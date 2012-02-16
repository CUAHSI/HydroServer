Public Class clsTableCount
    Inherits Dictionary(Of String, Integer)
    'dictionarybase
    'Inherits System.Collections.ObjectModel.Collection(Of counts) 'Of Dictionary(Of String, Integer))


    Public Sub AddTable(ByRef tc As clsTableCount)
        'For Each c As counts In tc
        'Me.Add(c.TblName, c.NumOfRows)
        For Each c As KeyValuePair(Of String, Integer) In tc
            If (Not ContainsKey(c.Key)) Then
                Me.Add(c.Key, c.Value)
            Else
                Me(c.Key) = Me(c.Key) + c.Value
            End If

        Next
    End Sub
    


End Class

Public Structure counts
    Public TblName As String
    Public NumOfRows As Integer
    Public Sub New(ByVal tableName As String, ByVal numberOfRows As Integer)
        TblName = tableName
        NumOfRows = numberOfRows
    End Sub

End Structure

