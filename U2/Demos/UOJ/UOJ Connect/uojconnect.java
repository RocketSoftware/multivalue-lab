// Pogram project  : uojconnect.java
// Pogram function : Demo to use the UniSession & UniFile Objects.
// Comparable ver. : UniData 7.x & UniVerse 11.x
// Date : 2/15/2012 (version 1.0)
//

import java.io.*;
import asjava.uniobjects.*;
import asjava.uniclientlibs.*;

public class uojconnect{

	public static String xDataSourceType = "UNIDATA";
	public static String xServiceName;
	public static String xHostName;
	public static String xUserName;
	public static String xPassword;
	public static String xAccount;
	public static String xFile;
	public static String xRecordID;
	public static String xTmp;
	public static int vTmp = 1;
	public static int vldlength = 1;
      	
	public static void main( String args[]){
		UniJava uJava = new UniJava();
		System.out.println("Version number = " + uJava.getVersionNumber() );
		System.out.println("Max # Sessions = " + uJava.getMaxSessions() );
		
		try{
			UniSession uSession = uJava.openSession();
			System.out.println("openSession is successful");
			
			try {
			xTmp = inputStringCheck("Choose DataSourceType: 1) UniData (Default) 2) UniVerse: ");
			// vTmp = getInt("Choose DataSourceType: 1) UniData (Default) 2) UniVerse: ");

			}
			catch (java.io.IOException e) {
				printMsg ("DataBaseType Error !");
			}
			
			if (xTmp.length() == 0) {vTmp = 1;}
			else {vTmp = Integer.parseInt(xTmp);}

			if (vTmp == 2)
				{
				xDataSourceType = "UNIVERSE";
				xServiceName = "uvcs";
				xHostName = "Localhost";
				xAccount = "HS.SALES";
				xFile = "STATES";
				xRecordID = "CO";
				}
			else
				{
				xDataSourceType = "UNIDATA";
				xServiceName = "udcs";
				xHostName = "Localhost";
				xAccount = "demo";
				xFile = "STATES";
				xRecordID = "CO";
				}

			try {
                        uSession.setDataSourceType ( xDataSourceType );
              		}
              		catch (UniConnectionException e) {
                        printMsg ("setDataSourceType to UNIDATA/UNIVERSE failed");
                	}

			try {
			xTmp = inputString("Please input the UniObject Service Name (Default " + xServiceName+ ") : ");
			}
			catch (java.io.IOException e) {
				printMsg ("UniObject Service Name Error !");
			}

			if (xTmp.length() != 0) {xServiceName = xTmp;}

			try {
			xTmp = inputString("Please input the HostName (Default " + xHostName+ ") : ");
			}
			catch (java.io.IOException e) {
				printMsg ("HostName Error !");
			}

			if (xTmp.length() != 0) {xHostName = xTmp;}

			try {
			xUserName = inputString("Please input the UserName: ");
			}
			catch (java.io.IOException e) {
				printMsg ("UserName Error !");
			}

			char pwdx[];
			try {
			// xPassword = getParameter("Password");
			//xPassword = inputString("Please input the Password: ");
			pwdx = PasswordField.getPassword(System.in, "Please input the password: ");
			xPassword = String.valueOf(pwdx);
			}
			catch (java.io.IOException e) {
				printMsg ("Password Error !");
			}

			try {
			printMsg("Default account " + xAccount + " !");
			xTmp = inputString("Please input the Account: ");
			}
			catch (java.io.IOException e) {
				printMsg ("Account Name Error !");
			}

			if (xTmp.length() != 0) {xAccount = xTmp;}
			
                	uSession.setConnectionString( xServiceName );
                	uSession.setHostName( xHostName );
                	uSession.setUserName( xUserName );
                	uSession.setPassword( xPassword );
                	uSession.setAccountPath( xAccount );

			printMsg("Server Name =" + xHostName);
               		uSession.connect();
			
			try {
			printMsg("Default file (" + xFile + ") !");
			xTmp = inputString("Please input the File Name: ");
			}
			catch (java.io.IOException e) {
				printMsg ("File Name Error !");
			}

			if (xTmp.length() != 0) {xFile = xTmp;}

			UniFile uojFile = uSession.open( xFile );
			System.out.println("\nThe " + xFile + " file was opened successfully");

			// Read entire CO record
			try {
			printMsg("Default Record ID (" + xRecordID + ") !");
			xTmp = inputString("Please input the Record ID: ");
			}
			catch (java.io.IOException e) {
				printMsg ("Record ID Error !");
			}
			if (xTmp.length() != 0) {xRecordID = xTmp;}

					
			// Extract record value based on the record ID
			try {
				UniString custRec = uojFile.read(xRecordID);
				UniDynArray custArray = new UniDynArray(custRec);
				System.out.println("custArray Object: " + custArray.toString());
							}
			catch ( UniFileException e) {
				System.out.println("error: " + e);
			}
		

			//catch ( UniStringException e ){
			//	System.out.println("error: "+e+" CODE = "+e.getErrorCode());
			//}

			// close UniSession & UniJava 
			uojFile.close();
			uSession.disconnect();
			uJava.closeSession(uSession);
                        System.out.println("\n\t*--- End of Test ---*\n");
		}
		catch ( UniSessionException e ){
			System.out.println("error: "+e+" CODE = "+e.getErrorCode());
		}
		catch ( UniFileException e) {
			System.out.println("Error CODE = "+e.getErrorCode() + " error: " + e);
		}
}

