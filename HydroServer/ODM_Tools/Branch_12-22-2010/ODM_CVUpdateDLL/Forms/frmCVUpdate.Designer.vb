<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCVUpdate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents ucMergeAll As ODM_CVUpdate.ucCVMerge

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCVUpdate))
        Me.ucMergeAll = New ODM_CVUpdate.ucCVMerge
        Me.SuspendLayout()
        '
        'ucMergeAll
        '
        Me.ucMergeAll.AddedTextColor = System.Drawing.Color.Orange
        Me.ucMergeAll.ChangedTextColor = System.Drawing.Color.Blue
        Me.ucMergeAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.ucMergeAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucMergeAll.Location = New System.Drawing.Point(0, 0)
        Me.ucMergeAll.Name = "ucMergeAll"
        Me.ucMergeAll.NotFoundTextColor = System.Drawing.Color.Red
        Me.ucMergeAll.Size = New System.Drawing.Size(692, 566)
        Me.ucMergeAll.TabIndex = 3
        Me.ucMergeAll.TableType = CVType.CensorCode
        '
        'frmCVUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 566)
        Me.Controls.Add(Me.ucMergeAll)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmCVUpdate"
        Me.Text = "Update CVs"
        Me.ResumeLayout(False)

    End Sub

End Class
