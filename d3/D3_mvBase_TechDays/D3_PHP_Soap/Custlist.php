<?php	
			// retrieve parameters from the CustSearch page ****************
		if(isset($_GET["custName"])) {
                $custName = $_GET["custName"];
        }
        elseif(isset($_POST["custName"])) {
                $custName = $_POST["custName"];
        }
        else {
                $custName = "";
        }
        if(isset($_GET["custAddress"])) {
                $custAddress = $_GET["custAddress"];
        }
        elseif(isset($_POST["custAddress"])) {
                $custAddress = $_POST["custAddress"];
        }
        else {
                $custAddress = "";
        }
        if(isset($_GET["custPhone"])) {
                $custPhone = $_GET["custPhone"];
        }
        elseif(isset($_POST["custPhone"])) {
                $custPhone = $_POST["custPhone"];
        }
        else {
                $custPhone = "";
        }
        if(isset($_GET["custTerrNo"])) {
                $custTerrNo = $_GET["custTerrNo"];
        }
        elseif(isset($_POST["custTerrNo"])) {
                $custTerrNo = $_POST["custTerrNo"];
        }
        else {
                $custTerrNo = "";
        }
		// Build up URI to make Soap Web Service call to get the Customer List
        $uri  = "http://localhost:8181"; // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices_Soap";
        $uri .= "/getCustList";
        $uri .= "?NAMES=".urlencode($custName);
        $uri .= "&ADDRS=".urlencode($custAddress);
        $uri .= "&PHONE=".$custPhone;
        $uri .= "&STERR=".$custTerrNo;
		
		$file = file_get_contents($uri);  // execute web service call ***************
		$xml = simplexml_load_string($file); // XML Result structure into variable
		
		// Do all your error trapping here for the web services soap call
?>
<html>
		<script type="text/javascript" src = "jquery-1.10.2.min.js"></script> <!-- need jquery for ajax type calls from javascript -->
		<script type="text/javascript" src = "custlist.js"></script>
        <link href="acme.css" rel="stylesheet" type="text/css" />
		
        <head><title>Customer Search Results</title></head>
        <body   marginwidth="0"
                marginheight="0">
        <div id="CustTopDiv">
        <img align="left"
                src="/img/acme.png"
                border="0">
				<FORM method="POST" action = "index.htm">					
					<br clear="all">
					<b>Customer Search Results:</b>
					
					<div id ="CustActions">
					<INPUT type="submit" name="submit" value="New Search"> 
					<INPUT id = "btn_addCust" type= button name="Add Customer" onClick= "addRow()" value= "Add Customer"> 
					</div>
					
				</FORM>
		</div>
					
		<div>	
		<!-- create HTML table header for Customer List Table -->
		<table id="Cust_Table"  width="1150" border=1>
        <tr><th width=90px>Account#</th>
                <th width=285px>Name</th>
                <th width=270px>Address</th>
                <th width=225px>City</th>
                <th width=50px>State</th>
				<th width=95px>Zip</th>
				<th width=110px>Phone</th>
				<th width=63px>Delete</th>         
		</tr>
		
		</div>

<?php
	
		// var_dump($xml); good way to see output of various structured variables in PHP
		// Loop through the XML structure ... note the way you offset to the XML element you need to access
		foreach($xml->CUSTLIST->foundCustomers as $Result){

		$AccountNo = $Result->foundAcctNo;
		$Name = $Result->foundName;
		$Address = $Result->foundAddress;
		$City = $Result->foundCity;
		$State = $Result->foundState;
		$Zip= $Result->foundZip; 
		$Phone = $Result->FoundPhone; 
		
		
				echo "<tr><td align='center'>";
                echo "<a href='http://localhost:81/D3_PHP_Soap"; // replace with your host or leverage a config file or similar approach
                echo "/invoicelist.php?accountNo=";
                echo $AccountNo."'>".$AccountNo."</a></td>";
                echo "<td align='left'>".$Name."</td>";
                echo "<td align='left'>".$Address."</td>";
                echo "<td align='left'>".$City."</td>";
                echo "<td align='left'>".$State."</td>";
				echo "<td align='left'>".$Zip."</td>";
				echo "<td align='left'>".$Phone."</td>";
				echo "<td><input type= button id= 'DeleteCustItem' value= 'Delete' onClick= 'delRow(this.parentNode.parentNode.rowIndex)'/></td>";	
                echo "</tr>";
		
			}
		
?>
</table>
</body>
</html>