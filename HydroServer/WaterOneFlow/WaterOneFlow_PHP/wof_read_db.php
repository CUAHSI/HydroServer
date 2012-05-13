<?php

require_once 'database_connection.php';

function db_GetSeriesCatalog($shortSiteCode) {
  
  //run SQL query
  $query_text = "SELECT s.VariableID, s.VariableCode, s.VariableName, s.ValueType, s.DataType, s.GeneralCategory, s.SampleMedium, 
   s.VariableUnitsName, u.UnitsType, u.UnitsAbbreviation, s.VariableUnitsID, 
   v.NoDataValue, v.IsRegular, s.TimeUnitsName, tu.UnitsType, tu.UnitsAbbreviation, s.TimeUnitsID, s.TimeSupport, s.Speciation, 
   s.ValueCount, s.BeginDateTime, s.EndDateTime, s.BeginDateTimeUTC, s.EndDateTimeUTC, 
   s.SourceID, s.Organization, s.SourceDescription, s.Citation, 
   s.QualityControlLevelID, s.QualityControlLevelCode, qc.Definition, 
   s.MethodID, s.MethodDescription, m.MethodLink
   FROM seriescatalog s
   LEFT JOIN variables v ON s.VariableID = v.VariableID
   LEFT JOIN units u ON s.VariableUnitsID = u.UnitsID
   LEFT JOIN units tu ON s.TimeUnitsID = tu.UnitsID
   LEFT JOIN qualitycontrollevels qc ON s.QualityControlLevelID = qc.QualityControlLevelID 
   LEFT JOIN methods m ON m.MethodID = s.MethodID";
  $query_text .= ' WHERE SiteCode = "' . $shortSiteCode . '"';
  
  $result = mysql_query($query_text);
   
   if (!$result) {
    die("<p>Error in executing the SQL query " . $query_text . ": " . 
	  mysql_error() . "</p>");
  }
  
  $retval = '<seriesCatalog>';
  
  while ($row = mysql_fetch_row($result)) {
  
  $retval .= '<series>';
  $retval .= '<variable>';
  
  $retval .= '<variableCode vocabulary="' . SERVICE_CODE . '" default="true" variableID="' . $row[0] . '">' . $row[1] . '</variableCode>';
  $retval .= "<variableName>{$row[2]}</variableName>";
  $retval .= "<valueType>{$row[3]}</valueType>";
  $retval .= "<dataType>{$row[4]}</dataType>";
  $retval .= "<generalCategory>{$row[5]}</generalCategory>";
  $retval .= "<sampleMedium>{$row[6]}</sampleMedium>";
  $retval .= "<unit><unitName>{$row[7]}</unitName><unitType>{$row[8]}</unitType>";
  $retval .= "<unitAbbreviation>{$row[9]}</unitAbbreviation><unitCode>{$row[10]}</unitCode></unit>";
  $retval .= "<noDataValue>{$row[11]}</noDataValue>";
  $isRegular = "true";
	if ($row[12] === false) {
	  $isRegular = "false";
	}
  $retval .= '<timeScale isRegular="' . $isRegular . '">';
  $retval .= "<unit><unitName>{$row[13]}</unitName><unitType>{$row[14]}</unitType>";
  $retval .= "<unitAbbreviation>{$row[15]}</unitAbbreviation><unitCode>{$row[16]}</unitCode></unit>";
  $retval .= "<timeSupport>{$row[17]}</timeSupport>";
  $retval .= "</timeScale>";
  $retval .= "<speciation>{$row[18]}</speciation>";
  $retval .= "</variable>";
  $retval .= "<valueCount>{$row[19]}</valueCount>";
  $retval .= '<variableTimeInterval xsi:type="TimeIntervalType">';
  $beginTime = str_replace(" ", "T", $row[20]);     //1995-01-02T06:00:00
  $endTime = str_replace(" ", "T", $row[21]);       //2011-10-01T07:00:00
  $beginTimeUTC = str_replace(" ", "T", $row[22]);  //1995-01-02T12:00:00
  $endTimeUTC = str_replace(" ", "T", $row[23]);    //2011-10-01T12:00:00
  $retval .= "<beginDateTime>" . $beginTime . "</beginDateTime>";
  $retval .= "<endDateTime>" . $endTime . "</endDateTime>";
  $retval .= "<beginDateTimeUTC>" . $beginTimeUTC . "</beginDateTimeUTC>";
  $retval .= "<endDateTimeUTC>" . $endTimeUTC . "</endDateTimeUTC>";
  $retval .= "</variableTimeInterval>";
  $retval .= '<method methodID="' . $row[31] . '">';
  $retval .= "<methodCode>" . $row[31] . "</methodCode>";
  $retval .= "<methodDescription>" . $row[32] . "</methodDescription>";
  $retval .= "<methodLink>" . $row[33] . "</methodLink>";
  $retval .= "</method>";
  $retval .= "<source sourceID=\"{$row[24]}\">";
  $retval .= "<organization>{$row[25]}</organization>";
  $retval .= "<sourceDescription>{$row[26]}</sourceDescription>";
  $retval .= "<citation>{$row[27]}</citation>";
  $retval .= "</source>";
  $retval .= "<qualityControlLevel qualityControlLevelID=\"{$row[28]}\">";
  $retval .= "<qualityControlLevelCode>{$row[29]}</qualityControlLevelCode>";
  $retval .= "<definition>{$row[30]}</definition>";
  $retval .= "</qualityControlLevel>";
  $retval .= "</series>";
  }
  $retval .= '</seriesCatalog>';
  return $retval;
}

