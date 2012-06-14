<?php
Header("content-type: application/x-javascript");

require_once 'db_config.php';

$siteid=$_GET['siteid'];
$varid=$_GET['varid'];
$startdate=$_GET['startdate'];
$enddate=$_GET['enddate'];
$methodid=$_GET['meth'];


$query = "SELECT ValueID, DataValue, LocalDateTime FROM datavalues";
$query .= " WHERE SiteID='$siteid' and VariableID='$varid' and MethodID='$methodid' and LocalDateTime between '".$startdate."' and '".$enddate."' ORDER BY LocalDateTime ASC";

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());
$query2 = "SELECT VariableunitsID FROM variables";
$query2 .= " WHERE VariableID=".$varid;

$result2 = mysql_query($query2) or die("SQL Error 1: " . mysql_error());

$unitid = mysql_fetch_array($result2, MYSQL_ASSOC);
$unitid = $unitid['VariableunitsID'];
$query3 = "SELECT * FROM units";
$query3 .= " WHERE unitsID=".$unitid;
$result3 = mysql_query($query3) or die("SQL Error 1: " . mysql_error());
$result3 = mysql_fetch_array($result3, MYSQL_ASSOC);

$unit=$result3['unitsType'];

echo("var data_test = [\r\n");

$num_rows = mysql_num_rows($result);
$count=1;

//To echo Data in javascript format


while ($row = mysql_fetch_array($result, MYSQL_ASSOC))
{
	
$pieces = explode("-", $row['LocalDateTime']);

$pieces2 = explode(" ", $pieces[2]);

$pieces3 = explode(":", $pieces2[1]);


$output="[Date.UTC(".$pieces[0].",".$pieces[1].",".$pieces2[0].",".$pieces3[0].",".$pieces3[1].",".$pieces3[2]."),".$row['DataValue']."]";
echo $output;

 if($count!=$num_rows)
	{echo ",";}
  $count=$count+1;
  
  echo ("\r\n");

}


echo("];");

?>
