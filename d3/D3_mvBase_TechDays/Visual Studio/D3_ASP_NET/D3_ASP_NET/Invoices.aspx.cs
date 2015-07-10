using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using rocketsoftware.MVSP; // add MVSP .Net Library


namespace D3_ASP_NET
{
    public partial class Invoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string hostName = "den-vm-dg02"; // replace with your host. Rather than hardcode you would want to leverage a config file or similar approach
            int hostPort = 9000;
            string userName = "DM";
            string userPassword = "";
            Boolean x = false;

            string fileName = "customers";
            string invoiceID = "";
            string salesrep = "";
            int args = 0;
            string subroutine = "";
            String AcctSelection = Request.QueryString["param"];

            Pick D3 = new rocketsoftware.MVSP.Pick();
            Functions func = new Functions();


            x = D3.Connect(hostName, hostPort, userName, userPassword);
            bool acctstat = D3.Logto("acme", "");  // log over to the appropriate account

            String CustomerName = D3.FileReadv(fileName, AcctSelection, 1); // read the customer file to get the customer name
            lbl_CustomeName.Text = CustomerName; // assign the customer name to the custmer name display


            // Create DataTable
            DataTable dt = new DataTable(); //map results into a dataTable that can be then bound to the dataGrid
            // Create the Headers for the DataTable that needs to mapped so that the DataGrid can bind to it.
            dt.Columns.Add("Invoice#", typeof(string));
            dt.Columns.Add("InvoiceDate", typeof(string));
            dt.Columns.Add("OrderDate", typeof(string));
            dt.Columns.Add("Terms", typeof(string));
            dt.Columns.Add("Gross", typeof(Int32));
            dt.Columns.Add("Discount", typeof(Int32));
            dt.Columns.Add("NetInvoice", typeof(Int32));

            // build the query to get the Invoice IDs that meet the selection criteria
            D3.ExecuteQuery("Query", "TRX.MST", "With cust.acct# = " + "" + AcctSelection + "" + " and with invoice.date", "by-dsnd invoice.date", " trx#", "");
            int rowcount = D3.MVResultSetGetRowCount();

            for (int i = 0; i < rowcount; i++) // loop through the ID list to read each matching Item
            {
                D3.MVResultSetNext();
                invoiceID = D3.MVResultSetGetCurrentRow(); // gets the invoiceID from the result set to use for the subsequent readfile statements
                fileName = "TRX.MST";
                string trxItem = D3.FileRead(fileName, invoiceID);
                string invoiceDate = func.Extract(trxItem, 21);
                args = 2;
                subroutine = "date_convert.sub";
                Pick.mvSubroutine mysub = new Pick.mvSubroutine(subroutine, args, D3);
                mysub.SetArgs(0, invoiceDate);
                mysub.SetArgs(1, "");
                mysub.MvCall();                         // call date conversion
                invoiceDate = mysub.GetArgs(1);

                string orderDate = func.Extract(trxItem, 18);
                mysub.SetArgs(0, orderDate);
                mysub.MvCall();                         // call date conversion
                orderDate = mysub.GetArgs(1);

                // convert to int to do math
                int TotalGross = Convert.ToInt32(func.Extract(trxItem, 31));
                int TotalDiscount = Convert.ToInt32(func.Extract(trxItem, 32));
                int TotalNet = (TotalGross - TotalDiscount);

                string Comments = func.Extract(trxItem, 23);
                string TerrID = func.Extract(trxItem, 8);


                fileName = "territories";
                string Terr_Results = D3.FileRead(fileName, TerrID);

                if (D3.statusCode != 0) { salesrep = ""; }// no sales rep for the territory
                else
                {
                    string territory = func.Extract(Terr_Results, 2);
                    fileName = "salesreps";
                    salesrep = D3.FileReadv(fileName, territory, 1);
                }

                dt.Rows.Add();

                dt.Rows[dt.Rows.Count - 1]["Invoice#"] = invoiceID;
                dt.Rows[dt.Rows.Count - 1]["InvoiceDate"] = invoiceDate;
                dt.Rows[dt.Rows.Count - 1]["OrderDate"] = orderDate;
                dt.Rows[dt.Rows.Count - 1]["Terms"] = "Net 30"; // no terms in database
                dt.Rows[dt.Rows.Count - 1]["Gross"] = TotalGross;
                dt.Rows[dt.Rows.Count - 1]["Discount"] = TotalDiscount;
                dt.Rows[dt.Rows.Count - 1]["NetInvoice"] = TotalNet;


            }

            Grid_Invoices.DataSource = dt;
            Grid_Invoices.DataBind();

            D3.CloseConnection();

        }

        protected void Get_CustomerSearch(object sender, EventArgs e)
        {
            Response.Redirect("~/CustomerSearch.aspx");
        }
    }
}

