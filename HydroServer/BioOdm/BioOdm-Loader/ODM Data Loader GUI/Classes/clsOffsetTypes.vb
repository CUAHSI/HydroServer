Class clsOffsetTypes
    Inherits clsFile

#Region " Database Field Constants "

#Region " OffsetTypes "
    'OffsetTypes
    Public Const db_tbl_OffsetTypes As String = "OffsetTypes" 'Table Name
    Public Const db_fld_OffsetTypeID As String = "OffsetTypeID" 'M Integer: Primary Key -> Unique ID for each offset type
    Public Const db_fld_OffsetUnitsID As String = "OffsetUnitsID" 'M Inteteger -> Linked to UnitsID in Units table
    Public Const db_fld_OffsetDescription As String = "OffsetDescription" 'M String: MAX -> Text description of the offset
#End Region

#Region " Units "
    'Units
    Public Const db_tbl_Units As String = "Units" 'Table Name
    Public Const db_fld_UnitsID As String = "UnitsID" 'M Integer: Primary Key -> Unique ID for each Units entry
    Public Const db_fld_UnitsName As String = "UnitsName" 'M String: 255 -> Full name of the units
    Public Const db_fld_UnitsType As String = "UnitsType" 'M String: 255 -> Dimensions of the units
    Public Const db_fld_UnitsAbrv As String = "UnitsAbbreviation" 'M String: 50 -> Abbreviation for the units
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'No controlled vocabulary tables

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_OffsetTypes As String = "offsettypes"
    Public Const file_OffsetTypes_OffsetUnitsID As String = "offsetunitsid"            'R
    Public Const file_OffsetTypes_OffsetUnitsName As String = "offsetunitsname"        'A - alternative for OffsetUnitsID
    Public Const file_OffsetTypes_OffsetDescription As String = "offsetdescription"    'R
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "OffsetTypes"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "OffsetTypes"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "OffsetTypes"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "OffsetTypes"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid as new datatable
        Dim Units as new datatable
        Dim i As Integer
        Dim fileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            'Load The Table Template Here
            valid = m_Connection.OpenTable(connect, trans, db_tbl_OffsetTypes, "SELECT * FROM " & db_tbl_OffsetTypes) ' & " WHERE " & db_tbl_OffsetTypes & "." & db_fld_OffsetTypeID & " <> " & db_tbl_OffsetTypes & "." & db_fld_OffsetTypeID)
            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            'Load all of the CV and other related tables here
            Units = m_Connection.OpenTable(connect, trans, db_tbl_Units, "SELECT * FROM " & db_tbl_Units)

            If (m_ViewTable.Columns.IndexOf(file_OffsetTypes_OffsetDescription) >= 0) Then
                fileRows = m_ViewTable.Select(file_OffsetTypes_OffsetDescription & " IS NOT NULL AND " & file_OffsetTypes_OffsetDescription & " <> ''", file_OffsetTypes_OffsetDescription & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_OffsetTypes_OffsetDescription & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_OffsetTypes_OffsetDescription & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_OffsetTypeID) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                LogError("OffsetTypes should be unique, but not all of the OffsetTypes in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this OffsetTypes table.")
            End Try

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required columns
                '----------------
                'OffsetTypeID
                tempRow.Item(db_fld_OffsetTypeID) = i

                'OffsetUnitsID
                If (m_ViewTable.Columns.IndexOf(file_OffsetTypes_OffsetUnitsID) >= 0) AndAlso (fileRow.Item(file_OffsetTypes_OffsetUnitsID).ToString <> "") Then
                    If (Units.Select(db_fld_UnitsID & " = '" & Val(fileRow.Item(file_OffsetTypes_OffsetUnitsID)) & "'").Length > 0) Then
                        tempRow.Item(db_fld_OffsetUnitsID) = fileRow.Item(file_OffsetTypes_OffsetUnitsID)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_OffsetTypes_OffsetUnitsID & " in the Units table.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_OffsetTypes_OffsetUnitsName) >= 0) AndAlso (fileRow.Item(file_OffsetTypes_OffsetUnitsName).ToString <> "") Then
                    Dim UnitRows() As DataRow = Units.Select(db_fld_UnitsName & " = '" & Replace(fileRow.Item(file_OffsetTypes_OffsetUnitsName), "'", "''") & "'")
                    If (UnitRows.Length > 0) Then
                        tempRow.Item(db_fld_OffsetUnitsID) = Val(UnitRows(UnitRows.Length - 1).Item(db_fld_UnitsID))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_OffsetTypes_OffsetUnitsName & " in the Units table.")
                    End If
                Else
                    Throw New Exception("Unable to find the Offset Units information.  You must specify either the OffsetUnitsID or the OffsetUnitsName.")
                End If

                'Offset description
                If (m_ViewTable.Columns.IndexOf(file_OffsetTypes_OffsetDescription) >= 0) Then
                    If (fileRow.Item(file_OffsetTypes_OffsetDescription).ToString <> "") Then
                        tempRow.Item(db_fld_OffsetDescription) = fileRow.Item(file_OffsetTypes_OffsetDescription)
                    Else
                        Throw New Exception(file_OffsetTypes_OffsetDescription & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_OffsetTypes_OffsetDescription & " column.")
                End If

                'Optional columns
                '----------------
                'No optional columns

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
            If Not (Units Is Nothing) Then
                Units.Clear()
            End If
            Throw New ExitError("OffsetTypes.ValidateTable(connect, trans)")
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
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_OffsetTypes)

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
        tc.Add(db_tbl_OffsetTypes, count)
        'Return count
        Return tc
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As clsTableCount
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_OffsetTypes)
        GC.Collect()

        Dim tc As New clsTableCount
        tc.Add(db_tbl_OffsetTypes, count)
        'Return count
        Return tc
    End Function
End Class
