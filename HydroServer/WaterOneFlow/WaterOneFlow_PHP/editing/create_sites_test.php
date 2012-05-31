<!DOCTYPE html>
<html>
<head>

<title>
Create Sites
</title>

<!-- Meta Tags -->
<meta charset="utf-8">

</head>

<body id="public">
<div id="container" class="ltr">

<h1 id="logo">
Create Sites Test
</h1>

<form target="_blank" id="frm" name="frm"  method="post"
action="create_sites.php">
    Access Token: <input type="text" name="token" /><br />
    Format:   <select name="format" >
    <option value="XML">XML</option>
    <option value="CSV">CSV</option>
    </select>
    <p>Data:</p> 
	<textarea rows="20" cols="60" name="data" id="data">
	<sites>
	  <siteInfo>
	    <siteName>MY SITE</siteName>
		<latitude>50.0234</latitude>
		<longitude>15.678</longitude>
		<elevation_m>333</elevation_m>
	  </siteInfo>
	</sites>
	</textarea><br />
    <input id="submit_button" name="submit_button" type="submit" />
</form>
</div>
</body>
</html>