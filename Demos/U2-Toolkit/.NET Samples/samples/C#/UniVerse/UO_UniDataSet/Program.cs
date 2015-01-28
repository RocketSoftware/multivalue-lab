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

                // open customer file
                UniFile fl = us1.CreateUniFile("CUSTOMER");

                // read records as unidataset
                string[] sArray = { "2", "12", "3", "4" };
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
                UniRecord q2 = uSet["2"];
                string sq2 = q2.ToString();
                Console.WriteLine("  Record data for rec id 2:" + sq2);
                UniRecord q3 = uSet["3"];
                string sq3 = q3.ToString();
                Console.WriteLine("  Record data for rec id 3:" + sq3);
                UniRecord q4 = uSet["4"];
                string sq4 = q4.ToString();
                Console.WriteLine("  Record data for rec id 4:" + sq4);

                // create UniDataSet in the Client Side
                UniDataSet uSet3 = us1.CreateUniDataSet();
                uSet3.Insert("3", "aaa");
                uSet3.Insert("4", "bbb");
                uSet3.Insert("5", "vvv");
                uSet3.Insert(2, "8", "www");

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
