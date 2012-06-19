<?php
//check authority to be here
require_once 'authorization_check.php';

//connect to server and select database
require_once 'database_connection.php';

//get list of Titles and TopicCategories to choose from
$sql_1 ="Select DISTINCT MetadataID, Title FROM isometadata";

$result1 = @mysql_query($sql_1,$connection)or die(mysql_error());

$num1 = @mysql_num_rows($result1);
	if ($num1 < 1) {

    $msg1 = "<P><em2>Sorry, no data available.</em></p>";

	} else {

	while ($row1 = mysql_fetch_array ($result1)) {

		$metaID = $row1["MetadataID"];
		$metaTitle = $row1["Title"];

		$option_block1 .= "<option value=$metaID>$metaTitle</option>";
		
		}
	}

//get list of TopicCategories to choose from
$sql2 ="Select Term FROM topiccategorycv";

$result2 = @mysql_query($sql2,$connection)or die(mysql_error());

$num2 = @mysql_num_rows($result2);
	if ($num2 < 1) {

    $msg2 = "<P><em2>Sorry, no data available.</em></p>";

	} else {

	while ($row2 = mysql_fetch_array ($result2)) {

		$metaTerm = $row2["Term"];
		
		$option_block2 .= "<option value=$metaTerm>$metaTerm</option>";

		}
	}

?>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>

<script type="text/javascript">

