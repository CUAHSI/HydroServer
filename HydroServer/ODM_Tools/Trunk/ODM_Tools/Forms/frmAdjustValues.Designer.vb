<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjustValues
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
		Me.btnOK = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.gboxAVMethod = New System.Windows.Forms.GroupBox
		Me.txtAVMDrift = New System.Windows.Forms.TextBox
		Me.txtAVMMultiply = New System.Windows.Forms.TextBox
		Me.txtAVMAdd = New System.Windows.Forms.TextBox
		Me.lblAVMDrift = New System.Windows.Forms.Label
		Me.lblAVMMultiply = New System.Windows.Forms.Label
		Me.lblAVMAdd = New System.Windows.Forms.Label
		Me.rbtnAVMAddConstant = New System.Windows.Forms.RadioButton
		Me.rbtnAVMMultConstant = New System.Windows.Forms.RadioButton
		Me.rbtnAVMLinearDrift = New System.Windows.Forms.RadioButton
		Me.gboxAVMethod.SuspendLayout()
		Me.SuspendLayout()
		'
		'btnOK
		'
		Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnOK.Location = New System.Drawing.Point(98, 205)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(72, 24)
		Me.btnOK.TabIndex = 1
		Me.btnOK.Text = "&OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCancel.Location = New System.Drawing.Point(176, 205)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(72, 24)
		Me.btnCancel.TabIndex = 2
		Me.btnCancel.Text = "&Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'gboxAVMethod
		'
		Me.gboxAVMethod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxAVMethod.Controls.Add(Me.txtAVMDrift)
		Me.gboxAVMethod.Controls.Add(Me.txtAVMMultiply)
		Me.gboxAVMethod.Controls.Add(Me.txtAVMAdd)
		Me.gboxAVMethod.Controls.Add(Me.lblAVMDrift)
		Me.gboxAVMethod.Controls.Add(Me.lblAVMMultiply)
		Me.gboxAVMethod.Controls.Add(Me.lblAVMAdd)
		Me.gboxAVMethod.Controls.Add(Me.rbtnAVMAddConstant)
		Me.gboxAVMethod.Controls.Add(Me.rbtnAVMMultConstant)
		Me.gboxAVMethod.Controls.Add(Me.rbtnAVMLinearDrift)
		Me.gboxAVMethod.Location = New System.Drawing.Point(8, 8)
		Me.gboxAVMethod.Name = "gboxAVMethod"
		Me.gboxAVMethod.Size = New System.Drawing.Size(240, 192)
		Me.gboxAVMethod.TabIndex = 0
		Me.gboxAVMethod.TabStop = False
		Me.gboxAVMethod.Text = "Adjust Value Methods"
		'
		'txtAVMDrift
		'
		Me.txtAVMDrift.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtAVMDrift.Enabled = False
		Me.txtAVMDrift.Location = New System.Drawing.Point(120, 160)
		Me.txtAVMDrift.Name = "txtAVMDrift"
		Me.txtAVMDrift.Size = New System.Drawing.Size(113, 20)
		Me.txtAVMDrift.TabIndex = 2
		'
		'txtAVMMultiply
		'
		Me.txtAVMMultiply.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtAVMMultiply.Enabled = False
		Me.txtAVMMultiply.Location = New System.Drawing.Point(120, 104)
		Me.txtAVMMultiply.Name = "txtAVMMultiply"
		Me.txtAVMMultiply.Size = New System.Drawing.Size(113, 20)
		Me.txtAVMMultiply.TabIndex = 8
		'
		'txtAVMAdd
		'
		Me.txtAVMAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtAVMAdd.Location = New System.Drawing.Point(120, 48)
		Me.txtAVMAdd.Name = "txtAVMAdd"
		Me.txtAVMAdd.Size = New System.Drawing.Size(113, 20)
		Me.txtAVMAdd.TabIndex = 5
		'
		'lblAVMDrift
		'
		Me.lblAVMDrift.Enabled = False
		Me.lblAVMDrift.Location = New System.Drawing.Point(24, 160)
		Me.lblAVMDrift.Name = "lblAVMDrift"
		Me.lblAVMDrift.Size = New System.Drawing.Size(94, 20)
		Me.lblAVMDrift.TabIndex = 1
		Me.lblAVMDrift.Text = "Final Gap Value  : "
		Me.lblAVMDrift.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblAVMMultiply
		'
		Me.lblAVMMultiply.Enabled = False
		Me.lblAVMMultiply.Location = New System.Drawing.Point(24, 104)
		Me.lblAVMMultiply.Name = "lblAVMMultiply"
		Me.lblAVMMultiply.Size = New System.Drawing.Size(94, 20)
		Me.lblAVMMultiply.TabIndex = 7
		Me.lblAVMMultiply.Text = "Constant Value : "
		Me.lblAVMMultiply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblAVMAdd
		'
		Me.lblAVMAdd.Location = New System.Drawing.Point(24, 48)
		Me.lblAVMAdd.Name = "lblAVMAdd"
		Me.lblAVMAdd.Size = New System.Drawing.Size(94, 20)
		Me.lblAVMAdd.TabIndex = 4
		Me.lblAVMAdd.Text = "Constant Value : "
		Me.lblAVMAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'rbtnAVMAddConstant
		'
		Me.rbtnAVMAddConstant.AutoSize = True
		Me.rbtnAVMAddConstant.Checked = True
		Me.rbtnAVMAddConstant.Location = New System.Drawing.Point(8, 24)
		Me.rbtnAVMAddConstant.Name = "rbtnAVMAddConstant"
		Me.rbtnAVMAddConstant.Size = New System.Drawing.Size(129, 17)
		Me.rbtnAVMAddConstant.TabIndex = 3
		Me.rbtnAVMAddConstant.TabStop = True
		Me.rbtnAVMAddConstant.Text = "Add A Constant Value"
		Me.rbtnAVMAddConstant.UseVisualStyleBackColor = True
		'
		'rbtnAVMMultConstant
		'
		Me.rbtnAVMMultConstant.AutoSize = True
		Me.rbtnAVMMultConstant.Location = New System.Drawing.Point(8, 80)
		Me.rbtnAVMMultConstant.Name = "rbtnAVMMultConstant"
		Me.rbtnAVMMultConstant.Size = New System.Drawing.Size(160, 17)
		Me.rbtnAVMMultConstant.TabIndex = 6
		Me.rbtnAVMMultConstant.Text = "Multiply By A Constant Value"
		Me.rbtnAVMMultConstant.UseVisualStyleBackColor = True
		'
		'rbtnAVMLinearDrift
		'
		Me.rbtnAVMLinearDrift.AutoSize = True
		Me.rbtnAVMLinearDrift.Location = New System.Drawing.Point(8, 136)
		Me.rbtnAVMLinearDrift.Name = "rbtnAVMLinearDrift"
		Me.rbtnAVMLinearDrift.Size = New System.Drawing.Size(166, 17)
		Me.rbtnAVMLinearDrift.TabIndex = 0
		Me.rbtnAVMLinearDrift.Text = "Apply A Linear Drift Correction"
		Me.rbtnAVMLinearDrift.UseVisualStyleBackColor = True
		'
		'frmAdjustValues
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(252, 236)
		Me.ControlBox = False
		Me.Controls.Add(Me.gboxAVMethod)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(500, 260)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(200, 260)
		Me.Name = "frmAdjustValues"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "Select Adjust Values Method"
		Me.gboxAVMethod.ResumeLayout(False)
		Me.gboxAVMethod.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnOK As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents gboxAVMethod As System.Windows.Forms.GroupBox
	Friend WithEvents rbtnAVMLinearDrift As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnAVMMultConstant As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnAVMAddConstant As System.Windows.Forms.RadioButton
	Friend WithEvents lblAVMAdd As System.Windows.Forms.Label
	Friend WithEvents lblAVMDrift As System.Windows.Forms.Label
	Friend WithEvents lblAVMMultiply As System.Windows.Forms.Label
	Friend WithEvents txtAVMDrift As System.Windows.Forms.TextBox
	Friend WithEvents txtAVMMultiply As System.Windows.Forms.TextBox
	Friend WithEvents txtAVMAdd As System.Windows.Forms.TextBox
End Class
