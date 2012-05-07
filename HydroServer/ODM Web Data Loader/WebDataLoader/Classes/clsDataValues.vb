Imports System.Data.Common
Imports System.Linq
Imports System.Collections
Imports System.Collections.Generic

Class clsDataValues
    Inherits clsFile

#Region " Database Field Constants "

#Region " DataValues "
    'DataValues
    Public Const db_tbl_DataValues As String = "DataValues" 'Table Name
    Public Const db_fld_ValueID As String = "ValueID" 'M Integer: Primary Key -> Unique ID for each data value
    Public Const db_fld_DataValue As String = "DataValue" 'M Double -> The numeric value of the observation
    Public Const db_fld_ValueAccuracy As String = "ValueAccuracy" 'O Double -> Accuracy of data value
    Public Const db_fld_LocalDateTime As String = "LocalDateTime" 'M DateTime -> Date on which the observation was made
    Public Const db_fld_UTCOffset As String = "UTCOffset" 'M Double -> UTCOffset associated with the data value
    Public Const db_fld_DateTimeUTC As String = "DateTimeUTC" 'M DateTime -> UTC Date on which the observation was made
    Public Const db_fld_SiteID As String = "SiteID" 'M Integer -> SiteID of the site at which the observation was made.  Linked to Sites.SiteID
    Public Const db_fld_VariableID As String = "VariableID" 'M Integer -> VariableID of the observation variable.  Linked to Variables.VariableID
    Public Const db_fld_OffsetValue As String = "OffsetValue" 'O Double -> Value of the offset
    Public Const db_fld_OffsetTypeID As String = "OffsetTypeID" 'O Integer -> OffsetTypeID of the observation offset.  Linked to OffsetTypes.OffsetTypeID 
    Public Const db_fld_CensorCode As String = "CensorCode" 'M String: 50 -> CV.  Text value of the censor code from the CV table
    Public Const db_fld_QualifierID As String = "QualifierID" 'O Integer ->QualifierID of the observation qualifier.  Linked to Qualifiers.QualifierID
    Public Const db_fld_MethodID As String = "MethodID" 'M Integer -> MethodID of the observation method.  Linked to Methods.MethodID
    Public Const db_fld_SourceID As String = "SourceID" 'M Integer -> SourceID of the observation Source.  Linked to Sources.SourceID
    Public Const db_fld_SampleID As String = "SampleID" 'O Integer -> SampleID of the observation.  Linked to Samples.SampleID
    Public Const db_fld_DerivedFromID As String = "DerivedFromID" 'O Integer -> DerivedFromID of the observation.
    Public Const db_fld_QualityControlLevelID As String = "QualityControlLevelID" 'M QualityControlLevelID of the observation.  Linked to QualityControlLevels.QualityControlLevelID
#End Region

#Region " Sites "
    'Sites
    Public Const db_tbl_Sites As String = "Sites" 'Table Name
    Public Const db_fld_SSiteID As String = "SiteID" 'M Integer: Primary Key -> Unique ID for each Sites entry
    Public Const db_fld_SiteCode As String = "SiteCode" 'M String: 50 -> Code used by organization that collects the data
    Public Const db_fld_SiteName As String = "SiteName" 'M String: 255 -> Full name of sampling location
    Public Const db_fld_SiteType As String = "SiteType"
    Public Const db_fld_Latitude As String = "Latitude" 'M Double -> Latitude in degrees w/ Decimals
    Public Const db_fld_Longitude As String = "Longitude" 'M Double -> Longitude in degrees w/ Decimals
    Public Const db_fld_LatLongDatumID As String = "LatLongDatumID" 'M Integer -> Linked to SpatialReferences.SpatialReferenceID
    Public Const db_fld_Elevation_m As String = "Elevation_m" 'O Double -> Elevation of sampling location in meters.  
    Public Const db_fld_VerticalDatum As String = "VerticalDatum" 'O String: 255 -> CV. Vertical Datum 
    Public Const db_fld_LocalX As String = "LocalX" 'O Double -> Local Projection X Coordinate
    Public Const db_fld_LocalY As String = "LocalY" 'O Double -> Local Projection Y Coordinate
    Public Const db_fld_LocalProjectionID As String = "LocalProjectionID" 'O Integer -> Linked to SpatialReferences.SpatialReferenceID
    Public Const db_fld_PosAccuracy_m As String = "PosAccuracy_m" 'O Double -> Value giving the acuracy with which the positional information is specified.  in meters
    Public Const db_fld_State As String = "State" 'O String: 255 -> Name of state in which the sampling station is located
    Public Const db_fld_County As String = "County" 'O String: 255 -> Name of County in which the sampling station is located
    Public Const db_fld_Comments As String = "Comments" 'O String: MAX -> Comments related to the site
#End Region

#Region " Variables "
    'Variables
    Public Const db_tbl_Variables As String = "Variables" 'Table Name
    Public Const db_fld_VVariableID As String = "VariableID" 'M Integer: Primary Key -> Unique ID for each Variables entry
    Public Const db_fld_VariableCode As String = "VariableCode" 'M String: 50 -> Code used by the organization that collects the data
    Public Const db_fld_VariableName As String = "VariableName" 'M String: 255 -> CV. Name of the variable that was measured/observed/modeled
    Public Const db_fld_Speciation As String = "Speciation" 'M String: 255 -> CV. Speciation of the variable
    Public Const db_fld_VariableUnitsID As String = "VariableUnitsID" 'M Integer -> Linked to Units.UnitsID
    Public Const db_fld_SampleMedium As String = "SampleMedium" 'M String: 255 -> CV. The medium of the sample
    Public Const db_fld_ValueType As String = "ValueType" 'M String: 255 -> CV. Text value indicating what type of value is being recorded
    Public Const db_fld_IsRegular As String = "IsRegular" 'M Boolean -> Whether the values are from a regularly sampled time series
    Public Const db_fld_TimeSupport As String = "TimeSupport" 'M Double -> Numerical value indicating the temporal footprint over which values are averaged. 
    Public Const db_fld_TimeUnitsID As String = "TimeUnitsID" 'M Integer -> UnitsID of the time support. Linked to Units.UnitsID
    Public Const db_fld_DataType As String = "DataType" 'M String: 255 -> CV. text value that identifies the data as one of several types
    Public Const db_fld_GeneralCategory As String = "GeneralCategory" 'M STring: 255 -> CV. General category of the values
    Public Const db_fld_NoDataValue As String = "NoDataValue" 'M Double -> Numeric value used to encode no data values for this variable
#End Region

#Region " OffsetTypes "
    'OffsetTypes
    Public Const db_tbl_OffsetTypes As String = "OffsetTypes" 'Table Name
    Public Const db_fld_OOffsetTypeID As String = "OffsetTypeID" 'M Integer: Primary Key -> Unique ID for each offset type
    Public Const db_fld_OffsetUnitsID As String = "OffsetUnitsID" 'M Inteteger -> Linked to UnitsID in Units table
    Public Const db_fld_OffsetDescription As String = "OffsetDescription" 'M String: MAX -> Text description of the offset
#End Region

#Region " Qualifiers "
    'GroupDescriptions
    Public Const db_tbl_Qualifiers As String = "Qualifiers" 'Table Name
    Public Const db_fld_QQualifierID As String = "QualifierID" 'M Integer: Primary Key -> Unique ID for each data qualifier
    Public Const db_fld_QualifierCode As String = "QualifierCode" 'O String: 50 -> Text code for qualifier
    Public Const db_fld_QualifierDescription As String = "QualifierDescription" 'M String: MAX -> Description of data qualifier
#End Region

#Region " Methods "
    'Methods
    Public Const db_tbl_Methods As String = "Methods" 'Table Name
    Public Const db_fld_MMethodID As String = "MethodID" 'M Integer: Primary Key -> Unique ID for each Methods entry
    Public Const db_fld_MethodDescription As String = "MethodDescription" 'M String: MAX -> Description of data collection method
    Public Const db_fld_MethodLink As String = "MethodLink" 'O String: 500 -> Text field holding hyperling to additional method information
#End Region

#Region " LabMethods "
    'ISOMetadata
    Public Const db_tbl_LabMethods As String = "LabMethods"
    Public Const db_fld_LLabMethodID As String = "LabMethodID"
    Public Const db_fld_LabName As String = "LabName"
    Public Const db_fld_LabOrganization As String = "LabOrganization"
    Public Const db_fld_LabMethodName As String = "LabMethodName"
    Public Const db_fld_LabMethodDescription As String = "LabMethodDescription"
    Public Const db_fld_LabMethodLink As String = "LabMethodLink"
#End Region

#Region " Sources "
    'Sources
    Public Const db_tbl_Sources As String = "Sources" 'Table Name
    Public Const db_fld_SSourceID As String = "SourceID" 'M Integer: Primary Key -> Unique ID for each Sources entry
    Public Const db_fld_Organization As String = "Organization" 'M String: 255 -> Text name of the source organization
    Public Const db_fld_SourceDescription As String = "SourceDescription" 'M String: MAX -> Full text descriptio of the data source
    Public Const db_fld_SourceLink As String = "SourceLink" 'O String: 500 -> Text hyperlink to additional source information
    Public Const db_fld_ContactName As String = "ContactName" 'M String: 255 -> Name of source contact
    Public Const db_fld_Phone As String = "Phone" 'M String: 255 -> Text phone number for source contact
    Public Const db_fld_Email As String = "Email" 'M String: 255 -> Text email address of source contact  
    Public Const db_fld_Address As String = "Address" 'M String: 255 -> Text address of source contact 
    Public Const db_fld_City As String = "City" 'M String: 255 -> Text city of source contact address
    Public Const db_fld_SState As String = "State" 'M String: 255 -> Text state of source contact address
    Public Const db_fld_ZipCode As String = "ZipCode" 'M String: 255 -> Text zip code of source contact address
    Public Const db_fld_Citation As String = "Citation" 'M String: MAX -> Text string that give the correct citation for the source
    Public Const db_fld_MetadataID As String = "MetadataID" 'M Integer -> ID of metadata record associated with the source
#End Region

#Region " ISOMetadata "
    'ISO Metadata
    Public Const db_tbl_ISOMetadata As String = "ISOMetadata" 'Table Name
    Public Const db_fld_MMetadataID As String = "MetadataID" 'M Integer: Primary Key -> Unique ID for each ISOMetadata entry
    Public Const db_fld_TopicCategory As String = "TopicCategory" 'M String: 255 -> Topic category associated with the metadata entry
    Public Const db_fld_Title As String = "Title" 'M String: 255 -> Title for the metadata entry
    Public Const db_fld_Abstract As String = "Abstract" 'M String: 255 -> Abstract for the metadata entry
    Public Const db_fld_ProfileVersion As String = "ProfileVersion" 'M String: MAX -> Profile version for the metadata entry
    Public Const db_fld_MetadataLink As String = "MetadataLink" 'O String: 500 -> Text field holding hyperlink to additional metadata information
#End Region

#Region " Samples "
    'Samples
    Public Const db_tbl_Samples As String = "Samples" 'Table Name
    Public Const db_fld_SSampleID As String = "SampleID" 'M Integer: Primary Key -> Unique ID for each Samples entry
    Public Const db_fld_SampleType As String = "SampleType" 'M String: 255 -> Text name of the sample type
    Public Const db_fld_LabSampleCode As String = "LabSampleCode" 'M String: 50 -> Code used by the laboratory to identify the sample
    Public Const db_fld_LabMethodID As String = "LabMethodID" 'M Integer -> ID of the LabMethods record associated with the sample
#End Region

#Region " QualityControlLevels "
    'QualityControlLevels
    Public Const db_tbl_QualityControlLevels As String = "QualityControlLevels" 'Table Name
    Public Const db_fld_QQualityControlLevelID As String = "QualityControlLevelID" 'M Integer: Primary Key -> Unique ID for each quality control level
    Public Const db_fld_QualityControlLevelCode As String = "QualityControlLevelCode" 'M String: 50 -> Text code for each quality control level
    Public Const db_fld_Definition As String = "Definition" 'M String: 255 -> Definition of quality control level
    Public Const db_fld_Explanation As String = "Explanation" 'M String: MAX -> Explanation of quality control level
#End Region

#Region " Units "
    'Units
    Public Const db_tbl_Units As String = "Units" 'Table Name
    Public Const db_fld_UnitsID As String = "UnitsID" 'M Integer: Primary Key -> Unique ID for each Units entry
    Public Const db_fld_UnitsName As String = "UnitsName" 'M String: 255 -> Full name of the units
    Public Const db_fld_UnitsType As String = "UnitsType" 'M String: 255 -> Dimensions of the units
    Public Const db_fld_UnitsAbrv As String = "UnitsAbbreviation" 'M String: 50 -> Abbreviation for the units
#End Region

