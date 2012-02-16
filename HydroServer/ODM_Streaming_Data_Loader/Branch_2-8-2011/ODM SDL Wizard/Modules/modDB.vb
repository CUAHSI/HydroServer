'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..

Module modDB
    'Last Documented 9/4/07

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

#Region "Categories"
    'Categories
    Public Const db_tbl_Categories As String = "Categories" 'Table Name
    Public Const db_fld_CatVarID As String = "VariableID" 'M Integer: Primary Key -> Unique ID for each Category entry
    Public Const db_fld_CatValue As String = "Value" 'M Double -> Numeric Value
    Public Const db_fld_CatDesc As String = "CategoryDescription" 'M String: 255 -> Definition of categorical variable value
#End Region

#Region "DataValues"
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
#End Region

#Region "DerivedFrom"
    'DerivedFrom
    Public Const db_tbl_DerivedFrom As String = "DerivedFrom" 'Table Name
    Public Const db_fld_DFID As String = "DerivedFromID" 'M Integer -> Unique ID for each group of Derived From entries
    Public Const db_fld_DFValueID As String = "ValueID" 'M Integer -> Corresponds to the value id(s) the Derived Value came from
#End Region

#Region "GroupDescriptions"
    'GroupDescriptions
    Public Const db_tbl_GroupDesc As String = "GroupDescriptions" 'Table Name
    Public Const db_fld_GDGroupID As String = "GroupID" 'M Integer: Primary Key -> Unique ID for each GroupDescriptions entry
    Public Const db_fld_GDDesc As String = "GroupDescription" 'O String: 255 -> Text description of the group
#End Region

#Region "Groups"
    'Groups 
    Public Const db_tbl_Groups As String = "Groups" 'Table Name
    Public Const db_fld_GroupID As String = "GroupID" 'M Integer -> Unique ID for each group of Values
    Public Const db_fld_GroupValueID As String = "ValueID" 'M Integer -> Corresponds to the value id of each value in the group
#End Region

#Region "ISOMetaData"
    'ISOMetaData
    Public Const db_tbl_ISOMetaData As String = "ISOMetaData" 'Table Name
    Public Const db_fld_IMDMetaID As String = "MetaDataID" 'M Integer: Primary Key -> Unique ID for each ISOMetaData entry
    Public Const db_fld_IMDTopicCat As String = "TopicCategory" 'M String: 50 -> Topic category keyword that gives the broad ISO19115 metadata topic category for data from this source.  CV
    Public Const db_fld_IMDTitle As String = "Title" 'M String: 255 -> Title of data from a specific data source
    Public Const db_fld_IMDAbstract As String = "Abstract" 'M String: 255 -> Abstract of data from a specific data source
    Public Const db_fld_IMDProfileVs As String = "ProfileVersion" 'M String: 50 -> Abstract of data from a specific data source
    Public Const db_fld_IMDMetaLink As String = "MetadataLink" 'O String: H -> Link to additional metadata reference material
#End Region

#Region "LabMethods"
    'LabMethods
    Public Const db_tbl_LabMethods As String = "LabMethods" 'Table Name
    Public Const db_fld_LMID As String = "LabMethodID" 'M Integer: Primary Key -> Unique ID for each LabMethods entry
    Public Const db_fld_LMLabName As String = "LabName" 'M String: 255 -> Name of the laboratory responsible for processing the sample
    Public Const db_fld_LMLabOrg As String = "LabOrganization" 'M String: 255 -> Organization responsible for sample analysis
    Public Const db_fld_LMName As String = "LabMethodName" 'M String: 255 -> Name of the method and protocols used for sample analysis
    Public Const db_fld_LMDesc As String = "LabMethodDescription" 'M String: 255 -> Description of the method and protocols used for sample analysis
    Public Const db_fld_LMLink As String = "LabMethodLink" 'O String: H -> Link to additional reference material to the analysis method
#End Region

#Region "Methods"
    'Methods
    Public Const db_tbl_Methods As String = "Methods" 'Table Name
    Public Const db_fld_MethID As String = "MethodID" 'M Integer: Primary Key -> Unique ID for each Methods entry
    Public Const db_fld_MethDesc As String = "MethodDescription" 'M String: 255 -> Text descriptionof each method including Quality Assurance and Quality Control procedures
    Public Const db_fld_MethLink As String = "MethodLink" 'O String: H -> Link to additional reference material on the method
