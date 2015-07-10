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
 * $Log: DataTable.java,v $
 * Revision 1.2  2014/01/31 21:24:17  hesam
 * Changed package name rocket to rocketsoftware.
 *
 * Revision 1.1  2009/11/01 20:16:49  hesam
 * Created.
 *
 *
 ****************************************************************************************/

import com.rocketsoftware.mvapi.utility.MVString;
import com.rocketsoftware.mvapi.MVConstants;

import javax.swing.table.AbstractTableModel;
import javax.swing.event.TableModelEvent;
import java.util.ArrayList;

/**
 * Created by IntelliJ IDEA.
 * User: hshamshiri
 * Date: Oct 31, 2009
 * Time: 3:53:21 PM
 * To change this template use File | Settings | File Templates.
 */
public class DataTable extends AbstractTableModel
{
    private ArrayList<String> m_columns;
    private ArrayList<String> m_rows;

    /**
     * Constructs a DataTable objects.
     */
    public DataTable(String [] columns)
    {
        m_rows = new ArrayList<String>();
        m_columns = new ArrayList<String>(columns.length);
        for (String column : columns)
        {
            m_columns.add(column);
        }
    }

    /**
     * Gets the number of rows.
     *
     * @return row count
     */
    public int getRowCount()
    {
        return m_rows.size();
    }

    public int getColumnCount()
    {
        return m_columns.size();
    }

    public Object getValueAt(int rowIndex, int columnIndex)
    {
        String result = "";
        if (rowIndex < m_rows.size())
        {
            if (columnIndex < m_columns.size())
            {
                String row = m_rows.get(rowIndex);
                result = MVString.extract(row, columnIndex+1);
            }
        }
        return result;
    }

    public void addRow(String row)
    {
        m_rows.add(row);
        int rowNum = m_rows.size()-1;
        fireTableChanged(new TableModelEvent(this, rowNum, rowNum,
                             TableModelEvent.ALL_COLUMNS, TableModelEvent.INSERT));
    }

    public void addRow(String itemId, String row)
    {
        addRow(itemId + MVConstants.AM + row);
    }

    public void clear()
    {

        m_rows.clear();
//        fireTableChanged(new TableModelEvent(this, 0, size-1,
//                             TableModelEvent.ALL_COLUMNS, TableModelEvent.DELETE);
    }

    @Override
    public String getColumnName(int column)
    {

        if (column < m_columns.size())
        {
            return m_columns.get(column);
        }
        else
        {
            return super.getColumnName(column);
        }
    }

    @Override
    public void fireTableRowsInserted(int firstRow, int lastRow)
    {
        super.fireTableRowsInserted(firstRow, lastRow);    //To change body of overridden methods use File | Settings | File Templates.
    }
}
