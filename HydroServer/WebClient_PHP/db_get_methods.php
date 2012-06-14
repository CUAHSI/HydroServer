<?php
require_once 'db_config.php';

// get data and store in a json array
$query = "SELECT MethodID, MethodDescription FROM seriescatalog";
$siteid = $_GET['siteid'];
$varid = $_GET['varid'];
$query .= " WHERE SiteID=".$siteid." AND VariableID='".$varid."'";

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());




while ($row = mysql_fetch_array($result, MYSQL_ASSOC)) {
    

		$methods[] = array(
        'methodid' => $row['MethodID'],
        'methodname' => $row['MethodDescription']);
}

echo json_encode($methods);
mysql_close($connect);
?>