<?php
//check authority to be here
require_once 'authorization_check.php';

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
      <h1>Import data file</h1>
      <p>In order to use this option, your CSV data file must conform to SQL database's requirements; therefore, your data should look like the following example before attempting to upload it: <a href="sample_csv.csv" target="_blank">view sample</a></p>
      <p>If your file is prepared correctly, you may use the process below:</p>
      <FORM METHOD="POST" ACTION="do_import_data_file.php" ENCTYPE="multipart/form-data">
        <p><strong>File to Upload:</strong><br>
		<INPUT TYPE="file" NAME="img1" SIZE="30"></P>
		<P><INPUT TYPE="submit" NAME="submit" VALUE="Upload File"></P>
		</FORM>
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
