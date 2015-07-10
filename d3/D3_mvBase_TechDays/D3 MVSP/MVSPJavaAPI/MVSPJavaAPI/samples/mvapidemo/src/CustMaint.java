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
 * $Log: CustMaint.java,v $
 * Revision 1.5  2014/01/31 21:23:03  hesam
 * Changed package name rocket to rocketsoftware.
 *
 * Revision 1.4  2010/07/21 16:35:08  hesam
 * Changed icon from small-pizza.gif to tl.gif.
 *
 * Revision 1.3  2009/11/30 18:17:13  hesam
 * no message
 *
 * Revision 1.2  2009/11/03 19:04:33  hesam
 * Added CustMaint demo
 *
 * Revision 1.1  2009/11/01 20:16:49  hesam
 * Created.
 *
 *
 ****************************************************************************************/

import layout.TableLayout;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.net.URL;

import com.rocketsoftware.mvapi.MVConnection;
import com.rocketsoftware.mvapi.MVConstants;
import com.rocketsoftware.mvapi.MVStatement;
import com.rocketsoftware.mvapi.ResultSet.MVResultSet;
import com.rocketsoftware.mvapi.exceptions.MVException;

/**
 * Demonstrates TigerLogic Java API.
 *
 * @author Hesam Shamshiri
 * @version $Revision: 1.5 $
 *
 */
public class CustMaint extends JFrame implements ActionListener, MouseListener, WindowListener
{
    private final String DIALOG_TITLE = "Customer Maintenance";

    public static void main(String [] args)
    {

        try
        {
            UIManager.setLookAndFeel( UIManager.getSystemLookAndFeelClassName() );
        }
        catch( ClassNotFoundException e )
        {
            e.printStackTrace();
        }
        catch( InstantiationException e )
        {
            e.printStackTrace();
        }
        catch( IllegalAccessException e )
        {
            e.printStackTrace();
        }
        catch( UnsupportedLookAndFeelException e )
        {
            e.printStackTrace();
        }

        CustMaint custMaint = new CustMaint();

    }

    public CustMaint()
    {
        m_mvConnection = null;
        constructUI();
        setVisible(true);
    }

