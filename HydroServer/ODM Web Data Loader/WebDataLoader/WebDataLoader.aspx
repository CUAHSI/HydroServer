<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebDataLoader.aspx.vb" Inherits="WebDataLoader.WebDataLoader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        

<div style="width:800px;">
&nbsp;&nbsp;
<p>
    <asp:FileUpload ID="fuOpenFilePath" runat="server" Width="257px" />

    <asp:Button ID="btnUpload" runat="server" Text="Upload file" />

    

        <asp:Button ID="btnCommit" runat="server" Text="Commit File" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel Selection" />
</p>
        <p>
    <asp:Label ID="lblstatus" runat="server" ForeColor="Red"></asp:Label>



</p>
<asp:GridView ID="dgvData" runat="server" BackColor="White" 
    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
    Height="200px" Width="500px">
    <RowStyle BackColor="white" ForeColor="#003399" />
    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
</asp:GridView>



<p>
    <asp:Table ID="tabledata" runat="server">
    </asp:Table>
    </p>
</div>



    </div>
    </form>
</body>
</html>
