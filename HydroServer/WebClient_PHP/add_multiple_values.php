<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />
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
    <td width="240" valign="top" bgcolor="#f2e6d6"><SCRIPT src="A_navbar.js"></SCRIPT></td>
    <td width="720" valign="top" bgcolor="#FFFFFF"><blockquote><br />
      <h1>Enter multiple values</h1>
      <p>Need to enter more than 10 values? Try the <a href="#">import csv file</a> method!</p>
      <FORM METHOD="POST" ACTION="do_add_data_value.php">
      <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td valign="top"><strong>Source:</strong></td>
          <td valign="top"><select name="SourceID" id="SourceID">
            <option value="MOSS">McCall Outdoor Science School</option>
          </select></td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Site:</strong></td>
          <td valign="top"><select name="SiteID" id="SiteID">
            <option value="">Select....</option>
            <option value="MOSS-DES-BC">Boulder Creek at Donnelly Elementary</option>
            <option value="MOSS-JMR-BC">Boulder Creek at Jug Mountain Ranch</option>
            <option value="MOSS-NM">Cyberlearning Summit Site</option>
          </select>
            <div class="em"></div></td>
          <td valign="top"><span class="em">&nbsp;(Case sensitive; enter 6-8 characters)</span></td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td width="59" valign="top"><strong>Type:</strong></td>
          <td width="284" valign="top"><select name="VariableID" id="VariableID">
            <option value="">Select....</option>
            <option value="IDCS-1">Oxygen, dissolved</option>
            <option value="">Etc.</option>
            <option value="">Etc.</option>
            </select></td>
          <td width="257" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top"><strong>Method:</strong></td>
          <td valign="top"><select name="authority5" id="authority6">
            <option value="">Select....</option>
            <option value="">Hach Water Quality Test Kit</option>
            <option value="">pHydrion pH Strips (1-14)</option>
            <option value="">Sharp EC WP Electrical Conductivity Meter</option>
          </select></td>
          <td valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
          <td width="284" valign="top">&nbsp;</td>
          <td width="257" valign="top">&nbsp;</td>
        </tr>
      </table>
      <table width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><center><strong>Date:</strong></center></td>
          <td><center><strong>Time:</strong></center></td>
          <td><center><strong>Value:</strong></center></td>
        </tr>
        <tr>
          <td><center>
            <span class="em">(Ex: &quot;04052012&quot; for 4 May  2012)</span>
          </center></td>
          <td><center>
            <span class="em">(Ex: &quot;13:45&quot; for 1:45 pm)</span>
          </center></td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td><center><input type="text" name="lastname" size=25 maxlength=50 /></center></td>
          <td><center><input type="text" name="username" size=25 maxlength=25 /></center></td>
          <td><center><input type="text" name="password" size=25 maxlength=25 /></center></td>
        </tr>
        <tr>
          <td colspan="3"><center><input type="SUBMIT" name="submit" value="Submit Your Data" /></center></td>
          </tr>
      </table>
      <p><strong>Hidden values to also add:</strong><br />
<input name="ValueID" type="hidden" value="" />ValueID<br />
<input name="UTCOffset" type="hidden" value="" />UTCOffset<br />
<input name="DateTimeUTC" type="hidden" value="" />DateTimeUTC<br />
<input name="CensorCode" type="hidden" value="" />CensorCode<br />
<input name="QualityControlLevelID" type="hidden" value="0" />QualityControlLevelID</p>
<p><strong>What about these values?</strong><br />
  <input name="" type="hidden" value="" />ValueAccuracy<br />
  <input name="" type="hidden" value="" />OffsetValue<br />
  <input name="" type="hidden" value="" />OffsetTypeID<br />
  <input name="" type="hidden" value="" />Qualifier<br />
  <input name="" type="hidden" value="" />SampleID<br />
  <input name="" type="hidden" value="" />DerivedFromID</FORM></p>
</blockquote>
    <p></p></td>
  </tr>
  <tr>
    <script src="footer.js"></script>
  </tr>
</table>
</body>
</html>
