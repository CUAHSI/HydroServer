<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewSite
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
        Me.txtSiteCode = New System.Windows.Forms.TextBox
        Me.txtSiteName = New System.Windows.Forms.TextBox
        Me.cboLatLongDatum = New System.Windows.Forms.ComboBox
        Me.grpRequired = New System.Windows.Forms.GroupBox
        Me.lblSiteCode = New System.Windows.Forms.Label
        Me.lblSiteName = New System.Windows.Forms.Label
        Me.lblLatitude = New System.Windows.Forms.Label
        Me.txtLatitude = New System.Windows.Forms.TextBox
        Me.lblLongitude = New System.Windows.Forms.Label
        Me.txtLongitude = New System.Windows.Forms.TextBox
        Me.lblLatLongDatum = New System.Windows.Forms.Label
        Me.grpOptional = New System.Windows.Forms.GroupBox
        Me.lblElevation_m = New System.Windows.Forms.Label
        Me.txtElevation_m = New System.Windows.Forms.TextBox
        Me.lblVerticalDatum = New System.Windows.Forms.Label
        Me.cboVerticalDatum = New System.Windows.Forms.ComboBox
        Me.lblLocalX = New System.Windows.Forms.Label
        Me.txtLocalX = New System.Windows.Forms.TextBox
        Me.lblLocalY = New System.Windows.Forms.Label
        Me.txtLocalY = New System.Windows.Forms.TextBox
        Me.lblLocalProjection = New System.Windows.Forms.Label
        Me.cboLocalProjection = New System.Windows.Forms.ComboBox
        Me.lblPosAccuracy = New System.Windows.Forms.Label
        Me.txtPosAccuracy = New System.Windows.Forms.TextBox
        Me.lblState = New System.Windows.Forms.Label
        Me.txtState = New System.Windows.Forms.TextBox
        Me.lblCounty = New System.Windows.Forms.Label
        Me.txtCounty = New System.Windows.Forms.TextBox
        Me.lblComments = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpRequired.SuspendLayout()
        Me.grpOptional.SuspendLayout()
        Me.flpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSiteCode
        '
        Me.txtSiteCode.AcceptsReturn = True
        Me.txtSiteCode.AllowDrop = True
        Me.txtSiteCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSiteCode.Location = New System.Drawing.Point(21, 32)
        Me.txtSiteCode.MaxLength = 50
        Me.txtSiteCode.Multiline = True
        Me.txtSiteCode.Name = "txtSiteCode"
        Me.txtSiteCode.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSiteCode.Size = New System.Drawing.Size(264, 59)
        Me.txtSiteCode.TabIndex = 1
        '
        'txtSiteName
        '
        Me.txtSiteName.AcceptsReturn = True
        Me.txtSiteName.AllowDrop = True
        Me.txtSiteName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSiteName.Location = New System.Drawing.Point(21, 110)
        Me.txtSiteName.MaxLength = 255
        Me.txtSiteName.Multiline = True
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSiteName.Size = New System.Drawing.Size(264, 59)
        Me.txtSiteName.TabIndex = 3
        '
        'cboLatLongDatum
        '
        Me.cboLatLongDatum.CausesValidation = False
        Me.cboLatLongDatum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLatLongDatum.DropDownWidth = 264
        Me.cboLatLongDatum.Location = New System.Drawing.Point(21, 227)
        Me.cboLatLongDatum.MaxDropDownItems = 10
        Me.cboLatLongDatum.Name = "cboLatLongDatum"
        Me.cboLatLongDatum.Size = New System.Drawing.Size(120, 21)
        Me.cboLatLongDatum.TabIndex = 9
        '
        'grpRequired
        '
        Me.grpRequired.Controls.Add(Me.lblSiteCode)
        Me.grpRequired.Controls.Add(Me.txtSiteCode)
        Me.grpRequired.Controls.Add(Me.lblSiteName)
        Me.grpRequired.Controls.Add(Me.txtSiteName)
        Me.grpRequired.Controls.Add(Me.lblLatitude)
        Me.grpRequired.Controls.Add(Me.txtLatitude)
        Me.grpRequired.Controls.Add(Me.lblLongitude)
        Me.grpRequired.Controls.Add(Me.txtLongitude)
        Me.grpRequired.Controls.Add(Me.lblLatLongDatum)
        Me.grpRequired.Controls.Add(Me.cboLatLongDatum)
        Me.grpRequired.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRequired.Location = New System.Drawing.Point(0, 0)
        Me.grpRequired.Name = "grpRequired"
        Me.grpRequired.Size = New System.Drawing.Size(300, 256)
        Me.grpRequired.TabIndex = 0
        Me.grpRequired.TabStop = False
        Me.grpRequired.Text = "Required"
        '
        'lblSiteCode
        '
        Me.lblSiteCode.AutoSize = True
        Me.lblSiteCode.Location = New System.Drawing.Point(6, 16)
        Me.lblSiteCode.Name = "lblSiteCode"
        Me.lblSiteCode.Size = New System.Drawing.Size(53, 13)
        Me.lblSiteCode.TabIndex = 0
        Me.lblSiteCode.Text = "Site Code"
        '
        'lblSiteName
        '
        Me.lblSiteName.AutoSize = True
        Me.lblSiteName.Location = New System.Drawing.Point(6, 94)
        Me.lblSiteName.Name = "lblSiteName"
        Me.lblSiteName.Size = New System.Drawing.Size(56, 13)
        Me.lblSiteName.TabIndex = 2
        Me.lblSiteName.Text = "Site Name"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(6, 172)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 4
        Me.lblLatitude.Text = "Latitude"
        '
        'txtLatitude
        '
        Me.txtLatitude.AllowDrop = True
        Me.txtLatitude.Location = New System.Drawing.Point(21, 188)
        Me.txtLatitude.MaxLength = 100
        Me.txtLatitude.Name = "txtLatitude"
        Me.txtLatitude.Size = New System.Drawing.Size(120, 20)
        Me.txtLatitude.TabIndex = 5
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.Location = New System.Drawing.Point(150, 172)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblLongitude.TabIndex = 6
        Me.lblLongitude.Text = "Longitude"
        '
        'txtLongitude
        '
        Me.txtLongitude.AllowDrop = True
        Me.txtLongitude.Location = New System.Drawing.Point(165, 188)
        Me.txtLongitude.MaxLength = 100
        Me.txtLongitude.Name = "txtLongitude"
        Me.txtLongitude.Size = New System.Drawing.Size(120, 20)
        Me.txtLongitude.TabIndex = 7
        '
        'lblLatLongDatum
        '
        Me.lblLatLongDatum.AutoSize = True
        Me.lblLatLongDatum.Location = New System.Drawing.Point(6, 211)
        Me.lblLatLongDatum.Name = "lblLatLongDatum"
        Me.lblLatLongDatum.Size = New System.Drawing.Size(131, 13)
        Me.lblLatLongDatum.TabIndex = 8
        Me.lblLatLongDatum.Text = "Latitude/Longitude Datum"
        '
        'grpOptional
        '
        Me.grpOptional.Controls.Add(Me.lblElevation_m)
        Me.grpOptional.Controls.Add(Me.txtElevation_m)
        Me.grpOptional.Controls.Add(Me.lblVerticalDatum)
        Me.grpOptional.Controls.Add(Me.cboVerticalDatum)
        Me.grpOptional.Controls.Add(Me.lblLocalX)
        Me.grpOptional.Controls.Add(Me.txtLocalX)
        Me.grpOptional.Controls.Add(Me.lblLocalY)
        Me.grpOptional.Controls.Add(Me.txtLocalY)
        Me.grpOptional.Controls.Add(Me.lblLocalProjection)
        Me.grpOptional.Controls.Add(Me.cboLocalProjection)
        Me.grpOptional.Controls.Add(Me.lblPosAccuracy)
        Me.grpOptional.Controls.Add(Me.txtPosAccuracy)
        Me.grpOptional.Controls.Add(Me.lblState)
        Me.grpOptional.Controls.Add(Me.txtState)
        Me.grpOptional.Controls.Add(Me.lblCounty)
        Me.grpOptional.Controls.Add(Me.txtCounty)
        Me.grpOptional.Controls.Add(Me.lblComments)
        Me.grpOptional.Controls.Add(Me.txtComments)
        Me.grpOptional.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpOptional.Location = New System.Drawing.Point(0, 256)
        Me.grpOptional.Name = "grpOptional"
        Me.grpOptional.Size = New System.Drawing.Size(300, 260)
        Me.grpOptional.TabIndex = 1
        Me.grpOptional.TabStop = False
        Me.grpOptional.Text = "Optional"
        '
        'lblElevation_m
        '
        Me.lblElevation_m.AutoSize = True
        Me.lblElevation_m.Location = New System.Drawing.Point(6, 16)
        Me.lblElevation_m.Name = "lblElevation_m"
        Me.lblElevation_m.Size = New System.Drawing.Size(96, 13)
        Me.lblElevation_m.TabIndex = 0
        Me.lblElevation_m.Text = "Elevation in meters"
        '
        'txtElevation_m
        '
        Me.txtElevation_m.AllowDrop = True
        Me.txtElevation_m.Location = New System.Drawing.Point(21, 33)
        Me.txtElevation_m.MaxLength = 100
        Me.txtElevation_m.Name = "txtElevation_m"
        Me.txtElevation_m.Size = New System.Drawing.Size(120, 20)
        Me.txtElevation_m.TabIndex = 1
        '
        'lblVerticalDatum
        '
        Me.lblVerticalDatum.AutoSize = True
        Me.lblVerticalDatum.Enabled = False
        Me.lblVerticalDatum.Location = New System.Drawing.Point(150, 16)
        Me.lblVerticalDatum.Name = "lblVerticalDatum"
        Me.lblVerticalDatum.Size = New System.Drawing.Size(76, 13)
        Me.lblVerticalDatum.TabIndex = 2
        Me.lblVerticalDatum.Text = "Vertical Datum"
        '
        'cboVerticalDatum
        '
        Me.cboVerticalDatum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVerticalDatum.DropDownWidth = 264
        Me.cboVerticalDatum.Enabled = False
        Me.cboVerticalDatum.FormattingEnabled = True
        Me.cboVerticalDatum.Location = New System.Drawing.Point(165, 32)
        Me.cboVerticalDatum.MaxDropDownItems = 10
        Me.cboVerticalDatum.Name = "cboVerticalDatum"
        Me.cboVerticalDatum.Size = New System.Drawing.Size(120, 21)
        Me.cboVerticalDatum.TabIndex = 3
        '
        'lblLocalX
        '
        Me.lblLocalX.AutoSize = True
        Me.lblLocalX.Location = New System.Drawing.Point(6, 55)
        Me.lblLocalX.Name = "lblLocalX"
        Me.lblLocalX.Size = New System.Drawing.Size(43, 13)
        Me.lblLocalX.TabIndex = 4
        Me.lblLocalX.Text = "Local X"
        '
        'txtLocalX
        '
        Me.txtLocalX.AllowDrop = True
        Me.txtLocalX.Location = New System.Drawing.Point(21, 71)
        Me.txtLocalX.MaxLength = 100
        Me.txtLocalX.Name = "txtLocalX"
        Me.txtLocalX.Size = New System.Drawing.Size(120, 20)
        Me.txtLocalX.TabIndex = 5
        '
        'lblLocalY
        '
        Me.lblLocalY.AutoSize = True
        Me.lblLocalY.Location = New System.Drawing.Point(150, 55)
        Me.lblLocalY.Name = "lblLocalY"
        Me.lblLocalY.Size = New System.Drawing.Size(43, 13)
        Me.lblLocalY.TabIndex = 6
        Me.lblLocalY.Text = "Local Y"
        '
        'txtLocalY
        '
        Me.txtLocalY.AllowDrop = True
        Me.txtLocalY.Location = New System.Drawing.Point(165, 71)
        Me.txtLocalY.MaxLength = 100
        Me.txtLocalY.Name = "txtLocalY"
        Me.txtLocalY.Size = New System.Drawing.Size(120, 20)
        Me.txtLocalY.TabIndex = 7
        '
        'lblLocalProjection
        '
        Me.lblLocalProjection.AutoSize = True
        Me.lblLocalProjection.Enabled = False
        Me.lblLocalProjection.Location = New System.Drawing.Point(6, 94)
        Me.lblLocalProjection.Name = "lblLocalProjection"
        Me.lblLocalProjection.Size = New System.Drawing.Size(117, 13)
        Me.lblLocalProjection.TabIndex = 8
        Me.lblLocalProjection.Text = "Local Projection Datum"
        '
        'cboLocalProjection
        '
        Me.cboLocalProjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocalProjection.DropDownWidth = 264
        Me.cboLocalProjection.Enabled = False
        Me.cboLocalProjection.FormattingEnabled = True
        Me.cboLocalProjection.Location = New System.Drawing.Point(21, 110)
        Me.cboLocalProjection.MaxDropDownItems = 10
        Me.cboLocalProjection.Name = "cboLocalProjection"
        Me.cboLocalProjection.Size = New System.Drawing.Size(120, 21)
        Me.cboLocalProjection.TabIndex = 9
        '
        'lblPosAccuracy
        '
        Me.lblPosAccuracy.AutoSize = True
        Me.lblPosAccuracy.Location = New System.Drawing.Point(150, 94)
        Me.lblPosAccuracy.Name = "lblPosAccuracy"
        Me.lblPosAccuracy.Size = New System.Drawing.Size(145, 13)
        Me.lblPosAccuracy.TabIndex = 10
        Me.lblPosAccuracy.Text = "Positional Accuracy in meters"
        '
        'txtPosAccuracy
        '
        Me.txtPosAccuracy.AllowDrop = True
        Me.txtPosAccuracy.Location = New System.Drawing.Point(165, 110)
        Me.txtPosAccuracy.MaxLength = 100
        Me.txtPosAccuracy.Name = "txtPosAccuracy"
        Me.txtPosAccuracy.Size = New System.Drawing.Size(120, 20)
        Me.txtPosAccuracy.TabIndex = 11
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(6, 134)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(32, 13)
        Me.lblState.TabIndex = 12
        Me.lblState.Text = "State"
        '
        'txtState
        '
        Me.txtState.AllowDrop = True
        Me.txtState.Location = New System.Drawing.Point(21, 150)
        Me.txtState.MaxLength = 255
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(120, 20)
        Me.txtState.TabIndex = 13
        '
        'lblCounty
        '
        Me.lblCounty.AutoSize = True
        Me.lblCounty.Location = New System.Drawing.Point(150, 134)
        Me.lblCounty.Name = "lblCounty"
        Me.lblCounty.Size = New System.Drawing.Size(40, 13)
        Me.lblCounty.TabIndex = 14
        Me.lblCounty.Text = "County"
        '
        'txtCounty
        '
        Me.txtCounty.AllowDrop = True
        Me.txtCounty.Location = New System.Drawing.Point(165, 150)
        Me.txtCounty.MaxLength = 255
        Me.txtCounty.Name = "txtCounty"
        Me.txtCounty.Size = New System.Drawing.Size(120, 20)
        Me.txtCounty.TabIndex = 15
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New System.Drawing.Point(6, 173)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(56, 13)
        Me.lblComments.TabIndex = 16
        Me.lblComments.Text = "Comments"
        '
        'txtComments
        '
        Me.txtComments.AcceptsReturn = True
        Me.txtComments.AllowDrop = True
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(21, 189)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComments.Size = New System.Drawing.Size(264, 59)
        Me.txtComments.TabIndex = 17
        '
        'flpButtons
        '
        Me.flpButtons.AutoSize = True
        Me.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpButtons.Controls.Add(Me.btnOK)
        Me.flpButtons.Controls.Add(Me.btnCancel)
        Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpButtons.Location = New System.Drawing.Point(0, 516)
        Me.flpButtons.Name = "flpButtons"
        Me.flpButtons.Size = New System.Drawing.Size(300, 31)
        Me.flpButtons.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(197, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 25)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(91, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmNewSite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(300, 547)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpOptional)
        Me.Controls.Add(Me.grpRequired)
        Me.Controls.Add(Me.flpButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmNewSite"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Add New Site"
        Me.grpRequired.ResumeLayout(False)
        Me.grpRequired.PerformLayout()
        Me.grpOptional.ResumeLayout(False)
        Me.grpOptional.PerformLayout()
        Me.flpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSiteCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSiteName As System.Windows.Forms.TextBox
    Friend WithEvents cboLatLongDatum As System.Windows.Forms.ComboBox
    Friend WithEvents grpRequired As System.Windows.Forms.GroupBox
    Friend WithEvents grpOptional As System.Windows.Forms.GroupBox
    Friend WithEvents txtCounty As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents cboLocalProjection As System.Windows.Forms.ComboBox
    Friend WithEvents lblSiteCode As System.Windows.Forms.Label
    Friend WithEvents lblSiteName As System.Windows.Forms.Label
    Friend WithEvents lblLatitude As System.Windows.Forms.Label
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents lblLatLongDatum As System.Windows.Forms.Label
    Friend WithEvents lblElevation_m As System.Windows.Forms.Label
    Friend WithEvents lblLocalY As System.Windows.Forms.Label
    Friend WithEvents lblLocalProjection As System.Windows.Forms.Label
    Friend WithEvents lblCounty As System.Windows.Forms.Label
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents lblPosAccuracy As System.Windows.Forms.Label
    Friend WithEvents lblLocalX As System.Windows.Forms.Label
    Friend WithEvents lblVerticalDatum As System.Windows.Forms.Label
    Friend WithEvents cboVerticalDatum As System.Windows.Forms.ComboBox
    Friend WithEvents flpButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtLongitude As System.Windows.Forms.TextBox
    Friend WithEvents txtLatitude As System.Windows.Forms.TextBox
    Friend WithEvents txtPosAccuracy As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalY As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalX As System.Windows.Forms.TextBox
    Friend WithEvents txtElevation_m As System.Windows.Forms.TextBox
End Class
