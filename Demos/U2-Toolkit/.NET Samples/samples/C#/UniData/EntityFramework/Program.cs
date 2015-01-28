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

            //first
            StudentContainer ctx = new StudentContainer();
            try
            {
                var q = from c in ctx.Students //LINQ Query
                        select c;

                List<Student> StudentList = q.ToList();

                foreach (Student item in StudentList)
                {
                    Console.WriteLine(item.FNAME);

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
