<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMapServer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddMapServer))
        Me.txtServerName = New System.Windows.Forms.TextBox
        Me.txtConnectionURL = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.txtPWD = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboConnectionType = New System.Windows.Forms.ComboBox
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblSampleConnection = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDomain = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvMeta = New System.Windows.Forms.DataGridView
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Content = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnRemoveMeta = New System.Windows.Forms.Button
        Me.btnEditMeta = New System.Windows.Forms.Button
        Me.btnAddMeta = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtServerName
        '
        Me.txtServerName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServerName.Location = New System.Drawing.Point(89, 3)
        Me.txtServerName.MaxLength = 255
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(236, 20)
        Me.txtServerName.TabIndex = 1
        '
        'txtConnectionURL
        '
        Me.txtConnectionURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectionURL.Location = New System.Drawing.Point(109, 56)
        Me.txtConnectionURL.MaxLength = 500
        Me.txtConnectionURL.Name = "txtConnectionURL"
        Me.txtConnectionURL.Size = New System.Drawing.Size(216, 20)
        Me.txtConnectionURL.TabIndex = 5
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsername.Enabled = False
        Me.txtUsername.Location = New System.Drawing.Point(130, 141)
        Me.txtUsername.MaxLength = 255
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(195, 20)
        Me.txtUsername.TabIndex = 10
        '
        'txtPWD
        '
        Me.txtPWD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPWD.Enabled = False
        Me.txtPWD.Location = New System.Drawing.Point(130, 167)
        Me.txtPWD.MaxLength = 255
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Size = New System.Drawing.Size(195, 20)
        Me.txtPWD.TabIndex = 12
        Me.txtPWD.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Connection URL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Username"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Connection Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Password"
        '
        'cboConnectionType
        '
        Me.cboConnectionType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConnectionType.FormattingEnabled = True
        Me.cboConnectionType.Location = New System.Drawing.Point(112, 29)
        Me.cboConnectionType.MaxLength = 255
        Me.cboConnectionType.Name = "cboConnectionType"
        Me.cboConnectionType.Size = New System.Drawing.Size(213, 21)
        Me.cboConnectionType.TabIndex = 3
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.btnOK)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCancel)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 298)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(328, 29)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(250, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(169, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblSampleConnection
        '
        Me.lblSampleConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSampleConnection.Location = New System.Drawing.Point(109, 79)
        Me.lblSampleConnection.Name = "lblSampleConnection"
        Me.lblSampleConnection.Size = New System.Drawing.Size(216, 33)
        Me.lblSampleConnection.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Domain"
        '
        'txtDomain
        '
        Me.txtDomain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDomain.Enabled = False
        Me.txtDomain.Location = New System.Drawing.Point(103, 115)
        Me.txtDomain.MaxLength = 255
        Me.txtDomain.Name = "txtDomain"
        Me.txtDomain.Size = New System.Drawing.Size(222, 20)
        Me.txtDomain.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtServerName)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtConnectionURL)
        Me.Panel1.Controls.Add(Me.txtDomain)
        Me.Panel1.Controls.Add(Me.txtUsername)
        Me.Panel1.Controls.Add(Me.lblSampleConnection)
        Me.Panel1.Controls.Add(Me.txtPWD)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboConnectionType)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 194)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvMeta)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 194)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 104)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Metadata"
        '
        'dgvMeta
        '
        Me.dgvMeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMeta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Title, Me.Content})
        Me.dgvMeta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMeta.Location = New System.Drawing.Point(3, 16)
        Me.dgvMeta.Name = "dgvMeta"
        Me.dgvMeta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMeta.Size = New System.Drawing.Size(322, 55)
        Me.dgvMeta.TabIndex = 0
        '
        'Title
        '
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        '
        'Content
        '
        Me.Content.HeaderText = "Content"
        Me.Content.Name = "Content"
        Me.Content.ReadOnly = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.btnRemoveMeta)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnEditMeta)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnAddMeta)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 71)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(322, 30)
        Me.FlowLayoutPanel2.TabIndex = 2
        '
        'btnRemoveMeta
        '
        Me.btnRemoveMeta.Image = Global.HIS_Config.My.Resources.Resources.btnRemove
        Me.btnRemoveMeta.Location = New System.Drawing.Point(295, 3)
        Me.btnRemoveMeta.Name = "btnRemoveMeta"
        Me.btnRemoveMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnRemoveMeta.TabIndex = 2
        Me.btnRemoveMeta.UseVisualStyleBackColor = True
        '
        'btnEditMeta
        '
        Me.btnEditMeta.Image = Global.HIS_Config.My.Resources.Resources.btnEdit
        Me.btnEditMeta.Location = New System.Drawing.Point(265, 3)
        Me.btnEditMeta.Name = "btnEditMeta"
        Me.btnEditMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnEditMeta.TabIndex = 1
        Me.btnEditMeta.UseVisualStyleBackColor = True
        '
        'btnAddMeta
        '
        Me.btnAddMeta.Image = Global.HIS_Config.My.Resources.Resources.btnAdd
        Me.btnAddMeta.Location = New System.Drawing.Point(235, 3)
        Me.btnAddMeta.Name = "btnAddMeta"
        Me.btnAddMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnAddMeta.TabIndex = 0
        Me.btnAddMeta.UseVisualStyleBackColor = True
        '
        'AddMapServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(328, 327)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddMapServer"
        Me.Text = "Add Map Server"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents txtConnectionURL As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPWD As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboConnectionType As System.Windows.Forms.ComboBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblSampleConnection As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDomain As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMeta As System.Windows.Forms.DataGridView
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnRemoveMeta As System.Windows.Forms.Button
    Friend WithEvents btnEditMeta As System.Windows.Forms.Button
    Friend WithEvents btnAddMeta As System.Windows.Forms.Button
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Content As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
