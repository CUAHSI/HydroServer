'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class frmCreateNewVariable

#Region "Member Variables"
	Dim m_varCode As String
	Dim m_varName As String
	Dim m_speciation As String
	Dim m_varUnits As String
	Dim m_varUnitsID As Integer = -1
	Dim m_tsValue As Double
	Dim m_tsUnits As String
	Dim m_tsUnitsID As Integer = -1
	Dim m_valueType As String
	Dim m_dataType As String
	Dim m_genCategory As String
	Dim m_sampleMed As String
	Dim m_noDataVal As Double
	Dim m_IsRegular As Boolean
	Dim m_deriveMethod As String
	Dim m_Loading As Boolean
#End Region

#Region "Form Control Functions"

	Public Sub New(ByVal tsValue As Double, ByVal tsUnits As String, ByVal tsUnitsID As Integer, ByVal valueType As String, ByVal dataType As String, ByVal genCategory As String, ByVal sampleMedium As String, ByVal noDataVal As Double, ByVal isRegular As Boolean, ByVal deriveMethod As String, ByVal varName As String, ByVal varUnits As String, ByVal speciation As String)
		'this function creates a new instance of the frmCreateNewVariable form
		'Inputs:  tsValue -> the time support value for the new variable
		'		  tsUnits -> the time support Units for the new variable -> for display only
		'		  tsUnitsID -> the ID for the time support units  -> for creating the new variable only
		'		  valueType -> the valueType value for the new variable
		'		  data Type -> the dataType value for the new variable
		'		  genCategory -> the general category value for the new variable
		'		  sampleMedium -> the sample medium value for the new variable
		'		  noDataVal -> the no data value for the new variable
		'		  isRegular -> the isRegular value for the new variable
		'		  deriveMethod -> the method using to derive the data series -> controls what may be selected in the Variable name combo-box
		'         varName -> the variable name to allow -> only used for certain derive methods (aggregate,smoothing): can be "" for algebraic derive method
		'		  varUnits -> the variable units to allow -> only used for certain derive methods (aggregate,smoothing): can be "" for algebraic derive method
		'         speciation -> the speciation to allow -> only used for certain derive methods (aggregate,smoothing): can be "" for algebraic derive method
		'Outputs: None
		MyBase.New()
		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

		'1. set member variables
		m_tsValue = tsValue
		m_tsUnits = tsUnits
		m_tsUnitsID = tsUnitsID
		m_valueType = valueType
		m_dataType = dataType
		m_genCategory = genCategory
		m_sampleMed = sampleMedium
		m_noDataVal = noDataVal
		m_IsRegular = isRegular
		m_deriveMethod = deriveMethod
		m_varName = varName
		m_varUnits = varUnits
		m_speciation = speciation

		'2. set that loading the form
		m_Loading = True
	End Sub

	Private Sub frmCreateNewVariable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'Loads and Initializes the frmCreateNewVariable form when it is shown
		'the inputs/outputs are standard for form events
		Try
			'1. Load ReadOnly Info
			LoadReadOnly()
			'2. Load Selectable Info
			'Variable Code
			tboxVarCode.Text = ""
			'Variable Names
			LoadVarNames()
			'Variable Units
			LoadVarUnits()
			'Speciation
			LoadSpeciation()

			'3. Enable/Disable Create button
			If HaveValidSelParameters() Then
				'enable create btn
				btnCreateVariable.Enabled = True
			Else
				btnCreateVariable.Enabled = False
			End If

			'5. Set that done loading the form
			m_Loading = False
		Catch ex As Exception
			ShowError("An Error occurred while loading the form to Derive a Data Series." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

	Private Sub btnCreateVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateVariable.Click
		Try
			'create the new variable in the database
			If Not (CreateNewVariable()) Then
				'don't close, allow user to try again
				Exit Try
			Else
				'variable successfully created, close form = OK
				Me.DialogResult = Windows.Forms.DialogResult.OK
				'close the form
				Me.Close()
			End If
		Catch ex As Exception
			ShowError("An Error occurred while creating the new Variable in the Database." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		'Handles the Cancel Button click, closes the form
		'the inputs/outputs are standard for form events

		'set that clicked cancel
		Me.DialogResult = Windows.Forms.DialogResult.Cancel
		'close the form
		Me.Close()
	End Sub

#End Region

#Region "Data Selection Functionality"

	Private Sub tboxVarCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxVarCode.KeyPress
		'see if enter key = pressed, if so, validate
		Select Case e.KeyChar
			Case vbCr, vbCrLf, vbLf
				tboxVarCode_Validating(sender, New System.ComponentModel.CancelEventArgs())
		End Select
	End Sub

	Private Sub tboxVarCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxVarCode.Validating
		Dim varCode As String
		Dim query As String
		Dim varCodeDT As DataTable
		Try
			If Not (m_Loading) Then
				'1. see if have a value
				If tboxVarCode.Text <> "" Then
					'2. see if it exists in the database already
					'get the variable code
					varCode = tboxVarCode.Text
					'check the database for the specified variable code
					query = "SELECT * FROM " & db_tbl_Variables & " WHERE " & db_fld_VarCode & " = '" & FormatStringForQueryFromDB(varCode) & "' ORDER BY " & db_fld_VarID
					varCodeDT = OpenTable("checkVarCode", query, g_CurrConnSettings)
					If Not (varCodeDT Is Nothing) AndAlso varCodeDT.Rows.Count > 0 Then
						'there was a value returned from the database -> this code already exists
						MsgBox("The Variable Code that you entered already exists in the database.  Duplicate Codes cannot exist in the database!!  Please specify a different Variable Code.", MsgBoxStyle.Exclamation)
						'disable create btn
						btnCreateVariable.Enabled = False
						'exit
						Exit Try
					End If

					'check to see other parameters = good, if so, enable create btn
					If HaveValidSelParameters() Then
						btnCreateVariable.Enabled = True
					Else
						btnCreateVariable.Enabled = False
					End If
				Else
					'disable create btn
					btnCreateVariable.Enabled = False
				End If
			End If
		Catch ex As Exception
			ShowError("An Error occurred while validating the Variable Code specified." & vbCrLf & "Message = " & ex.Message, ex)
			'disable create btn
			btnCreateVariable.Enabled = False
		End Try
	End Sub

	Private Sub cboxVarName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxVarName.SelectedIndexChanged
		Try
			If Not (m_Loading) Then
				'1. see if selected index is valid
				If cboxVarName.SelectedIndex >= 0 Then
					'check to see other parameters = good, if so, enable create btn
					If HaveValidSelParameters() Then
						btnCreateVariable.Enabled = True
					Else
						btnCreateVariable.Enabled = False
					End If
				Else
					'disable create btn
					btnCreateVariable.Enabled = False
				End If
			End If
		Catch ex As Exception
			ShowError("An Error occurred when a new Variable Name was selected." & vbCrLf & "Message = " & ex.Message, ex)
			'disable create btn
			btnCreateVariable.Enabled = False
		End Try
	End Sub

	Private Sub cboxVarUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxVarUnits.SelectedIndexChanged
		Try
			If Not (m_Loading) Then
				'1. see if selected index is valid
				If cboxVarUnits.SelectedIndex >= 0 Then
					'check to see other parameters = good, if so, enable create btn
					If HaveValidSelParameters() Then
						btnCreateVariable.Enabled = True
					Else
						btnCreateVariable.Enabled = False
					End If
				Else
					'disable create btn
					btnCreateVariable.Enabled = False
				End If
			End If
		Catch ex As Exception
			ShowError("An Error occurred when new Variable Units were selected." & vbCrLf & "Message = " & ex.Message, ex)
			'disable create btn
			btnCreateVariable.Enabled = False
		End Try
	End Sub

	Private Sub cboxSpeciation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxSpeciation.SelectedIndexChanged
		Try
			If Not (m_Loading) Then
				'1. see if selected index is valid
				If cboxSpeciation.SelectedIndex >= 0 Then
					'check to see other parameters = good, if so, enable create btn
					If HaveValidSelParameters() Then
						btnCreateVariable.Enabled = True
					Else
						btnCreateVariable.Enabled = False
					End If
				Else
					'disable create btn
					btnCreateVariable.Enabled = False
				End If
			End If
		Catch ex As Exception
			ShowError("An Error occurred when a new Speciation was selected." & vbCrLf & "Message = " & ex.Message, ex)
			'disable create btn
			btnCreateVariable.Enabled = False
		End Try
	End Sub

#End Region

#Region "Loading Functions"

	Private Sub LoadReadOnly()
		Try
			'1.load the previously defined parameters for the variable
			'Time Support
			tboxTSValue.Text = m_tsValue
			tboxTSUnits.Text = m_tsUnits
			'Value Type
			tboxValueType.Text = m_valueType
			'Data Type
			tboxDataType.Text = m_dataType
			'General Category
			tboxGeneralCategory.Text = m_genCategory
			'Sample Medium
			tboxSampleMedium.Text = m_sampleMed
			'No Data Value
			tboxNoDataValue.Text = m_noDataVal
			'IsRegular
			tboxIsRegular.Text = m_IsRegular.ToString
		Catch ex As Exception
			ShowError("An Error occurred while loading the Defined Parameters for the Variable to create." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

	Private Sub LoadVarNames()
		Dim query As String
		Dim varNamesDT As Data.DataTable
		Dim varName As String
		Dim i As Integer

		Try
			'1. clear out any old data
			cboxVarName.Items.Clear()
			cboxVarName.Text = ""

			'2. Load Variable names based on m_DeriveMethod
			Select Case m_deriveMethod
				Case g_DeriveMethod_Smooth, g_DeriveMethod_Aggregate
					'load only the given variable name
					cboxVarName.Items.Add(m_varName)
					'select this value
					cboxVarName.SelectedIndex = 0
				Case g_DeriveMethod_Algebraic
					'load all variable names from the database
					'2. create the query
					query = "SELECT DISTINCT " & db_fld_CV_Term & " FROM " & db_tbl_VariableNameCV & " ORDER BY " & db_fld_CV_Term
					'3. get the variable names from the database
					varNamesDT = OpenTable("newVar_VarNames", query, g_CurrConnSettings)
					'validate data
					If Not (varNamesDT Is Nothing) AndAlso varNamesDT.Rows.Count > 0 Then
						'4. load variable names  into cboxVarName
						For i = 0 To varNamesDT.Rows.Count - 1
							If Not (varNamesDT.Rows(i).Item(db_fld_CV_Term) Is DBNull.Value) Then
								varName = varNamesDT.Rows(i).Item(db_fld_CV_Term)
							Else
								varName = " "
							End If
							cboxVarName.Items.Add(varName)
						Next i
					End If
					'5. release resources
					If Not (varNamesDT Is Nothing) Then
						varNamesDT.Dispose()
						varNamesDT = Nothing
					End If
			End Select
		Catch ex As Exception
			ShowError("An Error occurred while loading the available Variable Names from the database." & vbCrLf & "Message = " & ex.Message, ex)
			'release Resources
			If Not (varNamesDT Is Nothing) Then
				varNamesDT.Dispose()
				varNamesDT = Nothing
			End If
		End Try
	End Sub

	Private Sub LoadVarUnits()
		Dim query As String
		Dim varUnitsDT As Data.DataTable
		Dim varUnits As String
		Dim i As Integer

		Try
			'1. clear out any old data
			cboxVarUnits.Items.Clear()
			cboxVarUnits.Text = ""

			'2. Load Variable names based on m_DeriveMethod
			Select Case m_deriveMethod
				Case g_DeriveMethod_Smooth, g_DeriveMethod_Aggregate
					'load only the given variable name
					cboxVarUnits.Items.Add(m_varUnits)
					'select this value
					cboxVarUnits.SelectedIndex = 0
				Case g_DeriveMethod_Algebraic
					'load all variable units from the database
					'2. create the query
					query = "SELECT DISTINCT " & db_fld_UnitsName & " FROM " & db_tbl_Units & " ORDER BY " & db_fld_UnitsName
					'3. get the variable units from the database
					varUnitsDT = OpenTable("newVar_VarUnits", query, g_CurrConnSettings)
					'validate data
					If Not (varUnitsDT Is Nothing) AndAlso varUnitsDT.Rows.Count > 0 Then
						'4. load variable names  into cboxVarName
						For i = 0 To varUnitsDT.Rows.Count - 1
							If Not (varUnitsDT.Rows(i).Item(db_fld_UnitsName) Is DBNull.Value) Then
								varUnits = varUnitsDT.Rows(i).Item(db_fld_UnitsName)
							Else
								varUnits = " "
							End If
							cboxVarUnits.Items.Add(varUnits)
						Next i
					End If
					'5. release resources
					If Not (varUnitsDT Is Nothing) Then
						varUnitsDT.Dispose()
						varUnitsDT = Nothing
					End If
			End Select
		Catch ex As Exception
			ShowError("An Error occurred while loading the available Variable Units from the database." & vbCrLf & "Message = " & ex.Message, ex)
			'release resources
			If Not (varUnitsDT Is Nothing) Then
				varUnitsDT.Dispose()
				varUnitsDT = Nothing
			End If
		End Try
	End Sub

	Private Sub LoadSpeciation()
		'This function loads the Selectable Variable Speciation from the Database
		'Inputs:  None
		'Outputs: None
		Dim i As Integer 'counter
		Dim query As String	'the SQL query used to pull the Units to select from from the database
		Dim speciationDT As Data.DataTable 'the set of data retrieved from the Database -> values = loaded into cboxVarUnits
		Try
			'1. clear out any old data
			cboxSpeciation.Items.Clear()
			cboxSpeciation.Text = ""

			'2. Load Variable names based on m_DeriveMethod
			Select Case m_deriveMethod
				Case g_DeriveMethod_Smooth, g_DeriveMethod_Aggregate
					'load only the given variable name
					cboxSpeciation.Items.Add(m_speciation)
					'select this value
					cboxSpeciation.SelectedIndex = 0
				Case g_DeriveMethod_Algebraic
					'load all variable names from the database
					'2. get unique Speciation from the Database
					query = "SELECT DISTINCT " & db_fld_CV_Term & " FROM " & db_tbl_SpeciationCV & " ORDER BY " & db_fld_CV_Term

					speciationDT = OpenTable("newVar_Speciation", query, g_CurrConnSettings)
					'validate data
					If Not (speciationDT Is Nothing) AndAlso speciationDT.Rows.Count > 0 Then
						'2. load variable units into cboxVarUnits
						For i = 0 To speciationDT.Rows.Count - 1
							If Not (speciationDT.Rows(i).Item(db_fld_CV_Term) Is DBNull.Value) Then
								cboxSpeciation.Items.Add(speciationDT.Rows(i).Item(db_fld_CV_Term))
							End If
						Next i
					End If

					'3. Release resources
					If Not (speciationDT Is Nothing) Then
						speciationDT.Dispose()
						speciationDT = Nothing
					End If
			End Select

		Catch ex As Exception
			ShowError("An Error occurred while loading the available Speciation values from the database." & vbCrLf & "Message = " & ex.Message, ex)
			'Release resources
			If Not (speciationDT Is Nothing) Then
				speciationDT.Dispose()
				speciationDT = Nothing
			End If
		End Try
	End Sub

#End Region

#Region "Validation Functions"

	Private Function HaveValidSelParameters() As Boolean
		'this function return whether or not all of the selectable parameters are valid or not
		'Inputs:  None
		'Outputs: Boolean -> returns if selectable parameters are valid or not
		Dim validParams As Boolean = False
		Dim validCode As Boolean = False
		Dim validName As Boolean = False
		Dim validUnits As Boolean = False
		Dim validSpeciation As Boolean = False

		Try
			'1. see if a code has been specified
			If tboxVarCode.Text <> "" Then
				validCode = True 'value will already have been validated -> so know it is good
			End If

			'2. see if a variable name has been selected
			If cboxVarName.Text <> "" AndAlso cboxVarName.SelectedIndex >= 0 Then
				validName = True
			End If

			'3. see if the variable units have been selected
			If cboxVarUnits.Text <> "" AndAlso cboxVarUnits.SelectedIndex >= 0 Then
				validUnits = True
			End If

			'4.  see if the speciation has been selected
			If cboxSpeciation.Text <> "" AndAlso cboxSpeciation.SelectedIndex >= 0 Then
				validSpeciation = True
			End If

			'5. see if all of the values are valid
			If validCode AndAlso validName AndAlso validUnits AndAlso validSpeciation Then
				validParams = True
			End If

			'6. return validParams
			Return validParams
		Catch ex As Exception
			ShowError("An error occurred while validating the selectable parameters." & vbCrLf & "Message = " & ex.Message)
			validParams = False
		End Try
		Return validParams
	End Function

#End Region

#Region "Updating Functions"

	Private Function CreateNewVariable() As Boolean
		Dim varCode As String
		Dim varName As String
		Dim speciation As String
		Dim varUnitsID As Integer
		Dim newVarID As Integer = -1
		Try
			'1. get the info to create the new variable
			varCode = tboxVarCode.Text
			varName = cboxVarName.Text
			speciation = cboxSpeciation.Text
			varUnitsID = GetUnitsIDFromDB(cboxVarUnits.Text)

			'2. try to create the new variable
			newVarID = CreateNewVariableInDB(varCode, varName, speciation, varUnitsID, m_sampleMed, m_valueType, m_tsValue, m_tsUnitsID, m_dataType, m_genCategory, m_IsRegular, m_noDataVal)
			If newVarID < 0 Then
				MsgBox("Unable to create the new Variable in the Database!", MsgBoxStyle.Exclamation)
				'return false
				Exit Try
			End If

			'3. return true
			Return True
		Catch ex As Exception
			ShowError("An Error occurred while creating the new Variable in the Database." & vbCrLf & "Message = " & ex.Message)
		End Try
		Return False
	End Function

#End Region

End Class