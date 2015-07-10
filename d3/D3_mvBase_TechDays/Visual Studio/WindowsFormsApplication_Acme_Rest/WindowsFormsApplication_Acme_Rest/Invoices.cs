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
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApplication_Acme_Rest
{
    public partial class Invoices : Form
    {
        public Invoices(String AcctSelection)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen; //center form

            this.FormClosing += Invoices_FormClosing; // set close event

            // Create the web request  
            string uri = "http://den-vm-dg02:8181/Invoices/getInvoiceList?CUST_ACCT="; // substitute with your host path. You may want to read this in from a config file (not hardcoded)
            uri = uri + AcctSelection;

            using (WebClient webClient = new System.Net.WebClient())
            {
                WebClient n = new WebClient();
                var json = n.DownloadString(uri);
                JObject jObj = (JObject)JsonConvert.DeserializeObject(json);

                string CustName = jObj["getInvoiceList"]["INVOICE_LIST"]["custName"].ToString();
                label1.Text = "Invoices for Customer: " + CustName; // assign the customer name to the custmer name display

                 // Get all invoices for Customer
                IList<JToken> Invoicesresults = jObj["getInvoiceList"]["INVOICE_LIST"]["invoice"].Children().ToList(); 
                int Invoicecount = Invoicesresults.Count;

                for (int i = 0; i < Invoicecount; i++)
                {
                     dataGridView2.Rows.Add();

                     dataGridView2.Rows[i].Cells[0].Value = (Invoicesresults[i].SelectToken("invoiceNo"));
                     dataGridView2.Rows[i].Cells[1].Value = (Invoicesresults[i].SelectToken("invoiceDate"));
                     dataGridView2.Rows[i].Cells[2].Value = (Invoicesresults[i].SelectToken("orderDate"));
                     dataGridView2.Rows[i].Cells[3].Value = (Invoicesresults[i].SelectToken("salesRep"));
                     dataGridView2.Rows[i].Cells[4].Value = (Invoicesresults[i].SelectToken("terms"));
                     dataGridView2.Rows[i].Cells[5].Value = (Invoicesresults[i].SelectToken("totalGross"));
                     dataGridView2.Rows[i].Cells[6].Value = (Invoicesresults[i].SelectToken("totalDiscount"));
                     dataGridView2.Rows[i].Cells[7].Value = (Invoicesresults[i].SelectToken("totalNet"));
                     dataGridView2.Rows[i].Cells[8].Value = (Invoicesresults[i].SelectToken("InvoiceComments"));

                }
        }
            }


        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void NewSearch_Click(object sender, System.EventArgs e)
        {
            CustSearchFormProvider.custsearch.Show();

            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "CustomerSearch")
                    f.Close();
            }
            
        }

        private void Invoices_FormClosing(Object sender, FormClosingEventArgs e)
        {

            this.Dispose();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string InvoiceSelection = dataGridView2.CurrentCell.Value.ToString();
            Invoice frm2 = new Invoice(InvoiceSelection);

            frm2.Show();

        }


    }
}
