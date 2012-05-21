<?php
require_once('authorization.php');

if (isset($_POST["token"]) and isset($_POST["data"])) {

$user_token = $_POST["token"];
$url = "http://localhost:333/his/services/editing/create_sites.php";
$data = $_POST["data"];

$soap_do = curl_init(); 
curl_setopt($soap_do, CURLOPT_URL,            $url );   
curl_setopt($soap_do, CURLOPT_CONNECTTIMEOUT, 10); 
curl_setopt($soap_do, CURLOPT_TIMEOUT,        10); 
curl_setopt($soap_do, CURLOPT_RETURNTRANSFER, true );
curl_setopt($soap_do, CURLOPT_SSL_VERIFYPEER, false);  
curl_setopt($soap_do, CURLOPT_SSL_VERIFYHOST, false); 
curl_setopt($soap_do, CURLOPT_POST,           true ); 
curl_setopt($soap_do, CURLOPT_POSTFIELDS,    $data); 
curl_setopt($soap_do, CURLOPT_HTTPHEADER,     array('Content-Type: text/xml; charset=utf-8', 'Content-Length: '.strlen($data), 'submitted: ' . TRUE,
'token: ' . $user_token)); 

$tuData = curl_exec($soap_do);
if(!curl_errno($soap_do)){
  $info = curl_getinfo($soap_do);
  echo 'Took ' . $info['total_time'] . ' seconds to send a request to ' . $info['url'];
} else {
  echo 'Curl error: ' . curl_error($soap_do);
}

curl_close($soap_do);
echo $tuData; 
}
?>
<!DOCTYPE html>
<html>
<head>

<title>
Add a Site
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
Add Sites Test
</h1>

<form id="form8" name="form8"  autocomplete="off" enctype="multipart/form-data" method="post" novalidate
action="">
    Access Token: <input type="text" name="token" /><br />
    Format:   <select name="format" >
    <option value="XML">XML</option>
    <option value="CSV">CSV</option>
    </select>
    <p>Data:</p> 
	<textarea rows="20" cols="60" name="data">
	<sites>
	  <siteInfo>
	    <siteName>MY SITE</siteName>
		<latitude>50.0234</latitude>
		<longitude>15.678</longitude>
		<elevation_m>333</elevation_m>
	  </siteInfo>
	</sites>
	</textarea><br />
    <input type="submit" name="submit_button"/>
</form> 
</div>
</body>
</html>