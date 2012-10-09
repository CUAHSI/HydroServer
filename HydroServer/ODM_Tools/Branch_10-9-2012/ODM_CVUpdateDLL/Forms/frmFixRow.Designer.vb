<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFixRow
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
        Me.lblInstruct = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.dgvOldRow = New System.Windows.Forms.DataGridView
        Me.dgvNewRow = New System.Windows.Forms.DataGridView
        Me.lblNewTerm = New System.Windows.Forms.Label
        CType(Me.dgvOldRow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNewRow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInstruct
        '
        Me.lblInstruct.AutoSize = True
        Me.lblInstruct.Location = New System.Drawing.Point(12, 9)
        Me.lblInstruct.Name = "lblInstruct"
        Me.lblInstruct.Size = New System.Drawing.Size(332, 39)
        Me.lblInstruct.TabIndex = 0
        Me.lblInstruct.Text = "Please select the Term you wish to change the Unapproved Term to." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Old Term:"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(274, 196)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(355, 196)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dgvOldRow
        '
        Me.dgvOldRow.AllowUserToAddRows = False
        Me.dgvOldRow.AllowUserToDeleteRows = False
        Me.dgvOldRow.AllowUserToResizeRows = False
        Me.dgvOldRow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOldRow.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvOldRow.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOldRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOldRow.Location = New System.Drawing.Point(27, 51)
        Me.dgvOldRow.Name = "dgvOldRow"
        Me.dgvOldRow.ReadOnly = True
        Me.dgvOldRow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvOldRow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOldRow.ShowCellErrors = False
        Me.dgvOldRow.Size = New System.Drawing.Size(403, 60)
        Me.dgvOldRow.TabIndex = 5
        '
        'dgvNewRow
        '
        Me.dgvNewRow.AllowUserToAddRows = False
        Me.dgvNewRow.AllowUserToDeleteRows = False
        Me.dgvNewRow.AllowUserToResizeColumns = False
        Me.dgvNewRow.AllowUserToResizeRows = False
        Me.dgvNewRow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNewRow.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvNewRow.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvNewRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNewRow.ColumnHeadersVisible = False
        Me.dgvNewRow.Location = New System.Drawing.Point(27, 130)
        Me.dgvNewRow.Name = "dgvNewRow"
        Me.dgvNewRow.ReadOnly = True
        Me.dgvNewRow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvNewRow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNewRow.ShowCellErrors = False
        Me.dgvNewRow.Size = New System.Drawing.Size(403, 60)
        Me.dgvNewRow.TabIndex = 6
        '
        'lblNewTerm
        '
        Me.lblNewTerm.AutoSize = True
        Me.lblNewTerm.Location = New System.Drawing.Point(12, 114)
        Me.lblNewTerm.Name = "lblNewTerm"
        Me.lblNewTerm.Size = New System.Drawing.Size(59, 13)
        Me.lblNewTerm.TabIndex = 7
        Me.lblNewTerm.Text = "New Term:"
        '
        'frmFixRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 231)
        Me.Controls.Add(Me.dgvOldRow)
        Me.Controls.Add(Me.lblNewTerm)
        Me.Controls.Add(Me.dgvNewRow)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblInstruct)
        Me.MinimumSize = New System.Drawing.Size(450, 230)
        Me.Name = "frmFixRow"
        Me.Text = "Fix Unaproved Term"
        CType(Me.dgvOldRow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNewRow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblInstruct As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dgvOldRow As System.Windows.Forms.DataGridView
    Friend WithEvents dgvNewRow As System.Windows.Forms.DataGridView
    Friend WithEvents lblNewTerm As System.Windows.Forms.Label
End Class
