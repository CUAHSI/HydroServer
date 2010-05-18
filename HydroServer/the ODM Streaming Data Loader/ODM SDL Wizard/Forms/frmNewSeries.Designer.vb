<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewSeries
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
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnFinish = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.pnlValColumn = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdoAggregate = New System.Windows.Forms.RadioButton
        Me.rdoInstantaneous = New System.Windows.Forms.RadioButton
        Me.pnlAggregate = New System.Windows.Forms.Panel
        Me.grpDatabase = New System.Windows.Forms.GroupBox
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.rdoDBYes = New System.Windows.Forms.RadioButton
        Me.rdoDBNo = New System.Windows.Forms.RadioButton
        Me.grpFile = New System.Windows.Forms.GroupBox
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.rdoFileYes = New System.Windows.Forms.RadioButton
        Me.rdoFileNo = New System.Windows.Forms.RadioButton
        Me.lblPOR = New System.Windows.Forms.Label
        Me.numDays = New System.Windows.Forms.NumericUpDown
        Me.lblDays = New System.Windows.Forms.Label
        Me.numHours = New System.Windows.Forms.NumericUpDown
        Me.lblHours = New System.Windows.Forms.Label
        Me.numMinutes = New System.Windows.Forms.NumericUpDown
        Me.lblMinutes = New System.Windows.Forms.Label
        Me.numSeconds = New System.Windows.Forms.NumericUpDown
        Me.lblSeconds = New System.Windows.Forms.Label
        Me.lblValColumn = New System.Windows.Forms.Label
        Me.cboValColumn = New System.Windows.Forms.ComboBox
        Me.ucSelect = New ODMSDLConfigWiz.ucSelectRow
        Me.flpButtons.SuspendLayout()
        Me.pnlValColumn.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlAggregate.SuspendLayout()
        Me.grpDatabase.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.grpFile.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.numDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flpButtons
        '
        Me.flpButtons.AutoSize = True
        Me.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpButtons.Controls.Add(Me.btnFinish)
        Me.flpButtons.Controls.Add(Me.btnNext)
        Me.flpButtons.Controls.Add(Me.btnBack)
        Me.flpButtons.Controls.Add(Me.btnCancel)
        Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpButtons.Location = New System.Drawing.Point(0, 445)
        Me.flpButtons.Name = "flpButtons"
        Me.flpButtons.Size = New System.Drawing.Size(692, 31)
        Me.flpButtons.TabIndex = 2
        '
        'btnFinish
        '
        Me.btnFinish.Enabled = False
        Me.btnFinish.Location = New System.Drawing.Point(589, 3)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(100, 25)
        Me.btnFinish.TabIndex = 0
        Me.btnFinish.Text = "Finish"
        Me.btnFinish.UseVisualStyleBackColor = True
        Me.btnFinish.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(483, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(100, 25)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(377, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 25)
        Me.btnBack.TabIndex = 2
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        Me.btnBack.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(271, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 25)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlValColumn
        '
        Me.pnlValColumn.Controls.Add(Me.GroupBox1)
        Me.pnlValColumn.Controls.Add(Me.lblValColumn)
        Me.pnlValColumn.Controls.Add(Me.cboValColumn)
        Me.pnlValColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlValColumn.Location = New System.Drawing.Point(0, 0)
        Me.pnlValColumn.Name = "pnlValColumn"
        Me.pnlValColumn.Size = New System.Drawing.Size(692, 445)
        Me.pnlValColumn.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoAggregate)
        Me.GroupBox1.Controls.Add(Me.rdoInstantaneous)
        Me.GroupBox1.Controls.Add(Me.pnlAggregate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(668, 224)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Time Interval Adjustment"
        '
        'rdoAggregate
        '
        Me.rdoAggregate.AutoSize = True
        Me.rdoAggregate.Location = New System.Drawing.Point(6, 42)
        Me.rdoAggregate.Name = "rdoAggregate"
        Me.rdoAggregate.Size = New System.Drawing.Size(196, 17)
        Me.rdoAggregate.TabIndex = 3
        Me.rdoAggregate.Text = "Aggregate Data (can adjust Interval)"
        Me.rdoAggregate.UseVisualStyleBackColor = True
        '
        'rdoInstantaneous
        '
        Me.rdoInstantaneous.AutoSize = True
        Me.rdoInstantaneous.Checked = True
        Me.rdoInstantaneous.Location = New System.Drawing.Point(6, 19)
        Me.rdoInstantaneous.Name = "rdoInstantaneous"
        Me.rdoInstantaneous.Size = New System.Drawing.Size(231, 17)
        Me.rdoInstantaneous.TabIndex = 2
        Me.rdoInstantaneous.TabStop = True
        Me.rdoInstantaneous.Text = "Instantaneous Data (no Interval adjustment)"
        Me.rdoInstantaneous.UseVisualStyleBackColor = True
        '
        'pnlAggregate
        '
        Me.pnlAggregate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAggregate.Controls.Add(Me.grpDatabase)
        Me.pnlAggregate.Controls.Add(Me.grpFile)
        Me.pnlAggregate.Controls.Add(Me.lblPOR)
        Me.pnlAggregate.Controls.Add(Me.numDays)
        Me.pnlAggregate.Controls.Add(Me.lblDays)
        Me.pnlAggregate.Controls.Add(Me.numHours)
        Me.pnlAggregate.Controls.Add(Me.lblHours)
        Me.pnlAggregate.Controls.Add(Me.numMinutes)
        Me.pnlAggregate.Controls.Add(Me.lblMinutes)
        Me.pnlAggregate.Controls.Add(Me.numSeconds)
        Me.pnlAggregate.Controls.Add(Me.lblSeconds)
        Me.pnlAggregate.Enabled = False
        Me.pnlAggregate.Location = New System.Drawing.Point(6, 65)
        Me.pnlAggregate.Name = "pnlAggregate"
        Me.pnlAggregate.Size = New System.Drawing.Size(656, 153)
        Me.pnlAggregate.TabIndex = 6
        '
        'grpDatabase
        '
        Me.grpDatabase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDatabase.Controls.Add(Me.FlowLayoutPanel2)
        Me.grpDatabase.Location = New System.Drawing.Point(3, 54)
        Me.grpDatabase.Name = "grpDatabase"
        Me.grpDatabase.Size = New System.Drawing.Size(650, 45)
        Me.grpDatabase.TabIndex = 5
        Me.grpDatabase.TabStop = False
        Me.grpDatabase.Text = "Data in this column should be saved to the database at the Start of the Interval"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.rdoDBYes)
        Me.FlowLayoutPanel2.Controls.Add(Me.rdoDBNo)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(644, 26)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'rdoDBYes
        '
        Me.rdoDBYes.AutoSize = True
        Me.rdoDBYes.Checked = True
        Me.rdoDBYes.Location = New System.Drawing.Point(3, 3)
        Me.rdoDBYes.Name = "rdoDBYes"
        Me.rdoDBYes.Size = New System.Drawing.Size(43, 17)
        Me.rdoDBYes.TabIndex = 3
        Me.rdoDBYes.TabStop = True
        Me.rdoDBYes.Text = "Yes"
        Me.rdoDBYes.UseVisualStyleBackColor = True
        '
        'rdoDBNo
        '
        Me.rdoDBNo.AutoSize = True
        Me.rdoDBNo.Location = New System.Drawing.Point(52, 3)
        Me.rdoDBNo.Name = "rdoDBNo"
        Me.rdoDBNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoDBNo.TabIndex = 4
        Me.rdoDBNo.Text = "No"
        Me.rdoDBNo.UseVisualStyleBackColor = True
        '
        'grpFile
        '
        Me.grpFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFile.Controls.Add(Me.FlowLayoutPanel1)
        Me.grpFile.Location = New System.Drawing.Point(3, 3)
        Me.grpFile.Name = "grpFile"
        Me.grpFile.Size = New System.Drawing.Size(650, 45)
        Me.grpFile.TabIndex = 4
        Me.grpFile.TabStop = False
        Me.grpFile.Text = "Data in this column is recorded at the Start of the Interval"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rdoFileYes)
        Me.FlowLayoutPanel1.Controls.Add(Me.rdoFileNo)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(644, 26)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'rdoFileYes
        '
        Me.rdoFileYes.AutoSize = True
        Me.rdoFileYes.Checked = True
        Me.rdoFileYes.Location = New System.Drawing.Point(3, 3)
        Me.rdoFileYes.Name = "rdoFileYes"
        Me.rdoFileYes.Size = New System.Drawing.Size(43, 17)
        Me.rdoFileYes.TabIndex = 3
        Me.rdoFileYes.TabStop = True
        Me.rdoFileYes.Text = "Yes"
        Me.rdoFileYes.UseVisualStyleBackColor = True
        '
        'rdoFileNo
        '
        Me.rdoFileNo.AutoSize = True
        Me.rdoFileNo.Location = New System.Drawing.Point(52, 3)
        Me.rdoFileNo.Name = "rdoFileNo"
        Me.rdoFileNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoFileNo.TabIndex = 4
        Me.rdoFileNo.Text = "No"
        Me.rdoFileNo.UseVisualStyleBackColor = True
        '
        'lblPOR
        '
        Me.lblPOR.AutoSize = True
        Me.lblPOR.Location = New System.Drawing.Point(3, 107)
        Me.lblPOR.Name = "lblPOR"
        Me.lblPOR.Size = New System.Drawing.Size(93, 13)
        Me.lblPOR.TabIndex = 6
        Me.lblPOR.Text = "Length of Interval:"
        '
        'numDays
        '
        Me.numDays.Location = New System.Drawing.Point(126, 123)
        Me.numDays.Name = "numDays"
        Me.numDays.Size = New System.Drawing.Size(55, 20)
        Me.numDays.TabIndex = 9
        '
        'lblDays
        '
        Me.lblDays.AutoSize = True
        Me.lblDays.Location = New System.Drawing.Point(86, 128)
        Me.lblDays.Name = "lblDays"
        Me.lblDays.Size = New System.Drawing.Size(34, 13)
        Me.lblDays.TabIndex = 11
        Me.lblDays.Text = "Days:"
        '
        'numHours
        '
        Me.numHours.Location = New System.Drawing.Point(239, 123)
        Me.numHours.Name = "numHours"
        Me.numHours.Size = New System.Drawing.Size(55, 20)
        Me.numHours.TabIndex = 8
        '
        'lblHours
        '
        Me.lblHours.AutoSize = True
        Me.lblHours.Location = New System.Drawing.Point(195, 128)
        Me.lblHours.Name = "lblHours"
        Me.lblHours.Size = New System.Drawing.Size(38, 13)
        Me.lblHours.TabIndex = 12
        Me.lblHours.Text = "Hours:"
        '
        'numMinutes
        '
        Me.numMinutes.Location = New System.Drawing.Point(359, 123)
        Me.numMinutes.Name = "numMinutes"
        Me.numMinutes.Size = New System.Drawing.Size(55, 20)
        Me.numMinutes.TabIndex = 7
        '
        'lblMinutes
        '
        Me.lblMinutes.AutoSize = True
        Me.lblMinutes.Location = New System.Drawing.Point(306, 128)
        Me.lblMinutes.Name = "lblMinutes"
        Me.lblMinutes.Size = New System.Drawing.Size(47, 13)
        Me.lblMinutes.TabIndex = 13
        Me.lblMinutes.Text = "Minutes:"
        '
        'numSeconds
        '
        Me.numSeconds.Location = New System.Drawing.Point(478, 123)
        Me.numSeconds.Name = "numSeconds"
        Me.numSeconds.Size = New System.Drawing.Size(55, 20)
        Me.numSeconds.TabIndex = 10
        '
        'lblSeconds
        '
        Me.lblSeconds.AutoSize = True
        Me.lblSeconds.Location = New System.Drawing.Point(420, 128)
        Me.lblSeconds.Name = "lblSeconds"
        Me.lblSeconds.Size = New System.Drawing.Size(52, 13)
        Me.lblSeconds.TabIndex = 14
        Me.lblSeconds.Text = "Seconds:"
        '
        'lblValColumn
        '
        Me.lblValColumn.AutoSize = True
        Me.lblValColumn.Location = New System.Drawing.Point(9, 9)
        Me.lblValColumn.Name = "lblValColumn"
        Me.lblValColumn.Size = New System.Drawing.Size(149, 13)
        Me.lblValColumn.TabIndex = 0
        Me.lblValColumn.Text = "Please Select a Value Column"
        '
        'cboValColumn
        '
        Me.cboValColumn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboValColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValColumn.FormattingEnabled = True
        Me.cboValColumn.Location = New System.Drawing.Point(12, 25)
        Me.cboValColumn.Name = "cboValColumn"
        Me.cboValColumn.Size = New System.Drawing.Size(668, 21)
        Me.cboValColumn.TabIndex = 1
        '
        'ucSelect
        '
        Me.ucSelect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucSelect.Location = New System.Drawing.Point(0, 0)
        Me.ucSelect.MinimumSize = New System.Drawing.Size(200, 200)
        Me.ucSelect.Name = "ucSelect"
        Me.ucSelect.Size = New System.Drawing.Size(692, 445)
        Me.ucSelect.TabIndex = 1
        '
        'frmNewSeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(692, 476)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlValColumn)
        Me.Controls.Add(Me.ucSelect)
        Me.Controls.Add(Me.flpButtons)
        Me.MinimumSize = New System.Drawing.Size(450, 450)
        Me.Name = "frmNewSeries"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Define Series"
        Me.flpButtons.ResumeLayout(False)
        Me.pnlValColumn.ResumeLayout(False)
        Me.pnlValColumn.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlAggregate.ResumeLayout(False)
        Me.pnlAggregate.PerformLayout()
        Me.grpDatabase.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.grpFile.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.numDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMinutes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSeconds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents flpButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ucSelect As ODMSDLConfigWiz.ucSelectRow
    Friend WithEvents pnlValColumn As System.Windows.Forms.Panel
    Friend WithEvents cboValColumn As System.Windows.Forms.ComboBox
    Friend WithEvents lblValColumn As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoAggregate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInstantaneous As System.Windows.Forms.RadioButton
    Friend WithEvents grpDatabase As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdoDBYes As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDBNo As System.Windows.Forms.RadioButton
    Friend WithEvents grpFile As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdoFileYes As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFileNo As System.Windows.Forms.RadioButton
    Friend WithEvents pnlAggregate As System.Windows.Forms.Panel
    Friend WithEvents lblPOR As System.Windows.Forms.Label
    Friend WithEvents lblSeconds As System.Windows.Forms.Label
    Friend WithEvents numSeconds As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMinutes As System.Windows.Forms.Label
    Friend WithEvents lblHours As System.Windows.Forms.Label
    Friend WithEvents numDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMinutes As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDays As System.Windows.Forms.Label
    Friend WithEvents numHours As System.Windows.Forms.NumericUpDown
End Class
