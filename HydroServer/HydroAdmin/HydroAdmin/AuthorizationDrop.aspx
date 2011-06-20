<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorizationDrop.aspx.cs" Inherits="HydroAdmin.AuthorizationDrop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Information Systems </title>

    <link rel="stylesheet" href="stylesheets/style.css" type="text/css" media="screen" />
    <script type ="text/javascript">
    function CheckOne(obj)
    {
        var grid = obj.parentNode.parentNode.parentNode;
        var inputs = grid.getElementsByTagName("input"); 
        for(var i=0;i<inputs.length;i++)
        {
            if (inputs[i].type =="checkbox")
            {
                if(obj.checked && inputs[i] != obj && inputs[i].checked)
                {
                    inputs[i].checked = false;
                }
            }
        }
    }
    
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="art-page-background-simple-gradient">
    </div>
    <div id="art-main" style="left: 0px; top: 0px">
        &nbsp;&nbsp;
        <div class="art-Sheet" style="z-index: 101">
            <div class="art-Sheet-tl"></div>
            <div class="art-Sheet-tr"></div>
            <div class="art-Sheet-bl"></div>
            <div class="art-Sheet-br"></div>
            <div class="art-Sheet-tc"></div>
            <div class="art-Sheet-bc"></div>
            <div class="art-Sheet-cl"></div>
            <div class="art-Sheet-cr"></div>
            <div class="art-Sheet-cc"></div>
            <div class="art-Sheet-body">
                <div class="art-Header">
                    <div class="art-Header-png"></div>
                    <div class="art-Header-jpeg"></div>
                    <div class="art-Logo">
                        <h1 id="name-text" class="art-Logo-name"><a href="main.aspx">Hydro Security</a></h1>
                        <div id="slogan-text" class="art-Logo-text">Access Control System </div>
                    </div>
                </div>
                <div class="art-nav">
                	<div class="l"></div>
                	<div class="r"></div>
                	<ul class="art-menu">
                		<li>
                			<a href="Main.aspx" ><span class="l"></span><span class="r"></span><span class="t">Resources</span></a>
                		</li>
                		<li>
                			<a href="users.aspx" ><span class="l"></span><span class="r"></span><span class="t">Users</span></a>                			
                		</li>		
                		<li>
                			<a href="DataRequest.aspx"><span class="l"></span><span class="r"></span><span class="t">Data Request</span></a>                			
                		</li>	
                		<li>
                			<a href="#" class=" active" style="z-index: 100"><span class="l"></span><span class="r"></span><span class="t">Admin</span></a>&nbsp;
                		</li>    
                	</ul>
                </div>
                <div class="art-contentLayout-main">
                    <div class="art-content-main" style="left: 0px; top: 0px">
                        <div class="art-Post">
                            <div class="art-Post-body">
                        
                                <div class="art-PostHeader">
                                    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                    
                                    
    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                    
                                    
                                    
                                    <div style = " z-index: 100;left : 0px; position: absolute; top: 0px;width:100%; height:320px" >
                                      <div style = " z-index: 100; border-style:ridge; left : 0px; position: absolute; top: 0px;width:40%; height:320px" >
                                          
                                          <asp:ListBox ID="DbListBox" runat="server" Height="325px" Width="300px" 
                                              AutoPostBack="True" onselectedindexchanged="DbListBox_SelectedIndexChanged"></asp:ListBox>
                                          
                                      </div>
                                      <div style = " z-index:100;  border-style:ridge; float:right; position: relative; top: 0px;width:60%; height:320px" >
                                          <div style = " z-index:100; text-align:left;   border-bottom-style:groove; float:right; position: relative; top: 0px;width:98%; height:20px" >
                                              <asp:CheckBox ID="userCheckBox" runat="server" Font-Size="Small" Text="Users" 
                                                  Width="60px" AutoPostBack="True" 
                                                  oncheckedchanged="userCheckBox_CheckedChanged" />
                                              <asp:CheckBox ID="groupCheckBox" runat="server" Font-Size="Small" Text="Groups" 
                                                  Width="60px" AutoPostBack="True" 
                                                  oncheckedchanged="groupCheckBox_CheckedChanged" />
                                          </div>
                                          <div style = " z-index:100; text-align:left;   border-bottom-style:groove; float:right; position: relative; top: 5px;width:98%; height:290px; overflow:auto;">
                                         <asp:GridView ID="userGroupGridView" runat="server" Font-Size="Small">
                                          <Columns>  
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="selectUserGroupCheckBox" runat="server"   AutoPostBack="false"  onclick ="CheckOne(this)"/>
                                                    </ItemTemplate>                    
                                                </asp:TemplateField>
                                            </Columns>
                                          </asp:GridView>
                                          </div>
                                      </div>
                                  </div>
                                  <div style=" text-align:left; z-index: 100;left : 0px; position: absolute; top: 330px;width:100%; height:20px; border-style:groove">
                                  <asp:Label ID="recordCount" runat="server" Width="120px" Font-Size="Small"></asp:Label>
                                         
                                         <asp:DropDownList ID="siteCodeDropDownList" runat="server" Width="120px" 
                                          AutoPostBack="True" 
                                          onselectedindexchanged="siteCodeDropDownList_SelectedIndexChanged">
                                         </asp:DropDownList>
                                         <asp:DropDownList ID="variableCodeDropDownList" runat="server" Width="120px" 
                                          AutoPostBack="True" 
                                          onselectedindexchanged="variableCodeDropDownList_SelectedIndexChanged" >
                                         </asp:DropDownList>
                                         <asp:Button ID="resetOdmInfoButton" runat="server" Text="Reset" 
                                          onclick="resetOdmInfoButton_Click" />
                                          <asp:Button ID="authorizationUpdate" runat="server" Text="Update" onclick="authorizationUpdate_Click" 
                                          />
                                  </div>
                                  </div>
                                  <div id="gridviewtable" style=" z-index: 100; border-style:ridge; left : 0px; position: absolute; top: 370px; width:100%; height:20px; overflow:auto;" >
                                  <asp:Table ID="Table1" runat="server">
                                  </asp:Table>
                                  </div>
                                  <div id="DataDiv" style = " z-index: 100; border-style:ridge; left : 0px; position: absolute; top: 400px; width:100%; height:240px; overflow:auto;">
                                      <asp:GridView ID="odmInfoGridView" runat="server" Font-Size="Small" 
                                          BorderStyle="Solid"  onprerender="odmInfoGridView_PreRender" 
                                          AutoGenerateColumns="true" 
                                          onrowcreated="odmInfoGridView_RowCreated" 
                                          ondatabound="odmInfoGridView_DataBound">
                                      <HeaderStyle BorderStyle="Solid" CssClass="header" />
                                      <Columns>  
                                <asp:TemplateField HeaderText="Read">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="readStatusCheckBox" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>                    
                                </asp:TemplateField>
                                 <asp:TemplateField  HeaderText="Update">
                                    <ItemTemplate >
                                        <asp:CheckBox ID="updateStatusCheckBox" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>                    
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="deleteStatusCheckBox" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TimeSeries Id">
                                    <ItemTemplate>
                                    <asp:HyperLink ID="odmInfoLink" runat="server" Font-Size="Small">View</asp:HyperLink>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                
                                            </Columns>
                                      </asp:GridView>
                                  </div>
                                  
                                </div>        
                                    &nbsp;&nbsp;
                                
                        
                        		<div class="cleared"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="cleared"></div><div class="art-Footer">
                    <div class="art-Footer-inner" style="left: 0px; top: -4px">
                        
                        <div class="art-Footer-text">
                            <p align="right"><a href="#" >Contact Usund&quot; style=&quot;left: 4px; bottom: -80px&quot;&gt;div>
        
        
        
    </div>
    </form>
</body>
</html>
