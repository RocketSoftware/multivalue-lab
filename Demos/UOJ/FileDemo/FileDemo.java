package FileDemo;

import asjava.uniclientlibs.UniConnectionException;
import asjava.uniclientlibs.UniDynArray;
import asjava.uniclientlibs.UniString;
import asjava.uniclientlibs.UniTokens;
import asjava.uniobjects.*;
import java.applet.Applet;
import java.awt.*;
import java.awt.event.*;

/**
 * <code>FileDemo</code> is a class constructed to display the usage of some of
 * the features provided by UniObjects.
 * We use the following UniObject classes:
 * <code>UniSession, UniFile, UniSelectList, UniCommand, UniSubroutine,
 * UniDynArray, UniString</code>
 */
public class FileDemo extends Applet {
   // Declare and initialize variables and user interface components.
   public boolean isApplet = true; // Used for applet conditional code
   public Color buttonColor = new Color(0, 191, 255); // Deep Sky Blue
   public Color textColor = new Color(85, 26, 139); // Purple
   private int lineCount = 0; // Used for TextArea output
   public boolean cancelConnect = false; // Used for LogonDialog feedback
   public TextArea taScreen;
   private Button bConnect, bCreateFile, bLoadFile, bListFile, bCreateSelectList,
           bShowSelectList, bExecuteCommand, bExecuteSubroutine, bExitDemo,
           bDisconnect;
   public UniSession session; // U2 session
   public UniSelectList demoSelect; // The select list for our demo file
   public Frame myFrame = null; // Pointer to our current Frame
   public String userName, password, server, accountPath; // User parameters
   public String DBtype;

   /**
    * The main entry point if this class is launched as an application.
    */
   @SuppressWarnings("ResultOfObjectAllocationIgnored")
   public static void main(String[] args) {
      new FileDemoFrame(new FileDemo(), 760, 600);
   }

   /**
    * Initializes FileDemo.
    */
   @Override
   public void init() {
      // read relevant parameters from user environment
      // in this case we are considering the user environment, which is all the parameters that
      // are set in the applet tag in your HTML file.
      if (isApplet) {
         userName = getParameter("username");
         password = getParameter("password");
         server = getParameter("server");
         accountPath = getParameter("account");
         DBtype = "UNIVERSE";
      } else {
         userName = "";
         password = "";
         server = "";
         accountPath = "";
         DBtype = "UNIVERSE";
      }

      setLayout(new BorderLayout());
      // Add all components to applet
      Panel p = new Panel();
      // Only include an exit demo button if we are launching this program as an application.
      if (isApplet) {
         p.setLayout(new GridLayout(9, 1));
      } else {
         p.setLayout(new GridLayout(10, 1));
      }
      bConnect = new Button("Connect to U2");
      bConnect.setForeground(textColor);
      bConnect.setBackground(buttonColor);
      bCreateFile = new Button("Create File");
      bCreateFile.setForeground(textColor);
      bCreateFile.setBackground(buttonColor);
      bLoadFile = new Button("Load File");
      bLoadFile.setForeground(textColor);
      bLoadFile.setBackground(buttonColor);
      bListFile = new Button("List File");
      bListFile.setForeground(textColor);
      bListFile.setBackground(buttonColor);
      bCreateSelectList = new Button("Create Select List");
      bCreateSelectList.setForeground(textColor);
      bCreateSelectList.setBackground(buttonColor);
      bShowSelectList = new Button("Show Select List");
      bShowSelectList.setForeground(textColor);
      bShowSelectList.setBackground(buttonColor);
      bExecuteCommand = new Button("Execute Command");
      bExecuteCommand.setForeground(textColor);
      bExecuteCommand.setBackground(buttonColor);
      bExecuteSubroutine = new Button("Execute Subroutine");
      bExecuteSubroutine.setForeground(textColor);
      bExecuteSubroutine.setBackground(buttonColor);
      bDisconnect = new Button("Disconnect");
      bDisconnect.setForeground(textColor);
      bDisconnect.setBackground(buttonColor);
      
      // Only build an exit demo button if we are launching this program as an application.
      if (!isApplet) {
         bExitDemo = new Button("Exit Demo");
         bExitDemo.setForeground(textColor);
         bExitDemo.setBackground(buttonColor);
      }
      
      // add the buttons into the panel
      p.add(bConnect);
      p.add(bCreateFile);
      p.add(bLoadFile);
      p.add(bCreateSelectList);
      p.add(bShowSelectList);
      p.add(bListFile);
      p.add(bExecuteCommand);
      p.add(bExecuteSubroutine);
      p.add(bDisconnect);
      
      // Only include an exit demo button if we are launching this program as an application.
      if (!isApplet) {
         p.add(bExitDemo);
      }
      
      add("West", p);
      taScreen = new TextArea();
      taScreen.setForeground(textColor);
      add("Center", taScreen);
      
      // Add Listeners for all buttons
      bConnect.addActionListener(new ConnectListener(this));
      bCreateFile.addActionListener(new CreateFileListener(this));
      bLoadFile.addActionListener(new LoadFileListener(this));
      bCreateSelectList.addActionListener(new CreateSelectListListener(this));
      bShowSelectList.addActionListener(new ShowSelectListListener(this));
      bListFile.addActionListener(new ListFileListener(this));
      bExecuteCommand.addActionListener(new ExecuteCommandListener(this));
      bExecuteSubroutine.addActionListener(new ExecuteSubroutineListener(this));
      bDisconnect.addActionListener(new DisconnectListener(this));
      
      // Only include an exit demo action listener if we are launching this
      // program as an application.
      if (!isApplet) {
         bExitDemo.addActionListener(new ExitDemoListener(this));
      }
      this.resize(600, 400); // This only works if we are an application
   }

