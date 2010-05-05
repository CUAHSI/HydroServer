<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDatabaseServer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectDatabaseServer))
        Me.cboServers = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPWD = New System.Windows.Forms.Label
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.txtPWD = New System.Windows.Forms.TextBox
        Me.btnGetList = New System.Windows.Forms.Button
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.ilStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.lbNewDatabases = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboServers
        '
        Me.cboServers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboServers.FormattingEnabled = True
        Me.cboServers.Location = New System.Drawing.Point(111, 12)
        Me.cboServers.Name = "cboServers"
        Me.cboServers.Size = New System.Drawing.Size(244, 21)
        Me.cboServers.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Username"
        '
        'lblPWD
        '
        Me.lblPWD.AutoSize = True
        Me.lblPWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPWD.Location = New System.Drawing.Point(12, 68)
        Me.lblPWD.Name = "lblPWD"
        Me.lblPWD.Size = New System.Drawing.Size(61, 13)
        Me.lblPWD.TabIndex = 3
        Me.lblPWD.Text = "Password"
        '
        'txtUser
        '
        Me.txtUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser.Location = New System.Drawing.Point(81, 39)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(274, 20)
        Me.txtUser.TabIndex = 2
        '
        'txtPWD
        '
        Me.txtPWD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPWD.Location = New System.Drawing.Point(79, 65)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Size = New System.Drawing.Size(276, 20)
        Me.txtPWD.TabIndex = 4
        Me.txtPWD.UseSystemPasswordChar = True
        '
        'btnGetList
        '
        Me.btnGetList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetList.Location = New System.Drawing.Point(12, 91)
        Me.btnGetList.Name = "btnGetList"
        Me.btnGetList.Size = New System.Drawing.Size(343, 23)
        Me.btnGetList.TabIndex = 5
        Me.btnGetList.Text = "Get Database List from the Server"
        Me.btnGetList.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.btnApply)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnCancel)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 180)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(367, 29)
        Me.FlowLayoutPanel2.TabIndex = 7
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(289, 3)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(208, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ilStatus
        '
        Me.ilStatus.ImageStream = CType(resources.GetObject("ilStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.ilStatus.Images.SetKeyName(0, "finished.png")
        Me.ilStatus.Images.SetKeyName(1, "add.png")
        Me.ilStatus.Images.SetKeyName(2, "missing.png")
        Me.ilStatus.Images.SetKeyName(3, "delete.png")
        '
        'lbNewDatabases
        '
        Me.lbNewDatabases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNewDatabases.FormattingEnabled = True
        Me.lbNewDatabases.Location = New System.Drawing.Point(12, 120)
        Me.lbNewDatabases.Name = "lbNewDatabases"
        Me.lbNewDatabases.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbNewDatabases.Size = New System.Drawing.Size(343, 56)
        Me.lbNewDatabases.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Server Address"
        '
        'SelectDatabaseServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(367, 209)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbNewDatabases)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.btnGetList)
        Me.Controls.Add(Me.txtPWD)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.lblPWD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboServers)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "SelectDatabaseServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add ODM Databases"
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboServers As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPWD As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPWD As System.Windows.Forms.TextBox
    Friend WithEvents btnGetList As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ilStatus As System.Windows.Forms.ImageList
    Friend WithEvents lbNewDatabases As System.Windows.Forms.ListBox
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
