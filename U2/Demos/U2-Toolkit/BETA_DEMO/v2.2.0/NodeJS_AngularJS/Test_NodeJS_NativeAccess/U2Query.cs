using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Data.Client;

namespace Test_NodeJS_NativeAccess
{
    public class U2Query
    {

        public async Task<object> Invoke(object input)
        {
          //  Debugger.Break();
           // Debugger.Launch();
            // Edge marshalls data to .NET using an IDictionary<string, object>
            var payload = (IDictionary<string, object>)input;
            var pageNumber = (int)payload["pageNumber"];// we do not use it
            var pageSize = (int)payload["pageSize"];
            return await QueryUsers(pageNumber, pageSize);
        }
        public async Task<object> Invoke_Update(object input)
        {

           // Debugger.Launch();
            // Edge marshalls data to .NET using an IDictionary<string, object>
            return await UpdateUser(input);
        }
        public async Task<string> UpdateUser(object customer)
        {
            int lRet = -1;
            try
            {
                var cust = (IDictionary<string, object>)customer;
                foreach (var property in (IDictionary<String, Object>)cust)
                {
                    Console.WriteLine(property.Key + ": " + property.Value);
                    var t1 = property.Key;
                    var t2 = property.Value;
                }
                U2ConnectionStringBuilder l = new U2ConnectionStringBuilder();
                l.UserID = "admin";
                l.Password = "u2";
                l.Server = "192.168.102.132";
                l.Database = "HS.SALES";
                l.ServerType = "universe";
                l.Connect_Timeout = 360;
                l.RpcServiceType = "uvcs";
                l.AccessMode = "Native";

                string lconnstr = l.ToString();
                U2Connection c = new U2Connection();
                c.ConnectionString = lconnstr;
                await c.OpenAsync();
                U2Command cmd = c.CreateCommand();
                //cmd.CommandText = string.Format("Action=Select;File=CUSTOMER;Attributes=CUSTID,FNAME,LNAME,PRODID,BUY_DATE;Where=CUSTID>0;Sort=CUSTID");
                //cmd.CommandText = string.Format("Action=Update;File=CUSTOMER;Attributes=FNAME={0},LNAME={1},DISCOUNT{2};Where=CUSTID={3}", cust["FNAME"], cust["LNAME"], cust["DISCOUNT"], cust["CUSTID"]);
                cmd.CommandText = string.Format("Action=Update;File=CUSTOMER;Attributes=FNAME={0},LNAME={1};Where=CUSTID={2}", cust["FNAME"], cust["LNAME"], cust["CUSTID"]);
                lRet = await cmd.ExecuteNonQueryAsync();
                c.Close();
            }
            catch (Exception ee)
            {
                throw ee;
            }
            return "200";
        }
        public async Task<string> QueryUsers(int pageNumber, int pageSize)
        {
            
            string lRetJsonData = string.Empty;
            
            try
            {
                U2ConnectionStringBuilder l = new U2ConnectionStringBuilder();
                l.UserID = "admjjin";
                l.Password = "u2";
                l.Server = "192.168.102.132";
                l.Database = "HS.SALES";
                l.ServerType = "universe";
                l.Connect_Timeout = 360;
                l.RpcServiceType = "uvcs";
                l.AccessMode = "Native";
                
                string lconnstr = l.ToString();
                U2Connection c = new U2Connection();
                c.ConnectionString = lconnstr;
                await c.OpenAsync();
                U2Command cmd = c.CreateCommand();
                cmd.CommandText = string.Format("Action=Select;File=CUSTOMER;Attributes=CUSTID,FNAME,LNAME,PRODID,BUY_DATE;Where=CUSTID>0;Sort=CUSTID");
                lRetJsonData  = await cmd.ExecuteJsonAsync();
                
               
                c.Close();
            }
            catch (Exception ee)
            {
                throw ee;
            }
            return lRetJsonData;
        }
    }
}
