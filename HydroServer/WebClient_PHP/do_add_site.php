<?php

if (!function_exists("GetSQLValueString")) {
function GetSQLValueString($theValue, $theType, $theDefinedValue = "", $theNotDefinedValue = "") 
{
  if (PHP_VERSION < 6) {
    $theValue = get_magic_quotes_gpc() ? stripslashes($theValue) : $theValue;
  }

  $theValue = function_exists("mysql_real_escape_string") ? mysql_real_escape_string($theValue) : mysql_escape_string($theValue);

  switch ($theType) {
    case "text":
      $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
      break;    
    case "long":
    case "int":
      $theValue = ($theValue != "") ? intval($theValue) : "NULL";
      break;
    case "double":
      $theValue = ($theValue != "") ? doubleval($theValue) : "NULL";
      break;
    case "date":
      $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
      break;
    case "defined":
      $theValue = ($theValue != "") ? $theDefinedValue : $theNotDefinedValue;
      break;
  }
  return $theValue;
}
}



$sitecode= $_GET['sc'];
$source= $_GET['source'];
$sitename= $_GET['sn'];
$lat=$_GET['lat'];
$lng=$_GET['lng'];
$llid=$_GET['llid'];
$type=$_GET['type'];
$elev=$_GET['elev'];
$datum=$_GET['datum'];
$state=$_GET['state'];
$county=$_GET['county'];
$coms=$_GET['com'];
require_once 'db_config.php';



$sql ="INSERT INTO `sites`(`SiteCode`, `SiteName`, `Latitude`, `Longitude`, `LatLongDatumID`, `SiteType`, `Elevation_m`, `VerticalDatum`, `State`, `County`, `Comments`) VALUES ('$sitecode', '$sitename', '$lat', '$lng', '$llid', '$type', '$elev', '$datum', '$state', '$county', '$coms')";

$result = @mysql_query($sql,$connect)or die(mysql_error());

//Fetch the SiteID of the Inserted site

$sql2="SELECT `SiteID` FROM `sites` WHERE `SiteCode`='$sitecode'";
$result2 = @mysql_query($sql2,$connect)or die(mysql_error());
$row2=mysql_fetch_array ($result2);
$siteid=$row2['SiteID'];


$sql3="SELECT * FROM `sources` WHERE SourceID='$source'";

$result3 = @mysql_query($sql3,$connect)or die(mysql_error());

$row3=mysql_fetch_array ($result3);

$org=$row3['Organization'];
$desc=$row3['SourceDescription'];
$cita=$row3['Citation'];
$vc=0;



$sql4 = sprintf("INSERT INTO `seriescatalog`(`SiteID`, `SiteCode`, `SiteName`, `SiteType`, `SourceID`, `Organization`, `SourceDescription`, `Citation`, `ValueCount`) VALUES ('$siteid', '$sitecode', '$sitename', '$type', '$source', '$org', %s, '$cita', '$vc')",
             
                       GetSQLValueString($desc, "text"));
					  


$result4 = @mysql_query($sql4,$connect)or die(mysql_error());


echo($result4);




?>