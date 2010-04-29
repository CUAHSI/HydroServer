<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HydroServer.Framework.Models.RegionContentsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Region
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="http://serverapi.arcgisonline.com/jsapi/arcgis/1.5/js/dojo/dijit/themes/tundra/tundra.css">
    <script type="text/javascript" src="http://serverapi.arcgisonline.com/jsapi/arcgis/?v=1.5"></script>

    <script type="text/javascript">
        dojo.require("esri.map");
        dojo.require("esri.toolbars.draw");
            
        var map;
            
        var xmin = <%=Model.Region.WestExtent %>;
        var xmax = <%=Model.Region.EastExtent %>;
        var ymin = <%=Model.Region.SouthExtent %>;
        var ymax = <%=Model.Region.NorthExtent %>;
        
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
            
            map.addLayer(new esri.layers.ArcGISDynamicMapServiceLayer(mapServiceURL));           
            
            dojo.connect(map, 'onLoad', addPoints);
        }        
        
        function addPoints() {        
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
    <div id="map" class="tundra"></div>
    <h2><%=Model.Region.RegionTitle %></h2>
    <p><strong><a href="<%=System.Configuration.ConfigurationManager.AppSettings["MapLocation"] %>?Region=<%=Model.Region.RegionName %>" target="_blank">Launch Map</a></strong></p>
    <p><strong>Region Description: </strong><%=Model.Region.RegionDescription %></p>       
    <% foreach (var md in Model.Metadata) { %>
        <p><strong><%= md.MetadataTitle %>:</strong> <%=md.MetadataContent %></p>
    <%} %>
    
    <strong>Observational Data Services:</strong>
    <ul>
    <% foreach (var item in Model.ODMDatabases) {%>
        <li><a href="<%=ResolveUrl("~/" + "Observational-Data/" + item.DatabaseID ) %>"><%=item.Title %></a>: <%=item.Abstract %></li>
    <%} %>
    </ul>
    <strong>GIS Data Services:</strong>
    <ul>    
    <% foreach (var item in Model.MapServices) {%>
        <li><a href="<%=ResolveUrl("~/" + "GIS-Data/" + item.MapServiceID ) %>"><%=item.Title %></a>: <%=item.Abstract %></li>
    <%} %>    
    </ul>
    

</asp:Content>
