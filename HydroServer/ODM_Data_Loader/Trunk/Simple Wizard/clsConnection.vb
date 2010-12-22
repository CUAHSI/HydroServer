Public Class clsConnection

    'Object for storing all nessecary data to access an ODM 1.1 Database

#Region " Properties "
    'ServerAddress property: sets/gets the ServerAddress value for the connection
    Public Property ServerAddress() As String
        Get
            Return m_ServerAddress
        End Get
        Set(ByVal value As String)
            m_ServerAddress = value
            SetConnectionString()
        End Set
    End Property

    'DBName property: sets/gets the Database Name value for the connection
    Public Property DBName() As String
        Get
            Return m_DBName
        End Get
        Set(ByVal value As String)
            m_DBName = value
            SetConnectionString()
        End Set
    End Property

    'Trusted property: sets/gets the Trusted Connection value for the connection
    Public Property Trusted() As Boolean
        Get
            Return m_Trusted
        End Get
        Set(ByVal value As Boolean)
            m_Trusted = value
            SetConnectionString()
        End Set
    End Property

    'UserID property: sets/gets the User ID value for the connection
    Public Property UserID() As String
        Get
            Return m_UserID
        End Get
        Set(ByVal value As String)
            m_UserID = value
            SetConnectionString()
        End Set
    End Property

    'Password property: sets/gets the User Password value for the connection
    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set(ByVal value As String)
            m_Password = value
            SetConnectionString()
        End Set
    End Property

    'Timeout property: sets/gets the Timeout value for the connection
    Public Property Timeout() As Integer
        Get
            Return m_Timeout
        End Get
        Set(ByVal value As Integer)
            m_Timeout = value
            SetConnectionString()
        End Set
    End Property

    'ConnectionString property: Readonly -> returns the Connection String created for the connection
    Public ReadOnly Property ConnectionString() As String
        Get
            Return m_ConnStr
        End Get
    End Property

#End Region

#Region " Database Constants "

#Region " Database Table Definitions "

    'Category _____ =      Definition
    '------------------------------
    'A _____        =      Automatically provided by the database
    'M _____        =      Mandatory
    'O _____        =      Optional
    'P _____        =      Programatically Derived


    '_ VB data type =      SQL server 2005 data type
    '------------------------------
    '_ Integer      =      int
    '_ Double       =      float
    '_ String: ###  =      nvarchar(###)
    '_ Date         =      datetime
    '_ Boolean      =      bit


    'M Integer: Primary Key ->  Automatically assigned int
    'Definitions from: CUAHSI Comunity Observations Data Model Working Design Specifications Document - Version 4

#Region " Categories "
    'Categories
    Public Const db_tbl_Categories As String = "Categories" 'Table Name
    Public Const db_fld_CatVarID As String = "VariableID" 'M Integer: Primary Key -> Unique ID for each Category entry
    Public Const db_fld_CatValue As String = "Value" 'M Double -> Numeric Value
    Public Const db_fld_CatDesc As String = "CategoryDescription" 'M String: 255 -> Definition of categorical variable value
#End Region

#Region " DataValues -> formerly Values "
    'DataValues
    Public Const db_tbl_DataValues As String = "DataValues" 'Table Name
    Public Const db_fld_ValID As String = "ValueID" 'M Integer: Primary Key ->Unique ID for each Values entry
    Public Const db_fld_ValValue As String = "DataValue" 'M Double -> The numeric value.  Holds the CategoryID for categorical data
    Public Const db_fld_ValAccuracyStdDev As String = "ValueAccuracy" 'O Double -> Estimated standard deviation
    Public Const db_fld_ValDateTime As String = "LocalDateTime" 'M Local date and time of the measurement
    Public Const db_fld_ValUTCOffset As String = "UTCOffset" 'M Offset in hours from UTC time
    Public Const db_fld_ValUTCDateTime As String = "DateTimeUTC" 'M UTC date and time of the measurement
    Public Const db_fld_ValSiteID As String = "SiteID" 'M Integer -> Linked to Sites.SiteID
    Public Const db_fld_ValVarID As String = "VariableID" 'M Integer -> Linked to Variables.VariableID
    Public Const db_fld_ValOffsetValue As String = "OffsetValue" 'O Double -> distance from a datum/control point at which the value was observed
    Public Const db_fld_ValOffsetTypeID As String = "OffsetTypeID" 'O Integer -> Linked to OffsetTypes.OffsetTypeID
    Public Const db_fld_ValCensorCode As String = "CensorCode" 'O String: 50 -> CV.  Whether the data is censored
    Public Const db_fld_ValQualifierID As String = "QualifierID" 'O Integer -> Linked to Qualifiers.QualifierID
    Public Const db_fld_ValMethodID As String = "MethodID" 'M Integer -> Linked to Methods.MethodID
    Public Const db_fld_ValSourceID As String = "SourceID" 'M Integer -> Linked to Sources.SourceID
    Public Const db_fld_ValSampleID As String = "SampleID" 'O Integer -> Linked to Samples.SampleID
    Public Const db_fld_ValDerivedFromID As String = "DerivedFromID" 'O Integer -> Linked to DerivedFrom.DerivedFromID
    Public Const db_fld_ValQCLevel As String = "QualityControlLevelID" 'O Integer -> Linked to QualityControlLevels.QualityControlLevel

