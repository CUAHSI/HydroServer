<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccessDB
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.lblPwd = New System.Windows.Forms.Label
        Me.txtPWD = New System.Windows.Forms.TextBox
        Me.pnlIcewater = New System.Windows.Forms.Panel
        Me.CloseButton = New System.Windows.Forms.Button
        Me.ConnectButton = New System.Windows.Forms.Button
        Me.txtDatabase = New System.Windows.Forms.TextBox
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.IcewaterConnection = New System.Data.SqlClient.SqlConnection
        Me.pnlIcewater.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(1)
        Me.Label3.Size = New System.Drawing.Size(221, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "HydroServer Capabilites Database Connection"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(390, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please enter connection settings for the HydroServer Capabilites " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Database. Make " & _
            "sure the username and password belong to a user " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "that has write access to the d" & _
            "atabase."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Server Address"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(6, 135)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(63, 13)
        Me.lblUser.TabIndex = 3
        Me.lblUser.Text = "Username"
        '
        'txtUser
        '
        Me.txtUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser.Location = New System.Drawing.Point(75, 132)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(337, 20)
        Me.txtUser.TabIndex = 3
        '
        'lblPwd
        '
        Me.lblPwd.AutoSize = True
        Me.lblPwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPwd.Location = New System.Drawing.Point(6, 161)
        Me.lblPwd.Name = "lblPwd"
        Me.lblPwd.Size = New System.Drawing.Size(61, 13)
        Me.lblPwd.TabIndex = 5
        Me.lblPwd.Text = "Password"
        '
        'txtPWD
        '
        Me.txtPWD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPWD.Location = New System.Drawing.Point(73, 161)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Size = New System.Drawing.Size(339, 20)
        Me.txtPWD.TabIndex = 4
        Me.txtPWD.UseSystemPasswordChar = True
        '
        'pnlIcewater
        '
        Me.pnlIcewater.Controls.Add(Me.CloseButton)
        Me.pnlIcewater.Controls.Add(Me.ConnectButton)
        Me.pnlIcewater.Controls.Add(Me.txtDatabase)
        Me.pnlIcewater.Controls.Add(Me.txtServer)
        Me.pnlIcewater.Controls.Add(Me.Label4)
        Me.pnlIcewater.Controls.Add(Me.Panel1)
        Me.pnlIcewater.Controls.Add(Me.Label1)
        Me.pnlIcewater.Controls.Add(Me.Label2)
        Me.pnlIcewater.Controls.Add(Me.lblUser)
        Me.pnlIcewater.Controls.Add(Me.txtUser)
        Me.pnlIcewater.Controls.Add(Me.lblPwd)
        Me.pnlIcewater.Controls.Add(Me.txtPWD)
        Me.pnlIcewater.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlIcewater.Location = New System.Drawing.Point(0, 0)
        Me.pnlIcewater.Name = "pnlIcewater"
        Me.pnlIcewater.Size = New System.Drawing.Size(415, 229)
        Me.pnlIcewater.TabIndex = 1
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(11, 195)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 7
        Me.CloseButton.Text = "&Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'ConnectButton
        '
        Me.ConnectButton.Location = New System.Drawing.Point(328, 195)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(75, 23)
        Me.ConnectButton.TabIndex = 6
        Me.ConnectButton.Text = "C&onnect"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'txtDatabase
        '
        Me.txtDatabase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatabase.Location = New System.Drawing.Point(105, 106)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(307, 20)
        Me.txtDatabase.TabIndex = 2
        '
        'txtServer
        '
        Me.txtServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServer.Location = New System.Drawing.Point(105, 80)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(307, 20)
        Me.txtServer.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Database Name"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 18)
        Me.Panel1.TabIndex = 4
        '
        'IcewaterConnection
        '
        Me.IcewaterConnection.ConnectionString = "Data Source=JUSTINB\SQLEXPRESS;Initial Catalog=ICEWATER;Persist Security Info=Tru" & _
            "e;User ID=justin;Password=UWRL"
        Me.IcewaterConnection.FireInfoMessageEventOnUserErrors = False
        '
        'AccessDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 229)
        Me.Controls.Add(Me.pnlIcewater)
        Me.Name = "AccessDB"
        Me.Text = "HydroServer Capabilites Database Configuration Tool"
        Me.pnlIcewater.ResumeLayout(False)
        Me.pnlIcewater.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblPwd As System.Windows.Forms.Label
    Friend WithEvents txtPWD As System.Windows.Forms.TextBox
    Friend WithEvents pnlIcewater As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents ConnectButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents IcewaterConnection As System.Data.SqlClient.SqlConnection
End Class
