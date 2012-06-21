<?php
//check authority to be here
require_once 'authorization_check.php';

//connect to server and select database
require_once 'database_connection.php';
require_once 'main_config.php';

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

if ($sourcename==$default_source)
{
	
	
	$option_block .= "<option selected='selected' value=$sourceid>$sourcename</option>";
}
else
{
		$option_block .= "<option value=$sourceid>$sourcename</option>";
}



		
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
if ($vd==$default_datum)
{
	
	$option_block3 .= "<option selected='selected' value=$vd>$vd</option>";
}
else
{
		$option_block3 .= "<option value=$vd>$vd</option>";
}
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


if ($srsname==$default_spatial)
{
	
	$option_block4 .= "<option selected='selected' value=$srid>$srsname</option>";
}
else
{
		$option_block4 .= "<option value=$srid>$srsname</option>";
}



		

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
alert("The current version of this software" + '\n' + "does not autmatically select the State and County. " + '\n' + "Please select them mannually.");
}
</script>
<!-- JQuery JS -->
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>

<!-- Drop Down JS -->
<script type="text/javascript" src="js/drop_down.js"></script>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyC3d042tZnUAA8256hCC2Y6QeTSREaxrY0&sensor=true"></script>

<!-- Preload Images -->
<SCRIPT language="JavaScript">
<!--
pic1 = new Image(16, 16); 
pic1.src="images/loader.gif";
//-->
</SCRIPT>

<script type="text/javascript">
     var map;
	 var marker=null;
	 var elevator;
	 
function initialize() {
	GetSourceName();
	var myLatlng = new google.maps.LatLng(43.52764,-112.04951);
	

  
  var myOptions = {
    zoom: 14,
    center: myLatlng,
    mapTypeId: google.maps.MapTypeId.ROADMAP,
	disableDoubleClickZoom : true
  }
  map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
elevator = new google.maps.ElevationService();
  google.maps.event.addListener(map, 'dblclick', function(event) {
	 
	// $('#Latitude').value('askjhsdf');

    placeMarker(event.latLng);
  });
}

 if(navigator.geolocation) {
    browserSupportFlag = true;
    navigator.geolocation.getCurrentPosition(function(position) {
      initialLocation = new google.maps.LatLng(position.coords.latitude,position.coords.longitude);
	   
	    var geocoder = new google.maps.Geocoder();
     geocoder.geocode({location: initialLocation}, function(results, status) {
       if (status == google.maps.GeocoderStatus.OK) {
		 
		  map.setCenter(results[0].geometry.location);  
		   
       
		;
       } else {
         alert(address + ' not found');
       }
     });
  
	   
	   
    }, function() {
      handleNoGeolocation(browserSupportFlag);
    });
  }
  // Browser doesn't support Geolocation
   else {
    browserSupportFlag = false;
    handleNoGeolocation(browserSupportFlag);
  }
  


function placeMarker(location) {
 
 
 if(marker==null)
 {
  marker = new google.maps.Marker({
      position: location,
      map: map,
	  draggable: true
  });
  
  google.maps.event.addListener(marker, 'dragend', function(event) {
	 
//Again Update the Latitude longitude values
update(event.latLng)
//    placeMarker(event.latLng);
  });
  
  
  //Update values in the 
  update(location)
  
 }
 else
 {
	marker.setPosition(location); 
//Update Values into the form	
update(location)

 }
  map.setCenter(location);
}

function update(location)
{
	
	
	$("#Latitude").val(parseFloat(location.lat()).toFixed(5));
	$("#Longitude").val(parseFloat(location.lng()).toFixed(5));

//Update Elevation




  var locations = [];
  locations.push(location);

  // Create a LocationElevationRequest object using the array's one value
  var positionalRequest = {
    'locations': locations
  }

  // Initiate the location request
  elevator.getElevationForLocations(positionalRequest, function(results, status) {
    if (status == google.maps.ElevationStatus.OK) {

      // Retrieve the first result
      if (results[0]) {

        // Open an info window indicating the elevation at the clicked position
        $("#Elevation").val(parseFloat(results[0].elevation).toFixed(1));
	
        
      } else {
        alert("No results found");
      }
    } else {
      alert("Elevation service failed due to: " + status);
    }
  });

	

// Now to update the state
var latlng1 = new google.maps.LatLng(location.lat(), location.lng());
var geocoder = new google.maps.Geocoder();
geocoder.geocode({'latLng': latlng1}, function(results, status) {
      if (status == google.maps.GeocoderStatus.OK) {
        if (results[0]) {
			
			$("#locationtext").html("Your selected location according to us is: " + results[0].formatted_address + ". Please select the state and county accordingly.");
			
        
          
        }
      } else {
        alert("Geocoder failed due to: " + status);
      }
    });



}
 
//Function to run on form submission to implement a validation and then run an ajax request to post the data to the server and display the message that the site has been added successfully



 
    </script>

<STYLE TYPE="text/css">
<!--
#county_drop_down, #no_county_drop_down, #loading_county_drop_down
{
display: none;
}
--> 
</STYLE>

<!-- Creating the Site Code automatically -->
<script type="text/javascript" src="js/create_site_code.js"></script>

</head>

