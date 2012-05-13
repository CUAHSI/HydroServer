<?php

//this function writes the header, the xml declaration and the SOAP:Envelope elements
function wof_start() {
  //Set the content-type header to xml
  header("Content-type: text/xml");
  //echo the XML declaration
  echo chr(60).chr(63).'xml version="1.0" encoding="utf-8" '.chr(63).chr(62);
  echo '<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><soap:Body>';
}

function wof_finish() {
  echo '</soap:Body>
      </soap:Envelope>';
}

function wof_get_sites() {
  $retval = '<sitesResponse xmlns="http://www.cuahsi.org/waterML/1.1/">' .
  wof_queryInfo('GetSites') .
  '<site>
  <siteInfo>
  <siteName>MY TEST SITE ONE</siteName>
  <siteCode network="GHCN">USW00003160</siteCode>
  <geoLocation>
  <geogLocation xsi:type="LatLonPointType"><latitude>36.62</latitude><longitude>-116.03</longitude></geogLocation>
  <localSiteXY projectionInformation="EPSG:4326"><X>-116.03</X><Y>36.62</Y></localSiteXY>
  </geoLocation>
  <elevation_m>985</elevation_m>
  <verticalDatum>Unknown</verticalDatum>
  <note type="custom" title="my note">GHCN</note>
  </siteInfo>
  </site>' .
  '<site>
  <siteInfo>
  <siteName>MY TEST SITE TWO</siteName>
  <siteCode network="GHCN">USW00003160</siteCode>
  <geoLocation>
  <geogLocation xsi:type="LatLonPointType"><latitude>36.62</latitude><longitude>-115.03</longitude></geogLocation>
  <localSiteXY projectionInformation="EPSG:4326"><X>-115.03</X><Y>36.62</Y></localSiteXY>
  </geoLocation>
  <elevation_m>985</elevation_m>
  <verticalDatum>Unknown</verticalDatum>
  <note type="custom" title="my note">GHCN</note>
  </siteInfo>
  </site>' .
  '</sitesResponse>';
  return $retval;
}

function wof_get_variables() {
  $retval = '<variablesResponse xmlns="http://www.cuahsi.org/waterML/1.1/">' .
  wof_queryInfo('GetVariables') .
'<variables>
<variable>
<variableCode vocabulary="GHCN" default="true">8</variableCode>' .
'<variableName>Precipitation</variableName>' .
'<valueType>Field Observation</valueType>
<dataType>Incremental</dataType>
<generalCategory>Climate</generalCategory>
<sampleMedium>Precipitation</sampleMedium>
<unit unitID="1">
<unitName>millimeter</unitName>
<unitDescription>millimeter</unitDescription>
<unitType>Length</unitType>
<unitAbbreviation>mm</unitAbbreviation>
              <unitCode>54</unitCode>
            </unit>
            <noDataValue>-9999</noDataValue>
            <timeScale isRegular="true">
              <unit>
                <unitName>day</unitName>
                <unitType>Time</unitType>
                <unitAbbreviation>d</unitAbbreviation>
                <unitCode>104</unitCode>
</unit>
<timeSupport>0</timeSupport>
</timeScale>
<speciation>Not Applicable</speciation>
</variable>
</variables>
</variablesResponse>';
	  
	return $retval;
}

function wof_queryInfo($MethodCalled, $parameters = null) {
  return 
  '<queryInfo>
   <creationTime>2012-04-11T07:16:11.2611662+02:00</creationTime>
   <criteria MethodCalled="'. $MethodCalled . '">
   <parameter name="variable" value="" />
   </criteria>
   </queryInfo>'; 
}

function GetVariables($variable_name) {
  wof_start();
  echo '<GetVariablesResponse xmlns="http://www.cuahsi.org/his/1.1/ws/"><GetVariablesResult>';
  echo htmlspecialchars(wof_get_variables());
  echo '</GetVariablesResult></GetVariablesResponse>';
  wof_finish();
}

function GetVariablesObject($variable_name) {
  wof_start();
  echo '<GetVariablesObjectResponse xmlns="http://www.cuahsi.org/his/1.1/ws/">';
  echo wof_get_variables();
  echo '</GetVariablesObjectResponse>';
  wof_finish();
}

function GetSites() {
  wof_start();
  echo '<GetSitesResponse xmlns="http://www.cuahsi.org/his/1.1/ws/"><GetSitesResult>';
  echo htmlspecialchars(wof_get_sites());
  echo '</GetSitesResult></GetSitesResponse>';
  wof_finish();
}

function GetSitesObject() {
  wof_start();
  echo '<GetSitesObjectResponse xmlns="http://www.cuahsi.org/his/1.1/ws/">';
  echo wof_get_sites();
  echo '</GetSitesObjectResponse>';
  wof_finish();
}

?>