#Region " SeriesCatalog "
    'SeriesCatalog
    Public Const db_tbl_SeriesCatalog As String = "SeriesCatalog" 'Table Name
    Public Const db_fld_SCSeriesID As String = "SeriesID" 'P Integer: Primary Key -> Unique ID for each SeriesCatalog entry
    Public Const db_fld_SCSiteID As String = "SiteID" 'P Integer -> Linked to Sites.SiteID
    Public Const db_fld_SCSiteCode As String = "SiteCode" 'P String: 50 -> Site Identifier used by organization that collects the data
    Public Const db_fld_SCSiteName As String = "SiteName" 'P String: 255 -> Full text name of sampling location
    Public Const db_fld_SCSiteType As String = "SiteType"
    Public Const db_fld_SCVarID As String = "VariableID" 'P Integer -> Linked to Variables.VariableID
    Public Const db_fld_SCVarCode As String = "VariableCode" 'P String: 50 -> Variable identifier used by the organization that collects the data
    Public Const db_fld_SCVarName As String = "VariableName" 'P String: 255 -> Name of the variable from the variables table
    Public Const db_fld_SCSpec As String = "Speciation" 'P String: 255 -> Speciation from the Variables Table
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
    Public Const db_fld_SCQCLevelID As String = "QualityControlLevelID"   'P Integer -> Corresponds to the Quality Control Level of the Series
    Public Const db_fld_SCQCLevelCode As String = "QualityControlLevelCode" 'String: 50
    Public Const db_fld_SCSourceID As String = "SourceID" 'P Integer -> Corresponds to the ID of the Source for the Series
    Public Const db_fld_SCOrganization As String = "Organization" 'P String: 50 -> Corresponds to the Organization for the Series
    Public Const db_fld_SCSourceDesc As String = "SourceDescription" 'P String -> Corresponds to the Source Description for the Series
    Public Const db_fld_SCCitation As String = "Citation" 'P String: 255
    Public Const db_fld_SCBeginDT As String = "BeginDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCEndDT As String = "EndDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCBeginDTUTC As String = "BeginDateTimeUTC" 'P DateTime -> The First UTC Date
    Public Const db_fld_SCEndDTUTC As String = "EndDateTimeUTC" 'P DateTime -> The Last UTC Date
    Public Const db_fld_SCValueCount As String = "ValueCount" 'P Integer -> The number of vaues in the series (SiteID & VariableID)
#End Region

#Region " Controlled Vocabulary Table Definitions "
    'table names
    Public Const db_tbl_CensorCodeCV As String = "CensorCodeCV"

    'fields
    Public Const db_fld_CV_Term As String = "Term"
    Public Const db_fld_CV_Definition As String = "Definition"
#End Region

#End Region

#Region " File Field Constants "
    Public Const file_DataValues As String = "datavalues"
    Public Const file_DataValues_DataValue As String = "datavalue"                          'R
    Public Const file_DataValues_ValueAccuracy As String = "valueaccuracy"                  'O
    Public Const file_DataValues_LocalDateTime As String = "localdatetime"                  'R
    Public Const file_DataValues_UTCOffset As String = "utcoffset"                          'R
    Public Const file_DataValues_DateTimeUTC As String = "datetimeutc"                      'R
#Region " Site Columns "
    Public Const file_DataValues_SiteID As String = "siteid"                                'R
    Public Const file_DataValues_SiteCode As String = "sitecode"                            'A
    Public Const file_DataValues_SiteName As String = "sitename"                            'A
#End Region
#Region " Variable Columns "
    Public Const file_DataValues_VariableID As String = "variableid"                        'R
    Public Const file_DataValues_VariableCode As String = "variablecode"                    'A
    Public Const file_DataValues_VariableName As String = "variablename"                    'A
#End Region
    Public Const file_DataValues_OffsetValue As String = "offsetvalue"                      'O
#Region " Offset Type Columns "
    Public Const file_DataValues_OffsetTypeID As String = "offsettypeid"
    Public Const file_DataValues_OffsetUnitsID As String = "offsetunitsid"                  'A
    Public Const file_DataValues_OffsetUnitsName As String = "offsetunitsname"              'A
    Public Const file_DataValues_OffsetDescription As String = "offsetdescription"          'A
#End Region
    Public Const file_DataValues_CensorCode As String = "censorcode"                        'R
#Region " Qualifier Columns "
    Public Const file_DataValues_QualifierID As String = "qualifierid"                      'O
    Public Const file_DataValues_QualifierDescription As String = "qualifierdescription"    'A
#End Region
#Region " Method Columns "
    Public Const file_DataValues_MethodID As String = "methodid"                            'R
    Public Const file_DataValues_MethodDescription As String = "methoddescription"          'A
#End Region
#Region " Source Columns "
    Public Const file_DataValues_SourceID As String = "sourceid"                            'R
    Public Const file_DataValues_Organization As String = "organization"                    'A
    Public Const file_DataValues_SourceDescription As String = "sourcedescription"          'A
    Public Const file_DataValues_ContactName As String = "contactname"                      'A
    Public Const file_DataValues_Phone As String = "phone"                                  'A
    Public Const file_DataValues_Email As String = "email"                                  'A
    Public Const file_DataValues_Address As String = "address"                              'A
    Public Const file_DataValues_City As String = "city"                                    'A
    Public Const file_DataValues_SourceState As String = "sourcestate"                      'A
    Public Const file_DataValues_ZipCode As String = "zipcode"                              'A
    Public Const file_DataValues_Citation As String = "citation"                            'A
#End Region
#Region " Sample Columns "
    Public Const file_DataValues_SampleID As String = "sampleid"                            'R
    Public Const file_DataValues_SampleType As String = "sampletype"                        'A
    Public Const file_DataValues_LabSampleCode As String = "labsamplecode"                  'A
#Region " Lab Method Columns "
    Public Const file_DataValues_LabMethodID As String = "labmethodid"                      'A
    Public Const file_DataValues_LabName As String = "labname"                              'A
    Public Const file_DataValues_LabOrganization As String = "laborganization"              'A
    Public Const file_DataValues_LabMethodName As String = "labmethodname"                  'A
    Public Const file_DataValues_LabMethodDescription As String = "labmethoddescription"    'A
#End Region
#End Region
#Region " Metadata Columns "
    Public Const file_DataValues_MetadataID As String = "metadataid"                        'A
    Public Const file_DataValues_TopicCategory As String = "topiccategory"                  'A
    Public Const file_DataValues_Title As String = "title"                                  'A
    Public Const file_DataValues_Abstract As String = "abstract"                            'A
    Public Const file_DataValues_ProfileVersion As String = "profileversion"                'A
#End Region
    Public Const file_DataValues_DerivedFromID As String = "derivedfromid"                  'O
#Region " Quality Control Level Columns "
    Public Const file_DataValues_QualityControlLevelID As String = "qualitycontrollevelid"  'R
    Public Const file_DataValues_QualityControlLevelCode As String = "qualitycontrollevelcode" 'A
    Public Const file_DataValues_Definition As String = "definition"                        'A
    Public Const file_DataValues_Explanation As String = "explanation"                      'A
