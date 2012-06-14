<?php
//value given from the page
$x=$_GET["x"];

//connect to server and select database
require_once 'database_connection.php';

//filter the Type results after Site is selected
$sql3 ="SELECT DISTINCT VariableID, VariableName, DataType FROM seriescatalog WHERE SiteID='".$x."' ORDER BY VariableName ASC";

$result3 = @mysql_query($sql3,$connection)or die(mysql_error());

$num = @mysql_num_rows($result3);
	if ($num < 1) {

    echo "<P><em2>No Types for this Site.</em></p>";

	} else {
$option_block3 = "<select name='VariableID' id='VariableID' onChange='showMethods(this.value)'><option value=''>Select....</option>";
	while ($row3 = mysql_fetch_array ($result3)) {

		$typeid = $row3["VariableID"];
		$typename = $row3["VariableName"];
		$datatype = $row3["DataType"];

		$option_block3 .= "<option value=$typeid>$typename ($datatype)</option>";

		}
	}
$option_block3 .= "</select>";
echo $option_block3;
mysql_close($connection);
?>