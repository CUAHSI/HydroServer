<?php
//Database Connection
$username='advenup1_odm';
$password='MapW1nd0w';
$database='advenup1_odm';
$db_connect='localhost';

// Start XML file, create parent node

$dom = new DOMDocument("1.0");
$node = $dom->createElement("markers");
$parnode = $dom->appendChild($node);

// Opens a connection to a MySQL server

$connection=mysql_connect ($db_connect, $username, $password);
if (!$connection) {  die('Not connected : ' . mysql_error());}

// Set the active MySQL database

$db_selected = mysql_select_db($database, $connection);
if (!$db_selected) {
  die ('Can\'t use db : ' . mysql_error());
}

// Select all the rows in the markers table
$dist=0;
$query = "SELECT * FROM sites WHERE 1";
$result = mysql_query($query);
if (!$result) {
  die('Invalid query: ' . mysql_error());
}

header("Content-type: text/xml");

// Iterate through the rows, adding XML nodes for each
while ($row = @mysql_fetch_assoc($result)){
  $node = $dom->createElement("marker");
  $newnode = $parnode->appendChild($node);
  $newnode->setAttribute("name", $row['SiteID']);
  $newnode->setAttribute("address", $row['SiteCode']);
  $newnode->setAttribute("lat", $row['Latitude']);
  $newnode->setAttribute("lng", $row['Longitude']);
  $newnode->setAttribute("type", $row['SiteType']);
  $newnode->setAttribute("distance", $dist);
}

echo $dom->saveXML();
?>