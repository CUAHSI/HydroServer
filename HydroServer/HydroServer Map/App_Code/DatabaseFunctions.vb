Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports System
Imports System.Configuration

Public Class DatabaseFunctions
    Public Structure ODMDatabase
        Public DisplayName As String
        Public DisplayOrder As String
        Public Connection As String
    End Structure
#Region " HydroServer Specifications "

    Public Const db_tbl_Regions As String = "Regions"
    Public Const db_fld_Re_ID As String = "RegionID"    'Primary Key
    Public Const db_fld_Re_DisplayName As String = "RegionName"
    Public Const db_fld_Re_Title As String = "RegionTitle"
    Public Const db_fld_Re_Description As String = "RegionDescription"
    Public Const db_fld_Re_CSSUrl As String = "RegionCSSURL"

    Public Const db_tbl_RegionDatabases As String = "RegionDatabases"
    Public Const db_fld_RD_RegionID As String = "RegionID"
    Public Const db_fld_RD_DatabaseID As String = "DatabaseID"
    Public Const db_fld_RD_DisplayOrder As String = "DisplayOrder"
    Public Const db_fld_RD_DisplayName As String = "DisplayName"

    Public Const db_tbl_RegionMaps As String = "RegionMapServices"
    Public Const db_fld_RM_RegionID As String = "RegionID"
    Public Const db_fld_RM_MapID As String = "MapServiceID"
    Public Const db_fld_RM_DisplayOrder As String = "DisplayOrder"
    Public Const db_fld_RM_DisplayName As String = "DisplayName"
    Public Const db_fld_RM_TransparencyPercent As String = "TransparencyPercent"
    Public Const db_fld_RM_IsVisible As String = "IsVisible"
    Public Const db_fld_RM_IsTOC As String = "IsTOC"
    Public Const db_fld_RM_IsBaseMap As String = "IsBaseMapService"

    Public Const db_tbl_Databases As String = "ODMDatabases"
    Public Const db_fld_Db_ID As String = "DatabaseID"  'Primary Key
    Public Const db_fld_Db_Title As String = "Title"
    Public Const db_fld_Db_ServerAddress As String = "ServerAddress"
    Public Const db_fld_Db_DatabaseName As String = "DatabaseName"
    Public Const db_fld_Db_User As String = "ODMUser"
    Public Const db_fld_Db_Password As String = "ODMPassword"
    Public Const db_fld_Db_Marker As String = "MapMarkerUrl"
    Public Const db_fld_Db_ReferenceDate As String = "ReferenceDate"
    Public Const db_fld_Db_NorthExtent As String = "NorthExtent"
    Public Const db_fld_Db_EastExtent As String = "EastExtent"
    Public Const db_fld_Db_SouthExtent As String = "SouthExtent"
    Public Const db_fld_Db_WestExtent As String = "WestExtent"
    Public Const db_fld_Db_TopicCategory As String = "TopicCategory"
    Public Const db_fld_Db_Abstract As String = "Abstract"
    Public Const db_fld_Db_MetadataContactID As String = "MetadataContactID"
    Public Const db_fld_Db_DatasetContactID As String = "DatasetContactID"
    Public Const db_fld_Db_LineageStatement As String = "LineageStatement"
    Public Const db_fld_Db_WSDL As String = "WaterOneFlowWSDL"

    Public Const db_tbl_Maps As String = "MapServices"
    Public Const db_fld_Mp_ID As String = "MapServiceID"  'Primary Key
    Public Const db_fld_Mp_Title As String = "Title"
    Public Const db_fld_Mp_MapConnection As String = "MapConnection"
    Public Const db_fld_Mp_ServerID As String = "MapServerID"
    Public Const db_fld_Mp_ReferenceDate As String = "ReferenceDate"
    Public Const db_fld_Mp_NorthExtent As String = "NorthExtent"
    Public Const db_fld_Mp_EastExtent As String = "EastExtent"
    Public Const db_fld_Mp_SouthExtent As String = "SouthExtent"
    Public Const db_fld_Mp_WestExtent As String = "WestExtent"
    Public Const db_fld_Mp_TopicCategory As String = "TopicCategory"
    Public Const db_fld_Mp_Abstract As String = "Abstract"
    Public Const db_fld_Mp_MetadataContactID As String = "MetadataContactID"
    Public Const db_fld_Mp_DatasetContactID As String = "DatasetContactID"
    Public Const db_fld_Mp_SpatialResolution As String = "SpatialResolution"
    Public Const db_fld_Mp_DistributionFormat As String = "DistributionFormat"
    Public Const db_fld_Mp_SpatialRepresentationType As String = "SpatialRepresentationType"
    Public Const db_fld_Mp_ReferenceSystem As String = "ReferenceSystem"
    Public Const db_fld_Mp_LineageStatement As String = "LineageStatement"
    Public Const db_fld_Mp_OnlineResource As String = "OnlineResource"

    Public Const db_tbl_Servers As String = "MapServers"
    Public Const db_fld_Se_ID As String = "MapServerID"    'Primary Key
    Public Const db_fld_Se_ServerName As String = "MapServerName"
    Public Const db_fld_Se_ConnectionUrl As String = "ConnectionUrl"
    Public Const db_fld_Se_Type As String = "MapServerType"
    Public Const db_fld_Se_Username As String = "Username"
    Public Const db_fld_Se_Domain As String = "Domain"
    Public Const db_fld_Se_Password As String = "Password"

    Public Const db_tbl_MapServerTypes As String = "MapServerTypeCV"
    Public Const db_fld_MST_Type As String = "MapServerType"
    Public Const db_fld_MST_Desc As String = "Description"
    Public Const db_fld_MST_SampServConn As String = "SampleServerConnection"
    Public Const db_fld_MST_SampMapConn As String = "SampleMapConnection"
    Public Const db_fld_MST_HasDomain As String = "HasDomain"
    Public Const db_fld_MST_HasUsername As String = "HasUsername"

    Public Const db_tbl_Contacts As String = "Contacts"
    Public Const db_fld_Co_FirstName As String = "FirstName"
    Public Const db_fld_Co_LastName As String = "LastName"
    Public Const db_fld_Co_OrganizationName As String = "OrganizationName"
    Public Const db_fld_Co_MailingAddress As String = "MailingAddress"
    Public Const db_fld_Co_City As String = "City"
    Public Const db_fld_Co_Area As String = "Area"
    Public Const db_fld_Co_Country As String = "Country"
    Public Const db_fld_Co_PostalCode As String = "PostalCode"
    Public Const db_fld_Co_FaxNumber As String = "FaxNumber"
    Public Const db_fld_Co_PhoneNumber As String = "PhoneNumber"
    Public Const db_fld_Co_EmailAddress As String = "EmailAddress"

    Public Const db_tbl_RegionMetadata As String = "RegionMetadata"
    Public Const db_tbl_DatabaseMetadata As String = "ODMDatabaseMetadata"
    Public Const db_tbl_MapMetadata As String = "MapServiceMetadata"
    Public Const db_tbl_MapServerMetadata As String = "MapServerMetadata"
    Public Const db_fld_Meta_RegionID As String = "RegionID"
    Public Const db_fld_Meta_DatabaseID As String = "DatabaseID"
    Public Const db_fld_Meta_MapID As String = "MapServiceID"
    Public Const db_fld_Meta_ServerID As String = "MapServerID"
    Public Const db_fld_Meta_Title As String = "MetadataTitle"
    Public Const db_fld_Meta_Content As String = "MetadataContent"
    Public Const db_fld_Meta_DisplayOrder As String = "DisplayOrder"

