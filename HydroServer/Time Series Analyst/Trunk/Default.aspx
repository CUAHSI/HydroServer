<%@ Page Language="vb" CodeFile="default.aspx.vb" AutoEventWireup="false" Inherits="RootDefault" %>
<%@ Register Src="Graphs/ZGBoxWhisker.ascx" TagName="ZGBoxWhisker" TagPrefix="Plot" %>
<%@ Register Src="Graphs/ZGHistogram.ascx" TagName="ZGHistogram" TagPrefix="Plot" %>
<%@ Register Src="Graphs/ZGProbability.ascx" TagName="ZGProbability" TagPrefix="Plot" %>
<%@ Register Src="Graphs/ZGTimeSeries.ascx" TagName="ZGTimeSeries" TagPrefix="Plot" %>
<%@ Register Src="Options/PlotOptions.ascx" TagName="PlotOptions" TagPrefix="Options" %>
<%@ Register Src="Options/Summary.ascx" TagName="Summary" TagPrefix="Options" %>

<!doctype html public "-//w3c//dtd html 4.0 transitional//en">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Time Series Analyst</title>
    <link href="css/Styles.css" rel="stylesheet" />
    <link href="css/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
	<script src="js/jquery-min.js" type="text/javascript" language="javascript"></script>
	<script src="js/jquery-ui-min.js" type="text/javascript" language="javascript"></script>
    <script src="js/default.js" type="text/javascript" language="javascript">
		<!--
			showHideTooltip = function () 
			{
				var obj = document.getElementById("ddlMethod");
				document.getElementById("tooltip").innerHTML = obj.options[obj.selectedIndex].value;
				if(event.type == "mouseleave") 
				{
					document.getElementById("tooltip").style.display = "none";
				} 
				else 
				{
					document.getElementById("tooltip").style.display = "inline"
					document.getElementById("tooltip").style.top = event.y;
					document.getElementById("tooltip").style.left = event.x;
				}
			}
		//-->
    </script>
	<script type="text/javascript" language="javascript">
	    var dtForm = '<%= dtFormat %>';

	    $(function() { $("#beginDatePicker").datepicker({ showOn: 'button', buttonImage: 'images/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, duration: '', dateFormat: dtForm}); });
	    $(function() { $("#endDatePicker").datepicker({ showOn: 'button', buttonImage: 'images/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, duration: '', dateFormat: dtForm }); });
	</script>
</head>
<body id="body" runat="server">
    <form id="frmAnalyst" onsubmit="document.body.style.cursor='wait'" method="post" runat="server">
        <!-- Connection Objects -->
<%--		<asp:SqlDataSource ID="SelectSite" runat="server" ConnectionString="" SelectCommand="SELECT DISTINCT [SiteCode], [SiteCode] + ': '+ [SiteName] as SiteString FROM [SeriesCatalog]"></asp:SqlDataSource>
		<asp:SqlDataSource ID="SelectVar" runat="server" ConnectionString="" SelectCommand="SELECT DISTINCT [VariableCode], [SiteCode], [VariableCode] + ': ' + [VariableName] + ' in ' + [VariableUnitsName] + ' (' + CAST([TimeSupport] as VarChar(10)) +' '+ [TimeUnitsName] +' '+ [DataType] + ')' as VarInfo FROM [SeriesCatalog]"></asp:SqlDataSource>--%>
        <!-- Main Menu -->
        <div id="mainMenu" >
            <table>
                <tr>
                    <td class="menu" id="fileMenuCell" onmouseover="openMenu('fileMenu')" onmouseout="closeMenu('fileMenu')">
                        File
                    </td>
                    <td class="menu" id="graphMenuCell" onmouseover="openMenu('graphMenu')" onmouseout="closeMenu('graphMenu')">
                        Graph
                    </td>
                    <td class="menu" id="dataMenuCell" onmouseover="openMenu('dataMenu')" onmouseout="closeMenu('dataMenu')">
                        Data
                    </td>
                </tr>
            </table>
        </div>
        <div id="fileMenu" class="menu" onmouseover="openMenu('fileMenu')" onmouseout="closeMenu('fileMenu')" style="z-index:101;" >
            <asp:LinkButton id="mnuFilePrint" runat="server" OnClientClick="window.open('print.aspx');">
                <div id="miPrint" class="menuItem" runat="server">
					Print&nbsp;Version
                </div>
            </asp:LinkButton>
            <asp:LinkButton id="mnuFilePrintAction" runat="server" />
			<hr width ="50px" />
            <asp:HyperLink id="mnuFileExit" runat="server" NavigateUrl="javascript:self.close()">
                <div id="miExit" class="menuItem" runat="server">
					Exit
                </div>
            </asp:HyperLink>
        </div>
        <div id="graphMenu" class="menu" onmouseover="openMenu('graphMenu')" onmouseout="closeMenu('graphMenu')" style="z-index: 101">
            <asp:LinkButton id="mnuGraphPlot" runat="server">
                <div id="miPlot" class="menuItem" runat="server">
                    Plot
                </div>
            </asp:LinkButton>
            <asp:LinkButton id="mnuGraphClear" runat="server">
                <div id="miClear" class="menuItem" runat="server">
                    Clear
                </div>
            </asp:LinkButton>
        </div>
        <div id="dataMenu" class="menu" onmouseover="openMenu('dataMenu')" onmouseout="closeMenu('dataMenu')" style="z-index: 101">
			<asp:LinkButton ID="mnuDataView" runat="server" OnClientClick="window.open('view.aspx');" >
                <div id="miView" class="menuItem" runat="server">
                    View
                </div>
			</asp:LinkButton>
            <asp:LinkButton id="mnuDataViewAction" runat="server" />
            <asp:LinkButton id="mnuMyDBExport" runat="server">
                <div id="miMyDBExport" class="menuItem" runat="server">
                    Export&nbsp;MyDB&#133;
                </div>
            </asp:LinkButton>
            <asp:LinkButton id="mnuMetaExport" runat="server">
                <div id="miMetaExport" class="menuItem" runat="server">
                    Export&nbsp;Metadata&#133;
                </div>
            </asp:LinkButton>
        </div>
        <!-- Tabbed Graphs -->
        <div id="tabbedGraphs">
            <!-- Tabs -->
            <table >
                <tr valign="bottom">
                    <td>
                        <asp:LinkButton id="lnkTimeSeries" runat="server">
                            <div id="tabTimeSeries" class="activeTab" runat="server" >
                                Time&nbsp;Series
                            </div>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton id="lnkProbability" runat="server">
                            <div id="tabProbability" class="inactiveTab" runat="server" >
                                Probability
                            </div>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton id="lnkHistogram" runat="server">
                            <div id="tabHistogram" class="inactiveTab" runat="server" >
                                Histogram
                            </div>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton id="lnkBoxWhisker" runat="server">
                            <div id="tabBoxWhisker" class="inactiveTab" runat="server">
                                Box&nbsp;Whisker
                            </div>
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
            <!-- Pages -->
            <Plot:ZGTimeSeries id="objTimeSeries" runat="server"  Visible="true" />
            <Plot:ZGProbability id="objProbability" runat="server" Visible="false" />
            <Plot:ZGHistogram id="objHistogram" runat="server" Visible="false" />
            <Plot:ZGBoxWhisker id="objBoxWhisker" runat="server" Visible="false" />
        </div>
        <!-- Tabbed Options -->
        <div id="tabbedOptions" >
            <!-- Tabs -->
            <table >
                <tr valign="bottom">
                    <td>
                        <asp:LinkButton id="lnkSummary" runat="server">
                            <div id="tabSummary" class="activeTab" runat="server">
                                Summary
                            </div>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton id="lnkPlotOptions" runat="server">
                            <div id="tabPlotOptions" class="inactiveTab" runat="server">
                                Plot&nbsp;Options
                            </div>
                        </asp:LinkButton>
                     </td>
                </tr>
            </table>
            <!-- Pages -->
            <Options:Summary id="objSummary" runat="server" Visible="true" />
            <Options:PlotOptions id="objPlotOptions" runat="server" Visible="false"  />
        </div>
        <!-- Control Panel -->
        <div id="controlPanel" enableviewstate="true">
           <asp:Panel id="pnlQueryBorder" runat="server" Width="765px" GroupingText="Select Data:">
					<table cellspacing="3" width="740px">
						<tr>
							<td>
								Pick&nbsp;a&nbsp;Site:
							</td>
							<td>
								<asp:DropDownList id="ddlSites" runat="server" DataValueField="SiteCode" DataTextField="SiteString" Font-Size="8pt" Width="500px" AutoPostBack="True" />
							</td>
							<td>
								Begin&nbsp;Date:
							</td>
							<td>
								<asp:Textbox ID="beginDatePicker" runat="server" Font-Size="8pt" SkinID="beginDatePicker" Width="76px"/>
							</td>
						</tr>
						<tr>
							<td>
								Pick&nbsp;a&nbsp;Variable:
							</td>
							<td>
								<asp:DropDownList id="ddlVars" runat="server" DataValueField="VariableCode" DataTextField="VarInfo" Font-Size="8pt" Width="500px" AutoPostBack="True" />
							</td>
							<td>
								End&nbsp;Date:
							</td>
							<td>
								<asp:TextBox ID="endDatePicker" runat="server" Font-Size="8pt" SkinID="endDatePicker" Width="75px" />
							</td>
						</tr>
					</table>
            </asp:Panel>
            <asp:Panel id="pnlDataSeriesBorder" runat="server" GroupingText="Select a Data Series to Plot" Width="765px">
                <asp:Panel id="pnlDataSeries" runat="server" Height="100px" ScrollBars="Auto" Width="743px">
						<asp:GridView ID="gvSelected" runat="server" AutoGenerateColumns="False" CssClass="gvSelected" Width="1100px" DataKeyNames="SeriesID">
						    <Columns>
								<asp:CommandField SelectText="" ShowSelectButton="True" SelectImageUrl="images/ts.gif" ButtonType="Image">
									<HeaderStyle Wrap="False" />
								</asp:CommandField>
								<asp:BoundField DataField="SiteType" HeaderText="Site Type" >
									<HeaderStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="GeneralCategory" HeaderText="General Category" >
									<HeaderStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="ValueType" HeaderText="Value Type" >
									<HeaderStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="SampleMedium" HeaderText="Sample Medium" >
									<HeaderStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="QualityControlLevelid" HeaderText="QC Level" >
									<HeaderStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="MethodDescription" HeaderText="Method Description" >
									<HeaderStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="Organization" HeaderText="Organization" >
									<HeaderStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="SourceDescription" HeaderText="Source Description" >
									<HeaderStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="DateTimeRange" HeaderText="Date Time Range" >
									<HeaderStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="ValueCount" HeaderText="# of Observations" />
						    </Columns>
							<RowStyle Font-Names="Arial" Font-Size="Smaller" VerticalAlign="Top" BackColor="White" HorizontalAlign="Left" />
							<SelectedRowStyle Font-Names="Arial" Font-Size="Smaller" ForeColor="Maroon" BackColor="#C0C0FF" />
							<HeaderStyle Font-Bold="True" Font-Names="Arial" Font-Size="12px" Font-Strikeout="False" HorizontalAlign="Center" VerticalAlign="Top" Wrap="False" />
							<PagerSettings Mode="NextPrevious" Visible="False" />
						</asp:GridView>
                </asp:Panel>
            </asp:Panel>
            <div align="right">
				<asp:Button id="btnPlot" runat="server" Text="Plot" />
				<asp:Button id="btnClearGraph" runat="server" Text="Clear Graph" />
            </div>
		</div>
	</form>
</body>
</html>
