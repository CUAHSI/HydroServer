'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class FrmDBConnection
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New(Optional ByVal e_FormName As String = "New Database Connection", Optional ByVal e_OldDBName As String = "", Optional ByVal e_OldDBServer As String = "", Optional ByVal e_OldDBUSer As String = "", Optional ByVal e_OldDBPassword As String = "", Optional ByVal e_OldDBTrusted As Boolean = True)
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call
		'chbSQLTrusted.Checked = e_OldDBTrusted
		If e_OldDBServer = "" Then
			txtSQLAddress.Text = "(local)"
		Else
			txtSQLAddress.Text = e_OldDBServer
		End If
		If e_OldDBName = "" Then
			txtDatabaseName.Text = "OD"
		Else
			txtDatabaseName.Text = e_OldDBName
		End If

		If e_OldDBUSer = "" And e_OldDBPassword = "" Then
			txtSQLUID.Text = m_defaultUIDsql
			txtSQLPWD.Text = m_defaultPWDsql
		Else
			txtSQLUID.Text = e_OldDBUSer
			txtSQLPWD.Text = e_OldDBPassword
		End If

		Me.Text = e_FormName
		If e_FormName = "New Database Connection" Then m_NewConnection = True
	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents txtSQLAddress As System.Windows.Forms.TextBox
	Friend WithEvents txtSQLPWD As System.Windows.Forms.TextBox
	Friend WithEvents txtSQLUID As System.Windows.Forms.TextBox
	Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
	Friend WithEvents DatabaseNameLabel As System.Windows.Forms.Label
	Friend WithEvents lblTitle As System.Windows.Forms.Label
	Friend WithEvents lblServerAddress As System.Windows.Forms.Label
	Friend WithEvents lblServerPassword As System.Windows.Forms.Label
	Friend WithEvents lblServerUserID As System.Windows.Forms.Label
	Friend WithEvents grpSQL As System.Windows.Forms.GroupBox
	Friend WithEvents btnSaveMasterPrefs As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents btnTestConn As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.lblTitle = New System.Windows.Forms.Label
		Me.grpSQL = New System.Windows.Forms.GroupBox
		Me.DatabaseNameLabel = New System.Windows.Forms.Label
		Me.txtDatabaseName = New System.Windows.Forms.TextBox
		Me.txtSQLAddress = New System.Windows.Forms.TextBox
		Me.lblServerAddress = New System.Windows.Forms.Label
		Me.txtSQLPWD = New System.Windows.Forms.TextBox
		Me.lblServerPassword = New System.Windows.Forms.Label
		Me.txtSQLUID = New System.Windows.Forms.TextBox
		Me.lblServerUserID = New System.Windows.Forms.Label
		Me.btnSaveMasterPrefs = New System.Windows.Forms.Button
		Me.btnTestConn = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.grpSQL.SuspendLayout()
		Me.SuspendLayout()
		'
		'lblTitle
		'
		Me.lblTitle.Location = New System.Drawing.Point(9, 8)
		Me.lblTitle.Name = "lblTitle"
		Me.lblTitle.Size = New System.Drawing.Size(392, 16)
		Me.lblTitle.TabIndex = 0
		Me.lblTitle.Text = "Please select a Database:"
		'
		'grpSQL
		'
		Me.grpSQL.Controls.Add(Me.DatabaseNameLabel)
		Me.grpSQL.Controls.Add(Me.txtDatabaseName)
		Me.grpSQL.Controls.Add(Me.txtSQLAddress)
		Me.grpSQL.Controls.Add(Me.lblServerAddress)
		Me.grpSQL.Controls.Add(Me.txtSQLPWD)
		Me.grpSQL.Controls.Add(Me.lblServerPassword)
		Me.grpSQL.Controls.Add(Me.txtSQLUID)
		Me.grpSQL.Controls.Add(Me.lblServerUserID)
		Me.grpSQL.Location = New System.Drawing.Point(9, 32)
		Me.grpSQL.Name = "grpSQL"
		Me.grpSQL.Size = New System.Drawing.Size(392, 120)
		Me.grpSQL.TabIndex = 1
		Me.grpSQL.TabStop = False
		Me.grpSQL.Text = "Microsoft SQL Server"
		'
		'DatabaseNameLabel
		'
		Me.DatabaseNameLabel.Location = New System.Drawing.Point(24, 40)
		Me.DatabaseNameLabel.Name = "DatabaseNameLabel"
		Me.DatabaseNameLabel.Size = New System.Drawing.Size(104, 20)
		Me.DatabaseNameLabel.TabIndex = 2
		Me.DatabaseNameLabel.Text = "Database Name:"
		Me.DatabaseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtDatabaseName
		'
		Me.txtDatabaseName.Location = New System.Drawing.Point(136, 40)
		Me.txtDatabaseName.Name = "txtDatabaseName"
		Me.txtDatabaseName.Size = New System.Drawing.Size(250, 20)
		Me.txtDatabaseName.TabIndex = 3
		'
		'txtSQLAddress
		'
		Me.txtSQLAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSQLAddress.Location = New System.Drawing.Point(136, 16)
		Me.txtSQLAddress.Name = "txtSQLAddress"
		Me.txtSQLAddress.Size = New System.Drawing.Size(250, 20)
		Me.txtSQLAddress.TabIndex = 1
		Me.txtSQLAddress.Text = "(local)"
		'
		'lblServerAddress
		'
		Me.lblServerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblServerAddress.Location = New System.Drawing.Point(24, 16)
		Me.lblServerAddress.Name = "lblServerAddress"
		Me.lblServerAddress.Size = New System.Drawing.Size(104, 20)
		Me.lblServerAddress.TabIndex = 0
		Me.lblServerAddress.Text = "Server Address:"
		Me.lblServerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtSQLPWD
		'
		Me.txtSQLPWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSQLPWD.Location = New System.Drawing.Point(136, 88)
		Me.txtSQLPWD.Name = "txtSQLPWD"
		Me.txtSQLPWD.Size = New System.Drawing.Size(250, 20)
		Me.txtSQLPWD.TabIndex = 8
		Me.txtSQLPWD.UseSystemPasswordChar = True
		'
		'lblServerPassword
		'
		Me.lblServerPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblServerPassword.Location = New System.Drawing.Point(24, 88)
		Me.lblServerPassword.Name = "lblServerPassword"
		Me.lblServerPassword.Size = New System.Drawing.Size(104, 20)
		Me.lblServerPassword.TabIndex = 7
		Me.lblServerPassword.Text = "Server Password:"
		Me.lblServerPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtSQLUID
		'
		Me.txtSQLUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSQLUID.Location = New System.Drawing.Point(136, 64)
		Me.txtSQLUID.Name = "txtSQLUID"
		Me.txtSQLUID.Size = New System.Drawing.Size(250, 20)
		Me.txtSQLUID.TabIndex = 6
		'
		'lblServerUserID
		'
		Me.lblServerUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblServerUserID.Location = New System.Drawing.Point(24, 64)
		Me.lblServerUserID.Name = "lblServerUserID"
		Me.lblServerUserID.Size = New System.Drawing.Size(104, 20)
		Me.lblServerUserID.TabIndex = 5
		Me.lblServerUserID.Text = "Server User ID:"
		Me.lblServerUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnSaveMasterPrefs
		'
		Me.btnSaveMasterPrefs.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnSaveMasterPrefs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSaveMasterPrefs.Location = New System.Drawing.Point(145, 160)
		Me.btnSaveMasterPrefs.Name = "btnSaveMasterPrefs"
		Me.btnSaveMasterPrefs.Size = New System.Drawing.Size(120, 24)
		Me.btnSaveMasterPrefs.TabIndex = 3
		Me.btnSaveMasterPrefs.Text = "&Save Changes"
		'
		'btnTestConn
		'
		Me.btnTestConn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnTestConn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnTestConn.Location = New System.Drawing.Point(9, 160)
		Me.btnTestConn.Name = "btnTestConn"
		Me.btnTestConn.Size = New System.Drawing.Size(120, 24)
		Me.btnTestConn.TabIndex = 2
		Me.btnTestConn.Text = "&Test Connection"
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(281, 160)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(120, 24)
		Me.btnCancel.TabIndex = 4
		Me.btnCancel.Text = "&Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'FrmDBConnection
		'
		Me.AcceptButton = Me.btnSaveMasterPrefs
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(410, 192)
		Me.ControlBox = False
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnSaveMasterPrefs)
		Me.Controls.Add(Me.btnTestConn)
		Me.Controls.Add(Me.grpSQL)
		Me.Controls.Add(Me.lblTitle)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FrmDBConnection"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Database Configuration"
		Me.grpSQL.ResumeLayout(False)
		Me.grpSQL.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

