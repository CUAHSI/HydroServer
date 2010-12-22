Imports System.Windows.Forms

Public Class frmRegionMap
    Dim m_connection As SqlClient.SqlConnection

    Public Sub New(ByVal maps As List(Of RegionMap), ByVal icewater As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_connection = icewater

        Dim MapIDs As New List(Of Integer)
        For Each map As RegionMap In maps
            MapIDs.Add(map.ID)
        Next map

        Dim mapImages As List(Of Image)
        mapImages = GetMaps(MapIDs)
    End Sub



    Private Function GetMaps(ByVal mapIDs As List(Of Integer)) As List(Of Image)
        Dim mapImages As New List(Of Image)

        Dim mapServer As ESRI.ArcGIS.ADF.ArcGISServer.MapServerProxy
        Dim mapInfo As ESRI.ArcGIS.ADF.ArcGISServer.MapServerInfo
        Dim mapDesc As ESRI.ArcGIS.ADF.ArcGISServer.MapDescription
        Dim imgType As ESRI.ArcGIS.ADF.ArcGISServer.ImageType
        Dim endpoint As String

        Dim SQL As String = "SELECT MapID, ConnectionUrl, MapConnection, Type, Domain, UserName, Password  FROM Maps LEFT JOIN MapServers ON Maps.ServerId = MapServers.ServerID WHERE MapID IN ('"
        SQL &= mapIDs(0)
        For i As Integer = 1 To (mapIDs.Count - 1)
            SQL &= "', '" & mapIDs(i)
        Next i
        SQL &= "')"
        Dim adapt As New SqlClient.SqlDataAdapter(SQL, m_connection)
        Dim table As New DataTable
        adapt.Fill(table)

        For Each row As DataRow In table.Rows
            Dim serverconnection As String = row.Item("ConnectionUrl")
            Dim mapconnection As String = row.Item("MapConnection")

            endpoint = ServerConnection & "/" & Split(MapConnection, "@")(1) & "/MapServer"
            mapServer = New ESRI.ArcGIS.ADF.ArcGISServer.MapServerProxy(endpoint)
            mapInfo = mapServer.GetServerInfo(Split(MapConnection, "@")(0))
            mapDesc = mapInfo.DefaultMapDescription
            For Each layer As ESRI.ArcGIS.ADF.ArcGISServer.LayerDescription In mapDesc.LayerDescriptions
                layer.Visible = True
            Next layer
            imgType = New ESRI.ArcGIS.ADF.ArcGISServer.ImageType
            imgType.ImageFormat = ESRI.ArcGIS.ADF.ArcGISServer.esriImageFormat.esriImageJPG
            imgType.ImageReturnType = ESRI.ArcGIS.ADF.ArcGISServer.esriImageReturnType.esriImageReturnURL
            Dim imgDisp As New ESRI.ArcGIS.ADF.ArcGISServer.ImageDisplay
            imgDisp.ImageHeight = pnlMapImages.Height
            imgDisp.ImageWidth = pnlMapImages.Width
            imgDisp.ImageDPI = 96
            Dim imgDesc As New ESRI.ArcGIS.ADF.ArcGISServer.ImageDescription
            imgDesc.ImageDisplay = imgDisp
            imgDesc.ImageType = imgType
            Dim mapImg As ESRI.ArcGIS.ADF.ArcGISServer.MapImage = mapServer.ExportMapImage(mapDesc, imgDesc)
            Dim webReq As System.Net.HttpWebRequest = System.Net.WebRequest.Create(mapImg.ImageURL)
            Dim webResp As System.Net.HttpWebResponse = webReq.GetResponse
            Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(webResp.GetResponseStream())
            mapImages.Add(img)
        Next row

        Return mapImages
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If LCase(e.Node.StateImageKey) = "visible" Then
            e.Node.StateImageKey = "hidden"
        Else
            e.Node.StateImageKey = "visible"
        End If
    End Sub
End Class
