<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddNewValue
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
        Me.tlpButtons = New System.Windows.Forms.TableLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.dtpANVDateTime = New System.Windows.Forms.DateTimePicker
        Me.cboANVUtcOffset = New System.Windows.Forms.ComboBox
        Me.txtANVDataValue = New System.Windows.Forms.TextBox
        Me.txtANVOffsetValue = New System.Windows.Forms.TextBox
        Me.grpDateInfo = New System.Windows.Forms.GroupBox
        Me.txtANVUtcDateTime = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpOffsetInfo = New System.Windows.Forms.GroupBox
        Me.grpOffsetValue = New System.Windows.Forms.Panel
        Me.txtANVOffsetUnits = New System.Windows.Forms.TextBox
        Me.txtANVOffsetType = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpRequiredInfo = New System.Windows.Forms.GroupBox
        Me.cboANVCensorCode = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.grpOptionalInfo = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboANVSample = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboANVQualifier = New System.Windows.Forms.ComboBox
        Me.pnlButtons = New System.Windows.Forms.Panel
        Me.tlpButtons.SuspendLayout()
        Me.grpDateInfo.SuspendLayout()
        Me.grpOffsetInfo.SuspendLayout()
        Me.grpOffsetValue.SuspendLayout()
        Me.grpRequiredInfo.SuspendLayout()
        Me.grpOptionalInfo.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpButtons
        '
        Me.tlpButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpButtons.ColumnCount = 2
        Me.tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpButtons.Controls.Add(Me.btnOK, 0, 0)
        Me.tlpButtons.Controls.Add(Me.btnCancel, 1, 0)
        Me.tlpButtons.Location = New System.Drawing.Point(189, 4)
        Me.tlpButtons.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tlpButtons.Name = "tlpButtons"
        Me.tlpButtons.RowCount = 1
        Me.tlpButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpButtons.Size = New System.Drawing.Size(195, 36)
        Me.tlpButtons.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.Location = New System.Drawing.Point(4, 4)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(89, 28)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(101, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 28)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'dtpANVDateTime
        '
        Me.dtpANVDateTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpANVDateTime.CustomFormat = "M/d/yyyy  h:mm:ss tt"
        Me.dtpANVDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpANVDateTime.Location = New System.Drawing.Point(144, 23)
        Me.dtpANVDateTime.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpANVDateTime.Name = "dtpANVDateTime"
        Me.dtpANVDateTime.Size = New System.Drawing.Size(214, 22)
        Me.dtpANVDateTime.TabIndex = 1
        Me.dtpANVDateTime.Value = New Date(2007, 4, 5, 14, 0, 0, 0)
        '
        'cboANVUtcOffset
        '
        Me.cboANVUtcOffset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboANVUtcOffset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboANVUtcOffset.FormattingEnabled = True
        Me.cboANVUtcOffset.Items.AddRange(New Object() {"-12", "-11", "-10", "-9.5", "-9", "-8.5", "-8", "-7", "-6", "-5", "-4", "-3.5", "-3", "-2.5", "-2", "-1", "0", "1", "2", "3", "3.5", "4", "4.5", "5", "5.5", "6", "6.5", "7", "7.5", "8", "9", "9.5", "10", "10.5", "11", "11.5", "12", "12.5", "13", "14", "15"})
        Me.cboANVUtcOffset.Location = New System.Drawing.Point(144, 55)
        Me.cboANVUtcOffset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboANVUtcOffset.Name = "cboANVUtcOffset"
        Me.cboANVUtcOffset.Size = New System.Drawing.Size(214, 24)
        Me.cboANVUtcOffset.TabIndex = 3
        '
        'txtANVDataValue
        '
        Me.txtANVDataValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtANVDataValue.Location = New System.Drawing.Point(152, 23)
        Me.txtANVDataValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtANVDataValue.Name = "txtANVDataValue"
        Me.txtANVDataValue.Size = New System.Drawing.Size(215, 22)
        Me.txtANVDataValue.TabIndex = 1
        '
        'txtANVOffsetValue
        '
        Me.txtANVOffsetValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtANVOffsetValue.Enabled = False
        Me.txtANVOffsetValue.Location = New System.Drawing.Point(0, 0)
        Me.txtANVOffsetValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtANVOffsetValue.Name = "txtANVOffsetValue"
        Me.txtANVOffsetValue.Size = New System.Drawing.Size(137, 22)
        Me.txtANVOffsetValue.TabIndex = 0
        '
        'grpDateInfo
        '
        Me.grpDateInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDateInfo.AutoSize = True
        Me.grpDateInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpDateInfo.Controls.Add(Me.txtANVUtcDateTime)
        Me.grpDateInfo.Controls.Add(Me.cboANVUtcOffset)
        Me.grpDateInfo.Controls.Add(Me.dtpANVDateTime)
        Me.grpDateInfo.Controls.Add(Me.Label2)
        Me.grpDateInfo.Controls.Add(Me.Label4)
        Me.grpDateInfo.Controls.Add(Me.Label3)
        Me.grpDateInfo.Location = New System.Drawing.Point(8, 89)
        Me.grpDateInfo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.grpDateInfo.Name = "grpDateInfo"
        Me.grpDateInfo.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpDateInfo.Size = New System.Drawing.Size(367, 134)
        Me.grpDateInfo.TabIndex = 4
        Me.grpDateInfo.TabStop = False
        Me.grpDateInfo.Text = "Date Information"
        '
        'txtANVUtcDateTime
        '
        Me.txtANVUtcDateTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtANVUtcDateTime.Location = New System.Drawing.Point(144, 89)
        Me.txtANVUtcDateTime.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtANVUtcDateTime.Name = "txtANVUtcDateTime"
        Me.txtANVUtcDateTime.ReadOnly = True
        Me.txtANVUtcDateTime.Size = New System.Drawing.Size(215, 22)
        Me.txtANVUtcDateTime.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Local Date/Time:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 94)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "UTC DateTime:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 60)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "UTC Offset:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpOffsetInfo
        '
        Me.grpOffsetInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOffsetInfo.AutoSize = True
        Me.grpOffsetInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpOffsetInfo.Controls.Add(Me.grpOffsetValue)
        Me.grpOffsetInfo.Controls.Add(Me.txtANVOffsetType)
        Me.grpOffsetInfo.Controls.Add(Me.Label8)
        Me.grpOffsetInfo.Controls.Add(Me.Label7)
        Me.grpOffsetInfo.Location = New System.Drawing.Point(8, 90)
        Me.grpOffsetInfo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.grpOffsetInfo.Name = "grpOffsetInfo"
        Me.grpOffsetInfo.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpOffsetInfo.Size = New System.Drawing.Size(368, 103)
        Me.grpOffsetInfo.TabIndex = 4
        Me.grpOffsetInfo.TabStop = False
        Me.grpOffsetInfo.Text = "Offset Information"
        '
        'grpOffsetValue
        '
        Me.grpOffsetValue.Controls.Add(Me.txtANVOffsetValue)
        Me.grpOffsetValue.Controls.Add(Me.txtANVOffsetUnits)
        Me.grpOffsetValue.Location = New System.Drawing.Point(144, 55)
        Me.grpOffsetValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpOffsetValue.Name = "grpOffsetValue"
        Me.grpOffsetValue.Size = New System.Drawing.Size(216, 25)
        Me.grpOffsetValue.TabIndex = 4
        '
        'txtANVOffsetUnits
        '
        Me.txtANVOffsetUnits.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtANVOffsetUnits.Location = New System.Drawing.Point(137, 0)
        Me.txtANVOffsetUnits.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtANVOffsetUnits.Name = "txtANVOffsetUnits"
        Me.txtANVOffsetUnits.ReadOnly = True
        Me.txtANVOffsetUnits.Size = New System.Drawing.Size(79, 22)
        Me.txtANVOffsetUnits.TabIndex = 1
        '
        'txtANVOffsetType
        '
        Me.txtANVOffsetType.Location = New System.Drawing.Point(144, 23)
        Me.txtANVOffsetType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtANVOffsetType.Name = "txtANVOffsetType"
        Me.txtANVOffsetType.ReadOnly = True
        Me.txtANVOffsetType.Size = New System.Drawing.Size(215, 22)
        Me.txtANVOffsetType.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 28)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Offset Type:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 62)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Offset Value:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data Value:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpRequiredInfo
        '
        Me.grpRequiredInfo.AutoSize = True
        Me.grpRequiredInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpRequiredInfo.Controls.Add(Me.cboANVCensorCode)
        Me.grpRequiredInfo.Controls.Add(Me.Label6)
        Me.grpRequiredInfo.Controls.Add(Me.grpDateInfo)
        Me.grpRequiredInfo.Controls.Add(Me.txtANVDataValue)
        Me.grpRequiredInfo.Controls.Add(Me.Label1)
        Me.grpRequiredInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRequiredInfo.Location = New System.Drawing.Point(4, 10)
        Me.grpRequiredInfo.Margin = New System.Windows.Forms.Padding(4, 4, 0, 0)
        Me.grpRequiredInfo.Name = "grpRequiredInfo"
        Me.grpRequiredInfo.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpRequiredInfo.Size = New System.Drawing.Size(384, 242)
        Me.grpRequiredInfo.TabIndex = 0
        Me.grpRequiredInfo.TabStop = False
        Me.grpRequiredInfo.Text = "Required"
        '
        'cboANVCensorCode
        '
        Me.cboANVCensorCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboANVCensorCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboANVCensorCode.FormattingEnabled = True
        Me.cboANVCensorCode.Location = New System.Drawing.Point(152, 55)
        Me.cboANVCensorCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboANVCensorCode.Name = "cboANVCensorCode"
        Me.cboANVCensorCode.Size = New System.Drawing.Size(215, 24)
        Me.cboANVCensorCode.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 60)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 17)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Censor Code:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpOptionalInfo
        '
        Me.grpOptionalInfo.AutoSize = True
        Me.grpOptionalInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpOptionalInfo.Controls.Add(Me.Label5)
        Me.grpOptionalInfo.Controls.Add(Me.cboANVSample)
        Me.grpOptionalInfo.Controls.Add(Me.Label9)
        Me.grpOptionalInfo.Controls.Add(Me.cboANVQualifier)
        Me.grpOptionalInfo.Controls.Add(Me.grpOffsetInfo)
        Me.grpOptionalInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpOptionalInfo.Location = New System.Drawing.Point(4, 252)
        Me.grpOptionalInfo.Margin = New System.Windows.Forms.Padding(4, 4, 0, 0)
        Me.grpOptionalInfo.Name = "grpOptionalInfo"
        Me.grpOptionalInfo.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpOptionalInfo.Size = New System.Drawing.Size(384, 212)
        Me.grpOptionalInfo.TabIndex = 1
        Me.grpOptionalInfo.TabStop = False
        Me.grpOptionalInfo.Text = "Optional"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 28)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Qualifier:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboANVSample
        '
        Me.cboANVSample.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboANVSample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboANVSample.FormattingEnabled = True
        Me.cboANVSample.Location = New System.Drawing.Point(152, 57)
        Me.cboANVSample.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboANVSample.Name = "cboANVSample"
        Me.cboANVSample.Size = New System.Drawing.Size(215, 24)
        Me.cboANVSample.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 62)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 17)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Sample:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboANVQualifier
        '
        Me.cboANVQualifier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboANVQualifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboANVQualifier.FormattingEnabled = True
        Me.cboANVQualifier.Location = New System.Drawing.Point(152, 23)
        Me.cboANVQualifier.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboANVQualifier.Name = "cboANVQualifier"
        Me.cboANVQualifier.Size = New System.Drawing.Size(215, 24)
        Me.cboANVQualifier.TabIndex = 1
        '
        'pnlButtons
        '
        Me.pnlButtons.AutoSize = True
        Me.pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlButtons.Controls.Add(Me.tlpButtons)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlButtons.Location = New System.Drawing.Point(4, 464)
        Me.pnlButtons.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(384, 49)
        Me.pnlButtons.TabIndex = 2
        '
        'frmAddNewValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(392, 517)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.grpOptionalInfo)
        Me.Controls.Add(Me.grpRequiredInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddNewValue"
        Me.Padding = New System.Windows.Forms.Padding(4, 10, 4, 4)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Value"
        Me.tlpButtons.ResumeLayout(False)
        Me.grpDateInfo.ResumeLayout(False)
        Me.grpDateInfo.PerformLayout()
        Me.grpOffsetInfo.ResumeLayout(False)
        Me.grpOffsetInfo.PerformLayout()
        Me.grpOffsetValue.ResumeLayout(False)
        Me.grpOffsetValue.PerformLayout()
        Me.grpRequiredInfo.ResumeLayout(False)
        Me.grpRequiredInfo.PerformLayout()
        Me.grpOptionalInfo.ResumeLayout(False)
        Me.grpOptionalInfo.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents tlpButtons As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents btnOK As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents dtpANVDateTime As System.Windows.Forms.DateTimePicker
	Friend WithEvents cboANVUtcOffset As System.Windows.Forms.ComboBox
	Friend WithEvents txtANVDataValue As System.Windows.Forms.TextBox
	Friend WithEvents txtANVOffsetValue As System.Windows.Forms.TextBox
	Friend WithEvents grpDateInfo As System.Windows.Forms.GroupBox
	Friend WithEvents grpOffsetInfo As System.Windows.Forms.GroupBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents grpRequiredInfo As System.Windows.Forms.GroupBox
	Friend WithEvents grpOptionalInfo As System.Windows.Forms.GroupBox
	Friend WithEvents txtANVUtcDateTime As System.Windows.Forms.TextBox
	Friend WithEvents cboANVSample As System.Windows.Forms.ComboBox
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents cboANVCensorCode As System.Windows.Forms.ComboBox
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents txtANVOffsetType As System.Windows.Forms.TextBox
	Friend WithEvents pnlButtons As System.Windows.Forms.Panel
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents cboANVQualifier As System.Windows.Forms.ComboBox
	Friend WithEvents grpOffsetValue As System.Windows.Forms.Panel
	Friend WithEvents txtANVOffsetUnits As System.Windows.Forms.TextBox

End Class
