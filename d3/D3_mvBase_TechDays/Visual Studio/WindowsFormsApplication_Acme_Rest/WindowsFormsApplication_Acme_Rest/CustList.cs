using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web; // provides library for executing Web Service calls
using Newtonsoft.Json; // download and add NewtonSoft to make Json parsing easier
using Newtonsoft.Json.Linq; // download and add NewtonSoft to make Json parsing easier

namespace WindowsFormsApplication_Acme_Rest
{
    public partial class CustList : Form
    {   private int rowIndex = 0;

        public CustList(String[] Selection)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; //center form
            this.FormClosing += CustList_FormClosing; // set close event

            String uri = "http://den-vm-dg02:8181"; // substitute with your host path. You may want to read this in from a config file (not hardcoded)
            uri = uri + "/Invoices";
            uri = uri + "/getCustList";
            uri = uri + "?NAMES=" + Uri.EscapeDataString(Selection[0]); //encodes to handles spaces, etc. in the Name
            uri = uri + "&ADDRS=" + Uri.EscapeDataString(Selection[1]); // endodes to handle spaces, etc. in the Address
            uri = uri + "&PHONE=" + Selection[2];
            uri = uri + "&STERR=" + Selection[3];
          
            using (WebClient webClient = new System.Net.WebClient()) // uses the system.web library declared previously
            {
                WebClient n = new WebClient();
                var json = n.DownloadString(uri);
                JObject jObj = (JObject)JsonConvert.DeserializeObject(json);

                // Get Each Customer
                IList<JToken> Custresults = jObj["getCustList"]["CUSTLIST"]["foundCustomers"].Children().ToList(); 
                int Custcount = Custresults.Count;

                for (int i = 0; i < Custcount; i++)
                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i].Cells[0].Value = (Custresults[i].SelectToken("foundAcctNo"));
                    dataGridView1.Rows[i].Cells[1].Value = (Custresults[i].SelectToken("foundName"));
                    dataGridView1.Rows[i].Cells[2].Value = (Custresults[i].SelectToken("foundAddress"));
                    dataGridView1.Rows[i].Cells[3].Value = (Custresults[i].SelectToken("foundCity"));
                    dataGridView1.Rows[i].Cells[4].Value = (Custresults[i].SelectToken("foundState"));
                    dataGridView1.Rows[i].Cells[5].Value = (Custresults[i].SelectToken("foundZip"));
                    dataGridView1.Rows[i].Cells[6].Value = (Custresults[i].SelectToken("foundPhone"));

                }
                
            }
        }

//*********************************************events and sub routines*********************************************************************
        private void NewSearch_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
            CustSearchFormProvider.custsearch.Show();
            
        }

        private void CustList_FormClosing(Object sender, FormClosingEventArgs e)
        {

            this.Dispose();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex != 0)
            {
                int currentRow = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.CurrentCell = dataGridView1[0, currentRow];
            }


            string AcctSelection = dataGridView1.CurrentCell.Value.ToString();
            Invoices frm2 = new Invoices(AcctSelection);

            frm2.Show();

        }

        private void Add_Row_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            Add_Row.Visible = false;
            Insert.Visible = true;
            int row = dataGridView1.RowCount;
            dataGridView1.CurrentCell = dataGridView1[0, row -1]; // force cursor to newly added row
            this.dataGridView1.ReadOnly = false; // set grid to allow editing
            dataGridView1.BeginEdit(true);
        }

       
        private void Insert_Row(object sender, EventArgs e)
        {
            this.dataGridView1.ReadOnly = true; // MAKE SURE WE RETURN THE GRID TO READ ONLY
            int Itemrow = dataGridView1.RowCount -1; // Make sure we are on the new insert row

            System.Net.ServicePointManager.Expect100Continue = false;
            // build the string for the Web Service
            String uri = "http://den-vm-dg02:8181"; // substitute with your host path. You may want to read this in from a config file (not hardcoded)
            uri = uri + "/Invoices";
            uri = uri + "/writecustitem";

            string datastring = "{"+ '"' + "CUSTID" + '"'+ ':' + '"' + dataGridView1.Rows[Itemrow].Cells[0].Value.ToString() + '"' + ',';
            datastring = datastring + '"' + "NAME" + '"' + ':' + '"' + dataGridView1.Rows[Itemrow].Cells[1].Value.ToString() + '"' + ',';
            datastring = datastring + '"' + "ADDR" + '"' + ':' + '"' + dataGridView1.Rows[Itemrow].Cells[2].Value.ToString() + '"' + ',';
            datastring = datastring + '"' + "CITY" + '"' + ':' + '"' + dataGridView1.Rows[Itemrow].Cells[3].Value.ToString() + '"' + ',';
            datastring = datastring + '"' + "STATE" + '"' + ':' + '"' + dataGridView1.Rows[Itemrow].Cells[4].Value.ToString() + '"' + ',';
            datastring = datastring + '"' + "ZIP" + '"' + ':' + '"' + dataGridView1.Rows[Itemrow].Cells[5].Value.ToString() + '"' + ',';
            datastring = datastring + '"' + "PHONE" + '"' + ':' + '"' + dataGridView1.Rows[Itemrow].Cells[6].Value.ToString() + '"';
            datastring = datastring + "}";
           

            using (WebClient webClient = new System.Net.WebClient())
            {
                WebClient n = new WebClient();
                n.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var json = n.UploadString(uri, "POST", datastring);  //this is how you would do a POST. 
                JObject jObj = (JObject)JsonConvert.DeserializeObject(json);
                Add_Row.Visible = true; // swap the displayed buttons
                Insert.Visible = false;
                
                
            }
        }

        private void ContextStrip_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {
                //Prepare to call the subroutine that deletes customer
                string ItemID = dataGridView1.Rows[this.rowIndex].Cells[0].Value.ToString(); //get CustomerID
                this.dataGridView1.Rows.RemoveAt(this.rowIndex);

                Add_Row.Visible = true; // swap the displayed buttons
                Insert.Visible = false;
                // build the string for the Web Service
                String uri = "http://den-vm-dg02:8181"; // substitute with your host path. You may want to read this in from a config file (not hardcoded)
                uri = uri + "/Invoices";
                uri = uri + "/delete_cust_item";
                uri = uri + "?CUSTID=" + ItemID; //get CustomerID

                string encoded_uri = Uri.EscapeUriString(uri); // Escape the url for spaces and VMs

                using (WebClient webClient = new System.Net.WebClient())
                {
                    WebClient n = new WebClient();
                    var json = n.DownloadString(encoded_uri);
                    JObject jObj = (JObject)JsonConvert.DeserializeObject(json);
                    Add_Row.Visible = true; // swap the displayed buttons
                    Insert.Visible = false;
                }
            }
        }

        private void datagricellmouse_up(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }        

    }
}
