Class clsSources
    Inherits clsFile

#Region " Database Field Constants "

#Region " Sources "
    'Sources
    Public Const db_tbl_Sources As String = "Sources" 'Table Name
    Public Const db_fld_SourceID As String = "SourceID" 'M Integer: Primary Key -> Unique ID for each Sources entry
    Public Const db_fld_Organization As String = "Organization" 'M String: 255 -> Text name of the source organization
    Public Const db_fld_SourceDescription As String = "SourceDescription" 'M String: MAX -> Full text descriptio of the data source
    Public Const db_fld_SourceLink As String = "SourceLink" 'O String: 500 -> Text hyperlink to additional source information
    Public Const db_fld_ContactName As String = "ContactName" 'M String: 255 -> Name of source contact
    Public Const db_fld_Phone As String = "Phone" 'M String: 255 -> Text phone number for source contact
    Public Const db_fld_Email As String = "Email" 'M String: 255 -> Text email address of source contact  
    Public Const db_fld_Address As String = "Address" 'M String: 255 -> Text address of source contact 
    Public Const db_fld_City As String = "City" 'M String: 255 -> Text city of source contact address
    Public Const db_fld_State As String = "State" 'M String: 255 -> Text state of source contact address
    Public Const db_fld_ZipCode As String = "ZipCode" 'M String: 255 -> Text zip code of source contact address
    Public Const db_fld_Citation As String = "Citation" 'M String: MAX -> Text string that give the correct citation for the source
    Public Const db_fld_MetadataID As String = "MetadataID" 'M Integer -> ID of metadata record associated with the source
#End Region

