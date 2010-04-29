Imports ESRI.ArcGIS


Partial Class _Default
    Inherits System.Web.UI.Page

    Public Function IcewaterDB() As DatabaseFunctions
        If (My.Request.QueryString.Item("Region") Is Nothing) Then
            Return New DatabaseFunctions()
        Else
            Dim region As String = My.Request.QueryString.Item("Region")
            Return New DatabaseFunctions(region)
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            'Used to determine if a previous/next action occurred
            Session("previousNext") = False
            Session("previousNextMapHandler") = False

            MapResourceManager1.ResourceItems.Clear()
        End If
        If (MapResourceManager1.ResourceItems.Count <= 0) Then
            Dim Icewater As DatabaseFunctions = IcewaterDB()
            Dim MapServers As Data.DataTable = Icewater.GetMapServers()
            Dim MapResources As Data.DataTable = Icewater.GetRegionMaps()
            Dim MapServerList() As Data.DataRow
            Dim MapResource As Data.DataRow

            Dim myPoints As New ADF.Web.UI.WebControls.MapResourceItem()
            myPoints.Definition = New ADF.Web.UI.WebControls.GISResourceItemDefinition()
            myPoints.Definition.ResourceDefinition = "GraphicsResource"
            myPoints.Definition.DataSourceDefinition = "In Memory"
            myPoints.Definition.DataSourceType = "GraphicsLayer"
            myPoints.Name = "ODM Sites"
            myPoints.DisplaySettings.DisplayInTableOfContents = True
            myPoints.DisplaySettings.Visible = True

            MapResourceManager1.ResourceItems.Add(myPoints)

            For Each MapResource In MapResources.Rows
                MapServerList = MapServers.Select(Icewater.db_fld_Se_ID & " = '" & MapResource.Item(Icewater.db_fld_Mp_ServerID) & "'")
                If (MapServerList.Length > 0) Then
                    Try
                        Dim res As New ADF.Web.UI.WebControls.MapResourceItem()
                        res.Definition = New ADF.Web.UI.WebControls.GISResourceItemDefinition()
                        res.Definition.DataSourceDefinition = CStr(MapServerList(0).Item(Icewater.db_fld_Se_ConnectionUrl)).ToLower.Replace("arcgis/rest/services", "arcgis/services")
                        res.Definition.DataSourceType = MapServerList(0).Item(Icewater.db_fld_Se_Type)
                        res.Definition.ResourceDefinition = MapResource.Item(Icewater.db_fld_Mp_MapConnection)
                        res.Definition.Identity = MapResource.Item(Icewater.db_fld_RM_DisplayName)
                        res.Name = MapResource.Item(Icewater.db_fld_RM_DisplayName)
                        res.DisplaySettings.Transparency = MapResource.Item(Icewater.db_fld_RM_TransparencyPercent)
                        res.DisplaySettings.Visible = MapResource.Item(Icewater.db_fld_RM_IsVisible)
                        res.DisplaySettings.DisplayInTableOfContents = MapResource.Item(Icewater.db_fld_RM_IsTOC)
                        res.DisplaySettings.ImageDescriptor.TransparentColor = Drawing.Color.Transparent
                        res.DisplaySettings.ImageDescriptor.TransparentBackground = True
                        MapResourceManager1.ResourceItems.Add(res)
                        res.InitializeResource()
                        res.GetDefaultLayerDefinitions()

                        If (MapResource.Item(Icewater.db_fld_RM_IsBaseMap) = True) Then
                            Map1.PrimaryMapResource = res.Name
                        End If

                        If res.FailedToInitialize Then
                            Throw res.InitializationFailure
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    Throw New Exception("No Server Available for " & MapResource.Item(Icewater.db_fld_RM_DisplayName))
                End If
            Next MapResource

            If MapResources.Rows.Count() = 0 Then
                LoadBaseMap()
            End If
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not (IsPostBack) Then
            Dim myPoints As ADF.Web.UI.WebControls.GISResourceItem = MapResourceManager1.ResourceItems.Find("ODM Sites")

            If Not (myPoints Is Nothing) Then
                Dim g As ESRI.ArcGIS.ADF.Web.DataSources.Graphics.MapResource = myPoints.CreateResource
                If Not (g.Graphics Is Nothing) Then
                    g.Graphics.Tables.Clear()
                    Dim blank() As String = {}
                    Dim Icewater As DatabaseFunctions = IcewaterDB()
                    Dim DBConnections As System.Collections.Generic.Dictionary(Of String, DatabaseFunctions.ODMDatabase) = Icewater.GetConnections
                    Dim DBName As String
                    Dim MapSR As ADF.Web.SpatialReference.IDSpatialReferenceInfo = Map1.SpatialReference.CoordinateSystem

                    Dim xmin As Double = 0
                    Dim xmax As Double = 0
                    Dim ymin As Double = 0
                    Dim ymax As Double = 0

                    For Each DBName In DBConnections.Keys
                        Dim ODMSites As Data.DataTable = Icewater.OpenTable("SELECT [Sites].*,[SpatialReferences].[SRSID] AS SRSID FROM [Sites] LEFT JOIN [SpatialReferences] ON [Sites].[LatLongDatumID] = [SpatialReferences].[SpatialReferenceID]", DBName)
                        Dim ODMSite As Data.DataRow
                        Dim fgLayer As New ADF.Web.Display.Graphics.FeatureGraphicsLayer(DBConnections.Item(DBName).DisplayName)

                        fgLayer.Columns.Add("SiteCode")
                        fgLayer.Columns.Add("DatabaseName")
                        fgLayer.Columns.Add("DisplayName")
                        fgLayer.Columns.Add("DisplayOrder")
                        For Each ODMSite In ODMSites.Rows
                            Dim siteLon As Double = ODMSite.Item(Icewater.db_fld_SiteLong)
                            Dim siteLat As Double = ODMSite.Item(Icewater.db_fld_SiteLat)
                            If (xmin = 0 Or (xmin > siteLon And xmin <> 0)) Then xmin = siteLon
                            If (xmax = 0 Or (xmax < siteLon And xmax <> 0)) Then xmax = siteLon
                            If (ymin = 0 Or (ymin > siteLat And ymin <> 0)) Then ymin = siteLat
                            If (ymax = 0 Or (ymax < siteLat And ymax <> 0)) Then ymax = siteLat

                            Dim point As New ADF.Web.Geometry.Point(siteLon, siteLat)
                            Dim geom As ADF.Web.Geometry.Point
                            If (ODMSite.Item("SRSID") Is DBNull.Value) Then
                                geom = SpatialReferenceConversions.Auto_Convert(point, "4269", MapSR.ID)
                            Else
                                geom = SpatialReferenceConversions.Auto_Convert(point, ODMSite.Item("SRSID"), MapSR.ID)
                            End If
                            Dim row As Data.DataRow = fgLayer.Add(geom)
                            row.Item("SiteCode") = ODMSite.Item("SiteCode")
                            row.Item("DatabaseName") = DBName

                            row.Item("DisplayName") = DBConnections.Item(DBName).DisplayName
                            row.Item("DisplayOrder") = DBConnections.Item(DBName).DisplayOrder
                        Next ODMSite

                        'Dim symbol As New ADF.Web.Display.Symbol.SimpleMarkerSymbol(Drawing.Color.Purple, 15, ADF.Web.Display.Symbol.MarkerSymbolType.Cross)
                        'http://localhost/AJAXMap/Images/Question.bmp
                        Dim connectionImage As String = Icewater.GetConnectionImage(DBConnections(DBName).Connection)

                        Dim symbol As ADF.Web.Display.Symbol.FeatureSymbol
                        If connectionImage = "" Then
                            symbol = New ADF.Web.Display.Symbol.SimpleMarkerSymbol(Drawing.Color.Black, 5, ADF.Web.Display.Symbol.MarkerSymbolType.Triangle)
                        Else
                            Dim temp As New ADF.Web.Display.Symbol.RasterMarkerSymbol(connectionImage)
                            temp.ImageFormat = ADF.Web.ImageFormat.PNG32
                            temp.Height = 32
                            temp.Width = 32
                            symbol = temp
                        End If


                        Dim sr As New ESRI.ArcGIS.ADF.Web.Display.Renderer.SimpleRenderer(symbol)
                        fgLayer.SupportsIdentify = True
                        fgLayer.Renderer = sr

                        g.Graphics.Tables.Add(fgLayer)
                    Next DBName

                    If Map1.PrimaryMapResource = "ESRI Base Map" Then
                        Dim layerEnv As New ESRI.ArcGIS.ADF.Web.Geometry.Envelope(Double.MaxValue, Double.MaxValue, Double.MinValue, Double.MinValue)

                        Dim xdev As Double
                        Dim ydev As Double

                        xdev = (xmax - xmin) * 0.2
                        If xmin > xmax Then xdev = xdev * -1
                        ydev = (ymax - ymin) * 0.2
                        If ymin > ymax Then ydev = ydev * -1

                        If xdev < 0.004 Then xdev = 0.004
                        If ydev < 0.004 Then ydev = 0.004

                        layerEnv.XMin = xmin - xdev
                        layerEnv.XMax = xmax + xdev
                        layerEnv.YMin = ymin - ydev
                        layerEnv.YMax = ymax + ydev

                        layerEnv.SpatialReference = Map1.SpatialReference

                        Map1.Extent = layerEnv
                        ScaleBar1.BarUnits = ADF.Web.ScaleBarUnits.Kilometers
                        'Map1.PrimaryMapResource = "ODM Sites"
                    End If

                    Map1.Refresh()
                    Toc1.Refresh()
                End If
            End If
        End If
    End Sub

    Public Sub LoadBaseMap()
        Dim res As New ADF.Web.UI.WebControls.MapResourceItem()
        res.Definition = New ADF.Web.UI.WebControls.GISResourceItemDefinition()
        res.Definition.DataSourceDefinition = "http://server.arcgisonline.com/arcgis/services"
        res.Definition.DataSourceType = "ArcGIS Server Internet"
        res.Definition.ResourceDefinition = "Layers@ESRI_StreetMap_World_2D"
        res.Definition.Identity = "ESRI Base Map"
        res.Name = "ESRI Base Map"
        res.DisplaySettings.Transparency = 0
        res.DisplaySettings.Visible = True
        res.DisplaySettings.DisplayInTableOfContents = True
        res.DisplaySettings.ImageDescriptor.TransparentColor = Drawing.Color.Transparent
        res.DisplaySettings.ImageDescriptor.TransparentBackground = True
        MapResourceManager1.ResourceItems.Add(res)
        res.InitializeResource()
        res.GetDefaultLayerDefinitions()
        Map1.PrimaryMapResource = res.Name
    End Sub

End Class