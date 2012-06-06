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

//add the Methods
$sql4 ="Select * FROM methods";

$result4 = @mysql_query($sql4,$connection)or die(mysql_error());

$num = @mysql_num_rows($result4);
	if ($num < 1) {

    $msg4 = "<P><em2>Sorry, there are no Methods.</em></p>";

	} else {

	while ($row4 = mysql_fetch_array ($result4)) {

		$methodid = $row4["MethodID"];
		$methodname = $row4["MethodDescription"];

		$option_block4 .= "<option value=$methodid>$methodname</option>";

		}
	}

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />

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
<link rel="stylesheet" href="styles/jqstyles/demos.css">
<script>
	$(function() {
		
		$( "#datepicker" ).datepicker({ dateFormat: "yy-mm-dd" });
		
		
		$( "#timepicker" ).timepicker({
			showOn: "focus",
    		showPeriodLabels: false,
		});
		
	});
</script>

<script type="text/javascript">
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
      <p>Need to enter more than 10 values? Try the <a href="import_data_file.php">import csv file</a> method!</p></blockquote>
      <FORM METHOD="POST" ACTION="do_add_data_value.php" name="addvalue">
      <blockquote><table width="450" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="55" valign="top"><strong>Source:</strong></td>
          <td width="370" valign="top"><select name="SourceID" id="SourceID" onChange="showSites(this.value)"><option value="">Select....</option><?php echo "$option_block"; ?></select></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
        <tr>
          <td valign="top"><strong>Site:</strong></td>
          <td valign="top"><div id="txtHint"><select name="" id=""><option value="">Select....</option></select>&nbsp;<a href="#" onClick="show_answer()" border="0"><img src="images/questionmark.png"></a></div></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          </tr>
      </table></blockquote>
      <table width="600" border="1" cellspacing="0" cellpadding="0">
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
          <td width="182"><select name="VariableID" id="VariableID">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td width="249"><select name="MethodID" id="MethodID">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td width="60"><center><input type="text" id="datepicker" name="datepicker1" size=10 maxlength=12 /></center></td>
          <td width="46"><center><input type="text" id="timepicker" name="timepicker1" size=7 maxlength=10></center></td>
          <td width="51"><center><input type="text" id="value" name="value" size=7 maxlength=20 onBlur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td width="182"><select name="VariableID2" id="VariableID2">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td width="249"><select name="MethodID2" id="MethodID2">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td width="60"><center><input type="text" id="datepicker2" name="datepicker2" size="10" maxlength="12" /></center></td>
          <td width="46"><center><input type="text" id="timepicker2" name="timepicker2" size="7" maxlength="10" /></center></td>
          <td width="51"><center><input type="text" id="value2" name="value2" size="7" maxlength="20" onblur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td><select name="VariableID3" id="VariableID3">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td><select name="MethodID3" id="MethodID3">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td><center><input type="text" id="datepicker3" name="datepicker3" size="10" maxlength="12" /></center></td>
          <td width="46"><center><input type="text" id="timepicker3" name="timepicker3" size="7" maxlength="10" /></center></td>
          <td width="51"><center><input type="text" id="value3" name="value3" size="7" maxlength="20" onblur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td><select name="VariableID4" id="VariableID4">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td><select name="MethodID4" id="MethodID4">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td><center><input type="text" id="datepicker4" name="datepicker4" size="10" maxlength="12" /></center></td>
          <td width="46"><center><input type="text" id="timepicker4" name="timepicker4" size="7" maxlength="10" /></center></td>
          <td width="51"><center><input type="text" id="value4" name="value4" size="7" maxlength="20" onblur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td><select name="VariableID5" id="VariableID5">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td><select name="MethodID5" id="MethodID5">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td><center><input type="text" id="datepicker5" name="datepicker5" size="10" maxlength="12" /></center></td>
          <td width="46"><center><input type="text" id="timepicker5" name="timepicker5" size="7" maxlength="10" /></center></td>
          <td width="51"><center><input type="text" id="value5" name="value5" size="7" maxlength="20" onblur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td><select name="VariableID6" id="VariableID6">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td><select name="MethodID6" id="MethodID6">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td><center><input type="text" id="datepicker6" name="datepicker6" size="10" maxlength="12" /></center></td>
          <td width="46"><center><input type="text" id="timepicker6" name="timepicker6" size="7" maxlength="10" /></center></td>
          <td width="51"><center><input type="text" id="value6" name="value6" size="7" maxlength="20" onblur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td><select name="VariableID7" id="VariableID7">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td><select name="MethodID7" id="MethodID7">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td><center><input type="text" id="datepicker7" name="datepicker7" size="10" maxlength="12" /></center></td>
          <td width="46"><center><input type="text" id="timepicker7" name="timepicker7" size="7" maxlength="10" /></center></td>
          <td width="51"><center><input type="text" id="value7" name="value7" size="7" maxlength="20" onblur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td><select name="VariableID8" id="VariableID8">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td><select name="MethodID8" id="MethodID8">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td><center><input type="text" id="datepicker8" name="datepicker8" size="10" maxlength="12" /></center></td>
          <td width="46"><center><input type="text" id="timepicker8" name="timepicker8" size="7" maxlength="10" /></center></td>
          <td width="51"><center><input type="text" id="value8" name="value8" size="7" maxlength="20" onblur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td><select name="VariableID9" id="VariableID9">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td><select name="MethodID9" id="MethodID9">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td><center><input type="text" id="datepicker9" name="datepicker9" size="10" maxlength="12" /></center></td>
          <td width="46"><center><input type="text" id="timepicker9" name="timepicker9" size="7" maxlength="10" /></center></td>
          <td width="51"><center><input type="text" id="value9" name="value9" size="7" maxlength="20" onblur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td><select name="VariableID10" id="VariableID10">
              <option value="">Select....</option>
              <?php echo "$option_block3"; ?>
            </select></td>
          <td><select name="MethodID10" id="MethodID10">
            <option value="">Select....</option>
            <?php echo "$option_block4"; ?>
          </select></td>
          <td><center><input type="text" id="datepicker10" name="datepicker10" size="10" maxlength="12" /></center></td>
          <td width="46"><center><input type="text" id="timepicker10" name="timepicker10" size="7" maxlength="10" /></center></td>
          <td width="51"><center><input type="text" id="value10" name="value10" size="7" maxlength="20" onblur="return validateNum()"/></center></td>
          </tr>
        <tr>
          <td colspan="5">&nbsp;</td>
          </tr>
        <tr>
          <td colspan="5"><center><input type="SUBMIT" name="submit" value="Submit Your Data" /></center></td>
          </tr>
      </table></FORM><blockquote>
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
</body>
</html>
