<?php
/**
 * Created by JetBrains PhpStorm.
 * User: Jiri
 * Date: 5/19/12
 * Time: 1:03 PM
 * To change this template use File | Settings | File Templates.
 */
require_once 'wof.php';
require_once 'REST_service.php';
  
//if the query string contains ?wsdl
$wsdl_is_set = (isset($_REQUEST['wsdl']) or isset($_REQUEST['WSDL']));

//if the POST request contains the SoapACTION parameter
$action_is_set = (isset($_SERVER['HTTP_SOAPACTION']));

//if the query string contains ?op
$op_is_set = (isset($_REQUEST['op']));

//if the request is a REST-style request with parameters in HTTP GET
$method_is_set = (isset($_REQUEST['method']));

//when the SOAPAction is set, call the appropriate web method
if ($action_is_set == 1) {
$action_name = $_SERVER['HTTP_SOAPACTION'];
$action_name2 = str_replace('"', "", $action_name); //removes quotes
$action = substr($action_name2, strlen('http://www.cuahsi.org/his/1.1/ws/'));

//read the input parameters
$postdata = file_get_contents('php://input');
$authtoken = wof_read_authtoken($postdata);

header('Content-Type: text/html; charset=utf-8');

if ($action == 'GetSiteInfo') {
  $site = wof_read_parameter($postdata, 'site');
  GetSiteInfo($authtoken, $site);
  exit;
} elseif ($action == 'GetSiteInfoMultpleObject') {
  $sitesArray = wof_read_site_array($postdata);
  GetSiteInfoMultpleObject($authtoken, $sitesArray);
  exit;
} elseif ($action == 'GetSiteInfoObject') {
  $site = wof_read_parameter($postdata, 'site');
  GetSiteInfoObject($authtoken, $site);
  exit;
} elseif ($action == 'GetSites') {
  GetSites();
  exit;
} elseif ($action == 'GetSitesByBoxObject') {
  $north = wof_read_parameter($postdata, 'north');
  $south = wof_read_parameter($postdata, 'south');
  $east =  wof_read_parameter($postdata, 'east');
  $west = wof_read_parameter($postdata, 'west');
  $IncludeSeries = wof_read_parameter($postdata, 'includeseries');
  GetSitesByBoxObject($north, $south, $east, $west, $IncludeSeries);
  exit;
} elseif ($action == 'GetSitesObject') {
  GetSitesObject();
  exit;
} elseif ($action == 'GetValues') {
  $location = wof_read_parameter($postdata, 'location');
  $variable = wof_read_parameter($postdata, 'variable');
  $startDate =  wof_read_parameter($postdata, 'startDate');
  $endDate = wof_read_parameter($postdata, 'endDate');
  echo 'postdata: ' . $postdata;
  echo $location . $variable . 'startDate:' . $startDate;
  //GetValues($authtoken, $location, $variable, $startDate, $endDate);
  exit;
} elseif ($action == 'GetValuesForASiteObject') {
  $site = wof_read_parameter($postdata, 'site');
  $startDate =  wof_read_parameter($postdata, 'startDate');
  $endDate = wof_read_parameter($postdata, 'endDate');
  GetValuesForASiteObject($authtoken, $site, $startDate, $endDate);
  exit;
} elseif ($action == 'GetValuesObject') {
  $location = wof_read_parameter($postdata, 'location');
  $variable = wof_read_parameter($postdata, 'variable');
  $startDate =  wof_read_parameter($postdata, 'startDate');
  $endDate = wof_read_parameter($postdata, 'endDate');
  GetValuesObject($authtoken, $location, $variable, $startDate, $endDate);
  exit;
} elseif ($action == 'GetVariableInfo') {
  $variable = wof_read_parameter($postdata, 'variable');
  GetVariableInfo($authtoken, $variable);
  exit;
} elseif ($action == 'GetVariableInfoObject') {
  $variable = wof_read_parameter($postdata, 'variable');
  GetVariableInfoObject($authtoken, $variable);
  exit;
} elseif ($action == 'GetVariables') {
  GetVariables();
  exit;
} elseif ($action == 'GetVariablesObject') {
  GetVariablesObject();
  exit;
}
else {
  echo "ACTION NOT FOUND!! " . $action;
  exit;
}
}

//when the op parameter is set, return the web method test page
elseif ($op_is_set == 1) {
$operation_name = $_REQUEST['op'];
$name = 'operations/operation_' . $operation_name . '.html';

// send the right headers
header("Content-Type: text/html");
header("Content-Length: " . filesize($name));
header("File-Name: " . $name);

// display the file and stop this script
readfile($name);
exit;
}

//when the WSDL query string document is set, return the WSDL
elseif ($wsdl_is_set == 1) {

// Return the WSDL
$wsdl = @implode ('', @file ('wateroneflow.wsdl'));
if (strlen($wsdl) > 1) {

  //replace the absolute uri
  //$absolute_uri = "http://localhost:333/HIS/hydroserver/webservice/cuahsi_1_1.php";
  $complete_uri = $_SERVER["SERVER_NAME"] . $_SERVER["REQUEST_URI"];
  $absolute_uri = "http://" . substr($complete_uri, 0, strrpos($complete_uri, '/')) . "/cuahsi_1_1.php";
  $pattern = "/ABSOLUTEURI_TO_REPLACE/";
  $wsdl2 = preg_replace($pattern, $absolute_uri, $wsdl);
  header("Content-type: text/xml");
  echo $wsdl2;
  exit;
}
else {
  header("Status: 500 Internal Server Error");
  header("Content-type: text/plain");
  echo "HTTP/1.0 500 Internal Server Error";
}
}
else if ($method_is_set == 1) {
  $method = $_REQUEST["method"];
  write_REST_response($method);
  exit;
}
else {
  header("Content-Type: text/html");
  $asmx_file_name = 'asmx_page.html';
  header("Content-Length: " . filesize($asmx_file_name));
  header("File-Name: " . $asmx_file_name);

  // display the file and stop this script
  readfile($asmx_file_name);
  exit;
}