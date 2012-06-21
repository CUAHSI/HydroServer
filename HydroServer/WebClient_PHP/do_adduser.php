<?php
//check for required fields
if ((!$_POST['firstname']) || (!$_POST['lastname']) || (!$_POST['username']) || (!$_POST['password']) || (!$_POST['authority'])) {
	header("Location: adduser.php");
	exit;
}

//check authority to be here
require_once 'authorization_check.php';

//connect to server and select database
require_once 'database_connection.php';

//add the user's data
$sql ="INSERT INTO moss_users(firstname, lastname, username, password, authority) VALUES ('$_POST[firstname]', '$_POST[lastname]', '$_POST[username]', PASSWORD('$_POST[password]'), '$_POST[authority]')";

$result = @mysql_query($sql,$connection)or die(mysql_error());

//get a good message for display upon success
if ($result) {

$msg ="<p class=em2>Congratulations, you've registered $_POST[firstname]. Would you like to add another?</p>";
}

//Display the appropriate user authority to add depending on the user's authority
if ($_COOKIE[power] == "admin"){
	$selection = "<select name=authority id=authority><option value=>Select....</option><option value=admin>Administrator</option><option value=teacher>Teacher</option><option value=student>Student</option></select>";		
	}
elseif ($_COOKIE[power] == "teacher"){
	$selection = "<select name=authority id=authority><option value=>Select....</option><option value=teacher>Teacher</option><option value=student>Student</option></select>";
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
    <td colspan="2" align="right" valign="middle" bgcolor="#3c3c3c"><?php require_once 'header.php'; ?></td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br /><?php echo "$msg"; ?>
      <h1>Add a new user</h1>
      <p>&nbsp;</p>
      <FORM METHOD="POST" ACTION="do_adduser.php">
      <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="95" valign="top"><strong>First Name:</strong></td>
          <td width="175" valign="top"><input type="text" name="firstname" size=25 maxlength=50 /></td>
          <td width="330" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="175" valign="top">&nbsp;</td>
          <td width="330" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="95" valign="top"><strong>Last Name:</strong></td>
          <td valign="top"><input type="text" name="lastname" size=25 maxlength=50 /></td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="95" valign="top"><strong>Username:</strong></td>
          <td valign="top"><input type="text" name="username" size=25 maxlength=25 />
          <div class="em"></div></td>
          <td valign="top"><span class="em">&nbsp;(First initial and last name; ex: &quot;jdoe&quot; for John Doe)</span></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="95" valign="top"><strong>Password:</strong></td>
          <td valign="top"><input type="text" name="password" size=25 maxlength=25 /><div class="em"></div></td>
          <td valign="top"><span class="em">&nbsp;(Case sensitive; enter 6-8 characters)</span></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="95" valign="top"><strong>Authority:</strong></td>
          <td valign="top"><?php echo "$selection"; ?></td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="95" valign="top">&nbsp;</td>
          <td valign="top"><input type="SUBMIT" name="submit" value="Add User" class="button"/></td>
          <td valign="top">&nbsp;</td>
        </tr>
      </table></FORM>
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