#End Region

#Region "OffsetTypes"
    'OffsetTypes
    Public Const db_tbl_OffsetTypes As String = "OffsetTypes" 'Table Name
    Public Const db_fld_OTID As String = "OffsetTypeID" 'M Integer: Primary Key ->Unique ID for each OffsetTypes entry 
    Public Const db_fld_OTUnitsID As String = "OffsetUnitsID" 'M Integer -> Linked to Units.UnitsID
    Public Const db_fld_OTDesc As String = "OffsetDescription" 'M String: 255 -> Full text description of the offset type
#End Region

#Region "Qualifiers"
    'Qualifiers
    Public Const db_tbl_Qualifiers As String = "Qualifiers" 'Table Name
    Public Const db_fld_QlfyID As String = "QualifierID" 'M Integer: Primary Key -> Unique ID for each Qualifiers entry
    Public Const db_fld_QlfyCode As String = "QualifierCode" 'O String: 50 -> Text code used by organization that collects the data
    Public Const db_fld_QlfyDesc As String = "QualifierDescription" 'M String: 255 -> Text of the data qualifying comment
#End Region

#Region "QualityControlLevels"
    'QualityControlLevels
    Public Const db_tbl_QCLevels As String = "QualityControlLevels" ''Table Name
    Public Const db_fld_QCLQCLevelID As String = "QualityControlLevelID" 'M Integer: Primary Key -> 
    Public Const db_fld_QCLQCLevelCode As String = "QualityControlLevelCode"
    Public Const db_fld_QCLDefinition As String = "Definition" 'M String: 255 -> Definition of Quality Control Level
    Public Const db_fld_QCLExplanation As String = "Explanation" 'M String: 500 -> Explanation of Quality Control Level
#End Region

#Region "Samples"
    'Samples
    Public Const db_tbl_Samples As String = "Samples" 'Table Name
    Public Const db_fld_SampleID As String = "SampleID" 'M Integer: Primary Key -> Unique ID for each Samples entry
    Public Const db_fld_SampleType As String = "SampleType" 'M String: 50 -> CV specifying the sample type
    Public Const db_fld_SampleLabCode As String = "LabSampleCode" 'M String: 50 -> Code or label used to identify and track lab sample/sample-container (e.g. bottle) during lab analysis
    Public Const db_fld_SampleMethodID As String = "LabMethodID" 'M Integer -> Linked to LabMethods.LabMethodID
#End Region

#Region "SeriesCatalog"
    'SeriesCatalog
    Public Const db_tbl_SeriesCatalog As String = "SeriesCatalog" 'Table Name
    Public Const db_fld_SCSeriesID As String = "SeriesID" 'P Integer: Primary Key -> Unique ID for each SeriesCatalog entry
    Public Const db_fld_SCSiteID As String = "SiteID" 'P Integer -> Linked to Sites.SiteID
    Public Const db_fld_SCSiteCode As String = "SiteCode" 'P String: 50 -> Site Identifier used by organization that collects the data
    Public Const db_fld_SCSiteName As String = "SiteName" 'P String: 255 -> Full text name of sampling location
    Public Const db_fld_SCVarID As String = "VariableID" 'P Integer -> Linked to Variables.VariableID
    Public Const db_fld_SCVarCode As String = "VariableCode" 'P String: 50 -> Variable identifier used by the organization that collects the data
    Public Const db_fld_SCVarName As String = "VariableName" 'P String: 255 -> Name of the variable from the variables table
    Public Const db_fld_SCSpec As String = "Speciation"
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
    Public Const db_fld_SCSourceID As String = "SourceID" 'P Integer -> Corresponds to the ID of the Source for the Series
    Public Const db_fld_SCOrganization As String = "Organization" 'P String: 50 -> Corresponds to the Organization for the Series
    Public Const db_fld_SCSourceDesc As String = "SourceDescription" 'P String: 255 -> Corresponds to the Source Description for the Series
    Public Const db_fld_SCCitation As String = "Citation"
    Public Const db_fld_SCQCLevelID As String = "QualityControlLevelID"   'P Integer -> Corresponds to the Quality Control Level of the Series
    Public Const db_fld_SCQCLevelCode As String = "QualityControlLevelCode"
    Public Const db_fld_SCBeginDT As String = "BeginDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCEndDT As String = "EndDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCBeginDTUTC As String = "BeginDateTimeUTC" 'P DateTime -> The First UTC Date
    Public Const db_fld_SCEndDTUTC As String = "EndDateTimeUTC" 'P DateTime -> The Last UTC Date
    Public Const db_fld_SCValueCount As String = "ValueCount" 'P Integer -> The number of vaues in the series (SiteID & VariableID)
