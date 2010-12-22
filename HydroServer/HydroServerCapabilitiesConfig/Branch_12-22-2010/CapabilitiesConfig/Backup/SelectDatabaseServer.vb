Public Class SelectDatabaseServer
    Dim icewaterConnection As SqlClient.SqlConnection
    Dim usedDatabases As Specialized.StringCollection

    Public Sub New(ByVal icewater As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        icewaterConnection = icewater
    End Sub
    Private Sub SelectDatabaseServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtSQL As New DataTable
        dtSQL = Sql.SqlDataSourceEnumerator.Instance.GetDataSources
        For Each row As DataRow In dtSQL.Rows
            If (row.Item("InstanceName") Is DBNull.Value) Then
                cboServers.Items.Add(row.Item("ServerName"))
            Else
                cboServers.Items.Add(row.Item("ServerName") & "\" & row.Item("InstanceName"))
            End If
        Next
        If cboServers.Items.Contains(My.Computer.Name) Then
            cboServers.Text = "(local)"
        ElseIf cboServers.Items.Contains(My.Computer.Name & "\SQLEXPRESS") Then
            cboServers.Text = "(local)\sqlexpress"
        End If
    End Sub

    Private Sub btnGetList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetList.Click
        Try
            Dim connection As New Microsoft.SqlServer.Management.Common.ServerConnection(cboServers.Text, txtUser.Text, txtPWD.Text)
            Dim server As New Microsoft.SqlServer.Management.Smo.Server(connection)
            lbNewDatabases.Items.Clear()
            server.Initialize()
            usedDatabases = GetUsedDatabases(cboServers.Text)
            For Each db As Microsoft.SqlServer.Management.Smo.Database In server.Databases
                If (db.IsAccessible) Then
                    If (db.IsDbDatareader) Then
                        If db.Tables.Contains("ODMVersion") Then
                            If usedDatabases.Contains(db.Name) Then
                                'DO SOMETHING HERE?
                            Else
                                lbNewDatabases.Items.Add(db.Name)
                                lbNewDatabases.SelectedItems.Add(db.Name)
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function GetUsedDatabases(ByVal server As String) As Specialized.StringCollection
        Dim Databases As New Specialized.StringCollection
        Dim adapter As New SqlClient.SqlDataAdapter("SELECT DatabaseName FROM ODMDatabases WHERE ServerAddress LIKE '" & server & "'", IcewaterConnection)
        Dim Table As New DataTable
        adapter.Fill(Table)

        For Each row As DataRow In Table.Rows
            Databases.Add(row.Item("DatabaseName"))
        Next
        Return Databases
    End Function

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim canceled As Boolean = False
        Dim used As New List(Of String)
        For Each usedItem As String In lbNewDatabases.SelectedItems
            If (Not usedDatabases.Contains(usedItem)) Then
                Dim diag As New AddDatabase(icewaterConnection, cboServers.Text, usedItem, txtUser.Text, txtPWD.Text)
                If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    used.Add(usedItem)
                Else
                    canceled = True
                    Exit For
                End If
            End If
        Next usedItem
        For Each usedMap As String In usedDatabases
            lbNewDatabases.Items.Remove(usedMap)
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