<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewVariable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtVariableCode = New System.Windows.Forms.TextBox
        Me.cboVariableName = New System.Windows.Forms.ComboBox
        Me.grpRequired = New System.Windows.Forms.GroupBox
        Me.lblSpeciation = New System.Windows.Forms.Label
        Me.cboSpeciation = New System.Windows.Forms.ComboBox
        Me.lblVariableCode = New System.Windows.Forms.Label
        Me.lblVariableName = New System.Windows.Forms.Label
        Me.lblVariableUnits = New System.Windows.Forms.Label
        Me.cboVariableUnits = New System.Windows.Forms.ComboBox
        Me.lblSampleMedium = New System.Windows.Forms.Label
        Me.cboSampleMedium = New System.Windows.Forms.ComboBox
        Me.lblValueType = New System.Windows.Forms.Label
        Me.cboValueType = New System.Windows.Forms.ComboBox
        Me.lblTimeSupport = New System.Windows.Forms.Label
        Me.numTimeSupport = New System.Windows.Forms.NumericUpDown
        Me.lblTimeSupportUnits = New System.Windows.Forms.Label
        Me.cboTimeSupportUnits = New System.Windows.Forms.ComboBox
        Me.lblDataType = New System.Windows.Forms.Label
        Me.cboDataType = New System.Windows.Forms.ComboBox
        Me.lblGeneralCategory = New System.Windows.Forms.Label
        Me.cboGeneralCategory = New System.Windows.Forms.ComboBox
        Me.lblNoDataValue = New System.Windows.Forms.Label
        Me.txtNoDataValue = New System.Windows.Forms.TextBox
        Me.lblIsRegular = New System.Windows.Forms.Label
        Me.cboIsRegular = New System.Windows.Forms.ComboBox
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpRequired.SuspendLayout()
        CType(Me.numTimeSupport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtVariableCode
        '
        Me.txtVariableCode.AcceptsReturn = True
        Me.txtVariableCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVariableCode.Location = New System.Drawing.Point(21, 32)
        Me.txtVariableCode.MaxLength = 50
        Me.txtVariableCode.Multiline = True
        Me.txtVariableCode.Name = "txtVariableCode"
        Me.txtVariableCode.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtVariableCode.Size = New System.Drawing.Size(261, 59)
        Me.txtVariableCode.TabIndex = 1
        '
        'cboVariableName
        '
        Me.cboVariableName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboVariableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVariableName.FormattingEnabled = True
        Me.cboVariableName.Location = New System.Drawing.Point(21, 110)
        Me.cboVariableName.MaxDropDownItems = 10
        Me.cboVariableName.Name = "cboVariableName"
        Me.cboVariableName.Size = New System.Drawing.Size(261, 21)
        Me.cboVariableName.TabIndex = 3
        '
        'grpRequired
        '
        Me.grpRequired.Controls.Add(Me.lblVariableCode)
        Me.grpRequired.Controls.Add(Me.txtVariableCode)
        Me.grpRequired.Controls.Add(Me.lblVariableName)
        Me.grpRequired.Controls.Add(Me.cboVariableName)
        Me.grpRequired.Controls.Add(Me.lblSpeciation)
        Me.grpRequired.Controls.Add(Me.cboSpeciation)
        Me.grpRequired.Controls.Add(Me.lblVariableUnits)
        Me.grpRequired.Controls.Add(Me.cboVariableUnits)
        Me.grpRequired.Controls.Add(Me.lblSampleMedium)
        Me.grpRequired.Controls.Add(Me.cboSampleMedium)
        Me.grpRequired.Controls.Add(Me.lblValueType)
        Me.grpRequired.Controls.Add(Me.cboValueType)
        Me.grpRequired.Controls.Add(Me.lblTimeSupport)
        Me.grpRequired.Controls.Add(Me.numTimeSupport)
        Me.grpRequired.Controls.Add(Me.lblTimeSupportUnits)
        Me.grpRequired.Controls.Add(Me.cboTimeSupportUnits)
        Me.grpRequired.Controls.Add(Me.lblDataType)
        Me.grpRequired.Controls.Add(Me.cboDataType)
        Me.grpRequired.Controls.Add(Me.lblGeneralCategory)
        Me.grpRequired.Controls.Add(Me.cboGeneralCategory)
        Me.grpRequired.Controls.Add(Me.lblNoDataValue)
        Me.grpRequired.Controls.Add(Me.txtNoDataValue)
        Me.grpRequired.Controls.Add(Me.lblIsRegular)
        Me.grpRequired.Controls.Add(Me.cboIsRegular)
        Me.grpRequired.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpRequired.Location = New System.Drawing.Point(0, 0)
        Me.grpRequired.Name = "grpRequired"
        Me.grpRequired.Size = New System.Drawing.Size(300, 383)
        Me.grpRequired.TabIndex = 0
        Me.grpRequired.TabStop = False
        Me.grpRequired.Text = "Required"
        '
        'lblSpeciation
        '
        Me.lblSpeciation.AutoSize = True
        Me.lblSpeciation.Location = New System.Drawing.Point(6, 134)
        Me.lblSpeciation.Name = "lblSpeciation"
        Me.lblSpeciation.Size = New System.Drawing.Size(57, 13)
        Me.lblSpeciation.TabIndex = 22
        Me.lblSpeciation.Text = "Speciation"
        '
        'cboSpeciation
        '
        Me.cboSpeciation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSpeciation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSpeciation.FormattingEnabled = True
        Me.cboSpeciation.Location = New System.Drawing.Point(21, 150)
        Me.cboSpeciation.MaxDropDownItems = 10
        Me.cboSpeciation.Name = "cboSpeciation"
        Me.cboSpeciation.Size = New System.Drawing.Size(261, 21)
        Me.cboSpeciation.TabIndex = 23
        '
        'lblVariableCode
        '
        Me.lblVariableCode.AutoSize = True
        Me.lblVariableCode.Location = New System.Drawing.Point(6, 16)
        Me.lblVariableCode.Name = "lblVariableCode"
        Me.lblVariableCode.Size = New System.Drawing.Size(73, 13)
        Me.lblVariableCode.TabIndex = 0
        Me.lblVariableCode.Text = "Variable Code"
        '
        'lblVariableName
        '
        Me.lblVariableName.AutoSize = True
        Me.lblVariableName.Location = New System.Drawing.Point(6, 94)
        Me.lblVariableName.Name = "lblVariableName"
        Me.lblVariableName.Size = New System.Drawing.Size(76, 13)
        Me.lblVariableName.TabIndex = 2
        Me.lblVariableName.Text = "Variable Name"
        '
        'lblVariableUnits
        '
        Me.lblVariableUnits.AutoSize = True
        Me.lblVariableUnits.Location = New System.Drawing.Point(6, 174)
        Me.lblVariableUnits.Name = "lblVariableUnits"
        Me.lblVariableUnits.Size = New System.Drawing.Size(72, 13)
        Me.lblVariableUnits.TabIndex = 4
        Me.lblVariableUnits.Text = "Variable Units"
        '
        'cboVariableUnits
        '
        Me.cboVariableUnits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboVariableUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVariableUnits.FormattingEnabled = True
        Me.cboVariableUnits.Location = New System.Drawing.Point(24, 190)
        Me.cboVariableUnits.MaxDropDownItems = 10
        Me.cboVariableUnits.Name = "cboVariableUnits"
        Me.cboVariableUnits.Size = New System.Drawing.Size(258, 21)
        Me.cboVariableUnits.TabIndex = 5
        '
        'lblSampleMedium
        '
        Me.lblSampleMedium.AutoSize = True
        Me.lblSampleMedium.Location = New System.Drawing.Point(6, 214)
        Me.lblSampleMedium.Name = "lblSampleMedium"
        Me.lblSampleMedium.Size = New System.Drawing.Size(82, 13)
        Me.lblSampleMedium.TabIndex = 6
        Me.lblSampleMedium.Text = "Sample Medium"
        '
        'cboSampleMedium
        '
        Me.cboSampleMedium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSampleMedium.DropDownWidth = 264
        Me.cboSampleMedium.FormattingEnabled = True
        Me.cboSampleMedium.Location = New System.Drawing.Point(21, 230)
        Me.cboSampleMedium.MaxDropDownItems = 10
        Me.cboSampleMedium.Name = "cboSampleMedium"
        Me.cboSampleMedium.Size = New System.Drawing.Size(120, 21)
        Me.cboSampleMedium.TabIndex = 7
        '
        'lblValueType
        '
        Me.lblValueType.AutoSize = True
        Me.lblValueType.Location = New System.Drawing.Point(147, 214)
        Me.lblValueType.Name = "lblValueType"
        Me.lblValueType.Size = New System.Drawing.Size(61, 13)
        Me.lblValueType.TabIndex = 8
        Me.lblValueType.Text = "Value Type"
        '
        'cboValueType
        '
        Me.cboValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValueType.DropDownWidth = 264
        Me.cboValueType.FormattingEnabled = True
        Me.cboValueType.Location = New System.Drawing.Point(165, 230)
        Me.cboValueType.MaxDropDownItems = 10
        Me.cboValueType.Name = "cboValueType"
        Me.cboValueType.Size = New System.Drawing.Size(120, 21)
        Me.cboValueType.TabIndex = 9
        '
        'lblTimeSupport
        '
        Me.lblTimeSupport.AutoSize = True
        Me.lblTimeSupport.Location = New System.Drawing.Point(6, 254)
        Me.lblTimeSupport.Name = "lblTimeSupport"
        Me.lblTimeSupport.Size = New System.Drawing.Size(100, 13)
        Me.lblTimeSupport.TabIndex = 10
        Me.lblTimeSupport.Text = "Time Support Value"
        '
        'numTimeSupport
        '
        Me.numTimeSupport.Location = New System.Drawing.Point(21, 269)
        Me.numTimeSupport.Name = "numTimeSupport"
        Me.numTimeSupport.Size = New System.Drawing.Size(120, 20)
        Me.numTimeSupport.TabIndex = 11
        '
        'lblTimeSupportUnits
        '
        Me.lblTimeSupportUnits.AutoSize = True
        Me.lblTimeSupportUnits.Location = New System.Drawing.Point(147, 254)
        Me.lblTimeSupportUnits.Name = "lblTimeSupportUnits"
        Me.lblTimeSupportUnits.Size = New System.Drawing.Size(97, 13)
        Me.lblTimeSupportUnits.TabIndex = 12
        Me.lblTimeSupportUnits.Text = "Time Support Units"
        '
        'cboTimeSupportUnits
        '
        Me.cboTimeSupportUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimeSupportUnits.DropDownWidth = 264
        Me.cboTimeSupportUnits.FormattingEnabled = True
        Me.cboTimeSupportUnits.Location = New System.Drawing.Point(165, 269)
        Me.cboTimeSupportUnits.MaxDropDownItems = 10
        Me.cboTimeSupportUnits.Name = "cboTimeSupportUnits"
        Me.cboTimeSupportUnits.Size = New System.Drawing.Size(120, 21)
        Me.cboTimeSupportUnits.TabIndex = 13
        '
        'lblDataType
        '
        Me.lblDataType.AutoSize = True
        Me.lblDataType.Location = New System.Drawing.Point(6, 293)
        Me.lblDataType.Name = "lblDataType"
        Me.lblDataType.Size = New System.Drawing.Size(57, 13)
        Me.lblDataType.TabIndex = 14
        Me.lblDataType.Text = "Data Type"
        '
        'cboDataType
        '
        Me.cboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataType.DropDownWidth = 264
        Me.cboDataType.FormattingEnabled = True
        Me.cboDataType.Location = New System.Drawing.Point(21, 309)
        Me.cboDataType.MaxDropDownItems = 10
        Me.cboDataType.Name = "cboDataType"
        Me.cboDataType.Size = New System.Drawing.Size(120, 21)
        Me.cboDataType.TabIndex = 15
        '
        'lblGeneralCategory
        '
        Me.lblGeneralCategory.AutoSize = True
        Me.lblGeneralCategory.Location = New System.Drawing.Point(147, 293)
        Me.lblGeneralCategory.Name = "lblGeneralCategory"
        Me.lblGeneralCategory.Size = New System.Drawing.Size(89, 13)
        Me.lblGeneralCategory.TabIndex = 16
        Me.lblGeneralCategory.Text = "General Category"
        '
        'cboGeneralCategory
        '
        Me.cboGeneralCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGeneralCategory.DropDownWidth = 264
        Me.cboGeneralCategory.FormattingEnabled = True
        Me.cboGeneralCategory.Location = New System.Drawing.Point(165, 309)
        Me.cboGeneralCategory.MaxDropDownItems = 10
        Me.cboGeneralCategory.Name = "cboGeneralCategory"
        Me.cboGeneralCategory.Size = New System.Drawing.Size(120, 21)
        Me.cboGeneralCategory.TabIndex = 17
        '
        'lblNoDataValue
        '
        Me.lblNoDataValue.AutoSize = True
        Me.lblNoDataValue.Location = New System.Drawing.Point(6, 333)
        Me.lblNoDataValue.Name = "lblNoDataValue"
        Me.lblNoDataValue.Size = New System.Drawing.Size(103, 13)
        Me.lblNoDataValue.TabIndex = 18
        Me.lblNoDataValue.Text = "No Data Value (#.#)"
        '
        'txtNoDataValue
        '
        Me.txtNoDataValue.Location = New System.Drawing.Point(21, 349)
        Me.txtNoDataValue.Name = "txtNoDataValue"
        Me.txtNoDataValue.Size = New System.Drawing.Size(120, 20)
        Me.txtNoDataValue.TabIndex = 19
        Me.txtNoDataValue.Text = "-9999"
        '
        'lblIsRegular
        '
        Me.lblIsRegular.AutoSize = True
        Me.lblIsRegular.Location = New System.Drawing.Point(147, 333)
        Me.lblIsRegular.Name = "lblIsRegular"
        Me.lblIsRegular.Size = New System.Drawing.Size(55, 13)
        Me.lblIsRegular.TabIndex = 20
        Me.lblIsRegular.Text = "Is Regular"
        '
        'cboIsRegular
        '
        Me.cboIsRegular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIsRegular.DropDownWidth = 264
        Me.cboIsRegular.FormattingEnabled = True
        Me.cboIsRegular.Items.AddRange(New Object() {"False", "True"})
        Me.cboIsRegular.Location = New System.Drawing.Point(165, 348)
        Me.cboIsRegular.MaxDropDownItems = 10
        Me.cboIsRegular.Name = "cboIsRegular"
        Me.cboIsRegular.Size = New System.Drawing.Size(120, 21)
        Me.cboIsRegular.TabIndex = 21
        '
        'flpButtons
        '
        Me.flpButtons.AutoSize = True
        Me.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpButtons.Controls.Add(Me.btnOK)
        Me.flpButtons.Controls.Add(Me.btnCancel)
        Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpButtons.Location = New System.Drawing.Point(0, 383)
        Me.flpButtons.Name = "flpButtons"
        Me.flpButtons.Size = New System.Drawing.Size(300, 31)
        Me.flpButtons.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(197, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 25)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(91, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmNewVariable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(300, 414)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpRequired)
        Me.Controls.Add(Me.flpButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmNewVariable"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Add New Variable"
        Me.grpRequired.ResumeLayout(False)
        Me.grpRequired.PerformLayout()
        CType(Me.numTimeSupport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVariableCode As System.Windows.Forms.TextBox
    Friend WithEvents cboVariableName As System.Windows.Forms.ComboBox
    Friend WithEvents grpRequired As System.Windows.Forms.GroupBox
    Friend WithEvents cboDataType As System.Windows.Forms.ComboBox
    Friend WithEvents cboGeneralCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboTimeSupportUnits As System.Windows.Forms.ComboBox
    Friend WithEvents cboValueType As System.Windows.Forms.ComboBox
    Friend WithEvents cboSampleMedium As System.Windows.Forms.ComboBox
    Friend WithEvents cboVariableUnits As System.Windows.Forms.ComboBox
    Friend WithEvents lblVariableCode As System.Windows.Forms.Label
    Friend WithEvents lblVariableName As System.Windows.Forms.Label
    Friend WithEvents lblVariableUnits As System.Windows.Forms.Label
    Friend WithEvents lblSampleMedium As System.Windows.Forms.Label
    Friend WithEvents lblValueType As System.Windows.Forms.Label
    Friend WithEvents lblTimeSupport As System.Windows.Forms.Label
    Friend WithEvents lblTimeSupportUnits As System.Windows.Forms.Label
    Friend WithEvents lblNoDataValue As System.Windows.Forms.Label
    Friend WithEvents lblGeneralCategory As System.Windows.Forms.Label
    Friend WithEvents lblDataType As System.Windows.Forms.Label
    Friend WithEvents lblIsRegular As System.Windows.Forms.Label
    Friend WithEvents cboIsRegular As System.Windows.Forms.ComboBox
    Friend WithEvents flpButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtNoDataValue As System.Windows.Forms.TextBox
    Friend WithEvents numTimeSupport As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSpeciation As System.Windows.Forms.Label
    Friend WithEvents cboSpeciation As System.Windows.Forms.ComboBox
End Class
