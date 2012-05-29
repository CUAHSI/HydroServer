<?php
// set the expiration date to one hour ago
setcookie ("auth", "", time() - 3600, "localhost");
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client: Homepage: Unauthorized User</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />

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
    <FORM METHOD="POST" ACTION="home.php">
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
            <INPUT TYPE="text" NAME="username" SIZE=25 MAXLENGTH=25></center></td>
        </tr>
        <tr>
          <td><center><font face="Arial, Helvetica, sans-serif" size="2"><strong>Password:</strong></font><br />
            <INPUT TYPE="password" NAME="password" SIZE=25 MAXLENGTH=25></center></td>
        </tr>
        <tr>
          <td><center><INPUT TYPE="SUBMIT" NAME="submit" VALUE="Login"></center></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><center><A HREF="#" onclick="show_alert()">Forgot your password?</a></center></td>
        </tr>
    </table></FORM>
    </td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote>
      <p><br />
        </p>
      <p><strong><em>You are not authorized to view this page.</em></strong><em> (If you feel this message is in error, please login and try navigating to it again.</em>)</p>
<p>&nbsp;</p>
<h1><img src="images/homepage_shot.jpg" alt="student working with teacher" width="300" height="235" hspace="10" align="right" />Welcome</h1>
        <p>The HydroServer Lite Interactive Web Client is an online software tool that helps store, organize, and publish data provided by citizen scientists.</p>
        <p>What are citizen scientists? They can be anyone who collects and  shares scientific data with professional scientists to achieve common goals.</p>
        <p>Once you are a  registered user, you will be able to login and upload your own data into our database to  provide valuable input into the research being done in your area as well as around the world.</p>
<p>This software is furnished by the <a href="http://www.cuahsi.org" target="_blank">Consortium of Universities for the Advancement of Hydrologic Sciences</a>, or commonly referred to as CUAHSI (pronounced &quot;kwä-zē&quot;).</p>
<p>To find out how your school or organization can get their own version 
of the HydroServer Lite Interactive Web Client,
please contact us  at <a href="#">email</a>.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
    </blockquote></td>
  </tr>
  <tr>
    <script src="footer.js"></script>
  </tr>
</table>
</body>
</html>