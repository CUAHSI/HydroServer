Imports DatabaseFunctions
Imports System.Data
Imports System.xml

Public Class ExportFunctions

#Region " Metadata XML Constants "
    'Root of the Metadata Document
    Const xml_meta_Meta_root As String = "Metadata"

    'Metadata >> DataSeriesList element
    Const xml_meta_DSL_root As String = "DataSeriesList"
    Const xml_meta_DSL_attrib_Total As String = "Total"
    Const xml_meta_DSL_DataSeries As String = "DataSeries"  'Child Element

    'DataSeriesList >> DataSeries element
    Const xml_meta_DS_attrib_id As String = "id"
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
    Const xml_meta_Geo_SRSid As String = "SRSid"
    Const xml_meta_Geo_SRSName As String = "SRSName"
    Const xml_meta_Geo_IsGeo As String = "IsGeographic"
    Const xml_meta_Geo_Notes As String = "Notes"

    'SiteInformation >> LocalCoordinates element
    Const xml_meta_Local_X As String = "LocalX"
    Const xml_meta_Local_Y As String = "LocalY"
    Const xml_meta_Local_PosAccuracy As String = "PosAccuracy_m"
    Const xml_meta_Local_SRSid As String = "SRSid"
    Const xml_meta_Local_SRSName As String = "SRSName"
    Const xml_meta_Local_IsGeo As String = "IsGeographic"
    Const xml_meta_Local_Notes As String = "Notes"
    Const xml_meta_Local_Elevation As String = "Elevation_m"
    Const xml_meta_Local_Vert As String = "VerticalDatum"

    'DataSeries >> VariableInformation element
    Const xml_meta_Var_Code As String = "VariableCode"
    Const xml_meta_Var_Name As String = "VariableName"
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

    'SourceInformation >> Contact element
    Const xml_meta_Contact_Name As String = "ContactName"
    Const xml_meta_Contact_Phone As String = "Phone"
    Const xml_meta_Contact_Email As String = "Email"
    Const xml_meta_Contact_Address As String = "Address"
    Const xml_meta_Contact_City As String = "City"
    Const xml_meta_Contact_State As String = "State"
    Const xml_meta_Contact_Zip As String = "ZipCode"

    'DataSeries >> QualityControlInformation
    Const xml_meta_QC_Level As String = "QualityControlLevelid"
    Const xml_meta_QC_Defin As String = "Definition"
    Const xml_meta_QC_Expln As String = "Explanation"

    '*Units
    Const xml_meta_Units_Name As String = "UnitsName"
    Const xml_meta_Units_Type As String = "UnitsType"
    Const xml_meta_Units_Abbr As String = "UnitsAbbreviation"

    'DataSeries >> OffsetInformation
    Const xml_meta_OT_Title As String = "Offset"
    Const xml_meta_OT_attrib_id As String = "id"
    Const xml_meta_OT_Desc As String = "OffsetDescription"
    Const xml_meta_OT_Units As String = "OffsetUnits"  'Child Element (UNITS)

    'DataSeries >> QualifierInformation
    Const xml_meta_Qual_Title As String = "Qualifier"
    Const xml_meta_Qual_attrib_id As String = "id"
    Const xml_meta_Qual_Code As String = "QualifierCode"
    Const xml_meta_Qual_Desc As String = "QualifierDescription"

    'DataSeries >> SampleInformation
    Const xml_meta_Smpl_Title As String = "Sample"
    Const xml_meta_Smpl_attrib_id As String = "id"
    Const xml_meta_Smpl_Type As String = "SampleType"
    Const xml_meta_Smpl_Code As String = "LabSampleCode"
    Const xml_meta_Smpl_LMid As String = "LabMethodid"

    'DataSeries >> LabMethodInformation
    Const xml_meta_LabM_Title As String = "LabMethod"
    Const xml_meta_LabM_attrib_id As String = "id"
    Const xml_meta_LabM_LName As String = "LabName"
    Const xml_meta_LabM_LOrg As String = "LabOrganization"
    Const xml_meta_LabM_LMName As String = "LabMethodName"
    Const xml_meta_LabM_LMDesc As String = "LabMethodDescription"
    Const xml_meta_LabM_LMLink As String = "LabMethodLink"

