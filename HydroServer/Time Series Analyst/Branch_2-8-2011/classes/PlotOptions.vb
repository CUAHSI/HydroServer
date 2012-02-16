Imports Microsoft.VisualBasic

Public Class PlotOptions
#Region " Member Variables "
    Private _PlottingMethod As String
    Private _ControlLineLabel As String
    Private _ControlLineValue As Double
    Private _ControlLineColor As Drawing.Color
    Private _ShowControlLine As Boolean
    Private _BoxWhiskerType As String
    Private _BoxWhiskerLine As String
#End Region

    Public Property PlottingMethod() As String
        Get
            Return _PlottingMethod
        End Get
        Set(ByVal value As String)
            _PlottingMethod = value
        End Set
    End Property

    Public Property ControlLineLabel() As String
        Get
            Return _ControlLineLabel
        End Get
        Set(ByVal value As String)
            _ControlLineLabel = value
        End Set
    End Property

    Public Property ControlLineValue() As Double
        Get
            Return _ControlLineValue
        End Get
        Set(ByVal value As Double)
            _ControlLineValue = value
        End Set
    End Property

    Public WriteOnly Property setControlLineColor() As String
        'Get
        '    Return _ControlLineColor.ToString
        'End Get
        Set(ByVal value As String)
            _ControlLineColor = Drawing.Color.FromName(value)
        End Set
    End Property

    Public ReadOnly Property ControlLineColor() As Drawing.Color
        Get
            Return _ControlLineColor
        End Get
    End Property

    Public Property ShowControlLine() As Boolean
        Get
            Return _ShowControlLine
        End Get
        Set(ByVal value As Boolean)
            _ShowControlLine = value
        End Set
    End Property

    Public Property BoxWhiskerType() As String
        Get
            Return _BoxWhiskerType
        End Get
        Set(ByVal value As String)
            _BoxWhiskerType = value
        End Set
    End Property

    Public Property BoxWhiskerLine() As String
        Get
            Return _BoxWhiskerLine
        End Get
        Set(ByVal value As String)
            _BoxWhiskerLine = value
        End Set
    End Property

End Class
