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

$user = $_POST["user"];
$password = $_POST["password"];
$format = $_POST["format"];

$data = $_POST["data"];

//get the sites POST data
//$postData = file_get_contents('php://input');

echo "<html>";
echo "<p>your data :$data</p>";
echo "format:" . $format;

if ($format == "XML") {
    $xml = simplexml_load_string($data);

    $site = $xml->site[0];
    print_r($site);

    $db = new redDB(DATABASE_HOST, DATABASE_USERNAME, DATABASE_PASSWORD, DATABASE_NAME);
    $objSite = $db->init('sites');
    $objSite->SiteName = $site->siteName;
    print_r($objSite);
    $objSite->Latitude = $site->latitude;
    $objSite->Longitude = $site->longitude;
    $objSite->SiteCode = "uuuxyyx";
    $objSite->VerticalDatum = "MSL";
    $objSite->SiteType = "Stream";
    $objSite->save();
    echo "saved successfully!!!";
}
else {
    //$csv = new CsvFileParser();
    //$csv->ParseFromString($data, false, false);

    //$myData = $csv->data;

    //echo "<table>";
    //foreach($myData as $row){
    //    echo "<tr><td>" . $row[0] . "</td><td>" . $row[1] . "</td><td>" . $row[2] . "</td></tr>";
    //}
    //echo "</table>";
    //echo "</html>";
}

//print_r($myData);

//$fields = csv2array($data);
//$arr = array("name", "\"latitude\"", "\"longitude\"");
//print_r($arr);


//$xml = simplexml_load_string($postData);
//print_r($xml);
//$sites = $xml->sites;
//$siteName = $xml->siteName;
//$latitude = $xml->latitude;
//$longitude = $xml->longitude;

//echo "you uploaded site: " . $siteName;

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

