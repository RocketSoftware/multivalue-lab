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
using System.Web; // need library to make SOAP Web Service Calls
using System.Xml; // Need Library to parse XML

namespace WindowsFormsApplication_Acme_Soap
{
    public partial class CustList : Form
    { 
        private int rowIndex = 0;

        public CustList(String[] Selection)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; //center form
            this.FormClosing += CustList_FormClosing; // set close event

            String uri = "http://den-vm-dg02:8181"; // substitute with your host path. You may want to read this in from a config file (not hardcoded)
            uri = uri + "/Invoices_Soap";
            uri = uri + "/getCustList";
            uri = uri + "?NAMES=" + Uri.EscapeDataString(Selection[0]); //encode to handle spaces etc.
            uri = uri + "&ADDRS=" + Uri.EscapeDataString(Selection[1]); // endode to handle spaces etc.
            uri = uri + "&PHONE=" + Selection[2];
            uri = uri + "&STERR=" + Selection[3];


            var ElementCount = 0;
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.Load(uri);

            XmlNodeList elemList = xmlDocument.GetElementsByTagName("foundCustomers");

            // Multidimensional array                
            string[,] Customers = new string[elemList.Count, 7];

            for (int i = 0; i < elemList.Count; i++)
            {
                ElementCount = 0;
                foreach (XmlNode chldNode in elemList[i].ChildNodes)
                {
                    Customers[i, ElementCount] = chldNode.InnerText;
                    ElementCount++;

                }

            }

            for (int i = 0; i <= elemList.Count - 1; i++) // loop for number of items (-1 is to handle the 0 start position of the grid row
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j <= ElementCount - 1; j++) // loop for each attribute (-1 is to handle the 0 start position for the grid's cells
                {

                    dataGridView1.Rows[i].Cells[j].Value = Customers[i, j];

                }
            }
        }

            
//************************************************************Subroutines and Functions************************************************************************

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
            this.dataGridView1.ReadOnly = false; // set grid to allow editing
            dataGridView1.CurrentCell = dataGridView1[0, row - 1]; // force cursor to newly added row
            dataGridView1.BeginEdit(true);
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ReadOnly = true; // MAKE SURE WE RETURN THE GRID TO READ ONLY
            int Itemrow = dataGridView1.RowCount - 1; // Make sure we are on the new insert row

            // Note the example below uses a GET method. When writing data out you might want to leverage a POST method instead since the data is sent in the Body instead of the base URI.
            // build the string for the Web Service
            String uri = "http://den-vm-dg02:8181"; // substitute with your host path. You may want to read this in from a config file (not hardcoded)
            uri = uri + "/Invoices_Soap";
            uri = uri + "/writecustitem";
            uri = uri + "?CUSTID=" + dataGridView1.Rows[Itemrow].Cells[0].Value.ToString(); //get CustomerID
            uri = uri + "&NAME=" + dataGridView1.Rows[Itemrow].Cells[1].Value.ToString(); //get Customer Name
            uri = uri + "&ADDR=" + dataGridView1.Rows[Itemrow].Cells[2].Value.ToString(); //get Customer Address
            uri = uri + "&CITY=" + dataGridView1.Rows[Itemrow].Cells[3].Value.ToString(); //get Customer City 
            uri = uri + "&STATE=" + dataGridView1.Rows[Itemrow].Cells[4].Value.ToString(); //get Customer State
            uri = uri + "&ZIP=" + dataGridView1.Rows[Itemrow].Cells[5].Value.ToString(); //get Customer Zip
            uri = uri + "&PHONE=" + dataGridView1.Rows[Itemrow].Cells[6].Value.ToString(); //get Customer Phone


            string encoded_uri = Uri.EscapeUriString(uri); // Escape the url for spaces and VMs

            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.Load(encoded_uri);
            Add_Row.Visible = true; // swap the displayed buttons
            Insert.Visible = false;
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
                uri = uri + "/Invoices_Soap";
                uri = uri + "/delete_cust_item";
                uri = uri + "?CUSTID=" + ItemID; //get CustomerID

                string encoded_uri = Uri.EscapeUriString(uri); // Escape the url for spaces and VMs
                System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
                xmlDocument.Load(encoded_uri);
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
