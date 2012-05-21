<?php
//add this to secondary pages to display the correct navigation options or redirect them to the unauthorized user page
if ($_COOKIE[auth] =="admin"){
	$nav ="<SCRIPT src=A_navbar.js></SCRIPT>";
	} 
    else {
	header("Location: unauthorized.php");
	exit;	
	}
?>
