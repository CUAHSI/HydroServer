<?php

//check for required fields
if ((!$_POST['SourceID']) || (!$_POST['SiteID'])) {
	header("Location: vd_by_source.php");
	exit;
}

$ResultSource = mysql_real_escape_string($_POST["SourceID"]);
$ResultSite = mysql_real_escape_string($_POST["SiteID"]);

//setup names of database and table to use
$db_name ="moss_db";

//connect to server and select database
$connection = @mysql_connect("localhost","wc4moss","pw2testWC") or die(mysql_error());

$db = @mysql_select_db($db_name,$connection)or die(mysql_error());

//add the SourceID's
$sql ="Select * FROM datavalues WHERE SourceID='$ResultSource' AND SiteID='$ResultSite' ORDER BY LocalDateTime";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$num = @mysql_num_rows($result);
	if ($num < 1) {

    $msg = "<P><em2>Sorry, there is no data form SourceID.</em></p>";

	} else {

	while ($row = mysql_fetch_array ($result)) {

		$SourceID = $row["Organization"];
		$ValueID = $row["Organization"];
		$DataValue = $row["Organization"];
		$LocalDateTime = $row["Organization"];
		$SiteID = $row["Organization"];
		$VariableID = $row["Organization"];
		$MethodID = $row["Organization"];
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
      <h1>Data from <?php $ResultSite ?></h1>
      <p>&nbsp;</p>
      <table width="650" border="1" cellspacing="0" cellpadding="0">
        <tr>
          <td width="100"><strong>column name</strong></td>
          <td width="95"><strong>column name</strong></td>
          <td width="99"><strong>column name</strong></td>
          <td width="98"><strong>column name</strong></td>
          <td width="103"><strong>column name</strong></td>
          <td width="103"><strong>column name</strong></td>
          <td width="30">&nbsp;</td>
          <td width="25">&nbsp;</td>
        </tr>
        <tr>
          <td>data value</td>
          <td>data value</td>
          <td>data value</td>
          <td>data value</td>
          <td>data value</td>
          <td>data value</td>
          <td><input name="edit5" type="image" value="Edit" src="images/Edit.png" alt="Edit Icon" source="images/Edit.png" /></td>
          <td><input name="delete5" type="image" value="Delete" src="images/Delete.png" alt="Delete Icon" source="images/Delete.png" /></td>
        </tr>
        <tr>
          <td>data value</td>
          <td>data value</td>
          <td>data value</td>
          <td>data value</td>
          <td>data value</td>
          <td>data value</td>
          <td><input name="edit6" type="image" value="Edit" src="images/Edit.png" alt="Edit Icon" source="images/Edit.png" /></td>
          <td><input name="delete6" type="image" value="Delete" src="images/Delete.png" alt="Delete Icon" source="images/Delete.png" /></td>
        </tr>
      </table>
</blockquote>
    <p>&nbsp;</p></td>
  </tr>
  <tr>
    <SCRIPT src="footer.js"></SCRIPT>
  </tr>
</table>
</body>
</html>
