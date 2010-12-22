<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddContact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddContact))
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtOrganizationName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMailingAddress = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtEmailAddress = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtFaxNumber = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPostalCode = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFirstName
        '
        Me.txtFirstName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFirstName.Location = New System.Drawing.Point(75, 12)
        Me.txtFirstName.MaxLength = 255
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(273, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.btnOK)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCancel)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 350)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(360, 29)
        Me.FlowLayoutPanel1.TabIndex = 22
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(282, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(201, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Last Name"
        '
        'txtLastName
        '
        Me.txtLastName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLastName.Location = New System.Drawing.Point(76, 38)
        Me.txtLastName.MaxLength = 255
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(272, 20)
        Me.txtLastName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Organization Name"
        '
        'txtOrganizationName
        '
        Me.txtOrganizationName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrganizationName.Location = New System.Drawing.Point(132, 64)
        Me.txtOrganizationName.MaxLength = 255
        Me.txtOrganizationName.Name = "txtOrganizationName"
        Me.txtOrganizationName.Size = New System.Drawing.Size(216, 20)
        Me.txtOrganizationName.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Mailing Address"
        '
        'txtMailingAddress
        '
        Me.txtMailingAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMailingAddress.Location = New System.Drawing.Point(99, 90)
        Me.txtMailingAddress.MaxLength = 255
        Me.txtMailingAddress.Multiline = True
        Me.txtMailingAddress.Name = "txtMailingAddress"
        Me.txtMailingAddress.Size = New System.Drawing.Size(249, 69)
        Me.txtMailingAddress.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "City"
        '
        'txtCity
        '
        Me.txtCity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCity.Location = New System.Drawing.Point(42, 165)
        Me.txtCity.MaxLength = 255
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(306, 20)
        Me.txtCity.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Area (State)"
        '
        'txtArea
        '
        Me.txtArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtArea.Location = New System.Drawing.Point(81, 191)
        Me.txtArea.MaxLength = 255
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(267, 20)
        Me.txtArea.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 324)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Email Address"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(91, 327)
        Me.txtEmailAddress.MaxLength = 255
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(257, 20)
        Me.txtEmailAddress.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 298)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Phone Number"
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPhoneNumber.Location = New System.Drawing.Point(96, 295)
        Me.txtPhoneNumber.MaxLength = 255
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(252, 20)
        Me.txtPhoneNumber.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 272)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Fax Number"
        '
        'txtFaxNumber
        '
        Me.txtFaxNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFaxNumber.Location = New System.Drawing.Point(82, 269)
        Me.txtFaxNumber.MaxLength = 255
        Me.txtFaxNumber.Name = "txtFaxNumber"
        Me.txtFaxNumber.Size = New System.Drawing.Size(266, 20)
        Me.txtFaxNumber.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 246)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Postal Code"
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostalCode.Location = New System.Drawing.Point(81, 243)
        Me.txtPostalCode.MaxLength = 255
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.Size = New System.Drawing.Size(267, 20)
        Me.txtPostalCode.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 220)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Country"
        '
        'txtCountry
        '
        Me.txtCountry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCountry.Location = New System.Drawing.Point(61, 217)
        Me.txtCountry.MaxLength = 255
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(287, 20)
        Me.txtCountry.TabIndex = 13
        '
        'AddContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(360, 379)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtEmailAddress)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtFaxNumber)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPostalCode)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtCountry)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtArea)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMailingAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOrganizationName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFirstName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddContact"
        Me.Text = "Add Contact"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents txtFirstName As System.Windows.Forms.TextBox
    Private WithEvents txtLastName As System.Windows.Forms.TextBox
    Private WithEvents txtOrganizationName As System.Windows.Forms.TextBox
    Private WithEvents txtMailingAddress As System.Windows.Forms.TextBox
    Private WithEvents txtCity As System.Windows.Forms.TextBox
    Private WithEvents txtArea As System.Windows.Forms.TextBox
    Private WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Private WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
    Private WithEvents txtFaxNumber As System.Windows.Forms.TextBox
    Private WithEvents txtPostalCode As System.Windows.Forms.TextBox
    Private WithEvents txtCountry As System.Windows.Forms.TextBox
End Class
