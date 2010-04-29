Imports Microsoft.VisualBasic

Public Class SpatialReferenceConversions
    Public Shared Function Auto_Convert(ByVal beforePoint As ESRI.ArcGIS.ADF.Web.Geometry.Point, ByVal beforeCoordSys As Integer, ByVal afterCoordSys As Integer) As ESRI.ArcGIS.ADF.Web.Geometry.Point
        Dim beforeIsGeo As Boolean
        Dim afterIsGeo As Boolean
        Dim beforeIsProj As Boolean
        Dim afterIsProj As Boolean

        beforeIsGeo = ((beforeCoordSys >= 4000 And beforeCoordSys < 5000) Or _
        (beforeCoordSys >= 37000 And beforeCoordSys < 38000) Or _
        (beforeCoordSys >= 104000 And beforeCoordSys < 105000))
        afterIsGeo = ((afterCoordSys >= 4000 And afterCoordSys < 5000) Or _
        (afterCoordSys >= 37000 And afterCoordSys < 38000) Or _
        (afterCoordSys >= 104000 And afterCoordSys < 105000))
        beforeIsproj = ((beforeCoordSys >= 2000 And beforeCoordSys < 4000) Or _
        (beforeCoordSys >= 20000 And beforeCoordSys < 33000) Or _
        (beforeCoordSys >= 53000 And beforeCoordSys < 55000) Or _
        (beforeCoordSys >= 65000 And beforeCoordSys < 66000) Or _
        (beforeCoordSys >= 102000 And beforeCoordSys < 104000))
        afterIsProj = ((afterCoordSys >= 2000 And afterCoordSys < 4000) Or _
        (afterCoordSys >= 20000 And afterCoordSys < 33000) Or _
        (afterCoordSys >= 53000 And afterCoordSys < 55000) Or _
        (afterCoordSys >= 65000 And afterCoordSys < 66000) Or _
        (afterCoordSys >= 102000 And afterCoordSys < 104000))

        If (beforeIsGeo) Then
            If (afterIsGeo) Then
                Return Geographic_to_Geographic(beforePoint, beforeCoordSys, afterCoordSys)
            ElseIf (afterIsProj) Then
                Return Geographic_to_Projected(beforePoint, beforeCoordSys, afterCoordSys)
            End If
        ElseIf (beforeIsProj) Then
            If (afterIsGeo) Then
                Return Projected_to_Geographic(beforePoint, beforeCoordSys, afterCoordSys)
            ElseIf (afterIsProj) Then
                Return Projected_to_Projected(beforePoint, beforeCoordSys, afterCoordSys)
            End If
        End If
        Return beforePoint
    End Function

    Private Shared Function Projected_to_Geographic(ByVal proj As ESRI.ArcGIS.ADF.Web.Geometry.Point, ByVal projCoordSys As Integer, ByVal geoCoordSys As Integer) As ESRI.ArcGIS.ADF.Web.Geometry.Point
        Dim iPoint As ESRI.ArcGIS.Geometry.IPoint = New ESRI.ArcGIS.Geometry.Point()
        iPoint.X = proj.X
        iPoint.Y = proj.Y
        Dim pSpatRefFact As ESRI.ArcGIS.Geometry.ISpatialReferenceFactory = New ESRI.ArcGIS.Geometry.SpatialReferenceEnvironmentClass()
        Dim pGeoCoordSystem As ESRI.ArcGIS.Geometry.ISpatialReference = pSpatRefFact.CreateGeographicCoordinateSystem(geoCoordSys)

        Dim pGeometry As ESRI.ArcGIS.Geometry.IGeometry2 = iPoint
        pGeometry.SpatialReference = pSpatRefFact.CreateProjectedCoordinateSystem(projCoordSys)
        pGeometry.ProjectEx(pGeoCoordSystem, ESRI.ArcGIS.Geometry.esriTransformDirection.esriTransformReverse, Nothing, False, 0, 0)

        Dim GCSPoint As ESRI.ArcGIS.Geometry.IPoint = pGeometry
        Dim converted As New ESRI.ArcGIS.ADF.Web.Geometry.Point(GCSPoint.X, GCSPoint.Y)

        Return converted
    End Function

    Private Shared Function Geographic_to_Projected(ByVal geo As ESRI.ArcGIS.ADF.Web.Geometry.Point, ByVal geoCoordSys As Integer, ByVal projCoordSys As Integer) As ESRI.ArcGIS.ADF.Web.Geometry.Point
        Dim point As New ESRI.ArcGIS.Geometry.Point()
        point.X = geo.X
        point.Y = geo.Y

        Dim pSpatRefFact As ESRI.ArcGIS.Geometry.ISpatialReferenceFactory = New ESRI.ArcGIS.Geometry.SpatialReferenceEnvironmentClass()
        Dim pProjCoordSystem As ESRI.ArcGIS.Geometry.ISpatialReference = pSpatRefFact.CreateProjectedCoordinateSystem(projCoordSys)

        Dim pGeometry As ESRI.ArcGIS.Geometry.IGeometry2 = point
        pGeometry.SpatialReference = pSpatRefFact.CreateGeographicCoordinateSystem(geoCoordSys)

        pGeometry.ProjectEx(pProjCoordSystem, ESRI.ArcGIS.Geometry.esriTransformDirection.esriTransformReverse, Nothing, False, 0, 0)

        Dim PCSPoint As ESRI.ArcGIS.Geometry.Point = pGeometry
        Dim converted As New ESRI.ArcGIS.ADF.Web.Geometry.Point(PCSPoint.X, PCSPoint.Y)

        Return converted
    End Function

    Private Shared Function Projected_to_Projected(ByVal old As ESRI.ArcGIS.ADF.Web.Geometry.Point, ByVal oldCoordSys As Integer, ByVal newCoordSys As Integer) As ESRI.ArcGIS.ADF.Web.Geometry.Point
        Dim iPoint As ESRI.ArcGIS.Geometry.IPoint = New ESRI.ArcGIS.Geometry.Point()
        iPoint.X = old.X
        iPoint.Y = old.Y
        Dim pSpatRefFact As ESRI.ArcGIS.Geometry.ISpatialReferenceFactory = New ESRI.ArcGIS.Geometry.SpatialReferenceEnvironmentClass()
        Dim newCoordSystem As ESRI.ArcGIS.Geometry.ISpatialReference = pSpatRefFact.CreateProjectedCoordinateSystem(newCoordSys)

        Dim pGeometry As ESRI.ArcGIS.Geometry.IGeometry2 = iPoint
        pGeometry.SpatialReference = pSpatRefFact.CreateProjectedCoordinateSystem(oldCoordSys)

        pGeometry.ProjectEx(newCoordSystem, ESRI.ArcGIS.Geometry.esriTransformDirection.esriTransformReverse, Nothing, False, 0, 0)

        Dim PProjPoint As ESRI.ArcGIS.Geometry.IPoint = pGeometry
        Dim converted As New ESRI.ArcGIS.ADF.Web.Geometry.Point(PProjPoint.X, PProjPoint.Y)

        Return converted
    End Function

    Private Shared Function Geographic_to_Geographic(ByVal old As ESRI.ArcGIS.ADF.Web.Geometry.Point, ByVal oldCoordSys As Integer, ByVal newCoordSys As Integer) As ESRI.ArcGIS.ADF.Web.Geometry.Point
        Dim point As New ESRI.ArcGIS.Geometry.Point()
        point.X = old.X
        point.Y = old.Y

        Dim pSpatRefFact As ESRI.ArcGIS.Geometry.ISpatialReferenceFactory = New ESRI.ArcGIS.Geometry.SpatialReferenceEnvironmentClass()
        Dim newCoordSystem As ESRI.ArcGIS.Geometry.ISpatialReference = pSpatRefFact.CreateGeographicCoordinateSystem(newCoordSys)

        Dim pGeometry As ESRI.ArcGIS.Geometry.IGeometry2 = point
        pGeometry.SpatialReference = pSpatRefFact.CreateGeographicCoordinateSystem(oldCoordSys)

        pGeometry.ProjectEx(newCoordSystem, ESRI.ArcGIS.Geometry.esriTransformDirection.esriTransformReverse, Nothing, False, 0, 0)

        Dim PGeoPoint As ESRI.ArcGIS.Geometry.Point = pGeometry
        Dim converted As New ESRI.ArcGIS.ADF.Web.Geometry.Point(PGeoPoint.X, PGeoPoint.Y)

        Return converted
    End Function
End Class
