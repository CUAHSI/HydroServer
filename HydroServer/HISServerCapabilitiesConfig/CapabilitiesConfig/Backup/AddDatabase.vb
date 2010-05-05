Public Class AddDatabase
    Dim DatabaseID As Integer
    Dim editing As Boolean = False
    Dim MinX As Double
    Dim MaxX As Double
    Dim MinY As Double
    Dim MaxY As Double
    Dim SiteList(1, -1) As Double
    Dim stuffToPlot As Boolean = False
    Dim m_connection As SqlClient.SqlConnection
    Dim myID As Integer = -1

    Public Sub New(ByVal icewater As SqlClient.SqlConnection, ByVal serverAddress As String, ByVal databaseName As String, ByVal userName As String, ByVal pwd As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_connection = icewater
        txtServerAddress.Text = serverAddress
        txtDatabaseName.Text = databaseName
        txtUserName.Text = userName
        txtPwd.Text = pwd
        getContactList()
    End Sub
    Public Sub New(ByVal databaseID As Integer, ByVal icewater As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_connection = icewater
        Me.DatabaseID = databaseID
        editing = True
        Dim databaseCommit As New IcewaterCommit(IcewaterCommit.TableType.ODMDatabases, m_connection)
        Dim databaseRow As Specialized.NameValueCollection = databaseCommit.GetRowToEdit(databaseID)
        If (databaseRow.Count > 0) Then
            txtTitle.Text = databaseRow.Item("Title")
            txtServerAddress.Text = databaseRow.Item("ServerAddress")
            txtDatabaseName.Text = databaseRow.Item("DatabaseName")
            txtUserName.Text = databaseRow.Item("ODMUser")
            txtPwd.Text = databaseRow.Item("ODMPassword")
            txtMarkerURL.Text = databaseRow.Item("MapMarkerURL")
            dtpReferenceDate.Value = Date.Parse(databaseRow.Item("ReferenceDate"))
            txtNorth.Text = databaseRow.Item("NorthExtent")
            txtSouth.Text = databaseRow.Item("SouthExtent")
            txtEast.Text = databaseRow.Item("EastExtent")
            txtWest.Text = databaseRow.Item("WestExtent")
            txtTopicCategory.Text = databaseRow.Item("TopicCategory")
            txtAbstract.Text = databaseRow.Item("Abstract")
            txtCitation.Text = databaseRow.Item("Citation")
            getContactList()
            cboMetadataContact.SelectedValue = databaseRow.Item("MetadataContactID")
            If databaseRow.Item("DatasetContactID") = "" Then
                cboDatasetContact.SelectedValue = -1
            Else
                cboDatasetContact.SelectedValue = databaseRow.Item("DatasetContactID")
            End If
            txtLineageStatement.Text = databaseRow.Item("LineageStatement")
            txtWaterOneFlowWSDL.Text = databaseRow.Item("WaterOneFlowWSDL")

            Dim table As DataTable = databaseCommit.GetMetadata(databaseID)
            For Each row As DataRow In table.Rows
                Dim i As Integer = dgvMeta.Rows.Add()
                dgvMeta.Rows(i).Cells("Title").Value = row.Item("Title")
                dgvMeta.Rows(i).Cells("Content").Value = row.Item("Content")
            Next row
        End If
    End Sub
    Private Sub AddDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim conn As New SqlClient.SqlConnection("Data Source=" & txtServerAddress.Text & ";Initial Catalog=" & txtDatabaseName.Text & ";Persist Security Info=True;User ID=" & txtUserName.Text & ";Password=" & txtPwd.Text & ";")
            Dim SiteBoundsAdapter As New SqlClient.SqlDataAdapter("SELECT MAX(Latitude) as MaxLat, MIN(Latitude) as MinLat, MAX(Longitude) as MaxLon, MIN(Longitude) as MinLon FROM Sites", conn)
            Dim SitesAdapter As New SqlClient.SqlDataAdapter("SELECT SiteCode, SiteName, Latitude, Longitude FROM Sites", conn)
            Dim VariablesAdapter As New SqlClient.SqlDataAdapter("SELECT VariableCode, VariableName FROM Variables", conn)
            Dim SRsAdapter As New SqlClient.SqlDataAdapter("SELECT DISTINCT SRSID, SRSName FROM SpatialReferences RIGHT JOIN Sites ON SpatialReferences.SpatialReferenceID = Sites.LatLongDatumID", conn)

            Dim SiteBounds As New DataTable
            SiteBoundsAdapter.Fill(SiteBounds)
            Dim Sites As New DataTable
            SitesAdapter.Fill(Sites)
            Dim Variables As New DataTable
            VariablesAdapter.Fill(Variables)

            ReDim SiteList(1, (Sites.Rows.Count - 1))
            For i As Integer = 0 To (Sites.Rows.Count - 1)
                lbSites.Items.Add(Sites.Rows(i).Item("SiteCode") & " - " & Sites.Rows(i).Item("SiteName"))
                SiteList(0, i) = Sites.Rows(i).Item("Longitude")
                SiteList(1, i) = Sites.Rows(i).Item("Latitude")
                stuffToPlot = True
            Next i
            If stuffToPlot And (SiteBounds.Rows.Count > 0) Then
                MinX = SiteBounds.Rows(0).Item("MinLon")
                txtWest.Text = SiteBounds.Rows(0).Item("MinLon")
                MaxX = SiteBounds.Rows(0).Item("MaxLon")
                txtEast.Text = SiteBounds.Rows(0).Item("MaxLon")
                MinY = SiteBounds.Rows(0).Item("MinLat")
                txtSouth.Text = SiteBounds.Rows(0).Item("MinLat")
                MaxY = SiteBounds.Rows(0).Item("MaxLat")
                txtNorth.Text = SiteBounds.Rows(0).Item("MaxLat")
            End If
            For Each variable As DataRow In Variables.Rows
                lbVariables.Items.Add(variable.Item("VariableCode") & " - " & variable.Item("VariableName"))
            Next variable

            drawGraph()
        Catch ex As Exception
#If DEBUG Then
            MsgBox("Unable to connect to ODM Database", , "AddDatabase.Load")
#End If
        End Try
    End Sub
    Private Sub drawGraph()
        Dim g As ZedGraph.GraphPane = zgSites.GraphPane
        zgSites.BackColor = Color.Transparent
        g.XAxis.IsVisible = False
        g.YAxis.IsVisible = False
        g.Title.IsVisible = False
        g.Border.IsVisible = False
        g.Legend.IsVisible = False
        zgSites.BorderStyle = BorderStyle.None

        If stuffToPlot Then
            Dim box As New ZedGraph.BoxObj
            box.Location.X = MinX
            box.Location.Width = MaxX - MinX
            box.Location.Y = MaxY
            box.Location.Height = MaxY - MinY
            box.ZOrder = ZedGraph.ZOrder.D_BehindCurves
            box.Border.Color = Color.Red
            box.Border.PenWidth = 3
            box.Border.IsVisible = True
            box.Fill.IsVisible = False
            g.GraphObjList.Add(box)

            Dim line As New ZedGraph.LineItem("Sites")
            line.Line.IsVisible = False
            line.Symbol.IsVisible = True
            line.Symbol.Size = 10
            line.Symbol.Type = ZedGraph.SymbolType.Circle
            line.Symbol.Fill.IsVisible = True
            Dim c As Color = Color.FromArgb(125, 0, 0, 0)
            line.Symbol.Fill.Color = c
            line.Symbol.Fill.Type = ZedGraph.FillType.Solid
            line.Symbol.Border.IsVisible = False
            For i As Integer = 0 To (SiteList.GetUpperBound(1))
                line.AddPoint(SiteList(0, i), SiteList(1, i))
            Next i
            g.CurveList.Add(line)

            g.XAxis.Scale.Min = MinX - ((MaxX - MinX) * 0.1)
            g.XAxis.Scale.Max = MaxX + ((MaxX - MinX) * 0.1)
            g.YAxis.Scale.Min = MinY - ((MaxY - MinY) * 0.1)
            g.YAxis.Scale.Max = MaxY + ((MaxY - MinY) * 0.1)
        End If
        zgSites.AxisChange()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If IsValidForm() Then
            If CommitChanges() Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Unable to commit changes")
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Function IsValidForm() As Boolean
        If (txtTitle.Text = "") Or (txtServerAddress.Text = "") Or (txtDatabaseName.Text = "") Or _
        (txtUserName.Text = "") Or (txtPwd.Text = "") Or (txtWaterOneFlowWSDL.Text = "") Or _
        (dtpReferenceDate.Text = "") Or (dtpReferenceDate.Value = Nothing) Or _
        (txtNorth.Text = "") Or (txtSouth.Text = "") Or (txtEast.Text = "") Or (txtWest.Text = "") Or _
        (txtTopicCategory.Text = "") Or (txtAbstract.Text = "") Or (cboMetadataContact.Text = "") Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function CommitChanges() As Boolean
        Dim DBCommit As New IcewaterCommit(IcewaterCommit.TableType.ODMDatabases, m_connection)
        Dim params As New Specialized.NameValueCollection
        params.Add("Title", txtTitle.Text)
        params.Add("ServerAddress", txtServerAddress.Text)
        params.Add("DatabaseName", txtDatabaseName.Text)
        params.Add("ODMUser", txtUserName.Text)
        params.Add("ODMPassword", txtPwd.Text)
        If Not (txtMarkerURL.Text = "") Then
            params.Add("MapMarkerURL", txtMarkerURL.Text)
        End If
        params.Add("ReferenceDate", dtpReferenceDate.Value)
        params.Add("NorthExtent", Val(txtNorth.Text))
        params.Add("EastExtent", Val(txtEast.Text))
        params.Add("SouthExtent", Val(txtSouth.Text))
        params.Add("WestExtent", Val(txtWest.Text))
        params.Add("TopicCategory", txtTopicCategory.Text)
        params.Add("Abstract", txtAbstract.Text)
        params.Add("Citation", txtCitation.Text)
        params.Add("MetadataContactID", cboMetadataContact.SelectedValue)
        If Not ((cboDatasetContact.SelectedItem Is Nothing) OrElse (cboDatasetContact.Text = "") OrElse (cboDatasetContact.SelectedValue < 0)) Then
            params.Add("DatasetContactID", cboDatasetContact.SelectedValue)
        End If
        If Not (txtLineageStatement.Text = "") Then
            params.Add("LineageStatement", txtLineageStatement.Text)
        End If
        params.Add("WaterOneFlowWSDL", txtWaterOneFlowWSDL.Text)

        Dim id As Integer
        If editing Then
            id = DBCommit.UpdateRow(DatabaseID, params)
        Else
            id = DBCommit.CommitRow(params)
        End If
        If (id > 0) Then
            Dim titles As New Specialized.StringCollection
            Dim contents As New Specialized.StringCollection
            For Each row As DataGridViewRow In dgvMeta.Rows
                If row.IsNewRow Then

                Else
                    titles.Add(row.Cells("Title").Value)
                    contents.Add(row.Cells("Content").Value)
                End If
            Next row
            If (DBCommit.CommitMetadata(id, titles, contents)) Then
                Return True
            End If
        Else
            Return False
        End If
        Return False
    End Function

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

    Private Sub getContactList()
        Try
            Dim ContactAdapter As New SqlClient.SqlDataAdapter("SELECT ContactID, FirstName, LastName, OrganizationName FROM Contacts", m_connection)
            Dim dContacts As New DataTable
            Dim mContacts As DataTable
            ContactAdapter.Fill(dContacts)
            dContacts.Columns.Add("DisplayName", "String".GetType)
            For Each contact As DataRow In dContacts.Rows
                Dim name As String
                If (contact.Item("FirstName") Is DBNull.Value) OrElse (contact.Item("FirstName") = "") Then
                    If (contact.Item("LastName") Is DBNull.Value) OrElse (contact.Item("LastName") = "") Then
                        name = ""
                    Else
                        name = contact.Item("LastName") & " - "
                    End If
                Else
                    name = contact.Item("FirstName") & " "
                    If (contact.Item("LastName") Is DBNull.Value) OrElse (contact.Item("LastName") = "") Then
                        name &= "- "
                    Else
                        name &= contact.Item("LastName") & " - "
                    End If
                End If
                name &= contact.Item("OrganizationName")

                contact.Item("DisplayName") = name
            Next contact
            mContacts = dContacts.Copy

            Dim row As DataRow = dContacts.NewRow
            row.Item("ContactID") = -1
            row.Item("OrganizationName") = "{N\A}"
            row.Item("DisplayName") = "{N\A}"
            dContacts.Rows.InsertAt(row, 0)

            cboDatasetContact.DataSource = New BindingSource(dContacts, Nothing)
            cboDatasetContact.DisplayMember = "DisplayName"
            cboDatasetContact.ValueMember = "ContactID"
            cboMetadataContact.DataSource = New BindingSource(mContacts, Nothing)
            cboMetadataContact.DisplayMember = "DisplayName"
            cboMetadataContact.ValueMember = "ContactID"
        Catch ex As Exception
            MsgBox("")
        End Try
    End Sub
    Private Sub addMetadataContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addMetadataContact.Click
        Dim diag As New AddContact(m_connection)
        If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            getContactList()
        End If
    End Sub
    Private Sub addDatasetContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addDatasetContact.Click
        Dim diag As New AddContact(m_connection)
        If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            getContactList()
        End If
    End Sub
End Class