#End Region

#Region " ODM Specifications "

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

    '#Region " Categories "
    '    'Categories
    '    Public Const db_tbl_Categories As String = "Categories" 'Table Name
    '    Public Const db_fld_CatVarid As String = "Variableid" 'M Integer: Primary Key -> Unique id for each Category entry
    '    Public Const db_fld_CatValue As String = "Value" 'M Double -> Numeric Value
    '    Public Const db_fld_CatDesc As String = "CategoryDescription" 'M String: 255 -> Definition of categorical variable value
    '#End Region

    '#Region " DataValues -> formerly Values "
    '    'DataValues
    '    Public Const db_tbl_DataValues As String = "DataValues" 'Table Name
    '    Public Const db_fld_Valid As String = "Valueid" 'M Integer: Primary Key ->Unique id for each Values entry
    '    Public Const db_fld_ValValue As String = "DataValue" 'M Double -> The numeric value.  Holds the Categoryid for categorical data
    '    Public Const db_fld_ValAccuracyStdDev As String = "ValueAccuracy" 'O Double -> Estimated standard deviation
    '    Public Const db_fld_ValDateTime As String = "LocalDateTime" 'M Local date and time of the measurement
    '    Public Const db_fld_ValUTCOffset As String = "UTCOffset" 'M Offset in hours from UTC time
    '    Public Const db_fld_ValUTCDateTime As String = "DateTimeUTC" 'M UTC date and time of the measurement
    '    Public Const db_fld_ValSiteid As String = "Siteid" 'M Integer -> Linked to Sites.Siteid
    '    Public Const db_fld_ValVarid As String = "Variableid" 'M Integer -> Linked to Variables.Variableid
    '    Public Const db_fld_ValOffsetValue As String = "OffsetValue" 'O Double -> distance from a datum/control point at which the value was observed
    '    Public Const db_fld_ValOffsetTypeid As String = "OffsetTypeid" 'O Integer -> Linked to OffsetTypes.OffsetTypeid
    '    Public Const db_fld_ValCensorCode As String = "CensorCode" 'O String: 50 -> CV.  Whether the data is censored
    '    Public Const db_fld_ValQualifierid As String = "Qualifierid" 'O Integer -> Linked to Qualifiers.Qualifierid
    '    Public Const db_fld_ValMethodid As String = "Methodid" 'M Integer -> Linked to Methods.Methodid
    '    Public Const db_fld_ValSourceid As String = "Sourceid" 'M Integer -> Linked to Sources.Sourceid
    '    Public Const db_fld_ValSampleid As String = "Sampleid" 'O Integer -> Linked to Samples.Sampleid
    '    Public Const db_fld_ValDerivedFromid As String = "DerivedFromid" 'O Integer -> Linked to DerivedFrom.DerivedFromid
    '    Public Const db_fld_ValQCLevel As String = "QualityControlLevelid" 'O Integer -> Linked to QualityControlLevels.QualityControlLevel

    '#Region " Values/Programmer Defined Variables "
    '    Public Const db_val_ValCensorCode_lt As String = "'lt'"
    '    Public Const db_outFld_ValDTMonth As String = "DateMonth"
    '    Public Const db_outFld_ValDTYear As String = "DateYear"
    '    Public Const db_outFld_ValDTDay As String = "DateDay"
    '    'Field names readable -> for Data Editing Tab Table
    '    Public Const db_fldName_Valid As String = "Value id" 'M Integer: Primary Key ->Unique id for each Values entry
    '    Public Const db_fldName_ValValue As String = "Data Value" 'M Double -> The numeric value.  Holds the Categoryid for categorical data
    '    Public Const db_fldName_ValAccuracyStdDev As String = "Value Accuracy" 'O Double -> Estimated standard deviation
    '    Public Const db_fldName_ValDateTime As String = "Local Date and Time" 'M Local date and time of the measurement
    '    Public Const db_fldName_ValUTCOffset As String = "UTC Offset" 'M Offset in hours from UTC time
    '    Public Const db_fldName_ValUTCDateTime As String = "UTC Date and Time" 'M UTC date and time of the measurement
    '    Public Const db_fldName_ValOffsetValue As String = "Offset Value" 'O Double -> distance from a datum/control point at which the value was observed
    '    Public Const db_fldName_ValOffsetTypeid As String = "Offset Type id" 'O Integer -> Linked to OffsetTypes.OffsetTypeid
    '    Public Const db_fldName_ValCensorCode As String = "Censor Code" 'O String: 50 -> CV.  Whether the data is censored
    '    Public Const db_fldName_ValQualifierid As String = "Qualifier id" 'O Integer -> Linked to Qualifiers.Qualifierid
    '    Public Const db_fldName_ValSampleid As String = "Sample id" 'O Integer -> Linked to Samples.Sampleid
    '    Public Const db_fldName_ValDerivedFromid As String = "Derived From id" 'O Integer -> Linked to DerivedFrom.DerivedFromid
    '#End Region

    '#End Region

    '#Region " DerivedFrom "
    '    'DerivedFrom
    '    Public Const db_tbl_DerivedFrom As String = "DerivedFrom" 'Table Name
    '    Public Const db_fld_DFid As String = "DerivedFromid" 'M Integer -> Unique id for each group of Derived From entries
    '    Public Const db_fld_DFValueid As String = "Valueid" 'M Integer -> Corresponds to the value id(s) the Derived Value came from

    '#Region " Values/Programmer Defined Variables "
    '    Public Const db_val_DerivedFromid_Removed As Integer = -1
    '    Public Const db_val_DerivedFromid_Invalid As Integer = -2
    '#End Region

    '#End Region

    '#Region " GroupDescriptions "
    '    'GroupDescriptions
    '    Public Const db_tbl_GroupDesc As String = "GroupDescriptions" 'Table Name
    '    Public Const db_fld_GDGroupid As String = "Groupid" 'M Integer: Primary Key -> Unique id for each GroupDescriptions entry
    '    Public Const db_fld_GDDesc As String = "GroupDescription" 'O String: 255 -> Text description of the group
    '#End Region

    '#Region " Groups "
    '    'Groups 
    '    Public Const db_tbl_Groups As String = "Groups" 'Table Name
    '    Public Const db_fld_Groupid As String = "Groupid" 'M Integer -> Unique id for each group of Values
    '    Public Const db_fld_GroupValueid As String = "Valueid" 'M Integer -> Corresponds to the value id of each value in the group
    '#End Region

    '#Region " ISOMetaData "
    '    'ISOMetaData
    '    Public Const db_tbl_ISOMetaData As String = "ISOMetaData" 'Table Name
    '    Public Const db_fld_IMDMetaid As String = "MetaDataid" 'M Integer: Primary Key -> Unique id for each ISOMetaData entry
    '    Public Const db_fld_IMDTopicCat As String = "TopicCategory" 'M String: 50 -> Topic category keyword that gives the broad ISO19115 metadata topic category for data from this source.  CV
    '    Public Const db_fld_IMDTitle As String = "Title" 'M String: 255 -> Title of data from a specific data source
    '    Public Const db_fld_IMDAbstract As String = "Abstract" 'M String: 255 -> Abstract of data from a specific data source
    '    Public Const db_fld_IMDProfileVs As String = "ProfileVersion" 'M String: 50 -> Abstract of data from a specific data source
    '    Public Const db_fld_IMDMetaLink As String = "MetadataLink" 'O String: H -> Link to additional metadata reference material
    '#End Region

    '#Region " LabMethods "
    '    'LabMethods
    '    Public Const db_tbl_LabMethods As String = "LabMethods" 'Table Name
    '    Public Const db_fld_LMid As String = "LabMethodid" 'M Integer: Primary Key -> Unique id for each LabMethods entry
    '    Public Const db_fld_LMLabName As String = "LabName" 'M String: 255 -> Name of the laboratory responsible for processing the sample
    '    Public Const db_fld_LMLabOrg As String = "LabOrganization" 'M String: 255 -> Organization responsible for sample analysis
    '    Public Const db_fld_LMName As String = "LabMethodName" 'M String: 255 -> Name of the method and protocols used for sample analysis
    '    Public Const db_fld_LMDesc As String = "LabMethodDescription" 'M String: 255 -> Description of the method and protocols used for sample analysis
    '    Public Const db_fld_LMLink As String = "LabMethodLink" 'O String: H -> Link to additional reference material to the analysis method
    '#End Region

    '#Region " Methods "
    '    'Methods
    '    Public Const db_tbl_Methods As String = "Methods" 'Table Name
    '    Public Const db_fld_Methid As String = "Methodid" 'M Integer: Primary Key -> Unique id for each Methods entry
    '    Public Const db_fld_MethDesc As String = "MethodDescription" 'M String: 255 -> Text descriptionof each method including Quality Assurance and Quality Control procedures
    '    Public Const db_fld_MethLink As String = "MethodLink" 'O String: H -> Link to additional reference material on the method
    '#End Region

    '#Region " OffsetTypes "
    '    'OffsetTypes
    '    Public Const db_tbl_OffsetTypes As String = "OffsetTypes" 'Table Name
    '    Public Const db_fld_OTid As String = "OffsetTypeid" 'M Integer: Primary Key ->Unique id for each OffsetTypes entry 
    '    Public Const db_fld_OTUnitsid As String = "OffsetUnitsid" 'M Integer -> Linked to Units.Unitsid
    '    Public Const db_fld_OTDesc As String = "OffsetDescription" 'M String: 255 -> Full text description of the offset type
    '#End Region

    '#Region " Qualifiers "
    '    'Qualifiers
    '    Public Const db_tbl_Qualifiers As String = "Qualifiers" 'Table Name
    '    Public Const db_fld_Qlfyid As String = "Qualifierid" 'M Integer: Primary Key -> Unique id for each Qualifiers entry
    '    Public Const db_fld_QlfyCode As String = "QualifierCode" 'O String: 50 -> Text code used by organization that collects the data
    '    Public Const db_fld_QlfyDesc As String = "QualifierDescription" 'M String: 255 -> Text of the data qualifying comment
    '#End Region

    '#Region " QualityControlLevels "
    '    'QualityControlLevels
    '    Public Const db_tbl_QCLevels As String = "QualityControlLevels" ''Table Name
    '    Public Const db_fld_QCLQCLevel As String = "QualityControlLevelid" 'M Integer: Primary Key -> Pre-defined id from 0 to 5
    '    Public Const db_fld_QCLDefinition As String = "Definition" 'M String: 255 -> Definition of Quality Control Level
    '    Public Const db_fld_QCLExplanation As String = "Explanation" 'M String: 500 -> Explanation of Quality Control Level

    '#Region " DB Loaded Constants "
    '    Public db_val_QCLDef_Level(,) As String 'Pre-loaded Quality control level definitions for each id
    '#End Region

    '#End Region

    '#Region " Samples "
    '    'Samples
    '    Public Const db_tbl_Samples As String = "Samples" 'Table Name
    '    Public Const db_fld_Sampleid As String = "Sampleid" 'M Integer: Primary Key -> Unique id for each Samples entry
    '    Public Const db_fld_SampleType As String = "SampleType" 'M String: 50 -> CV specifying the sample type
    '    Public Const db_fld_SampleLabCode As String = "LabSampleCode" 'M String: 50 -> Code or label used to identify and track lab sample/sample-container (e.g. bottle) during lab analysis
    '    Public Const db_fld_SampleMethodid As String = "LabMethodid" 'M Integer -> Linked to LabMethods.LabMethodid
    '#End Region

