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
$sql4 ="Select * FROM spatialreferences";

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

<!-- JQuery JS -->
<script type="text/javascript" src="js/jquery-1.2.6.min.js"></script>

<!-- Drop Down JS -->
<script type="text/javascript" src="js/drop_down.js"></script>

<!-- Preload Images -->
<SCRIPT language="JavaScript">
<!--
pic1 = new Image(16, 16); 
pic1.src="images/loader.gif";
//-->
</SCRIPT>

<STYLE TYPE="text/css">
<!--
#county_drop_down, #no_county_drop_down, #loading_county_drop_down
{
display: none;
}
--> 
</STYLE>

<!-- Creating the Site Code automatically -->
<script type="text/javascript">

/*!
 * Site Code Creation script by Rohit Khattar and Rex Burch
 */

function CreateCode(){
var sid = document.all("SourceID").value;
	alert(sid);
	location('getsourcename.php?SourceID='+sid,'_self');
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
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br /><?php echo "$msg"; ?>
      <h1>Add a new Site to the database    </h1>
      <p>&nbsp;</p><FORM METHOD="POST" ACTION="do_add_site.php" name="addsite">
      <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="93"><strong>Source:</strong></td>
          <td width="557"><select name="SourceID" id="SourceID" onChange="CreateCode(this.value)">
            <option value="">Select....</option>
            <?php echo "$option_block"; ?>
          </select></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><strong>Site Name:</strong></td>
          <td><input type="text" id="SiteName" name="SiteName" size=20 maxlength=20"/>
&nbsp;<span class="em">(Ex: Boulder Creek at Jug Mountain Ranch)</span></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><strong>Site Code:</strong></td>
          <td><input type="text" id="SiteCode" name="SiteCode" size=20 maxlength=20"/>
&nbsp;<span class="em">(You may adjust this if needed)</span></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><strong>Site Type:</strong></td>
          <td><select name="SiteType" id="SiteType">
            <option value="">Select....</option>
            <?php echo "$option_block2"; ?>
          </select></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
      </table>
        <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td colspan="4" valign="top"><strong>You may either enter the latitude/longitude manually or simply select the location on the map.</strong></td>
        </tr>
        <tr>
          <td width="100" valign="top">&nbsp;</td>
          <td width="145" valign="top">&nbsp;</td>
          <td width="96" valign="top">&nbsp;</td>
          <td width="309" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="100" align="right" valign="top"><strong>Latitude:&nbsp;</strong></td>
          <td width="145" valign="top"><input type="text" id="Latitude" name="Latitude" size=20 maxlength=20/></td>
          <td width="96" align="right" valign="top"><strong>Longitude:&nbsp;</strong></td>
          <td width="309" valign="top"><input type="text" id="Longitude" name="Longitude" size=20 maxlength=20/></td>
          </tr>
        <tr>
          <td width="100" valign="top">&nbsp;</td>
          <td width="145" valign="top">&nbsp;</td>
          <td width="96" valign="top">&nbsp;</td>
          <td width="309" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td colspan="4" valign="top"><center>
            <p><img src="images/google_map.jpeg" width="552" height="514" alt="google map"></p>
          </center></td>
        </tr>
      </table><table width="600" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="130">&nbsp;</td>
    <td width="520">&nbsp;</td>
  </tr>
  <tr>
    <td><strong>Elevation:</strong></td>
    <td><input type="text" id="Elevation" name="Elevation" size=20 maxlength=20/></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><strong>State:</strong></td>
    <td><select name="state" id="state">
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
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><strong>County:</strong></td>
    <td><div id="county_drop_down"><select id="county" name="county"><option value="">County...</option></select></div>
	 <span id="loading_county_drop_down"><img src="images/loader.gif" width="16" height="16" align="absmiddle">&nbsp;Select state first...</span>
	 <div id="no_county_drop_down">This state has no counties.</div></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><strong>Vertical Datum:</strong></td>
    <td><select name="VerticalDatum" id="VerticalDatum">
      <option value="">Select....</option>
      <?php echo "$option_block3"; ?>
    </select></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><strong>Spatial Reference:</strong></td>
    <td><select name="LatLongDatumID" id="LatLongDatumID">
      <option value="">Select....</option>
      <?php echo "$option_block4"; ?>
    </select></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><strong>Comments:</strong></td>
    <td><input type="text" id="value" name="value" size=50 maxlength=500/>
      <span class="em">&nbsp;(Optional)</span></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><input type="SUBMIT" name="submit" value="Submit Your Site" /></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
      </table>
</FORM>
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
