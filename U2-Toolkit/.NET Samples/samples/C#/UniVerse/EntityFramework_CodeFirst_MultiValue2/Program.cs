using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace EntityFramework_CodeFirst_MultiValue2
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                {
                    try
                    {
                        Console.WriteLine("start");
                        CustomerContext ctx = new CustomerContext();
                        Database.SetInitializer<CustomerContext>(null);

                        //var q2 = ctx.Product3s.ToList();
                        var q2 = from p in ctx.Customers

                                 select new
                                 {
                                     p.ID,
                                     p.FirstName,
                                     p.LastName

                                 };

                        int i = 0;
                        foreach (var item in q2)
                        {
                            Console.WriteLine(item.ID + "=>" + item.FirstName + "=>" + item.LastName);
                            i++;

                            var q3 = from p in ctx.Orders
                                     where p.ID == item.ID
                                     select new
                                     {
                                         p.BuyDate,
                                         p.Price

                                     };
                            foreach (var item2 in q3)
                            {
                                Console.WriteLine("\t" + "\t" + "\t" + item2.BuyDate + "=>" + item2.Price);
                            }



                        }
                        Console.WriteLine("# of Rows:" + i);
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
    }
}
