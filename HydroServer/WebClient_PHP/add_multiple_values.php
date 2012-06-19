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

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client</title>


<script type="text/javascript">
function show_answer(){
alert("If you do not see your location listed here," + '\n' + "please contact your teacher and ask them" + '\n' + "to add it before entering data.");
}

function show_answer2(){
alert("If you do not see your METHOD listed here," + '\n' + "please contact your teacher and ask them" + '\n' + "to add it before entering data.");
}
</script>

<script src="js/numbervalidation.js"></script>

<link rel="stylesheet" href="styles/jqstyles/jquery.ui.all.css">
<link rel="stylesheet" href="styles/jqstyles/jquery.ui.timepicker.css">

<script src="js/jquery-1.7.2.js"></script>
<script src="js/ui/jquery.ui.core.js"></script>
<script src="js/ui/jquery.ui.widget.js"></script>
<script src="js/ui/jquery.ui.datepicker.js"></script>
<script src="js/ui/jquery.ui.timepicker.js"></script>
<script type="text/javascript" src="js/jqwidgets/jqxcore.js"></script>
<script type="text/javascript" src="js/gettheme.js"></script>
<script type="text/javascript" src="js/jqwidgets/jqxbuttons.js"></script>
<script type="text/javascript" src="js/jqwidgets/jqxscrollbar.js"></script>
<script type="text/javascript" src="js/jqwidgets/jqxlistbox.js"></script>
<script type="text/javascript" src="js/jqwidgets/jqxdropdownlist.js"></script>
<script type="text/javascript" src="js/jqwidgets/jqxdata.js"></script>
<link rel="stylesheet" href="styles/jqstyles/demos.css">
<link rel="stylesheet" href="js/jqwidgets/styles/jqx.base.css" type="text/css" />
<link rel="stylesheet" href="js/jqwidgets/styles/jqx.darkblue.css" type="text/css" />

<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />
<script type="text/javascript">



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

var row_no=1;

var row_id=new Array;
row_id[0]="VariableID1";
var source =
        {
            datatype: "json",
            datafields: [
                { name: 'variableid' },
                { name: 'variablename' },
            ],
            url: 'db_get_types.php'
        };				
	
	
		var dataAdapter = new $.jqx.dataAdapter(source);
            $(document).ready(function () {
				

				
	
//Creating the Drop Down list
        $("#VariableID1").jqxDropDownList(
        {
            source: dataAdapter,
            theme: 'darkblue',
            width: 200,
            height: 25,
            selectedIndex: 0,
            displayMember: 'variablename',
            valueMember: 'variableid'
        });		
				

$('#VariableID1').bind('select', function (event) {
var args = event.args;
var item = $('#VariableID1').jqxDropDownList('getItem', args.index);
if ((item != null)&&(item.label != "Select..")) {	
//Create a another jqery list for methods
var varid=item.value;
var source1 =
        {
            datatype: "json",
            datafields: [
                { name: 'methodid' },
                { name: 'methodname' },
            ],
            url: 'getmethods.php?m='+varid
        };				
	
	
		var dataAdapter21 = new $.jqx.dataAdapter(source1);
		
 $("#MethodID1").jqxDropDownList(
        {
            source: dataAdapter21,
            theme: 'darkblue',
            width: 200,
            height: 25,
            selectedIndex: 0,
            displayMember: 'methodname',
            valueMember: 'methodid'
        });		
}
/*
if ((item != null)&&(item.label != "Please select a variable")) {		

//Clear the Box
//$('#daterange').empty();	
$('#daterange').html("");


varname=item.label;
//varid=item.value;

//Going to the next function that will generate a list of data types available for that variable
var t=setTimeout("create_var_list()",300)



}
*/

//Create 10 rows in the beginning

for(var i=1;i<2;i++)
{
addnew('value'+i);	
}



});
runa();

				
            });
			
function runa(){
$('input[id^="value"]').click(function() {

  addnew(this.id);
});


$('input[id^="value"]').change(function() {
  addnew(this.id);
});			

$('input[id^="datepicker"]').change(function() {
  var result=validatedate(this.id);
});			

$('input[id^="timepicker"]').change(function() {
  var result1=validatetime(this.id);
});			



}
	$(function() {
		
		$( "#datepicker1" ).datepicker({ dateFormat: "yy-mm-dd" });
		
		
		$( "#timepicker1" ).timepicker({
			showOn: "focus",
    		showPeriodLabels: false,
		});
		
	});





