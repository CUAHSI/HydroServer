<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnCommit = New System.Windows.Forms.Button
        Me.txtFilePath = New System.Windows.Forms.TextBox
        Me.dgvSites = New System.Windows.Forms.DataGridView
        Me.ofdLoader = New System.Windows.Forms.OpenFileDialog
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblLoadingType = New System.Windows.Forms.Label
        Me.tmrStartCMD = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.tsmiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiFile_Open = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiFile_Sep1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiFile_Exit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.tmrLoadProgress = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label
        CType(Me.dgvSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Location = New System.Drawing.Point(516, 3)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 20)
        Me.btnOpen.TabIndex = 1
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(516, 374)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnCommit.TabIndex = 2
        Me.btnCommit.Text = "Commit File"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilePath.Location = New System.Drawing.Point(3, 3)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.ReadOnly = True
        Me.txtFilePath.Size = New System.Drawing.Size(507, 20)
        Me.txtFilePath.TabIndex = 3
        '
        'dgvSites
        '
        Me.dgvSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSites.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSites.Location = New System.Drawing.Point(6, 29)
        Me.dgvSites.Name = "dgvSites"
        Me.dgvSites.Size = New System.Drawing.Size(585, 339)
        Me.dgvSites.TabIndex = 4
        '
        'ofdLoader
        '
        Me.ofdLoader.Title = "Load a ODM File"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.lblLoadingType)
        Me.Panel1.Controls.Add(Me.btnCommit)
        Me.Panel1.Controls.Add(Me.btnOpen)
        Me.Panel1.Controls.Add(Me.txtFilePath)
        Me.Panel1.Controls.Add(Me.dgvSites)
        Me.Panel1.Location = New System.Drawing.Point(19, 34)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 400)
        Me.Panel1.TabIndex = 5
        '
        'lblLoadingType
        '
        Me.lblLoadingType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLoadingType.AutoSize = True
        Me.lblLoadingType.Location = New System.Drawing.Point(3, 374)
        Me.lblLoadingType.Name = "lblLoadingType"
        Me.lblLoadingType.Size = New System.Drawing.Size(135, 13)
        Me.lblLoadingType.TabIndex = 5
        Me.lblLoadingType.Text = "You are Loading ""Nothing"""
        '
        'tmrStartCMD
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiFile, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmiFile
        '
        Me.tsmiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiFile_Open, Me.tsmiFile_Sep1, Me.tsmiFile_Exit})
        Me.tsmiFile.Name = "tsmiFile"
        Me.tsmiFile.Size = New System.Drawing.Size(37, 20)
        Me.tsmiFile.Text = "File"
        '
        'tsmiFile_Open
        '
        Me.tsmiFile_Open.Name = "tsmiFile_Open"
        Me.tsmiFile_Open.Size = New System.Drawing.Size(103, 22)
        Me.tsmiFile_Open.Text = "Open"
        '
        'tsmiFile_Sep1
        '
        Me.tsmiFile_Sep1.Name = "tsmiFile_Sep1"
        Me.tsmiFile_Sep1.Size = New System.Drawing.Size(100, 6)
        '
        'tsmiFile_Exit
        '
        Me.tsmiFile_Exit.Name = "tsmiFile_Exit"
        Me.tsmiFile_Exit.Size = New System.Drawing.Size(103, 22)
        Me.tsmiFile_Exit.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        Me.ToolsToolStripMenuItem.Visible = False
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.OptionsToolStripMenuItem.Text = "Options..."
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
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=JUSTINB\SQLEXPRESS;Initial Catalog=OD_1_1;Integrated Security=True;Mu" & _
            "ltipleActiveResultSets=True;Connect Timeout=30;Encrypt=False"
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'tmrLoadProgress
        '
        Me.tmrLoadProgress.Interval = 125
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(22, 431)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 6
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "COMIDA ODM Data Loader"
        CType(Me.dgvSites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnCommit As System.Windows.Forms.Button
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents dgvSites As System.Windows.Forms.DataGridView
    Friend WithEvents ofdLoader As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLoadingType As System.Windows.Forms.Label
    Friend WithEvents tmrStartCMD As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiFile_Open As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiFile_Sep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiFile_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents tmrLoadProgress As System.Windows.Forms.Timer
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStatus As System.Windows.Forms.Label

End Class
