<%@ Control Language="vb" AutoEventWireup="false" CodeFile="Summary.ascx.vb" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" Inherits="OptionsSummary" %>
<table id="optionsTable" ><tr><td id="optionsCell">
	<div class="groupLabel" style="WidTH:42px">Statistics</div>
	<table id="outerTable"><tr><td class="groupCell" valign="top" >
		<table width="100%">
			<tr>
				<td class="inputLabel">Arithmetic Mean</td>
				<td><asp:textbox id="txtArithmeticMean" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel">Geometric Mean</td>
				<td><asp:textbox id="txtGeometricMean" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel">Maximum</td>
				<td><asp:textbox id="txtMaximum" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel">Minimum</td>
				<td><asp:textbox id="txtMinimum" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel">Standard Deviation</td>
				<td><asp:textbox id="txtStandardDeviation" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel">Coefficient of Variation</td>
				<td><asp:textbox id="txtCoefficientOfVariation" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
				<tr>
					<td colspan="2">
						<hr/>
					</td>
				</tr>
			<tr>
				<td class="inputLabel">10%</td>
				<td><asp:textbox id="txt10Percentile" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel">25%</td>
				<td><asp:textbox id="txt25Percentile" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel">Median, 50%</td>
				<td><asp:textbox id="txtMedian" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel">75%</td>
				<td><asp:textbox id="txt75Percentile" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel">90%</td>
				<td><asp:textbox id="txt90Percentile" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel"># of Observations</td>
				<td><asp:textbox id="txtNumberOfObservations" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
			<tr>
				<td class="inputLabel" style="height: 26px"><a href="JavaScript:NewWindow('options/aboutsummary.aspx')"># Censored</a></td>
				<td style="height: 26px"><asp:textbox id="txtNumberCensoredObservations" cssclass="numericalInput" readonly="True" runat="server" /></td>
			</tr>
		</table>
		<div style="overflow: auto;"><asp:label id="lblMessage" cssclass="error" enableviewstate="False" runat="server" style="z-index: 150;" BackColor="Transparent" /></div>		
	</td></tr></table>
</td></tr></table>