   /**
    * Start FileDemo.
    */
   @Override
   public void start() {
      // Get a frame pointer to use for spawning the logon dialog.
      myFrame = getFrame(this);
   }

   /**
    * Stop FileDemo.
    */
   @Override
   public void stop() {
      appOutput("Disconnecting from the U2 Server.\n");
      if (session != null) {
         try {
            appOutput("   UniSession.disconnect()\n");
            session.disconnect();
         } catch (UniSessionException e) {
            appOutput("   ERROR:UniSessonException:" + e.getMessage() + "\n");
         }
      }
   }

   /**
    * Retrieve our parent Frame. If we are an applet we need this code to get a
    * parent window handle to launch a login dialog box with.
    */
   static Frame getFrame(Component component) {
      Frame frame = null;
      while ((component = component.getParent()) != null) {
         if (component instanceof Frame) {
            frame = (Frame) component;
         }
      }
      return frame;
   }

   /**
    * Control the output of data to the screen.
    */
   public void appOutput(String output) {
      // This is required because the peer for the text area control on most
      // platforms has a limited amount of text it can display at one time.
      // So, we control that here.
      if (lineCount < 250) {
         // Append this string to our TextArea
         taScreen.append(output);
         lineCount++;
      } else {
         // We have reached our maximum text threshold for the TextArea.
         // So, we remove half the text and keep going until we reach the
         // threshold again .
         String tmp = taScreen.getText();
         int length = tmp.length();
         taScreen.setText(tmp.substring(length / 2));
         taScreen.append(output);
         lineCount = 126;
      }
   }
}

/**
 * The parent Frame if we launched FileDemo as an application. Essentially this
 * frame runs the applet in exactly the same way as a web browser would.
 */
class FileDemoFrame extends Frame {
   FileDemo applet = null;

   FileDemoFrame(FileDemo childApplet, int x, int y) {
      applet = childApplet;
      setTitle("Rocket Java Demo");
      setSize(x, y);
      add("Center", applet);
      applet.isApplet = false;
      applet.init();
      setVisible(true);
      applet.start();

      // This listener detects all application exit signals
      addWindowListener(new WindowAdapter() {

         @Override
         public void windowClosing(WindowEvent event) {
            applet.stop();
            applet.destroy();
            dispose();
            System.exit(0);
         }
      });
   }
}

/**
 * The dialog to accept the logon information for U2. The defaults can be
 * specified as parameters if FileDemo is launched as an applet.
 *
 * @version	Version 1.0
 * @author	Rocket
 * @since	1.0
 */
class LogonDialog extends Dialog {
   // Graphical elements for this dialog

