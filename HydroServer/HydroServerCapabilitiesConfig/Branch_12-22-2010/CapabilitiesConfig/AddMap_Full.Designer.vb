<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMap_Full
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddMap_Full))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvMeta = New System.Windows.Forms.DataGridView
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Content = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnRemoveMeta = New System.Windows.Forms.Button
        Me.btnEditMeta = New System.Windows.Forms.Button
        Me.btnAddMeta = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnAddMapServer = New System.Windows.Forms.Button
        Me.cboServer = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblSampleConnection = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboDatasetContact = New System.Windows.Forms.ComboBox
        Me.txtMapConnection = New System.Windows.Forms.TextBox
        Me.cboMetadataContact = New System.Windows.Forms.ComboBox
        Me.btnAddDatasetContact = New System.Windows.Forms.Button
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.btnAddMetadataContact = New System.Windows.Forms.Button
        Me.dtpReferenceDate = New System.Windows.Forms.DateTimePicker
        Me.txtEast = New System.Windows.Forms.TextBox
        Me.txtOnlineResource = New System.Windows.Forms.TextBox
        Me.txtNorth = New System.Windows.Forms.TextBox
        Me.txtLineageStatement = New System.Windows.Forms.TextBox
        Me.txtSouth = New System.Windows.Forms.TextBox
        Me.txtReferenceSystem = New System.Windows.Forms.TextBox
        Me.txtWest = New System.Windows.Forms.TextBox
        Me.txtSpatialRepresentationType = New System.Windows.Forms.TextBox
        Me.txtTopicCategory = New System.Windows.Forms.TextBox
        Me.txtDistributionFormat = New System.Windows.Forms.TextBox
        Me.txtAbstract = New System.Windows.Forms.TextBox
        Me.txtSpatialResolution = New System.Windows.Forms.TextBox
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.btnOK)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCancel)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 707)
        Me.FlowLayoutPanel1.MinimumSize = New System.Drawing.Size(250, 28)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(426, 29)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(348, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(267, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvMeta)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 610)
        Me.GroupBox1.MinimumSize = New System.Drawing.Size(250, 100)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 100)
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
        Me.dgvMeta.Size = New System.Drawing.Size(420, 51)
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
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 67)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(420, 30)
        Me.FlowLayoutPanel2.TabIndex = 2
        '
        'btnRemoveMeta
        '
        Me.btnRemoveMeta.Image = Global.HIS_Config.My.Resources.Resources.btnRemove
        Me.btnRemoveMeta.Location = New System.Drawing.Point(393, 3)
        Me.btnRemoveMeta.Name = "btnRemoveMeta"
        Me.btnRemoveMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnRemoveMeta.TabIndex = 2
        Me.btnRemoveMeta.UseVisualStyleBackColor = True
        '
        'btnEditMeta
        '
        Me.btnEditMeta.Image = Global.HIS_Config.My.Resources.Resources.btnEdit
        Me.btnEditMeta.Location = New System.Drawing.Point(363, 3)
        Me.btnEditMeta.Name = "btnEditMeta"
        Me.btnEditMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnEditMeta.TabIndex = 1
        Me.btnEditMeta.UseVisualStyleBackColor = True
        '
        'btnAddMeta
        '
        Me.btnAddMeta.Image = Global.HIS_Config.My.Resources.Resources.btnAdd
        Me.btnAddMeta.Location = New System.Drawing.Point(333, 3)
        Me.btnAddMeta.Name = "btnAddMeta"
        Me.btnAddMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnAddMeta.TabIndex = 0
        Me.btnAddMeta.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.btnAddMapServer)
        Me.Panel1.Controls.Add(Me.cboServer)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblSampleConnection)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.cboDatasetContact)
        Me.Panel1.Controls.Add(Me.txtMapConnection)
        Me.Panel1.Controls.Add(Me.cboMetadataContact)
        Me.Panel1.Controls.Add(Me.btnAddDatasetContact)
        Me.Panel1.Controls.Add(Me.txtTitle)
        Me.Panel1.Controls.Add(Me.btnAddMetadataContact)
        Me.Panel1.Controls.Add(Me.dtpReferenceDate)
        Me.Panel1.Controls.Add(Me.txtEast)
        Me.Panel1.Controls.Add(Me.txtOnlineResource)
        Me.Panel1.Controls.Add(Me.txtNorth)
        Me.Panel1.Controls.Add(Me.txtLineageStatement)
        Me.Panel1.Controls.Add(Me.txtSouth)
        Me.Panel1.Controls.Add(Me.txtReferenceSystem)
        Me.Panel1.Controls.Add(Me.txtWest)
        Me.Panel1.Controls.Add(Me.txtSpatialRepresentationType)
        Me.Panel1.Controls.Add(Me.txtTopicCategory)
        Me.Panel1.Controls.Add(Me.txtDistributionFormat)
        Me.Panel1.Controls.Add(Me.txtAbstract)
        Me.Panel1.Controls.Add(Me.txtSpatialResolution)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(426, 610)
        Me.Panel1.TabIndex = 3
        '
        'btnAddMapServer
        '
        Me.btnAddMapServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddMapServer.Location = New System.Drawing.Point(393, 32)
        Me.btnAddMapServer.Name = "btnAddMapServer"
        Me.btnAddMapServer.Size = New System.Drawing.Size(21, 21)
        Me.btnAddMapServer.TabIndex = 82
        Me.btnAddMapServer.Text = "+"
        Me.btnAddMapServer.UseVisualStyleBackColor = True
        '
        'cboServer
        '
        Me.cboServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServer.FormattingEnabled = True
        Me.cboServer.Location = New System.Drawing.Point(62, 32)
        Me.cboServer.Name = "cboServer"
        Me.cboServer.Size = New System.Drawing.Size(325, 21)
        Me.cboServer.TabIndex = 81
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Server"
        '
        'lblSampleConnection
        '
        Me.lblSampleConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSampleConnection.Location = New System.Drawing.Point(33, 82)
        Me.lblSampleConnection.Name = "lblSampleConnection"
        Me.lblSampleConnection.Size = New System.Drawing.Size(381, 54)
        Me.lblSampleConnection.TabIndex = 78
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Title"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Map Connection"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 223)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "East Extent"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Reference Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "North Extent"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 589)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 13)
        Me.Label18.TabIndex = 76
        Me.Label18.Text = "Online Resource"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "South Extent"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 524)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 13)
        Me.Label17.TabIndex = 74
        Me.Label17.Text = "Lineage Statement"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 249)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "West Extent"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 498)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Reference System"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 275)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 13)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "Topic Category"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 472)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 13)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Spatial Representation Type"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 301)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "Abstract"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 446)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 13)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Distribution Format"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 368)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 13)
        Me.Label14.TabIndex = 60
        Me.Label14.Text = "Metadata Contact"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 420)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 13)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Spatial Resolution"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 394)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Dataset Contact"
        '
        'cboDatasetContact
        '
        Me.cboDatasetContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDatasetContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDatasetContact.FormattingEnabled = True
        Me.cboDatasetContact.Location = New System.Drawing.Point(102, 390)
        Me.cboDatasetContact.Name = "cboDatasetContact"
        Me.cboDatasetContact.Size = New System.Drawing.Size(285, 21)
        Me.cboDatasetContact.TabIndex = 64
        '
        'txtMapConnection
        '
        Me.txtMapConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMapConnection.Location = New System.Drawing.Point(117, 59)
        Me.txtMapConnection.MaxLength = 500
        Me.txtMapConnection.Name = "txtMapConnection"
        Me.txtMapConnection.Size = New System.Drawing.Size(297, 20)
        Me.txtMapConnection.TabIndex = 43
        '
        'cboMetadataContact
        '
        Me.cboMetadataContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMetadataContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMetadataContact.FormattingEnabled = True
        Me.cboMetadataContact.Location = New System.Drawing.Point(126, 364)
        Me.cboMetadataContact.Name = "cboMetadataContact"
        Me.cboMetadataContact.Size = New System.Drawing.Size(261, 21)
        Me.cboMetadataContact.TabIndex = 61
        '
        'btnAddDatasetContact
        '
        Me.btnAddDatasetContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddDatasetContact.Location = New System.Drawing.Point(393, 390)
        Me.btnAddDatasetContact.Name = "btnAddDatasetContact"
        Me.btnAddDatasetContact.Size = New System.Drawing.Size(21, 21)
        Me.btnAddDatasetContact.TabIndex = 65
        Me.btnAddDatasetContact.Text = "+"
        Me.btnAddDatasetContact.UseVisualStyleBackColor = True
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Location = New System.Drawing.Point(50, 6)
        Me.txtTitle.MaxLength = 255
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(364, 20)
        Me.txtTitle.TabIndex = 41
        '
        'btnAddMetadataContact
        '
        Me.btnAddMetadataContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddMetadataContact.Location = New System.Drawing.Point(393, 364)
        Me.btnAddMetadataContact.Name = "btnAddMetadataContact"
        Me.btnAddMetadataContact.Size = New System.Drawing.Size(21, 21)
        Me.btnAddMetadataContact.TabIndex = 62
        Me.btnAddMetadataContact.Text = "+"
        Me.btnAddMetadataContact.UseVisualStyleBackColor = True
        '
        'dtpReferenceDate
        '
        Me.dtpReferenceDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpReferenceDate.Location = New System.Drawing.Point(115, 142)
        Me.dtpReferenceDate.Name = "dtpReferenceDate"
        Me.dtpReferenceDate.Size = New System.Drawing.Size(299, 20)
        Me.dtpReferenceDate.TabIndex = 47
        '
        'txtEast
        '
        Me.txtEast.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEast.Location = New System.Drawing.Point(90, 220)
        Me.txtEast.Name = "txtEast"
        Me.txtEast.Size = New System.Drawing.Size(324, 20)
        Me.txtEast.TabIndex = 53
        '
        'txtOnlineResource
        '
        Me.txtOnlineResource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOnlineResource.Location = New System.Drawing.Point(104, 587)
        Me.txtOnlineResource.MaxLength = 500
        Me.txtOnlineResource.Name = "txtOnlineResource"
        Me.txtOnlineResource.Size = New System.Drawing.Size(310, 20)
        Me.txtOnlineResource.TabIndex = 77
        '
        'txtNorth
        '
        Me.txtNorth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNorth.Location = New System.Drawing.Point(96, 168)
        Me.txtNorth.Name = "txtNorth"
        Me.txtNorth.Size = New System.Drawing.Size(318, 20)
        Me.txtNorth.TabIndex = 49
        '
        'txtLineageStatement
        '
        Me.txtLineageStatement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLineageStatement.Location = New System.Drawing.Point(114, 521)
        Me.txtLineageStatement.Multiline = True
        Me.txtLineageStatement.Name = "txtLineageStatement"
        Me.txtLineageStatement.Size = New System.Drawing.Size(300, 60)
        Me.txtLineageStatement.TabIndex = 75
        '
        'txtSouth
        '
        Me.txtSouth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSouth.Location = New System.Drawing.Point(98, 194)
        Me.txtSouth.Name = "txtSouth"
        Me.txtSouth.Size = New System.Drawing.Size(316, 20)
        Me.txtSouth.TabIndex = 51
        '
        'txtReferenceSystem
        '
        Me.txtReferenceSystem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReferenceSystem.Location = New System.Drawing.Point(112, 495)
        Me.txtReferenceSystem.MaxLength = 255
        Me.txtReferenceSystem.Name = "txtReferenceSystem"
        Me.txtReferenceSystem.Size = New System.Drawing.Size(302, 20)
        Me.txtReferenceSystem.TabIndex = 73
        '
        'txtWest
        '
        Me.txtWest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWest.Location = New System.Drawing.Point(94, 246)
        Me.txtWest.Name = "txtWest"
        Me.txtWest.Size = New System.Drawing.Size(320, 20)
        Me.txtWest.TabIndex = 55
        '
        'txtSpatialRepresentationType
        '
        Me.txtSpatialRepresentationType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpatialRepresentationType.Location = New System.Drawing.Point(159, 469)
        Me.txtSpatialRepresentationType.MaxLength = 255
        Me.txtSpatialRepresentationType.Name = "txtSpatialRepresentationType"
        Me.txtSpatialRepresentationType.Size = New System.Drawing.Size(255, 20)
        Me.txtSpatialRepresentationType.TabIndex = 71
        '
        'txtTopicCategory
        '
        Me.txtTopicCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTopicCategory.Location = New System.Drawing.Point(111, 272)
        Me.txtTopicCategory.MaxLength = 255
        Me.txtTopicCategory.Name = "txtTopicCategory"
        Me.txtTopicCategory.Size = New System.Drawing.Size(303, 20)
        Me.txtTopicCategory.TabIndex = 57
        '
        'txtDistributionFormat
        '
        Me.txtDistributionFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDistributionFormat.Location = New System.Drawing.Point(112, 443)
        Me.txtDistributionFormat.MaxLength = 255
        Me.txtDistributionFormat.Name = "txtDistributionFormat"
        Me.txtDistributionFormat.Size = New System.Drawing.Size(302, 20)
        Me.txtDistributionFormat.TabIndex = 69
        '
        'txtAbstract
        '
        Me.txtAbstract.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAbstract.Location = New System.Drawing.Point(72, 298)
        Me.txtAbstract.Multiline = True
        Me.txtAbstract.Name = "txtAbstract"
        Me.txtAbstract.Size = New System.Drawing.Size(342, 60)
        Me.txtAbstract.TabIndex = 59
        '
        'txtSpatialResolution
        '
        Me.txtSpatialResolution.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpatialResolution.Location = New System.Drawing.Point(110, 417)
        Me.txtSpatialResolution.MaxLength = 255
        Me.txtSpatialResolution.Name = "txtSpatialResolution"
        Me.txtSpatialResolution.Size = New System.Drawing.Size(304, 20)
        Me.txtSpatialResolution.TabIndex = 67
        '
        'AddMap_Full
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(426, 736)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddMap_Full"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Map Service"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMeta As System.Windows.Forms.DataGridView
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnRemoveMeta As System.Windows.Forms.Button
    Friend WithEvents btnEditMeta As System.Windows.Forms.Button
    Friend WithEvents btnAddMeta As System.Windows.Forms.Button
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Content As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSampleConnection As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboDatasetContact As System.Windows.Forms.ComboBox
    Friend WithEvents txtMapConnection As System.Windows.Forms.TextBox
    Friend WithEvents cboMetadataContact As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddDatasetContact As System.Windows.Forms.Button
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnAddMetadataContact As System.Windows.Forms.Button
    Friend WithEvents dtpReferenceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEast As System.Windows.Forms.TextBox
    Friend WithEvents txtOnlineResource As System.Windows.Forms.TextBox
    Friend WithEvents txtNorth As System.Windows.Forms.TextBox
    Friend WithEvents txtLineageStatement As System.Windows.Forms.TextBox
    Friend WithEvents txtSouth As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenceSystem As System.Windows.Forms.TextBox
    Friend WithEvents txtWest As System.Windows.Forms.TextBox
    Friend WithEvents txtSpatialRepresentationType As System.Windows.Forms.TextBox
    Friend WithEvents txtTopicCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtDistributionFormat As System.Windows.Forms.TextBox
    Friend WithEvents txtAbstract As System.Windows.Forms.TextBox
    Friend WithEvents txtSpatialResolution As System.Windows.Forms.TextBox
    Friend WithEvents btnAddMapServer As System.Windows.Forms.Button
    Friend WithEvents cboServer As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
