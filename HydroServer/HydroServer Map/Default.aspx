<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="ESRI.ArcGIS.ADF.Web.UI.WebControls, Version=9.3.1.3000, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86"
    Namespace="ESRI.ArcGIS.ADF.Web.UI.WebControls" TagPrefix="esri" %>
<%@ Register Assembly="ESRI.ArcGIS.ADF.Web.UI.WebControls, Version=9.3.0.1770, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86" Namespace="ESRI.ArcGIS.ADF.Web.UI.WebControls" TagPrefix="esri" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html style="width: 100%; height: 100%;" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HydroServer Mapping Application</title>
    <style type="text/css">
        div #Map1 {
        position:relative;
        }
    </style>
</head>
<body style="width: 100%; height: 100%; max-width:100%; max-height:100%; overflow:hidden; margin:0;" bgcolor="white">
    <form id="form1" runat="server" style="width: 100%; height: 100%;">    
        <asp:ScriptManager ID="ScriptManager1" runat="server" />		
		<esri:DockExtender ID="ScaleDock" runat="server" DockControlId="Map1" TargetControlID="ScaleBar1" Alignment="BottomCenter" />
		<esri:DockExtender ID="NavDock" runat="server" DockControlId="Map1" TargetControlID="NavHolder" Alignment="TopRight" />
		
		<div id="leftpanel" style="float:left; width:250px; height:100%; font-size: 80%;">
		    <div id="titlebar" style="position:absolute; top:0; left:0; color:#fff; font-size: 1.3em; font-weight:bold; padding-top:1px; font-family:Verdana; background:url(Images/toolbar.png) repeat-x; height:24px; width:250px; padding: 1px 0 0 5px;">
		        Map Tools
		    </div>
		    <esri:Toolbar ID="Toolbar1" runat="server" BuddyControlType="Map" Group="Toolbar1_Group" Height="30px" ToolbarItemDefaultStyle-BackColor="White" ToolbarItemDefaultStyle-Font-Names="Arial" ToolbarItemDefaultStyle-Font-Size="Smaller" ToolbarItemDisabledStyle-BackColor="White" ToolbarItemDisabledStyle-Font-Names="Arial" ToolbarItemDisabledStyle-Font-Size="Smaller" ToolbarItemDisabledStyle-ForeColor="Gray" ToolbarItemHoverStyle-BackColor="White" ToolbarItemHoverStyle-Font-Bold="True" ToolbarItemHoverStyle-Font-Italic="True" ToolbarItemHoverStyle-Font-Names="Arial" ToolbarItemHoverStyle-Font-Size="Smaller" ToolbarItemSelectedStyle-BackColor="White" ToolbarItemSelectedStyle-Font-Bold="True" ToolbarItemSelectedStyle-Font-Names="Arial" ToolbarItemSelectedStyle-Font-Size="Smaller" WebResourceLocation="/aspnet_client/ESRI/WebADF/" Width="200px" Alignment="Left" CurrentTool="MapPan" TextPosition="Right" ToolbarStyle="ImageOnly" Style="padding-top: 30px;">
			    <ToolbarItems>
				    <esri:Tool ClientAction="DragRectangle" DefaultImage="esriZoomIn.gif" HoverImage="esriZoomInU.gif" JavaScriptFile="" Name="MapZoomIn" SelectedImage="esriZoomInD.gif" ServerActionAssembly="ESRI.ArcGIS.ADF.Web.UI.WebControls" ServerActionClass="ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.MapZoomIn" Text="Zoom In" ToolTip="Zoom In" />
				    <esri:Tool ClientAction="DragRectangle" DefaultImage="esriZoomOut.gif" HoverImage="esriZoomOutU.gif" JavaScriptFile="" Name="MapZoomOut" SelectedImage="esriZoomOutD.gif" ServerActionAssembly="ESRI.ArcGIS.ADF.Web.UI.WebControls" ServerActionClass="ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.MapZoomOut" Text="Zoom Out" ToolTip="Zoom Out" />
				    <esri:Tool ClientAction="DragImage" DefaultImage="esriPan.gif" HoverImage="esriPanU.gif" JavaScriptFile="" Name="MapPan" SelectedImage="esriPanD.gif" ServerActionAssembly="ESRI.ArcGIS.ADF.Web.UI.WebControls" ServerActionClass="ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.MapPan" Text="Pan" ToolTip="Pan" />
				    <esri:Command ClientAction="" DefaultImage="esriFullExt.gif" HoverImage="esriFullExtU.gif" JavaScriptFile="" Name="MapFullExtent" SelectedImage="esriFullExtD.gif" ServerActionAssembly="ESRI.ArcGIS.ADF.Web.UI.WebControls" ServerActionClass="ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.MapFullExtent" Text="Full Extent" ToolTip="Full Extent" />
				    <esri:Command BuddyItem="MapForward" ClientAction="ToolbarMapBack" DefaultImage="esriBack.gif" Disabled="True" DisabledImage="esriBack.gif" HoverImage="esriBackU.gif" JavaScriptFile="" Name="MapBack" SelectedImage="esriBackD.gif" Text="Back" ToolTip="Map Back Extent" />
				    <esri:Command BuddyItem="MapBack" ClientAction="ToolbarMapForward" DefaultImage="esriForward.gif" Disabled="True" DisabledImage="esriForward.gif" HoverImage="esriForwardU.gif" JavaScriptFile="" Name="MapForward" SelectedImage="esriForwardD.gif" Text="Forward" ToolTip="Map Forward Extent" />
				    <esri:Tool ClientAction="Point" DefaultImage="~/Images/hyperlink.png" HoverImage="~/Images/hyperlink_hover.png" SelectedImage="~/Images/hyperlink_selected.png" JavaScriptFile="" Name="GetData" ServerActionAssembly="App_Code" ServerActionClass="CustomToolLibrary.HyperLinkTool" Text="Get Data" ToolTip="Launch Time Series Analyst" />
			    </ToolbarItems>
			    <BuddyControls>
				    <esri:BuddyControl Name="Map1" />
			    </BuddyControls>
		    </esri:Toolbar>    		
		    
		    <div style="position:absolute; top:70px; bottom:0; left:10px; width:230px; padding: 10; overflow:auto;">
		        <esri:Toc ID="Toc1" runat="server" BuddyControl="Map1" style="overflow:visible; font-family:Verdana;" />			
		    </div>
		</div>		
        
        <div style="position:absolute; left:250px; right:0; top:0; bottom:0;">
            <esri:Map ID="Map1" runat="server" MapResourceManager="MapResourceManager1" Width="100%" Height="100%" style="z-index: 100;" InitialExtent="Default" />	        
        </div>
        
		<esri:ScaleBar ID="ScaleBar1" runat="server" style="z-index: 102; left: 50%; position: absolute; top: 90%; height: 10%;" Map="Map1" BarUnits="Kilometers" />
		
		<asp:panel ID="NavHolder" runat="server" style="z-index:102; width: 15%; padding-top: 30px; left: 85%; position: absolute; top: 0%;" >
		    <table>
		    	<tr>
		    		<td>
		    			<esri:ZoomLevel ID="ZoomLevel1" runat="server" Map="Map1" />
		    		</td>
		    		<td>
		    			<esri:Navigation ID="Navigation1" runat="server" Height="100px" Map="Map1" Width="100px" DisplayImageUrl="~/Images/compass.png">
		    				<DisplayCharacter CharacterIndex="60" FontName="ESRI North" />
		    			</esri:Navigation>
		    		</td>
		    	</tr>
		    </table>
	    </asp:panel>

		<esri:MapResourceManager ID="MapResourceManager1" runat="server">
		</esri:MapResourceManager>
    </form>
</body>
</html>
