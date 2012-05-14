<?php

$connection = @mysql_connect("localhost", "wc4moss", "pw2testWC") or die(mysql_error());

if ($connection) {
	$msg = "Success!";
} 

?>

<HTML>
<HEAD>
<TITLE>MySQL Connection</TITLE>
</HEAD>
<BODY>

<?php echo "$msg"; ?>

</BODY>
</HTML>