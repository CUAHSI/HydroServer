<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewMethod
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
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
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
        Me.grpRequired.Controls.Add(Me.lblDescription)
        Me.grpRequired.Controls.Add(Me.txtDescription)
        Me.grpRequired.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRequired.Location = New System.Drawing.Point(0, 0)
        Me.grpRequired.Name = "grpRequired"
        Me.grpRequired.Size = New System.Drawing.Size(300, 103)
        Me.grpRequired.TabIndex = 0
        Me.grpRequired.TabStop = False
        Me.grpRequired.Text = "Required"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(6, 16)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(21, 32)
        Me.txtDescription.MaxLength = 255
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescription.Size = New System.Drawing.Size(264, 59)
        Me.txtDescription.TabIndex = 1
        '
        'grpOptional
        '
        Me.grpOptional.Controls.Add(Me.lblLink)
        Me.grpOptional.Controls.Add(Me.txtLink)
        Me.grpOptional.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpOptional.Location = New System.Drawing.Point(0, 103)
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
        Me.txtLink.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
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
        Me.flpButtons.Location = New System.Drawing.Point(0, 206)
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
        'frmNewMethod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(300, 237)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpOptional)
        Me.Controls.Add(Me.grpRequired)
        Me.Controls.Add(Me.flpButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmNewMethod"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Add New Method"
        Me.grpRequired.ResumeLayout(False)
        Me.grpRequired.PerformLayout()
        Me.grpOptional.ResumeLayout(False)
        Me.grpOptional.PerformLayout()
        Me.flpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpRequired As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents grpOptional As System.Windows.Forms.GroupBox
    Friend WithEvents txtLink As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblLink As System.Windows.Forms.Label
    Friend WithEvents flpButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