    /**
     * Constructs the UI for this form.
     */
    private void constructUI()
    {
        // Initialize the form.
        // --------------------
        setTitle("Customer Maintenance - Java version");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        // Set form size.
        // --------------
        Toolkit toolkit = Toolkit.getDefaultToolkit();
        Dimension dimension = toolkit.getScreenSize();
        setSize((int)(dimension.getWidth()*.75), (int)(dimension.getHeight()*.75));

        // Set the icon.
        // -------------
        URL url = CustMaint.class.getResource("product_icon.gif");
        setIconImage( toolkit.getImage(url) );

        setLayout( new TableLayout( LAYOUT ));

        // Create the connection panel.
        // ----------------------------
        JPanel panelConn = new JPanel( new TableLayout( CONNECTION_LAYOUT ));

        JLabel lblUser = new JLabel("Username");
        m_txtUser = new JTextField();

        JLabel lblPwd = new JLabel("Password");
        m_txtPwd = new JPasswordField();

        JLabel lblHost = new JLabel("Hostname");
        m_txtHost = new JTextField();

        JLabel lblPort = new JLabel("Port");
        m_txtPort = new JTextField();

        m_btnConnect = new JButton("Connect");
        panelConn.add("1, 1", lblUser);
        panelConn.add("3, 1", m_txtUser);
        panelConn.add("5, 1", lblHost);
        panelConn.add("7, 1", m_txtHost);
        panelConn.add("9, 1", m_btnConnect);
        panelConn.add("1, 3", lblPwd);
        panelConn.add("3, 3", m_txtPwd);
        panelConn.add("5, 3", lblPort);
        panelConn.add("7, 3", m_txtPort);

        // Create the list panel.
        // ----------------------
        JPanel panelTable = new JPanel( new TableLayout(TABLE_LAYOUT));
        String[] columnNames = {"ItemId", "Name"};
        m_tableData = new DataTable(columnNames);
        m_table = new JTable(m_tableData);
        m_table.getColumnModel().getColumn(0).setWidth(50);
        m_table.getColumnModel().getColumn(1).setWidth(500);
        JScrollPane scrollTable = new JScrollPane(m_table);
        panelTable.add("1,1", scrollTable);
        m_table.addMouseListener(this);

        // Create the customer panel.
        // --------------------------
        JPanel panelData = new JPanel( new TableLayout(DATA_LAYOUT));

        JLabel lblCustId = new JLabel("Customer ID");
        m_txtCustId = new JTextField();

        JLabel lblCname = new JLabel("Contact Name");
        m_txtCname = new JTextField();

        JLabel lblCtitle = new JLabel("Contact Title");
        m_txtCtitle = new JTextField();

        JLabel lblOname = new JLabel("Organization Name");
        m_txtOname = new JTextField();

        JLabel lblAddr = new JLabel("Address");
        m_txtAddr = new JTextField();

        JLabel lblCity = new JLabel("City");
        m_txtCity = new JTextField();

        JLabel lblState = new JLabel("State");
        m_txtState = new JTextField();

        JLabel lblPostal = new JLabel("Postal Code");
        m_txtPostal = new JTextField();

        JLabel lblPhone = new JLabel("Phone Number");
        m_txtPhone = new JTextField();

        JLabel lblFax = new JLabel("Fax Number");
        m_txtFax = new JTextField();

        JLabel lblNote = new JLabel("Note");
        m_txtNote = new JTextArea();
        JScrollPane scrollNote = new JScrollPane(m_txtNote);

        panelData.add("1,1", lblCustId);
        panelData.add("3,1", m_txtCustId);

        panelData.add("1,3", lblCname);
        panelData.add("3,3,9,3", m_txtCname);

        panelData.add("1,5", lblCtitle);
        panelData.add("3,5,9,5", m_txtCtitle);

        panelData.add("1,7", lblOname);
        panelData.add("3,7,9,7", m_txtOname);

        panelData.add("1,9", lblAddr);
        panelData.add("3,9,9,9", m_txtAddr);

        panelData.add("1,11", lblCity);
        panelData.add("3,11,9,11", m_txtCity);

        panelData.add("1,13", lblState);
        panelData.add("3,13", m_txtState);

        panelData.add("5,13", lblPostal);
        panelData.add("7,13,9,13", m_txtPostal);

        panelData.add("1,15", lblPhone);
        panelData.add("3,15,5,15", m_txtPhone);

        panelData.add("1,17", lblFax);
        panelData.add("3,17,5,17", m_txtFax);

        panelData.add("1,19", lblNote);
        panelData.add("3,19,9,19", scrollNote);

        // Combine table and data into one panel.
        // --------------------------------------
        JPanel panelFile = new JPanel( new TableLayout(FILE_LAYOUT));
        panelFile.add("1,1", panelTable);
        panelFile.add("3,1", panelData);

        // Create the buttons panel.
        // -------------------------
        JPanel panelButtons = new JPanel( new TableLayout(BUTTONS_LAYOUT));
        m_btnTCL = new JButton("Execute");
        m_btnOrders = new JButton("Orders");
        //m_btnTest = new JButton("Test");
        m_btnNew = new JButton("New");
        m_btnSave = new JButton("Save");
        panelButtons.add("5,1", m_btnOrders);
        panelButtons.add("7,1", m_btnTCL);
        panelButtons.add("9,1", m_btnNew);
        panelButtons.add("11,1", m_btnSave);
        m_btnNew.setEnabled(false);
        m_btnSave.setEnabled(false);

        // Set the event handlers.
        // -----------------------
        m_btnConnect.addActionListener(this);
        m_btnTCL.addActionListener(this);
        m_btnNew.addActionListener(this);
        m_btnSave.addActionListener(this);
        //m_btnTest.addActionListener(this);
        m_btnOrders.addActionListener(this);
        addWindowListener(this);

        // Add all the panels to the form.
        // -------------------------------
        add("1,1", panelConn);
        add("1,3", panelFile);
        add("1,5", panelButtons);

        // Default connection text fields.
        // -------------------------------
        m_txtUser.setText("dm");
        m_txtHost.setText("localhost");
        m_txtPort.setText("9000");

    }

