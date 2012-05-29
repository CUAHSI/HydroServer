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
require_once('authorization.php');

//get the token
if (isset($_POST["token"])) {
  $token = $_POST["token"];
}
else {
  if (isset($_SERVER['HTTP_TOKEN'])) {
    $token = $_SERVER['HTTP_TOKEN'];
  }
  else {
    echo 'not authorized (unspecified token).';
	exit;
  }
}
$valid_token = get_current_token();
if ($token != $valid_token) {
  echo 'not authorized (invalid token).';
  exit;
}
else {
  echo 'token is valid. authorized.';
}

//get the site code
if (isset($_GET["SiteCode"])) {
$site_code = $_GET["SiteCode"];
}
else {
	echo 'Site Code is not valid.';
	exit;
}

//get the variable code
if (isset($_GET["VariableCode"])) {
	$variable_code = $_GET["VariableCode"];
}else {
	echo 'Variable Code is not valid.';
	exit;
}

//get the format (XML)
$format = "XML";
if (isset($_REQUEST["format"])) {
	$format = $_REQUEST["format"];
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
	echo "site ID not found for code: " . $site_code;
	exit;
}
$variable_id = get_valid_variable_id($variable_code);
if ($variable_id < 1) {
	echo "variable ID not found for code: " . $variable_code;
	exit;
}

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

function generate_site_code($latitude, $longitude) {
	$north_south = $latitude > 0 ? 'N' : 'S';
	$east_west = $longitude > 0 ? 'E' : 'W';
	$lat_str = number_format(abs($latitude), 6);
	$lon_str = number_format(abs($longitude), 6);
	$code = $lat_str . $north_south . '_' . $lon_str . $east_west;
	return $code;
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