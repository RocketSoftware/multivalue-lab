using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Data.Client;

namespace Execute_U2Subroutine
{
    public class Exec_Async_Subroutine_DataTable
    {
                
        public static async Task<DataTable> CallSubroutine()
        {

            try
            {
                DataTable lRetDT = new DataTable("EmpTable");
                lRetDT.Columns.Add("ID", typeof(Int32));
                lRetDT.Columns.Add("Name", typeof(string));
                lRetDT.Columns.Add("HireDate", typeof(DateTime));

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
                p2.MV_To_DataTable(lRetDT);//Convert multi-value data to C# DataTable using Schema
                conn.Close();
                return lRetDT;
            }
            catch (Exception ee)
            {
                string lErr = ee.Message;
                throw;
            }

        }
    }
}
