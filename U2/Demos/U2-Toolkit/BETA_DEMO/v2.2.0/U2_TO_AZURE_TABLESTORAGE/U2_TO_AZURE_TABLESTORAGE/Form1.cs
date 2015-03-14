using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using U2.Data.Client;

namespace U2_TO_AZURE_TABLESTORAGE
{
    public partial class Form1 : Form
    {
        string accountName = "mykey";

        string accountKey = "mypass";
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.AppendText("Start..." + Environment.NewLine);

                //strat get U2 data

                U2ConnectionStringBuilder conn_bldr = new U2ConnectionStringBuilder();
                conn_bldr.UserID = "admin";
                conn_bldr.Password = "**";
                conn_bldr.Server = "192.168.102.132";
                conn_bldr.ServerType = "universe";
                conn_bldr.Database = "HS.SALES";
                conn_bldr.AccessMode = "Native";
                conn_bldr.RpcServiceType = "uvcs";
                string lConnStr = conn_bldr.ConnectionString;
                U2Connection lConn = new U2Connection();
                lConn.ConnectionString = lConnStr;
                lConn.Open();
                Console.WriteLine("Connected...");
                U2Command cmd = lConn.CreateCommand();

                // CUSTID,FNAME,LNAME : Single Value
                //PRODID, BUY_DATE    : Multi Value
                //Syntax : Action=?;File=?;Attributes=?;Where=?;Sort

                cmd.CommandText = string.Format("Action=Select;File=CUSTOMER;Attributes=CUSTID,FNAME,LNAME,PRODID,BUY_DATE;Where=CUSTID>0;Sort=CUSTID");

                U2DataAdapter da = new U2DataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];

                //end get U2 data

                //load table storage
                string lTableStorageName = "CUSTOMER3";
                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                CloudTableClient client = account.CreateCloudTableClient();
                CloudTable table = client.GetTableReference("CUSTOMER6");
                table.CreateIfNotExists();
                string lUri = table.Uri.ToString();
                //  Console.WriteLine(table.Uri.ToString());
                this.textBox1.AppendText(lUri + Environment.NewLine);
                foreach (DataRow item in dt.Rows)
                {
                    var t1 = item["CUSTID"].ToString();
                    var t2 = item["Z_MV_KEY"].ToString();
                    DateTime lhiredate;
                    if (item["BUY_DATE"] == DBNull.Value)
                    {
                        lhiredate = DateTime.Now;// new DateTime();
                    }
                    else
                    {
                        lhiredate = (DateTime)item["BUY_DATE"];
                    }
                    CustomerEntity entity = new CustomerEntity(t1,t2)
                    {
                        FNAME = (string)item["FNAME"],
                        LNAME = (string)item["LNAME"],
                        PRODID = (string)item["PRODID"],
                        BUY_DATE = lhiredate
                    };
                    TableOperation insertOperation = TableOperation.InsertOrReplace(entity);
                    table.Execute(insertOperation);
                    this.textBox1.AppendText("Entity inserted!" + Environment.NewLine);
                }
                this.textBox1.AppendText("End..." + Environment.NewLine);
            }

            catch (Exception ex)
            {

                this.textBox1.AppendText(ex.Message + Environment.NewLine);

            }

        }
    }
}
