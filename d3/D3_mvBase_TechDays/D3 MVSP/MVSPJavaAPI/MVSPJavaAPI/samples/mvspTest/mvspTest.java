// package mvspTest;

import com.rocketsoftware.mvapi.*;
import java.util.Properties;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
import java.awt.event.WindowEvent;

import java.util.*; // for Date, used for timing


public class mvspTest extends Frame{
	
	// Connect
	static TextField tfHostName;
	static Label lHostName;
	static Label lPort;
	static TextField tfPort;
	static Button btConnect = null;
	static Button btClose = null;
	static ButtonListener buttonListener;
	static Choice chcDatabase;
	
	//Login
	static Label lUserName;
	static TextField tfUserName;
	static Label lUserPasswd;
	static TextField tfUserPasswd;

	 // Logto
	static Label lAccountName;
	static TextField tfAccountName;
	static Label lAccountPasswd;
	static TextField tfAccountPasswd;
	static Button btLogto=null;
	
	// Display area
	static TextArea taDisplay;
	
	static MVConnection mvcHandle;
	
	private static final long serialVersionUID = 1L;
	private static final String sEndOfItems = "<End of Items>";
	
	public mvspTest(){
		super("MVSP Java API");
	     setFont(new Font("dialog", Font.PLAIN,12));
	     setSize(700,600);
	     buttonListener = new ButtonListener();
	     addWindowListener(new Exit() );
	     setMenuBar( new MyMenuBar() );
	     setLayout( new FlowLayout() );
	     setVisible(true);
	}

	/**
	 * @param no args
	 */
	public static void main(String[] args) {
		mvspTest mvTest = new mvspTest();
		
		lHostName = new Label("hostname or IP address");
		mvTest.add(lHostName);
		tfHostName = new TextField("192.168.1.100",15);
        mvTest.add(tfHostName);
        
        lPort = new Label("Port");
        tfPort = new TextField("9000"); // default is 9000
        mvTest.add(lPort);
        mvTest.add(tfPort);
        
        chcDatabase = new Choice();
        chcDatabase.add("D3");
        chcDatabase.add("mvBase");
        //chcDatabase.add("Universe");
        //chcDatabase.add("UniData");
        mvTest.add(chcDatabase);
        
        lUserName = new Label("User Name");
        lUserPasswd = new Label("Password");
        tfUserName = new TextField("demoUser",15); // 15 chars wide
        tfUserPasswd = new TextField("",10); // 10 chars wide
        tfUserPasswd.setEchoChar('*');
        Panel pUserPass = new Panel();
        pUserPass.add( lUserName);
        pUserPass.add(tfUserName);
        pUserPass.add(lUserPasswd);
        pUserPass.add(tfUserPasswd);
        mvTest.add(pUserPass);
        
        btConnect = new Button("Connect");
        btConnect.addActionListener(buttonListener);
        mvTest.add(btConnect);
        
        btClose = new Button("Close Connection");
        btClose.addActionListener(buttonListener);
        mvTest.add(btClose);
        
        taDisplay = new TextArea("",20,80);
        mvTest.add(taDisplay);

        mvTest.paintAll(mvTest.getGraphics() );
	}
	
	void mvspConnect(){
        Properties props = new Properties();
        props.setProperty("username", tfUserName.getText());
        props.setProperty("password", tfUserPasswd.getText());
        String url = "jdbc:mv:"
        	+ chcDatabase.getSelectedItem()
        	+ ":"
        	+ tfHostName.getText() 
        	+ ":"
        	+ tfPort.getText();
        try {
        	mvcHandle = new MVConnection(url, props);
        }
        catch (Exception ex){
            System.out.println("new MVConnection: Unexpected exception: "
            		+ ex.toString());
            taDisplay.setText("new MVConnection:Unexpected exception: "
            		+ ex.toString() + ": " + ex.getMessage() + " Cause: " +ex.getCause() );
            return;
         }
        taDisplay.setText("Connected");
	}// mvspConnect
	
