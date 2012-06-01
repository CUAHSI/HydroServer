<?php
require_once 'db_config.php';

$siteid=$_GET['siteid'];
$varid=$_GET['varid'];
$startdate=$_GET['startdate'];
$enddate=$_GET['enddate'];

$query = "SELECT ValueID, DataValue, LocalDateTime FROM datavalues";
$query .= " WHERE SiteID=".$siteid." and VariableID=".$varid." and LocalDateTime between '".$startdate."' and '".$enddate."' ORDER BY LocalDateTime ASC";

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());

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