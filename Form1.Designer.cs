namespace FlightRecorder
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            statusStrip = new StatusStrip();
            lblConnectionStatus = new ToolStripStatusLabel();
            timerMain = new System.Windows.Forms.Timer(components);
            txtAirspeed = new TextBox();
            label1 = new Label();
            timerConnection = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            label4 = new Label();
            tbStartTime = new TextBox();
            tbEndTime = new TextBox();
            label5 = new Label();
            tbCurrentFuel = new TextBox();
            label6 = new Label();
            label7 = new Label();
            tbStartFuel = new TextBox();
            tbEndFuel = new TextBox();
            label9 = new Label();
            tbCargo = new TextBox();
            label8 = new Label();
            tbStartPosition = new TextBox();
            tbEndPosition = new TextBox();
            tbStartIata = new TextBox();
            tbEndIata = new TextBox();
            label10 = new Label();
            tbImmatriculation = new TextBox();
            label11 = new Label();
            tbCallsign = new TextBox();
            btnSaveSettings = new Button();
            btnSubmit = new Button();
            llManualSave = new LinkLabel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            tbDesignationAvion = new TextBox();
            btnRefresh = new Button();
            btnSettings = new Button();
            groupBox4 = new GroupBox();
            tbPax = new TextBox();
            label13 = new Label();
            cbNote = new ComboBox();
            label2 = new Label();
            tbCommentaires = new TextBox();
            label12 = new Label();
            statusStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblConnectionStatus });
            statusStrip.Location = new Point(0, 574);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 23, 0);
            statusStrip.Size = new Size(584, 22);
            statusStrip.TabIndex = 6;
            statusStrip.Text = "statusStrip1";
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(104, 17);
            lblConnectionStatus.Text = "Connection Status";
            // 
            // timerMain
            // 
            timerMain.Interval = 500;
            timerMain.Tick += timerMain_Tick;
            // 
            // txtAirspeed
            // 
            txtAirspeed.Location = new Point(259, 23);
            txtAirspeed.Margin = new Padding(6, 4, 6, 4);
            txtAirspeed.Name = "txtAirspeed";
            txtAirspeed.ReadOnly = true;
            txtAirspeed.Size = new Size(141, 26);
            txtAirspeed.TabIndex = 9;
            txtAirspeed.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 27);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(201, 19);
            label1.TabIndex = 7;
            label1.Text = "Indicated Airpeed (Knots)";
            // 
            // timerConnection
            // 
            timerConnection.Interval = 1000;
            timerConnection.Tick += timerConnection_Tick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 48);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 19);
            label3.TabIndex = 12;
            label3.Text = "Time";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 81);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(78, 19);
            label4.TabIndex = 13;
            label4.Text = "Fuel (Kg)";
            // 
            // tbStartTime
            // 
            tbStartTime.Location = new Point(252, 48);
            tbStartTime.Margin = new Padding(4);
            tbStartTime.Name = "tbStartTime";
            tbStartTime.ReadOnly = true;
            tbStartTime.Size = new Size(141, 26);
            tbStartTime.TabIndex = 14;
            tbStartTime.TextAlign = HorizontalAlignment.Right;
            // 
            // tbEndTime
            // 
            tbEndTime.Location = new Point(404, 48);
            tbEndTime.Margin = new Padding(4);
            tbEndTime.Name = "tbEndTime";
            tbEndTime.ReadOnly = true;
            tbEndTime.Size = new Size(141, 26);
            tbEndTime.TabIndex = 15;
            tbEndTime.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 64);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(135, 19);
            label5.TabIndex = 16;
            label5.Text = "Current fuel (Kg)";
            // 
            // tbCurrentFuel
            // 
            tbCurrentFuel.Location = new Point(259, 60);
            tbCurrentFuel.Margin = new Padding(4);
            tbCurrentFuel.Name = "tbCurrentFuel";
            tbCurrentFuel.ReadOnly = true;
            tbCurrentFuel.Size = new Size(141, 26);
            tbCurrentFuel.TabIndex = 17;
            tbCurrentFuel.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(252, 14);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(45, 19);
            label6.TabIndex = 18;
            label6.Text = "Start";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(404, 14);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(40, 19);
            label7.TabIndex = 19;
            label7.Text = "End";
            // 
            // tbStartFuel
            // 
            tbStartFuel.Location = new Point(252, 82);
            tbStartFuel.Margin = new Padding(4);
            tbStartFuel.Name = "tbStartFuel";
            tbStartFuel.ReadOnly = true;
            tbStartFuel.Size = new Size(141, 26);
            tbStartFuel.TabIndex = 20;
            tbStartFuel.TextAlign = HorizontalAlignment.Right;
            // 
            // tbEndFuel
            // 
            tbEndFuel.Location = new Point(404, 81);
            tbEndFuel.Margin = new Padding(4);
            tbEndFuel.Name = "tbEndFuel";
            tbEndFuel.ReadOnly = true;
            tbEndFuel.Size = new Size(141, 26);
            tbEndFuel.TabIndex = 21;
            tbEndFuel.TextAlign = HorizontalAlignment.Right;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 93);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(71, 19);
            label9.TabIndex = 24;
            label9.Text = "Payload";
            // 
            // tbCargo
            // 
            tbCargo.Location = new Point(260, 90);
            tbCargo.Margin = new Padding(4);
            tbCargo.Name = "tbCargo";
            tbCargo.ReadOnly = true;
            tbCargo.Size = new Size(141, 26);
            tbCargo.TabIndex = 25;
            tbCargo.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(5, 119);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(72, 19);
            label8.TabIndex = 26;
            label8.Text = "Position";
            // 
            // tbStartPosition
            // 
            tbStartPosition.Location = new Point(192, 115);
            tbStartPosition.Margin = new Padding(4);
            tbStartPosition.Name = "tbStartPosition";
            tbStartPosition.ReadOnly = true;
            tbStartPosition.Size = new Size(353, 26);
            tbStartPosition.TabIndex = 27;
            tbStartPosition.TextAlign = HorizontalAlignment.Right;
            // 
            // tbEndPosition
            // 
            tbEndPosition.Location = new Point(192, 152);
            tbEndPosition.Margin = new Padding(4);
            tbEndPosition.Name = "tbEndPosition";
            tbEndPosition.ReadOnly = true;
            tbEndPosition.Size = new Size(353, 26);
            tbEndPosition.TabIndex = 28;
            tbEndPosition.TextAlign = HorizontalAlignment.Right;
            tbEndPosition.TextChanged += tbEndPosition_TextChanged;
            // 
            // tbStartIata
            // 
            tbStartIata.Location = new Point(92, 115);
            tbStartIata.Margin = new Padding(4);
            tbStartIata.Name = "tbStartIata";
            tbStartIata.ReadOnly = true;
            tbStartIata.Size = new Size(90, 26);
            tbStartIata.TabIndex = 29;
            tbStartIata.TextAlign = HorizontalAlignment.Right;
            // 
            // tbEndIata
            // 
            tbEndIata.Location = new Point(92, 152);
            tbEndIata.Margin = new Padding(4);
            tbEndIata.Name = "tbEndIata";
            tbEndIata.ReadOnly = true;
            tbEndIata.Size = new Size(90, 26);
            tbEndIata.TabIndex = 30;
            tbEndIata.TextAlign = HorizontalAlignment.Right;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 60);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(64, 19);
            label10.TabIndex = 31;
            label10.Text = "Aircraft";
            // 
            // tbImmatriculation
            // 
            tbImmatriculation.Font = new Font("Arial", 12F, FontStyle.Bold);
            tbImmatriculation.Location = new Point(110, 56);
            tbImmatriculation.Margin = new Padding(4);
            tbImmatriculation.Name = "tbImmatriculation";
            tbImmatriculation.ReadOnly = true;
            tbImmatriculation.RightToLeft = RightToLeft.No;
            tbImmatriculation.Size = new Size(140, 26);
            tbImmatriculation.TabIndex = 32;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 24);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(106, 19);
            label11.TabIndex = 33;
            label11.Text = "Pilot callsign";
            // 
            // tbCallsign
            // 
            tbCallsign.Location = new Point(259, 19);
            tbCallsign.Margin = new Padding(4);
            tbCallsign.Name = "tbCallsign";
            tbCallsign.Size = new Size(141, 26);
            tbCallsign.TabIndex = 34;
            tbCallsign.TextAlign = HorizontalAlignment.Right;
            tbCallsign.TextChanged += textBox1_TextChanged;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Enabled = false;
            btnSaveSettings.ForeColor = Color.Gray;
            btnSaveSettings.Location = new Point(411, 19);
            btnSaveSettings.Margin = new Padding(4);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(107, 26);
            btnSaveSettings.TabIndex = 35;
            btnSaveSettings.Text = "Apply";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.ForeColor = Color.Gray;
            btnSubmit.Location = new Point(457, 538);
            btnSubmit.Margin = new Padding(4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(107, 29);
            btnSubmit.TabIndex = 36;
            btnSubmit.Text = "Save flight";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // llManualSave
            // 
            llManualSave.AutoSize = true;
            llManualSave.Location = new Point(270, 543);
            llManualSave.Margin = new Padding(4, 0, 4, 0);
            llManualSave.Name = "llManualSave";
            llManualSave.Size = new Size(162, 19);
            llManualSave.TabIndex = 37;
            llManualSave.TabStop = true;
            llManualSave.Text = "Manually enter flight";
            llManualSave.LinkClicked += llManualSave_LinkClicked;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbEndIata);
            groupBox1.Controls.Add(tbStartIata);
            groupBox1.Controls.Add(tbEndPosition);
            groupBox1.Controls.Add(tbStartPosition);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(tbEndFuel);
            groupBox1.Controls.Add(tbStartFuel);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tbEndTime);
            groupBox1.Controls.Add(tbStartTime);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 340);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(558, 191);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Flight summary";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tbCurrentFuel);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtAirspeed);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 134);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(558, 98);
            groupBox2.TabIndex = 40;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dynamic data";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tbDesignationAvion);
            groupBox3.Controls.Add(btnRefresh);
            groupBox3.Controls.Add(btnSaveSettings);
            groupBox3.Controls.Add(tbCallsign);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(tbImmatriculation);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(tbCargo);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(12, -1);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(558, 129);
            groupBox3.TabIndex = 41;
            groupBox3.TabStop = false;
            groupBox3.Text = "Static data";
            // 
            // tbDesignationAvion
            // 
            tbDesignationAvion.Font = new Font("Arial", 12F, FontStyle.Bold);
            tbDesignationAvion.Location = new Point(260, 56);
            tbDesignationAvion.Margin = new Padding(4);
            tbDesignationAvion.Name = "tbDesignationAvion";
            tbDesignationAvion.ReadOnly = true;
            tbDesignationAvion.Size = new Size(258, 26);
            tbDesignationAvion.TabIndex = 40;
            tbDesignationAvion.TextAlign = HorizontalAlignment.Right;
            // 
            // btnRefresh
            // 
            btnRefresh.ForeColor = Color.Gray;
            btnRefresh.Location = new Point(411, 90);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(107, 26);
            btnRefresh.TabIndex = 39;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSettings
            // 
            btnSettings.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnSettings.ForeColor = Color.Gray;
            btnSettings.Location = new Point(12, 537);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(118, 31);
            btnSettings.TabIndex = 42;
            btnSettings.Text = "Gform Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tbPax);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(cbNote);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(tbCommentaires);
            groupBox4.Controls.Add(label12);
            groupBox4.Location = new Point(12, 234);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(558, 98);
            groupBox4.TabIndex = 43;
            groupBox4.TabStop = false;
            groupBox4.Text = "Flight data";
            // 
            // tbPax
            // 
            tbPax.Location = new Point(404, 62);
            tbPax.Margin = new Padding(6, 4, 6, 4);
            tbPax.Name = "tbPax";
            tbPax.Size = new Size(91, 26);
            tbPax.TabIndex = 19;
            tbPax.TextAlign = HorizontalAlignment.Right;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(348, 64);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(38, 19);
            label13.TabIndex = 18;
            label13.Text = "Pax";
            // 
            // cbNote
            // 
            cbNote.FormattingEnabled = true;
            cbNote.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbNote.Location = new Point(259, 61);
            cbNote.MaxDropDownItems = 10;
            cbNote.Name = "cbNote";
            cbNote.Size = new Size(73, 27);
            cbNote.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 64);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 19);
            label2.TabIndex = 16;
            label2.Text = "Note du vol";
            // 
            // tbCommentaires
            // 
            tbCommentaires.Location = new Point(259, 23);
            tbCommentaires.Margin = new Padding(6, 4, 6, 4);
            tbCommentaires.Name = "tbCommentaires";
            tbCommentaires.Size = new Size(286, 26);
            tbCommentaires.TabIndex = 9;
            tbCommentaires.TextAlign = HorizontalAlignment.Right;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(11, 27);
            label12.Margin = new Padding(6, 0, 6, 0);
            label12.Name = "label12";
            label12.Size = new Size(120, 19);
            label12.TabIndex = 7;
            label12.Text = "Commentaires";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(584, 596);
            Controls.Add(groupBox4);
            Controls.Add(btnSettings);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(llManualSave);
            Controls.Add(btnSubmit);
            Controls.Add(statusStrip);
            Font = new Font("Arial", 12F, FontStyle.Bold);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6, 4, 6, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Flight recorder";
            FormClosing += frmMain_FormClosing;
            Load += Form1_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.TextBox txtAirspeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerConnection;
        private Label label3;
        private Label label4;
        private TextBox tbStartTime;
        private TextBox tbEndTime;
        private Label label5;
        private TextBox tbCurrentFuel;
        private Label label6;
        private Label label7;
        private TextBox tbStartFuel;
        private TextBox tbEndFuel;
        private Label label9;
        private TextBox tbCargo;
        private Label label8;
        private TextBox tbStartPosition;
        private TextBox tbEndPosition;
        private TextBox tbStartIata;
        private TextBox tbEndIata;
        private Label label10;
        private TextBox tbImmatriculation;
        private Label label11;
        private TextBox tbCallsign;
        private Button btnSaveSettings;
        private Button btnSubmit;
        private LinkLabel llManualSave;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnSettings;
        private Button btnRefresh;
        private GroupBox groupBox4;
        private TextBox textBox1;
        private Label label2;
        private TextBox tbCommentaires;
        private Label label12;
        private ComboBox cbNote;
        private Label label13;
        private TextBox tbPax;
        private TextBox tbDesignationAvion;
    }
}

