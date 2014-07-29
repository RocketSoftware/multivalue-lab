using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U2.Data.Client;
using System.Data;

namespace DataAdapter_MultiValue
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FillDataSetWithUNNEST();
            Console.WriteLine("Enter to exit:");
            string line = Console.ReadLine();
        }

        
        private static void FillDataSetWithUNNEST()
        {
            try
            {
                U2ConnectionStringBuilder conn_str = new U2ConnectionStringBuilder();
                conn_str.UserID = "user";
                conn_str.Password = "pass";
                conn_str.Server = "localhost";
                conn_str.Database = "HS.SALES";
                conn_str.ServerType = "UNIVERSE";
                conn_str.FirstNormalForm = false;
                conn_str.Pooling = false;
                string s = conn_str.ToString();
                U2Connection con = new U2Connection();
                con.ConnectionString = s;
                con.Open();
                Console.WriteLine("Connected.........................");
                U2Command cmd = con.CreateCommand();
                cmd.CommandText = "SELECT FNAME, PRICE FROM UNNEST CUSTOMER ON ORDERS"; // FNAME = SingleValue, PRICE = multivalue
                DataSet ds = new DataSet();
                U2DataAdapter da = new U2DataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine(dr["FNAME"] + "==" + dr["PRICE"]);
                }

                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                //Console.WriteLine("Enter to exit:");
                //string line = Console.ReadLine();
            }
        }
    }
}
