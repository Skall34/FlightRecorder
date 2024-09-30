using FlightRecorder.Properties;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FlightRecorder
{


    public partial class Form1 : Form
    {
        private bool autostart = false;

        //private Offset<short> parkingBrake = new Offset<short>(0x0BC8);
        FsPositionSnapshot? _currentPosition;
        FsPositionSnapshot? _startPosition;
        FsPositionSnapshot? _endPosition;

        private bool atLeastOneEngineFiring;
        private double _startFuel;
        private double _endFuel;
        private double _endPayload;

        private DateTime _startTime;
        private DateTime _endTime;

        private DateTime _airborn;
        private DateTime _notAirborn;

        private readonly simData _simData;


        private FlightPerfs flightPerfs;

        public bool onGround;
        private bool gearIsUp;
        private uint flapsPosition;
        private bool _planeReserved;
        private double _currentFuel;
        private bool _refuelDetected;

        private readonly List<Mission> missions;
        private readonly List<Avion> avions;
        private readonly List<Aeroport> aeroports;
        private Aeroport? localAirport;

        private int startDisabled; // if startDisabled==0, then start is possible, if not, start is disabled. each 100ms, the counter will be decremented
        private int endDisabled;

        private readonly string BASERURL;
        Version? version;

        public static bool isAutoStart()
        {
            // Récupérer les paramètres de la ligne de commande
            string[] args = Environment.GetCommandLineArgs();

            // Vérifier si "-auto" est présent dans les arguments
            foreach (string arg in args)
            {
                if (arg.Equals("-auto", StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Retourne true si "-auto" est trouvé
                }
            }

            return false; // Retourne false si "-auto" n'est pas trouvé
        }

        //private bool modifiedFuel;
        public Form1()
        {
            InitializeComponent();

            autostart = isAutoStart();
            //utilisation de la nouvelle classe de combobox item pour mettre des elements non selectionables
            this.cbImmat.ValueMember = "Immat";
            this.cbImmat.DisplayMember = "Immat";

            //initialize the trace mechanism
            Logger.init();

            Logger.WriteLine("Starting flightrecorder");
            if (autostart)
            {
                Logger.WriteLine("Autostarted");
            }

            //get the google sheet API url from the app settings
            BASERURL = Settings.Default.GSheetAPIUrl;

            // Get the version information of your application
            Assembly? assembly = Assembly.GetEntryAssembly();
            if (null != assembly)
            {
                version = assembly.GetName().Version;
                if (null == version)
                {
                    version = new Version("unknown");
                }
                // Set the form's title to include the version number
                this.Text = $"FlightRecorder - Version {version.ToString(3)}";
                if (autostart)
                {
                    this.Text += " autostarted";
                }
                Logger.WriteLine($"Version : {version.ToString(3)}");
            }
            else
            {
                version = new Version("unknown");
            }

            this.Cursor = Cursors.WaitCursor;
            aeroports = new List<Aeroport>();
            avions = new List<Avion>();
            missions = new List<Mission>();

            flightPerfs = new FlightPerfs();

            Logger.WriteLine("start loading airports database");
            LoadAirportsFromSheet();
            Logger.WriteLine("start loading planes and missions");
            LoadDataFromSheet();

            //initialise l'object qui sert à capter les données qui viennent du simu
            Logger.WriteLine("initialize the connection to the simulator");
            _simData = new simData();

            //initialise des variables qui servent à garder un état.
            cbNote.SelectedItem = 8;
            atLeastOneEngineFiring = false;
            _startTime = DateTime.Now;
            _endTime = DateTime.Now;
            _airborn = DateTime.Now;
            _notAirborn = DateTime.Now;

            _startFuel = 0;
            _endFuel = 0;
            _currentFuel = 0;
            _refuelDetected = false;
            _endPayload = 0;

            lbStartFuel.Text = "Not Yet Available";
            lbEndFuel.Text = "Waiting end flight ...";
            lbStartIata.Text = "Not Yet Available";
            lbEndIata.Text = "Waiting end flight ...";
            lbStartPosition.Text = "Not Yet Available";
            lbEndPosition.Text = "Waiting end flight ...";
            lbStartTime.Text = "--:--";
            lbEndTime.Text = "--:--";
            lbPayload.Text = "Not Yet Available";
            lbTimeAirborn.Text = "--:--";
            lbTimeOnGround.Text = "--:--";
            lbLibelleAvion.Text = "Not Yet Available";

            onGround = true;
            gearIsUp = false;
            flapsPosition = 0;

            //recupere le callsign qui a été sauvegardé en settings de l'application
            this.tbCallsign.Text = Settings.Default.callsign;
            //desactive le bouton de maj du setting. Il sera reactivé si le callsign est modifié.
            btnSaveSettings.Enabled = false;

            //met à jour l'etat de connection au simu dans la barre de statut
            Logger.WriteLine("update form status");
            ConfigureForm();

            //demarre le timer de connection (fait un essai de connexion toutes les 1000ms)
            this.timerConnection.Start();
        }

        //get the fleet, and missions from the google sheet
        private async void LoadAirportsFromSheet()
        {
            //load the airports.
            this.aeroports.AddRange(await Aeroport.fetchAirports(BASERURL, DateTime.UnixEpoch));
            //just in case, reload the statc values
            if (aeroports.Count > 0)
            {
                ReadStaticValues();
            }
            else
            {
                MessageBox.Show("airport database is empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Logger.WriteLine("done loading airports database");
            this.Cursor = Cursors.Default;
        }

        private async void LoadDataFromSheet()
        {
            string url = BASERURL + "?query=fleet";
            UrlDeserializer dataReader = new UrlDeserializer(url);

            (List<Avion> avions, List<Mission> missions) = await dataReader.FetchDataAsync();
            this.avions.Clear();
            this.missions.Clear();
            this.avions.AddRange(avions);
            this.missions.AddRange(missions);

            if (avions.Count == 0)
            {
                MessageBox.Show("planes database is empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (missions.Count == 0)
            {
                MessageBox.Show("No mission available !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RemplirComboImmat();
            RemplirComboMissions();

            Logger.WriteLine("done loading planes and missions");

            this.Cursor = Cursors.Default;
        }

        private async Task<float> GetFretOnAirport(string airportIdent)
        {
            string url = BASERURL + "?query=freight&airport=" + airportIdent;
            float fret = await Aeroport.fetchFreight(BASERURL, airportIdent);
            if (fret > 0)
            {
                lbFret.Text = "Available freight at " + airportIdent + " : " + fret.ToString();
            }
            else
            {
                lbFret.Text = "No freight here";
            }
            Logger.WriteLine("Found freight " + fret.ToString() + " at airport " + airportIdent);
            return fret;
        }

        private async void ReadStaticValues()
        {
            //Logger.WriteLine("Reading static values");
            try
            {
                if ((null != _simData) && (_simData.isConnected))
                {
                    //commence à lire qq variables du simu : fuel & cargo, immat avion...
                    this.lbPayload.Text = _simData.GetPayload().ToString("0.00");

                    //recupere l'emplacement courant :
                    _currentPosition = _simData.GetPosition(); ;

                    //Recupere le libellé de l'avion
                    string planeNomComplet = _simData.GetAircraftType();
                    lbLibelleAvion.Text = planeNomComplet;

                    double lat = _currentPosition.Location.Latitude.DecimalDegrees;
                    double lon = _currentPosition.Location.Longitude.DecimalDegrees;

                    if ((aeroports != null) && (aeroports.Count > 0))
                    {
                        Aeroport? currentAirport = Aeroport.FindClosestAirport(aeroports, lat, lon);
                        if ((currentAirport != null) && (currentAirport != localAirport))
                        {
                            localAirport = currentAirport;
                            string? startAirportname = localAirport.name;

                            if ((this.aeroports != null) && (startAirportname != null))
                            {
                                // Votre code pour utiliser les avions et les aéroports
                                float fretOnAirport = await GetFretOnAirport(localAirport.ident);
                                //lbFret.Text = fretOnAirport.ToString() + " Kg available " + startAirportname;
                            }
                        }
                    }
                    //recupere le type d'avion donné par le simu.
                    Logger.WriteLine("Simulator aircraft loaded : " + _simData.GetAircraftType());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Exception caught : " + ex.Message);
            }
        }

        // appelé chaque 1s par le timer de connection
        private void TimerConnection_Tick(object sender, EventArgs e)
        {
            // Try to open the connection
            try
            {
                if ((aeroports.Count > 0) && (avions.Count > 0) && (missions.Count > 0))
                {

                    //essaie d'ouvrir la connection. Si ça échoue, une exception sera envoyée
                    _simData.OpenConnection();

                    Logger.WriteLine("Connected to simulator");
                    //si on arrive ici, la connection est bien ouverte, arrete le timer de connection.
                    this.timerConnection.Stop();

                    //read the value that normally don't change (except change of plane, or cargo)
                    ReadStaticValues();

                    //demarre le timer principal, qui lit les infos du simu 2x par 1s.
                    this.timerMain.Start();

                    // met à jour le status de connection dans la barre de statut.
                    ConfigureForm();
                }
                else
                {
                    Logger.WriteLine("Still waiting for data before connecting to simulator");
                }
            }
            catch
            {
                // No connection found. Don't need to do anything, just keep trying
                if (autostart)
                {
                    //if flight recorder was started automatically by the simulator, then exit when simulator is not there anymore.
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        private void getStartOfFlightData()
        {
            endDisabled = 1;
            lbEndFuel.Enabled = false;
            lbEndPosition.Enabled = false;
            lbEndTime.Enabled = false;
            lbEndIata.Enabled = false;

            _startPosition = _simData.GetPosition();

            double lat = _startPosition.Location.Latitude.DecimalDegrees;
            double lon = _startPosition.Location.Longitude.DecimalDegrees;

            Aeroport? localAirport = Aeroport.FindClosestAirport(aeroports, lat, lon);
            if (localAirport != null)
            {
                string? startAirportname = localAirport.name;
                lbStartPosition.Text = startAirportname;
                lbStartIata.Text = localAirport.ident;
            }

            _startFuel = _simData.GetFuelWeight();
            _startTime = DateTime.Now;
            this.lbStartTime.Text = _startTime.ToShortTimeString();
            //0.00 => only keep 2 decimals for the fuel

            this.lbStartFuel.Text = _startFuel.ToString("0.00");

        }

        private void getEndOfFlightData()
        {
            // disable start detection for 300 x 100 ms =30s  disable the start text boxes.
            startDisabled = 300;
            lbStartFuel.Enabled = false;
            lbStartPosition.Enabled = false;
            lbStartTime.Enabled = false;
            lbStartIata.Enabled = false;

            //on recupere les etats de fin de vol : heure, carbu, position.
            _endPosition = _simData.GetPosition();
            double lat = _endPosition.Location.Latitude.DecimalDegrees;
            double lon = _endPosition.Location.Longitude.DecimalDegrees;

            Aeroport? localAirport = Aeroport.FindClosestAirport(aeroports, lat, lon);
            if (localAirport != null)
            {
                string endAirportname = localAirport.name;
                lbEndPosition.Text = endAirportname;
                lbEndIata.Text = localAirport.ident;
            }

            _endFuel = _simData.GetFuelWeight();
            _endTime = DateTime.Now;
            this.lbEndTime.Text = _endTime.ToShortTimeString();
            //0.00 => only keep 2 decimals for the fuel
            this.lbEndFuel.Text = _endFuel.ToString("0.00");
            _endPayload = _simData.GetPayload();
            //compute the note of the flight
            AnalyseFlight();
        }

        // This method runs 2 times per second (every 500ms). This is set on the timerMain properties.
        private async void TimerMain_Tick(object sender, EventArgs e)
        {
            try
            {
                if (startDisabled > 0)
                {
                    startDisabled -= 1;

                    if (startDisabled <= 0)
                    {
                        //the start detection disable timer expired, restore the start textboxes.
                        lbStartFuel.Enabled = true;
                        lbStartPosition.Enabled = true;
                        lbStartTime.Enabled = true;
                        lbStartIata.Enabled = true;
                    }
                }

                if (endDisabled > 0)
                {
                    endDisabled -= 1;

                    if (endDisabled <= 0)
                    {
                        //the start detection disable timer expired, restore the start textboxes.
                        lbEndFuel.Enabled = true;
                        lbEndPosition.Enabled = true;
                        lbEndTime.Enabled = true;
                        lbEndIata.Enabled = true;
                    }
                }

                //rafraichis les données venant du simu
                _simData.Refresh();

                // Airspeed
                double airspeedKnots = _simData.GetAirSpeed();
                double currentFuel = _simData.GetFuelWeight();

                //check if we are in the air
                if (_simData.GetOnground() == 0)
                {
                    if (onGround)
                    {
                        Logger.WriteLine("Takeoff detected !");

                        //we just took off ! read the plane weight
                        flightPerfs.takeOffWeight = _simData.GetPlaneWeight();
                        //keep memory that we're airborn
                        onGround = false;
                        // on veut afficher la date
                        _airborn = DateTime.Now;
                        if (lbTimeAirborn.Text == "--:--")
                        {
                            this.lbTimeAirborn.Text = _airborn.ToString("HH:mm");
                        }

                        // On cache le label du Fret après le décollage. On en a plus besoin
                        this.lbFret.Visible = false;
                        //on grise le bouton save flight en vol
                        btnSubmit.Enabled = false;
                        submitFlightToolStripMenuItem.Enabled = false;
                        //just incase of rebound during takeoff, reset the onground label
                        lbTimeOnGround.Text = "--:--";

                    }

                    flightPerfs.landingVerticalAcceleration = _simData.GetVerticalAcceleration();
                    flightPerfs.landingSpeed = _simData.GetAirSpeed();
                }
                else //we're on ground !
                {
                    if (!onGround)
                    {
                        Logger.WriteLine("Landing detected !");

                        //only update the touchDownVSpeed if we've been airborn once
                        flightPerfs.touchDownVSpeed = _simData.GetLandingVerticalSpeed();
                        flightPerfs.landingWeight = _simData.GetPlaneWeight();

                        _notAirborn = DateTime.Now;
                        if (lbTimeOnGround.Text == "--:--")
                        {
                            this.lbTimeOnGround.Text = _notAirborn.ToString("HH:mm");
                        }

                        onGround = true;

                        //enable the save button
                        btnSubmit.Enabled = true;
                        submitFlightToolStripMenuItem.Enabled = true;
                    }

                    //si on est au sol, et moteur arretés, alors on continue de rafraichir les données statiques.
                    //sinon (en vol, ou des que les moteurs sont allumés, on ne change plus ça).
                    if (!atLeastOneEngineFiring)
                    {
                        ReadStaticValues();
                    }

                    //si on est au sol, et qu'on a lu une valeur de fuel, ET le fuel augmente, on detecte un refuel !
                    if (!_refuelDetected && (_currentFuel > 0) && (currentFuel > _currentFuel))
                    {
                        _refuelDetected = true;
                        //on detecte un refuel !
                        //il faut peut-être faire un reset ?
                        Logger.WriteLine("Refuel detected ! new fuel " + currentFuel + " > " + _currentFuel + " (old fuel))");
                        this.WindowState = FormWindowState.Normal;
                        _currentFuel = currentFuel;
                        //si on refuel pendant qu'un moteur tourne, c'est suspect. Envoie la popup pour proposer le reset !
                        if (atLeastOneEngineFiring)
                        {
                            MessageBox.Show("Refuel detected ! you should reset the flight !");
                        }
                        else
                        {
                            //sinon, refuel sans moteur arreté.
                            // on reste le vol direct ? et s'il n'a pas été soumis ? 
                            if (btnSubmit.Enabled)
                            {
                                //le bouton submit est encore actif, donc peut-etre que le vol n'a pas été soumis. Demande une confirmation
                                resetFlight(false);
                            }
                            else
                            {
                                //le bouton submit est encore inactif, donc le vol a été soumis, on peut reset
                                resetFlight(true);
                            }
                        }
                    }

                }

                //keep new value of current fuel quantity
                _currentFuel = currentFuel;

                if (_simData.GetGearRetractableFlag() == 1)
                {
                    //check gear position, if gear just deployed, get the airspeed
                    bool currentGearIsUp = gearIsUp;
                    gearIsUp = _simData.GetIsGearUp();
                    if (!gearIsUp && currentGearIsUp)
                    {
                        Logger.WriteLine("Gear down detected. Measure speed");
                        //get the max air speed while deploying the gears
                        if (airspeedKnots > flightPerfs.gearDownSpeed)
                        {
                            //gear just went to be deployed ! check the current speed !!!
                            flightPerfs.gearDownSpeed = airspeedKnots;
                        }
                    }
                }

                if (_simData.GetFlapsAvailableFlag() == 1)
                {
                    //check the flaps deployment speed
                    uint currentFlapsPosition = flapsPosition;
                    flapsPosition = _simData.GetFlapsPosition();
                    //if flaps just went deployed, get the air speed.
                    if ((currentFlapsPosition == 0) && (flapsPosition > 0))
                    {
                        Logger.WriteLine("Flaps down detected. Measure speed");
                        //only keep the max flaps deployment air speed for this flight
                        if (airspeedKnots > flightPerfs.flapsDownSpeed)
                        {
                            flightPerfs.flapsDownSpeed = airspeedKnots;
                        }
                    }
                }


                if (_simData.GetOverspeedWarning() != 0)
                {
                    Logger.WriteLine("overspeed warning detected");
                    flightPerfs.overspeed = true;
                }
                if (_simData.GetOffRunwayCrashed() != 0)
                {
                    Logger.WriteLine("off runway crashed detected");
                    flightPerfs.overRunwayCrashed = true;
                }
                if (_simData.GetCrashedFlag() != 0)
                {
                    Logger.WriteLine("crash detected");
                    flightPerfs.crashed = true;
                }
                if (_simData.GetStallWarning() != 0)
                {
                    Logger.WriteLine("stall warning detected");
                    flightPerfs.stallWarning = true;
                }

                //on va verifier l'etat des moteurs :

                //sauvegarde l'etat precedent des moteurs
                bool _previousEngineStatus = atLeastOneEngineFiring;
                //lit le nouvel etat.
                atLeastOneEngineFiring = _simData.IsAtLeastOneEngineFiring();

                //si aucun moteur de tournait, mais que maintenant, au moins un moteur tourne, on commence a enregistrer.
                //on va memoriser les etats de carburant, et l'heure. On récupere aussi quel est l'aeroport.
                if ((!_previousEngineStatus && atLeastOneEngineFiring) && (startDisabled == 0))
                {
                    if (engineStopTimer.Enabled)
                    {
                        Logger.WriteLine("Engine stop canceled. Validation timer stopped");
                        engineStopTimer.Stop();
                    }
                    else
                    {
                        if (onGround)
                        {
                            Logger.WriteLine("First engine start detected for plane" + cbImmat.Text);
                            this.WindowState = FormWindowState.Minimized;
                            getStartOfFlightData();

                            //Update the google sheet database indicating that this plane is being used
                            UpdatePlaneStatus(1);
                            cbImmat.Enabled = false;
                            //tbEndICAO.Enabled = false;
                        }
                        else
                        {
                            //demarrage des moteur en vol (redémarrage)... ne rien faire.
                            Logger.WriteLine("Engine start during flight. Do nothing");
                        }
                    }
                }

                // si on detecte un arret moteur
                if (_previousEngineStatus && !atLeastOneEngineFiring)
                {
                    // si on est au sol, et qu'on autorise la detection de l'arret moteur
                    if (onGround && (endDisabled == 0))
                    {
                        Logger.WriteLine("Potential engine stop detected. Start validation timer");
                        engineStopTimer.Start();
                    }
                    else
                    {
                        //si on est en vol, OU si la detection est desactivée, ne rien faire.
                        Logger.WriteLine("Potential engine stop detected during flight. Do nothing");
                    }
                }

            }
            catch (Exception ex)
            {
                //log the excepction
                Logger.WriteLine("Communication with FSUIPC Failed\n\n" + ex.Message);
                // An error occured. Tell the user and stop this timer.
                this.timerMain.Stop();
                // Update the connection status
                ConfigureForm();
                // re-start the connection timer
                this.timerConnection.Start();
            }
        }

        // Configures the status label depending on if we're connected or not 
        private void ConfigureForm()
        {
            //si la connection vers le simu est OK
            if (FSUIPCConnection.IsOpen)
            {
                this.lblConnectionStatus.Text = "Connected to " + FSUIPCConnection.FlightSimVersionConnected.ToString();
                this.lblConnectionStatus.ForeColor = Color.Green;
            }
            else
            {
                this.lblConnectionStatus.Text = "Disconnected. Looking for Flight Simulator...";
                this.lblConnectionStatus.ForeColor = Color.Red;
            }
        }

        // Form is closing so stop all the timers and close FSUIPC Connection
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            string message = "Confirm close ACARS ?";
            if (this.btnSubmit.Enabled == true)
            {
                //Le vol n'a PAS été envoyé
                message += "\r\n !!! Le vol n'a pas été envoyé !!!";
            }
            DialogResult res = DialogResult.Cancel;

            if (!autostart)
            {
                res = MessageBox.Show(message, "Flight Recorder", MessageBoxButtons.OKCancel);
            }
            else
            {
                //si il y a eu un vol, ET que les moteurs sont arretés, envoie le vol vers la google sheet
                if ((this.btnSubmit.Enabled == true) && (!atLeastOneEngineFiring))
                {
                    saveFlight();
                }
            }

            if ((res == DialogResult.OK) || (autostart))
            {
                if (atLeastOneEngineFiring)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.lblConnectionStatus.Text = "Freeing plane...";
                    this.lblConnectionStatus.ForeColor = Color.Green;
                    // Libère l'avion sur le fichier en cas de fermeture de l'acars avant la fin du vol
                    // on ne le fait que si un moteur tourne encore ==> vol interrompu avant la fin
                    UpdatePlaneStatus(0);
                    cbImmat.Enabled = true;
                    //tbEndICAO.Enabled = true;
                    System.Threading.Thread.Sleep(2000);
                    this.Cursor = Cursors.Default;
                }
                //arrete les timers.
                this.timerConnection.Stop();
                this.timerMain.Stop();
                //ferme la connection vers le simu
                FSUIPCConnection.Close();

                //stop and flush the traces 
                Logger.Dispose();
            }
            else
            {
                // Si l'utilisateur clique sur Annuler, annule la fermeture de la fenêtre.
                e.Cancel = true;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //si l'utilisateur a modifié le texte du callsign, active le bouton pour le sauvrgarder
            btnSaveSettings.Enabled = true;
        }

        //sauvegarde du callsign comme setting de l'application
        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            //met le callsign en majuscules
            tbCallsign.Text = tbCallsign.Text.ToUpper();
            //recupere le texte dans le setting
            Settings.Default.callsign = tbCallsign.Text;
            //sauve le setting
            Settings.Default.Save();
            //desactive le bouton de sauvegarde.
            this.btnSaveSettings.Enabled = false;
        }

        private bool CheckBeforeSave()
        {
            if (tbCallsign.Text == string.Empty)
            {
                throw new Exception("Please indicate callsign and click 'Apply'.");
            }

            // Define the regular expression pattern
            string pattern = @"^SKY\d{4}$";
            // Create a Regex object with the pattern
            Regex regex = new Regex(pattern);
            // Check if the input string matches the pattern
            if (!regex.IsMatch(tbCallsign.Text))
            {
                throw new Exception("The string starts with 'SKY' followed by four numbers.");
            }

            if (cbMission.Text == string.Empty)
            {
                throw new Exception("Please select a mission.");
            }

            if (cbImmat.Text == string.Empty)
            {
                throw new Exception("Please select a plane immatriculation.");
            }

            return true;
        }

        private async void saveFlight()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //if end of flight is not detected, get the data
                if (atLeastOneEngineFiring)
                {
                    //garde le commentaire entré manuellement
                    //string flightComment = tbCommentaires.Text;
                    Logger.WriteLine("Forcing end of flight detection before save");
                    getEndOfFlightData();
                    //get the computed flight comments.
                    //string autoComment = tbCommentaires.Text;
                    //concatene les deux commentaires.
                    //tbCommentaires.Text = flightComment + " " + autoComment;
                }

                CheckBeforeSave();

                string fullComment = tbCommentaires.Text;
                //crée un dictionnaire des valeurs à envoyer
                Dictionary<string, string> values = new Dictionary<string, string>();
                UrlDeserializer.SaveFlightQuery data = new UrlDeserializer.SaveFlightQuery
                {
                    query = "save",
                    qtype = "json",
                    cs = tbCallsign.Text,
                    plane = cbImmat.Text,
                    sicao = lbStartIata.Text,
                    sfuel = lbStartFuel.Text,
                    stime = lbStartTime.Text,
                    eicao = lbEndIata.Text,
                    efuel = lbEndFuel.Text,
                    etime = lbEndTime.Text,
                    note = cbNote.Text,
                    mission = cbMission.Text,
                    comment = fullComment,
                    cargo = _endPayload.ToString("0.00")
                };
                UrlDeserializer urlDeserializer = new UrlDeserializer(BASERURL);

                //sauve le vol dans le fichier "lastflight.json"
                await urlDeserializer.SaveLocalJsonAsync(data, "lastflight.json");
                //envoie le vol vers le serveur
                int result = await urlDeserializer.PushJSonAsync<UrlDeserializer.SaveFlightQuery>(data);
                //int result = await urlDeserializer.PushFlightAsync(data);
                if (0 != result)
                {
                    //si tout va bien...
                    this.lblConnectionStatus.Text = "Flight data saved";
                    this.lblConnectionStatus.ForeColor = Color.Green;
                    MessageBox.Show("Flight saved. Thank you for flying with SKYWINGS :)", "Flight Recorder");

                    //reset le vol sans demande de confirmation
                    resetFlight(true);
                }
                else
                {
                    //en, cas d'erreur, affiche une popup avec le message
                    MessageBox.Show("Error while sending flight data.");
                }
                // On grise le bouton save flight pour éviter les doubles envois
                btnSubmit.Enabled = false;
                submitFlightToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                //in case if check error, or exception durong save, show a messagebox containing the error message
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;

        }
        //envoi des données au google form
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            saveFlight();
        }

        private void tbEndICAO_TextChanged(object sender, EventArgs e)
        {
            // Obtenir le texte actuel
            string text = tbEndICAO.Text;

            // Transformer en majuscules
            text = text.ToUpper();

            // Garder uniquement les lettres majuscules et les chiffres
            text = new string(text.Where(c => char.IsUpper(c) || char.IsDigit(c)).ToArray());

            // Limiter la longueur du texte à 4 caractères
            if (text.Length > 4)
            {
                text = text.Substring(0, 4);
            }

            // Mettre à jour le texte de la TextBox si nécessaire
            if (text != tbEndICAO.Text)
            {
                int selectionStart = tbEndICAO.SelectionStart; // Sauvegarder la position du curseur
                tbEndICAO.Text = text;
                tbEndICAO.SelectionStart = selectionStart > text.Length ? text.Length : selectionStart; // Restaurer la position du curseur
            }

            //only send the update if the text is long enough
            if (text.Length == 4)
            {
                UpdatePlaneStatus(_planeReserved ? 1 : 0);
                //todo ! search for this airport in the database.
                //if found, udate the tooltip with the airport name.
            }
        }


        private async void UpdatePlaneStatus(int isFlying)
        {
            try
            {
                //crée un dictionnaire des valeurs à envoyer
                Dictionary<string, string> values = new Dictionary<string, string>();
                UrlDeserializer.PlaneUpdateQuery data = new UrlDeserializer.PlaneUpdateQuery
                {
                    query = "updatePlaneStatus",
                    qtype = "json",
                    cs = tbCallsign.Text,
                    plane = cbImmat.Text,
                    sicao = lbStartIata.Text,
                    flying = isFlying,
                    endIcao = tbEndICAO.Text
                };
                UrlDeserializer urlDeserializer = new UrlDeserializer(BASERURL);
                int result = await urlDeserializer.PushJSonAsync<UrlDeserializer.PlaneUpdateQuery>(data);
                //int result = await urlDeserializer.PushFlightAsync(data);
                if (0 != result)
                {
                    Logger.WriteLine("Plane data updated");
                    //si tout va bien...
                    this.lblConnectionStatus.Text = "Plane data updated";
                    this.lblConnectionStatus.ForeColor = Color.Green;
                    if (isFlying == 1)
                    {
                        _planeReserved = true;
                    }
                    else
                    {
                        _planeReserved = false;
                    }
                }
                else
                {
                    Logger.WriteLine("Error while updating plane data");
                    //si tout va mal ...
                    this.lblConnectionStatus.Text = "Error while updating plane data";
                    this.lblConnectionStatus.ForeColor = Color.Red;

                }
            }
            catch (Exception ex)
            {
                //in case if check error, or exception durong save, show a messagebox containing the error message
                MessageBox.Show(ex.Message);
            }
        }

        private void RemplirComboImmat()
        {
            lbFret.Text = "Acars initializing ..... please wait";
            // Effacez les éléments existants dans la combobox
            cbImmat.Items.Clear();
            if (avions != null)
            {
                avions.Sort();
                // Parcourez la liste des avions
                foreach (Avion? avion in avions)
                {
                    //// Vérifiez si le statut de l'avion est égal à 1
                    //if (avion.Status == 1 || avion.Status == 2 || ((avion.EnVol == 1) && (avion.DernierUtilisateur != tbCallsign.Text)))
                    //{
                    //    // Si le statut est égal à 1 ou 2, il est en maintenance,
                    //    // passez à l'itération suivante
                    //    // Si l'avion est en vol, on ne le liste pas (execption, si l'utilisateur courant est celui qui a laissé l'avion en vol)
                    //    // (permet de libérer un avion qui serait bloqué en vol suite à un crash du simulateur)
                    //    continue;
                    //}
                    // Ajoutez l'immatriculation de l'avion à la liste des immatriculations
                    if (null != avion.Immat)
                    {
                        //immatriculations.Add(avion.Immat);
                        cbImmat.Items.Add(avion);
                    }
                }
                cbImmat.DisplayMember = "Immat";


                //pre-select the last used immat (stored as setting)
                string lastImmat = Settings.Default.lastImmat;
                if (lastImmat != string.Empty)
                {
                    Avion selected = avions.Where(a => a.Immat == lastImmat).First();
                    cbImmat.SelectedItem = selected;
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void RemplirComboMissions()
        {
            if (missions != null)
            {
                cbMission.Items.AddRange(missions.Select(mission => mission.Libelle).Where(mission => !string.IsNullOrEmpty(mission)).ToArray());
            }
            //await dataReader.FillComboBoxMissionsAsync(cbMission);
            cbMission.DisplayMember = "Libelle";
            this.Cursor = Cursors.Default;
        }

        private int AnalyseFlight()
        {

            string comment = flightPerfs.getFlightComment();

            if (tbCommentaires.Text.Length > 0)
            {
                tbCommentaires.Text += " " + comment;
            }
            else
            {
                tbCommentaires.Text = comment;
            }
            tbCommentaires.Text += " (F.R. V" + version.ToString(3) + ")";

            int note = flightPerfs.getFlightNote();
            cbNote.Text = note.ToString();
            return note;
        }

        private void CbNote_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Flight details";
            string tipText = flightPerfs.getFlightNoteDetails();

            toolTip1.SetToolTip((Control)sender, tipText);

            toolTip1.Show(tipText, this, 5000);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

        }

        private void resetFlight(bool force) //force ==true => pas de demande de confirmation
        {
            Logger.WriteLine("Reseting flight");
            DialogResult res = DialogResult.OK;
            if (!force)
            {
                res = MessageBox.Show("Confirm flight reset ?", "Flight Recorder", MessageBoxButtons.OKCancel);
            }

            if (res == DialogResult.OK)
            {

                lbStartIata.Text = string.Empty;
                lbStartFuel.Text = string.Empty;
                lbStartPosition.Text = string.Empty;
                lbStartTime.Text = string.Empty;

                lbEndTime.Text = string.Empty;
                lbEndFuel.Text = string.Empty;
                lbEndIata.Text = string.Empty;
                lbEndPosition.Text = string.Empty;

                tbCommentaires.Text = string.Empty;
                cbMission.Text = string.Empty;

                tbEndICAO.Text = string.Empty;

                lbStartFuel.Text = "Waiting start";
                lbEndFuel.Text = "Waiting end ...";
                lbStartIata.Text = "Waiting start";
                lbEndIata.Text = "Waiting end ...";
                lbStartPosition.Text = "Waiting start";
                lbEndPosition.Text = "Waiting end ...";
                lbStartTime.Text = "Waiting start";
                lbEndTime.Text = "Waiting end ...";
                lbTimeAirborn.Text = "--:--";
                lbTimeOnGround.Text = "--:--";
                lbFret.Visible = true;
                cbNote.SelectedItem = 8;

                //reset flight infos.
                flightPerfs.overRunwayCrashed = false;
                flightPerfs.crashed = false;
                flightPerfs.stallWarning = false;
                flightPerfs.overspeed = false;

                atLeastOneEngineFiring = false;

                //reenable start detection at next timer tick
                startDisabled = 1;
                endDisabled = 1;
                _refuelDetected = false;
                _endPayload = 0;

                //on peut préparer un nouveau vol
                cbImmat.Enabled = true;
                tbEndICAO.Enabled = true;
                lbPayload.Enabled = true;

                btnSubmit.Enabled = false;
                submitFlightToolStripMenuItem.Enabled = false;
                Logger.WriteLine("Flight reset");
            }
            else
            {
                Logger.WriteLine("Flight reset canceled");
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //reset flight avec demande de confirmation
            resetFlight(false);
        }

        private void CbImmat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Avion? selectedPlane = this.avions.Where(a => a.Immat == cbImmat.Text).FirstOrDefault();
            if (selectedPlane != null)
            {
                if ((selectedPlane.Status == 1) || (selectedPlane.Status == 2) || ((selectedPlane.EnVol == 1) && (selectedPlane.DernierUtilisateur != tbCallsign.Text)))
                {
                    cbImmat.SelectedItem = null;
                    lbDesignationAvion.Text = "<no plane selected>";
                }
                else
                {
                    string? planeDesign = selectedPlane.Designation;
                    lbDesignationAvion.Text = planeDesign;
                    // #34 sauvegarder la derniere immat utilisée
                    Settings.Default.lastImmat = cbImmat.Text;
                    Settings.Default.Save();

                    //si cet avion est marqué comme deja en vol, c'est par l'utilisateur courant. 
                    //marque cet avion comme n'etant plus en vol.
                    if ((selectedPlane.EnVol == 1) && selectedPlane.DernierUtilisateur == tbCallsign.Text)
                    {
                        Logger.WriteLine("Freeing the airplane on the sheet");
                        UpdatePlaneStatus(0);
                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void resetFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reset flight avec demande de confirmation
            resetFlight(false);
        }

        private void submitFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFlight();
        }

        private void submitBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.suspend();
            List<string> allLog = Logger.getFullLog();
            Logger.restart();

            BugForm bf = new BugForm(tbCallsign.Text, allLog, BASERURL);
            bf.ShowDialog();

        }

        private void engineStopTimer_Tick(object sender, EventArgs e)
        {
            //if this happen, then the engine are definitively stopped.
            Logger.WriteLine("Last engine stop detected");
            this.WindowState = FormWindowState.Normal;
            getEndOfFlightData();

            //Update the google sheet database indicating that this plane is no more used
            UpdatePlaneStatus(0);
            cbImmat.Enabled = true;
            tbEndICAO.Enabled = true;
            //stop this timer
            engineStopTimer.Stop();
        }

        private void tbEndICAO_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "destination airport";
            Aeroport? dest = aeroports.FirstOrDefault(a => a.ident == tbEndICAO.Text);
            if (null != dest)
            {
                toolTip1.SetToolTip((Control)sender, dest.name);
                toolTip1.Show(dest.name, this, 5000);
            }

        }

        private void cbImmat_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush myBrush = Brushes.Black;

            // Determine the color of the brush to draw each item based 
            // on the index of the item to draw.


            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            if (e.Index >= 0)
            {
                Avion item = (Avion)cbImmat.Items[e.Index];
                switch (item.Status)
                {
                    case 0:
                        myBrush = Brushes.Black; //avion disponible
                        break;
                    case 1:
                        myBrush = Brushes.LightGray; //avion non disponible (en maintenance).
                        break;
                    case 2:
                        myBrush = Brushes.LightGray;//avion non disponible (en maintenance).
                        break;
                }

                if (item.EnVol == 1)
                {
                    if (item.DernierUtilisateur != tbCallsign.Text)
                    {
                        myBrush = Brushes.LightGray; //avion non disponible (utilisé par qqun d'autre).
                    }
                    else
                    {
                        myBrush = Brushes.Blue; //avion non disponible (deja pris par moi).
                    }
                }

                e.Graphics.DrawString(item.Immat,
                    e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            }
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        //private bool isAutoStartRegistered()
        //{
        //    bool result = false;

        //    try
        //    {
        //        // Obtenir le chemin du répertoire AppData\Roaming\MSFS de l'utilisateur courant
        //        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //        string msfsDirectory = Path.Combine(appDataPath, "Microsoft Flight Simulator");
        //        string exeXmlPath = Path.Combine(msfsDirectory, "exe.xml");

        //        // Vérifier si le fichier exe.xml existe
        //        if (!File.Exists(exeXmlPath))
        //        {
        //            Logger.WriteLine("Le fichier exe.xml n'existe pas dans le répertoire spécifié.");
        //            return false;
        //        }

        //        // Lire le fichier en utilisant l'encodage Windows-1252
        //        string xmlContent;
        //        using (StreamReader reader = new StreamReader(exeXmlPath, System.Text.Encoding.GetEncoding("Windows-1252")))
        //        {
        //            xmlContent = reader.ReadToEnd();
        //        }

        //        // Charger le contenu XML dans l'objet XmlDocument
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(xmlContent);

        //        // Afficher le contenu pour vérification (ou effectuer des modifications si nécessaire)
        //        Logger.WriteLine($"Fichier XML chargé depuis : {exeXmlPath}");
        //        Logger.WriteLine(xmlDoc.OuterXml);

        //        // Ici, tu peux ajouter ou modifier des éléments dans le fichier XML si nécessaire
        //        // Par exemple : xmlDoc.DocumentElement.AppendChild(newElement);
        //        foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
        //        {
        //            if (node.Name == "Launch.Addon")
        //            {
        //                if (node.HasChildNodes)
        //                {
        //                    foreach (XmlNode childNode in node.ChildNodes)
        //                    {
        //                        if ((childNode.Name=="Name")&&(childNode.InnerText == "Flight Recorder"))
        //                        {
        //                            result = true;
        //                        }
        //                    }
        //                }

        //            }
        //        }
               
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLine($"Erreur lors de l'ouverture du fichier exe.xml : {ex.Message}");
        //    }
        //    return result;
        //}
        //private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //    try
        //    {
        //        // Obtenir le chemin du répertoire AppData\Roaming\MSFS de l'utilisateur courant
        //        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //        string msfsDirectory = Path.Combine(appDataPath, "Microsoft Flight Simulator");
        //        string exeXmlPath = Path.Combine(msfsDirectory, "exe.xml");

        //        // Vérifier si le fichier exe.xml existe
        //        if (!File.Exists(exeXmlPath))
        //        {
        //            Logger.WriteLine("Le fichier exe.xml n'existe pas dans le répertoire spécifié.");
        //            return;
        //        }

        //        // Lire le fichier en utilisant l'encodage Windows-1252
        //        string xmlContent;
        //        using (StreamReader reader = new StreamReader(exeXmlPath, System.Text.Encoding.GetEncoding("Windows-1252")))
        //        {
        //            xmlContent = reader.ReadToEnd();
        //        }

        //        // Charger le contenu XML dans l'objet XmlDocument
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(xmlContent);

        //        // Afficher le contenu pour vérification (ou effectuer des modifications si nécessaire)
        //        Logger.WriteLine($"Fichier XML chargé depuis : {exeXmlPath}");
        //        Logger.WriteLine(xmlDoc.OuterXml);

        //        // Ici, tu peux ajouter ou modifier des éléments dans le fichier XML si nécessaire
        //        // Par exemple : xmlDoc.DocumentElement.AppendChild(newElement);
        //        bool foundFlightRecorder = isAutoStartRegistered();

        //        if (!foundFlightRecorder)
        //        {

        //            //si le flight recorder n'a pas été trouvé.
        //            XmlNode newEntry = xmlDoc.CreateNode(XmlNodeType.Element, "Launch.Addon", "");
                    
        //            XmlNode disabled = newEntry.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Disabled", ""));
        //            disabled.InnerText = "False";
                    
        //            XmlNode manualLoad = newEntry.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "ManualLoad", ""));
        //            manualLoad.InnerText = "False";
                    
        //            XmlNode name = newEntry.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Name", ""));
        //            name.InnerText = "Flight Recorder";
                    
        //            XmlNode path = newEntry.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Path", ""));
        //            path.InnerText = Process.GetCurrentProcess().MainModule.FileName;
                    
        //            XmlNode commandline = newEntry.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "CommandLine", ""));
        //            commandline.InnerText = "-auto";

        //            XmlNode newConsole = newEntry.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "NewConsole", ""));
        //            newConsole.InnerText = "False";

        //            xmlDoc.DocumentElement.AppendChild(newEntry);


        //            // Sauvegarder les modifications (si des modifications ont été faites)
        //            xmlDoc.Save(exeXmlPath);
        //            MessageBox.Show("Demarrage auto enregistré. fermez le flight recorder, et relancez le simulateur.");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Flight recorder est deja enregistré dans l'auto start MSFS.");
        //        }

        //        Logger.WriteLine("Les modifications ont été enregistrées avec succès.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLine($"Erreur lors de l'ouverture du fichier exe.xml : {ex.Message}");
        //        MessageBox.Show("Erreur lors de l'enregistrement de l'auto start");
        //    }
        //}
    }
}
