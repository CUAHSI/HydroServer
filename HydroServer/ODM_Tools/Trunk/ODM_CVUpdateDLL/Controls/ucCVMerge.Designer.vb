<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCVMerge
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucCVMerge))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgvWeb = New System.Windows.Forms.DataGridView
        Me.lblWebCV = New System.Windows.Forms.Label
        Me.dgvLocal = New System.Windows.Forms.DataGridView
        Me.lblLocalCV = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cboCVType = New System.Windows.Forms.ToolStripComboBox
        Me.btnRefreshWeb = New System.Windows.Forms.ToolStripButton
        Me.btnRefreshLocal = New System.Windows.Forms.ToolStripButton
        Me.btnUpdateLocal = New System.Windows.Forms.ToolStripButton
        Me.btnFixRow = New System.Windows.Forms.ToolStripButton
        Me.btnApply = New System.Windows.Forms.ToolStripButton
        Me.btnFinished = New System.Windows.Forms.ToolStripButton
        Me.tscControls = New System.Windows.Forms.ToolStripContainer
        Me.flpKey = New System.Windows.Forms.FlowLayoutPanel
        Me.lblKeyText = New System.Windows.Forms.Label
        Me.lblKeyCorrect = New System.Windows.Forms.Label
        Me.lblKeyAdded = New System.Windows.Forms.Label
        Me.lblKeyChanged = New System.Windows.Forms.Label
        Me.lblKeyUnapproved = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLocal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.tscControls.ContentPanel.SuspendLayout()
        Me.tscControls.TopToolStripPanel.SuspendLayout()
        Me.tscControls.SuspendLayout()
        Me.flpKey.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvWeb)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblWebCV)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(10)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvLocal)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblLocalCV)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.SplitContainer1.Size = New System.Drawing.Size(650, 462)
        Me.SplitContainer1.SplitterDistance = 317
        Me.SplitContainer1.SplitterIncrement = 2
        Me.SplitContainer1.TabIndex = 2
        '
        'dgvWeb
        '
        Me.dgvWeb.AllowUserToAddRows = False
        Me.dgvWeb.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvWeb.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvWeb.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvWeb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWeb.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvWeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWeb.Location = New System.Drawing.Point(10, 23)
        Me.dgvWeb.MultiSelect = False
        Me.dgvWeb.Name = "dgvWeb"
        Me.dgvWeb.ReadOnly = True
        Me.dgvWeb.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvWeb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWeb.Size = New System.Drawing.Size(297, 429)
        Me.dgvWeb.TabIndex = 1
        '
        'lblWebCV
        '
        Me.lblWebCV.AutoEllipsis = True
        Me.lblWebCV.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblWebCV.Location = New System.Drawing.Point(10, 10)
        Me.lblWebCV.Name = "lblWebCV"
        Me.lblWebCV.Size = New System.Drawing.Size(297, 13)
        Me.lblWebCV.TabIndex = 0
        Me.lblWebCV.Text = "Master CV"
        Me.lblWebCV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvLocal
        '
        Me.dgvLocal.AllowUserToAddRows = False
        Me.dgvLocal.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray
        Me.dgvLocal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLocal.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLocal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLocal.Location = New System.Drawing.Point(10, 23)
        Me.dgvLocal.MultiSelect = False
        Me.dgvLocal.Name = "dgvLocal"
        Me.dgvLocal.ReadOnly = True
        Me.dgvLocal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvLocal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLocal.Size = New System.Drawing.Size(309, 429)
        Me.dgvLocal.TabIndex = 1
        '
        'lblLocalCV
        '
        Me.lblLocalCV.AutoEllipsis = True
        Me.lblLocalCV.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLocalCV.Location = New System.Drawing.Point(10, 10)
        Me.lblLocalCV.Name = "lblLocalCV"
        Me.lblLocalCV.Size = New System.Drawing.Size(309, 13)
        Me.lblLocalCV.TabIndex = 0
        Me.lblLocalCV.Text = "Local CV"
        Me.lblLocalCV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboCVType, Me.btnRefreshWeb, Me.btnRefreshLocal, Me.btnUpdateLocal, Me.btnFixRow, Me.btnApply, Me.btnFinished})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(630, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cboCVType
        '
        Me.cboCVType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCVType.Items.AddRange(New Object() {"Censor Code CV", "Data Type CV", "General Category CV", "Sample Medium CV", "Sample Type CV", "Topic Category CV", "Value Type CV", "Variable Name CV", "Vertical Datum CV", "Speciation CV", "Spatial References", "Units"})
        Me.cboCVType.Name = "cboCVType"
        Me.cboCVType.Size = New System.Drawing.Size(121, 25)
        '
        'btnRefreshWeb
        '
        Me.btnRefreshWeb.Image = CType(resources.GetObject("btnRefreshWeb.Image"), System.Drawing.Image)
        Me.btnRefreshWeb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefreshWeb.Name = "btnRefreshWeb"
        Me.btnRefreshWeb.Size = New System.Drawing.Size(81, 22)
        Me.btnRefreshWeb.Text = "Master CV"
        '
        'btnRefreshLocal
        '
        Me.btnRefreshLocal.Image = CType(resources.GetObject("btnRefreshLocal.Image"), System.Drawing.Image)
        Me.btnRefreshLocal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefreshLocal.Name = "btnRefreshLocal"
        Me.btnRefreshLocal.Size = New System.Drawing.Size(73, 22)
        Me.btnRefreshLocal.Text = "Local CV"
        '
        'btnUpdateLocal
        '
        Me.btnUpdateLocal.Image = CType(resources.GetObject("btnUpdateLocal.Image"), System.Drawing.Image)
        Me.btnUpdateLocal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpdateLocal.Name = "btnUpdateLocal"
        Me.btnUpdateLocal.Size = New System.Drawing.Size(114, 22)
        Me.btnUpdateLocal.Text = "Update Local CV"
        '
        'btnFixRow
        '
        Me.btnFixRow.Image = CType(resources.GetObject("btnFixRow.Image"), System.Drawing.Image)
        Me.btnFixRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFixRow.Name = "btnFixRow"
        Me.btnFixRow.Size = New System.Drawing.Size(67, 22)
        Me.btnFixRow.Text = "Fix Row"
        Me.btnFixRow.Visible = False
        '
        'btnApply
        '
        Me.btnApply.Image = CType(resources.GetObject("btnApply.Image"), System.Drawing.Image)
        Me.btnApply.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(58, 22)
        Me.btnApply.Text = "Apply"
        Me.btnApply.Visible = False
        '
        'btnFinished
        '
        Me.btnFinished.Image = CType(resources.GetObject("btnFinished.Image"), System.Drawing.Image)
        Me.btnFinished.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFinished.Name = "btnFinished"
        Me.btnFinished.Size = New System.Drawing.Size(71, 22)
        Me.btnFinished.Text = "Finished"
        '
        'tscControls
        '
        '
        'tscControls.ContentPanel
        '
        Me.tscControls.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.tscControls.ContentPanel.Controls.Add(Me.flpKey)
        Me.tscControls.ContentPanel.Size = New System.Drawing.Size(650, 475)
        Me.tscControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tscControls.Location = New System.Drawing.Point(0, 0)
        Me.tscControls.Name = "tscControls"
        Me.tscControls.Size = New System.Drawing.Size(650, 500)
        Me.tscControls.TabIndex = 4
        Me.tscControls.Text = "ToolStripContainer1"
        '
        'tscControls.TopToolStripPanel
        '
        Me.tscControls.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'flpKey
        '
        Me.flpKey.AutoSize = True
        Me.flpKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpKey.Controls.Add(Me.lblKeyText)
        Me.flpKey.Controls.Add(Me.lblKeyCorrect)
        Me.flpKey.Controls.Add(Me.lblKeyAdded)
        Me.flpKey.Controls.Add(Me.lblKeyChanged)
        Me.flpKey.Controls.Add(Me.lblKeyUnapproved)
        Me.flpKey.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpKey.Location = New System.Drawing.Point(0, 462)
        Me.flpKey.Name = "flpKey"
        Me.flpKey.Size = New System.Drawing.Size(650, 13)
        Me.flpKey.TabIndex = 3
        '
        'lblKeyText
        '
        Me.lblKeyText.AutoSize = True
        Me.lblKeyText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeyText.Location = New System.Drawing.Point(3, 0)
        Me.lblKeyText.Name = "lblKeyText"
        Me.lblKeyText.Size = New System.Drawing.Size(120, 13)
        Me.lblKeyText.TabIndex = 0
        Me.lblKeyText.Text = "Local CV Color Key:"
        '
        'lblKeyCorrect
        '
        Me.lblKeyCorrect.AutoSize = True
        Me.lblKeyCorrect.Location = New System.Drawing.Point(129, 0)
        Me.lblKeyCorrect.Name = "lblKeyCorrect"
        Me.lblKeyCorrect.Size = New System.Drawing.Size(119, 13)
        Me.lblKeyCorrect.TabIndex = 4
        Me.lblKeyCorrect.Text = "No Changes Nessecary"
        '
        'lblKeyAdded
        '
        Me.lblKeyAdded.AutoSize = True
        Me.lblKeyAdded.ForeColor = System.Drawing.Color.Orange
        Me.lblKeyAdded.Location = New System.Drawing.Point(254, 0)
        Me.lblKeyAdded.Name = "lblKeyAdded"
        Me.lblKeyAdded.Size = New System.Drawing.Size(129, 13)
        Me.lblKeyAdded.TabIndex = 1
        Me.lblKeyAdded.Text = "Added but not Committed."
        '
        'lblKeyChanged
        '
        Me.lblKeyChanged.AutoSize = True
        Me.lblKeyChanged.ForeColor = System.Drawing.Color.Blue
        Me.lblKeyChanged.Location = New System.Drawing.Point(389, 0)
        Me.lblKeyChanged.Name = "lblKeyChanged"
        Me.lblKeyChanged.Size = New System.Drawing.Size(138, 13)
        Me.lblKeyChanged.TabIndex = 2
        Me.lblKeyChanged.Text = "Modified but not Committed."
        '
        'lblKeyUnapproved
        '
        Me.lblKeyUnapproved.AutoSize = True
        Me.lblKeyUnapproved.ForeColor = System.Drawing.Color.Red
        Me.lblKeyUnapproved.Location = New System.Drawing.Point(533, 0)
        Me.lblKeyUnapproved.Name = "lblKeyUnapproved"
        Me.lblKeyUnapproved.Size = New System.Drawing.Size(96, 13)
        Me.lblKeyUnapproved.TabIndex = 3
        Me.lblKeyUnapproved.Text = "Unapproved Term."
        '
        'ucCVMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tscControls)
        Me.Name = "ucCVMerge"
        Me.Size = New System.Drawing.Size(650, 500)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvWeb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLocal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tscControls.ContentPanel.ResumeLayout(False)
        Me.tscControls.ContentPanel.PerformLayout()
        Me.tscControls.TopToolStripPanel.ResumeLayout(False)
        Me.tscControls.TopToolStripPanel.PerformLayout()
        Me.tscControls.ResumeLayout(False)
        Me.tscControls.PerformLayout()
        Me.flpKey.ResumeLayout(False)
        Me.flpKey.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblWebCV As System.Windows.Forms.Label
    Friend WithEvents lblLocalCV As System.Windows.Forms.Label
    Friend WithEvents dgvWeb As System.Windows.Forms.DataGridView
    Friend WithEvents dgvLocal As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRefreshWeb As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRefreshLocal As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUpdateLocal As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFixRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnApply As System.Windows.Forms.ToolStripButton
    Friend WithEvents tscControls As System.Windows.Forms.ToolStripContainer
    Friend WithEvents cboCVType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnFinished As System.Windows.Forms.ToolStripButton
    Friend WithEvents flpKey As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblKeyText As System.Windows.Forms.Label
    Friend WithEvents lblKeyAdded As System.Windows.Forms.Label
    Friend WithEvents lblKeyChanged As System.Windows.Forms.Label
    Friend WithEvents lblKeyUnapproved As System.Windows.Forms.Label
    Friend WithEvents lblKeyCorrect As System.Windows.Forms.Label

End Class
