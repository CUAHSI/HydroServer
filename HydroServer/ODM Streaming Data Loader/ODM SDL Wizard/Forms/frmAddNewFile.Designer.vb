<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddNewFile
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
        Me.pnlNewFile = New System.Windows.Forms.Panel
        Me.grpNFLocation = New System.Windows.Forms.GroupBox
        Me.rdoNFLocal = New System.Windows.Forms.RadioButton
        Me.txtNFLocal = New System.Windows.Forms.TextBox
        Me.btnNFBrowse = New System.Windows.Forms.Button
        Me.rdoNFWeb = New System.Windows.Forms.RadioButton
        Me.txtNFWeb = New System.Windows.Forms.TextBox
        Me.lblDelimiter = New System.Windows.Forms.Label
        Me.cboDelimiter = New System.Windows.Forms.ComboBox
        Me.lblNFSchedPeriod = New System.Windows.Forms.Label
        Me.numNFSchedPeriod = New System.Windows.Forms.NumericUpDown
        Me.cboNFSchedPeriod = New System.Windows.Forms.ComboBox
        Me.txtNFSchedDate = New System.Windows.Forms.Label
        Me.dtpNFDate = New System.Windows.Forms.DateTimePicker
        Me.lblNFSchedTime = New System.Windows.Forms.Label
        Me.dtpNFTime = New System.Windows.Forms.DateTimePicker
        Me.ucdbConnect = New ODMSDLConfigWiz.ucDBConnection
        Me.lblNFHeaderRow = New System.Windows.Forms.Label
        Me.numNFHeaderRow = New System.Windows.Forms.NumericUpDown
        Me.lnlNone = New System.Windows.Forms.Label
        Me.lblNFDataRow = New System.Windows.Forms.Label
        Me.numNFDataRow = New System.Windows.Forms.NumericUpDown
        Me.chbOldData = New System.Windows.Forms.CheckBox
        Me.pnlSetMapping = New System.Windows.Forms.Panel
        Me.dgvSMFile = New System.Windows.Forms.DataGridView
        Me.grpSMTime = New System.Windows.Forms.GroupBox
        Me.rdoSM_UTCDT = New System.Windows.Forms.RadioButton
        Me.cboSM_UTCDT = New System.Windows.Forms.ComboBox
        Me.rdoSM_DT = New System.Windows.Forms.RadioButton
        Me.cboSM_DT = New System.Windows.Forms.ComboBox
        Me.lblTimeZone = New System.Windows.Forms.Label
        Me.cboSM_TimeZone = New System.Windows.Forms.ComboBox
        Me.chbSM_DST = New System.Windows.Forms.CheckBox
        Me.dgvSMSeries = New System.Windows.Forms.DataGridView
        Me.Identity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValueColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSite = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Variable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OffsetType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OffsetValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Method = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Source = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QCL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FileBOR = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DBBOR = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.POR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSMAdd = New System.Windows.Forms.Button
        Me.btnSMEdit = New System.Windows.Forms.Button
        Me.btnSMRemove = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnFinish = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.ofdLocalFile = New System.Windows.Forms.OpenFileDialog
        Me.pnlNewFile.SuspendLayout()
        Me.grpNFLocation.SuspendLayout()
        CType(Me.numNFSchedPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNFHeaderRow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNFDataRow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSetMapping.SuspendLayout()
        CType(Me.dgvSMFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSMTime.SuspendLayout()
        CType(Me.dgvSMSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlNewFile
        '
        Me.pnlNewFile.Controls.Add(Me.grpNFLocation)
        Me.pnlNewFile.Controls.Add(Me.lblDelimiter)
        Me.pnlNewFile.Controls.Add(Me.cboDelimiter)
        Me.pnlNewFile.Controls.Add(Me.lblNFSchedPeriod)
        Me.pnlNewFile.Controls.Add(Me.numNFSchedPeriod)
        Me.pnlNewFile.Controls.Add(Me.cboNFSchedPeriod)
        Me.pnlNewFile.Controls.Add(Me.txtNFSchedDate)
        Me.pnlNewFile.Controls.Add(Me.dtpNFDate)
        Me.pnlNewFile.Controls.Add(Me.lblNFSchedTime)
        Me.pnlNewFile.Controls.Add(Me.dtpNFTime)
        Me.pnlNewFile.Controls.Add(Me.ucdbConnect)
        Me.pnlNewFile.Controls.Add(Me.lblNFHeaderRow)
        Me.pnlNewFile.Controls.Add(Me.numNFHeaderRow)
        Me.pnlNewFile.Controls.Add(Me.lnlNone)
        Me.pnlNewFile.Controls.Add(Me.lblNFDataRow)
        Me.pnlNewFile.Controls.Add(Me.numNFDataRow)
        Me.pnlNewFile.Controls.Add(Me.chbOldData)
        Me.pnlNewFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNewFile.Location = New System.Drawing.Point(0, 0)
        Me.pnlNewFile.Name = "pnlNewFile"
        Me.pnlNewFile.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlNewFile.Size = New System.Drawing.Size(692, 442)
        Me.pnlNewFile.TabIndex = 2
        '
        'grpNFLocation
        '
        Me.grpNFLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNFLocation.Controls.Add(Me.rdoNFLocal)
        Me.grpNFLocation.Controls.Add(Me.txtNFLocal)
        Me.grpNFLocation.Controls.Add(Me.btnNFBrowse)
        Me.grpNFLocation.Controls.Add(Me.rdoNFWeb)
        Me.grpNFLocation.Controls.Add(Me.txtNFWeb)
        Me.grpNFLocation.Location = New System.Drawing.Point(6, 12)
        Me.grpNFLocation.Name = "grpNFLocation"
        Me.grpNFLocation.Size = New System.Drawing.Size(680, 72)
        Me.grpNFLocation.TabIndex = 0
        Me.grpNFLocation.TabStop = False
        Me.grpNFLocation.Text = "Location"
        '
        'rdoNFLocal
        '
        Me.rdoNFLocal.Checked = True
        Me.rdoNFLocal.Location = New System.Drawing.Point(6, 18)
        Me.rdoNFLocal.Name = "rdoNFLocal"
        Me.rdoNFLocal.Size = New System.Drawing.Size(70, 20)
        Me.rdoNFLocal.TabIndex = 0
        Me.rdoNFLocal.TabStop = True
        Me.rdoNFLocal.Text = "Local File"
        Me.rdoNFLocal.UseVisualStyleBackColor = True
        '
        'txtNFLocal
        '
        Me.txtNFLocal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNFLocal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtNFLocal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtNFLocal.Location = New System.Drawing.Point(79, 19)
        Me.txtNFLocal.Name = "txtNFLocal"
        Me.txtNFLocal.Size = New System.Drawing.Size(565, 20)
        Me.txtNFLocal.TabIndex = 1
        '
        'btnNFBrowse
        '
        Me.btnNFBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNFBrowse.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNFBrowse.Location = New System.Drawing.Point(650, 19)
        Me.btnNFBrowse.Name = "btnNFBrowse"
        Me.btnNFBrowse.Size = New System.Drawing.Size(24, 20)
        Me.btnNFBrowse.TabIndex = 2
        Me.btnNFBrowse.Text = "..."
        Me.btnNFBrowse.UseVisualStyleBackColor = True
        '
        'rdoNFWeb
        '
        Me.rdoNFWeb.Location = New System.Drawing.Point(6, 44)
        Me.rdoNFWeb.Name = "rdoNFWeb"
        Me.rdoNFWeb.Size = New System.Drawing.Size(70, 20)
        Me.rdoNFWeb.TabIndex = 3
        Me.rdoNFWeb.Text = "Website"
        Me.rdoNFWeb.UseVisualStyleBackColor = True
        '
        'txtNFWeb
        '
        Me.txtNFWeb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNFWeb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtNFWeb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl
        Me.txtNFWeb.Enabled = False
        Me.txtNFWeb.Location = New System.Drawing.Point(79, 45)
        Me.txtNFWeb.Name = "txtNFWeb"
        Me.txtNFWeb.Size = New System.Drawing.Size(595, 20)
        Me.txtNFWeb.TabIndex = 4
        '
        'lblDelimiter
        '
        Me.lblDelimiter.AutoSize = True
        Me.lblDelimiter.Location = New System.Drawing.Point(13, 93)
        Me.lblDelimiter.Name = "lblDelimiter"
        Me.lblDelimiter.Size = New System.Drawing.Size(50, 13)
        Me.lblDelimiter.TabIndex = 1
        Me.lblDelimiter.Text = "Delimiter:"
        '
        'cboDelimiter
        '
        Me.cboDelimiter.FormattingEnabled = True
        Me.cboDelimiter.Items.AddRange(New Object() {"<Comma Delimited>", "<Tab Delimited>"})
        Me.cboDelimiter.Location = New System.Drawing.Point(79, 90)
        Me.cboDelimiter.Name = "cboDelimiter"
        Me.cboDelimiter.Size = New System.Drawing.Size(121, 21)
        Me.cboDelimiter.TabIndex = 2
        Me.cboDelimiter.Text = "<Comma Delimited>"
        '
        'lblNFSchedPeriod
        '
        Me.lblNFSchedPeriod.AutoSize = True
        Me.lblNFSchedPeriod.Location = New System.Drawing.Point(13, 119)
        Me.lblNFSchedPeriod.Name = "lblNFSchedPeriod"
        Me.lblNFSchedPeriod.Size = New System.Drawing.Size(60, 13)
        Me.lblNFSchedPeriod.TabIndex = 3
        Me.lblNFSchedPeriod.Text = "Run Every:"
        '
        'numNFSchedPeriod
        '
        Me.numNFSchedPeriod.Location = New System.Drawing.Point(79, 117)
        Me.numNFSchedPeriod.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numNFSchedPeriod.Name = "numNFSchedPeriod"
        Me.numNFSchedPeriod.Size = New System.Drawing.Size(93, 20)
        Me.numNFSchedPeriod.TabIndex = 4
        Me.numNFSchedPeriod.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboNFSchedPeriod
        '
        Me.cboNFSchedPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNFSchedPeriod.FormattingEnabled = True
        Me.cboNFSchedPeriod.Items.AddRange(New Object() {"minutes", "hours", "days", "months", "years"})
        Me.cboNFSchedPeriod.Location = New System.Drawing.Point(178, 116)
        Me.cboNFSchedPeriod.MaxDropDownItems = 5
        Me.cboNFSchedPeriod.Name = "cboNFSchedPeriod"
        Me.cboNFSchedPeriod.Size = New System.Drawing.Size(121, 21)
        Me.cboNFSchedPeriod.TabIndex = 5
        '
        'txtNFSchedDate
        '
        Me.txtNFSchedDate.AutoSize = True
        Me.txtNFSchedDate.Location = New System.Drawing.Point(13, 147)
        Me.txtNFSchedDate.Name = "txtNFSchedDate"
        Me.txtNFSchedDate.Size = New System.Drawing.Size(32, 13)
        Me.txtNFSchedDate.TabIndex = 6
        Me.txtNFSchedDate.Text = "Start:"
        '
        'dtpNFDate
        '
        Me.dtpNFDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNFDate.Location = New System.Drawing.Point(79, 143)
        Me.dtpNFDate.Name = "dtpNFDate"
        Me.dtpNFDate.Size = New System.Drawing.Size(93, 20)
        Me.dtpNFDate.TabIndex = 7
        Me.dtpNFDate.Value = New Date(2007, 1, 1, 0, 0, 0, 0)
        '
        'lblNFSchedTime
        '
        Me.lblNFSchedTime.AutoSize = True
        Me.lblNFSchedTime.Location = New System.Drawing.Point(178, 147)
        Me.lblNFSchedTime.Name = "lblNFSchedTime"
        Me.lblNFSchedTime.Size = New System.Drawing.Size(18, 13)
        Me.lblNFSchedTime.TabIndex = 8
        Me.lblNFSchedTime.Text = "@"
        '
        'dtpNFTime
        '
        Me.dtpNFTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpNFTime.Location = New System.Drawing.Point(202, 143)
        Me.dtpNFTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpNFTime.Name = "dtpNFTime"
        Me.dtpNFTime.ShowUpDown = True
        Me.dtpNFTime.Size = New System.Drawing.Size(97, 20)
        Me.dtpNFTime.TabIndex = 9
        Me.dtpNFTime.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'ucdbConnect
        '
        Me.ucdbConnect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucdbConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucdbConnect.GetDBSetttings = Nothing
        Me.ucdbConnect.Location = New System.Drawing.Point(16, 171)
        Me.ucdbConnect.Margin = New System.Windows.Forms.Padding(5)
        Me.ucdbConnect.Name = "ucdbConnect"
        Me.ucdbConnect.Size = New System.Drawing.Size(677, 146)
        Me.ucdbConnect.TabIndex = 10
        '
        'lblNFHeaderRow
        '
        Me.lblNFHeaderRow.AutoSize = True
        Me.lblNFHeaderRow.Location = New System.Drawing.Point(13, 327)
        Me.lblNFHeaderRow.Name = "lblNFHeaderRow"
        Me.lblNFHeaderRow.Size = New System.Drawing.Size(135, 13)
        Me.lblNFHeaderRow.TabIndex = 11
        Me.lblNFHeaderRow.Text = "Column Headers on Row #"
        '
        'numNFHeaderRow
        '
        Me.numNFHeaderRow.Location = New System.Drawing.Point(154, 325)
        Me.numNFHeaderRow.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numNFHeaderRow.Name = "numNFHeaderRow"
        Me.numNFHeaderRow.Size = New System.Drawing.Size(145, 20)
        Me.numNFHeaderRow.TabIndex = 12
        '
        'lnlNone
        '
        Me.lnlNone.AutoSize = True
        Me.lnlNone.Location = New System.Drawing.Point(305, 327)
        Me.lnlNone.Name = "lnlNone"
        Me.lnlNone.Size = New System.Drawing.Size(63, 13)
        Me.lnlNone.TabIndex = 13
        Me.lnlNone.Text = "(0 for None)"
        '
        'lblNFDataRow
        '
        Me.lblNFDataRow.AutoSize = True
        Me.lblNFDataRow.Location = New System.Drawing.Point(13, 354)
        Me.lblNFDataRow.Name = "lblNFDataRow"
        Me.lblNFDataRow.Size = New System.Drawing.Size(110, 13)
        Me.lblNFDataRow.TabIndex = 14
        Me.lblNFDataRow.Text = "Data Starts on Row #"
        '
        'numNFDataRow
        '
        Me.numNFDataRow.Location = New System.Drawing.Point(154, 351)
        Me.numNFDataRow.Maximum = New Decimal(New Integer() {1001, 0, 0, 0})
        Me.numNFDataRow.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numNFDataRow.Name = "numNFDataRow"
        Me.numNFDataRow.Size = New System.Drawing.Size(145, 20)
        Me.numNFDataRow.TabIndex = 15
        Me.numNFDataRow.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chbOldData
        '
        Me.chbOldData.AutoSize = True
        Me.chbOldData.Location = New System.Drawing.Point(16, 377)
        Me.chbOldData.Name = "chbOldData"
        Me.chbOldData.Size = New System.Drawing.Size(360, 17)
        Me.chbOldData.TabIndex = 16
        Me.chbOldData.Text = "Include Data previous to Data Values that are already in the Database."
        Me.chbOldData.UseVisualStyleBackColor = True
        '
        'pnlSetMapping
        '
        Me.pnlSetMapping.Controls.Add(Me.dgvSMFile)
        Me.pnlSetMapping.Controls.Add(Me.grpSMTime)
        Me.pnlSetMapping.Controls.Add(Me.dgvSMSeries)
        Me.pnlSetMapping.Controls.Add(Me.btnSMAdd)
        Me.pnlSetMapping.Controls.Add(Me.btnSMEdit)
        Me.pnlSetMapping.Controls.Add(Me.btnSMRemove)
        Me.pnlSetMapping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSetMapping.Location = New System.Drawing.Point(0, 0)
        Me.pnlSetMapping.Name = "pnlSetMapping"
        Me.pnlSetMapping.Size = New System.Drawing.Size(692, 442)
        Me.pnlSetMapping.TabIndex = 0
        Me.pnlSetMapping.Visible = False
        '
        'dgvSMFile
        '
        Me.dgvSMFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSMFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSMFile.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSMFile.Location = New System.Drawing.Point(3, 3)
        Me.dgvSMFile.MultiSelect = False
        Me.dgvSMFile.Name = "dgvSMFile"
        Me.dgvSMFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSMFile.Size = New System.Drawing.Size(686, 322)
        Me.dgvSMFile.TabIndex = 0
        '
        'grpSMTime
        '
        Me.grpSMTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpSMTime.Controls.Add(Me.rdoSM_UTCDT)
        Me.grpSMTime.Controls.Add(Me.cboSM_UTCDT)
        Me.grpSMTime.Controls.Add(Me.rdoSM_DT)
        Me.grpSMTime.Controls.Add(Me.cboSM_DT)
        Me.grpSMTime.Controls.Add(Me.lblTimeZone)
        Me.grpSMTime.Controls.Add(Me.cboSM_TimeZone)
        Me.grpSMTime.Controls.Add(Me.chbSM_DST)
        Me.grpSMTime.Location = New System.Drawing.Point(3, 331)
        Me.grpSMTime.Name = "grpSMTime"
        Me.grpSMTime.Size = New System.Drawing.Size(230, 108)
        Me.grpSMTime.TabIndex = 1
        Me.grpSMTime.TabStop = False
        Me.grpSMTime.Text = "Time (must select one option)"
        '
        'rdoSM_UTCDT
        '
        Me.rdoSM_UTCDT.Location = New System.Drawing.Point(9, 17)
        Me.rdoSM_UTCDT.Name = "rdoSM_UTCDT"
        Me.rdoSM_UTCDT.Size = New System.Drawing.Size(104, 21)
        Me.rdoSM_UTCDT.TabIndex = 0
        Me.rdoSM_UTCDT.Text = "UTC Date Time"
        Me.rdoSM_UTCDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoSM_UTCDT.UseVisualStyleBackColor = True
        '
        'cboSM_UTCDT
        '
        Me.cboSM_UTCDT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSM_UTCDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSM_UTCDT.Enabled = False
        Me.cboSM_UTCDT.FormattingEnabled = True
        Me.cboSM_UTCDT.Location = New System.Drawing.Point(114, 20)
        Me.cboSM_UTCDT.Name = "cboSM_UTCDT"
        Me.cboSM_UTCDT.Size = New System.Drawing.Size(110, 21)
        Me.cboSM_UTCDT.TabIndex = 1
        '
        'rdoSM_DT
        '
        Me.rdoSM_DT.Location = New System.Drawing.Point(9, 44)
        Me.rdoSM_DT.Name = "rdoSM_DT"
        Me.rdoSM_DT.Size = New System.Drawing.Size(104, 21)
        Me.rdoSM_DT.TabIndex = 2
        Me.rdoSM_DT.Text = "Local Date Time"
        Me.rdoSM_DT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoSM_DT.UseVisualStyleBackColor = True
        '
        'cboSM_DT
        '
        Me.cboSM_DT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSM_DT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSM_DT.Enabled = False
        Me.cboSM_DT.FormattingEnabled = True
        Me.cboSM_DT.Location = New System.Drawing.Point(113, 44)
        Me.cboSM_DT.Name = "cboSM_DT"
        Me.cboSM_DT.Size = New System.Drawing.Size(110, 21)
        Me.cboSM_DT.TabIndex = 3
        '
        'lblTimeZone
        '
        Me.lblTimeZone.Location = New System.Drawing.Point(6, 71)
        Me.lblTimeZone.Name = "lblTimeZone"
        Me.lblTimeZone.Size = New System.Drawing.Size(107, 21)
        Me.lblTimeZone.TabIndex = 4
        Me.lblTimeZone.Text = "Time Zone"
        Me.lblTimeZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSM_TimeZone
        '
        Me.cboSM_TimeZone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSM_TimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSM_TimeZone.Enabled = False
        Me.cboSM_TimeZone.FormattingEnabled = True
        Me.cboSM_TimeZone.Items.AddRange(New Object() {"+14", "+13", "+12", "+11", "+10", "+9", "+8", "+7", "+6", "+5", "+4", "+3", "+2", "+1", "0", "-1", "-2", "-3", "-4", "-5", "-6", "-7", "-8", "-9", "-10", "-11", "-12"})
        Me.cboSM_TimeZone.Location = New System.Drawing.Point(113, 72)
        Me.cboSM_TimeZone.Name = "cboSM_TimeZone"
        Me.cboSM_TimeZone.Size = New System.Drawing.Size(55, 21)
        Me.cboSM_TimeZone.TabIndex = 5
        '
        'chbSM_DST
        '
        Me.chbSM_DST.AutoSize = True
        Me.chbSM_DST.Location = New System.Drawing.Point(174, 74)
        Me.chbSM_DST.Name = "chbSM_DST"
        Me.chbSM_DST.Size = New System.Drawing.Size(48, 17)
        Me.chbSM_DST.TabIndex = 6
        Me.chbSM_DST.Text = "DST"
        Me.chbSM_DST.UseVisualStyleBackColor = True
        '
        'dgvSMSeries
        '
        Me.dgvSMSeries.AllowUserToAddRows = False
        Me.dgvSMSeries.AllowUserToDeleteRows = False
        Me.dgvSMSeries.AllowUserToResizeRows = False
        Me.dgvSMSeries.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSMSeries.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSMSeries.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvSMSeries.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgvSMSeries.ColumnHeadersHeight = 20
        Me.dgvSMSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSMSeries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Identity, Me.ValueColumn, Me.colSite, Me.Variable, Me.OffsetType, Me.OffsetValue, Me.Method, Me.Source, Me.QCL, Me.FileBOR, Me.DBBOR, Me.POR})
        Me.dgvSMSeries.Location = New System.Drawing.Point(239, 331)
        Me.dgvSMSeries.Name = "dgvSMSeries"
        Me.dgvSMSeries.ReadOnly = True
        Me.dgvSMSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSMSeries.ShowCellErrors = False
        Me.dgvSMSeries.ShowCellToolTips = False
        Me.dgvSMSeries.ShowEditingIcon = False
        Me.dgvSMSeries.ShowRowErrors = False
        Me.dgvSMSeries.Size = New System.Drawing.Size(412, 108)
        Me.dgvSMSeries.TabIndex = 2
        '
        'Identity
        '
        Me.Identity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Identity.Frozen = True
        Me.Identity.HeaderText = " "
        Me.Identity.Name = "Identity"
        Me.Identity.ReadOnly = True
        Me.Identity.Visible = False
        Me.Identity.Width = 35
        '
        'ValueColumn
        '
        Me.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ValueColumn.Frozen = True
        Me.ValueColumn.HeaderText = "Value Column"
        Me.ValueColumn.Name = "ValueColumn"
        Me.ValueColumn.ReadOnly = True
        Me.ValueColumn.Width = 97
        '
        'colSite
        '
        Me.colSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSite.Frozen = True
        Me.colSite.HeaderText = "Site"
        Me.colSite.Name = "colSite"
        Me.colSite.ReadOnly = True
        Me.colSite.Width = 50
        '
        'Variable
        '
        Me.Variable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Variable.Frozen = True
        Me.Variable.HeaderText = "Variable"
        Me.Variable.Name = "Variable"
        Me.Variable.ReadOnly = True
        Me.Variable.Width = 70
        '
        'OffsetType
        '
        Me.OffsetType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OffsetType.Frozen = True
        Me.OffsetType.HeaderText = "Offset Type"
        Me.OffsetType.Name = "OffsetType"
        Me.OffsetType.ReadOnly = True
        Me.OffsetType.Width = 87
        '
        'OffsetValue
        '
        Me.OffsetValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OffsetValue.Frozen = True
        Me.OffsetValue.HeaderText = "Offset Value"
        Me.OffsetValue.Name = "OffsetValue"
        Me.OffsetValue.ReadOnly = True
        Me.OffsetValue.Width = 90
        '
        'Method
        '
        Me.Method.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Method.Frozen = True
        Me.Method.HeaderText = "Method"
        Me.Method.Name = "Method"
        Me.Method.ReadOnly = True
        Me.Method.Width = 68
        '
        'Source
        '
        Me.Source.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Source.Frozen = True
        Me.Source.HeaderText = "Source"
        Me.Source.Name = "Source"
        Me.Source.ReadOnly = True
        Me.Source.Width = 66
        '
        'QCL
        '
        Me.QCL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.QCL.Frozen = True
        Me.QCL.HeaderText = "Quality Control Level"
        Me.QCL.Name = "QCL"
        Me.QCL.ReadOnly = True
        Me.QCL.Width = 129
        '
        'FileBOR
        '
        Me.FileBOR.Frozen = True
        Me.FileBOR.HeaderText = "File BOR"
        Me.FileBOR.Name = "FileBOR"
        Me.FileBOR.ReadOnly = True
        '
        'DBBOR
        '
        Me.DBBOR.Frozen = True
        Me.DBBOR.HeaderText = "Database BOR"
        Me.DBBOR.Name = "DBBOR"
        Me.DBBOR.ReadOnly = True
        '
        'POR
        '
        Me.POR.Frozen = True
        Me.POR.HeaderText = "Period of Record"
        Me.POR.Name = "POR"
        Me.POR.ReadOnly = True
        '
        'btnSMAdd
        '
        Me.btnSMAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSMAdd.Image = Global.ODMSDLConfigWiz.My.Resources.Resources.btnAdd
        Me.btnSMAdd.Location = New System.Drawing.Point(657, 331)
        Me.btnSMAdd.Name = "btnSMAdd"
        Me.btnSMAdd.Size = New System.Drawing.Size(32, 32)
        Me.btnSMAdd.TabIndex = 3
        Me.btnSMAdd.UseVisualStyleBackColor = True
        '
        'btnSMEdit
        '
        Me.btnSMEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSMEdit.Enabled = False
        Me.btnSMEdit.Image = Global.ODMSDLConfigWiz.My.Resources.Resources.btnEdit
        Me.btnSMEdit.Location = New System.Drawing.Point(657, 369)
        Me.btnSMEdit.Name = "btnSMEdit"
        Me.btnSMEdit.Size = New System.Drawing.Size(32, 32)
        Me.btnSMEdit.TabIndex = 4
        Me.btnSMEdit.UseVisualStyleBackColor = True
        '
        'btnSMRemove
        '
        Me.btnSMRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSMRemove.Enabled = False
        Me.btnSMRemove.Image = Global.ODMSDLConfigWiz.My.Resources.Resources.btnRemove
        Me.btnSMRemove.Location = New System.Drawing.Point(657, 407)
        Me.btnSMRemove.Name = "btnSMRemove"
        Me.btnSMRemove.Size = New System.Drawing.Size(32, 32)
        Me.btnSMRemove.TabIndex = 5
        Me.btnSMRemove.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(271, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 25)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnFinish
        '
        Me.btnFinish.Location = New System.Drawing.Point(589, 3)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(100, 25)
        Me.btnFinish.TabIndex = 0
        Me.btnFinish.Text = "Finish"
        Me.btnFinish.UseVisualStyleBackColor = True
        Me.btnFinish.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(483, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(100, 25)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(377, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 25)
        Me.btnBack.TabIndex = 2
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        Me.btnBack.Visible = False
        '
        'flpButtons
        '
        Me.flpButtons.AutoSize = True
        Me.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpButtons.Controls.Add(Me.btnFinish)
        Me.flpButtons.Controls.Add(Me.btnNext)
        Me.flpButtons.Controls.Add(Me.btnBack)
        Me.flpButtons.Controls.Add(Me.btnCancel)
        Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpButtons.Location = New System.Drawing.Point(0, 442)
        Me.flpButtons.Name = "flpButtons"
        Me.flpButtons.Size = New System.Drawing.Size(692, 31)
        Me.flpButtons.TabIndex = 1
        '
        'ofdLocalFile
        '
        Me.ofdLocalFile.AddExtension = False
        Me.ofdLocalFile.DefaultExt = "csv"
        Me.ofdLocalFile.Filter = "Data Files|*.txt; *.dat; *.csv|All Files|*.*"
        Me.ofdLocalFile.RestoreDirectory = True
        Me.ofdLocalFile.Title = "Locate File"
        '
        'frmAddNewFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(692, 473)
        Me.Controls.Add(Me.pnlNewFile)
        Me.Controls.Add(Me.pnlSetMapping)
        Me.Controls.Add(Me.flpButtons)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 450)
        Me.Name = "frmAddNewFile"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New File"
        Me.pnlNewFile.ResumeLayout(False)
        Me.pnlNewFile.PerformLayout()
        Me.grpNFLocation.ResumeLayout(False)
        Me.grpNFLocation.PerformLayout()
        CType(Me.numNFSchedPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNFHeaderRow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNFDataRow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSetMapping.ResumeLayout(False)
        CType(Me.dgvSMFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSMTime.ResumeLayout(False)
        Me.grpSMTime.PerformLayout()
        CType(Me.dgvSMSeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlNewFile As System.Windows.Forms.Panel
    Friend WithEvents lblNFSchedTime As System.Windows.Forms.Label
    Friend WithEvents dtpNFDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpNFTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNFSchedDate As System.Windows.Forms.Label
    Friend WithEvents numNFSchedPeriod As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboNFSchedPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents lblNFSchedPeriod As System.Windows.Forms.Label
    Friend WithEvents grpNFLocation As System.Windows.Forms.GroupBox
    Friend WithEvents txtNFWeb As System.Windows.Forms.TextBox
    Friend WithEvents txtNFLocal As System.Windows.Forms.TextBox
    Friend WithEvents btnNFBrowse As System.Windows.Forms.Button
    Friend WithEvents rdoNFWeb As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNFLocal As System.Windows.Forms.RadioButton
    Friend WithEvents pnlSetMapping As System.Windows.Forms.Panel
    Friend WithEvents grpSMTime As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSMFile As System.Windows.Forms.DataGridView
    Friend WithEvents cboSM_DT As System.Windows.Forms.ComboBox
    Friend WithEvents btnSMRemove As System.Windows.Forms.Button
    Friend WithEvents btnSMEdit As System.Windows.Forms.Button
    Friend WithEvents btnSMAdd As System.Windows.Forms.Button
    Friend WithEvents cboSM_TimeZone As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents flpButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ofdLocalFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ucdbConnect As ODMSDLConfigWiz.ucDBConnection
    Friend WithEvents numNFDataRow As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblNFDataRow As System.Windows.Forms.Label
    Friend WithEvents numNFHeaderRow As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblNFHeaderRow As System.Windows.Forms.Label
    Friend WithEvents lnlNone As System.Windows.Forms.Label
    Friend WithEvents chbSM_DST As System.Windows.Forms.CheckBox
    Friend WithEvents cboSM_UTCDT As System.Windows.Forms.ComboBox
    Friend WithEvents lblTimeZone As System.Windows.Forms.Label
    Friend WithEvents rdoSM_UTCDT As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSM_DT As System.Windows.Forms.RadioButton
    Friend WithEvents chbOldData As System.Windows.Forms.CheckBox
    Friend WithEvents dgvSMSeries As System.Windows.Forms.DataGridView
    Friend WithEvents cboDelimiter As System.Windows.Forms.ComboBox
    Friend WithEvents lblDelimiter As System.Windows.Forms.Label
    Friend WithEvents Identity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValueColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OffsetType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OffsetValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Method As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Source As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileBOR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DBBOR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents POR As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
