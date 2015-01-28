D3 Miscellaneous Tools
======================

A collection of miscellaneous D3 FlashBASIC subroutines.

<dl>

<dt>HTTP.GET.SUB</dt>
<dd>Uses D3's built-in FlashBASIC socket functions to send an HTTP GET request to a server and retrieve the response.</dd>

<dt>HTTPS.GET.SUB</dt>
<dd>Uses D3's built-in FlashBASIC socket functions to send an HTTPS GET request to a server and retrieve the response (SSL version of HTTP.GET.SUB).</dd>

<dt>HTTP.POST.SUB</dt>
<dd>Uses D3's built-in FlashBASIC socket functions to send data as HTTP POST content to a server and retrieve the status response.</dd>

<dt>HTTPS.POST.SUB</dt>
<dd>Uses D3's built-in FlashBASIC socket functions to send data as HTTPS POST content to a server and retrieve the status response (SSL version of HTTP.POST.SUB).</dd>

<dt>GET.JSON.FIELD.SUB</dt>
<dd>A D3 FlashBASIC subroutine that returns a dynamic array containing information extracted from a JSON string. Each attribute of the dynamic array is the value, object or array associated with the passed name.</dd>

<dt>PARSE.XML.SUB</dt>
<dd>A D3 FlashBASIC subroutine that parses an XML-encoded file into a dynamic array which can then be queried by GET.XML.FIELD.SUB. Each attribute is either a tag or its contents (<name>Bob</name> parses to three attributes).</dd>

<dt>GET.XML.FIELD.SUB</dt>
<dd>A D3 FlashBASIC subroutine that returns a dynamic array containing information extracted from a dynamic array created by PARSE.XML.SUB. Each occurrence of a tag results in a separate attribute containing the tag's contents as values (<line><qty>1</qty></line><line><qty>2</qty></line> returns two attributes with three values each).</dd>

<dt>BASE.64.ENCODE.TXT.SUB</dt>
<dd>Base-64 encodes a passed ASCII-encoded string.</dd>

<dt>BASE.64.DECODE.HEX.SUB</dt>
<dd>Decodes a passed base-64-encoded string, returns a hex-encoded string.</dd>

<dt>BASE.64.ENCODE.HEX.SUB</dt>
<dd>Base-64 encodes a passed hex-encoded string.</dt>

<dt>PCL5.RBOX.SUB</dt>
<dd>Uses passed X/Y coordinates and width/depth parameters to create a PCL5 string to draw a shaded box on a page into which text can be laid.</dd>

<dt>PCL5.RFNT.SUB</dt>
<dd>Uses passed parameters to create a PCL5 string to set font characteristics for subsequent text.</dd>

<dt>PCL5.RPOS.SUB</dt>
<dd>Uses passed X/Y coordinates to create a PCL5 string to position subsequent text on a page.</dd>

</dl>