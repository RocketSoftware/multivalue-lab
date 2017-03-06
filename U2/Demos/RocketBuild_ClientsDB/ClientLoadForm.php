<html>
  <head>
    <title>Update Client Details</title>
  </head>

  <body>
    <style type="text/css">
.buttoninfo{
    border: 1px black solid;
    font-weight: bold;
    width: 120px;
    text-align: center;
    background-color:#A9E2F3; 
}
    </style>

<?php

// Check if we have parameter custid being passed to the script through the URL 
if (isset($_GET["custid"]))
{
   $prevurl = $_GET["urlloc"];
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
    <form>
	  <table>
	    <tbody>
	      <tr>
	        <td>
	          <br><b>CLIENT ID:</b>
	        </td>
	      <td>
	          <br><b><input type = "text" id="ClientID" value="<?php echo $client_key ?>" disabled></b>
	        </td>
	      </tr>
	      <tr>
	        <td>
	          <br><label for="Name">Full name:</label>
	        </td>
	        <td>
	          <br><input type="text" id="Name" size="30" value="<?php echo $custname ?>">
	        </td>
	      </tr>
	      <tr>
	        <td>
	          <br><label for="AddressLine1">Address line 1: </label>
	        </td>
	        <td>
	          <br><input type="text" id="AddressLine1" size="40" value="<?php echo $addrln1 ?>">
	        </td>
	      </tr>
	      <tr>
	        <td>
	          <label for="AddressLine2">Address line 2: </label>
	        </td>
	        <td>
	          <input type="text" id="AddressLine2" size="40" value="<?php echo $addrln2 ?>">
	        </td>
	      </tr>
	      <tr>
	        <td>
	          <label for="AddressLine3">Address line 3: </label>
	        </td>
	      <td>
	          <input type="text" id="AddressLine3" size="40" value="<?php echo $addrln3 ?>">
	        </td>
	      </tr>
	      <tr>
	        <td>
	          <label for="zipCode">Zip Code: </label>
	        </td>
	        <td>
	          <input type="text" id="zipCode" size="10" value="<?php echo $zipcode ?>">
	        </td>
	      </tr>
	      <tr>
	        <td>
	          <br><br><input type="button" class="buttoninfo" value="Submit details" onclick=javascript:updatedetails(<?php echo "'" . $prevurl . "'"; ?>)>
	        </td>
            <td>
              <br><br><input type="button" class="buttoninfo" style="background-color:#A9E2F3" value="Cancel" onclick=javascript:cancelupdate(<?php echo "'" . $prevurl . "'"; ?>)>
            </td>
          </tr>
	    </tbody>
	  </table>
	</form>
<?php
	ob_get_contents();
      }
   }
}
?>
    <script type="text/javascript">
      function updatedetails(oldurl)
      {
// double-quotes cause errors in json string to be passed. Output error if located in input
        inputerr = 0;
        tmpvar = document.getElementById('Name').value;
        if (tmpvar.search('"') > 0){inputerr = 1};
        tmpvar = document.getElementById('AddressLine1').value;
        if (tmpvar.search('"') > 0){inputerr = 1};
        tmpvar = document.getElementById('AddressLine2').value;
        if (tmpvar.search('"') > 0){inputerr = 1};
        tmpvar = document.getElementById('AddressLine3').value;
        if (tmpvar.search('"') > 0){inputerr = 1};
        tmpvar = document.getElementById('zipCode').value;
        if (tmpvar.search('"') > 0){inputerr = 1};

        if(inputerr) {
           alert('Double-quotes are not valid in this data entry screen');
        } else {
           clientDetails = {};
           updclientkey = document.getElementById('ClientID').value;
           clientDetails.clientid = updclientkey;
           clientDetails.Name = document.getElementById('Name').value;
           clientDetails.AddressLine1 = document.getElementById('AddressLine1').value;
           clientDetails.AddressLine2 = document.getElementById('AddressLine2').value;
           clientDetails.AddressLine3 = document.getElementById('AddressLine3').value;
           clientDetails.ZipCode = document.getElementById('zipCode').value;
           jsonstr = JSON.stringify(clientDetails);
           winref='ClientUpdateView.php?urlloc=' + oldurl + '&updclientkey=' + updclientkey + '&newdetails=' + jsonstr;
           newWindow = window.open(encodeURI(winref),"_self", "");
        }
      }

      function cancelupdate(oldurl)
      {
 	    window.location.href = oldurl;
      }
    </script>
  </body>
</html>