	void mvspClose(){
		try{
			mvcHandle.close();
		}
		catch (Exception ex){
            System.out.println("close: Unexpected exception: " + ex.toString());
            taDisplay.setText("close: Unexpected exception: " + ex.toString());
            return;
         }
		taDisplay.setText("Disconnected");
	}// mvspClose

	void mvspLogto(){
		try{
			mvcHandle.logTo(tfAccountName.getText(), tfAccountPasswd.getText());
		}
		catch (Exception ex){
            System.out.println("Logto: Unexpected exception: " + ex.toString());
            taDisplay.setText("Logto: Unexpected exception: " + ex.toString());
            return;
         }
		taDisplay.setText("Logto OK");
	}// mvspLogto
	
	class LogtoDialog extends Frame{
		private static final long serialVersionUID = 1L;
		public LogtoDialog(){
		super("Logto");
	     setFont(new Font("dialog", Font.PLAIN,12));
	     setSize(300,100);
	     buttonListener = new ButtonListener();
	     addWindowListener(new CloseFrame() );
	     setLayout( new FlowLayout() );
	     lAccountName = new Label("Account");
	     tfAccountName = new TextField("",20);
	     add(lAccountName);
	     add(tfAccountName);
	     lAccountPasswd = new Label("Password");
	     tfAccountPasswd = new TextField("",10);
	     tfAccountPasswd.setEchoChar('*');
	     add(lAccountPasswd);
	     add(tfAccountPasswd);
	     btLogto = new Button("Logto");
	     btLogto.addActionListener(buttonListener);
	     add(btLogto);
	     setVisible(true);
		}// constructor
	} // LogtoDialog
	
	class FileDialog extends Frame{
		private static final long serialVersionUID = 1L;
		Label lFileName;
		TextField tfFileName;
		Label lItemID;
		TextField tfItemID;
		TextArea taItemBody;
		FileButtonListener fbListener;
		Button btRead;
		Button btReadU;
		Button btWrite;
		Button btWriteU;
		Button btRelease;
		Button btDelete;
		Button btSelect;
		Button btReadNext;
		TextField tfStatus;
		
		public FileDialog(){
		super("File access");
	     setFont(new Font("dialog", Font.PLAIN,12));
	     setSize(700,600);
	     fbListener = new FileButtonListener();
	     addWindowListener(new CloseFrame() );
	     setLayout( new FlowLayout() );
	     lFileName = new Label("File Name");
	     tfFileName = new TextField("",40);
	     add(lFileName);
	     add(tfFileName);
	     lItemID = new Label("Item ID");
	     tfItemID = new TextField("",40);
	     add(lItemID);
	     add(tfItemID);
	     taItemBody = new TextArea("",20,80);
	     add(taItemBody);
	     btRead = new Button("Read");
	     btRead.addActionListener(fbListener);
	     add(btRead);
	     btReadU = new Button("ReadU");
	     btReadU.addActionListener(fbListener);
	     add(btReadU);
	     btWrite = new Button("Write");
	     btWrite.addActionListener(fbListener);
	     add(btWrite);
	     btWriteU = new Button("WriteU");
	     btWriteU.addActionListener(fbListener);
	     add(btWriteU);
	     btRelease = new Button("Release item lock");
	     btRelease.addActionListener(fbListener);
	     add(btRelease);
	     btDelete = new Button("Delete Item");
	     btDelete.addActionListener(fbListener);
	     add(btDelete);
	     btSelect = new Button("Select file");
	     btSelect.addActionListener(fbListener);
	     add(btSelect);
	     btReadNext = new Button("Readnext item id");
	     btReadNext.addActionListener(fbListener);
	     add(btReadNext);
	     tfStatus = new TextField(80);
	     add(tfStatus);
	     setVisible(true);
		}// FileDialog() constructor

