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
 * $Log: CustServiceServlet.java,v $
 * Revision 1.5  2014/01/31 21:23:17  hesam
 * Changed package name rocket to rocketsoftware.
 *
 * Revision 1.4  2013/12/02 22:53:44  hesam
 * Added Rocket Software html.
 * Added next/prev buttons.
 *
 * Revision 1.3  2013/11/22 02:13:14  hesam
 * changed to d3prod, removed starbucks field.
 *
 * Revision 1.2  2011/09/09 00:00:29  hesam
 * Added misc field.
 *
 * Revision 1.1  2011/04/26 19:31:26  hesam
 * new
 *
 * Revision 1.1  2010/07/14 22:00:20  hesam
 * no message
 *
 *
 ****************************************************************************************/

import com.rocketsoftware.mvapi.MVConnection;
import com.rocketsoftware.mvapi.MVConstants;
import com.rocketsoftware.mvapi.MVStatement;
import com.rocketsoftware.mvapi.MVSubroutine;
import com.rocketsoftware.mvapi.ResultSet.MVResultSet;
import com.rocketsoftware.mvapi.exceptions.MVException;
import com.rocketsoftware.mvapi.utility.MVString;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.Map;

public class CustServiceServlet extends HttpServlet
{

    /**
     * Constants for calling the conversion subroutine.
     */
    private final static String CONV_SUB = "conv.sub";
    private final static String ICONV = "1";
    private final static String OCONV = "0";
    private final static String CONV_D = "D";
    private final static String CONV_D2S = "D2/";

    private final static String[] m_fieldNames =
            {
                    "Support calls",
                    "QA Testing",
                    "Documentation",
                    "Pre-Sales",
                    "Development",
                    "Hardware Configuration",
                    "Software Configuration",
                    "Sales",
                    "Professional Services",
                    "Training",
                    "Vacation",
                    "Sick",
                    "Admin"
            };

    private final static String[] m_fieldIds =
            {
                    "s", // support
                    "qt", // qa
                    "doc", // documentation
                    "ps", // pre sales
                    "dev", // development
                    "hc", // hardware
                    "sc", // software
                    "sa", // sales
                    "pro", // pro services
                    "t", // training
                    "v", // vacation
                    "st", // sick
                    "ad", // admin
                    //"lg"
            };

    private final static float[] m_fieldValues;

    private final static String[] m_dictIds =
            {
                    "SupportCalls",
                    "qatesting",
                    "Documentation",
                    "Pre-Sales",
                    "Development",
                    "HardwareConf",
                    "SoftwareConf",
                    "Sales",
                    "ProfServices",
                    "Training",
                    "Vacation",
                    "SickTime",
                    "Admin"
            };

    private final static int[] m_fieldNumbers =
            {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    13,
                    14
            };

    private final static String m_account = "support";

    private final static String m_accountPwd = ""; // todo set encrypted account password

    private final static String m_ADIlist;

