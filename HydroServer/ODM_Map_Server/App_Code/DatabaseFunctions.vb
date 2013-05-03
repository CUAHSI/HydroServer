Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class DatabaseFunctions

    Public Shared Function OpenTable(ByVal strDBConnection As String, ByVal strSQL As String) As DataTable
        Dim objSQLConnection As SqlConnection
        Dim objSqlCommand As SqlCommand
        Dim objSqlDataAdapter As SqlDataAdapter
        Dim objDataTable As DataTable

        objDataTable = New DataTable
        objSQLConnection = New SqlConnection(strDBConnection)
        objSQLConnection.Open()
        objSqlCommand = New SqlCommand(strSQL, objSQLConnection)
        objSqlDataAdapter = New SqlDataAdapter(objSqlCommand)
        objSqlDataAdapter.Fill(objDataTable)
        objSQLConnection.Close()

        Return objDataTable
    End Function

End Class