#Region " Values/Programmer Defined Variables "
    Public Const db_val_ValCensorCode_lt As String = "'lt'"
    Public Const db_outFld_ValDTMonth As String = "DateMonth"
    Public Const db_outFld_ValDTYear As String = "DateYear"
    Public Const db_outFld_ValDTDay As String = "DateDay"
    'Field names readable -> for Data Editing Tab Table
    Public Const db_fldName_ValID As String = "Value ID" 'M Integer: Primary Key ->Unique ID for each Values entry
    Public Const db_fldName_ValValue As String = "Data Value" 'M Double -> The numeric value.  Holds the CategoryID for categorical data
    Public Const db_fldName_ValAccuracyStdDev As String = "Value Accuracy" 'O Double -> Estimated standard deviation
    Public Const db_fldName_ValDateTime As String = "Local Date and Time" 'M Local date and time of the measurement
    Public Const db_fldName_ValUTCOffset As String = "UTC Offset" 'M Offset in hours from UTC time
    Public Const db_fldName_ValUTCDateTime As String = "UTC Date and Time" 'M UTC date and time of the measurement
    Public Const db_fldName_ValOffsetValue As String = "Offset Value" 'O Double -> distance from a datum/control point at which the value was observed
    Public Const db_fldName_ValOffsetTypeID As String = "Offset Type ID" 'O Integer -> Linked to OffsetTypes.OffsetTypeID
    Public Const db_fldName_ValCensorCode As String = "Censor Code" 'O String: 50 -> CV.  Whether the data is censored
    Public Const db_fldName_ValQualifierID As String = "Qualifier ID" 'O Integer -> Linked to Qualifiers.QualifierID
    Public Const db_fldName_ValSampleID As String = "Sample ID" 'O Integer -> Linked to Samples.SampleID
    Public Const db_fldName_ValDerivedFromID As String = "Derived From ID" 'O Integer -> Linked to DerivedFrom.DerivedFromID
#End Region

#End Region

#Region " DerivedFrom "
    'DerivedFrom
    Public Const db_tbl_DerivedFrom As String = "DerivedFrom" 'Table Name
    Public Const db_fld_DFID As String = "DerivedFromID" 'M Integer -> Unique ID for each group of Derived From entries
    Public Const db_fld_DFValueID As String = "ValueID" 'M Integer -> Corresponds to the value id(s) the Derived Value came from

#Region " Values/Programmer Defined Variables "
    Public Const db_val_DerivedFromID_Removed As Integer = -1
    Public Const db_val_DerivedFromID_Invalid As Integer = -2
#End Region

#End Region

#Region " GroupDescriptions "
    'GroupDescriptions
    Public Const db_tbl_GroupDesc As String = "GroupDescriptions" 'Table Name
    Public Const db_fld_GDGroupID As String = "GroupID" 'M Integer: Primary Key -> Unique ID for each GroupDescriptions entry
    Public Const db_fld_GDDesc As String = "GroupDescription" 'O String: 255 -> Text description of the group
#End Region

#Region " Groups "
    'Groups 
    Public Const db_tbl_Groups As String = "Groups" 'Table Name
    Public Const db_fld_GroupID As String = "GroupID" 'M Integer -> Unique ID for each group of Values
    Public Const db_fld_GroupValueID As String = "ValueID" 'M Integer -> Corresponds to the value id of each value in the group
#End Region