function addnew(value_id_new)
{

var value_id='value'+row_no;

if(value_id_new==value_id)
{

row_no=row_no+1;
row_id.push("VariableID"+row_no);


var newid=row_id[row_id.length-1];


var add_html='<tr><td width="182"><div id="VariableID'+row_no+'"></div></td> <td width="249"><div id="MethodID'+row_no+'"></div></td><td width="60"><center><input type="text" id="datepicker'+row_no+'" size=10 maxlength=12 /></center></td><td width="46"><center><input type="text" id="timepicker'+row_no+'" size=7 maxlength=10></center></td><td width="51"><center><input type="text" id="value'+row_no+'" name="value'+row_no+'" onblur="runa()" size=7 maxlength=20/></center></td></tr>';

$('#multiple tr:last').after(add_html);

//Implement required javascript functions


//Creating the Drop Down list

     $('#' + newid).jqxDropDownList(
        {
            source: dataAdapter,
            theme: 'darkblue',
            width: 200,
            height: 25,
            selectedIndex: 0,
            displayMember: 'variablename',
            valueMember: 'variableid'
        });		
				

$('#' + newid).bind('select', function (event) {
var args = event.args;
var item = $(this).jqxDropDownList('getItem', args.index);
if ((item != null)&&(item.label != "Select..")) 
{
//Create a another jqery list for methods
var varid=item.value;

var source1 =
        {
            datatype: "json",
            datafields: [
                { name: 'methodid' },
                { name: 'methodname' },
            ],
            url: 'getmethods.php?m='+varid
        };				
	
	
		var dataAdapter21 = new $.jqx.dataAdapter(source1);
			
var tempid='MethodID'+newid.slice(10, newid.length);
 
 $('#' + tempid).jqxDropDownList(
        {
            source: dataAdapter21,
            theme: 'darkblue',
            width: 200,
            height: 25,
            selectedIndex: 0,
            displayMember: 'methodname',
            valueMember: 'methodid'
        });		
}

});


newid="datepicker"+row_no;

	$('#' + newid).datepicker({ dateFormat: "yy-mm-dd" });
	
$('#' + newid).change(function() {
  var result=validatedate(this.id);
});			
	
newid="timepicker"+row_no;		
		
		$('#' + newid).timepicker({
			showOn: "focus",
    		showPeriodLabels: false,
		});


}


$('#' + newid).change(function() {
  var result1=validatetime(this.id);
});			

}

