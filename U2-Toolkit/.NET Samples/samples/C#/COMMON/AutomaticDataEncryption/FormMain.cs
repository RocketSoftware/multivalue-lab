using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using U2.Data.Client;
using U2.Data.Client.UO;

namespace WalletConnection
{
    public partial class FormMain : Form
    {
        private Properties.Settings settings=Properties.Settings.Default;

        /// <summary>
        /// Used for manual close this form
        /// </summary>
        private int WM_CLOSE = 0x0010;

        public FormMain()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            InitializeComponent();
        }

        /// <summary>
        /// Get current and inner exception message
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string GetExceptionMessage(Exception ex)
        {
            StringBuilder sbMessage = new StringBuilder();
            while (ex != null)
            {
                sbMessage.AppendFormat("{0}{1}", ex.Message, Environment.NewLine);
                ex = ex.InnerException;
            }
            return sbMessage.ToString();
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

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                StringBuilder sbMessage = new StringBuilder();
                string strErrMessage = GetExceptionMessage(e.Exception);
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

            // ADE
            ttpControls.SetToolTip(tbxFileName, "Set the name of encrypted file you want to retrieve");
            ttpControls.SetToolTip(tbxWalletID, "Set the wallet key name");
            ttpControls.SetToolTip(tbxWalletPassword, "Set the wallet password");
        }

        private void ADETest_Load(object sender, EventArgs e)
        {
            SetToolTip();

            // Reload history configuration
            tbxServer.Text = settings.Server;
            tbxDatabase.Text = settings.Database;
            tbxUserName.Text = settings.UserName;
            tbxPassword.Text = settings.Password;

            // Wallet 
            tbxFileName.Text = settings.FileName;
            tbxWalletID.Text = settings.WalletID;
            tbxWalletPassword.Text = settings.WalletPassword;

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

        private DataGridViewColumnCollection CreateColumn(DataColumnCollection clms,DataGridView grdv)
        {
            DataGridViewColumnCollection clmsNew = new DataGridViewColumnCollection(grdv);
            foreach (DataColumn col in clms)
            {
                DataGridViewColumn grdcol = new DataGridViewColumn();
                grdcol.HeaderText = col.ColumnName;
                clmsNew.Add(grdcol);
            }
            
            return clmsNew;
        }

        /// <summary>
        /// Update configuration
        /// </summary>
        private void UpdateConfig()
        {
            // Login info
            settings.Server = tbxServer.Text.Trim();
            settings.Database = tbxDatabase.Text.Trim();
            settings.UserName = tbxUserName.Text.Trim();
            settings.Password = tbxPassword.Text.Trim();

            settings.FileName = tbxFileName.Text.Trim();
            settings.WalletID = tbxWalletID.Text.Trim();
            settings.WalletPassword = tbxWalletPassword.Text.Trim();

            if (rbtUniData.Checked == true)
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
            if (rbtModeNative.Checked == true)
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

            settings.Save();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                // If there still be any invalid input, return
                if (!this.ValidateChildren())
                {
                    return;
                }
                UpdateConfig();
                btnRetrieve.Enabled = false;
                grdDataList.DataSource = null;
                tbxInfo.Text = string.Empty;

                string strInfo = string.Format("Retrieving......{0}{0}", Environment.NewLine);
                StringAppendAndSelect(strInfo);

                //Background run
                bwkRetrieve.RunWorkerAsync();
            }
            catch (System.Exception ex)
            {
                string strErrMessage = GetExceptionMessage(ex);
                strErrMessage= string.Format("Exception: {0}", strErrMessage);
                StringAppendAndSelect(strErrMessage);
            }
        }

