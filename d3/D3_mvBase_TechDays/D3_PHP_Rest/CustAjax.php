<?php  

$Action = $_POST['Action'];  

if($Action == "Delete")
	{
	$CUSTID = $_POST['CUSTID'];
												// construct the URL for the rest Services Call
        $uri  = "http://den-l-dg01:8181";       // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices";
        $uri .= "/delete_cust_item";
		$uri .= "?CUSTID=".$_POST['CUSTID'];

        $jsonStr = file_get_contents($uri);  	//execute the rest services call
        $jsonArr = json_decode($jsonStr, true); // get the Json results from the call

} 
else if($Action == "WriteItem")
{
	// construct the URL for the rest Services Call
        $uri  = "http://den-l-dg01:8181";   // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices";
        $uri .= "/writecustitem";
		$uri .= "?CUSTID=".$_POST['CUSTID'];
		$uri .= "&NAME=".urlencode($_POST['NAME']);  // encode in case of spaces
		$uri .= "&ADDR=".urlencode($_POST['ADDR']);  // encode in case of scpaces etc
		$uri .= "&CITY=".urlencode($_POST['CITY']);  // encode in case of spaces etc
		$uri .= "&STATE=".$_POST['STATE'];
		$uri .= "&ZIP=".$_POST['ZIP'];
		$uri .= "&PHONE=".$_POST['PHONE'];

		$jsonStr = file_get_contents($uri);  	//execute the rest services call
        $jsonArr = json_decode($jsonStr, true); // get the Json results from the call
}
?>  