#Region " ISOMetadata "
    'ISOMetadata
    Public Const db_tbl_ISOMetadata As String = "ISOMetadata"
    Public Const db_fld_ISOMetadataID As String = "MetadataID"
    Public Const db_fld_TopicCategory As String = "TopicCategory"
    Public Const db_fld_Title As String = "Title"
    Public Const db_fld_Abstract As String = "Abstract"
    Public Const db_fld_ProfileVersion As String = "ProfileVersion"
    Public Const db_fld_MetadataLink As String = "MetadataLink"
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'No controlled vocabulary table definitions

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_Sources As String = "sources"
    Public Const file_Sources_Organization As String = "organization"            'R
    Public Const file_Sources_SourceDescription As String = "sourcedescription"  'R
    Public Const file_Sources_SourceLink As String = "sourcelink"                'O
    Public Const file_Sources_ContactName As String = "contactname"              'R
    Public Const file_Sources_Phone As String = "phone"                          'R
    Public Const file_Sources_Email As String = "email"                          'R
    Public Const file_Sources_Address As String = "address"                      'R
    Public Const file_Sources_City As String = "city"                            'R
    Public Const file_Sources_SourceState As String = "sourcestate"              'R
    Public Const file_Sources_Zipcode As String = "zipcode"                      'R
    Public Const file_Sources_Citation As String = "citation"                    'R
    Public Const file_Sources_MetadataID As String = "metadataid"                'R
    'The following are alternatives for MetadataID
    Public Const file_Sources_TopicCategory As String = "topiccategory"          'A
    Public Const file_Sources_Title As String = "title"                          'A
    Public Const file_Sources_Abstract As String = "abstract"                    'A
    Public Const file_Sources_ProfileVersion As String = "profileversion"        'A
    Public Const file_Sources_MetadataLink As String = "metadatalink"            'A
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "Sources"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "Sources"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "Sources"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "Sources"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid as new datatable
        'Declare all of your CVs Here
        Dim ISOMetadata as new datatable
        Dim i As Integer
        Dim fileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            'Load The Table Template Here
            valid = m_Connection.OpenTable(connect, trans, db_tbl_Sources, "SELECT * FROM " & db_tbl_Sources) '& " WHERE " & db_tbl_Sources & "." & db_fld_SourceID & " <> " & db_tbl_Sources & "." & db_fld_SourceID)
            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            'Load all of the CV and other related tables here
            ISOMetadata = m_Connection.OpenTable(connect, trans, db_tbl_ISOMetadata, "SELECT * FROM " & db_tbl_ISOMetadata)

            If (m_ViewTable.Columns.IndexOf(file_Sources_Organization) >= 0) Then
                fileRows = m_ViewTable.Select(file_Sources_Organization & " IS NOT NULL AND " & file_Sources_Organization & " <> ''", file_Sources_Organization & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_Sources_Organization & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_Sources_Organization & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_SourceID And col.ColumnName <> db_fld_SourceLink) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                LogError("Sources should be unique, but not all of the Sources in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this Sources table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required columns
                '----------------
                'SourceID
                tempRow.Item(db_fld_SourceID) = i

                'Organization
                If (m_ViewTable.Columns.IndexOf(file_Sources_Organization) >= 0) Then
                    If (fileRow.Item(file_Sources_Organization).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_Organization), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_Organization) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Organization & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Organization & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_Organization & " column.")
                End If

                'SourceDescription  
                If (m_ViewTable.Columns.IndexOf(file_Sources_SourceDescription) >= 0) Then
                    If (fileRow.Item(file_Sources_SourceDescription).ToString <> "") Then
                        tempRow.Item(db_fld_SourceDescription) = fileRow.Item(file_Sources_SourceDescription)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_SourceDescription & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_SourceDescription & " column.")
                End If

                'ContactName
                If (m_ViewTable.Columns.IndexOf(file_Sources_ContactName) >= 0) Then
                    If ((fileRow.Item(file_Sources_ContactName).ToString <> "")) Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_ContactName), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_ContactName) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_ContactName & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_ContactName & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_ContactName & " column.")
                End If

                'Phone
                If (m_ViewTable.Columns.IndexOf(file_Sources_Phone) >= 0) Then
                    If ((fileRow.Item(file_Sources_Phone).ToString <> "")) Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_Phone), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_Phone) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Phone & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Phone & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_Phone & " column.")
                End If

                'Email
                If (m_ViewTable.Columns.IndexOf(file_Sources_Email) >= 0) Then
                    If ((fileRow.Item(file_Sources_Email).ToString <> "")) Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_Email), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_Email) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Email & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Email & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_Email & " column.")
                End If

                'Address
                If (m_ViewTable.Columns.IndexOf(file_Sources_Address) >= 0) Then
                    If ((fileRow.Item(file_Sources_Address).ToString <> "")) Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_Address), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_Address) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Address & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Address & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_Address & " column.")
                End If

                'City
                If (m_ViewTable.Columns.IndexOf(file_Sources_City) >= 0) Then
                    If ((fileRow.Item(file_Sources_City).ToString <> "")) Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_City), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_City) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_City & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_City & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_City & " column.")
                End If

                'State
                If (m_ViewTable.Columns.IndexOf(file_Sources_SourceState) >= 0) Then
                    If ((fileRow.Item(file_Sources_SourceState).ToString <> "")) Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_SourceState), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_State) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_SourceState & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_SourceState & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_SourceState & " column.")
                End If

                'ZipCode
                If (m_ViewTable.Columns.IndexOf(file_Sources_Zipcode) >= 0) Then
                    If ((fileRow.Item(file_Sources_Zipcode).ToString <> "")) Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_Zipcode), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_ZipCode) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Zipcode & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Zipcode & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_Zipcode & " column.")
                End If

                'Citation
                If (m_ViewTable.Columns.IndexOf(file_Sources_Citation) >= 0) Then
                    If ((fileRow.Item(file_Sources_Citation).ToString <> "")) Then
                        tempRow.Item(db_fld_Citation) = fileRow.Item(file_Sources_Citation)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_Citation & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sources_Citation & " column.")
                End If

                'MetadataID
                If (m_ViewTable.Columns.IndexOf(file_Sources_MetadataID) >= 0) Then
                    If (fileRow.Item(file_Sources_MetadataID).ToString <> "") Then
                        'The m_viewtable contains a MetadataID column with something in it
                        Dim MetaRows() As DataRow = ISOMetadata.Select(db_fld_ISOMetadataID & " = '" & Val(fileRow.Item(file_Sources_MetadataID)) & "'")
                        If (MetaRows.Length > 0) Then
                            tempRow.Item(db_fld_MetadataID) = Val(fileRow.Item(file_Sources_MetadataID))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Sources_MetadataID & " in the ISOMetadata table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sources_MetadataID & " cannot be NULL.")
                    End If
                    'MetadataID was not specified, so see if they specified the alternative columns from the ISOMetadata table
                ElseIf (m_ViewTable.Columns.IndexOf(file_Sources_TopicCategory) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_Sources_Title) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_Sources_Abstract) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_Sources_ProfileVersion) >= 0) Then
                    'Test to make sure there is something in all of the alternative columns
                    If (fileRow.Item(file_Sources_TopicCategory).ToString <> "") AndAlso (fileRow.Item(file_Sources_Title).ToString <> "") AndAlso (fileRow.Item(file_Sources_Abstract).ToString <> "") AndAlso (fileRow.Item(file_Sources_ProfileVersion).ToString <> "") Then
                        'All of the alternative ISOMetadata fields are specified and are not empty so test to make sure a corresponding record exists in the ISOMetadata table
                        Dim MetaRows() As DataRow = ISOMetadata.Select(db_fld_TopicCategory & " = '" & Replace(fileRow.Item(file_Sources_TopicCategory), "'", "''") & "' AND " & db_fld_Title & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_Title), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_Abstract & " = '" & Replace(fileRow.Item(file_Sources_Abstract), "'", "''") & "' AND " & db_fld_ProfileVersion & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sources_ProfileVersion), "[\t\r\v\f\n]", ""), "'", "''") & "'")
                        If (MetaRows.Length > 0) Then
                            tempRow.Item(db_fld_MetadataID) = Val(MetaRows(MetaRows.Length - 1).Item(db_fld_MetadataID))
                        Else
                            'There is no record in the ISOMetadata table that matches the information that they have given
                            'Throw New Exception("ROW # " & (i+1) & ": " & "Cannot find an associated metadata record in the ISOMetadata table for the information given.")
                        End If
                    End If
                Else
                    'One or more of the alternative fields are missing
                    Throw New Exception("You must specify either a valid MetadataID or all of the alternative columns from the ISOMetadata table.")
                End If

                'Optional fields
                '---------------
                'SourceLink
                If (m_ViewTable.Columns.IndexOf(file_Sources_SourceLink) >= 0) AndAlso ((fileRow.Item(file_Sources_SourceLink).ToString <> "")) Then
                    tempRow.Item(db_fld_SourceLink) = fileRow.Item(file_Sources_SourceLink)
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
            'Log ERROR
            LogError(ex)
            If Not (valid Is Nothing) Then
                valid.Clear()
            End If
            If Not (ISOMetadata Is Nothing) Then
                ISOMetadata.Clear()
            End If
            Throw New ExitError("Sources.ValidateTable(connect, trans)")
        End Try
        Return New DataTable("ERROR")
    End Function

    Public Overrides Function CommitTable() As clsTableCount
        'Dim scope As New Transactions.TransactionScope
        Dim count As Integer = 0
        Dim otherCount As Integer = 0
        Dim tc As New clsTableCount
        tc.Add(db_tbl_ISOMetadata, count)


        Dim connect As New System.Data.SqlClient.SqlConnection(m_Connection.ConnectionString)
        connect.Open()
        Dim trans As SqlClient.SqlTransaction = connect.BeginTransaction(Data.IsolationLevel.ReadCommitted, "this is a test")

        Try
            If (m_ViewTable.Columns.IndexOf(db_fld_TopicCategory) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_Title) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_Abstract) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_ProfileVersion) >= 0) Then
                LogUpdate("Finding New ISOMetadata")
                Dim newMetaData As New clsISOMetadata(m_Connection, m_ViewTable)
                tc.AddTable(newMetaData.CommitTable(connect, trans))
                count = tc(db_tbl_ISOMetadata)
                If (count > 0) Then
                    otherCount += count
                    LogUpdate(count & " rows committed to ISOMetadata")
                End If
            End If

            LogUpdate("Finding New Sources")


            tc.Add(db_tbl_Sources, m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Sources))
            count = tc(db_tbl_Sources)
            otherCount += count
            LogUpdate(count & " rows committed to Sources")
            GC.Collect()
            If (count > 0) AndAlso (otherCount > 0) Then
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
        'Return otherCount
        Return tc
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As clsTableCount
        Dim count As Integer = 0
        Dim tc As New clsTableCount

        If (m_ViewTable.Columns.IndexOf(db_fld_TopicCategory) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_Title) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_Abstract) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_ProfileVersion) >= 0) Then
            LogUpdate("Finding New ISOMetadata")
            Dim newMetaData As New clsISOMetadata(m_Connection, m_ViewTable)
            tc.AddTable(newMetaData.CommitTable(connect, trans))
            count = tc(db_tbl_ISOMetadata)
            LogUpdate(count & " rows committed to ISOMetadata")
        End If

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Sources)
        GC.Collect()
        tc.Add(db_tbl_Sources, count)
        'Return count
        Return tc

    End Function
End Class
