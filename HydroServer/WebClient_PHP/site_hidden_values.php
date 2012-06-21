<?php



require_once 'main_config.php';

//create next increment SiteID in the table
$next_increment ="0";

//connect to server and select database
require_once 'database_connection.php';

//add the SourceID's

$sql ="SHOW TABLE STATUS LIKE 'sites'";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$row = mysql_fetch_assoc($result);

$SiteID = $row['Auto_increment'];

?>