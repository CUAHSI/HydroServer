<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditFlagValues
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
		Me.components = New System.ComponentModel.Container
		Me.lblQualifier = New System.Windows.Forms.Label
		Me.cboxQualifier = New System.Windows.Forms.ComboBox
		Me.ttipFlagValues = New System.Windows.Forms.ToolTip(Me.components)
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOk = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'lblQualifier
		'
		Me.lblQualifier.Location = New System.Drawing.Point(8, 4)
		Me.lblQualifier.Name = "lblQualifier"
		Me.lblQualifier.Size = New System.Drawing.Size(56, 16)
		Me.lblQualifier.TabIndex = 0
		Me.lblQualifier.Text = "Qualifier:"
		Me.lblQualifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'cboxQualifier
		'
		Me.cboxQualifier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cboxQualifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboxQualifier.FormattingEnabled = True
		Me.cboxQualifier.Location = New System.Drawing.Point(8, 20)
		Me.cboxQualifier.Name = "cboxQualifier"
		Me.cboxQualifier.Size = New System.Drawing.Size(377, 21)
		Me.cboxQualifier.TabIndex = 1
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(321, 47)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(64, 24)
		Me.btnCancel.TabIndex = 4
		Me.btnCancel.Text = "&Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnOk
		'
		Me.btnOk.Location = New System.Drawing.Point(251, 47)
		Me.btnOk.Name = "btnOk"
		Me.btnOk.Size = New System.Drawing.Size(64, 24)
		Me.btnOk.TabIndex = 5
		Me.btnOk.Text = "&OK"
		Me.btnOk.UseVisualStyleBackColor = True
		'
		'frmEditFlagValues
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(392, 81)
		Me.ControlBox = False
		Me.Controls.Add(Me.btnOk)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.cboxQualifier)
		Me.Controls.Add(Me.lblQualifier)
		Me.MaximumSize = New System.Drawing.Size(500, 108)
		Me.MinimumSize = New System.Drawing.Size(250, 108)
		Me.Name = "frmEditFlagValues"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Flag Values"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents lblQualifier As System.Windows.Forms.Label
	Friend WithEvents cboxQualifier As System.Windows.Forms.ComboBox
	Friend WithEvents ttipFlagValues As System.Windows.Forms.ToolTip
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
