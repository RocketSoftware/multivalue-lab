using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework_ExecuteStoreQuery_UNNEST
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomerContainer ctx = new CustomerContainer();
                var q = ctx.ExecuteStoreQuery<CUSTOMER_MV>("SELECT * FROM UNNEST CUSTOMER ON ORDERS");
                //CUSTID is 'S'
                //FNAME is   'S'
                //PRODID is 'M'
                //DESCRIPTION is 'M'
                foreach (var item in q)
                {

                    Console.WriteLine(item.CUSTID + "=>" + item.FNAME + "=>" + item.PRODID + "=>" + item.DESCRIPTION);
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