function db_GetSitesByQuery($query_text, $siteTag="siteInfo", $siteTagType = "") {
  $siteArray[0] = '';
  $result = mysql_query($query_text);
   
   if (!$result) {
    die("<p>Error in executing the SQL query " . $query_text . ": " . 
	  mysql_error() . "</p>");
  }
  $siteIndex = 0; 
  
  $fullSiteTag = $siteTag;
  if ($siteTagType != "") {
    $fullSiteTag = $siteTag . ' xsi:type="' . $siteTagType . '"';
  }
  
  while ($row = mysql_fetch_row($result)) {
  $retval = '';
  $retval .= "<" . $fullSiteTag . ">";
  $retval .= "<siteName>{$row[0]}</siteName>";
  $retval .= '<siteCode network="'. SERVICE_CODE . '">' . $row[2] . "</siteCode>";
  $retval .= '<geoLocation><geogLocation xsi:type="LatLonPointType">';
  $retval .= "<latitude>{$row[3]}</latitude><longitude>{$row[4]}</longitude></geogLocation>";
  
  //local projection info (optional)
  $localProjectionID = $row[5];
  $localX = $row[6];
  $localY = $row[7];
  if ($localProjectionID != '' and $localX != '' and $localY != '') {
    $retval .= '<localSiteXY projectionInformation="' . $localProjectionID . "<X>{$localX}</X><Y>{$localY}</Y></localSiteXY>";
  }
  
  $retval .= "</geoLocation>";
  
  $elevation_m = $row[8];
  if ($elevation_m != '') {
    $retval .= "<elevation_m>{$elevation_m}</elevation_m>";
  }
  $verticalDatum = $row[9];
  if ($verticalDatum != '') {
    $retval .= "<verticalDatum>{$verticalDatum}</verticalDatum>";
  }
  $retval .= '<note type="custom" title="my note">MyHydroServer</note>';
  $retval .= "</" . $siteTag . ">";
  $siteArray[$siteIndex] = $retval;
  $siteIndex++;
  }
  return $siteArray;
}

function createQuery_GetAllSites() {
  $query_text = 
  'SELECT SiteName, SiteID, SiteCode, Latitude, Longitude, SRSID, LocalX, LocalY, Elevation_m, VerticalDatum, State, County, Comments
   FROM sites LEFT JOIN spatialreferences ON sites.LocalProjectionID = spatialreferences.SpatialReferenceID';
   return $query_text;
}

function createQuery_GetSiteByCode($shortcode) {
  $where = ' WHERE SiteCode = "'. $shortcode . '"';
  return createQuery_GetAllSites() . $where;
}

