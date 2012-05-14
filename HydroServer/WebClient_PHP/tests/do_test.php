<?

//connect to server and select database
require_once 'database_connection.php';

//add the user's data
$sql = "SELECT * FROM moss_users";


  
  if (!$sql) {
    die("<p>Error in executing the SQL query " . $sql . ": " . 
	  mysql_error() . "</p>");
  }
  
//get a good message for display upon success
if ($sql) {

$msg ="<p class=em2>$sql</p>";
}

?>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Hydrologic System</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />
</head>

<body background="images/bkgrdimage.png">
<table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning Banner" /></td>
  </tr>
  <tr>
    <td colspan="2" bgcolor="#3c3c3c">&nbsp;</td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><SCRIPT src="../HIS_navbar.js"></SCRIPT></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br /><? echo "$msg"; ?>
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
      <p>&nbsp;</p>
    </blockquote>
    <p></p></td>
  </tr>
  <tr>
    <td colspan="2" bgcolor="#0971B3"><center><font color="#FFFFFF" face="Arial, Helvetica, sans-serif" size="2"><i>HIS Hydrologic Systems. Copyright © 2012. All rights reserved.</i></font></center></td>
  </tr>
</table>
</body>
</html>
