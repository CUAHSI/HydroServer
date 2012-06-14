<?php
require_once 'db_config.php';


// get data and store in a json array
$query = "SELECT DISTINCT VariableName FROM seriescatalog";
$siteid = $_GET['siteid'];
$query .= " WHERE SiteID=".$siteid;

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());





$variables[] = array(
        'variableid' => "-1",
        'variablename' => "Please select a variable" );
	
$temp=1;

while ($row = mysql_fetch_array($result, MYSQL_ASSOC)) {
    
if($row['VariableName']!=null){
		$variables[] = array(
        'variableid' => $temp,
        'variablename' => $row['VariableName']);
$temp=$temp+1;
}
}

echo json_encode($variables);
?>