#Region " SeriesCatalog "
    'SeriesCatalog
    Public Const db_tbl_SeriesCatalog As String = "SeriesCatalog" 'Table Name
    Public Const db_fld_SCSeriesid As String = "Seriesid" 'P Integer: Primary Key -> Unique id for each SeriesCatalog entry
    Public Const db_fld_SCSiteid As String = "Siteid" 'P Integer -> Linked to Sites.Siteid
    Public Const db_fld_SCSiteCode As String = "SiteCode" 'P String: 50 -> Site identifier used by organization that collects the data
    Public Const db_fld_SCSiteName As String = "SiteName" 'P String: 255 -> Full text name of sampling location
    Public Const db_fld_SCVarid As String = "Variableid" 'P Integer -> Linked to Variables.Variableid
    Public Const db_fld_SCVarCode As String = "VariableCode" 'P String: 50 -> Variable identifier used by the organization that collects the data
    Public Const db_fld_SCVarName As String = "VariableName" 'P String: 255 -> Name of the variable from the variables table
    Public Const db_fld_SCVarUnitsid As String = "VariableUnitsid" 'P Integer -> Linked to Units.Unitsid
    Public Const db_fld_SCVarUnitsName As String = "VariableUnitsName" 'P String: 255 -> Full text name of the variable units from the UnitsName field in the Units Table
    Public Const db_fld_SCSampleMed As String = "SampleMedium" 'P String: 50 -> 
    Public Const db_fld_SCValueType As String = "ValueType" 'P String: 50 -> Text value indicating what type of value is being recorded
    Public Const db_fld_SCTimeSupport As String = "TimeSupport" 'P Double -> Numerical value that indicates the time support (or temporal footprint). 0 = instantaneous. otherwise = time over which values are averaged. 
    Public Const db_fld_SCTimeUnitsid As String = "TimeUnitsid" 'P Integer -> Linked to Units.Unitsid
    Public Const db_fld_SCTimeUnitsName As String = "TimeUnitsName" 'P String: 255 -> Full text name of the time support units from Units.UnitsName 
    Public Const db_fld_SCDataType As String = "DataType" 'P String: 50 -> CV. Data type that identifies the data as one of several types from the DataTypeCV.
    Public Const db_fld_SCGenCat As String = "GeneralCategory" 'P String: 50 -> CV. General category of the variable
    Public Const db_fld_SCMethodid As String = "Methodid" 'P Integer -> Corresponds to the id of the Method for the Series
    Public Const db_fld_SCMethodDesc As String = "MethodDescription" 'P String: 255 -> Corresponds to the Method Description for the Series
    Public Const db_fld_SCQCLevel As String = "QualityControlLevelid"   'P Integer -> Corresponds to the Quality Control Level of the Series
    Public Const db_fld_SCSourceid As String = "Sourceid" 'P Integer -> Corresponds to the id of the Source for the Series
    Public Const db_fld_SCOrganization As String = "Organization" 'P String: 50 -> Corresponds to the Organization for the Series
    Public Const db_fld_SCSourceDesc As String = "SourceDescription" 'P String: 255 -> Corresponds to the Source Description for the Series
    Public Const db_fld_SCBeginDT As String = "BeginDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCEndDT As String = "EndDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCBeginDTUTC As String = "BeginDateTimeUTC" 'P DateTime -> The First UTC Date
    Public Const db_fld_SCEndDTUTC As String = "EndDateTimeUTC" 'P DateTime -> The Last UTC Date
    Public Const db_fld_SCValueCount As String = "ValueCount" 'P Integer -> The number of vaues in the series (Siteid & Variableid)
