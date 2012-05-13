<?php

require_once 'wof_read_db.php';

function wof_read_parameter($soap_envelope, $parameter_name) {
  
  // parts to test--> parameter name may contain a prefix. parameter name
  // may be empty tag
  
  //case 1 test for an empty tag such as <variable />
  $empty_tag_pattern = "/<\s*[ws:]*" . $parameter_name . "\s*\/>/";'<' . $parameter_name . '/>';
  //case 2 test for a populated tag such as <variable>VALUE</variable>
  $full_tag_pattern =  "/<\s*[ws:]*" . $parameter_name . "\s*>(.*?)<\/\s*[ws:]*" . $parameter_name . "\s*>/";
  
  $num_matches = preg_match($full_tag_pattern, $soap_envelope, $matches);
  
  if ($num_matches == 1) {
    $result = $matches[1];
	return $result;
  }
  else {
    //no match found: interpret this as an empty parameter
	return "";
  }
}

function wof_read_authtoken($soap_envelope) {
  
  $pos1 = stripos($soap_envelope, "<authtoken>");
  
  if ($pos1 === false) {
    return "";
  }
  else {
    $pos2 = stripos($soap_envelope, "</authtoken>");
	if ($pos2 === false) {
	  return "";
	}
	$result = substr($soap_envelope, $pos1 + 12, $pos2 - $pos1 - 12);
	return $result;
  }
}

//special case - reads an array of sites
function wof_read_site_array($soap_envelope) {  
  $pattern = "/<string>(.*)<\/string>/";
  preg_match_all($pattern, $soap_envelope, $matches);
  return $matches[1];
}

//given a full site code NETWORK:CODE returns the CODE part
function wof_GetShortSiteCode($full_site_code) {  
  return substr($full_site_code, strpos($full_site_code, ':') + 1);
}

//given a full site code NETWORK:CODE returns the NETWORK part
function wof_GetSiteNetwork($full_site_code) {
  return substr($full_site_code, 0, strpos($full_site_code, ':'));
}

//this function writes the header, the xml declaration and the SOAP:Envelope elements
function wof_start() {
  //Set the content-type header to xml
  header("Content-type: text/xml");
  //echo the XML declaration
  echo chr(60).chr(63).'xml version="1.0" encoding="utf-8" '.chr(63).chr(62);
  echo '<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><soap:Body>';
}

function wof_finish() {
  echo '</soap:Body></soap:Envelope>';
}

function wof_queryInfo_variables() {
  $retval = '<queryInfo><creationTime>' . date('c') . '</creationTime>';
  $retval .= '<criteria MethodCalled="GetVariables"><parameter name="variable" value="" />';
  $retval .= "</criteria></queryInfo>";
  return $retval;  
}

function wof_queryInfo_variable($variable) {
  $retval = "<queryInfo><creationTime>" . date('c') . "</creationTime>";
  $retval .= '<criteria MethodCalled="GetVariableInfo">';
  $retval .= "<variableParam>" . $variable . "</variableParam>";
  $retval .= '<parameter name="variable" value="' . $variable . '" />';
  $retval .= "</criteria></queryInfo>";
  return $retval;
}

function wof_queryInfo_GetSites($site = null) {
  $retval = '<queryInfo><creationTime>' . date('c') . '</creationTime>';
  $retval .= '<criteria MethodCalled="GetSites">';
  $retval .= '<parameter name="site" value="ALL SITES" /></criteria></queryInfo>';
  return $retval;
}

function wof_queryInfo_site($site = null) {
  $retval = '<queryInfo><creationTime>' . date('c') . '</creationTime>';
  $retval .= '<criteria MethodCalled="GetSiteInfo">';
  $retval .= '<parameter name="site" value="' . $site . '" /></criteria></queryInfo>';
  return $retval;
}

function wof_queryInfo_MultipleSites($siteArray) {
  $retval = '<queryInfo><creationTime>' . date('c') . '</creationTime><criteria MethodCalled="GetSiteInfo">';
  foreach($siteArray as $param) {
    $retval .= '<parameter name="site" value="' . $param . '" />';
  }
  $retval .= '</criteria></queryInfo>';
  return $retval;
}

function wof_queryInfo_SitesByBox($north, $south, $east, $west, $IncludeSeries) {
  $retval = '<queryInfo><creationTime>' . date('c') . '</creationTime>
  <criteria MethodCalled="GetSitesByBoxObject">';
  $retval .= '<parameter name="north" value="' . $north . '" />';
  $retval .= '<parameter name="south" value="' . $south . '" />';
  $retval .= '<parameter name="east" value="' . $east . '" />';
  $retval .= '<parameter name="west" value="' . $west . '" />';
  $retval .= '<parameter name="IncludeSeries" value="' . $IncludeSeries . '" />';
  $retval .= '</criteria></queryInfo>';
  return $retval;
}

