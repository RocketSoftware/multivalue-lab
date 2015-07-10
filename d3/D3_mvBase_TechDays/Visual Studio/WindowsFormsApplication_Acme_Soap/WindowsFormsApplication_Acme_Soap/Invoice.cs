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
using System.Xml;

namespace WindowsFormsApplication_Acme_Soap
{
    public partial class Invoice : Form
    {
        public Invoice(String InvoiceSelection)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen; //center form

            this.FormClosing += Invoice_FormClosing; // set close event

            // Create the web request  
            string uri = "http://den-vm-dg02:8181/Invoices_Soap/getInvoice?INVOICE_NO="; // substitute with your host path. You may want to read this in from a config file (not hardcoded)
            uri = uri + InvoiceSelection;

            //declare variables
            var ElementCount = 0;
            var LN_Count = 0;

            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.Load(uri);

            XmlNodeList Acctno = xmlDocument.GetElementsByTagName("custAccount");
            AccountNo.Text = Acctno[0].InnerText;

            XmlNodeList BillCo = xmlDocument.GetElementsByTagName("billtoCompanyName");
            BillTo.Text = BillCo[0].InnerText;

            XmlNodeList BillAddress = xmlDocument.GetElementsByTagName("billtoAddress");
            BillAddr.Text = BillAddress[0].InnerText;

            XmlNodeList BillCity = xmlDocument.GetElementsByTagName("billtoCity");
            XmlNodeList BillState = xmlDocument.GetElementsByTagName("billtoSate");
            XmlNodeList BillZip = xmlDocument.GetElementsByTagName("billtoZip");
            Bill_CityStateZip.Text = BillCity[0].InnerText + ", " + BillState[0].InnerText + " " + BillZip[0].InnerText;

            XmlNodeList CustContact = xmlDocument.GetElementsByTagName("billtoContactName");
            Contact.Text = CustContact[0].InnerText;

            XmlNodeList Invoice_No = xmlDocument.GetElementsByTagName("invoiceNo");
            InvoiceNo.Text = Invoice_No[0].InnerText;

            XmlNodeList ShipToName = xmlDocument.GetElementsByTagName("shiptoName");
            ShipTo.Text = ShipToName[0].InnerText;

            XmlNodeList ShipAddress = xmlDocument.GetElementsByTagName("shiptoAddress");
            ShipAddr.Text = ShipAddress[0].InnerText;

            XmlNodeList ShipCity = xmlDocument.GetElementsByTagName("shiptoCity");
            XmlNodeList ShipState = xmlDocument.GetElementsByTagName("shiptoState");
            XmlNodeList ShipZip = xmlDocument.GetElementsByTagName("shiptoZip");
            Ship_CityStateZip.Text = ShipCity[0].InnerText + ", " + ShipState[0].InnerText + " " + ShipZip[0].InnerText;

            XmlNodeList SalesRepName = xmlDocument.GetElementsByTagName("salesRepName");
            SalesRep.Text = SalesRepName[0].InnerText;

            XmlNodeList SalesRepPhone = xmlDocument.GetElementsByTagName("salesRepPhone");
            RepPhone.Text = SalesRepPhone[0].InnerText;

            XmlNodeList Order_date = xmlDocument.GetElementsByTagName("orderDate");
            Ordered.Text = Order_date[0].InnerText;

            XmlNodeList Invoice_date = xmlDocument.GetElementsByTagName("invoiceDate");
            Invoiced.Text = Invoice_date[0].InnerText;

            XmlNodeList terms = xmlDocument.GetElementsByTagName("terms");
            Terms.Text = terms[0].InnerText;

            XmlNodeList Comments = xmlDocument.GetElementsByTagName("comment");
            Note.Text = Comments[0].InnerText;

            XmlNodeList InvoiceGross = xmlDocument.GetElementsByTagName("invoiceGross");
            Gross.Text = InvoiceGross[0].InnerText;

            XmlNodeList InvoiceDiscount = xmlDocument.GetElementsByTagName("invoiceDiscount");
            Discount.Text = InvoiceDiscount[0].InnerText;

            XmlNodeList InvoiceNet = xmlDocument.GetElementsByTagName("invoiceNet");
            Net.Text = InvoiceNet[0].InnerText;

            //Loop to get lines

            XmlNodeList elemList = xmlDocument.GetElementsByTagName("line");

            // Multidimensional array                
            string[,] Lines = new string[elemList.Count, 8]; //must know how many child membersto declare array

            for (int i = 0; i < elemList.Count; i++)
            {
                ElementCount = 0;
                LN_Count++;

                foreach (XmlNode chldNode in elemList[i].ChildNodes)
                {
                    if (ElementCount == 0)
                    {
                        ElementCount++;
                        Lines[i, 0] = LN_Count.ToString();
                    }
                    Lines[i, ElementCount] = chldNode.InnerText;
                    ElementCount++;

                }

            }


            int ArrayCols = 8;
            for (int i = 0; i != elemList.Count; i++)
            {
                for (int j = 0; j != ArrayCols; j++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[j].Value = Lines[i, j];

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
