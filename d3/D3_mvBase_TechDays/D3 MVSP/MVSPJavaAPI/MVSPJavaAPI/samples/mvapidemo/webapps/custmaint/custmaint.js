function GetCustomers()
{
	document.getElementById("status").innerHTML="";
	if (window.XMLHttpRequest)
	{	// code for IE7+, Firefox, Chrome, Opera, Safari
  		xmlhttp=new XMLHttpRequest();
	}
	else
	{	// code for IE6, IE5
		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
	}
	xmlhttp.onreadystatechange=function()
	{
/* this handler is only used for async requests
		if (xmlhttp.readyState==4 && xmlhttp.status==200)
		{
			document.getElementById("CustomerList").innerHTML=xmlhttp.responseText;
		}
*/
	}

  	var servlet = "custmaint?"
	 + "user=" + document.getElementById("user").value 
	 + "&pwd=" + document.getElementById("pwd").value 
	 + "&hostname=" + document.getElementById("hostname").value 
	 + "&port=" + document.getElementById("port").value
	 + "&function=1";
	xmlhttp.open("POST", servlet, false);
	xmlhttp.send();
	document.getElementById("CustomerList").innerHTML=xmlhttp.responseText;
	var control = document.getElementById("btnConnect");
	if (control != null) 
	{
		control.style.display = "none";
	}


	var firstId = document.getElementById("Row0").innerHTML;
	GetCustomer(firstId);
}

function GetCustomer(CustomerId)
{
	document.getElementById("status").innerHTML="";
	if (window.XMLHttpRequest)
	{	// code for IE7+, Firefox, Chrome, Opera, Safari
  		xmlhttp=new XMLHttpRequest();
	}
	else
	{	// code for IE6, IE5
		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
	}
	xmlhttp.onreadystatechange=function()
	{
		if (xmlhttp.readyState==4 && xmlhttp.status==200)
		{
			document.getElementById("CustomerInfo").innerHTML=xmlhttp.responseText;
		}
	}
  	var servlet = "custmaint?"
	 + "user=" + document.getElementById("user").value 
	 + "&pwd=" + document.getElementById("pwd").value 
	 + "&hostname=" + document.getElementById("hostname").value 
	 + "&port=" + document.getElementById("port").value 
	 + "&id=" + CustomerId
	 + "&function=2";
	xmlhttp.open("POST", servlet, true);
	xmlhttp.send();
	var control = document.getElementById("btnOrders");
	if (control != null) 
	{
		control.style.display = "inline";
	}

	var control = document.getElementById("btnExecute");
	if (control != null) 
	{
		control.style.display = "inline";
	}

	var control = document.getElementById("btnNew");
	if (control != null) 
	{
		control.style.display = "inline";
	}

	var control = document.getElementById("btnSave");
	if (control != null) 
	{
		control.style.display = "inline";
	}
}

function TCL()
{
	document.getElementById("status").innerHTML="";
	var CustomerId = document.getElementById("CustomerID_input").value;
	var url = window.location.protocol + "//" + window.location.host + "/" + "custmaint/TCL.html?"
	 + "user=" + document.getElementById("user").value 
	 + "&pwd=" + document.getElementById("pwd").value 
	 + "&hostname=" + document.getElementById("hostname").value 
	 + "&port=" + document.getElementById("port").value;
	window.open(url, "TCL","width=800,height=300,scrollbars=yes,resizable=yes");	
}

function Execute()
{
	document.getElementById("status").innerHTML="<p><font color=red>Executing...</font>";
	if (window.XMLHttpRequest)
	{	// code for IE7+, Firefox, Chrome, Opera, Safari
  		xmlhttp=new XMLHttpRequest();
	}
	else
	{	// code for IE6, IE5
		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
	}
	xmlhttp.onreadystatechange=function()
	{
		if (xmlhttp.readyState==4 && xmlhttp.status==200)
		{
			document.getElementById("status").innerHTML="";
			document.getElementById("TCLResults").innerHTML=xmlhttp.responseText;
		}
	}

	var urlparams = window.location.href.split("?");
	var parameters = urlparams[1];
	servlet = "custmaint?" + parameters + "&cmd=" + document.getElementById("txtTCL").value
	+ "&function=4";

	xmlhttp.open("POST", servlet, true);
	xmlhttp.send();

}

function GetOrders()
{
	document.getElementById("status").innerHTML="";
	var CustomerId = document.getElementById("CustomerID_input").value;
	var url = window.location.protocol + "//" + window.location.host + "/" + "custmaint/";
  	var servlet = "custmaint?"
	 + "user=" + document.getElementById("user").value 
	 + "&pwd=" + document.getElementById("pwd").value 
	 + "&hostname=" + document.getElementById("hostname").value 
	 + "&port=" + document.getElementById("port").value 
	 + "&id=" + CustomerId
	 + "&function=3";
	var ordersURL = url + servlet;
	window.open(ordersURL, "Orders","width=800,height=300,scrollbars=yes");	
}

function New()
{
	document.getElementById("status").innerHTML="";
	document.getElementById("CustomerID_input").value = ""
	document.getElementById("ContactName_input").value = "";
	document.getElementById("ContactTitle_input").value = "";
	document.getElementById("OrganizationName_input").value = "";
	document.getElementById("Address_input").value = "";
	document.getElementById("City_input").value = "";
	document.getElementById("State_input").value = "";
	document.getElementById("PostalCode_input").value = "";
	document.getElementById("PhoneNumber_input").value = "";
	document.getElementById("FaxNumber_input").value = "";
	document.getElementById("Note_input").value = "";
}

function Save()
{
	document.getElementById("status").innerHTML="";

	var CustomerId = document.getElementById("CustomerID_input").value;
	if (CustomerId == null || CustomerId == "")
	{
		alert("Please enter a customer Id");
	}
	else
	{

		if (window.XMLHttpRequest)
		{	// code for IE7+, Firefox, Chrome, Opera, Safari
  			xmlhttp=new XMLHttpRequest();
		}
		else
		{	// code for IE6, IE5
			xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
		}
		xmlhttp.onreadystatechange=function()
		{

			if (xmlhttp.readyState==4 && xmlhttp.status==200)
			{
				document.getElementById("status").innerHTML=xmlhttp.responseText;
			}	

		}

	  	var servlet = "custmaint?"
		 + "user=" + document.getElementById("user").value 
		 + "&pwd=" + document.getElementById("pwd").value 
		 + "&hostname=" + document.getElementById("hostname").value 
		 + "&port=" + document.getElementById("port").value 
		 + "&id=" + CustomerId
	         + "&ContactName_input=" + document.getElementById("ContactName_input").value
	         + "&ContactTitle_input=" + document.getElementById("ContactTitle_input").value
	         + "&OrganizationName_input=" + document.getElementById("OrganizationName_input").value
	         + "&Address_input=" + document.getElementById("Address_input").value 
	         + "&City_input=" + document.getElementById("City_input").value
	         + "&State_input=" + document.getElementById("State_input").value
	         + "&PostalCode_input=" + document.getElementById("PostalCode_input").value
	         + "&PhoneNumber_input=" + document.getElementById("PhoneNumber_input").value
	         + "&FaxNumber_input=" + document.getElementById("FaxNumber_input").value
		 + "&Note_input=" + document.getElementById("Note_input").value
		 + "&function=5";
		xmlhttp.open("POST", servlet, true);
		xmlhttp.send();
	}
}
