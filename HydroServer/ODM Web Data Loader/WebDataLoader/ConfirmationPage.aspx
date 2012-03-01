<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConfirmationPage.aspx.vb" Inherits="WebDataLoader.ConfirmationPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HydroServer Web Data Loader</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/HydroServer.png" /></h1>  
            <h2>Web Data Loader</h2>
            <div class ="container" align="left">
                <asp:Label ID="lblFilesSaved" runat="server" Text=""></asp:Label>
                <p align="left">
                    <asp:Button ID="btnNewFile" runat="server" Text="Add Another File to Current Database" />
                    <asp:Button ID="btnNewDB" runat="server" Text="Connect to a New Database" />
                </p>
            </div>
        </div>
    </form>
</body>
</html>
