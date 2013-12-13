## .NET Samples ##
This directory contains U2 Toolkit for .NET's sample code in C# and VB.NET (32-bit and 64-bit).

#Overview#
The goal of these samples code (C#\VB.NET) is to provide data access techniques using ADO.NET, Entity Framework and Native UniObjects. It also demonstrate how to use the following server side functionality in  .NET such as

- ADE (Automatic Data Encryption)
- SSL (Secure Socket Layer)
- Connection Pooling 
- Calling UniVerse\UniData Subroutines



#Software Requirement#

- U2 Toolkit for .NET v 1.2.0+
- UniVerse 10.3+
- UniData 7.1+
- Visual Studio 2010/2012/2013

#How to run Sample Project?#
1.	Open “???.sln” file using Visual Studio 2010 or 2012 or 2013
2.	Make sure Project Solution is pointing to right U2.Data.Client.DLL. You can always use Right Click->Add Reference->C:\Program Files (x86)\Rocket Software\U2 Toolkit for .NET\U2 Database Provider\bin\.NETFramework\v4.0\U2.Data.Client.dll
3.	Open App.config file
4.	Change the connection string in App.config file (For Example : user,password, server,database)
5.	Visual Studio ->Build->Build Solution
6.	Run it