   private Label lUserName, lPassword, lServer, lAccountPath, lblDStype;
   private TextField tUserName, tPassword, tServer, tAccount;
   private Button bOK, bCancel;
   private Color labelColor = new Color(139, 0, 0); // Dark Red
   private FileDemo parentApplet; // Reference to our parent
   private boolean uvOn;
   private boolean udOn;

   // Construct frame
   LogonDialog(Frame f, FileDemo Github) {
      this(f, Github, "U2 Logon");
   }
   
   // Construct frame with a title
   LogonDialog(Frame f, FileDemo Github, String title) {
      super(f, title, true);
      parentApplet = Github;

      // Initialize the layout manager
      GridBagLayout gbl = new GridBagLayout();
      setLayout(gbl);
      GridBagConstraints gbc1 = new GridBagConstraints();
      GridBagConstraints gbc2 = new GridBagConstraints();
      gbc1.weighty = 1.0;
      gbc2.weighty = 1.0;
      gbc1.anchor = GridBagConstraints.EAST;
      gbc2.anchor = GridBagConstraints.WEST;
      gbc2.gridwidth = GridBagConstraints.REMAINDER;

      // Create the user text boxes
      tUserName = new TextField(parentApplet.userName, 20);
      tUserName.setForeground(parentApplet.textColor);
      tPassword = new TextField(parentApplet.password, 20);
      tPassword.setForeground(parentApplet.textColor);
      tPassword.setEchoChar('*');
      tServer = new TextField(parentApplet.server, 20);
      tServer.setForeground(parentApplet.textColor);
      tAccount = new TextField(parentApplet.accountPath, 20);
      tAccount.setForeground(parentApplet.textColor);

      // Create the buttons
      bOK = new Button("OK");
      bOK.setForeground(parentApplet.textColor);
      bOK.setBackground(parentApplet.buttonColor);
      bCancel = new Button("Cancel");
      bCancel.setForeground(parentApplet.textColor);
      bCancel.setBackground(parentApplet.buttonColor);

      // Add all the components to the container
      add(gbl, gbc1, lUserName = new Label("UserName:"));
      lUserName.setForeground(labelColor);
      add(gbl, gbc2, tUserName);
      add(gbl, gbc1, lPassword = new Label("Password:"));
      lPassword.setForeground(labelColor);
      add(gbl, gbc2, tPassword);
      add(gbl, gbc1, lServer = new Label("Server:"));
      lServer.setForeground(labelColor);
      add(gbl, gbc2, tServer);
      add(gbl, gbc1, lAccountPath = new Label("Account Path:"));
      lAccountPath.setForeground(labelColor);
      add(gbl, gbc2, tAccount);

      /**
       * Create the checkboxes ("radio buttons") to select between
       * UniVerse and UniData, then add them to the dialog
       */
      CheckboxGroup checkbox_group = new CheckboxGroup();
      Checkbox[] checkboxes = new Checkbox[2];
      uvOn = false;
      udOn = false;
      if (parentApplet.DBtype.equals("UNIVERSE")) {
         uvOn = true;
      }
      if (parentApplet.DBtype.equals("UNIDATA")) {
         udOn = true;
      }
      checkboxes[0] = new Checkbox("UniVerse", checkbox_group, uvOn);
      checkboxes[1] = new Checkbox("UniData", checkbox_group, udOn);
      lblDStype = new Label("Data Source Type:");
      lblDStype.setForeground(labelColor);
      add(gbl, gbc1, lblDStype);
      add(gbl, gbc1, checkboxes[0]);
      add(gbl, gbc2, checkboxes[1]);
      ItemListener checkbox_listener = new ItemListener() {

         @Override
         public void itemStateChanged(ItemEvent e) {
            parentApplet.DBtype =
                    ((Checkbox) e.getItemSelectable()).getLabel();
         }
      };
      checkboxes[0].addItemListener(checkbox_listener);
      checkboxes[1].addItemListener(checkbox_listener);

      // Add OK and Cancel buttons
      add(gbl, gbc1, bOK);
      add(gbl, gbc2, bCancel);

      // Add action listeners for buttons and window closes
      bOK.addActionListener(new ActionListener() {

         @Override
         public void actionPerformed(ActionEvent event) {
            // Pass the entered parameters to the parent applet
            parentApplet.userName = tUserName.getText();
            parentApplet.password = tPassword.getText();
            parentApplet.server = tServer.getText();
            parentApplet.accountPath = tAccount.getText();
            parentApplet.cancelConnect = false;
            setVisible(false);
            dispose();
         }
      });
      bCancel.addActionListener(new ActionListener() {

         @Override
         public void actionPerformed(ActionEvent event) {
            // Cancel connect operation
            parentApplet.cancelConnect = true;
            setVisible(false);
            dispose();
         }
      });
      
      addWindowListener(new WindowAdapter() {
         @Override
         public void windowClosing(WindowEvent event) {
            setVisible(false);
            dispose();
         }
      });

      Point scrnLoc = parentApplet.myFrame.getLocationOnScreen();
      setLocation(scrnLoc.x + 150, scrnLoc.y + 100);

      setSize(300, 200);
      setVisible(true);
      
      // For some reason requestFocus and transferFocus are not working
      bOK.requestFocus();
      bOK.transferFocus();
   }

