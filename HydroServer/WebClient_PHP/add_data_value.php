<?php
//check authority to be here
require_once 'authorization_check.php';

//connect to server and select database
require_once 'database_connection.php';

//add the SourceID's
$sql ="Select * FROM sources";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$num = @mysql_num_rows($result);
	if ($num < 1) {

    $msg = "<P><em2>Sorry, there are no SourceID names.</em></p>";

	} else {

	while ($row = mysql_fetch_array ($result)) {

		$sourceid = $row["SourceID"];
		$sourcename = $row["Organization"];

		$option_block .= "<option value=$sourceid>$sourcename</option>";

		}
	}

//add the SiteID's
$sql2 ="Select * FROM sites";

$result2 = @mysql_query($sql2,$connection)or die(mysql_error());

$num = @mysql_num_rows($result2);
	if ($num < 1) {

    $msg2 = "<P><em2>Sorry, there are no SiteID names.</em></p>";

	} else {

	while ($row2 = mysql_fetch_array ($result2)) {

		$siteid = $row2["SiteID"];
		$sitename = $row2["SiteName"];

		$option_block2 .= "<option value=$siteid>$sitename</option>";

		}
	}

//add the Types
$sql3 ="Select * FROM variables ORDER BY VariableName ASC";

$result3 = @mysql_query($sql3,$connection)or die(mysql_error());

$num = @mysql_num_rows($result3);
	if ($num < 1) {

    $msg3 = "<P><em2>Sorry, there are no Types.</em></p>";

	} else {

	while ($row3 = mysql_fetch_array ($result3)) {

		$typeid = $row3["VariableID"];
		$typename = $row3["VariableName"];
		$datatype = $row3["DataType"];

		$option_block3 .= "<option value=$typeid>$typename ($datatype)</option>";

		}
	}

//add the Methods
$sql4 ="Select * FROM methods";

$result4 = @mysql_query($sql4,$connection)or die(mysql_error());

$num = @mysql_num_rows($result4);
	if ($num < 1) {

    $msg4 = "<P><em2>Sorry, there are no Methods.</em></p>";

	} else {

	while ($row4 = mysql_fetch_array ($result4)) {

		$methodid = $row4["MethodID"];
		$methodname = $row4["MethodDescription"];

		$option_block4 .= "<option value=$methodid>$methodname</option>";

		}
	}

?>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />

<script type="text/javascript">
function show_answer(){
alert("If you do not see your location listed here," + '\n' + "please contact your teacher and ask them" + '\n' + "to add it before entering data.");
}
</script>

<script src="js/numbervalidation.js"></script>

<link rel="stylesheet" href="styles/jqstyles/jquery.ui.all.css">
<link rel="stylesheet" href="styles/jqstyles/jquery.ui.timepicker.css">
<script src="js/jquery-1.7.2.js"></script>
<script src="js/ui/jquery.ui.core.js"></script>
<script src="js/ui/jquery.ui.widget.js"></script>
<script src="js/ui/jquery.ui.datepicker.js"></script>
<script src="js/ui/jquery.ui.timepicker.js"></script>
<link rel="stylesheet" href="styles/jqstyles/demos.css">
<script>
	$(function() {
		
		$( "#datepicker" ).datepicker({ dateFormat: "yy-mm-dd" });
		
		
		$( "#timepicker" ).timepicker({
			showOn: "focus",
    		showPeriodLabels: false,
		});
		
	});
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
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>Enter a single data value</h1>
      <p>&nbsp;</p>
      <FORM METHOD="POST" ACTION="do_add_data_value.php" name="addvalue">
      <table width="500" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td valign="top"><strong>Source:</strong></td>
          <td valign="top"><select name="SourceID" id="SourceID"><option value="">Select....</option><?php echo "$option_block"; ?></select></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td valign="top"><strong>Site:</strong></td>
          <td valign="top"><select name="SiteID" id="SiteID"><option value="">Select....</option><?php echo "$option_block2"; ?></select> <a href="#" onClick="show_answer()" border="0"><img src="images/questionmark.png"></a></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Type:</strong></td>
          <td width="370" valign="top"><select name="VariableID" id="VariableID">
            <option value="">Select....</option><?php echo "$option_block3"; ?></select></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td valign="top"><strong>Method:</strong></td>
          <td valign="top"><select name="MethodID" id="MethodID">
            <option value="">Select....</option><?php echo "$option_block4"; ?></select></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="370" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Date:</strong></td>
          <td valign="top"><input type="text" id="datepicker" name="datepicker"><span class="em">&nbsp;(Ex: &quot;2012-05-04&quot; for 4 May  2012)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Time:</strong></td>
          <td valign="top"><input type="text" id="timepicker" name="timepicker"><span class="em">&nbsp;(24 hour format; Ex: &quot;13:45&quot; for 1:45 pm)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Value:</strong></td>
          <td valign="top"><input type="text" id="value" name="value" size=10 maxlength=20 onBlur="return validateNum()"/><span class="em">&nbsp;(Must be a number; no commas allowed)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top">&nbsp;</td>
          <td valign="top"><input type="SUBMIT" name="submit" value="Submit Your Data" /></td>
          </tr>
      </table>
      </FORM></p>
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
