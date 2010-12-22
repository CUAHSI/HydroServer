<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateNewQualifier
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
		Me.lblQCode = New System.Windows.Forms.Label
		Me.tboxQDesc = New System.Windows.Forms.TextBox
		Me.lblQDesc = New System.Windows.Forms.Label
		Me.tboxQCode = New System.Windows.Forms.TextBox
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOk = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'lblQCode
		'
		Me.lblQCode.Location = New System.Drawing.Point(4, 4)
		Me.lblQCode.Name = "lblQCode"
		Me.lblQCode.Size = New System.Drawing.Size(66, 16)
		Me.lblQCode.TabIndex = 4
		Me.lblQCode.Text = "Code :"
		Me.lblQCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxQDesc
		'
		Me.tboxQDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxQDesc.Location = New System.Drawing.Point(72, 24)
		Me.tboxQDesc.Name = "tboxQDesc"
		Me.tboxQDesc.Size = New System.Drawing.Size(352, 20)
		Me.tboxQDesc.TabIndex = 7
		'
		'lblQDesc
		'
		Me.lblQDesc.Location = New System.Drawing.Point(4, 24)
		Me.lblQDesc.Name = "lblQDesc"
		Me.lblQDesc.Size = New System.Drawing.Size(66, 16)
		Me.lblQDesc.TabIndex = 8
		Me.lblQDesc.Text = "Description : "
		Me.lblQDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxQCode
		'
		Me.tboxQCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxQCode.Location = New System.Drawing.Point(72, 2)
		Me.tboxQCode.Name = "tboxQCode"
		Me.tboxQCode.Size = New System.Drawing.Size(136, 20)
		Me.tboxQCode.TabIndex = 9
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCancel.Location = New System.Drawing.Point(360, 50)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(64, 24)
		Me.btnCancel.TabIndex = 10
		Me.btnCancel.Text = "&Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnOk
		'
		Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnOk.Location = New System.Drawing.Point(290, 50)
		Me.btnOk.Name = "btnOk"
		Me.btnOk.Size = New System.Drawing.Size(64, 24)
		Me.btnOk.TabIndex = 11
		Me.btnOk.Text = "&OK"
		Me.btnOk.UseVisualStyleBackColor = True
		'
		'frmCreateNewQualifier
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(434, 81)
		Me.ControlBox = False
		Me.Controls.Add(Me.btnOk)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.tboxQCode)
		Me.Controls.Add(Me.lblQDesc)
		Me.Controls.Add(Me.tboxQDesc)
		Me.Controls.Add(Me.lblQCode)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(500, 108)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(250, 108)
		Me.Name = "frmCreateNewQualifier"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Create A New Qualifier"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblQCode As System.Windows.Forms.Label
	Friend WithEvents tboxQDesc As System.Windows.Forms.TextBox
	Friend WithEvents lblQDesc As System.Windows.Forms.Label
	Friend WithEvents tboxQCode As System.Windows.Forms.TextBox
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
