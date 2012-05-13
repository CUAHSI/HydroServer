<?php
  
  require_once 'wof.php';
  
  //if the query string contains ?wsdl
  $wsdl_is_set = (isset($_REQUEST['wsdl']) or isset($_REQUEST['WSDL']));
  
  //if the POST request contains the SoapACTION parameter
  $action_is_set = (isset($_SERVER['HTTP_SOAPACTION']));
  
  //if the query string contains ?op
  $op_is_set = (isset($_REQUEST['op']));
  
  //if the request is a REST-style request with parameters in HTTP GET
  $method_is_set = (isset($_REQUEST['method']));
  
  //when the SOAPAction is set, call the appropriate web method
  if ($action_is_set == 1) {
    $action_name = $_SERVER['HTTP_SOAPACTION'];
	$action_name2 = str_replace('"', "", $action_name); //removes quotes
	$action = substr($action_name2, strlen('http://www.cuahsi.org/his/1.1/ws/'));

	//read the input parameters
	$postdata = file_get_contents('php://input');
	$authtoken = wof_read_authtoken($postdata);
	
	if ($action == 'GetSiteInfo') {
	  $site = wof_read_parameter($postdata, 'site');
	  GetSiteInfo($authtoken, $site);
	  exit;
	} elseif ($action == 'GetSiteInfoMultpleObject') {
	  $sitesArray = wof_read_site_array($postdata);
	  GetSiteInfoMultpleObject($authtoken, $sitesArray);
	  exit;
	} elseif ($action == 'GetSiteInfoObject') {
	  $site = wof_read_parameter($postdata, 'site');
	  GetSiteInfoObject($authtoken, $site);
	  exit;
	} elseif ($action == 'GetSites') {
	  GetSites();
	  exit;
	} elseif ($action == 'GetSitesByBoxObject') {
	  $north = wof_read_parameter($postdata, 'north');
	  $south = wof_read_parameter($postdata, 'south');
	  $east =  wof_read_parameter($postdata, 'east');
	  $west = wof_read_parameter($postdata, 'west');
	  $IncludeSeries = wof_read_parameter($postdata, 'includeseries');
	  GetSitesByBoxObject($north, $south, $east, $west, $IncludeSeries);
	  exit;
	} elseif ($action == 'GetSitesObject') {
	  GetSitesObject();
	  exit;
	} elseif ($action == 'GetValues') {
	  $location = wof_read_parameter($postdata, 'location');
	  $variable = wof_read_parameter($postdata, 'variable');
	  $startDate =  wof_read_parameter($postdata, 'startdate');
	  $endDate = wof_read_parameter($postdata, 'enddate');
	  GetValues($authtoken, $location, $variable, $startDate, $endDate);
	  exit;
	} elseif ($action == 'GetValuesForASiteObject') {
	  $site = wof_read_parameter($postdata, 'site');
	  $startDate =  wof_read_parameter($postdata, 'startdate');
	  $endDate = wof_read_parameter($postdata, 'enddate');
	  GetValuesForASiteObject($authtoken, $site, $startDate, $endDate);
	  exit;
	} elseif ($action == 'GetValuesObject') {
	  $location = wof_read_parameter($postdata, 'location');
	  $variable = wof_read_parameter($postdata, 'variable');
	  $startDate =  wof_read_parameter($postdata, 'startdate');
	  $endDate = wof_read_parameter($postdata, 'enddate');
	  GetValuesObject($authtoken, $location, $variable, $startDate, $endDate);
	  exit;
	} elseif ($action == 'GetVariableInfo') {
	  $variable = wof_read_parameter($postdata, 'variable');
	  GetVariableInfo($authtoken, $variable);
	  exit;
	} elseif ($action == 'GetVariableInfoObject') {
	  $variable = wof_read_parameter($postdata, 'variable');
	  GetVariableInfoObject($authtoken, $variable);
	  exit;
	} elseif ($action == 'GetVariables') {
	  GetVariables();
	  exit;
	} elseif ($action == 'GetVariablesObject') {
	  GetVariablesObject();
	  exit;
	}
	else {
	  echo "ACTION NOT FOUND!! " . $action;
	  exit;
	}
  }
  
  //when the op parameter is set, return the web method test page
  elseif ($op_is_set == 1) {
    $operation_name = $_REQUEST['op'];
    $name = 'operations/operation_' . $operation_name . '.html';

    // send the right headers
    header("Content-Type: text/html");
    header("Content-Length: " . filesize($name));
	header("File-Name: " . $name);

    // display the file and stop this script
    readfile($name);
    exit;
  }
  
  //when the WSDL query string document is set, return the WSDL
  elseif ($wsdl_is_set == 1) {
  
    // Return the WSDL
    $wsdl = @implode ('', @file ('wateroneflow.wsdl'));
    if (strlen($wsdl) > 1) {
      
	  //replace the absolute uri
	  //$absolute_uri = "http://localhost:333/HIS/hydroserver/webservice/cuahsi_1_1.php";
	  $complete_uri = $_SERVER["SERVER_NAME"] . $_SERVER["REQUEST_URI"];
	  $absolute_uri = "http://" . substr($complete_uri, 0, strrpos($complete_uri, '/')) . "/cuahsi_1_1.php";
	  $pattern = "/ABSOLUTEURI_TO_REPLACE/";
	  $wsdl2 = preg_replace($pattern, $absolute_uri, $wsdl);
	  header("Content-type: text/xml");
      echo $wsdl2;
	  exit;
    }
    else {
      header("Status: 500 Internal Server Error");
      header("Content-type: text/plain");
      echo "HTTP/1.0 500 Internal Server Error";
    }
  }
  else if ($method_is_set == 1) {
    //the method was sent by a HTTP GET request
	$method = $_REQUEST["method"];
	//echo 'method: ' . $method;
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
		  echo chr(60).chr(63).'xml version="1.0" encoding="utf-8" '.chr(63).chr(62);
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
		  header("Content-type: text/xml");
		  echo chr(60).chr(63).'xml version="1.0" encoding="utf-8" '.chr(63).chr(62);	  
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
		  header("Content-type: text/xml");
		  echo chr(60).chr(63).'xml version="1.0" encoding="utf-8" '.chr(63).chr(62);	  
		  echo wof_GetSiteInfo($authToken, $site);
		}
	  }
	  exit;	  
	} elseif ($method == 'GetSites') {	  
	  header("Content-type: text/xml");
	  echo chr(60).chr(63).'xml version="1.0" encoding="utf-8" '.chr(63).chr(62);
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
	  header("Content-type: text/xml");
	  echo chr(60).chr(63).'xml version="1.0" encoding="utf-8" '.chr(63).chr(62);	  
	  echo wof_GetSitesByBox($west, $south, $east, $north, $includeSeries);
	  exit;
	} elseif ($method == 'GetSitesObject') {
	  header("Content-type: text/xml");
	  echo chr(60).chr(63).'xml version="1.0" encoding="utf-8" '.chr(63).chr(62);	  
	  echo wof_GetSites();
	  exit;
	} elseif ($method == 'GETVALUES') {
	  $location = wof_read_parameter($postdata, 'location');
	  $variable = wof_read_parameter($postdata, 'variable');
	  $startDate =  wof_read_parameter($postdata, 'startdate');
	  $endDate = wof_read_parameter($postdata, 'enddate');
	  GetValues($authtoken, $location, $variable, $startDate, $endDate);
	  exit;
	} elseif ($method == 'GetValuesForASiteObject') {
	  $site = wof_read_parameter($postdata, 'site');
	  $startDate =  wof_read_parameter($postdata, 'startdate');
	  $endDate = wof_read_parameter($postdata, 'enddate');
	  GetValuesForASiteObject($authtoken, $site, $startDate, $endDate);
	  exit;
	} elseif ($method == 'GetValuesObject') {
	  $location = wof_read_parameter($postdata, 'location');
	  $variable = wof_read_parameter($postdata, 'variable');
	  $startDate =  wof_read_parameter($postdata, 'startdate');
	  $endDate = wof_read_parameter($postdata, 'enddate');
	  GetValuesObject($authtoken, $location, $variable, $startDate, $endDate);
	  exit;
	} elseif ($method == 'GetVariableInfo') {
	  $variable = wof_read_parameter($postdata, 'variable');
	  GetVariableInfo($authtoken, $variable);
	  exit;
	} elseif ($method == 'GetVariableInfoObject') {
	  $variable = wof_read_parameter($postdata, 'variable');
	  GetVariableInfoObject($authtoken, $variable);
	  exit;
	} elseif ($method == 'GetVariables') {
	  GetVariables();
	  exit;
	} elseif ($method == 'GetVariablesObject') {
	  GetVariablesObject();
	  exit;
	}
	else {  
	  echo $method . " Web Service method name is not valid. method names are case sensitive.";
	  exit;
	}
	
	exit;
  }