<body background="images/bkgrdimage.jpg" onLoad="initialize()">
<table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning Banner" /></td>
  </tr>
  <tr>
    <td colspan="2" align="right" valign="middle" bgcolor="#3c3c3c"><script src="js/header.js"></script></td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br /><?php //echo "$msg"; ?>
      <h1>Add a new Site to the database    </h1>
      <p>&nbsp;</p><FORM METHOD="POST" ACTION="" name="addsite" id="addsite">
      <table width="650" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="93"><strong>Source:</strong></td>
          <td width="557"><select name="SourceID" id="SourceID" onChange="GetSourceName()">
            <option value="-1">Select....</option>
            <?php echo "$option_block"; ?>
          </select></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><strong>Site Name:</strong></td>
          <td><input type="text" id="SiteName" name="SiteName" size=20 maxlength="200" onKeyUp="GetSiteName()"/>
&nbsp;<span class="em">(Ex: Boulder Creek at Jug Mountain Ranch)</span></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><strong>Site Code:</strong></td>
          <td><input type="text" id="SiteCode" name="SiteCode" size=20 maxlength="200"/>
&nbsp;<span class="em">(You may adjust this if needed)</span></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><strong>Site Type:</strong></td>
          <td><select name="SiteType" id="SiteType">
            <option value="-1">Select....</option>
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
        <table width="650" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td colspan="4" valign="top"><strong>You may either enter the latitude/longitude manually or simply double click the location on the map. Once the marker is placed on the map, you may then click and drag it to the exact location you desire to adjust the results to be more accurate.</strong></td>
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
          <td colspan="4" valign="top"><div id="map_canvas" style="width:650px; height:450px"></div></td>
        </tr>
      </table><table width="650" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="130">&nbsp;</td>
    <td width="520">&nbsp;</td>
  </tr>
  <tr>
    <td><strong>Elevation:</strong></td>
    <td><input type="text" id="Elevation" name="Elevation" size=20 maxlength=20/>
    meter</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="2"><div id="locationtext"></div></td>
    </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><strong>State:</strong></td>
    <td><select name="state" id="state">
      <option value="-1">Select....</option>
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
    </select>&nbsp;<a href="#" onClick="show_answer()" border="0"><img src="images/questionmark.png" border="0"></a></td>
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
      <option value="-1">Select....</option>
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
      <option value="-1">Select....</option>
      <?php echo "$option_block4"; ?>
    </select></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><strong>Comments:</strong></td>
    <td><input type="text" id="com" name="value" size=50 maxlength=500/>
      <span class="em">&nbsp;(Optional)</span></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><input type="SUBMIT" name="submit" value="Submit Your Site" class="button"/></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
      </table>
</FORM>
     
    </blockquote>
    <p></p></td>
  </tr>
  <tr>
    <script src="js/footer.js"></script>
  </tr>
</table>

<script>

    $("form").submit(function() {
      //Validate all fields
	  
if(($("#SourceID option:selected").val())==-1)
{
alert("Please select a Source. If you do not find it in the list, please visit the 'Add a new source' page");
return false;
}

if(($("#SiteName").val())=="")
{
alert("Please enter a name for the site.");
return false;
}

if(($("#SiteCode").val())=="")
{
alert("Please enter a code for the site.");
return false;
}

if(($("#SiteType option:selected").val())==-1)
{
alert("Please select a Site Type.");
return false;
}	  

if(($("#Latitude").val())=="")
{
alert("Please enter the latitude for the site or select a point from the map");
return false;
}

if(($("#Longitude").val())=="")
{
alert("Please enter the longitude for the site or select a point from the map");
return false;
}

if(($("#Elevation").val())=="")
{
alert("Please enter the elevation for the site or select a point from the map");
return false;
}


var floatRegex = '[-+]?([0-9]*\.[0-9]+|[0-9]+)';
var myInt = $("#Latitude").val().match(floatRegex);


if(myInt==null)
{alert("Invalid characters present in latitude. Please correct it.");
      return false;
}


if(myInt[0]!=$("#Latitude").val())
{alert("Invalid characters present in latitude. Please correct it.");
      return false;
}


myInt = $("#Longitude").val().match(floatRegex);


if(myInt==null)
{alert("Invalid characters present in longitude. Please correct it.");
      return false;
}


if(myInt[0]!=$("#Longitude").val())
{alert("Invalid characters present in longitude. Please correct it.");
      return false;
}

myInt = $("#Elevation").val().match(floatRegex);


if(myInt==null)
{alert("Invalid characters present in elevation. Please correct it.");
      return false;
}


if(myInt[0]!=$("#Elevation").val())
{alert("Invalid characters present in elevation. Please correct it.");
      return false;
}

if(($("#state option:selected").val())==-1)
{
alert("Please select a state.");
return false;
}
if(($("#VerticalDatum option:selected").val())==-1)
{
alert("Please select a vertical datum.");
return false;
}
if(($("#LatLongDatumID option:selected").val())==-1)
{
alert("Please select a spatial reference.");
return false;
}

//All Validation Checks completed.Now add data to the database

$.ajax({
  type: "POST",
  url: "do_add_site.php?sc="+$("#SiteCode").val()+"&sn="+$("#SiteName").val()+"&lat="+$("#Latitude").val()+"&lng="+$("#Longitude").val()+"&llid="+$("#LatLongDatumID option:selected").val()+"&type="+$("#SiteType option:selected").text()+"&elev="+$("#Elevation").val()+"&datum="+$("#VerticalDatum option:selected").text()+"&state="+$("#state option:selected").text()+"&county="+$("#county option:selected").text()+"&com="+$("#com").val()+"&source="+$("#SourceID").val()
}).done(function( msg ) {
  if(msg==1)
  {
	  alert("Site successfully added");
	  window.location.href = "add_site.php";
	  return true;
  }
  else
  {
  alert("Error in database configuration");
  return false;
  }
  
});


      return false;
    });
</script>


</body>
</html>
