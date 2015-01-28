using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using U2.Data.Client;

namespace SSLConnection
{
    public partial class MainForm : Form
    {
        private Properties.Settings settings = Properties.Settings.Default;

        private U2Connection con;
        
        /// <summary>
        /// Used for manual close this form
        /// </summary>
        private int WM_CLOSE = 0x0010;

        public MainForm()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLOSE)
            {
                // Exit without causing validate
                Application.Exit();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private string GetErrorMessage(Exception ex)
        {
            StringBuilder sbMessage = new StringBuilder();
            while (ex != null)
            {
                sbMessage.AppendFormat("{0}{1}", ex.Message, Environment.NewLine);
                ex = ex.InnerException;
            }
            return sbMessage.ToString();
        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                StringBuilder sbMessage = new StringBuilder();
                string strErrMessage = GetErrorMessage(e.Exception);
                string strStackTrace = e.Exception.StackTrace;

                sbMessage.AppendFormat("Unhandled Exception: {0}{1}{0}", Environment.NewLine, strErrMessage);
                sbMessage.AppendFormat("Stack Trace: {0}{1}", Environment.NewLine, strStackTrace);

                tbxInfo.Text = sbMessage.ToString();
            }
            catch (System.Exception ex)
            {
                string strMessage = string.Format("Unmanaged Exception: {0}", ex.Message);
                MessageBox.Show(strMessage);
            }
        }

        /// <summary>
        /// Set hint for input controls
        /// </summary>
        private void SetToolTip()
        {
            // Login
            ttpControls.SetToolTip(tbxServer, "Set server name or IP address");
            ttpControls.SetToolTip(tbxDatabase, "Set name of account or database");
            ttpControls.SetToolTip(tbxUserName, "Set name of the user");
            ttpControls.SetToolTip(tbxPassword, "Set password of the user");
            　　　　　　　　　　　　　　　　　
            // SSL
            ttpControls.SetToolTip(tbxCertificateFilePath, "Select the certificate file. \r\nKeep it empty if you want to automatically choose.");
            ttpControls.SetToolTip(numUpDnConnTimeout, "Set an integer value between 1 to 100000 to specify\r\n the period before throw a timeout error");
            ttpControls.SetToolTip(numUpDnLifetime, "Set an integer value between 1 to 100000 to specify\r\n the period that the connection is keeping active");
        }

        /// <summary>
        /// Initialize form state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetToolTip();

            // Load configure
            tbxServer.Text = settings.Server;
            tbxDatabase.Text = settings.Database;
            tbxUserName.Text = settings.UserName;
            tbxPassword.Text = settings.Password;

            // Server type
            string strServerType = settings.ServerType;
            switch (strServerType)
            {
                case "UNIDATA":
                    rbtUniData.Checked = true;
                    break;
                case "UNIVERSE":
                    rbtUniVerse.Checked = true;
                    break;
                default:
                    rbtUniData.Checked = true;
                    break;
            }

            // SSL
            cbxEnableSSLConnection.Checked = settings.EnableSSLConnection;
            cbxEnableSSLIgnCertNameMismatch.Checked = settings.EnableSSLIgnCertNameMismatch;
            cbxEnableSSLChkCertRevocation.Checked = settings.EnableSSLChkCertRevocation;
            cbxEnableSSLIgnIncompCertChain.Checked = settings.EnableSSLIgnIncompCertChain;
            tbxCertificateFilePath.Text = settings.CertificateFilePath;
            
            numUpDnConnTimeout.Value = settings.ConnTimeOut;
            numUpDnLifetime.Value = settings.ConnLifeTime;

