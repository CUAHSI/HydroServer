<?php

//Enable Cookies Once Dev is Complete

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
		




?>

<html>
<head>
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />
<script src="http://maps.google.com/maps/api/js?sensor=true"
            type="text/javascript"></script>
    
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"
            type="text/javascript"></script>
            
            
	<script type="text/javascript">
    //<![CDATA[

//Populate the Javascript Array

var initialLocation;
var siberia = new google.maps.LatLng(60, 105);
var newyork = new google.maps.LatLng(40.69847032728747, -73.9514422416687);
var browserSupportFlag =  new Boolean();

    var map;
    var markers = [];
    var infoWindow;
    var locationSelect;
	var xml="-1";	

   function load() {
 
      map = new google.maps.Map(document.getElementById("map"), {
        center: new google.maps.LatLng(44, -160),
        zoom: 4,
        mapTypeId: 'roadmap',
        mapTypeControlOptions: {style: google.maps.MapTypeControlStyle.DROPDOWN_MENU}
      });
      infoWindow = new google.maps.InfoWindow();

      locationSelect = document.getElementById("locationSelect");
      locationSelect.onchange = function() {
        var markerNum = locationSelect.options[locationSelect.selectedIndex].value;
        if (markerNum != "none"){
          google.maps.event.trigger(markers[markerNum], 'click');
        }
      };
	  
	  loadall();
   }

