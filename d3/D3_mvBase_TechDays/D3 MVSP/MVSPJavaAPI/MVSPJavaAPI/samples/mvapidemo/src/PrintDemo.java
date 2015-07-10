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
 * $Log: PrintDemo.java,v $
 * Revision 1.2  2014/01/31 21:25:18  hesam
 * Changed package name rocket to rocketsoftware.
 *
 * Revision 1.1  2010/07/14 22:00:20  hesam
 * no message
 *
 *
 ****************************************************************************************/

import com.rocketsoftware.mvapi.MVConnection;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.awt.print.*;

public class PrintDemo implements Printable, ActionListener {

    MVConnection m_mvConnection;

    public int print(Graphics g, PageFormat pf, int page) throws
                                                        PrinterException {

        if (page > 0) { /* We have only one page, and 'page' is zero-based */
            return NO_SUCH_PAGE;
        }

        /* User (0,0) is typically outside the imageable area, so we must
         * translate by the X and Y values in the PageFormat to avoid clipping
         */
        Graphics2D g2d = (Graphics2D)g;
        g2d.translate(pf.getImageableX(), pf.getImageableY());

        /* Now we perform our rendering */
        g.drawString("Hello world!", 100, 100);

        /* tell the caller that this page is part of the printed document */
        return PAGE_EXISTS;
    }

    public void actionPerformed(ActionEvent e)
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
              /* The job did not successfully complete */
             }
         }
    }

    public static void main(String args[]) {

        UIManager.put("swing.boldMetal", Boolean.FALSE);
        JFrame f = new JFrame("Hello World Printer");
        f.addWindowListener(new WindowAdapter() {
           public void windowClosing(WindowEvent e) {System.exit(0);}
        });
        JButton printButton = new JButton("Print Hello World");
        printButton.addActionListener(new PrintDemo());
        f.add("Center", printButton);
        f.pack();
        f.setVisible(true);
    }
}

