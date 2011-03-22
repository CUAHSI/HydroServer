<%@ page language="C#" autoeventwireup="true" CodeFile="Configure.aspx.cs" inherits="Configure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Configuration: CUAHSI Web Services for ODM</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <p>
            Back to the <a href="Default.aspx"> Service Description</a></p>
        <h1>
          
        Edit the configuration:
        </h1>
       
        &nbsp;&nbsp;<asp:Label ID="lbl_error" runat="server" Font-Bold="True" Font-Size="XX-Large"
            ForeColor="Red" Width="326px"></asp:Label>
        <div style="width: 373px; height: 32px">
            <asp:Label ID="lblNetwork" runat="server" Text="ODM Network Prefix (network)" Width="216px"></asp:Label>
            <asp:TextBox ID="txt_Network" runat="server" Columns="8" ToolTip="A Brief code for the Network name of the OD"></asp:TextBox></div>
    
    </div>
        <div style="width: 372px; height: 25px">
            <asp:Label ID="lbl_vocabulary" runat="server" Text="ODM Vocabulary Prefix (vocabulary)"></asp:Label>
            <asp:TextBox ID="txt_Vocabulary" runat="server" Columns="8"></asp:TextBox></div>
        <div style="width: 520px; height: 42px">
            <asp:Label ID="lbl_connectionstring" runat="server" Text="Database Connection String"></asp:Label>
            <asp:TextBox ID="txt_odmconnectionString" runat="server" Width="304px"></asp:TextBox>&nbsp;
            <br />
            <asp:CheckBox ID="cb_encryptConnectionString" runat="server" Text="Encrypt Connection String" />&nbsp;
            </div>
        <div style="z-index: 100; left: 0px; width: 520px; position: relative; top: 0px;
            height: 48px">
            <asp:Label ID="lblSeriesName" runat="server" Style="z-index: 100; left: 0px; position: relative;
                top: 0px" Text="Series Name" Width="120px"></asp:Label>
            <asp:TextBox ID="txtSeriesName" runat="server" Style="z-index: 102; left: 3px; position: relative;
                top: 0px" Width="336px"></asp:TextBox></div>
        <div style="z-index: 101; left: 0px; width: 520px; position: relative; top: 0px;
            height: 100px">
            <asp:Label ID="lblContactEmail" runat="server" Style="z-index: 100; left: 0px; position: absolute;
                top: 0px" Text="Contact Email" Width="104px"></asp:Label>
            <asp:TextBox ID="txtContactEmail" runat="server" Style="z-index: 102; left: 184px;
                position: absolute; top: 0px" Width="248px">Contact Email</asp:TextBox>
        </div>
        <br />
        <strong>
        Optional:<br />
        </strong>
        <div style="width: 370px; height: 37px">
            <asp:Label ID="lbl_serviceExampleHTMLPage" runat="server" Text="Service Description Page or URL"></asp:Label>
            <asp:TextBox ID="txt_serviceExampleHTMLPage" runat="server"></asp:TextBox></div>
        <br />
        <br />
        <asp:Button ID="btn_ok" runat="server" OnClick="btn_ok_Click" Text="Ok" />
        <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="cancel" /><br /><br />
<span><a target="_top" href=DatabaseTest.aspx>Test Database Connection (be sure to click Ok above first)</a></span>
    </form>
</body>
</html>
