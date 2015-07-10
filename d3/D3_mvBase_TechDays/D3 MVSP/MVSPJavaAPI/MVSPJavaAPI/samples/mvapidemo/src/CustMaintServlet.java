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
 * $Log: CustMaintServlet.java,v $
 * Revision 1.2  2014/01/31 21:23:11  hesam
 * Changed package name rocket to rocketsoftware.
 *
 * Revision 1.1  2010/07/14 22:00:20  hesam
 * no message
 *
 *
 ****************************************************************************************/

import com.rocketsoftware.mvapi.MVConnection;
import com.rocketsoftware.mvapi.MVConstants;
import com.rocketsoftware.mvapi.MVStatement;
import com.rocketsoftware.mvapi.ResultSet.MVResultSet;
import com.rocketsoftware.mvapi.exceptions.MVException;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.ServletException;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Hashtable;
import java.util.Map;
import java.util.Iterator;

public class CustMaintServlet extends HttpServlet
{
    private final static String[] m_fieldNames = {
            "Customer ID",
            "Contact Name",
            "Contact Title",
            "Organization Name",
            "Address",
            "City",
            "State",
            "Postal Code",
            "Phone Number",
            "Fax Number",
            "Note"
    };

    private final static String[] m_fieldIds = {
            "CustomerID_input",
            "ContactName_input",
            "ContactTitle_input",
            "OrganizationName_input",
            "Address_input",
            "City_input",
            "State_input",
            "PostalCode_input",
            "PhoneNumber_input",
            "FaxNumber_input",
            "Note_input"
    };

