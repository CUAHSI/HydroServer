<?php
require_once 'db_config.php';

// Start XML file, create parent node

$dom = new DOMDocument("1.0");
$node = $dom->createElement("markers");
$parnode = $dom->appendChild($node);



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
	
$query1 = "SELECT * FROM seriescatalog WHERE SiteID=".$row['SiteID']." and VariableID IS NULL";
$result1 = mysql_query($query1);
$rows=mysql_num_rows($result1);

	
$query2 = "SELECT * FROM seriescatalog WHERE SiteID=".$row['SiteID'];
$result2 = mysql_query($query2);
$rows2=mysql_num_rows($result2);

	if ((($rows==1)&&($rows==$rows2))||($rows2==0)) {
	
 
	}
	else
	{
	 $node = $dom->createElement("marker");
  $newnode = $parnode->appendChild($node);
  $newnode->setAttribute("name", $row['SiteName']);
  $newnode->setAttribute("siteid", $row['SiteID']);
   $newnode->setAttribute("sitecode", $row['SiteCode']);
  $newnode->setAttribute("lat", $row['Latitude']);
  $newnode->setAttribute("lng", $row['Longitude']);
  $newnode->setAttribute("sitetype", $row['SiteType']);
  $newnode->setAttribute("distance", $dist);	
		
	}
	
}

echo $dom->saveXML();
mysql_close($connect);
?>