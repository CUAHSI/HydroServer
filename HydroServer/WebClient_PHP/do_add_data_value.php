<?php
//Display the correct navigation or redirect them to the unauthorized user page
if ($_COOKIE[auth] == "admin"){
			$nav ="<SCRIPT src=A_navbar.js></SCRIPT>";
		
		} elseif ($auth == "teacher"){
			$nav ="<SCRIPT src=T_navbar.js></SCRIPT>";
		
		} elseif ($auth == "student"){
			$nav ="<SCRIPT src=S_navbar.js></SCRIPT>";
		} else {
		header("Location: unauthorized.php");
		exit;	
		}

//check for required fields
if ((!$_POST['SourceID']) || (!$_POST['SiteID']) || (!$_POST['VariableID']) || (!$_POST['MethodID']) || (!$_POST['Date']) || (!$_POST['Time']) || (!$_POST['Value'])) {
	header("Location: add_data_value.php");
	exit;
	}

$SourceID = $_POST["SourceID"];
$SiteID = $_POST["SiteID"];
$VariableID = $_POST["VariableID"];
$MethodID = $_POST["MethodID"];
$DataValue = $_POST["Value"];

require_once 'AL_hidden_values.php';

//Create Local and UTC DateTimes
$LocalDate = $_POST["Date"];
$LocalTime = $_POST["Time"];

$timepieces = explode(":", $LocalTime);
$timepieces[0]; // piece1 (hours)
$timepieces[1]; // piece2 (minutes)

// the UTC Offset time is 7 hours in this location
$newUTCpiece = ($timepieces[0] + $UTCOffset2); 

	// this checks to see if adding the hours puts us into the next day period
	if ($newUTCpiece > 24) {

		$NewTimePiece = ($newUTCpiece - 24);
	
		//this creates the complete new time for a new day
		$newUTCtime = "0" . $NewTimePiece . ":" . $timepieces[1]; 

		$DatePiece = explode("-", $LocalDate);
		$DP0 = $DatePiece[0]; // piece1 (year as YYYY)
		$DP1 = $DatePiece[1]; // piece2 (month as MM)
		$DP2 = $DatePiece[2]; // piece3 (day as DD)

		// Adds one day to the date
		$NewDay = $DP2 + 1; 
		
	// Checks to see if the day puts it into the next month during a non-leap year
	if ($NewDay > 28 && $DP1 == 02 && $DP0 == 2013 || 2014 || 2015 || 2017 || 2018 || 2019 || 2021 || 2022 || 2023 || 2025 || 2026 || 2027 || 2029 || 2030 || 2031 || 2033 || 2034 || 2035 || 2037 || 2038 || 2039 || 2041 || 2042 || 2043 || 2045 || 2046 || 2047 || 2049 || 2050 || 2051 || 2053 || 2054 || 2055 || 2057 || 2058 || 2059 || 2061 || 2062 || 2063){  
	
	// Bumps the month to the next one and makes the day 1
	$NewYear = $DP0;
	$NewMonth = $DP1 + 1;
	$NewDay = 01;

		// Checks to see if the month puts it into the next year
		if ($NewMonth > 12){

			$NewYear = $DP0 + 1;
			$NewMonth = 01;
			$NewDay = 01;
			}
		// then build this yyyy-mm-dd hh:mm:ss
		$DateTimeUTC = $NewYear . "-" . $NewMonth . "-" . $NewDay . " " . $newUTCtime . ":00";
		}

	// Checks to see if the day puts it into the next month during a leap year
	elseif ($NewDay > 29 && $DP1 == 02 && $DP0 == 2012 || 2016 || 2020 || 2024 || 2028 || 2032 || 2036 || 2040 || 2044 || 2048 || 2052 || 2056 || 2060 || 2064){ 

	// Bumps the month to the next one and makes the day 1
	$NewYear = $DP0;
	$NewMonth = $DP1 + 1;
	$NewDay = 01;

		// Checks to see if the month puts it into the next year
		if ($NewMonth > 12) {

			$NewYear = $DP0 + 1;
			$NewMonth = 01;
			$NewDay = 01;
			}
		// then build this yyyy-mm-dd hh:mm:ss
		$DateTimeUTC = $NewYear . "-" . $NewMonth . "-" . $NewDay . " " . $newUTCtime . ":00";
		}
		
	// Checks to see if the day puts it into the next month
	elseif ($NewDay > 30 && $DP1 == 04 || 06 || 09 || 11){ 

	// Bumps the month to the next one and makes the day 1
	$NewYear = $DP0;
	$NewMonth = $DP1 + 1;
	$NewDay = 01;

		// Checks to see if the month puts it into the next year
		if ($NewMonth > 12) {

			$NewYear = $DP0 + 1;
			$NewMonth = 01;
			$NewDay = 01;
			}
		// then build this yyyy-mm-dd hh:mm:ss
		$DateTimeUTC = $NewYear . "-" . $NewMonth . "-" . $NewDay . " " . $newUTCtime . ":00";
		}

	// Checks to see if the day puts it into the next month
	elseif ($NewDay > 31 && $DP1 == 01 || 03 || 05 || 07 || 08 || 10 || 12){

	// Bumps the month to the next one and makes the day 1
	$NewYear = $DP0;
	$temp = $DP1 + 1;
		if ($temp < 10) {
			$NewMonth = "0" . $temp;
			}
			else {
				$NewMonth = $temp;
				}
	$NewDay = 01;

		// Checks to see if the month puts it into the next year
		if ($NewMonth > 12) {
			$NewYear = $DP0 + 1;
			$NewMonth = 01;
			$NewDay = 01;
			}
		// then build this yyyy-mm-dd hh:mm:ss
		$DateTimeUTC = $NewYear . "-" . $NewMonth . "-" . $NewDay . " " . $newUTCtime . ":00";
		} 
	
	} else {
	$DateTimeUTC = $LocalDate . " " . $newUTCpiece . ":" . $timepieces[1] . ":00";
	}
