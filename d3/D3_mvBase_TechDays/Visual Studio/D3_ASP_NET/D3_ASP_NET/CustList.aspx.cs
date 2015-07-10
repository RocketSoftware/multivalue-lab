using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using rocketsoftware.MVSP; //add MVS .NET Library

namespace D3_ASP_NET
{

    public partial class CustList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // retrieve search arguments from previous customer search form

                string custName = (string)(Session["CustName"]);
                string custAddress = (string)(Session["CustAddr"]);
                string custPhone = (string)(Session["CustPhone"]);
                string custTerrNo = (string)(Session["CustTerr"]);

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
                    //if (acctstat)
                    // {
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
                    if (amCount != 0)
                    {
                        int vmCount = func.Dcount(custResults, vm);
                        int itemCount = vmCount / amCount; //determine how many items we retreived

                        DataTable dt = new DataTable(); //map results into a dataTable that can be then bound to the dataGrid
                        // Create the Headers for the DataTable
                        dt.Columns.Add("Account#", typeof(string));
                        dt.Columns.Add("Name", typeof(string));
                        dt.Columns.Add("Address", typeof(string));
                        dt.Columns.Add("City", typeof(string));
                        dt.Columns.Add("State", typeof(string));
                        dt.Columns.Add("Zip", typeof(string));
                        dt.Columns.Add("Phone", typeof(string));


                        for (int v = 0; v < itemCount + 1; v++) // need to add 1 to the amCount to allow for the loop going enough times for all items
                        {

                            dt.Rows.Add();

                            dt.Rows[dt.Rows.Count - 1]["Account#"] = func.Extract(custResults, 1, v + 1);
                            dt.Rows[dt.Rows.Count - 1]["Name"] = func.Extract(custResults, 2, v + 1);
                            dt.Rows[dt.Rows.Count - 1]["Address"] = func.Extract(custResults, 3, v + 1);
                            dt.Rows[dt.Rows.Count - 1]["City"] = func.Extract(custResults, 4, v + 1);
                            dt.Rows[dt.Rows.Count - 1]["State"] = func.Extract(custResults, 5, v + 1);
                            dt.Rows[dt.Rows.Count - 1]["Zip"] = func.Extract(custResults, 6, v + 1);
                            dt.Rows[dt.Rows.Count - 1]["Phone"] = func.Extract(custResults, 7, v + 1);

                        }

                        Grid_CustList.DataSource = dt;
                        Grid_CustList.DataBind();
                        Session["dt_table"] = dt;

                    }
                    else { lbl_STATUS.Text = custResults; btn_NewSearch.Visible = false; } // show error and hide controls

                    D3.CloseConnection(); //close out the connection to D3

                }

            }

        }

        //************************************************************************************************************************************************************************

        private void DataGridView1_CellContentClick(object sender, EventArgs e)
        {

            string InvoiceNo = Grid_CustList.SelectedValue.ToString();
        }


        protected void Get_CustomerSearch(object sender, EventArgs e)
        {
            Response.Redirect("~/CustomerSearch.aspx");
        }


        protected void Insert_Item_Click(object sender, EventArgs e)
        {
            string CUSTID = ((TextBox)Grid_CustList.FooterRow.FindControl("txtAcct")).Text;
            TextBox tx = (TextBox)Grid_CustList.FooterRow.FindControl("txtAcct");
            if (string.IsNullOrEmpty(tx.Text))
            {
                return;
            }

            string NAME = ((TextBox)Grid_CustList.FooterRow.FindControl("txtName")).Text;
            string ADDR = ((TextBox)Grid_CustList.FooterRow.FindControl("txtAddr")).Text;
            string CITY = ((TextBox)Grid_CustList.FooterRow.FindControl("txtCity")).Text;
            string STATE = ((TextBox)Grid_CustList.FooterRow.FindControl("txtState")).Text;
            string ZIP = ((TextBox)Grid_CustList.FooterRow.FindControl("txtZip")).Text;
            string PHONE = ((TextBox)Grid_CustList.FooterRow.FindControl("txtPhone")).Text;

            // ***************************** prepare and write data to D3 via Basic Subroutine Call *******************************

            // assign connection values and create variables to use
            string hostName = "den-vm-dg02"; // replace with your host or leverage a config file or similar approach
            int hostPort = 9000;
            string userName = "DM";
            string userPassword = "";
            Boolean x = false;
            string subroutine = "WriteCustItem.sub";
            int args = 8; // 7 inputs and a retured status code
            String Account = "acme";

            Pick D3 = new rocketsoftware.MVSP.Pick(); // make an instance of the D3 class
            Functions func = new Functions(); // make an instance of the Functions Class
            x = D3.Connect(hostName, hostPort, userName, userPassword); // connect to D3 and check status
            if (x)
            {
                bool acctstat = D3.Logto(Account, ""); //Move to the correct account
                //if (acctstat)..... would normally add error handling logic here

                //Prepare to call the subroutine that gets the customer lists


                Pick.mvSubroutine mysub = new Pick.mvSubroutine(subroutine, args, D3);

                mysub.SetArgs(0, CUSTID); // set the required arguments into the array for the arguments of the subroutine
                mysub.SetArgs(1, NAME);
                mysub.SetArgs(2, ADDR);
                mysub.SetArgs(3, CITY);
                mysub.SetArgs(4, STATE);
                mysub.SetArgs(5, ZIP);
                mysub.SetArgs(6, PHONE);
                mysub.SetArgs(7, "");
                mysub.MvCall();

                string STATUS = mysub.GetArgs(7); // gets the return values from the subroutine

                //  Perform Error checking based on status returned

                // Retrieve the datatable from Session and add the row so we can dbind it back to the gridtable
                DataTable dt = (DataTable)(Session["dt_Table"]);


                dt.Rows.Add(); // add row to datatable so we can insert the new data
                dt.Rows[dt.Rows.Count - 1]["Account#"] = CUSTID;
                dt.Rows[dt.Rows.Count - 1]["Name"] = NAME;
                dt.Rows[dt.Rows.Count - 1]["Address"] = ADDR;
                dt.Rows[dt.Rows.Count - 1]["City"] = CITY;
                dt.Rows[dt.Rows.Count - 1]["State"] = STATE;
                dt.Rows[dt.Rows.Count - 1]["Zip"] = ZIP;
                dt.Rows[dt.Rows.Count - 1]["Phone"] = PHONE;

                Grid_CustList.DataSource = dt;
                Grid_CustList.DataBind();
                Session["dt_table"] = dt;
                D3.CloseConnection(); //close out the connection to D3
            }
        }


        public Label custResults { get; set; }

        protected void Grid_CustList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItem")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int row_index = int.Parse(e.CommandArgument.ToString());

                string CUSTID = ((HyperLink)Grid_CustList.Rows[row_index].Cells[0].FindControl("HyperLink1")).Text;

               
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

                        subroutine = "delete_cust_item.sub";
                        args = 2;
                        Pick.mvSubroutine mysub = new Pick.mvSubroutine(subroutine, args, D3);
                        mysub.SetArgs(0, CUSTID);
                        mysub.MvCall();
                        string Status = mysub.GetArgs(1); // gets the return values from the subroutine
                        // do proper error handling on return status

                        
                        Grid_CustList.DataBind();
                       
                        D3.CloseConnection(); //close out the connection to D3

                        Response.Redirect(Request.RawUrl);
                        
                    }
                }



            }

        }
    }
}


