<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HydroServer.Framework.Models.DataServiceTable>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Observational Data
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Observational Data Services</h2>
    
    <p>Here is a list of observational data services on this HydroServer. To view more details about a data service, click on the title.</p>

    <% Html.RenderPartial("ObservationalDataServiceTable", Model); %>

</asp:Content>
