<?php
require_once('authorization.php');

if (isset($_POST["token"]) and isset($_POST["data"]) and isset($_POST["SiteCode"]) and isset($_POST["VariableCode"])) {

$user_token = $_POST["token"];

$complete_uri = get_complete_uri();
$url = substr($complete_uri, 0, strrpos($complete_uri, '/')) . "/create_values.php";

$data = $_POST["data"];
$site_code = $_POST["SiteCode"];
$variable_code = $_POST["VariableCode"];
$params = '?SiteCode=' . $site_code . '&VariableCode=' . $variable_code;

$soap_do = curl_init(); 
curl_setopt($soap_do, CURLOPT_URL,            $url . $params );   
curl_setopt($soap_do, CURLOPT_CONNECTTIMEOUT, 10); 
curl_setopt($soap_do, CURLOPT_TIMEOUT,        10); 
curl_setopt($soap_do, CURLOPT_RETURNTRANSFER, true );
curl_setopt($soap_do, CURLOPT_SSL_VERIFYPEER, false);  
curl_setopt($soap_do, CURLOPT_SSL_VERIFYHOST, false); 
curl_setopt($soap_do, CURLOPT_POST,           true ); 
curl_setopt($soap_do, CURLOPT_POSTFIELDS,    $data); 
curl_setopt($soap_do, CURLOPT_HTTPHEADER, array('Content-Type: text/xml; charset=utf-8', 'Content-Length: '.strlen($data), 'submitted: ' . TRUE,
'token: ' . $user_token)); 

$tuData = curl_exec($soap_do);
if(!curl_errno($soap_do)){
  $info = curl_getinfo($soap_do);
  //echo 'Took ' . $info['total_time'] . ' seconds to send a request to ' . $info['url'];
} else {
  echo 'Curl error: ' . curl_error($soap_do);
}

curl_close($soap_do);
echo $tuData; 
}

function get_complete_uri() {
	$pageURL = (@$_SERVER["HTTPS"] == "on") ? "https://" : "http://";
	if ($_SERVER["SERVER_PORT"] != "80")
	{
    	$pageURL .= $_SERVER["SERVER_NAME"].":".$_SERVER["SERVER_PORT"].$_SERVER["REQUEST_URI"];
	} 
	else 
	{
    	$pageURL .= $_SERVER["SERVER_NAME"].$_SERVER["REQUEST_URI"];
	}
	return $pageURL;
}

?>
<!DOCTYPE html>
<html>
<head>

<title>
Create Data Values
</title>

<!-- Meta Tags -->
<meta charset="utf-8">
<meta name="robots" content="index, follow">

<!--[if lt IE 10]>
<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
</head>

<body id="public">
<div id="container" class="ltr">

<h1 id="logo">
Create Values Test
</h1>

<form id="form8" name="form8"  autocomplete="off" enctype="multipart/form-data" method="post" novalidate
action="">
    <table>
    <tr>
    <td>Access Token:</td><td> <input type="text" name="token" /></td>
    </tr>
    <tr>
    <td>Format:</td><td> <select name="format" >
    <option value="XML">XML</option>
    <option value="CSV">CSV</option>
    </select></td>
    </tr>
    <tr>
    <td>
    Site Code:</td><td>
    <input type="text" name="SiteCode" id="SiteCode" />
    </td>
    </tr>
    <tr>
    <td>
    Variable Code: </td><td>
    <input type="text" name="VariableCode" id="VariableCode" /></td>
    </tr>
    <tr>
    <td>Data:</td>
    <td><textarea rows="20" cols="80" name="data"><values>
<value DateTimeUTC="2012-06-01T14:00:00">23.33</value>
<value DateTimeUTC="2012-01-01T14:01:00">22.12</value>
</values>
	</textarea><br /></td>
    </tr>
    <tr>
    <td />
    <td><input type="submit" name="submit_button"/></td>
    </tr>
    </table>
</form> 
</div>
</body>
</html>