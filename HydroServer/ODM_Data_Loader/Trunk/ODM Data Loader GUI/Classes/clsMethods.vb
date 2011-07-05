Class clsMethods
    Inherits clsFile

#Region " Database Field Constants "

#Region " Methods "
    'Methods
    Public Const db_tbl_Methods As String = "Methods" 'Table Name
    Public Const db_fld_MethodID As String = "MethodID" 'M Integer: Primary Key -> Unique ID for each Methods entry
    Public Const db_fld_MethodDescription As String = "MethodDescription" 'M String: MAX -> Description of data collection method
    Public Const db_fld_MethodLink As String = "MethodLink" 'O String: 500 -> Text field holding hyperling to additional method information
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'No controlled vocabulary table definitions

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_Methods As String = "methods"
    Public Const file_Methods_MethodDescription As String = "methoddescription"    'R
    Public Const file_Methods_MethodLink As String = "methodlink"                  'O
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "Methods"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "Methods"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "Methods"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "Methods"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid as new datatable
        Dim i As Integer
        Dim FileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            valid = m_Connection.OpenTable(connect, trans, db_tbl_Methods, "SELECT * FROM " & db_tbl_Methods) '& " WHERE " & db_tbl_Methods & "." & db_fld_MethodID & " <> " & db_tbl_Methods & "." & db_fld_MethodID)

            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            If (m_ViewTable.Columns.IndexOf(file_Methods_MethodDescription) >= 0) Then
                FileRows = m_ViewTable.Select(file_Methods_MethodDescription & " IS NOT NULL AND " & file_Methods_MethodDescription & " <> ''", file_Methods_MethodDescription & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (FileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_Methods_MethodDescription & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_Methods_MethodDescription & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_MethodID And col.ColumnName <> db_fld_MethodLink) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                LogError("Methods should be unique, but not all of the Methods in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this Methods table.")
            End Try

            For i = 0 To (FileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = FileRows(i)
                'Required fields
                '---------------
                'MethodID
                tempRow.Item(db_fld_MethodID) = i '+ maxID

                'MethodDescription
                If (m_ViewTable.Columns.IndexOf(file_Methods_MethodDescription) >= 0) Then
                    If (fileRow.Item(file_Methods_MethodDescription).ToString <> "") Then
                        tempRow.Item(db_fld_MethodDescription) = fileRow.Item(file_Methods_MethodDescription)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Methods_MethodDescription & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_Methods_MethodDescription & " column.")
                End If

                'Optional fields
                '---------------
                'MethodLink
                If (m_ViewTable.Columns.IndexOf(file_Methods_MethodLink) >= 0) AndAlso (fileRow.Item(file_Methods_MethodLink).ToString <> "") Then
                    tempRow.Item(db_fld_MethodLink) = fileRow.Item(file_Methods_MethodLink)
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
            LogError(ex)
            If Not (valid Is Nothing) Then
                valid.Clear()
            End If
            Throw New ExitError("Methods.ValidateTable(connect, trans)")
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
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Methods)

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
        Dim tc As New clsTableCount
        tc.Add(db_tbl_Methods, count)
        'Return count
        Return tc
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As clsTableCount
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Methods)
        GC.Collect()

        Dim tc As New clsTableCount
        tc.Add(db_tbl_Methods, count)
        'Return count
        Return tc
    End Function
End Class
