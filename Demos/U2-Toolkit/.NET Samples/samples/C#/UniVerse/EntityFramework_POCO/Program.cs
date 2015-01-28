using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework_POCO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomerContainer ctx = new CustomerContainer();

                var q = from c in ctx.CUSTOMERS
                        orderby c.CUSTID
                        select c;

                foreach (var item in q)
                {
                    Console.WriteLine(item.CUSTID + "=>" + item.FNAME);

                }
            }
            catch (Exception e3)
            {

                Console.WriteLine(e3.Message);
            }
            finally
            {
                Console.WriteLine("Enter to exit:");
                string line = Console.ReadLine();
            }

           
        }
    }
}
