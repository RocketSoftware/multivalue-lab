using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace EntityFramework_CodeFirst
{
    
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("start");
                Database.SetInitializer<CustomerContext>(null);
                CustomerContext ctx = new CustomerContext();
                ctx.Configuration.LazyLoadingEnabled = true;
                

                var t = ctx.Customers.ToList().Take(5);
                
                foreach (Customer item in t)
                {
                    Console.WriteLine(item.CUSTID + item.FNAME);
                    var q2 = from o in ctx.Orders
                             where o.CUSTID == item.CUSTID
                             select o;
                    
                    foreach (var item2 in q2)
                    {
                        
                        Console.WriteLine("\t"+item2.PRODID+"=>"+item2.SER_NUM);
                    }
                    
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