   // Macro for adding components
   private void add(GridBagLayout gb, GridBagConstraints c, Component o) {
      gb.setConstraints(o, c);
      add(o);
   }
}

/**
 * Connect to U2 ActionListener. Opens a connection to U2.
 */
class ConnectListener implements ActionListener {
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   ConnectListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the Connect button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      parentApplet.appOutput("Connecting to U2 Server.\n");
      LogonDialog logonDialog = new LogonDialog(parentApplet.myFrame, parentApplet);

      // Only connect if "OK" was pressed in logon dialog.
      if (!parentApplet.cancelConnect) {
         try {
            // Create a new UniSession object
            parentApplet.session = new UniSession();
            
            // Set the connect parameters to the session object
            parentApplet.session.setUserName(parentApplet.userName);
            parentApplet.session.setPassword(parentApplet.password);
            parentApplet.session.setHostName(parentApplet.server);
            parentApplet.session.setAccountPath(parentApplet.accountPath);
            parentApplet.session.setDataSourceType(parentApplet.DBtype);
            parentApplet.appOutput("   UniSession.connect() -- Hostname=" + parentApplet.session.getHostName()
                    + "=UserName=" + parentApplet.session.getUserName()
                    + "=AccountPath=" + parentApplet.session.getAccountPath() + "=\n");
            // Try to connect this session
            parentApplet.session.connect();

            int osType;
            String dbType;

            dbType = parentApplet.session.getDataSourceType();
            osType = parentApplet.session.getHostType();

            parentApplet.appOutput("   *** Server OS is ");
            switch (osType) {
               case UniTokens.UVT_NONE:
                  parentApplet.appOutput("None");
                  break;
               case UniTokens.UVT_UNIX:
                  parentApplet.appOutput("Unix");
                  break;
               case UniTokens.UVT_NT:
                  parentApplet.appOutput("Windows");
                  break;
               default:
                  parentApplet.appOutput("Unknown");
                  break;
            }
            parentApplet.appOutput(" ***\n");
            parentApplet.appOutput("   *** Server DB is "
                    + dbType + " ***\n");

            if (dbType.equals("UNIDATA")) {
               UniFile f = parentApplet.session.open("BP");
               String subr = "SUBROUTINE MYTIME(TIME) TIME= OCONV(DATE(),\"DM\") : @AM : OCONV(DATE(),\"DD\") : @AM :";
               subr = subr + " OCONV(DATE(),\"D4Y\") : @AM : OCONV(TIME(),\"MTSS\") : @AM";
               f.write("MYTIME", subr);
               UniCommand cmd = parentApplet.session.command("BASIC BP MYTIME");
               cmd.exec();
               cmd.setCommand("CATALOG BP MYTIME FORCE");
               cmd.exec();
               parentApplet.appOutput(cmd.response());
            }

         } catch (UniSessionException e) {
            parentApplet.appOutput("   ERROR:UniSessionException:" + e.getMessage() + "\n");
         } catch (UniConnectionException e) {
            parentApplet.appOutput("   ERROR:UniConnectionException:" + e.getMessage() + "\n");
         } catch (UniFileException e) {
            parentApplet.appOutput("   ERROR:UniFileException:" + e.getMessage() + "\n");
         } catch (UniCommandException e) {
            parentApplet.appOutput("   ERROR:UniCommandException:" + e.getMessage() + "\n");
         }
         // Check to see if our session connect succeded
         if (parentApplet.session.isActive()) {
            parentApplet.appOutput("Connection Successfully established.\n");
         } else {
            parentApplet.appOutput("Connection Failed!\n");
         }
      }
   }
}

