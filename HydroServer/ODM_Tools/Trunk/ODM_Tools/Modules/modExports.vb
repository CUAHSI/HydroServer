'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Imports System.xml
Imports System.io

Module Exports
    'Last Documented 5/15/07

#Region " Metadata XML Constants "
	'Root of the Metadata Document
	Const xml_meta_Meta_root As String = "Metadata"

	'Metadata >> DataSeriesList element
	Const xml_meta_DSL_root As String = "DataSeriesList"
	Const xml_meta_DSL_attrib_Total As String = "Total"
    Const xml_meta_DSL_DataSeries As String = "DataSeries"  'Child Element

	'DataSeriesList >> DataSeries element
	Const xml_meta_DS_attrib_ID As String = "ID"
    Const xml_meta_DS_Gen As String = "GeneralInformation"  'Child element
    Const xml_meta_DS_Site As String = "SiteInformation"  'Child element
    Const xml_meta_DS_Var As String = "VariableInformation"  'Child element
    Const xml_meta_DS_Method As String = "MethodInformation"  'Child element
    Const xml_meta_DS_Source As String = "SourceInformation"  'Child element
    Const xml_meta_DS_QC As String = "QualityControlLevelInformation"  'Child element
    Const xml_meta_DS_OT As String = "OffsetInformation"  'Child element
    Const xml_meta_DS_Qual As String = "QualifierInformation"  'Child element
    Const xml_meta_DS_Smpl As String = "SampleInformation"  'Child element
    Const xml_meta_DS_LabM As String = "LabMethodInformation"  'Child element

	'DataSeries >> GeneralInformation element
	Const xml_meta_Gen_Topic As String = "TopicCategory"
	Const xml_meta_Gen_Title As String = "Title"
	Const xml_meta_Gen_Abstract As String = "Abstract"
	Const xml_meta_Gen_Profile As String = "ProfileVersion"
	Const xml_meta_Gen_Link As String = "MetadataLink"
	Const xml_meta_Gen_CDate As String = "MetadataCreationDate"

	'DataSeries >> SiteInformation element
	Const xml_meta_Site_Code As String = "SiteCode"
    Const xml_meta_Site_Name As String = "SiteName"
    Const xml_meta_Site_Type As String = "SiteType"
    Const xml_meta_Site_Geo As String = "GeographicCoordinates"  'Child element
    Const xml_meta_Site_Local As String = "LocalCoordinates"  'Child element
	Const xml_meta_Site_State As String = "State"
	Const xml_meta_Site_County As String = "County"
	Const xml_meta_Site_Comments As String = "Comments"

	'SiteInformation >> GeographicCoordinates element
	Const xml_meta_Geo_Lat As String = "Latitude"
	Const xml_meta_Geo_Lon As String = "Longitude"
	Const xml_meta_Geo_SRSID As String = "SRSID"
	Const xml_meta_Geo_SRSName As String = "SRSName"
	Const xml_meta_Geo_IsGeo As String = "IsGeographic"
	Const xml_meta_Geo_Notes As String = "Notes"

	'SiteInformation >> LocalCoordinates element
	Const xml_meta_Local_X As String = "LocalX"
	Const xml_meta_Local_Y As String = "LocalY"
	Const xml_meta_Local_PosAccuracy As String = "PosAccuracy_m"
	Const xml_meta_Local_SRSID As String = "SRSID"
	Const xml_meta_Local_SRSName As String = "SRSName"
	Const xml_meta_Local_IsGeo As String = "IsGeographic"
	Const xml_meta_Local_Notes As String = "Notes"
	Const xml_meta_Local_Elevation As String = "Elevation_m"
	Const xml_meta_Local_Vert As String = "VerticalDatum"

	'DataSeries >> VariableInformation element
	Const xml_meta_Var_Code As String = "VariableCode"
    Const xml_meta_Var_Name As String = "VariableName"
    Const xml_meta_Var_Spec As String = "Speciation"
    Const xml_meta_Var_VarUnits As String = "VariableUnits"  'Child element (UNITS)
	Const xml_meta_Var_SmplMed As String = "SampleMedium"
	Const xml_meta_Var_ValType As String = "ValueType"
	Const xml_meta_Var_IsReg As String = "IsRegular"
	Const xml_meta_Var_TimeSupport As String = "TimeSupport"
    Const xml_meta_Var_TimeUnits As String = "TimeSupportUnits"  'Child Element (UNITS)
	Const xml_meta_Var_DataType As String = "DataType"
	Const xml_meta_Var_GenCat As String = "GeneralCategory"
	Const xml_meta_Var_NoDataVal As String = "NoDataValue"
    Const xml_meta_Var_PerofRec As String = "PeriodOfRecord"  'Child element

	'VariableInformation >> PeriodOfRecord element
	Const xml_meta_PerofRec_BeginDT As String = "BeginDateTime"
	Const xml_meta_PerofRec_EndDT As String = "EndDateTime"
	Const xml_meta_PerofRec_BeginUTC As String = "BeginDateTimeUTC"
	Const xml_meta_PerofRec_EndUTC As String = "EndDateTimeUTC"
	Const xml_meta_PerofRec_ValCount As String = "ValueCount"

	'DataSeries >> MethodInformation
	Const xml_meta_Method_Desc As String = "MethodDescription"
	Const xml_meta_Method_Link As String = "MethodLink"

	'DataSeries >> SourceInformation element
	Const xml_meta_Source_Org As String = "Organization"
	Const xml_meta_Source_Desc As String = "SourceDescription"
	Const xml_meta_Source_Link As String = "SourceLink"
    Const xml_meta_Source_Contact As String = "Contact"  'Child Element
    Const xml_meta_Source_Citation As String = "Citation"

	'SourceInformation >> Contact element
	Const xml_meta_Contact_Name As String = "ContactName"
	Const xml_meta_Contact_Phone As String = "Phone"
	Const xml_meta_Contact_Email As String = "Email"
	Const xml_meta_Contact_Address As String = "Address"
	Const xml_meta_Contact_City As String = "City"
	Const xml_meta_Contact_State As String = "State"
    Const xml_meta_Contact_Zip As String = "ZipCode"

	'DataSeries >> QualityControlInformation
    Const xml_meta_QC_LevelCode As String = "QualityControlLevelCode"
	Const xml_meta_QC_Defin As String = "Definition"
	Const xml_meta_QC_Expln As String = "Explanation"

	'*Units
	Const xml_meta_Units_Name As String = "UnitsName"
	Const xml_meta_Units_Type As String = "UnitsType"
	Const xml_meta_Units_Abbr As String = "UnitsAbbreviation"

	'DataSeries >> OffsetInformation
	Const xml_meta_OT_Title As String = "Offset"
	Const xml_meta_OT_attrib_ID As String = "ID"
	Const xml_meta_OT_Desc As String = "OffsetDescription"
    Const xml_meta_OT_Units As String = "OffsetUnits"  'Child Element (UNITS)

	'DataSeries >> QualifierInformation
	Const xml_meta_Qual_Title As String = "Qualifier"
	Const xml_meta_Qual_attrib_ID As String = "ID"
	Const xml_meta_Qual_Code As String = "QualifierCode"
	Const xml_meta_Qual_Desc As String = "QualifierDescription"

	'DataSeries >> SampleInformation
	Const xml_meta_Smpl_Title As String = "Sample"
	Const xml_meta_Smpl_attrib_ID As String = "ID"
	Const xml_meta_Smpl_Type As String = "SampleType"
	Const xml_meta_Smpl_Code As String = "LabSampleCode"
	Const xml_meta_Smpl_LMID As String = "LabMethodID"

	'DataSeries >> LabMethodInformation
	Const xml_meta_LabM_Title As String = "LabMethod"
	Const xml_meta_LabM_attrib_ID As String = "ID"
	Const xml_meta_LabM_LName As String = "LabName"
	Const xml_meta_LabM_LOrg As String = "LabOrganization"
	Const xml_meta_LabM_LMName As String = "LabMethodName"
	Const xml_meta_LabM_LMDesc As String = "LabMethodDescription"
	Const xml_meta_LabM_LMLink As String = "LabMethodLink"

#End Region

