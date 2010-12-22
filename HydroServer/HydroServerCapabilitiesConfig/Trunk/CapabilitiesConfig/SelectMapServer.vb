Public Class SelectMapServer
    Dim icewaterConnection As SqlClient.SqlConnection
    Dim serverList As New Generic.Dictionary(Of String, server)
    Dim usedMaps As Specialized.StringCollection

    Public Structure server
        Sub New(ByVal ID As Integer, ByVal Name As String, ByVal Connection As String, ByVal type As String)
            mapServerID = ID
            ServerName = Name
            ServerConnection = Connection
            Me.Type = type
        End Sub
        Public mapServerID As Integer
        Public ServerName As String
        Public ServerConnection As String
        Public Domain As String
        Public Username As String
        Public Password As String
        Public Type As String
    End Structure

    Public Sub New(ByVal icewater As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        icewaterConnection = icewater
    End Sub

    Private Sub SelectMapServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim adapter As New SqlClient.SqlDataAdapter("SELECT * FROM MapServers", icewaterConnection)
        Dim MapServers As New Data.DataTable
        adapter.Fill(MapServers)

        For Each MapServer As Data.DataRow In MapServers.Rows
            cboServers.Items.Add(MapServer.Item("MapServerName"))
            Dim connectionString As String = MapServer.Item("ConnectionURL")
            Dim myServer As New server(MapServer.Item("MapServerID"), MapServer.Item("MapServerName"), MapServer.Item("ConnectionURL"), MapServer.Item("MapServerType"))

            If Not (MapServer.Item("Username") Is DBNull.Value) Then
                myServer.Username = MapServer.Item("Username")
            End If
            If Not (MapServer.Item("Domain") Is DBNull.Value) Then
                myServer.Domain = MapServer.Item("Domain")
            End If
            If Not (MapServer.Item("Password") Is DBNull.Value) Then
                myServer.Password = MapServer.Item("Password")
            End If

            serverList.Add(MapServer.Item("MapServerName"), myServer)

        Next MapServer
    End Sub

    Private Sub cboServers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServers.SelectedIndexChanged
        lbNewMaps.Items.Clear()
        Dim Maps As Specialized.StringCollection = GetMaps(serverList(cboServers.SelectedItem))
        usedMaps = GetUsedMaps(serverList(cboServers.SelectedItem).ServerConnection)
        For Each Map As String In Maps
            If Not (usedMaps.Contains(Map)) Then
                lbNewMaps.Items.Add(Map)
                lbNewMaps.SelectedItems.Add(Map)
            End If
        Next Map
    End Sub

    Public Function GetMaps(ByVal arcGIS As server) As Specialized.StringCollection
        Dim Maps As New Specialized.StringCollection
        If Not arcGIS.ServerConnection.EndsWith("/") Then
            arcGIS.ServerConnection &= "/"
        End If

        'Dim gisCatalog As New ESRI.ArcGIS.ADF.ArcGISServer.Catalog(arcGIS.ServerConnection)
        'Dim mapServer As ESRI.ArcGIS.ADF.ArcGISServer.MapServerProxy
        'For Each service As ESRI.ArcGIS.ADF.ArcGISServer.ServiceDescription In gisCatalog.GetServiceDescriptions()
        '    If (service.Type = "MapServer") Then
        '        mapServer = New ESRI.ArcGIS.ADF.ArcGISServer.MapServerProxy(arcGIS.ServerConnection & service.Name & "/" & service.Type)
        '        For i As Integer = 0 To (mapServer.GetMapCount - 1)
        '            Maps.Add(mapServer.GetMapName(i) & "@" & service.Name)
        '        Next i
        '    End If
        'Next service

        Return Maps
    End Function
    Public Function GetUsedMaps(ByVal arcGIS As String) As Specialized.StringCollection
        Dim adapter As New SqlClient.SqlDataAdapter("SELECT MapConnection FROM MapServices LEFT JOIN MapServers ON MapServices.MapServerID = MapServers.MapServerID WHERE ConnectionURL = '" & arcGIS & "'", icewaterConnection)
        Dim table As New DataTable
        adapter.Fill(table)
        Dim usedMaps As New Specialized.StringCollection

        For Each row As DataRow In table.Rows
            usedMaps.Add(row.Item("MapConnection"))
        Next row

        Return usedMaps
    End Function

    Private Sub btnAddServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddServer.Click
        Dim diag As New AddMapServer(icewaterConnection)
        If (diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
            Dim adapter As New SqlClient.SqlDataAdapter("SELECT * FROM MapServers", icewaterConnection)
            Dim MapServers As New Data.DataTable
            adapter.Fill(MapServers)
            cboServers.Items.Clear()
            serverList.Clear()
            For Each MapServer As Data.DataRow In MapServers.Rows
                cboServers.Items.Add(MapServer.Item("MapServerName"))
                Dim connectionString As String = MapServer.Item("ConnectionURL")
                serverList.Add(MapServer.Item("MapServerName"), New server(MapServer.Item("MapServerID"), MapServer.Item("MapServerName"), MapServer.Item("ConnectionURL"), MapServer.Item("MapServerType")))
            Next MapServer
        Else

        End If
    End Sub
    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim canceled As Boolean = False
        Dim used As New List(Of String)
        For Each usedItem As String In lbNewMaps.SelectedItems
            If (Not usedMaps.Contains(usedItem)) Then
                Dim diag As New AddMap(serverList(cboServers.SelectedItem).mapServerID, serverList(cboServers.SelectedItem).ServerConnection, usedItem, icewaterConnection)
                If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    used.Add(usedItem)
                Else
                    canceled = True
                    Exit For
                End If
            End If
        Next usedItem
        For Each usedMap As String In usedMaps
            lbNewMaps.Items.Remove(usedMap)
        Next usedMap
        If canceled Then
            MsgBox("Commit changes Canceled", MsgBoxStyle.Information)
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class