/**
 * Create a file ActionListener. Creates a U2 file in the current account.
 */
class CreateFileListener implements ActionListener {
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   CreateFileListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the Create File button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      UniFile demoFile;
      UniCommand command;
      parentApplet.appOutput("Create File started.\n");
      try {
         String cmdString;
         String dbType = parentApplet.session.getDataSourceType();

         // Check if JAVA_DEMO exists, if so, then delete
         try {
            demoFile = parentApplet.session.open("JAVA_DEMO");
            demoFile.close();
            parentApplet.appOutput("   Removing existing JAVA_DEMO file.\n");
            command = parentApplet.session.command();
            if (dbType.equals("UNIVERSE")) {
               command.setCommand("DELETE.FILE JAVA_DEMO");
            } else {
               command.setCommand("DELETE.FILE JAVA_DEMO FORCE");
            }
            command.exec();
            parentApplet.appOutput(command.response());
         } catch (UniSessionException e) {
            // This exception means that the file doesn't exist so we can go ahead and create it.
         } catch (UniFileException e) {
            parentApplet.appOutput("   ERROR:UniFileException:" + e.getMessage() + "\n");
         }

         parentApplet.appOutput("   UniCommand = UniSesson.command()\n");
         
         // Create a U2 command object
         command = parentApplet.session.command();
         if (dbType.equals("UNIVERSE")) {
            cmdString = "CREATE.FILE JAVA_DEMO 25"
                    + " Java Demo File";
            parentApplet.appOutput("   UniCommand.setCommand"
                    + "(" + cmdString + ")\n");
            command.setCommand(cmdString);
         } else {
            cmdString = "CREATE.FILE JAVA_DEMO 1";
            parentApplet.appOutput("   UniCommand.setCommand"
                    + "(" + cmdString + ")\n");
            command.setCommand(cmdString);
         }
         
         // Execute our create file command
         parentApplet.appOutput("   UniCommand.exec()\n");
         command.exec();
         
         // Print out the results from the execute command
         parentApplet.appOutput("   UniCommand.response() = ");
         parentApplet.appOutput(command.response());
         parentApplet.appOutput("   UniCommand.status() = " + command.status() + "\n");
         parentApplet.appOutput("   UniCommand.getSystemReturnCode() = " + command.getSystemReturnCode() + "\n");
      } catch (UniSessionException e) {
         parentApplet.appOutput("   ERROR:UniSessonException:" + e.getMessage() + "\n");
      } catch (UniCommandException e) {
         parentApplet.appOutput("   ERROR:UniCommandException:" + e.getMessage() + "\n");
      }
      parentApplet.appOutput("Create File completed.\n");
   }
}

/**
 * Load a file ActionListener. Loads our demo U2 file from the current account.
 */
class LoadFileListener implements ActionListener {
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   LoadFileListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the Load File button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      UniFile demoFile;
      String data = null;
      char chr;
      parentApplet.appOutput("Load File started.\n");
      try {
         parentApplet.appOutput("   UniFile = UniSession.open(JAVA_DEMO)\n");
         
         // Create a new file object
         demoFile = parentApplet.session.open("JAVA_DEMO");
         
         // If the session object supports encryption, then lets turn encryption
         // on for this file.
         if (parentApplet.session.isEncryptionEnabled()) {
            demoFile.setEncryptionType(1);
         }
         chr = 'a';
         parentApplet.appOutput("   UniFile.write(Record ID, Record Data) 200 times!\n");
         
         // Now lets fill the file with meaningless data
         for (int count = 0; count < 200; count++) {
            data = data + chr;
            demoFile.write(Integer.valueOf(count), data);
            chr++;
         }
         
         // Close the file we opened
         parentApplet.appOutput("   UniFile.close()\n");
         demoFile.close();
      } catch (UniSessionException e) {
         parentApplet.appOutput("   ERROR:UniSessonException:" + e.getMessage() + ":" + e.getExtendedMessage() + "\n");
      } catch (UniFileException e) {
         parentApplet.appOutput("   ERROR:UniFileException:" + e.getMessage() + "\n");
      }
      parentApplet.appOutput("Load File completed.\n");
   }
}

