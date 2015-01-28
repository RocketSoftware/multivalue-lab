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

            try
            {
                //first Sample
                CustomerContainer ctx = new CustomerContainer();
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

                    ctx.GetXmlSubroutine("LIST CUSTOMER", "", outputParameter1, outputParameter2, outputParameter3, outputParameter4);

                    string sXmlData = (string)outputParameter1.Value;
                    string sXsdData = (string)outputParameter2.Value;
                    string sErrNum = (string)outputParameter3.Value;
                    string sErrMsg = (string)outputParameter4.Value;

                    Console.WriteLine(sXmlData);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }




                //Second Sample

                // make sure you have subroutine GETCUSTOMER compiled and catalog

                //STEPS

                // 1 . Create a BP directory
                // 2.  ED BP GETCUSTOMER
                // 3.  Cut and paste the following subroutine
                // 4.  BASIC BP GETCUSTOMER
                // 5.  CATALOG BP GETCUSTOMER

                // SUBROUTINE GETCUSTOMER
                //$INCLUDE UNIVERSE.INCLUDE ODBC.H
                //SELSTMT = "SELECT *  FROM CUSTOMER"
                //ST = SQLExecDirect(@HSTMT, SELSTMT)
                //RETURN




                CustomerContainer ctx2 = new CustomerContainer();
                try
                {

                    var q = ctx2.GetCustomer();
                    List<CUSTOMER> lCustList = q.ToList();

                    foreach (CUSTOMER item in lCustList)
                    {
                        Console.WriteLine(item.FNAME);
                    }



                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }
            catch (Exception)
            {
                
                
            }
            finally
            {
                Console.WriteLine("Enter to exit:");
                string line = Console.ReadLine();
            }
            
        }
    }
}
