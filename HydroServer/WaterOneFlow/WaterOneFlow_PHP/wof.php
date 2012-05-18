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
  $retVal = '<queryInfo><creationTime>' . date('c') . '</creationTime>';
  $retVal .= '<criteria MethodCalled="GetVariables"><parameter name="variable" value="" />';
  $retVal .= "</criteria></queryInfo>";
  return $retVal;  
}

function wof_queryInfo_variable($variable) {
  $retVal = "<queryInfo><creationTime>" . date('c') . "</creationTime>";
  $retVal .= '<criteria MethodCalled="GetVariableInfo">';
  $retVal .= "<variableParam>" . $variable . "</variableParam>";
  $retVal .= '<parameter name="variable" value="' . $variable . '" />';
  $retVal .= "</criteria></queryInfo>";
  return $retVal;
}

function wof_queryInfo_GetSites($site = null) {
  $retVal = '<queryInfo><creationTime>' . date('c') . '</creationTime>';
  $retVal .= '<criteria MethodCalled="GetSites">';
  $retVal .= '<parameter name="site" value="ALL SITES" /></criteria></queryInfo>';
  return $retVal;
}

function wof_queryInfo_site($site = null) {
  $retVal = '<queryInfo><creationTime>' . date('c') . '</creationTime>';
  $retVal .= '<criteria MethodCalled="GetSiteInfo">';
  $retVal .= '<parameter name="site" value="' . $site . '" /></criteria></queryInfo>';
  return $retVal;
}

function wof_queryInfo_MultipleSites($siteArray) {
  $retVal = '<queryInfo><creationTime>' . date('c') . '</creationTime><criteria MethodCalled="GetSiteInfo">';
  foreach($siteArray as $param) {
    $retVal .= '<parameter name="site" value="' . $param . '" />';
  }
  $retVal .= '</criteria></queryInfo>';
  return $retVal;
}

function wof_queryInfo_SitesByBox($north, $south, $east, $west, $IncludeSeries) {
  $retVal = '<queryInfo><creationTime>' . date('c') . '</creationTime>
  <criteria MethodCalled="GetSitesByBoxObject">';
  $retVal .= '<parameter name="north" value="' . $north . '" />';
  $retVal .= '<parameter name="south" value="' . $south . '" />';
  $retVal .= '<parameter name="east" value="' . $east . '" />';
  $retVal .= '<parameter name="west" value="' . $west . '" />';
  $retVal .= '<parameter name="IncludeSeries" value="' . $IncludeSeries . '" />';
  $retVal .= '</criteria></queryInfo>';
  return $retVal;
}

function wof_queryInfo_Values($location, $variable, $startDate, $endDate) {
  $retVal = '<queryInfo><creationTime>' . date('c') . '</creationTime>';
  $retVal .= '<criteria MethodCalled="GetValues">';
  $retVal .= '<parameter name="site" value="' . $location . '" />';
  $retVal .= '<parameter name="variable" value="' . $variable . '" />';
  $retVal .= '<parameter name="startDate" value="' . $startDate . '" />';
  $retVal .= '<parameter name="endDate" value="' . $endDate . '" />';
  $retVal .= '</criteria></queryInfo>';
  return $retVal;
}

function wof_queryInfo_ValuesForSite($site, $startDate, $endDate) {
    $retVal = '<queryInfo><creationTime>' . date('c') . '</creationTime>';
    $retVal .= '<criteria MethodCalled="GetValuesForASite">';
    $retVal .= '<parameter name="site" value="' . $site . '" />';
    $retVal .= '<parameter name="startDate" value="' . $startDate . '" />';
    $retVal .= '<parameter name="endDate" value="' . $endDate . '" />';
    $retVal .= '</criteria></queryInfo>';
    return $retVal;
}

//auxiliary function: gets the <site> element corresponding to the site code
function wof_GetSiteInfoByCode($sitecode, $includeSeriesCatalog) {
  $split = explode(":", $sitecode);
  $shortcode = $split[1]; 
  $retVal = "<site>";
  $retVal .= db_GetSiteByCode($shortcode);
  
  if ($includeSeriesCatalog) {
    $retVal .=  db_GetSeriesCatalog($shortcode);
  }
  $retVal .= '</site>';
  return $retVal;
}

function wof_GetSiteInfo($authToken, $fullSiteCode) {
  $retVal = '<sitesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.cuahsi.org/waterML/1.1/">
  <queryInfo><creationTime>'. date('c') . '</creationTime><criteria MethodCalled="GetSiteInfo"><parameter name="site" value="'. $fullSiteCode . '" /></criteria></queryInfo>';
  
  $split = explode(":", $fullSiteCode);
  $shortcode = $split[1];
  
  $retVal .= "<site>";
  $retVal .= db_GetSiteByCode($shortcode);
  $retVal .=  db_GetSeriesCatalog($shortcode);
  $retVal .= '</site>';
  $retVal .= '</sitesResponse>';
  return $retVal;
}