#End Region

    Public Shared Sub DataGridToExcel(ByVal objResponse As HttpResponse, ByVal header As String, ByVal filename As String, ByRef objDataTable As Data.DataTable)
        Try
            Dim stringWrite As New System.IO.StringWriter
            Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
            Dim dg As New DataGrid
            htmlWrite.Write(header)

            'Set the datagrid attributes and columns, bind, and render
            dg.DataSource = objDataTable
            dg.BorderColor = Drawing.Color.FromArgb(153, 153, 153)
            dg.BorderStyle = BorderStyle.None
            dg.BorderWidth = Unit.Pixel(1)
            dg.BackColor = Drawing.Color.White
            dg.CellPadding = 3
            dg.GridLines = GridLines.Vertical
            dg.EnableViewState = False
            dg.AutoGenerateColumns = False

            dg.HeaderStyle.Font.Bold = True
            dg.HeaderStyle.BackColor = Drawing.Color.FromArgb(0, 0, 132)
            dg.HeaderStyle.ForeColor = Drawing.Color.White
            dg.AlternatingItemStyle.BackColor = Drawing.Color.Gainsboro
            dg.ItemStyle.BackColor = Drawing.Color.FromArgb(238, 238, 238)

            'SiteCode column
            Dim colSite As BoundColumn = New BoundColumn
            colSite.DataField = "SiteCode"
            colSite.ReadOnly = True
            colSite.HeaderText = "SiteCode"
            dg.Columns.Add(colSite)

            'SiteName Column
            Dim colSiteName As BoundColumn = New BoundColumn
            colSiteName.DataField = "SiteName"
            colSiteName.ReadOnly = True
            colSiteName.HeaderText = "SiteName"
            dg.Columns.Add(colSiteName)

            'SiteType Column
            Dim colSiteType As BoundColumn = New BoundColumn
            colSiteType.DataField = "SiteType"
            colSiteType.ReadOnly = True
            colSiteType.HeaderText = "SiteType"
            dg.Columns.Add(colSiteType)

            'VariableCode column
            Dim colVariableCode As BoundColumn = New BoundColumn
            colVariableCode.DataField = "VariableCode"
            colVariableCode.ReadOnly = True
            colVariableCode.HeaderText = "VariableCode"
            dg.Columns.Add(colVariableCode)

            'VariableName column
            Dim colVariableName As BoundColumn = New BoundColumn
            colVariableName.DataField = "VariableName"
            colVariableName.ReadOnly = True
            colVariableName.HeaderText = "VariableName"
            dg.Columns.Add(colVariableName)

            'LocalDateTime column
            Dim colDate As BoundColumn = New BoundColumn
            colDate.DataField = "LocalDateTime"
            colDate.ReadOnly = True
            colDate.DataFormatString = "{0:g}"
            colDate.HeaderText = "LocalDateTime"
            dg.Columns.Add(colDate)

            'DataValue column
            Dim colVariableValue As BoundColumn = New BoundColumn
            colVariableValue.DataField = "DataValue"
            colVariableValue.ReadOnly = True
            colVariableValue.HeaderText = "DataValue"
            dg.Columns.Add(colVariableValue)

            'Bind
            dg.DataBind()

            'Render
            dg.RenderControl(htmlWrite)

            'Initialize response object and output HTML
            objResponse.Clear()
            objResponse.Charset = ""
            objResponse.ContentType = "application/vnd.ms-excel"
            objResponse.AddHeader("Content-Disposition", "attachment;filename=" & filename & ".xls")
            objResponse.Write(stringWrite.ToString)
            objResponse.End()
        Catch ex As Exception
            Throw New Exception("Error Occured in ExportFunctions.DataGridToExcel" & vbCrLf & ex.Message)
        End Try
    End Sub

