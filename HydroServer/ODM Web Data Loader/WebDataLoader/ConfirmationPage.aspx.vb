Public Partial Class ConfirmationPage
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("TableCount") Is Nothing) Then
            lblFilesSaved.Text = "Nothing was saved to the database"
        Else
            ShowUpdate()
        End If
    End Sub

    Protected Sub btnNewFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewFile.Click
        Session("TableCount") = Nothing
        Response.Redirect("WebDataLoader.aspx")
    End Sub

    Protected Sub btnNewDB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewDB.Click
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub

    Public Sub ShowUpdate(Optional ByVal tableName As String = "the database")
        ''LogUpdate("The update was completed.<br>"& rows & " rows committed to " & tableName & ".<br>")
        Dim resultstr As New System.Text.StringBuilder
        Dim _clsTableCount As clsTableCount = Session("TableCount")
        resultstr.Append(Now.ToLongDateString & " " & Now.ToLongTimeString & "<br> The update was completed. <br>")
        For Each c As KeyValuePair(Of String, Integer) In _clsTableCount
            If c.Value > 0 Then
                resultstr.AppendLine(c.Value & " rows committed to " & c.Key & " Table<br>")
            End If
        Next
        lblFilesSaved.Text = resultstr.ToString()
    End Sub
End Class
