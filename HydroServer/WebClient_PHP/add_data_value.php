<?php
//check authority to be here
require_once 'authorization_check.php';

//connect to server and select database
require_once 'database_connection.php';

//add the SourceID's
$sql ="Select distinct SourceID, Organization FROM seriescatalog";

$result = @mysql_query($sql,$connection)or die(mysql_error());

$num = @mysql_num_rows($result);
	if ($num < 1) {

    $msg = "<P><em2>Sorry, no Sources available.</em></p>";

	} else {

	while ($row = mysql_fetch_array ($result)) {

		$sourceid = $row["SourceID"];
		$sourcename = $row["Organization"];

		$option_block .= "<option value=$sourceid>$sourcename</option>";

		}
	}

//add the Types
$sql3 ="Select * FROM variables ORDER BY VariableName ASC";

$result3 = @mysql_query($sql3,$connection)or die(mysql_error());

$num = @mysql_num_rows($result3);
	if ($num < 1) {

    $msg3 = "<P><em2>Sorry, there are no Types.</em></p>";

	} else {

	while ($row3 = mysql_fetch_array ($result3)) {

		$typeid = $row3["VariableID"];
		$typename = $row3["VariableName"];
		$datatype = $row3["DataType"];

		$option_block3 .= "<option value=$typeid>$typename ($datatype)</option>";

		}
	}

?>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client</title>

<script type="text/javascript">
function show_answer(){
alert("If you do not see your SITE listed here," + '\n' + "please contact your teacher and ask them" + '\n' + "to add it before entering data.");
}

function show_answer2(){
alert("If you do not see your METHOD listed here," + '\n' + "please contact your teacher and ask them" + '\n' + "to add it before entering data.");
}
</script>

<script src="js/datevalidation.js"></script>
<script src="js/timevalidation.js"></script>
<script src="js/numbervalidation.js"></script>

<link rel="stylesheet" href="styles/jqstyles/jquery.ui.all.css">
<link rel="stylesheet" href="styles/jqstyles/jquery.ui.timepicker.css">
<script src="js/jquery-1.7.2.js"></script>
<script src="js/ui/jquery.ui.core.js"></script>
<script src="js/ui/jquery.ui.widget.js"></script>
<script src="js/ui/jquery.ui.datepicker.js"></script>
<script src="js/ui/jquery.ui.timepicker.js"></script>
<link rel="stylesheet" href="styles/jqstyles/demos.css">

<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />

<script type="text/javascript">
var glob_siteid=1;
	$(document).ready(function(){
		$("#msg").hide();
		
		$("#viewdata").click(function() {
	window.location.href = "details.php?siteid="+glob_siteid;
	
});	

				
		
	});

//Date Validation Script Begins
function validatedate(dateid) {

var value2 = $('#' + dateid).val();
//Removing all space
var value = value2.replace(" ",""); 

//minimum length is 10. example 2012-05-31
if(value.length != 10){
	
	alert("Error on row "+dateid.slice(10, dateid.length)+": "+"Invalid date length. Date format should be YYYY-MM-DD");
	return false;
	}
if (isDate(value,dateid) == false){
	return false;
	}
return true;
}