function wof_queryInfo_Values($location, $variable, $startDate, $endDate) {
  $retval = '<queryInfo><creationTime>' . date('c') . '</creationTime>';
  $retval .= '<criteria MethodCalled="GetValues">';
  $retval .= '<parameter name="site" value="' . $location . '" />';
  $retval .= '<parameter name="variable" value="' . $variable . '" />';
  $retval .= '<parameter name="startDate" value="' . $startDate . '" />';
  $retval .= '<parameter name="endDate" value="' . $endDate . '" />';
  $retval .= '</criteria></queryInfo>';
  return $retval;
}

//auxiliary function: gets the <site> element corresponding to the site code
function wof_GetSiteInfoByCode($sitecode, $includeSeriesCatalog) {
  $split = explode(":", $sitecode);
  $shortcode = $split[1]; 
  $retval = "<site>";
  $retval .= db_GetSiteByCode($shortcode);
  
  if ($includeSeriesCatalog) {
    $retval .=  db_GetSeriesCatalog($shortcode);
  }
  $retval .= '</site>';
  return $retval;
}

function wof_GetSiteInfo($authToken, $fullSiteCode) {
  $retval = '<sitesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.cuahsi.org/waterML/1.1/">
  <queryInfo><creationTime>'. date('c') . '</creationTime><criteria MethodCalled="GetSiteInfo"><parameter name="site" value="'. $fullSiteCode . '" /></criteria></queryInfo>';
  
  $split = explode(":", $fullSiteCode);
  $shortcode = $split[1];
  
  $retval .= "<site>";
  $retval .= db_GetSiteByCode($shortcode);
  $retval .=  db_GetSeriesCatalog($shortcode);
  $retval .= '</site>';
  $retval .= '</sitesResponse>';
  return $retval;
}

//returns full information about multiple sites according to the array of site codes
function wof_GetSiteInfoMultipleObject($authToken, $siteArray) {
  $retval = '<sitesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.cuahsi.org/waterML/1.1/">' .
  wof_queryInfo_MultipleSites($siteArray);
  
  foreach($siteArray as $sitecodeparam) {
    $retval .= wof_GetSiteInfoByCode($sitecodeparam, true); 
  }
  
  $retval .= '</sitesResponse>';
  return $retval;
}

function wof_GetSites() {
  $retval = '<sitesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.cuahsi.org/waterML/1.1/">';
  $retval .= wof_queryInfo_GetSites();
  $retval .= db_GetSites();  
  $retval .= '</sitesResponse>';
  return $retval;
}

function wof_GetSitesByBox($west, $south, $east, $north, $IncludeSeries) {
  //TODO add support for IncludeSeries (now assumed FALSE)
  $retval = '<sitesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.cuahsi.org/waterML/1.1/">';
  $retval .= wof_queryInfo_SitesByBox($north, $south, $east, $west, $IncludeSeries);
  $retval .= db_GetSitesByBox($west, $south, $east, $north);
  $retval .= '</sitesResponse>';
  return $retval;
}

function wof_GetValues($authToken, $location, $variable, $startDate, $endDate) {
  
  //get the short variable code and short site code
  $split1 = explode(":", $location);
  $shortSiteCode = $split1[1];
  $split2 = explode(":", $variable);
  $shortVariableCode = $split2[1];
  
  $retval = '<timeSeriesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">';
  $retval .= wof_queryInfo_Values($location, $variable, $startDate, $endDate);
  $retval .= '<timeSeries>';
  
  //write site information
  $retval .= db_GetSiteByCode($shortSiteCode, "sourceInfo", "SiteInfoType");
  
  //write variable information
  $retval .= db_GetVariableByCode($shortVariableCode);
  
  //write list of data values
  $retval .= db_GetValues($shortSiteCode, $shortVariableCode, $startDate, $endDate);
  
  $retval .= "</timeSeries>";
  $retval .= "</timeSeriesResponse>";
  return $retval;
}

function wof_GetValuesForASite($authToken, $site, $startDate, $endDate) { 
  //todo write xml code here
}

function wof_GetVariables() {
  $retval = '<variablesResponse xmlns="http://www.cuahsi.org/waterML/1.1/">';
  $retval .= wof_queryInfo_variables();
  $retval .= '<variables>';
  $retval .= db_GetVariableByCode(NULL);
  $retval .= '</variables></variablesResponse>';	  
  return $retval;
}

// GetVariableInfo Web Method
function wof_GetVariableInfo($authToken, $variable) {
   
  $retval = '<variablesResponse>';  
  $retval .= wof_queryInfo_variable($variable);
  
  //checking for variable code: send NULL or send the short code
  $short_code = NULL;
  if (strlen($variable) > 0) {
    $short_code = substr($variable, strpos($variable, ':') + 1);
  }
  
  $retval .= '<variables>';
  $retval .= db_GetVariableByCode($short_code);
  $retval .= '</variables></variablesResponse>';	  
  return $retval;
}

