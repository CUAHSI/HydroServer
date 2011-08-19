<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="HydroAdmin._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Information Systems </title>

    <link rel="stylesheet" href="stylesheets/style.css" type="text/css" media="screen" />
   
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
                			<a href="Main.aspx" class=" active"><span class="l"></span><span class="r"></span><span class="t">Resources</span></a>
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
                			<a href="AuthorizationDrop.aspx" style="z-index: 100"><span class="l"></span><span class="r"></span><span class="t">Admin</span></a>&nbsp;
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
                                    <div style = " z-index: 100;  left:0px; position: absolute; top: 0px;width:31%; height:25px">
                                    <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:center; background-color:#13242e;">ODM List</td>
                                       </tr>
                                  </table>
                                    </div>
                                    <div style = " z-index: 100;  left:240px; position: absolute; top: 0px;width:68%; height:25px">
                                    <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:center; background-color:#13242e;">ODM Information</td>
                                       </tr>
                                  </table>
                                    </div>
                                    </div>
                                    
                                    
                                    
                                    
                                    
                                    
                                    <div class="infolist-block" style="z-index: 100; height:250px; border-style:groove; left: 0px; position: absolute; top: 31px">
                                    <asp:ListBox ID="odmList"  runat="server" Height="245px" Width="225px" 
                                            BackColor="#E7F2F9" 
                                            ForeColor="Black" AutoPostBack="True" 
                                            onselectedindexchanged="odmList_SelectedIndexChanged" 
                                             Font-Size="11pt"></asp:ListBox>
                                        <asp:SqlDataSource ID="HydroSecureODMList" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:SecurityDb %>" 
                                            SelectCommand="select distinct databasename from TimeSeriesResource;">
                                        </asp:SqlDataSource>
                                        <%--<div style = "z-index:100; left:0px; text-align:right">
                                        <asp:LinkButton ID="addODM" runat="server" Font-Size="Small" onclick="addODM_Click">Add</asp:LinkButton>
                                        <asp:LinkButton ID="updateODM" runat="server" Font-Size="Small" >Update</asp:LinkButton>
                                        <asp:LinkButton ID="deleteODM" runat="server" Font-Size="Small" onclick="deleteODM_Click">Delete</asp:LinkButton>
                                        </div>--%>
                                     </div> 
                                     
                                     <div style = "z-index:100; position:absolute; top:285px; width:30%; left:7px; text-align:right">
                                        <asp:LinkButton ID="addODM" runat="server" Font-Size="Small" ForeColor="#13242e" onclick="addODM_Click">Add</asp:LinkButton>
                                        <asp:LinkButton ID="updateODM" runat="server" Font-Size="Small"  ForeColor="#13242e">Update</asp:LinkButton>
                                        <asp:LinkButton ID="deleteODM" runat="server" Font-Size="Small" ForeColor="#13242e" onclick="deleteODM_Click">Delete</asp:LinkButton>
                                        </div>
                                     
                                     
                                     <div class="info-block"  style="z-index:100; height:265px; border-style:groove; left: 240px; position: absolute; top: 31px">
                               <table class="contacts" border="1">
                               <tr>
                               <td class="contactDept">Title</td><td class="value"><asp:TextBox ID="Title" 
                                       runat="server" Width="395px" BorderColor="#404040" Height="25px"></asp:TextBox></td>
                               </tr>
                               <tr><td class="contactDept">Server Name</td><td class="value">
                                   <asp:TextBox ID="serverName" runat="server" Width="395px" BorderColor="#404040" 
                                       Height="25px"></asp:TextBox></td>
                               </tr>
                               <tr><td class="contactDept">Topic</td><td class="value"><asp:TextBox ID="Topic" 
                                       runat="server" Width="395px" BorderColor="#404040" Height="25px"></asp:TextBox></td>
                               </tr>
                               <tr><td class="contactDept" style ="height:60px">Abstract</td><td class="value">
                                   <asp:TextBox ID="abstractODM" runat="server" Width="395px" BorderColor="#404040" 
                                       Height="52px" TextMode="MultiLine"></asp:TextBox></td>
                               </tr>
                               <tr><td class="contactDept" style ="height:60px">Citation</td><td class="value">
                                   <asp:TextBox ID="citation" runat="server" Width="395px" BorderColor="#404040" 
                                       Height="52px" TextMode="MultiLine"></asp:TextBox></td>
                               </tr>
                               </table>
                                     </div>
                                     
                                     
                                     
                                     <div style = " z-index: 100; left:0px;position: absolute; top: 305px;width:99.5%; height:25px"> 
                                  <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:left; background-color:#13242e;">Filters 
                                           </td>
                                       </tr>
                                  </table>
                                  </div>
                                     
                                     
                                     
                                     <div style=" text-align:left;   border-width:thin;  border-color:#13242e; z-index: 100;left : 0px; vertical-align:middle; border-style:groove; position: absolute; top: 335px;width:99%; height:36px;">
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
                                  
                                  </div>
                                     
                                     
                                   
                                     
                                     <div class="info-block"  style="z-index:100; height:450px; border-style:groove; width:99%; left: 0px; position:absolute; top: 380px; overflow: auto">
                                        
                                         <asp:GridView ID="odmInfoGridView" runat="server" Font-Size="X-Small" 
                                             onrowcreated="odmInfoGridView_RowCreated" onload="odmInfoGridView_Load" 
                                             ondatabound="odmInfoGridView_DataBound" 
                                             onprerender="odmInfoGridView_PreRender" 
                                             onrowdatabound="odmInfoGridView_RowDataBound">
                                             <HeaderStyle BorderStyle="Solid" CssClass="header" />
                                             <rowstyle backcolor="LightCyan"  
                                               font-italic="true"/>
                                            <alternatingrowstyle backcolor="lightblue"  
                                              font-italic="true"/>
                                         <Columns>  
                                <asp:TemplateField HeaderText="Information">
                                    <ItemTemplate>
                                    <asp:HyperLink ID="odmInfoLink" runat="server" Font-Size="X-Small">View</asp:HyperLink>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                      <Columns>  
                                      
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