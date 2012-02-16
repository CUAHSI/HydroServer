Option Strict On
Imports DatabaseFunctions

Public Class DataSeries

#Region " Member Variables "
    Private mintSeriesid As Integer
    Private mobjSite As Site
    Private mobjVariable As Variable
    Private mstrSampleMedium As String
    Private mstrValueType As String
    Private mstrTimeSupport As String
    Private mstrTimeUnitsName As String
    Private mstrDataType As String
    Private mstrGeneralCategory As String
    Private mstrMethodDescription As String
    Private mstrOrganization As String
    Private mstrSourceDescription As String
    Private mintQualityControlLevelid As Integer
    Private mdtmBeginDateTime As System.DateTime
    Private mdtmEndDateTime As System.DateTime
    Private mintValueCount As Integer
    Private mstrDatabaseName As String

    Private mintMethodID As Integer
    Private mintSourceID As Integer

#End Region

#Region " Constructors "

    Sub New()
        mintSeriesid = Nothing
        mobjSite = Nothing
        mobjVariable = Nothing
        mstrSampleMedium = Nothing
        mstrValueType = Nothing
        mstrTimeSupport = Nothing
        mstrTimeUnitsName = Nothing
        mstrDataType = Nothing
        mstrGeneralCategory = Nothing
        mstrMethodDescription = Nothing
        mstrOrganization = Nothing
        mstrSourceDescription = Nothing
        mintQualityControlLevelid = Nothing
        mdtmBeginDateTime = Nothing
        mdtmEndDateTime = Nothing
        mintValueCount = Nothing
        mstrDatabaseName = Nothing
        mintMethodID = Nothing
        mintSourceID = Nothing
    End Sub

    Sub New(ByRef objDataSeries As DataSeries)
        Try
            mintSeriesid = objDataSeries.Seriesid
            mobjSite = objDataSeries.mobjSite
            mobjVariable = objDataSeries.mobjVariable
            mstrSampleMedium = objDataSeries.SampleMedium
            mstrValueType = objDataSeries.ValueType
            mstrTimeSupport = objDataSeries.TimeSupport
            mstrTimeUnitsName = objDataSeries.TimeUnitsName
            mstrDataType = objDataSeries.DataType
            mstrGeneralCategory = objDataSeries.GeneralCategory
            mstrMethodDescription = objDataSeries.MethodDescription
            mstrOrganization = objDataSeries.Organization
            mstrSourceDescription = objDataSeries.SourceDescription
            mintQualityControlLevelid = objDataSeries.QualityControlLevelid
            mdtmBeginDateTime = objDataSeries.BeginDateTime
            mdtmEndDateTime = objDataSeries.EndDateTime
            mintValueCount = objDataSeries.ValueCount
            mstrDatabaseName = objDataSeries.DatabaseName
            mintMethodID = objDataSeries.MethodID
            mintSourceID = objDataSeries.SourceID
        Catch ex As Exception
            Throw New Exception("Error Occured in DataSeries.New" & vbCrLf & ex.Message)
        End Try
    End Sub

    Sub New(ByVal intSiteid As Integer, ByVal strSiteCode As String, ByVal strSiteName As String, ByVal intVariableid As Integer, ByVal strVariableCode As String, ByVal strVariableName As String, _
            ByVal strVariableUnits As String, ByVal strSampleMedium As String, ByVal strValueType As String, _
            ByVal strTimeSupport As String, ByVal strTimeUnitsName As String, ByVal strDataType As String, _
            ByVal strGeneralCategory As String, ByVal strMethodDescription As String, ByVal strOrganization As String, _
            ByVal strSourceDescription As String, ByVal intQualityControlLevelid As Integer, _
            ByVal dtmBeginDateTime As System.DateTime, ByVal dtmEndDateTime As System.DateTime, ByVal intValueCount As Integer, ByVal strDatabaseName As String)
        Try
            mobjSite = New Site(intSiteid, strSiteCode, strSiteName, strDatabaseName)
            mobjVariable = New Variable(intVariableid, strVariableCode, strVariableName, strVariableUnits, strDatabaseName)
            mstrSampleMedium = strSampleMedium
            mstrValueType = strValueType
            mstrTimeSupport = strTimeSupport
            mstrTimeUnitsName = strTimeUnitsName
            mstrDataType = strDataType
            mstrGeneralCategory = strGeneralCategory
            mstrMethodDescription = strMethodDescription
            mstrOrganization = strOrganization
            mstrSourceDescription = strSourceDescription
            mintQualityControlLevelid = intQualityControlLevelid
            mdtmBeginDateTime = dtmBeginDateTime
            mdtmEndDateTime = dtmEndDateTime
            mintValueCount = intValueCount
            mstrDatabaseName = strDatabaseName

            Dim seriesData As System.Data.DataTable
            seriesData = OpenODMTable("SELECT " & db_fld_SCSeriesid & ", " & db_fld_SCMethodid & ", " & db_fld_SCSourceid & _
            " FROM " & db_tbl_SeriesCatalog & _
            " WHERE (" & db_fld_SCSiteid & " = '" & intSiteid & "') AND (" & _
            db_fld_SCVarid & " = '" & intVariableid & "') AND (" & _
            db_fld_SCMethodDesc & " = '" & strMethodDescription & "') AND (" & _
            db_fld_SCMethodDesc & " = '" & strOrganization & "') AND (" & _
            db_fld_SCMethodDesc & " = '" & strSourceDescription & "') AND (" & _
            db_fld_SCMethodDesc & " = '" & intQualityControlLevelid & "')", mstrDatabaseName)
            If Not (seriesData Is Nothing) And (seriesData.Rows.Count > 0) Then
                mintSeriesid = CInt(seriesData.Rows(0).Item(db_fld_SCSeriesid))
                mintSourceID = CInt(seriesData.Rows(0).Item(db_fld_SCSourceid))
                mintMethodID = CInt(seriesData.Rows(0).Item(db_fld_SCMethodid))
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in DatabaseFunctions.FormatParameter" & vbCrLf & ex.Message)
        End Try
    End Sub

    Sub New(ByVal e_seriesid As Integer, ByVal e_databasename As String)
        Try
            Dim seriesData As System.Data.DataTable
            seriesData = OpenODMTable("SELECT * FROM " & db_tbl_SeriesCatalog & " WHERE " & db_fld_SCSeriesid & " = '" & e_seriesid & "'", e_databasename)
            If Not (seriesData Is Nothing) And (seriesData.Rows.Count > 0) Then
                mintSeriesid = CInt(seriesData.Rows(0).Item(db_fld_SCSeriesid))
                mobjSite = New Site(CInt(seriesData.Rows(0).Item(db_fld_SCSiteid)), seriesData.Rows(0).Item(db_fld_SCSiteCode).ToString, seriesData.Rows(0).Item(db_fld_SCSiteName).ToString, e_databasename)
                mobjVariable = New Variable(CInt(seriesData.Rows(0).Item(db_fld_SCVarid)), e_databasename)
                mstrSampleMedium = CStr(seriesData.Rows(0).Item(db_fld_SCSampleMed))
                mstrValueType = CStr(seriesData.Rows(0).Item(db_fld_SCValueType))
                mstrTimeSupport = CStr(seriesData.Rows(0).Item(db_fld_SCTimeSupport))
                mstrTimeUnitsName = CStr(seriesData.Rows(0).Item(db_fld_SCTimeUnitsName))
                mstrDataType = CStr(seriesData.Rows(0).Item(db_fld_SCDataType))
                mstrGeneralCategory = CStr(seriesData.Rows(0).Item(db_fld_SCGenCat))
                mstrMethodDescription = CStr(seriesData.Rows(0).Item(db_fld_SCMethodDesc))
                mstrOrganization = CStr(seriesData.Rows(0).Item(db_fld_SCOrganization))
                mstrSourceDescription = CStr(seriesData.Rows(0).Item(db_fld_SCSourceDesc))
                mintQualityControlLevelid = CInt(seriesData.Rows(0).Item(db_fld_SCQCLevel))
                mdtmBeginDateTime = CDate(seriesData.Rows(0).Item(db_fld_SCBeginDT))
                mdtmEndDateTime = CDate(seriesData.Rows(0).Item(db_fld_SCEndDT))
                mintValueCount = CInt(seriesData.Rows(0).Item(db_fld_SCValueCount))
                mintSourceID = CInt(seriesData.Rows(0).Item(db_fld_SCSourceid))
                mintMethodID = CInt(seriesData.Rows(0).Item(db_fld_SCMethodid))
                mstrDatabaseName = e_databasename
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in DataSeries.New" & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

