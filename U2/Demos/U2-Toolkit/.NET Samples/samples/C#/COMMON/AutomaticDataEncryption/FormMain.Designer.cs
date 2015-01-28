namespace WalletConnection
{
    partial class FormMain
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
            this.grdDataList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtUniVerse = new System.Windows.Forms.RadioButton();
            this.rbtUniData = new System.Windows.Forms.RadioButton();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxWalletPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxWalletID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.lblSplit = new System.Windows.Forms.Label();
            this.bwkRetrieve = new System.ComponentModel.BackgroundWorker();
            this.ttpControls = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtModeNative = new System.Windows.Forms.RadioButton();
            this.rbtModeAdo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDataList
            // 
            this.grdDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDataList.Location = new System.Drawing.Point(265, 20);
            this.grdDataList.Name = "grdDataList";
            this.grdDataList.ReadOnly = true;
            this.grdDataList.Size = new System.Drawing.Size(404, 160);
            this.grdDataList.TabIndex = 12;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
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
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(110, 102);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(100, 20);
            this.tbxPassword.TabIndex = 4;
            this.tbxPassword.Text = "pass";
            this.tbxPassword.UseSystemPasswordChar = true;
            this.tbxPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPassword_Validating);
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
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(110, 76);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(100, 20);
            this.tbxUserName.TabIndex = 3;
            this.tbxUserName.Text = "administrator";
            this.tbxUserName.Validating += new System.ComponentModel.CancelEventHandler(this.tbxUserName_Validating);
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
            // tbxDatabase
            // 
            this.tbxDatabase.Location = new System.Drawing.Point(110, 50);
            this.tbxDatabase.Name = "tbxDatabase";
            this.tbxDatabase.Size = new System.Drawing.Size(100, 20);
            this.tbxDatabase.TabIndex = 2;
            this.tbxDatabase.Text = "demo";
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
            // tbxServer
            // 
            this.tbxServer.Location = new System.Drawing.Point(110, 24);
            this.tbxServer.Name = "tbxServer";
            this.tbxServer.Size = new System.Drawing.Size(100, 20);
            this.tbxServer.TabIndex = 1;
            this.tbxServer.Text = "localhost";
            this.tbxServer.Validating += new System.ComponentModel.CancelEventHandler(this.tbxServer_Validating);
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
            this.groupBox2.Controls.Add(this.tbxWalletPassword);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbxWalletID);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbxFileName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 106);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADE";
            // 
            // tbxWalletPassword
            // 
            this.tbxWalletPassword.Location = new System.Drawing.Point(110, 72);
            this.tbxWalletPassword.Name = "tbxWalletPassword";
            this.tbxWalletPassword.Size = new System.Drawing.Size(100, 20);
            this.tbxWalletPassword.TabIndex = 9;
            this.tbxWalletPassword.UseSystemPasswordChar = true;
            this.tbxWalletPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbxWalletPassword_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Wallet Password";
            // 
            // tbxWalletID
            // 
            this.tbxWalletID.Location = new System.Drawing.Point(110, 46);
            this.tbxWalletID.Name = "tbxWalletID";
            this.tbxWalletID.Size = new System.Drawing.Size(100, 20);
            this.tbxWalletID.TabIndex = 8;
            this.tbxWalletID.Validating += new System.ComponentModel.CancelEventHandler(this.tbxWalletID_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Wallet ID";
            // 
            // tbxFileName
            // 
            this.tbxFileName.Location = new System.Drawing.Point(110, 20);
            this.tbxFileName.Name = "tbxFileName";
            this.tbxFileName.Size = new System.Drawing.Size(100, 20);
            this.tbxFileName.TabIndex = 7;
            this.tbxFileName.Validating += new System.ComponentModel.CancelEventHandler(this.tbxFileName_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "File/Table";
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(429, 201);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 10;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // tbxInfo
            // 
            this.tbxInfo.Location = new System.Drawing.Point(265, 237);
            this.tbxInfo.Multiline = true;
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.ReadOnly = true;
            this.tbxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInfo.Size = new System.Drawing.Size(404, 142);
            this.tbxInfo.TabIndex = 13;
            // 
            // lblSplit
            // 
            this.lblSplit.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblSplit.Location = new System.Drawing.Point(251, 10);
            this.lblSplit.Name = "lblSplit";
            this.lblSplit.Size = new System.Drawing.Size(1, 375);
            this.lblSplit.TabIndex = 4;
            // 
            // bwkRetrieve
            // 
            this.bwkRetrieve.WorkerReportsProgress = true;
            this.bwkRetrieve.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkRetrieve_DoWork);
            this.bwkRetrieve.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwkRetrieve_ProgressChanged);
            this.bwkRetrieve.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwkRetrieve_RunWorkerCompleted);
            // 
            // ttpControls
            // 
            this.ttpControls.AutomaticDelay = 300;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtModeNative);
            this.groupBox3.Controls.Add(this.rbtModeAdo);
            this.groupBox3.Location = new System.Drawing.Point(12, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 81);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Access";
            // 
            // rbtModeNative
            // 
            this.rbtModeNative.AutoSize = true;
            this.rbtModeNative.Checked = true;
            this.rbtModeNative.Location = new System.Drawing.Point(19, 24);
            this.rbtModeNative.Name = "rbtModeNative";
            this.rbtModeNative.Size = new System.Drawing.Size(145, 17);
            this.rbtModeNative.TabIndex = 63;
            this.rbtModeNative.TabStop = true;
            this.rbtModeNative.Tag = "Native";
            this.rbtModeNative.Text = "Native Mode (UO Server)";
            this.rbtModeNative.UseVisualStyleBackColor = true;
            // 
            // rbtModeAdo
            // 
            this.rbtModeAdo.AutoSize = true;
            this.rbtModeAdo.Location = new System.Drawing.Point(19, 47);
            this.rbtModeAdo.Name = "rbtModeAdo";
            this.rbtModeAdo.Size = new System.Drawing.Size(188, 17);
            this.rbtModeAdo.TabIndex = 64;
            this.rbtModeAdo.Tag = "Uci";
            this.rbtModeAdo.Text = "SQL ADO.NET Mode (UCI Server)";
            this.rbtModeAdo.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 391);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblSplit);
            this.Controls.Add(this.grdDataList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.btnRetrieve);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADE Test";
            this.Load += new System.EventHandler(this.ADETest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDataList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.Label lblSplit;
        private System.Windows.Forms.TextBox tbxServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxWalletPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxWalletID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxFileName;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bwkRetrieve;
        private System.Windows.Forms.RadioButton rbtUniVerse;
        private System.Windows.Forms.RadioButton rbtUniData;
        private System.Windows.Forms.ToolTip ttpControls;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtModeNative;
        private System.Windows.Forms.RadioButton rbtModeAdo;
    }
}

