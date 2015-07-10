<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN"
"http://www.w3.org/TR/html4/strict.dtd">

<?php
		//************************************Retrieve data from previous Post request ****************************
        if(isset($_GET["accountNo"])) {
                $accountNo = $_GET["accountNo"];
        }
        elseif(isset($_POST["accountNo"])) {
                $accountNo = $_POST["accountNo"];
        }
        else {
                $accountNo = "";
        }
		// *****************build up URL for Web Services call to retrieve Invoices for the specified Customer selected ******
        $uri  = "http://den-l-dg01:8181"; // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices";
        $uri .= "/getInvoiceList";
        $uri .= "?CUST_ACCT=".$accountNo;
        $jsonStr = file_get_contents($uri);
        $jsonArr = json_decode($jsonStr, true);
        $trxMst = $jsonArr["getInvoiceList"]["INVOICE_LIST"];
		
		#var_dump($trxMst); // great for doing debugging with any type of PHP object *******
?>
 
<html>
        <link href="acme.css" rel="stylesheet" type="text/css" />
        <head><title>Acme Invoice List</title></head>
        <body   marginwidth="0"
                marginheight="0">
        <div id="InvoiceListTopDiv">
        <img align="left"
                src="/img/acme.png"
                border="0">
				<FORM action="index.htm" method="post">
					 <br clear="all">
					 
					 <?php Echo "List of Invoices for: ".$jsonArr["getInvoiceList"]["INVOICE_LIST"]["custName"]; ?> <!-- get Customer with offset into Json structure -->
					<div id="InvoicesActions"><INPUT type="submit" value="New Search"> </div> 
				</FORM>
        </div>
		
		<!-- create HTML Table header for Invoice List -->
		<table id="InvoiceList_Table" width="815" border=1>
			<tr><th width=90px>Invoice#</th>
                <th width=90px>Invoice Date</th>
                <th width=90px>Order Date</th>
                <th width=110px>Terms</th>
                <th width=100px>Gross</th>
                <th width=100px>Discount</th>
                <th width=100px>Net Invoice</th>
				<th width=150px>Comments</th>
			</tr>
<?php
		// *** loop through Json result set and populate the HTML table ***
		
        foreach ($trxMst["invoice"] as $invoice)		{
				echo "<tr><td align='center'>";
                echo "<a href='http://den-l-dg01:81/D3_PHP_Rest"; // replace with your host or leverage a config file or similar approach
                echo "/invoice.php?invoiceNo=";						// ***** build up URL to click to specific Invoice Details *****
                echo $invoice["invoiceNo"]."'>".$invoice["invoiceNo"]."</a></td>";
                echo "<td align='center'>".$invoice["invoiceDate"]."</td>";
                echo "<td align='center'>".$invoice["orderDate"]."</td>";
                echo "<td align='center'>".$invoice["terms"]."</td>";
                echo "<td align='right'>".$invoice["totalGross"]."</td>";
                echo "<td align='right'>".$invoice["totalDiscount"]."</td>";
                echo "<td align='right'>".$invoice["totalNet"]."</td>";
				echo "<td align='center'>".$invoice["InvoiceComments"]."</td>";
                echo "</tr>";
        }
?>
</table>
        </body>
</html>