//Check the length of each segment to ensure it is correct. The order is yyyy-mm-dd by default.
function isDate(value,dateid) {
    try {
        
        var YearIndex = 0;
        var MonthIndex = 1;
        var DayIndex = 2;
 
        value = value.replace("/","-").replace(".","-"); 
        var SplitValue = value.split("-");
        var OK = true;

		//Check the length of the year
		if (OK && SplitValue[YearIndex].length != 4){
			alert("Error on row "+dateid.slice(10, dateid.length)+": "+"Please enter the correct length for the YEAR.");
            OK = false;
			return OK;
        }
		
		//Check the length of the month
        if (OK && SplitValue[MonthIndex].length != 2){
			alert("Error on row "+dateid.slice(10, dateid.length)+": "+"Please enter the correct length for the MONTH.");
            OK = false;
			return OK;
        }
		
		//Check the length of the day
        if (SplitValue[DayIndex].length != 2){
			alert("Error on row "+dateid.slice(10, dateid.length)+": "+"Please enter the correct length for the DAY.");
            OK = false;
			return OK;
        }
		if ((SplitValue[DayIndex] == "00") || (SplitValue[MonthIndex] == "00")){
			alert("Error on row "+dateid.slice(10, dateid.length)+": "+"Incorrect date. You cannot enter 00.");
			OK = false;
			return OK;
		}		
		
        if (OK) {
            var Year = parseInt(SplitValue[YearIndex], 10);
            var Month = parseInt(SplitValue[MonthIndex], 10);
            var Day = parseInt(SplitValue[DayIndex], 10);
 
            if (OK = ((Year > 1900) && (Year <= new Date().getFullYear()))) {
				
                if (OK = (Month <= 12 && Month > 0)) {
                    var LeapYear = (((Year % 4) == 0) && ((Year % 100) != 0) || ((Year % 400) == 0));
 
                    if (Month == 2) {
						
                        OK = LeapYear ? Day <= 29 : Day <= 28;
                    }
                    else {
                        if ((Month == 4) || (Month == 6) || (Month == 9) || (Month == 11)) {
                            OK = (Day > 0 && Day <= 30);
                        }
                        else {
                      
							OK = (Day > 0 && Day <= 31);
							
                        }
                    }
                }
            }
        }
		if (OK == false){
			alert("Error on row "+dateid.slice(10, dateid.length)+": "+"Incorrect date range.");
		}
        return OK;
    }
    catch (e) {
        return false;
    }
}
//Date Validation script ends

//Time Validation Script Begins
function  validatetime(timeid){
var strval = $('#' + timeid).val();

//Minimum and maximum length is 5, for example, 01:20
	if(strval.length < 5 || strval.length > 5){
		alert("Error on row "+timeid.slice(10, timeid.length)+": "+"Invalid time. Time format should be five characters long and formatted HH:MM");
	return false;
	}

	//Removing all space
	strval = trimAllSpace(strval);
	$('#' + timeid).val(strval)

	//Split the string
	var newval = strval.split(":");
	var horval = newval[0]
	var minval = newval[1];

	//Checking hours

	//minimum length for hours is two digits, for example, 12
	if(horval.length != 2){
		alert("Error on row "+timeid.slice(10, timeid.length)+": "+"Invalid time. Hours format should be two digits long.");
		return false;
		}
	if(horval < 0){
		alert("Error on row "+timeid.slice(10, timeid.length)+": "+"Invalid time. Hours cannot be less than 00.");
		return false;
		}
	else if(horval > 23){
		alert("Error on row "+timeid.slice(10, timeid.length)+": "+"Invalid time. Hours cannot be greater than 23.");
		return false;
		}

	//Checking minutes

 	//minimum length for minutes is 2, for example, 59
	if(minval.length != 2){
		alert("Error on row "+timeid.slice(10, timeid.length)+": "+"Invalid time. Minutes format should be two digits long.");
	return false;
	} 
	if(minval < 0){
		alert("Error on row "+timeid.slice(10, timeid.length)+": "+"Invalid time. Minutes cannot be less than 00.");
		return false;
		}   
	else if(minval > 59){
		alert("Error on row "+timeid.slice(10, timeid.length)+": "+"Invalid time. Minutes cannot be greater than 59.");
		return false;
		}
	strval = IsNumeric(strval);
	$('#' + timeid).val(strval)
}

//The trimAllSpace() function will remove any extra spaces
function trimAllSpace(str) 
{ 
    var str1 = ''; 
    var i = 0; 
    while(i != str.length) 
    { 
        if(str.charAt(i) != ' ') 
            str1 = str1 + str.charAt(i); i ++; 
    } 
    return str1; 
}

//The trimString() function will remove 
function trimString(str) 
{ 
     var str1 = ''; 
     var i = 0; 
     while ( i != str.length) 
     { 
         if(str.charAt(i) != ' ') str1 = str1 + str.charAt(i); i++; 
     }
     var retval = IsNumeric(str1); 
     if(retval == false) 
         return -100; 
     else 
         return str1; 
}