		// inner class used to process FileDialog Buttons.
		class FileButtonListener implements ActionListener {
			public void actionPerformed(ActionEvent event) 	{
				Object obj = event.getSource();
				if (obj instanceof Button ) {	// clicked a GUI button
					tfStatus.setText("");
					try
					{
						Button button = (Button)obj;
						if ( button == btRead) {
							System.out.println("Reading . . . ");
							taItemBody.setText(
									mvcHandle.swap(
											mvcHandle.fileRead(tfFileName.getText(),tfItemID.getText())
											, MVConstants.AM, "\n"
										)
								);
						}
						else if ( button == btReadU) {
							System.out.println("Read setting item lock . . . ");
							taItemBody.setText(
									mvcHandle.swap(
											mvcHandle.fileReadU(tfFileName.getText(),tfItemID.getText())
											, MVConstants.AM, "\n"
									)
							);
						}
						else if (button == btWrite){
							System.out.println("Writing . . . ");
							
							// Start ugly kludge.
							// Treachery!!!
							// On Windows, keying in several lines terminates
							// each with CR LF, as expected, BUT a swap of "\n" to AM only
							// replaces the linefeed!!!
							// Yet, on read, swapping AM with "\n" and setting the
							// result in the text area displays fine, rather than
							// each line starting indented the length of the
							// previous line because the CR is missing.
							// So, to hack around this asymetric nonsense, strip out any
							// CRs first.
							taItemBody.setText(
									mvcHandle.swap(taItemBody.getText(),
											"\r",""));
							// End ugly kludge
							
							mvcHandle.fileWrite(
										tfFileName.getText()
										, tfItemID.getText()
										, mvcHandle.swap(taItemBody.getText()
												, "\n"
												, MVConstants.AM
											)
								);
						}
						else if (button == btWriteU){
							System.out.println("Write keeping item lock . . . ");
							mvcHandle.fileWriteU(tfFileName.getText()
									, tfItemID.getText()
									, mvcHandle.swap(taItemBody.getText()
											, "\n"
											, MVConstants.AM
										)
								);
						}
						else if (button == btDelete){
							System.out.println("Deleting item . . . ");
							mvcHandle.fileDelete(tfFileName.getText(),tfItemID.getText());
						}
						else if (button == btRelease){
							System.out.println("Releasing item lock. . . ");
							mvcHandle.fileRelease(tfFileName.getText(),tfItemID.getText());
						}
						else if (button == btSelect){
							System.out.println("Selecting file . . . ");
							mvcHandle.fileSelect(tfFileName.getText());
						}
						else if (button == btReadNext)
						{
							tfItemID.setText(mvcHandle.fileReadNext());
						} 
						else
						{
							System.out.println("That button is not yet implemented in FileButtonListener");
							tfStatus.setText("That button is not yet implemented in FileButtonListener");
						}
						

						if (mvcHandle.getFileStatusCode() != 0){
							tfStatus.setText(mvcHandle.getFileStatusMessage());
						}
						if (button == btReadNext)
						{
							if (mvcHandle.getEol())
							{
								tfStatus.setText(tfStatus.getText() + " <End of List>");
							}
						} 
					} 
					catch (MVException e)
					{
						tfStatus.setText("Exception!!  " + e.getErrorMessage());
					}
				}// button
			}// actionPerformed
		}// FileButtonListener
	} // FileDialog
	
	class ExecuteDialog extends Frame{
		private static final long serialVersionUID = 1L;
		Label lCommand = new Label("Command");
		TextField tfCommand = new TextField("",80);
		Label lStack = new Label("Stacked input");
		TextArea taStack = new TextArea("",5,80);
		TextArea taResult = new TextArea("",20,80);
		Button btExecute = new Button("Go");
		ExecuteListener exListener = new ExecuteListener();
		
		// Listener for btExecute
		class ExecuteListener implements ActionListener {
			Button button; // who's got the button?
			boolean bResult;
			
			public void actionPerformed(ActionEvent event) 	{
				Object obj = event.getSource();
				if (obj instanceof Button ) {
					button = (Button)obj;
					if (button == btExecute){
						taResult.setText(""); // Clear display
						try{
							// Strip out CRs, if any.
							// See comments in btWrite handler above.
							taStack.setText(
									mvcHandle.swap(
											taStack.getText()
											,"\r"
											,""
									)
							);
							mvcHandle.execute(
									tfCommand.getText()
									,mvcHandle.swap(
											taStack.getText()
											,"\n"
											,MVConstants.AM
									)
							);
							taResult.setText(
									mvcHandle.swap(
											mvcHandle.getExecuteCapturing()
											,MVConstants.AM
											, "\n"
									)
							);
						}
						catch (MVException mveMess){
							taResult.setText(mveMess.getErrorMessage());
						}
					}
				}
			}// ExecuteListener.actionPerformed
		}// class ExecuteListener
		
