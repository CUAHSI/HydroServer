Class clsGroupDescriptions
    Inherits clsFile

#Region " Database Field Constants "

#Region " GroupDescriptions "
    'GroupDescriptions
    Public Const db_tbl_GroupDescriptions As String = "GroupDescriptions" 'Table Name
    Public Const db_fld_GroupID As String = "GroupID" 'M Integer: Primary Key -> Unique ID for each GroupDescriptions entry
    Public Const db_fld_GroupDescription As String = "GroupDescription" 'O String: MAX -> Description of observation group
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'No controlled vocabulary table definitions

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_GroupDescriptions As String = "groupdescriptions"
    'Even though GroupDescription is optional in the database, it is required in the m_viewtable or else there is nothing to load.
    Public Const file_GroupDescriptions_GroupDescription As String = "groupdescription"    'R
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "GroupDescriptions"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "GroupDescriptions"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_ViewTable)
        MyType = "GroupDescriptions"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "GroupDescriptions"
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

            valid = m_Connection.OpenTable(connect, trans, db_tbl_GroupDescriptions, "SELECT * FROM " & db_tbl_GroupDescriptions) '& " WHERE " & db_tbl_GroupDescriptions & "." & db_fld_GroupID & " <> " & db_tbl_GroupDescriptions & "." & db_fld_GroupID)

            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            If (m_ViewTable.Columns.IndexOf(file_GroupDescriptions_GroupDescription) >= 0) Then
                fileRows = m_ViewTable.Select("", file_GroupDescriptions_GroupDescription & " ASC")
            Else
                Throw New Exception("Unable to find " & file_GroupDescriptions_GroupDescription & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_GroupID) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                'LogError("GroupDescriptions should be unique, but not all of the GroupDescriptions in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this GroupDescriptions table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required fields
                '---------------
                'GroupID
                tempRow.Item(db_fld_GroupID) = i '+ maxID
                'GroupDescription - even though GroupDescription is optional in the database, it is required in the m_viewtable or else there is nothing to load.
                If (m_ViewTable.Columns.IndexOf(file_GroupDescriptions_GroupDescription) >= 0) Then
                    If (fileRow.Item(file_GroupDescriptions_GroupDescription).ToString <> "") Then
                        tempRow.Item(db_fld_GroupDescription) = fileRow.Item(file_GroupDescriptions_GroupDescription)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_GroupDescriptions_GroupDescription & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_GroupDescriptions_GroupDescription & " column.")
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
            'LogError(ex)
            If Not (valid Is Nothing) Then
                valid.Clear()
            End If
            Throw New ExitError("GroupDescriptions.ValidateTable(connect, trans)<br> " & ex.Message)
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
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_GroupDescriptions)

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
        tc.Add(db_tbl_GroupDescriptions, count)
        'Return count
        Return tc
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As clsTableCount
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_GroupDescriptions)
        GC.Collect()

        Dim tc As New clsTableCount
        tc.Add(db_tbl_GroupDescriptions, count)
        'Return count
        Return tc
    End Function
End Class
