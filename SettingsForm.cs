using FlightRecorder.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FlightRecorder
{
    public partial class SettingsForm : Form
    {
        private SettingsMgr settingsMgr;
        public SettingsForm()
        {
            settingsMgr = new SettingsMgr("settings.json");
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if ((settingsMgr != null)&&(null != settingsMgr.allSettings))
            {
                tbCallsign.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.CALLSIGNENTRY);
                tbImmat.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.AIRCRAFTENTRY);
                //tbPassengers.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.PAXENTRY);
                tbCargo.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.CARGOENTRY);
                
                tbDepICAO.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.STARTIATAENTRY);
                tbDepFuel.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.STARTFUELENTRY);
                tbDepTime.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.STARTTIMEENTRY);
                
                tbArrICAO.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.ENDIATAENTRY);
                tbArrFuel.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.ENDFUELENTRY);
                tbArrTime.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.ENDTIMEENTRY);

                tbFlightNote.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.FLIGHTNOTEENTRY);
                tbComment.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.COMMENTENTRY);
                
                tbGoogleForm.Text = settingsMgr.allSettings.gformSettings.getValue(SettingsMgr.GFORMURL);


                refreshFleetLists();
            }
            else
            {
                //what to do if not settings found ?
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (settingsMgr.allSettings != null)
            {
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.CALLSIGNENTRY, tbCallsign.Text);
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.AIRCRAFTENTRY, tbImmat.Text);
                //settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.PAXENTRY, tbPassengers.Text);
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.CARGOENTRY, tbCargo.Text);
                
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.STARTIATAENTRY, tbDepICAO.Text);
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.STARTFUELENTRY, tbDepFuel.Text);
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.STARTTIMEENTRY, tbDepTime.Text);
                
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.ENDIATAENTRY, tbArrICAO.Text);
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.ENDFUELENTRY, tbArrFuel.Text);
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.ENDTIMEENTRY, tbArrTime.Text);

                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.FLIGHTNOTEENTRY, tbArrTime.Text);
                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.COMMENTENTRY, tbArrTime.Text);

                settingsMgr.allSettings.gformSettings.setValue(SettingsMgr.GFORMURL, tbGoogleForm.Text);

                settingsMgr.SaveSettings();
            }
            this.Close();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string url = tbFullUrl.Text;
            // https://docs.google.com/forms/d/e/1FAIpQLSeUruKbF7P3Es2b5JC8RIZaDhK5In1nwn_mq_RhsGV5MXU9AQ/viewform?usp=pp_url&entry.875291795=callSign&entry.354262163=lfmt&entry.1974689794=300&entry.1603698953=22:22&entry.864236608=LFMT&entry.789000913=200&entry.1547789562=23:23&entry.941405603=0&entry.704113444=300

            //https://docs.google.com/forms/d/e/1FAIpQLSeUruKbF7P3Es2b5JC8RIZaDhK5In1nwn_mq_RhsGV5MXU9AQ/viewform?usp=pp_url&entry.875291795=Callsign&entry.793899725=Aircraft_immat&entry.941405603=Passengers&entry.704113444=Cargo&entry.354262163=Departure_ICAO&entry.1974689794=Departure_Fuel&entry.1603698953=Departure_Time&entry.864236608=Arrival_ICAO&entry.789000913=Arrival_Fuel&entry.1547789562=Arrival_Time

            string[] major_items = url.Split('?');
            string[] minor_items = major_items[1].Split("&");
            foreach (string item in minor_items)
            {
                string[] sParam = item.Split('=');
                if (sParam[0].StartsWith("entry."))
                {
                    if (sParam[1] == "callsign")
                    {
                        tbCallsign.Text = sParam[0];
                    }
                    if (sParam[1] == "Aircraft_immat")
                    {
                        tbImmat.Text = sParam[0];
                    }
                    //if (sParam[1] == "Passengers")
                    //{
                    //    tbPassengers.Text = sParam[0];
                    //}
                    if (sParam[1] == "Cargo")
                    {
                        tbCargo.Text = sParam[0];
                    }
                    if (sParam[1] == "Departure_ICAO")
                    {
                        tbDepICAO.Text = sParam[0];
                    }
                    if (sParam[1] == "Departure_Fuel")
                    {
                        tbDepFuel.Text = sParam[0];
                    }
                    if (sParam[1] == "Departure_Time")
                    {
                        tbDepTime.Text = sParam[0];
                    }
                    if (sParam[1] == "Arrival_ICAO")
                    {
                        tbArrICAO.Text = sParam[0];
                    }
                    if (sParam[1] == "Arrival_Fuel")
                    {
                        tbArrFuel.Text = sParam[0];
                    }
                    if (sParam[1] == "Arrival_Time")
                    {
                        tbArrTime.Text = sParam[0];
                    }
                    if (sParam[1] == "Flight_Note")
                    {
                        tbFlightNote.Text = sParam[0];
                    }
                    if (sParam[1] == "Comment")
                    {
                        tbComment.Text = sParam[0];
                    }
                    if (sParam[1] == "Mission")
                    {
                        tbMission.Text = sParam[0];
                    }
                }
            }
            string gFormBaseUrl = major_items[0].Substring(0, major_items[0].LastIndexOf('/'));
            tbGoogleForm.Text = gFormBaseUrl;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cbAircrafts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbImmats.Items.Clear();
            tbNewImmat.ResetText();

            string model = cbAircrafts.Text;
            if (settingsMgr.allSettings != null)
            {
                foreach (string immat in settingsMgr.allSettings.fleet.Immats[model])
                {
                    lbImmats.Items.Add(immat);
                }
            }

        }

        private void cbAircrafts_TextChanged(object sender, EventArgs e)
        {
            btnAddAircraft.Enabled = true;
        }

        private void refreshFleetLists()
        {
            int index = cbAircrafts.SelectedIndex;
            cbAircrafts.Items.Clear();
            cbAircrafts.ResetText();
            lbImmats.Items.Clear();
            //refill the aircraft list
            if (settingsMgr.allSettings != null)
            {
                foreach (string model in settingsMgr.allSettings.fleet.AircraftModels)
                {
                    cbAircrafts.Items.Add(model);
                }
                //restore selected airplane model
                cbAircrafts.SelectedIndex = index;
            }
        }

        private void btnAddAircraft_Click(object sender, EventArgs e)
        {
            if (settingsMgr.allSettings != null)
            {
                settingsMgr.allSettings.fleet.addAircraftModel(cbAircrafts.Text);
                refreshFleetLists();
                btnAddAircraft.Enabled = false;
            }
        }

        private void btnAddImmat_Click(object sender, EventArgs e)
        {
            if (null != settingsMgr.allSettings)
            {
                string model = cbAircrafts.Text;
                settingsMgr.allSettings.fleet.addImmat(cbAircrafts.Text, tbNewImmat.Text);
                refreshFleetLists();
                btnAddImmat.Enabled = false;
            }
        }

        private void tbNewImmat_TextChanged(object sender, EventArgs e)
        {
            btnAddImmat.Enabled = true;
        }
    }
}
