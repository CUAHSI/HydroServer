<?php
// Set the JSON header
header( 'Content-Type: text/csv' );
header('Content-Disposition: attachment; filename=data.csv');

require_once 'db_config.php';

$siteid=$_GET['siteid'];
$varid=$_GET['varid'];
$startdate=$_GET['startdate'];
$enddate=$_GET['enddate'];

$query = "SELECT ValueID, DataValue, LocalDateTime FROM datavalues";
$query .= " WHERE SiteID=".$siteid." and VariableID=".$varid." and LocalDateTime between '".$startdate."' and '".$enddate."' ORDER BY LocalDateTime ASC";

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());

//Echo the details

echo("HYDROSERVER WEB - DATA EXPORT\r\n");

//Run a query to get the site details

$query2 = "SELECT SiteID, SiteName, SiteCode, Latitude, Longitude FROM sites";
$query2 .= " WHERE SiteID=".$siteid;

$result2 = mysql_query($query2) or die("SQL Error 1: " . mysql_error());
$row2 = mysql_fetch_array($result2, MYSQL_ASSOC);


echo("Site: ".$row2['SiteName']."(".$row2['SiteCode'].") Latitude: ".$row2['Latitude']." Longitude: ".$row2['Longitude']."\r\n");

//Run A query to get Variable Details

$query2 = "SELECT VariableID, VariableName, DataType FROM variables";
$query2 .= " WHERE VariableID=".$varid;

$result2 = mysql_query($query2) or die("SQL Error 1: " . mysql_error());
$row2 = mysql_fetch_array($result2, MYSQL_ASSOC);

$varname = str_replace(",", "", $row2['VariableName']);

echo("Variable: ".$varname."(".$row2['VariableID'].") Datatype: ".$row2['DataType']);
echo("\r\n");
//Echo Date Range

echo("The below data is from: ".$startdate." to ".$enddate."\r\n");

//Echo Column Names

echo("ValueID,DataValue,LocalDateTime\r\n");


$num_rows = mysql_num_rows($result);
$count=1;
 while ($row = mysql_fetch_array($result, MYSQL_ASSOC))
  {
    echocsv( $row );
   if($count!=$num_rows)
	{echo "\r\n";}
  $count=$count+1;
  }


  function echocsv( $fields )
  {
    $separator = '';
    foreach ( $fields as $field )
    {
      if ( preg_match( '/\\r|\\n|,|"/', $field ) )
      {
        $field = '"' . str_replace( '"', '""', $field ) . '"';
      }
      echo $separator . $field;
      $separator = ',';
    }
    
  }
mysql_close($connect);
?>