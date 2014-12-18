'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..
Imports System.Data.SqlClient
Module modDB
    'Last Documented 8/30/07

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
    Public Const db_fld_SCVarSpec As String = "Speciation"
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
    Public Const db_fld_SCSourceCit As String = "Citation"
    Public Const db_fld_SCQCLevelID As String = "QualityControlLevelID"   'P Integer -> Corresponds to the Quality Control Level of the Series
    Public Const db_fld_SCQCLevelCode As String = "QualityControlLevelCode"
    Public Const db_fld_SCBeginDT As String = "BeginDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCEndDT As String = "EndDateTime" 'P Date -> Date and time of the first value in the series
    Public Const db_fld_SCBeginDTUTC As String = "BeginDateTimeUTC" 'P DateTime -> The First UTC Date
    Public Const db_fld_SCEndDTUTC As String = "EndDateTimeUTC" 'P DateTime -> The Last UTC Date
    Public Const db_fld_SCValueCount As String = "ValueCount" 'P Integer -> The number of vaues in the series (SiteID & VariableID)
    Public Const db_fld_SCSiteType As String = "SiteType"
#End Region

#Region "Sites"
    'Sites
    Public Const db_tbl_Sites As String = "Sites" 'Table Name
    Public Const db_fld_SiteID As String = "SiteID" 'M Integer: Primary Key -> Unique ID for each Sites entry
    Public Const db_fld_SiteCode As String = "SiteCode" 'O String: 50 -> Code used by organization that collects the data
    Public Const db_fld_SiteName As String = "SiteName" 'O String: 255 -> Full name of sampling location
    Public Const db_fld_SiteType As String = "SiteType"
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
    Public Const db_tbl_SiteTypeCV As String = "SiteTypeCV"

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

    ''' <summary>
    ''' The name of a generated column in the 'Update Series Catalog Table' queries
    ''' </summary>
    ''' <remarks></remarks>
    Public Const db_expr_Count As String = "DataCount"
    ''' <summary>
    ''' Used by the form in place of 'null'
    ''' </summary>
    ''' <remarks></remarks>
    Public Const db_expr_None As String = "<None>"
    ''' <summary>
    ''' The default 'NoDataValue'
    ''' </summary>
    ''' <remarks></remarks>
    Public Const db_Default_VarNoDataVal As String = "-9999"

#End Region