function GetSiteInfo($authToken, $site) {
  wof_start();
  echo '<GetSiteInfoResponse xmlns="http://www.cuahsi.org/his/1.1/ws/"><GetSiteInfoResult>';
  echo htmlspecialchars(wof_GetSiteInfo($authToken, $site));
  echo '</GetSiteInfoResult></GetSiteInfoResponse>';
  wof_finish();
}

function GetSiteInfoObject($authToken, $site) {
  wof_start();
  echo '<GetSiteInfoObjectResponse xmlns="http://www.cuahsi.org/his/1.1/ws/">';
  echo wof_GetSiteInfo($authToken, $site);
  echo '</GetSiteInfoObjectResponse>';
  wof_finish();
}

function GetSiteInfoMultpleObject($authToken, $sitearray) {
  wof_start();
  echo '<GetSiteInfoMultpleObjectResponse xmlns="http://www.cuahsi.org/his/1.1/ws/">';
  echo wof_GetSiteInfoMultipleObject($authToken, $sitearray);
  echo '</GetSiteInfoMultpleObjectResponse>';
  wof_finish();
}

function GetSites() {
  wof_start();
  echo '<GetSitesResponse xmlns="http://www.cuahsi.org/his/1.1/ws/"><GetSitesResult>';
  echo htmlspecialchars(wof_GetSites());
  echo '</GetSitesResult></GetSitesResponse>';
  wof_finish();
}

function GetSitesByBoxObject($north, $south, $east, $west, $includeSeries) {
  wof_start();
  echo '<GetSitesByBoxObjectResponse xmlns="http://www.cuahsi.org/his/1.1/ws/">';
  echo wof_GetSitesByBox($west, $south, $east, $north, $includeSeries);
  echo '</GetSitesByBoxObjectResponse>';
  wof_finish();
}

function GetSitesObject() {
  wof_start();
  echo '<GetSitesObjectResponse xmlns="http://www.cuahsi.org/his/1.1/ws/">';
  echo wof_GetSites();
  echo '</GetSitesObjectResponse>';
  wof_finish();
}

function GetValues($authToken, $location, $variable, $startDate, $endDate) {
  wof_start();
  echo '<GetValuesResponse xmlns="http://www.cuahsi.org/his/1.1/ws/"><GetValuesResult>';
  echo htmlspecialchars(wof_GetValues($authToken, $location, $variable, $startDate, $endDate));
  echo '</GetValuesResult></GetValuesResponse>';
  wof_finish();
}

function GetValuesForASiteObject($authToken, $site, $startDate, $endDate) {
  wof_start();
  echo '<GetValuesForASiteObjectResponse xmlns="http://www.cuahsi.org/his/1.1/ws/">';
  echo wof_GetValuesForASite($authToken, $site, $startDate, $endDate);
  echo '</GetValuesForASiteObjectResponse>';
  wof_finish();
}

function GetValuesObject($authToken, $location, $variable, $startDate, $endDate) {
  wof_start();
  echo '<TimeSeriesResponse xmlns="http://www.cuahsi.org/waterML/1.1/">';
  echo wof_GetValues($authToken, $location, $variable, $startDate, $endDate);
  echo '</TimeSeriesResponse>';
  wof_finish();
}

function GetVariableInfo($authToken, $variable) {
  wof_start();
  echo '<GetVariableInfoResponse xmlns="http://www.cuahsi.org/his/1.1/ws/"><GetVariableInfoResult>';
  echo htmlspecialchars(wof_GetVariableInfo($authToken, $variable));
  echo '</GetVariableInfoResult></GetVariableInfoResponse>';
  wof_finish();
}

function GetVariableInfoObject($authToken, $variable) {
  wof_start();
  echo '<VariablesResponse  xmlns="http://www.cuahsi.org/waterML/1.1/">';
  echo wof_GetVariableInfo($authToken, $variable);
  echo '</VariablesResponse>';
  wof_finish();
}

function GetVariables() {
  wof_start();
  echo '<GetVariablesResponse xmlns="http://www.cuahsi.org/his/1.1/ws/"><GetVariablesResult>';
  echo htmlspecialchars(wof_GetVariables());
  echo '</GetVariablesResult></GetVariablesResponse>';
  wof_finish();
}

function GetVariablesObject() {
  wof_start();
  echo '<GetVariablesObjectResponse xmlns="http://www.cuahsi.org/his/1.1/ws/">';
  echo wof_GetVariables();
  echo '</GetVariablesObjectResponse>';
  wof_finish();
}

?>