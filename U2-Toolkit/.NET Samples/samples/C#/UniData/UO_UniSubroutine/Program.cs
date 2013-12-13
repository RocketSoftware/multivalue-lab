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

                string RoutineName = "*GETXMLSUB";
                int IntTotalAtgs = 6;
                string[] largs = new string[IntTotalAtgs];
                largs[0] = "LIST STUDENT ALL";
                largs[1] = "arg2";
                largs[2] = "arg3";
                largs[3] = "arg4";
                largs[4] = "arg5";
                largs[5] = "arg6";
                UniDynArray tmpStr2;
                UniSubroutine sub = us1.CreateUniSubroutine(RoutineName, IntTotalAtgs);

                for (int i = 0; i < IntTotalAtgs; i++)
                {
                    sub.SetArg(i, largs[i]);
                }

                sub.Call();
                tmpStr2 = sub.GetArgDynArray(2);
                string result = "\n" + "Result is :" + tmpStr2;
                Console.WriteLine("  Response from UniSubRoutineSample :" + result);

               
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
