namespace SSLConnection
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
            this.bwkConnect = new System.ComponentModel.BackgroundWorker();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.rbtModeNative = new System.Windows.Forms.RadioButton();
            this.rbtModeAdo = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numUpDnLifetime = new System.Windows.Forms.NumericUpDown();
            this.numUpDnConnTimeout = new System.Windows.Forms.NumericUpDown();
            this.cbxEnableSSLIgnIncompCertChain = new System.Windows.Forms.CheckBox();
            this.btnCertFileSelect = new System.Windows.Forms.Button();
            this.cbxEnableSSLChkCertRevocation = new System.Windows.Forms.CheckBox();
            this.cbxEnableSSLConnection = new System.Windows.Forms.CheckBox();
            this.cbxEnableSSLIgnCertNameMismatch = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCertificateFilePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.lblSplit = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.rbtUniVerse = new System.Windows.Forms.RadioButton();
            this.rbtUniData = new System.Windows.Forms.RadioButton();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxServer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fdlgSelectCertificate = new System.Windows.Forms.OpenFileDialog();
            this.bwkDisconnect = new System.ComponentModel.BackgroundWorker();
            this.ttpControls = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnLifetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnConnTimeout)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bwkConnect
            // 
            this.bwkConnect.WorkerReportsProgress = true;
            this.bwkConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkConnect_DoWork);
            this.bwkConnect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwkConnect_RunWorkerCompleted);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(29, 93);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 65;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(150, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "ms";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(360, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "ms";
            // 
            // groupBox3
            // 
            this.groupBox3.CausesValidation = false;
            this.groupBox3.Controls.Add(this.btnDisconnect);
            this.groupBox3.Controls.Add(this.rbtModeNative);
            this.groupBox3.Controls.Add(this.btnConnect);
            this.groupBox3.Controls.Add(this.rbtModeAdo);
            this.groupBox3.Location = new System.Drawing.Point(12, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 153);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Access";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(122, 93);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 66;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // rbtModeNative
            // 
            this.rbtModeNative.AutoSize = true;
            this.rbtModeNative.Checked = true;
            this.rbtModeNative.Location = new System.Drawing.Point(18, 29);
            this.rbtModeNative.Name = "rbtModeNative";
            this.rbtModeNative.Size = new System.Drawing.Size(145, 17);
            this.rbtModeNative.TabIndex = 61;
            this.rbtModeNative.TabStop = true;
            this.rbtModeNative.Tag = "Native";
            this.rbtModeNative.Text = "Native Mode (UO Server)";
            this.rbtModeNative.UseVisualStyleBackColor = true;
            // 
            // rbtModeAdo
            // 
            this.rbtModeAdo.AutoSize = true;
            this.rbtModeAdo.Location = new System.Drawing.Point(18, 52);
            this.rbtModeAdo.Name = "rbtModeAdo";
            this.rbtModeAdo.Size = new System.Drawing.Size(188, 17);
            this.rbtModeAdo.TabIndex = 62;
            this.rbtModeAdo.Tag = "Uci";
            this.rbtModeAdo.Text = "SQL ADO.NET Mode (UCI Server)";
            this.rbtModeAdo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Timeout";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(212, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Life Time";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numUpDnLifetime);
            this.groupBox2.Controls.Add(this.numUpDnConnTimeout);
            this.groupBox2.Controls.Add(this.cbxEnableSSLIgnIncompCertChain);
            this.groupBox2.Controls.Add(this.btnCertFileSelect);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbxEnableSSLChkCertRevocation);
            this.groupBox2.Controls.Add(this.cbxEnableSSLConnection);
            this.groupBox2.Controls.Add(this.cbxEnableSSLIgnCertNameMismatch);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbxCertificateFilePath);
            this.groupBox2.Location = new System.Drawing.Point(261, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 169);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SSL";
            // 
            // numUpDnLifetime
            // 
            this.numUpDnLifetime.Location = new System.Drawing.Point(284, 139);
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
            this.numUpDnLifetime.Size = new System.Drawing.Size(70, 20);
            this.numUpDnLifetime.TabIndex = 57;
            this.numUpDnLifetime.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numUpDnConnTimeout
            // 
            this.numUpDnConnTimeout.Location = new System.Drawing.Point(74, 137);
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
            this.numUpDnConnTimeout.Size = new System.Drawing.Size(70, 20);
            this.numUpDnConnTimeout.TabIndex = 57;
            this.numUpDnConnTimeout.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // cbxEnableSSLIgnIncompCertChain
            // 
            this.cbxEnableSSLIgnIncompCertChain.AutoSize = true;
            this.cbxEnableSSLIgnIncompCertChain.Checked = true;
            this.cbxEnableSSLIgnIncompCertChain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnableSSLIgnIncompCertChain.Location = new System.Drawing.Point(18, 54);
            this.cbxEnableSSLIgnIncompCertChain.Name = "cbxEnableSSLIgnIncompCertChain";
            this.cbxEnableSSLIgnIncompCertChain.Size = new System.Drawing.Size(191, 17);
            this.cbxEnableSSLIgnIncompCertChain.TabIndex = 43;
            this.cbxEnableSSLIgnIncompCertChain.Text = "Ignore Incomplete Certificate Chain";
            this.cbxEnableSSLIgnIncompCertChain.UseVisualStyleBackColor = true;
            // 
            // btnCertFileSelect
            // 
            this.btnCertFileSelect.Location = new System.Drawing.Point(312, 99);
            this.btnCertFileSelect.Name = "btnCertFileSelect";
            this.btnCertFileSelect.Size = new System.Drawing.Size(42, 23);
            this.btnCertFileSelect.TabIndex = 51;
            this.btnCertFileSelect.Text = "...";
            this.btnCertFileSelect.UseVisualStyleBackColor = true;
            this.btnCertFileSelect.Click += new System.EventHandler(this.btnCertFileSelect_Click);
            // 
            // cbxEnableSSLChkCertRevocation
            // 
            this.cbxEnableSSLChkCertRevocation.AutoSize = true;
            this.cbxEnableSSLChkCertRevocation.Location = new System.Drawing.Point(215, 53);
            this.cbxEnableSSLChkCertRevocation.Name = "cbxEnableSSLChkCertRevocation";
            this.cbxEnableSSLChkCertRevocation.Size = new System.Drawing.Size(165, 17);
            this.cbxEnableSSLChkCertRevocation.TabIndex = 44;
            this.cbxEnableSSLChkCertRevocation.Text = "Check Certificate Revocation";
            this.cbxEnableSSLChkCertRevocation.UseVisualStyleBackColor = true;
            // 
            // cbxEnableSSLConnection
            // 
            this.cbxEnableSSLConnection.AutoSize = true;
            this.cbxEnableSSLConnection.Checked = true;
            this.cbxEnableSSLConnection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnableSSLConnection.Location = new System.Drawing.Point(18, 28);
            this.cbxEnableSSLConnection.Name = "cbxEnableSSLConnection";
            this.cbxEnableSSLConnection.Size = new System.Drawing.Size(139, 17);
            this.cbxEnableSSLConnection.TabIndex = 41;
            this.cbxEnableSSLConnection.Text = "Enable SSL Connection";
            this.cbxEnableSSLConnection.UseVisualStyleBackColor = true;
            // 
            // cbxEnableSSLIgnCertNameMismatch
            // 
            this.cbxEnableSSLIgnCertNameMismatch.AutoSize = true;
            this.cbxEnableSSLIgnCertNameMismatch.Checked = true;
            this.cbxEnableSSLIgnCertNameMismatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnableSSLIgnCertNameMismatch.Location = new System.Drawing.Point(215, 28);
            this.cbxEnableSSLIgnCertNameMismatch.Name = "cbxEnableSSLIgnCertNameMismatch";
            this.cbxEnableSSLIgnCertNameMismatch.Size = new System.Drawing.Size(185, 17);
            this.cbxEnableSSLIgnCertNameMismatch.TabIndex = 42;
            this.cbxEnableSSLIgnCertNameMismatch.Text = "Ignore Certificate Name Mismatch";
            this.cbxEnableSSLIgnCertNameMismatch.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "CA File";
            // 
            // tbxCertificateFilePath
            // 
            this.tbxCertificateFilePath.Location = new System.Drawing.Point(74, 102);
            this.tbxCertificateFilePath.Name = "tbxCertificateFilePath";
            this.tbxCertificateFilePath.Size = new System.Drawing.Size(226, 20);
            this.tbxCertificateFilePath.TabIndex = 50;
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
            // tbxInfo
            // 
            this.tbxInfo.Location = new System.Drawing.Point(261, 200);
            this.tbxInfo.Multiline = true;
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.ReadOnly = true;
            this.tbxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInfo.Size = new System.Drawing.Size(409, 146);
            this.tbxInfo.TabIndex = 80;
            // 
            // lblSplit
            // 
            this.lblSplit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSplit.Location = new System.Drawing.Point(250, 2);
            this.lblSplit.Name = "lblSplit";
            this.lblSplit.Size = new System.Drawing.Size(1, 350);
            this.lblSplit.TabIndex = 78;
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(110, 76);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(100, 20);
            this.tbxUserName.TabIndex = 3;
            this.tbxUserName.Validating += new System.ComponentModel.CancelEventHandler(this.tbxUserName_Validating);
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
            this.rbtUniVerse.Click += new System.EventHandler(this.rbtUniVerse_Click);
            // 
            // rbtUniData
            // 
            this.rbtUniData.AutoSize = true;
            this.rbtUniData.Location = new System.Drawing.Point(20, 137);
            this.rbtUniData.Name = "rbtUniData";
            this.rbtUniData.Size = new System.Drawing.Size(64, 17);
            this.rbtUniData.TabIndex = 5;
            this.rbtUniData.Tag = "UNIDATA";
            this.rbtUniData.Text = "UniData";
            this.rbtUniData.UseVisualStyleBackColor = true;
            this.rbtUniData.CheckedChanged += new System.EventHandler(this.rbtUniData_CheckedChanged);
            this.rbtUniData.Click += new System.EventHandler(this.rbtUniData_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
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
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // fdlgSelectCertificate
            // 
            this.fdlgSelectCertificate.Filter = "CA files|*.crt;*.cer;*.cert|All Files|*.*";
            // 
            // bwkDisconnect
            // 
            this.bwkDisconnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkDisconnect_DoWork);
            this.bwkDisconnect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwkDisconnect_RunWorkerCompleted);
            // 
            // ttpControls
            // 
            this.ttpControls.AutomaticDelay = 300;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 358);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.lblSplit);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSL Connection Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnLifetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnConnTimeout)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwkConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxEnableSSLConnection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.Label lblSplit;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.RadioButton rbtUniVerse;
        private System.Windows.Forms.RadioButton rbtUniData;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtModeNative;
        private System.Windows.Forms.RadioButton rbtModeAdo;
        private System.Windows.Forms.CheckBox cbxEnableSSLIgnCertNameMismatch;
        private System.Windows.Forms.CheckBox cbxEnableSSLChkCertRevocation;
        private System.Windows.Forms.CheckBox cbxEnableSSLIgnIncompCertChain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCertificateFilePath;
        private System.Windows.Forms.OpenFileDialog fdlgSelectCertificate;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnCertFileSelect;
        private System.ComponentModel.BackgroundWorker bwkDisconnect;
        private System.Windows.Forms.ToolTip ttpControls;
        private System.Windows.Forms.NumericUpDown numUpDnLifetime;
        private System.Windows.Forms.NumericUpDown numUpDnConnTimeout;
    }
}

