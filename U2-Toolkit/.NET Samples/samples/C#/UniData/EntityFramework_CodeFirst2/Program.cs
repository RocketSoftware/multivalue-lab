using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework_CodeFirst2
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("start");
                StudentContext ctx = new StudentContext();

                var t = ctx.Database.SqlQuery<Student>("SELECT ID,FNAME,LNAME,MAJOR,MINOR FROM STUDENT_NF_SUB");
                foreach (Student item in t)
                {
                    Console.WriteLine(item.ID + "=>" + item.FNAME + "=>" + item.LNAME + "=>" + item.MAJOR + "=>" + item.MINOR);
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