/**
 * Create a select list ActionListener. Creates a select list of our demo file
 * in the current account.
 */
class CreateSelectListListener implements ActionListener {
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   CreateSelectListListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the Create Select List button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      UniFile demoFile;
      parentApplet.appOutput("Create Select List started.\n");
      try {
         // Create a new file object
         parentApplet.appOutput("   UniSession.open('JAVA_DEMO')\n");
         demoFile = parentApplet.session.open("JAVA_DEMO");
         
         // If we have an existing select list then lets empty it
         if (parentApplet.demoSelect != null) {
            parentApplet.appOutput("   UniSession.clearList()\n");
            parentApplet.demoSelect.clearList();
         }
         parentApplet.appOutput("   UniSession.selectList(1)\n");
         
         // Create a new select list
         parentApplet.demoSelect = parentApplet.session.selectList(1);
         parentApplet.appOutput("   UniSelectList.select(UniFile)\n");
         
         // Generate a select list of the file we opened earlier
         parentApplet.demoSelect.select(demoFile);
         parentApplet.appOutput("   UniSelectList.saveList(JAVA_DEMO_LIST)\n");
         
         // Save the list we generated to a file
         parentApplet.demoSelect.saveList("JAVA_DEMO_LIST");
         parentApplet.appOutput("   UniFile.close()\n");
         
         // Close the file object now that we are done with it
         demoFile.close();
      } catch (UniSessionException e) {
         parentApplet.appOutput("   ERROR:UniSessonException:" + e.getMessage() + "\n");
      } catch (UniFileException e) {
         parentApplet.appOutput("   ERROR:UniFileException:" + e.getMessage() + "\n");
      } catch (UniSelectListException e) {
         parentApplet.appOutput("   ERROR:UniSelectListException:" + e.getMessage() + "\n");
      }
      parentApplet.appOutput("Create Select List completed.\n");
   }
}

/**
 * Show a select list ActionListener. Reads and displays the select list of our
 * demo file in the current account if one has been created.
 */
class ShowSelectListListener implements ActionListener {
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   ShowSelectListListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the Show Select List button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      parentApplet.appOutput("Show Select List started.\n");
      try {
         // Check to see if we have created a select list during the life of this applet
         if (parentApplet.demoSelect != null) {
            parentApplet.appOutput("   UniSelectList.getList(JAVA_DEMO_LIST)\n");
            // load the select list we previously generated
            parentApplet.demoSelect.getList("JAVA_DEMO_LIST");
            parentApplet.appOutput("   UniSelectList.readList()\n");
            // read the list into a string and then output it
            UniString result = parentApplet.demoSelect.readList();
            parentApplet.appOutput("   " + result.toString() + "\n");
            UniDynArray dynResult = new UniDynArray(result);
            parentApplet.appOutput("   The English version!\n");
            // output the select list in a formatted form
            for (int i = 0; i < dynResult.count(); i++) {
               parentApplet.appOutput("    " + dynResult.extract(i).toString() + ",");
               if (((i + 1) % 10) == 0) {
                  parentApplet.appOutput("\n");
               }
            }
            parentApplet.appOutput("\n");
         } else {
            parentApplet.appOutput(
                    "   If you want to look at the select list, then you must first create one!\n");
         }
      } catch (UniSelectListException e) {
         parentApplet.appOutput("   ERROR:UniSelectListException:" + e.getMessage() + "\n");
      }
      parentApplet.appOutput("Show Select List completed.\n");
   }
}

/**
 * List the file we created ActionListener. Reads and displays the contents of
 * our demo file in the current account.
 */
