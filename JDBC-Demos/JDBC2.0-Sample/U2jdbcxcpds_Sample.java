/******************************************************************
 * Title: u2jdbcxcpds.java 
 *
 * Description: This Program shows how to register a Pooled
 * 				UniJDBCDataSource and how to use this DataSource
 * 				to establish Pooled JDBC connection
 *
 *****************************************************************/
import java.sql.*;
import javax.sql.*;
import java.io.*;
import javax.naming.*;
import com.rs.u2.jdbcx.*;

public class U2jdbcxcpds_Sample {

	public static String xDataSourceType = "UNIVERSE";
	public static String xServiceName;
	public static String xHostName;
	public static String xUserName;
	public static String xPassword;
	public static String xAccount;
	public static String xSQL;

	public static String xdsname;
	public static String xpathname;
	public static String xTmp;
	public static int vTmp = 2;
	public static int vldlength = 2;
	public static String xdata = "";

	public static void main(String[] args) {

		if (args.length == 0) {
			xdsname = "DS_pool";
			xpathname = "c:\\temp";
			System.out.println(">>>Register DataSource " + xdsname + " in "
					+ xpathname);
		} else {
			if (args.length != 2) {
				System.out
						.println("Usage: RegisterCPDS <name of Datasource> <Name Registry location>");
				return;
			}
			xdsname = args[0];
			xpathname = args[1];
			System.out.println(">>>Register DataSource " + args[0] + " in "
					+ args[1]);
		}

		try {
			xTmp = inputStringCheck("Choose DataSourceType: 1) UniData 2) UniVerse (Default) : ");
		} catch (java.io.IOException e) {
			printMsg("DataBaseType Error !");
		}

		if (xTmp.length() == 0) {
			vTmp = 2;
		} else {
			vTmp = Integer.parseInt(xTmp);
		}

		if (vTmp == 2) {
			xDataSourceType = "UNIVERSE";
			xHostName = "Localhost";
			xAccount = "HS.SALES";
			xUserName = "ysheng";
			xSQL = "SELECT CODE, NAME FROM STATES;";
		} else {
			xDataSourceType = "UNIDATA";
			xHostName = "Localhost";
			xAccount = "demo";
			xUserName = "ysheng";
			xSQL = "SELECT ID, NAME FROM STATES;";
		}
		try {
			xTmp = inputString("Do you want to register a data source name: 1) Yes 2) No (Default) : ");
		} catch (java.io.IOException e) {
			printMsg("Register Error !");
		}
		if (xTmp.length() == 0) {
			vTmp = 2;
		} else {
			vTmp = Integer.parseInt(xTmp);
		}

		if (vTmp == 1) {
			try {
				System.setProperty(Context.INITIAL_CONTEXT_FACTORY,
						"com.sun.jndi.fscontext.RefFSContextFactory");
				System.setProperty(Context.PROVIDER_URL, "file:" + xpathname);

				registerDS(xdsname, new InitialContext());
			} catch (Exception e) {
				System.out.println("Problem with registration");
				e.printStackTrace();
				return;
			}
			System.out.println(">>>Done Register for " + xDataSourceType);
		}

		String testName = "Use JDBC Connection Pool Data Source to create connection object";
		Connection connection = null;
		try {
			System.out.println("");
			
			// Retrieve the Registered DataSource
			DataSource ds = lookupDS(xdsname, xpathname);

			// Initiate Pool JDBC Connection via DataSource obj
			connection = (Connection) ds.getConnection();

			System.out.println("Connection1 is:" + connection);

			Statement stmt1 = connection.createStatement();
			stmt1.execute(xSQL);
			ResultSet rs1 = stmt1.getResultSet();
			
			// Get result of first five records
			System.out.println(xDataSourceType + " SQL result:");
			System.out
					.println("List selected columns for the first five records:");
			int i = 1;
			while (rs1.next() && i <= 5) {
				System.out.println("\nRecord " + i + " :");
				System.out.println("\tCODE : \t" + rs1.getString(1));
				System.out.println("\tFNAME :\t" + rs1.getString(2));
				i++;
			}
			rs1.close();
			stmt1.close();
			connection.close();

			try {
				xdata = inputString("Please enter to close the program!");
			} catch (java.io.IOException e) {
				System.out.print("Error");
			}

			System.out.println(">>>End of " + testName);
			System.exit(0);
		} catch (Exception e) {
			System.out.println("Exception caught " + e.toString());
			e.printStackTrace();
		} finally {
			try {
				if (connection != null)
					connection.close();
			} catch (Exception e) {
				System.out.println("Exception caught " + e.toString());
				System.exit(0);
			}
		}

		System.out.println(">>>End of " + testName);
	}