    private static final String m_homePage = "" +
            "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\"\n" +
            "        \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n" +
            "<html xmlns=\"http://www.w3.org/1999/xhtml\">\n" +
            "<head>\n" +
            "    <title>Rocket D3 Database Management System - System ID Lookup</title>\n" +
            "    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\n" +
            "<meta http-equiv=\"imagetoolbar\" content=\"no\" />\n" +
            "<link rel=\"shortcut icon\" href=\"http://www3.rocketsoftware.com/rocketd3/tl_favicon_16px_16px.ico\" type=\"image/png\" />\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"http://www3.rocketsoftware.com/rocketd3/css/global.css\" />\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"http://www3.rocketsoftware.com/rocketd3/css/pick.css\" />\n" +
            "<script type=\"text/javascript\" src=\"http://www3.rocketsoftware.com/rocketd3/js/supersearch.js\"></script>\n" +
            "<script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js\"></script>\n" +
            "<script type=\"text/javascript\" src=\"./scripts/custserv.js\">\n" +
            "</script>\n" +
            "\n" +
            "<!--[if IE 7]>\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"http://www3.rocketsoftware.com/rocketd3/css/ie7.css?ver=1\" />\n" +
            "<![endif]-->\n" +
            "\n" +
            "<!-- fonts -->\n" +
            "<link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css'>\n" +
            "<link href='http://fonts.googleapis.com/css?family=Nobile:regular' rel='stylesheet' type='text/css'>\n" +
            "\n" +
            "\n" +
            "<!-- for new nav -->\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"http://www3.rocketsoftware.com/rocketd3/css/superfish.css\" media=\"screen\">\n" +
            "<!--\n" +
            "<script type=\"text/javascript\" src=\"http://www3.rocketsoftware.com/rocketd3/js/hoverIntent.js\"></script>\n" +
            "<script type=\"text/javascript\" src=\"http://www3.rocketsoftware.com/rocketd3/js/superfish.js\"></script>\n" +
            "-->\n" +
            "\n" +
            "  <style type=\"text/css\">\n" +
            "     #sysIDLookupMain {\n" +
            "      width: 948px;\n" +
            "      min-height: 348px;\n" +
            "      background-color: white;\n" +
            "      color: black;\n" +
            "      padding: 10; \n" +
            "    }\n" +
            "     #sysIDLookupTable, #sysIDLookupTable table, #sysIDLookupTable h1, #sysIDLookupTable h2 {\n" +
            "      background-color: white;\n" +
            "      color: black;\n" +
            "    }\n" +
            "    .headcol {\n" +
            "      width: 33%;\n" +
            "    }\n" +
            "    .headcolleft {\n" +
            "      border: 1px solid #BB1212;\n" +
            "      color: #BB1212;\n" +
            "      font-size: 1.2em;\n" +
            "      padding: 10px;\n" +
            "      width: 33%\n" +
            "    }\n" +
            "  </style>\n" +
            "\n" +
            "</head>\n" +
            "\n" +
            "<body class=\"support_active two\">\n" +
            "<div id=\"navbar\">\n" +
            "     <div class=\"mainlogo\"><a href=\"http://www.rocketsoftware.com\"><img src=\"http://www3.rocketsoftware.com/rocketd3/rocket-white-logo.png\" width=\"169\" height=\"43\" border=\"0\" alt=\"Rocket Software home\" /></a></div>\n" +
            "    <div class=\"navbuttons_alt\">\n" +
            "  \n" +
            "          <ul class=\"sf-menu\">\n" +
            "              <li class=\"current\"><a href=\"http://www3.rocketsoftware.com/rocketd3/\">D3 Home</a></li>\n" +
            "              <li class=\"current\"><a href=\"http://www3.rocketsoftware.com/rocketd3/products/\">Products</a></li>\n" +
            "              <li><a href=\"http://www3.rocketsoftware.com/rocketd3/support/\">Support</a></li>\n" +
            "              <li><a href=\"http://www3.rocketsoftware.com/rocketd3/support/education/\">Training</a></li>\n" +
            "              <li><a href=\"http://www.rocketsoftware.com/news\">News</a></li>\n" +
            "              <li><a href=\"http://www.rocketsoftware.com/events\">Events</a></li>\n" +
            "              <li class=\"last\"><a href=\"http://www3.rocketsoftware.com/rocketd3/contact.jsp\">Contact</a></li>\n" +
            "              <li class=\"last\">\n" +
            "                <a href=\"http://www.rocketsoftware.com/news/faq-multivalue-database-acquisition\">Acquisition FAQ</a></li>\n" +
            "          </ul>\n" +
            "        </div>\n" +
            "     <div class=\"clear\"></div>\n" +
            "</div>\n" +
            "\n" +
            "<center>\n" +
            "<div id=\"sysIDLookupMain\">\n" +
            "  <div id=\"sysIDLookupTable\">\n" +
            "    <table width=\"95%\">\n" +
            "      <tr align=\"center\" valign=\"center\">\n" +
            "        <td align=\"left\">&nbsp;</td>\n" +
            "        <td>\n" +
//            "</head>\n" +
//            "<table border=0 width=\"100%\">\n" +
//            "<tr>\n" +
//            "<td align=\"left\"><img src=\"./images/tigerlogic_logo.png\"></td>\n" +
//            "</tr>\n" +
//            "</table>\n" +
            "<h2><span style='color:#0069aa'>Customer service activity log</h2><hr></span>\n" +
            "<table border=0 width=\"100%\">\n" +
            "<tr>\n" +
            "<td>\n" +
            "Username:\n" +
            "</td>\n" +
            "<td>\n" +
            "<input type=\"text\" id=\"user\" value=\"$user\">\n" +
            "</td>\n" +
            "<td>\n" +
            "Hostname:\n" +
            "</td>\n" +
            "<td>\n" +
            "<input type=\"text\" id=\"hostname\" value=\"$host\">\n" +
            "</td>\n" +
            "</tr>\n" +
            "<tr>\n" +
            "<td>\n" +
            "Password:\n" +
            "</td>\n" +
            "<td>\n" +
            " <input type=\"password\" id=\"pwd\" value=\"$pwd\">\n" +
            "</td>\n" +
            "<td>\n" +
            "Port:\n" +
            "</td>\n" +
            "<td>\n" +
            " <input type=\"text\" id=\"port\" value=\"$port\">\n" +
            "</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "<td colspan=\"4\">\n" +
            "<hr><p><p>" +
            "</td>" +
            "</tr>" +
            "<tr>" +
            "<td>\n" +
            "Activity Date:" +
            "</td>" +
            "<td>" +
            "<input type=\"text\" id=\"date\" value=\"$date\">\n" +
            "</td>\n" +
            "</tr>\n" +
            "$table" +
            "<tr><td></td><td>$command</td></tr>" +
            "</table>\n" +
            "\n" +
            "\n" +
//            "$command" +
            "\n" +
            "    </table>\n" +
            "  </div>\n" +
            "</div>\n" +
            "</center>\n" +
            "\n" +
            "    <div id=\"footer\">\n" +
            "         <div style=\"float:left;margin-right:30px;margin-top:-2px;\">Connect With Us Today: \n" +
            "         <a href=\"http://www.linkedin.com/groups?gid=3997577\" target=\"_blank\"><img src=\"http://www3.rocketsoftware.com/rocketd3/images/linkedin.png\" style=\"vertical-align:-4px;padding-left:5px;border:none;\" / ></a> \n" +
            "         <a href=\"http://twitter.com/rocket\" target=\"_blank\"><img src=\"http://www3.rocketsoftware.com/rocketd3/images/badge_twitter.png\" style=\"vertical-align:-4px;border:none;\" / ></a>\n" +
            "         <a href=\"https://www.youtube.com/rocketsource\" target=\"_blank\"><img src=\"http://www3.rocketsoftware.com/rocketd3/images/badge_youtube.png\" style=\"vertical-align:-4px;border:none;\" / ></a>\n" +
            "\n" +
            "         </div> <a href=\"http://www.rocketsoftware.com/company\">Company Info</a> &nbsp;|&nbsp; <a href=\"http://www3.rocketsoftware.com/rocketd3/contact.jsp\">Contact Us</a> &nbsp;|&nbsp; <a href=\"http://www.rocketsoftware.com/company/legal/privacy-policy\">Privacy</a> &nbsp;|&nbsp; <a href=\"mailto:rberman@rocketsoftware.com?subject=Media\">Press</a> &nbsp;|&nbsp; <a href=\"http://www.rocketsoftware.com/news\">News</a> &nbsp;|&nbsp; <a href=\"http://www.rocketsoftware.com/events\">Events</a>\n" +
            "    <br>\n" +
            "    <br>\n" +
            "         <p> Rocket Software, Inc. or its affiliates 1990-2013. All rights reserved. Rocket and the Rocket Software logos are registered trademarks of Rocket Software, Inc. Other product and service names might be trademarks of Rocket Software or its affiliates.</p>\n" +
            "    </div>\n" +
            "    \n" +
            "    <style>\n" +
            "    #footer img:hover{opacity:.8;}\n" +
            "    </style>\n" +
            "    \n" +
            "\n" +
            "<script type=\"text/javascript\">\n" +
            "//var DOCUMENTGROUP='';\n" +
            "//var DOCUMENTNAME='';\n" +
            "//var ACTION='';\n" +
            "</script>\n" +
            "</body>\n" +
            "</html>\n";

