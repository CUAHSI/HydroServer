<?php
	
//Display the correct navigation or redirect them to the unauthorized user page
if ($_COOKIE[power] ==admin){
	$nav ="<script src=js/A_navbar.js></script>";
	}
elseif ($_COOKIE[power] ==teacher){
	$nav ="<script src=js/T_navbar.js></script>";
	}
elseif ($_COOKIE[power] ==student){
	$nav ="<script src=js/S_navbar.js></script>";
	} 
else {
	$nav ="<script src=js/P_navbar.js></script>";
	}
	
?>
