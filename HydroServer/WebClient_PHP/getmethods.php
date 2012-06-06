<?php
//value given from the page
$q=$_GET["y"];

//connect to server and select database
require_once 'database_connection.php';

//filter the Type results after Site is selected
$sql6 ="SELECT DISTINCT MethodID, MethodDescription FROM seriescatalog WHERE SourceID='".$y."' ORDER BY MethodDescription ASC";

$result6 = @mysql_query($sql6,$connection)or die(mysql_error());

$num = @mysql_num_rows($result6);
	if ($num < 1) {

    echo "<P><em2>No Types for this Site.</em></p>";

	} else {
$option_block6 = "<select name='VariableID' id='VariableID'><option value=''>Select....</option>";
	while ($row6 = mysql_fetch_array ($result6)) {

		$typeid = $row6["VariableID"];
		$typename = $row6["VariableName"];
		$datatype = $row6["DataType"];

		$option_block6 .= "<option value=$typeid>$typename ($datatype)</option>";

		}
	}
$option_block6 .= "</select>";
echo $option_block6;
mysql_close($connection);
?>