$LocalDateTime = $LocalDate . " " . $LocalTime . ":00";
	
//connect to server and select database
require_once 'database_connection.php';

//add the all variables to the datavalues table
$sql7 ="INSERT INTO `datavalues`(`ValueID`, `DataValue`, `ValueAccuracy`, `LocalDateTime`, `UTCOffset`, `DateTimeUTC`, `SiteID`, `VariableID`, `OffsetValue`, `OffsetTypeID`, `CensorCode`, `QualifierID`, `MethodID`, `SourceID`, `SampleID`, `DerivedFromID`, `QualityControlLevelID`) VALUES ('$ValueID', '$DataValue', $ValueAccuracy, '$LocalDateTime', '$UTCOffset', '$DateTimeUTC', '$SiteID', '$VariableID', $OffsetValue, $OffsetTypeID, '$CensorCode', '$QualifierID', '$MethodID', '$SourceID', $SampleID, '$DerivedFromID', '$QualityControlLevelID')";

$result7 = @mysql_query($sql7,$connection)or die(mysql_error());

//get a good message for display upon success
if ($result7) {

	$msg7 ="<h1>Thank you!</h1><p class=em2>You have successfully entered data values.</p>";
	}

//Setup the rest of hte page from here down in case they want to submit another data value

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
$sql3 ="Select * FROM variables";

$result3 = @mysql_query($sql3,$connection)or die(mysql_error());

$num = @mysql_num_rows($result3);
	if ($num < 1) {

    $msg3 = "<P><em2>Sorry, there are no Types.</em></p>";

	} else {

	while ($row3 = mysql_fetch_array ($result3)) {

		$typeid = $row3["VariableID"];
		$typename = $row3["VariableName"];

		$option_block3 .= "<option value=$typeid>$typename</option>";

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
function show_alert()
{
alert("If you do not see your location listed here," + '\n' + "please contact your teacher and ask them" + '\n' + "to add it before entering data.");
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
    <td width="240" valign="top" bgcolor="#f2e6d6"><SCRIPT src="A_navbar.js"></SCRIPT></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <?php echo "$msg7"; ?>
      <h1>Would you like to enter another data value?</h1>
      <FORM METHOD="POST" ACTION="do_add_data_value.php">
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
          <td valign="top"><input type="text" name="Time" size=5 maxlength=5 /><span class="em">&nbsp;(Ex: &quot;13:45&quot; for 1:45 pm or &quot;06:30&quot; for 6:30 am)</span></td>
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
      </table></FORM>
      <p>&nbsp;</p>
    </blockquote></td>
  </tr>
  <tr>
    <SCRIPT src="footer.js"></SCRIPT>
  </tr>
</table>
</body>
</html>
