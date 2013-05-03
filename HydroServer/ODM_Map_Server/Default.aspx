<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ODM Map Server</title>
    <link href="styles/Styles.css" rel="stylesheet" type="text/css">
	<script language="javascript" src="scripts/preloadImages.js"></script>
	<script language="javascript" src="scripts/mapWindow.js"></script>
	<script language="javascript" src="scripts/analystPopup.js"></script>
</head>
<body onload="initialize()" onunload="GUnload()">
	<!-- Specify the Google Maps API Key -->
	<asp:literal id="ltlMaps" runat="server" />
	<!-- Create the Javascipt of the Google Map -->
	<SCRIPT type="text/javascript">
		//<![CDATA[
		var map;
		function initialize() {
			if (GBrowserIsCompatible()) {
				//Create the map
				map = new GMap2(document.getElementById("map"));
				map.addControl(new GOverviewMapControl());
				map.addMapType(G_PHYSICAL_MAP);
				map.removeMapType(G_SATELLITE_MAP);
				var topRight = new GControlPosition(G_ANCHOR_TOP_RIGHT, new GSize(20,40));
				map.addControl(new GLargeMapControl(), topRight);
				map.addControl(new GMapTypeControl());	
							
				//Set the map zoom
				<asp:literal id="ltlZoomExtents" runat="server" />
				
				//Add the scale bar to map
				var scalePos = new GControlPosition(G_ANCHOR_BOTTOM_LEFT, new GSize(75,10)); 
				map.addControl(new GScaleControl(), scalePos);
				
				//Set the default map type
				map.setMapType(G_PHYSICAL_MAP);
																				
				//Add the monitoring sites to the map
				<asp:literal id="ltlSitesScript" runat="server" />
				
				//Monitor the window resize event and let the map know when it occurs
				if (window.attachEvent) { 
					window.attachEvent("onresize", function() {this.map.onResize()} );
				} else {
					window.addEventListener("resize", function() {this.map.onResize()} , false);
				}					
			}
		}
		function createMarker(point, htmlString, markerOptions) {  
			var marker = new GMarker(point, markerOptions);  
			GEvent.addListener(marker, "click", function() {    
				marker.openInfoWindowHtml(htmlString);  
			});  
			return marker;
		}
		//]]>
	</SCRIPT>
	<!-- Declare the Google Map div -->
	<div id="map" class="map"></div>
	<form id=frmGMap runat="server">		
		<!-- Add the left panel content on top of the map -->
		<div id="leftpanel" class="leftpanel" style="width: 225px"></div>
		<asp:Panel id="pnlLegend" Visible="False" Runat="Server">
			<asp:literal id="ltlNetworkLegend" runat="server"></asp:literal>
		</asp:Panel>
		<asp:Panel Id="pnlQueryOptions" Visible="True" Runat="server">
			<DIV class="leftpanel" id="leftpanelcontents" style="width: 250px">
				<P style="MARGIN-LEFT: 50px"><IMG src="images/logo.gif"></P><B>Network Query</B> 
				<P style="MARGIN-TOP: 10px">Select an observation Network from the list to display the sites for that network.</P>
				<asp:DropDownList id="ddlNetworks" style="MARGIN-TOP: 10px; WIDTH: 220px" runat="server" autopostback="True"></asp:DropDownList>
				<P style="MARGIN-TOP: 20px"><B>Site Query</B></P>
				<P style="MARGIN-TOP: 10px">Select a variable from the list to display only those sites with data for the selected variable.</P>
				<asp:DropDownList id="ddlVariables" style="MARGIN-TOP: 10px; WIDTH: 220px" runat="server" autopostback="True"></asp:DropDownList>
			</DIV>
		</asp:Panel>
		<div class="copyright"><br>
			© 2007, <A href="http://uwrl.usu.edu" target="_blank" class="copyright">Utah Water Research Laboratory.</A><br>
			<a href="http://www.usu.edu" target="_blank" class="copyright">Utah State University</a><br>
			All rights reserved.
		</div>
		<!-- Tabs -->
		<div id="tabs" style="left: 20px; top: 16px">
			<table width="100%">
				<tr valign="bottom">
					<td width="50%" align="center"><asp:linkbutton id="lnkQueryOptions" runat="server"><div id="tabQueryOptions" class="activeTab" runat="server">Query&nbsp;Options</div></asp:linkbutton></td>
					<td width="50%" align="center"><asp:linkbutton id="lnkLegend" runat="server"><div id="tabLegend" class="inactiveTab" runat="server">Legend</div></asp:linkbutton></td>
				</tr>
			</table>
		</div>
		<div class="logo">
			<a href="http://www.usu.edu" target="_blank"><img src="images/small-wordmark.gif" border="0" ></a>
		</div>
    </form>
</body>
</html>