#End Region

#Region " Sites "
    'Sites
    Public Const db_tbl_Sites As String = "Sites" 'Table Name
    Public Const db_fld_Siteid As String = "Siteid" 'M Integer: Primary Key -> Unique id for each Sites entry
    Public Const db_fld_SiteCode As String = "SiteCode" 'O String: 50 -> Code used by organization that collects the data
    Public Const db_fld_SiteName As String = "SiteName" 'O String: 255 -> Full name of sampling location
    Public Const db_fld_SiteLat As String = "Latitude" 'M Double -> Latitude in degrees w/ Decimals
    Public Const db_fld_SiteLong As String = "Longitude" 'M Double -> Longitude in degrees w/ Decimals
    Public Const db_fld_SiteLatLongDatumid As String = "LatLongDatumid" 'M Integer -> Linked to SpatialReferences.SpatialReferenceid
    Public Const db_fld_SiteElev_m As String = "Elevation_m" 'M Double -> Elevation of sampling location in meters.  
    Public Const db_fld_SiteVertDatum As String = "VerticalDatum" 'M String: 50 -> CV. Vertical Datum 
    Public Const db_fld_SiteLocX As String = "LocalX" 'O Double -> Local Projection X Coordinate
    Public Const db_fld_SiteLocY As String = "LocalY" 'O Double -> Local Projection Y Coordinate
    Public Const db_fld_SiteLocProjid As String = "LocalProjectionid" 'O Integer -> Linked to SpatialReferences.SpatialReferenceid
    Public Const db_fld_SitePosAccuracy_m As String = "PosAccuracy_m" 'O Double -> Value giving the acuracy with which the positional information is specified.  in meters
    Public Const db_fld_SiteState As String = "State" 'O String: 50 -> Name of state in which the sampling station is located
    Public Const db_fld_SiteCounty As String = "County" 'O String: 50 -> Name of County in which the sampling station is located
    Public Const db_fld_SiteComments As String = "Comments" 'O String: 500 -> Comments related to the site
