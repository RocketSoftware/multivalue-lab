<html>
  <head>
    <title>Upload picture for client</title>
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
if (isset($_GET["custid"]))
{
   $prevurl = $_GET["urlloc"];
   $client_key = $_GET["custid"];
   setcookie('mainsite', $prevurl);
   setcookie('clkey', $client_key);
   $uploadresult = "";

   ob_start();
?>
    <form action="<?php echo $_SERVER['PHP_SELF'] ?>" method="post" enctype="multipart/form-data">
      <h1>Function to upload an image file for the client</h1>
      <h2>Only JPG, JPEG, PNG and GIF files are allowed.<br>Size must be less than 500 Kbytes.</h2>
      <h3 style="color:#0489B1">Select image to upload for client <?php echo $client_key; ?>:</h3>
      <input type="file" name="fileToUpload" id="fileToUpload" size="70" />
      <br><br><input type="submit" class="buttoninfo" value="Upload Image" name="submit">
      &#8195;
      <input type="button" value="Cancel" class="buttoninfo" onclick=javascript:returnMain(<?php echo "'" . $prevurl . "'"; ?>)>

      <br><br><label for uploadstatus><b>Upload status:</b></label>
      <br><textarea name="uploadstatus" cols="52" rows="5"><?php echo $uploadresult; ?></textarea>
    </form>
<?php
   ob_get_contents();
}
if (isset($_POST['submit']))
{
  $prevurl = $_COOKIE['mainsite'];
  $client_key = $_COOKIE['clkey'];
  $uploadresult = "";
  $target_dir = "images/Clients/";
  $target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);
  $baseimgfile = basename( $_FILES["fileToUpload"]["name"]);

  $uploadOk = 1;
  $imageFileType = pathinfo($target_file,PATHINFO_EXTENSION);
  $check = getimagesize($_FILES["fileToUpload"]["tmp_name"]);
  if($check !== false)
  {
    $uploadresult .= "File is an image - " . $check["mime"] . ". ";
    $uploadOk = 1;
  } else {
    $uploadresult .= "File is not an image. ";
    $uploadOk = 0;
  }
// Check if file already exists
  if (file_exists($target_file))
  {
    $uploadresult .= "File already exists. ";
    $uploadOk = 0;
  }
// Check file size
  if ($_FILES["fileToUpload"]["size"] > 500000)
  {
    $uploadresult .= "File is too large to upload. ";
    $uploadOk = 0;
  }
// Allow certain file formats
  if($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg"
&& $imageFileType != "gif" )
  {
    $uploadresult .= "Sorry, only JPG, JPEG, PNG & GIF files allowed. ";
    $uploadOk = 0;
  }
  if ($baseimgfile == "")
  {
     $uploadresult = "Image not selected. ";
     $uploadOk = 0;
  }
// Check if $uploadOk is set to 0 by an error
  if ($uploadOk == 0)
  {
    $uploadresult .= "File was not uploaded.";
// if everything is ok, try to upload file
  } else {
    if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file))
    {
      $cmd = "C:\U2\ud82\python\python C:\U2\ud82\python\ClientsScript.py " . '"cl_uploadimg" ' . '"' . $client_key . '" ' . '"' . $baseimgfile . '"';
      exec($cmd, $execoutput, $returnvar);
      $uploadresult .= "The file ". $baseimgfile . " has been uploaded.";
    } else {
      $uploadresult .= "Sorry, there was an error uploading your file.";
    }

  }
ob_start();
?>
   <form>
      <h1>Function to upload an image file for the client</h1>
      <h2>Only JPG, JPEG, PNG and GIF files are allowed.<br>Size must be less than 500 Kbytes.</h2>
      <h3 style="color:#0489B1">Target image file for client <?php echo $client_key; ?>:</h3>
      <input type="text" name="filetext" size="70" value="C:\inepub\wwroot\<?php echo $target_file; ?>" disabled>
      <br><br><label for uploadstatus><b>Upload status:</b></label>
      <br><br><textarea name="uploadstatus" cols="52" rows="5"><?php echo $uploadresult; ?></textarea>
      <br><br><input type="button" class="buttoninfo" value="OK" onclick=javascript:returnMain(<?php echo "'" . $prevurl . "'"; ?>)>
   </form>
<?php
ob_get_contents();
}
?>
<script type="text/javascript">
      function returnMain(oldurl)
      {
         window.location.href = oldurl;
      }
    </script>
  </body>
</html>