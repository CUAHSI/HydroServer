'Imports System.XML
Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports system.IO





Public Class AccessDB


    Private ConnectionTested As Boolean 'Tracks whether the connection has been tested
    Public connectionString As String
    Public firsttime As Boolean = False



    Private Sub CloseButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub ConnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectButton.Click
        ConnectionTested = CustomConnect()
        If ConnectionTested Then
            'Write the settings to the xml document
            If Not WriteSettings() Then
                ShowError("Unable to save settings." & vbCrLf & "Settings not saved")
            End If
            'return an OK dialog result
            'Me.DialogResult = Windows.Forms.DialogResult.OK

            Connect()
        End If
    End Sub

    Private Sub Connect()
        'display Form1
        If Not Form1.Visible Then
            Form1.Show()
        End If
        Form1.IcewaterConnection.ConnectionString = connectionString
        Form1.lblDBName.Text = txtDatabase.Text
        Form1.lblCurrUser.Text = txtUser.Text
        Form1.lblServer.Text = txtServer.Text()

        'close current page 
        Me.Hide()
    End Sub

    Private Sub AccessDB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' check to see if there is a saved connection if so load the information else do nothing

        getfirsttime()
        My.Settings.Reload()
        If Not My.Settings.Database_Name = "" Then

            txtDatabase.Text = My.Settings.Database_Name
            txtServer.Text = My.Settings.Database_Path
            txtUser.Text = My.Settings.User_Name
            If Not My.Settings.Password = "" Then
                txtPWD.Text = Decrypt(My.Settings.Password)
            End If

            If firsttime Then

                ConnectionTested = CustomConnect()
                Connect()
                Me.Close()
            End If
        End If

    End Sub
    Private Sub getfirsttime()
        If Form1.Visible Then
            firsttime = False
        Else
            firsttime = True
        End If
    End Sub
    Private Function CustomConnect() As Boolean
        'Determines if any fields are blank then tests the connection
        'Inputs:     The connection string from NewConnString() 
        'Outputs:    Returns True if the Connection was valid and successful

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim errorMessage As String 'Used to determine what was wrong with the connection
        'checks for blank fields
        If txtDatabase.Text = "" Then
            ShowError("Please enter a database name." & vbCrLf & "No Database Name")
        ElseIf (txtUser.Text = "") Then '(Not chbSQLTrusted.Checked) AndAlso (txtSQLUID.Text = "")
            ShowError("Please enter a User Name." & vbCrLf & "No Username")
        ElseIf (txtPWD.Text = "") Then '(Not chbSQLTrusted.Checked) AndAlso (txtSQLPWD.Text = "")
            ShowError("Please enter a Password." & vbCrLf & "No Password")
        Else
            connectionString = "Data Source=" & txtServer.Text & ";Initial Catalog=" & txtDatabase.Text & ";User ID=" & txtUser.Text & ";Password=" & txtPWD.Text & ";"
            IcewaterConnection.ConnectionString = connectionString
            If TestDBConnection(connectionString) Then
                'Conection was completed without exceptions
                Me.Cursor = Windows.Forms.Cursors.Default
                Return True

                'Check for Known Errors
            ElseIf Mid(errorMessage, 1, 41) = "Cannot open database requested in login '" Then
                MsgBox("The requested database does not exist on that server." & vbCrLf & "Please enter the full server path.")
            ElseIf Mid(errorMessage, 1, 21) = "Invalid object name '" Then
                ShowError("The requested database does not contain the correct tables." & vbCrLf & "Please enter a different database name.")
            Else
                ShowError("Cannot connect to the specified server." & vbCrLf & "Please change the server name or use a different login.")
            End If
        End If
        Me.Cursor = Windows.Forms.Cursors.Default
        Return False
    End Function


    Public Sub ShowError(ByVal errorMessage As String, Optional ByVal ex As Exception = Nothing) ', Optional ByVal style As MsgBoxStyle = MsgBoxStyle.Critical)
        'Displays an error message to the user with the name of the function where the error occured and the error message
        'Inputs:  funcName -> the name of the function where the error occurred
        '         errorMessage -> the message to display
        'Outputs: Displays a messagebox to the user

        'show the error message
        If ex Is Nothing Then
            MsgBox(errorMessage, MsgBoxStyle.Critical, "HydroServer Configuration Error")
        Else
            Dim message As String = ex.Message

            MsgBox(errorMessage & vbCrLf & message, MsgBoxStyle.Critical, "HydroServer Configuration Error")
        End If

    End Sub

    Public Function TestDBConnection(ByRef e_DBSettings As String, Optional ByRef ErrorMessage As String = "NONE") As Boolean
        'Used to test a databse connection
        'Inputs:  Settings -> A ConnectionSettings instance used to create a connection to a database
        'Outputs: TestDBConnection -> Returns True if the test was successful, otherwise returns False

        'Create a new connection
        If txtDatabase.Text = "" Or txtServer.Text = "" Then
            Return False
        Else
            connectionString = "Data Source=" & txtServer.Text & ";Initial Catalog=" & txtDatabase.Text & ";User ID=" & txtUser.Text & ";Password=" & txtPWD.Text & ";"
            IcewaterConnection.ConnectionString = connectionString
            Try
                IcewaterConnection.Open()
                If IcewaterConnection.State = ConnectionState.Open Then
                Else
                    Throw New Exception("Unable to open database connection.")
                End If
                IcewaterConnection.Close()

            Catch ex As Exception

                If ex.Message.Contains("SQL Server does not exist") Then
                    ShowError("Server Address Incorrect.", ex)
                    Return False
                ElseIf ex.Message.Contains("Cannot open database") Then
                    ShowError("Database Name Incorrect.", ex)
                    Return False
                ElseIf ex.Message.Contains("Login failed for user") Then
                    ShowError("Username or Password Incorrect.", ex)
                    Return False
                ElseIf ErrorMessage = "NONE" Then
                    ShowError("Unable to connect to Database", ex)
                    Return False
                    'Else
                    '    ErrorMessage = ex.Message
                    '   Return False
                End If
            End Try
            Return True
        End If
        'No Errors
    End Function





    Public Function WriteSettings() As Boolean
        'Writes the program settings to the settings file
        'Outputs: returns true if sucessful
        Try
            'DB(Settings)
            My.Settings.Database_Name = txtDatabase.Text
            My.Settings.Database_Path = txtServer.Text
            My.Settings.User_Name = txtUser.Text
            My.Settings.Password = Encrypt(txtPWD.Text)



            'Save the settings file
            My.Settings.Save()
            'MsgBox("Connection Saved")


            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    ' Create byte array for additional entropy when using Encrypt method.
    Private Const Entropy As String = "WsDlTeZt"

    Public Function Encrypt(ByVal data As String, Optional ByVal padding As Byte = 0) As String
        Try
            Dim encrypted As Byte() = EncryptInMemoryData(Encoding.UTF8.GetBytes(data), DataProtectionScope.CurrentUser)
            Dim temp As String = encrypted(0).ToString("X")
            Dim i As Integer


            For i = 1 To (encrypted.Length - 1)
                temp &= " " & encrypted(i).ToString("X")
            Next

            Return temp

        Catch
            MsgBox("Unable to encrypt data")
        End Try

        Return ""
    End Function

    Public Function Decrypt(ByVal data As String, Optional ByVal padding As Byte = 0) As String
        Try
            Dim bytes() As String = Split(data)
            Dim encrypted(bytes.Length - 1) As Byte
            Dim i As Integer
            For i = 0 To (bytes.Length - 1)
                encrypted(i) = Convert.ToInt32(bytes(i), 16)
            Next

            Dim decrypted As Byte() = DecryptInMemoryData(encrypted, DataProtectionScope.CurrentUser)

            For i = (decrypted.Length - 1) To 0 Step -1
                If decrypted(i) = padding Then
                    ReDim Preserve decrypted(i - 1)
                Else
                    Exit For
                End If
            Next

            Return Encoding.UTF8.GetString(decrypted)

        Catch ex As Exception
            MsgBox("Unable to decrypt data")
        End Try

        Return ""
    End Function

    Private Function EncryptInMemoryData(ByVal Data() As Byte, ByVal Scope As MemoryProtectionScope, Optional ByVal padding As Byte = 0) As Byte()
        If Data.Length <= 0 Then
            Throw New ArgumentException("Buffer")
        End If
        If Data Is Nothing Then
            Throw New ArgumentNullException("Buffer")
        End If

        Dim buffer As Byte()
        buffer = ProtectedData.Protect(Data, Encoding.UTF8.GetBytes(Entropy), Scope)

        Return buffer
    End Function


    Private Function DecryptInMemoryData(ByVal Data() As Byte, ByVal Scope As MemoryProtectionScope) As Byte()
        If Data.Length <= 0 Then
            Throw New ArgumentException("Buffer")
        End If
        If Data Is Nothing Then
            Throw New ArgumentNullException("Buffer")
        End If

        Dim Buffer As Byte()

        'Decrypt the data. The result is stored in the same same array as the original data.
        Buffer = ProtectedData.Unprotect(Data, Encoding.UTF8.GetBytes(Entropy), Scope)

        Return Buffer
    End Function


End Class