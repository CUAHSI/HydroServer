'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class frmCreateNewQualifier
    'Last Documented 5/15/07

#Region " Member Variables "
    Friend m_QlfyCode As String 'Passes the qualifier code back once the form is closed
    Friend m_QlfyDesc As String 'Passes the qualifier desription back once the form is closed
    Private m_Qualifiers(,) As String 'Stores the qualifier codes and descriptions for validation
#End Region

#Region " Form Functionality "

    Private Sub frmCreateNewQualifier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Resets the textboxes and loads existing qualifiers from DB for validation
        Try
            '1. clear out anything from tboxQCode, tboxQDesc
            tboxQCode.Text = ""
            tboxQDesc.Text = ""

            '3. LoadQualifiers
            Dim fields() As String = {db_fld_QlfyCode, db_fld_QlfyDesc} 'Array of strings containing the desired field names
            m_Qualifiers = LoadDataList(db_tbl_Qualifiers, fields)

            '2. disable OK Button
            btnOk.Enabled = False

        Catch ex As Exception
            ShowError("An Error occurred while loading the form to Create A New Qualifier." & vbCrLf & "Message = " & ex.Message, ex)
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End Try
    End Sub

    Private Sub tboxQCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxQCode.KeyPress
        'Validate the text box upon pressing return    
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxQCode_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxQCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxQCode.Validating
        'Check if the input value is valid
        'Output: Messagebox if problem with selected data
        Try
            Dim x As Integer 'Counter Variable
            '1. See if input value already exists in DB, if so, show error, set e.Cancel = true
            For x = 0 To m_Qualifiers.GetLength(1) - 1
                If LCase(tboxQCode.Text) = LCase(m_Qualifiers(0, x)) Then
                    ShowError("Invalid Qualifier Code:  Qualifier Code already exists" & vbCrLf & "Please specify a unique Qualifier Code that does no already exist in the Database")
                    e.Cancel = True
                End If
            Next

            '2. If Description <> "", enable ok button, else disable it
            If (Not e.Cancel) And (tboxQCode.Text <> "") And (tboxQDesc.Text <> "") Then
                btnOk.Enabled = True
            Else
                btnOk.Enabled = False
            End If

        Catch ex As Exception
            ShowError("An Error occurred while validating the Qualifier Code when creating a new Qualifier." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxQDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxQDesc.KeyPress
        'Validate the textbox on pressing return
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxQDesc_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxQDesc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxQDesc.Validating
        'Check if the input value is valid
        'Output: Msgbox if problem with selected data
        Try
            Dim x As Integer 'Counter Variable
            '1. see if input value already exists in DB, if so, show error, set e.Cancel = true
            For x = 0 To m_Qualifiers.GetLength(1) - 1
                If LCase(tboxQDesc.Text) = LCase(m_Qualifiers(1, x)) Then
                    ShowError("Invalid Qualifier Code:  Qualifier Code already exists" & vbCrLf & "Please specify a unique Qualifier Code that does no already exist in the Database")
                    e.Cancel = True
                End If
            Next

            '2. If Code <> "", enable OK button, else disable it
            If (Not e.Cancel) And (tboxQCode.Text <> "") And (tboxQDesc.Text <> "") Then
                btnOk.Enabled = True
            Else
                btnOk.Enabled = False
            End If

        Catch ex As Exception
            ShowError("An Error occurred while validating the Qualifier Description when creating a new Qualifier." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'Stores the data in friend member variables, then creates the new Qualifier  
        'Output: Returns DialogResult.OK if successful
        Try
            '1. Set some variable so know what new Qualifier is -> from EditFlagValue form
            m_QlfyCode = tboxQCode.Text
            m_QlfyDesc = tboxQDesc.Text

            '2. Create New Qualifier in DB
            CreateNewQualifierInDB(m_QlfyCode, m_QlfyDesc)

            '3. Set dialog result = OK
            Me.DialogResult = Windows.Forms.DialogResult.OK

            '4. close form
            Me.Close()
        Catch ex As Exception
            ShowError("An Error occurred when the OK button was selected while creating a new Qualifier." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Cancels the form
        'Output: Returns DialogResult.Cancel  
        Try
            '1. set dialog result = cancel
            Me.DialogResult = Windows.Forms.DialogResult.Cancel

            '2. close form
            Me.Close()
        Catch ex As Exception
            ShowError("An Error occurred when the Cancel button was selected while creating a new Qualifier." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

End Class