'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class frmAdjustValues
    'Last Documented 5/15/07

#Region " Enumerations "

    'The possible types of adjustments to be made to the data
    Friend Enum adjustTypes 'The type of adjustment
        ADD
        MULTIPLY
        DRIFT
    End Enum

#End Region

#Region " Member Variables "

    Friend m_adjustType As adjustTypes 'Stores the type of adjustment to be made after the form has been closed
    Friend m_adjustValue As Double = 0 'Stores the value of the adjustment after the form has been closed

#End Region

#Region " Form Control Functions "

    Private Sub rbtnAVMAddConstant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAVMAddConstant.CheckedChanged
        'Enable/Disable txtAVMADD and lblAVMAdd
        txtAVMAdd.Enabled = rbtnAVMAddConstant.Checked
        lblAVMAdd.Enabled = rbtnAVMAddConstant.Checked
        If rbtnAVMAddConstant.Checked Then 'Set the adjustment type
            m_adjustType = adjustTypes.ADD
        Else
            txtAVMAdd.ResetText()
        End If
    End Sub

    Private Sub rbtnAVMMultConstant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAVMMultConstant.CheckedChanged
        'Enable/Disable txtAVMMultiply and lblAVMMultiply
        txtAVMMultiply.Enabled = rbtnAVMMultConstant.Checked
        lblAVMMultiply.Enabled = rbtnAVMMultConstant.Checked
        If rbtnAVMMultConstant.Checked Then 'Set the adjustment type
            m_adjustType = adjustTypes.MULTIPLY
        Else
            txtAVMMultiply.ResetText()
        End If
    End Sub

    Private Sub rbtnAVMLinearDrift_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAVMLinearDrift.CheckedChanged
        'Enable/Disable txtAVMDrift and lblAVMDrift
        txtAVMDrift.Enabled = rbtnAVMLinearDrift.Checked
        lblAVMDrift.Enabled = rbtnAVMLinearDrift.Checked
        If rbtnAVMLinearDrift.Checked Then 'Set the adjustment type
            m_adjustType = adjustTypes.DRIFT
        Else
            txtAVMDrift.ResetText()
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Check if all of the required data is valid then store the values
        'Output: Msgbox if error, otherwise save adjust value and type and return dialogresult.OK
        If rbtnAVMAddConstant.Checked Then
            If txtAVMAdd.Text = "0" Then
                ShowError("This value will not change the data.  Please enter a new value.")
            ElseIf Not IsNumeric(txtAVMAdd.Text) Then
                ShowError("Please enter a numeric value.")
            Else
                m_adjustValue = CDbl(txtAVMAdd.Text)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        ElseIf rbtnAVMMultConstant.Checked Then
            If txtAVMMultiply.Text = "0" Then
                ShowError("This value will set all data to 0.  Please enter a new value.")
            ElseIf txtAVMMultiply.Text = "1" Then
                ShowError("This value will not change the data.  Please enter a new value.")
            ElseIf Not IsNumeric(txtAVMMultiply.Text) Then
                ShowError("Please enter a numeric value.")
            Else
                m_adjustValue = CDbl(txtAVMMultiply.Text)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        ElseIf rbtnAVMLinearDrift.Checked Then
            If txtAVMDrift.Text = "0" Then
                ShowError("This value will not change the data.  Please enter a new value.")
            ElseIf Not IsNumeric(txtAVMDrift.Text) Then
                ShowError("Please enter a numeric value.")
            Else
                m_adjustValue = CDbl(txtAVMDrift.Text)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'In case user wants to cancel    
        'Output: Returns DialogResult.Cancel
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub txtAVMAdd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAVMAdd.TextChanged
        'Check if the text is a valid numerical expression, or part of one
        'Output: Removes all invalid characters from txtAVMAdd
        If (Not IsNumeric(txtAVMAdd.Text)) And (Not txtAVMAdd.Text = "-") And (Not txtAVMAdd.Text = "+") And (Not txtAVMAdd.Text = ".") Then
            Dim i As Integer 'Stores Cursor Position
            i = txtAVMAdd.SelectionStart - System.Text.RegularExpressions.Regex.Matches(txtAVMAdd.Text, g_NumericExpressionPatern).Count
            If i <= 0 Then i = 1
            txtAVMAdd.Text = System.Text.RegularExpressions.Regex.Replace(txtAVMAdd.Text, g_NumericExpressionPatern, "")
            txtAVMAdd.Select(i, 0)
        End If
    End Sub

    Private Sub txtAVMMultiply_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAVMMultiply.TextChanged
        'Check if the text is a valid numerical expression, or part of one
        'Output: Removes all invalid characters from txtAVMMultiply
        If Not IsNumeric(txtAVMMultiply.Text) Then
            Dim i As Integer 'Stores Cursor Position
            i = txtAVMMultiply.SelectionStart - System.Text.RegularExpressions.Regex.Matches(txtAVMMultiply.Text, g_NumericExpressionPatern).Count
            If i <= 0 Then i = 1
            txtAVMMultiply.Text = System.Text.RegularExpressions.Regex.Replace(txtAVMMultiply.Text, g_NumericExpressionPatern, "")
            txtAVMMultiply.Select(i, 0)
        End If
    End Sub

    Private Sub txtAVMDrift_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAVMDrift.TextChanged
        'Check if the text is a valid numerical expression, or part of one
        'Output: Removes all invalid characters from txtAVMDrift
        If Not IsNumeric(txtAVMDrift.Text) Then
            Dim i As Integer 'Stores Cursor Position
            i = txtAVMDrift.SelectionStart - System.Text.RegularExpressions.Regex.Matches(txtAVMDrift.Text, g_NumericExpressionPatern).Count
            If i <= 0 Then i = 1
            txtAVMDrift.Text = System.Text.RegularExpressions.Regex.Replace(txtAVMDrift.Text, g_NumericExpressionPatern, "")
            txtAVMDrift.Select(i, 0)
        End If
    End Sub

#End Region

End Class