<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataExport
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
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataExport))
		Me.pic_exprtAnimation = New System.Windows.Forms.PictureBox
		Me.tmrDone = New System.Windows.Forms.Timer(Me.components)
		Me.btnCancel = New System.Windows.Forms.Button
		CType(Me.pic_exprtAnimation, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pic_exprtAnimation
		'
		Me.pic_exprtAnimation.AccessibleRole = System.Windows.Forms.AccessibleRole.Animation
		Me.pic_exprtAnimation.Dock = System.Windows.Forms.DockStyle.Top
		Me.pic_exprtAnimation.Image = CType(resources.GetObject("pic_exprtAnimation.Image"), System.Drawing.Image)
		Me.pic_exprtAnimation.Location = New System.Drawing.Point(0, 0)
		Me.pic_exprtAnimation.Name = "pic_exprtAnimation"
		Me.pic_exprtAnimation.Size = New System.Drawing.Size(284, 60)
		Me.pic_exprtAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.pic_exprtAnimation.TabIndex = 1
		Me.pic_exprtAnimation.TabStop = False
		'
		'tmrDone
		'
		Me.tmrDone.Enabled = True
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(97, 66)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(90, 25)
		Me.btnCancel.TabIndex = 2
		Me.btnCancel.Text = "&Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'frmDataExport
		'
		Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Animation
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.ClientSize = New System.Drawing.Size(284, 98)
		Me.ControlBox = False
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.pic_exprtAnimation)
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmDataExport"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Exporting Data"
		Me.TopMost = True
		CType(Me.pic_exprtAnimation, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pic_exprtAnimation As System.Windows.Forms.PictureBox
	Friend WithEvents tmrDone As System.Windows.Forms.Timer
	Friend WithEvents btnCancel As System.Windows.Forms.Button

End Class