class ListFileListener implements ActionListener {
   
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   ListFileListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the List File button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      UniFile demoFile;
      parentApplet.appOutput("List File started.\n");
      try {
         if (parentApplet.demoSelect == null) {
            parentApplet.appOutput("   If you want to run this command you must first press the Create Select List button.\n");
         } else {
            // we previously generated a select list so now lets use it
            parentApplet.appOutput("   UniSelectList.getList(JAVA_DEMO_LIST)\n");
            // load the select list we previously generated
            parentApplet.demoSelect.getList("JAVA_DEMO_LIST");
            parentApplet.appOutput("   UniSession.open('JAVA_DEMO')\n");
            // Create a new file object
            demoFile = parentApplet.session.open("JAVA_DEMO");

            parentApplet.appOutput("   UniSelectList.next()\n");
            parentApplet.appOutput("   UniFile.read(Record ID)\n");
            // list the entire contents of the file
            // read first recordID
            UniString recordID = parentApplet.demoSelect.next();
            while (!parentApplet.demoSelect.isLastRecordRead()) {
               UniString record = demoFile.read(recordID);
               parentApplet.appOutput(demoFile.getRecordID() + "\t" + demoFile.getRecord() + "\n");
               // read next record ID
               recordID = parentApplet.demoSelect.next();
            }
            // Close the file we opened
            demoFile.close();
            parentApplet.appOutput("   UniFile.close()\n");
         }
      } catch (UniSessionException e) {
         parentApplet.appOutput("   ERROR:UniSessonException:" + e.getMessage() + "\n");
      } catch (UniFileException e) {
         parentApplet.appOutput("   ERROR:UniFileException:" + e.getExtendedMessage() + "\n");
      } catch (UniSelectListException e) {
         parentApplet.appOutput("   ERROR:UniSelectListException:" + e.getMessage() + "\n");
      }
      parentApplet.appOutput("List File completed.\n");
   }
}

/**
 * Execute a command ActionListener. Executes a U2 command in the current
 * account and displays the output of that command.
 */
class ExecuteCommandListener implements ActionListener {
   
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   ExecuteCommandListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the Execute Command button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      UniCommand command;
      parentApplet.appOutput("Execute Command started.\n");
      try {
         // Create a command object
         command = parentApplet.session.command();
         parentApplet.appOutput("   UniCommand.setCommand(LIST VOC SAMPLE 10)\n");
         // Set the TCL text of the command you wish to execute
         command.setCommand("LIST VOC SAMPLE 10");
         parentApplet.appOutput("   UniCommand.exec()\n");
         // Execute your command
         command.exec();
         parentApplet.appOutput("   UniCommand.response() = ");
         // Display the results of the command
         parentApplet.appOutput(command.response());
         parentApplet.appOutput("   UniCommand.status() = " + command.status() + "\n");
         parentApplet.appOutput("   UniCommand.getSystemReturnCode() = " + command.getSystemReturnCode() + "\n");
      } catch (UniSessionException e) {
         parentApplet.appOutput("   ERROR:UniSessonException:" + e.getMessage() + "\n");
      } catch (UniCommandException e) {
         parentApplet.appOutput("   ERROR:UniCommandException:" + e.getMessage() + "\n");
      }
      parentApplet.appOutput("Execute Command completed.\n");
   }
}

/**
 * Execute a subroutine ActionListener. Executes a U2 Basic subroutine in the
 * current account and displays the output of that command.
 */
