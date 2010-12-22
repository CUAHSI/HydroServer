Class clsDerivedFrom
    Inherits clsFile

#Region " Database Field Constants "

#Region " DerivedFrom "
    'DerivedFrom
    Public Const db_tbl_DerivedFrom As String = "DerivedFrom" 'Table Name
    Public Const db_fld_DerivedFromID As String = "DerivedFromID" 'M Integer -> DerivedFromID from the DataValues table
    Public Const db_fld_ValueID As String = "ValueID" 'M Integer -> ValueID from the DataValues table
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'No controlled vocabulary table definitions

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_DerivedFrom As String = "derivedfrom"
    Public Const file_DerivedFrom_DerivedFromID As String = "derivedfromid"         'R
    Public Const file_DerivedFrom_ValueID As String = "valueid"                     'R
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "DerivedFrom"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "DerivedFrom"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "DerivedFrom"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "DerivedFrom"
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

            valid = m_Connection.OpenTable(connect, trans, db_tbl_DerivedFrom, "SELECT * FROM " & db_tbl_DerivedFrom) '& " WHERE " & db_tbl_DerivedFrom & "." & db_fld_DerivedFromID & " <> " & db_tbl_DerivedFrom & "." & db_fld_DerivedFromID)

            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            If (m_ViewTable.Columns.IndexOf(file_DerivedFrom_ValueID) >= 0) Then
                fileRows = m_ViewTable.Select(file_DerivedFrom_ValueID & " IS NOT NULL AND " & file_DerivedFrom_ValueID & " <> ''", file_DerivedFrom_ValueID & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_DerivedFrom_ValueID & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_DerivedFrom_ValueID & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_DerivedFromID) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                LogError("DerivedFrom values should be unique, but not all of the DerivedFrom values in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this DerivedFrom table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required fields
                '---------------
                'DerivedFromID
                If (m_ViewTable.Columns.IndexOf(file_DerivedFrom_DerivedFromID) >= 0) Then
                    If (fileRow.Item(file_DerivedFrom_DerivedFromID).ToString <> "") Then
                        tempRow.Item(db_fld_DerivedFromID) = fileRow.Item(file_DerivedFrom_DerivedFromID)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DerivedFrom_DerivedFromID & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_DerivedFrom_DerivedFromID & " column.")
                End If

                'ValueID
                If (m_ViewTable.Columns.IndexOf(file_DerivedFrom_ValueID) >= 0) Then
                    If (fileRow.Item(file_DerivedFrom_ValueID).ToString <> "") Then
                        tempRow.Item(db_fld_ValueID) = fileRow.Item(file_DerivedFrom_ValueID)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DerivedFrom_ValueID & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_DerivedFrom_ValueID & " column.")
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
            Throw New ExitError("DeriedFrom.ValidateTable(connect, trans)")
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
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_DerivedFrom)

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

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_DerivedFrom)
        GC.Collect()

        Return count
    End Function

End Class