#End Region

#Region "Sites"
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

#Region "Sources"
    'Sources
    Public Const db_tbl_Sources As String = "Sources" 'Table Name
    Public Const db_fld_SrcID As String = "SourceID" 'M Integer: Primary Key -> Unique ID for each Sources entry
    Public Const db_fld_SrcOrg As String = "Organization" 'M String: 50 -> Name of organization that collected the data itself.  not who held it
    Public Const db_fld_SrcDesc As String = "SourceDescription" 'M String: 255 -> Full text description of the source of the data
    Public Const db_fld_SrcLink As String = "SourceLink" 'M String: H -> Link to original data file and associated metadata stored in the digital library or URL of data source
    Public Const db_fld_SrcContactName As String = "ContactName" 'M String: 50 -> Name of Contact Person for data source
    Public Const db_fld_SrcPhone As String = "Phone" 'M String: 50 -> Phone number for contact person
    Public Const db_fld_SrcEmail As String = "Email" 'M String: 50 -> email address for contact person
    Public Const db_fld_SrcAddress As String = "Address" 'M String: 255 -> Address for contact person
    Public Const db_fld_SrcCity As String = "City" 'M String: 50 -> city for contact person
    Public Const db_fld_SrcState As String = "State" 'M String: 50 -> state for contact person. 2 letter abreviations for "state, US", give full name for other countries
    Public Const db_fld_SrcZip As String = "ZipCode" 'M String: 50 -> US zip code or country postal code
    Public Const db_fld_SrcCitation As String = "Citation"
    Public Const db_fld_SrcMetaID As String = "MetaDataID" 'M Integer -> ISOMetaData.MetaDataID
#End Region

#Region "SpatialReferences"
    'SpatialReferences
    Public Const db_tbl_SpatialRefs As String = "SpatialReferences" 'Table Name
    Public Const db_fld_SRID As String = "SpatialReferenceID" 'M Integer: Primary Key -> Unique ID for each SpatialReferences entry
    Public Const db_fld_SRSRSID As String = "SRSID" 'O Integer -> ID for Spatial Reference System @ http://epsg.org/
    Public Const db_fld_SRSRSName As String = "SRSName" 'M String: 255 -> Name of spatial reference system
    Public Const db_fld_SRIsGeo As String = "IsGeographic" 'M Boolean -> Whether it uses geographic coordinates (Lat., Long.)
    Public Const db_fld_SRNotes As String = "Notes" 'O String: 500 -> Descriptive information about reference system
#End Region

#Region "Units"
    'Units
    Public Const db_tbl_Units As String = "Units" 'Table Name
    Public Const db_fld_UnitsID As String = "UnitsID" 'M Integer: Primary Key -> Unique ID for each Units entry
    Public Const db_fld_UnitsName As String = "UnitsName" 'M String: 255 -> Full name of the units
    Public Const db_fld_UnitsType As String = "UnitsType" 'M String: 50 -> Dimensions of the units
    Public Const db_fld_UnitsAbrv As String = "UnitsAbbreviation" 'M String: 50 -> Abbreviation for the units
#End Region

