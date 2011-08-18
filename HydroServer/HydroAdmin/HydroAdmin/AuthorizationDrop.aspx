<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AuthorizationDrop.aspx.cs" Inherits="HydroAdmin.AuthorizationDrop" %>

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
        
        <div class="art-Sheet" style="z-index: 101 ; height:1100px;">
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
                			<a href="Groups.aspx" ><span class="l"></span><span class="r"></span><span class="t">Groups</span></a>                			
                		</li>
                		<li>
                			<a href="DataRequest.aspx"><span class="l"></span><span class="r"></span><span class="t">Data Request</span></a>                			
                		</li>	
                		<li>
                			<a href="AuthorizationDrop.aspx" class=" active" style="z-index: 100"><span class="l"></span><span class="r"></span><span class="t">Admin</span></a>&nbsp;
                		</li>    
                	</ul>
                </div>
                <div class="art-contentLayout-main">
                    <div class="art-content-main" style="left: 0px; top: 0px ; height:860px;">
                        <div class="art-Post">
                            <div class="art-Post-body">
                        
                                <div class="art-PostHeader">
                                    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                    <div style = " z-index: 100;  left:0px; position: absolute; top: 0px;width:100%; height:25px" >
                                    <div style = " z-index: 100;  left:0px; position: absolute; top: 0px;width:40%; height:25px">
                                    <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:center; background-color:#13242e;">ODM List</td>
                                       </tr>
                                  </table>
                                    </div>
                                    <div style = " z-index: 100;  left:300px; position: absolute; top: 0px;width:60%; height:25px">
                                    <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:center; background-color:#13242e;">Users/Groups List</td>
                                       </tr>
                                  </table>
                                    </div>
                                    </div>
                                    
                                    <div style = " z-index: 100;left : 0px; position: absolute; top: 30px;width:100%; height:320px" >
                                      <div style = " z-index: 100; border-style:ridge; left : 0px; position: absolute; top: 0px;width:40%; height:320px" >
                                          
                                          <asp:ListBox ID="DbListBox" runat="server" Height="327px" Width="290px" 
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
                                         <asp:GridView ID="userGroupGridView" runat="server" Font-Size="Small" 
                                                  onrowdatabound="userGroupGridView_RowDataBound" 
                                                  onselectedindexchanged="userGroupGridView_SelectedIndexChanged">
                                                  <HeaderStyle BorderStyle="Solid" CssClass="header" />
                                          <Columns>  
                                                <asp:ButtonField CommandName="Select" Text="Button" Visible="False" />
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="selectUserGroupCheckBox" runat="server"   AutoPostBack="true" OnCheckedChanged="selectUserGroupCheckBox_CheckedChanged"  onclick ="CheckOne(this)" />
                                                    </ItemTemplate>                    
                                                </asp:TemplateField>
                                            </Columns>
                                          </asp:GridView>
                                          </div>
                                      </div>
                                  </div>
                                  <div style = " z-index: 100; left:0px;position: absolute; top: 360px;width:100%; height:25px"> 
                                  <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:left; background-color:#13242e;">Filters 
                                           </td>
                                       </tr>
                                  </table>
                                  </div>
                                  
                                  
                                  
                                  <div style=" text-align:left;  border-width:thin;  border-color:#13242e; z-index: 100;left : 0px; vertical-align:middle; border-style:groove; position: absolute; top: 390px;width:99%; height:36px;">
                                  <asp:CheckBox ID="enableFiltersCheckBox" runat="server" Font-Size="13px" Text="SiteCode Filter" 
                                                   AutoPostBack="True" oncheckedchanged="enableFiltersCheckBox_CheckedChanged" 
                                                   />
                                                   <asp:DropDownList ID="siteCodeDropDownList" runat="server" Width="130px" 
                                                     AutoPostBack="True" 
                                                     onselectedindexchanged="siteCodeDropDownList_SelectedIndexChanged">
                                                 </asp:DropDownList>
                                                 <asp:CheckBox ID="enableVariableCodeFilter" runat="server" 
                                             Font-Size="13px" Text="VariableCode Filter" 
                                                   AutoPostBack="True" oncheckedchanged="enableVariableCodeFilter_CheckedChanged" 
                                                   />
                                                   <asp:DropDownList ID="variableCodeDropDownList" runat="server" Width="170px" 
                                                     AutoPostBack="True" 
                                                     onselectedindexchanged="variableCodeDropDownList_SelectedIndexChanged">
                                                 </asp:DropDownList>
                                                 <asp:Button ID="resetOdmInfoButton" runat="server" Text="Reset" 
                                          onclick="resetOdmInfoButton_Click" />
                                  
                                  </div>
                                  
                                  
                                   <div id="DataDiv" style = " z-index: 100; border-style:ridge; left : 0px; position: absolute; top: 435px; width:99%; height:375px; overflow:auto;">
                                      <asp:GridView ID="odmInfoGridView" runat="server" Font-Size="X-Small" 
                                          BorderStyle="Solid"  onprerender="odmInfoGridView_PreRender" 
                                          AutoGenerateColumns="true" 
                                          onrowcreated="odmInfoGridView_RowCreated" 
                                          ondatabound="odmInfoGridView_DataBound">
                                      <HeaderStyle BorderStyle="Solid" CssClass="header" />
                                      <rowstyle backcolor="LightCyan"  
                                               font-italic="true"/>
                                            <alternatingrowstyle backcolor="lightblue"  
                                              font-italic="true"/>
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
                                <asp:TemplateField HeaderText="Information">
                                    <ItemTemplate>
                                    <asp:HyperLink ID="odmInfoLink" runat="server" Font-Size="X-Small">View</asp:HyperLink>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    
                               <asp:TemplateField HeaderText="Site Code">
                                    <ItemTemplate>
                                    <asp:Table ID="sitecodetable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    <Columns>  
                                    
                                <asp:TemplateField HeaderText="Variable Code">
                                    <ItemTemplate>
                                    <asp:Table ID="variablecodetable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    
                                    <Columns>  
                                <asp:TemplateField HeaderText="General Category">
                                    <ItemTemplate>
                                    <asp:Table ID="generalcategorytable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    <Columns>  
                                    
                                <asp:TemplateField HeaderText="Value Type">
                                    <ItemTemplate>
                                    <asp:Table ID="valuetypetable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    
                                    <Columns>  
                                <asp:TemplateField HeaderText="Sample Medium">
                                    <ItemTemplate>
                                    <asp:Table ID="samplemediumtable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    
                                    <Columns>  
                                <asp:TemplateField HeaderText="QC Level">
                                    <ItemTemplate>
                                    <asp:Table ID="qcleveltable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    
                                    <Columns>  
                                <asp:TemplateField HeaderText="Method Description">
                                    <ItemTemplate>
                                    <asp:Table ID="methoddescriptiontable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    
                                     <Columns>  
                                <asp:TemplateField HeaderText="Organization">
                                    <ItemTemplate>
                                    <asp:Table ID="organizationtable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    
                                     <Columns>  
                                <asp:TemplateField HeaderText="Source Description">
                                    <ItemTemplate>
                                    <asp:Table ID="sourcedescriptiontable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    
                                     <Columns>  
                                <asp:TemplateField HeaderText="DateTime Range">
                                    <ItemTemplate>
                                    <asp:Table ID="datetimerangetable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    
                                     <Columns>  
                                <asp:TemplateField HeaderText="# of observations">
                                    <ItemTemplate>
                                    <asp:Table ID="observationstable" runat="server"></asp:Table>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                    
                                    
                                      </asp:GridView>
                                  </div>        
                                  
                                  <div style = " z-index: 100;  left:0px; text-align:right; position: absolute; top: 825px;width:100%; height:25px">
                                      <asp:Button ID="updateAccessControl" runat="server" Text="Update" 
                                          onclick="updateAccessControl_Click" />
                                  </div>
                                    &nbsp;&nbsp;
                                
                        </div>
                        		<div class="cleared"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="cleared"></div><div class="art-Footer">
                    <div class="art-Footer-inner" style="left: 0px; top: -4px">
                        
                        <div class="art-Footer-text">
                            <p align="right"><a href="#" >Contact Us</a></p>
                        </div>
                    </div>
                    <div class="art-Footer-background" style="left: 4px; bottom: -80px"></div>
                </div>
        		<div class="cleared"></div>
            </div>
        </div>
        <div class="cleared"></div>
        
    </div>
    </form>
</body>
</html>