		ExecuteDialog(){
			super("Execute");
		    setFont(new Font( Font.MONOSPACED, Font.PLAIN,12));
		    setSize(700,600);
		    addWindowListener(new CloseFrame() );
		    setLayout( new FlowLayout() );
		    Panel pCommand = new Panel();
		    pCommand.add(lCommand);
		    pCommand.add(tfCommand);
		    add(pCommand);
		    Panel pStack = new Panel();
		    pStack.add(lStack);
		    pStack.add(taStack);
		    add(pStack);
		    add(btExecute);
		    btExecute.addActionListener(exListener);
		    add(taResult);
		    setVisible(true);
		    paintAll(getGraphics());
		}
	}// class ExecuteDialog
	
	class QueryStreamDialog extends Frame{
		private static final long serialVersionUID = 1L;
		Choice chcOperation = new Choice();
		Label lFileName = new Label("FileName");
		TextField tfFileName = new TextField("",50);
		Label lSelCrit = new Label ("Selection criteria");
		TextField tfSelCrit = new TextField("",80);
		Label lSortCrit = new Label ("Sort criteria");
		TextField tfSortCrit = new TextField("",80);
		Label lOutputList = new Label("Output list");
		TextField tfOutputList = new TextField("",80);
		Label lExplicitIds = new Label("Explicit Item-ids");
		TextField tfExplicitIds = new TextField("",80);
		Button btQueryStream = new Button("Go");
		QueryStreamListener qsListener = new QueryStreamListener();
		MVResultSet mvResults;
		Button btOneRow = new Button("Get one row");
		Label lRowCount = new Label("Rows to get");
		TextField tfRowCount = new TextField("20",5);
		Button btManyRows = new Button("Get multiple rows");
		Button btAllRows = new Button("Get all rows");
		TextArea taResult = new TextArea("",20,80);
		Checkbox cbTable = new Checkbox("Generate Table",false);
		DisplayTable dtResults;
		
		// Listener for btQueryStream
		class QueryStreamListener implements ActionListener {
			MVStatement mvStatement;
			Button button; // who's got the button?
			boolean bResult;
			String[] saUnparsedColumns;
			int nColumnParser;
			
