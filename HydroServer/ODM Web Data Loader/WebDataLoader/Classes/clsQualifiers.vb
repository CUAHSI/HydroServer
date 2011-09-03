Class clsQualifiers
    Inherits clsFile

#Region " Database Field Constants "

#Region " Qualifiers "
    'GroupDescriptions
    Public Const db_tbl_Qualifiers As String = "Qualifiers" 'Table Name
    Public Const db_fld_QualifierID As String = "QualifierID" 'M Integer: Primary Key -> Unique ID for each data qualifier
    Public Const db_fld_QualifierCode As String = "QualifierCode" 'O String: 50 -> Text code for qualifier
    Public Const db_fld_QualifierDescription As String = "QualifierDescription" 'M String: MAX -> Description of data qualifier
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'No controlled vocabulary table definitions

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_Qualifiers As String = "qualifiers"
    Public Const file_Qualifiers_QualifierCode As String = "qualifiercode"                  'O
    Public Const file_Qualifiers_QualifierDescription As String = "qualifierdescription"    'R
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "Qualifiers"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "Qualifiers"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "Qualifiers"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "Qualifiers"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid As New datatable
        Dim i As Integer
        Dim fileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            valid = m_Connection.OpenTable(connect, trans, db_tbl_Qualifiers, "SELECT * FROM " & db_tbl_Qualifiers) '& " WHERE " & db_tbl_Qualifiers & "." & db_fld_QualifierID & " <> " & db_tbl_Qualifiers & "." & db_fld_QualifierID)

            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            If (m_ViewTable.Columns.IndexOf(file_Qualifiers_QualifierDescription) >= 0) Then
                fileRows = m_ViewTable.Select(file_Qualifiers_QualifierDescription & " IS NOT NULL AND " & file_Qualifiers_QualifierDescription & " <> ''", file_Qualifiers_QualifierDescription & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_Qualifiers_QualifierDescription & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_Qualifiers_QualifierDescription & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_QualifierID) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                'LogError("Qualifiers should be unique, but not all of the Qualifiers in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this Qualifiers table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required fields
                '---------------
                'QualifierID
                tempRow.Item(db_fld_QualifierID) = i '+ maxID

                'QualifierDescription
                If (m_ViewTable.Columns.IndexOf(file_Qualifiers_QualifierDescription) >= 0) Then
                    If (fileRow.Item(file_Qualifiers_QualifierDescription).ToString <> "") Then
                        tempRow.Item(db_fld_QualifierDescription) = fileRow.Item(file_Qualifiers_QualifierDescription)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Qualifiers_QualifierDescription & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_Qualifiers_QualifierDescription & " column.")
                End If

                'Optional fields
                '---------------
                'QualifierCode
                If (m_ViewTable.Columns.IndexOf(file_Qualifiers_QualifierCode) >= 0) AndAlso (fileRow.Item(file_Qualifiers_QualifierCode).ToString <> "") Then
                    Dim temp As String
                    temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Qualifiers_QualifierCode), "[\040]", "_")
                    temp = System.Text.RegularExpressions.Regex.Replace(temp, "[\s]", "")

                    If System.Text.RegularExpressions.Regex.Matches(temp, "[\s]").Count() = 0 Then
                        tempRow.Item(db_fld_QualifierCode) = temp
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Qualifiers_QualifierCode & " contains invalid characters.")
                    End If
                End If

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
            'LogError(ex)
            If Not (valid Is Nothing) Then
                valid.Clear()
            End If
            Throw New ExitError("Qualifiers.ValidateTable(connect, trans)<br> " & ex.Message)
        End Try
        Return New DataTable("ERROR")
    End Function

    Public Overrides Function CommitTable() As clsTableCount
        'Dim scope As New Transactions.TransactionScope
        Dim count As Integer = 0

        'Using scope
        Dim connect As New System.Data.SqlClient.SqlConnection(m_Connection.ConnectionString)
        connect.Open()
        Dim trans As SqlClient.SqlTransaction = connect.BeginTransaction(Data.IsolationLevel.ReadCommitted, "this is a test")
        Try
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Qualifiers)

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
            'LogError(ex)
#If DEBUG Then
            MsgBox("Trans.rollback")
#End If
            trans.Rollback()
            Throw New ExitError("Error Committing Samples<br> " & ex.Message)
        End Try
        connect.Close()
        Dim tc As New clsTableCount
        tc.Add(db_tbl_Qualifiers, count)
        'Return count
        Return tc
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As clsTableCount
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Qualifiers)
        GC.Collect()

        Dim tc As New clsTableCount
        tc.Add(db_tbl_Qualifiers, count)
        'Return count
        Return tc
    End Function
End Class