	/**
         * Utility routine to get an input string.  Prints up the given msg and
         * returns the input string
         *
         * @param msg String representing the message to be displayed
         * @return String representing the data input
         * @exception IOException is thrown if an error occurs
         * @since UNITEST 1.0
         */

        public static String inputStringCheck( String msg ) throws IOException
        {
            printMsg( msg, false );
            byte bArray[] = new byte[ 128 ];
		byte byte1;
            int bytesRead = System.in.read( bArray );
		if (bytesRead > 1) {
			vldlength = 2;
			byte1 = bArray[bytesRead-2];
//			System.out.println("byte1=" + byte1);
			if (byte1 == 13) {
				vldlength = 2;
				}
			else
				{
				vldlength = 1;
				}
			}
		else
			{
			vldlength = 1;
			}
		/* vldlength will be 1 for Unix or 2 for Windows */
            return new String( bArray, 0, bytesRead - vldlength );
        }

        public static String inputString( String msg ) throws IOException
        {
                printMsg( msg, false );
                byte bArray[] = new byte[ 128 ];
                int bytesRead = System.in.read( bArray );
			/* vldlength will be 1 for Unix or 2 for Windows */
                return new String( bArray, 0, bytesRead - vldlength );
        }

        /**
         * Utility routine which prints up the 'Press any key' message
         *
         * @since UNITEST 1.0
         */
        public static void pressAnyKey() throws IOException
        {
                        String dummy = inputString( "Press any key to continue..." );
                        printMsg();
        }

        /**
         * Prints the details of any given UniObjects errors
         *
         * @param e UniException that started it all
         * @since UNITEST 1.0
         */
         public static void printErrorDetails( UniException e )
         {
                        printHeader( "Error!!!!   UniObjects Exception Caught" );
                        printMsg( "Details:" );
                        printMsg( "          ErrorType = " + e.getErrorTypeText() );
                        printMsg( "          ErrorCode = " + e.getErrorCode() );
                        printMsg( "          Message   = " + e.getExtendedMessage() );
         }

        /**
         * Utility routine which prints up a header msg followed by a line of
         * separator characters.
         *
         * @param msg String representing message to be displayed
         * @exception IOException is thrown if an error occurs
         * @since UNITEST 1.0
         */
        public static void printHeader( String msg )
        {
                printMsg();
                printMsg( msg );
                for ( int i = 0; i < msg.length(); i++ )
                        System.out.print("=");
                printMsg();
        }

        /**
         * Prints a blank line
         *
         * @since UNITEST 1.0
         */
        public static void printMsg()
        {
                System.out.println();
        }

        /**
         * Prints the given msg on the display
         *
         * @param msg String representing the message to be displayed
         * @since UNITEST 1.0
         */
        public static void printMsg( String msg )
        {
                System.out.println( msg );
        }

        /**
         * Prints the given msg on the display
         *
         * @param msg String representing the message to be displayed
         * @param newLine boolean representing whether a newline character should
         *                      be put at the end of the display
         * @since UNITEST 1.0
         */
        public static void printMsg( String msg, boolean newLine )
        {
                if ( newLine )
                        printMsg( msg );
                else
                        System.out.print( msg );
        }
        public static UniJava uvJava                            = null;
        public static int     totalErrors                       = 0;
        public static final int FAILURE                         = 1;
        public static final int SUCCESS                         = 0;	
}
