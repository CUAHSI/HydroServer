<?php

//value given from the add_site.php page
$sid=$_GET["SourceID"];

//connect to server and select database
require_once 'database_connection.php';

//find the matching name for the SourceID
$sql_cc ="Select * FROM sources WHERE SourceID=$sid";

$result_cc = @mysql_query($sql_cc,$connection)or die(mysql_error());

$num_cc = @mysql_num_rows($result_cc);

	if ($num_cc < 1) {

	alert("Please reselect the Source.");

	} 

	else {

		while ($row_cc = mysql_fetch_array ($result_cc)) {

			$sname = $row_cc["Organization"];

		}
	}
echo $sname;	
	
mysql_close($connection);

?>