#Region " ISOMetaData "
    'ISOMetaData
    Public Const db_tbl_ISOMetaData As String = "ISOMetaData" 'Table Name
    Public Const db_fld_IMDMetaID As String = "MetaDataID" 'M Integer: Primary Key -> Unique ID for each ISOMetaData entry
    Public Const db_fld_IMDTopicCat As String = "TopicCategory" 'M String: 50 -> Topic category keyword that gives the broad ISO19115 metadata topic category for data from this source.  CV
    Public Const db_fld_IMDTitle As String = "Title" 'M String: 255 -> Title of data from a specific data source
    Public Const db_fld_IMDAbstract As String = "Abstract" 'M String: 255 -> Abstract of data from a specific data source
    Public Const db_fld_IMDProfileVs As String = "ProfileVersion" 'M String: 50 -> Abstract of data from a specific data source
    Public Const db_fld_IMDMetaLink As String = "MetadataLink" 'O String: H -> Link to additional metadata reference material
#End Region

#Region " LabMethods "
    'LabMethods
    Public Const db_tbl_LabMethods As String = "LabMethods" 'Table Name
    Public Const db_fld_LMID As String = "LabMethodID" 'M Integer: Primary Key -> Unique ID for each LabMethods entry
    Public Const db_fld_LMLabName As String = "LabName" 'M String: 255 -> Name of the laboratory responsible for processing the sample
    Public Const db_fld_LMLabOrg As String = "LabOrganization" 'M String: 255 -> Organization responsible for sample analysis
    Public Const db_fld_LMName As String = "LabMethodName" 'M String: 255 -> Name of the method and protocols used for sample analysis
    Public Const db_fld_LMDesc As String = "LabMethodDescription" 'M String: 255 -> Description of the method and protocols used for sample analysis
    Public Const db_fld_LMLink As String = "LabMethodLink" 'O String: H -> Link to additional reference material to the analysis method
#End Region

#Region " Methods "
    'Methods
    Public Const db_tbl_Methods As String = "Methods" 'Table Name
    Public Const db_fld_MethID As String = "MethodID" 'M Integer: Primary Key -> Unique ID for each Methods entry
    Public Const db_fld_MethDesc As String = "MethodDescription" 'M String: 255 -> Text descriptionof each method including Quality Assurance and Quality Control procedures
    Public Const db_fld_MethLink As String = "MethodLink" 'O String: H -> Link to additional reference material on the method
#End Region

#Region " OffsetTypes "
    'OffsetTypes
    Public Const db_tbl_OffsetTypes As String = "OffsetTypes" 'Table Name
    Public Const db_fld_OTID As String = "OffsetTypeID" 'M Integer: Primary Key ->Unique ID for each OffsetTypes entry 
    Public Const db_fld_OTUnitsID As String = "OffsetUnitsID" 'M Integer -> Linked to Units.UnitsID
    Public Const db_fld_OTDesc As String = "OffsetDescription" 'M String: 255 -> Full text description of the offset type
#End Region

#Region " Qualifiers "
    'Qualifiers
    Public Const db_tbl_Qualifiers As String = "Qualifiers" 'Table Name
    Public Const db_fld_QlfyID As String = "QualifierID" 'M Integer: Primary Key -> Unique ID for each Qualifiers entry
    Public Const db_fld_QlfyCode As String = "QualifierCode" 'O String: 50 -> Text code used by organization that collects the data
    Public Const db_fld_QlfyDesc As String = "QualifierDescription" 'M String: 255 -> Text of the data qualifying comment
#End Region

#Region " QualityControlLevels "
    'QualityControlLevels
    Public Const db_tbl_QCLevels As String = "QualityControlLevels" ''Table Name
    Public Const db_fld_QCLQCLevelID As String = "QualityControlLevelID" 'M Integer: Primary Key -> Pre-defined ID from 0 to 5
    Public Const db_fld_QCLQCLCode As String = "QualityControlLevelCode"
    Public Const db_fld_QCLDefinition As String = "Definition" 'M String: 255 -> Definition of Quality Control Level
    Public Const db_fld_QCLExplanation As String = "Explanation" 'M String: 500 -> Explanation of Quality Control Level

#Region " DB Loaded Constants "
    Public db_val_QCLDef_Level(,) As String 'Pre-loaded Quality control level definitions for each ID
#End Region

#End Region

