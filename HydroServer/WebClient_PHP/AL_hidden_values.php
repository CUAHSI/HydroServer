<?php

require_once 'main_config.php';

//create next increment ValueID in the table
$next_increment ="0";

//connect to server and select database
require_once 'database_connection.php';

//add the SourceID's

$sql ="SHOW TABLE STATUS LIKE 'datavalues'";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$row = mysql_fetch_assoc($result);

$ValueID = $row['Auto_increment'];

?>