//returns full information about multiple sites according to the array of site codes
function wof_GetSiteInfoMultipleObject($authToken, $siteArray) {
  $retVal = '<sitesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.cuahsi.org/waterML/1.1/">' .
  wof_queryInfo_MultipleSites($siteArray);
  
  foreach($siteArray as $sitecodeparam) {
    $retVal .= wof_GetSiteInfoByCode($sitecodeparam, true); 
  }
  
  $retVal .= '</sitesResponse>';
  return $retVal;
}

function wof_GetSites() {
  $retVal = '<sitesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.cuahsi.org/waterML/1.1/">';
  $retVal .= wof_queryInfo_GetSites();
  $retVal .= db_GetSites();  
  $retVal .= '</sitesResponse>';
  return $retVal;
}

function wof_GetSitesByBox($west, $south, $east, $north, $IncludeSeries) {
  //TODO add support for IncludeSeries (now assumed FALSE)
  $retVal = '<sitesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.cuahsi.org/waterML/1.1/">';
  $retVal .= wof_queryInfo_SitesByBox($north, $south, $east, $west, $IncludeSeries);
  $retVal .= db_GetSitesByBox($west, $south, $east, $north);
  $retVal .= '</sitesResponse>';
  return $retVal;
}

function wof_GetValues( $authToken, $location, $variable, $startDate, $endDate ) {
    //get the short variable code and short site code
    $shortSiteCode = $location;
    $shortVariableCode = $variable;
    $pos1 = strpos($location, ":");
    if ($pos1 >= 0) {
        $split1 = explode(":", $location);
        $shortSiteCode = $split1[1];
    }
    $pos2 = strpos($variable, ":");
    if ($pos2 >= 0) {
        $split2 = explode(":", $variable);
        $shortVariableCode = $split2[1];
    }
  
    $retVal = '<timeSeriesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">';
    $retVal .= wof_queryInfo_Values($location, $variable, $startDate, $endDate);
    $retVal .= '<timeSeries>';
  
    //write site information
    $retVal .= db_GetSiteByCode($shortSiteCode, "sourceInfo", "SiteInfoType");
  
    //write variable information
    $retVal .= db_GetVariableByCode($shortVariableCode);
  
    //write list of data values
    $retVal .= db_GetValues($shortSiteCode, $shortVariableCode, $startDate, $endDate);
  
    $retVal .= "</timeSeries>";
    $retVal .= "</timeSeriesResponse>";
    return $retVal;
}

function wof_GetValuesForASite( $authToken, $site, $startDate, $endDate ) {
    $shortSiteCode = $site;
    $pos1 = strpos($site, ":");
    if ($pos1 >= 0) {
        $split1 = explode(":", $site);
        $shortSiteCode = $split1[1];
    }

    $retVal = '<timeSeriesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">';
    $retVal .= wof_queryInfo_ValuesForSite($site, $startDate, $endDate);
    $variableCodes = db_GetVariableCodesBySite($shortSiteCode);
    $siteInformation = db_GetSiteByCode($shortSiteCode, "sourceInfo", "SiteInfoType");

    foreach($variableCodes as $varCode ) {
        $retVal .= '<timeSeries>';

        //write site information
        $retVal .= $siteInformation;

        //write variable information
        $retVal .= db_GetVariableByCode($varCode);

        //write list of data values
        $retVal .= db_GetValues($shortSiteCode, $varCode, $startDate, $endDate);

        $retVal .= "</timeSeries>";
    }

    $retVal .= "</timeSeriesResponse>";
    return $retVal;
}

function wof_GetVariables() {
  $retVal = '<variablesResponse xmlns="http://www.cuahsi.org/waterML/1.1/">';
  $retVal .= wof_queryInfo_variables();
  $retVal .= '<variables>';
  $retVal .= db_GetVariableByCode(NULL);
  $retVal .= '</variables></variablesResponse>';	  
  return $retVal;
}

// GetVariableInfo Web Method
function wof_GetVariableInfo($authToken, $variable) {
   
  $retVal = '<variablesResponse>';  
  $retVal .= wof_queryInfo_variable($variable);
  
  //checking for variable code: send NULL or send the short code
  $short_code = NULL;
  if (strlen($variable) > 0) {
    $short_code = substr($variable, strpos($variable, ':') + 1);
  }
  
  $retVal .= '<variables>';
  $retVal .= db_GetVariableByCode($short_code);
  $retVal .= '</variables></variablesResponse>';	  
  return $retVal;
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