Public Class SelectDatabaseServer
    Dim icewaterConnection As SqlClient.SqlConnection
    Dim usedDatabases As Specialized.StringCollection

    Public Sub New(ByVal icewater As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        icewaterConnection = icewater
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim canceled As Boolean = False
        Dim used As New List(Of String)
        'For Each usedItem As String In txtDBName.Text

        Dim diag As New AddDatabase(icewaterConnection, txtServers.Text, txtDBName.Text, txtUser.Text, txtPWD.Text)
        If diag.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            used.Add(txtDBName.Text)
        Else
            canceled = True
        End If


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