Public Class clsTableCount

    Private _methodtablecount As Integer
    Private _offsettypestablecount As Integer
    Private _qualifierstablecount As Integer
    Private _qualitycontrollevelstablecount As Integer
    Private _samplestablecount As Integer
    Private _sitestablecount As Integer
    Private _sourcestablecount As Integer
    Private _variablestablecount As Integer
    Private _datavaluestablecount As Integer
    Private _seriescatalogtablecount As Integer

    Public Sub New()

    End Sub

    Public Property MethodTablecount() As Integer
        Get
            Return _methodtablecount
        End Get
        Set(ByVal value As Integer)
            _methodtablecount = value
        End Set
    End Property

    Public Property OffsetTypesTablecount() As Integer
        Get
            Return _offsettypestablecount
        End Get
        Set(ByVal value As Integer)
            _offsettypestablecount = value
        End Set
    End Property


    Public Property qualifiersTablecount() As Integer
        Get
            Return _qualifierstablecount
        End Get
        Set(ByVal value As Integer)
            _qualifierstablecount = value
        End Set
    End Property

    Public Property QualityControlLevelStableCount() As Integer
        Get
            Return _qualitycontrollevelstablecount
        End Get
        Set(ByVal value As Integer)
            _qualitycontrollevelstablecount = value
        End Set
    End Property

    Public Property SamplesTablecount() As Integer
        Get
            Return _samplestablecount
        End Get
        Set(ByVal value As Integer)
            _samplestablecount = value
        End Set
    End Property

    Public Property SitesTablecount() As Integer
        Get
            Return _sitestablecount
        End Get
        Set(ByVal value As Integer)
            _sitestablecount = value
        End Set
    End Property

    Public Property SourcesTableCount() As Integer
        Get
            Return _sourcestablecount
        End Get
        Set(ByVal value As Integer)
            _sourcestablecount = value
        End Set
    End Property

    Public Property VariablesTableCount() As Integer
        Get
            Return _variablestablecount
        End Get
        Set(ByVal value As Integer)
            _variablestablecount = value
        End Set
    End Property

    Public Property DataValuesTableCount() As Integer
        Get
            Return _datavaluestablecount
        End Get
        Set(ByVal value As Integer)
            _datavaluestablecount = value
        End Set
    End Property

    Public Property SeriesCatalogTableCount() As Integer
        Get
            Return _seriescatalogtablecount
        End Get
        Set(ByVal value As Integer)
            _seriescatalogtablecount = value
        End Set
    End Property


End Class
