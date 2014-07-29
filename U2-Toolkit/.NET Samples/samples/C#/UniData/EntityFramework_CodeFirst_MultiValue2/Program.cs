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

            try
            {
                Console.WriteLine("start");
                StudentContext ctx = new StudentContext();
                Database.SetInitializer<StudentContext>(null);

                //var q2 = ctx.Product3s.ToList();
                var q2 = from p in ctx.Students
                         
                         select new
                         {
                             p.StudentID,
                             p.FirstName,
                             p.LastName

                         };

                int i = 0;
                foreach (var item in q2)
                {

                    Console.WriteLine(item.StudentID + "=>" + item.FirstName + "=>" + item.LastName);                    i++;

                    var q3 = from p in ctx.Semesters
                             where p.StudentID == item.StudentID
                             select new
                             {
                                 p.StudentID,
                                 p.StudentSemester

                             };
                    foreach (var item2 in q3)
                    {
                        Console.WriteLine("\t" + "\t" + "\t" + item2.StudentID + "=>" + item2.StudentSemester);
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
