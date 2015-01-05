using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Data.Client;

namespace Execute_U2Subroutine
{
    public class Exec_Async_Subroutine
    {
        public static async Task<string> CallSubroutine()
        {
            
            try
            {
                string lRet = string.Empty;
                
                U2Connection conn = CreateConnection.GetConnection();
                await conn.OpenAsync();
                U2Command command = conn.CreateCommand();
                Console.WriteLine("Connected.........................");

                command.CommandText = "CALL *GETXMLSUB(?,?,?,?,?,?)"; // UniVerse subroutine

                command.Parameters.Clear();

                command.CommandType = CommandType.StoredProcedure;
                U2Parameter p1 = new U2Parameter();
                p1.Direction = ParameterDirection.InputOutput;

                p1.Value = "LIST CUSTOMER";
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

                await command.ExecuteNonQueryAsync();

                string s1 = command.Parameters[0].Value.ToString();//INPUT command
                string s2 = command.Parameters[1].Value.ToString();// INPUT command option
                string lOutputValue = command.Parameters[2].Value.ToString(); // OUTPUT xml
                string s4 = command.Parameters[3].Value.ToString(); //OUTPUT xsd
                string s5 = command.Parameters[4].Value.ToString(); //OUTPUT  msg #
                string s6 = command.Parameters[5].Value.ToString(); //OUTPUT  msg description

               
                conn.Close();
                return lOutputValue;
            }
            catch (Exception ee)
            {
                string lErr = ee.Message;
                throw;
            }

        }
    }

    
}
