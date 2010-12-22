Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim temp As New MapServerConnection("http://maps.usu.edu/arcgis/services", "")
        Dim listy As List(Of String) = temp.getMapServices

        ListBox1.Items.Clear()
        For Each mapService As String In listy
            ListBox1.Items.Add(mapService)
        Next mapService
    End Sub
End Class