function createQuery_GetSitesByCodes($fullSiteCodeArray) {
  //split array of site codes
  $where = 'WHERE SiteCode IN (';
  foreach($fullSiteCodeArray as $fullCode) {
    $split = explode(":", $fullCode);
	$shortCode = $split[1];
	$where .= '"' . $shortCode . '",';
  }
  $whereStr = substr($where, 0, strlen($where) - 1);
  $whereStr .= ")";
  
  //run SQL query
  $query_text = createQuery_GetAllSites() . $whereStr;
  return $query_text;
}

function db_GetSiteByCode($shortcode, $siteTag="siteInfo", $siteTagType="") {
  $query_text = createQuery_GetSiteByCode($shortcode);
  $sitesArray = db_GetSitesByQuery($query_text, $siteTag, $siteTagType);
  return $sitesArray[0]; //what if no site is found?
}

function db_GetSiteByID($siteID, $siteTag="siteInfo", $siteTagType="") {
  $query_text = createQuery_GetSiteByCode($shortcode);
  $sitesArray = db_GetSitesByQuery($query_text, $siteTag, $siteTagType);
  return $sitesArray[0]; //what if no site is found?
}

function db_GetSites() {    
  $query_text = createQuery_GetAllSites(); 
  $sitesArray = db_GetSitesByQuery($query_text);
  $retval = ''; 
  
  foreach($sitesArray as $site) {
	$retval .= "<site>";
	$retval .= $site;
	$retval .= "</site>";
  }
  return $retval;
}

function db_GetSitesByCodes($fullSiteCodeArray) {
  $query_text = createQuery_GetSitesByCodes($fullSiteCodeArray);
  return db_GetSitesByQuery($query_text);
}

function db_GetVariableByCode($shortvariablecode = NULL) {
  
  //run SQL query
  $query_text = 
  'SELECT VariableID, VariableCode, VariableName, ValueType, DataType, GeneralCategory, SampleMedium,  
   u1.UnitsName AS "VariableUnitsName", u1.UnitsType AS "VariableUnitsType", u1.UnitsAbbreviation AS "VariableUnitsAbbreviation", 
   VariableUnitsID, NoDataValue, IsRegular, 
   u2.UnitsName AS "TimeUnitsName", u2.UnitsType AS "TimeUnitsType", u2.UnitsAbbreviation AS "TimeUnitsAbbreviation", 
   TimeUnitsID, TimeSupport, Speciation
   FROM variables
   LEFT JOIN units u1 ON variables.VariableUnitsID = u1.UnitsID
   LEFT JOIN units u2 ON variables.TimeUnitsID = u2.UnitsID';
   
   if (!is_null($shortvariablecode)) {
     $query_text .= ' WHERE VariableCode = "' . $shortvariablecode .'"';
   }

   $result = mysql_query($query_text);
  
  if (!$result) {
    die("<p>Error in executing the SQL query " . $query_text . ": " . 
	  mysql_error() . "</p>");
  }
  
  $retval = '';
  
  while ($row = mysql_fetch_row($result)) {
    $retval .= '<variable>';
	$retval .= '<variableCode vocabulary="' . SERVICE_CODE . '" default="true" variableID="' . $row[0] . '">' . $row[1] . '</variableCode>';
	$retval .= "<variableName>{$row[2]}</variableName>";
	$retval .= "<valueType>{$row[3]}</valueType>";
	$retval .= "<dataType>{$row[4]}</dataType>";
	$retval .= "<generalCategory>{$row[5]}</generalCategory>";
	$retval .= "<sampleMedium>{$row[6]}</sampleMedium>";
	$retval .= "<unit><unitName>{$row[7]}</unitName><unitType>{$row[8]}</unitType><unitAbbreviation>{$row[9]}</unitAbbreviation><unitCode>{$row[10]}</unitCode></unit>";
	$retval .= "<noDataValue>-9.99</noDataValue>";
	$isRegular = "true";
	if ($row[11] === false) {
	  $isRegular = "false";
	}
	$retval .= '<timeScale isRegular="' . $isRegular . '">';
	$retval .= "<unit><unitName>{$row[13]}</unitName><unitType>{$row[14]}</unitType><unitAbbreviation>{$row[15]}</unitAbbreviation><unitCode>{$row[16]}</unitCode></unit>";
    $retval .= "<timeSupport>{$row[12]}</timeSupport>";
	$retval .= "</timeScale>";
	$retval .= "<speciation>Not Applicable</speciation>";
	$retval .= '</variable>';
  } 
  return $retval;
}

