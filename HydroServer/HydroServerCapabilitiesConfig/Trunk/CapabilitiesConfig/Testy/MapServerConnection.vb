Public Class MapServerConnection
    Private serverWSDL As New arcgis_Server.Catalog
    Public Sub New(ByVal url As String, ByVal type As String)
        serverWSDL.Url = url
    End Sub

    Public Function getMapServices() As List(Of String)
        Dim mapServices As New List(Of String)
        Dim folders() As String = serverWSDL.GetFolders
        For Each folder As String In folders
            Try
                If folder = "mapserver" Then
                    mapServices.Add(folder)
                Else
                    mapServices.AddRange(getMapServices(folder))
                End If
            Catch ex As Exception

            End Try
        Next folder
        Return mapServices
    End Function

    Private Function getMapServices(ByVal path As String) As List(Of String)
        Dim mapServices As New List(Of String)
        Try
            Dim folderWSDL As New arcgis_Server.Catalog
            folderWSDL.Url = serverWSDL.Url & "/" & path
            Dim folders() As String = folderWSDL.GetFolders
            For Each folder As String In folders

                If folder = "mapserver" Then
                    mapServices.Add(path & "/" & folder)
                Else
                    getMapServices(path & "/" & folder)
                End If
            Next folder
        Catch ex As Exception

        End Try
        Return mapServices
    End Function

End Class
