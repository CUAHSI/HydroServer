Class clsLabMethods
    Inherits clsFile

#Region " Database Field Constants "

#Region " LabMethods "
    'LabMethods
    Public Const db_tbl_LabMethods As String = "LabMethods" 'Table Name
    Public Const db_fld_LabMethodID As String = "LabMethodID" 'M Integer: Primary Key -> Unique ID for each LabMethods entry
    Public Const db_fld_LabName As String = "LabName" 'M String: 255 -> Name of the laboratory
    Public Const db_fld_LabOrganization As String = "LabOrganization" 'M String: 255 -> Name of the organization that runs the laboratory
    Public Const db_fld_LabMethodName As String = "LabMethodName" 'M String: 255 -> Name of the laboratory method
    Public Const db_fld_LabMethodDescription As String = "LabMethodDescription" 'M String: MAX -> Description of of the laboratory method
    Public Const db_fld_LabMethodLink As String = "LabMethodLink" 'O String: 500 -> Text field holding hyperlink to additional method information
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'No controlled vocabulary table definitions

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_LabMethods As String = "labmethods"
    Public Const file_LabMethods_LabName As String = "labname"                              'R
    Public Const file_LabMethods_LabOrganization As String = "laborganization"              'R
    Public Const file_LabMethods_LabMethodName As String = "labmethodname"                  'R
    Public Const file_LabMethods_LabMethodDescription As String = "labmethoddescription"    'R
    Public Const file_LabMethods_LabMethodLink As String = "labmethodlink"                  'O
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "LabMethods"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "LabMethods"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "LabMethods"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "LabMethods"
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

            valid = m_Connection.OpenTable(connect, trans, db_tbl_LabMethods, "SELECT * FROM " & db_tbl_LabMethods) '& " WHERE " & db_tbl_LabMethods & "." & db_fld_LabMethodID & " <> " & db_tbl_LabMethods & "." & db_fld_LabMethodID)

            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            If (m_ViewTable.Columns.IndexOf(file_LabMethods_LabMethodName) >= 0) Then
                fileRows = m_ViewTable.Select(file_LabMethods_LabMethodName & " IS NOT NULL AND " & file_LabMethods_LabMethodName & " <> ''", file_LabMethods_LabMethodName & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_LabMethods_LabMethodName & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_LabMethods_LabMethodName & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_LabMethodID And col.ColumnName <> db_fld_LabMethodLink) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                LogError("LabMethods should be unique, but not all of the LabMethods in your database are unique.<br>Duplicate rows will be allowed for updates into this LabMethods table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required fields
                '---------------
                'LabMethodID
                tempRow.Item(db_fld_LabMethodID) = i '+ maxID

                'LabName
                If (m_ViewTable.Columns.IndexOf(file_LabMethods_LabName) >= 0) Then
                    If (fileRow.Item(file_LabMethods_LabName).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_LabMethods_LabName), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_LabName) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_LabMethods_LabName & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_LabMethods_LabName & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_LabMethods_LabName & " column.")
                End If

                'LabOrganization
                If (m_ViewTable.Columns.IndexOf(file_LabMethods_LabOrganization) >= 0) Then
                    If (fileRow.Item(file_LabMethods_LabOrganization).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_LabMethods_LabOrganization), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_LabOrganization) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_LabMethods_LabOrganization & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_LabMethods_LabOrganization & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_LabMethods_LabOrganization & " column.")
                End If

                'LabMethodName
                If (m_ViewTable.Columns.IndexOf(file_LabMethods_LabMethodName) >= 0) Then
                    If (fileRow.Item(file_LabMethods_LabMethodName).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_LabMethods_LabMethodName), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_LabMethodName) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_LabMethods_LabMethodName & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_LabMethods_LabMethodName & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_LabMethods_LabMethodName & " column.")
                End If

                'LabMethodDescription
                If (m_ViewTable.Columns.IndexOf(file_LabMethods_LabMethodDescription) >= 0) Then
                    If (fileRow.Item(file_LabMethods_LabMethodDescription).ToString <> "") Then
                        tempRow.Item(db_fld_LabMethodDescription) = fileRow.Item(file_LabMethods_LabMethodDescription)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_LabMethods_LabMethodDescription & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_LabMethods_LabMethodDescription & " column.")
                End If

                'Optional fields
                '---------------
                'LabMethodLink
                If (m_ViewTable.Columns.IndexOf(file_LabMethods_LabMethodLink) >= 0) AndAlso (fileRow.Item(file_LabMethods_LabMethodLink).ToString <> "") Then
                    tempRow.Item(db_fld_LabMethodLink) = fileRow.Item(file_LabMethods_LabMethodLink)
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
            Throw New ExitError("LabeMethods.ValidateTable(connect, trans)<br> " & ex.Message)
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
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_LabMethods)

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
            Throw New ExitError("Error Committing Samples<br> " & ex.Message)
        End Try
        connect.Close()
        Dim tc As New clsTableCount
        tc.Add(db_tbl_LabMethods, count)
        'Return count
        Return tc
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As clsTableCount
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_LabMethods)
        GC.Collect()

        Dim tc As New clsTableCount
        tc.Add(db_tbl_LabMethods, count)
        'Return count
        Return tc
    End Function
End Class

