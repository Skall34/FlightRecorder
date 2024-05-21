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
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            tbCallsign = new TextBox();
            btnSaveSettings = new Button();
            btnSubmit = new Button();
            groupBox1 = new GroupBox();
            groupBox4 = new GroupBox();
            label1 = new Label();
            label14 = new Label();
            label16 = new Label();
            label17 = new Label();
            lbEndPosition = new Label();
            lbEndIata = new Label();
            lbEndFuel = new Label();
            lbEndTime = new Label();
            groupBox2 = new GroupBox();
            label13 = new Label();
            lbStartPosition = new Label();
            lbStartIata = new Label();
            lbStartFuel = new Label();
            lbStartTime = new Label();
            label8 = new Label();
            label4 = new Label();
            label3 = new Label();
            lbTimeOnGround = new Label();
            lbOnGround = new Label();
            lbTimeAirborn = new Label();
            lbAirborn = new Label();
            label15 = new Label();
            cbMission = new ComboBox();
            cbNote = new ComboBox();
            label2 = new Label();
            tbCommentaires = new TextBox();
            label12 = new Label();
            lbFret = new Label();
            groupBox3 = new GroupBox();
            lbEndICAO = new Label();
            tbEndICAO = new TextBox();
            label5 = new Label();
            lbLibelleAvion = new Label();
            lbPayload = new Label();
            lbDesignationAvion = new Label();
            cbImmat = new ComboBox();
            toolTip1 = new ToolTip(components);
            btnReset = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            resetFlightToolStripMenuItem = new ToolStripMenuItem();
            submitFlightToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            submitBugToolStripMenuItem = new ToolStripMenuItem();
            statusStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblConnectionStatus });
            statusStrip.Location = new Point(0, 724);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 21, 0);
            statusStrip.Size = new Size(495, 22);
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
            timerMain.Tick += TimerMain_Tick;
            // 
            // timerConnection
            // 
            timerConnection.Interval = 1000;
            timerConnection.Tick += TimerConnection_Tick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 120);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(105, 18);
            label9.TabIndex = 24;
            label9.Text = "Payload (Kg) :";
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
            tbCallsign.TextChanged += TextBox1_TextChanged;
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
            btnSaveSettings.Click += BtnSaveSettings_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Enabled = false;
            btnSubmit.ForeColor = Color.Black;
            btnSubmit.Location = new Point(391, 686);
            btnSubmit.Margin = new Padding(4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(96, 27);
            btnSubmit.TabIndex = 24;
            btnSubmit.Text = "Save flight";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(lbTimeOnGround);
            groupBox1.Controls.Add(lbOnGround);
            groupBox1.Controls.Add(lbTimeAirborn);
            groupBox1.Controls.Add(lbAirborn);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(cbMission);
            groupBox1.Controls.Add(cbNote);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbCommentaires);
            groupBox1.Controls.Add(label12);
            groupBox1.Location = new Point(10, 201);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(476, 478);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Flight summary";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(label17);
            groupBox4.Controls.Add(lbEndPosition);
            groupBox4.Controls.Add(lbEndIata);
            groupBox4.Controls.Add(lbEndFuel);
            groupBox4.Controls.Add(lbEndTime);
            groupBox4.Location = new Point(9, 214);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(455, 141);
            groupBox4.TabIndex = 53;
            groupBox4.TabStop = false;
            groupBox4.Text = "End";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 55);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 18);
            label1.TabIndex = 59;
            label1.Text = "Position Name";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(11, 21);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(106, 18);
            label14.TabIndex = 58;
            label14.Text = "Position ICAO";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(11, 112);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(73, 18);
            label16.TabIndex = 57;
            label16.Text = "Fuel (Kg)";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(11, 84);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(43, 18);
            label17.TabIndex = 56;
            label17.Text = "Time";
            // 
            // lbEndPosition
            // 
            lbEndPosition.AutoSize = true;
            lbEndPosition.Location = new Point(137, 55);
            lbEndPosition.Name = "lbEndPosition";
            lbEndPosition.Size = new Size(17, 18);
            lbEndPosition.TabIndex = 55;
            lbEndPosition.Text = "?";
            // 
            // lbEndIata
            // 
            lbEndIata.AutoSize = true;
            lbEndIata.Location = new Point(137, 21);
            lbEndIata.Name = "lbEndIata";
            lbEndIata.Size = new Size(44, 18);
            lbEndIata.TabIndex = 54;
            lbEndIata.Text = "????";
            // 
            // lbEndFuel
            // 
            lbEndFuel.AutoSize = true;
            lbEndFuel.Location = new Point(137, 112);
            lbEndFuel.Name = "lbEndFuel";
            lbEndFuel.Size = new Size(44, 18);
            lbEndFuel.TabIndex = 53;
            lbEndFuel.Text = "????";
            lbEndFuel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbEndTime
            // 
            lbEndTime.AutoSize = true;
            lbEndTime.Location = new Point(137, 84);
            lbEndTime.Name = "lbEndTime";
            lbEndTime.Size = new Size(32, 18);
            lbEndTime.TabIndex = 52;
            lbEndTime.Text = "--:--";
            lbEndTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(lbStartPosition);
            groupBox2.Controls.Add(lbStartIata);
            groupBox2.Controls.Add(lbStartFuel);
            groupBox2.Controls.Add(lbStartTime);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(9, 36);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(455, 141);
            groupBox2.TabIndex = 52;
            groupBox2.TabStop = false;
            groupBox2.Text = "Start";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(11, 51);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(110, 18);
            label13.TabIndex = 55;
            label13.Text = "Position Name";
            // 
            // lbStartPosition
            // 
            lbStartPosition.AutoSize = true;
            lbStartPosition.Location = new Point(137, 51);
            lbStartPosition.Name = "lbStartPosition";
            lbStartPosition.Size = new Size(17, 18);
            lbStartPosition.TabIndex = 54;
            lbStartPosition.Text = "?";
            // 
            // lbStartIata
            // 
            lbStartIata.AutoSize = true;
            lbStartIata.Location = new Point(137, 21);
            lbStartIata.Name = "lbStartIata";
            lbStartIata.Size = new Size(44, 18);
            lbStartIata.TabIndex = 53;
            lbStartIata.Text = "????";
            // 
            // lbStartFuel
            // 
            lbStartFuel.AutoSize = true;
            lbStartFuel.Location = new Point(137, 106);
            lbStartFuel.Name = "lbStartFuel";
            lbStartFuel.Size = new Size(44, 18);
            lbStartFuel.TabIndex = 52;
            lbStartFuel.Text = "????";
            lbStartFuel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbStartTime
            // 
            lbStartTime.AutoSize = true;
            lbStartTime.Location = new Point(137, 79);
            lbStartTime.Name = "lbStartTime";
            lbStartTime.Size = new Size(32, 18);
            lbStartTime.TabIndex = 51;
            lbStartTime.Text = "--:--";
            lbStartTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 21);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(106, 18);
            label8.TabIndex = 50;
            label8.Text = "Position ICAO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 106);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(73, 18);
            label4.TabIndex = 49;
            label4.Text = "Fuel (Kg)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 79);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 18);
            label3.TabIndex = 48;
            label3.Text = "Time";
            // 
            // lbTimeOnGround
            // 
            lbTimeOnGround.AutoSize = true;
            lbTimeOnGround.Location = new Point(374, 191);
            lbTimeOnGround.Name = "lbTimeOnGround";
            lbTimeOnGround.Size = new Size(32, 18);
            lbTimeOnGround.TabIndex = 46;
            lbTimeOnGround.Text = "--:--";
            lbTimeOnGround.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbOnGround
            // 
            lbOnGround.AutoSize = true;
            lbOnGround.Location = new Point(265, 191);
            lbOnGround.Margin = new Padding(4, 0, 4, 0);
            lbOnGround.Name = "lbOnGround";
            lbOnGround.Size = new Size(87, 18);
            lbOnGround.TabIndex = 45;
            lbOnGround.Text = "On Ground";
            lbOnGround.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTimeAirborn
            // 
            lbTimeAirborn.AutoSize = true;
            lbTimeAirborn.Location = new Point(167, 191);
            lbTimeAirborn.Name = "lbTimeAirborn";
            lbTimeAirborn.Size = new Size(32, 18);
            lbTimeAirborn.TabIndex = 43;
            lbTimeAirborn.Text = "--:--";
            lbTimeAirborn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbAirborn
            // 
            lbAirborn.AutoSize = true;
            lbAirborn.Location = new Point(100, 191);
            lbAirborn.Margin = new Padding(4, 0, 4, 0);
            lbAirborn.Name = "lbAirborn";
            lbAirborn.Size = new Size(60, 18);
            lbAirborn.TabIndex = 42;
            lbAirborn.Text = "Airborn";
            lbAirborn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(215, 443);
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
            cbMission.Location = new Point(285, 441);
            cbMission.Name = "cbMission";
            cbMission.Size = new Size(179, 26);
            cbMission.TabIndex = 22;
            // 
            // cbNote
            // 
            cbNote.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNote.FormattingEnabled = true;
            cbNote.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            cbNote.Location = new Point(116, 440);
            cbNote.MaxDropDownItems = 10;
            cbNote.Name = "cbNote";
            cbNote.Size = new Size(66, 26);
            cbNote.TabIndex = 21;
            cbNote.MouseHover += CbNote_MouseHover;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 443);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 18);
            label2.TabIndex = 16;
            label2.Text = "Evaluation";
            // 
            // tbCommentaires
            // 
            tbCommentaires.Location = new Point(116, 368);
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
            label12.Location = new Point(10, 368);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(83, 18);
            label12.TabIndex = 7;
            label12.Text = "Comments";
            // 
            // lbFret
            // 
            lbFret.AutoSize = true;
            lbFret.Location = new Point(6, 152);
            lbFret.Name = "lbFret";
            lbFret.Size = new Size(110, 18);
            lbFret.TabIndex = 43;
            lbFret.Text = "Fret on airport";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbEndICAO);
            groupBox3.Controls.Add(tbEndICAO);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(lbLibelleAvion);
            groupBox3.Controls.Add(lbPayload);
            groupBox3.Controls.Add(lbDesignationAvion);
            groupBox3.Controls.Add(lbFret);
            groupBox3.Controls.Add(cbImmat);
            groupBox3.Controls.Add(btnSaveSettings);
            groupBox3.Controls.Add(tbCallsign);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(11, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(476, 183);
            groupBox3.TabIndex = 41;
            groupBox3.TabStop = false;
            groupBox3.Text = "Static data";
            // 
            // lbEndICAO
            // 
            lbEndICAO.AutoSize = true;
            lbEndICAO.Font = new Font("Arial", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbEndICAO.Location = new Point(360, 127);
            lbEndICAO.Margin = new Padding(4, 0, 4, 0);
            lbEndICAO.Name = "lbEndICAO";
            lbEndICAO.Size = new Size(104, 16);
            lbEndICAO.TabIndex = 49;
            lbEndICAO.Text = "Opt: End ICAO";
            // 
            // tbEndICAO
            // 
            tbEndICAO.BackColor = Color.White;
            tbEndICAO.Location = new Point(400, 145);
            tbEndICAO.Margin = new Padding(4);
            tbEndICAO.Name = "tbEndICAO";
            tbEndICAO.ShortcutsEnabled = false;
            tbEndICAO.Size = new Size(63, 25);
            tbEndICAO.TabIndex = 48;
            tbEndICAO.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 84);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(156, 18);
            label5.TabIndex = 47;
            label5.Text = "Aircraft Designation :";
            // 
            // lbLibelleAvion
            // 
            lbLibelleAvion.AutoSize = true;
            lbLibelleAvion.Location = new Point(176, 84);
            lbLibelleAvion.Name = "lbLibelleAvion";
            lbLibelleAvion.Size = new Size(126, 18);
            lbLibelleAvion.TabIndex = 46;
            lbLibelleAvion.Text = "Not Yet Available";
            // 
            // lbPayload
            // 
            lbPayload.AutoSize = true;
            lbPayload.Location = new Point(176, 120);
            lbPayload.Name = "lbPayload";
            lbPayload.Size = new Size(126, 18);
            lbPayload.TabIndex = 45;
            lbPayload.Text = "Not Yet Available";
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
            cbImmat.SelectedIndexChanged += CbImmat_SelectedIndexChanged;
            // 
            // btnReset
            // 
            btnReset.ForeColor = Color.Black;
            btnReset.Location = new Point(10, 686);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(101, 27);
            btnReset.TabIndex = 25;
            btnReset.Text = "Reset flight";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnReset_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { resetFlightToolStripMenuItem, submitFlightToolStripMenuItem, toolStripSeparator1, submitBugToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 98);
            // 
            // resetFlightToolStripMenuItem
            // 
            resetFlightToolStripMenuItem.Name = "resetFlightToolStripMenuItem";
            resetFlightToolStripMenuItem.Size = new Size(180, 22);
            resetFlightToolStripMenuItem.Text = "Reset flight";
            resetFlightToolStripMenuItem.Click += resetFlightToolStripMenuItem_Click;
            // 
            // submitFlightToolStripMenuItem
            // 
            submitFlightToolStripMenuItem.Name = "submitFlightToolStripMenuItem";
            submitFlightToolStripMenuItem.Size = new Size(180, 22);
            submitFlightToolStripMenuItem.Text = "Save Flight";
            submitFlightToolStripMenuItem.Click += submitFlightToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // submitBugToolStripMenuItem
            // 
            submitBugToolStripMenuItem.Name = "submitBugToolStripMenuItem";
            submitBugToolStripMenuItem.Size = new Size(180, 22);
            submitBugToolStripMenuItem.Text = "Submit bug";
            submitBugToolStripMenuItem.Click += submitBugToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(495, 746);
            ContextMenuStrip = contextMenuStrip1;
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
            Activated += Form1_Activated;
            FormClosing += FrmMain_FormClosing;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Timer timerConnection;
        private Label label9;
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
        private ComboBox cbImmat;
        private Label lbFret;
        private Label label15;
        private ComboBox cbMission;
        private Button btnReset;
        private Label lbDesignationAvion;
        private Label lbPayload;
        private Label lbTimeOnGround;
        private Label lbOnGround;
        private Label lbTimeAirborn;
        private Label lbAirborn;
        private Label lbLibelleAvion;
        private Label label5;
        private GroupBox groupBox4;
        private GroupBox groupBox2;
        private Label label13;
        private Label lbStartPosition;
        private Label lbStartIata;
        private Label lbStartFuel;
        private Label lbStartTime;
        private Label label8;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label14;
        private Label label16;
        private Label label17;
        private Label lbEndPosition;
        private Label lbEndIata;
        private Label lbEndFuel;
        private Label lbEndTime;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem resetFlightToolStripMenuItem;
        private ToolStripMenuItem submitFlightToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem submitBugToolStripMenuItem;
        private TextBox tbEndICAO;
        private Label lbEndICAO;
    }
}

