Partial Class OptionsPlotOptions
    Inherits System.Web.UI.UserControl
    'Implements System.Web.UI.IStyleSheet

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        m_Options = New PlotOptions
    End Sub

#End Region

    Private m_Options As PlotOptions
    Private m_ShowControlLine As Boolean
    Public Event OptionsChanged()

    Public Property curr_Options() As PlotOptions
        Get
            m_Options = New PlotOptions
            m_Options.PlottingMethod = rblTimeSeries.SelectedValue
            m_Options.ControlLineLabel = txtLabel.Text
            m_Options.ControlLineValue = Val(txtValue.Text)
            m_Options.setControlLineColor = cboColor.SelectedValue
            m_Options.BoxWhiskerType = rblBoxWhiskerType.SelectedValue
            m_Options.BoxWhiskerLine = rblBoxWhiskerLine.SelectedValue
            m_Options.ShowControlLine = m_ShowControlLine
            Return m_Options
        End Get
        Set(ByVal value As PlotOptions)
            m_Options = value

            rblTimeSeries.SelectedValue = value.PlottingMethod
            txtLabel.Text = value.ControlLineLabel
            txtValue.Text = value.ControlLineValue
            rblBoxWhiskerType.SelectedValue = value.BoxWhiskerType
            rblBoxWhiskerLine.SelectedValue = value.BoxWhiskerLine
            m_ShowControlLine = value.ShowControlLine

        End Set
    End Property

    Private Sub lnkApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkApply.Click
        Try
            m_ShowControlLine = True
            RaiseEvent OptionsChanged()
        Catch ex As Exception
            Throw New Exception("Error Occured in PlotOptions.lnkApply_click" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lnkCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCancel.Click
        Try
            txtLabel.Text = String.Empty
            txtValue.Text = String.Empty
            cboColor.SelectedIndex = -1
            m_ShowControlLine = False
            RaiseEvent OptionsChanged()
        Catch ex As Exception
            Throw New Exception("Error Occured in PlotOptions.lnkCancel_click" & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Sub rblTimeSeries_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblTimeSeries.SelectedIndexChanged
        If m_Options Is Nothing Then
            m_Options = New PlotOptions
        End If
        m_Options.PlottingMethod = rblTimeSeries.SelectedValue
        RaiseEvent OptionsChanged()
    End Sub

    Protected Sub txtLabel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLabel.TextChanged
        If m_Options Is Nothing Then
            m_Options = New PlotOptions
        End If
        m_Options.ControlLineLabel = txtLabel.Text
        'RaiseEvent OptionsChanged()
    End Sub

    Protected Sub txtValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
        If m_Options Is Nothing Then
            m_Options = New PlotOptions
        End If
        m_Options.ControlLineValue = Val(txtValue.Text)
        'RaiseEvent OptionsChanged()
    End Sub

    Protected Sub cboColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboColor.SelectedIndexChanged
        If m_Options Is Nothing Then
            m_Options = New PlotOptions
        End If
        m_Options.setControlLineColor = cboColor.SelectedValue
        'RaiseEvent OptionsChanged()
    End Sub

    Protected Sub rblBoxWhiskerType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblBoxWhiskerType.SelectedIndexChanged
        If m_Options Is Nothing Then
            m_Options = New PlotOptions
        End If
        m_Options.BoxWhiskerType = rblBoxWhiskerType.SelectedValue
        RaiseEvent OptionsChanged()
    End Sub

    Protected Sub rblBoxWhiskerLine_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblBoxWhiskerLine.SelectedIndexChanged
        If m_Options Is Nothing Then
            m_Options = New PlotOptions
        End If
        m_Options.BoxWhiskerLine = rblBoxWhiskerLine.SelectedValue
        RaiseEvent OptionsChanged()
    End Sub

End Class
