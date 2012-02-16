Imports System.Data.SqlClient

'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Module modDatabase
    'Last Documented 5/15/07

#Region " Global Variables "

    Public Const db_BadID As Integer = -1 'Constant for if a bad ID value is returned from the Database -> so know if have a valid ID or not
    'Public db_qclLoaded As Boolean = False 'tracks if the QCLevel info has been loaded from the database or not

#End Region

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
    Public Const db_fld_QCLQCLevel As String = "QualityControlLevelID" 'M Integer: Primary Key -> Pre-defined ID from 0 to 5
    Public Const db_fld_QCLCode As String = "QualityControlLevelCode"
    Public Const db_fld_QCLDefinition As String = "Definition" 'M String: 255 -> Definition of Quality Control Level
    Public Const db_fld_QCLExplanation As String = "Explanation" 'M String: 500 -> Explanation of Quality Control Level

#Region " DB Loaded Constants "
    'Public db_val_QCLDef_Level(,) As String 'Pre-loaded Quality control level definitions for each ID
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
    Public Const db_fld_SCSpeciation As String = "Speciation"
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
    Public Const db_fld_SCQCLevel As String = "QualityControlLevelID"   'P Integer -> Corresponds to the Quality Control Level of the Series
    Public Const db_fld_SCQCLCode As String = "QualityControlLevelCode"
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
    Public Const db_fld_VarSpeciation As String = "Speciation"
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

#Region " ODM Version "
    'Version
    Public Const db_tbl_ODMVersion As String = "ODMVersion"
    Public Const db_fld_ODMVersionNumber As String = "VersionNumber"
    Public Const db_const_Version As String = "1.1"
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
    Public Const db_tbl_SpeciationCV As String = "SpeciationCV"

    'fields
    Public Const db_fld_CV_Term As String = "Term"
    Public Const db_fld_CV_Definition As String = "Definition"

    'values
    Public Const db_val_VTCVTerm_DerivedValue As String = "Derived Value" 'the term for a 'Derived Value' from the ValueTypeCV table
    Public Const db_val_DTCVTerm_Maximum As String = "Maximum" 'the term for the Maximum type from the DataTypeCV table
    Public Const db_val_DTCVTerm_Minimum As String = "Minimum" 'the term for the Minimum type from the DataTypeCV table
    Public Const db_val_DTCVTerm_Average As String = "Average" 'the term for the Average type from the DataTypeCV table
    Public Const db_val_CCCVTerm_NULL As String = "nc" 'the term for a NULL Censor Code value from the CensorCodeCV table

#End Region

#Region " Export Query Expressions "
    'Geographic Location
    Public Const db_expr_Geo As String = "GeographicCoordinates"
    Public Const db_expr_Geo_SRSID As String = "GeoSRSID"
    Public Const db_expr_Geo_SRSName As String = "GeoSRSName"
    Public Const db_expr_Geo_IsGeo As String = "GeoIsGeo"
    Public Const db_expr_Geo_Notes As String = "GeoNotes"

    'Local Location
    Public Const db_expr_Local As String = "LocalCoordinates"
    Public Const db_expr_Local_SRSID As String = "LocalSRSID"
    Public Const db_expr_Local_SRSName As String = "LocalSRSName"
    Public Const db_expr_Local_IsGeo As String = "LocalIsGeo"
    Public Const db_expr_Local_Notes As String = "LocalNotes"

    'Variable Units
    Public Const db_expr_VarUnits As String = "VariableUnits"
    Public Const db_expr_VarUnits_Name As String = "VariableUnitsName"
    Public Const db_expr_VarUnits_Type As String = "VariableUnitsType"
    Public Const db_expr_VarUnits_Abbr As String = "VariableUnitsAbbreviation"

    'Time Units
    Public Const db_expr_TimeUnits As String = "TimeUnits"
    Public Const db_expr_TimeUnits_Name As String = "TimeUnitsName"
    Public Const db_expr_TimeUnits_Type As String = "TimeUnitsType"
    Public Const db_expr_TimeUnits_Abbr As String = "TimeUnitsAbbreviation"

    'Offset Units
    Public Const db_expr_OffsetUnits As String = "OffsetUnits"
    Public Const db_expr_OffsetUnits_Name As String = "OffsetUnitsName"
    Public Const db_expr_OffsetUnits_Type As String = "OffsetUnitsType"
    Public Const db_expr_OffsetUnits_Abbr As String = "OffsetUnitsAbbreviation"

    'Contact Information
    Public Const db_expr_contact_Name As String = "ContactName"
    Public Const db_expr_contact_Phone As String = "ContactPhone"
    Public Const db_expr_contact_Email As String = "ContactEmail"
    Public Const db_expr_contact_Address As String = "ContactAddress"
    Public Const db_expr_contact_City As String = "ContactCity"
    Public Const db_expr_contact_State As String = "ContactState"
    Public Const db_expr_contact_Zip As String = "ContactZipCode"

#End Region

#Region " Update/Insert Expressions "

    Public Const db_expr_MaxID As String = "MaxID" 'holds the expression for retrieving the Maximum Value ID from the database for when creating new points or data series
    Public Const db_expr_OutTable As String = "OutputTable"
    Public Const db_expr_FiltTable As String = "FilterTable"

#End Region

#Region " Database Functions "

    Public Function getValue(ByVal query As String, ByRef settings As clsConnectionSettings) As Object

        Dim cmd As SqlClient.SqlCommand
        Dim conn As New SqlClient.SqlConnection(settings.ConnectionString)
        conn.Open()
        cmd = New SqlClient.SqlCommand(query, conn)
        Dim id As Object = cmd.ExecuteScalar()
        conn.Close()

        Return id
    End Function

    Public Function InsertBulk(ByVal tableName As String, ByVal data As DataTable, ByVal connectionString As String) As Boolean
        Dim bc As New SqlBulkCopy(connectionString)
        bc.BatchSize = 20
        bc.DestinationTableName = TableName
        Try
            bc.WriteToServer(data)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function OpenTable(ByVal tableName As String, ByVal sqlQuery As String, ByRef settings As clsConnectionSettings) As DataTable
        'Returns a dataTable of the query data.
        'Inputs:  tablename -> name of the table
        '         SqlQuery -> sql Query to retreive the data with
        '         connString -> the connection String for the database to connect to, to retreive the data from
        'Outputs: the dataTable of data retreived from the database using SqlQuery
        'create a flow table
        Dim table As New System.Data.DataTable(tableName) 'the table of data to return
        Dim dataAdapter As SqlClient.SqlDataAdapter ' OleDb.OleDbDataAdapter 'the dataAdapter to fill the table
        Try
            'connect to the Database
            dataAdapter = New SqlClient.SqlDataAdapter(sqlQuery, settings.ConnectionString) 'New OleDb.OleDbDataAdapter(sqlQuery, settings.ConnectionString)

            'get the table from the database
            dataAdapter.Fill(table)
            dataAdapter = Nothing
            Return table
        Catch ex As System.Exception
            table = Nothing
            dataAdapter = Nothing
            'if the connection timed out, increment the timeout and resave the settings. then try to open the table again.
            If LCase(ex.Message).Contains("timeout") Then
                If g_CurrConnSettings.IncrementTimeout() Then
                    My.Settings.Timeout = g_CurrConnSettings.Timeout
                    My.Settings.Save()
                    Return OpenTable(tableName, sqlQuery, settings)
                Else
                    ShowError("Connection timed out.")
                End If
            Else
                ShowError("An Error occurred while opening the Table = " & tableName & vbCrLf & "Message = " & ex.Message, ex)
            End If
        End Try

        Return Nothing
    End Function

    Public Function UpdateTable(ByVal dataTable As System.Data.DataTable, ByVal query As String, ByVal connectionString As String) As Boolean
        'this function updates the database after new rows have been added to or existing rows have been edited in the dataTable
        'the datatable is the the dataTable that was used to add/edit the rows, query is the query used to create the original datatable
        'Inputs: dataTable -> the dataTable used to add/edit the row
        '        query -> the query used to create the original dataTable
        '        connectionString -> the connectionString to the database
        'Outputs: none
        Dim updateAdapter As System.Data.SqlClient.SqlDataAdapter 'OleDb.OleDbDataAdapter	'updateAdapter -> finds out if anything has been changed and marks the rows that need to be added -> used by the command builder
        Dim commandBuilder As System.Data.SqlClient.SqlCommandBuilder 'OleDb.OleDbCommandBuilder	'CommandBuilder -> creates the insert function for updating the database
        Try
            'crate the updateAdapter,commandBuilder
            'updateAdapter = New System.Data.OleDb.OleDbDataAdapter(query, connectionString)
            updateAdapter = New System.Data.SqlClient.SqlDataAdapter(query, connectionString)
            'commandBuilder = New System.Data.OleDb.OleDbCommandBuilder(updateAdapter)
            commandBuilder = New System.Data.SqlClient.SqlCommandBuilder(updateAdapter)
            'update the database
            Dim count As Integer ' counter variable
            count = updateAdapter.Update(dataTable)

            'everything worked fine, return true
            Return True
        Catch ex As Exception
            ShowError("Error in UpdateTable()" & vbCr & "Message = " & ex.Message, ex)
        End Try
        'errors occurred, return false
        Return False
    End Function

    Public Function TestDBConnection(ByRef e_DBSettings As clsConnectionSettings, Optional ByRef ErrorMessage As String = "NONE") As Boolean
        'Used to test a databse connection
        'Inputs:  Settings -> A ConnectionSettings instance used to create a connection to a database
        'Outputs: TestDBConnection -> Returns True if the test was successful, otherwise returns False

        'Create a new connection
        Dim testConn As New SqlClient.SqlConnection(e_DBSettings.ConnectionString) 'OleDb.OleDbConnection(e_DBSettings.ConnectionString) 'Temporary connection settings to test
        Dim sql As String 'SQL command to test DB with
        If e_DBSettings.DBName = "" Or e_DBSettings.ServerAddress = "" Then
            Return False
        Else
            Try

                testConn.Open()

                'Create an sql command that accesses all tables and a field within the series catalog table
                sql = "SELECT MAX(" & db_fld_ODMVersionNumber & ") AS Max_Version FROM " & db_tbl_ODMVersion

                'Test the connection
                Dim temp As New SqlClient.SqlCommand(sql, testConn) '  OleDb.OleDbCommand(sql, testConn) 'Command to test the DB with
                Dim maxVersion As String = temp.ExecuteScalar
                If maxVersion <> db_const_Version Then
                    Throw New Exception("Database Version Incorrect." & vbCrLf & _
                    "This is an ODM Version " & maxVersion & " database." & vbCrLf & _
                    "This application requires an ODM Version " & db_const_Version & " database.")
                End If

                testConn.Close()
                testConn.Dispose()
            Catch ex As Exception
                'If the connection timed out, increment the timeout setting, return the results of another test, else return false
                If ex.Message.Contains("Timeout expired") Then
                    If e_DBSettings.IncrementTimeout() Then
                        Return TestDBConnection(e_DBSettings)
                    End If
                ElseIf ex.Message.Contains("SQL Server does not exist") Then
                    ShowError("Server Address Incorrect.", ex)
                    Return False
                ElseIf ex.Message.Contains("Cannot open database") Then
                    ShowError("Database Name Incorrect.", ex)
                    Return False
                ElseIf ex.Message.Contains("Login failed for user") Then
                    ShowError("Username or Password Incorrect.", ex)
                    Return False
                ElseIf ErrorMessage = "NONE" Then
                    ShowError("Unable to connect to Database", ex)
                    Return False
                Else
                    ErrorMessage = ex.Message
                    Return False
                End If
            End Try
            Return True
        End If
        'No Errors
    End Function

    Public Function FormatDateForQueryFromDB(ByVal d As Date) As String
        'Formats the date according to what type of data base connection is selected
        ' Sql puts quotes and oledb puts # around the date
        'Inputs:  d -> the date to format
        'Outputs: the correctly formatted date

        'Format the Date for an SQL Database
        Return "'" & d.ToString & "'"

    End Function

    Public Function FormatDateForInsertIntoDB(ByVal d As Date) As String
        'Formats the date according to what type of data base connection is selected
        ' Sql puts quotes and oledb puts # around the date
        'Inputs:  d -> the date to format
        'Outputs: the correctly formatted date

        'Format the Date for an SQL Database
        Return d.Month & "-" & d.Day & "-" & d.Year & " " & d.TimeOfDay.ToString
    End Function

    Public Function FormatStringForQueryFromDB(ByVal value As String) As String
        'Returns a string with ' replaced with '' for sql string statements.
        'Inputs:  value ->the string to format
        'Outputs: the formatted string
        Return (value.Replace("'", "''"))
    End Function


