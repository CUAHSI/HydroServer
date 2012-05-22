<<<<<<< .mine
<?php

//setup names of database and table to use
$db_name ="moss_db";

//connect to server and select database
$connection = @mysql_connect("localhost","wc4moss","pw2testWC") or die(mysql_error());

$db = @mysql_select_db($db_name,$connection)or die(mysql_error());

//add the SourceID's
$sql ="Select * FROM sources";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$num = @mysql_num_rows($result);
	if ($num < 1) {

    $msg = "<P><em2>Sorry, there are no SourceID names.</em></p>";

	} else {

	while ($row = mysql_fetch_array ($result)) {

		$SourceName = $row["Organization"];
		$SourceID = $row["SourceID"];

		$option_block .= "<option value=$SourceID>$SourceName</option>";

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

?>

<html>
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
    <td width="240" valign="top" bgcolor="#f2e6d6"><SCRIPT src="A_navbar.js"></SCRIPT></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>View Data: Show All By Source</h1>
      <p>Select the source of the data you wish to view....</p>
      <FORM METHOD="POST" ACTION="do_add_data_value.php">
      <table width="425" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td valign="top"><strong>Source:</strong></td>
          <td width="370" valign="top"><select name="SourceID" id="SourceID"><option value="">Select....</option><?php echo "$option_block"; ?></select></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Site:</strong></td>
          <td valign="top"><select name="SiteID" id="SiteID"><option value="">Select....</option><?php echo "$option_block2"; ?></select></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="55" valign="top">&nbsp;</td>
          <td valign="top"><input type="SUBMIT" name="submit" value="View Data" /></td>
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
=======
<?php

//setup names of database and table to use
$db_name ="moss_db";

//connect to server and select database
$connection = @mysql_connect("localhost","wc4moss","pw2testWC") or die(mysql_error());

$db = @mysql_select_db($db_name,$connection)or die(mysql_error());

//add the SourceID's
$sql ="Select * FROM sources";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$num = @mysql_num_rows($result);
	if ($num < 1) {

    $msg = "<P><em2>Sorry, there are no SourceID names.</em></p>";

	} else {

	while ($row = mysql_fetch_array ($result)) {

		$SourceName = $row["Organization"];
		$SourceID = $row["SourceID"];

		$option_block .= "<option value=$SourceID>$SourceName</option>";

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
    <td colspan="2"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning Banner" /></td>
  </tr>
  <tr>
    <td colspan="2" bgcolor="#3c3c3c">&nbsp;</td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><SCRIPT src="A_navbar.js"></SCRIPT></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>View Data: Show All By Source</h1>
      <p>Select the source of the data you wish to view....</p>
      <FORM METHOD="POST" ACTION="do_add_data_value.php">
      <table width="425" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td valign="top"><strong>Source:</strong></td>
          <td width="370" valign="top"><select name="SourceID" id="SourceID"><option value="">Select....</option><?php echo "$option_block"; ?></select></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Site:</strong></td>
          <td valign="top"><select name="SiteID" id="SiteID"><option value="">Select....</option><?php echo "$option_block2"; ?></select></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="55" valign="top">&nbsp;</td>
          <td valign="top"><input type="SUBMIT" name="submit" value="View Data" /></td>
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
>>>>>>> .r67546
