<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HydroServer.Framework.Models.DataServiceModel>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%=ConfigurationManager.AppSettings["siteTitle"] %></h2>   
       
    <% if (ConfigurationManager.AppSettings["homePageDescription"] != null) { %>     
    <p>        
        <%=ConfigurationManager.AppSettings["homePageDescription"] %>
    </p>
    <% } %>
    <!--Custom content added by icewater data manager-->
    <h2>Features</h2>
    
    <a href="http://his.cuahsi.org" target="_blank"><img src="content/cuahsihis.jpg" class="leftImage"/></a>
    
    <h3><a href="http://his.cuahsi.org" target="_blank">CUAHSI Hydrologic Information System (HIS)</a></h3>

    <p>The data hosted on this server have been published using the Consortium of Universities for the Advancement of Hydrologic Science, Inc. (CUAHSI)
    Hydrologic Information System (HIS).  The goals of the CUAHSI Hydrologic Information System (HIS) Project are to unite the nation's water information, 
    to make it universally accessible and useful, and to provide access to the data sources, tools and models that enable the synthesis, 
    visualization and evaluation of the behavior of hydrologic systems. The CUAHSI HIS is a geographically distributed network of 
    hydrologic data sources and functions that are integrated using web services so that they function as a connected whole. The 
    <a href="http://his.cuahsi.org" target="_blank">CUAHSI HIS website</a> contains tools for implementing Hydrologic Information Systems.</p>
    <!--End of custom content by icewater data manager-->  
</asp:Content>
