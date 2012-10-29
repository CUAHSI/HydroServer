Imports System.Data.SqlClient

'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Module ODMTSettings
    'Last Documented 5/15/07

#Region " Global Variables "

    Public g_CurrConnSettings As clsConnectionSettings  'The Current Connection Settings
    Public g_CurrOptions As clsOptions  'The Current ODM Tools Options

#End Region

#Region " Settings Retrieval Functionality "

    Public Function GetSettings() As Boolean
        'Retrieves the Database Settings from the associated settings File, loads values into member variables
        'Outputs: Boolean -> tracks if successfully retrieved the Database Info from the associated XML File or not

        Dim m_TempConnSettings As clsConnectionSettings   'The connection settings loaded from the file

        'Temporary database settings
        Dim serverAddress As String 'holds the server address value for the connection string to validate
        Dim dBName As String 'holds the database name value for the connection string to validate
        Dim trusted As Boolean 'holds the trusted connection for the connection string value to validate
        Dim userID As String 'holds the user ID value for the connection string to validate
        Dim password As String 'holds the user password for the connection string value to validate
        Dim timeout As Integer 'holds the timeout value for the connection string to valiate

        Try
            'Get temp database settings from settings file
            serverAddress = My.Settings.Database_Path
            dBName = My.Settings.Database_Name
            trusted = My.Settings.Trusted_Connection
            userID = My.Settings.User_Name
            password = Decrypt(My.Settings.Password)
            timeout = My.Settings.Timeout

            'Get Options from settings file.  Save to g_currOptions object
            g_CurrOptions.ExportTime = My.Settings.Export_Time
            g_CurrOptions.ExportSite = My.Settings.Export_Site
            g_CurrOptions.ExportVariable = My.Settings.Export_Variable
            g_CurrOptions.ExportQualifier = My.Settings.Export_Qualifier
            g_CurrOptions.ExportOffset = My.Settings.Export_Offset
            g_CurrOptions.ExportSource = My.Settings.Export_Source
            g_CurrOptions.MetadataExport = My.Settings.Export_MetaData
            g_CurrOptions.ExportQualityControlLevels = My.Settings.Export_QCLevel

            If (serverAddress = "") Or (dBName = "") Or (userID = "") Then
                Return False
            End If

            'create a new clsConnectionSettings object
            m_TempConnSettings = New clsConnectionSettings(serverAddress, dBName, timeout, trusted, userID, password)

            

            Try
                'no errors occurred, return true
                Dim testConn As New SqlClient.SqlConnection(m_TempConnSettings.ConnectionString)
                testConn.Open()
                'Create an sql command that accesses all tables and a field within the series catalog table
                Dim sql1 As String = "SELECT MAX(VersionNumber) as CurrentVersion FROM ODMVersion"
                Dim VersTable As New SqlClient.SqlDataAdapter(sql1, testConn)
                Dim Table As New DataTable
                VersTable.Fill(Table)
                testConn.Close()
                testConn.Dispose()
                My.Settings.ODMVersion = (Table.Rows(0).Item("CurrentVersion").ToString())

            Catch ex As Exception
                g_CurrConnSettings = New clsConnectionSettings
                Return False
            End Try

            g_CurrConnSettings = m_TempConnSettings
            Return True
            


            'If TestDBConnection(m_TempConnSettings) Then
            '    g_CurrConnSettings = m_TempConnSettings
            '    Return True
            'Else
            '    g_CurrConnSettings = New clsConnectionSettings
            '    Return False
            'End If

        Catch ex As SqlException

        Catch ex As Exception
            ShowError("An Error occurred while retrieving your settings." & vbCrLf & "Error = " & ex.Message, ex)
        End Try
            'error(s) occurred above, return false
            Return False
    End Function

#End Region

#Region " Writing Settings Functionality "

    Public Function WriteSettings() As Boolean
        'Writes the program settings to the settings file
        'Outputs: returns true if sucessful
        Try
            'DB Settings
            My.Settings.Database_Name = g_CurrConnSettings.DBName
            My.Settings.Database_Path = g_CurrConnSettings.ServerAddress
            My.Settings.Trusted_Connection = g_CurrConnSettings.Trusted
            My.Settings.User_Name = g_CurrConnSettings.UserID
            My.Settings.Password = Encrypt(g_CurrConnSettings.Password)
            My.Settings.Timeout = g_CurrConnSettings.Timeout
            'Data Export Settings
            My.Settings.Export_Time = g_CurrOptions.ExportTime
            My.Settings.Export_Site = g_CurrOptions.ExportSite
            My.Settings.Export_Variable = g_CurrOptions.ExportVariable
            My.Settings.Export_Qualifier = g_CurrOptions.ExportQualifier
            My.Settings.Export_Offset = g_CurrOptions.ExportOffset
            My.Settings.Export_Source = g_CurrOptions.ExportSource
            My.Settings.Export_MetaData = g_CurrOptions.MetadataExport
            My.Settings.Export_QCLevel = g_CurrOptions.ExportQualityControlLevels
            'Save the settings file
            My.Settings.Save()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

End Module
