using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication_Acme_Soap
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
            string[] Selection = new string[4];
            Selection[0] = Custname.Text;
            Selection[1] = Address.Text;
            Selection[2] = Phone.Text;
            Selection[3] = Territory.Text;
            CustList frm2 = new CustList(Selection);
            frm2.Show();
            this.Hide();
            
            
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
