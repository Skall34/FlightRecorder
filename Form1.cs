﻿using FlightRecorder.Properties;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FlightRecorder
{
    public partial class Form1 : Form
    {

        //private Offset<short> parkingBrake = new Offset<short>(0x0BC8);
        FsPositionSnapshot? _currentPosition;
        FsPositionSnapshot? _startPosition;
        FsPositionSnapshot? _endPosition;

        private bool atLeastOneEngineFiring;
        private double _startFuel;
        private double _endFuel;
        private string commentaires;
        //private string mission;
        //private int noteDuVol;

        private DateTime _startTime;
        private DateTime _endTime;

        //private airportsMgr airportsDatabase;
        private simData _simData;

        private bool stallWarning;
        private bool crashed;
        private bool overRunwayCrashed;
        private bool overspeed;
        private bool onGround;
        private double currentVSpeed;
        private double touchDownVSpeed;

        private bool gearIsUp;
        private uint flapsPosition;

        private double flapsDownSpeed;
        private double gearDownSpeed;

        private bool modifiedPayload; //a flag indicating that the user changed the payload
        private double FuelQtty;
        private int refillQtty;
        private double maxFuelCapacity;

        private double takeOffWeight;
        private double landingWeight;

        private List<Mission> missions;
        private List<Avion> avions;
        private List<Aeroport> aeroports;

        private int startDisabled; // if startDisabled==0, then start is possible, if not, start is disabled. each 100ms, the counter will be decremented
        
        private const string BASERURL = "https://script.google.com/macros/s/AKfycbwndkLVndehcRiBI8vEJ7ocdRz8RDo2BGLQ2YlhJFCQm0s06OnVfr8KrSD8RgBtCux9Tg/exec";
        
        private const string DEBUGBASEURL = "https://script.google.com/macros/s/AKfycbxeubE-ReLw4TCJHWg9kiLsXGw1-ISAf9KSJw9khJW_/dev";

        //private bool modifiedFuel;
        public Form1()
        {
            InitializeComponent();

            this.Cursor = Cursors.WaitCursor;
            aeroports = new List<Aeroport>();
            avions = new List<Avion>();
            missions = new List<Mission>();

            loadAirportsFromSheet();
            loadDataFromSheet();

            // Get the version information of your application
            Assembly? assembly = Assembly.GetEntryAssembly();
            if (null != assembly)
            {
                Version? version = assembly.GetName().Version;
                // Set the form's title to include the version number
                this.Text = $"FlightRecorder - Version {version}";
            }

            //initialise l'object qui sert à capter les données qui viennent du simu
            _simData = new simData();

            //initialise des variables qui servent à garder un état.
            cbNote.SelectedItem = 8;
            atLeastOneEngineFiring = false;
            _startTime = DateTime.Now;
            _endTime = DateTime.Now;
            _startFuel = 0;
            _endFuel = 0;
            commentaires = string.Empty;
            onGround = true;

            touchDownVSpeed = 0;
            currentVSpeed = 0;

            gearIsUp = false;
            flapsPosition = 0;

            overspeed = false;
            crashed = false;
            overRunwayCrashed = false;
            stallWarning = false;

            modifiedPayload = false;
            //modifiedFuel = false;
            maxFuelCapacity = 0;

            //recupere le callsign qui a été sauvegardé en settings de l'application
            this.tbCallsign.Text = Settings.Default.callsign;
            //desactive le bouton de maj du setting. Il sera reactivé si le callsign est modifié.
            btnSaveSettings.Enabled = false;

            //met à jour l'etat de connection au simu dans la barre de statut
            configureForm();

            //demarre le timer de connection (fait un essai de connexion toutes les 1000ms)
            this.timerConnection.Start();
        }

        //get the fleet, and missions from the google sheet
        private async void loadAirportsFromSheet()
        {
            //load the airports.
            this.aeroports.AddRange(await Aeroport.fetchAirports(BASERURL, DateTime.UnixEpoch));
            //just in case, reload the statc values
            if (aeroports.Count > 0)
            {
                readStaticValues();
            }
            else
            {
                MessageBox.Show("airport database is empty !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private async void loadDataFromSheet()
        {
            string url = BASERURL + "?query=fleet";
            UrlDeserializer dataReader = new UrlDeserializer(url);

            (List<Avion> avions, List<Mission> missions) = await dataReader.FetchDataAsync();

            this.avions.AddRange(avions);
            this.missions.AddRange(missions);

            if (avions.Count==0)
            {
                MessageBox.Show("planes database is empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (missions.Count == 0)
            {
                MessageBox.Show("No mission available !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            remplirComboImmat();
            remplirComboMissions();
            this.Cursor = Cursors.Default;
        }

        private async Task<float> GetFretOnAirport(string airportIdent)
        {
            string url = BASERURL + "?query=freight&airport=" + airportIdent;
            float fret = await Aeroport.fetchFreight(BASERURL, airportIdent);
            if (fret > 0)
            {
                lbFret.Text = "Available fret: " + fret.ToString();
            }
            else
            {
                lbFret.Text = "No fret here";
            }
            return fret;
        }


        private async void readStaticValues()
        {
            if ((null != _simData) && (_simData.isConnected))
            {
                //commence à lire qq variables du simu : fuel & cargo, immat avion...
                FuelQtty = _simData.getFuelWeight();
                maxFuelCapacity = _simData.getMaxFuel();

                this.tbCurrentFuel.Text = FuelQtty.ToString("0.00");
                this.tbCargo.Text = _simData.getPayloadWheight().ToString("0.00");

                //recupere l'emplacement courant :
                _currentPosition = _simData.getPosition(); ;

                double lat = _currentPosition.Location.Latitude.DecimalDegrees;
                double lon = _currentPosition.Location.Longitude.DecimalDegrees;

                if ((aeroports != null) && (aeroports.Count > 0))
                {
                    Aeroport? localAirport = Aeroport.FindClosestAirport(aeroports, lat, lon);
                    if (localAirport != null)
                    {
                        string startAirportname = localAirport.name;
                        tbCurrentPosition.Text = startAirportname;
                        tbCurrentIata.Text = localAirport.Ident;

                        //Ca ne marche pas. Airport est null. 
                        // Je confonds airports et Aeroport
                        // Utilisez les avions et les aéroports ici
                        if (this.aeroports != null)
                        {
                            // Votre code pour utiliser les avions et les aéroports
                            float fretOnLFMT = await GetFretOnAirport(tbCurrentIata.Text);
                            lbFret.Text = "Il y a " + fretOnLFMT.ToString() + " Kg de frêt disponible sur cet aéroport";
                        }
                    }
                }
                //recupere le type d'avion donné par le simu.
                this.tbDesignationAvion.Text = _simData.getAircraftType();
            }
        }

        // appelé chaque 1s par le timer de connection
        private void timerConnection_Tick(object sender, EventArgs e)
        {
            // Try to open the connection
            try
            {
                //essaie d'ouvrir la connection. Si ça échoue, une exception sera envoyée
                _simData.openConnection();

                //si on arrive ici, la connection est bien ouverte, arrete le timer de connection.
                this.timerConnection.Stop();

                //read the value that normally don't change (except change of plane, or cargo)
                readStaticValues();

                //demarre le timer principal, qui lit les infos du simu 2x par 1s.
                this.timerMain.Start();

                // met à jour le status de connection dans la barre de statut.
                configureForm();
            }
            catch
            {
                // No connection found. Don't need to do anything, just keep trying
            }
        }

        // This method runs 2 times per second (every 500ms). This is set on the timerMain properties.
        private async void timerMain_Tick(object sender, EventArgs e)
        {
            try
            {
                if (startDisabled > 0)
                {
                    startDisabled -= 1;

                    if (startDisabled <= 0)
                    {
                        //the start detection disable timer expired, restore the start textboxes.
                        tbStartFuel.Enabled = true;
                        tbStartPosition.Enabled = true;
                        tbStartTime.Enabled = true;
                        tbStartIata.Enabled = true;
                    }
                }

                //rafraichis les données venant du simu
                _simData.refresh();

                // Airspeed
                double airspeedKnots = _simData.getAirSpeed();
                this.txtAirspeed.Text = airspeedKnots.ToString("F0");

                currentVSpeed = _simData.getVerticalSpeed();
                tbVSpeed.Text = currentVSpeed.ToString("0.00");
                // Update the information on the form
                //check if we are in the air
                if (_simData.getOnground() == 0)
                {
                    if (onGround)
                    {
                        //we just took off ! read the plane weight
                        takeOffWeight = _simData.getPlaneWeight();
                    }
                    //keep memory that we're airborn
                    onGround = false;
                }
                else //we're on ground !
                {
                    if (!onGround)
                    {
                        //only update the touchDownVSpeed if we've been airborn once
                        touchDownVSpeed = _simData.getLandingVerticalSpeed();
                        landingWeight = _simData.getPlaneWeight();
                    }
                }

                //check gear position, if gear just deployed, get the airspeed
                bool currentGearIsUp = gearIsUp;
                gearIsUp = _simData.getIsGearUp();
                if (!gearIsUp && currentGearIsUp)
                {
                    //get the max air speed while deploying the gears
                    if (airspeedKnots > gearDownSpeed)
                    {
                        //gear just went to be deployed ! check the current speed !!!
                        gearDownSpeed = airspeedKnots;
                    }
                }

                //check the flaps deployment speed
                uint currentFlapsPosition = flapsPosition;
                flapsPosition = _simData.getFlapsPosition();
                //if flaps just went deployed, get the air speed.
                if ((currentFlapsPosition == 0) && (flapsPosition > 0))
                {
                    //only keep the max flaps deployment air speed for this flight
                    if (airspeedKnots > flapsDownSpeed)
                    {
                        flapsDownSpeed = airspeedKnots;
                    }
                }


                if (_simData.getOverspeedWarning() != 0)
                {
                    overspeed = true;
                }
                if (_simData.getOffRunwayCrashed() != 0)
                {
                    overRunwayCrashed = true;
                }
                if (_simData.getCrashedFlag() != 0)
                {
                    crashed = true;
                }
                if (_simData.getStallWarning() != 0)
                {
                    stallWarning = true;
                }

                //affiche en live le niveau de barburant
                //0.00 => only keep 2 decimals for the fuel
                if (!refillTimer.Enabled)
                {
                    tbCurrentFuel.Text = _simData.getFuelWeight().ToString("0.00");
                }
                //tbCargo.Text = _simData.getPayloadWheight().ToString("0.00");

                //on va verifier l'etat des moteurs :

                //sauvegarde l'etat precedent des moteurs
                bool _previousEngineStatus = atLeastOneEngineFiring;
                //lit le nouvel etat.
                atLeastOneEngineFiring = _simData.isAtLeastOneEngineFiring();

                //si aucun moteur de tournait, mais que maintenant, au moins un moteur tourne, on commence a enregistrer.
                //on va memoriser les etats de carburant, et l'heure. On récupere aussi quel est l'aeroport.
                if ((!_previousEngineStatus && atLeastOneEngineFiring) && (startDisabled == 0))
                {
                    _startPosition = _simData.getPosition(); ;

                    double lat = _startPosition.Location.Latitude.DecimalDegrees;
                    double lon = _startPosition.Location.Longitude.DecimalDegrees;

                    Aeroport? localAirport = Aeroport.FindClosestAirport(aeroports, lat, lon);
                    if (localAirport != null)
                    {
                        string startAirportname = localAirport.name;
                        tbStartPosition.Text = startAirportname;
                        tbStartIata.Text = localAirport.Ident;
                    }

                    _startFuel = _simData.getFuelWeight();
                    _startTime = DateTime.Now;
                    this.tbStartTime.Text = _startTime.ToShortTimeString();
                    //0.00 => only keep 2 decimals for the fuel
                    this.tbStartFuel.Text = _startFuel.ToString("0.00");

                    //fix payload, remove the pilot wheight;
                    //considere que le pilote fait 80Kg;
                    float fpayload = float.Parse(tbCargo.Text) - 80;

                    //recupere le fret qui etait dispo au depart;
                    float startFret = await Aeroport.fetchFreight(BASERURL, tbStartIata.Text);
                    if (fpayload > startFret)
                    {
                        fpayload = startFret + 80;
                        tbCargo.Text = fpayload.ToString();
                        _simData.setPayload(fpayload);
                        lbFret.Text = "Cargo payload maxed to " + fpayload.ToString() + " Kg";
                        Invalidate();
                    }
                }

                //Si au moins un moteur tournait, mais que plus aucun moteur ne tourne, c'est la fin du vol.
                if (_previousEngineStatus && !atLeastOneEngineFiring)
                {
                    // disable start detection for 300 x 100 ms =30s  disable the start text boxes.
                    startDisabled = 300;
                    tbStartFuel.Enabled = false;
                    tbStartPosition.Enabled = false;
                    tbStartTime.Enabled = false;
                    tbStartIata.Enabled = false;

                    //on recupere les etats de fin de vol : heure, carbu, position.
                    _endPosition = _simData.getPosition();
                    double lat = _endPosition.Location.Latitude.DecimalDegrees;
                    double lon = _endPosition.Location.Longitude.DecimalDegrees;

                    Aeroport? localAirport = Aeroport.FindClosestAirport(aeroports, lat, lon);
                    if (localAirport != null)
                    {
                        string endAirportname = localAirport.name;
                        tbEndPosition.Text = endAirportname;
                        tbEndIata.Text = localAirport.Ident;
                    }

                    _endFuel = _simData.getFuelWeight(); ;
                    _endTime = DateTime.Now;
                    this.tbEndTime.Text = _endTime.ToShortTimeString();
                    //0.00 => only keep 2 decimals for the fuel
                    this.tbEndFuel.Text = _endFuel.ToString("0.00");

                    //compute the note of the flight
                    analyseFlight();

                    //enable the save button
                    btnSubmit.Enabled = true;

                }

            }
            catch (Exception ex)
            {
                // An error occured. Tell the user and stop this timer.
                this.timerMain.Stop();
                MessageBox.Show("Communication with FSUIPC Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Update the connection status
                configureForm();
                // start the connection timer
                this.timerConnection.Start();
            }
        }

        // Configures the status label depending on if we're connected or not 
        private void configureForm()
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
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //arrete les timers.
            this.timerConnection.Stop();
            this.timerMain.Stop();
            //ferme la connection vers le simu
            FSUIPCConnection.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //si l'utilisateur a modifié le texte du callsign, active le bouton pour le sauvrgarder
            btnSaveSettings.Enabled = true;

        }

        //sauvegarde du callsign comme setting de l'application
        private void btnSaveSettings_Click(object sender, EventArgs e)
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

        private bool checkBeforeSave()
        {
            if (tbCallsign.Text== string.Empty) {
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

        //envoi des données au google form
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                checkBeforeSave();

                //crée un dictionnaire des valeurs à envoyer
                Dictionary<string, string> values = new Dictionary<string, string>();
                UrlDeserializer.SaveFlightQuery data = new UrlDeserializer.SaveFlightQuery
                {
                    query = "save",
                    qtype = "json",
                    cs = tbCallsign.Text,
                    plane = cbImmat.Text,
                    sicao = tbStartIata.Text,
                    sfuel = tbStartFuel.Text,
                    stime = tbStartTime.Text,
                    eicao = tbEndIata.Text,
                    efuel = tbEndFuel.Text,
                    etime = tbEndTime.Text,
                    note = cbNote.Text,
                    mission = cbMission.Text,
                    comment = tbCommentaires.Text,
                    cargo = tbCargo.Text
                };
                UrlDeserializer urlDeserializer = new UrlDeserializer(BASERURL);
                int result = await urlDeserializer.PushFlightAsync(data);
                if (0 != result)
                {
                    //si tout va bien...
                    this.lblConnectionStatus.Text = "Flight data saved";
                    this.lblConnectionStatus.ForeColor = Color.Green;
                }
                else
                {
                    //en, cas d'erreur, affiche une popup avec le message
                    MessageBox.Show("Error while sending flight data.");
                }
                btnSubmit.Enabled = false;
            }
            catch (Exception ex)
            {
                //in case if check error, or exception durong save, show a messagebox containing the error message
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void remplirComboImmat()
        {
            lbFret.Text = "Acars initializing ..... please wait";
            // Effacez les éléments existants dans la combobox
            cbImmat.Items.Clear();

            // Parcourez la liste des avions
            foreach (var avion in avions)
            {
                // Vérifiez si le statut de l'avion est égal à 1
                if (avion.Status == 1 || avion.Status == 2)
                {
                    // Si le statut est égal à 1, passez à l'itération suivante
                    continue;
                }
                // Ajoutez l'immatriculation de l'avion à la combobox
                if (null != avion.Immat)
                {
                    cbImmat.Items.Add(avion.Immat);
                }
            }

            //await dataReader.FillComboBoxImmatAsync(cbImmat);
            cbImmat.DisplayMember = "Immat";
            this.Cursor = Cursors.Default;
        }

        private void remplirComboMissions()
        {
            if (missions != null)
            {
                cbMission.Items.AddRange(missions.Select(mission => mission.Libelle).Where(mission => !string.IsNullOrEmpty(mission)).ToArray());
            }
            //await dataReader.FillComboBoxMissionsAsync(cbMission);
            cbMission.DisplayMember = "Libelle";
            this.Cursor = Cursors.Default;
        }

        private void tbEndPosition_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _simData.refresh();
            if (modifiedPayload)
            {
                try
                {
                    double newPayload = double.Parse(tbCargo.Text);
                    _simData.setPayload(newPayload);
                    this.lblConnectionStatus.Text = "New payload send to simulator";
                    this.lblConnectionStatus.ForeColor = Color.Green;
                }
                catch (Exception)
                {
                    //do nothing
                }
            }
            //update the static values
            readStaticValues();

            modifiedPayload = false;
            btnRefresh.Enabled = false;
        }

        private void tbImmat_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Set plane immat.";
            string? tip = toolTip1.GetToolTip(this);
            toolTip1.Show(tip, this, 5000);
        }

        private int analyseFlight()
        {
            int note = 10;
            tbCommentaires.Text = "VSpeed @touchdown : " + touchDownVSpeed.ToString("0.00") + " fpm ";
            tbCommentaires.Text += " Takeoff weight : " + takeOffWeight.ToString("0.00") + " Kg ";
            tbCommentaires.Text += " Landing weight : " + landingWeight.ToString("0.00") + " Kg ";

            if (_simData.getFlapsAvailableFlag() == 1)
            {
                if (flapsDownSpeed > 130)
                {
                    note -= 1; // pareil que note = note -1
                }
            }

            if (_simData.getGearRetractableFlag() == 1)
            {
                if (gearDownSpeed > 130)
                {
                    note -= 1;
                }
            }

            if (touchDownVSpeed > 500)
            {
                note -= 2;
            }

            if (overspeed) note -= 2; // note = note -2
            if (stallWarning) note -= 2;
            if (overRunwayCrashed) note = 2;
            if (crashed) note = 0;

            cbNote.Text = note.ToString();

            return note;
        }
        private void cbNote_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Flight details";
            string tipText = "";

            if (overspeed) tipText += "Overspeed detected \n";
            if (stallWarning) tipText += "Stall warning detected \n";
            if (overRunwayCrashed) tipText += "Over runway crashed \n";
            if (crashed) tipText += "Crashed \n";
            tipText += "vertical speed at touchdown: " + touchDownVSpeed + " fpm";
            if (_simData.getGearRetractableFlag() == 1)
            {
                tipText += "gear down speed : " + gearDownSpeed + " m/s";
            }
            if (_simData.getFlapsAvailableFlag() == 1)
            {
                tipText += "flaps down speed : " + flapsDownSpeed + " m/s";
            }

            toolTip1.SetToolTip((Control)sender, tipText);

            toolTip1.Show(tipText, this, 5000);
        }

        private void cbNote_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbCargo_TextChanged(object sender, EventArgs e)
        {
            modifiedPayload = true;
            btnRefresh.Enabled = true;
        }

        private void tbCurrentFuel_TextChanged(object sender, EventArgs e)
        {
            //modifiedFuel = true;
            btnRefresh.Enabled = true;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (_simData.isConnected)
            {
                readStaticValues();
            }

        }

        private void refillTimer_Tick(object sender, EventArgs e)
        {
            if (FuelQtty < maxFuelCapacity)
            {
                FuelQtty++;
                refillQtty++;
                //accelerate after a few seconds
                if ((refillQtty > 5) && (refillTimer.Interval == 500))
                {
                    refillTimer.Interval = 100;
                }
                //check for overfill
                if (FuelQtty >= maxFuelCapacity)
                {
                    FuelQtty = maxFuelCapacity;
                    refillTimer.Stop();
                    _simData.setFuelWheight(FuelQtty);
                }

                tbCurrentFuel.Text = FuelQtty.ToString("0.00");
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((!refillTimer.Enabled) && (FuelQtty < maxFuelCapacity))
            {
                refillTimer.Interval = 500;
                refillQtty = 0;
                refillTimer.Enabled = true;
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            refillTimer.Stop();
            _simData.setFuelWheight(FuelQtty);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirm flight reset ?", "Confirm", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {

                tbStartIata.Text = string.Empty;
                tbStartFuel.Text = string.Empty;
                tbStartPosition.Text = string.Empty;
                tbStartTime.Text = string.Empty;

                tbEndTime.Text = string.Empty;
                tbEndFuel.Text = string.Empty;
                tbEndIata.Text = string.Empty;
                tbEndPosition.Text = string.Empty;

                tbCommentaires.Text = string.Empty;
                //reenable start detection at next timer tick
                startDisabled = 1;
				
                btnSubmit.Enabled = false;
            }
        }

        private void cbMission_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