#Region " Database Functions "

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
                        ErrorLog("This program is only compatible with ODM 1.1 Databases.  You have an ODM " & Table.Rows(0).Item("VersionNumber").ToString & " Database")
                        Return False
                    End If
                Else
                    ErrorLog("There was an error retrieving the Version Number of the ODM Database")
                    Return False
                End If

                TestConn.Close()
                TestConn.Dispose()
            Catch ex As Exception
                'If the connection timed out, increment the timeout setting, return the results of another test, else return false
                If ex.Message.Contains("Invalid object name 'ODMVersion'.") Then
                    ErrorLog("This program is only compatible with ODM 1.1 Databases.  You have an ODM 1.0 Database")
                ElseIf ex.Message.Contains("Timeout expired") Then
                    If e_DBSettings.IncrementTimeout() Then
                        If TestDBConnection(e_DBSettings) Then
                            Return True
                        Else
                            ErrorLog("Database Connection Timeout Expired. modDB line 376")
                            Return False
                        End If
                    End If
                ElseIf ex.Message.Contains("SQL Server does not exist") Then
                    ErrorLog("Server Address Incorrect.")
                    Return False
                ElseIf ex.Message.Contains("Cannot open database") Then
                    ErrorLog("Database Name Incorrect.")
                    Return False
                ElseIf ex.Message.Contains("Login failed for user") Then
                    ErrorLog("Username or Password Incorrect.")
                    Return False
                Else
                    ErrorLog("Error while testing database connection.", ex)
                    Return False
                End If
            End Try
        End If
        Return False
    End Function

    ''' <summary>
    ''' Creates a new record in the Series Catalog Table with the given information
    ''' </summary>
    ''' <param name="siteID">The SiteID of the given Data Series</param>
    ''' <param name="varID">The VariableID of the given Data Series</param>
    ''' <param name="MethodID">The MethodID of the given Data Series</param>
    ''' <param name="SourceID">The SourceID of the given Data Series</param>
    ''' <param name="qcLevelID">The QualityControlLevelID of the given Data Series</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <remarks></remarks>
    Public Sub CreateNewSeries(ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qcLevelID As Integer, ByVal e_settings As clsConnectionSettings)
        Try
            Dim sql As String
            Dim siteInfo As DataRow = GetSiteInfo(siteID, e_settings)
            Dim variableInfo As DataRow = GetVariableInfo(varID, e_settings)
            Dim methodInfo As DataRow = GetMethodInfo(methodID, e_settings)
            Dim sourceInfo As DataRow = GetSourceInfo(sourceID, e_settings)
            Dim varunitsInfo As DataRow = GetUnitInfo(variableInfo.Item(db_fld_VarUnitsID), e_settings)
            Dim timeunitsInfo As DataRow = GetUnitInfo(variableInfo.Item(db_fld_VarTimeUnitsID), e_settings)
            Dim qclevelInfo As DataRow = GetQCLevelInfo(qcLevelID, e_settings)
            Dim BeginDT As DateTime = GetFirstDate(siteID, varID, methodID, sourceID, qcLevelID, e_settings)
            Dim EndDT As DateTime = GetLastDate(siteID, varID, methodID, sourceID, qcLevelID, e_settings)
            Dim BeginUtcDT As DateTime = GetFirstUTCDate(siteID, varID, methodID, sourceID, qcLevelID, e_settings)
            Dim EndUtcDT As DateTime = GetLastUTCDate(siteID, varID, methodID, sourceID, qcLevelID, e_settings)
            Dim ValueCount As Integer = GetDataCount(siteID, varID, methodID, sourceID, qcLevelID, e_settings)
            sql = ""
            sql = "INSERT INTO " & db_tbl_SeriesCatalog & _
            " (" & db_fld_SCSiteID & ", " & db_fld_SCSiteCode & ", " & _
                    db_fld_SCSiteName & ", " & db_fld_SCVarID & ", " & db_fld_SCVarCode & ", " & _
                    db_fld_SCVarName & ", " & _
                    db_fld_SCVarSpec & ", " & _
                    db_fld_SCVarUnitsID & ", " & db_fld_SCVarUnitsName & ", " & _
                    db_fld_SCSampleMed & ", " & db_fld_SCValueType & ", " & db_fld_SCTimeSupport & ", " & _
                    db_fld_SCTimeUnitsID & ", " & db_fld_SCTimeUnitsName & ", " & db_fld_SCDataType & ", " & _
                    db_fld_SCGenCat & ", " & db_fld_SCMethodID & ", " & db_fld_SCMethodDesc & ", " & _
                    db_fld_SCSourceID & ", " & db_fld_SCOrganization & ", " & db_fld_SCSourceDesc & ", " & _
                    db_fld_SCSourceCit & ", " & _
                    db_fld_SCQCLevelID & ", " & _
                    db_fld_SCQCLevelCode & ", " & _
                    db_fld_SCBeginDT & ", " & db_fld_SCEndDT & ", " & _
                    db_fld_SCBeginDTUTC & ", " & db_fld_SCEndDTUTC & ", " & db_fld_SCValueCount
            If (My.Settings.ODMVersion = "1.1.1") Then
                If Not (siteInfo.Item(db_fld_SiteType) Is DBNull.Value) Then
                    sql &= ", " & db_fld_SCSiteType
                End If
            End If

            sql &= ")" & _
                   " VALUES ( '" & _
                   siteID & "', '" & _
                   FormatForDB(siteInfo.Item(db_fld_SiteCode)) & "', '" & _
                   FormatForDB(siteInfo.Item(db_fld_SiteName)) & "', '" & _
                   varID & "', '" & _
                   FormatForDB(variableInfo.Item(db_fld_VarCode)) & "', '" & _
                   FormatForDB(variableInfo.Item(db_fld_VarName)) & "', '" & _
                   FormatForDB(variableInfo.Item(db_fld_VarSpec)) & "', '" & _
                   variableInfo.Item(db_fld_VarUnitsID) & "', '" & _
                   FormatForDB(varunitsInfo.Item(db_fld_UnitsName)) & "', '" & _
                   FormatForDB(variableInfo.Item(db_fld_VarSampleMed)) & "', '" & _
                   FormatForDB(variableInfo.Item(db_fld_VarValueType)) & "', '" & _
                   variableInfo.Item(db_fld_VarTimeSupport) & "', '" & _
                   variableInfo.Item(db_fld_VarTimeUnitsID) & "', '" & _
                   FormatForDB(timeunitsInfo.Item(db_fld_UnitsName)) & "', '" & _
                   FormatForDB(variableInfo.Item(db_fld_VarDataType)) & "', '" & _
                   FormatForDB(variableInfo.Item(db_fld_VarGenCat)) & "', '" & _
                   methodID & "', '" & _
                   FormatForDB(methodInfo.Item(db_fld_MethDesc)) & "', '" & _
                   sourceID & "', '" & _
                   FormatForDB(sourceInfo.Item(db_fld_SrcOrg)) & "', '" & _
                   FormatForDB(sourceInfo.Item(db_fld_SrcDesc)) & "', '" & _
                   FormatForDB(sourceInfo.Item(db_fld_SrcCitation)) & "', '" & _
                   qcLevelID & "', '" & _
                   FormatForDB(qclevelInfo.Item(db_fld_QCLQCLevelCode)) & "', " & _
                   "@BeginDT, @EndDT, @BeginUtcDT, @EndUtcDT" & ", '" & ValueCount
            If (My.Settings.ODMVersion = "1.1.1") Then
                If Not (siteInfo.Item(db_fld_SiteType) Is DBNull.Value) Then
                    sql &= "', '" & FormatForDB(siteInfo.Item(db_fld_SiteType))
                End If
            End If
            sql &= "')"

            Dim Connection As New SqlClient.SqlConnection(e_settings.ConnectionString)
            Connection.Open()

            'Run the query
            Dim update As New SqlClient.SqlCommand(sql, Connection)
            update.Parameters.Add(New SqlParameter("@BeginDT", SqlDbType.DateTime))
            update.Parameters("@BeginDT").Value = BeginDT
            update.Parameters.Add(New SqlParameter("@EndDT", SqlDbType.DateTime))
            update.Parameters("@EndDT").Value = EndDT
            update.Parameters.Add(New SqlParameter("@BeginUtcDT", SqlDbType.DateTime))
            update.Parameters("@BeginUtcDT").Value = BeginUtcDT
            update.Parameters.Add(New SqlParameter("@EndUtcDT", SqlDbType.DateTime))
            update.Parameters("@EndUtcDT").Value = EndUtcDT
            Dim temp As Object
            temp = update.ExecuteScalar()

            Connection.Close()
            Connection.Dispose()

        Catch ex As Exception
            ErrorLog("An Error Occured Creating a New Series in the Series Catalog Table.", ex)
        End Try
    End Sub

