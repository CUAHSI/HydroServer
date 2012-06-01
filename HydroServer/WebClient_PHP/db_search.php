<?php

require_once 'db_config.php';

// Get parameters from URL
$center_lat = $_GET["lat"];
$center_lng = $_GET["lng"];
$radius = $_GET["radius"];

// Start XML file, create parent node
$dom = new DOMDocument("1.0");
$node = $dom->createElement("markers");
$parnode = $dom->appendChild($node);



// Search the rows in the markers table
$query = sprintf("SELECT SiteID, SiteCode,SiteName, Latitude, Longitude, SiteType, ( 3959 * acos( cos( radians('%s') ) * cos( radians( Latitude ) ) * cos( radians( Longitude ) - radians('%s') ) + sin( radians('%s') ) * sin( radians( Latitude ) ) ) ) AS distance FROM sites HAVING distance < '%s' ORDER BY distance",
  mysql_real_escape_string($center_lat),
  mysql_real_escape_string($center_lng),
  mysql_real_escape_string($center_lat),
  mysql_real_escape_string($radius));
$result = mysql_query($query);

$result = mysql_query($query);
if (!$result) {
  die("Invalid query: " . mysql_error());
}

header("Content-type: text/xml");

// Iterate through the rows, adding XML nodes for each
while ($row = @mysql_fetch_assoc($result)){
  $node = $dom->createElement("marker");
  $newnode = $parnode->appendChild($node);
  $newnode->setAttribute("name", $row['SiteName']);
  $newnode->setAttribute("siteid", $row['SiteID']);
  $newnode->setAttribute("sitecode", $row['SiteCode']);
  $newnode->setAttribute("lat", $row['Latitude']);
  $newnode->setAttribute("lng", $row['Longitude']);
  $newnode->setAttribute("distance", $row['distance']);
  $newnode->setAttribute("sitetype", $row['SiteType']);
}

//Output the XML DATA to be fed into the google maps api

echo $dom->saveXML();
mysql_close($connect);
?>