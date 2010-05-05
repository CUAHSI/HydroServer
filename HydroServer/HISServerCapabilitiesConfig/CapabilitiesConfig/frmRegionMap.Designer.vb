<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegionMap
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node2")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node3")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node4")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node5")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node1", New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegionMap))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.isVisIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlMapImages = New System.Windows.Forms.Panel
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlMapImages)
        Me.SplitContainer1.Size = New System.Drawing.Size(884, 436)
        Me.SplitContainer1.SplitterDistance = 211
        Me.SplitContainer1.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node2"
        TreeNode1.StateImageKey = "visible"
        TreeNode1.Text = "Node2"
        TreeNode2.Name = "Node3"
        TreeNode2.StateImageKey = "hidden"
        TreeNode2.Text = "Node3"
        TreeNode3.Name = "Node0"
        TreeNode3.StateImageKey = "visible"
        TreeNode3.Text = "Node0"
        TreeNode4.Name = "Node4"
        TreeNode4.StateImageKey = "visible"
        TreeNode4.Text = "Node4"
        TreeNode5.Name = "Node5"
        TreeNode5.StateImageKey = "hidden"
        TreeNode5.Text = "Node5"
        TreeNode6.Name = "Node1"
        TreeNode6.StateImageKey = "hidden"
        TreeNode6.Text = "Node1"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode6})
        Me.TreeView1.Size = New System.Drawing.Size(211, 436)
        Me.TreeView1.StateImageList = Me.isVisIcons
        Me.TreeView1.TabIndex = 0
        '
        'isVisIcons
        '
        Me.isVisIcons.ImageStream = CType(resources.GetObject("isVisIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.isVisIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.isVisIcons.Images.SetKeyName(0, "visible")
        Me.isVisIcons.Images.SetKeyName(1, "hidden")
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 436)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(884, 100)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'pnlMapImages
        '
        Me.pnlMapImages.Location = New System.Drawing.Point(151, 61)
        Me.pnlMapImages.Name = "pnlMapImages"
        Me.pnlMapImages.Size = New System.Drawing.Size(386, 306)
        Me.pnlMapImages.TabIndex = 0
        '
        'frmRegionMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 536)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegionMap"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RegionMap"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents isVisIcons As System.Windows.Forms.ImageList
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlMapImages As System.Windows.Forms.Panel

End Class