function track_loc(){
  // Try W3C Geolocation (Preferred)
  if(navigator.geolocation) {
    browserSupportFlag = true;
    navigator.geolocation.getCurrentPosition(function(position) {
      initialLocation = new google.maps.LatLng(position.coords.latitude,position.coords.longitude);
	   
	    var geocoder = new google.maps.Geocoder();
     geocoder.geocode({location: initialLocation}, function(results, status) {
       if (status == google.maps.GeocoderStatus.OK) {
        searchLocationsNear2(results[0].geometry.location);
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
  
 
  
 // searchLocations2(initialLocation);
}

function loadall()
{
	clearLocations();
	 var searchUrl = 'db_display_all.php';
  downloadUrl(searchUrl, function(data) {
  var xml = parseXml(data);
	 var markerNodes = xml.documentElement.getElementsByTagName("marker");
  var bounds = new google.maps.LatLngBounds();
   for (var i = 0; i < markerNodes.length; i++) {
    var name = markerNodes[i].getAttribute("name");
    var address = markerNodes[i].getAttribute("address");
    var distance = parseFloat(markerNodes[i].getAttribute("distance"));
    var latlng = new google.maps.LatLng(
        parseFloat(markerNodes[i].getAttribute("lat")),
        parseFloat(markerNodes[i].getAttribute("lng")));

    createOption(name, distance, i);
    createMarker(latlng, name, address);
    bounds.extend(latlng);
  }
  map.fitBounds(bounds);
	 });
	
	}
	


   function searchLocations() {
     var address = document.getElementById("addressInput").value;
     var geocoder = new google.maps.Geocoder();
     geocoder.geocode({address: address}, function(results, status) {
       if (status == google.maps.GeocoderStatus.OK) {
        searchLocationsNear(results[0].geometry.location);
       } else {
         alert(address + ' not found');
       }
     });
   }
   

   function clearLocations() {
     infoWindow.close();
     for (var i = 0; i < markers.length; i++) {
       markers[i].setMap(null);
     }
     markers.length = 0;

     locationSelect.innerHTML = "";
     var option = document.createElement("option");
     option.value = "none";
     option.innerHTML = "See all results:";
     locationSelect.appendChild(option);
   }

   function searchLocationsNear(center) {
     clearLocations(); 

     var radius = document.getElementById('radiusSelect').value;
     var searchUrl = 'db_search.php?lat=' + center.lat() + '&lng=' + center.lng() + '&radius=' + radius;
     downloadUrl(searchUrl, function(data) {
       var xml2 = parseXml(data);
	   xml=xml2;
       var markerNodes = xml2.documentElement.getElementsByTagName("marker");
       var bounds = new google.maps.LatLngBounds();
       
	   if (markerNodes.length==0)
	   {alert("No Sites Found. Please Alter Search Terms");}
	   for (var i = 0; i < markerNodes.length; i++) {
         var name = markerNodes[i].getAttribute("name");
         var address = markerNodes[i].getAttribute("address");
         var distance = parseFloat(markerNodes[i].getAttribute("distance"));
         var latlng = new google.maps.LatLng(
              parseFloat(markerNodes[i].getAttribute("lat")),
              parseFloat(markerNodes[i].getAttribute("lng")));
		var type = markerNodes[i].getAttribute("type");

         createOption(name, distance, i);
         createMarker(latlng, name, address, type);
         bounds.extend(latlng);
       }
       map.fitBounds(bounds);
       locationSelect.style.visibility = "visible";
       locationSelect.onchange = function() {
         var markerNum = locationSelect.options[locationSelect.selectedIndex].value;
         google.maps.event.trigger(markers[markerNum], 'click');
       };
      });
    }
  

 function searchLocationsNear2(center) {
     clearLocations(); 
    var radius = 300;
     var searchUrl = 'db_search.php?lat=' + center.lat() + '&lng=' + center.lng() + '&radius=' + radius;
     downloadUrl(searchUrl, function(data) {
       var xml2 = parseXml(data);
       var markerNodes = xml2.documentElement.getElementsByTagName("marker");
       var bounds = new google.maps.LatLngBounds();
       for (var i = 0; i < markerNodes.length; i++) {
         var name = markerNodes[i].getAttribute("name");
         var address = markerNodes[i].getAttribute("address");
         var distance = parseFloat(markerNodes[i].getAttribute("distance"));
         var latlng = new google.maps.LatLng(
              parseFloat(markerNodes[i].getAttribute("lat")),
              parseFloat(markerNodes[i].getAttribute("lng")));
		var type = markerNodes[i].getAttribute("type");

         createOption(name, distance, i);
         createMarker(latlng, name, address, type);
         bounds.extend(latlng);
       }
       map.fitBounds(bounds);
       locationSelect.style.visibility = "visible";
       locationSelect.onchange = function() {
         var markerNum = locationSelect.options[locationSelect.selectedIndex].value;
         google.maps.event.trigger(markers[markerNum], 'click');
       };
      });
    }
  
   function createMarker(latlng, name, address, type) {
  var html = "<b>" + name + "</b> <br/>" + address;
  
  
  var marker = new google.maps.Marker({
    map: map,
    position: latlng
  });
  google.maps.event.addListener(marker, 'click', function() {
    infoWindow.setContent(html);
    infoWindow.open(map, marker);
  });
  markers.push(marker);
}


    function createOption(name, distance, num) {
      var option = document.createElement("option");
      option.value = num;
      option.innerHTML = name + "(" + distance.toFixed(1) + ")";
      locationSelect.appendChild(option);
    }

    function downloadUrl(url, callback) {
      var request = window.ActiveXObject ?
          new ActiveXObject('Microsoft.XMLHTTP') :
          new XMLHttpRequest;

      request.onreadystatechange = function() {
        if (request.readyState == 4) {
          request.onreadystatechange = doNothing;
          callback(request.responseText, request.status);
        }
      };

      request.open('GET', url, true);
      request.send(null);
    }

    function parseXml(str) {
      if (window.ActiveXObject) {
        var doc = new ActiveXObject('Microsoft.XMLDOM');
        doc.loadXML(str);
        return doc;
      } else if (window.DOMParser) {
        return (new DOMParser).parseFromString(str, 'text/xml');
      }
    }

    function doNothing() {}



	

    //]]>
  </script>

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
    <td width="240" valign="top" bgcolor="#f2e6d6"></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <?php //echo "$msg"; ?>
       <div>
     <input type="text" id="addressInput" size="10"/>
    <select id="radiusSelect">
      <option value="25" selected>25mi</option>
      <option value="100">100mi</option>
      <option value="200">200mi</option>
    </select>
    <input type="button" onClick="searchLocations()" value="Search"/>
    <input type='button' onClick="loadall()" value="reset"/>
<input type='button' onClick="track_loc()" value="track"/>
    </div>
    <div><select id="locationSelect" style="width:100%;visibility:hidden"></select></div>
    
    </td>
  </tr>
  <tr>
  
  <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?> </td>
    <td width="700px" height="500px">
      <div id="map" style="width:100%; height:100%"></div>
    </td>
  
  </tr>  
  <tr>
   <SCRIPT src="footer.js"></SCRIPT>
  </tr>
  
</table>

</body>
</html>