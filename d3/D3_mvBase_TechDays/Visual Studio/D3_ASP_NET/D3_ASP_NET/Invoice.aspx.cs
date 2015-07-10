using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using rocketsoftware.MVSP; // add MVSP .NET Library

namespace D3_ASP_NET
{
    public partial class Invoice: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            string InvoiceSelection = Request.QueryString["param"];

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

                    string InvoiceResult = mysub.GetArgs(1);

                    tbl_AccountID.Text = func.Extract(InvoiceResult, 1);
                    tbl_BillTo.Text = func.Extract(InvoiceResult, 2);
                    tbl_BillToAddr.Text = func.Extract(InvoiceResult, 3);
                    var BillCity = func.Extract(InvoiceResult, 4);
                    var BillState = func.Extract(InvoiceResult, 5);
                    var BillZip = func.Extract(InvoiceResult, 6);
                    tbl_BillToCSZ.Text = BillCity + ", " + BillState + " " + BillZip;

                    tbl_Contact.Text = func.Extract(InvoiceResult, 7);
                    tbl_InvoiceID.Text = func.Extract(InvoiceResult, 8);
                    tbl_ShipTo.Text = func.Extract(InvoiceResult, 9);
                    tbl_ShipToAddr.Text = func.Extract(InvoiceResult, 10);

                    var ShipCity = func.Extract(InvoiceResult, 11);
                    var ShipState = func.Extract(InvoiceResult, 12);
                    var ShipZip = func.Extract(InvoiceResult, 13);
                    tbl_ShipToCSZ.Text = ShipCity + ", " + ShipState + " " + ShipZip;

                    tbl_SalesRep.Text = func.Extract(InvoiceResult, 15, 1);
                    tbl_RepPhone.Text = func.Extract(InvoiceResult, 16, 2);
                    tbl_Ordered.Text = func.Extract(InvoiceResult, 17);
                    tbl_Invoiced.Text = func.Extract(InvoiceResult, 18);
                    tbl_Terms.Text = func.Extract(InvoiceResult, 19);
                    tbl_Note.Text = func.Extract(InvoiceResult, 20);
                    tbl_Gross.Text = func.Extract(InvoiceResult, 21);
                    tbl_Discount.Text = func.Extract(InvoiceResult, 22);
                    tbl_Net.Text = func.Extract(InvoiceResult, 23);

                    //declare the strings needed to do the deletes of the mv attributes that are not part of the line items so we can get an accurate count

                    string LineResults1 = "";
                    string LineResults2 = "";
                    int mvLineCount = 7;


                    LineResults1 = func.Delete(InvoiceResult, 15);
                    LineResults2 = func.Delete(LineResults1, 15);
                    int vmCount = func.Dcount(LineResults2, vm);
                    int svmCount = func.Count(LineResults2, svm); // find out how many actual line items we have
                    int itemCount = vmCount / mvLineCount;

                    //Create dataTable
                    
                    DataTable dt = new DataTable(); //map results into a dataTable that can be then bound to the dataGrid
                    // Create the Headers for the DataTable that needs to mapped so that the DataGrid can bind to it.
                    dt.Columns.Add("Ln", typeof(string));
                    dt.Columns.Add("Qty", typeof(string));
                    dt.Columns.Add("ItemId", typeof(string));
                    dt.Columns.Add("Description", typeof(string));
                    dt.Columns.Add("UnitPrice", typeof(string));
                    dt.Columns.Add("ExtPrice", typeof(Int32));
                    dt.Columns.Add("Disc", typeof(string));
                    dt.Columns.Add("Ext", typeof(Int32));   
                   
                    //Get Each Line Item
                    for (int i = 0; i <= itemCount; i++)
                    {

                        dt.Rows.Add();

                        dt.Rows[dt.Rows.Count - 1]["Ln"] = i + 1; // LineQty
                        dt.Rows[dt.Rows.Count - 1]["Qty"] =         func.Extract(InvoiceResult, 24, i + 1); // Line Qty
                        dt.Rows[dt.Rows.Count - 1]["ItemId"] =       func.Extract(InvoiceResult, 25, i + 1); // Product Number
                        dt.Rows[dt.Rows.Count - 1]["Description"] = func.Extract(InvoiceResult, 26, i + 1); // Description
                        dt.Rows[dt.Rows.Count - 1]["UnitPrice"] =  decimal.Parse(func.Extract(InvoiceResult, 27, i + 1)); // List or Unit Price
                        dt.Rows[dt.Rows.Count - 1]["ExtPrice"] =   decimal.Parse(func.Extract(InvoiceResult, 28, i + 1)); // Total Gross 
                        dt.Rows[dt.Rows.Count - 1]["Disc"] =   func.Extract(InvoiceResult, 29, i + 1); // Total Discount is a %
                        dt.Rows[dt.Rows.Count - 1]["Ext"] =         decimal.Parse(func.Extract(InvoiceResult, 31, i + 1)); // Total Net


            }

                    Grid_InvoiceList.DataSource = dt;
                    Grid_InvoiceList.DataBind();

                    D3.CloseConnection();


                    }
                }
            }

        protected void Get_CustomerSearch(object sender, EventArgs e)
        {
            Response.Redirect("~/CustomerSearch.aspx");
        }
    }
}