    private static final String m_activityTable =
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tSupport Calls\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"SupportCalls\" value=\"$SupportCalls\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tQA Testing\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"qatesting\" value=\"$qatesting\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tDocumentation\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"Documentation\" value=\"$Documentation\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tPre-Sales\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"Pre-Sales\" value=\"$Pre-Sales\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tDevelopment\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"Development\" value=\"$Development\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tHardware Configuration\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"HardwareConf\" value=\"$HardwareConf\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tSoftware Configuration\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"SoftwareConf\" value=\"$SoftwareConf\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tSales\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"Sales\" value=\"$Sales\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tProfessional Services\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"ProfServices\" value=\"$ProfServices\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tTraining\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"Training\" value=\"$Training\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tVacation\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"Vacation\" value=\"$Vacation\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tSickTime\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"SickTime\"  value=\"$SickTime\">\n" +
            "\t</td>\n" +
            "</tr>\n" +
            "\n" +
            "<tr>\n" +
            "\t<td>\n" +
            "\t\tAdmin\n" +
            "\t</td>\n" +
            "\t<td>\n" +
            "\t\t<input type=\"text\" id=\"Admin\"  value=\"$Admin\">\n" +
            "\t</td>\n" +
            "</tr>\n"+
//            "<tr>\n" +
//            "\t<td>\n" +
//            "\t\tYammering\n" +
//            "\t</td>\n" +
//            "\t<td>\n" +
//            "\t\t<input type=\"text\" id=\"Yammering\"  value=\"$Starbucks\">\n" +
//            "\t</td>\n" +
//            "</tr>\n"+
            "<tr>\n" +
            "<td colspan=\"4\">\n" +
            "<hr><p><p>" +
            "</td>" +
            "</tr>";

