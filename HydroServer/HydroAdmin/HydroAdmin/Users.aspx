<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="HydroAdmin.Users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Users </title>

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
                			<a href="users.aspx" class=" active" ><span class="l"></span><span class="r"></span><span class="t">Users</span></a>                			
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
                                 <div style = " z-index: 100; left : 0px; position: absolute; top: 0px;width:30%; height:640px">
                                 <div style = " z-index: 100; left: 0px; position: absolute; top: 0px;width:98%; height:25px">
                                  <table style=" width:100%; background-color:#13242e; height: 25px" border="1">
                                       <tr>
                                       <td style=" color: #E7F2F9 !important;   width:100%; border:none; text-align:center; background-color:#13242e;">Users</td>
                                       </tr>
                                  </table>
                                 </div>
                                 <div style = " z-index: 100; border-style:groove; border-color: #fafafa; left: 0px; position: absolute; top: 25px;width:95%; height:575px">
                                     <asp:ListBox ID="UserListBox" Height="580px" Width="215px"  runat="server" 
                                         AutoPostBack="True" onselectedindexchanged="UserListBox_SelectedIndexChanged"></asp:ListBox>
                                 </div>
                                 </div>
                                 <div class="info-block"  style="z-index:100; height:170px; border-style:groove; left: 240px; position: absolute; top: 0px">
                                         <table class="contacts" border="1">
                                       <tr>
                                       <td class="contactDept">Name</td><td class="value"><asp:TextBox ID="name" 
                                               runat="server" Width="395px" BorderColor="#404040" Height="25px"></asp:TextBox></td>
                                       </tr>
                                       <tr><td class="contactDept">Email Id</td><td class="value">
                                           <asp:TextBox ID="emailId" runat="server" Width="395px" BorderColor="#404040" 
                                               Height="25px"></asp:TextBox></td>
                                       </tr>
                                       <tr><td class="contactDept">Organization</td><td class="value"><asp:TextBox ID="organization" 
                                               runat="server" Width="395px" BorderColor="#404040" Height="25px"></asp:TextBox></td>
                                       </tr>
                                       <tr><td class="contactDept" style ="height:60px">Country</td><td class="value">
                                           <asp:TextBox ID="country" runat="server" Width="395px" BorderColor="#404040" 
                                               Height="52px" TextMode="MultiLine"></asp:TextBox></td>
                                       </tr>
                                       </table>
                                 </div>
                                  <div class="info-block"  style="z-index:100; height:420px; border-style:groove; left: 240px; position:absolute; top: 180px; overflow: auto">
                                      <asp:GridView ID="userGroup" runat="server" Font-Size="Small" 
                                          onrowcreated="userGroup_RowCreated">
                                      <Columns>  
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="selectGroup" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>                    
                                </asp:TemplateField>
                                            </Columns>
                                      </asp:GridView>
                                  </div>
                                  <div style="z-index:100; text-align:right; width:220px; height:30px;left: 535px; position:absolute; top: 610px; overflow: auto">
                                  <asp:Button ID="Button1" runat="server" Text="Update" onclick="Button1_Click" />
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
