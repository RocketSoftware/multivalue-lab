using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace EntityFramework_Subroutine
{
    class Program
    {
        static void Main(string[] args)
        {
            //first
            StudentContainer ctx = new StudentContainer();
            try
            {

                var outputParameter1 = new ObjectParameter("RESULT", typeof(string));
                outputParameter1.Value = "";

                var outputParameter2 = new ObjectParameter("arg_xsd", typeof(string));
                outputParameter2.Value = "";

                var outputParameter3 = new ObjectParameter("arg_errnum", typeof(string));
                outputParameter3.Value = "";

                var outputParameter4 = new ObjectParameter("arg_errmsg", typeof(string));
                outputParameter4.Value = "";

                ctx.GetXmlSubroutine("LIST STUDENT ALL", "", outputParameter1, outputParameter2, outputParameter3, outputParameter4);

                string sXmlData = (string) outputParameter1.Value;
                string sXsdData = (string)outputParameter2.Value;
                string sErrNum = (string)outputParameter3.Value;
                string sErrMsg = (string)outputParameter4.Value;

                Console.WriteLine(sXmlData);
               
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