#Region " Create Query Functions "

	Public Function CreateMetadataSeriesQuery(ByVal e_SeriesID As String) As String
        'Creates the Query String used to export the series level metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String = "" 'Used to store the Metadata Series Level Query used to export series level metadata

        'Write the SELECT DISTINCT statement
        sql = "SELECT DISTINCT " & _
         db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID & ", " & _
         db_tbl_ISOMetaData & "." & db_fld_IMDTopicCat & ", " & _
         db_tbl_ISOMetaData & "." & db_fld_IMDTitle & ", " & _
         db_tbl_ISOMetaData & "." & db_fld_IMDAbstract & ", " & _
         db_tbl_ISOMetaData & "." & db_fld_IMDProfileVs & ", " & _
         db_tbl_ISOMetaData & "." & db_fld_IMDMetaLink & ", " & _
         db_tbl_Sites & "." & db_fld_SiteCode & ", " & _
         db_tbl_Sites & "." & db_fld_SiteName & ", "
        If My.Settings.ODMVersion = "1.1.1" Then
            sql &= db_tbl_Sites & "." & db_fld_SiteType & ", "
        End If
            sql &= db_tbl_Sites & "." & db_fld_SiteLat & ", " & _
             db_tbl_Sites & "." & db_fld_SiteLong & ", " & _
             db_expr_Geo & "." & db_fld_SRSRSID & " AS " & db_expr_Geo_SRSID & ", " & _
             db_expr_Geo & "." & db_fld_SRSRSName & " AS " & db_expr_Geo_SRSName & ", " & _
             db_expr_Geo & "." & db_fld_SRIsGeo & " AS " & db_expr_Geo_IsGeo & ", " & _
             db_expr_Geo & "." & db_fld_SRNotes & " AS " & db_expr_Geo_Notes & ", " & _
             db_tbl_Sites & "." & db_fld_SiteVertDatum & ", " & _
             db_tbl_Sites & "." & db_fld_SiteLocX & ", " & _
             db_tbl_Sites & "." & db_fld_SiteLocY & ", " & _
             db_tbl_Sites & "." & db_fld_SiteElev_m & ", " & _
             db_tbl_Sites & "." & db_fld_SitePosAccuracy_m & ", " & _
             db_expr_Local & "." & db_fld_SRSRSID & " AS " & db_expr_Local_SRSID & ", " & _
             db_expr_Local & "." & db_fld_SRSRSName & " AS " & db_expr_Local_SRSName & ", " & _
             db_expr_Local & "." & db_fld_SRIsGeo & " AS " & db_expr_Local_IsGeo & ", " & _
             db_expr_Local & "." & db_fld_SRNotes & " AS " & db_expr_Local_Notes & ", " & _
             db_tbl_Sites & "." & db_fld_SiteState & ", " & _
             db_tbl_Sites & "." & db_fld_SiteCounty & ", " & _
             db_tbl_Sites & "." & db_fld_SiteComments & ", " & _
             db_tbl_Variables & "." & db_fld_VarCode & ", " & _
             db_tbl_Variables & "." & db_fld_VarName & ", " & _
             db_expr_VarUnits & "." & db_fld_UnitsName & " AS " & db_expr_VarUnits_Name & ", " & _
             db_expr_VarUnits & "." & db_fld_UnitsType & " AS " & db_expr_VarUnits_Type & ", " & _
             db_expr_VarUnits & "." & db_fld_UnitsAbrv & " AS " & db_expr_VarUnits_Abbr & ", " & _
             db_tbl_Variables & "." & db_fld_VarTimeSupport & ", " & _
             db_expr_TimeUnits & "." & db_fld_UnitsName & " AS " & db_expr_TimeUnits_Name & ", " & _
             db_expr_TimeUnits & "." & db_fld_UnitsType & " AS " & db_expr_TimeUnits_Type & ", " & _
             db_expr_TimeUnits & "." & db_fld_UnitsAbrv & " AS " & db_expr_TimeUnits_Abbr & ", " & _
             db_tbl_Variables & "." & db_fld_VarSampleMed & ", " & _
             db_tbl_Variables & "." & db_fld_VarValueType & ", " & _
             db_tbl_Variables & "." & db_fld_VarIsRegular & ", " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCBeginDT & ", " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCEndDT & ", " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCBeginDTUTC & ", " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCEndDTUTC & ", " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCValueCount & ", " & _
             db_tbl_Variables & "." & db_fld_VarDataType & ", " & _
             db_tbl_Variables & "." & db_fld_VarSpeciation & ", " & _
             db_tbl_Variables & "." & db_fld_VarGenCat & ", " & _
             db_tbl_Variables & "." & db_fld_VarNoDataVal & ", " & _
             db_tbl_Sources & "." & db_fld_SrcOrg & ", " & _
             db_tbl_Sources & "." & db_fld_SrcDesc & ", " & _
             db_tbl_Sources & "." & db_fld_SrcLink & ", " & _
             db_tbl_Sources & "." & db_fld_SrcContactName & " AS " & db_expr_contact_Name & ", " & _
             db_tbl_Sources & "." & db_fld_SrcPhone & " AS " & db_expr_contact_Phone & ", " & _
             db_tbl_Sources & "." & db_fld_SrcEmail & " AS " & db_expr_contact_Email & ", " & _
             db_tbl_Sources & "." & db_fld_SrcAddress & " AS " & db_expr_contact_Address & ", " & _
             db_tbl_Sources & "." & db_fld_SrcCity & " AS " & db_expr_contact_City & ", " & _
             db_tbl_Sources & "." & db_fld_SrcState & " AS " & db_expr_contact_State & ", " & _
             db_tbl_Sources & "." & db_fld_SrcZip & " AS " & db_expr_contact_Zip & ", " & _
             db_tbl_Sources & "." & db_fld_SrcCitation & ", " & _
             db_tbl_OffsetTypes & "." & db_fld_OTDesc & ", " & _
             db_expr_OffsetUnits & "." & db_fld_UnitsName & " AS " & db_expr_OffsetUnits_Name & ", " & _
             db_expr_OffsetUnits & "." & db_fld_UnitsType & " AS " & db_expr_OffsetUnits_Type & ", " & _
             db_expr_OffsetUnits & "." & db_fld_UnitsAbrv & " AS " & db_expr_OffsetUnits_Abbr & ", " & _
             db_tbl_Methods & "." & db_fld_MethDesc & ", " & _
             db_tbl_Methods & "." & db_fld_MethLink & ", " & _
             db_tbl_QCLevels & "." & db_fld_QCLQCLevel & ", " & _
             db_tbl_QCLevels & "." & db_fld_QCLCode & ", " & _
             db_tbl_QCLevels & "." & db_fld_QCLDefinition & ", " & _
             db_tbl_QCLevels & "." & db_fld_QCLExplanation

            'FROM statement
            sql = sql & " FROM " & _
                db_tbl_SeriesCatalog & " LEFT OUTER JOIN " & _
                db_tbl_Sites & " ON " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCSiteID & " = " & _
                db_tbl_Sites & "." & db_fld_SiteID & " LEFT OUTER JOIN " & _
                db_tbl_SpatialRefs & " AS " & db_expr_Geo & " ON " & _
                db_expr_Geo & "." & db_fld_SRID & " = " & _
                db_tbl_Sites & "." & db_fld_SiteLatLongDatumID & " LEFT OUTER JOIN " & _
                db_tbl_SpatialRefs & " AS " & db_expr_Local & " ON " & _
                db_expr_Local & "." & db_fld_SRID & " = " & _
                db_tbl_Sites & "." & db_fld_SiteLocProjID & " LEFT OUTER JOIN " & _
                db_tbl_Variables & " ON " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCVarID & " = " & _
                db_tbl_Variables & "." & db_fld_VarID & " LEFT OUTER JOIN " & _
                db_tbl_Units & " AS " & db_expr_VarUnits & " ON " & _
                db_expr_VarUnits & "." & db_fld_UnitsID & " = " & _
                db_tbl_Variables & "." & db_fld_VarUnitsID & " LEFT OUTER JOIN " & _
                db_tbl_Units & " AS " & db_expr_TimeUnits & " ON " & _
                db_tbl_Variables & "." & db_fld_VarTimeUnitsID & " = " & _
                db_expr_TimeUnits & "." & db_fld_UnitsID & " LEFT OUTER JOIN " & _
                db_tbl_QCLevels & " ON " & _
                db_tbl_QCLevels & "." & db_fld_QCLQCLevel & " = " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel & " LEFT OUTER JOIN " & _
                db_tbl_Methods & " ON " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCMethodID & " = " & _
                db_tbl_Methods & "." & db_fld_MethID & " LEFT OUTER JOIN " & _
                db_tbl_Sources & " ON " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCSourceID & " = " & _
                db_tbl_Sources & "." & db_fld_SrcID & " LEFT OUTER JOIN " & _
                db_tbl_ISOMetaData & " ON " & _
                db_tbl_ISOMetaData & "." & db_fld_IMDMetaID & " = " & _
                db_tbl_Sources & "." & db_fld_SrcMetaID & " LEFT OUTER JOIN " & _
                db_tbl_DataValues & " ON " & _
                db_tbl_DataValues & "." & db_fld_ValSiteID & " = " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCSiteID & " AND " & _
                db_tbl_DataValues & "." & db_fld_ValVarID & " = " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCVarID & " AND " & _
                db_tbl_DataValues & "." & db_fld_ValMethodID & " = " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCMethodID & " AND " & _
                db_tbl_DataValues & "." & db_fld_ValSourceID & " = " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCSourceID & " AND " & _
                db_tbl_DataValues & "." & db_fld_ValQCLevel & " = " & _
                db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel & " LEFT OUTER JOIN " & _
                db_tbl_OffsetTypes & " ON " & _
                db_tbl_OffsetTypes & "." & db_fld_OTID & " = " & _
                db_tbl_DataValues & "." & db_fld_ValOffsetTypeID & " LEFT OUTER JOIN " & _
                db_tbl_Units & " AS " & db_expr_OffsetUnits & " ON " & _
                db_expr_OffsetUnits & "." & db_fld_UnitsID & " = " & _
                db_tbl_OffsetTypes & "." & db_fld_OTUnitsID

            'Write the WHERE statement
            sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID & " = " & e_SeriesID & ") "

            Return sql
    End Function

	Public Function CreateMetadataOffsetQuery(ByVal e_SeriesID As String) As String
        'Creates the Query String used to export the offset metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Metadata Offset Query used to export offset metadata

        'The SELECT DISTINCT statement
        sql = sql & "SELECT DISTINCT " & _
         db_tbl_OffsetTypes & "." & db_fld_OTID & ", " & _
         db_tbl_OffsetTypes & "." & db_fld_OTDesc & ", " & _
         db_tbl_Units & "." & db_fld_UnitsName & ", " & _
         db_tbl_Units & "." & db_fld_UnitsType & ", " & _
         db_tbl_Units & "." & db_fld_UnitsAbrv

        sql = sql & " FROM " & _
            db_tbl_SeriesCatalog & " LEFT OUTER JOIN " & _
            db_tbl_DataValues & " ON " & _
            db_tbl_DataValues & "." & db_fld_ValSiteID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCSiteID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValVarID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCVarID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValMethodID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCMethodID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValSourceID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCSourceID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValQCLevel & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel & " LEFT OUTER JOIN " & _
            db_tbl_OffsetTypes & " ON " & _
            db_tbl_DataValues & "." & db_fld_ValOffsetTypeID & " = " & _
            db_tbl_OffsetTypes & "." & db_fld_OTID & " LEFT OUTER JOIN " & _
            db_tbl_Units & " ON " & _
            db_tbl_OffsetTypes & "." & db_fld_OTUnitsID & " = " & _
            db_tbl_Units & "." & db_fld_UnitsID

        'The WHERE statement
        sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID & " = " & e_SeriesID & ") "

        'The ORDER BY statement
        sql = sql & " ORDER BY " & _
         db_tbl_OffsetTypes & "." & db_fld_OTID

        Return sql
    End Function

	Public Function CreateMetadataQualifierQuery(ByVal e_SeriesID As String) As String
        'Creates the Query String used to export the Qualifier metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Metadata Qualifier Query used to export qualifier metadata

        'The SELECT DISTINCT statement
        sql = sql & "SELECT DISTINCT " & _
         db_tbl_Qualifiers & "." & db_fld_QlfyID & ", " & _
         db_tbl_Qualifiers & "." & db_fld_QlfyCode & ", " & _
         db_tbl_Qualifiers & "." & db_fld_QlfyDesc

        'The FROM statement
        sql = sql & " FROM " & _
            db_tbl_SeriesCatalog & " LEFT OUTER JOIN " & _
            db_tbl_DataValues & " ON " & _
            db_tbl_DataValues & "." & db_fld_ValSiteID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCSiteID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValVarID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCVarID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValMethodID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCMethodID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValSourceID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCSourceID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValQCLevel & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel & " LEFT OUTER JOIN " & _
            db_tbl_Qualifiers & " ON " & _
            db_tbl_Qualifiers & "." & db_fld_QlfyID & " = " & _
            db_tbl_DataValues & "." & db_fld_ValQualifierID

        'The WHERE statement
        sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID & " = " & e_SeriesID & ") "

        'The ORDER BY statement
        sql = sql & " ORDER BY " & _
         db_tbl_Qualifiers & "." & db_fld_QlfyID

        Return sql
    End Function

	Public Function CreateMetadataSampleQuery(ByVal e_SeriesID As String) As String
        'Creates the Query String used to export the qualifier metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Metadata Sample Query used to export Sample metadata
        'FROM         Samples RIGHT OUTER JOIN
        '                      DataValues ON Samples.SampleID = DataValues.SampleID RIGHT OUTER JOIN
        '                      SeriesCatalog ON DataValues.SiteID = SeriesCatalog.SiteID AND DataValues.VariableID = SeriesCatalog.VariableID AND 
        '                      DataValues.MethodID = SeriesCatalog.MethodID AND DataValues.SourceID = SeriesCatalog.SourceID AND 
        '                      DataValues.QualityControlLevelID = SeriesCatalog.QualityControlLevelID
        'WHERE     (SeriesCatalog.SeriesID = 107)
        'ORDER BY Samples.SampleID
        'The SELECT DISTINCT statement
        sql = sql & "SELECT DISTINCT " & _
         db_tbl_Samples & "." & db_fld_SampleID & ", " & _
         db_tbl_Samples & "." & db_fld_SampleType & ", " & _
         db_tbl_Samples & "." & db_fld_SampleLabCode & ", " & _
         db_tbl_Samples & "." & db_fld_SampleMethodID

        'The FROM statement
        sql = sql & " FROM " & _
            db_tbl_SeriesCatalog & " LEFT OUTER JOIN " & _
            db_tbl_DataValues & " ON " & _
            db_tbl_DataValues & "." & db_fld_ValSiteID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCSiteID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValVarID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCVarID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValMethodID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCMethodID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValSourceID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCSourceID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValQCLevel & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel & " LEFT OUTER JOIN " & _
            db_tbl_Samples & " ON " & _
            db_tbl_Samples & "." & db_fld_SampleID & " = " & _
            db_tbl_DataValues & "." & db_fld_ValSampleID

        'The WHERE statement
        sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID & " = " & e_SeriesID & ") "

        'The ORDER BY statement
        sql = sql & " ORDER BY " & _
         db_tbl_Samples & "." & db_fld_SampleID

        Return sql
    End Function

	Public Function CreateMetadataLabMethodQuery(ByVal e_SeriesID As String) As String
        'Creates the Query String used to export the offset metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Metadata Lab Method Query used to export LabMethod metadata

        'The SELECT DISTINCT statement
        sql = sql & "SELECT DISTINCT " & _
         db_tbl_LabMethods & "." & db_fld_LMID & ", " & _
         db_tbl_LabMethods & "." & db_fld_LMLabName & ", " & _
         db_tbl_LabMethods & "." & db_fld_LMLabOrg & ", " & _
         db_tbl_LabMethods & "." & db_fld_LMName & ", " & _
         db_tbl_LabMethods & "." & db_fld_LMDesc & ", " & _
         db_tbl_LabMethods & "." & db_fld_LMLink

        'The FROM statement
        sql = sql & " FROM " & _
            db_tbl_SeriesCatalog & " LEFT OUTER JOIN " & _
            db_tbl_DataValues & " ON " & _
            db_tbl_DataValues & "." & db_fld_ValSiteID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCSiteID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValVarID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCVarID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValMethodID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCMethodID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValSourceID & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCSourceID & " AND " & _
            db_tbl_DataValues & "." & db_fld_ValQCLevel & " = " & _
            db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel & " LEFT OUTER JOIN " & _
            db_tbl_Samples & " ON " & _
            db_tbl_Samples & "." & db_fld_SampleID & " = " & _
            db_tbl_DataValues & "." & db_fld_ValSampleID & " LEFT OUTER JOIN " & _
            db_tbl_LabMethods & " ON " & _
            db_tbl_Samples & "." & db_fld_SampleMethodID & " = " & _
            db_tbl_LabMethods & "." & db_fld_LMID

        'The WHERE statement
        sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID & " = " & e_SeriesID & ") "

        'The ORDER BY statement
        sql = sql & " ORDER BY " & _
         db_tbl_LabMethods & "." & db_fld_LMID

        Return sql
    End Function

	Public Function CreateExportQuery(ByVal e_SeriesID() As Integer) As String
        'Creates the Query String used to export the selected data series
        'Inputs:  Input an array of integers containing the seriesIDs of the data series to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Data Export Query used to export multiple data series
        Dim i As Integer 'Counter Variable

        'CORE Select Statement
        sql = "SELECT " & _
         db_tbl_DataValues & "." & db_fld_ValID & ", " & _
         db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID & ", " & _
         db_tbl_DataValues & "." & db_fld_ValValue & ", " & _
         db_tbl_DataValues & "." & db_fld_ValAccuracyStdDev & ", " & _
         db_tbl_DataValues & "." & db_fld_ValDateTime & ", " & _
         db_tbl_DataValues & "." & db_fld_ValOffsetValue & ", " & _
         db_tbl_DataValues & "." & db_fld_ValOffsetTypeID & ", " & _
         db_tbl_DataValues & "." & db_fld_ValCensorCode & ", " & _
         db_tbl_DataValues & "." & db_fld_ValQualifierID & ", " & _
         db_tbl_Sites & "." & db_fld_SiteCode & ", " & _
         db_tbl_Variables & "." & db_fld_VarCode & ", " & _
         db_tbl_DataValues & "." & db_fld_ValSampleID

        'Include the Time information
        If g_CurrOptions.ExportTime Then
            sql = sql & ", " & _
             db_tbl_DataValues & "." & db_fld_ValUTCDateTime & ", " & _
             db_tbl_DataValues & "." & db_fld_ValUTCOffset
        End If

        'Include the Site information
        If g_CurrOptions.ExportSite Then
            sql = sql & ", " & _
             db_tbl_Sites & "." & db_fld_SiteName & ", "
            If My.Settings.ODMVersion = "1.1.1" Then
                sql &= db_tbl_Sites & "." & db_fld_SiteType & ", "
            End If
                sql = sql & db_tbl_Sites & "." & db_fld_SiteLat & ", " & _
             db_tbl_Sites & "." & db_fld_SiteLong & ", " & _
             db_tbl_SpatialRefs & "." & db_fld_SRSRSName
        End If

        'Include the Variable information
        If g_CurrOptions.ExportVariable Then
            sql = sql & ", " & _
             db_tbl_Variables & "." & db_fld_VarName & ", " & _
             db_expr_VarUnits & "." & db_fld_UnitsName & " AS " & db_expr_VarUnits_Name & ", " & _
             db_expr_VarUnits & "." & db_fld_UnitsAbrv & " AS " & db_expr_VarUnits_Abbr & ", " & _
             db_tbl_Variables & "." & db_fld_VarSampleMed & ", " & _
             db_tbl_Variables & "." & db_fld_VarSpeciation
        End If

        'Include the Qualifier information
        If g_CurrOptions.ExportQualifier Then
            sql = sql & ", " & _
             db_tbl_Qualifiers & "." & db_fld_QlfyCode & ", " & _
             db_tbl_Qualifiers & "." & db_fld_QlfyDesc
        End If

        'Include the Offset information
        If g_CurrOptions.ExportOffset Then
            sql = sql & ", " & _
             db_tbl_OffsetTypes & "." & db_fld_OTDesc & ", " & _
             db_expr_OffsetUnits & "." & db_fld_UnitsName & " AS " & db_expr_OffsetUnits_Name
        End If

        'Include the Source information
        If g_CurrOptions.ExportSource Then
            sql = sql & ", " & _
             db_tbl_Sources & "." & db_fld_SrcOrg & ", " & _
             db_tbl_Sources & "." & db_fld_SrcDesc & ", " & _
             db_tbl_Sources & "." & db_fld_SrcCitation
        End If

        If g_CurrOptions.ExportQualityControlLevels Then
            sql = sql & ", " & _
                db_tbl_QCLevels & "." & db_fld_QCLCode & ", " & _
                db_tbl_QCLevels & "." & db_fld_QCLDefinition & ", " & _
                db_tbl_QCLevels & "." & db_fld_QCLExplanation
        End If

        'CORE From Statement
        sql = sql & " FROM " & _
         db_tbl_DataValues & " RIGHT OUTER JOIN " & _
         db_tbl_SeriesCatalog & " ON " & _
         db_tbl_DataValues & "." & db_fld_ValSourceID & " = " & _
         db_tbl_SeriesCatalog & "." & db_fld_SCSourceID & " AND " & _
         db_tbl_DataValues & "." & db_fld_ValMethodID & " = " & _
         db_tbl_SeriesCatalog & "." & db_fld_SCMethodID & " AND " & _
         db_tbl_DataValues & "." & db_fld_ValQCLevel & " = " & _
         db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel & " AND " & _
         db_tbl_DataValues & "." & db_fld_ValSiteID & " = " & _
         db_tbl_SeriesCatalog & "." & db_fld_SCSiteID & " AND " & _
         db_tbl_DataValues & "." & db_fld_ValVarID & " = " & _
         db_tbl_SeriesCatalog & "." & db_fld_SCVarID & " LEFT OUTER JOIN " & _
         db_tbl_Samples & " ON " & _
         db_tbl_DataValues & "." & db_fld_ValSampleID & " = " & _
         db_tbl_Samples & "." & db_fld_SampleID & " LEFT OUTER JOIN " & _
         db_tbl_Sites & " ON " & _
         db_tbl_Sites & "." & db_fld_SiteID & " = " & _
         db_tbl_DataValues & "." & db_fld_ValSiteID & " LEFT OUTER JOIN " & _
         db_tbl_Variables & " ON " & _
         db_tbl_Variables & "." & db_fld_VarID & " = " & _
         db_tbl_DataValues & "." & db_fld_ValVarID

        'Include the Site information
        If g_CurrOptions.ExportSite Then
            sql = sql & " LEFT Outer Join " & _
             db_tbl_SpatialRefs & " ON " & _
             db_tbl_SpatialRefs & "." & db_fld_SRID & " = " & _
             db_tbl_Sites & "." & db_fld_SiteLatLongDatumID
        End If

        'Include the Variable information
        If g_CurrOptions.ExportVariable Then
            sql = sql & " LEFT Outer Join " & _
             db_tbl_Units & " AS " & db_expr_VarUnits & " ON " & _
             db_expr_VarUnits & "." & db_fld_UnitsID & " = " & _
             db_tbl_Variables & "." & db_fld_VarUnitsID
        End If

        'Include the Qualifier information
        If g_CurrOptions.ExportQualifier Then
            sql = sql & " LEFT OUTER JOIN " & _
             db_tbl_Qualifiers & " ON " & _
             db_tbl_Qualifiers & "." & db_fld_QlfyID & " = " & _
             db_tbl_DataValues & "." & db_fld_ValQualifierID
        End If

        'Include the Offset information
        If g_CurrOptions.ExportOffset Then
            sql = sql & " LEFT OUTER JOIN " & _
             db_tbl_OffsetTypes & " ON " & _
             db_tbl_OffsetTypes & "." & db_fld_OTID & " = " & _
             db_tbl_DataValues & "." & db_fld_ValOffsetTypeID & " LEFT Outer Join " & _
             db_tbl_Units & " AS " & db_expr_OffsetUnits & " ON " & _
             db_expr_OffsetUnits & "." & db_fld_UnitsID & " = " & _
             db_tbl_OffsetTypes & "." & db_fld_OTUnitsID
        End If

        'Include the Source information
        If g_CurrOptions.ExportSource Then
            sql = sql & " LEFT OUTER JOIN " & _
             db_tbl_Sources & " ON " & _
             db_tbl_Sources & "." & db_fld_SrcID & " = " & _
             db_tbl_DataValues & "." & db_fld_ValSourceID
        End If

        'Include the Quality Control Level
        If g_CurrOptions.ExportQualityControlLevels Then
            sql = sql & " LEFT OUTER JOIN " & _
                db_tbl_QCLevels & " ON " & _
                db_tbl_QCLevels & "." & db_fld_QCLQCLevel & " = " & _
                db_tbl_DataValues & "." & db_fld_ValQCLevel
        End If

        'Where statement
        sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID & " = " & e_SeriesID(0) & ") "
        If e_SeriesID.Length > 1 Then
            For i = 1 To e_SeriesID.Length - 1
                'Write each element of the Where statement
                sql = sql & "OR (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID & " = " & e_SeriesID(i) & ") "
            Next
        End If
        'Write the Order By statement
        sql = sql & "ORDER BY " & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesID


        'Return the SQL Query String
        Return sql
        Return Nothing
    End Function

