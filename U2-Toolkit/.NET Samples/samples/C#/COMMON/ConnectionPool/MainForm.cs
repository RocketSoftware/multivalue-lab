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
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ConnectionPool
{
    public partial class MainForm : Form
    {
        private static Properties.Settings settings = Properties.Settings.Default;

        /// <summary>
        /// Handler for initializing the local string builder
        /// </summary>
        private Func<StringBuilder> InitLocalCallbackHandler;

        /// <summary>
        /// Call back handler for thread action
        /// </summary>
        private Func<int, ParallelLoopState, StringBuilder, StringBuilder> ParallelThreadCallbackHandler; 
 
        /// <summary>
        /// Used to watch the main process
        /// </summary>
        private Stopwatch watcherMain = new Stopwatch();

        /// <summary>
        /// Used for manual close this form
        /// </summary>
        private int WM_CLOSE = 0x0010;

        /// <summary>
        /// Store the count value for successful thread action
        /// </summary>
        private int SUCCESS_COUNT = 0;

        /// <summary>
        /// Store the count value for failed thread action
        /// </summary>
        private int FAILED_COUNT = 0;

        public MainForm()
        {
            InitializeComponent();
            // To catch unexpected exception
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            InitLocalCallbackHandler = new Func<StringBuilder>(InitStatusStringBuilder_Callback);
            ParallelThreadCallbackHandler = new Func<int, ParallelLoopState, StringBuilder, StringBuilder>(ParallelRunDataObjects_Callback);
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
                // Manual exit without causing validate
                Application.Exit();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// Catch unexpected exception
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
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
                string strMessage = string.Format("Unexpected Exception: {0}", ex.Message);
                MessageBox.Show(strMessage);
            }
        }

        // Enable/Disable Pooling state
        private void cbxPooling_CheckedChanged(object sender, EventArgs e)
        {
            pnlPool.Enabled = cbxEnablePooling.Checked;
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

            // Repeat count
            ttpControls.SetToolTip(numUpDnRepeatCount, "Set repeat count for command running");

            // Pool
            ttpControls.SetToolTip(numUpDnMinPoolSize, "Set an integer value between 1 to 1000 to specify\r\n the minimum pooling size");
            ttpControls.SetToolTip(numUpDnMaxPoolSize, "Set an integer value between 1 to 1000 to specify\r\n the maximal pooling size");
            ttpControls.SetToolTip(numUpDnConnTimeout, "Set an integer value between 1 to 100000 to specify\r\n the period before throw a timeout error");
            ttpControls.SetToolTip(numUpDnLifetime, "Set an integer value between 1 to 100000 to specify\r\n the period that the connection is keeping active");

            // Parallel
            ttpControls.SetToolTip(numUpDnParallelMaxDegree, "Set an integer value between 1 to 1000 to specify\r\n the maximal parallel degree");
            ttpControls.SetToolTip(numUpDnThreadDelayTime, "Set an integer value between 0 to 100000 to specify\r\n the delay time for each thread");

            StringBuilder sb = new StringBuilder();
            sb.Append("Set the Command Text. For Example:" + Environment.NewLine);
            sb.Append("For Native Mode => LIST VOC SAMPLE 10" + Environment.NewLine);
            sb.Append("For SQL Mode    => SELECT * FROM CUSTOMER" + Environment.NewLine);
            ttpControls.SetToolTip(tbxCommandText, sb.ToString());
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

            // Data objects
            cbxCommand.Checked = settings.UseCommand;
            cbxDataReader.Checked = settings.UseDataReader;
            cbxDataSet.Checked = settings.UseDataSet;
            numUpDnRepeatCount.Value = settings.RepeatCount;
            tbxCommandText.Text = settings.CommandText;

            // Pool
            cbxEnablePooling.Checked = settings.EnablePooling;
            cbxEnableReset.Checked = settings.EnableConnReset;
            numUpDnMinPoolSize.Value = settings.MinPoolSize;
            numUpDnMaxPoolSize.Value = settings.MaxPoolSize;
            numUpDnConnTimeout.Value = settings.ConnTimeOut;
            numUpDnLifetime.Value = settings.ConnLifeTime;

            // Access mode
            string strAccessMode = settings.AccessMode;
            switch (strAccessMode)
            {
                case "Native":
                    rbtModeNative.Checked = true;
                    tbxCommandText.Text = "LIST VOC SAMPLE 10";
                    break;
                case "Uci":
                    rbtModeAdo.Checked = true;
                    tbxCommandText.Text = "SELECT * FROM CUSTOMER";
                    break;
                default:
                    rbtModeNative.Checked = true;
                    break;
            }

            // Parallel
            numUpDnParallelMaxDegree.Value = settings.PallelleMaxDegree;
            numUpDnThreadDelayTime.Value = settings.ThreadDelayTime;
        }

        /// <summary>
        /// Start running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                // If there still be any invalid input, not run
                if (!this.ValidateChildren())
                {
                    return;
                }

                UpdateConfig();

                // Reset running status
                tbxInfo.Text = string.Format("Running...{0}{0}", Environment.NewLine);
                btnCancel.Enabled = true;
                btnRun.Enabled = false;

                // Reset main watcher
                watcherMain.Reset();
                watcherMain.Start();

                // Start and execute command in background 
                bwkRun.RunWorkerAsync();
            }
            catch (System.Exception ex)
            {
                string strErrMessage = GetExceptionMessage(ex);
                strErrMessage = string.Format("Exception: {0}", strErrMessage);
                StringAppendAndSelect(strErrMessage);
            }
        }

        /// <summary>
        /// Update configuration
        /// </summary>
        private void UpdateConfig()
        {
            // Login
            settings.Server = tbxServer.Text.Trim();
            settings.Database = tbxDatabase.Text.Trim();
            settings.UserName = tbxUserName.Text.Trim();
            settings.Password = tbxPassword.Text.Trim();

            // Server type
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

            settings.UseCommand = cbxCommand.Checked;
            settings.UseDataReader = cbxDataReader.Checked;
            settings.UseDataSet = cbxDataSet.Checked;
            settings.RepeatCount = (int)numUpDnRepeatCount.Value;
            settings.CommandText = tbxCommandText.Text;

            // Pool
            settings.EnablePooling = cbxEnablePooling.Checked;
            settings.EnableConnReset = cbxEnableReset.Checked;
            settings.MinPoolSize = (int)numUpDnMinPoolSize.Value;
            settings.MaxPoolSize = (int)numUpDnMaxPoolSize.Value;
            
            settings.ConnTimeOut = (int)numUpDnConnTimeout.Value;
            settings.ConnLifeTime = (int)numUpDnLifetime.Value;

            settings.PallelleMaxDegree = (int)numUpDnParallelMaxDegree.Value;
            settings.ThreadDelayTime = (int)numUpDnThreadDelayTime.Value;

            settings.Save();
            settings.Reload();
        }
        /// <summary>
        /// Get an U2 connection object
        /// </summary>
        /// <returns></returns>
        private static U2Connection GetU2Connection()
        {
            U2ConnectionStringBuilder conStr = new U2ConnectionStringBuilder();

            // Login
            conStr.UserID = settings.UserName;
            conStr.Password = settings.Password;
            conStr.Server = settings.Server;
            conStr.Database = settings.Database;
            conStr.ServerType = settings.ServerType;

            // Pool
            conStr.Pooling = settings.EnablePooling;
            conStr.MinPoolSize = settings.MinPoolSize;
            conStr.MaxPoolSize = settings.MaxPoolSize;
            conStr.ConnectionReset = settings.EnableConnReset;
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

            U2Connection con = new U2Connection();
            con.ConnectionString = conStr.ToString();
            return con;
        }

        private void ExecuteCommand(U2Connection con)
        {
            try
            {
                if (settings.AccessMode=="Native")
                {
                    // Native mode
                    UniSession us1 = con.UniSession;
                    UniCommand uniCmd = us1.CreateUniCommand();
                    uniCmd.Command = settings.CommandText;
                    uniCmd.Execute();
                    // Get response string but not output
                    string strNative = uniCmd.Response;
                    
                }
                else
                {
                    // SQL mode
                    U2Command cmd = con.CreateCommand();
                    cmd.Connection = con;
                    cmd.CommandText = settings.CommandText;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        private void ExecuteDataReader(U2Connection con)
        {
            try
            {
                if (settings.AccessMode == "Native")
                {
                    // Need to confirm how to use UniDataSet
                }
                else
                {
                U2Command cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = settings.CommandText;
                U2DataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                        // Do something
                }
            }
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        private void ExecuteDataSet(U2Connection con)
        {
            try
            {
                if (settings.AccessMode == "Native")
                {
                    // Need to confirm how to use UniDataSet
                }
                else
                {
                U2Command cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = settings.CommandText;

                U2DataAdapter da = new U2DataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Run Command/DataReader/DataSet on U2 connection
        /// </summary>
        /// <param name="stepLabel"></param>
        /// <param name="threadID"></param>
        /// <returns></returns>
        private string RunDataObjectsOnPool(int stepLabel, int threadID)
        {
            string strInfo = string.Empty;
            Stopwatch watcher = new Stopwatch();
            watcher.Start();

            U2Connection con = null;
            try
            {
                // Thread delay, just for slowdown process 
                Thread.Sleep(settings.ThreadDelayTime);

                con = GetU2Connection();
                con.Open();
                
                if (settings.UseCommand)
                {
                    ExecuteCommand(con);
                }
                if (settings.UseDataReader)
                {
                    ExecuteDataReader(con);
                }
                if (settings.UseDataSet)
                {
                    ExecuteDataSet(con);
                }

                con.Close();

                watcher.Stop();

                strInfo = string.Format(
                        "[Success] Step symbol: {0} Thread ID: {1} Elapsed time: {2} ms{3}",
                        stepLabel,
                        threadID,
                        watcher.ElapsedMilliseconds,
                        Environment.NewLine
                    );
                SUCCESS_COUNT++;
            }
            catch (System.Exception ex)
            {
                strInfo = string.Format(
                    "[Failed] Step symbol: {0} Thread ID: {1} Elapsed Time: {2} ms{3} Error: {4}{3}{3}",
                    stepLabel,
                    threadID,
                    watcher.ElapsedMilliseconds,
                    Environment.NewLine,
                    ex.Message
                );
                FAILED_COUNT++;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return strInfo;
        }

        private void bwkRun_DoWork(object sender, DoWorkEventArgs e)
        {
            // Used to determine how many times the performance will be played
            int[] arr = Enumerable.Range(1, settings.RepeatCount).ToArray();

            ParallelOptions po = new ParallelOptions();
            po.MaxDegreeOfParallelism = settings.PallelleMaxDegree;
            
            int stepCount = 0;

            // Parallel 
            ParallelLoopResult paralResult=Parallel.ForEach(
                arr,
                po,
                InitLocalCallbackHandler,
                // Call back run connection and/or data objects
                ParallelThreadCallbackHandler,
                (info) =>
                {
                    // Progress percentage, reserved 
                    int percent = (stepCount++) * 100 / arr.Length;
                    bwkRun.ReportProgress(percent, info);
                }
            );

            // Determine whether the parallel action gets a cancel request
            e.Cancel=!paralResult.IsCompleted;
        }

        private StringBuilder InitStatusStringBuilder_Callback()
        {
            return new StringBuilder(); 
        }

        private StringBuilder ParallelRunDataObjects_Callback(int stepLabel, ParallelLoopState loopOption, StringBuilder info)
        {
            if (bwkRun.CancellationPending == true)
            {
                loopOption.Stop();   
            }
            else
            {
                int threadID = Thread.CurrentThread.ManagedThreadId;
                string strInfo = RunDataObjectsOnPool(stepLabel, threadID);
                info.Append(strInfo);
            }
            return info;
        }

        /// <summary>
        /// Append and select the new string segment on displaying area
        /// </summary>
        /// <param name="strInfo"></param>
        private void StringAppendAndSelect(string strInfo)
        {
            if (strInfo == null || strInfo == string.Empty)
            {
                return;
            }
            tbxInfo.Focus();
            int startIndex = tbxInfo.Text.Length;
            tbxInfo.Text += strInfo;
            tbxInfo.Select(startIndex, strInfo.Length);
            tbxInfo.ScrollToCaret();
        }

        private void bwkRun_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StringBuilder sbInfo = (StringBuilder)e.UserState;
            string strInfo = sbInfo.ToString();

            // Append status info to displaying area string
            StringAppendAndSelect(strInfo);
        }

        /// <summary>
        /// Send cancel request to background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                bwkRun.CancelAsync();
                btnCancel.Enabled = false;

                string strInfo = string.Format("{0}Cancelling...{0}{0}", Environment.NewLine);
                StringAppendAndSelect(strInfo);
            }
            catch (System.Exception ex)
            {
                string strErrMessage = GetExceptionMessage(ex);
                strErrMessage = string.Format("Exception: {0}", strErrMessage);
                StringAppendAndSelect(strErrMessage);
            }
        }

        private void bwkRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string strInfo = string.Empty;
            watcherMain.Stop();
            strInfo = string.Format(
                    "{0}Success: {1}  Failed: {2}  Main thread elapsed time: {3} ms{0}",
                    Environment.NewLine,
                    SUCCESS_COUNT,
                    FAILED_COUNT,
                    watcherMain.ElapsedMilliseconds
                );

            if (e.Cancelled == true)
            {
                strInfo = string.Format("{0}Cancelled.", strInfo);
            }
            else
            {
                strInfo = string.Format("{0}Completed.", strInfo);
            }

            StringAppendAndSelect(strInfo);

            // Reset states
            btnRun.Enabled = true;
            btnCancel.Enabled = false;
            SUCCESS_COUNT = 0;
            FAILED_COUNT = 0;
        }

        #region Validate input

        private bool IsCommandTextValid()
        {
            // Determine whether the command text is required
            // If one of check boxes Command/DataReader/DataSet checked, it is required
            if (cbxCommand.Checked | cbxDataReader.Checked | cbxDataSet.Checked)
            {
                return (tbxCommandText.Text.Trim().Length > 0);
            }
            return true;
        }

        private bool IsMaxPoolSizeValid()
        {
            // Determine whether the max pool size is equal or lager than 
            // the min pool size
            if ((int)numUpDnMaxPoolSize.Value >= (int)numUpDnMinPoolSize.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void tbxCommandText_Validating(object sender, CancelEventArgs e)
        {
            if (IsCommandTextValid() == false)
            {
                MessageBox.Show("Command text is required.");
                e.Cancel = true;
            }
        }

        private void tbxMaxPoolSize_Validating(object sender, CancelEventArgs e)
        {
            if (IsMaxPoolSizeValid() == false)
            {
                MessageBox.Show("Max pool size should be a positive integer, and equal or larger than min pool size.");
                e.Cancel = true;
            }
        }

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

        private void numUpDnMaxPoolSize_Validating(object sender, CancelEventArgs e)
        {
            if (IsMaxPoolSizeValid() == false)
            {
                MessageBox.Show("Max pool size should be equal or larger than min pool size.");
                e.Cancel = true;
            }
        }

        #endregion        

        private void rbtModeNative_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtModeNative.Checked == true)
            {
                tbxCommandText.Text = "LIST VOC SAMPLE 10";
            }

        }

        private void rbtModeAdo_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtModeAdo.Checked == true)
            {
                tbxCommandText.Text = "SELECT * FROM CUSTOMER";
            }


        }

        private void rbtUniVerse_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtUniVerse.Checked == true)
            {
                tbxDatabase.Text = "HS.SALES";
            }
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
