Imports System.Data.SqlClient
Imports databasefunctions

Partial Class RootDefault
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        Try
            Dim connstring As String = DatabaseFunctions.GetConnectionString(Session("Database"))
            SelectSite = New SqlDataSource(connstring, SelectSiteCommand)
            SelectVar = New SqlDataSource(connstring, SelectVarCommand)
            ddlSites.DataSource = SelectSite
            ddlVars.DataSource = SelectVar
            SelectSite.DataBind()
            SelectVar.DataBind()
            Page_Load()
        Catch ex As Exception
            Me.objSummary.Message("An error occurred in Default.Page_Init" & vbCrLf & ex.Message, ex)
        End Try


    End Sub

#End Region

    Public WithEvents SelectSite As SqlDataSource
    Public WithEvents SelectVar As SqlDataSource

    '<asp:SqlDataSource ID="SelectSite" runat="server" ConnectionString="" SelectCommand="SELECT DISTINCT [SiteCode], [SiteCode] + ': '+ [SiteName] as SiteString FROM [SeriesCatalog]"></asp:SqlDataSource>
    '<asp:SqlDataSource ID="SelectVar" runat="server" ConnectionString="" SelectCommand="SELECT DISTINCT [VariableCode], [SiteCode], [VariableCode] + ': ' + [VariableName] + ' in ' + [VariableUnitsName] + ' (' + CAST([TimeSupport] as VarChar(10)) +' '+ [TimeUnitsName] +' '+ [DataType] + ')' as VarInfo FROM [SeriesCatalog]"></asp:SqlDataSource>
    Private mobjGraphs As New Collection
    Private mobjOptions As New Collection
    Private mobjDataSet As Data.DataSet
    Private mtblSeries As Data.DataTable
    Private Const SelectSiteCommand As String = "SELECT DISTINCT [SiteCode], [SiteCode] + ': '+ [SiteName] as SiteString FROM [SeriesCatalog]"
    Private Const SelectVarCommand As String = "SELECT DISTINCT [VariableCode], [SiteCode], [VariableCode] + ': ' + [VariableName] + ' in ' + [VariableUnitsName] + ' (' + CAST([TimeSupport] as VarChar(10)) +' '+ [TimeUnitsName] +' '+ [DataType] + ')' as VarInfo FROM [SeriesCatalog]"
    Private mFilterString As String = ""

    ReadOnly Property TimeSeries() As Graphs_ZGTimeSeries
        Get
            Return objTimeSeries
        End Get
    End Property

    ReadOnly Property Probability() As Graphs_ZGProbability
        Get
            Return objProbability
        End Get
    End Property

    ReadOnly Property Histogram() As Graphs_ZGHistogram
        Get
            Return objHistogram
        End Get
    End Property

    ReadOnly Property BoxWhisker() As Graphs_ZGBoxWhisker
        Get
            Return objBoxWhisker
        End Get
    End Property

    ReadOnly Property Summary() As OptionsSummary
        Get
            Return objSummary
        End Get
    End Property

    ReadOnly Property Options() As PlotOptions
        Get
            Return objPlotOptions.curr_Options
        End Get
    End Property

    ReadOnly Property SiteInfo() As String
        Get
            Dim strSiteCode, strSiteName As String
            strSiteCode = Left(ddlSites.SelectedItem.Text, ddlSites.SelectedItem.Text.IndexOf(" - "))
            strSiteName = Right(ddlSites.SelectedItem.Text, ddlSites.SelectedItem.Text.Length - ddlSites.SelectedItem.Text.IndexOf(" - ") - 3)

            Dim strSiteInfo As String
            strSiteInfo = "<b>SiteCode: </b>" & strSiteCode & "<br>" & _
                          "<b>SiteName: </b>" & strSiteName & "<br>"

            Return strSiteInfo

        End Get
    End Property

    ReadOnly Property VariableInfo() As String
        Get
            Dim strVariableCode, strVariableName, strVariableUnits As String
            strVariableCode = Split(ddlVars.SelectedItem.Text, " - ", 3)(0)
            strVariableName = Split(ddlVars.SelectedItem.Text, " _ ", 3)(1)
            strVariableUnits = Split(ddlVars.SelectedItem.Text, " - ", 3)(2)

            'Dim objVariableInfoTable As Data.DataTable = DatabaseFunctions.OpenTable("SELECT Variables.*, Units.UnitsName AS VariableUnits FROM Variables LEFT OUTER JOIN Units ON Variables.VariableUnitsid = Units.UnitsidWHERE Variables.VariableCode = '" & strVariableCode & "'")

            Dim strVariableInfo As String
            strVariableInfo = "<b>VariableCode: </b>" & strVariableCode & "<br>" & _
                              "<b>VariableName: </b>" & strVariableName & "<br>" & _
                              "<b>VariableUnits: </b>" & strVariableUnits & "<br>"

            Return strVariableInfo
        End Get
    End Property

    ReadOnly Property SeriesInfo() As String
        Get
            Try
                'FIX - need to fix this so that it creates an HTML string with all of the series 
                'FIX - need to make this respond to qclevelid, method, and source
                'information for the print.aspx page to replace the SiteInfo and VariableInfo sections 
                'above.
                'Get the Siteid and the Variableid
                Dim strSitecode As String = ddlSites.SelectedItem.Value
                Dim strVariablecode As String = ddlVars.SelectedItem.Value

                'Query the Series Catalog table for all of the series information
                Dim objSeriesInfoTable As Data.DataTable = DatabaseFunctions.OpenODMTable("SELECT * FROM SeriesCatalog WHERE SiteCode = '" & strSitecode & "' AND VariableCode = '" & strVariablecode & "'", Session("Database"))
                If (objSeriesInfoTable.Rows.Count > 0) Then
                    'Construct an HTML string with all of the series information
                    Dim strSeriesInfo As String
                    strSeriesInfo = "<b>SiteCode: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("SiteCode")) & "<br>" & _
                                    "<b>SiteName: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("SiteName")) & "<br>"
                    If DatabaseFunctions.GetODMVersion("") = "1.1.1" Then
                        strSeriesInfo &= "<b>SiteType: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("SiteType")) & "<br>"
                    End If
                    strSeriesInfo &= "<b>VariableCode: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("VariableCode")) & "<br>" & _
                                    "<b>VariableName: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("VariableName")) & "<br>" & _
                                    "<b>VariableUnitsName: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("VariableUnitsName")) & "<br>" & _
                                    "<b>SampleMedium: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("SampleMedium")) & "<br>" & _
                                    "<b>ValueType: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("ValueType")) & "<br>" & _
                                    "<b>TimeSupport: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("TimeSupport")) & " " & Convert.ToString(objSeriesInfoTable.Rows(0).Item("TimeUnitsName")) & "<br>" & _
                                    "<b>DataType: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("DataType")) & "<br>" & _
                                    "<b>GeneralCategory: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("GeneralCategory")) & "<br>" & _
                                    "<b>QualityControlLevelid: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("QualityControlLevelid")) & "<br>" & _
                                    "<b>MethodDescription: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("MethodDescription")) & "<br>" & _
                                    "<b>Organization: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("Organization")) & "<br>" & _
                                    "<b>SourceDescription: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("SourceDescription")) & "<br>" & _
                                    "<b>BeginDateTime: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("BeginDateTime")) & "<br>" & _
                                    "<b>EndDateTime: </b>" & Convert.ToString(objSeriesInfoTable.Rows(0).Item("EndDateTime")) & "<br>"
                    Return strSeriesInfo
                End If
            Catch ex As Exception

            End Try
        End Get
    End Property

    Private Sub ActivateMenuItem(ByRef mnuItem As WebControl, ByVal strMenu As String, ByRef mi As HtmlGenericControl)
        Try
            mnuItem.Attributes.Item("onmouseover") = "openMenu('" & strMenu & "'); document.getElementById('" & mi.ID & "').className='menuItemOver'"
            mnuItem.Attributes.Item("onmouseout") = "closeMenu('" & strMenu & "'); document.getElementById('" & mi.ID & "').className='menuItem'"
            mi.Attributes.Item("class") = "menuItem"
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.ActivateMenuItem" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Function BlankSeriesTable() As Data.DataTable
        Try
            Dim blankTable As Data.DataTable = OpenODMTable("SELECT CONVERT(VARCHAR(20), [BeginDateTime], 100) + ' - ' + CONVERT(VARCHAR(20), [EndDateTime], 100) AS DateTimeRange, * FROM SeriesCatalog WHERE (Seriesid = 1) and (Seriesid = 2)")
            Dim tempRow As Data.DataRow = blankTable.NewRow
            blankTable.Rows.Add(tempRow)
            Return blankTable
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.BlankSeriesTable" & vbCrLf & ex.Message, ex)
        End Try
    End Function

    Private Sub btnClearGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearGraph.Click
        Try
            objTimeSeries.Clear()
            objProbability.Clear()
            objHistogram.Clear()
            objBoxWhisker.Clear()
            objSummary.Clear()
            mnuFilePrint.Enabled = False
            DeactivateMenuItem(CType(mnuFilePrint, WebControl), "fileMenu", miPrint)
            mnuDataView.Enabled = False
            DeactivateMenuItem(CType(mnuDataView, WebControl), "dataMenu", miView)
            mnuMyDBExport.Enabled = False
            DeactivateMenuItem(CType(mnuMyDBExport, WebControl), "dataMenu", miMyDBExport)
            mnuMetaExport.Enabled = False
            DeactivateMenuItem(CType(mnuMetaExport, WebControl), "dataMenu", miMetaExport)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.btnClearGraph_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnPlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlot.Click
        Try
            Dim i As Integer
            Dim SeriesToPlot(0) As DataSeries
            If (gvSelected.SelectedIndex >= 0) Then
                mobjDataSet = New Data.DataSet
                Dim Selected As Integer = gvSelected.SelectedIndex
                Dim dataRow As Integer = gvSelected.Rows(Selected).DataItemIndex
                Dim objSeries As New DataSeries(CInt(mtblSeries.Rows(dataRow).Item("Seriesid")), Session("Database"))
                SeriesToPlot(i) = objSeries
                'TODO: FINISH HERE ???

                'Get the table of just the values.  Weed out nodata values, keep the CensorCodes, and sort by DataValue
                'FIX - fix the SQL query so that it responds to methodid, QCLevelid, Sourceid
                'First get the nodata value
                Dim strNoDataValue As String
                Dim objNoDataTable As Data.DataTable = OpenODMTable("SELECT NoDataValue FROM Variables WHERE Variableid = '" & objSeries.Variableid & "'", Session("Database"))
                strNoDataValue = Convert.ToString(objNoDataTable.Rows(0).Item("NoDataValue"))
                'mobjDataSet.Tables.Add(OpenTable("SELECT DataValue, CensorCode FROM DataValues WHERE Siteid = " & objSite.id.ToString & " AND Variableid = " & cboVariable.SelectedItem.Value.ToString & " AND (LocalDateTime BETWEEN '01/01/" & BeginYear & "' AND '12/31/" & EndYear & "') AND (MONTH(LocalDateTime) BETWEEN " & Month1 & " AND " & Month2 & ") AND DataValue <> " & strNoDataValue & " ORDER BY DataValue ASC"))

                Dim statQuery As String = _
                   "SELECT DataValue, CensorCode " & _
                   "FROM DataValues RIGHT OUTER JOIN " & _
                   "SeriesCatalog ON DataValues.Siteid = SeriesCatalog.Siteid AND DataValues.Variableid = SeriesCatalog.Variableid AND " & _
                   "DataValues.Methodid = SeriesCatalog.Methodid And DataValues.Sourceid = SeriesCatalog.Sourceid And " & _
                   "DataValues.QualityControlLevelid = SeriesCatalog.QualityControlLevelid" & _
                   " WHERE (SeriesCatalog.Seriesid = '" & objSeries.Seriesid & "')" & " AND (DataValue <> " & strNoDataValue & ")"

                Dim plotQuery As String = "SELECT '" & objSeries.SiteCode & "' AS SiteCode, '" & objSeries.SiteName & "' AS SiteName, '" & objSeries.VariableCode & "' AS VariableCode, '" & objSeries.VariableName & "' AS VariableName, DataValue, LocalDateTime, MONTH(LocalDateTime) AS DateMonth, YEAR(LocalDateTime) AS DateYear, CensorCode " & _
                   "FROM DataValues RIGHT OUTER JOIN " & _
                   "SeriesCatalog ON DataValues.Siteid = SeriesCatalog.Siteid AND DataValues.Variableid = SeriesCatalog.Variableid AND " & _
                   "DataValues.Methodid = SeriesCatalog.Methodid And DataValues.Sourceid = SeriesCatalog.Sourceid And " & _
                   "DataValues.QualityControlLevelid = SeriesCatalog.QualityControlLevelid" & _
                   " WHERE (SeriesCatalog.Seriesid = '" & objSeries.Seriesid & "')" & " AND (DataValue <> " & strNoDataValue & ") AND (CensorCode = 'nc')"

                Dim beginDate As Date
                If Date.TryParse(beginDatePicker.Text, beginDate) = False Then
                    Throw New Exception("Invalid Begin Date")
                End If
                Dim endDate As Date
                If Date.TryParse(endDatePicker.Text, endDate) = False Then
                    Throw New Exception("Invalid End Date")
                End If
                endDate.AddDays(1)
                If beginDate > endDate Then
                    Throw New Exception("Begin Date must be on or before the End Date")
                End If

                statQuery &= " AND (DataValues.LocalDateTime BETWEEN '" & beginDate.ToString("MMM dd yyyy hh:mmtt") & "' AND '" & endDate.ToString("MMM dd yyyy hh:mmtt") & "')"
                plotQuery &= " AND (DataValues.LocalDateTime BETWEEN '" & beginDate.ToString("MMM dd yyyy hh:mmtt") & "' AND '" & endDate.ToString("MMM dd yyyy hh:mmtt") & "')"

                statQuery &= " ORDER BY LocalDateTime"
                plotQuery &= " ORDER BY LocalDateTime"

                Dim statData As Data.DataTable = OpenODMTable(statQuery, Session("Database"))
                statData.TableName = "StatisticsData"
                mobjDataSet.Tables.Add(statData)
                Dim plotData As Data.DataTable = OpenODMTable(plotQuery, Session("Database"))
                plotData.TableName = "PlotData"
                mobjDataSet.Tables.Add(plotData)

                'Update form
                If mobjDataSet.Tables(0).Rows.Count > 0 AndAlso mobjDataSet.Tables(1).Rows.Count > 0 Then
                    'Only plot the graphs if there are 2 or more uncensored observations
                    Session("DataSet") = mobjDataSet
                    If Convert.ToInt32(mobjDataSet.Tables(0).Compute("Count(DataValue)", "CensorCode = 'nc'")) >= 2 Then
                        'TODO: Fix Here ???
                        objTimeSeries.Plot(mobjDataSet.Tables.Item(1), SeriesToPlot(0).SiteName, SeriesToPlot(0).VariableName, SeriesToPlot(0).VariableUnits, objPlotOptions.curr_Options, objSummary.StdDev)
                        objProbability.Plot(mobjDataSet.Tables.Item(1), SeriesToPlot(0).SiteName, SeriesToPlot(0).VariableName, SeriesToPlot(0).VariableUnits, objPlotOptions.curr_Options, objSummary.StdDev)
                        objHistogram.Plot(mobjDataSet.Tables.Item(1), SeriesToPlot(0).SiteName, SeriesToPlot(0).VariableName, SeriesToPlot(0).VariableUnits, objPlotOptions.curr_Options, objSummary.StdDev)
                        objBoxWhisker.Plot(mobjDataSet.Tables.Item(1), SeriesToPlot(0).SiteName, SeriesToPlot(0).VariableName, SeriesToPlot(0).VariableUnits, objPlotOptions.curr_Options, objSummary.StdDev)

                        'TODO: Re-insert Correlation Plot
                        'If (mobjDataSet.Tables.Count >= 3) Then
                        'objCorrelation.Plot(mobjDataSet.Tables.Item(1), mobjDataSet.Tables.Item(3), objPlotOptions.curr_Options)
                        'Else
                        'objCorrelation.ClearHalf()
                        'End If

                        objSummary.Fill(mobjDataSet.Tables.Item(0))
                        mnuFilePrint.Enabled = True
                        ActivateMenuItem(CType(mnuFilePrint, WebControl), "fileMenu", miPrint)
                        mnuDataView.Enabled = True
                        ActivateMenuItem(CType(mnuDataView, WebControl), "dataMenu", miView)
                        mnuMyDBExport.Enabled = True
                        ActivateMenuItem(CType(mnuMyDBExport, WebControl), "dataMenu", miMyDBExport)
                        mnuMetaExport.Enabled = True
                        ActivateMenuItem(CType(mnuMetaExport, WebControl), "dataMenu", miMetaExport)
                    Else  'There is only 1 or zero uncensored values, so populate the summary, but deactivate the plots.
                        objSummary.Fill(mobjDataSet.Tables.Item(0))
                        mnuDataView.Enabled = True
                        ActivateMenuItem(CType(mnuDataView, WebControl), "dataMenu", miView)
                        mnuMyDBExport.Enabled = True
                        ActivateMenuItem(CType(mnuMyDBExport, WebControl), "dataMenu", miMyDBExport)
                        mnuMetaExport.Enabled = True
                        ActivateMenuItem(CType(mnuMetaExport, WebControl), "dataMenu", miMetaExport)
                        'Deactivate the plots
                        objTimeSeries.Clear()
                        objProbability.Clear()
                        objHistogram.Clear()
                        objBoxWhisker.Clear()
                        'TODO: Re-insert Correlation Plot
                        'objCorrelation.Clear()
                        mnuFilePrint.Enabled = False
                        DeactivateMenuItem(CType(mnuFilePrint, WebControl), "fileMenu", miPrint)
                        objSummary.Message("TOO FEW DATA TO PLOT", New Exception)

                    End If
                Else 'For some reason there are no data in the tables to plot
                    btnClearGraph_Click(sender, e)
                    objSummary.Message("NO DATA AVAILABLE", New Exception)
                End If
            End If
        Catch ex As Exception
            objSummary.Message("Error While Plotting Data:" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub Query()
        Try
            Dim used As Boolean = False
            Dim table As New Data.DataTable
            Dim dpq As New Data.DataTable
            Dim datePickerQuery As String = "SELECT MIN(BeginDateTime) as MinDateTime, MAX(EndDateTime)as MaxDateTime FROM SeriesCatalog WHERE "
            Dim sql As String
            Dim odm As String = DatabaseFunctions.GetODMVersion(Session("Database"))
            If odm = "1.1.1" Then
                sql = "SELECT CONVERT(VARCHAR(20), [BeginDateTime], 100) + ' - ' + CONVERT(VARCHAR(20), [EndDateTime], 100) AS DateTimeRange, * FROM SeriesCatalog WHERE "
            Else
                sql = "SELECT CONVERT(VARCHAR(20), [BeginDateTime], 100) + ' - ' + CONVERT(VARCHAR(20), [EndDateTime], 100) AS DateTimeRange, NULL As SiteType, * FROM SeriesCatalog WHERE "
            End If
            If Not (mtblSeries Is Nothing) Then
                mtblSeries.Clear()
            End If
            btnClearGraph_Click(btnClearGraph, New System.EventArgs())

            'Site
            If (ddlSites.SelectedIndex >= 0) Then
                If used Then
                    sql &= " AND "
                    datePickerQuery &= " AND "
                End If
                sql &= "(SiteCode = '" & DatabaseFunctions.FormatParameter(ddlSites.SelectedValue) & "')"
                datePickerQuery &= "(SiteCode = '" & DatabaseFunctions.FormatParameter(ddlSites.SelectedValue) & "')"
                used = True
            End If

            'Variable
            If (ddlVars.SelectedIndex >= 0) Then
                If used Then
                    sql &= " AND "
                    datePickerQuery &= " AND "
                End If
                sql &= "(VariableCode = '" & DatabaseFunctions.FormatParameter(ddlVars.SelectedValue) & "')"
                datePickerQuery &= "(VariableCode = '" & DatabaseFunctions.FormatParameter(ddlVars.SelectedValue) & "')"
                used = True
            End If

            'Source Selection
            If (Not (Session("SourceID") Is Nothing)) Then
                If used Then
                    sql &= " AND "
                    datePickerQuery &= " AND "
                End If
                sql &= "(SourceID = '" & DatabaseFunctions.FormatParameter(Session("SourceID").ToString) & "')"
                datePickerQuery &= "(SourceID = '" & DatabaseFunctions.FormatParameter(Session("SourceID").ToString) & "')"
                used = True
            End If

            'Method
            If (Not (Session("MethodID") Is Nothing)) Then
                If used Then
                    sql &= " AND "
                    datePickerQuery &= " AND "
                End If
                sql &= "(MethodID = '" & DatabaseFunctions.FormatParameter(Session("MethodID").ToString) & "')"
                datePickerQuery &= "(MethodID = '" & DatabaseFunctions.FormatParameter(Session("MethodID").ToString) & "')"
                used = True
            End If

            'Quality Control Level
            If (Not (Session("QualityControlLevelID") Is Nothing)) Then
                If used Then
                    sql &= " AND "
                    datePickerQuery &= " AND "
                End If
                sql &= "(QualityControlLevelID = '" & DatabaseFunctions.FormatParameter(Session("QualityControlLevelID").ToString) & "')"
                datePickerQuery &= "(QualityControlLevelID = '" & DatabaseFunctions.FormatParameter(Session("QualityControlLevelID").ToString) & "')"
                used = True
            End If

            table = DatabaseFunctions.OpenODMTable(sql, Session("Database"))
            mtblSeries = table
            dpq = DatabaseFunctions.OpenODMTable(datePickerQuery, Session("Database"))
            'If (dpq.Rows.Count > 0) Then
            '    beginDatePicker.Text = CDate(dpq.Rows(0).Item("MinDateTime")).ToShortDateString
            '    endDatePicker.Text = CDate(dpq.Rows(0).Item("MaxDateTime")).ToShortDateString
            'End If
            System.Web.HttpContext.Current.Session("SeriesTable") = table
            gvSelected.DataSource = mtblSeries
            gvSelected.DataBind()
            

            If (gvSelected.Rows.Count > 0) Then
                gvSelected.SelectedIndex = 0
            End If

            SetBeginEndDates()
            If Not DatabaseFunctions.GetODMVersion(Session("Database")) = "1.1.1" Then
                If gvSelected.Columns(1).HeaderText = "Site Type" Then
                    gvSelected.Columns(1).Visible = False
                End If
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.Query" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub DeactivateMenuItem(ByRef mnuItem As WebControl, ByVal strMenu As String, ByRef mi As HtmlGenericControl)
        Try
            mnuItem.Attributes.Item("onmouseover") = "openMenu('" & strMenu & "')"
            mnuItem.Attributes.Item("onmouseout") = "closeMenu('" & strMenu & "')"
            mi.Attributes.Item("class") = "menuItemDisabled"
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.DeactivateMenuItem" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub gvselected_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSelected.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(sender, "Select$" & e.Row.RowIndex.ToString))
                SetBeginEndDates()
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.gvselected_RowDataBound" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub gvSelected_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvSelected.SelectedIndexChanged
        Try
            btnClearGraph_Click(sender, e)
            SetBeginEndDates()
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.gvSelected_SelectedIndexChanged" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkBoxWhisker_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBoxWhisker.Click
        Try
            SelectTab(lnkBoxWhisker, mobjGraphs)
            objBoxWhisker.Replot(objPlotOptions.curr_Options)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkBoxWhisker_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkBoxWhisker_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBoxWhisker.Load
        Try
            If Not IsPostBack() Then
                SetInactive(lnkBoxWhisker, tabBoxWhisker)
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkBoxWhisker_Load" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkHistogram_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHistogram.Click
        Try
            SelectTab(lnkHistogram, mobjGraphs)
            objHistogram.Replot(objPlotOptions.curr_Options)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkHistogram_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkHistogram_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHistogram.Load
        Try
            If Not IsPostBack() Then
                SetInactive(lnkHistogram, tabHistogram)
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkHistogram_Load" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkProbability_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProbability.Click
        Try
            SelectTab(lnkProbability, mobjGraphs)
            objProbability.Replot(objPlotOptions.curr_Options)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkProbability_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkProbability_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProbability.Load
        Try
            If Not IsPostBack() Then
                SetInactive(lnkProbability, tabProbability)
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkProbability_Load" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkPlotOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPlotOptions.Click
        Try
            SelectTab(lnkPlotOptions, mobjOptions)
            objTimeSeries.Replot(objPlotOptions.curr_Options)
            objProbability.Replot(objPlotOptions.curr_Options)
            objHistogram.Replot(objPlotOptions.curr_Options)
            objBoxWhisker.Replot(objPlotOptions.curr_Options)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkPlotOptions_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkPlotOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPlotOptions.Load
        Try
            If Not IsPostBack() Then
                SetInactive(lnkPlotOptions, tabPlotOptions)
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkPlotOptions_Load" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkSummary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSummary.Click
        Try
            SelectTab(lnkSummary, mobjOptions)
            objTimeSeries.Replot(objPlotOptions.curr_Options)
            objProbability.Replot(objPlotOptions.curr_Options)
            objHistogram.Replot(objPlotOptions.curr_Options)
            objBoxWhisker.Replot(objPlotOptions.curr_Options)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkSummary_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub lnkTimeSeries_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTimeSeries.Click
        Try
            SelectTab(lnkTimeSeries, mobjGraphs)
            objTimeSeries.Replot(objPlotOptions.curr_Options)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.lnkTimeSeries_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub mnuGraphClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGraphClear.Click
        Try
            btnClearGraph_Click(sender, e)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.mnuGraphClear_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub mnuGraphPlot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGraphPlot.Click
        Try
            btnPlot_Click(sender, e)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.mnuGraphPlot_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub mnuMetaExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMetaExport.Click
        Try
            Dim m_dataseries As New DataSeries(gvSelected.SelectedValue, Session("Database"))
            Dim filename As String
            filename = (m_dataseries.SiteCode & "_" & m_dataseries.VariableCode) _
            .Replace("\", "").Replace("/", "").Replace(":", "") _
            .Replace("*", "").Replace("?", "").Replace("""", "") _
            .Replace("<", "").Replace(">", "").Replace("|", "")

            Session("filename") = filename
            Session("m_dataseries") = m_dataseries
            Dim objResponse As HttpResponse
            objResponse = Response
            ExportFunctions.ExportMetaData(Response, filename, m_dataseries) 'mobjDataSet.Tables.Item(1))
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.mnuMetaExport_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub mnuMyDBExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMyDBExport.Click
        Try
            Dim m_dataseries As New DataSeries(gvSelected.SelectedValue, Session("Database"))
            Dim filename As String
            filename = (m_dataseries.SiteCode & "_" & m_dataseries.VariableCode) _
            .Replace("\", "").Replace("/", "").Replace(":", "") _
            .Replace("*", "").Replace("?", "").Replace("""", "") _
            .Replace("<", "").Replace(">", "").Replace("|", "")

            ExportFunctions.ExportMyDB(Response, filename, m_dataseries) 'mobjDataSet.Tables.Item(1))
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.mnuMyDBExport_Click" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub objPlotOptions_OptionsChanged() Handles objPlotOptions.OptionsChanged
        Try
            objTimeSeries.Replot(objPlotOptions.curr_Options)
            objProbability.Replot(objPlotOptions.curr_Options)
            objHistogram.Replot(objPlotOptions.curr_Options)
            objBoxWhisker.Replot(objPlotOptions.curr_Options)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.objPlotOptions_OptionsChanged" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub Page_Load()
        Try
            Dim blnReplot As Boolean = False

            If (Session("DataSet") Is Nothing) And (Session("SeriesTable") Is Nothing) Then
                'Refresh the session
                Session.Clear()
                If IsPostBack Then blnReplot = True
            End If

            If (Request.Params("Database") Is Nothing) OrElse (Request.Params("Database") = "") Then
                Session("Database") = ConfigurationManager.AppSettings("defaultDatabase")
            Else
                Session("Database") = Request.Params("Database")
            End If

            Dim connstring As String = DatabaseFunctions.GetConnectionString(Session("Database"))
            SelectSite.ConnectionString = connstring
            SelectVar.ConnectionString = connstring
            If Not IsPostBack Then
                If Not (mobjDataSet Is Nothing) Then
                    mobjDataSet.Clear()
                End If
                If Not (mtblSeries Is Nothing) Then
                    mtblSeries.Clear()
                End If
                Session("SeriesTable") = BlankSeriesTable()
                'Main Menu
                ActivateMenuItem(CType(mnuFilePrint, WebControl), "fileMenu", miPrint)
                ActivateMenuItem(CType(mnuFileExit, WebControl), "fileMenu", miExit)
                ActivateMenuItem(CType(mnuGraphPlot, WebControl), "graphMenu", miPlot)
                ActivateMenuItem(CType(mnuGraphClear, WebControl), "graphMenu", miClear)
                ActivateMenuItem(CType(mnuDataView, WebControl), "dataMenu", miView)
                ActivateMenuItem(CType(mnuMyDBExport, WebControl), "dataMenu", miMyDBExport)
                ActivateMenuItem(CType(mnuMetaExport, WebControl), "dataMenu", miMetaExport)

                mFilterString = ""
                Dim used As Boolean = False
                'SourceID
                If (Not (Request.Params("SourceID") Is Nothing)) Then
                    Session.Add("SourceID", Request.Params("SourceID"))
                    Session.Add("ForceQuery", True)
                    If (Not used) Then
                        mFilterString &= " WHERE ([SourceID] = '" & Request.Params("SourceID") & "')"
                    Else
                        mFilterString &= " AND ([SourceID] = '" & Request.Params("SourceID") & "')"
                    End If
                    used = True
                Else
                    Session.Remove("SourceID")
                End If
                'MethodID
                If (Not (Request.Params("MethodID") Is Nothing)) Then
                    Session.Add("MethodID", Request.Params("MethodID"))
                    Session.Add("ForceQuery", True)
                    If (Not used) Then
                        mFilterString &= " WHERE ([MethodID] = '" & Request.Params("MethodID") & "')"
                    Else
                        mFilterString &= " AND ([MethodID] = '" & Request.Params("MethodID") & "')"
                    End If
                    used = True
                Else
                    Session.Remove("MethodID")
                End If
                'QualityControlLevelID
                If (Not (Request.Params("QualityControlLevelID") Is Nothing)) Then
                    Session.Add("QualityControlLevelID", Request.Params("QualityControlLevelID"))
                    Session.Add("ForceQuery", True)
                    If (Not used) Then
                        mFilterString &= " WHERE ([QualityControlLevelID] = '" & Request.Params("QualityControlLevelID") & "')"
                    Else
                        mFilterString &= " AND ([QualityControlLevelID] = '" & Request.Params("QualityControlLevelID") & "')"
                    End If
                    used = True
                Else
                    Session.Remove("QualityControlLevelID")
                End If
                SelectSite.SelectCommand = SelectSiteCommand & mFilterString
                SelectVar.SelectCommand = SelectVarCommand & mFilterString
                SelectSite.DataBind()
            End If

            'Fill the graph tabs collection
            If Session.IsNewSession Then
                objTimeSeries.Clear()
                objProbability.Clear()
                objHistogram.Clear()
                objBoxWhisker.Clear()
            End If
            Dim arrTimeSeries() As Object = {lnkTimeSeries, tabTimeSeries, objTimeSeries}
            Dim arrProbability() As Object = {lnkProbability, tabProbability, objProbability}
            Dim arrHistogram() As Object = {lnkHistogram, tabHistogram, objHistogram}
            Dim arrBoxWhisker() As Object = {lnkBoxWhisker, tabBoxWhisker, objBoxWhisker}
            mobjGraphs.Add(arrTimeSeries)
            mobjGraphs.Add(arrProbability)
            mobjGraphs.Add(arrHistogram)
            mobjGraphs.Add(arrBoxWhisker)

            'Fill the option tabs collection
            Dim arrSummary() As Object = {lnkSummary, tabSummary, objSummary}
            Dim arrPlotOptions() As Object = {lnkPlotOptions, tabPlotOptions, objPlotOptions}
            mobjOptions.Add(arrSummary)
            mobjOptions.Add(arrPlotOptions)

            'Bind session objects
            mtblSeries = CType(Session("SeriesTable"), Data.DataTable)
            If (mtblSeries Is Nothing) OrElse (mtblSeries.Rows.Count < 1) Then
                mtblSeries = BlankSeriesTable()
            End If

            mobjDataSet = CType(Session("DataSet"), Data.DataSet)
        Catch ex As Exception
            'Throw ex
            objSummary.Message("Error Occured in Default.Page_Load" & vbCrLf & ex.Message, ex)
        End Try

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Not (IsPostBack) Then
                'SiteCode
                ddlSites.DataBind()
                If (Not (Request.Params("SiteCode") Is Nothing)) Then
                    ddlSites.SelectedValue = Request.Params("SiteCode")
                    If (ddlSites.Items.Count > 0) AndAlso (ddlSites.SelectedIndex >= 0) Then
                        SelectVar.FilterExpression = "SiteCode='" & ddlSites.SelectedValue & "'"
                        ddlVars.DataBind()
                    End If
                End If
                'Begin/End Date
                SetBeginEndDates()
                'VariableCode
                ddlVars.DataBind()
                If (Not (Request.Params("VariableCode") Is Nothing)) Then
                    ddlVars.SelectedValue = Request.Params("VariableCode")
                End If
                'BeginDate
                If (Not (Request.Params("BeginDate") Is Nothing)) Then
                    beginDatePicker.Text = Request.Params("BeginDate")
                End If
                'EndDate
                If (Not (Request.Params("EndDate") Is Nothing)) Then
                    endDatePicker.Text = Request.Params("EndDate")
                End If
                If (Not (Request.Params("Plot") Is Nothing)) Then
                    If (LCase(Request.Params("Plot")) = "true") Then
                        Session.Add("ForcePlot", True)
                    Else
                        Session.Remove("ForcePlot")
                    End If
                End If
                If (Not (Request.Params("PlotGraph") Is Nothing)) Then
                    If (LCase(Request.Params("PlotGraph")) = "true") Then
                        Session.Add("ForcePlot", True)
                    Else
                        Session.Remove("ForcePlot")
                    End If
                End If
                Query()
                If (Not (Session("ForcePlot") Is Nothing)) AndAlso (Session("ForcePlot") = True) Then
                    btnPlot_Click(sender, e)
                End If
            End If

            Session.Add("TimeSeries", TimeSeries)
            Session.Add("Probability", Probability)
            Session.Add("Histogram", Histogram)
            Session.Add("BoxWhisker", BoxWhisker)
            Session.Add("Options", Options)

        Catch ex As Exception
            objSummary.Message("Error Occured in Default.Page_LoadComplete" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Public Sub refreshPlots()
        Try
            objTimeSeries.Replot(objPlotOptions.curr_Options)
            objProbability.Replot(objPlotOptions.curr_Options)
            objHistogram.Replot(objPlotOptions.curr_Options)
            objBoxWhisker.Replot(objPlotOptions.curr_Options)
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.refreshPlots" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub SelectTab(ByRef objSelectedButton As LinkButton, ByRef objOptions As Collection)
        Try
            Dim arr() As Object
            Dim objLinkButton As LinkButton
            Dim objTab As HtmlGenericControl
            Dim objUserControl As UserControl

            For Each arr In objOptions
                objLinkButton = CType(arr(0), LinkButton)
                objTab = CType(arr(1), HtmlGenericControl)
                objUserControl = CType(arr(2), UserControl)

                'Show the selected tab and hide all others
                If objLinkButton Is objSelectedButton Then
                    objLinkButton.Attributes.Remove("onmouseover")
                    objLinkButton.Attributes.Remove("onmouseout")
                    objTab.Attributes.Item("class") = "activeTab"
                    objUserControl.Visible = True
                Else
                    SetInactive(objLinkButton, objTab)
                    objUserControl.Visible = False
                End If
            Next
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.SelectTab" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub SetInactive(ByRef objLinkButton As LinkButton, ByRef objTab As HtmlGenericControl)
        Try
            objLinkButton.Attributes.Add("onmouseover", "document.getElementById('" & objTab.ID & "').style.backgroundColor = 'White'")
            objLinkButton.Attributes.Add("onmouseout", "document.getElementById('" & objTab.ID & "').style.backgroundColor = '#E6E6E6'")
            objTab.Attributes.Item("class") = "inactiveTab"
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.SetInactive" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub ddlSites_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSites.DataBound
        Try
            If (ddlSites.Items.Count > 0) Then
                'ddlSites.SelectedIndex = 0
                SelectVar.FilterExpression = "SiteCode = '" & ddlSites.SelectedValue & "'"
                ddlVars.DataBind()
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.ddlSites_DataBound" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub ddlSites_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSites.SelectedIndexChanged
        Try
            If (ddlSites.Items.Count > 0) AndAlso (ddlSites.SelectedIndex >= 0) Then
                SelectVar.FilterExpression = "SiteCode='" + ddlSites.SelectedValue & "'"
                ddlVars.DataBind()
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.ddlSites_SelectedIndexChanged" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub ddlVars_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlVars.DataBound
        Try
            If (ddlVars.Items.Count > 0) AndAlso (ddlVars.SelectedIndex >= 0) Then                
                Query()
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.ddlVars_DataBound" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Protected Sub ddlVars_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlVars.SelectedIndexChanged
        Try
            If (ddlVars.Items.Count > 0) AndAlso (ddlVars.SelectedIndex >= 0) Then
                Query()
            End If
        Catch ex As Exception
            objSummary.Message("Error Occured in Default.ddlVars_SelectedIndexChanged" & vbCrLf & ex.Message, ex)
        End Try
    End Sub
    Protected dtFormat As String = Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.ToString()
    Protected Sub SetBeginEndDates()

        Dim MinMaxDT As Data.DataTable = OpenODMTable("SELECT MIN(" & db_fld_SCBeginDT & ") as MinDT, MAX(" & db_fld_SCEndDT & ") as MaxDT FROM " & db_tbl_SeriesCatalog & " WHERE (" & db_fld_SeriesId & "='" & gvSelected.SelectedValue & "') GROUP BY " & db_fld_SeriesId, Session("Database"))
        If (MinMaxDT Is Nothing) OrElse (MinMaxDT.Rows.Count < 1) Then
            beginDatePicker.Text = Today.AddYears(-1).Date().ToString(dtFormat)
            endDatePicker.Text = Today.Date.ToString(dtFormat)
        Else
            beginDatePicker.Text = CDate(MinMaxDT.Rows(0).Item("MinDT")).AddDays(-1).ToString(dtFormat)
            endDatePicker.Text = CDate(MinMaxDT.Rows(0).Item("MaxDT")).AddDays(1).ToString(dtFormat)
        End If

    End Sub

End Class
