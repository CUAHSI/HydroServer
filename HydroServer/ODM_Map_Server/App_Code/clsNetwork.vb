Option Strict On
Public Class clsNetwork
    Private mintNetworkID As Integer
    Private mstrNetworkName As String
    Private mstrDatabaseName As String
    Private mstrDBConnection As String
    Private mstrIcon As String
    Private mobjVariables As SortedList

    Public Sub New()
        mintNetworkID = Nothing
        mstrNetworkName = String.Empty
        mstrDatabaseName = String.Empty
        mstrDBConnection = String.Empty
        mstrIcon = String.Empty
        mobjVariables = New SortedList
    End Sub

    Public Sub New(ByVal intNetWorkId As Integer, ByVal strNetworkName As String, ByVal strDatabaseName As String, ByVal strDBConnection As String, ByVal strIcon As String, ByVal objVariables As SortedList)
        mintNetworkID = intNetWorkId
        mstrNetworkName = strNetworkName
        mstrDatabaseName = strDatabaseName
        mstrDBConnection = strDBConnection
        mstrIcon = strIcon
        mobjVariables = objVariables
    End Sub

    Property NetworkId() As Integer
        Get
            Return mintNetworkID
        End Get
        Set(ByVal intNetworkId As Integer)
            mintNetworkID = intNetworkId
        End Set
    End Property

    Property NetworkName() As String
        Get
            Return mstrNetworkName
        End Get
        Set(ByVal strNetworkName As String)
            mstrNetworkName = strNetworkName
        End Set
    End Property

    Property DatabaseName() As String
        Get
            Return mstrDatabaseName
        End Get
        Set(ByVal strDatabaseName As String)
            mstrDatabaseName = strDatabaseName
        End Set
    End Property

    Property DBConnection() As String
        Get
            Return mstrDBConnection
        End Get
        Set(ByVal strDBConnection As String)
            mstrDBConnection = strDBConnection
        End Set
    End Property

    Property Icon() As String
        Get
            Return mstrIcon
        End Get
        Set(ByVal strIcon As String)
            mstrIcon = strIcon
        End Set
    End Property

    Property Variables() As SortedList
        Get
            Return mobjVariables
        End Get
        Set(ByVal objParameters As SortedList)
            mobjVariables = objParameters
        End Set
    End Property

End Class