#End Region
#End Region

    Private loadSites, loadVariables, loadOffsetTypes, loadQualifiers, loadMethods, loadSources, loadSamples, loadQualityControlLevels As New DataTable

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "DataValues"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "DataValues"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)

        MyBase.new(m_viewtable)
        MyType = "DataValues"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "DataValues"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid As New DataTable
        'Declare all of your CVs Here
        Dim Sites, Variables, OffsetTypes, CensorCodes, Qualifiers, Methods, Sources, Samples, QualityControlLevels, LabMethods, ISOMetadata, Units As New DataTable
        Dim i As Integer
        Dim fileRows() As DataRow
        Dim CVRows() As DataRow
        Dim parseTime As New TimeSpan(0)
        Dim writetime As New TimeSpan(0)
        Dim sParse As DateTime
        'Dim eParse As DateTime
        'Dim sWrite As DateTime
        'Dim eWrite As DateTime

        Try
            If (m_Connection Is Nothing) OrElse (trans.Connection.State = ConnectionState.Closed) Then
                Throw New Exception("No Database Connection")
            End If

            'Load The Table Template Here
            valid = m_Connection.OpenTable(connect, trans, db_tbl_DataValues, "SELECT * FROM " & db_tbl_DataValues & " WHERE " & db_tbl_DataValues & "." & db_fld_ValueID & " <> " & db_tbl_DataValues & "." & db_fld_ValueID)
            If (valid Is Nothing) OrElse (valid.Rows.Count > 0) Then
                Throw New Exception("Error Getting Database Schema")
            End If
            valid.Columns(db_fld_DataValue).DataType = System.Type.GetType("System.String")

            'Load all of the CV and other related tables here
            Sites = m_Connection.OpenTable(connect, trans, db_tbl_Sites, "SELECT * FROM " & db_tbl_Sites)
            Variables = m_Connection.OpenTable(connect, trans, db_tbl_Variables, "SELECT * FROM " & db_tbl_Variables)
            OffsetTypes = m_Connection.OpenTable(connect, trans, db_tbl_OffsetTypes, "SELECT * FROM " & db_tbl_OffsetTypes)
            CensorCodes = m_Connection.OpenTable(connect, trans, db_tbl_CensorCodeCV, "SELECT * FROM " & db_tbl_CensorCodeCV)
            Qualifiers = m_Connection.OpenTable(connect, trans, db_tbl_Qualifiers, "SELECT * FROM " & db_tbl_Qualifiers)
            Methods = m_Connection.OpenTable(connect, trans, db_tbl_Methods, "SELECT * FROM " & db_tbl_Methods)
            LabMethods = m_Connection.OpenTable(connect, trans, db_tbl_LabMethods, "SELECT * FROM " & db_tbl_LabMethods)
            Sources = m_Connection.OpenTable(connect, trans, db_tbl_Sources, "SELECT * FROM " & db_tbl_Sources)
            ISOMetadata = m_Connection.OpenTable(connect, trans, db_tbl_ISOMetadata, "SELECT * FROM " & db_tbl_ISOMetadata)
            Samples = m_Connection.OpenTable(connect, trans, db_tbl_Samples, "SELECT * FROM " & db_tbl_Samples)
            Units = m_Connection.OpenTable(connect, trans, db_tbl_Units, "SELECT * FROM " & db_tbl_Units)
            QualityControlLevels = m_Connection.OpenTable(connect, trans, db_tbl_QualityControlLevels, "SELECT * FROM " & db_tbl_QualityControlLevels)

            If (m_ViewTable.Columns.IndexOf(file_DataValues_DataValue) >= 0) Then
                If (m_ViewTable.Columns.IndexOf(file_DataValues_DateTimeUTC) >= 0) Then
                    If (m_ViewTable.Columns(file_DataValues_DataValue).DataType.ToString = "System.Double") Then
                        fileRows = m_ViewTable.Select(file_DataValues_DataValue & " IS NOT NULL")
                    Else
                        fileRows = m_ViewTable.Select(file_DataValues_DataValue & " IS NOT NULL AND " & file_DataValues_DataValue & " <> ''")
                    End If
                    If (m_ThrowFileOnNulls) Then
                        If (fileRows.Length < m_ViewTable.Rows.Count) Then
                            Throw New Exception(file_DataValues_DataValue & " cannot be NULL.")
                        End If
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_LocalDateTime) >= 0) Then
                    If (m_ViewTable.Columns(file_DataValues_DataValue).DataType.ToString = "System.Double") Then
                        fileRows = m_ViewTable.Select(file_DataValues_DataValue & " IS NOT NULL")
                    Else
                        fileRows = m_ViewTable.Select(file_DataValues_DataValue & " IS NOT NULL AND " & file_DataValues_DataValue & " <> ''")
                    End If
                    If (m_ThrowFileOnNulls) Then
                        If (fileRows.Length < m_ViewTable.Rows.Count) Then
                            Throw New Exception(file_DataValues_DataValue & " cannot be NULL.")
                        End If
                    End If
                Else
                    Throw New Exception("Unable to find 2 Time columns.")
                End If
            Else
                Throw New Exception("Unable to find " & file_DataValues_DataValue & " column.")
            End If

            Dim col As DataColumn
            Dim cols() As DataColumn = {}
            Dim count As Integer = 0
            For Each col In valid.Columns
                If (col.ColumnName <> db_fld_ValueID) Then
                    Array.Resize(cols, count + 1)
                    cols(count) = col
                    count += 1
                End If
            Next

            Try
                valid.Constraints.Add("AllUnique", cols, False)
            Catch ex As Exception
                LogError("Sources should be unique, but not all of the Sources in your database are unique." & vbCrLf & "Duplicate rows will be allowed for updates into this Sources table.")

            End Try

            For i = 0 To (fileRows.Length - 1)
                sParse = Now
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)

                'Required columns
                '----------------
                'ValueID
                'tempRow.Item(db_fld_ValueID) = i

                'DataValue


                If (fileRow.Item(file_DataValues_DataValue).ToString <> "") AndAlso IsNumeric(fileRow.Item(file_DataValues_DataValue).ToString()) Then
                    tempRow.Item(db_fld_DataValue) = fileRow.Item(file_DataValues_DataValue)
                Else
                    Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_DataValue & " cannot be NULL and must be numeric.")
                End If
                'Else
                'The m_viewtable is invalid because there is no DataValue field.
                'Throw New Exception("Unable to find the " & file_DataValues_DataValue & " column.")
                'End If

                'LocalDateTime, UTCOffset, and DateTimeUTC
                If (m_ViewTable.Columns.IndexOf(file_DataValues_LocalDateTime) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_UTCOffset) >= 0) Then
                    If (fileRow.Item(file_DataValues_LocalDateTime).ToString <> "") AndAlso (fileRow.Item(file_DataValues_UTCOffset).ToString <> "") Then
                        Dim Local As New Date
                        If Date.TryParse(fileRow.Item(file_DataValues_LocalDateTime), Local) AndAlso IsNumeric(fileRow.Item(file_DataValues_UTCOffset)) Then
                            tempRow.Item(db_fld_LocalDateTime) = Local
                            tempRow.Item(db_fld_UTCOffset) = fileRow.Item(file_DataValues_UTCOffset)
                            'Calculate DateTimeUTC from LocalDateTime and UTCOffset
                            tempRow.Item(db_fld_DateTimeUTC) = DateAdd(DateInterval.Hour, -(fileRow.Item(file_DataValues_UTCOffset)), fileRow.Item(file_DataValues_LocalDateTime))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_LocalDateTime & " must be a date and " & file_DataValues_UTCOffset & " must be numeric.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_LocalDateTime & " and " & file_DataValues_UTCOffset & " cannot be null.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_UTCOffset) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_DateTimeUTC) >= 0) Then
                    If (fileRow.Item(file_DataValues_UTCOffset).ToString <> "") AndAlso (fileRow.Item(file_DataValues_DateTimeUTC).ToString <> "") Then
                        Dim UTC As New Date
                        If IsNumeric(fileRow.Item(file_DataValues_UTCOffset)) AndAlso Date.TryParse(fileRow.Item(file_DataValues_DateTimeUTC), UTC) Then
                            tempRow.Item(db_fld_DateTimeUTC) = UTC
                            tempRow.Item(db_fld_UTCOffset) = fileRow.Item(file_DataValues_UTCOffset)
                            'Calculate LocalDateTime from DateTimeUTC and UTCOffset
                            tempRow.Item(db_fld_LocalDateTime) = DateAdd(DateInterval.Hour, fileRow.Item(file_DataValues_UTCOffset), fileRow.Item(file_DataValues_DateTimeUTC))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_DateTimeUTC & " must be a date and " & file_DataValues_UTCOffset & " must be numeric.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_DateTimeUTC & " and " & file_DataValues_UTCOffset & " cannot be null.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_LocalDateTime) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_DateTimeUTC) >= 0) Then
                    If (fileRow.Item(file_DataValues_LocalDateTime).ToString <> "") AndAlso (fileRow.Item(file_DataValues_DateTimeUTC).ToString <> "") Then
                        Dim Local As New Date
                        Dim UTC As New Date
                        If Date.TryParse(fileRow.Item(file_DataValues_LocalDateTime), Local) AndAlso Date.TryParse(fileRow.Item(file_DataValues_DateTimeUTC), UTC) Then
                            tempRow.Item(db_fld_DateTimeUTC) = UTC
                            tempRow.Item(db_fld_LocalDateTime) = Local
                            'Calculate UTCOffset from DateTimeUTC and LocalDateTime
                            tempRow.Item(db_fld_UTCOffset) = DateDiff(DateInterval.Second, fileRow.Item(file_DataValues_DateTimeUTC), fileRow.Item(file_DataValues_LocalDateTime)) / 3600
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_LocalDateTime & " and " & file_DataValues_DateTimeUTC & " must be a dates.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_LocalDateTime & " and " & file_DataValues_DateTimeUTC & " cannot be null.")
                    End If
                Else
                    'The m_viewtable is invalid because they have not included enough information to define the time fields.
                    Throw New Exception("Unable to find the time information.  You must specify at least two of the following: LocalDateTime, UTCOffset, and DateTimeUTC.")
                End If

                'SiteID
                If (m_ViewTable.Columns.IndexOf(file_DataValues_SiteID) >= 0) Then
                    'They are trying to load DataValues using the SiteID and they are not loading Sites
                    If (fileRow.Item(file_DataValues_SiteID).ToString <> "") AndAlso IsNumeric(fileRow.Item(file_DataValues_SiteID)) Then
                        CVRows = Sites.Select(db_fld_SSiteID & " = '" & Val(fileRow.Item(file_DataValues_SiteID)) & "'")
                        If (CVRows.Length > 0) Then
                            tempRow.Item(db_fld_SiteID) = fileRow.Item(file_DataValues_SiteID)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_SiteID & " in the Sites table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_SiteID & " cannot be NULL and must be an integer.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_SiteCode) >= 0) Then 'AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_SiteName) < 0) Then
                    'They are trying to load DataValues using the SiteCode and they are not loading Sites.  I only have to check to see if the SiteCode exists because SiteCode is an alternate key for the Sites table.
                    If (fileRow.Item(file_DataValues_SiteCode).ToString <> "") Then
                        Dim SiteCode As String
                        SiteCode = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_SiteCode), "[\040]", "_")
                        SiteCode = System.Text.RegularExpressions.Regex.Replace(SiteCode, "[\,\+]", ".")
                        SiteCode = System.Text.RegularExpressions.Regex.Replace(SiteCode, "[\:\\\/\=]", "-")

                        If System.Text.RegularExpressions.Regex.Matches(SiteCode, "[^0-9a-zA-Z\.\-_]").Count() = 0 Then
                            CVRows = Sites.Select(db_fld_SiteCode & " = '" & Replace(SiteCode, "'", "''") & "'")
                            If (CVRows.Length > 0) Then
                                tempRow.Item(db_fld_SiteID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_SSiteID))
                            Else
                                Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_SiteCode & " in the Sites table.")
                            End If
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_SiteCode & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_SiteCode & " cannot be NULL.")
                    End If
                    'ElseIf (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_SiteCode) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_SiteName) >= 0) Then
                    '    'They are trying to load DataValues and Sites from the same m_viewtable.
                    '    'TODO: Add code to load Sites before DataValues if Site information is given in the DataValues input m_viewtable
                    '    'newSites.Rows.Add(filerow.ItemArray)
                Else
                    'The m_viewtable is invalid because they have not included enough information to determine what the Site is.
                    Throw New Exception("Unable to find the Site information.  You must specify a SiteID or a SiteCode or all of the required fields from the Sites table.")
                End If

                'VariableID
                If (m_ViewTable.Columns.IndexOf(file_DataValues_VariableID) >= 0) Then
                    'They are trying to load DataValues using the VariableID and they are not loading Variables.  
                    If (fileRow.Item(file_DataValues_VariableID).ToString <> "") AndAlso IsNumeric(fileRow.Item(file_DataValues_VariableID)) Then
                        CVRows = Variables.Select(db_fld_VVariableID & " = '" & Val(fileRow.Item(file_DataValues_VariableID)) & "'")
                        If (CVRows.Length > 0) Then
                            tempRow.Item(db_fld_VariableID) = fileRow.Item(file_DataValues_VariableID)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_VariableID & " in the Variables table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_VariableID & " cannot be NULL and must be an integer.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_VariableCode) >= 0) Then 'AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_VariableName) < 0) Then
                    'They are trying to load DataValues using the VariableCode and they are not loading Variables. I only have to check to see if the VariableCode exists because VariableCode is an alternate key for the Variables table.
                    If (fileRow.Item(file_DataValues_VariableCode).ToString <> "") Then
                        Dim VariableCode As String
                        VariableCode = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_VariableCode), "[\040]", "_")
                        VariableCode = System.Text.RegularExpressions.Regex.Replace(VariableCode, "[\,\+]", ".")
                        VariableCode = System.Text.RegularExpressions.Regex.Replace(VariableCode, "[\:\\\/\=]", "-")

                        If System.Text.RegularExpressions.Regex.Matches(VariableCode, "[^0-9a-zA-Z\.\-_]").Count() = 0 Then
                            CVRows = Variables.Select(db_fld_VariableCode & " = '" & Replace(VariableCode, "'", "''") & "'")
                            If (CVRows.Length > 0) Then
                                tempRow.Item(db_fld_VariableID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_VVariableID))
                            Else
                                Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_VariableCode & " in the Variables table.")
                            End If
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_VariableCode & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_VariableCode & " cannot be NULL.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_VariableCode) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_VariableName) >= 0) Then
                    Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid Variable information.")
                Else
                    'The m_viewtable is invalid because they have not specified enough information to determine what the variable is.
                    Throw New Exception("Unable to find the Variable information.  You must specify a VariableID or VariableCode or all of the required fields from the Variables table.")
                End If

                'CensorCode
                If (m_ViewTable.Columns.IndexOf(file_DataValues_CensorCode) >= 0) Then
                    If (fileRow.Item(file_DataValues_CensorCode).ToString <> "") Then
                        CVRows = CensorCodes.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_DataValues_CensorCode), "'", "''") & "'")
                        If (CVRows.Length > 0) Then
                            tempRow.Item(db_fld_CensorCode) = fileRow.Item(file_DataValues_CensorCode)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_CensorCode & " in the CensorCodeCV table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_CensorCode & " cannot be NULL.")
                    End If
                Else
                    'The m_viewtable is invalid because they have not specified a CensorCode field.
                    Throw New Exception("Unable to find the " & file_DataValues_CensorCode & " column.")
                End If

                'MethodID
                If (m_ViewTable.Columns.IndexOf(file_DataValues_MethodID) >= 0) Then
                    'They are trying to load DataValues using the MethodID and they are not loading Methods
                    If (fileRow.Item(file_DataValues_MethodID).ToString <> "") AndAlso IsNumeric(fileRow.Item(file_DataValues_MethodID)) Then
                        CVRows = Methods.Select(db_fld_MMethodID & " = '" & Val(fileRow.Item(file_DataValues_MethodID)) & "'")
                        If (CVRows.Length > 0) Then
                            tempRow.Item(db_fld_MethodID) = fileRow.Item(file_DataValues_MethodID)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_MethodID & " in the Methods table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_MethodID & " cannot be NULL and must be an integer.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_MethodDescription) >= 0) AndAlso (fileRow.Item(file_DataValues_MethodDescription).ToString <> "") Then
                    'They are trying to load DataValues using a description of a Method, so first check to see if it already exists in the Methods table
                    CVRows = Methods.Select(db_fld_MethodDescription & " = '" & Replace(fileRow.Item(file_DataValues_MethodDescription), "'", "''") & "'")
                    If (CVRows.Length > 0) Then
                        'The Method already exists in the Methods table
                        tempRow.Item(db_fld_MethodID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_MMethodID))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid Method information.")
                    End If
                Else
                    'The m_viewtable is invalid because they have not specified adequate Method information.
                    Throw New Exception("Unable to find the Method information.  You must specify either a MethodID or all of the required fields from the Methods table.")
                End If

                'SourceID
                If (m_ViewTable.Columns.IndexOf(file_DataValues_SourceID) >= 0) AndAlso (fileRow.Item(file_DataValues_SourceID).ToString <> "") Then
                    'They are trying to load DataValues using a SourceID and they are not loading Sources
                    If IsNumeric(fileRow.Item(file_DataValues_SourceID)) Then
                        CVRows = Sources.Select(db_fld_SSourceID & " = '" & Val(fileRow.Item(file_DataValues_SourceID)) & "'")
                        If (CVRows.Length > 0) Then
                            tempRow.Item(db_fld_SourceID) = fileRow.Item(file_DataValues_SourceID)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_SourceID & " in the Sources table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_SourceID & " must be an integer.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_Organization) >= 0) AndAlso (fileRow.Item(file_DataValues_Organization).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_SourceDescription) >= 0) AndAlso (fileRow.Item(file_DataValues_SourceDescription).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_ContactName) >= 0) AndAlso (fileRow.Item(file_DataValues_ContactName).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Phone) >= 0) AndAlso (fileRow.Item(file_DataValues_Phone).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Email) >= 0) AndAlso (fileRow.Item(file_DataValues_Email).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Address) >= 0) AndAlso (fileRow.Item(file_DataValues_Address).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_City) >= 0) AndAlso (fileRow.Item(file_DataValues_City).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_SourceState) >= 0) AndAlso (fileRow.Item(file_DataValues_SourceState).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_ZipCode) >= 0) AndAlso (fileRow.Item(file_DataValues_ZipCode).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Citation) >= 0) AndAlso (fileRow.Item(file_DataValues_Citation).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_MetadataID) >= 0) AndAlso (fileRow.Item(file_DataValues_MetadataID).ToString <> "") AndAlso IsNumeric(fileRow.Item(file_DataValues_MetadataID)) Then
                    'They are trying to load DataValues with the description of a Source, so check first to see if the Source already exists in the Sources table
                    CVRows = Sources.Select(db_fld_Organization & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_Organization), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_SourceDescription & " = '" & Replace(fileRow.Item(file_DataValues_SourceDescription), "'", "''") & "' AND " & db_fld_ContactName & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_ContactName), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_Phone & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_Phone), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_Email & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_Email), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_Address & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_Address), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_City & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_City), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_State & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_SourceState), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_ZipCode & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_ZipCode), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_Citation & " = '" & Replace(fileRow.Item(file_DataValues_Citation), "'", "''") & "' AND " & db_fld_MetadataID & " = '" & Val(fileRow.Item(file_DataValues_MetadataID)) & "'")
                    If (CVRows.Length > 0) Then
                        'The Source already exists in the Sources table
                        tempRow.Item(db_fld_SourceID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_SSourceID))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid Source information.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_Organization) >= 0) AndAlso (fileRow.Item(file_DataValues_Organization).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_SourceDescription) >= 0) AndAlso (fileRow.Item(file_DataValues_SourceDescription).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_ContactName) >= 0) AndAlso (fileRow.Item(file_DataValues_ContactName).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Phone) >= 0) AndAlso (fileRow.Item(file_DataValues_Phone).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Email) >= 0) AndAlso (fileRow.Item(file_DataValues_Email).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Address) >= 0) AndAlso (fileRow.Item(file_DataValues_Address).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_City) >= 0) AndAlso (fileRow.Item(file_DataValues_City).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_SourceState) >= 0) AndAlso (fileRow.Item(file_DataValues_SourceState).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_ZipCode) >= 0) AndAlso (fileRow.Item(file_DataValues_ZipCode).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Citation) >= 0) AndAlso (fileRow.Item(file_DataValues_Citation).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_TopicCategory) >= 0) AndAlso (fileRow.Item(file_DataValues_TopicCategory).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Title) >= 0) AndAlso (fileRow.Item(file_DataValues_Abstract).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_ProfileVersion) >= 0) AndAlso (fileRow.Item(file_DataValues_ProfileVersion).ToString <> "") Then
                    'They are trying to load DataValues with the description of a Source and a description of an ISOMetadata record, so check first to see if the Source already exists in the Sources table and if the ISOMetadata record exists in the ISOMetadata table
                    Dim MetaRows() As DataRow = ISOMetadata.Select(db_fld_TopicCategory & " = '" & Replace(fileRow.Item(file_DataValues_TopicCategory), "'", "''") & "' AND " & db_fld_Title & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_Title), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_Abstract & " = '" & Replace(fileRow.Item(file_DataValues_Abstract), "'", "''") & "' AND " & db_fld_ProfileVersion & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_ProfileVersion), "[\t\r\v\f\n]", ""), "'", "''") & "'")
                    If (MetaRows.Length > 0) Then
                        CVRows = Sources.Select(db_fld_Organization & " = '" & Replace(fileRow.Item(file_DataValues_Organization), "'", "''") & "' AND " & db_fld_SourceDescription & " = '" & Replace(fileRow.Item(file_DataValues_SourceDescription), "'", "''") & "' AND " & db_fld_ContactName & " = '" & Replace(fileRow.Item(file_DataValues_ContactName), "'", "''") & "' AND " & db_fld_Phone & " = '" & Replace(fileRow.Item(file_DataValues_Phone), "'", "''") & "' AND " & db_fld_Email & " = '" & Replace(fileRow.Item(file_DataValues_Email), "'", "''") & "' AND " & db_fld_Address & " = '" & Replace(fileRow.Item(file_DataValues_Address), "'", "''") & "' AND " & db_fld_City & " = '" & Replace(fileRow.Item(file_DataValues_City), "'", "''") & "' AND " & db_fld_State & " = '" & Replace(fileRow.Item(file_DataValues_SourceState), "'", "''") & "' AND " & db_fld_ZipCode & " = '" & Replace(fileRow.Item(file_DataValues_ZipCode), "'", "''") & "' AND " & db_fld_Citation & " = '" & Replace(fileRow.Item(file_DataValues_Citation), "'", "''") & "' AND " & db_fld_MetadataID & " ='" & Val(MetaRows(MetaRows.Length - 1).Item(db_fld_MMetadataID)) & "'")
                        If (CVRows.Length > 0) Then
                            'The Source already exists in the Sources table, and the ISOMetadata record already exists in the ISOMetadata table
                            tempRow.Item(db_fld_SourceID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_SSourceID))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid Source information.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid ISOMetadata information.")
                    End If
                Else

                    'The m_viewtable is invalid because they have not specified adequate Source information.
                    Throw New Exception("Unable to load Source information.  You must specify either a SourceID or all of the required fields from the Sources table.")
                End If

                'QualityControlLevelID
                If (m_ViewTable.Columns.IndexOf(file_DataValues_QualityControlLevelID) >= 0) Then
                    'They are trying to load DataValues using the QualityControlLevelID and they are not loading QualityControlLevels
                    If (fileRow.Item(file_DataValues_QualityControlLevelID).ToString <> "") AndAlso IsNumeric(fileRow.Item(file_DataValues_QualityControlLevelID)) Then
                        CVRows = QualityControlLevels.Select(db_fld_QQualityControlLevelID & " = '" & Val(fileRow.Item(file_DataValues_QualityControlLevelID)) & "'")
                        If (CVRows.Length > 0) Then
                            tempRow.Item(db_fld_QualityControlLevelID) = fileRow.Item(file_DataValues_QualityControlLevelID)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_QualityControlLevelID & " in the QualityControlLevels table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_QualityControlLevelID & " cannot be NULL and must be an integer.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_QualityControlLevelCode) >= 0) AndAlso (fileRow.Item(file_DataValues_QualityControlLevelCode).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Definition) >= 0) AndAlso (fileRow.Item(file_DataValues_Definition).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_Explanation) >= 0) AndAlso (fileRow.Item(file_DataValues_Explanation).ToString <> "") Then
                    'They are trying to load DataValues using a description of a QualityControlLevel, so first check to see if it already exists in the QuaityControlLevels table
                    Dim QualityControlLevelCode As String
                    QualityControlLevelCode = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_QualityControlLevelCode), "[\t\r\v\f\n]", "")
                    Dim QualityControlLevelDefinition
                    QualityControlLevelDefinition = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_Definition), "[\t\r\v\f\n]", "")

                    If (System.Text.RegularExpressions.Regex.Matches(QualityControlLevelCode, "[\t\r\v\f\n]").Count() = 0) Then
                        If (System.Text.RegularExpressions.Regex.Matches(QualityControlLevelDefinition, "[\t\r\v\f\n]").Count() = 0) Then
                            CVRows = QualityControlLevels.Select(db_fld_QualityControlLevelCode & " = '" & Replace(QualityControlLevelCode, "'", "''") & "' AND " & db_fld_Definition & " = '" & Replace(QualityControlLevelDefinition, "'", "''") & "' AND " & db_fld_Explanation & " = '" & Replace(fileRow.Item(file_DataValues_Explanation), "'", "''") & "'")
                            If (CVRows.Length > 0) Then
                                'The QualityControlLevel already exists in the QualityControlLevels table
                                tempRow.Item(db_fld_QualityControlLevelID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_QQualityControlLevelID))
                            Else
                                Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid QualityControlLevel information.")
                            End If
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_Definition & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_QualityControlLevelCode & " contains invalid characters.")
                    End If
                Else
                    'The m_viewtable is invalid because they have not specified adequate QualityControlLevel information.
                    Throw New Exception("Unable to find the QualityControlLevel information.  You must specify either a QualityControlLevelID or all of the required fields from the QualityControlLevels table.")
                End If
                'Optional columns
                '----------------
                'ValueAccuracy
                If (m_ViewTable.Columns.IndexOf(file_DataValues_ValueAccuracy) >= 0) AndAlso (fileRow.Item(file_DataValues_ValueAccuracy).ToString <> "") Then
                    If IsNumeric(fileRow.Item(file_DataValues_ValueAccuracy)) Then
                        tempRow.Item(db_fld_ValueAccuracy) = fileRow.Item(file_DataValues_ValueAccuracy)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_ValueAccuracy & " must be numeric.")
                    End If
                End If

                'OffsetValue and OffsetTypeID
                If (m_ViewTable.Columns.IndexOf(file_DataValues_OffsetValue) >= 0) AndAlso (fileRow.Item(file_DataValues_OffsetValue).ToString <> "") Then
                    If IsNumeric(fileRow.Item(file_DataValues_OffsetValue)) Then
                        'Set the OffsetValue in the temporary row
                        tempRow.Item(db_fld_OffsetValue) = fileRow.Item(file_DataValues_OffsetValue)
                        'Get the OffsetTypeID
                        If (m_ViewTable.Columns.IndexOf(file_DataValues_OffsetTypeID) >= 0) AndAlso (fileRow.Item(file_DataValues_OffsetTypeID).ToString <> "") AndAlso IsNumeric(fileRow.Item(file_DataValues_OffsetTypeID)) Then
                            'They are loading DataValues using an existing OffsetTypeID and are not loading OffsetTypes
                            CVRows = OffsetTypes.Select(db_fld_OOffsetTypeID & " = '" & Val(fileRow.Item(file_DataValues_OffsetTypeID)) & "'")
                            If (CVRows.Length > 0) Then
                                tempRow.Item(db_fld_OffsetTypeID) = fileRow.Item(file_DataValues_OffsetTypeID)
                            Else
                                Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_OffsetTypeID & " in the OffsetTypes table.")
                            End If
                        ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_OffsetUnitsID) >= 0) AndAlso (fileRow.Item(file_DataValues_OffsetUnitsID).ToString <> "") AndAlso IsNumeric(fileRow.Item(file_DataValues_OffsetUnitsID)) AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_OffsetDescription) >= 0) AndAlso (fileRow.Item(file_DataValues_OffsetDescription).ToString <> "") Then
                            'They are trying to load DataValues using the description of an OffsetType, so check first to see if the OffsetType already exists in the OffsetTypes table
                            CVRows = OffsetTypes.Select(db_fld_OffsetUnitsID & " = '" & Val(fileRow.Item(file_DataValues_OffsetUnitsID)) & "' AND " & db_fld_OffsetDescription & " = '" & Replace(fileRow.Item(file_DataValues_OffsetDescription), "'", "''") & "'")
                            If (CVRows.Length > 0) Then
                                'The OffsetType already exists in the OffsetTypesTable
                                tempRow.Item(db_fld_OffsetTypeID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_OOffsetTypeID))
                            Else
                                Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid OffsetType information.")
                            End If
                        ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_OffsetUnitsName) >= 0) AndAlso (fileRow.Item(file_DataValues_OffsetUnitsName).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_OffsetDescription) >= 0) AndAlso (fileRow.Item(file_DataValues_OffsetDescription).ToString <> "") Then
                            'They are trying to load DataValues using the description of an OffsetType, so check first to see if the OffsetType already exists in the OffsetTypes table
                            Dim unitRows() As DataRow = Units.Select(db_fld_UnitsName & " = '" & Replace(fileRow.Item(file_DataValues_OffsetUnitsName), "'", "''") & "'")
                            If (unitRows.Length > 0) Then
                                CVRows = OffsetTypes.Select(db_fld_OffsetUnitsID & " = '" & unitRows(unitRows.Length - 1).Item(db_fld_UnitsID) & "' AND " & db_fld_OffsetDescription & " = '" & Replace(fileRow.Item(file_DataValues_OffsetDescription), "'", "''") & "'")
                                If (CVRows.Length > 0) Then
                                    'The OffsetType already exists in the OffsetTypes table
                                    tempRow.Item(db_fld_OffsetTypeID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_OOffsetTypeID))
                                Else
                                    Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid OffsetType information.")
                                End If
                            Else
                                Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid OffsetUnits information.")
                            End If
                        Else
                            Throw New Exception("Unable to find the OffsetType information.  If you specify and OffsetValue, you must also include an OffsetTypeID or all of the required fields from the OffsetTypes table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_OffsetValue & " must be numeric.")
                    End If
                End If

                'QualifierID
                If (m_ViewTable.Columns.IndexOf(file_DataValues_QualifierID) >= 0) AndAlso (fileRow.Item(file_DataValues_QualifierID).ToString <> "") Then
                    'They are trying to load DataValues using a QualifierID and they are not loading Qualifiers
                    If IsNumeric(fileRow.Item(file_DataValues_QualifierID)) Then
                        CVRows = Qualifiers.Select(db_fld_QQualifierID & " = '" & Val(fileRow.Item(file_DataValues_QualifierID)) & "'")
                        If (CVRows.Length > 0) Then
                            tempRow.Item(db_fld_QualifierID) = fileRow.Item(file_DataValues_QualifierID)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_QualifierID & " in the Qualifiers table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_QualifierID & " must be an integer.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_QualifierDescription) >= 0) AndAlso (fileRow.Item(file_DataValues_QualifierDescription).ToString <> "") Then
                    'They are trying to load DataValues with the description of a Qualifier, so check first to see if the Qualifier already exists in the Qualifiers table
                    CVRows = Qualifiers.Select(db_fld_QualifierDescription & " = '" & Replace(fileRow.Item(file_DataValues_QualifierDescription), "'", "''") & "'")
                    If (CVRows.Length > 0) Then
                        'The Qualifier already exists in the Qualifiers table
                        tempRow.Item(db_fld_QualifierID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_QQualifierID))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid Qualifier information.")
                    End If
                End If

                'SampleID
                If (m_ViewTable.Columns.IndexOf(file_DataValues_SampleID) >= 0) AndAlso (fileRow.Item(file_DataValues_SampleID).ToString <> "") Then
                    'They are trying to load DataValues using a SampleID and they are not loading Samples
                    If IsNumeric(fileRow.Item(file_DataValues_SampleID)) Then
                        CVRows = Samples.Select(db_fld_SSampleID & " = '" & Val(fileRow.Item(file_DataValues_SampleID)) & "'")
                        If (CVRows.Length > 0) Then
                            tempRow.Item(db_fld_SampleID) = fileRow.Item(file_DataValues_SampleID)
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_DataValues_SampleID & " in the Samples table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_SampleID & " must be an integer.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_SampleType) >= 0) AndAlso (fileRow.Item(file_DataValues_SampleType).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_LabSampleCode) >= 0) AndAlso (fileRow.Item(file_DataValues_LabSampleCode).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_LabMethodID) >= 0) AndAlso (fileRow.Item(file_DataValues_LabMethodID).ToString <> "") AndAlso IsNumeric(fileRow.Item(file_DataValues_LabMethodID)) Then
                    'They are trying to load DataValues with the description of a Sample, so check first to see if the Sample already exists in the Samples Table
                    CVRows = Samples.Select(db_fld_SampleType & " = '" & Replace(fileRow.Item(file_DataValues_SampleType), "'", "''") & "' AND " & db_fld_LabSampleCode & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_LabSampleCode), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_LabMethodID & " = '" & Val(fileRow.Item(file_DataValues_LabMethodID)) & "'")
                    If (CVRows.Length > 0) Then
                        'The Sample already exists in the Samples table
                        tempRow.Item(db_fld_SampleID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_SSampleID))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid Sample information.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_SampleType) >= 0) AndAlso (fileRow.Item(file_DataValues_SampleType).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_LabSampleCode) >= 0) AndAlso (fileRow.Item(file_DataValues_LabSampleCode).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_LabName) >= 0) AndAlso (fileRow.Item(file_DataValues_LabName).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_LabOrganization) >= 0) AndAlso (fileRow.Item(file_DataValues_LabOrganization).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_LabMethodName) >= 0) AndAlso (fileRow.Item(file_DataValues_LabMethodName).ToString <> "") AndAlso (m_ViewTable.Columns.IndexOf(file_DataValues_LabMethodDescription) >= 0) AndAlso (fileRow.Item(file_DataValues_LabMethodDescription).ToString <> "") Then
                    'They are trying to load DataValues with the description of a Sample and a description of the LabMethod, so check to see if the Sample exists in the Samples table and that the LabMethod exists in the LabMethods table.
                    Dim LabMethodRows() As DataRow = LabMethods.Select(db_fld_LabName & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_LabName), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_LabOrganization & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_LabOrganization), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_LabMethodName & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_LabMethodName), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_LabMethodDescription & " = '" & Replace(fileRow.Item(file_DataValues_LabMethodDescription), "'", "''") & "'")
                    If (LabMethodRows.Length > 0) Then
                        CVRows = Samples.Select(db_fld_SampleType & " = '" & Replace(fileRow.Item(file_DataValues_SampleType), "'", "''") & "' AND " & db_fld_LabSampleCode & " = '" & Replace(System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_DataValues_LabSampleCode), "[\t\r\v\f\n]", ""), "'", "''") & "' AND " & db_fld_LabMethodID & " = '" & LabMethodRows(LabMethodRows.Length - 1).Item(db_fld_LLabMethodID) & "'")
                        If (CVRows.Length > 0) Then
                            'The Sample already exists in the Samples table and the LabMethod already exists in the LabMethods table
                            tempRow.Item(db_fld_SampleID) = Val(CVRows(CVRows.Length - 1).Item(db_fld_SSampleID))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid Sample information.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find Valid LabMethod information.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_DataValues_SampleType) >= 0 AndAlso fileRow.Item(file_DataValues_SampleType).ToString <> "") Or (m_ViewTable.Columns.IndexOf(file_DataValues_LabSampleCode) >= 0 AndAlso fileRow.Item(file_DataValues_LabSampleCode).ToString <> "") Or (m_ViewTable.Columns.IndexOf(file_DataValues_LabMethodID) >= 0) AndAlso (fileRow.Item(file_DataValues_LabMethodID).ToString <> "") Then
                    'The m_viewtable is invalid because they have included some of the Sample information but not all of it.
                    Throw New Exception("Unable to load Sample information.  You must specify either a SampleID or all of the required fields from the Samples table.")
                End If

                'DerivedFromID
                If (m_ViewTable.Columns.IndexOf(file_DataValues_DerivedFromID) >= 0) AndAlso (fileRow.Item(file_DataValues_DerivedFromID).ToString <> "") Then
                    If IsNumeric(fileRow.Item(file_DataValues_DerivedFromID)) Then
                        tempRow.Item(db_fld_DerivedFromID) = fileRow.Item(file_DataValues_DerivedFromID)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_DataValues_DerivedFromID & " must be numeric.")
                    End If
                End If
                Try
                    valid.Rows.Add(tempRow)
                Catch ex As Exception
                    If (ex.Message.StartsWith("Column") And ex.Message.EndsWith("is already present.")) Then
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & " is a duplicate of a previous row.<br> " & ex.Message, ex)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & " contained an error.<br> " & ex.Message, ex)
                    End If
                End Try

                If (i Mod 1000 = 999) Then
                    GC.Collect()
                End If
            Next i

            GC.Collect()

            Console.WriteLine("Adding " & valid.Rows.Count & " rows to DataValues.")
            Return valid
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            'Log: ERROR
            'LogError(ex)
            If Not (valid Is Nothing) Then
                valid.Clear()
            End If
            If Not (Sites Is Nothing) Then
                Sites.Clear()
            End If
            If Not (Variables Is Nothing) Then
                Variables.Clear()
            End If
            If Not (OffsetTypes Is Nothing) Then
                OffsetTypes.Clear()
            End If
            If Not (Qualifiers Is Nothing) Then
                Qualifiers.Clear()
            End If
            If Not (Methods Is Nothing) Then
                Methods.Clear()
            End If
            'If Not (LabMethods Is Nothing) Then
            '    LabMethods.Clear()
            'End If
            If Not (Sources Is Nothing) Then
                Sources.Clear()
            End If
            'If Not (ISOMetadata Is Nothing) Then
            '    ISOMetadata.Clear()
            'End If
            If Not (Samples Is Nothing) Then
                Samples.Clear()
            End If
            If Not (QualityControlLevels Is Nothing) Then
                QualityControlLevels.Clear()
            End If
            'If Not (Units Is Nothing) Then
            '    Units.Clear()
            'End If
            If Not (CensorCodes Is Nothing) Then
                CensorCodes.Clear()
            End If
            Throw New ExitError(ex.Message) '"DataValues.ValidateTable(connect, trans)")
        End Try
        Return New DataTable("ERROR")
    End Function

    Private Function writeSelect(ByVal dc As DataColumnCollection, ByVal vals As String()) As String
        Dim strselect As String
        Dim i As Integer = 0
        'For Each dc As DataColumn In dcs
        strselect = dc(i).ColumnName & " = '" & vals(i + 1) & "' "
        For i = 1 To dc.Count - 1
            strselect &= "AND " & dc(i).ColumnName & " = '" & vals(i + 1) & "' "
        Next i
        Return strselect
    End Function

    Public Overrides Function CommitTable() As clsTableCount

        Dim _tc As New clsTableCount

        'Dim scope As New Transactions.TransactionScope
        'Dim count As Integer = 0
        'Dim otherCount As Integer = 0

        'Using scope
        Dim connect As New System.Data.SqlClient.SqlConnection(m_Connection.ConnectionString)
        connect.Open()
        Dim trans As SqlClient.SqlTransaction = connect.BeginTransaction(Data.IsolationLevel.ReadCommitted, "this is a test")

        Try
            _tc = CommitTable(connect, trans)
        Catch SqlEr As SqlClient.SqlException
            '"Violation of UNIQUE KEY constraint 'UNIQUE_DataValues'. Cannot insert duplicate key in object 'dbo.DataValues'. The duplicate key value is (3.2, <NULL>, Aug 24 1997 10:15AM, -5, Aug 24 1997  3:15PM, 13, 1, <NULL>, <NULL>, nc, <NULL>, 0, 1, <NULL>, <NULL>, 1). The statement has been terminated."
            'Dim sep() As Char = {",", "(", ")"}
            'Dim vals() As String = SqlEr.Message.Split(sep)
            'Dim strSelect = writeSelect(m_ViewTable.Columns, vals)
            'Dim foundRow() = m_ViewTable.Select("DataValue = " & vals(1) & " AND LocalDateTime = '" & vals(3) & "'")
            'Dim rowIndex As Integer
            'For Each row As DataRow In foundRow
            '    rowIndex = m_ViewTable.Rows.IndexOf(row) 'RowIndex will be index of row in datatable
            'Next

            'Dim newMsg As String = "Duplicate Row present . #" & rowIndex
            Dim newMsg As String = "Duplicate Row present ."
            LogError(newMsg)
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            'LogError(ex)
#If DEBUG Then
            MsgBox("Trans.rollback")
