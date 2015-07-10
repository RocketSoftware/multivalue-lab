<?php  

$Action = $_POST['Action'];  

if($Action == "Delete")
	{
	$CUSTID = $_POST['CUSTID'];
	// construct the URL for the rest Services Call
        $uri  = "http://localhost:8181"; // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices_Soap";
        $uri .= "/delete_cust_item";
		$uri .= "?CUSTID=".$_POST['CUSTID'];

		$file = file_get_contents($uri);  //execute the rest services call
		$xml = simplexml_load_string($file); // get the xml results
		
		// Do all your error trapping here for the web services soap call and return the results to the ajax javascript page
	}
else if($Action == "WriteItem")
   {
	// construct the URL for the rest Services Call
        $uri  = "http://localhost:8181"; // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices_Soap";
        $uri .= "/writecustitem";
		$uri .= "?CUSTID=".$_POST['CUSTID'];
		$uri .= "&NAME=".urlencode($_POST['NAME']);
		$uri .= "&ADDR=".urlencode($_POST['ADDR']);
		$uri .= "&CITY=".urlencode($_POST['CITY']);
		$uri .= "&STATE=".$_POST['STATE'];
		$uri .= "&ZIP=".$_POST['ZIP'];
		$uri .= "&PHONE=".$_POST['PHONE'];

		$file = file_get_contents($uri);  //execute the rest services call
		$xml = simplexml_load_string($file); // get the xml results
		
		// Do all your error trapping here for the web services soap call and return the results to the ajax javascript page
		 
   }

?>  
