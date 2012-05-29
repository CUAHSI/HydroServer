<?php

//check authority to be here
require_once 'authorization_check.php';

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

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
      <h1>Add a new user</h1>
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
          <td valign="top"><input type="SUBMIT" name="submit" value="Add User" /></td>
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
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
    </blockquote>
    <p></p></td>
  </tr>
  <tr>
    <script src="footer.js"></script>
  </tr>
</table>
</body>
</html>