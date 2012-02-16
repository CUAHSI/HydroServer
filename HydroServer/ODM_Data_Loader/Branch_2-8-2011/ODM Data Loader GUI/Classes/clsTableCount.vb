Public Class clsTableCount
    Inherits Dictionary(Of String, Integer)
    'dictionarybase
    'Inherits System.Collections.ObjectModel.Collection(Of counts) 'Of Dictionary(Of String, Integer))


    Public Sub AddTable(ByRef tc As clsTableCount)
        'For Each c As counts In tc
        'Me.Add(c.TblName, c.NumOfRows)
        For Each c As KeyValuePair(Of String, Integer) In tc
            If (Not ContainsKey(c.Key)) Then
                Me.Add(c.Key, c.Value)
            Else
                Me(c.Key) = Me(c.Key) + c.Value
            End If

        Next
    End Sub
    'Public listofCounts As List(Of counts)

    'Private _methodtablecount As Integer
    'Private _offsettypestablecount As Integer
    'Private _qualifierstablecount As Integer
    'Private _qualitycontrollevelstablecount As Integer
    'Private _samplestablecount As Integer
    'Private _sitestablecount As Integer
    'Private _sourcestablecount As Integer
    'Private _variablestablecount As Integer
    'Private _datavaluestablecount As Integer
    'Private _seriescatalogtablecount As Integer
    'Private _categoriestablecount As Integer
    'Private _derivedfromtablecount As Integer
    'Private _groupdescriptiontablecount As Integer
    'Private _groupstablecount

    'Public Sub New()

    'End Sub

    'Public Property MethodTablecount() As Integer
    '    Get
    '        Return _methodtablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _methodtablecount = value
    '    End Set
    'End Property
    'Public Property DerivedFromTablecount() As Integer
    '    Get
    '        Return _derivedfromtablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _derivedfromtablecount = value
    '    End Set
    'End Property
    'Public Property GroupDescriptionTablecount() As Integer
    '    Get
    '        Return _groupdescriptiontablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _groupdescriptiontablecount = value
    '    End Set
    'End Property
    'Public Property GroupsTablecount() As Integer
    '    Get
    '        Return _groupstablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _groupstablecount = value
    '    End Set
    'End Property
    'Public Property CategoriesTablecount() As Integer
    '    Get
    '        Return _categoriestablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _categoriestablecount = value
    '    End Set
    'End Property
    'Public Property OffsetTypesTablecount() As Integer
    '    Get
    '        Return _offsettypestablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _offsettypestablecount = value
    '    End Set
    'End Property


    'Public Property qualifiersTablecount() As Integer
    '    Get
    '        Return _qualifierstablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _qualifierstablecount = value
    '    End Set
    'End Property

    'Public Property QualityControlLevelStableCount() As Integer
    '    Get
    '        Return _qualitycontrollevelstablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _qualitycontrollevelstablecount = value
    '    End Set
    'End Property

    'Public Property SamplesTablecount() As Integer
    '    Get
    '        Return _samplestablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _samplestablecount = value
    '    End Set
    'End Property

    'Public Property SitesTablecount() As Integer
    '    Get
    '        Return _sitestablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _sitestablecount = value
    '    End Set
    'End Property

    'Public Property SourcesTableCount() As Integer
    '    Get
    '        Return _sourcestablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _sourcestablecount = value
    '    End Set
    'End Property

    'Public Property VariablesTableCount() As Integer
    '    Get
    '        Return _variablestablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _variablestablecount = value
    '    End Set
    'End Property

    'Public Property DataValuesTableCount() As Integer
    '    Get
    '        Return _datavaluestablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _datavaluestablecount = value
    '    End Set
    'End Property

    'Public Property SeriesCatalogTableCount() As Integer
    '    Get
    '        Return _seriescatalogtablecount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _seriescatalogtablecount = value
    '    End Set
    'End Property


End Class

Public Structure counts
    Public TblName As String
    Public NumOfRows As Integer
    Public Sub New(ByVal tableName As String, ByVal numberOfRows As Integer)
        TblName = tableName
        NumOfRows = numberOfRows
    End Sub
 
End Structure