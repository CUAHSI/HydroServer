<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HydroServer.Framework.Models.MapServiceModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Observational Data Services - <%=Model.MapService.Title %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">    
    <link rel="stylesheet" type="text/css" href="http://serverapi.arcgisonline.com/jsapi/arcgis/1.5/js/dojo/dijit/themes/tundra/tundra.css">
    <script type="text/javascript" src="http://serverapi.arcgisonline.com/jsapi/arcgis/?v=2.1"></script>
    <script type="text/javascript">
         djConfig = {
             parseOnLoad: true
         };
    </script> 
    <script type="text/javascript">
        dojo.require("dijit.layout.BorderContainer");
        dojo.require("dijit.layout.ContentPane");
        dojo.require("esri.map");
            
        var xmin = <%=Model.MapService.WestExtent %>;
        var xmax = <%=Model.MapService.EastExtent %>;
        var ymin = <%=Model.MapService.SouthExtent %>;
        var ymax = <%=Model.MapService.NorthExtent %>;                
        var mapServiceURL = "<%=Model.MapService.MapServer.ConnectionURL + "/" + Model.MapService.MapConnection.Substring(7, Model.MapService.MapConnection.Length - 7) %>/MapServer";
        
        
        var customExtentAndSR =
            new esri.geometry.Extent
            (xmin, xmax, ymin, ymax);
            //new esri.SpatialReference({wkid:26912}));

        function init() {
            var map = new esri.Map("map");
            //var map = new esri.Map("map", { extent: customExtentAndSR });           
            map.addLayer(new esri.layers.ArcGISDynamicMapServiceLayer(mapServiceURL));            
        }        

        dojo.addOnLoad(init);
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% var m = Model.MapService; %>
    
        <div id="map" class="tundra"></div>
        <h2><%=m.Title%></h2>
        <p><strong>Abstract: </strong><%=m.Abstract%></p>
        <p><strong>Extent:</strong><br />
            North: <%=m.NorthExtent%><br />
            South: <%=m.SouthExtent%><br />
            East: <%=m.EastExtent%><br />
            West: <%=m.WestExtent%>
        </p>
        <p><strong>Contact: </strong><%=HydroServer.Framework.Models.DataServiceModel.ContactSummary(m.Contact1)%></p>
        
        <% if (Model.MetadataContact != null) { %>
        <p><strong>Metadata Contact: </strong><%=HydroServer.Framework.Models.DataServiceModel.ContactSummary(Model.MetadataContact)%></p>    
        <%} %>
        
        <% if (m.LineageStatement != null)
           { %>
        <p><strong>Lineage: </strong><%=m.LineageStatement%></p>    
        <%} %>
        
        <% if (m.ReferenceDate != null)
           { %>
        <p><strong>Reference Date: </strong><%=m.ReferenceDate%></p>    
        <%} %>
        
        <% if (m.SpatialResolution != null)
           { %>
        <p><strong>Spatial Resolution: </strong><%=m.SpatialResolution%></p>    
        <%} %>                
        
        <% if (m.DistributionFormat != null)
           { %>
        <p><strong>Distribution Format: </strong><%=m.DistributionFormat%></p>    
        <%} %>        
        
        <% if (m.SpatialRepresentationType != null)
           { %>
        <p><strong>Spatial Representation Type: </strong><%=m.SpatialRepresentationType%></p>    
        <%} %>        
        
        <% if (m.SpatialReferenceSystem != null)
           { %>
        <p><strong>Spatial Reference System: </strong><%=m.SpatialReferenceSystem%></p>    
        <%} %>        
        
        <% if (m.OnlineResource != null)
           { %>
        <p><strong>Online Resource: </strong><a href="<%=m.OnlineResource%>" target="_blank"><%=m.OnlineResource%></a></p>    
        <%} %>        
        
        <% foreach (var md in Model.Metadata) { %>
            <p><strong><%= md.MetadataTitle %>:</strong> <%=md.MetadataContent %></p>
        <%} %>
        
        <% Html.RenderPartial("GISDataServiceLinks", m); %>    
</asp:Content>
