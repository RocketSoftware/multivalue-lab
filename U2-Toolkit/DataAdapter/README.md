## U2DataAdapter Class Demos ##
This directory contains sample code to show how to use U2DataAdapter Class to connect to UniVerse or UniData and create DataSet. Later you can see how we can bind DataSet with WinForm’s DataGrid View control.

#Overview#
U2DataAdapter is a part of the U2 Toolkit for .NET (Provider) and it resides in the U2.Data.Client namespace. U2DataAdapter provides the communication between the DataSet and the U2 database. We can use U2DataAdapter Object in combination with DataSet Object.

#Sample Code#
This sample shows how to use U2DataAdapter Class to connect to UniVerse or UniData and create DataSet. Later you can see how we can bind DataSet with WinForm’s DataGrid View control.

#Software Requirement#

- U2 Toolkit for .NET v 1.2.0+
- UniVerse 10.3+
- UniData 7.1+
- Visual Studio 2010/2012

#How to run Sample Project?#
1.	Open “DataAdapter.sln” file using Visual Studio 2010 or 2012
2.	Make sure Project Solution is pointing to right U2.Data.Client.DLL. You can always use Right Click->Add Reference->C:\Program Files (x86)\Rocket Software\U2 Toolkit for .NET\U2 Database Provider\bin\.NETFramework\v4.0\U2.Data.Client.dll
3.	Open App.config file
4.	Change the connection string in App.config file (For Example : user,password, server,database)
5.	Visual Studio ->Build->Build Solution
6.	Run it
7.	Press “Run_UniVerse” button. You will see Fig 1
8.	Press “Run_UniData” button. You will see Fig 2

**Fig 1**
![Fig1 and Fig2](http://sdrv.ms/1bdQe3b)
http://sdrv.ms/1bdQe3b


