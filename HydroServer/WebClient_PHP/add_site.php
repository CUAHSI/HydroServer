<?php
//check authority to be here
require_once 'authorization_check.php';

//connect to server and select database
require_once 'database_connection.php';

//add the SourceID's options
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

//add the SiteType options
$sql2 ="Select * FROM sitetypecv";

$result2 = @mysql_query($sql2,$connection)or die(mysql_error());

$num2 = @mysql_num_rows($result2);
	if ($num2 < 1) {

    $msg = "<P><em2>Sorry, there are no Site Types.</em></p>";

	} else {

	while ($row2 = mysql_fetch_array ($result2)) {

		$sitetype = $row2["Term"];

		$option_block2 .= "<option value=$sitetype>$sitetype</option>";

		}
	}

//add the VerticalDatum options
$sql3 ="Select * FROM verticaldatumcv";

$result3 = @mysql_query($sql3,$connection)or die(mysql_error());

$num3 = @mysql_num_rows($result3);
	if ($num3 < 1) {

    $msg = "<P><em2>Sorry, there are no Vertical Datums.</em></p>";

	} else {

	while ($row3 = mysql_fetch_array ($result3)) {

		$vd = $row3["Term"];

		$option_block3 .= "<option value=$vd>$vd</option>";

		}
	}

//add the LatLongDatumID options
$sql4 ="Select * FROM spatialreferences WHERE SRSID !='2914'";

$result4 = @mysql_query($sql4,$connection)or die(mysql_error());

