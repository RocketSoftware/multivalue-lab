using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U2.Data.Client;
using U2.Data.Client.UO;

namespace UO_UniSelectList
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
                conn_str.AccessMode = "Native";   // FOR UO
                conn_str.RpcServiceType = "udcs"; // FOR UO
                conn_str.Pooling = false;
                string s = conn_str.ToString();
                U2Connection con = new U2Connection();
                con.ConnectionString = s;
                con.Open();
                Console.WriteLine("Connected.........................");

                // get RECID

                UniSession us1 = con.UniSession;

                UniSelectList sl = us1.CreateUniSelectList(2);

                // Select UniFile
                UniFile fl = us1.CreateUniFile("STUDENT");
                sl.Select(fl);

                bool lLastRecord = sl.LastRecordRead;

                while (!lLastRecord)
                {
                    string s2 = sl.Next();
                    Console.WriteLine("Record ID:" + s2);
                    lLastRecord = sl.LastRecordRead;
                }

               

                con.Close();

            }
            catch (Exception e)
            {
                string s = e.Message;
                if (e.InnerException != null)
                {
                    s += e.InnerException.Message;
                }

                Console.WriteLine(s);

            }
            finally
            {
                Console.WriteLine("Enter to exit:");
                string line = Console.ReadLine();
            }
        }
    }
}
