<?php
/*
Default Configuration file for Hydroserver-WebClient-PHP
Edit at your own risk
This file provides configuration for the database, for the default options on various pages.
Developed by : GIS LAB - CAES - ISU

This file will be populated while deployment
*/

//MySql Database Configuration Settings

define("DATABASE_HOST", "localhost"); //for example define("DATABASE_HOST", "your_database_host");
define("DATABASE_USERNAME", "advenup1_hisv1"); //for example define("DATABASE_USERNAME", "your_database_username");
define("DATABASE_NAME", "advenup1_hisv1");  //for example define("DATABASE_NAME", "your_database_name");
define("DATABASE_PASSWORD", "MapW1nd0w"); //for example define("DATABASE_PASSWORD", "your_database_password");

//Cookie Settings - This is for Security!

$www = "adventurelearningat.com"; // Please change this to your website's domain name. You may also use "localhost" for testing purposes on a local server.

//Default Variables for add_site.php

$default_datum="MSL";

$default_spatial="NAD83 / Idaho Central";

$default_source="McCall Outdoor Science School";

//Establish default values for MOSS' data variables when adding a data value to a site(add_data_value.php)

$UTCOffset = -7; 
$UTCOffset2 = 7; // Actually it is -7
$CensorCode ='nc';
$QualityControlLevelID = 0;
$ValueAccuracy ='NULL'; 
$OffsetValue ='NULL';
$OffsetTypeID ='NULL';
$QualifierID =1;
$SampleID ='NULL';
$DerivedFromID ='NULL';

//Establish default values for new MOSS site when adding a new site to the database (add_site.php)

$LocalX ='NULL';
$LocalY ='NULL';
$LocalProjectionID ='NULL';
$PosAccuracy_m ='NULL';


//Establish default values for MOSS' source info when adding a new source to the database (add_source.php)

$ProfileVersion = 'ISO 19115'; 

//Name of your blog/Website homepage..(This affects the "Back to home button"

$homename="Moss blog";

//Link of your blog/Website homepage..(This affects the "Back to home button"


$homelink="http://www.adventurelearningat.com";

?>