public class JDBCdemo {

   /**
    * A sample program to test Rocket UniVerse/UniData JDBC Driver.
    */
   public static void main(String[] argv) {
      try {
         Console console = System.console();

         BufferedReader in = new BufferedReader(new InputStreamReader(System.in));

         System.out.println("\n\n\tThis is the JDBC sample program");
         System.out.println("\t ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
         System.out.println("\n\tThis program connects to a U2 account (schema)");
         System.out.println("\tand lists the CUSTOMER file.");

         //---------------------------
         //  Connect to the U2 server
         //---------------------------

         // Obtain path to the server account
         System.out.println("\nEnter destination account name: ");
         String account = in.readLine();

         // Get user name
         System.out.println("Enter valid server User Name: ");
         String userid = in.readLine();

         // Get password
         String password;
         if (console != null) {
            // Read without echoing on the console
            char passwordArray[] = console.readPassword("Enter password for user: ");
            password = new String(passwordArray);
         } else {
            // Read in when no console exists (eg, in IDE)
            // The password will be echoed to the screen
            System.out.println("Enter password for user: ");
            password = in.readLine();
         }

         // Get host machine name
         System.out.println("Enter host machine name (localhost or machine name): ");
         String host = in.readLine();

         // Get database type
         System.out.println("Enter database type(UNIVERSE/UNIDATA): ");
         String dbtype = in.readLine();

         // generate URL
         String url = "jdbc:ibm-u2://" + host + "/" + account + "?dbmstype=" + dbtype + ";tracelevel=5;tracefile=jdbc.trace";

         //Load driver and connect to server
         Class.forName("com.ibm.u2.jdbc.UniJDBCDriver");
         Connection con = DriverManager.getConnection(url, userid, password);

         System.out.println("\n\t*--- Connection successful ---*\n");

         //------------------------
         //  First example
         //------------------------
         System.out.println("1. Select from CUSTOMER ------------------------");
         testQuery(con);

         //------------------------
         // Second example
         //------------------------
         System.out.println("2. Transaction test ----------------------------");
         testRollback(con);

         con.close();
      } catch (SQLException e) {
         System.out.println("Ex-Message :" + e.getMessage());
         System.out.println("Ex-Code    :" + e.getErrorCode());
         System.out.println("Ex-SQLState:" + e.getSQLState());
         System.out.println("Ex-Next    :" + e.getNextException());
         e.printStackTrace();
         System.gc();
      } catch (Exception e) {
         System.out.println("Exception caught:" + e);
         e.printStackTrace();
      }
   }

   /**
    * Select something from CUSTOMER table.
    * @param con The JDBC connection object.
    */
   public static void testQuery(Connection con) throws SQLException {
      Statement stmt = con.createStatement();
      String sql = "select @ID, CITY, STATE, ZIP, PHONE from CUSTOMER";

      // Execute the SELECT statement
      ResultSet rs = stmt.executeQuery(sql);

      // Get result of first five records
      System.out.println("\tlist selected columns for the first five records:");
      int i = 1;
      while (rs.next() && i < 6) {
         System.out.println("\nRecord " + i + " :");
         System.out.println("\t@ID : \t" + rs.getString(1));
         System.out.println("\tCITY :\t" + rs.getString(2));
         System.out.println("\tSTATE :\t" + rs.getString(3));
         System.out.println("\tZIP : \t" + rs.getString(4));
         System.out.println("\tPHONE :\t" + rs.getString(5));
         i++;
      }

      rs.close();
      stmt.close();
      System.out.println("\n\t*--- QUERY test is done successful ---*\n");
   }

   /**
    * Transaction test. It will:
    * (1) begin a transaction
    * (2) update STATE of CUSTOMER to CA
    * (3) re-read that record to show the update
    * (4) roll the transaction back
    * (5) re-read that record to show original value
    * @param con The JDBC connection object.
    */
   static public void testRollback(Connection con) throws SQLException {
      System.out.println("\nThis section will:");
      System.out.println("\t(1) begin a transaction");
      System.out.println("\t(2) update STATE of CUSTOMER to CA");
      System.out.println("\t(3) re-read that record to show the update");
      System.out.println("\t(4) roll the transaction back");
      System.out.println("\t(5) re-read that record to show original value\n");

      // Set isolation level and start a transaction
      con.setTransactionIsolation(java.sql.Connection.TRANSACTION_READ_COMMITTED);
      con.setAutoCommit(false);

      // Update the CUSTOMER file
      String sql = "update CUSTOMER set STATE = 'CA' where @ID = '2';";
      Statement stmt = con.createStatement();

      int rows = stmt.executeUpdate(sql);

      System.out.println(rows + " rows updated.");
      stmt.close();

      //Read the record to show the update
      String lsql = "SELECT STATE FROM CUSTOMER WHERE @ID = ?;";
      PreparedStatement pstmt = con.prepareCall(lsql);

      pstmt.setString(1, "2");
      ResultSet rs = pstmt.executeQuery();

      while (rs.next()) {
         System.out.println("updated STATE is " + rs.getString(1));
      }
      pstmt.close();

      //Rollback the transation
      con.rollback();
      System.out.println("\nTransaction has rollbacked.\n");

      //re-Read the record to show original value
      pstmt = con.prepareCall(lsql);

      pstmt.setString(1, "2");
      rs = pstmt.executeQuery();

      while (rs.next()) {
         System.out.println("original STATE is " + rs.getString(1));
      }
      pstmt.close();

      System.out.println("\n\t*--- Transaction test is done successful ---*\n");
   }
}