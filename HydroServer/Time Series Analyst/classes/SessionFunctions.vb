Imports System.Data.SqlClient
Public Class SessionFunctions
    Private Shared Function GetList(ByRef objDataRows() As Data.DataRow, ByVal strColumn As String) As String
        Try
            If objDataRows.Length > 0 Then
                Dim objDataRow As Data.DataRow
                Dim arr(objDataRows.Length - 1) As String
                Dim i As Integer = 0

                For Each objDataRow In objDataRows
                    arr(i) = Convert.ToString(objDataRow.Item(strColumn))
                    i += 1
                Next

                Return String.Join(",", arr)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in SessionFunctions.GetList" & vbCrLf & ex.Message)
        End Try
    End Function
End Class