function showSites(str){

document.getElementById("txtHint").innerHTML="<a href='#' onClick='show_answer()' border='0'><img src='images/questionmark.png'></a>";

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



</script>

</head>

<body background="images/bkgrdimage.jpg">
<table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning Banner" /></td>
  </tr>
  <tr>
    <td colspan="2" bgcolor="#3c3c3c">&nbsp;</td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>Enter multiple values manually</h1>
      <p>Please enter the data in the below table. Don't see enough number of rows? Don't worry! Start entering the values and see the magic happen.</p></blockquote>
      <FORM METHOD="POST" ACTION="" name="addvalue">
      <blockquote><table width="450" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="55" valign="top"><strong>Source:</strong></td>
          <td width="370" valign="top"><select name="SourceID" id="SourceID" onChange="showSites(this.value)"><option value="-1">Select....</option><?php echo "$option_block"; ?></select></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td valign="top"><strong>Site:</strong></td>
          <td valign="top"><div id="txtHint"><select name="" id=""><option value="-1">Select....</option></select>&nbsp;<a href="#" onClick="show_answer()" border="0"><img src="images/questionmark.png"></a></div></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
      </table>
      <table width="600" border="1" cellpadding="0" cellspacing="0" id="multiple">
        <tr>
          <td width="182"><center><strong>Type:</strong></center></td>
          <td width="249"><center><strong>Method:</strong> <a href="#" onclick="show_answer2()" border="0"><img src="images/questionmark.png" /></a></center></td>
          <td width="60"><center><strong>Date:</strong>**</center></td>
          <td width="46"><center><strong>Time:**</strong></center></td>
          <td width="51"><center><strong>Value:**</strong></center></td>
          </tr>
        <tr>
          <td width="182" bgcolor="#0099FF">&nbsp;</td>
          <td width="249" bgcolor="#0099FF">&nbsp;</td>
          <td width="60" bgcolor="#0099FF">&nbsp;</td>
          <td width="46" bgcolor="#0099FF">&nbsp;</td>
          <td width="51" bgcolor="#0099FF">&nbsp;</td>
          </tr>
        <tr>
          <td width="182">
     
           <div id="VariableID1"></div>
            
            </td>
          <td width="249"><div id="MethodID1"></div></td>
          <td width="60"><center><input type="text" id="datepicker1" name="datepicker1" size=10 maxlength=12/></center></td>
          <td width="46"><center><input type="text" id="timepicker1" name="timepicker1" size=7 maxlength=10></center></td>
          <td width="51"><center><input type="text" id="value1" name="value1" onblur="runa()" size=7 maxlength=20/></center></td>
          </tr>
      
        
       
      </table>
      </blockquote>
      <br/>
      <center><input type="SUBMIT" name="submit" value="Submit Your Data" class="button" /></center>
        
      </FORM><blockquote>
      <p>**<strong>Formating Notes:</strong><br />
<span class="em">Date should be formatted like this &quot;2012-05-04&quot; for 4 May  2012.<br />
Time should be formatted like this &quot;13:45&quot; for 1:45 pm</span><span class="em"><br />
Value must be a number, and no 
commas are allowed</span><br />
</p>
</blockquote>
    <p></p></td>
  </tr>
  <tr>
    <script src="footer.js"></script>
  </tr>
</table>

<script>

    $("form").submit(function() {
      //Validate all fields

//Source and site validation

if(($("#SourceID option:selected").val())==-1)
{
alert("Please select a Source. If you do not find it in the list, please visit the 'Add a new source' page");
return false;
}

if(($("#SiteID option:selected").val())==-1)
{
alert("Please select a Site. If you do not find it in the list, please visit the 'Add a new site' page");
return false;
}


//Setup form validation for all the rows in which value is present

//First check if there is any data in the last row

var final_rows;
var valid_rows=0;
var checkid='VariableID'+row_no;
var item = $('#' + checkid).jqxDropDownList('getSelectedItem'); 

checkid='MethodID'+row_no;
var item1 = $('#' + checkid).jqxDropDownList('getSelectedItem'); 

checkid='value'+row_no;

if((item.value==-1)&&(item1==undefined)&&($('#' + checkid).val()==""))
{
final_rows=row_no-1;
}
else
{
final_rows=row_no;	
}


//Now we start validating each row


for(var j=1;j<=final_rows;j++)
{

var checkid='VariableID'+j;
var item = $('#' + checkid).jqxDropDownList('getSelectedItem'); 

checkid='MethodID'+j;
var item1 = $('#' + checkid).jqxDropDownList('getSelectedItem'); 

checkid='value'+j;

if((item.value==-1)&&(item1==undefined)&&($('#' + checkid).val()==""))
{
	
}

else

{

//first check if type is selected or not
checkid='VariableID'+j;
item = $('#' + checkid).jqxDropDownList('getSelectedItem'); 

if(item.value==-1)
{
alert("Error in row "+j+": Please select a Type.");
return false;
}

checkid='MethodID'+j;
item = $('#' + checkid).jqxDropDownList('getSelectedItem'); 

if(item.value==-1)
{
alert("Error in row "+j+": Please select a Method.");
return false;
}

checkid='datepicker'+j;
var result=validatedate(checkid);

if(result==false)
{
	
return false;
}

checkid='timepicker'+j;
var result=validatetime(checkid);
if(result==false)
{
return false;
}

//Value Check
checkid='value'+j;

if(validatenum(checkid)==false)
{
	//alert("Error in row "+j+": Please enter a valid value");
return false;
}
valid_rows=valid_rows+1;

}
	
}
var final_result=1;
//Validation Complete
//Input data


if(valid_rows==0)
{
alert("Please enter atleast one value");
return false;	
}
else
{

var ajax_count=0;
for(var j=1;j<=final_rows;j++)
{

var checkid='VariableID'+j;
var item = $('#' + checkid).jqxDropDownList('getSelectedItem'); 

checkid='MethodID'+j;
var item1 = $('#' + checkid).jqxDropDownList('getSelectedItem'); 

checkid='value'+j;

if((item.value==-1)&&(item1==undefined)&&($('#' + checkid).val()==""))
{

}

else

{




var sourceid=$("#SourceID option:selected").val();
var siteid=$("#SiteID option:selected").val();
checkid='VariableID'+j;
item = $('#' + checkid).jqxDropDownList('getSelectedItem'); 
var variableid=item.value;
checkid='MethodID'+j;
item = $('#' + checkid).jqxDropDownList('getSelectedItem'); 
var methodid=item.value;
checkid='value'+j;
var value1=$('#' + checkid).val();
checkid='datepicker'+j;
var date=$('#' + checkid).val();
checkid='timepicker'+j;
var time=$('#' + checkid).val();

var temp_result=-1;

$.ajax({
  type: "POST",
  url: "do_add_multiple.php?SourceID="+sourceid+"&SiteID="+siteid+"&VariableID="+variableid+"&MethodID="+methodid+"&value="+value1+"&datepicker="+date+"&timepicker="+time
}).done(function( msg ) {
  if(msg==1)
  {
	  ajax_count=ajax_count+1;
 if(ajax_count==valid_rows)
 {
	 
	 
	 alert("Data successfully added");
	  window.location.href = "add_multiple_values.php";
	  return true;
	
 }
  temp_result=1;
  }
  else
  {
	  temp_result=-1;
	   alert("Error in database configuration");
  return false;
	  
  }
 });

}

}

}

return false;


    });
</script>

</body>
</html>
