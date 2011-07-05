Public Class AddMapServer
    Dim icewaterConnection As SqlClient.SqlConnection
    Dim hasDomain As System.Collections.Generic.Dictionary(Of String, Boolean)
    Dim hasUsername As System.Collections.Generic.Dictionary(Of String, Boolean)
    Dim connectionSample As System.Collections.Generic.Dictionary(Of String, String)

    Dim m_editing As Boolean = False
    Dim m_id As Integer = -1

    Public Sub New(ByVal icewater As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        icewaterConnection = icewater

        getServerTypes()
    End Sub
    Public Sub New(ByVal icewater As SqlClient.SqlConnection, ByVal id As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        icewaterConnection = icewater

        m_editing = True
        m_id = id

        Dim commit As New IcewaterCommit(IcewaterCommit.TableType.MapServers, icewater)
        Dim params As Specialized.NameValueCollection = commit.GetRowToEdit(id)

        getServerTypes()

        txtServerName.Text = params.Get("MapServerName")
        txtConnectionURL.Text = params.Get("ConnectionURL")
        cboConnectionType.Text = params.Get("MapServerType")
        txtDomain.Text = params.Get("Domain")
        txtUsername.Text = params.Get("Username")
        txtPWD.Text = params.Get("Password")

        Dim table As DataTable = commit.GetMetadata(id)
        For Each row As DataRow In table.Rows
            Dim i As Integer = dgvMeta.Rows.Add()
            dgvMeta.Rows(i).Cells("Title").Value = row.Item("Title")
            dgvMeta.Rows(i).Cells("Content").Value = row.Item("Content")
        Next row

    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim DBCommit As New IcewaterCommit(IcewaterCommit.TableType.MapServers, icewaterConnection)
        Dim params As New Specialized.NameValueCollection

        params.Add("MapServerName", txtServerName.Text)
        params.Add("ConnectionURL", txtConnectionURL.Text)
        params.Add("MapServerType", cboConnectionType.Text)
        If (txtDomain.Text <> "") Then
            params.Add("Domain", txtDomain.Text)
        End If
        If (txtUsername.Text <> "") Then
            params.Add("Username", txtUsername.Text)
        End If
        If (txtPWD.Text <> "") Then
            params.Add("Password", txtPWD.Text)
        End If

        Dim id As Integer
        If m_editing Then
            id = DBCommit.UpdateRow(m_id, params)
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
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Unable to commit metadata")
            End If
        End If


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub getServerTypes()
        hasDomain = New System.Collections.Generic.Dictionary(Of String, Boolean)
        hasUsername = New System.Collections.Generic.Dictionary(Of String, Boolean)
        connectionSample = New System.Collections.Generic.Dictionary(Of String, String)

        Dim adapt As New SqlClient.SqlDataAdapter("SELECT * FROM MapServerTypeCV", icewaterConnection)
        Dim table As New DataTable
        adapt.Fill(table)

        cboConnectionType.Items.Clear()
        For Each row As DataRow In table.Rows
            cboConnectionType.Items.Add(row.Item("MapServerType"))
            hasDomain.Add(row.Item("MapServerType"), row.Item("HasDomain"))
            hasUsername.Add(row.Item("MapServerType"), row.Item("HasUsername"))
            connectionSample.Add(row.Item("MapServerType"), row.Item("SampleServerConnectionURL"))
        Next row
    End Sub

    Private Sub cboConnectionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConnectionType.SelectedIndexChanged
        lblSampleConnection.Text = connectionSample(cboConnectionType.SelectedItem)
        txtDomain.Enabled = hasDomain(cboConnectionType.SelectedItem)
        txtUsername.Enabled = hasUsername(cboConnectionType.SelectedItem)
        txtPWD.Enabled = hasUsername(cboConnectionType.SelectedItem)
    End Sub


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
End Class