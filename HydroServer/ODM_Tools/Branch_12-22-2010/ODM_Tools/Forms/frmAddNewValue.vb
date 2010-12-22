'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Imports System.Windows.Forms

Public Class frmAddNewValue

    'Last Documented 5/15/07

#Region " Member Variables "
    Private Const m_CreateNew As String = "<Create New>" 'Place holder in item picker
    Private Const m_None As String = "<None>" 'Place holder in item picker
    Private Const m_NoCensor As String = "nc - not censored" 'Default Censor Code value

    Friend m_DataValue As Double 'The data value to return
    Friend m_QualifierID As Integer = -1 'The Qualifier ID to return
    Friend m_CensorCode As String 'The censor code to return
    Friend m_DateTime As Date 'The date/time to return
    Friend m_UtcOffset As Double 'The utc offset to return
    Friend m_UtcDateTime As Date 'the UTC date/time to return
    Friend m_SampleID As Integer = -1 'the Sample ID to return
    Private m_OffsetType As String = "<None>" 'The offset type to return
    Private m_OffsetUnits As String = "<None>" 'The offset units to return
    Friend m_OffsetValue As Double 'The offset value to return
#End Region

#Region " Form Control Functions "

    Public Sub New(Optional ByVal e_OffsetType As String = m_None, Optional ByVal e_OffsetUnits As String = m_None)
        'Input:     e_offsetType -> The Offset type for the new point
        '           e_offsetunits -> The Offset units for the new point

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If e_OffsetType <> "" Then
            m_OffsetType = e_OffsetType
        End If
        If e_OffsetUnits <> "" Then
            m_OffsetUnits = e_OffsetUnits
        End If
    End Sub

    Private Sub frmAddNewValue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Sets all the Default Values and Information
        'Loads lists of qualifiers, censorcodes, and samples

        dtpANVDateTime.Value = Now
        dtpANVDateTime.MaxDate = Now.AddMonths(1)
        cboANVUtcOffset.Text = (Now - Date.UtcNow).TotalHours
        txtANVOffsetType.Text = m_OffsetType
        If m_OffsetType = m_None Then
            txtANVOffsetValue.Enabled = False
        Else
            txtANVOffsetValue.Enabled = True
            txtANVOffsetUnits.Text = m_OffsetUnits
        End If

        LoadQualifiers()
        LoadCensorCodes()
        LoadSamples()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Checks if data is all valid then returns it to the calling form
        'Output:    Pops up a message box if there is a problem with the data
        '           The form returns dialogresult.ok if everything is correct
        Try
            If Not (IsNumeric(txtANVDataValue.Text)) Then
                ShowError("Please enter a valid numeric value for the Data Value.")
            ElseIf (m_OffsetType <> m_None) And (Not IsNumeric(txtANVOffsetValue.Text)) Then
                ShowError("Please enter a valid numeric value for the Offset Value.")
            ElseIf (cboANVQualifier.SelectedIndex < 0) Then
                ShowError("Please select/create a Qualifier.", New Exception)
            ElseIf (cboANVCensorCode.SelectedIndex < 0) Then
                ShowError("Please select a Censor Code.  Default is 'nc' for Not Censored.")
            ElseIf (cboANVUtcOffset.SelectedIndex < 0) Then
                ShowError("Please select the UTC Offset (Add 1 for DST).")
            ElseIf (cboANVSample.SelectedIndex < 0) Then
                ShowError("Please select a Sample.  Default if '<None>' if data did not come from a sample.")
            Else
                m_DataValue = CDbl(txtANVDataValue.Text)
                If cboANVQualifier.SelectedItem <> m_None Then
                    m_QualifierID = GetQualifierIDFromDB(Split(cboANVQualifier.SelectedItem, " - ", 2)(0), Split(cboANVQualifier.SelectedItem, " - ", 2)(1))
                End If
                m_CensorCode = Split(cboANVCensorCode.SelectedItem, " - ")(0)
                m_DateTime = dtpANVDateTime.Value
                m_UtcOffset = cboANVUtcOffset.SelectedItem
                m_UtcDateTime = m_DateTime.AddHours(-m_UtcOffset)
                If cboANVSample.SelectedItem <> m_None Then
                    m_SampleID = GetSampleIDFromDB(Split(cboANVSample.SelectedItem, " - ", 2)(1), Split(cboANVSample.SelectedItem, " - ", 2)(0))
                End If
                If txtANVOffsetValue.Text <> "" Then m_OffsetValue = CDbl(txtANVOffsetValue.Text)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Closes the form and returns a cancel to the calling form  
        'Output:   Returns dialogResult.cancel 
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dtpANVDateTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpANVDateTime.ValueChanged
        'When the DT value is changed, it updates the UTCDT text
        If cboANVUtcOffset.Text <> "" Then
            Dim utcDateTime As Date 'Used to format the UTC date time
            utcDateTime = dtpANVDateTime.Value.AddHours(-Val(cboANVUtcOffset.SelectedItem))
            txtANVUtcDateTime.Text = utcDateTime.ToString
        End If
    End Sub

    Private Sub cboANVUtcOffset_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboANVUtcOffset.SelectedIndexChanged
        'When the UTC Offset value is changed it updates the UTCDT Text
        If cboANVUtcOffset.Text <> "" Then
            Dim utcDateTime As Date 'Used to format the utc Date Time
            utcDateTime = dtpANVDateTime.Value.AddHours(-Val(cboANVUtcOffset.SelectedItem))
            txtANVUtcDateTime.Text = utcDateTime.ToString
        End If
    End Sub

    Private Sub cboANVQualifier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboANVQualifier.SelectedIndexChanged
        'If m_CreateNew was selected, then create a new qualifier
        Try
            '1. See if m_CreateNew item = selected
            If cboANVQualifier.Text = m_CreateNew Then
                'show Create Qualifier form
                Dim newQlfy As New frmCreateNewQualifier 'Form for creating the new qualifier
                newQlfy.Owner = Me
                If newQlfy.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'reload Qualifiers, select one just created
                    LoadQualifiers()
                    cboANVQualifier.SelectedItem = newQlfy.m_QlfyCode & " - " & newQlfy.m_QlfyDesc
                End If

                'release resources
                newQlfy = Nothing
            End If

            '2. enable OK Button
            btnOK.Enabled = True

        Catch ex As Exception
            ShowError("An Error occured when a new Qualifier was selected when Flagging Values." & vbCrLf & "Message = " & ex.Message, New Exception)
        End Try
    End Sub

    Private Sub txtANVOffsetValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtANVOffsetValue.TextChanged
        'Check if the text is a valid numerical expression, or part of one
        'Output:    Removes any invalid characters
        If (Not IsNumeric(txtANVDataValue.Text)) And (Not txtANVDataValue.Text = "-") And (Not txtANVDataValue.Text = "+") And (Not txtANVDataValue.Text = ".") Then
            Dim i As Integer 'counter variable
            i = txtANVDataValue.SelectionStart - System.Text.RegularExpressions.Regex.Matches(txtANVDataValue.Text, g_NumericExpressionPatern).Count
            If i <= 0 Then i = 1
            txtANVDataValue.Text = System.Text.RegularExpressions.Regex.Replace(txtANVDataValue.Text, g_NumericExpressionPatern, "")
            txtANVDataValue.Select(i, 0)
        End If
    End Sub

    Private Sub txtANVDataValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtANVDataValue.TextChanged
        'Check if the text is a valid numerical expression, or part of one
        'Output:    Removes any invalid characters
        If System.Text.RegularExpressions.Regex.Match(txtANVDataValue.Text, g_NumericExpressionPatern).Success Then
            Dim i As Integer 'counter variable
            i = txtANVDataValue.SelectionStart - System.Text.RegularExpressions.Regex.Matches(txtANVDataValue.Text, g_NumericExpressionPatern).Count
            If i <= 0 Then i = 1
            txtANVDataValue.Text = System.Text.RegularExpressions.Regex.Replace(txtANVDataValue.Text, g_NumericExpressionPatern, "")
            txtANVDataValue.Select(i, 0)
        End If
    End Sub

