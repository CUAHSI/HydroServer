Class clsVariables
    Inherits clsFile

#Region " Database Field Constants "

#Region " Variables "

    'Variables
    Public Const db_tbl_Variables As String = "Variables" 'Table Name
    Public Const db_fld_VariableID As String = "VariableID" 'M Integer: Primary Key -> Unique ID for each Variables entry
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

#Region " Units "
    'Units
    Public Const db_tbl_Units As String = "Units" 'Table Name
    Public Const db_fld_UnitsID As String = "UnitsID" 'M Integer: Primary Key -> Unique ID for each Units entry
    Public Const db_fld_UnitsName As String = "UnitsName" 'M String: 255 -> Full name of the units
    Public Const db_fld_UnitsType As String = "UnitsType" 'M String: 255 -> Dimensions of the units
    Public Const db_fld_UnitsAbrv As String = "UnitsAbbreviation" 'M String: 50 -> Abbreviation for the units
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'table names
    Public Const db_tbl_VariableNameCV As String = "VariableNameCV"
    Public Const db_tbl_SpeciationCV As String = "SpeciationCV"
    Public Const db_tbl_ValueTypeCV As String = "ValueTypeCV"
    Public Const db_tbl_SampleMediumCV As String = "SampleMediumCV"
    Public Const db_tbl_GeneralCategoryCV As String = "GeneralCategoryCV"
    Public Const db_tbl_DataTypeCV As String = "DataTypeCV"

    'fields
    Public Const db_fld_CV_Term As String = "Term"
    Public Const db_fld_CV_Definition As String = "Definition"

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_Variables As String = "Variables"
    Public Const file_Variables_VariableCode As String = "VariableCode"             'R
    Public Const file_Variables_VariableName As String = "VariableName"             'R
    Public Const file_Variables_Speciation As String = "Speciation"                 'R
#Region " Variable Units Columns "
    Public Const file_Variables_VariableUnitsID As String = "variableunitsid"       'R
    Public Const file_Variables_VariableUnitsName As String = "variableunitsname"   'A
#End Region
    Public Const file_Variables_SampleMedium As String = "samplemedium"             'R
    Public Const file_Variables_ValueType As String = "valuetype"                   'R
    Public Const file_Variables_IsRegular As String = "isregular"                   'R
    Public Const file_Variables_TimeSupport As String = "timesupport"               'R
#Region " Time Support Units Columns "
    Public Const file_Variables_TimeUnitsID As String = "timeunitsid"               'R
    Public Const file_Variables_TimeUnitsName As String = "timeunitsname"           'A
