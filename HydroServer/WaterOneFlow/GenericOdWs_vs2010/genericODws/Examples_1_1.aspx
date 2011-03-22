<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Examples_1_1.aspx.cs" Inherits="Examples_1_1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
   
      <!-- add getSites Box -->
      <!-- add GetValues methods -->
    
   <asp:Repeater ID="GetSites" runat="server" >
    <HeaderTemplate>
    <p>GetSites Examples</p>
    <table>
    <tr>
    <td>GetSites()</td>
    </tr>
    </HeaderTemplate>
 
    <ItemTemplate>
    <tr>
<td>GetSites(<%#Container.DataItem%>)</td>

</tr>
    </ItemTemplate>
    <FooterTemplate>
    </table></FooterTemplate>
    </asp:Repeater>  
    
      
    <asp:Repeater ID="GetSiteInfo" runat="server" >
    <HeaderTemplate>
    <p>GetSiteInfo Examples</p> 
    <table>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
<td>GetSiteInfo(<%#Container.DataItem%>)</td>

</tr>
    </ItemTemplate>
    <FooterTemplate>
    </table></FooterTemplate>
    </asp:Repeater>
       
    <asp:Repeater ID="GetVariableInfo" runat="server" >
    <HeaderTemplate>
    <p>VariableInfo</p>
    <table><tr>
    <td>GetVariableInfo()</td>
    </tr></HeaderTemplate>
    <ItemTemplate>
    <tr>
<td>GetVariableInfo(<%#Container.DataItem%>)</td>

</tr>
    </ItemTemplate>
    <FooterTemplate>
    </table></FooterTemplate>
    </asp:Repeater>
    
      <asp:Repeater ID="GetVariableInfoDetailed" runat="server" >
    <HeaderTemplate>
    <p>GetVariableInfo With Detailed Information</p>
    <table>
     </HeaderTemplate>
    <ItemTemplate>
    <tr>
<td>GetVariableInfo(<%#Container.DataItem%>)</td>

</tr>
    </ItemTemplate>
    <FooterTemplate>
    </table></FooterTemplate>
    </asp:Repeater>
    </form>
</body>

</html>
