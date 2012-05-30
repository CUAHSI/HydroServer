<?php
//This class is the helper for getting values from the database
require_once('database_connection.php');
//returns TRUE, if user is valid
//returns FALSE otherwise
function validate_user($user, $password) {
	$sql ="SELECT * FROM moss_users WHERE username='$user' AND password= password('$password')";
	$result = mysql_query($sql) or die(mysql_error());
	
	$num = mysql_num_rows($result);
	if ($num != 0) {
		return TRUE;
	} else {
		return FALSE;
	}
}

function validate_token($token) {
	$cd = date('c', time());
	$tok = mysql_real_escape_string($token);
	$sql = "SELECT token from moss_user_tokens WHERE token = '$tok' AND issued < '$cd' AND expires > '$cd'";
	$result = mysql_query($sql) or die(mysql_error());
	$num = mysql_num_rows($result);
	$valid = FALSE;
	while ($arr = mysql_fetch_array($result)) {
		if ($arr[0] == $token) {
			$valid = TRUE;
		}
	}
	return $valid;
}

function generate_token($user_name, $user_password) {
	$issued = time();
	$expires = $issued + 60 * 120;
	$issued_f = date('c', $issued);
	$expires_f = date('c', $expires);
	
	if (validate_user($user_name, $user_password)) {
		$tok = crypt($user_name . '-' . $issued_f . '-' . $expires_f);
		$sql = "INSERT INTO moss_user_tokens(username, token, issued, expires) VALUES ('$user_name', '$tok', '$issued_f', '$expires_f')";
		$result = mysql_query($sql) or die(mysql_error());
		
		$token_info = array('token' => $tok, 'issued' => $issued_f, 'expires' => $expires_f);
		return $token_info;
	}
}