<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <style type="text/css">
    
		BODY { color: #000000; background-color: white; font-family: Verdana; margin-left: 0px; margin-top: 0px; }
		#content { margin-left: 0px; font-size: .70em; padding-bottom: 2em; }
		A:link { color: #336699; font-weight: bold; text-decoration: underline; }
		A:visited { color: #6699cc; font-weight: bold; text-decoration: underline; }
		A:active { color: #336699; font-weight: bold; text-decoration: underline; }
		A:hover { color: cc3300; font-weight: bold; text-decoration: underline; }
		P { color: #000000; margin-top: 0px; margin-bottom: 12px; font-family: Verdana; }
		pre { background-color: #e5e5cc; padding: 5px; font-family: Courier New; font-size: x-small; margin-top: 05px; border: 1px #f0f0e0 solid; }
		td { color: #000000; font-family: Verdana; font-size: .7em; }
		h2 { font-size: 1.5em; font-weight: bold; margin-top: 25px; margin-bottom: 10px; border-top: 1px solid #003366; margin-left: 015px; color: #003366; }
		h3 { font-size: 1.1em; color: #000000; margin-left: 15px; margin-top: 10px; margin-bottom: 10px; }
		ul { margin-top: 10px; margin-left: 20px; }
		ol { margin-top: 10px; margin-left: 20px; }
		li { margin-top: 10px; color: #000000; margin-left: 20px; }
		font.value { color: darkblue; font: bold; }
		font.key { color: darkgreen; font: bold; }
		font.error { color: darkred; font: bold; }
		.heading1 { color: #ffffff; font-family: Tahoma; font-size: 26px; font-weight: normal; background-color: #003366; margin-top: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 10px; padding-bottom: 3px; padding-left: 15px; width: 100%; }
		.button { background-color: #dcdcdc; font-family: Verdana; font-size: 1em; border-top: #cccccc 1px solid; border-bottom: #666666 1px solid; border-left: #cccccc 1px solid; border-right: #666666 1px solid; }
		.frmheader { color: #000000; background: #dcdcdc; font-family: Verdana; font-size: .7em; font-weight: normal; border-bottom: 1px solid #dcdcdc; padding-top: 2px; padding-bottom: 2px; }
		.frmtext { font-family: Verdana; font-size: .7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; }
		.frmInput { font-family: Verdana; font-size: 1em; }
		.intro { margin-left: 015px; }
           
    </style>
    <title>CUAHSI Web Services for Observations Databases </title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
 
      <div class="heading1">  <asp:Label CssClass="heading1" ID="PageTitle" runat="server" Text="Web Service"></asp:Label>
        </div>
         
         <span>
          
      </span>
       <h2>
          CUAHSI Web Services for Observations Databases Help Pages  
        </h2>
       <div class="intro">
            This web page describes <a href="http://his.cuahsi.org/" target="_blank">
                <span style="color: #0000ff">CUAHSI WaterOneFlow web services</span></a> developed
            to provide access to data from the <a href="http://www.EXAMPLE.COM/"
                target="_blank"><span style="color: #0000ff">YOUR SITE HERE</span></a>
            at the YOUR SITE HERE for YOUR purposes. <strong>
                <br />
            </strong>
  
      </div> 
        <asp:Panel ID="LocalConfiguration" runat="server">
        
     <ul>
       <li><a href="http://river.sdsc.edu/Wiki/GenericODWS%20User%20Guide.ashx">
        Installation</a></li>
        <li><a href="Configure.aspx">
        Configuration (restricted by password)</a></li>
         <li><a target="_top" href="DatabaseTest.aspx">
        Database Test Page</a></li>
          </ul> 
          </asp:Panel>
      <span>

          <h2>
              Service Description.</h2>
          <div class="intro" >
              There are two Water Web services,
              <br />
              <ul>
                  <li>A  1.1 version service is found at:
                      <asp:HyperLink ID="serviceLocation_1_1" runat="server" NavigateUrl="~/cuahsi_1_1.asmx" >Hyperlink 1 1</asp:HyperLink>
                  </li>
                  <li>The  1.0 version service is found at:<asp:HyperLink ID="serviceLocation" runat="server"
                      NavigateUrl="~/cuahsi_1_0.asmx">HyperLink</asp:HyperLink>
                  </li>
                  <li>a prototype cababilities document is found here:
                      <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Capabilities.xml"
                     >Capabilities.xml</asp:HyperLink>
                      &nbsp;&nbsp;<br />
                  </li>
              </ul>
              Example Inputs can be found here:<br />
              <ul>
                  <li>
                      <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Examples_1_1.aspx" >Examples for 1_1</asp:HyperLink>
                  </li>
                  <li>
                      <asp:HyperLink ID="Example_1_0" runat="server" NavigateUrl="~/Examples_1_0.aspx">Examples for 1_0</asp:HyperLink>
                  </li>
              </ul>
              </div>
          <div class="intro">
              &nbsp;</div>
            
      </span>

      
      

    <span>
        
    </span>
        <br />
        <h2>
        
        Web Service Description:</h2>
        <div class="intro">
        Status Level:
        <asp:Label ID="lblServiceLevel" runat="server" Text="<%$ AppSettings:serviceLevel %>"
            Width="90px"></asp:Label><br />
        <br />
        Network Name:
        <asp:Label ID="lblNetworkName" runat="server" Text="<%$ AppSettings:network %>" Width="90px"></asp:Label><br />
        Vocabulary Name:
        <asp:Label ID="lblVocabularyName" runat="server" Text="<%$ AppSettings:vocabulary %>" Width="93px"></asp:Label><br />
            AuthenticationSetttings:(TB Redone)<br />
        <br />
        <br />
        </div>
        <h2>
            Pages
        </h2>
       <ul>
         <li>Information about the web service can be found at
             <asp:HyperLink  ID="HyperLink1" runat="server" NavigateUrl="<%$ AppSettings:serviceDescriptionPage %>"
   Text=" <%$  AppSettings:serviceDescriptionPage %>"></asp:HyperLink>
      </li>
           <li><a href="DatabaseTest.aspx">
        Database Test Page</a><br />
           </li>
          </ul>
        <h2>
        Configured Properties:</h2>
        <div class="intro">
        GetSiteInfo from OD:<asp:Label ID="Label10" runat="server" Text="<%$ AppSettings:UseODForInformation %>"
            Width="73px"></asp:Label><br />
        GetSiteInfo&nbsp; Series From OD:<asp:Label ID="Label11" runat="server" Text="<%$ AppSettings:UseODForValues %>"
            Width="73px"></asp:Label><br />
        GetValues from OD:<asp:Label ID="Label12" runat="server" Text="<%$ AppSettings:UseODForInformation %>"
            Width="79px"></asp:Label><br />
        <br />
        Software and Database Information:<br />
            Software:<asp:TextBox ID="wsversion" runat="server" Width="269px"></asp:TextBox><br />
        database version:<br />
            <br />
            <br />
       </div>
  
    </form>
</body>
</html>
