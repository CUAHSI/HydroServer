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
                			<a href="Main.aspx" class=" active"><span class="l"></span><span class="r"></span><span class="t">Resources</span></a>
                		</li>
                		<li>
                			<a href="users.aspx" ><span class="l"></span><span class="r"></span><span class="t">Users</span></a>                			
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
                    <div class="art-content-main" style="left: 0px; top: 0px">
                        <div class="art-Post">
                            <div class="art-Post-body">
                        
                                <div class="art-PostHeader">
                                    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                    
                                    <div class="infolist-block" style="z-index: 100; height:230px; border-style:groove; left: 0px; position: absolute; top: 0px">
                                    <asp:ListBox ID="odmList"  runat="server" Height="210px" Width="225px" 
                                            BackColor="#E7F2F9" 
                                            ForeColor="Black" AutoPostBack="True" 
                                            onselectedindexchanged="odmList_SelectedIndexChanged" 
                                             Font-Size="11pt"></asp:ListBox>
                                        <asp:SqlDataSource ID="HydroSecureODMList" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:SecurityDb %>" 
                                            SelectCommand="select distinct databasename from TimeSeriesResource;">
                                        </asp:SqlDataSource>
                                        <div style = "z-index:100; left:0px; text-align:right">
                                        <asp:LinkButton ID="addODM" runat="server" Font-Size="11pt" onclick="addODM_Click">Add</asp:LinkButton>
                                        <asp:LinkButton ID="updateODM" runat="server" Font-Size="11pt" >Update</asp:LinkButton>
                                        <asp:LinkButton ID="deleteODM" runat="server" Font-Size="11pt" onclick="deleteODM_Click">Delete</asp:LinkButton>
                                        </div>
                                     </div> 
                                     <div class="info-block"  style="z-index:100; height:230px; border-style:groove; left: 240px; position: absolute; top: 0px">
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
                                     <div style="z-index:100;text-align:left; width:100%; height:25px;left:10px; position:absolute; top: 240px; overflow: auto">
                                         <asp:Label ID="recordCount" runat="server" Width="120px" Font-Size="Small"></asp:Label>
                                         
                                         <asp:DropDownList ID="siteCodeDropDownList" runat="server" Width="120px" 
                                             AutoPostBack="True" 
                                             onselectedindexchanged="siteCodeDropDownList_SelectedIndexChanged">
                                         </asp:DropDownList>
                                         <asp:DropDownList ID="variableCodeDropDownList" runat="server" Width="120px" 
                                             AutoPostBack="True" 
                                             onselectedindexchanged="variableCodeDropDownList_SelectedIndexChanged">
                                         </asp:DropDownList>
                                         <asp:Button ID="resetOdmInfoButton" runat="server" Text="Reset" 
                                             onclick="resetOdmInfoButton_Click" />
                                     </div>
                                     <div class="info-block"  style="z-index:100; height:370px; border-style:groove; width:100%; left: 0px; position:absolute; top: 270px; overflow: auto">
                                        
                                         <asp:GridView ID="odmInfoGridView" runat="server" Font-Size="Small" 
                                             onrowcreated="odmInfoGridView_RowCreated" onload="odmInfoGridView_Load" 
                                             ondatabound="odmInfoGridView_DataBound" 
                                             onprerender="odmInfoGridView_PreRender">
                                             <HeaderStyle BorderStyle="Solid" CssClass="header" />
                                         <Columns>  
                                <asp:TemplateField HeaderText="Information">
                                    <ItemTemplate>
                                    <asp:HyperLink ID="odmInfoLink" runat="server" Font-Size="Small">View</asp:HyperLink>
                                    </ItemTemplate> 
                                    </asp:TemplateField>
                                    </Columns> 
                                     <Columns>  
                                <asp:TemplateField HeaderText="TimeSeriesInformation">
                                    <ItemTemplate>
                                    <asp:Table ID="TimeSeriesInfoTable" runat="server"></asp:Table>
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
