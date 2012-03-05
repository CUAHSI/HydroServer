<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWizard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWizard))
        Me.txtFilePath = New System.Windows.Forms.TextBox
        Me.lblFileCap = New System.Windows.Forms.Label
        Me.btnFileBrowse = New System.Windows.Forms.Button
        Me.btnBatBrowse = New System.Windows.Forms.Button
        Me.lblBatCaption = New System.Windows.Forms.Label
        Me.pnlFilePath = New System.Windows.Forms.Panel
        Me.lblFileType = New System.Windows.Forms.Label
        Me.btnFilePreview = New System.Windows.Forms.Button
        Me.dgvFileView = New System.Windows.Forms.DataGridView
        Me.txtBatPath = New System.Windows.Forms.TextBox
        Me.pnlLinkPath = New System.Windows.Forms.Panel
        Me.btnLinkPreview = New System.Windows.Forms.Button
        Me.dgvLinkView = New System.Windows.Forms.DataGridView
        Me.grpLinkLoad = New System.Windows.Forms.GroupBox
        Me.txtLinkPath = New System.Windows.Forms.TextBox
        Me.lblLinkCap = New System.Windows.Forms.Label
        Me.rdoNoLoad = New System.Windows.Forms.RadioButton
        Me.btnLinkBrowse = New System.Windows.Forms.Button
        Me.rdoYesLoad = New System.Windows.Forms.RadioButton
        Me.flpNavigation = New System.Windows.Forms.FlowLayoutPanel
        Me.btnFinish = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.pnlDone = New System.Windows.Forms.Panel
        Me.grpDoneRun = New System.Windows.Forms.GroupBox
        Me.flpDoneRun = New System.Windows.Forms.FlowLayoutPanel
        Me.rdoYesRun = New System.Windows.Forms.RadioButton
        Me.rdoNoRun = New System.Windows.Forms.RadioButton
        Me.lblDoneCap = New System.Windows.Forms.Label
        Me.sfdSaveBat = New System.Windows.Forms.SaveFileDialog
        Me.ofdLoadDataFiles = New System.Windows.Forms.OpenFileDialog
        Me.pnlBatch = New System.Windows.Forms.Panel
        Me.txtLogPath = New System.Windows.Forms.TextBox
        Me.lblLogCap = New System.Windows.Forms.Label
        Me.btnLogBrowse = New System.Windows.Forms.Button
        Me.ucConnect = New Simple_Wizard.ucDBConnection
        Me.sfdSaveLog = New System.Windows.Forms.SaveFileDialog
        Me.FilePreview = New System.ComponentModel.BackgroundWorker
        Me.pnlFilePath.SuspendLayout()
        CType(Me.dgvFileView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLinkPath.SuspendLayout()
        CType(Me.dgvLinkView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpLinkLoad.SuspendLayout()
        Me.flpNavigation.SuspendLayout()
        Me.pnlDone.SuspendLayout()
        Me.grpDoneRun.SuspendLayout()
        Me.flpDoneRun.SuspendLayout()
        Me.pnlBatch.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFilePath
        '
        Me.txtFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        '        Me.txtFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtFilePath.Location = New System.Drawing.Point(13, 29)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(264, 20)
        Me.txtFilePath.TabIndex = 1
        '
        'lblFileCap
        '
        Me.lblFileCap.AutoSize = True
        Me.lblFileCap.Location = New System.Drawing.Point(13, 13)
        Me.lblFileCap.Name = "lblFileCap"
        Me.lblFileCap.Size = New System.Drawing.Size(166, 13)
        Me.lblFileCap.TabIndex = 0
        Me.lblFileCap.Text = "Location of your Data Values File:"
        '
        'btnFileBrowse
        '
        Me.btnFileBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFileBrowse.Location = New System.Drawing.Point(283, 29)
        Me.btnFileBrowse.Name = "btnFileBrowse"
        Me.btnFileBrowse.Size = New System.Drawing.Size(60, 20)
        Me.btnFileBrowse.TabIndex = 2
        Me.btnFileBrowse.Text = "Browse"
        Me.btnFileBrowse.UseVisualStyleBackColor = True
        '
        'btnBatBrowse
        '
        Me.btnBatBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBatBrowse.Location = New System.Drawing.Point(319, 26)
        Me.btnBatBrowse.Name = "btnBatBrowse"
        Me.btnBatBrowse.Size = New System.Drawing.Size(60, 20)
        Me.btnBatBrowse.TabIndex = 2
        Me.btnBatBrowse.Text = "Browse"
        Me.btnBatBrowse.UseVisualStyleBackColor = True
        '
        'lblBatCaption
        '
        Me.lblBatCaption.AutoSize = True
        Me.lblBatCaption.Location = New System.Drawing.Point(9, 9)
        Me.lblBatCaption.Name = "lblBatCaption"
        Me.lblBatCaption.Size = New System.Drawing.Size(126, 13)
        Me.lblBatCaption.TabIndex = 0
        Me.lblBatCaption.Text = "Location to save .bat file:"
        '
        'pnlFilePath
        '
        Me.pnlFilePath.AutoScroll = True
        Me.pnlFilePath.Controls.Add(Me.lblFileType)
        Me.pnlFilePath.Controls.Add(Me.btnFilePreview)
        Me.pnlFilePath.Controls.Add(Me.txtFilePath)
        Me.pnlFilePath.Controls.Add(Me.dgvFileView)
        Me.pnlFilePath.Controls.Add(Me.lblFileCap)
        Me.pnlFilePath.Controls.Add(Me.btnFileBrowse)
        Me.pnlFilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFilePath.Location = New System.Drawing.Point(0, 0)
        Me.pnlFilePath.MinimumSize = New System.Drawing.Size(200, 200)
        Me.pnlFilePath.Name = "pnlFilePath"
        Me.pnlFilePath.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlFilePath.Size = New System.Drawing.Size(392, 336)
        Me.pnlFilePath.TabIndex = 1
        Me.pnlFilePath.Visible = False
        '
        'lblFileType
        '
        Me.lblFileType.AutoSize = True
        Me.lblFileType.Location = New System.Drawing.Point(14, 109)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(0, 13)
        Me.lblFileType.TabIndex = 3
        '
        'btnFilePreview
        '
        Me.btnFilePreview.Location = New System.Drawing.Point(13, 128)
        Me.btnFilePreview.Name = "btnFilePreview"
        Me.btnFilePreview.Size = New System.Drawing.Size(174, 23)
        Me.btnFilePreview.TabIndex = 4
        Me.btnFilePreview.Text = "Preview File"
        Me.btnFilePreview.UseVisualStyleBackColor = True
        '
        'dgvFileView
        '
        Me.dgvFileView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFileView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFileView.Location = New System.Drawing.Point(13, 157)
        Me.dgvFileView.Name = "dgvFileView"
        Me.dgvFileView.Size = New System.Drawing.Size(366, 166)
        Me.dgvFileView.TabIndex = 5
        '
        'txtBatPath
        '
        Me.txtBatPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        'Me.txtBatPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        '        Me.txtBatPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtBatPath.Location = New System.Drawing.Point(13, 26)
        Me.txtBatPath.Name = "txtBatPath"
        Me.txtBatPath.Size = New System.Drawing.Size(300, 20)
        Me.txtBatPath.TabIndex = 1
        '
        'pnlLinkPath
        '
        Me.pnlLinkPath.AutoScroll = True
        Me.pnlLinkPath.Controls.Add(Me.btnLinkPreview)
        Me.pnlLinkPath.Controls.Add(Me.dgvLinkView)
        Me.pnlLinkPath.Controls.Add(Me.grpLinkLoad)
        Me.pnlLinkPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLinkPath.Location = New System.Drawing.Point(0, 0)
        Me.pnlLinkPath.MinimumSize = New System.Drawing.Size(200, 200)
        Me.pnlLinkPath.Name = "pnlLinkPath"
        Me.pnlLinkPath.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlLinkPath.Size = New System.Drawing.Size(392, 336)
        Me.pnlLinkPath.TabIndex = 2
        Me.pnlLinkPath.Visible = False
        '
        'btnLinkPreview
        '
        Me.btnLinkPreview.Location = New System.Drawing.Point(13, 128)
        Me.btnLinkPreview.Name = "btnLinkPreview"
        Me.btnLinkPreview.Size = New System.Drawing.Size(174, 23)
        Me.btnLinkPreview.TabIndex = 1
        Me.btnLinkPreview.Text = "Preview File"
        Me.btnLinkPreview.UseVisualStyleBackColor = True
        '
        'dgvLinkView
        '
        Me.dgvLinkView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLinkView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLinkView.Location = New System.Drawing.Point(13, 157)
        Me.dgvLinkView.Name = "dgvLinkView"
        Me.dgvLinkView.Size = New System.Drawing.Size(366, 166)
        Me.dgvLinkView.TabIndex = 2
        '
        'grpLinkLoad
        '
        Me.grpLinkLoad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLinkLoad.Controls.Add(Me.txtLinkPath)
        Me.grpLinkLoad.Controls.Add(Me.lblLinkCap)
        Me.grpLinkLoad.Controls.Add(Me.rdoNoLoad)
        Me.grpLinkLoad.Controls.Add(Me.btnLinkBrowse)
        Me.grpLinkLoad.Controls.Add(Me.rdoYesLoad)
        Me.grpLinkLoad.Location = New System.Drawing.Point(13, 13)
        Me.grpLinkLoad.Name = "grpLinkLoad"
        Me.grpLinkLoad.Size = New System.Drawing.Size(366, 109)
        Me.grpLinkLoad.TabIndex = 0
        Me.grpLinkLoad.TabStop = False
        Me.grpLinkLoad.Text = "Would you like to Load __ too?"
        '
        'txtLinkPath
        '
        Me.txtLinkPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '        Me.txtLinkPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        '        Me.txtLinkPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtLinkPath.Location = New System.Drawing.Point(6, 42)
        Me.txtLinkPath.Name = "txtLinkPath"
        Me.txtLinkPath.Size = New System.Drawing.Size(288, 20)
        Me.txtLinkPath.TabIndex = 1
        '
        'lblLinkCap
        '
        Me.lblLinkCap.AutoSize = True
        Me.lblLinkCap.Location = New System.Drawing.Point(6, 88)
        Me.lblLinkCap.Name = "lblLinkCap"
        Me.lblLinkCap.Size = New System.Drawing.Size(80, 13)
        Me.lblLinkCap.TabIndex = 4
        Me.lblLinkCap.Text = "Not Loading __"
        Me.lblLinkCap.Visible = False
        '
        'rdoNoLoad
        '
        Me.rdoNoLoad.AutoSize = True
        Me.rdoNoLoad.Location = New System.Drawing.Point(6, 68)
        Me.rdoNoLoad.Name = "rdoNoLoad"
        Me.rdoNoLoad.Size = New System.Drawing.Size(88, 17)
        Me.rdoNoLoad.TabIndex = 3
        Me.rdoNoLoad.Text = "Don't load __"
        Me.rdoNoLoad.UseVisualStyleBackColor = True
        '
        'btnLinkBrowse
        '
        Me.btnLinkBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLinkBrowse.Location = New System.Drawing.Point(300, 42)
        Me.btnLinkBrowse.Name = "btnLinkBrowse"
        Me.btnLinkBrowse.Size = New System.Drawing.Size(60, 20)
        Me.btnLinkBrowse.TabIndex = 2
        Me.btnLinkBrowse.Text = "Browse"
        Me.btnLinkBrowse.UseVisualStyleBackColor = True
        '
        'rdoYesLoad
        '
        Me.rdoYesLoad.AutoSize = True
        Me.rdoYesLoad.Checked = True
        Me.rdoYesLoad.Location = New System.Drawing.Point(6, 19)
        Me.rdoYesLoad.Name = "rdoYesLoad"
        Me.rdoYesLoad.Size = New System.Drawing.Size(64, 17)
        Me.rdoYesLoad.TabIndex = 0
        Me.rdoYesLoad.TabStop = True
        Me.rdoYesLoad.Text = "Load __"
        Me.rdoYesLoad.UseVisualStyleBackColor = True
        '
        'flpNavigation
        '
        Me.flpNavigation.Controls.Add(Me.btnFinish)
        Me.flpNavigation.Controls.Add(Me.btnNext)
        Me.flpNavigation.Controls.Add(Me.btnBack)
        Me.flpNavigation.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpNavigation.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpNavigation.Location = New System.Drawing.Point(0, 336)
        Me.flpNavigation.Name = "flpNavigation"
        Me.flpNavigation.Size = New System.Drawing.Size(392, 30)
        Me.flpNavigation.TabIndex = 4
        '
        'btnFinish
        '
        Me.btnFinish.Location = New System.Drawing.Point(314, 3)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(75, 25)
        Me.btnFinish.TabIndex = 0
        Me.btnFinish.Text = "&Finish"
        Me.btnFinish.UseVisualStyleBackColor = True
        Me.btnFinish.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(233, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 25)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "&Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBack.Location = New System.Drawing.Point(152, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 25)
        Me.btnBack.TabIndex = 2
        Me.btnBack.Text = "&Back"
        Me.btnBack.UseVisualStyleBackColor = True
        Me.btnBack.Visible = False
        '
        'pnlDone
        '
        Me.pnlDone.AutoScroll = True
        Me.pnlDone.Controls.Add(Me.grpDoneRun)
        Me.pnlDone.Controls.Add(Me.lblDoneCap)
        Me.pnlDone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDone.Location = New System.Drawing.Point(0, 0)
        Me.pnlDone.MinimumSize = New System.Drawing.Size(200, 200)
        Me.pnlDone.Name = "pnlDone"
        Me.pnlDone.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlDone.Size = New System.Drawing.Size(392, 336)
        Me.pnlDone.TabIndex = 3
        Me.pnlDone.Visible = False
        '
        'grpDoneRun
        '
        Me.grpDoneRun.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDoneRun.Controls.Add(Me.flpDoneRun)
        Me.grpDoneRun.Location = New System.Drawing.Point(13, 26)
        Me.grpDoneRun.Name = "grpDoneRun"
        Me.grpDoneRun.Size = New System.Drawing.Size(366, 59)
        Me.grpDoneRun.TabIndex = 1
        Me.grpDoneRun.TabStop = False
        Me.grpDoneRun.Text = "Run the batch file now?"
        '
        'flpDoneRun
        '
        Me.flpDoneRun.AutoScroll = True
        Me.flpDoneRun.Controls.Add(Me.rdoYesRun)
        Me.flpDoneRun.Controls.Add(Me.rdoNoRun)
        Me.flpDoneRun.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpDoneRun.Location = New System.Drawing.Point(3, 16)
        Me.flpDoneRun.Name = "flpDoneRun"
        Me.flpDoneRun.Size = New System.Drawing.Size(360, 40)
        Me.flpDoneRun.TabIndex = 0
        '
        'rdoYesRun
        '
        Me.rdoYesRun.AutoSize = True
        Me.rdoYesRun.Checked = True
        Me.rdoYesRun.Location = New System.Drawing.Point(3, 3)
        Me.rdoYesRun.Name = "rdoYesRun"
        Me.rdoYesRun.Size = New System.Drawing.Size(43, 17)
        Me.rdoYesRun.TabIndex = 0
        Me.rdoYesRun.TabStop = True
        Me.rdoYesRun.Text = "Yes"
        Me.rdoYesRun.UseVisualStyleBackColor = True
        '
        'rdoNoRun
        '
        Me.rdoNoRun.AutoSize = True
        Me.rdoNoRun.Location = New System.Drawing.Point(52, 3)
        Me.rdoNoRun.Name = "rdoNoRun"
        Me.rdoNoRun.Size = New System.Drawing.Size(39, 17)
        Me.rdoNoRun.TabIndex = 1
        Me.rdoNoRun.Text = "No"
        Me.rdoNoRun.UseVisualStyleBackColor = True
        '
        'lblDoneCap
        '
        Me.lblDoneCap.AutoSize = True
        Me.lblDoneCap.Location = New System.Drawing.Point(13, 10)
        Me.lblDoneCap.Name = "lblDoneCap"
        Me.lblDoneCap.Size = New System.Drawing.Size(172, 13)
        Me.lblDoneCap.TabIndex = 0
        Me.lblDoneCap.Text = "Click Finish to create the batch file."
        '
        'sfdSaveBat
        '
        Me.sfdSaveBat.DefaultExt = "bat"
        Me.sfdSaveBat.Filter = "Batch File|*.bat|Text File|*.txt|All File Types| *.*"
        Me.sfdSaveBat.RestoreDirectory = True
        Me.sfdSaveBat.SupportMultiDottedExtensions = True
        Me.sfdSaveBat.Title = "Save Batch File"
        '
        'ofdLoadDataFiles
        '
        Me.ofdLoadDataFiles.DefaultExt = "xls"
        Me.ofdLoadDataFiles.Filter = "Data Files|*.xls;*.csv;*.txt;*.dat|All Files|*.*"
        Me.ofdLoadDataFiles.Multiselect = True
        Me.ofdLoadDataFiles.RestoreDirectory = True
        Me.ofdLoadDataFiles.SupportMultiDottedExtensions = True
        Me.ofdLoadDataFiles.Title = "Open _____"
        '
        'pnlBatch
        '
        Me.pnlBatch.AutoScroll = True
        Me.pnlBatch.Controls.Add(Me.txtLogPath)
        Me.pnlBatch.Controls.Add(Me.lblLogCap)
        Me.pnlBatch.Controls.Add(Me.btnLogBrowse)
        Me.pnlBatch.Controls.Add(Me.ucConnect)
        Me.pnlBatch.Controls.Add(Me.lblBatCaption)
        Me.pnlBatch.Controls.Add(Me.txtBatPath)
        Me.pnlBatch.Controls.Add(Me.btnBatBrowse)
        Me.pnlBatch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBatch.Location = New System.Drawing.Point(0, 0)
        Me.pnlBatch.MinimumSize = New System.Drawing.Size(200, 200)
        Me.pnlBatch.Name = "pnlBatch"
        Me.pnlBatch.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlBatch.Size = New System.Drawing.Size(392, 336)
        Me.pnlBatch.TabIndex = 0
        '
        'txtLogPath
        '
        Me.txtLogPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '        Me.txtLogPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        '        Me.txtLogPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtLogPath.Location = New System.Drawing.Point(12, 68)
        Me.txtLogPath.Name = "txtLogPath"
        Me.txtLogPath.Size = New System.Drawing.Size(300, 20)
        Me.txtLogPath.TabIndex = 4
        '
        'lblLogCap
        '
        Me.lblLogCap.AutoSize = True
        Me.lblLogCap.Location = New System.Drawing.Point(9, 52)
        Me.lblLogCap.Name = "lblLogCap"
        Me.lblLogCap.Size = New System.Drawing.Size(125, 13)
        Me.lblLogCap.TabIndex = 3
        Me.lblLogCap.Text = "Location to write Log file:"
        '
        'btnLogBrowse
        '
        Me.btnLogBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogBrowse.Location = New System.Drawing.Point(318, 68)
        Me.btnLogBrowse.Name = "btnLogBrowse"
        Me.btnLogBrowse.Size = New System.Drawing.Size(60, 20)
        Me.btnLogBrowse.TabIndex = 5
        Me.btnLogBrowse.Text = "Browse"
        Me.btnLogBrowse.UseVisualStyleBackColor = True
        '
        'ucConnect
        '
        Me.ucConnect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucConnect.Location = New System.Drawing.Point(14, 96)
        Me.ucConnect.Margin = New System.Windows.Forms.Padding(5)
        Me.ucConnect.Name = "ucConnect"
        Me.ucConnect.Size = New System.Drawing.Size(364, 131)
        Me.ucConnect.TabIndex = 6
        '
        'sfdSaveLog
        '
        Me.sfdSaveLog.DefaultExt = "txt"
        Me.sfdSaveLog.Filter = "Text File|*.txt|All File Types|*.*"
        Me.sfdSaveLog.RestoreDirectory = True
        Me.sfdSaveLog.SupportMultiDottedExtensions = True
        Me.sfdSaveLog.Title = "Save Log File"
        '
        'FilePreview
        '
        Me.FilePreview.WorkerReportsProgress = True
        '
        'frmWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnBack
        Me.ClientSize = New System.Drawing.Size(392, 366)
        Me.Controls.Add(Me.pnlBatch)
        Me.Controls.Add(Me.pnlFilePath)
        Me.Controls.Add(Me.pnlLinkPath)
        Me.Controls.Add(Me.pnlDone)
        Me.Controls.Add(Me.flpNavigation)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(400, 400)
        Me.Name = "frmWizard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ODM Data Loader 1.1 Wizard"
        Me.pnlFilePath.ResumeLayout(False)
        Me.pnlFilePath.PerformLayout()
        CType(Me.dgvFileView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLinkPath.ResumeLayout(False)
        CType(Me.dgvLinkView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpLinkLoad.ResumeLayout(False)
        Me.grpLinkLoad.PerformLayout()
        Me.flpNavigation.ResumeLayout(False)
        Me.pnlDone.ResumeLayout(False)
        Me.pnlDone.PerformLayout()
        Me.grpDoneRun.ResumeLayout(False)
        Me.flpDoneRun.ResumeLayout(False)
        Me.flpDoneRun.PerformLayout()
        Me.pnlBatch.ResumeLayout(False)
        Me.pnlBatch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBatBrowse As System.Windows.Forms.Button
    Friend WithEvents lblBatCaption As System.Windows.Forms.Label
    Friend WithEvents pnlFilePath As System.Windows.Forms.Panel
    Friend WithEvents pnlLinkPath As System.Windows.Forms.Panel
    Friend WithEvents flpNavigation As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents pnlDone As System.Windows.Forms.Panel
    Friend WithEvents btnFileBrowse As System.Windows.Forms.Button
    Friend WithEvents rdoYesLoad As System.Windows.Forms.RadioButton
    Friend WithEvents btnLinkBrowse As System.Windows.Forms.Button
    Friend WithEvents grpLinkLoad As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNoRun As System.Windows.Forms.RadioButton
    Friend WithEvents rdoYesRun As System.Windows.Forms.RadioButton
    Friend WithEvents lblDoneCap As System.Windows.Forms.Label
    Friend WithEvents grpDoneRun As System.Windows.Forms.GroupBox
    Friend WithEvents flpDoneRun As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblFileCap As System.Windows.Forms.Label
    Friend WithEvents lblLinkCap As System.Windows.Forms.Label
    Friend WithEvents rdoNoLoad As System.Windows.Forms.RadioButton
    Friend WithEvents dgvFileView As System.Windows.Forms.DataGridView
    Friend WithEvents dgvLinkView As System.Windows.Forms.DataGridView
    Friend WithEvents sfdSaveBat As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ofdLoadDataFiles As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents txtBatPath As System.Windows.Forms.TextBox
    Friend WithEvents txtLinkPath As System.Windows.Forms.TextBox
    Friend WithEvents pnlBatch As System.Windows.Forms.Panel
    Friend WithEvents ucConnect As Simple_Wizard.ucDBConnection
    Friend WithEvents sfdSaveLog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnFilePreview As System.Windows.Forms.Button
    Friend WithEvents btnLinkPreview As System.Windows.Forms.Button
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents FilePreview As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtLogPath As System.Windows.Forms.TextBox
    Friend WithEvents lblLogCap As System.Windows.Forms.Label
    Friend WithEvents btnLogBrowse As System.Windows.Forms.Button

End Class
