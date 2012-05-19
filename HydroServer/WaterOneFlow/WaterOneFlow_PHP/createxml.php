<?php
/**
 * Created by JetBrains PhpStorm.
 * User: Jiri
 * Date: 5/19/12
 * Time: 1:03 PM
 * To change this template use File | Settings | File Templates.
 */
$myxmlstring = "EXAMPLE";
write_XML_header();
echo "<string>" . $myxmlstring . "</string>";

function write_XML_header() {
    header("Content-type: text/xml");
    echo chr(60).chr(63).'xml version="1.0" encoding="utf-8" '.chr(63).chr(62);
}