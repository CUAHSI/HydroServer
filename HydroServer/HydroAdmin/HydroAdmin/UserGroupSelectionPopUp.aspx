<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserGroupSelectionPopUp.aspx.cs" Inherits="HydroAdmin.UserGroupSelectionPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style = " z-index: 100; border-style:groove; border-color:White;  left:0px; position: absolute; top: 0px;width:98%; height:450px; overflow:auto">
        <asp:GridView ID="userGroupSelectionGridview" runat="server">
        <Columns>  
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
        </asp:GridView>
    </div >
    <div style = " z-index: 100; text-align:left; border-color:White;  left:0px; position: absolute; top: 455px;width:98%; height:30px;">
        <asp:Button ID="groupAddButton" Width="70px" runat="server" Text="Apply" 
            onclick="groupAddButton_Click" />
        <asp:Button ID="groupRemoveButton" Width="70px"  runat="server" Text="Apply" 
            onclick="groupRemoveButton_Click" />
        <asp:Button ID="cancelActionButton" Width="70px"  runat="server" Text="OK" 
            onclick="cancelActionButton_Click" />
    </div>
    
    
    </div>
    
    
    
    </form>
</body>
</html>