#Region " Samples "
    'Samples
    Public Const db_tbl_Samples As String = "Samples" 'Table Name
    Public Const db_fld_SampleID As String = "SampleID" 'M Integer: Primary Key -> Unique ID for each Samples entry
    Public Const db_fld_SampleType As String = "SampleType" 'M String: 50 -> CV specifying the sample type
    Public Const db_fld_SampleLabCode As String = "LabSampleCode" 'M String: 50 -> Code or label used to identify and track lab sample/sample-container (e.g. bottle) during lab analysis
    Public Const db_fld_SampleMethodID As String = "LabMethodID" 'M Integer -> Linked to LabMethods.LabMethodID
#End Region

#Region " SeriesCatalog "
    'SeriesCatalog
    Public Const db_tbl_SeriesCatalog As String = "SeriesCatalog" 'Table Name
    Public Const db_fld_SCSeriesID As String = "SeriesID" 'P Integer: Primary Key -> Unique ID for each SeriesCatalog entry
    Public Const db_fld_SCSiteID As String = "SiteID" 'P Integer -> Linked to Sites.SiteID
    Public Const db_fld_SCSiteCode As String = "SiteCode" 'P String: 50 -> Site Identifier used by organization that collects the data
    Public Const db_fld_SCSiteName As String = "SiteName" 'P String: 255 -> Full text name of sampling location
    Public Const db_fld_SCVarID As String = "VariableID" 'P Integer -> Linked to Variables.VariableID
    Public Const db_fld_SCVarCode As String = "VariableCode" 'P String: 50 -> Variable identifier used by the organization that collects the data
    Public Const db_fld_SCVarName As String = "VariableName" 'P String: 255 -> Name of the variable from the variables table
    Public Const db_fld_SCVarUnitsID As String = "VariableUnitsID" 'P Integer -> Linked to Units.UnitsID
    Public Const db_fld_SCVarUnitsName As String = "VariableUnitsName" 'P String: 255 -> Full text name of the variable units from the UnitsName field in the Units Table
    Public Const db_fld_SCSampleMed As String = "SampleMedium" 'P String: 50 -> 
    Public Const db_fld_SCValueType As String = "ValueType" 'P String: 50 -> Text value indicating what type of value is being recorded
    Public Const db_fld_SCTimeSupport As String = "TimeSupport" 'P Double -> Numerical value that indicates the time support (or temporal footprint). 0 = instantaneous. otherwise = time over which values are averaged. 
    Public Const db_fld_SCTimeUnitsID As String = "TimeUnitsID" 'P Integer -> Linked to Units.UnitsID
    Public Const db_fld_SCTimeUnitsName As String = "TimeUnitsName" 'P String: 255 -> Full text name of the time support units from Units.UnitsName 
    Public Const db_fld_SCDataType As String = "DataType" 'P String: 50 -> CV. Data type that identifies the data as one of several types from the DataTypeCV.
    Public Const db_fld_SCGenCat As String = "GeneralCategory" 'P String: 50 -> CV. General category of the variable
    Public Const db_fld_SCMethodID As String = "MethodID" 'P Integer -> Corresponds to the ID of the Method for the Series
    Public Const db_fld_SCMethodDesc As String = "MethodDescription" 'P String: 255 -> Corresponds to the Method Description for the Series
    Public Const db_fld_SCQCLevel As String = "QualityControlLevelID"   'P Integer -> Corresponds to the Quality Control Level of the Series
    Public Const db_fld_SCSourceID As String = "SourceID" 'P Integer -> Corresponds to the ID of the Source for the Series
    Public Const db_fld_SCOrganization As String = "Organization" 'P String: 50 -> Corresponds to the Organization for the Series
    Public Const db_fld_SCSourceDesc As String = "SourceDescription" 'P String: 255 -> Corresponds to the Source Description for the Series
    Public Const db_fld_SCBeginDT As String = "BeginDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCEndDT As String = "EndDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCBeginDTUTC As String = "BeginDateTimeUTC" 'P DateTime -> The First UTC Date
    Public Const db_fld_SCEndDTUTC As String = "EndDateTimeUTC" 'P DateTime -> The Last UTC Date
    Public Const db_fld_SCValueCount As String = "ValueCount" 'P Integer -> The number of vaues in the series (SiteID & VariableID)
#End Region

