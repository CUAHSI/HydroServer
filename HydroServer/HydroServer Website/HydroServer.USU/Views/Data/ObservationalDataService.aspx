<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HydroServer.Framework.Models.ODMDatabaseModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Observational Data Services - <%=Model.ODMDatabase.Title %>
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
            
        var map;
            
        var xmin = <%=Model.ODMDatabase.WestExtent %>;
        var xmax = <%=Model.ODMDatabase.EastExtent %>;
        var ymin = <%=Model.ODMDatabase.SouthExtent %>;
        var ymax = <%=Model.ODMDatabase.NorthExtent %>;
        
        var xdev = (xmax - xmin) * 0.2;
        if (xmin > xmax) { xdev = xdev * -1 };
        var ydev = (ymax - ymin) * 0.2;
        if (ymin > ymax) { ydev = ydev * -1 };

        if (xdev < 0.004) { xdev = 0.004 };
        if (ydev < 0.004) { ydev = 0.004 };
                
        var mapServiceURL = "http://server.arcgisonline.com/ArcGIS/rest/services/ESRI_StreetMap_World_2D/MapServer";               

        function init() {
            var spatialReference = new esri.SpatialReference({wkid:26912});
            
            var customExtentAndSR =
                new esri.geometry.Extent
                (xmin - xdev, ymin - ydev, xmax + xdev, ymax + ydev,
                spatialReference);
            
            map = new esri.Map("map", { extent: customExtentAndSR });
            
            map.addLayer(new esri.layers.ArcGISTiledMapServiceLayer(mapServiceURL));           
            
            dojo.connect(map, 'onLoad', addPoints);
        }        
        
        function addPoints() {
        
            $('#sites').append("<p><strong>Sites:</strong></p><ul>");
            
        <% foreach (var site in Model.Sites) { %>
            
            var symbol = new esri.symbol.SimpleMarkerSymbol(
                esri.symbol.SimpleMarkerSymbol.STYLE_CIRCLE, 15, 
                new esri.symbol.SimpleLineSymbol(esri.symbol.SimpleLineSymbol.STYLE_SOLID, 
                new dojo.Color([50,50,50]), 1), new dojo.Color([Math.floor(Math.random()*220),Math.floor(Math.random()*220),Math.floor(Math.random()*220)], 0.1)
            );
            
            map.graphics.add(
                new esri.Graphic(
                    new esri.geometry.Point(<%=site.Longitude %>,<%=site.Latitude %>, map.spatialReference), symbol
                )
            );
            
            $('#sites').append('<li><%=site.SiteName %>: <%=site.Longitude %>, <%=site.Latitude %></li>');
        <%} %>
            
            $('#sites').append("</ul>");
            
            points = [
                new esri.geometry.Point(xmin, ymin),
                new esri.geometry.Point(xmin, ymax),
                new esri.geometry.Point(xmax, ymax),
                new esri.geometry.Point(xmax, ymin),
                new esri.geometry.Point(xmin, ymin)
            ];
              
            var polygon = new esri.geometry.Polygon();
            polygon.addRing(points);
            polygon.spatialReference = map.spatialReference;

            // Add the polygon to map
            var symbol = new esri.symbol.SimpleFillSymbol().setStyle(esri.symbol.SimpleFillSymbol.STYLE_SOLID);
            polygonGraphic = new esri.Graphic(polygon, symbol);
            map.graphics.add(polygonGraphic);
        }
        
        dojo.addOnLoad(init);        
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% var m = Model.ODMDatabase;%>
        <div id="map" class="tundra"></div>
        <h2><%=m.Title%></h2>
        <p><strong><a href="<%=System.Configuration.ConfigurationManager.AppSettings["TSALocation"] %>?database=<%=m.DatabaseName %>" target="_blank">Launch Time Series Analyst</a></strong></p>
        <p><strong><%=Html.ActionLink("Download data", "DataQuery", "DataQuery")%></strong></p>
        <% Html.RenderPartial("ObservationalDataServiceLinks", m); %>
        <p><strong>Abstract: </strong><%=m.Abstract%></p>
        <p><strong>Topic: </strong><%=m.TopicCategory%></p>
        <i><strong>Citation: </strong><%=m.Citation%></i>
        <p><strong>Water OneFlow WSDL: </strong><a href="<%=m.WaterOneFlowWSDL %>" target="_blank"><%=m.WaterOneFlowWSDL%></a></p>
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
        
        <% if (m.SpatialReferenceSystem != null)
           { %>
        <p><strong>Spatial Reference System: </strong><%=m.SpatialReferenceSystem%></p>    
        <%} %>                
        
        <% foreach (var md in Model.Metadata) { %>
            <p><strong><%= md.MetadataTitle %>:</strong> <%=md.MetadataContent %></p>
        <%} %>
        
        <!--Commented out from the original view       
        <div id="sites"></div>
        -->
</asp:Content>
