<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewQCL
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
        Me.txtExplanation = New System.Windows.Forms.TextBox
        Me.grpRequired = New System.Windows.Forms.GroupBox
        Me.lblExplanation = New System.Windows.Forms.Label
        Me.lblQCLCode = New System.Windows.Forms.Label
        Me.txtQCLCode = New System.Windows.Forms.TextBox
        Me.lblDefinition = New System.Windows.Forms.Label
        Me.txtDefinition = New System.Windows.Forms.TextBox
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpRequired.SuspendLayout()
        Me.flpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtExplanation
        '
        Me.txtExplanation.AcceptsReturn = True
        Me.txtExplanation.AllowDrop = True
        Me.txtExplanation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExplanation.Location = New System.Drawing.Point(21, 110)
        Me.txtExplanation.Multiline = True
        Me.txtExplanation.Name = "txtExplanation"
        Me.txtExplanation.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtExplanation.Size = New System.Drawing.Size(267, 59)
        Me.txtExplanation.TabIndex = 5
        '
        'grpRequired
        '
        Me.grpRequired.Controls.Add(Me.lblQCLCode)
        Me.grpRequired.Controls.Add(Me.txtQCLCode)
        Me.grpRequired.Controls.Add(Me.lblDefinition)
        Me.grpRequired.Controls.Add(Me.txtDefinition)
        Me.grpRequired.Controls.Add(Me.lblExplanation)
        Me.grpRequired.Controls.Add(Me.txtExplanation)
        Me.grpRequired.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpRequired.Location = New System.Drawing.Point(0, 0)
        Me.grpRequired.Name = "grpRequired"
        Me.grpRequired.Size = New System.Drawing.Size(300, 186)
        Me.grpRequired.TabIndex = 0
        Me.grpRequired.TabStop = False
        Me.grpRequired.Text = "Required"
        '
        'lblExplanation
        '
        Me.lblExplanation.AutoSize = True
        Me.lblExplanation.Location = New System.Drawing.Point(6, 94)
        Me.lblExplanation.Name = "lblExplanation"
        Me.lblExplanation.Size = New System.Drawing.Size(62, 13)
        Me.lblExplanation.TabIndex = 4
        Me.lblExplanation.Text = "Explanation"
        '
        'lblQCLCode
        '
        Me.lblQCLCode.AutoSize = True
        Me.lblQCLCode.Location = New System.Drawing.Point(6, 16)
        Me.lblQCLCode.Name = "lblQCLCode"
        Me.lblQCLCode.Size = New System.Drawing.Size(132, 13)
        Me.lblQCLCode.TabIndex = 0
        Me.lblQCLCode.Text = "Quality Control Level Code"
        '
        'txtQCLCode
        '
        Me.txtQCLCode.AllowDrop = True
        Me.txtQCLCode.Location = New System.Drawing.Point(21, 32)
        Me.txtQCLCode.MaxLength = 50
        Me.txtQCLCode.Name = "txtQCLCode"
        Me.txtQCLCode.Size = New System.Drawing.Size(267, 20)
        Me.txtQCLCode.TabIndex = 1
        '
        'lblDefinition
        '
        Me.lblDefinition.AutoSize = True
        Me.lblDefinition.Location = New System.Drawing.Point(6, 55)
        Me.lblDefinition.Name = "lblDefinition"
        Me.lblDefinition.Size = New System.Drawing.Size(51, 13)
        Me.lblDefinition.TabIndex = 2
        Me.lblDefinition.Text = "Definition"
        '
        'txtDefinition
        '
        Me.txtDefinition.AllowDrop = True
        Me.txtDefinition.Location = New System.Drawing.Point(21, 71)
        Me.txtDefinition.MaxLength = 255
        Me.txtDefinition.Name = "txtDefinition"
        Me.txtDefinition.Size = New System.Drawing.Size(267, 20)
        Me.txtDefinition.TabIndex = 3
        '
        'flpButtons
        '
        Me.flpButtons.AutoSize = True
        Me.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpButtons.Controls.Add(Me.btnOK)
        Me.flpButtons.Controls.Add(Me.btnCancel)
        Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpButtons.Location = New System.Drawing.Point(0, 186)
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
        'frmNewQCL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(300, 217)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpRequired)
        Me.Controls.Add(Me.flpButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmNewQCL"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Add New Quality Control Level"
        Me.grpRequired.ResumeLayout(False)
        Me.grpRequired.PerformLayout()
        Me.flpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtExplanation As System.Windows.Forms.TextBox
    Friend WithEvents grpRequired As System.Windows.Forms.GroupBox
    Friend WithEvents lblExplanation As System.Windows.Forms.Label
    Friend WithEvents lblQCLCode As System.Windows.Forms.Label
    Friend WithEvents lblDefinition As System.Windows.Forms.Label
    Friend WithEvents flpButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtDefinition As System.Windows.Forms.TextBox
    Friend WithEvents txtQCLCode As System.Windows.Forms.TextBox
End Class
