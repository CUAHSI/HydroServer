<?php
require_once 'db_config.php';


// get data and store in a json array
$query = "Select * FROM variables ORDER BY VariableName ASC";

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());




$variables[] = array(
        'variableid' => "-1",
        'variablename' => "Select.." );
	


while ($row = mysql_fetch_array($result, MYSQL_ASSOC)) {
    

		$variables[] = array(
        'variableid' => $row['VariableID'],
        'variablename' => $row['VariableName']."(".$row["DataType"].")");

}


echo json_encode($variables);
?>