#Region " Sites "
    'Sites
    Public Const db_tbl_Sites As String = "Sites" 'Table Name
    Public Const db_fld_SiteID As String = "SiteID" 'M Integer: Primary Key -> Unique ID for each Sites entry
    Public Const db_fld_SiteCode As String = "SiteCode" 'O String: 50 -> Code used by organization that collects the data
    Public Const db_fld_SiteName As String = "SiteName" 'O String: 255 -> Full name of sampling location
    Public Const db_fld_SiteLat As String = "Latitude" 'M Double -> Latitude in degrees w/ Decimals
    Public Const db_fld_SiteLong As String = "Longitude" 'M Double -> Longitude in degrees w/ Decimals
    Public Const db_fld_SiteLatLongDatumID As String = "LatLongDatumID" 'M Integer -> Linked to SpatialReferences.SpatialReferenceID
    Public Const db_fld_SiteElev_m As String = "Elevation_m" 'M Double -> Elevation of sampling location in meters.  
    Public Const db_fld_SiteVertDatum As String = "VerticalDatum" 'M String: 50 -> CV. Vertical Datum 
    Public Const db_fld_SiteLocX As String = "LocalX" 'O Double -> Local Projection X Coordinate
    Public Const db_fld_SiteLocY As String = "LocalY" 'O Double -> Local Projection Y Coordinate
    Public Const db_fld_SiteLocProjID As String = "LocalProjectionID" 'O Integer -> Linked to SpatialReferences.SpatialReferenceID
    Public Const db_fld_SitePosAccuracy_m As String = "PosAccuracy_m" 'O Double -> Value giving the acuracy with which the positional information is specified.  in meters
    Public Const db_fld_SiteState As String = "State" 'O String: 50 -> Name of state in which the sampling station is located
    Public Const db_fld_SiteCounty As String = "County" 'O String: 50 -> Name of County in which the sampling station is located
    Public Const db_fld_SiteComments As String = "Comments" 'O String: 500 -> Comments related to the site
#End Region

#Region " Sources "
    'Sources
    Public Const db_tbl_Sources As String = "Sources" 'Table Name
    Public Const db_fld_SrcID As String = "SourceID" 'M Integer: Primary Key -> Unique ID for each Sources entry
    Public Const db_fld_SrcOrg As String = "Organization" 'M String: 50 -> Name of organization that collected the data itself.  not who held it
    Public Const db_fld_SrcDesc As String = "SourceDescription" 'M String: 255 -> Full text description of the source of the data
    Public Const db_fld_SrcLink As String = "SourceLink" 'M String: H -> Link to original data m_viewtable and associated metadata stored in the digital library or URL of data source
    Public Const db_fld_SrcContactName As String = "ContactName" 'M String: 50 -> Name of Contact Person for data source
    Public Const db_fld_SrcPhone As String = "Phone" 'M String: 50 -> Phone number for contact person
    Public Const db_fld_SrcEmail As String = "Email" 'M String: 50 -> email address for contact person
    Public Const db_fld_SrcAddress As String = "Address" 'M String: 255 -> Address for contact person
    Public Const db_fld_SrcCity As String = "City" 'M String: 50 -> city for contact person
    Public Const db_fld_SrcState As String = "State" 'M String: 50 -> state for contact person. 2 letter abreviations for "state, US", give full name for other countries
    Public Const db_fld_SrcCitation As String = "Citation"
    Public Const db_fld_SrcZip As String = "ZipCode" 'M String: 50 -> US zip code or country postal code
    Public Const db_fld_SrcMetaID As String = "MetaDataID" 'M Integer -> ISOMetaData.MetaDataID
#End Region

#Region " SpatialReferences "
    'SpatialReferences
    Public Const db_tbl_SpatialRefs As String = "SpatialReferences" 'Table Name
    Public Const db_fld_SRID As String = "SpatialReferenceID" 'M Integer: Primary Key -> Unique ID for each SpatialReferences entry
    Public Const db_fld_SRSRSID As String = "SRSID" 'O Integer -> ID for Spatial Reference System @ http://epsg.org/
    Public Const db_fld_SRSRSName As String = "SRSName" 'M String: 255 -> Name of spatial reference system
    Public Const db_fld_SRIsGeo As String = "IsGeographic" 'M Boolean -> Whether it uses geographic coordinates (Lat., Long.)
    Public Const db_fld_SRNotes As String = "Notes" 'O String: 500 -> Descriptive information about reference system
#End Region

