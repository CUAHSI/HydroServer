<?php
//check authority to be here
require_once 'authorization_check.php';

//check for required fields
if ((!$_POST['username']) || (!$_POST['password'])) {
	header("Location: changepassword.php");
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

//Display the appropriate user authority to add depending on the user's authority
if ($_COOKIE[power] == "admin"){
	//select the users
	$sql ="Select username FROM moss_users WHERE (authority='teacher' OR authority='student') ORDER BY username";
	$result = @mysql_query($sql,$connection)or die(mysql_error());
	$num = @mysql_num_rows($result);
	if ($num < 1) {
    	$msg2 = "<P><em2>Sorry, there are no users.</em></p>";
	} else {
	while ($row = mysql_fetch_array ($result)) {
		$users = $row["username"];
		$option_block .= "<option value=$users>$users</option>";
		}
	}
}
elseif ($_COOKIE[power] == "teacher"){
	//select the users
	$sql ="Select username FROM moss_users WHERE authority='student' ORDER BY username";
	$result = @mysql_query($sql,$connection)or die(mysql_error());
	$num = @mysql_num_rows($result);
	if ($num < 1) {
    	$msg2 = "<P><em2>Sorry, there are no users.</em></p>";
	} else {
	while ($row = mysql_fetch_array ($result)) {
		$users = $row["username"];
		$option_block .= "<option value=$users>$users</option>";
		}
	}
}
elseif ($_COOKIE[power] == "student"){
	header("Location: unauthorized.php");
	exit;	
	}

?>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
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
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br /><?php echo "$msg"; ?><?php echo "$msg2"; ?>
      <h1>Change a password for a user</h1>
      <p>&nbsp;</p>
      <FORM METHOD="POST" ACTION="do_changepassword.php">
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
          <td valign="top"><input type="SUBMIT" name="submit" value="Change Password" class="button" style="width: 145px" /></td>
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
    <script src="js/footer.js"></script>
  </tr>
</table>
</body>
</html>