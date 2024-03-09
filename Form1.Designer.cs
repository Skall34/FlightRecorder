using FlightRecorder.Properties;
using Newtonsoft.Json.Linq;

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
            label11 = new Label();
            tbCallsign = new TextBox();
            btnSaveSettings = new Button();
            btnSubmit = new Button();
            groupBox1 = new GroupBox();
            label15 = new Label();
            cbMission = new ComboBox();
            cbNote = new ComboBox();
            label2 = new Label();
            tbCommentaires = new TextBox();
            label12 = new Label();
            groupBox2 = new GroupBox();
            lbFret = new Label();
            tbCurrentPosition = new TextBox();
            tbVSpeed = new TextBox();
            tbCurrentIata = new TextBox();
            label14 = new Label();
            label13 = new Label();
            btnRefill = new Button();
            groupBox3 = new GroupBox();
            cbImmat = new ComboBox();
            tbDesignationAvion = new TextBox();
            toolTip1 = new ToolTip(components);
            refillTimer = new System.Windows.Forms.Timer(components);
            btnReset = new Button();
            statusStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblConnectionStatus });
            statusStrip.Location = new Point(0, 622);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 21, 0);
            statusStrip.Size = new Size(498, 22);
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
            timerMain.Tick += timerMain_Tick;
            // 
            // txtAirspeed
            // 
            txtAirspeed.Location = new Point(194, 85);
            txtAirspeed.Margin = new Padding(5, 4, 5, 4);
            txtAirspeed.Name = "txtAirspeed";
            txtAirspeed.ReadOnly = true;
            txtAirspeed.Size = new Size(74, 25);
            txtAirspeed.TabIndex = 8;
            txtAirspeed.TabStop = false;
            txtAirspeed.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 88);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(187, 18);
            label1.TabIndex = 7;
            label1.Text = "Indicated Airpeed (Knots)";
            label1.Click += label1_Click;
            // 
            // timerConnection
            // 
            timerConnection.Interval = 1000;
            timerConnection.Tick += timerConnection_Tick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 34);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 18);
            label3.TabIndex = 12;
            label3.Text = "Time";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 66);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(73, 18);
            label4.TabIndex = 13;
            label4.Text = "Fuel (Kg)";
            // 
            // tbStartTime
            // 
            tbStartTime.Location = new Point(227, 34);
            tbStartTime.Margin = new Padding(4);
            tbStartTime.Name = "tbStartTime";
            tbStartTime.ReadOnly = true;
            tbStartTime.Size = new Size(69, 25);
            tbStartTime.TabIndex = 12;
            tbStartTime.TabStop = false;
            tbStartTime.TextAlign = HorizontalAlignment.Right;
            // 
            // tbEndTime
            // 
            tbEndTime.Location = new Point(364, 34);
            tbEndTime.Margin = new Padding(4);
            tbEndTime.Name = "tbEndTime";
            tbEndTime.ReadOnly = true;
            tbEndTime.Size = new Size(69, 25);
            tbEndTime.TabIndex = 13;
            tbEndTime.TabStop = false;
            tbEndTime.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 123);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(128, 18);
            label5.TabIndex = 16;
            label5.Text = "Current fuel (Kg)";
            // 
            // tbCurrentFuel
            // 
            tbCurrentFuel.BackColor = SystemColors.Control;
            tbCurrentFuel.Location = new Point(194, 120);
            tbCurrentFuel.Margin = new Padding(4);
            tbCurrentFuel.Name = "tbCurrentFuel";
            tbCurrentFuel.ReadOnly = true;
            tbCurrentFuel.Size = new Size(74, 25);
            tbCurrentFuel.TabIndex = 10;
            tbCurrentFuel.TabStop = false;
            tbCurrentFuel.TextAlign = HorizontalAlignment.Right;
            tbCurrentFuel.TextChanged += tbCurrentFuel_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(254, 13);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(42, 18);
            label6.TabIndex = 18;
            label6.Text = "Start";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(397, 13);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(36, 18);
            label7.TabIndex = 19;
            label7.Text = "End";
            // 
            // tbStartFuel
            // 
            tbStartFuel.Location = new Point(227, 67);
            tbStartFuel.Margin = new Padding(4);
            tbStartFuel.Name = "tbStartFuel";
            tbStartFuel.ReadOnly = true;
            tbStartFuel.Size = new Size(69, 25);
            tbStartFuel.TabIndex = 14;
            tbStartFuel.TabStop = false;
            tbStartFuel.TextAlign = HorizontalAlignment.Right;
            // 
            // tbEndFuel
            // 
            tbEndFuel.Location = new Point(364, 66);
            tbEndFuel.Margin = new Padding(4);
            tbEndFuel.Name = "tbEndFuel";
            tbEndFuel.ReadOnly = true;
            tbEndFuel.Size = new Size(69, 25);
            tbEndFuel.TabIndex = 15;
            tbEndFuel.TabStop = false;
            tbEndFuel.TextAlign = HorizontalAlignment.Right;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 83);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(97, 18);
            label9.TabIndex = 24;
            label9.Text = "Payload (Kg)";
            label9.Click += label9_Click;
            // 
            // tbCargo
            // 
            tbCargo.BackColor = Color.FromArgb(192, 255, 192);
            tbCargo.Location = new Point(118, 80);
            tbCargo.Margin = new Padding(4);
            tbCargo.Name = "tbCargo";
            tbCargo.Size = new Size(109, 25);
            tbCargo.TabIndex = 4;
            tbCargo.TextAlign = HorizontalAlignment.Right;
            tbCargo.TextChanged += tbCargo_TextChanged;
            tbCargo.Leave += tbCargo_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 102);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(66, 18);
            label8.TabIndex = 26;
            label8.Text = "Position";
            // 
            // tbStartPosition
            // 
            tbStartPosition.Location = new Point(173, 98);
            tbStartPosition.Margin = new Padding(4);
            tbStartPosition.Name = "tbStartPosition";
            tbStartPosition.ReadOnly = true;
            tbStartPosition.Size = new Size(293, 25);
            tbStartPosition.TabIndex = 17;
            tbStartPosition.TabStop = false;
            tbStartPosition.TextAlign = HorizontalAlignment.Right;
            // 
            // tbEndPosition
            // 
            tbEndPosition.Location = new Point(173, 133);
            tbEndPosition.Margin = new Padding(4);
            tbEndPosition.Name = "tbEndPosition";
            tbEndPosition.ReadOnly = true;
            tbEndPosition.Size = new Size(293, 25);
            tbEndPosition.TabIndex = 19;
            tbEndPosition.TabStop = false;
            tbEndPosition.TextAlign = HorizontalAlignment.Right;
            tbEndPosition.TextChanged += tbEndPosition_TextChanged;
            // 
            // tbStartIata
            // 
            tbStartIata.Location = new Point(83, 98);
            tbStartIata.Margin = new Padding(4);
            tbStartIata.Name = "tbStartIata";
            tbStartIata.ReadOnly = true;
            tbStartIata.Size = new Size(81, 25);
            tbStartIata.TabIndex = 16;
            tbStartIata.TabStop = false;
            tbStartIata.TextAlign = HorizontalAlignment.Right;
            // 
            // tbEndIata
            // 
            tbEndIata.Location = new Point(83, 133);
            tbEndIata.Margin = new Padding(4);
            tbEndIata.Name = "tbEndIata";
            tbEndIata.ReadOnly = true;
            tbEndIata.Size = new Size(81, 25);
            tbEndIata.TabIndex = 18;
            tbEndIata.TabStop = false;
            tbEndIata.TextAlign = HorizontalAlignment.Right;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(11, 51);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(59, 18);
            label10.TabIndex = 31;
            label10.Text = "Aircraft";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(11, 19);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(98, 18);
            label11.TabIndex = 33;
            label11.Text = "Pilot callsign";
            label11.Click += label11_Click;
            // 
            // tbCallsign
            // 
            tbCallsign.BackColor = Color.FromArgb(192, 255, 192);
            tbCallsign.Location = new Point(117, 16);
            tbCallsign.Margin = new Padding(4);
            tbCallsign.Name = "tbCallsign";
            tbCallsign.ShortcutsEnabled = false;
            tbCallsign.Size = new Size(111, 25);
            tbCallsign.TabIndex = 0;
            tbCallsign.TextAlign = HorizontalAlignment.Right;
            tbCallsign.TextChanged += textBox1_TextChanged;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Enabled = false;
            btnSaveSettings.ForeColor = Color.Gray;
            btnSaveSettings.Location = new Point(233, 16);
            btnSaveSettings.Margin = new Padding(4);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(96, 25);
            btnSaveSettings.TabIndex = 1;
            btnSaveSettings.Text = "Apply";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Enabled = false;
            btnSubmit.ForeColor = Color.Black;
            btnSubmit.Location = new Point(391, 583);
            btnSubmit.Margin = new Padding(4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(96, 27);
            btnSubmit.TabIndex = 24;
            btnSubmit.Text = "Save flight";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(cbMission);
            groupBox1.Controls.Add(cbNote);
            groupBox1.Controls.Add(tbEndIata);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbStartIata);
            groupBox1.Controls.Add(tbCommentaires);
            groupBox1.Controls.Add(label12);
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
            groupBox1.Location = new Point(11, 305);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(476, 272);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Flight summary";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(217, 242);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(63, 18);
            label15.TabIndex = 32;
            label15.Text = "Mission";
            // 
            // cbMission
            // 
            cbMission.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMission.FormattingEnabled = true;
            cbMission.Location = new Point(287, 240);
            cbMission.Name = "cbMission";
            cbMission.Size = new Size(121, 26);
            cbMission.TabIndex = 22;
            cbMission.SelectedIndexChanged += cbMission_SelectedIndexChanged;
            // 
            // cbNote
            // 
            cbNote.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNote.FormattingEnabled = true;
            cbNote.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            cbNote.Location = new Point(118, 239);
            cbNote.MaxDropDownItems = 10;
            cbNote.Name = "cbNote";
            cbNote.Size = new Size(66, 26);
            cbNote.TabIndex = 21;
            cbNote.SelectedIndexChanged += cbNote_SelectedIndexChanged;
            cbNote.MouseHover += cbNote_MouseHover;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 242);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 18);
            label2.TabIndex = 16;
            label2.Text = "Evaluation";
            // 
            // tbCommentaires
            // 
            tbCommentaires.Location = new Point(118, 166);
            tbCommentaires.Margin = new Padding(5, 4, 5, 4);
            tbCommentaires.Multiline = true;
            tbCommentaires.Name = "tbCommentaires";
            tbCommentaires.ScrollBars = ScrollBars.Vertical;
            tbCommentaires.Size = new Size(348, 66);
            tbCommentaires.TabIndex = 20;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(11, 169);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(83, 18);
            label12.TabIndex = 7;
            label12.Text = "Comments";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lbFret);
            groupBox2.Controls.Add(tbCurrentPosition);
            groupBox2.Controls.Add(tbVSpeed);
            groupBox2.Controls.Add(tbCurrentIata);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(tbCurrentFuel);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtAirspeed);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(11, 128);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(476, 171);
            groupBox2.TabIndex = 40;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dynamic data";
            // 
            // lbFret
            // 
            lbFret.AutoSize = true;
            lbFret.Location = new Point(11, 52);
            lbFret.Name = "lbFret";
            lbFret.Size = new Size(110, 18);
            lbFret.TabIndex = 43;
            lbFret.Text = "Fret on airport";
            // 
            // tbCurrentPosition
            // 
            tbCurrentPosition.Location = new Point(236, 18);
            tbCurrentPosition.Margin = new Padding(4);
            tbCurrentPosition.Name = "tbCurrentPosition";
            tbCurrentPosition.ReadOnly = true;
            tbCurrentPosition.Size = new Size(233, 25);
            tbCurrentPosition.TabIndex = 7;
            tbCurrentPosition.TabStop = false;
            tbCurrentPosition.TextAlign = HorizontalAlignment.Right;
            // 
            // tbVSpeed
            // 
            tbVSpeed.Location = new Point(376, 86);
            tbVSpeed.Name = "tbVSpeed";
            tbVSpeed.Size = new Size(90, 25);
            tbVSpeed.TabIndex = 9;
            tbVSpeed.TabStop = false;
            // 
            // tbCurrentIata
            // 
            tbCurrentIata.Location = new Point(147, 18);
            tbCurrentIata.Margin = new Padding(4);
            tbCurrentIata.Name = "tbCurrentIata";
            tbCurrentIata.ReadOnly = true;
            tbCurrentIata.Size = new Size(81, 25);
            tbCurrentIata.TabIndex = 6;
            tbCurrentIata.TabStop = false;
            tbCurrentIata.TextAlign = HorizontalAlignment.Right;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(304, 88);
            label14.Name = "label14";
            label14.Size = new Size(63, 18);
            label14.TabIndex = 18;
            label14.Text = "VSpeed";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(11, 21);
            label13.Name = "label13";
            label13.Size = new Size(124, 18);
            label13.TabIndex = 42;
            label13.Text = "Current position";
            label13.Click += label13_Click;
            // 
            // btnRefill
            // 
            btnRefill.ForeColor = Color.Gray;
            btnRefill.Location = new Point(355, 80);
            btnRefill.Name = "btnRefill";
            btnRefill.Size = new Size(111, 25);
            btnRefill.TabIndex = 11;
            btnRefill.Text = "Fuel refill";
            toolTip1.SetToolTip(btnRefill, "Keep button pressed to refill the tanks");
            btnRefill.UseVisualStyleBackColor = true;
            btnRefill.MouseDown += button1_MouseDown;
            btnRefill.MouseUp += button1_MouseUp;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbImmat);
            groupBox3.Controls.Add(btnRefill);
            groupBox3.Controls.Add(tbDesignationAvion);
            groupBox3.Controls.Add(btnSaveSettings);
            groupBox3.Controls.Add(tbCallsign);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(tbCargo);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(11, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(476, 117);
            groupBox3.TabIndex = 41;
            groupBox3.TabStop = false;
            groupBox3.Text = "Static data";
            // 
            // cbImmat
            // 
            cbImmat.DropDownStyle = ComboBoxStyle.DropDownList;
            cbImmat.FormattingEnabled = true;
            cbImmat.Location = new Point(118, 46);
            cbImmat.Name = "cbImmat";
            cbImmat.Size = new Size(109, 26);
            cbImmat.TabIndex = 2;
            cbImmat.SelectedIndexChanged += cbImmat_SelectedIndexChanged;
            // 
            // tbDesignationAvion
            // 
            tbDesignationAvion.Font = new Font("Arial", 12F, FontStyle.Bold);
            tbDesignationAvion.Location = new Point(233, 47);
            tbDesignationAvion.Margin = new Padding(4);
            tbDesignationAvion.Name = "tbDesignationAvion";
            tbDesignationAvion.ReadOnly = true;
            tbDesignationAvion.Size = new Size(233, 26);
            tbDesignationAvion.TabIndex = 3;
            tbDesignationAvion.TabStop = false;
            tbDesignationAvion.TextAlign = HorizontalAlignment.Right;
            // 
            // refillTimer
            // 
            refillTimer.Interval = 500;
            refillTimer.Tick += refillTimer_Tick;
            // 
            // btnReset
            // 
            btnReset.ForeColor = Color.Black;
            btnReset.Location = new Point(12, 583);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(101, 27);
            btnReset.TabIndex = 25;
            btnReset.Text = "Reset flight";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(498, 644);
            Controls.Add(btnReset);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnSubmit);
            Controls.Add(statusStrip);
            Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Flight recorder";
            TopMost = true;
            Activated += Form1_Activated;
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
        private Label label11;
        private TextBox tbCallsign;
        private Button btnSaveSettings;
        private Button btnSubmit;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox tbCurrentIata;
        private Label label2;
        private TextBox tbCommentaires;
        private Label label12;
        private ComboBox cbNote;
        private TextBox tbDesignationAvion;
        private ToolTip toolTip1;
        private TextBox tbVSpeed;
        private Label label14;
        private Button btnRefill;
        private System.Windows.Forms.Timer refillTimer;
        private ComboBox cbImmat;
        private Label label13;
        private TextBox tbCurrentPosition;
        private Label lbFret;
        private Label label15;
        private ComboBox cbMission;
        private Button btnReset;
    }
}

