<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebDataLoader.aspx.vb" Inherits="WebDataLoader.WebDataLoader"  Theme="Default"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>HydroServer Web Data Loader</title>
</head>
<body>
<h1>  
      &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/HydroServer.png" />
</h1>
    <form id="form1" runat="server">
    
<h2 >
    Web Data Loader
</h2>
    
   <div class ="container" align="left"> 
&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" 
           Text="To load a file into the database, click Browse and select a file, then Upload File. "></asp:Label>
&nbsp;<p align="left">
    <asp:FileUpload ID="fuOpenFilePath" size = "40px" runat="server" Height="24px" />

    <asp:Button ID="btnUpload" runat="server" Text="Upload file" />

    

        <asp:Button ID="btnCommit" runat="server" Text="Commit File" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</p>
        <p>
    <asp:Label ID="lblstatus" runat="server" ForeColor="Red"></asp:Label>



</p>
    <asp:Panel ID="Panel1" runat="server" 
        ScrollBars="Auto" Height="500px" >
        <asp:GridView ID="dgvData" runat="server" BackColor="White" 
    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"    
            HorizontalAlign="Left">
            <RowStyle BackColor="white" ForeColor="#003399" />
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        </asp:GridView>
    </asp:Panel>



<p>
    <asp:Table ID="tabledata" runat="server">
    </asp:Table>
    </p>




    </div>
    </form>
</body>
</html>
