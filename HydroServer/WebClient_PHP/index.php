<?php
// set the expiration date to one hour ago
unset($_COOKIE["power"]);
setcookie ("power", null, -3600, "/", "adventurelearningat.com", 0);

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client: Homepage</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />

<!-- JQuery JS -->
<script type="text/javascript" src="scripts/jquery-1.7.2.min.js"></script>

<script type="text/javascript">
function show_alert()
{
alert("If you have forgotten your password," + '\n' + "please contact your direct supervisor" + '\n' + "and they can reset it for you. Thank You!");
}
</script>

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
    <td width="240" valign="top" bgcolor="#f2e6d6">
    <p>&nbsp;</p>
    <FORM METHOD="POST" ACTION="home.php" name="login" id="login">
    <table width="200" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td><center>
            <font face="Arial, Helvetica, sans-serif" size="4"><strong>Returning Users</strong></font>
          </center></td>
        </tr>
        <tr>
          <td><hr width="150" noshade="noshade" /></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><center><font face="Arial, Helvetica, sans-serif" size="2"><strong>Username:
          </strong></font><br />
            <INPUT TYPE="text" id="username" name="username" SIZE=25 MAXLENGTH=25></center></td>
        </tr>
        <tr>
          <td><center><font face="Arial, Helvetica, sans-serif" size="2"><strong>Password:</strong></font><br />
            <INPUT TYPE="password" id="password" name="password" SIZE=25 MAXLENGTH=25></center></td>
        </tr>
        <tr>
          <td><center><INPUT TYPE="SUBMIT" NAME="submit" VALUE="Login" class="button"></center></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><center><A HREF="#" onclick="show_alert()">Forgot your password?</a></center></td>
        </tr>
    </table></FORM>
    <p>&nbsp;</p>
    <p><center><strong><a href="view_main.php" class="button"><img src='images/icons/SearchData.png'>&nbsp;&nbsp;Search Data</a></strong>
    </center></p></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <p><?php if ($_GET['state'])
	  {
		  if ($_GET['state']=="pass"){
			echo "<p class=em2>***Incorrect username and/or password!</p>";
		}elseif ($_GET['state']=="pass2"){
			echo "<p class=em2>***You are not authorized to view that page!</p>";
			}
	  }
	  ?></p>
      <h1><img src="images/homepage_shot.jpg" alt="student working with teacher" width="300" height="235" hspace="10" align="right" />Welcome</h1>
        <p>The HydroServer Lite Interactive Web Client is an online software tool that helps store, organize, and publish data provided by citizen scientists.</p>
        <p>What are citizen scientists? They can be anyone who collects and  shares scientific data with professional scientists to achieve common goals.</p>
        <p>Once you are a  registered user, you will be able to login and upload your own data into our database to  provide valuable input into the research being done in your area as well as around the world.</p>
<p>This software is furnished by the <a href="http://www.cuahsi.org" target="_blank">Consortium of Universities for the Advancement of Hydrologic Sciences</a>, or commonly referred to as CUAHSI (pronounced &quot;kwä-zē&quot;).</p>
<p>To find out how your school or organization can get their own version 
of the HydroServer Lite Interactive Web Client,
please contact us <a href="http://www.hydrodesktop.org/" target="_blank">here</a>.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
    </blockquote></td>
  </tr>
  <tr>
    <script src="js/footer.js"></script>
  </tr>
</table>

<script type="text/javascript">

//Validate username and password
$("form").submit(function(){

	if(($("#username").val())==""){
	alert("Please enter a username!");
	return false;
	}

	if(($("#password").val())==""){
	alert("Please enter a password!");
	return false;
	}

//Now that all validation checks are completed, allow the data to query database

	return true;
});
</script>

</body>
</html>