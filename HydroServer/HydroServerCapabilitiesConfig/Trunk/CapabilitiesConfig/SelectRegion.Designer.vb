<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectRegion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectRegion))
        Me.flpFormNavButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnFinish = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.pnlDefineRegion = New System.Windows.Forms.Panel
        Me.pnlData = New System.Windows.Forms.Panel
        Me.lblDisplayName = New System.Windows.Forms.Label
        Me.txtDisplayName = New System.Windows.Forms.TextBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.lblWebsite = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblCSS = New System.Windows.Forms.Label
        Me.txtCSS = New System.Windows.Forms.TextBox
        Me.pnlRegionInstructions = New System.Windows.Forms.Panel
        Me.lblRegionInstructions = New System.Windows.Forms.Label
        Me.pnlSelectDatabases = New System.Windows.Forms.Panel
        Me.tlpDatabases = New System.Windows.Forms.TableLayoutPanel
        Me.lstNewDatabases = New System.Windows.Forms.ListBox
        Me.flpDatabaseNavButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnAddAllDatabases = New System.Windows.Forms.Button
        Me.btnAddSelectedDatabases = New System.Windows.Forms.Button
        Me.btnRemoveSelectedDatabases = New System.Windows.Forms.Button
        Me.btnRemoveAllDatabases = New System.Windows.Forms.Button
        Me.pnlUsedDatabases = New System.Windows.Forms.Panel
        Me.lstUsedDatabases = New System.Windows.Forms.ListBox
        Me.flpDatabaseOrderButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnMoveDatabaseUp = New System.Windows.Forms.Button
        Me.btnMoveDatabaseDown = New System.Windows.Forms.Button
        Me.pnlSelectDatabaseInstructions = New System.Windows.Forms.Panel
        Me.lblSelectDatabaseInstructions = New System.Windows.Forms.Label
        Me.pnlSelectMaps = New System.Windows.Forms.Panel
        Me.tlpMaps = New System.Windows.Forms.TableLayoutPanel
        Me.lstNewMaps = New System.Windows.Forms.ListBox
        Me.flpMapNavButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnAddAllMaps = New System.Windows.Forms.Button
        Me.btnAddSelectedMaps = New System.Windows.Forms.Button
        Me.btnRemoveSelectedMaps = New System.Windows.Forms.Button
        Me.btnRemoveAllMaps = New System.Windows.Forms.Button
        Me.pnlUsedMaps = New System.Windows.Forms.Panel
        Me.lstUsedMaps = New System.Windows.Forms.ListBox
        Me.flpMapOrderButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnMoveMapUp = New System.Windows.Forms.Button
        Me.btnMoveMapDown = New System.Windows.Forms.Button
        Me.pnlSelectMapInstructions = New System.Windows.Forms.Panel
        Me.lblSelectMapInstructions = New System.Windows.Forms.Label
        Me.pnlMetadata = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvMeta = New System.Windows.Forms.DataGridView
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Content = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnRemoveMeta = New System.Windows.Forms.Button
        Me.btnEditMeta = New System.Windows.Forms.Button
        Me.btnAddMeta = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.numNorthExtent = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.numSouthExtent = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.numEastExtent = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.numWestExtent = New System.Windows.Forms.NumericUpDown
        Me.flpFormNavButtons.SuspendLayout()
        Me.pnlDefineRegion.SuspendLayout()
        Me.pnlData.SuspendLayout()
        Me.pnlRegionInstructions.SuspendLayout()
        Me.pnlSelectDatabases.SuspendLayout()
        Me.tlpDatabases.SuspendLayout()
        Me.flpDatabaseNavButtons.SuspendLayout()
        Me.pnlUsedDatabases.SuspendLayout()
        Me.flpDatabaseOrderButtons.SuspendLayout()
        Me.pnlSelectDatabaseInstructions.SuspendLayout()
        Me.pnlSelectMaps.SuspendLayout()
        Me.tlpMaps.SuspendLayout()
        Me.flpMapNavButtons.SuspendLayout()
        Me.pnlUsedMaps.SuspendLayout()
        Me.flpMapOrderButtons.SuspendLayout()
        Me.pnlSelectMapInstructions.SuspendLayout()
        Me.pnlMetadata.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numNorthExtent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSouthExtent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numEastExtent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWestExtent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flpFormNavButtons
        '
        Me.flpFormNavButtons.AutoSize = True
        Me.flpFormNavButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFormNavButtons.Controls.Add(Me.btnFinish)
        Me.flpFormNavButtons.Controls.Add(Me.btnNext)
        Me.flpFormNavButtons.Controls.Add(Me.btnBack)
        Me.flpFormNavButtons.Controls.Add(Me.btnCancel)
        Me.flpFormNavButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpFormNavButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpFormNavButtons.Location = New System.Drawing.Point(0, 256)
        Me.flpFormNavButtons.Name = "flpFormNavButtons"
        Me.flpFormNavButtons.Size = New System.Drawing.Size(520, 29)
        Me.flpFormNavButtons.TabIndex = 3
        '
        'btnFinish
        '
        Me.btnFinish.Location = New System.Drawing.Point(442, 3)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(75, 23)
        Me.btnFinish.TabIndex = 3
        Me.btnFinish.Text = "Finish"
        Me.btnFinish.UseVisualStyleBackColor = True
        Me.btnFinish.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(361, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(280, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 4
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        Me.btnBack.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(199, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlDefineRegion
        '
        Me.pnlDefineRegion.Controls.Add(Me.pnlData)
        Me.pnlDefineRegion.Controls.Add(Me.pnlRegionInstructions)
        Me.pnlDefineRegion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDefineRegion.Location = New System.Drawing.Point(0, 0)
        Me.pnlDefineRegion.Name = "pnlDefineRegion"
        Me.pnlDefineRegion.Size = New System.Drawing.Size(520, 256)
        Me.pnlDefineRegion.TabIndex = 0
        '
        'pnlData
        '
        Me.pnlData.Controls.Add(Me.lblDisplayName)
        Me.pnlData.Controls.Add(Me.txtDisplayName)
        Me.pnlData.Controls.Add(Me.lblTitle)
        Me.pnlData.Controls.Add(Me.txtTitle)
        Me.pnlData.Controls.Add(Me.lblWebsite)
        Me.pnlData.Controls.Add(Me.txtDescription)
        Me.pnlData.Controls.Add(Me.lblCSS)
        Me.pnlData.Controls.Add(Me.txtCSS)
        Me.pnlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlData.Location = New System.Drawing.Point(0, 23)
        Me.pnlData.Name = "pnlData"
        Me.pnlData.Size = New System.Drawing.Size(520, 233)
        Me.pnlData.TabIndex = 1
        '
        'lblDisplayName
        '
        Me.lblDisplayName.AutoSize = True
        Me.lblDisplayName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayName.Location = New System.Drawing.Point(12, 12)
        Me.lblDisplayName.Name = "lblDisplayName"
        Me.lblDisplayName.Size = New System.Drawing.Size(84, 13)
        Me.lblDisplayName.TabIndex = 0
        Me.lblDisplayName.Text = "Display Name"
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDisplayName.Location = New System.Drawing.Point(102, 9)
        Me.txtDisplayName.MaxLength = 255
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(415, 20)
        Me.txtDisplayName.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 38)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(32, 13)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "Title"
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Location = New System.Drawing.Point(50, 35)
        Me.txtTitle.MaxLength = 255
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(467, 20)
        Me.txtTitle.TabIndex = 3
        '
        'lblWebsite
        '
        Me.lblWebsite.AutoSize = True
        Me.lblWebsite.Location = New System.Drawing.Point(12, 64)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(97, 13)
        Me.lblWebsite.TabIndex = 4
        Me.lblWebsite.Text = "Region Description"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(115, 61)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(402, 60)
        Me.txtDescription.TabIndex = 5
        '
        'lblCSS
        '
        Me.lblCSS.AutoSize = True
        Me.lblCSS.Location = New System.Drawing.Point(12, 130)
        Me.lblCSS.Name = "lblCSS"
        Me.lblCSS.Size = New System.Drawing.Size(114, 13)
        Me.lblCSS.TabIndex = 6
        Me.lblCSS.Text = "Region Map CSS URL"
        '
        'txtCSS
        '
        Me.txtCSS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCSS.Location = New System.Drawing.Point(132, 127)
        Me.txtCSS.MaxLength = 500
        Me.txtCSS.Name = "txtCSS"
        Me.txtCSS.Size = New System.Drawing.Size(385, 20)
        Me.txtCSS.TabIndex = 7
        '
        'pnlRegionInstructions
        '
        Me.pnlRegionInstructions.AutoSize = True
        Me.pnlRegionInstructions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlRegionInstructions.Controls.Add(Me.lblRegionInstructions)
        Me.pnlRegionInstructions.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRegionInstructions.Location = New System.Drawing.Point(0, 0)
        Me.pnlRegionInstructions.Name = "pnlRegionInstructions"
        Me.pnlRegionInstructions.Size = New System.Drawing.Size(520, 23)
        Me.pnlRegionInstructions.TabIndex = 0
        '
        'lblRegionInstructions
        '
        Me.lblRegionInstructions.AutoSize = True
        Me.lblRegionInstructions.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRegionInstructions.Location = New System.Drawing.Point(0, 0)
        Me.lblRegionInstructions.Name = "lblRegionInstructions"
        Me.lblRegionInstructions.Padding = New System.Windows.Forms.Padding(5)
        Me.lblRegionInstructions.Size = New System.Drawing.Size(101, 23)
        Me.lblRegionInstructions.TabIndex = 0
        Me.lblRegionInstructions.Text = "Define the region:"
        '
        'pnlSelectDatabases
        '
        Me.pnlSelectDatabases.Controls.Add(Me.tlpDatabases)
        Me.pnlSelectDatabases.Controls.Add(Me.pnlSelectDatabaseInstructions)
        Me.pnlSelectDatabases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSelectDatabases.Location = New System.Drawing.Point(0, 0)
        Me.pnlSelectDatabases.Name = "pnlSelectDatabases"
        Me.pnlSelectDatabases.Size = New System.Drawing.Size(520, 256)
        Me.pnlSelectDatabases.TabIndex = 2
        Me.pnlSelectDatabases.Visible = False
        '
        'tlpDatabases
        '
        Me.tlpDatabases.ColumnCount = 3
        Me.tlpDatabases.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpDatabases.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpDatabases.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpDatabases.Controls.Add(Me.lstNewDatabases, 0, 0)
        Me.tlpDatabases.Controls.Add(Me.flpDatabaseNavButtons, 1, 0)
        Me.tlpDatabases.Controls.Add(Me.pnlUsedDatabases, 2, 0)
        Me.tlpDatabases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDatabases.Location = New System.Drawing.Point(0, 23)
        Me.tlpDatabases.Name = "tlpDatabases"
        Me.tlpDatabases.RowCount = 1
        Me.tlpDatabases.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDatabases.Size = New System.Drawing.Size(520, 233)
        Me.tlpDatabases.TabIndex = 15
        '
        'lstNewDatabases
        '
        Me.lstNewDatabases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstNewDatabases.FormattingEnabled = True
        Me.lstNewDatabases.Location = New System.Drawing.Point(3, 3)
        Me.lstNewDatabases.Name = "lstNewDatabases"
        Me.lstNewDatabases.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstNewDatabases.Size = New System.Drawing.Size(233, 225)
        Me.lstNewDatabases.TabIndex = 0
        '
        'flpDatabaseNavButtons
        '
        Me.flpDatabaseNavButtons.AutoSize = True
        Me.flpDatabaseNavButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpDatabaseNavButtons.Controls.Add(Me.btnAddAllDatabases)
        Me.flpDatabaseNavButtons.Controls.Add(Me.btnAddSelectedDatabases)
        Me.flpDatabaseNavButtons.Controls.Add(Me.btnRemoveSelectedDatabases)
        Me.flpDatabaseNavButtons.Controls.Add(Me.btnRemoveAllDatabases)
        Me.flpDatabaseNavButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpDatabaseNavButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpDatabaseNavButtons.Location = New System.Drawing.Point(242, 3)
        Me.flpDatabaseNavButtons.Name = "flpDatabaseNavButtons"
        Me.flpDatabaseNavButtons.Size = New System.Drawing.Size(36, 227)
        Me.flpDatabaseNavButtons.TabIndex = 1
        '
        'btnAddAllDatabases
        '
        Me.btnAddAllDatabases.Location = New System.Drawing.Point(3, 3)
        Me.btnAddAllDatabases.Name = "btnAddAllDatabases"
        Me.btnAddAllDatabases.Size = New System.Drawing.Size(30, 23)
        Me.btnAddAllDatabases.TabIndex = 0
        Me.btnAddAllDatabases.Text = ">>"
        Me.btnAddAllDatabases.UseVisualStyleBackColor = True
        '
        'btnAddSelectedDatabases
        '
        Me.btnAddSelectedDatabases.Location = New System.Drawing.Point(3, 32)
        Me.btnAddSelectedDatabases.Name = "btnAddSelectedDatabases"
        Me.btnAddSelectedDatabases.Size = New System.Drawing.Size(30, 23)
        Me.btnAddSelectedDatabases.TabIndex = 1
        Me.btnAddSelectedDatabases.Text = ">"
        Me.btnAddSelectedDatabases.UseVisualStyleBackColor = True
        '
        'btnRemoveSelectedDatabases
        '
        Me.btnRemoveSelectedDatabases.Location = New System.Drawing.Point(3, 61)
        Me.btnRemoveSelectedDatabases.Name = "btnRemoveSelectedDatabases"
        Me.btnRemoveSelectedDatabases.Size = New System.Drawing.Size(30, 23)
        Me.btnRemoveSelectedDatabases.TabIndex = 2
        Me.btnRemoveSelectedDatabases.Text = "<"
        Me.btnRemoveSelectedDatabases.UseVisualStyleBackColor = True
        '
        'btnRemoveAllDatabases
        '
        Me.btnRemoveAllDatabases.Location = New System.Drawing.Point(3, 90)
        Me.btnRemoveAllDatabases.Name = "btnRemoveAllDatabases"
        Me.btnRemoveAllDatabases.Size = New System.Drawing.Size(30, 23)
        Me.btnRemoveAllDatabases.TabIndex = 3
        Me.btnRemoveAllDatabases.Text = "<<"
        Me.btnRemoveAllDatabases.UseVisualStyleBackColor = True
        '
        'pnlUsedDatabases
        '
        Me.pnlUsedDatabases.Controls.Add(Me.lstUsedDatabases)
        Me.pnlUsedDatabases.Controls.Add(Me.flpDatabaseOrderButtons)
        Me.pnlUsedDatabases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUsedDatabases.Location = New System.Drawing.Point(284, 3)
        Me.pnlUsedDatabases.Name = "pnlUsedDatabases"
        Me.pnlUsedDatabases.Size = New System.Drawing.Size(233, 227)
        Me.pnlUsedDatabases.TabIndex = 2
        '
        'lstUsedDatabases
        '
        Me.lstUsedDatabases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstUsedDatabases.FormattingEnabled = True
        Me.lstUsedDatabases.Location = New System.Drawing.Point(0, 0)
        Me.lstUsedDatabases.Name = "lstUsedDatabases"
        Me.lstUsedDatabases.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstUsedDatabases.Size = New System.Drawing.Size(233, 186)
        Me.lstUsedDatabases.TabIndex = 0
        '
        'flpDatabaseOrderButtons
        '
        Me.flpDatabaseOrderButtons.AutoSize = True
        Me.flpDatabaseOrderButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpDatabaseOrderButtons.Controls.Add(Me.btnMoveDatabaseUp)
        Me.flpDatabaseOrderButtons.Controls.Add(Me.btnMoveDatabaseDown)
        Me.flpDatabaseOrderButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpDatabaseOrderButtons.Location = New System.Drawing.Point(0, 198)
        Me.flpDatabaseOrderButtons.Name = "flpDatabaseOrderButtons"
        Me.flpDatabaseOrderButtons.Size = New System.Drawing.Size(233, 29)
        Me.flpDatabaseOrderButtons.TabIndex = 0
        '
        'btnMoveDatabaseUp
        '
        Me.btnMoveDatabaseUp.Location = New System.Drawing.Point(3, 3)
        Me.btnMoveDatabaseUp.Name = "btnMoveDatabaseUp"
        Me.btnMoveDatabaseUp.Size = New System.Drawing.Size(30, 23)
        Me.btnMoveDatabaseUp.TabIndex = 0
        Me.btnMoveDatabaseUp.Text = "/\"
        Me.btnMoveDatabaseUp.UseVisualStyleBackColor = True
        '
        'btnMoveDatabaseDown
        '
        Me.btnMoveDatabaseDown.Location = New System.Drawing.Point(39, 3)
        Me.btnMoveDatabaseDown.Name = "btnMoveDatabaseDown"
        Me.btnMoveDatabaseDown.Size = New System.Drawing.Size(30, 23)
        Me.btnMoveDatabaseDown.TabIndex = 1
        Me.btnMoveDatabaseDown.Text = "\/"
        Me.btnMoveDatabaseDown.UseVisualStyleBackColor = True
        '
        'pnlSelectDatabaseInstructions
        '
        Me.pnlSelectDatabaseInstructions.AutoSize = True
        Me.pnlSelectDatabaseInstructions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSelectDatabaseInstructions.Controls.Add(Me.lblSelectDatabaseInstructions)
        Me.pnlSelectDatabaseInstructions.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSelectDatabaseInstructions.Location = New System.Drawing.Point(0, 0)
        Me.pnlSelectDatabaseInstructions.Name = "pnlSelectDatabaseInstructions"
        Me.pnlSelectDatabaseInstructions.Size = New System.Drawing.Size(520, 23)
        Me.pnlSelectDatabaseInstructions.TabIndex = 16
        '
        'lblSelectDatabaseInstructions
        '
        Me.lblSelectDatabaseInstructions.AutoSize = True
        Me.lblSelectDatabaseInstructions.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSelectDatabaseInstructions.Location = New System.Drawing.Point(0, 0)
        Me.lblSelectDatabaseInstructions.Name = "lblSelectDatabaseInstructions"
        Me.lblSelectDatabaseInstructions.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSelectDatabaseInstructions.Size = New System.Drawing.Size(229, 23)
        Me.lblSelectDatabaseInstructions.TabIndex = 0
        Me.lblSelectDatabaseInstructions.Text = "Select which databases to add to this region:"
        '
        'pnlSelectMaps
        '
        Me.pnlSelectMaps.Controls.Add(Me.tlpMaps)
        Me.pnlSelectMaps.Controls.Add(Me.pnlSelectMapInstructions)
        Me.pnlSelectMaps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSelectMaps.Location = New System.Drawing.Point(0, 0)
        Me.pnlSelectMaps.Name = "pnlSelectMaps"
        Me.pnlSelectMaps.Size = New System.Drawing.Size(520, 256)
        Me.pnlSelectMaps.TabIndex = 1
        Me.pnlSelectMaps.Visible = False
        '
        'tlpMaps
        '
        Me.tlpMaps.ColumnCount = 3
        Me.tlpMaps.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMaps.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpMaps.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMaps.Controls.Add(Me.lstNewMaps, 0, 0)
        Me.tlpMaps.Controls.Add(Me.flpMapNavButtons, 1, 0)
        Me.tlpMaps.Controls.Add(Me.pnlUsedMaps, 2, 0)
        Me.tlpMaps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMaps.Location = New System.Drawing.Point(0, 23)
        Me.tlpMaps.Name = "tlpMaps"
        Me.tlpMaps.RowCount = 1
        Me.tlpMaps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMaps.Size = New System.Drawing.Size(520, 233)
        Me.tlpMaps.TabIndex = 16
        '
        'lstNewMaps
        '
        Me.lstNewMaps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstNewMaps.FormattingEnabled = True
        Me.lstNewMaps.Location = New System.Drawing.Point(3, 3)
        Me.lstNewMaps.Name = "lstNewMaps"
        Me.lstNewMaps.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstNewMaps.Size = New System.Drawing.Size(233, 225)
        Me.lstNewMaps.TabIndex = 0
        '
        'flpMapNavButtons
        '
        Me.flpMapNavButtons.AutoSize = True
        Me.flpMapNavButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpMapNavButtons.Controls.Add(Me.btnAddAllMaps)
        Me.flpMapNavButtons.Controls.Add(Me.btnAddSelectedMaps)
        Me.flpMapNavButtons.Controls.Add(Me.btnRemoveSelectedMaps)
        Me.flpMapNavButtons.Controls.Add(Me.btnRemoveAllMaps)
        Me.flpMapNavButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpMapNavButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpMapNavButtons.Location = New System.Drawing.Point(242, 3)
        Me.flpMapNavButtons.Name = "flpMapNavButtons"
        Me.flpMapNavButtons.Size = New System.Drawing.Size(36, 227)
        Me.flpMapNavButtons.TabIndex = 0
        '
        'btnAddAllMaps
        '
        Me.btnAddAllMaps.Location = New System.Drawing.Point(3, 3)
        Me.btnAddAllMaps.Name = "btnAddAllMaps"
        Me.btnAddAllMaps.Size = New System.Drawing.Size(30, 23)
        Me.btnAddAllMaps.TabIndex = 0
        Me.btnAddAllMaps.Text = ">>"
        Me.btnAddAllMaps.UseVisualStyleBackColor = True
        '
        'btnAddSelectedMaps
        '
        Me.btnAddSelectedMaps.Location = New System.Drawing.Point(3, 32)
        Me.btnAddSelectedMaps.Name = "btnAddSelectedMaps"
        Me.btnAddSelectedMaps.Size = New System.Drawing.Size(30, 23)
        Me.btnAddSelectedMaps.TabIndex = 1
        Me.btnAddSelectedMaps.Text = ">"
        Me.btnAddSelectedMaps.UseVisualStyleBackColor = True
        '
        'btnRemoveSelectedMaps
        '
        Me.btnRemoveSelectedMaps.Location = New System.Drawing.Point(3, 61)
        Me.btnRemoveSelectedMaps.Name = "btnRemoveSelectedMaps"
        Me.btnRemoveSelectedMaps.Size = New System.Drawing.Size(30, 23)
        Me.btnRemoveSelectedMaps.TabIndex = 2
        Me.btnRemoveSelectedMaps.Text = "<"
        Me.btnRemoveSelectedMaps.UseVisualStyleBackColor = True
        '
        'btnRemoveAllMaps
        '
        Me.btnRemoveAllMaps.Location = New System.Drawing.Point(3, 90)
        Me.btnRemoveAllMaps.Name = "btnRemoveAllMaps"
        Me.btnRemoveAllMaps.Size = New System.Drawing.Size(30, 23)
        Me.btnRemoveAllMaps.TabIndex = 3
        Me.btnRemoveAllMaps.Text = "<<"
        Me.btnRemoveAllMaps.UseVisualStyleBackColor = True
        '
        'pnlUsedMaps
        '
        Me.pnlUsedMaps.Controls.Add(Me.lstUsedMaps)
        Me.pnlUsedMaps.Controls.Add(Me.flpMapOrderButtons)
        Me.pnlUsedMaps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUsedMaps.Location = New System.Drawing.Point(284, 3)
        Me.pnlUsedMaps.Name = "pnlUsedMaps"
        Me.pnlUsedMaps.Size = New System.Drawing.Size(233, 227)
        Me.pnlUsedMaps.TabIndex = 2
        '
        'lstUsedMaps
        '
        Me.lstUsedMaps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstUsedMaps.FormattingEnabled = True
        Me.lstUsedMaps.Location = New System.Drawing.Point(0, 0)
        Me.lstUsedMaps.Name = "lstUsedMaps"
        Me.lstUsedMaps.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstUsedMaps.Size = New System.Drawing.Size(233, 186)
        Me.lstUsedMaps.TabIndex = 0
        '
        'flpMapOrderButtons
        '
        Me.flpMapOrderButtons.AutoSize = True
        Me.flpMapOrderButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpMapOrderButtons.Controls.Add(Me.Label5)
        Me.flpMapOrderButtons.Controls.Add(Me.btnMoveMapUp)
        Me.flpMapOrderButtons.Controls.Add(Me.btnMoveMapDown)
        Me.flpMapOrderButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpMapOrderButtons.Location = New System.Drawing.Point(0, 198)
        Me.flpMapOrderButtons.Name = "flpMapOrderButtons"
        Me.flpMapOrderButtons.Size = New System.Drawing.Size(233, 29)
        Me.flpMapOrderButtons.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 29)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Change Display Order"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMoveMapUp
        '
        Me.btnMoveMapUp.Location = New System.Drawing.Point(95, 3)
        Me.btnMoveMapUp.Name = "btnMoveMapUp"
        Me.btnMoveMapUp.Size = New System.Drawing.Size(30, 23)
        Me.btnMoveMapUp.TabIndex = 0
        Me.btnMoveMapUp.Text = "/\"
        Me.btnMoveMapUp.UseVisualStyleBackColor = True
        '
        'btnMoveMapDown
        '
        Me.btnMoveMapDown.Location = New System.Drawing.Point(131, 3)
        Me.btnMoveMapDown.Name = "btnMoveMapDown"
        Me.btnMoveMapDown.Size = New System.Drawing.Size(30, 23)
        Me.btnMoveMapDown.TabIndex = 1
        Me.btnMoveMapDown.Text = "\/"
        Me.btnMoveMapDown.UseVisualStyleBackColor = True
        '
        'pnlSelectMapInstructions
        '
        Me.pnlSelectMapInstructions.AutoSize = True
        Me.pnlSelectMapInstructions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSelectMapInstructions.Controls.Add(Me.lblSelectMapInstructions)
        Me.pnlSelectMapInstructions.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSelectMapInstructions.Location = New System.Drawing.Point(0, 0)
        Me.pnlSelectMapInstructions.Name = "pnlSelectMapInstructions"
        Me.pnlSelectMapInstructions.Size = New System.Drawing.Size(520, 23)
        Me.pnlSelectMapInstructions.TabIndex = 15
        '
        'lblSelectMapInstructions
        '
        Me.lblSelectMapInstructions.AutoSize = True
        Me.lblSelectMapInstructions.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSelectMapInstructions.Location = New System.Drawing.Point(0, 0)
        Me.lblSelectMapInstructions.Name = "lblSelectMapInstructions"
        Me.lblSelectMapInstructions.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSelectMapInstructions.Size = New System.Drawing.Size(242, 23)
        Me.lblSelectMapInstructions.TabIndex = 0
        Me.lblSelectMapInstructions.Text = "Select which map services to add to this region:"
        '
        'pnlMetadata
        '
        Me.pnlMetadata.Controls.Add(Me.GroupBox1)
        Me.pnlMetadata.Controls.Add(Me.GroupBox2)
        Me.pnlMetadata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMetadata.Location = New System.Drawing.Point(0, 0)
        Me.pnlMetadata.Name = "pnlMetadata"
        Me.pnlMetadata.Size = New System.Drawing.Size(520, 256)
        Me.pnlMetadata.TabIndex = 10
        Me.pnlMetadata.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvMeta)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 130)
        Me.GroupBox1.TabIndex = 2
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
        Me.dgvMeta.Size = New System.Drawing.Size(514, 81)
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
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 97)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(514, 30)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'btnRemoveMeta
        '
        Me.btnRemoveMeta.Image = Global.HIS_Config.My.Resources.Resources.btnRemove
        Me.btnRemoveMeta.Location = New System.Drawing.Point(487, 3)
        Me.btnRemoveMeta.Name = "btnRemoveMeta"
        Me.btnRemoveMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnRemoveMeta.TabIndex = 2
        Me.btnRemoveMeta.UseVisualStyleBackColor = True
        '
        'btnEditMeta
        '
        Me.btnEditMeta.Image = Global.HIS_Config.My.Resources.Resources.btnEdit
        Me.btnEditMeta.Location = New System.Drawing.Point(457, 3)
        Me.btnEditMeta.Name = "btnEditMeta"
        Me.btnEditMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnEditMeta.TabIndex = 1
        Me.btnEditMeta.UseVisualStyleBackColor = True
        '
        'btnAddMeta
        '
        Me.btnAddMeta.Image = Global.HIS_Config.My.Resources.Resources.btnAdd
        Me.btnAddMeta.Location = New System.Drawing.Point(427, 3)
        Me.btnAddMeta.Name = "btnAddMeta"
        Me.btnAddMeta.Size = New System.Drawing.Size(24, 24)
        Me.btnAddMeta.TabIndex = 0
        Me.btnAddMeta.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.numNorthExtent)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.numSouthExtent)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.numEastExtent)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.numWestExtent)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 126)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Extents"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "North Extent"
        '
        'numNorthExtent
        '
        Me.numNorthExtent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numNorthExtent.DecimalPlaces = 10
        Me.numNorthExtent.Location = New System.Drawing.Point(86, 19)
        Me.numNorthExtent.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numNorthExtent.Minimum = New Decimal(New Integer() {1000000000, 0, 0, -2147483648})
        Me.numNorthExtent.Name = "numNorthExtent"
        Me.numNorthExtent.Size = New System.Drawing.Size(428, 20)
        Me.numNorthExtent.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "South Extent"
        '
        'numSouthExtent
        '
        Me.numSouthExtent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numSouthExtent.DecimalPlaces = 10
        Me.numSouthExtent.Location = New System.Drawing.Point(86, 45)
        Me.numSouthExtent.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numSouthExtent.Minimum = New Decimal(New Integer() {1000000000, 0, 0, -2147483648})
        Me.numSouthExtent.Name = "numSouthExtent"
        Me.numSouthExtent.Size = New System.Drawing.Size(428, 20)
        Me.numSouthExtent.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "East Extent"
        '
        'numEastExtent
        '
        Me.numEastExtent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numEastExtent.DecimalPlaces = 10
        Me.numEastExtent.Location = New System.Drawing.Point(86, 71)
        Me.numEastExtent.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numEastExtent.Minimum = New Decimal(New Integer() {1000000000, 0, 0, -2147483648})
        Me.numEastExtent.Name = "numEastExtent"
        Me.numEastExtent.Size = New System.Drawing.Size(428, 20)
        Me.numEastExtent.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "West Extent"
        '
        'numWestExtent
        '
        Me.numWestExtent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numWestExtent.DecimalPlaces = 10
        Me.numWestExtent.Location = New System.Drawing.Point(86, 97)
        Me.numWestExtent.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numWestExtent.Minimum = New Decimal(New Integer() {1000000000, 0, 0, -2147483648})
        Me.numWestExtent.Name = "numWestExtent"
        Me.numWestExtent.Size = New System.Drawing.Size(428, 20)
        Me.numWestExtent.TabIndex = 3
        '
        'SelectRegion
        '
        Me.AcceptButton = Me.btnNext
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(520, 285)
        Me.Controls.Add(Me.pnlDefineRegion)
        Me.Controls.Add(Me.pnlSelectMaps)
        Me.Controls.Add(Me.pnlSelectDatabases)
        Me.Controls.Add(Me.pnlMetadata)
        Me.Controls.Add(Me.flpFormNavButtons)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SelectRegion"
        Me.Text = "Add Region"
        Me.flpFormNavButtons.ResumeLayout(False)
        Me.pnlDefineRegion.ResumeLayout(False)
        Me.pnlDefineRegion.PerformLayout()
        Me.pnlData.ResumeLayout(False)
        Me.pnlData.PerformLayout()
        Me.pnlRegionInstructions.ResumeLayout(False)
        Me.pnlRegionInstructions.PerformLayout()
        Me.pnlSelectDatabases.ResumeLayout(False)
        Me.pnlSelectDatabases.PerformLayout()
        Me.tlpDatabases.ResumeLayout(False)
        Me.tlpDatabases.PerformLayout()
        Me.flpDatabaseNavButtons.ResumeLayout(False)
        Me.pnlUsedDatabases.ResumeLayout(False)
        Me.pnlUsedDatabases.PerformLayout()
        Me.flpDatabaseOrderButtons.ResumeLayout(False)
        Me.pnlSelectDatabaseInstructions.ResumeLayout(False)
        Me.pnlSelectDatabaseInstructions.PerformLayout()
        Me.pnlSelectMaps.ResumeLayout(False)
        Me.pnlSelectMaps.PerformLayout()
        Me.tlpMaps.ResumeLayout(False)
        Me.tlpMaps.PerformLayout()
        Me.flpMapNavButtons.ResumeLayout(False)
        Me.pnlUsedMaps.ResumeLayout(False)
        Me.pnlUsedMaps.PerformLayout()
        Me.flpMapOrderButtons.ResumeLayout(False)
        Me.pnlSelectMapInstructions.ResumeLayout(False)
        Me.pnlSelectMapInstructions.PerformLayout()
        Me.pnlMetadata.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numNorthExtent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSouthExtent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numEastExtent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWestExtent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents flpFormNavButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents pnlDefineRegion As System.Windows.Forms.Panel
    Friend WithEvents pnlSelectDatabases As System.Windows.Forms.Panel
    Friend WithEvents pnlSelectMaps As System.Windows.Forms.Panel
    Friend WithEvents tlpDatabases As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flpDatabaseNavButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAddAllDatabases As System.Windows.Forms.Button
    Friend WithEvents btnAddSelectedDatabases As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSelectedDatabases As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAllDatabases As System.Windows.Forms.Button
    Friend WithEvents lstNewDatabases As System.Windows.Forms.ListBox
    Friend WithEvents tlpMaps As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flpMapNavButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAddAllMaps As System.Windows.Forms.Button
    Friend WithEvents btnAddSelectedMaps As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSelectedMaps As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAllMaps As System.Windows.Forms.Button
    Friend WithEvents lstNewMaps As System.Windows.Forms.ListBox
    Friend WithEvents lstUsedMaps As System.Windows.Forms.ListBox
    Friend WithEvents pnlUsedDatabases As System.Windows.Forms.Panel
    Friend WithEvents lstUsedDatabases As System.Windows.Forms.ListBox
    Friend WithEvents flpDatabaseOrderButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnMoveDatabaseUp As System.Windows.Forms.Button
    Friend WithEvents btnMoveDatabaseDown As System.Windows.Forms.Button
    Friend WithEvents pnlUsedMaps As System.Windows.Forms.Panel
    Friend WithEvents flpMapOrderButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnMoveMapUp As System.Windows.Forms.Button
    Friend WithEvents btnMoveMapDown As System.Windows.Forms.Button
    Friend WithEvents pnlSelectDatabaseInstructions As System.Windows.Forms.Panel
    Friend WithEvents lblSelectDatabaseInstructions As System.Windows.Forms.Label
    Friend WithEvents pnlSelectMapInstructions As System.Windows.Forms.Panel
    Friend WithEvents lblSelectMapInstructions As System.Windows.Forms.Label
    Friend WithEvents lblCSS As System.Windows.Forms.Label
    Friend WithEvents txtCSS As System.Windows.Forms.TextBox
    Friend WithEvents lblWebsite As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents pnlData As System.Windows.Forms.Panel
    Friend WithEvents pnlRegionInstructions As System.Windows.Forms.Panel
    Friend WithEvents lblRegionInstructions As System.Windows.Forms.Label
    Friend WithEvents lblDisplayName As System.Windows.Forms.Label
    Friend WithEvents txtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents pnlMetadata As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Protected Friend WithEvents dgvMeta As System.Windows.Forms.DataGridView
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Content As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnRemoveMeta As System.Windows.Forms.Button
    Friend WithEvents btnEditMeta As System.Windows.Forms.Button
    Friend WithEvents btnAddMeta As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numWestExtent As System.Windows.Forms.NumericUpDown
    Friend WithEvents numEastExtent As System.Windows.Forms.NumericUpDown
    Friend WithEvents numSouthExtent As System.Windows.Forms.NumericUpDown
    Friend WithEvents numNorthExtent As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
