<html>
  <head>
    <title>Update/View Client Details</title>
  </head>


  <body>
    <style type="text/css">

#leftdiv{
    float:left;
}
#header{
    width:80px;
    height: 150px;
    border:0px;
}
#rightdiv{
    float:left;
}

.buttoninfo{
    border: 1px black solid;
    font-weight: bold;
    width: 50px;
    text-align: center;
    background-color:#A9E2F3; 
}
    </style>

    <script type="text/javascript">
      function gobacktomain(oldurl)
      {
	      window.location.href = oldurl;
      }
    </script>

<?php
if (isset($_GET["custid"]))
{
  $prevurl = $_GET["urlloc"];
  $custname = '';
  $addrln1 = '';
  $addrln2 = '';
  $addrln3 = '';
  $zipcode = '';
  $client_key = $_GET["custid"];
  $cmd = "C:\U2\ud82\python\python C:\U2\ud82\python\ClientsScript.py " . '"cl_getdetails" ' . '"' . $client_key . '"';
  exec($cmd, $execoutput, $returnvar);
  $arrcount = count($execoutput);
  if ($arrcount > 0)
  {
    foreach ($execoutput as $value)
    {
      $jsonObj = json_decode($value);
      $custname = $jsonObj->{Name};
      $addrln1 = $jsonObj->{AddressLine1};
      $addrln2 = $jsonObj->{AddressLine2};
      $addrln3 = $jsonObj->{AddressLine3};
      $zipcode = $jsonObj->{ZipCode};

      ob_start();
?>

    <div style="width:350;height:300;padding:10;border:2 solid;">
	    <form>
	      <table>
	        <tbody>
	          <tr>
	            <td><br><b><font color="blue">CLIENT ID:</font></b></td>
	            <td><br>&#8195;<b><?php echo $client_key ?></b></td>
	          </tr>
	          <tr>
              <td><br><font color="blue">Full name:</font></td>
              <td><br>&#8195;<?php echo $custname ?></td>
            </tr>
            <tr>
              <td><br><font color="blue">Address line 1:</font></td>
              <td><br>&#8195;<?php echo $addrln1 ?></td>
            </tr>
            <tr>
              <td><font color="blue">Address line 2:</font></td>
              <td>&#8195;<?php echo $addrln2 ?></td>
            </tr>
            <tr>
              <td><font color="blue">Address line 3:</font></td>
              <td>&#8195;<?php echo $addrln3 ?></td>
            </tr>
            <tr>
              <td><font color="blue">Zip Code:</font></td>
              <td>&#8195;<?php echo $zipcode ?></td>
            </tr>
            <tr>
              <td>
              </td>
              <td>
	              <br><br>&#8195;<input type="button" class="buttoninfo" value="OK" onclick=javascript:gobacktomain(<?php echo '"' . $prevurl . '"'?>)>
              </td>
            </tr>
	        </tbody>
	      </table>
	    </form>
    </div>

<?php
	    ob_get_contents();
    }
  }
}
if (isset($_GET["newdetails"]))
{
  $prevurl = $_GET["urlloc"];
  $newjson = $_GET["newdetails"];
  $updclientkey = $_GET["updclientkey"];
//
// note, if customer enters double-quote in input it screws things up due to JSON using " as part of spec...

  $dttm = getdate(date("U"));
  $dateout =  $dttm[year] . '-' . sprintf('%03d',$dttm[yday]) . '-' . sprintf('%02d',$dttm[hours]) . sprintf('%02d',$dttm[minutes]) . sprintf('%02d',$dttm[seconds]);
  $outputfile = 'cl' . $updclientkey . '-' . $dateout . '.txt';
  $outputpath = "C:\\temp\\" . $outputfile;
  $fh = fopen($outputpath, "wb");
  $updstat = fwrite($fh, $newjson); 
  fclose($fh);
  $cmd = 'C:\U2\ud82\python\python C:\U2\ud82\python\ClientsScript.py ' . '"cl_update" ' . '"' . $outputfile . '"';
  exec($cmd, $execoutput, $returnvar);

  ob_start();
?>

    <div id="rightdiv" align="center" style="width:300;height:150;padding:3;border:1 solid black;">
      <form>
        <br>Thanks for updating the client's details. 
	      <br>Don't forget to upload a picture for this client.
	      <br><br>Return value of submission: <?php echo $returnvar; ?>
	      <br><br><input type="button" value="OK" onclick=javascript:gobacktomain(<?php echo '"' . $prevurl . '"'; ?>)>
	    </form>
    </div>

<?php
  ob_get_contents();
}
?>
  </body>
</html>