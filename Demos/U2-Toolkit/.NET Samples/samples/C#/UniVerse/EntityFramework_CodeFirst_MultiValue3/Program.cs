using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace EntityFramework_CodeFirst_MultiValue3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // SELECT
                Console.WriteLine("start");
                CustomerContext ctx = new CustomerContext();
                var q = ctx.Customers.ToList();
                foreach (var item in q)
                {
                    Console.WriteLine(item.CUSTID + "   "+item.FirstName + "   "
                        + item.Price + "   " + item.BuyDate + "   " + item.ASSOC_ROW);

                }

                //SAVE (UPDATE)
                // multi-value update single row
                Customer c1 = ctx.Customers.FirstOrDefault();
                c1.BuyDate = DateTime.Parse("01/01/2013");
                var entityInDb = ctx.Entry<Customer>(c1);
                var lCurrentValues = entityInDb.CurrentValues;
                var lOriginalValues = entityInDb.OriginalValues;
                DateTime dt2 = lOriginalValues.GetValue<DateTime>("BuyDate");
                ctx.Entry<Customer>(c1).Property(u => u.BuyDate).IsModified = true;
                Object[] parameters = { DateTime.Parse("01/01/2013"), 2, dt2};
                ctx.Database.ExecuteSqlCommand("UPDATE CUSTOMER SET BUY_DATE = ?  WHERE CUSTID = ? WHEN BUY_DATE = ? ", parameters);


                //SAVE (UPDATE)
                // multi-value update all rows
                object parameters21 = "<'01/09/2001','09/01/2002','02/13/2003'>";
                object parameters22 = "2";
                string lSQl = string.Format("UPDATE CUSTOMER SET BUY_DATE = {0}  WHERE CUSTID = {1}  ", parameters21, parameters22);
                ctx.Database.ExecuteSqlCommand(lSQl);
                                
                //var result = ctx.Customers.Select(i => new { CUSTID=i.CUSTID,BUYDATE=i.BuyDate }).Where(p=>p.CUSTID==2);
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