    private final static int[] m_fieldNumbers = {
            0,
            6,
            7,
            1,
            2,
            3,
            4,
            5,
            8,
            9,
            10
    };

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        PrintWriter out = response.getWriter();
        String result = process(request.getParameterMap());
        out.write(result);
        out.flush();
        out.close();
    }

    private static String getParameter(Map<String, String[]> params, String key)
    {
        String [] values;
        String value = null;
        values = params.get(key);
        if (values != null)
        {
            value = values[0];
        }
        return value;
    }

    private static String process(Map<String, String[]> params)
    {
        StringBuilder sb = new StringBuilder();
        String hostname = getParameter(params, "hostname");

        int port ;
        try
        {
            port = Integer.parseInt(params.get("port")[0]);
        }
        catch (NumberFormatException e)
        {
            port = 9001;
        }

        String user = getParameter(params, "user");
        String pwd = getParameter(params, "pwd");
        String account = getParameter(params, "account");
        String accountpwd = getParameter(params, "accountpwd");
        String CustomerId = getParameter(params, "id");
        if (account == null || account.length() == 0)
        {
            account = "mvdemo";
        }

        int functionId;
        try
        {
            functionId = Integer.parseInt(getParameter(params, "function"));
        }
        catch (NumberFormatException e)
        {
            functionId = 0;
        }
        String cmd = getParameter(params, "cmd");

        MVConnection mvConnection = null;
        try
        {
            if (hostname != null && hostname.length() > 0 && port != -1 && user != null && user.length() > 0 )
            {
                mvConnection = new MVConnection(hostname, port, user, pwd);
                if (account != null && account.length() > 0)
                {
                    mvConnection.logTo(account, accountpwd);
                }

                if (functionId == 1)
                {
                    // Return customer listing
                    MVStatement mvStatement = mvConnection.createStatement();
                    MVResultSet mvResultSet =
                            mvStatement.executeQuery("CUSTOMERS",      // file name
                                    "",                                // select criteria, e.g. with STATE = "CA"
                                    "BY ORGANIZATIONNAME",             // sort criteria
                                    "CUSTOMERID ORGANIZATIONNAME", ""); // output
                    sb.append("<table border=1 align=\"left\">");
                    sb.append("<tr>");
                    sb.append(" <th>Id</th>");
                    sb.append(" <th>Name</th>");
                    sb.append("</tr>");
                    int row = 0;
                    while (mvResultSet.next())
                    {
                        sb.append("<tr>");
                        sb.append("<td>");
                        sb.append("<a id=\"Row");
                        sb.append(row++);
                        sb.append("\" ");
                        sb.append("href=\"javascript:GetCustomer(");
                        sb.append(mvResultSet.getString(("CUSTOMERID")));
                        sb.append(")\"");
                        sb.append(">");
                        sb.append(mvResultSet.getString(("CUSTOMERID")));
                        sb.append("</td>");
                        sb.append("<td>");
                        sb.append(mvResultSet.getString(("ORGANIZATIONNAME")));
                        sb.append("</td>");
                        sb.append("</tr>");
                    }
                    sb.append("</table>");
                }
                else if (functionId == 2)
                {
                    // Return one customer record.
                    String item = mvConnection.fileRead("customers", CustomerId);
                    sb.append("<table border=\"0\">");
                    for (int i=0;i<m_fieldNumbers.length;i++)
                    {
                        sb.append("<tr><td><b>");
                        sb.append(m_fieldNames[i]);
                        sb.append("</b></td><td>");
                        if (m_fieldNumbers[i] > 0)
                        {
                            String attribute = mvConnection.extract(item, m_fieldNumbers[i]);
                            attribute = attribute.replace(MVConstants.VAL_MARK, '\n');
                            if (m_fieldNames[i].equalsIgnoreCase("note"))
                            {
                                sb.append("<textarea cols=50 rows=3 id=\"");
                                sb.append(m_fieldIds[i]);
                                sb.append("\"");
                                sb.append(">");
                            }
                            else
                            {
                                sb.append("<input type=\"text\"");
                                sb.append(" id=\"");
                                sb.append(m_fieldIds[i]);
                                sb.append("\"");
                                sb.append(" value=\"");
                            }
                            sb.append(attribute);
                            if (m_fieldNames[i].equalsIgnoreCase("note"))
                            {
                                sb.append("</textarea>");
                            }
                            else
                            {
                                sb.append("\">");
                            }
                        }
                        else
                        {
                            sb.append("<input type=\"text\"");
                            sb.append(" id=\"");
                            sb.append(m_fieldIds[i]);
                            sb.append("\"");
                            sb.append(" value=\"");
                            sb.append(CustomerId);
                            sb.append("\">");
                        }
                        sb.append("</td></tr>");
                    }
                    sb.append("</table>");
                }
                else if (functionId == 3 )
                {
                    sb = getOrders(mvConnection, CustomerId);
                }
                else if (functionId == 4)
                {
                    // execute a TCL command.
                    mvConnection.execute(cmd);
                    String result = mvConnection.getExecuteCapturing();
                    sb.append("<p>Results:<p>");
                    sb.append("<textarea rows=7 cols=80 readonly=true>");
                    result = result.replace(MVConstants.AM.charAt(0),  '\n');
                    sb.append(result);
                    sb.append("</textarea>");
                    sb.append("<p>");
                }
                else if (functionId == 5)
                {
                    // update file.
                    String value;
                    String item = mvConnection.fileRead("customers", CustomerId);
                    for (int i=0;i<m_fieldIds.length;i++)
                    {
                        value = getParameter(params, m_fieldIds[i]);
                        if (value != null)
                        {
                            value = value.replace('\n', MVConstants.VAL_MARK);
                            value = value.replace('\r', MVConstants.VAL_MARK);
                            item = mvConnection.replace(item, m_fieldNumbers[i], value);
                        }
                    }
                    mvConnection.fileWrite("customers", CustomerId, item);
                    sb.append("<p><font color=\"red\">Saved!</font>");
                }
                else
                {
                    sb.append("<p>Unknown functionId: ");
                    sb.append(functionId);
                }
            }
        }
        catch (MVException e)
        {
            sb.append("<p>exception: ");
            sb.append(e.getErrorMessage());
            sb.append("<p>hostname: ");sb.append(hostname);
            sb.append("<P>port: ");sb.append(port);
            sb.append("<p>user: ");sb.append(user);
        }
        finally
        {
            closeConnection(mvConnection);
        }
        return sb.toString();
    }

    private static StringBuilder getOrders(MVConnection mvConnection, String CustomerId)
    {
        StringBuilder sb = new StringBuilder();

        sb.append("<html>");
        sb.append("<body><table border=0 width=\"100%\"><tr><td nowrap><b>List orders for customer ");
        sb.append(CustomerId);
        sb.append("</b></td>");
        sb.append("<td align=\"right\"><img src=\"images/poweredbytws.gif\" hspace=\"5\"></td>");
        sb.append("</tr></table><hr>");
        int row = 0;
        try
        {
            MVStatement mvStatement = mvConnection.createStatement();
            MVResultSet mvResultSet = mvStatement.executeQuery("ORDERS",
                    "WITH CUSTOMERID = \"" + CustomerId + "\"",
                    "BY ORDERID",
                    "ORDERID ORDERDATE SHIPNAME", "");

            while (mvResultSet.next())
            {
                if (row == 0)
                {
                    sb.append("<table border=\"1\"");
                    sb.append("<tr><th>ORDERID</th><th>SHIPDATE</th></tr>");
                }

                row = row + 1;
                sb.append("<tr>");

                sb.append("<td>");
                sb.append(mvResultSet.getString("ORDERID"));
                sb.append("</td>");

                sb.append("<td>");
                sb.append(mvResultSet.getString("ORDERDATE"));
                sb.append("</td>");

                sb.append("</tr>");
            }
            if (row > 0)
            {
                sb.append("</table>");
            }
            else
            {
                sb.append("<p><b>No orders found for customer ");
                sb.append(CustomerId);
                sb.append("</b><p>");
            }
            sb.append("<input type=\"button\" onclick=\"javascript: window.close()\" id=\"btnClose\" style=\"display:inline\" value=\"Close\"/>");
            sb.append("</body></html>");
        }
        catch (MVException e)
        {
            sb.append("<p>exception: ");
            sb.append(e.getErrorMessage());
            sb.append("</p>");
        }
        return sb;
    }

    public void doPost(HttpServletRequest request,
                       HttpServletResponse response)
            throws IOException, ServletException
    {
        doGet(request, response);
    }

    private static boolean closeConnection(MVConnection mvConnection)
    {
        boolean result = true;
        try
        {
            if (mvConnection != null)
            {
                mvConnection.execute(MVConstants.MVSP_EXIT);
                mvConnection.close();
            }
        }
        catch (MVException e)
        {
            result = false;
        }
        return result;
    }


    public static void main(String [] args)
    {
        String hostname = "localhost";
        int port = 9002;
        String user = "dm";
        String pwd = "";
        String account = "mvdemo";
        String accountpwd = "";
        String CustomerId = "49";
        String note = "testing...";
        String cmd = null; // = "who";
        int functionId = 5;
        test_process(hostname, port, user, pwd, account, accountpwd,
                CustomerId, functionId, cmd, note);

    }

    private static String test_process(String hostname, int port, String user, String pwd, String account, String accountpwd,
                                       String CustomerId, int functionId, String cmd, String note)
    {
        Hashtable<String,String[]> parameters = new Hashtable<String,String[]>();
        parameters.put("hostname", new String[] {hostname} );
        parameters.put("port", new String[]{String.valueOf(port)});
        parameters.put("user", new String[]{user});
        parameters.put("pwd", new String[]{pwd});
        parameters.put("account", new String[]{account});
        parameters.put("accountpwd", new String[]{accountpwd});
        parameters.put("id", new String[]{CustomerId});
        parameters.put("function", new String[]{String.valueOf(functionId)});
        parameters.put("cmd", new String[]{cmd});
        parameters.put("Note_input", new String[]{note});

        String result = process(parameters);
        System.out.println(result);
        return result;
    }
}
