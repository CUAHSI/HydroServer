<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateNewVariable
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
        Me.btnCreateVariable = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.gboxSelectableParameters = New System.Windows.Forms.GroupBox
        Me.cboxSpeciation = New System.Windows.Forms.ComboBox
        Me.cboxVarUnits = New System.Windows.Forms.ComboBox
        Me.lblSpeciation = New System.Windows.Forms.Label
        Me.lblVarUnits = New System.Windows.Forms.Label
        Me.cboxVarName = New System.Windows.Forms.ComboBox
        Me.lblVarName = New System.Windows.Forms.Label
        Me.lblVarCode = New System.Windows.Forms.Label
        Me.tboxVarCode = New System.Windows.Forms.TextBox
        Me.gboxDefinedParameters = New System.Windows.Forms.GroupBox
        Me.tboxIsRegular = New System.Windows.Forms.TextBox
        Me.lblIsRegular = New System.Windows.Forms.Label
        Me.tboxNoDataValue = New System.Windows.Forms.TextBox
        Me.tboxSampleMedium = New System.Windows.Forms.TextBox
        Me.tboxGeneralCategory = New System.Windows.Forms.TextBox
        Me.tboxValueType = New System.Windows.Forms.TextBox
        Me.tboxDataType = New System.Windows.Forms.TextBox
        Me.lblNoDataValue = New System.Windows.Forms.Label
        Me.lblDataType = New System.Windows.Forms.Label
        Me.lblGeneralCategory = New System.Windows.Forms.Label
        Me.gboxVarTimeSupport = New System.Windows.Forms.GroupBox
        Me.tboxTSUnits = New System.Windows.Forms.TextBox
        Me.tboxTSValue = New System.Windows.Forms.TextBox
        Me.lblTSUnits = New System.Windows.Forms.Label
        Me.lblTSValue = New System.Windows.Forms.Label
        Me.lblValueType = New System.Windows.Forms.Label
        Me.lblSampleMedium = New System.Windows.Forms.Label
        Me.gboxSelectableParameters.SuspendLayout()
        Me.gboxDefinedParameters.SuspendLayout()
        Me.gboxVarTimeSupport.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCreateVariable
        '
        Me.btnCreateVariable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateVariable.Location = New System.Drawing.Point(336, 320)
        Me.btnCreateVariable.Name = "btnCreateVariable"
        Me.btnCreateVariable.Size = New System.Drawing.Size(83, 24)
        Me.btnCreateVariable.TabIndex = 36
        Me.btnCreateVariable.Text = "Create"
        Me.btnCreateVariable.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(432, 320)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 24)
        Me.btnCancel.TabIndex = 37
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'gboxSelectableParameters
        '
        Me.gboxSelectableParameters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboxSelectableParameters.Controls.Add(Me.cboxSpeciation)
        Me.gboxSelectableParameters.Controls.Add(Me.cboxVarUnits)
        Me.gboxSelectableParameters.Controls.Add(Me.lblSpeciation)
        Me.gboxSelectableParameters.Controls.Add(Me.lblVarUnits)
        Me.gboxSelectableParameters.Controls.Add(Me.cboxVarName)
        Me.gboxSelectableParameters.Controls.Add(Me.lblVarName)
        Me.gboxSelectableParameters.Controls.Add(Me.lblVarCode)
        Me.gboxSelectableParameters.Controls.Add(Me.tboxVarCode)
        Me.gboxSelectableParameters.Location = New System.Drawing.Point(8, 8)
        Me.gboxSelectableParameters.Name = "gboxSelectableParameters"
        Me.gboxSelectableParameters.Size = New System.Drawing.Size(512, 120)
        Me.gboxSelectableParameters.TabIndex = 40
        Me.gboxSelectableParameters.TabStop = False
        Me.gboxSelectableParameters.Text = "Parameters to Select"
        '
        'cboxSpeciation
        '
        Me.cboxSpeciation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxSpeciation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboxSpeciation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxSpeciation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxSpeciation.FormattingEnabled = True
        Me.cboxSpeciation.Location = New System.Drawing.Point(384, 88)
        Me.cboxSpeciation.Name = "cboxSpeciation"
        Me.cboxSpeciation.Size = New System.Drawing.Size(120, 21)
        Me.cboxSpeciation.TabIndex = 15
        '
        'cboxVarUnits
        '
        Me.cboxVarUnits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxVarUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboxVarUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxVarUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxVarUnits.FormattingEnabled = True
        Me.cboxVarUnits.Location = New System.Drawing.Point(88, 88)
        Me.cboxVarUnits.Name = "cboxVarUnits"
        Me.cboxVarUnits.Size = New System.Drawing.Size(216, 21)
        Me.cboxVarUnits.TabIndex = 14
        '
        'lblSpeciation
        '
        Me.lblSpeciation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSpeciation.Location = New System.Drawing.Point(320, 90)
        Me.lblSpeciation.Name = "lblSpeciation"
        Me.lblSpeciation.Size = New System.Drawing.Size(64, 16)
        Me.lblSpeciation.TabIndex = 13
        Me.lblSpeciation.Text = "Speciation :"
        Me.lblSpeciation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVarUnits
        '
        Me.lblVarUnits.Location = New System.Drawing.Point(8, 90)
        Me.lblVarUnits.Name = "lblVarUnits"
        Me.lblVarUnits.Size = New System.Drawing.Size(88, 16)
        Me.lblVarUnits.TabIndex = 12
        Me.lblVarUnits.Text = "Variable Units :"
        Me.lblVarUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboxVarName
        '
        Me.cboxVarName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxVarName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboxVarName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxVarName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxVarName.FormattingEnabled = True
        Me.cboxVarName.Location = New System.Drawing.Point(88, 56)
        Me.cboxVarName.Name = "cboxVarName"
        Me.cboxVarName.Size = New System.Drawing.Size(416, 21)
        Me.cboxVarName.TabIndex = 11
        '
        'lblVarName
        '
        Me.lblVarName.Location = New System.Drawing.Point(8, 58)
        Me.lblVarName.Name = "lblVarName"
        Me.lblVarName.Size = New System.Drawing.Size(88, 16)
        Me.lblVarName.TabIndex = 10
        Me.lblVarName.Text = "Variable Name :"
        Me.lblVarName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVarCode
        '
        Me.lblVarCode.Location = New System.Drawing.Point(8, 26)
        Me.lblVarCode.Name = "lblVarCode"
        Me.lblVarCode.Size = New System.Drawing.Size(80, 16)
        Me.lblVarCode.TabIndex = 9
        Me.lblVarCode.Text = "Variable Code :"
        Me.lblVarCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tboxVarCode
        '
        Me.tboxVarCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxVarCode.Location = New System.Drawing.Point(88, 24)
        Me.tboxVarCode.Name = "tboxVarCode"
        Me.tboxVarCode.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.tboxVarCode.Size = New System.Drawing.Size(416, 20)
        Me.tboxVarCode.TabIndex = 8
        '
        'gboxDefinedParameters
        '
        Me.gboxDefinedParameters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboxDefinedParameters.Controls.Add(Me.tboxIsRegular)
        Me.gboxDefinedParameters.Controls.Add(Me.lblIsRegular)
        Me.gboxDefinedParameters.Controls.Add(Me.tboxNoDataValue)
        Me.gboxDefinedParameters.Controls.Add(Me.tboxSampleMedium)
        Me.gboxDefinedParameters.Controls.Add(Me.tboxGeneralCategory)
        Me.gboxDefinedParameters.Controls.Add(Me.tboxValueType)
        Me.gboxDefinedParameters.Controls.Add(Me.tboxDataType)
        Me.gboxDefinedParameters.Controls.Add(Me.lblNoDataValue)
        Me.gboxDefinedParameters.Controls.Add(Me.lblDataType)
        Me.gboxDefinedParameters.Controls.Add(Me.lblGeneralCategory)
        Me.gboxDefinedParameters.Controls.Add(Me.gboxVarTimeSupport)
        Me.gboxDefinedParameters.Controls.Add(Me.lblValueType)
        Me.gboxDefinedParameters.Controls.Add(Me.lblSampleMedium)
        Me.gboxDefinedParameters.Location = New System.Drawing.Point(8, 136)
        Me.gboxDefinedParameters.Name = "gboxDefinedParameters"
        Me.gboxDefinedParameters.Size = New System.Drawing.Size(512, 176)
        Me.gboxDefinedParameters.TabIndex = 41
        Me.gboxDefinedParameters.TabStop = False
        Me.gboxDefinedParameters.Text = "Defined Parameters "
        '
        'tboxIsRegular
        '
        Me.tboxIsRegular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxIsRegular.Location = New System.Drawing.Point(416, 144)
        Me.tboxIsRegular.Name = "tboxIsRegular"
        Me.tboxIsRegular.ReadOnly = True
        Me.tboxIsRegular.Size = New System.Drawing.Size(88, 20)
        Me.tboxIsRegular.TabIndex = 52
        '
        'lblIsRegular
        '
        Me.lblIsRegular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIsRegular.Location = New System.Drawing.Point(352, 146)
        Me.lblIsRegular.Name = "lblIsRegular"
        Me.lblIsRegular.Size = New System.Drawing.Size(64, 16)
        Me.lblIsRegular.TabIndex = 51
        Me.lblIsRegular.Text = "Is Regular :"
        Me.lblIsRegular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tboxNoDataValue
        '
        Me.tboxNoDataValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxNoDataValue.Location = New System.Drawing.Point(416, 112)
        Me.tboxNoDataValue.Name = "tboxNoDataValue"
        Me.tboxNoDataValue.ReadOnly = True
        Me.tboxNoDataValue.Size = New System.Drawing.Size(88, 20)
        Me.tboxNoDataValue.TabIndex = 50
        '
        'tboxSampleMedium
        '
        Me.tboxSampleMedium.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxSampleMedium.Location = New System.Drawing.Point(104, 144)
        Me.tboxSampleMedium.Name = "tboxSampleMedium"
        Me.tboxSampleMedium.ReadOnly = True
        Me.tboxSampleMedium.Size = New System.Drawing.Size(208, 20)
        Me.tboxSampleMedium.TabIndex = 49
        '
        'tboxGeneralCategory
        '
        Me.tboxGeneralCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxGeneralCategory.Location = New System.Drawing.Point(104, 112)
        Me.tboxGeneralCategory.Name = "tboxGeneralCategory"
        Me.tboxGeneralCategory.ReadOnly = True
        Me.tboxGeneralCategory.Size = New System.Drawing.Size(208, 20)
        Me.tboxGeneralCategory.TabIndex = 48
        '
        'tboxValueType
        '
        Me.tboxValueType.Location = New System.Drawing.Point(80, 80)
        Me.tboxValueType.Name = "tboxValueType"
        Me.tboxValueType.ReadOnly = True
        Me.tboxValueType.Size = New System.Drawing.Size(184, 20)
        Me.tboxValueType.TabIndex = 47
        '
        'tboxDataType
        '
        Me.tboxDataType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxDataType.Location = New System.Drawing.Point(336, 80)
        Me.tboxDataType.Name = "tboxDataType"
        Me.tboxDataType.ReadOnly = True
        Me.tboxDataType.Size = New System.Drawing.Size(168, 20)
        Me.tboxDataType.TabIndex = 46
        '
        'lblNoDataValue
        '
        Me.lblNoDataValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoDataValue.Location = New System.Drawing.Point(328, 114)
        Me.lblNoDataValue.Name = "lblNoDataValue"
        Me.lblNoDataValue.Size = New System.Drawing.Size(88, 16)
        Me.lblNoDataValue.TabIndex = 45
        Me.lblNoDataValue.Text = "No Data Value :"
        Me.lblNoDataValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDataType
        '
        Me.lblDataType.Location = New System.Drawing.Point(272, 82)
        Me.lblDataType.Name = "lblDataType"
        Me.lblDataType.Size = New System.Drawing.Size(64, 16)
        Me.lblDataType.TabIndex = 44
        Me.lblDataType.Text = "Data Type :"
        Me.lblDataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGeneralCategory
        '
        Me.lblGeneralCategory.Location = New System.Drawing.Point(8, 114)
        Me.lblGeneralCategory.Name = "lblGeneralCategory"
        Me.lblGeneralCategory.Size = New System.Drawing.Size(104, 16)
        Me.lblGeneralCategory.TabIndex = 43
        Me.lblGeneralCategory.Text = "General Category :"
        Me.lblGeneralCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gboxVarTimeSupport
        '
        Me.gboxVarTimeSupport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboxVarTimeSupport.Controls.Add(Me.tboxTSUnits)
        Me.gboxVarTimeSupport.Controls.Add(Me.tboxTSValue)
        Me.gboxVarTimeSupport.Controls.Add(Me.lblTSUnits)
        Me.gboxVarTimeSupport.Controls.Add(Me.lblTSValue)
        Me.gboxVarTimeSupport.Location = New System.Drawing.Point(8, 24)
        Me.gboxVarTimeSupport.Name = "gboxVarTimeSupport"
        Me.gboxVarTimeSupport.Size = New System.Drawing.Size(496, 48)
        Me.gboxVarTimeSupport.TabIndex = 42
        Me.gboxVarTimeSupport.TabStop = False
        Me.gboxVarTimeSupport.Text = "Time Support"
        '
        'tboxTSUnits
        '
        Me.tboxTSUnits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxTSUnits.Location = New System.Drawing.Point(248, 18)
        Me.tboxTSUnits.Name = "tboxTSUnits"
        Me.tboxTSUnits.ReadOnly = True
        Me.tboxTSUnits.Size = New System.Drawing.Size(240, 20)
        Me.tboxTSUnits.TabIndex = 31
        '
        'tboxTSValue
        '
        Me.tboxTSValue.Location = New System.Drawing.Point(56, 18)
        Me.tboxTSValue.Name = "tboxTSValue"
        Me.tboxTSValue.ReadOnly = True
        Me.tboxTSValue.Size = New System.Drawing.Size(120, 20)
        Me.tboxTSValue.TabIndex = 14
        Me.tboxTSValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTSUnits
        '
        Me.lblTSUnits.BackColor = System.Drawing.SystemColors.Control
        Me.lblTSUnits.Location = New System.Drawing.Point(208, 20)
        Me.lblTSUnits.Name = "lblTSUnits"
        Me.lblTSUnits.Size = New System.Drawing.Size(40, 16)
        Me.lblTSUnits.TabIndex = 6
        Me.lblTSUnits.Text = "Units : "
        Me.lblTSUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTSValue
        '
        Me.lblTSValue.BackColor = System.Drawing.SystemColors.Control
        Me.lblTSValue.Location = New System.Drawing.Point(12, 20)
        Me.lblTSValue.Name = "lblTSValue"
        Me.lblTSValue.Size = New System.Drawing.Size(40, 16)
        Me.lblTSValue.TabIndex = 5
        Me.lblTSValue.Text = "Value : "
        '
        'lblValueType
        '
        Me.lblValueType.Location = New System.Drawing.Point(8, 82)
        Me.lblValueType.Name = "lblValueType"
        Me.lblValueType.Size = New System.Drawing.Size(72, 16)
        Me.lblValueType.TabIndex = 41
        Me.lblValueType.Text = "Value Type :"
        Me.lblValueType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSampleMedium
        '
        Me.lblSampleMedium.Location = New System.Drawing.Point(8, 146)
        Me.lblSampleMedium.Name = "lblSampleMedium"
        Me.lblSampleMedium.Size = New System.Drawing.Size(88, 16)
        Me.lblSampleMedium.TabIndex = 40
        Me.lblSampleMedium.Text = "Sample Medium :"
        Me.lblSampleMedium.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCreateNewVariable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 350)
        Me.Controls.Add(Me.gboxDefinedParameters)
        Me.Controls.Add(Me.gboxSelectableParameters)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCreateVariable)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreateNewVariable"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create A new Variable for the Derived Data Series"
        Me.gboxSelectableParameters.ResumeLayout(False)
        Me.gboxSelectableParameters.PerformLayout()
        Me.gboxDefinedParameters.ResumeLayout(False)
        Me.gboxDefinedParameters.PerformLayout()
        Me.gboxVarTimeSupport.ResumeLayout(False)
        Me.gboxVarTimeSupport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
	Friend WithEvents btnCreateVariable As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents gboxSelectableParameters As System.Windows.Forms.GroupBox
	Friend WithEvents cboxSpeciation As System.Windows.Forms.ComboBox
	Friend WithEvents cboxVarUnits As System.Windows.Forms.ComboBox
	Friend WithEvents lblSpeciation As System.Windows.Forms.Label
	Friend WithEvents lblVarUnits As System.Windows.Forms.Label
	Friend WithEvents cboxVarName As System.Windows.Forms.ComboBox
	Friend WithEvents lblVarName As System.Windows.Forms.Label
	Friend WithEvents lblVarCode As System.Windows.Forms.Label
	Friend WithEvents tboxVarCode As System.Windows.Forms.TextBox
	Friend WithEvents gboxDefinedParameters As System.Windows.Forms.GroupBox
	Friend WithEvents tboxIsRegular As System.Windows.Forms.TextBox
	Friend WithEvents lblIsRegular As System.Windows.Forms.Label
	Friend WithEvents tboxNoDataValue As System.Windows.Forms.TextBox
	Friend WithEvents tboxSampleMedium As System.Windows.Forms.TextBox
	Friend WithEvents tboxGeneralCategory As System.Windows.Forms.TextBox
	Friend WithEvents tboxValueType As System.Windows.Forms.TextBox
	Friend WithEvents tboxDataType As System.Windows.Forms.TextBox
	Friend WithEvents lblNoDataValue As System.Windows.Forms.Label
	Friend WithEvents lblDataType As System.Windows.Forms.Label
	Friend WithEvents lblGeneralCategory As System.Windows.Forms.Label
	Friend WithEvents gboxVarTimeSupport As System.Windows.Forms.GroupBox
	Friend WithEvents tboxTSUnits As System.Windows.Forms.TextBox
	Friend WithEvents tboxTSValue As System.Windows.Forms.TextBox
	Friend WithEvents lblTSUnits As System.Windows.Forms.Label
	Friend WithEvents lblTSValue As System.Windows.Forms.Label
	Friend WithEvents lblValueType As System.Windows.Forms.Label
	Friend WithEvents lblSampleMedium As System.Windows.Forms.Label
End Class
