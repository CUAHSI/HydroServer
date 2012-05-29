<?php
//check authority to be here
require_once 'authorization_check.php';

//upload protocol
if ($_FILES[img1] != "") {

	copy($_FILES[img1][tmp_name],"/usr/local/apache2/htdocs/".$_FILES[img1][name]) or die("Couldn't copy the file.");

} else {

	die("No input file specified");

}

?>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />
</head>

<body background="images/bkgrdimage.jpg">
<table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning Banner" /></td>
  </tr>
  <tr>
    <td colspan="2" bgcolor="#3c3c3c">&nbsp;</td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>Success!</h1>
      <p>You have uploaded <?php echo "$_FILES[name]"; ?> into the database.</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
<p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p></blockquote>
    </td>
  </tr>
  <tr>
    <script src="footer.js"></script>
  </tr>
</table>
</body>
</html>
