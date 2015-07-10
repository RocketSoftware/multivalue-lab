/*****************************************************************************************
 * Rocket Software.
 *
 * Copyright (c) Rocket Software. All Rights Reserved.
 *
 * This software is confidential and proprietary information belonging to
 * Rocket Software. It is the property of Rocket Software. and is protected
 * under the Copyright Laws of the United States of America.  No part of this
 * software may be copied or used in any form without the prior
 * written permission of Rocket Software.
 *
 *****************************************************************************************
 *
 * R E V I S I O N   L O G
 *
 * $Log: Demo.java,v $
 * Revision 1.3  2014/01/31 21:24:05  hesam
 * Changed package name rocket to rocketsoftware.
 *
 * Revision 1.2  2009/12/08 20:57:01  hesam
 * Use upcase WHERE command for MVBASE.
 * Use "California" instead of "CALIFORNIA" in selection clause of executeQuery to work with MVBASE.
 * Use PRODUCTID instead of CUSTOMERID.
 *
 * Revision 1.1  2009/11/01 20:16:49  hesam
 * Created.
 *
 * Revision 1.3  2009/08/27 23:12:24  hesam
 * Added executeQuery with column names passed in an array.
 *
 * Revision 1.2  2009/07/30 01:00:50  hesam
 * updates
 *
 * Revision 1.1  2009/07/29 23:57:47  hesam
 * class to show executeQuery usage.
 *
 *
 ****************************************************************************************/

import com.rocketsoftware.mvapi.MVConnection;
import com.rocketsoftware.mvapi.MVStatement;
import com.rocketsoftware.mvapi.exceptions.MVException;
import com.rocketsoftware.mvapi.ResultSet.MVResultSet;

/**
 * Demonstrates using MVAPI to connect to a D3 Server, execute queries and return the results.
 * uses executeQuery() to return result set in columns.
 */
public class Demo
{
    public static void main(String [] args)
    {

        if (args.length != 3)
        {
            System.out.println("usage: hostname port username");
            return;
        }
        String hostName = args[0];
        String port = args[1];
        String userName = args[2];
        int portNumber = Integer.parseInt(port);

        demo_execute(hostName, portNumber, userName, "");
        demo_query(hostName, portNumber, userName, "");

    }

    /**
     * Demo execute and executeQuery.
     * @param hostName
     * @param portNumber
     * @param userName
     * @param pwd
     */
    public static void demo_query(String hostName, int portNumber, String userName, String pwd)
    {
        MVConnection connection = null;
        try
        {
            connection = new MVConnection(hostName, portNumber, userName, pwd);

            System.out.println("Connection properties: " + connection.getConnectionProperties());

            MVStatement mvStatement = connection.createStatement();
            connection.logTo("MVDEMO", "");

            /**
             * Generate an active list, the result set will have the result
             * of the select query:  404^[404] 10 items selected out of 100 items.
             */
            String query = "SELECT CUSTOMERS";
            System.out.println(query);
            MVResultSet results = mvStatement.executeQuery(query);
            while (results.next())
            {
                System.out.println(results.getCurrentRow());
            }

            results = mvStatement.executeQuery("CUSTOMERS",
                    "WITH STATE = \"California\"",                 // selection criteria
                    "BY ORGANIZATIONNAME",                 // sort order
                    "CUSTOMERID ORGANIZATIONNAME ADDRESS CITY STATE CONTACTNAME PHONENUMBER",
                    "");


            /**
             * Display columns in result set
             */
            int columnCount = results.getColumnCount();
            String [] columns = results.getColumns();
            System.out.println("resultSet has " + columnCount + " columns.");
            for (int i=0;i<columnCount;i++)
            {
                System.out.println(i + " " + columns[i] + " ");
            }

            /**
             * Display data in result set
             */
            System.out.println("resultSet rows:");
            while (results.next())
            {
                System.out.println(results.getCurrentRow());

                /**
                 * row columns start at 1.
                 */
                int columnNumber = 1;
                while (columnNumber <= columnCount)
                {
                    System.out.println("column " + columnNumber + ": " + results.getString(columnNumber) + " ");
                    columnNumber++;
                }

                /**
                 * Retrieve column data using getString("columnname")
                 */
                System.out.println("results.getString(\"CUSTOMERID\"): " + results.getString("CUSTOMERID"));

            }
        }
        catch (MVException e)
        {
            System.out.println(e.getMessage());
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

    /**
     * Demo execute and executeQuery.
     * @param hostName
     * @param portNumber
     * @param userName
     * @param pwd
     */
    public static void demo_execute(String hostName, int portNumber, String userName, String pwd)
    {
        MVConnection connection = null;
        try
        {
            connection = new MVConnection(hostName, portNumber, userName, pwd);

            System.out.println("Connection properties: " + connection.getConnectionProperties());

            MVStatement mvStatement = connection.createStatement();
            connection.logTo("MVDEMO", "");
            connection.execute("WHERE");
            String capturing = connection.getExecuteCapturing();
            String returning = connection.getExecuteReturning();
            System.out.println("capturing: " + capturing);
            System.out.println("returning: " + returning);
        }
        catch (MVException e)
        {
            System.out.println(e.getMessage());
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
