'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class frmOptionsDialog
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents cmdOK As System.Windows.Forms.Button
	Friend WithEvents TPDataExport As System.Windows.Forms.TabPage
	Friend WithEvents grp_xprtOther As System.Windows.Forms.GroupBox
	Friend WithEvents chb_xprtMeta As System.Windows.Forms.CheckBox
	Friend WithEvents grp_xprtMyDB As System.Windows.Forms.GroupBox
	Friend WithEvents chb_xprtSource As System.Windows.Forms.CheckBox
	Friend WithEvents chb_xprtOffset As System.Windows.Forms.CheckBox
	Friend WithEvents chb_xprtQualifier As System.Windows.Forms.CheckBox
	Friend WithEvents chb_xprtVariable As System.Windows.Forms.CheckBox
	Friend WithEvents chb_xprtSite As System.Windows.Forms.CheckBox
	Friend WithEvents chb_xprtTime As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents chb_xprtQCL As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.TPDataExport = New System.Windows.Forms.TabPage
        Me.grp_xprtOther = New System.Windows.Forms.GroupBox
        Me.chb_xprtMeta = New System.Windows.Forms.CheckBox
        Me.grp_xprtMyDB = New System.Windows.Forms.GroupBox
        Me.chb_xprtQCL = New System.Windows.Forms.CheckBox
        Me.chb_xprtSource = New System.Windows.Forms.CheckBox
        Me.chb_xprtOffset = New System.Windows.Forms.CheckBox
        Me.chb_xprtQualifier = New System.Windows.Forms.CheckBox
        Me.chb_xprtVariable = New System.Windows.Forms.CheckBox
        Me.chb_xprtSite = New System.Windows.Forms.CheckBox
        Me.chb_xprtTime = New System.Windows.Forms.CheckBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TPDataExport.SuspendLayout()
        Me.grp_xprtOther.SuspendLayout()
        Me.grp_xprtMyDB.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Location = New System.Drawing.Point(88, 302)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(176, 302)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        '
        'TPDataExport
        '
        Me.TPDataExport.Controls.Add(Me.grp_xprtOther)
        Me.TPDataExport.Controls.Add(Me.grp_xprtMyDB)
        Me.TPDataExport.Location = New System.Drawing.Point(4, 22)
        Me.TPDataExport.Name = "TPDataExport"
        Me.TPDataExport.Size = New System.Drawing.Size(255, 272)
        Me.TPDataExport.TabIndex = 0
        Me.TPDataExport.Text = "Data Export"
        '
        'grp_xprtOther
        '
        Me.grp_xprtOther.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_xprtOther.Controls.Add(Me.chb_xprtMeta)
        Me.grp_xprtOther.Location = New System.Drawing.Point(8, 213)
        Me.grp_xprtOther.Name = "grp_xprtOther"
        Me.grp_xprtOther.Size = New System.Drawing.Size(238, 51)
        Me.grp_xprtOther.TabIndex = 1
        Me.grp_xprtOther.TabStop = False
        Me.grp_xprtOther.Text = "Other Options"
        '
        'chb_xprtMeta
        '
        Me.chb_xprtMeta.AutoSize = True
        Me.chb_xprtMeta.Location = New System.Drawing.Point(6, 19)
        Me.chb_xprtMeta.Name = "chb_xprtMeta"
        Me.chb_xprtMeta.Size = New System.Drawing.Size(184, 17)
        Me.chb_xprtMeta.TabIndex = 0
        Me.chb_xprtMeta.Text = "Export MetaData with DataExport"
        '
        'grp_xprtMyDB
        '
        Me.grp_xprtMyDB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_xprtMyDB.Controls.Add(Me.chb_xprtQCL)
        Me.grp_xprtMyDB.Controls.Add(Me.chb_xprtSource)
        Me.grp_xprtMyDB.Controls.Add(Me.chb_xprtOffset)
        Me.grp_xprtMyDB.Controls.Add(Me.chb_xprtQualifier)
        Me.grp_xprtMyDB.Controls.Add(Me.chb_xprtVariable)
        Me.grp_xprtMyDB.Controls.Add(Me.chb_xprtSite)
        Me.grp_xprtMyDB.Controls.Add(Me.chb_xprtTime)
        Me.grp_xprtMyDB.Location = New System.Drawing.Point(8, 16)
        Me.grp_xprtMyDB.Name = "grp_xprtMyDB"
        Me.grp_xprtMyDB.Size = New System.Drawing.Size(238, 191)
        Me.grp_xprtMyDB.TabIndex = 0
        Me.grp_xprtMyDB.TabStop = False
        Me.grp_xprtMyDB.Text = "Expanded MyDB Options"
        '
        'chb_xprtQCL
        '
        Me.chb_xprtQCL.AutoSize = True
        Me.chb_xprtQCL.Location = New System.Drawing.Point(6, 167)
        Me.chb_xprtQCL.Name = "chb_xprtQCL"
        Me.chb_xprtQCL.Size = New System.Drawing.Size(167, 17)
        Me.chb_xprtQCL.TabIndex = 6
        Me.chb_xprtQCL.Text = "Quality Control Level Atributes"
        '
        'chb_xprtSource
        '
        Me.chb_xprtSource.AutoSize = True
        Me.chb_xprtSource.Location = New System.Drawing.Point(6, 144)
        Me.chb_xprtSource.Name = "chb_xprtSource"
        Me.chb_xprtSource.Size = New System.Drawing.Size(107, 17)
        Me.chb_xprtSource.TabIndex = 5
        Me.chb_xprtSource.Text = "Source Attributes"
        '
        'chb_xprtOffset
        '
        Me.chb_xprtOffset.AutoSize = True
        Me.chb_xprtOffset.Location = New System.Drawing.Point(6, 119)
        Me.chb_xprtOffset.Name = "chb_xprtOffset"
        Me.chb_xprtOffset.Size = New System.Drawing.Size(101, 17)
        Me.chb_xprtOffset.TabIndex = 4
        Me.chb_xprtOffset.Text = "Offset Attributes"
        '
        'chb_xprtQualifier
        '
        Me.chb_xprtQualifier.AutoSize = True
        Me.chb_xprtQualifier.Location = New System.Drawing.Point(6, 94)
        Me.chb_xprtQualifier.Name = "chb_xprtQualifier"
        Me.chb_xprtQualifier.Size = New System.Drawing.Size(111, 17)
        Me.chb_xprtQualifier.TabIndex = 3
        Me.chb_xprtQualifier.Text = "Qualifier Attributes"
        '
        'chb_xprtVariable
        '
        Me.chb_xprtVariable.AutoSize = True
        Me.chb_xprtVariable.Location = New System.Drawing.Point(6, 69)
        Me.chb_xprtVariable.Name = "chb_xprtVariable"
        Me.chb_xprtVariable.Size = New System.Drawing.Size(111, 17)
        Me.chb_xprtVariable.TabIndex = 2
        Me.chb_xprtVariable.Text = "Variable Attributes"
        '
        'chb_xprtSite
        '
        Me.chb_xprtSite.AutoSize = True
        Me.chb_xprtSite.Location = New System.Drawing.Point(6, 44)
        Me.chb_xprtSite.Name = "chb_xprtSite"
        Me.chb_xprtSite.Size = New System.Drawing.Size(91, 17)
        Me.chb_xprtSite.TabIndex = 1
        Me.chb_xprtSite.Text = "Site Attributes"
        '
        'chb_xprtTime
        '
        Me.chb_xprtTime.AutoSize = True
        Me.chb_xprtTime.Checked = True
        Me.chb_xprtTime.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_xprtTime.Location = New System.Drawing.Point(6, 19)
        Me.chb_xprtTime.Name = "chb_xprtTime"
        Me.chb_xprtTime.Size = New System.Drawing.Size(96, 17)
        Me.chb_xprtTime.TabIndex = 0
        Me.chb_xprtTime.Text = "Time Attributes"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TPDataExport)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(263, 298)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 0
        '
        'frmOptionsDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(263, 332)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptionsDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.TopMost = True
        Me.TPDataExport.ResumeLayout(False)
        Me.grp_xprtOther.ResumeLayout(False)
        Me.grp_xprtOther.PerformLayout()
        Me.grp_xprtMyDB.ResumeLayout(False)
        Me.grp_xprtMyDB.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

	'Last Documented 5/15/07

