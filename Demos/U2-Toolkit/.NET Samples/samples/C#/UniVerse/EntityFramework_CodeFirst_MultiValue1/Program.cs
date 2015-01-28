using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace EntityFramework_CodeFirst_MultiValue1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("start");
                CustomerContext ctx = new CustomerContext();
                //var q2 = ctx.Customers2.ToList();
                Database.SetInitializer<CustomerContext>(null);

                var q2 = from p in ctx.Customers
                         select new
                         {
                             p.ID,
                             p.FirstName,
                             p.LastName,
                             p.Price,
                             p.BuyDate

                         };

                foreach (var item in q2)
                {
                    Console.WriteLine(item.ID + "=>" + item.FirstName + "=>" + item.LastName + "=>" + item.Price + "=>" + item.BuyDate);

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
