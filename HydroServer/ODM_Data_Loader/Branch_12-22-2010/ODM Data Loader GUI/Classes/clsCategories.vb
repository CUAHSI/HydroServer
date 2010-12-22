''' <summary>
''' Class to read a Categories file and submit it to a database
''' </summary>
''' <remarks></remarks>
Class clsCategories
    Inherits clsFile

#Region " Database Field Constants "

#Region " Categories "
    'Groups
    Public Const db_tbl_Categories As String = "Categories" 'Table Name
    Public Const db_fld_VariableID As String = "VariableID" 'M Integer -> VariableID from the Groups table
    Public Const db_fld_DataValue As String = "DataValue" 'M Double -> DataValue from the DataValues table
    Public Const db_fld_CategoryDescription As String = "CategoryDescription" 'M String: MAX -> Text description of the category value
#End Region

#Region " Variables "
    'Variables
    Public Const db_tbl_Variables As String = "Variables" 'Table Name
    Public Const db_fld_VVariableID As String = "VariableID" 'M Integer: Primary Key -> Unique ID for each Variables entry
    Public Const db_fld_VariableCode As String = "VariableCode" 'M String: 50 -> Code used by the organization that collects the data
    Public Const db_fld_VariableName As String = "VariableName" 'M String: 255 -> CV. Name of the variable that was measured/observed/modeled
    Public Const db_fld_Speciation As String = "Speciation" 'M String: 255 -> CV. Speciation of the variable
    Public Const db_fld_VariableUnitsID As String = "VariableUnitsID" 'M Integer -> Linked to Units.UnitsID
    Public Const db_fld_SampleMedium As String = "SampleMedium" 'M String: 255 -> CV. The medium of the sample
    Public Const db_fld_ValueType As String = "ValueType" 'M String: 255 -> CV. Text value indicating what type of value is being recorded
    Public Const db_fld_IsRegular As String = "IsRegular" 'M Boolean -> Whether the values are from a regularly sampled time series
    Public Const db_fld_TimeSupport As String = "TimeSupport" 'M Double -> Numerical value indicating the temporal footprint over which values are averaged. 
    Public Const db_fld_TimeUnitsID As String = "TimeUnitsID" 'M Integer -> UnitsID of the time support. Linked to Units.UnitsID
    Public Const db_fld_DataType As String = "DataType" 'M String: 255 -> CV. text value that identifies the data as one of several types
    Public Const db_fld_GeneralCategory As String = "GeneralCategory" 'M STring: 255 -> CV. General category of the values
    Public Const db_fld_NoDataValue As String = "NoDataValue" 'M Double -> Numeric value used to encode no data values for this variable
#End Region

#End Region

#Region " File Field Constants "
    Public Const file_Categories As String = "categories"
    Public Const file_Categories_VariableID As String = "variableid"                     'R
    Public Const file_Categories_VariableCode As String = "variablecode"                 'A - alternative for VariableID
    Public Const file_Categories_DataValue As String = "datavalue"                       'R
    Public Const file_Categories_CategoryDescription As String = "categorydescription"   'R
