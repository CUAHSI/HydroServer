<?php

//check authority to be here
require_once 'authorization_check2.php';

?>

<html>
<head>
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />

</head>

<body background="images/bkgrdimage.jpg" onLoad="load()">
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
         <h1>Help Center (FAQ's)</h1>
         <p>If you need help with a part of the website, please review our Frequently Asked Questions below.</p>
         <p><a href="#Register">How do I register for an account?</a><br>
         <a href="#Bug">Need to report a bug?</a><br>
         <a href="#Questions">Still have questions?</a><br>
         <a href="#CreatSite">Ready to create a site of your own?</a> </p>
        <hr width="400">
<p><strong><a name="Register"></a>How do I register for an account, so I can enter data?</strong><br>
          Creating an account 
        must be done by your direct supervisor. Please contact them to fulfil this request.</p>
<p><strong><a name="Bug" id="Bug"></a>Need to report a bug?</strong><br>
If you are experiencing an issue with the website, you may share it with the programming team to have it resolved. Please visit us <a href="http://www.adventurelearningat.com/his/client/issues/index.php" target="_blank">here</a>, register for an account, and post the request by clicking &quot;Create Issue&quot; in the &quot;Issue Tracker.&quot;</p>
         <p><strong><a name="Questions"></a>Still have questions?</strong><br>
         If you do not see the answer you are seeking, please contact your direct supervisor about these additional  questions.</p>
         <p><strong><a name="CreatSite" id="CreatSite"></a>Ready to create a site of your own?</strong><br>
This software is furnished by the <a href="http://www.cuahsi.org/" title="Link to CUAHSI" target="_blank">Consortium of Universities for the Advancement of Hydrologic Sciences</a>, or commonly referred to as CUAHSI (pronounced &quot;kwä-ze&quot;). To find out how your school or organization can get their own version of the HydroServer Lite Interactive Web Client, please contact us <a href="http://hydroserver.codeplex.com/" target="_blank">here</a>.</p>
         <p>&nbsp;</p>
         <p>&nbsp;</p>
    </blockquote>
    </td>
  </tr>
  <tr>
    <script src="js/footer.js"></script>
  </tr>  
</table>
</body>
</html>