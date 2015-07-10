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
 * $Log: CustOrders.java,v $
 * Revision 1.2  2014/01/31 21:23:17  hesam
 * Changed package name rocket to rocketsoftware.
 *
 * Revision 1.1  2010/02/26 18:28:54  hesam
 * Created.
 *
 *
 ****************************************************************************************/

import com.rocketsoftware.mvapi.MVConnection;
import com.rocketsoftware.mvapi.MVConstants;
import com.rocketsoftware.mvapi.MVStatement;
import com.rocketsoftware.mvapi.ResultSet.MVResultSet;
import com.rocketsoftware.mvapi.exceptions.MVException;

import javax.swing.*;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.*;

import layout.TableLayout;

/**
 *
 * @author Hesam Shamshiri
 * @version $Revision: 1.2 $
 */
public class CustOrders extends JDialog implements ActionListener
{

    CustOrders(JFrame parent, MVConnection connection, String customerId)
    {
        super(parent);
        m_mvConnection = connection;
        m_customerId = customerId;
        constructUI();
        setLocation((int)(parent.getLocation().getX() + 100), (int)(parent.getLocation().getY() + 100));
        loadOrders();
    }

    public void actionPerformed(ActionEvent e)
    {
        Object source = e.getSource();
       if (source == m_btnClose)
       {
           dispose();
       }
    }


    /**
     * Constructs the UI for this form.
     */
    private void constructUI()
    {
        // Initialize the form.
        // --------------------
        setTitle("List orders for customer " + m_customerId);

        // Set form size.
        // --------------
        Toolkit toolkit = Toolkit.getDefaultToolkit();
        Dimension dimension = toolkit.getScreenSize();
        setSize((int)(dimension.getWidth()*.75), (int)(dimension.getHeight()*.75));

        setLayout( new TableLayout( CustOrders.LAYOUT ));

        // Create the list panel.
        // ----------------------
        String[] columnNames = {"ORDERID", "SHIPDATE", "SHIPNAME"};
        m_tableData = new DataTable(columnNames);
        m_table = new JTable(m_tableData);
        m_table.getColumnModel().getColumn(0).setWidth(50);
        JScrollPane scrollTable = new JScrollPane(m_table);
        m_lblOrders = new JLabel("Orders");
        add("1, 1", m_lblOrders);
        add("1, 3", scrollTable);
        JPanel buttons = new JPanel( new GridLayout(1, 1));
        m_btnClose = new JButton("Close");
        buttons.add(m_btnClose);
        add("1, 5", buttons);
        m_btnClose.addActionListener(this);
        getRootPane().setDefaultButton(m_btnClose);
    }

    private void loadOrders()
    {
        try
        {
            MVStatement mvStatement = m_mvConnection.createStatement();
            MVResultSet mvResultSet = mvStatement.executeQuery("ORDERS",
                    "WITH CUSTOMERID = \"" + m_customerId + "\"",
                    "BY ORDERID",
                    "ORDERID ORDERDATE SHIPNAME", "");
            while (mvResultSet.next())
            {
                m_tableData.addRow(mvResultSet.getCurrentRow());
            }
        }
        catch (MVException e)
        {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
    }

    /**
     * Layout for the screen.
     *
     * @since 1.0
     */
    private final static double[][] LAYOUT = new double[][]
            {
                    // Columns.
                    // --------
                    {
                            3,                                  // Gutter
                            TableLayout.FILL,                   // main
                            3                                   // Gutter
                    },

                    // Rows.
                    // -----
                    {
                            3,                                  // Gutter
                            23,                                 // label
                            3,                                  // Gutter
                            TableLayout.FILL,                   // result
                            3,                                  // Gutter
                            30,                                 // buttons
                            3                                   // Gutter
                    }
            };


    private MVConnection m_mvConnection;
    private JLabel m_lblOrders;
    private JButton m_btnClose;
    private JTable m_table;
    private DataTable m_tableData;
    private String m_customerId;

}