#Region "Variables"
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
    Public Const db_tbl_CensorCodeCV As String = "CensorCodeCV"
    Public Const db_tbl_DataTypeCV As String = "DataTypeCV"
    Public Const db_tbl_GeneralCategoryCV As String = "GeneralCategoryCV"
    Public Const db_tbl_SampleMediumCV As String = "SampleMediumCV"
    Public Const db_tbl_SampleTypeCV As String = "SampleTypeCV"
    Public Const db_tbl_SpeciationCV As String = "SpeciationCV"
    Public Const db_tbl_TopicCategoryCV As String = "TopicCategoryCV"
    Public Const db_tbl_ValueTypeCV As String = "ValueTypeCV"
    Public Const db_tbl_VariableNameCV As String = "VariableNameCV"
    Public Const db_tbl_VerticalDatumCV As String = "VerticalDatumCV"

    'fields
    Public Const db_fld_CV_Term As String = "Term"
    Public Const db_fld_CV_Definition As String = "Definition"

    'values
    Public Const db_val_VTCVTerm_DerivedValue As String = "Derived Value"
    Public Const db_val_DTCVTerm_Maximum As String = "Maximum"
    Public Const db_val_DTCVTerm_Minimum As String = "Minimum"
    Public Const db_val_DTCVTerm_Average As String = "Average"
    Public Const db_val_CCCVTerm_nc As String = "nc"

#End Region

#Region " Database Expressions "
    Public Const db_expr_Count As String = "DataCount"
    Public Const db_expr_New As String = "<New>"
    Public Const db_expr_None As String = "<None>"
    Public Const db_expr_Max As String = "FieldMax"
    Public Const db_expr_Default As String = "unknown"
    Public Const db_expr_ID As String = "ID"
    Public Const db_expr_View As String = "View"
    Public Const db_expr_DefaultQCL As String = "0"

    Public Const db_expr_MetaTitle As String = "MetadataTitle"
    Public Const db_expr_MetaAbstract As String = "MetadataAbstract"
    Public Const db_expr_VarUnits As String = "VariableUnits"
    Public Const db_expr_VarUnitsName As String = "VariableUnitsName"
    Public Const db_expr_TimeUnits As String = "TimeUnits"
    Public Const db_expr_TimeUnitsName As String = "TimeUnitsName"

#End Region

