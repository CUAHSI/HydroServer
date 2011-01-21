Class clsISOMetadata
    Inherits clsFile

#Region " Database Field Constants "

#Region " ISOMetadata "
    'ISO Metadata
    Public Const db_tbl_ISOMetadata As String = "ISOMetadata" 'Table Name
    Public Const db_fld_MetadataID As String = "MetadataID" 'M Integer: Primary Key -> Unique ID for each ISOMetadata entry
    Public Const db_fld_TopicCategory As String = "TopicCategory" 'M String: 255 -> Topic category associated with the metadata entry
    Public Const db_fld_Title As String = "Title" 'M String: 255 -> Title for the metadata entry
    Public Const db_fld_Abstract As String = "Abstract" 'M String: 255 -> Abstract for the metadata entry
    Public Const db_fld_ProfileVersion As String = "ProfileVersion" 'M String: MAX -> Profile version for the metadata entry
    Public Const db_fld_MetadataLink As String = "MetadataLink" 'O String: 500 -> Text field holding hyperlink to additional metadata information
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'table names
    Public Const db_tbl_TopicCategoryCV As String = "TopicCategoryCV"

    'fields
    Public Const db_fld_CV_Term As String = "Term"
    Public Const db_fld_CV_Definition As String = "Definition"

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_ISOMetadata As String = "labmethods"
    Public Const file_ISOMetadata_TopicCategory As String = "topiccategory"     'R
    Public Const file_ISOMetadata_Title As String = "title"                     'R
    Public Const file_ISOMetadata_Abstract As String = "abstract"               'R
    Public Const file_ISOMetadata_ProfileVersion As String = "profileversion"   'R
    Public Const file_ISOMetadata_MetadataLink As String = "metadatalink"       'O
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "ISOMetadata"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "ISOMetadata"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "ISOMetadata"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "ISOMetadata"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid as new datatable
        Dim TopicCategory as new datatable
        Dim i As Integer
        Dim fileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            valid = m_Connection.OpenTable(connect, trans, db_tbl_ISOMetadata, "SELECT * FROM " & db_tbl_ISOMetadata) '& " WHERE " & db_tbl_ISOMetadata & "." & db_fld_MetadataID & " <> " & db_tbl_ISOMetadata & "." & db_fld_MetadataID)

            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            'Load all of the CV and other related tables here
            TopicCategory = m_Connection.OpenTable(connect, trans, db_tbl_TopicCategoryCV, "SELECT * FROM " & db_tbl_TopicCategoryCV)

            If (m_ViewTable.Columns.IndexOf(file_ISOMetadata_Title) >= 0) Then
                fileRows = m_ViewTable.Select(file_ISOMetadata_Title & " IS NOT NULL AND " & file_ISOMetadata_Title & " <> ''", file_ISOMetadata_Title & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_ISOMetadata_Title & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_ISOMetadata_Title & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_MetadataID) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                'LogError("ISOMetadata should be unique, but not all of the ISOMetadata in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this ISOMetadata table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)

                'Required fields
                '---------------
                'MetadataID
                tempRow.Item(db_fld_MetadataID) = i '+ maxID

                'TopicCategory - this is a CV field
                If (m_ViewTable.Columns.IndexOf(file_ISOMetadata_TopicCategory) >= 0) Then
                    If (fileRow.Item(file_ISOMetadata_TopicCategory).ToString <> "") Then
                        If (TopicCategory.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_ISOMetadata_TopicCategory), "'", "''") & "'").Length > 0) Then
                            tempRow.Item(db_fld_TopicCategory) = fileRow.Item(file_ISOMetadata_TopicCategory)
                        Else
                            Throw New Exception("Unable to find specified " & file_ISOMetadata_TopicCategory & " in the TopicCategoryCV table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_ISOMetadata_TopicCategory & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_ISOMetadata_TopicCategory & " column.")
                End If

                'Title
                If (m_ViewTable.Columns.IndexOf(file_ISOMetadata_Title) >= 0) Then
                    If (fileRow.Item(file_ISOMetadata_Title).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_ISOMetadata_Title), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_Title) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_ISOMetadata_Title & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_ISOMetadata_Title & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_ISOMetadata_Title & " column.")
                End If

                'Abstract
                If (m_ViewTable.Columns.IndexOf(file_ISOMetadata_Abstract) >= 0) Then
                    If (fileRow.Item(file_ISOMetadata_Abstract).ToString <> "") Then
                        tempRow.Item(db_fld_Abstract) = fileRow.Item(file_ISOMetadata_Abstract)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_ISOMetadata_Abstract & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_ISOMetadata_Abstract & " column.")
                End If

                'ProfileVersion
                If (m_ViewTable.Columns.IndexOf(file_ISOMetadata_ProfileVersion) >= 0) Then
                    If (fileRow.Item(file_ISOMetadata_ProfileVersion).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_ISOMetadata_ProfileVersion), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_ProfileVersion) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_ISOMetadata_ProfileVersion & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_ISOMetadata_ProfileVersion & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find " & file_ISOMetadata_ProfileVersion & " column.")
                End If

                'Optional fields
                '---------------
                'MetadataLink
                If (m_ViewTable.Columns.IndexOf(file_ISOMetadata_MetadataLink) >= 0) AndAlso (fileRow.Item(file_ISOMetadata_MetadataLink).ToString <> "") Then
                    tempRow.Item(db_fld_MetadataLink) = fileRow.Item(file_ISOMetadata_MetadataLink)
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
            If Not (TopicCategory Is Nothing) Then
                TopicCategory.Clear()
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
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_ISOMetadata)

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

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_ISOMetadata)
        GC.Collect()

        Return count
    End Function
End Class