#Region " Units "
    'Units
    Public Const db_tbl_Units As String = "Units" 'Table Name
    Public Const db_fld_UnitsID As String = "UnitsID" 'M Integer: Primary Key -> Unique ID for each Units entry
    Public Const db_fld_UnitsName As String = "UnitsName" 'M String: 255 -> Full name of the units
    Public Const db_fld_UnitsType As String = "UnitsType" 'M String: 50 -> Dimensions of the units
    Public Const db_fld_UnitsAbrv As String = "UnitsAbbreviation" 'M String: 50 -> Abbreviation for the units

#Region " Values/Programmer Defined Variables "
    Public Const db_val_UnitsTimeSupport_MilliSecond As String = "millisecond"
    Public Const db_val_UnitsTimeSupport_Second As String = "second"
    Public Const db_val_UnitsTimeSupport_Minute As String = "minute"
    Public Const db_val_UnitsTimeSupport_Hour As String = "hour"
    Public Const db_val_UnitsTimeSupport_Day As String = "day"
#End Region

#End Region

#Region " Variables "
    'Variables
    Public Const db_tbl_Variables As String = "Variables" 'Table Name
    Public Const db_fld_VarID As String = "VariableID" 'M Integer: Primary Key -> Unique ID for each Variables entry
    Public Const db_fld_VarCode As String = "VariableCode" 'O String: 50 -> Code used by the organization that collects the data
    Public Const db_fld_VarName As String = "VariableName" 'M String: 255 -> CV. Name of the variable that was measured/observed/modeled
    Public Const db_fld_VarSpec As String = "Speciation"
    Public Const db_fld_VarUnitsID As String = "VariableUnitsID" 'O Integer -> Linked to Units.UnitsID
    Public Const db_fld_VarSampleMed As String = "SampleMedium" 'M String: 50 -> CV. The medium of the sample
    Public Const db_fld_VarValueType As String = "ValueType" 'M String: 50 -> CV. Text value indicating what type of value is being recorded
    Public Const db_fld_VarIsRegular As String = "IsRegular" 'M Boolean -> Whether the values are from a regularly sampled time series
    Public Const db_fld_VarTimeSupport As String = "TimeSupport" 'M Double -> Numerical value indicating the temporal footprint over which values are averaged.  0 = instantaneous
    Public Const db_fld_VarTimeUnitsID As String = "TimeUnitsID" 'O Integer -> Linked to Units.UnitsID
    Public Const db_fld_VarDataType As String = "DataType" 'M STring: 50 -> CV. text value that identifies the data as one of several types
    Public Const db_fld_VarGenCat As String = "GeneralCategory" 'M STring: 50 -> CV. General category of the values
    Public Const db_fld_VarNoDataVal As String = "NoDataValue" 'M Double -> Numeric value used to encode no data values for this variable
#End Region

#End Region

#Region " Controlled Vocabulary Table Definitions "

    'table names
    Public Const db_tbl_VariableNameCV As String = "VariableNameCV"
    Public Const db_tbl_ValueTypeCV As String = "ValueTypeCV"
    Public Const db_tbl_CensorCodeCV As String = "CensorCodeCV"
    Public Const db_tbl_SampleMediumCV As String = "SampleMediumCV"
    Public Const db_tbl_GeneralCategoryCV As String = "GeneralCategoryCV"
    Public Const db_tbl_TopicCategoryCV As String = "TopicCategoryCV"
    Public Const db_tbl_DataTypeCV As String = "DataTypeCV"
    Public Const db_tbl_SampleTypeCV As String = "SampleTypeCV"
    Public Const db_tbl_VerticalDatumCV As String = "VerticalDatumCV"

    'fields
    Public Const db_fld_CV_Term As String = "Term"
    Public Const db_fld_CV_Definition As String = "Definition"

#End Region

#End Region

#Region " Connection Variables "

    Private m_ServerAddress As String   'The network address of the server
    Private m_DBName As String      'The Name of the Database
    Private m_Trusted As Boolean    'True if using Windows Authentication
    Private m_UserID As String      'User Name for the connection
    Private m_Password As String    'Password of the connection
    Private m_Timeout As Integer    'Timeout of the connection
    Private m_ConnStr As String 'The actual connection string used by the DB connection

#End Region

#Region " Functions "

