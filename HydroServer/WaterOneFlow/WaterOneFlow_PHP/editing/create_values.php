<?php
/**
 * Add one or more sites to the database
 * Requires an user name and password.
 * User: Jiri
 * Date: 5/18/12
 * Time: 10:45 AM
 * To change this template use File | Settings | File Templates.
 */

require_once('database_connection.php');
require_once('db_helper.php');

//get the token
if (isset($_POST["authToken"])) {
  $token = $_POST["authToken"];
}
else {
  if (isset($_SERVER['HTTP_AUTHTOKEN'])) {
    $token = $_SERVER['HTTP_AUTHTOKEN'];
  }
  else {
    echo 'not authorized (unspecified token).';
	exit;
  }
}

if (!validate_token($token)) {
  header('HTTP/1.0 403 Forbidden');
  header ("Content-Type:text/xml");
  echo '<response>not authorized (invalid token).</response>';
  exit;
}

//get the site code
if (isset($_POST["siteCode"])) {
$site_code = $_POST["siteCode"];
}
else {
	return_error('Site Code is not specified.');
}

//get the variable code
if (isset($_POST["variableCode"])) {
	$variable_code = $_POST["variableCode"];
}else {
	return_error('Variable code is not specified.');
}

//get the format (XML)
$format = "XML";
if (isset($_POST["format"])) {
	$format = $_POST["format"];
}
$data = 'EMPTY-DATA';
if (isset($_POST["data"])) {
	$data = $_POST["data"];
}
else {
	//get the sites POST data
	$data = file_get_contents('php://input');
}

//validate SiteID and VariableID
$site_id = get_valid_site_id($site_code);
if ($site_id < 1) {
	return_error( "site ID not found for code: " . $site_code);
}
$variable_id = get_valid_variable_id($variable_code);
if ($variable_id < 1) {
	return_error( "variable ID not found for code: " . $variable_code);
}

//todo read method, source, qc

$source_id = get_valid_source_id();

if ($format == "XML") {
    $xml = simplexml_load_string($data);

	foreach($xml->children() as $val) {
		$attr = $val->attributes();
		$time = $attr['DateTimeUTC'];
		$data_value = $val[0];
		save_value($site_id, $variable_id, $source_id, $time, $data_value);
	}
}
else {
	echo '<p>CSV format is not yet supported.</p>';
}

function get_valid_site_id($site_code) {
	$query = 'SELECT SiteID FROM Sites WHERE SiteCode = "' . $site_code . '"';
	
	$result = mysql_query($query);
	if (!$result) {
		die("<p>Error validating site code" . $query . ": " . 
	  	mysql_error() . "</p>");
	}
	
	$nr = mysql_num_rows($result);
	if ($nr > 0) {
		$arr = mysql_fetch_array($result);
		$id = $arr[0];
		return $id;
	}
	else {
		return 0;
	}
}

function get_valid_variable_id($variable_code) {
	$query = 'SELECT VariableID FROM Variables WHERE VariableCode = "' . $variable_code . '"';
	
	$result = mysql_query($query);
	if (!$result) {
		die("<p>Error validating site code" . $query . ": " . 
	  	mysql_error() . "</p>");
	}
	
	$nr = mysql_num_rows($result);
	if ($nr > 0) {
		$arr = mysql_fetch_array($result);
		$id = $arr[0];
		return $id;
	}
	else {
		return 0;
	}
}

function get_valid_source_id() {
	$query = 'SELECT SourceID FROM sources';
	$result = mysql_query($query);
	if (!$result) {
		die("<p>Error validating site code" . $query . ": " . 
	  	mysql_error() . "</p>");
	}
	$arr = mysql_fetch_array($result);
	$id = $arr[0];
	return $id;
}

function save_value($site_id, $variable_id, $source_id, $utc_date_time, $data_value) {
	$utc_offset = 0;
	$method_id = 0;
	$quality_control_level_id = 1;
	
	
	$query = 'INSERT INTO datavalues(SiteID, VariableID, MethodID, SourceID, QualityControlLevelID, ';
	$query .= 'LocalDateTime, UTCOffset, DateTimeUTC, DataValue) VALUES ';
	$query .= '("' . $site_id . '",';
	$query .= '"' . $variable_id . '", ';
	$query .= '"' . $method_id . '", ';
	$query .= '"' . $source_id . '", ';
	$query .= '"' . $quality_control_level_id . '", ';
	$query .= '"' . $utc_date_time . '",';
	$query .= '"' . $utc_offset . '",';
	$query .= '"' . $utc_date_time . '",';
	$query .= '"' . $data_value . '")';
	
	$result = mysql_query($query);
   
	if (!$result) {
	die("<p>Error inserting sites" . $query . ": " . 
	  mysql_error() . "</p>");
	}
	echo 'values for ' . $variable_id . ' and ' . $site_id . ' saved successfully.';
}

function return_error($error_text) {
	header('HTTP/1.0 500 Internal Server Error');
	header ("Content-Type:text/xml");
	echo '<response>' . $error_text . '</response>';
	exit;
}

function csv2array($input,$delimiter=',',$enclosure='"',$escape='\\'){
    $fields=explode($enclosure.$delimiter.$enclosure,substr($input,1,-1));
    foreach ($fields as $key=>$value)
        $fields[$key]=str_replace($escape.$enclosure,$enclosure,$value);
    return($fields);
}

function array2csv($input,$delimiter=',',$enclosure='"',$escape='\\'){
    foreach ($input as $key=>$value)
        $input[$key]=str_replace($enclosure,$escape.$enclosure,$value);
    return $enclosure.implode($enclosure.$delimiter.$enclosure,$input).$enclosure;
}