#Region " Get Data From DB "

    ''' <summary>
    ''' Retrieves an entire data table using the given query
    ''' </summary>
    ''' <param name="tableName">The name of the created DataTable to return</param>
    ''' <param name="SqlQuery">The SQL Query used to generate the DataTable</param>
    ''' <param name="e_settings">the connection settings to the database</param>
    ''' <returns>The DataTable created by the given query</returns>
    ''' <remarks></remarks>
    Public Function OpenTable(ByVal tableName As String, ByVal SqlQuery As String, ByRef e_settings As clsConnectionSettings) As DataTable
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
            dataAdapter = New SqlClient.SqlDataAdapter(SqlQuery, e_settings.ConnectionString)

            'get the table from the database
            dataAdapter.Fill(table)
            dataAdapter = Nothing
            Return table
        Catch ex As System.Exception
            table = Nothing
            dataAdapter = Nothing
            'if the connection timed out, increment the timeout and resave the settings. then try to open the table again.
            If LCase(ex.Message).Contains("timeout") Then
                If e_settings.IncrementTimeout() Then
                    table = OpenTable(tableName, SqlQuery, e_settings)
                Else
                    ErrorLog("Database Connection Timeout Expired. modDB line 538")
                End If
            Else
                ErrorLog("An Error Occured Retrieving Information from the Database.", ex)
            End If
        End Try

        Return Nothing
    End Function
    Public Function OpenTableDate(ByVal tableName As String, ByVal SqlQuery As String, ByRef e_settings As clsConnectionSettings) As DataTable
        'Returns a dataTable of the query data.
        'Inputs:  tablename -> name of the table
        '         SqlQuery -> sql Query to retreive the data with
        '         connString -> the connection String for the database to connect to, to retreive the data from
        'Outputs: the dataTable of data retreived from the database using SqlQuery
        'create a flow table

        Dim table As New System.Data.DataTable(tableName) 'the table of data to return

        Try
            Dim idColumn As DataColumn = New DataColumn()
            idColumn.DataType = System.Type.GetType("System.DateTime")
            idColumn.ColumnName = "Date"
            table.Columns.Add(idColumn)

            Dim Rows As DataRow
            Rows = table.NewRow()

            Using connection As New SqlConnection(e_settings.ConnectionString)
                'connection.ConnectionTimeout = 200
                Using command As New SqlCommand(SqlQuery, connection)
                    command.CommandTimeout = 200
                    connection.Open() 'connect to the Database
                    Using reader As SqlDataReader = command.ExecuteReader() 'the dataReader to fill the table
                        While reader.Read()
                            Rows("Date") = reader(0)
                            table.Rows.Add(Rows)
                        End While
                    End Using
                    connection.Close()
                End Using
            End Using
            Return table
        Catch ex As System.Exception
            table = Nothing
            'if the connection timed out, increment the timeout and resave the settings. then try to open the table again.
            If LCase(ex.Message).Contains("timeout") Then
                If e_settings.IncrementTimeout() Then
                    table = OpenTable(tableName, SqlQuery, e_settings)
                Else
                    ErrorLog("Database Connection Timeout Expired.modDB line 586")
                End If
            Else
                ErrorLog("An Error Occured Retrieving Information from the Database.", ex)
            End If
        End Try

        Return Nothing
    End Function
    ''' <summary>
    ''' Retrieves the Minimum/First Local DateTime value for the series specified by the parameters
    ''' </summary>
    ''' <param name="siteID">The SiteID of the given Data Series</param>
    ''' <param name="variableID">The VariableID of the given Data Series</param>
    ''' <param name="MethodID">The MethodID of the given Data Series</param>
    ''' <param name="SourceID">The SourceID of the given Data Series</param>
    ''' <param name="QualityControlLevelID">The QualityControlLevelID of the given Data Series</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>the Minimum/First Local DateTime value for the series</returns>
    ''' <remarks></remarks>
    Public Function GetFirstDate(ByVal siteID As Integer, ByVal variableID As Integer, ByVal MethodID As Integer, ByVal SourceID As Integer, ByVal QualityControlLevelID As Integer, ByVal e_settings As clsConnectionSettings) As DateTime
        Try
            Dim first As DateTime
            Dim table As DataTable
            Dim sql As String
            'sql = "SELECT MIN(LocalDateTime) AS MinDT" & _
            '" FROM DataValues" & _
            '" GROUP BY SiteID, VariableID, MethodID, SourceID, QualityControlLevelID" & _
            '" HAVING (SiteID = " & siteID & ") AND (VariableID = " & variableID & ") AND (MethodID = " & MethodID & ") AND (SourceID = " & SourceID & ") AND (QualityControlLevelID = " & QualityControlLevelID & ")"

            sql = "SELECT TOP 1 LocalDateTime AS MinDT" & _
            " FROM DataValues" & _
            " WHERE SiteID = " & siteID & " AND VariableID = " & variableID & " AND MethodID = " & MethodID & " AND SourceID = " & SourceID & " AND QualityControlLevelID = " & QualityControlLevelID & _
            " ORDER BY LocalDateTime"
            table = OpenTableDate("FirstDate", sql, e_settings)
            If (Not (table Is Nothing)) AndAlso (table.Rows.Count > 0) Then
                If (table.Rows(0).Item("Date") Is DBNull.Value) Then
                    first = Date.MinValue
                Else
                    first = table.Rows(0).Item("Date")
                    'Date.TryParse(table.Rows(0).Item("MinDT"), first)
                End If
            Else
                first = Date.MinValue
            End If

            Return first
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving the Minimum Date/Time Value from the Database.", ex)
            Return Date.MinValue
        End Try
    End Function

    ''' <summary>
    ''' Retrieves the Minimum/First UTC DateTime value for the series specified by the parameters
    ''' </summary>
    ''' <param name="siteID">The SiteID of the given Data Series</param>
    ''' <param name="variableID">The VariableID of the given Data Series</param>
    ''' <param name="MethodID">The MethodID of the given Data Series</param>
    ''' <param name="SourceID">The SourceID of the given Data Series</param>
    ''' <param name="QualityControlLevelID">The QualityControlLevelID of the given Data Series</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>the Minimum/First UTC DateTime value for the series</returns>
    ''' <remarks></remarks>
    Public Function GetFirstUTCDate(ByVal siteID As Integer, ByVal variableID As Integer, ByVal MethodID As Integer, ByVal SourceID As Integer, ByVal QualityControlLevelID As Integer, ByVal e_settings As clsConnectionSettings) As DateTime
        Try
            Dim first As DateTime
            Dim table As DataTable
            Dim sql As String
            'sql = "SELECT MIN(DateTimeUTC) AS MinDT" & _
            '" FROM DataValues" & _
            '" WHERE (SiteID = " & siteID & ") AND (VariableID = " & variableID & ") AND (MethodID = " & MethodID & ") AND (SourceID = " & SourceID & ") AND (QualityControlLevelID = " & QualityControlLevelID & ")"
            '" GROUP BY SiteID, VariableID, MethodID, SourceID, QualityControlLevelID" & _

            sql = "SELECT TOP 1 DateTimeUTC AS MinDT" & _
            " FROM DataValues" & _
            " WHERE SiteID = " & siteID & " AND VariableID = " & variableID & " AND MethodID = " & MethodID & " AND SourceID = " & SourceID & " AND QualityControlLevelID = " & QualityControlLevelID & _
            " ORDER BY DateTimeUTC"


            table = OpenTableDate("FirstUTCDate", sql, e_settings)
            If (Not (table Is Nothing)) AndAlso (table.Rows.Count > 0) Then
                If (table.Rows(0).Item("Date") Is DBNull.Value) Then
                    first = Date.MinValue
                Else
                    first = table.Rows(0).Item("Date")
                    'Date.TryParse(table.Rows(0).Item("MinDT"), first)
                End If
            Else
                first = Date.MinValue
            End If

            Return first
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving the Minimum UTC Date/Time Value from the Database.", ex)
            Return Date.MinValue
        End Try
    End Function

    ''' <summary>
    ''' Retrieves the Maximum/Last Local DateTime value for the series specified by the parameters
    ''' </summary>
    ''' <param name="siteID">The SiteID of the given Data Series</param>
    ''' <param name="variableID">The VariableID of the given Data Series</param>
    ''' <param name="MethodID">The MethodID of the given Data Series</param>
    ''' <param name="SourceID">The SourceID of the given Data Series</param>
    ''' <param name="QualityControlLevelID">The QualityControlLevelID of the given Data Series</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>the Maximum/Last Local DateTime value for the series</returns>
    ''' <remarks></remarks>
    Public Function GetLastDate(ByVal siteID As Integer, ByVal variableID As Integer, ByVal MethodID As Integer, ByVal SourceID As Integer, ByVal QualityControlLevelID As Integer, ByVal e_settings As clsConnectionSettings) As DateTime
        Try
            Dim last As DateTime
            Dim table As DataTable
            Dim sql As String
            'sql = "SELECT MAX(LocalDateTime) AS MaxDT" & _
            '" FROM DataValues" & _
            '" GROUP BY SiteID, VariableID, MethodID, SourceID, QualityControlLevelID" & _
            '" HAVING (SiteID = " & siteID & ") AND (VariableID = " & variableID & ") AND (MethodID = " & MethodID & ") AND (SourceID = " & SourceID & ") AND (QualityControlLevelID = " & QualityControlLevelID & ")"
            sql = "SELECT TOP 1 LocalDateTime AS MaxDT" & _
            " FROM DataValues" & _
            " WHERE SiteID = " & siteID & " AND VariableID = " & variableID & " AND MethodID = " & MethodID & " AND SourceID = " & SourceID & " AND QualityControlLevelID = " & QualityControlLevelID & _
            " ORDER BY LocalDateTime DESC"


            table = OpenTableDate("LastDate", sql, e_settings)
            If (Not (table Is Nothing)) AndAlso (table.Rows.Count > 0) Then
                If (table.Rows(0).Item("Date") Is DBNull.Value) Then
                    last = Date.MinValue
                Else
                    last = table.Rows(0).Item("Date")
                    'Date.TryParse(table.Rows(0).Item("MaxDT"), last)
                End If
            Else
                last = Date.MinValue
            End If

            Return last
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving the Maximum Date/Time Value from the Database.", ex)
            Return Date.MinValue
        End Try
    End Function

    ''' <summary>
    ''' Retrieves the Maximum/Last UTC DateTime value for the series specified by the parameters
    ''' </summary>
    ''' <param name="siteID">The SiteID of the given Data Series</param>
    ''' <param name="variableID">The VariableID of the given Data Series</param>
    ''' <param name="MethodID">The MethodID of the given Data Series</param>
    ''' <param name="SourceID">The SourceID of the given Data Series</param>
    ''' <param name="QualityControlLevelID">The QualityControlLevelID of the given Data Series</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>the Maximum/Last UTC DateTime value for the series</returns>
    ''' <remarks></remarks>
    Public Function GetLastUTCDate(ByVal siteID As Integer, ByVal variableID As Integer, ByVal MethodID As Integer, ByVal SourceID As Integer, ByVal QualityControlLevelID As Integer, ByVal e_settings As clsConnectionSettings) As DateTime
        Try
            Dim last As DateTime
            Dim table As DataTable
            Dim sql As String
            'sql = "SELECT MAX(DateTimeUTC) AS MaxDT" & _
            '" FROM DataValues" & _
            '" GROUP BY SiteID, VariableID, MethodID, SourceID, QualityControlLevelID" & _
            '" HAVING (SiteID = " & siteID & ") AND (VariableID = " & variableID & ") AND (MethodID = " & MethodID & ") AND (SourceID = " & SourceID & ") AND (QualityControlLevelID = " & QualityControlLevelID & ")"

            sql = "SELECT TOP 1 DateTimeUTC AS MaxDT" & _
            " FROM DataValues" & _
            " WHERE SiteID = " & siteID & " AND VariableID = " & variableID & " AND MethodID = " & MethodID & " AND SourceID = " & SourceID & " AND QualityControlLevelID = " & QualityControlLevelID & _
            " ORDER BY DateTimeUTC DESC"
            'SELECT Top 1 LocalDateTime From DataValues ORDER BY LocalDateTime DESC

            table = OpenTableDate("LastUTCDate", sql, e_settings)
            If (Not (table Is Nothing)) AndAlso (table.Rows.Count > 0) Then
                If (table.Rows(0).Item("Date") Is DBNull.Value) Then
                    last = Date.MinValue
                Else
                    last = table.Rows(0).Item("Date")
                    'Date.TryParse(table.Rows(0).Item("MaxDT"), last)
                End If
            Else
                last = Date.MinValue
            End If

            Return last
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving the Maximum UTC Date/Time Value from the Database.", ex)
            Return Date.MinValue
        End Try
    End Function

    ''' <summary>
    ''' Retrieves the number of records for the given Data Series, used to update the series catalog table
    ''' </summary>
    ''' <param name="siteID">The SiteID of the given Data Series</param>
    ''' <param name="variableID">The VariableID of the given Data Series</param>
    ''' <param name="MethodID">The MethodID of the given Data Series</param>
    ''' <param name="SourceID">The SourceID of the given Data Series</param>
    ''' <param name="QualityControlLevelID">The QualityControlLevelID of the given Data Series</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>Total number of records for the given dataseries</returns>
    ''' <remarks></remarks>
    Public Function GetDataCount(ByVal siteID As Integer, ByVal variableID As Integer, ByVal MethodID As Integer, ByVal SourceID As Integer, ByVal QualityControlLevelID As Integer, ByVal e_settings As clsConnectionSettings) As Integer
        Try
            Dim intValues
            Dim table As DataTable
            Dim sql As String
            sql = "SELECT COUNT(" & db_fld_ValID & ") AS " & db_expr_Count & _
            " FROM " & db_tbl_DataValues & _
            " WHERE (" & db_fld_ValSiteID & " = " & siteID & ") AND (" & db_fld_ValVarID & " = " & variableID & ") AND (" & db_fld_ValMethodID & " = " & MethodID & ") AND (" & db_fld_ValSourceID & " = " & SourceID & ") AND (" & db_fld_ValQCLevel & " = " & QualityControlLevelID & ")"
            '" GROUP BY " & db_fld_ValSiteID & ", " & db_fld_ValVarID & ", " & db_fld_ValMethodID & ", " & db_fld_ValSourceID & ", " & db_fld_ValQCLevel & _

            table = OpenTable("DataCount", sql, e_settings)
            If Not ((table Is Nothing)) AndAlso (table.Rows.Count > 0) Then
                If (table.Rows(0).Item(db_expr_Count) Is DBNull.Value) Then
                    intValues = 0
                Else
                    intValues = table.Rows(0).Item(db_expr_Count)
                End If
            Else
                intValues = 0
            End If

            Return intValues
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving the Data Value Count from the Database.", ex)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Retrieves the maximum ValueID from the DataValues table
    ''' </summary>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>The maximum ValueID from the DataValues table</returns>
    ''' <remarks></remarks>
    Public Function GetLastValueID(ByVal e_settings As clsConnectionSettings) As Integer
        Try
            Dim intValID
            Dim table As DataTable
            Dim sql As String
            sql = "SELECT TOP 1 " & db_fld_ValID & " AS " & db_expr_Count & _
            " FROM " & db_tbl_DataValues & " ORDER BY " & db_fld_ValID & " DESC"



            table = OpenTable("LastValueID", sql, e_settings)
            If Not ((table Is Nothing)) AndAlso (table.Rows.Count > 0) Then
                If (table.Rows(0).Item(db_expr_Count) Is DBNull.Value) Then
                    intValID = 0
                Else
                    intValID = table.Rows(0).Item(db_expr_Count)
                End If
            Else
                intValID = 0
            End If

            Return intValID
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving the Data Value Count from the Database.", ex)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Retrieves an entire row from the Sites table for the specified ID
    ''' </summary>
    ''' <param name="siteID">The SiteID of the DataRow to retrieve</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>An entire row from the Sites table</returns>
    ''' <remarks></remarks>
    Public Function GetSiteInfo(ByVal siteID As Integer, ByVal e_settings As clsConnectionSettings) As DataRow
        Dim table As New DataTable
        Try
            Dim sql As String = "SELECT " & _
            db_fld_SiteCode & ", " & db_fld_SiteName

            If (My.Settings.ODMVersion = "1.1.1") Then
                sql &= ", " & db_fld_SiteType
            End If

            sql &= " FROM " & db_tbl_Sites & _
            " WHERE " & db_tbl_Sites & "." & db_fld_SiteID & " = '" & siteID & "'"

            table = OpenTable("SiteInfo", sql, e_settings)
            If (Not (table Is Nothing)) And (table.Rows.Count > 0) Then
                Return table.Rows(0)
            Else
                Return table.NewRow
            End If
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving Site Information from the Database.", ex)
        End Try
        Return table.NewRow
    End Function

    ''' <summary>
    ''' Retrieves an entire row from the Variables table for the specified ID
    ''' </summary>
    ''' <param name="variableID">The VariableID of the DataRow to retrieve</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>An entire row from the Variables table</returns>
    ''' <remarks></remarks>
    Public Function GetVariableInfo(ByVal variableID As Integer, ByVal e_settings As clsConnectionSettings) As DataRow
        Dim table As New DataTable
        Try
            Dim sql As String = "SELECT " & _
            db_fld_VarCode & ", " & db_fld_VarName & ", " & db_fld_VarSpec & ", " & db_fld_VarUnitsID & ", " & _
            db_fld_VarSampleMed & ", " & db_fld_VarValueType & ", " & db_fld_VarTimeSupport & ", " & _
            db_fld_VarTimeUnitsID & ", " & db_fld_VarDataType & ", " & db_fld_VarDataType & ", " & _
            db_fld_VarGenCat & _
            " FROM " & db_tbl_Variables & _
            " WHERE " & db_tbl_Variables & "." & db_fld_VarID & " = '" & variableID & "'"

            table = OpenTable("VariableInfo", sql, e_settings)
            If (Not (table Is Nothing)) And (table.Rows.Count > 0) Then
                Return table.Rows(0)
            Else
                Return table.NewRow
            End If
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving Variable Information from the Database.", ex)
        End Try
        Return table.NewRow
    End Function

    ''' <summary>
    ''' Retrieves an entire row from the Units table for the specified ID
    ''' </summary>
    ''' <param name="unitID">The UnitID of the DataRow to retrieve</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>An entire row from the Units table</returns>
    ''' <remarks></remarks>
    Public Function GetUnitInfo(ByVal unitID As Integer, ByVal e_settings As clsConnectionSettings) As DataRow
        Dim table As New DataTable
        Try
            Dim sql As String = "SELECT " & _
            db_fld_UnitsName & _
            " FROM " & db_tbl_Units & _
            " WHERE " & db_tbl_Units & "." & db_fld_UnitsID & " = '" & unitID & "'"

            table = OpenTable("UnitInfo", sql, e_settings)
            If (Not (table Is Nothing)) And (table.Rows.Count > 0) Then
                Return table.Rows(0)
            Else
                Return table.NewRow
            End If
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving Unit Information from the Database.", ex)
        End Try
        Return table.NewRow
    End Function

    ''' <summary>
    ''' Retrieves an entire row from the Methods table for the specified ID
    ''' </summary>
    ''' <param name="methodID">The MethodID of the DataRow to retrieve</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>An entire row from the Methods table</returns>
    ''' <remarks></remarks>
    Public Function GetMethodInfo(ByVal methodID As Integer, ByVal e_settings As clsConnectionSettings) As DataRow
        Dim table As New DataTable
        Try
            Dim sql As String = "SELECT " & _
            db_fld_MethDesc & _
            " FROM " & db_tbl_Methods & _
            " WHERE " & db_tbl_Methods & "." & db_fld_MethID & " = '" & methodID & "'"

            table = OpenTable("MethodInfo", sql, e_settings)
            If (Not (table Is Nothing)) And (table.Rows.Count > 0) Then
                Return table.Rows(0)
            Else
                Return table.NewRow
            End If
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving Method Information from the Database.", ex)
        End Try
        Return table.NewRow
    End Function

    ''' <summary>
    ''' Retrieves an entire row from the Sources table for the specified ID
    ''' </summary>
    ''' <param name="sourceID">The SourceID of the DataRow to retrieve</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>An entire row from the Sources table</returns>
    ''' <remarks></remarks>
    Public Function GetSourceInfo(ByVal sourceID As Integer, ByVal e_settings As clsConnectionSettings) As DataRow
        Dim table As New DataTable
        Try
            Dim sql As String = "SELECT " & _
            db_fld_SrcOrg & ", " & db_fld_SrcDesc & ", " & db_fld_SrcCitation & _
            " FROM " & db_tbl_Sources & _
            " WHERE " & db_tbl_Sources & "." & db_fld_SrcID & " = '" & sourceID & "'"

            table = OpenTable("SourceInfo", sql, e_settings)
            If (Not (table Is Nothing)) And (table.Rows.Count > 0) Then
                Return table.Rows(0)
            Else
                Return table.NewRow
            End If
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving Source Information from the Database.", ex)
        End Try
        Return table.NewRow
    End Function

    ''' <summary>
    ''' Retrieves an entire row from the QualityControlLevels table for the specified ID
    ''' </summary>
    ''' <param name="qclevelID">The QualityControlLevelID of the DataRow to retrieve</param>
    ''' <param name="e_settings">the connetion settings to the database</param>
    ''' <returns>An entire row from the QualityControlLevels table</returns>
    ''' <remarks></remarks>
    Public Function GetQCLevelInfo(ByVal qclevelID As Integer, ByVal e_settings As clsConnectionSettings) As DataRow
        Dim table As New DataTable
        Try
            Dim sql As String = "SELECT " & _
            db_fld_QCLQCLevelCode & _
            " FROM " & db_tbl_QCLevels & _
            " WHERE " & db_tbl_QCLevels & "." & db_fld_QCLQCLevelID & " = '" & qclevelID & "'"

            table = OpenTable("QCLevelInfo", sql, e_settings)
            If (Not (table Is Nothing)) And (table.Rows.Count > 0) Then
                Return table.Rows(0)
            Else
                Return table.NewRow
            End If
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving Quality Control Level Information from the Database.", ex)
        End Try
        Return table.NewRow
    End Function

    ''' <summary>
    ''' Retrieves the 'NoDataValue' record for the given Variable
    ''' </summary>
    ''' <param name="variableID">Determines the Variable to read</param>
    ''' <param name="e_settings">the connection settings to the database</param>
    ''' <returns>The 'NoDataValue' value for the given Variable</returns>
    ''' <remarks></remarks>
    Public Function GetNoDataValue(ByVal variableID As Integer, ByVal e_settings As clsConnectionSettings) As String
        Dim table As New DataTable
        Try
            Dim sql As String = "SELECT " & _
            db_fld_VarNoDataVal & _
            " FROM " & db_tbl_Variables & _
            " WHERE " & db_tbl_Variables & "." & db_fld_VarID & " = '" & variableID & "'"

            table = OpenTable("VariableInfo", sql, e_settings)
            If (Not (table Is Nothing)) And (table.Rows.Count > 0) Then
                Return table.Rows(0).Item(db_fld_VarNoDataVal)
            Else
                Return db_Default_VarNoDataVal
            End If
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving Variable Information from the Database.", ex)
        End Try
        Return db_Default_VarNoDataVal
    End Function

    ''' <summary>
    ''' Returns the Series ID for the Data Series specified by the parameters if it exists
    ''' Returns -1 otherwise
    ''' </summary>
    ''' <param name="siteID">The SiteID of the Data Series in the Series Catalog</param>
    ''' <param name="varID">The VariableID of the Data Series in the Series Catalog</param>
    ''' <param name="methodID">The MethodID of the Data Series in the Series Catalog</param>
    ''' <param name="sourceID">The SourceID of the Data Series in the Series Catalog</param>
    ''' <param name="qcLevelID">The QualityControlLevelID of the Data Series in the Series Catalog</param>
    ''' <param name="e_settings">The connection settings to establish a connection to the database</param>
    ''' <returns> Returns the Series ID for the Data Series specified by the parameters if it exists
    ''' Returns -1 otherwise
    ''' </returns>
    ''' <remarks></remarks>
    Public Function IsSeries(ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qcLevelID As Integer, ByVal e_settings As clsConnectionSettings) As Integer
        Try
            Dim sql As String
            Dim table As DataTable
            sql = "SELECT " & db_fld_SCSeriesID & " FROM " & db_tbl_SeriesCatalog & " WHERE " & db_fld_SCSiteID & " = '" & siteID & "' AND " & db_fld_SCVarID & " = '" & varID & "' AND " & db_fld_SCMethodID & " = '" & methodID & "' AND " & db_fld_SCSourceID & " = '" & sourceID & "' AND " & db_fld_SCQCLevelID & " = '" & qcLevelID & "'"

            table = OpenTable("IsSeries", sql, e_settings)

            If ((table Is Nothing) OrElse (table.Rows.Count < 1)) Then
                Return -1
            Else
                Return table.Rows(0).Item(db_fld_SCSeriesID)
            End If
        Catch ex As Exception
            ErrorLog("An Error Occured Retrieving Series Information from the Database.", ex)
            Return False
        End Try
    End Function