#Region " Database Functions "

    ''' <summary>
    ''' Retrieves an entire data table using the given query
    ''' </summary>
    ''' <param name="tableName">The name of the created DataTable to return</param>
    ''' <param name="SqlQuery">The SQL Query used to generate the DataTable</param>
    ''' <param name="settings">the connection settings to the database</param>
    ''' <returns>The DataTable created by the given query</returns>
    ''' <remarks></remarks>
    Public Function OpenTable(ByVal tableName As String, ByVal SqlQuery As String, ByRef settings As clsConnectionSettings) As DataTable
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
            dataAdapter = New SqlClient.SqlDataAdapter(SqlQuery, settings.ConnectionString)

            'get the table from the database
            dataAdapter.Fill(table)
            dataAdapter = Nothing
            Return table
        Catch ex As System.Exception
            table = Nothing
            dataAdapter = Nothing
            'if the connection timed out, increment the timeout and resave the settings. then try to open the table again.
            If LCase(ex.Message).Contains("timeout") Then
                If settings.IncrementTimeout() Then
                    Return OpenTable(tableName, SqlQuery, settings)
                Else
                    ShowError(ex)
                End If
            Else
                ShowError(ex)
            End If
        End Try

        Return Nothing
    End Function

    ''' <summary>
    ''' Commits data to the database and returns updated data
    ''' </summary>
    ''' <param name="table">name of the table</param>
    ''' <param name="SqlQuery">sql Query to retreive the data with</param>
    ''' <param name="settings">the connection settings for the database to connect to</param>
    ''' <returns>the dataTable of data retreived from the database using SqlQuery</returns>
    ''' <remarks></remarks>
    Public Function CommitTable(ByRef table As DataTable, ByVal SqlQuery As String, ByRef settings As clsConnectionSettings) As Integer
        'create a flow table
        Dim dataAdapter As SqlClient.SqlDataAdapter 'the dataAdapter to fill the table
        Dim builder As SqlClient.SqlCommandBuilder
        Dim count As Integer
        Try
            'connect to the Database
            dataAdapter = New SqlClient.SqlDataAdapter(SqlQuery, settings.ConnectionString)
            builder = New SqlClient.SqlCommandBuilder(dataAdapter)

            'get the table from the database
            count = dataAdapter.Update(table)
            table.Rows.Clear()
            dataAdapter.Fill(table)
            dataAdapter = Nothing
            Return count
        Catch ex As System.Exception
            table = Nothing
            dataAdapter = Nothing
            'if the connection timed out, increment the timeout and resave the settings. then try to open the table again.
            If LCase(ex.Message).Contains("timeout") Then
                If settings.IncrementTimeout() Then
                    Return CommitTable(table, SqlQuery, settings)
                Else
                    ShowError(ex)
                End If
            Else
                ShowError(ex)
            End If
        End Try

        Return 0
    End Function

    ''' <summary>
    ''' Tries to establish a connection to a MSSQL database using the given connection settings
    ''' </summary>
    ''' <param name="e_DBSettings">the connetion settings to the database</param>
    ''' <returns>True if the program was able to establish a conneciton to the database</returns>
    ''' <remarks></remarks>
    Public Function TestDBConnection(ByRef e_DBSettings As clsConnectionSettings) As Boolean
        'Used to test a databse connection
        'Inputs:  Settings -> A ConnectionSettings instance used to create a connection to a database
        'Outputs: TestDBConnection -> Returns True if the test was successful, otherwise returns False

        'Create a new connection
        Dim TestConn As New SqlClient.SqlConnection(e_DBSettings.ConnectionString)
        Dim SQL1 As String
        'Dim SQL2 As String
        If e_DBSettings.DBName = "" Or e_DBSettings.ServerAddress = "" Then
            Return False
        Else
            Try

                TestConn.Open()

                'Create an sql command that accesses all tables and a field within the series catalog table
                SQL1 = "SELECT MAX(VersionNumber)as MaxVersion FROM ODMVersion"
                'SQL2 = "SELECT MAX(value) as VersionNumber FROM ::fn_listextendedproperty('ODM_version', NULL, NULL, NULL, NULL, NULL, NULL)"

                'Test the connection
                Dim VersTable As New SqlClient.SqlDataAdapter(SQL1, TestConn)
                'Dim VersExPrp As New sqlclient.sqlDataAdapter(SQL2, TestConn)
                Dim Table As New DataTable
                'Dim ExPrp As New DataTable

                VersTable.Fill(Table)
                'VersExPrp.Fill(ExPrp)

                TestConn.Close()
                TestConn.Dispose()

                If (Table.Rows.Count = 1) Then
                    If (Table.Rows(0).Item("MaxVersion").ToString.StartsWith("1.1")) Then
                        Return True
                    Else
                        ShowError("This program is only compatible with ODM 1.1 Databases.  You have an ODM " & Table.Rows(0).Item("VersionNumber").ToString & " Database")
                        Return False
                    End If
                Else
                    ShowError("There was an error retrieving the Version Number of the ODM Database")
                    Return False
                End If

                TestConn.Close()
                TestConn.Dispose()
            Catch ex As Exception
                'If the connection timed out, increment the timeout setting, return the results of another test, else return false
                If ex.Message.Contains("Invalid object name 'ODMVersion'.") Then
                    ShowError("This program is only compatible with ODM 1.1 Databases.  You have an ODM 1.0 Database")
                ElseIf ex.Message.Contains("Timeout expired") Then
                    If e_DBSettings.IncrementTimeout() Then
                        If TestDBConnection(e_DBSettings) Then
                            Return True
                        Else
                            ShowError("Database Connection Timeout Expired.")
                            Return False
                        End If
                    End If
                ElseIf ex.Message.Contains("SQL Server does not exist") Then
                    ShowError("Server Address Incorrect.")
                    Return False
                ElseIf ex.Message.Contains("Cannot open database") Then
                    ShowError("Database Name Incorrect.")
                    Return False
                ElseIf ex.Message.Contains("Login failed for user") Then
                    ShowError("Username or Password Incorrect.")
                    Return False
                Else
                    ShowError(ex)
                    Return False
                End If
            End Try
        End If
        Return False
    End Function

