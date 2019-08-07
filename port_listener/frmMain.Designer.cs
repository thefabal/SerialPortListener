namespace port_listener {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbRTS = new System.Windows.Forms.GroupBox();
            this.rbRTSOff = new System.Windows.Forms.RadioButton();
            this.rbRTSOn = new System.Windows.Forms.RadioButton();
            this.gbDTR = new System.Windows.Forms.GroupBox();
            this.rbDTROff = new System.Windows.Forms.RadioButton();
            this.rbDTROn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStopBit = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbDataBit = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveHex = new System.Windows.Forms.Button();
            this.btnSaveRaw = new System.Windows.Forms.Button();
            this.nudGroupSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudBytePerLine = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.hbSerialData = new Be.Windows.Forms.HexBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.fileSizeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionSettingRateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.baudRateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbRTS.SuspendLayout();
            this.gbDTR.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGroupSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBytePerLine)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(664, 39);
            this.label9.TabIndex = 42;
            this.label9.Text = "Serial Port Listener";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.cbAuto);
            this.panel1.Controls.Add(this.btnListen);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 422);
            this.panel1.TabIndex = 44;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(76, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(63, 23);
            this.btnStop.TabIndex = 47;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Checked = true;
            this.cbAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAuto.Location = new System.Drawing.Point(18, 32);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(111, 17);
            this.cbAuto.TabIndex = 46;
            this.cbAuto.Text = "Auto Baud Switch";
            this.cbAuto.UseVisualStyleBackColor = true;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(12, 3);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(63, 23);
            this.btnListen.TabIndex = 45;
            this.btnListen.Text = "Start";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbRTS);
            this.groupBox1.Controls.Add(this.gbDTR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPortName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbStopBit);
            this.groupBox1.Controls.Add(this.cbParity);
            this.groupBox1.Controls.Add(this.cbDataBit);
            this.groupBox1.Controls.Add(this.cbBaudRate);
            this.groupBox1.Location = new System.Drawing.Point(3, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 363);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port Settings";
            // 
            // gbRTS
            // 
            this.gbRTS.Controls.Add(this.rbRTSOff);
            this.gbRTS.Controls.Add(this.rbRTSOn);
            this.gbRTS.Location = new System.Drawing.Point(4, 306);
            this.gbRTS.Name = "gbRTS";
            this.gbRTS.Size = new System.Drawing.Size(130, 44);
            this.gbRTS.TabIndex = 11;
            this.gbRTS.TabStop = false;
            this.gbRTS.Text = "RTS";
            // 
            // rbRTSOff
            // 
            this.rbRTSOff.AutoSize = true;
            this.rbRTSOff.ForeColor = System.Drawing.Color.Black;
            this.rbRTSOff.Location = new System.Drawing.Point(55, 19);
            this.rbRTSOff.Name = "rbRTSOff";
            this.rbRTSOff.Size = new System.Drawing.Size(39, 17);
            this.rbRTSOff.TabIndex = 108;
            this.rbRTSOff.Text = "Off";
            this.rbRTSOff.UseVisualStyleBackColor = true;
            // 
            // rbRTSOn
            // 
            this.rbRTSOn.AutoSize = true;
            this.rbRTSOn.Checked = true;
            this.rbRTSOn.ForeColor = System.Drawing.Color.Black;
            this.rbRTSOn.Location = new System.Drawing.Point(9, 19);
            this.rbRTSOn.Name = "rbRTSOn";
            this.rbRTSOn.Size = new System.Drawing.Size(39, 17);
            this.rbRTSOn.TabIndex = 107;
            this.rbRTSOn.TabStop = true;
            this.rbRTSOn.Text = "On";
            this.rbRTSOn.UseVisualStyleBackColor = true;
            // 
            // gbDTR
            // 
            this.gbDTR.Controls.Add(this.rbDTROff);
            this.gbDTR.Controls.Add(this.rbDTROn);
            this.gbDTR.Location = new System.Drawing.Point(4, 258);
            this.gbDTR.Name = "gbDTR";
            this.gbDTR.Size = new System.Drawing.Size(130, 44);
            this.gbDTR.TabIndex = 10;
            this.gbDTR.TabStop = false;
            this.gbDTR.Text = "DTR";
            // 
            // rbDTROff
            // 
            this.rbDTROff.AutoSize = true;
            this.rbDTROff.ForeColor = System.Drawing.Color.Black;
            this.rbDTROff.Location = new System.Drawing.Point(55, 19);
            this.rbDTROff.Name = "rbDTROff";
            this.rbDTROff.Size = new System.Drawing.Size(39, 17);
            this.rbDTROff.TabIndex = 108;
            this.rbDTROff.Text = "Off";
            this.rbDTROff.UseVisualStyleBackColor = true;
            // 
            // rbDTROn
            // 
            this.rbDTROn.AutoSize = true;
            this.rbDTROn.Checked = true;
            this.rbDTROn.ForeColor = System.Drawing.Color.Black;
            this.rbDTROn.Location = new System.Drawing.Point(9, 19);
            this.rbDTROn.Name = "rbDTROn";
            this.rbDTROn.Size = new System.Drawing.Size(39, 17);
            this.rbDTROn.TabIndex = 107;
            this.rbDTROn.TabStop = true;
            this.rbDTROn.Text = "On";
            this.rbDTROn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Port Names";
            // 
            // cbPortName
            // 
            this.cbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(13, 34);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(121, 21);
            this.cbPortName.TabIndex = 5;
            this.cbPortName.SelectedIndexChanged += new System.EventHandler(this.cbPortName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(10, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Stop Bit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(10, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Parity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(10, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data Bits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Baud Rate";
            // 
            // cbStopBit
            // 
            this.cbStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBit.FormattingEnabled = true;
            this.cbStopBit.Items.AddRange(new object[] {
            "None",
            "1",
            "2",
            "1.5"});
            this.cbStopBit.Location = new System.Drawing.Point(13, 226);
            this.cbStopBit.Name = "cbStopBit";
            this.cbStopBit.Size = new System.Drawing.Size(121, 21);
            this.cbStopBit.TabIndex = 9;
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cbParity.Location = new System.Drawing.Point(13, 178);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(121, 21);
            this.cbParity.TabIndex = 8;
            // 
            // cbDataBit
            // 
            this.cbDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBit.FormattingEnabled = true;
            this.cbDataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBit.Location = new System.Drawing.Point(13, 130);
            this.cbDataBit.Name = "cbDataBit";
            this.cbDataBit.Size = new System.Drawing.Size(121, 21);
            this.cbDataBit.TabIndex = 7;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(13, 82);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cbBaudRate.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSaveHex);
            this.groupBox2.Controls.Add(this.btnSaveRaw);
            this.groupBox2.Controls.Add(this.nudGroupSize);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nudBytePerLine);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.hbSerialData);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Location = new System.Drawing.Point(156, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 422);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // btnSaveHex
            // 
            this.btnSaveHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveHex.Location = new System.Drawing.Point(224, 365);
            this.btnSaveHex.Name = "btnSaveHex";
            this.btnSaveHex.Size = new System.Drawing.Size(133, 23);
            this.btnSaveHex.TabIndex = 55;
            this.btnSaveHex.Text = "Save Hex";
            this.btnSaveHex.UseVisualStyleBackColor = true;
            this.btnSaveHex.Click += new System.EventHandler(this.BtnSaveHex_Click);
            // 
            // btnSaveRaw
            // 
            this.btnSaveRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRaw.Location = new System.Drawing.Point(363, 365);
            this.btnSaveRaw.Name = "btnSaveRaw";
            this.btnSaveRaw.Size = new System.Drawing.Size(133, 23);
            this.btnSaveRaw.TabIndex = 54;
            this.btnSaveRaw.Text = "Save Raw";
            this.btnSaveRaw.UseVisualStyleBackColor = true;
            this.btnSaveRaw.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // nudGroupSize
            // 
            this.nudGroupSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudGroupSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudGroupSize.Location = new System.Drawing.Point(88, 395);
            this.nudGroupSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudGroupSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudGroupSize.Name = "nudGroupSize";
            this.nudGroupSize.Size = new System.Drawing.Size(78, 20);
            this.nudGroupSize.TabIndex = 53;
            this.nudGroupSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudGroupSize.ValueChanged += new System.EventHandler(this.NudGroupSize_ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Group size :";
            // 
            // nudBytePerLine
            // 
            this.nudBytePerLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudBytePerLine.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudBytePerLine.Location = new System.Drawing.Point(88, 368);
            this.nudBytePerLine.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudBytePerLine.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudBytePerLine.Name = "nudBytePerLine";
            this.nudBytePerLine.Size = new System.Drawing.Size(78, 20);
            this.nudBytePerLine.TabIndex = 51;
            this.nudBytePerLine.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudBytePerLine.ValueChanged += new System.EventHandler(this.NudBytePerLine_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Bytes per line :";
            // 
            // hbSerialData
            // 
            this.hbSerialData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbSerialData.ColumnInfoVisible = true;
            this.hbSerialData.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hbSerialData.GroupSeparatorVisible = true;
            this.hbSerialData.Location = new System.Drawing.Point(6, 19);
            this.hbSerialData.Name = "hbSerialData";
            this.hbSerialData.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hbSerialData.Size = new System.Drawing.Size(492, 338);
            this.hbSerialData.StringViewVisible = true;
            this.hbSerialData.TabIndex = 48;
            this.hbSerialData.UseFixedBytesPerLine = true;
            this.hbSerialData.VScrollBarVisible = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(363, 392);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(135, 23);
            this.btnClear.TabIndex = 47;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSizeToolStripStatusLabel,
            this.connectionSettingRateToolStripStatusLabel,
            this.baudRateToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 462);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(664, 22);
            this.statusStrip.TabIndex = 49;
            this.statusStrip.Text = "statusStrip1";
            // 
            // fileSizeToolStripStatusLabel
            // 
            this.fileSizeToolStripStatusLabel.AutoSize = false;
            this.fileSizeToolStripStatusLabel.Name = "fileSizeToolStripStatusLabel";
            this.fileSizeToolStripStatusLabel.Size = new System.Drawing.Size(125, 17);
            // 
            // connectionSettingRateToolStripStatusLabel
            // 
            this.connectionSettingRateToolStripStatusLabel.AutoSize = false;
            this.connectionSettingRateToolStripStatusLabel.Name = "connectionSettingRateToolStripStatusLabel";
            this.connectionSettingRateToolStripStatusLabel.Size = new System.Drawing.Size(125, 17);
            // 
            // baudRateToolStripStatusLabel
            // 
            this.baudRateToolStripStatusLabel.AutoSize = false;
            this.baudRateToolStripStatusLabel.Name = "baudRateToolStripStatusLabel";
            this.baudRateToolStripStatusLabel.Size = new System.Drawing.Size(125, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 484);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Port Listener";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbRTS.ResumeLayout(false);
            this.gbRTS.PerformLayout();
            this.gbDTR.ResumeLayout(false);
            this.gbDTR.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGroupSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBytePerLine)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbAuto;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStopBit;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbDataBit;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox gbDTR;
        private System.Windows.Forms.RadioButton rbDTROff;
        private System.Windows.Forms.RadioButton rbDTROn;
        private System.Windows.Forms.GroupBox gbRTS;
        private System.Windows.Forms.RadioButton rbRTSOff;
        private System.Windows.Forms.RadioButton rbRTSOn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClear;
        private Be.Windows.Forms.HexBox hbSerialData;
        private System.Windows.Forms.NumericUpDown nudBytePerLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudGroupSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel fileSizeToolStripStatusLabel;
        private System.Windows.Forms.Button btnSaveRaw;
        private System.Windows.Forms.ToolStripStatusLabel connectionSettingRateToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel baudRateToolStripStatusLabel;
        private System.Windows.Forms.Button btnSaveHex;
    }
}

