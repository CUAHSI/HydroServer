Partial Public Class Login
    Inherits System.Web.UI.Page


    Private m_ConnSettings As clsConnection
    Private m_ConnectionTested As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack  Then
            btnConnect_Click
        End If
        
        txtPassword.TextMode = TextBoxMode.Password
        Session.Clear()
    End Sub

    Protected Sub btnTestConnection_Click() Handles btnTestConnection.Click
        m_ConnectionTested = False
        Try
            Dim errorMessage As String = "" 'Used to determine what was wrong with the connection
            lblstatus.Text = ""

            'checks for blank fields
            If txtDatabaseName.Text = "" Then
                lblstatus.Text = "Please enter a database name." & vbCrLf & "No Database Name"
                ''LogError("Please enter a database name." & vbCrLf & "No Database Name")
            ElseIf (txtUserID.Text = "") Then '(Not chbSQLTrusted.Checked) AndAlso (txtSQLUID.Text = "")
                lblstatus.Text = "Please enter a User Name." & vbCrLf & "No Username"
                ''LogError("Please enter a User Name." & vbCrLf & "No Username")
            ElseIf (txtPassword.Text = "") Then '(Not chbSQLTrusted.Checked) AndAlso (txtSQLPWD.Text = "")
                lblstatus.Text = "Please enter a Password." & vbCrLf & "No Password"
                ''LogError("Please enter a Password." & vbCrLf & "No Password")
            Else
                m_ConnSettings = New clsConnection(txtServerAddress.Text, txtDatabaseName.Text, 1, False, txtUserID.Text, txtPassword.Text) '(,,,chbSQLTrusted.checked,,)
                If m_ConnSettings.TestDBConnection() Then
                    'Conection was completed without exceptions
                    lblstatus.Text = "Connection Successful"

                    m_ConnectionTested = True

                    'Check for Known Errors
                Else
                    m_ConnectionTested = False
                    lblstatus.Text = "Cannot connect to the specified server." & vbCrLf & "Please change the server name or use a different login."

                    ''LogError("Cannot connect to the specified server." & vbCrLf & "Please change the server name or use a different login.")
                End If
            End If
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            ''LogError("Error Testing the Database Connection", ex)
        End Try
    End Sub


    Protected Sub btnConnect_Click() Handles btnConnect.Click
        lblstatus.Text = ""

        'checks for blank fields
        If txtDatabaseName.Text = "" Then
            lblstatus.Text = "Please enter a database name." & vbCrLf & "No Database Name"
        ElseIf (txtUserID.Text = "") Then
            lblstatus.Text = "Please enter a User Name." & vbCrLf & "No Username"
        ElseIf (txtPassword.Text = "") Then
            lblstatus.Text = "Please enter a Password." & vbCrLf & "No Password"
        Else
            m_ConnSettings = New clsConnection(txtServerAddress.Text, txtDatabaseName.Text, 1, False, txtUserID.Text, txtPassword.Text) '(,,,chbSQLTrusted.checked,,)
            If m_ConnSettings.TestDBConnection() Then
                'Conection was completed without exceptions
                lblstatus.Text = "Connection Successful"

                Session("ServerAddress") = txtServerAddress.Text
                Session("DatabaseName") = txtDatabaseName.Text
                Session("UserID") = txtUserID.Text
                Session("Password") = txtPassword.Text

                Response.Redirect("WebDataLoader.aspx")

            Else
                lblstatus.Text = "Cannot connect to the specified server." & vbCrLf & "Please change the server name or use a different login."
            End If
        End If

    End Sub
End Class