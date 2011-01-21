<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="WebDataLoader.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<div style="width:500px;">


    <asp:Label ID="lblServerAddress" runat="server" Text="Server Address:    "></asp:Label>
    <asp:TextBox ID="txtServerAddress" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblDatabaseName" runat="server" Text="Database Name: "></asp:Label>
    <asp:TextBox ID="txtDatabaseName" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblUserID" runat="server" Text="Server User ID: "></asp:Label>
    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Server Password: "></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>


    <br />
    <br />
    <asp:Button ID="btnTestConnection" runat="server" 
        Text="Test Connection" />


    <asp:Button ID="btnConnect" runat="server" Text="Next" />


    <br />
    <br />
    <asp:Label ID="lblstatus" runat="server" ForeColor="Red"></asp:Label>


</div>


    </div>
    </form>
</body>
</html>
