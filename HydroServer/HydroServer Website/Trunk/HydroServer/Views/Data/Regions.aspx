<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Hydroserver.Models.DataServiceTable>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Regions
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>HIS Regions</h2>
    
    <p>Here is a list of regions on this HydroServer. To view more details about a region, click on the region title.</p>
    
    <% Html.RenderPartial("RegionTable", Model); %>
    
</asp:Content>
