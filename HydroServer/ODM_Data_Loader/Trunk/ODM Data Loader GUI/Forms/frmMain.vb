Public Class frmMain
    Dim connect As clsConnection
    Dim WithEvents file As clsFile
    Dim table as new datatable
    Dim path As String

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (file Is Nothing) Then
            file.Canceled = True
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim connection As New clsConnection
        Dim tempFilepath As String = ""
        Dim tempLog As String = ""
        Dim cmdConnection As Integer = 0
        AttachConsole(-1)
        CommandLine = True

        If My.Settings.DateFormat = "" Then
            My.Settings.DateFormat = My.Application.Culture.DateTimeFormat.ShortDatePattern
        End If

        'LogPath = System.IO.Path.GetDirectoryName(Me.GetType.Assembly.Location) & "\Log.txt"
        LogPath = System.IO.Path.GetDirectoryName(System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath) & "\Log.txt"


        For i As Integer = 0 To (My.Application.CommandLineArgs.Count - 1)
            If (My.Application.CommandLineArgs(i).StartsWith("-")) AndAlso (My.Application.CommandLineArgs.Count > (i + 1)) AndAlso (Not (My.Application.CommandLineArgs(i + 1).StartsWith("-"))) Then
                Select Case LCase(My.Application.CommandLineArgs(i))
                    Case "-server"
                        If (connection.ServerAddress = "") Then
                            connection.ServerAddress = My.Application.CommandLineArgs(i + 1)
                            cmdConnection += 1
                        End If
                    Case "-db"
                        If (connection.DBName = "") Then
                            connection.DBName = My.Application.CommandLineArgs(i + 1)
                            cmdConnection += 1
                        End If
                    Case "-user"
                        If (connection.UserID = "") Then
                            connection.UserID = My.Application.CommandLineArgs(i + 1)
                            cmdConnection += 1
                        End If
                    Case "-password"
                        If (connection.Password = "") Then
                            connection.Password = My.Application.CommandLineArgs(i + 1)
                            cmdConnection += 1
                        End If
                    Case "-enc"
                        If (connection.Password = "") Then
                            connection.Password = Decrypt(My.Application.CommandLineArgs(i + 1)).Replace("""", "")
                            cmdConnection += 1
                        End If
                    Case "-file"
                        tempFilepath = My.Application.CommandLineArgs(i + 1)
                        If (tempFilepath <> "") Then
                            txtFilePath.Text = tempFilepath.Replace("""", "")
                            cmdConnection += 1
                        End If
                    Case "-log"
                        tempLog = LCase(My.Application.CommandLineArgs(i + 1))
                        tempLog = tempLog.Replace("""", "")
                        If tempLog.Contains("\") Then
                            If (System.IO.Directory.Exists(tempLog.Remove(tempLog.LastIndexOf("\"), tempLog.Length - tempLog.LastIndexOf("\")))) Then
                                LogPath = tempLog
                            End If
                        Else
                            LogPath = System.IO.Path.GetDirectoryName(Me.GetType.Assembly.Location) & "\" & tempLog
                        End If
                    Case Else
                        Dim tempError As String = _
                        "Valid Command Line Arguments:" & vbCrLf & _
                        "-server [ServerAddress]" & vbCrLf & _
                        "-db [DatabaseName]" & vbCrLf & _
                        "-user [UserName]" & vbCrLf & _
                        "-password [Password]" & vbCrLf & _
                        "-file ""[FilePath]""" & vbCrLf & _
                        "-log ""[FilePath]"""
                        MsgBox(tempError, MsgBoxStyle.Information, "Command Line Argument Help")
                        Me.Close()
                        Exit Sub
                End Select
            ElseIf (LCase(My.Application.CommandLineArgs(i)) = "-?") OrElse (LCase(My.Application.CommandLineArgs(i)) = "-h") Then
                Dim tempError As String = _
                "Valid Command Line Arguments:" & vbCrLf & _
                "-server [ServerAddress]" & vbCrLf & _
                "-db [DatabaseName]" & vbCrLf & _
                "-user [UserName]" & vbCrLf & _
                "-password [Password]" & vbCrLf & _
                "-file ""[FilePath]""" & vbCrLf & _
                "-log ""[FilePath]"""
                MsgBox(tempError, MsgBoxStyle.Information, "Command Line Argument Help")
                Me.Close()
                Exit Sub
            End If
        Next i

        writer = New System.IO.StreamWriter(LogPath, True)

        If cmdConnection < 5 Then
            CommandLine = False
        End If

        If (connection.ConnectionString <> "") Then
            If (connection.TestDBConnection()) Then
                connect = connection
            Else
                Dim connectDialog As FrmDBConnection
                If cmdConnection Then
                    connectDialog = New FrmDBConnection(connection)
                Else
                    connectDialog = New FrmDBConnection
                End If
                Select Case connectDialog.ShowDialog
                    Case Windows.Forms.DialogResult.OK
                        connect = connectDialog.ConnectionSettings

                    Case Windows.Forms.DialogResult.Cancel
                        Me.Close()
                        Exit Sub
                    Case Else
                        LogError("Invalid Dialog Result Returned") ', , logWriter)
                End Select
            End If
        Else
            Dim connectDialog As FrmDBConnection
            If cmdConnection Then
                connectDialog = New FrmDBConnection(connection)
            Else
                connectDialog = New FrmDBConnection
            End If
            Select Case connectDialog.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    connect = connectDialog.ConnectionSettings
                Case Windows.Forms.DialogResult.Cancel
                    Me.Close()
                    Exit Sub
                Case Else
                    LogError("Invalid Dialog Result Returned") ', , logWriter)
            End Select
        End If


        If (tempFilepath <> "") Then
            If (cmdConnection >= 5) Then
                If (Not (connect Is Nothing)) Then
                    If (connect.TestDBConnection) Then
                        If (System.IO.File.Exists(tempFilepath)) Then
                            Me.Visible = False
                            Me.ShowInTaskbar = False
                            CommandLine = True
                            path = txtFilePath.Text
                            tmrStartCMD.Start()
                        Else
                            LogError("File does not exist") ', , logWriter)
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        LogError("Database Connection Failed") ', , logWriter)
                        Me.Close()
                        Exit Sub
                    End If
                Else
                    LogError("No Database Connection") ', , logWriter)
                    Me.Close()
                    Exit Sub
                End If
            Else
                LogError("No Connection Specified") ', , logWriter)
                Me.Close()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        btnOpen.Enabled = False
        If (ofdLoader.ShowDialog = Windows.Forms.DialogResult.OK) Then
            txtFilePath.Text = ofdLoader.FileName
            Try
                If Not (table Is Nothing) Then
                    table.Clear()
                End If
                file = New clsFile(connect, txtFilePath.Text)
                dgvSites.DataSource = New DataTable("EMPTY")
                AllowClicks(False)
                tmrLoadProgress.Enabled = True
                GC.Collect()
            Catch err As ExitError

            Catch ex As Exception
                LogError("Error Loading " & file.MyType & " File", ex)
            End Try
        End If
        btnOpen.Enabled = True
    End Sub

    Private Sub btnCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommit.Click
        btnOpen.Enabled = False
        btnCommit.Enabled = False
        Try
            Dim rows As Integer
            lblLoadingType.Text = "Committing file to database. This may take a while."
            rows = file.CommitTable()

            If (rows > 0) Then
                ShowUpdate(rows)
                ResetForm()
            Else
                MsgBox("There was an error committing this file to the database." & vbCrLf & "Please read the log file to determine where the error occurred." & vbCrLf & "No data was committed to the database.", MsgBoxStyle.Critical, "Error Committing Data")
                lblLoadingType.Text = "Error committing this file."
                table = New DataTable("ERROR")
                dgvSites.DataSource = table
            End If
            dgvSites.DataSource = table
        Catch ExEr As ExitError
            table = New DataTable("ERROR")
            dgvSites.DataSource = table
        Catch ex As Exception
            LogError("Error Committing " & file.MyType & " File", ex)
            table = New DataTable("ERROR")
            dgvSites.DataSource = table
        End Try
        btnOpen.Enabled = True
    End Sub

    Private Sub tmrStartCMD_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStartCMD.Tick
        tmrStartCMD.Stop()
        Console.WriteLine(Now.ToLongTimeString)
        Try
            If Not (table Is Nothing) Then
                table.Clear()
            End If
            file = New clsFile(connect, path)
            tmrLoadProgress.Enabled = True
            GC.Collect()
        Catch ExEr As ExitError
            Me.Close()
        Catch ex As Exception
            LogError("Error Committing " & file.MyType & " File", ex)
        End Try
    End Sub

    Private Sub tsmiOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiFile_Open.Click
        btnOpen.PerformClick()
    End Sub
    Private Sub tsmiFile_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiFile_Exit.Click
        Close()
    End Sub

    Protected Overrides Sub Finalize()
        FreeConsole()
        writer.Close()
        MyBase.Finalize()
    End Sub

    Private Sub tmrLoadProgress_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLoadProgress.Tick
        Static last As Integer = 0
        Static oldRowCount As Integer = 0

        If file.FileLoadPercent >= 100 Then
            tmrLoadProgress.Enabled = False
            FileLoaded()
        ElseIf file.FileLoadPercent > 0 Then

            If (CommandLine) Then
                If CInt(file.FileLoadPercent / 10) > last Then
                    last = CInt(file.FileLoadPercent / 10)
                    Console.WriteLine("Opening File: " & last * 10 & "%.")
                End If
            Else
                If (oldRowCount < 20) Then
                    table = file.SmallViewTable
                    oldRowCount = table.Rows.Count
                    dgvSites.AutoGenerateColumns = True
                    dgvSites.DataSource = table
                End If
                lblLoadingType.Text = "Opening File: " & CInt(file.FileLoadPercent) & "%."
            End If
        End If
    End Sub


    Private Sub FileLoaded()
        Try
            If (CommandLine) Then
                Dim tempFile As clsFile = file
                file = tempFile.GetTableType
                tempFile = Nothing
                LogUpdate("You are loading """ & file.MyType & """")
                Dim rows As Integer
                rows = file.CommitTable()

                If (rows > 0) Then
                    LogUpdate("Committed " & rows & " rows to the database.")
                Else
                    LogError("No Data Commited to the database")
                End If

                Me.Close()
            Else
                Dim tempFile As clsFile = file
                file = tempFile.GetTableType
                tempFile = Nothing
                lblLoadingType.Text = "You are loading " & file.MyType
                table = file.ViewTable
                dgvSites.AutoGenerateColumns = True
                dgvSites.DataSource = table
                If (table.Rows.Count > 0) Then
                    btnCommit.Enabled = True
                End If
                AllowClicks(True)
                btnOpen.Enabled = True
            End If
        Catch ex As Exception
            'Log: ERROR
            LogError(ex)
            ResetForm()
            If (CommandLine) Then
                Me.Close()
            End If
        End Try
    End Sub

    Private Sub AllowClicks(ByVal value As Boolean)
        dgvSites.Enabled = value
    End Sub

    Private Sub ResetForm()
        txtFilePath.Text = ""
        table = New DataTable("EMPTY")
        btnOpen.Enabled = True
        lblLoadingType.Text = "You are Loading ""Nothing"""
        btnCommit.Enabled = False
        dgvSites.DataSource = table
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim temp As New frmAbout
        temp.ShowDialog()
    End Sub
End Class
