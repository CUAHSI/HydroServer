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
      <FORM METHOD="POST" ACTION="do_add_data_value.php" name="addvalue">
        <table width="600" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="75" valign="top"><strong>Source:</strong></td>
            <td width="225" valign="top"><select name="SourceID" id="SourceID">
              <option value="">Select....</option>
              <?php echo "$option_block"; ?></select></td>
            <td width="300" valign="top">&nbsp;</td>
          </tr>
          <tr>
            <td width="75" valign="top">&nbsp;</td>
            <td width="225" valign="top">&nbsp;</td>
            <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top"><strong>Site Name:</strong></td>
          <td width="225" valign="top"><input type="text" id="SiteName" name="SiteName" size=20 maxlength=20 onBlur="return validateNum()"/></td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top">&nbsp;</td>
          <td width="225" valign="top">&nbsp;</td>
          <td width="300" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="75" valign="top"><strong>Site Type:</strong></td>
          <td width="225" valign="top"><select name="MethodID2" id="MethodID2">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td width="300" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="75" valign="top">&nbsp;</td>
          <td width="225" valign="top">&nbsp;</td>
          <td width="300" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="75" valign="top"><strong>Latitude:</strong></td>
          <td width="225" valign="top"><input type="text" id="Latitude" name="Latitude" size=20 maxlength=20 onBlur="return validateNum()"/> <a href="#" onClick="show_answer()" border="0"><img src="images/questionmark.png"></a></td>
          <td width="300" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="75" valign="top">&nbsp;</td>
          <td width="225" valign="top">&nbsp;</td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top"><strong>Longitude:</strong></td>
          <td width="225" valign="top"><input type="text" id="Longitude" name="Longitude" size=20 maxlength=20 onBlur="return validateNum()"/></td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top">&nbsp;</td>
          <td width="225" valign="top">&nbsp;</td>
          <td width="300" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="75" valign="top"><strong>Elevation:</strong></td>
          <td width="225" valign="top"><input type="text" id="Elevation" name="Elevation" size=20 maxlength=20 onBlur="return validateNum()"/></td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top">&nbsp;</td>
          <td width="225" valign="top">&nbsp;</td>
          <td width="300" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="75" valign="top"><strong>State:</strong></td>
          <td width="225" valign="top"><select name="State" id="State">
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
          <td width="300" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="75" valign="top">&nbsp;</td>
          <td width="225" valign="top">&nbsp;</td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top"><strong>County:</strong></td>
          <td width="225" valign="top"><input type="text" id="County" name="County"></td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top">&nbsp;</td>
          <td width="225" valign="top">&nbsp;</td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top"><strong>Comments:</strong></td>
          <td width="225" valign="top"><input type="text" id="value" name="value" size=20 maxlength=20 onBlur="return validateNum()"/></td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top">&nbsp;</td>
          <td width="225" valign="top">&nbsp;</td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="75" valign="top">&nbsp;</td>
          <td width="225" valign="top"><input type="SUBMIT" name="submit" value="Submit Your Site" /></td>
          <td width="300" valign="top">&nbsp;</td>
          </tr>
      </table></FORM>
      <p>******Need hidden values added too:<br>
      Site ID - Next auto<br>
        Site Code - Create based on Source selected<br>
        LatLongDatumID<br>
        VerticalDatum - #<br>
        LocalX - NULL<br>
        LocalY - NULL<br>
        LocalProjectionID - NULL<br>
        PosAccuracy_m - NULL</p>
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