function createQuery_TimeRange($startTime, $endTime) {
  //time range query..
  $query = "( (BeginDateTime <= '" . $startTime . "' AND EndDateTime >= '" . $endTime . "' )";
  $query .= " OR (BeginDateTime >= '" . $startTime . "' AND BeginDateTime <= '" . $endTime . "' )";
  $query .= " OR (EndDateTime >= '" . $startTime . "' AND EndDateTime <= '" . $endTime . "') )";
  return $query;
}

function db_GetValues($siteCode, $variableCode, $beginTime, $endTime) {
  //first get the metadata
  $querymeta = "SELECT SiteID, VariableID, MethodID, SourceID, QualityControlLevelID FROM seriescatalog WHERE SiteCode = '";
  $querymeta .= $siteCode . "' AND VariableCode = '" . $variableCode . "'";
  $querymeta .= " AND " . createQuery_TimeRange($beginTime, $endTime);
  
  $result = mysql_query($querymeta);
   
   if (!$result) {
    die("<p>Error in executing the SQL query " . $querymeta . ": " . 
	  mysql_error() . "</p>");
  }
  
  $numSeries = $num_rows = mysql_num_rows($result);
  
  if ($numSeries == 0) {
    return "<values />";
  }
  else if ($numSeries == 1) {
    
	$row = mysql_fetch_row($result);
	
	return db_GetValues_OneSeries($row[0], $row[1], $row[2], $row[3], $row[4], $beginTime, $endTime); 
  }
  else {
    
	$row = mysql_fetch_row($result);
    return db_GetValues_MultipleSeries($row[0], $row[1], $beginTime, $endTime);
  }
}

function db_GetValues_OneSeries($siteID, $variableID, $methodID, $sourceID, $qcID, $beginTime, $endTime) {
  $queryval = "SELECT LocalDateTime, UTCOffset, DateTimeUTC, DataValue FROM datavalues WHERE ";
  $queryval .= "SiteID={$siteID} AND VariableID={$variableID} AND MethodID={$methodID} AND SourceID={$sourceID} AND QualityControlLevelID={$qcID}";
  $queryval .= " AND LocalDateTime >= '" . $beginTime . "' AND LocalDateTime <= '" . $endTime . "'";
  
  $result = mysql_query($queryval);  
   if (!$result) {
    die("<p>Error in executing the SQL query " . $queryval . ": " . 
	  mysql_error() . "</p>");
  }
  $retval = "<values>";
  $metadata = 'methodCode="' . $methodID . '" sourceCode="' . $sourceID . '" qualityControlLevelCode="' . $qcID . '"';
  while($row = mysql_fetch_row($result)) {
    $retval .= '<value censorCode="nc" dateTime="' . $row[0] . '"';
	$retval .= ' timeOffset="' . $row[1] . '" dateTimeUTC="' . $row[2] . '" ';
	$retval .= $metadata;
	$retval .= ">{$row[3]}</value>";
  }
  $retval .= db_GetQualityControlLevelByID($qcID);
  $retval .= db_GetMethodByID($methodID);
  $retval .= db_GetSourceByID($sourceID);
  
  $retval .= "<censorCode><censorCode>nc</censorCode><censorCodeDescription>not censored</censorCodeDescription></censorCode>";
  
  $retval .= "</values>";
  
  return $retval;
}

