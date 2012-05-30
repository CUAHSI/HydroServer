<?php
require_once('db_helper.php');
if (!isset($_POST["user"])) {
	echo "Missing user parameter.";
	exit;
}
if (!isset($_POST["password"])) {
	echo "Missing user name or password.";
	exit;
}
$user = $_POST['user'];
$password = $_POST['password'];

//do the authorization: encrypt name and password and compare it to values in the DB
if (validate_user($user, $password) === FALSE) {
	echo "Bad user name or password!";
	exit;
}

//we have a valid password: generate the token
$token_info = generate_token($user, $password);

header("Content-type: text/xml; charset=utf-8'");
echo chr(60) . chr(63) . 'xml version="1.0" encoding="utf-8" ' . chr(63) . chr(62);
echo '<token expires="' . $token_info['expires'] . '">' . $token_info['token'] . '</token>';