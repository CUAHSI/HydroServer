<?php
require_once 'db_config.php';

// get data and store in a json array
$query = "SELECT DISTINCT DataType FROM seriescatalog";
$siteid = $_GET['siteid'];
$varname = $_GET['varname'];
$query .= " WHERE SiteID=".$siteid." AND VariableName='".$varname."'";

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());




while ($row = mysql_fetch_array($result, MYSQL_ASSOC)) {
    
	if($row['DataType']=="Average")
{	
$dataid=1;}
else
{
	$dataid=2;
}
		$variables[] = array(
        'dataid' => $dataid,
        'dataname' => $row['DataType']);
}

echo json_encode($variables);
mysql_close($connect);
?>