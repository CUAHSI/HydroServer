Public Class AddRegionMap
    Dim m_connection As SqlClient.SqlConnection

    Public Sub New(ByVal MapTitle As String, ByVal dName As String, ByVal transPerc As Integer, ByVal Vis As Boolean, ByVal TOC As Boolean, ByVal BaseMapService As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtMapTitle.Text = MapTitle
        DisplayName = dName
        TransparencyPercent = transPerc
        IsVisible = Vis
        IsTOC = TOC
        IsBaseMapService = BaseMapService
    End Sub
    'Public Sub New(ByVal MapServiceID As Integer, ByVal icewater As SqlClient.SqlConnection)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    m_connection = icewater
    'End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If DisplayName <> "" Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Property DisplayName() As String
        Get
            Return txtDisplayName.Text
        End Get
        Set(ByVal value As String)
            txtDisplayName.Text = value
        End Set
    End Property
    Public Property TransparencyPercent() As Integer
        Get
            If numTransparency.Value < 0 Then
                Return 0
            ElseIf numTransparency.Value > 100 Then
                Return 100
            Else
                Return numTransparency.Value
            End If
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                numTransparency.Value = 0
            ElseIf value > 100 Then
                numTransparency.Value = 100
            Else
                numTransparency.Value = value
            End If
        End Set
    End Property
    Public Property IsVisible() As Boolean
        Get
            Return chkIsVisible.Checked
        End Get
        Set(ByVal value As Boolean)
            chkIsVisible.Checked = value
        End Set
    End Property
    Public Property IsTOC() As Boolean
        Get
            Return chkIsTOC.Checked
        End Get
        Set(ByVal value As Boolean)
            chkIsTOC.Checked = value
        End Set
    End Property
    Public Property IsBaseMapService() As Boolean
        Get
            Return chkIsBaseMap.Checked
        End Get
        Set(ByVal value As Boolean)
            chkIsBaseMap.Checked = value
        End Set
    End Property
End Class