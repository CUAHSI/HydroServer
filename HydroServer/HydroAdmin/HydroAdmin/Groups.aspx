<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="HydroAdmin.Groups" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Groups </title>

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
                			<a href="Main.aspx" ><span class="l"></span><span class="r"></span><span class="t">Resources</span></a>
                		</li>
                		<li>
                			<a href="users.aspx" ><span class="l"></span><span class="r"></span><span class="t">Users</span></a>                			
                		</li>		
                		<li>
                			<a href="Groups.aspx"  class=" active"><span class="l"></span><span class="r"></span><span class="t">Groups</span></a>                			
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
                                    
                                 
                                    
                                    <div style = " z-index: 100;  left:0px; position: absolute; top: 0px;width:100%; height:25px" >
                                    <div style = " z-index: 100;  left:0px; position: absolute; top: 0px;width:31%; height:25px">
                                    <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:center; background-color:#13242e;">Groups List</td>
                                       </tr>
                                  </table>
                                    </div>
                                    <div style = " z-index: 100;  left:240px; position: absolute; top: 0px;width:68%; height:25px">
                                    <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:center; background-color:#13242e;">Group Information</td>
                                       </tr>
                                  </table>
                                    </div>
                                    </div>
                                    
                                 <div style = " z-index: 100; left : 0px; position: absolute; top: 5px;width:31.5%; height:640px">
                                 <div style = " z-index: 100; border-style:groove; border-color: #fafafa; left: 0px; position: absolute; top: 25px;width:95%; height:575px">
                                     <asp:ListBox ID="GroupListBox" Height="580px" Width="225px"  runat="server" 
                                         AutoPostBack="True" 
                                         onselectedindexchanged="GroupListBox_SelectedIndexChanged" ></asp:ListBox>
                                 </div>
                                 </div>
                                 <div class="info-block"  style="z-index:100; height:140px; border-style:groove; left: 240px; position: absolute; top: 31px">
                                         <table class="contacts" border="1">
                                       <tr>
                                       <td class="contactDept">Name</td><td class="value"><asp:TextBox ID="name" 
                                               runat="server" Width="395px" BorderColor="#404040" Height="25px"></asp:TextBox></td>
                                       </tr>
                                       <tr><td class="contactDept">Owner</td><td class="value">
                                           <asp:TextBox ID="owner" runat="server" Width="395px" BorderColor="#404040" 
                                               Height="25px"></asp:TextBox></td>
                                       </tr>
                                       <tr><td class="contactDept">DateCreated</td><td class="value"><asp:TextBox ID="dateCreated" 
                                               runat="server" Width="395px" BorderColor="#404040" Height="25px"></asp:TextBox></td>
                                       </tr>
                                       </table>
                                 </div>
                                 <div style = " z-index: 100; text-align:right; left : 255px; position: absolute; top: 180px;width:66%; height:30px">
                                     <asp:Button ID="newGroupButton" width="70px" runat="server" Text="New" />
                                     <asp:Button ID="addGroupButton" width="70px" runat="server" Text="Add" />
                                 </div>
                                 
                                 <div style = " z-index: 100;  left:240px; position: absolute; top: 200px;width:68%; height:25px">
                                    <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:center; background-color:#13242e;">User Participation List</td>
                                       </tr>
                                  </table>
                                    </div>
                                 
                                 
                                 
                                 
                                  <div class="info-block"  style="z-index:100; height:350px; border-style:groove; left: 240px; position:absolute; top: 230px; overflow: auto">
                                      <asp:GridView ID="groupUserGridView" runat="server" Font-Size="Small" >
                                      </asp:GridView>
                                  </div>
                                 
                                     <div style = " z-index: 100; text-align:left;  left:240px; position: absolute; top: 590px;width:68%; height:25px">
                                         <asp:Button ID="userAddButton" Width="70px" runat="server" Text="Add" onclick="userAddButton_Click" 
                                             />
                                         <asp:Button ID="userRemoveButton" Width="70px" runat="server" Text="Remove" onclick="userRemoveButton_Click" 
                                             />
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
