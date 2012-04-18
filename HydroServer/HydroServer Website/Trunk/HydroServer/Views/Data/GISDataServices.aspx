<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Hydroserver.Models.DataServiceTable>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	GIS Data
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>GIS Data Services</h2>
    
    <p>Here is a list of GIS data services on this HydroServer. To view more details about a data service, click on the title.</p>
    
    <% Html.RenderPartial("GISDataServiceTable", Model); %>

</asp:Content>