class ExecuteSubroutineListener implements ActionListener {
   
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   ExecuteSubroutineListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the Execute Subroutine button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      UniSubroutine subroutine;
      parentApplet.appOutput("Execute Subroutine started.\n");
      try {
         String dbType = parentApplet.session.getDataSourceType();

         // Create a subroutine object
         if (dbType.equals("UNIVERSE")) {
            parentApplet.appOutput("   UniSubroutine = UniSesson.subroutine(!TIMDAT, 1)\n");
            subroutine = parentApplet.session.subroutine("!TIMDAT", 1);
         } else {
            parentApplet.appOutput("   UniSubroutine = UniSesson.subroutine(MYTIME, 1)\n");
            subroutine = parentApplet.session.subroutine("MYTIME", 1);
         }
         parentApplet.appOutput("   UniSubroutine.call()\n");

         // Execute the specified subroutine
         subroutine.call();
         String outputStr = subroutine.getArg(0);
         UniDynArray outputDyn = subroutine.getArgDynArray(0);

         parentApplet.appOutput("   UniSubroutine.getArg(0) = " + outputStr + "\n");
         // Display the results of the subroutine
         parentApplet.appOutput("   The English version of the subroutine return argument!\n");
         if (dbType.equals("UNIVERSE")) {
            parentApplet.appOutput("   Month=" + outputDyn.extract(0) + "\n");
            parentApplet.appOutput("   Day of Month=" + outputDyn.extract(1) + "\n");
            parentApplet.appOutput("   Year=" + outputDyn.extract(2) + "\n");
            parentApplet.appOutput("   Minutes since midnight=" + outputDyn.extract(3) + "\n");
            parentApplet.appOutput("   Seconds into the minute=" + outputDyn.extract(4) + "\n");
            parentApplet.appOutput("   Ticks of last second since midnight=" + outputDyn.extract(5) + "\n");
            parentApplet.appOutput("   CPU second used since entering UniVerse=" + outputDyn.extract(6) + "\n");
            parentApplet.appOutput("   Ticks of last second used since login=" + outputDyn.extract(7) + "\n");
            parentApplet.appOutput("   Disk I/O seconds used since entering UniVerse=" + outputDyn.extract(8) + "\n");
            parentApplet.appOutput("   Ticks of last disk I/O second used since login=" + outputDyn.extract(9) + "\n");
            parentApplet.appOutput("   Number of ticks per second=" + outputDyn.extract(10) + "\n");
            parentApplet.appOutput("   User number=" + outputDyn.extract(11) + "\n");
            parentApplet.appOutput("   Login ID=" + outputDyn.extract(12) + "\n");
         } else {
            String time[] = outputDyn.extract(4).toString().split(":");
            parentApplet.appOutput("   Month=" + outputDyn.extract(1) + "\n");
            parentApplet.appOutput("   Day of Month=" + outputDyn.extract(2) + "\n");
            parentApplet.appOutput("   Year=" + outputDyn.extract(3) + "\n");
            parentApplet.appOutput("   Hours=" + time[0] + "\n");
            parentApplet.appOutput("   Minutes=" + time[1] + "\n");
            parentApplet.appOutput("   Seconds=" + time[2] + "\n");
         }

      } catch (UniSessionException e) {
         parentApplet.appOutput("   ERROR:UniSessonException:" + e.getMessage() + "\n");
      } catch (UniSubroutineException e) {
         parentApplet.appOutput("   ERROR:UniSubroutineException:" + e.getMessage() + "\n");
      }

      parentApplet.appOutput("Execute Subroutine completed.\n");
   }
}

/**
 * Disconnect the U2 connection ActionListener. Disconnect our current U2
 * connection.
 */
class DisconnectListener implements ActionListener {
   
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   DisconnectListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the Disconnect button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      parentApplet.appOutput("Disconnecting from the U2 Server.\n");
      // Check to make sure we originally established a session
      if (parentApplet.session != null) {
         try {
            parentApplet.appOutput("   UniSession.disconnect()\n");
            // Disconnect from the server
            parentApplet.session.disconnect();
            parentApplet.demoSelect = null;
         } catch (UniSessionException e) {
            parentApplet.appOutput("   ERROR:UniSessonException:" + e.getMessage() + "\n");
         }
      }
      parentApplet.appOutput("Connection Successfully terminated.\n");
   }
}

/**
 * Exit our FileDemo application ActionListener. Exit out of our FileDemo
 * application. This ActionListener is only used when FileDemo is launched as an
 * application. If it is launched as an applet, then the "Exit Demo" button is
 * not displayed.
 */
class ExitDemoListener implements ActionListener {
   
   // Handle to the base applet
   private FileDemo parentApplet;

   // Constructor that requires a handle to the base applet
   ExitDemoListener(FileDemo handle) {
      parentApplet = handle;
   }

   // This method is executed whenever the Exit Demo button is pressed.
   @Override
   public void actionPerformed(ActionEvent event) {
      parentApplet.appOutput("Exiting Demo Applet.\n");
      // Check to make sure we originally established a session
      if (parentApplet.session != null) {
         try {
            // Disconnect from the server
            parentApplet.session.disconnect();
            parentApplet.demoSelect = null;
         } catch (UniSessionException e) {
            parentApplet.appOutput("   ERROR:UniSessonException:" + e.getMessage() + "\n");
         }
      }
      System.exit(0);
   }
}