$num4 = @mysql_num_rows($result4);
	if ($num4 < 1) {

    $msg = "<P><em2>Sorry, there are no Vertical Datums.</em></p>";

	} else {

	while ($row4 = mysql_fetch_array ($result4)) {

		$srid = $row4["SpatialReferenceID"];
		$srsname = $row4["SRSName"];

		$option_block4 .= "<option value=$srid>$srsname</option>";

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
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br /><?php echo "$msg"; ?>
      <h1>Add a new Site to the database    </h1>
      <p>&nbsp;</p>
      <FORM METHOD="POST" ACTION="do_add_data_value.php" name="addvalue">
        <table width="650" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="125" valign="top"><strong>Source:</strong></td>
            <td colspan="2" valign="top"><select name="SourceID" id="SourceID">
              <option value="">Select....</option>
              <?php echo "$option_block"; ?></select></td>
            </tr>
          <tr>
            <td width="125" valign="top">&nbsp;</td>
            <td width="223" valign="top">&nbsp;</td>
            <td width="302" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="125" valign="top"><strong>Site Name:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="SiteName" name="SiteName" size=20 maxlength=20"/>&nbsp;<span class="em">(Ex: Boulder Creek at Jug Mountain Ranch)</span></td>
          </tr>
        <tr>
          <td width="125" valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          <td width="302" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Site Code:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="SiteCode" name="SiteCode" size=20 maxlength=20"/>
            &nbsp;<span class="em">(You may adjust this if needed)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          <td width="302" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="125" valign="top"><strong>Site Type:</strong></td>
          <td colspan="2" valign="top"><select name="SiteType" id="SiteType">
            <option value="">Select....</option>
            <?php echo "$option_block2"; ?>
          </select></td>
          </tr>
        <tr>
          <td width="125" valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          <td width="302" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="3" valign="top">You may either enter the latitude and longitude manually below or simply select the location on the map.</td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          <td width="302" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="125" valign="top"><strong>Latitude:</strong></td>
          <td width="223" valign="top"><input type="text" id="Latitude" name="Latitude" size=20 maxlength=20/></td>
          <td width="302" rowspan="13" valign="top"><img src="WebClient_PHP/images/google_map.jpg" width="300" height="235" alt="google map"></td>
        </tr>
        <tr>
          <td width="125" valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="125" valign="top"><strong>Longitude:</strong></td>
          <td width="223" valign="top"><input type="text" id="Longitude" name="Longitude" size=20 maxlength=20/></td>
          </tr>
        <tr>
          <td width="125" valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td valign="top"><strong>Vertical Datum:</strong></td>
          <td width="223" valign="top"><select name="VerticalDatum" id="VerticalDatum">
            <option value="">Select....</option>
            <?php echo "$option_block3"; ?>
          </select></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Spatial Reference:</strong></td>
          <td width="223" valign="top"><select name="LatLongDatumID" id="LatLongDatumID">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="125" valign="top"><strong>Elevation:</strong></td>
          <td width="223" valign="top"><input type="text" id="Elevation" name="Elevation" size=20 maxlength=20/></td>
          </tr>
        <tr>
          <td width="125" valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="125" valign="top"><strong>State:</strong></td>
          <td width="223" valign="top"><select name="State" id="State">
            <option value="">Select....</option>
            <option value="AL">Alabama</option>
            <option value="AK">Alaska</option>
            <option value="AZ">Arizona</option>
            <option value="AR">Arkansas</option>
            <option value="CA">California</option>
            <option value="CO">Colorado</option>
            <option value="CT">Connecticut</option>
            <option value="DE">Delaware</option>
            <option value="DC">District of Columbia</option>
            <option value="FL">Florida</option>
            <option value="GA">Georgia</option>
            <option value="HI">Hawaii</option>
            <option value="ID">Idaho</option>
            <option value="IL">Illinois</option>
            <option value="IN">Indiana</option>
            <option value="IA">Iowa</option>
            <option value="KS">Kansas</option>
            <option value="KY">Kentucky</option>
            <option value="LA">Louisiana</option>
            <option value="ME">Maine</option>
            <option value="MD">Maryland</option>
            <option value="MA">Massachusetts</option>
            <option value="MI">Michigan</option>
            <option value="MN">Minnesota</option>
            <option value="MS">Mississippi</option>
            <option value="MO">Missouri</option>
            <option value="MT">Montana</option>
            <option value="NE">Nebraska</option>
            <option value="NV">Nevada</option>
            <option value="NH">New Hampshire</option>
            <option value="NJ">New Jersey</option>
            <option value="NM">New Mexico</option>
            <option value="NY">New York</option>
            <option value="NC">North Carolina</option>
            <option value="ND">North Dakota</option>
            <option value="OH">Ohio</option>
            <option value="OK">Oklahoma</option>
            <option value="OR">Oregon</option>
            <option value="PA">Pennsylvania</option>
            <option value="RI">Rhode Island</option>
            <option value="SC">South Carolina</option>
            <option value="SD">South Dakota</option>
            <option value="TN">Tennessee</option>
            <option value="TX">Texas</option>
            <option value="UT">Utah</option>
            <option value="VT">Vermont</option>
            <option value="VA">Virginia</option>
            <option value="WA">Washington</option>
            <option value="WV">West Virginia</option>
            <option value="WI">Wisconsin</option>
            <option value="WY">Wyoming</option>
          </select></td>
          </tr>
        <tr>
          <td width="125" valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="125" valign="top"><strong>County:</strong></td>
          <td width="223" valign="top"><input type="text" id="County" name="County"></td>
          </tr>
        <tr>
          <td width="125" valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          <td width="302" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="125" valign="top"><strong>Comments:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="value" name="value" size=20 maxlength=20/> 
            <span class="em">(Optional)</span></td>
          </tr>
        <tr>
          <td width="125" valign="top">&nbsp;</td>
          <td width="223" valign="top">&nbsp;</td>
          <td width="302" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td colspan="3" valign="top"><center><input type="SUBMIT" name="submit" value="Submit Your Site" /></center></td>
          </tr>
      </table></FORM>
      <p>******Need hidden values added too</p>
    </blockquote>
    <p></p></td>
  </tr>
  <tr>
    <script src="footer.js"></script>
  </tr>
</table>
</body>
</html>
