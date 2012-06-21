<?php

require 'main_config.php';

$connect = mysql_connect(DATABASE_HOST, DATABASE_USERNAME, DATABASE_PASSWORD)
    or die("<p>Error connecting to database: " . 
	       mysql_error() . "</p>");
  
  $bool = mysql_select_db(DATABASE_NAME,$connect)
    or die("<p>Error selecting the database " . DATABASE_NAME .
	  mysql_error() . "</p>");



?>