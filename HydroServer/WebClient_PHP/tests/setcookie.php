<?

$cookie_name = "test_cookie";
$cookie_value = "test string!";
$cookie_expire = time()+86400;
$cookie_domain = "127.0.0.1";

setcookie($cookie_name, $cookie_value, $cookie_expire, "/" , $cookie_domain, 0);

?>

<HTML>
<HEAD>
<TITLE>Set Test Cookie</TITLE>
</HEAD>
<BODY>

<h1>Mmmmmmmm...cookie!</h1>

</BODY>
</HTML>
