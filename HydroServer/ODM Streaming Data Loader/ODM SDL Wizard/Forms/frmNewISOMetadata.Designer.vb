<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewISOMetadata
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
        Me.grpRequired = New System.Windows.Forms.GroupBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.lblAbstract = New System.Windows.Forms.Label
        Me.txtAbstract = New System.Windows.Forms.TextBox
        Me.lblProfileVs = New System.Windows.Forms.Label
        Me.txtProfileVs = New System.Windows.Forms.TextBox
        Me.lblTopicCategory = New System.Windows.Forms.Label
        Me.cboTopicCategory = New System.Windows.Forms.ComboBox
        Me.grpOptional = New System.Windows.Forms.GroupBox
        Me.lblLink = New System.Windows.Forms.Label
        Me.txtLink = New System.Windows.Forms.TextBox
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpRequired.SuspendLayout()
        Me.grpOptional.SuspendLayout()
        Me.flpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRequired
        '
        Me.grpRequired.Controls.Add(Me.lblTitle)
        Me.grpRequired.Controls.Add(Me.txtTitle)
        Me.grpRequired.Controls.Add(Me.lblAbstract)
        Me.grpRequired.Controls.Add(Me.txtAbstract)
        Me.grpRequired.Controls.Add(Me.lblProfileVs)
        Me.grpRequired.Controls.Add(Me.txtProfileVs)
        Me.grpRequired.Controls.Add(Me.lblTopicCategory)
        Me.grpRequired.Controls.Add(Me.cboTopicCategory)
        Me.grpRequired.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRequired.Location = New System.Drawing.Point(0, 0)
        Me.grpRequired.Name = "grpRequired"
        Me.grpRequired.Size = New System.Drawing.Size(300, 307)
        Me.grpRequired.TabIndex = 0
        Me.grpRequired.TabStop = False
        Me.grpRequired.Text = "Required"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(6, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(27, 13)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title"
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Location = New System.Drawing.Point(21, 32)
        Me.txtTitle.MaxLength = 255
        Me.txtTitle.Multiline = True
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTitle.Size = New System.Drawing.Size(264, 59)
        Me.txtTitle.TabIndex = 1
        '
        'lblAbstract
        '
        Me.lblAbstract.AutoSize = True
        Me.lblAbstract.Location = New System.Drawing.Point(6, 94)
        Me.lblAbstract.Name = "lblAbstract"
        Me.lblAbstract.Size = New System.Drawing.Size(46, 13)
        Me.lblAbstract.TabIndex = 2
        Me.lblAbstract.Text = "Abstract"
        '
        'txtAbstract
        '
        Me.txtAbstract.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAbstract.Location = New System.Drawing.Point(21, 110)
        Me.txtAbstract.Multiline = True
        Me.txtAbstract.Name = "txtAbstract"
        Me.txtAbstract.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAbstract.Size = New System.Drawing.Size(264, 59)
        Me.txtAbstract.TabIndex = 3
        '
        'lblProfileVs
        '
        Me.lblProfileVs.AutoSize = True
        Me.lblProfileVs.Location = New System.Drawing.Point(6, 172)
        Me.lblProfileVs.Name = "lblProfileVs"
        Me.lblProfileVs.Size = New System.Drawing.Size(74, 13)
        Me.lblProfileVs.TabIndex = 4
        Me.lblProfileVs.Text = "Profile Version"
        '
        'txtProfileVs
        '
        Me.txtProfileVs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfileVs.Location = New System.Drawing.Point(21, 188)
        Me.txtProfileVs.MaxLength = 255
        Me.txtProfileVs.Multiline = True
        Me.txtProfileVs.Name = "txtProfileVs"
        Me.txtProfileVs.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtProfileVs.Size = New System.Drawing.Size(264, 59)
        Me.txtProfileVs.TabIndex = 5
        '
        'lblTopicCategory
        '
        Me.lblTopicCategory.AutoSize = True
        Me.lblTopicCategory.Location = New System.Drawing.Point(6, 250)
        Me.lblTopicCategory.Name = "lblTopicCategory"
        Me.lblTopicCategory.Size = New System.Drawing.Size(79, 13)
        Me.lblTopicCategory.TabIndex = 6
        Me.lblTopicCategory.Text = "Topic Category"
        '
        'cboTopicCategory
        '
        Me.cboTopicCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTopicCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTopicCategory.FormattingEnabled = True
        Me.cboTopicCategory.Location = New System.Drawing.Point(21, 266)
        Me.cboTopicCategory.MaxDropDownItems = 10
        Me.cboTopicCategory.Name = "cboTopicCategory"
        Me.cboTopicCategory.Size = New System.Drawing.Size(264, 21)
        Me.cboTopicCategory.TabIndex = 7
        '
        'grpOptional
        '
        Me.grpOptional.Controls.Add(Me.lblLink)
        Me.grpOptional.Controls.Add(Me.txtLink)
        Me.grpOptional.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpOptional.Location = New System.Drawing.Point(0, 307)
        Me.grpOptional.Name = "grpOptional"
        Me.grpOptional.Size = New System.Drawing.Size(300, 103)
        Me.grpOptional.TabIndex = 1
        Me.grpOptional.TabStop = False
        Me.grpOptional.Text = "Optional"
        '
        'lblLink
        '
        Me.lblLink.AutoSize = True
        Me.lblLink.Location = New System.Drawing.Point(6, 16)
        Me.lblLink.Name = "lblLink"
        Me.lblLink.Size = New System.Drawing.Size(27, 13)
        Me.lblLink.TabIndex = 0
        Me.lblLink.Text = "Link"
        '
        'txtLink
        '
        Me.txtLink.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLink.Location = New System.Drawing.Point(21, 32)
        Me.txtLink.MaxLength = 500
        Me.txtLink.Multiline = True
        Me.txtLink.Name = "txtLink"
        Me.txtLink.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLink.Size = New System.Drawing.Size(264, 59)
        Me.txtLink.TabIndex = 1
        '
        'flpButtons
        '
        Me.flpButtons.AutoSize = True
        Me.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpButtons.Controls.Add(Me.btnOK)
        Me.flpButtons.Controls.Add(Me.btnCancel)
        Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpButtons.Location = New System.Drawing.Point(0, 410)
        Me.flpButtons.Name = "flpButtons"
        Me.flpButtons.Size = New System.Drawing.Size(300, 31)
        Me.flpButtons.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        'frmNewISOMetadata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(300, 441)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpOptional)
        Me.Controls.Add(Me.grpRequired)
        Me.Controls.Add(Me.flpButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmNewISOMetadata"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Add New ISO Metadata"
        Me.grpRequired.ResumeLayout(False)
        Me.grpRequired.PerformLayout()
        Me.grpOptional.ResumeLayout(False)
        Me.grpOptional.PerformLayout()
        Me.flpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpRequired As System.Windows.Forms.GroupBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents cboTopicCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtProfileVs As System.Windows.Forms.TextBox
    Friend WithEvents txtAbstract As System.Windows.Forms.TextBox
    Friend WithEvents grpOptional As System.Windows.Forms.GroupBox
    Friend WithEvents txtLink As System.Windows.Forms.TextBox
    Friend WithEvents flpButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblAbstract As System.Windows.Forms.Label
    Friend WithEvents lblProfileVs As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblTopicCategory As System.Windows.Forms.Label
    Friend WithEvents lblLink As System.Windows.Forms.Label
End Class
