using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //first
                CustomerContainer ctx = new CustomerContainer();
                try
                {
                    var q = from c in ctx.CUSTOMERS
                            select c;

                    List<CUSTOMER> CustList = q.ToList();

                    foreach (CUSTOMER item in CustList)
                    {
                        Console.WriteLine(item.FNAME);

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


                // second ( multi-value)
                CustomerContainer ctx2 = new CustomerContainer();

                try
                {
                    var result = ctx2.ExecuteStoreQuery<CUSTOMER_MV>("SELECT * FROM UNNEST CUSTOMER ON ORDERS");

                    List<CUSTOMER_MV> CustList = result.ToList();

                    foreach (CUSTOMER_MV item in CustList)
                    {
                        Console.WriteLine(item.FNAME);

                    }
                }
                catch (Exception e2)
                {

                    Console.WriteLine(e2.Message);
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
