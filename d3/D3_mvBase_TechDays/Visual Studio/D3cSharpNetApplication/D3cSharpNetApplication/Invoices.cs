using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rocketsoftware.MVSP; //Add MVSP .NET Library

namespace D3cSharpNetApplication
{
    public partial class Invoices : Form
    {
        public Invoices()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen; //center form

            this.FormClosing += Invoices_FormClosing; // set close event


            string hostName = "den-vm-dg02"; // replace with your host or leverage a config file or similar approach
            int hostPort = 9000;
            string userName = "DM";
            string userPassword = "";
            Boolean x = false;
            
            string fileName = "customers";
            string invoiceID = "";
            string salesrep = "";
            int args = 0;
            string subroutine = "";
            String AcctSelection = formargs.AcctSelection;

            Pick D3 = new rocketsoftware.MVSP.Pick();
            Functions func = new Functions();

            x = D3.Connect(hostName, hostPort, userName, userPassword);
            bool acctstat = D3.Logto("acme", "");  // log over to the appropriate account

            String CustomerName = D3.FileReadv(fileName, AcctSelection, 1); // read the customer file to get the customer name
            label1.Text = "Invoices for Customer: " + CustomerName; // assign the customer name to the custmer name display

            // build the query to get the Invoice IDs that meet the selection criteria
            D3.ExecuteQuery("Query", "TRX.MST", "With cust.acct# = " + "" + AcctSelection + "" + " and with invoice.date", "by-dsnd invoice.date", " trx#", "");
            int rowcount = D3.MVResultSetGetRowCount();

            for (int i = 0; i < rowcount; i++) // loop through the ID list to read each matching Item
            {
                D3.MVResultSetNext();
                invoiceID = D3.MVResultSetGetCurrentRow(); // gets the invoiceID from the result set to use for the subsequent readfile statements
                fileName = "TRX.MST";
                    string trxItem = D3.FileRead(fileName, invoiceID);
                    string invoiceDate = func.Extract(trxItem,21);
                    args = 2;
                    subroutine = "date_convert.sub";
                    Pick.mvSubroutine mysub = new Pick.mvSubroutine(subroutine, args, D3);
                        mysub.SetArgs(0, invoiceDate);
                        mysub.SetArgs(1, "");
                        mysub.MvCall();                         // call date conversion
                        invoiceDate = mysub.GetArgs(1);
                       
                     string orderDate = func.Extract(trxItem,18);
                        mysub.SetArgs(0, orderDate);
                        mysub.MvCall();                         // call date conversion
                        orderDate = mysub.GetArgs(1);

                        
                    int TotalGross = Convert.ToInt32(func.Extract(trxItem,31));
                    int TotalDiscount = Convert.ToInt32(func.Extract(trxItem, 32));
                    int TotalNet = (TotalGross-TotalDiscount);
                    string Comments = func.Extract(trxItem, 23);
                    string TerrID = func.Extract(trxItem, 8);
                    

                fileName = "territories";
                string Terr_Results = D3.FileRead(fileName, TerrID);
                if (D3.statusCode !=0)
                {
                    //if no territory there is no valid sales rep
                    salesrep = "";
                }
                else
                {
                    string territory = func.Extract(Terr_Results, 2);
                    fileName = "salesreps";
                    salesrep = D3.FileReadv(fileName, territory, 1);
                    if (D3.statusCode !=0) {salesrep = ""; }// no sales rep for the territory
                }
            

                    dataGridView2.Rows.Add();

                    dataGridView2.Rows[i].Cells[0].Value = invoiceID;
                    dataGridView2.Rows[i].Cells[1].Value = invoiceDate;
                    dataGridView2.Rows[i].Cells[2].Value = orderDate;
                    dataGridView2.Rows[i].Cells[3].Value = salesrep;
                    dataGridView2.Rows[i].Cells[4].Value = "Net 30"; // Terms not in database
                    dataGridView2.Rows[i].Cells[5].Value = TotalGross;
                    dataGridView2.Rows[i].Cells[6].Value = TotalDiscount;
                    dataGridView2.Rows[i].Cells[7].Value = TotalNet;
                    dataGridView2.Rows[i].Cells[8].Value = Comments;
              }
            D3.CloseConnection();
                   
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
            formargs.InvoiceSelection = InvoiceSelection; // get invoice number and assign to clas proporty
            Invoice frm2 = new Invoice();

            frm2.Show();

        }


    }
}
