Public Class Form1
    Private Enum WizardPage
        DatabaseConnection = 0
        MapServices
        Databases
        Regions
    End Enum
    Dim currPage As WizardPage

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IcewaterConnection.ConnectionString = AccessDB.connectionString
        lblDBName.Text = AccessDB.txtDatabase.Text
        lblCurrUser.Text = AccessDB.txtUser.Text
        lblServer.Text = AccessDB.txtServer.Text()
        currPage = WizardPage.DatabaseConnection
    End Sub

    Private Sub getContacts()
        Dim adapt As New SqlClient.SqlDataAdapter("SELECT * FROM Contacts", IcewaterConnection)
        Dim table As New DataTable
        adapt.Fill(table)
        dgvContacts.DataSource = table
    End Sub
    Private Sub getMapServers()
        Dim adapt As New SqlClient.SqlDataAdapter("SELECT * FROM MapServers", IcewaterConnection)
        Dim table As New DataTable
        adapt.Fill(table)
        dgvMapServers.DataSource = table
    End Sub
    Private Sub getMaps()
        Dim adapt As New SqlClient.SqlDataAdapter("SELECT * FROM MapServices", IcewaterConnection)
        Dim table As New DataTable
        adapt.Fill(table)
        dgvMaps.DataSource = table

    End Sub
    Private Sub getDatabases()
        Dim adapt As New SqlClient.SqlDataAdapter("SELECT * FROM ODMDatabases", IcewaterConnection)
        Dim table As New DataTable
        adapt.Fill(table)
        dgvDatabases.DataSource = table

    End Sub
    Private Sub getRegions()
        Dim adapt As New SqlClient.SqlDataAdapter("SELECT * FROM Regions", IcewaterConnection)
        Dim table As New DataTable
        adapt.Fill(table)
        dgvRegions.DataSource = table

    End Sub

    Private Sub btnAddContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddContact.Click
        Dim diag As New AddContact(IcewaterConnection)
        If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            getContacts()
        End If
    End Sub
    Private Sub btnAddMapServers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMapServer.Click
        Dim diag As New AddMapServer(IcewaterConnection)
        If (diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
            getMapServers()
        End If
    End Sub

    Private Sub btnAddMaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMap.Click
        'Dim diag As New SelectMapServer(IcewaterConnection)
        Dim diag As New AddMap_Full(IcewaterConnection)
        If (diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
            getMaps()
        Else

        End If
    End Sub
    Private Sub btnAddDatabases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDatabase.Click
        Dim diag As New SelectDatabaseServer(IcewaterConnection)
        If (diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
            getDatabases()
        Else

        End If
    End Sub
    Private Sub btnAddRegions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRegion.Click
        Dim diag As New SelectRegion(IcewaterConnection)
        If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            getRegions()
        Else

        End If
    End Sub

    Private Sub btnEditContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditContact.Click
        If dgvContacts.SelectedRows.Count = 1 Then
            Dim diag As New AddContact(IcewaterConnection, dgvContacts.SelectedRows(0).Cells("ContactID").Value)
            If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                getContacts()
            End If
        End If
    End Sub
    Private Sub btnEditMapServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMapServer.Click
        If dgvMapServers.SelectedRows.Count = 1 Then
            Dim diag As New AddMapServer(IcewaterConnection, dgvMapServers.SelectedRows(0).Cells("MapServerID").Value)
            If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                getMapServers()
            End If
        End If
    End Sub
    Private Sub btnEditMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditMap.Click
        If dgvMaps.SelectedRows.Count = 1 Then
            'Dim diag As New AddMap(dgvMaps.SelectedRows(0).Cells("MapServiceID").Value, IcewaterConnection)
            Dim diag As New AddMap_Full(dgvMaps.SelectedRows(0).Cells("MapServiceID").Value, IcewaterConnection)
            If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                getMaps()
            Else

            End If
        End If
    End Sub
    Private Sub btnEditDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDatabase.Click
        If dgvDatabases.SelectedRows.Count = 1 Then
            Dim diag As New AddDatabase(dgvDatabases.SelectedRows(0).Cells("DatabaseID").Value, IcewaterConnection)
            If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                getDatabases()
            Else

            End If
        End If
    End Sub
    Private Sub btnEditRegion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditRegion.Click
        If dgvRegions.SelectedRows.Count = 1 Then
            Dim diag As New SelectRegion(dgvRegions.SelectedRows(0).Cells("RegionID").Value, IcewaterConnection)
            If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                getRegions()
            Else

            End If
        End If
    End Sub

    Private Sub btnRemoveContact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeletContact.Click
        If dgvContacts.SelectedRows.Count = 1 Then
            Dim contactID As Integer = dgvContacts.SelectedRows(0).Cells("ContactID").Value
            Dim mapMeta As New SqlClient.SqlCommand("SELECT COUNT(MetadataContactID) as MapCount FROM MapServices GROUP BY MetadataContactID HAVING (MetadataContactID = '" & contactID & "')", IcewaterConnection)
            Dim mapDataset As New SqlClient.SqlCommand("SELECT COUNT(DatasetContactID) as MapCount FROM MapServices GROUP BY DatasetContactID HAVING (DatasetContactID = '" & contactID & "')", IcewaterConnection)
            Dim databaseMeta As New SqlClient.SqlCommand("SELECT COUNT(MetadataContactID) as DatabaseCount FROM ODMDatabases GROUP BY MetadataContactID HAVING (MetadataContactID = '" & contactID & "')", IcewaterConnection)
            Dim databaseDataset As New SqlClient.SqlCommand("SELECT COUNT(DatasetContactID) as DatabaseCount FROM ODMDatabases GROUP BY DatasetContactID HAVING (DatasetContactID = '" & contactID & "')", IcewaterConnection)

            IcewaterConnection.Open()
            Dim mapCount As Integer = CInt(mapMeta.ExecuteScalar) + CInt(mapDataset.ExecuteScalar)
            Dim databaseCount As Integer = CInt(databaseMeta.ExecuteScalar) + CInt(databaseDataset.ExecuteScalar)
            IcewaterConnection.Close()

            If (mapCount > 0) Or (databaseCount > 0) Then
                MsgBox("This contact is used by " & mapCount & " maps and " & databaseCount & " databases.", , "Unable to delete contact")
            Else
                If MsgBox("Are you sure you wish to permanently delete this contact?", MsgBoxStyle.OkCancel, "Delete Contact " & contactID) = MsgBoxResult.Ok Then
                    Dim deleteContact As New SqlClient.SqlCommand("DELETE FROM Contacts WHERE (ContactID = '" & contactID & "')", IcewaterConnection)

                    Try
                        IcewaterConnection.Open()
                        deleteContact.ExecuteNonQuery()
                        IcewaterConnection.Close()
                        getContacts()
                    Catch ex As Exception
                        MsgBox("Unable to delete Contact." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Unable to delete Contact")
                    End Try
                End If
            End If
        End If
    End Sub
    Private Sub btnRemoveMapServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteMapServer.Click
        If dgvMapServers.SelectedRows.Count = 1 Then
            Dim MapServerID As Integer = dgvMapServers.SelectedRows(0).Cells("MapServerID").Value
            Dim mapCmd As New SqlClient.SqlCommand("SELECT COUNT(MapServerID) as ServerCount FROM MapServices GROUP BY MapServerID HAVING (MapServerID = '" & MapServerID & "')", IcewaterConnection)

            IcewaterConnection.Open()
            Dim serverCount As Integer = mapCmd.ExecuteScalar
            IcewaterConnection.Close()

            If (serverCount > 0) Then
                MsgBox("This map server is used by " & serverCount & " maps.", , "Unable to delete map server")
            Else
                If MsgBox("Are you sure you wish to permanently delete this map?", MsgBoxStyle.OkCancel, "Delete Map Server " & MapServerID) = MsgBoxResult.Ok Then
                    Dim deleteMapServer As New SqlClient.SqlCommand("DELETE FROM MapServers WHERE (MapServerID = '" & MapServerID & "')", IcewaterConnection)

                    Try
                        IcewaterConnection.Open()
                        DeleteMapServer.ExecuteNonQuery()
                        IcewaterConnection.Close()
                        getMapServers()
                    Catch ex As Exception
                        MsgBox("Unable to delete Map Server." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Unable to delete Map Server")
                    End Try
                End If
                End If
        End If
    End Sub
    Private Sub btnRemoveMap_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveMap.Click
        If dgvMaps.SelectedRows.Count = 1 Then
            Dim MapServiceID As Integer = dgvMaps.SelectedRows(0).Cells("MapServiceID").Value
            Dim mapCmd As New SqlClient.SqlCommand("SELECT COUNT(RegionID) AS RegionCount FROM RegionMapServices GROUP BY MapServiceID HAVING (MapServiceID = '" & MapServiceID & "')", IcewaterConnection)

            Dim regionCount As Integer
            IcewaterConnection.Open()
            Try
                regionCount = mapCmd.ExecuteScalar
            Catch ex As Exception
                MsgBox("Unable to get information about Map.")
                Exit Sub
            End Try
            IcewaterConnection.Close()

            Dim message As String = "Are you sure you wish to permanently delete this map?"
            If regionCount > 0 Then
                message &= vbCrLf & "This map is used by " & regionCount & " regions." & vbCrLf & "These regions will not be deleted, but they will no longer be able to use this map."
            End If

            If MsgBox(message, MsgBoxStyle.OkCancel, "Delete Map Service " & MapServiceID) = MsgBoxResult.Ok Then
                Dim deleteLinks As New SqlClient.SqlCommand("DELETE FROM RegionMapServices WHERE MapServiceID = '" & MapServiceID & "'", IcewaterConnection)
                Dim deleteMeta As New SqlClient.SqlCommand("DELETE FROM MapServiceMetadata WHERE MapServiceID = '" & MapServiceID & "'", IcewaterConnection)
                Dim deleteMap As New SqlClient.SqlCommand("DELETE FROM MapServices WHERE MapServiceID = '" & MapServiceID & "'", IcewaterConnection)
                IcewaterConnection.Open()
                Try
                    deleteLinks.ExecuteNonQuery()
                    deleteMeta.ExecuteNonQuery()
                    deleteMap.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Unable to delete Map." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Unable to delete Map")
                End Try
                IcewaterConnection.Close()
                getMaps()
            End If
        End If
    End Sub
    Private Sub btnRemoveDatabase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveDatabase.Click
        If dgvDatabases.SelectedRows.Count = 1 Then
            Dim databaseID As Integer = dgvDatabases.SelectedRows(0).Cells("DatabaseID").Value
            Dim databaseCmd As New SqlClient.SqlCommand("SELECT COUNT(RegionID) AS RegionCount FROM RegionDatabases GROUP BY DatabaseID HAVING (DatabaseID = '" & databaseID & "')", IcewaterConnection)
            IcewaterConnection.Open()
            Dim regionCount As Integer = databaseCmd.ExecuteScalar
            IcewaterConnection.Close()

            Dim message As String = "Are you sure you wish to permanently delete this database?"
            If regionCount > 0 Then
                message &= vbCrLf & "This database is used by " & regionCount & " regions." & vbCrLf & "These regions will not be deleted, but they will no longer be able to use this database."
            End If

            If MsgBox(message, MsgBoxStyle.OkCancel, "Delete Database " & databaseID) = MsgBoxResult.Ok Then
                Dim deleteLinks As New SqlClient.SqlCommand("DELETE FROM RegionDatabases WHERE DatabaseID = '" & databaseID & "'", IcewaterConnection)
                Dim deleteMeta As New SqlClient.SqlCommand("DELETE FROM ODMDatabaseMetadata WHERE DatabaseID = '" & databaseID & "'", IcewaterConnection)
                Dim deleteDatabase As New SqlClient.SqlCommand("DELETE FROM ODMDatabases WHERE DatabaseID = '" & databaseID & "'", IcewaterConnection)

                Try
                    IcewaterConnection.Open()
                    deleteLinks.ExecuteNonQuery()
                    deleteMeta.ExecuteNonQuery()
                    deleteDatabase.ExecuteNonQuery()
                    IcewaterConnection.Close()
                    getDatabases()
                Catch ex As Exception
                    MsgBox("Unable to delete Database." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Unable to delete Database")
                End Try
            End If
        End If
    End Sub
    Private Sub btnRemoveRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveRegion.Click
        If dgvRegions.SelectedRows.Count = 1 Then
            Dim RegionID As Integer = dgvRegions.SelectedRows(0).Cells("RegionID").Value
            Dim mapCmd As New SqlClient.SqlCommand("SELECT COUNT(MapServiceID) AS RegionCount FROM RegionMapServices GROUP BY RegionID HAVING (RegionID = '" & RegionID & "')", IcewaterConnection)
            Dim databaseCmd As New SqlClient.SqlCommand("SELECT COUNT(DatabaseID) AS RegionCount FROM RegionDatabases GROUP BY RegionID HAVING (RegionID = '" & RegionID & "')", IcewaterConnection)
            IcewaterConnection.Open()
            Dim mapCount As Integer = mapCmd.ExecuteScalar
            Dim databaseCount As Integer = databaseCmd.ExecuteScalar
            IcewaterConnection.Close()

            Dim message As String = "Are you sure you wish to permanently delete this region?"
            If mapCount > 0 Then
                message &= vbCrLf & "This region is used by " & mapCount & " map services." & vbCrLf & "These maps will not be deleted, but they will no longer be associated with this region."
            End If
            If databaseCount > 0 Then
                message &= vbCrLf & "This region is used by " & databaseCount & " databases." & vbCrLf & "These databases will not be deleted, but they will no longer be associated with this region."
            End If

            If MsgBox(message, MsgBoxStyle.OkCancel, "Delete Region " & RegionID) = MsgBoxResult.Ok Then
                Dim removeMaps As New SqlClient.SqlCommand("DELETE FROM RegionMapServices WHERE RegionID = '" & RegionID & "'", IcewaterConnection)
                Dim removeDatabases As New SqlClient.SqlCommand("DELETE FROM RegionDatabases WHERE RegionID = '" & RegionID & "'", IcewaterConnection)
                Dim deleteMeta As New SqlClient.SqlCommand("DELETE FROM RegionMetadata WHERE RegionID = '" & RegionID & "'", IcewaterConnection)
                Dim deleteRegion As New SqlClient.SqlCommand("DELETE FROM Regions WHERE RegionID = '" & RegionID & "'", IcewaterConnection)

                Try
                    IcewaterConnection.Open()
                    removeMaps.ExecuteNonQuery()
                    removeDatabases.ExecuteNonQuery()
                    deleteMeta.ExecuteNonQuery()
                    deleteRegion.ExecuteNonQuery()
                    IcewaterConnection.Close()
                    getRegions()
                Catch ex As Exception
                    MsgBox("Unable to delete Region." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Unable to delete Region")
                End Try
            End If
        End If
    End Sub

    Private Sub btnContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContacts.Click
        getContacts()
        pnlContacts.Visible = True
        pnlIcewater.Visible = False
        btnBack.Visible = True
        btnFinished.Visible = False
    End Sub
    Private Sub btnMapServers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMapServers.Click
        getMapServers()
        pnlMapServers.Visible = True
        pnlIcewater.Visible = False
        btnBack.Visible = True
        btnFinished.Visible = False
    End Sub
    Private Sub btnMapServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMapServices.Click
        getMaps()
        pnlMaps.Visible = True
        pnlIcewater.Visible = False
        btnBack.Visible = True
        btnFinished.Visible = False
    End Sub
    Private Sub btnODMDatabases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnODMDatabases.Click
        getDatabases()
        pnlDatabases.Visible = True
        pnlIcewater.Visible = False
        btnBack.Visible = True
        btnFinished.Visible = False
    End Sub
    Private Sub btnRegions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegions.Click
        getRegions()
        pnlRegions.Visible = True
        pnlIcewater.Visible = False
        btnBack.Visible = True
        btnFinished.Visible = False
    End Sub
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        pnlMaps.Visible = False
        pnlDatabases.Visible = False
        pnlRegions.Visible = False
        pnlContacts.Visible = False
        pnlMapServers.Visible = False
        btnBack.Visible = False
        pnlIcewater.Visible = True
        btnFinished.Visible = True
    End Sub
    Private Sub btnFinished_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinished.Click
        Me.Close()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        AccessDB.Close()
    End Sub

    Private Sub EditDbConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditDbConnectionToolStripMenuItem.Click
        AccessDB.Show(Me)
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.Show(Me)
    End Sub
End Class
