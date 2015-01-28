using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U2.Data.Client;
using System.Data;
using System.IO;

namespace DataAdapter_TOXML
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
                conn_str.Database = "HS.SALES";
                conn_str.ServerType = "UNIVERSE";
                conn_str.Pooling = false;
                string s = conn_str.ToString();
                U2Connection con = new U2Connection();
                con.ConnectionString = s;
                con.Open();
                Console.WriteLine("Connected.........................");
                U2Command cmd = con.CreateCommand();
                cmd.CommandText = "LIST CUSTOMER";
                DataSet ds = new DataSet();
                U2DataAdapter da = new U2DataAdapter(cmd);
                da.FillWithTOXML(ds);
               

                 Console.WriteLine(ds.GetXml());
                

                
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
