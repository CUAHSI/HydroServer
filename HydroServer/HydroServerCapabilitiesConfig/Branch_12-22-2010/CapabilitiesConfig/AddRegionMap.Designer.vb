<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddRegionMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddRegionMap))
        Me.lblMapTitle = New System.Windows.Forms.Label
        Me.txtMapTitle = New System.Windows.Forms.TextBox
        Me.chkIsVisible = New System.Windows.Forms.CheckBox
        Me.numTransparency = New System.Windows.Forms.NumericUpDown
        Me.txtDisplayName = New System.Windows.Forms.TextBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.chkIsBaseMap = New System.Windows.Forms.CheckBox
        Me.lblDisplayName = New System.Windows.Forms.Label
        Me.lblTransparency = New System.Windows.Forms.Label
        Me.chkIsTOC = New System.Windows.Forms.CheckBox
        Me.picMap = New System.Windows.Forms.PictureBox
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        CType(Me.numTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMapTitle
        '
        Me.lblMapTitle.AutoSize = True
        Me.lblMapTitle.Location = New System.Drawing.Point(12, 15)
        Me.lblMapTitle.Name = "lblMapTitle"
        Me.lblMapTitle.Size = New System.Drawing.Size(51, 13)
        Me.lblMapTitle.TabIndex = 0
        Me.lblMapTitle.Text = "Map Title"
        '
        'txtMapTitle
        '
        Me.txtMapTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMapTitle.Enabled = False
        Me.txtMapTitle.Location = New System.Drawing.Point(69, 12)
        Me.txtMapTitle.Name = "txtMapTitle"
        Me.txtMapTitle.Size = New System.Drawing.Size(119, 20)
        Me.txtMapTitle.TabIndex = 1
        '
        'chkIsVisible
        '
        Me.chkIsVisible.AutoSize = True
        Me.chkIsVisible.Checked = True
        Me.chkIsVisible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsVisible.Location = New System.Drawing.Point(15, 90)
        Me.chkIsVisible.Name = "chkIsVisible"
        Me.chkIsVisible.Size = New System.Drawing.Size(73, 17)
        Me.chkIsVisible.TabIndex = 6
        Me.chkIsVisible.Text = "Is Visible?"
        Me.chkIsVisible.UseVisualStyleBackColor = True
        '
        'numTransparency
        '
        Me.numTransparency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numTransparency.Location = New System.Drawing.Point(130, 64)
        Me.numTransparency.Name = "numTransparency"
        Me.numTransparency.Size = New System.Drawing.Size(58, 20)
        Me.numTransparency.TabIndex = 5
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDisplayName.Location = New System.Drawing.Point(90, 38)
        Me.txtDisplayName.MaxLength = 255
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(98, 20)
        Me.txtDisplayName.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkIsBaseMap)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMapTitle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMapTitle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDisplayName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDisplayName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTransparency)
        Me.SplitContainer1.Panel1.Controls.Add(Me.numTransparency)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkIsVisible)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkIsTOC)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.picMap)
        Me.SplitContainer1.Size = New System.Drawing.Size(424, 237)
        Me.SplitContainer1.SplitterDistance = 191
        Me.SplitContainer1.TabIndex = 0
        '
        'chkIsBaseMap
        '
        Me.chkIsBaseMap.AutoSize = True
        Me.chkIsBaseMap.Location = New System.Drawing.Point(15, 137)
        Me.chkIsBaseMap.Name = "chkIsBaseMap"
        Me.chkIsBaseMap.Size = New System.Drawing.Size(124, 17)
        Me.chkIsBaseMap.TabIndex = 8
        Me.chkIsBaseMap.Text = "Is Base Map Service"
        Me.chkIsBaseMap.UseVisualStyleBackColor = True
        '
        'lblDisplayName
        '
        Me.lblDisplayName.AutoSize = True
        Me.lblDisplayName.Location = New System.Drawing.Point(12, 41)
        Me.lblDisplayName.Name = "lblDisplayName"
        Me.lblDisplayName.Size = New System.Drawing.Size(72, 13)
        Me.lblDisplayName.TabIndex = 2
        Me.lblDisplayName.Text = "Display Name"
        '
        'lblTransparency
        '
        Me.lblTransparency.AutoSize = True
        Me.lblTransparency.Location = New System.Drawing.Point(12, 66)
        Me.lblTransparency.Name = "lblTransparency"
        Me.lblTransparency.Size = New System.Drawing.Size(112, 13)
        Me.lblTransparency.TabIndex = 4
        Me.lblTransparency.Text = "Transparency Percent"
        '
        'chkIsTOC
        '
        Me.chkIsTOC.AutoSize = True
        Me.chkIsTOC.Checked = True
        Me.chkIsTOC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsTOC.Location = New System.Drawing.Point(15, 113)
        Me.chkIsTOC.Name = "chkIsTOC"
        Me.chkIsTOC.Size = New System.Drawing.Size(138, 17)
        Me.chkIsTOC.TabIndex = 7
        Me.chkIsTOC.Text = "Is in Table of Contents?"
        Me.chkIsTOC.UseVisualStyleBackColor = True
        '
        'picMap
        '
        Me.picMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picMap.Location = New System.Drawing.Point(0, 0)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(229, 237)
        Me.picMap.TabIndex = 0
        Me.picMap.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.btnOK)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCancel)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 237)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(424, 29)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(346, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(265, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'AddRegionMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(424, 266)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddRegionMap"
        Me.Text = "Add Region Map Service"
        CType(Me.numTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMapTitle As System.Windows.Forms.Label
    Friend WithEvents txtMapTitle As System.Windows.Forms.TextBox
    Friend WithEvents chkIsVisible As System.Windows.Forms.CheckBox
    Friend WithEvents numTransparency As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTransparency As System.Windows.Forms.Label
    Friend WithEvents lblDisplayName As System.Windows.Forms.Label
    Friend WithEvents chkIsTOC As System.Windows.Forms.CheckBox
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkIsBaseMap As System.Windows.Forms.CheckBox
End Class
