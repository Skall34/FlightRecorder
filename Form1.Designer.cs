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
            timerConnection = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            tbCargo = new TextBox();
            label8 = new Label();
            label10 = new Label();
            label11 = new Label();
            tbCallsign = new TextBox();
            btnSaveSettings = new Button();
            btnSubmit = new Button();
            groupBox1 = new GroupBox();
            lbEndPosition = new Label();
            lbStartPosition = new Label();
            lbEndIata = new Label();
            lbStartIata = new Label();
            lbEndFuel = new Label();
            lbStartFuel = new Label();
            lbEndTime = new Label();
            lbStartTime = new Label();
            label15 = new Label();
            cbMission = new ComboBox();
            cbNote = new ComboBox();
            label2 = new Label();
            tbCommentaires = new TextBox();
            label12 = new Label();
            lbFret = new Label();
            groupBox3 = new GroupBox();
            lbDesignationAvion = new Label();
            cbImmat = new ComboBox();
            toolTip1 = new ToolTip(components);
            refillTimer = new System.Windows.Forms.Timer(components);
            btnReset = new Button();
            statusStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblConnectionStatus });
            statusStrip.Location = new Point(0, 470);
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
            // timerConnection
            // 
            timerConnection.Interval = 1000;
            timerConnection.Tick += timerConnection_Tick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 45);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 18);
            label3.TabIndex = 12;
            label3.Text = "Time";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 77);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(73, 18);
            label4.TabIndex = 13;
            label4.Text = "Fuel (Kg)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(185, 21);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(42, 18);
            label6.TabIndex = 18;
            label6.Text = "Start";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(324, 21);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(36, 18);
            label7.TabIndex = 19;
            label7.Text = "End";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 83);
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
            label8.Location = new Point(11, 108);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(66, 18);
            label8.TabIndex = 26;
            label8.Text = "Position";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 51);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(59, 18);
            label10.TabIndex = 31;
            label10.Text = "Aircraft";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 19);
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
            btnSaveSettings.Size = new Size(58, 25);
            btnSaveSettings.TabIndex = 1;
            btnSaveSettings.Text = "Apply";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Enabled = false;
            btnSubmit.ForeColor = Color.Black;
            btnSubmit.Location = new Point(391, 439);
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
            groupBox1.Controls.Add(lbEndPosition);
            groupBox1.Controls.Add(lbStartPosition);
            groupBox1.Controls.Add(lbEndIata);
            groupBox1.Controls.Add(lbStartIata);
            groupBox1.Controls.Add(lbEndFuel);
            groupBox1.Controls.Add(lbStartFuel);
            groupBox1.Controls.Add(lbEndTime);
            groupBox1.Controls.Add(lbStartTime);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(cbMission);
            groupBox1.Controls.Add(cbNote);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbCommentaires);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(10, 149);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(476, 283);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Flight summary";
            // 
            // lbEndPosition
            // 
            lbEndPosition.AutoSize = true;
            lbEndPosition.Location = new Point(173, 142);
            lbEndPosition.Name = "lbEndPosition";
            lbEndPosition.Size = new Size(17, 18);
            lbEndPosition.TabIndex = 40;
            lbEndPosition.Text = "?";
            // 
            // lbStartPosition
            // 
            lbStartPosition.AutoSize = true;
            lbStartPosition.Location = new Point(173, 108);
            lbStartPosition.Name = "lbStartPosition";
            lbStartPosition.Size = new Size(17, 18);
            lbStartPosition.TabIndex = 39;
            lbStartPosition.Text = "?";
            // 
            // lbEndIata
            // 
            lbEndIata.AutoSize = true;
            lbEndIata.Location = new Point(83, 142);
            lbEndIata.Name = "lbEndIata";
            lbEndIata.Size = new Size(44, 18);
            lbEndIata.TabIndex = 38;
            lbEndIata.Text = "????";
            // 
            // lbStartIata
            // 
            lbStartIata.AutoSize = true;
            lbStartIata.Location = new Point(83, 108);
            lbStartIata.Name = "lbStartIata";
            lbStartIata.Size = new Size(44, 18);
            lbStartIata.TabIndex = 37;
            lbStartIata.Text = "????";
            // 
            // lbEndFuel
            // 
            lbEndFuel.AutoSize = true;
            lbEndFuel.Location = new Point(320, 77);
            lbEndFuel.Name = "lbEndFuel";
            lbEndFuel.Size = new Size(44, 18);
            lbEndFuel.TabIndex = 36;
            lbEndFuel.Text = "????";
            lbEndFuel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbStartFuel
            // 
            lbStartFuel.AutoSize = true;
            lbStartFuel.Location = new Point(184, 77);
            lbStartFuel.Name = "lbStartFuel";
            lbStartFuel.Size = new Size(44, 18);
            lbStartFuel.TabIndex = 35;
            lbStartFuel.Text = "????";
            lbStartFuel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbEndTime
            // 
            lbEndTime.AutoSize = true;
            lbEndTime.Location = new Point(326, 45);
            lbEndTime.Name = "lbEndTime";
            lbEndTime.Size = new Size(32, 18);
            lbEndTime.TabIndex = 34;
            lbEndTime.Text = "--:--";
            lbEndTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbStartTime
            // 
            lbStartTime.AutoSize = true;
            lbStartTime.Location = new Point(190, 45);
            lbStartTime.Name = "lbStartTime";
            lbStartTime.Size = new Size(32, 18);
            lbStartTime.TabIndex = 33;
            lbStartTime.Text = "--:--";
            lbStartTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(217, 250);
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
            cbMission.Location = new Point(287, 248);
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
            cbNote.Location = new Point(118, 247);
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
            label2.Location = new Point(11, 250);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 18);
            label2.TabIndex = 16;
            label2.Text = "Evaluation";
            // 
            // tbCommentaires
            // 
            tbCommentaires.Location = new Point(118, 172);
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
            label12.Location = new Point(11, 175);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(83, 18);
            label12.TabIndex = 7;
            label12.Text = "Comments";
            // 
            // lbFret
            // 
            lbFret.AutoSize = true;
            lbFret.Location = new Point(6, 113);
            lbFret.Name = "lbFret";
            lbFret.Size = new Size(110, 18);
            lbFret.TabIndex = 43;
            lbFret.Text = "Fret on airport";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbDesignationAvion);
            groupBox3.Controls.Add(lbFret);
            groupBox3.Controls.Add(cbImmat);
            groupBox3.Controls.Add(btnSaveSettings);
            groupBox3.Controls.Add(tbCallsign);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(tbCargo);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(11, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(476, 138);
            groupBox3.TabIndex = 41;
            groupBox3.TabStop = false;
            groupBox3.Text = "Static data";
            // 
            // lbDesignationAvion
            // 
            lbDesignationAvion.AutoSize = true;
            lbDesignationAvion.Location = new Point(233, 49);
            lbDesignationAvion.Name = "lbDesignationAvion";
            lbDesignationAvion.Size = new Size(152, 18);
            lbDesignationAvion.TabIndex = 44;
            lbDesignationAvion.Text = "<no plane selected>";
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
            // refillTimer
            // 
            refillTimer.Interval = 500;
            refillTimer.Tick += refillTimer_Tick;
            // 
            // btnReset
            // 
            btnReset.ForeColor = Color.Black;
            btnReset.Location = new Point(12, 438);
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
            ClientSize = new Size(498, 492);
            Controls.Add(btnReset);
            Controls.Add(groupBox3);
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
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Timer timerConnection;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label9;
        private TextBox tbCargo;
        private Label label8;
        private Label label10;
        private Label label11;
        private TextBox tbCallsign;
        private Button btnSaveSettings;
        private Button btnSubmit;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Label label2;
        private TextBox tbCommentaires;
        private Label label12;
        private ComboBox cbNote;
        private ToolTip toolTip1;
        private System.Windows.Forms.Timer refillTimer;
        private ComboBox cbImmat;
        private Label lbFret;
        private Label label15;
        private ComboBox cbMission;
        private Button btnReset;
        private Label lbDesignationAvion;
        private Label lbEndPosition;
        private Label lbStartPosition;
        private Label lbEndIata;
        private Label lbStartIata;
        private Label lbEndFuel;
        private Label lbStartFuel;
        private Label lbEndTime;
        private Label lbStartTime;
    }
}

