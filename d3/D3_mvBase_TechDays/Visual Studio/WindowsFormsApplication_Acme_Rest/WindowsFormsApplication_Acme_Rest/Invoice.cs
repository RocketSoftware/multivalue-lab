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
    public partial class Invoice : Form
    {
        public Invoice(String InvoiceSelection)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen; //center form

            this.FormClosing += Invoice_FormClosing; // set close event

            // Create the web request  
            string uri = "http://den-vm-dg02:8181/Invoices/getInvoice?INVOICE_NO="; // substitute with your host path. You may want to read this in from a config file (not hardcoded)
            uri = uri + InvoiceSelection;

            using (WebClient webClient = new System.Net.WebClient())
            {
                WebClient n = new WebClient();
                var json = n.DownloadString(uri);
                JObject jObj = (JObject)JsonConvert.DeserializeObject(json);

                AccountNo.Text =jObj.SelectToken("getInvoice.INVOICE_ITEM.custAccount").ToString();
                BillTo.Text =   jObj.SelectToken("getInvoice.INVOICE_ITEM.billtoCompanyName").ToString();
                BillAddr.Text = jObj.SelectToken("getInvoice.INVOICE_ITEM.billtoAddress").ToString();

                var BillCity =  jObj.SelectToken("getInvoice.INVOICE_ITEM.billtoCity").ToString();
                var BillState = jObj.SelectToken("getInvoice.INVOICE_ITEM.billtoState").ToString();
                var BillZip =   jObj.SelectToken("getInvoice.INVOICE_ITEM.billtoZip").ToString();
                Bill_CityStateZip.Text = BillCity + ", " + BillState + " " + BillZip;

                Contact.Text =  jObj.SelectToken("getInvoice.INVOICE_ITEM.billtoContactName").ToString();
                InvoiceNo.Text =jObj.SelectToken("getInvoice.INVOICE_ITEM.invoiceNo").ToString();
                ShipTo.Text =   jObj.SelectToken("getInvoice.INVOICE_ITEM.shiptoName").ToString();
                ShipAddr.Text = jObj.SelectToken("getInvoice.INVOICE_ITEM.shiptoAddress").ToString();

                var ShipCity =  jObj.SelectToken("getInvoice.INVOICE_ITEM.shiptoCity").ToString();
                var ShipState = jObj.SelectToken("getInvoice.INVOICE_ITEM.shiptoState").ToString();
                var ShipZip =   jObj.SelectToken("getInvoice.INVOICE_ITEM.shiptoZip").ToString();
                Ship_CityStateZip.Text = ShipCity + ", " + ShipState + " " + ShipZip;

                SalesRep.Text = jObj.SelectToken("getInvoice.INVOICE_ITEM.salesRepName").ToString();
                RepPhone.Text = jObj.SelectToken("getInvoice.INVOICE_ITEM.salesRepPhone").ToString();
                Ordered.Text =  jObj.SelectToken("getInvoice.INVOICE_ITEM.orderDate").ToString();
                Invoiced.Text = jObj.SelectToken("getInvoice.INVOICE_ITEM.invoiceDate").ToString();
                Terms.Text =    jObj.SelectToken("getInvoice.INVOICE_ITEM.terms").ToString();
                Note.Text =     jObj.SelectToken("getInvoice.INVOICE_ITEM.comment").ToString();
                Gross.Text =    jObj.SelectToken("getInvoice.INVOICE_ITEM.invoiceGross").ToString();
                Discount.Text = jObj.SelectToken("getInvoice.INVOICE_ITEM.invoiceDiscount").ToString();
                Net.Text =      jObj.SelectToken("getInvoice.INVOICE_ITEM.invoiceNet").ToString();

                // Get Each Line Item
                IList<JToken> Lineresults = jObj["getInvoice"]["INVOICE_ITEM"]["line"].Children().ToList(); //Here don't see ToList()
                int Linecount = Lineresults.Count;

                for (int i = 0; i < Linecount; i++)
                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i].Cells[0].Value = i+1;
                     dataGridView1.Rows[i].Cells[1].Value = (Lineresults[i].SelectToken("lineQty"));
                     dataGridView1.Rows[i].Cells[2].Value = (Lineresults[i].SelectToken("lineProductNo"));
                     dataGridView1.Rows[i].Cells[3].Value = (Lineresults[i].SelectToken("lineDescription"));
                     dataGridView1.Rows[i].Cells[4].Value = (Lineresults[i].SelectToken("lineUnitPrice"));
                     dataGridView1.Rows[i].Cells[5].Value = (Lineresults[i].SelectToken("lineGross"));
                     dataGridView1.Rows[i].Cells[6].Value = (Lineresults[i].SelectToken("lineDiscount"));
                     dataGridView1.Rows[i].Cells[7].Value = (Lineresults[i].SelectToken("lineExtNet"));

                }
        }
        }

        private void Invoice_Load(object sender, EventArgs e)
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

        private void Invoice_FormClosing(Object sender, FormClosingEventArgs e)
        {

            this.Dispose();
        }
    }
}