#Region " Connection String Functions "

    Public Sub New(Optional ByVal e_ServerAddress As String = "", Optional ByVal e_DBName As String = "", Optional ByVal e_Timeout As Integer = 1, Optional ByVal e_Trusted As Boolean = False, Optional ByVal e_UserID As String = "", Optional ByVal e_Password As String = "")
        'Create a new set of connection settings with the specified parameters (if any are specified)
        m_ServerAddress = e_ServerAddress
        m_DBName = e_DBName
        m_Trusted = e_Trusted
        m_Timeout = e_Timeout
        m_UserID = e_UserID
        m_Password = e_Password

        'Regenerate the connection string
        SetConnectionString()
    End Sub

    Public Function IncrementTimeout() As Boolean
        'Increments the Timeout setting by 1 as long as it is <= 15
        'Then regenerates the conntection string 
        'Output:    Returns True if m_timeout is not too high
        If Timeout <= 30 Then
            m_Timeout = m_Timeout + 1
            SetConnectionString()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SetConnectionString()
        'Generates a connection string for use in accessing a database
        If m_Trusted Then
            If Not (m_ServerAddress = "" OrElse m_DBName = "" OrElse m_Timeout <= 0) Then
                m_ConnStr = "Data Source=" & m_ServerAddress & ";Integrated Security=" & "True" & ";Connect Timeout=" & m_Timeout & ";Initial Catalog=" & m_DBName & ";MultipleActiveResultSets=True"
            Else
                m_ConnStr = ""
            End If
        Else
            If Not (m_ServerAddress = "" OrElse m_DBName = "" OrElse m_Timeout <= 0 OrElse m_UserID = "" OrElse m_Password = "") Then
                m_ConnStr = "Data Source=" & m_ServerAddress & ";User ID=" & m_UserID & ";Password=" & m_Password & ";Connect Timeout=" & m_Timeout & ";Initial Catalog=" & m_DBName & ";MultipleActiveResultSets=True"
            Else
                m_ConnStr = ""
            End If
        End If
    End Sub

#End Region