#End Region

    '#Region " Sources "
    '    'Sources
    '    Public Const db_tbl_Sources As String = "Sources" 'Table Name
    '    Public Const db_fld_Srcid As String = "Sourceid" 'M Integer: Primary Key -> Unique id for each Sources entry
    '    Public Const db_fld_SrcOrg As String = "Organization" 'M String: 50 -> Name of organization that collected the data itself.  not who held it
    '    Public Const db_fld_SrcDesc As String = "SourceDescription" 'M String: 255 -> Full text description of the source of the data
    '    Public Const db_fld_SrcLink As String = "SourceLink" 'M String: H -> Link to original data file and associated metadata stored in the digital library or URL of data source
    '    Public Const db_fld_SrcContactName As String = "ContactName" 'M String: 50 -> Name of Contact Person for data source
    '    Public Const db_fld_SrcPhone As String = "Phone" 'M String: 50 -> Phone number for contact person
    '    Public Const db_fld_SrcEmail As String = "Email" 'M String: 50 -> email address for contact person
    '    Public Const db_fld_SrcAddress As String = "Address" 'M String: 255 -> Address for contact person
    '    Public Const db_fld_SrcCity As String = "City" 'M String: 50 -> city for contact person
    '    Public Const db_fld_SrcState As String = "State" 'M String: 50 -> state for contact person. 2 letter abreviations for "state, US", give full name for other countries
    '    Public Const db_fld_SrcZip As String = "ZipCode" 'M String: 50 -> US zip code or country postal code
    '    Public Const db_fld_SrcMetaid As String = "MetaDataid" 'M Integer -> ISOMetaData.MetaDataid
    '#End Region

    '#Region " SpatialReferences "
    '    'SpatialReferences
    '    Public Const db_tbl_SpatialRefs As String = "SpatialReferences" 'Table Name
    '    Public Const db_fld_SRid As String = "SpatialReferenceid" 'M Integer: Primary Key -> Unique id for each SpatialReferences entry
    '    Public Const db_fld_SRSRSid As String = "SRSid" 'O Integer -> id for Spatial Reference System @ http://epsg.org/
    '    Public Const db_fld_SRSRSName As String = "SRSName" 'M String: 255 -> Name of spatial reference system
    '    Public Const db_fld_SRIsGeo As String = "IsGeographic" 'M Boolean -> Whether it uses geographic coordinates (Lat., Long.)
    '    Public Const db_fld_SRNotes As String = "Notes" 'O String: 500 -> Descriptive information about reference system
    '#End Region

    '#Region " Units "
    '    'Units
    '    Public Const db_tbl_Units As String = "Units" 'Table Name
    '    Public Const db_fld_Unitsid As String = "Unitsid" 'M Integer: Primary Key -> Unique id for each Units entry
    '    Public Const db_fld_UnitsName As String = "UnitsName" 'M String: 255 -> Full name of the units
    '    Public Const db_fld_UnitsType As String = "UnitsType" 'M String: 50 -> Dimensions of the units
    '    Public Const db_fld_UnitsAbrv As String = "UnitsAbbreviation" 'M String: 50 -> Abbreviation for the units

    '#Region " Values/Programmer Defined Variables "
    '    Public Const db_val_UnitsTimeSupport_MilliSecond As String = "millisecond"
    '    Public Const db_val_UnitsTimeSupport_Second As String = "second"
    '    Public Const db_val_UnitsTimeSupport_Minute As String = "minute"
    '    Public Const db_val_UnitsTimeSupport_Hour As String = "hour"
    '    Public Const db_val_UnitsTimeSupport_Day As String = "day"
    '#End Region

    '#End Region

    '#Region " Variables "
    '    'Variables
    '    Public Const db_tbl_Variables As String = "Variables" 'Table Name
    '    Public Const db_fld_Varid As String = "Variableid" 'M Integer: Primary Key -> Unique id for each Variables entry
    '    Public Const db_fld_VarCode As String = "VariableCode" 'O String: 50 -> Code used by the organization that collects the data
    '    Public Const db_fld_VarName As String = "VariableName" 'M String: 255 -> CV. Name of the variable that was measured/observed/modeled
    '    Public Const db_fld_VarUnitsid As String = "VariableUnitsid" 'O Integer -> Linked to Units.Unitsid
    '    Public Const db_fld_VarSampleMed As String = "SampleMedium" 'M String: 50 -> CV. The medium of the sample
    '    Public Const db_fld_VarValueType As String = "ValueType" 'M String: 50 -> CV. Text value indicating what type of value is being recorded
    '    Public Const db_fld_VarIsRegular As String = "IsRegular" 'M Boolean -> Whether the values are from a regularly sampled time series
    '    Public Const db_fld_VarTimeSupport As String = "TimeSupport" 'M Double -> Numerical value indicating the temporal footprint over which values are averaged.  0 = instantaneous
    '    Public Const db_fld_VarTimeUnitsid As String = "TimeUnitsid" 'O Integer -> Linked to Units.Unitsid
    '    Public Const db_fld_VarDataType As String = "DataType" 'M STring: 50 -> CV. text value that identifies the data as one of several types
    '    Public Const db_fld_VarGenCat As String = "GeneralCategory" 'M STring: 50 -> CV. General category of the values
    '    Public Const db_fld_VarNoDataVal As String = "NoDataValue" 'M Double -> Numeric value used to encode no data values for this variable
    '#End Region

    '#Region " Controlled Vocabulary Table Definitions "

    '    'table names
    '    Public Const db_tbl_VariableNameCV As String = "VariableNameCV"
    '    Public Const db_tbl_ValueTypeCV As String = "ValueTypeCV"
    '    Public Const db_tbl_CensorCodeCV As String = "CensorCodeCV"
    '    Public Const db_tbl_SampleMediumCV As String = "SampleMediumCV"
    '    Public Const db_tbl_GeneralCategoryCV As String = "GeneralCategoryCV"
    '    Public Const db_tbl_TopicCategoryCV As String = "TopicCategoryCV"
    '    Public Const db_tbl_DataTypeCV As String = "DataTypeCV"
    '    Public Const db_tbl_SampleTypeCV As String = "SampleTypeCV"
    '    Public Const db_tbl_VerticalDatumCV As String = "VerticalDatumCV"

    '    'fields
    '    Public Const db_fld_CV_Term As String = "Term"
    '    Public Const db_fld_CV_Definition As String = "Definition"

    '    'values
    '    Public Const db_val_VTCVTerm_DerivedValue As String = "Derived Value" 'the term for a 'Derived Value' from the ValueTypeCV table
    '    Public Const db_val_DTCVTerm_Maximum As String = "Maximum" 'the term for the Maximum type from the DataTypeCV table
    '    Public Const db_val_DTCVTerm_Minimum As String = "Minimum" 'the term for the Minimum type from the DataTypeCV table
    '    Public Const db_val_DTCVTerm_Average As String = "Average" 'the term for the Average type from the DataTypeCV table
    '    Public Const db_val_CCCVTerm_NULL As String = "nc" 'the term for a NULL Censor Code value from the CensorCodeCV table

    '#End Region

    '#Region " Export Query Expressions "
    '    'Geographic Location
    '    Public Const db_expr_Geo As String = "GeographicCoordinates"
    '    Public Const db_expr_Geo_SRSid As String = "GeoSRSid"
    '    Public Const db_expr_Geo_SRSName As String = "GeoSRSName"
    '    Public Const db_expr_Geo_IsGeo As String = "GeoIsGeo"
    '    Public Const db_expr_Geo_Notes As String = "GeoNotes"

    '    'Local Location
    '    Public Const db_expr_Local As String = "LocalCoordinates"
    '    Public Const db_expr_Local_SRSid As String = "LocalSRSid"
    '    Public Const db_expr_Local_SRSName As String = "LocalSRSName"
    '    Public Const db_expr_Local_IsGeo As String = "LocalIsGeo"
    '    Public Const db_expr_Local_Notes As String = "LocalNotes"

    '    'Variable Units
    '    Public Const db_expr_VarUnits As String = "VariableUnits"
    '    Public Const db_expr_VarUnits_Name As String = "VariableUnitsName"
    '    Public Const db_expr_VarUnits_Type As String = "VariableUnitsType"
    '    Public Const db_expr_VarUnits_Abbr As String = "VariableUnitsAbbreviation"

    '    'Time Units
    '    Public Const db_expr_TimeUnits As String = "TimeUnits"
    '    Public Const db_expr_TimeUnits_Name As String = "TimeUnitsName"
    '    Public Const db_expr_TimeUnits_Type As String = "TimeUnitsType"
    '    Public Const db_expr_TimeUnits_Abbr As String = "TimeUnitsAbbreviation"

    '    'Offset Units
    '    Public Const db_expr_OffsetUnits As String = "OffsetUnits"
    '    Public Const db_expr_OffsetUnits_Name As String = "OffsetUnitsName"
    '    Public Const db_expr_OffsetUnits_Type As String = "OffsetUnitsType"
    '    Public Const db_expr_OffsetUnits_Abbr As String = "OffsetUnitsAbbreviation"

    '    'Contact Information
    '    Public Const db_expr_contact_Name As String = "ContactName"
    '    Public Const db_expr_contact_Phone As String = "ContactPhone"
    '    Public Const db_expr_contact_Email As String = "ContactEmail"
    '    Public Const db_expr_contact_Address As String = "ContactAddress"
    '    Public Const db_expr_contact_City As String = "ContactCity"
    '    Public Const db_expr_contact_State As String = "ContactState"
    '    Public Const db_expr_contact_Zip As String = "ContactZipCode"

    '#End Region