    private static final String m_btnGo =
            "<input type=\"button\" onclick=\"GetActivityInfo()\" id=\"btnConnect\" style=\"display:inline\" value=\"Go\"/>\n";

    private static final String m_btnSave =
            "<input type=\"button\" id=\"btnSave\" style=\"display:inline\" value=\"Save\" onclick=\"doSave()\"/>\n";

    private static final String m_btnCancel =
            "<input type=\"button\" id=\"btnCancel\" style=\"display:inline\" value=\"Cancel\" onclick=\"doCancel()\">\n";

    private static final String m_btnNext =
            "<input type=\"button\" id=\"btnNext\" style=\"display:inline\" value=\"Next\" onclick=\"doNext()\">\n";

    private static final String m_btnPrev =
            "<input type=\"button\" id=\"btnPrev\" style=\"display:inline\" value=\"Prev\" onclick=\"doPrev()\">\n";

    private static final String m_fileName = "support,technicians,";

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

        // Return initial page.
        // -------------------
        if (params == null || params.size() == 0)
        {
            return genHomePage();
        }

        String user = getParameter(params, "user");
        String pwd = getParameter(params, "pwd");
        String date = getParameter(params, "date");
        String hostname = getParameter(params, "hostname");
        int port ;
        try
        {
            port = Integer.parseInt(params.get("port")[0]);
        }
        catch (NumberFormatException e)
        {
            port = 9000;
        }

        // If date is null, just validate the host,port,user and pwd.
        // ----------------------------------------------------------
        if (date.length() == 0)
        {
            return genHomePage(hostname, String.valueOf(port), user, pwd, "");
        }