//The IsNumeric() function will check whether the user has entered a numeric value or not.
function IsNumeric(strString){ 
    var strValidChars = "0123456789:"; 
    var blnResult = true; 

    //test strString consists of valid characters listed above
    for (i = 0; i < strString.length && blnResult == true; i++) 
    { 
        var strChar = strString.charAt(i); 
        if (strValidChars.indexOf(strChar) == -1) 
        {
			alert ("Invalid character. You may only use numbers.");
			strString = strString.replace(strString[i],"");
            blnResult = false;
        } 
     }
	return strString;
}
//Time Validation Script Ends

//Number validatin script
function validatenum(valid) {
var v = $('#' + valid).val();
var Value = isValidNumber(v, valid);
return Value;
}

function isValidNumber(val, valid){
      if(val==null || val.length==0){
  		  alert("Error on row "+valid.slice(5, valid.length)+": "+"Please enter a number in the Value box");
		  return false;
		  }

      var DecimalFound = false
      for (var i = 0; i < val.length; i++) {
            var ch = val.charAt(i)
            if (i == 0 && ch == "-") {
                  continue
            }
            if (ch == "." && !DecimalFound) {
                  DecimalFound = true
                  continue
            }
            if (ch < "0" || ch > "9") {
       		    alert("Error on row "+valid.slice(5, valid.length)+": "+"Please enter a valid number in the Value box");
			    return false;
            	}
      }
	  return true;
}
//Number Validation script ends
</script>


<script>
	$(function() {
		
		$( "#datepicker" ).datepicker({ dateFormat: "yy-mm-dd", constrainInput: false, showOn: "button", buttonImage: "images/calendar.gif", buttonImageOnly: true });
		
		
		$( "#timepicker" ).timepicker({ showOn: "focus", showPeriodLabels: false });
		
	});
</script>

<script type="text/javascript">
function showSites(str){

document.getElementById("txtHint").innerHTML="<select name='SiteID' id='SiteID'><option value=''>Select....</option></select>&nbsp;<a href='#' onClick='show_answer()' border='0'><img src='images/questionmark.png' border='0'></a>";

if (str=="")
  {
  document.getElementById("txtHint").innerHTML="";
  return;
  }
if (window.XMLHttpRequest)
  {// code for IE7+, Firefox, Chrome, Opera, Safari
  xmlhttp=new XMLHttpRequest();
  }
else
  {// code for IE6, IE5
  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  }
xmlhttp.onreadystatechange=function()
  {
  if (xmlhttp.readyState==4 && xmlhttp.status==200)
    {
    document.getElementById("txtHint").innerHTML=xmlhttp.responseText;
    }
  }
xmlhttp.open("GET","getsites.php?q="+str,true);
xmlhttp.send();
}

function showMethods(str){

document.getElementById("txtHint2").innerHTML="&nbsp;<a href='#' onClick='show_answer()' border='0'><img src='images/questionmark.png' border='0'></a>";

if (str=="")
  {
  document.getElementById("txtHint2").innerHTML="";
  return;
  }
if (window.XMLHttpRequest)
  {// code for IE7+, Firefox, Chrome, Opera, Safari
  xmlhttp=new XMLHttpRequest();
  }
else
  {// code for IE6, IE5
  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  }
xmlhttp.onreadystatechange=function()
  {
  if (xmlhttp.readyState==4 && xmlhttp.status==200)
    {
    document.getElementById("txtHint2").innerHTML=xmlhttp.responseText;
    }
  }
xmlhttp.open("GET","getmethods1.php?m="+str,true);
xmlhttp.send();
}

</script>

</head>

