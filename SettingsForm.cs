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

namespace FlightRecorder
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tbCallsign.Text = Settings.Default.callsign_entry;
            tbImmat.Text = Settings.Default.aircraft_entry;
            tbPassengers.Text = Settings.Default.pax_entry;
            tbCargo.Text = Settings.Default.cargo_entry;
            tbDepICAO.Text = Settings.Default.startIata_entry;
            tbDepFuel.Text = Settings.Default.startFuel_entry;
            tbDepTime.Text = Settings.Default.startTime_entry;
            tbArrICAO.Text = Settings.Default.endIata_entry;
            tbArrFuel.Text = Settings.Default.endFuel_entry;
            tbArrTime.Text = Settings.Default.endTime_entry;
            tbGoogleForm.Text = Settings.Default.GoogleFormUrl;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.callsign_entry = tbCallsign.Text;
            Settings.Default.aircraft_entry = tbImmat.Text;
            Settings.Default.pax_entry = tbPassengers.Text;
            Settings.Default.cargo_entry = tbCargo.Text;
            Settings.Default.startIata_entry = tbDepICAO.Text;
            Settings.Default.startFuel_entry = tbDepFuel.Text;
            Settings.Default.startTime_entry = tbDepTime.Text;
            Settings.Default.endIata_entry = tbArrICAO.Text;
            Settings.Default.endFuel_entry = tbArrFuel.Text;
            Settings.Default.endTime_entry = tbArrTime.Text;
            Settings.Default.GoogleFormUrl = tbGoogleForm.Text;

            Settings.Default.Save();
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
                    if (sParam[1] == "Passengers")
                    {
                        tbPassengers.Text = sParam[0];
                    }
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
                }
            }

            string gFormBaseUrl = major_items[0].Substring(0, major_items[0].LastIndexOf('/'));
            tbGoogleForm.Text = gFormBaseUrl;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
