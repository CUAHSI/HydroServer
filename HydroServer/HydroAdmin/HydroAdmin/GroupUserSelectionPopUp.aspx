<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupUserSelectionPopUp.aspx.cs" Inherits="HydroAdmin.GroupUserSelectionPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style = " z-index: 100; border-style:groove; border-color:White;  left:0px; position: absolute; top: 0px;width:98%; height:450px; overflow:auto">
        <asp:GridView ID="GroupUserSelectionGridview" runat="server">
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
        <asp:Button ID="userAddButton" Width="70px" runat="server" Text="Add" onclick="userAddButton_Click" 
             />
        <asp:Button ID="userRemoveButton" Width="70px"  runat="server" Text="Remove" onclick="userRemoveButton_Click" 
             />
        <asp:Button ID="cancelActionButton" Width="70px"  runat="server" Text="Cancel" 
            />
    </div>
    
    </div>
    
    
    
    </form>
</body>
</html>
