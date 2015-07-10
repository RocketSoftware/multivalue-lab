import com.rocketsoftware.mvapi.MVConnection;
import com.rocketsoftware.mvapi.MVStatement;
import com.rocketsoftware.mvapi.MVConstants;
import com.rocketsoftware.mvapi.ResultSet.MVResultSet;
import com.rocketsoftware.mvapi.exceptions.MVException;

import java.util.Properties;
import java.io.IOException;

/**
 * Demonstrates using MVAPI to connect to a D3 Server, execute queries and return the results.
 */
public class Main
{
    public static void main(String [] args)
    {

        if (args.length < 3)
        {
            System.out.println("usage: hostname port username password");
            return;
        }
        String hostName = args[0];
        String port = args[1];
        String userName = args[2];
        Properties props = new Properties();
        props.setProperty("username", userName);
        String password = "";
        if (args.length > 3)
        {
            password = args[3];
        }
        props.setProperty("password", password);
        String url = "jdbc:mv:d3:" + hostName + ":" + port;
        String account = "MVDEMO";
        String AM = MVConstants.AM;
        String query;
        MVConnection connection = null;
        try
        {
            connection = new MVConnection(url, props);

            /**
             * Execute a query and display the results:
             */
            MVStatement mvStatement = connection.createStatement();
            connection.logTo(account, "");
            query =
            "LIST CUSTOMERS CUSTOMERID ORGANIZATIONNAME" +
                    " ADDRESS CITY STATE POSTALCODE" +
                    " CONTACTNAME CONTACTTITLE PHONENUMBER FAXNUMBER NOTE (I";
            boolean result = mvStatement.execute(query);
            MVResultSet results = mvStatement.getResultSet();
            while (results.next())
            {
                String row = results.getCurrentRow();
                System.out.println(row);
            }

            /**
             * Call a subroutine passing it some values then read the results:
             */
            String subName;
            String parameters;
            /**
             * subroutine name:
             */
            subName = "DEMO1.SUB";

            /**
             * Subroutine parameters:
             */
            parameters = "1" + AM + "2";
            query = subName + AM + parameters;
            mvStatement.execute(query);

            results = mvStatement.getResultSet();
            while (results.next())
            {
                String row = results.getCurrentRow();
                System.out.println(row);
            }

            /**
             * subroutine name:
             */
            subName = "DEMO2.SUB";

            /**
             * Subroutine parameters:
             */
            parameters = "HELLO WORLD";
            query = subName + AM + parameters;
            mvStatement.execute(query);

            results = mvStatement.getResultSet();
            while (results.next())
            {
                String row = results.getCurrentRow();
                System.out.println(row);
            }

        }
        catch (MVException e)
        {
            e.printStackTrace();
        }
        finally
        {
            if (connection != null)
            {
                try
                {
                    connection.close();
                }
                catch (MVException e)
                {
                    e.printStackTrace();
                }
            }
        }
    }
}
