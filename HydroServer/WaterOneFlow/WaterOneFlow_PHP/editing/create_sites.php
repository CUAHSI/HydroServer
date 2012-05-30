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

if (!validate_token($token)) {
  echo 'not authorized (invalid token).';
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
echo "<html>";
echo "<p>your data :$data</p>";
echo "format:" . $format;

if ($format == "XML") {
    $xml = simplexml_load_string($data);

    $site = $xml->siteInfo[0];

	//call SaveSite here!!!
	save_site($site);
}
else {
	echo '<p>CSV format is not yet supported.</p>';
}

function save_site($xmlsite) {
	$site_name = $xmlsite->siteName;
	$latitude = $xmlsite->latitude;
	$longitude = $xmlsite->longitude;
	
	$site_code = generate_site_code($latitude, $longitude);
	if (isset($xmlsite->siteCode)) {
		$site_code = $xmlsite->siteCode;
	}
	$elevation_m = 0;
	if (isset($xmlsite->elevation_m)) {
		$elevation_m = $xmlsite-> elevation_m;
	}
	$query = 'INSERT INTO Sites(SiteCode, SiteName, Latitude, Longitude, Elevation_m) VALUES ';
	$query .= '("' . $site_code . '",';
	$query .= '"' . $site_name . '",';
	$query .= '"' . $latitude . '",';
	$query .= '"' . $longitude . '",';
	$query .= '"' . $elevation_m . '")';
	
	$result = mysql_query($query);
   
	if (!$result) {
	die("<p>Error inserting sites" . $query . ": " . 
	  mysql_error() . "</p>");
	}
	echo 'site ' . $site_code . ' saved successfully.';
}

function generate_site_code($latitude, $longitude) {
	$north_south = $latitude > 0 ? 'N' : 'S';
	$east_west = $longitude > 0 ? 'E' : 'W';
	$lat = number_format(abs((float) $latitude),6);
	$lon = number_format(abs((float) $longitude),6);
	$code = $lat . $north_south . '_' . $lon . $east_west;
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

