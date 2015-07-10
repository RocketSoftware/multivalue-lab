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
    public partial class Invoices : Form
    {
        public Invoices(String AcctSelection)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen; //center form

            this.FormClosing += Invoices_FormClosing; // set close event

            // Create the web request  
            string uri = "http://den-vm-dg02:8181/Invoices_Soap/getInvoiceList?CUST_ACCT="; // substitute with your host path. You may want to read this in from a config file (not hardcoded)
            uri = uri + AcctSelection;


            var ElementCount = 0;
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.Load(uri);
            XmlNodeList InvoicesList = xmlDocument.GetElementsByTagName("custName");
            String CustName = InvoicesList[0].InnerText;
            label1.Text = "Invoices for Customer: " + CustName; // assign the customer name to the custmer name display

            XmlNodeList elemList = xmlDocument.GetElementsByTagName("invoice");

            // Multidimensional array                
            string[,] Invoices = new string[elemList.Count, 9];

            for (int i = 0; i < elemList.Count; i++)
            {
                ElementCount = 0;
                foreach (XmlNode chldNode in elemList[i].ChildNodes)
                {
                    Invoices[i, ElementCount] = chldNode.InnerText;
                    ElementCount++;

                }

            }


            int ArrayCols = 9;
            for (int i = 0; i != elemList.Count; i++)
            {
                for (int j = 0; j != ArrayCols; j++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[j].Value = Invoices[i, j];

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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        }
    }