function db_GetValues_MultipleSeries($siteID, $variableID, $beginTime, $endTime) {
  $queryval = "SELECT LocalDateTime, UTCOffset, DateTimeUTC, MethodID, SourceID, QualityControlLevelID, DataValue FROM datavalues WHERE ";
  $queryval .= "SiteID={$siteID} AND VariableID={$variableID}";
  $queryval .= " AND LocalDateTime >= '" . $beginTime . "' AND LocalDateTime <= '" . $endTime . "'";
  
  $result = mysql_query($queryval);  
   if (!$result) {
    die("<p>Error in executing the SQL query " . $queryval . ": " . 
	  mysql_error() . "</p>");
  }
  $retval = "<values>";
  //$metadata = 'methodCode="' . $methodID . '" sourceCode="' . $sourceID . '" qualityControlLevelCode="' . $qcID . '"';
  while($row = mysql_fetch_row($result)) {
    $retval .= '<value censorCode="nc" dateTime="' . $row[0] . '"';
	$retval .= ' timeOffset="' . $row[1] . '" dateTimeUTC="' . $row[2] . '"';
	$retval .= ' methodCode="' . $row[3] . '" ';
	$retval .= ' sourceCode="' . $row[4] . '" ';
	$retval .= ' qualityControlLevelCode="' . $row[5] . '" ';
	$retval .= ">{$row[6]}</value>";
  }
  
  $retval .= "<censorCode><censorCode>nc</censorCode><censorCodeDescription>not censored</censorCodeDescription></censorCode>";
  
  $retval .= "</values>";
  return $retval;
}

function db_GetQualityControlLevelByID($qcID) {
  $query = "SELECT QualityControlLevelCode, Definition, Explanation FROM qualitycontrollevels WHERE QualityControlLevelID = " . $qcID;
  $result = mysql_query($query);  
   if (!$result) {
    die("<p>Error in executing the SQL query " . $query . ": " . 
	  mysql_error() . "</p>");
  }
  
  $row = mysql_fetch_row($result);
  $retval = '<qualityControlLevel qualityControlLevelID="' . $qcID . '">';
  $retval .= "<qualityControlLevelCode>" . $row[0] . "</qualityControlLevelCode>";
  $retval .= "<definition>" . $row[1] . "</definition>";
  $retval .= "<explanation>" . $row[2] . "</explanation>";
  $retval .= "</qualityControlLevel>";
  return $retval;
}

function db_GetMethodByID($methodID) {
  $query = "SELECT MethodDescription, MethodLink FROM methods WHERE MethodID = " . $methodID;
  $result = mysql_query($query);  
   if (!$result) {
    die("<p>Error in executing the SQL query " . $query . ": " . 
	  mysql_error() . "</p>");
  }
  
  $row = mysql_fetch_row($result);
  $retval = '<method methodID="' . $methodID . '"><methodCode>' . $methodID . "</methodCode>";
  $retval .= "<methodDescription>" . $row[0] . "</methodDescription>";
  $retval .= "<methodLink>" . $row[1] . "</methodLink>";
  $retval .= "</method>";
  return $retval;
}

function db_GetSourceByID($sourceID) {
  $query = "SELECT Organization, SourceDescription, ContactName, Phone, Email, Address, City, State, ZipCode, SourceLink, ";
  $query .= "Citation FROM sources WHERE SourceID = " . $sourceID;
  $result = mysql_query($query);  
   if (!$result) {
    die("<p>Error in executing the SQL query " . $query . ": " . 
	  mysql_error() . "</p>");
  }
  $row = mysql_fetch_row($result);
  
  $retval = '<source sourceID="' . $sourceID . '">';
  $retval .= "<sourceCode>" . $sourceID . "</sourceCode>";
  $retval .= "<organization>" . $row[0] . "</organization>";
  $retval .= "<sourceDescription>" . $row[1] . "</sourceDescription>";
  $retval .= "<contactInformation>";
  $retval .= "<contactName>" . $row[2] . "</contactName>";
  $retval .= "<typeOfContact>main</typeOfContact>";
  $retval .= "<email>" . $row[3] . "</email>";
  $retval .= "<phone>" . $row[4] . "</phone>";
  $retval .= '<address xsi:type="xsd:string">' . $row[5] . ", " . $row[6] . ", " . $row[7] . ", " . $row[8];
  $retval .=  "</address></contactInformation>";
  $retval .= "<sourceLink>" . $row[9] . "</sourceLink>";
  $retval .= "<citation>" . $row[10]. "</citation>";
  $retval .= "</source>";
  return $retval;
}
?>