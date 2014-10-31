'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..

''' <summary>
''' Object for storing all nessecary data to create a Database Connection String
''' </summary>
''' <remarks></remarks>
Public Class clsConnectionSettings
    'Last Documented 8/29/07

#Region "Member Variables"

    ''' <summary>
    ''' The network address of the server
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ServerAddress As String
    ''' <summary>
    ''' The Name of the Database
    ''' </summary>
    ''' <remarks></remarks>
    Private m_DBName As String
    ''' <summary>
    ''' True if using Windows Authentication
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Trusted As Boolean
    ''' <summary>
    ''' User Name for the connection
    ''' </summary>
    ''' <remarks></remarks>
    Private m_UserID As String
    ''' <summary>
    ''' Password of the connection
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Password As String
    ''' <summary>
    ''' Timeout of the connection
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Timeout As Integer
    ''' <summary>
    ''' The actual connection string used by the DB connection
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ConnStr As String

#End Region

#Region "Functions"

#Region "Member Functions"

    ''' <summary>
    ''' Create a new set of connection settings with the specified parameters (if any are specified)
    ''' </summary>
    ''' <param name="e_ServerAddress">[IP Address]\[Instance Name] or [Server Name]\[Instance Name] for Named Instances such as SQLExpress
    ''' or just use [IP Address] or [Server Name] for Unnamed Instances.</param>
    ''' <param name="e_DBName">Name of the database to connect to.</param>
    ''' <param name="e_Timeout">How long the connection should stay open before timeout.</param>
    ''' <param name="e_Trusted">Whether the connection uses Windows Authentication.</param>
    ''' <param name="e_UserID">The Username for the Database Server</param>
    ''' <param name="e_Password">The Password for the Database Server</param>
    ''' <remarks></remarks>
    Public Sub New(Optional ByVal e_ServerAddress As String = "", Optional ByVal e_DBName As String = "", Optional ByVal e_Timeout As Integer = 1, Optional ByVal e_Trusted As Boolean = False, Optional ByVal e_UserID As String = "", Optional ByVal e_Password As String = "")
        m_ServerAddress = e_ServerAddress
        m_DBName = e_DBName
        m_Trusted = e_Trusted
        m_Timeout = e_Timeout
        m_UserID = e_UserID
        m_Password = e_Password

        'Regenerate the connection string
        SetConnectionString()
        If Not (m_ConnStr = "") Then
            Dim testConn As New SqlClient.SqlConnection(m_ConnStr)
            testConn.Open()
            'Create an sql command that accesses all tables and a field within the series catalog table
            Dim sql1 As String = "SELECT MAX(VersionNumber) as CurrentVersion FROM ODMVersion"
            Dim VersTable As New SqlClient.SqlDataAdapter(sql1, testConn)
            Dim Table As New DataTable
            VersTable.Fill(Table)
            testConn.Close()
            testConn.Dispose()
            My.Settings.ODMVersion = (Table.Rows(0).Item("CurrentVersion").ToString())
        End If
    End Sub

#End Region

#Region "Connection String Functionality"

    ''' <summary>
    ''' Increases the Timeout setting by 1 as long as it is less than or equal to 15
    ''' Then regenerates the conntection string
    ''' </summary>
    ''' <returns>Returns True if m_timeout is not too high</returns>
    ''' <remarks></remarks>
    Public Function IncrementTimeout() As Boolean

        If Timeout <= 450 Then
            m_Timeout = m_Timeout + 100
            SetConnectionString()
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Generates a connection string for use in accessing a database
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetConnectionString()
        If m_Trusted Then
            If Not (m_ServerAddress = "" OrElse m_DBName = "" OrElse m_Timeout <= 0) Then
                m_ConnStr = "Data Source=" & m_ServerAddress & ";Integrated Security=" & "True" & ";Connect Timeout=" & m_Timeout & ";Initial Catalog=" & m_DBName & ";MultipleActiveResultSets=True"
            Else
                m_ConnStr = ""
            End If
        Else
            If Not (m_ServerAddress = "" OrElse m_DBName = "" OrElse m_Timeout <= 0 OrElse m_UserID = "" OrElse m_Password = "") Then
                m_ConnStr = "Data Source=" & m_ServerAddress & ";User ID=" & m_UserID & ";Password=" & m_Password & ";Connect Timeout=" & m_Timeout & ";Initial Catalog=" & m_DBName & ";MultipleActiveResultSets=True"
            Else
                m_ConnStr = ""
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Properties"

    ''' <summary>
    ''' Returns the Server Address
    ''' </summary>
    ''' <value></value>
    ''' <returns>Formated as [IP] or [IP]\[Instance] or [Server Name] or [Server Name]\[Instance]</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ServerAddress() As String
        Get
            Return m_ServerAddress
        End Get
    End Property

    ''' <summary>
    ''' returns the Database Name value for the connection
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DBName() As String
        Get
            Return m_DBName
        End Get
    End Property

    ''' <summary>
    ''' returns the Trusted Connection value for the connection
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Trusted() As Boolean
        Get
            Return m_Trusted
        End Get
    End Property

    ''' <summary>
    ''' returns the User ID value for the connection
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UserID() As String
        Get
            Return m_UserID
        End Get
    End Property

    ''' <summary>
    ''' returns the User Password value for the connection
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Password() As String
        Get
            Return m_Password
        End Get
    End Property

    ''' <summary>
    ''' returns the Timeout value for the connection
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Timeout() As Integer
        Get
            Return m_Timeout
        End Get
    End Property

    ''' <summary>
    ''' returns the Connection String created for the connection
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ConnectionString() As String
        Get
            Return m_ConnStr
        End Get
    End Property

#End Region

End Class
