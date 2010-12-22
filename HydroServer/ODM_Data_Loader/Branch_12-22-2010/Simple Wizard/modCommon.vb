Module modCommon
    Public CommandLine As Boolean = False

    Public Declare Function AttachConsole Lib "kernel32.dll" (ByVal dwProcessId As Int32) As Boolean
    Public Declare Function FreeConsole Lib "kernel32.dll" () As Boolean

#Region " Error Reporting Functionality "

    Public Sub ShowError(ByVal errorMessage As String)
        'Displays an error message to the user with the name of the function where the error occured and the error message
        'Inputs:  funcName -> the name of the function where the error occurred
        '         errorMessage -> the message to display
        'Outputs: Displays a messagebox to the user

        'show the error message
        MsgBox(errorMessage, , "ODM Data Loader Error")
    End Sub

    Public Sub ShowError(ByVal errorMessage As String, ByVal err As Exception)
        'Displays an error message to the user with the name of the function where the error occured and the error message
        'Inputs:  funcName -> the name of the function where the error occurred
        '         errorMessage -> the message to display
        'Outputs: Displays a messagebox to the user

        'show the error message
        MsgBox(errorMessage & vbCrLf & "Error in " & err.Source & vbCrLf & vbCrLf & err.Message, , "ODM Data Loader Error")
    End Sub

#End Region

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

End Module
