<?php

//setup names of database and table to use
$db_name ="moss_db";
$table_name ="moss_users";

//connect to server and select database
$connection = @mysql_connect("localhost","wc4moss","pw2testWC") or die(mysql_error());

$db = @mysql_select_db($db_name,$connection)or die(mysql_error());

//add the user's data
$sql ="SELECT username FROM $table_name WHERE (authority='teacher' OR authority='student') ORDER BY username";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$num = @mysql_num_rows($result);
	if ($num < 1) {

    	$msg = "<P><em2>Sorry, there are no users.</em></p>";

	} else {

	while ($row = mysql_fetch_array ($result)) {

		$users = $row["username"];

		$option_block .= "<option value=$users>$users</option>";

		}
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
    <td colspan="2"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning banner" /></td>
  </tr>
  <tr>
    <td colspan="2" bgcolor="#3c3c3c">&nbsp;</td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><SCRIPT src="A_navbar.js"></SCRIPT></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>Change the authority of a user</h1>
      <p><?php echo "$msg"; ?>&nbsp;</p>
      <p><strong>Change Authority</strong></p>
      <form method="post" action="do_changeauthority_admin.php">
        <table width="300" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="95" valign="top"><strong>Username:</strong></td>
            <td width="205" valign="top"><select name="username" id="username"><option value="">Select a username....</option><?php echo "$option_block"; ?></select></td>
          </tr>
          <tr>
            <td width="95" valign="top">&nbsp;</td>
            <td valign="top">&nbsp;</td>
          </tr>
          <tr>
            <td valign="top"><strong>New Authority:</strong></td>
            <td valign="top"><select name="authority" id="authority">
              <option value="">Select a level....</option>            
              <option value="admin">Administrator</option>
              <option value="teacher">Teacher</option>
              <option value="student">Student</option></select></td>
          </tr>
          <tr>
            <td valign="top">&nbsp;</td>
            <td valign="top">&nbsp;</td>
          </tr>
          <tr>
            <td valign="top">&nbsp;</td>
            <td valign="top"><input type="submit" name="submit2" value="Change Authority" /></td>
          </tr>
        </table>
  </form>
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