#End Region

#Region " Export Data from DB "

    Public Function WriteMetadata(ByVal e_FileName As String, ByVal e_SeriesID() As Integer, ByVal keepOld As Boolean) As Boolean
        'Writes the selected series' metadata to the seleced xml file, preserving any previous data
        'Input: e_filename -> The path and name of the file to save
        '       e_seriesID() -> An array containing the series ids to query for
        'Output: Returns true if successful.
        '        Creates an XML document at the selected location

        'If the file does not exist or if it is not a readonly file -> continue
        If (Not (System.IO.File.Exists(e_FileName))) OrElse (Not (New System.IO.FileInfo(e_FileName).Attributes = IO.FileAttributes.ReadOnly)) Then
            Dim series, value As System.Data.DataTable  'Holds the data retrieved from the Database query
            Dim oldData As XmlElement = Nothing 'Holds the existing xml data
            Dim attachOldData As Boolean 'True if any valid data to store
            Dim numOld As Integer 'The number of existing data series (that have unique series IDs)
            Dim x, y As Integer 'Index Variables
            Dim oldWritten As Integer 'An index variable (counts the number of existing data series added so far)
            Dim writer As XmlTextWriter 'The Text Writer used to create the xml document
            Array.Sort(e_SeriesID) 'Put the series IDs in sequential order
            Try
                'If the file exists - load existing metadata
                If keepOld And System.IO.File.Exists(e_FileName) Then

                    Try
                        Dim oldDoc As New XmlDocument 'The old xml document
                        OldDoc.Load(e_FileName)
                        OldData = OldDoc.DocumentElement.FirstChild
                        'Remove repeated series ids
                        x = 0
                        While x <= OldData.ChildNodes.Count - 1
                            For y = 0 To e_SeriesID.Length - 1
                                If OldData.ChildNodes(x).Attributes(xml_meta_DS_attrib_ID).Value = e_SeriesID(y) Then
                                    OldData.RemoveChild(OldData.ChildNodes(x))
                                    Exit For
                                ElseIf y = e_SeriesID.Length - 1 Then
                                    x += 1
                                End If
                            Next
                        End While
                        'If there are elements left, attach the old data
                        If OldData.ChildNodes.Count > 0 Then
                            AttachOldData = True
                        End If
                    Catch ex As Exception
                        'Unable to read the existing data correctly.  Let user decide whether to keep or discard old data
                        If MsgBox("There was an error loading the old metadata." & vbCrLf & "Would you like to continue and discard all existing metadata?", MsgBoxStyle.OkCancel, "Metadata Save Error") = MsgBoxResult.Ok Then
                            AttachOldData = False
                        Else
                            Exit Function
                        End If
                    End Try
                End If

                If OldData Is Nothing Then
                    NumOld = 0
                Else
                    NumOld = OldData.ChildNodes.Count
                End If

                'Open/Create the file to write
                Writer = New XmlTextWriter(e_FileName, System.Text.Encoding.UTF8)

                'Format the output
                Writer.Formatting = Formatting.Indented
                Writer.Indentation() = 4

                'Create the Document
                Writer.WriteStartDocument()

                'Root of the Metadata Document
                Writer.WriteStartElement(xml_meta_Meta_root)

                'Metadata >> DataSeriesList element
                Writer.WriteStartElement(xml_meta_DSL_root)
                Writer.WriteAttributeString(xml_meta_DSL_attrib_Total, NumOld + e_SeriesID.Length)

                x = 0
                'For each DataSeriesID Write the DataSeries metadata
                While x + OldWritten < (e_SeriesID.Length + NumOld)
                    If x >= e_SeriesID.Length OrElse AttachOldData AndAlso NumOld > OldWritten AndAlso OldData.ChildNodes(OldWritten).Attributes(xml_meta_DS_attrib_ID).Value <= e_SeriesID(x) Then
                        'Attach unique OldData in the correct sequence
                        OldData.ChildNodes(OldWritten).WriteTo(Writer)
                        OldWritten += 1
                    Else

                        series = OpenTable("Series", CreateMetadataSeriesQuery(e_SeriesID(x)), g_CurrConnSettings)

                        writer.WriteStartElement(xml_meta_DSL_DataSeries) 'DataSeriesList >> DataSeries Element

                        If series.Rows.Count > 0 Then
                            writer.WriteAttributeString(xml_meta_DS_attrib_ID, series.Rows(0).Item(db_fld_SCSeriesID).ToString)

                            writer.WriteStartElement(xml_meta_DS_Gen) 'DataSeries >> GeneralInformation Element
                            writer.WriteElementString(xml_meta_Gen_Topic, series.Rows(0).Item(db_fld_IMDTopicCat).ToString)
                            writer.WriteElementString(xml_meta_Gen_Title, series.Rows(0).Item(db_fld_IMDTitle).ToString)
                            writer.WriteElementString(xml_meta_Gen_Abstract, series.Rows(0).Item(db_fld_IMDAbstract).ToString)
                            writer.WriteElementString(xml_meta_Gen_Profile, series.Rows(0).Item(db_fld_IMDProfileVs).ToString)
                            writer.WriteElementString(xml_meta_Gen_Link, series.Rows(0).Item(db_fld_IMDMetaLink).ToString)
                            writer.WriteElementString(xml_meta_Gen_CDate, Now.ToString)
                            writer.WriteEndElement() 'END: DataSeries >> GeneralInformation Element

                            writer.WriteStartElement(xml_meta_DS_Site) 'DataSeries >> SiteInformation Element
                            writer.WriteElementString(xml_meta_Site_Code, series.Rows(0).Item(db_fld_SiteCode).ToString)
                            writer.WriteElementString(xml_meta_Site_Name, series.Rows(0).Item(db_fld_SiteName).ToString)
                            If My.Settings.ODMVersion = "1.1.1" Then
                                writer.WriteElementString(xml_meta_Site_Type, series.Rows(0).Item(db_fld_SiteType).ToString)
                            End If
                            writer.WriteStartElement(xml_meta_Site_Geo) 'SiteInformation >> GeographicCoordinates Element
                            writer.WriteElementString(xml_meta_Geo_Lat, series.Rows(0).Item(db_fld_SiteLat).ToString)
                            writer.WriteElementString(xml_meta_Geo_Lon, series.Rows(0).Item(db_fld_SiteLong).ToString)
                            writer.WriteElementString(xml_meta_Geo_SRSID, series.Rows(0).Item(db_expr_Geo_SRSID).ToString)
                            writer.WriteElementString(xml_meta_Geo_SRSName, series.Rows(0).Item(db_expr_Geo_SRSName).ToString)
                            writer.WriteElementString(xml_meta_Geo_IsGeo, series.Rows(0).Item(db_expr_Geo_IsGeo).ToString)
                            writer.WriteElementString(xml_meta_Geo_Notes, series.Rows(0).Item(db_expr_Geo_Notes).ToString)
                            writer.WriteEndElement() 'END: SiteInformation >> GeographicCoordinates Element

                            writer.WriteStartElement(xml_meta_Site_Local) 'SiteInformation >> GeographicCoordinates Element
                            writer.WriteElementString(xml_meta_Local_X, series.Rows(0).Item(db_fld_SiteLocX).ToString)
                            writer.WriteElementString(xml_meta_Local_Y, series.Rows(0).Item(db_fld_SiteLocY).ToString)
                            writer.WriteElementString(xml_meta_Local_SRSID, series.Rows(0).Item(db_expr_Local_SRSID).ToString)
                            writer.WriteElementString(xml_meta_Local_SRSName, series.Rows(0).Item(db_expr_Local_SRSName).ToString)
                            writer.WriteElementString(xml_meta_Local_IsGeo, series.Rows(0).Item(db_expr_Local_IsGeo).ToString)
                            writer.WriteElementString(xml_meta_Local_Notes, series.Rows(0).Item(db_expr_Local_Notes).ToString)
                            writer.WriteElementString(xml_meta_Local_Elevation, series.Rows(0).Item(db_fld_SiteElev_m).ToString)
                            writer.WriteElementString(xml_meta_Local_Vert, series.Rows(0).Item(db_fld_SiteVertDatum).ToString)
                            writer.WriteEndElement() 'END: SiteInformation >> GeographicCoordinates Element

                            writer.WriteElementString(xml_meta_Local_PosAccuracy, series.Rows(0).Item(db_fld_SitePosAccuracy_m).ToString)
                            writer.WriteElementString(xml_meta_Site_State, series.Rows(0).Item(db_fld_SiteState).ToString)
                            writer.WriteElementString(xml_meta_Site_County, series.Rows(0).Item(db_fld_SiteCounty).ToString)
                            writer.WriteElementString(xml_meta_Site_Comments, series.Rows(0).Item(db_fld_SiteComments).ToString)
                            writer.WriteEndElement() 'END: DataSeries >> SiteInformation Element

                            writer.WriteStartElement(xml_meta_DS_Var) 'DataSeries >> VariableInformation Element
                            writer.WriteElementString(xml_meta_Var_Code, series.Rows(0).Item(db_fld_VarCode).ToString)
                            writer.WriteElementString(xml_meta_Var_Name, series.Rows(0).Item(db_fld_VarName).ToString)
                            writer.WriteElementString(xml_meta_var_Spec, series.Rows(0).Item(db_fld_VarSpeciation).ToString)

                            writer.WriteStartElement(xml_meta_Var_VarUnits) 'VariableInformation >> VariableUnits Element
                            writer.WriteElementString(xml_meta_Units_Name, series.Rows(0).Item(db_expr_VarUnits_Name).ToString)
                            writer.WriteElementString(xml_meta_Units_Type, series.Rows(0).Item(db_expr_VarUnits_Type).ToString)
                            writer.WriteElementString(xml_meta_Units_Abbr, series.Rows(0).Item(db_expr_VarUnits_Abbr).ToString)
                            writer.WriteEndElement() 'END: VariableInformation >> VariableUnits Element

                            writer.WriteElementString(xml_meta_Var_SmplMed, series.Rows(0).Item(db_fld_VarSampleMed).ToString)
                            writer.WriteElementString(xml_meta_Var_ValType, series.Rows(0).Item(db_fld_VarValueType).ToString)
                            writer.WriteElementString(xml_meta_Var_IsReg, series.Rows(0).Item(db_fld_VarIsRegular).ToString)
                            writer.WriteElementString(xml_meta_Var_TimeSupport, series.Rows(0).Item(db_fld_VarTimeSupport).ToString)

                            writer.WriteStartElement(xml_meta_Var_TimeUnits) 'VariableInformation >> TimeSupportUnits Element
                            writer.WriteElementString(xml_meta_Units_Name, series.Rows(0).Item(db_expr_TimeUnits_Name).ToString)
                            writer.WriteElementString(xml_meta_Units_Type, series.Rows(0).Item(db_expr_TimeUnits_Type).ToString)
                            writer.WriteElementString(xml_meta_Units_Abbr, series.Rows(0).Item(db_expr_TimeUnits_Abbr).ToString)
                            writer.WriteEndElement() 'END: VariableInformation >> TimeSupportUnits Element

                            writer.WriteElementString(xml_meta_Var_DataType, series.Rows(0).Item(db_fld_VarDataType).ToString)
                            writer.WriteElementString(xml_meta_Var_GenCat, series.Rows(0).Item(db_fld_VarGenCat).ToString)
                            writer.WriteElementString(xml_meta_Var_NoDataVal, series.Rows(0).Item(db_fld_VarNoDataVal).ToString)

                            writer.WriteStartElement(xml_meta_Var_PerofRec) 'VariableInformation >> PeriodOfRecord Element
                            writer.WriteElementString(xml_meta_PerofRec_BeginDT, series.Rows(0).Item(db_fld_SCBeginDT).ToString)
                            writer.WriteElementString(xml_meta_PerofRec_EndDT, series.Rows(0).Item(db_fld_SCEndDT).ToString)
                            writer.WriteElementString(xml_meta_PerofRec_BeginUTC, series.Rows(0).Item(db_fld_SCBeginDTUTC).ToString)
                            writer.WriteElementString(xml_meta_PerofRec_EndUTC, series.Rows(0).Item(db_fld_SCEndDTUTC).ToString)
                            writer.WriteElementString(xml_meta_PerofRec_ValCount, series.Rows(0).Item(db_fld_SCValueCount).ToString)
                            writer.WriteEndElement() 'END: VariableInformation >> PeriodOfRecord Element

                            writer.WriteEndElement() 'END: DataSeries >> VariableInformation Element

                            writer.WriteStartElement(xml_meta_DS_Method) 'DataSeries >> MethodInformation Element
                            writer.WriteElementString(xml_meta_Method_Desc, series.Rows(0).Item(db_fld_MethDesc).ToString)
                            writer.WriteElementString(xml_meta_Method_Link, series.Rows(0).Item(db_fld_MethLink).ToString)
                            writer.WriteEndElement() 'END: DataSeries >> Method Information Element

                            writer.WriteStartElement(xml_meta_DS_Source) 'DataSeries >> SourceInformation Element
                            writer.WriteElementString(xml_meta_Source_Org, series.Rows(0).Item(db_fld_SrcOrg).ToString)
                            writer.WriteElementString(xml_meta_Source_Desc, series.Rows(0).Item(db_fld_SrcDesc).ToString)
                            writer.WriteElementString(xml_meta_Source_Link, series.Rows(0).Item(db_fld_SrcLink).ToString)

                            writer.WriteStartElement(xml_meta_Source_Contact) 'SourceInformation >> Contact Element
                            writer.WriteElementString(xml_meta_Contact_Name, series.Rows(0).Item(db_expr_contact_Name).ToString)
                            writer.WriteElementString(xml_meta_Contact_Phone, series.Rows(0).Item(db_expr_contact_Phone).ToString)
                            writer.WriteElementString(xml_meta_Contact_Email, series.Rows(0).Item(db_expr_contact_Email).ToString)
                            writer.WriteElementString(xml_meta_Contact_Address, series.Rows(0).Item(db_expr_contact_Address).ToString)
                            writer.WriteElementString(xml_meta_Contact_City, series.Rows(0).Item(db_expr_contact_City).ToString)
                            writer.WriteElementString(xml_meta_Contact_State, series.Rows(0).Item(db_expr_contact_State).ToString)
                            writer.WriteElementString(xml_meta_Contact_Zip, series.Rows(0).Item(db_expr_contact_Zip).ToString)
                            writer.WriteEndElement() 'END: SourceInformation >> Contact Element

                            writer.WriteElementString(xml_meta_source_Citation, series.Rows(0).Item(db_fld_SrcCitation).ToString)
                            writer.WriteEndElement() 'END: DataSeries >> Source Information Element

                            writer.WriteStartElement(xml_meta_DS_QC) 'DataSeries >> QualityControlLevelInformation Element
                            writer.WriteElementString(xml_meta_QC_LevelCode, series.Rows(0).Item(db_fld_QCLCode).ToString)
                            writer.WriteElementString(xml_meta_QC_Defin, series.Rows(0).Item(db_fld_QCLDefinition).ToString)
                            writer.WriteElementString(xml_meta_QC_Expln, series.Rows(0).Item(db_fld_QCLExplanation).ToString)
                            writer.WriteEndElement() 'END: DataSeries >> QualityControlLevelInformation Element

                            writer.WriteStartElement(xml_meta_DS_OT) 'DataSeries >> OffsetInformation Element
                            value = OpenTable("Offsets", CreateMetadataOffsetQuery(e_SeriesID(x)), g_CurrConnSettings)
                            For y = 0 To value.Rows.Count - 1 'Write each set of offset information
                                writer.WriteStartElement(xml_meta_OT_Title) 'OffsetInformation >> Offset Element
                                writer.WriteAttributeString(xml_meta_OT_attrib_ID, value.Rows(y).Item(db_fld_OTID).ToString)
                                writer.WriteElementString(xml_meta_OT_Desc, value.Rows(y).Item(db_fld_OTDesc).ToString)
                                writer.WriteStartElement(xml_meta_OT_Units) 'Offset >> OffsetUnits Element
                                writer.WriteElementString(xml_meta_Units_Name, value.Rows(y).Item(db_fld_UnitsName).ToString)
                                writer.WriteElementString(xml_meta_Units_Type, value.Rows(y).Item(db_fld_UnitsType).ToString)
                                writer.WriteElementString(xml_meta_Units_Abbr, value.Rows(y).Item(db_fld_UnitsAbrv).ToString)
                                writer.WriteEndElement() 'END: Offset >> OffsetUnits Element
                                writer.WriteEndElement() 'END: OffsetInformation >> Offset Element
                            Next
                            writer.WriteEndElement() 'END: DataSeries >> OffsetInformation Element

                            writer.WriteStartElement(xml_meta_DS_Qual) 'DataSeries >> QualifierInformation
                            value = OpenTable("Qualifiers", CreateMetadataQualifierQuery(e_SeriesID(x)), g_CurrConnSettings)
                            For y = 0 To value.Rows.Count - 1 'Write each set of qualifier information
                                writer.WriteStartElement(xml_meta_Qual_Title) 'QualifierInformation >> Qualifier Element
                                writer.WriteAttributeString(xml_meta_Qual_attrib_ID, value.Rows(y).Item(db_fld_QlfyID).ToString)
                                writer.WriteElementString(xml_meta_Qual_Code, value.Rows(y).Item(db_fld_QlfyCode).ToString)
                                writer.WriteElementString(xml_meta_Qual_Desc, value.Rows(y).Item(db_fld_QlfyDesc).ToString)
                                writer.WriteEndElement() 'END: QualifierInformation >> Qualifier Element
                            Next
                            writer.WriteEndElement() 'END: DataSeries >> QualifierInformation Element

                            writer.WriteStartElement(xml_meta_DS_Smpl) 'DataSeries >> SampleInformation Element
                            value = OpenTable("Samples", CreateMetadataSampleQuery(e_SeriesID(x)), g_CurrConnSettings)
                            For y = 0 To value.Rows.Count - 1 'Write each set of sample information
                                writer.WriteStartElement(xml_meta_Smpl_Title) 'SampleInformation >> Sample Element
                                writer.WriteAttributeString(xml_meta_Smpl_attrib_ID, value.Rows(y).Item(db_fld_SampleID).ToString)
                                writer.WriteElementString(xml_meta_Smpl_Type, value.Rows(y).Item(db_fld_SampleType).ToString)
                                writer.WriteElementString(xml_meta_Smpl_Code, value.Rows(y).Item(db_fld_SampleLabCode).ToString)
                                writer.WriteElementString(xml_meta_Smpl_LMID, value.Rows(y).Item(db_fld_SampleMethodID).ToString)
                                writer.WriteEndElement() 'END: SampleInformation >> Sample Element
                            Next
                            writer.WriteEndElement() 'END: DataSeries >> SampleInformation Element

                            writer.WriteStartElement(xml_meta_DS_LabM) 'DataSeries >> LabMethodInformation Element
                            value = OpenTable("LabMethods", CreateMetadataLabMethodQuery(e_SeriesID(x)), g_CurrConnSettings)
                            For y = 0 To value.Rows.Count - 1 'Write each set of lab method information Element
                                writer.WriteStartElement(xml_meta_LabM_Title) 'LabMethodInformation >> LabMethod Element
                                writer.WriteAttributeString(xml_meta_LabM_attrib_ID, value.Rows(y).Item(db_fld_LMID).ToString)
                                writer.WriteElementString(xml_meta_LabM_LName, value.Rows(y).Item(db_fld_LMLabName).ToString)
                                writer.WriteElementString(xml_meta_LabM_LOrg, value.Rows(y).Item(db_fld_LMLabOrg).ToString)
                                writer.WriteElementString(xml_meta_LabM_LMName, value.Rows(y).Item(db_fld_LMName).ToString)
                                writer.WriteElementString(xml_meta_LabM_LMDesc, value.Rows(y).Item(db_fld_LMDesc).ToString)
                                writer.WriteElementString(xml_meta_LabM_LMLink, value.Rows(y).Item(db_fld_LMLink).ToString)
                                writer.WriteEndElement() 'END: LabMethodInformation >> LabMethod Element
                            Next
                            writer.WriteEndElement() 'END: DataSeries >> LabMethodInformation Element
                            writer.WriteEndElement() 'END: DataSeriesList >> DataSeries Element
                        Else
                            writer.WriteElementString("ERROR", "Series Catalog Table doesn't match Values.  Please update Series Catalog Table.")
                            writer.WriteEndElement() 'END: DataSeriesList >> DataSeries Element
                            writer.WriteEndElement() 'END: Metadata >> DataSeriesList Element
                            writer.WriteEndElement() 'END: Root of the Metadata Document
                            writer.Flush()
                            Throw New Exception("Series Catalog Table doesn't match Values.  Please update Series Catalog Table.")
                        End If

                        x += 1
                    End If
                End While

                Writer.WriteEndElement() 'END:   Metadata >> DataSeriesList element
                Writer.WriteEndElement() 'END:   Root of the Metadata Document
                Writer.Flush()
            Catch ex As Exception
                ShowError("Error writing to xml file" & vbCrLf & ex.Message, ex)
                Writer.Close()
                OldData = Nothing
                Series = Nothing
                Value = Nothing
                Return False
            End Try
            'Save and Close the XML document stream
            Writer.Close()
            OldData = Nothing
            Series = Nothing
            Return True
        Else
            ShowError("Unable to write to """ & e_FileName & """.")
            Return False
        End If
    End Function

	Public Function ViewMetadata(ByVal e_SeriesID() As Integer) As Boolean
		'Writes the selected series' metadata to the seleced xml file, preserving any previous data
		'Input: e_seriesID() -> An array containing the series IDs to query for
        'Output: Returns True if sucessful
        '        Opens a browser window containing the selected xml data

        Dim fileName As String 'Temporary filename

		FileName = System.IO.Path.GetTempPath & "Metadata.xml"

		WriteMetadata(FileName, e_SeriesID, False)

		'launch the temporary metadata.xml file
		Try
			Process.Start(FileName)
        Catch ex As Exception
            ShowError("Error viewing Metadata", ex)
            Return False
		End Try

		Return True
	End Function

    Public Function ExportMyDBData(ByVal queryTable As DataTable, ByVal fullFileName As String, ByVal delimiter As String) As Boolean
        'Takes the MyDB QueryTable data and stores it in the selected .csv file
        'Inputs:  QueryTable-> A table containing all the data to export
        '         FullFileName->The filename and path to export to (including extension)
        'Outputs: Returns true if successful
        '         Saves the QueryTable to a comma/tab delimited table

        Dim writer As StreamWriter 'Stream writer used to write the data
        Try
            Dim i As Integer 'counter variable
            Dim splitFile() As String
            splitFile = Split(FullFileName, ".")
            writer = New StreamWriter(FullFileName)

            If File.Exists(FullFileName) Then
                'If using Comma Delimited Format
                'write the headers
                writer.Write(db_fld_SCSeriesID & delimiter)
                writer.Write(db_fld_ValID & delimiter)
                writer.Write(db_fld_ValValue & delimiter)
                writer.Write(db_fld_ValAccuracyStdDev & delimiter)
                writer.Write(db_fld_ValDateTime & delimiter)
                If g_CurrOptions.ExportTime Then 'OPTIONAL
                    writer.Write(db_fld_ValUTCDateTime & delimiter)
                    writer.Write(db_fld_ValUTCOffset & delimiter)
                End If
                writer.Write(db_fld_SiteCode & delimiter)
                If g_CurrOptions.ExportSite Then 'OPTIONAL
                    writer.Write(db_fld_SiteName & delimiter)
                    If My.Settings.ODMVersion = "1.1.1" Then
                        writer.Write(db_fld_SiteType & delimiter)
                    End If
                    writer.Write(db_fld_SiteLat & delimiter)
                    writer.Write(db_fld_SiteLong & delimiter)
                    writer.Write(db_fld_SRSRSName & delimiter)
                End If
                writer.Write(db_fld_VarCode & delimiter)
                If g_CurrOptions.ExportVariable Then 'OPTIONAL
                    writer.Write(db_fld_VarName & delimiter)
                    writer.Write(db_fld_VarSpeciation & delimiter)
                    writer.Write(db_expr_VarUnits_Name & delimiter)
                    writer.Write(db_expr_VarUnits_Abbr & delimiter)
                    writer.Write(db_fld_VarSampleMed & delimiter)
                End If
                writer.Write(db_fld_ValOffsetValue & delimiter)
                writer.Write(db_fld_ValOffsetTypeID & delimiter)
                If g_CurrOptions.ExportOffset Then 'OPTIONAL
                    writer.Write(db_fld_OTDesc & delimiter)
                    writer.Write(db_expr_OffsetUnits_Name & delimiter)
                End If
                writer.Write(db_fld_ValCensorCode & delimiter)
                writer.Write(db_fld_ValQualifierID & delimiter)
                If g_CurrOptions.ExportQualifier Then 'OPTIONAL
                    writer.Write(db_fld_QlfyCode & delimiter)
                    writer.Write(db_fld_QlfyDesc & delimiter)
                End If
                If g_CurrOptions.ExportSource Then 'OPTIONAL
                    writer.Write(db_fld_SrcOrg & delimiter)
                    writer.Write(db_fld_SrcDesc & delimiter)
                    writer.Write(db_fld_SrcCitation & delimiter)
                End If
                If g_CurrOptions.ExportQualityControlLevels Then
                    writer.Write(db_fld_QCLCode & delimiter)
                    writer.Write(db_fld_QCLDefinition & delimiter)
                    writer.Write(db_fld_QCLExplanation & delimiter)
                End If
                writer.Write(db_fld_ValSampleID & vbCrLf)

                For i = 0 To queryTable.Rows.Count - 1
                    'Write each line of data, placing commas in between each value in the same row
                    writer.Write(queryTable.Rows(i).Item(db_fld_SCSeriesID) & delimiter)
                    writer.Write(queryTable.Rows(i).Item(db_fld_ValID) & delimiter)
                    writer.Write(queryTable.Rows(i).Item(db_fld_ValValue) & delimiter)
                    writer.Write(queryTable.Rows(i).Item(db_fld_ValAccuracyStdDev) & delimiter)
                    writer.Write(CDate(queryTable.Rows(i).Item(db_fld_ValDateTime)).ToString & delimiter)
                    If g_CurrOptions.ExportTime Then 'OPTIONAL
                        writer.Write(CDate(queryTable.Rows(i).Item(db_fld_ValUTCDateTime)).ToString & delimiter)
                        writer.Write(queryTable.Rows(i).Item(db_fld_ValUTCOffset) & delimiter)
                    End If
                    writer.Write("""" & queryTable.Rows(i).Item(db_fld_SiteCode) & """" & delimiter)
                    If g_CurrOptions.ExportSite Then 'OPTIONAL
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_SiteName) & """" & delimiter)
                        If My.Settings.ODMVersion = "1.1.1" Then
                            writer.Write("""" & queryTable.Rows(i).Item(db_fld_SiteType) & """" & delimiter)
                        End If
                        writer.Write(queryTable.Rows(i).Item(db_fld_SiteLat) & delimiter)
                        writer.Write(queryTable.Rows(i).Item(db_fld_SiteLong) & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_SRSRSName) & """" & delimiter)
                    End If
                    writer.Write("""" & queryTable.Rows(i).Item(db_fld_VarCode) & """" & delimiter)
                    If g_CurrOptions.ExportVariable Then 'OPTIONAL
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_VarName) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_VarSpeciation) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_expr_VarUnits_Name) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_expr_VarUnits_Abbr) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_VarSampleMed) & """" & delimiter)
                    End If
                    writer.Write(queryTable.Rows(i).Item(db_fld_ValOffsetValue) & delimiter)
                    writer.Write(queryTable.Rows(i).Item(db_fld_ValOffsetTypeID) & delimiter)
                    If g_CurrOptions.ExportOffset Then 'OPTIONAL
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_OTDesc) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_expr_OffsetUnits_Name) & """" & delimiter)
                    End If
                    writer.Write(queryTable.Rows(i).Item(db_fld_ValCensorCode) & delimiter)
                    writer.Write(queryTable.Rows(i).Item(db_fld_ValQualifierID) & delimiter)
                    If g_CurrOptions.ExportQualifier Then 'OPTIONAL
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_QlfyCode) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_QlfyDesc) & """" & delimiter)
                    End If
                    If g_CurrOptions.ExportSource Then 'OPTIONAL
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_SrcOrg) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_SrcDesc) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_SrcCitation) & """" & delimiter)
                    End If
                    If g_CurrOptions.ExportQualityControlLevels Then 'OPTIONAL
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_QCLCode) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_QCLDefinition) & """" & delimiter)
                        writer.Write("""" & queryTable.Rows(i).Item(db_fld_QCLExplanation) & """" & delimiter)
                    End If
                    writer.Write(queryTable.Rows(i).Item(db_fld_ValSampleID) & vbCrLf)
                Next i
            Else
                'StreamWriter did not create the file correctly
                ShowError("File Does Not Exist")
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        writer.Close()
        Return True
    End Function

    Public Function LoadDataList(ByVal tableName As String, ByVal fieldName As String) As String()
        'Loads the available Fields from the selected table
        'Inputs:  TableName -> Name of a table within the DB
        '         FieldNames -> Names of fields within the table
        'Outputs: Values -> String Array 
        Dim sql As String 'the sql-query used to get parameter data from the selected Time Series database
        Dim x As Integer 'counter

        'create the sql query
        sql = "SELECT DISTINCT " & FieldName & " FROM " & TableName & " ORDER BY " & FieldName

        'get the table
        Dim cvTable As DataTable = OpenTable("CV Table", sql, g_CurrConnSettings)  'the datatable that holds the data retreived from the selected database using sql
        'make sure that VariableTable in NOT empty
        If (cvTable Is Nothing) Then Return Nothing

        'add the results to Values
        Dim values(cvTable.Rows.Count - 1) As String
        For x = 0 To cvTable.Rows.Count - 1
            'add the Variable1 name,code to cbVariable1,m_VariableCode1
            If (cvTable.Rows(x).Item(fieldName) Is DBNull.Value) Then
                values(x) = ""
            Else
                values(x) = (cvTable.Rows(x).Item(fieldName))
            End If

        Next

        'release resources
        cvTable.Dispose()
        cvTable = Nothing
        Return values
    End Function

    Public Function LoadDataList(ByVal tableName As String, ByVal fieldNames() As String) As String(,)
        'Loads the available Fields from the selected table
        'Inputs:  TableName -> Name of a table within the DB
        '         FieldNames -> Names of fields within the table
        'Outputs: Values -> String Array
        Dim sql As String 'the sql-query used to get parameter data from the selected Time Series database
        Dim x, y As Integer 'counter
        Try

            'create the sql query
            sql = "SELECT DISTINCT "
            For y = 0 To FieldNames.Length - 1
                If y = FieldNames.Length - 1 Then
                    sql = sql & FieldNames(FieldNames.Length - 1)
                Else
                    sql = sql & FieldNames(y) & ", "
                End If
            Next
            sql = sql & " FROM " & TableName & " ORDER BY "
            For y = 0 To FieldNames.Length - 1
                If y = FieldNames.Length - 1 Then
                    sql = sql & FieldNames(FieldNames.Length - 1)
                Else
                    sql = sql & FieldNames(y) & ", "
                End If
            Next
            'get the table
            Dim cvTable As DataTable = OpenTable(TableName & " Table", sql, g_CurrConnSettings)  'the datatable that holds the data retreived from the selected database using sql
            'make sure that VariableTable in NOT empty
            If (cvTable Is Nothing) Then Return Nothing

            'add the Values to Temp
            Dim values(FieldNames.Length - 1, cvTable.Rows.Count - 1) As String
            For y = 0 To cvTable.Rows.Count - 1
                For x = 0 To FieldNames.Length - 1
                    If (cvTable.Rows(y).Item(FieldNames(x))) Is Nothing Then
                        values(x, y) = ""
                    Else
                        values(x, y) = (cvTable.Rows(y).Item(FieldNames(x)))
                    End If
                Next
            Next

            'release resources
            cvTable.Dispose()
            cvTable = Nothing
            Return values
        Catch ex As System.Exception
            ShowError("Error in LoadDataList()" & vbCrLf & "Message: " & ex.Message, ex)
            Return Nothing
        End Try
    End Function

	Public Function ExportData(ByVal queryString As String, ByVal fileName As String, ByVal exportSeriesID() As Integer, ByVal delimiter As String) As Boolean
        'Gets the data to export and executes ExportMyDB data
        'Inputs:  QueryString -> SQL Query used to get the data
        '         FileName -> Location to save the data
        '         exportSeriesID -> array of integers containing the series ids of the data to export
        '         Delimiter -> Delimiter used to separate values within a row
        'Outputs: returns true if successful

        Dim queryTable As DataTable 'DataTable of data to export

		Try
			'Generate a Query Table for the selected query string
			QueryTable = OpenTable("Export", queryString, g_CurrConnSettings)

			'Export the data
			If ExportMyDBData(QueryTable, fileName, delimiter) Then
				Return True
			Else
				ShowError("Unable to export data")
				Return False
			End If
        Catch ex As Exception
            ShowError("Unable to export data" & vbCrLf & ex.Message, ex)
            Return False
		End Try
		QueryTable = Nothing

		Return False
	End Function

    Public Function ExportMetadata(ByVal e_fileName As String, ByVal e_exportSeriesID() As Integer) As Boolean
        'Gets the data to export and executes ExportMyDB data
        'Inputs:  e_FileName -> Location to save the data
        '         e_exportSeriesID -> array of integers containing the series ids of the data to export
        'Outputs: returns true if successful

        If Not (WriteMetadata(e_fileName, e_exportSeriesID, True)) Then
            ShowError("Unable to export metadata")
            Return False
        End If
        Return True
    End Function

#End Region

End Module
