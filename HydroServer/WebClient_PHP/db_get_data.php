<?php
header( 'Content-Type: text/csv' );
require_once 'db_config.php';

$siteid=$_GET['siteid'];
$varid=$_GET['varid'];
$startdate=$_GET['startdate'];
$enddate=$_GET['enddate'];

$query = "SELECT ValueID, DataValue, LocalDateTime FROM datavalues";
$query .= " WHERE SiteID=".$siteid." and VariableID=".$varid." and LocalDateTime between '".$startdate."' and '".$enddate."' ORDER BY LocalDateTime ASC";

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
echo("ValueID,DataValue,LocalDateTime");

 while ($row = mysql_fetch_array($result, MYSQL_ASSOC))
  {echo "\r\n";
  
  
  
    echocsv( $row );
	echo(",");
	echo($unit);
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