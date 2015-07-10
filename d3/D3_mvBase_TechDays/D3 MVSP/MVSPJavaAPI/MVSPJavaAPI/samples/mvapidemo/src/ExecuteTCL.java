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
 * $Log: ExecuteTCL.java,v $
 * Revision 1.3  2014/01/31 21:24:39  hesam
 * Changed package name rocket to rocketsoftware.
 *
 * Revision 1.2  2010/06/23 00:06:48  hesam
 * Added a print button to print the results
 *
 * Revision 1.1  2010/02/26 18:29:02  hesam
 * Created.
 *
 *
 ****************************************************************************************/

import layout.TableLayout;

import javax.swing.*;
import java.awt.*;
import java.awt.print.Printable;
import java.awt.print.PageFormat;
import java.awt.print.PrinterException;
import java.awt.print.PrinterJob;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.net.URL;

import com.rocketsoftware.mvapi.MVConnection;
import com.rocketsoftware.mvapi.MVConstants;
import com.rocketsoftware.mvapi.exceptions.MVException;

/**
 *
 * @author Hesam Shamshiri
 * @version $Revision: 1.3 $
 */
public class ExecuteTCL extends JDialog implements ActionListener, Printable
{
    ExecuteTCL(JFrame parent, MVConnection connection)
    {
        super(parent);
        m_mvResult = "";
        m_mvConnection = connection;
        constructUI();
        setLocation((int)(parent.getLocation().getX() + 100), (int)(parent.getLocation().getY() + 100));
    }

    public void actionPerformed(ActionEvent e)
    {
        Object source = e.getSource();
        if (source == m_btnExecute)
       {
           executeTCL();
       }
       else
       if (source == m_btnPrint)
       {
           printResults();
       }
       if (source == m_btnClose)
       {
           dispose();
       }
    }

    private void executeTCL()
    {
        String command = m_txtTCL.getText();
        m_mvResult = "";
        try
        {
            m_mvConnection.execute(command);
            m_mvResult = m_mvConnection.getExecuteCapturing();
            int amc = m_mvConnection.dCount(m_mvResult, MVConstants.ATTR_MARK);
            StringBuilder stringBuilder = new StringBuilder();
            for (int line=0; line<amc; line++)
            {
                stringBuilder.append(m_mvConnection.extract(m_mvResult, line));
                stringBuilder.append("\n");
            }
            m_txtResult.setText( stringBuilder.toString() );
        }
        catch (MVException e)
        {
            JOptionPane.showMessageDialog(this, "Exception while executing command: \n"
                        + e.getErrorMessage(), "Execute TCL", JOptionPane.OK_OPTION);
        }

    }

    private void printResults()
    {
        PrinterJob job = PrinterJob.getPrinterJob();
        job.setPrintable(this);
        boolean ok = job.printDialog();
        if (ok)
        {
            try
            {
                 job.print();
            }
            catch (PrinterException ex)
            {
            }
        }

    }

    /**
     * Constructs the UI for this form.
     */
    private void constructUI()
    {
        // Initialize the form.
        // --------------------
        setTitle("TCL");

        // Set form size.
        // --------------
        Toolkit toolkit = Toolkit.getDefaultToolkit();
        Dimension dimension = toolkit.getScreenSize();
        setSize((int)(dimension.getWidth()*.75), (int)(dimension.getHeight()*.75));

        setLayout( new TableLayout( LAYOUT ));

        JLabel lblTCL = new JLabel("TCL Command");
        m_txtTCL = new JTextField();

        JLabel lblResult = new JLabel("Result");
        m_txtResult = new JTextArea();
        m_txtResult.setEditable(false);

        m_btnExecute = new JButton("Execute");
        m_btnPrint = new JButton("Print");
        m_btnClose = new JButton("Close");
        add("1, 1", lblTCL);
        add("1, 3", m_txtTCL);
        add("1, 5", lblResult);
        add("1, 7", new JScrollPane(m_txtResult));
        JPanel buttons = new JPanel( new GridLayout(1, 3));
        buttons.add(m_btnExecute);
        buttons.add(m_btnPrint);
        buttons.add(m_btnClose);
        add("1, 9", buttons);
        m_btnExecute.addActionListener(this);
        m_btnClose.addActionListener(this);
        m_btnPrint.addActionListener(this);

        getRootPane().setDefaultButton(m_btnExecute);
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
                            23,                                 // TCL label
                            3,                                  // Gutter
                            23,                                 // TCL command
                            3,                                  // Gutter
                            23,                                 // Result label
                            3,                                  // Gutter
                            TableLayout.FILL,                   // result
                            3,                                  // Gutter
                            30,                                 // buttons
                            3                                   // Gutter
                    }
            };


    private MVConnection m_mvConnection;
    private JLabel m_lblTCL;
    private JTextField m_txtTCL;
    private JLabel m_lblResult;
    private JTextArea m_txtResult;
    private JButton m_btnExecute;
    private JButton m_btnPrint;
    private JButton m_btnClose;
    private String m_mvResult;
    public int print(Graphics g, PageFormat pf, int page) throws PrinterException
    {
        if (page > 0)
        { /* We have only one page, and 'page' is zero-based */
            return NO_SUCH_PAGE;
        }

        /* User (0,0) is typically outside the imageable area, so we must
         * translate by the X and Y values in the PageFormat to avoid clipping
         */
        Graphics2D g2d = (Graphics2D)g;
        g2d.translate(pf.getImageableX(), pf.getImageableY());
        g2d.setFont( new Font("Monospaced", Font.PLAIN, 10));
        try
        {
            int amc = m_mvConnection.dCount(m_mvResult, MVConstants.ATTR_MARK);
            for (int line=0; line<amc; line++)
            {
                String text = m_mvConnection.extract(m_mvResult, line);
                g.drawString(text, 1, 10*line);
            }
        }
        catch (MVException e)
        {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
        /* tell the caller that this page is part of the printed document */
        return PAGE_EXISTS;
    }
}
