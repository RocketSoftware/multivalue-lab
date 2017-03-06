<html>
 <head>
  <title>Client interface</title>
 </head>

<body>
<style type="text/css">
.scrollable{
   overflow: auto;
    width: 520px;
    height: 610px;
    border: 3px silver solid;
}
.scrollable select{
   border: none;
}
#selection{
    width: 520px;
    height: 610px;
    float:left;
}
#seloptions{
    width: 220px;
    height: 610px;
    float:left;
}
.listheader{
    width: 520px;
    height: 80px;
    background-color:#eeeeee;
    border: 3px silver solid;
}
#leftdiv{
    float:left;
}
#header{
    width:700px;
    height: 100px;
    background-color:#CEECF5;
    border:0px;
}
#intro{
    width:700px;
    height: 250px;
    background-color:#eeeeee;
    border:0px;
}
#bottomimg{
    width:700px;
    height: 350px;
    background-color:#CEECF5;
    border:0px;
}

#rightdiv{
    float:left;
}
</style>
<style type="text/css">

.table-container {
    height: 0em;
}
table {
    display: flex;
    flex-flow: column;
    height: 100%;
    width: 100%;
}
table thead {
/* head takes the height it requires,
and it's not scaled when table is resized */
    flex: 0 0 auto;
    width: calc(100% - 0.9em);
    height:85px;
}
table tbody {
/* body takes all the remaining available space */
    flex: 1 1 auto;
    display: block;
    overflow-y: scroll;
}
table tbody tr {
    width: 100%;
}
table thead, table tbody tr {
    display: table;
    table-layout: fixed;
}
table, th, td {
    border: 2px solid black;
}
h1 {color:white;}
h2 {color:#6E6E6E;}

</style>
<script type="text/javascript">

function UpdateCl(custkey)
{
   wereHere = location.href;
   window.location.href = "ClientLoadForm.php?custid=" + custkey + "&urlloc=" +  wereHere;
}

function UploadCl(custkey)
{
   wereHere = location.href;
   window.location.href = "ClientImageForm.php?custid=" + custkey + "&urlloc=" +  wereHere;
}
function dispClientDetail(custkey)
{
   wereHere = location.href;
   window.location.href = "ClientUpdateView.php?custid=" + custkey + "&urlloc=" +  wereHere;
}
</script>


<!-- NOTE: resizing IE window ruins the formatting of divs. Need to fix this. -->
<div id="leftdiv">
 <div id="header">
   <br>
      <h1 style="color:#6E6E6E">CLIENTS DATABASE</h1>
 </div>
 <div id="intro">
   <br><blockquote>
     <h2>This project makes use of php, javascipt, JSON, python, and the UniData database.</h2>
     <h2>In place of a web service, python is used as the interface. JSON data is exchanged between python and the website.</h2>
     <h2>The user has the ability to view and update details, as well as upload images to the database for a particular client.</h2>
   </blockquote>
 </div>
 <div id="bottomimg">
   <br>
<!-- following line a bit dodgy but hey, this is just a demo....  -->
<!-- To do it properly is a bit complicated for this purpose.  -->
   <h1 style="color:#CEECF5">.............................<img src="images/Clients/handshake.jpg" alt="Meeting pic" style="width:220px; height:220px;"></h1>
   <h1 style="color:#6E6E6E"><marquee behavior="scroll" direction="left">Select a client image to view details</marquee></h1>
 </div>
</div>

<div id="selection">
  <div class="listheader">
     <h2 style="color:#6E6E6E">&#8195;List of clients...</h2>
  </div>

  <div class="table-container; scrollable">
     <table>
        <tbody>

<?php
$cmd = 'C:\U2\ud82\python\python C:\U2\ud82\python\ClientsScript.py "cl_list"';
exec($cmd, $execoutput, $returnvar);
$arrcount = count($execoutput);
if ($arrcount > 0)
{
   foreach ($execoutput as $value)
   {
      $pos = strpos($value, "\t");
      if ($pos > 0)
      {
         $client_key = substr($value,0,$pos);
         $img_src = substr($value,($pos+1),(strlen($value)-$pos-1));
         echo '<tr><td>';
         echo '<a href="javascript:dispClientDetail(' . "'" . $client_key . "'" . ');"><img src="images/Clients/' . $img_src . '" alt="' . $client_key . '" width="190" height="190"/></a>';
         echo '</td>';
//
         echo '<td><a href="javascript:UploadCl(' . "'" . $client_key . "'" . ');"><img src="images/Clients/UploadPic.JPG" width="140" height="80"/></a></td>';
//
         echo '<td><a href="javascript:UpdateCl(' . "'" . $client_key . "'" . ",'name'" . ');"><img src="images/Clients/UpdateClient.JPG" width="140" height="80"/></a>';
         echo '</td></tr>';
      }
   }
} else{
   echo "<tr><td>There is no one available on this list</td></tr>";
}
?>
        </tbody>
     </table>
  </div>
</div>
</body>
</html>
