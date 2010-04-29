Option Strict On
Imports DatabaseFunctions

Public Class Site
    Private mintSiteid As Integer
    Private mstrSiteCode As String
    Private mstrSiteName As String
    Private mstrDatabaseName As String

    Public Sub New()
        mintSiteid = Nothing
        mstrSiteCode = String.Empty
        mstrSiteName = String.Empty
        mstrDatabaseName = String.Empty
    End Sub

    Public Sub New(ByVal oldSite As Site)
        Try
            mintSiteid = oldSite.id
            mstrSiteCode = oldSite.Code
            mstrSiteName = oldSite.Name
            mstrDatabaseName = oldSite.DatabaseName
        Catch ex As Exception
            Throw New Exception("Error Occured in Site.New" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal intSiteid As Integer, ByVal strSiteCode As String, ByVal strSiteName As String, ByVal strDatabaseName As String) ', ByVal objVariables As SortedList)
        Try
            mintSiteid = intSiteid
            mstrSiteCode = strSiteCode
            mstrSiteName = strSiteName
            mstrDatabaseName = strDatabaseName
        Catch ex As Exception
            Throw New Exception("Error Occured in Site.New" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal intSiteid As Integer, ByVal strDatabaseName As String)
        Try
            mintSiteid = intSiteid
            Dim siteData As Data.DataTable = OpenODMTable("SELECT " & db_fld_SiteCode & ", " & db_fld_SiteName & " FROM " & db_tbl_Sites & " WHERE " & db_fld_Siteid & " = '" & intSiteid & "'", strDatabaseName)
            If (Not (siteData Is Nothing)) And (siteData.Rows.Count = 1) Then
                mstrSiteCode = siteData.Rows(0).Item(db_fld_SiteCode).ToString
                mstrSiteName = siteData.Rows(0).Item(db_fld_SiteName).ToString
                'mobjVariables = objVariables
            Else
                mstrSiteCode = String.Empty
                mstrSiteName = String.Empty
                'mobjVariables = new sortedlist
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in Site.New" & vbCrLf & ex.Message)
        End Try
    End Sub

    Property id() As Integer
        Get
            Return mintSiteid
        End Get
        Set(ByVal intSiteid As Integer)
            mintSiteid = intSiteid
        End Set
    End Property

    Property Code() As String
        Get
            Return mstrSiteCode
        End Get
        Set(ByVal strSiteCode As String)
            mstrSiteCode = strSiteCode
        End Set
    End Property

    Property Name() As String
        Get
            Return mstrSiteName
        End Get
        Set(ByVal strSiteName As String)
            mstrSiteName = strSiteName
        End Set
    End Property

    Property DatabaseName() As String
        Get
            Return mstrDatabaseName
        End Get
        Set(ByVal value As String)
            mstrDatabaseName = value
        End Set
    End Property
End Class