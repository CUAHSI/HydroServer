<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserQuickInfo.aspx.cs" Inherits="HydroAdmin.UserQuickInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="z-index: 100;left : 0px; position: absolute; top: 0px;width:300px;  height:200px;">
    <div style="z-index: 100;left : 0px; position: absolute; top: 0px;width:100%;  height:25px;"  >
    <table style=" width:100%; background-color:#E7E7FF; height: 25px">
           <tr>
           <td style=" width:100%; border:none; text-align:center;">User Information</td>
           </tr>
    </table>
    </div>
        <div style="z-index: 100;left : 0px; position: absolute;top: 30px;width:100%;height:170px;">
        
            <asp:DetailsView ID="UserDetailsView" runat="server" BackColor="White" 
                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                GridLines="Horizontal" Height="50px" Width="300px">
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
            </asp:DetailsView>
        </div>
    </div>
    </form>
</body>
</html>
