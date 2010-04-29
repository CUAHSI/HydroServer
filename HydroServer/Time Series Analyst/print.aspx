<%@ Page Language="vb" EnableSessionState="readonly" AutoEventWireup="false" CodeFile="print.aspx.vb" Inherits="RootPrint"%>
<%@ PreviousPageType VirtualPath="~/default.aspx" %>
<%@ Register Src="Graphs/ZGBoxWhisker.ascx" TagName="ZGBoxWhisker" TagPrefix="Plot" %>
<%@ Register Src="Graphs/ZGHistogram.ascx" TagName="ZGHistogram" TagPrefix="Plot" %>
<%@ Register Src="Graphs/ZGProbability.ascx" TagName="ZGProbability" TagPrefix="Plot" %>
<%@ Register Src="Graphs/ZGTimeSeries.ascx" TagName="ZGTimeSeries" TagPrefix="Plot" %>
<%@ Register Src="Options/PlotOptions.ascx" TagName="PlotOptions" TagPrefix="Options" %>
<%@ Register Src="Options/Summary.ascx" TagName="Summary" TagPrefix="Options" %>

<!doctype html public "-//w3c//dtd html 4.0 transitional//en">
<html>
	<head>
		<title>Time Series Analyst - Print View</title>
		<style>
			.heading { FONT-SIZE: 24px; FONT-FAMILY: 'Times New Roman',Roman,Georgia,serif }
			.subheading { FONT-SIZE: 18px; FONT-FAMILY: 'Times New Roman',Roman,Georgia,serif }
			.content { FONT-SIZE: 16px; FONT-FAMILY: 'Times New Roman',Roman,Georgia,serif }
			TD { FONT-SIZE: 13px; FONT-FAMILY: Arial,Helvetica,sans-serif }
		</style>
	</head>
	<body>
		<form id="frmPrint" method="post" runat="server">
			<div align="center">
				<asp:Literal id="ltlSeriesInfo" Runat="server" /><br/>
				<br/>
				<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
				<br/>
				<br/>
				<br/>
				<table cellpadding=4>
					<tr>
						<td><b>Arithmetic Mean</b></td>
						<td width=20></td>
						<td align="right"><asp:label id="lblArithmeticMean" runat="server" /></td>
						<td width=60></td>
						<td><b>10%</b></td>
						<td width=20></td>
						<td align="right"><asp:label id="lbl10Percentile" runat="server" /></td>
					</tr>
					<tr>
						<td><b>Geometric Mean</b></td>
						<td></td>
						<td align="right"><asp:label id="lblGeometricMean" runat="server" /></td>
						<td></td>
						<td><b>25%</b></td>
						<td></td>
						<td align="right"><asp:label id="lbl25Percentile" runat="server" /></td>
					</tr>
					<tr>
						<td><b>Maximum</b></td>
						<td></td>
						<td align="right"><asp:label id="lblMaximum" runat="server" /></td>
						<td></td>
						<td><b>Median, 50%</b></td>
						<td></td>
						<td align="right"><asp:label id="lblMedian" runat="server" /></td>
					</tr>
					<tr>
						<td><b>Minimum</b></td>
						<td></td>
						<td align="right"><asp:label id="lblMinimum" runat="server" /></td>
						<td></td>
						<td><b>75%</b></td>
						<td></td>
						<td align="right"><asp:label id="lbl75Percentile" runat="server" /></td>
					</tr>
					<tr>
						<td><b>Standard Deviation</b></td>
						<td></td>
						<td align="right"><asp:label id="lblStandardDeviation" runat="server" /></td>
						<td></td>
						<td><b>90%</b></td>
						<td></td>
						<td align="right"><asp:label id="lbl90Percentile" runat="server" /></td>
					</tr>
					<tr>
						<td><b>Coefficient of Variation</b></td>
						<td></td>
						<td align="right"><asp:label id="lblCoefficientOfVariation" runat="server" /></td>
						<td></td>
						<td><b># of Observations</b></td>
						<td></td>
						<td align="right"><asp:label id="lblNumberOfObservations" runat="server" /></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</html>
