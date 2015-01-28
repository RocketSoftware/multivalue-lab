using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U2.Data.Client;
using U2.Data.Client.UO;

namespace UO_UniFile
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
                conn_str.AccessMode = "Native";   // FOR UO
                conn_str.RpcServiceType = "uvcs"; // FOR UO
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
                UniFile fl = us1.CreateUniFile("CUSTOMER");
                sl.Select(fl);

                bool lLastRecord = sl.LastRecordRead;
                List<string> lRecIdList = new List<string>();
                while (!lLastRecord)
                {
                    string sRecID = sl.Next();
                    lRecIdList.Add(sRecID);
                    Console.WriteLine("Record ID:" + sRecID);
                    lLastRecord = sl.LastRecordRead;
                }

                UniDataSet uSet = fl.ReadRecords(lRecIdList.ToArray());
                // use for each statement to print the record
                foreach (UniRecord item in uSet)
                {
                    
                    Console.WriteLine(item.ToString());
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
