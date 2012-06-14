<?php
//check authority to be here
require_once 'authorization_check.php';

//redirect anyone that is not an administrator
if ($_COOKIE[power] !="admin"){
	header("Location: index.php?state=pass2");
	exit;	
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
      <h1>Add a new Method to the database    </h1>
      <p>&nbsp;</p>
      <FORM METHOD="POST" ACTION="do_add_method.php" name="addmethod">
        <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="94" valign="top"><strong>Method Name:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="MethodDescription" name="MethodDescription" size=20 maxlength=100"/>&nbsp;<span class="em">(Ex: YSI DO 200 Meter)</span></td>
        </tr>
        <tr>
          <td width="94" valign="top">&nbsp;</td>
          <td width="236" valign="top">&nbsp;</td>
          <td width="270" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Method Link:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="MethodLink" name="MethodLink" size=20 maxlength=200"/>&nbsp;<span class="em">(Ex: http://www.ysi.com/productsdetail.php?DO200-35)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="236" valign="top">&nbsp;</td>
          <td width="270" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="94" valign="top">&nbsp;</td>
          <td width="236" valign="top">&nbsp;</td>
          <td width="270" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2" valign="top"><center><input type="SUBMIT" name="submit" value="Add New Method" /></center></td>
          <td valign="top">&nbsp;</td>
          </tr>
      </table></FORM>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
    </blockquote>
    <p></p></td>
  </tr>
  <tr>
    <script src="js/footer.js"></script>
  </tr>
</table>
</body>
</html>
