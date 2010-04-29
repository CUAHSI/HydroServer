<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	About
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>About <%=ConfigurationManager.AppSettings["siteTitle"] %></h2>
    
    <p><%=ConfigurationManager.AppSettings["aboutPageDescription"] %></p>
    
    <p>For more information, contact:</p>
    
    <p>
        <b><a href="mailto:<%=ConfigurationManager.AppSettings["contactEmail"] %>">
            <%=ConfigurationManager.AppSettings["contactName"] %>
        </a></b><br />    
    
        <%=ConfigurationManager.AppSettings["contactAddress1"] %><br />
        <%if (ConfigurationManager.AppSettings["contactAddress2"].Length > 0) {%>
        <%=ConfigurationManager.AppSettings["contactAddress2"] %><br />
        <%} %>
        <%if (ConfigurationManager.AppSettings["contactAddress3"].Length > 0) {%>
        <%=ConfigurationManager.AppSettings["contactAddress3"] %><br />
        <%} %>
        <%=ConfigurationManager.AppSettings["contactPhone"] %>
    </p>
    
    <% if (ConfigurationManager.AppSettings["capabilitiesURL"] != null) { %>    
    <h3>HydroServer Capabilities</h3>
    <p>The capabilities of this HydroServer can be discovered automatically using the web service located at: 
    <a href="<%=ConfigurationManager.AppSettings["capabilitiesURL"] %>" target="_blank"><%=ConfigurationManager.AppSettings["capabilitiesURL"] %></a></p>    
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