			public void actionPerformed(ActionEvent event) 	{
				Object obj = event.getSource();
				if (obj instanceof Button ) {
					button = (Button)obj;
					if (button == btQueryStream){
						taResult.setText(""); // Clear display
						doQuery();
						if (cbTable.getState()){
							dtResults = new DisplayTable();
							dtResults.setTitle(chcOperation.getSelectedItem() + " "
								+ tfFileName.getText() + " "
								+ tfSelCrit.getText() + " "
								+ tfSortCrit.getText());
							
							// Generate a string array containing the column headers:
							// - eliminating "eval" connective, but keeping the next double-quoted
							// string, but stripping the surrounding double-quotes.
							// - eliminating "conv" and "fmt" connectives and the
							// double-quoted values that follow each.
							// The stuff we want to keep, we'll bubble to the left in the
							// unparsed columns array.  Then, when we finally know how many
							// columns we have, we'll instantiate the array to pass to 
							// setColumnNames.
							String[] saColumnNames;
							saUnparsedColumns = tfOutputList.getText().split(" ");
							int nLen = saUnparsedColumns.length;
							int nNewPos = 0;
							for (nColumnParser = 0; nColumnParser < nLen; nColumnParser++){
								String sTmp = saUnparsedColumns[nColumnParser];
								switch (1){
								case 1:
									if (sTmp.compareToIgnoreCase("eval") == 0){
										nColumnParser++; // skip "eval"
										saUnparsedColumns[nNewPos] = getConnective();
										nNewPos++;
										break;
									}
									if ((sTmp.compareToIgnoreCase("conv") == 0)
										|| (sTmp.compareToIgnoreCase("fmt") == 0)){
										nColumnParser++; // skip "conv" or "fmt"
										sTmp = getConnective();
										// but do nothing with it, so it's lost
										break;
									}
									if (sTmp.compareToIgnoreCase("") == 0) {
										// Original string had more than one
										// space between two words.
										break; // nuthin to do
									}
									saUnparsedColumns[nNewPos]=sTmp;
									nNewPos++;
								}
							}
							saColumnNames = new String[nNewPos];
							for (int i=0; i< nNewPos; i++){
								saColumnNames[i] = saUnparsedColumns[i];
							}
							dtResults.setColumnNames(saColumnNames);
						}
						taResult.setText("Got " + mvResults.getRowCount() + " rows");
					}
		            else if (button == btOneRow){
		            	String sResult = getOneRow();
		            	if (cbTable.getState()){
		            		dtResults.addRow(sResult,MVConstants.AM);
		            		dtResults.paintAll(dtResults.getGraphics() );
		            	}
		            	taResult.setText(sResult);
		            }
		            else if (button == btManyRows){
		            	int iLim = Integer.parseInt(tfRowCount.getText());
		            	for (int i = 0; i < iLim; i++ ){
		            		if (btManyRows.isEnabled()){
				            	String sResult = getOneRow();
				            	if (cbTable.getState()){
				            		dtResults.addRow(sResult,MVConstants.AM);
				            	}
			            		taResult.append(sResult);
			            		taResult.append("\n");
		            		}
		            		else{
		            			// If reading, say, 20 at a time and there are
		            			// 34 rows, the button becomes disabled after
		            			// the last row and we want to end the "for" loop.
		            			i=iLim; // End if button disables
		            		}
		            	}
		            	if (cbTable.getState()){
		            		dtResults.paintAll(dtResults.getGraphics() );
		            	}
		            }
		            else if (button == btAllRows){
		            	taResult.setText(""); // Clear display
		            	//int iLim = mvResults.getRowCount();// always returns 0 for streams
		            	//for (int i = 1; i < iLim; i++){
		            	do{
		            		Date dStart = new Date();
			            	long x= dStart.getTime();
			            	String sResult = getOneRow();
			            	//dStart = new Date();
			            	//long x2 = dStart.getTime();
			            	if (cbTable.getState()){
			            		dtResults.addRow(sResult,MVConstants.AM);
			            	}
			            	taResult.append(sResult);
			            	//dStart = new Date();
			            	//long x3 = dStart.getTime();
		            		taResult.append("\n");
		            		//dStart = new Date();
		            		//long x4 = dStart.getTime();
		            		System.out.print(x + "\n");
		            		//+ x2 + " " + x3 + " " + x4 + "\n");
		            	} while (btAllRows.isEnabled()); // Button disabled on get after final row.
		            	if (cbTable.getState()){
		            		dtResults.paintAll(dtResults.getGraphics() );
		            	}
		            }// if button == .... sieve
				} // instanceof Button
			} // ActionPerformed
			
			// Given the array sTmp and element i, return the string that
			// starts with '"' and ends with '"', but without the quotes.
			String getConnective(){
				int nFirst,nLast;
				String sConnective="",sTmp;
				sTmp = saUnparsedColumns[nColumnParser];
				nFirst = sTmp.indexOf('"');
				nLast = sTmp.indexOf('"',nFirst+1);
				if (nLast != (-1)){
					return sTmp.substring(nFirst+1, nLast);
				}
				nFirst++; // skip '"'
				do{
					nLast = sTmp.length();
					sConnective = sConnective + sTmp.substring(nFirst,nLast) + " ";
					nColumnParser++;
					sTmp = saUnparsedColumns[nColumnParser];
					nFirst = 0;
					nLast = sTmp.indexOf('"',nFirst);
					if (nLast != -1){
						return sConnective + sTmp.substring(nFirst, nLast);
					}
				}
				while (true);
			}
			
