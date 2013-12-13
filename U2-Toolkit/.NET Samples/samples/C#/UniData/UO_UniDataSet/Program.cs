using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U2.Data.Client;
using U2.Data.Client.UO;

namespace UO_UniDataSet
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
                UniSession us1 = con.UniSession;

                UniSelectList sl = us1.CreateUniSelectList(2);
                // Select UniFile
                UniFile fl = us1.CreateUniFile("STUDENT");
                sl.Select(fl);

                // read records as unidataset
                string[] sArray = { "291222021", "521814564","424325656" };
                UniDataSet uSet = fl.ReadRecords(sArray);

                // use for each statement to print the record
                foreach (UniRecord item in uSet)
                {
                    Console.WriteLine(item.ToString());

                }

                // use index to print the record
                int lCount = uSet.RowCount;
                for (int ii = 0; ii < lCount; ii++)
                {
                    UniRecord ee = uSet[ii];
                    Console.WriteLine(ee.ToString());
                }

                // print one by one record
                UniRecord q2 = uSet["291222021"];
                string sq2 = q2.ToString();
                Console.WriteLine("  Record data for rec id 291222021:" + sq2);
                UniRecord q3 = uSet["521814564"];
                string sq3 = q3.ToString();
                Console.WriteLine("  Record data for rec id 521814564:" + sq3);
                UniRecord q4 = uSet["424325656"];
                string sq4 = q4.ToString();
                Console.WriteLine("  Record data for rec id 424325656:" + sq4);

                 //create UniDataSet in the Client Side
                UniDataSet uSet3 = us1.CreateUniDataSet();
                uSet3.Insert("3", "aaa");
                uSet3.Insert("4", "bbb");
                uSet3.Insert("5", "vvv");
                uSet3.Insert(2, "8", "www");


                

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