$(document).ready(function() {
	
	
	$("#TopicCategory").attr('disabled', true);
	$("#Title").attr('disabled', true);
	$("#Abstract").attr('disabled', true);
	$("#ContactName4").attr('disabled', true);
	
$("#MetadataChoice").click(function() {

	$("#TopicCategory").attr('disabled', true);
	$("#Title").attr('disabled', true);
	$("#Abstract").attr('disabled', true);
	$("#ContactName4").attr('disabled', true);
});

$("#MetadataChoice1").click(function() {
	 	$("#TopicCategory").removeAttr("disabled");
	$("#Title").removeAttr("disabled");
	$("#Abstract").removeAttr("disabled");
	$("#ContactName4").removeAttr("disabled");

 
});


});

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
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>Add a new Source</h1>
      <p>&nbsp;</p>
      <FORM METHOD="POST" ACTION="" name="addsource" id="addsource">
        <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="108" valign="top"><strong>Organization:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="Organization" name="Organization" size="35" maxlength="100"/>&nbsp;<span class="em">(Ex: McCall Outdoor Science School)</span></td>
        </tr>
        <tr>
          <td width="108" valign="top">&nbsp;</td>
          <td width="22" valign="top">&nbsp;</td>
          <td width="470" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Description:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="SourceDescription" name="SourceDescription" size="35" maxlength="200"/>&nbsp;<span class="em">(Ex: The mission of the MOSS is....)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="22" valign="top">&nbsp;</td>
          <td width="470" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Link to Org:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="SourceLink" name="SourceLink" size="35" style="background-color:#9FF" maxlength="200"/>
          &nbsp;<span class="em">(Optional, Ex: http://www.mossidaho.org)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Contact Name:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="ContactName" name="ContactName" size="25" maxlength="200"/>&nbsp;<span class="em">(Full Name)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Phone:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="Phone" name="Phone" size="12" maxlength="15"/>&nbsp;<span class="em">(Ex: XXX-XXX-XXXX)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Email:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="Email" name="Email" size="12" maxlength="50"/>&nbsp;<span class="em">(Ex: info@moss.org)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Address:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="Address" name="Address" size="35" maxlength="100"/></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>City:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="City" name="City" size="25" maxlength="100"/></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>State:</strong></td>
          <td colspan="2" valign="top"><select name="state" id="state">
            <option value="-1">Select....</option>
            <option value="AL">Alabama</option>
            <option value="AK">Alaska</option>
            <option value="AZ">Arizona</option>
            <option value="AR">Arkansas</option>
            <option value="CA">California</option>
            <option value="CO">Colorado</option>
            <option value="CT">Connecticut</option>
            <option value="DE">Delaware</option>
            <option value="DC">District of Columbia</option>
            <option value="FL">Florida</option>
            <option value="GA">Georgia</option>
            <option value="HI">Hawaii</option>
            <option value="ID">Idaho</option>
            <option value="IL">Illinois</option>
            <option value="IN">Indiana</option>
            <option value="IA">Iowa</option>
            <option value="KS">Kansas</option>
            <option value="KY">Kentucky</option>
            <option value="LA">Louisiana</option>
            <option value="ME">Maine</option>
            <option value="MD">Maryland</option>
            <option value="MA">Massachusetts</option>
            <option value="MI">Michigan</option>
            <option value="MN">Minnesota</option>
            <option value="MS">Mississippi</option>
            <option value="MO">Missouri</option>
            <option value="MT">Montana</option>
            <option value="NE">Nebraska</option>
            <option value="NV">Nevada</option>
            <option value="NH">New Hampshire</option>
            <option value="NJ">New Jersey</option>
            <option value="NM">New Mexico</option>
            <option value="NY">New York</option>
            <option value="NC">North Carolina</option>
            <option value="ND">North Dakota</option>
            <option value="OH">Ohio</option>
            <option value="OK">Oklahoma</option>
            <option value="OR">Oregon</option>
            <option value="PA">Pennsylvania</option>
            <option value="RI">Rhode Island</option>
            <option value="SC">South Carolina</option>
            <option value="SD">South Dakota</option>
            <option value="TN">Tennessee</option>
            <option value="TX">Texas</option>
            <option value="UT">Utah</option>
            <option value="VT">Vermont</option>
            <option value="VA">Virginia</option>
            <option value="WA">Washington</option>
            <option value="WV">West Virginia</option>
            <option value="WI">Wisconsin</option>
            <option value="WY">Wyoming</option>
          </select></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Zip Code:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="ZipCode" name="ZipCode" size="5" maxlength="8"/></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Citation:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="Citation" name="Citation" size="35" style="background-color:#9FF" maxlength="100"/>
            &nbsp;<span class="em">(Optional, Ex: Data collected by MOSS scientists and citizen scie...)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>MetadataID:</strong></td>
          <td valign="top"><input name="radio" type="radio" id="MetadataChoice" value="existing" checked></td>
          <td valign="top"><strong>Existing:</strong>
<select name="MetadataID" id="MetadataID">
  <option value="-1">Select....</option>
  <?php echo "$option_block1"; ?>
</select>&nbsp;<?php echo "$msg1"; ?><br><span class="em">(If you select from  existing ones, you do not need to fill out anything else below.)</span></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top"><input type="radio" name="radio" id="MetadataChoice1" value="new"></td>
          <td valign="top"><strong>New</strong></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
     <div id="optional">   
        <tr>
          <td valign="top"><strong>Topic Category:</strong></td>
          <td colspan="2" valign="top"><select name="TopicCategory" id="TopicCategory">
            <option value="-1">Select....</option>
            <?php echo "$option_block2"; ?>
          </select>&nbsp;<?php echo "$msg2"; ?></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Title:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="Title" name="Title" size="35" maxlength="100"/>&nbsp;<span class="em">(Ex: Twin Falls High School)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Abstract:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="Abstract" name="Abstract" size="35" style="background-color:#9FF" maxlength="250"/>
          &nbsp;<span class="em">(Optional, Ex: High school students/citizen scientists collecting...)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Metadata Link:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="ContactName4" name="ContactName4" style="background-color:#9FF" size="12" maxlength="15"/>
&nbsp;<span class="em">(Optional)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="108" valign="top">&nbsp;</td>
          <td width="22" valign="top">&nbsp;</td>
          <td width="470" valign="top">&nbsp;</td>
        </tr>
        
        </div>
        <tr>
          <td colspan="2" valign="top"><center><input type="SUBMIT" name="submit" value="Add New Source" class="button" /></center></td>
          <td valign="top">&nbsp;</td>
          </tr>
      </table></FORM>
    <p>&nbsp;</p>
    </blockquote></td>
  </tr>
  <tr>
    <script src="js/footer.js"></script>
  </tr>
</table>

<script>

    $("#addsource").submit(function() {
      //Validate all fields


if(($("#Organization").val())=="")
{
alert("Please enter an organization for the source.");
return false;
}

if(($("#SourceDescription").val())=="")
{
alert("Please enter a description for the source.");
return false;
}


if(($("#SourceLink").val())!="")
{
var regexp = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/
if(!($("#SourceLink").val().match(regexp)))
{
	alert("Invalid url for sourcelink");
	return false;
}

}



if(($("#ContactName").val())=="")
{
alert("Please enter a contact name for the source.");
return false;
}

if(($("#Phone").val())=="")
{
alert("Please enter a phone number for the contact person.");
return false;
}

//Phone Validation

var regex = /^((\+?1-)?\d\d\d-)?\d\d\d-\d\d\d\d$/;
if(!($("#Phone").val().match(regex)))
{
	alert("Invalid phone number");
	return false;
}




if(($("#Email").val())=="")
{
alert("Please enter an email address for the source.");
return false;
}

var pattern=/^([a-zA-Z0-9_.-])+@([a-zA-Z0-9_.-])+\.([a-zA-Z])+([a-zA-Z])+/;

if(!($("#Email").val().match(pattern)))
{
	alert("Invalid email address");
	return false;
}



if(($("#Address").val())=="")
{
alert("Please enter an address for the source.");
return false;
}
if(($("#City").val())=="")
{
alert("Please enter a city for the source.");
return false;
}


if(($("#state option:selected").val())==-1)
{
alert("Please select a state for the source.");
return false;
}


if(($("#ZipCode").val())=="")
{
alert("Please enter a zip code for the source.");
return false;
}



if(!($("#ZipCode").val().match(/^\d{5}(-\d{4})?$/)))
{
	alert("Invalid zip code");
	return false;
}



//Check for Metadata Exisitng or not



if($('input:radio[id=MetadataChoice]:checked').val()=="existing")
{
	
if(($("#MetadataID option:selected").val())==-1)
{
alert("Please select an exisiting Metadata. In case you don't find it, please select 'New' option for Metadata");
return false;
}
}

//For new metadata


if($('input:radio[id=MetadataChoice1]:checked').val()=="new")
{
	
if(($("#TopicCategory option:selected").val())==-1)
{
alert("Please select a topic category for Metadata.");
return false;
}

if(($("#Title").val())=="")
{
alert("Please enter a title for Metadata.");
return false;
}


if(($("#ContactName4").val())!="")
{
var regexp = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/
if(!($("#ContactName4").val().match(regexp)))
{
	alert("Invalid url for Metadata link");
	return false;
}

}


}

//Validation Complete

$.post("do_add_source.php", $("#addsource").serialize(),  function( data ) {
  
		 if(data==1)
  {
	  alert("Source successfully added");
	  window.location.href = "add_source.php";
	  return true;
  }
  else
  {
  alert("Error in database configuration");
  return false;
  }
		
		      });


      return false;
    });
</script>


</body>
</html>
