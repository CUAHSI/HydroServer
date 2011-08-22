Module modCommon
    Public CommandLine As Boolean = False

    Public Declare Function AttachConsole Lib "kernel32.dll" (ByVal dwProcessId As Int32) As Boolean
    Public Declare Function FreeConsole Lib "kernel32.dll" () As Boolean

#Region " Error Reporting Functionality "
    Public writer As System.IO.StreamWriter
    'Public path As String = System.IO.Path.GetDirectoryName(System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath)
    'move config file out of the programfiles directory
    Public dirPath As String = Split(System.IO.Path.GetDirectoryName(System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath), "ODMLoader", , CompareMethod.Text)(0) & "DataLoader\1.1.5.1"
    Public LogPath As String = dirPath & "\" & "log.txt"


    'Console.WriteLine("Local user config path: {0}", config.FilePath);

    Public Sub LogError(ByVal message As String, Optional ByVal err As Exception = Nothing)
        'Writes an error message to the log file.  Including the message from the exception.
        Try
            Console.WriteLine()
            writer.WriteLine("ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Console.WriteLine("ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            writer.WriteLine(message)
            Console.WriteLine(message)
            If Not (err Is Nothing) Then
                writer.WriteLine("Error Message: " & err.Message)
                Console.WriteLine("Error Message: " & err.Message)
#If DEBUG Then
                writer.WriteLine("Stack Trace: " & err.StackTrace) 'Testing Only!
                Console.WriteLine("Stack Trace: " & err.StackTrace) 'Testing Only!
#End If
            End If

            If Not (CommandLine) Then
                Dim text As String
                text = "ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString & vbCrLf & _
                    message
                If Not (err Is Nothing) Then
                    text = text & vbCrLf & "Error Message: " & err.Message
#If DEBUG Then
                    text = text & vbCrLf & "Stack Trace: " & err.StackTrace 'Testing Only!
#End If
                End If
                MsgBox(text, MsgBoxStyle.Critical, "Error!")
            End If
            writer.Flush()
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            MsgBox("An error occurred writing the error message to the log file." & vbCrLf & "Error: " & ex.Message & vbCrLf & vbCrLf & "Original Error Message: " & message)
        End Try
    End Sub

    Public Sub LogError(ByVal err As Exception)
        'Writes an error message to the log file.  Including the message from the exception.
        Try
            Console.WriteLine()
            writer.WriteLine("ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Console.WriteLine("ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            If Not (err Is Nothing) Then
                writer.WriteLine(err.Message)
                Console.WriteLine(err.Message)
#If DEBUG Then
                writer.WriteLine("Stack Trace: " & err.StackTrace) 'Testing Only!
                Console.WriteLine("Stack Trace: " & err.StackTrace) 'Testing Only!
#End If
            End If

            If Not (CommandLine) Then
                Dim text As String
                If Not (err Is Nothing) Then
                    text = "ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString & vbCrLf & _
                        err.Message
#If DEBUG Then
                    text = text & vbCrLf & "Stack Trace: " & err.StackTrace 'Testing Only!
#End If
                End If
                MsgBox(text, MsgBoxStyle.Critical, "Error!")
            End If
            writer.Flush()
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            MsgBox("An error occurred writing the error message to the log file." & vbCrLf & "Error: " & ex.Message & vbCrLf & vbCrLf & "Original Error Message: " & err.Message)
        End Try
    End Sub

    Public Sub LogUpdate(ByVal comment As String)
        'Writes messages to the log file with an empty line between each message.
        Try
            'Dim Writer As New System.IO.StreamWriter(LogPath, True)

            'Writer.WriteLine(Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Console.WriteLine()
            writer.WriteLine("Log @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Console.WriteLine("Log @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            writer.WriteLine(comment)
            Console.WriteLine(comment)
            writer.WriteLine()
            'Writer.Close()
            writer.Flush()
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            LogError("Unable to update log file." & vbCrLf & ex.Message, ex)
            MsgBox("An error occurred writing the completion comment to the log file." & vbCrLf & "Error: " & ex.Message & vbCrLf & vbCrLf & "Original Completion Comment: " & comment)
        End Try
    End Sub

    Public Sub ShowUpdate(ByVal _clsTableCount As clsTableCount, Optional ByVal tableName As String = "the database")
        'LogUpdate("The update was completed." & vbCrLf & rows & " rows committed to " & tableName & ".")
        Dim resultstr As New System.Text.StringBuilder

        resultstr.Append(Now.ToLongDateString & " " & Now.ToLongTimeString & vbCrLf & "The update was completed." & vbCrLf)

        For Each c As KeyValuePair(Of String, Integer) In _clsTableCount
            resultstr.AppendLine(c.Value & " rows committed to " & c.Key & " Table")
        Next

        'resultstr.Append(".")

        If Not (CommandLine) Then
            MsgBox(resultstr.ToString, MsgBoxStyle.Information, "Update was successful!")
            'Method 1: commented out because trying to remove any popups-SR
            'MsgBox(Now.ToLongDateString & " " & Now.ToLongTimeString & vbCrLf & "The update was completed." & vbCrLf & rows & " rows committed to " & tableName & ".", MsgBoxStyle.Information, "Update was successful!")
            'Method 2: commented out because giving more data to user- KI
            'frmMain.lblStatus.Text = Now.ToLongDateString & " " & Now.ToLongTimeString & ", The update was completed. " & rows & " rows committed to " & tableName & "."
        End If
    End Sub

#End Region

    'Public Function StringSplit(ByVal delimiter As String, ByVal value As String) As String()
    '    'Splits a string based on a delimiter, but "s mean that it is a string datatype, and can contain the delimiter within it.

    '    Try
    '        Dim temp As String = ""
    '        Dim result(0) As String
    '        Dim isString As Boolean = False
    '        Dim x, y As Integer

    '        For x = 0 To (value.Length - 1)
    '            If ((value(x) = """") Or (value(x) = delimiter)) Then 'If current char = " or delimiter(, or ; or tab) 
    '                If (x < value.Length - 1) AndAlso (value(x) = """") AndAlso (value(x + 1) = """") Then 'If not last char, current char =  " , and next char =  " 
    '                    temp &= """"
    '                ElseIf (x > 0) AndAlso ((value(x - 1) = """") AndAlso (value(x) = """")) Then 'if not first char, current char =  " , and last char =  " 
    '                    temp = temp
    '                ElseIf (Not isString) AndAlso (value(x) = delimiter) Then 'If not currently reading a string value and current char = delimiter(, or ; or tab)
    '                    ReDim Preserve result(y)
    '                    result(y) = temp
    '                    temp = ""
    '                    y += 1
    '                ElseIf (value(x) = """") Then 'If only a single "
    '                    isString = Not isString
    '                Else
    '                    temp &= value(x)
    '                End If
    '            Else
    '                temp &= value(x)
    '            End If
    '        Next x
    '        ReDim Preserve result(y)
    '        result(y) = temp
    '        y += 1

    '        Return result
    '    Catch ExEr As ExitError
    '        Throw ExEr
    '    Catch ex As Exception
    '        LogError("An Error Occured Reading the Comma Delimited Data.", ex)
    '        Return New String() {""}
    '    End Try
    'End Function
    Public Function ProcessLine(ByVal line As String, ByVal delimiter As String) As String()
        Dim str() As String
        If (line <> "") Then
            delimiter = System.Text.RegularExpressions.Regex.Escape(delimiter)
            Dim patt As String = _
                "(?m)^((?("")""(?<quote>)|(?<=(^|" & delimiter & ")))(?<field>(?(quote)(""""|[^""]|""(?!" & delimiter & "))|[^" & delimiter & "])*?)(?(quote)""(?<-quote>))(?($)|" & delimiter & "))+"


            Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(line, patt)

            With m.Groups("field")
                ReDim str(.Captures.Count - 1)
                For i As Integer = 0 To (.Captures.Count - 1)
                    str(i) &= .Captures(i).Value
                Next i
            End With
        End If
        Return str
    End Function

#Region " SelectDistinct "

    Public Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
        Dim lastValues() As Object
        Dim newTable As New DataTable

        If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
            Throw New ArgumentNullException("FieldNames")
        End If

        lastValues = New Object(FieldNames.Length - 1) {}
        newTable = New DataTable(SourceTable.TableName)

        For Each field As String In FieldNames
            newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
        Next

        For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
            If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
                newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

                setLastValues(lastValues, Row, FieldNames)
            End If
        Next

        Return newTable
    End Function

    Private Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
        Dim areEqual As Boolean = True

        For i As Integer = 0 To fieldNames.Length - 1
            If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
                areEqual = False
                Exit For
            End If
        Next

        Return areEqual
    End Function

    Private Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
        For Each field As String In fieldNames
            newRow(field) = sourceRow(field)
        Next

        Return newRow
    End Function

    Private Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
        For i As Integer = 0 To fieldNames.Length - 1
            lastValues(i) = sourceRow(fieldNames(i))
        Next
    End Sub

#End Region

    Public Class ExitError
        Inherits System.Exception
        Public Sub New()
            MyBase.new()
        End Sub
        Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
    End Class

End Module
