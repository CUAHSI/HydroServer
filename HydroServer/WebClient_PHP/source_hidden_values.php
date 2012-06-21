<?php

require 'main_config.php';

//create next increment SourceID in the table
$next_increment ="0";

//connect to server and select database
require_once 'database_connection.php';

//add the next SourceID's

$sql ="SHOW TABLE STATUS LIKE 'sources'";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$row = mysql_fetch_assoc($result);

$SourceID = $row['Auto_increment'];

?>