#End Region

    'Last Documented 5/15/07

#Region " Member Variables "

    Dim m_FinalConnSettings As clsConnectionSettings 'The Connection Settings structure from the connectiondata module
    Private Const m_defaultUIDsql As String = "" 'Default SQL user ID -> used when checking for Win98 compatibility
    Private Const m_defaultPWDsql As String = ""    'Default SQL user Password -> used when checking for Win98 compatibility
    Private m_ConnectionTested As Boolean 'Tracks whether the recently modified connection has been tested
    Private m_Saving As Boolean 'Tracks whether the settings have been changed
    Private m_NewConnection As Boolean    'Tracks whether it is a new connection or changing an old one.

#End Region

#Region " Form Functionality "

    Private Sub btnTestConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConn.Click
        'Tests the Connection and marks whether the connection has been tested
        'Input:     Default form inputs plus the customconnect() function's result
        'Output:    ConnectionTested
        m_ConnectionTested = CustomConnect()
    End Sub

    Private Sub btnSaveMasterPrefs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveMasterPrefs.Click
        'Checks if the connection has been tested, if not then it tests
        'if the test is succesful it saves the current data to the ConnString
        'and exits the program
        'Input:     Default form Input plus Determines whther the connection is valid and whether to save it.
        'Output:    Whether to save the settings or not  

        If m_ConnectionTested Then
            m_Saving = True
            Close()
        Else
            m_ConnectionTested = CustomConnect()
            If m_ConnectionTested Then
                m_Saving = True
                Close()
            End If
        End If
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        'When the dialog box is closed without saving it sends a dialogresult.cancel  
        'Input:     m_NewConnection, m_Saving, and User Inputs -> Used to decide whether to store the connection or not.
        'Output:    FinalConnsettings, Me.dialogresult ->Stores Successful connection settings to CurrConnSettings, and sends a dialogresult.ok

        'If saving then save the settings
        If m_Saving Then
            g_CurrConnSettings = m_FinalConnSettings
            'Write the settings to the xml document
            If Not WriteSettings() Then
                ShowError("Unable to save settings." & vbCrLf & "Settings not saved")
            End If
            'return an OK dialog result
            Me.DialogResult = Windows.Forms.DialogResult.OK

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Cancels the dialog
        'Input:     Default form input
        'Output:    Triggers the Form.close event.

        If m_NewConnection Then
            If MsgBox("No Database Connection:  Unable to continue without a valid Database Connection." & vbCrLf & "Would you like to quit ODM Tools?", MsgBoxStyle.YesNo, "No Database Connection") = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

