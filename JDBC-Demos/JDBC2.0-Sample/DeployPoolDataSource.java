/************************************************************************
* Title: DeployPoolDataSource.java 
*
* Description: This Program registers a given Pool Connection DataSource
*                      with the given JNDI Name registry
*
* An example of running this program:
*
* java DeployPoolDataSource CPDS c:\temp or java DeployPoolDataSource 
*
*************************************************************************/

import javax.naming.*;

public class DeployPoolDataSource {

	public static void main(String[] args) {
		String cpdsname;
		String pathname;
		
		if (args.length == 0)
		{
			cpdsname = "CPDS";
			pathname = "c:\\temp";
		}
		else
		{
	        if (args.length != 2)
		  {
		    System.out.println(
		      "Usage: RegisterCPDS <name of Datasource> <Name Registry location>");
		    return;
		  }
		  cpdsname = args[0];
		  pathname = args[1];
		}
		
		System.out.println(">>>Register DataSource " + cpdsname + " in " + pathname);
		
		try {
			System.setProperty(Context.INITIAL_CONTEXT_FACTORY,
					"com.sun.jndi.fscontext.RefFSContextFactory");
			System.setProperty(Context.PROVIDER_URL, "file:" + pathname);
			registerDataSource(cpdsname, new InitialContext());
		} catch (Exception e) {
			System.out.println("Problem with registration");
			e.printStackTrace();
			return;
		}
		
		System.out.println(">>>Done Register");
	}
	
	private static void registerDataSource(String DSName, Context ctx)
	{
		// Create a UniJDBCConnectionPoolDataSource Object cpds and Set Its Properties
		com.rs.u2.jdbcx.UniJDBCConnectionPoolDataSource cpds = new com.rs.u2.jdbcx.UniJDBCConnectionPoolDataSource();
		cpds.setServerHost("localhost");
		cpds.setAccount("HS.SALES");
		cpds.setUser("username");
		cpds.setPassword("password");
		cpds.setUniJDBCCPMMaxConnections(-1);
		cpds.setUniJDBCCPMInitPoolSize(0);
		cpds.setUniJDBCCPMMinPoolSize(2);
		cpds.setUniJDBCCPMMaxPoolSize(8);
		cpds.setUniJDBCCPMServiceInterval(100);
		cpds.setUniJDBCCPMMinAgeLimit(7200);
		cpds.setUniJDBCCPMMinAgeLimit(3600);
		
		// Register UniJDBCConnectionPoolDataSource Object with Naming Service That Uses JNDI API
		try {
			ctx.bind("myCPDS", cpds);
		} catch (Exception e) {
			System.out.println("Problem with registering the ConnectionPoolDataSource");
			e.printStackTrace();
		}
		
		// Register UniJDBCDataSource Object
		// User Should be Referencing this DataSource Object to Initiate Pooled JDBC Connection
		try {
			// Initiatiate a UniJDBCDataSource
			com.rs.u2.jdbcx.UniJDBCDataSource ds = new com.rs.u2.jdbcx.UniJDBCDataSource();
			ds.setDataSourceName("myCPDS");
			ctx.bind(DSName, ds);
		} catch (Exception e) {
			System.out.println("Problem with registering the DataSource");
		}
	}

}
