<?php

//connect to server and select database
require_once 'database_connection.php';
require_once 'main_config.php';
//build and issue the query
$sql ="SELECT * FROM moss_users WHERE username='$_POST[username]' AND password= password('$_POST[password]')";

$result = @mysql_query($sql,$connection) or die(mysql_error());

//get the number of rows in the result set
$num = mysql_num_rows($result);
	if ($num != 0) {
		//get the person's first name and authority
		while ($row = mysql_fetch_assoc($result)) {
		$firstname = $row['firstname'];
		$auth = $row['authority'];
		}
		$msg ="<h1>Welcome, $firstname!</h1>";
	} else {
		header("Location: index.php?state=pass");
		exit;
	}

//Set the navigation menu and a cookie of the user's authority
// or redirect the user elsewhere if unauthorized

if ($auth == "admin"){
	$nav = "<script src=js/A_navbar.js></script>";
	$cookie_name = "power";
	$cookie_value = $auth;
	$cookie_expire = time()+14400;
	$cookie_domain = $www;
	setcookie($cookie_name, $cookie_value, $cookie_expire, "/", $cookie_domain, 0);
	}
elseif ($auth == "teacher"){
	$nav = "<script src=js/T_navbar.js></script>";
	$cookie_name = "power";
	$cookie_value = $auth;
	$cookie_expire = time()+14400;
	$cookie_domain = $www;
	setcookie($cookie_name, $cookie_value, $cookie_expire, "/", $cookie_domain, 0);
	}
elseif ($auth == "student"){
	$nav = "<script src=js/S_navbar.js></script>";
	$cookie_name = "power";
	$cookie_value = $auth;
	$cookie_expire = time()+14400;
	$cookie_domain = $www;
	setcookie($cookie_name, $cookie_value, $cookie_expire, "/", $cookie_domain, 0);
	}
else {
	header("Location: index.php?state=pass2");
	exit;	
	}

?>

<html>
<head>
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
</head>

<body background="images/bkgrdimage.jpg">
<table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning banner" /></td>
  </tr>
  <tr>
    <td colspan="2" align="right" valign="middle" bgcolor="#3c3c3c"><?php require_once 'header.php'; ?></td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <?php echo "$msg"; ?>
      <p>Please select a function from the left-hand menu....</p>
      <p></p>
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
    <script src="js/footer.js"></script>
  </tr>
</table>
</body>
</html>