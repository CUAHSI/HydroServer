<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectMapServer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectMapServer))
        Me.cboServers = New System.Windows.Forms.ComboBox
        Me.btnAddServer = New System.Windows.Forms.Button
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lbNewMaps = New System.Windows.Forms.ListBox
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboServers
        '
        Me.cboServers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServers.FormattingEnabled = True
        Me.cboServers.Location = New System.Drawing.Point(12, 12)
        Me.cboServers.Name = "cboServers"
        Me.cboServers.Size = New System.Drawing.Size(341, 21)
        Me.cboServers.TabIndex = 0
        '
        'btnAddServer
        '
        Me.btnAddServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddServer.Location = New System.Drawing.Point(359, 12)
        Me.btnAddServer.Name = "btnAddServer"
        Me.btnAddServer.Size = New System.Drawing.Size(21, 21)
        Me.btnAddServer.TabIndex = 1
        Me.btnAddServer.Text = "+"
        Me.btnAddServer.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.btnApply)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnCancel)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 287)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(392, 29)
        Me.FlowLayoutPanel2.TabIndex = 3
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(314, 3)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(233, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lbNewMaps
        '
        Me.lbNewMaps.FormattingEnabled = True
        Me.lbNewMaps.Location = New System.Drawing.Point(12, 39)
        Me.lbNewMaps.Name = "lbNewMaps"
        Me.lbNewMaps.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbNewMaps.Size = New System.Drawing.Size(368, 238)
        Me.lbNewMaps.TabIndex = 2
        '
        'SelectMapServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(392, 316)
        Me.Controls.Add(Me.lbNewMaps)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.btnAddServer)
        Me.Controls.Add(Me.cboServers)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "SelectMapServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Map Server"
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboServers As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddServer As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents lbNewMaps As System.Windows.Forms.ListBox
End Class
