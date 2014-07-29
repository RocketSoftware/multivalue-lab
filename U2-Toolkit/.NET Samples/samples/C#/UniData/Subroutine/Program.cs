using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U2.Data.Client;
using System.Data;

namespace Subroutine
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
                string s = conn_str.ToString();
                U2Connection con = new U2Connection();
                con.ConnectionString = s;
                con.Open();
                Console.WriteLine("Connected.........................");
                U2Command command = con.CreateCommand();
                command.CommandText = "CALL GETXMLSUB(?,?,?,?,?,?)"; // UniData subroutine

                command.Parameters.Clear();

                command.CommandType = CommandType.StoredProcedure;
                U2Parameter p1 = new U2Parameter();
                p1.Direction = ParameterDirection.InputOutput;

                p1.Value = "LIST STUDENT";
                p1.ParameterName = "@arg1";

                U2Parameter p2 = new U2Parameter();
                p2.Direction = ParameterDirection.InputOutput;
                p2.Value = "";
                p2.ParameterName = "@arg2";


                U2Parameter p3 = new U2Parameter();
                p3.Direction = ParameterDirection.InputOutput;
                p3.Value = "";
                p3.ParameterName = "@arg3";


                U2Parameter p4 = new U2Parameter();
                p4.Direction = ParameterDirection.InputOutput;
                p4.Value = "";
                p4.ParameterName = "@arg4";

                U2Parameter p5 = new U2Parameter();
                p5.Direction = ParameterDirection.InputOutput;
                p5.Value = "";
                p5.ParameterName = "@arg5";

                U2Parameter p6 = new U2Parameter();
                p6.Direction = ParameterDirection.InputOutput;
                p6.Value = "";
                p6.ParameterName = "@arg6";


                command.Parameters.Add(p1);
                command.Parameters.Add(p2);
                command.Parameters.Add(p3);
                command.Parameters.Add(p4);
                command.Parameters.Add(p5);
                command.Parameters.Add(p6);

                command.ExecuteNonQuery();

                string s1 = command.Parameters[0].Value.ToString();//command
                string s2 = command.Parameters[1].Value.ToString();// command option
                string s3 = command.Parameters[2].Value.ToString(); // xml
                string s4 = command.Parameters[3].Value.ToString(); //xsd
                string s5 = command.Parameters[4].Value.ToString(); // msg #
                string s6 = command.Parameters[5].Value.ToString(); // msg description

                Console.WriteLine("Subroutine Output:" + s3 + Environment.NewLine);
                Console.WriteLine("Subroutine Output:" + s4 + Environment.NewLine);

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
