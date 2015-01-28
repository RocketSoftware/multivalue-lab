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
                Student2Container ctx = new Student2Container();
            var result = ctx.ExecuteStoreQuery<Student2_UNNEST>("SELECT * FROM STUDENT UNNEST NL_ALL CGA ;");

            foreach (var item in result)
            {
                // ID is 'S'
                // LNAME is 'S'
                // SEMESTER is 'M'
                Console.WriteLine(item.ID +"=>"+item.LNAME +"=>"+ item.SEMESTER);
            }
            }
            catch (Exception e)
            {
                
                string s = e.Message;
                if (e.InnerException != null)
                {
                    s += e.InnerException.Message;
                }

                Console.WriteLine(s);
            }
            finally
            {
                Console.WriteLine("Enter to exit:");
                string line = Console.ReadLine();
            }


        }
    }
}
