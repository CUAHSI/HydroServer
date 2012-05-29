<?php
	
//Display the correct navigation or redirect them to the unauthorized user page
if ($_COOKIE[power] ==admin){
	$nav ="<script src=A_navbar.js></script>";
	}
elseif ($_COOKIE[power] ==teacher){
	$nav ="<script src=T_navbar.js></script>";
	}
elseif ($_COOKIE[power] ==student){
	$nav ="<script src=S_navbar.js></script>";
	} 
else {
	header("Location: unauthorized.php");
	exit;	
	}
	
?>