    public void actionPerformed(ActionEvent e)
    {
        Object source = e.getSource();
        if (source == m_btnConnect)
        {
            boolean connected = connect();
            if (connected)
            {
                loadCustomers();
                m_btnNew.setEnabled(true);
                m_btnSave.setEnabled(true);
            }
        }
        else
        if (source == m_btnTCL)
        {
            TCL();
        }
        if (source == m_btnNew)
        {
            create();
        }
        else
        if (source == m_btnSave)
        {
            writeItem();
        }
        else
        if (source == m_btnTest)
        {
            test();
        }
        if (source == m_btnOrders)
        {
            listOrders();
        }
    }

    public void mouseClicked(MouseEvent e)
    {
        if (e.getSource() == m_table)
        {
            readItem(m_table.getSelectedRow());
        }
    }

    public void mousePressed(MouseEvent e)
    {
    }

    public void mouseReleased(MouseEvent e)
    {
    }

    public void mouseEntered(MouseEvent e)
    {
    }

    public void mouseExited(MouseEvent e)
    {
    }

    private void test()
    {
        try
        {
              String result = m_mvConnection.call("TEST.SUB", "TESTING");
              System.out.println(result);
//            m_mvConnection.execute("listfiles");
//            String s = m_mvConnection.getExecuteCapturing();
//            int attributes = m_mvConnection.dCount(s, MVConstants.ATTR_MARK);
//            for (int i=1; i<attributes+1; i++)
//            {
//                String s1 = m_mvConnection.extract(s, i);
//                System.out.println(s1);
//            }
////            System.out.println(s);
        }
        catch (MVException e)
        {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
    }

    /**
     * Connects to an MVSP server.
     */
    private boolean connect()
    {

        boolean isConnected = false;
        boolean isValid = true;

        // Get user name and password.
        // ---------------------------
        String userName = m_txtUser.getText();
        String userPwd = new String(m_txtPwd.getPassword());
        if (userName.length() == 0)
        {
            JOptionPane.showMessageDialog(this, "Please enter a user name", DIALOG_TITLE,
                    JOptionPane.OK_OPTION);
            isValid = false;
        }

        // Get hostname and port.
        // ----------------------
        String hostName = m_txtHost.getText();
        String port = m_txtPort.getText();
        if (hostName.length() == 0 || port.length() == 0)
        {
            JOptionPane.showMessageDialog(this, "Please enter hostname and port.", DIALOG_TITLE,
                    JOptionPane.OK_OPTION);
            isValid = false;
        }

        if (isValid)
        {
            try
            {
                // Close the current connection.
                // -----------------------------
                if (m_mvConnection != null)
                {
                    m_mvConnection.close();
                }

                // Connect to the MVSP server.
                // ---------------------------
                m_mvConnection = new MVConnection(hostName, Integer.parseInt(port), userName, userPwd);

                String msg =
                        "ServerPlatform: " + m_mvConnection.getServerPlatform() + "\n" +
                                "Server version: " + m_mvConnection.getServerVersion() + "\n" +
                                "Server port: " + m_mvConnection.getServerPort();
                JOptionPane.showMessageDialog(this, "Connected: \n" + msg, DIALOG_TITLE,
                        JOptionPane.INFORMATION_MESSAGE);
                isConnected = true;
            }
            catch (MVException e)
            {
                JOptionPane.showMessageDialog(this, "MVSP Exception when connecting: " + e.getErrorMessage(),
                        DIALOG_TITLE, JOptionPane.OK_OPTION);
            }
            catch (Exception e)
            {
                JOptionPane.showMessageDialog(this, "Exception when connecting: " + e.getMessage(),
                        DIALOG_TITLE, JOptionPane.OK_OPTION);
            }
        }

        return isConnected;
    }

    /**
     * Disconnects from the MVSP server.
     */
    private void disconnect()
    {
        if (m_mvConnection != null)
        {
            try
            {
                m_mvConnection.close();
                m_mvConnection = null;
            }
            catch (MVException e1)
            {
                // Ignore.
                // -------
            }
        }
    }

    /**
     * Reads data from MVSP using the executeQuery method.
     */
    private void loadCustomers()
    {

        // Clear existing rows.
        // --------------------
        m_tableData.clear();

        try
        {

            // Logto the account.
            // ------------------
            m_mvConnection.logTo("MVDEMO", "");

            // Create a statement object from the connection.
            // ---------------------------------------------
            MVStatement mvStatement = m_mvConnection.createStatement();

            MVResultSet mvResultSet =
                    mvStatement.executeQuery("CUSTOMERS",      // file name
                            "",                                // select criteria, e.g. with STATE = "CA"
                            "BY ORGANIZATIONNAME",             // sort criteria
                            "CUSTOMERID ORGANIZATIONNAME", ""); // output

            // Read all the items and load into the table.
            // -------------------------------------------
            while (mvResultSet.next())
            {
                String row = mvResultSet.getCurrentRow();
                m_tableData.addRow(row);

            }
        }
        catch (MVException e)
        {
            JOptionPane.showMessageDialog(this, "MVSP Exception while selecting file:" + e.getErrorMessage(),
                    DIALOG_TITLE, JOptionPane.OK_OPTION);
        }
    }

    /**
     * Reads data from MVSP using fileSelect/fileReadNext methods.
     */
    private void loadCustomersUsingFileSelect()
    {

        // Clear existing rows.
        // --------------------
        m_tableData.clear();

        try
        {

            // Logto the account.
            // ------------------
            m_mvConnection.logTo("MVDEMO", "");

            if (m_mvConnection.fileSelect("CUSTOMERS"))
            {
                do
                {
                    String itemId = m_mvConnection.fileReadNext();
                    if (!m_mvConnection.getEol())
                    {
                        String item = m_mvConnection.fileRead("CUSTOMERS", itemId);
                        m_tableData.addRow(itemId, item);
                    }
                }
                while ( !m_mvConnection.getEol() );
            }
            else
            {
                JOptionPane.showMessageDialog(this, "fileSelect failed, error:" +
                        m_mvConnection.getFileStatusMessage(), DIALOG_TITLE, JOptionPane.OK_OPTION);
            }
        }
        catch (MVException e)
        {
            JOptionPane.showMessageDialog(this, "MVSP Exception while selecting file:" + e.getErrorMessage(),
                    DIALOG_TITLE, JOptionPane.OK_OPTION);
        }
    }

    /**
     * Create a new item.
     *
     */
    private void create()
    {
        m_txtCustId.setText("");
        m_txtOname.setText( "");
        m_txtAddr.setText( "");
        m_txtCity.setText( "");
        m_txtState.setText( "");
        m_txtPostal.setText( "");
        m_txtCname.setText( "");
        m_txtCtitle.setText( "");
        m_txtPhone.setText( "");
        m_txtFax.setText( "");
        m_txtNote.setText( "");
        m_currentItemId = "";

    }

    /**
     * Reads and displays an item.
     * @param row is the row number containing the item id to read.
     */
    private void readItem(int row)
    {
        try
        {
            String itemId = (String)m_tableData.getValueAt(row, 0);
            String item = m_mvConnection.fileRead("CUSTOMERS", itemId);
            if (m_mvConnection.getFileStatusCode() == 0)
            {
                m_txtCustId.setText(itemId);
                m_txtOname.setText( m_mvConnection.extract(item, 1));
                m_txtAddr.setText( m_mvConnection.extract(item, 2));
                m_txtCity.setText( m_mvConnection.extract(item, 3));
                m_txtState.setText( m_mvConnection.extract(item, 4));
                m_txtPostal.setText( m_mvConnection.extract(item, 5));
                m_txtCname.setText( m_mvConnection.extract(item, 6));
                m_txtCtitle.setText( m_mvConnection.extract(item, 7));
                m_txtPhone.setText( m_mvConnection.extract(item, 8));
                m_txtFax.setText( m_mvConnection.extract(item, 9));
                m_txtNote.setText( m_mvConnection.extract(item, 10));
                m_currentItemId = itemId;
            }
            else
            {
                String msg = m_mvConnection.getFileStatusMessage();
                JOptionPane.showMessageDialog(this, "Error while reading item " + itemId +
                        "\n" + msg, DIALOG_TITLE, JOptionPane.OK_OPTION);
                m_currentItemId = "";
            }
        }
        catch (MVException e)
        {
            JOptionPane.showMessageDialog(this, "MVSP Exception while reading item: " + e.getErrorMessage(),
                    DIALOG_TITLE, JOptionPane.OK_OPTION);

        }
    }

    /**
     * Writes the current item.
     *
     */
    private void writeItem()
    {
        try
        {
            boolean validId = true;
            String itemId = m_txtCustId.getText();
            if (m_currentItemId == null || m_currentItemId.length() == 0) // New Item
            {
                if (itemId.length() > 0)
                {
                    m_mvConnection.fileRead("CUSTOMERS", itemId);
                    if (m_mvConnection.getFileStatusCode() == 0)
                    {
                        JOptionPane.showMessageDialog(this, "ID already in use",
                                DIALOG_TITLE, JOptionPane.OK_OPTION);
                        validId = false;
                    }
                }
                else
                {
                    JOptionPane.showMessageDialog(this, "ID cannot be null",
                            DIALOG_TITLE, JOptionPane.OK_OPTION);
                    validId = false;
                }
            }


            if (validId)
            {
                StringBuilder sb = new StringBuilder();
                sb.append(m_txtOname.getText());
                String AM = MVConstants.AM;
                sb.append( AM );
                sb.append( m_txtAddr.getText() );
                sb.append( AM );
                sb.append( m_txtCity.getText() );
                sb.append( AM );
                sb.append( m_txtState.getText() );
                sb.append( AM );
                sb.append( m_txtPostal.getText() );
                sb.append( AM );
                sb.append( m_txtCname.getText() );
                sb.append( AM );
                sb.append( m_txtCtitle.getText() );
                sb.append( AM );
                sb.append( m_txtPhone.getText() );
                sb.append( AM );
                sb.append( m_txtFax.getText() );
                sb.append( AM );
                sb.append( m_txtNote.getText() );
                String item = sb.toString();
                m_mvConnection.fileWrite("CUSTOMERS", itemId, item);
                if (m_mvConnection.getFileStatusCode() != 0)
                {
                    String msg = m_mvConnection.getFileStatusMessage();
                    JOptionPane.showMessageDialog(this, "Error while writing item " + itemId +
                            "\n" + msg, DIALOG_TITLE, JOptionPane.OK_OPTION);
                }
                loadCustomers();
            }
        }
        catch (MVException e)
        {
            JOptionPane.showMessageDialog(this, "MVSP Exception in file write: " + e.getErrorMessage(),
                    DIALOG_TITLE, JOptionPane.OK_OPTION);
        }
    }

    private void TCL()
    {
        ExecuteTCL executeTCL = new ExecuteTCL(this, m_mvConnection);
        executeTCL.setModal(true);
        executeTCL.setVisible(true);
    }

    private void listOrders()
    {
        int row = m_table.getSelectedRow();
        String itemId = (String)m_tableData.getValueAt(row, 0);

        CustOrders custOrders = new CustOrders(this, m_mvConnection, itemId);
        custOrders.setModal(true);
        custOrders.setVisible(true);
    }
    // -----------------------------------------------------------------------------------------------
    // WindowListener methods

    public void windowOpened(WindowEvent e)
    {
    }

    public void windowClosing(WindowEvent e)
    {
        disconnect();
    }

    public void windowClosed(WindowEvent e)
    {
        disconnect();
    }

    public void windowIconified(WindowEvent e){}

    public void windowDeiconified(WindowEvent e){}

    public void windowActivated(WindowEvent e){}

    public void windowDeactivated(WindowEvent e){}

    // -----------------------------------------------------------------------------------------------
    // private members

    private MVConnection m_mvConnection;
    private JButton m_btnConnect;
    private JButton m_btnTCL;
    private JButton m_btnNew;
    private JButton m_btnSave;
    private JButton m_btnTest;
    private JButton m_btnOrders;
    private JTextField m_txtUser;
    private JPasswordField m_txtPwd;
    private JTextField m_txtHost;
    private JTextField m_txtPort;
    private JTextField m_txtCustId;
    private JTextField m_txtCname;
    private JTextField m_txtCtitle;
    private JTextField m_txtOname;
    private JTextField m_txtAddr;
    private JTextField m_txtCity;
    private JTextField m_txtState;
    private JTextField m_txtPostal;
    private JTextField m_txtPhone;
    private JTextField m_txtFax;
    private JTextArea m_txtNote;
    private JTable m_table;
    private DataTable m_tableData;
    private String m_currentItemId;

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
                            TableLayout.FILL,                    // main
                            3                                   // Gutter
                    },