			//disable the "get..." buttons
			void disableGetButtons(){
				btOneRow.setEnabled(false);
				btManyRows.setEnabled(false);
				btAllRows.setEnabled(false);
				cbTable.setEnabled(true); //inverse of "get" buttons
			}
			
			// Enable the "get..." buttons
			void enableGetButtons(){
				btOneRow.setEnabled(true);
				btManyRows.setEnabled(true);
				btAllRows.setEnabled(true);
				cbTable.setEnabled(false); //inverse of "get" buttons
			}
			
			// Get one row of result
			String getOneRow(){
				String sResult;
				bResult = false;
				try{
            		bResult = mvResults.next();
            	}
            	catch(MVException eErr){
            		sResult = ("Got exception:"
							+ eErr.getErrorMessage());
            		return sResult;
            	}
            	try{
            		if (bResult){
            			sResult = mvResults.getCurrentRow();
            		}
            		else{
            			disableGetButtons();
            			sResult = sEndOfItems;
            		}
            	}
            	catch(MVException eErr){
					sResult = ("Got exception:"
							+ eErr.getErrorMessage());
            	}
            	return sResult;
			}// getOneRow
			
			void doQuery(){
				
				disableGetButtons();
				try{
					mvStatement = mvcHandle.createStatement();
				}
				catch (MVException eErr){
					taResult.setText("Got exception:"
							+ eErr.getErrorMessage());
					return;
				}
				String AM = MVConstants.AM;
				
				String parameters = chcOperation.getSelectedItem().toUpperCase() + AM
				+ tfFileName.getText() + AM
				+ tfSelCrit.getText() + AM
				+ tfSortCrit.getText() + AM
				+ tfOutputList.getText() + AM
				+ tfExplicitIds.getText() +AM;
				String query = "MVAPI.QUERY.STREAM" + AM + parameters;
				try{
	            	bResult = mvStatement.execute(query);
	            }
	            catch(MVException eErr){
	            	taResult.setText("Got exception:"
							+ eErr.getErrorMessage());
					return;
	            }
	            if (bResult){
	            	try{
	            		mvResults = mvStatement.getResultSet();
	            	}
	            	catch(MVException eErr){
		            	taResult.setText("Got exception:"
								+ eErr.getErrorMessage());
						return;
		            }
	            	btOneRow.setEnabled(true);
					btManyRows.setEnabled(true);
					btAllRows.setEnabled(true);
	            }
	            else{
	            	taResult.setText("Query stream returned \"false\"");
	            }
			}// doQuery
		}// class QueryStreamListener
		
		/*
		 * QueryStreamDialog class constructor
		 */
		public QueryStreamDialog(){
		super("Query Stream");
		setFont(new Font("dialog", Font.PLAIN,12));
		setSize(700,600);
		buttonListener = new ButtonListener();
		addWindowListener(new CloseFrame() );
		setLayout( new FlowLayout() );
		add(chcOperation);
			chcOperation.add("Query");
			chcOperation.add("Count");
			chcOperation.add("Clear");
			chcOperation.add("Exist");
			chcOperation.add("Doc");
			//chcOperation.add("Version");
			//chcOperation.add("Update");
			//chcOperation.add("Call");
			//chcOperation.add("Select");
		Panel pFileName = new Panel();
		pFileName.add(lFileName);
		pFileName.add(tfFileName);
		add(pFileName);
		Panel pSelCrit = new Panel();
		pSelCrit.add(lSelCrit);
		pSelCrit.add(tfSelCrit);
		add(pSelCrit);
		Panel pSortCrit = new Panel();
		pSortCrit.add(lSortCrit);
		pSortCrit.add(tfSortCrit);
		add(pSortCrit);
		Panel pOutputList = new Panel();
		pOutputList.add(lOutputList);
		pOutputList.add(tfOutputList);
		add(pOutputList);
		Panel pExplicitIds = new Panel();
		pExplicitIds.add(lExplicitIds);
		pExplicitIds.add(tfExplicitIds);
		add(pExplicitIds);
		// Create the "get results" buttons
		Panel pButtons = new Panel();
		btQueryStream.addActionListener(qsListener);
		pButtons.add(cbTable);
		pButtons.add(btQueryStream);
		btOneRow.addActionListener(qsListener);
		btOneRow.setEnabled(false);
		pButtons.add(btOneRow);
		pButtons.add(lRowCount);
		pButtons.add(tfRowCount);
		btManyRows.addActionListener(qsListener);
		btManyRows.setEnabled(false);
		pButtons.add(btManyRows);
		btAllRows.addActionListener(qsListener);
		btAllRows.setEnabled(false);
		pButtons.add(btAllRows);
		add(pButtons);
		add(taResult);
	    setVisible(true);
	    paintAll(getGraphics() );
		}// QueryStreamDialog constructor
	}// QueryStreamDialog class
	
