<?php
//value given from the page
$m=$_GET["m"];

//connect to server and select database
require_once 'database_connection.php';

//filter the Type results after Site is selected
$sql_m ="SELECT MethodID FROM varmeth WHERE VariableCode=$m";

$result_m = @mysql_query($sql_m,$connection)or die(mysql_error());

$num_m = @mysql_num_rows($result_m);
	if ($num_m < 1) {

    	echo "<p><em2>No Methods for this Type.</em></p>";
		} 

	else {

	$option_block_m = "<select name='MethodID' id='MethodID'><option value=''>Select....</option>";

	$method =  mysql_fetch_field($result_m);

	$methodstr = explode(",", $method);
	
	for ($a = 0; $a<= "10"; $a++){
		
		//Creates a variable for each method number, starting with $m1
		$m[$a++] = $methodstr[$a]; 
		
		foreach($m[]){
		
		$sql_m2 ="SELECT * FROM methods WHERE MethodID=$m[]";

		$result_m2 = @mysql_query($sql_m2,$connection)or die(mysql_error());

			while ($rows = mysql_fetch_array ($result_m2)) {

			$methodNum = $rows["MethodID"];
			$methodName = $rows["MethodDescription"];

			$option_block_m .= "<option value=$methodNum>$methodName</option>";

			}
		}
	}
}

$option_block_m .= "</select>";
echo $option_block_m;

mysql_close($connection);

?>