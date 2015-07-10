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
 * $Log: DemoColumns.java,v $
 * Revision 1.6  2014/01/31 21:24:28  hesam
 * Changed package name rocket to rocketsoftware.
 *
 * Revision 1.5  2010/04/29 23:10:03  hesam
 * AI 34540, use MVDEMO account.
 *
 * Revision 1.4  2009/11/30 23:23:29  hesam
 * Allow password on the command line.
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

import java.util.Properties;
import java.io.IOException;

/**
 * Demonstrates using MVAPI to connect to a D3 Server, execute queries and return the results.
 * uses executeQuery() to return result set in columns.
 */
public class DemoColumns
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
        Properties props = new Properties();
        props.setProperty("username", userName);
        props.setProperty("password", "");
        String url = "jdbc:mv:d3:" + hostName + ":" + port;
        String account = "MVDEMO";

        MVConnection connection = null;
        try
        {
            connection = new MVConnection(url, props);

            MVStatement mvStatement = connection.createStatement();
            connection.logTo(account, "");

            /**
             * Generate an active list, the result set will have the result
             * of the select query:  404^[404] 6 items selected out of 50 items.
             */
            String query = "SELECT CUSTOMERS WITH STATE = \"California\"";
            System.out.println(query);
            MVResultSet results = mvStatement.executeQuery(query);
            while (results.next())
            {
                System.out.println(results.getCurrentRow());
            }

            /**
             * select customers.
             *
             * This select will use the active list to select and
             * sort items then return the requested columns.
             *
             * executeQuery() Javadocs:
             *
             * Executes a query with the provided selection and sort criteria, then
             * returns the requested columns.
             * @param filename The filename to query
             * @param selectionCriteria selection criteria in the native syntax
             * for example: WITH ORDERDATE >= "07/01/09" AND WITH EMPLOYEEID = "10"
             * @param sortCriteria sort criteria in the native syntax
             * for example BY ORDERDATE BY CUSTOMERID
             * @param ADIList Attribute Defining items to populate the resultset
             * for example ORDERDATE CUSTOMERID EMPLOYEEID PRODUCTID QUANTITY UNITPRICE
             *
             * Each row in the resultset will contain an attribute mark delimited string
             * representing the returned item. To retrieve individual columns, use
             * the getString(columnNumber) with columnNumber corresponding to an ADI in the
             * ADIList parameter. You can also use getString("COLUMNNAME").
             * For example getString(4) or getString("PRODUCTID") will return the PRODUCTID.
             * If the column contains multivalues or subvalues, they can be extracted using
             * the MVString class, for example:
             * String productID = resultSet.getString(4);
             * String value = MVString.extract(productID, 1, 2); // attribute 1, value 2
             *
             * @return MVResultSet ResultSet containing the result of this query.
             * @throws MVException raised if any errors occur
             */

// Alternate forms of executeQuery:
//
// This one takes the column names as one string:
//
//            results = mvStatement.executeQuery("CUSTOMERS",
//                    "BY ORGANIZATIONNAME",
//                    "WITH CITY = \"Los Angeles\" ",
//                    "CUSTOMERID ORGANIZATIONNAME ADDRESS CITY STATE",
//                    "");
//
// This one takes the column names in an array:
//
            String [] ADIs = {"CUSTOMERID", "ORGANIZATIONNAME", "ADDRESS", "CITY", "STATE"};
            results = mvStatement.executeQuery("CUSTOMERS",              // file
                   "WITH STATE = \"California\"",                        // selection criteria
                    "BY ORGANIZATIONNAME",                               // sort order
                        ADIs);                                           // result columns

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
                 * Retrieve column data using getString("columname")
                 */
                System.out.println("results.getString(\"ORGANIZATIONNAME\"): " + results.getString("ORGANIZATIONNAME"));

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
}
