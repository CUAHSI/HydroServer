<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ODMUpload.aspx.cs" Inherits="HydroAdmin.ODMUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>ODM Upload</title>

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
                			<a href="Main.aspx" class=" active" ><span class="l"></span><span class="r"></span><span class="t">Resources</span></a>
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
                                    
                              
                               <div class="infolist-block" style="z-index: 100; border-style:groove; left: 0px; position: absolute; top: 0px">
                                <asp:ListBox ID="odmList"  runat="server" Height="620px" Width="225px" 
                                       BackColor="#E7F2F9" ForeColor="Black" AutoPostBack="True" Font-Size="11pt" 
                                       onselectedindexchanged="odmList_SelectedIndexChanged">
                                </asp:ListBox>
                               </div>
                               <div class="info-block"  style="z-index:100; height:265px; border-style:groove; left: 240px; position: absolute; top: 0px">
                              
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
                                       <tr><td class="contactDept">WaterOneFlow WSDL
                                           </td><td class="value">
                                           <asp:TextBox ID="waterOneWSDL" runat="server" Width="395px" BorderColor="#404040" 
                                               Height="25px"></asp:TextBox></td>
                                       </tr>
                                     
                                       </table>
                                 </div>
                                       <div style="z-index:100; text-align:right; width:515px; height:20px;left: 240px; position:absolute; top: 275px;">
                                           <asp:CheckBox ID="automatedDOICheckBox" runat="server" Font-Size="Small" 
                                               Text="Automated DOI" AutoPostBack="True" 
                                               oncheckedchanged="automatedDOICheckBox_CheckedChanged" />
                                               <asp:CheckBox ID="customDOICheckBox" runat="server" AutoPostBack="True"  Font-Size="Small" 
                                               Text="Custom DOI" oncheckedchanged="customDOICheckBox_CheckedChanged" />
                                       <asp:Button ID="Button1" runat="server" Text="Cancel" Height="20px" 
                                               onclick="Button1_Click" Width="50px" />
                                       <asp:Button ID="Button2" runat="server" Text="Load" Height="20px" 
                                               onclick="Button2_Click" Width="50px" />
                                       </div>
                                      
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
                            <p align="right"><a href="#" >Contact Usund" style="left: 4px; bottom: -80px"></div>
                </div>
        		<div class="cleared"></div>
            </div>
        </div>
        <div class="cleared"></div>
        
    </div>
    </form>
</body>
</html>
