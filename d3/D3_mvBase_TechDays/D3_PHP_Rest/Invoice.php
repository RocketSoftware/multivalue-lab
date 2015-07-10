<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN"
"http://www.w3.org/TR/html4/strict.dtd">

<?php
		// ****************************** retrieve from previous page a action's link arguments
        if(isset($_GET["invoiceNo"])) {
                $invoiceNo = $_GET["invoiceNo"];
        }
        elseif(isset($_POST["invoiceNo"])) {
                $invoiceNo = $_POST["invoiceNo"];
        }
        else {
                $invoiceNo = "";
        }
		//***** build up URI for calling Web Service to get specific invoice *****
        $uri  = "http://den-l-dg01:8181"; // replace with your host or leverage a config file or similar approach
        $uri .= "/Invoices";
        $uri .= "/getInvoice";
        $uri .= "?INVOICE_NO=".$invoiceNo;
        $jsonStr = file_get_contents($uri);
        $jsonArr = json_decode($jsonStr, true);
        $trxMst = $jsonArr["getInvoice"]["INVOICE_ITEM"]; // offset to get to the data structure in the Jason results *****
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
 
<table width=810px border=1>
        <tr><td valign="top"><table width=450px border=0>
<?php
		// ************************* create table and populate with the single valued attributes from the Jason Structure******
        echo "<tr><td width=80px>Bill to:</td>";
                echo "<td>";
                echo $trxMst['billtoCompanyName'];
                echo "</td></tr>";
        echo "<tr><td></td>";
                echo "<td>";
                echo $trxMst['billtoAddress'];
                echo "</td></tr>";
        echo "<tr><td></td>";
                echo "<td>";
                echo $trxMst['billtoCity'].", ";
                echo $trxMst['billtoState']." ";
                echo $trxMst['billtoZip'];
                echo "</td></tr>";
        echo "<tr><td>Ship to:</td>";
                echo "<td>";
                echo $trxMst['shiptoName'];
                echo "</td></tr>";
        echo "<tr><td></td>";
                echo "<td>";
                echo $trxMst['shiptoAddress'];
                echo "</td></tr>";
        echo "<tr><td></td>";
                echo "<td>";
                echo $trxMst['shiptoCity'].", ";
                echo $trxMst['shiptoState']." ";
                echo $trxMst['shiptoZip'];
                echo "</td></tr>";
        echo "<tr><td>Contact:</td>";
                echo "<td>";
                echo $trxMst['billtoContactName'];
                echo "</td></tr>";
        echo "<tr><td>Sales Rep:</td>";
                echo "<td>";
                echo $trxMst['salesRepName'];
                echo "</td></tr>";
        echo "<tr><td>Rep Phone:</td>";
                echo "<td>";
                echo $trxMst['salesRepPhone'];
                echo "</td></tr>";
?>
        </table></td>
        <td valign="top"><table width=350px border=0>
<?php
		// ************************* create second table and populate with the single valued attributes from the Jason Structure******
        echo "<tr><td width=80px>Invoice#:</td>";
                echo "<td width=240px>";
                echo $trxMst['invoiceNo'];
                echo "</td></tr>";
        echo "<tr><td>Account#:</td>";
                echo " <td>";
                echo $trxMst['custAccount'];
                echo "</td></tr>";
        echo "<tr><td>Ordered:</td>";
                echo " <td>";
                echo $trxMst['orderDate'];
                echo "</td></tr>";
        echo "<tr><td>Invoiced:</td>";
                echo " <td>";
                echo $trxMst['invoiceDate'];
                echo "</td></tr>";
        echo "<tr><td>Terms:</td>";
                echo " <td>";
                echo $trxMst['terms'];
                echo "</td></tr>";
        echo "<tr><td>Note:</td>";
                echo " <td>";
                echo $trxMst['comment'];
                echo "</td></tr>";
        echo "<tr><td>Gross:</td>";
                echo " <td>";
                echo $trxMst['invoiceGross'];
                echo "</td></tr>";
        echo "<tr><td>Discount:</td>";
                echo " <td>";
                echo $trxMst['invoiceDiscount'];
                echo "</td></tr>";
        echo "<tr><td>Net:</td>";
                echo " <td>";
                echo $trxMst['invoiceNet'];
                echo "</td></tr>";
?>
        </table></td></tr>
</table>
<br>

<!-- Create HTML table headers for invoice item list table -->

<table  width="750" border=1>
        <tr><th width=50px>Ln</th>
                <th width=50px>Qty</th>
                <th width=50px>Item#</th>
                <th width=350px>Description</th>
                <th width=75px>Unit Price</th>
                <th width=75px>Ext Price</th>
                <th width=50px>Disc</th>
                <th width=50px>Ext</th>
        </tr>
<?php
		// *****************  Loop through json array for each item in the invoice ***************
        $lineNo = 0;
        foreach ($trxMst["line"] as $line) {
                echo "<tr><td align='center'>".++$lineNo."</td>";
                echo "<td align='center'>".$line["lineQty"]."</td>";
                echo "<td align='center'>".$line["lineProductNo"]."</td>";
                echo "<td align='left'>".$line["lineDescription"]."</td>";
                echo "<td align='right'>".$line["lineUnitPrice"]."</td>";
                echo "<td align='right'>".$line["lineGross"]."</td>";
                echo "<td align='right'>".$line["lineDiscount" ]."</td>";
                echo "<td align='right'>".$line["lineExtNet"]."</td>";
                echo "</tr>";
        }
?>
</table>
        </body>
</html>