            // Access mode
            string strAccessMode = settings.AccessMode;
            switch (strAccessMode)
            {
                case "Native":
                    rbtModeNative.Checked = true;
                    break;
                case "Uci":
                    rbtModeAdo.Checked = true;
                    break;
                default:
                    rbtModeNative.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// Update configuration
        /// </summary>
        private void UpdateConfig()
        {
            settings.Server = tbxServer.Text.Trim();
            settings.Database = tbxDatabase.Text.Trim();
            settings.UserName = tbxUserName.Text.Trim();
            settings.Password = tbxPassword.Text.Trim();

            if (rbtUniData.Checked==true)
            {
                settings.ServerType = rbtUniData.Tag.ToString();
                settings.RpcServiceType = "udcs";
            }
            else
            {
                settings.ServerType = rbtUniVerse.Tag.ToString();
                settings.RpcServiceType = "uvcs";
            }

            // Access mode
            if (rbtModeNative.Checked==true)
            {
                // UO mode
                settings.AccessMode = rbtModeNative.Tag.ToString();
            }
            else
            {
                // SQL ADO.NET mode
                settings.AccessMode = rbtModeAdo.Tag.ToString();
                settings.RpcServiceType = "defcs";
            }

            // SSL 
            settings.ConnTimeOut = (int)numUpDnConnTimeout.Value;
            settings.ConnLifeTime = (int)numUpDnLifetime.Value;
            settings.EnableSSLConnection = cbxEnableSSLConnection.Checked;
            settings.EnableSSLIgnCertNameMismatch = cbxEnableSSLIgnCertNameMismatch.Checked;
            settings.EnableSSLChkCertRevocation = cbxEnableSSLChkCertRevocation.Checked;
            settings.EnableSSLIgnIncompCertChain = cbxEnableSSLIgnIncompCertChain.Checked;
            settings.CertificateFilePath = tbxCertificateFilePath.Text;

            settings.Save();
            settings.Reload();
        }       
        
        #region Do connection

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // If there still be any invalid input, return
                if (!this.ValidateChildren())
                {
                    return;
                }

                UpdateConfig();

                // Set connecting status
                tbxInfo.Text = string.Format("Connecting...{0}", Environment.NewLine);
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = false;

                // Do connection in background 
                bwkConnect.RunWorkerAsync();
            }
            catch (System.Exception ex)
            {
                string strErrMessage = GetErrorMessage(ex);
                tbxInfo.Text = string.Format("Exception: {0}", strErrMessage);
            }
        }

        private void bwkConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            DoConnection();
        }

        /// <summary>
        /// Create and open connection
        /// </summary>
        private void DoConnection()
        {
            try
            {
            // Close current connection if exists
            DoDisconnection();

            con = GetU2Connection();
            con.Open();
        }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        /// <summary>
        /// Get an U2 connection object
        /// </summary>
        /// <returns></returns>
        private U2Connection GetU2Connection()
        {
            U2ConnectionStringBuilder conStr = new U2ConnectionStringBuilder();

            // Login settings
            conStr.UserID = settings.UserName;
            conStr.Password = settings.Password;
            conStr.Server = settings.Server;
            conStr.Database = settings.Database;
            conStr.ServerType = settings.ServerType;            

            conStr.Connect_Timeout = settings.ConnTimeOut;
            conStr.ConnectionLifeTime = settings.ConnLifeTime;

            // Access mode
            if (settings.AccessMode == "Native")
            {
                conStr.AccessMode = settings.AccessMode;
                if (conStr.ServerType == "UNIDATA")
                {
                    conStr.RpcServiceType = "udcs";
                }
                else
                {
                    conStr.RpcServiceType = "uvcs";
                }
            }
            else
            {
                // If not Native mode and set the property like bellow, an error occurred
                //conStr.AccessMode = "Uci"; // settings.AccessMode;
                //conStr.RpcServiceType = "defcs"; // settings.RpcServiceType;
            }

            // SSL settings
            conStr.SSLConnection = settings.EnableSSLConnection;
            if (conStr.SSLConnection == true)
            {
                conStr.SslIgnoreCertificateNameMismatch = settings.EnableSSLIgnCertNameMismatch;

                if (settings.CertificateFilePath.Length > 0)
                {
                    conStr.ClientCertificatePath = settings.CertificateFilePath;
                }
                conStr.SslIgnoreIncompleteCertificateChain = settings.EnableSSLIgnIncompCertChain;
                conStr.SslCheckCertificateRevocation = settings.EnableSSLChkCertRevocation;
            }

            U2Connection con = new U2Connection();
            con.ConnectionString = conStr.ToString();
            return con;
        }

        private void bwkConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string strInfo = string.Empty;
            if (e.Error != null)
            {
                strInfo = GetErrorMessage(e.Error);
                strInfo = string.Format(
                    "Create connection failed.{0}{0}Exception: {1}{0}Stack Trace:{2}",
                        Environment.NewLine,
                        strInfo,
                        e.Error.StackTrace
                    );

                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
            else
            {
                // determine whether need a secure symbol, if not, the symbol is empty
                string strSecureSymbol = settings.EnableSSLConnection == true ? "(Secure)" : string.Empty;

                strInfo = string.Format(
                    "{0} database server has been connected! {1}",
                    settings.ServerType,
                    strSecureSymbol);

                // enable disconnect button
                btnDisconnect.Enabled = true;
            }
            tbxInfo.Text = strInfo;
        }

        #endregion

        #region Do disconnection

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Set disconnecting status
            tbxInfo.Text = "Disconnecting...";
            btnDisconnect.Enabled = false;

            // Do disconnection in background
            bwkDisconnect.RunWorkerAsync();
        }

        private void bwkDisconnect_DoWork(object sender, DoWorkEventArgs e)
        {
            DoDisconnection();
        }

        /// <summary>
        /// Close active connection
        /// </summary>
        private void DoDisconnection()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }

        /// <summary>
        /// Select the certificate file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCertFileSelect_Click(object sender, EventArgs e)
        {
            if (fdlgSelectCertificate.ShowDialog(this)==DialogResult.OK)
            {
                tbxCertificateFilePath.Text = fdlgSelectCertificate.FileName;
            }
        }

        private void bwkDisconnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string strInfo = string.Empty;
            if (e.Error != null)
            {
                strInfo = string.Format(
                    "Disconnection failed.{0}{0}Exception: {1}",
                    Environment.NewLine,
                    e.Error.Message
                    );
            }
            else
            {
                strInfo = "Disconnected!";
            }
            tbxInfo.Text = strInfo;

            // Recheck the connection state
            if (con == null || con.State == ConnectionState.Closed)
            {
                // Reset button state
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
        }

        #endregion

        #region Validate input

        private void tbxServer_Validating(object sender, CancelEventArgs e)
        {
            if (tbxServer.Text.Trim().Length == 0)
            {
                MessageBox.Show("Server name is required.");
                e.Cancel = true;
            }
        }

        private void tbxDatabase_Validating(object sender, CancelEventArgs e)
        {
            if (tbxDatabase.Text.Trim().Length == 0)
            {
                MessageBox.Show("Database name is required.");
                e.Cancel = true;
            }
        }

        private void tbxUserName_Validating(object sender, CancelEventArgs e)
        {
            if (tbxUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("User name is required.");
                e.Cancel = true;
            }
        }

        private void tbxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbxPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Password is required.");
                e.Cancel = true;
            }
        }

        #endregion        

        private void rbtUniData_Click(object sender, EventArgs e)
        {
            
        }

        private void rbtUniVerse_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtUniVerse.Checked == true)
            {
                tbxDatabase.Text = "HS.SALES";
            }
        }

        private void rbtUniVerse_Click(object sender, EventArgs e)
        {

        }

        private void rbtUniData_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtUniData.Checked == true)
            {
                tbxDatabase.Text = "demo";
            }
        }

    }
}
