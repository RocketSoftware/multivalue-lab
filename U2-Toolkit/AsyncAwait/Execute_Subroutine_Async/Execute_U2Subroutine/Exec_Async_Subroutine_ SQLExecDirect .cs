using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Data.Client;

namespace Execute_U2Subroutine
{
    public class Exec_Async_Subroutine_SQLExecDirect
    {
        public static async Task<List<Customer>> CallSubroutine()
        {
            try
            {
                List<Customer> lRetList = new List<Customer>();
                U2Connection conn = CreateConnection.GetConnection();
                await conn.OpenAsync();
                U2Command command = conn.CreateCommand();
                
                Console.WriteLine("Connected.........................");
                command.CommandText = "CALL *HS.SALES*GETCUSTOMER()"; // UniVerse subroutine, returns multi-value data
                U2DataReader dr = await command.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Customer lCust = new Customer();
                    lCust.CustomerId = await dr.GetFieldValueAsync<int>(0);
                    lCust.FirstName = await dr.GetFieldValueAsync<string>(1);
                    lCust.LastName = await dr.GetFieldValueAsync<string>(2);
                    lRetList.Add(lCust);
                }
                conn.Close();
                return lRetList;
            }
            catch (Exception ee)
            {
                string lErr = ee.Message;
                throw;
            }

        }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
