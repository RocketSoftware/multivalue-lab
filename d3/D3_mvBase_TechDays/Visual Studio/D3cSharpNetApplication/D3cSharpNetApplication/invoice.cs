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
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen; //center form

            this.FormClosing += Invoice_FormClosing; // set close event

            
            var vm = (char)253;
            var svm = (char)252;


            string hostName = "den-vm-dg02"; // replace with your host or leverage a config file or similar approach
            int hostPort = 9000;
            string userName = "DM";
            string userPassword = "";
            Boolean x = false;
            string Account = "acme";
            string subroutine = "get_invoice.sub";
            int args = 0;
            string InvoiceSelection = formargs.InvoiceSelection;

            Pick D3 = new rocketsoftware.MVSP.Pick();
            Functions func = new Functions();
            x = D3.Connect(hostName, hostPort, userName, userPassword);
            if (x)
            {
                bool acctstat = D3.Logto(Account, ""); //Move to the correct account
                if (acctstat)
                {

                    args = 2;
                    Pick.mvSubroutine mysub = new Pick.mvSubroutine(subroutine, args, D3);

                    mysub.SetArgs(0, InvoiceSelection);
                    mysub.SetArgs(1, "");
                    mysub.MvCall(); // call get_invoice.sub
                 
                   if (D3.statusCode != 0)
                    {
                        MessageBox.Show("Unable to execute:" + D3.ruleModule, "Subroutine Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Environment.Exit(0);
                    }

                    else
                    {

                       string InvoiceResult =  mysub.GetArgs(1);

                        AccountNo.Text =    func.Extract(InvoiceResult, 1);
                        BillTo.Text =   func.Extract(InvoiceResult, 2);
                        BillAddr.Text = func.Extract(InvoiceResult, 3);
                        var BillCity =  func.Extract(InvoiceResult, 4);
                        var BillState = func.Extract(InvoiceResult, 5);
                        var BillZip =   func.Extract(InvoiceResult, 6);
                        Bill_CityStateZip.Text = BillCity + ", " + BillState + " " + BillZip;

                        Contact.Text =      func.Extract(InvoiceResult, 7);
                        InvoiceNo.Text =    func.Extract(InvoiceResult, 8);
                        ShipTo.Text =       func.Extract(InvoiceResult, 9);
                        ShipAddr.Text =     func.Extract(InvoiceResult, 10);

                        var ShipCity =      func.Extract(InvoiceResult, 11);
                        var ShipState =     func.Extract(InvoiceResult, 12);
                        var ShipZip =       func.Extract(InvoiceResult, 13);
                        Ship_CityStateZip.Text = ShipCity + ", " + ShipState + " " + ShipZip;

                        SalesRep.Text =     func.Extract(InvoiceResult, 15,1);
                        RepPhone.Text =     func.Extract(InvoiceResult, 16,2);
                        Ordered.Text =      func.Extract(InvoiceResult, 17);
                        Invoiced.Text =     func.Extract(InvoiceResult, 18);
                        Terms.Text =        func.Extract(InvoiceResult, 19);
                        Note.Text =         func.Extract(InvoiceResult, 20);
                        Gross.Text =        func.Extract(InvoiceResult, 21);
                        Discount.Text =     func.Extract(InvoiceResult, 22);
                        Net.Text =          func.Extract(InvoiceResult, 23);
                        
                       //declare the strings needed to do the deletes of the mv attributes that are not part of the line items so we can get an accurate count

                        string LineResults1 = "";
                        string LineResults2 = "";
                        int mvLineCount = 7;
                        
                        
                        LineResults1 = func.Delete(InvoiceResult, 15);
                        LineResults2 = func.Delete(LineResults1, 15);
                        int vmCount = func.Dcount(LineResults2, vm);
                        int svmCount = func.Count(LineResults2, svm); // find out how many actual line items we have
                        int itemCount = vmCount / mvLineCount;
                       
                       //Get Each Line Item
                         for(int i = 0; i <= itemCount; i++) {

                             dataGridView1.Rows.Add();

                             dataGridView1.Rows[i].Cells[0].Value = i + 1; // LineQty
                             dataGridView1.Rows[i].Cells[1].Value = func.Extract(InvoiceResult, 24, i + 1); // Line Qty
                             dataGridView1.Rows[i].Cells[2].Value = func.Extract(InvoiceResult, 25, i + 1); // Product Number
                             dataGridView1.Rows[i].Cells[3].Value = func.Extract(InvoiceResult, 26, i + 1); // Description
                             dataGridView1.Rows[i].Cells[4].Value = decimal.Parse(func.Extract(InvoiceResult, 27, i + 1)); // List or Unit Price
                             dataGridView1.Rows[i].Cells[5].Value = decimal.Parse(func.Extract(InvoiceResult, 28, i + 1)); // Total Gross 
                             dataGridView1.Rows[i].Cells[6].Value = func.Extract(InvoiceResult, 29, i + 1); // Total Discount is a %
                             dataGridView1.Rows[i].Cells[7].Value = decimal.Parse(func.Extract(InvoiceResult, 31, i + 1)); // Total Net
                             
                         }

                    }
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