#End If
            trans.Rollback()
            Throw New ExitError("Error Committing Samples <br> " & ex.Message)
        End Try
        connect.Close()
        'Return otherCount
        Return _tc
        'Return count


    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As clsTableCount

        Dim _tc As New clsTableCount
        Dim count As New Integer
        'Methods
        If (m_ViewTable.Columns.IndexOf(clsMethods.file_Methods_MethodDescription) >= 0) Then
            Dim fields() As String = {clsMethods.file_Methods_MethodDescription}
            If (m_ViewTable.Columns.IndexOf(clsMethods.file_Methods_MethodLink) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsMethods.file_Methods_MethodLink
            End If
            ''LogUpdate("Finding New Methods")
            Dim dMethods As DataTable = SelectDistinct(m_ViewTable, fields)
            Dim newMethods As New clsMethods(m_Connection, dMethods)
            _tc.AddTable(newMethods.CommitTable(connect, trans))
            If (_tc(db_tbl_Methods) > 0) Then
                'otherCount += count
                ''LogUpdate(_tc(db_tbl_Methods) & " rows committed to Methods")
            End If
        End If

        'OffsetTypes
        If (m_ViewTable.Columns.IndexOf(clsOffsetTypes.file_OffsetTypes_OffsetDescription) >= 0) Then
            Dim fields() As String = {clsOffsetTypes.file_OffsetTypes_OffsetDescription}
            If (m_ViewTable.Columns.IndexOf(clsOffsetTypes.file_OffsetTypes_OffsetUnitsID) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsOffsetTypes.file_OffsetTypes_OffsetUnitsID
            End If
            If (m_ViewTable.Columns.IndexOf(clsOffsetTypes.file_OffsetTypes_OffsetUnitsName) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsOffsetTypes.file_OffsetTypes_OffsetUnitsName
            End If
            ''LogUpdate("Finding New OffsetTypes")
            Dim dOffsetTypes As DataTable = SelectDistinct(m_ViewTable, fields)
            Dim newOffsetTypes As New clsOffsetTypes(m_Connection, dOffsetTypes)
            _tc.AddTable(newOffsetTypes.CommitTable(connect, trans))
            If (_tc(db_tbl_OffsetTypes) > 0) Then
                'otherCount += count
                ''LogUpdate(_tc(db_tbl_OffsetTypes) & " rows committed to OffsetTypes")
            End If
        End If

        'Qualifiers
        If (m_ViewTable.Columns.IndexOf(clsQualifiers.file_Qualifiers_QualifierDescription) >= 0) Then
            Dim fields() As String = {clsQualifiers.file_Qualifiers_QualifierDescription}
            If (m_ViewTable.Columns.IndexOf(clsQualifiers.file_Qualifiers_QualifierCode) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsQualifiers.file_Qualifiers_QualifierCode
            End If
            ''LogUpdate("Finding New Qualifiers")
            Dim dQualifiers As DataTable = SelectDistinct(m_ViewTable, fields)
            Dim newQualifiers As New clsQualifiers(m_Connection, dQualifiers)
            _tc.AddTable(newQualifiers.CommitTable(connect, trans))
            If (_tc(db_tbl_Qualifiers) > 0) Then
                'otherCount += count
                ''LogUpdate(_tc(db_tbl_Qualifiers) & " rows committed to Qualifiers")
            End If
        End If

        'QualityControlLevels
        If (m_ViewTable.Columns.IndexOf(clsQualityControlLevels.file_QualityControlLevels_Definition) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsQualityControlLevels.file_QualityControlLevels_Explanation) >= 0) Then
            Dim fields() As String = {clsQualityControlLevels.file_QualityControlLevels_Definition, clsQualityControlLevels.file_QualityControlLevels_Explanation}
            If (m_ViewTable.Columns.IndexOf(clsQualityControlLevels.file_QualityControlLevels_QualityControlLevelCode) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsQualityControlLevels.file_QualityControlLevels_QualityControlLevelCode
            End If
            ''LogUpdate("Finding New QualityControlLevels")
            Dim dQualityControlLevels As DataTable = SelectDistinct(m_ViewTable, fields)
            Dim newQualityControlLevels As New clsQualityControlLevels(m_Connection, dQualityControlLevels)
            _tc.AddTable(newQualityControlLevels.CommitTable(connect, trans))
            If (_tc(db_tbl_QualityControlLevels) > 0) Then
                'otherCount += count
                ''LogUpdate(_tc(db_tbl_QualityControlLevels) & " rows committed to QualityControlLevels")
            End If
        End If

        'Samples
        If (m_ViewTable.Columns.IndexOf(clsSamples.file_Samples_SampleType) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSamples.file_Samples_LabSampleCode) >= 0) Then
            Dim fields() As String = {clsSamples.file_Samples_SampleType, clsSamples.file_Samples_LabSampleCode}
            If (m_ViewTable.Columns.IndexOf(clsSamples.file_Samples_LabMethodID) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSamples.file_Samples_LabMethodID
            End If
            If (m_ViewTable.Columns.IndexOf(clsSamples.file_Samples_LabName) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSamples.file_Samples_LabName
            End If
            If (m_ViewTable.Columns.IndexOf(clsSamples.file_Samples_LabOrganization) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSamples.file_Samples_LabOrganization
            End If
            If (m_ViewTable.Columns.IndexOf(clsSamples.file_Samples_LabMethodName) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSamples.file_Samples_LabMethodName
            End If
            If (m_ViewTable.Columns.IndexOf(clsSamples.file_Samples_LabMethodDescription) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSamples.file_Samples_LabMethodDescription
            End If
            If (m_ViewTable.Columns.IndexOf(clsSamples.file_Samples_LabMethodLink) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSamples.file_Samples_LabMethodLink
            End If
            ''LogUpdate("Finding New Samples")
            Dim dSamples As DataTable = SelectDistinct(m_ViewTable, fields)
            Dim newSamples As New clsSamples(m_Connection, dSamples)
            _tc.AddTable(newSamples.CommitTable(connect, trans))
            If (_tc(db_tbl_Samples) > 0) Then
                ' otherCount += count
                ''LogUpdate(_tc(db_tbl_Samples) & " rows committed to Samples")
            End If
        End If

        'Sites
        If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_SiteCode) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_SiteName) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_Latitude) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_Longitude) >= 0) Then
            Dim fields() As String = {clsSites.file_Sites_SiteCode, clsSites.file_Sites_SiteName, clsSites.file_Sites_Latitude, clsSites.file_Sites_Longitude}
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_LatLongDatumID) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_LatLongDatumID
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_LatLongDatumSRSID) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_LatLongDatumSRSID
            End If
            If (m_Connection.getODMVersion = "1.1.1") Then
                If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_SiteType) >= 0) Then
                    Array.Resize(fields, fields.Length + 1)
                    fields(fields.Length - 1) = clsSites.file_Sites_SiteType
                End If
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_LatLongDatumSRSName) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_LatLongDatumSRSName
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_Elevation_m) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_Elevation_m
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_VerticalDatum) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_VerticalDatum
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_LocalX) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_LocalX
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_LocalY) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_LocalY
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_LocalProjectionID) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_LocalProjectionID
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_LocalProjectionSRSID) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_LocalProjectionSRSID
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_LocalProjectionSRSName) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_LocalProjectionSRSName
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_PosAccuracy_m) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_PosAccuracy_m
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_SiteState) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_SiteState
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_County) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_County
            End If
            If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_Comments) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSites.file_Sites_Comments
            End If
            'LogUpdate("Finding New Sites")
            Dim dSites As DataTable = SelectDistinct(m_ViewTable, fields)
            Dim newSites As New clsSites(m_Connection, dSites)
            _tc.AddTable(newSites.CommitTable(connect, trans))
            If (_tc(db_tbl_Sites) > 0) Then
                'otherCount += count
                'LogUpdate(_tc(db_tbl_Sites) & " rows committed to Sites")
            End If
        End If

        'Sources
        If (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_Organization) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_SourceDescription) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_ContactName) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_Phone) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_Email) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_Address) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_City) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_SourceState) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_Zipcode) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_Citation) >= 0) Then
            Dim fields() As String = {clsSources.file_Sources_Organization, clsSources.file_Sources_SourceDescription, clsSources.file_Sources_ContactName, clsSources.file_Sources_Phone, clsSources.file_Sources_Email, clsSources.file_Sources_Address, clsSources.file_Sources_City, clsSources.file_Sources_SourceState, clsSources.file_Sources_Zipcode, clsSources.file_Sources_Citation}
            If (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_SourceLink) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSources.file_Sources_SourceLink
            End If
            If (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_MetadataID) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSources.file_Sources_MetadataID
            End If
            If (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_TopicCategory) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSources.file_Sources_TopicCategory
            End If
            If (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_Title) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSources.file_Sources_Title
            End If
            If (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_Abstract) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSources.file_Sources_Abstract
            End If
            If (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_ProfileVersion) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSources.file_Sources_ProfileVersion
            End If
            If (m_ViewTable.Columns.IndexOf(clsSources.file_Sources_MetadataLink) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsSources.file_Sources_MetadataLink
            End If
            'LogUpdate("Finding New Sources")
            Dim dSources As DataTable = SelectDistinct(m_ViewTable, fields)
            Dim newSources As New clsSources(m_Connection, dSources)
            _tc.AddTable(newSources.CommitTable(connect, trans))
            If (_tc(db_tbl_Sources) > 0) Then
                'otherCount += count
                'LogUpdate(_tc(db_tbl_Sources) & " rows committed to Sources")
            End If
        End If

        'Variables
        If (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_VariableCode) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_VariableName) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_Speciation) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_SampleMedium) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_ValueType) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_IsRegular) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_TimeSupport) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_DataType) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_GeneralCategory) >= 0) AndAlso (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_NoDataValue) >= 0) Then
            Dim fields() As String = {clsVariables.file_Variables_VariableCode, clsVariables.file_Variables_VariableName, clsVariables.file_Variables_Speciation, clsVariables.file_Variables_SampleMedium, clsVariables.file_Variables_ValueType, clsVariables.file_Variables_IsRegular, clsVariables.file_Variables_TimeSupport, clsVariables.file_Variables_DataType, clsVariables.file_Variables_GeneralCategory, clsVariables.file_Variables_NoDataValue}
            If (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_VariableUnitsID) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsVariables.file_Variables_VariableUnitsID
            End If
            If (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_VariableUnitsName) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsVariables.file_Variables_VariableUnitsName
            End If
            If (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_TimeUnitsID) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsVariables.file_Variables_TimeUnitsID
            End If
            If (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_TimeUnitsName) >= 0) Then
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = clsVariables.file_Variables_TimeUnitsName
            End If

            Dim dVariables As DataTable = SelectDistinct(m_ViewTable, fields)
            Dim newVariables As New clsVariables(m_Connection, dVariables)
            _tc.AddTable(newVariables.CommitTable(connect, trans))
            If (_tc(db_tbl_Variables) > 0) Then
                'otherCount += count
                'LogUpdate(_tc(db_tbl_Variables) & " rows committed to Variables")
            End If
        End If

        'LogUpdate("Finding New DataValues")
        Dim DV As DataTable = ValidateTable(connect, trans)
        '_tc.Add(db_tbl_DataValues, m_Connection.UpdateTable(connect, trans, DV, "SELECT * FROM " & db_tbl_DataValues))
        _tc.Add(db_tbl_DataValues, m_Connection.insertBulk(connect, trans, DV))
        If (_tc(db_tbl_DataValues) > 0) Then
            'otherCount += count
            'LogUpdate(_tc(db_tbl_DataValues) & " rows committed to DataValues")
            'Else
            'Throw New Exception("No Valid DataValues")
        End If
        'LogUpdate("Updating Series Catalog")
        _tc.Add(db_tbl_SeriesCatalog, UpdateSeriesCatalogTable(connect, trans, DV))
        If (_tc(db_tbl_SeriesCatalog) > 0) Then
            'otherCount += count
            'LogUpdate(_tc(db_tbl_SeriesCatalog) & " rows committed to SeriesCatalog")
        End If
        GC.Collect()
        Dim otherCount As Integer = getTotalRows(_tc)
        'If (_tc(db_tbl_SeriesCatalog) > 0) AndAlso ((otherCount - _tc(db_tbl_SeriesCatalog)) > 0) Then
        If (_tc(db_tbl_DataValues) > 0 AndAlso _tc(db_tbl_SeriesCatalog) > 0) AndAlso ((otherCount - _tc(db_tbl_SeriesCatalog)) > 0) Then
