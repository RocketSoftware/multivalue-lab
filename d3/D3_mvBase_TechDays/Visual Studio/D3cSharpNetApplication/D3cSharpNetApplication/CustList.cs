using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rocketsoftware.MVSP; //add MVSP .NET Library

namespace D3cSharpNetApplication
{
    public partial class CustList : Form
    {
        private int rowIndex = 0;

        public CustList()
        {

            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; //center form
            this.FormClosing += CustList_FormClosing;

            // retrieve search arguments from previous customer search form

            string custName = formargs.Selection[0];
            string custAddress = formargs.Selection[1];
            string custPhone = formargs.Selection[2];
            string custTerrNo = formargs.Selection[3];

            var am = (char)254;
            var vm = (char)253;

            // assign connection values and create variables to use
            string hostName = "den-vm-dg02"; // replace with your host or leverage a config file or similar approach
            int hostPort = 9000;
            string userName = "DM";
            string userPassword = "";
            Boolean x = false;
            string subroutine = "";
            int args = 0;
            String Account = "acme";

            Pick D3 = new rocketsoftware.MVSP.Pick(); // make an instance of the D3 class
            Functions func = new Functions(); // make an instance of the Functions Class
            x = D3.Connect(hostName, hostPort, userName, userPassword); // connect to D3 and check status
            if (x)
            {
                bool acctstat = D3.Logto(Account, ""); //Move to the correct account
                if (acctstat)
                {
                    //Prepare to call the subroutine that gets the customer lists
                    subroutine = "cust_lookup.sub";
                    args = 5;
                    Pick.mvSubroutine mysub = new Pick.mvSubroutine(subroutine, args, D3);

                    mysub.SetArgs(0, custName); // set the required arguments into the array for the arguments of the subroutine
                    mysub.SetArgs(1, custAddress);
                    mysub.SetArgs(2, custPhone);
                    mysub.SetArgs(3, custTerrNo);
                    mysub.SetArgs(4, "");

                    mysub.MvCall();
                    string custResults = mysub.GetArgs(4); // gets the return values from the subroutine

                    int amCount = func.Count(custResults, am); // counts the number of items we have
                    int vmCount = func.Dcount(custResults, vm);
                    int itemCount = vmCount / amCount; //determine how many items we retreived


                    for (int v = 0; v < itemCount; v++) // need to add 1 to the amCount to allow for the loop going enogh times for all items
                    {
                        dataGridView1.Rows.Add(); // add row so we can insert into

                        // map results into the form's datagrid
                        dataGridView1.Rows[v].Cells[0].Value = func.Extract(custResults, 1, v + 1);     //AccountNo
                        dataGridView1.Rows[v].Cells[1].Value = func.Extract(custResults, 2, v + 1);     //Customer Name
                        dataGridView1.Rows[v].Cells[2].Value = func.Extract(custResults, 3, v + 1);     //Address
                        dataGridView1.Rows[v].Cells[3].Value = func.Extract(custResults, 4, v + 1);     //City
                        dataGridView1.Rows[v].Cells[4].Value = func.Extract(custResults, 5, v + 1);     //State
                        dataGridView1.Rows[v].Cells[5].Value = func.Extract(custResults, 6, v + 1);     // Zip
                        dataGridView1.Rows[v].Cells[6].Value = func.Extract(custResults, 7, v + 1);     // Phone
                    }

                    D3.CloseConnection(); //close out the connection to D3
                }
                else
                {
                    MessageBox.Show(Account + ": Not Found", "Invalid Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("Unable to connect to D3", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);

            }


        }

        private void NewSearch_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
            CustSearchFormProvider.custsearch.Show();


        }

        private void CustList_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.Dispose();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) // catch the clicked on cell and load the Invoices Form
        {
            string AcctSelection = dataGridView1.CurrentCell.Value.ToString();
            formargs.AcctSelection = AcctSelection;
            Invoices frm2 = new Invoices();

            frm2.Show();

        }

        private void Add_Row_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            Add_Row.Visible = false;
            Insert.Visible = true;
            int row = dataGridView1.RowCount;
            dataGridView1.CurrentCell = dataGridView1[0, row - 1]; // force cursor to newly added row
            this.dataGridView1.ReadOnly = false; // set grid to allow editing
            dataGridView1.BeginEdit(true);
        }

