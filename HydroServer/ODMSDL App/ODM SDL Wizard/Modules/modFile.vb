'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..

Module modFile
    'Last Documented 9/4/07

    ''' <summary>
    ''' Loads a comma delimited text file into a datatable.  Can specify which row Column Headers begin on.  Can specify which row Data begins on, must be after column header row.
    ''' </summary>
    ''' <param name="isWeb">Is path a URL?</param>
    ''' <param name="path">The filepath / URL to the data</param>
    ''' <param name="headerRow">Which row the column headers are on (starting at 1, 0 means no headers)</param>
    ''' <param name="dataRow">Which row the data starts on (starting at 1, must be greater than headerRow)</param>
    ''' <param name="delimiter">the delimiter to split the file by</param>
    ''' <returns>Returns the data as a DataTable, each row is a line of text in the file</returns>
    ''' <remarks></remarks>
    Public Function LoadFile(ByVal isWeb As Boolean, ByVal path As String, Optional ByVal headerRow As Integer = 1, Optional ByVal dataRow As Integer = 2, Optional ByVal delimiter As String = ",") As DataTable
        'Loads the specified file from a file path or a web url.  
        Try

            If dataRow <= headerRow Then
                dataRow = headerRow + 1
            End If

            Dim files As String()
            Dim i As Integer
            Dim reader As System.IO.StreamReader
            Dim table As New DataTable
            Dim columns() As String

            If (isWeb) Then
                Dim myWebClient As New Net.WebClient()
                Dim tempPath As String
                tempPath = System.IO.Path.GetTempPath
                'LogUpdate(vbTab & vbTab & "Downloading Data from Website..." & vbCrLf & "From: " & path & vbCrLf & "To: " & tempPath & "DataImport.txt")
                Try
                    myWebClient.DownloadFile(path, tempPath & "DataImport.txt")
                    files = System.IO.Directory.GetFiles(tempPath, "DataImport.txt")
                Catch ex As Exception
                    ShowError(ex)
                    Try
                        myWebClient.DownloadFile(path, tempPath & "DataImport.txt")
                        files = System.IO.Directory.GetFiles(tempPath, "DataImport.txt")
                    Catch err As Exception
                        GC.Collect()
                        ShowError(err)
                        Return New DataTable("ERROR")
                    End Try
                End Try
                'LogUpdate(vbTab & vbTab & "...Finished Downloading Data")
            Else

                files = (System.IO.Directory.GetFiles(Mid(path, 1, path.LastIndexOf("\")), Mid(path, path.LastIndexOf("\") + 2)))
            End If



            Dim file As String
            For Each file In files
                Dim rowCount As Integer = 0
                reader = New System.IO.StreamReader(file)
                For i = 1 To headerRow - 1
                    rowCount += 1
                    Dim temp As String = reader.ReadLine()
                    '#If DEBUG Then
                    '                    MsgBox("Skipping:" & vbCrLf & temp)
                    '#End If
                Next

                If table.Columns.Count = 0 Then
                    If headerRow > 0 Then
                        rowCount += 1
                        Dim nextLine As String = reader.ReadLine
                        '#If DEBUG Then
                        '                        MsgBox("Header Row:" & vbCrLf & nextLine)
                        '#End If
                        If (nextLine <> "") Then
                            columns = ProcessLine(nextLine, delimiter)
                            'columns = StringSplit(delimiter, reader.ReadLine())
                            For i = 0 To (columns.Length - 1)
                                table.Columns.Add(columns(i))
                            Next
                        End If
                    End If
                End If
                While (Not reader.EndOfStream)
                    rowCount += 1
                    Dim nextLine As String = reader.ReadLine()
                    'Dim FileRow As String = reader.ReadLine
                    'If rowCount = 0 Then MsgBox("File Row:" & vbCrLf & FileRow)
                    If (rowCount >= dataRow) Then
                        If nextLine <> "" Then
                            Dim tempRow() As String = ProcessLine(nextLine, delimiter)
                            'Dim tempRow() As String = StringSplit(delimiter, FileRow)

                            While (tempRow.Length > table.Columns.Count)
                                table.Columns.Add()
                            End While
                            table.Rows.Add(tempRow)
                        End If
                    End If
                End While

                reader.Close()
            Next file
            Return table
        Catch ex As System.IO.InvalidDataException
            Select Case delimiter
                Case ","
                    ShowError("File is not in a Comma Delimited Format.")
                Case ControlChars.Tab
                    ShowError("File is not in a Tab Delimited Format.")
                Case Else
                    ShowError("File is not a recognized format.")
            End Select
        Catch ex As System.Net.WebException
            ShowError("Unable to Connect to Web File: " & path & " .")
        Catch ex As Exception
            ShowError(ex)
        End Try
        Return Nothing
    End Function
End Module
