

Public Structure RegionDB
    Public Sub New(ByVal e_Title As String, ByVal e_ID As Integer)
        Title = e_Title
        ID = e_ID
        DisplayName = ""
    End Sub

    Public Title As String
    Public ID As Integer
    Public DisplayName As String
    Public Order As Integer
End Structure
Public Structure RegionMap
    Public Sub New(ByVal e_Title As String, ByVal e_ID As Integer)
        Title = e_Title
        ID = e_ID
        DisplayName = ""
        Transparency = 0
        isVisible = True
        isTOC = True
        isBaseMapService = False
    End Sub

    Public Title As String
    Public ID As Integer
    Public DisplayName As String
    Public Transparency As Integer
    Public isVisible As Boolean
    Public isTOC As Boolean
    Public isBaseMapService As Boolean
    Public Order As Integer
End Structure

Public Class SelectRegion
    Private Enum RegionPage
        RegionDefinition = 0
        MapSelect
        DatabaseSelect
        MetadataSelect
    End Enum
    Dim editing As Boolean = False
    Dim regionID As Integer = -1
    Dim currPage As RegionPage
    Dim icewaterConnection As SqlClient.SqlConnection
    Dim databaseInfo As System.Collections.Generic.Dictionary(Of String, RegionDB)
    Dim mapInfo As System.Collections.Generic.Dictionary(Of String, RegionMap)

    Public Sub New(ByVal icewater As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        icewaterConnection = icewater
        currPage = RegionPage.RegionDefinition
    End Sub
    Public Sub New(ByVal regionID As Integer, ByVal icewater As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        icewaterConnection = icewater
        editing = True
        Me.regionID = regionID
        Dim regionCommit As New IcewaterCommit(IcewaterCommit.TableType.Regions, icewaterConnection)
        Dim regionRow As Specialized.NameValueCollection = regionCommit.GetRowToEdit(regionID)
        If (regionRow.Count > 0) Then
            txtDisplayName.Text = regionRow.Item("RegionName")
            txtTitle.Text = regionRow.Item("RegionTitle")
            numNorthExtent.Value = Decimal.Parse(regionRow.Item("NorthExtent"))
            numSouthExtent.Value = Decimal.Parse(regionRow.Item("SouthExtent"))
            numEastExtent.Value = Decimal.Parse(regionRow.Item("EastExtent"))
            numWestExtent.Value = Decimal.Parse(regionRow.Item("WestExtent"))
            txtDescription.Text = regionRow.Item("RegionDescription")
            txtCSS.Text = regionRow.Item("RegionMapCSSURL")

            Dim table As DataTable = regionCommit.GetMetadata(regionID)
            For Each row As DataRow In table.Rows
                Dim i As Integer = dgvMeta.Rows.Add()
                dgvMeta.Rows(i).Cells("Title").Value = row.Item("Title")
                dgvMeta.Rows(i).Cells("Content").Value = row.Item("Content")
            Next row
        End If
    End Sub

    Private Sub SelectRegion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mapAdapt As New SqlClient.SqlDataAdapter("SELECT Title, MapServiceID FROM MapServices", icewaterConnection)
        Dim dbAdapt As New SqlClient.SqlDataAdapter("SELECT Title, DatabaseID FROM ODMDatabases", icewaterConnection)
        Dim regionCommit As New IcewaterCommit(IcewaterCommit.TableType.Regions, icewaterConnection)
        databaseInfo = New Dictionary(Of String, RegionDB)
        mapInfo = New Dictionary(Of String, RegionMap)
        Dim regions As New DataTable
        Dim maps As New DataTable
        Dim dbs As New DataTable

        mapAdapt.Fill(maps)
        dbAdapt.Fill(dbs)

        Dim mapServicesInRegion As DataTable = regionCommit.GetMapServicesInRegion(regionID)
        Dim usedMaps(mapServicesInRegion.Rows.Count - 1) As String
        For Each mapService As DataRow In maps.Rows
            Dim rms As New RegionMap(mapService.Item("Title"), mapService.Item("MapServiceID"))



            Dim rows() As DataRow = mapServicesInRegion.Select("MapServiceID = '" & rms.ID & "'")
            If (rows.Length >= 1) Then
                Dim i As Integer = mapServicesInRegion.Rows.IndexOf(rows(0))

                rms.DisplayName = rows(0).Item("DisplayName")
                rms.Transparency = rows(0).Item("TransparencyPercent")
                rms.isVisible = rows(0).Item("isVisible")
                rms.isTOC = rows(0).Item("isTOC")
                rms.isBaseMapService = rows(0).Item("isBaseMapService")
                rms.Order = rows(0).Item("DisplayOrder")

                usedMaps(i) = rms.Title
            Else
                lstNewMaps.Items.Add(rms.Title)
            End If
            mapInfo.Add(rms.Title, rms)
        Next mapService
        lstUsedMaps.Items.AddRange(usedMaps)

        Dim databasesInRegion As DataTable = regionCommit.GetDatabasesInRegion(regionID)
        Dim usedDatabases(databasesInRegion.Rows.Count - 1) As String
        For Each db As DataRow In dbs.Rows
            Dim rdb As New RegionDB(db.Item("Title"), db.Item("DatabaseID"))

            Dim rows() As DataRow = databasesInRegion.Select("DatabaseID = '" & rdb.ID & "'")
            If (rows.Length >= 1) Then
                Dim i As Integer = databasesInRegion.Rows.IndexOf(rows(0))
                rdb.DisplayName = rows(0).Item("DisplayName")
                rdb.Order = rows(0).Item("DisplayOrder")
                usedDatabases(i) = rdb.Title
            Else
                lstNewDatabases.Items.Add(rdb.Title)
            End If
            databaseInfo.Add(rdb.Title, rdb)
        Next db
        lstUsedDatabases.Items.AddRange(usedDatabases)
    End Sub

#Region " Databases "

    Private Sub btnAddAllDatabases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAllDatabases.Click
        Dim used As New List(Of String)
        For Each db As String In lstNewDatabases.Items
            Dim info As RegionDB = databaseInfo(db)
            Dim displayName As String = InputBox("Please enter a the Display Name for " & db & "." & vbCrLf & "This display name only applies to this Region.", "Enter Display Name", info.DisplayName)
            If displayName <> "" Then
                used.Add(db)
                info.DisplayName = displayName
                databaseInfo(db) = info
                'MsgBox(displayName & vbCrLf & info.DisplayName & vbCrLf & databaseInfo(db).DisplayName & vbCrLf & "||||||||||")
            End If
        Next db
        For Each usedDB As String In used
            lstNewDatabases.Items.Remove(usedDB)
            lstUsedDatabases.Items.Add(usedDB)
        Next usedDB
    End Sub

    Private Sub btnAddSelectedDatabases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSelectedDatabases.Click
        Dim used As New List(Of String)
        For Each db As String In lstNewDatabases.SelectedItems
            Dim info As RegionDB = databaseInfo(db)
            Dim displayName As String = InputBox("Please enter a the Display Name for " & db & "." & vbCrLf & "This display name only applies to this Region.", "Enter Display Name", info.DisplayName)
            If displayName <> "" Then
                used.Add(db)
                info.DisplayName = displayName
                databaseInfo(db) = info
                'MsgBox(displayName & vbCrLf & info.DisplayName & vbCrLf & databaseInfo(db).DisplayName & vbCrLf & "||||||||||")
            End If
        Next db
        For Each usedDB As String In used
            lstNewDatabases.Items.Remove(usedDB)
            lstUsedDatabases.Items.Add(usedDB)
        Next usedDB
    End Sub

    Private Sub btnRemoveSelectedDatabases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSelectedDatabases.Click
        Dim used As New List(Of String)
        For Each db As String In lstUsedDatabases.SelectedItems
            used.Add(db)
        Next db
        For Each usedDB As String In used
            lstUsedDatabases.Items.Remove(usedDB)
            lstNewDatabases.Items.Add(usedDB)
        Next usedDB
    End Sub

    Private Sub btnRemoveAllDatabases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllDatabases.Click
        Dim used As New List(Of String)
        For Each db As String In lstUsedDatabases.SelectedItems
            used.Add(db)
        Next db
        For Each usedDB As String In used
            lstUsedDatabases.Items.Remove(usedDB)
            lstNewDatabases.Items.Add(usedDB)
        Next usedDB
    End Sub

    Private Sub btnMoveDatabaseUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDatabaseUp.Click
        Dim groupFirst As New List(Of Integer)
        Dim groupLast As New List(Of Integer)
        Dim SelectedItems As New List(Of Object)

        For Each id As Integer In lstUsedDatabases.SelectedIndices
            SelectedItems.Add(lstUsedDatabases.Items.Item(id))
            If (id = 0) Then
                groupFirst.Add(id)
            Else
                If Not (lstUsedDatabases.SelectedIndices.Contains(id - 1)) Then
                    groupFirst.Add(id)
                End If
            End If
            If (id = (lstUsedDatabases.Items.Count - 1)) Then
                groupLast.Add(id)
            Else
                If Not (lstUsedDatabases.SelectedIndices.Contains(id + 1)) Then
                    groupLast.Add(id)
                End If
            End If
        Next id

        If (groupFirst.Count <> groupLast.Count) Then
            Throw New Exception("Unknown grouping")
        End If

        For i As Integer = 0 To (groupFirst.Count - 1)
            If groupFirst(i) <> 0 Then
                For ID As Integer = groupFirst(i) To groupLast(i)
                    Dim temp As Object = lstUsedDatabases.Items.Item(ID)
                    lstUsedDatabases.Items.Remove(temp)
                    lstUsedDatabases.Items.Insert(ID - 1, temp)
                Next ID
            End If
        Next i

        For Each item As Object In SelectedItems
            lstUsedDatabases.SelectedItems.Add(item)
        Next item
    End Sub

    Private Sub btnMoveDatabaseDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDatabaseDown.Click
        Dim groupFirst As New List(Of Integer)
        Dim groupLast As New List(Of Integer)
        Dim SelectedItems As New List(Of Object)

        For Each id As Integer In lstUsedDatabases.SelectedIndices
            SelectedItems.Add(lstUsedDatabases.Items.Item(id))
            If (id = 0) Then
                groupFirst.Add(id)
            Else
                If Not (lstUsedDatabases.SelectedIndices.Contains(id - 1)) Then
                    groupFirst.Add(id)
                End If
            End If
            If (id = (lstUsedDatabases.Items.Count - 1)) Then
                groupLast.Add(id)
            Else
                If Not (lstUsedDatabases.SelectedIndices.Contains(id + 1)) Then
                    groupLast.Add(id)
                End If
            End If
        Next id

        If (groupFirst.Count <> groupLast.Count) Then
            Throw New Exception("Unknown grouping")
        End If

        For i As Integer = (groupLast.Count - 1) To 0 Step -1
            If groupLast(i) <> (lstUsedDatabases.Items.Count - 1) Then
                For ID As Integer = groupLast(i) To groupFirst(i) Step -1
                    Dim temp As Object = lstUsedDatabases.Items.Item(ID)
                    lstUsedDatabases.Items.Remove(temp)
                    lstUsedDatabases.Items.Insert(ID + 1, temp)
                Next ID
            End If
        Next i

        For Each item As Object In SelectedItems
            lstUsedDatabases.SelectedItems.Add(item)
        Next item
    End Sub

#End Region

#Region " Maps "

    Private Sub btnAddAllMaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAllMaps.Click
        Dim used As New List(Of String)
        For Each map As String In lstNewMaps.Items
            Dim info As RegionMap = mapInfo(map)
            Dim diag As New AddRegionMap(map, info.DisplayName, info.Transparency, info.isVisible, info.isTOC, info.isBaseMapService)
            If (diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                used.Add(map)
                info.DisplayName = diag.DisplayName
                info.Transparency = diag.TransparencyPercent
                info.isVisible = diag.IsVisible
                info.isTOC = diag.IsTOC
                info.isBaseMapService = diag.IsBaseMapService
                mapInfo(map) = info
            End If
        Next map
        For Each usedmap As String In used
            lstNewMaps.Items.Remove(usedmap)
            lstUsedMaps.Items.Add(usedmap)
        Next usedmap
    End Sub

    Private Sub btnAddSelectedMaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSelectedMaps.Click
        Dim used As New List(Of String)
        For Each map As String In lstNewMaps.SelectedItems
            Dim info As RegionMap = mapInfo(map)
            Dim diag As New AddRegionMap(map, info.DisplayName, info.Transparency, info.isVisible, info.isTOC, info.isBaseMapService)
            If (diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                used.Add(map)
                info.DisplayName = diag.DisplayName
                info.Transparency = diag.TransparencyPercent
                info.isVisible = diag.IsVisible
                info.isTOC = diag.IsTOC
                info.isBaseMapService = diag.IsBaseMapService
                mapInfo(map) = info
            End If
        Next map
        For Each usedmap As String In used
            lstNewMaps.Items.Remove(usedmap)
            lstUsedMaps.Items.Add(usedmap)
        Next usedmap
    End Sub

    Private Sub btnRemoveSelectedMaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSelectedMaps.Click
        Dim used As New List(Of String)
        For Each map As String In lstUsedMaps.SelectedItems
            used.Add(map)
        Next map
        For Each usedmap As String In used
            lstUsedMaps.Items.Remove(usedmap)
            lstNewMaps.Items.Add(usedmap)
        Next usedmap
    End Sub

    Private Sub btnRemoveAllMaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllMaps.Click
        Dim used As New List(Of String)
        For Each map As String In lstUsedMaps.Items
            used.Add(map)
        Next map
        For Each usedmap As String In used
            lstUsedMaps.Items.Remove(usedmap)
            lstNewMaps.Items.Add(usedmap)
        Next usedmap
    End Sub

    Private Sub btnMoveMapUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveMapUp.Click
        Dim groupFirst As New List(Of Integer)
        Dim groupLast As New List(Of Integer)
        Dim SelectedItems As New List(Of Object)

        For Each id As Integer In lstUsedMaps.SelectedIndices
            SelectedItems.Add(lstUsedMaps.Items.Item(id))
            If (id = 0) Then
                groupFirst.Add(id)
            Else
                If Not (lstUsedMaps.SelectedIndices.Contains(id - 1)) Then
                    groupFirst.Add(id)
                End If
            End If
            If (id = (lstUsedMaps.Items.Count - 1)) Then
                groupLast.Add(id)
            Else
                If Not (lstUsedMaps.SelectedIndices.Contains(id + 1)) Then
                    groupLast.Add(id)
                End If
            End If
        Next id

        If (groupFirst.Count <> groupLast.Count) Then
            Throw New Exception("Unknown grouping")
        End If

        For i As Integer = 0 To (groupFirst.Count - 1)
            If groupFirst(i) <> 0 Then
                For ID As Integer = groupFirst(i) To groupLast(i)
                    Dim temp As Object = lstUsedMaps.Items.Item(ID)
                    lstUsedMaps.Items.Remove(temp)
                    lstUsedMaps.Items.Insert(ID - 1, temp)
                Next ID
            End If
        Next i

        For Each item As Object In SelectedItems
            lstUsedMaps.SelectedItems.Add(item)
        Next item
    End Sub

    Private Sub btnMoveMapDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveMapDown.Click
        Dim groupFirst As New List(Of Integer)
        Dim groupLast As New List(Of Integer)
        Dim SelectedItems As New List(Of Object)

        For Each id As Integer In lstUsedMaps.SelectedIndices
            SelectedItems.Add(lstUsedMaps.Items.Item(id))
            If (id = 0) Then
                groupFirst.Add(id)
            Else
                If Not (lstUsedMaps.SelectedIndices.Contains(id - 1)) Then
                    groupFirst.Add(id)
                End If
            End If
            If (id = (lstUsedMaps.Items.Count - 1)) Then
                groupLast.Add(id)
            Else
                If Not (lstUsedMaps.SelectedIndices.Contains(id + 1)) Then
                    groupLast.Add(id)
                End If
            End If
        Next id

        If (groupFirst.Count <> groupLast.Count) Then
            Throw New Exception("Unknown grouping")
        End If

        For i As Integer = (groupLast.Count - 1) To 0 Step -1
            If groupLast(i) <> (lstUsedMaps.Items.Count - 1) Then
                For ID As Integer = groupLast(i) To groupFirst(i) Step -1
                    Dim temp As Object = lstUsedMaps.Items.Item(ID)
                    lstUsedMaps.Items.Remove(temp)
                    lstUsedMaps.Items.Insert(ID + 1, temp)
                Next ID
            End If
        Next i

        For Each item As Object In SelectedItems
            lstUsedMaps.SelectedItems.Add(item)
        Next item
    End Sub

    'Private Sub btnViewMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewMap.Click
    '    If lstUsedMaps.Items.Count > 0 Then
    '        Dim regionMaps As New List(Of RegionMap)
    '        For Each item As String In lstUsedMaps.Items
    '            regionMaps.Add(mapInfo(item))
    '        Next item
    '        Dim diag As New frmRegionMap(regionMaps, icewaterConnection)
    '        diag.Show(Me)
    '    End If

    'End Sub

#End Region


    Private Sub btnAddMeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMeta.Click
        Dim diag As New AddMetadata("Add Database")
        If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim i As Integer = dgvMeta.Rows.Add()
            dgvMeta.Rows(i).Cells("Title").Value = diag.metaTitle
            dgvMeta.Rows(i).Cells("Content").Value = diag.metaContent
        Else

        End If
    End Sub
    Private Sub btnEditMeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditMeta.Click
        For Each row As DataGridViewRow In dgvMeta.SelectedRows
            Dim diag As New AddMetadata("Edit Database", row.Cells("Title").Value, row.Cells("Content").Value)
            If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                row.Cells("Title").Value = diag.metaTitle
                row.Cells("Content").Value = diag.metaContent
            Else

            End If
        Next row
    End Sub
    Private Sub btnRemoveMeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveMeta.Click
        Dim rows As DataGridViewSelectedRowCollection = dgvMeta.SelectedRows
        For Each row As DataGridViewRow In rows
            dgvMeta.Rows.Remove(row)
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        If currPage <= 0 Then
            currPage = RegionPage.RegionDefinition
        Else
            currPage -= 1
        End If

        Select Case currPage
            Case RegionPage.RegionDefinition
                btnBack.Visible = False
                pnlDefineRegion.Visible = True
                pnlSelectMaps.Visible = False
            Case RegionPage.MapSelect
                pnlSelectMaps.Visible = True
                pnlSelectDatabases.Visible = False
            Case RegionPage.DatabaseSelect
                pnlSelectDatabases.Visible = True
                pnlMetadata.Visible = False
                btnNext.Visible = True
                btnFinish.Visible = False
            Case RegionPage.MetadataSelect
                pnlMetadata.Visible = True
            Case Else
                pnlDefineRegion.Visible = False
                pnlSelectMaps.Visible = False
                pnlSelectDatabases.Visible = False
                pnlMetadata.Visible = False
        End Select
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If currPage = RegionPage.RegionDefinition Then
            If Not isDefineRegionValid() Then
                Exit Sub
            End If
        End If
        If currPage >= RegionPage.MetadataSelect Then
            currPage = RegionPage.MetadataSelect
        Else
            currPage += 1
        End If

        Select Case currPage
            Case RegionPage.RegionDefinition
                pnlDefineRegion.Visible = True
            Case RegionPage.MapSelect
                btnBack.Visible = True
                pnlDefineRegion.Visible = False
                pnlSelectMaps.Visible = True
            Case RegionPage.DatabaseSelect
                pnlSelectMaps.Visible = False
                pnlSelectDatabases.Visible = True
            Case RegionPage.MetadataSelect
                pnlSelectDatabases.Visible = False
                pnlMetadata.Visible = True
                btnNext.Visible = False
                btnFinish.Visible = True
            Case Else
                pnlDefineRegion.Visible = False
                pnlSelectMaps.Visible = False
                pnlSelectDatabases.Visible = False
                pnlMetadata.Visible = False
        End Select
    End Sub
    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        If txtTitle.Text <> "" Then
            If CommitRegion() Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Unable to commit Region")
            End If
        End If
    End Sub

    Private Function CommitRegion() As Boolean
        Dim commit As New IcewaterCommit(IcewaterCommit.TableType.Regions, icewaterConnection)
        'Dim id As Integer = -1

        Try
            Dim params As New Specialized.NameValueCollection
            params.Add("RegionName", txtDisplayName.Text)
            params.Add("RegionTitle", txtTitle.Text)
            params.Add("NorthExtent", numNorthExtent.Value)
            params.Add("EastExtent", numEastExtent.Value)
            params.Add("SouthExtent", numSouthExtent.Value)
            params.Add("WestExtent", numWestExtent.Value)
            params.Add("RegionDescription", txtDescription.Text)
            params.Add("RegionMapCSSURL", txtCSS.Text)
            If editing Then
                regionID = commit.UpdateRow(regionID, params)
            Else
                regionID = commit.CommitRow(params)
            End If
        Catch ex As Exception
            Return False
        End Try

        Dim mapcount As Integer
        Try
            Dim MapServiceIDs As New List(Of Integer)
            Dim mapNames As New List(Of String)
            Dim trans As New List(Of Integer)
            Dim isVis As New List(Of Boolean)
            Dim isTOC As New List(Of Boolean)
            Dim isBMS As New List(Of Boolean)
            For Each map As String In lstUsedMaps.Items
                MapServiceIDs.Add(mapInfo(map).ID)
                mapNames.Add(mapInfo(map).DisplayName)
                trans.Add(mapInfo(map).Transparency)
                isVis.Add(mapInfo(map).isVisible)
                isTOC.Add(mapInfo(map).isTOC)
                isBMS.Add(mapInfo(map).isBaseMapService)
            Next map
            mapcount = commit.AddMapServicesToRegion(regionID, MapServiceIDs, mapNames, trans, isVis, isTOC, isBMS)

        Catch ex As Exception
            Return False
        End Try

        Dim dbCount As Integer
        Try
            Dim dbIDs As New List(Of Integer)
            Dim dbNames As New List(Of String)
            For Each db As String In lstUsedDatabases.Items
                dbIDs.Add(databaseInfo(db).ID)
                dbNames.Add(databaseInfo(db).DisplayName)
            Next db
            dbCount = commit.AddDatabasesToRegion(regionID, dbIDs, dbNames)

        Catch ex As Exception
            Return False
        End Try
        If (regionID > 0) Then
            Dim titles As New Specialized.StringCollection
            Dim contents As New Specialized.StringCollection
            For Each row As DataGridViewRow In dgvMeta.Rows
                If row.IsNewRow Then

                Else
                    titles.Add(row.Cells("Title").Value)
                    contents.Add(row.Cells("Content").Value)
                End If
            Next row
            If (commit.CommitMetadata(regionID, titles, contents)) Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Function isDefineRegionValid() As Boolean
        If (txtDisplayName.Text <> "") And (txtTitle.Text <> "") Then
            Return True
        End If
        Return False
    End Function

End Class