	//class cDisplayTable extends JFrame{
		//JTable tbResults;
		/*
		 * JTable seems to be column oriented; it has an add column
		 * method, but not add row.
		 * We need row-oriented, since we want to first establish
		 * the columns, a mere initialization, and then enter the
		 * main loop of adding rows.
		 * 
		 * So, here is a crude, but effective, roll-your-own
		 * Display Table, which can add new rows on the fly.
		 * */
	class DisplayTable extends Frame{
		private static final long serialVersionUID = 1L;
		static final int iMaxColumns = 20;
		static final int iMaxRows = 40;
		DisplayRow drColumnNames;
		DisplayRow[] draRows;
		int iRows,iColumns;
		
		public DisplayTable(){
			super("Results");
			setSize(800,500);
			
			draRows = new DisplayRow[iMaxRows];
			addWindowListener(new CloseFrame() );
			setVisible(true);
		}
		public int getRowCount() {
		    return iRows;
		  }
		public int getColumnCount() {
		    return iColumns;
		  }
		
		public String getValueAt(int nRow, int nCol) {
		    if (nRow < 0 || nRow >= iRows)
		      return "";
		    return draRows[nRow].getText(nCol);
		  }
		
		public String getColumnName(int iColumn) {
		    return drColumnNames.getText(iColumn);
		}
		
		public void setColumnNames(String[] saColumnNames){
			iColumns = saColumnNames.length;
			if (iColumns == 0){
				return;
			}
			if (iColumns > iMaxColumns){
				iColumns = iMaxColumns;
			}
			drColumnNames = new DisplayRow(iColumns);
			for (int i=0; i < iColumns; i++){
				drColumnNames.setCell(i,saColumnNames[i]);
				drColumnNames.setCellBold(i);
			}
			
			// Fails.  Generates one column!  Then two as rows are added!
			//setLayout( new GridLayout(iMaxRows,iColumns) );
			
			//Try this instead, since Sun says:
			//"Specifying the number of columns affects the layout only
			//when the number of rows is set to zero."
			// http://java.sun.com/j2se/1.5.0/docs/api/java/awt/GridLayout.html
			
			// Well, that's cheezy.  Too.
			// Exception in thread "AWT-EventQueue-0" java.lang.IllegalArgumentException:
			// rows and cols cannot both be zero
			//GridLayout glDisplayTable = new GridLayout(0,0);
			//glDisplayTable.setColumns(iColumns);
			GridLayout glDisplayTable = new GridLayout(0,iColumns);
			
			// still doesn't work; try commenting next line.
			//glDisplayTable.setRows(iMaxRows);
			
			// Yesssss!!!!
			setLayout(glDisplayTable);
			
			drColumnNames.addToParent(this);
			paintAll(getGraphics()); // more reliable than repaint();
			//repaint();
		}
		public void addRow(String sRow, String sDelim){
			String[] saCells;
			if (iRows < iMaxRows){
				draRows[iRows] = new DisplayRow(iColumns);
				saCells = sRow.split(sDelim);
				int iLim = saCells.length;
				if (iLim > iColumns){
					iLim=iColumns;
				}
				for (int i=0; i<iLim; i++){
					draRows[iRows].setCell(i,saCells[i]);
				}
				draRows[iRows].addToParent(this);
				//caller does paintAll
				//repaint();
				iRows++;
			}
		}// addRow
	}// class DisplayTable
	
