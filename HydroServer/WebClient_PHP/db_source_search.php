<?php


require_once 'db_config.php';

// Get parameters from URL
$siteid = $_GET["siteid"];

// Start XML file, create parent node
$dom = new DOMDocument("1.0");
$node = $dom->createElement("sources");
$parnode = $dom->appendChild($node);
header("Content-type: text/xml");


//Search the Data Table for SourceIDs




$query = sprintf("SELECT DISTINCT SourceID, SiteID FROM seriescatalog WHERE SiteID ='%s'",
  mysql_real_escape_string($siteid));
$result = mysql_query($query);

while ($row = @mysql_fetch_assoc($result)){
//Search Details of Each Source ID Returned

$sourceid=$row['SourceID'];
$query1 = sprintf("SELECT SourceID, Organization, SourceLink FROM sources WHERE SourceID ='%s'",
  mysql_real_escape_string($sourceid));
$result1 = mysql_query($query1);

$row1 = @mysql_fetch_assoc($result1);

$node = $dom->createElement("source");
$newnode = $parnode->appendChild($node);
$newnode->setAttribute("sourcename", $row1['Organization']);
$newnode->setAttribute("sourcecode", $row1['SourceID']);
$newnode->setAttribute("sourcelink", $row1['SourceLink']);
}

//Output the XML DATA to be fed into the google maps api

echo $dom->saveXML();
mysql_close($connect);
?>