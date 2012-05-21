<?php
//check authority to be here
require_once 'auth_admin.php';

//check for required fields
if ((!$_POST['username']) || (!$_POST['password'])) {
	header("Location: changepassword_admin.php");
	exit;
}

//connect to server and select database
require_once 'database_connection.php';

//add the user's data
$sql ="UPDATE moss_users SET password=PASSWORD('$_POST[password]') WHERE username='$_POST[username]'";

$result = @mysql_query($sql,$connection)or die(mysql_error());

//get a good message for display upon success
if ($result) {

$msg ="<p class=em2>Congratulations, you're changed the password of $_POST[username]. Would you like to do another?</p>";
}

//add the user's data
$sql2 ="Select username FROM moss_users WHERE (authority='teacher' OR authority='student') ORDER BY username";

$result2 = @mysql_query($sql2,$connection)or die(mysql_error());

$num = @mysql_num_rows($result2);

	if ($num < 1) {

    	$msg2 = "<P><em2>Sorry, there are no users.</em></p>";

	} else {

	while ($row = mysql_fetch_array ($result2)) {

		$users = $row["username"];

		$option_block .= "<option value=$users>$users</option>";
		}
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
    <td width="240" valign="top" bgcolor="#f2e6d6"><SCRIPT src="A_navbar.js"></SCRIPT></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>Change a password for a user</h1>
      <p><?php echo "$msg,$msg2"; ?>&nbsp;</p>
      <FORM METHOD="POST" ACTION="do_changepassword_admin.php">
        <table width="300" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="100" valign="top"><strong>Username:</strong></td>
          <td width="200" valign="top"><select name="username" id="username"><option value="">Select a username....</option><?php echo "$option_block"; ?></select></td>
        </tr>
        <tr>
          <td width="100" valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>New Password:</strong></td>
          <td valign="top"><input type="text" name="password" size="25" maxlength="25" /></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top"><input type="SUBMIT" name="submit" value="Change Password" /></td>
        </tr>
      </table>
  </FORM>
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
    <SCRIPT src="footer.js"></SCRIPT>
  </tr>
</table>
</body>
</html>