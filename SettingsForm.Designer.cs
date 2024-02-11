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
            label11 = new Label();
            tbCallsign = new TextBox();
            tbImmat = new TextBox();
            tbPassengers = new TextBox();
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 346);
            label1.Name = "label1";
            label1.Size = new Size(194, 15);
            label1.TabIndex = 0;
            label1.Text = "Past here the url with default values";
            label1.Click += label1_Click;
            // 
            // tbFullUrl
            // 
            tbFullUrl.Location = new Point(12, 364);
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
            label3.Location = new Point(12, 111);
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
            label5.Location = new Point(12, 137);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 6;
            label5.Text = "Departure_ICAO";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 163);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 7;
            label6.Text = "Departure_Fuel";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 189);
            label7.Name = "label7";
            label7.Size = new Size(90, 15);
            label7.TabIndex = 8;
            label7.Text = "Departure_Time";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 215);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 9;
            label8.Text = "Arrival_ICAO";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 241);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 10;
            label9.Text = "Arrival_Fuel";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 267);
            label10.Name = "label10";
            label10.Size = new Size(72, 15);
            label10.TabIndex = 11;
            label10.Text = "Arrival_Time";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 85);
            label11.Name = "label11";
            label11.Size = new Size(65, 15);
            label11.TabIndex = 12;
            label11.Text = "Passengers";
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
            // tbPassengers
            // 
            tbPassengers.Location = new Point(204, 82);
            tbPassengers.Name = "tbPassengers";
            tbPassengers.Size = new Size(100, 23);
            tbPassengers.TabIndex = 15;
            // 
            // tbCargo
            // 
            tbCargo.Location = new Point(204, 108);
            tbCargo.Name = "tbCargo";
            tbCargo.Size = new Size(100, 23);
            tbCargo.TabIndex = 16;
            // 
            // tbDepICAO
            // 
            tbDepICAO.Location = new Point(204, 134);
            tbDepICAO.Name = "tbDepICAO";
            tbDepICAO.Size = new Size(100, 23);
            tbDepICAO.TabIndex = 17;
            // 
            // tbDepFuel
            // 
            tbDepFuel.Location = new Point(204, 160);
            tbDepFuel.Name = "tbDepFuel";
            tbDepFuel.Size = new Size(100, 23);
            tbDepFuel.TabIndex = 18;
            // 
            // tbDepTime
            // 
            tbDepTime.Location = new Point(204, 186);
            tbDepTime.Name = "tbDepTime";
            tbDepTime.Size = new Size(100, 23);
            tbDepTime.TabIndex = 19;
            // 
            // tbArrICAO
            // 
            tbArrICAO.Location = new Point(204, 212);
            tbArrICAO.Name = "tbArrICAO";
            tbArrICAO.Size = new Size(100, 23);
            tbArrICAO.TabIndex = 20;
            // 
            // tbArrFuel
            // 
            tbArrFuel.Location = new Point(204, 238);
            tbArrFuel.Name = "tbArrFuel";
            tbArrFuel.Size = new Size(100, 23);
            tbArrFuel.TabIndex = 21;
            // 
            // tbArrTime
            // 
            tbArrTime.Location = new Point(204, 264);
            tbArrTime.Name = "tbArrTime";
            tbArrTime.Size = new Size(100, 23);
            tbArrTime.TabIndex = 22;
            // 
            // btnParse
            // 
            btnParse.Location = new Point(708, 364);
            btnParse.Name = "btnParse";
            btnParse.Size = new Size(75, 23);
            btnParse.TabIndex = 23;
            btnParse.Text = "Parse";
            btnParse.UseVisualStyleBackColor = true;
            btnParse.Click += btnParse_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(644, 393);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(139, 45);
            btnSave.TabIndex = 24;
            btnSave.Text = "Save settings";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tbGoogleForm
            // 
            tbGoogleForm.Location = new Point(204, 306);
            tbGoogleForm.Name = "tbGoogleForm";
            tbGoogleForm.Size = new Size(498, 23);
            tbGoogleForm.TabIndex = 25;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 309);
            label12.Name = "label12";
            label12.Size = new Size(98, 15);
            label12.TabIndex = 26;
            label12.Text = "Google form URL";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label12);
            Controls.Add(tbGoogleForm);
            Controls.Add(btnSave);
            Controls.Add(btnParse);
            Controls.Add(tbArrTime);
            Controls.Add(tbArrFuel);
            Controls.Add(tbArrICAO);
            Controls.Add(tbDepTime);
            Controls.Add(tbDepFuel);
            Controls.Add(tbDepICAO);
            Controls.Add(tbCargo);
            Controls.Add(tbPassengers);
            Controls.Add(tbImmat);
            Controls.Add(tbCallsign);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Callsign);
            Controls.Add(tbFullUrl);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
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
        private Label label11;
        private TextBox tbCallsign;
        private TextBox tbImmat;
        private TextBox tbPassengers;
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
    }
}