<%@ Page Language="vb" EnableSessionState="readonly" AutoEventWireup="false" CodeFile="view.aspx.vb" Inherits="RootView"  %>
<%@ PreviousPageType VirtualPath="~/default.aspx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
	<title>Time Series Analyst - Data View</title>
</HEAD>
<body>
<form id="frmExport" method="post" runat="server">
	<div align="center">
		<asp:Literal id="ltlSeriesInfo" Runat="server" /><br>
		<br>
		<br>
		<asp:datagrid id="dgODMData" width="60%" bordercolor="#999999" borderstyle="None" borderwidth="1px" backcolor="White" cellpadding="3" gridlines="Vertical" enableviewstate="False" autogeneratecolumns="False" runat="server">
			<headerstyle font-name="Arial" font-size="10pt" font-bold="True" forecolor="White" backcolor="#000084"></headerstyle>
			<alternatingitemstyle backcolor="Gainsboro"></alternatingitemstyle>
			<itemstyle font-name="Arial" font-size="10pt" forecolor="Black" backcolor="#EEEEEE"></itemstyle>
			<columns>
				<asp:boundcolumn datafield="LocalDateTime" dataformatstring="{0:g}" readonly="True" headertext="LocalDateTime"></asp:boundcolumn>
				<asp:boundcolumn datafield="DataValue" readonly="True" headertext="DataValue"></asp:boundcolumn>
			</columns>
		</asp:datagrid>
	</div>
</form>
</body>
</HTML>