                    // Rows.
                    // -----
                    {
                            10,                                 // Gutter
                            100,                                // connect
                            3,                                  // Gutter
                            TableLayout.FILL,                   // data
                            3,                                  // Gutter
                            50,                                 // buttons
                            3                                   // Gutter
                    }
            };

    /**
     * Layout for the connection panel.
     *
     * @since 1.0
     */
    private final static double[][] CONNECTION_LAYOUT = new double[][]
            {
                    // Columns.
                    // --------
                    {
                            10,                                  // Gutter
                            75,                                 // Label
                            10,                                  // Gutter
                            TableLayout.FILL,                    // Text
                            10,                                  // Gutter
                            75,                                  // Label
                            10,                                  // Gutter
                            TableLayout.FILL,                    // Text
                            10,                                  // Gutter
                            100                                  // button
                    },

                    // Rows.
                    // -----
                    {
                            10,                                 // Gutter
                            23,                                 // Username row
                            3,                                  // Gutter
                            23,                                 // Password row
                            3                                   // Gutter
                    }
            };


    /**
     * Layout for the tabel panel.
     *
     * @since 1.0
     */
    private final static double[][] TABLE_LAYOUT = new double[][]
            {
                    // Columns.
                    // --------
                    {
                            3,                                  // Gutter
                            TableLayout.FILL,                    // Text
                            3
                    },

                    // Rows.
                    // -----
                    {
                            10,                                 // Gutter
                            TableLayout.FILL,                    // Text
                            10                                  // Gutter
                    }
            };

    /**
     * Layout for the data panel.
     *
     * @since 1.0
     */
    private final static double[][] DATA_LAYOUT = new double[][]
            {
                    // Columns.
                    // --------
                    {
                            3,                                   // Gutter
                            100,                                 // Label
                            3,                                   // Gutter
                            100,                                 // Text1
                            30,                                  // Gutter
                            100,                                 // Label2
                            3,                                   // Gutter
                            100,                                 // Text2
                            3,                                   // Gutter
                            TableLayout.FILL,                    // Text3
                            3                                    // Gutter
                    },

                    // Rows.
                    // -----
                    {
                            10,                                 // Gutter
                            23,                                 // Customer id
                            3,                                  // Gutter
                            23,                                 // Contact Name
                            3,                                  // Gutter
                            23,                                 // Contact Title
                            3,                                  // Gutter
                            23,                                 // Organization Name
                            3,                                  // Gutter
                            23,                                 // Address
                            3,                                  // Gutter
                            23,                                 // City
                            3,                                  // Gutter
                            23,                                 // State and postal
                            3,                                  // Gutter
                            23,                                 // Phone
                            3,                                  // Gutter
                            23,                                 // Fax
                            3,                                  // Gutter
                            TableLayout.FILL                    // Notes
                    }
            };


    /**
     * Layout for the table and data panels.
     *
     * @since 1.0
     */
    private final static double[][] FILE_LAYOUT = new double[][]
            {
                    // Columns.
                    // --------
                    {
                            3,                                  // Gutter
                            300,                               // table
                            3,                                 // Gutter
                            TableLayout.FILL,                   // data
                            3                                   // Gutter
                    },

                    // Rows.
                    // -----
                    {
                            3,                                 // Gutter
                            TableLayout.FILL,                  // table and data
                            3                                  // Gutter
                    }
            };

    /**
     * Layout for the buttons panel.
     *
     * @since 1.0
     */
    private final static double[][] BUTTONS_LAYOUT = new double[][]
            {
                    // Columns.
                    // --------
                    {
                            10,                                  // Gutter
                            80,                                 // Button
                            10,                                  // Gutter
                            120,                                 // Button
                            10,                                  // Gutter
                            120,                                 // Button
                            10,                                  // Gutter
                            120,                                 // Button
                            10,                                  // Gutter
                            120,                                 // Button
                            10,                                  // Gutter
                            120,                                 // Button
                            10                                   // Gutter
                    },

                    // Rows.
                    // -----
                    {
                            3,                                  // Gutter
                            30,                                 // buttons
                    }
            };
}
