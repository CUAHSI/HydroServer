'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class clsConnectionSettings
    'Last Documented 5/15/07
    'Object for storing all nessecary data to create a Database Connection String

#Region " Member Variables "

    Private m_ServerAddress As String   'The network address of the server
    Private m_DBName As String      'The Name of the Database
    Private m_Trusted As Boolean    'True if using Windows Authentication
    Private m_UserID As String      'User Name for the connection
    Private m_Password As String    'Password of the connection
    Private m_Timeout As Integer    'Timeout of the connection
    Private m_ConnStr As String 'The actual connection string used by the DB connection

#End Region

#Region " Functions "

#Region " Member Functions "

    Public Sub New(Optional ByVal e_ServerAddress As String = "", Optional ByVal e_DBName As String = "", Optional ByVal e_Timeout As Integer = 1, Optional ByVal e_Trusted As Boolean = False, Optional ByVal e_UserID As String = "", Optional ByVal e_Password As String = "")
        'Create a new set of connection settings with the specified parameters (if any are specified)
        'Input:     e_ServerAddress -> The TCP/IP address of the server
        '           e_DBName -> The name of the database within SQL Server
        '           e_Trusted -> Whether to use Windows authentication or SQL Server Authentication
        '           e_Timeout -> The timeout for the specified connection
        '           e_UserID -> The User Name if using SQL Server Authentication
        '           e_Password -> The Password if using SQL Server Authentication

        m_ServerAddress = e_ServerAddress
        m_DBName = e_DBName
        m_Trusted = e_Trusted
        m_Timeout = e_Timeout
        m_UserID = e_UserID
        m_Password = e_Password

        'Regenerate the connection string
        SetConnectionString()
    End Sub

#End Region

#Region " Connection String Functionality "

    Public Function IncrementTimeout() As Boolean
        'Increments the Timeout setting by 1 as long as it is <= 15
        'Then regenerates the conntection string 
        'Output:    Returns True if m_timeout is not too high
        If Timeout <= 30 Then
            m_Timeout = m_Timeout + 1
            SetConnectionString()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SetConnectionString()
        'Generates a connection string for use in accessing a database
        If m_Trusted Then
            If Not (m_ServerAddress = "" And m_DBName = "" And m_Timeout <= 0) Then
                m_ConnStr = "Provider=SQLOLEDB;Server=" & m_ServerAddress & ";Trusted_Connection=" & "Yes" & ";Connect Timeout=" & m_Timeout & ";Database=" & m_DBName & ";"
            Else
                m_ConnStr = Nothing
            End If
        Else
            If Not (m_ServerAddress = "" And m_DBName = "" And m_Timeout <= 0 And m_UserID = "" And m_Password = "") Then
                m_ConnStr = "Provider=SQLOLEDB;Server=" & m_ServerAddress & ";Trusted_Connection=" & "No" & ";UID=" & m_UserID & ";PWD=" & m_Password & ";Connect Timeout=" & m_Timeout & ";Database=" & m_DBName & ";"
            Else
                m_ConnStr = Nothing
            End If
        End If
    End Sub

#End Region

#End Region

#Region " Properties "

    'Note: These Properties are used to protect private data members from being changed

    'ServerAddress property: ReadOnly -> returns the ServerAddress value for the connection
    Public ReadOnly Property ServerAddress() As String
        Get
            Return m_ServerAddress
        End Get
    End Property

    'DBName property: ReadOnly -> returns the Database Name value for the connection
    Public ReadOnly Property DBName() As String
        Get
            Return m_DBName
        End Get
    End Property

    'Trusted property: ReadOnly -> returns the Trusted Connection value for the connection
    Public ReadOnly Property Trusted() As Boolean
        Get
            Return m_Trusted
        End Get
    End Property

    'UserID property: ReadOnly -> returns the User ID value for the connection
    Public ReadOnly Property UserID() As String
        Get
            Return m_UserID
        End Get
    End Property

    'Password property: ReadOnly -> returns the User Password value for the connection
    Public ReadOnly Property Password() As String
        Get
            Return m_Password
        End Get
    End Property

    'Timeout property: ReadOnly -> returns the Timeout value for the connection
    Public ReadOnly Property Timeout() As Integer
        Get
            Return m_Timeout
        End Get
    End Property

    'ConnectionString property: ReadOnly -> returns the Connection String created for the connection
    Public ReadOnly Property ConnectionString() As String
        Get
            Return m_ConnStr
        End Get
    End Property

#End Region

End Class
