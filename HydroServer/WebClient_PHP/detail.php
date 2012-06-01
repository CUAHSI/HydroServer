<?php

require_once 'db_config.php';

// get data and store in a json array
$query = "SELECT DISTINCT VariableID, VariableName, VariableunitsID FROM seriescatalog";
$siteid = $_GET['siteid'];
$query .= " WHERE SiteID=".$siteid;

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());





$variables[] = array(
        'variableid' => "-1",
        'variablename' => "Please select a variable" );
	


while ($row = mysql_fetch_array($result, MYSQL_ASSOC)) {
    

		$variables[] = array(
        'variableid' => $row['VariableID'],
        'variablename' => $row['VariableName']);
}

echo json_encode($variables);
mysql_close($connect);
?>