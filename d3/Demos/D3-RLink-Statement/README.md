D3 R/LINK Basic Demos - Statement
=================================

Example of a D3 FlashBASIC application that generates an HP PCL statement within D3, converts the PCL to a PDF, base-64 encodes the PDF and posts the PDF to R/Link.

<dl>

<dt>EXAMPLE-RLINK.STATEMENT.PDF</dt>
<dd>A D3 FlashBASIC program that generates a PCL5-encoded string using fake customer data, calls a Windows process to convert the PCL to a PDF, base-64 endodes the PDF and posts it to R/Link as HTTP POST content.</dd>

<dt>STATEMENT.IMAGE.SUB.SUB</dt>
<dd>Called by EXAMPLE-RLINK.STATEMENT.PDF. Accepts customer data and generates random aging data to create a PCL5-encoded string for output to an HP PCL5 printer or file.</dd>

<dt>HTTP.POST.SUB</dt>
<dd>Called by EXAMPLE-RLINK.STATEMENT.PDF. Uses D3's built-in FlashBASIC socket functions to send data as HTTP POST content to a server and retrieve the status response.</dd>

<dt>BASE.64.ENCODE.HEX.SUB</dt>
<dd>Called by EXAMPLE-RLINK.STATEMENT.PDF. Base-64 encodes a passed hex-encoded string.</dt>

<dt>PCL5.RBOX.SUB</dt>
<dd>Called by STATEMENT.IMAGE.SUB. Uses passed X/Y coordinates and width/depth parameters to create a PCL5 string to draw a shaded box on a page into which text can be laid.</dd>

<dt>PCL5.RFNT.SUB</dt>
<dd>Called by STATEMENT.IMAGE.SUB. Uses passed parameters to create a PCL5 string to set font characteristics for subsequent text.</dd>

<dt>PCL5.RPOS.SUB</dt>
<dd>Called by STATEMENT.IMAGE.SUB. Uses passed X/Y coordinates to create a PCL5 string to position subsequent text on a page.</dd>

</dl>