	static void registerDS(String DSname, Context registry) {
		try // First findout if the datasource has a connection pooling
		{
			UniJDBCConnectionPoolDataSource cpds = new UniJDBCConnectionPoolDataSource();

			try {
				xTmp = inputString("Please input the HostName (Default "
						+ xHostName + ") : ");
			} catch (java.io.IOException e) {
				printMsg("HostName Error !");
			}

			if (xTmp.length() != 0) {
				xHostName = xTmp;
			}

			try {
				xTmp = inputString("Please input the UserName (Default "
						+ xUserName + ") : ");
			} catch (java.io.IOException e) {
				printMsg("UserName Error !");
			}
			if (xTmp.length() != 0) {
				xUserName = xTmp;
			}

			try {
				xPassword = inputString("Please input the Password: ");
			} catch (java.io.IOException e) {
				printMsg("Password Error !");
			}

			cpds.addProp("HOST", xHostName);
			cpds.addProp("ACCOUNT", xAccount);
			cpds.addProp("DBMSTYPE", xDataSourceType);
			cpds.addProp("USER", xUserName);
			cpds.addProp("PASSWORD", xPassword);

			cpds.setUniJDBCCPMMaxConnections(-1);
			cpds.setUniJDBCCPMInitPoolSize(3);
			cpds.setUniJDBCCPMMinPoolSize(2);
			cpds.setUniJDBCCPMMaxPoolSize(5);
			cpds.setUniJDBCCPMServiceInterval(100);
			cpds.setUniJDBCCPMAgeLimit(7200);
			cpds.setUniJDBCCPMMinAgeLimit(3600);

			registry.rebind("myCPDS", cpds);

			// User Need to Use UniJDBCDataSource obj for Initiating
			// Pooled JDBC Connection
			UniJDBCDataSource ds = new UniJDBCDataSource();
			ds.setDataSourceName("myCPDS");
			registry.rebind(DSname, ds);
		} catch (Exception e) {
			System.out.println("Problem with registering the DataSource");
			e.printStackTrace();
			return;
		}
	}

	static DataSource lookupDS(String DSName, String nameRegistry)
			throws Exception {
		Context initCtx;
		try {
			System.setProperty(Context.INITIAL_CONTEXT_FACTORY,
					"com.sun.jndi.fscontext.RefFSContextFactory");
			System.setProperty(Context.PROVIDER_URL, "file:" + nameRegistry);
			initCtx = new InitialContext();
			DataSource ds = (DataSource) initCtx.lookup(DSName);
			return ds;
		} catch (Exception e) {
			System.out.println("Problem looking up datasource, " + DSName
					+ " in " + nameRegistry);
			throw e;
		}
	}

	public static String inputStringCheck(String msg) throws IOException {
		printMsg(msg, false);
		byte bArray[] = new byte[128];
		byte byte1;
		int bytesRead = System.in.read(bArray);
		if (bytesRead > 1) {
			vldlength = 2;
			byte1 = bArray[bytesRead - 2];
			if (byte1 == 13) {
				vldlength = 2;
			} else {
				vldlength = 1;
			}
		} else {
			vldlength = 1;
		}
		/* vldlength will be 1 for Unix or 2 for Windows */
		return new String(bArray, 0, bytesRead - vldlength);
	}

	public static String inputString(String msg) throws IOException {
		printMsg(msg, false);
		byte bArray[] = new byte[128];
		int bytesRead = System.in.read(bArray);
		return new String(bArray, 0, bytesRead - vldlength);
	}

	public static void pressAnyKey() throws IOException {
		String dummy = inputString("Press any key to continue...");
		printMsg();
	}

	public static void printMsg() {
		System.out.println();
	}

	public static void printMsg(String msg) {
		System.out.println(msg);
	}

	public static void printMsg(String msg, boolean newLine) {
		if (newLine)
			printMsg(msg);
		else
			System.out.print(msg);
	}

}