?>

<html>
  <head>
<meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link rel="alternate" type="text/xml" href="cuahsi_1_1.asmx?disco"/>

    <style type="text/css">
    
		BODY { color: #000000; background-color: white; font-family: ; margin-left: 0px; margin-top: 0px; }
		#content { margin-left: 30px; font-size: .70em; padding-bottom: 2em; }
		A:link { color: #336699; font-weight: bold; text-decoration: underline; }
		A:visited { color: #6699cc; font-weight: bold; text-decoration: underline; }
		A:active { color: #336699; font-weight: bold; text-decoration: underline; }
		A:hover { color: cc3300; font-weight: bold; text-decoration: underline; }
		P { color: #000000; margin-top: 0px; margin-bottom: 12px; font-family: ; }
		pre { background-color: #e5e5cc; padding: 5px; font-family: ; font-size: x-small; margin-top: -5px; border: 1px #f0f0e0 solid; }
		td { color: #000000; font-family: ; font-size: .7em; }
		h2 { font-size: 1.5em; font-weight: bold; margin-top: 25px; margin-bottom: 10px; border-top: 1px solid #003366; margin-left: -15px; color: #003366; }
		h3 { font-size: 1.1em; color: #000000; margin-left: -15px; margin-top: 10px; margin-bottom: 10px; }
		ul, ol { margin-top: 10px; margin-left: 20px; }
		li { margin-top: 10px; color: #000000; }
		font.value { color: darkblue; font: bold; }
		font.key { color: darkgreen; font: bold; }
		.heading1 { color: #ffffff; font-family: ; font-size: 26px; font-weight: normal; background-color: #003366; margin-top: 0px; margin-bottom: 0px; margin-left: -30px; padding-top: 10px; padding-bottom: 3px; padding-left: 15px; width: 105%; }
		.button { background-color: #dcdcdc; font-family: ; font-size: 1em; border-top: #cccccc 1px solid; border-bottom: #666666 1px solid; border-left: #cccccc 1px solid; border-right: #666666 1px solid; }
		.frmheader { color: #000000; background: #dcdcdc; font-family: ; font-size: .7em; font-weight: normal; border-bottom: 1px solid #dcdcdc; padding-top: 2px; padding-bottom: 2px; }
		.frmtext { font-family: ; font-size: .7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; }
		.frmInput { font-family: ; font-size: 1em; }
		.intro { margin-left: -15px; }
           
    </style>

    <title>WaterOneFlow Web Service</title>

      <script language="javascript" type="text/javascript">
		
		function ShowTestSection() {
			document.getElementById("soaptemplaterequest").style.display = "block";
			document.getElementById("soapsamplerequest").style.display = "none";
			document.getElementById("soapsampleresponse").style.display = "none";
			document.getElementById("testhref").style.display = "none";
			document.getElementById("samplehref").style.display = "block";
			document.getElementById("soapsampletitle").style.display = "none";
			document.getElementById("soaptesttitle").style.display = "block";
		}
		
		function ShowTemplateSection() {
			document.getElementById("soaptemplaterequest").style.display = "none";
			document.getElementById("soapsamplerequest").style.display = "block";
			document.getElementById("soapsampleresponse").style.display = "block";
			document.getElementById("samplehref").style.display = "none";
			document.getElementById("testhref").style.display = "block";
			document.getElementById("soapsampletitle").style.display = "block";
			document.getElementById("soaptesttitle").style.display = "none";
		}

		function SendSoapRequest_onclick(SoapRequest, MethodName, Url) {
		// clear any old message 
		
       document.getElementById("note").firstChild.nodeValue ="";
		// SoapRequst Javascript not working in FF
		SoapRequest = document.getElementById("txasoaptemplaterequest").value;
			var xmlhttp;
			if (window.XMLHttpRequest)
              {// code for all new browsers
              xmlhttp=new XMLHttpRequest();
              } else if (window.ActiveXObject)
              {// code for IE5 and IE6
              xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
              }
            if (xmlhttp!=null)
              {	
	            // Function.
	            xmlhttp.onreadystatechange=function() {
                     if (xmlhttp.readyState==4)
                     {
                         if (xmlhttp.status == 200) {
                          // alert(xmlhttp.responseText)	
   		                    document.getElementById("tempsoaprequest").value = document.getElementById("txasoaptemplaterequest").value;
			                document.getElementById("txasoaptemplaterequest").value = xmlhttp.responseText;
			                document.getElementById("backhref").style.display = "block";
			                document.getElementById("posthref").style.display = "none";
    			        
                         } else {
    		              document.getElementById("tempsoaprequest").value = document.getElementById("txasoaptemplaterequest").value;
                         
                          document.getElementById("note").style.visibility = "visible";
                         document.getElementById("note").firstChild.nodeValue ="ERROR" ;
                         }
                         // done. turn off status
                        document.getElementById("Status").style.visibility = "hidden";

                     }
                 }
	        xmlhttp.open('POST', Url, true);
			xmlhttp.setRequestHeader('Content-Type', 'text/xml; charset="UTF-8"');
			xmlhttp.setRequestHeader('SOAPAction', '');
			
			document.getElementById("Status").style.visibility = "visible";
			
			xmlhttp.send(SoapRequest);

          }
            else
              {
              alert("Your browser does not support XMLHTTP.");
              }
		}

		function GoBackToRequest_onclick() {
			document.getElementById("txasoaptemplaterequest").value = document.getElementById("tempsoaprequest").value;
			document.getElementById("backhref").style.display = "none";
			document.getElementById("posthref").style.display = "block";
		}
      </script>

  </head>

<body>



<div id="content">

	<p class="heading1">WaterOneFlow</p>
	<br>
	
	<span id="Span1">
		<p class="intro">The following operations are supported.  For a formal definition, please review the <a href="cuahsi_1_1.php?WSDL">Service Description</a>.</p>
		
				<ul>
			
				<li>
					<a href="cuahsi_1_1.php?op=GetSiteInfo">GetSiteInfo</a>
					<span id="MethodList_ctl01_Span2">
						<br>Given a site number, this method returns the site's metadata. Send the site code in this format: 'NetworkName:SiteCode'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetSiteInfoMultpleObject">GetSiteInfoMultpleObject</a>
					<span id="MethodList_ctl02_Span2">
						<br>Given a site number, this method returns the site's metadata. Send the site code in this format: 'NetworkName:SiteCode'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetSiteInfoObject">GetSiteInfoObject</a>
					<span id="MethodList_ctl03_Span2">
						<br>Given a site number, this method returns the site's metadata. Send the site code in this format: 'NetworkName:SiteCode'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetSites">GetSites</a>
					<span id="MethodList_ctl04_Span2">
						<br>Given an array of site numbers, this method returns the site metadata for each one. Send the array of site codes in this format: 'NetworkName:SiteCode'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetSitesByBoxObject">GetSitesByBoxObject</a>
					<span id="MethodList_ctl05_Span2">
						<br>Given a site number, this method returns the site's metadata. Send the site code in this format: 'NetworkName:SiteCode'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetSitesObject">GetSitesObject</a>
					<span id="MethodList_ctl06_Span2">
						<br>Given an array of site numbers, this method returns the site metadata for each one. Send the array of site codes in this format: 'NetworkName:SiteCode'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetValues">GetValues</a>
					<span id="MethodList_ctl07_Span2">
						<br>Given a site number, a variable, a start date, and an end date, this method returns a time series. Pass in the sitecode and variable in this format: 'NetworkName:SiteCode' and 'NetworkName:Variable'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetValuesForASiteObject">GetValuesForASiteObject</a>
					<span id="MethodList_ctl08_Span2">
						<br>Given a site number, this method returns the site's metadata. Send the site code in this format: 'NetworkName:SiteCode'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetValuesObject">GetValuesObject</a>
					<span id="MethodList_ctl09_Span2">
						<br>Given a site number, a variable, a start date, and an end date, this method returns a time series. Pass in the sitecode and variable in this format: 'NetworkName:SiteCode' and 'NetworkName:Variable'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetVariableInfo">GetVariableInfo</a>
					<span id="MethodList_ctl10_Span2">
						<br>Given a variable code, this method returns the variable's name. Pass in the variable in this format: 'NetworkName:Variable'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetVariableInfoObject">GetVariableInfoObject</a>
					<span id="MethodList_ctl11_Span2">
						<br>Given a variable code, this method returns the variable's siteName. Pass in the variable in this format: 'NetworkName:Variable'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetVariables">GetVariables</a>
					<span id="MethodList_ctl12_Span2">
						<br>Given a variable code, this method returns the variable's name. Pass in the variable in this format: 'NetworkName:Variable'
					</span>
				</li>
				<p />
			
				<li>
					<a href="cuahsi_1_1.php?op=GetVariablesObject">GetVariablesObject</a>
					<span id="MethodList_ctl13_Span2">
						<br>Given a variable code, this method returns the variable's siteName. Pass in the variable in this format: 'NetworkName:Variable'
					</span>
				</li>
				<p />
			
				</ul>
			
	</span>

	
</div>
<div id="Status" style="visibility:hidden;z-index:1;position:absolute;left:50%;top:50%;border:thick double #00FF00;" >
Running
</div>
</body>
</html>