#End Region

#Region " Loading Functions "

#Region "Old Code"
    'NOTE: not using this now that have table in DB for this for new ODM1.1 schema!!

    'Public Sub LoadQCLevelDefinitions()
    '    'This function loads the Definitions for the QC Levels -> used on Query Tab, DeriveNewDataSeries Form
    '    'loads values in member variables = db_val_QCLDef_Level(0),db_val_QCLDef_Level(1),db_val_QCLDef_Level(2),db_val_QCLDef_Level(3),db_val_QCLDef_Level(4)
    '    'Inputs:  None
    '    'Outputs: None

    '    Dim qcFieldNames() As String = {db_fld_QCLQCLevel, db_fld_QCLDefinition} 'Array of the names of the desired fields within db_tbl_qclevels
    '    Dim qclDefDT(,) As String 'Table of Quality Control Level Definitions

    '    Try
    '        'Load the list of QC Levels
    '        qclDefDT = LoadDataList(db_tbl_QCLevels, qcFieldNames)
    '        db_val_QCLDef_Level = qclDefDT
    '        'ReDim db_val_QCLDef_Level(1, qclDefDT.GetUpperBound(1))
    '        'For i = 0 To qclDefDT.GetUpperBound(1)
    '        '	db_val_QCLDef_Level(0, i) = qclDefDT(0, i)
    '        '	db_val_QCLDef_Level(1, i) = qclDefDT(1, i)
    '        'Next
    '        db_qclLoaded = True
    '    Catch ex As Exception
    '        ShowError("An Error occurred while loading the Quality Control Level Definitions from the Database." & vbCrLf & "Message = " & ex.Message, ex)
    '    End Try
    'End Sub

    'Public Function GetQCLDefID(ByVal qcLevel As Integer) As Integer
    '	Dim x As Integer
    '	'0.
    '	For x = 0 To 4
    '		If db_val_QCLDef_Level(0, x) = qcLevel Then
    '			Return x
    '		End If
    '	Next x
    'End Function
