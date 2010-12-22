Public Class AddMetadata

    Public Property metaTitle() As String
        Get
            Return txtTitle.Text
        End Get
        Set(ByVal value As String)
            txtTitle.Text = value
        End Set
    End Property
    Public Property metaContent() As String
        Get
            Return txtContent.Text
        End Get
        Set(ByVal value As String)
            txtContent.Text = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(ByVal MetaType As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = MetaType & " Metadata"
    End Sub
    Public Sub New(ByVal MetaType As String, ByVal oldTitle As String, ByVal oldContent As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = MetaType & " Metadata"
        txtTitle.Text = oldTitle
        txtContent.Text = oldContent
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class