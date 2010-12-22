'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class frmEditFlagValues
	'Last Documented 5/15/07

#Region " Member Variables "
    Private Const m_CreateNew As String = "<Create New>" 'Place holder in item picker
    Friend m_QualifierCode As String 'Qualifier Code to return
    Friend m_QualifierDesc As String 'Qualifier Description to return
#End Region

#Region " Form Functionality "

    Private Sub frmEditFlagValues_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Loads the existing qualifiers before the form loads
        Try
            '1. Load Qualifiers
            LoadQualifiers()

        Catch ex As Exception
            ShowError("An Error occurred while loading the Flag Values form. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub cboxQualifier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxQualifier.SelectedIndexChanged
        'If new qualifier is selected, create a new qualifier
        Try
            '1. See if m_CreateNew item = selected
            If cboxQualifier.Text = m_CreateNew Then
                'show Create Qualifier form
                Dim newQlfy As New frmCreateNewQualifier 'Form used to create a new qualifier
                newQlfy.Owner = Me
                If newQlfy.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'reload Qualifiers, select one just created
                    LoadQualifiers()
                    cboxQualifier.SelectedItem = newQlfy.m_QlfyCode & " - " & newQlfy.m_QlfyDesc
                End If

                'release resources
                newQlfy = Nothing
            End If

            '2. enable OK Button
            btnOk.Enabled = True

        Catch ex As Exception
            ShowError("An Error occured when a new Qualifier was selected when Flagging Values." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'Stores the Qualifier Code and Description so parent form can access
        'Output: m_QualifierCode -> String containing the qualifier code to return
        '        m_QualifierDesc -> String containing the qualifier Description to return
        Try
            '1. set m_Qualifier so can access sel value from Main Form
            m_QualifierCode = Split(cboxQualifier.SelectedItem.ToString, " - ")(0)
            m_QualifierDesc = Split(cboxQualifier.SelectedItem.ToString, " - ")(1)

            '2. set dialog result = ok
            Me.DialogResult = Windows.Forms.DialogResult.OK
            '3. close the form
            Me.Close()
        Catch ex As Exception
            ShowError("An Error occurred when the OK button was selected while Flagging Values." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'In case user wants to cancel
        'Output: Returns DialogResult.Cancel
        Try
            '1. clear out m_Qualifier (set = "")
            m_QualifierCode = ""
            m_QualifierDesc = ""
            '2. set dialog result = cancel
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            '3. close the form
            Me.Close()
        Catch ex As Exception
            ShowError("An Error occurred when the Cancel button was selected while Flagging Values." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Loading Functions "

    Private Sub LoadQualifiers()
        'Loads the qualifiers from the DB
        'Input:  Qualifiers from DB
        'Output: Writes the Qualifiers to cboxQualifier and adds NewQualifer item
        Try
            Dim quals(,) As String '2D Array of string used to hold desired Qualifier Information
            Dim x As Integer 'Counter Variable
            Dim fields() As String = {db_fld_QlfyID, db_fld_QlfyCode, db_fld_QlfyDesc} 'Array of strings containing the desired field names

            '1. Clear out all data from cboxQualifier
            cboxQualifier.Items.Clear()

            '2. Load available Qualifiers from DB
            quals = LoadDataList(db_tbl_Qualifiers, fields)
            For x = 0 To quals.GetUpperBound(1)
                cboxQualifier.Items.Add(quals(1, x) & " - " & quals(2, x))
            Next

            '3. Add m_CreateNew value
            cboxQualifier.Items.Add(m_CreateNew)

            '4. Select first one in list as default
            cboxQualifier.SelectedIndex = 0

        Catch ex As Exception
            ShowError("An Error occurred while loading the Qualifiers list when Flagging Values." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

End Class