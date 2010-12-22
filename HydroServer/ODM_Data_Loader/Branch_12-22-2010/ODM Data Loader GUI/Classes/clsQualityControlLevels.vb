Class clsQualityControlLevels
    Inherits clsFile

#Region " Database Field Constants "

#Region " QualityControlLevels "
    'QualityControlLevels
    Public Const db_tbl_QualityControlLevels As String = "QualityControlLevels" 'Table Name
    Public Const db_fld_QualityControlLevelID As String = "QualityControlLevelID" 'M Integer: Primary Key -> Unique ID for each quality control level
    Public Const db_fld_QualityControlLevelCode As String = "QualityControlLevelCode" 'M String: 50 -> Text code for each quality control level
    Public Const db_fld_Definition As String = "Definition" 'M String: 255 -> Definition of quality control level
    Public Const db_fld_Explanation As String = "Explanation" 'M String: MAX -> Explanation of quality control level
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'No controlled vocabulary table definitions

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_QualityControlLevels As String = "qualitycontrollevels"
    Public Const file_QualityControlLevels_QualityControlLevelCode As String = "qualitycontrollevelcode"    'R
    Public Const file_QualityControlLevels_Definition As String = "definition"                              'R
    Public Const file_QualityControlLevels_Explanation As String = "explanation"                            'R
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "QualityControlLevels"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "QualityControlLevels"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "QualityControlLevels"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "QualityControlLevels"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid as new datatable
        Dim i As Integer
        Dim fileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            valid = m_Connection.OpenTable(connect, trans, db_tbl_QualityControlLevels, "SELECT * FROM " & db_tbl_QualityControlLevels) ' & " WHERE " & db_tbl_QualityControlLevels & "." & db_fld_QualityControlLevelID & " <> " & db_tbl_QualityControlLevels & "." & db_fld_QualityControlLevelID)

            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            If (m_ViewTable.Columns.IndexOf(file_QualityControlLevels_Definition) >= 0) Then
                fileRows = m_ViewTable.Select(file_QualityControlLevels_Definition & " IS NOT NULL AND " & file_QualityControlLevels_Definition & " <> ''", file_QualityControlLevels_Definition & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_QualityControlLevels_Definition & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_QualityControlLevels_Definition & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_QualityControlLevelID) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                LogError("QualityControlLevels should be unique, but not all of the QualityControlLevels in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this QualityControlLevels table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required fields
                '---------------
                'QualityControlLevelID
                tempRow.Item(db_fld_QualityControlLevelID) = i '+ maxID

                'QualityControlLevelCode
                If (m_ViewTable.Columns.IndexOf(file_QualityControlLevels_QualityControlLevelCode) >= 0) Then
                    If (fileRow.Item(file_QualityControlLevels_QualityControlLevelCode).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_QualityControlLevels_QualityControlLevelCode), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_QualityControlLevelCode) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_QualityControlLevels_QualityControlLevelCode & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_QualityControlLevels_QualityControlLevelCode & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_QualityControlLevels_QualityControlLevelCode & " column.")
                End If

                'Definition
                If (m_ViewTable.Columns.IndexOf(file_QualityControlLevels_Definition) >= 0) Then
                    If (fileRow.Item(file_QualityControlLevels_Definition).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_QualityControlLevels_Definition), "[\t\r\v\f\n]", "")
                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_Definition) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_QualityControlLevels_Definition & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_QualityControlLevels_Definition & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_QualityControlLevels_Definition & " column.")
                End If

                'Explanation
                If (m_ViewTable.Columns.IndexOf(file_QualityControlLevels_Explanation) >= 0) Then
                    If (fileRow.Item(file_QualityControlLevels_Explanation).ToString <> "") Then
                        tempRow.Item(db_fld_Explanation) = fileRow.Item(file_QualityControlLevels_Explanation)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_QualityControlLevels_Explanation & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_QualityControlLevels_Explanation & " column.")
                End If

                'Optional fields
                '---------------
                'No optional fields

                ''TODO: PUT THIS BACK??
                'If RowExists(tempRow, valid) Then
                '    If (m_ThrowFileOnRepeat) Then
                '        Throw New Exception("Row " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & " already exists in the database.")
                '    End If
                'Else
                '    valid.Rows.Add(tempRow)
                'End If
                Try
                    valid.Rows.Add(tempRow)
                Catch ex As Exception
                    If (m_ThrowFileOnRepeat) Then
                        Throw New Exception("Row " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & " already exists in the database.")
                    End If
                End Try
            Next i

            GC.Collect()
            Return valid
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            'Log: ERROR
            LogError(ex)
            If Not (valid Is Nothing) Then
                valid.Clear()
            End If
            Throw New ExitError("QualityControlLevels.ValidateTable(connect, trans)")
        End Try
        Return New DataTable("ERROR")
    End Function

    Public Overrides Function CommitTable() As Integer
        'Dim scope As New Transactions.TransactionScope
        Dim count As Integer = 0

        'Using scope
        Dim connect As New System.Data.SqlClient.SqlConnection(m_Connection.ConnectionString)
        connect.Open()
        Dim trans As SqlClient.SqlTransaction = connect.BeginTransaction(Data.IsolationLevel.Readcommitted, "this is a test")
        Try
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_QualityControlLevels)

            GC.Collect()
            If (count > 0) Then
#If DEBUG Then
                MsgBox("Trans.commit")
#End If
                trans.Commit()
            Else
                Throw New Exception("An Error Occurred. Rolling back database transaction.")
            End If
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            LogError(ex)
#If DEBUG Then
            MsgBox("Trans.rollback")
#End If
            trans.Rollback()
            Throw New ExitError("Error Committing Samples")
        End Try
        connect.Close()
        Return count
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As Integer
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_QualityControlLevels)
        GC.Collect()

        Return count
    End Function
End Class