#Region " Get Data "

    ''' <summary>
    ''' Retrieves metadata from the Database.  Returns metadata in a datatable.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>metadata in a datatable</returns>
    ''' <remarks></remarks>
    Public Function GetMetadata(ByVal e_settings As clsConnectionSettings) As DataTable
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim comboTable As New DataTable(db_tbl_ISOMetaData)
        comboTable.Columns.Add(db_expr_ID)
        comboTable.Columns.Add(db_expr_View)

        Try

            sql = "SELECT " & db_fld_IMDMetaID & ", " & db_fld_IMDTopicCat & ", " & db_fld_IMDAbstract & " FROM " & db_tbl_ISOMetaData & " ORDER BY " & db_fld_IMDTopicCat & ", " & db_fld_IMDAbstract

            table = OpenTable("ISOMetadata", sql, e_settings)

            If Not (table Is Nothing) Then
                For i = 0 To (table.Rows.Count - 1)
                    comboTable.Rows.Add(New String() {table.Rows(i).Item(db_fld_IMDMetaID), table.Rows(i).Item(db_fld_IMDTopicCat) & " - " & table.Rows(i).Item(db_fld_IMDAbstract)})
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return comboTable
    End Function

    ''' <summary>
    ''' Retrieves QCLevels from the Database.  Returns QCLevels in a datatable.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>QCLevels in a datatable</returns>
    ''' <remarks></remarks>
    Public Function GetQualityControlLevels(ByVal e_settings As clsConnectionSettings) As DataTable
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim comboTable As New DataTable(db_tbl_QCLevels)
        comboTable.Columns.Add(db_expr_ID)
        comboTable.Columns.Add(db_expr_View)

        Try

            sql = "SELECT " & db_fld_QCLQCLevelID & ", " & db_fld_QCLDefinition & ", " & db_fld_QCLExplanation & " FROM " & db_tbl_QCLevels & " ORDER BY " & db_fld_QCLDefinition & ", " & db_fld_QCLExplanation

            table = OpenTable("QCLevels", sql, e_settings)

            If Not (table Is Nothing) Then
                For i = 0 To (table.Rows.Count - 1)
                    comboTable.Rows.Add(New String() {table.Rows(i).Item(db_fld_QCLQCLevelID), table.Rows(i).Item(db_fld_QCLDefinition) & " - " & table.Rows(i).Item(db_fld_QCLExplanation)})
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return comboTable
    End Function

    ''' <summary>
    ''' Retrieves Spatial References from the Database.  Returns Spatial References in a datatable.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Spatial References in a datatable</returns>
    ''' <remarks></remarks>
    Public Function GetSpatialReferences(ByVal e_settings As clsConnectionSettings) As DataTable
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim comboTable As New DataTable(db_tbl_SpatialRefs)
        comboTable.Columns.Add(db_expr_ID)
        comboTable.Columns.Add(db_expr_View)

        Try

            sql = "SELECT " & db_fld_SRID & ", " & db_fld_SRSRSID & ", " & db_fld_SRSRSName & " FROM " & db_tbl_SpatialRefs & " ORDER BY " & db_fld_SRSRSID & ", " & db_fld_SRSRSName

            table = OpenTable("SpatialReferences", sql, e_settings)

            If Not (table Is Nothing) Then
                For i = 0 To (table.Rows.Count - 1)
                    comboTable.Rows.Add(New String() {table.Rows(i).Item(db_fld_SRID), table.Rows(i).Item(db_fld_SRSRSID) & " - " & table.Rows(i).Item(db_fld_SRSRSName)})
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return comboTable
    End Function

    ''' <summary>
    ''' Retrieves Units from the Database.  Returns Units in a datatable.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Units in a datatable</returns>
    ''' <remarks></remarks>
    Public Function GetUnits(ByVal e_settings As clsConnectionSettings) As DataTable
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim comboTable As New DataTable(db_tbl_Units)
        comboTable.Columns.Add(db_expr_ID)
        comboTable.Columns.Add(db_expr_View)

        Try

            sql = "SELECT " & db_fld_UnitsID & ", " & db_fld_UnitsName & ", " & db_fld_UnitsAbrv & " FROM " & db_tbl_Units & " ORDER BY " & db_fld_UnitsName & ", " & db_fld_UnitsAbrv

            table = OpenTable("Units", sql, e_settings)

            If Not (table Is Nothing) Then
                For i = 0 To (table.Rows.Count - 1)
                    comboTable.Rows.Add(New String() {table.Rows(i).Item(db_fld_UnitsID), table.Rows(i).Item(db_fld_UnitsName) & " - " & table.Rows(i).Item(db_fld_UnitsAbrv)})
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return comboTable
    End Function

    ''' <summary>
    ''' Retrieves Vertical Datum from the Database.  Returns Vertical Datum in a string Array.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Vertical Datum in a string Array</returns>
    ''' <remarks></remarks>
    Public Function GetVerticalDatum(ByVal e_settings As clsConnectionSettings) As String()
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim VerticalDatum(0) As String

        Try

            sql = "SELECT * FROM " & db_tbl_VerticalDatumCV & " ORDER BY " & db_fld_CV_Term

            table = OpenTable("VerticalDatum", sql, e_settings)

            If Not (table Is Nothing) Then
                ReDim VerticalDatum(table.Rows.Count - 1)
                For i = 0 To (table.Rows.Count - 1)
                    VerticalDatum(i) = table.Rows(i).Item(db_fld_CV_Term)
                Next
            End If
        Catch ex As Exception
            ShowError(ex)
        End Try
        Return VerticalDatum
    End Function

    ''' <summary>
    ''' Retrieves Variable Names from the Database.  Returns Variable Names in a String Array.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Variable Names in a String Array</returns>
    ''' <remarks></remarks>
    Public Function GetVariableNames(ByVal e_settings As clsConnectionSettings) As String()
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim VariableNames(0) As String

        Try

            sql = "SELECT " & db_fld_CV_Term & " FROM " & db_tbl_VariableNameCV & " ORDER BY " & db_fld_CV_Term

            table = OpenTable("VariableNames", sql, e_settings)

            If Not (table Is Nothing) Then
                ReDim VariableNames(table.Rows.Count - 1)
                For i = 0 To (table.Rows.Count - 1)
                    VariableNames(i) = table.Rows(i).Item(db_fld_CV_Term)
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return VariableNames
    End Function

    ''' <summary>
    ''' Retrieves Variable Names from the Database.  Returns Variable Names in a String Array.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Variable Names in a String Array</returns>
    ''' <remarks></remarks>
    Public Function GetSpeciation(ByVal e_settings As clsConnectionSettings) As String()
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim Speciation(0) As String

        Try

            sql = "SELECT " & db_fld_CV_Term & " FROM " & db_tbl_SpeciationCV & " ORDER BY " & db_fld_CV_Term

            table = OpenTable("Speciation", sql, e_settings)

            If Not (table Is Nothing) Then
                ReDim Speciation(table.Rows.Count - 1)
                For i = 0 To (table.Rows.Count - 1)
                    Speciation(i) = table.Rows(i).Item(db_fld_CV_Term)
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return Speciation
    End Function

    ''' <summary>
    ''' Retrieves Sample Mediums  from the Database.  Returns Sample Mediums in a String Array.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Sample Mediums in a String Array</returns>
    ''' <remarks></remarks>
    Public Function GetSampleMediums(ByVal e_settings As clsConnectionSettings) As String()
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim SampleMediums(0) As String

        Try

            sql = "SELECT " & db_fld_CV_Term & " FROM " & db_tbl_SampleMediumCV & " ORDER BY " & db_fld_CV_Term

            table = OpenTable("SampleMediums", sql, e_settings)

            If Not (table Is Nothing) Then
                ReDim SampleMediums(table.Rows.Count - 1)
                For i = 0 To (table.Rows.Count - 1)
                    SampleMediums(i) = table.Rows(i).Item(db_fld_CV_Term)
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return SampleMediums
    End Function

    ''' <summary>
    ''' Retrieves Value Types from the Database.  Returns Value Types in a String Array.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Value Types in a String Array</returns>
    ''' <remarks></remarks>
    Public Function GetValueTypes(ByVal e_settings As clsConnectionSettings) As String()
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim ValueTypes(0) As String

        Try

            sql = "SELECT " & db_fld_CV_Term & " FROM " & db_tbl_ValueTypeCV & " ORDER BY " & db_fld_CV_Term

            table = OpenTable("ValueTypes", sql, e_settings)

            If Not (table Is Nothing) Then
                ReDim ValueTypes(table.Rows.Count - 1)
                For i = 0 To (table.Rows.Count - 1)
                    ValueTypes(i) = table.Rows(i).Item(db_fld_CV_Term)
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return ValueTypes
    End Function

    ''' <summary>
    ''' Retrieves Data Types from the Database.  Returns Data Types in a String Array.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Data Types in a String Array</returns>
    ''' <remarks></remarks>
    Public Function GetDataTypes(ByVal e_settings As clsConnectionSettings) As String()
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim DataTypes(0) As String

        Try

            sql = "SELECT " & db_fld_CV_Term & " FROM " & db_tbl_DataTypeCV & " ORDER BY " & db_fld_CV_Term

            table = OpenTable("DataTypes", sql, e_settings)

            If Not (table Is Nothing) Then
                ReDim DataTypes(table.Rows.Count - 1)
                For i = 0 To (table.Rows.Count - 1)
                    DataTypes(i) = table.Rows(i).Item(db_fld_CV_Term)
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return DataTypes
    End Function

    ''' <summary>
    ''' Retrieves General Categories from the Database.  Returns General Categories in a String Array.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>General Categories in a String Array</returns>
    ''' <remarks></remarks>
    Public Function GetGeneralCategories(ByVal e_settings As clsConnectionSettings) As String()
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim GeneralCategories(0) As String

        Try

            sql = "SELECT " & db_fld_CV_Term & " FROM " & db_tbl_GeneralCategoryCV & " ORDER BY " & db_fld_CV_Term

            table = OpenTable("GeneralCategories", sql, e_settings)

            If Not (table Is Nothing) Then
                ReDim GeneralCategories(table.Rows.Count - 1)
                For i = 0 To (table.Rows.Count - 1)
                    GeneralCategories(i) = table.Rows(i).Item(db_fld_CV_Term)
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return GeneralCategories
    End Function

    ''' <summary>
    ''' Retrieves Topic Categories from the Database.  Returns Topic Categories in a String Array.
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Topic Categories in a String Array</returns>
    ''' <remarks></remarks>
    Public Function GetTopicCategories(ByVal e_settings As clsConnectionSettings) As String()
        '
        Dim sql As String
        Dim table As DataTable
        Dim i As Integer
        Dim TopicCategories(0) As String

        Try

            sql = "SELECT " & db_fld_CV_Term & " FROM " & db_tbl_TopicCategoryCV & " ORDER BY " & db_fld_CV_Term

            table = OpenTable("TopicCategories", sql, e_settings)

            If Not (table Is Nothing) Then
                ReDim TopicCategories(table.Rows.Count - 1)
                For i = 0 To (table.Rows.Count - 1)
                    TopicCategories(i) = table.Rows(i).Item(db_fld_CV_Term)
                Next
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

        Return TopicCategories
    End Function

    ''' <summary>
    ''' Gets the maximumn (fieldName) from the (tableName) table in the database
    ''' </summary>
    ''' <param name="tableName">The table to access</param>
    ''' <param name="fieldName">The field to get the max of</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>The maximum value from the field</returns>
    ''' <remarks></remarks>
    Public Function GetMaxFromTable(ByVal tableName As String, ByVal fieldName As String, ByVal e_settings As clsConnectionSettings) As String
        'Retrieves the maximum value from a specified column in a specified table in the database.
        Try
            Dim table As New System.Data.DataTable(tableName) 'the table of data to return
            Dim dataAdapter As SqlClient.SqlDataAdapter 'the dataAdapter to fill the table
            Dim sql As String = "SELECT MAX(" & fieldName & ") AS " & db_expr_Max & " FROM " & tableName

            'connect to the Database
            dataAdapter = New SqlClient.SqlDataAdapter(sql, e_settings.ConnectionString)

            'get the table from the database
            dataAdapter.Fill(table)
            dataAdapter = Nothing
            If table.Rows.Count > 0 Then
                If table.Rows(0).Item(db_expr_Max) Is DBNull.Value Then
                    Return 0
                Else
                    Return table.Rows(0).Item(db_expr_Max)
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            ShowError(ex)
        End Try
        Return ""
    End Function

#End Region

#End Region

End Module
