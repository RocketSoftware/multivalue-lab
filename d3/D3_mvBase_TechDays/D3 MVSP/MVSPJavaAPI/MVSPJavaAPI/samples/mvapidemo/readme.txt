
Information about running the demo applications:
================================================

To run the Java demo applications you will need to install java JDK 1.5 or higher and be sure to
point the JAVA_HOME environment variable to the JDK install folder

for example:
set JAVA_HOME=C:\Program Files\Java\jdk1.5.0_22


To run the Web based customer maintenance demo:

1. Install Apache Software Tomcat server version 6 or higher.
2. Copy the webapps\custmaint folder to Tomcat server's webapps folder.
3. Restart Tomcat service.
4. Access the application using a web browser with the URL containing the server name and
   application name, for example:

	http://localhost/custmaint/custmaint.html

Note: if Tomcat is not running on default HTTP port 80, the port number must be included in the URL
      for example:
	
	http://localhost:8080/custmaint/custmaint.html

---------------------------------------------------------------------------------------------------------------