        private void Insert_Click(object sender, EventArgs e)
        {
           // assign connection values and create variables to use
            string hostName = "den-vm-dg02"; // replace with your host or leverage a config file or similar approach
            int hostPort = 9000;
            string userName = "DM";
            string userPassword = "";
            Boolean x = false;
            string subroutine = "";
            int args = 0;
            String Account = "acme";

            //Prepare to call the subroutine that gets writes the new customer

            Pick D3 = new rocketsoftware.MVSP.Pick(); // make an instance of the D3 class
            Functions func = new Functions(); // make an instance of the Functions Class
            x = D3.Connect(hostName, hostPort, userName, userPassword); // connect to D3 and check status
            if (x)
            {
                bool acctstat = D3.Logto(Account, ""); //Move to the correct account
                if (acctstat)
                {

                    subroutine = "WriteCustItem.sub";
                    args = 8;
                    Pick.mvSubroutine mysub = new Pick.mvSubroutine(subroutine, args, D3);

                    this.dataGridView1.ReadOnly = true; // MAKE SURE WE RETURN THE GRID TO READ ONLY
                    int Itemrow = dataGridView1.RowCount - 1; // Make sure we are on the new insert row
                   
                    // set the required arguments into the array for the arguments of the subroutine
                    mysub.SetArgs(0, dataGridView1.Rows[Itemrow].Cells[0].Value.ToString()); //get CustomerID
                    mysub.SetArgs(1, dataGridView1.Rows[Itemrow].Cells[1].Value.ToString()); //get Customer Name
                    mysub.SetArgs(2, dataGridView1.Rows[Itemrow].Cells[2].Value.ToString()); //get Customer Address
                    mysub.SetArgs(3, dataGridView1.Rows[Itemrow].Cells[3].Value.ToString()); //get Customer City 
                    mysub.SetArgs(4, dataGridView1.Rows[Itemrow].Cells[4].Value.ToString()); //get Customer State
                    mysub.SetArgs(5, dataGridView1.Rows[Itemrow].Cells[5].Value.ToString()); //get Customer Zip
                    mysub.SetArgs(6, dataGridView1.Rows[Itemrow].Cells[6].Value.ToString()); //get Customer Phone

                    mysub.MvCall();
                    string Status = mysub.GetArgs(7); // gets the return values from the subroutine


                    Add_Row.Visible = true; // swap the displayed buttons
                    Insert.Visible = false;
                    D3.CloseConnection(); //close out the connection to D3

                }

                else
                {
                    MessageBox.Show(Account + ": Not Found", "Invalid Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("Unable to connect to D3", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);

            }

        }

        private void ContextStrip_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {
                // assign connection values and create variables to use
                string hostName = "den-vm-dg02"; // replace with your host or leverage a config file or similar approach
                int hostPort = 9000;
                string userName = "DM";
                string userPassword = "";
                Boolean x = false;
                string subroutine = "";
                int args = 0;
                String Account = "acme";

                //Prepare to call the subroutine that deletes customer
                string ItemID = dataGridView1.Rows[this.rowIndex].Cells[0].Value.ToString(); //get CustomerID
                this.dataGridView1.Rows.RemoveAt(this.rowIndex);

                Pick D3 = new rocketsoftware.MVSP.Pick(); // make an instance of the D3 class
                    Functions func = new Functions(); // make an instance of the Functions Class
                     x = D3.Connect(hostName, hostPort, userName, userPassword); // connect to D3 and check status
                    if (x)
                 {
                         bool acctstat = D3.Logto(Account, ""); //Move to the correct account
                        if (acctstat)
                        {

                            subroutine = "delete_cust_item.sub";
                            args = 2;
                            Pick.mvSubroutine mysub = new Pick.mvSubroutine(subroutine, args, D3);
                            mysub.SetArgs(0,ItemID);
                            mysub.MvCall();
                    string Status = mysub.GetArgs(1); // gets the return values from the subroutine


                    Add_Row.Visible = true; // swap the displayed buttons
                    Insert.Visible = false;
                    D3.CloseConnection(); //close out the connection to D3
            }
                 }

                    else
                    {
                        MessageBox.Show(Account + ": Not Found", "Invalid Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Environment.Exit(0);
                    }
            }
            else
            {
                MessageBox.Show("Unable to connect to D3", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);

            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
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


