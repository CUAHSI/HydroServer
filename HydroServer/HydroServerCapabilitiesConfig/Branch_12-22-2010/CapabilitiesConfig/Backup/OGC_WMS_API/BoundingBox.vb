Public Class BoundingBox
    Public Sub New(ByVal minX As Double, ByVal minY As Double, ByVal maxX As Double, ByVal maxY As Double)
        Me.minX = minX
        Me.minY = minY
        Me.maxX = maxX
        Me.maxY = maxY
    End Sub
    Public minX As Double
    Public minY As Double
    Public maxX As Double
    Public maxY As Double

    Public Overrides Function ToString() As String
        Return "BBOX=" & minX & "," & minY & "," & maxX & "," & maxY
    End Function
End Class
