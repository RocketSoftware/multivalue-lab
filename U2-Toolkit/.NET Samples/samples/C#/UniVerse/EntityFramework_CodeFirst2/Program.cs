using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework_CodeFirst2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("start");
                CustomerContext ctx = new CustomerContext();
                
                 var t = ctx.Database.SqlQuery<Customer>("SELECT CUSTID,FNAME,LNAME,FULLADDR FROM CUSTOMER");
                foreach (Customer item in t)
                {
                    Console.WriteLine(item.CUSTID + "=>" + item.FNAME + "=>" + item.LNAME + "=>" + item.FULLADDR);
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
                else
                {
                    Console.WriteLine(e.Message);
                }

            }
            finally
            {
                Console.WriteLine("Enter to exit:");
                string line = Console.ReadLine();
            }
           

        }
    }
}
