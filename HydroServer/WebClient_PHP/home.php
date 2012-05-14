<?php
//check for required fields
if ((!$_POST['username']) || (!$_POST['password'])) {
	header("Location: index.html");
	exit;
}

//setup names of database and table to use
$db_name ="moss_db";
$table_name ="moss_users";

//connect to server and select database
$connection = @mysql_connect("localhost","wc4moss","pw2testWC") or die(mysql_error());

$db = @mysql_select_db($db_name,$connection)or die(mysql_error());

//build and issue the query
$sql ="SELECT * FROM $table_name WHERE username='$_POST[username]' AND password= password('$_POST[password]')";

$result = @mysql_query($sql,$connection) or die(mysql_error());

//get the number of rows in the result set
$num = mysql_num_rows($result);
	if ($num != 0) {
		//get the person's first name
		while ($row = mysql_fetch_assoc($result)) {
		$firstname = $row['firstname'];
		}
		$msg ="<h1>Welcome, $firstname!</h1>";
	} else {
		header("Location: index.html");
		exit;
	}

$auth = mysql_result($result,0,"authority");

		if ($auth == "admin") {
			$nav ="<SCRIPT src=A_navbar.js></SCRIPT>";
		
		} elseif ($auth == "teacher") {
			$nav ="<SCRIPT src=T_navbar.js></SCRIPT>";
		
		} else {
			$nav ="<SCRIPT src=S_navbar.js></SCRIPT>";
		}
		
?>

<html>
<head>
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
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <?php echo "$msg"; ?>
      <p>Please select a function from the left-hand menu....</p>
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