#Region " ODM Tools Export Functions (MyDB.csv and Metadata.xml)"

    Public Shared Sub ExportMyDB(ByVal objResponse As HttpResponse, ByVal filename As String, ByVal e_DataSeries As DataSeries)
        Dim i As Integer
        Dim Writer As New System.IO.StringWriter
        Dim querytable As DataTable

        Try
            querytable = OpenODMTable(CreateExportQuery(e_DataSeries), e_DataSeries.DatabaseName)

            'Using Comma Delimited Format
            'write the headers
            Writer.Write(db_fld_SCSeriesid & ",")
            Writer.Write(db_fld_Valid & ",")
            Writer.Write(db_fld_ValValue & ",")
            Writer.Write(db_fld_ValAccuracyStdDev & ",")
            Writer.Write(db_fld_ValDateTime & ",")
            ''If g_CurrOptions.ExportTime Then 'OPTIONAL
            Writer.Write(db_fld_ValUTCDateTime & ",")
            Writer.Write(db_fld_ValUTCOffset & ",")
            ''End If
            Writer.Write(db_fld_SiteCode & ",")
            ''If g_CurrOptions.ExportSite Then 'OPTIONAL
            Writer.Write(db_fld_SiteName & ",")
            If DatabaseFunctions.GetODMVersion(e_DataSeries.DatabaseName) = "1.1.1" Then
                Writer.Write(db_fld_SiteType & ",")
            End If
            Writer.Write(db_fld_SiteLat & ",")
            Writer.Write(db_fld_SiteLong & ",")
            Writer.Write(db_fld_SRSRSName & ",")
            ''End If
            Writer.Write(db_fld_VarCode & ",")
            ''If g_CurrOptions.ExportVariable Then 'OPTIONAL
            Writer.Write(db_fld_VarName & ",")
            Writer.Write(db_expr_VarUnits_Name & ",")
            Writer.Write(db_expr_VarUnits_Abbr & ",")
            Writer.Write(db_fld_VarSampleMed & ",")
            ''End If
            Writer.Write(db_fld_ValOffsetValue & ",")
            Writer.Write(db_fld_ValOffsetTypeid & ",")
            ''If g_CurrOptions.ExportOffset Then 'OPTIONAL
            Writer.Write(db_fld_OTDesc & ",")
            Writer.Write(db_expr_OffsetUnits_Name & ",")
            ''End If
            Writer.Write(db_fld_ValCensorCode & ",")
            Writer.Write(db_fld_ValQualifierid & ",")
            ''If g_CurrOptions.ExportQualifier Then 'OPTIONAL
            Writer.Write(db_fld_QlfyCode & ",")
            Writer.Write(db_fld_QlfyDesc & ",")
            ''End If
            ''If g_CurrOptions.ExportSource Then 'OPTIONAL
            Writer.Write(db_fld_SrcOrg & ",")
            Writer.Write(db_fld_SrcDesc & ",")
            ''End If
            Writer.Write(db_fld_ValSampleid & vbCrLf)

            For i = 0 To querytable.Rows.Count - 1
                'Write each line of data, placing commas in between each value in the same row
                Writer.Write(e_DataSeries.Seriesid & ",")
                Writer.Write(querytable.Rows(i).Item(db_fld_Valid) & ",")
                Writer.Write(querytable.Rows(i).Item(db_fld_ValValue) & ",")
                Writer.Write(querytable.Rows(i).Item(db_fld_ValAccuracyStdDev) & ",")
                Writer.Write(CDate(querytable.Rows(i).Item(db_fld_ValDateTime)).ToString & ",")
                ''If g_CurrOptions.ExportTime Then 'OPTIONAL
                Writer.Write(CDate(querytable.Rows(i).Item(db_fld_ValUTCDateTime)).ToString & ",")
                Writer.Write(querytable.Rows(i).Item(db_fld_ValUTCOffset) & ",")
                ''End If
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_SiteCode) & """" & ",")
                ''If g_CurrOptions.ExportSite Then 'OPTIONAL
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_SiteName) & """" & ",")
                If DatabaseFunctions.GetODMVersion(e_DataSeries.DatabaseName) = "1.1.1" Then
                    Writer.Write("""" & querytable.Rows(i).Item(db_fld_SiteType) & """" & ",")
                End If
                Writer.Write(querytable.Rows(i).Item(db_fld_SiteLat) & ",")
                Writer.Write(querytable.Rows(i).Item(db_fld_SiteLong) & ",")
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_SRSRSName) & """" & ",")
                ''End If
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_VarCode) & """" & ",")
                ''If g_CurrOptions.ExportVariable Then 'OPTIONAL
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_VarName) & """" & ",")
                Writer.Write("""" & querytable.Rows(i).Item(db_expr_VarUnits_Name) & """" & ",")
                Writer.Write("""" & querytable.Rows(i).Item(db_expr_VarUnits_Abbr) & """" & ",")
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_VarSampleMed) & """" & ",")
                ''End If
                Writer.Write(querytable.Rows(i).Item(db_fld_ValOffsetValue) & ",")
                Writer.Write(querytable.Rows(i).Item(db_fld_ValOffsetTypeid) & ",")
                ''If g_CurrOptions.ExportOffset Then 'OPTIONAL
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_OTDesc) & """" & ",")
                Writer.Write("""" & querytable.Rows(i).Item(db_expr_OffsetUnits_Name) & """" & ",")
                ''End If
                Writer.Write(querytable.Rows(i).Item(db_fld_ValCensorCode) & ",")
                Writer.Write(querytable.Rows(i).Item(db_fld_ValQualifierid) & ",")
                ''If g_CurrOptions.ExportQualifier Then 'OPTIONAL
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_QlfyCode) & """" & ",")
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_QlfyDesc) & """" & ",")
                ''End If
                ''If g_CurrOptions.ExportSource Then 'OPTIONAL
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_SrcOrg) & """" & ",")
                Writer.Write("""" & querytable.Rows(i).Item(db_fld_SrcDesc) & """" & ",")
                ''End If
                Writer.Write(querytable.Rows(i).Item(db_fld_ValSampleid) & vbCrLf)
            Next i
        Catch ex As Exception
            Throw New Exception("Error Occured in ExportFunctions.ExportMyDB" & vbCrLf & ex.Message)
        End Try
        Writer.Close()

        'Initialize response object and output HTML
        objResponse.Clear()
        objResponse.Charset = ""
        objResponse.ContentType = "application/vnd.ms-excel"
        objResponse.AddHeader("Content-Disposition", "attachment;filename=" & filename & ".csv")
        objResponse.Write(Writer.ToString)
        objResponse.End()
    End Sub

    Public Shared Sub ExportMetaData(ByVal objResponse As HttpResponse, ByVal filename As String, ByVal e_DataSeries As DataSeries)
        Dim i As Integer 'Index Variables
        Dim stringWriter As New System.IO.StringWriter
        Dim series, value, querytable As System.Data.DataTable  'Holds the data retrieved from the Database query
        Dim writer As New System.Xml.XmlTextWriter(stringWriter) 'The Text Writer used to create the xml document
        Try

            querytable = OpenODMTable(CreateExportQuery(e_DataSeries), e_DataSeries.DatabaseName)

            'Format the output
            writer.Formatting = System.Xml.Formatting.Indented
            writer.Indentation() = 4

            'Create the Document
            writer.WriteStartDocument()

            'Root of the Metadata Document
            writer.WriteStartElement(xml_meta_Meta_root)

            'Metadata >> DataSeriesList element
            writer.WriteStartElement(xml_meta_DSL_root)
            writer.WriteAttributeString(xml_meta_DSL_attrib_Total, 1)

            'For each DataSeriesid Write the DataSeries metadata

            series = OpenODMTable(CreateMetadataSeriesQuery(e_DataSeries), e_DataSeries.DatabaseName)

            writer.WriteStartElement(xml_meta_DSL_DataSeries) 'DataSeriesList >> DataSeries Element

            If series.Rows.Count > 0 Then
                writer.WriteAttributeString(xml_meta_DS_attrib_id, series.Rows(0).Item(db_fld_SCSeriesid).ToString)

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
                If DatabaseFunctions.GetODMVersion(e_DataSeries.DatabaseName) = "1.1.1" Then
                    writer.WriteElementString(xml_meta_Site_Type, series.Rows(0).Item(db_fld_SiteType).ToString)
                End If

                writer.WriteStartElement(xml_meta_Site_Geo) 'SiteInformation >> GeographicCoordinates Element
                writer.WriteElementString(xml_meta_Geo_Lat, series.Rows(0).Item(db_fld_SiteLat).ToString)
                writer.WriteElementString(xml_meta_Geo_Lon, series.Rows(0).Item(db_fld_SiteLong).ToString)
                writer.WriteElementString(xml_meta_Geo_SRSid, series.Rows(0).Item(db_expr_Geo_SRSid).ToString)
                writer.WriteElementString(xml_meta_Geo_SRSName, series.Rows(0).Item(db_expr_Geo_SRSName).ToString)
                writer.WriteElementString(xml_meta_Geo_IsGeo, series.Rows(0).Item(db_expr_Geo_IsGeo).ToString)
                writer.WriteElementString(xml_meta_Geo_Notes, series.Rows(0).Item(db_expr_Geo_Notes).ToString)
                writer.WriteEndElement() 'END: SiteInformation >> GeographicCoordinates Element

                writer.WriteStartElement(xml_meta_Site_Local) 'SiteInformation >> GeographicCoordinates Element
                writer.WriteElementString(xml_meta_Local_X, series.Rows(0).Item(db_fld_SiteLocX).ToString)
                writer.WriteElementString(xml_meta_Local_Y, series.Rows(0).Item(db_fld_SiteLocY).ToString)
                writer.WriteElementString(xml_meta_Local_SRSid, series.Rows(0).Item(db_expr_Local_SRSid).ToString)
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

                writer.WriteEndElement() 'END: DataSeries >> Source Information Element

                writer.WriteStartElement(xml_meta_DS_QC) 'DataSeries >> QualityControlLevelInformation Element
                writer.WriteElementString(xml_meta_QC_Level, series.Rows(0).Item(db_fld_QCLQCLevel).ToString)
                writer.WriteElementString(xml_meta_QC_Defin, series.Rows(0).Item(db_fld_QCLDefinition).ToString)
                writer.WriteElementString(xml_meta_QC_Expln, series.Rows(0).Item(db_fld_QCLExplanation).ToString)
                writer.WriteEndElement() 'END: DataSeries >> QualityControlLevelInformation Element

                writer.WriteStartElement(xml_meta_DS_OT) 'DataSeries >> OffsetInformation Element
                value = OpenODMTable(CreateMetadataOffsetQuery(e_DataSeries), e_DataSeries.DatabaseName)
                For i = 0 To value.Rows.Count - 1 'Write each set of offset information
                    writer.WriteStartElement(xml_meta_OT_Title) 'OffsetInformation >> Offset Element
                    writer.WriteAttributeString(xml_meta_OT_attrib_id, value.Rows(i).Item(db_fld_OTid).ToString)
                    writer.WriteElementString(xml_meta_OT_Desc, value.Rows(i).Item(db_fld_OTDesc).ToString)
                    writer.WriteStartElement(xml_meta_OT_Units) 'Offset >> OffsetUnits Element
                    writer.WriteElementString(xml_meta_Units_Name, value.Rows(i).Item(db_fld_UnitsName).ToString)
                    writer.WriteElementString(xml_meta_Units_Type, value.Rows(i).Item(db_fld_UnitsType).ToString)
                    writer.WriteElementString(xml_meta_Units_Abbr, value.Rows(i).Item(db_fld_UnitsAbrv).ToString)
                    writer.WriteEndElement() 'END: Offset >> OffsetUnits Element
                    writer.WriteEndElement() 'END: OffsetInformation >> Offset Element
                Next
                writer.WriteEndElement() 'END: DataSeries >> OffsetInformation Element

                writer.WriteStartElement(xml_meta_DS_Qual) 'DataSeries >> QualifierInformation
                value = OpenODMTable(CreateMetadataQualifierQuery(e_DataSeries), e_DataSeries.DatabaseName)
                For i = 0 To value.Rows.Count - 1 'Write each set of qualifier information
                    writer.WriteStartElement(xml_meta_Qual_Title) 'QualifierInformation >> Qualifier Element
                    writer.WriteAttributeString(xml_meta_Qual_attrib_id, value.Rows(i).Item(db_fld_Qlfyid).ToString)
                    writer.WriteElementString(xml_meta_Qual_Code, value.Rows(i).Item(db_fld_QlfyCode).ToString)
                    writer.WriteElementString(xml_meta_Qual_Desc, value.Rows(i).Item(db_fld_QlfyDesc).ToString)
                    writer.WriteEndElement() 'END: QualifierInformation >> Qualifier Element
                Next
                writer.WriteEndElement() 'END: DataSeries >> QualifierInformation Element

                writer.WriteStartElement(xml_meta_DS_Smpl) 'DataSeries >> SampleInformation Element
                value = OpenODMTable(CreateMetadataSampleQuery(e_DataSeries), e_DataSeries.DatabaseName)
                For i = 0 To value.Rows.Count - 1 'Write each set of sample information
                    writer.WriteStartElement(xml_meta_Smpl_Title) 'SampleInformation >> Sample Element
                    writer.WriteAttributeString(xml_meta_Smpl_attrib_id, value.Rows(i).Item(db_fld_Sampleid).ToString)
                    writer.WriteElementString(xml_meta_Smpl_Type, value.Rows(i).Item(db_fld_SampleType).ToString)
                    writer.WriteElementString(xml_meta_Smpl_Code, value.Rows(i).Item(db_fld_SampleLabCode).ToString)
                    writer.WriteElementString(xml_meta_Smpl_LMid, value.Rows(i).Item(db_fld_SampleMethodid).ToString)
                    writer.WriteEndElement() 'END: SampleInformation >> Sample Element
                Next
                writer.WriteEndElement() 'END: DataSeries >> SampleInformation Element

                writer.WriteStartElement(xml_meta_DS_LabM) 'DataSeries >> LabMethodInformation Element
                value = OpenODMTable(CreateMetadataLabMethodQuery(e_DataSeries), e_DataSeries.DatabaseName)
                For i = 0 To value.Rows.Count - 1 'Write each set of lab method information Element
                    writer.WriteStartElement(xml_meta_LabM_Title) 'LabMethodInformation >> LabMethod Element
                    writer.WriteAttributeString(xml_meta_LabM_attrib_id, value.Rows(i).Item(db_fld_LMid).ToString)
                    writer.WriteElementString(xml_meta_LabM_LName, value.Rows(i).Item(db_fld_LMLabName).ToString)
                    writer.WriteElementString(xml_meta_LabM_LOrg, value.Rows(i).Item(db_fld_LMLabOrg).ToString)
                    writer.WriteElementString(xml_meta_LabM_LMName, value.Rows(i).Item(db_fld_LMName).ToString)
                    writer.WriteElementString(xml_meta_LabM_LMDesc, value.Rows(i).Item(db_fld_LMDesc).ToString)
                    writer.WriteElementString(xml_meta_LabM_LMLink, value.Rows(i).Item(db_fld_LMLink).ToString)
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

            writer.WriteEndElement() 'END:   Metadata >> DataSeriesList element
            writer.WriteEndElement() 'END:   Root of the Metadata Document
            writer.Flush()
        Catch ex As Exception
            Throw New Exception("Error Occured in ExportFunctions.ExportMetadata" & vbCrLf & ex.Message)
        End Try
        'Save and Close the XML document stream
        writer.Close()



        'Initialize response object and output HTML
        objResponse.Clear()
        objResponse.ContentType = "text/xml"
        objResponse.Charset = "utf-8"
        objResponse.ContentEncoding = System.Text.Encoding.UTF8
        objResponse.HeaderEncoding = System.Text.Encoding.UTF8
        objResponse.AddHeader("Content-Disposition", "attachment;filename=" & filename & ".xml")
        objResponse.Write(stringWriter.ToString.Replace("utf-16", "utf-8"))
        objResponse.End()

    End Sub

#Region " Create Query Functions "

    'TODO: GREATLY SIMPLIFY THIS QUERY!!!!!
    Private Shared Function CreateMetadataSeriesQuery(ByVal e_Series As DataSeries) As String
        'Creates the Query String used to export the series level metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String = "" 'Used to store the Metadata Series Level Query used to export series level metadata
        Try
            'Write the SELECT DISTINCT statement
            sql = "SELECT DISTINCT " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCSeriesid & ", " & _
             db_tbl_ISOMetaData & "." & db_fld_IMDTopicCat & ", " & _
             db_tbl_ISOMetaData & "." & db_fld_IMDTitle & ", " & _
             db_tbl_ISOMetaData & "." & db_fld_IMDAbstract & ", " & _
             db_tbl_ISOMetaData & "." & db_fld_IMDProfileVs & ", " & _
             db_tbl_ISOMetaData & "." & db_fld_IMDMetaLink & ", " & _
             db_tbl_Sites & "." & db_fld_SiteCode & ", " & _
             db_tbl_Sites & "." & db_fld_SiteName & ", "
            If DatabaseFunctions.GetODMVersion(e_Series.DatabaseName) = "1.1.1" Then
                sql &= db_tbl_Sites & "." & db_fld_SiteType & ", "
            End If
            sql &= db_tbl_Sites & "." & db_fld_SiteLat & ", " & _
             db_tbl_Sites & "." & db_fld_SiteLong & ", " & _
             db_expr_Geo & "." & db_fld_SRSRSid & " AS " & db_expr_Geo_SRSid & ", " & _
             db_expr_Geo & "." & db_fld_SRSRSName & " AS " & db_expr_Geo_SRSName & ", " & _
             db_expr_Geo & "." & db_fld_SRIsGeo & " AS " & db_expr_Geo_IsGeo & ", " & _
             db_expr_Geo & "." & db_fld_SRNotes & " AS " & db_expr_Geo_Notes & ", " & _
             db_tbl_Sites & "." & db_fld_SiteVertDatum & ", " & _
             db_tbl_Sites & "." & db_fld_SiteLocX & ", " & _
             db_tbl_Sites & "." & db_fld_SiteLocY & ", " & _
             db_tbl_Sites & "." & db_fld_SiteElev_m & ", " & _
             db_tbl_Sites & "." & db_fld_SitePosAccuracy_m & ", " & _
             db_expr_Local & "." & db_fld_SRSRSid & " AS " & db_expr_Local_SRSid & ", " & _
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
             db_tbl_OffsetTypes & "." & db_fld_OTDesc & ", " & _
             db_expr_OffsetUnits & "." & db_fld_UnitsName & " AS " & db_expr_OffsetUnits_Name & ", " & _
             db_expr_OffsetUnits & "." & db_fld_UnitsType & " AS " & db_expr_OffsetUnits_Type & ", " & _
             db_expr_OffsetUnits & "." & db_fld_UnitsAbrv & " AS " & db_expr_OffsetUnits_Abbr & ", " & _
             db_tbl_Methods & "." & db_fld_MethDesc & ", " & _
             db_tbl_Methods & "." & db_fld_MethLink & ", " & _
             db_tbl_QCLevels & "." & db_fld_QCLQCLevel & ", " & _
             db_tbl_QCLevels & "." & db_fld_QCLDefinition & ", " & _
             db_tbl_QCLevels & "." & db_fld_QCLExplanation

            'FROM statement
            sql = sql & " FROM " & _
             db_tbl_SpatialRefs & " AS " & db_expr_Local & " RIGHT OUTER JOIN " & _
             db_tbl_Units & " AS " & db_expr_OffsetUnits & " INNER JOIN " & _
             db_tbl_OffsetTypes & " ON " & _
             db_expr_OffsetUnits & "." & db_fld_Unitsid & " = " & _
             db_tbl_OffsetTypes & "." & db_fld_OTUnitsid & " RIGHT OUTER JOIN " & _
             db_tbl_QCLevels & " INNER JOIN " & _
             db_tbl_SeriesCatalog & " ON " & _
             db_tbl_QCLevels & "." & db_fld_QCLQCLevel & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel & " INNER JOIN " & _
             db_tbl_Units & " AS " & db_expr_VarUnits & " INNER JOIN " & _
             db_tbl_Variables & " ON " & _
             db_expr_VarUnits & "." & db_fld_Unitsid & " = " & _
             db_tbl_Variables & "." & db_fld_VarUnitsid & " INNER JOIN " & _
             db_tbl_Units & " AS " & db_expr_TimeUnits & " ON " & _
             db_tbl_Variables & "." & db_fld_VarTimeUnitsid & " = " & _
             db_expr_TimeUnits & "." & db_fld_Unitsid & " ON " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCVarid & " = " & _
             db_tbl_Variables & "." & db_fld_Varid & " INNER JOIN " & _
             db_tbl_SpatialRefs & " AS " & db_expr_Geo & " INNER JOIN " & _
             db_tbl_Sites & " ON " & _
             db_expr_Geo & "." & db_fld_SRid & " = " & _
             db_tbl_Sites & "." & db_fld_SiteLatLongDatumid & " ON " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCSiteid & " = " & _
             db_tbl_Sites & "." & db_fld_Siteid & " INNER JOIN " & _
             db_tbl_Methods & " ON " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCMethodid & " = " & _
             db_tbl_Methods & "." & db_fld_Methid & " INNER JOIN " & _
             db_tbl_ISOMetaData & " INNER JOIN " & _
             db_tbl_Sources & " ON " & _
             db_tbl_ISOMetaData & "." & db_fld_IMDMetaid & " = " & _
             db_tbl_Sources & "." & db_fld_SrcMetaid & " ON " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCSourceid & " = " & _
             db_tbl_Sources & "." & db_fld_Srcid & " INNER JOIN " & _
             db_tbl_DataValues & " ON " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel & " = " & _
             db_tbl_DataValues & "." & db_fld_ValQCLevel & " AND " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCSiteid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValSiteid & " AND " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCVarid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValVarid & " ON " & _
             db_tbl_OffsetTypes & "." & db_fld_OTid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValOffsetTypeid & " ON " & _
             db_expr_Local & "." & db_fld_SRid & " = " & _
             db_tbl_Sites & "." & db_fld_SiteLocProjid

            'Write the WHERE statement
            sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesid & " = " & e_Series.Seriesid & ") "

            Return sql
        Catch ex As Exception
            Throw New Exception("Error Occured in ExportFunctions.CreateMetadataSeriesQuery" & vbCrLf & ex.Message)
        End Try
    End Function

    'TODO: GREATLY SIMPLIFY THIS QUERY!!!!!
    Private Shared Function CreateMetadataOffsetQuery(ByVal e_Series As DataSeries) As String
        'Creates the Query String used to export the offset metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Metadata Offset Query used to export offset metadata
        Try
            'The SELECT DISTINCT statement
            sql = "SELECT DISTINCT " & _
             db_tbl_OffsetTypes & "." & db_fld_OTid & ", " & _
             db_tbl_OffsetTypes & "." & db_fld_OTDesc & ", " & _
             db_tbl_Units & "." & db_fld_UnitsName & ", " & _
             db_tbl_Units & "." & db_fld_UnitsType & ", " & _
             db_tbl_Units & "." & db_fld_UnitsAbrv

            'The FROM statement
            sql = sql & " FROM " & _
             db_tbl_DataValues & " INNER JOIN " & _
             db_tbl_OffsetTypes & " ON " & _
             db_tbl_DataValues & "." & db_fld_ValOffsetTypeid & " = " & _
             db_tbl_OffsetTypes & "." & db_fld_OTid & " INNER JOIN " & _
             db_tbl_Units & " ON " & _
             db_tbl_OffsetTypes & "." & db_fld_OTUnitsid & " = " & _
             db_tbl_Units & "." & db_fld_Unitsid & " INNER JOIN " & _
             db_tbl_SeriesCatalog & " ON " & _
             db_tbl_DataValues & "." & db_fld_ValSiteid & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCSiteid & " AND " & _
             db_tbl_DataValues & "." & db_fld_ValVarid & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCVarid

            'The WHERE statement
            sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesid & " = " & e_Series.Seriesid & ") "

            'The ORDER BY statement
            sql = sql & " ORDER BY " & _
             db_tbl_OffsetTypes & "." & db_fld_OTid

            Return sql
        Catch ex As Exception
            Throw New Exception("Error Occured in ExportFunctions.CreateMetadataOffsetQuery" & vbCrLf & ex.Message)
        End Try
    End Function

    'TODO: GREATLY SIMPLIFY THIS QUERY!!!!!
    Private Shared Function CreateMetadataQualifierQuery(ByVal e_Series As DataSeries) As String
        'Creates the Query String used to export the Qualifier metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Metadata Qualifier Query used to export qualifier metadata
        Try
            'The SELECT DISTINCT statement
            sql = "SELECT DISTINCT " & _
             db_tbl_Qualifiers & "." & db_fld_Qlfyid & ", " & _
             db_tbl_Qualifiers & "." & db_fld_QlfyCode & ", " & _
             db_tbl_Qualifiers & "." & db_fld_QlfyDesc

            'The FROM statement
            sql = sql & " FROM " & _
             db_tbl_Qualifiers & " INNER JOIN " & _
             db_tbl_DataValues & " ON " & _
             db_tbl_Qualifiers & "." & db_fld_Qlfyid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValQualifierid & " INNER JOIN " & _
             db_tbl_SeriesCatalog & " ON " & _
             db_tbl_DataValues & "." & db_fld_ValSiteid & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCSiteid & " AND " & _
             db_tbl_DataValues & "." & db_fld_ValVarid & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCVarid

            'The WHERE statement
            sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesid & " = " & e_Series.Seriesid & ") "

            'The ORDER BY statement
            sql = sql & " ORDER BY " & _
             db_tbl_Qualifiers & "." & db_fld_Qlfyid

            Return sql
        Catch ex As Exception
            Throw New Exception("Error Occured in ExportFunctions.CreateMetadataQualifierQuery" & vbCrLf & ex.Message)
        End Try
    End Function

    'TODO: GREATLY SIMPLIFY THIS QUERY!!!!!
    Private Shared Function CreateMetadataSampleQuery(ByVal e_Series As DataSeries) As String
        'Creates the Query String used to export the qualifier metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Metadata Sample Query used to export Sample metadata
        Try
            'The SELECT DISTINCT statement
            sql = "SELECT DISTINCT " & _
             db_tbl_Samples & "." & db_fld_Sampleid & ", " & _
             db_tbl_Samples & "." & db_fld_SampleType & ", " & _
             db_tbl_Samples & "." & db_fld_SampleLabCode & ", " & _
             db_tbl_Samples & "." & db_fld_SampleMethodid

            'The FROM statement
            sql = sql & " FROM " & _
             db_tbl_Samples & " INNER JOIN " & _
             db_tbl_DataValues & " ON " & _
             db_tbl_Samples & "." & db_fld_Sampleid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValSampleid & " INNER JOIN " & _
             db_tbl_SeriesCatalog & " ON " & _
             db_tbl_DataValues & "." & db_fld_ValSiteid & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCSiteid & " AND " & _
             db_tbl_DataValues & "." & db_fld_ValVarid & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCVarid

            'The WHERE statement
            sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesid & " = " & e_Series.Seriesid & ") "

            'The ORDER BY statement
            sql = sql & " ORDER BY " & _
             db_tbl_Samples & "." & db_fld_Sampleid

            Return sql
        Catch ex As Exception
            Throw New Exception("Error Occured in ExportFunctions.CreateMetadataSampleQuery" & vbCrLf & ex.Message)
        End Try
    End Function

    'TODO: GREATLY SIMPLIFY THIS QUERY!!!!!
    Private Shared Function CreateMetadataLabMethodQuery(ByVal e_Series As DataSeries) As String
        'Creates the Query String used to export the offset metadata for the selected series
        'Inputs:  The series id of the metadata to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Metadata Lab Method Query used to export LabMethod metadata
        Try
            'The SELECT DISTINCT statement
            sql = "SELECT DISTINCT " & _
             db_tbl_LabMethods & "." & db_fld_LMid & ", " & _
             db_tbl_LabMethods & "." & db_fld_LMLabName & ", " & _
             db_tbl_LabMethods & "." & db_fld_LMLabOrg & ", " & _
             db_tbl_LabMethods & "." & db_fld_LMName & ", " & _
             db_tbl_LabMethods & "." & db_fld_LMDesc & ", " & _
             db_tbl_LabMethods & "." & db_fld_LMLink

            'The FROM statement
            sql = sql & " FROM " & _
             db_tbl_Samples & " INNER JOIN " & _
             db_tbl_DataValues & " ON " & _
             db_tbl_Samples & "." & db_fld_Sampleid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValSampleid & " INNER JOIN " & _
             db_tbl_LabMethods & " ON " & _
             db_tbl_Samples & "." & db_fld_SampleMethodid & " = " & _
             db_tbl_LabMethods & "." & db_fld_LMid & " INNER JOIN " & _
             db_tbl_SeriesCatalog & " ON " & _
             db_tbl_DataValues & "." & db_fld_ValMethodid & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCMethodid & " AND " & _
             db_tbl_DataValues & "." & db_fld_ValSiteid & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_SCSiteid & " AND " & _
             db_tbl_DataValues & "." & db_fld_ValVarid & " = " & _
             db_tbl_SeriesCatalog & "." & db_fld_ValVarid

            'The WHERE statement
            sql = sql & " WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSeriesid & " = " & e_Series.Seriesid & ") "

            'The ORDER BY statement
            sql = sql & " ORDER BY " & _
             db_tbl_LabMethods & "." & db_fld_LMid

            Return sql
        Catch ex As Exception
            Throw New Exception("Error Occured in ExportFunctions.CreateMetadataLabMethodQuery" & vbCrLf & ex.Message)
        End Try
    End Function

    'TODO: GREATLY SIMPLIFY THIS QUERY!!!!!
    Private Shared Function CreateExportQuery(ByVal e_Series As DataSeries) As String
        'Creates the Query String used to export the selected data series
        'Inputs:  Input an array of integers containing the seriesids of the data series to export
        'Outputs: SQL -> The Query String

        Dim sql As String 'Used to store the Data Export Query used to export multiple data series
        'Dim i As Integer 'Counter Variable
        Try
            'CORE Select Statement
            sql = "SELECT " & _
             db_tbl_DataValues & "." & db_fld_Valid & ", " & _
             db_tbl_DataValues & "." & db_fld_ValValue & ", " & _
             db_tbl_DataValues & "." & db_fld_ValAccuracyStdDev & ", " & _
             db_tbl_DataValues & "." & db_fld_ValDateTime & ", " & _
             db_tbl_DataValues & "." & db_fld_ValOffsetValue & ", " & _
             db_tbl_DataValues & "." & db_fld_ValOffsetTypeid & ", " & _
             db_tbl_DataValues & "." & db_fld_ValCensorCode & ", " & _
             db_tbl_DataValues & "." & db_fld_ValQualifierid & ", " & _
             db_tbl_Sites & "." & db_fld_SiteCode & ", " & _
             db_tbl_Variables & "." & db_fld_VarCode & ", " & _
             db_tbl_DataValues & "." & db_fld_ValSampleid

            'Include the Time information
            ''If g_CurrOptions.ExportTime Then
            sql = sql & ", " & _
             db_tbl_DataValues & "." & db_fld_ValUTCDateTime & ", " & _
             db_tbl_DataValues & "." & db_fld_ValUTCOffset
            ''End If

            'Include the Site information
            ''If g_CurrOptions.ExportSite Then
            sql = sql & ", " & _
             db_tbl_Sites & "." & db_fld_SiteName & ", "
            If DatabaseFunctions.GetODMVersion(e_Series.DatabaseName) = "1.1.1" Then
                sql &= db_tbl_Sites & "." & db_fld_SiteType & ", "
            End If
            sql &= db_tbl_Sites & "." & db_fld_SiteLat & ", " & _
             db_tbl_Sites & "." & db_fld_SiteLong & ", " & _
             db_tbl_SpatialRefs & "." & db_fld_SRSRSName
            ''End If

            'Include the Variable information
            ''If g_CurrOptions.ExportVariable Then
            sql = sql & ", " & _
             db_tbl_Variables & "." & db_fld_VarName & ", " & _
             db_expr_VarUnits & "." & db_fld_UnitsName & " AS " & db_expr_VarUnits_Name & ", " & _
             db_expr_VarUnits & "." & db_fld_UnitsAbrv & " AS " & db_expr_VarUnits_Abbr & ", " & _
             db_tbl_Variables & "." & db_fld_VarSampleMed
            ''End If

            'Include the Qualifier information
            ''If g_CurrOptions.ExportQualifier Then
            sql = sql & ", " & _
             db_tbl_Qualifiers & "." & db_fld_QlfyCode & ", " & _
             db_tbl_Qualifiers & "." & db_fld_QlfyDesc
            ''End If

            'Include the Offset information
            ''If g_CurrOptions.ExportOffset Then
            sql = sql & ", " & _
             db_tbl_OffsetTypes & "." & db_fld_OTDesc & ", " & _
             db_expr_OffsetUnits & "." & db_fld_UnitsName & " AS " & db_expr_OffsetUnits_Name
            ''End If

            'Include the Source information
            ''If g_CurrOptions.ExportSource Then
            sql = sql & ", " & _
             db_tbl_Sources & "." & db_fld_SrcOrg & ", " & _
             db_tbl_Sources & "." & db_fld_SrcDesc
            ''End If

            'CORE From Statement
            sql = sql & " FROM " & _
             db_tbl_DataValues & " LEFT OUTER JOIN " & _
             db_tbl_Samples & " ON " & _
             db_tbl_DataValues & "." & db_fld_ValSampleid & " = " & _
             db_tbl_Samples & "." & db_fld_Sampleid & " LEFT OUTER JOIN " & _
             db_tbl_Sites & " ON " & _
             db_tbl_Sites & "." & db_fld_Siteid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValSiteid & " LEFT OUTER JOIN " & _
             db_tbl_Variables & " ON " & _
             db_tbl_Variables & "." & db_fld_Varid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValVarid

            'Include the Site information
            ''If g_CurrOptions.ExportSite Then
            sql = sql & " LEFT Outer Join " & _
             db_tbl_SpatialRefs & " ON " & _
             db_tbl_SpatialRefs & "." & db_fld_SRid & " = " & _
             db_tbl_Sites & "." & db_fld_SiteLatLongDatumid
            '' End If

            'Include the Variable information
            ''If g_CurrOptions.ExportVariable Then
            sql = sql & " LEFT Outer Join " & _
             db_tbl_Units & " AS " & db_expr_VarUnits & " ON " & _
             db_expr_VarUnits & "." & db_fld_Unitsid & " = " & _
             db_tbl_Variables & "." & db_fld_VarUnitsid
            ''End If

            'Include the Qualifier information
            ''If g_CurrOptions.ExportQualifier Then
            sql = sql & " LEFT OUTER JOIN " & _
             db_tbl_Qualifiers & " ON " & _
             db_tbl_Qualifiers & "." & db_fld_Qlfyid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValQualifierid
            ''End If

            'Include the Offset information
            ''If g_CurrOptions.ExportOffset Then
            sql = sql & " LEFT OUTER JOIN " & _
             db_tbl_OffsetTypes & " ON " & _
             db_tbl_OffsetTypes & "." & db_fld_OTid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValOffsetTypeid & " LEFT Outer Join " & _
             db_tbl_Units & " AS " & db_expr_OffsetUnits & " ON " & _
             db_expr_OffsetUnits & "." & db_fld_Unitsid & " = " & _
             db_tbl_OffsetTypes & "." & db_fld_OTUnitsid
            ''End If

            'Include the Source information
            ''If g_CurrOptions.ExportSource Then
            sql = sql & " LEFT OUTER JOIN " & _
             db_tbl_Sources & " ON " & _
             db_tbl_Sources & "." & db_fld_Srcid & " = " & _
             db_tbl_DataValues & "." & db_fld_ValSourceid
            ''End If

            'Where statement
            sql = sql & " WHERE (" & db_tbl_DataValues & "." & db_fld_ValSiteid & " = " & e_Series.Siteid & ") AND (" & _
              db_tbl_DataValues & "." & db_fld_ValVarid & " = " & e_Series.Variableid & ") AND (" & _
              db_tbl_DataValues & "." & db_fld_ValMethodid & " = " & e_Series.MethodID & ") AND (" & _
              db_tbl_DataValues & "." & db_fld_ValSourceid & " = " & e_Series.SourceID & ") AND (" & _
              db_tbl_DataValues & "." & db_fld_ValQCLevel & " = " & e_Series.QualityControlLevelid & ")"

            'Write the Order By statement
            sql = sql & "ORDER BY " & db_tbl_DataValues & "." & db_fld_Valid


            'Return the SQL Query String
            Return sql
        Catch ex As Exception
            Throw New Exception("Error Occured in ExportFunctions.CreateExportQuery" & vbCrLf & ex.Message)
        End Try
    End Function

#End Region

#End Region

End Class
