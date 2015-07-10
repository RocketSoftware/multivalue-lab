using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3cSharpNetApplication
{  
    

    public partial class CustomerSearch : Form
    {
        
        public CustomerSearch()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; //center form
            
            this.FormClosing += CustomerSearch_FormClosing; // set close event
        }

        private void Search_Click(object sender, System.EventArgs e)
        {
           
            //string[] Selection = new string[4];
            formargs.Selection[0] = Custname.Text;
            formargs.Selection[1] = Address.Text;
            formargs.Selection[2] = Phone.Text;
            formargs.Selection[3] = Territory.Text;

            CustList frm2 = new CustList();

            frm2.Show();
            
        }

        private void Clear_Click(object sender, System.EventArgs e)
        {
            Custname.Text = String.Empty;
            Territory.Text = String.Empty;
            Address.Text = String.Empty;
            Phone.Text = String.Empty;
        }

        private void CustomerSearch_FormClosing(Object sender, FormClosingEventArgs e)
        {

            Environment.Exit(0);
        }
    }
}