#End Region

#Region " Loading Functions "

	Private Sub LoadQualifiers()
        'Loads all Qualifiers   
        'Output:    Puts the qualifiers into a ComboBox
		Try
            Dim quals(,) As String '2D Array of Strings containing all necesary Qualifier Data
            Dim x As Integer 'Counter Variable
            Dim fields() As String = {db_fld_QlfyID, db_fld_QlfyCode, db_fld_QlfyDesc} 'Array of strings containing the desired field names

			'1. Clear out all data from cboxQualifier
			cboANVQualifier.Items.Clear()

			'2. Add m_None value
			cboANVQualifier.Items.Add(m_None)

			'2. Load available Qualifiers from DB
            quals = LoadDataList(db_tbl_Qualifiers, fields)
            For x = 0 To quals.GetUpperBound(1)
                cboANVQualifier.Items.Add(quals(1, x) & " - " & quals(2, x))
			Next

			'3. Add m_CreateNew value
			cboANVQualifier.Items.Add(m_CreateNew)

			'4. Select first one in list as default
			cboANVQualifier.SelectedIndex = 0

		Catch ex As Exception
            ShowError("An Error occurred while loading the Qualifiers list." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

	Private Sub LoadCensorCodes()
        'Loads all CensorCodes   
        'Output:    Puts the censorcodes into a ComboBox   
		Try
            Dim codes(,) As String '2D Array of Strings containing all necesary CensorCode Data
            Dim x As Integer 'Counter Variable
            Dim fields() As String = {db_fld_CV_Term, db_fld_CV_Definition} 'Array of strings containing the desired field names

			'1. Clear out all data from cboxQualifier
			cboANVCensorCode.Items.Clear()

			'2. Load available Censor Codes from DB
            codes = LoadDataList(db_tbl_CensorCodeCV, fields)
            For x = 0 To codes.GetUpperBound(1)
                cboANVCensorCode.Items.Add(codes(0, x) & " - " & codes(1, x))
			Next

			'4. Select first one in list as default
			cboANVCensorCode.SelectedItem = m_NoCensor

		Catch ex As Exception
            ShowError("An Error occurred while loading the Censor Codes list." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

	Private Sub LoadSamples()
        'Loads all Samples
        'Output:    Puts the Samples into a ComboBox   
		Try
            Dim samples(,) As String '2D Array of Strings containing all necesary Sample Data
            Dim x As Integer 'Counter Variable
            Dim fields() As String = {db_fld_SampleLabCode, db_fld_SampleType} 'Array of strings containing the desired field names

			'1. Clear out all data from cboxQualifier
			cboANVSample.Items.Clear()

			'2. Create an empty Sample
			cboANVSample.Items.Add(m_None)

			'3. Load available Qualifiers from DB
            samples = LoadDataList(db_tbl_Samples, fields)
            For x = 0 To samples.GetUpperBound(1)
                cboANVSample.Items.Add(samples(0, x) & " - " & samples(1, x))
			Next

			'4. Select first one in list as default
			cboANVSample.SelectedIndex = 0

		Catch ex As Exception
            ShowError("An Error occurred while loading the Samples list." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

#End Region

End Class