#If DEBUG Then
            MsgBox("Trans.commit")
#End If
            trans.Commit()
            Return _tc
        Else
            Throw New Exception("An Error Occurred. Rolling back database transaction.")
        End If

    End Function
    Private Function getTotalRows(ByVal _clsTableCount As clsTableCount) As Integer
        Dim count As Integer = 0
        For Each c As KeyValuePair(Of String, Integer) In _clsTableCount
            If (c.Value > 0) Then
                count += c.Value
            End If
        Next
        Return count
    End Function
    'Protected Function UpdateSeriesCatalogTableNewest(ByVal connect As SqlClient.SqlConnection, ByRef trans As System.Data.SqlClient.SqlTransaction, ByVal valid As DataTable) As Integer
    '    Dim SC As DataTable
    '    Dim Fields() As String = {db_fld_SiteID, db_fld_VariableID, db_fld_MethodID, db_fld_SourceID, db_fld_QualityControlLevelID}
    '    Dim NumToUpdate = 0
    '    'Dim SeriesToUpdate As DataTable = SelectDistinct(valid, Fields)
    '    Dim SeriesToUpdate As Object
    '    Dim valDT2 As IEnumerable(Of DataRow) = New VBEnumerator.EnumerableDataRows(Of DataRow)(valid.Rows)
    '    SeriesToUpdate = _
    '                    From series In valDT2 _
    '                    Where 1 = 1 _
    '                    Group series By sID = series.Item("SiteID"), vID = series.Item("VariableID"), mID = series.Item("MethodID"), soID = series.Item("SourceID"), qID = series.Item("QualityControlLevelID") _
    '                    Into ValueCount = Count(CType(series.Item("DataValue"), Double)), EndDate = Max(CType(series.Item("LocalDateTime"), DateTime)), StartDate = Min(CType(series.Item("LocalDateTime"), DateTime)), Group

    '    'NumToUpdate = SeriesToUpdate.Rows.Count
    '    Dim SiteWhere As String = db_fld_SiteID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_SiteID)))) & ")"
    '    Dim VariableWhere As String = db_fld_VariableID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_VariableID)))) & ")"
    '    Dim MethodWhere As String = db_fld_MethodID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_MethodID)))) & ")"
    '    Dim SourceWhere As String = db_fld_SourceID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_SourceID)))) & ")"
    '    Dim QCLWhere As String = db_fld_QualityControlLevelID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_QualityControlLevelID)))) & ")"
    '    Dim SCSelect As String = "Select * From SeriesCatalog"
    '    Dim SCDVWhere = " Where " & SiteWhere & " AND " & VariableWhere & " AND " & MethodWhere & " AND " & SourceWhere & " AND " & QCLWhere

    '    SC = m_Connection.OpenTable(connect, trans, "SeriesCatalog", SCSelect & SCDVWhere)
    '    If (SeriesToUpdate.Rows.Count > 0) Then
    '        'For i As Integer = 0 To SeriesToUpdate.Rows.Count - 1
    '        For Each Rows As Object In SeriesToUpdate
    '            Dim result As DataRow = Rows.Group(0)
    '            'Dim newRow As DataRow = SC.NewRow
    '            Dim SiteID As Integer = result.Item(db_fld_SCSiteID)
    '            Dim VariableID As Integer = result.Item(db_fld_SCVarID)
    '            Dim MethodID As Integer = result.Item(db_fld_SCMethodID)
    '            Dim SourceID As Integer = result.Item(db_fld_SCSourceID)
    '            Dim QualityControlLevelID As Integer = result.Item(db_fld_SCQCLevelID)
    '            Dim rownum As Integer = 0
    '            Dim Updated() As DataRow = SC.Select("(" & db_fld_SiteID & " = " & SiteID & ") AND (" & db_fld_VariableID & " = " & VariableID & ") AND (" & db_fld_MethodID & " = " & MethodID & ") AND (" & db_fld_SourceID & " = " & SourceID & ") AND (" & db_fld_QQualityControlLevelID & " = " & QualityControlLevelID & ")")

    '            If (Updated.Length = 1) Then
    '                'if a series is found then update it 
    '                'Dim dvData As DataRow = Get_SCData_From_DV(connect, trans, SiteID, VariableID, MethodID, SourceID, QualityControlLevelID)
    '                If (Updated(0).Item(db_fld_SCBeginDT) < result.Item(db_fld_SCBeginDT)) Then
    '                    Updated(0).Item(db_fld_SCBeginDT) = result.Item(db_fld_SCBeginDT)
    '                    Updated(0).Item(db_fld_SCBeginDTUTC) = result.Item(db_fld_SCBeginDT).Add(New TimeSpan(-Updated(0).Item(db_fld_UTCOffset), 0, 0))
    '                End If
    '                If Updated(0).Item(db_fld_SCEndDT > result.Item(db_fld_SCEndDT)) Then
    '                    Updated(0).Item(db_fld_SCEndDT) = result.Item(db_fld_SCBeginDT)
    '                    Updated(0).Item(db_fld_SCEndDTUTC) = result.Item(db_fld_SCEndDTUTC).Add(New TimeSpan(-Updated(0).Item(db_fld_UTCOffset), 0, 0))
    '                End If
    '                Updated(0).Item(db_fld_SCValueCount) = Updated(0).Item(db_fld_SCValueCount) + result.Item(db_fld_SCValueCount)
    '                Updated(0).SetModified()

    '            Else
    '                rownum += 1
    '                'if new series is found create a new data row and add it to the table
    '                Dim SCQuery As String = "SELECT " & rownum & " As SeriesID, dv.SiteID, s.SiteCode, s.SiteName, dv.VariableID, v.VariableCode, " _
    '                   & "v.VariableName, v.Speciation, v.VariableUnitsID, u.UnitsName AS VariableUnitsName, v.SampleMedium, " _
    '                   & "v.ValueType, v.TimeSupport, v.TimeUnitsID, u1.UnitsName AS TimeUnitsName, v.DataType, " _
    '                   & "v.GeneralCategory, dv.MethodID, m.MethodDescription, dv.SourceID, so.Organization, " _
    '                   & "so.SourceDescription, so.Citation, dv.QualityControlLevelID, qc.QualityControlLevelCode, " _
    '                   & "MIN(dv.LocalDateTime) AS BeginDateTime, MAX(dv.LocalDateTime) AS EndDateTime, " _
    '                   & "MIN(dv.DateTimeUTC) AS BeginDateTimeUTC, MAX(dv.DateTimeUTC) AS EndDateTimeUTC, " _
    '                   & "COUNT(dv.DataValue) AS ValueCount  " _
    '                   & "FROM DataValues as dv " _
    '                   & "INNER JOIN dbo.Sites s ON dv.SiteID = s.SiteID " _
    '                   & "INNER JOIN dbo.Variables v ON dv.VariableID = v.VariableID " _
    '                   & "INNER JOIN dbo.Units u ON v.VariableUnitsID = u.UnitsID " _
    '                   & "INNER JOIN dbo.Methods m ON dv.MethodID = m.MethodID " _
    '                   & "INNER JOIN dbo.Units u1 ON v.TimeUnitsID = u1.UnitsID " _
    '                   & "INNER JOIN dbo.Sources so ON dv.SourceID = so.SourceID " _
    '                   & "INNER JOIN dbo.QualityControlLevels qc ON dv.QualityControlLevelID = qc.QualityControlLevelID " _
    '                   & "Where dv.SiteID =" & SiteID & " AND dv.VariableID=" & VariableID & " And dv.MethodID=" & MethodID _
    '                   & " AND dv.SourceID =" & SourceID & " And dv.QualityControlLevelID =" & QualityControlLevelID _
    '                   & " GROUP BY   dv.SiteID, s.SiteCode, s.SiteName, dv.VariableID, v.VariableCode, v.VariableName, v.Speciation, " _
    '                   & "v.VariableUnitsID, u.UnitsName, v.SampleMedium, v.ValueType, v.TimeSupport, v.TimeUnitsID, u1.UnitsName, " _
    '                   & "v.DataType, v.GeneralCategory, dv.MethodID, m.MethodDescription, dv.SourceID, so.Organization, " _
    '                   & "so.SourceDescription, so.Citation, dv.QualityControlLevelID, qc.QualityControlLevelCode "
    '                SC.ImportRow(m_Connection.OpenTable(connect, trans, "SeriesCatalog", SCQuery).Rows(0))
    '                SC.Rows(SC.Rows.Count - 1).SetAdded()
    '            End If
    '        Next

    '        Dim count As Integer = m_Connection.UpdateTable(connect, trans, SC, SCSelect) '& SCDVWhere)
    '        If (count = NumToUpdate) Then
    '            Return count
    '        Else
    '            Throw New Exception("Only " & count & " out of " & NumToUpdate & " rows found.")
    '        End If
    '    Else
    '        Throw New Exception("Error Checking DataValues for SeriesCatalog Update")
    '    End If
    'End Function
    'Protected Function UpdateSeriesCatalogTableNew(ByVal connect As SqlClient.SqlConnection, ByRef trans As System.Data.SqlClient.SqlTransaction, ByVal valid As DataTable) As Integer
    '    Dim SC As DataTable
    '    Dim Fields() As String = {db_fld_SiteID, db_fld_VariableID, db_fld_MethodID, db_fld_SourceID, db_fld_QualityControlLevelID}
    '    Dim NumToUpdate = 0
    '    Dim SeriesToUpdate As DataTable = SelectDistinct(valid, Fields)

    '    NumToUpdate = SeriesToUpdate.Rows.Count
    '    Dim SiteWhere As String = db_fld_SiteID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_SiteID)))) & ")"
    '    Dim VariableWhere As String = db_fld_VariableID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_VariableID)))) & ")"
    '    Dim MethodWhere As String = db_fld_MethodID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_MethodID)))) & ")"
    '    Dim SourceWhere As String = db_fld_SourceID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_SourceID)))) & ")"
    '    Dim QCLWhere As String = db_fld_QualityControlLevelID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_QualityControlLevelID)))) & ")"
    '    Dim SCSelect As String = "Select * From SeriesCatalog"
    '    Dim SCDVWhere = " Where " & SiteWhere & " AND " & VariableWhere & " AND " & MethodWhere & " AND " & SourceWhere & " AND " & QCLWhere

    '    SC = m_Connection.OpenTable(connect, trans, "SeriesCatalog", SCSelect & SCDVWhere)
    '    If (SeriesToUpdate.Rows.Count > 0) Then
    '        For i As Integer = 0 To SeriesToUpdate.Rows.Count - 1

    '            'Dim newRow As DataRow = SC.NewRow
    '            Dim SiteID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCSiteID)
    '            Dim VariableID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCVarID)
    '            Dim MethodID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCMethodID)
    '            Dim SourceID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCSourceID)
    '            Dim QualityControlLevelID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCQCLevelID)
    '            Dim rownum As Integer = 0
    '            Dim Updated() As DataRow = SC.Select("(" & db_fld_SiteID & " = " & SiteID & ") AND (" & db_fld_VariableID & " = " & VariableID & ") AND (" & db_fld_MethodID & " = " & MethodID & ") AND (" & db_fld_SourceID & " = " & SourceID & ") AND (" & db_fld_QQualityControlLevelID & " = " & QualityControlLevelID & ")")

    '            If (Updated.Length = 1) Then
    '                'if a series is found then update it 
    '                Dim dvData As DataRow = Get_SCData_From_DV(connect, trans, SiteID, VariableID, MethodID, SourceID, QualityControlLevelID)
    '                Updated(0).Item(db_fld_SCBeginDT) = dvData.Item(db_fld_SCBeginDT)
    '                Updated(0).Item(db_fld_SCEndDT) = dvData.Item(db_fld_SCEndDT)
    '                Updated(0).Item(db_fld_SCBeginDTUTC) = dvData.Item(db_fld_SCBeginDTUTC)
    '                Updated(0).Item(db_fld_SCEndDTUTC) = dvData.Item(db_fld_SCEndDTUTC)
    '                Updated(0).Item(db_fld_SCValueCount) = dvData.Item(db_fld_SCValueCount)
    '                Updated(0).SetModified()

    '            Else
    '                rownum += 1
    '                'if new series is found create a new data row and add it to the table
    '                Dim SCQuery As String = "SELECT " & rownum & " As SeriesID, dv.SiteID, s.SiteCode, s.SiteName, dv.VariableID, v.VariableCode, " _
    '                   & "v.VariableName, v.Speciation, v.VariableUnitsID, u.UnitsName AS VariableUnitsName, v.SampleMedium, " _
    '                   & "v.ValueType, v.TimeSupport, v.TimeUnitsID, u1.UnitsName AS TimeUnitsName, v.DataType, " _
    '                   & "v.GeneralCategory, dv.MethodID, m.MethodDescription, dv.SourceID, so.Organization, " _
    '                   & "so.SourceDescription, so.Citation, dv.QualityControlLevelID, qc.QualityControlLevelCode, " _
    '                   & "MIN(dv.LocalDateTime) AS BeginDateTime, MAX(dv.LocalDateTime) AS EndDateTime, " _
    '                   & "MIN(dv.DateTimeUTC) AS BeginDateTimeUTC, MAX(dv.DateTimeUTC) AS EndDateTimeUTC, " _
    '                   & "COUNT(dv.DataValue) AS ValueCount  " _
    '                   & "FROM DataValues as dv " _
    '                   & "INNER JOIN dbo.Sites s ON dv.SiteID = s.SiteID " _
    '                   & "INNER JOIN dbo.Variables v ON dv.VariableID = v.VariableID " _
    '                   & "INNER JOIN dbo.Units u ON v.VariableUnitsID = u.UnitsID " _
    '                   & "INNER JOIN dbo.Methods m ON dv.MethodID = m.MethodID " _
    '                   & "INNER JOIN dbo.Units u1 ON v.TimeUnitsID = u1.UnitsID " _
    '                   & "INNER JOIN dbo.Sources so ON dv.SourceID = so.SourceID " _
    '                   & "INNER JOIN dbo.QualityControlLevels qc ON dv.QualityControlLevelID = qc.QualityControlLevelID " _
    '                   & "Where dv.SiteID =" & SiteID & " AND dv.VariableID=" & VariableID & " And dv.MethodID=" & MethodID _
    '                   & " AND dv.SourceID =" & SourceID & " And dv.QualityControlLevelID =" & QualityControlLevelID _
    '                   & " GROUP BY   dv.SiteID, s.SiteCode, s.SiteName, dv.VariableID, v.VariableCode, v.VariableName, v.Speciation, " _
    '                   & "v.VariableUnitsID, u.UnitsName, v.SampleMedium, v.ValueType, v.TimeSupport, v.TimeUnitsID, u1.UnitsName, " _
    '                   & "v.DataType, v.GeneralCategory, dv.MethodID, m.MethodDescription, dv.SourceID, so.Organization, " _
    '                   & "so.SourceDescription, so.Citation, dv.QualityControlLevelID, qc.QualityControlLevelCode "
    '                SC.ImportRow(m_Connection.OpenTable(connect, trans, "SeriesCatalog", SCQuery).Rows(0))
    '                SC.Rows(SC.Rows.Count - 1).SetAdded()
    '            End If
    '        Next

    '        Dim count As Integer = m_Connection.UpdateTable(connect, trans, SC, SCSelect) '& SCDVWhere)
    '        If (count = NumToUpdate) Then
    '            Return count
    '        Else
    '            Throw New Exception("Only " & count & " out of " & NumToUpdate & " rows found.")
    '        End If
    '    Else
    '        Throw New Exception("Error Checking DataValues for SeriesCatalog Update")
    '    End If
    'End Function


    Protected Function UpdateSeriesCatalogTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction, ByVal valid As DataTable) As Integer
        Dim Fields() As String = {db_fld_SiteID, db_fld_VariableID, db_fld_MethodID, db_fld_SourceID, db_fld_QualityControlLevelID}
        Const db_expr_VarUnitsName As String = "VariableUnitsName"
        Const db_expr_TimeUnitsName As String = "TimeUnitsName"

        Dim SCSelect As String = "SELECT * FROM SeriesCatalog"

        Dim SiteSelect As String
        If (m_Connection.getODMVersion = "1.1.1") Then
            SiteSelect = "SELECT SiteID, SiteCode, SiteName, SiteType FROM Sites"
        Else
            SiteSelect = "SELECT SiteID, SiteCode, SiteName FROM Sites"
        End If
        Dim VariableSelect As String = "SELECT VariableID, VariableCode, VariableName, Speciation, VariableUnitsID, VariableUnits.UnitsName AS VariableUnitsName, SampleMedium, ValueType, IsRegular, TimeSupport, TimeUnitsID, TimeUnits.UnitsName AS TimeUnitsName, DataType, GeneralCategory FROM Variables LEFT OUTER JOIN Units AS VariableUnits ON Variables.VariableUnitsID = VariableUnits.UnitsID LEFT OUTER JOIN Units AS TimeUnits ON Variables.TimeUnitsID = TimeUnits.UnitsID "
        Dim MethodSelect As String = "SELECT MethodID, MethodDescription FROM Methods"
        Dim SourceSelect As String = "SELECT SourceID, Organization, SourceDescription, Citation FROM Sources"
        Dim QualityControlLevelSelect As String = "SELECT QualityControlLevelID, QualityControlLevelCode FROM QualityControlLevels"
        Dim SiteWhere As String
        Dim VariableWhere As String
        Dim MethodWhere As String
        Dim SourceWhere As String
        Dim QualityControlLevelWhere As String

        Dim SC As New DataTable
        Dim Sites As New DataTable
        Dim Variables As New DataTable
        Dim Methods As New DataTable
        Dim Sources As New DataTable
        Dim QualityControlLevels As New DataTable
        Dim SeriesToUpdate As New DataTable

        Dim i As Integer
        Dim NumToUpdate As Integer

        SeriesToUpdate = SelectDistinct(valid, Fields)
        NumToUpdate = SeriesToUpdate.Rows.Count
        If (SeriesToUpdate.Rows.Count > 0) Then
            'Set All of the Query Parts
            'SeriesToUpdate.Columns.Cast(Of String)().ToArray()
            Dim SiteWhere2 As String = " WHERE " & db_fld_SiteID & " IN (" & String.Join(",", Array.ConvertAll(Of DataRow, String)(SeriesToUpdate.Select(), New Converter(Of DataRow, String)(Function(row) row(db_fld_SiteID)))) & ")"

            SiteWhere = " WHERE " & db_fld_SiteID & " IN (" & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(0).Item(db_fld_SiteID))
            VariableWhere = " WHERE " & db_fld_VariableID & " IN (" & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(0).Item(db_fld_VariableID))
            MethodWhere = " WHERE " & db_fld_MethodID & " IN (" & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(0).Item(db_fld_MethodID))
            SourceWhere = " WHERE " & db_fld_SourceID & " IN (" & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(0).Item(db_fld_SourceID))
            QualityControlLevelWhere = " WHERE " & db_fld_QualityControlLevelID & " IN (" & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(0).Item(db_fld_QualityControlLevelID))
            For i = 1 To (SeriesToUpdate.Rows.Count - 1)
                SiteWhere &= ", " & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(i).Item(db_fld_SiteID))
                VariableWhere &= ", " & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(i).Item(db_fld_VariableID))
                MethodWhere &= ", " & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(i).Item(db_fld_MethodID))
                SourceWhere &= ", " & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(i).Item(db_fld_SourceID))
                QualityControlLevelWhere &= ", " & m_Connection.FormatStringForQuery(SeriesToUpdate.Rows(i).Item(db_fld_QualityControlLevelID))
            Next i
            SiteWhere &= ")"
            VariableWhere &= ")"
            MethodWhere &= ")"
            SourceWhere &= ")"
            QualityControlLevelWhere &= ")"

            SC = m_Connection.OpenTable(connect, trans, "SeriesCatalog", SCSelect) '& SCDVWhere)


            For i = 0 To (SC.Rows.Count - 1)
                Dim SiteID As Integer = SC.Rows(i).Item(db_fld_SCSiteID)
                Dim VariableID As Integer = SC.Rows(i).Item(db_fld_SCVarID)
                Dim MethodID As Integer = SC.Rows(i).Item(db_fld_SCMethodID)
                Dim SourceID As Integer = SC.Rows(i).Item(db_fld_SCSourceID)
                Dim QualityControlLevelID As Integer = SC.Rows(i).Item(db_fld_SCQCLevelID)

                Dim dvData As DataRow = Get_SCData_From_DV(connect, trans, SiteID, VariableID, MethodID, SourceID, QualityControlLevelID)
                Dim Updated() As DataRow = SeriesToUpdate.Select("(" & db_fld_SiteID & " = " & SiteID & ") AND (" & db_fld_VariableID & " = " & VariableID & ") AND (" & db_fld_MethodID & " = " & MethodID & ") AND (" & db_fld_SourceID & " = " & SourceID & ") AND (" & db_fld_QQualityControlLevelID & " = " & QualityControlLevelID & ")")

                If (Updated.Length = 1) Then
                    SC.Rows(i).Item(db_fld_SCBeginDT) = dvData.Item(db_fld_SCBeginDT)
                    SC.Rows(i).Item(db_fld_SCEndDT) = dvData.Item(db_fld_SCEndDT)
                    SC.Rows(i).Item(db_fld_SCBeginDTUTC) = dvData.Item(db_fld_SCBeginDTUTC)
                    SC.Rows(i).Item(db_fld_SCEndDTUTC) = dvData.Item(db_fld_SCEndDTUTC)
                    SC.Rows(i).Item(db_fld_SCValueCount) = dvData.Item(db_fld_SCValueCount)
                    SeriesToUpdate.Rows.Remove(Updated(0))
                Else
                    'Throw New Exception("Error Updating Series Catalog Table." & vbCrLf & "Missing DataValue Information.")
                End If
            Next i
            If SeriesToUpdate.Rows.Count > 0 Then

                Variables = m_Connection.OpenTable(connect, trans, "Variables", VariableSelect & VariableWhere)
                Methods = m_Connection.OpenTable(connect, trans, "Methods", MethodSelect & MethodWhere)
                Sources = m_Connection.OpenTable(connect, trans, "Sources", SourceSelect & SourceWhere)
                QualityControlLevels = m_Connection.OpenTable(connect, trans, "QualityControlLevels", QualityControlLevelSelect & QualityControlLevelWhere)
                Sites = m_Connection.OpenTable(connect, trans, "Sites", SiteSelect & SiteWhere)

                For i = 0 To (SeriesToUpdate.Rows.Count - 1)
                    Dim newRow As DataRow = SC.NewRow
                    Dim SiteID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCSiteID)
                    Dim VariableID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCVarID)
                    Dim MethodID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCMethodID)
                    Dim SourceID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCSourceID)
                    Dim QualityControlLevelID As Integer = SeriesToUpdate.Rows(i).Item(db_fld_SCQCLevelID)
                    Dim TestRows() As DataRow

                    newRow.Item(db_fld_SCSeriesID) = i
                    TestRows = Sites.Select(db_fld_SiteID & " = " & SiteID)
                    If (TestRows.Length = 1) Then
                        newRow.Item(db_fld_SCSiteID) = SiteID
                        newRow.Item(db_fld_SCSiteCode) = TestRows(0).Item(db_fld_SiteCode)
                        newRow.Item(db_fld_SCSiteName) = TestRows(0).Item(db_fld_SiteName)
                        If (m_Connection.getODMVersion = "1.1.1") Then
                            newRow.Item(db_fld_SCSiteType) = TestRows(0).Item(db_fld_SiteType)
                        End If
                    Else
                        Throw New Exception("Error Updating Series Catalog Table.<br>Missing Site Information.")
                    End If
                    TestRows = Variables.Select(db_fld_VariableID & " = " & VariableID)
                    If (TestRows.Length = 1) Then
                        newRow.Item(db_fld_SCVarID) = VariableID
                        newRow.Item(db_fld_SCVarCode) = TestRows(0).Item(db_fld_VariableCode)
                        newRow.Item(db_fld_SCVarName) = TestRows(0).Item(db_fld_VariableName)
                        newRow.Item(db_fld_SCSpec) = TestRows(0).Item(db_fld_Speciation)
                        newRow.Item(db_fld_SCVarUnitsID) = TestRows(0).Item(db_fld_VariableUnitsID)
                        newRow.Item(db_fld_SCVarUnitsName) = TestRows(0).Item(db_expr_VarUnitsName)
                        newRow.Item(db_fld_SCSampleMed) = TestRows(0).Item(db_fld_SampleMedium)
                        newRow.Item(db_fld_SCValueType) = TestRows(0).Item(db_fld_ValueType)
                        newRow.Item(db_fld_SCTimeSupport) = TestRows(0).Item(db_fld_TimeSupport)
                        newRow.Item(db_fld_SCTimeUnitsID) = TestRows(0).Item(db_fld_TimeUnitsID)
                        newRow.Item(db_fld_SCTimeUnitsName) = TestRows(0).Item(db_expr_TimeUnitsName)
                        newRow.Item(db_fld_SCDataType) = TestRows(0).Item(db_fld_DataType)
                        newRow.Item(db_fld_SCGenCat) = TestRows(0).Item(db_fld_GeneralCategory)
                    Else
                        Throw New Exception("Error Updating Series Catalog Table.<br>Missing Variable Information.")
                    End If
                    TestRows = Methods.Select(db_fld_MethodID & " = " & MethodID)
                    If (TestRows.Length = 1) Then
                        newRow.Item(db_fld_SCMethodID) = MethodID
                        newRow.Item(db_fld_SCMethodDesc) = TestRows(0).Item(db_fld_MethodDescription)
                    Else
                        Throw New Exception("Error Updating Series Catalog Table.<br>Missing Method Information.")
                    End If
                    TestRows = Sources.Select(db_fld_SourceID & " = " & SourceID)
                    If (TestRows.Length = 1) Then
                        newRow.Item(db_fld_SCSourceID) = SourceID
                        newRow.Item(db_fld_SCOrganization) = TestRows(0).Item(db_fld_Organization)
                        newRow.Item(db_fld_SCSourceDesc) = TestRows(0).Item(db_fld_SourceDescription)
                        newRow.Item(db_fld_SCCitation) = TestRows(0).Item(db_fld_Citation)
                    Else
                        Throw New Exception("Error Updating Series Catalog Table.<br>Missing Source Information.")
                    End If
                    TestRows = QualityControlLevels.Select(db_fld_QualityControlLevelID & " = " & QualityControlLevelID)
                    If (TestRows.Length = 1) Then
                        newRow.Item(db_fld_SCQCLevelID) = QualityControlLevelID
                        newRow.Item(db_fld_SCQCLevelCode) = TestRows(0).Item(db_fld_QualityControlLevelCode)
                    Else
                        Throw New Exception("Error Updating Series Catalog Table.<br>Missing QualityControlLevel Information.")
                    End If
                    Dim TestRow As DataRow = Get_SCData_From_DV(connect, trans, SiteID, VariableID, MethodID, SourceID, QualityControlLevelID)
                    If Not (TestRow Is Nothing) Then
                        newRow.Item(db_fld_SCBeginDT) = TestRow.Item(db_fld_SCBeginDT)
                        newRow.Item(db_fld_SCEndDT) = TestRow.Item(db_fld_SCEndDT)
                        newRow.Item(db_fld_SCBeginDTUTC) = TestRow.Item(db_fld_SCBeginDTUTC)
                        newRow.Item(db_fld_SCEndDTUTC) = TestRow.Item(db_fld_SCEndDTUTC)
                        newRow.Item(db_fld_SCValueCount) = TestRow.Item(db_fld_SCValueCount)
                    Else
                        Throw New Exception("Error Updating Series Catalog Table.<br>Missing DataValue Information.")
                    End If
                    SC.Rows.Add(newRow)
                Next i
            End If
            Dim count As Integer = m_Connection.UpdateTable(connect, trans, SC, SCSelect) '& SCDVWhere)
            If (count = NumToUpdate) Then
                Return count
            Else
                Throw New Exception("Only " & count & " out of " & NumToUpdate & " rows found.")
            End If
        Else
            Throw New Exception("Error Checking DataValues for SeriesCatalog Update")
        End If

    End Function

    Private Function Get_SCData_From_DV(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction, ByVal siteID As String, ByVal variableID As String, ByVal methodID As String, ByVal sourceID As String, ByVal qualitycontrollevelID As String) As DataRow
        Dim newRow As DataRow = Nothing
        Dim DV As New DataTable
        Dim DVSelect As String = "SELECT SiteID, VariableID, MethodID, SourceID, QualityControlLevelID, MIN(LocalDateTime) AS BeginDateTime, MAX(LocalDateTime) AS EndDateTime, MIN(DateTimeUTC) AS BeginDateTimeUTC, MAX(DateTimeUTC) as EndDateTimeUTC, COUNT(ValueID) AS ValueCount FROM DataValues"
        Dim SCDVWhere As String
        Dim DVGroupBy As String = " GROUP BY SiteID, VariableID, MethodID, SourceID, QualityControlLevelID"

        SCDVWhere = " WHERE ((" & db_fld_SiteID & " = " & siteID & ") AND (" & _
        db_fld_VariableID & " = " & variableID & ") AND (" & _
        db_fld_MethodID & " = " & methodID & ") AND (" & _
        db_fld_SourceID & " = " & sourceID & ") AND (" & _
        db_fld_QualityControlLevelID & " = " & qualitycontrollevelID & "))"

        DV = m_Connection.OpenTable(connect, trans, "DataValues", DVSelect & SCDVWhere & DVGroupBy)
        If DV.Rows.Count = 1 Then
            Return DV.Rows(0)
        Else
            Throw New Exception("No valid DV data to retrieve to update series catalog.")
        End If
    End Function
End Class
