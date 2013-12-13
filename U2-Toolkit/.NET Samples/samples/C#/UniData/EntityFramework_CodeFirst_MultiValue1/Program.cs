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
                StudentContext ctx = new StudentContext();
                Database.SetInitializer<StudentContext>(null);
                //var q2 = ctx.Students.ToList();

                var q2 = from p in ctx.Students
                         select new
                         {
                             p.StudentID,
                             p.FirstName,
                             p.LastName,
                             p.Semester

                         };

                foreach (var item in q2)
                {
                    Console.WriteLine(item.StudentID+ "=>" + item.FirstName + "=>" + item.LastName + "=>" + item.Semester);

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