<body background="images/bkgrdimage.jpg">
<table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning Banner" /></td>
  </tr>
  <tr>
    <td colspan="2" align="right" valign="middle" bgcolor="#3c3c3c"><script src="js/header.js"></script></td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote>
      <p><br />
        <?php echo "$msg"; ?>&nbsp;<?php echo "$msg3"; ?>&nbsp;<?php echo "$msg4"; ?><div id="msg"><p class=em2>Value successfully added! <input type="button" name="viewdata" id="viewdata" value="View data inputed" /></p></div>
        <h1>Enter a single data value</h1>
      <FORM METHOD="POST" ACTION="" name="addvalue" id="addvalue">
        <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td valign="top"><strong>Source:</strong></td>
          <td valign="top"><select name="SourceID" id="SourceID" onChange="showSites(this.value)"><option value="-1">Select....</option><?php echo "$option_block"; ?></select></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td valign="top"><strong>Site:</strong></td>
          <td valign="top"><div id="txtHint"><select name="SiteID" id="SiteID"><option value="-1">Select....</option></select>&nbsp;<a href="#" onClick="show_answer()" border="0"><img src="images/questionmark.png" border="0"></a></div> 
</td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Type:</strong></td>
          <td width="370" valign="top"><select name="VariableID" id="VariableID" onChange="showMethods(this.value)"><option value="-1">Select....</option><?php echo "$option_block3"; ?></select></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td valign="top"><strong>Method:</strong></td>
          <td valign="top"><div id="txtHint2"><select name="MethodID" id="MethodID"><option value="-1">Select....</option></select>&nbsp;<a href="#" onClick="show_answer2()" border="0"><img src="images/questionmark.png" border="0"></a></div></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="370" valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Date:</strong></td>
          <td valign="top"><input type="text" id="datepicker" name="datepicker" onChange="return validateDate()" size="15">
            <span class="em">&nbsp;(YYYY-MM-DD format; Ex: 2012-05-04 for 4 May  2012)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Time:</strong></td>
          <td valign="top"><input type="text" id="timepicker" name="timepicker" onChange="return validateTime()" size="10">
            <span class="em">&nbsp;(HH:MM, 24 hour  format; Ex: 13:45 for 1:45 pm)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top"><strong>Value:</strong></td>
          <td valign="top"><input type="text" id="value" name="value" size=10 maxlength=20 onBlur="return validateNum()"/><span class="em">&nbsp;(Must be a number; no commas allowed)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td width="55" valign="top">&nbsp;</td>
          <td valign="top"><input type="SUBMIT" name="submit" value="Submit Your Data" class="button" /></td>
          </tr>
      </table>
    </FORM></p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
    </blockquote>
    <p></p></td>
  </tr>
  <tr>
    <script src="js/footer.js"></script>
  </tr>
</table>
</body>
</html>

<script>

//Calls a function to validate all fields when the submit button is hit.
$("form").submit(function(){

	if(($("#SourceID option:selected").val())==-1){
		alert("Please select a Source!");
		return false;
	}

	if(($("#SiteID option:selected").val())==-1){
		alert("Please select a Site!");
		return false;
	}
	
	glob_siteid=$("#SiteID option:selected").val();

	if(($("#VariableID option:selected").val())==-1){
		alert("Please select a Type!");
		return false;
	}

	if(($("#MethodID option:selected").val())==-1){
		alert("Please select a Method!");
		return false;
	}
	
	//Date checking
	var checkid='datepicker';
	var result=validatedate(checkid);

	if(result==false){
		return false;
	}

	//Time checking
	checkid='timepicker';
	var result=validatetime(checkid);

	if(result==false){
		return false;
	}

	//Value checking
	checkid='value';

	if(validatenum(checkid)==false){
		return false;
	}

//Validation is now complete, so send to the processing page
$.post("do_add_data_value.php", $("#addvalue").serialize(),  function( data ){

		if(data==1){
			$("#msg").show(1600);
			$("#SourceID").val(-1);
			$("#SiteID").val(-1);
			$("#VariableID").val(-1);
			$("#MethodID").val(-1);
			$("#datepicker").val("");
			$("#timepicker").val("");
			$("#value").val("");
			
			return true;
		}else{
			alert("Error in database configuration!");
			return false;
			}
	});

return false;
});
	
</script>