using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace D3_ASP_NET
{
    public partial class CustomerSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Get_CustList(object sender, CommandEventArgs e)
        {
            string CustName = txt_CustName.Text;
            string CustAddr = txt_CustAddr.Text;
            string CustPhone = txt_CustPhone.Text;
            string CustTerr = txt_CustTerr.Text;

            Session["CustName"] = CustName;
            Session["CustAddr"] = CustAddr;
            Session["CustPhone"] = CustPhone;
            Session["CustTerr"] = CustTerr;

            Response.Redirect("~/CustList.aspx");
        }

        protected void ClearSearch(object sender, EventArgs e)
        {
            txt_CustName.Text = "";
            txt_CustAddr.Text = "";
            txt_CustPhone.Text = "";
            txt_CustTerr.Text = "";

        }
    }
}