#Region " Properties "

    Public Property Seriesid() As Integer
        Get
            Return mintSeriesid
        End Get
        Set(ByVal value As Integer)
            mintSeriesid = value
        End Set
    End Property

    Public Property Siteid() As Integer
        Get
            Return mobjSite.id
        End Get
        Set(ByVal value As Integer)
            mobjSite.id = value
        End Set
    End Property

    Public Property SiteCode() As String
        Get
            Return mobjSite.Code
        End Get
        Set(ByVal strSiteCode As String)
            mobjSite.Code = strSiteCode
        End Set
    End Property

    Public Property SiteName() As String
        Get
            Return mobjSite.Name
        End Get
        Set(ByVal value As String)
            mobjSite.Name = value
        End Set
    End Property

    Public Property Variableid() As Integer
        Get
            Return mobjVariable.id
        End Get
        Set(ByVal intVariableid As Integer)
            mobjVariable.id = intVariableid
        End Set
    End Property

    Public Property VariableCode() As String
        Get
            Return mobjVariable.Code
        End Get
        Set(ByVal strVariableCode As String)
            mobjVariable.Code = strVariableCode
        End Set
    End Property

    Public Property VariableName() As String
        Get
            Return mobjVariable.Name
        End Get
        Set(ByVal strVariableName As String)
            mobjVariable.Name = strVariableName
        End Set
    End Property

    Public Property VariableUnits() As String
        Get
            Return mobjVariable.Units
        End Get
        Set(ByVal strVariableUnitsName As String)
            mobjVariable.Units = strVariableUnitsName
        End Set
    End Property

    Public Property SampleMedium() As String
        Get
            Return mstrSampleMedium
        End Get
        Set(ByVal strSampleMedium As String)
            mstrSampleMedium = strSampleMedium
        End Set
    End Property

    Public Property ValueType() As String
        Get
            Return mstrValueType
        End Get
        Set(ByVal strValueType As String)
            mstrValueType = strValueType
        End Set
    End Property

    Public Property TimeSupport() As String
        Get
            Return mstrTimeSupport
        End Get
        Set(ByVal strTimeSupport As String)
            mstrTimeSupport = strTimeSupport
        End Set
    End Property

    Public Property TimeUnitsName() As String
        Get
            Return mstrTimeUnitsName
        End Get
        Set(ByVal strTimeUnitsName As String)
            mstrTimeUnitsName = strTimeUnitsName
        End Set
    End Property

    Public Property DataType() As String
        Get
            Return mstrDataType
        End Get
        Set(ByVal strDataType As String)
            mstrDataType = strDataType
        End Set
    End Property

    Public Property GeneralCategory() As String
        Get
            Return mstrGeneralCategory
        End Get
        Set(ByVal strGeneralCategory As String)
            mstrGeneralCategory = strGeneralCategory
        End Set
    End Property

    Public Property MethodDescription() As String
        Get
            Return mstrMethodDescription
        End Get
        Set(ByVal strMethodDescription As String)
            mstrMethodDescription = strMethodDescription
        End Set
    End Property

    Public Property Organization() As String
        Get
            Return mstrOrganization
        End Get
        Set(ByVal strOrganization As String)
            mstrOrganization = strOrganization
        End Set
    End Property

    Public Property SourceDescription() As String
        Get
            Return mstrSourceDescription
        End Get
        Set(ByVal strSourceDescription As String)
            mstrSourceDescription = strSourceDescription
        End Set
    End Property

    Public Property QualityControlLevelid() As Integer
        Get
            Return mintQualityControlLevelid
        End Get
        Set(ByVal intQualityControlLevelid As Integer)
            mintQualityControlLevelid = intQualityControlLevelid
        End Set
    End Property

    Property BeginDateTime() As System.DateTime
        Get
            Return mdtmBeginDateTime
        End Get
        Set(ByVal dtmBeginDateTime As System.DateTime)
            mdtmBeginDateTime = mdtmBeginDateTime
        End Set
    End Property

    Property EndDateTime() As System.DateTime
        Get
            Return mdtmEndDateTime
        End Get
        Set(ByVal dtmEndDateTime As System.DateTime)
            mdtmEndDateTime = dtmEndDateTime
        End Set
    End Property

    Property ValueCount() As Integer
        Get
            Return mintValueCount
        End Get
        Set(ByVal intValueCount As Integer)
            mintValueCount = intValueCount
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

    ReadOnly Property MethodID() As Integer
        Get
            Return mintMethodID
        End Get
    End Property

    ReadOnly Property SourceID() As Integer
        Get
            Return mintSourceID
        End Get
    End Property

#End Region

    Public Sub AdjustSpan(ByRef objDataSeries As DataSeries)
        Try
            If Year(objDataSeries.BeginDateTime) < Year(mdtmBeginDateTime) Then
                mdtmBeginDateTime = objDataSeries.BeginDateTime
            End If
            If Year(objDataSeries.EndDateTime) > Year(mdtmEndDateTime) Then
                mdtmEndDateTime = objDataSeries.EndDateTime
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in DataSeries.AdjustSpan" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class
