<?php

//Establish default values for MOSS' data variables
$UTCOffset = -7; 
$UTCOffset2 = 7; // Actually it is -7
$CensorCode ='nc';
$QualityControlLevelID = 0;
$ValueAccuracy ='NULL'; 
$OffsetValue ='NULL';
$OffsetTypeID ='NULL';
$QualifierID =1;
$SampleID ='NULL';
$DerivedFromID ='NULL';


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