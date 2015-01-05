using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Execute_U2Subroutine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.AppendText("Start : Subroutine_Async" +Environment.NewLine);
                string lRetVal = await Exec_Async_Subroutine.CallSubroutine();
                this.textBox1.AppendText("Output : " + Environment.NewLine);
                this.textBox1.AppendText(lRetVal);
                this.textBox1.AppendText(Environment.NewLine);
                this.textBox1.AppendText("End : Subroutine_Async" + Environment.NewLine);
            }
            catch (Exception e3)
            {
                this.textBox1.AppendText("Error : Subroutine_Async:" + e3.Message + Environment.NewLine);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.AppendText("Start : Subroutine_Async_DataTable" + Environment.NewLine);
                DataTable lRetValDT = await Exec_Async_Subroutine_DataTable.CallSubroutine();
                this.textBox1.AppendText("Output : " + Environment.NewLine);

                System.IO.StringWriter writer = new System.IO.StringWriter();
                lRetValDT.WriteXml(writer, true);

                this.textBox1.AppendText(writer.ToString());
                this.dataGridView1.DataSource = lRetValDT;
                this.textBox1.AppendText(Environment.NewLine);
                this.textBox1.AppendText("End : Subroutine_Async_DataTable" + Environment.NewLine);
            }
            catch (Exception e3)
            {
                this.textBox1.AppendText("Error : Subroutine_Async_DataTable:" + e3.Message + Environment.NewLine);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.AppendText("Start : Subroutine_Async_Objects" + Environment.NewLine);
                List<Employee> lRetEmpList = await Exec_Async_Subroutine_Objects.CallSubroutine();
                this.textBox1.AppendText("Output : " + Environment.NewLine);
                foreach (var item in lRetEmpList)
                {
                    this.textBox1.AppendText(item.ID+"\t"+item.Name+"\t"+item.HireDate + Environment.NewLine);
                }

               
                this.dataGridView1.DataSource = lRetEmpList;
                this.textBox1.AppendText(Environment.NewLine);
                this.textBox1.AppendText("End : Subroutine_Async_Objects" + Environment.NewLine);
            }
            catch (Exception e3)
            {
                this.textBox1.AppendText("Error : Subroutine_Async_Objects:" + e3.Message + Environment.NewLine);
            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {

            try
            {
                this.textBox1.AppendText("Start : Subroutine_Async_Json" + Environment.NewLine);
                string lRetVal = await Exec_Async_Subroutine_Json.CallSubroutine();
                this.textBox1.AppendText("Output : " + Environment.NewLine);
                this.textBox1.AppendText(lRetVal);
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(lRetVal);
                this.dataGridView1.DataSource = result;
                this.textBox1.AppendText( Environment.NewLine);
                this.textBox1.AppendText("End : Subroutine_Async_Json" + Environment.NewLine);
            }
            catch (Exception e3)
            {
                this.textBox1.AppendText("Error : Subroutine_Async_Json:" + e3.Message + Environment.NewLine);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.AppendText("Start : Subroutine_Async_SQLExecDirect" + Environment.NewLine);
                List<Customer> lRetEmpList = await Exec_Async_Subroutine_SQLExecDirect.CallSubroutine();
                this.textBox1.AppendText("Output : " + Environment.NewLine);
                foreach (var item in lRetEmpList)
                {
                    this.textBox1.AppendText(item.CustomerId + "\t" + item.FirstName + "\t" + item.LastName + Environment.NewLine);
                }

                this.dataGridView1.DataSource = lRetEmpList;
                this.textBox1.AppendText(Environment.NewLine);
                this.textBox1.AppendText("End : Subroutine_Async_SQLExecDirect" + Environment.NewLine);
            }
            catch (Exception e3)
            {
                this.textBox1.AppendText("Error : Subroutine_Async_SQLExecDirect:" + e3.Message + Environment.NewLine);
            }
        }
    }
}
