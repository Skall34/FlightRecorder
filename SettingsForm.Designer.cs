namespace FlightRecorder
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            label1 = new Label();
            tbFullUrl = new TextBox();
            Callsign = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            tbCallsign = new TextBox();
            tbImmat = new TextBox();
            tbCargo = new TextBox();
            tbDepICAO = new TextBox();
            tbDepFuel = new TextBox();
            tbDepTime = new TextBox();
            tbArrICAO = new TextBox();
            tbArrFuel = new TextBox();
            tbArrTime = new TextBox();
            btnParse = new Button();
            btnSave = new Button();
            tbGoogleForm = new TextBox();
            label12 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tbComment = new TextBox();
            tbFlightNote = new TextBox();
            label17 = new Label();
            label16 = new Label();
            tabPage2 = new TabPage();
            lbImmats = new ListBox();
            label15 = new Label();
            tbNewImmat = new TextBox();
            btnAddImmat = new Button();
            btnAddAircraft = new Button();
            label14 = new Label();
            cbAircrafts = new ComboBox();
            label13 = new Label();
            tbMission = new TextBox();
            label11 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 259);
            label1.Name = "label1";
            label1.Size = new Size(194, 15);
            label1.TabIndex = 0;
            label1.Text = "Past here the url with default values";
            label1.Click += label1_Click;
            // 
            // tbFullUrl
            // 
            tbFullUrl.Location = new Point(12, 277);
            tbFullUrl.Name = "tbFullUrl";
            tbFullUrl.Size = new Size(690, 23);
            tbFullUrl.TabIndex = 1;
            // 
            // Callsign
            // 
            Callsign.AutoSize = true;
            Callsign.Location = new Point(12, 33);
            Callsign.Name = "Callsign";
            Callsign.Size = new Size(49, 15);
            Callsign.TabIndex = 2;
            Callsign.Text = "Callsign";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(619, 15);
            label2.TabIndex = 3;
            label2.Text = "Google form entry fields : copy these field names as default answers of your google form and  past here the link here";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 87);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Cargo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 59);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 5;
            label4.Text = "Aircraft_immat";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(410, 33);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 6;
            label5.Text = "Departure_ICAO";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(410, 59);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 7;
            label6.Text = "Departure_Fuel";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(410, 85);
            label7.Name = "label7";
            label7.Size = new Size(90, 15);
            label7.TabIndex = 8;
            label7.Text = "Departure_Time";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(410, 111);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 9;
            label8.Text = "Arrival_ICAO";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(410, 137);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 10;
            label9.Text = "Arrival_Fuel";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(410, 163);
            label10.Name = "label10";
            label10.Size = new Size(72, 15);
            label10.TabIndex = 11;
            label10.Text = "Arrival_Time";
            // 
            // tbCallsign
            // 
            tbCallsign.Location = new Point(204, 30);
            tbCallsign.Name = "tbCallsign";
            tbCallsign.Size = new Size(100, 23);
            tbCallsign.TabIndex = 13;
            // 
            // tbImmat
            // 
            tbImmat.Location = new Point(204, 56);
            tbImmat.Name = "tbImmat";
            tbImmat.Size = new Size(100, 23);
            tbImmat.TabIndex = 14;
            // 
            // tbCargo
            // 
            tbCargo.Location = new Point(204, 84);
            tbCargo.Name = "tbCargo";
            tbCargo.Size = new Size(100, 23);
            tbCargo.TabIndex = 16;
            // 
            // tbDepICAO
            // 
            tbDepICAO.Location = new Point(602, 30);
            tbDepICAO.Name = "tbDepICAO";
            tbDepICAO.Size = new Size(100, 23);
            tbDepICAO.TabIndex = 17;
            // 
            // tbDepFuel
            // 
            tbDepFuel.Location = new Point(602, 56);
            tbDepFuel.Name = "tbDepFuel";
            tbDepFuel.Size = new Size(100, 23);
            tbDepFuel.TabIndex = 18;
            // 
            // tbDepTime
            // 
            tbDepTime.Location = new Point(602, 82);
            tbDepTime.Name = "tbDepTime";
            tbDepTime.Size = new Size(100, 23);
            tbDepTime.TabIndex = 19;
            // 
            // tbArrICAO
            // 
            tbArrICAO.Location = new Point(602, 108);
            tbArrICAO.Name = "tbArrICAO";
            tbArrICAO.Size = new Size(100, 23);
            tbArrICAO.TabIndex = 20;
            // 
            // tbArrFuel
            // 
            tbArrFuel.Location = new Point(602, 134);
            tbArrFuel.Name = "tbArrFuel";
            tbArrFuel.Size = new Size(100, 23);
            tbArrFuel.TabIndex = 21;
            // 
            // tbArrTime
            // 
            tbArrTime.Location = new Point(602, 160);
            tbArrTime.Name = "tbArrTime";
            tbArrTime.Size = new Size(100, 23);
            tbArrTime.TabIndex = 22;
            // 
            // btnParse
            // 
            btnParse.Location = new Point(708, 277);
            btnParse.Name = "btnParse";
            btnParse.Size = new Size(75, 23);
            btnParse.TabIndex = 23;
            btnParse.Text = "Parse";
            btnParse.UseVisualStyleBackColor = true;
            btnParse.Click += btnParse_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(671, 351);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(139, 45);
            btnSave.TabIndex = 24;
            btnSave.Text = "Save settings";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tbGoogleForm
            // 
            tbGoogleForm.Location = new Point(204, 216);
            tbGoogleForm.Name = "tbGoogleForm";
            tbGoogleForm.Size = new Size(498, 23);
            tbGoogleForm.TabIndex = 25;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 219);
            label12.Name = "label12";
            label12.Size = new Size(98, 15);
            label12.TabIndex = 26;
            label12.Text = "Google form URL";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(799, 337);
            tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tbMission);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(tbComment);
            tabPage1.Controls.Add(tbFlightNote);
            tabPage1.Controls.Add(label17);
            tabPage1.Controls.Add(label16);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(tbGoogleForm);
            tabPage1.Controls.Add(tbFullUrl);
            tabPage1.Controls.Add(Callsign);
            tabPage1.Controls.Add(btnParse);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(tbArrTime);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(tbArrFuel);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(tbArrICAO);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(tbDepTime);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(tbDepFuel);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(tbDepICAO);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(tbCargo);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(tbImmat);
            tabPage1.Controls.Add(tbCallsign);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(791, 309);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "GForm";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbComment
            // 
            tbComment.Location = new Point(204, 141);
            tbComment.Name = "tbComment";
            tbComment.Size = new Size(100, 23);
            tbComment.TabIndex = 30;
            // 
            // tbFlightNote
            // 
            tbFlightNote.Location = new Point(204, 112);
            tbFlightNote.Name = "tbFlightNote";
            tbFlightNote.Size = new Size(100, 23);
            tbFlightNote.TabIndex = 29;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(12, 144);
            label17.Name = "label17";
            label17.Size = new Size(61, 15);
            label17.TabIndex = 28;
            label17.Text = "Comment";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(12, 118);
            label16.Name = "label16";
            label16.Size = new Size(68, 15);
            label16.TabIndex = 27;
            label16.Text = "Flight_Note";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lbImmats);
            tabPage2.Controls.Add(label15);
            tabPage2.Controls.Add(tbNewImmat);
            tabPage2.Controls.Add(btnAddImmat);
            tabPage2.Controls.Add(btnAddAircraft);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(cbAircrafts);
            tabPage2.Controls.Add(label13);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(791, 309);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Fleet";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // lbImmats
            // 
            lbImmats.FormattingEnabled = true;
            lbImmats.ItemHeight = 15;
            lbImmats.Location = new Point(176, 42);
            lbImmats.Name = "lbImmats";
            lbImmats.Size = new Size(100, 94);
            lbImmats.TabIndex = 8;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(15, 146);
            label15.Name = "label15";
            label15.Size = new Size(119, 15);
            label15.TabIndex = 7;
            label15.Text = "New immatriculation";
            // 
            // tbNewImmat
            // 
            tbNewImmat.Location = new Point(176, 142);
            tbNewImmat.Name = "tbNewImmat";
            tbNewImmat.Size = new Size(100, 23);
            tbNewImmat.TabIndex = 6;
            tbNewImmat.TextChanged += tbNewImmat_TextChanged;
            // 
            // btnAddImmat
            // 
            btnAddImmat.Enabled = false;
            btnAddImmat.Location = new Point(282, 142);
            btnAddImmat.Name = "btnAddImmat";
            btnAddImmat.Size = new Size(75, 23);
            btnAddImmat.TabIndex = 5;
            btnAddImmat.Text = "Add";
            btnAddImmat.UseVisualStyleBackColor = true;
            btnAddImmat.Click += btnAddImmat_Click;
            // 
            // btnAddAircraft
            // 
            btnAddAircraft.Enabled = false;
            btnAddAircraft.Location = new Point(429, 13);
            btnAddAircraft.Name = "btnAddAircraft";
            btnAddAircraft.Size = new Size(75, 23);
            btnAddAircraft.TabIndex = 4;
            btnAddAircraft.Text = "Add";
            btnAddAircraft.UseVisualStyleBackColor = true;
            btnAddAircraft.Click += btnAddAircraft_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(15, 39);
            label14.Name = "label14";
            label14.Size = new Size(155, 15);
            label14.TabIndex = 3;
            label14.Text = "Registered immatriculations";
            // 
            // cbAircrafts
            // 
            cbAircrafts.FormattingEnabled = true;
            cbAircrafts.Location = new Point(72, 13);
            cbAircrafts.Name = "cbAircrafts";
            cbAircrafts.Size = new Size(351, 23);
            cbAircrafts.TabIndex = 1;
            cbAircrafts.SelectedIndexChanged += cbAircrafts_SelectedIndexChanged;
            cbAircrafts.TextChanged += cbAircrafts_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(15, 16);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 0;
            label13.Text = "Aircrafts";
            // 
            // tbMission
            // 
            tbMission.Location = new Point(204, 174);
            tbMission.Name = "tbMission";
            tbMission.Size = new Size(100, 23);
            tbMission.TabIndex = 32;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 177);
            label11.Name = "label11";
            label11.Size = new Size(48, 15);
            label11.TabIndex = 31;
            label11.Text = "Mission";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 406);
            Controls.Add(tabControl1);
            Controls.Add(btnSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox tbFullUrl;
        private Label Callsign;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox tbCallsign;
        private TextBox tbImmat;
        private TextBox tbCargo;
        private TextBox tbDepICAO;
        private TextBox tbDepFuel;
        private TextBox tbDepTime;
        private TextBox tbArrICAO;
        private TextBox tbArrFuel;
        private TextBox tbArrTime;
        private Button btnParse;
        private Button btnSave;
        private TextBox tbGoogleForm;
        private Label label12;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnAddImmat;
        private Button btnAddAircraft;
        private Label label14;
        private ComboBox cbAircrafts;
        private Label label13;
        private ListBox lbImmats;
        private Label label15;
        private TextBox tbNewImmat;
        private TextBox tbComment;
        private TextBox tbFlightNote;
        private Label label17;
        private Label label16;
        private TextBox tbMission;
        private Label label11;
    }
}