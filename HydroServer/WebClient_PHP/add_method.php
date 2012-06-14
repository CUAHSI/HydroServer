<?php
//check authority to be here
require_once 'authorization_check.php';

//redirect anyone that is not an administrator
if ($_COOKIE[power] !="admin"){
	header("Location: index.php?state=pass2");
	exit;	
	}

?>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />
<link rel="stylesheet" href="jqwidgets/styles/jqx.base.css" type="text/css" />
<script type="text/javascript" src="scripts/gettheme.js"></script>
<script type="text/javascript" src="scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="jqwidgets/jqxcore.js"></script>
<script type="text/javascript" src="jqwidgets/jqxdata.js"></script>
<script type="text/javascript" src="jqwidgets/jqxbuttons.js"></script>
<script type="text/javascript" src="jqwidgets/jqxscrollbar.js"></script>
<script type="text/javascript" src="jqwidgets/jqxlistbox.js"></script>

<script type="text/javascript">
	
	//put together the Variable array			
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
	
    $(document).ready(function (){
				
		//Creating the list box
		$("#VariableID1").jqxListBox(
    		{
			source: dataAdapter,
		    theme: 'darkblue',
			multiple: true,
    	    width: 300,
			height: 250,
		    displayMember: 'variablename',
       	    valueMember: 'variableid'
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
    <td colspan="2" bgcolor="#3c3c3c">&nbsp;</td>
  </tr>
  <tr>
    <td width="240" valign="top" bgcolor="#f2e6d6"><?php echo "$nav"; ?></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>Add a new Method</h1>
      <p>&nbsp;</p>
      <FORM METHOD="POST" ACTION="do_add_method.php" name="addmethod">
        <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="101" valign="top"><strong>Method Name:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="MethodDescription" name="MethodDescription" size=20 maxlength=100"/>&nbsp;<span class="em">(Ex: YSI DO 200 Meter)</span></td>
        </tr>
        <tr>
          <td width="101" valign="top">&nbsp;</td>
          <td width="229" valign="top">&nbsp;</td>
          <td width="270" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Method Link:</strong></td>
          <td colspan="2" valign="top"><input type="text" id="MethodLink" name="MethodLink" size=20 maxlength=200"/>&nbsp;<span class="em">(Ex: http://www.ysi.com/productsdetail.php?DO200-35)</span></td>
          </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="3" valign="top"><strong>Variable(s) used by this method:</strong> <br>
            (select all that apply by holding the &quot;Ctrl&quot; key down and selecting multiple options):</td>
          </tr>
        <tr>
          <td colspan="3" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td colspan="2" valign="top"><div id="VariableID1"></div></td>
          </tr>
        <tr>
          <td width="101" valign="top">&nbsp;</td>
          <td width="229" valign="top">&nbsp;</td>
          <td width="270" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2" valign="top"><center><input type="SUBMIT" name="submit" value="Add New Method" class="button"/></center></td>
          <td valign="top">&nbsp;</td>
          </tr>
      </table></FORM>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
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
