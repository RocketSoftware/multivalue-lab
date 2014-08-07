using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using U2.Data.Client;

namespace DataAdapter
{
    public partial class Form1 : Form
    {
        private U2DataAdapter m_da;
        private U2CommandBuilder m_U2CommandBuilder;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.Clear();
                var connection_str = System.Configuration.ConfigurationManager.ConnectionStrings["DEMO_UV"];

                string s = connection_str.ConnectionString;
                U2Connection con = new U2Connection();
                con.ConnectionString = s;
                con.Open();
                this.textBox1.AppendText("Connected.........................(UniVerse Account)" + Environment.NewLine);

                U2Command cmd = con.CreateCommand();

                cmd.CommandText = "SELECT CUSTID, FNAME,LNAME FROM CUSTOMER";

                DataSet ds = new DataSet();
                m_da = new U2DataAdapter(cmd);
                m_da.Fill(ds);
                m_U2CommandBuilder = new U2CommandBuilder(m_da);

                this.dataGridView1.DataSource = ds.Tables[0].DefaultView;

                this.textBox1.AppendText("Done........................." + Environment.NewLine);

            }
            catch (Exception e3)
            {
                this.textBox1.AppendText(e3.Message);
                MessageBox.Show(e3.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.Clear();
                var connection_str = System.Configuration.ConfigurationManager.ConnectionStrings["DEMO_UD"];

                string s = connection_str.ConnectionString;
                U2Connection con = new U2Connection();
                con.ConnectionString = s;
                con.Open();
                this.textBox1.AppendText("Connected.........................(UniData Account)" + Environment.NewLine);

                U2Command cmd = con.CreateCommand();

                cmd.CommandText = "SELECT ID, FNAME,LNAME FROM STUDENT_NF_SUB";

                DataSet ds = new DataSet();
                m_da = new U2DataAdapter(cmd);
                m_da.Fill(ds);
                m_U2CommandBuilder = new U2CommandBuilder(m_da);

                this.dataGridView1.DataSource = ds.Tables[0].DefaultView;

                this.textBox1.AppendText("Done........................." + Environment.NewLine);

            }
            catch (Exception e3)
            {
                this.textBox1.AppendText(e3.Message);
                MessageBox.Show(e3.Message);
            }
        }
    }
}
