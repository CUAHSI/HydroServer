Imports System.IO

Partial Public Class WebDataLoader
    Inherits System.Web.UI.Page


    Private table As New DataTable
    Private WithEvents _file As clsFile
    Private connect As clsConnection
    Private path As String
    Friend WithEvents tmrLoadProgress As New Timer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim connection As New clsConnection
            Dim tempFilepath As String = ""
            Dim tempLog As String = ""
            Dim cmdConnection As Integer = 0
            AttachConsole(-1)
            CommandLine = True


            If cmdConnection < 5 Then
                CommandLine = False
            End If

            connection = New clsConnection(Session("ServerAddress").ToString, Session("DatabaseName").ToString, 1, False, Session("UserID").ToString, Session("Password").ToString)

            If (connection.ConnectionString <> "") Then
                If (connection.TestDBConnection()) Then
                    connect = connection
                Else
                    Response.Redirect("Login.aspx")
                    Exit Sub
                End If
            Else
                Response.Redirect("Login.aspx")
                Exit Sub
            End If

        Catch
            Response.Redirect("Login.aspx")
        End Try

        Try
            _file = New clsFile(connect, Session("FilePath").ToString)
        Catch
            btnCommit.Visible = False
            btnCancel.Visible = False
        End Try

    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
        If fuOpenFilePath.HasFile Then
            Try
                If Not (table Is Nothing) Then
                    table.Clear()
                End If

                lblstatus.Text = "Uploading file to server. This may take a while."

                UploadThisFile(fuOpenFilePath)
                lblstatus.Text = "File Uploaded"

                _file = New clsFile(connect, "C:/temp/" + System.IO.Path.GetFileName(fuOpenFilePath.PostedFile.FileName).ToString)
                Session("FilePath") = "C:/temp/" + System.IO.Path.GetFileName(fuOpenFilePath.PostedFile.FileName).ToString

                dgvData.Enabled = True


                FileLoaded()

                dgvData.DataBind()

                btnCommit.Enabled = True
                btnCommit.Visible = True
                btnCancel.Visible = True
                btnUpload.Visible = False
                fuOpenFilePath.Visible = False
            Catch ExEr As ExitError
                table = New DataTable("ERROR")
                dgvData.DataSource = table
            Catch ex As Exception
                ''LogError("Error Committing " & _file.MyType & " File", ex)
                table = New DataTable("ERROR")
                dgvData.DataSource = table
            End Try


        Else
            lblstatus.Text = "Please select a file to upload!"
        End If
    End Sub

    Protected Sub btnCommit_click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCommit.Click
        'btnOpen.Enabled = False
        Try
            'Dim commit As String = ""
            Dim commit As clsTableCount
            lblstatus.Text = "Committing file to database. This may take a while."
            Dim tempFile As clsFile = _file
            _file = tempFile.GetTableType
            tempFile = Nothing
            commit = _file.CommitTable()
            Session("Saved") = commit
            lblstatus.Text = "Rows Commited"
            'lblstatus.Text = "Successful committed file."
            If (commit.Count = 0) Then
                MsgBox("There was an error committing this file to the database.<br>Please read the log file to determine where the error occurred.<br>No data was committed to the database.", MsgBoxStyle.Critical, "Error Committing Data")
                lblstatus.Text = "There was an error committing this file to the database."
            End If
            btnCommit.Visible = False
            btnCancel.Visible = False
            btnUpload.Visible = True
            fuOpenFilePath.Visible = True
            Response.Redirect("ConfirmationPage.aspx")
        Catch ex As Exception
            ''LogError("Error Committing " & _file.MyType & " File", ex)
            lblstatus.Text = ex.Message
            btnCommit.Enabled = False
        End Try
        'btnOpen.Enabled = True
    End Sub


    Private Sub FileLoaded()
        Try
            
            Dim tempFile As clsFile = _file
            _file = tempFile.GetTableType
            tempFile = Nothing
            lblstatus.Text = "You are loading " & _file.MyType
            table = _file.ViewTable


            dgvData.AutoGenerateColumns = True
            dgvData.DataSource = table
            'If (table.Rows.Count > 0) Then
            '    btnUpload.Enabled = True
            'End If
            AllowClicks(True)
            fuOpenFilePath.Enabled = True

        Catch ex As Exception
            If (CommandLine) Then

            End If
        End Try
    End Sub

    Private Sub AllowClicks(ByVal value As Boolean)
        dgvData.Enabled = value
    End Sub

    Protected Sub UploadThisFile(ByVal upload As FileUpload)
        If upload.HasFile Then
            If Not Directory.Exists("C:/temp/") Then
                Directory.CreateDirectory("C:/temp/")
            End If
            Dim theFileName As String = ("C:/temp/" + upload.FileName)
            If File.Exists(theFileName) Then
                File.Delete(theFileName)
            End If
            upload.SaveAs(theFileName)
        End If
    End Sub


    Public Sub err(ByVal text As String)
        lblstatus.Text = text
    End Sub

    Private Sub dgvData_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgvData.RowCreated
        'e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ccaaaa';")
        If e.Row.RowIndex = 0 Then
            e.Row.Cells(0).Width = 5000
        End If

    End Sub


    'Protected Sub dgvData_DataBinding(ByVal sender As Object, ByVal e As EventArgs) Handles dgvData.DataBound
    '    dgvData.Columns(0).ItemStyle.Width = 500
    '    dgvData.DataBind()
    'End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        fuOpenFilePath.Visible = True
        btnUpload.Visible = True
        btnCommit.Visible = False
        btnCancel.Visible = False

        table = New DataTable("NEW")
        dgvData.DataSource = table
        DataBind()
        lblstatus.Text = ""
    End Sub


End Class