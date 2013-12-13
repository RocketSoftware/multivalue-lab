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
                StudentContainer ctx = new StudentContainer();
            var lstudents = from s in ctx.Students
                            select s;

            foreach (var item in lstudents)
            {
                Console.WriteLine(item.ID + "=>" + item.LNAME);

                var lsemesters = from s2 in ctx.Semesters
                                 where s2.ID == item.ID
                                 select s2;
                foreach (var item2 in lsemesters)
                {
                    Console.WriteLine("\t"+"\t"+item2.CGA_MV_KEY + "=>" + item2.SEMESTER);

                    var lcourses = from s3 in ctx.Courses
                                     where s3.ID == item2.ID && s3.CGA_MV_KEY == item2.CGA_MV_KEY
                                     select s3;

                    foreach (var item3 in lcourses)
                    {
                        Console.WriteLine("\t" + "\t"+ "\t" + "\t"+ item3.CGA_MS_KEY + "=>" + item3.COURSE_NAME);
                    }
                }
                
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
