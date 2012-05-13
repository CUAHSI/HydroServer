<?php

require_once 'database_connection.php';

echo 'Testing UpdateSeriesCatalog!';
db_UpdateSeriesCatalog_All();
//db_UpdateSeriesCatalog(24, 12, 4, 6, 0);

// This function updates all entries in the 
// SeriesCatalog by extracting the aggregate values
// from the dataValues table and from related tables.
function db_UpdateSeriesCatalog_All() {
  
  $result_status = array("inserted" => 0, "updated" => 0);
  
  $query = "SELECT MAX(SiteID), MAX(VariableID), MAX(MethodID), MAX(SourceID), MAX(QualityControlLevelID)
            FROM datavalues
            GROUP BY SiteID, VariableID, SourceID, MethodID, QualityControlLevelID";
  
  $result = mysql_query($query);
  
  if (!$result) {
    die("<p>Error in executing the SQL query " . $query . ": " . 
	  mysql_error() . "</p>");
  }
  
  $result_array = mysql_fetch_rowsarr($result, MYSQL_NUM);
  foreach($result_array as $r) {
    echo "<p>executing db_UpdateSeriesCatalog({$r[0]}, {$r[1]}, {$r[2]}, {$r[3]}, {$r[4]}</p>";
    $status = db_UpdateSeriesCatalog($r[0], $r[1], $r[2], $r[3], $r[4]);
	$result_status["inserted"] += $status["inserted"];
	$result_status["updated"] += $status["updated"];
  }
  
  echo "<p>rows inserted: " . $result_status["inserted"] . "</p>";
  echo "<p>rows updated: " . $result_status["updated"] . "</p>";
}

function mysql_fetch_rowsarr($result, $numass=MYSQL_BOTH) {
  $i=0;
  $keys=array_keys(mysql_fetch_array($result, $numass));
  mysql_data_seek($result, 0);
    while ($row = mysql_fetch_array($result, $numass)) {
      foreach ($keys as $speckey) {
        $got[$i][$speckey]=$row[$speckey];
      }
    $i++;
    }
  return $got;
}

function db_find_seriesid($siteID, $variableID, $methodID, $sourceID, $qcID) {
  $query_text = "SELECT SeriesID FROM seriescatalog WHERE ";
  $query_text .= "SiteID = " . $siteID . " AND VariableID = " . $variableID . " AND MethodID = " . $methodID . " AND SourceID = " . $sourceID . " AND QualityControlLevelID = " . $qcID;
  
  echo "<p>db_find_seriesid</p>";
  echo "<pre>" . $query_text . "</pre>";
  
  $result = mysql_query($query_text);
   
  if (!$result) {
    die("<p>Error in executing the SQL query " . $query_text . ": " . 
	  mysql_error() . "</p>");
  }
  $num_rows = mysql_num_rows($result);
  if ($num_rows == 0)
    return 0;
  else {
    $val = mysql_fetch_row($result);
	return $val[0];
  }
}