	class DisplayRow {
		TextField[] tfaCells;
		int iCells;
		
		DisplayRow(int iSize){
			iCells = iSize;
			tfaCells = new TextField[iSize];  // Allocate array
			for (int i=0; i<iSize; i++){
				tfaCells[i] = new TextField(); // init each element
			}
		}
		void setCell(int iCell,String sString){
			tfaCells[iCell].setText(sString);
		}
		void setCellBold(int iCell){
			tfaCells[iCell].setFont(new Font("serif", Font.BOLD, 16));
		}
		
		String getText(int iCell){
			return tfaCells[iCell].getText();
		}
		void addToParent(Frame fParent){
			for (int i=0; i<iCells; i++){
				fParent.add(tfaCells[i]);
			}
		}
	}// class DisplayRow
	
//	inner class used to process Global Buttons.
	class ButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent event) 	{
			Object obj = event.getSource();
			if (obj instanceof Button ) {	// press a button on GUI
				Button button = (Button)obj;
				if ( button == btConnect) {
					System.out.println("Connecting . . . ");
					taDisplay.setText("Connecting . . . ");
					mvspConnect();
				}
				else if (button == btClose){
					System.out.println("DisConnecting . . . ");
					taDisplay.setText("DisConnecting . . . ");
					mvspClose();
				}
				else if (button == btLogto){
					String sAccountName = tfAccountName.getText();
					System.out.println("Logging to "
							+ sAccountName);
					taDisplay.setText("Logging to "
							+ sAccountName);
					mvspLogto();
				}
			}
		}// actionPerformed
	}// ButtonListener
	
	/*
	 *  ItemListener for chcDatabase
	 */
	public void itemStateChanged (ItemEvent e){
		//String s = (String) e.getItem();
	}
	/**
	   * Inner class used to build a menu for the main window.
	   * */
	   class MyMenuBar extends MenuBar {
		/**
		 * 
		 */
		private static final long serialVersionUID = 1L;
		//protected MenuItem miEdit = null;
		protected MenuItem miLogto = null;
		protected MenuItem miQueryStream = null;
		protected MenuItem miFile = null;
		protected MenuItem miExecute = null;

		class MIListener implements ActionListener {
			public void actionPerformed( ActionEvent e ) {
				MenuItem mi = (MenuItem)e.getSource();
				if (mi == miLogto){
					new LogtoDialog();
				}
				else if (mi == miQueryStream){
					new QueryStreamDialog();
				}
				else if (mi == miFile){
					new FileDialog();
				}
				else if (mi == miExecute){
					new ExecuteDialog();
				}
			}// actionPerformed
		}// MIListener
		/**
	       * Menu constructor
	       */
	      public MyMenuBar()
	      {
		   super();
		   MIListener milistener = new MIListener();

		   Menu mMenu = new Menu("Actions");

		   miLogto = new MenuItem("Logto");
		   miQueryStream = new MenuItem("Query stream");
		   miFile = new MenuItem("File access");
		   miExecute = new MenuItem("Execute");
		   
		   mMenu.add( miLogto );
		   mMenu.add( miQueryStream );
		   mMenu.add( miFile  );
		   mMenu.add(miExecute);

		   miLogto.addActionListener( milistener);
		   miQueryStream.addActionListener( milistener);
		   miFile.addActionListener(milistener);
		   miExecute.addActionListener(milistener);

	   	   add(mMenu);
	      } // Constructor
	   }// MyMenuBar
	/*
	 * Inner class used to exit the main frame when closing the application
	 */
	  class Exit extends java.awt.event.WindowAdapter {
	     public void windowClosing(WindowEvent event) {
//	    	 System.out.println("main window exited");
		     setVisible( false );
		     dispose();
		     System.exit(0);
	     }
	  }// Exit class
	  
	//	inner class used to exit a frame when closing that frame
     class CloseFrame extends java.awt.event.WindowAdapter {
        public void windowClosing(WindowEvent event) {
           Frame fToClose = (Frame) event.getWindow();
           fToClose.setVisible(false);
           fToClose.dispose();
        }
     }
}