#Region " Database Functions "

    Public Function OpenTable(ByVal conn As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction, ByVal tableName As String, ByVal sqlQuery As String) As DataTable
        'Returns a dataTable of the query data.
        'Inputs:  tablename -> name of the table
        '         SqlQuery -> sql Query to retreive the data with
        '         connString -> the connection String for the database to connect to, to retreive the data from
        'Outputs: the dataTable of data retreived from the database using SqlQuery
        'create a flow table
        Dim table As New System.Data.DataTable(tableName) 'the table of data to return
        Dim dataAdapter As SqlClient.SqlDataAdapter 'the dataAdapter to fill the table
        Try
            'connect to the Database
            dataAdapter = New SqlClient.SqlDataAdapter(sqlQuery, conn)
            dataAdapter.SelectCommand.Transaction = trans

            'get the table from the database
            dataAdapter.Fill(table)
            dataAdapter = Nothing
            Return table
        Catch ex As System.Exception
            table = Nothing
            dataAdapter = Nothing
            'if the connection timed out, increment the timeout and resave the settings. then try to open the table again.
            If LCase(ex.Message).Contains("timeout") Then
                If IncrementTimeout() Then
                    'My.Settings.Timeout = settings.Timeout
                    'My.Settings.Save()
                    Return OpenTable(conn, trans, tableName, sqlQuery)
                Else
                    ShowError("Connection timed out.")
                End If
            Else
                ShowError("An Error occurred while opening the Table = " & tableName, ex)
            End If
        End Try

        Return Nothing
    End Function

    Public Function UpdateTable(ByVal conn As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction, ByRef table As System.Data.DataTable, ByVal query As String) As Integer
        'this function updates the database after new rows have been added to or existing rows have been edited in the dataTable
        'the datatable is the the dataTable that was used to add/edit the rows, query is the query used to create the original datatable
        'Inputs: dataTable -> the dataTable used to add/edit the row
        '        query -> the query used to create the original dataTable
        '        connectionString -> the connectionString to the database
        'Outputs: none
        Dim count As Integer
        If (table Is Nothing) Then
            Return -1
        End If
        If (table.Rows.Count <= 0) Then
            Return 0
        End If
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If

        Dim updateAdapter As SqlClient.SqlDataAdapter 'updateAdapter -> finds out if anything has been changed and marks the rows that need to be added -> used by the command builder
        Dim commandBuilder As SqlClient.SqlCommandBuilder 'CommandBuilder -> creates the insert function for updating the database

        Try
            'create the updateAdapter,commandBuilder
            updateAdapter = New SqlClient.SqlDataAdapter(query, conn)
            updateAdapter.SelectCommand.Transaction = trans
            commandBuilder = New SqlClient.SqlCommandBuilder(updateAdapter)

            updateAdapter.ContinueUpdateOnError = False
            'update the database
            count = updateAdapter.Update(table)

            table.Rows.Clear()

            updateAdapter.Fill(table)

            If (count <= 0) Then
                Return -1
            End If

        Catch ex As Exception
            If ex.Message.Contains("Violation of UNIQUE KEY constraint") Then
                ShowError("One (or more) rows in " & table.TableName & " already exist in the database.")
            Else
                ShowError("Error in UpdateTable()" & vbCr & "Message = " & ex.Message, ex)
            End If
            Return -1
        End Try

        'return the number of rows updated
        Return count
    End Function

    Public Function TestDBConnection() As Boolean
        'Used to test a databse connection
        'Inputs:  Settings -> A ConnectionSettings instance used to create a connection to a database
        'Outputs: TestDBConnection -> Returns True if the test was successful, otherwise returns False

        'Create a new connection
        Dim testConn As New SqlClient.SqlConnection(m_ConnStr) 'Temporary connection settings to test
        Dim sql1 As String 'SQL command to test DB with
        'dim SQL2 as string
        If m_DBName = "" Or m_ServerAddress = "" Then
            Return False
        Else
            Try

                testConn.Open()

                'Create an sql command that accesses all tables and a field within the series catalog table
                sql1 = "SELECT MAX(VersionNumber) as CurrentVersion FROM ODMVersion"
                'SQL2 = "SELECT MAX(value) as CurrentVersion FROM ::fn_listextendedproperty('ODM_version', NULL, NULL, NULL, NULL, NULL, NULL)"

                'Test the connection
                Dim VersTable As New SqlClient.SqlDataAdapter(sql1, testConn)
                'Dim VersExPrp As New SqlClient.SqlDataAdapter(SQL2, TestConn)
                Dim Table As New DataTable
                'Dim ExPrp As New DataTable

                VersTable.Fill(Table)
                'VersExPrp.Fill(ExPrp)

                testConn.Close()
                testConn.Dispose()

                If (Table.Rows.Count = 1) Then
                    If (Table.Rows(0).Item("CurrentVersion").ToString.StartsWith("1.1")) Then
                        Return True
                    Else
                        ShowError("This program is only compatible with ODM 1.1 Databases.  You have an ODM " & Table.Rows(0).Item("VersionNumber").ToString & " Database")
                        Return False
                    End If
                Else
                    ShowError("There was an error retrieving the Version Number of the ODM Database")
                    Return False
                End If

                testConn.Close()
                testConn.Dispose()
            Catch ex As Exception
                'If the connection timed out, increment the timeout setting, return the results of another test, else return false
                If ex.Message.Contains("Timeout expired") Then
                    If IncrementTimeout() Then
                        Return TestDBConnection()
                    End If
                ElseIf ex.Message.Contains("SQL Server does not exist") Then
                    ShowError("Server Address Incorrect.")
                ElseIf ex.Message.Contains("Cannot open database") Then
                    ShowError("Database Name Incorrect.")
                ElseIf ex.Message.Contains("Login failed for user") Then
                    ShowError("Username or Password Incorrect.")
                ElseIf ex.Message.Contains("Cannot open database requested in login '") Then
                    ShowError("The requested database does not exist on that server." & vbCrLf & "Please enter the full server path.")
                ElseIf ex.Message.Contains("Invalid object name '") Then
                    ShowError("The requested database does not contain the correct tables." & vbCrLf & "Please enter a different database name.")
                Else
                    ShowError("Unable to connect to Database", ex)
                End If
                Return False 'after logging error
            End Try
            Return True
        End If
        'No Errors
    End Function

    Public Function FormatDateForQuery(ByVal d As Date) As String
        'Formats the date for a query string
        ' Sql puts quotes and oledb puts # around the date
        'Inputs:  d -> the date to format
        'Outputs: the correctly formatted date

        'Format the Date for an SQL Database
        Return "'" & d.ToString & "'"

    End Function

    Public Function FormatStringForQuery(ByVal value As String) As String
        Dim formatted As String
        formatted = "'" & value.Replace("'", "''") & "'"

        Return formatted
    End Function

#End Region

#End Region

End Class
