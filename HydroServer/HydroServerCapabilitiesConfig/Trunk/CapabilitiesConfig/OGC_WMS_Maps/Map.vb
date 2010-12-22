Public Class Map
    'http://columbo.nrlssc.navy.mil/ogcwms/servlet/WMSServlet/Salt_Lake_City_UT_Maps.wms?
    'SERVICE=WMS&REQUEST=GetCapabilities

    'http://columbo.nrlssc.navy.mil/ogcwms/servlet/WMSServlet/Salt_Lake_City_UT_Maps.wms?
    'SERVICE=WMS&
    'REQUEST=GetMap&
    'WIDTH=100&
    'HEIGHT=100&
    'FORMAT=image/jpeg&
    'BBOX=-112.2,40.8,-112.0,40.9&
    'LAYERS=0:0,0:1
    Public Function GetMapImage(ByVal ImageWidth As Integer, ByVal ImageHeight As Integer, ByVal cap As Capabilities) As Image
        Dim img As Image
        Dim url As String = cap.URL & "?SERVICE=WMS&REQUEST=GetMap&WIDTH=" & ImageWidth & "&HEIGHT=" & ImageHeight

        Dim format As String = "&FORMAT=" & cap.GetFormats(0)
        Dim layerNames As Specialized.NameValueCollection = cap.getLayerNames
        Dim layers As String = "&LAYERS=" & layerNames.Keys(0)
        For i As Integer = 0 To layerNames.Count

        Next i
        Dim bbox As String = "&BBOX=-112.2,40.8,-112.0,40.9"

        url &= format & bbox & layers

        Dim theRequest As System.Net.WebRequest = System.Net.WebRequest.Create(url)
        Dim theResponse As System.Net.WebResponse = theRequest.GetResponse()
        img = System.Drawing.Image.FromStream(theResponse.GetResponseStream())


        Return img
    End Function


End Class