#End Region

    ''' <summary>
    ''' Create a blank categories file with a connection to the database
    ''' </summary>
    ''' <param name="e_Connection">the connection to the database</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "Categories"
    End Sub

    ''' <summary>
    ''' Create a categories file from a local file at the given filepath
    ''' </summary>
    ''' <param name="e_Connection">the connection to the database</param>
    ''' <param name="filePath">the path to the file</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "Categories"
    End Sub

    ''' <summary>
    ''' Create a categories file from a clsFile
    ''' </summary>
    ''' <param name="e_file">The clsFile used to determine the type of file</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_file As clsFile)
        MyBase.new(e_file)
        MyType = "Categories"
    End Sub

    ''' <summary>
    ''' Create a categories file with a connection to the database
    ''' </summary>
    ''' <param name="e_Connection">the connection to the database</param>
    ''' <param name="m_viewtable"></param>
    ''' <param name="e_ThrowFileOnError"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "Categories"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="connect"></param>
    ''' <param name="trans"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid As New DataTable
        Dim Variables As New DataTable
        Dim i As Integer
        Dim FileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            valid = m_Connection.OpenTable(connect, trans, db_tbl_Categories, "SELECT * FROM " & db_tbl_Categories) '& " WHERE " & db_tbl_Categories & "." & db_fld_VariableID & " <> " & db_tbl_Categories & "." & db_fld_VariableID)

            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            'Load all of the CV and other related tables here
            Variables = m_Connection.OpenTable(connect, trans, db_tbl_Variables, "SELECT * FROM " & db_tbl_Variables)

            If (m_ViewTable.Columns.IndexOf(file_Categories_CategoryDescription) >= 0) Then
                FileRows = m_ViewTable.Select(file_Categories_CategoryDescription & " IS NOT NULL AND " & file_Categories_CategoryDescription & " <> ''")
                If (m_ThrowFileOnNulls) Then
                    If (FileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_Categories_CategoryDescription & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_Categories_CategoryDescription & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn = {}
            Dim count As Integer = 0
            For Each col In valid.Columns
                'If (col.ColumnName <> db_fld_CategoryID) Then
                Array.Resize(cols, count + 1)
                cols(count) = col
                count += 1
                'End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                LogError("Categories should be unique, but not all of the Categories in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this Categories table.")
            End Try

            For i = 0 To (FileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = FileRows(i)
                'Required fields
                '---------------
                'VariableID
                If (m_ViewTable.Columns.IndexOf(file_Categories_VariableID) >= 0) AndAlso (LCase(fileRow.Item(file_Categories_VariableID).ToString) <> "null") AndAlso (fileRow.Item(file_Categories_VariableID).ToString <> "") Then
                    If (Variables.Select(db_fld_VVariableID & " = '" & Val(fileRow.Item(file_Categories_VariableID)) & "'").Length > 0) Then
                        tempRow.Item(db_fld_VariableID) = fileRow.Item(file_Categories_VariableID)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Categories_VariableID & " in the Variables table.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_Categories_VariableCode) >= 0) AndAlso (fileRow.Item(file_Categories_VariableCode).ToString <> "") Then
                    Dim VarRows() As DataRow = Variables.Select(db_fld_VariableCode & " = '" & Replace(fileRow.Item(file_Categories_VariableCode), "'", "''") & "'")
                    If (VarRows.Length > 0) Then
                        tempRow.Item(db_fld_VariableID) = Val(VarRows(VarRows.Length - 1).Item(db_fld_VVariableID))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Categories_VariableCode & " in the Variables table.")
                    End If
                Else
                    Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the Variable information.  You must specify either the VariableID or the VariableCode.")
                End If

                'DataValue
                If (m_ViewTable.Columns.IndexOf(file_Categories_DataValue) >= 0) Then
                    If (fileRow.Item(file_Categories_DataValue).ToString <> "") Then
                        tempRow.Item(db_fld_DataValue) = fileRow.Item(file_Categories_DataValue)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Categories_DataValue & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Categories_DataValue & " column.")
                End If

                'CategoryDescription
                If (m_ViewTable.Columns.IndexOf(file_Categories_CategoryDescription) >= 0) Then
                    If (fileRow.Item(file_Categories_CategoryDescription).ToString <> "") Then
                        tempRow.Item(db_fld_CategoryDescription) = fileRow.Item(file_Categories_CategoryDescription)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Categories_CategoryDescription & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Categories_CategoryDescription & " column.")
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
            If Not (Variables Is Nothing) Then
                Variables.Clear()
            End If
            Throw New ExitError("Categories.ValidateTable(connect, trans)")
        End Try
        Return New DataTable("ERROR")
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function CommitTable() As Integer
        'Dim scope As New Transactions.TransactionScope
        Dim count As Integer = 0

        'Using scope
        Dim connect As New System.Data.SqlClient.SqlConnection(m_Connection.ConnectionString)
        connect.Open()
        Dim trans As SqlClient.SqlTransaction = connect.BeginTransaction(Data.IsolationLevel.ReadCommitted, "this is a test")

        Try
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Categories)
            GC.Collect()

            If count > 0 Then
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

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="connect"></param>
    ''' <param name="trans"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As Integer
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Categories)
        GC.Collect()

        Return count
    End Function

End Class
