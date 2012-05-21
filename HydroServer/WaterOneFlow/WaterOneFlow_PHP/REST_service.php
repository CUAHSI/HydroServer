<?php
require_once("wof.php");

function write_XML_header()
{
    header("Content-type: text/xml; charset=utf-8'");
    echo chr(60) . chr(63) . 'xml version="1.0" encoding="utf-8" ' . chr(63) . chr(62);
}

function write_REST_response($method)
{
    $method = $_REQUEST["method"];
    $authToken = "";
    if ($method == 'GetSiteInfo') {
        if (!isset($_REQUEST["site"])) {
            echo "Value cannot be null.\nParameter name: SiteCode";
        } else {
            $site = $_REQUEST["site"];
            if ($site == "") {
                echo "Value cannot be null.\nParameter name: SiteCode";
            } else {
                header("Content-type: text/xml");
                echo chr(60) . chr(63) . 'xml version="1.0" encoding="utf-8" ' . chr(63) . chr(62);
                echo "<string>" . htmlspecialchars(wof_GetSiteInfo($authToken, $site)) . "</string>";
            }
        }
        exit;
    } elseif ($method == 'GetSiteInfoMultpleObject') {
        //TODO: user may post multiple site values in query string
        if (!isset($_REQUEST["site"])) {
            echo "Value cannot be null.\nParameter name: SiteCode";
        } else {
            $site = $_REQUEST["site"];
            if ($site == "") {
                echo "Value cannot be null.\nParameter name: SiteCode";
            } else {
                write_XML_header();
                echo wof_GetSiteInfoMultipleObject($authToken, array($site));
            }
        }
        exit;
    } elseif ($method == 'GetSiteInfoObject') {
        if (!isset($_REQUEST["site"])) {
            echo "Value cannot be null.\nParameter name: SiteCode";
        } else {
            $site = $_REQUEST["site"];
            if ($site == "") {
                echo "Value cannot be null.\nParameter name: SiteCode";
            } else {
                write_XML_header();
                echo wof_GetSiteInfo($authToken, $site);
            }
        }
        exit;
    } elseif ($method == 'GetSites') {
        write_XML_header();
        echo "<string>" . htmlspecialchars(wof_GetSites()) . "</string>";
        exit;
    } elseif ($method == 'GetSitesByBoxObject') {
        $includeSeries = FALSE;
        if (!isset($_REQUEST["west"])) {
            echo "Missing parameter: west";
            exit;
        }
        if (!isset($_REQUEST["south"])) {
            echo "Missing parameter: south";
            exit;
        }
        if (!isset($_REQUEST["east"])) {
            echo "Missing parameter: east";
            exit;
        }
        if (!isset($_REQUEST["north"])) {
            echo "Missing parameter: north";
            exit;
        }
        if (isset($_REQUEST["IncludeSeries"])) {
            $includeSeries = $_REQUEST["IncludeSeries"]; //TRUE or FALSE
        }
        $west = $_REQUEST['west'];
        if ($west == NULL) {
            echo "Value cannot be null.\nParameter name: west";
            exit;
        }
        $south = $_REQUEST['south'];
        if ($south == NULL) {
            echo "Value cannot be null.\nParameter name: south";
            exit;
        }
        $east = $_REQUEST['east'];
        if ($east == NULL) {
            echo "Value cannot be null.\nParameter name: east";
            exit;
        }
        $north = $_REQUEST['north'];
        if ($north == NULL) {
            echo "Value cannot be null.\nParameter name: north";
            exit;
        }
        write_XML_header();
        echo wof_GetSitesByBox($west, $south, $east, $north, $includeSeries);
        exit;
    } elseif ($method == 'GetSitesObject') {
        header("Content-type: text/xml");
        echo chr(60) . chr(63) . 'xml version="1.0" encoding="utf-8" ' . chr(63) . chr(62);
        echo wof_GetSites();
        exit;
    } elseif ($method == 'GetValues' or $method == 'GetValuesObject') {
        if (!isset($_REQUEST['location'])) {
            echo "Missing parameter: location";
            exit;
        }
        if (!isset($_REQUEST['variable'])) {
            echo "Missing parameter: variable";
            exit;
        }
        if (!isset($_REQUEST['startDate'])) {
            echo "Missing parameter: startDate";
            exit;
        }
        if (!isset($_REQUEST['endDate'])) {
            echo "Missing parameter: endDate";
            exit;
        }
        $location = $_REQUEST["location"];
        $variable = $_REQUEST["variable"];
        $startDate = $_REQUEST["startDate"];
        $endDate = $_REQUEST["endDate"];
        write_XML_header();

        if ($method == "GetValues") {
            echo '<string>';
            echo htmlspecialchars(wof_GetValues($authToken, $location, $variable, $startDate, $endDate));
            echo "</string>";
        }
        elseif ($method == "GetValuesObject") {
            echo wof_GetValues($authToken, $location, $variable, $startDate, $endDate);
        }
        exit;
    } elseif ($method == 'GetValuesForASiteObject') {
        if (!isset($_REQUEST['site'])) {
            echo "Missing parameter: site";
            exit;
        }
        if (!isset($_REQUEST['startDate'])) {
            echo "Missing parameter: startDate";
            exit;
        }
        if (!isset($_REQUEST['endDate'])) {
            echo "Missing parameter: endDate";
            exit;
        }
        $site = $_REQUEST['site'];
        $startDate = $_REQUEST['startDate'];
        $endDate = $_REQUEST['endDate'];
        write_XML_header();
        echo wof_GetValuesForASite($authToken, $site, $startDate, $endDate);
        exit;
    } elseif ($method == 'GetVariableInfo' or $method == 'GetVariableInfoObject') {
        $variable = "";
        if (isset($_REQUEST['variable'])) {
            $variable = $_REQUEST['variable'];
        }
        write_XML_header();
        if ($method == "GetVariableInfo") {
            echo '<string>';
            echo htmlspecialchars(wof_GetVariableInfo($authToken, $variable));
            echo '</string>';
        } elseif ($method == "GetVariableInfoObject") {
            echo wof_GetVariableInfo($authToken, $variable);
        }
        exit;
    } elseif ($method == 'GetVariables') {
        write_XML_header();
        echo '<string>';
        echo htmlspecialchars(wof_GetVariables());
        echo '</string>';
        exit;
    } elseif ($method == 'GetVariablesObject') {
        write_XML_header();
        echo wof_GetVariables();
        exit;
    }
    else {
        echo $method . " Web Service method name is not valid. method names are case sensitive.";
        exit;
    }
}