#End Region

    Protected m_connectionString As String
    Protected m_regionID As Integer

    Public Sub New()
        m_connectionString = ConfigurationManager.ConnectionStrings("CapabilitiesDatabase").ConnectionString
        Dim regionName As String = ConfigurationManager.AppSettings("DefaultRegion")
        m_regionID = GetRegionID(regionName)
    End Sub

    Public Sub New(ByVal Region As String)
        m_connectionString = ConfigurationManager.ConnectionStrings("CapabilitiesDatabase").ConnectionString
        Dim regionName As String = Region
        m_regionID = GetRegionID(regionName)
    End Sub

#Region "HydroServer Functions"
    Public Function GetRegionID(ByVal regionName As String) As Integer
        Dim query As String = "SELECT " & db_fld_Re_ID & " FROM " & db_tbl_Regions & " WHERE " & db_fld_Re_DisplayName & " = '" & regionName & "'"
        Dim table As Data.DataTable = OpenTable(query)
        If table.Rows.Count < 1 Then
            Throw New Exception("INVALID Region Name")
        Else
            Return table.Rows(0).Item(db_fld_Re_ID)
        End If
    End Function
    Public Function GetMapServers() As DataTable
        Dim query As String = "SELECT DISTINCT " & _
        db_tbl_Servers & ".* FROM " & _
        db_tbl_Servers & " LEFT JOIN " & _
        db_tbl_Maps & " ON " & _
        db_tbl_Servers & "." & db_fld_Se_ID & " = " & _
        db_tbl_Maps & "." & db_fld_Mp_ServerID & " LEFT JOIN " & _
        db_tbl_RegionMaps & " ON " & _
        db_tbl_Maps & "." & db_fld_Mp_ID & " = " & _
        db_tbl_RegionMaps & "." & db_fld_RM_MapID & "  WHERE (" & _
        db_tbl_RegionMaps & "." & db_fld_RM_RegionID & " = '" & m_regionID & "')"

        Dim data As DataTable = OpenTable(query)

        If (data Is Nothing) OrElse (data.Rows.Count <= 0) Then
            Return New DataTable("EMPTY")
        Else
            Return data
        End If
    End Function
    Public Function GetRegionMaps() As DataTable
        Dim query As String = "SELECT DISTINCT " & _
        db_tbl_RegionMaps & ".*, " & db_tbl_Maps & ".* FROM " & _
        db_tbl_RegionMaps & " LEFT JOIN " & _
        db_tbl_Maps & " ON " & _
        db_tbl_RegionMaps & "." & db_fld_RM_MapID & " = " & _
        db_tbl_Maps & "." & db_fld_Mp_ID & "  WHERE (" & _
        db_tbl_RegionMaps & "." & db_fld_RM_RegionID & " = '" & m_regionID & "') ORDER BY " & _
        db_tbl_RegionMaps & "." & db_fld_RM_DisplayOrder & " ASC"

        Dim data As DataTable = OpenTable(query)

        If (data Is Nothing) OrElse (data.Rows.Count <= 0) Then
            Return New DataTable("EMPTY")
        Else
            Return data
        End If
    End Function

    ''' <summary>
    ''' Gets a StringDictionary containing Database_Name:Connection_String from the ODM_Databases database
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetConnections() As System.Collections.Generic.Dictionary(Of String, ODMDatabase)
        Try
            Dim Connections As New System.Collections.Generic.Dictionary(Of String, ODMDatabase)
            Dim data As DataTable = OpenTable("SELECT " & _
            db_tbl_Databases & ".*, DisplayName, DisplayOrder FROM " & _
            db_tbl_Databases & " RIGHT JOIN " & _
            db_tbl_RegionDatabases & " ON " & _
            db_tbl_Databases & "." & db_fld_Db_ID & " = " & _
            db_tbl_RegionDatabases & "." & db_fld_RD_DatabaseID & " WHERE " & _
            db_tbl_RegionDatabases & "." & db_fld_RD_RegionID & " = '" & m_regionID & "' ORDER BY RegionDatabases.DisplayOrder ASC")
            Dim Key As String
            Dim Value As ODMDatabase
            Dim i As Integer
            For Each row As DataRow In data.Rows
                'Data Source=(local)\SQLExpress;Initial Catalog=ODM_Databases;User id=USERID;Password=PASSWORD;
                Key = row.Item("DatabaseName").ToString
                Value = New ODMDatabase

                Value.DisplayName = row.Item("DisplayName")
                Value.DisplayOrder = row.Item("DisplayOrder")
                Value.Connection = "Data Source=" & row.Item("ServerAddress").ToString & _
                ";Initial Catalog=" & row.Item("DatabaseName").ToString & _
                ";User id=" & row.Item("ODMUser").ToString & _
                ";Password=" & row.Item("ODMPassword").ToString & ";"

                i = 1
                While (Connections.ContainsKey(Key))
                    Key = row.Item("DatabaseName").ToString & i
                    i += 1
                End While
                Connections.Add(Key, Value)
            Next row
            Return Connections
        Catch ex As Exception
            Throw New Exception("Error Occured in DatabaseFunctions.GetConnections" & vbCrLf & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Returns the connection string for a specified database name from the ODM_Databases database
    ''' </summary>
    ''' <param name="dbName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetConnectionString(Optional ByVal dbName As String = "") As String
        Try
            Dim connectionString As String
            If (dbName = "") Then
                connectionString = ConfigurationManager.ConnectionStrings.Item("CapabilitiesDatabase").ConnectionString
            Else
                Dim Connections As System.Collections.Generic.Dictionary(Of String, ODMDatabase) = GetConnections()
                If (Connections.ContainsKey(dbName)) Then
                    connectionString = Connections.Item(dbName).Connection
                Else
                    connectionString = ConfigurationManager.ConnectionStrings.Item(dbName).ConnectionString
                End If
            End If

            Return connectionString
        Catch ex As Exception
            Throw New Exception("Error Occured in DatabaseFunctions.GetConnectionString" & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function GetConnectionImage(ByVal conn As String) As String
        Dim data As DataTable = OpenTable("SELECT " & _
        db_tbl_Databases & ".* FROM " & _
        db_tbl_Databases & " RIGHT JOIN " & _
        db_tbl_RegionDatabases & " ON " & _
        db_tbl_Databases & "." & db_fld_Db_ID & " = " & _
        db_tbl_RegionDatabases & "." & db_fld_RD_DatabaseID & " WHERE " & _
        db_tbl_RegionDatabases & "." & db_fld_RD_RegionID & " = '" & m_regionID & "'")
        Dim connElements() As String = conn.Split(";")
        For Each row As DataRow In data.Rows
            If (LCase(connElements(0)) = LCase("Data Source=" & row.Item("ServerAddress").ToString)) AndAlso _
                (LCase(connElements(1)) = LCase("Initial Catalog=" & row.Item("DatabaseName").ToString)) Then
                Return row.Item(db_fld_Db_Marker).ToString
            End If
        Next row
        Return ""
    End Function

#End Region

    ''' <summary>
    ''' Returns a dataTable of the query data.
    ''' </summary>
    ''' <param name="sqlQuery">sql Query to retreive the data with</param>
    ''' <param name="DBName">The name of the database to connect to</param>
    ''' <returns>The dataTable of data retreived from the database using SqlQuery.</returns>
    ''' <remarks></remarks>
    Public Function OpenTable(ByVal sqlQuery As String, Optional ByVal DBName As String = "") As DataTable
        'create a flow table
        Dim table As New DataTable() 'the table of data to return
        Dim dataAdapter As New SqlClient.SqlDataAdapter  'the dataAdapter to fill the table
        Dim objSqlConnection As SqlConnection = Nothing
        Try
            Dim connectionString As String = GetConnectionString(DBName)
            objSqlConnection = New SqlConnection(connectionString)
            objSqlConnection.Open()
            'connect to the Database
            dataAdapter = New SqlClient.SqlDataAdapter(sqlQuery, objSqlConnection)

            'get the table from the database
            dataAdapter.Fill(table)
            objSqlConnection.Close()
            If Not (dataAdapter Is Nothing) Then
                dataAdapter.Dispose()
                'dataAdapter = Nothing
            End If
            Return table
        Catch ex As System.Exception
            If Not (table Is Nothing) Then
                table.Dispose()
                table = Nothing
            End If
            If Not (dataAdapter Is Nothing) Then
                dataAdapter.Dispose()
                dataAdapter = Nothing
            End If
            If Not (objSqlConnection Is Nothing) Then
                If (objSqlConnection.State <> ConnectionState.Closed) Then
                    objSqlConnection.Close()
                End If
                objSqlConnection = Nothing
            End If
            Throw New Exception("Error Occured in DatabaseFunctions.OpenTable" & vbCrLf & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Executes a no-result query on the database
    ''' </summary>
    ''' <param name="objSqlCommand">the sql command to excute</param>
    ''' <param name="DBName">the database name to query</param>
    ''' <remarks></remarks>
    Public Sub ExecuteNonQuery(ByVal objSqlCommand As SqlCommand, Optional ByVal DBName As String = "")
        Try
            Dim connectionString As String = GetConnectionString(DBName)
            Dim objSqlConnection As New SqlConnection(connectionString)
            objSqlConnection.Open()

            objSqlCommand.Connection = objSqlConnection
            objSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error Occured in DatabaseFunctions.ExecuteNonQuery" & vbCrLf & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Executes a no-result query on the database
    ''' </summary>
    ''' <param name="strSQL">the sql command to execute</param>
    ''' <param name="DBName">the database name to query</param>
    ''' <remarks></remarks>
    Public Sub ExecuteNonQuery(ByVal strSQL As String, Optional ByVal DBName As String = "")
        Try
            Dim objSqlCommand As SqlCommand

            objSqlCommand = New SqlCommand(strSQL)
            ExecuteNonQuery(objSqlCommand, DBName)
        Catch ex As Exception
            Throw New Exception("Error Occured in DatabaseFunctions.ExecuteNonQuery" & vbCrLf & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' formats a vb date value for insert into a sql server database, with the required ' ' marks
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FormatDateForQueryFromDB(ByVal d As Date) As String
        Try
            'Formats the date according to what type of data base connection is selected
            ' Sql puts quotes and oledb puts # around the date
            'Inputs:  d -> the date to format
            'Outputs: the correctly formatted date

            'Format the Date for an SQL Database
            Return "'" & d.ToString & "'"
        Catch ex As Exception
            Throw New Exception("Error Occured in DatabaseFunctions.FormatDateForQueryFromDB" & vbCrLf & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' formats a parameter value for a query without the required ' ' marks
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FormatParameter(ByVal val As String) As String
        Try
            '    'Formats the date according to what type of data base connection is selected
            '    ' Sql puts quotes and oledb puts # around the date
            '    'Inputs:  d -> the date to format
            '    'Outputs: the correctly formatted date

            '    'Format the string for an SQL Database
            Return val.Replace("'", "\'")
        Catch ex As Exception
            Throw New Exception("Error Occured in DatabaseFunctions.FormatParameter" & vbCrLf & ex.Message)
        End Try
    End Function

End Class
