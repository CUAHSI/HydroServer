Option Strict On
Imports DatabaseFunctions
Public Class Variable
    Private mintVariableid As Integer
    Private mstrVariableCode As String
    Private mstrVariableName As String
    Private mstrVariableUnits As String
    Private mstrDatabaseName As String

    Sub New()
        mintVariableid = Nothing
        mstrVariableCode = Nothing
        mstrVariableName = Nothing
        mstrDatabaseName = Nothing
    End Sub

    Sub New(ByRef objVariable As Variable)
        try
        mintVariableid = objVariable.id
        mstrVariableCode = objVariable.Code
        mstrVariableName = objVariable.Name
        mstrVariableUnits = objVariable.Units
            mstrDatabaseName = objVariable.DatabaseName
        Catch ex As Exception
            Throw New Exception("Error Occured in Variable.New" & vbCrLf & ex.Message)
        End Try
    End Sub

    Sub New(ByVal intVariableid As Integer, ByVal strVariableCode As String, ByVal strVariableName As String, ByVal strVariableUnits As String, ByVal strDatabaseName As String)
        Try
            mintVariableid = intVariableid
            mstrVariableCode = strVariableCode
            mstrVariableName = strVariableName
            mstrVariableUnits = strVariableUnits
            mstrDatabaseName = strDatabaseName
        Catch ex As Exception
            Throw New Exception("Error Occured in Variable.New" & vbCrLf & ex.Message)
        End Try
    End Sub

    Sub New(ByVal intVariableid As Integer, ByVal strDatabaseName As String) ', ByVal dtDataSeriesTable As Data.DataTable)
        Try
            mintVariableid = intVariableid
            Dim variableData As Data.DataTable = OpenODMTable("SELECT " & db_tbl_Variables & "." & db_fld_VarCode & ", " & db_tbl_Variables & "." & db_fld_VarName & ", " & db_tbl_Units & "." & db_fld_UnitsAbrv & " AS " & db_expr_VarUnits_Name & " FROM " & db_tbl_Variables & " LEFT JOIN " & db_tbl_Units & " ON " & db_tbl_Variables & "." & db_fld_VarUnitsid & " = " & db_tbl_Units & "." & db_fld_Unitsid & " WHERE " & db_tbl_Variables & "." & db_fld_Varid & " = '" & intVariableid & "'", strDatabaseName)
            If (Not (variableData Is Nothing)) And (variableData.Rows.Count = 1) Then
                mstrVariableCode = variableData.Rows(0).Item(db_fld_VarCode).ToString
                mstrVariableName = variableData.Rows(0).Item(db_fld_VarName).ToString
                mstrVariableUnits = variableData.Rows(0).Item(db_expr_VarUnits_Name).ToString
                mstrDatabaseName = strDatabaseName
            Else
                mstrVariableCode = String.Empty
                mstrVariableName = String.Empty
                mstrVariableUnits = String.Empty
                strDatabaseName = String.Empty
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in Variable.New" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Property id() As Integer
        Get
            Return mintVariableid
        End Get
        Set(ByVal value As Integer)
            mintVariableid = value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return mstrVariableCode
        End Get
        Set(ByVal value As String)
            mstrVariableCode = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return mstrVariableName
        End Get
        Set(ByVal value As String)
            mstrVariableName = value
        End Set
    End Property

    Public Property Units() As String
        Get
            Return mstrVariableUnits
        End Get
        Set(ByVal value As String)
            mstrVariableUnits = value
        End Set
    End Property

    Public Property DatabaseName() As String
        Get
            Return mstrDatabaseName
        End Get
        Set(ByVal value As String)
            mstrDatabaseName = value
        End Set
    End Property
End Class