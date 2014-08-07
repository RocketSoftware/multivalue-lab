using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U2.Data.Client;

namespace DataReader
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                U2ConnectionStringBuilder conn_str = new U2ConnectionStringBuilder();
                conn_str.UserID = "user";
                conn_str.Password = "pass";
                conn_str.Server = "localhost";
                conn_str.Database = "demo";
                conn_str.ServerType = "UNIDATA";
                conn_str.Pooling = false;
                string s = conn_str.ToString();
                U2Connection con = new U2Connection();
                con.ConnectionString = s;
                con.Open();
                Console.WriteLine("Connected.........................");
                U2Command cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM STUDENT_NF_SUB";
                U2DataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string s1 = string.Format("FNAME={0}     LNAME={1}", dr["FNAME"], dr["LNAME"] + Environment.NewLine);
                    Console.WriteLine(s1);
                }
                
                con.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
            finally
            {
                Console.WriteLine("Enter to exit:");
                string line = Console.ReadLine();
            }
           
        }
    }
}
