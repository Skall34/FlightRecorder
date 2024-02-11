using FlightRecorder.Properties;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightRecorder
{
    public partial class Form1 : Form
    {

        //private Offset<short> parkingBrake = new Offset<short>(0x0BC8);
        FsPositionSnapshot _startPosition;
        FsPositionSnapshot _endPosition;

        private bool atLeastOneEngineFiring;
        private double _startFuel;
        private double _endFuel;

        private DateTime _startTime;
        private DateTime _endTime;

        private airportsMgr airportsDatabase;
        private simData _simData;

        public Form1()
        {
            InitializeComponent();

            //charge la bas de données des aéroports
            this.lblConnectionStatus.Text = "Loading Airport database";
            airportsDatabase = new airportsMgr("airports.csv");
            this.lblConnectionStatus.Text = "Airport database loaded";

            //initialise l'object qui sert à capter les données qui viennent du simu
            _simData = new simData();

            //initialise des variables qui servent à garder un état.
            atLeastOneEngineFiring = false;
            _startTime = DateTime.Now;
            _endTime = DateTime.Now;
            _startFuel = 0;
            _endFuel = 0;

            //recupere le callsign qui a été sauvegardé en settings de l'application
            this.tbCallsign.Text = Settings.Default.callsign;
            //desactive le bouton de maj du setting. Il sera reactivé si le callsign est modifié.
            btnSaveSettings.Enabled = false;

            //met à jour l'etat de connection au simu dans la barre de statut
            configureForm();

            //demarre le timer de connection (fait un essai de connexion toutes les 1000ms)
            this.timerConnection.Start();

        }

        private void readStaticValues()
        {
            //commence à lire qq variables du simu : fuel & cargo, immat avion...
            this.tbCurrentFuel.Text = _simData.getFuelWeight().ToString("0.00");
            this.tbCargo.Text = _simData.getPayloadWheight().ToString("0.00");
            this.tbATCFlightNumber.Text = _simData.getAircraftType();
            this.tbCurrentFuel.Text = _simData.getFuelWeight().ToString("0.00");
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
        private void timerMain_Tick(object sender, EventArgs e)
        {
            try
            {
                //rafraichis les données venant du simu
                _simData.refresh();


                // Update the information on the form

                // Airspeed
                double airspeedKnots = _simData.getAirSpeed();
                this.txtAirspeed.Text = airspeedKnots.ToString("F0");

                //affiche en live le niveau de barburant
                //0.00 => only keep 2 decimals for the fuel
                tbCurrentFuel.Text = _simData.getFuelWeight().ToString("0.00");
                //tbCargo.Text = _simData.getPayloadWheight().ToString("0.00");

                //on va verifier l'etat des moteurs :

                //sauvegarde l'etat precedent des moteurs
                bool _previousEngineStatus = atLeastOneEngineFiring;
                //lit le nouvel etat.
                atLeastOneEngineFiring = _simData.isAtLeastOneEngineFiring();

                //si aucun moteur de tournait, mais que maintenant, au moins un moteur tourne, on commence a enregistrer.
                //on va memoriser les etats de carburant, et l'heure. On récupere aussi quel est l'aeroport.
                if (!_previousEngineStatus && atLeastOneEngineFiring)
                {
                    _startPosition = _simData.getPosition(); ;

                    double lat = _startPosition.Location.Latitude.DecimalDegrees;
                    double lon = _startPosition.Location.Longitude.DecimalDegrees;

                    airport localAirport = airportsDatabase.FindClosestAirport(lat, lon);
                    string startAirportname = localAirport.Name;
                    tbStartPosition.Text = startAirportname;
                    tbStartIata.Text = localAirport.Ident;

                    _startFuel = _simData.getFuelWeight();
                    _startTime = DateTime.Now;
                    this.tbStartTime.Text = _startTime.ToShortTimeString();
                    //0.00 => only keep 2 decimals for the fuel
                    this.tbStartFuel.Text = _startFuel.ToString("0.00");
                }

                //Si au moins un moteur tournait, mais que plus aucun moteur ne tourne, c'est la fin du vol.
                if (_previousEngineStatus && !atLeastOneEngineFiring)
                {
                    //on recupere les etats de fin de vol : heure, carbu, position.
                    _endPosition = _simData.getPosition();
                    double lat = _endPosition.Location.Latitude.DecimalDegrees;
                    double lon = _endPosition.Location.Longitude.DecimalDegrees;

                    airport localAirport = airportsDatabase.FindClosestAirport(lat, lon);
                    string endAirportname = localAirport.Name;
                    tbEndPosition.Text = endAirportname;
                    tbEndIata.Text = localAirport.Ident;

                    _endFuel = _simData.getFuelWeight(); ;
                    _endTime = DateTime.Now;
                    this.tbEndTime.Text = _endTime.ToShortTimeString();
                    //0.00 => only keep 2 decimals for the fuel
                    this.tbEndFuel.Text = _endFuel.ToString("0.00");
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


        //envoi des données au google form
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            //crée un dictionnaire des valeurs à envoyer
            Dictionary<string, string> values = new Dictionary<string, string>();

            GoogleFormsSubmissionService gform = new GoogleFormsSubmissionService(Settings.Default.GoogleFormUrl + "/formResponse");
            //https://docs.google.com/forms/d/e/1FAIpQLSeUruKbF7P3Es2b5JC8RIZaDhK5In1nwn_mq_RhsGV5MXU9AQ/viewform?usp=pp_url&entry.875291795=callSign&entry.354262163=lfmt&entry.1974689794=300&entry.1603698953=22:22&entry.864236608=LFMT&entry.789000913=200&entry.1547789562=23:23&entry.941405603=0&entry.704113444=300
            //https://docs.google.com/forms/d/e/1FAIpQLSeUruKbF7P3Es2b5JC8RIZaDhK5In1nwn_mq_RhsGV5MXU9AQ/viewform?usp=pp_url&entry.793899725=immat
            //https://docs.google.com/forms/d/e/1FAIpQLSeUruKbF7P3Es2b5JC8RIZaDhK5In1nwn_mq_RhsGV5MXU9AQ/viewform?usp=pp_url&entry.793899725=immat

            //rempli le dictionnaire avec les valeurs. La clé et la reference de la donnée dans le google form
            values.Add(Settings.Default.callsign_entry, tbCallsign.Text);
            values.Add(Settings.Default.startIata_entry, tbStartIata.Text);
            values.Add(Settings.Default.startFuel_entry, tbStartFuel.Text);

            values.Add(Settings.Default.startTime_entry, tbStartTime.Text);
            values.Add(Settings.Default.endIata_entry, tbEndIata.Text);
            values.Add(Settings.Default.endFuel_entry, tbEndFuel.Text);

            values.Add(Settings.Default.endTime_entry, tbEndTime.Text);
            values.Add(Settings.Default.pax_entry, "0");
            values.Add(Settings.Default.cargo_entry, tbCargo.Text);
            values.Add(Settings.Default.aircraft_entry, tbATCFlightNumber.Text);

            //attribute les valeurs à l'object gerant la requete.
            gform.SetFieldValues(values);

            //envoie la requete.
            Task<HttpResponseMessage> request = gform.SubmitAsync();
            HttpResponseMessage response = await request;
            if (!response.IsSuccessStatusCode)
            {
                //en, cas d'erreur, affiche une popup avec le message
                MessageBox.Show("Error '" + response.ReasonPhrase + "' while sending flight data.");
            }
            else
            {
                //si tout va bien...
                this.lblConnectionStatus.Text = "Flight data saved";
                this.lblConnectionStatus.ForeColor = Color.Green;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //ouvre le navigateur par defaut sur le lien dans le form.
        private void llManualSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Navigate to a URL.
                System.Diagnostics.Process.Start(new ProcessStartInfo(Settings.Default.GoogleFormUrl + "/viewform") { UseShellExecute = true });

                // Specify that the link was visited.
                this.llManualSave.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbEndPosition_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _simData.refresh();
            //update the static values
            readStaticValues();
        }
    }
}
