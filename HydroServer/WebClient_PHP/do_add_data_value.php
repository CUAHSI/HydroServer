<?php

//check for required fields
if ((!$_POST['SourceID']) || (!$_POST['SiteID']) || (!$_POST['VariableID']) || (!$_POST['MethodID']) || (!$_POST['Date']) || (!$_POST['Time']) || (!$_POST['Value'])) {
	header("Location: add_data_value.php");
	exit;
}

require 'AL_hidden_values.php';

$SourceID = mysql_real_escape_string($_POST["SourceID"]);
$SiteID = mysql_real_escape_string($_POST["SiteID"]);
$VariableID = mysql_real_escape_string($_POST["VariableID"]);
$MethodID = mysql_real_escape_string($_POST["MethodID"]);
$Value = mysql_real_escape_string($_POST["Value"]);

//Create Local and UTC DateTimes
$LocalDate = mysql_real_escape_string($_POST["Date"]);
$LocalTime = mysql_real_escape_string($_POST["Time"]);

$timepieces = explode(":", $LocalTime);

$timepieces[0]; // piece1
$timepieces[1]; // piece2

$newUTCpiece = $timepieces[0] + $UTCOffset;

	if ($newUTCpiece > 24) {

	$NewTimePiece = $newUTCpiece - 24;

//new time for a new day	$newUTCtime = $NewTimePiece . ":" . $timepieces[0];

	$AdjustedDate = explode("-", $LocalDate);

	$DatePiece[0]; // piece1
	$DatePiece[1]; // piece2
	$DatePiece[2]; // piece3

	$NewDay = $DatePiece[2] + 1;

		if ($NewDay > 30) {

		$NewMonth = $DatePiece[1] + 1;

				if ($NewMonth > 12) {

				$NewerYear = $DatePiece[0] + 1;

	$DateTimeUTC = yyyy-mm-dd hh:mm:ss

	} else {

	$DateTimeUTC = $LocalDate . " " . $newUTCpiece . $newtime[1] . ":00";

	$LocalDateTime = $LocalDate . " " . $LocalTime . ":00";
	}

}

//setup names of database and table to use
$db_name ="moss_db";

//connect to server and select database
$connection = @mysql_connect("localhost","wc4moss","pw2testWC") or die(mysql_error());

$db = @mysql_select_db($db_name,$connection)or die(mysql_error());

//add the SourceID's
$sql ="INSERT INTO `datavalues`(`ValueID`, `DataValue`, `ValueAccuracy`, `LocalDateTime`, `UTCOffset`, `DateTimeUTC`, `SiteID`, `VariableID`, `OffsetValue`, `OffsetTypeID`, `CensorCode`, `QualifierID`, `MethodID`, `SourceID`, `SampleID`, `DerivedFromID`, `QualityControlLevelID`) VALUES ($ValueID,$Value,[value-3],$LocalDateTime,[value-5],[value-6],$SiteID,$VariableID,[value-9],[value-10],[value-11],[value-12],$MethodID,$SourceID,[value-15],[value-16],[value-17])";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$num = @mysql_num_rows($result);
	if ($num < 1) {

    $msg = "<P><em2>Sorry, there are no SourceID names.</em></p>";

	} else {

	while ($row = mysql_fetch_array ($result)) {

		$sources = $row["Organization"];

		$option_block .= "<option value=$sources>$sources</option>";

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

		$sites = $row2["SiteName"];

		$option_block2 .= "<option value=$sites>$sites</option>";

		}
	}

//add the Types
$sql3 ="Select * FROM variables";

$result3 = @mysql_query($sql3,$connection)or die(mysql_error());

$num = @mysql_num_rows($result3);
	if ($num < 1) {

    $msg3 = "<P><em2>Sorry, there are no Types.</em></p>";

	} else {

	while ($row3 = mysql_fetch_array ($result3)) {

		$type = $row3["VariableName"];

		$option_block3 .= "<option value=$type>$type</option>";

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

		$method = $row4["MethodDescription"];

		$option_block4 .= "<option value=$method>$method</option>";

		}
	}

?>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Hydrologic System</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />

<script type="text/javascript">
function show_alert()
{
alert("If you do not see your location listed here," + '\n' + "please contact your teacher and ask them" + '\n' + "to add it before entering data.");
}
</script>
</head>

<body background="images/bkgrdimage.png">
<table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning Banner" /></td>
  </tr>
  <tr>
    <td colspan="2" bgcolor="#3c3c3c">&nbsp;</td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><SCRIPT src="A_navbar.js"></SCRIPT></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>Thank you!</h1>
      <p>You have successfully entered the following data values:</p>
      <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><strong>Source:</strong></td>
          <td><strong>Site:</strong></td>
          <td><strong>Type:</strong></td>
          <td><strong>Method:</strong></td>
          <td><strong>LocalDateTime:</strong></td>
          <td><strong>Value:</strong></td>
          </tr>
        <tr>
          <td><?php echo "$SourceID"; ?></td>
          <td><?php echo "$SiteID"; ?></td>
          <td><?php echo "$VariableID"; ?></td>
          <td><?php echo "$MethodID"; ?></td>
          <td><?php echo "$LocalDateTime"; ?></td>
          <td><?php echo "$Value"; ?></td>
          </tr>
      </table>
      <p>NOTE: If this information is incorrect, please contact your Teacher immediately so they can  edit or delete it.</p>
      <h1>Would you like to enter another data value?</h1>
      <table width="425" border="0" cellspacing="0" cellpadding="0">
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
          <td valign="top"><select name="SiteID" id="SiteID"><option value="">Select....</option><?php echo "$option_block2"; ?></select> <a href="#" onClick="show_alert()" border="0"><img src="images/questionmark.png"></a></td>
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
          <td valign="top"><input type="text" name="Date" size=10 maxlength=10 /><span class="em">&nbsp;(Ex: &quot;2012-05-04&quot; for 4 May  2012)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Time:</strong></td>
          <td valign="top"><input type="text" name="Time" size=5 maxlength=5 /><span class="em">&nbsp;(Ex: &quot;13:45&quot; for 1:45 pm)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Value:</strong></td>
          <td valign="top"><input type="text" name="Value" size=10 maxlength=20 /><span class="em">&nbsp;(Must be a number)</span></td>
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
      <p><strong>Hidden values to also add:</strong><br />
<input name="ValueID" type="hidden" value="" />ValueID<br />
<input name="UTCOffset" type="hidden" value="" />UTCOffset<br />
<input name="DateTimeUTC" type="hidden" value="" />DateTimeUTC<br />
<input name="CensorCode" type="hidden" value="" />CensorCode<br />
<input name="QualityControlLevelID" type="hidden" value="0" />QualityControlLevelID</p>
<p><strong>What about these values?</strong><br />
<input name="" type="hidden" value="" />ValueAccuracy<br />
<input name="" type="hidden" value="" />OffsetValue<br />
<input name="" type="hidden" value="" />OffsetTypeID<br />
<input name="" type="hidden" value="" />Qualifier<br />
<input name="" type="hidden" value="" />SampleID<br />
<input name="" type="hidden" value="" />DerivedFromID</FORM></p>
</blockquote>
    <p></p></td>
  </tr>
  <tr>
    <SCRIPT src="footer.js"></SCRIPT>
  </tr>
</table>
</body>
</html>
