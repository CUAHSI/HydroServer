'ODM Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..

Public Class ucDBConnection
    'Last Documented 8/31/07

#Region " Member Variables "

    Dim m_FinalConnSettings As clsConnection 'The Connection Settings structure from the connectiondata module
    Private Const m_defaultUIDsql As String = "" 'Default SQL user ID -> used when checking for Win98 compatibility
    Private Const m_defaultPWDsql As String = ""    'Default SQL user Password -> used when checking for Win98 compatibility
    Private m_ConnectionTested As Boolean 'Tracks whether the recently modified connection has been tested.
    Private m_NewConnection As Boolean    'Tracks whether it is a new connection or changing an old one.

#End Region

#Region " Properties "

    Public Property GetDBSetttings() As clsConnection
        'Returns a clsConnectionSettings object based on the Provided Database settings
        Get
            Return m_FinalConnSettings
        End Get
        Set(ByVal value As clsConnection)
            Try
                If value Is Nothing Then
                    value = New clsConnection()
                End If
                m_FinalConnSettings = value
                If value.ServerAddress <> "" Then
                    txtSQLAddress.Text = value.ServerAddress
                Else
                    txtSQLAddress.Text = "(local)"
                End If
                txtDatabaseName.Text = value.DBName
                txtSQLUID.Text = value.UserID
                m_ConnectionTested = True
                txtSQLPWD.Text = value.Password
            Catch ex As Exception
                RaiseEvent ErrorOccured(ex)
            End Try
        End Set
    End Property

#End Region

#Region " Events "

    Public Event DataChanged() 'Reports when the data has been changed
    Public Event ErrorOccured(ByVal ex As Exception) 'Reports when an error has occurred.

#End Region

#Region " Validation Functions "
    'If any settings have been changed, it validates the input and then marks the connection as not tested "

    Public Sub PasswordReset()
        txtSQLPWD.Text = ""
    End Sub

    Private Sub txtSQLPWD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSQLPWD.TextChanged
        Try
            m_ConnectionTested = False
            RaiseEvent DataChanged()
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex)
        End Try
    End Sub

    Private Sub txtSQLAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLAddress.TextChanged
        RaiseEvent DataChanged()
    End Sub
#End Region

#Region " Connection Testing Functions "

    Public Function TestConnection() As Boolean
        Try
            'Determines if any fields are blank then tests the connection

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            'checks for blank fields
            If txtDatabaseName.Text = "" Then
                ShowError("Please enter a database name." & vbCrLf & "No Database Name")
            ElseIf (txtSQLUID.Text = "") Then '(Not chbSQLTrusted.Checked) AndAlso (txtSQLUID.Text = "")
                ShowError("Please enter a User Name." & vbCrLf & "No Username")
            ElseIf (txtSQLPWD.Text = "") Then '(Not chbSQLTrusted.Checked) AndAlso (txtSQLPWD.Text = "")
                ShowError("Please enter a Password." & vbCrLf & "No Password")
            Else
                m_FinalConnSettings = New clsConnection(txtSQLAddress.Text, txtDatabaseName.Text, 10, False, txtSQLUID.Text, txtSQLPWD.Text) '(,,,chbSQLTrusted.checked,,)
                If m_FinalConnSettings.TestDBConnection() Then
                    'Conection was completed without exceptions
                    'MsgBox("Connection Successful!", MsgBoxStyle.Information, "Connection Successful")
                    Me.Cursor = Windows.Forms.Cursors.Default
                    Return True
                End If
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
        Catch ex As Exception
            PasswordReset()
        End Try
        Return False
    End Function

#End Region

End Class
