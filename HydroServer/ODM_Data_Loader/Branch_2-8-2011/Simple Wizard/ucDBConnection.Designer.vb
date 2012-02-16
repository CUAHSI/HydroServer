<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDBConnection
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.grpSQL = New System.Windows.Forms.GroupBox
        Me.DatabaseNameLabel = New System.Windows.Forms.Label
        Me.txtDatabaseName = New System.Windows.Forms.TextBox
        Me.txtSQLAddress = New System.Windows.Forms.TextBox
        Me.lblServerAddress = New System.Windows.Forms.Label
        Me.txtSQLPWD = New System.Windows.Forms.TextBox
        Me.lblServerPassword = New System.Windows.Forms.Label
        Me.txtSQLUID = New System.Windows.Forms.TextBox
        Me.lblServerUserID = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.grpSQL.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSQL
        '
        Me.grpSQL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpSQL.Controls.Add(Me.DatabaseNameLabel)
        Me.grpSQL.Controls.Add(Me.txtDatabaseName)
        Me.grpSQL.Controls.Add(Me.txtSQLAddress)
        Me.grpSQL.Controls.Add(Me.lblServerAddress)
        Me.grpSQL.Controls.Add(Me.txtSQLPWD)
        Me.grpSQL.Controls.Add(Me.lblServerPassword)
        Me.grpSQL.Controls.Add(Me.txtSQLUID)
        Me.grpSQL.Controls.Add(Me.lblServerUserID)
        Me.grpSQL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpSQL.Location = New System.Drawing.Point(0, 16)
        Me.grpSQL.Name = "grpSQL"
        Me.grpSQL.Size = New System.Drawing.Size(409, 130)
        Me.grpSQL.TabIndex = 6
        Me.grpSQL.TabStop = False
        Me.grpSQL.Text = "Microsoft SQL Server"
        '
        'DatabaseNameLabel
        '
        Me.DatabaseNameLabel.AutoSize = True
        Me.DatabaseNameLabel.Location = New System.Drawing.Point(9, 44)
        Me.DatabaseNameLabel.Name = "DatabaseNameLabel"
        Me.DatabaseNameLabel.Size = New System.Drawing.Size(87, 13)
        Me.DatabaseNameLabel.TabIndex = 2
        Me.DatabaseNameLabel.Text = "Database Name:"
        Me.DatabaseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatabaseName.Location = New System.Drawing.Point(102, 41)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(301, 20)
        Me.txtDatabaseName.TabIndex = 3
        '
        'txtSQLAddress
        '
        Me.txtSQLAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQLAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSQLAddress.Location = New System.Drawing.Point(102, 17)
        Me.txtSQLAddress.Name = "txtSQLAddress"
        Me.txtSQLAddress.Size = New System.Drawing.Size(301, 20)
        Me.txtSQLAddress.TabIndex = 1
        Me.txtSQLAddress.Text = "(local)"
        '
        'lblServerAddress
        '
        Me.lblServerAddress.AutoSize = True
        Me.lblServerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerAddress.Location = New System.Drawing.Point(14, 20)
        Me.lblServerAddress.Name = "lblServerAddress"
        Me.lblServerAddress.Size = New System.Drawing.Size(82, 13)
        Me.lblServerAddress.TabIndex = 0
        Me.lblServerAddress.Text = "Server Address:"
        Me.lblServerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSQLPWD
        '
        Me.txtSQLPWD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQLPWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSQLPWD.Location = New System.Drawing.Point(102, 89)
        Me.txtSQLPWD.Name = "txtSQLPWD"
        Me.txtSQLPWD.Size = New System.Drawing.Size(301, 20)
        Me.txtSQLPWD.TabIndex = 8
        Me.txtSQLPWD.UseSystemPasswordChar = True
        '
        'lblServerPassword
        '
        Me.lblServerPassword.AutoSize = True
        Me.lblServerPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerPassword.Location = New System.Drawing.Point(6, 92)
        Me.lblServerPassword.Name = "lblServerPassword"
        Me.lblServerPassword.Size = New System.Drawing.Size(90, 13)
        Me.lblServerPassword.TabIndex = 7
        Me.lblServerPassword.Text = "Server Password:"
        Me.lblServerPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSQLUID
        '
        Me.txtSQLUID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQLUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSQLUID.Location = New System.Drawing.Point(102, 65)
        Me.txtSQLUID.Name = "txtSQLUID"
        Me.txtSQLUID.Size = New System.Drawing.Size(301, 20)
        Me.txtSQLUID.TabIndex = 6
        '
        'lblServerUserID
        '
        Me.lblServerUserID.AutoSize = True
        Me.lblServerUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerUserID.Location = New System.Drawing.Point(16, 68)
        Me.lblServerUserID.Name = "lblServerUserID"
        Me.lblServerUserID.Size = New System.Drawing.Size(80, 13)
        Me.lblServerUserID.TabIndex = 5
        Me.lblServerUserID.Text = "Server User ID:"
        Me.lblServerUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(409, 16)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Please select a Database:"
        '
        'ucDBConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.grpSQL)
        Me.Controls.Add(Me.lblTitle)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "ucDBConnection"
        Me.Size = New System.Drawing.Size(409, 146)
        Me.grpSQL.ResumeLayout(False)
        Me.grpSQL.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSQL As System.Windows.Forms.GroupBox
    Friend WithEvents DatabaseNameLabel As System.Windows.Forms.Label
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents txtSQLAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblServerAddress As System.Windows.Forms.Label
    Friend WithEvents txtSQLPWD As System.Windows.Forms.TextBox
    Friend WithEvents lblServerPassword As System.Windows.Forms.Label
    Friend WithEvents txtSQLUID As System.Windows.Forms.TextBox
    Friend WithEvents lblServerUserID As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label

End Class
