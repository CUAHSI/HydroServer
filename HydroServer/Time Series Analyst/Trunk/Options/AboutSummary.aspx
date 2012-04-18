<%@ Page Language="vb" AutoEventWireup="false" CodeFile="AboutSummary.aspx.vb" Inherits="AboutSummary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <title>About the TS Analyst Statisitcal Summary</title>
    <link href="../Styles.css" rel="stylesheet"/>
  </head>
  <body>
    <form id="frmAboutSummary" method="post" runat="server">
		<table>
		<!--div-->
			<tr>
				<td class="groupCell">Summary statistics for datasets that have censored data are calculated using robust methods described in <a href="http://water.usgs.gov/pubs/twri/twri4a3/" target="_blank">Helsel and Hirsch (2002)</a>.  The summary statistics presented are subject to the following constraints:</td>
			</tr>
			<tr>
				<td class="groupCell">
					<ul>
						<li>Censored data statistics are calculated only for a single censoring level.  Multiple censoring levels are not currently supported.</li>
						<li>Censored data statistics are calculated only for datasets with observations below a censoring level.  Datasets with values above a censoring level are not currently supported.</li>
					</ul>
				</td>
			</tr>			
		<!--/div-->
		</table>
    </form>
  </body>
</html>