#End Region

    Public Function GetVarIsRegularFromDB(ByVal varID As Integer) As Boolean
        'Returns the IsRegular value for the given variable
        'Inputs:  varID -> the variable ID for the variable to get the IsRegular value for
        'Outputs: Boolean -> returns the IsRegular value
        Dim query As String 'sql statement used to retrieve the IsRegular data from the database
        ' Dim isRegularDT As Data.DataTable 'DataTable to hold the data retrieved from the database
        Dim isRegular As Boolean = False 'the isRegular value -> return value
        Try
            '1. get the IsRegular value for the given variable
            query = "SELECT " & db_fld_VarIsRegular & " FROM " & db_tbl_Variables & " WHERE " & db_fld_VarID & " = " & varID
            isRegular = getValue(query, g_CurrConnSettings)

            'isRegularDT = OpenTable("CheckIsRegular", query, g_CurrConnSettings)
            'If (isRegularDT Is Nothing) OrElse (isRegularDT.Rows.Count = 0) Then
            '    'errors or nothing was returned, return false
            '    Exit Try
            'End If
            ''get the isRegular value
            'If (isRegularDT.Rows(0).Item(db_fld_VarIsRegular) Is DBNull.Value) Then
            '    'value = NULL -> return false
            '    isRegular = False
            'Else
            '    isRegular = isRegularDT.Rows(0).Item(db_fld_VarIsRegular)
            'End If

            ''release resources
            'If Not (isRegularDT Is Nothing) Then
            '    isRegularDT.Dispose()
            '    isRegularDT = Nothing
            'End If

            Return isRegular
        Catch ex As Exception
            ShowError("An Error occurred while retrieving the IsRegular value for the VariableID = " & varID & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        'If Not (isRegularDT Is Nothing) Then
        '    isRegularDT.Dispose()
        '    isRegularDT = Nothing
        'End If
        'errors occurred above, return false
        Return False
    End Function

    Public Function GetVarNoDataValueFromDB(ByVal varID As Integer) As Double
        'Retrieves the NoDataValue from the Database for the given variable
        'Inputs:  varID -> the variable ID for the variable to retrieved the NoDataValue for
        'Outptus: Double > the NoDataValue for the given variable
        Dim query As String 'the sql query used to pull the NoDataValue value from the database
        'Dim noDataValDT As Data.DataTable 'the DataTable to hold the data retrieved from the database
        Dim noDataValue As Double = -9999.0 'the NoDataValue (initialized to -9999) -> return value
        Try
            '1. get the IsRegular value for the given variable
            query = "SELECT " & db_fld_VarNoDataVal & " FROM " & db_tbl_Variables & " WHERE " & db_fld_VarID & " = " & varID
            noDataValue = getValue(query, g_CurrConnSettings)
            If (noDataValue = 0) Then
                noDataValue = -9999
            End If

            'noDataValDT = OpenTable("RetriveNoDataValue", query, g_CurrConnSettings)
            'If (noDataValDT Is Nothing) OrElse (noDataValDT.Rows.Count = 0) Then
            '    'errors or nothing was returned, return default value = -9999
            '    Exit Try
            'End If
            ''get the isRegular value
            'If (noDataValDT.Rows(0).Item(db_fld_VarNoDataVal) Is DBNull.Value) Then
            '    'value = NULL -> return false
            '    noDataValue = -9999
            'Else
            'noDataValue = noDataValDT.Rows(0).Item(db_fld_VarNoDataVal)
            'End If

            ''release resources
            'If Not (noDataValDT Is Nothing) Then
            '    noDataValDT.Dispose()
            '    noDataValDT = Nothing
            'End If

            Return noDataValue
        Catch ex As Exception
            ShowError("An Error occurred while retrieving the No Data Value for the VariableID = " & varID & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        'If Not (noDataValDT Is Nothing) Then
        '    noDataValDT.Dispose()
        '    noDataValDT = Nothing
        'End If
        'errors occurred above, return false
        Return False
    End Function

    Public Function GetUnitsIDFromDB(ByVal unitsName As String) As Integer
        'Retrieves the Units ID from the database for the given Units Name
        'Inputs:  unitsName -> the name of the units to retrieve the ID for
        'Outputs: Integer -> the ID for the given Units name
        Dim unitsID As Integer = -1 'units ID value retrieved from the database (initialized to -1) -> return value
        'Dim unitsDT As Data.DataTable   'Datatable to hold the UnitsID retrieved from the Units Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Try
            '1. Connect to the database
            query = "SELECT " & db_fld_UnitsID & " FROM " & db_tbl_Units & " WHERE " & db_fld_UnitsName & " = '" & FormatStringForQueryFromDB(unitsName) & "' ORDER BY " & db_fld_UnitsID
            unitsID = getValue(query, g_CurrConnSettings)
            'validate for data
            'unitsDT = OpenTable("GetUnitsIDDT", query, g_CurrConnSettings)
            'If (unitsDT Is Nothing) OrElse unitsDT.Rows.Count = 0 Then
            '    'release resources
            '    If Not (unitsDT Is Nothing) Then
            '        unitsDT.Dispose()
            '        unitsDT = Nothing
            '    End If

            '    'return -1 -> no ID was found
            '    Exit Try
            'End If

            ''2. Get the UnitsID for the given Units Name -> just get first one!!
            'If Not (unitsDT.Rows(0).Item(db_fld_UnitsID) Is DBNull.Value) Then
            '    unitsID = unitsDT.Rows(0).Item(db_fld_UnitsID)
            'Else
            '    unitsID = -1
            'End If

            ''3. release resources
            'If Not (unitsDT Is Nothing) Then
            '    unitsDT.Dispose()
            '    unitsDT = Nothing
            'End If

            Return unitsID
        Catch ex As Exception
            ShowError("An Error occurred when retrieving the " & db_fld_UnitsID & " from the Database for the Units = " & unitsName & vbCrLf & "Message = " & ex.Message, ex)
            'release resources
            'If Not (unitsDT Is Nothing) Then
            '    unitsDT.Dispose()
            '    unitsDT = Nothing
            'End If
            'return whatever value was set
        End Try
        Return unitsID
    End Function
    
    Public Function GetVariableIDFromDB(ByVal varCode As String, ByVal varName As String, ByVal speciation As String, ByVal varUnitsID As Integer, ByVal sampleMed As String, ByVal valueType As String, ByVal timeSupport As Double, ByVal tsUnitsID As Integer, ByVal dataType As String, ByVal genCategory As String) As Integer
        'Retrieves the Variable ID from the database for the given variable
        'Inputs:  varCode -> the Variable Code to get the ID for
        '         varName -> the Variable Name to get the ID for
        '		  speciation -> the Speciation to get the ID for
        '         varUnitsID -> the Variable Units ID to get the ID for
        '         sampleMed -> the Variable Sample Medium to get the ID for
        '         valueType -> the Variable Value Type to get the ID for
        '         timeSupport -> the Variable Time Support Value to get the ID for
        '         tsUnitsID -> the Variable Time Support Units ID to get the ID for
        '         dataType -> the Variable DataType to get the ID for
        '         getCategorty -> the Variable General Category to get the ID for
        'Outputs: Integer -> the Variable ID for the given variable
        Dim varID As Integer = -1 'the variable retrieved from the database (initialized to -1) -> Return value
        'Dim varDT As Data.DataTable 'Datatable to hold the VariableID retrieved from the Units Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Try
            '1. Connect to the database
            query = "SELECT " & db_fld_VarID & " FROM " & db_tbl_Variables & " WHERE (" & db_fld_VarCode & " = '" & FormatStringForQueryFromDB(varCode) & "' AND " & db_fld_VarName & " = '" & FormatStringForQueryFromDB(varName) & "' AND " & db_fld_VarSpeciation & " = '" & FormatStringForQueryFromDB(speciation) & "' AND " & db_fld_VarUnitsID & " = " & varUnitsID & " AND " & db_fld_VarSampleMed & " = '" & FormatStringForQueryFromDB(sampleMed) & "' AND " & db_fld_VarValueType & " = '" & FormatStringForQueryFromDB(valueType) & "' AND " & db_fld_VarTimeSupport & " = " & timeSupport & " AND " & db_fld_VarTimeUnitsID & " = " & tsUnitsID & " AND " & db_fld_VarDataType & " = '" & FormatStringForQueryFromDB(dataType) & "' AND " & db_fld_VarGenCat & " = '" & FormatStringForQueryFromDB(genCategory) & "') ORDER BY " & db_fld_VarID
            varID = getValue(query, g_CurrConnSettings)
            'validate for data
            'varDT = OpenTable("GetVarIDDT", query, g_CurrConnSettings)
            'If (varDT Is Nothing) OrElse varDT.Rows.Count = 0 Then
            '    'release resources
            '    If Not (varDT Is Nothing) Then
            '        varDT.Dispose()
            '        varDT = Nothing
            '    End If

            '    'return -1 -> no ID was found
            '    Exit Try
            'End If

            ''2. Get the VariableID for the given Variable -> just get first one!!
            'If Not (varDT.Rows(0).Item(db_fld_VarID) Is DBNull.Value) Then
            '    varID = varDT.Rows(0).Item(db_fld_VarID)
            'Else
            '    varID = -1
            'End If


            ''3. release resources
            'If Not (varDT Is Nothing) Then
            '    varDT.Dispose()
            '    varDT = Nothing
            'End If

            Return varID
        Catch ex As Exception
            ShowError("An Error occurred when retrieving the " & db_fld_VarID & " from the Database for the Variable: " & vbCrLf & "Desc = " & varCode & " - " & varName & vbCrLf & "UnitsID = " & varUnitsID & vbCrLf & "Sample Medium = " & sampleMed & vbCrLf & "Value Type = " & valueType & vbCrLf & "Time Support = " & timeSupport & vbCrLf & "Time UnitsID = " & tsUnitsID & vbCrLf & "Data Type = " & dataType & vbCrLf & "General Category = " & genCategory & vbCrLf & vbCrLf & "Message = " & ex.Message, ex)
            'release resources
            'If Not (varDT Is Nothing) Then
            '    varDT.Dispose()
            '    varDT = Nothing
            'End If
            'return whatever value was set
        End Try
        Return varID
    End Function

    Public Function GetMethodIDFromDB(ByVal methodDesc As String) As Integer
        'Retrieves the Method ID from the database for the given descriptiong
        'Inputs:  methodDesc -> the Method Description to get the ID for
        'Outputs: Integer -> the MethodID for the given description
        Dim methodID As Integer = -1 'the MethodID retrieved from the database (intialized to -1) -> return value
        'Dim methodDT As Data.DataTable  'Datatable to hold the MethodID retrieved from the Methods Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Try
            '1. Connect to the database
            query = "SELECT " & db_fld_MethID & " FROM " & db_tbl_Methods & " WHERE " & db_fld_MethDesc & " = '" & FormatStringForQueryFromDB(methodDesc) & "' ORDER BY " & db_fld_MethID
            'validate for data

            methodID = getValue(query, g_CurrConnSettings)


            'methodDT = OpenTable("GetMethodIDDT", query, g_CurrConnSettings)
            'If (methodDT Is Nothing) OrElse methodDT.Rows.Count = 0 Then
            '    'release resources
            '    If Not (methodDT Is Nothing) Then
            '        methodDT.Dispose()
            '        methodDT = Nothing
            '    End If

            '    'return -1 -> no ID was found
            '    Exit Try
            'End If

            ''2. Get the MethodID for the given Method Desc -> just get first one!!
            'If Not (methodDT.Rows(0).Item(db_fld_MethID) Is DBNull.Value) Then
            '    methodID = methodDT.Rows(0).Item(db_fld_MethID)
            'Else
            '    methodID = -1
            'End If

            '3. release resources
            'If Not (methodDT Is Nothing) Then
            '    methodDT.Dispose()
            '    methodDT = Nothing
            'End If

            Return methodID
        Catch ex As Exception
            ShowError("An Error occurred when retrieving the " & db_fld_MethID & " from the Database for the Method Description = " & methodDesc & vbCrLf & "Message = " & ex.Message, ex)
            'release resources
            'If Not (methodDT Is Nothing) Then
            '    methodDT.Dispose()
            '    methodDT = Nothing
            'End If
            'return whatever value was set
        End Try
        Return methodID
    End Function

#Region " Code not currently being used, but may in the future "

    'Public Function GetDerivedFromIDFromDB(ByVal valID As Integer) As Integer
    '	Dim derivedFromID As Integer = db_val_DerivedFromID_Invalid
    '	Dim deriveFromDT As Data.DataTable	'Datatable to hold the UnitsID retrieved from the Units Table in the Database
    '	Dim query As String	'SQL Query to pull the data from the database
    '	Try
    '		'1. Connect to the database
    '		query = "SELECT DISTINCT " & db_fld_DFID & " FROM " & db_tbl_DerivedFrom & " WHERE " & db_fld_DFID & " IN (SELECT " & db_fld_DFID & " FROM " & db_tbl_DerivedFrom & " WHERE " & db_fld_DFValueID & " = " & valID & ") AND " & db_fld_DFID & " NOT IN (SELECT " & db_fld_DFID & " FROM " & db_tbl_DerivedFrom & " WHERE " & db_fld_DFValueID & " NOT IN (" & valID & "))"
    '		'validate for data
    '		deriveFromDT = OpenTable("GetDerivedFromIDDT", query, g_CurrConnSettings)
    '		If (deriveFromDT Is Nothing) OrElse deriveFromDT.Rows.Count = 0 Then
    'release resources
    '			If Not (deriveFromDT Is Nothing) Then
    '				deriveFromDT.Dispose()
    '				deriveFromDT = Nothing
    '			End If

    '			'return db_val_DerivedFromID_Invalid -> no ID was found
    '			Exit Try
    '		End If

    '		'2. Get the DerivedFromID for the given ValueID -> just get first one!!
    '		If Not (deriveFromDT.Rows(0).Item(db_fld_DFID) Is DBNull.Value) Then
    '			derivedFromID = deriveFromDT.Rows(0).Item(db_fld_DFID)
    '		Else
    '			derivedFromID = db_val_DerivedFromID_Invalid
    '		End If

    '		'3. release resources
    '		If Not (deriveFromDT Is Nothing) Then
    '			deriveFromDT.Dispose()
    '			deriveFromDT = Nothing
    '		End If

    '		Return derivedFromID
    '	Catch ex As Exception
    '		ShowError("An Error occurred when retrieving the " & db_fld_DFID & " from the Database for the ValueID = " & valID & vbCrLf & "Message = " & ex.Message, ex)
    '		'release resources
    '		If Not (deriveFromDT Is Nothing) Then
    '			deriveFromDT.Dispose()
    '			deriveFromDT = Nothing
    '		End If
    '		'return whatever value was set
    '	End Try
    '	Return derivedFromID
    'End Function

    'Public Function GetDerivedFromIDFromDB(ByVal dataRows As Data.DataRow()) As Integer
    '	Dim i As Integer 'counter
    '	Dim derivedFromID As Integer = db_val_DerivedFromID_Invalid
    '	Dim deriveFromDT As Data.DataTable	'Datatable to hold the UnitsID retrieved from the Units Table in the Database
    '	Dim query As String	'SQL Query to pull the data from the database
    '	Dim list As String 'used as the end of the query
    '	Try
    '		'1. Connect to the database
    '		query = "SELECT DISTINCT " & db_fld_DFID & " FROM " & db_tbl_DerivedFrom & " WHERE "
    '		list = " AND " & db_fld_DFID & " NOT IN (SELECT " & db_fld_DFID & " FROM " & db_tbl_DerivedFrom & " WHERE " & db_fld_DFValueID & " NOT IN ("
    '		For i = 0 To dataRows.GetLength(0) - 1
    '			If i > 0 Then
    '				query = query & " AND "
    '				list = list & ", "
    '			End If
    '			query = query & db_fld_DFID & " IN (SELECT " & db_fld_DFID & " FROM " & db_tbl_DerivedFrom & " WHERE " & db_fld_DFValueID & " = " & dataRows(i).Item(db_fld_ValID) & ")"
    '			list = list & dataRows(i).Item(db_fld_ValID)
    '		Next i
    '		query = query & list & "))"	'& " ORDER BY " & db_fld_DFID
    '		'validate for data
    '		deriveFromDT = OpenTable("MULTGetDerivedFromIDDT", query, g_CurrConnSettings)
    '		If (deriveFromDT Is Nothing) OrElse deriveFromDT.Rows.Count = 0 Then
    '			'release resources
    '			If Not (deriveFromDT Is Nothing) Then
    '				deriveFromDT.Dispose()
    '				deriveFromDT = Nothing
    '			End If

    '			'return db_val_DerivedFromID_Invalid -> no ID was found
    '			Exit Try
    '		End If

    '		'2. Get the UnitsID for the given Method Desc -> just get first one!!
    '		If Not (deriveFromDT.Rows(0).Item(db_fld_DFID) Is DBNull.Value) Then
    '			derivedFromID = deriveFromDT.Rows(0).Item(db_fld_DFID)
    '		Else
    '			derivedFromID = db_val_DerivedFromID_Invalid
    '		End If

    '		'3. release resources
    '		If Not (deriveFromDT Is Nothing) Then
    '			deriveFromDT.Dispose()
    '			deriveFromDT = Nothing
    '		End If

    '		Return derivedFromID
    '	Catch ex As Exception
    '		ShowError("An Error occurred when retrieving the " & db_fld_DFID & " from the Database for the given set of ValueIDs." & vbCrLf & "Message = " & ex.Message, ex)
    '		'release resources
    '		If Not (deriveFromDT Is Nothing) Then
    '			deriveFromDT.Dispose()
    '			deriveFromDT = Nothing
    '		End If
    '		'return whatever value was set
    '	End Try
    '	Return derivedFromID
    'End Function

#End Region

    Public Function GetQualifierIDFromDB(ByVal qualifierCode As String, ByVal qualifierDesc As String) As Integer
        'Retrieves the Qualifier ID from the database for the given qualifier
        'Inputs:  qualifierCode -> the Qualifier Code to get the ID for
        '         qualifierDesc -> the Qualifier Description to get the ID for
        'Outputs: Integer -> the ID for the given qualifier 
        Dim qualifierID As Integer = -1 'the Qualifier ID retrieved from the database (initialized to -1) -> return value
        'Dim qualifierDT As Data.DataTable   'Datatable to hold the QualifierID retrieved from the Qualifiers Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Try
            '1. Connect to the database
            query = "SELECT " & db_fld_QlfyID & " FROM " & db_tbl_Qualifiers & " WHERE " & db_fld_QlfyDesc & " = '" & FormatStringForQueryFromDB(qualifierDesc) & "' AND " & db_fld_QlfyDesc & " = '" & FormatStringForQueryFromDB(qualifierDesc) & "' ORDER BY " & db_fld_QlfyID
            qualifierID = getValue(query, g_CurrConnSettings)


            'validate for data
            'qualifierDT = OpenTable("GetQualifierIDDT", query, g_CurrConnSettings)
            'If (qualifierDT Is Nothing) OrElse qualifierDT.Rows.Count = 0 Then
            '    'release resources
            '    If Not (qualifierDT Is Nothing) Then
            '        qualifierDT.Dispose()
            '        qualifierDT = Nothing
            '    End If

            '    'return -1 -> no ID was found
            '    Exit Try
            'End If

            ''2. Get the QualifierID for the given Qualifier Code,Desc -> just get first one!!
            'If Not (qualifierDT.Rows(0).Item(db_fld_QlfyID) Is DBNull.Value) Then
            '    qualifierID = qualifierDT.Rows(0).Item(db_fld_QlfyID)
            'Else
            '    qualifierID = -1
            'End If


            ''3. release resources
            'If Not (qualifierDT Is Nothing) Then
            '    qualifierDT.Dispose()
            '    qualifierDT = Nothing
            'End If

            Return qualifierID
        Catch ex As Exception
            ShowError("An Error occurred when retrieving the " & db_fld_QlfyID & " from the Database for the qualifier Description = " & qualifierDesc & vbCrLf & "Message = " & ex.Message, ex)
            'release resources
            'If Not (qualifierDT Is Nothing) Then
            '    qualifierDT.Dispose()
            '    qualifierDT = Nothing
            'End If
            'return whatever value was set
        End Try
        Return qualifierID
    End Function

    Public Function GetSampleIDFromDB(ByVal sampleType As String, ByVal labSampleCode As String) As Integer
        'Retrieves the Sample ID from the database for the given sample
        'Inputs:  sampleType -> the Sample Type to get the ID for
        '         labSampleCode -> the Sample Lab Sample Code to get the ID for
        'Outputs: Integer -> the SampleID for the given sample
        Dim sampleID As Integer = -1 'the SampleID retrieved from the database (initialized to -1) -> return value
        'Dim sampleDT As Data.DataTable  'Datatable to hold the UnitsID retrieved from the Units Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Try
            '1. Connect to the database				db_fld_SampleType, db_fld_SampleLabCode
            query = "SELECT " & db_fld_SampleID & " FROM " & db_tbl_Samples & " WHERE " & db_fld_SampleType & " = '" & FormatStringForQueryFromDB(sampleType) & "' AND " & db_fld_SampleLabCode & " = '" & FormatStringForQueryFromDB(labSampleCode) & "' ORDER BY " & db_fld_SampleID
            sampleID = getValue(query, g_CurrConnSettings)
            'validate for data
            'sampleDT = OpenTable("GetSampleIDDT", query, g_CurrConnSettings)
            'If (sampleDT Is Nothing) OrElse sampleDT.Rows.Count = 0 Then
            '    'release resources
            '    If Not (sampleDT Is Nothing) Then
            '        sampleDT.Dispose()
            '        sampleDT = Nothing
            '    End If

            '    'return -1 -> no ID was found
            '    Exit Try
            'End If

            ''2. Get the ID for the given Sample Type,LabSampleCode -> just get first one!!
            'If Not (sampleDT.Rows(0).Item(db_fld_SampleID) Is DBNull.Value) Then
            '    sampleID = sampleDT.Rows(0).Item(db_fld_SampleID)
            'Else
            '    sampleID = -1
            'End If

            ''3. release resources
            'If Not (sampleDT Is Nothing) Then
            '    sampleDT.Dispose()
            '    sampleDT = Nothing
            'End If

            Return sampleID
        Catch ex As Exception
            ShowError("An Error occurred when retrieving the " & db_fld_SampleID & " from the Database for the Sample Type = " & sampleType & " and the Lab Sample Code = " & labSampleCode & vbCrLf & "Message = " & ex.Message, ex)
            'release resources
            'If Not (sampleDT Is Nothing) Then
            '    sampleDT.Dispose()
            '    sampleDT = Nothing
            'End If
            'return whatever value was set
        End Try
        Return sampleID
    End Function

    Public Function GetValuesFromDB(ByVal tblName As String, ByVal siteID As Integer, ByVal varID As Integer, ByVal qcLevel As Integer, ByVal methodID As Integer, ByVal sourceID As Integer) As Data.DataTable
        'This function loads all data from the Database for the selected Data Series
        'Inputs:  tblName -> the name of the table to create -> used to create the DataTable returned
        '         siteID -> the Site ID for the values to retrieve
        '         varID -> the Variable ID for the values to retrieve
        '         qcLevel -> the Quality Control Level ID for the valuet rerieve
        '         methodID -> the Method ID for the values to retrieve
        '         sourceID -> the Source ID for the values to retrieve
        'Outputs: DataTable -> the data retrieved from the database
        Dim query As String 'the sql query to pull the data from the database
        Dim valuesDT As Data.DataTable 'the datatable of Values retrieved from the database for the given Data series -> Return Value
        Try
            '1. Validate Data
            'If (siteID <= 0) OrElse (varID <= 0) OrElse (methodID < 0) OrElse (sourceID <= 0) Then
            If Not IsNumeric(siteID) OrElse Not IsNumeric(varID) OrElse Not IsNumeric(methodID) OrElse Not IsNumeric(sourceID) Then

                'Exit, cannot create table -> invalid parameters
                Exit Try
            End If

            '2. create the query
            'query = "SELECT *, Year(" & db_fld_ValDateTime & ") AS " & db_outFld_ValDTYear & ", Month(" & db_fld_ValDateTime & ") AS " & db_outFld_ValDTMonth & ", Day(" & db_fld_ValDateTime & ") AS " & db_outFld_ValDTDay & " FROM " & db_tbl_DataValues & " WHERE (" & db_fld_ValMethodID & " = " & methodID & " AND " & db_fld_ValQCLevel & " = " & qcLevel & " AND " & db_fld_ValSiteID & " = " & siteID & " AND " & db_fld_ValVarID & " = " & varID & " AND " & db_fld_ValSourceID & " = " & sourceID & ") ORDER BY " & db_fld_ValDateTime
            query = "SELECT * FROM " & db_tbl_DataValues & " WHERE (" & db_fld_ValMethodID & " = " & methodID & " AND " & db_fld_ValQCLevel & " = " & qcLevel & " AND " & db_fld_ValSiteID & " = " & siteID & " AND " & db_fld_ValVarID & " = " & varID & " AND " & db_fld_ValSourceID & " = " & sourceID & ") ORDER BY " & db_fld_ValDateTime
            'query = "Select NULL as ValueID, DataValue, ValueAccuracy, LocalDateTime,  UTCOffset, DateTimeUTC, SiteID,  VariableID,OffsetValue, OffsetTypeID, CensorCode, QualifierID, MethodID, SourceID,  SampleID, DerivedFromID,  QualityControlLevelID FROM " & db_tbl_DataValues & " WHERE (" & db_fld_ValMethodID & " = " & methodID & " AND " & db_fld_ValQCLevel & " = " & qcLevel & " AND " & db_fld_ValSiteID & " = " & siteID & " AND " & db_fld_ValVarID & " = " & varID & " AND " & db_fld_ValSourceID & " = " & sourceID & ") ORDER BY " & db_fld_ValDateTime
            '3. Open the table
            valuesDT = OpenTable(tblName, query, g_CurrConnSettings)
            'validate have data
            If Not (valuesDT Is Nothing) Then
                If valuesDT.Rows.Count = 0 Then
                    'release resources, return nothing
                    valuesDT.Dispose()
                    valuesDT = Nothing
                End If
            End If

            '4. Return what was retrieved
            Return valuesDT
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while loading the data values from the Database for the SiteID = " & siteID & vbCrLf & "VariableID = " & varID & vbCrLf & "Quality Control Level = " & qcLevel & vbCrLf & "MethodID = " & methodID & vbCrLf & "SourceID = " & sourceID & vbCrLf & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'errors occurred above, return nothing
        Return Nothing
    End Function

#Region "Code Not being used: GetUnusedValuesFromDB" 'Stephanie
    'Public Function GetUnusedValuesFromDB(ByVal tblName As String, ByVal siteID As Integer, ByVal varID As Integer, ByVal qcLevel As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal filterQCLevel As Integer) As Data.DataTable
    '    'This function loads all data from the Database for the selected Data Series
    '    'Inputs:  tblName -> the name of the table to create -> used to create the DataTable returned
    '    '         siteID -> the Site ID for the values to retrieve
    '    '         varID -> the Variable ID for the values to retrieve
    '    '         qcLevel -> the Quality Control Level ID for the value to rerieve
    '    '         methodID -> the Method ID for the values to retrieve
    '    '         sourceID -> the Source ID for the values to retrieve
    '    'Outputs: DataTable -> the data retrieved from the database
    '    Dim query As String 'the sql query to pull the data from the database
    '    Dim valuesDT As Data.DataTable 'the datatable of Values retrieved from the database for the given Data series -> Return Value
    '    Try
    '        '1. Validate Data
    '        If (siteID <= 0) OrElse (varID <= 0) OrElse (qcLevel <= 0) OrElse (methodID <= 0) OrElse (sourceID <= 0) Then
    '            'Exit, cannot create table -> invalid parameters
    '            Exit Try
    '        End If

    '        '2. create the query
    '        'MICHELLE: Does this need to use an inner join?
    '        query = "SELECT " & _
    '        db_expr_OutTable & ".* FROM " & _
    '        db_tbl_DataValues & " AS " & db_expr_FiltTable & " INNER JOIN " & _
    '        db_tbl_DerivedFrom & " ON " & _
    '        db_expr_FiltTable & "." & db_fld_ValDerivedFromID & " = " & _
    '        db_tbl_DerivedFrom & "." & db_fld_DFID & " RIGHT OUTER JOIN " & _
    '        db_tbl_DataValues & " AS " & db_expr_OutTable & " ON " & _
    '        db_tbl_DerivedFrom & "." & db_fld_DFValueID & " = " & _
    '        db_expr_OutTable & "." & db_fld_ValID & _
    '        " WHERE ((" & _
    '        db_expr_OutTable & "." & db_fld_ValSiteID & " = " & siteID & ") AND (" & _
    '        db_expr_OutTable & "." & db_fld_ValVarID & " = " & varID & ") AND (" & _
    '        db_expr_OutTable & "." & db_fld_ValSourceID & " = " & sourceID & ") AND (" & _
    '        db_expr_OutTable & "." & db_fld_ValQCLevel & " = " & qcLevel & ")) AND ((" & _
    '        db_expr_FiltTable & "." & db_fld_ValDerivedFromID & " IS NULL) OR NOT ((" & _
    '        db_expr_FiltTable & "." & db_fld_ValSiteID & " = " & siteID & ") AND (" & _
    '        db_expr_FiltTable & "." & db_fld_ValVarID & " = " & varID & ") AND (" & _
    '        db_expr_FiltTable & "." & db_fld_ValSourceID & " = " & sourceID & ") AND (" & _
    '        db_expr_FiltTable & "." & db_fld_ValQCLevel & " = " & filterQCLevel & ")))"
    '        'query = "SELECT *, Year(" & db_fld_ValDateTime & ") AS " & db_outFld_ValDTYear & ", Month(" & db_fld_ValDateTime & ") AS " & db_outFld_ValDTMonth & ", Day(" & db_fld_ValDateTime & ") AS " & db_outFld_ValDTDay & " FROM " & db_tbl_DataValues & " WHERE (" & db_fld_ValMethodID & " = " & methodID & " AND " & db_fld_ValQCLevel & " = " & qcLevel & " AND " & db_fld_ValSiteID & " = " & siteID & " AND " & db_fld_ValVarID & " = " & varID & " AND " & db_fld_ValSourceID & " = " & sourceID & ") ORDER BY " & db_fld_ValDateTime

    '        '3. Open the table
    '        valuesDT = OpenTable(tblName, query, g_CurrConnSettings)
    '        'validate have data
    '        If Not (valuesDT Is Nothing) Then
    '            If valuesDT.Rows.Count = 0 Then
    '                'release resources, return nothing
    '                valuesDT.Dispose()
    '                valuesDT = Nothing
    '            End If
    '        End If

    '        '4. Return what was retrieved
    '        Return valuesDT
    '    Catch ex As Exception
    '        'show an error message
    '        ShowError("An Error occurred while loading the data values from the Database for the SiteID = " & siteID & vbCrLf & "VariableID = " & varID & vbCrLf & "Quality Control Level = " & qcLevel & vbCrLf & "MethodID = " & methodID & vbCrLf & "SourceID = " & sourceID & vbCrLf & vbCrLf & "Message = " & ex.Message, ex)
    '    End Try
    '    'errors occurred above, return nothing
    '    Return Nothing
    'End Function
#End Region

    Public Function GetOffsetUnitsFromDB(ByVal e_OffsetTypeID As Object) As String
        'Retrieves the Specific Offset Type's Units Abrv from the Database
        'Input:  ID of the OffsetType
        'Output: String Containing the Offset Type's Units Abrv
        Try
            If Not (e_OffsetTypeID Is DBNull.Value) Then
                'Dim units As New DataTable 'Data table used to read from the database
                'Dim query As String  'Query used to get the units for the specified offset
                Dim query As String = "SELECT " & db_tbl_Units & "." & db_fld_UnitsAbrv & _
                " FROM " & db_tbl_Units & _
                " JOIN " & db_tbl_OffsetTypes & _
                " ON " & db_tbl_Units & "." & db_fld_UnitsID & _
                " = " & db_tbl_OffsetTypes & "." & db_fld_OTUnitsID & _
                " WHERE " & db_tbl_OffsetTypes & "." & db_fld_OTID & " = " & e_OffsetTypeID
                'units = OpenTable("UnitsFromDB", query, g_CurrConnSettings)
                'If (Not (units Is Nothing)) And (units.Rows.Count > 0) Then
                '    Return units.Rows(0).Item(0).ToString
                'Else
                '    Return ""
                'End If
                Return getValue(query, g_CurrConnSettings)
            Else
                Return ""
            End If
        Catch ex As Exception
            ShowError("An Error occurred while loading the Offset Types list." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Return ""
    End Function

    Public Function GetOffsetTypeFromDB(ByVal id As Object) As String
        'Retrieves the specified Offset Type Description
        'Input:  Id of the Offset Type to Retrieve
        'Output: The Description of the Specified Offset Type
        Try
            If Not (id Is DBNull.Value) Then
                'Dim ot As New DataTable 'Table used to read the offset types from the DB
                'Dim sql As String 'the sql command used to get the offset type for the specified ID
                Dim sql As String = "SELECT " & db_fld_OTDesc & " FROM " & db_tbl_OffsetTypes & " WHERE " & db_fld_OTID & " = " & id
                'ot = OpenTable("OffsetTypeFromDB", sql, g_CurrConnSettings)
                'If (Not (ot Is Nothing)) And (ot.Rows.Count > 0) Then
                '    Return ot.Rows(0).Item(0).ToString
                'Else
                '    Return ""
                'End If
                Return getValue(sql, g_CurrConnSettings)
            Else
                Return ""
            End If
        Catch ex As Exception
            ShowError("An Error occurred while loading the Offset Types list." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Return ""
    End Function

    Public Function GetMaxValIDFromDB() As Integer
        'Retrieves the highest Value ID in the database
        'Output: The Highest Value ID in the Database
        Try
            'Dim valID As New DataTable 'Used to get the largest value id from the database
            Dim sql As String = "SELECT MAX(" & db_fld_ValID & ") FROM " & db_tbl_DataValues
            'valID = OpenTable("MaxValueID", sql, g_CurrConnSettings)
            'If (Not (valID Is Nothing)) And (valID.Rows.Count > 0) Then
            '    Return CInt(valID.Rows(0).Item(0))
            'Else
            '    Return -1
            'End If
            Return getValue(sql, g_CurrConnSettings)
        Catch ex As Exception
            ShowError("An Error occurred while finding the Maximum Value ID." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Return -1
    End Function

    Public Function GetDataSeriesIDFromDB(ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qcLevelID As Integer) As Integer
        'Retrieves the ID for a specific data series
        'Input: siteID -> The Site ID for the Specific Data Series
        '       varID -> The Variable ID for the Specific Data Series
        '       methodID -> The Method ID for the Specific Data Series
        '       sourceID -> The Source ID for the Specific Data Series
        '       qcLevelID -> The Quality Control Level for the Specific Data Series
        'Output: The Series ID of the Specified Data Series
        Dim dsID As Integer = -1 'the Data series ID retrieved from the database (initialized to -1) -> return value
        'Dim dsDT As Data.DataTable 'the datatable of data to hold the Data series Id retrieved from the database
        Dim sql As String 'the SQL statement to pull the data from the database
        Try
            '1. get variable values to get the Data Series ID from the Series Catalog table

            '2. get the Data Series ID from the database
            sql = "SELECT " & db_fld_SCSeriesID & " FROM " & db_tbl_SeriesCatalog & " WHERE (" & db_fld_SCSiteID & " = " & siteID & " AND " & db_fld_SCVarID & " = " & varID & " AND " & db_fld_SCMethodID & " = " & methodID & " AND " & db_fld_SCSourceID & " = " & sourceID & " AND " & db_fld_SCQCLevel & " = " & qcLevelID & ") ORDER BY " & db_fld_SCSeriesID
            dsID = getValue(sql, g_CurrConnSettings)
            'dsDT = OpenTable("GetDataSeriesID", sql, g_CurrConnSettings)
            'If (dsDT Is Nothing) OrElse (dsDT.Rows.Count <= 0) Then
            '    'return -1
            '    Exit Try
            'End If

            ''3. make sure have a valid value
            'If Not (dsDT.Rows(0).Item(db_fld_SCSeriesID) Is DBNull.Value) Then
            '    dsID = dsDT.Rows(0).Item(db_fld_SCSeriesID)
            'Else
            '    dsID = -1
            'End If

            ''4. release resources
            'If Not (dsDT Is Nothing) Then
            '    dsDT.Dispose()
            '    dsDT = Nothing
            'End If

            '5. return value
            Return dsID
        Catch ex As Exception
            ShowError("An Error occurred while finding the Data Series ID." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        'If Not (dsDT Is Nothing) Then
        '    dsDT.Dispose()
        '    dsDT = Nothing
        'End If
        'return -1
        dsID = -1
        Return dsID
    End Function

    Public Function GetQCLevelIDFromDB(ByVal qclevel_Code As String, ByVal qclevel_Def As String) As Integer
        'Retrieves the ID for a specific quality control level
        'Input: qclevel_Code -> The QCLevel Code 
        '       qclevel_Def -> The QCLevel Definition
        'Output: The QCLevel ID of the 
        Dim qcLevelID As Integer = -1 'the QClevel ID retrieved from the database (initialized to -1) -> return value
        'Dim qclDT As Data.DataTable 'the datatable of data to hold the Data series Id retrieved from the database
        Dim sql As String 'the SQL statement to pull the data from the database
        Try
            '1. get the QC Level ID from the database
            sql = "SELECT " & db_fld_QCLQCLevel & " FROM " & db_tbl_QCLevels & " WHERE (" & db_fld_QCLCode & " = " & "'" & qclevel_Code & "'" & " AND " & db_fld_QCLDefinition & " = " & "'" & qclevel_Def & "'" & ")"
            qcLevelID = getValue(sql, g_CurrConnSettings)
            'qclDT = OpenTable("GetQCLevelID", sql, g_CurrConnSettings)
            'If (qclDT Is Nothing) OrElse (qclDT.Rows.Count <= 0) Then
            '    'return -1
            '    Exit Try
            'End If

            ''3. make sure have a valid value
            'If Not (qclDT.Rows(0).Item(db_fld_QCLQCLevel) Is DBNull.Value) Then
            '    qcLevelID = qclDT.Rows(0).Item(db_fld_QCLQCLevel)
            'Else
            '    qcLevelID = -1
            'End If

            ''4. release resources
            'If Not (qclDT Is Nothing) Then
            '    qclDT.Dispose()
            '    qclDT = Nothing
            'End If

            '5. return value
            Return qcLevelID
        Catch ex As Exception
            ShowError("An Error occurred while finding the Quality Control Level ID." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        'If Not (qclDT Is Nothing) Then
        '    qclDT.Dispose()
        '    qclDT = Nothing
        'End If
        'return -1
        qcLevelID = -1
        Return qcLevelID
    End Function

#Region "Not Used Code -> value found in Series Catalog table"
    'Public Function GetQCLevelCodeFromDB(ByVal qclevelID As Integer) As String
    '	'Retrieves the ID for a specific quality control level
    '	'Input: qclevelID -> The QCLevel ID to retrieve the Code for 
    '	'Output: The Code for the given QCLevel ID 
    '	Dim qcLevel_Code As String = ""	'the qcLevel Code retrieved from the database (initialized to -1) -> return value
    '	Dim qclCodeDT As Data.DataTable	'the datatable of data to hold the Data series Id retrieved from the database
    '	Dim sql As String 'the SQL statement to pull the data from the database
    '	Try
    '		'1. get the QC Level ID from the database
    '		sql = "SELECT " & db_fld_QCLCode & " FROM " & db_tbl_QCLevels & " WHERE (" & db_fld_QCLQCLevel & " = " & qclevelID & ")"
    '		qclCodeDT = OpenTable("GetQCLevelCode", sql, g_CurrConnSettings)
    '		If (qclCodeDT Is Nothing) OrElse (qclCodeDT.Rows.Count <= 0) Then
    '			'return Nothing
    '			Exit Try
    '		End If

    '		'3. make sure have a valid value
    '		If Not (qclCodeDT.Rows(0).Item(db_fld_QCLCode) Is DBNull.Value) Then
    '			qcLevel_Code = qclCodeDT.Rows(0).Item(db_fld_QCLCode)
    '		Else
    '			qcLevel_Code = Nothing
    '		End If

    '		'4. release resources
    '		If Not (qclCodeDT Is Nothing) Then
    '			qclCodeDT.Dispose()
    '			qclCodeDT = Nothing
    '		End If

    '		'5. return value
    '		Return qcLevel_Code
    '	Catch ex As Exception
    '		ShowError("An Error occurred while finding the Quality Control Level Code." & vbCrLf & "Message = " & ex.Message, ex)
    '	End Try
    '	'release resources
    '	If Not (qclCodeDT Is Nothing) Then
    '		qclCodeDT.Dispose()
    '		qclCodeDT = Nothing
    '	End If
    '	'return Nothing
    '	qcLevel_Code = Nothing
    '	Return qcLevel_Code
    'End Function

#End Region

    Public Function GetQCLevelDefinitionFromDB(ByVal qclevelID As Integer) As String
        'Retrieves the ID for a specific quality control level
        'Input: qclevelID -> The QCLevel ID to retrieve the Definition for 
        'Output: The Definition for the given QCLevel ID 
        Dim qcLevel_Def As String = ""  'the qcLevel Definition retrieved from the database -> return value
        'Dim qclDefDT As Data.DataTable  'the datatable of data to hold the Data series Id retrieved from the database
        Dim sql As String 'the SQL statement to pull the data from the database
        Try
            '1. get the QC Level ID from the database
            sql = "SELECT " & db_fld_QCLDefinition & " FROM " & db_tbl_QCLevels & " WHERE (" & db_fld_QCLQCLevel & " = " & qclevelID & ")"
            qcLevel_Def = getValue(sql, g_CurrConnSettings)
            'qclDefDT = OpenTable("GetQCLevelDefinition", sql, g_CurrConnSettings)
            'If (qclDefDT Is Nothing) OrElse (qclDefDT.Rows.Count <= 0) Then
            '    'return Nothing
            '    Exit Try
            'End If

            ''3. make sure have a valid value
            'If Not (qclDefDT.Rows(0).Item(db_fld_QCLDefinition) Is DBNull.Value) Then
            '    qcLevel_Def = qclDefDT.Rows(0).Item(db_fld_QCLDefinition)
            'Else
            '    qcLevel_Def = Nothing
            'End If

            ''4. release resources
            'If Not (qclDefDT Is Nothing) Then
            '    qclDefDT.Dispose()
            '    qclDefDT = Nothing
            'End If

            '5. return value
            Return qcLevel_Def
        Catch ex As Exception
            ShowError("An Error occurred while finding the Quality Control Level Definition." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        'If Not (qclDefDT Is Nothing) Then
        '    qclDefDT.Dispose()
        '    qclDefDT = Nothing
        'End If
        'return Nothing
        qcLevel_Def = Nothing
        Return qcLevel_Def
    End Function

    Public Function GetVarUnitsFromDB(ByVal varCode As String) As String
        'Returns the Units for the given variable code
        'Inputs:  varCode -> the variable Code for the variable to get the Units for (the Code is unique, so it is all that is needed)
        'Outputs: String -> returns the units for the variable
        Dim varQuery As String  'sql statement used to retrieve the unitsID data from the database
        Dim unitsQuery As String 'sql statement used to retrive the units value from the database
        'Dim varUnitsDT As Data.DataTable 'DataTable to hold the data retrieved from the database
        Dim varUnits As String 'Return value
        Dim varUnitsID As Integer = -1 'used to retrieve the var units from the database
        Try
            '1. get the UnitsID value for the given variable
            varQuery = "SELECT " & db_fld_VarUnitsID & " FROM " & db_tbl_Variables & " WHERE " & db_fld_VarCode & " = '" & FormatStringForQueryFromDB(varCode) & "'"
            varUnitsID = getValue(varQuery, g_CurrConnSettings)
            'varUnitsDT = OpenTable("GetVarUnitsID", varQuery, g_CurrConnSettings)
            'If (varUnitsDT Is Nothing) OrElse (varUnitsDT.Rows.Count = 0) Then
            '    'errors or nothing was returned, return Nothing
            '    Exit Try
            'End If
            ''get the UnitsID value
            'If (varUnitsDT.Rows(0).Item(db_fld_VarUnitsID) Is DBNull.Value) Then
            '    'value = NULL -> return Nothing
            '    varUnitsID = -1
            'Else
            '    varUnitsID = varUnitsDT.Rows(0).Item(db_fld_VarUnitsID)
            'End If

            ''release resources
            'If Not (varUnitsDT Is Nothing) Then
            '    varUnitsDT.Dispose()
            '    varUnitsDT = Nothing
            'End If

            '2. get the units for the UnitsID
            If varUnitsID <= 0 Then
                'exit, return nothing
                Exit Try
            End If
            unitsQuery = "SELECT " & db_fld_UnitsName & " FROM " & db_tbl_Units & " WHERE " & db_fld_UnitsID & " = " & varUnitsID
            varUnits = getValue(unitsQuery, g_CurrConnSettings)
            'varUnitsDT = OpenTable("GetVarUnitsName", unitsQuery, g_CurrConnSettings)
            'If (varUnitsDT Is Nothing) OrElse (varUnitsDT.Rows.Count = 0) Then
            '    'errors or nothing was returned, return false
            '    Exit Try
            'End If
            ''get the UnitsID value
            'If (varUnitsDT.Rows(0).Item(db_fld_UnitsName) Is DBNull.Value) Then
            '    'value = NULL -> return ""
            '    varUnits = ""
            'Else
            '    varUnits = varUnitsDT.Rows(0).Item(db_fld_UnitsName)
            'End If

            'release resources
            'If Not (varUnitsDT Is Nothing) Then
            '    varUnitsDT.Dispose()
            '    varUnitsDT = Nothing
            'End If

            Return varUnits
        Catch ex As Exception
            ShowError("An Error occurred while retrieving the variable Units value for the VariableCode = " & varCode & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        'If Not (varUnitsDT Is Nothing) Then
        '    varUnitsDT.Dispose()
        '    varUnitsDT = Nothing
        'End If
        'errors occurred above, return Nothing
        Return ""
    End Function

    Public Function GetSpeciationFromDB(ByVal varCode As String) As String
        'Returns the Speciation for the given variable code
        'Inputs:  varCode -> the variable Code for the variable to get the Units for (the Code is unique, so it is all that is needed)
        'Outputs: String -> returns the speciation for the variable
        Dim query As String 'sql statement used to retrieve the speciation data from the database
        'Dim speciationDT As Data.DataTable 'DataTable to hold the data retrieved from the database
        Dim speciation As String 'Return value
        Try
            '1. get the speciation value for the given variable
            query = "SELECT " & db_fld_VarSpeciation & " FROM " & db_tbl_Variables & " WHERE " & db_fld_VarCode & " = '" & FormatStringForQueryFromDB(varCode) & "'"
            speciation = getValue(query, g_CurrConnSettings)

            'speciationDT = OpenTable("GetVarSpeciation", query, g_CurrConnSettings)
            'If (speciationDT Is Nothing) OrElse (speciationDT.Rows.Count = 0) Then
            '    'errors or nothing was returned, return Nothing
            '    Exit Try
            'End If
            ''get the UnitsID value
            'If (speciationDT.Rows(0).Item(db_fld_VarSpeciation) Is DBNull.Value) Then
            '    'value = NULL -> return Nothing
            '    speciation = ""
            'Else
            '    speciation = speciationDT.Rows(0).Item(db_fld_VarSpeciation)
            'End If

            ''release resources
            'If Not (speciationDT Is Nothing) Then
            '    speciationDT.Dispose()
            '    speciationDT = Nothing
            'End If

            Return speciation
        Catch ex As Exception
            ShowError("An Error occurred while retrieving the speciation value for the VariableCode = " & varCode & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        'If Not (speciationDT Is Nothing) Then
        '    speciationDT.Dispose()
        '    speciationDT = Nothing
        'End If
        'errors occurred above, return Nothing
        Return ""
    End Function


#End Region

#Region " Create Functions "

    Public Function CreateNewVariableInDB(ByVal varCode As String, ByVal varName As String, ByVal speciation As String, ByVal varUnitsID As Integer, ByVal sampleMed As String, ByVal valueType As String, ByVal timeSupport As Double, ByVal tsUnitsID As Integer, ByVal dataType As String, ByVal genCategory As String, ByVal isRegular As Boolean, ByVal noDataValue As Double) As Integer
        'Creates a new Variable with the selected information
        'Inputs:  varCode -> the variable Code for the Variable to create
        '         varName -> the variable Name for the Variable to create
        '		  speciation -> the speciation for the Variable to create
        '         varUnitsID -> the variable UnitsID for the Variable to create
        '         sampleMed -> the Sample Medium for the Variable to create
        '         valueType -> the valueType for the Variable to create
        '         timeSupport -> the Time Support Value for the Variable to create
        '         tsUnitsID -> the Time Support UnitsID for the Variable to create
        '         dataType -> the Data Type for the Variable to create
        '         genCategory -> the General Category for the Variable to create
        '         isRegular -> the IsRegular Value for the Variable to create
        '         noDataValue -> the NoDataValue for the Varaibel to create
        'Outputs: Integer -> the Variable ID of the created Variable, returns -1 if nothing was created
        Dim varID As Integer = -1 'variable id of the created variable (initialized to -1) -> return value
        Dim query As String 'the SQL query used to get the max Method ID so can create/update the new variable in the database
        Dim varDT As Data.DataTable 'the dataTable used to create/update the new variable in the database
        Dim newRow As Data.DataRow 'the new row added to dataTable -> used to create the new variable
        Dim added As Boolean = False 'tracks if the new variable was successfully added to the database or not
        Dim lastID As Integer = -1 'maximum Variable ID of the Variables currently in the database
        Try
            '1. Connect to Database, get all current records from the Variables table
            query = "SELECT MAX(" & db_fld_VarID & ") as " & db_expr_MaxID & " FROM " & db_tbl_Variables
            'varDT = OpenTable("CreateNewVariable_MaxID", query, g_CurrConnSettings)
            'If (varDT Is Nothing) Then
            '    'table is missing or errors occurred 
            '    'exit, return -1
            '    Exit Try
            'End If

            ''2. Get VariableID for the new row
            'If varDT.Rows.Count = 0 OrElse (varDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
            '    'set it = 0
            '    lastID = 0
            'Else
            '    'set it = VariableID for last row
            '    lastID = varDT.Rows(0).Item(db_expr_MaxID)
            'End If
            lastID = getValue(query, g_CurrConnSettings)

            '**********************************************************************************************************************************************************
            Dim query2 As String = "SELECT * FROM " & db_tbl_Variables & " WHERE " & db_fld_VarID & " = " & lastID + 1 & " ORDER BY " & db_fld_VarID 'the SQL query used to create the new Variable in the database
            varDT = OpenTable("CreateNewVariable", query2, g_CurrConnSettings)

            '3. create a new row
            newRow = varDT.NewRow()
            varID = lastID + 1
            newRow.Item(db_fld_VarID) = varID
            newRow.Item(db_fld_VarCode) = varCode
            newRow.Item(db_fld_VarName) = varName
            newRow.Item(db_fld_VarSpeciation) = speciation
            newRow.Item(db_fld_VarUnitsID) = varUnitsID
            newRow.Item(db_fld_VarSampleMed) = sampleMed
            newRow.Item(db_fld_VarValueType) = valueType
            newRow.Item(db_fld_VarIsRegular) = isRegular
            newRow.Item(db_fld_VarTimeSupport) = timeSupport
            newRow.Item(db_fld_VarTimeUnitsID) = tsUnitsID
            newRow.Item(db_fld_VarDataType) = dataType
            newRow.Item(db_fld_VarGenCat) = genCategory
            newRow.Item(db_fld_VarNoDataVal) = noDataValue

            '4. Add the new row, update the database
            varDT.Rows.Add(newRow)
            added = UpdateTable(varDT, query2, g_CurrConnSettings.ConnectionString)
            'release resources
            If Not (varDT Is Nothing) Then
                varDT.Dispose()
                varDT = Nothing
            End If
            If Not (newRow Is Nothing) Then
                newRow = Nothing
            End If

            '4. Get the MethodID just created
            If Not (added) Then
                'reset varID,return -1
                varID = -1
            End If

            'return value set
            Return varID
        Catch ex As Exception
            ShowError("An Error occurred while creating a new Variable in the Database." & vbCrLf & "Message = " & ex.Message, ex)
            'release resources
            If Not (varDT Is Nothing) Then
                varDT.Dispose()
                varDT = Nothing
            End If
            If Not (newRow Is Nothing) Then
                newRow = Nothing
            End If
            'reset varID, return -1
            varID = -1
        End Try
        'errors occurred above, return what was set previously
        Return varID
    End Function

    Public Function CreateNewMethodInDB(ByVal methodDesc As String) As Integer
        'Creates a new method with the given method description
        'Inputs:  methodDesc -> the method description of the new method to create
        'Outputs: Integer -> the MethodID for the newly created method, return -1 if nothing was created
        Dim methodID As Integer = -1 'the ID for the created method (initialized to -1) -> return value
        Dim query As String 'sql query to get the max MethodID from the Database, and also to create new method
        Dim methodDT As Data.DataTable 'the datatable of data to get the max MethodID from the database
        Dim newRow As Data.DataRow 'row used to create the new method
        Dim added As Boolean = False 'tracks if the new method was successfully added or not
        Dim lastID As Integer = -1 'max MethodID found in the database
        Try
            '1. Connect to Database, get all current records from the Methods table
            query = "SELECT MAX(" & db_fld_MethID & ") as " & db_expr_MaxID & " FROM " & db_tbl_Methods
            'methodDT = OpenTable("CreateNewMethod_MaxID", query, g_CurrConnSettings)
            'If (methodDT Is Nothing) Then
            '    'table is missing or errors occurred 
            '    'exit, return -1
            '    Exit Try
            'End If

            ''2. Get MethodID for the new row
            'If methodDT.Rows.Count = 0 OrElse (methodDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
            '    'set it = 0
            '    lastID = 0
            'Else
            '    'set it = MethodID for last row
            '    lastID = methodDT.Rows(0).Item(db_expr_MaxID)
            'End If

            lastID = getValue(query, g_CurrConnSettings)

            '**********************************************************************************************************************************************************
            Dim query2 As String = "SELECT * FROM " & db_tbl_Methods & " WHERE " & db_fld_MethID & " = " & lastID + 1 & " ORDER BY " & db_fld_MethID 'the SQL query used to create the new method in the database
            methodDT = OpenTable("CreateNewMethod", query2, g_CurrConnSettings)

            '3. create a new row
            methodID = lastID + 1
            newRow = methodDT.NewRow()
            newRow.Item(db_fld_MethID) = methodID
            newRow.Item(db_fld_MethDesc) = methodDesc

            '4. Add the new row, update the database
            methodDT.Rows.Add(newRow)
            added = UpdateTable(methodDT, query2, g_CurrConnSettings.ConnectionString)
            '**********************************************************************************************************************************************************

            'release resources
            If Not (methodDT Is Nothing) Then
                methodDT.Dispose()
                methodDT = Nothing
            End If
            If Not (newRow Is Nothing) Then
                newRow = Nothing
            End If

            '4. Get the MethodID just created
            If Not (added) Then
                'reset MethodID, return -1
                methodID = -1
            End If

            'return value set
            Return methodID
        Catch ex As Exception
            ShowError("An Error occurred while creating a new Method in the Database." & vbCrLf & "Message = " & ex.Message, ex)
            'release resources
            If Not (methodDT Is Nothing) Then
                methodDT.Dispose()
                methodDT = Nothing
            End If
            If Not (newRow Is Nothing) Then
                newRow = Nothing
            End If
            'reset MethodID, return -1
            methodID = -1
        End Try
        'errors occurred above, return whatever was set previously
        Return methodID
    End Function

#Region "DerivedFrom Code not being used" 'Stephanie
    'Public Function CreateNewDerivedFromIDInDB(ByVal valID As Integer) As Integer
    '    'Creates a new 'Derived From' ID with the selected ValueID
    '    'Inputs:  valID -> the value ID to create a DerivedFromID for
    '    'Outputs: Integer -> thenew DerivedFromID create, returns -1 if failed
    '    Dim derivedFromID As Integer = -1 'the new DerivedFromID created (initialized to -1)-> return value
    '    Dim query As String 'the SQL query to get the max DerivedFromID from the database
    '    Dim derivedFromDT As Data.DataTable 'the datatable to hold the max DerivedFromID retrieved from the database, and used to create the new ID also
    '    Dim newRow As Data.DataRow 'new row -> used to create the new ID in the datatable
    '    Dim added As Boolean = False 'tracks if the new id was updated to the database successfully or not
    '    Dim lastID As Integer = -1 'max Derived From ID found in the database
    '    Try
    '        '1. Connect to Database, get all current records from the Methods table
    '        query = "SELECT MAX(" & db_fld_DFID & ") as " & db_expr_MaxID & " FROM " & db_tbl_DerivedFrom
    '        derivedFromDT = OpenTable("CreateNewDerivedFromID_MaxID", query, g_CurrConnSettings)
    '        If (derivedFromDT Is Nothing) Then
    '            'table is missing or errors occurred 
    '            'exit, return -1
    '            Exit Try
    '        End If

    '        '2. Get MethodID for the new row
    '        If derivedFromDT.Rows.Count = 0 OrElse (derivedFromDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
    '            'set it = 0
    '            lastID = 0
    '        Else
    '            'set it = MethodID for last row
    '            lastID = derivedFromDT.Rows(0).Item(db_expr_MaxID)
    '        End If

    '        '**********************************************************************************************************************************************************
    '        Dim query2 As String = "SELECT * FROM " & db_tbl_DerivedFrom & " WHERE " & db_fld_DFID & " = " & lastID + 1 & " ORDER BY " & db_fld_DFID 'the SQL Query used to get the data from the database so create the new DerivedFrom value
    '        derivedFromDT = OpenTable("CreateNewDerivedFromID", query2, g_CurrConnSettings)

    '        '3. create a new row
    '        newRow = derivedFromDT.NewRow()
    '        derivedFromID = lastID + 1
    '        newRow.Item(db_fld_DFID) = derivedFromID
    '        newRow.Item(db_fld_DFValueID) = valID

    '        '4. Add the new row, update the database
    '        derivedFromDT.Rows.Add(newRow)
    '        added = UpdateTable(derivedFromDT, query2, g_CurrConnSettings.ConnectionString)

    '        'release resources
    '        If Not (derivedFromDT Is Nothing) Then
    '            derivedFromDT.Dispose()
    '            derivedFromDT = Nothing
    '        End If
    '        If Not (newRow Is Nothing) Then
    '            newRow = Nothing
    '        End If

    '        '4. Get the MethodID just created
    '        If Not (added) Then
    '            'reset derivedFromID, return -1
    '            derivedFromID = -1
    '        End If

    '        'return value set
    '        Return derivedFromID
    '    Catch ex As Exception
    '        ShowError("An Error occurred while creating a new Derived From ID for ValueID = " & valID & " in the Database." & vbCrLf & "Message = " & ex.Message, ex)
    '        'release resources
    '        If Not (derivedFromDT Is Nothing) Then
    '            derivedFromDT.Dispose()
    '            derivedFromDT = Nothing
    '        End If
    '        If Not (newRow Is Nothing) Then
    '            newRow = Nothing
    '        End If
    '        'reset derivedFromID, return -1
    '        derivedFromID = -1
    '    End Try
    '    'errors occurred above, return whatever was set previously
    '    Return derivedFromID
    'End Function


    'Public Function CreateNewDerivedFromIDInDB(ByVal dataRows As Data.DataRow()) As Integer
    '    'Creates new 'Derived From' IDs with the given ValueIDs
    '    'Inputs:  dataRows() -> the collection of ValueIDs to create the new DerivedFromID for
    '    'Outputs: Integer -> thenew DerivedFromID create, returns -1 if failed
    '    'NOTE: dataRows are in DataValues Table format
    '    Dim derivedFromID As Integer = -1 'the new DerivedFromID created (initialized to -1)-> return value
    '    Dim query As String 'the SQL query to get the max DerivedFromID from the database
    '    Dim derivedFromDT As Data.DataTable 'the datatable to hold the max DerivedFromID retrieved from the database, and used to create the new ID also
    '    Dim newRow As Data.DataRow 'new row -> used to create the new ID in the datatable
    '    Dim added As Boolean = False 'tracks if the new id was updated to the database successfully or not
    '    Dim lastID As Integer = -1 'max Derived From ID found in the database
    '    Dim i As Integer 'counter
    '    Try
    '        '1. Connect to Database, get all current records from the Methods table
    '        query = "SELECT MAX(" & db_fld_DFID & ") as " & db_expr_MaxID & " FROM " & db_tbl_DerivedFrom
    '        derivedFromDT = OpenTable("CreateNewDerivedFromID_MaxID", query, g_CurrConnSettings)
    '        If (derivedFromDT Is Nothing) Then
    '            'table is missing or errors occurred 
    '            'exit, return -1
    '            Exit Try
    '        End If

    '        '2. Get MethodID for the new row
    '        If derivedFromDT.Rows.Count = 0 OrElse (derivedFromDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
    '            'set it = 0
    '            lastID = 0
    '        Else
    '            'set it = MethodID for last row
    '            lastID = derivedFromDT.Rows(0).Item(db_expr_MaxID)
    '        End If

    '        '**********************************************************************************************************************************************************
    '        Dim query2 As String = "SELECT * FROM " & db_tbl_DerivedFrom & " WHERE " & db_fld_DFID & " = " & lastID + 1 & " ORDER BY " & db_fld_DFID 'the SQL query used to create the new rows for the new Derived From ID
    '        derivedFromDT = OpenTable("CreateNewDerivedFrom", query2, g_CurrConnSettings)

    '        '3. create a new row for each ID
    '        derivedFromID = lastID + 1
    '        For i = 0 To dataRows.GetLength(0) - 1
    '            newRow = derivedFromDT.NewRow()
    '            newRow.Item(db_fld_DFID) = derivedFromID 'use the same derivedFromID for all valueIDs
    '            newRow.Item(db_fld_DFValueID) = dataRows(i).Item(db_fld_ValID) 'NOTE: DataRows is in the DataValues table format
    '            'Add the new row
    '            derivedFromDT.Rows.Add(newRow)
    '        Next i

    '        '4. update the database
    '        added = UpdateTable(derivedFromDT, query2, g_CurrConnSettings.ConnectionString)
    '        'release resources
    '        If Not (derivedFromDT Is Nothing) Then
    '            derivedFromDT.Dispose()
    '            derivedFromDT = Nothing
    '        End If
    '        If Not (newRow Is Nothing) Then
    '            newRow = Nothing
    '        End If

    '        '5. Get the DerivedFromID just created
    '        If Not (added) Then
    '            'reset derivedFromID, return -1
    '            derivedFromID = -1
    '        End If

    '        'return value set
    '        Return derivedFromID
    '    Catch ex As Exception
    '        ShowError("An Error occurred while creating a new Derived From ID for a set of ValueIDs in the Database." & vbCrLf & "Message = " & ex.Message, ex)
    '        'release resources
    '        If Not (derivedFromDT Is Nothing) Then
    '            derivedFromDT.Dispose()
    '            derivedFromDT = Nothing
    '        End If
    '        If Not (newRow Is Nothing) Then
    '            newRow = Nothing
    '        End If
    '        'reset derivedFromID, return -1
    '        derivedFromID = -1
    '    End Try
    '    'errors occurred above, return whatever was set previously
    '    Return derivedFromID
    'End Function

#End Region

    Public Function CreateNewQualifierInDB(ByVal qualifierCode As String, ByVal qualifierDesc As String) As Integer
        'Creates a new method with the given method description
        'Inputs:  qualifierCode -> the Code for the new Qualifier to create
        '         qualifierDesc -> the Description for the new Qualifier to create
        'Outputs: Integer -> the QualifierID for the newly created qualifier, returns -1 if failed
        Dim qualifierID As Integer = -1 'the ID for the created qualifier (initialized to -1) -> return value
        Dim query As String 'the SQL query to get the max Qualifier ID from the database
        Dim qualifierDT As Data.DataTable 'the datatable used to get the max Qualifier ID retrieved from the database, and create/update the new one also
        Dim newRow As Data.DataRow 'new dataRow -> used to create the new qualifier
        Dim added As Boolean = False 'tracks if the new qualifier was created or not
        Dim lastID As Integer = -1 'max qualifierID retrieved from the database
        Try
            '1. Connect to Database, get all current records from the Methods table
            query = "SELECT MAX(" & db_fld_QlfyID & ") as " & db_expr_MaxID & " FROM " & db_tbl_Qualifiers
            'qualifierDT = OpenTable("CreateNewQualifier_MaxID", query, g_CurrConnSettings)
            'If (qualifierDT Is Nothing) Then
            '    'table is missing or errors occurred 
            '    'exit, return -1
            '    Exit Try
            'End If

            ''2. Get QualifierID for the new row
            'If qualifierDT.Rows.Count = 0 OrElse (qualifierDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
            '    'set it = 0
            '    lastID = 0
            'Else
            '    'set it = QualifierID for last row
            '    lastID = qualifierDT.Rows(0).Item(db_expr_MaxID)
            'End If
            lastID = getValue(query, g_CurrConnSettings)

            '**********************************************************************************************************************************************************
            Dim query2 As String = "SELECT * FROM " & db_tbl_Qualifiers & " WHERE " & db_fld_QlfyID & " = " & lastID + 1 & " ORDER BY " & db_fld_QlfyID 'the SQL query used to create/update the new Qualifier to the database
            qualifierDT = OpenTable("CreateNewQualifier", query2, g_CurrConnSettings)

            '3. create a new row
            qualifierID = lastID + 1
            newRow = qualifierDT.NewRow()
            newRow.Item(db_fld_QlfyID) = qualifierID
            newRow.Item(db_fld_QlfyCode) = qualifierCode
            newRow.Item(db_fld_QlfyDesc) = qualifierDesc

            '4. Add the new row, update the database
            qualifierDT.Rows.Add(newRow)
            added = UpdateTable(qualifierDT, query2, g_CurrConnSettings.ConnectionString)

            '**********************************************************************************************************************************************************
            'release resources
            If Not (qualifierDT Is Nothing) Then
                qualifierDT.Dispose()
                qualifierDT = Nothing
            End If
            If Not (newRow Is Nothing) Then
                newRow = Nothing
            End If

            '5. Get the MethodID just created
            If Not (added) Then
                'reset MethodID, return -1
                qualifierID = -1
            End If

            'return value set
            Return qualifierID
        Catch ex As Exception
            ShowError("An Error occurred while creating a new Method in the Database." & vbCrLf & "Message = " & ex.Message, ex)
            'release resources
            If Not (qualifierDT Is Nothing) Then
                qualifierDT.Dispose()
                qualifierDT = Nothing
            End If
            If Not (newRow Is Nothing) Then
                newRow = Nothing
            End If
            'reset MethodID, return -1
            qualifierID = -1
        End Try
        'errors occurred above, return whatever was set previously
        Return qualifierID
    End Function

    Public Function CreateNewDataSeriesInDB(ByVal siteID As Integer, ByVal siteCode As String, ByVal siteName As String, ByVal varID As Integer, ByVal varCode As String, ByVal varName As String, ByVal speciation As String, ByVal varUnitsID As Integer, ByVal varUnitsName As String, ByVal sampleMed As String, ByVal valueType As String, ByVal timeSupport As Double, ByVal tsUnitsID As Integer, ByVal tsUnitsName As String, ByVal dataType As String, ByVal genCategory As String, ByVal methodID As Integer, ByVal methodDesc As String, ByVal sourceID As Integer, ByVal sourceDesc As String, ByVal organization As String, ByVal citation As String, ByVal qclevelID As Integer, ByVal qclevelCode As String, ByVal beginDate As DateTime, ByVal endDate As DateTime, ByVal beginDateUTC As DateTime, ByVal endDateUTC As DateTime, ByVal valueCount As Integer) As Integer
        'Creates a new DataSeries with the given information
        'Inputs:  siteID -> the SiteID for the new Data Series to create
        '         siteCode -> the SiteCode for the new Data series to create
        '         siteName -> the Site Name for the new Data series to create
        '         varID -> the Variable ID for the new Data series to create
        '         varCode -> the Variable Code for the new Data series to create
        '         varName -> the Variable Name for the new Data series to create
        '		  speciation -> the Speciation for the new Data series to create
        '         varUnitsID -> the Variable UnitsID for the new Data series to create
        '         varUnitsName -> the Variable Units Name for the new Data series to create
        '         sampleMed -> the Sample Medium for the new Data series to create
        '         valueType -> the Value Type for the new Data series to create
        '         timeSupport -> the Time Support Value for the new Data series to create
        '         tsUnitsID -> the Time Support UnitsID for the new Data series to create
        '         tsUnitsName -> the Time Support Units Name for the new Data series to create
        '         dataType -> the Data Type for the new Data series to create
        '         genCategory -> the General Category for the new Data series to create
        '         methodID -> the Method ID for the new Data series to create
        '         methodDesc -> the Method Description for the new Data series to create
        '         sourceID -> the SourceID for the new Data series to create
        '         sourceDesc -> the Source Description for the new Data series to create
        '         organization -> the Source Organization for the new Data series to create
        '		  citation -> the Source Citation for the new Data series to create
        '         qcLevelID -> the QC Level for the new Data series to create
        '		  qcLevelCode -> the QC Level Code for the new Data series to create
        '         beginDate -> the local Begin DateTime for the new Data series to create
        '         endDate -> the local End DateTime for the new Data series to create
        '         beginDateUTC -> the UTC Begin DateTime for the new Data series to create
        '         endDateUTC -> the UTC End DateTime for the new Data series to create
        '         valueCount -> the Value Count for the new Data series to create
        'Outputs: Integer -> the Series ID for the newly created Data Series, returns -1 if failed
        Dim seriesID As Integer = -1 'the Series ID just create (initialize to -1) -> return value
        Dim query As String 'the sql query to get the max Series ID from the database
        Dim seriesDT As Data.DataTable 'the datatable used to get the max Series ID retrieved from the database, and to create/update the new Data series in the database
        Dim newRow As Data.DataRow 'new DataRow -> used to create the new data series
        Dim added As Boolean = False 'tracks if the new data series was successfully added to the database
        Dim lastID As Integer = -1 'max Series ID retrieved from the database
        Try
            '1. Connect to Database, get all current records from the Series Catalog table
            query = "SELECT MAX(" & db_fld_SCSeriesID & ") as " & db_expr_MaxID & " FROM " & db_tbl_SeriesCatalog
            'seriesDT = OpenTable("CreateNewDataSeries_MaxID", query, g_CurrConnSettings)
            'If (seriesDT Is Nothing) Then
            '    'table is missing or errors occurred 
            '    'exit, return -1
            '    Exit Try
            'End If

            ''2. Get VariableID for the new row
            'If seriesDT.Rows.Count = 0 OrElse (seriesDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
            '    'set it = 0
            '    lastID = 0
            'Else
            '    'set it = VariableID for last row
            '    lastID = seriesDT.Rows(0).Item(db_expr_MaxID)
            'End If
            lastID = getValue(query, g_CurrConnSettings)

            '**********************************************************************************************************************************************************
            Dim query2 As String = "SELECT * FROM " & db_tbl_SeriesCatalog & " WHERE " & db_fld_SCSeriesID & " = " & lastID + 1 & " ORDER BY " & db_fld_SCSeriesID 'the SQL Query used to create/update the New Data series in the database
            seriesDT = OpenTable("CreateNewDataSeries", query2, g_CurrConnSettings)

            '3. create a new row
            newRow = seriesDT.NewRow()
            seriesID = lastID + 1
            newRow.Item(db_fld_SCSeriesID) = seriesID
            newRow.Item(db_fld_SCSiteID) = siteID
            newRow.Item(db_fld_SCSiteCode) = siteCode
            newRow.Item(db_fld_SCSiteName) = siteName
            newRow.Item(db_fld_SCVarID) = varID
            newRow.Item(db_fld_SCVarCode) = varCode
            newRow.Item(db_fld_SCVarName) = varName
            newRow.Item(db_fld_SCSpeciation) = speciation
            newRow.Item(db_fld_SCVarUnitsID) = varUnitsID
            newRow.Item(db_fld_SCVarUnitsName) = varUnitsName
            newRow.Item(db_fld_SCSampleMed) = sampleMed
            newRow.Item(db_fld_SCValueType) = valueType
            newRow.Item(db_fld_SCTimeSupport) = timeSupport
            newRow.Item(db_fld_SCTimeUnitsID) = tsUnitsID
            newRow.Item(db_fld_SCTimeUnitsName) = tsUnitsName
            newRow.Item(db_fld_SCDataType) = dataType
            newRow.Item(db_fld_SCGenCat) = genCategory
            newRow.Item(db_fld_SCMethodID) = methodID
            newRow.Item(db_fld_SCMethodDesc) = methodDesc
            newRow.Item(db_fld_SCSourceID) = sourceID
            newRow.Item(db_fld_SCOrganization) = organization
            newRow.Item(db_fld_SCSourceDesc) = sourceDesc
            newRow.Item(db_fld_SCCitation) = citation
            newRow.Item(db_fld_SCQCLevel) = qclevelID
            newRow.Item(db_fld_SCQCLCode) = qclevelCode
            newRow.Item(db_fld_SCBeginDT) = FormatDateForInsertIntoDB(beginDate)
            newRow.Item(db_fld_SCEndDT) = FormatDateForInsertIntoDB(endDate)
            newRow.Item(db_fld_SCBeginDTUTC) = FormatDateForInsertIntoDB(beginDateUTC)
            newRow.Item(db_fld_SCEndDTUTC) = FormatDateForInsertIntoDB(endDateUTC)
            newRow.Item(db_fld_SCValueCount) = valueCount

            '4. Add the new row, update the database
            seriesDT.Rows.Add(newRow)
            added = UpdateTable(seriesDT, query2, g_CurrConnSettings.ConnectionString)
            'release resources
            If Not (seriesDT Is Nothing) Then
                seriesDT.Dispose()
                seriesDT = Nothing
            End If
            If Not (newRow Is Nothing) Then
                newRow = Nothing
            End If

            '5. Get the seriesID just created
            If Not (added) Then
                'reset seriesID, return -1
                seriesID = -1
            End If

            Return seriesID
        Catch ex As Exception
            ShowError("An Error occurred while creating a new Data Series in the " & db_tbl_SeriesCatalog & " Table in the Database." & vbCrLf & "Message = " & ex.Message, ex)
            'release resources
            If Not (seriesDT Is Nothing) Then
                seriesDT.Dispose()
                seriesDT = Nothing
            End If
            If Not (newRow Is Nothing) Then
                newRow = Nothing
            End If
            'reset seriesID, return -1
            seriesID = -1
        End Try
        Return seriesID
    End Function

#End Region

#Region " Delete Functions "
    Public Function DeleteDataSeries(ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qclevelID As Integer) As Boolean
        'Returns a dataTable of the query data.
        'Inputs:  tablename -> name of the table
        '         SqlQuery -> sql Query to retreive the data with
        '         connString -> the connection String for the database to connect to, to retreive the data from
        'Outputs: the dataTable of data retreived from the database using SqlQuery
        'create a flow table
        Dim sql As String = "DELETE FROM " & db_tbl_DataValues & " WHERE (" & db_fld_ValSiteID & " = " & siteID & ") AND (" & db_fld_ValVarID & " = " & varID & ") AND (" & db_fld_ValMethodID & " = " & methodID & ") AND (" & db_fld_ValSourceID & " = " & sourceID & ") AND (" & db_fld_ValQCLevel & " = " & qclevelID & ")"
        Dim delConn As New OleDb.OleDbConnection(g_CurrConnSettings.ConnectionString)
        Try
            'connect to the Database
            delConn.Open()

            Dim delCommand As New OleDb.OleDbCommand(sql, delConn) 'Command to test the DB with
            delCommand.ExecuteScalar()

            delConn.Close()
            delConn.Dispose()

        Catch ex As Exception
            'If the connection timed out, increment the timeout setting, return the results of another test, else return false
            If ex.Message.Contains("Timeout expired") Then
                If g_CurrConnSettings.IncrementTimeout() Then
                    Return DeleteDataSeries(siteID, varID, methodID, sourceID, qclevelID)
                End If
            ElseIf ex.Message.Contains("SQL Server does not exist") Then
                ShowError("Server Address Incorrect.", ex)
                Return False
            ElseIf ex.Message.Contains("Cannot open database") Then
                ShowError("Database Name Incorrect.", ex)
                Return False
            ElseIf ex.Message.Contains("Login failed for user") Then
                ShowError("Username or Password Incorrect.", ex)
                Return False
            Else
                ShowError(ex.Message, ex)
                Return False
            End If
        End Try
        Return True
    End Function
#End Region

#Region "Update Series Catalog Functions"

    Public Sub UpdateSeriesCatalogAfterEdits(ByVal seriesID As Integer, ByVal beginDate As DateTime, ByVal endDate As DateTime, ByVal beginUTCDate As DateTime, ByVal endUTCDate As DateTime, ByVal valCount As Integer)
        Dim query As String
        Dim upSCDT As DataTable
        Try

            '1. Get the Correct Data Series currently viewing
            query = "SELECT * FROM " & db_tbl_SeriesCatalog & " WHERE " & db_fld_SCSeriesID & " = " & seriesID
            upSCDT = OpenTable("updateSCAfterEdits", query, g_CurrConnSettings)
            'validate data
            If (upSCDT Is Nothing) OrElse upSCDT.Rows.Count = 0 Then
                'no values were retrieved for this series, exit
                Exit Try
            End If

            '2. Update the Dates, UTC Dates,value count
            'Local Dates
            upSCDT.Rows(0).Item(db_fld_SCBeginDT) = beginDate
            upSCDT.Rows(0).Item(db_fld_SCEndDT) = endDate
            'UTC Dates
            upSCDT.Rows(0).Item(db_fld_SCBeginDTUTC) = beginUTCDate
            upSCDT.Rows(0).Item(db_fld_SCEndDTUTC) = endUTCDate
            'Value Count
            upSCDT.Rows(0).Item(db_fld_SCValueCount) = valCount

            '3. Apply to Database
            If Not (UpdateTable(upSCDT, query, g_CurrConnSettings.ConnectionString)) Then

                'exit
                Exit Try
            End If
            '4. release resources
            If Not (upSCDT Is Nothing) Then
                upSCDT.Dispose()
                upSCDT = Nothing
            End If
        Catch ex As Exception
            ShowError("An Error occurred while updating the " & db_tbl_SeriesCatalog & " Table in the Database to reflect the Edits made. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (upSCDT Is Nothing) Then
            upSCDT.Dispose()
            upSCDT = Nothing
        End If
    End Sub

#End Region

End Module