#Region " Member Variables "

    Dim m_tempOptions As New clsOptions 'The object used to store all Options changes until ok is pressed

#End Region

#Region " Form Functionality "

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Saves the options
        'Output:    Returns an OK DialogResult
        g_CurrOptions = m_tempOptions
        'If unable to save the settings, display an error message
        If Not WriteSettings() Then
            ShowError("Unable to save settings." & vbCrLf & "Settings not saved")
            Me.DialogResult = Windows.Forms.DialogResult.No
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'Cancel the Options Dialog Box
        'Output:   returns a Cancel DialogResult 
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub frmOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load the current settings to the form and and into a temporary copy      
        chb_xprtTime.Checked = g_CurrOptions.ExportTime
        chb_xprtSite.Checked = g_CurrOptions.ExportSite
        chb_xprtVariable.Checked = g_CurrOptions.ExportVariable
        chb_xprtQualifier.Checked = g_CurrOptions.ExportQualifier
        chb_xprtOffset.Checked = g_CurrOptions.ExportOffset
        chb_xprtSource.Checked = g_CurrOptions.ExportSource
        chb_xprtQCL.Checked = g_CurrOptions.ExportQualityControlLevels
        chb_xprtMeta.Checked = g_CurrOptions.MetadataExport
        m_tempOptions = g_CurrOptions
    End Sub

#Region " Options Functions "
    'When an item is checked/unchecked it's corresponding value is saved in m_temp options "

    Private Sub chb_xprtSource_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_xprtSource.CheckedChanged
        m_tempOptions.ExportSource = sender.checked
    End Sub

    Private Sub chb_xprtOffset_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_xprtOffset.CheckedChanged
        m_tempOptions.ExportOffset = sender.checked
    End Sub

    Private Sub chb_xprtQualifier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_xprtQualifier.CheckedChanged
        m_tempOptions.ExportQualifier = sender.checked
    End Sub

    Private Sub chb_xprtVariable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_xprtVariable.CheckedChanged
        m_tempOptions.ExportVariable = sender.checked
    End Sub

    Private Sub chb_xprtSite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_xprtSite.CheckedChanged
        m_tempOptions.ExportSite = sender.checked
    End Sub

    Private Sub chb_xprtTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_xprtTime.CheckedChanged
        m_tempOptions.ExportTime = sender.checked
    End Sub

    Private Sub chb_xprtQCL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_xprtQCL.CheckedChanged
        m_tempOptions.ExportQualityControlLevels = sender.checked
    End Sub

    Private Sub chb_exprtMeta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_xprtMeta.CheckedChanged
        'Change the Metadata export option for the temporary copy of g_CurrOptions
        m_tempOptions.MetadataExport = sender.Checked
    End Sub


#End Region

#End Region

End Class
