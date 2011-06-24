<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeSeriesInformation.aspx.cs" Inherits="HydroAdmin.TimeSeriesInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:DetailsView ID="timeSeriesInfoView" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" Height="50px" Width="125px">
        <rowstyle backcolor="LightCyan"  font-italic="true"/>
        <alternatingrowstyle backcolor="lightblue"  font-italic="true"/>
    </asp:DetailsView>
    </form>
</body>
</html>
