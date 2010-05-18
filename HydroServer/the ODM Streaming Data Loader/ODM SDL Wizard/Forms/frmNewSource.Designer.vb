<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewSource
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
        Me.grpRequired = New System.Windows.Forms.GroupBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblCitation = New System.Windows.Forms.Label
        Me.txtCitation = New System.Windows.Forms.TextBox
        Me.lblOrganization = New System.Windows.Forms.Label
        Me.txtOrganization = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblContactName = New System.Windows.Forms.Label
        Me.txtContactName = New System.Windows.Forms.TextBox
        Me.lblContactPhone = New System.Windows.Forms.Label
        Me.txtContactPhone = New System.Windows.Forms.MaskedTextBox
        Me.lblContactAddress = New System.Windows.Forms.Label
        Me.txtContactAddress = New System.Windows.Forms.TextBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.lblState = New System.Windows.Forms.Label
        Me.txtState = New System.Windows.Forms.TextBox
        Me.lblZipCode = New System.Windows.Forms.Label
        Me.txtZipCode = New System.Windows.Forms.MaskedTextBox
        Me.lblEmail = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.lblISOMetadata = New System.Windows.Forms.Label
        Me.cboISOMetadata = New System.Windows.Forms.ComboBox
        Me.grpOptional = New System.Windows.Forms.GroupBox
        Me.lblLink = New System.Windows.Forms.Label
        Me.txtLink = New System.Windows.Forms.TextBox
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpRequired.SuspendLayout()
        Me.grpOptional.SuspendLayout()
        Me.flpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRequired
        '
        Me.grpRequired.Controls.Add(Me.lblOrganization)
        Me.grpRequired.Controls.Add(Me.txtOrganization)
        Me.grpRequired.Controls.Add(Me.lblDescription)
        Me.grpRequired.Controls.Add(Me.txtDescription)
        Me.grpRequired.Controls.Add(Me.lblContactAddress)
        Me.grpRequired.Controls.Add(Me.txtContactAddress)
        Me.grpRequired.Controls.Add(Me.lblCitation)
        Me.grpRequired.Controls.Add(Me.txtCitation)
        Me.grpRequired.Controls.Add(Me.lblContactName)
        Me.grpRequired.Controls.Add(Me.txtContactName)
        Me.grpRequired.Controls.Add(Me.lblContactPhone)
        Me.grpRequired.Controls.Add(Me.txtContactPhone)
        Me.grpRequired.Controls.Add(Me.lblCity)
        Me.grpRequired.Controls.Add(Me.txtCity)
        Me.grpRequired.Controls.Add(Me.lblState)
        Me.grpRequired.Controls.Add(Me.txtState)
        Me.grpRequired.Controls.Add(Me.lblZipCode)
        Me.grpRequired.Controls.Add(Me.txtZipCode)
        Me.grpRequired.Controls.Add(Me.lblEmail)
        Me.grpRequired.Controls.Add(Me.txtEmail)
        Me.grpRequired.Controls.Add(Me.lblISOMetadata)
        Me.grpRequired.Controls.Add(Me.cboISOMetadata)
        Me.grpRequired.Controls.Add(Me.btnAdd)
        Me.grpRequired.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRequired.Location = New System.Drawing.Point(0, 0)
        Me.grpRequired.Name = "grpRequired"
        Me.grpRequired.Size = New System.Drawing.Size(301, 493)
        Me.grpRequired.TabIndex = 0
        Me.grpRequired.TabStop = False
        Me.grpRequired.Text = "Required"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.ODMSDLConfigWiz.My.Resources.Resources.btnAdd
        Me.btnAdd.Location = New System.Drawing.Point(264, 461)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(21, 21)
        Me.btnAdd.TabIndex = 22
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblCitation
        '
        Me.lblCitation.AutoSize = True
        Me.lblCitation.Location = New System.Drawing.Point(12, 250)
        Me.lblCitation.Name = "lblCitation"
        Me.lblCitation.Size = New System.Drawing.Size(42, 13)
        Me.lblCitation.TabIndex = 6
        Me.lblCitation.Text = "Citation"
        '
        'txtCitation
        '
        Me.txtCitation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCitation.Location = New System.Drawing.Point(21, 266)
        Me.txtCitation.Multiline = True
        Me.txtCitation.Name = "txtCitation"
        Me.txtCitation.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCitation.Size = New System.Drawing.Size(265, 59)
        Me.txtCitation.TabIndex = 7
        '
        'lblOrganization
        '
        Me.lblOrganization.AutoSize = True
        Me.lblOrganization.Location = New System.Drawing.Point(12, 16)
        Me.lblOrganization.Name = "lblOrganization"
        Me.lblOrganization.Size = New System.Drawing.Size(66, 13)
        Me.lblOrganization.TabIndex = 0
        Me.lblOrganization.Text = "Organization"
        '
        'txtOrganization
        '
        Me.txtOrganization.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrganization.Location = New System.Drawing.Point(21, 32)
        Me.txtOrganization.MaxLength = 255
        Me.txtOrganization.Multiline = True
        Me.txtOrganization.Name = "txtOrganization"
        Me.txtOrganization.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOrganization.Size = New System.Drawing.Size(265, 59)
        Me.txtOrganization.TabIndex = 1
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(12, 94)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(21, 110)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescription.Size = New System.Drawing.Size(265, 59)
        Me.txtDescription.TabIndex = 3
        '
        'lblContactName
        '
        Me.lblContactName.AutoSize = True
        Me.lblContactName.Location = New System.Drawing.Point(12, 328)
        Me.lblContactName.Name = "lblContactName"
        Me.lblContactName.Size = New System.Drawing.Size(75, 13)
        Me.lblContactName.TabIndex = 8
        Me.lblContactName.Text = "Contact Name"
        '
        'txtContactName
        '
        Me.txtContactName.Location = New System.Drawing.Point(21, 344)
        Me.txtContactName.MaxLength = 255
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(120, 20)
        Me.txtContactName.TabIndex = 9
        '
        'lblContactPhone
        '
        Me.lblContactPhone.AutoSize = True
        Me.lblContactPhone.Location = New System.Drawing.Point(150, 328)
        Me.lblContactPhone.Name = "lblContactPhone"
        Me.lblContactPhone.Size = New System.Drawing.Size(78, 13)
        Me.lblContactPhone.TabIndex = 10
        Me.lblContactPhone.Text = "Contact Phone"
        '
        'txtContactPhone
        '
        Me.txtContactPhone.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPhone.Location = New System.Drawing.Point(165, 344)
        Me.txtContactPhone.Mask = "9(999) 000-0000"
        Me.txtContactPhone.Name = "txtContactPhone"
        Me.txtContactPhone.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtContactPhone.RejectInputOnFirstFailure = True
        Me.txtContactPhone.Size = New System.Drawing.Size(120, 20)
        Me.txtContactPhone.TabIndex = 11
        '
        'lblContactAddress
        '
        Me.lblContactAddress.AutoSize = True
        Me.lblContactAddress.Location = New System.Drawing.Point(12, 172)
        Me.lblContactAddress.Name = "lblContactAddress"
        Me.lblContactAddress.Size = New System.Drawing.Size(85, 13)
        Me.lblContactAddress.TabIndex = 4
        Me.lblContactAddress.Text = "Contact Address"
        '
        'txtContactAddress
        '
        Me.txtContactAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContactAddress.Location = New System.Drawing.Point(21, 188)
        Me.txtContactAddress.MaxLength = 255
        Me.txtContactAddress.Multiline = True
        Me.txtContactAddress.Name = "txtContactAddress"
        Me.txtContactAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtContactAddress.Size = New System.Drawing.Size(265, 59)
        Me.txtContactAddress.TabIndex = 5
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(12, 367)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(24, 13)
        Me.lblCity.TabIndex = 12
        Me.lblCity.Text = "City"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(21, 383)
        Me.txtCity.MaxLength = 255
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(120, 20)
        Me.txtCity.TabIndex = 13
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(150, 367)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(32, 13)
        Me.lblState.TabIndex = 14
        Me.lblState.Text = "State"
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(165, 383)
        Me.txtState.MaxLength = 255
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(120, 20)
        Me.txtState.TabIndex = 15
        '
        'lblZipCode
        '
        Me.lblZipCode.AutoSize = True
        Me.lblZipCode.Location = New System.Drawing.Point(12, 406)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(50, 13)
        Me.lblZipCode.TabIndex = 16
        Me.lblZipCode.Text = "Zip Code"
        '
        'txtZipCode
        '
        Me.txtZipCode.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipCode.Location = New System.Drawing.Point(21, 423)
        Me.txtZipCode.Mask = "00000-9999"
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtZipCode.RejectInputOnFirstFailure = True
        Me.txtZipCode.Size = New System.Drawing.Size(120, 20)
        Me.txtZipCode.TabIndex = 17
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(150, 406)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(72, 13)
        Me.lblEmail.TabIndex = 18
        Me.lblEmail.Text = "Contact Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(165, 422)
        Me.txtEmail.MaxLength = 255
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(120, 20)
        Me.txtEmail.TabIndex = 19
        '
        'lblISOMetadata
        '
        Me.lblISOMetadata.AutoSize = True
        Me.lblISOMetadata.Location = New System.Drawing.Point(12, 445)
        Me.lblISOMetadata.Name = "lblISOMetadata"
        Me.lblISOMetadata.Size = New System.Drawing.Size(73, 13)
        Me.lblISOMetadata.TabIndex = 20
        Me.lblISOMetadata.Text = "ISO Metadata"
        '
        'cboISOMetadata
        '
        Me.cboISOMetadata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboISOMetadata.FormattingEnabled = True
        Me.cboISOMetadata.Location = New System.Drawing.Point(21, 461)
        Me.cboISOMetadata.MaxDropDownItems = 10
        Me.cboISOMetadata.Name = "cboISOMetadata"
        Me.cboISOMetadata.Size = New System.Drawing.Size(237, 21)
        Me.cboISOMetadata.TabIndex = 21
        '
        'grpOptional
        '
        Me.grpOptional.Controls.Add(Me.lblLink)
        Me.grpOptional.Controls.Add(Me.txtLink)
        Me.grpOptional.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpOptional.Location = New System.Drawing.Point(0, 493)
        Me.grpOptional.Name = "grpOptional"
        Me.grpOptional.Size = New System.Drawing.Size(301, 103)
        Me.grpOptional.TabIndex = 1
        Me.grpOptional.TabStop = False
        Me.grpOptional.Text = "Optional"
        '
        'lblLink
        '
        Me.lblLink.AutoSize = True
        Me.lblLink.Location = New System.Drawing.Point(12, 16)
        Me.lblLink.Name = "lblLink"
        Me.lblLink.Size = New System.Drawing.Size(27, 13)
        Me.lblLink.TabIndex = 0
        Me.lblLink.Text = "Link"
        '
        'txtLink
        '
        Me.txtLink.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLink.Location = New System.Drawing.Point(21, 32)
        Me.txtLink.MaxLength = 500
        Me.txtLink.Multiline = True
        Me.txtLink.Name = "txtLink"
        Me.txtLink.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLink.Size = New System.Drawing.Size(265, 59)
        Me.txtLink.TabIndex = 1
        '
        'flpButtons
        '
        Me.flpButtons.AutoSize = True
        Me.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpButtons.Controls.Add(Me.btnOK)
        Me.flpButtons.Controls.Add(Me.btnCancel)
        Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpButtons.Location = New System.Drawing.Point(0, 596)
        Me.flpButtons.Name = "flpButtons"
        Me.flpButtons.Size = New System.Drawing.Size(301, 31)
        Me.flpButtons.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(198, 3)
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
        Me.btnCancel.Location = New System.Drawing.Point(92, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmNewSource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(301, 627)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpOptional)
        Me.Controls.Add(Me.grpRequired)
        Me.Controls.Add(Me.flpButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmNewSource"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Add New Source"
        Me.grpRequired.ResumeLayout(False)
        Me.grpRequired.PerformLayout()
        Me.grpOptional.ResumeLayout(False)
        Me.grpOptional.PerformLayout()
        Me.flpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpRequired As System.Windows.Forms.GroupBox
    Friend WithEvents txtOrganization As System.Windows.Forms.TextBox
    Friend WithEvents cboISOMetadata As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtContactAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtContactName As System.Windows.Forms.TextBox
    Friend WithEvents grpOptional As System.Windows.Forms.GroupBox
    Friend WithEvents txtLink As System.Windows.Forms.TextBox
    Friend WithEvents lblZipCode As System.Windows.Forms.Label
    Friend WithEvents lblISOMetadata As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblContactAddress As System.Windows.Forms.Label
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents lblContactPhone As System.Windows.Forms.Label
    Friend WithEvents lblContactName As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblOrganization As System.Windows.Forms.Label
    Friend WithEvents lblLink As System.Windows.Forms.Label
    Friend WithEvents txtZipCode As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtContactPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents flpButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblCitation As System.Windows.Forms.Label
    Friend WithEvents txtCitation As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class
