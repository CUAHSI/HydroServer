<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.IcewaterConnection = New System.Data.SqlClient.SqlConnection
        Me.pnlMaps = New System.Windows.Forms.Panel
        Me.dgvMaps = New System.Windows.Forms.DataGridView
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.pnlDatabases = New System.Windows.Forms.Panel
        Me.dgvDatabases = New System.Windows.Forms.DataGridView
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.pnlRegions = New System.Windows.Forms.Panel
        Me.dgvRegions = New System.Windows.Forms.DataGridView
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnFinished = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.pnlMapServers = New System.Windows.Forms.Panel
        Me.dgvMapServers = New System.Windows.Forms.DataGridView
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label13 = New System.Windows.Forms.Label
        Me.pnlContacts = New System.Windows.Forms.Panel
        Me.dgvContacts = New System.Windows.Forms.DataGridView
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.pnlChoices = New System.Windows.Forms.Panel
        Me.btnContacts = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnMapServers = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnMapServices = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnODMDatabases = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnRegions = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlIcewater = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblServer = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblCurrUser = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblDBName = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditDbConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeletContact = New System.Windows.Forms.Button
        Me.EditContact = New System.Windows.Forms.Button
        Me.AddContact = New System.Windows.Forms.Button
        Me.DeleteMapServer = New System.Windows.Forms.Button
        Me.EditMapServer = New System.Windows.Forms.Button
        Me.AddMapServer = New System.Windows.Forms.Button
        Me.btnRemoveMap = New System.Windows.Forms.Button
        Me.btnEditMap = New System.Windows.Forms.Button
        Me.btnAddMap = New System.Windows.Forms.Button
        Me.btnRemoveDatabase = New System.Windows.Forms.Button
        Me.btnEditDatabase = New System.Windows.Forms.Button
        Me.btnAddDatabase = New System.Windows.Forms.Button
        Me.btnRemoveRegion = New System.Windows.Forms.Button
        Me.btnEditRegion = New System.Windows.Forms.Button
        Me.btnAddRegion = New System.Windows.Forms.Button
        Me.pnlMaps.SuspendLayout()
        CType(Me.dgvMaps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlDatabases.SuspendLayout()
        CType(Me.dgvDatabases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlRegions.SuspendLayout()
        CType(Me.dgvRegions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlMapServers.SuspendLayout()
        CType(Me.dgvMapServers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlContacts.SuspendLayout()
        CType(Me.dgvContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.pnlChoices.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlIcewater.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IcewaterConnection
        '
        Me.IcewaterConnection.ConnectionString = "Data Source=JUSTINB\SQLEXPRESS;Initial Catalog=ICEWATER;Persist Security Info=Tru" & _
            "e;User ID=justin;Password=UWRL"
        Me.IcewaterConnection.FireInfoMessageEventOnUserErrors = False
        '
        'pnlMaps
        '
        Me.pnlMaps.Controls.Add(Me.dgvMaps)
        Me.pnlMaps.Controls.Add(Me.FlowLayoutPanel2)
        Me.pnlMaps.Controls.Add(Me.Panel5)
        Me.pnlMaps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMaps.Location = New System.Drawing.Point(0, 0)
        Me.pnlMaps.Name = "pnlMaps"
        Me.pnlMaps.Size = New System.Drawing.Size(526, 284)
        Me.pnlMaps.TabIndex = 12
        Me.pnlMaps.Visible = False
        '
        'dgvMaps
        '
        Me.dgvMaps.AllowUserToAddRows = False
        Me.dgvMaps.AllowUserToDeleteRows = False
        Me.dgvMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaps.Location = New System.Drawing.Point(0, 18)
        Me.dgvMaps.MultiSelect = False
        Me.dgvMaps.Name = "dgvMaps"
        Me.dgvMaps.ReadOnly = True
        Me.dgvMaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaps.Size = New System.Drawing.Size(526, 237)
        Me.dgvMaps.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.btnRemoveMap)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnEditMap)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnAddMap)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 255)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(526, 29)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.AutoSize = True
        Me.Panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(526, 18)
        Me.Panel5.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(1)
        Me.Label4.Size = New System.Drawing.Size(35, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Maps"
        '
        'pnlDatabases
        '
        Me.pnlDatabases.Controls.Add(Me.dgvDatabases)
        Me.pnlDatabases.Controls.Add(Me.FlowLayoutPanel3)
        Me.pnlDatabases.Controls.Add(Me.Panel6)
        Me.pnlDatabases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatabases.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatabases.Name = "pnlDatabases"
        Me.pnlDatabases.Size = New System.Drawing.Size(526, 284)
        Me.pnlDatabases.TabIndex = 13
        Me.pnlDatabases.Visible = False
        '
        'dgvDatabases
        '
        Me.dgvDatabases.AllowUserToAddRows = False
        Me.dgvDatabases.AllowUserToDeleteRows = False
        Me.dgvDatabases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatabases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDatabases.Location = New System.Drawing.Point(0, 18)
        Me.dgvDatabases.MultiSelect = False
        Me.dgvDatabases.Name = "dgvDatabases"
        Me.dgvDatabases.ReadOnly = True
        Me.dgvDatabases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatabases.Size = New System.Drawing.Size(526, 237)
        Me.dgvDatabases.TabIndex = 1
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.AutoSize = True
        Me.FlowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel3.Controls.Add(Me.btnRemoveDatabase)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnEditDatabase)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnAddDatabase)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(0, 255)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(526, 29)
        Me.FlowLayoutPanel3.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.AutoSize = True
        Me.Panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(526, 18)
        Me.Panel6.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(1)
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Databases"
        '
        'pnlRegions
        '
        Me.pnlRegions.Controls.Add(Me.dgvRegions)
        Me.pnlRegions.Controls.Add(Me.FlowLayoutPanel4)
        Me.pnlRegions.Controls.Add(Me.Panel7)
        Me.pnlRegions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRegions.Location = New System.Drawing.Point(0, 0)
        Me.pnlRegions.Name = "pnlRegions"
        Me.pnlRegions.Size = New System.Drawing.Size(526, 284)
        Me.pnlRegions.TabIndex = 14
        Me.pnlRegions.Visible = False
        '
        'dgvRegions
        '
        Me.dgvRegions.AllowUserToAddRows = False
        Me.dgvRegions.AllowUserToDeleteRows = False
        Me.dgvRegions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRegions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRegions.Location = New System.Drawing.Point(0, 18)
        Me.dgvRegions.MultiSelect = False
        Me.dgvRegions.Name = "dgvRegions"
        Me.dgvRegions.ReadOnly = True
        Me.dgvRegions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRegions.Size = New System.Drawing.Size(526, 237)
        Me.dgvRegions.TabIndex = 11
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.AutoSize = True
        Me.FlowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel4.Controls.Add(Me.btnRemoveRegion)
        Me.FlowLayoutPanel4.Controls.Add(Me.btnEditRegion)
        Me.FlowLayoutPanel4.Controls.Add(Me.btnAddRegion)
        Me.FlowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(0, 255)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(526, 29)
        Me.FlowLayoutPanel4.TabIndex = 12
        '
        'Panel7
        '
        Me.Panel7.AutoSize = True
        Me.Panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel7.Controls.Add(Me.Label6)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(526, 18)
        Me.Panel7.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(1)
        Me.Label6.Size = New System.Drawing.Size(48, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Regions"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.btnFinished)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnBack)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 284)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(526, 29)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btnFinished
        '
        Me.btnFinished.Location = New System.Drawing.Point(448, 3)
        Me.btnFinished.Name = "btnFinished"
        Me.btnFinished.Size = New System.Drawing.Size(75, 23)
        Me.btnFinished.TabIndex = 6
        Me.btnFinished.Text = "Finished"
        Me.btnFinished.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBack.Location = New System.Drawing.Point(367, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 7
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        Me.btnBack.Visible = False
        '
        'pnlMapServers
        '
        Me.pnlMapServers.Controls.Add(Me.dgvMapServers)
        Me.pnlMapServers.Controls.Add(Me.FlowLayoutPanel5)
        Me.pnlMapServers.Controls.Add(Me.Panel4)
        Me.pnlMapServers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMapServers.Location = New System.Drawing.Point(0, 0)
        Me.pnlMapServers.Name = "pnlMapServers"
        Me.pnlMapServers.Size = New System.Drawing.Size(526, 284)
        Me.pnlMapServers.TabIndex = 13
        Me.pnlMapServers.Visible = False
        '
        'dgvMapServers
        '
        Me.dgvMapServers.AllowUserToAddRows = False
        Me.dgvMapServers.AllowUserToDeleteRows = False
        Me.dgvMapServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMapServers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMapServers.Location = New System.Drawing.Point(0, 18)
        Me.dgvMapServers.MultiSelect = False
        Me.dgvMapServers.Name = "dgvMapServers"
        Me.dgvMapServers.ReadOnly = True
        Me.dgvMapServers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMapServers.Size = New System.Drawing.Size(526, 237)
        Me.dgvMapServers.TabIndex = 0
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.AutoSize = True
        Me.FlowLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel5.Controls.Add(Me.DeleteMapServer)
        Me.FlowLayoutPanel5.Controls.Add(Me.EditMapServer)
        Me.FlowLayoutPanel5.Controls.Add(Me.AddMapServer)
        Me.FlowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(0, 255)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(526, 29)
        Me.FlowLayoutPanel5.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(526, 18)
        Me.Panel4.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Padding = New System.Windows.Forms.Padding(1)
        Me.Label13.Size = New System.Drawing.Size(69, 15)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Map Servers"
        '
        'pnlContacts
        '
        Me.pnlContacts.Controls.Add(Me.dgvContacts)
        Me.pnlContacts.Controls.Add(Me.FlowLayoutPanel6)
        Me.pnlContacts.Controls.Add(Me.Panel9)
        Me.pnlContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContacts.Location = New System.Drawing.Point(0, 0)
        Me.pnlContacts.Name = "pnlContacts"
        Me.pnlContacts.Size = New System.Drawing.Size(526, 284)
        Me.pnlContacts.TabIndex = 13
        Me.pnlContacts.Visible = False
        '
        'dgvContacts
        '
        Me.dgvContacts.AllowUserToAddRows = False
        Me.dgvContacts.AllowUserToDeleteRows = False
        Me.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvContacts.Location = New System.Drawing.Point(0, 18)
        Me.dgvContacts.MultiSelect = False
        Me.dgvContacts.Name = "dgvContacts"
        Me.dgvContacts.ReadOnly = True
        Me.dgvContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvContacts.Size = New System.Drawing.Size(526, 237)
        Me.dgvContacts.TabIndex = 0
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.AutoSize = True
        Me.FlowLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel6.Controls.Add(Me.DeletContact)
        Me.FlowLayoutPanel6.Controls.Add(Me.EditContact)
        Me.FlowLayoutPanel6.Controls.Add(Me.AddContact)
        Me.FlowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(0, 255)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(526, 29)
        Me.FlowLayoutPanel6.TabIndex = 1
        '
        'Panel9
        '
        Me.Panel9.AutoSize = True
        Me.Panel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel9.Controls.Add(Me.Label14)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(526, 18)
        Me.Panel9.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(1)
        Me.Label14.Size = New System.Drawing.Size(51, 15)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Contacts"
        '
        'pnlChoices
        '
        Me.pnlChoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlChoices.Controls.Add(Me.btnContacts)
        Me.pnlChoices.Controls.Add(Me.Label11)
        Me.pnlChoices.Controls.Add(Me.btnMapServers)
        Me.pnlChoices.Controls.Add(Me.Label12)
        Me.pnlChoices.Controls.Add(Me.Panel2)
        Me.pnlChoices.Controls.Add(Me.btnMapServices)
        Me.pnlChoices.Controls.Add(Me.Label8)
        Me.pnlChoices.Controls.Add(Me.btnODMDatabases)
        Me.pnlChoices.Controls.Add(Me.Label9)
        Me.pnlChoices.Controls.Add(Me.btnRegions)
        Me.pnlChoices.Controls.Add(Me.Label10)
        Me.pnlChoices.Location = New System.Drawing.Point(3, 96)
        Me.pnlChoices.Name = "pnlChoices"
        Me.pnlChoices.Size = New System.Drawing.Size(511, 185)
        Me.pnlChoices.TabIndex = 15
        '
        'btnContacts
        '
        Me.btnContacts.Location = New System.Drawing.Point(8, 29)
        Me.btnContacts.Name = "btnContacts"
        Me.btnContacts.Size = New System.Drawing.Size(109, 23)
        Me.btnContacts.TabIndex = 1
        Me.btnContacts.Text = "Contacts"
        Me.btnContacts.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(123, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(345, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Add/Edit/Remove Contacts from the HydroServer Capabilites Database"
        '
        'btnMapServers
        '
        Me.btnMapServers.Location = New System.Drawing.Point(8, 58)
        Me.btnMapServers.Name = "btnMapServers"
        Me.btnMapServers.Size = New System.Drawing.Size(109, 23)
        Me.btnMapServers.TabIndex = 2
        Me.btnMapServers.Text = "Map Servers"
        Me.btnMapServers.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(123, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(363, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Add/Edit/Remove Map Servers from the HydroServer Capabilites Database"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(511, 23)
        Me.Panel2.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(5, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Where to now?"
        '
        'btnMapServices
        '
        Me.btnMapServices.Location = New System.Drawing.Point(8, 87)
        Me.btnMapServices.Name = "btnMapServices"
        Me.btnMapServices.Size = New System.Drawing.Size(109, 23)
        Me.btnMapServices.TabIndex = 3
        Me.btnMapServices.Text = "Map Services"
        Me.btnMapServices.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(123, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(368, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Add/Edit/Remove Map Services from the HydroServer Capabilites Database"
        '
        'btnODMDatabases
        '
        Me.btnODMDatabases.Location = New System.Drawing.Point(8, 116)
        Me.btnODMDatabases.Name = "btnODMDatabases"
        Me.btnODMDatabases.Size = New System.Drawing.Size(109, 23)
        Me.btnODMDatabases.TabIndex = 4
        Me.btnODMDatabases.Text = "ODM Databases"
        Me.btnODMDatabases.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(123, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(382, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Add/Edit/Remove ODM Databases from the HydroServer Capabilites Database"
        '
        'btnRegions
        '
        Me.btnRegions.Location = New System.Drawing.Point(8, 145)
        Me.btnRegions.Name = "btnRegions"
        Me.btnRegions.Size = New System.Drawing.Size(109, 23)
        Me.btnRegions.TabIndex = 5
        Me.btnRegions.Text = "Regions"
        Me.btnRegions.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(123, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(342, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Add/Edit/Remove Regions from the HydroServer Capabilites Database"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 0)
        Me.Panel1.TabIndex = 4
        '
        'pnlIcewater
        '
        Me.pnlIcewater.Controls.Add(Me.Panel3)
        Me.pnlIcewater.Controls.Add(Me.Panel1)
        Me.pnlIcewater.Controls.Add(Me.pnlChoices)
        Me.pnlIcewater.Controls.Add(Me.MenuStrip1)
        Me.pnlIcewater.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlIcewater.Location = New System.Drawing.Point(0, 0)
        Me.pnlIcewater.Name = "pnlIcewater"
        Me.pnlIcewater.Size = New System.Drawing.Size(526, 284)
        Me.pnlIcewater.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lblServer)
        Me.Panel3.Controls.Add(Me.lblUser)
        Me.Panel3.Controls.Add(Me.lblCurrUser)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.lblDBName)
        Me.Panel3.Location = New System.Drawing.Point(0, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(346, 66)
        Me.Panel3.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Server Address:"
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(102, 3)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(0, 13)
        Me.lblServer.TabIndex = 28
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(35, 47)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(67, 13)
        Me.lblUser.TabIndex = 18
        Me.lblUser.Text = "Username:"
        '
        'lblCurrUser
        '
        Me.lblCurrUser.AllowDrop = True
        Me.lblCurrUser.AutoSize = True
        Me.lblCurrUser.Location = New System.Drawing.Point(104, 47)
        Me.lblCurrUser.Name = "lblCurrUser"
        Me.lblCurrUser.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrUser.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Database Name:"
        '
        'lblDBName
        '
        Me.lblDBName.AutoSize = True
        Me.lblDBName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDBName.Location = New System.Drawing.Point(102, 25)
        Me.lblDBName.Name = "lblDBName"
        Me.lblDBName.Size = New System.Drawing.Size(0, 13)
        Me.lblDBName.TabIndex = 26
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(526, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditDbConnectionToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.EditToolStripMenuItem.Text = "Tools"
        '
        'EditDbConnectionToolStripMenuItem
        '
        Me.EditDbConnectionToolStripMenuItem.Name = "EditDbConnectionToolStripMenuItem"
        Me.EditDbConnectionToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.EditDbConnectionToolStripMenuItem.Text = "Edit DB connection"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'DeletContact
        '
        Me.DeletContact.Image = CType(resources.GetObject("DeletContact.Image"), System.Drawing.Image)
        Me.DeletContact.Location = New System.Drawing.Point(500, 3)
        Me.DeletContact.Name = "DeletContact"
        Me.DeletContact.Size = New System.Drawing.Size(23, 23)
        Me.DeletContact.TabIndex = 2
        Me.DeletContact.UseVisualStyleBackColor = True
        '
        'EditContact
        '
        Me.EditContact.Image = CType(resources.GetObject("EditContact.Image"), System.Drawing.Image)
        Me.EditContact.Location = New System.Drawing.Point(471, 3)
        Me.EditContact.Name = "EditContact"
        Me.EditContact.Size = New System.Drawing.Size(23, 23)
        Me.EditContact.TabIndex = 1
        Me.EditContact.UseVisualStyleBackColor = True
        '
        'AddContact
        '
        Me.AddContact.Image = CType(resources.GetObject("AddContact.Image"), System.Drawing.Image)
        Me.AddContact.Location = New System.Drawing.Point(442, 3)
        Me.AddContact.Name = "AddContact"
        Me.AddContact.Size = New System.Drawing.Size(23, 23)
        Me.AddContact.TabIndex = 0
        Me.AddContact.UseVisualStyleBackColor = True
        '
        'DeleteMapServer
        '
        Me.DeleteMapServer.Image = CType(resources.GetObject("DeleteMapServer.Image"), System.Drawing.Image)
        Me.DeleteMapServer.Location = New System.Drawing.Point(500, 3)
        Me.DeleteMapServer.Name = "DeleteMapServer"
        Me.DeleteMapServer.Size = New System.Drawing.Size(23, 23)
        Me.DeleteMapServer.TabIndex = 2
        Me.DeleteMapServer.UseVisualStyleBackColor = True
        '
        'EditMapServer
        '
        Me.EditMapServer.Image = CType(resources.GetObject("EditMapServer.Image"), System.Drawing.Image)
        Me.EditMapServer.Location = New System.Drawing.Point(471, 3)
        Me.EditMapServer.Name = "EditMapServer"
        Me.EditMapServer.Size = New System.Drawing.Size(23, 23)
        Me.EditMapServer.TabIndex = 1
        Me.EditMapServer.UseVisualStyleBackColor = True
        '
        'AddMapServer
        '
        Me.AddMapServer.Image = CType(resources.GetObject("AddMapServer.Image"), System.Drawing.Image)
        Me.AddMapServer.Location = New System.Drawing.Point(442, 3)
        Me.AddMapServer.Name = "AddMapServer"
        Me.AddMapServer.Size = New System.Drawing.Size(23, 23)
        Me.AddMapServer.TabIndex = 0
        Me.AddMapServer.UseVisualStyleBackColor = True
        '
        'btnRemoveMap
        '
        Me.btnRemoveMap.Image = CType(resources.GetObject("btnRemoveMap.Image"), System.Drawing.Image)
        Me.btnRemoveMap.Location = New System.Drawing.Point(500, 3)
        Me.btnRemoveMap.Name = "btnRemoveMap"
        Me.btnRemoveMap.Size = New System.Drawing.Size(23, 23)
        Me.btnRemoveMap.TabIndex = 2
        Me.btnRemoveMap.UseVisualStyleBackColor = True
        '
        'btnEditMap
        '
        Me.btnEditMap.Image = CType(resources.GetObject("btnEditMap.Image"), System.Drawing.Image)
        Me.btnEditMap.Location = New System.Drawing.Point(471, 3)
        Me.btnEditMap.Name = "btnEditMap"
        Me.btnEditMap.Size = New System.Drawing.Size(23, 23)
        Me.btnEditMap.TabIndex = 1
        Me.btnEditMap.UseVisualStyleBackColor = True
        '
        'btnAddMap
        '
        Me.btnAddMap.Image = CType(resources.GetObject("btnAddMap.Image"), System.Drawing.Image)
        Me.btnAddMap.Location = New System.Drawing.Point(442, 3)
        Me.btnAddMap.Name = "btnAddMap"
        Me.btnAddMap.Size = New System.Drawing.Size(23, 23)
        Me.btnAddMap.TabIndex = 0
        Me.btnAddMap.UseVisualStyleBackColor = True
        '
        'btnRemoveDatabase
        '
        Me.btnRemoveDatabase.Image = CType(resources.GetObject("btnRemoveDatabase.Image"), System.Drawing.Image)
        Me.btnRemoveDatabase.Location = New System.Drawing.Point(500, 3)
        Me.btnRemoveDatabase.Name = "btnRemoveDatabase"
        Me.btnRemoveDatabase.Size = New System.Drawing.Size(23, 23)
        Me.btnRemoveDatabase.TabIndex = 2
        Me.btnRemoveDatabase.UseVisualStyleBackColor = True
        '
        'btnEditDatabase
        '
        Me.btnEditDatabase.Image = CType(resources.GetObject("btnEditDatabase.Image"), System.Drawing.Image)
        Me.btnEditDatabase.Location = New System.Drawing.Point(471, 3)
        Me.btnEditDatabase.Name = "btnEditDatabase"
        Me.btnEditDatabase.Size = New System.Drawing.Size(23, 23)
        Me.btnEditDatabase.TabIndex = 1
        Me.btnEditDatabase.UseVisualStyleBackColor = True
        '
        'btnAddDatabase
        '
        Me.btnAddDatabase.Image = CType(resources.GetObject("btnAddDatabase.Image"), System.Drawing.Image)
        Me.btnAddDatabase.Location = New System.Drawing.Point(442, 3)
        Me.btnAddDatabase.Name = "btnAddDatabase"
        Me.btnAddDatabase.Size = New System.Drawing.Size(23, 23)
        Me.btnAddDatabase.TabIndex = 0
        Me.btnAddDatabase.UseVisualStyleBackColor = True
        '
        'btnRemoveRegion
        '
        Me.btnRemoveRegion.Image = CType(resources.GetObject("btnRemoveRegion.Image"), System.Drawing.Image)
        Me.btnRemoveRegion.Location = New System.Drawing.Point(500, 3)
        Me.btnRemoveRegion.Name = "btnRemoveRegion"
        Me.btnRemoveRegion.Size = New System.Drawing.Size(23, 23)
        Me.btnRemoveRegion.TabIndex = 3
        Me.btnRemoveRegion.UseVisualStyleBackColor = True
        '
        'btnEditRegion
        '
        Me.btnEditRegion.Image = CType(resources.GetObject("btnEditRegion.Image"), System.Drawing.Image)
        Me.btnEditRegion.Location = New System.Drawing.Point(471, 3)
        Me.btnEditRegion.Name = "btnEditRegion"
        Me.btnEditRegion.Size = New System.Drawing.Size(23, 23)
        Me.btnEditRegion.TabIndex = 4
        Me.btnEditRegion.UseVisualStyleBackColor = True
        '
        'btnAddRegion
        '
        Me.btnAddRegion.Image = CType(resources.GetObject("btnAddRegion.Image"), System.Drawing.Image)
        Me.btnAddRegion.Location = New System.Drawing.Point(442, 3)
        Me.btnAddRegion.Name = "btnAddRegion"
        Me.btnAddRegion.Size = New System.Drawing.Size(23, 23)
        Me.btnAddRegion.TabIndex = 5
        Me.btnAddRegion.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 313)
        Me.Controls.Add(Me.pnlIcewater)
        Me.Controls.Add(Me.pnlContacts)
        Me.Controls.Add(Me.pnlMapServers)
        Me.Controls.Add(Me.pnlMaps)
        Me.Controls.Add(Me.pnlDatabases)
        Me.Controls.Add(Me.pnlRegions)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = " HydroServer Capabilities Database Configuration Tool"
        Me.pnlMaps.ResumeLayout(False)
        Me.pnlMaps.PerformLayout()
        CType(Me.dgvMaps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlDatabases.ResumeLayout(False)
        Me.pnlDatabases.PerformLayout()
        CType(Me.dgvDatabases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlRegions.ResumeLayout(False)
        Me.pnlRegions.PerformLayout()
        CType(Me.dgvRegions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlMapServers.ResumeLayout(False)
        Me.pnlMapServers.PerformLayout()
        CType(Me.dgvMapServers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlContacts.ResumeLayout(False)
        Me.pnlContacts.PerformLayout()
        CType(Me.dgvContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.pnlChoices.ResumeLayout(False)
        Me.pnlChoices.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlIcewater.ResumeLayout(False)
        Me.pnlIcewater.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IcewaterConnection As System.Data.SqlClient.SqlConnection
    Friend WithEvents pnlMaps As System.Windows.Forms.Panel
    Friend WithEvents pnlDatabases As System.Windows.Forms.Panel
    Friend WithEvents pnlRegions As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnFinished As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents dgvMaps As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDatabases As System.Windows.Forms.DataGridView
    Friend WithEvents dgvRegions As System.Windows.Forms.DataGridView
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnRemoveMap As System.Windows.Forms.Button
    Friend WithEvents btnEditMap As System.Windows.Forms.Button
    Friend WithEvents btnAddMap As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnRemoveDatabase As System.Windows.Forms.Button
    Friend WithEvents btnEditDatabase As System.Windows.Forms.Button
    Friend WithEvents btnAddDatabase As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnRemoveRegion As System.Windows.Forms.Button
    Friend WithEvents btnEditRegion As System.Windows.Forms.Button
    Friend WithEvents btnAddRegion As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlMapServers As System.Windows.Forms.Panel
    Friend WithEvents dgvMapServers As System.Windows.Forms.DataGridView
    Friend WithEvents FlowLayoutPanel5 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents DeleteMapServer As System.Windows.Forms.Button
    Friend WithEvents EditMapServer As System.Windows.Forms.Button
    Friend WithEvents AddMapServer As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlContacts As System.Windows.Forms.Panel
    Friend WithEvents dgvContacts As System.Windows.Forms.DataGridView
    Friend WithEvents FlowLayoutPanel6 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents DeletContact As System.Windows.Forms.Button
    Friend WithEvents EditContact As System.Windows.Forms.Button
    Friend WithEvents AddContact As System.Windows.Forms.Button
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlChoices As System.Windows.Forms.Panel
    Friend WithEvents btnContacts As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnMapServers As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnMapServices As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnODMDatabases As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnRegions As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlIcewater As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditDbConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblDBName As System.Windows.Forms.Label
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents lblCurrUser As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