#End Region

#Region " Update Data In DB "

    ''' <summary>
    ''' this function updates the database after new rows have been added to or existing rows have been edited in the dataTable
    ''' the datatable is the dataTable that was used to add/edit the rows, query is the query used to create the original datatable
    ''' </summary>
    ''' <param name="dataTable">the dataTable used to add/edit the rows</param>
    ''' <param name="query">the query used to create the original dataTable</param>
    ''' <param name="e_settings">the connectionString to the database</param>
    ''' <returns>Returns True if no errors occurred</returns>
    ''' <remarks></remarks>
    Public Function UpdateTable(ByVal dataTable As System.Data.DataTable, ByVal query As String, ByVal e_settings As clsConnectionSettings) As Boolean
        Dim updateAdapter As System.Data.SqlClient.SqlDataAdapter 'updateAdapter -> finds out if anything has been changed and marks the rows that need to be added -> used by the command builder
        Dim commandBuilder As System.Data.SqlClient.SqlCommandBuilder 'CommandBuilder -> creates the insert function for updating the database
        Try
            'crate the updateAdapter,commandBuilder
            
            updateAdapter = New System.Data.SqlClient.SqlDataAdapter(query, e_settings.ConnectionString)
            commandBuilder = New System.Data.SqlClient.SqlCommandBuilder(updateAdapter)

            'update the database
            Dim count As Integer
            count = updateAdapter.Update(dataTable)

            'If count <= 0 Then
            '	'TODO:
            '	MsgBox("No rows were Updated to the Database")
            'End If

            'everything worked fine, return true
            Return True
        Catch ex As Exception
            updateAdapter = Nothing
            commandBuilder = Nothing
            'if the connection timed out, increment the timeout and resave the settings. then try to open the table again.
            If LCase(ex.Message).Contains("timeout") Then
                If e_settings.IncrementTimeout() Then
                    Return UpdateTable(dataTable, query, e_settings)
                Else
                    ErrorLog("Database Connection Timeout Expired. modDb line 1120")
                End If
            ElseIf (LCase(ex.Message).Contains("unique key")) Then

                If PrecisionError(dataTable, e_settings) Then
                    ErrorLog("Date Values are too precise for Database. Please limit precision to 1/100 of a second. " & vbCrLf & ex.Message.ToString(), ex)
                Else
                    ErrorLog("An Error Occured Updating the Database. " & ex.Message.ToString(), ex)
                End If
            Else
                ErrorLog("An Error Occured Updating the Database. " & ex.Message.ToString(), ex)
            End If
        End Try
        'errors occurred, return false
        Return False
    End Function

    Public Function UpdateDVs(ByVal dataTable As System.Data.DataTable, ByVal e_settings As clsConnectionSettings) As Boolean
        Dim bc As New SqlBulkCopy(e_settings.ConnectionString)
        bc.BatchSize = 1000
        bc.DestinationTableName = "DataValues"
        Try
            bc.WriteToServer(dataTable)
            Return True
        Catch ex As Exception
            ErrorLog("An Error Occured While adding DataValues.", ex)
            Return False
        End Try
    End Function

    Public Function PrecisionError(ByVal table As DataTable, ByVal cmd As clsConnectionSettings) As Boolean
        'test to see if date value is in db
        Try
            Dim temprows() As DataRow = table.Select()
            Using connection As New SqlConnection(cmd.ConnectionString)
                For Each row As DataRow In temprows

                    Dim currdate As DateTime = row(db_fld_ValDateTime)
                    Dim sql As String = "SELECT COUNT(LocalDateTime) FROM DataValues WHERE LocalDateTime='" & currdate.ToString("yyyy-MM-dd HH:mm:ss.fff") & "'"

                    connection.Open() 'connect to the Database
                    Using command As New SqlCommand(sql, connection)
                        Dim count As Integer = command.ExecuteNonQuery()
                        If count <= 0 Then
                            Return True
                        End If
                    End Using
                Next
                connection.Close()
            End Using
            Return False
        Catch ex As Exception
             Return False
        End Try
    End Function

    ''' <summary>
    ''' Updates the series catalog for the series described by the parameters.
    ''' </summary>
    ''' <param name="siteID">The SiteID of the Data Series in the Series Catalog to update</param>
    ''' <param name="varID">The VariableID of the Data Series in the Series Catalog to update</param>
    ''' <param name="methodID">The MethodID of the Data Series in the Series Catalog to update</param>
    ''' <param name="sourceID">The SourceID of the Data Series in the Series Catalog to update</param>
    ''' <param name="qcLevelID">The QualityControlLevelID of the Data Series in the Series Catalog to update</param>
    ''' <param name="e_settings">The Connection Settings to the database</param>
    ''' <remarks></remarks>
    Public Sub UpdateSeriesCatalog(ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qcLevelID As Integer, ByVal e_settings As clsConnectionSettings)
        Try
            Dim sql As String
            Dim first, last As DateTime
            Dim firstUTC, lastUTC As DateTime
            Dim dataCount As Integer
            first = GetFirstDate(siteID, varID, methodID, sourceID, qcLevelID, e_settings)
            last = GetLastDate(siteID, varID, methodID, sourceID, qcLevelID, e_settings)
            firstUTC = GetFirstUTCDate(siteID, varID, methodID, sourceID, qcLevelID, e_settings)
            lastUTC = GetLastUTCDate(siteID, varID, methodID, sourceID, qcLevelID, e_settings)
            dataCount = GetDataCount(siteID, varID, methodID, sourceID, qcLevelID, e_settings)

            sql = "UPDATE " & db_tbl_SeriesCatalog & _
            " SET " & db_fld_SCBeginDT & " = " & "@first" & ", " & db_fld_SCEndDT & " = " & "@last" & ", " & db_fld_SCBeginDTUTC & " = " & "@firstUTC" & ", " & db_fld_SCEndDTUTC & " = " & "@lastUTC" & ", " & db_fld_SCValueCount & " = '" & dataCount & "'" & _
            " WHERE (" & db_fld_SCSiteID & " = " & siteID & ") AND (" & db_fld_SCVarID & " = " & varID & ") AND (" & db_fld_SCMethodID & " = " & methodID & ") AND (" & db_fld_SCSourceID & " = " & sourceID & ") AND (" & db_fld_SCQCLevelID & " = " & qcLevelID & ")"

            Dim Connection As New SqlClient.SqlConnection(e_settings.ConnectionString)
            Connection.Open()

            'Set the query parameters
            Dim update As New SqlClient.SqlCommand(sql, Connection)
            update.Parameters.Add(New SqlParameter("@first", SqlDbType.DateTime))
            update.Parameters("@first").Value = first
            update.Parameters.Add(New SqlParameter("@last", SqlDbType.DateTime))
            update.Parameters("@last").Value = last
            update.Parameters.Add(New SqlParameter("@firstUTC", SqlDbType.DateTime))
            update.Parameters("@firstUTC").Value = firstUTC
            update.Parameters.Add(New SqlParameter("@lastUTC", SqlDbType.DateTime))
            update.Parameters("@lastUTC").Value = lastUTC
            'Dim temp As Object
            'temp = update.executescalar
            update.ExecuteScalar()

            Connection.Close()
            Connection.Dispose()

        Catch ex As Exception
            ErrorLog("An Error Occured While Updating the Series Catalog.", ex)
        End Try
    End Sub

#End Region

#End Region

End Module
