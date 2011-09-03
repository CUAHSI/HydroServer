<%@ Page Language="vb" 
AutoEventWireup="false" 
CodeBehind="Login.aspx.vb" 
Inherits="WebDataLoader.Login" Theme="Default"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >  
<head id="Head1" runat="server" >
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1 align="left">  
      &nbsp;<asp:Image ID="Image1" runat="server" 
          ImageUrl="~/Images/HydroServer.png"  />
</h1>
    <div class ="container">
  <h2 >
        Web Data Loader
</h2>  
<div  align="left">


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
    <br style="position: relative" />
    <asp:Button ID="btnTestConnection" runat="server" OnClick = "btnTestConnection_Click" 
        Text="Test Connection" />


    <asp:Button ID="btnConnect" runat="server" OnClick = "btnConnect_Click" Text="Next" />


    <br />
    <br />
    <asp:Label ID="lblstatus" runat="server" ForeColor="Red"></asp:Label>


</div>


    </div>
    </form>
</body>
</html>
