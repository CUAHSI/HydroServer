Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Database

    Private Shared Function OpenConnection() As SqlConnection
        Dim strConnectionString As String
        strConnectionString = ConfigurationManager.ConnectionStrings("CapabilitiesDatabase").ConnectionString

        Dim objSqlConnection As New SqlConnection(strConnectionString)
        objSqlConnection.Open()

        Return objSqlConnection
    End Function

    Public Shared Function OpenTable(ByVal objSqlCommand As SqlCommand) As Data.DataTable
        Dim objSqlConnection As SqlConnection = OpenConnection()
        Dim objSqlDataAdapter As SqlDataAdapter
        Dim objDataTable As New Data.DataTable

        objSqlCommand.Connection = objSqlConnection
        objSqlDataAdapter = New SqlDataAdapter(objSqlCommand)
        objSqlDataAdapter.Fill(objDataTable)
        objSqlConnection.Close()

        Return objDataTable
    End Function

    Public Shared Function OpenTable(ByVal strSQL As String) As Data.DataTable
        Dim objSqlCommand As SqlCommand
        objSqlCommand = New SqlCommand(strSQL)

        Return OpenTable(objSqlCommand)
    End Function

    Public Shared Sub ExecuteNonQuery(ByVal objSqlCommand As SqlCommand)
        Dim objSqlConnection As SqlConnection = OpenConnection()

        objSqlCommand.Connection = objSqlConnection
        objSqlCommand.ExecuteNonQuery()
        objSqlConnection.Close()
    End Sub

    Public Shared Sub ExecuteNonQuery(ByVal strSQL As String)
        Dim objSqlCommand As SqlCommand

        objSqlCommand = New SqlCommand(strSQL)
        ExecuteNonQuery(objSqlCommand)
    End Sub

End Class
