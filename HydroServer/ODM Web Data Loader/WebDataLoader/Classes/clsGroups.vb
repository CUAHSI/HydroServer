Class clsGroups
    Inherits clsFile

#Region " Database Field Constants "

#Region " Groups "
    'Groups
    Public Const db_tbl_Groups As String = "Groups" 'Table Name
    Public Const db_fld_GroupID As String = "GroupID" 'M Integer -> GroupID from the Groups table
    Public Const db_fld_ValueID As String = "ValueID" 'M Integer -> ValueID from the DataValues table
#End Region

#Region " GroupDescriptions "
    'GroupDescriptions
    Public Const db_tbl_GroupDescriptions As String = "GroupDescriptions" 'Table Name
    Public Const db_fld_GDGroupID As String = "GroupID" 'M Integer: Primary Key -> GroupID from the GroupDescriptions table
    Public Const db_fld_GroupDescription As String = "GroupDescription" 'M String: MAX ->GroupdDescription from the GroupDescriptions table
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'No controlled vocabulary table definitions

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_Groups As String = "groups"
    Public Const file_Groups_GroupID As String = "groupid"      'R
    Public Const file_Groups_ValueID As String = "valueid"      'R
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "Groups"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "Groups"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "Groups"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "Groups"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid as new datatable
        Dim GroupDescriptions as new datatable
        Dim i As Integer
        Dim fileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            valid = m_Connection.OpenTable(connect, trans, db_tbl_Groups, "SELECT * FROM " & db_tbl_Groups) '& " WHERE " & db_tbl_Groups & "." & db_fld_GroupID & " <> " & db_tbl_Groups & "." & db_fld_GroupID)

            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            'Load all of the CV and other related tables here
            GroupDescriptions = m_Connection.OpenTable(connect, trans, db_tbl_GroupDescriptions, "SELECT * FROM " & db_tbl_GroupDescriptions)

            If (m_ViewTable.Columns.IndexOf(file_Groups_GroupID) >= 0) Then
                fileRows = m_ViewTable.Select(file_Groups_GroupID & " IS NOT NULL AND " & file_Groups_GroupID & " <> ''", file_Groups_GroupID & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_Groups_GroupID & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_Groups_GroupID & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                Array.Resize(cols, count + 1)
                cols(count) = col
                count += 1
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                'LogError("Groups should be unique, but not all of the Groups in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this Groups table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required fields
                '---------------
                'GroupID
                If (m_ViewTable.Columns.IndexOf(file_Groups_GroupID) >= 0) Then
                    If (m_ViewTable.Columns.IndexOf(file_Groups_GroupID).ToString <> "") Then
                        If (GroupDescriptions.Select(db_fld_GDGroupID & " = '" & Val(fileRow.Item(file_Groups_GroupID)) & "'").Length > 0) Then
                            tempRow.Item(db_fld_GroupID) = Val(fileRow.Item(file_Groups_GroupID))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Groups_GroupID & " in the GroupDescriptions table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Groups_GroupID & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Groups_GroupID & " column.")
                End If

                'ValueID
                If (m_ViewTable.Columns.IndexOf(file_Groups_ValueID) >= 0) Then
                    If (fileRow.Item(file_Groups_ValueID).ToString <> "") Then
                        tempRow.Item(db_fld_ValueID) = fileRow.Item(file_Groups_ValueID)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Groups_ValueID & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Groups_ValueID & " column.")
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
            If Not (GroupDescriptions Is Nothing) Then
                GroupDescriptions.Clear()
            End If
            Throw New ExitError(ex.Message)
        End Try
        Return New DataTable("ERROR")
    End Function

    Public Overrides Function CommitTable() As Integer
        'Dim scope As New Transactions.TransactionScope
        Dim count As Integer = 0

        'Using scope
        Dim connect As New System.Data.SqlClient.SqlConnection(m_Connection.ConnectionString)
        connect.Open()
        Dim trans As SqlClient.SqlTransaction = connect.BeginTransaction(Data.IsolationLevel.ReadCommitted, "this is a test")
        Try
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Groups)

            GC.Collect()
            If (count > 0) Then

                trans.Commit()
            Else
                Throw New Exception("An Error Occurred. Rolling back database transaction.")
            End If
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            'LogError(ex)

            trans.Rollback()
            Throw New ExitError(ex.Message)
        End Try
        connect.Close()
        Return count
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As Integer
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Groups)
        GC.Collect()

        Return count
    End Function
End Class
