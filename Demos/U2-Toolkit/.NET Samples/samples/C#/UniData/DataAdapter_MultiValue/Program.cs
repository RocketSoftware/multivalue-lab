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
            try
            {
                U2ConnectionStringBuilder conn_str = new U2ConnectionStringBuilder();
                conn_str.UserID = "user";
                conn_str.Password = "pass";
                conn_str.Server = "localhost";
                conn_str.Database = "demo";
                conn_str.ServerType = "UNIDATA";
                conn_str.Pooling = false;
                conn_str.FirstNormalForm = false;
                string s = conn_str.ToString();
                U2Connection con = new U2Connection();
                con.ConnectionString = s;
                con.Open();
                Console.WriteLine("Connected.........................");
                U2Command cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM STUDENT UNNEST NL_ALL CGA ;";
                DataSet ds = new DataSet();
                U2DataAdapter da = new U2DataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine(dr["FNAME"] + "==" + dr["SEMESTER"]);
                }

                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                Console.WriteLine("Enter to exit:");
                string line = Console.ReadLine();
            }
        }
    }
}
