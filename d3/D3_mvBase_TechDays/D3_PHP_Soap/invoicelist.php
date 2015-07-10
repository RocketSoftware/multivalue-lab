<?php
		// Retrieve parameters from previous page passed via link
        if(isset($_GET["accountNo"])) {
                $accountNo = $_GET["accountNo"];
        }
        elseif(isset($_POST["accountNo"])) {
                $accountNo = $_POST["accountNo"];
        }
        else {
                $accountNo = "";
        }
		
		// Create URI for Soap Web Service call to get customer Invoices **************
        $uri  = "http://localhost:8181"; // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices_Soap";
        $uri .= "/getInvoiceList";
        $uri .= "?CUST_ACCT=".$accountNo;
		
		
		$file = file_get_contents($uri);  // call web service
		$xml = simplexml_load_string($file); // assign XML return structure into variable
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
					 <?php Echo "List of Invoices for: ".$xml->INVOICE_LIST->custName;?>
					<div id="InvoicesActions"><INPUT type="submit" value="New Search"> </div>
				</FORM>
        </div>
		
		<!-- Create HTML Table Headers for Invoice List -->
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
		// loop through the XML structure for each invoice and add to table
        foreach ($xml->INVOICE_LIST->invoice as $invoice)
		{
				
				echo "<tr><td align='center'>";
                echo "<a href='http://localhost:81/D3_PHP_Soap"; // replace with your host or leverage a config file or similar approach
                echo "/invoice.php?invoiceNo=";
                echo $invoice->InvoiceNo."'>".$invoice->InvoiceNo."</a></td>";
                echo "<td align='center'>".$invoice->invoiceDate."</td>";
                echo "<td align='center'>".$invoice->orderDate."</td>";
                echo "<td align='center'>".$invoice->terms."</td>";
                echo "<td align='right'>".$invoice->totalGross."</td>";
                echo "<td align='right'>".$invoice->totalDiscount."</td>";
                echo "<td align='right'>".$invoice->totalNet."</td>";
				echo "<td align='center'>".$invoice->InvoiceComments."</td>";
                echo "</tr>";
        }
?>
</table>
        </body>
</html>
