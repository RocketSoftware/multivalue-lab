<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN"
"http://www.w3.org/TR/html4/strict.dtd">


<?php
// check the values being passed to the page from the Customer search criteria
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
		// construct the URL for the rest Services Call
        $uri  = "http://LocalHost:8181"; // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices";
        $uri .= "/getCustList";
        $uri .= "?NAMES=".urlencode($custName); //encode to allow for spaces etc.
        $uri .= "&ADDRS=".urlencode($custAddress); // encode to allow for spaces etc.
        $uri .= "&PHONE=".$custPhone;
        $uri .= "&STERR=".$custTerrNo;
        $jsonStr = file_get_contents($uri);  //execute the rest services call
        $jsonArr = json_decode($jsonStr, true); // get the Json results from the call

        $trxMst = $jsonArr["getCustList"]["CUSTLIST"]; //grab the part of the Json structure we need for the HTML table
?>
<html>
		
		<script type="text/javascript" src = "jquery-1.10.2.min.js"></script>
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
			<!-- create the Customer list HTML table headers  -->
		<table id="Cust_Table"  width="1000" border=1>
        <tr><th width=80px>Account#</th>
                <th width=270px>Name</th>
                <th width=250px>Address</th>
                <th width=125px>City</th>
                <th width=50px>State</th>
				<th width=95px>Zip</th>
				<th width=85px>Phone</th>
				<th width=63px>Delete</th>
            
		</tr>
		</div>
<?php
		// ************ loop through the Json Array structure to populate the customer list table *****************
        foreach ($trxMst["foundCustomers"] as $customer) {
                echo "<tr><td id='custID' align='center'>";
                echo "<a href='http://den-l-dg01:81/D3_PHP_Rest"; // replace with your host or leverage a config file or similar approach
                echo "/invoicelist.php?accountNo=";		
                echo $customer["foundAcctNo"]."'>".$customer["foundAcctNo"]."</a></td>"; // ******** build up the URL link to the InvoiceList so when clicked passes the customer's ID ***
                echo "<td align='left'>".$customer["foundName"]."</td>";
                echo "<td align='left'>".$customer["foundAddress"]."</td>";
                echo "<td align='left'>".$customer["foundCity"]."</td>";
				echo "<td align='left'>".$customer["foundState"]."</td>";
				echo "<td align='left'>".$customer["foundZip"]."</td>";
                echo "<td align='left'>".$customer["foundPhone"]."</td>";
				echo "<td><input type= button id= 'DeleteCustItem' value= 'Delete' onClick= 'delRow(this.parentNode.parentNode.rowIndex)'/></td>";	
                echo "</tr>";
        }
?>
</table>

</body>
</html>
