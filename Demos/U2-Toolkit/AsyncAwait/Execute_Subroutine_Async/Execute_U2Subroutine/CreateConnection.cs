using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Data.Client;

namespace Execute_U2Subroutine
{
    public class CreateConnection
    {
        public static U2Connection GetConnection()
        {
            U2ConnectionStringBuilder l = new U2ConnectionStringBuilder();
            l.UserID = "admin";
            l.Password = "pass";
            l.Server = "9.21.45.89";
            l.Database = "HS.SALES";
            l.ServerType = "universe";
            l.Connect_Timeout = 360;
            l.AccessMode = "Uci";

            string lconnstr = l.ToString();
            U2Connection conn = new U2Connection();
            conn.ConnectionString = lconnstr;
            return conn;
        }
    }
}