#End Region
    Public Const file_Variables_DataType As String = "datatype"                     'R
    Public Const file_Variables_GeneralCategory As String = "generalcategory"       'R
    Public Const file_Variables_NoDataValue As String = "nodatavalue"               'R
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "Variables"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "Variables"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_ViewTable)
        MyType = "Variables"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "Variables"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid as new datatable
        'Declare all of your CVs Here
        Dim Units, VariableName, Speciation, SampleMedium, ValueType, DataType, GeneralCategory as new datatable
        Dim i As Integer
        Dim fileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            'Load The Table Template Here
            'Make sure no rows are retrieved.  This isn't a big issue in small tables, but what if we accidentally load a large table?
            valid = m_Connection.OpenTable(connect, trans, db_tbl_Variables, "SELECT * FROM " & db_tbl_Variables) '& " WHERE " & db_tbl_Variables & "." & db_fld_VariableID & " <> " & db_tbl_Variables & "." & db_fld_VariableID)
            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            'Load all of the CV and other related tables here
            Units = m_Connection.OpenTable(connect, trans, db_tbl_Units, "SELECT * FROM " & db_tbl_Units)
            VariableName = m_Connection.OpenTable(connect, trans, db_tbl_VariableNameCV, "SELECT * FROM " & db_tbl_VariableNameCV)
            Speciation = m_Connection.OpenTable(connect, trans, db_tbl_SpeciationCV, "SELECT * FROM " & db_tbl_SpeciationCV)
            SampleMedium = m_Connection.OpenTable(connect, trans, db_tbl_SampleMediumCV, "SELECT * FROM " & db_tbl_SampleMediumCV)
            ValueType = m_Connection.OpenTable(connect, trans, db_tbl_ValueTypeCV, "SELECT * FROM " & db_tbl_ValueTypeCV)
            DataType = m_Connection.OpenTable(connect, trans, db_tbl_DataTypeCV, "SELECT * FROM " & db_tbl_DataTypeCV)
            GeneralCategory = m_Connection.OpenTable(connect, trans, db_tbl_GeneralCategoryCV, "SELECT * FROM " & db_tbl_GeneralCategoryCV)

            If (m_ViewTable.Columns.IndexOf(file_Variables_VariableCode) >= 0) Then
                fileRows = m_ViewTable.Select(file_Variables_VariableCode & " IS NOT NULL AND " & file_Variables_VariableCode & " <> ''", file_Variables_VariableCode & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_Variables_VariableCode & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_Variables_VariableCode & " column.")
            End If

            valid.Constraints.Add("AllUnique", valid.Columns(db_fld_VariableCode), False)

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required columns
                '----------------
                'VariableID
                'This is here because it is needed to add the temporary row to the table.
                tempRow.Item(db_fld_VariableID) = i

                'VariableCode
                If (m_ViewTable.Columns.IndexOf(file_Variables_VariableCode) >= 0) Then
                    If (fileRow.Item(file_Variables_VariableCode).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Variables_VariableCode), "[\040]", "_")
                        temp = System.Text.RegularExpressions.Regex.Replace(temp, "[\,\+]", ".")
                        temp = System.Text.RegularExpressions.Regex.Replace(temp, "[\:\\\/\=]", "-")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[^0-9a-zA-Z\.\-_]").Count() = 0 Then
                            tempRow.Item(db_fld_VariableCode) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_VariableCode & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_VariableCode & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_VariableCode & " column.")
                End If

                'VariableName - CV field
                If (m_ViewTable.Columns.IndexOf(file_Variables_VariableName) >= 0) Then
                    If (fileRow.Item(file_Variables_VariableName).ToString <> "") Then
                        If (VariableName.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_Variables_VariableName), "'", "''") & "'").Length > 0) Then
                            tempRow.Item(db_fld_VariableName) = fileRow.Item(file_Variables_VariableName)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Variables_VariableName & " in the VariableNameCV table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_VariableName & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_VariableName & " column.")
                End If

                'Speciation - CV field
                If (m_ViewTable.Columns.IndexOf(file_Variables_Speciation) >= 0) Then
                    If (fileRow.Item(file_Variables_Speciation).ToString <> "") Then
                        If (Speciation.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_Variables_Speciation), "'", "''") & "'").Length > 0) Then
                            tempRow.Item(db_fld_Speciation) = fileRow.Item(file_Variables_Speciation)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Variables_Speciation & " in the SpeciationCV table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_Speciation & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_Speciation & " column.")
                End If

                'VariableUnitsID - CV field
                If (m_ViewTable.Columns.IndexOf(file_Variables_VariableUnitsID) >= 0) AndAlso (fileRow.Item(file_Variables_VariableUnitsID).ToString <> "") Then
                    Dim UnitRows() As DataRow = Units.Select(db_fld_UnitsID & " = '" & Val(fileRow.Item(file_Variables_VariableUnitsID)) & "'")
                    If (UnitRows.Length > 0) Then
                        tempRow.Item(db_fld_VariableUnitsID) = fileRow.Item(file_Variables_VariableUnitsID)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Variables_VariableUnitsID & " in the Units table.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_Variables_VariableUnitsName) >= 0) AndAlso (fileRow.Item(file_Variables_VariableUnitsName).ToString <> "") Then
                    Dim UnitRows() As DataRow = Units.Select(db_fld_UnitsName & " = '" & Replace(fileRow.Item(file_Variables_VariableUnitsName), "'", "''") & "'")
                    If (UnitRows.Length > 0) Then
                        tempRow.Item(db_fld_VariableUnitsID) = Val(UnitRows(UnitRows.Length - 1).Item(db_fld_UnitsID))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Variables_VariableUnitsName & " in the Units table.")
                    End If
                Else
                    Throw New Exception("Unable to find the Variable Units information.  You must specify either the VariableUnitsID or the VariableUnitsName.")
                End If

                'SampleMedium - CV field
                If (m_ViewTable.Columns.IndexOf(file_Variables_SampleMedium) >= 0) Then
                    If (fileRow.Item(file_Variables_SampleMedium).ToString <> "") Then
                        If (SampleMedium.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_Variables_SampleMedium), "'", "''") & "'").Length > 0) Then
                            tempRow.Item(db_fld_SampleMedium) = fileRow.Item(file_Variables_SampleMedium)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Variables_SampleMedium & " in the SampleMediumCV table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_SampleMedium & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_SampleMedium & " column.")
                End If

                'ValueType - CV field
                If (m_ViewTable.Columns.IndexOf(file_Variables_ValueType) >= 0) Then
                    If (fileRow.Item(file_Variables_ValueType).ToString <> "") Then
                        If (ValueType.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_Variables_ValueType), "'", "''") & "'").Length > 0) Then
                            tempRow.Item(db_fld_ValueType) = fileRow.Item(file_Variables_ValueType)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Variables_ValueType & " in the ValueTypeCV table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_ValueType & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_ValueType & " column.")
                End If

                'IsRegular - boolean
                If (m_ViewTable.Columns.IndexOf(file_Variables_IsRegular) >= 0) Then
                    If (fileRow.Item(file_Variables_IsRegular).ToString <> "") Then
                        If (LCase(fileRow.Item(file_Variables_IsRegular)) = "0") OrElse (LCase(fileRow.Item(file_Variables_IsRegular)) = "false") Then
                            tempRow.Item(db_fld_IsRegular) = False
                        Else 'If (LCase(fileRow.Item(file_Variables_IsRegular)) = "1") OrElse (LCase(fileRow.Item(file_Variables_IsRegular)) = "true") Then
                            tempRow.Item(db_fld_IsRegular) = True
                            'Else
                            'Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_IsRegular & " should be equal to 1 or 'True' for True or 0 or 'False' for False")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_IsRegular & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_IsRegular & " column.")
                End If

                'TimeSupport
                If (m_ViewTable.Columns.IndexOf(file_Variables_TimeSupport) >= 0) Then
                    If (fileRow.Item(file_Variables_TimeSupport).ToString <> "") Then
                        If IsNumeric(fileRow.Item(file_Variables_TimeSupport)) Then
                            tempRow.Item(db_fld_TimeSupport) = Val(fileRow.Item(file_Variables_TimeSupport))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_TimeSupport & " must be numeric.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_TimeSupport & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_TimeSupport & " column.")
                End If

                'TimeUnitsID - CV field
                If (m_ViewTable.Columns.IndexOf(file_Variables_TimeUnitsID) >= 0) AndAlso (fileRow.Item(file_Variables_TimeUnitsID).ToString <> "") Then
                    Dim UnitRows() As DataRow = Units.Select(db_fld_UnitsID & " = '" & Val(fileRow.Item(file_Variables_TimeUnitsID)) & "'")
                    If (UnitRows.Length > 0) Then
                        tempRow.Item(db_fld_TimeUnitsID) = fileRow.Item(file_Variables_TimeUnitsID)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Variables_TimeUnitsID & " in the Units table.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_Variables_TimeUnitsName) >= 0) AndAlso (fileRow.Item(file_Variables_TimeUnitsName).ToString <> "") Then
                    Dim UnitRows() As DataRow = Units.Select(db_fld_UnitsName & " = '" & Replace(fileRow.Item(file_Variables_TimeUnitsName), "'", "''") & "'")
                    If (UnitRows.Length > 0) Then
                        tempRow.Item(db_fld_TimeUnitsID) = Val(UnitRows(UnitRows.Length - 1).Item(db_fld_UnitsID))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Variables_TimeUnitsName & " in the Units table.")
                    End If
                Else
                    Throw New Exception("Unable to find TimeSupportUnits information.  You must specify either the TimeUnitsID or the TimeUnitsName.")
                End If

                'DataType - CV field
                If (m_ViewTable.Columns.IndexOf(file_Variables_DataType) >= 0) Then
                    If (fileRow.Item(file_Variables_DataType).ToString <> "") Then
                        If (DataType.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_Variables_DataType), "'", "''") & "'").Length > 0) Then
                            tempRow.Item(db_fld_DataType) = fileRow.Item(file_Variables_DataType)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Variables_DataType & " in the DataTypeCV table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_DataType & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_DataType & " column.")
                End If

                'GeneralCategory - CV field
                If (m_ViewTable.Columns.IndexOf(file_Variables_GeneralCategory) >= 0) Then
                    If (fileRow.Item(file_Variables_GeneralCategory).ToString <> "") Then
                        If (GeneralCategory.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_Variables_GeneralCategory), "'", "''") & "'").Length > 0) Then
                            tempRow.Item(db_fld_GeneralCategory) = fileRow.Item(file_Variables_GeneralCategory)
                        Else
                            Throw New Exception("Unable to find the specified " & file_Variables_GeneralCategory & " in the GeneralCategoryCV table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_GeneralCategory & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_GeneralCategory & " column.")
                End If

                'NoDataValue
                If (m_ViewTable.Columns.IndexOf(file_Variables_NoDataValue) >= 0) Then
                    If (fileRow.Item(file_Variables_NoDataValue).ToString <> "") Then
                        If (IsNumeric(fileRow.Item(file_Variables_NoDataValue))) Then
                            tempRow.Item(db_fld_NoDataValue) = fileRow.Item(file_Variables_NoDataValue)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_NoDataValue & " must be numeric.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Variables_NoDataValue & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Variables_NoDataValue & " column.")
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
            If Not (VariableName Is Nothing) Then
                VariableName.Clear()
            End If
            If Not (Speciation Is Nothing) Then
                Speciation.Clear()
            End If
            If Not (SampleMedium Is Nothing) Then
                SampleMedium.Clear()
            End If
            If Not (ValueType Is Nothing) Then
                ValueType.Clear()
            End If
            If Not (DataType Is Nothing) Then
                DataType.Clear()
            End If
            If Not (GeneralCategory Is Nothing) Then
                GeneralCategory.Clear()
            End If
            Throw New ExitError("Variables.ValidateTable(connect, trans)")
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
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Variables)

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
        connect.Close()
        Dim tc As New clsTableCount
        tc.Add(db_tbl_Variables, count)
        'Return count
        Return tc
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As clsTableCount
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Variables)
        GC.Collect()

        Dim tc As New clsTableCount
        tc.Add(db_tbl_Variables, count)
        'Return count
        Return tc
    End Function
End Class
