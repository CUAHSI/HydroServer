<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddDatabase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddDatabase))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblSRS = New System.Windows.Forms.Label
        Me.txtSRS = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCitation = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtWaterOneFlowWSDL = New System.Windows.Forms.TextBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblServerAddress = New System.Windows.Forms.Label
        Me.lblDatabaseName = New System.Windows.Forms.Label
        Me.lblUserName = New System.Windows.Forms.Label
        Me.lblPwd = New System.Windows.Forms.Label
        Me.lblMarkerUrl = New System.Windows.Forms.Label
        Me.lblReferenceDate = New System.Windows.Forms.Label
        Me.lblNorth = New System.Windows.Forms.Label
        Me.lblSouth = New System.Windows.Forms.Label
        Me.lblEast = New System.Windows.Forms.Label
        Me.lblWest = New System.Windows.Forms.Label
        Me.lblTopicCategory = New System.Windows.Forms.Label
        Me.lblAbstract = New System.Windows.Forms.Label
        Me.lblMetadataContact = New System.Windows.Forms.Label
        Me.lblDatasetContact = New System.Windows.Forms.Label
        Me.lblLineageStatement = New System.Windows.Forms.Label
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.txtServerAddress = New System.Windows.Forms.TextBox
        Me.txtDatabaseName = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtPwd = New System.Windows.Forms.TextBox
        Me.txtMarkerURL = New System.Windows.Forms.TextBox
        Me.dtpReferenceDate = New System.Windows.Forms.DateTimePicker
        Me.txtNorth = New System.Windows.Forms.TextBox
        Me.txtSouth = New System.Windows.Forms.TextBox
        Me.txtEast = New System.Windows.Forms.TextBox
        Me.txtWest = New System.Windows.Forms.TextBox
        Me.txtTopicCategory = New System.Windows.Forms.TextBox
        Me.txtAbstract = New System.Windows.Forms.TextBox
        Me.cboMetadataContact = New System.Windows.Forms.ComboBox
        Me.addMetadataContact = New System.Windows.Forms.Button
        Me.cboDatasetContact = New System.Windows.Forms.ComboBox
        Me.addDatasetContact = New System.Windows.Forms.Button
        Me.txtLineageStatement = New System.Windows.Forms.TextBox
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.zgSites = New ZedGraph.ZedGraphControl
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.lbSites = New System.Windows.Forms.ListBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.lbVariables = New System.Windows.Forms.ListBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvMeta = New System.Windows.Forms.DataGridView
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Content = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnRemoveMeta = New System.Windows.Forms.Button
        Me.btnEditMeta = New System.Windows.Forms.Button
        Me.btnAddMeta = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 785)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(607, 29)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(529, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(448, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSRS)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSRS)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCitation)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtWaterOneFlowWSDL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTitle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblServerAddress)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDatabaseName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblUserName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblPwd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMarkerUrl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblReferenceDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblNorth)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSouth)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblEast)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblWest)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTopicCategory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblAbstract)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMetadataContact)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDatasetContact)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblLineageStatement)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTitle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtServerAddress)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDatabaseName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtUserName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPwd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMarkerURL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpReferenceDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtNorth)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSouth)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtEast)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtWest)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTopicCategory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAbstract)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboMetadataContact)
        Me.SplitContainer1.Panel1.Controls.Add(Me.addMetadataContact)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboDatasetContact)
        Me.SplitContainer1.Panel1.Controls.Add(Me.addDatasetContact)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLineageStatement)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(607, 604)
        Me.SplitContainer1.SplitterDistance = 314
        Me.SplitContainer1.TabIndex = 0
        '
        'lblSRS
        '
        Me.lblSRS.AutoSize = True
        Me.lblSRS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSRS.Location = New System.Drawing.Point(12, 301)
        Me.lblSRS.Name = "lblSRS"
        Me.lblSRS.Size = New System.Drawing.Size(153, 13)
        Me.lblSRS.TabIndex = 51
        Me.lblSRS.Text = "Spatial Reference System"
        '
        'txtSRS
        '
        Me.txtSRS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSRS.Location = New System.Drawing.Point(171, 301)
        Me.txtSRS.Name = "txtSRS"
        Me.txtSRS.Size = New System.Drawing.Size(140, 20)
        Me.txtSRS.TabIndex = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 327)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Citation"
        '
        'txtCitation
        '
        Me.txtCitation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCitation.Location = New System.Drawing.Point(68, 327)
        Me.txtCitation.MaxLength = 255
        Me.txtCitation.Multiline = True
        Me.txtCitation.Name = "txtCitation"
        Me.txtCitation.Size = New System.Drawing.Size(243, 46)
        Me.txtCitation.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 579)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "WOF WSDL"
        '
        'txtWaterOneFlowWSDL
        '
        Me.txtWaterOneFlowWSDL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWaterOneFlowWSDL.Location = New System.Drawing.Point(93, 576)
        Me.txtWaterOneFlowWSDL.MaxLength = 500
        Me.txtWaterOneFlowWSDL.Name = "txtWaterOneFlowWSDL"
        Me.txtWaterOneFlowWSDL.Size = New System.Drawing.Size(218, 20)
        Me.txtWaterOneFlowWSDL.TabIndex = 47
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(32, 13)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title"
        '
        'lblServerAddress
        '
        Me.lblServerAddress.AutoSize = True
        Me.lblServerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerAddress.Location = New System.Drawing.Point(12, 41)
        Me.lblServerAddress.Name = "lblServerAddress"
        Me.lblServerAddress.Size = New System.Drawing.Size(93, 13)
        Me.lblServerAddress.TabIndex = 2
        Me.lblServerAddress.Text = "Server Address"
        '
        'lblDatabaseName
        '
        Me.lblDatabaseName.AutoSize = True
        Me.lblDatabaseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabaseName.Location = New System.Drawing.Point(12, 67)
        Me.lblDatabaseName.Name = "lblDatabaseName"
        Me.lblDatabaseName.Size = New System.Drawing.Size(97, 13)
        Me.lblDatabaseName.TabIndex = 4
        Me.lblDatabaseName.Text = "Database Name"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(12, 93)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(63, 13)
        Me.lblUserName.TabIndex = 6
        Me.lblUserName.Text = "Username"
        '
        'lblPwd
        '
        Me.lblPwd.AutoSize = True
        Me.lblPwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPwd.Location = New System.Drawing.Point(12, 119)
        Me.lblPwd.Name = "lblPwd"
        Me.lblPwd.Size = New System.Drawing.Size(61, 13)
        Me.lblPwd.TabIndex = 8
        Me.lblPwd.Text = "Password"
        '
        'lblMarkerUrl
        '
        Me.lblMarkerUrl.AutoSize = True
        Me.lblMarkerUrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarkerUrl.Location = New System.Drawing.Point(12, 145)
        Me.lblMarkerUrl.Name = "lblMarkerUrl"
        Me.lblMarkerUrl.Size = New System.Drawing.Size(103, 13)
        Me.lblMarkerUrl.TabIndex = 12
        Me.lblMarkerUrl.Text = "Map Marker URL"
        '
        'lblReferenceDate
        '
        Me.lblReferenceDate.AutoSize = True
        Me.lblReferenceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReferenceDate.Location = New System.Drawing.Point(12, 172)
        Me.lblReferenceDate.Name = "lblReferenceDate"
        Me.lblReferenceDate.Size = New System.Drawing.Size(97, 13)
        Me.lblReferenceDate.TabIndex = 14
        Me.lblReferenceDate.Text = "Reference Date"
        '
        'lblNorth
        '
        Me.lblNorth.AutoSize = True
        Me.lblNorth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNorth.Location = New System.Drawing.Point(12, 197)
        Me.lblNorth.Name = "lblNorth"
        Me.lblNorth.Size = New System.Drawing.Size(78, 13)
        Me.lblNorth.TabIndex = 16
        Me.lblNorth.Text = "North Extent"
        '
        'lblSouth
        '
        Me.lblSouth.AutoSize = True
        Me.lblSouth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSouth.Location = New System.Drawing.Point(12, 223)
        Me.lblSouth.Name = "lblSouth"
        Me.lblSouth.Size = New System.Drawing.Size(80, 13)
        Me.lblSouth.TabIndex = 18
        Me.lblSouth.Text = "South Extent"
        '
        'lblEast
        '
        Me.lblEast.AutoSize = True
        Me.lblEast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEast.Location = New System.Drawing.Point(12, 249)
        Me.lblEast.Name = "lblEast"
        Me.lblEast.Size = New System.Drawing.Size(72, 13)
        Me.lblEast.TabIndex = 20
        Me.lblEast.Text = "East Extent"
        '
        'lblWest
        '
        Me.lblWest.AutoSize = True
        Me.lblWest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWest.Location = New System.Drawing.Point(12, 275)
        Me.lblWest.Name = "lblWest"
        Me.lblWest.Size = New System.Drawing.Size(76, 13)
        Me.lblWest.TabIndex = 22
        Me.lblWest.Text = "West Extent"
        '
        'lblTopicCategory
        '
        Me.lblTopicCategory.AutoSize = True
        Me.lblTopicCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTopicCategory.Location = New System.Drawing.Point(12, 379)
        Me.lblTopicCategory.Name = "lblTopicCategory"
        Me.lblTopicCategory.Size = New System.Drawing.Size(93, 13)
        Me.lblTopicCategory.TabIndex = 24
        Me.lblTopicCategory.Text = "Topic Category"
        '
        'lblAbstract
        '
        Me.lblAbstract.AutoSize = True
        Me.lblAbstract.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbstract.Location = New System.Drawing.Point(12, 405)
        Me.lblAbstract.Name = "lblAbstract"
        Me.lblAbstract.Size = New System.Drawing.Size(54, 13)
        Me.lblAbstract.TabIndex = 26
        Me.lblAbstract.Text = "Abstract"
        '
        'lblMetadataContact
        '
        Me.lblMetadataContact.AutoSize = True
        Me.lblMetadataContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMetadataContact.Location = New System.Drawing.Point(12, 459)
        Me.lblMetadataContact.Name = "lblMetadataContact"
        Me.lblMetadataContact.Size = New System.Drawing.Size(108, 13)
        Me.lblMetadataContact.TabIndex = 28
        Me.lblMetadataContact.Text = "Metadata Contact"
        '
        'lblDatasetContact
        '
        Me.lblDatasetContact.AutoSize = True
        Me.lblDatasetContact.Location = New System.Drawing.Point(12, 486)
        Me.lblDatasetContact.Name = "lblDatasetContact"
        Me.lblDatasetContact.Size = New System.Drawing.Size(84, 13)
        Me.lblDatasetContact.TabIndex = 31
        Me.lblDatasetContact.Text = "Dataset Contact"
        '
        'lblLineageStatement
        '
        Me.lblLineageStatement.AutoSize = True
        Me.lblLineageStatement.Location = New System.Drawing.Point(12, 513)
        Me.lblLineageStatement.Name = "lblLineageStatement"
        Me.lblLineageStatement.Size = New System.Drawing.Size(96, 13)
        Me.lblLineageStatement.TabIndex = 42
        Me.lblLineageStatement.Text = "Lineage Statement"
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Location = New System.Drawing.Point(50, 12)
        Me.txtTitle.MaxLength = 255
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(261, 20)
        Me.txtTitle.TabIndex = 1
        '
        'txtServerAddress
        '
        Me.txtServerAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServerAddress.Enabled = False
        Me.txtServerAddress.Location = New System.Drawing.Point(111, 38)
        Me.txtServerAddress.MaxLength = 500
        Me.txtServerAddress.Name = "txtServerAddress"
        Me.txtServerAddress.Size = New System.Drawing.Size(200, 20)
        Me.txtServerAddress.TabIndex = 3
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatabaseName.Enabled = False
        Me.txtDatabaseName.Location = New System.Drawing.Point(115, 64)
        Me.txtDatabaseName.MaxLength = 255
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(196, 20)
        Me.txtDatabaseName.TabIndex = 5
        '
        'txtUserName
        '
        Me.txtUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserName.Enabled = False
        Me.txtUserName.Location = New System.Drawing.Point(81, 90)
        Me.txtUserName.MaxLength = 255
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(230, 20)
        Me.txtUserName.TabIndex = 7
        '
        'txtPwd
        '
        Me.txtPwd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPwd.Enabled = False
        Me.txtPwd.Location = New System.Drawing.Point(79, 116)
        Me.txtPwd.MaxLength = 255
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Size = New System.Drawing.Size(232, 20)
        Me.txtPwd.TabIndex = 9
        Me.txtPwd.UseSystemPasswordChar = True
        '
        'txtMarkerURL
        '
        Me.txtMarkerURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMarkerURL.Location = New System.Drawing.Point(121, 142)
        Me.txtMarkerURL.MaxLength = 500
        Me.txtMarkerURL.Name = "txtMarkerURL"
        Me.txtMarkerURL.Size = New System.Drawing.Size(190, 20)
        Me.txtMarkerURL.TabIndex = 13
        '
        'dtpReferenceDate
        '
        Me.dtpReferenceDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpReferenceDate.Location = New System.Drawing.Point(115, 168)
        Me.dtpReferenceDate.Name = "dtpReferenceDate"
        Me.dtpReferenceDate.Size = New System.Drawing.Size(196, 20)
        Me.dtpReferenceDate.TabIndex = 15
        '
        'txtNorth
        '
        Me.txtNorth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNorth.Enabled = False
        Me.txtNorth.Location = New System.Drawing.Point(96, 194)
        Me.txtNorth.Name = "txtNorth"
        Me.txtNorth.Size = New System.Drawing.Size(215, 20)
        Me.txtNorth.TabIndex = 17
        '
        'txtSouth
        '
        Me.txtSouth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSouth.Enabled = False
        Me.txtSouth.Location = New System.Drawing.Point(98, 220)
        Me.txtSouth.Name = "txtSouth"
        Me.txtSouth.Size = New System.Drawing.Size(213, 20)
        Me.txtSouth.TabIndex = 19
        '
        'txtEast
        '
        Me.txtEast.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEast.Enabled = False
        Me.txtEast.Location = New System.Drawing.Point(90, 246)
        Me.txtEast.Name = "txtEast"
        Me.txtEast.Size = New System.Drawing.Size(221, 20)
        Me.txtEast.TabIndex = 21
        '
        'txtWest
        '
        Me.txtWest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWest.Enabled = False
        Me.txtWest.Location = New System.Drawing.Point(94, 272)
        Me.txtWest.Name = "txtWest"
        Me.txtWest.Size = New System.Drawing.Size(217, 20)
        Me.txtWest.TabIndex = 23
        '
        'txtTopicCategory
        '
        Me.txtTopicCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTopicCategory.Location = New System.Drawing.Point(112, 379)
        Me.txtTopicCategory.MaxLength = 255
        Me.txtTopicCategory.Name = "txtTopicCategory"
        Me.txtTopicCategory.Size = New System.Drawing.Size(200, 20)
        Me.txtTopicCategory.TabIndex = 25
        '
        'txtAbstract
        '
        Me.txtAbstract.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAbstract.Location = New System.Drawing.Point(72, 405)
        Me.txtAbstract.Multiline = True
        Me.txtAbstract.Name = "txtAbstract"
        Me.txtAbstract.Size = New System.Drawing.Size(239, 45)
        Me.txtAbstract.TabIndex = 27
        '
        'cboMetadataContact
        '
        Me.cboMetadataContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMetadataContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMetadataContact.FormattingEnabled = True
        Me.cboMetadataContact.Location = New System.Drawing.Point(126, 456)
        Me.cboMetadataContact.Name = "cboMetadataContact"
        Me.cboMetadataContact.Size = New System.Drawing.Size(158, 21)
        Me.cboMetadataContact.TabIndex = 29
        '
        'addMetadataContact
        '
        Me.addMetadataContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addMetadataContact.Location = New System.Drawing.Point(290, 456)
        Me.addMetadataContact.Name = "addMetadataContact"
        Me.addMetadataContact.Size = New System.Drawing.Size(21, 21)
        Me.addMetadataContact.TabIndex = 30
        Me.addMetadataContact.Text = "+"
        Me.addMetadataContact.UseVisualStyleBackColor = True
        '
        'cboDatasetContact
        '
        Me.cboDatasetContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDatasetContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDatasetContact.FormattingEnabled = True
        Me.cboDatasetContact.Location = New System.Drawing.Point(102, 483)
        Me.cboDatasetContact.Name = "cboDatasetContact"
        Me.cboDatasetContact.Size = New System.Drawing.Size(182, 21)
        Me.cboDatasetContact.TabIndex = 32
        '
        'addDatasetContact
        '
        Me.addDatasetContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addDatasetContact.Location = New System.Drawing.Point(290, 483)
        Me.addDatasetContact.Name = "addDatasetContact"
        Me.addDatasetContact.Size = New System.Drawing.Size(21, 21)
        Me.addDatasetContact.TabIndex = 33
        Me.addDatasetContact.Text = "+"
        Me.addDatasetContact.UseVisualStyleBackColor = True
        '
        'txtLineageStatement
        '
        Me.txtLineageStatement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLineageStatement.Location = New System.Drawing.Point(114, 510)
        Me.txtLineageStatement.Multiline = True
        Me.txtLineageStatement.Name = "txtLineageStatement"
        Me.txtLineageStatement.Size = New System.Drawing.Size(197, 60)
        Me.txtLineageStatement.TabIndex = 43
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.zgSites)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(289, 604)
        Me.SplitContainer2.SplitterDistance = 287
        Me.SplitContainer2.TabIndex = 0
        '
        'zgSites
        '
        Me.zgSites.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zgSites.IsEnableHPan = False
        Me.zgSites.IsEnableHZoom = False
        Me.zgSites.IsEnableVPan = False
        Me.zgSites.IsEnableVZoom = False
        Me.zgSites.IsShowContextMenu = False
        Me.zgSites.IsShowCopyMessage = False
        Me.zgSites.LinkButtons = System.Windows.Forms.MouseButtons.None
        Me.zgSites.LinkModifierKeys = System.Windows.Forms.Keys.None
        Me.zgSites.Location = New System.Drawing.Point(0, 0)
        Me.zgSites.Name = "zgSites"
        Me.zgSites.PanButtons = System.Windows.Forms.MouseButtons.None
        Me.zgSites.PanButtons2 = System.Windows.Forms.MouseButtons.None
        Me.zgSites.PanModifierKeys = System.Windows.Forms.Keys.None
        Me.zgSites.ScrollMaxX = 0
        Me.zgSites.ScrollMaxY = 0
        Me.zgSites.ScrollMaxY2 = 0
        Me.zgSites.ScrollMinX = 0
        Me.zgSites.ScrollMinY = 0
        Me.zgSites.ScrollMinY2 = 0
        Me.zgSites.Size = New System.Drawing.Size(289, 287)
        Me.zgSites.TabIndex = 0
        Me.zgSites.ZoomButtons = System.Windows.Forms.MouseButtons.None
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.lbSites)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label22)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.lbVariables)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label23)
        Me.SplitContainer3.Size = New System.Drawing.Size(289, 313)
        Me.SplitContainer3.SplitterDistance = 139
        Me.SplitContainer3.TabIndex = 0
        '
        'lbSites
        '
        Me.lbSites.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbSites.FormattingEnabled = True
        Me.lbSites.Location = New System.Drawing.Point(0, 13)
        Me.lbSites.Name = "lbSites"
        Me.lbSites.Size = New System.Drawing.Size(139, 290)
        Me.lbSites.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label22.Location = New System.Drawing.Point(0, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 13)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Sites"
        '
        'lbVariables
        '
        Me.lbVariables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbVariables.FormattingEnabled = True
        Me.lbVariables.Location = New System.Drawing.Point(0, 13)
        Me.lbVariables.Name = "lbVariables"
        Me.lbVariables.Size = New System.Drawing.Size(146, 290)
        Me.lbVariables.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label23.Location = New System.Drawing.Point(0, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 13)
        Me.Label23.TabIndex = 1
        Me.Label23.Text = "Variables"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvMeta)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 604)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 181)
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
        Me.dgvMeta.RowHeadersVisible = False
        Me.dgvMeta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMeta.ShowCellErrors = False
        Me.dgvMeta.ShowCellToolTips = False
        Me.dgvMeta.ShowRowErrors = False
        Me.dgvMeta.Size = New System.Drawing.Size(601, 132)
        Me.dgvMeta.TabIndex = 0
        '
        'Title
        '
        Me.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Title.Frozen = True
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        Me.Title.Width = 52
        '
        'Content
        '
        Me.Content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Content.HeaderText = "Content"
        Me.Content.Name = "Content"
        Me.Content.Width = 69
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
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 148)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(601, 30)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'btnRemoveMeta
        '
        Me.btnRemoveMeta.Image = Global.HIS_Config.My.Resources.Resources.btnRemove
        Me.btnRemoveMeta.Location = New System.Drawing.Point(574, 3)
        Me.btnRemoveMeta.Name = "btnRemoveMeta"
        Me.btnRemoveMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnRemoveMeta.TabIndex = 2
        Me.btnRemoveMeta.UseVisualStyleBackColor = True
        '
        'btnEditMeta
        '
        Me.btnEditMeta.Image = Global.HIS_Config.My.Resources.Resources.btnEdit
        Me.btnEditMeta.Location = New System.Drawing.Point(544, 3)
        Me.btnEditMeta.Name = "btnEditMeta"
        Me.btnEditMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnEditMeta.TabIndex = 1
        Me.btnEditMeta.UseVisualStyleBackColor = True
        '
        'btnAddMeta
        '
        Me.btnAddMeta.Image = Global.HIS_Config.My.Resources.Resources.btnAdd
        Me.btnAddMeta.Location = New System.Drawing.Point(514, 3)
        Me.btnAddMeta.Name = "btnAddMeta"
        Me.btnAddMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnAddMeta.TabIndex = 0
        Me.btnAddMeta.UseVisualStyleBackColor = True
        '
        'AddDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(607, 814)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddDatabase"
        Me.Text = "Edit ODM Database Attributes"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblServerAddress As System.Windows.Forms.Label
    Friend WithEvents lblDatabaseName As System.Windows.Forms.Label
    Friend WithEvents lblEast As System.Windows.Forms.Label
    Friend WithEvents lblReferenceDate As System.Windows.Forms.Label
    Friend WithEvents lblNorth As System.Windows.Forms.Label
    Friend WithEvents lblSouth As System.Windows.Forms.Label
    Friend WithEvents lblLineageStatement As System.Windows.Forms.Label
    Friend WithEvents lblWest As System.Windows.Forms.Label
    Friend WithEvents lblTopicCategory As System.Windows.Forms.Label
    Friend WithEvents lblAbstract As System.Windows.Forms.Label
    Friend WithEvents lblMetadataContact As System.Windows.Forms.Label
    Friend WithEvents lblDatasetContact As System.Windows.Forms.Label
    Friend WithEvents addMetadataContact As System.Windows.Forms.Button
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblPwd As System.Windows.Forms.Label
    Friend WithEvents lblMarkerUrl As System.Windows.Forms.Label
    Private WithEvents addDatasetContact As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents zgSites As ZedGraph.ZedGraphControl
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents lbSites As System.Windows.Forms.ListBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lbVariables As System.Windows.Forms.ListBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnEditMeta As System.Windows.Forms.Button
    Friend WithEvents btnRemoveMeta As System.Windows.Forms.Button
    Friend WithEvents btnAddMeta As System.Windows.Forms.Button
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Content As System.Windows.Forms.DataGridViewTextBoxColumn
    Protected Friend WithEvents cboDatasetContact As System.Windows.Forms.ComboBox
    Protected Friend WithEvents txtServerAddress As System.Windows.Forms.TextBox
    Protected Friend WithEvents cboMetadataContact As System.Windows.Forms.ComboBox
    Protected Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Protected Friend WithEvents dtpReferenceDate As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents txtEast As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtNorth As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtLineageStatement As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtSouth As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtWest As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtTopicCategory As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtAbstract As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtMarkerURL As System.Windows.Forms.TextBox
    Protected Friend WithEvents dgvMeta As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Protected Friend WithEvents txtWaterOneFlowWSDL As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtCitation As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSRS As System.Windows.Forms.Label
    Protected Friend WithEvents txtSRS As System.Windows.Forms.TextBox
End Class
