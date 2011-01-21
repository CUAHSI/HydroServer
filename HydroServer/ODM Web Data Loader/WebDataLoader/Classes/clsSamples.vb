Class clsSamples
    Inherits clsFile

#Region " Database Field Constants "

#Region " Samples "
    'Samples
    Public Const db_tbl_Samples As String = "Samples" 'Table Name
    Public Const db_fld_SampleID As String = "SampleID" 'M Integer: Primary Key -> Unique ID for each Samples entry
    Public Const db_fld_SampleType As String = "SampleType" 'M String: 255 -> Text name of the sample type
    Public Const db_fld_LabSampleCode As String = "LabSampleCode" 'M String: 50 -> Code used by the laboratory to identify the sample
    Public Const db_fld_LabMethodID As String = "LabMethodID" 'M Integer -> ID of the LabMethods record associated with the sample
#End Region

#Region " LabMethods "
    'ISOMetadata
    Public Const db_tbl_LabMethods As String = "LabMethods"
    Public Const db_fld_LMLabMethodID As String = "LabMethodID"
    Public Const db_fld_LabName As String = "LabName"
    Public Const db_fld_LabOrganization As String = "LabOrganization"
    Public Const db_fld_LabMethodName As String = "LabMethodName"
    Public Const db_fld_LabMethodDescription As String = "LabMethodDescription"
    Public Const db_fld_LabMethodLink As String = "LabMethodLink"
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'table names
    Public Const db_tbl_SampleTypeCV As String = "SampleTypeCV"

    'fields
    Public Const db_fld_CV_Term As String = "Term"
    Public Const db_fld_CV_Definition As String = "Definition"

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_Samples As String = "samples"
    Public Const file_Samples_SampleType As String = "sampletype"                            'R
    Public Const file_Samples_LabSampleCode As String = "labsamplecode"                      'R
    Public Const file_Samples_LabMethodID As String = "labmethodid"                          'R
    'The following are alternatives for LabMethodID
    Public Const file_Samples_LabName As String = "labname"                                  'A
    Public Const file_Samples_LabOrganization As String = "laborganization"                  'A
    Public Const file_Samples_LabMethodName As String = "labmethodname"                      'A
    Public Const file_Samples_LabMethodDescription As String = "labmethoddescription"        'A
    Public Const file_Samples_LabMethodLink As String = "labmethodlink"        'A
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "Samples"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "Samples"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "Samples"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "Samples"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid as new datatable
        'Declare all of your CVs Here
        Dim LabMethods, SampleType as new datatable
        Dim i As Integer
        Dim fileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If
            'Load The Table Template Here
            valid = m_Connection.OpenTable(connect, trans, db_tbl_Samples, "SELECT * FROM " & db_tbl_Samples) '& " WHERE " & db_tbl_Samples & "." & db_fld_SampleID & " <> " & db_tbl_Samples & "." & db_fld_SampleID)
            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            'Load all of the CV and other related tables here
            LabMethods = m_Connection.OpenTable(connect, trans, db_tbl_LabMethods, "SELECT * FROM " & db_tbl_LabMethods)
            SampleType = m_Connection.OpenTable(connect, trans, db_tbl_SampleTypeCV, "SELECT * FROM " & db_tbl_SampleTypeCV)

            If (m_ViewTable.Columns.IndexOf(file_Samples_LabSampleCode) >= 0) Then
                fileRows = m_ViewTable.Select(file_Samples_LabSampleCode & " IS NOT NULL AND " & file_Samples_LabSampleCode & " <> ''", file_Samples_LabSampleCode & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_Samples_LabSampleCode & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_Samples_LabSampleCode & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_SampleID) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                'LogError("Samples should be unique, but not all of the Samples in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this Samples table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required columns
                '----------------
                'SampleID
                tempRow.Item(db_fld_SampleID) = i

                'SampleType
                If (m_ViewTable.Columns.IndexOf(file_Samples_SampleType) >= 0) Then
                    If (fileRow.Item(file_Samples_SampleType).ToString <> "") Then
                        If (SampleType.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_Samples_SampleType), "'", "''") & "'").Length > 0) Then
                            tempRow.Item(db_fld_SampleType) = fileRow.Item(file_Samples_SampleType)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Samples_SampleType & " in the SampleTypeCV table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Samples_SampleType & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Samples_SampleType & " column.")
                End If

                'LabSampleCode  
                If (m_ViewTable.Columns.IndexOf(file_Samples_LabSampleCode) >= 0) Then
                    If (fileRow.Item(file_Samples_LabSampleCode).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Samples_LabSampleCode), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_LabSampleCode) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Samples_LabSampleCode & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Samples_LabSampleCode & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Samples_LabSampleCode & " column.")
                End If

                'LabMethodID
                If (m_ViewTable.Columns.IndexOf(file_Samples_LabMethodID) >= 0) Then
                    If (fileRow.Item(file_Samples_LabMethodID).ToString <> "") Then
                        'The m_viewtable contains a LabMethodID column with something in it
                        If (LabMethods.Select(db_fld_LabMethodID & " = '" & Val(fileRow.Item(file_Samples_LabMethodID)) & "'").Length > 0) Then
                            tempRow.Item(db_fld_LabMethodID) = Val(fileRow.Item(file_Samples_LabMethodID))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Samples_LabMethodID & " in the LabMethods table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Samples_LabMethodID & " cannot be NULL.")
                    End If
                    'LabMethodID was not specified, so see if they specified the alternative columns from the LabMethods table
                ElseIf (m_ViewTable.Columns.IndexOf(file_Samples_LabName) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_Samples_LabOrganization) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_Samples_LabMethodName) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_Samples_LabMethodDescription) >= 0) Then
                    'Test to make sure there is something in all of the alternative columns
                    If (fileRow.Item(file_Samples_LabName).ToString <> "") AndAlso (fileRow.Item(file_Samples_LabOrganization).ToString <> "") AndAlso (fileRow.Item(file_Samples_LabMethodName).ToString <> "") AndAlso (fileRow.Item(file_Samples_LabMethodDescription).ToString <> "") Then
                        'All of the alternative LabMethod fields are specified and are not empty so test to make sure a corresponding record exists in the LabMethods table
                        Dim LabMethodRows() As DataRow = LabMethods.Select(db_fld_LabName & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Samples_LabName), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_LabOrganization & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Samples_LabOrganization), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_LabMethodName & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Samples_LabMethodName), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_LabMethodDescription & " = '" & Replace(fileRow.Item(file_Samples_LabMethodDescription), "'", "''") & "'")
                        If (LabMethodRows.Length > 0) Then
                            tempRow.Item(db_fld_LabMethodID) = Val(LabMethodRows(LabMethodRows.Length).Item(db_fld_LabMethodID))
                        Else
                            'There is no record in the LabMethods table that matches the information that they have given
                            'Throw New Exception("ROW # " & (i+1) & ": " & "Cannot find an associated LabMethod record in the LabMethods table for the information given.")
                        End If
                    End If
                Else
                    'One or more of the alternative fields are missing
                    Throw New Exception("You must specify either a valid LabMethodID or all of the alternative columns from the LabMethods table.")
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
            'LogError(ex)
            If Not (valid Is Nothing) Then
                valid.Clear()
            End If
            If Not (LabMethods Is Nothing) Then
                LabMethods.Clear()
            End If
            If Not (SampleType Is Nothing) Then
                SampleType.Clear()
            End If
            Throw New ExitError(ex.Message)
        End Try
        Return New DataTable("ERROR")
    End Function

    Public Overrides Function CommitTable() As Integer
        'Dim scope As New Transactions.TransactionScope
        Dim count As Integer = 0
        Dim othercount As Integer = 0

        Dim connect As New System.Data.SqlClient.SqlConnection(m_Connection.ConnectionString)
        connect.Open()
        Dim trans As SqlClient.SqlTransaction = connect.BeginTransaction(Data.IsolationLevel.ReadCommitted, "this is a test")

        Try
            If (m_ViewTable.Columns.IndexOf(db_fld_LabName) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_LabOrganization) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_LabMethodName) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_LabMethodDescription) >= 0) Then
                'LogUpdate("Finding New LabMethods")
                Dim newLabMethods As New clsLabMethods(m_Connection, m_ViewTable)
                If (count > 0) Then
                    count = newLabMethods.CommitTable(connect, trans)
                    othercount += count
                    'LogUpdate(count & " rows committed to LabMethods")
                End If
            End If

            'LogUpdate("Finding New Samples")

            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Samples)
            othercount += count
            'LogUpdate(count & " rows committed to Samples")

            GC.Collect()
            If (count > 0) AndAlso (othercount > 0) Then

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
        Return othercount
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As Integer
        Dim count As Integer = 0

        If (m_ViewTable.Columns.IndexOf(db_fld_LabName) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_LabOrganization) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_LabMethodName) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(db_fld_LabMethodDescription) >= 0) Then
            'LogUpdate("Finding New LabMethods")
            Dim newLabMethods As New clsLabMethods(m_Connection, m_ViewTable)
            newLabMethods.CommitTable(connect, trans)
            'LogUpdate(count & " rows committed to LabMethods")
        End If

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Samples)

        GC.Collect()

        Return count
    End Function
End Class