#Region " Validation Functions "
    'If any settings have been changed, it validates the input and then marks the connection as not tested "

    Private Sub txtSQLAddress_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSQLAddress.TextChanged
        m_ConnectionTested = False
    End Sub

    Private Sub txtDatabaseName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDatabaseName.TextChanged
        Dim i As Integer 'Counter Variable
        While i < (txtDatabaseName.Text.Length)
            If Not (Char.IsLetterOrDigit(txtDatabaseName.Text, i) Or Mid(txtDatabaseName.Text, i + 1, 1) = "_") Then
                txtDatabaseName.Text = txtDatabaseName.Text.Remove(i, 1)
                txtDatabaseName.SelectionStart = i
            Else
                i += 1
            End If
        End While
        m_ConnectionTested = False
    End Sub

    Private Sub txtSQLUID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSQLUID.TextChanged
        Dim i As Integer 'Counter Variable
        While i < (txtSQLUID.Text.Length)
            If Not Char.IsLetterOrDigit(txtSQLUID.Text, i) Then
                txtSQLUID.Text = txtSQLUID.Text.Remove(i, 1)
                txtSQLUID.SelectionStart = i
            Else
                i += 1
            End If
        End While
        m_ConnectionTested = False
    End Sub

    Private Sub txtSQLPWD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSQLPWD.TextChanged
        m_ConnectionTested = False
    End Sub

#End Region

#End Region

#Region " Connection Testing Functions "

    Private Function CustomConnect() As Boolean
        'Determines if any fields are blank then tests the connection
        'Inputs:     The connection string from NewConnString() 
        'Outputs:    Returns True if the Connection was valid and successful

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim errorMessage As String 'Used to determine what was wrong with the connection
        'checks for blank fields
        If txtDatabaseName.Text = "" Then
            ShowError("Please enter a database name." & vbCrLf & "No Database Name")
        ElseIf (txtSQLUID.Text = "") Then '(Not chbSQLTrusted.Checked) AndAlso (txtSQLUID.Text = "")
            ShowError("Please enter a User Name." & vbCrLf & "No Username")
        ElseIf (txtSQLPWD.Text = "") Then '(Not chbSQLTrusted.Checked) AndAlso (txtSQLPWD.Text = "")
            ShowError("Please enter a Password." & vbCrLf & "No Password")
        Else
            m_FinalConnSettings = New clsConnectionSettings(txtSQLAddress.Text, txtDatabaseName.Text, 10, False, txtSQLUID.Text, txtSQLPWD.Text) '(,,,chbSQLTrusted.checked,,)
            If TestDBConnection(m_FinalConnSettings, errorMessage) Then
                'Conection was completed without exceptions
                MsgBox("Connection Successful", MsgBoxStyle.Information, "ODM Tools")
                Me.Cursor = Windows.Forms.Cursors.Default
                Return True
                'Check for Known Errors
            ElseIf Mid(errorMessage, 1, 41) = "Cannot open database requested in login '" Then
                ShowError("The requested database does not exist on that server." & vbCrLf & "Please enter the full server path.")
            ElseIf Mid(errorMessage, 1, 21) = "Invalid object name '" Then
                ShowError("The requested database does not contain the correct tables." & vbCrLf & "Please enter a different database name.")
            Else
                ShowError("Cannot connect to the specified server." & vbCrLf & "Please change the server name or use a different login.")
            End If
        End If
        Me.Cursor = Windows.Forms.Cursors.Default
        Return False
    End Function

#End Region

End Class