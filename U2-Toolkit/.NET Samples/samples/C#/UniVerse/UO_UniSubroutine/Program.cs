using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U2.Data.Client;
using U2.Data.Client.UO;

namespace UO_UniSubroutine
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

                

                UniSession us1 = con.UniSession;

                string RoutineName = "!TIMDAT";
                int IntTotalAtgs = 1;
                string[] largs = new string[IntTotalAtgs];
                largs[0] = "1";
                UniDynArray tmpStr2;
                UniSubroutine sub = us1.CreateUniSubroutine(RoutineName, IntTotalAtgs);

                for (int i = 0; i < IntTotalAtgs; i++)
                {
                    sub.SetArg(i, largs[i]);
                }

                sub.Call();
                tmpStr2 = sub.GetArgDynArray(0);
                string result = "\n" + "Result is :" + tmpStr2;
                Console.WriteLine("  Response from UniSubRoutineSample :" + result);

                
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
