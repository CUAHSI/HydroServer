<?php

//Connect to DB
$username='advenup1_odm';
$password='MapW1nd0w';
$database='advenup1_odm';
$db_connect='localhost';
//connection String
$connect = mysql_connect($db_connect, $username, $password)
or die('Could not connect: ' . mysql_error());
//select database
mysql_select_db($database, $connect);
//Select The database
$bool = mysql_select_db($database, $connect);
if ($bool === False){
   print "can't find $database";
}



?>