<?php

require_once 'db_config.php';

// get data and store in a json array
$query = "SELECT DISTINCT VariableID FROM seriescatalog";
$siteid = $_GET['siteid'];
$varname = $_GET['varname'];
$datatype = $_GET['type'];
$query .= " WHERE SiteID=".$siteid." AND VariableName='".$varname."'"." AND DataType='".$datatype."'";

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());

$row = mysql_fetch_array($result, MYSQL_ASSOC);
$output = $row['VariableID'];

echo $output;
mysql_close($connect);
?>