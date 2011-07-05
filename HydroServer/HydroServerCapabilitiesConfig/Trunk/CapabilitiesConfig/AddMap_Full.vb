Public Class AddMap_Full
    Dim MapServiceID As Integer = -1
    Dim editing As Boolean = False
    'Dim endpoint As String
    'Dim mapServerID As Integer
    Dim m_connection As SqlClient.SqlConnection

    Public Sub New(ByVal icewater As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        m_connection = icewater

        getContactList()
        getMapServerList()
    End Sub
    Public Sub New(ByVal mapServiceID As Integer, ByVal icewater As SqlClient.SqlConnection)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        editing = True
        Me.MapServiceID = mapServiceID
        m_connection = icewater
        Dim serviceCommit As New IcewaterCommit(IcewaterCommit.TableType.MapServices, m_connection)
        Dim serviceRow As Specialized.NameValueCollection = serviceCommit.GetRowToEdit(mapServiceID)

        If (serviceRow.Count > 0) Then
            'mapServerID = serviceRow.Item("MapServerID")
            Try
                getContactList()
                getMapServerList()

                txtTitle.Text = serviceRow.Item("Title")
                txtMapConnection.Text = serviceRow.Item("MapConnection")
                cboServer.SelectedValue = serviceRow.Item("MapServerID")
                dtpReferenceDate.Value = Date.Parse(serviceRow.Item("ReferenceDate"))
                txtNorth.Text = serviceRow.Item("NorthExtent")
                txtEast.Text = serviceRow.Item("EastExtent")
                txtSouth.Text = serviceRow.Item("SouthExtent")
                txtWest.Text = serviceRow.Item("WestExtent")
                txtTopicCategory.Text = serviceRow.Item("TopicCategory")
                txtAbstract.Text = serviceRow.Item("Abstract")

                cboMetadataContact.SelectedValue = serviceRow.Item("MetadataContactID")
                If serviceRow.Item("DatasetContactID") = "" Then
                    cboDatasetContact.SelectedValue = -1
                Else
                    cboDatasetContact.SelectedValue = serviceRow.Item("DatasetContactID")
                End If
                txtSpatialResolution.Text = serviceRow.Item("SpatialResolution")
                txtDistributionFormat.Text = serviceRow.Item("DistributionFormat")
                txtSpatialRepresentationType.Text = serviceRow.Item("SpatialRepresentationType")
                txtReferenceSystem.Text = serviceRow.Item("SpatialReferenceSystem")
                txtLineageStatement.Text = serviceRow.Item("LineageStatement")
                txtOnlineResource.Text = serviceRow.Item("OnlineResource")

                Dim table As DataTable = serviceCommit.GetMetadata(mapServiceID)
                For Each row As DataRow In table.Rows
                    Dim i As Integer = dgvMeta.Rows.Add()
                    dgvMeta.Rows(i).Cells("Title").Value = row.Item("Title")
                    dgvMeta.Rows(i).Cells("Content").Value = row.Item("Content")
                Next row
            Catch ex As Exception
                Throw New Exception("There was an error getting data about the map.")
            End Try
        Else
            Throw New Exception("There was an error getting data about the Map Service.")
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim imgDisp As New ESRI.ArcGIS.ADF.ArcGISServer.ImageDisplay
        'imgDisp.ImageHeight = picMap.Height
        'imgDisp.ImageWidth = picMap.Width
        'imgDisp.ImageDPI = 96

        'Dim imgDesc As New ESRI.ArcGIS.ADF.ArcGISServer.ImageDescription
        'imgDesc.ImageDisplay = imgDisp
        'imgDesc.ImageType = imgType

        'Dim mapImg As ESRI.ArcGIS.ADF.ArcGISServer.MapImage = mapServer.ExportMapImage(mapDesc, imgDesc)
        'Dim webReq As System.Net.HttpWebRequest = System.Net.WebRequest.Create(mapImg.ImageURL)
        'Dim webResp As System.Net.HttpWebResponse = webReq.GetResponse
        'Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(webResp.GetResponseStream())
        'picMap.Image = img
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If isValid() Then
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
    Private Function isValid() As Boolean
        If (txtTitle.Text = "") Or (txtMapConnection.Text = "") Or (cboServer.SelectedValue Is Nothing) Or _
        (dtpReferenceDate.Text = "") Or (dtpReferenceDate.Value = Nothing) Or _
        (txtNorth.Text = "") Or (txtSouth.Text = "") Or (txtEast.Text = "") Or (txtWest.Text = "") Or _
        (txtTopicCategory.Text = "") Or (txtAbstract.Text = "") Or (cboMetadataContact.Text = "") Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function CommitChanges() As Boolean
        Dim commit As New IcewaterCommit(IcewaterCommit.TableType.MapServices, m_connection)
        Dim params As New Specialized.NameValueCollection()
        params.Add("Title", txtTitle.Text)
        params.Add("MapConnection", txtMapConnection.Text)
        params.Add("MapServerID", cboServer.SelectedValue)
        params.Add("ReferenceDate", dtpReferenceDate.Value)
        params.Add("NorthExtent", Val(txtNorth.Text))
        params.Add("EastExtent", Val(txtEast.Text))
        params.Add("SouthExtent", Val(txtSouth.Text))
        params.Add("WestExtent", Val(txtWest.Text))
        params.Add("TopicCategory", txtTopicCategory.Text)
        params.Add("Abstract", txtAbstract.Text)
        params.Add("MetadataContactID", cboMetadataContact.SelectedValue)
        If Not ((cboDatasetContact.SelectedItem Is Nothing) OrElse (cboDatasetContact.Text = "") OrElse (cboDatasetContact.SelectedValue < 0)) Then
            params.Add("DatasetContactID", cboDatasetContact.SelectedValue)
        End If
        If Not (txtSpatialResolution.Text = "") Then
            params.Add("SpatialResolution", txtSpatialResolution.Text)
        End If
        If Not (txtDistributionFormat.Text = "") Then
            params.Add("DistributionFormat", txtDistributionFormat.Text)
        End If
        If Not (txtSpatialRepresentationType.Text = "") Then
            params.Add("SpatialRepresentationType", txtSpatialRepresentationType.Text)
        End If
        If Not (txtReferenceSystem.Text = "") Then
            params.Add("SpatialReferenceSystem", txtReferenceSystem.Text)
        End If
        If Not (txtLineageStatement.Text = "") Then
            params.Add("LineageStatement", txtLineageStatement.Text)
        End If
        If Not (txtOnlineResource.Text = "") Then
            params.Add("OnlineResource", txtOnlineResource.Text)
        End If

        Dim id As Integer
        If editing Then
            id = commit.UpdateRow(MapServiceID, params)
        Else
            id = commit.CommitRow(params)
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
            If (commit.CommitMetadata(id, titles, contents)) Then

                Return True
            Else
#If DEBUG Then
                MsgBox("Unable to commit metadata", , "AddMap_Full.CommitChanges")
#End If
            End If
        Else
#If DEBUG Then
            MsgBox("Bad ID Returned from database", , "AddMap_Full.CommitChanges")
#End If
            Return False
        End If
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
        If MsgBox("Are you sure you wish to delete the selected row?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim rows As DataGridViewSelectedRowCollection = dgvMeta.SelectedRows
            For Each row As DataGridViewRow In rows
                dgvMeta.Rows.Remove(row)
            Next
        End If
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
    Private Sub getMapServerList()
        Try
            Dim MapServerAdapter As New SqlClient.SqlDataAdapter("SELECT MapServerID, MapServerName FROM MapServers", m_connection)
            Dim mapServers As New DataTable
            MapServerAdapter.Fill(mapServers)

            cboServer.DataSource = New BindingSource(mapServers, Nothing)
            cboServer.DisplayMember = "MapServerName"
            cboServer.ValueMember = "MapServerID"
        Catch ex As Exception
            MsgBox("")
        End Try
    End Sub

    Private Sub addMetadataContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMetadataContact.Click
        Dim diag As New AddContact(m_connection)
        If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            getContactList()
        End If
    End Sub
    Private Sub addDatasetContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDatasetContact.Click
        Dim diag As New AddContact(m_connection)
        If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            getContactList()
        End If
    End Sub
    Private Sub btnAddMapServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMapServer.Click
        Dim diag As New AddMapServer(m_connection)
        If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            getMapServerList()
        End If
    End Sub
End Class