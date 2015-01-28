using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Data.Client;

namespace Execute_U2Subroutine
{
    public class Exec_Async_Subroutine_Objects
    {
        public static async Task<List<Employee>> CallSubroutine()
        {

            try
            {
                List<Employee> lRetEmpList = new List<Employee>();

                U2Connection conn = CreateConnection.GetConnection();
                await conn.OpenAsync();
                U2Command command = conn.CreateCommand();
                Console.WriteLine("Connected.........................");

                command.CommandText = "CALL *HS.SALES*SELECT_SUBROUTINE(?,?)"; // UniVerse subroutine, returns multi-value data

                command.Parameters.Clear();

                command.CommandType = CommandType.StoredProcedure;
                U2Parameter p1 = new U2Parameter();
                p1.Direction = ParameterDirection.InputOutput;

                p1.Value = "1";//INPUT
                p1.ParameterName = "@arg1";

                U2Parameter p2 = new U2Parameter();
                p2.Direction = ParameterDirection.InputOutput;
                p2.Value = "";//OUTPUT (multi-value data
                p2.ParameterName = "@arg2";

                command.Parameters.Add(p1);
                command.Parameters.Add(p2);

                await command.ExecuteNonQueryAsync();

                string s1 = command.Parameters[0].Value.ToString();//INPUT
                string s2 = command.Parameters[1].Value.ToString();// OUTPUT
                lRetEmpList= p2.MV_To_POCO<Employee>();//Convert multi-value data to C# POCO Class using Schema
                conn.Close();
                return lRetEmpList;
            }
            catch (Exception ee)
            {
                string lErr = ee.Message;
                throw;
            }

        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
    }
}
