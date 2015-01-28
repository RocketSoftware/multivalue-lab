namespace ConnectionPool
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.rbtUniVerse = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.rbtUniData = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSplit = new System.Windows.Forms.Label();
            this.tbxDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxServer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numUpDnLifetime = new System.Windows.Forms.NumericUpDown();
            this.pnlPool = new System.Windows.Forms.Panel();
            this.numUpDnMinPoolSize = new System.Windows.Forms.NumericUpDown();
            this.numUpDnMaxPoolSize = new System.Windows.Forms.NumericUpDown();
            this.numUpDnConnTimeout = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxEnableReset = new System.Windows.Forms.CheckBox();
            this.cbxEnablePooling = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bwkRun = new System.ComponentModel.BackgroundWorker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxCommand = new System.Windows.Forms.CheckBox();
            this.cbxDataReader = new System.Windows.Forms.CheckBox();
            this.cbxDataSet = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.numUpDnRepeatCount = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.tbxCommandText = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numUpDnThreadDelayTime = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numUpDnParallelMaxDegree = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbtModeNative = new System.Windows.Forms.RadioButton();
            this.rbtModeAdo = new System.Windows.Forms.RadioButton();
            this.ttpControls = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnLifetime)).BeginInit();
            this.pnlPool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnMinPoolSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnMaxPoolSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnConnTimeout)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnRepeatCount)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnThreadDelayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnParallelMaxDegree)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtUniVerse
            // 
            this.rbtUniVerse.AutoSize = true;
            this.rbtUniVerse.Checked = true;
            this.rbtUniVerse.Location = new System.Drawing.Point(110, 137);
            this.rbtUniVerse.Name = "rbtUniVerse";
            this.rbtUniVerse.Size = new System.Drawing.Size(68, 17);
            this.rbtUniVerse.TabIndex = 6;
            this.rbtUniVerse.TabStop = true;
            this.rbtUniVerse.Tag = "UNIVERSE";
            this.rbtUniVerse.Text = "UniVerse";
            this.rbtUniVerse.UseVisualStyleBackColor = true;
            this.rbtUniVerse.CheckedChanged += new System.EventHandler(this.rbtUniVerse_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(229, 39);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 75;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // rbtUniData
            // 
            this.rbtUniData.AutoSize = true;
            this.rbtUniData.Location = new System.Drawing.Point(19, 137);
            this.rbtUniData.Name = "rbtUniData";
            this.rbtUniData.Size = new System.Drawing.Size(64, 17);
            this.rbtUniData.TabIndex = 5;
            this.rbtUniData.Tag = "UNIDATA";
            this.rbtUniData.Text = "UniData";
            this.rbtUniData.UseVisualStyleBackColor = true;
            this.rbtUniData.CheckedChanged += new System.EventHandler(this.rbtUniData_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Min Pool Size";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(110, 102);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(100, 20);
            this.tbxPassword.TabIndex = 4;
            this.tbxPassword.UseSystemPasswordChar = true;
            this.tbxPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPassword_Validating);
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(110, 76);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(100, 20);
            this.tbxUserName.TabIndex = 3;
            this.tbxUserName.Validating += new System.ComponentModel.CancelEventHandler(this.tbxUserName_Validating);
            // 
            // tbxInfo
            // 
            this.tbxInfo.Location = new System.Drawing.Point(267, 270);
            this.tbxInfo.Multiline = true;
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.ReadOnly = true;
            this.tbxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInfo.Size = new System.Drawing.Size(469, 123);
            this.tbxInfo.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Name";
            // 
            // lblSplit
            // 
            this.lblSplit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSplit.Location = new System.Drawing.Point(254, 7);
            this.lblSplit.Name = "lblSplit";
            this.lblSplit.Size = new System.Drawing.Size(1, 390);
            this.lblSplit.TabIndex = 16;
            // 
            // tbxDatabase
            // 
            this.tbxDatabase.Location = new System.Drawing.Point(110, 50);
            this.tbxDatabase.Name = "tbxDatabase";
            this.tbxDatabase.Size = new System.Drawing.Size(100, 20);
            this.tbxDatabase.TabIndex = 2;
            this.tbxDatabase.Validating += new System.ComponentModel.CancelEventHandler(this.tbxDatabase_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account/DB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Max Pool Size";
            // 
            // tbxServer
            // 
            this.tbxServer.Location = new System.Drawing.Point(110, 24);
            this.tbxServer.Name = "tbxServer";
            this.tbxServer.Size = new System.Drawing.Size(100, 20);
            this.tbxServer.TabIndex = 1;
            this.tbxServer.Validating += new System.ComponentModel.CancelEventHandler(this.tbxServer_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtUniVerse);
            this.groupBox1.Controls.Add(this.rbtUniData);
            this.groupBox1.Controls.Add(this.tbxPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxDatabase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numUpDnLifetime);
            this.groupBox2.Controls.Add(this.pnlPool);
            this.groupBox2.Controls.Add(this.numUpDnConnTimeout);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbxEnableReset);
            this.groupBox2.Controls.Add(this.cbxEnablePooling);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(267, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 104);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection Pool";
            // 
            // numUpDnLifetime
            // 
            this.numUpDnLifetime.Location = new System.Drawing.Point(315, 76);
            this.numUpDnLifetime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDnLifetime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDnLifetime.Name = "numUpDnLifetime";
            this.numUpDnLifetime.Size = new System.Drawing.Size(75, 20);
            this.numUpDnLifetime.TabIndex = 55;
            this.numUpDnLifetime.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // pnlPool
            // 
            this.pnlPool.Controls.Add(this.label6);
            this.pnlPool.Controls.Add(this.label5);
            this.pnlPool.Controls.Add(this.numUpDnMinPoolSize);
            this.pnlPool.Controls.Add(this.numUpDnMaxPoolSize);
            this.pnlPool.Location = new System.Drawing.Point(6, 43);
            this.pnlPool.Name = "pnlPool";
            this.pnlPool.Size = new System.Drawing.Size(395, 28);
            this.pnlPool.TabIndex = 40;
            // 
            // numUpDnMinPoolSize
            // 
            this.numUpDnMinPoolSize.Location = new System.Drawing.Point(100, 4);
            this.numUpDnMinPoolSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDnMinPoolSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDnMinPoolSize.Name = "numUpDnMinPoolSize";
            this.numUpDnMinPoolSize.Size = new System.Drawing.Size(75, 20);
            this.numUpDnMinPoolSize.TabIndex = 40;
            this.numUpDnMinPoolSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numUpDnMaxPoolSize
            // 
            this.numUpDnMaxPoolSize.Location = new System.Drawing.Point(309, 4);
            this.numUpDnMaxPoolSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDnMaxPoolSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDnMaxPoolSize.Name = "numUpDnMaxPoolSize";
            this.numUpDnMaxPoolSize.Size = new System.Drawing.Size(75, 20);
            this.numUpDnMaxPoolSize.TabIndex = 45;
            this.numUpDnMaxPoolSize.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUpDnMaxPoolSize.Validating += new System.ComponentModel.CancelEventHandler(this.numUpDnMaxPoolSize_Validating);
            // 
            // numUpDnConnTimeout
            // 
            this.numUpDnConnTimeout.Location = new System.Drawing.Point(106, 76);
            this.numUpDnConnTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDnConnTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDnConnTimeout.Name = "numUpDnConnTimeout";
            this.numUpDnConnTimeout.Size = new System.Drawing.Size(75, 20);
            this.numUpDnConnTimeout.TabIndex = 50;
            this.numUpDnConnTimeout.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(391, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "seconds";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(182, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "ms";
            // 
            // cbxEnableReset
            // 
            this.cbxEnableReset.AutoSize = true;
            this.cbxEnableReset.Checked = true;
            this.cbxEnableReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnableReset.Location = new System.Drawing.Point(229, 24);
            this.cbxEnableReset.Name = "cbxEnableReset";
            this.cbxEnableReset.Size = new System.Drawing.Size(90, 17);
            this.cbxEnableReset.TabIndex = 35;
            this.cbxEnableReset.Text = "Enable Reset";
            this.cbxEnableReset.UseVisualStyleBackColor = true;
            // 
            // cbxEnablePooling
            // 
            this.cbxEnablePooling.AutoSize = true;
            this.cbxEnablePooling.Checked = true;
            this.cbxEnablePooling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnablePooling.Location = new System.Drawing.Point(20, 23);
            this.cbxEnablePooling.Name = "cbxEnablePooling";
            this.cbxEnablePooling.Size = new System.Drawing.Size(97, 17);
            this.cbxEnablePooling.TabIndex = 30;
            this.cbxEnablePooling.Text = "Enable Pooling";
            this.cbxEnablePooling.UseVisualStyleBackColor = true;
            this.cbxEnablePooling.CheckedChanged += new System.EventHandler(this.cbxPooling_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(226, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Life Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Timeout";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Max Degree";
            // 
            // bwkRun
            // 
            this.bwkRun.WorkerReportsProgress = true;
            this.bwkRun.WorkerSupportsCancellation = true;
            this.bwkRun.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkRun_DoWork);
            this.bwkRun.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwkRun_ProgressChanged);
            this.bwkRun.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwkRun_RunWorkerCompleted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Thread Delay";
            // 
            // cbxCommand
            // 
            this.cbxCommand.AutoSize = true;
            this.cbxCommand.CausesValidation = false;
            this.cbxCommand.Checked = true;
            this.cbxCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxCommand.Location = new System.Drawing.Point(20, 21);
            this.cbxCommand.Name = "cbxCommand";
            this.cbxCommand.Size = new System.Drawing.Size(73, 17);
            this.cbxCommand.TabIndex = 10;
            this.cbxCommand.Text = "Command";
            this.cbxCommand.UseVisualStyleBackColor = true;
            // 
            // cbxDataReader
            // 
            this.cbxDataReader.AutoSize = true;
            this.cbxDataReader.Location = new System.Drawing.Point(110, 21);
            this.cbxDataReader.Name = "cbxDataReader";
            this.cbxDataReader.Size = new System.Drawing.Size(84, 17);
            this.cbxDataReader.TabIndex = 15;
            this.cbxDataReader.Text = "DataReader";
            this.cbxDataReader.UseVisualStyleBackColor = true;
            // 
            // cbxDataSet
            // 
            this.cbxDataSet.AutoSize = true;
            this.cbxDataSet.Location = new System.Drawing.Point(20, 45);
            this.cbxDataSet.Name = "cbxDataSet";
            this.cbxDataSet.Size = new System.Drawing.Size(65, 17);
            this.cbxDataSet.TabIndex = 20;
            this.cbxDataSet.Text = "DataSet";
            this.cbxDataSet.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.CausesValidation = false;
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cbxDataSet);
            this.groupBox3.Controls.Add(this.cbxDataReader);
            this.groupBox3.Controls.Add(this.numUpDnRepeatCount);
            this.groupBox3.Controls.Add(this.cbxCommand);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(13, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 111);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Objects";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label15.Location = new System.Drawing.Point(18, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(192, 1);
            this.label15.TabIndex = 76;
            this.label15.Text = "label15";
            // 
            // numUpDnRepeatCount
            // 
            this.numUpDnRepeatCount.Location = new System.Drawing.Point(110, 79);
            this.numUpDnRepeatCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDnRepeatCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDnRepeatCount.Name = "numUpDnRepeatCount";
            this.numUpDnRepeatCount.Size = new System.Drawing.Size(75, 20);
            this.numUpDnRepeatCount.TabIndex = 60;
            this.numUpDnRepeatCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Repeat Count";
            // 
            // tbxCommandText
            // 
            this.tbxCommandText.Location = new System.Drawing.Point(11, 21);
            this.tbxCommandText.Multiline = true;
            this.tbxCommandText.Name = "tbxCommandText";
            this.tbxCommandText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxCommandText.Size = new System.Drawing.Size(205, 41);
            this.tbxCommandText.TabIndex = 70;
            this.tbxCommandText.Validating += new System.ComponentModel.CancelEventHandler(this.tbxCommandText_Validating);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numUpDnThreadDelayTime);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.numUpDnParallelMaxDegree);
            this.groupBox4.Location = new System.Drawing.Point(267, 122);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(469, 56);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parallelism";
            // 
            // numUpDnThreadDelayTime
            // 
            this.numUpDnThreadDelayTime.Location = new System.Drawing.Point(315, 21);
            this.numUpDnThreadDelayTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDnThreadDelayTime.Name = "numUpDnThreadDelayTime";
            this.numUpDnThreadDelayTime.Size = new System.Drawing.Size(75, 20);
            this.numUpDnThreadDelayTime.TabIndex = 65;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(391, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "seconds";
            // 
            // numUpDnParallelMaxDegree
            // 
            this.numUpDnParallelMaxDegree.Location = new System.Drawing.Point(106, 22);
            this.numUpDnParallelMaxDegree.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDnParallelMaxDegree.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDnParallelMaxDegree.Name = "numUpDnParallelMaxDegree";
            this.numUpDnParallelMaxDegree.Size = new System.Drawing.Size(75, 20);
            this.numUpDnParallelMaxDegree.TabIndex = 60;
            this.numUpDnParallelMaxDegree.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbxCommandText);
            this.groupBox5.Controls.Add(this.btnRun);
            this.groupBox5.Controls.Add(this.btnCancel);
            this.groupBox5.Location = new System.Drawing.Point(267, 186);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(469, 73);
            this.groupBox5.TabIndex = 70;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Command Text";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(315, 39);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbtModeNative);
            this.groupBox6.Controls.Add(this.rbtModeAdo);
            this.groupBox6.Location = new System.Drawing.Point(13, 302);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(228, 91);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Access";
            // 
            // rbtModeNative
            // 
            this.rbtModeNative.AutoSize = true;
            this.rbtModeNative.Checked = true;
            this.rbtModeNative.Location = new System.Drawing.Point(19, 24);
            this.rbtModeNative.Name = "rbtModeNative";
            this.rbtModeNative.Size = new System.Drawing.Size(145, 17);
            this.rbtModeNative.TabIndex = 20;
            this.rbtModeNative.TabStop = true;
            this.rbtModeNative.Tag = "Native";
            this.rbtModeNative.Text = "Native Mode (UO Server)";
            this.rbtModeNative.UseVisualStyleBackColor = true;
            this.rbtModeNative.CheckedChanged += new System.EventHandler(this.rbtModeNative_CheckedChanged);
            // 
            // rbtModeAdo
            // 
            this.rbtModeAdo.AutoSize = true;
            this.rbtModeAdo.Location = new System.Drawing.Point(19, 47);
            this.rbtModeAdo.Name = "rbtModeAdo";
            this.rbtModeAdo.Size = new System.Drawing.Size(188, 17);
            this.rbtModeAdo.TabIndex = 25;
            this.rbtModeAdo.Tag = "Uci";
            this.rbtModeAdo.Text = "SQL ADO.NET Mode (UCI Server)";
            this.rbtModeAdo.UseVisualStyleBackColor = true;
            this.rbtModeAdo.CheckedChanged += new System.EventHandler(this.rbtModeAdo_CheckedChanged);
            // 
            // ttpControls
            // 
            this.ttpControls.AutomaticDelay = 300;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(760, 405);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.lblSplit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection Pool Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnLifetime)).EndInit();
            this.pnlPool.ResumeLayout(false);
            this.pnlPool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnMinPoolSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnMaxPoolSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnConnTimeout)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnRepeatCount)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnThreadDelayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnParallelMaxDegree)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtUniVerse;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.RadioButton rbtUniData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSplit;
        private System.Windows.Forms.TextBox tbxDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker bwkRun;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbxDataReader;
        private System.Windows.Forms.CheckBox cbxDataSet;
        private System.Windows.Forms.CheckBox cbxCommand;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbxCommandText;
        private System.Windows.Forms.CheckBox cbxEnablePooling;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbxEnableReset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlPool;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numUpDnConnTimeout;
        private System.Windows.Forms.NumericUpDown numUpDnLifetime;
        private System.Windows.Forms.NumericUpDown numUpDnParallelMaxDegree;
        private System.Windows.Forms.NumericUpDown numUpDnThreadDelayTime;
        private System.Windows.Forms.NumericUpDown numUpDnRepeatCount;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbtModeNative;
        private System.Windows.Forms.RadioButton rbtModeAdo;
        private System.Windows.Forms.NumericUpDown numUpDnMinPoolSize;
        private System.Windows.Forms.NumericUpDown numUpDnMaxPoolSize;
        private System.Windows.Forms.ToolTip ttpControls;

    }
}