function db_UpdateSeriesCatalog($siteID, $variableID, $methodID, $sourceID, $qcID) {
  
  $status = array("inserted" => 0, "updated" => 0);
  
  //check for an existing seriesID
  $series_id = db_find_seriesid($siteID, $variableID, $methodID, $sourceID, $qcID);
  
  echo "series_id: " . $series_id;
  
  //run the values query - series catalog from data values table
 
	$values_query = 
	"SELECT dv.SiteID, 
s.SiteCode, s.SiteName, s.SiteType,
dv.VariableID,
v.VariableCode, v.VariableName, v.Speciation, 
v.VariableUnitsID, vu.UnitsName, 
v.SampleMedium, v.ValueType, v.TimeSupport, 
v.TimeUnitsID, tu.UnitsName, 
v.DataType, v.GeneralCategory,
m.MethodID, m.MethodDescription, 
sou.SourceID, sou.Organization, sou.SourceDescription, sou.Citation,
qc.QualityControlLevelID, qc.QualityControlLevelCode,
MIN( dv.LocalDateTime ) AS 'BeginDateTime', MAX( dv.LocalDateTime ) AS 'EndDateTime' , 
MIN( dv.DateTimeUTC )  AS 'BeginDateTimeUTC', MAX( dv.DateTimeUTC )  AS 'EndDateTimeUTC', 
COUNT( dv.ValueID ) AS 'ValueCount'
FROM datavalues dv
INNER JOIN sites s ON dv.SiteID = s.SiteID
INNER JOIN variables v ON dv.VariableID = v.VariableID
INNER JOIN units vu ON v.VariableunitsID = vu.UnitsID
INNER JOIN units tu ON v.TimeunitsID = tu.UnitsID
INNER JOIN methods m ON dv.MethodID = m.MethodID
INNER JOIN sources sou ON dv.SourceID = sou.SourceID
INNER JOIN qualitycontrollevels qc ON dv.QualityControlLevelID = qc.QualityControlLevelID
WHERE dv.SiteID ={$siteID}
 AND dv.VariableID ={$variableID}
 AND dv.MethodID ={$methodID}
 AND dv.SourceID ={$sourceID}
 AND dv.QualityControlLevelID ={$qcID}";
 
   $valuesresult = mysql_query($values_query);
   
   if (!$valuesresult) {
    die("<p>Error in executing the SQL query " . $values_query . ": " . 
	  mysql_error() . "</p>");
  }
  
  echo "<pre>" . $values_query . "</pre>";
  
  $num_values_rows = mysql_num_rows($valuesresult);
  
  if ($num_values_rows == 0) {
    echo "NO SERIES IDENTIFIED from DataValues TABLE!";
    return $status; 
  }
  
    // find entries to SeriesCatalog from joining DataValues and other tables
	$row = mysql_fetch_row($valuesresult); 
    $siteID = $row[0];
	$siteCode = $row[1];
	$siteName = $row[2];
	$siteType = $row[3];
	$variableID = $row[4];
	$variableCode = $row[5];
	$variableName = $row[6];
	$speciation = $row[7];
	$variableUnitsID = $row[8];
	$variableUnitsName = $row[9];
	$sampleMedium = $row[10];
	$valueType = $row[11];
	$timeSupport = $row[12];
	$timeUnitsID = $row[13];
	$timeUnitsName = $row[14];
	$dataType = $row[15];
	$generalCategory = $row[16];
	$methodID = $row[17];
	$methodDescription = $row[18];
	$sourceID = $row[19];
	$organization = $row[20];
	$sourceDescription = $row[21];
	$citation = $row[22];
	$qualityControlLevelID = $row[23];
	$qualityControlLevelCode = $row[24];
	$beginDateTime = $row[25];
	$endDateTime = $row[26];
	$beginDateTimeUTC = $row[27];
	$endDateTimeUTC = $row[28];
	$valueCount = $row[29];
  
  //IF SERIESID IS NOT FOUND: INSERT
  if ($series_id == 0) { // INSERT
    $insert = 
	"INSERT INTO seriescatalog(SiteID, SiteCode, SiteName, SiteType,
	VariableID, VariableCode, VariableName, Speciation, VariableunitsID, VariableunitsName,
	SampleMedium, ValueType, TimeSupport, TimeunitsID, TimeunitsName, DataType, GeneralCategory,
	MethodID, MethodDescription,
	SourceID, Organization, SourceDescription, Citation,
	QualityControlLevelID, QualityControlLevelCode,
	BeginDateTime, EndDateTime, BeginDateTimeUTC, EndDateTimeUTC, ValueCount) VALUES (";
	$insert .= "'" . $siteID . "', ";
	$insert .= "'" . $siteCode . "', ";
	$insert .= "'" . mysql_real_escape_string($siteName) . "', ";
    $insert .= "'" . $siteType . "', ";
	$insert .= "'" . $variableID . "', ";
	$insert .= "'" . $variableCode . "', ";
	$insert .= "'" . $variableName . "', ";
	$insert .= "'" . $speciation . "', ";
	$insert .= "'" . $variableUnitsID . "', "; 
	$insert .= "'" . $variableUnitsName . "', ";
	$insert .= "'" . $sampleMedium . "', ";
	$insert .= "'" . $valueType . "', ";
	$insert .= "'" . $timeSupport . "', ";
	$insert .= "'" . $timeUnitsID . "', ";
	$insert .= "'" . $timeUnitsName . "', ";
	$insert .= "'" . $dataType . "', ";
	$insert .= "'" . $generalCategory . "', ";
	$insert .= "'" . $methodID . "', ";
	$insert .= "'" . mysql_real_escape_string($methodDescription) . "', ";
	$insert .= "'" . $sourceID . "', ";
	$insert .= "'" . $organization . "', ";
	$insert .= "'" . mysql_real_escape_string($sourceDescription) . "', ";
	$insert .= "'" . mysql_real_escape_string($citation) . "', ";
	$insert .= "'" . $qualityControlLevelID . "', ";
	$insert .= "'" . $qualityControlLevelCode . "', ";
	$insert .= "'" . $beginDateTime . "', ";
	$insert .= "'" . $endDateTime . "', ";
	$insert .= "'" . $beginDateTimeUTC . "', ";
	$insert .= "'" . $endDateTimeUTC . "', ";
	$insert .= "'" . $valueCount . "'); ";
	
	echo "<pre>" . $insert . "</pre>";
	
	   $insertresult = mysql_query($insert);
	   if (!$insertresult) {
		die("<p>Error in executing the SQL query " . $insert . ": " . 
		  mysql_error() . "</p>");
	  }
	  echo "<p>INSERT SUCCESSFUL!!!</p>";
	  $status["inserted"] = 1;
  }
  //IF SERIESID IS FOUND: UPDATE
  else {                 
    $update = "UPDATE seriescatalog SET ";
	$update .= "SiteID = '" . $siteID . "', ";
	$update .= "SiteCode='" . $siteCode . "', ";
	$update .= "SiteName='" . mysql_real_escape_string($siteName) . "', ";
    $update .= "SiteType='" . $siteType . "', ";
	$update .= "VariableID='" . $variableID . "', ";
	$update .= "VariableCode='" . $variableCode . "', ";
	$update .= "VariableName='" . $variableName . "', ";
	$update .= "Speciation='" . $speciation . "', ";
	$update .= "VariableUnitsID='" . $variableUnitsID . "', "; 
	$update .= "VariableUnitsName='" . $variableUnitsName . "', ";
	$update .= "SampleMedium='" . $sampleMedium . "', ";
	$update .= "ValueType='" . $valueType . "', ";
	$update .= "TimeSupport='" . $timeSupport . "', ";
	$update .= "TimeunitsID='" . $timeUnitsID . "', ";
	$update .= "TimeunitsName='" . $timeUnitsName . "', ";
	$update .= "DataType='" . $dataType . "', ";
	$update .= "GeneralCategory='" . $generalCategory . "', ";
	$update .= "MethodID='" . $methodID . "', ";
	$update .= "MethodDescription='" . mysql_real_escape_string($methodDescription) . "', ";
	$update .= "SourceID='" . $sourceID . "', ";
	$update .= "Organization='" . mysql_real_escape_string($organization) . "', ";
	$update .= "SourceDescription='" . mysql_real_escape_string($sourceDescription) . "', ";
	$update .= "Citation='" . mysql_real_escape_string($citation) . "', ";
	$update .= "QualityControlLevelID='" . $qualityControlLevelID . "', ";
	$update .= "QualityControlLevelCode='" . $qualityControlLevelCode . "', ";
	$update .= "BeginDateTime='" . $beginDateTime . "', ";
	$update .= "EndDateTime='" . $endDateTime . "', ";
	$update .= "BeginDateTimeUTC='" . $beginDateTimeUTC . "', ";
	$update .= "ValueCount='" . $valueCount . "'";
	$update .= " WHERE SeriesID = " . $series_id . ";";
	
	echo "<pre>" . $update . "</pre>";
	
	$updateresult = mysql_query($update);
	   if (!$updateresult) {
		die("<p>Error in executing the SQL query " . $update . ": " . 
		  mysql_error() . "</p>");
	  }
	  
	  echo "<p>UPDATE SUCCESSFUL!!!</p>";
	  $status["updated"] = 1;
  }
  return $status;
}