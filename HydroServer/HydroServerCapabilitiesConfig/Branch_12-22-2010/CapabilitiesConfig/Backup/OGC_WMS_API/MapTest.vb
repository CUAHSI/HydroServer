Public Class MapTest

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Dim myMap As New OGC.WMS.Map()
        Dim myCapabilities As New OGC.WMS.Capabilities()

        Dim formats As List(Of String) = myCapabilities.GetFormats()
        Dim LayerNames As System.Collections.Specialized.NameValueCollection = myCapabilities.getLayerNames

        Dim mapBox As New Windows.Forms.PictureBox
        mapImages.Controls.Add(mapBox)
        mapBox.Dock = Windows.Forms.DockStyle.Fill
        mapBox.Image = myMap.GetMapImage(mapBox.Width, mapBox.Height, myCapabilities)
        'MsgBox(LayerNames.Count)
        For Each Name As String In LayerNames.Keys
            Console.WriteLine(Name & vbTab & LayerNames(Name))
        Next Name
    End Sub
End Class