        private void bwkRetrieve_DoWork(object sender, DoWorkEventArgs e)
        {
            U2ConnectionStringBuilder conStr = new U2ConnectionStringBuilder();
            conStr.UserID = settings.UserName;
            conStr.Password = settings.Password;
            conStr.Server = settings.Server;
            conStr.Database = settings.Database;
            conStr.ServerType = settings.ServerType;

            // Wallet
            conStr.WalletID = settings.WalletID;
            conStr.WalletPwd = settings.WalletPassword;

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
                e.Result = GetNativeString(conStr, settings.FileName);
            }
            else
            {
                e.Result=GetSQLDataSet(conStr, settings.FileName);
            }
        }

        /// <summary>
        /// Get dataset in SQL mode
        /// </summary>
        /// <param name="conStrBdr"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        private DataSet GetSQLDataSet(U2ConnectionStringBuilder conStrBdr, string strTableName)
        {
            try
            {
            U2Connection con = new U2Connection();
            con.ConnectionString = conStrBdr.ToString();

            con.Open();

            U2Command cmd = con.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM [{0}]", strTableName);
            U2DataAdapter da = new U2DataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();            
            da.Fill(ds);

            con.Close();
            return ds;
        }
            catch (Exception e)
            {

                throw  e ;
            }
           
        }

        /// <summary>
        /// Get native string in Native mode
        /// </summary>
        /// <param name="conStrBdr"></param>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        private string GetNativeString(U2ConnectionStringBuilder conStrBdr, string strFileName)
        {
            try
            {
            U2Connection con = new U2Connection();
            con.ConnectionString = conStrBdr.ToString();
            con.Open();

            string strInfo = string.Format("Connected......{0}{0}",Environment.NewLine);
            // 0 is meaningless
            bwkRetrieve.ReportProgress(0, strInfo);
            string strNative = string.Empty;
            UniSession us1 = con.UniSession;
            UniCommand cmd = us1.CreateUniCommand();

            // List no more than 10 records for sample
            if (conStrBdr.ServerType=="UNIDATA")
            {
                cmd.Command = string.Format("LIST {0} ALL SAMPLE 10", strFileName);
            }
            else
            {
                cmd.Command = string.Format("LIST {0} SAMPLE 10", strFileName);
            }
            cmd.Execute();
            
            if (cmd.Response != null)
            {
                strNative = cmd.Response.Trim();
            }
                        
            con.Close();
            return strNative;
        }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        private void bwkRetrieve_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRetrieve.Enabled = true;
            if (e.Error != null)
            {
                string strErrMessage = GetExceptionMessage(e.Error);
                tbxInfo.Text = string.Format(
                        "Retrieve Failed.{0}{0}Exception: {1}{0}Stack Trace:{2}",
                        Environment.NewLine,
                        strErrMessage,
                        e.Error.StackTrace
                    );
            }
            else
            {
                if (e.Result is string)
                {
                    // Native result
                    string strNative = (string)e.Result;
                    StringAppendAndSelect(strNative);
                    string strEnd = string.Format("{0}{0}End.", Environment.NewLine);
                    StringAppendAndSelect(strEnd);
                }
                else if (e.Result is DataSet)
                {
                    // SQL result
                    DataSet ds = (DataSet)e.Result;
                    if (ds.Tables.Count > 0)
                    {
                        grdDataList.DataSource = ds.Tables[0];
                        int rowCount = ds.Tables[0].Rows.Count;
                        tbxInfo.Text = string.Format("Data count {0}", rowCount);
                    }
                    else
                    {
                        grdDataList.DataSource = null;
                        tbxInfo.Text = "No data table found.";
                    }
                }
            }
        }

        private void bwkRetrieve_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string strInfo = e.UserState as string;
            if (strInfo!=null)
            {
                StringAppendAndSelect(strInfo);
            }
        }

        /// <summary>
        /// Append and select the new string segment on displaying area
        /// </summary>
        /// <param name="strInfo"></param>
        private void StringAppendAndSelect(string strInfo)
        {
            if (strInfo==null||strInfo==string.Empty)
            {
                return;
            }
            int startIndex = tbxInfo.Text.Length;
            tbxInfo.Text += strInfo;
            tbxInfo.Select(startIndex, strInfo.Length);
            tbxInfo.ScrollToCaret();
        }

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

        private void tbxFileName_Validating(object sender, CancelEventArgs e)
        {
            if (tbxFileName.Text.Trim().Length == 0)
            {
                MessageBox.Show("File/Table name is required.");
                e.Cancel = true;
            }
        }

        private void tbxWalletID_Validating(object sender, CancelEventArgs e)
        {
            if (tbxWalletID.Text.Trim().Length == 0)
            {
                MessageBox.Show("Wallet ID is required.");
                e.Cancel = true;
            }
        }

        private void tbxWalletPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbxWalletPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Wallet password is required.");
                e.Cancel = true;
            }
        }

        #endregion
    }
}
