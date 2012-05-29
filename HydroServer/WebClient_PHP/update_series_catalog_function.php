<?php
require_once 'database_connection.php';

function update_series_catalog($siteID, $variableID, $methodID, $sourceID, $qcID) {
  
  $status = "error";
  
  //check for an existing seriesID
  $series_id = db_find_seriesid($siteID, $variableID, $methodID, $sourceID, $qcID);
 
$qry = 
'SELECT dv.SiteID, s.SiteCode, s.SiteName, s.SiteType,
dv.VariableID, v.VariableCode, v.VariableName, v.Speciation, 
v.VariableUnitsID, vu.UnitsName, 
v.SampleMedium, v.ValueType, v.TimeSupport, 
v.TimeUnitsID, tu.UnitsName, 
v.DataType, v.GeneralCategory,
m.MethodID, m.MethodDescription, 
sou.SourceID, sou.Organization, sou.SourceDescription, sou.Citation,
qc.QualityControlLevelID, qc.QualityControlLevelCode, ';
$qry .= 'MIN( dv.LocalDateTime ) AS "BeginDateTime", MAX( dv.LocalDateTime ) AS "EndDateTime", ' ; 
$qry .= 'MIN( dv.DateTimeUTC )  AS "BeginDateTimeUTC", MAX( dv.DateTimeUTC )  AS "EndDateTimeUTC", '; 
$qry .= 'COUNT( dv.ValueID ) AS "ValueCount"  ';
$qry .= 'FROM datavalues dv ';
$qry .= 'INNER JOIN sites s ON dv.SiteID = s.SiteID ';
$qry .= 'INNER JOIN variables v ON dv.VariableID = v.VariableID ';
$qry .= 'INNER JOIN units vu ON v.VariableunitsID = vu.UnitsID ';
$qry .= 'INNER JOIN units tu ON v.TimeunitsID = tu.UnitsID ';
$qry .= 'INNER JOIN methods m ON dv.MethodID = m.MethodID ';
$qry .= 'INNER JOIN sources sou ON dv.SourceID = sou.SourceID ';
$qry .= 'INNER JOIN qualitycontrollevels qc ON dv.QualityControlLevelID = qc.QualityControlLevelID ';
$qry .= 'WHERE dv.SiteID = ' . $siteID;
$qry .= ' AND dv.VariableID = ' . $variableID;
$qry .= ' AND dv.MethodID = ' . $methodID;
$qry .= ' AND dv.SourceID = ' . $sourceID;
$qry .= ' AND dv.QualityControlLevelID = ' . $qcID;

   $valuesresult = mysql_query($qry);
   
   if (!$valuesresult) {
    die("<p>Error in executing the SQL query " . $qry . ": " . 
	  mysql_error() . "</p>");
  }
  
  $num_values_rows = mysql_num_rows($valuesresult);
  
  if ($num_values_rows == 0) {
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
	'INSERT INTO seriescatalog (SiteID, SiteCode, SiteName, SiteType,
	VariableID, VariableCode, VariableName, Speciation, VariableunitsID, VariableunitsName,
	SampleMedium, ValueType, TimeSupport, TimeunitsID, TimeunitsName, DataType, GeneralCategory,
	MethodID, MethodDescription,
	SourceID, Organization, SourceDescription, Citation,
	QualityControlLevelID, QualityControlLevelCode,
	BeginDateTime, EndDateTime, BeginDateTimeUTC, EndDateTimeUTC, ValueCount) VALUES (';
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
	
	$insert = utf8_encode($insert);
	
	   $insertresult = mysql_query($insert);
	   if (!$insertresult) {
		die("<p>Error in executing the SQL query " . $insert . ": " . 
		  mysql_error() . "</p>");
	  }
	  $status = "1 row inserted";
  }
  //IF SERIESID IS FOUND: UPDATE
  else {                 
    $update = 'UPDATE seriescatalog SET ';
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
	
	$updateresult = mysql_query($update);
	   if (!$updateresult) {
		die("<p>Error in executing the SQL query " . $update . ": " . 
		  mysql_error() . "</p>");
	  }
	  $status = "1 row updated";
  }
  return $status;
}

function db_find_seriesid($siteID, $variableID, $methodID, $sourceID, $qcID) {
  $query_text = 'SELECT SeriesID FROM seriescatalog WHERE ';
  $query_text .= "SiteID = " . $siteID . " AND VariableID = " . $variableID . " AND MethodID = " . $methodID . " AND SourceID = " . $sourceID . " AND QualityControlLevelID = " . $qcID;
  
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