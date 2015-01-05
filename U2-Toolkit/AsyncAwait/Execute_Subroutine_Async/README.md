##Execute Rocket MV U2 Subroutine Asynchronously using C# (async\await) and U2 Toolkit for .NET v2.2.0. Convert Subroutine Multi-Value Output to Json/Objects/DataTable ##

## Overview ##
Asynchronous programming involves executing operations in the background so that the main thread can continue its own operations. This way the main thread can keep the user interface responsive while the background thread is processing the task at hand. .NET framework 4.5 introduced the C# (async/await) and VB.NET (Async\Await) keywords that simplify asynchronous programming. If you pull huge amounts of data from a database synchronously then the entire UI will block and the user is unable to do anything until all database operations finish. But if we do it asynchronously then the user is free to do their work while the data is loading in the background. 

U2 Toolkit for .NET v2.2.0 implements ADO.NET’s asynchronous API such as 

-	ExecuteNonQueryAsync()
-	ExecuteReaderAsync()
-	ExecuteScalarAsync()


These APIs allows you to execute U2 Subroutines and return multi-value data as U2Parameter’s output value. You can also return multi-column multi-rows of data like result set  (DataSet/DataTable) from U2 Subroutines (UniVerse Only).
You can use U2Parameter class to convert multi-value output data to Json or Objects or DataTable.


Asynchronous features can be used in the following applications


-	ASP.NET MVC
-	Web API and oData
-	Node.js\Edge.js (Server Side) and Angular.js (Client Side)
-	WPF, WinForm
-	ASP.NET Web Form
-	Mobile and Cloud Development


This article demonstrate the following walkthroughs

1.	Execute Simple U2 subroutine
2.	Execute U2 Subroutine, return multi-value data as output, convert multi-value data to DataTable
3.	Execute U2 Subroutine, return multi-value data as output, convert multi-value data to Objects
4.	Execute U2 Subroutine, return multi-value data as output, convert multi-value data to Json
5.	Execute U2 Subroutine, return result set (DataSet/DataTable) [UniVerse Only]




 

