<?php
        // Retrieve parameters passed from the previous page url arguments
		if(isset($_GET["invoiceNo"])) {
                $invoiceNo = $_GET["invoiceNo"];
        }
        elseif(isset($_POST["invoiceNo"])) {
                $invoiceNo = $_POST["invoiceNo"];
        }
        else {
                $invoiceNo = "";
        }
		// build URI and execute Soap Based Web Service call to get specific Customer invoice selected
        $uri  = "http://localhost:8181"; // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices_Soap";
        $uri .= "/getInvoice";
        $uri .= "?INVOICE_NO=".$invoiceNo;
		
        $file = file_get_contents($uri);
		$xml = simplexml_load_string($file);
		
		//print_r($xml); // good way to interrogate the returned XML structure
?>
 
<html>
        <link href="acme.css" rel="stylesheet" type="text/css" />
        <head><title>Acme Invoice</title></head>
        <body   marginwidth="0"
                marginheight="0">
        <div id="InvoiceTopDiv">
        <img align="left"
                src="/img/acme.png"
                border="0">
				<FORM action="index.htm" method="post">
				<br clear="all">	
					<div id="InvoiceActions"><INPUT type="submit" value="New Search"> </div>
				</FORM>
        </div>
		<!-- walk the XML structure to get specific single elements and populate table -->
		
<table width=810px border=1>
        <tr><td valign="top"><table width=450px border=0>
<?php
        echo "<tr><td width=80px>Bill to:</td>";
                echo "<td>";
                echo $xml->INVOICE_ITEM->billtoCompanyName;
                echo "</td></tr>";
        echo "<tr><td></td>";
                echo "<td>";
                echo $xml->INVOICE_ITEM->billtoAddress;
                echo "</td></tr>";
        echo "<tr><td></td>";
                echo "<td>";
                echo $xml->INVOICE_ITEM->billtoCity.", ";
                echo $xml->INVOICE_ITEM->billtoState." ";
                echo $xml->INVOICE_ITEM->billtoZip;
                echo "</td></tr>";
        echo "<tr><td>Ship to:</td>";
                echo "<td>";
                echo $xml->INVOICE_ITEM->shiptoName;
                echo "</td></tr>";
        echo "<tr><td></td>";
                echo "<td>";
                echo $xml->INVOICE_ITEM->shiptoAddress;
                echo "</td></tr>";
        echo "<tr><td></td>";
                echo "<td>";
                echo $xml->INVOICE_ITEM->shiptoCity.", ";
                echo $xml->INVOICE_ITEM->shiptoState." ";
                echo $xml->INVOICE_ITEM->shiptoZip;
                echo "</td></tr>";
        echo "<tr><td>Contact:</td>";
                echo "<td>";
                echo $xml->INVOICE_ITEM->billtoContactName;
                echo "</td></tr>";
        echo "<tr><td>Sales Rep:</td>";
                echo "<td>";
                echo $xml->INVOICE_ITEM->salesRepName;
                echo "</td></tr>";
        echo "<tr><td>Rep Phone:</td>";
                echo "<td>";
                echo $xml->INVOICE_ITEM->salesRepPhone;
                echo "</td></tr>";
?>
        </table></td>
        <td valign="top"><table width=400px border=0>
<?php
		//walk the XML structure to get specific single elements and populate second table
        echo "<tr><td width=80px>Invoice#:</td>";
                echo "<td width=240px>";
                echo $xml->INVOICE_ITEM->invoiceNo;
                echo "</td></tr>";
        echo "<tr><td>Account#:</td>";
                echo " <td>";
                echo $xml->INVOICE_ITEM->custAccount;
                echo "</td></tr>";
        echo "<tr><td>Ordered:</td>";
                echo " <td>";
                echo $xml->INVOICE_ITEM->orderDate;
                echo "</td></tr>";
        echo "<tr><td>Invoiced:</td>";
                echo " <td>";
                echo $xml->INVOICE_ITEM->invoiceDate;
                echo "</td></tr>";
        echo "<tr><td>Terms:</td>";
                echo " <td>";
                echo $xml->INVOICE_ITEM->terms;
                echo "</td></tr>";
        echo "<tr><td>Note:</td>";
                echo " <td>";
                echo $xml->INVOICE_ITEM->comment;
                echo "</td></tr>";
        echo "<tr><td>Gross:</td>";
                echo " <td>";
                echo $xml->INVOICE_ITEM->invoiceGross;
                echo "</td></tr>";
        echo "<tr><td>Discount:</td>";
                echo " <td>";
                echo $xml->INVOICE_ITEM->invoiceDiscount;
                echo "</td></tr>";
        echo "<tr><td>Net:</td>";
                echo " <td>";
                echo $xml->INVOICE_ITEM->invoiceNet;
                echo "</td></tr>";
?>
        </table></td></tr>
</table>
<br>
<!-- create HTML Table Header for Items in Invoice -->
<table  width="815" border=1>
        <tr><th width=50px>Ln</th>
                <th width=50px>Qty</th>
                <th width=50px>Item#</th>
                <th width=300px>Description</th>
                <th width=75px>Unit Price</th>
                <th width=75px>Ext Price</th>
                <th width=50px>Disc</th>
                <th width=50px>Ext</th>
        </tr>
<?php
		// ********** loop through the XML structure for each line item and  populate the table
        $lineNo = 0;
        foreach ($xml->INVOICE_ITEM->line as $line) {
                echo "<tr><td align='center'>".++$lineNo."</td>";
                echo "<td align='center'>".$line->lineQty."</td>";
                echo "<td align='center'>".$line->lineProductNo."</td>";
                echo "<td align='left'>".$line->lineDescription."</td>";
                echo "<td align='right'>".$line->lineUnitPrice."</td>";
                echo "<td align='right'>".$line->lineGross."</td>";
                echo "<td align='right'>".$line->lineDiscount."</td>";
                echo "<td align='right'>".$line->lineExtNet."</td>";
                echo "</tr>";
        }
?>
</table>
        </body>
</html>
