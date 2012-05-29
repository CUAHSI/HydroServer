<?php
require_once('authorization.php');

if (!isset($_REQUEST["user"])) {
	echo "Missing user parameter.";
	exit;
}
if (!isset($_REQUEST["password"])) {
	echo "Missing user name or password.";
	exit;
}
$user = $_REQUEST['user'];
$password = $_REQUEST['password'];

//do the authorization: encrypt name and password and compare it to values in the DB
$valid_user = "jkadlec";
$valid_password = "jiri4moss";

if ($user != $valid_user || $password != $valid_password) {
  echo "Bad user name or password!";
  exit;
}

//we have a valid password: generate the token
$token = get_current_token();


header("Content-type: text/xml; charset=utf-8'");
echo chr(60) . chr(63) . 'xml version="1.0" encoding="utf-8" ' . chr(63) . chr(62);
echo '<token expires="' . date("Y-m-d H:i:s", strtotime ("+1 hour")) . '">' . $token . '</token>';