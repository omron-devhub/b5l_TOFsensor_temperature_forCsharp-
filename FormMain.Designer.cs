namespace TOFSensorSampleGetTemperature
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurrentLED = new System.Windows.Forms.TextBox();
            this.txtCurrentImagerUL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.cmbCOMList = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.nudStopImager = new System.Windows.Forms.NumericUpDown();
            this.nudStopLED = new System.Windows.Forms.NumericUpDown();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCurrentImagerUR = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCurrentImagerLL = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCurrentImagerLR = new System.Windows.Forms.TextBox();
            this.nudStartLED = new System.Windows.Forms.NumericUpDown();
            this.nudStartImager = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopImager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopLED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartLED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartImager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStart.Location = new System.Drawing.Point(24, 341);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(158, 31);
            this.btnStart.TabIndex = 34;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStop.Location = new System.Drawing.Point(188, 341);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(158, 31);
            this.btnStop.TabIndex = 35;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label1.Location = new System.Drawing.Point(21, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Imager temperature";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label2.Location = new System.Drawing.Point(21, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "LED  temperature";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label3.Location = new System.Drawing.Point(462, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "°C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label4.Location = new System.Drawing.Point(462, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "°C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label5.Location = new System.Drawing.Point(645, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "°C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label6.Location = new System.Drawing.Point(771, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "°C";
            // 
            // txtCurrentLED
            // 
            this.txtCurrentLED.Enabled = false;
            this.txtCurrentLED.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.txtCurrentLED.Location = new System.Drawing.Point(539, 289);
            this.txtCurrentLED.Name = "txtCurrentLED";
            this.txtCurrentLED.Size = new System.Drawing.Size(100, 23);
            this.txtCurrentLED.TabIndex = 32;
            this.txtCurrentLED.TabStop = false;
            this.txtCurrentLED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurrentImagerUL
            // 
            this.txtCurrentImagerUL.Enabled = false;
            this.txtCurrentImagerUL.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.txtCurrentImagerUL.Location = new System.Drawing.Point(665, 160);
            this.txtCurrentImagerUL.Name = "txtCurrentImagerUL";
            this.txtCurrentImagerUL.Size = new System.Drawing.Size(100, 23);
            this.txtCurrentImagerUL.TabIndex = 16;
            this.txtCurrentImagerUL.TabStop = false;
            this.txtCurrentImagerUL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label7.Location = new System.Drawing.Point(358, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Stop temperature";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label8.Location = new System.Drawing.Point(541, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Current temperature";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.btnRefresh.Location = new System.Drawing.Point(188, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(158, 31);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.btnDisconnect.Location = new System.Drawing.Point(188, 62);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(158, 31);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnet";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // cmbCOMList
            // 
            this.cmbCOMList.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.cmbCOMList.FormattingEnabled = true;
            this.cmbCOMList.Location = new System.Drawing.Point(24, 21);
            this.cmbCOMList.Name = "cmbCOMList";
            this.cmbCOMList.Size = new System.Drawing.Size(158, 24);
            this.cmbCOMList.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.btnConnect.Location = new System.Drawing.Point(24, 62);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(158, 31);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // nudStopImager
            // 
            this.nudStopImager.DecimalPlaces = 1;
            this.nudStopImager.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.nudStopImager.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudStopImager.Location = new System.Drawing.Point(361, 161);
            this.nudStopImager.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudStopImager.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudStopImager.Name = "nudStopImager";
            this.nudStopImager.Size = new System.Drawing.Size(95, 23);
            this.nudStopImager.TabIndex = 13;
            this.nudStopImager.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudStopImager.Value = new decimal(new int[] {
            55,
            0,
            0,
            0});
            // 
            // nudStopLED
            // 
            this.nudStopLED.DecimalPlaces = 1;
            this.nudStopLED.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.nudStopLED.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudStopLED.Location = new System.Drawing.Point(361, 289);
            this.nudStopLED.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudStopLED.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudStopLED.Name = "nudStopLED";
            this.nudStopLED.Size = new System.Drawing.Size(95, 23);
            this.nudStopLED.TabIndex = 30;
            this.nudStopLED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudStopLED.Value = new decimal(new int[] {
            55,
            0,
            0,
            0});
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatusMessage.Location = new System.Drawing.Point(356, 345);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(236, 27);
            this.lblStatusMessage.TabIndex = 36;
            this.lblStatusMessage.Text = "lblStatusMessage";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtLog.Location = new System.Drawing.Point(24, 378);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(770, 222);
            this.txtLog.TabIndex = 37;
            this.txtLog.TabStop = false;
            this.txtLog.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label9.Location = new System.Drawing.Point(541, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Upper left";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label10.Location = new System.Drawing.Point(541, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "Upper right";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label11.Location = new System.Drawing.Point(771, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "°C";
            // 
            // txtCurrentImagerUR
            // 
            this.txtCurrentImagerUR.Enabled = false;
            this.txtCurrentImagerUR.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.txtCurrentImagerUR.Location = new System.Drawing.Point(665, 189);
            this.txtCurrentImagerUR.Name = "txtCurrentImagerUR";
            this.txtCurrentImagerUR.Size = new System.Drawing.Size(100, 23);
            this.txtCurrentImagerUR.TabIndex = 19;
            this.txtCurrentImagerUR.TabStop = false;
            this.txtCurrentImagerUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label12.Location = new System.Drawing.Point(541, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "Lower left";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label13.Location = new System.Drawing.Point(771, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "°C";
            // 
            // txtCurrentImagerLL
            // 
            this.txtCurrentImagerLL.Enabled = false;
            this.txtCurrentImagerLL.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.txtCurrentImagerLL.Location = new System.Drawing.Point(665, 218);
            this.txtCurrentImagerLL.Name = "txtCurrentImagerLL";
            this.txtCurrentImagerLL.Size = new System.Drawing.Size(100, 23);
            this.txtCurrentImagerLL.TabIndex = 22;
            this.txtCurrentImagerLL.TabStop = false;
            this.txtCurrentImagerLL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label14.Location = new System.Drawing.Point(541, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "Lower right";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label15.Location = new System.Drawing.Point(771, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 16);
            this.label15.TabIndex = 26;
            this.label15.Text = "°C";
            // 
            // txtCurrentImagerLR
            // 
            this.txtCurrentImagerLR.Enabled = false;
            this.txtCurrentImagerLR.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.txtCurrentImagerLR.Location = new System.Drawing.Point(665, 247);
            this.txtCurrentImagerLR.Name = "txtCurrentImagerLR";
            this.txtCurrentImagerLR.Size = new System.Drawing.Size(100, 23);
            this.txtCurrentImagerLR.TabIndex = 25;
            this.txtCurrentImagerLR.TabStop = false;
            this.txtCurrentImagerLR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudStartLED
            // 
            this.nudStartLED.DecimalPlaces = 1;
            this.nudStartLED.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.nudStartLED.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudStartLED.Location = new System.Drawing.Point(188, 289);
            this.nudStartLED.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudStartLED.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudStartLED.Name = "nudStartLED";
            this.nudStartLED.Size = new System.Drawing.Size(95, 23);
            this.nudStartLED.TabIndex = 28;
            this.nudStartLED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudStartLED.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nudStartImager
            // 
            this.nudStartImager.DecimalPlaces = 1;
            this.nudStartImager.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.nudStartImager.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudStartImager.Location = new System.Drawing.Point(188, 161);
            this.nudStartImager.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudStartImager.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudStartImager.Name = "nudStartImager";
            this.nudStartImager.Size = new System.Drawing.Size(95, 23);
            this.nudStartImager.TabIndex = 11;
            this.nudStartImager.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudStartImager.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label16.Location = new System.Drawing.Point(185, 124);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(144, 16);
            this.label16.TabIndex = 7;
            this.label16.Text = "Start temperature";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label17.Location = new System.Drawing.Point(289, 292);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 16);
            this.label17.TabIndex = 29;
            this.label17.Text = "°C";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label18.Location = new System.Drawing.Point(289, 163);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 16);
            this.label18.TabIndex = 12;
            this.label18.Text = "°C";
            // 
            // nudInterval
            // 
            this.nudInterval.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.nudInterval.Location = new System.Drawing.Point(400, 62);
            this.nudInterval.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(94, 23);
            this.nudInterval.TabIndex = 5;
            this.nudInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label19.Location = new System.Drawing.Point(397, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(296, 16);
            this.label19.TabIndex = 4;
            this.label19.Text = "Time interval after stop measurement";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.label20.Location = new System.Drawing.Point(503, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 16);
            this.label20.TabIndex = 6;
            this.label20.Text = "Second";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 612);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.nudStartLED);
            this.Controls.Add(this.nudStartImager);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCurrentImagerLR);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCurrentImagerLL);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCurrentImagerUR);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.nudStopLED);
            this.Controls.Add(this.nudStopImager);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.cmbCOMList);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCurrentLED);
            this.Controls.Add(this.txtCurrentImagerUL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TOF Sensor Sample Get Temperature Ver. 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudStopImager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopLED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartLED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartImager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurrentLED;
        private System.Windows.Forms.TextBox txtCurrentImagerUL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.ComboBox cmbCOMList;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.NumericUpDown nudStopImager;
        private System.Windows.Forms.NumericUpDown nudStopLED;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCurrentImagerUR;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCurrentImagerLL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCurrentImagerLR;
        private System.Windows.Forms.NumericUpDown nudStartLED;
        private System.Windows.Forms.NumericUpDown nudStartImager;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
    }
}

