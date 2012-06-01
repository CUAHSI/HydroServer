<?php
require_once 'db_config.php';

// Get parameters from URL
$siteid = $_GET["siteid"];
$varid = $_GET["varid"];

// Start XML file, create parent node
$dom = new DOMDocument("1.0");
$node = $dom->createElement("datesall");
$parnode = $dom->appendChild($node);


// Search the rows in the markers table
$query = sprintf("SELECT BeginDateTime, EndDateTime, SiteName FROM seriescatalog WHERE SiteID='%s' and VariableID='%s'",
  mysql_real_escape_string($siteid),
  mysql_real_escape_string($varid));
$result = mysql_query($query);

$result = mysql_query($query);
if (!$result) {
  die("Invalid query: " . mysql_error());
}

header("Content-type: text/xml");

// Iterate through the rows, adding XML nodes for each
while ($row = @mysql_fetch_assoc($result)){
  $node = $dom->createElement("dates");
  $newnode = $parnode->appendChild($node);
  $newnode->setAttribute("date_from", $row['BeginDateTime']);
  $newnode->setAttribute("date_to", $row['EndDateTime']);
  $newnode->setAttribute("sitename", $row['SiteName']);
 }

//Output the XML DATA to be fed into the google maps api

echo $dom->saveXML();
mysql_close($connect);
?>