        if (hostname.length() == 0 || user.length() == 0)
        {
            return "<html><h2>Host and user name are required</h2></html>";
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

        MVConnection mvConnection = null;
        String iDate = "";
        String oDate = "";
        String itemId = "";

        try
        {
            if (hostname != null && hostname.length() > 0 && port != -1 && user != null && user.length() > 0 )
            {

                // Read
                // ----
                if (functionId == 1 || functionId == 3 || functionId == 4)
                {

                    mvConnection = new MVConnection(hostname, port, user, pwd);
                    mvConnection.logTo(m_account, m_accountPwd);

                    try
                    {
                        iDate = conv(mvConnection, date, CONV_D, ICONV);
                        if (functionId == 3)
                        {
                            iDate = String.valueOf(
                                    Integer.parseInt(iDate) + 1);
                        }
                        else if (functionId == 4)
                        {
                            iDate = String.valueOf(
                                    Integer.parseInt(iDate) - 1);
                        }
                        oDate = conv(mvConnection, iDate, CONV_D2S, OCONV);
                    }
                    catch (Exception e)
                    {
                        sb.append("<html><body><p>Error while converting date " + date + " to internal date.");
                        sb.append(e.getMessage());
                        sb.append("</body></html>");
                        e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
                    }

                    // Get employee time record for the requested date.
                    // ------------------------------------------------
                    MVStatement mvStatement = mvConnection.createStatement();
                    MVResultSet mvResultSet =
                            mvStatement.executeQuery("technicians",      // file name
                                    "WITH DATE = \"" + oDate + "\" AND WITH TECHID = \"" + user + "\"", // select criteria, e.g. with STATE = "CA"
                                    "BY DATE BY TECHID",             // sort criteria
                                    m_ADIlist, "");                 // output

                    String [] results = new String[m_dictIds.length];
                    for (int i=0;i<results.length;i++)
                    {
                        results[i] = "";
                    }
                    while (mvResultSet.next())
                    {
                        String row = mvResultSet.getCurrentRow();
                        for (int i=0;i<m_dictIds.length; i++)
                        {
                            results[i] = MVString.extract(row, i + 1);
                        }
                    }

                    return genActivityPage(hostname, port, user, pwd, oDate, results);

                }
                // Write
                // -----
                else if (functionId == 2)
                {

                    StringBuilder errors = null;

                    for (int i=0;i<m_fieldIds.length;i++)
                    {
                        try
                        {
                            String value = getParameter(params, m_fieldIds[i]);
                            if (value != null && value.length() > 0)
                            {
                                m_fieldValues[i] = Float.parseFloat( value );
                            }
                            else
                            {
                                m_fieldValues[i] = 0;
                            }
                        }
                        catch (NumberFormatException e)
                        {
                            if (errors == null)
                            {
                                errors = new StringBuilder();
                                errors.append("Please enter a valid decimal number for these fields:\n\n");
                            }
                            errors.append(m_fieldNames[i]).append("\n");
                        }
                    }

                    if (errors != null)
                    {
                        System.out.println( errors.toString() );
                        return errors.toString();
                    }

                    mvConnection = new MVConnection(hostname, port, user, pwd);
                    mvConnection.logTo(m_account, m_accountPwd);

                    try
                    {
                        iDate = conv(mvConnection, date, CONV_D, ICONV);
                        itemId = user + "*" + iDate;
                        String item = mvConnection.fileReadU(m_fileName, itemId);
                        String [] itemArray = item.split(MVConstants.AM);
                        String [] newItem = new String[100];
                        for (int i = 0; i< itemArray.length;i++)
                        {
                            newItem[i] = itemArray[i];
                        }
                        for (int i=0;i<m_fieldIds.length;i++)
                        {
                            newItem[m_fieldNumbers[i] - 1] = String.valueOf(m_fieldValues[i]);
                        }
                        StringBuilder ib = new StringBuilder();
                        for (int i = 0;i<newItem.length;i++)
                        {
                            if (newItem[i] == null)
                            {
                                break;
                            }
                            ib.append(newItem[i]).append(MVConstants.AM);
                        }
                        mvConnection.fileWrite(m_fileName, itemId, ib.substring(0, ib.length()));
                        itemId = "";
                        sb.setLength(0);
                        sb.append("<p>saved!</p>");
                    }
                    catch (Exception e)
                    {
                        sb.append("<html><body><p>Error while converting date " + date + " to internal date.");
                        sb.append(e.getMessage());
                        sb.append("</body></html>");
                        e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
                    }
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
            sb.append("<html><body>");
            sb.append("<p>exception: ");
            sb.append(e.getErrorMessage());
            sb.append("<p>hostname: ");sb.append(hostname);
            sb.append("<P>port: ");sb.append(port);
            sb.append("<p>user: ");sb.append(user);
            sb.append("</body></html>");
        }
        finally
        {
            if (mvConnection != null)
            {
                if (itemId.length() > 0)
                {
                    try
                    {
                        mvConnection.fileRelease(m_fileName, itemId);
                    }
                    catch (MVException e)
                    {
                        e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
                    }
                }
            }
            closeConnection(mvConnection);
        }
        return sb.toString();
    }

    public void doPost(HttpServletRequest request,
                       HttpServletResponse response)
            throws IOException, ServletException
    {
        doGet(request, response);
    }

    private static String conv(MVConnection mvConnection,
                               String data, String code, String dir ) throws Exception
    {
        String subName = CONV_SUB;
        int arguments = 4;
        MVSubroutine mvSubroutine = mvConnection.mvSub(subName, arguments);
        mvSubroutine.setArg(0, data);
        mvSubroutine.setArg(1, code);
        mvSubroutine.setArg(2, dir);
        mvSubroutine.setArg(3, "");
        mvSubroutine.mvCall();
        return mvSubroutine.getArg(3);
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
        int port = 9000;
        String user = "dm";
        String pwd = "";
        String account = "support";
        String accountpwd = "";
        String date = "04/15/2011";
        int functionId = 2;
        test_process(hostname, port, user, pwd, account, accountpwd, date, functionId);

    }

    private static String test_process(String hostname, int port, String user, String pwd, String account, String accountpwd,
                                       String date, int functionId)
    {
        Hashtable<String,String[]> parameters = new Hashtable<String,String[]>();
        parameters.put("hostname", new String[] {hostname} );
        parameters.put("port", new String[]{String.valueOf(port)});
        parameters.put("user", new String[]{user});
        parameters.put("pwd", new String[]{pwd});
        parameters.put("account", new String[]{account});
        parameters.put("accountpwd", new String[]{accountpwd});
        parameters.put("function", new String[]{String.valueOf(functionId)});
        parameters.put("date", new String[]{date});

        parameters.put("s", new String[]{"1"});
        parameters.put("qt", new String[]{"2"});
        parameters.put("doc", new String[]{"3"});
        parameters.put("ps", new String[]{"4"});
        parameters.put("dev", new String[]{"5"});
        parameters.put("hc", new String[]{"6"});
        parameters.put("sc", new String[]{"7"});
        parameters.put("sa", new String[]{"8"});
        parameters.put("pro", new String[]{"9"});
        parameters.put("t", new String[]{"10"});
        parameters.put("v", new String[]{"11"});
        parameters.put("st", new String[]{"12"});
        parameters.put("ad", new String[]{"13"});
        parameters.put("lg", new String[]{"14"});

        String result = process(parameters);
        System.out.println(result);
        return result;
    }

    private static String genActivityPage(String hostName, int port, String user, String pwd, String date, String [] results)
    {

        String table = m_activityTable;
        for (int i=0;i<m_dictIds.length;i++)
        {
            table = table.replace("$" + m_dictIds[i], results[i]);
        }

        String result = m_homePage.replace("$host", hostName)
                .replace("$port", String.valueOf(port))
                .replace("$user", user)
                .replace("$pwd", pwd)
                .replace("$date", date)
                .replace("$table", table)
                .replace("$command", m_btnSave + m_btnCancel + m_btnNext + m_btnPrev);

        return result;


    }

    private static String genHomePage()
    {
        return genHomePage("d3prod", "9000", "", "", "");
    }

    private static String genHomePage(String hostName, String port, String user, String pwd, String date)
    {
        return m_homePage.replace("$host", hostName)
                .replace("$port", port)
                .replace("$user", user)
                .replace("$pwd", pwd)
                .replace("$date", date)
                .replace("$table", "")
                .replace("$command", m_btnGo);
    }

    static
    {
        StringBuilder sb = new StringBuilder();
        for (String s : m_dictIds)
        {
            sb.append(s).append(" ");
        }
        m_ADIlist = sb.toString();
        m_fieldValues = new float[m_dictIds.length];
    }
}
