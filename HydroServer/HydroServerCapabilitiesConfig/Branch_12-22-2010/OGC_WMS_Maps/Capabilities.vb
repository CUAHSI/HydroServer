Public Class Capabilities
    '1.3.0
    'http://maps.usu.edu/ArcGIS/services/BearRiver/Administrative/MapServer/WMSServer?SERVICE=WMS&REQUEST=GetCapabilities
    '1.1.1
    'http://columbo.nrlssc.navy.mil/ogcwms/servlet/WMSServlet/Salt_Lake_City_UT_Maps.wms?SERVICE=WMS&REQUEST=GetCapabilities

    Private m_url As String
    Private m_doc As Xml.XmlDocument
    Public Sub New()
        URL = "http://columbo.nrlssc.navy.mil/ogcwms/servlet/WMSServlet/Salt_Lake_City_UT_Maps.wms"
        m_doc = New Xml.XmlDocument
        m_doc.Load(URL & "?SERVICE=WMS&REQUEST=GetCapabilities")
        'url = url & "?SERVICE=WMS&REQUEST=GetCapabilities"
    End Sub
    Public Sub New(ByVal url As String)
        Me.URL = url
        m_doc = New Xml.XmlDocument
        m_doc.Load(url & "?SERVICE=WMS&REQUEST=GetCapabilities")
        'url = url & "?SERVICE=WMS&REQUEST=GetCapabilities"
    End Sub

    Public Sub Refresh()
        m_doc.Load(URL & "?SERVICE=WMS&REQUEST=GetCapabilities")
    End Sub

    Public Property URL() As String
        Get
            Return m_url
        End Get
        Set(ByVal value As String)
            m_url = value
        End Set
    End Property

    Public Function getVersion() As String
        Dim version As Xml.XmlAttribute = m_doc.Attributes.GetNamedItem("version")

        Return version.Value
    End Function

    Public Function getLayerNames() As System.Collections.Specialized.NameValueCollection
        Dim dict As New System.Collections.Specialized.NameValueCollection

        For Each Layer As Xml.XmlElement In m_doc.GetElementsByTagName("Layer")
            Dim LayerName As String = ""
            Dim LayerTitle As String = ""
            For Each Element As Xml.XmlElement In Layer.ChildNodes
                If (Element.Name = "Name") Then
                    LayerName = Element.InnerText
                ElseIf (Element.Name = "Title") Then
                    LayerTitle = Element.InnerText
                End If
            Next Element
            If (LayerName <> "") And (LayerTitle <> "") Then
                dict.Add(LayerName, LayerTitle)
            End If
        Next Layer

        Return dict
    End Function

    Public Function getBoundingBox(ByVal layerName As String) As BoundingBox
        Dim minX As Double = Double.NaN
        Dim minY As Double = Double.NaN
        Dim maxX As Double = Double.NaN
        Dim maxY As Double = Double.NaN

        For Each Layer As Xml.XmlElement In m_doc.GetElementsByTagName("Layer")
            Dim FoundLayer As Boolean = False
            For Each Child As Xml.XmlElement In Layer.ChildNodes
                If (Child.Name = "Name") Then
                    If (Child.InnerText = layerName) Then
                        FoundLayer = True
                        Exit For
                    End If
                End If
            Next Child
            If (FoundLayer) Then
                For Each Child As Xml.XmlElement In Layer.ChildNodes
                    If (Child.Name = "LatLonBoundingBox") Then
                        Try
                            minX = Child.Attributes.GetNamedItem("minx").Value
                            minY = Child.Attributes.GetNamedItem("miny").Value
                            maxX = Child.Attributes.GetNamedItem("maxx").Value
                            maxY = Child.Attributes.GetNamedItem("maxy").Value
                        Catch ex As Exception

                        End Try
                    End If
                Next Child
            End If
        Next Layer

        Return New BoundingBox(minX, minY, maxX, maxY)
    End Function

    Public Function GetFormats() As List(Of String)
        Dim formats As New List(Of String)

        For Each GetMap As Xml.XmlElement In m_doc.GetElementsByTagName("GetMap")
            For Each Element As Xml.XmlElement In GetMap.ChildNodes
                If (Element.Name = "Format") Then
                    formats.Add(Element.InnerText)
                End If
            Next Element
        Next GetMap

        Return formats
    End Function

    'Public Function getStyleNames(ByVal layerName As String) As List(Of String)
    '    Dim styles As New List(Of String)
    '
    '    Return styles
    'End Function

    'Public Function getCoordinateSystems() As List(Of String)
    '    Dim coordSystems As New List(Of String)
    '
    '    Return coordSystems
    'End Function
End Class
