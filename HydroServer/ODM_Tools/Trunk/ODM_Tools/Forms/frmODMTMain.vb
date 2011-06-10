Imports ZedGraph
Imports System.Text
Imports System.Collections.Generic
'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

'Written by:
'Justin Berger
'Michelle Hospodarsky
'Jeff Horsburgh

Public Class frmODMTools
    'Last Documented 5/15/07
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents chb_qryGenCat As System.Windows.Forms.CheckBox
	Friend WithEvents lbx_qryGenCat As System.Windows.Forms.ListBox
	Friend WithEvents txt_qryVarName As System.Windows.Forms.TextBox
	Friend WithEvents lbx_qrySites As System.Windows.Forms.ListBox
	Friend WithEvents txt_qrySiteName As System.Windows.Forms.TextBox
	Friend WithEvents chb_qryVar As System.Windows.Forms.CheckBox
	Friend WithEvents chb_qrySite As System.Windows.Forms.CheckBox
	Friend WithEvents rdo_qrySiteList As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qryVarList As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qryVarName As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qrySiteName As System.Windows.Forms.RadioButton
	Friend WithEvents grp_qryOther As System.Windows.Forms.GroupBox
	Friend WithEvents rdo_qryVarCode As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qrySiteCode As System.Windows.Forms.RadioButton
	Friend WithEvents txt_qryVarCode As System.Windows.Forms.TextBox
	Friend WithEvents txt_qrySiteCode As System.Windows.Forms.TextBox
	Friend WithEvents tabctlODMTools As System.Windows.Forms.TabControl
	Friend WithEvents gboxVisDataSel As System.Windows.Forms.GroupBox
	Friend WithEvents gboxDateInfo As System.Windows.Forms.GroupBox
	Friend WithEvents tabctlPlots As System.Windows.Forms.TabControl
	Friend WithEvents tabpgTimeSeries As System.Windows.Forms.TabPage
	Friend WithEvents tabpgProbability As System.Windows.Forms.TabPage
	Friend WithEvents tabpgHistogram As System.Windows.Forms.TabPage
	Friend WithEvents grp_qrySiteSelect As System.Windows.Forms.GroupBox
	Friend WithEvents grp_qryVarSelect As System.Windows.Forms.GroupBox
	Friend WithEvents tabctlPlotOptions As System.Windows.Forms.TabControl
	Friend WithEvents btnPlot As System.Windows.Forms.Button
	Friend WithEvents tabpgBoxPlot As System.Windows.Forms.TabPage
	Friend WithEvents lblEndDate As System.Windows.Forms.Label
	Friend WithEvents lblStartDate As System.Windows.Forms.Label
	Friend WithEvents tabpgSummary As System.Windows.Forms.TabPage
	Friend WithEvents tabpgOptions As System.Windows.Forms.TabPage
	Friend WithEvents dtpVisStartDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents dtpVisEndDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents gboxStatistics As System.Windows.Forms.GroupBox
	Friend WithEvents gboxDivider As System.Windows.Forms.GroupBox
	Friend WithEvents tboxNumObs As System.Windows.Forms.TextBox
	Friend WithEvents lblNumObs As System.Windows.Forms.Label
	Friend WithEvents lblNumCensoredObs As System.Windows.Forms.Label
	Friend WithEvents tboxNumCensoredObs As System.Windows.Forms.TextBox
	Friend WithEvents lblStdDev As System.Windows.Forms.Label
	Friend WithEvents lblMax As System.Windows.Forms.Label
	Friend WithEvents lblCoeffVar As System.Windows.Forms.Label
	Friend WithEvents tboxGeoMean As System.Windows.Forms.TextBox
	Friend WithEvents lblAMean As System.Windows.Forms.Label
	Friend WithEvents tboxAMean As System.Windows.Forms.TextBox
	Friend WithEvents lblGeoMean As System.Windows.Forms.Label
	Friend WithEvents tboxCoeffVar As System.Windows.Forms.TextBox
	Friend WithEvents tboxMin As System.Windows.Forms.TextBox
	Friend WithEvents tboxMax As System.Windows.Forms.TextBox
	Friend WithEvents tboxStdDev As System.Windows.Forms.TextBox
	Friend WithEvents lblMin As System.Windows.Forms.Label
	Friend WithEvents tbox90Perc As System.Windows.Forms.TextBox
	Friend WithEvents tbox75Perc As System.Windows.Forms.TextBox
	Friend WithEvents tbox50Perc As System.Windows.Forms.TextBox
	Friend WithEvents lbl90Perc As System.Windows.Forms.Label
	Friend WithEvents lbl75Perc As System.Windows.Forms.Label
	Friend WithEvents tbox10Perc As System.Windows.Forms.TextBox
	Friend WithEvents tbox25Perc As System.Windows.Forms.TextBox
	Friend WithEvents lbl50Perc As System.Windows.Forms.Label
	Friend WithEvents lbl25Perc As System.Windows.Forms.Label
	Friend WithEvents lbl10Perc As System.Windows.Forms.Label
	Friend WithEvents lblPercentiles As System.Windows.Forms.Label
	Friend WithEvents gboxTSPlotType As System.Windows.Forms.GroupBox
	Friend WithEvents lbx_qryVars As System.Windows.Forms.ListBox
	Friend WithEvents chb_qryValType As System.Windows.Forms.CheckBox
	Friend WithEvents chb_qrySampleMed As System.Windows.Forms.CheckBox
	Friend WithEvents lbx_qryValType As System.Windows.Forms.ListBox
	Friend WithEvents lbx_qrySampleMed As System.Windows.Forms.ListBox
	Friend WithEvents grp_qryVars As System.Windows.Forms.GroupBox
	Friend WithEvents rdo_qryVarOR As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qryVarAND As System.Windows.Forms.RadioButton
	Friend WithEvents grp_qrySites As System.Windows.Forms.GroupBox
	Friend WithEvents rdo_qrySiteAND As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qrySiteOR As System.Windows.Forms.RadioButton
	Friend WithEvents mnuitmFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuitmEdit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuEditDBConnect As System.Windows.Forms.MenuItem
	Friend WithEvents mnuitmTools As System.Windows.Forms.MenuItem
	Friend WithEvents mnuQDRCPlot As System.Windows.Forms.MenuItem
	Friend WithEvents mnuQDRCLine1 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuQDRCSingleExport As System.Windows.Forms.MenuItem
	Friend WithEvents btn_qryExecute As System.Windows.Forms.Button
	Friend WithEvents lv_qryResults As System.Windows.Forms.ListView
	Friend WithEvents gboxTSPlotOptions As System.Windows.Forms.GroupBox
	Friend WithEvents rbtnTSLine As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnTSBoth As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnTSPoint As System.Windows.Forms.RadioButton
	Friend WithEvents gboxBoxPlotOptions As System.Windows.Forms.GroupBox
	Friend WithEvents gboxBPPlotType As System.Windows.Forms.GroupBox
	Friend WithEvents rbtnBPMonthly As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnBPYearly As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnBPSeasonal As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnBPOverall As System.Windows.Forms.RadioButton
	Friend WithEvents tabpgQuery As System.Windows.Forms.TabPage
	Friend WithEvents tabpgVisualize As System.Windows.Forms.TabPage
	Friend WithEvents btnAxisOptions As System.Windows.Forms.Button
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents cmnuQueryDataRightClick As System.Windows.Forms.ContextMenu
	Friend WithEvents sfdExportMyDB As System.Windows.Forms.SaveFileDialog
	Friend WithEvents tabpQuery As System.Windows.Forms.TabPage
	Friend WithEvents mnuQDRCExportMeta As System.Windows.Forms.MenuItem
	Friend WithEvents mnuQDRCViewMeta As System.Windows.Forms.MenuItem
	Friend WithEvents cboxVisVariable As System.Windows.Forms.ComboBox
	Friend WithEvents lblVisSite As System.Windows.Forms.Label
	Friend WithEvents lblVisVariable As System.Windows.Forms.Label
	Friend WithEvents cboxVisSite As System.Windows.Forms.ComboBox
	Friend WithEvents lvVisDataSeries As System.Windows.Forms.ListView
	Friend WithEvents lblVisDataSeries As System.Windows.Forms.Label
	Friend WithEvents lvcolVisDataType As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisTimeUnits As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisTimeSupport As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisVarUnits As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisValueType As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisSampleMedium As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisGenCategory As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisUTCDateRange As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisValueCount As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisLocalDateRange As System.Windows.Forms.ColumnHeader
	Friend WithEvents sfdExportMetadata As System.Windows.Forms.SaveFileDialog
	Friend WithEvents lbx_qryDataType As System.Windows.Forms.ListBox
	Friend WithEvents chb_qryDataType As System.Windows.Forms.CheckBox
	Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuQDRCSelectSingle As System.Windows.Forms.MenuItem
	Friend WithEvents mnuQDRCSelectAll As System.Windows.Forms.MenuItem
	Friend WithEvents btn_qryDataExport As System.Windows.Forms.Button
	Friend WithEvents btn_qryMetaExport As System.Windows.Forms.Button
	Friend WithEvents mnuQDRCSelectNone As System.Windows.Forms.MenuItem
	Friend WithEvents ckboxUseCensoredData As System.Windows.Forms.CheckBox
    Friend WithEvents zg5TimeSeries As ZedGraph.ZedGraphControl
	Friend WithEvents zg5Probability As ZedGraph.ZedGraphControl
	Friend WithEvents zg5Histogram As ZedGraph.ZedGraphControl
	Friend WithEvents zg5BoxPlot As ZedGraph.ZedGraphControl
	Friend WithEvents gboxHistPlotOptions As System.Windows.Forms.GroupBox
	Friend WithEvents gboxHPNumBarSettings As System.Windows.Forms.GroupBox
	Friend WithEvents ckboxHistSetNumBins As System.Windows.Forms.CheckBox
	Friend WithEvents lblHPNumBins As System.Windows.Forms.Label
	Friend WithEvents tboxHPNumBins As System.Windows.Forms.TextBox
	Friend WithEvents rbtnHPDiscreteBreakVals As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnHPExactNumBins As System.Windows.Forms.RadioButton
	Friend WithEvents tabpgEdit As System.Windows.Forms.TabPage
	Friend WithEvents gboxEditDataSel As System.Windows.Forms.GroupBox
	Friend WithEvents lvEditDataSeries As System.Windows.Forms.ListView
	Friend WithEvents lvcolEditGenCategory As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditVarUnits As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditTimeSupport As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditTimeUnits As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditSampleMedium As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditValueType As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditDataType As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditLocalDateRange As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditUTCDateRange As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditValueCount As System.Windows.Forms.ColumnHeader
	Friend WithEvents lblEditDataSeries As System.Windows.Forms.Label
	Friend WithEvents cboxEditVariable As System.Windows.Forms.ComboBox
	Friend WithEvents lblEditSite As System.Windows.Forms.Label
	Friend WithEvents lblEditVariable As System.Windows.Forms.Label
	Friend WithEvents cboxEditSite As System.Windows.Forms.ComboBox
	Friend WithEvents btnBPViewDesc As System.Windows.Forms.Button
	Friend WithEvents splitpnlEdit_PlotData As System.Windows.Forms.SplitContainer
	Friend WithEvents btnEditRestoreDefaults As System.Windows.Forms.Button
	Friend WithEvents btnEditApplyChanges As System.Windows.Forms.Button
	Friend WithEvents dgvEditTable As System.Windows.Forms.DataGridView
	Friend WithEvents btnEditDataAdjust As System.Windows.Forms.Button
	Friend WithEvents btnEditDataAdd As System.Windows.Forms.Button
	Friend WithEvents btnEditDataRemove As System.Windows.Forms.Button
	Friend WithEvents btnEditDataFlag As System.Windows.Forms.Button
	Friend WithEvents btnEditDataInterpolate As System.Windows.Forms.Button
	Friend WithEvents gboxEditFilter As System.Windows.Forms.GroupBox
	Friend WithEvents rbtnEditDFValueThreshold As System.Windows.Forms.RadioButton
	Friend WithEvents gboxEditDFValueThreshold As System.Windows.Forms.GroupBox
	Friend WithEvents tboxEditDFVTLess As System.Windows.Forms.TextBox
	Friend WithEvents ckboxEditDFVTLess As System.Windows.Forms.CheckBox
	Friend WithEvents tboxEditDFVTGreater As System.Windows.Forms.TextBox
	Friend WithEvents ckboxEditDFVTGreater As System.Windows.Forms.CheckBox
	Friend WithEvents rbtnEditDFDataGap As System.Windows.Forms.RadioButton
	Friend WithEvents gboxEditDFDataGaps As System.Windows.Forms.GroupBox
	Friend WithEvents rbtnEditDFDate As System.Windows.Forms.RadioButton
	Friend WithEvents btnEditDFApplyFilter As System.Windows.Forms.Button
	Friend WithEvents btnEditDFClearSel As System.Windows.Forms.Button
	Friend WithEvents tboxEditDFVTChange As System.Windows.Forms.TextBox
	Friend WithEvents rbtnEditDFVTChange As System.Windows.Forms.RadioButton
	Friend WithEvents gboxEditDFDate As System.Windows.Forms.GroupBox
	Friend WithEvents dtpEditDFDAfter As System.Windows.Forms.DateTimePicker
	Friend WithEvents dtpEditDFDBefore As System.Windows.Forms.DateTimePicker
	Friend WithEvents ckboxEditDFDAfter As System.Windows.Forms.CheckBox
	Friend WithEvents ckboxEditDFDBefore As System.Windows.Forms.CheckBox
	Friend WithEvents btnEditDataDeriveNewDS As System.Windows.Forms.Button
	Friend WithEvents lvcolVisQCLevel As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisMethod As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditQCLevel As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditMethod As System.Windows.Forms.ColumnHeader
	Friend WithEvents ttipEdit As System.Windows.Forms.ToolTip
	Friend WithEvents txt_qryMethod As System.Windows.Forms.TextBox
	Friend WithEvents chb_qryQCLevel As System.Windows.Forms.CheckBox
	Friend WithEvents lbx_qryQCLevel As System.Windows.Forms.ListBox
	Friend WithEvents chb_qryMethod As System.Windows.Forms.CheckBox
	Friend WithEvents grp_qrySources As System.Windows.Forms.GroupBox
	Friend WithEvents rdo_qrySrcDesc As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qrySrcOrg As System.Windows.Forms.RadioButton
	Friend WithEvents txt_qrySrcDesc As System.Windows.Forms.TextBox
	Friend WithEvents txt_qrySrcOrg As System.Windows.Forms.TextBox
	Friend WithEvents lvcolEditOrganization As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditSourceDesc As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisOrganization As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisSourceDesc As System.Windows.Forms.ColumnHeader
	Friend WithEvents dtp_qryTimeBegin As System.Windows.Forms.DateTimePicker
	Friend WithEvents lbl_qryTimeBegin As System.Windows.Forms.Label
	Friend WithEvents dtp_qryTimeEnd As System.Windows.Forms.DateTimePicker
	Friend WithEvents chb_qryNumObs As System.Windows.Forms.CheckBox
	Friend WithEvents chb_qryDate As System.Windows.Forms.CheckBox
	Friend WithEvents num_qryObs As System.Windows.Forms.NumericUpDown
	Friend WithEvents lbl_qryTimeEnd As System.Windows.Forms.Label
	Friend WithEvents chb_qrySrc As System.Windows.Forms.CheckBox
	Friend WithEvents col_qrySiteCodeName As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryVarCodeName As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryVarUnits As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryGenCat As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryValType As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qrySampleMed As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryDataType As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryQCLevel As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryMethodDesc As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryNumObs As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryDateTime As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryOrg As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qrySrcDesc As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryTimeSupport As System.Windows.Forms.ColumnHeader
	Friend WithEvents grp_qrySrcSelect As System.Windows.Forms.GroupBox
	Friend WithEvents rdo_qrySrcOR As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qrySrcAND As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qryNumObsL As System.Windows.Forms.RadioButton
	Friend WithEvents rdo_qryNumObsG As System.Windows.Forms.RadioButton
	Friend WithEvents grp_qryNumObs As System.Windows.Forms.Panel
	Friend WithEvents mnuQDRCEdit As System.Windows.Forms.MenuItem
	Friend WithEvents col_qryTimeSupportUnits As System.Windows.Forms.ColumnHeader
	Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuitmHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuitmHelpAbout As System.Windows.Forms.MenuItem
	Friend WithEvents tboxEditDFDGValue As System.Windows.Forms.TextBox
	Friend WithEvents lblEditDFDGValue As System.Windows.Forms.Label
	Friend WithEvents cboxEditDFDGTimePeriod As System.Windows.Forms.ComboBox
    Friend WithEvents mnuToolsReloadQuery As System.Windows.Forms.MenuItem
    Friend WithEvents mnuToolsIntCVUpdate As System.Windows.Forms.MenuItem
    Friend WithEvents mnuToolsOptions As System.Windows.Forms.MenuItem
    Friend WithEvents mnuToolsQuickCVUpdate As System.Windows.Forms.MenuItem
	Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
	Friend WithEvents col_qrySpeciation As System.Windows.Forms.ColumnHeader
	Friend WithEvents col_qryCitation As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisSpeciation As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolVisCitation As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvcolEditSpeciation As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcolEditCitation As System.Windows.Forms.ColumnHeader
    Friend WithEvents zg5EditPlot As ZedGraph.ZedGraphControl
    'Friend WithEvents zg5EditPlot As ODM_Tools.cTimeSeriesPlot
    Friend WithEvents lblEditDFDGTimePeriod As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmODMTools))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.mnuMain = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuitmFile = New System.Windows.Forms.MenuItem
        Me.mnuFileExit = New System.Windows.Forms.MenuItem
        Me.mnuitmEdit = New System.Windows.Forms.MenuItem
        Me.mnuEditDBConnect = New System.Windows.Forms.MenuItem
        Me.mnuitmTools = New System.Windows.Forms.MenuItem
        Me.mnuToolsIntCVUpdate = New System.Windows.Forms.MenuItem
        Me.mnuToolsQuickCVUpdate = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.mnuToolsReloadQuery = New System.Windows.Forms.MenuItem
        Me.mnuToolsOptions = New System.Windows.Forms.MenuItem
        Me.mnuitmHelp = New System.Windows.Forms.MenuItem
        Me.mnuitmHelpAbout = New System.Windows.Forms.MenuItem
        Me.tabctlODMTools = New System.Windows.Forms.TabControl
        Me.tabpgQuery = New System.Windows.Forms.TabPage
        Me.btn_qryMetaExport = New System.Windows.Forms.Button
        Me.btn_qryExecute = New System.Windows.Forms.Button
        Me.btn_qryDataExport = New System.Windows.Forms.Button
        Me.chb_qrySrc = New System.Windows.Forms.CheckBox
        Me.chb_qryVar = New System.Windows.Forms.CheckBox
        Me.grp_qryVars = New System.Windows.Forms.GroupBox
        Me.lbx_qryVars = New System.Windows.Forms.ListBox
        Me.txt_qryVarCode = New System.Windows.Forms.TextBox
        Me.txt_qryVarName = New System.Windows.Forms.TextBox
        Me.rdo_qryVarCode = New System.Windows.Forms.RadioButton
        Me.rdo_qryVarName = New System.Windows.Forms.RadioButton
        Me.rdo_qryVarList = New System.Windows.Forms.RadioButton
        Me.grp_qryVarSelect = New System.Windows.Forms.GroupBox
        Me.rdo_qryVarOR = New System.Windows.Forms.RadioButton
        Me.rdo_qryVarAND = New System.Windows.Forms.RadioButton
        Me.chb_qrySite = New System.Windows.Forms.CheckBox
        Me.grp_qrySites = New System.Windows.Forms.GroupBox
        Me.lbx_qrySites = New System.Windows.Forms.ListBox
        Me.txt_qrySiteCode = New System.Windows.Forms.TextBox
        Me.txt_qrySiteName = New System.Windows.Forms.TextBox
        Me.rdo_qrySiteCode = New System.Windows.Forms.RadioButton
        Me.rdo_qrySiteName = New System.Windows.Forms.RadioButton
        Me.rdo_qrySiteList = New System.Windows.Forms.RadioButton
        Me.grp_qrySiteSelect = New System.Windows.Forms.GroupBox
        Me.rdo_qrySiteAND = New System.Windows.Forms.RadioButton
        Me.rdo_qrySiteOR = New System.Windows.Forms.RadioButton
        Me.grp_qrySources = New System.Windows.Forms.GroupBox
        Me.txt_qrySrcDesc = New System.Windows.Forms.TextBox
        Me.txt_qrySrcOrg = New System.Windows.Forms.TextBox
        Me.rdo_qrySrcDesc = New System.Windows.Forms.RadioButton
        Me.rdo_qrySrcOrg = New System.Windows.Forms.RadioButton
        Me.grp_qrySrcSelect = New System.Windows.Forms.GroupBox
        Me.rdo_qrySrcOR = New System.Windows.Forms.RadioButton
        Me.rdo_qrySrcAND = New System.Windows.Forms.RadioButton
        Me.grp_qryOther = New System.Windows.Forms.GroupBox
        Me.dtp_qryTimeBegin = New System.Windows.Forms.DateTimePicker
        Me.dtp_qryTimeEnd = New System.Windows.Forms.DateTimePicker
        Me.txt_qryMethod = New System.Windows.Forms.TextBox
        Me.lbx_qryQCLevel = New System.Windows.Forms.ListBox
        Me.lbx_qryDataType = New System.Windows.Forms.ListBox
        Me.lbx_qryValType = New System.Windows.Forms.ListBox
        Me.lbx_qrySampleMed = New System.Windows.Forms.ListBox
        Me.lbx_qryGenCat = New System.Windows.Forms.ListBox
        Me.lbl_qryTimeBegin = New System.Windows.Forms.Label
        Me.chb_qryNumObs = New System.Windows.Forms.CheckBox
        Me.chb_qryDate = New System.Windows.Forms.CheckBox
        Me.lbl_qryTimeEnd = New System.Windows.Forms.Label
        Me.chb_qryMethod = New System.Windows.Forms.CheckBox
        Me.chb_qryQCLevel = New System.Windows.Forms.CheckBox
        Me.chb_qryDataType = New System.Windows.Forms.CheckBox
        Me.chb_qryValType = New System.Windows.Forms.CheckBox
        Me.chb_qrySampleMed = New System.Windows.Forms.CheckBox
        Me.chb_qryGenCat = New System.Windows.Forms.CheckBox
        Me.grp_qryNumObs = New System.Windows.Forms.Panel
        Me.rdo_qryNumObsG = New System.Windows.Forms.RadioButton
        Me.num_qryObs = New System.Windows.Forms.NumericUpDown
        Me.rdo_qryNumObsL = New System.Windows.Forms.RadioButton
        Me.lv_qryResults = New System.Windows.Forms.ListView
        Me.col_qrySiteCodeName = New System.Windows.Forms.ColumnHeader
        Me.col_qryVarCodeName = New System.Windows.Forms.ColumnHeader
        Me.col_qrySpeciation = New System.Windows.Forms.ColumnHeader
        Me.col_qryVarUnits = New System.Windows.Forms.ColumnHeader
        Me.col_qryGenCat = New System.Windows.Forms.ColumnHeader
        Me.col_qryValType = New System.Windows.Forms.ColumnHeader
        Me.col_qrySampleMed = New System.Windows.Forms.ColumnHeader
        Me.col_qryDataType = New System.Windows.Forms.ColumnHeader
        Me.col_qryQCLevel = New System.Windows.Forms.ColumnHeader
        Me.col_qryMethodDesc = New System.Windows.Forms.ColumnHeader
        Me.col_qryNumObs = New System.Windows.Forms.ColumnHeader
        Me.col_qryDateTime = New System.Windows.Forms.ColumnHeader
        Me.col_qryOrg = New System.Windows.Forms.ColumnHeader
        Me.col_qrySrcDesc = New System.Windows.Forms.ColumnHeader
        Me.col_qryCitation = New System.Windows.Forms.ColumnHeader
        Me.col_qryTimeSupport = New System.Windows.Forms.ColumnHeader
        Me.col_qryTimeSupportUnits = New System.Windows.Forms.ColumnHeader
        Me.tabpgVisualize = New System.Windows.Forms.TabPage
        Me.btnPlot = New System.Windows.Forms.Button
        Me.tabctlPlotOptions = New System.Windows.Forms.TabControl
        Me.tabpgSummary = New System.Windows.Forms.TabPage
        Me.gboxStatistics = New System.Windows.Forms.GroupBox
        Me.lblPercentiles = New System.Windows.Forms.Label
        Me.tbox90Perc = New System.Windows.Forms.TextBox
        Me.tbox75Perc = New System.Windows.Forms.TextBox
        Me.tbox50Perc = New System.Windows.Forms.TextBox
        Me.lbl90Perc = New System.Windows.Forms.Label
        Me.lbl75Perc = New System.Windows.Forms.Label
        Me.tbox10Perc = New System.Windows.Forms.TextBox
        Me.tbox25Perc = New System.Windows.Forms.TextBox
        Me.lbl50Perc = New System.Windows.Forms.Label
        Me.lbl25Perc = New System.Windows.Forms.Label
        Me.lbl10Perc = New System.Windows.Forms.Label
        Me.lblStdDev = New System.Windows.Forms.Label
        Me.lblMax = New System.Windows.Forms.Label
        Me.lblCoeffVar = New System.Windows.Forms.Label
        Me.tboxGeoMean = New System.Windows.Forms.TextBox
        Me.lblAMean = New System.Windows.Forms.Label
        Me.tboxAMean = New System.Windows.Forms.TextBox
        Me.lblGeoMean = New System.Windows.Forms.Label
        Me.tboxCoeffVar = New System.Windows.Forms.TextBox
        Me.tboxMin = New System.Windows.Forms.TextBox
        Me.gboxDivider = New System.Windows.Forms.GroupBox
        Me.tboxMax = New System.Windows.Forms.TextBox
        Me.tboxStdDev = New System.Windows.Forms.TextBox
        Me.lblMin = New System.Windows.Forms.Label
        Me.lblNumCensoredObs = New System.Windows.Forms.Label
        Me.lblNumObs = New System.Windows.Forms.Label
        Me.tboxNumObs = New System.Windows.Forms.TextBox
        Me.tboxNumCensoredObs = New System.Windows.Forms.TextBox
        Me.ckboxUseCensoredData = New System.Windows.Forms.CheckBox
        Me.tabpgOptions = New System.Windows.Forms.TabPage
        Me.gboxHistPlotOptions = New System.Windows.Forms.GroupBox
        Me.ckboxHistSetNumBins = New System.Windows.Forms.CheckBox
        Me.gboxHPNumBarSettings = New System.Windows.Forms.GroupBox
        Me.rbtnHPExactNumBins = New System.Windows.Forms.RadioButton
        Me.rbtnHPDiscreteBreakVals = New System.Windows.Forms.RadioButton
        Me.tboxHPNumBins = New System.Windows.Forms.TextBox
        Me.lblHPNumBins = New System.Windows.Forms.Label
        Me.btnAxisOptions = New System.Windows.Forms.Button
        Me.gboxBoxPlotOptions = New System.Windows.Forms.GroupBox
        Me.gboxBPPlotType = New System.Windows.Forms.GroupBox
        Me.btnBPViewDesc = New System.Windows.Forms.Button
        Me.rbtnBPOverall = New System.Windows.Forms.RadioButton
        Me.rbtnBPMonthly = New System.Windows.Forms.RadioButton
        Me.rbtnBPYearly = New System.Windows.Forms.RadioButton
        Me.rbtnBPSeasonal = New System.Windows.Forms.RadioButton
        Me.gboxTSPlotOptions = New System.Windows.Forms.GroupBox
        Me.gboxTSPlotType = New System.Windows.Forms.GroupBox
        Me.rbtnTSLine = New System.Windows.Forms.RadioButton
        Me.rbtnTSBoth = New System.Windows.Forms.RadioButton
        Me.rbtnTSPoint = New System.Windows.Forms.RadioButton
        Me.gboxDateInfo = New System.Windows.Forms.GroupBox
        Me.dtpVisEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpVisStartDate = New System.Windows.Forms.DateTimePicker
        Me.lblEndDate = New System.Windows.Forms.Label
        Me.lblStartDate = New System.Windows.Forms.Label
        Me.gboxVisDataSel = New System.Windows.Forms.GroupBox
        Me.lvVisDataSeries = New System.Windows.Forms.ListView
        Me.lvcolVisGenCategory = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisSpeciation = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisVarUnits = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisTimeSupport = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisTimeUnits = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisSampleMedium = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisValueType = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisDataType = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisQCLevel = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisMethod = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisOrganization = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisSourceDesc = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisCitation = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisLocalDateRange = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisUTCDateRange = New System.Windows.Forms.ColumnHeader
        Me.lvcolVisValueCount = New System.Windows.Forms.ColumnHeader
        Me.lblVisDataSeries = New System.Windows.Forms.Label
        Me.cboxVisVariable = New System.Windows.Forms.ComboBox
        Me.lblVisSite = New System.Windows.Forms.Label
        Me.lblVisVariable = New System.Windows.Forms.Label
        Me.cboxVisSite = New System.Windows.Forms.ComboBox
        Me.tabctlPlots = New System.Windows.Forms.TabControl
        Me.tabpgTimeSeries = New System.Windows.Forms.TabPage
        Me.zg5TimeSeries = New ZedGraph.ZedGraphControl
        Me.tabpgProbability = New System.Windows.Forms.TabPage
        Me.zg5Probability = New ZedGraph.ZedGraphControl
        Me.tabpgHistogram = New System.Windows.Forms.TabPage
        Me.zg5Histogram = New ZedGraph.ZedGraphControl
        Me.tabpgBoxPlot = New System.Windows.Forms.TabPage
        Me.zg5BoxPlot = New ZedGraph.ZedGraphControl
        Me.tabpgEdit = New System.Windows.Forms.TabPage
        Me.btnEditDataDeriveNewDS = New System.Windows.Forms.Button
        Me.gboxEditFilter = New System.Windows.Forms.GroupBox
        Me.rbtnEditDFDate = New System.Windows.Forms.RadioButton
        Me.gboxEditDFDate = New System.Windows.Forms.GroupBox
        Me.dtpEditDFDBefore = New System.Windows.Forms.DateTimePicker
        Me.ckboxEditDFDBefore = New System.Windows.Forms.CheckBox
        Me.dtpEditDFDAfter = New System.Windows.Forms.DateTimePicker
        Me.ckboxEditDFDAfter = New System.Windows.Forms.CheckBox
        Me.rbtnEditDFValueThreshold = New System.Windows.Forms.RadioButton
        Me.gboxEditDFValueThreshold = New System.Windows.Forms.GroupBox
        Me.tboxEditDFVTGreater = New System.Windows.Forms.TextBox
        Me.ckboxEditDFVTGreater = New System.Windows.Forms.CheckBox
        Me.tboxEditDFVTLess = New System.Windows.Forms.TextBox
        Me.ckboxEditDFVTLess = New System.Windows.Forms.CheckBox
        Me.rbtnEditDFDataGap = New System.Windows.Forms.RadioButton
        Me.gboxEditDFDataGaps = New System.Windows.Forms.GroupBox
        Me.cboxEditDFDGTimePeriod = New System.Windows.Forms.ComboBox
        Me.lblEditDFDGTimePeriod = New System.Windows.Forms.Label
        Me.tboxEditDFDGValue = New System.Windows.Forms.TextBox
        Me.lblEditDFDGValue = New System.Windows.Forms.Label
        Me.btnEditDFApplyFilter = New System.Windows.Forms.Button
        Me.btnEditDFClearSel = New System.Windows.Forms.Button
        Me.tboxEditDFVTChange = New System.Windows.Forms.TextBox
        Me.rbtnEditDFVTChange = New System.Windows.Forms.RadioButton
        Me.btnEditDataFlag = New System.Windows.Forms.Button
        Me.btnEditDataInterpolate = New System.Windows.Forms.Button
        Me.btnEditDataAdd = New System.Windows.Forms.Button
        Me.btnEditDataRemove = New System.Windows.Forms.Button
        Me.btnEditDataAdjust = New System.Windows.Forms.Button
        Me.btnEditRestoreDefaults = New System.Windows.Forms.Button
        Me.btnEditApplyChanges = New System.Windows.Forms.Button
        Me.splitpnlEdit_PlotData = New System.Windows.Forms.SplitContainer
        Me.zg5EditPlot = New ZedGraph.ZedGraphControl
        Me.dgvEditTable = New System.Windows.Forms.DataGridView
        Me.gboxEditDataSel = New System.Windows.Forms.GroupBox
        Me.lvEditDataSeries = New System.Windows.Forms.ListView
        Me.lvcolEditGenCategory = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditSpeciation = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditVarUnits = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditTimeSupport = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditTimeUnits = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditSampleMedium = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditValueType = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditDataType = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditQCLevel = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditMethod = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditOrganization = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditSourceDesc = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditCitation = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditLocalDateRange = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditUTCDateRange = New System.Windows.Forms.ColumnHeader
        Me.lvcolEditValueCount = New System.Windows.Forms.ColumnHeader
        Me.lblEditDataSeries = New System.Windows.Forms.Label
        Me.cboxEditVariable = New System.Windows.Forms.ComboBox
        Me.lblEditSite = New System.Windows.Forms.Label
        Me.lblEditVariable = New System.Windows.Forms.Label
        Me.cboxEditSite = New System.Windows.Forms.ComboBox
        Me.cmnuQueryDataRightClick = New System.Windows.Forms.ContextMenu
        Me.mnuQDRCPlot = New System.Windows.Forms.MenuItem
        Me.mnuQDRCEdit = New System.Windows.Forms.MenuItem
        Me.mnuQDRCViewMeta = New System.Windows.Forms.MenuItem
        Me.mnuQDRCLine1 = New System.Windows.Forms.MenuItem
        Me.mnuQDRCSingleExport = New System.Windows.Forms.MenuItem
        Me.mnuQDRCExportMeta = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuQDRCSelectSingle = New System.Windows.Forms.MenuItem
        Me.mnuQDRCSelectAll = New System.Windows.Forms.MenuItem
        Me.mnuQDRCSelectNone = New System.Windows.Forms.MenuItem
        Me.sfdExportMyDB = New System.Windows.Forms.SaveFileDialog
        Me.sfdExportMetadata = New System.Windows.Forms.SaveFileDialog
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.ttipEdit = New System.Windows.Forms.ToolTip(Me.components)
        Me.tabctlODMTools.SuspendLayout()
        Me.tabpgQuery.SuspendLayout()
        Me.grp_qryVars.SuspendLayout()
        Me.grp_qryVarSelect.SuspendLayout()
        Me.grp_qrySites.SuspendLayout()
        Me.grp_qrySiteSelect.SuspendLayout()
        Me.grp_qrySources.SuspendLayout()
        Me.grp_qrySrcSelect.SuspendLayout()
        Me.grp_qryOther.SuspendLayout()
        Me.grp_qryNumObs.SuspendLayout()
        CType(Me.num_qryObs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpgVisualize.SuspendLayout()
        Me.tabctlPlotOptions.SuspendLayout()
        Me.tabpgSummary.SuspendLayout()
        Me.gboxStatistics.SuspendLayout()
        Me.tabpgOptions.SuspendLayout()
        Me.gboxHistPlotOptions.SuspendLayout()
        Me.gboxHPNumBarSettings.SuspendLayout()
        Me.gboxBoxPlotOptions.SuspendLayout()
        Me.gboxBPPlotType.SuspendLayout()
        Me.gboxTSPlotOptions.SuspendLayout()
        Me.gboxTSPlotType.SuspendLayout()
        Me.gboxDateInfo.SuspendLayout()
        Me.gboxVisDataSel.SuspendLayout()
        Me.tabctlPlots.SuspendLayout()
        Me.tabpgTimeSeries.SuspendLayout()
        Me.tabpgProbability.SuspendLayout()
        Me.tabpgHistogram.SuspendLayout()
        Me.tabpgBoxPlot.SuspendLayout()
        Me.tabpgEdit.SuspendLayout()
        Me.gboxEditFilter.SuspendLayout()
        Me.gboxEditDFDate.SuspendLayout()
        Me.gboxEditDFValueThreshold.SuspendLayout()
        Me.gboxEditDFDataGaps.SuspendLayout()
        Me.splitpnlEdit_PlotData.Panel1.SuspendLayout()
        Me.splitpnlEdit_PlotData.Panel2.SuspendLayout()
        Me.splitpnlEdit_PlotData.SuspendLayout()
        CType(Me.dgvEditTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxEditDataSel.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuitmFile, Me.mnuitmEdit, Me.mnuitmTools, Me.mnuitmHelp})
        '
        'mnuitmFile
        '
        Me.mnuitmFile.Index = 0
        Me.mnuitmFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileExit})
        Me.mnuitmFile.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.mnuitmFile.Text = "File"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Index = 0
        Me.mnuFileExit.Shortcut = System.Windows.Forms.Shortcut.CtrlQ
        Me.mnuFileExit.Text = "Exit"
        '
        'mnuitmEdit
        '
        Me.mnuitmEdit.Index = 1
        Me.mnuitmEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEditDBConnect})
        Me.mnuitmEdit.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mnuitmEdit.Text = "Edit"
        '
        'mnuEditDBConnect
        '
        Me.mnuEditDBConnect.Index = 0
        Me.mnuEditDBConnect.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mnuEditDBConnect.Text = "Database Connection..."
        '
        'mnuitmTools
        '
        Me.mnuitmTools.Index = 2
        Me.mnuitmTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuToolsIntCVUpdate, Me.mnuToolsQuickCVUpdate, Me.MenuItem4, Me.mnuToolsReloadQuery, Me.mnuToolsOptions})
        Me.mnuitmTools.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.mnuitmTools.Text = "Tools"
        '
        'mnuToolsIntCVUpdate
        '
        Me.mnuToolsIntCVUpdate.Index = 0
        Me.mnuToolsIntCVUpdate.Text = "Interactive CV Update"
        '
        'mnuToolsQuickCVUpdate
        '
        Me.mnuToolsQuickCVUpdate.Index = 1
        Me.mnuToolsQuickCVUpdate.Text = "Quick CV Update"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "-"
        '
        'mnuToolsReloadQuery
        '
        Me.mnuToolsReloadQuery.Index = 3
        Me.mnuToolsReloadQuery.Text = "Reload Query Items"
        '
        'mnuToolsOptions
        '
        Me.mnuToolsOptions.Index = 4
        Me.mnuToolsOptions.Text = "Options..."
        '
        'mnuitmHelp
        '
        Me.mnuitmHelp.Index = 3
        Me.mnuitmHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuitmHelpAbout})
        Me.mnuitmHelp.Shortcut = System.Windows.Forms.Shortcut.CtrlH
        Me.mnuitmHelp.Text = "Help"
        '
        'mnuitmHelpAbout
        '
        Me.mnuitmHelpAbout.Index = 0
        Me.mnuitmHelpAbout.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mnuitmHelpAbout.Text = "About..."
        '
        'tabctlODMTools
        '
        Me.tabctlODMTools.Controls.Add(Me.tabpgQuery)
        Me.tabctlODMTools.Controls.Add(Me.tabpgVisualize)
        Me.tabctlODMTools.Controls.Add(Me.tabpgEdit)
        Me.tabctlODMTools.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabctlODMTools.Location = New System.Drawing.Point(0, 0)
        Me.tabctlODMTools.Name = "tabctlODMTools"
        Me.tabctlODMTools.SelectedIndex = 0
        Me.tabctlODMTools.Size = New System.Drawing.Size(792, 545)
        Me.tabctlODMTools.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabctlODMTools.TabIndex = 0
        '
        'tabpgQuery
        '
        Me.tabpgQuery.Controls.Add(Me.btn_qryMetaExport)
        Me.tabpgQuery.Controls.Add(Me.btn_qryExecute)
        Me.tabpgQuery.Controls.Add(Me.btn_qryDataExport)
        Me.tabpgQuery.Controls.Add(Me.chb_qrySrc)
        Me.tabpgQuery.Controls.Add(Me.chb_qryVar)
        Me.tabpgQuery.Controls.Add(Me.grp_qryVars)
        Me.tabpgQuery.Controls.Add(Me.chb_qrySite)
        Me.tabpgQuery.Controls.Add(Me.grp_qrySites)
        Me.tabpgQuery.Controls.Add(Me.grp_qrySources)
        Me.tabpgQuery.Controls.Add(Me.grp_qryOther)
        Me.tabpgQuery.Controls.Add(Me.lv_qryResults)
        Me.tabpgQuery.Location = New System.Drawing.Point(4, 22)
        Me.tabpgQuery.Name = "tabpgQuery"
        Me.tabpgQuery.Size = New System.Drawing.Size(784, 519)
        Me.tabpgQuery.TabIndex = 0
        Me.tabpgQuery.Text = "Query"
        Me.tabpgQuery.UseVisualStyleBackColor = True
        '
        'btn_qryMetaExport
        '
        Me.btn_qryMetaExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_qryMetaExport.Enabled = False
        Me.btn_qryMetaExport.Location = New System.Drawing.Point(332, 492)
        Me.btn_qryMetaExport.Name = "btn_qryMetaExport"
        Me.btn_qryMetaExport.Size = New System.Drawing.Size(144, 24)
        Me.btn_qryMetaExport.TabIndex = 9
        Me.btn_qryMetaExport.Text = "Export Checked &Metadata"
        '
        'btn_qryExecute
        '
        Me.btn_qryExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_qryExecute.Enabled = False
        Me.btn_qryExecute.Location = New System.Drawing.Point(632, 492)
        Me.btn_qryExecute.Name = "btn_qryExecute"
        Me.btn_qryExecute.Size = New System.Drawing.Size(144, 24)
        Me.btn_qryExecute.TabIndex = 7
        Me.btn_qryExecute.Text = "&Query"
        '
        'btn_qryDataExport
        '
        Me.btn_qryDataExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_qryDataExport.Enabled = False
        Me.btn_qryDataExport.Location = New System.Drawing.Point(482, 492)
        Me.btn_qryDataExport.Name = "btn_qryDataExport"
        Me.btn_qryDataExport.Size = New System.Drawing.Size(144, 24)
        Me.btn_qryDataExport.TabIndex = 10
        Me.btn_qryDataExport.Text = "Export Checked &Data"
        '
        'chb_qrySrc
        '
        Me.chb_qrySrc.AutoSize = True
        Me.chb_qrySrc.BackColor = System.Drawing.Color.Transparent
        Me.chb_qrySrc.Location = New System.Drawing.Point(16, 226)
        Me.chb_qrySrc.Name = "chb_qrySrc"
        Me.chb_qrySrc.Size = New System.Drawing.Size(105, 17)
        Me.chb_qrySrc.TabIndex = 4
        Me.chb_qrySrc.Text = "Query by Source"
        Me.chb_qrySrc.UseVisualStyleBackColor = False
        '
        'chb_qryVar
        '
        Me.chb_qryVar.AutoSize = True
        Me.chb_qryVar.BackColor = System.Drawing.Color.Transparent
        Me.chb_qryVar.Location = New System.Drawing.Point(16, 116)
        Me.chb_qryVar.Name = "chb_qryVar"
        Me.chb_qryVar.Size = New System.Drawing.Size(109, 17)
        Me.chb_qryVar.TabIndex = 2
        Me.chb_qryVar.Text = "Query by Variable"
        Me.chb_qryVar.UseVisualStyleBackColor = False
        '
        'grp_qryVars
        '
        Me.grp_qryVars.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_qryVars.Controls.Add(Me.lbx_qryVars)
        Me.grp_qryVars.Controls.Add(Me.txt_qryVarCode)
        Me.grp_qryVars.Controls.Add(Me.txt_qryVarName)
        Me.grp_qryVars.Controls.Add(Me.rdo_qryVarCode)
        Me.grp_qryVars.Controls.Add(Me.rdo_qryVarName)
        Me.grp_qryVars.Controls.Add(Me.rdo_qryVarList)
        Me.grp_qryVars.Controls.Add(Me.grp_qryVarSelect)
        Me.grp_qryVars.Enabled = False
        Me.grp_qryVars.Location = New System.Drawing.Point(8, 116)
        Me.grp_qryVars.Name = "grp_qryVars"
        Me.grp_qryVars.Size = New System.Drawing.Size(768, 109)
        Me.grp_qryVars.TabIndex = 3
        Me.grp_qryVars.TabStop = False
        '
        'lbx_qryVars
        '
        Me.lbx_qryVars.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbx_qryVars.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbx_qryVars.Enabled = False
        Me.lbx_qryVars.Location = New System.Drawing.Point(24, 32)
        Me.lbx_qryVars.Name = "lbx_qryVars"
        Me.lbx_qryVars.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbx_qryVars.Size = New System.Drawing.Size(376, 69)
        Me.lbx_qryVars.TabIndex = 1
        '
        'txt_qryVarCode
        '
        Me.txt_qryVarCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_qryVarCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txt_qryVarCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txt_qryVarCode.Enabled = False
        Me.txt_qryVarCode.Location = New System.Drawing.Point(424, 72)
        Me.txt_qryVarCode.MaxLength = 1000
        Me.txt_qryVarCode.Name = "txt_qryVarCode"
        Me.txt_qryVarCode.Size = New System.Drawing.Size(256, 20)
        Me.txt_qryVarCode.TabIndex = 5
        '
        'txt_qryVarName
        '
        Me.txt_qryVarName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_qryVarName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txt_qryVarName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txt_qryVarName.Enabled = False
        Me.txt_qryVarName.Location = New System.Drawing.Point(424, 32)
        Me.txt_qryVarName.MaxLength = 1000
        Me.txt_qryVarName.Name = "txt_qryVarName"
        Me.txt_qryVarName.Size = New System.Drawing.Size(256, 20)
        Me.txt_qryVarName.TabIndex = 3
        '
        'rdo_qryVarCode
        '
        Me.rdo_qryVarCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdo_qryVarCode.AutoSize = True
        Me.rdo_qryVarCode.Location = New System.Drawing.Point(406, 55)
        Me.rdo_qryVarCode.Name = "rdo_qryVarCode"
        Me.rdo_qryVarCode.Size = New System.Drawing.Size(136, 17)
        Me.rdo_qryVarCode.TabIndex = 4
        Me.rdo_qryVarCode.Text = "Query by Variable Code"
        '
        'rdo_qryVarName
        '
        Me.rdo_qryVarName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdo_qryVarName.AutoSize = True
        Me.rdo_qryVarName.Location = New System.Drawing.Point(406, 15)
        Me.rdo_qryVarName.Name = "rdo_qryVarName"
        Me.rdo_qryVarName.Size = New System.Drawing.Size(139, 17)
        Me.rdo_qryVarName.TabIndex = 2
        Me.rdo_qryVarName.Text = "Query by Variable Name"
        '
        'rdo_qryVarList
        '
        Me.rdo_qryVarList.AutoSize = True
        Me.rdo_qryVarList.Location = New System.Drawing.Point(8, 15)
        Me.rdo_qryVarList.Name = "rdo_qryVarList"
        Me.rdo_qryVarList.Size = New System.Drawing.Size(154, 17)
        Me.rdo_qryVarList.TabIndex = 0
        Me.rdo_qryVarList.Text = "Choose Variables from a list"
        '
        'grp_qryVarSelect
        '
        Me.grp_qryVarSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_qryVarSelect.Controls.Add(Me.rdo_qryVarOR)
        Me.grp_qryVarSelect.Controls.Add(Me.rdo_qryVarAND)
        Me.grp_qryVarSelect.Enabled = False
        Me.grp_qryVarSelect.Location = New System.Drawing.Point(688, 8)
        Me.grp_qryVarSelect.Name = "grp_qryVarSelect"
        Me.grp_qryVarSelect.Size = New System.Drawing.Size(74, 95)
        Me.grp_qryVarSelect.TabIndex = 6
        Me.grp_qryVarSelect.TabStop = False
        Me.grp_qryVarSelect.Text = "Multiple Entries (; )"
        '
        'rdo_qryVarOR
        '
        Me.rdo_qryVarOR.AutoSize = True
        Me.rdo_qryVarOR.Location = New System.Drawing.Point(16, 52)
        Me.rdo_qryVarOR.Name = "rdo_qryVarOR"
        Me.rdo_qryVarOR.Size = New System.Drawing.Size(41, 17)
        Me.rdo_qryVarOR.TabIndex = 1
        Me.rdo_qryVarOR.Text = "OR"
        '
        'rdo_qryVarAND
        '
        Me.rdo_qryVarAND.AutoSize = True
        Me.rdo_qryVarAND.Checked = True
        Me.rdo_qryVarAND.Location = New System.Drawing.Point(16, 27)
        Me.rdo_qryVarAND.Name = "rdo_qryVarAND"
        Me.rdo_qryVarAND.Size = New System.Drawing.Size(48, 17)
        Me.rdo_qryVarAND.TabIndex = 0
        Me.rdo_qryVarAND.TabStop = True
        Me.rdo_qryVarAND.Text = "AND"
        '
        'chb_qrySite
        '
        Me.chb_qrySite.AutoSize = True
        Me.chb_qrySite.BackColor = System.Drawing.Color.Transparent
        Me.chb_qrySite.Location = New System.Drawing.Point(16, 8)
        Me.chb_qrySite.Name = "chb_qrySite"
        Me.chb_qrySite.Size = New System.Drawing.Size(89, 17)
        Me.chb_qrySite.TabIndex = 0
        Me.chb_qrySite.Text = "Query by Site"
        Me.chb_qrySite.UseVisualStyleBackColor = False
        '
        'grp_qrySites
        '
        Me.grp_qrySites.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_qrySites.Controls.Add(Me.lbx_qrySites)
        Me.grp_qrySites.Controls.Add(Me.txt_qrySiteCode)
        Me.grp_qrySites.Controls.Add(Me.txt_qrySiteName)
        Me.grp_qrySites.Controls.Add(Me.rdo_qrySiteCode)
        Me.grp_qrySites.Controls.Add(Me.rdo_qrySiteName)
        Me.grp_qrySites.Controls.Add(Me.rdo_qrySiteList)
        Me.grp_qrySites.Controls.Add(Me.grp_qrySiteSelect)
        Me.grp_qrySites.Enabled = False
        Me.grp_qrySites.Location = New System.Drawing.Point(8, 8)
        Me.grp_qrySites.Name = "grp_qrySites"
        Me.grp_qrySites.Size = New System.Drawing.Size(768, 108)
        Me.grp_qrySites.TabIndex = 1
        Me.grp_qrySites.TabStop = False
        '
        'lbx_qrySites
        '
        Me.lbx_qrySites.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbx_qrySites.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbx_qrySites.Enabled = False
        Me.lbx_qrySites.Location = New System.Drawing.Point(24, 32)
        Me.lbx_qrySites.Name = "lbx_qrySites"
        Me.lbx_qrySites.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbx_qrySites.Size = New System.Drawing.Size(376, 69)
        Me.lbx_qrySites.TabIndex = 1
        '
        'txt_qrySiteCode
        '
        Me.txt_qrySiteCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_qrySiteCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txt_qrySiteCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txt_qrySiteCode.Enabled = False
        Me.txt_qrySiteCode.Location = New System.Drawing.Point(424, 72)
        Me.txt_qrySiteCode.MaxLength = 1000
        Me.txt_qrySiteCode.Name = "txt_qrySiteCode"
        Me.txt_qrySiteCode.Size = New System.Drawing.Size(256, 20)
        Me.txt_qrySiteCode.TabIndex = 5
        '
        'txt_qrySiteName
        '
        Me.txt_qrySiteName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_qrySiteName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txt_qrySiteName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txt_qrySiteName.Enabled = False
        Me.txt_qrySiteName.Location = New System.Drawing.Point(424, 32)
        Me.txt_qrySiteName.MaxLength = 1000
        Me.txt_qrySiteName.Name = "txt_qrySiteName"
        Me.txt_qrySiteName.Size = New System.Drawing.Size(256, 20)
        Me.txt_qrySiteName.TabIndex = 3
        '
        'rdo_qrySiteCode
        '
        Me.rdo_qrySiteCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdo_qrySiteCode.AutoSize = True
        Me.rdo_qrySiteCode.Location = New System.Drawing.Point(406, 55)
        Me.rdo_qrySiteCode.Name = "rdo_qrySiteCode"
        Me.rdo_qrySiteCode.Size = New System.Drawing.Size(116, 17)
        Me.rdo_qrySiteCode.TabIndex = 4
        Me.rdo_qrySiteCode.Text = "Query by Site Code"
        '
        'rdo_qrySiteName
        '
        Me.rdo_qrySiteName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdo_qrySiteName.AutoSize = True
        Me.rdo_qrySiteName.Location = New System.Drawing.Point(406, 15)
        Me.rdo_qrySiteName.Name = "rdo_qrySiteName"
        Me.rdo_qrySiteName.Size = New System.Drawing.Size(119, 17)
        Me.rdo_qrySiteName.TabIndex = 2
        Me.rdo_qrySiteName.Text = "Query by Site Name"
        '
        'rdo_qrySiteList
        '
        Me.rdo_qrySiteList.AutoSize = True
        Me.rdo_qrySiteList.Location = New System.Drawing.Point(8, 15)
        Me.rdo_qrySiteList.Name = "rdo_qrySiteList"
        Me.rdo_qrySiteList.Size = New System.Drawing.Size(134, 17)
        Me.rdo_qrySiteList.TabIndex = 0
        Me.rdo_qrySiteList.Text = "Choose Sites from a list"
        '
        'grp_qrySiteSelect
        '
        Me.grp_qrySiteSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_qrySiteSelect.Controls.Add(Me.rdo_qrySiteAND)
        Me.grp_qrySiteSelect.Controls.Add(Me.rdo_qrySiteOR)
        Me.grp_qrySiteSelect.Enabled = False
        Me.grp_qrySiteSelect.Location = New System.Drawing.Point(688, 8)
        Me.grp_qrySiteSelect.Name = "grp_qrySiteSelect"
        Me.grp_qrySiteSelect.Size = New System.Drawing.Size(74, 94)
        Me.grp_qrySiteSelect.TabIndex = 6
        Me.grp_qrySiteSelect.TabStop = False
        Me.grp_qrySiteSelect.Text = "Multiple Entries (; )"
        '
        'rdo_qrySiteAND
        '
        Me.rdo_qrySiteAND.AutoSize = True
        Me.rdo_qrySiteAND.Checked = True
        Me.rdo_qrySiteAND.Location = New System.Drawing.Point(16, 27)
        Me.rdo_qrySiteAND.Name = "rdo_qrySiteAND"
        Me.rdo_qrySiteAND.Size = New System.Drawing.Size(48, 17)
        Me.rdo_qrySiteAND.TabIndex = 0
        Me.rdo_qrySiteAND.TabStop = True
        Me.rdo_qrySiteAND.Text = "AND"
        '
        'rdo_qrySiteOR
        '
        Me.rdo_qrySiteOR.AutoSize = True
        Me.rdo_qrySiteOR.Location = New System.Drawing.Point(16, 52)
        Me.rdo_qrySiteOR.Name = "rdo_qrySiteOR"
        Me.rdo_qrySiteOR.Size = New System.Drawing.Size(41, 17)
        Me.rdo_qrySiteOR.TabIndex = 1
        Me.rdo_qrySiteOR.Text = "OR"
        '
        'grp_qrySources
        '
        Me.grp_qrySources.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_qrySources.Controls.Add(Me.txt_qrySrcDesc)
        Me.grp_qrySources.Controls.Add(Me.txt_qrySrcOrg)
        Me.grp_qrySources.Controls.Add(Me.rdo_qrySrcDesc)
        Me.grp_qrySources.Controls.Add(Me.rdo_qrySrcOrg)
        Me.grp_qrySources.Controls.Add(Me.grp_qrySrcSelect)
        Me.grp_qrySources.Enabled = False
        Me.grp_qrySources.Location = New System.Drawing.Point(8, 226)
        Me.grp_qrySources.Name = "grp_qrySources"
        Me.grp_qrySources.Size = New System.Drawing.Size(192, 178)
        Me.grp_qrySources.TabIndex = 5
        Me.grp_qrySources.TabStop = False
        '
        'txt_qrySrcDesc
        '
        Me.txt_qrySrcDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_qrySrcDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txt_qrySrcDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txt_qrySrcDesc.Enabled = False
        Me.txt_qrySrcDesc.Location = New System.Drawing.Point(23, 91)
        Me.txt_qrySrcDesc.MaxLength = 1000
        Me.txt_qrySrcDesc.Name = "txt_qrySrcDesc"
        Me.txt_qrySrcDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_qrySrcDesc.Size = New System.Drawing.Size(160, 20)
        Me.txt_qrySrcDesc.TabIndex = 3
        '
        'txt_qrySrcOrg
        '
        Me.txt_qrySrcOrg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_qrySrcOrg.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txt_qrySrcOrg.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txt_qrySrcOrg.Enabled = False
        Me.txt_qrySrcOrg.Location = New System.Drawing.Point(23, 32)
        Me.txt_qrySrcOrg.MaxLength = 1000
        Me.txt_qrySrcOrg.Name = "txt_qrySrcOrg"
        Me.txt_qrySrcOrg.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_qrySrcOrg.Size = New System.Drawing.Size(160, 20)
        Me.txt_qrySrcOrg.TabIndex = 1
        '
        'rdo_qrySrcDesc
        '
        Me.rdo_qrySrcDesc.AutoSize = True
        Me.rdo_qrySrcDesc.Location = New System.Drawing.Point(8, 68)
        Me.rdo_qrySrcDesc.Name = "rdo_qrySrcDesc"
        Me.rdo_qrySrcDesc.Size = New System.Drawing.Size(130, 17)
        Me.rdo_qrySrcDesc.TabIndex = 2
        Me.rdo_qrySrcDesc.Text = "Source Description (; )"
        '
        'rdo_qrySrcOrg
        '
        Me.rdo_qrySrcOrg.AutoSize = True
        Me.rdo_qrySrcOrg.Location = New System.Drawing.Point(8, 15)
        Me.rdo_qrySrcOrg.Name = "rdo_qrySrcOrg"
        Me.rdo_qrySrcOrg.Size = New System.Drawing.Size(99, 17)
        Me.rdo_qrySrcOrg.TabIndex = 0
        Me.rdo_qrySrcOrg.Text = "Organization (; )"
        '
        'grp_qrySrcSelect
        '
        Me.grp_qrySrcSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_qrySrcSelect.Controls.Add(Me.rdo_qrySrcOR)
        Me.grp_qrySrcSelect.Controls.Add(Me.rdo_qrySrcAND)
        Me.grp_qrySrcSelect.Location = New System.Drawing.Point(8, 122)
        Me.grp_qrySrcSelect.Name = "grp_qrySrcSelect"
        Me.grp_qrySrcSelect.Size = New System.Drawing.Size(178, 50)
        Me.grp_qrySrcSelect.TabIndex = 4
        Me.grp_qrySrcSelect.TabStop = False
        Me.grp_qrySrcSelect.Text = "Multiple Entries (; )"
        '
        'rdo_qrySrcOR
        '
        Me.rdo_qrySrcOR.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rdo_qrySrcOR.AutoSize = True
        Me.rdo_qrySrcOR.Location = New System.Drawing.Point(105, 18)
        Me.rdo_qrySrcOR.Name = "rdo_qrySrcOR"
        Me.rdo_qrySrcOR.Size = New System.Drawing.Size(41, 17)
        Me.rdo_qrySrcOR.TabIndex = 1
        Me.rdo_qrySrcOR.Text = "OR"
        '
        'rdo_qrySrcAND
        '
        Me.rdo_qrySrcAND.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rdo_qrySrcAND.AutoSize = True
        Me.rdo_qrySrcAND.Checked = True
        Me.rdo_qrySrcAND.Location = New System.Drawing.Point(32, 18)
        Me.rdo_qrySrcAND.Name = "rdo_qrySrcAND"
        Me.rdo_qrySrcAND.Size = New System.Drawing.Size(48, 17)
        Me.rdo_qrySrcAND.TabIndex = 0
        Me.rdo_qrySrcAND.TabStop = True
        Me.rdo_qrySrcAND.Text = "AND"
        '
        'grp_qryOther
        '
        Me.grp_qryOther.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_qryOther.Controls.Add(Me.dtp_qryTimeBegin)
        Me.grp_qryOther.Controls.Add(Me.dtp_qryTimeEnd)
        Me.grp_qryOther.Controls.Add(Me.txt_qryMethod)
        Me.grp_qryOther.Controls.Add(Me.lbx_qryQCLevel)
        Me.grp_qryOther.Controls.Add(Me.lbx_qryDataType)
        Me.grp_qryOther.Controls.Add(Me.lbx_qryValType)
        Me.grp_qryOther.Controls.Add(Me.lbx_qrySampleMed)
        Me.grp_qryOther.Controls.Add(Me.lbx_qryGenCat)
        Me.grp_qryOther.Controls.Add(Me.lbl_qryTimeBegin)
        Me.grp_qryOther.Controls.Add(Me.chb_qryNumObs)
        Me.grp_qryOther.Controls.Add(Me.chb_qryDate)
        Me.grp_qryOther.Controls.Add(Me.lbl_qryTimeEnd)
        Me.grp_qryOther.Controls.Add(Me.chb_qryMethod)
        Me.grp_qryOther.Controls.Add(Me.chb_qryQCLevel)
        Me.grp_qryOther.Controls.Add(Me.chb_qryDataType)
        Me.grp_qryOther.Controls.Add(Me.chb_qryValType)
        Me.grp_qryOther.Controls.Add(Me.chb_qrySampleMed)
        Me.grp_qryOther.Controls.Add(Me.chb_qryGenCat)
        Me.grp_qryOther.Controls.Add(Me.grp_qryNumObs)
        Me.grp_qryOther.Location = New System.Drawing.Point(206, 226)
        Me.grp_qryOther.Name = "grp_qryOther"
        Me.grp_qryOther.Size = New System.Drawing.Size(570, 178)
        Me.grp_qryOther.TabIndex = 6
        Me.grp_qryOther.TabStop = False
        Me.grp_qryOther.Text = "Other Query Options"
        '
        'dtp_qryTimeBegin
        '
        Me.dtp_qryTimeBegin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dtp_qryTimeBegin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtp_qryTimeBegin.Enabled = False
        Me.dtp_qryTimeBegin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_qryTimeBegin.Location = New System.Drawing.Point(467, 83)
        Me.dtp_qryTimeBegin.MaxDate = New Date(3006, 12, 31, 0, 0, 0, 0)
        Me.dtp_qryTimeBegin.Name = "dtp_qryTimeBegin"
        Me.dtp_qryTimeBegin.Size = New System.Drawing.Size(94, 20)
        Me.dtp_qryTimeBegin.TabIndex = 16
        Me.dtp_qryTimeBegin.Value = New Date(2007, 1, 5, 0, 0, 0, 0)
        '
        'dtp_qryTimeEnd
        '
        Me.dtp_qryTimeEnd.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dtp_qryTimeEnd.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtp_qryTimeEnd.Enabled = False
        Me.dtp_qryTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_qryTimeEnd.Location = New System.Drawing.Point(467, 107)
        Me.dtp_qryTimeEnd.MaxDate = New Date(3006, 12, 31, 0, 0, 0, 0)
        Me.dtp_qryTimeEnd.Name = "dtp_qryTimeEnd"
        Me.dtp_qryTimeEnd.Size = New System.Drawing.Size(94, 20)
        Me.dtp_qryTimeEnd.TabIndex = 18
        Me.dtp_qryTimeEnd.Value = New Date(2007, 1, 5, 0, 0, 0, 0)
        '
        'txt_qryMethod
        '
        Me.txt_qryMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txt_qryMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txt_qryMethod.Enabled = False
        Me.txt_qryMethod.Location = New System.Drawing.Point(317, 149)
        Me.txt_qryMethod.MaxLength = 1000
        Me.txt_qryMethod.Name = "txt_qryMethod"
        Me.txt_qryMethod.Size = New System.Drawing.Size(244, 20)
        Me.txt_qryMethod.TabIndex = 11
        '
        'lbx_qryQCLevel
        '
        Me.lbx_qryQCLevel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbx_qryQCLevel.Enabled = False
        Me.lbx_qryQCLevel.HorizontalScrollbar = True
        Me.lbx_qryQCLevel.Location = New System.Drawing.Point(317, 32)
        Me.lbx_qryQCLevel.Name = "lbx_qryQCLevel"
        Me.lbx_qryQCLevel.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbx_qryQCLevel.Size = New System.Drawing.Size(112, 95)
        Me.lbx_qryQCLevel.TabIndex = 9
        '
        'lbx_qryDataType
        '
        Me.lbx_qryDataType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbx_qryDataType.Enabled = False
        Me.lbx_qryDataType.Location = New System.Drawing.Point(170, 113)
        Me.lbx_qryDataType.Name = "lbx_qryDataType"
        Me.lbx_qryDataType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbx_qryDataType.Size = New System.Drawing.Size(124, 56)
        Me.lbx_qryDataType.TabIndex = 7
        '
        'lbx_qryValType
        '
        Me.lbx_qryValType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbx_qryValType.Enabled = False
        Me.lbx_qryValType.Location = New System.Drawing.Point(170, 32)
        Me.lbx_qryValType.Name = "lbx_qryValType"
        Me.lbx_qryValType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbx_qryValType.Size = New System.Drawing.Size(124, 56)
        Me.lbx_qryValType.TabIndex = 5
        '
        'lbx_qrySampleMed
        '
        Me.lbx_qrySampleMed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbx_qrySampleMed.Enabled = False
        Me.lbx_qrySampleMed.Location = New System.Drawing.Point(24, 113)
        Me.lbx_qrySampleMed.Name = "lbx_qrySampleMed"
        Me.lbx_qrySampleMed.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbx_qrySampleMed.Size = New System.Drawing.Size(124, 56)
        Me.lbx_qrySampleMed.TabIndex = 3
        '
        'lbx_qryGenCat
        '
        Me.lbx_qryGenCat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbx_qryGenCat.Enabled = False
        Me.lbx_qryGenCat.Location = New System.Drawing.Point(24, 32)
        Me.lbx_qryGenCat.Name = "lbx_qryGenCat"
        Me.lbx_qryGenCat.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbx_qryGenCat.Size = New System.Drawing.Size(124, 56)
        Me.lbx_qryGenCat.TabIndex = 1
        '
        'lbl_qryTimeBegin
        '
        Me.lbl_qryTimeBegin.Enabled = False
        Me.lbl_qryTimeBegin.Location = New System.Drawing.Point(422, 83)
        Me.lbl_qryTimeBegin.Name = "lbl_qryTimeBegin"
        Me.lbl_qryTimeBegin.Size = New System.Drawing.Size(45, 20)
        Me.lbl_qryTimeBegin.TabIndex = 15
        Me.lbl_qryTimeBegin.Text = "begin:"
        Me.lbl_qryTimeBegin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chb_qryNumObs
        '
        Me.chb_qryNumObs.AutoSize = True
        Me.chb_qryNumObs.Location = New System.Drawing.Point(451, 15)
        Me.chb_qryNumObs.Name = "chb_qryNumObs"
        Me.chb_qryNumObs.Size = New System.Drawing.Size(110, 17)
        Me.chb_qryNumObs.TabIndex = 12
        Me.chb_qryNumObs.Text = "# of Observations"
        '
        'chb_qryDate
        '
        Me.chb_qryDate.AutoSize = True
        Me.chb_qryDate.Location = New System.Drawing.Point(451, 67)
        Me.chb_qryDate.Name = "chb_qryDate"
        Me.chb_qryDate.Size = New System.Drawing.Size(82, 17)
        Me.chb_qryDate.TabIndex = 14
        Me.chb_qryDate.Text = "Time Period"
        '
        'lbl_qryTimeEnd
        '
        Me.lbl_qryTimeEnd.Enabled = False
        Me.lbl_qryTimeEnd.Location = New System.Drawing.Point(425, 107)
        Me.lbl_qryTimeEnd.Name = "lbl_qryTimeEnd"
        Me.lbl_qryTimeEnd.Size = New System.Drawing.Size(42, 20)
        Me.lbl_qryTimeEnd.TabIndex = 17
        Me.lbl_qryTimeEnd.Text = "end:"
        Me.lbl_qryTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chb_qryMethod
        '
        Me.chb_qryMethod.AutoSize = True
        Me.chb_qryMethod.Location = New System.Drawing.Point(301, 133)
        Me.chb_qryMethod.Name = "chb_qryMethod"
        Me.chb_qryMethod.Size = New System.Drawing.Size(77, 17)
        Me.chb_qryMethod.TabIndex = 10
        Me.chb_qryMethod.Text = "Method (; )"
        '
        'chb_qryQCLevel
        '
        Me.chb_qryQCLevel.AutoSize = True
        Me.chb_qryQCLevel.Location = New System.Drawing.Point(301, 16)
        Me.chb_qryQCLevel.Name = "chb_qryQCLevel"
        Me.chb_qryQCLevel.Size = New System.Drawing.Size(123, 17)
        Me.chb_qryQCLevel.TabIndex = 8
        Me.chb_qryQCLevel.Text = "Quality Control Level"
        '
        'chb_qryDataType
        '
        Me.chb_qryDataType.AutoSize = True
        Me.chb_qryDataType.Location = New System.Drawing.Point(154, 97)
        Me.chb_qryDataType.Name = "chb_qryDataType"
        Me.chb_qryDataType.Size = New System.Drawing.Size(76, 17)
        Me.chb_qryDataType.TabIndex = 6
        Me.chb_qryDataType.Text = "Data Type"
        '
        'chb_qryValType
        '
        Me.chb_qryValType.AutoSize = True
        Me.chb_qryValType.Location = New System.Drawing.Point(154, 16)
        Me.chb_qryValType.Name = "chb_qryValType"
        Me.chb_qryValType.Size = New System.Drawing.Size(80, 17)
        Me.chb_qryValType.TabIndex = 4
        Me.chb_qryValType.Text = "Value Type"
        '
        'chb_qrySampleMed
        '
        Me.chb_qrySampleMed.AutoSize = True
        Me.chb_qrySampleMed.Location = New System.Drawing.Point(8, 97)
        Me.chb_qrySampleMed.Name = "chb_qrySampleMed"
        Me.chb_qrySampleMed.Size = New System.Drawing.Size(101, 17)
        Me.chb_qrySampleMed.TabIndex = 2
        Me.chb_qrySampleMed.Text = "Sample Medium"
        '
        'chb_qryGenCat
        '
        Me.chb_qryGenCat.AutoSize = True
        Me.chb_qryGenCat.Location = New System.Drawing.Point(8, 16)
        Me.chb_qryGenCat.Name = "chb_qryGenCat"
        Me.chb_qryGenCat.Size = New System.Drawing.Size(108, 17)
        Me.chb_qryGenCat.TabIndex = 0
        Me.chb_qryGenCat.Text = "General Category"
        '
        'grp_qryNumObs
        '
        Me.grp_qryNumObs.Controls.Add(Me.rdo_qryNumObsG)
        Me.grp_qryNumObs.Controls.Add(Me.num_qryObs)
        Me.grp_qryNumObs.Controls.Add(Me.rdo_qryNumObsL)
        Me.grp_qryNumObs.Enabled = False
        Me.grp_qryNumObs.Location = New System.Drawing.Point(446, 32)
        Me.grp_qryNumObs.Name = "grp_qryNumObs"
        Me.grp_qryNumObs.Size = New System.Drawing.Size(118, 34)
        Me.grp_qryNumObs.TabIndex = 13
        '
        'rdo_qryNumObsG
        '
        Me.rdo_qryNumObsG.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdo_qryNumObsG.Location = New System.Drawing.Point(11, 1)
        Me.rdo_qryNumObsG.Name = "rdo_qryNumObsG"
        Me.rdo_qryNumObsG.Size = New System.Drawing.Size(30, 15)
        Me.rdo_qryNumObsG.TabIndex = 0
        Me.rdo_qryNumObsG.Text = ">"
        '
        'num_qryObs
        '
        Me.num_qryObs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.num_qryObs.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.num_qryObs.Location = New System.Drawing.Point(44, 0)
        Me.num_qryObs.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.num_qryObs.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.num_qryObs.Name = "num_qryObs"
        Me.num_qryObs.Size = New System.Drawing.Size(71, 20)
        Me.num_qryObs.TabIndex = 1
        Me.num_qryObs.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rdo_qryNumObsL
        '
        Me.rdo_qryNumObsL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdo_qryNumObsL.Location = New System.Drawing.Point(11, 18)
        Me.rdo_qryNumObsL.Name = "rdo_qryNumObsL"
        Me.rdo_qryNumObsL.Size = New System.Drawing.Size(41, 15)
        Me.rdo_qryNumObsL.TabIndex = 2
        Me.rdo_qryNumObsL.Text = "<="
        '
        'lv_qryResults
        '
        Me.lv_qryResults.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lv_qryResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv_qryResults.AutoArrange = False
        Me.lv_qryResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lv_qryResults.CheckBoxes = True
        Me.lv_qryResults.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_qrySiteCodeName, Me.col_qryVarCodeName, Me.col_qrySpeciation, Me.col_qryVarUnits, Me.col_qryGenCat, Me.col_qryValType, Me.col_qrySampleMed, Me.col_qryDataType, Me.col_qryQCLevel, Me.col_qryMethodDesc, Me.col_qryNumObs, Me.col_qryDateTime, Me.col_qryOrg, Me.col_qrySrcDesc, Me.col_qryCitation, Me.col_qryTimeSupport, Me.col_qryTimeSupportUnits})
        Me.lv_qryResults.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lv_qryResults.Enabled = False
        Me.lv_qryResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv_qryResults.FullRowSelect = True
        Me.lv_qryResults.GridLines = True
        Me.lv_qryResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv_qryResults.Location = New System.Drawing.Point(8, 410)
        Me.lv_qryResults.MultiSelect = False
        Me.lv_qryResults.Name = "lv_qryResults"
        Me.lv_qryResults.Size = New System.Drawing.Size(768, 76)
        Me.lv_qryResults.TabIndex = 8
        Me.lv_qryResults.UseCompatibleStateImageBehavior = False
        Me.lv_qryResults.View = System.Windows.Forms.View.Details
        '
        'col_qrySiteCodeName
        '
        Me.col_qrySiteCodeName.Text = "Site"
        Me.col_qrySiteCodeName.Width = 50
        '
        'col_qryVarCodeName
        '
        Me.col_qryVarCodeName.Text = "Variable"
        Me.col_qryVarCodeName.Width = 50
        '
        'col_qrySpeciation
        '
        Me.col_qrySpeciation.Text = "Speciation"
        Me.col_qrySpeciation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'col_qryVarUnits
        '
        Me.col_qryVarUnits.Text = "Variable Units"
        Me.col_qryVarUnits.Width = 50
        '
        'col_qryGenCat
        '
        Me.col_qryGenCat.Text = "General Category"
        Me.col_qryGenCat.Width = 50
        '
        'col_qryValType
        '
        Me.col_qryValType.Text = "Value Type"
        Me.col_qryValType.Width = 50
        '
        'col_qrySampleMed
        '
        Me.col_qrySampleMed.Text = "Sample Medium"
        Me.col_qrySampleMed.Width = 50
        '
        'col_qryDataType
        '
        Me.col_qryDataType.Text = "Data Type"
        Me.col_qryDataType.Width = 50
        '
        'col_qryQCLevel
        '
        Me.col_qryQCLevel.Text = "Quality Control Level"
        Me.col_qryQCLevel.Width = 50
        '
        'col_qryMethodDesc
        '
        Me.col_qryMethodDesc.Text = "Method Description"
        Me.col_qryMethodDesc.Width = 50
        '
        'col_qryNumObs
        '
        Me.col_qryNumObs.Text = "Value Count"
        Me.col_qryNumObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_qryNumObs.Width = 50
        '
        'col_qryDateTime
        '
        Me.col_qryDateTime.Text = "Date Range"
        Me.col_qryDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_qryDateTime.Width = 50
        '
        'col_qryOrg
        '
        Me.col_qryOrg.Text = "Organization"
        Me.col_qryOrg.Width = 50
        '
        'col_qrySrcDesc
        '
        Me.col_qrySrcDesc.Text = "Source Description"
        Me.col_qrySrcDesc.Width = 50
        '
        'col_qryCitation
        '
        Me.col_qryCitation.Text = "Citation"
        '
        'col_qryTimeSupport
        '
        Me.col_qryTimeSupport.Text = "Time Support"
        Me.col_qryTimeSupport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.col_qryTimeSupport.Width = 50
        '
        'col_qryTimeSupportUnits
        '
        Me.col_qryTimeSupportUnits.Text = "Time Support Units"
        Me.col_qryTimeSupportUnits.Width = 50
        '
        'tabpgVisualize
        '
        Me.tabpgVisualize.Controls.Add(Me.btnPlot)
        Me.tabpgVisualize.Controls.Add(Me.tabctlPlotOptions)
        Me.tabpgVisualize.Controls.Add(Me.gboxDateInfo)
        Me.tabpgVisualize.Controls.Add(Me.gboxVisDataSel)
        Me.tabpgVisualize.Controls.Add(Me.tabctlPlots)
        Me.tabpgVisualize.Location = New System.Drawing.Point(4, 22)
        Me.tabpgVisualize.Name = "tabpgVisualize"
        Me.tabpgVisualize.Size = New System.Drawing.Size(784, 519)
        Me.tabpgVisualize.TabIndex = 1
        Me.tabpgVisualize.Text = "Visualize"
        Me.tabpgVisualize.UseVisualStyleBackColor = True
        '
        'btnPlot
        '
        Me.btnPlot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlot.Location = New System.Drawing.Point(560, 491)
        Me.btnPlot.Name = "btnPlot"
        Me.btnPlot.Size = New System.Drawing.Size(208, 24)
        Me.btnPlot.TabIndex = 2
        Me.btnPlot.Text = "Update Plot"
        '
        'tabctlPlotOptions
        '
        Me.tabctlPlotOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabctlPlotOptions.Controls.Add(Me.tabpgSummary)
        Me.tabctlPlotOptions.Controls.Add(Me.tabpgOptions)
        Me.tabctlPlotOptions.Location = New System.Drawing.Point(548, 8)
        Me.tabctlPlotOptions.Name = "tabctlPlotOptions"
        Me.tabctlPlotOptions.SelectedIndex = 0
        Me.tabctlPlotOptions.Size = New System.Drawing.Size(232, 401)
        Me.tabctlPlotOptions.TabIndex = 6
        '
        'tabpgSummary
        '
        Me.tabpgSummary.AutoScroll = True
        Me.tabpgSummary.Controls.Add(Me.gboxStatistics)
        Me.tabpgSummary.Controls.Add(Me.ckboxUseCensoredData)
        Me.tabpgSummary.Location = New System.Drawing.Point(4, 22)
        Me.tabpgSummary.Name = "tabpgSummary"
        Me.tabpgSummary.Size = New System.Drawing.Size(224, 375)
        Me.tabpgSummary.TabIndex = 0
        Me.tabpgSummary.Text = "Summary"
        '
        'gboxStatistics
        '
        Me.gboxStatistics.Controls.Add(Me.lblPercentiles)
        Me.gboxStatistics.Controls.Add(Me.tbox90Perc)
        Me.gboxStatistics.Controls.Add(Me.tbox75Perc)
        Me.gboxStatistics.Controls.Add(Me.tbox50Perc)
        Me.gboxStatistics.Controls.Add(Me.lbl90Perc)
        Me.gboxStatistics.Controls.Add(Me.lbl75Perc)
        Me.gboxStatistics.Controls.Add(Me.tbox10Perc)
        Me.gboxStatistics.Controls.Add(Me.tbox25Perc)
        Me.gboxStatistics.Controls.Add(Me.lbl50Perc)
        Me.gboxStatistics.Controls.Add(Me.lbl25Perc)
        Me.gboxStatistics.Controls.Add(Me.lbl10Perc)
        Me.gboxStatistics.Controls.Add(Me.lblStdDev)
        Me.gboxStatistics.Controls.Add(Me.lblMax)
        Me.gboxStatistics.Controls.Add(Me.lblCoeffVar)
        Me.gboxStatistics.Controls.Add(Me.tboxGeoMean)
        Me.gboxStatistics.Controls.Add(Me.lblAMean)
        Me.gboxStatistics.Controls.Add(Me.tboxAMean)
        Me.gboxStatistics.Controls.Add(Me.lblGeoMean)
        Me.gboxStatistics.Controls.Add(Me.tboxCoeffVar)
        Me.gboxStatistics.Controls.Add(Me.tboxMin)
        Me.gboxStatistics.Controls.Add(Me.gboxDivider)
        Me.gboxStatistics.Controls.Add(Me.tboxMax)
        Me.gboxStatistics.Controls.Add(Me.tboxStdDev)
        Me.gboxStatistics.Controls.Add(Me.lblMin)
        Me.gboxStatistics.Controls.Add(Me.lblNumCensoredObs)
        Me.gboxStatistics.Controls.Add(Me.lblNumObs)
        Me.gboxStatistics.Controls.Add(Me.tboxNumObs)
        Me.gboxStatistics.Controls.Add(Me.tboxNumCensoredObs)
        Me.gboxStatistics.Location = New System.Drawing.Point(4, 36)
        Me.gboxStatistics.Name = "gboxStatistics"
        Me.gboxStatistics.Size = New System.Drawing.Size(218, 336)
        Me.gboxStatistics.TabIndex = 36
        Me.gboxStatistics.TabStop = False
        Me.gboxStatistics.Text = "Statistics"
        '
        'lblPercentiles
        '
        Me.lblPercentiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPercentiles.Location = New System.Drawing.Point(8, 216)
        Me.lblPercentiles.Name = "lblPercentiles"
        Me.lblPercentiles.Size = New System.Drawing.Size(72, 16)
        Me.lblPercentiles.TabIndex = 60
        Me.lblPercentiles.Text = "Percentiles"
        Me.lblPercentiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbox90Perc
        '
        Me.tbox90Perc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbox90Perc.BackColor = System.Drawing.SystemColors.Window
        Me.tbox90Perc.Location = New System.Drawing.Point(124, 312)
        Me.tbox90Perc.Name = "tbox90Perc"
        Me.tbox90Perc.ReadOnly = True
        Me.tbox90Perc.Size = New System.Drawing.Size(90, 20)
        Me.tbox90Perc.TabIndex = 53
        Me.tbox90Perc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbox75Perc
        '
        Me.tbox75Perc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbox75Perc.BackColor = System.Drawing.SystemColors.Window
        Me.tbox75Perc.Location = New System.Drawing.Point(124, 288)
        Me.tbox75Perc.Name = "tbox75Perc"
        Me.tbox75Perc.ReadOnly = True
        Me.tbox75Perc.Size = New System.Drawing.Size(90, 20)
        Me.tbox75Perc.TabIndex = 52
        Me.tbox75Perc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbox50Perc
        '
        Me.tbox50Perc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbox50Perc.BackColor = System.Drawing.SystemColors.Window
        Me.tbox50Perc.Location = New System.Drawing.Point(124, 264)
        Me.tbox50Perc.Name = "tbox50Perc"
        Me.tbox50Perc.ReadOnly = True
        Me.tbox50Perc.Size = New System.Drawing.Size(90, 20)
        Me.tbox50Perc.TabIndex = 51
        Me.tbox50Perc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl90Perc
        '
        Me.lbl90Perc.Location = New System.Drawing.Point(96, 314)
        Me.lbl90Perc.Name = "lbl90Perc"
        Me.lbl90Perc.Size = New System.Drawing.Size(32, 16)
        Me.lbl90Perc.TabIndex = 59
        Me.lbl90Perc.Text = "90%"
        '
        'lbl75Perc
        '
        Me.lbl75Perc.Location = New System.Drawing.Point(96, 290)
        Me.lbl75Perc.Name = "lbl75Perc"
        Me.lbl75Perc.Size = New System.Drawing.Size(32, 16)
        Me.lbl75Perc.TabIndex = 58
        Me.lbl75Perc.Text = "75%"
        '
        'tbox10Perc
        '
        Me.tbox10Perc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbox10Perc.BackColor = System.Drawing.SystemColors.Window
        Me.tbox10Perc.Location = New System.Drawing.Point(124, 216)
        Me.tbox10Perc.Name = "tbox10Perc"
        Me.tbox10Perc.ReadOnly = True
        Me.tbox10Perc.Size = New System.Drawing.Size(90, 20)
        Me.tbox10Perc.TabIndex = 49
        Me.tbox10Perc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbox25Perc
        '
        Me.tbox25Perc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbox25Perc.BackColor = System.Drawing.SystemColors.Window
        Me.tbox25Perc.Location = New System.Drawing.Point(124, 240)
        Me.tbox25Perc.Name = "tbox25Perc"
        Me.tbox25Perc.ReadOnly = True
        Me.tbox25Perc.Size = New System.Drawing.Size(90, 20)
        Me.tbox25Perc.TabIndex = 50
        Me.tbox25Perc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl50Perc
        '
        Me.lbl50Perc.Location = New System.Drawing.Point(50, 266)
        Me.lbl50Perc.Name = "lbl50Perc"
        Me.lbl50Perc.Size = New System.Drawing.Size(78, 16)
        Me.lbl50Perc.TabIndex = 57
        Me.lbl50Perc.Text = "(Median)  50%"
        '
        'lbl25Perc
        '
        Me.lbl25Perc.Location = New System.Drawing.Point(96, 242)
        Me.lbl25Perc.Name = "lbl25Perc"
        Me.lbl25Perc.Size = New System.Drawing.Size(32, 16)
        Me.lbl25Perc.TabIndex = 56
        Me.lbl25Perc.Text = "25%"
        '
        'lbl10Perc
        '
        Me.lbl10Perc.Location = New System.Drawing.Point(96, 218)
        Me.lbl10Perc.Name = "lbl10Perc"
        Me.lbl10Perc.Size = New System.Drawing.Size(32, 16)
        Me.lbl10Perc.TabIndex = 55
        Me.lbl10Perc.Text = "10%"
        '
        'lblStdDev
        '
        Me.lblStdDev.Location = New System.Drawing.Point(4, 162)
        Me.lblStdDev.Name = "lblStdDev"
        Me.lblStdDev.Size = New System.Drawing.Size(120, 16)
        Me.lblStdDev.TabIndex = 45
        Me.lblStdDev.Text = "Standard Deviation :"
        Me.lblStdDev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMax
        '
        Me.lblMax.Location = New System.Drawing.Point(4, 114)
        Me.lblMax.Name = "lblMax"
        Me.lblMax.Size = New System.Drawing.Size(120, 16)
        Me.lblMax.TabIndex = 43
        Me.lblMax.Text = "Maximum :"
        Me.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCoeffVar
        '
        Me.lblCoeffVar.Location = New System.Drawing.Point(2, 186)
        Me.lblCoeffVar.Name = "lblCoeffVar"
        Me.lblCoeffVar.Size = New System.Drawing.Size(122, 16)
        Me.lblCoeffVar.TabIndex = 46
        Me.lblCoeffVar.Text = "Coefficiant of Variation:"
        Me.lblCoeffVar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tboxGeoMean
        '
        Me.tboxGeoMean.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxGeoMean.BackColor = System.Drawing.SystemColors.Window
        Me.tboxGeoMean.Location = New System.Drawing.Point(124, 88)
        Me.tboxGeoMean.Name = "tboxGeoMean"
        Me.tboxGeoMean.ReadOnly = True
        Me.tboxGeoMean.Size = New System.Drawing.Size(90, 20)
        Me.tboxGeoMean.TabIndex = 37
        Me.tboxGeoMean.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAMean
        '
        Me.lblAMean.Location = New System.Drawing.Point(4, 66)
        Me.lblAMean.Name = "lblAMean"
        Me.lblAMean.Size = New System.Drawing.Size(120, 16)
        Me.lblAMean.TabIndex = 42
        Me.lblAMean.Text = "Arithmetic Mean :"
        Me.lblAMean.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tboxAMean
        '
        Me.tboxAMean.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxAMean.BackColor = System.Drawing.SystemColors.Window
        Me.tboxAMean.Location = New System.Drawing.Point(124, 64)
        Me.tboxAMean.Name = "tboxAMean"
        Me.tboxAMean.ReadOnly = True
        Me.tboxAMean.Size = New System.Drawing.Size(90, 20)
        Me.tboxAMean.TabIndex = 36
        Me.tboxAMean.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGeoMean
        '
        Me.lblGeoMean.Location = New System.Drawing.Point(4, 90)
        Me.lblGeoMean.Name = "lblGeoMean"
        Me.lblGeoMean.Size = New System.Drawing.Size(120, 16)
        Me.lblGeoMean.TabIndex = 48
        Me.lblGeoMean.Text = "Geometric Mean :"
        Me.lblGeoMean.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tboxCoeffVar
        '
        Me.tboxCoeffVar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxCoeffVar.BackColor = System.Drawing.SystemColors.Window
        Me.tboxCoeffVar.Location = New System.Drawing.Point(124, 184)
        Me.tboxCoeffVar.Name = "tboxCoeffVar"
        Me.tboxCoeffVar.ReadOnly = True
        Me.tboxCoeffVar.Size = New System.Drawing.Size(90, 20)
        Me.tboxCoeffVar.TabIndex = 41
        Me.tboxCoeffVar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tboxMin
        '
        Me.tboxMin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxMin.BackColor = System.Drawing.SystemColors.Window
        Me.tboxMin.Location = New System.Drawing.Point(124, 136)
        Me.tboxMin.Name = "tboxMin"
        Me.tboxMin.ReadOnly = True
        Me.tboxMin.Size = New System.Drawing.Size(90, 20)
        Me.tboxMin.TabIndex = 39
        Me.tboxMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gboxDivider
        '
        Me.gboxDivider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboxDivider.Location = New System.Drawing.Point(7, 204)
        Me.gboxDivider.Name = "gboxDivider"
        Me.gboxDivider.Size = New System.Drawing.Size(204, 8)
        Me.gboxDivider.TabIndex = 47
        Me.gboxDivider.TabStop = False
        '
        'tboxMax
        '
        Me.tboxMax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxMax.BackColor = System.Drawing.SystemColors.Window
        Me.tboxMax.Location = New System.Drawing.Point(124, 112)
        Me.tboxMax.Name = "tboxMax"
        Me.tboxMax.ReadOnly = True
        Me.tboxMax.Size = New System.Drawing.Size(90, 20)
        Me.tboxMax.TabIndex = 38
        Me.tboxMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tboxStdDev
        '
        Me.tboxStdDev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxStdDev.BackColor = System.Drawing.SystemColors.Window
        Me.tboxStdDev.Location = New System.Drawing.Point(124, 160)
        Me.tboxStdDev.Name = "tboxStdDev"
        Me.tboxStdDev.ReadOnly = True
        Me.tboxStdDev.Size = New System.Drawing.Size(90, 20)
        Me.tboxStdDev.TabIndex = 40
        Me.tboxStdDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMin
        '
        Me.lblMin.Location = New System.Drawing.Point(4, 138)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(120, 16)
        Me.lblMin.TabIndex = 44
        Me.lblMin.Text = "Minimum :"
        Me.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumCensoredObs
        '
        Me.lblNumCensoredObs.Location = New System.Drawing.Point(4, 42)
        Me.lblNumCensoredObs.Name = "lblNumCensoredObs"
        Me.lblNumCensoredObs.Size = New System.Drawing.Size(120, 16)
        Me.lblNumCensoredObs.TabIndex = 35
        Me.lblNumCensoredObs.Text = "# Of Censored Obs. :"
        Me.lblNumCensoredObs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumObs
        '
        Me.lblNumObs.Location = New System.Drawing.Point(4, 18)
        Me.lblNumObs.Name = "lblNumObs"
        Me.lblNumObs.Size = New System.Drawing.Size(120, 16)
        Me.lblNumObs.TabIndex = 33
        Me.lblNumObs.Text = "# Of Observations :"
        Me.lblNumObs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tboxNumObs
        '
        Me.tboxNumObs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxNumObs.BackColor = System.Drawing.SystemColors.Window
        Me.tboxNumObs.Location = New System.Drawing.Point(124, 16)
        Me.tboxNumObs.Name = "tboxNumObs"
        Me.tboxNumObs.ReadOnly = True
        Me.tboxNumObs.Size = New System.Drawing.Size(90, 20)
        Me.tboxNumObs.TabIndex = 32
        Me.tboxNumObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tboxNumCensoredObs
        '
        Me.tboxNumCensoredObs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxNumCensoredObs.BackColor = System.Drawing.SystemColors.Window
        Me.tboxNumCensoredObs.Location = New System.Drawing.Point(124, 40)
        Me.tboxNumCensoredObs.Name = "tboxNumCensoredObs"
        Me.tboxNumCensoredObs.ReadOnly = True
        Me.tboxNumCensoredObs.Size = New System.Drawing.Size(90, 20)
        Me.tboxNumCensoredObs.TabIndex = 34
        Me.tboxNumCensoredObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ckboxUseCensoredData
        '
        Me.ckboxUseCensoredData.Location = New System.Drawing.Point(8, 4)
        Me.ckboxUseCensoredData.Name = "ckboxUseCensoredData"
        Me.ckboxUseCensoredData.Size = New System.Drawing.Size(212, 32)
        Me.ckboxUseCensoredData.TabIndex = 30
        Me.ckboxUseCensoredData.Text = "Use censored data in summary statistics."
        '
        'tabpgOptions
        '
        Me.tabpgOptions.AutoScroll = True
        Me.tabpgOptions.Controls.Add(Me.gboxHistPlotOptions)
        Me.tabpgOptions.Controls.Add(Me.btnAxisOptions)
        Me.tabpgOptions.Controls.Add(Me.gboxBoxPlotOptions)
        Me.tabpgOptions.Controls.Add(Me.gboxTSPlotOptions)
        Me.tabpgOptions.Location = New System.Drawing.Point(4, 22)
        Me.tabpgOptions.Name = "tabpgOptions"
        Me.tabpgOptions.Size = New System.Drawing.Size(224, 375)
        Me.tabpgOptions.TabIndex = 1
        Me.tabpgOptions.Text = "Plot Options"
        '
        'gboxHistPlotOptions
        '
        Me.gboxHistPlotOptions.Controls.Add(Me.ckboxHistSetNumBins)
        Me.gboxHistPlotOptions.Controls.Add(Me.gboxHPNumBarSettings)
        Me.gboxHistPlotOptions.Location = New System.Drawing.Point(8, 120)
        Me.gboxHistPlotOptions.Name = "gboxHistPlotOptions"
        Me.gboxHistPlotOptions.Size = New System.Drawing.Size(208, 104)
        Me.gboxHistPlotOptions.TabIndex = 14
        Me.gboxHistPlotOptions.TabStop = False
        Me.gboxHistPlotOptions.Text = "Histogram  Plot"
        '
        'ckboxHistSetNumBins
        '
        Me.ckboxHistSetNumBins.Checked = True
        Me.ckboxHistSetNumBins.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckboxHistSetNumBins.Location = New System.Drawing.Point(10, 14)
        Me.ckboxHistSetNumBins.Name = "ckboxHistSetNumBins"
        Me.ckboxHistSetNumBins.Size = New System.Drawing.Size(192, 16)
        Me.ckboxHistSetNumBins.TabIndex = 0
        Me.ckboxHistSetNumBins.Text = "Manually set the Number Of Bars"
        Me.ckboxHistSetNumBins.UseVisualStyleBackColor = True
        '
        'gboxHPNumBarSettings
        '
        Me.gboxHPNumBarSettings.Controls.Add(Me.rbtnHPExactNumBins)
        Me.gboxHPNumBarSettings.Controls.Add(Me.rbtnHPDiscreteBreakVals)
        Me.gboxHPNumBarSettings.Controls.Add(Me.tboxHPNumBins)
        Me.gboxHPNumBarSettings.Controls.Add(Me.lblHPNumBins)
        Me.gboxHPNumBarSettings.Location = New System.Drawing.Point(4, 28)
        Me.gboxHPNumBarSettings.Name = "gboxHPNumBarSettings"
        Me.gboxHPNumBarSettings.Size = New System.Drawing.Size(200, 68)
        Me.gboxHPNumBarSettings.TabIndex = 1
        Me.gboxHPNumBarSettings.TabStop = False
        '
        'rbtnHPExactNumBins
        '
        Me.rbtnHPExactNumBins.Location = New System.Drawing.Point(4, 50)
        Me.rbtnHPExactNumBins.Name = "rbtnHPExactNumBins"
        Me.rbtnHPExactNumBins.Size = New System.Drawing.Size(184, 16)
        Me.rbtnHPExactNumBins.TabIndex = 3
        Me.rbtnHPExactNumBins.Text = "Allow Decimal Break Values"
        Me.rbtnHPExactNumBins.UseVisualStyleBackColor = True
        '
        'rbtnHPDiscreteBreakVals
        '
        Me.rbtnHPDiscreteBreakVals.Checked = True
        Me.rbtnHPDiscreteBreakVals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnHPDiscreteBreakVals.Location = New System.Drawing.Point(4, 32)
        Me.rbtnHPDiscreteBreakVals.Name = "rbtnHPDiscreteBreakVals"
        Me.rbtnHPDiscreteBreakVals.Size = New System.Drawing.Size(192, 16)
        Me.rbtnHPDiscreteBreakVals.TabIndex = 2
        Me.rbtnHPDiscreteBreakVals.TabStop = True
        Me.rbtnHPDiscreteBreakVals.Text = "Adjust For Discrete Break Values"
        Me.rbtnHPDiscreteBreakVals.UseVisualStyleBackColor = True
        '
        'tboxHPNumBins
        '
        Me.tboxHPNumBins.Location = New System.Drawing.Point(94, 12)
        Me.tboxHPNumBins.Name = "tboxHPNumBins"
        Me.tboxHPNumBins.Size = New System.Drawing.Size(98, 20)
        Me.tboxHPNumBins.TabIndex = 0
        '
        'lblHPNumBins
        '
        Me.lblHPNumBins.Location = New System.Drawing.Point(4, 12)
        Me.lblHPNumBins.Name = "lblHPNumBins"
        Me.lblHPNumBins.Size = New System.Drawing.Size(94, 20)
        Me.lblHPNumBins.TabIndex = 1
        Me.lblHPNumBins.Text = "Number Of Bars :"
        Me.lblHPNumBins.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAxisOptions
        '
        Me.btnAxisOptions.Location = New System.Drawing.Point(8, 3)
        Me.btnAxisOptions.Name = "btnAxisOptions"
        Me.btnAxisOptions.Size = New System.Drawing.Size(208, 24)
        Me.btnAxisOptions.TabIndex = 13
        Me.btnAxisOptions.Text = "Axis Options"
        Me.btnAxisOptions.Visible = False
        '
        'gboxBoxPlotOptions
        '
        Me.gboxBoxPlotOptions.Controls.Add(Me.gboxBPPlotType)
        Me.gboxBoxPlotOptions.Location = New System.Drawing.Point(8, 248)
        Me.gboxBoxPlotOptions.Name = "gboxBoxPlotOptions"
        Me.gboxBoxPlotOptions.Size = New System.Drawing.Size(208, 88)
        Me.gboxBoxPlotOptions.TabIndex = 3
        Me.gboxBoxPlotOptions.TabStop = False
        Me.gboxBoxPlotOptions.Text = "Box/Whisker Plot"
        '
        'gboxBPPlotType
        '
        Me.gboxBPPlotType.Controls.Add(Me.btnBPViewDesc)
        Me.gboxBPPlotType.Controls.Add(Me.rbtnBPOverall)
        Me.gboxBPPlotType.Controls.Add(Me.rbtnBPMonthly)
        Me.gboxBPPlotType.Controls.Add(Me.rbtnBPYearly)
        Me.gboxBPPlotType.Controls.Add(Me.rbtnBPSeasonal)
        Me.gboxBPPlotType.Location = New System.Drawing.Point(4, 13)
        Me.gboxBPPlotType.Name = "gboxBPPlotType"
        Me.gboxBPPlotType.Size = New System.Drawing.Size(200, 69)
        Me.gboxBPPlotType.TabIndex = 13
        Me.gboxBPPlotType.TabStop = False
        Me.gboxBPPlotType.Text = "Plot Type"
        '
        'btnBPViewDesc
        '
        Me.btnBPViewDesc.Location = New System.Drawing.Point(72, 42)
        Me.btnBPViewDesc.Name = "btnBPViewDesc"
        Me.btnBPViewDesc.Size = New System.Drawing.Size(120, 20)
        Me.btnBPViewDesc.TabIndex = 7
        Me.btnBPViewDesc.Text = "Box Plot Description"
        Me.btnBPViewDesc.UseVisualStyleBackColor = True
        '
        'rbtnBPOverall
        '
        Me.rbtnBPOverall.Location = New System.Drawing.Point(4, 42)
        Me.rbtnBPOverall.Name = "rbtnBPOverall"
        Me.rbtnBPOverall.Size = New System.Drawing.Size(62, 16)
        Me.rbtnBPOverall.TabIndex = 6
        Me.rbtnBPOverall.Text = "Overall"
        '
        'rbtnBPMonthly
        '
        Me.rbtnBPMonthly.Checked = True
        Me.rbtnBPMonthly.Location = New System.Drawing.Point(4, 16)
        Me.rbtnBPMonthly.Name = "rbtnBPMonthly"
        Me.rbtnBPMonthly.Size = New System.Drawing.Size(62, 16)
        Me.rbtnBPMonthly.TabIndex = 3
        Me.rbtnBPMonthly.TabStop = True
        Me.rbtnBPMonthly.Text = "Monthly"
        '
        'rbtnBPYearly
        '
        Me.rbtnBPYearly.Location = New System.Drawing.Point(142, 16)
        Me.rbtnBPYearly.Name = "rbtnBPYearly"
        Me.rbtnBPYearly.Size = New System.Drawing.Size(56, 16)
        Me.rbtnBPYearly.TabIndex = 5
        Me.rbtnBPYearly.Text = "Yearly"
        '
        'rbtnBPSeasonal
        '
        Me.rbtnBPSeasonal.Location = New System.Drawing.Point(70, 16)
        Me.rbtnBPSeasonal.Name = "rbtnBPSeasonal"
        Me.rbtnBPSeasonal.Size = New System.Drawing.Size(70, 16)
        Me.rbtnBPSeasonal.TabIndex = 4
        Me.rbtnBPSeasonal.Text = "Seasonal"
        '
        'gboxTSPlotOptions
        '
        Me.gboxTSPlotOptions.Controls.Add(Me.gboxTSPlotType)
        Me.gboxTSPlotOptions.Location = New System.Drawing.Point(8, 32)
        Me.gboxTSPlotOptions.Name = "gboxTSPlotOptions"
        Me.gboxTSPlotOptions.Size = New System.Drawing.Size(208, 63)
        Me.gboxTSPlotOptions.TabIndex = 0
        Me.gboxTSPlotOptions.TabStop = False
        Me.gboxTSPlotOptions.Text = "Time Series Plot"
        '
        'gboxTSPlotType
        '
        Me.gboxTSPlotType.Controls.Add(Me.rbtnTSLine)
        Me.gboxTSPlotType.Controls.Add(Me.rbtnTSBoth)
        Me.gboxTSPlotType.Controls.Add(Me.rbtnTSPoint)
        Me.gboxTSPlotType.Location = New System.Drawing.Point(8, 16)
        Me.gboxTSPlotType.Name = "gboxTSPlotType"
        Me.gboxTSPlotType.Size = New System.Drawing.Size(192, 36)
        Me.gboxTSPlotType.TabIndex = 0
        Me.gboxTSPlotType.TabStop = False
        Me.gboxTSPlotType.Text = "Plot Type"
        '
        'rbtnTSLine
        '
        Me.rbtnTSLine.Location = New System.Drawing.Point(8, 16)
        Me.rbtnTSLine.Name = "rbtnTSLine"
        Me.rbtnTSLine.Size = New System.Drawing.Size(56, 16)
        Me.rbtnTSLine.TabIndex = 3
        Me.rbtnTSLine.Text = "Line"
        '
        'rbtnTSBoth
        '
        Me.rbtnTSBoth.Location = New System.Drawing.Point(140, 16)
        Me.rbtnTSBoth.Name = "rbtnTSBoth"
        Me.rbtnTSBoth.Size = New System.Drawing.Size(48, 16)
        Me.rbtnTSBoth.TabIndex = 5
        Me.rbtnTSBoth.Text = "Both"
        '
        'rbtnTSPoint
        '
        Me.rbtnTSPoint.Location = New System.Drawing.Point(70, 16)
        Me.rbtnTSPoint.Name = "rbtnTSPoint"
        Me.rbtnTSPoint.Size = New System.Drawing.Size(58, 16)
        Me.rbtnTSPoint.TabIndex = 4
        Me.rbtnTSPoint.Text = "Point"
        '
        'gboxDateInfo
        '
        Me.gboxDateInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboxDateInfo.Controls.Add(Me.dtpVisEndDate)
        Me.gboxDateInfo.Controls.Add(Me.dtpVisStartDate)
        Me.gboxDateInfo.Controls.Add(Me.lblEndDate)
        Me.gboxDateInfo.Controls.Add(Me.lblStartDate)
        Me.gboxDateInfo.Location = New System.Drawing.Point(548, 414)
        Me.gboxDateInfo.Name = "gboxDateInfo"
        Me.gboxDateInfo.Size = New System.Drawing.Size(232, 72)
        Me.gboxDateInfo.TabIndex = 2
        Me.gboxDateInfo.TabStop = False
        Me.gboxDateInfo.Text = "Date Range"
        '
        'dtpVisEndDate
        '
        Me.dtpVisEndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpVisEndDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtpVisEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVisEndDate.Location = New System.Drawing.Point(72, 44)
        Me.dtpVisEndDate.Name = "dtpVisEndDate"
        Me.dtpVisEndDate.Size = New System.Drawing.Size(154, 20)
        Me.dtpVisEndDate.TabIndex = 15
        '
        'dtpVisStartDate
        '
        Me.dtpVisStartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpVisStartDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtpVisStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVisStartDate.Location = New System.Drawing.Point(72, 20)
        Me.dtpVisStartDate.Name = "dtpVisStartDate"
        Me.dtpVisStartDate.Size = New System.Drawing.Size(154, 20)
        Me.dtpVisStartDate.TabIndex = 14
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(10, 48)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(62, 16)
        Me.lblEndDate.TabIndex = 13
        Me.lblEndDate.Text = "End Date :"
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(8, 24)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(64, 16)
        Me.lblStartDate.TabIndex = 12
        Me.lblStartDate.Text = "Start Date :"
        '
        'gboxVisDataSel
        '
        Me.gboxVisDataSel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboxVisDataSel.Controls.Add(Me.lvVisDataSeries)
        Me.gboxVisDataSel.Controls.Add(Me.lblVisDataSeries)
        Me.gboxVisDataSel.Controls.Add(Me.cboxVisVariable)
        Me.gboxVisDataSel.Controls.Add(Me.lblVisSite)
        Me.gboxVisDataSel.Controls.Add(Me.lblVisVariable)
        Me.gboxVisDataSel.Controls.Add(Me.cboxVisSite)
        Me.gboxVisDataSel.Location = New System.Drawing.Point(8, 329)
        Me.gboxVisDataSel.Name = "gboxVisDataSel"
        Me.gboxVisDataSel.Size = New System.Drawing.Size(536, 188)
        Me.gboxVisDataSel.TabIndex = 1
        Me.gboxVisDataSel.TabStop = False
        Me.gboxVisDataSel.Text = "Data To Visualize"
        '
        'lvVisDataSeries
        '
        Me.lvVisDataSeries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvVisDataSeries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvcolVisGenCategory, Me.lvcolVisSpeciation, Me.lvcolVisVarUnits, Me.lvcolVisTimeSupport, Me.lvcolVisTimeUnits, Me.lvcolVisSampleMedium, Me.lvcolVisValueType, Me.lvcolVisDataType, Me.lvcolVisQCLevel, Me.lvcolVisMethod, Me.lvcolVisOrganization, Me.lvcolVisSourceDesc, Me.lvcolVisCitation, Me.lvcolVisLocalDateRange, Me.lvcolVisUTCDateRange, Me.lvcolVisValueCount})
        Me.lvVisDataSeries.FullRowSelect = True
        Me.lvVisDataSeries.GridLines = True
        Me.lvVisDataSeries.HideSelection = False
        Me.lvVisDataSeries.Location = New System.Drawing.Point(6, 89)
        Me.lvVisDataSeries.MultiSelect = False
        Me.lvVisDataSeries.Name = "lvVisDataSeries"
        Me.lvVisDataSeries.Size = New System.Drawing.Size(520, 94)
        Me.lvVisDataSeries.TabIndex = 9
        Me.lvVisDataSeries.UseCompatibleStateImageBehavior = False
        Me.lvVisDataSeries.View = System.Windows.Forms.View.Details
        '
        'lvcolVisGenCategory
        '
        Me.lvcolVisGenCategory.Text = "General Category"
        Me.lvcolVisGenCategory.Width = 75
        '
        'lvcolVisSpeciation
        '
        Me.lvcolVisSpeciation.Text = "Speciation"
        Me.lvcolVisSpeciation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvcolVisVarUnits
        '
        Me.lvcolVisVarUnits.Text = "Variable Units"
        Me.lvcolVisVarUnits.Width = 75
        '
        'lvcolVisTimeSupport
        '
        Me.lvcolVisTimeSupport.Text = "Time Support"
        Me.lvcolVisTimeSupport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvcolVisTimeSupport.Width = 75
        '
        'lvcolVisTimeUnits
        '
        Me.lvcolVisTimeUnits.Text = "Time Units"
        Me.lvcolVisTimeUnits.Width = 75
        '
        'lvcolVisSampleMedium
        '
        Me.lvcolVisSampleMedium.Text = "Sample Medium"
        Me.lvcolVisSampleMedium.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolVisSampleMedium.Width = 75
        '
        'lvcolVisValueType
        '
        Me.lvcolVisValueType.Text = "Value Type"
        Me.lvcolVisValueType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolVisValueType.Width = 75
        '
        'lvcolVisDataType
        '
        Me.lvcolVisDataType.Text = "Data Type"
        Me.lvcolVisDataType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolVisDataType.Width = 75
        '
        'lvcolVisQCLevel
        '
        Me.lvcolVisQCLevel.Text = "Quality Control Level"
        Me.lvcolVisQCLevel.Width = 75
        '
        'lvcolVisMethod
        '
        Me.lvcolVisMethod.Text = "Method"
        Me.lvcolVisMethod.Width = 75
        '
        'lvcolVisOrganization
        '
        Me.lvcolVisOrganization.Text = "Organization"
        Me.lvcolVisOrganization.Width = 75
        '
        'lvcolVisSourceDesc
        '
        Me.lvcolVisSourceDesc.Text = "Source Description"
        Me.lvcolVisSourceDesc.Width = 75
        '
        'lvcolVisCitation
        '
        Me.lvcolVisCitation.Text = "Citation"
        '
        'lvcolVisLocalDateRange
        '
        Me.lvcolVisLocalDateRange.Text = "Local Date Range"
        Me.lvcolVisLocalDateRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolVisLocalDateRange.Width = 75
        '
        'lvcolVisUTCDateRange
        '
        Me.lvcolVisUTCDateRange.Text = "UTC Date Range"
        Me.lvcolVisUTCDateRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolVisUTCDateRange.Width = 75
        '
        'lvcolVisValueCount
        '
        Me.lvcolVisValueCount.Text = "Value Count"
        Me.lvcolVisValueCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolVisValueCount.Width = 75
        '
        'lblVisDataSeries
        '
        Me.lblVisDataSeries.Location = New System.Drawing.Point(8, 74)
        Me.lblVisDataSeries.Name = "lblVisDataSeries"
        Me.lblVisDataSeries.Size = New System.Drawing.Size(176, 16)
        Me.lblVisDataSeries.TabIndex = 10
        Me.lblVisDataSeries.Text = "Select a Data Series to View :"
        '
        'cboxVisVariable
        '
        Me.cboxVisVariable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxVisVariable.Location = New System.Drawing.Point(58, 44)
        Me.cboxVisVariable.Name = "cboxVisVariable"
        Me.cboxVisVariable.Size = New System.Drawing.Size(470, 21)
        Me.cboxVisVariable.TabIndex = 0
        '
        'lblVisSite
        '
        Me.lblVisSite.Location = New System.Drawing.Point(8, 18)
        Me.lblVisSite.Name = "lblVisSite"
        Me.lblVisSite.Size = New System.Drawing.Size(32, 16)
        Me.lblVisSite.TabIndex = 7
        Me.lblVisSite.Text = "Site :"
        Me.lblVisSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVisVariable
        '
        Me.lblVisVariable.Location = New System.Drawing.Point(8, 46)
        Me.lblVisVariable.Name = "lblVisVariable"
        Me.lblVisVariable.Size = New System.Drawing.Size(56, 16)
        Me.lblVisVariable.TabIndex = 8
        Me.lblVisVariable.Text = "Variable :"
        '
        'cboxVisSite
        '
        Me.cboxVisSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxVisSite.Location = New System.Drawing.Point(40, 16)
        Me.cboxVisSite.Name = "cboxVisSite"
        Me.cboxVisSite.Size = New System.Drawing.Size(488, 21)
        Me.cboxVisSite.TabIndex = 4
        '
        'tabctlPlots
        '
        Me.tabctlPlots.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabctlPlots.Controls.Add(Me.tabpgTimeSeries)
        Me.tabctlPlots.Controls.Add(Me.tabpgProbability)
        Me.tabctlPlots.Controls.Add(Me.tabpgHistogram)
        Me.tabctlPlots.Controls.Add(Me.tabpgBoxPlot)
        Me.tabctlPlots.Location = New System.Drawing.Point(8, 8)
        Me.tabctlPlots.Name = "tabctlPlots"
        Me.tabctlPlots.SelectedIndex = 0
        Me.tabctlPlots.Size = New System.Drawing.Size(536, 321)
        Me.tabctlPlots.TabIndex = 8
        '
        'tabpgTimeSeries
        '
        Me.tabpgTimeSeries.Controls.Add(Me.zg5TimeSeries)
        Me.tabpgTimeSeries.Location = New System.Drawing.Point(4, 22)
        Me.tabpgTimeSeries.Name = "tabpgTimeSeries"
        Me.tabpgTimeSeries.Size = New System.Drawing.Size(528, 295)
        Me.tabpgTimeSeries.TabIndex = 0
        Me.tabpgTimeSeries.Text = "Time Series"
        '
        'zg5TimeSeries
        '
        Me.zg5TimeSeries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zg5TimeSeries.IsShowHScrollBar = True
        Me.zg5TimeSeries.IsShowPointValues = True
        Me.zg5TimeSeries.IsShowVScrollBar = True
        Me.zg5TimeSeries.Location = New System.Drawing.Point(0, 0)
        Me.zg5TimeSeries.Name = "zg5TimeSeries"
        Me.zg5TimeSeries.ScrollGrace = 0
        Me.zg5TimeSeries.ScrollMaxX = 0
        Me.zg5TimeSeries.ScrollMaxY = 0
        Me.zg5TimeSeries.ScrollMaxY2 = 0
        Me.zg5TimeSeries.ScrollMinX = 0
        Me.zg5TimeSeries.ScrollMinY = 0
        Me.zg5TimeSeries.ScrollMinY2 = 0
        Me.zg5TimeSeries.Size = New System.Drawing.Size(528, 295)
        Me.zg5TimeSeries.TabIndex = 0
        '
        'tabpgProbability
        '
        Me.tabpgProbability.Controls.Add(Me.zg5Probability)
        Me.tabpgProbability.Location = New System.Drawing.Point(4, 22)
        Me.tabpgProbability.Name = "tabpgProbability"
        Me.tabpgProbability.Size = New System.Drawing.Size(528, 295)
        Me.tabpgProbability.TabIndex = 0
        Me.tabpgProbability.Text = "Probability"
        '
        'zg5Probability
        '
        Me.zg5Probability.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zg5Probability.IsShowHScrollBar = True
        Me.zg5Probability.IsShowPointValues = True
        Me.zg5Probability.IsShowVScrollBar = True
        Me.zg5Probability.Location = New System.Drawing.Point(0, 0)
        Me.zg5Probability.Name = "zg5Probability"
        Me.zg5Probability.ScrollGrace = 0
        Me.zg5Probability.ScrollMaxX = 0
        Me.zg5Probability.ScrollMaxY = 0
        Me.zg5Probability.ScrollMaxY2 = 0
        Me.zg5Probability.ScrollMinX = 0
        Me.zg5Probability.ScrollMinY = 0
        Me.zg5Probability.ScrollMinY2 = 0
        Me.zg5Probability.Size = New System.Drawing.Size(528, 295)
        Me.zg5Probability.TabIndex = 1
        '
        'tabpgHistogram
        '
        Me.tabpgHistogram.Controls.Add(Me.zg5Histogram)
        Me.tabpgHistogram.Location = New System.Drawing.Point(4, 22)
        Me.tabpgHistogram.Name = "tabpgHistogram"
        Me.tabpgHistogram.Size = New System.Drawing.Size(528, 295)
        Me.tabpgHistogram.TabIndex = 0
        Me.tabpgHistogram.Text = "Histogram"
        '
        'zg5Histogram
        '
        Me.zg5Histogram.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zg5Histogram.IsShowHScrollBar = True
        Me.zg5Histogram.IsShowPointValues = True
        Me.zg5Histogram.IsShowVScrollBar = True
        Me.zg5Histogram.Location = New System.Drawing.Point(0, 0)
        Me.zg5Histogram.Name = "zg5Histogram"
        Me.zg5Histogram.PointValueFormat = "N"
        Me.zg5Histogram.ScrollGrace = 0
        Me.zg5Histogram.ScrollMaxX = 0
        Me.zg5Histogram.ScrollMaxY = 0
        Me.zg5Histogram.ScrollMaxY2 = 0
        Me.zg5Histogram.ScrollMinX = 0
        Me.zg5Histogram.ScrollMinY = 0
        Me.zg5Histogram.ScrollMinY2 = 0
        Me.zg5Histogram.Size = New System.Drawing.Size(528, 295)
        Me.zg5Histogram.TabIndex = 2
        '
        'tabpgBoxPlot
        '
        Me.tabpgBoxPlot.Controls.Add(Me.zg5BoxPlot)
        Me.tabpgBoxPlot.Location = New System.Drawing.Point(4, 22)
        Me.tabpgBoxPlot.Name = "tabpgBoxPlot"
        Me.tabpgBoxPlot.Size = New System.Drawing.Size(528, 295)
        Me.tabpgBoxPlot.TabIndex = 0
        Me.tabpgBoxPlot.Text = "Box/Whisker"
        '
        'zg5BoxPlot
        '
        Me.zg5BoxPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zg5BoxPlot.IsShowHScrollBar = True
        Me.zg5BoxPlot.IsShowPointValues = True
        Me.zg5BoxPlot.IsShowVScrollBar = True
        Me.zg5BoxPlot.Location = New System.Drawing.Point(0, 0)
        Me.zg5BoxPlot.Name = "zg5BoxPlot"
        Me.zg5BoxPlot.ScrollGrace = 0
        Me.zg5BoxPlot.ScrollMaxX = 0
        Me.zg5BoxPlot.ScrollMaxY = 0
        Me.zg5BoxPlot.ScrollMaxY2 = 0
        Me.zg5BoxPlot.ScrollMinX = 0
        Me.zg5BoxPlot.ScrollMinY = 0
        Me.zg5BoxPlot.ScrollMinY2 = 0
        Me.zg5BoxPlot.Size = New System.Drawing.Size(528, 295)
        Me.zg5BoxPlot.TabIndex = 2
        '
        'tabpgEdit
        '
        Me.tabpgEdit.Controls.Add(Me.btnEditDataDeriveNewDS)
        Me.tabpgEdit.Controls.Add(Me.gboxEditFilter)
        Me.tabpgEdit.Controls.Add(Me.btnEditDataFlag)
        Me.tabpgEdit.Controls.Add(Me.btnEditDataInterpolate)
        Me.tabpgEdit.Controls.Add(Me.btnEditDataAdd)
        Me.tabpgEdit.Controls.Add(Me.btnEditDataRemove)
        Me.tabpgEdit.Controls.Add(Me.btnEditDataAdjust)
        Me.tabpgEdit.Controls.Add(Me.btnEditRestoreDefaults)
        Me.tabpgEdit.Controls.Add(Me.btnEditApplyChanges)
        Me.tabpgEdit.Controls.Add(Me.splitpnlEdit_PlotData)
        Me.tabpgEdit.Controls.Add(Me.gboxEditDataSel)
        Me.tabpgEdit.Location = New System.Drawing.Point(4, 22)
        Me.tabpgEdit.Name = "tabpgEdit"
        Me.tabpgEdit.Size = New System.Drawing.Size(784, 519)
        Me.tabpgEdit.TabIndex = 2
        Me.tabpgEdit.Text = "Edit"
        Me.tabpgEdit.UseVisualStyleBackColor = True
        '
        'btnEditDataDeriveNewDS
        '
        Me.btnEditDataDeriveNewDS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditDataDeriveNewDS.Location = New System.Drawing.Point(440, 303)
        Me.btnEditDataDeriveNewDS.Name = "btnEditDataDeriveNewDS"
        Me.btnEditDataDeriveNewDS.Size = New System.Drawing.Size(144, 24)
        Me.btnEditDataDeriveNewDS.TabIndex = 12
        Me.btnEditDataDeriveNewDS.Text = "Derive New Data Series"
        Me.ttipEdit.SetToolTip(Me.btnEditDataDeriveNewDS, "Derive/Create a New Data Series from the selected Data Series")
        Me.btnEditDataDeriveNewDS.UseVisualStyleBackColor = True
        '
        'gboxEditFilter
        '
        Me.gboxEditFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboxEditFilter.Controls.Add(Me.rbtnEditDFDate)
        Me.gboxEditFilter.Controls.Add(Me.gboxEditDFDate)
        Me.gboxEditFilter.Controls.Add(Me.rbtnEditDFValueThreshold)
        Me.gboxEditFilter.Controls.Add(Me.gboxEditDFValueThreshold)
        Me.gboxEditFilter.Controls.Add(Me.rbtnEditDFDataGap)
        Me.gboxEditFilter.Controls.Add(Me.gboxEditDFDataGaps)
        Me.gboxEditFilter.Controls.Add(Me.btnEditDFApplyFilter)
        Me.gboxEditFilter.Controls.Add(Me.btnEditDFClearSel)
        Me.gboxEditFilter.Controls.Add(Me.tboxEditDFVTChange)
        Me.gboxEditFilter.Controls.Add(Me.rbtnEditDFVTChange)
        Me.gboxEditFilter.Location = New System.Drawing.Point(440, 328)
        Me.gboxEditFilter.Name = "gboxEditFilter"
        Me.gboxEditFilter.Size = New System.Drawing.Size(340, 158)
        Me.gboxEditFilter.TabIndex = 4
        Me.gboxEditFilter.TabStop = False
        Me.gboxEditFilter.Text = "Data Filter"
        '
        'rbtnEditDFDate
        '
        Me.rbtnEditDFDate.Location = New System.Drawing.Point(12, 96)
        Me.rbtnEditDFDate.Name = "rbtnEditDFDate"
        Me.rbtnEditDFDate.Size = New System.Drawing.Size(16, 16)
        Me.rbtnEditDFDate.TabIndex = 14
        Me.rbtnEditDFDate.TabStop = True
        Me.rbtnEditDFDate.UseVisualStyleBackColor = True
        '
        'gboxEditDFDate
        '
        Me.gboxEditDFDate.Controls.Add(Me.dtpEditDFDBefore)
        Me.gboxEditDFDate.Controls.Add(Me.ckboxEditDFDBefore)
        Me.gboxEditDFDate.Controls.Add(Me.dtpEditDFDAfter)
        Me.gboxEditDFDate.Controls.Add(Me.ckboxEditDFDAfter)
        Me.gboxEditDFDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gboxEditDFDate.Location = New System.Drawing.Point(4, 98)
        Me.gboxEditDFDate.Name = "gboxEditDFDate"
        Me.gboxEditDFDate.Size = New System.Drawing.Size(224, 56)
        Me.gboxEditDFDate.TabIndex = 25
        Me.gboxEditDFDate.TabStop = False
        Me.gboxEditDFDate.Text = "     Date"
        '
        'dtpEditDFDBefore
        '
        Me.dtpEditDFDBefore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpEditDFDBefore.CustomFormat = "MM/dd/yyyy  hh:mm tt"
        Me.dtpEditDFDBefore.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEditDFDBefore.Location = New System.Drawing.Point(68, 12)
        Me.dtpEditDFDBefore.Name = "dtpEditDFDBefore"
        Me.dtpEditDFDBefore.Size = New System.Drawing.Size(150, 20)
        Me.dtpEditDFDBefore.TabIndex = 24
        '
        'ckboxEditDFDBefore
        '
        Me.ckboxEditDFDBefore.Location = New System.Drawing.Point(8, 14)
        Me.ckboxEditDFDBefore.Name = "ckboxEditDFDBefore"
        Me.ckboxEditDFDBefore.Size = New System.Drawing.Size(80, 16)
        Me.ckboxEditDFDBefore.TabIndex = 22
        Me.ckboxEditDFDBefore.Text = "Before Date"
        Me.ckboxEditDFDBefore.UseVisualStyleBackColor = True
        '
        'dtpEditDFDAfter
        '
        Me.dtpEditDFDAfter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpEditDFDAfter.CustomFormat = "MM/dd/yyyy  hh:mm tt"
        Me.dtpEditDFDAfter.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEditDFDAfter.Location = New System.Drawing.Point(68, 34)
        Me.dtpEditDFDAfter.Name = "dtpEditDFDAfter"
        Me.dtpEditDFDAfter.Size = New System.Drawing.Size(150, 20)
        Me.dtpEditDFDAfter.TabIndex = 25
        '
        'ckboxEditDFDAfter
        '
        Me.ckboxEditDFDAfter.Location = New System.Drawing.Point(8, 36)
        Me.ckboxEditDFDAfter.Name = "ckboxEditDFDAfter"
        Me.ckboxEditDFDAfter.Size = New System.Drawing.Size(80, 16)
        Me.ckboxEditDFDAfter.TabIndex = 23
        Me.ckboxEditDFDAfter.Text = "After "
        Me.ckboxEditDFDAfter.UseVisualStyleBackColor = True
        '
        'rbtnEditDFValueThreshold
        '
        Me.rbtnEditDFValueThreshold.Location = New System.Drawing.Point(12, 14)
        Me.rbtnEditDFValueThreshold.Name = "rbtnEditDFValueThreshold"
        Me.rbtnEditDFValueThreshold.Size = New System.Drawing.Size(16, 16)
        Me.rbtnEditDFValueThreshold.TabIndex = 0
        Me.rbtnEditDFValueThreshold.TabStop = True
        Me.rbtnEditDFValueThreshold.UseVisualStyleBackColor = True
        '
        'gboxEditDFValueThreshold
        '
        Me.gboxEditDFValueThreshold.Controls.Add(Me.tboxEditDFVTGreater)
        Me.gboxEditDFValueThreshold.Controls.Add(Me.ckboxEditDFVTGreater)
        Me.gboxEditDFValueThreshold.Controls.Add(Me.tboxEditDFVTLess)
        Me.gboxEditDFValueThreshold.Controls.Add(Me.ckboxEditDFVTLess)
        Me.gboxEditDFValueThreshold.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gboxEditDFValueThreshold.Location = New System.Drawing.Point(4, 16)
        Me.gboxEditDFValueThreshold.Name = "gboxEditDFValueThreshold"
        Me.gboxEditDFValueThreshold.Size = New System.Drawing.Size(136, 58)
        Me.gboxEditDFValueThreshold.TabIndex = 24
        Me.gboxEditDFValueThreshold.TabStop = False
        Me.gboxEditDFValueThreshold.Text = "     Value Threshold"
        '
        'tboxEditDFVTGreater
        '
        Me.tboxEditDFVTGreater.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxEditDFVTGreater.Location = New System.Drawing.Point(72, 12)
        Me.tboxEditDFVTGreater.Name = "tboxEditDFVTGreater"
        Me.tboxEditDFVTGreater.Size = New System.Drawing.Size(58, 20)
        Me.tboxEditDFVTGreater.TabIndex = 13
        Me.tboxEditDFVTGreater.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tboxEditDFVTGreater.WordWrap = False
        '
        'ckboxEditDFVTGreater
        '
        Me.ckboxEditDFVTGreater.Location = New System.Drawing.Point(8, 14)
        Me.ckboxEditDFVTGreater.Name = "ckboxEditDFVTGreater"
        Me.ckboxEditDFVTGreater.Size = New System.Drawing.Size(68, 16)
        Me.ckboxEditDFVTGreater.TabIndex = 15
        Me.ckboxEditDFVTGreater.Text = "Value >"
        Me.ckboxEditDFVTGreater.UseVisualStyleBackColor = True
        '
        'tboxEditDFVTLess
        '
        Me.tboxEditDFVTLess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxEditDFVTLess.Location = New System.Drawing.Point(72, 34)
        Me.tboxEditDFVTLess.Name = "tboxEditDFVTLess"
        Me.tboxEditDFVTLess.Size = New System.Drawing.Size(58, 20)
        Me.tboxEditDFVTLess.TabIndex = 14
        Me.tboxEditDFVTLess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tboxEditDFVTLess.WordWrap = False
        '
        'ckboxEditDFVTLess
        '
        Me.ckboxEditDFVTLess.Location = New System.Drawing.Point(8, 36)
        Me.ckboxEditDFVTLess.Name = "ckboxEditDFVTLess"
        Me.ckboxEditDFVTLess.Size = New System.Drawing.Size(68, 16)
        Me.ckboxEditDFVTLess.TabIndex = 16
        Me.ckboxEditDFVTLess.Text = "Value <"
        Me.ckboxEditDFVTLess.UseVisualStyleBackColor = True
        '
        'rbtnEditDFDataGap
        '
        Me.rbtnEditDFDataGap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnEditDFDataGap.Location = New System.Drawing.Point(152, 14)
        Me.rbtnEditDFDataGap.Name = "rbtnEditDFDataGap"
        Me.rbtnEditDFDataGap.Size = New System.Drawing.Size(16, 16)
        Me.rbtnEditDFDataGap.TabIndex = 23
        Me.rbtnEditDFDataGap.TabStop = True
        Me.rbtnEditDFDataGap.UseVisualStyleBackColor = True
        '
        'gboxEditDFDataGaps
        '
        Me.gboxEditDFDataGaps.Controls.Add(Me.cboxEditDFDGTimePeriod)
        Me.gboxEditDFDataGaps.Controls.Add(Me.lblEditDFDGTimePeriod)
        Me.gboxEditDFDataGaps.Controls.Add(Me.tboxEditDFDGValue)
        Me.gboxEditDFDataGaps.Controls.Add(Me.lblEditDFDGValue)
        Me.gboxEditDFDataGaps.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gboxEditDFDataGaps.Location = New System.Drawing.Point(144, 16)
        Me.gboxEditDFDataGaps.Name = "gboxEditDFDataGaps"
        Me.gboxEditDFDataGaps.Size = New System.Drawing.Size(192, 58)
        Me.gboxEditDFDataGaps.TabIndex = 22
        Me.gboxEditDFDataGaps.TabStop = False
        Me.gboxEditDFDataGaps.Text = "     Data Gaps"
        '
        'cboxEditDFDGTimePeriod
        '
        Me.cboxEditDFDGTimePeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxEditDFDGTimePeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxEditDFDGTimePeriod.FormattingEnabled = True
        Me.cboxEditDFDGTimePeriod.Location = New System.Drawing.Point(80, 34)
        Me.cboxEditDFDGTimePeriod.Name = "cboxEditDFDGTimePeriod"
        Me.cboxEditDFDGTimePeriod.Size = New System.Drawing.Size(108, 21)
        Me.cboxEditDFDGTimePeriod.TabIndex = 6
        '
        'lblEditDFDGTimePeriod
        '
        Me.lblEditDFDGTimePeriod.Location = New System.Drawing.Point(8, 36)
        Me.lblEditDFDGTimePeriod.Name = "lblEditDFDGTimePeriod"
        Me.lblEditDFDGTimePeriod.Size = New System.Drawing.Size(72, 16)
        Me.lblEditDFDGTimePeriod.TabIndex = 7
        Me.lblEditDFDGTimePeriod.Text = "Time Period : "
        Me.lblEditDFDGTimePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tboxEditDFDGValue
        '
        Me.tboxEditDFDGValue.Location = New System.Drawing.Point(80, 12)
        Me.tboxEditDFDGValue.Name = "tboxEditDFDGValue"
        Me.tboxEditDFDGValue.Size = New System.Drawing.Size(58, 20)
        Me.tboxEditDFDGValue.TabIndex = 5
        '
        'lblEditDFDGValue
        '
        Me.lblEditDFDGValue.Location = New System.Drawing.Point(8, 14)
        Me.lblEditDFDGValue.Name = "lblEditDFDGValue"
        Me.lblEditDFDGValue.Size = New System.Drawing.Size(72, 16)
        Me.lblEditDFDGValue.TabIndex = 4
        Me.lblEditDFDGValue.Text = "Value : "
        Me.lblEditDFDGValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnEditDFApplyFilter
        '
        Me.btnEditDFApplyFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditDFApplyFilter.Location = New System.Drawing.Point(242, 94)
        Me.btnEditDFApplyFilter.Name = "btnEditDFApplyFilter"
        Me.btnEditDFApplyFilter.Size = New System.Drawing.Size(86, 24)
        Me.btnEditDFApplyFilter.TabIndex = 8
        Me.btnEditDFApplyFilter.Text = "Apply Filter"
        Me.btnEditDFApplyFilter.UseVisualStyleBackColor = True
        '
        'btnEditDFClearSel
        '
        Me.btnEditDFClearSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditDFClearSel.Location = New System.Drawing.Point(234, 124)
        Me.btnEditDFClearSel.Name = "btnEditDFClearSel"
        Me.btnEditDFClearSel.Size = New System.Drawing.Size(100, 24)
        Me.btnEditDFClearSel.TabIndex = 7
        Me.btnEditDFClearSel.Text = "Clear Selection"
        Me.btnEditDFClearSel.UseVisualStyleBackColor = True
        '
        'tboxEditDFVTChange
        '
        Me.tboxEditDFVTChange.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tboxEditDFVTChange.Location = New System.Drawing.Point(172, 78)
        Me.tboxEditDFVTChange.Name = "tboxEditDFVTChange"
        Me.tboxEditDFVTChange.Size = New System.Drawing.Size(56, 20)
        Me.tboxEditDFVTChange.TabIndex = 6
        Me.tboxEditDFVTChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tboxEditDFVTChange.WordWrap = False
        '
        'rbtnEditDFVTChange
        '
        Me.rbtnEditDFVTChange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbtnEditDFVTChange.Location = New System.Drawing.Point(12, 78)
        Me.rbtnEditDFVTChange.Name = "rbtnEditDFVTChange"
        Me.rbtnEditDFVTChange.Size = New System.Drawing.Size(168, 20)
        Me.rbtnEditDFVTChange.TabIndex = 2
        Me.rbtnEditDFVTChange.TabStop = True
        Me.rbtnEditDFVTChange.Text = "Value Change Threshold >= "
        Me.rbtnEditDFVTChange.UseVisualStyleBackColor = True
        '
        'btnEditDataFlag
        '
        Me.btnEditDataFlag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditDataFlag.Image = CType(resources.GetObject("btnEditDataFlag.Image"), System.Drawing.Image)
        Me.btnEditDataFlag.Location = New System.Drawing.Point(688, 301)
        Me.btnEditDataFlag.Name = "btnEditDataFlag"
        Me.btnEditDataFlag.Size = New System.Drawing.Size(28, 28)
        Me.btnEditDataFlag.TabIndex = 11
        Me.ttipEdit.SetToolTip(Me.btnEditDataFlag, "Flag the selected Values in the Data Series")
        Me.btnEditDataFlag.UseVisualStyleBackColor = True
        '
        'btnEditDataInterpolate
        '
        Me.btnEditDataInterpolate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditDataInterpolate.Image = CType(resources.GetObject("btnEditDataInterpolate.Image"), System.Drawing.Image)
        Me.btnEditDataInterpolate.Location = New System.Drawing.Point(656, 301)
        Me.btnEditDataInterpolate.Name = "btnEditDataInterpolate"
        Me.btnEditDataInterpolate.Size = New System.Drawing.Size(28, 28)
        Me.btnEditDataInterpolate.TabIndex = 10
        Me.ttipEdit.SetToolTip(Me.btnEditDataInterpolate, "Interpolate Values")
        Me.btnEditDataInterpolate.UseVisualStyleBackColor = True
        '
        'btnEditDataAdd
        '
        Me.btnEditDataAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditDataAdd.Image = CType(resources.GetObject("btnEditDataAdd.Image"), System.Drawing.Image)
        Me.btnEditDataAdd.Location = New System.Drawing.Point(752, 301)
        Me.btnEditDataAdd.Name = "btnEditDataAdd"
        Me.btnEditDataAdd.Size = New System.Drawing.Size(28, 28)
        Me.btnEditDataAdd.TabIndex = 9
        Me.ttipEdit.SetToolTip(Me.btnEditDataAdd, "Add a new Value to the Data Series")
        Me.btnEditDataAdd.UseVisualStyleBackColor = True
        '
        'btnEditDataRemove
        '
        Me.btnEditDataRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditDataRemove.Image = CType(resources.GetObject("btnEditDataRemove.Image"), System.Drawing.Image)
        Me.btnEditDataRemove.Location = New System.Drawing.Point(720, 301)
        Me.btnEditDataRemove.Name = "btnEditDataRemove"
        Me.btnEditDataRemove.Size = New System.Drawing.Size(28, 28)
        Me.btnEditDataRemove.TabIndex = 8
        Me.ttipEdit.SetToolTip(Me.btnEditDataRemove, "Remove the selected Values from the Data Series")
        Me.btnEditDataRemove.UseVisualStyleBackColor = True
        '
        'btnEditDataAdjust
        '
        Me.btnEditDataAdjust.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditDataAdjust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditDataAdjust.Image = CType(resources.GetObject("btnEditDataAdjust.Image"), System.Drawing.Image)
        Me.btnEditDataAdjust.Location = New System.Drawing.Point(624, 301)
        Me.btnEditDataAdjust.Name = "btnEditDataAdjust"
        Me.btnEditDataAdjust.Size = New System.Drawing.Size(28, 28)
        Me.btnEditDataAdjust.TabIndex = 7
        Me.ttipEdit.SetToolTip(Me.btnEditDataAdjust, "Adjust the selected Values in the Data Series")
        Me.btnEditDataAdjust.UseVisualStyleBackColor = True
        '
        'btnEditRestoreDefaults
        '
        Me.btnEditRestoreDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditRestoreDefaults.Location = New System.Drawing.Point(444, 490)
        Me.btnEditRestoreDefaults.Name = "btnEditRestoreDefaults"
        Me.btnEditRestoreDefaults.Size = New System.Drawing.Size(152, 24)
        Me.btnEditRestoreDefaults.TabIndex = 6
        Me.btnEditRestoreDefaults.Text = "Restore Original Values "
        Me.ttipEdit.SetToolTip(Me.btnEditRestoreDefaults, "Restore the data from the Database")
        Me.btnEditRestoreDefaults.UseVisualStyleBackColor = True
        '
        'btnEditApplyChanges
        '
        Me.btnEditApplyChanges.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditApplyChanges.Location = New System.Drawing.Point(602, 490)
        Me.btnEditApplyChanges.Name = "btnEditApplyChanges"
        Me.btnEditApplyChanges.Size = New System.Drawing.Size(172, 26)
        Me.btnEditApplyChanges.TabIndex = 5
        Me.btnEditApplyChanges.Text = "Apply Changes To Database"
        Me.ttipEdit.SetToolTip(Me.btnEditApplyChanges, "Apply any changes to the Database")
        Me.btnEditApplyChanges.UseVisualStyleBackColor = True
        '
        'splitpnlEdit_PlotData
        '
        Me.splitpnlEdit_PlotData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitpnlEdit_PlotData.BackColor = System.Drawing.SystemColors.Highlight
        Me.splitpnlEdit_PlotData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.splitpnlEdit_PlotData.Location = New System.Drawing.Point(4, 8)
        Me.splitpnlEdit_PlotData.Name = "splitpnlEdit_PlotData"
        '
        'splitpnlEdit_PlotData.Panel1
        '
        Me.splitpnlEdit_PlotData.Panel1.Controls.Add(Me.zg5EditPlot)
        '
        'splitpnlEdit_PlotData.Panel2
        '
        Me.splitpnlEdit_PlotData.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.splitpnlEdit_PlotData.Panel2.Controls.Add(Me.dgvEditTable)
        Me.splitpnlEdit_PlotData.Size = New System.Drawing.Size(776, 289)
        Me.splitpnlEdit_PlotData.SplitterDistance = 430
        Me.splitpnlEdit_PlotData.TabIndex = 3
        '
        'zg5EditPlot
        '
        Me.zg5EditPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.zg5EditPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zg5EditPlot.IsShowHScrollBar = True
        Me.zg5EditPlot.IsShowPointValues = True
        Me.zg5EditPlot.IsShowVScrollBar = True
        Me.zg5EditPlot.Location = New System.Drawing.Point(0, 0)
        Me.zg5EditPlot.Name = "zg5EditPlot"
        Me.zg5EditPlot.ScrollGrace = 0
        Me.zg5EditPlot.ScrollMaxX = 0
        Me.zg5EditPlot.ScrollMaxY = 0
        Me.zg5EditPlot.ScrollMaxY2 = 0
        Me.zg5EditPlot.ScrollMinX = 0
        Me.zg5EditPlot.ScrollMinY = 0
        Me.zg5EditPlot.ScrollMinY2 = 0
        Me.zg5EditPlot.Size = New System.Drawing.Size(426, 285)
        Me.zg5EditPlot.TabIndex = 2
        '
        'dgvEditTable
        '
        Me.dgvEditTable.AllowUserToAddRows = False
        Me.dgvEditTable.AllowUserToDeleteRows = False
        Me.dgvEditTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvEditTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEditTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEditTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEditTable.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEditTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEditTable.Location = New System.Drawing.Point(0, 0)
        Me.dgvEditTable.Name = "dgvEditTable"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEditTable.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEditTable.RowHeadersWidth = 20
        Me.dgvEditTable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvEditTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEditTable.Size = New System.Drawing.Size(338, 285)
        Me.dgvEditTable.TabIndex = 0
        '
        'gboxEditDataSel
        '
        Me.gboxEditDataSel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboxEditDataSel.Controls.Add(Me.lvEditDataSeries)
        Me.gboxEditDataSel.Controls.Add(Me.lblEditDataSeries)
        Me.gboxEditDataSel.Controls.Add(Me.cboxEditVariable)
        Me.gboxEditDataSel.Controls.Add(Me.lblEditSite)
        Me.gboxEditDataSel.Controls.Add(Me.lblEditVariable)
        Me.gboxEditDataSel.Controls.Add(Me.cboxEditSite)
        Me.gboxEditDataSel.Location = New System.Drawing.Point(4, 297)
        Me.gboxEditDataSel.Name = "gboxEditDataSel"
        Me.gboxEditDataSel.Size = New System.Drawing.Size(428, 220)
        Me.gboxEditDataSel.TabIndex = 2
        Me.gboxEditDataSel.TabStop = False
        Me.gboxEditDataSel.Text = "Data To Plot"
        '
        'lvEditDataSeries
        '
        Me.lvEditDataSeries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEditDataSeries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvcolEditGenCategory, Me.lvcolEditSpeciation, Me.lvcolEditVarUnits, Me.lvcolEditTimeSupport, Me.lvcolEditTimeUnits, Me.lvcolEditSampleMedium, Me.lvcolEditValueType, Me.lvcolEditDataType, Me.lvcolEditQCLevel, Me.lvcolEditMethod, Me.lvcolEditOrganization, Me.lvcolEditSourceDesc, Me.lvcolEditCitation, Me.lvcolEditLocalDateRange, Me.lvcolEditUTCDateRange, Me.lvcolEditValueCount})
        Me.lvEditDataSeries.FullRowSelect = True
        Me.lvEditDataSeries.GridLines = True
        Me.lvEditDataSeries.HideSelection = False
        Me.lvEditDataSeries.Location = New System.Drawing.Point(8, 88)
        Me.lvEditDataSeries.MultiSelect = False
        Me.lvEditDataSeries.Name = "lvEditDataSeries"
        Me.lvEditDataSeries.Size = New System.Drawing.Size(412, 126)
        Me.lvEditDataSeries.TabIndex = 9
        Me.lvEditDataSeries.UseCompatibleStateImageBehavior = False
        Me.lvEditDataSeries.View = System.Windows.Forms.View.Details
        '
        'lvcolEditGenCategory
        '
        Me.lvcolEditGenCategory.Text = "General Category"
        Me.lvcolEditGenCategory.Width = 75
        '
        'lvcolEditSpeciation
        '
        Me.lvcolEditSpeciation.Text = "Speciation"
        Me.lvcolEditSpeciation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvcolEditVarUnits
        '
        Me.lvcolEditVarUnits.Text = "Variable Units"
        Me.lvcolEditVarUnits.Width = 75
        '
        'lvcolEditTimeSupport
        '
        Me.lvcolEditTimeSupport.Text = "Time Support"
        Me.lvcolEditTimeSupport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvcolEditTimeSupport.Width = 75
        '
        'lvcolEditTimeUnits
        '
        Me.lvcolEditTimeUnits.Text = "Time Units"
        Me.lvcolEditTimeUnits.Width = 75
        '
        'lvcolEditSampleMedium
        '
        Me.lvcolEditSampleMedium.Text = "Sample Medium"
        Me.lvcolEditSampleMedium.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolEditSampleMedium.Width = 75
        '
        'lvcolEditValueType
        '
        Me.lvcolEditValueType.Text = "Value Type"
        Me.lvcolEditValueType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolEditValueType.Width = 75
        '
        'lvcolEditDataType
        '
        Me.lvcolEditDataType.Text = "Data Type"
        Me.lvcolEditDataType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolEditDataType.Width = 75
        '
        'lvcolEditQCLevel
        '
        Me.lvcolEditQCLevel.Text = "Quality Control Level"
        Me.lvcolEditQCLevel.Width = 75
        '
        'lvcolEditMethod
        '
        Me.lvcolEditMethod.Text = "Method"
        Me.lvcolEditMethod.Width = 75
        '
        'lvcolEditOrganization
        '
        Me.lvcolEditOrganization.Text = "Organization"
        Me.lvcolEditOrganization.Width = 75
        '
        'lvcolEditSourceDesc
        '
        Me.lvcolEditSourceDesc.Text = "Source Description"
        Me.lvcolEditSourceDesc.Width = 75
        '
        'lvcolEditCitation
        '
        Me.lvcolEditCitation.Text = "Citation"
        '
        'lvcolEditLocalDateRange
        '
        Me.lvcolEditLocalDateRange.Text = "Date Range"
        Me.lvcolEditLocalDateRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolEditLocalDateRange.Width = 75
        '
        'lvcolEditUTCDateRange
        '
        Me.lvcolEditUTCDateRange.Text = "UTC Date Range"
        Me.lvcolEditUTCDateRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolEditUTCDateRange.Width = 75
        '
        'lvcolEditValueCount
        '
        Me.lvcolEditValueCount.Text = "Value Count"
        Me.lvcolEditValueCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolEditValueCount.Width = 75
        '
        'lblEditDataSeries
        '
        Me.lblEditDataSeries.Location = New System.Drawing.Point(8, 74)
        Me.lblEditDataSeries.Name = "lblEditDataSeries"
        Me.lblEditDataSeries.Size = New System.Drawing.Size(176, 16)
        Me.lblEditDataSeries.TabIndex = 10
        Me.lblEditDataSeries.Text = "Select a Data Series to Edit :"
        '
        'cboxEditVariable
        '
        Me.cboxEditVariable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxEditVariable.Location = New System.Drawing.Point(58, 44)
        Me.cboxEditVariable.Name = "cboxEditVariable"
        Me.cboxEditVariable.Size = New System.Drawing.Size(362, 21)
        Me.cboxEditVariable.TabIndex = 0
        '
        'lblEditSite
        '
        Me.lblEditSite.Location = New System.Drawing.Point(8, 18)
        Me.lblEditSite.Name = "lblEditSite"
        Me.lblEditSite.Size = New System.Drawing.Size(32, 16)
        Me.lblEditSite.TabIndex = 7
        Me.lblEditSite.Text = "Site :"
        Me.lblEditSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEditVariable
        '
        Me.lblEditVariable.Location = New System.Drawing.Point(8, 46)
        Me.lblEditVariable.Name = "lblEditVariable"
        Me.lblEditVariable.Size = New System.Drawing.Size(56, 16)
        Me.lblEditVariable.TabIndex = 8
        Me.lblEditVariable.Text = "Variable :"
        '
        'cboxEditSite
        '
        Me.cboxEditSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxEditSite.Location = New System.Drawing.Point(40, 16)
        Me.cboxEditSite.Name = "cboxEditSite"
        Me.cboxEditSite.Size = New System.Drawing.Size(380, 21)
        Me.cboxEditSite.TabIndex = 4
        '
        'cmnuQueryDataRightClick
        '
        Me.cmnuQueryDataRightClick.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuQDRCPlot, Me.mnuQDRCEdit, Me.mnuQDRCViewMeta, Me.mnuQDRCLine1, Me.mnuQDRCSingleExport, Me.mnuQDRCExportMeta, Me.MenuItem1, Me.mnuQDRCSelectSingle, Me.mnuQDRCSelectAll, Me.mnuQDRCSelectNone})
        '
        'mnuQDRCPlot
        '
        Me.mnuQDRCPlot.DefaultItem = True
        Me.mnuQDRCPlot.Index = 0
        Me.mnuQDRCPlot.Text = "Plot"
        '
        'mnuQDRCEdit
        '
        Me.mnuQDRCEdit.Index = 1
        Me.mnuQDRCEdit.Text = "Edit"
        '
        'mnuQDRCViewMeta
        '
        Me.mnuQDRCViewMeta.Index = 2
        Me.mnuQDRCViewMeta.Text = "View MetaData"
        '
        'mnuQDRCLine1
        '
        Me.mnuQDRCLine1.Index = 3
        Me.mnuQDRCLine1.Text = "-"
        '
        'mnuQDRCSingleExport
        '
        Me.mnuQDRCSingleExport.Index = 4
        Me.mnuQDRCSingleExport.Text = "Export Single Data"
        '
        'mnuQDRCExportMeta
        '
        Me.mnuQDRCExportMeta.Index = 5
        Me.mnuQDRCExportMeta.Text = "Export Single MetaData"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 6
        Me.MenuItem1.Text = "-"
        '
        'mnuQDRCSelectSingle
        '
        Me.mnuQDRCSelectSingle.Index = 7
        Me.mnuQDRCSelectSingle.Text = "Select for Group Export"
        '
        'mnuQDRCSelectAll
        '
        Me.mnuQDRCSelectAll.Index = 8
        Me.mnuQDRCSelectAll.Text = "Select All"
        '
        'mnuQDRCSelectNone
        '
        Me.mnuQDRCSelectNone.Index = 9
        Me.mnuQDRCSelectNone.Text = "Select None"
        '
        'sfdExportMyDB
        '
        Me.sfdExportMyDB.DefaultExt = "csv"
        Me.sfdExportMyDB.FileName = "MyDB"
        Me.sfdExportMyDB.Filter = "Comma Delimited Format(*.csv)|*.csv|TabDelimited(*.txt)|*.txt"
        Me.sfdExportMyDB.Title = "Export as MyDB Format"
        '
        'sfdExportMetadata
        '
        Me.sfdExportMetadata.DefaultExt = "xml"
        Me.sfdExportMetadata.FileName = "Metadata"
        Me.sfdExportMetadata.Filter = "Metadata(*.xml)|*.xml"
        Me.sfdExportMetadata.OverwritePrompt = False
        Me.sfdExportMetadata.SupportMultiDottedExtensions = True
        Me.sfdExportMetadata.Title = "Export Metadata to XML file"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'frmODMTools
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 545)
        Me.Controls.Add(Me.tabctlODMTools)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = New System.Drawing.Size(800, 552)
        Me.Name = "frmODMTools"
        Me.Text = "ODM Tools"
        Me.tabctlODMTools.ResumeLayout(False)
        Me.tabpgQuery.ResumeLayout(False)
        Me.tabpgQuery.PerformLayout()
        Me.grp_qryVars.ResumeLayout(False)
        Me.grp_qryVars.PerformLayout()
        Me.grp_qryVarSelect.ResumeLayout(False)
        Me.grp_qryVarSelect.PerformLayout()
        Me.grp_qrySites.ResumeLayout(False)
        Me.grp_qrySites.PerformLayout()
        Me.grp_qrySiteSelect.ResumeLayout(False)
        Me.grp_qrySiteSelect.PerformLayout()
        Me.grp_qrySources.ResumeLayout(False)
        Me.grp_qrySources.PerformLayout()
        Me.grp_qrySrcSelect.ResumeLayout(False)
        Me.grp_qrySrcSelect.PerformLayout()
        Me.grp_qryOther.ResumeLayout(False)
        Me.grp_qryOther.PerformLayout()
        Me.grp_qryNumObs.ResumeLayout(False)
        CType(Me.num_qryObs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpgVisualize.ResumeLayout(False)
        Me.tabctlPlotOptions.ResumeLayout(False)
        Me.tabpgSummary.ResumeLayout(False)
        Me.gboxStatistics.ResumeLayout(False)
        Me.gboxStatistics.PerformLayout()
        Me.tabpgOptions.ResumeLayout(False)
        Me.gboxHistPlotOptions.ResumeLayout(False)
        Me.gboxHPNumBarSettings.ResumeLayout(False)
        Me.gboxHPNumBarSettings.PerformLayout()
        Me.gboxBoxPlotOptions.ResumeLayout(False)
        Me.gboxBPPlotType.ResumeLayout(False)
        Me.gboxTSPlotOptions.ResumeLayout(False)
        Me.gboxTSPlotType.ResumeLayout(False)
        Me.gboxDateInfo.ResumeLayout(False)
        Me.gboxVisDataSel.ResumeLayout(False)
        Me.tabctlPlots.ResumeLayout(False)
        Me.tabpgTimeSeries.ResumeLayout(False)
        Me.tabpgProbability.ResumeLayout(False)
        Me.tabpgHistogram.ResumeLayout(False)
        Me.tabpgBoxPlot.ResumeLayout(False)
        Me.tabpgEdit.ResumeLayout(False)
        Me.gboxEditFilter.ResumeLayout(False)
        Me.gboxEditFilter.PerformLayout()
        Me.gboxEditDFDate.ResumeLayout(False)
        Me.gboxEditDFValueThreshold.ResumeLayout(False)
        Me.gboxEditDFValueThreshold.PerformLayout()
        Me.gboxEditDFDataGaps.ResumeLayout(False)
        Me.gboxEditDFDataGaps.PerformLayout()
        Me.splitpnlEdit_PlotData.Panel1.ResumeLayout(False)
        Me.splitpnlEdit_PlotData.Panel2.ResumeLayout(False)
        Me.splitpnlEdit_PlotData.ResumeLayout(False)
        CType(Me.dgvEditTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxEditDataSel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub



#End Region

#Region " Member Variables "
    'All Tabs
    Private m_EXEDirectory As String = "" 'holds the directory for where the ODMTools.exe is located

    'Query Tab
    Private m_qryTabLoaded As Boolean = False 'tracks if the Query Tab has been loaded or not
    Private m_qrySiteSelectionMethod As String = "OR" 'The method used for multiple Site Queries
    Private m_qryVariableSelectionMethod As String = "OR" 'The method used for multiple Variable Queries
    Private m_qrySourceSelectionMethod As String = "AND" 'The method used to query multiple Sources
    Private m_qryOtherSelectionMethod As String = "AND" 'The method used for all of the queries on the query tab page
    Private m_qryNumObsMethod As String = " <= " 'The method used to query by number of observations
    Private m_qrySeriesID() As String 'The series IDs of the Query Results

    'Visualize Tab
    Private m_IsPlotCurrent_TimeSeries As Boolean = False 'tracks if the Time Series Plot on the Visualize Tab is current or not
    Private m_IsPlotCurrent_Probability As Boolean = False 'tracks if the Probability Plot on the Visualize Tab is current or not
    Private m_IsPlotCurrent_Histogram As Boolean = False 'tracks if the Histogram Plot on the Visualize Tab is current or not
    Private m_IsPlotCurrent_BoxPlot As Boolean = False 'tracks if the Box/Whisker Plot on the Visualize Tab is current or not
    Private m_NewPlotCriteriaSelected As Boolean = True 'tracks if new criteria for the Plots have been selected (ie. site, variable, date range, etc)
    Private m_VisualizeTabLoaded As Boolean = False 'tracks if the Visualize Tab has been loaded or not
    Private m_LoadingVisualizeTab As Boolean = False 'tracks if currently loading the Visualize Tab -> used so certain event don't fire (may cause errors if they do) while loading is occurring
    Private m_LoadingVisDateRange As Boolean = False 'tracks if loading the date range for the current site/variable selection on the Visualize Tab 
    Private m_InitialVisSiteSelIndex As Integer = 0 'holds the initial Index to select when sites are loaded for the Visualize Tab
    Private m_VisualizeIDs As System.Collections.ArrayList 'A collection of IDs needed for plotting the data on the Visualize tab page
    Private m_VisPlotData As Data.DataTable 'holds the data for the selected data series
    Private Const m_MaxHistBins As Integer = 20 'holds the maximum number of Bins for a Histogram plot, 20 = selected due to spacing of values on the plot
    Private m_VisEditNumbBinsValidated As Boolean = False 'tracks if the user input number of bins for the Histogram plot has been validated or not

    'Edit Tab
    Private m_IsEditTabEnabled As Boolean = True 'Tracks if the Edit Tab can be used by the user -> is loaded and active
    Private m_EditTabLoaded As Boolean = False 'tracks if the Edit Tab is loaded or not
    Private m_LoadingEditTab As Boolean = False 'tracks if currently loading the Edit Tab -> used so certain event don't fire (may cause errors if they do) while loading is occurring
    Private m_LoadingEditDateRange As Boolean = False 'tracks if loading the Date Range for the selected Data Series on the Edit Tab
    Private m_InitialEditSiteSelIndex As Integer = 0 'holds the initial Index to select when sites are loaded for the Edit Tab
    Private m_EditIDs As System.Collections.ArrayList 'A collection of IDs needed for accessing the data on the Edit tab page
    Private m_EditData As Data.DataTable 'holds the current copy of data that is to be or currently being edited
    Private m_EditData_Graphing As DataTable
    Private m_EditSelPtIndexes As System.Collections.ArrayList 'A collection of Indexes of points from m_EditData to be/are selected in the Plot,Table
    Private m_EditHavePointsSelected As Boolean = False 'tracks if any points are currently selected on the Edit tab or not
    Private m_EditHaveEditsUncommitted As Boolean = False 'tracks if have any Edits to the data that have not been committed to the database yet.
    Private Const m_EditDFMethod_Both As String = "Both" 'Data Filter Method = Both, used for both Value Threshold and Date Data Filters
    Private Const m_EditDFVTMethod_Greater As String = "Greater Than" 'Data Filter Value Threshold Method = Greater Than (>)
    Private Const m_EditDFVTMethod_Less As String = "Less Than" 'Data Filter Value Threshold Method = Less Than (<)
    Private Const m_EditDFDMethod_Before As String = "Before" 'Data Filter Date Method = Before (<)
    Private Const m_EditDFDMethod_After As String = "After" 'Data Filter Date Method = After (>)
    'Private m_EditRemoveDFIDs As System.Collections.ArrayList 'A collection of DerivedFromIDs to be deleted from the DerivedFrom, Data Values tables when edits are saved to the database
    'Private m_EditHaveRemoveDFIDs As Boolean = False 'tracks if have any DerivedFromIDs to be deleted from the database (stored in m_EditRemoveDFIDs) when edits are saved to the database
    Private m_EditTableColName_DateTime As String 'holds the LocalDateTime column name for the Data Table on the Edit Tab, NOTE: This is set when the Table is loaded on the Edit Tab
    Private m_EditTableColName_UTCDateTime As String 'holds the UTCDateTime column name for the Data Table on the Edit Tab, NOTE: This is set when the Table is loaded on the Edit Tab
    Private m_EditTableColName_Value As String 'holds the DataValue column name for the Data Table on the Edit Tab, NOTE: This is set when the Table is loaded on the Edit Tab
    Private m_EditHaveDeletedValIDs As Boolean = False 'tracks if have any ValueIDs to be deleted from the database (stored in m_EditDeletedValIDs) when edits are saved to the database
    Private m_EditDeletedValIDs As System.Collections.ArrayList 'A collection of ValueIDs to be deleted from the DataValues table when edits are saved to the database
    Private m_EditUpdatingSelection As Boolean = False 'tracks if currently updating the selection (points selected) in the Data Table/Plot areas of the Edit Tab
    Private m_EditDeletingVals As Boolean = False 'tracks if currently deleting Values from the Data Table (this is not when saving edits to the Database, it is only for making the current Data Series look correct for the edits the user wants)
    Private m_EditAddingVals As Boolean = False 'tracks if adding values to the current Data Series (this is not when saving added values (edits) to the Database, it is only for making the current Data Series look correct for the edits the user wants)
    Private m_EditNoDataVal As Double 'holds the No Data Value for the currently selected Data Series on the Edit Tab.
    Private m_Edit_SelZVal As String = "Selected" 'holds the col name for m_EditData to put data into to sel plot values
    Private m_XBorder As Double = 0.025
    Private m_YBorder As Double = 0.1


    Private CurveEditingColor As Drawing.Color = Color.Black
    'Public Originaldt As Data.DataTable
    'Public Editdt As DataTable
    Public newseriesID As Integer = 0


#End Region

#Region " Enumerations "

    'Contains an enumeration for Data Gap Time Periods on the Edit Tab
    Private Enum enumEditDGTimePeriods
        Minutes
        Hours
        Days
        Months
        Years
    End Enum

#End Region

#Region " Main Form Functions "

    Private Sub ODMTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Called when the program begins
        'Checks if there are any saved settings -> if there are no saved settings it opens the new connection dialog box
        'Prepares the listboxes for the query tab, initialized variables for the Visualize and Edit Tabs
        'Loads Listbox selections from the Database, Loads Existing connection settings
        'Sets up the listboxes, sets default values, SettingsChanged -> Tracks whether cettings have been changed
        'the inputs/outputs are standard for form events

        'Visualize Tab
        m_VisualizeTabLoaded = False
        m_InitialVisSiteSelIndex = 0
        'set m_IsPlotCurrent_* = True so plots will initialize correctly
        m_IsPlotCurrent_TimeSeries = True
        m_IsPlotCurrent_Probability = True
        m_IsPlotCurrent_Histogram = True
        m_IsPlotCurrent_BoxPlot = True

        'Edit Tab
        m_EditTabLoaded = False
        m_InitialEditSiteSelIndex = 0

		'Query Tab
        g_CurrOptions = New clsOptions 'Creates an empty options Object
        g_CurrConnSettings = New clsConnectionSettings 'Creates an empty connection settings object

        'Load the settings, If settings aren't found or the settings are bad, create a new connection
        If (Not GetSettings()) OrElse ((g_CurrConnSettings.ConnectionString = "") OrElse (Not TestDBConnection(g_CurrConnSettings))) Then
            Dim newDBConnection As New FrmDBConnection 'Used to establish a new DB Connection
            newDBConnection.ShowDialog()
            If newDBConnection.DialogResult = Windows.Forms.DialogResult.OK Then
                dtp_qryTimeBegin.MaxDate = Date.Today
                dtp_qryTimeEnd.MinDate = Date.Today
                dtp_qryTimeBegin.Text = CStr(Date.Today)
                dtp_qryTimeEnd.Text = CStr(Date.Today)
            Else
                'The connection dialog was canceled.  Close the program without loading the listboxes
                Me.Close()
                Exit Sub
            End If
            newDBConnection.Dispose()
        Else
            dtp_qryTimeBegin.MaxDate = Date.Today.AddMonths(1)
            dtp_qryTimeEnd.MaxDate = Date.Today.AddMonths(1)
            dtp_qryTimeBegin.Text = CStr(Date.Today)
            dtp_qryTimeEnd.Text = CStr(Date.Today)
        End If

        'force it to look in the correct location (NOTE: will not find the dll if started w/ shortcut or menu because working directory <> location of EXE)
        m_EXEDirectory = System.IO.Path.GetDirectoryName(Me.GetType.Assembly.Location)
        If (Not (System.IO.File.Exists(m_EXEDirectory & "\zedgraph.dll"))) Then
            ShowError("Error: A required DLL is missing = ZedGraph.dll" & vbCrLf & "Please make sure that it exists and is located in the Directory = " & vbCrLf & m_EXEDirectory & "\")
            Me.Close()
        End If
		mnuToolsIntCVUpdate.Visible = System.IO.File.Exists(m_EXEDirectory & "\ODM CVUpdate.dll")

		'initialize all of variables, etc for Query tab
		ResetQueryPage()
		lv_qryResults_AutoSizeColumns()
		m_qryTabLoaded = True

		'NOTE: no longer using this -> loading info straight from database = based on new ODM1.1 Schema
		'LoadQCLevelDefinitions()
	End Sub

    Private Sub frmODMTools_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Initializes query tab after form is drawn
        'the inputs/outputs are standard for form events

        'NOTE: First tab must be initialized here.  Loading will not call tabctlODMTools_SelectedIndexChanged.
        If Not (m_qryTabLoaded) Then
            ResetQueryPage()
            lv_qryResults_AutoSizeColumns()
            m_qryTabLoaded = True
        End If
    End Sub

    Private Sub tabctlODMTools_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabctlODMTools.SelectedIndexChanged
        'This loads/resets the tab when a new one is selected
        'the inputs/outputs are standard for form events
        Select Case tabctlODMTools.SelectedTab.Name
            Case "tabpgQuery"
                '1. see if any edits are uncommitted
                If m_EditHaveEditsUncommitted Then
                    If MsgBox("There are edits for the current Data Series that have not been committed, would you like them to be applied (saved) to the Database?" & vbCrLf & vbCrLf & "NOTE: IF you select NO then none of your changes will saved!!", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Apply Edits to Database
                        btnEditApplyChanges_Click(Me, New System.EventArgs)
                    Else
                        'set that no edit are uncommitted
						m_EditHaveEditsUncommitted = False
						m_EditHaveDeletedValIDs = False
						If Not (m_EditDeletedValIDs Is Nothing) Then
							m_EditDeletedValIDs.Clear()
                        End If
                        'm_EditHaveRemoveDFIDs = False
                        'If Not (m_EditRemoveDFIDs Is Nothing) Then
                        'm_EditRemoveDFIDs.Clear()
                        'End If
                        'reload current data series
                        'lvEditDataSeries_SelectedIndexChanged(Me, New System.EventArgs())
                        cboxEditVariable_SelectedIndexChanged(Me, New System.EventArgs())
                    End If
                End If

                If Not (m_qryTabLoaded) Then
                    ResetQueryPage()
                    lv_qryResults_AutoSizeColumns()
                    m_qryTabLoaded = True
                End If
            Case "tabpgVisualize"
                '1. see if any edits are uncommitted
                If m_EditHaveEditsUncommitted Then
                    If MsgBox("There are edits for the current Data Series that have not been committed, would you like them to be applied (saved) to the Database?" & vbCrLf & vbCrLf & "NOTE: IF you select NO then none of your changes will saved!!", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Apply Edits to Database
                        btnEditApplyChanges_Click(Me, New System.EventArgs)
                    Else
						'set that no edit are uncommitted
						m_EditHaveEditsUncommitted = False
						m_EditHaveDeletedValIDs = False
						If Not (m_EditDeletedValIDs Is Nothing) Then
							m_EditDeletedValIDs.Clear()
						End If						
                        'm_EditHaveRemoveDFIDs = False
                        'If Not (m_EditRemoveDFIDs Is Nothing) Then
                        'm_EditRemoveDFIDs.Clear()
                        'End If
                        'reload current data series						
                        'lvEditDataSeries_SelectedIndexChanged(Me, New System.EventArgs())
                        cboxEditVariable_SelectedIndexChanged(Me, New System.EventArgs())
                    End If
                End If
                If Not (m_VisualizeTabLoaded) Then
                    '1. initialize tab
                    InitializeVisualizeTab()
                    'InitializeAllVisualizePlots()

                    '2. set m_LoadingVisualizeTabe = True -> so certain events aren't run at this time
                    m_LoadingVisualizeTab = True

                    '3. Load Site Info from Series Catalog Table
                    If Not (LoadVisualizeSites()) Then
                        'NOTE: errors occurred while loading Sites, disable form
                        '4. clear out any other old data
                        cboxVisVariable.Items.Clear()
                        lvVisDataSeries.Items.Clear()
                        InitializeVisualizeDateInfo()

                        '5. disable Update Plot Button, plot selection controls
                        gboxVisDataSel.Enabled = False
                        gboxDateInfo.Enabled = False
                        btnPlot.Enabled = False

                        '6. set that the plots = current
                        SetVisPlotsCurrent(True)
                    Else
                        '4. select the first site -> NOTE: when a site is selected, the Variables will be populated
                        If cboxVisSite.Items.Count > 0 And cboxVisSite.SelectedIndex < 0 Then
                            cboxVisSite.SelectedIndex = m_InitialVisSiteSelIndex
                        End If

                        '5. enable Site Selection -> others are enabled already if needed
                        gboxVisDataSel.Enabled = True

                        '6. set that visualize tab is loaded
                        m_VisualizeTabLoaded = True
                    End If

                    '7. select default TS Plot type = Both
                    rbtnTSBoth.Checked = True

                    '8. make sure "Manually set Number of Bins" is unchecked,
                    'and make sure that "Adjust for Discrete Break Values" is checked
                    ckboxHistSetNumBins.Checked = False
                    rbtnHPDiscreteBreakVals.Checked = True

                    '9. select default BoxPlot Plot Type = Monthly
                    rbtnBPMonthly.Checked = True

                    '10. set that done loading visualize tab -> allow events to fire correctly
                    m_LoadingVisualizeTab = False

                    'get the plot options to update correctly
                    tabctlPlots_SelectedIndexChanged(sender, e)
                End If
            Case "tabpgEdit"
                If Not (m_EditTabLoaded) Then
                    If m_IsEditTabEnabled Then 'NOTE: Only load the tab if = Enabled
                        '1. initialize tab
                        InitializeEditTab() 'this initializes/clears/resets the plot and Data Table

                        '2. set m_LoadingEditTab = True -> so certain events aren't run at this time
                        m_LoadingEditTab = True

                        '3. Load Site Info from Series Catalog Table
                        If Not (LoadEditSites()) Then
                            'NOTE: errors occurred while loading Sites, disable form
                            '4. clear out any other old data
                            cboxEditVariable.Items.Clear()
                            lvEditDataSeries.Items.Clear()

                            '5. disable Apply, reset Buttons, Plot, Table, Filter functions
                            gboxEditDataSel.Enabled = False
                            gboxEditFilter.Enabled = False
                            SetEditTableBtnsEnabled(False)
                        Else
                            '4. select the first site -> NOTE: when a site is selected, the Variables will be populated
                            If cboxEditSite.Items.Count > 0 And cboxEditSite.SelectedIndex < 0 Then
                                cboxEditSite.SelectedIndex = m_InitialEditSiteSelIndex
                            End If

                            '5. enable Site Selection -> others are enabled already if needed
                            gboxEditDataSel.Enabled = True

                            '6. set that Edit tab is loaded
                            m_EditTabLoaded = True
                        End If

                        '7. make sure that default filter values are correctly set
                        rbtnEditDFValueThreshold_CheckedChanged(sender, e)
                        ckboxEditDFVTGreater_CheckedChanged(sender, e)
                        ckboxEditDFVTLess_CheckedChanged(sender, e)
                        rbtnEditDFVTChange_CheckedChanged(sender, e)
                        rbtnEditDFDate_CheckedChanged(sender, e)
                        rbtnEditDFDataGap_CheckedChanged(sender, e)

                        '8. set that done loading visualize tab -> allow events to fire correctly
                        m_LoadingEditTab = False
                    End If
                End If
        End Select
    End Sub

#Region " Form Close "

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        'Include any code required before the program can close
        'Cleans up,...

		'see if last tab open = edit, if so, then check for any unsaved edits
		If tabctlODMTools.SelectedTab.Name = "tabpgEdit" Then
			If m_EditHaveEditsUncommitted Then
				If MsgBox("There are edits for the current Data Series that have not been committed, would you like them to be applied (saved) to the Database?" & vbCrLf & vbCrLf & "NOTE: IF you select NO then none of your changes will saved!!", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
					'Apply Edits to Database
					btnEditApplyChanges_Click(Me, New System.EventArgs)
				Else
					'they don't want to apply changes, continue on

					'set that no edit are uncommitted, release resources
					m_EditHaveEditsUncommitted = False
					m_EditHaveDeletedValIDs = False
					If Not (m_EditDeletedValIDs Is Nothing) Then
						m_EditDeletedValIDs.Clear()
					End If
                    'm_EditHaveRemoveDFIDs = False
                    'If Not (m_EditRemoveDFIDs Is Nothing) Then
                    'm_EditRemoveDFIDs.Clear()
                    'End If
                End If
			End If
		End If

		'clean up Visualize Tab variables
		If Not (m_VisPlotData) Is Nothing Then
			m_VisPlotData.Dispose()
		End If

		'Clean up Edit Tab variables
		If Not (m_EditData) Is Nothing Then
			m_EditData.Dispose()
		End If

	End Sub

#End Region

#Region " Main Menu Items "
    'ODMTools >> MainMenu >> File
    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        'Closes the program
        'Input:     Standard form control Inputs
        'Output:    Closes the program.
        Close()
    End Sub

    'ODMTools >> MainMenu >> Tools
    Private Sub mnuToolsReloadQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsReloadQuery.Click
        'Reloads the Query Page Listboxes
        ResetQueryPage()
    End Sub

    Private Sub mnuToolsOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsOptions.Click
        'Opens an Options Dialog Box
        'Allows the user to set Data Export Options, Plot Export Options, and other Options
        'Input:     standard form input, plus user choicec.
        'Output:    Stores the current options settings
        Dim optionsDialog As New frmOptionsDialog 'Used to choose new Options (I.E. Export)
        OptionsDialog.ShowDialog()
    End Sub

    Private Sub mnuEditDBConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditDBConnect.Click
        'Opens a DB Connection Settings Dialog Window
        'If Settings are saved then it stores those changes in CurrConnSettings and reloads Data
        'Input:     standard form inputs
        'Output:    Opens DBCOnnection which edits the existing ConnectionSetings

        Dim dbConnection As New FrmDBConnection("Database Configuration", g_CurrConnSettings.DBName, g_CurrConnSettings.ServerAddress, g_CurrConnSettings.UserID, g_CurrConnSettings.Password, g_CurrConnSettings.Trusted) 'Used to change the existing DB Connection Settings
        DBConnection.ShowDialog()
        DBConnection.Dispose()
        ResetQueryPage()
        m_EditTabLoaded = False
        m_VisualizeTabLoaded = False

        tabctlODMTools_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    'ODMTools >> MainMenu >> Help
    Private Sub mnuitmHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuitmHelpAbout.Click
        'Opens the About Dialog
        Dim about As New frmAboutODMT 'The About Form
        about.ShowDialog()
    End Sub

    Private Sub mnuToolsDBUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsIntCVUpdate.Click
        Me.Cursor = Cursors.WaitCursor
        'Create a new CV Update Dialog Box
        Dim update As New ODM_CVUpdate.frmCVUpdate(g_CurrConnSettings.ServerAddress, g_CurrConnSettings.DBName, g_CurrConnSettings.Timeout, g_CurrConnSettings.Trusted, g_CurrConnSettings.UserID, g_CurrConnSettings.Password)
        If update.ShowDialog() = Windows.Forms.DialogResult.No Then
            ShowError("Error Updating")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuToolsQuickCVUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsQuickCVUpdate.Click
        Me.Cursor = Cursors.WaitCursor
        'Create a new Automatic CV Update Dialog Box.  Will Run w/o user intervention
        Dim update As New ODM_CVUpdate.frmQuickUpdate(g_CurrConnSettings.ServerAddress, g_CurrConnSettings.DBName, g_CurrConnSettings.Timeout, g_CurrConnSettings.Trusted, g_CurrConnSettings.UserID, g_CurrConnSettings.Password)
        update.Show()
        update.RunCVUpdate()
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#End Region

#Region " Query Tab: Setup "

	Private Sub LoadQCLevels()
		'This function Loads the Quality Control Levels from the database
		'Inputs:  None
		'Outputs: None
		Dim query As String
		Dim qcLevelDT As DataTable
		Dim i As Integer
		Dim qcLevel_Code As String
		Dim qcLevel_Def As String
		Try
			'1. clear out any old data
			lbx_qryQCLevel.Items.Clear()

			'2. Add the QC Levels 
			query = "SELECT DISTINCT " & db_fld_QCLQCLevel & ", " & db_fld_QCLCode & ", " & db_fld_QCLDefinition & " FROM " & db_tbl_QCLevels & " ORDER BY " & db_fld_QCLQCLevel
			qcLevelDT = OpenTable("qryQCLevels", query, g_CurrConnSettings)
			'validate data
			If Not (qcLevelDT Is Nothing) AndAlso qcLevelDT.Rows.Count > 0 Then
				'2. load variables into lbx_qryQCLevel
				For i = 0 To qcLevelDT.Rows.Count - 1
					If Not (qcLevelDT.Rows(i).Item(db_fld_QCLCode) Is DBNull.Value) Then
						qcLevel_Code = qcLevelDT.Rows(i).Item(db_fld_QCLCode)
					Else
						qcLevel_Code = " "
					End If
					If Not (qcLevelDT.Rows(i).Item(db_fld_QCLDefinition) Is DBNull.Value) Then
						qcLevel_Def = qcLevelDT.Rows(i).Item(db_fld_QCLDefinition)
					Else
						qcLevel_Def = " "
					End If
					lbx_qryQCLevel.Items.Add(qcLevel_Code & " - " & qcLevel_Def)
				Next i
			End If

			'3. Release resources
			If Not (qcLevelDT Is Nothing) Then
				qcLevelDT.Dispose()
				qcLevelDT = Nothing
			End If
		Catch ex As Exception
			ShowError("An Error occurred while loading the QC Levels." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

	Private Sub ResetQueryPage()
		'Resets the Query Page to it's default values.  Used when Data Source is changed
		'Outputs: Clears all data from Query Page
		Dim x As Integer 'counter
		Dim sFieldNames() As String = {db_fld_SCSiteCode, db_fld_SCSiteName}	'The field names used for lbx_qrySites
		Dim vFieldNames() As String = {db_fld_SCVarCode, db_fld_SCVarName}	'The field names used for lbx_qryVars
		Dim cv(,) As String	'Used to store the matrix of sitecodes/sitenames, and variablecodes/variableNames
		Dim otherCVs() As String 'Used to store all of the other listbox items

		Try
			'Load the list of sites
			cv = LoadDataList(db_tbl_SeriesCatalog, sFieldNames)
			lbx_qrySites.Items.Clear()
			For x = 0 To cv.GetUpperBound(1)
				lbx_qrySites.Items.Add(cv(0, x) & " - " & cv(1, x))
			Next

			'Load the list of Variables
			'otherCVs = LoadDataList(db_tbl_SeriesCatalog, db_fld_VarName)
			cv = LoadDataList(db_tbl_SeriesCatalog, vFieldNames)
			lbx_qryVars.Items.Clear()
			For x = 0 To cv.GetUpperBound(1)
				'lbx_qryVars.Items.Add(otherCVs(x))
				lbx_qryVars.Items.Add(cv(0, x) & " - " & cv(1, x))
			Next

			'Load the list of General Categories
			otherCVs = LoadDataList(db_tbl_SeriesCatalog, db_fld_SCGenCat)
			lbx_qryGenCat.Items.Clear()
			For x = 0 To otherCVs.Length - 1
				lbx_qryGenCat.Items.Add(otherCVs(x))
			Next

			'Load the list of Sample Mediums
			otherCVs = LoadDataList(db_tbl_SeriesCatalog, db_fld_SCSampleMed)
			lbx_qrySampleMed.Items.Clear()
			For x = 0 To otherCVs.Length - 1
				lbx_qrySampleMed.Items.Add(otherCVs(x))
			Next

			'Load the list of Value Types
			otherCVs = LoadDataList(db_tbl_SeriesCatalog, db_fld_SCValueType)
			lbx_qryValType.Items.Clear()
			For x = 0 To otherCVs.Length - 1
				lbx_qryValType.Items.Add(otherCVs(x))
			Next

			'Load the list of Data Types
			otherCVs = LoadDataList(db_tbl_SeriesCatalog, db_fld_SCDataType)
			lbx_qryDataType.Items.Clear()
			For x = 0 To otherCVs.Length - 1
				lbx_qryDataType.Items.Add(otherCVs(x))
			Next

			'Load the list of QC Levels
			LoadQCLevels()
			''NOTE: Per changes to ODM1.1 Schema, now loading info from database
			''lbx_qryQCLevel.Items.Clear()
			''For x = 0 To db_val_QCLDef_Level.GetLength(1) - 1
			''	lbx_qryQCLevel.Items.Add(db_val_QCLDef_Level(0, x) & " - " & db_val_QCLDef_Level(1, x))
			''Next

			'Reset Listviews
			lv_qryResults.Items.Clear()

			'Reset Checkboxes
			chb_qrySite.Checked = False
			chb_qryVar.Checked = False
			chb_qrySrc.Checked = False
			chb_qryGenCat.Checked = False
			chb_qrySampleMed.Checked = False
			chb_qryValType.Checked = False
			chb_qryDataType.Checked = False
			chb_qryQCLevel.Checked = False
			chb_qryMethod.Checked = False
			chb_qryNumObs.Checked = False
			chb_qryDate.Checked = False

		Catch ex As Exception
			ShowError("Error Loading Query Selection Values", ex)
		End Try
	End Sub

	Private Sub lv_qryResults_AutoSizeColumns(Optional ByVal includeData As Boolean = False)
		'Autosizes the Columns of lv_qryResults
		'Inputs: includeData -> Boolean True if resize should include data or only headers.
		'Outputs: Resizes the columns of lv_qryResults
		Dim x, y As Integer	'Counters
		Const HeaderResize As Integer = -2 'Constant for resizing listview columns by the header
		Const DataResize As Integer = -1 'Constant for resizing listview columns by the bigest text within the column

		For x = 0 To lv_qryResults.Columns.Count - 1
			lv_qryResults.Columns(x).Width = HeaderResize 'Resize the columns
		Next

		If includeData Then
			Dim columnWidth As Double 'Size of the header
			Dim dataWidth As Double	'Size of the data
			For y = 0 To lv_qryResults.Columns.Count - 1
				'Sets column width for each column
				columnWidth = GetStringLen(lv_qryResults.Columns(y).Text())
				For x = 0 To lv_qryResults.Items.Count - 1
					'Sets datawidth for each data within each column
					dataWidth = GetStringLen(lv_qryResults.Items(x).SubItems(y).Text())
					If dataWidth > columnWidth Then
						'Resize the columns based on the width of the text within the column
						lv_qryResults.Columns(y).Width = DataResize
					End If
				Next
			Next
		End If

	End Sub

#End Region

#Region " Query Tab: Context Menus "

	'ODMTools >> QueryTab >> QueryResults >> ContextMenu
	Private Sub cmnuQueryDataRightClick_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuQueryDataRightClick.Popup
        'Sets menu options for cmnuQDRC
        If lv_qryResults.SelectedItems.Count > 0 Then
            'If anything is selected and that item is checked, set the menu to "Remove", else set the menu to "Select"
            If lv_qryResults.SelectedItems(0).Checked Then
                mnuQDRCSelectSingle.Text = "Remove from Group Export"
            Else
                mnuQDRCSelectSingle.Text = "Select for Group Export"
            End If
            'If less than everything is checked, enable SelectAll
            mnuQDRCSelectAll.Enabled = (lv_qryResults.CheckedItems.Count < lv_qryResults.Items.Count)
            'If more than 0 are checked, enable SelectNone
            mnuQDRCSelectNone.Enabled = (lv_qryResults.CheckedItems.Count > 0)
        End If
	End Sub

	Private Sub mnuQDRCSelectSingle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQDRCSelectSingle.Click
        'Toggles the check of the currently selected object
		lv_qryResults.SelectedItems(0).Checked = Not lv_qryResults.SelectedItems(0).Checked
	End Sub

	Private Sub mnuQDRCSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQDRCSelectAll.Click
        'Sequentially Checks all items in the Query Results listview 
        'Outputs: Checks all items in lv_qryresults
        Dim i As Integer 'Counter
		For i = 0 To lv_qryResults.Items.Count - 1
			lv_qryResults.Items(i).Checked = True
		Next
	End Sub

	Private Sub mnuQDRCSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQDRCSelectNone.Click
        'Sequentially UNChecks all items in the Query Results listview
        'Outputs: Unchecks all items in lv_qryresults
        Dim i As Integer 'Counter
		For i = 0 To lv_qryResults.Items.Count - 1
			lv_qryResults.Items(i).Checked = False
		Next
	End Sub

#End Region

#Region " Query Tab: Enable/Disable Items "

#Region " Site "

    Private Sub chb_qrySite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qrySite.CheckedChanged
        'Enables/Disables related Site objects within grp_qrySites
        grp_qrySites.Enabled = chb_qrySite.Checked
        rdo_qrySiteList.Checked = chb_qrySite.Checked 'Sets the default option
        If chb_qrySite.Checked = False Then
            rdo_qrySiteName.Checked = False
            rdo_qrySiteCode.Checked = False
        End If
    End Sub

    Private Sub rdo_qrySiteList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qrySiteList.CheckedChanged
        'Enables/Disables Site List
        lbx_qrySites.Enabled = rdo_qrySiteList.Checked
        If Not rdo_qrySiteList.Checked Then
            lbx_qrySites.SelectedItem() = Nothing 'Clears the selection
        End If
    End Sub

    Private Sub rdo_qrySiteName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qrySiteName.CheckedChanged
        'Enables/Disables SiteName
        txt_qrySiteName.Enabled = rdo_qrySiteName.Checked
        grp_qrySiteSelect.Enabled = rdo_qrySiteName.Checked
        If Not rdo_qrySiteName.Checked Then
            txt_qrySiteName.Text = "" 'Clears the textbox
        End If
    End Sub

    Private Sub rdo_qrySiteCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qrySiteCode.CheckedChanged
        'Enables/Disables SiteCode
        txt_qrySiteCode.Enabled = rdo_qrySiteCode.Checked
        grp_qrySiteSelect.Enabled = rdo_qrySiteCode.Checked
        If Not rdo_qrySiteCode.Checked Then
            txt_qrySiteCode.Text = "" 'Clears the textbox
        End If
    End Sub

    Private Sub rdo_qrySiteAND_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qrySiteAND.CheckedChanged
        'sets Site Query Selection to AND
        If rdo_qrySiteAND.Checked Then m_qrySiteSelectionMethod = "AND"
    End Sub

    Private Sub rdo_qrySiteOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qrySiteOR.CheckedChanged
        'Sets Site Query Selection to OR
        If rdo_qrySiteOR.Checked Then m_qrySiteSelectionMethod = "OR"
    End Sub

#End Region

#Region " Variable "

    Private Sub chb_qryVar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qryVar.CheckedChanged
        'Enables/Disables related Variable objects within grp_qryVars
        grp_qryVars.Enabled = chb_qryVar.Checked
        rdo_qryVarList.Checked = chb_qryVar.Checked
        If chb_qryVar.Checked = False Then
            rdo_qryVarName.Checked = False
            rdo_qryVarCode.Checked = False
        End If
    End Sub

    Private Sub rdo_qryVarList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qryVarList.CheckedChanged
        'Enables/Disables the VariableList
        lbx_qryVars.Enabled = rdo_qryVarList.Checked
        If Not rdo_qryVarList.Checked Then
            lbx_qryVars.SelectedItem() = Nothing 'Clears the selection
        End If

    End Sub

    Private Sub rdo_qryVarName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qryVarName.CheckedChanged
        'Enables/Disables VariableName
        txt_qryVarName.Enabled = rdo_qryVarName.Checked
        grp_qryVarSelect.Enabled = rdo_qryVarName.Checked
        If Not rdo_qryVarName.Checked Then
            txt_qryVarName.Text = "" 'Clears the textbox
        End If

    End Sub

    Private Sub rdo_qryVarCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qryVarCode.CheckedChanged
        'Enables/Disables VariableCode
        txt_qryVarCode.Enabled = rdo_qryVarCode.Checked
        grp_qryVarSelect.Enabled = rdo_qryVarCode.Checked
        If Not rdo_qryVarCode.Checked Then
            txt_qryVarCode.Text = "" 'Clears the textbox
        End If

    End Sub

    Private Sub rdo_qryVarAND_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qryVarAND.CheckedChanged
        'set Variable Query selection to AND
        If rdo_qryVarAND.Checked Then m_qryVariableSelectionMethod = "AND"
    End Sub

    Private Sub rdo_qryVarOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qryVarOR.CheckedChanged
        'sets Variable Query selection to OR
        If rdo_qryVarOR.Checked Then m_qryVariableSelectionMethod = "OR"
    End Sub

#End Region

#Region " Other "
    'Enables/Disables related Other objects within grp_qryOther

    Private Sub chb_qryGenCat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qryGenCat.CheckedChanged
        'Enables/Disables General Category
        lbx_qryGenCat.Enabled = chb_qryGenCat.Checked
        If Not chb_qryGenCat.Checked Then
            lbx_qryGenCat.SelectedItem() = Nothing  'Clears the selection
        End If
    End Sub

    Private Sub chb_qrySampleMed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qrySampleMed.CheckedChanged
        'Enables/Disables Sample Medium
        lbx_qrySampleMed.Enabled = chb_qrySampleMed.Checked
        If Not chb_qrySampleMed.Checked Then
            lbx_qrySampleMed.SelectedItem() = Nothing 'Clears the selection
        End If
    End Sub

    Private Sub chb_qryValType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qryValType.CheckedChanged
        'Enables/Disables Value Type
        lbx_qryValType.Enabled = chb_qryValType.Checked
        If Not chb_qryValType.Checked Then
            lbx_qryValType.SelectedItem() = Nothing 'Clears the selection
        End If
    End Sub

    Private Sub chb_qryDataType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qryDataType.CheckedChanged
        'Enables/Disables Data Type
        lbx_qryDataType.Enabled = chb_qryDataType.Checked
        If Not chb_qryDataType.Checked Then
            lbx_qryDataType.SelectedItem() = Nothing 'Clears the selection
        End If
    End Sub

#Region " Source "

    Private Sub chb_qrySrc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qrySrc.CheckedChanged
        'Enables/Disables grp_qrySrcs (Source)
        grp_qrySources.Enabled = chb_qrySrc.Checked
        rdo_qrySrcOrg.Checked = chb_qrySrc.Checked  'Sets the default option
        If chb_qrySrc.Checked = False Then
            rdo_qrySrcOrg.Checked = False
            rdo_qrySrcDesc.Checked = False
        End If
    End Sub

    Private Sub rdo_qrySrcOrg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qrySrcOrg.CheckedChanged
        'Enables/Disables Source Organization
        txt_qrySrcOrg.Enabled = rdo_qrySrcOrg.Checked
        If Not rdo_qrySrcOrg.Checked Then
            txt_qrySrcOrg.Text = "" 'Clears the textbox
        End If
    End Sub

    Private Sub rdo_qrySrcDesc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qrySrcDesc.CheckedChanged
        'Enables/Disables Source Description
        txt_qrySrcDesc.Enabled = rdo_qrySrcDesc.Checked
        If Not rdo_qrySrcDesc.Checked Then
            txt_qrySrcDesc.Text = ""    'Clears the textbox
        End If
    End Sub

    Private Sub rdo_qrySrcAND_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qrySrcAND.CheckedChanged
        'sets the Source query selection to AND
        If rdo_qrySrcAND.Checked Then m_qrySourceSelectionMethod = "AND"
    End Sub

    Private Sub rdo_qrySrcOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qrySrcOR.CheckedChanged
        'sets the Source query selection to OR
        If rdo_qrySrcOR.Checked Then m_qrySourceSelectionMethod = "OR"
    End Sub

#End Region

    Private Sub chb_qryQCLevel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qryQCLevel.CheckedChanged
        'Enables/Disables QC Level
        lbx_qryQCLevel.Enabled = chb_qryQCLevel.Checked
        If Not chb_qryQCLevel.Checked Then
            lbx_qryQCLevel.SelectedItem = Nothing
        End If
    End Sub

    Private Sub chb_qryMethod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qryMethod.CheckedChanged
        'Enables/Disables Method
        txt_qryMethod.Enabled = chb_qryMethod.Checked
        If Not chb_qryMethod.Checked Then
            txt_qryMethod.Text = ""
        End If
    End Sub

#Region " Number of Observations "

    Private Sub chb_qryNumObs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qryNumObs.CheckedChanged
        'Enables/Disables Number of Observations
        grp_qryNumObs.Enabled = chb_qryNumObs.Checked
        rdo_qryNumObsG.Checked = True

        If Not chb_qryNumObs.Checked Then
            num_qryObs.Value = 1        'Sets a default value
            num_qryObs.Text = "1"   'Shows the default value
            rdo_qryNumObsG.Checked = False
            rdo_qryNumObsL.Checked = False
        End If
        AnyValid()
    End Sub

    Private Sub rdo_qryNumObsG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qryNumObsG.CheckedChanged
        'sets the Number of Observations query selection to Greater Than
        If rdo_qryNumObsG.Checked Then m_qryNumObsMethod = " > "
    End Sub

    Private Sub rdo_qryNumObsL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_qryNumObsL.CheckedChanged
        'sets the Number of Observations query selection to Less Than or Equal
        If rdo_qryNumObsL.Checked Then m_qryNumObsMethod = " <= "
    End Sub

#End Region

    Private Sub chb_qryDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_qryDate.CheckedChanged
        'Enables/Disables Date
        dtp_qryTimeBegin.Enabled = chb_qryDate.Checked
        dtp_qryTimeEnd.Enabled = chb_qryDate.Checked
        If Not (chb_qryDate.Checked) Then
            dtp_qryTimeEnd.Value = Date.Today
            dtp_qryTimeBegin.Value = Date.Today
        End If
        AnyValid()
    End Sub

#End Region

#End Region

#Region " Query Tab: Results Items "

    Private Sub lv_qryResults_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lv_qryResults.ItemCheck
        'Enables the export buttons if any items are checked
        'Input:     e.index -> the index of the most recently checked item
        'Output:    Enables/Disables btnExport
        'Note:  Checked Value Does Not Change Until After ItemCheck call
        Dim checkedItems As Integer 'The number of items checked in lv_qryResults
        If lv_qryResults.Items(e.Index).Checked = False Then
            checkedItems = lv_qryResults.CheckedItems.Count + 1
        Else
            checkedItems = lv_qryResults.CheckedItems.Count - 1
        End If

        If checkedItems < 1 Then
            btn_qryDataExport.Enabled = False
            btn_qryMetaExport.Enabled = False
        Else
            btn_qryDataExport.Enabled = True
            btn_qryMetaExport.Enabled = True
        End If
    End Sub

    Private Sub lv_qryResults_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv_qryResults.SelectedIndexChanged
        'Enables the QDRC context menu when an item is selected in lv_qryResults 
        If lv_qryResults.SelectedItems.Count > 0 Then
            lv_qryResults.ContextMenu = cmnuQueryDataRightClick
        Else
            lv_qryResults.ContextMenu = Nothing
        End If
    End Sub

#End Region

#Region " Query Tab: Input Validation "

    Private Sub AnyValid()
        'Checks if any are valid 
        'Output: If any are valid then enable the query button
        btn_qryExecute.Enabled = ((lbx_qrySites.SelectedItems.Count > 0) OrElse _
        (lbx_qryVars.SelectedItems.Count > 0) OrElse _
        (lbx_qryGenCat.SelectedItems.Count > 0) OrElse _
        (lbx_qrySampleMed.SelectedItems.Count > 0) OrElse _
        (lbx_qryValType.SelectedItems.Count > 0) OrElse _
        (lbx_qryDataType.SelectedItems.Count > 0) OrElse _
        (lbx_qryQCLevel.SelectedItems.Count > 0) OrElse _
        (txt_qrySiteName.Text.Length > 0) OrElse _
        (txt_qrySiteCode.Text.Length > 0) OrElse _
        (txt_qryVarName.Text.Length > 0) OrElse _
        (txt_qryVarCode.Text.Length > 0) OrElse _
        (txt_qrySrcOrg.Text.Length > 0) OrElse _
        (txt_qrySrcDesc.Text.Length > 0) OrElse _
        (txt_qryMethod.Text.Length > 0) OrElse _
        (chb_qryNumObs.Checked) OrElse _
        (dtp_qryTimeBegin.Enabled AndAlso dtp_qryTimeEnd.Enabled AndAlso dtp_qryTimeEnd.Value >= dtp_qryTimeBegin.Value))
    End Sub

	'Uses Regex and RegularExpressionPatern Constants to validate the data.
	Private Sub lbx_qrySites_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbx_qrySites.SelectedIndexChanged
		'Sites changes, validate
		AnyValid()
	End Sub

	Private Sub lbx_qryVars_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbx_qryVars.SelectedIndexChanged
		'Variables changed, validate
		AnyValid()
	End Sub

	Private Sub lbx_qryGenCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbx_qryGenCat.SelectedIndexChanged
		'General Category changed, validate
		AnyValid()
	End Sub

	Private Sub lbx_qrySampleMed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbx_qrySampleMed.SelectedIndexChanged
		'Sample Medium changed, validate
		AnyValid()
	End Sub

	Private Sub lbx_qryValType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbx_qryValType.SelectedIndexChanged
		'Value Type changed, validate
		AnyValid()
	End Sub

	Private Sub lbx_qryDataType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbx_qryDataType.SelectedIndexChanged
		'Data Type changed, validate
		AnyValid()
	End Sub

	Private Sub lbx_qryQCLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbx_qryQCLevel.SelectedIndexChanged
		'QC Level changed, validate
		AnyValid()
	End Sub

	Private Sub num_qryObsMin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num_qryObs.ValueChanged
		'min #Obs changes, validate
		AnyValid()
	End Sub

	Private Sub num_qryObsMax_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		'max #Obs changes, validate
		AnyValid()
	End Sub

	Private Sub dtp_qryTimeBegin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_qryTimeBegin.ValueChanged
		'Begin Time changed, validate
		AnyValid()
		If dtp_qryTimeBegin.Value > dtp_qryTimeEnd.Value Then
			'showerror("The Beginning Date must be after the Ending Date")
		End If
	End Sub

	Private Sub dtp_qryTimeEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_qryTimeEnd.ValueChanged
		'end time changed, validate
		AnyValid()
		If dtp_qryTimeBegin.Value > dtp_qryTimeEnd.Value Then
			'showerror("The Ending Date must be after the Beginning Date")
		End If
	End Sub

	Private Sub txt_qryMethod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qryMethod.TextChanged
		'Method Changed, validate
		If Not ValidQueryText(txt_qryMethod.Text) Then
			Dim writePos As Integer	'Holds the current position of the cursor
			writePos = txt_qryMethod.SelectionStart	'Track the current cursor position
			'Remove any invalid characters
			txt_qryMethod.Text = System.Text.RegularExpressions.Regex.Replace(txt_qryMethod.Text, g_RegularExpressionPatern, "")
			txt_qryMethod.Select(writePos - 1, 0)	'Return the cursor to it's original position
		End If
		AnyValid()
	End Sub

	Private Sub txt_qrySrcOrg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qrySrcOrg.TextChanged
		'Source Organization changes, validate
		If Not ValidQueryText(txt_qrySrcOrg.Text) Then
			Dim writePos As Integer	'Hold the current position of the cursor
			writePos = txt_qrySrcOrg.SelectionStart	'Track the current cursor position
			'Remove any invalid characters
			txt_qrySrcOrg.Text = System.Text.RegularExpressions.Regex.Replace(txt_qrySrcOrg.Text, g_RegularExpressionPatern, "")
			txt_qrySrcOrg.Select(writePos - 1, 0)	'Return the cursor to it's original position
		End If
		AnyValid()
	End Sub

	Private Sub txt_qrySrcDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qrySrcDesc.TextChanged
		'Source Description changed, validate
		If Not ValidQueryText(txt_qrySrcOrg.Text) Then
			Dim writePos As Integer	'Hold the current position of the cursor
			writePos = txt_qrySrcDesc.SelectionStart	'Track the current cursor position
			'Remove any invalid characters
			txt_qrySrcDesc.Text = System.Text.RegularExpressions.Regex.Replace(txt_qrySrcDesc.Text, g_RegularExpressionPatern, "")
			txt_qrySrcDesc.Select(writePos - 1, 0)	'Return the cursor to it's original position
		End If
		AnyValid()
	End Sub

	Private Sub txt_qrySiteName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qrySiteName.TextChanged
		'Site Name Changed, validate
		If Not ValidQueryText(txt_qrySiteName.Text) Then
			Dim writePos As Integer	'Hold the current position of the cursor
			writePos = txt_qrySiteName.SelectionStart 'Track the current cursor position
			'Remove any invalid characters
			txt_qrySiteName.Text = System.Text.RegularExpressions.Regex.Replace(txt_qrySiteName.Text, g_RegularExpressionPatern, "")
			txt_qrySiteName.Select(writePos - 1, 0)	'Return the cursor to it's original position
		End If
		AnyValid()
	End Sub

	Private Sub txt_qryVarName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qryVarName.TextChanged
		'variable name changes, validate
		If Not ValidQueryText(txt_qryVarName.Text) Then
			Dim writePos As Integer	'Hold the current position of the cursor
			writePos = txt_qryVarName.SelectionStart 'Track the current cursor position
			'Remove any invalid characters
			txt_qryVarName.Text = System.Text.RegularExpressions.Regex.Replace(txt_qryVarName.Text, g_RegularExpressionPatern, "")
			txt_qryVarName.Select(writePos - 1, 0) 'Return the cursor to it's original position
		End If
		AnyValid()
	End Sub

	Private Sub txt_qrySiteCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qrySiteCode.TextChanged
		'site code changed, validate
		If Not ValidQueryText(txt_qrySiteCode.Text) Then
			Dim writePos As Integer	'Hold the current position of the cursor
			writePos = txt_qrySiteCode.SelectionStart 'Track the current cursor position
			'Remove any invalid characters
			txt_qrySiteCode.Text = System.Text.RegularExpressions.Regex.Replace(txt_qrySiteCode.Text, g_RegularExpressionPatern, "")
			txt_qrySiteCode.Select(writePos - 1, 0)	'Return the cursor to it's original position
		End If
		AnyValid()
	End Sub

	Private Sub txt_qryVarCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qryVarCode.TextChanged
		'variable code changed, validate
		If Not ValidQueryText(txt_qryVarCode.Text) Then
			Dim writePos As Integer	'Hold the current position of the cursor
			writePos = txt_qryVarCode.SelectionStart 'Track the current cursor position
			'Remove any invalid characters
			txt_qryVarCode.Text = System.Text.RegularExpressions.Regex.Replace(txt_qryVarCode.Text, g_RegularExpressionPatern, "")
			txt_qryVarCode.Select(writePos - 1, 0) 'Return the cursor to it's original position
		End If
		AnyValid()
	End Sub

	Private Sub dtp_qryDateBegin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		'Makes sure the beginning date is before the ending date, validate
		dtp_qryTimeEnd.MinDate = dtp_qryTimeBegin.Value
		If dtp_qryTimeBegin.Value > dtp_qryTimeEnd.Value Then
			dtp_qryTimeBegin.Value = dtp_qryTimeEnd.Value
		End If
		AnyValid()
	End Sub

	Private Sub dtp_qryDateEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		'Makes sure the beginning date is after the ending date, validate
		dtp_qryTimeBegin.MaxDate = dtp_qryTimeEnd.Value
		If dtp_qryTimeBegin.Value > dtp_qryTimeEnd.Value Then
			dtp_qryTimeEnd.Value = dtp_qryTimeBegin.Value
		End If
		AnyValid()
	End Sub

#End Region

#Region " Query Tab: Database Query Functions "

	Private Sub cmdExecuteQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_qryExecute.Click
		'Executes the query, calling createcustomquery() and opentable() when clicked
		'this function validates selected data, Creates a set of stations the match the criteria set from the selected database
		'Input:     the inputs are standard for form events
		'Output:    Displays the results of the query to a listview control

		Dim sql As String 'the SQL Query to pull the station names from the database
        Dim queryTable As DataTable 'the datatable of final stations
		Dim i As Integer 'counter

		'If a radio button is checked and the inputed text is invalid, display a message and exit the sub.
		If dtp_qryTimeBegin.Value > dtp_qryTimeEnd.Value Then
			ShowError("Please Enter A Valid Date Range")
			Exit Sub
		End If

		If rdo_qrySiteName.Checked And (Not ValidQueryText(txt_qrySiteName.Text)) Then
			ShowError("Please Enter A Valid Site Name")
			Exit Sub
		End If
		If rdo_qrySiteCode.Checked And (Not ValidQueryText(txt_qrySiteCode.Text)) Then
			ShowError("Please Enter A Valid Site Code")
			Exit Sub
		End If
		If rdo_qryVarName.Checked And (Not ValidQueryText(txt_qryVarName.Text)) Then
			ShowError("Please Enter A Valid Variable Name")
			Exit Sub
		End If
		If rdo_qryVarCode.Checked And (Not ValidQueryText(txt_qryVarCode.Text)) Then
			ShowError("Please Enter A Valid Variable Code")
			Exit Sub
		End If

		'change the cursor to the wait cursor
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

		Try
			'1. clear out old data
			lv_qryResults.Items.Clear()

			'2. create the query -> based on selected criteria
			sql = CreateCustomQuery()

			If sql = "" Then
				Exit Try
			End If
			QueryTable = OpenTable("customQuery", sql, g_CurrConnSettings)
			'make sure data was retreived from the database
			If QueryTable Is Nothing Or QueryTable.Rows.Count = 0 Then
				lv_qryResults.Enabled = False

				Exit Try
			Else
				lv_qryResults.Enabled = True
			End If

			'3. show results in the lvResults
			Dim lvItem As Windows.Forms.ListViewItem 'used to add stations/station info to lvResults
			Dim numResults As Integer = 0 'tracks the number of valid Stations added to lvResults
			Dim qclevel_Code As String 'holds the Quality Control Level code value to be displayed
			Dim qclevel_Def As String 'holds the QC Level Definition to be displayed
			'if checking for #Data Points, set the numObs
			'loop through the returned stations/data
			ReDim m_qrySeriesID(QueryTable.Rows.Count - 1)
			For i = 0 To QueryTable.Rows.Count - 1
				'add the valid series to lv_qryResults
				m_qrySeriesID(i) = Val(QueryTable.Rows(i).Item(db_fld_SCSeriesID))	'Series ID
				lvItem = lv_qryResults.Items.Add(QueryTable.Rows(i).Item(db_fld_SCSiteCode) & " - " & QueryTable.Rows(i).Item(db_fld_SCSiteName)) 'Site Code - Site Name
				lvItem.SubItems.Add(queryTable.Rows(i).Item(db_fld_SCVarCode) & " - " & queryTable.Rows(i).Item(db_fld_SCVarName)) 'Variable Code - Variable Name
				lvItem.SubItems.Add(queryTable.Rows(i).Item(db_fld_SCSpeciation)) 'Speciation
				lvItem.SubItems.Add(QueryTable.Rows(i).Item(db_fld_SCVarUnitsName))	'Variable Units Name
				lvItem.SubItems.Add(QueryTable.Rows(i).Item(db_fld_SCGenCat)) 'General Category
				lvItem.SubItems.Add(QueryTable.Rows(i).Item(db_fld_SCValueType)) 'Value Type
				lvItem.SubItems.Add(QueryTable.Rows(i).Item(db_fld_SCSampleMed)) 'Sample Medium
				lvItem.SubItems.Add(queryTable.Rows(i).Item(db_fld_SCDataType))	'Data Type
				qclevel_Code = queryTable.Rows(i).Item(db_fld_SCQCLCode) 'QCLevel Code
				qclevel_Def = GetQCLevelDefinitionFromDB(queryTable.Rows(i).Item(db_fld_SCQCLevel))	'QCLevel Defition
				lvItem.SubItems.Add(qclevel_Code & " - " & qclevel_Def)	'QCLevel = Code - Definition
				lvItem.SubItems.Add(QueryTable.Rows(i).Item(db_fld_SCMethodDesc)) 'Method Description
				lvItem.SubItems.Add(QueryTable.Rows(i).Item(db_fld_SCValueCount)) 'Value Count
				lvItem.SubItems.Add(CDate(QueryTable.Rows(i).Item(db_fld_SCBeginDT)).ToString & " - " & CDate(QueryTable.Rows(i).Item(db_fld_SCEndDT)).ToString)	   'Begin Date Time - End Date Time
				lvItem.SubItems.Add(QueryTable.Rows(i).Item(db_fld_SCOrganization))	'Organization
				lvItem.SubItems.Add(queryTable.Rows(i).Item(db_fld_SCSourceDesc)) 'Source Description
				lvItem.SubItems.Add(queryTable.Rows(i).Item(db_fld_SCCitation))	'Citation
				lvItem.SubItems.Add(QueryTable.Rows(i).Item(db_fld_SCTimeSupport)) 'Time support
				lvItem.SubItems.Add(QueryTable.Rows(i).Item(db_fld_SCTimeUnitsName)) 'time support units

				numResults += 1
			Next


			'5. release resources
			QueryTable.Dispose()
			QueryTable = Nothing
			lvItem = Nothing

			'6. if there are any results, enable the listview and store the query parameters
			If numResults = 0 Then
				lv_qryResults.Enabled = False
			Else
				lv_qryResults.Enabled = True
				lv_qryResults_AutoSizeColumns(True)
				If rdo_qrySiteName.Checked Then
					txt_qrySiteName.AutoCompleteCustomSource.Add(txt_qrySiteName.Text)
				End If
				If rdo_qrySiteCode.Checked Then
					txt_qrySiteCode.AutoCompleteCustomSource.Add(txt_qrySiteCode.Text)
				End If
				If rdo_qryVarName.Checked Then
					txt_qryVarName.AutoCompleteCustomSource.Add(txt_qryVarName.Text)
				End If
				If rdo_qryVarCode.Checked Then
					txt_qryVarCode.AutoCompleteCustomSource.Add(txt_qryVarCode.Text)
				End If
				If rdo_qrySrcOrg.Checked Then
					txt_qrySrcOrg.AutoCompleteCustomSource.Add(txt_qrySrcOrg.Text)
				End If
				If rdo_qrySrcDesc.Checked Then
					txt_qrySrcDesc.AutoCompleteCustomSource.Add(txt_qrySrcDesc.Text)
				End If
				If chb_qryMethod.Checked Then
					txt_qryMethod.AutoCompleteCustomSource.Add(txt_qryMethod.Text)
				End If
			End If

		Catch ex As Exception
            ShowError("An Error occurred while running the Query." & "Message = " & ex.Message, ex)
		End Try
		'change the cursor back to the default
		Me.Cursor = System.Windows.Forms.Cursors.Default
	End Sub

	Private Function CreateCustomQuery() As String
		'Creates the SQL Query to retreived stations from the selected database based on selected criteria in the Database Query Tab
		'Inputs:  None
		'Outputs: String -> the created SQL Query
		Dim sql As String 'the SQL query to create
		Dim i As Integer 'counter
        Dim firstCommand As Boolean = True 'Is this the first command to be written?
		Try
			'set basic query -> get SiteCode, SiteName, VariableCode, VariableName, BeginDateTime, EndDateTime, GeneralCategory, ValueCount, SampleMedium, ValueType
			sql = "SELECT * FROM " _
			  & db_tbl_SeriesCatalog & " WHERE "

			'see what check boxes are checked -> creates the WHERE Clause

			'Search for Similar Site Codes
			If rdo_qrySiteCode.Checked Then
				If Not FirstCommand Then
					sql = sql & " AND "
				Else
					FirstCommand = False
				End If

				Dim compareVal As String 'the site code comparison value to qualify the station name by
				compareVal = FixSQL(txt_qrySiteCode.Text)
				If compareVal = "" Then
					ShowError("No Site Code Entered." & vbCrLf & "Please enter a Site Code to query by.")
					Return ""
				Else
					If System.Text.RegularExpressions.Regex.Matches(compareVal, "; ").Count() > 0 Then
                        Dim splitEntries As Array 'Holds the separate query entries
						splitEntries = SplitMultipleEntries(compareVal)
						For i = 0 To splitEntries.Length - 1
							If i = splitEntries.Length - 1 Then
								sql = sql & db_fld_SCSiteCode & " LIKE '%" & splitEntries(i) & "%') "
							ElseIf i = 0 Then
								sql = sql & "(" & db_fld_SCSiteCode & " LIKE '%" & splitEntries(i) & "%' " & m_qrySiteSelectionMethod & " "
							Else
								sql = sql & db_fld_SCSiteCode & " LIKE '%" & splitEntries(i) & "%' " & m_qrySiteSelectionMethod & " "
							End If
						Next
					Else
						sql = sql & "(" & db_fld_SCSiteCode & " LIKE '%" & compareVal & "%') "
					End If
				End If
			End If
			'Search for Similar Site Names
			If rdo_qrySiteName.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim compareVal As String 'the site name comparison value to qualify the station name by
				compareVal = FixSQL(txt_qrySiteName.Text)
				If compareVal = "" Then
					ShowError("No Site Name Entered." & vbCrLf & "Please enter a Site Name to query by.")
					Return ""
				Else
					If System.Text.RegularExpressions.Regex.Matches(compareVal, "; ").Count() > 0 Then
                        Dim splitEntries As Array 'Holds the separate query entries
						splitEntries = SplitMultipleEntries(compareVal)
						For i = 0 To splitEntries.Length - 1
							If i = splitEntries.Length - 1 Then
								sql = sql & db_fld_SCSiteName & " LIKE '%" & splitEntries(i) & "%') "
							ElseIf i = 0 Then
								sql = sql & "(" & db_fld_SCSiteName & " LIKE '%" & splitEntries(i) & "%' " & m_qrySiteSelectionMethod & " "
							Else
								sql = sql & db_fld_SCSiteName & " LIKE '%" & splitEntries(i) & "%' " & m_qrySiteSelectionMethod & " "
							End If
						Next
					Else
						sql = sql & "(" & db_fld_SCSiteName & " LIKE '%" & compareVal & "%') "
					End If
				End If
			End If
			'Search for Similar Var Codes
			If rdo_qryVarCode.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim compareVal As String 'the variable code comparison value to qualify the station name by
				compareVal = FixSQL(txt_qryVarCode.Text)
				If compareVal = "" Then
					ShowError("No Variable Code Entered." & vbCrLf & "Please enter a Variable Code to query by.")
					Return ""
				Else
					If System.Text.RegularExpressions.Regex.Matches(compareVal, "; ").Count() > 0 Then
                        Dim splitEntries As Array 'Holds the separate query entries
						splitEntries = SplitMultipleEntries(compareVal)
						For i = 0 To splitEntries.Length - 1
							If i = splitEntries.Length - 1 Then
								sql = sql & db_fld_SCVarCode & " LIKE '%" & splitEntries(i) & "%') "
							ElseIf i = 0 Then
								sql = sql & "(" & db_fld_SCVarCode & " LIKE '%" & splitEntries(i) & "%' " & m_qryVariableSelectionMethod & " "
							Else
								sql = sql & db_fld_SCVarCode & " LIKE '%" & splitEntries(i) & "%' " & m_qryVariableSelectionMethod & " "
							End If
						Next
					Else
						sql = sql & "(" & db_fld_SCVarCode & " LIKE '%" & compareVal & "%') "
					End If
				End If
			End If
			'Search for Similar Var Names
			If rdo_qryVarName.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim compareVal As String 'the variable name comparison value to qualify the station name by
				compareVal = FixSQL(txt_qryVarName.Text)
				If compareVal = "" Then
					ShowError("No Variable Name Entered." & vbCrLf & "Please enter a Variable Name to query by.")
					Return ""
				Else
					compareVal = Replace(compareVal, "'", "''")
					If System.Text.RegularExpressions.Regex.Matches(compareVal, "; ").Count() > 0 Then
                        Dim splitEntries As Array 'Holds the separate query entries
						splitEntries = SplitMultipleEntries(compareVal)
						For i = 0 To splitEntries.Length - 1
							If i = splitEntries.Length - 1 Then
								sql = sql & db_fld_SCVarName & " LIKE '%" & splitEntries(i) & "%') "
							ElseIf i = 0 Then
								sql = sql & "(" & db_fld_SCVarName & " LIKE '%" & splitEntries(i) & "%' " & m_qryVariableSelectionMethod & " "
							Else
								sql = sql & db_fld_SCVarName & " LIKE '%" & splitEntries(i) & "%' " & m_qryVariableSelectionMethod & " "
							End If
						Next
					Else
						sql = sql & "(" & db_fld_SCVarName & " LIKE '%" & compareVal & "%') "
					End If
				End If
			End If
			'Search for Similar Methods
			If chb_qryMethod.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim compareVal As String 'the Method comparison value to qualify the station name by
				compareVal = FixSQL(txt_qryMethod.Text)
				If compareVal = "" Then
					ShowError("No Method Entered." & vbCrLf & "Please enter a Method to query by.")
					Return ""
				Else
					compareVal = Replace(compareVal, "'", "''")
					If System.Text.RegularExpressions.Regex.Matches(compareVal, "; ").Count() > 0 Then
                        Dim splitEntries As Array 'Holds the separate query entries
						splitEntries = SplitMultipleEntries(compareVal)
						For i = 0 To splitEntries.Length - 1
							If i = splitEntries.Length - 1 Then
								sql = sql & db_fld_SCMethodDesc & " LIKE '%" & splitEntries(i) & "%') "
							ElseIf i = 0 Then
								sql = sql & "(" & db_fld_SCMethodDesc & " LIKE '%" & splitEntries(i) & "%' " & m_qryOtherSelectionMethod & " "
							Else
								sql = sql & db_fld_SCMethodDesc & " LIKE '%" & splitEntries(i) & "%' " & m_qryOtherSelectionMethod & " "
							End If
						Next
					Else
						sql = sql & "(" & db_fld_SCMethodDesc & " LIKE '%" & compareVal & "%') "
					End If
				End If
			End If
			'Search for Similar Organizations
			If rdo_qrySrcOrg.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim compareVal As String 'the variable name comparison value to qualify the station name by
				compareVal = FixSQL(txt_qrySrcOrg.Text)
				If compareVal = "" Then
					ShowError("No Organization Entered." & vbCrLf & "Please enter a Organization to query by.")
					Return ""
				Else
					compareVal = Replace(compareVal, "'", "''")
					If System.Text.RegularExpressions.Regex.Matches(compareVal, "; ").Count() > 0 Then
                        Dim splitEntries As Array 'Holds the separate query entries
						splitEntries = SplitMultipleEntries(compareVal)
						For i = 0 To splitEntries.Length - 1
							If i = splitEntries.Length - 1 Then
								sql = sql & db_fld_SCOrganization & " LIKE '%" & splitEntries(i) & "%') "
							ElseIf i = 0 Then
								sql = sql & "(" & db_fld_SCOrganization & " LIKE '%" & splitEntries(i) & "%' " & m_qrySourceSelectionMethod & " "
							Else
								sql = sql & db_fld_SCOrganization & " LIKE '%" & splitEntries(i) & "%' " & m_qrySourceSelectionMethod & " "
							End If
						Next
					Else
						sql = sql & "(" & db_fld_SCOrganization & " LIKE '%" & compareVal & "%') "
					End If
				End If
			End If
			'Search for Similar Source Description
			If rdo_qrySrcDesc.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim compareVal As String 'the variable name comparison value to qualify the station name by
				compareVal = FixSQL(txt_qrySrcDesc.Text)
				If compareVal = "" Then
					ShowError("No Source Entered." & vbCrLf & "Please enter a Source to query by.")
					Return ""
				Else
					compareVal = Replace(compareVal, "'", "''")
					If System.Text.RegularExpressions.Regex.Matches(compareVal, "; ").Count() > 0 Then
                        Dim splitEntries As Array 'Holds the separate query entries
						splitEntries = SplitMultipleEntries(compareVal)
						For i = 0 To splitEntries.Length - 1
							If i = splitEntries.Length - 1 Then
								sql = sql & db_fld_SCSourceDesc & " LIKE '%" & splitEntries(i) & "%') "
							ElseIf i = 0 Then
								sql = sql & "(" & db_fld_SCSourceDesc & " LIKE '%" & splitEntries(i) & "%' " & m_qrySourceSelectionMethod & " "
							Else
								sql = sql & db_fld_SCSourceDesc & " LIKE '%" & splitEntries(i) & "%' " & m_qrySourceSelectionMethod & " "
							End If
						Next
					Else
						sql = sql & "(" & db_fld_SCSourceDesc & " LIKE '%" & compareVal & "%') "
					End If
				End If
			End If

			'Include Selected Sites
			If rdo_qrySiteList.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim numParams As Integer	'the number of selected Agency Codes to qualify the query by
				numParams = lbx_qrySites.SelectedItems.Count
				If numParams <= 0 Then
					ShowError("There were no Sites selected to Query by." & vbCr & "Please select at least one Site from the list")
					Return ""
				End If
				If numParams > 1 Then
					For i = 0 To numParams - 1
						If i = 0 Then 'if this is the first one
							sql = sql & "((" & db_fld_SCSiteCode & " = '" & FixSQL(Split(lbx_qrySites.SelectedItems.Item(i), " - ")(0)) & "' AND " & db_fld_SCSiteName & " = '" & FixSQL(Split(lbx_qrySites.SelectedItems.Item(i), " - ")(1)) & "') OR "
						ElseIf i = numParams - 1 Then 'if this is the last one
							sql = sql & "(" & db_fld_SCSiteCode & " = '" & FixSQL(Split(lbx_qrySites.SelectedItems.Item(i), " - ")(0)) & "' AND " & db_fld_SCSiteName & " = '" & FixSQL(Split(lbx_qrySites.SelectedItems.Item(i), " - ")(1)) & "'))"
						Else
							sql = sql & "(" & db_fld_SCSiteCode & " = '" & FixSQL(Split(lbx_qrySites.SelectedItems.Item(i), " - ")(0)) & "' AND " & db_fld_SCSiteName & " = '" & FixSQL(Split(lbx_qrySites.SelectedItems.Item(i), " - ")(1)) & "') OR "
						End If
					Next
				ElseIf numParams = 1 Then
					sql = sql & "(" & db_fld_SCSiteCode & " = '" & FixSQL(Split(lbx_qrySites.SelectedItems.Item(0), " - ")(0)) & "' AND " & db_fld_SCSiteName & " = '" & FixSQL(Split(lbx_qrySites.SelectedItems.Item(0), " - ")(1)) & "') "
				End If
			End If
			'Include Selected Variables
			If rdo_qryVarList.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim numParams As Integer 'the number of Variables selected to qualify the query by
				numParams = lbx_qryVars.SelectedItems.Count
				If numParams <= 0 Then
					ShowError("There were no Vars selected to Query by." & vbCr & "Please select at least one Var from the list")
					Return ""
				End If
				If numParams > 1 Then
					For i = 0 To numParams - 1
						If i = 0 Then 'if this is the first one
							sql = sql & "((" & db_fld_SCVarCode & " = '" & FixSQL(Split(lbx_qryVars.SelectedItems.Item(i), " - ")(0)) & "' AND " & db_fld_SCVarName & " = '" & FixSQL(Split(lbx_qryVars.SelectedItems.Item(i), " - ")(1)) & "') OR "
						ElseIf i = numParams - 1 Then 'if this is the last one
							sql = sql & "(" & db_fld_SCVarCode & " = '" & FixSQL(Split(lbx_qryVars.SelectedItems.Item(i), " - ")(0)) & "' AND " & db_fld_SCVarName & " = '" & FixSQL(Split(lbx_qryVars.SelectedItems.Item(i), " - ")(1)) & "'))"
						Else
							sql = sql & "(" & db_fld_SCVarCode & " = '" & FixSQL(Split(lbx_qryVars.SelectedItems.Item(i), " - ")(0)) & "' AND " & db_fld_SCVarName & " = '" & FixSQL(Split(lbx_qryVars.SelectedItems.Item(i), " - ")(1)) & "') OR "
						End If
					Next
				ElseIf numParams = 1 Then
					sql = sql & "(" & db_fld_SCVarCode & " = '" & FixSQL(Split(lbx_qryVars.SelectedItems.Item(0), " - ")(0)) & "' AND " & db_fld_SCVarName & " = '" & FixSQL(Split(lbx_qryVars.SelectedItems.Item(0), " - ")(1)) & "') "
				End If
			End If
			'Include Selected Categories
			If chb_qryGenCat.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim numCategories As Integer 'the number of selected Agency Codes to qualify the query by
				numCategories = lbx_qryGenCat.SelectedItems.Count
				If numCategories <= 0 Then
					ShowError("There were no Categories selected to Query by." & vbCrLf & "Please select at least one Category from the list")
					Return ""
				End If
				If numCategories > 1 Then
					For i = 0 To numCategories - 1
						If i = 0 Then 'if this is the first one
							sql = sql & "(" & db_fld_SCGenCat & " = '" & lbx_qryGenCat.SelectedItems(i) & "' OR "
						ElseIf i = numCategories - 1 Then 'if this is the last one
							sql = sql & db_fld_SCGenCat & " = '" & lbx_qryGenCat.SelectedItems(i) & "') "
						Else
							sql = sql & db_fld_SCGenCat & " = '" & lbx_qryGenCat.SelectedItems(i) & "' OR "
						End If
					Next
				ElseIf numCategories = 1 Then
					sql = sql & "(" & db_fld_SCGenCat & " = '" & lbx_qryGenCat.SelectedItems(0) & "') "
				End If
			End If
			'Include Selected Value Types
			If chb_qryValType.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim numParams As Integer 'the number of Variables selected to qualify the query by
				numParams = lbx_qryValType.SelectedItems.Count
				If numParams <= 0 Then
					ShowError("There were no Variables selected to Query by." & vbCrLf & "Please select at least one Variable from the list")
					Return ""
				ElseIf numParams = 1 Then
					sql = sql & "(" & db_fld_SCValueType & " = '" & lbx_qryValType.SelectedItems.Item(0) & "') "
				Else
					For i = 0 To numParams - 1
						If i = numParams - 1 Then
							sql = sql & db_fld_SCValueType & " = '" & lbx_qryValType.SelectedItems.Item(i) & "') "
						ElseIf i = 0 Then
							sql = sql & "(" & db_fld_SCValueType & " = '" & lbx_qryValType.SelectedItems.Item(i) & "' OR "
						Else
							sql = sql & db_fld_SCValueType & " = '" & lbx_qryValType.SelectedItems.Item(i) & "' OR "
						End If
					Next
				End If
			End If
			'Include Selected Sample Mediums
			If chb_qrySampleMed.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim numParams As Integer 'the number of Sample Mediums selected to qualify the query by
				numParams = lbx_qrySampleMed.SelectedItems.Count
				If numParams <= 0 Then
					ShowError("There were no Sample Medium selected to Query by." & vbCrLf & "Please select at least one Variable from the list")
					Return ""
				ElseIf numParams = 1 Then
					sql = sql & "(" & db_fld_SCSampleMed & " = '" & lbx_qrySampleMed.SelectedItems.Item(0) & "') "
				Else
					For i = 0 To numParams - 1
						If i = numParams - 1 Then
							sql = sql & db_fld_SCSampleMed & " = '" & lbx_qrySampleMed.SelectedItems.Item(i) & "') "
						ElseIf i = 0 Then
							sql = sql & "(" & db_fld_SCSampleMed & " = '" & lbx_qrySampleMed.SelectedItems.Item(i) & "' OR "
						Else
							sql = sql & db_fld_SCSampleMed & " = '" & lbx_qrySampleMed.SelectedItems.Item(i) & "' OR "
						End If
					Next
				End If
			End If
			'Include Selected Data Types 
			If chb_qryDataType.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim numParams As Integer 'the number of Data Types selected to qualify the query by
				numParams = lbx_qryDataType.SelectedItems.Count
				If numParams <= 0 Then
					ShowError("There were no Data Types selected to Query by." & vbCrLf & "Please select at least one Variable from the list")
					Return ""
				ElseIf numParams = 1 Then
					sql = sql & "(" & db_fld_SCDataType & " = '" & lbx_qryDataType.SelectedItems.Item(0) & "') "
				Else
					For i = 0 To numParams - 1
						If i = numParams - 1 Then
							sql = sql & db_fld_SCDataType & " = '" & lbx_qryDataType.SelectedItems.Item(i) & "') "
						ElseIf i = 0 Then
							sql = sql & "(" & db_fld_SCDataType & " = '" & lbx_qryDataType.SelectedItems.Item(i) & "' OR "
						Else
							sql = sql & db_fld_SCDataType & " = '" & lbx_qryDataType.SelectedItems.Item(i) & "' OR "
						End If
					Next
				End If
			End If
			'Include Selected QCLevels
			If chb_qryQCLevel.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim numCodes As Integer	'the number of selected Agency Codes to qualify the query by
				numCodes = lbx_qryQCLevel.SelectedItems.Count
				If numCodes <= 0 Then
					ShowError("There were no QC Levels selected to Query by." & vbCrLf & "Please select at least one QC Level from the list.")
					Return ""
				End If
				If numCodes > 1 Then
					For i = 0 To numCodes - 1
						If i = 0 Then 'if this is the first one
							sql = sql & "(" & db_fld_SCQCLevel & " = '" & Split(lbx_qryQCLevel.SelectedItems.Item(i), " - ")(0) & "' OR "
						ElseIf i = numCodes - 1 Then 'if this is the last one
							sql = sql & db_fld_SCQCLevel & " = '" & Split(lbx_qryQCLevel.SelectedItems.Item(i), " - ")(0) & "') "
						Else
							sql = sql & db_fld_SCQCLevel & " = '" & Split(lbx_qryQCLevel.SelectedItems.Item(i), " - ")(0) & "' OR "
						End If
					Next
				ElseIf numCodes = 1 Then
					sql = sql & "(" & db_fld_SCQCLevel & " = '" & Split(lbx_qryQCLevel.SelectedItems.Item(0), " - ")(0) & "') "
				End If
			End If

			'Search Specified Time Period
			If chb_qryDate.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				'get the values
				Dim max As Date	'the "To" Date value selected by the user
				Dim min As Date	'the "From" Date value selected by the user
				min = dtp_qryTimeBegin.Value
				max = dtp_qryTimeEnd.Value.AddDays(1)

				'set the date values in sql
				sql = sql & "(" & db_fld_SCBeginDT & " >= '" & min & "' AND " & db_fld_SCEndDT & " <= '" & max & "') "
			End If
			'Search for Matching Number of Observations
			If chb_qryNumObs.Checked Then
				If Not FirstCommand Then
					sql = sql & "AND "
				Else
					FirstCommand = False
				End If
				Dim val As Integer 'the max Number of Observations comparison value to qualify the series by
				val = num_qryObs.Value
				If val < 0 Or val < 0 Then
					ShowError("Invalid Number of Observations Entered." & vbCrLf & "Please enter positive number of observations to query by.")
					Return ""
				Else
					sql = sql & "(" & db_fld_SCValueCount & m_qryNumObsMethod & val & ") "
				End If
			End If

			sql = sql & " ORDER BY " & db_tbl_SeriesCatalog & "." & db_fld_SCSiteCode & ", " & _
			   db_tbl_SeriesCatalog & "." & db_fld_SCSiteName & ", " & _
			   db_tbl_SeriesCatalog & "." & db_fld_SCVarCode & ", " & _
			   db_tbl_SeriesCatalog & "." & db_fld_SCVarName & ", " & _
			   db_tbl_SeriesCatalog & "." & db_fld_SCQCLevel

			'return created query
			If FirstCommand Then
				ShowError("No Query Parameters Were Selected" & vbCrLf & "Please Select at Least One Query Parameter")
				Return ""
			End If
			Return sql
		Catch ex As Exception
            ShowError("An Error occurred while creating the Query." & vbCrLf & "Message = " & ex.Message, ex)
			Return ""
		End Try
	End Function

#End Region

#Region " Query Tab: Export Functions "

	Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_qryDataExport.Click
		'Exports the database files to a MyDB comma delimited table
		'Input:     Standard Form Inputs
		'Output:    Saves the queried data to a ComaDelimitedFile

        Dim i As Integer 'Counter Variable
		If lv_qryResults.CheckedItems.Count < 1 Then
			'Nothing was selected
			ShowError("Please select at least one item to export")
		Else
			Dim exportSeriesID(lv_qryResults.CheckedItems.Count - 1) As Integer	'An array used to store the series IDs of the selected items

			'Reset the File Dialog to a generic filename
			sfdExportMyDB.FileName = "MyDB"
			If sfdExportMyDB.ShowDialog = Windows.Forms.DialogResult.OK Then
				Me.Refresh() 'Reload the form after the dialog box closes
				Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                Dim queryString As String 'The string used to export the data
                Dim dFileName As String 'The filename to save the data
                Dim mFileName As String 'The filename to save the metadata
                Dim dataExport As frmDataExport 'The Data Export Progresss Form
                Dim metaExport As frmMetadataExport 'The Metadata Progress Form
				dFileName = sfdExportMyDB.FileName
				Try
					'Copy all of the selected series' IDs to exportSeriesID
					For i = 0 To lv_qryResults.CheckedItems.Count - 1
						exportSeriesID(i) = m_qrySeriesID(lv_qryResults.CheckedIndices(i))
					Next

					'Generate a query string for the selected series IDs
					QueryString = CreateExportQuery(exportSeriesID)
					'Create the correct dataExport progress window
					Select Case sfdExportMyDB.FilterIndex
						Case 1
							dataExport = New frmDataExport(queryString, dFileName, exportSeriesID, ",")
						Case 2
							DataExport = New frmDataExport(QueryString, dFileName, exportSeriesID, vbTab)
						Case Else
							DataExport = New frmDataExport(QueryString, dFileName, exportSeriesID, ";")
					End Select
					'Open the DataExport progress window
					Select Case DataExport.ShowDialog()
                        Case Windows.Forms.DialogResult.Yes
                            If Not (g_CurrOptions.MetadataExport) Then
                                MsgBox("Export Complete", MsgBoxStyle.Information, "ODM Tools")
                            End If
                        Case Windows.Forms.DialogResult.Cancel

                        Case Else
                            ShowError("Export Failed")
                    End Select

					'If also exporting metadata ...
                    If g_CurrOptions.MetadataExport Then
                        'sfdExportMetadata.FileName = Split(dFileName, ".")(0) 'Defaults to the filename before the first .
                        'If sfdExportMetadata.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If dFileName.Contains(".") Then
                            mFileName = dFileName.Substring(0, dFileName.LastIndexOf(".")) & ".xml" 'sfdExportMetadata.FileName
                        Else
                            mFileName = dFileName & ".xml" 'sfdExportMetadata.FileName
                        End If
                        'Create the correct dataExport progress window
                        metaExport = New frmMetadataExport(mFileName, exportSeriesID)
                        'Open the DataExport progress window
                        Select Case metaExport.ShowDialog()
                            Case Windows.Forms.DialogResult.Yes
                                MsgBox("Export Complete", MsgBoxStyle.Information, "ODM Tools")
                            Case Windows.Forms.DialogResult.Cancel

                            Case Else
                                ShowError("Metadata Export Failed")
                        End Select
                        'End If
                    End If

				Catch ex As Exception
                    'MsgBox(ex.Message)'TESTING ONLY!!!!!
                End Try
			End If
		End If
		'Set the cursor back to normal
		Me.Cursor = System.Windows.Forms.Cursors.Default
	End Sub

	Private Sub btn_qryMetaExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_qryMetaExport.Click
		'Exports the metadat to a xml file
		'Input:     Standard Form Inputs
		'Output:    Saves the queried data to a ComaDelimitedFile
        Dim mFilename As String 'The filename to save the metadata
        Dim metaExport As frmMetadataExport 'The Metadata Progress Form
        Dim i As Integer 'Counter Variable
		If lv_qryResults.CheckedItems.Count < 1 Then
			ShowError("Please select at least one item to export")
		Else
            Dim exportSeriesID(lv_qryResults.CheckedItems.Count - 1) As Integer 'Array of series IDs to export
			For i = 0 To lv_qryResults.CheckedItems.Count - 1
				exportSeriesID(i) = m_qrySeriesID(lv_qryResults.CheckedIndices(i))
			Next
			'Sets the default filename
			sfdExportMetadata.FileName = "Metadata"
			If sfdExportMetadata.ShowDialog = Windows.Forms.DialogResult.OK Then
				mFilename = sfdExportMetadata.FileName
				'Create the correct dataExport progress window
				MetaExport = New frmMetadataExport(mFilename, exportSeriesID)
				'Open the DataExport progress window
				Select Case MetaExport.ShowDialog()
					Case Windows.Forms.DialogResult.Yes
                        MsgBox("Metadata Export Complete", MsgBoxStyle.Information, "ODM Tools")
					Case Windows.Forms.DialogResult.Cancel

					Case Else
						'ShowError("Metadata Export Failed") 'TESTING ONLY!!
				End Select
			End If
		End If
		'Set the cursor back to default
		Me.Cursor = System.Windows.Forms.Cursors.Default
	End Sub

	Private Sub mnuQDRCSingleExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQDRCSingleExport.Click
		'Exports the database files to a MyDB comma delimited table
		'Input:     Standard Form Inputs
		'Output:    Saves the queried data to a ComaDelimitedFile

		If lv_qryResults.SelectedItems.Count < 1 Then
			'Nothing was selected
			ShowError("Please select at least one item to export")
		Else
			Dim exportSeriesID(0) As Integer	'An array used to store the series IDs of the selected items

			'Reset the File Dialog to a generic filename
			sfdExportMyDB.FileName = "MyDB"
			If sfdExportMyDB.ShowDialog = Windows.Forms.DialogResult.OK Then
				Me.Refresh() 'Reload the form after the dialog box closes
				Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                Dim queryString As String 'Query used to export the data
                Dim dFileName As String 'File name to store the data
                Dim mFileName As String 'File name to store the metadata
                Dim dataExport As frmDataExport 'Data Export Progress Form
                Dim metaExport As frmMetadataExport 'Metadata progress form
				dFileName = sfdExportMyDB.FileName
				Try
					exportSeriesID(0) = m_qrySeriesID(lv_qryResults.SelectedIndices(0))

					'Generate a query string for the selected series IDs
					QueryString = CreateExportQuery(exportSeriesID)
					'Create the correct dataExport progress window
					Select Case sfdExportMyDB.FilterIndex
						Case 1
							DataExport = New frmDataExport(QueryString, dFileName, exportSeriesID, ",")
						Case 2
							DataExport = New frmDataExport(QueryString, dFileName, exportSeriesID, vbTab)
						Case Else
							DataExport = New frmDataExport(QueryString, dFileName, exportSeriesID, ";")
					End Select
					'Open the DataExport progress window
					Select Case DataExport.ShowDialog()
						Case Windows.Forms.DialogResult.Yes
                            MsgBox("Data Export Complete", MsgBoxStyle.Information, "ODM Tools")
						Case Windows.Forms.DialogResult.Cancel

						Case Else
							ShowError("Data Export Failed")
					End Select

					'If also exporting metadata ...
					If g_CurrOptions.MetadataExport = True Then
						sfdExportMetadata.FileName = Split(dFileName, ".", 1)(0) 'Defaults to the filename before the first .
						If sfdExportMetadata.ShowDialog = Windows.Forms.DialogResult.OK Then
							mFileName = sfdExportMetadata.FileName
							'Create the correct dataExport progress window
							MetaExport = New frmMetadataExport(mFileName, exportSeriesID)
							'Open the DataExport progress window
							Select Case MetaExport.ShowDialog()
								Case Windows.Forms.DialogResult.Yes
                                    MsgBox("Metadata Export Complete", MsgBoxStyle.Information, "ODM Tools")
								Case Windows.Forms.DialogResult.Cancel

								Case Else
									ShowError("Metadata Export Failed")
							End Select
						End If
					End If
				Catch ex As Exception
					'MsgBox(ex.Message)'TESTING ONLY!!!!!
				End Try
			End If
		End If
		'Set the cursor back to normal
		Me.Cursor = System.Windows.Forms.Cursors.Default
	End Sub

	Private Sub mnuQDRCExportMeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQDRCExportMeta.Click
        'Exports the Metadata for a single DataSeries to an xml file
        'Outputs: Writes Metadata for a single DataSeries
		Dim exportSeriesID(0) As Integer	'The ID of the DataSeries to export metadata for
        Dim mFilename As String 'Filename to save the metadata
        Dim metaExport As frmMetadataExport 'Metadata progress form
		If lv_qryResults.SelectedItems.Count <> 1 Then
			ShowError("Please select only one item to export")
		Else
			exportSeriesID(0) = m_qrySeriesID(lv_qryResults.SelectedIndices(0))
			sfdExportMetadata.FileName = "Metadata"
			If sfdExportMetadata.ShowDialog = Windows.Forms.DialogResult.OK Then
				mFileName = sfdExportMetadata.FileName
				'Create the correct dataExport progress window
				MetaExport = New frmMetadataExport(mFileName, exportSeriesID)
				'Open the DataExport progress window
				Select Case MetaExport.ShowDialog()
					Case Windows.Forms.DialogResult.Yes
                        MsgBox("Metadata Export Complete", MsgBoxStyle.Information, "ODM Tools")
					Case Windows.Forms.DialogResult.Cancel

					Case Else
						ShowError("Metadata Export Failed")
				End Select
			End If
		End If
		Me.Cursor = System.Windows.Forms.Cursors.Default
	End Sub

	Private Sub mnuQDRCViewMeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQDRCViewMeta.Click
		'Exports the metadata for a single data series to a temporary xml file then opens it in the default xml viewer
        'Outputs: Opens XML Browser to read Metadata
        Dim seriesID(0) As Integer 'The series ID to export

		If lv_qryResults.SelectedItems.Count <> 1 Then
			ShowError("Please select only one item to export")
		Else
			seriesID(0) = m_qrySeriesID(lv_qryResults.SelectedIndices(0))

			ViewMetadata(seriesID)
		End If
	End Sub

#End Region

#Region " Query Tab: Plot selected Data Series "

	Private Sub lv_qryResults_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv_qryResults.DoubleClick
        'When an Item in the listview is double clicked, item is plotted on the plot tab
        'Outputs: Plots selected item on plot tab
		tabctlODMTools.SelectedTab = tabpgVisualize
		Me.Refresh()
        Dim i As Integer 'counter variable

		'1. Select the selected value's site in cboxVisSite
		'For i = cboxVisSite.Items.Count - 1 To 0 Step -1
		'	If cboxVisSite.Items.Item(i) = (lv_qryResults.SelectedItems(0).SubItems(0).Text & " - " & lv_qryResults.SelectedItems(0).SubItems(1).Text) Then
		'		cboxVisSite.SelectedIndex = i
		'	End If
		'Next
		'NOTE: Made to match mnuQDRCPlot/Edit functionality
		For i = cboxVisSite.Items.Count - 1 To 0 Step -1
			If cboxVisSite.Items.Item(i) = (lv_qryResults.SelectedItems(0).SubItems(0).Text) Then
				cboxVisSite.SelectedIndex = i
			End If
		Next

		'2. Select the selected value's variable in cboxVisVariable
		'For i = cboxVisVariable.Items.Count - 1 To 0 Step -1
		'	If cboxVisVariable.Items.Item(i) = (lv_qryResults.SelectedItems(0).SubItems(2).Text & " - " & lv_qryResults.SelectedItems(0).SubItems(3).Text) Then
		'		cboxVisVariable.SelectedIndex = i
		'	End If
		'Next
		'NOTE: Made to match mnuQDRCPlot/Edit functionality
		For i = cboxVisVariable.Items.Count - 1 To 0 Step -1
			If cboxVisVariable.Items.Item(i) = (lv_qryResults.SelectedItems(0).SubItems(1).Text) Then
				cboxVisVariable.SelectedIndex = i
			End If
		Next

		'3. Select the selected specific data series in 
		'For i = lvVisDataSeries.Items.Count - 1 To 0 Step -1
		'	If (lvVisDataSeries.Items.Item(i).SubItems(0).Text = lv_qryResults.SelectedItems(0).SubItems(10).Text) And (lvVisDataSeries.Items.Item(i).SubItems(5).Text = lv_qryResults.SelectedItems(0).SubItems(4).Text) And (lvVisDataSeries.Items.Item(i).SubItems(6).Text = lv_qryResults.SelectedItems(0).SubItems(5).Text) And (lvVisDataSeries.Items.Item(i).SubItems(7).Text = lv_qryResults.SelectedItems(0).SubItems(9).Text) And (lvVisDataSeries.Items.Item(i).SubItems(9).Text = lv_qryResults.SelectedItems(0).SubItems(8).Text) Then
		'		lvVisDataSeries.Select()
		'		lvVisDataSeries.Items(i).Selected = True
		'	End If
		'Next
		'NOTE: Made to match mnuQDRCPlot/Edit functionality
		For i = lvVisDataSeries.Items.Count - 1 To 0 Step -1
			If (lvVisDataSeries.Items.Item(i).SubItems(0).Text = lv_qryResults.SelectedItems(0).SubItems(3).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(1).Text = lv_qryResults.SelectedItems(0).SubItems(2).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(2).Text = lv_qryResults.SelectedItems(0).SubItems(13).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(3).Text = lv_qryResults.SelectedItems(0).SubItems(14).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(4).Text = lv_qryResults.SelectedItems(0).SubItems(5).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(5).Text = lv_qryResults.SelectedItems(0).SubItems(4).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(6).Text = lv_qryResults.SelectedItems(0).SubItems(6).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(7).Text = lv_qryResults.SelectedItems(0).SubItems(7).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(8).Text = lv_qryResults.SelectedItems(0).SubItems(8).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(9).Text = lv_qryResults.SelectedItems(0).SubItems(11).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(10).Text = lv_qryResults.SelectedItems(0).SubItems(12).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(11).Text = lv_qryResults.SelectedItems(0).SubItems(10).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(13).Text = lv_qryResults.SelectedItems(0).SubItems(9).Text) Then

				lvVisDataSeries.Select()
				lvVisDataSeries.Items(i).Selected = True
			End If
		Next

		btnPlot.PerformClick()
	End Sub

	Private Sub mnuQDRCPlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQDRCPlot.Click
        'When Plot is selected from mnuQDRC, item is plotted on the plot tab
        'Outputs: Plots selected item on plot tab
		tabctlODMTools.SelectedTab = tabpgVisualize
		Me.Refresh()
        Dim i As Integer 'counter variable

		'1. Select the selected value's site in cboxVisSite
		For i = cboxVisSite.Items.Count - 1 To 0 Step -1
			If cboxVisSite.Items.Item(i) = (lv_qryResults.SelectedItems(0).SubItems(0).Text) Then
				cboxVisSite.SelectedIndex = i
			End If
		Next

		'2. Select the selected value's variable in cboxVisVariable
		For i = cboxVisVariable.Items.Count - 1 To 0 Step -1
			If cboxVisVariable.Items.Item(i) = (lv_qryResults.SelectedItems(0).SubItems(1).Text) Then
				cboxVisVariable.SelectedIndex = i
			End If
		Next

		'3. Select the selected specific data series in 
		For i = lvVisDataSeries.Items.Count - 1 To 0 Step -1
			If (lvVisDataSeries.Items.Item(i).SubItems(0).Text = lv_qryResults.SelectedItems(0).SubItems(3).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(1).Text = lv_qryResults.SelectedItems(0).SubItems(2).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(2).Text = lv_qryResults.SelectedItems(0).SubItems(13).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(3).Text = lv_qryResults.SelectedItems(0).SubItems(14).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(4).Text = lv_qryResults.SelectedItems(0).SubItems(5).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(5).Text = lv_qryResults.SelectedItems(0).SubItems(4).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(6).Text = lv_qryResults.SelectedItems(0).SubItems(6).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(7).Text = lv_qryResults.SelectedItems(0).SubItems(7).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(8).Text = lv_qryResults.SelectedItems(0).SubItems(8).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(9).Text = lv_qryResults.SelectedItems(0).SubItems(11).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(10).Text = lv_qryResults.SelectedItems(0).SubItems(12).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(11).Text = lv_qryResults.SelectedItems(0).SubItems(10).Text) AndAlso _
			   (lvVisDataSeries.Items.Item(i).SubItems(13).Text = lv_qryResults.SelectedItems(0).SubItems(9).Text) Then

				lvVisDataSeries.Select()
				lvVisDataSeries.Items(i).Selected = True
			End If
		Next

		btnPlot.PerformClick()
	End Sub

	Private Sub mnuQDRCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQDRCEdit.Click
        'When Plot is selected from mnuQDRC, item is selected on the edit tab
        'Outputs: Selects Specified item on edit tab
		tabctlODMTools.SelectedTab = tabpgEdit
		Me.Refresh()
        Dim i As Integer 'counter variable

		If m_IsEditTabEnabled Then

			'1. Select the selected value's site in cboxEditSite
			For i = cboxEditSite.Items.Count - 1 To 0 Step -1
				If cboxEditSite.Items.Item(i) = (lv_qryResults.SelectedItems(0).SubItems(0).Text) Then
					cboxEditSite.SelectedIndex = i
				End If
			Next

			'2. Select the selected value's variable in cboxEditVariable
			For i = cboxEditVariable.Items.Count - 1 To 0 Step -1
				If cboxEditVariable.Items.Item(i) = (lv_qryResults.SelectedItems(0).SubItems(1).Text) Then
					cboxEditVariable.SelectedIndex = i
				End If
			Next

			'3. Select the selected specific data series in 
			For i = lvEditDataSeries.Items.Count - 1 To 0 Step -1
                If (lvEditDataSeries.Items.Item(i).SubItems(0).Text = lv_qryResults.SelectedItems(0).SubItems(4).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(1).Text = lv_qryResults.SelectedItems(0).SubItems(2).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(2).Text = lv_qryResults.SelectedItems(0).SubItems(3).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(3).Text = lv_qryResults.SelectedItems(0).SubItems(15).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(4).Text = lv_qryResults.SelectedItems(0).SubItems(16).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(5).Text = lv_qryResults.SelectedItems(0).SubItems(6).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(6).Text = lv_qryResults.SelectedItems(0).SubItems(5).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(7).Text = lv_qryResults.SelectedItems(0).SubItems(7).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(8).Text = lv_qryResults.SelectedItems(0).SubItems(8).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(9).Text = lv_qryResults.SelectedItems(0).SubItems(9).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(10).Text = lv_qryResults.SelectedItems(0).SubItems(12).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(11).Text = lv_qryResults.SelectedItems(0).SubItems(13).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(12).Text = lv_qryResults.SelectedItems(0).SubItems(14).Text) AndAlso _
                    (lvEditDataSeries.Items(i).SubItems(15).Text = lv_qryResults.SelectedItems(0).SubItems(10).Text) Then

                    lvEditDataSeries.Select()
                    lvEditDataSeries.Items(i).Selected = True
                End If
            Next
		End If
	End Sub

#End Region

#Region " Visualize Tab: Form Controls Functions "

#Region " Data Selection Functions "

    Private Sub cboxVisSite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxVisSite.SelectedIndexChanged
        'loads the Variables for the selected Site
        'the inputs/outputs are standard for form events
        Dim siteCode As String 'holds the Code for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Dim siteName As String 'holds the Name for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Try
            '1. clear out any old Data -> cboxVisVariable
            cboxVisVariable.Items.Clear()

            '2. get the site Code,Name from the selected item
            siteCode = Split(cboxVisSite.SelectedItem, " - ")(0)
            siteName = CStr(cboxVisSite.SelectedItem).Substring(CStr(cboxVisSite.SelectedItem).IndexOf(" - ") + 3) 'NOTE: using substring here to make sure that get full Site Name, even if other " - " values are in the name

            '3. Load the Variables for the selected site from the Series Catalog Table
            If Not (LoadVisualizeVariables(siteCode, siteName)) Then
                'NOTE: errors occurred while loading Variables, disable form
                '4. clear out any other old data
                lvVisDataSeries.Items.Clear()
                InitializeVisualizeDateInfo()

                '5. disable Update Plot Button, plot selection controls
                cboxVisVariable.Enabled = False
                lvVisDataSeries.Enabled = False
                gboxDateInfo.Enabled = False
                btnPlot.Enabled = False
            Else
                '4. select the first variable -> NOTE: when a variable is selected, the Data Series will be populated
                If cboxVisVariable.Items.Count > 0 And cboxVisVariable.SelectedIndex < 0 Then
                    cboxVisVariable.SelectedIndex = 0
                End If

                '5. enable Variable Selection -> others are enabled already if needed
                cboxVisVariable.Enabled = True
            End If

            'NOTE: Don't need to update the plot, etc here -> a new Variable is always selected, and it is done when a Variable is selected
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while selecting a Site on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub cboxVisSite_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboxVisSite.KeyPress
        'validates the new Site when the enter key is pressed
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                cboxVisSite.SelectedItem = cboxVisSite.Text

                'make sure that item was selected
                If (cboxVisSite.SelectedItem Is Nothing) Then
                    cboxVisSite.Text = ""
                End If
        End Select
    End Sub

    Private Sub cboxVisVariable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxVisVariable.SelectedIndexChanged
        'loads the Data Series for the selected Site and Variable, resets the current plot, sets all plots = Not Current
        'the inputs/outputs are standard for form events
        Dim siteCode As String 'holds the Code for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Dim siteName As String 'holds the Name for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Dim varCode As String 'holds the Code for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Dim varName As String 'holds the Name for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Try
            '1. clear out any old Data -> lvVizDataSeries, Dates
            lvVisDataSeries.Items.Clear()
            InitializeVisualizeDateInfo()

            '2. get the site Code,Name from the selected item
            siteCode = Split(cboxVisSite.SelectedItem, " - ")(0)
            siteName = CStr(cboxVisSite.SelectedItem).Substring(CStr(cboxVisSite.SelectedItem).IndexOf(" - ") + 3) 'NOTE: using substring here to make sure that get full Site Name, even if other " - " values are in the name

            '3. get the variable Code,Name from the selected item
            varCode = Split(cboxVisVariable.SelectedItem, " - ")(0)
            varName = CStr(cboxVisVariable.SelectedItem).Substring(CStr(cboxVisVariable.SelectedItem).IndexOf(" - ") + 3) 'NOTE: using substring here to make sure that get full variable Name, even if other " - " values are in the name

            '4. Load the Data Series for the selected site and variable from the Series Catalog Table
            If Not (LoadVisualizeDataSeries(siteCode, siteName, varCode, varName)) Then
                'NOTE: errors occurred while loading Data Series, disable form
                '5. clear out any other old data
                InitializeVisualizeDateInfo()

                '6. disable Update Plot Button, plot selection controls
                lvVisDataSeries.Enabled = False
                gboxDateInfo.Enabled = False
                btnPlot.Enabled = False
            Else
                '5. enable lvDataSeries
                lvVisDataSeries.Enabled = True

                'NOTE: Per Jeff 3/26/07 -> select 1st Data Series available
                '*****************************************************************************************
                ''6. disable Update Plot Button, Date Controls -> till the user selects a Data Series
                'gboxDateInfo.Enabled = False
                'btnPlot.Enabled = False
                '*****************************************************************************************
                If lvVisDataSeries.Items.Count <= 0 Then
                    '6. disable Update Plot Button, Date Controls -> till the user selects a Data Series
                    gboxDateInfo.Enabled = False
                    btnPlot.Enabled = False
                Else
                    lvVisDataSeries.Items(0).Selected = True
                End If
            End If

            '7. set m_NewPlotCriteriaSelected = True, reset plots, summary
            m_NewPlotCriteriaSelected = True
            InitializeVisualizeTab()

            'NOTE: Per comments on beta version being changed so auto selects 1st Data Series
            'clear out any selection
            lvVisDataSeries.SelectedItems.Clear()
            'select the first value
            lvVisDataSeries.Items(0).Selected = True
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while selecting a Variable on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub cboxVisVariable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboxVisVariable.KeyPress
        'validates the new Variable when the enter key is pressed
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                cboxVisVariable.SelectedItem = cboxVisVariable.Text

                'make sure that item was selected
                If (cboxVisVariable.SelectedItem Is Nothing) Then
                    cboxVisVariable.Text = ""
                End If
        End Select
    End Sub

    Private Sub lvVisDataSeries_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles lvVisDataSeries.ColumnWidthChanged
        'make sure that no col Width > maxColWIdth
        'the inputs/outputs are standard for form events

        Dim maxColWidth As Integer = lvVisDataSeries.Width - 25 'holds the maxWidth for a column in the Data Selection list view

        If lvVisDataSeries.Columns(e.ColumnIndex).Width > maxColWidth Then
            lvVisDataSeries.Columns(e.ColumnIndex).Width = maxColWidth
        End If
    End Sub

    Private Sub lvVisDataSeries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvVisDataSeries.SelectedIndexChanged
        'loads the Date Range for the selected Data Series, resets the current plot, sets all plots = Not Current
        'the inputs/outputs are standard for form events
        Try
            '1. reset the Dates = Today
            InitializeVisualizeDateInfo()

            '2. See if anything was selected
            If lvVisDataSeries.SelectedItems.Count <= 0 Then
                '3. disable Update Plot Button, Date Controls
                gboxDateInfo.Enabled = False
                btnPlot.Enabled = False
            Else
                '3. Load the Date Range for the selected data series from the Series Catalog Table
                If Not (LoadVisualizeDateRange()) Then
                    'NOTE: errors occurred while loading the Date Range, disable form
                    'reset Dates = Today
                    InitializeVisualizeDateInfo()

                    '4. disable Update Plot Button, Date Controls
                    gboxDateInfo.Enabled = False
                    btnPlot.Enabled = False
                Else
                    'NOTE: The initial Date Range is set in LoadVisualizeDateRange()
                    '4. enable Update Plot Button, Date controls
                    gboxDateInfo.Enabled = True
                    btnPlot.Enabled = True
                End If

                '5. set m_NewPlotCriteriaSelected = True, reset plots, summary
                m_NewPlotCriteriaSelected = True
                InitializeVisualizeTab()
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while selecting a Data Series on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub dtpVisStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpVisStartDate.ValueChanged
        '
        'the inputs/outputs are standard for form events
        Try
            '1. check to see if loading value
            If Not (m_LoadingVisDateRange) And Not (m_LoadingVisualizeTab) Then
                '2. Validate selected value -> make sure that StartDate < EndDate
                If dtpVisStartDate.Value > dtpVisEndDate.Value Then
                    'Value is < End Date, shange End Date = Start Date
                    dtpVisEndDate.Value = dtpVisStartDate.Value
                End If

                '3. set m_NewPlotCriteriaSelected = True, reset plots,summary
                m_NewPlotCriteriaSelected = True
                InitializeVisualizeTab()
                'InitializeAllVisualizePlots() 'NOTE: This function calls SetVisPlotsCurrents, resets all plots)
                ''SetVisPlotsCurrent(False)
                'ClearSummary()

                '4. enable btnPlot
                btnPlot.Enabled = True

                ''4. update the current plot
                'tabctlPlots_SelectedIndexChanged(sender, e)
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while selecting a Start Date on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub dtpVisEndDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpVisEndDate.ValueChanged
        '
        'the inputs/outputs are standard for form events
        Try
            '1. check to see if loading value
            If (Not (m_LoadingVisDateRange)) And (Not (m_LoadingVisualizeTab)) Then
                '2. Validate selected value -> make sure that StartDate < EndDate
                If dtpVisEndDate.Value < dtpVisStartDate.Value Then
                    'Value is < Start Date, shange start date = end date
                    dtpVisStartDate.Value = dtpVisEndDate.Value
                End If

                '3. set m_NewPlotCriteriaSelected = True, reset plots, summary
                m_NewPlotCriteriaSelected = True
                InitializeVisualizeTab()
                'InitializeAllVisualizePlots() 'NOTE: This function calls SetVisPlotsCurrents, resets all plots)
                ''SetVisPlotsCurrent(False)
                'ClearSummary()

                '4. enable btnPlot
                btnPlot.Enabled = True

                ''4. update the current plot
                'tabctlPlots_SelectedIndexChanged(sender, e)
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while selecting an End Date on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Plot Functions "

    Private Sub tabctlPlots_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabctlPlots.SelectedIndexChanged
        'Resets the plots if they are not current, else shows selected tab
        'the inputs/outputs are standard for form events
        Try
            If Not (m_LoadingVisualizeTab) Then
                Select Case tabctlPlots.SelectedTab.Name
                    Case "tabpgTimeSeries"
                        ''TODO: Michelle: Remove the msgbox -> for Testing only!!
                        'MsgBox("You want to view the Time Series Plot")
                        If Not (m_IsPlotCurrent_TimeSeries) Then
                            'NOTE: Per Comments on beta ODM Tools -> if a plot has been plotted for the selected set of data, then go ahead and just plot when select a new tab
                            If Not (m_NewPlotCriteriaSelected) Then
                                'A graph has already been plotted for this set of data, go ahead and plot me
                                btnPlot_Click(Me, New System.EventArgs())
                            Else
                                'NOTE: New Data needs to be loaded still, so nothing has been plotted yet, so just enable Plot Button
                                'enable btnPlot
                                If gboxDateInfo.Enabled Then
                                    btnPlot.Enabled = True
                                End If
                            End If
                        Else
                            'disable btnPlot
                            btnPlot.Enabled = False
                        End If
                        'enable Time Series Plot Options, disable rest
                        gboxTSPlotOptions.Enabled = True
                        'gboxProbPlotOptions.Enabled = False
                        gboxHistPlotOptions.Enabled = False
                        gboxBoxPlotOptions.Enabled = False
                    Case "tabpgProbability"
                        ''TODO: Michelle: Remove the msgbox -> for Testing only!!
                        'MsgBox("You want to view the Probability Plot")
                        If Not (m_IsPlotCurrent_Probability) Then
                            'NOTE: Per Comments on beta ODM Tools -> if a plot has been plotted for the selected set of data, then go ahead and just plot when select a new tab
                            If Not (m_NewPlotCriteriaSelected) Then
                                'A graph has already been plotted for this set of data, go ahead and plot me
                                btnPlot_Click(Me, New System.EventArgs())
                            Else
                                'NOTE: New Data needs to be loaded still, so nothing has been plotted yet, so just enable Plot Button
                                'enable btnPlot
                                If gboxDateInfo.Enabled Then
                                    btnPlot.Enabled = True
                                End If
                            End If
                        Else
                            'disable btnPlot
                            btnPlot.Enabled = False
                        End If
                        'enable Probability Plot Options, disable rest
                        gboxTSPlotOptions.Enabled = False
                        'gboxProbPlotOptions.Enabled = True
                        gboxHistPlotOptions.Enabled = False
                        gboxBoxPlotOptions.Enabled = False
                    Case "tabpgHistogram"
                        ''TODO: Michelle: Remove the msgbox -> for Testing only!!
                        'MsgBox("You want to view the Histogram Plot")
                        If Not (m_IsPlotCurrent_Histogram) Then
                            'NOTE: Per Comments on beta ODM Tools -> if a plot has been plotted for the selected set of data, then go ahead and just plot when select a new tab
                            If Not (m_NewPlotCriteriaSelected) Then
                                'A graph has already been plotted for this set of data, go ahead and plot me
                                btnPlot_Click(Me, New System.EventArgs())
                            Else
                                'NOTE: New Data needs to be loaded still, so nothing has been plotted yet, so just enable Plot Button
                                'enable btnPlot
                                If gboxDateInfo.Enabled Then
                                    btnPlot.Enabled = True
                                End If
                            End If
                        Else
                            'disable btnPlot
                            btnPlot.Enabled = False
                        End If
                        'disable all plot options
                        gboxTSPlotOptions.Enabled = False
                        'gboxProbPlotOptions.Enabled = False
                        gboxHistPlotOptions.Enabled = True
                        gboxBoxPlotOptions.Enabled = False
                    Case "tabpgBoxPlot"
                        ''TODO: Michelle: Remove the msgbox -> for Testing only!!
                        'MsgBox("You want to view the Box/Whisker Plot")
                        If Not (m_IsPlotCurrent_BoxPlot) Then
                            'NOTE: Per Comments on beta ODM Tools -> if a plot has been plotted for the selected set of data, then go ahead and just plot when select a new tab
                            If Not (m_NewPlotCriteriaSelected) Then
                                'A graph has already been plotted for this set of data, go ahead and plot me
                                btnPlot_Click(Me, New System.EventArgs())
                            Else
                                'NOTE: New Data needs to be loaded still, so nothing has been plotted yet, so just enable Plot Button
                                'enable btnPlot
                                If gboxDateInfo.Enabled Then
                                    btnPlot.Enabled = True
                                End If
                            End If
                        Else
                            'disable btnPlot
                            btnPlot.Enabled = False
                        End If
                        'enable Box/Whisker Plot Options, disable rest
                        gboxTSPlotOptions.Enabled = False
                        'gboxProbPlotOptions.Enabled = False
                        gboxHistPlotOptions.Enabled = False
                        gboxBoxPlotOptions.Enabled = True
                End Select
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while selecting a Plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnPlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlot.Click
        'This function plots the selected graph on the Visualize Tab
        'the inputs/outputs are standard for form events
        Dim site As String
        Dim variable As String
        Dim varUnits As String
        Dim startDate As Date
        Dim endDate As Date
        Dim varUnitsIndex As Integer = 2
        'NOTE: Colums for lvVisData Series:
		'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description, Citation, Local Date Range, UTC Date Range, Value Count
        Try
            '1. change cursor = hourglass
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            '2. disable me -> will be enabled when changes are made
            btnPlot.Enabled = False

            '3. get the plotting parameters
            site = cboxVisSite.Text
            variable = cboxVisVariable.Text
            varUnits = GetAbbreviatedVariableUnitsFromDB(lvVisDataSeries.SelectedItems(0).SubItems(varUnitsIndex).Text)
            startDate = dtpVisStartDate.Value
            endDate = dtpVisEndDate.Value
            'siteID = CType(m_VisualizeIDs.Item(lvVisDataSeries.SelectedItems(0).Index), clsDataValueIDs).SiteID
            'varID = CType(m_VisualizeIDs.Item(lvVisDataSeries.SelectedItems(0).Index), clsDataValueIDs).VariableID
            'methodID = CType(m_VisualizeIDs.Item(lvVisDataSeries.SelectedItems(0).Index), clsDataValueIDs).MethodID
            'qcLevel = CInt(lvVisDataSeries.SelectedItems(0).SubItems(qcLevelIndex).text)

            '4. Load the Data from the Database if needed, calculate summary of new data
            If (m_NewPlotCriteriaSelected) Then
                'change title on graph
                SetVisualizePlotTitle(tabctlPlots.SelectedTab.Name, "Loading Data From Database ... ")
                'load data from dataabase
                LoadVisualizePlotDataFromDB(m_VisualizeIDs.Item(lvVisDataSeries.SelectedItems(0).Index), startDate, endDate)
                'Calculate and display stats
                ckboxUseCensoredData.Enabled = True
                gboxStatistics.Enabled = True
                CalculateSummary()
            End If

            '5. Plot the Data
            Select Case tabctlPlots.SelectedTab.Name
                Case "tabpgTimeSeries"
                    'plot the Time Series graph
                    PlotTimeSeries(site, variable, varUnits, startDate, endDate)
                    'set that the plot is current
                    m_IsPlotCurrent_TimeSeries = True
                Case "tabpgProbability"
                    'plot the Probablity graph
                    PlotProbability(site, variable, varUnits)
                    'set that the plot is current
                    m_IsPlotCurrent_Probability = True
                Case "tabpgHistogram"
                    'plot the Histogram graph
                    PlotHistogram(site, variable, varUnits)
                    'PlotHistogram2(site, variable, varUnits)
                    'set that the plot is current
                    m_IsPlotCurrent_Histogram = True
                Case "tabpgBoxPlot"
                    'plot the Box/Whisker graph
                    PlotBoxPlot(site, variable, varUnits)
                    'set that the plot is current
                    m_IsPlotCurrent_BoxPlot = True
            End Select

            '6. set m_NewPlotCriteriaSelected = False -> NOTE: The plotting function set the corresponding m_IsPlotCurrent_* variable already
            m_NewPlotCriteriaSelected = False

            '7. change cursor = default
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while updating the selected Plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Plot Options Functions "

#Region " Summary Options "

    Private Sub ckbboxUseCensoredData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckboxUseCensoredData.CheckedChanged
        CalculateSummary()
    End Sub

#End Region

#Region " Time Series Options "

    Private Sub rbtnTSLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnTSLine.CheckedChanged

        Dim gPane As ZedGraph.GraphPane
        Dim line As ZedGraph.LineItem
        Try
            'change the plot Type = Line, if plot = current
            If (m_IsPlotCurrent_TimeSeries) Then
                'get the graphPane, graphics objects
                gPane = zg5TimeSeries.GraphPane
                'g = zg5TimeSeries.CreateGraphics
                'change the plot type = Line
                line = CType(gPane.CurveList(0), ZedGraph.LineItem)
                If line.Symbol.Type = ZedGraph.SymbolType.Circle Then
                    line.Symbol.Type = ZedGraph.SymbolType.None
                End If
                If line.Line.IsVisible = False Then
                    line.Line.IsVisible = True
                End If
                'redraw the plot
                zg5TimeSeries.Refresh()
                'release resources
                'g.Dispose()
                line = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtnTSPoint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnTSPoint.CheckedChanged
        Dim gPane As ZedGraph.GraphPane
        'Dim g As Drawing.Graphics
        Dim line As ZedGraph.LineItem
        Try
            'change the plot Type = Line, if plot = current
            If (m_IsPlotCurrent_TimeSeries) Then
                'get the graphPane, graphics objects
                gPane = zg5TimeSeries.GraphPane
                'change the plot type = Line
                line = CType(gPane.CurveList(0), ZedGraph.LineItem)
                If line.Symbol.Type = ZedGraph.SymbolType.None Then
                    line.Symbol.Type = ZedGraph.SymbolType.Circle
                    line.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Black)
                End If
                If line.Line.IsVisible = True Then
                    line.Line.IsVisible = False
                End If
                'redraw the plot
                zg5TimeSeries.Refresh()
                'release resources
                'g.Dispose()
                line = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtnTSBoth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnTSBoth.CheckedChanged
        Dim gPane As ZedGraph.GraphPane
        Dim line As ZedGraph.LineItem
        Try
            'change the plot Type = Line, if plot = current
            If (m_IsPlotCurrent_TimeSeries) Then
                'get the graphPane, graphics objects
                gPane = zg5TimeSeries.GraphPane
                'change the plot type = Line
                line = CType(gPane.CurveList(0), ZedGraph.LineItem)
                If line.Symbol.Type = ZedGraph.SymbolType.None Then
                    line.Symbol.Type = ZedGraph.SymbolType.Circle
                    line.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Black)
                End If
                If line.Line.IsVisible = False Then
                    line.Line.IsVisible = True
                End If
                'redraw the plot
                zg5TimeSeries.Refresh()
                'release resources
                'g.Dispose()
                line = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Histogram Options "

    Private Sub ckboxHistSetNumBins_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckboxHistSetNumBins.CheckedChanged
        Try
            If (ckboxHistSetNumBins.Checked) Then
                'enable the settings
                gboxHPNumBarSettings.Enabled = True
            Else
                'disable the settings
                gboxHPNumBarSettings.Enabled = False
            End If

            'Redraw Histogram Plot
            If m_IsPlotCurrent_Histogram Then
                'reset the Histogram graph
                InitializeZedGraphPlot(zg5Histogram)
                'zg5Histogram.GraphPane.Title.Text = "Waiting For Update ..."
                're-plot the Histogram graph
                btnPlot_Click(sender, e)
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the " & """" & "Manually set the Number Of Bars" & """" & " checkbox was clicked on the Plot Options Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxHPNumBins_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxHPNumBins.KeyPress
        'Catch the "enter" key press -> validate me
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf
                'validate value -> enter key was pressed
                m_VisEditNumbBinsValidated = False
                tboxHPNumBins_Validated(sender, New System.EventArgs)
            Case Else
                m_VisEditNumbBinsValidated = False
        End Select
    End Sub

    Private Sub tboxHPNumBins_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxHPNumBins.Validated
        Dim val As Double
        'Validate the value, if valid then update the plot
        If Not (m_VisEditNumbBinsValidated) Then
            If tboxHPNumBins.Text <> "" Then
                If IsNumeric(tboxHPNumBins.Text) Then
                    val = CDbl(tboxHPNumBins.Text)
                    'make sure that it is an integer value
                    If Math.Truncate(val) <> val Then
                        'show error -> value MUST be an Integer
                        MsgBox("Invalid " & """" & "Number of Bars" & """" & " value: Value must be an Integer.")
                        'reset to current
                        tboxHPNumBins.Text = zg5Histogram.GraphPane.CurveList(0).NPts
                    Else
                        'make sure value is less than m_MaxHistBins
                        If val < 0 OrElse val > m_MaxHistBins Then
                            MsgBox("Invalid " & """" & "Number of Bars" & """" & " value:  Value must be between 0 AND " & m_MaxHistBins)
                            tboxHPNumBins.Text = zg5Histogram.GraphPane.CurveList(0).NPts
                        Else
                            If m_IsPlotCurrent_Histogram Then
                                'reset the Histogram graph
                                InitializeZedGraphPlot(zg5Histogram)
                                'zg5Histogram.GraphPane.Title.Text = "Waiting For Update ..."
                                're-plot the Histogram graph
                                btnPlot_Click(sender, e)
                            End If
                            'set that has been validated
                            m_VisEditNumbBinsValidated = True
                        End If
                    End If
                Else
                    'show error -> value MUST be numeric
                    MsgBox("Invalid " & """" & "Number of Bars" & """" & " value: Value must be Numeric.")
                    tboxHPNumBins.Text = zg5Histogram.GraphPane.CurveList(0).NPts
                End If
            End If
        End If
    End Sub

    Private Sub rbtnHPDiscreteBreakVals_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnHPDiscreteBreakVals.CheckedChanged
        'only do this if the visualize tab is already loaded
        If rbtnHPDiscreteBreakVals.Checked = True Then
            If (m_IsPlotCurrent_Histogram) Then
                'reset the Histogram graph
                InitializeZedGraphPlot(zg5Histogram)
                'zg5Histogram.GraphPane.Title.Text = "Waiting For Update ..."
                'plot the Histogram graph
                btnPlot_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub rbtnHPExactNumBins_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnHPExactNumBins.CheckedChanged
        'only do this if the visualize tab is already loaded
        If rbtnHPExactNumBins.Checked = True Then
            If (m_IsPlotCurrent_Histogram) Then
                'reset the Histogram graph
                InitializeZedGraphPlot(zg5Histogram)
                'zg5Histogram.GraphPane.Title.Text = "Waiting For Update ..."

                'plot the Histogram graph
                btnPlot_Click(sender, e)
            End If
        End If
    End Sub

#End Region

#Region " Box/Whisker Options "

    Private Sub rbtnBPMonthly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnBPMonthly.CheckedChanged
        If (m_IsPlotCurrent_BoxPlot) AndAlso (rbtnBPMonthly.Checked) Then
            '1. Reset BoxPlot
            InitializeZedGraphPlot(zg5BoxPlot)

            '2. Re-Plot Monthly BoxPlot
            btnPlot_Click(sender, e)
        End If
    End Sub

    Private Sub rbtnBPSeasonal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnBPSeasonal.CheckedChanged
        If (m_IsPlotCurrent_BoxPlot) AndAlso (rbtnBPSeasonal.Checked) Then
            '1. Reset BoxPlot
            InitializeZedGraphPlot(zg5BoxPlot)
            '2. Re-Plot Seasonal BoxPlot
            btnPlot_Click(sender, e)
        End If
    End Sub

    Private Sub rbtnBPYearly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnBPYearly.CheckedChanged
        If (m_IsPlotCurrent_BoxPlot) AndAlso (rbtnBPYearly.Checked) Then
            '1. Reset BoxPlot
            InitializeZedGraphPlot(zg5BoxPlot)
            '2. Re-Plot Yearly BoxPlot
            btnPlot_Click(sender, e)
        End If
    End Sub

    Private Sub rbtnBPOverall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnBPOverall.CheckedChanged
        If (m_IsPlotCurrent_BoxPlot) AndAlso (rbtnBPOverall.Checked) Then
            '1. Reset BoxPlot
            InitializeZedGraphPlot(zg5BoxPlot)
            '2. Re-Plot Overall BoxPlot
            btnPlot_Click(sender, e)
        End If
    End Sub

    Private Sub btnBPViewDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBPViewDesc.Click
        'shows the form that explains the markings on the Whisker Box plots
        'the inputs/outputs are standard for form events
        Dim frmBPDesc As New frmBoxPlot   'instance of the form

        'show the boxPlot form
        Me.AddOwnedForm(frmBPDesc)
        frmBPDesc.ShowDialog()
        Me.RemoveOwnedForm(frmBPDesc)
        'release resources
        frmBPDesc.Dispose()
        frmBPDesc = Nothing
    End Sub

#End Region

#End Region

#End Region

#Region " Visualize Tab: Loading Functions "

    Private Function LoadVisualizeSites() As Boolean
        'This function Loads the Sites from the Series Catalog Table into the Visualize Tab for plotting
        'Inputs:  None
        'Outputs: Boolean -> tracks if sites were successfully retrieved from the Series Catalog in the database
        Dim i As Integer 'counter
        Dim siteDT As Data.DataTable 'Datatable to hold the Sites retrieved and loaded from the Series Catalog Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Dim siteName As String 'the SiteName value retrieved from the Database -> used to add it to cboxVisSite
        Dim siteCode As String 'the SiteCode value retrieved from the Database -> used to add it to cboxVisSite
        Try
            '1. clear out any old data 
            cboxVisSite.Items.Clear()
            cboxVisSite.Text = ""

            '2. Connect to the database
            query = "SELECT DISTINCT " & db_fld_SCSiteCode & ", " & db_fld_SCSiteName & " FROM " & db_tbl_SeriesCatalog & " ORDER BY " & db_fld_SCSiteCode

            siteDT = OpenTable("VisSitesDT", query, g_CurrConnSettings)
            If (siteDT Is Nothing) OrElse siteDT.Rows.Count = 0 Then

                'release resources
                If Not (siteDT Is Nothing) Then
                    siteDT.Dispose()
                    siteDT = Nothing
                End If

                'return false -> no values were added
                Return True
            End If

            '3. get the Sites from the Series Catalog Table,load the Sites into cboxSites
            For i = 0 To siteDT.Rows.Count - 1
                If Not (siteDT.Rows(i).Item(db_fld_SCSiteCode) Is DBNull.Value) Then
                    siteCode = siteDT.Rows(i).Item(db_fld_SCSiteCode)
                Else
                    siteCode = " "
                End If
                If Not (siteDT.Rows(i).Item(db_fld_SCSiteName) Is DBNull.Value) Then
                    siteName = siteDT.Rows(i).Item(db_fld_SCSiteName)
                Else
                    siteName = " "
                End If
                cboxVisSite.Items.Add(siteCode & " - " & siteName)
            Next i

            '4. release resources
            If Not (siteDT Is Nothing) Then
                siteDT.Dispose()
                siteDT = Nothing
            End If

            Return True
        Catch ex As Exception
            ShowError("An Error occurred while loading the Sites on the Visualization Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (siteDT Is Nothing) Then
            siteDT.Dispose()
            siteDT = Nothing
        End If
        Return False
    End Function

    Private Function LoadVisualizeVariables(ByVal siteCode As String, ByVal siteName As String) As Boolean
        'This function loads the Variables for the selected Site from the Series Catalog into the Visualize Tab
        'Inputs:  siteCode -> the Code for the selected Site
        '         siteName -> the Name for the selected Site
        'Outputs: Boolean -> tracks if the Variables were successfully retrieved and loaded for the selected Site from the Series Catalog Table in the Database
        Dim i As Integer 'counter
        Dim varDT As Data.DataTable 'Datatable to hold the Variables retrieved from the Series Catalog Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Dim varName As String 'the SiteName value retrieved from the Database -> used to add it to cboxVisSite
        Dim varCode As String 'the SiteCode value retrieved from the Database -> used to add it to cboxVisSite
        Try
            '1. clear out any old data 
            cboxVisVariable.Items.Clear()
            cboxVisVariable.Text = ""

            '2. Connect to the database
            query = "SELECT DISTINCT " & db_fld_SCVarCode & ", " & db_fld_SCVarName & " FROM " & db_tbl_SeriesCatalog & " WHERE (" & db_fld_SCSiteCode & " = '" & FormatStringForQueryFromDB(siteCode) & "' AND " & db_fld_SCSiteName & " = '" & FormatStringForQueryFromDB(siteName) & "') ORDER BY " & db_fld_SCVarCode

            varDT = OpenTable("VisVarsDT", query, g_CurrConnSettings)
            If (varDT Is Nothing) OrElse varDT.Rows.Count = 0 Then

                'release resources
                If Not (varDT Is Nothing) Then
                    varDT.Dispose()
                    varDT = Nothing
                End If

                'return false -> no values were added
                Exit Try
            End If

            '3. get the Sites from the Series Catalog Table,load the Sites into cboxSites
            For i = 0 To varDT.Rows.Count - 1
                If Not (varDT.Rows(i).Item(db_fld_SCVarCode) Is DBNull.Value) Then
                    varCode = varDT.Rows(i).Item(db_fld_SCVarCode)
                Else
                    varCode = " "
                End If
                If Not (varDT.Rows(i).Item(db_fld_SCVarName) Is DBNull.Value) Then
                    varName = varDT.Rows(i).Item(db_fld_SCVarName)
                Else
                    varName = " "
                End If
                cboxVisVariable.Items.Add(varCode & " - " & varName)
            Next i

            '4. release resources
            If Not (varDT Is Nothing) Then
                varDT.Dispose()
                varDT = Nothing
            End If

            Return True
        Catch ex As Exception
            ShowError("An Error occurred while loading the Variables on the Visualization Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (varDT Is Nothing) Then
            varDT.Dispose()
            varDT = Nothing
        End If
        Return False
    End Function

    Private Function LoadVisualizeDataSeries(ByVal siteCode As String, ByVal siteName As String, ByVal varCode As String, ByVal varName As String) As Boolean
        'This function loads the Data Series for the selected Site and Variable into the Visualize Tab
        'Inputs:  siteCode -> the Code for the selected Site
        '         siteName -> the Name for the selected Site
        '         varCode -> the Code for the selected Variable
        '         varName -> the Name for the selected Variable
        'Outputs: Boolean -> Tracks if the Data Series were successfully retrieved and loaded from the Series Catalog Table in the Database
        Dim i As Integer 'counter
        Dim dataSeriesDT As Data.DataTable 'Datatable to hold the Variables retrieved from the Series Catalog Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Dim lvItem As ListViewItem 'list view item so can add the data from the database to lvVisDataSeries
        Dim varUnits As String 'the VariableUnitsName value retrieved from the database -> added to lvVisDataSeries
        Dim sampleMed As String 'the SampleMedium value retrieved from the database -> added to lvVisDataSeries
        Dim valueType As String 'the ValueType value retrieved from the database -> added to lvVisDataSeries
        Dim timeSupport As String 'the TimeSupport value retrieved from the database -> added to lvVisDataSeries
        Dim timeUnits As String 'the TimeUnitsName value retrieved from the database -> added to lvVisDataSeries
        Dim dataType As String 'the DataType value retrieved from the database -> added to lvVisDataSeries
        Dim genCategory As String 'the GeneralCategory value retrieved from the database -> added to lvVisDataSeries
        Dim beginDateLocal As DateTime 'the BeginDateTime value retrieved from the database -> added to lvVisDataSeries
        Dim endDateLocal As DateTime 'the EndDateTime value retrieved from the database -> added to lvVisDataSeries
        Dim beginDateUTC As DateTime
        Dim endDateUTC As DateTime
        Dim valueCount As Integer 'the ValueCount value retrieved from the database -> added to lvVisDataSeries
		Dim currVisIDs As clsDataSeriesIDs 'the clsVisualizeIDs item to add the current set of SiteID, VariableID values to m_VisualizeIDs
        Dim seriesID As Integer
        Dim siteID As Integer 'the SiteID value retrieved from the database -> added to lvVisDataSeries
        Dim varID As Integer 'the VariableID value retrieved from the database -> added to lvVisDataSeries
        Dim methodID As Integer
        Dim methodDesc As String
        Dim qcLevelID As Integer
        Dim sourceID As Integer
        Dim organization As String
        Dim sourceDesc As String
		Dim qcLevelCode As String
		Dim qcLevelDef As String
		Dim speciation As String
		Dim citation As String
        Try
            '1. clear out any old data 
            lvVisDataSeries.Items.Clear()
            If Not (m_VisualizeIDs Is Nothing) Then
                m_VisualizeIDs.Clear()
            Else
                m_VisualizeIDs = New System.Collections.ArrayList
            End If

            '2. Connect to the database
            query = "SELECT * FROM " & db_tbl_SeriesCatalog & " WHERE (" & db_fld_SCSiteCode & " = '" & FormatStringForQueryFromDB(siteCode) & "' AND " & db_fld_SCSiteName & " = '" & FormatStringForQueryFromDB(siteName) & "' AND " & db_fld_SCVarCode & " = '" & FormatStringForQueryFromDB(varCode) & "' AND " & db_fld_SCVarName & " = '" & FormatStringForQueryFromDB(varName) & "') ORDER BY " & db_fld_SCSiteID & ", " & db_fld_SCVarID

            dataSeriesDT = OpenTable("VisDataSeriesDT", query, g_CurrConnSettings)
            If (dataSeriesDT Is Nothing) OrElse dataSeriesDT.Rows.Count = 0 Then

                'release resources
                If Not (dataSeriesDT Is Nothing) Then
                    dataSeriesDT.Dispose()
                    dataSeriesDT = Nothing
                End If

                'return false -> no values were added
                Return True
            End If

            '3. get the Sites from the Series Catalog Table,load the Sites into cboxSites
            For i = 0 To dataSeriesDT.Rows.Count - 1
                If dataSeriesDT.Rows(i).Item(db_fld_SCSiteID) Is DBNull.Value OrElse dataSeriesDT.Rows(i).Item(db_fld_SCVarID) Is DBNull.Value Then
                    'error occurred on this site ... Figure out what to do here

                Else
                    seriesID = dataSeriesDT.Rows(i).Item(db_fld_SCSeriesID)
                    siteID = dataSeriesDT.Rows(i).Item(db_fld_SCSiteID)
                    varID = dataSeriesDT.Rows(i).Item(db_fld_SCVarID)
                    methodID = dataSeriesDT.Rows(i).Item(db_fld_SCMethodID)
                    qcLevelID = dataSeriesDT.Rows(i).Item(db_fld_SCQCLevel)
                    sourceID = dataSeriesDT.Rows(i).Item(db_fld_SCSourceID)
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCVarUnitsName) Is DBNull.Value) Then
                        varUnits = dataSeriesDT.Rows(i).Item(db_fld_SCVarUnitsName)
                    Else
                        varUnits = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCSampleMed) Is DBNull.Value) Then
                        sampleMed = dataSeriesDT.Rows(i).Item(db_fld_SCSampleMed)
                    Else
                        sampleMed = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCValueType) Is DBNull.Value) Then
                        valueType = dataSeriesDT.Rows(i).Item(db_fld_SCValueType)
                    Else
                        valueType = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCTimeSupport) Is DBNull.Value) Then
                        timeSupport = dataSeriesDT.Rows(i).Item(db_fld_SCTimeSupport)
                    Else
                        timeSupport = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCTimeUnitsName) Is DBNull.Value) Then
                        timeUnits = dataSeriesDT.Rows(i).Item(db_fld_SCTimeUnitsName)
                    Else
                        timeUnits = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCDataType) Is DBNull.Value) Then
                        dataType = dataSeriesDT.Rows(i).Item(db_fld_SCDataType)
                    Else
                        dataType = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCGenCat) Is DBNull.Value) Then
                        genCategory = dataSeriesDT.Rows(i).Item(db_fld_SCGenCat)
                    Else
                        genCategory = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCBeginDT) Is DBNull.Value) Then
                        beginDateLocal = dataSeriesDT.Rows(i).Item(db_fld_SCBeginDT)
                    Else
                        beginDateLocal = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCEndDT) Is DBNull.Value) Then
                        endDateLocal = dataSeriesDT.Rows(i).Item(db_fld_SCEndDT)
                    Else
                        endDateLocal = " "
                    End If
                    'NOTE: No longer in Database
                    '******************************************************************************
                    'If Not (dataSeriesDT.Rows(i).Item(db_fld_SCUTCOffset) Is DBNull.Value) Then
                    '    utcOffset = dataSeriesDT.Rows(i).Item(db_fld_SCUTCOffset)
                    'Else
                    '    utcOffset = db_BadID
                    'End If
                    '******************************************************************************
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCBeginDTUTC) Is DBNull.Value) Then
                        beginDateUTC = dataSeriesDT.Rows(i).Item(db_fld_SCBeginDTUTC)
                    Else
                        beginDateUTC = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCEndDTUTC) Is DBNull.Value) Then
                        endDateUTC = dataSeriesDT.Rows(i).Item(db_fld_SCEndDTUTC)
                    Else
                        endDateUTC = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCValueCount) Is DBNull.Value) Then
                        valueCount = dataSeriesDT.Rows(i).Item(db_fld_SCValueCount)
                    Else
                        valueCount = db_BadID
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCMethodDesc) Is DBNull.Value) Then
                        methodDesc = dataSeriesDT.Rows(i).Item(db_fld_SCMethodDesc)
                    Else
                        methodDesc = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCOrganization) Is DBNull.Value) Then
                        organization = dataSeriesDT.Rows(i).Item(db_fld_SCOrganization)
                    Else
                        organization = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCSourceDesc) Is DBNull.Value) Then
                        sourceDesc = dataSeriesDT.Rows(i).Item(db_fld_SCSourceDesc)
                    Else
                        sourceDesc = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCQCLCode) Is DBNull.Value) Then
                        qcLevelCode = dataSeriesDT.Rows(i).Item(db_fld_SCQCLCode)
                    Else
                        qcLevelCode = " "
                    End If
                    qcLevelDef = GetQCLevelDefinitionFromDB(qcLevelID)

                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCSpeciation) Is DBNull.Value) Then
                        speciation = dataSeriesDT.Rows(i).Item(db_fld_SCSpeciation)
                    Else
                        speciation = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCCitation) Is DBNull.Value) Then
                        citation = dataSeriesDT.Rows(i).Item(db_fld_SCCitation)
                    Else
                        citation = " "
                    End If

                    'NOTE: Colums for lvVisData Series:
                    'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description, Citation, Local Date Range, UTC Date Range, Value Count

                    'create the new listview item
                    lvItem = New ListViewItem(genCategory)

                    'add the rest of the items to lvItem
                    lvItem.SubItems.Add(speciation)
                    lvItem.SubItems.Add(varUnits)
                    lvItem.SubItems.Add(timeSupport)
                    lvItem.SubItems.Add(timeUnits)
                    lvItem.SubItems.Add(sampleMed)
                    lvItem.SubItems.Add(valueType)
                    lvItem.SubItems.Add(dataType)
                    lvItem.SubItems.Add(qcLevelCode & " - " & qcLevelDef) 'Note:  QC Level = Code - Definition
                    lvItem.SubItems.Add(methodDesc)
                    lvItem.SubItems.Add(organization)
                    lvItem.SubItems.Add(sourceDesc)
                    lvItem.SubItems.Add(citation)
                    lvItem.SubItems.Add(beginDateLocal.ToString & " - " & endDateLocal.ToString)
                    'lvItem.SubItems.Add(utcOffset)
                    lvItem.SubItems.Add(beginDateUTC.ToString & " - " & endDateUTC.ToString)
                    lvItem.SubItems.Add(valueCount)

                    'add the listview item to lvVisDataSeries
                    lvVisDataSeries.Items.Add(lvItem)

                    'add the SiteID,VarID to m_VisualizeIDs
                    currVisIDs = New clsDataSeriesIDs
                    currVisIDs.SeriesID = seriesID
                    currVisIDs.SiteID = siteID
                    currVisIDs.VariableID = varID
                    currVisIDs.MethodID = methodID
                    currVisIDs.QCLevelID = qcLevelID
                    currVisIDs.SourceID = sourceID
                    m_VisualizeIDs.Add(currVisIDs)
                End If
            Next i

            '4. adjust the column widths for values
            For i = 0 To lvVisDataSeries.Columns.Count - 1
                lvVisDataSeries.Columns(i).Width = GetVisDataSeriesColWidth(i)
            Next i
            'redraw the list view
            lvVisDataSeries.Update()

            '5. release resources
            If Not (dataSeriesDT Is Nothing) Then
                dataSeriesDT.Dispose()
                dataSeriesDT = Nothing
            End If

            Return True
        Catch ex As Exception
            ShowError("An Error occurred while loading the available Data Series on the Visualization Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (dataSeriesDT Is Nothing) Then
            dataSeriesDT.Dispose()
            dataSeriesDT = Nothing
        End If
        Return False
    End Function

    Private Function LoadVisualizeDateRange() As Boolean
        'This function Loads the Date Range for the selected Data Series
        'Inputs:  None
        'Outputs: Boolean -> Tracks if successfully loaded the Date Range for the selected Data Series -> values are in selected lvVisDataSeries item          
        Dim startDate As Date = Date.Today
        Dim endDate As Date = Date.Today
        Dim dateIndex As Integer = 13
        'NOTE: Colums for lvVisData Series:
		'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description, Citation, Local Date Range, UTC Date Range, Value Count
        Try
            '1. make sure have a valid selected item
            If lvVisDataSeries.SelectedItems.Count <= 0 Then
                'return false
                Exit Try
            End If

            '2. set that loading the date range
            m_LoadingVisDateRange = True

            '3. get the Start,End dates from the selected item
            startDate = CDate(Split(lvVisDataSeries.SelectedItems(0).SubItems(dateIndex).Text, " - ")(0))
            endDate = CDate(Split(lvVisDataSeries.SelectedItems(0).SubItems(dateIndex).Text, " - ")(1))

            '4. set the Min, Max, and Value for the StartDate item
            dtpVisStartDate.MinDate = startDate
            dtpVisStartDate.MaxDate = endDate
            dtpVisStartDate.Value = startDate

            '5. set the Min, Max, and Value for the EndDate item
            dtpVisEndDate.MinDate = startDate
            dtpVisEndDate.MaxDate = endDate
            dtpVisEndDate.Value = endDate

            '6. set that done loading the date range
            m_LoadingVisDateRange = False

            Return True
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while loading the Date Range for the selected Data Series on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Return False
    End Function

    Private Function GetVisDataSeriesColWidth(ByVal colIndex As Integer) As Integer
        Dim i As Integer 'counter
        Dim itemWidth As Integer 'the width of the current subitem -> so can correctly size of each column to fit the data
        Dim colWidth As Integer 'the width of the current column header -> so can correctly size of each column to fit the data
        Const useColHeaderWidth As Integer = -2 'resize to the column header
        Const useLargestItemWidth As Integer = -1 'resize to the largest value in the list
        Try
            '1. intialize minWidth, colWidth
            colWidth = GetStringLen(lvVisDataSeries.Columns(colIndex).Text)

            '2. loop through all of the items and get the largest item

            For i = 0 To lvVisDataSeries.Items.Count - 1
                If lvVisDataSeries.Items(i).SubItems.Count < colIndex Then
                    itemWidth = GetStringLen(lvVisDataSeries.Items(i).SubItems(colIndex).Text)
                    If itemWidth > colWidth Then
                        '3. return useLargestItemWidth -> at least one value is greater than the column header, so resize to largest item
                        Return useLargestItemWidth
                    End If
                End If
            Next i

            '3. Return useColHeaderWidth -> no values were greater than the column header width
            Return useColHeaderWidth
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while calculating the Width for the Column = " & colIndex & " in the lvVisDataSeries control on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Function

    'Private Sub LoadVisualizePlotDataFromDB(ByVal siteID As Integer, ByVal varID As Integer, ByVal startDate As Date, ByVal endDate As Date)
    Private Sub LoadVisualizePlotDataFromDB(ByVal dataSeriesIDs As clsDataSeriesIDs, ByVal startDate As Date, ByVal endDate As Date)
        '
        'Inputs:  dataSeriesIDs ->
        '         startDate -> 
        '         endDate ->
        'Outputs: None
        Dim query As String
        Dim noDataVal As Double
        Try
            '1. reset data
            m_VisPlotData = Nothing

            '2. Validate Data
            'If siteID < 0 OrElse varID < 0 OrElse startDate.ToOADate <= 0 OrElse endDate.ToOADate <= 0 Then
            If (dataSeriesIDs Is Nothing) OrElse startDate.ToOADate <= 0 OrElse endDate.ToOADate <= 0 Then
                'Exit, cannot create table -> invalid parameters
                Exit Try
            End If

            '3. create the query
            noDataVal = GetVarNoDataValueFromDB(dataSeriesIDs.VariableID)
            query = "SELECT *,Month(" & db_fld_ValDateTime & ") as " & db_outFld_ValDTMonth & ",Year(" & db_fld_ValDateTime & ") as " & db_outFld_ValDTYear & " FROM " & db_tbl_DataValues & " WHERE (" & db_fld_ValMethodID & " = " & dataSeriesIDs.MethodID & " AND " & db_fld_ValQCLevel & " = " & dataSeriesIDs.QCLevelID & " AND " & db_fld_ValSiteID & " = " & dataSeriesIDs.SiteID & " AND " & db_fld_ValVarID & " = " & dataSeriesIDs.VariableID & " AND " & db_fld_ValSourceID & " = " & dataSeriesIDs.SourceID & " AND " & db_fld_ValDateTime & " >= " & FormatDateForQueryFromDB(startDate) & " AND " & db_fld_ValDateTime & " <= " & FormatDateForQueryFromDB(endDate) & " AND " & db_fld_ValValue & " <> '" & noDataVal & "') ORDER BY " & db_fld_ValValue

            '4. Open the table
            m_VisPlotData = OpenTable("CurrentPlotData", query, g_CurrConnSettings)
            'MsgBox("DONE")
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while loading the graph data from the Database for the SiteID = " & dataSeriesIDs.SiteID & " and the VariableID = " & dataSeriesIDs.VariableID & " for the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
            'set m_VisPlotData = Nothing
            m_VisPlotData = Nothing
        End Try
    End Sub

    Private Function GetAbbreviatedVariableUnitsFromDB(ByVal units As String) As String
        '
        'Inputs:  units ->
        'Outputs: String -> 
        Dim query As String
        'Dim unitsDT As System.Data.DataTable
        Dim abrvUnits As String = ""
        Try
            '1. connect to database
            query = "SELECT " & db_fld_UnitsAbrv & " FROM " & db_tbl_Units & " WHERE " & db_fld_UnitsName & " = '" & FormatStringForQueryFromDB(units) & "' ORDER BY " & db_fld_UnitsID
            '2. get abbreviation for given units
            abrvUnits = getValue(query, g_CurrConnSettings)


            'unitsDT = OpenTable("GetAbrvUnits", query, g_CurrConnSettings)
            ''make sure have data
            'If (unitsDT Is Nothing) OrElse unitsDT.Rows.Count <= 0 Then
            '    'release resources
            '    If Not (unitsDT Is Nothing) Then
            '        unitsDT.Dispose()
            '        unitsDT = Nothing
            '    End If
            '    'return (unk) = unknown
            '    Exit Try
            'End If
            'abrvUnits = unitsDT.Rows(0).Item(db_fld_UnitsAbrv)

            ''3. release resources
            'If Not (unitsDT Is Nothing) Then
            '    unitsDT.Dispose()
            '    unitsDT = Nothing
            'End If

            '4. Return value
            Return "(" & abrvUnits & ")"
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while retrieving the Abbreviation for the Units = " & units & "." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        'If Not (unitsDT Is Nothing) Then
        '    unitsDT.Dispose()
        '    unitsDT = Nothing
        'End If
        Return "(unk)"
    End Function

#End Region

#Region " Visualize Tab: Initialize Functions "

	Private Sub SetVisPlotsCurrent(ByVal isCurrent As Boolean)
		'This function Sets the m_IsPlotCurrent_(PlotType) variables value = isCurrent
		'Inputs:  isCurrent -> the value (True or False) to set the m_IsPlotCurrent_* variables to
		'Outputs: None
		Try
			'reset the m_ISPlotCurrent_* variables
			m_IsPlotCurrent_TimeSeries = isCurrent
			m_IsPlotCurrent_Probability = isCurrent
			m_IsPlotCurrent_Histogram = isCurrent
			m_IsPlotCurrent_BoxPlot = isCurrent
		Catch ex As Exception
			'show an error message
            ShowError("An Error occurred while resetting the Plots on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

	Private Sub InitializeVisualizeTab()
		Try
			If Not m_LoadingVisualizeTab Then
				'MsgBox("Initializing Visualize Tab")

				'initialize the plots
				InitializeAllVisualizePlots()

				'intialize the summary
				ClearSummary()
				'ckboxUseCensoredData.Checked = False
				ckboxUseCensoredData.Enabled = False
				gboxStatistics.Enabled = False
			End If
		Catch ex As Exception
			'show an error message
            ShowError("An Error occurred while initializing controls on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

	Private Sub InitializeAllVisualizePlots()

		Try
			'reset/initialize the Time Series Plot only if it says it is current -> was current, changes occurred, so redrawing
			If m_IsPlotCurrent_TimeSeries Then				
                InitializeZedGraphPlot(zg5TimeSeries)
                zg5TimeSeries.GraphPane.Title.Text = "Waiting For Update ..."
				zg5TimeSeries.Refresh()
			End If
			'reset/initialize the Probability Plot only if it says it is current -> was current, changes occurred, so redrawing
			If m_IsPlotCurrent_Probability Then
				InitializeZedGraphPlot(zg5Probability)
				zg5Probability.GraphPane.Title.Text = "Waiting For Update ..."
				zg5Probability.Refresh()
			End If
			'reset/initialize the Histogram Plot only if it says it is current -> was current, changes occurred, so redrawing
			If m_IsPlotCurrent_Histogram Then
				InitializeZedGraphPlot(zg5Histogram)
				zg5Histogram.GraphPane.Title.Text = "Waiting For Update ..."
				zg5Histogram.Refresh()
			End If
			'reset/initialize the Box/Whisker Plot only if it says it is current -> was current, changes occurred, so redrawing
			If m_IsPlotCurrent_BoxPlot Then
				InitializeZedGraphPlot(zg5BoxPlot)
				zg5BoxPlot.GraphPane.Title.Text = "Waiting For Update ..."
				zg5BoxPlot.Refresh()
			End If

			'set that all plots = Not Current
			SetVisPlotsCurrent(False)
		Catch ex As Exception
			'show an error message
            ShowError("An Error occurred while Initializing all of the plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

	Private Sub InitializeVisualizeDateInfo()
		Try
			'set that loading the Date Range
			m_LoadingVisDateRange = True
			'reset Start Date
			dtpVisStartDate.MaxDate = Date.Now
			dtpVisStartDate.MinDate = Date.Today
			dtpVisStartDate.Value = Date.Today
			'reset End Date
			dtpVisEndDate.MaxDate = Date.Now
			dtpVisEndDate.MinDate = Date.Today
			dtpVisEndDate.Value = Date.Today
			'set that done loading the Date Range
			m_LoadingVisDateRange = False
		Catch ex As Exception
			'show an error message
            ShowError("An Error occurred while initializing the Date Info on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
		End Try
	End Sub

#End Region

#Region " Visualize Tab: Plot Functions "

#Region " All Plots "

    Private Sub SetVisualizePlotTitle(ByVal plotTabName As String, ByVal plotTitle As String)
        Dim gPane As New ZedGraph.GraphPane
        Dim g As Drawing.Graphics
        Try
            'set up gPane,g
            Select Case plotTabName
                Case "tabpgTimeSeries"
                    gPane = zg5TimeSeries.GraphPane
                    g = zg5TimeSeries.CreateGraphics
                Case "tabpgProbability"
                    gPane = zg5Probability.GraphPane
                    g = zg5Probability.CreateGraphics
                Case "tabpgHistogram"
                    gPane = zg5Histogram.GraphPane
                    g = zg5Histogram.CreateGraphics
                Case "tabpgBoxPlot"
                    gPane = zg5BoxPlot.GraphPane
                    g = zg5BoxPlot.CreateGraphics
                Case Else
                    g = Nothing
            End Select
            'set the title
            gPane.Title.Text = plotTitle
            'redraw the graph
            gPane.Draw(g)
            'release resources
            g.Dispose()
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while setting the Title for the Plot on the Tab = " & plotTabName & "." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub AddLabelToPlot(ByRef gpane As ZedGraph.GraphPane, ByVal label As String, ByVal xLoc As Double)
        Dim myText As ZedGraph.TextObj
        Dim myTic As ZedGraph.TextObj
        Try
            myText = New ZedGraph.TextObj(label, xLoc, 1.05, ZedGraph.CoordType.XScaleYChartFraction)
            myText.FontSpec.Size = 13
            myText.FontSpec.Border.IsVisible = False
            myText.FontSpec.Fill = New ZedGraph.Fill(Drawing.Color.FromArgb(25, Drawing.Color.White))
            gpane.GraphObjList.Add(myText)
            myTic = New ZedGraph.TextObj("|", xLoc, 0.997, ZedGraph.CoordType.XScaleYChartFraction)
            myTic.FontSpec.Size = 12.0
            myTic.FontSpec.Border.IsVisible = False
            myTic.FontSpec.Fill = New ZedGraph.Fill(Drawing.Color.FromArgb(25, Drawing.Color.White))
            gpane.GraphObjList.Add(myTic)
        Catch ex As Exception
            ShowError("An Error occurred while creating an X-Axis Label for a plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Time Series "

    'NOTE:  Line plot draws dots then line.  
    'then removes dots.  Any way to avoid drawing dots in the first place? (before redraw?)
    Private Sub PlotTimeSeries(ByVal site As String, ByVal variable As String, ByVal varUnits As String, ByVal startDate As Date, ByVal endDate As Date)
        'This function plots the Time Series graph for the selected data series
        'Inputs:  site -> Code - Name of the site to plot -> used for the title
        '         variable -> Code - Name of the variable to plot -> used for the y-axis label
        '         varUnits -> (units) of the variable abbreviated -> used for the y-axis label
        '         startDate -> Start Date of the data -> for calculating Scroll padding
        '         endDate -> End Date of the data -> for calculating Scroll padding
        'Outputs: None
        Dim i As Integer 'counter
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgTimeSeries plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zgTimeSeries plot object -> used to redraw/update the plot
        Dim ptList As ZedGraph.PointPairList 'collection of points for the Time Series line
        Dim tsCurve As ZedGraph.LineItem 'Line object -> Time Series line that is added to the plot
        Dim validRows() As Data.DataRow 'collection of valid data retrieved from m_VisPlotData -> data to plot
        Dim numRows As Integer 'number of valid rows returned
        Dim curDate As Date 'Date of the current item -> x-value for the current point
        Dim curValue As Double 'Value of the curren item -> y-value for the current point
        'Dim xScrollPad As Double 'scroll padding value for the x-axis
        Dim minX, maxX As Date
        Dim minY, maxY As Double
        Dim rangeX, rangeY As Double
        Try
            '1. set the Graph Pane, graphics object
            gPane = zg5TimeSeries.GraphPane
            'g = zg5TimeSeries.CreateGraphics

            '2. Validate Data
            If m_VisPlotData Is Nothing Then
                'If site = "" OrElse variable = "" OrElse (m_VisPlotData Is Nothing) Then
                'reset Title = No Data
                gPane.Title.Text = "No Data"
                zg5TimeSeries.Refresh()
                'release resources
                'If Not (g Is Nothing) Then
                '    g.Dispose()
                '    g = Nothing
                'End If
                'exit
                Exit Try
            End If

            '3. Let user know something is being plotted
            gPane.Title.Text = "Loading Graph ... "
            zg5TimeSeries.Refresh()

            '4. get the data 
            'get all the rows from the table with positive data

            validRows = m_VisPlotData.Select(db_fld_ValCensorCode & " <> " & db_val_ValCensorCode_lt, db_fld_ValDateTime & " ASC") 'selected rows from m_Table that censorcode <> "lt"
            numRows = validRows.GetLength(0)
            If (numRows = 0) Then
                'reset Title = No Data
                gPane.Title.Text = "No Data"
                zg5TimeSeries.Refresh()
                'release resources
                'If Not (g Is Nothing) Then
                '    g.Dispose()
                '    g = Nothing
                'End If
                'exit
                Exit Try
            End If

            '5. set Graph Properties
            If gPane.IsZoomed() = True Then
                zg5TimeSeries.ZoomOutAll(gPane)
            End If
            'x-axis
            minX = m_VisPlotData.Compute("MIN(" & db_fld_ValDateTime & ")", db_fld_ValCensorCode & " <> " & db_val_ValCensorCode_lt)
            maxX = m_VisPlotData.Compute("MAX(" & db_fld_ValDateTime & ")", db_fld_ValCensorCode & " <> " & db_val_ValCensorCode_lt)
            rangeX = maxX.ToOADate - minX.ToOADate
            gPane.XAxis.IsVisible = True
            gPane.XAxis.MajorGrid.IsVisible = True
            gPane.XAxis.MajorGrid.Color = Drawing.Color.Gray
            gPane.XAxis.Type = ZedGraph.AxisType.Date
            gPane.XAxis.Title.Text = "Date"
            gPane.XAxis.Scale.Min = minX.ToOADate - (m_XBorder * rangeX)
            gPane.XAxis.Scale.Max = maxX.ToOADate + (m_XBorder * rangeX)
            gPane.XAxis.Scale.FormatAuto = True
            gPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Month
            gPane.XAxis.Scale.MinorUnit = ZedGraph.DateUnit.Hour
            'y-axis
            minY = m_VisPlotData.Compute("MIN(" & db_fld_ValValue & ")", db_fld_ValCensorCode & " <> " & db_val_ValCensorCode_lt)
            maxY = m_VisPlotData.Compute("MAX(" & db_fld_ValValue & ")", db_fld_ValCensorCode & " <> " & db_val_ValCensorCode_lt)
            rangeY = maxY - minY
            gPane.YAxis.IsVisible = True
            gPane.YAxis.MajorGrid.IsVisible = True
            gPane.YAxis.MajorGrid.Color = Drawing.Color.Gray
            gPane.YAxis.Type = ZedGraph.AxisType.Linear
            gPane.YAxis.Title.Text = variable & "   " & varUnits
            gPane.YAxis.Scale.Min = minY - (m_YBorder * rangeY)
            gPane.YAxis.Scale.Max = maxY + (m_YBorder * rangeY)

            'Title
            While (GetStringLen(site, gPane.Title.FontSpec.GetFont(gPane.CalcScaleFactor)) > zg5TimeSeries.Width)
                site = GraphTitleBreaks(site)
            End While

            gPane.Title.Text = site


            '6. Create the Pts for the Line
            ptList = New ZedGraph.PointPairList
            For i = 0 To numRows - 1
                curDate = validRows(i).Item(db_fld_ValDateTime)
                curValue = validRows(i).Item(db_fld_ValValue)
                ptList.Add(curDate.ToOADate, curValue)
            Next i

            '7. Plot the Data
            'create the curve
            tsCurve = New ZedGraph.LineItem("ts")
            Select Case True
                Case rbtnTSLine.Checked
                    tsCurve = gPane.AddCurve("ts", ptList, Drawing.Color.Black, ZedGraph.SymbolType.None)
                Case rbtnTSPoint.Checked
                    tsCurve = gPane.AddCurve("ts", ptList, Drawing.Color.Black, ZedGraph.SymbolType.Circle)
                    tsCurve.Line.IsVisible = False
                    tsCurve.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Black)
                    tsCurve.Symbol.Size = 4
                Case rbtnTSBoth.Checked
                    tsCurve = gPane.AddCurve("ts", ptList, Drawing.Color.Black, ZedGraph.SymbolType.Circle)
                    tsCurve.Line.IsVisible = True
                    tsCurve.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Black)
                    tsCurve.Symbol.Size = 4
            End Select

            'set up scrolling
            'xScrollPad = 0.025 * (endDate.ToOADate - startDate.ToOADate)
            'zg5TimeSeries.IsAutoScrollRange = False
            zg5TimeSeries.ScrollMinX = minX.ToOADate - (0.025 * rangeX) '(startDate.ToOADate) - xScrollPad
            zg5TimeSeries.ScrollMaxX = maxX.ToOADate + (0.025 * rangeX) '(endDate.ToOADate) + xScrollPad
            zg5TimeSeries.ScrollMinY = minY - (0.1 * rangeY) '0.975 * CDbl(tboxMin.Text)
            zg5TimeSeries.ScrollMaxY = maxY + (0.1 * rangeY) '1.025 * CDbl(tboxMax.Text)
            'draw the plot
            zg5TimeSeries.AxisChange()
            zg5TimeSeries.Refresh()

            '8. release resources
            'If Not (g Is Nothing) Then
            '    g.Dispose()
            '    g = Nothing
            'End If
            If Not (ptList Is Nothing) Then
                ptList = Nothing
            End If
            If Not (tsCurve Is Nothing) Then
                tsCurve = Nothing
            End If
            If Not (validRows Is Nothing) Then
                validRows = Nothing
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while graphing the Time Series Plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Probability "

    Private Sub PlotProbability(ByVal site As String, ByVal variable As String, ByVal varUnits As String)
        Dim i As Integer 'counter
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgProbability plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zgProbability plot object -> used to redraw/update the plot
        Dim ptList As ZedGraph.PointPairList 'collection of points for the Probability plot
        Dim bflPtList As ZedGraph.PointPairList
        Dim probLine As ZedGraph.LineItem
        Dim bflLine As ZedGraph.LineItem
        Dim validRows() As Data.DataRow
        Dim numRows As Integer
        Dim curValue As Double
        Dim curX As Double
        Dim curFreq As Double
        Try
            '1. Set the Graph Pane, graphics object
            gPane = zg5Probability.GraphPane
            'g = zg5Probability.CreateGraphics

            '2. Validate data
            If m_VisPlotData Is Nothing Then
                'reset Title = No Data
                gPane.Title.Text = "No Data"
                zg5Probability.Refresh()
                'release resources
                'If Not (g Is Nothing) Then
                '	g.Dispose()
                '	g = Nothing
                'End If

                'exit
                Exit Try
            End If

            '3. let user know something is being plotted
            gPane.Title.Text = "Loading Graph..."
            zg5Probability.Refresh()

            '4.get the data
            ''get all the rows from the table that are not censored, order by Value
            'validRows = m_VisPlotData.Select(db_fld_ValCensorCode & " <> " & db_val_valCensorCode_lt, db_fld_ValValue & " ASC") 'selected rows from m_VisPlotData that have censorcode <> "lt"

            'get all data(even censored ones), order by Value
            validRows = m_VisPlotData.Select("", db_fld_ValValue & " ASC")
            numRows = validRows.GetLength(0)
            'make sure data was selected
            If (numRows = 0) Then
                'reset Title = No Data
                gPane.Title.Text = "No Data"
                zg5Probability.Refresh()
                'release resources
                'If Not (g Is Nothing) Then
                '	g.Dispose()
                '	g = Nothing
                'End If
                'exit
                Exit Try
            End If

            '5. Set Graph Properties
            If gPane.IsZoomed() = True Then
                zg5Probability.ZoomOutAll(gPane)
            End If
            'x-axis
            gPane.XAxis.IsVisible = True
            gPane.XAxis.MajorTic.Size = 0
            gPane.XAxis.MinorTic.Size = 0
            gPane.XAxis.Title.Text = vbCrLf & vbCrLf & "Cumulative Frequency < Stated Value %"
            gPane.XAxis.Title.Gap = 0.2
            gPane.XAxis.Type = ZedGraph.AxisType.Linear
            gPane.XAxis.Scale.IsVisible = False
            gPane.XAxis.Scale.Min = -4.0
            gPane.XAxis.Scale.Max = 4.0
            gPane.XAxis.MajorTic.IsAllTics = False
            gPane.XAxis.Scale.MinGrace = 0
            gPane.XAxis.Scale.MaxGrace = 0
            'y-axis
            gPane.YAxis.IsVisible = True
            gPane.YAxis.MajorGrid.IsVisible = True
            gPane.YAxis.MajorGrid.Color = Drawing.Color.Gray
            gPane.YAxis.Title.Text = variable & "  " & varUnits
            gPane.YAxis.Type = ZedGraph.AxisType.Linear
            gPane.YAxis.Scale.MinGrace = 0.025
            gPane.YAxis.Scale.MaxGrace = 0.025
            'Title
            While (GetStringLen(site, gPane.Title.FontSpec.GetFont(gPane.CalcScaleFactor)) > zg5TimeSeries.Width)
                site = GraphTitleBreaks(site)
            End While

            gPane.Title.Text = site

            '6. Create the Pts for the Line
            ptList = New ZedGraph.PointPairList

            'Dim ptListF As New ZedGraph.PointPairList
            For i = 0 To numRows - 1
                'get the y component
                curValue = validRows(i).Item(db_fld_ValValue)
                'curX = CalculateProbabilityXPosition(i / numRows)
                curFreq = CalculateProbabilityFreq(i + 1, numRows)
                curX = CalculateProbabilityXPosition(curFreq)
                'NOTE: use i+1 so rank = 1 -> N

                'plot the point
                If curValue >= 0 Then
                    ptList.Add(curX, curValue, "(" & curFreq * 100 & ", " & curValue & ")")
                End If
            Next i

            '7. Plot the Data
            'create the points
            probLine = New ZedGraph.LineItem("ProbCurve")
            probLine = gPane.AddCurve("ProbPts", ptList, Drawing.Color.Black, ZedGraph.SymbolType.Circle)
            probLine.Line.IsVisible = False
            probLine.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Black)
            probLine.Symbol.Size = 4


            '8. set up Tic Marks

            For i = 0 To 20
                AddLabelToPlot(gPane, GetProbabilityLabel(i), GetProbabilityValue(i))
            Next i

            'set up scrolling 
            zg5Probability.IsAutoScrollRange = False
            zg5Probability.ScrollMinX = -4.0
            zg5Probability.ScrollMaxX = 4.0
            zg5Probability.ScrollMinY = 0
            zg5Probability.ScrollMaxY = 1.025 * CDbl(tboxMax.Text)
            'draw the plot
            zg5Probability.AxisChange()
            zg5Probability.Refresh()

            '9. Release resources
            If Not (ptList Is Nothing) Then
                ptList = Nothing
            End If
            If Not (bflPtList Is Nothing) Then
                bflPtList = Nothing
            End If
            If Not (probLine Is Nothing) Then
                probLine = Nothing
            End If
            If Not (bflLine Is Nothing) Then
                bflLine = Nothing
            End If
            If Not (validRows Is Nothing) Then
                validRows = Nothing
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while graphing the Probability Plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Function CalculateProbabilityXPosition(ByVal freq As Double) As Double
        'Calculates the position along the x-axis to place the dot -> only used on the Probability Plot
        'Based on a normal curve distribution, Code is from Dr. Stevens
        'Inputs:  freq -> used to calculate the position so has a normal distribution look -> (i/numrows)
        'Outputs: Double -> the x-position to plot the point at
        Try
            Return Math.Round(4.91 * (freq ^ 0.14 - (1.0# - freq) ^ 0.14), 3)
        Catch ex As System.Exception
            ShowError("An Error occurred while calculating the X-Position for a point in the Probability Plot." & vbCrLf & "Message= " & ex.Message, ex)
        End Try
    End Function

    Private Function CalculateProbabilityFreq(ByVal rank As Integer, ByVal numRows As Integer) As Double
        Try
            Return Math.Round((rank - 0.375) / (numRows + 1 - 2 * (0.375)), 3)
        Catch ex As Exception

        End Try
    End Function

    Private Function CreateProbabilityXAxisLabels(ByVal pane As ZedGraph.GraphPane, ByVal axis As ZedGraph.Axis, ByVal val As Double, ByVal index As Integer) As String
        Try
            'pane.XAxis.IsVisible = True
            'Select Case val
            '	Case -3.892
            '		Return "0.01"
            '	Case -3.5
            '		Return "0.02"
            '	Case -3.095
            '		Return "0.1"
            '	Case -2.323
            '		Return "1"
            '	Case -2.055
            '		Return "2"
            '	Case -1.645
            '		Return "5"
            '	Case -1.282
            '		Return "10"
            '	Case -0.842
            '		Return "20"
            '	Case -0.524
            '		Return "30"
            '	Case -0.254
            '		Return "40"
            '	Case 0
            '		Return "50"
            '	Case 0.254
            '		Return "60"
            '	Case 0.524
            '		Return "70"
            '	Case 0.842
            '		Return "80"
            '	Case 1.282
            '		Return "90"
            '	Case 1.645
            '		Return "95"
            '	Case 2.055
            '		Return "98"
            '	Case 2.323
            '		Return "99"
            '	Case 3.095
            '		Return "99.9"
            '	Case 3.5
            '		Return "99.98"
            '	Case 3.892
            '		Return "99.99"
            '	Case Else
            '		Return ""
            'End Select
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetProbabilityLabel(ByVal index As Integer) As String
        Select Case index
            Case 0
                Return "0.01"
            Case 1
                Return "0.02"
            Case 2
                Return "0.1"
            Case 3
                Return "1"
            Case 4
                Return "2"
            Case 5
                Return "5"
            Case 6
                Return "10"
            Case 7
                Return "20"
            Case 8
                Return "30"
            Case 9
                Return "40"
            Case 10
                Return "50"
            Case 11
                Return "60"
            Case 12
                Return "70"
            Case 13
                Return "80"
            Case 14
                Return "90"
            Case 15
                Return "95"
            Case 16
                Return "98"
            Case 17
                Return "99"
            Case 18
                Return "99.9"
            Case 19
                Return "99.98"
            Case 20
                Return "99.99"
            Case Else
                Return ""
        End Select
    End Function

    Private Function GetProbabilityValue(ByVal index As Integer) As Double
        Select Case index
            Case 0
                Return -3.892
            Case 1
                Return -3.5
            Case 2
                Return -3.095
            Case 3
                Return -2.323
            Case 4
                Return -2.055
            Case 5
                Return -1.645
            Case 6
                Return -1.282
            Case 7
                Return -0.842
            Case 8
                Return -0.542
            Case 9
                Return -0.254
            Case 10
                Return 0
            Case 11
                Return 0.254
            Case 12
                Return 0.524
            Case 13
                Return 0.842
            Case 14
                Return 1.282
            Case 15
                Return 1.645
            Case 16
                Return 2.055
            Case 17
                Return 2.323
            Case 18
                Return 3.095
            Case 19
                Return 3.5
            Case 20
                Return 3.892
            Case Else
                Return ""
        End Select
    End Function

#End Region

#Region " Histogram "

    Private Sub PlotHistogram(ByVal site As String, ByVal variable As String, ByVal varUnits As String)
        '
        'Inputs: site -> Code -> Name of the site to plot -> used for the title
        '        variable -> Code - Name of the variable to plot -> used for the x-axis label
        '        varUnits -> (units) of the variable abbreviated -> used for the x-axis label
        'Outputs: None
        Dim i As Integer 'counter
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zg5Histogram plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zg5Histogram plot object -> used to redraw/update the plot
        Dim ptList As ZedGraph.PointPairList 'collection of points fro the Histogram chart
        Dim histBars As ZedGraph.BarItem 'Bar Item curve -> Histogram bars on the plot
        'Dim validRows() As Data.DataRow 'collection of valid data retrieved from m_VisPlotData -> data to plot
        Dim numValid As Integer 'number of valid rows returned
        Dim numBins As Integer 'number of bars in the bar chart
        Dim minValue As Double 'lowest valid value
        Dim maxValue As Double 'highest valid value
        Dim xRange As Double 'range of Values with padding
        Dim dX As Double 'distance between bins
        'Dim count As Integer
        Dim totalCount As Integer
        Dim maxTotal As Integer
        Dim lastValue As Double
        'Dim curValue As Double
        Dim xValue As Double
        Dim nextXValue As Double
        Try
            '1. set the Graph Pane, graphics object
            gPane = zg5Histogram.GraphPane
            'g = zg5Histogram.CreateGraphics

            '2. Validate Data
            If site = "" OrElse variable = "" OrElse (m_VisPlotData Is Nothing) Then
                'reset Title = No Data
                gPane.Title.Text = "No Data"
                zg5Histogram.Refresh()
                'release resources
                'If Not (g Is Nothing) Then
                '	g.Dispose()
                '	g = Nothing
                'End If
                'exit
                Exit Try
            End If

            '3. Let user know something is being plotted
            gPane.Title.Text = "Loading Graph ..."
            zg5Histogram.Refresh()

            '4. Get the data
            ''get all the rows from the table with positive data, order by Value
            'validRows = m_VisPlotData.Select(db_fld_ValCensorCode & " <> " & db_val_valCensorCode_lt, db_fld_ValValue & " ASC") 'selected rows from m_VisPlotData that have censor code <> "lt"
            'Select all data, order by value
            'validRows = m_VisPlotData.Select("", db_fld_ValValue & " ASC") 'selected rows from m_VisPlotData that have censor code <> "lt"
            'numValid = validRows.GetLength(0)
            'If (numValid = 0) Then
            '    'reset Title = No Data
            '    gPane.Title.Text = "No Data"
            '    gPane.Draw(g)
            '    'release resources
            '    If Not (g Is Nothing) Then
            '        g.Dispose()
            '        g = Nothing
            '    End If
            '    'exit
            '    Exit Try
            'End If

            '5. Set Graph Properties
            If gPane.IsZoomed() = True Then
                zg5Histogram.ZoomOutAll(gPane)
            End If
            'x-axis
            gPane.XAxis.IsVisible = True
            gPane.XAxis.MajorGrid.IsVisible = True
            gPane.XAxis.MajorGrid.Color = Color.Gray
            gPane.XAxis.MajorTic.Size = 0
            gPane.XAxis.MinorTic.Size = 0
            gPane.XAxis.Type = ZedGraph.AxisType.Linear
            'gPane.XAxis.Title.Text = variable & "  " & varUnits
            gPane.XAxis.Title.Text = vbCrLf & vbCrLf & variable & "  " & varUnits
            gPane.XAxis.Title.Gap = 0.2
            gPane.XAxis.Scale.IsVisible = False
            'gPane.XAxis.Scale.IsSkipFirstLabel = True
            'gPane.XAxis.Scale.IsSkipLastLabel = True
            gPane.XAxis.Scale.MinGrace = 0.025 '2.5% padding on front
            gPane.XAxis.Scale.MaxGrace = 0.025 '2.5% padding on back
            gPane.XAxis.Scale.Mag = 0
            'y-axis
            gPane.YAxis.IsVisible = True
            gPane.YAxis.MajorGrid.IsVisible = True
            gPane.YAxis.MajorGrid.Color = Color.Gray
            'gPane.YAxis.Type = ZedGraph.AxisType.Linear
            gPane.YAxis.Title.Text = "Number of Observations"
            gPane.YAxis.Scale.MinGrace = 0.025 '2.5% padding on front
            gPane.YAxis.Scale.MaxGrace = 0.025 '2.5% padding on back
            'Title
            While (GetStringLen(site, gPane.Title.FontSpec.GetFont(gPane.CalcScaleFactor)) > zg5TimeSeries.Width)
                site = GraphTitleBreaks(site)
            End While

            gPane.Title.Text = site

            '6. Create the Pts for the Bars
            'set min,max,range values
            'minValue = Math.Floor(0.99 * CDbl(validRows(0).Item(db_fld_ValValue)))
            'maxValue = Math.Ceiling(1.01 * CDbl(validRows(numValid - 1).Item(db_fld_ValValue)))
            minValue = Math.Floor(0.975 * CDbl(m_VisPlotData.Compute("Min(" & db_fld_ValValue & ")", "")))
            maxValue = Math.Floor(1.025 * CDbl(m_VisPlotData.Compute("Max(" & db_fld_ValValue & ")", "")))
            numValid = m_VisPlotData.Rows.Count

            xRange = Math.Round(maxValue - minValue, 3)
            'get the number of bins -> bars, tic marks
            If ckboxHistSetNumBins.Checked Then
                'get the number of bins specified
                numBins = CInt(tboxHPNumBins.Text)
                'Figure out if modifying dX for discrete values or not
                Select Case True
                    Case rbtnHPDiscreteBreakVals.Checked
                        'adjust for discrete values (whole numbers)
                        'calculate DX
                        dX = Math.Round(xRange / (numBins), 3)
                        'modify dX so is a discreet value (a whole number) value -> modified dX will always be smaller than calculated to ensure the correct number of bins!
                        If dX > Math.Floor(dX) + 0.5 Then
                            dX = Math.Ceiling(dX)
                        Else
                            dX = Math.Floor(dX)
                        End If
                        'Do a check if dx = 0, make it minimum of 1
                        If dX <= 0 Then
                            MsgBox("Unable to Calculate the Histogram Plot with the #Bins specified:  The #Bins specified is larger than the Maximum #Bins that can be created with Discrete Break Values." & vbCrLf & "Please select the " & """" & "Allow Decimal Break Values" & """" & " option on the Plot Options tab to have a larger #Bins." & vbCrLf & vbCrLf & "NOTE: The #Bins shown is the Maximum number that can be created with Discrete Break Values.")
                            dX = 1
                        End If
                    Case rbtnHPExactNumBins.Checked
                        'do exact number of bins specified
                        dX = Math.Round(xRange / (numBins), 3)
                End Select
            Else
                'figure out for self
                numBins = CalculateHistogramNumBins(numValid)
                If numBins > m_MaxHistBins Then
                    numBins = m_MaxHistBins
                End If
                'dx = range/(#bins - 1)
                dX = Math.Round(xRange / (numBins), 3)
                'modify dX so is a discreet value (a whole number) value -> modified dX will always be smaller than calculated to ensure the correct number of bins!
                If dX > Math.Floor(dX) + 0.5 Then
                    dX = Math.Ceiling(dX)
                Else
                    dX = Math.Floor(dX)
                End If
                'Do a check if dx = 0, make it minimum of 1
                If dX <= 0 Then
                    dX = 1
                End If
            End If

            'get the count of values for each value, add it to ptList
            ptList = New ZedGraph.PointPairList
            lastValue = 0
            xValue = minValue
            nextXValue = Math.Round(xValue + dX, 3)
            totalCount = 0
            maxTotal = 0
            For i = 0 To numBins - 1
                If xValue <= maxValue Then
                    '1. get the count of values in range
                    totalCount = m_VisPlotData.Compute("Count(" & db_fld_ValValue & ")", "(" & db_fld_ValValue & " >= " & xValue & " AND " & db_fld_ValValue & " < " & nextXValue & ")")
                    '2. add the point to the list
                    ptList.Add(Math.Round(xValue + (dX / 2), 3), totalCount, xValue & " - " & nextXValue)
                    '3. create the tic mark,lable
                    AddLabelToPlot(gPane, xValue.ToString, xValue)
                    '4. see if totalCount > maxTotal
                    If totalCount > maxTotal Then
                        maxTotal = totalCount
                    End If
                    '5. calculate next xValue,nextXValue
                    xValue = nextXValue
                    nextXValue = Math.Round(xValue + dX, 3)
                End If
            Next i

            'make sure that the last point,lables are added
            'If totalCount > maxTotal Then
            '    maxTotal = totalCount
            'End If
            'ptList.Add(xValue, totalCount)
            'ptList.Add(Math.Round(xValue + (dX / 2), 3), totalCount, xValue & " - " & nextXValue)
            AddLabelToPlot(gPane, xValue.ToString, xValue)
            'AddLabelToPlot(gPane, nextXValue.ToString, nextXValue)
            'set the number of bins created in PlotOptions tab
            tboxHPNumBins.Text = ptList.Count

            '7. Plot the Data
            'create the bars
            histBars = gPane.AddBar("histogram", ptList, Color.Black)
            'set bar settings
            gPane.BarSettings.Type = ZedGraph.BarType.Cluster
            gPane.BarSettings.MinBarGap = 0
            gPane.BarSettings.MinClusterGap = 0
            gPane.XAxis.Scale.IsLabelsInside = False

            'set the cluster = dx
            'gPane.BarSettings.ClusterScaleWidth = dX

            '9. set up scrolling
            zg5Histogram.ScrollMinX = 0.975 * minValue
            zg5Histogram.ScrollMaxX = 1.025 * maxValue
            zg5Histogram.ScrollMinY = 0
            zg5Histogram.ScrollMaxY = 1.025 * maxTotal
            'draw the plot
            zg5Histogram.AxisChange()
            zg5Histogram.Refresh()

            '10. release resources
            'If Not (g Is Nothing) Then
            '	g.Dispose()
            '	g = Nothing
            'End If
            If Not (ptList Is Nothing) Then
                ptList = Nothing
            End If
            If Not (histBars Is Nothing) Then
                histBars = Nothing
            End If
            'If Not (validRows Is Nothing) Then
            '    validRows = Nothing
            'End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while graphing the Histogram Plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    'Private Sub PlotHistogram2(ByVal site As String, ByVal variable As String, ByVal varUnits As String)
    '    '
    '    'Inputs: site -> Code -> Name of the site to plot -> used for the title
    '    '        variable -> Code - Name of the variable to plot -> used for the x-axis label
    '    '        varUnits -> (units) of the variable abbreviated -> used for the x-axis label
    '    'Outputs: None
    '    Dim i As Integer 'counter
    '    Dim gPane As ZedGraph.GraphPane 'GraphPane of the zg5Histogram plot object -> used to set data and characteristics
    '    'Dim g As Drawing.Graphics 'graphics object of the zg5Histogram plot object -> used to redraw/update the plot
    '    Dim ptList As ZedGraph.PointPairList 'collection of points fro the Histogram chart
    '    Dim histBars As ZedGraph.BarItem 'Bar Item curve -> Histogram bars on the plot
    '    Dim validRows() As Data.DataRow 'collection of valid data retrieved from m_VisPlotData -> data to plot
    '    Dim numValid As Integer 'number of valid rows returned
    '    Dim numBins As Integer 'number of bars in the bar chart
    '    Dim minValue As Double 'lowest valid value
    '    Dim maxValue As Double 'highest valid value
    '    Dim xRange As Double 'range of Values with padding
    '    Dim dX As Double 'distance between bins
    '    Dim count As Integer
    '    Dim totalCount As Integer
    '    Dim maxTotal As Integer
    '    Dim lastValue As Double
    '    Dim curValue As Double
    '    Dim xValue As Double
    '    Dim nextXValue As Double
    '    Try
    '        'TODO: Michelle: Remove the message box -> for testing only!!
    '        'MsgBox("Graphing the Histogram Plot")

    '        'TODO: Michelle: 
    '        '1. set the Graph Pane, graphics object
    '        gPane = zg5Histogram.GraphPane
    '        g = zg5Histogram.CreateGraphics

    '        '2. Validate Data
    '        If site = "" OrElse variable = "" OrElse (m_VisPlotData Is Nothing) Then
    '            'reset Title = No Data
    '            gPane.Title.Text = "No Data"
    '            gPane.Draw(g)
    '            'release resources
    '            If Not (g Is Nothing) Then
    '                g.Dispose()
    '                g = Nothing
    '            End If
    '            'exit
    '            Exit Try
    '        End If

    '        '3. Let user know something is being plotted
    '        gPane.Title.Text = "Loading Graph ..."
    '        gPane.Draw(g)

    '        '4. Get the data
    '        'get all the rows from the table with positive data, order by Value
    '        validRows = m_VisPlotData.Select(db_fld_ValValue & " > 0", db_fld_ValValue & " ASC") 'selected rows from m_VisPlotData that have positive values
    '        numValid = validRows.GetLength(0)
    '        If (numValid = 0) Then
    '            'reset Title = No Data
    '            gPane.Title.Text = "No Data"
    '            gPane.Draw(g)
    '            'release resources
    '            If Not (g Is Nothing) Then
    '                g.Dispose()
    '                g = Nothing
    '            End If
    '            'exit
    '            Exit Try
    '        End If

    '        '5. Set Graph Properties
    '        'x-axis
    '        gPane.XAxis.IsVisible = True
    '        gPane.XAxis.MajorGrid.IsVisible = True
    '        gPane.XAxis.MajorGrid.Color = Color.Gray
    '        gPane.XAxis.Type = ZedGraph.AxisType.Text
    '        gPane.XAxis.Title.Text = variable & "  " & varUnits
    '        'gPane.XAxis.Title.Text = vbCrLf & vbCrLf & variable & "  " & varUnits
    '        'gPane.XAxis.Title.Gap = 0.2
    '        gPane.XAxis.Scale.IsVisible = True
    '        'gPane.XAxis.Scale.IsSkipFirstLabel = True
    '        'gPane.XAxis.Scale.IsSkipLastLabel = True
    '        gPane.XAxis.Scale.MinGrace = 0.025 '2.5% padding on front
    '        gPane.XAxis.Scale.MaxGrace = 0.025 '2.5% padding on back
    '        gPane.XAxis.Scale.Mag = 0
    '        'y-axis
    '        gPane.YAxis.IsVisible = True
    '        gPane.YAxis.MajorGrid.IsVisible = True
    '        gPane.YAxis.MajorGrid.Color = Color.Gray
    '        'gPane.YAxis.Type = ZedGraph.AxisType.Linear
    '        gPane.YAxis.Title.Text = "Number of Observations"
    '        gPane.YAxis.Scale.MinGrace = 0.025 '2.5% padding on front
    '        gPane.YAxis.Scale.MaxGrace = 0.025 '2.5% padding on back
    '        'Title
    '        gPane.Title.Text = site

    '        '6. Create the Pts for the Bars
    '        'get the number of bins -> bars, tic marks
    '        minValue = Math.Floor(CDbl(validRows(0).Item(db_fld_ValValue)))
    '        maxValue = Math.Ceiling(CDbl(validRows(numValid - 1).Item(db_fld_ValValue)))
    '        numBins = CalculateHistogramNumBins(numValid)
    '        'dx = range/(#bins - 1)
    '        xRange = Math.Round(maxValue - minValue, 3)
    '        dX = Math.Round(xRange / (numBins), 3)
    '        'modify dX so is a discreet value (a whole number) value -> modified dX will always be smaller than calculated to ensure the correct number of bins!
    '        If dX > Math.Floor(dX) + 0.5 Then
    '            dX = Math.Ceiling(dX)
    '        Else
    '            dX = Math.Floor(dX)
    '        End If
    '        'get the count of values for each value, add it to ptList
    '        ptList = New ZedGraph.PointPairList
    '        'TODO: Michelle: : Manually manage total Count for each Bin!!'
    '        lastValue = 0
    '        xValue = minValue
    '        nextXValue = Math.Round(xValue + dX, 3)
    '        totalCount = 0
    '        maxTotal = 0
    '        Dim textLabels As String()
    '        ReDim textLabels(numBins)
    '        Dim curLabel As Integer = 0
    '        For i = 0 To numValid - 1
    '            curValue = validRows(i).Item(db_fld_ValValue)
    '            If i = 0 OrElse lastValue <> curValue Then
    '                If curValue >= nextXValue Then
    '                    'add the point
    '                    'ptList.Add(xValue, totalCount)
    '                    ptList.Add(Math.Round(xValue + (dX / 2), 3), totalCount, xValue & " - " & nextXValue)
    '                    'create the tic mark,label
    '                    AddLabelToPlot(gPane, xValue.ToString, xValue)
    '                    If totalCount > maxTotal Then
    '                        maxTotal = totalCount
    '                    End If
    '                    totalCount = 0
    '                    TextLabels(curLabel) = xValue
    '                    curLabel += 1
    '                    xValue = nextXValue
    '                    nextXValue = Math.Round(xValue + dX, 3)
    '                End If
    '                count = m_VisPlotData.Compute("Count(" & db_fld_ValValue & ")", db_fld_ValValue & " = " & curValue)
    '                totalCount += count
    '                lastValue = curValue
    '                i += count - 1
    '            End If
    '        Next i
    '        'make sure that the last point,lables are added
    '        If totalCount > maxTotal Then
    '            maxTotal = totalCount
    '        End If
    '        'ptList.Add(xValue, totalCount)
    '        'ptList.Add(nextXValue, 0)
    '        ptList.Add(Math.Round(xValue + (dX / 2), 3), totalCount, xValue & " - " & nextXValue)
    '        ptList.Add(Math.Round(nextXValue + (dX / 2), 3), 0, " ")
    '        TextLabels(numBins - 1) = xValue
    '        TextLabels(numBins - 0) = nextXValue
    '        'AddLabelToPlot(gPane, xValue.ToString, xValue)
    '        'AddLabelToPlot(gPane, nextXValue.ToString, nextXValue)

    '        '7. Plot the Data
    '        'create the bars
    '        histBars = gPane.AddBar("histogram", ptList, Color.Black)
    '        histBars.IsOverrideOrdinal = True
    '        'set bar settings
    '        gPane.BarSettings.Type = ZedGraph.BarType.Overlay
    '        gPane.XAxis.Scale.TextLabels = TextLabels
    '        gPane.BarSettings.MinBarGap = 0
    '        gPane.BarSettings.MinClusterGap = 0
    '        'gPane.XAxis.Scale.IsLabelsInside = False

    '        'set the cluster = dx
    '        gPane.BarSettings.ClusterScaleWidth = dX

    '        '9. set up scrolling
    '        zg5Histogram.ScrollMinX = 1.025 * minValue
    '        zg5Histogram.ScrollMaxX = 1.025 * maxValue
    '        zg5Histogram.ScrollMinY = 0
    '        zg5Histogram.ScrollMaxY = 1.025 * maxTotal
    '        'draw the plot
    '        zg5Histogram.AxisChange()
    '        gPane.Draw(g)

    '        '10. release resources
    '        If Not (g Is Nothing) Then
    '            g.Dispose()
    '            g = Nothing
    '        End If
    '        If Not (ptList Is Nothing) Then
    '            ptList = Nothing
    '        End If
    '        If Not (histBars Is Nothing) Then
    '            histBars = Nothing
    '        End If
    '        If Not (validRows Is Nothing) Then
    '            validRows = Nothing
    '        End If
    '    Catch ex As Exception
    '        'show an error message
    '        ShowError("An Error occurred while graphing the Histogram Plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
    '    End Try
    'End Sub

    Private Function CalculateHistogramNumBins(ByVal numValues As Double) As Integer
        'this function calculates the number of Bins -> Bars for the Histogram Chart on the Visualize Tab
        'Inputs:  numValues -> the total number of valid values
        'Outputs: Integer -> the number of bins needed
        Dim numBins As Integer = 0
        Dim top As Double 'top half of the equation
        Dim bottom As Double 'bottom half of the equation
        '#bins = ((2.303*squareRoot(n))/(natural log(n)))*(2)

        Try
            top = 2.303 * Math.Sqrt(numValues)
            bottom = Math.Log(numValues)
            numBins = Math.Floor((top / bottom) * 2)

            Return numBins
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Number Bars for the Histogram Plot on the Visualize Tab." & vbCrLf & "Message= " & ex.Message, ex)
            numBins = 0
        End Try
        Return numBins
    End Function

#End Region

#Region " Box/Whisker "

    Private Sub PlotBoxPlot(ByVal site As String, ByVal variable As String, ByVal varUnits As String)
        'This function plots the Box/Whisker Plot for the selected data set
        'Inputs:  site -> the site to plot the data for -> used for the Title of the plot
        '         variable -> the variable to plot -> used for the y-Axis title of the plot
        '         varUnits -> the units of the variable to plot -> used for the y-Axis title of the plot
        'Outputs: None
        Dim i As Integer 'counter
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zg5BoxPlot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zg5BoxPlot object -> used to redraw/update the plot
        Dim numPts As Integer 'number of points in ptList
        Dim xTitle As String 'the title of the XAxis
        Dim medianList As ZedGraph.PointPairList 'collection of Median points for the Box/Whisker plot
        Dim meanList As ZedGraph.PointPairList 'collection of Mean points for the Box/Whisker plot
        Dim outlierList As ZedGraph.PointPairList 'collection of Outlier points for the Box/Whisker plot
        Dim boxes As clsBoxPlot() 'collection of boxes to draw
        Dim xAxisLabels As String() 'collection of labels for the x-Axis
        Dim medianLine As ZedGraph.LineItem 'zedgraph curve item -> line that contains all of the Medain points
        Dim meanLine As ZedGraph.LineItem 'zedgraph curve item -> line that contains all of the Mean points
        Dim outlierLine As ZedGraph.LineItem 'zedgraph curve item -> line that contains all of the outliers
        Dim min, max As Double 'the max,Min value
        Dim showXTics As Boolean = True 'tracks if showing major tic marks along the x-axis
        Try
            ''TODO: Michelle: Remove the message box -> for testing only!!
            'MsgBox("Graphing the Box/Whisker Plot")

            '1. Set the Graph Pane, graphics object
            gPane = zg5BoxPlot.GraphPane
            'g = zg5BoxPlot.CreateGraphics

            '2. Validate Data
            If m_VisPlotData Is Nothing Then
                'reset Title = No Data
                gPane.Title.Text = "No Data"
                zg5BoxPlot.Refresh()
                'release resources
                'If Not (g Is Nothing) Then
                '	g.Dispose()
                '	g = Nothing
                'End If
                'exit
                Exit Try
            End If

            '3. Let user know something is being plotted
            gPane.Title.Text = "Loading Graph..."
            zg5BoxPlot.Refresh()

            '4. Calculate Data for the correct type of BoxPlot
            'get all the rows from the table with positive data, order by Date
            medianList = New ZedGraph.PointPairList()
            meanList = New ZedGraph.PointPairList()
            min = 100
            max = 0
            Select Case True
                Case rbtnBPMonthly.Checked
                    'Calculate Boxplot for Monthly data
                    numPts = CalcBoxPlot_Monthly(medianList, meanList, boxes, xAxisLabels, min, max)
                    xTitle = "Month"
                    showXTics = True
                Case rbtnBPSeasonal.Checked
                    'Calculate Boxplot for seasonal data
                    numPts = CalcBoxPlot_Seasonal(medianList, meanList, boxes, xAxisLabels, min, max)
                    xTitle = "Season"
                    showXTics = True
                Case rbtnBPYearly.Checked
                    'Calculate Boxplot for Yearly data
                    numPts = CalcBoxPlot_Yearly(medianList, meanList, boxes, xAxisLabels, min, max)
                    xTitle = "Year"
                    showXTics = True
                Case rbtnBPOverall.Checked
                    'Calculate Boxplot for All data
                    numPts = CalcBoxPlot_Overall(medianList, meanList, boxes, xAxisLabels, min, max)
                    xTitle = "Overall"
                    showXTics = False
            End Select

			'5. Set Graph Properties
			If gPane.IsZoomed() = True Then
				zg5BoxPlot.ZoomOutAll(gPane)
			End If
            'x-axis
            gPane.XAxis.IsVisible = True
            gPane.XAxis.Type = ZedGraph.AxisType.Text
            gPane.XAxis.Scale.TextLabels = xAxisLabels
            gPane.XAxis.Title.Text = xTitle
            gPane.XAxis.MajorTic.IsAllTics = showXTics
            'y-axis
            gPane.YAxis.IsVisible = True
            gPane.YAxis.MajorGrid.IsVisible = True
            gPane.YAxis.MajorGrid.Color = Color.Gray
            gPane.YAxis.Type = ZedGraph.AxisType.Linear
            gPane.YAxis.Title.Text = variable & "  " & varUnits
            gPane.YAxis.Scale.Min = 0.975 * min
            gPane.YAxis.Scale.Max = 1.025 * max
            gPane.YAxis.Scale.MaxGrace = 0.025 '2.5% 
            gPane.YAxis.Scale.MinGrace = 0.025 '2.5%
            'Title
            While (GetStringLen(site, gPane.Title.FontSpec.GetFont(gPane.CalcScaleFactor)) > zg5TimeSeries.Width)
                site = GraphTitleBreaks(site)
            End While

            gPane.Title.Text = site

            '6. Plot the Data
            If numPts > 0 Then
                'Add Median line to plot
                medianLine = gPane.AddCurve("MedianPts", medianList, Color.Black, ZedGraph.SymbolType.Circle)
                medianLine.Line.IsVisible = False
                medianLine.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Black)
                medianLine.Symbol.Size = 5
                'Add Mean line to plot
                meanLine = gPane.AddCurve("MeanPts", meanList, Color.Red, ZedGraph.SymbolType.Triangle)
                meanLine.Line.IsVisible = False
                meanLine.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Red)
                meanLine.Symbol.Size = 5
                'Draw BoxPlot,Outliers around each point
                If Not (outlierList Is Nothing) Then
                    outlierList.Clear()
                Else
                    outlierList = New ZedGraph.PointPairList
                End If
                For i = 0 To numPts - 1
                    If Not (boxes(i) Is Nothing) Then
                        'Draw Box/Whisker
                        DrawBoxPlot(gPane, boxes(i))
                        'set Outliers Points
                        DrawOutliers(outlierList, boxes(i))
                    End If
                Next i
                'draw the Outliers on plot
                outlierLine = gPane.AddCurve("Outliers", outlierList, Color.DarkGreen, ZedGraph.SymbolType.Circle)
                outlierLine.Line.IsVisible = False
                outlierLine.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.DarkGreen)
                outlierLine.Symbol.Size = 4
                outlierLine.IsOverrideOrdinal = True

                'set up scrolling
                zg5BoxPlot.IsAutoScrollRange = False
                zg5BoxPlot.ScrollMinX = -1
                zg5BoxPlot.ScrollMaxX = numPts + 1
                zg5BoxPlot.ScrollMinY = 0.975 * min
                zg5BoxPlot.ScrollMaxY = 1.025 * max
            Else
                gPane.XAxis.Scale.Min = 0
                gPane.XAxis.Scale.Max = 10
                gPane.YAxis.Scale.Min = 0
                gPane.YAxis.Scale.Max = 10
            End If
            'draw the plot
            zg5BoxPlot.AxisChange()
            zg5BoxPlot.Refresh()

            '7. Release Resources
            'If Not (g Is Nothing) Then
            '	g.Dispose()
            '	g = Nothing
            'End If
            If Not (medianList Is Nothing) Then
                medianList = Nothing
            End If
            If Not (meanList Is Nothing) Then
                meanList = Nothing
            End If
            If Not (outlierList Is Nothing) Then
                outlierList = Nothing
            End If
            If Not (boxes Is Nothing) Then
                boxes = Nothing
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while graphing the Box/Whisker Plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
            'draw what have set so far
            If Not (gPane Is Nothing) Then 'AndAlso Not (g Is Nothing) Then
                zg5BoxPlot.Refresh()
            End If
        End Try
    End Sub

    Private Function CalcBoxPlot_Monthly(ByRef medianPtList As ZedGraph.PointPairList, ByRef meanPtList As ZedGraph.PointPairList, ByRef boxes As clsBoxPlot(), ByRef xAxisLabels As String(), ByRef min As Double, ByRef max As Double) As Integer
        'This function calculates the Mean and Median point lists, boxes, and x-axis lables for the Monthly Box Plot, it returns the number of points created
        'Inputs:  medianPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         meanPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         boxes (ByRef) -> the collection of data for drawing each box -> values are calculated in this function : input values are junk
        '         xAxisLabels (ByRef) -> the collection of labels for the x-Axis -> values are calcaulted in this funciton : input values are junk
        '         min (byRef) -> the minimum value -> value is calculated in this function : input value is initialized
        '         max (byRef) -> the maximum value -> value is calculated in this function : input value is initialized  
        'Outputs: Integer -> the number of points (boxes) in the point list being returned
        '         medianPtList (ByRef) -> the Median Point values for each month
        '         meanPtList (ByRef) -> the Mean Point values for each month
        '         boxes (ByRef) -> the calculated values for drawing a box around each point
        '         xAxisLabels (ByRef) -> the set of labels for the x-Axis -> 1 for each month
        '         min (byRef) -> the minimum value of the whisker/outliers
        '         max (byRef) -> the maximum value of the whisker/outliers
        Const numMonths As Integer = 12 'number of months in the year -> Monthly will always have this many points
        Dim i, j As Integer 'counter
        Dim monthData As Data.DataTable 'clone of m_VisPlotData -> used to pull the data for each individual month 
        Dim validRows As Data.DataRow() 'collection of valid data for the current month
        Dim numValid As Integer 'number of valid rows retrieved
        Try
            ''TODO: Michelle: Remove the message box -> for testing only
            'MsgBox("Calculating the Data for the Monthly Box Plot")

            '1. Create the Mean, Median point list
            If Not (medianPtList) Is Nothing Then
                If medianPtList.Count > 0 Then
                    medianPtList.Clear()
                End If
            Else
                medianPtList = New ZedGraph.PointPairList()
            End If
            If Not (meanPtList) Is Nothing Then
                If meanPtList.Count > 0 Then
                    meanPtList.Clear()
                End If
            Else
                meanPtList = New ZedGraph.PointPairList()
            End If

            '2. Create Axis labels
            xAxisLabels = CreateMonthLabels()

            '3. Get data for each month, calculate stats
            ReDim boxes(numMonths - 1)
            monthData = m_VisPlotData.Clone()
            For i = 0 To numMonths - 1
                '4. get the data for the current month
                'validRows = m_VisPlotData.Select(db_fld_ValDTMonth & " = " & (i + 1) & " AND " & db_fld_ValCensorCode & " <> " & db_val_valCensorCode_lt, db_fld_ValValue & " ASC")
                'NOTE: INCLUDE the censored data
                validRows = m_VisPlotData.Select(db_outFld_ValDTMonth & " = " & (i + 1), db_fld_ValValue & " ASC")
                numValid = validRows.Length()
                'see if have any points for this month
                If numValid > 0 Then
                    'add the data for this month to monthData
                    If monthData.Rows.Count > 0 Then
                        monthData.Clear()
                    End If
                    For j = 0 To numValid - 1
                        monthData.ImportRow(validRows(j))
                    Next j
                    '5. calculate stats on data
                    If (boxes(i) Is Nothing) Then
                        boxes(i) = New clsBoxPlot
                    End If
                    CalcBoxPlotStats(numValid, monthData, boxes(i))

                    '6. calculate,add the point to ptList
                    'set x,y values for this box
                    boxes(i).xValue = i + 1
                    boxes(i).yValue = boxes(i).median
                    'add the point
                    medianPtList.Add(i, boxes(i).yValue, xAxisLabels(i) & ", " & "Median = " & boxes(i).yValue)
                    meanPtList.Add(i, boxes(i).mean, xAxisLabels(i) & ", " & "Mean = " & boxes(i).mean)

                    '7. Calc Outliers
                    'set the min,max to Lower,Upper Adjacent Values
                    'min
                    If boxes(i).adjacentLevel_Lower < min Then
                        min = boxes(i).adjacentLevel_Lower
                    End If
                    'max
                    If boxes(i).adjacentLevel_Upper > max Then
                        max = boxes(i).adjacentLevel_Upper
                    End If
                    'Calculate the Outliers for this set of data, set min,max values to min,Max Outlier values
                    CalcBoxPlotOutliers(numValid, monthData, boxes(i), min, max)
                Else
                    medianPtList.Add(i, ZedGraph.PointPair.Missing)
                    meanPtList.Add(i, ZedGraph.PointPair.Missing)
                End If
            Next i

            '8. Release resources
            If Not (monthData Is Nothing) Then
                monthData.Dispose()
                monthData = Nothing
            End If
            If Not (validRows Is Nothing) Then
                validRows = Nothing
            End If

            '9. return the number of points created
            Return numMonths
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Monthly Box Plot values. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'return that none were created
        Return 0
    End Function

    Private Function CalcBoxPlot_Seasonal(ByRef medianPtList As ZedGraph.PointPairList, ByRef meanPtList As ZedGraph.PointPairList, ByRef boxes As clsBoxPlot(), ByRef xAxisLabels As String(), ByRef min As Double, ByRef max As Double) As Integer
        'This function calculates the point list, boxes, and x-axis lables for the Seasonal Box Plot, it returns the number of points created
        'Inputs:  medianPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         meanPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         boxes (ByRef) -> the collection of data for drawing each box -> values are calculated in this function : input values are junk
        '         xAxisLabels (ByRef) -> the collection of labels for the x-Axis -> values are calcaulted in this funciton : input values are junk
        '         min (byRef) -> the minimum value -> value is calculated in this function : input value is initialized
        '         max (byRef) -> the maximum value -> value is calculated in this function : input value is initialized  
        'Outputs: Integer -> the number of points (boxes) in the point list being returned
        '         medianPtList (ByRef) -> the Median Point values for each Season
        '         meanPtList (ByRef) -> the Mean Point values for each Season
        '         boxes (ByRef) -> the calculated values for drawing a box around each point
        '         xAxisLabels (ByRef) -> the set of labels for the x-Axis -> 1 for each month
        '         min (byRef) -> the minimum value of the whisker/outliers
        '         max (byRef) -> the maximum value of the whisker/outliers
        Const numSeasons As Integer = 4 'number of Seasons in the year -> Seasonal will always have this many points
        Dim i, j As Integer 'counter
        Dim seasonData As Data.DataTable 'clone of m_VisPlotData -> used to pull the data for each individual month 
        Dim validRows As Data.DataRow() 'collection of valid data for the current month
        Dim numValid As Integer 'number of valid rows retrieved
        Try
            ''TODO: Michelle: Remove the message box -> for testing only
            'MsgBox("Calculating the Data for the Seasonal Box Plot")

            '1. Create the Mean, Median point list
            If Not (medianPtList) Is Nothing Then
                If medianPtList.Count > 0 Then
                    medianPtList.Clear()
                End If
            Else
                medianPtList = New ZedGraph.PointPairList()
            End If
            If Not (meanPtList) Is Nothing Then
                If meanPtList.Count > 0 Then
                    meanPtList.Clear()
                End If
            Else
                meanPtList = New ZedGraph.PointPairList()
            End If

            '2. Create Axis labels
            xAxisLabels = CreateSeasonLabels()

            '3. Get data for each month, calculate stats
            ReDim boxes(numSeasons - 1)
            seasonData = m_VisPlotData.Clone()
            For i = 0 To numSeasons - 1
                '4. get the data for the current season
                'validRows = m_VisPlotData.Select("(" & db_fld_ValDTMonth & " = " & ((3 * i) + 1) & " OR " & db_fld_ValDTMonth & " = " & ((3 * i) + 2) & " OR " & db_fld_ValDTMonth & " = " & ((3 * i) + 3) & ") AND (" & db_fld_ValCensorCode & " <> " & db_val_valCensorCode_lt & ")", db_fld_ValValue & " ASC")
                'NOTE: INCLUDE the censored data
                validRows = m_VisPlotData.Select("(" & db_outFld_ValDTMonth & " = " & ((3 * i) + 1) & " OR " & db_outFld_ValDTMonth & " = " & ((3 * i) + 2) & " OR " & db_outFld_ValDTMonth & " = " & ((3 * i) + 3) & ")", db_fld_ValValue & " ASC")
                numValid = validRows.Length()
                'see if have any points for this month
                If numValid > 0 Then
                    'add the data for this month to monthData
                    If seasonData.Rows.Count > 0 Then
                        seasonData.Clear()
                    End If
                    For j = 0 To numValid - 1
                        seasonData.ImportRow(validRows(j))
                    Next j
                    '5. calculate stats on data
                    If (boxes(i) Is Nothing) Then
                        boxes(i) = New clsBoxPlot
                    End If
                    CalcBoxPlotStats(numValid, seasonData, boxes(i))

                    '6. calculate,add the point to ptList
                    'set x,y values for this box
                    boxes(i).xValue = i + 1
                    boxes(i).yValue = boxes(i).median
                    'add the point
                    medianPtList.Add(i, boxes(i).yValue, xAxisLabels(i) & ", " & "Median = " & boxes(i).yValue)
                    meanPtList.Add(i, boxes(i).mean, xAxisLabels(i) & ", " & "Mean = " & boxes(i).mean)

                    '7. Calc Outliers
                    'set the min,max to Lower,Upper Adjacent Values
                    'min
                    If boxes(i).adjacentLevel_Lower < min Then
                        min = boxes(i).adjacentLevel_Lower
                    End If
                    'max
                    If boxes(i).adjacentLevel_Upper > max Then
                        max = boxes(i).adjacentLevel_Upper
                    End If
                    'Calculate the Outliers for this set of data, set min,max values to min,Max Outlier values
                    CalcBoxPlotOutliers(numValid, seasonData, boxes(i), min, max)
                Else
                    medianPtList.Add(i, ZedGraph.PointPair.Missing)
                    meanPtList.Add(i, ZedGraph.PointPair.Missing)
                End If
            Next i

            '8. Release resources
            If Not (seasonData Is Nothing) Then
                seasonData.Dispose()
                seasonData = Nothing
            End If
            If Not (validRows Is Nothing) Then
                validRows = Nothing
            End If

            '9. return the number of points created
            Return numSeasons
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Seasonal Box Plot values. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'return that none were created
        Return 0
    End Function

    Private Function CalcBoxPlot_Yearly(ByRef medianPtList As ZedGraph.PointPairList, ByRef meanPtList As ZedGraph.PointPairList, ByRef boxes As clsBoxPlot(), ByRef xAxisLabels As String(), ByRef min As Double, ByRef max As Double) As Integer
        'This function calculates the point list, boxes, and x-axis lables for the Yearly Box Plot, it returns the number of points created
        'Inputs:  medianPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         meanPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         boxes (ByRef) -> the collection of data for drawing each box -> values are calculated in this function : input values are junk
        '         xAxisLabels (ByRef) -> the collection of labels for the x-Axis -> values are calcaulted in this funciton : input values are junk
        '         min (byRef) -> the minimum value -> value is calculated in this function : input value is initialized
        '         max (byRef) -> the maximum value -> value is calculated in this function : input value is initialized  
        'Outputs: Integer -> the number of points (boxes) in the point list being returned
        '         medianPtList (ByRef) -> the Median Point values for each year
        '         meanPtList (ByRef) -> the Mean Point values for each year
        '         boxes (ByRef) -> the calculated values for drawing a box around each point
        '         xAxisLabels (ByRef) -> the set of labels for the x-Axis -> 1 for each Year
        '         min (byRef) -> the minimum value of the whisker/outliers
        '         max (byRef) -> the maximum value of the whisker/outliers
        Dim numYears As Integer = 0 'number of years in selected data
        Dim i, j As Integer 'counter
        Dim yearData As Data.DataTable 'clone of m_VisPlotData -> used to pull the data for each individual month 
        Dim validRows As Data.DataRow() 'collection of valid data for the current month
        Dim numValid As Integer 'number of valid rows retrieved
        Dim startYear As Integer 'the beginning year of the data
        Dim endYear As Integer 'the ending year of the data
        Dim curYear As Integer 'the current year evaluating data for
        Try
            '1. Create Axis labels
            numYears = CreateYearLabels(xAxisLabels, startYear, endYear)
            'make sure there is at least 1 year
            If numYears <= 0 Then
                'return 0
                Exit Try
            End If

            '2. Create the Mean, Median point list
            If Not (medianPtList) Is Nothing Then
                If medianPtList.Count > 0 Then
                    medianPtList.Clear()
                End If
            Else
                medianPtList = New ZedGraph.PointPairList()
            End If
            If Not (meanPtList) Is Nothing Then
                If meanPtList.Count > 0 Then
                    meanPtList.Clear()
                End If
            Else
                meanPtList = New ZedGraph.PointPairList()
            End If

            '3. Get data for each month, calculate stats
            ReDim boxes(numYears - 1)
            yearData = m_VisPlotData.Clone()
            For i = 0 To numYears - 1
                '4. get the data for the current year
                curYear = CInt(xAxisLabels(i))
                'validRows = m_VisPlotData.Select(db_fld_ValDTYear & " = " & (curYear) & " AND " & db_fld_ValCensorCode & " <> " & db_val_valCensorCode_lt, db_fld_ValValue & " ASC")
                'NOTE: INCLUDE censored data
                validRows = m_VisPlotData.Select(db_outFld_ValDTYear & " = " & (curYear), db_fld_ValValue & " ASC")
                numValid = validRows.Length()
                'see if have any points for this month
                If numValid > 0 Then
                    'add the data for this month to monthData
                    If yearData.Rows.Count > 0 Then
                        yearData.Clear()
                    End If
                    For j = 0 To numValid - 1
                        yearData.ImportRow(validRows(j))
                    Next j
                    '5. calculate stats on data
                    If (boxes(i) Is Nothing) Then
                        boxes(i) = New clsBoxPlot
                    End If
                    CalcBoxPlotStats(numValid, yearData, boxes(i))

                    '6. calculate,add the point to ptList
                    'set x,y values for this box
                    boxes(i).xValue = i + 1
                    boxes(i).yValue = boxes(i).median
                    'add the point
                    medianPtList.Add(i, boxes(i).yValue, xAxisLabels(i) & ", " & "Median = " & boxes(i).yValue)
                    meanPtList.Add(i, boxes(i).mean, xAxisLabels(i) & ", " & "Mean = " & boxes(i).mean)

                    '7. Calc Outliers
                    'set the min,max to Lower,Upper Adjacent Values
                    'min
                    If boxes(i).adjacentLevel_Lower < min Then
                        min = boxes(i).adjacentLevel_Lower
                    End If
                    'max
                    If boxes(i).adjacentLevel_Upper > max Then
                        max = boxes(i).adjacentLevel_Upper
                    End If
                    'Calculate the Outliers for this set of data, set min,max values to min,Max Outlier values
                    CalcBoxPlotOutliers(numValid, yearData, boxes(i), min, max)
                Else
                    medianPtList.Add(i, ZedGraph.PointPair.Missing)
                    meanPtList.Add(i, ZedGraph.PointPair.Missing)
                End If
            Next i

            '8. Release resources
            If Not (yearData Is Nothing) Then
                yearData.Dispose()
                yearData = Nothing
            End If
            If Not (validRows Is Nothing) Then
                validRows = Nothing
            End If

            '9. return the number of points created
            Return numYears
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Yearly Box Plot values. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'return that none were created
        Return 0
    End Function

    Private Function CalcBoxPlot_Overall(ByRef medianPtList As ZedGraph.PointPairList, ByRef meanPtList As ZedGraph.PointPairList, ByRef boxes As clsBoxPlot(), ByRef xAxisLabels As String(), ByRef min As Double, ByRef max As Double) As Integer
        'This function calculates the point list, boxes, and x-axis labels for the Overall Box Plot, it returns the number of points created
        'Inputs:  medianPtList (ByRef) -> the zedgraph PointPairList to Plot the Median value -> value is calculated in this function : input values are junk
        '         meanPtList (ByRef) -> the zedgraph PointPairList to Plot the Median value -> value is calculated in this function : input values are junk
        '         boxes (ByRef) -> the collection of data for drawing each box -> values are calculated in this function : input values are junk
        '         xAxisLabels (ByRef) -> the collection of labels for the x-Axis -> values are calcaulted in this funciton : input values are junk
        '         min (byRef) -> the minimum value -> value is calculated in this function : input value is initialized
        '         max (byRef) -> the maximum value -> value is calculated in this function : input value is initialized  
        'Outputs: Integer -> the number of points (boxes) in the point list being returned
        '         medianPtList (ByRef) -> the overall Median Point value
        '         meanPtList (ByRef) -> the overall Mean Point value
        '         boxes (ByRef) -> the calculated values for drawing a box around each point
        '         xAxisLabels (ByRef) -> the set of labels for the x-Axis -> 1 total
        '         min (byRef) -> the minimum value of the whisker/outliers
        '         max (byRef) -> the maximum value of the whisker/outliers
        Const numPts As Integer = 5 'number of months in the year -> Overall will always have this many points
        Dim validRows() As Data.DataRow
        Dim numValid As Integer 'number of valid rows retrieved
        Dim overallData As Data.DataTable
        Dim i As Integer
        Try
            ''TODO: Michelle: Remove the message box -> for testing only
            'MsgBox("Calculating the Data for the Overall Box Plot")

            '1. Create the Mean, Median point list
            If Not (medianPtList) Is Nothing Then
                If medianPtList.Count > 0 Then
                    medianPtList.Clear()
                End If
            Else
                medianPtList = New ZedGraph.PointPairList()
            End If
            If Not (meanPtList) Is Nothing Then
                If meanPtList.Count > 0 Then
                    meanPtList.Clear()
                End If
            Else
                meanPtList = New ZedGraph.PointPairList()
            End If

            '2. Create Axis labels
            ReDim xAxisLabels(4)
            'xAxisLabels(2) = "Overall"

            '3. Get data for each month, calculate stats
            ReDim boxes(numPts - 1)
            overallData = m_VisPlotData.Clone()
            '4. get the valid data 
            validRows = m_VisPlotData.Select("", db_fld_ValValue & " ASC")
            numValid = validRows.Length()
            'see if have any points 
            If numValid > 0 Then
                'add the data to overallData
                For i = 0 To numValid - 1
                    overallData.ImportRow(validRows(i))
                Next i
                '5. calculate stats on data
                If (boxes(2) Is Nothing) Then
                    boxes(2) = New clsBoxPlot
                End If
                CalcBoxPlotStats(numValid, overallData, boxes(2))

                '6. calculate,add the point to ptList
                'set x,y values for this box
                boxes(2).xValue = 3
                boxes(2).yValue = boxes(2).median
                'add the points
                medianPtList.Add(1, ZedGraph.PointPair.Missing)
                meanPtList.Add(1, ZedGraph.PointPair.Missing)
                medianPtList.Add(2, ZedGraph.PointPair.Missing)
                meanPtList.Add(2, ZedGraph.PointPair.Missing)
                medianPtList.Add(3, boxes(2).yValue, xAxisLabels(2) & ", " & "Median = " & boxes(2).yValue)
                meanPtList.Add(3, boxes(2).mean, xAxisLabels(2) & ", " & "Mean = " & boxes(2).mean)
                medianPtList.Add(4, ZedGraph.PointPair.Missing)
                meanPtList.Add(4, ZedGraph.PointPair.Missing)
                medianPtList.Add(5, ZedGraph.PointPair.Missing)
                meanPtList.Add(5, ZedGraph.PointPair.Missing)

                '7. Calc Outliers
                'set the min,max to Lower,Upper Adjacent Values
                'min
                If boxes(2).adjacentLevel_Lower < min Then
                    min = boxes(2).adjacentLevel_Lower
                End If
                'max
                If boxes(2).adjacentLevel_Upper > max Then
                    max = boxes(2).adjacentLevel_Upper
                End If
                'Calculate the Outliers for this set of data, set min,max values to min,Max Outlier values
                CalcBoxPlotOutliers(numValid, m_VisPlotData, boxes(2), min, max)
            End If

            '8. return the number of points created
            Return numPts
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Overall Box Plot values. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'return that none were created
        Return 0
    End Function

    Private Sub CalcBoxPlotOutliers(ByVal numRows As Integer, ByRef monthData As Data.DataTable, ByRef boxData As clsBoxPlot, ByRef min As Double, ByRef max As Double)
        '
        'Inputs:  
        'Outputs: 
        Dim i As Integer 'counter
        Dim curValue As Double 'current value checking
        Try
            '1. move through values 
            For i = 0 To numRows - 1
                'get the value
                curValue = monthData.Rows(i).Item(db_fld_ValValue)
                '2. find those that are below the Lower Adjacent Level -> add them to boxData.Outliers_Lower
                If (curValue < boxData.adjacentLevel_Lower) Then
                    boxData.AddOutlier_Lower(curValue)
                End If
                '3. find those that are above the Upper Adjacent Level -> add them to boxData.Outliers_Upper
                If (curValue > boxData.adjacentLevel_Upper) Then
                    boxData.AddOutlier_Upper(curValue)
                End If
                '4. compare to min,max
                'min
                If curValue < min Then
                    min = curValue
                End If
                'max
                If curValue > max Then
                    max = curValue
                End If
            Next i
        Catch ex As Exception
            ShowError("An Error occurred while calculating the the Outliers for the Box Plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub DrawBoxPlot(ByRef gPane As ZedGraph.GraphPane, ByVal boxData As clsBoxPlot)
        'Dim x1, y1, x2, y2 As Double 'x,y values for bounds of rectangles
        Dim upperBoxShaded As ZedGraph.BoxObj 'shaded box between 75% quantile and Upper 95% Confidence Limit on the Median
        Dim lowerBoxShaded As ZedGraph.BoxObj 'shaded box between 25% quantile and Lower 95% Confidence Limit on the Median
        Dim hourglassPts As ZedGraph.PointD() 'points for the Hourglass outline to make up the box outline
        Dim hourglassOutline As ZedGraph.PolyObj 'Outline for the Hourglass
        Dim confIntervalLine As ZedGraph.LineObj 'Line in center -> 95% Confidence Interval on the Mean
        Dim whisker_Upper As ZedGraph.LineObj 'Upper Whisker -> Upper Adjacent Level
        Dim lineToWhisker_Upper As ZedGraph.LineObj 'Line from Upper Whisker to 75% quantile (top of box)
        Dim whisker_Lower As ZedGraph.LineObj 'Lower Whisker -> Lower Adjacent Level
        Dim lineToWhisker_Lower As ZedGraph.LineObj 'Line from Lower Whisker to 25% quantil (bottom of box)
        Try
            '1. Draw Confidence Interval -> red line
            confIntervalLine = New ZedGraph.LineObj(Color.Red, boxData.xValue, boxData.confidenceInterval95_Upper, boxData.xValue, boxData.confidenceInterval95_Lower)
            confIntervalLine.IsClippedToChartRect = True
            confIntervalLine.ZOrder = ZedGraph.ZOrder.E_BehindCurves
            gPane.GraphObjList.Add(confIntervalLine)

            '2. Draw Upper Whisker, line
            'whisker
            whisker_Upper = New ZedGraph.LineObj(Color.Black, boxData.xValue - 0.15, boxData.adjacentLevel_Upper, boxData.xValue + 0.15, boxData.adjacentLevel_Upper)
            whisker_Upper.IsClippedToChartRect = True

            whisker_Upper.ZOrder = ZedGraph.ZOrder.E_BehindCurves
            'whisker_Upper.PenWidth = 2
            gPane.GraphObjList.Add(whisker_Upper)
            'line between whisker, top of hourglass
            lineToWhisker_Upper = New ZedGraph.LineObj(Color.Black, boxData.xValue, boxData.adjacentLevel_Upper, boxData.xValue, boxData.quantile_75th)
            lineToWhisker_Upper.IsClippedToChartRect = True
            lineToWhisker_Upper.ZOrder = ZedGraph.ZOrder.E_BehindCurves
            'lineToWhisker_Upper.PenWidth = 2
            gPane.GraphObjList.Add(lineToWhisker_Upper)

            '3. Draw Lower Whisker, line
            'whisker
            whisker_Lower = New ZedGraph.LineObj(Color.Black, boxData.xValue - 0.15, boxData.adjacentLevel_Lower, boxData.xValue + 0.15, boxData.adjacentLevel_Lower)
            whisker_Lower.IsClippedToChartRect = True
            whisker_Lower.ZOrder = ZedGraph.ZOrder.E_BehindCurves
            'whisker_Lower.PenWidth = 2
            gPane.GraphObjList.Add(whisker_Lower)
            'line between whisker, top of hourglass
            lineToWhisker_Lower = New ZedGraph.LineObj(Color.Black, boxData.xValue, boxData.quantile_25th, boxData.xValue, boxData.adjacentLevel_Lower)
            lineToWhisker_Lower.IsClippedToChartRect = True

            lineToWhisker_Lower.ZOrder = ZedGraph.ZOrder.E_BehindCurves
            'lineToWhisker_Lower.PenWidth = 2
            gPane.GraphObjList.Add(lineToWhisker_Lower)

            '4. Draw Hourglass outline
            'create points
            ReDim hourglassPts(10)
            'top
            hourglassPts(0) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.quantile_75th)
            hourglassPts(1) = New ZedGraph.PointD(boxData.xValue + 0.3, boxData.quantile_75th)
            'right side
            hourglassPts(2) = New ZedGraph.PointD(boxData.xValue + 0.3, boxData.confidenceLimit95_Upper)
            hourglassPts(3) = New ZedGraph.PointD(boxData.xValue + 0.15, boxData.median)
            hourglassPts(4) = New ZedGraph.PointD(boxData.xValue + 0.3, boxData.confidenceLimit95_Lower)
            'bottom
            hourglassPts(5) = New ZedGraph.PointD(boxData.xValue + 0.3, boxData.quantile_25th)
            hourglassPts(6) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.quantile_25th)
            'left side
            hourglassPts(7) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.confidenceLimit95_Lower)
            hourglassPts(8) = New ZedGraph.PointD(boxData.xValue - 0.15, boxData.median)
            hourglassPts(9) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.confidenceLimit95_Upper)
            'repeat 1st point -> end of poly
            hourglassPts(10) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.quantile_75th)
            'create outline
            hourglassOutline = New ZedGraph.PolyObj(hourglassPts)
            hourglassOutline.Border.Color = Color.SlateGray
            hourglassOutline.Border.IsVisible = True
            hourglassOutline.Fill.IsVisible = False
            hourglassOutline.IsClippedToChartRect = True
            hourglassOutline.ZOrder = ZedGraph.ZOrder.E_BehindCurves
            gPane.GraphObjList.Add(hourglassOutline)

            '5. Draw Upper shaded box ->Upper 95% Confidence Limit to 75% quantile value
            If boxData.quantile_75th > boxData.confidenceLimit95_Upper Then
                upperBoxShaded = New ZedGraph.BoxObj(1, 1, 1, 1)
                'If upperBoxShaded.Location Is Nothing Then
                '    upperBoxShaded.Location = New ZedGraph.Location()
                'End If
                upperBoxShaded.Location.X = boxData.xValue - 0.3
                upperBoxShaded.Location.Width = 0.6
                upperBoxShaded.Location.Y = boxData.quantile_75th
                upperBoxShaded.Location.Height = -Math.Round(boxData.quantile_75th - boxData.confidenceLimit95_Upper, 3)
                'Else
                'upperBoxShaded.Location.Y = boxData.confidenceLimit95_Upper
                'upperBoxShaded.Location.Height = Math.Round(boxData.quantile_75th - boxData.confidenceLimit95_Upper, 3)

                upperBoxShaded.Border.IsVisible = False
                upperBoxShaded.Fill = New ZedGraph.Fill(System.Drawing.Color.LightGray)
                upperBoxShaded.IsClippedToChartRect = True
                upperBoxShaded.ZOrder = ZedGraph.ZOrder.E_BehindCurves
                gPane.GraphObjList.Add(upperBoxShaded)
            End If
            '6. Draw Lower shaded box ->Lower 95% Confidence Limit to 25% quantile value
            If boxData.confidenceLimit95_Lower > boxData.quantile_25th Then
                lowerBoxShaded = New ZedGraph.BoxObj(1, 1, 1, 1)
                'If upperBoxShaded.Location Is Nothing Then
                '    upperBoxShaded.Location = New ZedGraph.Location()
                'End If
                lowerBoxShaded.Location.X = boxData.xValue - 0.3
                lowerBoxShaded.Location.Width = 0.6

                lowerBoxShaded.Location.Y = boxData.confidenceLimit95_Lower
                lowerBoxShaded.Location.Height = -Math.Round(boxData.confidenceLimit95_Lower - boxData.quantile_25th, 3)
                'Else
                'lowerBoxShaded.Location.Y = boxData.quantile_25th
                'lowerBoxShaded.Location.Height = Math.Round(boxData.confidenceLimit95_Lower - boxData.quantile_25th, 3)
                lowerBoxShaded.Border.IsVisible = False
                lowerBoxShaded.Fill = New ZedGraph.Fill(System.Drawing.Color.LightGray)
                lowerBoxShaded.IsClippedToChartRect = True
                lowerBoxShaded.ZOrder = ZedGraph.ZOrder.E_BehindCurves
                gPane.GraphObjList.Add(lowerBoxShaded)
            End If

            '7. Release resources
            If Not (hourglassPts Is Nothing) Then
                hourglassPts = Nothing
            End If
            If Not (hourglassOutline Is Nothing) Then
                hourglassOutline = Nothing
            End If
            If Not (upperBoxShaded Is Nothing) Then
                upperBoxShaded = Nothing
            End If
            If Not (lowerBoxShaded Is Nothing) Then
                lowerBoxShaded = Nothing
            End If
            If Not (confIntervalLine Is Nothing) Then
                confIntervalLine = Nothing
            End If
            If Not (whisker_Upper Is Nothing) Then
                whisker_Upper = Nothing
            End If
            If Not (lineToWhisker_Upper Is Nothing) Then
                lineToWhisker_Upper = Nothing
            End If
            If Not (whisker_Lower Is Nothing) Then
                whisker_Lower = Nothing
            End If
            If Not (lineToWhisker_Lower Is Nothing) Then
                lineToWhisker_Lower = Nothing
            End If
        Catch ex As Exception
            ShowError("An Error occurred while drawing a Box/Whisker for the Box Plot. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub DrawOutliers(ByRef outlierPtList As ZedGraph.PointPairList, ByVal curBoxData As clsBoxPlot) 'ByRef gPane As ZedGraph.GraphPane, ByVal boxData As clsBoxPlot)
        Dim i As Integer 'counter
        Dim curValue As Double

        Try
            '1. validate data
            If curBoxData Is Nothing Then
                Exit Try
            End If
            If outlierPtList Is Nothing Then
                outlierPtList = New ZedGraph.PointPairList
            End If

            '2. Add Lower Outliers
            If curBoxData.numOutliers_Lower > 0 Then
                For i = 0 To curBoxData.numOutliers_Lower - 1
                    curValue = curBoxData.outlierValue_Lower(i)
                    If curValue <> -1 Then
                        outlierPtList.Add(curBoxData.xValue, curValue)
                    End If
                Next i
            End If

            '3. Draw Upper Outliers
            If curBoxData.numOutliers_Upper > 0 Then
                For i = 0 To curBoxData.numOutliers_Upper - 1
                    curValue = curBoxData.outlierValue_Upper(i)
                    If curValue <> -1 Then
                        'add the point
                        outlierPtList.Add(curBoxData.xValue, curValue)
                    End If
                Next i
            End If
        Catch ex As Exception
            ShowError("An Error occurred while drawing the Outliers for the Box Plot." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Function CreateMonthLabels() As String()
        Dim labels(11) As String
        'set the labels for each month
        labels(0) = "Jan"
        labels(1) = "Feb"
        labels(2) = "Mar"
        labels(3) = "Apr"
        labels(4) = "May"
        labels(5) = "Jun"
        labels(6) = "Jul"
        labels(7) = "Aug"
        labels(8) = "Sep"
        labels(9) = "Oct"
        labels(10) = "Nov"
        labels(11) = "Dec"

        Return labels
    End Function

    Private Function CreateSeasonLabels() As String()
        Dim labels(3) As String
        'set the labels for each month
        labels(0) = "Winter"
        labels(1) = "Spring"
        labels(2) = "Summer"
        labels(3) = "Fall"

        Return labels
    End Function

    Private Function CreateYearLabels(ByRef labels As String(), ByRef startYear As Integer, ByRef endYear As Integer) As Integer
        Dim i As Integer 'counter
        Dim numYears As Integer 'count of years in selected data
        Dim curYear As Integer 'current year creating a label for
        Try
            ''TODO: Michelle: remove message box -> for testing only!!
            'MsgBox("Creating the Year Labels for the Box/Whisker Plot")

            '1. calculate the start,end year
            startYear = m_VisPlotData.Compute("Min(" & db_outFld_ValDTYear & ")", "")
            endYear = m_VisPlotData.Compute("Max(" & db_outFld_ValDTYear & ")", "")

            '2. calculate the number of years
            numYears = (endYear - startYear) + 1

            '3. create the labels -> one for each year
            ReDim labels(numYears - 1)
            For i = 0 To numYears - 1
                curYear = startYear + i
                If (curYear >= startYear) AndAlso (curYear <= endYear) Then
                    labels(i) = curYear
                End If
            Next i

            Return numYears
        Catch ex As Exception
            ShowError("An Error occurred while creating the Year labels for the Box/Whisker Plot." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'return 0
        Return 0
    End Function

#End Region

#End Region

#Region " Visualize Tab: Statistics Functions "

#Region " Plot Options: Summary "

    Private Sub CalculateSummary()
        'Calculates and populates the statistics for the "Summary" tab page
        'Inputs:  None
        'Outputs: None
        Try
            'Dim i As Integer
            Dim stats As New clsStatistics  'instance of Statistics class : used to calculate the Censored Data -> so only calculate stats for valid data
            Dim mean As Double 'the mean value of the data
            Dim max As Double 'the maximum value of the data in m_Table
            Dim min As Double 'the minimum value of the data in m_Table
            Dim var As Double 'the variance of the data
            Dim dev As Double 'the standard deviation of the data -> sqrt(dev)
            Dim geoMean As Double 'the geometericMean of the data
            Dim table As DataTable 'copy of m_Table or a clone of m_Table filled with data in rows()
            Dim maxRow As Data.DataRow
            Dim minRow As Data.DataRow

            'clear the previous summary
            ClearSummary()

            If (m_VisPlotData Is Nothing OrElse m_VisPlotData.Rows.Count = 0) Then Exit Sub

            Dim temp As Object
            temp = m_VisPlotData.Compute("Max (" & db_fld_ValValue & ")", "")
            maxRow = m_VisPlotData.Select(db_fld_ValValue & " = " & temp, db_fld_ValCensorCode & " ASC")(0)
            max = CDbl(temp)
            temp = m_VisPlotData.Compute("Min (" & db_fld_ValValue & ")", "")
            minRow = m_VisPlotData.Select(db_fld_ValValue & " = " & temp, db_fld_ValCensorCode & " ASC")(0) 'get just the first row returned
            min = CDbl(temp)

            'check to make sure we can caculate the censored data
            Dim numNonCensored As Integer = m_VisPlotData.Compute("Count(" & db_fld_ValCensorCode & ")", db_fld_ValCensorCode & " <> " & db_val_ValCensorCode_lt) 'the number of values in m_Table that are > 0 (will be viewed by the user so aren't censored)
            Dim numCensored As Integer = m_VisPlotData.Compute("Count(" & db_fld_ValCensorCode & ")", db_fld_ValCensorCode & " = " & db_val_ValCensorCode_lt) 'the number of values in m_Table that are <= 0 (won't be viewed by the user unless the user specifies to)

            'get all the rows from the table
            Dim rows() As DataRow 'the data selected from m_Table that is positive
            Dim i As Integer 'counter

            If (ckboxUseCensoredData.Checked And numCensored > 0) Then
                If (numNonCensored < 2) Then
                    'If (max <= 0) Then
                    If maxRow.Item(db_fld_ValCensorCode) = db_val_ValCensorCode_lt Then
                        tboxMax.Text = "<BDL>"
                    Else
                        tboxMax.Text = max
                    End If

                    'If (min <= 0) Then
                    If minRow.Item(db_fld_ValCensorCode) = db_val_ValCensorCode_lt Then
                        tboxMin.Text = "<BDL>"
                    Else
                        tboxMin.Text = min
                    End If

                    tboxNumCensoredObs.Text = numCensored
                    tboxNumObs.Text = numCensored + numNonCensored
                    Exit Sub
                End If

                'calculate the censored data
                table = m_VisPlotData.Copy
                stats.CalculateCensoredData(table)
            Else
                table = m_VisPlotData.Clone
                rows = m_VisPlotData.Select(db_fld_ValCensorCode & " <> " & db_val_ValCensorCode_lt, db_fld_ValValue & " ASC")
                For i = 0 To rows.Length() - 1
                    table.ImportRow(rows(i))
                Next i
            End If

            Dim count As Integer = table.Rows.Count 'the number of rows in table
            If (count > 0) Then
                'calculate the variance, standard deviation
                If Not (count = 1 And table.Rows.Item(0).Item(db_fld_ValValue) = 0) Then
                    'Mean = table.Compute("Avg (" & db_fld_ValValue & ")", db_fld_ValValue & " > 0")
                    mean = table.Compute("Avg (" & db_fld_ValValue & ")", "")
                    'If Not (table.Compute("Var (" & db_fld_ValValue & ")", db_fld_ValValue & " > 0") Is System.DBNull.Value) Then
                    If Not (table.Compute("Var (" & db_fld_ValValue & ")", "") Is System.DBNull.Value) Then
                        'var = table.Compute("Var (" & db_fld_ValValue & ")", db_fld_ValValue & " > 0")
                        var = table.Compute("Var (" & db_fld_ValValue & ")", "")
                        dev = System.Math.Sqrt(var)
                    End If
                End If

                'calculate the geometric mean
                Dim sum As Double 'the sum so far of the Log10(Value) (the log base 10 of value) -> used to calculate the geometric mean
                'rows = table.Select(db_fld_ValValue & " > 0", db_fld_ValValue & " ASC")
                rows = table.Select("", db_fld_ValValue & " ASC")
                For i = 0 To rows.Length() - 1
                    sum += Math.Log10(rows(i)(db_fld_ValValue))
                Next i
                geoMean = 10 ^ (sum / rows.Length)

                tboxAMean.Text = mean.ToString("G4")
                tboxGeoMean.Text = geoMean.ToString("G4")
                tboxStdDev.Text = dev.ToString("G4")
                tboxCoeffVar.Text = var.ToString("G4")
                tbox10Perc.Text = CType(table.Rows.Item(Math.Floor(count / 10)).Item(db_fld_ValValue), Double).ToString("G4")
                tbox25Perc.Text = CType(table.Rows.Item(Math.Floor(count / 4)).Item(db_fld_ValValue), Double).ToString("G4")

                'calculate the median
                If (count Mod 2 = 0 And count > 1) Then
                    tbox50Perc.Text = CType((table.Rows((count / 2) - 1).Item(db_fld_ValValue) + table.Rows(count / 2).Item(db_fld_ValValue)) / 2, Double).ToString("G4")
                Else
                    tbox50Perc.Text = CType(table.Rows(Math.Ceiling((count / 2) - 1)).Item(db_fld_ValValue), Double).ToString("G4")
                End If
                tbox75Perc.Text = CType(table.Rows.Item(Math.Floor(count / 4 * 3)).Item(db_fld_ValValue), Double).ToString("G4")
                tbox90Perc.Text = CType(table.Rows.Item(Math.Floor(count / 10 * 9)).Item(db_fld_ValValue), Double).ToString("G4")
            End If

            'set the min and max values
            'If (max <= 0) Then
            If maxRow.Item(db_fld_ValCensorCode) = db_val_ValCensorCode_lt Then
                tboxMax.Text = "<BDL>"
            Else
                tboxMax.Text = max
            End If

            'If (min <= 0) Then
            If minRow.Item(db_fld_ValCensorCode) = db_val_ValCensorCode_lt Then
                tboxMin.Text = "<BDL>"
            Else
                tboxMin.Text = min
            End If

            tboxNumObs.Text = numNonCensored + numCensored
            tboxNumCensoredObs.Text = numCensored

            'release resources
            If Not (table Is Nothing) Then
                table.Dispose()
            End If
            table = Nothing
            rows = Nothing
            stats = Nothing
        Catch ex As System.Exception
            'show an error message
            ShowError("An Error occurred while calculating the Statistical Summary for the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub ClearSummary()
        'Resets the values in the "Summary" tab page to empty strings or 0 (Blanks out the values)
        'Inputs:  None
        'Outputs: None

        tboxAMean.Text = ""
        tboxGeoMean.Text = ""
        tboxMax.Text = ""
        tboxMin.Text = ""
        tboxStdDev.Text = ""
        tboxCoeffVar.Text = ""

        tbox10Perc.Text = ""
        tbox25Perc.Text = ""
        tbox50Perc.Text = ""
        tbox75Perc.Text = ""
        tbox90Perc.Text = ""
        tboxNumObs.Text = 0
        tboxNumCensoredObs.Text = 0
    End Sub

#End Region

#Region " Plots: BoxPlot "

    Private Sub CalcBoxPlotStats(ByVal numRows As Integer, ByRef data As DataTable, ByRef boxData As clsBoxPlot)
        'Calculates and stores the stats for the given set of data for a BoxPlot
        'Inputs:  data (ByRef) -> the set of data to calculate the stats on
        '         boxData (ByRef) -> the clsBoxPlot object to store the calculated data into -> NOTE: the xValue should have already been set
        'Outputs: data (ByRef) -> 
        '         boxData (ByRef) -> the calculated stats so can draw the boxPlot at this point
        Dim variance As Double 'the variance of the values in data
        Dim stdDev As Double 'the standard deviation of the values in data
        Dim max As Double 'the maximum value in data
        Dim min As Double 'the minimum value in data
        Dim v As Double 'used to calculate the lower,upper whiskers (adjacent levels)
        Try
            'make sure have data
            If numRows = 0 OrElse data.Rows.Count <= 0 Then
                Exit Try
            End If
            '1. Calculate the 25% and 75% quantile values
            boxData.quantile_25th = data.Rows(Math.Floor(numRows / 4)).Item(db_fld_ValValue)
            boxData.quantile_75th = data.Rows(Math.Floor(numRows / 4) * 3).Item(db_fld_ValValue)

            '2. calculate the Mean, Median
            'Mean
            boxData.mean = Math.Round(data.Compute("Avg(" & db_fld_ValValue & ")", ""), 3)
            'Median
            If (numRows Mod 2 = 0 And numRows > 1) Then
                'even number of values -> take the middle two and average them
                Dim val1 As Double 'first of the middle values -> (numRows/2) - 1
                Dim val2 As Double 'second of the middle value -> (numrows/2)
                val1 = data.Rows((numRows / 2) - 1).Item(db_fld_ValValue)
                val2 = data.Rows(numRows / 2).Item(db_fld_ValValue)
                boxData.median = (val1 + val2) / 2
            Else
                boxData.median = data.Rows(Math.Ceiling((numRows / 2) - 1)).Item(db_fld_ValValue)
            End If

            '3. Calculate the upper and lower whiskers
            max = data.Compute("Max(" & db_fld_ValValue & ")", "")
            min = data.Compute("Min(" & db_fld_ValValue & ")", "")
            v = (boxData.quantile_75th - boxData.quantile_25th) * 1.5
            'lower whisker -> Lower Adjacent Level
            If (boxData.quantile_25th - v) < min Then
                boxData.adjacentLevel_Lower = min
            Else
                boxData.adjacentLevel_Lower = boxData.quantile_25th - v
            End If
            'upper whisker -> Upper Adjacent Level
            If (boxData.quantile_75th + v) > max Then
                boxData.adjacentLevel_Upper = max
            Else
                boxData.adjacentLevel_Upper = boxData.quantile_75th + v
            End If

            '4. Calculate the 95% Confidence Interval on the Mean,Calculate the 95% Confidence Limit on the Median
            If Not (data.Compute("Var(" & db_fld_ValValue & ")", "") Is System.DBNull.Value) Then
                variance = data.Compute("Var(" & db_fld_ValValue & ")", "")
                stdDev = Math.Sqrt(variance)
            Else
                stdDev = 0
            End If
            'Confidence Interval on Mean
            boxData.confidenceInterval95_Lower = boxData.mean - 1.96 * (stdDev / (Math.Sqrt(numRows)))
            boxData.confidenceInterval95_Upper = boxData.mean + 1.96 * (stdDev / (Math.Sqrt(numRows)))
            'Confidence Limit on Median
            boxData.confidenceLimit95_Lower = boxData.median - 1.96 * (stdDev / (Math.Sqrt(numRows)))
            boxData.confidenceLimit95_Upper = boxData.median + 1.96 * (stdDev / (Math.Sqrt(numRows)))
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Box Plot Statistics for the Visualize Tab. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub GetStats(ByRef flowTable As DataTable, ByRef yMean As Double, _
      ByRef yMedian As Double, ByRef y25 As Double, ByRef y75 As Double, ByRef yAdjL As Double, ByRef yAdjU As Double, _
      ByRef y95CIU As Double, ByRef y95CIL As Double, ByRef y95CLU As Double, ByRef y95CLL As Double)
        'Calculates the statistics needed to draw the Whisker Box plot -> mean, median, quantiles, CI, CL, adjacent levels
        'Inputs:  flowTable -> (ByRef) the dataTable of data to calculate the stats for
        '         yMean -> (ByRef) the mean value of the data in the dataTable
        '         yMedian -> (ByRef) the median value of the data in the dataTable
        '         y25 -> (ByRef) the lower(25th)-Quantile value of the data in the dataTable
        '         y75 -> (ByRef) the upper(75th)-Quantile value of the data in the dataTable
        '         yAdjL -> (ByRef) the lower adjacent level -> the lower whisker
        '         yAdjU -> (ByRef) the upper adjacent level -> the upper whisker
        '         y95CIU -> (ByRef) the upper 95% confidence interval on the mean
        '         y95CIL -> (ByRef) the lower 95% confidence interval on the mean
        '         y95CLU -> (ByRef) the upper 95% confidence limit on the median
        '         y95CLL -> (ByRef) the lower 95% confidence limit on the median
        'Outputs: all Inputs -> they are by ref, so changed/unchanged values for all of the Inputs are returned
        Try
            Dim variance As Double 'the variance of the values in flowTable
            Dim stdDev As Double 'the standard deviation of the values in flowTable -> sqrt(variance_
            Dim count As Integer = flowTable.Rows.Count 'the number of rows in flowTable -> the dataTable passed in
            'make sure that there is valid data in flowTable
            If count = 0 Then Exit Sub

            'calculate the 25% and 75% quantile and median
            y25 = flowTable.Rows(Math.Floor(count / 4)).Item("Value")
            y75 = flowTable.Rows(Math.Floor((count / 4) * 3)).Item("Value")

            'calculate the median
            If (count Mod 2 = 0 And count > 1) Then
                yMedian = (flowTable.Rows((count / 2) - 1).Item("Value") + flowTable.Rows(count / 2).Item("Value")) / 2
            Else
                yMedian = flowTable.Rows(Math.Ceiling((count / 2) - 1)).Item("Value")
            End If

            'calculate the upper and lower whiskers
            Dim max As Double = flowTable.Compute("Max(Value)", "") 'the maximum value of the data in flowTable
            Dim min As Double = flowTable.Compute("Min(Value)", "") 'the minimum value of the data in flowTable
            Dim v As Double = (y75 - y25) * 1.5 'used to calculate the lower,upper whiskers for the boxPlot

            If (y75 + v > max) Then
                yAdjU = max
            Else
                yAdjU = y75 + v
            End If

            If (y25 - v < min) Then
                yAdjL = min
            Else
                yAdjL = y25 - v
            End If

            'calculate the Mean
            yMean = flowTable.Compute("Avg(Value)", "")

            'calculate the variance and standard deviation
            If Not (flowTable.Compute("Var(Value)", "") Is System.DBNull.Value) Then
                variance = flowTable.Compute("Var(Value)", "")
                stdDev = Math.Sqrt(variance)
            End If

            'calculate the confidence Intervals on the mean and median
            y95CIU = yMean + 1.96 * (stdDev / (Math.Sqrt(count)))
            y95CIL = yMean - 1.96 * (stdDev / (Math.Sqrt(count)))
            y95CLU = yMedian + 1.96 * (stdDev / (Math.Sqrt(count)))
            y95CLL = yMedian - 1.96 * (stdDev / (Math.Sqrt(count)))
        Catch ex As System.Exception
            MsgBox("Error in GetStats(), Message: " + ex.Message, MsgBoxStyle.Exclamation, "Time Series Data Analyst")
        End Try
    End Sub

    Private Sub GetAveragedStats(ByRef flowTable As DataTable, ByVal method As AveragingType, ByRef yMean As Double, ByRef yStdDev As Double)
        'Calculates the Mean, Standard Deviation for averaged data
        'Inputs:  flowTable -> (ByRef) table of Averaged data to calculate the Statistics for
        '         method -> the averaging method 
        '         yMean -> (ByRef)Mean Value : input value isn't important -> value is calculated in this function
        '         yStdDev -> (ByRef) Standard Deviation Value : input value isn't important -> value is calculated in this function
        'Outputs: flowTable -> (ByRef) table of averaged data input
        '         yMean -> (ByRef) calculated Mean (average) of the averaged values
        '         yStdDev -> (ByRef) calculated Standard Deviation of the averaged values
        Try
            Dim variance As Double 'the variance of the values in flowTable
            Dim count As Integer = flowTable.Rows.Count 'the number of rows in flowTable -> the dataTable passed in
            'make sure that there is valid data in flowTable
            If count = 0 Then Exit Sub

            Select Case method
                Case AveragingType.Hourly, AveragingType.Daily, AveragingType.Weekly, AveragingType.Monthly, AveragingType.Yearly
                    'calculate the Mean
                    yMean = flowTable.Compute("Avg(Average)", "")

                    'calculate the variance and standard deviation
                    If Not (flowTable.Compute("Var(Average)", "") Is System.DBNull.Value) Then
                        variance = flowTable.Compute("Var(Average)", "")
                        yStdDev = Math.Sqrt(variance)
                    End If
                Case AveragingType.Seasonally
                    'need to get the average of the averages for each season, etc.
                    Dim newSeasonTable As Data.DataTable 'new data table with seasonally averaged data -> in Seasonal Average format
                    newSeasonTable = FormatSeasonTable(flowTable)

                    'calculate the Mean
                    yMean = newSeasonTable.Compute("Avg(Average)", "")

                    'calculate the variance and the standard deviation
                    If Not (newSeasonTable.Compute("Var(Average)", "") Is System.DBNull.Value) Then
                        variance = newSeasonTable.Compute("Var(Average)", "")
                        yStdDev = Math.Sqrt(variance)
                    Else
                        'return 0, do a check if ystdev = 0 when graphing and don't show anything
                        yStdDev = 0
                    End If
            End Select
        Catch ex As System.Exception
            MsgBox("Error in GetAveragedStats(), Message: " + ex.Message, MsgBoxStyle.Exclamation, "Time Series Data Analyst")
        End Try
    End Sub

    Private Function FormatSeasonTable(ByVal table As DataTable) As DataTable
        'Reformats a Seasonally averaged table so data can be retreived easily
        'Inputs:  table -> the table of seasonally averaged data to format so can read the Seasonally averaged values
        'Outputs: DataTable -> the formatted table 
        Try
            Dim newTable As New DataTable 'table to put formatted data into : return value
            Dim newRow As DataRow 'DataRow -> used to add data from the input table to the new, formatted table

            'setup the new table
            newTable.Columns.Add(New DataColumn("yYear", GetType(Integer)))
            newTable.Columns.Add(New DataColumn("sSeason", GetType(Integer)))
            newTable.Columns.Add(New DataColumn("Average", GetType(Double)))

            'add all the records to the new table
            Dim i As Integer 'counter
            For i = 0 To table.Rows.Count - 1
                'winter
                newRow = newTable.NewRow
                newRow("yYear") = table.Rows(i).Item("yYear")
                newRow("sSeason") = 1
                newRow("Average") = table.Rows(i).Item("Winter")
                newTable.Rows.Add(newRow)
                'spring
                newRow = newTable.NewRow
                newRow("yYear") = table.Rows(i).Item("yYear")
                newRow("sSeason") = 2
                newRow("Average") = table.Rows(i).Item("Spring")
                newTable.Rows.Add(newRow)
                'summer
                newRow = newTable.NewRow
                newRow("yYear") = table.Rows(i).Item("yYear")
                newRow("sSeason") = 3
                newRow("Average") = table.Rows(i).Item("Summer")
                newTable.Rows.Add(newRow)
                'fall
                newRow = newTable.NewRow
                newRow("yYear") = table.Rows(i).Item("yYear")
                newRow("sSeason") = 4
                newRow("Average") = table.Rows(i).Item("Fall")
                newTable.Rows.Add(newRow)
            Next i

            'release resources
            newRow = Nothing

            Return newTable
        Catch ex As Exception
            ShowError("FormatSeasonTable()" & vbCrLf & ex.Message, ex)
            Return Nothing
        End Try
    End Function

#End Region

#End Region

#Region " Visualize and Edit Tab: Common Functions "

    Private Sub InitializeZedGraphPlot(ByRef plot As ZedGraph.ZedGraphControl)
        '
        'Inputs:  plot -> (ByRef) the instance of the plot to initialize
        'Outputs: plot -> (ByRef) the initialized plot
        Dim graphPane As ZedGraph.GraphPane
        Try
            ''TODO: Michelle: remove msgbox -> for testing only!!
            'MsgBox("Initializing Plot = " & plot.Name)

            '1. get reference to plot's graphpane
            graphPane = plot.GraphPane

            '2. clear out all data
            graphPane.CurveList.Clear()
            graphPane.GraphObjList.Clear()

            '3. reset plot
            'reset titles
            graphPane.Title.Text = ""
            graphPane.XAxis.Title.Text = ""
            graphPane.YAxis.Title.Text = ""
            'recalculate axis
            plot.AxisChange()
            'turn off legend
            graphPane.Legend.IsVisible = False
            'remove gridlines
            graphPane.XAxis.MajorGrid.IsVisible = False
            graphPane.XAxis.MinorGrid.IsVisible = False
            graphPane.YAxis.MajorGrid.IsVisible = False
            graphPane.YAxis.MinorGrid.IsVisible = False
            'reset axis type = linear
            graphPane.XAxis.Type = ZedGraph.AxisType.Linear
            graphPane.YAxis.Type = ZedGraph.AxisType.Linear
            '
            graphPane.XAxis.IsVisible = False
            graphPane.YAxis.IsVisible = False


            '4. update the plot
            graphPane.Draw(plot.CreateGraphics)
        Catch ex As Exception
            ShowError("An Error occurred while initializing the Plot = " & plot.Name & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub UpdateZedGraphPlotBounds(ByRef plot As ZedGraph.ZedGraphControl, ByVal data As Data.DataTable, ByVal noDataVal As Double)
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgTimeSeries plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zgTimeSeries plot object -> used to redraw/update the plot
        Dim maxVal As Double
        Dim minVal As Double
        Dim maxDate As DateTime
        Dim minDate As DateTime
        Dim xScrollPad As Double
        Try
            '1. set the Graph Pane, graphics object
            gPane = plot.GraphPane
            'g = plot.CreateGraphics

            '2. Get the Max, Min values from data
            minVal = data.Compute("MIN(" & db_fld_ValValue & ")", db_fld_ValValue & " <> " & noDataVal)
            maxVal = data.Compute("MAX(" & db_fld_ValValue & ")", db_fld_ValValue & " <> " & noDataVal)

            '3. Get the Max,Min Date from data
            minDate = data.Compute("MIN(" & db_fld_ValDateTime & ")", "")
            maxDate = data.Compute("MAX(" & db_fld_ValDateTime & ")", "")

            '4. set new scroll bounds in plot
            xScrollPad = 0.025 * (maxDate.ToOADate - minDate.ToOADate)
            plot.ScrollMinX = (minDate.ToOADate) - xScrollPad
            plot.ScrollMaxX = (maxDate.ToOADate) + xScrollPad
            plot.ScrollMinY = 0.975 * minVal
            plot.ScrollMaxY = 1.025 * maxVal

            '5. redraw the plot
            plot.AxisChange()
            plot.Refresh()

            '6. Release resources
            'If Not (g Is Nothing) Then
            '	g.Dispose()
            'End If
        Catch ex As Exception
            ShowError("An Error occurred while updating the bounds on the plot = " & plot.Name & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'Release resources
        'If Not (g Is Nothing) Then
        '	g.Dispose()
        'End If
    End Sub

#End Region

#Region " Edit Tab: Form Controls Functions "

#Region " Edit Tab: Plot Functions "

    Private Sub PlotEditData(ByVal site As String, ByVal variable As String, ByVal varUnits As String)
        'This function plots the Time Series graph for the selected data series
        'Inputs:  site -> Code - Name of the site to plot -> used for the title
        '         variable -> Code - Name of the variable to plot -> used for the y-axis label
        '         varUnits -> (units) of the variable abbreviated -> used for the y-axis label
        '         startDate -> Start Date of the data -> for calculating Scroll padding
        '         endDate -> End Date of the data -> for calculating Scroll padding
        'Outputs: None
        'Dim i As Integer 'counter
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgTimeSeries plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zgTimeSeries plot object -> used to redraw/update the plot
        Dim ptList As ZedGraph.PointPairList 'collection of points for the Time Series line
        Dim editCurve As ZedGraph.LineItem 'Line object -> Time Series line that is added to the plot
        'Dim validRows() As Data.DataRow 'collection of valid data retrieved from m_VisPlotData -> data to plot
        'Dim numRows As Integer 'number of valid rows returned
        'Dim curDate As Date	'Date of the current item -> x-value for the current point
        'Dim curValue As Double 'Value of the curren item -> y-value for the current point
        'Dim xScrollPad As Double 'scroll padding value for the x-axis
        Dim maxDate As DateTime
        Dim minDate As DateTime
        Dim maxValue As Double
        Dim minValue As Double
        Dim minX, maxX As Date
        Dim minY, maxY As Double
        Dim rangeX, rangeY As Double
        Try
            '1. set the Graph Pane, graphics object
            gPane = zg5EditPlot.GraphPane
            'g = zg5EditPlot.CreateGraphics

            '2. Validate Data
            If m_EditData Is Nothing Then
                'If site = "" OrElse variable = "" OrElse (m_VisPlotData Is Nothing) Then
                'reset Title = No Data
                gPane.Title.Text = "No Data"
                zg5EditPlot.Refresh()
                'release resources
                'If Not (g Is Nothing) Then
                '	g.Dispose()
                '	g = Nothing
                'End If
                'exit
                Exit Try
            End If

            '3. Let user know something is being plotted
            gPane.Title.Text = "Loading Graph ... "
            zg5EditPlot.Refresh()
            Me.Cursor = Cursors.WaitCursor

            '4. set Graph Properties
            If gPane.IsZoomed() = True Then
                zg5EditPlot.ZoomOutAll(gPane)
            End If
            'x-axis
            minX = m_EditData.Compute("MIN(" & db_fld_ValDateTime & ")", "")
            maxX = m_EditData.Compute("MAX(" & db_fld_ValDateTime & ")", "")
            rangeX = maxX.ToOADate - minX.ToOADate
            gPane.XAxis.IsVisible = True
            gPane.XAxis.MajorGrid.IsVisible = True
            gPane.XAxis.MajorGrid.Color = Drawing.Color.Gray
            gPane.XAxis.Type = ZedGraph.AxisType.Date
            gPane.XAxis.Title.Text = "Date"
            gPane.XAxis.Scale.Min = minX.ToOADate - (m_XBorder * rangeX)
            gPane.XAxis.Scale.Max = maxX.ToOADate + (m_XBorder * rangeX)
            'gPane.XAxis.Min = startDate.ToOADate
            'gPane.XAxis.Max = endDate.ToOADate
            'gPane.XAxis.Scale.MinGrace = 0.025 '2.5% of time padding on front
            'gPane.XAxis.Scale.MaxGrace = 0.025 '2.5% of time padding on back
            gPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Month
            gPane.XAxis.Scale.MinorUnit = ZedGraph.DateUnit.Hour
            'y-axis
            minY = m_EditData.Compute("MIN(" & db_fld_ValValue & ")", "")
            maxY = m_EditData.Compute("MAX(" & db_fld_ValValue & ")", "")
            rangeY = maxY - minY
            gPane.YAxis.IsVisible = True
            gPane.YAxis.MajorGrid.IsVisible = True
            gPane.YAxis.MajorGrid.Color = Drawing.Color.Gray
            gPane.YAxis.Type = ZedGraph.AxisType.Linear
            gPane.YAxis.Title.Text = variable & "   " & varUnits
            gPane.YAxis.Scale.Min = minY - (m_YBorder * rangeY)
            gPane.YAxis.Scale.Max = maxY + (m_YBorder * rangeY)
            'gPane.YAxis.Scale.MaxGrace = 0.025
            'gPane.YAxis.Scale.MinGrace = 0.025
            'gPane.YAxis.Scale.MajorStep = 50
            'Title
            While (GetStringLen(site, gPane.Title.FontSpec.GetFont(gPane.CalcScaleFactor)) > zg5TimeSeries.Width)
                site = GraphTitleBreaks(site)
            End While

            gPane.Title.Text = site

            '5. calculate max,min Date values, max Y Value
            minDate = m_EditData.Rows(0).Item(db_fld_ValDateTime) 'NOTE: m_EditData should already be sorted by date, so min = 1st value
            maxDate = m_EditData.Rows(m_EditData.Rows.Count - 1).Item(db_fld_ValDateTime) 'NOTE: m_EditData should already be sorted by date, so max = last value
            maxValue = m_EditData.Compute("Max (" & db_fld_ValValue & ")", "")
            minValue = m_EditData.Compute("Min (" & db_fld_ValValue & ")", "")

            '6. Create the Pts for the Line
            Dim temp As New ZedGraph.DataSourcePointList
            temp.DataSource = m_EditData_Graphing
            temp.XDataMember = db_fld_ValDateTime
            temp.YDataMember = db_fld_ValValue
            temp.ZDataMember = m_Edit_SelZVal

            'NOTE: This DOES NOT work!!  must change the points in the data source!!
            ''Add in Z-Value for all points, initialize to 1.0 so = not selected
            'For i = 0 To m_EditData.Rows.Count - 1
            '	temp.Item(i).Z = 2.0
            'Next i

            'NOTE: Justin changed to using DataMembers to speed up plotting time
            'ptList = New ZedGraph.PointPairList
            'For i = 0 To m_EditData.Rows.Count - 1
            '	curDate = m_EditData.Rows(i).Item(db_fld_ValDateTime)
            '	curValue = m_EditData.Rows(i).Item(db_fld_ValValue)
            '	ptList.Add(curDate.ToOADate, curValue, 1.0)
            'Next i

            '7. Plot the Data
            'create the curve
            editCurve = New ZedGraph.LineItem("editTS")
            editCurve = gPane.AddCurve("editTS", temp, Drawing.Color.Black, ZedGraph.SymbolType.Circle)
            editCurve.Line.IsVisible = True
            'NOTE: Set a GradientByZ Fill, set all z-values = 1.0 for Black, then when selected, zvalue = 2.0, so sel points will show up red
            Dim zFill As New ZedGraph.Fill(Drawing.Color.Black, Drawing.Color.Red)
            zFill.Type = ZedGraph.FillType.GradientByZ
            zFill.RangeMin = 1.0
            zFill.RangeMax = 2.0
            zFill.RangeDefault = 1.0
            zFill.SecondaryValueGradientColor = Drawing.Color.Empty
            editCurve.Symbol.Fill = zFill
            'editCurve.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Black)
            editCurve.Symbol.Size = 7
            editCurve.Symbol.Border.IsVisible = False

            'set up scrolling
            zg5EditPlot.IsAutoScrollRange = False
            zg5EditPlot.ScrollMinX = minX.ToOADate - (m_XBorder * rangeX)
            zg5EditPlot.ScrollMaxX = maxX.ToOADate + (m_XBorder * rangeX)
            zg5EditPlot.ScrollMinY = minY - (m_YBorder * rangeY)
            zg5EditPlot.ScrollMaxY = maxY + (m_YBorder * rangeY)
            'draw the plot
            zg5EditPlot.AxisChange()

            zg5EditPlot.Refresh()

            '8. release resources
            'If Not (g Is Nothing) Then
            '	g.Dispose()
            '	g = Nothing
            'End If
            If Not (ptList Is Nothing) Then
                ptList = Nothing
            End If
            If Not (editCurve Is Nothing) Then
                editCurve = Nothing
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while plotting the Edit Data." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ResetPlotBounds()
        'This function plots the Time Series graph for the selected data series
        'Inputs: None
        'Outputs: None

        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgTimeSeries plot object -> used to set data and characteristics
        Dim minX, maxX As Date
        Dim minY, maxY As Double
        Dim rangeX, rangeY As Double
        Try
            '1. set the Graph Pane, graphics object
            gPane = zg5EditPlot.GraphPane

            '2. Validate Data
            If m_EditData Is Nothing Then
                'If site = "" OrElse variable = "" OrElse (m_VisPlotData Is Nothing) Then
                'reset Title = No Data
                gPane.Title.Text = "No Data"
                zg5EditPlot.Refresh()
                'release resources
                'If Not (g Is Nothing) Then
                '	g.Dispose()
                '	g = Nothing
                'End If
                'exit
                Exit Try
            End If

            '3. Let user know something is being plotted
            Me.Cursor = Cursors.WaitCursor

            '4. set Graph Properties
            If gPane.IsZoomed() = True Then
                zg5EditPlot.ZoomOutAll(gPane)
            End If
            'x-axis
            minX = m_EditData.Compute("MIN(" & db_fld_ValDateTime & ")", "")
            maxX = m_EditData.Compute("MAX(" & db_fld_ValDateTime & ")", "")
            rangeX = maxX.ToOADate - minX.ToOADate
            gPane.XAxis.Scale.Min = minX.ToOADate - (m_XBorder * rangeX)
            gPane.XAxis.Scale.Max = maxX.ToOADate + (m_XBorder * rangeX)

            gPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Month
            gPane.XAxis.Scale.MinorUnit = ZedGraph.DateUnit.Hour
            'y-axis
            minY = m_EditData.Compute("MIN(" & db_fld_ValValue & ")", "")
            maxY = m_EditData.Compute("MAX(" & db_fld_ValValue & ")", "")
            rangeY = maxY - minY
            gPane.YAxis.Scale.Min = minY - (m_YBorder * rangeY)
            gPane.YAxis.Scale.Max = maxY + (m_YBorder * rangeY)

            zg5EditPlot.IsAutoScrollRange = False
            zg5EditPlot.ScrollMinX = minX.ToOADate - (m_XBorder * rangeX)
            zg5EditPlot.ScrollMaxX = maxX.ToOADate + (m_XBorder * rangeX)
            zg5EditPlot.ScrollMinY = minY - (m_YBorder * rangeY)
            zg5EditPlot.ScrollMaxY = maxY + (m_YBorder * rangeY)
            'draw the plot
            zg5EditPlot.AxisChange()

            zg5EditPlot.Refresh()

        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while plotting the Edit Data." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region " Data Selection Functions "

    Private Sub cboxEditSite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxEditSite.SelectedIndexChanged
        'loads the Variables for the selected Site on the Edit Tab
        'the inputs/outputs are standard for form events
        Dim siteCode As String 'holds the Code for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Dim siteName As String 'holds the Name for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Try
            '1. clear out any old Data -> cboxEditVariable
            cboxEditVariable.Items.Clear()

            '2. get the site Code,Name from the selected item
            siteCode = Split(cboxEditSite.SelectedItem, " - ")(0)
            siteName = CStr(cboxEditSite.SelectedItem).Substring(CStr(cboxEditSite.SelectedItem).IndexOf(" - ") + 3) 'NOTE: using substring here to make sure that get full Site Name, even if other " - " values are in the name

            '3. Load the Variables for the selected site from the Series Catalog Table
            If Not (LoadEditVariables(siteCode, siteName)) Then
                'NOTE: errors occurred while loading Variables, disable form
                '4. clear out any other old data
                lvEditDataSeries.Items.Clear()

                '5. disable everything but Site selection
                cboxEditVariable.Enabled = False
                lvEditDataSeries.Enabled = False
                gboxEditFilter.Enabled = False
                SetEditTableBtnsEnabled(False)
            Else
                '4. select the first variable -> NOTE: when a variable is selected, the Data Series will be populated
                If cboxEditVariable.Items.Count > 0 And cboxEditVariable.SelectedIndex < 0 Then
                    cboxEditVariable.SelectedIndex = 0
                End If

                '5. enable Variable Selection -> others are enabled already if needed
                cboxEditVariable.Enabled = True
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while selecting a Site on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub cboxEditSite_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboxEditSite.KeyPress
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                cboxEditSite.SelectedItem = cboxEditSite.Text

                'make sure that item was selected
                If (cboxEditSite.SelectedItem Is Nothing) Then
                    cboxEditSite.Text = ""
                End If
        End Select
    End Sub

    Private Sub cboxEditVariable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxEditVariable.SelectedIndexChanged
        'loads the Data Series for the selected Site and Variable on the Edit Tab
        'the inputs/outputs are standard for form events
        Dim siteCode As String 'holds the Code for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Dim siteName As String 'holds the Name for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Dim varCode As String 'holds the Code for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Dim varName As String 'holds the Name for the currently selected Site -> so can retrieve all the Variables from the Series Catalog Table 
        Try
            '1. clear out any old Data -> lvEditDataSeries
            lvEditDataSeries.Items.Clear()

            '2. get the site Code,Name from the selected item
            siteCode = Split(cboxEditSite.SelectedItem, " - ")(0)
            siteName = CStr(cboxEditSite.SelectedItem).Substring(CStr(cboxEditSite.SelectedItem).IndexOf(" - ") + 3) 'NOTE: using substring here to make sure that get full Site Name, even if other " - " values are in the name

            '3. get the variable Code,Name from the selected item
            varCode = Split(cboxEditVariable.SelectedItem, " - ")(0)
            varName = CStr(cboxEditVariable.SelectedItem).Substring(CStr(cboxEditVariable.SelectedItem).IndexOf(" - ") + 3) 'NOTE: using substring here to make sure that get full variable Name, even if other " - " values are in the name

            '4. Load the Data Series for the selected site and variable from the Series Catalog Table
            If Not (LoadEditDataSeries(siteCode, siteName, varCode, varName)) Then
                'NOTE: errors occurred while loading Data Series, disable form
                '5. clear out any other old data

                '6. disable everything but site,variable selection
                lvEditDataSeries.Enabled = False
                gboxEditFilter.Enabled = False
                SetEditTableBtnsEnabled(False)
            Else
                '5. enable lvEditDataSeries
                lvEditDataSeries.Enabled = True

                '6. disable Data Filter, Plot, Table, and edit functionality -> till a user selects a data series
                gboxEditFilter.Enabled = False
                SetEditTableBtnsEnabled(False)
            End If
            '7. re-set/Initialize plot/table
            InitializeEditTab()

        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while selecting a Variable on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub cboxEditVariable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboxEditVariable.KeyPress
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                cboxEditVariable.SelectedItem = cboxEditVariable.Text

                'make sure that item was selected
                If (cboxEditVariable.SelectedItem Is Nothing) Then
                    cboxEditVariable.Text = ""
                End If
        End Select
    End Sub

    Private Sub lvEditDataSeries_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles lvEditDataSeries.ColumnWidthChanged
        'make sure that no col Width > maxColWIdth
        Dim maxColWidth As Integer = lvEditDataSeries.Width - 25

        If lvEditDataSeries.Columns(e.ColumnIndex).Width > maxColWidth Then
            lvEditDataSeries.Columns(e.ColumnIndex).Width = maxColWidth
        End If
    End Sub

    Private Sub lvEditDataSeries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvEditDataSeries.SelectedIndexChanged
        'loads the Plot, Table Data for the selected Data Series
        'the inputs/outputs are standard for form events
        Dim siteName As String
        'Dim siteID As Integer 'holds the SiteID for the selected Data Series -> value retrieved from m_EditIDs for the corresponding selected item in lvEditDataSeries
        Dim varName As String
        Dim varID As Integer 'holds the VariableID for the selected Data Series -> value retrieved from m_EditIDs for the corresponding selected item in lvEditDataSeries
        Dim varUnits As String
		'Dim qcLevel As Integer = -1 'holds the Quality Control Level value for the selected Data series -> value retrieved from lvEditDataSeries for the selected item 
		Dim qcLevel As String
        'Dim methodID As Integer	'holds the Method ID value from the selected Data SEries -> value retrieved from lvEditDataSeries for the selected item
        'Dim sourceID As Integer
		Dim varUnitsIndex As Integer = 2
		Dim qcLevelIndex As Integer = 8
		Dim qcLevelCode As String
        'NOTE: Colums for lvEditData Series:
		'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description, Citation, Local Date Range, UTC Date Range, Value Count
        Try
            '1. see if any edits are uncommitted
            '1. see if any edits are uncommitted
            If m_EditHaveEditsUncommitted Then
                If MsgBox("There are edits for the current Data Series that have not been committed, would you like them to be applied (saved) to the Database?" & vbCrLf & vbCrLf & "NOTE: IF you select NO then none of your changes will saved!!", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Apply Edits to Database
                    btnEditApplyChanges_Click(Me, New System.EventArgs)
                Else
                    'set that no edit are uncommitted
                    m_EditHaveEditsUncommitted = False
                    m_EditHaveDeletedValIDs = False
                    If Not (m_EditDeletedValIDs Is Nothing) Then
                        m_EditDeletedValIDs.Clear()
                    End If
                    'm_EditHaveRemoveDFIDs = False
                    'If Not (m_EditRemoveDFIDs Is Nothing) Then
                    'm_EditRemoveDFIDs.Clear()
                    'End If
                    'reload current data series
                    'lvEditDataSeries_SelectedIndexChanged(Me, New System.EventArgs())
                    cboxEditVariable_SelectedIndexChanged(Me, New System.EventArgs())
                End If
            End If
            '1. reset/Clear any Plot,Table data
            InitializeEditTab()

            '2. See if anything was selected
            If lvEditDataSeries.SelectedItems.Count <= 0 Then
                '3. disable Filter, editing functionality
                gboxEditFilter.Enabled = False
                SetEditTableBtnsEnabled(False)
                dgvEditTable.ReadOnly = True
            Else
                '3. Get Needed data from selected Item
                siteName = cboxEditSite.Text
                'siteID = CType(m_EditIDs.Item(lvEditDataSeries.SelectedItems(0).Index), clsDataSeriesIDs).SiteID
                varName = cboxEditVariable.Text
                varID = CType(m_EditIDs.Item(lvEditDataSeries.SelectedItems(0).Index), clsDataSeriesIDs).VariableID
                varUnits = GetAbbreviatedVariableUnitsFromDB(lvEditDataSeries.SelectedItems(0).SubItems(varUnitsIndex).Text)
                ''TODO: get the actual values from the ListView
                qcLevel = CType(m_EditIDs.Item(lvEditDataSeries.SelectedItems(0).Index), clsDataSeriesIDs).QCLevelID
                'methodID = CType(m_EditIDs.Item(lvEditDataSeries.SelectedItems(0).Index), clsDataSeriesIDs).MethodID
                'get the NoDataVal
                m_EditNoDataVal = GetVarNoDataValueFromDB(varID)
                '4. Load the Data for the selected data series from the Values Tab
                'Update plot to reflect that loading the data!!
                zg5EditPlot.GraphPane.Title.Text = "Loading Data From Database ... "
                zg5EditPlot.Refresh()
                'LoadEditDataFromDB(siteID, varID, qcLevel, methodID)
                LoadEditDataFromDB(m_EditIDs.Item(lvEditDataSeries.SelectedItems(0).Index))
                If m_EditData.Rows.Count <= 0 Then
                    'no data was retrieved
                    '5. Disable filter,edit functionality
                    gboxEditFilter.Enabled = False
                    SetEditTableBtnsEnabled(False)
                    dgvEditTable.ReadOnly = True
                Else
                    '5. Load the Table
                    LoadEditDataIntoTable()

                    '6. Plot the Data
                    PlotEditData(siteName, varName, varUnits)

                    '7. Enable/disable Functionality based on QC Level
                    qcLevel = lvEditDataSeries.SelectedItems(0).SubItems(qcLevelIndex).Text
                    qcLevelCode = Split(qcLevel, " - ")(0)
                    If IsNumeric(qcLevelCode) Then
                        If CInt(qcLevelCode) <> 0 Then
                            '8. enable everything
                            gboxEditFilter.Enabled = True
                            SetEditTableBtnsEnabled(True)
                            dgvEditTable.ReadOnly = False
                            '9. Load the Date Range for the selected data series from the Series Catalog Table
                            If Not (LoadEditDataFilterDateRange()) Then
                                'NOTE: errors occurred while loading the Date Range, disable Date Filter Area
                                'reset Dates = Today
                                InitializeEditDateInfo()

                                '10. disable ByDate Data Filter selection
                                gboxEditDFDate.Enabled = False
                                rbtnEditDFDate.Enabled = False
                            Else
                                'NOTE: The initial Date Range is set in LoadVisualizeDateRange()
                                '10. enable ByDate Data Filter selection
                                gboxEditDFDate.Enabled = True
                                rbtnEditDFDate.Enabled = True
                            End If

                            '11. Load the Data Gap default Value if can, else Blank It out
                            If m_EditData.Rows.Count > 1 Then
                                If Not (LoadEditDFDataGapDefaultValue(varID, m_EditData.Rows(0).Item(db_fld_ValDateTime), m_EditData.Rows(1).Item(db_fld_ValDateTime))) Then
                                    'NOTE: errors occurred while loading the default Data Gap values, disable Data Gap Area
                                    'make values = blank
                                    tboxEditDFDGValue.Text = ""
                                    cboxEditDFDGTimePeriod.SelectedIndex = -1
                                    cboxEditDFDGTimePeriod.Text = ""

                                    '12.disable By Data Gaps Filter selection
                                    gboxEditDFDataGaps.Enabled = False
                                    rbtnEditDFDataGap.Enabled = False
                                Else
                                    'NOTE: the initial value is set and validated in LoadEditDFDataGapDefaultValue()
                                    '12.enable Data Gaps Filter selection
                                    gboxEditDFDataGaps.Enabled = True
                                    rbtnEditDFDataGap.Enabled = True
                                End If
                            Else
                                'NOTE: there is only 1 Data value, cannot set a Data Gap!!
                                '12. disable Data Gaps Filter selection
                                gboxEditDFDataGaps.Enabled = False
                                rbtnEditDFDataGap.Enabled = False
                            End If

                            '13. Enable/disable Edit Functionality
                            If HaveValidEditDataFilter() Then
                                SetEditTableBtnsEnabled(True)
                            Else
                                SetEditTableBtnsEnabled(False)
                                're-enable Derive New Data Series Button, Add button
                                btnEditDataDeriveNewDS.Enabled = True
                                btnEditDataAdd.Enabled = True
                            End If
                        ElseIf qcLevelCode = 0 Then
                            '8. disable everything but Derive New Data Series button
                            gboxEditFilter.Enabled = False
                            SetEditTableBtnsEnabled(False)
                            dgvEditTable.ReadOnly = True
                            '9. reset Dates = Today
                            InitializeEditDateInfo()
                            '10. make Data Gap values = blank
                            tboxEditDFDGValue.Text = ""
                            cboxEditDFDGTimePeriod.SelectedIndex = -1
                            cboxEditDFDGTimePeriod.Text = ""
                            '11. re-enable the Derive New Data Series button
                            btnEditDataDeriveNewDS.Enabled = True
                            'Else
                            '	'8. disable everything 
                            '	gboxEditFilter.Enabled = False
                            '	SetEditTableBtnsEnabled(False)
                            '	dgvEditTable.ReadOnly = True
                            '	btnEditDataDeriveNewDS.Enabled = False
                            '	'9. reset Dates = Today
                            '	InitializeEditDateInfo()
                            '	'10. make Data Gap values = blank
                            '	tboxEditDFDGValue.Text = ""
                            '	cboxEditDFDGTimePeriod.SelectedIndex = -1
                            '	cboxEditDFDGTimePeriod.Text = ""
                            '	''11. notify user that qcl < 0 can't be edited
                            '	'MsgBox("The selected Data Series has a Quality Control Level of " & qcLevel & "." & vbCrLf & "You can not edit a Data Series with a Quality Control Level below 0.", MsgBoxStyle.Information)
                        End If
                    Else
                        'some other user defined QC Level, enable everything
                        '8. enable everything
                        gboxEditFilter.Enabled = True
                        SetEditTableBtnsEnabled(True)
                        dgvEditTable.ReadOnly = False
                        '9. Load the Date Range for the selected data series from the Series Catalog Table
                        If Not (LoadEditDataFilterDateRange()) Then
                            'NOTE: errors occurred while loading the Date Range, disable Date Filter Area
                            'reset Dates = Today
                            InitializeEditDateInfo()

                            '10. disable ByDate Data Filter selection
                            gboxEditDFDate.Enabled = False
                            rbtnEditDFDate.Enabled = False
                        Else
                            'NOTE: The initial Date Range is set in LoadVisualizeDateRange()
                            '10. enable ByDate Data Filter selection
                            gboxEditDFDate.Enabled = True
                            rbtnEditDFDate.Enabled = True
                        End If

                        '11. Load the Data Gap default Value if can, else Blank It out
                        If m_EditData.Rows.Count > 1 Then
                            If Not (LoadEditDFDataGapDefaultValue(varID, m_EditData.Rows(0).Item(db_fld_ValDateTime), m_EditData.Rows(1).Item(db_fld_ValDateTime))) Then
                                'NOTE: errors occurred while loading the default Data Gap values, disable Data Gap Area
                                'make values = blank
                                tboxEditDFDGValue.Text = ""
                                cboxEditDFDGTimePeriod.SelectedIndex = -1
                                cboxEditDFDGTimePeriod.Text = ""

                                '12.disable By Data Gaps Filter selection
                                gboxEditDFDataGaps.Enabled = False
                                rbtnEditDFDataGap.Enabled = False
                            Else
                                'NOTE: the initial value is set and validated in LoadEditDFDataGapDefaultValue()
                                '12.enable Data Gaps Filter selection
                                gboxEditDFDataGaps.Enabled = True
                                rbtnEditDFDataGap.Enabled = True
                            End If
                        Else
                            'NOTE: there is only 1 Data value, cannot set a Data Gap!!
                            '12. disable Data Gaps Filter selection
                            gboxEditDFDataGaps.Enabled = False
                            rbtnEditDFDataGap.Enabled = False
                        End If

                        '13. Enable/disable Edit Functionality
                        If HaveValidEditDataFilter() Then
                            SetEditTableBtnsEnabled(True)
                        Else
                            SetEditTableBtnsEnabled(False)
                            're-enable Derive New Data Series Button, Add button
                            btnEditDataDeriveNewDS.Enabled = True
                            btnEditDataAdd.Enabled = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while selecting a Data Series on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Table Functions "

    Private Sub dgvEditTable_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEditTable.CellValueChanged
        Dim index As Integer
        Dim newVal As Double
        Try
            '1. get the row index
            index = e.RowIndex
            '2. get the new value
            newVal = dgvEditTable.Item(e.ColumnIndex, index).Value
            '3. update the Data Value in m_EditData
            m_EditData.Rows(index).Item(db_fld_ValValue) = newVal
            m_EditData_Graphing.Rows(index).Item(db_fld_ValValue) = newVal
            '4. Update the plot
            'UpdateYValForSelPtsInPlot()

            UpdateZedGraphPlotBounds(zg5EditPlot, m_EditData, m_EditNoDataVal)
            '5. mark that edits have been made, enable apply and restore buttons
            m_EditHaveEditsUncommitted = True
            btnEditApplyChanges.Enabled = True
        Catch ex As Exception
            ShowError("An Error occurred when a Value in the Table was changed on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub dgvEditTable_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvEditTable.DataError
        Dim index As Integer
        Dim newVal As Object
        Try
            '1. get the row index of the error
            index = e.RowIndex
            '2. check to see if the value input was numeric
            newVal = dgvEditTable.Item(e.ColumnIndex, index).EditedFormattedValue
            If Not (IsNumeric(newVal)) Then
                'show error message -> value must be numerid
                MsgBox("Invalid " & m_EditTableColName_Value & " Value:  " & "Value must be Numeric!!")
            Else
                'show error message -> show their error
                MsgBox("Invalid " & m_EditTableColName_Value & " Value: " & e.Exception.Message & vbCrLf & "Value must be Numeric!!")
            End If
        Catch ex As Exception
            ShowError("An Error occurred while handeling a Data Error in the Data Table in the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub dgvEditTable_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim i As Integer 'counter
        Dim selIndexes As Integer()
        Dim numSel As Integer = 0
        Try
            '1. see if updating selection
            If Not (m_EditUpdatingSelection) AndAlso Not (m_EditDeletingVals) AndAlso Not (m_EditAddingVals) Then
                '2. set that updating selection
                m_EditUpdatingSelection = True

                '3. Save sel table indexes
                numSel = dgvEditTable.SelectedRows.Count
                If numSel > 0 Then
                    ReDim selIndexes(numSel - 1)
                    For i = 0 To numSel - 1
                        selIndexes(i) = dgvEditTable.SelectedRows(i).Index
                    Next i
                    'End If

                    '4. clear selection 
                    ClearEditSelection() 'NOTE: this function disables Edit Functionality until something is selected
                    '5. add correct indexes (ones selected in table) to m_editselpointIndexes
                    If (m_EditSelPtIndexes Is Nothing) Then
                        m_EditSelPtIndexes = New System.Collections.ArrayList
                    ElseIf m_EditSelPtIndexes.Count > 0 Then
                        m_EditSelPtIndexes.Clear()
                    End If
                    If numSel > 0 Then
                        For i = 0 To numSel - 1
                            m_EditSelPtIndexes.Add(selIndexes(i))
                        Next i
                    End If
                    '6. Sort m_EditSelPtIndexes so in correct order
                    m_EditSelPtIndexes.Sort()

                    '7. sel points in plot
                    SelectEditValues() 'NOTE: this function enables Edit Functionality -> something is NOW selected
                End If
                '8. reset that done updating selection
                m_EditUpdatingSelection = False
            End If

        Catch ex As Exception
            ShowError("An Error occurred while selecting rows in the Data Table on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Data Filter Functions "

    Private Sub rbtnEditDFValueThreshold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnEditDFValueThreshold.CheckedChanged
        'check to see if value = checked
        If rbtnEditDFValueThreshold.Checked Then
            'enable >,< checkboxes
            ckboxEditDFVTGreater.Enabled = True
            If ckboxEditDFVTGreater.Checked Then
                tboxEditDFVTGreater.Enabled = True
            End If
            ckboxEditDFVTLess.Enabled = True
            If ckboxEditDFVTLess.Checked Then
                tboxEditDFVTLess.Enabled = True
            End If
            If (ckboxEditDFVTGreater.Checked And tboxEditDFVTGreater.Text <> "") OrElse (ckboxEditDFVTLess.Checked And tboxEditDFVTLess.Text <> "") Then
                'enable ApplyFilter button
                btnEditDFApplyFilter.Enabled = True
            Else
                'disable ApplyFilter button
                btnEditDFApplyFilter.Enabled = False
            End If
        Else
            ckboxEditDFVTGreater.Enabled = False
            tboxEditDFVTGreater.Enabled = False
            ckboxEditDFVTLess.Enabled = False
            tboxEditDFVTLess.Enabled = False
        End If
    End Sub

    Private Sub ckboxEditDFVTGreater_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckboxEditDFVTGreater.CheckedChanged
        'check to see if value = checked
        If ckboxEditDFVTGreater.Checked Then
            tboxEditDFVTGreater.Enabled = True
        Else
            tboxEditDFVTGreater.Enabled = False
        End If
        If (ckboxEditDFVTGreater.Checked And tboxEditDFVTGreater.Text <> "") OrElse (ckboxEditDFVTLess.Checked And tboxEditDFVTLess.Text <> "") Then
            'enable ApplyFilter button
            btnEditDFApplyFilter.Enabled = True
        Else
            'disable ApplyFilter button
            btnEditDFApplyFilter.Enabled = False
        End If
    End Sub

    Private Sub tboxEditDFVTGreater_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxEditDFVTGreater.KeyPress
        ' Select Case e.KeyChar
        'Case vbCr, vbCrLf, vbLf 'return key
        tboxEditDFVTGreater_Validating(sender, New System.ComponentModel.CancelEventArgs)
        'End Select
    End Sub

    Private Sub tboxEditDFVTGreater_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxEditDFVTGreater.Validating
        'This function validates the Value Threshold:Greater Value on the Edit Tab
        Try
            '1. make sure a value was entered
            If tboxEditDFVTGreater.Text <> "" Then
                '2. make sure value is numeric
                If IsNumeric(tboxEditDFVTGreater.Text) Then
                    'valid value -> enable Apply Filter Button
                    btnEditDFApplyFilter.Enabled = True
                Else
                    'show an error box -> value must be numeric
                    MsgBox("Invalid GreaterThan (>) Value: Value must be Numeric.")
                    'tboxEditDFVTGreater.Text = ""
                    e.Cancel = True
                    'disable Apply Filter Button
                    If Not (ckboxEditDFVTLess.Checked And tboxEditDFVTLess.Text <> "") Then
                        'disable ApplyFilter button
                        btnEditDFApplyFilter.Enabled = False
                    End If
                End If
            Else
                'disable Apply Filter Button
                If Not (ckboxEditDFVTLess.Checked And tboxEditDFVTLess.Text <> "") Then
                    'disable ApplyFilter button
                    btnEditDFApplyFilter.Enabled = False
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the Data Filter Value Threshold: GreaterThan (>) value on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
            If Not (ckboxEditDFVTLess.Checked And tboxEditDFVTLess.Text <> "") Then
                'disable ApplyFilter button
                btnEditDFApplyFilter.Enabled = False
            End If
        End Try
    End Sub

    Private Sub ckboxEditDFVTLess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckboxEditDFVTLess.CheckedChanged
        'check to see if value = checked
        If ckboxEditDFVTLess.Checked Then
            tboxEditDFVTLess.Enabled = True
        Else
            tboxEditDFVTLess.Enabled = False
        End If
        If (ckboxEditDFVTGreater.Checked And tboxEditDFVTGreater.Text <> "") OrElse (ckboxEditDFVTLess.Checked And tboxEditDFVTLess.Text <> "") Then
            'enable ApplyFilter button
            btnEditDFApplyFilter.Enabled = True
        Else
            'disable ApplyFilter button
            btnEditDFApplyFilter.Enabled = False
        End If
    End Sub

    Private Sub tboxEditDFVTLess_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxEditDFVTLess.KeyPress
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxEditDFVTLess_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxEditDFVTLess_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxEditDFVTLess.Validating
        'This function validates the Value Threshold: LessThan Value on the Edit Tab
        Try
            '1. make sure a value was entered
            If tboxEditDFVTLess.Text <> "" Then
                '2. make sure value is numeric
                If IsNumeric(tboxEditDFVTLess.Text) Then
                    'valid value -> enable Apply Filter Button
                    btnEditDFApplyFilter.Enabled = True
                Else
                    'show an error box -> value must be numeric
                    MsgBox("Invalid LessThan (<) Value: Value must be Numeric.")
                    'tboxEditDFVTLess.Text = ""
                    e.Cancel = True
                    'disable Apply Filter Button
                    If Not (ckboxEditDFVTGreater.Checked And tboxEditDFVTGreater.Text <> "") Then
                        'disable ApplyFilter button
                        btnEditDFApplyFilter.Enabled = False
                    End If
                End If
            Else
                'disable Apply Filter Button
                If Not (ckboxEditDFVTGreater.Checked And tboxEditDFVTGreater.Text <> "") Then
                    'disable ApplyFilter button
                    btnEditDFApplyFilter.Enabled = False
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the Data Filter Value Threshold: LessThan (<) value on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
            If Not (ckboxEditDFVTGreater.Checked And tboxEditDFVTGreater.Text <> "") Then
                'disable ApplyFilter button
                btnEditDFApplyFilter.Enabled = False
            End If
        End Try
    End Sub

    Private Sub rbtnEditDFVTChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnEditDFVTChange.CheckedChanged
        'check to see if value = checked
        If rbtnEditDFVTChange.Checked Then
            tboxEditDFVTChange.Enabled = True
            If tboxEditDFVTChange.Text <> "" Then
                'enable ApplyFilter button
                btnEditDFApplyFilter.Enabled = True
            Else
                'diable ApplyFilter Button
                btnEditDFApplyFilter.Enabled = False
            End If
        Else
            tboxEditDFVTChange.Enabled = False
        End If
    End Sub

    Private Sub tboxEditDFVTChange_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxEditDFVTChange.KeyPress
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxEditDFVTChange_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxEditDFVTChange_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxEditDFVTChange.Validating
        'This function validates the Value Threshold: Change in Value Value on the Edit Tab
        Try
            '1. make sure a value was entered
            If tboxEditDFVTChange.Text <> "" Then
                '2. make sure value is numeric
                If IsNumeric(tboxEditDFVTChange.Text) Then
                    'valid value -> enable Apply Filter Button
                    btnEditDFApplyFilter.Enabled = True
                Else
                    'show an error box -> value must be numeric
                    MsgBox("Invalid Value Change Threshold Value: Value must be Numeric.")
                    'tboxEditDFVTChange.Text = ""
                    e.Cancel = True
                    'disable Apply Filter Button
                    btnEditDFApplyFilter.Enabled = False
                End If
            Else
                'disable ApplyFilter button
                btnEditDFApplyFilter.Enabled = False
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the Data Filter Value Change Threshold value on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
            'disable ApplyFilter button
            btnEditDFApplyFilter.Enabled = False
        End Try
    End Sub

    Private Sub rbtnEditDFDataGap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnEditDFDataGap.CheckedChanged
        'check to see if value = checked
        If rbtnEditDFDataGap.Checked Then
            'enable Value,TimePeriod
            tboxEditDFDGValue.Enabled = True
            cboxEditDFDGTimePeriod.Enabled = True
            'enable/disable ApplyFilter button
            If tboxEditDFDGValue.Text <> "" AndAlso cboxEditDFDGTimePeriod.SelectedIndex >= 0 Then
                'enable ApplyFilter button
                btnEditDFApplyFilter.Enabled = True
            Else
                'disable ApplyFilter button
                btnEditDFApplyFilter.Enabled = False
            End If
        Else
            'disable Value,TimePeriod
            tboxEditDFDGValue.Enabled = False
            cboxEditDFDGTimePeriod.Enabled = False
        End If
    End Sub

    Private Sub tboxEditDFDGValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxEditDFDGValue.KeyPress
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf
                'return was pressed, validate the value
                tboxEditDFDGValue_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxEditDFDGValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxEditDFDGValue.Validating
        Try
            If tboxEditDFDGValue.Text <> "" Then
                'make sure it is numeric
                If IsNumeric(tboxEditDFDGValue.Text) Then
                    'make sure it is positive
                    If CDbl(tboxEditDFDGValue.Text) > 0 Then
                        'enable OK button if Time Period is selected
                        If cboxEditDFDGTimePeriod.SelectedIndex >= 0 Then
                            'Value must be an integer
                            If tboxEditDFDGValue.Text.Contains(".") Then
                                'show error message
                                MsgBox("Invalid Data Gap Value:  Value must be an Integer (1, 2, 1000, etc.)")
                                'disable ApplyFilter button
                                btnEditDFApplyFilter.Enabled = False
                            Else
                                'enable ApplyFilter button
                                btnEditDFApplyFilter.Enabled = True
                            End If
                        End If
                    Else
                        'disable ApplyFilter button
                        btnEditDFApplyFilter.Enabled = False
                        'show error message
                        MsgBox("Invalid Data Gap Value:  Value must be > 0")
                        'reset so has to change the value
                        e.Cancel = True
                    End If
                Else
                    'disable ApplyFilter button
                    btnEditDFApplyFilter.Enabled = False
                    'show error message
                    MsgBox("Invalid Data Gap Value:  Value must be numeric.")
                    'reset so has to change the value
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the Data Gap Value." & vbCrLf & "Message = " & ex.Message, ex)
            'disable ApplyFilter button
            btnEditDFApplyFilter.Enabled = False
            e.Cancel = True
        End Try
    End Sub

    Private Sub cboxEditDFDGTimePeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxEditDFDGTimePeriod.SelectedIndexChanged
        'check to see if need to enable the OK Button
        If cboxEditDFDGTimePeriod.SelectedIndex >= 0 And tboxEditDFDGValue.Text <> "" Then
            'enable ApplyFilter button
            btnEditDFApplyFilter.Enabled = True
        End If
    End Sub

    'Private Sub rbtnEditDFDGByData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '	If rbtnEditDFDGByData.Checked Then
    '		'TODO: Michelle: Figure out what to do here

    '		'enable ApplyFilter button
    '		btnEditDFApplyFilter.Enabled = True
    '	End If
    'End Sub

    'Private Sub rbtnEditDFDGManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
    '	If rbtnEditDFDGManual.Checked Then
    '		'enable Set Gap button
    '		btnEditDFDGSetGap.Enabled = True
    '		'show a form to allow the user to set gap -> only if no gap has been set for this data
    '		If m_EditDFManualDGValue <= 0 OrElse (m_EditDFManualDGTimePeriod <> EditDGTimePeriods.Minutes And m_EditDFManualDGTimePeriod <> EditDGTimePeriods.Hours And m_EditDFManualDGTimePeriod <> EditDGTimePeriods.Days And m_EditDFManualDGTimePeriod <> EditDGTimePeriods.Months And m_EditDFManualDGTimePeriod <> EditDGTimePeriods.Years) Then
    '			'show the form to set the datagap
    '			btnEditDFDGSetGap_Click(sender, e)
    '		End If

    '		'enable ApplyFilter button
    '		btnEditDFApplyFilter.Enabled = True
    '	Else
    '		btnEditDFDGSetGap.Enabled = False
    '	End If
    'End Sub

    'Private Sub btnEditDFDGSetGap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
    '	Dim fSetDataGap As frmSetDataGap 'instance of frmSetDataGap -> so user can manually specify Data Gap for Data Filter
    '	Try
    '		''TODO: Michelle: remove the message box -> for testing only!!
    '		'MsgBox("setting Data Gap")

    '		'TODO: Michelle: 
    '		'1. Create the SetDataGap form
    '		fSetDataGap = New frmSetDataGap

    '		'2. set existing Values                                                                       
    '		fSetDataGap.dgValue = m_EditDFManualDGValue
    '		fSetDataGap.dgTimePeriod = GetDataGapTimePeriodText(m_EditDFManualDGTimePeriod)
    '		'3. Show the Form, save settings if needed
    '		If (fSetDataGap.ShowDialog = Windows.Forms.DialogResult.OK) Then
    '			'save set values
    '			m_EditDFManualDGValue = fSetDataGap.dgValue
    '			m_EditDFManualDGTimePeriod = GetDataGapTimePeriodEnum(fSetDataGap.dgTimePeriod)

    '			''TODO: Michelle: remove msgbox -> for testing only!!
    '			'MsgBox("Value = " & fSetDataGap.dgValue & vbCrLf & "Time Period = " & fSetDataGap.dgTimePeriod)
    '		End If
    '		'4. release resources
    '		If Not (fSetDataGap) Is Nothing Then
    '			fSetDataGap.Dispose()
    '			fSetDataGap = Nothing
    '		End If

    '		'5.enable apply Filter button
    '		btnEditDFApplyFilter.Enabled = True
    '	Catch ex As Exception
    '		ShowError("An Error occurred while manually setting the Data Gap." & vbCrLf & "Message = " & ex.Message, ex)
    '	End Try
    'End Sub

    Private Sub rbtnEditDFDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnEditDFDate.CheckedChanged
        'check to see if value = checked
        If rbtnEditDFDate.Checked Then
            'enable Before,After checkboxes
            ckboxEditDFDBefore.Enabled = True
            If ckboxEditDFDBefore.Checked Then
                dtpEditDFDBefore.Enabled = True
            End If
            ckboxEditDFDAfter.Enabled = True
            If ckboxEditDFDAfter.Checked Then
                dtpEditDFDAfter.Enabled = True
            End If
            If ckboxEditDFDBefore.Checked Or ckboxEditDFDAfter.Checked Then
                'enable ApplyFilter button
                btnEditDFApplyFilter.Enabled = True
            Else
                'disable ApplyFilter button
                btnEditDFApplyFilter.Enabled = False
            End If
        Else
            ckboxEditDFDBefore.Enabled = False
            dtpEditDFDBefore.Enabled = False
            ckboxEditDFDAfter.Enabled = False
            dtpEditDFDAfter.Enabled = False
        End If
    End Sub

    Private Sub ckboxEditDFDBefore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckboxEditDFDBefore.CheckedChanged
        'check to see if value = checked
        If ckboxEditDFDBefore.Checked Then
            dtpEditDFDBefore.Enabled = True
        Else
            dtpEditDFDBefore.Enabled = False
        End If
        If ckboxEditDFDBefore.Checked Or ckboxEditDFDAfter.Checked Then
            'enable ApplyFilter button
            btnEditDFApplyFilter.Enabled = True
        Else
            'disable ApplyFilter button
            btnEditDFApplyFilter.Enabled = False
        End If
    End Sub

    Private Sub dtpEditDFDBefore_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEditDFDBefore.ValueChanged
        If Not (m_LoadingEditDateRange) And Not (m_LoadingEditTab) Then
            'enable the ApplyFilter Button -> new value selected
            btnEditDFApplyFilter.Enabled = True
        End If
    End Sub

    Private Sub ckboxEditDFDAfter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckboxEditDFDAfter.CheckedChanged
        'check to see if value = checked
        If ckboxEditDFDAfter.Checked Then
            dtpEditDFDAfter.Enabled = True
        Else
            dtpEditDFDAfter.Enabled = False
        End If
        If ckboxEditDFDBefore.Checked Or ckboxEditDFDAfter.Checked Then
            'enable ApplyFilter button
            btnEditDFApplyFilter.Enabled = True
        Else
            'disable ApplyFilter button
            btnEditDFApplyFilter.Enabled = False
        End If
    End Sub

    Private Sub dtpEditDFDAfter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEditDFDAfter.ValueChanged
        If Not (m_LoadingEditDateRange) And Not (m_LoadingEditTab) Then
            'enable the ApplyFilter Button -> new value selected
            btnEditDFApplyFilter.Enabled = True
        End If
    End Sub

    Private Sub btnEditDFClearSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDFClearSel.Click
        Try
            '1. Clear selection
            ClearEditSelection() 'NOTE: this function disables Edit Functionality until something is selected

            ''2. disable me because selection = cleared
            'btnEditDFClearSel.Enabled = False
        Catch ex As Exception
            ShowError("An Error occurred while Clearing the Selected Points on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnEditDFApplyFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDFApplyFilter.Click
        Dim method As String
        Try
            '1. Clear any previous selection
            ClearEditSelection() 'NOTE: this function disables Edit Functionality until something is selected, and also clears out m_EditSelPtIndexes
            btnEditDFClearSel.Enabled = False

            '2. Get the Indexes of the values to select
            Select Case True
                Case rbtnEditDFValueThreshold.Checked
                    If ckboxEditDFVTGreater.Checked AndAlso ckboxEditDFVTLess.Checked Then
                        method = m_EditDFMethod_Both
                    ElseIf ckboxEditDFVTGreater.Checked Then
                        method = m_EditDFVTMethod_Greater
                    ElseIf ckboxEditDFVTLess.Checked Then
                        method = m_EditDFVTMethod_Less
                    Else
                        'error -> exit sub
                        m_EditSelPtIndexes.Clear()
                        Exit Select
                    End If

                    'NOTE: this function will only pay attention to needed values (greater, less)
                    'AND it will put the matching indexes into m_EditSelPtIndexes
                    FindValueThresholdIndexes(method, tboxEditDFVTGreater.Text, tboxEditDFVTLess.Text)
                Case rbtnEditDFDate.Checked
                    If ckboxEditDFDBefore.Checked AndAlso ckboxEditDFDAfter.Checked Then
                        method = m_EditDFMethod_Both
                    ElseIf ckboxEditDFDBefore.Checked Then
                        method = m_EditDFDMethod_Before
                    ElseIf ckboxEditDFDAfter.Checked Then
                        method = m_EditDFDMethod_After
                    Else
                        'error -> exit sub
                        m_EditSelPtIndexes.Clear()
                        Exit Select
                    End If

                    'NOTE: this function will only pay attention to needed values (greater, less)
                    'AND it will put the matching indexes into m_EditSelPtIndexes
                    FindDateIndexes(method, dtpEditDFDBefore.Value, dtpEditDFDAfter.Value)
                Case rbtnEditDFVTChange.Checked
                    'NOTE: it will put the matching indexes into m_EditSelPtIndexes
                    FindValueChangeThresholdIndexes(tboxEditDFVTChange.Text)
                Case rbtnEditDFDataGap.Checked
                    Dim timeGap As TimeSpan
                    Dim val As Integer
                    val = CInt(tboxEditDFDGValue.Text)
                    Select Case GetDataGapTimePeriodEnum(cboxEditDFDGTimePeriod.Text)
                        '	Case rbtnEditDFDGByData.Checked
                        '		timeGap = CalculateTimeGapFromData()
                        '	Case rbtnEditDFDGManual.Checked
                        '		Select Case m_EditDFManualDGTimePeriod
                        Case enumEditDGTimePeriods.Minutes
                            timeGap = New TimeSpan(0, val, 0)
                        Case enumEditDGTimePeriods.Hours
                            timeGap = New TimeSpan(val, 0, 0)
                        Case enumEditDGTimePeriods.Days
                            timeGap = New TimeSpan(val, 0, 0, 0)
                        Case enumEditDGTimePeriods.Months
                            timeGap = ((New DateTime()).AddMonths(val)).Subtract(New DateTime())
                        Case enumEditDGTimePeriods.Years
                            timeGap = New DateTime(CInt(val), 1, 1).Subtract(New DateTime())
                            'End Select
                        Case Else
                            'error -> set times span = 0
                            m_EditSelPtIndexes.Clear()
                            timeGap = TimeSpan.Zero
                    End Select

                    If (timeGap.CompareTo(TimeSpan.Zero) > 0) Then '<0 = less, 0 = equal, >0 = greater
                        'NOTE: it will put the matching indexes into m_EditSelPtIndexes
                        FindDataGapIndexes(timeGap)
                    Else
                        'not able to find indexes, return nothing
                        m_EditSelPtIndexes.Clear()
                    End If
            End Select
            'validate data 
            If (m_EditSelPtIndexes Is Nothing) OrElse m_EditSelPtIndexes.Count = 0 Then
                'unable to continue -> no Indexes selected
                MsgBox("No points were found to select." & vbCrLf & "Please adjust your Filter settings and try again.")
                Exit Try
            End If

            '3. select new data 
            SelectEditValues() 'NOTE: this function enables Edit Functionality -> something is NOW selected, it also enables the Clear Selection button if can

            '4. disable me-> until they make an edit, or change the filter
            btnEditDFApplyFilter.Enabled = False
        Catch ex As Exception
            ShowError("An Error occurred while Applying the Selected Data Filter to the points on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub


#End Region

#Region " Data Edit Functions "

    Private Sub btnEditDataAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDataAdjust.Click
        'Opens the AdjustValues form then applies the adjustment to the EditTab Data
        'Inputs: frmAdjustValues form
        'Outputs: Adjusts the data
        Try
            '1. If valid Points were selected...
            If m_EditHavePointsSelected Then
                m_EditSelPtIndexes.Sort()
                Dim fAdjustValues As New frmAdjustValues() 'Value Adjust Form
                fAdjustValues.Owner = Me
                'Select the Adjustment type
                If fAdjustValues.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    'Adjust based on type of adjustment selected
                    Select Case fAdjustValues.m_adjustType
                        Case frmAdjustValues.adjustTypes.ADD 'Add a numeric constant
                            AdjustValAdd(fAdjustValues.m_adjustValue)
                        Case frmAdjustValues.adjustTypes.MULTIPLY 'Multiply by a numeric constant
                            AdjustValMultiply(fAdjustValues.m_adjustValue)
                        Case frmAdjustValues.adjustTypes.DRIFT 'Apply a linear drift correction
                            AdjustValDrift(fAdjustValues.m_adjustValue)
                    End Select

                    'update the y-values, bounds in the plot
                    'UpdateYValForSelPtsInPlot()
                    UpdateZedGraphPlotBounds(zg5EditPlot, m_EditData, m_EditNoDataVal)

                    'set that have edits uncommitted to the database
                    m_EditHaveEditsUncommitted = True
                    btnEditApplyChanges.Enabled = True
                End If
            End If
        Catch ex As Exception
            ShowError("Error Adjusting Values" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnEditDataInterpolate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDataInterpolate.Click
        Dim numVals As Integer
        Dim newVals As Double()
        Dim errorMsg As String
        Dim i As Integer
        Try
            '1. Check to see if anything was selected
            If Not (m_EditHavePointsSelected) Then
                'show a message box -> let user know something needs to be selected
                MsgBox("Cannot Interpolate Values:  No points were selected to interpolate" & vbCrLf & "Please select one or more points to interpolate first.")
                'exit
                Exit Try
            End If

            '2. Check to see if the first or last value was selected
            'make sure m_EditSelPtIndexes is correctly ordered
            m_EditSelPtIndexes.Sort()
            If m_EditSelPtIndexes.Contains(0) OrElse m_EditSelPtIndexes.Contains(dgvEditTable.Rows.Count - 1) Then
                'either the first or last point is selected, can't interpolate if one or both is selected
                'show error message
                MsgBox("Cannot Interpolate the First or Last value(s) in the Data Series" & vbCrLf & "You will have to fix your selection before continuing.")
                'exit 
                Exit Try
            End If

            '3. Interpolate points
            If Not (InterpolatePoints(newVals, errorMsg)) Then
                MsgBox("Cannot Interpolate selected points:  " & errorMsg)
                'exit
                Exit Try
            End If

            '4. Update Table
            numVals = newVals.Length
            For i = 0 To numVals - 1
                m_EditData.Rows(m_EditSelPtIndexes(i)).Item(db_fld_ValValue) = newVals(i)
                m_EditData_Graphing.Rows(m_EditSelPtIndexes(i)).Item(db_fld_ValValue) = newVals(i)
            Next i

            '5. Update Plot
            'UpdateYValForSelPtsInPlot()

            UpdateZedGraphPlotBounds(zg5EditPlot, m_EditData, m_EditNoDataVal)

            '6. Mark that edits were made
            m_EditHaveEditsUncommitted = True

            '7. enable/disable apply,restore buttons
            btnEditApplyChanges.Enabled = True

            ResetPlotBounds()
        Catch ex As Exception
            ShowError("An Error occurred while when Interpolated Values was selected on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnEditDataFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDataFlag.Click
        'Edits the Qualifier flag on selected data
        'Inputs: frmEditFlagValues form
        'Outputs: Changes the Qualifier flag of the selected data
        Try
            '1. If valid points are selected...
            If m_EditHavePointsSelected Then
                Dim fFlagVals As New frmEditFlagValues() 'Value Flagging Form
                Dim i As Integer 'Counter Variable
                Dim qualifierID As Integer 'Qualifier ID to flag values with
                fFlagVals.Owner = Me
                'Select a qualifier
                If fFlagVals.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    qualifierID = GetQualifierIDFromDB(fFlagVals.m_QualifierCode, fFlagVals.m_QualifierDesc)
                    'Apply the qualifier changes to dvgEditTable
                    For i = 0 To m_EditSelPtIndexes.Count - 1
                        m_EditData.Rows(CInt(m_EditSelPtIndexes(i))).Item(db_fld_QlfyID) = qualifierID
                        m_EditData_Graphing.Rows(CInt(m_EditSelPtIndexes(i))).Item(db_fld_QlfyID) = qualifierID
                    Next

                    'set that have edits uncommitted to the database
                    m_EditHaveEditsUncommitted = True
                    btnEditApplyChanges.Enabled = True
                End If
            End If
        Catch ex As Exception
            ShowError("Error Flagging Values" & vbCrLf & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnEditDataRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDataRemove.Click
        'This function deletes the selected values 
        Dim errorMsg As String
        Dim beginDate As DateTime
        Dim endDate As DateTime
        Dim beginUTCDate As DateTime
        Dim endUTCDate As DateTime
        Dim valCount As Integer
        Dim vcIndex As Integer = 15
        Dim dtIndex As Integer = 13
        Dim utcDTIndex As Integer = 14
        'NOTE: Colums for lvEditData Series:
        'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description, Citation, Local Date Range, UTC Date Range, Value Count
        Try
            '1. show message box -> make sure user REALLY wants to delete the values
            If MsgBox("Are you sure that you want to DELETE the selected values?", MsgBoxStyle.YesNo, "Delete Values") = MsgBoxResult.Yes Then
                'set that deleting points
                m_EditDeletingVals = True

                '2. remove points from Table, get/reset Derived From values for these ValueIDs
                If Not (DeleteEditSelPtsFromTable(errorMsg)) Then
                    'show error message
                    MsgBox("Unable To continue Deleting Points: " & errorMsg)
                    'exit
                    Exit Try
                End If

                '3.remove points from plot or Replot Data

                'clear out sel Pts, no longer selected!! -> NOTE: doing this so errors won't occur when ClearEditSelection is called!!
                m_EditSelPtIndexes.Clear()

                'reset
                m_EditDeletingVals = False

                '4. clear selection 
                ClearEditSelection() 'NOTE: this function disables Edit Functionality until something is selected
                're-enable Add functionality
                btnEditDataAdd.Enabled = True 'NOTE: don't have to check for if level 0, because Deletion would not be possible if Data Series = Level 0

                '5. Update the List View for the Selected Data Series -> Date/Time, UTC Date/Time, and Value Count
                'calculate new Value Count
                valCount = dgvEditTable.RowCount
                'calculate new Date range
                beginDate = m_EditData.Compute("MIN(" & db_fld_ValDateTime & ")", "")
                endDate = m_EditData.Compute("MAX(" & db_fld_ValDateTime & ")", "")
                'calculate new UTC Date range
                beginUTCDate = m_EditData.Compute("MIN(" & db_fld_ValUTCDateTime & ")", "")
                endUTCDate = m_EditData.Compute("MAX(" & db_fld_ValUTCDateTime & ")", "")
                'update the list view
                lvEditDataSeries.SelectedItems(0).SubItems(vcIndex).Text = valCount
                lvEditDataSeries.SelectedItems(0).SubItems(dtIndex).Text = beginDate.ToString & " - " & endDate.ToString
                lvEditDataSeries.SelectedItems(0).SubItems(utcDTIndex).Text = beginUTCDate.ToString & " - " & endUTCDate.ToString

                '6. Reload the Data Filter -> Date Range
                If Not (LoadEditDataFilterDateRange()) Then
                    'disable Date Data Filter
                    gboxEditDFDate.Enabled = False
                    rbtnEditDFDate.Enabled = False
                Else
                    'enable Date Data Filter
                    gboxEditDFDate.Enabled = True
                    rbtnEditDFDate.Enabled = True
                End If

                '7. update plot bounds
                UpdateZedGraphPlotBounds(zg5EditPlot, m_EditData, m_EditNoDataVal)

                '7. set that have edits uncommitted to database 
                m_EditHaveEditsUncommitted = True

                '8. enable Restore defaults, apply changes buttons
                btnEditApplyChanges.Enabled = True

                ResetPlotBounds()
            End If
        Catch ex As Exception
            ShowError("An Error occured while deleting the selected points on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnEditDataAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDataAdd.Click
        'Adds a new point with given values
        'Inputs: frmAddNewValue
        'Outputs: adds the new value to the selected Data Series
        Dim loc As Integer 'Location to add the new point
        Dim offsetType As String = GetOffsetTypeFromDB(m_EditData.Rows(0).Item(db_fld_ValOffsetTypeID)) 'The offset type of the selected Data Series
        Dim offsetUnits As String = GetOffsetUnitsFromDB(m_EditData.Rows(0).Item(db_fld_ValOffsetTypeID)) 'THe offset Units of the selected Data Series
        Dim addValues As New frmAddNewValue(offsetType, offsetUnits) 'Value Add Form
        Dim tempRow As DataRow 'New row of data to add
        Dim siteName, variableName, variableUnits As String 'Information about the point to add
        Dim db_MaxValID, m_MaxValID As Integer 'Value IDs to refrence the new Value

        '1. Set Adding Values = true
        m_EditAddingVals = True

        Try
            addValues.Owner = Me
            'Select the Data to add
            If addValues.ShowDialog() = Windows.Forms.DialogResult.OK Then

                '2. Create the datatable row, format, and add data
                tempRow = m_EditData.NewRow
                db_MaxValID = GetMaxValIDFromDB()
                db_MaxValID = m_EditData.Compute("MAX(" & db_fld_ValID & ")", "")
                If db_MaxValID > m_MaxValID Then
                    tempRow.Item(db_fld_ValID) = db_MaxValID + 1
                Else
                    tempRow.Item(db_fld_ValID) = m_MaxValID + 1
                End If
                tempRow.Item(db_fld_ValValue) = addValues.m_DataValue
                tempRow.Item(db_fld_ValDateTime) = FormatDateForInsertIntoDB(addValues.m_DateTime)
                tempRow.Item(db_fld_ValUTCOffset) = addValues.m_UtcOffset
                tempRow.Item(db_fld_ValUTCDateTime) = FormatDateForInsertIntoDB(addValues.m_UtcDateTime)
                tempRow.Item(db_fld_ValCensorCode) = addValues.m_CensorCode
                If addValues.m_QualifierID > -1 Then
                    tempRow.Item(db_fld_ValQualifierID) = addValues.m_QualifierID
                End If
                If addValues.m_SampleID > -1 Then
                    tempRow.Item(db_fld_ValSampleID) = addValues.m_SampleID
                End If
                tempRow.Item(db_fld_ValSiteID) = m_EditData.Rows(0).Item(db_fld_ValSiteID)
                tempRow.Item(db_fld_ValVarID) = m_EditData.Rows(0).Item(db_fld_ValVarID)
                tempRow.Item(db_fld_ValMethodID) = m_EditData.Rows(0).Item(db_fld_ValMethodID)
                tempRow.Item(db_fld_ValSourceID) = m_EditData.Rows(0).Item(db_fld_ValSourceID)
                tempRow.Item(db_fld_ValQCLevel) = m_EditData.Rows(0).Item(db_fld_ValQCLevel)
                tempRow.Item(db_fld_ValOffsetTypeID) = m_EditData.Rows(0).Item(db_fld_ValOffsetTypeID)
                If Not (m_EditData.Rows(0).Item(db_fld_ValOffsetTypeID) Is DBNull.Value) Then
                    tempRow.Item(db_fld_ValOffsetValue) = addValues.m_OffsetValue
                End If
                tempRow.Item(db_fld_ValAccuracyStdDev) = m_EditData.Rows(0).Item(db_fld_ValAccuracyStdDev)

                '8. Reset Date Filter Maxs and Mins
                If addValues.m_DateTime < dtpEditDFDAfter.MinDate Then
                    dtpEditDFDBefore.MinDate = addValues.m_DateTime
                    dtpEditDFDAfter.MinDate = addValues.m_DateTime
                End If
                If addValues.m_DateTime > dtpEditDFDBefore.MaxDate Then
                    dtpEditDFDBefore.MaxDate = addValues.m_DateTime
                    dtpEditDFDAfter.MaxDate = addValues.m_DateTime
                End If

                '3. Find Location to add new point.
                While ((loc < m_EditData.Rows.Count) AndAlso (m_EditData.Rows(loc).Item(db_fld_ValDateTime) < addValues.m_DateTime))
                    loc += 1
                End While

                '4. Add new point
                Dim tempGRow As DataRow = m_EditData_Graphing.NewRow()
                tempGRow.ItemArray() = tempRow.ItemArray
                m_EditData_Graphing.Rows.InsertAt(tempGRow, loc)
                m_EditData.Rows.InsertAt(tempRow, loc)


                '5. Get Needed info from selected series, then graph data with new point
                siteName = cboxEditSite.Text
                variableName = cboxEditVariable.Text
                variableUnits = GetAbbreviatedVariableUnitsFromDB(lvEditDataSeries.SelectedItems(0).SubItems(1).Text)

                '6. De-Select points in the table
                While dgvEditTable.SelectedRows.Count > 0
                    dgvEditTable.SelectedRows(0).Selected = False
                End While
                m_EditSelPtIndexes.Clear()

                '7. Select new point
                m_EditSelPtIndexes.Add(loc)
                SelectEditValues()

                'NOTE: Don't need to update Plot Bounds -> replotted all of data, so already correct!!

                '8. Set that have edits uncommitted to the database
                m_EditHaveEditsUncommitted = True
                btnEditApplyChanges.Enabled = True

                ResetPlotBounds()
            End If
        Catch ex As Exception
            ShowError("An Error occurred while Adding a New Value to the selected Data series on the Edit Tab" & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        '9. Done Adding Values
        m_EditAddingVals = False
    End Sub

    Private Sub btnEditDataDeriveNewDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDataDeriveNewDS.Click
        Dim fDeriveDS As frmDeriveNewDataSeries
        Dim dsIDs As clsDataSeriesIDs
        Dim varUnits As String
        Dim sampleMed As String
        Dim genCategory As String
        Dim tsValue As Double
        Dim tsUnits As String
        Dim valueType As String
        Dim dataType As String
        Dim organization As String
        Dim sourceDesc As String
        'Dim methodDesc As String
        'NOTE: Colums for lvEditData Series:
		
        'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description, Citation, Local Date Range, UTC Date Range, Value Count
        Dim varUnitsID As Integer = 2
        Dim sampleMedID As Integer = 5
        Dim genCatID As Integer = 0		
        Dim tsValueID As Integer = 3
        Dim tsUnitsID As Integer = 4
        Dim valueTypeID As Integer = 6
        Dim dataTypeID As Integer = 7
        Dim orgID As Integer = 10
        Dim sourceDescID As Integer = 11
        'Dim methodDescID As Integer = 9
        Dim speciationID As Integer = 1
        Dim citationID As Integer = 12
        Dim speciation As String
        Dim citation As String
        Try
            '1. see if any edits are uncommitted
            If m_EditHaveEditsUncommitted Then
                If MsgBox("There are edits for the current Data Series that have not been committed, would you like them to be applied (saved) to the Database?" & vbCrLf & vbCrLf & "NOTE: IF you select NO then none of your changes will saved!!", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Apply Edits to Database
                    btnEditApplyChanges_Click(Me, New System.EventArgs)
                Else
                    'set that no edit are uncommitted
                    m_EditHaveEditsUncommitted = False
                    m_EditHaveDeletedValIDs = False
                    If Not (m_EditDeletedValIDs Is Nothing) Then
                        m_EditDeletedValIDs.Clear()
                    End If
                    
                    'm_EditHaveRemoveDFIDs = False
                    'If Not (m_EditRemoveDFIDs Is Nothing) Then
                    '    m_EditRemoveDFIDs.Clear()
                    'End If
                    'reload current data series
                    'lvEditDataSeries_SelectedIndexChanged(Me, New System.EventArgs())
                    cboxEditVariable_SelectedIndexChanged(Me, New System.EventArgs())
                End If
            End If
            '1. Get Data series info, so can derive a new one
            dsIDs = m_EditIDs(lvEditDataSeries.SelectedItems(0).Index)
            speciation = lvEditDataSeries.SelectedItems(0).SubItems(speciationID).Text
            varUnits = lvEditDataSeries.SelectedItems(0).SubItems(varUnitsID).Text
            sampleMed = lvEditDataSeries.SelectedItems(0).SubItems(sampleMedID).Text
            genCategory = lvEditDataSeries.SelectedItems(0).SubItems(genCatID).Text
            tsValue = CDbl(lvEditDataSeries.SelectedItems(0).SubItems(tsValueID).Text)
            tsUnits = lvEditDataSeries.SelectedItems(0).SubItems(tsUnitsID).Text
            valueType = lvEditDataSeries.SelectedItems(0).SubItems(valueTypeID).Text
            dataType = lvEditDataSeries.SelectedItems(0).SubItems(dataTypeID).Text
            organization = lvEditDataSeries.SelectedItems(0).SubItems(orgID).Text
            sourceDesc = lvEditDataSeries.SelectedItems(0).SubItems(sourceDescID).Text
            'methodDesc = lvEditDataSeries.SelectedItems(0).SubItems(methodDescID).Text
            citation = lvEditDataSeries.SelectedItems(0).SubItems(citationID).Text
            '2. Create instance of frmDeriveNewDataSeries
            fDeriveDS = New frmDeriveNewDataSeries(dsIDs, cboxEditSite.Text, cboxEditVariable.Text, speciation, varUnits, sampleMed, genCategory, tsValue, tsUnits, valueType, dataType, organization, sourceDesc, citation)
            Me.AddOwnedForm(fDeriveDS)
            '3. Show the form,If Cancel = do nothing, 
            If fDeriveDS.ShowDialog = Windows.Forms.DialogResult.OK Then
                '4. load the newly created Data Series

                ''TODO: Remove msgbox -> for testing only!!
                'MsgBox("Loading the Newly Created Data Series")

                'clear/reset the plot,table
                InitializeEditTab()

                'reload the available Data Series
                Dim siteCode As String = Split(cboxEditSite.Text, " - ")(0)
                Dim siteName As String = Split(cboxEditSite.Text, " - ")(1)
                Dim varCode As String = Split(fDeriveDS.cboxVariable.Text, " - ")(0)
                Dim varName As String = Split(fDeriveDS.cboxVariable.Text, " - ")(1)
                Dim i As Integer 'counter
                Dim varSelID As Integer = -1

                'make sure correct variable is loaded
                If varCode <> Split(cboxEditVariable.Text, " - ")(0) OrElse varName <> Split(cboxEditVariable.Text, " - ")(1) Then
                    'select the correct variable, this should load the new data series
                    For i = 0 To cboxEditVariable.Items.Count - 1
                        If varCode = Split(cboxEditVariable.Items(i), " - ")(0) Then
                            varSelID = i
                            i = cboxEditVariable.Items.Count
                        End If
                    Next i
                    If varSelID < 0 Then
                        'reload variables, a new variable for this site must have been used
                        LoadEditVariables(siteCode, siteName)
                        'select the correct variable, this should load the new data series
                        For i = 0 To cboxEditVariable.Items.Count - 1
                            If varCode = Split(cboxEditVariable.Items(i), " - ")(0) Then
                                varSelID = i
                                i = cboxEditVariable.Items.Count
                            End If
                        Next i
                    End If
                    cboxEditVariable.SelectedIndex = varSelID
                Else
                    'reload the data series for the selected variable
                    LoadEditDataSeries(siteCode, siteName, varCode, varName)
                End If

                'select the one just created
                Dim selIndex As Integer = -1
                Dim numItems As Integer = 0
                Dim newSeriesID As Integer = fDeriveDS.m_NewSeriesID


                'make sure 
                numItems = lvEditDataSeries.Items.Count
                If numItems > 0 Then
                    'figure out which index is the newly created Data Series
                    selIndex = -1
                    For i = 0 To numItems - 1
                        If CType(m_EditIDs(i), clsDataSeriesIDs).SeriesID = newSeriesID Then
                            selIndex = i
                            Exit For
                        End If
                    Next i
                    'select the correct data series, if it was found
                    If selIndex >= 0 Then
                        lvEditDataSeries.Items(selIndex).Selected = True
                    End If
                End If

                'reset other tabs (Query,Vis) so load new/edit data series correctly!!
                m_VisualizeTabLoaded = False
                m_qryTabLoaded = False
            Else
                'reload the current selected Data Series -> just in case they didn't save changes
                lvEditDataSeries_SelectedIndexChanged(Me, New System.EventArgs())
            End If
            'remove owned form
            Me.RemoveOwnedForm(fDeriveDS)
            'release resources
            If Not (fDeriveDS Is Nothing) Then
                fDeriveDS.Dispose()
                fDeriveDS = Nothing
            End If
        Catch ex As Exception
            ShowError("An Error occurred while deriving a new Data Series on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnEditRestoreDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditRestoreDefaults.Click
        Try
            '1. Make sure that the user really wants to do this!!
            If MsgBox("Are you sure that you want to discard all changes that have been made, and restore the original data from the Database?", MsgBoxStyle.YesNo, "Restore Changes From Database") = MsgBoxResult.Yes Then
                '2. Restore Defaults
                RestoreEditDefaultsFromDB()
            End If
        Catch ex As Exception
            ShowError("An Error occurred when Restoring Defaults From Database was selected on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnEditApplyChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditApplyChanges.Click
        Dim errorMsg As String
        Try
            '1. Apply edits to database
            If Not (ApplyEditsToDatabase(m_EditIDs(lvEditDataSeries.SelectedItems(0).Index), errorMsg)) Then
                MsgBox("Unable to Apply the Changes To the Database: " & vbCrLf & errorMsg)
                'exit
                Exit Try
            End If

            '2. Reset Visualize,Query tabs so will reload when selected with updated data
            m_VisualizeTabLoaded = False
            m_qryTabLoaded = False

            '3. Reset Me, Restore Defaults From Database
            btnEditApplyChanges.Enabled = False
        Catch ex As Exception
            ShowError("An Error occurred when the Apply Changes To Database button was selected on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

    '#Region " Plot Functions "

    '    Private Sub zg5EditPlot_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles zg5EditPlot.Paint
    '        'Used to ensure the plots are redrawn when the form is redrawn
    '        zg5EditPlot.GraphPane.Draw(e.Graphics)
    '    End Sub

    '    Private Sub zg5BoxPlot_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles zg5BoxPlot.Paint
    '        'Used to ensure the plots are redrawn when the form is redrawn
    '        zg5BoxPlot.GraphPane.Draw(e.Graphics)
    '    End Sub

    '    Private Sub zg5Histogram_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles zg5Histogram.Paint
    '        'Used to ensure the plots are redrawn when the form is redrawn
    '        zg5Histogram.GraphPane.Draw(e.Graphics)
    '    End Sub

    '    Private Sub zg5Probability_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles zg5Probability.Paint
    '        'Used to ensure the plots are redrawn when the form is redrawn
    '        zg5Probability.GraphPane.Draw(e.Graphics)
    '    End Sub

    '    Private Sub zg5TimeSeries_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles zg5TimeSeries.Paint
    '        'Used to ensure the plots are redrawn when the form is redrawn
    '        zg5TimeSeries.GraphPane.Draw(e.Graphics)
    '    End Sub

    '#End Region

#End Region

#Region " Edit Tab: Loading Functions "

#Region " Data selection Loading Functions "

    Private Function LoadEditSites() As Boolean
        'This function Loads the Sites from the Series Catalog Table into the Visualize Tab for plotting
        'Inputs:  None
        'Outputs: Boolean -> tracks if sites were successfully retrieved from the Series Catalog in the database
        Dim i As Integer 'counter
        Dim siteDT As Data.DataTable 'Datatable to hold the Sites retrieved and loaded from the Series Catalog Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Dim siteName As String 'the SiteName value retrieved from the Database -> used to add it to cboxVisSite
        Dim siteCode As String 'the SiteCode value retrieved from the Database -> used to add it to cboxVisSite
        Try
            '1. clear out any old data 
            cboxEditSite.Items.Clear()
            cboxEditSite.Text = ""

            '2. Connect to the database
            query = "SELECT DISTINCT " & db_fld_SCSiteCode & ", " & db_fld_SCSiteName & " FROM " & db_tbl_SeriesCatalog & " ORDER BY " & db_fld_SCSiteCode

            siteDT = OpenTable("EditSitesDT", query, g_CurrConnSettings)
            If (siteDT Is Nothing) OrElse siteDT.Rows.Count = 0 Then

                'release resources
                If Not (siteDT Is Nothing) Then
                    siteDT.Dispose()
                    siteDT = Nothing
                End If

                'return false -> no values were added
                Return True
            End If

            '3. get the Sites from the Series Catalog Table,load the Sites into cboxSites
            For i = 0 To siteDT.Rows.Count - 1
                If Not (siteDT.Rows(i).Item(db_fld_SCSiteCode) Is DBNull.Value) Then
                    siteCode = siteDT.Rows(i).Item(db_fld_SCSiteCode)
                Else
                    siteCode = " "
                End If
                If Not (siteDT.Rows(i).Item(db_fld_SCSiteName) Is DBNull.Value) Then
                    siteName = siteDT.Rows(i).Item(db_fld_SCSiteName)
                Else
                    siteName = " "
                End If
                cboxEditSite.Items.Add(siteCode & " - " & siteName)
            Next i

            '4. release resources
            If Not (siteDT Is Nothing) Then
                siteDT.Dispose()
                siteDT = Nothing
            End If

            Return True
        Catch ex As Exception
            ShowError("An Error occurred while loading the Sites on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (siteDT Is Nothing) Then
            siteDT.Dispose()
            siteDT = Nothing
        End If
        Return False
    End Function

    Private Function LoadEditVariables(ByVal siteCode As String, ByVal siteName As String) As Boolean
        'This function loads the Variables for the selected Site from the Series Catalog into the Edit Tab
        'Inputs:  siteCode -> the Code for the selected Site
        '         siteName -> the Name for the selected Site
        'Outputs: Boolean -> tracks if the Variables were successfully retrieved and loaded for the selected Site from the Series Catalog Table in the Database
        Dim i As Integer 'counter
        Dim varDT As Data.DataTable 'Datatable to hold the Variables retrieved from the Series Catalog Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Dim varName As String 'the SiteName value retrieved from the Database -> used to add it to cboxVisSite
        Dim varCode As String 'the SiteCode value retrieved from the Database -> used to add it to cboxVisSite
        Try
            '1. clear out any old data 
            cboxEditVariable.Items.Clear()
            cboxEditVariable.Text = ""

            '2. Connect to the database
            query = "SELECT DISTINCT " & db_fld_SCVarCode & ", " & db_fld_SCVarName & " FROM " & db_tbl_SeriesCatalog & " WHERE (" & db_fld_SCSiteCode & " = '" & FormatStringForQueryFromDB(siteCode) & "' AND " & db_fld_SCSiteName & " = '" & FormatStringForQueryFromDB(siteName) & "') ORDER BY " & db_fld_SCVarCode

            varDT = OpenTable("EditVarsDT", query, g_CurrConnSettings)
            If (varDT Is Nothing) OrElse varDT.Rows.Count = 0 Then

                'release resources
                If Not (varDT Is Nothing) Then
                    varDT.Dispose()
                    varDT = Nothing
                End If

                'return false -> no values were added
                Exit Try
            End If

            '3. get the Sites from the Series Catalog Table,load the Sites into cboxSites
            For i = 0 To varDT.Rows.Count - 1
                If Not (varDT.Rows(i).Item(db_fld_SCVarCode) Is DBNull.Value) Then
                    varCode = varDT.Rows(i).Item(db_fld_SCVarCode)
                Else
                    varCode = " "
                End If
                If Not (varDT.Rows(i).Item(db_fld_SCVarName) Is DBNull.Value) Then
                    varName = varDT.Rows(i).Item(db_fld_SCVarName)
                Else
                    varName = " "
                End If
                cboxEditVariable.Items.Add(varCode & " - " & varName)
            Next i

            '4. release resources
            If Not (varDT Is Nothing) Then
                varDT.Dispose()
                varDT = Nothing
            End If

            Return True
        Catch ex As Exception
            ShowError("An Error occurred while loading the Variables on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (varDT Is Nothing) Then
            varDT.Dispose()
            varDT = Nothing
        End If
        Return False
    End Function

    Friend Function LoadEditDataSeries(ByVal siteCode As String, ByVal siteName As String, ByVal varCode As String, ByVal varName As String) As Boolean
        'This function loads the Data Series for the selected Site and Variable into the Visualize Tab
        'Inputs:  siteCode -> the Code for the selected Site
        '         siteName -> the Name for the selected Site
        '         varCode -> the Code for the selected Variable
        '         varName -> the Name for the selected Variable
        'Outputs: Boolean -> Tracks if the Data Series were successfully retrieved and loaded from the Series Catalog Table in the Database
        Dim i As Integer 'counter
        Dim dataSeriesDT As Data.DataTable 'Datatable to hold the Variables retrieved from the Series Catalog Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Dim lvItem As ListViewItem 'list view item so can add the data from the database to lvVisDataSeries
        Dim varUnits As String 'the VariableUnitsName value retrieved from the database -> added to lvVisDataSeries
        Dim sampleMed As String 'the SampleMedium value retrieved from the database -> added to lvVisDataSeries
        Dim valueType As String 'the ValueType value retrieved from the database -> added to lvVisDataSeries
        Dim timeSupport As String 'the TimeSupport value retrieved from the database -> added to lvVisDataSeries
        Dim timeUnits As String 'the TimeUnitsName value retrieved from the database -> added to lvVisDataSeries
        Dim dataType As String 'the DataType value retrieved from the database -> added to lvVisDataSeries
        Dim genCategory As String 'the GeneralCategory value retrieved from the database -> added to lvVisDataSeries
        Dim beginDateLocal As DateTime 'the BeginDateTime value retrieved from the database -> added to lvVisDataSeries
        Dim endDateLocal As DateTime 'the EndDateTime value retrieved from the database -> added to lvVisDataSeries
        'Dim utcOffset As String 'the UTCOffset value retrieved from the database -> added to lvVisDataSeries
        Dim beginDateUTC As DateTime
        Dim endDateUTC As DateTime
        Dim valueCount As Integer 'the ValueCount value retrieved from the database -> added to lvVisDataSeries
        Dim currEditIDs As clsDataSeriesIDs 'the clsVisualizeIDs item to add the current set of SiteID, VariableID values to m_VisualizeIDs
        Dim seriesID As Integer
        Dim siteID As Integer 'the SiteID value retrieved from the database -> added to lvVisDataSeries
        Dim varID As Integer 'the VariableID value retrieved from the database -> added to lvVisDataSeries
        Dim methodID As Integer
        Dim methodDesc As String
        Dim qcLevelID As Integer
        Dim organization As String
        Dim sourceID As Integer
        Dim sourceDesc As String
        Dim qcLevelCode As String
        Dim qcLevelDef As String
        Dim speciation As String
        Dim citation As String
        Try
            '1. clear out any old data 
            lvEditDataSeries.Items.Clear()
            If Not (m_EditIDs Is Nothing) Then
                m_EditIDs.Clear()
            Else
                m_EditIDs = New System.Collections.ArrayList
            End If

            '2. Connect to the database
            query = "SELECT * FROM " & db_tbl_SeriesCatalog & " WHERE (" & db_fld_SCSiteCode & " = '" & FormatStringForQueryFromDB(siteCode) & "' AND " & db_fld_SCSiteName & " = '" & FormatStringForQueryFromDB(siteName) & "' AND " & db_fld_SCVarCode & " = '" & FormatStringForQueryFromDB(varCode) & "' AND " & db_fld_SCVarName & " = '" & FormatStringForQueryFromDB(varName) & "') ORDER BY " & db_fld_SCSiteID & ", " & db_fld_SCVarID

            dataSeriesDT = OpenTable("EditDataSeriesDT", query, g_CurrConnSettings)
            If (dataSeriesDT Is Nothing) OrElse dataSeriesDT.Rows.Count = 0 Then

                'release resources
                If Not (dataSeriesDT Is Nothing) Then
                    dataSeriesDT.Dispose()
                    dataSeriesDT = Nothing
                End If

                'return false -> no values were added
                Return True
            End If

            '3. get the Sites from the Series Catalog Table,load the Sites into cboxSites
            For i = 0 To dataSeriesDT.Rows.Count - 1
                If dataSeriesDT.Rows(i).Item(db_fld_SCSiteID) Is DBNull.Value OrElse dataSeriesDT.Rows(i).Item(db_fld_SCVarID) Is DBNull.Value Then
                    'error occurred on this site ... Figure out what to do here

                Else
                    seriesID = dataSeriesDT.Rows(i).Item(db_fld_SCSeriesID)
                    siteID = dataSeriesDT.Rows(i).Item(db_fld_SCSiteID)
                    varID = dataSeriesDT.Rows(i).Item(db_fld_SCVarID)
                    methodID = dataSeriesDT.Rows(i).Item(db_fld_SCMethodID)
                    qcLevelID = dataSeriesDT.Rows(i).Item(db_fld_SCQCLevel)
                    sourceID = dataSeriesDT.Rows(i).Item(db_fld_SCSourceID)
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCVarUnitsName) Is DBNull.Value) Then
                        varUnits = dataSeriesDT.Rows(i).Item(db_fld_SCVarUnitsName)
                    Else
                        varUnits = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCSampleMed) Is DBNull.Value) Then
                        sampleMed = dataSeriesDT.Rows(i).Item(db_fld_SCSampleMed)
                    Else
                        sampleMed = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCValueType) Is DBNull.Value) Then
                        valueType = dataSeriesDT.Rows(i).Item(db_fld_SCValueType)
                    Else
                        valueType = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCTimeSupport) Is DBNull.Value) Then
                        timeSupport = dataSeriesDT.Rows(i).Item(db_fld_SCTimeSupport)
                    Else
                        timeSupport = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCTimeUnitsName) Is DBNull.Value) Then
                        timeUnits = dataSeriesDT.Rows(i).Item(db_fld_SCTimeUnitsName)
                    Else
                        timeUnits = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCDataType) Is DBNull.Value) Then
                        dataType = dataSeriesDT.Rows(i).Item(db_fld_SCDataType)
                    Else
                        dataType = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCGenCat) Is DBNull.Value) Then
                        genCategory = dataSeriesDT.Rows(i).Item(db_fld_SCGenCat)
                    Else
                        genCategory = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCBeginDT) Is DBNull.Value) Then
                        beginDateLocal = dataSeriesDT.Rows(i).Item(db_fld_SCBeginDT)
                    Else
                        beginDateLocal = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCEndDT) Is DBNull.Value) Then
                        endDateLocal = dataSeriesDT.Rows(i).Item(db_fld_SCEndDT)
                    Else
                        endDateLocal = " "
                    End If
                    'NOTE: No longer in Database 2/5/07
                    '********************************************************************************
                    'If Not (dataSeriesDT.Rows(i).Item(db_fld_SCUTCOffset) Is DBNull.Value) Then
                    '    utcOffset = dataSeriesDT.Rows(i).Item(db_fld_SCUTCOffset)
                    'Else
                    '    utcOffset = db_BadID
                    'End If
                    '********************************************************************************
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCBeginDTUTC) Is DBNull.Value) Then
                        beginDateUTC = dataSeriesDT.Rows(i).Item(db_fld_SCBeginDTUTC)
                    Else
                        beginDateUTC = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCEndDTUTC) Is DBNull.Value) Then
                        endDateUTC = dataSeriesDT.Rows(i).Item(db_fld_SCEndDTUTC)
                    Else
                        endDateUTC = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCValueCount) Is DBNull.Value) Then
                        valueCount = dataSeriesDT.Rows(i).Item(db_fld_SCValueCount)
                    Else
                        valueCount = db_BadID
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCMethodDesc) Is DBNull.Value) Then
                        methodDesc = dataSeriesDT.Rows(i).Item(db_fld_SCMethodDesc)
                    Else
                        methodDesc = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCOrganization) Is DBNull.Value) Then
                        organization = dataSeriesDT.Rows(i).Item(db_fld_SCOrganization)
                    Else
                        organization = ""
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCSourceDesc) Is DBNull.Value) Then
                        sourceDesc = dataSeriesDT.Rows(i).Item(db_fld_SCSourceDesc)
                    Else
                        sourceDesc = ""
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCQCLCode) Is DBNull.Value) Then
                        qcLevelCode = dataSeriesDT.Rows(i).Item(db_fld_SCQCLCode)
                    Else
                        qcLevelCode = " "
                    End If
                    qcLevelDef = GetQCLevelDefinitionFromDB(qcLevelID)

                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCSpeciation) Is DBNull.Value) Then
                        speciation = dataSeriesDT.Rows(i).Item(db_fld_SCSpeciation)
                    Else
                        speciation = " "
                    End If
                    If Not (dataSeriesDT.Rows(i).Item(db_fld_SCCitation) Is DBNull.Value) Then
                        citation = dataSeriesDT.Rows(i).Item(db_fld_SCCitation)
                    Else
                        citation = " "
                    End If

                    'NOTE: Colums for lvEditDataSeries:
                    'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description,Citation, Local Date Range, UTC Date Range, Value Count

                    'create the new listview item
                    lvItem = New ListViewItem(genCategory)

                    'add the rest of the items to lvItem
                    lvItem.SubItems.Add(speciation)
                    lvItem.SubItems.Add(varUnits)
                    lvItem.SubItems.Add(timeSupport)
                    lvItem.SubItems.Add(timeUnits)
                    lvItem.SubItems.Add(sampleMed)
                    lvItem.SubItems.Add(valueType)
                    lvItem.SubItems.Add(dataType)
                    lvItem.SubItems.Add(qcLevelCode & " - " & qcLevelDef) 'NOTE: QCLevel = Code - Definition
                    lvItem.SubItems.Add(methodDesc)
                    lvItem.SubItems.Add(organization)
                    lvItem.SubItems.Add(sourceDesc)
                    lvItem.SubItems.Add(citation)
                    lvItem.SubItems.Add(beginDateLocal.ToString & " - " & endDateLocal.ToString)
                    'lvItem.SubItems.Add(utcOffset)
                    lvItem.SubItems.Add(beginDateUTC.ToString & " - " & endDateUTC.ToString)
                    lvItem.SubItems.Add(valueCount)

                    'add the listview item to lvEditDataSeries
                    lvEditDataSeries.Items.Add(lvItem)

                    'add the SiteID,VarID to m_EditIDs
                    currEditIDs = New clsDataSeriesIDs
                    currEditIDs.SeriesID = seriesID
                    currEditIDs.SiteID = siteID
                    currEditIDs.VariableID = varID
                    currEditIDs.MethodID = methodID
                    currEditIDs.QCLevelID = qcLevelID
                    currEditIDs.SourceID = sourceID
                    m_EditIDs.Add(currEditIDs)
                End If
            Next i

            '4. adjust the column widths for values
            For i = 0 To lvEditDataSeries.Columns.Count - 1
                lvEditDataSeries.Columns(i).Width = GetEditDataSeriesColWidth(i)
            Next i
            'redraw the list view
            lvEditDataSeries.Update()

            '5. release resources
            If Not (dataSeriesDT Is Nothing) Then
                dataSeriesDT.Dispose()
                dataSeriesDT = Nothing
            End If

            Return True
        Catch ex As Exception
            ShowError("An Error occurred while loading the available Data Series on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (dataSeriesDT Is Nothing) Then
            dataSeriesDT.Dispose()
            dataSeriesDT = Nothing
        End If
        Return False
    End Function

    Private Function GetEditDataSeriesColWidth(ByVal colIndex As Integer) As Integer
        Dim i As Integer 'counter
        Dim itemWidth As Integer 'the width of the current subitem -> so can correctly size of each column to fit the data
        Dim colWidth As Integer 'the width of the current column header -> so can correctly size of each column to fit the data
        Const useColHeaderWidth As Integer = -2 'resize to the column header
        Const useLargestItemWidth As Integer = -1 'resize to the largest value in the list
        Try
            '1. intialize minWidth, colWidth
            colWidth = GetStringLen(lvEditDataSeries.Columns(colIndex).Text)

            '2. loop through all of the items and get the largest item
            For i = 0 To lvEditDataSeries.Items.Count - 1
                If lvEditDataSeries.Items(i).SubItems.Count > colIndex Then
                    itemWidth = GetStringLen(lvEditDataSeries.Items(i).SubItems(colIndex).Text)
                    If itemWidth > colWidth Then
                        '3. return useLargestItemWidth -> at least one value is greater than the column header, so resize to largest item
                        Return useLargestItemWidth
                    End If
                End If
            Next i

            '3. Return useColHeaderWidth -> no values were greater than the column header width
            Return useColHeaderWidth
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while calculating the Width for the Column = " & colIndex & " in the lvEditDataSeries control on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Function

#End Region

#Region " Edit Data Loading Functions "

    Private Sub LoadEditDataFromDB(ByVal dataSeriesIDs As clsDataSeriesIDs)
        '        This function loads all data from the Database for the selected Data Series
        '        Inputs:  dataSeriesIDs ->
        '        Outputs: None()
        Dim query As String
        Try
            ''1. let user know loading data
            'zg5EditPlot.GraphPane.Title.Text = "Loading Data From Database ..."
            'zg5EditPlot.Refresh()
            Me.Cursor = Cursors.WaitCursor

            '2. reset data
            m_EditData = Nothing

            '3. Validate Data
            If (dataSeriesIDs Is Nothing) Then
                'Exit, cannot create table -> invalid parameters
                Exit Try
            End If

            '4. create the query
            'NOTE: for now using this one till get qcLevel,Method info
            query = "SELECT * FROM " & db_tbl_DataValues & " WHERE (" & db_fld_ValMethodID & " = " & dataSeriesIDs.MethodID & " AND " & db_fld_ValQCLevel & " = " & dataSeriesIDs.QCLevelID & " AND " & db_fld_ValSiteID & " = " & dataSeriesIDs.SiteID & " AND " & db_fld_ValVarID & " = " & dataSeriesIDs.VariableID & " AND " & db_fld_ValSourceID & " = " & dataSeriesIDs.SourceID & ") ORDER BY " & db_fld_ValDateTime

            '4. get the Edit data from the Database
            m_EditData = GetValuesFromDB("CurrentEditData", dataSeriesIDs.SiteID, dataSeriesIDs.VariableID, dataSeriesIDs.QCLevelID, dataSeriesIDs.MethodID, dataSeriesIDs.SourceID)

            '5. Add in a data row -> for ZValue so can select points on the plot
            m_EditData_Graphing = m_EditData.Copy
            m_EditData_Graphing.Columns.Add(m_Edit_SelZVal, GetType(System.Double))
            'default values = 1.0, so none are selected
            Dim i As Integer
            For i = 0 To m_EditData_Graphing.Rows.Count - 1
                m_EditData_Graphing.Rows(i).Item(m_Edit_SelZVal) = 1.0
            Next
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while loading the editable data from the Database for the SiteID = " & dataSeriesIDs.SiteID & vbCrLf & "VariableID = " & dataSeriesIDs.VariableID & vbCrLf & "Quality Control Level = " & dataSeriesIDs.QCLevelID & vbCrLf & "MethodID = " & dataSeriesIDs.MethodID & vbCrLf & " for the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
            'set m_VisPlotData = Nothing
            m_EditData = Nothing
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region


#Region " Data Filter Loading Functions "

    Private Function LoadEditDataFilterDateRange() As Boolean
        'This function Loads the Date Range for the selected Data Series into the Data Filter section
        'Inputs:  None
        'Outputs: Boolean -> Tracks if successfully loaded the Date Range for the selected Data Series -> values are in selected lvVisDataSeries item          
        Dim startDate As Date = Date.Today
        Dim endDate As Date = Date.Today
        Dim dateIndex As Integer = 13
        'NOTE: Colums for lvEditData Series:
        'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description, Citation, Local Date Range, UTC Date Range, Value Count
        Try
            '1. make sure have a valid selected item
            If lvEditDataSeries.SelectedItems.Count <= 0 Then
                'return false
                Exit Try
            End If

            '2. set that loading the date range
            m_LoadingEditDateRange = True

            '3. get the Start,End dates from the selected item
            startDate = CDate(Split(lvEditDataSeries.SelectedItems(0).SubItems(dateIndex).Text, " - ")(0))
            endDate = CDate(Split(lvEditDataSeries.SelectedItems(0).SubItems(dateIndex).Text, " - ")(1))

            '4. set the Min, Max, and Value for the Before Date item
            If endDate < dtpEditDFDBefore.MinDate Then
                dtpEditDFDBefore.MinDate = startDate
                dtpEditDFDBefore.MaxDate = endDate
            Else 'IF startDate > dtpEditDFDBefore.MaxDate Then
                dtpEditDFDBefore.MaxDate = endDate
                dtpEditDFDBefore.MinDate = startDate
            End If
            dtpEditDFDBefore.Value = endDate

            '5. set the Min, Max, and Value for the After Date item
            If endDate < dtpEditDFDAfter.MinDate Then
                dtpEditDFDAfter.MinDate = startDate
                dtpEditDFDAfter.MaxDate = endDate
            Else 'If startDate > dtpEditDFDAfter.MaxDate Then
                dtpEditDFDAfter.MaxDate = endDate
                dtpEditDFDAfter.MinDate = startDate
            End If
            dtpEditDFDAfter.Value = startDate

            '6. set that done loading the date range
            m_LoadingEditDateRange = False

            Return True
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while loading the Date Range for the selected Data Series on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Return False
    End Function

    Private Function GetDataGapTimePeriodText(ByVal enumTimePeriod As enumEditDGTimePeriods) As String
        Dim text As String = ""
        Select Case enumTimePeriod
            Case enumEditDGTimePeriods.Minutes
                text = "Minutes"
            Case enumEditDGTimePeriods.Hours
                text = "Hours"
            Case enumEditDGTimePeriods.Days
                text = "Days"
            Case enumEditDGTimePeriods.Months
                text = "Months"
            Case enumEditDGTimePeriods.Years
                text = "Years"
            Case Else
                text = ""
        End Select
        Return text
    End Function

    Private Function GetDataGapTimePeriodEnum(ByVal strTimePeriod As String) As enumEditDGTimePeriods
        Dim enumValue As enumEditDGTimePeriods = -1
        Select Case LCase(strTimePeriod)
            Case "minutes"
                Return enumEditDGTimePeriods.Minutes
            Case "hours"
                Return enumEditDGTimePeriods.Hours
            Case "days"
                Return enumEditDGTimePeriods.Days
            Case "months"
                Return enumEditDGTimePeriods.Months
            Case "years"
                Return enumEditDGTimePeriods.Years
            Case Else
                Return -1
        End Select
    End Function

    Private Function GetEditDFDGSelIndex(ByVal strTimePeriod As String) As Integer
        Dim i As Integer
        Dim selIndex As Integer = -1
        Try
            '1. validate that Time periods are loaded
            If cboxEditDFDGTimePeriod.Items.Count <= 0 Then
                LoadDataGapTimePeriods()
            End If

            '2. find the correct index in cboxEditDFDGTimePeriod
            For i = 0 To cboxEditDFDGTimePeriod.Items.Count - 1
                If cboxEditDFDGTimePeriod.Items(i) = strTimePeriod Then
                    selIndex = i
                    'exit early
                    Exit For
                End If
            Next i

            Return selIndex
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Index of the Data Gap Time Period to selected for the Time Period = " & strTimePeriod & " on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'errors occurred above, return -1
        Return -1
    End Function

    Private Sub LoadDataGapTimePeriods()
        Try
            '1. Clear out any data
            cboxEditDFDGTimePeriod.Items.Clear()

            '3. Load Time Periods into cboxDGTimePeriod
            cboxEditDFDGTimePeriod.Items.Add(GetDataGapTimePeriodText(enumEditDGTimePeriods.Minutes))
            cboxEditDFDGTimePeriod.Items.Add(GetDataGapTimePeriodText(enumEditDGTimePeriods.Hours))
            cboxEditDFDGTimePeriod.Items.Add(GetDataGapTimePeriodText(enumEditDGTimePeriods.Days))
            cboxEditDFDGTimePeriod.Items.Add(GetDataGapTimePeriodText(enumEditDGTimePeriods.Months))
            cboxEditDFDGTimePeriod.Items.Add(GetDataGapTimePeriodText(enumEditDGTimePeriods.Years))
        Catch ex As Exception
            ShowError("An Error occurred while loading the Available Time Periods for the Data Gaps Data Filter on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
            cboxEditDFDGTimePeriod.Items.Clear()
        End Try
    End Sub

    Private Function LoadEditDFDataGapDefaultValue(ByVal varID As Integer, ByVal firstDateTime As Object, ByVal secondDateTime As Object) As Boolean
        Dim valText As String
        Dim tpSelIndex As Integer = -1
        Dim gap As TimeSpan
        Dim firstDate As DateTime
        Dim nextDate As DateTime
        Try
            '1. Load Time Periods if needed
            If cboxEditDFDGTimePeriod.Items.Count = 0 Then
                LoadDataGapTimePeriods()
            End If

            '2. Clear out old data
            tboxEditDFDGValue.Text = ""
            cboxEditDFDGTimePeriod.SelectedIndex = -1
            cboxEditDFDGTimePeriod.Text = ""

            '3. Check if sel data series IsRegular = True
            If GetVarIsRegularFromDB(varID) = True Then
                '4. Calculate Default Value
                'validate given Date Values
                If (firstDateTime Is DBNull.Value) OrElse (secondDateTime Is DBNull.Value) Then
                    'invalid data, leave values blank
                    valText = ""
                    tpSelIndex = -1
                Else
                    'calculate the time span
                    firstDate = CType(firstDateTime, DateTime)
                    nextDate = CType(secondDateTime, DateTime)
                    gap = nextDate.Subtract(firstDate)
                    If gap.Days > 0 Then
                        valText = gap.Days.ToString
                        tpSelIndex = GetEditDFDGSelIndex(GetDataGapTimePeriodText(enumEditDGTimePeriods.Days))
                    ElseIf gap.Hours > 0 Then
                        valText = gap.Hours.ToString
                        tpSelIndex = GetEditDFDGSelIndex(GetDataGapTimePeriodText(enumEditDGTimePeriods.Hours))
                    ElseIf gap.Minutes > 0 Then
                        valText = gap.Minutes.ToString
                        tpSelIndex = GetEditDFDGSelIndex(GetDataGapTimePeriodText(enumEditDGTimePeriods.Minutes))
                    End If
                End If
            Else
                '4. set values = blank
                valText = ""
                tpSelIndex = -1
            End If

            '5. Set default Data Gap Value in Data Filter area on form
            tboxEditDFDGValue.Text = valText
            'Validate Value
            tboxEditDFDGValue_Validating(Me, New System.ComponentModel.CancelEventArgs())

            '6. Set default Data Gap Time Period in Data Filter area on form
            cboxEditDFDGTimePeriod.SelectedIndex = tpSelIndex

            '7. Return that everything worked great!!
            Return True
        Catch ex As Exception
            ShowError("An Error occurred while loading the default value for the Data Gap data filter on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'errors occurred above, return false
        Return False
    End Function

#End Region

#Region " Table Loading Functions "

    Private Sub LoadEditDataIntoTable()
        'Dim i As Integer 'counter
        Dim curTxtCol As DataGridViewTextBoxColumn

        Try
            '1. Validate(Data)
            If m_EditData Is Nothing Then
                'exit
                Exit Try
            End If

            '2. Let user know something is being loading
            zg5EditPlot.GraphPane.Title.Text = "Loading Table ... "
            zg5EditPlot.Refresh()
            Me.Cursor = Cursors.WaitCursor

            '3. Load Data into the Table
            'dgvEditTable.AutoGenerateColumns = False
            dgvEditTable.AutoGenerateColumns = True
            dgvEditTable.DataSource = m_EditData

            'dgvEditTable.AllowUserToResizeColumns = True
            'dgvEditTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
            'For i As Integer = 0 To dgvEditTable.ColumnCount - 1
            '    dgvEditTable.EditMode
            'Next


            'dgvEditTable.Columns("DateYear").Visible = False
            'dgvEditTable.Columns("DateMonth").Visible = False
            'dgvEditTable.Columns("DateDay").Visible = False


            '5. 'make only Value Col editable

            '5. make sure nothing is selected yet
            dgvEditTable.ClearSelection()
            '6. Release resources
            If Not (curTxtCol Is Nothing) Then
                curTxtCol.Dispose()
                curTxtCol = Nothing
            End If

        Catch ex As Exception
            ShowError("An Error occurred while loading the Edit Data into the Table." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub LoadEditDataIntoTable_OLD()
    '	Dim i As Integer 'counter
    '	Try
    '		''TODO: Michelle: Remove msgbox -> for testing only!!
    '		'MsgBox("Loading Edit Data into Table")

    '		'TODO: Michelle: 
    '		'1. Validate(Data)
    '		If m_EditData Is Nothing Then
    '			'exit
    '			Exit Try
    '		End If

    '		'2. Let user know something is being loading
    '		zg5EditPlot.GraphPane.Title.Text = "Loading Table ... "
    '		zg5EditPlot.Refresh()
    '		Me.Cursor = Cursors.WaitCursor

    '		'3. Set Table Properties
    '		'TODO: Michelle: Center Col Header text
    '		'dgvEditTable.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '		''default = Center all data
    '		'dgvEditTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '		''resize Cols to header/largest value
    '		'dgvEditTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.displayedcells

    '		'4. Load Data into the Table
    '		dgvEditTable.DataSource = m_EditData

    '		'5. 'make only Value Col editable
    '		'TODO: Michelle: make the ValueID be the first col
    '		Dim text As String = ""
    '		For i = 0 To dgvEditTable.Columns.Count - 1
    '			text = text & dgvEditTable.Columns(i).HeaderText & vbTab & i & vbCrLf
    '			'make read only, except Value col
    '			If dgvEditTable.Columns(i).HeaderText <> db_fld_ValValue Then
    '				dgvEditTable.Columns(i).ReadOnly = True
    '			Else
    '				dgvEditTable.Columns(i).ReadOnly = False
    '			End If
    '			If i = 0 Then
    '				dgvEditTable.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '			End If
    '		Next i
    '		'MsgBox(text)

    '		'5. make sure nothing is selected yet
    '		dgvEditTable.ClearSelection()

    '		'7. Release resources
    '	Catch ex As Exception
    '		ShowError("An Error occurred while loading the Edit Data into the Table." & vbCrLf & "Message = " & ex.Message, ex)
    '	End Try
    '	Me.Cursor = Cursors.Default
    'End Sub

#End Region

#End Region

#Region " Edit Tab: Initialize Functions "

    Private Sub InitializeEditTab()
        Try
            If Not m_LoadingEditTab Then
                '1. Intialize Plot
                InitializeZedGraphPlot(zg5EditPlot)
                zg5EditPlot.GraphPane.Title.Text = "Select a Data Series ..."
                zg5EditPlot.Refresh()

                '2. Intialize Table
                InitializeEditTable()

                '3. reset Filter Data
                btnEditDFApplyFilter.Enabled = False
                btnEditDFClearSel.Enabled = False
                'Initialize Value Threshold values
                tboxEditDFVTGreater.Text = ""
                tboxEditDFVTLess.Text = ""
                tboxEditDFVTChange.Text = ""
                'initialize Data Gap values
                tboxEditDFDGValue.Text = ""
                cboxEditDFDGTimePeriod.SelectedIndex = -1
                cboxEditDFDGTimePeriod.Text = ""
                ' select Simple Threshold as default selected filter
                rbtnEditDFValueThreshold.Checked = True
                'value >,<  are unchecked
                ckboxEditDFVTGreater.Checked = False
                ckboxEditDFVTLess.Checked = False
                'Value Change Threshold = unchecked
                rbtnEditDFVTChange.Checked = False
                'Intialize Dates = Today
                InitializeVisualizeDateInfo()
                'Date is unchecked
                rbtnEditDFDate.Checked = False
                'intialize Data Gap values

                'Data Gap is unchecked
                rbtnEditDFDataGap.Checked = False

                '4.clear out variables holding data
                If (lvEditDataSeries.Items.Count > 0) Then
                    If (lvEditDataSeries.SelectedItems.Count > 0) Then
                        If lvEditDataSeries.SelectedItems.Item(0).SubItems(8).Text <> "0 - Raw data" Then
                            btnEditRestoreDefaults.Enabled = True
                        Else
                            btnEditRestoreDefaults.Enabled = False
                        End If
                    Else
                        btnEditRestoreDefaults.Enabled = False
                    End If
                Else
                    btnEditRestoreDefaults.Enabled = False
                End If
                '5.reset data changed tracking values
                'variables

                'buttons
                btnEditDataDeriveNewDS.Enabled = False
                btnEditApplyChanges.Enabled = False
            End If
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while initializing controls and values on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub SetEditTableBtnsEnabled(ByVal enabled As Boolean)
        btnEditDataRemove.Enabled = enabled
        btnEditDataAdjust.Enabled = enabled
        btnEditDataAdd.Enabled = enabled
        btnEditDataInterpolate.Enabled = enabled
        btnEditDataFlag.Enabled = enabled

        'btnEditDataSmooth.Enabled = enabled
        'btnEditDataDeriveNewDS.Enabled = enabled
    End Sub

    Private Sub InitializeEditDateInfo()
        Try
            'set that loading the Date Range
            m_LoadingEditDateRange = True

            'reset Before Date
            If Date.Now < dtpEditDFDBefore.MinDate Then
                dtpEditDFDBefore.MinDate = Date.Today
                dtpEditDFDBefore.MaxDate = Date.Now
            Else
                dtpEditDFDBefore.MaxDate = Date.Now
                dtpEditDFDBefore.MinDate = Date.Today
            End If
            dtpEditDFDBefore.Value = Date.Today

            'reset After Date
            If Date.Now < dtpEditDFDAfter.MinDate Then
                dtpEditDFDAfter.MinDate = Date.Today
                dtpEditDFDAfter.MaxDate = Date.Now
            Else
                dtpEditDFDAfter.MaxDate = Date.Now
                dtpEditDFDAfter.MinDate = Date.Today
            End If
            dtpEditDFDAfter.Value = Date.Today

            'set that done loading the Date Range
            m_LoadingEditDateRange = False
        Catch ex As Exception
            'show an error message
            ShowError("An Error occurred while initializing the Filter Date Info on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub InitializeEditTable()
        'this function initializes the Data Table on the Edit Tab
        'Inputs:  None
        'Outputs: None
        Try
            '1. Clear out Data
            If Not (dgvEditTable Is Nothing) AndAlso dgvEditTable.RowCount > 0 Then
                dgvEditTable.DataSource = Nothing
                dgvEditTable.Columns.Clear()
            End If
        Catch ex As Exception
            ShowError("An Error occurred while initializing the Data Table on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region "Not Sure yet"


    Private Function HaveValidEditDataFilter() As Boolean
        Dim valid As Boolean = False
        Try
            Select Case True
                Case rbtnEditDFValueThreshold.Checked
                    'check to see which one(s) are checked and if have text
                    If ckboxEditDFVTGreater.Checked AndAlso ckboxEditDFVTLess.Checked Then
                        If tboxEditDFVTGreater.Text <> "" AndAlso tboxEditDFVTLess.Text <> "" Then
                            'have valid text, return true
                            valid = True
                        Else
                            'missing text, return false
                            valid = False
                        End If
                    ElseIf ckboxEditDFVTGreater.Checked Then
                        If tboxEditDFVTGreater.Text <> "" Then
                            'have valid text, return true
                            valid = True
                        Else
                            'missing text, return false
                            valid = False
                        End If
                    ElseIf ckboxEditDFVTLess.Checked Then
                        If tboxEditDFVTLess.Text <> "" Then
                            'have valid text, return true
                            valid = True
                        Else
                            'missing text, return false
                            valid = False
                        End If
                    Else
                        'nothing is checked, return false
                        valid = False
                    End If
                Case rbtnEditDFVTChange.Checked
                    'check to see if have a value
                    If tboxEditDFVTChange.Text <> "" Then
                        'have valid text, return true
                        valid = True
                    Else
                        'missing text, return false
                        valid = False
                    End If
                Case rbtnEditDFDate.Checked
                    'check to see that something is selected -> default values are always loaded
                    If ckboxEditDFDBefore.Checked Or ckboxEditDFDAfter.Checked Then
                        'have a date Type selected, return true
                        valid = True
                    Else
                        'no date type = selected, return false
                        valid = False
                    End If
                Case rbtnEditDFDataGap.Checked
                    'check to see if have value, time period specified
                    If tboxEditDFDGValue.Text <> "" AndAlso cboxEditDFDGTimePeriod.SelectedIndex >= 0 Then
                        'have valid text and Time Period, return true
                        valid = True
                    Else
                        'missing text or Time Period, return false
                        valid = False
                    End If
                Case Else
                    'nothing is selected, return flase
                    valid = False
            End Select
            Return valid
        Catch ex As Exception
            ShowError("An Error occurred while validating the Data Filter on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'errors occurred above, return false
        Return False
    End Function

    Private Sub FindValueThresholdIndexes(ByVal vtMethod As String, ByVal greaterText As String, ByVal lessText As String)
        'NOTE: this function sets the selected indexes into m_EditSelPtIndexes
        Dim i As Integer 'counter
        Dim numFound As Integer
        Dim numVals As Integer
        Dim curVal As Double
        Dim greaterVal As Double
        Dim lessVal As Double
        Try
            '1. clear out old data from m_EditSelPtIndexes
            If Not (m_EditSelPtIndexes Is Nothing) Then
                m_EditSelPtIndexes.Clear()
            Else
                m_EditSelPtIndexes = New System.Collections.ArrayList
            End If

            '2. Validate data, get compare values
            Select Case vtMethod
                Case m_EditDFMethod_Both
                    If greaterText = "" OrElse lessText = "" Then
                        'show error msg
                        MsgBox("Invalid Filter settings:  The Greater Than and Less Than values cannot be blank.  Cannot select points, please verify filter values." & vbCrLf & vbCrLf & "Greater Than Value = " & greaterText & vbCrLf & "Less Than Value = " & lessText, MsgBoxStyle.Exclamation)
                        'errors occurred above, return empty set of indexes
                        m_EditSelPtIndexes.Clear()
                        Exit Try
                    End If
                    'get the greater Value
                    greaterVal = CDbl(greaterText)
                    'get the less Value
                    lessVal = CDbl(lessText)
                Case m_EditDFVTMethod_Greater
                    If greaterText = "" Then
                        'show error msg
                        MsgBox("Invalid Filter settings:  The Greater Than value cannot be blank.  Cannot select points, please verify filter values." & vbCrLf & vbCrLf & "Greater Than Value = " & greaterText, MsgBoxStyle.Exclamation)
                        'errors occurred above, return empty set of indexes
                        m_EditSelPtIndexes.Clear()
                        Exit Try
                    End If
                    'get the greater Value
                    greaterVal = CDbl(greaterText)
                Case m_EditDFVTMethod_Less
                    If lessText = "" Then
                        'show error msg
                        MsgBox("Invalid Filter settings:  The Less Than value cannot be blank.  Cannot select points, please verify filter values." & vbCrLf & vbCrLf & "Less Than Value = " & lessText, MsgBoxStyle.Exclamation)
                        'errors occurred above, return empty set of indexes
                        m_EditSelPtIndexes.Clear()
                        Exit Try
                    End If
                    'get the less Value
                    lessVal = CDbl(lessText)
            End Select

            '3. Move through selected values, find the ones that match the criteria, store in indexes
            numFound = 0
            numVals = m_EditData.Rows.Count

            'Dim rowlist() As DataRow

            'Select vtMethod
            '    Case m_EditDFMethod_Both
            '        If greaterVal > lessVal Then
            '            rowlist = m_EditData.Select("DataValue > " & greaterVal & " OR DataValue < " & lessVal)
            '        Else
            '            rowlist = m_EditData.Select("DataValue > " & greaterVal & " AND DataValue < " & lessVal)
            '        End If
            '    Case m_EditDFVTMethod_Greater
            '        rowlist = m_EditData.Select("DataValue > " & greaterVal)
            '    Case m_EditDFVTMethod_Less
            '        rowlist = m_EditData.Select("DataValue < " & lessVal)
            'End Select

            'm_EditSelPtIndexes = rowlist.IndexOf(
            'numFound = rowlist.Length


            'm_EditSelPtIndexes
            For i = 0 To numVals - 1
                curVal = m_EditData.Rows(i).Item(db_fld_ValValue)
                Select Case vtMethod
                    Case m_EditDFMethod_Both
                        If greaterVal > lessVal Then
                            If curVal > greaterVal OrElse curVal < lessVal Then
                                m_EditSelPtIndexes.Add(i)
                                numFound += 1
                            End If
                        Else
                            If curVal > greaterVal AndAlso curVal < lessVal Then
                                m_EditSelPtIndexes.Add(i)
                                numFound += 1
                            End If
                        End If

                    Case m_EditDFVTMethod_Greater
                        If curVal > greaterVal Then
                            m_EditSelPtIndexes.Add(i)
                            numFound += 1
                        End If
                    Case m_EditDFVTMethod_Less
                        If curVal < lessVal Then
                            m_EditSelPtIndexes.Add(i)
                            numFound += 1
                        End If
                End Select
            Next i

            '3. double check to make sure data in m_EditSelPtIndexes = valid
            If numFound <= 0 Then
                'reset indexes = nothing
                m_EditSelPtIndexes.Clear()
            End If
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Indexes to select for the Value Threshold Data Filter on the Edit Tab. " & vbCrLf & "Message = " & ex.Message, ex)
            'errors occurred above, return empty set of indexes
            m_EditSelPtIndexes.Clear()
        End Try
    End Sub

    Private Sub FindDateIndexes(ByVal dateMethod As String, ByVal beforeDate As DateTime, ByVal afterDate As DateTime)
        'NOTE: this function sets the selected indexes into m_EditSelPtIndexes
        Dim i As Integer 'counter
        Dim newDate As New DateTime
        Dim numFound As Integer
        Dim numVals As Integer
        Dim curDate As DateTime
        Try
            '1. clear out old data from m_EditSelPtIndexes
            If Not (m_EditSelPtIndexes Is Nothing) Then
                m_EditSelPtIndexes.Clear()
            Else
                m_EditSelPtIndexes = New System.Collections.ArrayList
            End If

            '2. Validate data, get compare values
            Select Case dateMethod
                Case m_EditDFMethod_Both
                    If (beforeDate = newDate) OrElse (afterDate = newDate) Then
                        'show error msg
                        MsgBox("Invalid Filter settings:  The Before and After Date values must be selected.  Cannot select points, please verify filter values." & vbCrLf & vbCrLf & "Before Date = " & beforeDate.ToString & vbCrLf & "After Date = " & afterDate.ToString, MsgBoxStyle.Exclamation)
                        'errors occurred above, return empty set of indexes
                        m_EditSelPtIndexes.Clear()
                        Exit Try
                    End If
                Case m_EditDFVTMethod_Greater
                    If (beforeDate = newDate) Then
                        'show error msg
                        MsgBox("Invalid Filter settings:  The Before Date value must be selected.  Cannot select points, please verify filter values." & vbCrLf & vbCrLf & "Before Date = " & beforeDate.ToString, MsgBoxStyle.Exclamation)
                        'errors occurred above, return empty set of indexes
                        m_EditSelPtIndexes.Clear()
                        Exit Try
                    End If
                Case m_EditDFVTMethod_Less
                    If (afterDate = newDate) Then
                        'show error msg
                        MsgBox("Invalid Filter settings:  The After Date value must be selected.  Cannot select points, please verify filter values." & vbCrLf & vbCrLf & "After Date = " & afterDate.ToString, MsgBoxStyle.Exclamation)
                        'errors occurred above, return empty set of indexes
                        m_EditSelPtIndexes.Clear()
                        Exit Try
                    End If
            End Select

            '3. Move through selected values, find the ones that match the criteria, store in indexes
            numFound = 0
            numVals = m_EditData.Rows.Count
            For i = 0 To numVals - 1
                curDate = m_EditData.Rows(i).Item(db_fld_ValDateTime)
                Select Case dateMethod
                    Case m_EditDFMethod_Both
                        If afterDate > beforeDate Then
                            If curDate > afterDate OrElse curDate < beforeDate Then
                                m_EditSelPtIndexes.Add(i)
                                numFound += 1
                            End If
                        Else
                            If curDate > afterDate AndAlso curDate < beforeDate Then
                                m_EditSelPtIndexes.Add(i)
                                numFound += 1
                            End If
                        End If
                    Case m_EditDFDMethod_Before
                        If curDate < beforeDate Then
                            m_EditSelPtIndexes.Add(i)
                            numFound += 1
                        End If
                    Case m_EditDFDMethod_After
                        If curDate > afterDate Then
                            m_EditSelPtIndexes.Add(i)
                            numFound += 1
                        End If
                End Select
            Next i

            '3. double check to make sure data in m_EditSelPtIndexes = valid
            If numFound <= 0 Then
                'reset indexes = nothing
                m_EditSelPtIndexes.Clear()
            End If
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Indexes to select for the Value Threshold Data Filter on the Edit Tab. " & vbCrLf & "Message = " & ex.Message, ex)
            'errors occurred above, return empty set of indexes
            m_EditSelPtIndexes.Clear()
        End Try
    End Sub

    Private Sub FindValueChangeThresholdIndexes(ByVal valChangeText As String)
        'NOTE: this function sets the selected indexes into m_EditSelPtIndexes
        Dim i As Integer 'counter
        Dim numFound As Integer
        Dim numVals As Integer
        Dim prevVal As Double
        Dim curVal As Double
        Dim curChange As Double
        Dim valChange As Double
        Try
            '1. clear out old data from m_EditSelPtIndexes
            If Not (m_EditSelPtIndexes Is Nothing) Then
                m_EditSelPtIndexes.Clear()
            Else
                m_EditSelPtIndexes = New System.Collections.ArrayList
            End If

            '2. Validate data, get compare values
            If valChangeText = "" Then
                'show error msg
                MsgBox("Invalid Filter settings:  The Value Change Threshold value cannot be blank.  Cannot select points, please verify filter values." & vbCrLf & vbCrLf & "Value Change Threshold = " & valChangeText, MsgBoxStyle.Exclamation)
                'errors occurred above, return empty set of indexes
                m_EditSelPtIndexes.Clear()
                Exit Try
            End If
            'get the less Value
            valChange = CDbl(valChangeText)

            '3. Move through selected values, find the ones that match the criteria, store in indexes
            numFound = 0
            numVals = m_EditData.Rows.Count
            curVal = m_EditData.Rows(0).Item(db_fld_ValValue)
            For i = 1 To numVals - 1
                prevVal = curVal
                curVal = m_EditData.Rows(i).Item(db_fld_ValValue)
                curChange = Math.Abs(curVal - prevVal)
                If curChange >= valChange Then
                    m_EditSelPtIndexes.Add(i - 1)
                    m_EditSelPtIndexes.Add(i)
                    numFound += 2
                End If
            Next i

            '3. double check to make sure data in m_EditSelPtIndexes = valid
            If numFound <= 0 Then
                'reset indexes = nothing
                m_EditSelPtIndexes.Clear()
            End If
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Indexes to select for the Value Threshold Data Filter on the Edit Tab. " & vbCrLf & "Message = " & ex.Message, ex)
            'errors occurred above, return empty set of indexes
            m_EditSelPtIndexes.Clear()
        End Try
    End Sub

    Private Sub FindDataGapIndexes(ByVal timeGap As TimeSpan)
        'NOTE: this function sets the selected indexes into m_EditSelPtIndexes
        Dim i As Integer 'counter
        Dim numFound As Integer
        Dim numVals As Integer
        Dim prevDate As DateTime
        Dim curDate As DateTime
        Dim curSpan As TimeSpan
        Try
            '1. clear out old data from m_EditSelPtIndexes
            If Not (m_EditSelPtIndexes Is Nothing) Then
                m_EditSelPtIndexes.Clear()
            Else
                m_EditSelPtIndexes = New System.Collections.ArrayList
            End If

            '2. Validate data, get compare values
            If (timeGap.CompareTo(TimeSpan.Zero) = 0) Then 'NOTE: if <0 = less, 0 = equal, >0 = greater
                'show error msg
                MsgBox("Invalid Filter settings:  The Data Gap value cannot be blank.  Cannot select points, please verify filter values." & vbCrLf & vbCrLf & "Data Gap = " & timeGap.ToString, MsgBoxStyle.Exclamation)
                'errors occurred above, return empty set of indexes
                m_EditSelPtIndexes.Clear()
                Exit Try
            End If

            '3. Move through selected values, find the ones that match the criteria, store in indexes
            numFound = 0
            numVals = m_EditData.Rows.Count
            curDate = m_EditData.Rows(0).Item(db_fld_ValDateTime)
            For i = 1 To numVals - 1
                prevDate = curDate
                curDate = m_EditData.Rows(i).Item(db_fld_ValDateTime)
                curSpan = curDate.Subtract(prevDate)
                If curSpan.CompareTo(timeGap) > 0 Then  'NOTE: negative value = less, 0 = equal, positive value = greater
                    m_EditSelPtIndexes.Add(i - 1)
                    m_EditSelPtIndexes.Add(i)
                    numFound += 2
                End If
            Next i

            '3. double check to make sure data in m_EditSelPtIndexes = valid
            If numFound <= 0 Then
                'reset indexes = nothing
                m_EditSelPtIndexes.Clear()
            End If
        Catch ex As Exception
            ShowError("An Error occurred while calculating the Indexes to select for the Value Threshold Data Filter on the Edit Tab. " & vbCrLf & "Message = " & ex.Message, ex)
            'errors occurred above, return empty set of indexes
            m_EditSelPtIndexes.Clear()
        End Try
    End Sub

    'Private Function CalculateTimeGapFromData() As TimeSpan
    '	'Dim i As Integer 'counter
    '	Dim timeGap As TimeSpan = TimeSpan.Zero
    '	Dim numVals As Integer = 0
    '	'Dim avgSpan As TimeSpan
    '	'Dim curSpan As TimeSpan
    '	'Dim numLess As Integer = 0
    '	'Dim numWithin As Integer = 0
    '	'Dim numGreater As Integer = 0
    '	Try
    '		''TODO: remove msgbox -> for testing only!!
    '		MsgBox("Calculating the Data Gap from the Data")

    '		'TODO:
    '		'1. Calculate Average Time Span for whole series of data
    '		'2. Calculate how many spans, less then, within 10%, and greater than average
    '		'3. Adjust Time Span accordingly

    '		'4. Return calculated time span
    '		Return timeGap
    '	Catch ex As Exception
    '		ShowError("An Error occurred while calculating the Time Gap for the Data on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
    '	End Try
    '	'errors occured above, return Zero
    '	Return TimeSpan.Zero
    'End Function

#End Region

#Region " Edit Tab: Edit Data Functions "

#Region " Adjust Values Functionality "

    Private Sub AdjustValAdd(ByVal adjustValue As Double)
        'Adjusts all selected values by adding a constant
        'Inputs: adjustValue -> the constant to add
        'Outputs: adds constand to all selected values
        Dim i As Integer 'Counter Variable
        Dim curIndex As Integer 'Index of the point to adjust
        Dim curVal As Double 'Current value of the point

        For i = 0 To m_EditSelPtIndexes.Count - 1
            curIndex = m_EditSelPtIndexes(i)
            curVal = m_EditData.Rows(curIndex).Item(db_fld_ValValue)
            m_EditData.Rows(curIndex).Item(db_fld_ValValue) = Math.Round(curVal + adjustValue, 4)
            m_EditData_Graphing.Rows(curIndex).Item(db_fld_ValValue) = m_EditData.Rows(curIndex).Item(db_fld_ValValue)
        Next i

        ResetPlotBounds()

        'm_EditData_Graphing = m_EditData.Copy
        'm_EditData_Graphing.Columns.Add(m_Edit_SelZVal, GetType(System.Double))
    End Sub

    Private Sub AdjustValMultiply(ByVal adjustValue As Double)
        'Adjusts all selected values by multipying a constant
        'Inputs: adjustValue -> the constant to multiply
        'Outputs: multiplies constant to all selected values
        Dim i As Integer 'Counter Variable
        Dim curIndex As Integer 'Index of the point to adjust
        Dim curVal As Double 'Current value of the point

        For i = 0 To m_EditSelPtIndexes.Count - 1
            curIndex = m_EditSelPtIndexes(i)
            curVal = m_EditData.Rows(curIndex).Item(db_fld_ValValue)
            m_EditData.Rows(curIndex).Item(db_fld_ValValue) = Math.Round(curVal * adjustValue, 4)
            m_EditData_Graphing.Rows(curIndex).Item(db_fld_ValValue) = m_EditData.Rows(curIndex).Item(db_fld_ValValue)
        Next i

        ResetPlotBounds()

        'm_EditData_Graphing = m_EditData.Copy
        'm_EditData_Graphing.Columns.Add(m_Edit_SelZVal, GetType(System.Double))
    End Sub

    Private Sub AdjustValDrift(ByVal adjustValue As Double)
        'Adjusts all selected values by using Linear Drift Correction
        'Inputs: adjustValue -> the constant to control Linear Drift Correction
        'Outputs: adjusts for Linear Drift based on a constant
        Dim i As Integer 'Counter Variable
        Dim first As DateTime 'Date and Time of the first Point
        Dim last As DateTime 'DAte and Time of the last point
        Dim totalTime As TimeSpan 'The Time span between 1st and Last
        Dim current As DateTime 'The Date and Time of the Current Point
        Dim curIndex As Integer 'Index of the point to adjust
        Dim curVal As Double 'Current value of the point

        m_EditSelPtIndexes.Sort()
        first = CDate(m_EditData.Rows(CInt(m_EditSelPtIndexes(0))).Item(db_fld_ValDateTime))
        last = CDate(m_EditData.Rows(CInt(m_EditSelPtIndexes(m_EditSelPtIndexes.Count - 1))).Item(db_fld_ValDateTime))
        totalTime = last - first
        For i = 0 To m_EditSelPtIndexes.Count - 1

            curIndex = m_EditSelPtIndexes(i)
            curVal = m_EditData.Rows(curIndex).Item(db_fld_ValValue)
            current = CDate(m_EditData.Rows(curIndex).Item(db_fld_ValDateTime))
            m_EditData.Rows(curIndex).Item(db_fld_ValValue) = curVal + (adjustValue * ((current - first).TotalSeconds / totalTime.TotalSeconds))
            m_EditData_Graphing.Rows(curIndex).Item(db_fld_ValValue) = m_EditData.Rows(curIndex).Item(db_fld_ValValue)
        Next i

        ResetPlotBounds()

        'm_EditData_Graphing = m_EditData.Copy
        'm_EditData_Graphing.Columns.Add(m_Edit_SelZVal, GetType(System.Double))
    End Sub

#End Region

#Region " Interpolate Functionality "

    Private Function InterpolatePoints(ByRef newVals As Double(), ByRef errorMsg As String) As Boolean
        Dim i, j As Integer 'counters
        Dim numVals As Integer = 0 'tracks the total number of points interpolated -> size of newVals
        Dim numInterp As Integer = 0 'tracks the number of points in the current set of interepolated points
        Dim numCalc As Integer = 0
        Dim beginIndex As Integer 'index of the point at front of set of points to interpolate
        Dim endIndex As Integer 'index of the point at end of set of points to interpolate
        Dim curIndex As Integer
        Dim x1 As Double
        Dim x2 As Double
        Dim y1 As Double
        Dim y2 As Double
        Dim curX As Double
        Dim curY As Double
        Dim top As Double
        Dim bottom As Double
        Try
            '1. reset errorMsg
            errorMsg = ""

            '2. get the number of selected points
            numVals = m_EditSelPtIndexes.Count

            '3. resize newVals()
            ReDim newVals(numVals - 1)

            '4. loop through, find the begin,end indexes for the points to interpolate
            curIndex = -1
            beginIndex = -1
            endIndex = -1
            For i = 0 To numVals - 1
                If curIndex = -1 Then
                    'reset end Index
                    endIndex = -1
                    'get the current Index
                    curIndex = m_EditSelPtIndexes(i)
                    'set beginIndex
                    beginIndex = curIndex - 1 'NOTE: already validated that can't be the first value, so always a valid Index!!
                    'reset numInterp count
                    numInterp = 1
                ElseIf (m_EditSelPtIndexes(i) > (curIndex + 1)) Then 'found a gap -> set the end, interpolated all values before gap
                    'set end Index
                    endIndex = curIndex + 1
                    'reset curIndex = -1 -> so will do correctly next loop
                    curIndex = -1
                Else
                    'set curIndex = current Index
                    curIndex = m_EditSelPtIndexes(i)
                    'add 1 to numInterp
                    numInterp += 1
                End If

                'See if have last sel Index
                If i = (numVals - 1) AndAlso endIndex = -1 Then 'NOTE: must add extra check in case last point is a single point
                    'set end Index
                    endIndex = curIndex + 1
                End If

                'Interpolate values if have a begin and end index
                If beginIndex >= 0 AndAlso endIndex >= 0 Then
                    'get the begin point
                    x1 = CType(m_EditData.Rows(beginIndex).Item(db_fld_ValDateTime), DateTime).ToOADate
                    y1 = m_EditData.Rows(beginIndex).Item(db_fld_ValValue)
                    'get the end point
                    x2 = CType(m_EditData.Rows(endIndex).Item(db_fld_ValDateTime), DateTime).ToOADate
                    y2 = m_EditData.Rows(endIndex).Item(db_fld_ValValue)
                    'Interpolate each of the points between beginIndex,endIndex
                    'NOTE: Interpolation equation : curY = y1 + (curX - x1)(y2-y1)/(x2-x1)
                    For j = 1 To numInterp
                        'calculate the new Y value
                        curX = CType(m_EditData.Rows(beginIndex + j).Item(db_fld_ValDateTime), DateTime).ToOADate
                        top = (curX - x1) * (y2 - y1)
                        bottom = (x2 - x1)
                        curY = Math.Round(y1 + (top / bottom), 4)
                        'store the New Y value
                        newVals(numCalc) = curY
                        numCalc += 1
                    Next j
                    'if not on last point, reduce i by 1 so can get the next full set of points to interpolate
                    If (numCalc < numVals) Then 'NOTE: must add extra check in case last point is a single point
                        i -= 1
                    End If
                End If
            Next i

            'm_EditData_Graphing = m_EditData.Copy
            'm_EditData_Graphing.Columns.Add(m_Edit_SelZVal, GetType(System.Double))

            '5. everything worked, return True!!
            Return True
        Catch ex As Exception
            errorMsg = "An Error occurred while Interpolating points" & vbCrLf & "Message = " & ex.Message
        End Try
        'errors occurred above -> reset newvals, return false
        newVals = Nothing
        Return False
    End Function

#End Region

#Region " Delete Functionality "

    Private Function DeleteEditSelPtsFromTable(ByRef errorMsg As String) As Boolean
        Console.WriteLine("DeleteEditSelPtsFromTable(ByRef errorMsg As String)")
        Console.WriteLine(Now)
        Dim i As Integer 'counter
        Dim numSel As Integer
        Dim valIDs As Integer()
        Dim numDFIDs As Integer
        'Dim dfIDs As System.Collections.ArrayList
        Dim dfIDsQuery As String
        Dim dfIDsDT As Data.DataTable
        Dim curDFID As Object
        'Dim deleteQuery As String
        'Dim delDBCmd As OleDb.OleDbCommand
        'Dim numAffctd As Integer 'tracks the number of rows affected by Non_query execution
        Dim removeIndex As Integer
        Try
            '1. reset errorMsg
            errorMsg = ""

            '2. Get the ValueIDs being deleted
            numSel = m_EditSelPtIndexes.Count
            If numSel <= 0 Then
                'return false
                errorMsg = "No Values were selected:  Cannot delete until values are selected."
                Exit Try
            End If
            ReDim valIDs(numSel - 1)
            For i = 0 To numSel - 1
                'Get the ValueID 
                valIDs(i) = m_EditData.Rows(m_EditSelPtIndexes(i)).Item(db_fld_ValID)
            Next i

            '3.see if any DFids were derived from any of these ValueIDs
            'get any DerivedFromIDs that contain these valueIDs
            dfIDsQuery = "SELECT DISTINCT " & db_fld_DFID & " FROM " & db_tbl_DerivedFrom & " WHERE " & db_fld_DFValueID & " IN("
            For i = 0 To numSel - 1
                If i > 0 Then
                    dfIDsQuery = dfIDsQuery & ", " & valIDs(i)
                Else
                    dfIDsQuery = dfIDsQuery & valIDs(i)
                End If
            Next i
            dfIDsQuery = dfIDsQuery & ") ORDER BY " & db_fld_DFID
            dfIDsDT = OpenTable("GetDFIDsToRemove", dfIDsQuery, g_CurrConnSettings)
            'make sure have data
            If (dfIDsDT Is Nothing) Then
                'set error message, return flase
                errorMsg = "Invalid Derived From Table:  Unable to retrieve the Derived From Table from the Database.  Please make sure that it exists and is accessible."
                'return false
                Exit Try
            End If
            numDFIDs = dfIDsDT.Rows.Count

            '4. see if Have any DFIDs, if so, see if user wants to continue or not
            If numDFIDs > 0 Then
                'Ask if user wants to delete these values
                If MsgBox("One or more of the selected values have been used to derive other values in the Database. " & vbCrLf & "Are you sure that you want to DELETE all of the selected values?", MsgBoxStyle.YesNo, "WARNING: Selected Values Derived From") <> MsgBoxResult.Yes Then
                    'exit, User Does NOT want to continue
                    errorMsg = "User chose to abort Deletion process because one or more of the selected values were used to derive other values in the Database."
                    Exit Try
                End If
            End If

            '5. remove the rows from the Data Table, store values in m_Edit
            If (m_EditDeletedValIDs Is Nothing) Then
                m_EditDeletedValIDs = New System.Collections.ArrayList
            End If
            If Not (m_EditHaveDeletedValIDs) Then
                m_EditDeletedValIDs.Clear()
            End If

            'NOTE: removing in backwards order so not screw up earlier indexes -> make sure remove correct rows
            For i = numSel - 1 To 0 Step -1
                removeIndex = m_EditSelPtIndexes(i)
                m_EditDeletedValIDs.Add(m_EditData.Rows(removeIndex).Item(db_fld_ValID))
                'm_EditData.Rows(removeIndex).Delete()
                m_EditData.Rows.RemoveAt(removeIndex)
                m_EditData_Graphing.Rows.RemoveAt(removeIndex)
            Next i

            'set m_EditHaveDeletedValIDs = True
            If m_EditDeletedValIDs.Count > 0 Then
                m_EditHaveDeletedValIDs = True
            End If

            '6. get DFIDs to remove, add to m_EditRemoveDFIDs
            'If (m_EditRemoveDFIDs Is Nothing) Then
            '    m_EditRemoveDFIDs = New System.Collections.ArrayList
            'End If
            'If Not (m_EditHaveRemoveDFIDs) Then
            '    m_EditRemoveDFIDs.Clear()
            'End If
            'For i = 0 To numDFIDs - 1
            '    curDFID = dfIDsDT.Rows(i).Item(db_fld_DFID)
            '    If Not (m_EditRemoveDFIDs.Contains(curDFID)) Then
            '        m_EditRemoveDFIDs.Add(curDFID)
            '    End If
            'Next i
            ''set m_EditHaveRemoveDFIDs = True
            'If m_EditRemoveDFIDs.Count > 0 Then
            '    m_EditHaveRemoveDFIDs = True
            'End If

            '7. Move through m_EditData and set DFID = db_val_DerivedFromID_Removed for any that match
            For i = 0 To m_EditData.Rows.Count - 1
                '1. get DFID
                curDFID = m_EditData.Rows(i).Item(db_fld_ValDerivedFromID)
                If Not (curDFID Is DBNull.Value) Then
                    '2. see if is in dfIDS
                  
                    'If m_EditRemoveDFIDs.Contains(curDFID) Then
                    '    '3. change it if needed
                    '    m_EditData.Rows(i).Item(db_fld_ValDerivedFromID) = db_val_DerivedFromID_Removed
                    '    m_EditData_Graphing.Rows(i).Item(db_fld_ValDerivedFromID) = db_val_DerivedFromID_Removed
                    'End If
                End If
            Next i

            'NOTE: This is only Done, if they Apply changes to Database
            ''8. Delete records from DerivedFrom table

            '8. Release Resources
            If Not (dfIDsDT Is Nothing) Then
                dfIDsDT.Dispose()
                dfIDsDT = Nothing
            End If

            'm_EditData_Graphing = m_EditData.Copy
            'm_EditData_Graphing.Columns.Add(m_Edit_SelZVal, GetType(System.Double))

            '9. everything worked, return true
            Return True
        Catch ex As Exception
            'set errorMsg
            errorMsg = "An Error occurred while deleting the selected points from the Data Table." & vbCrLf & "Message = " & ex.Message
        End Try
        'release resources
        If Not (dfIDsDT Is Nothing) Then
            dfIDsDT.Dispose()
            dfIDsDT = Nothing
        End If
        'errors occurred above, return false
        Return False
    End Function

    Private Sub DeleteSelEditPointsFromPlot()
        Dim i As Integer 'counter
        Dim numSel As Integer
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgTimeSeries plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zgTimeSeries plot object -> used to redraw/update the plot
        Dim line As ZedGraph.LineItem
        Dim curIndex As Integer
        Try
            '1. make sure have selected values to delete
            numSel = m_EditSelPtIndexes.Count
            If numSel <= 0 Then
                'exit
                Exit Try
            End If

            '2. set GraphPane,Graphic objects
            gPane = zg5EditPlot.GraphPane
            'g = zg5EditPlot.CreateGraphics

            '3. Get the line
            line = CType(gPane.CurveList(0), ZedGraph.LineItem)

            '4. remove the points from the line
            For i = numSel - 1 To 0 Step -1 'NOTE: starting from the end, so don't mess up indexes for points to be removed
                curIndex = m_EditSelPtIndexes(i)
                'remove the point
                line.RemovePoint(curIndex)
            Next i

            '5. redraw the plot
            zg5EditPlot.Refresh()

            '6. clear out sel Pts, no longer selected!! -> NOTE: doing this so errors won't occur when ClearEditSelection is called!!
            m_EditSelPtIndexes.Clear()

            '6. release resources
            'g.Dispose()
            line = Nothing
        Catch ex As Exception
            ShowError("An Error occurred while removing the selected points from the Plot on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Add Functionality "

    Private Sub AddNewEditPointToPlot(ByVal e_date As DateTime, ByVal e_Value As Double)
        'Adds a new point to the Edit Plot
        'Inputs: e_date -> the date/time of the point
        '        e_value -> the value of the point
        'Outputs: Redraws the plot with the added point
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgTimeSeries plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zgTimeSeries plot object -> used to redraw/update the plot
        Dim line As ZedGraph.LineItem 'The line to plot
        Try

            '1. set GraphPane,Graphic objects
            gPane = zg5EditPlot.GraphPane
            'g = zg5EditPlot.CreateGraphics


            '2. Get the line
            line = CType(gPane.CurveList(0), ZedGraph.LineItem)

            '3. Add the point to the line
            line.AddPoint(e_date.ToOADate, e_Value)

            '4. redraw the plot
            zg5EditPlot.Refresh()

            '5. release resources
            'g.Dispose()
            line = Nothing
        Catch ex As Exception
            ShowError("An Error occurred while adding new points to the Plot on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Apply Edits To Database Functionality "

    Private Function ApplyEditsToDatabase(ByVal editIDs As clsDataSeriesIDs, ByRef errorMsg As String) As Boolean
        Dim beginDate As DateTime
        Dim endDate As DateTime
        Dim beginUTCDate As DateTime
        Dim endUTCDate As DateTime
        Dim valCount As Integer
        Dim updateQuery As String
        Try
#If DEBUG Then
            'TODO: Remove msgbox -> for testing only!!
            MsgBox("Applying Edits To Database: 1/4")
#End If

            '1. make sure there are edits to apply
            If Not (m_EditHaveEditsUncommitted) Then
                'set errorMsg
                errorMsg = "No changes were available to be committed to the database"
                'no edits available, return false
                Exit Try
            End If

            '2. Get the Date, ValueCount info for update
            beginDate = m_EditData.Compute("MIN(" & db_fld_ValDateTime & ")", "")
            endDate = m_EditData.Compute("MAX(" & db_fld_ValDateTime & ")", "")
            beginUTCDate = m_EditData.Compute("MIN(" & db_fld_ValUTCDateTime & ")", "")
            endUTCDate = m_EditData.Compute("MAX(" & db_fld_ValUTCDateTime & ")", "")
            valCount = m_EditData.Rows.Count

#If DEBUG Then
            'TODO: Remove msgbox -> for testing only!!
            MsgBox("Applying Edits To Database: 2/4")
#End If

            '3. Update changes to m_EditData to the Database
            updateQuery = "SELECT * FROM " & db_tbl_DataValues & " WHERE (" & db_fld_ValMethodID & " = " & editIDs.MethodID & " AND " & db_fld_ValQCLevel & " = " & editIDs.QCLevelID & " AND " & db_fld_ValSiteID & " = " & editIDs.SiteID & " AND " & db_fld_ValVarID & " = " & editIDs.VariableID & " AND " & db_fld_ValSourceID & " = " & editIDs.SourceID & ")"
            'SELECT *<, Year(" & db_fld_ValDateTime & ") AS " & db_outFld_ValDTYear & ", Month(" & db_fld_ValDateTime & ") AS " & db_outFld_ValDTMonth & ", Day(" & db_fld_ValDateTime & ") AS " & db_outFld_ValDTDay & "
            ') <ORDER BY " & db_fld_ValDateTime
            If Not (UpdateTable(m_EditData, updateQuery, g_CurrConnSettings.ConnectionString)) Then
                'show errormsg
                MsgBox("Unable to Continue updates to the Database:  Table did not update correctly")
                'exit
                Exit Try
            End If

#If DEBUG Then
            'TODO: Remove msgbox -> for testing only!!
            MsgBox("Applying Edits To Database: 3/4")
#End If

            '4. Update DerivedFromIDs to Database 'NOTE: have to do this first, so can remove from DataValues Table!!
            'UpdateDerivedFromIDsInDB() 'NOTE: this function resets m_EditRemoveDFIDs and m_EditHaveRemoveDFIDs

            '5. Remove deleted rows in the Values Table from the Database
            UpdateDeletedValuesInDB() 'NOTE: this function reset m_EditHaveDeletedValIDS and m_DeletedValIDs

            '6. Update Series Catalog
            UpdateSeriesCatalogAfterEdits(editIDs.SeriesID, beginDate, endDate, beginUTCDate, endUTCDate, valCount)

            '7. reload database Data into memory -> so matches what is in the database
            'LoadEditDataFromDB(editIDs)

#If DEBUG Then
            'TODO: Remove msgbox -> for testing only!!
            MsgBox("Applying Edits To Database: 4/4")
#End If

            'reset m_EditHaveEditsUncommitted
            m_EditHaveEditsUncommitted = False

            lvEditDataSeries_SelectedIndexChanged(Me, New System.EventArgs())

            '8. everything worked, Return true!!
            Return True
        Catch ex As Exception
            errorMsg = "An Error occurred while applying the edits to the Database." & vbCrLf & "Message = " & ex.Message
        End Try
        'errors occurred above, return false
        Return False
    End Function

    Private Sub UpdateDeletedValuesInDB()
        Dim i As Integer 'counter
        Dim delQuery As String
        Dim delCmd As SqlClient.SqlCommand
        Dim delConn As SqlClient.SqlConnection
        Dim numAffctd As Integer
        Try
            '1. make sure have values to deleted
            If Not (m_EditHaveDeletedValIDs) OrElse m_EditDeletedValIDs.Count <= 0 Then
                'reset variables
                m_EditHaveDeletedValIDs = False
                If Not (m_EditDeletedValIDs Is Nothing) Then
                    m_EditDeletedValIDs.Clear()
                End If
                'exit 
                Exit Try
            End If
            '2. Create a DELETE Query for the DataValues table
            delQuery = "DELETE FROM " & db_tbl_DataValues & " WHERE " & db_fld_ValID & " IN ("
            For i = 0 To m_EditDeletedValIDs.Count - 1
                If i > 0 Then
                    delQuery = delQuery & ", " & m_EditDeletedValIDs(i)
                Else
                    delQuery = delQuery & m_EditDeletedValIDs(i)
                End If
            Next i
            delQuery = delQuery & ")"

            '3. Run the nonQuery
            delConn = New SqlClient.SqlConnection(g_CurrConnSettings.ConnectionString)
            delConn.Open()
            'execute delete command -> NonQuery
            delCmd = New SqlClient.SqlCommand(delQuery, delConn)
            numAffctd = delCmd.ExecuteNonQuery()

            '4. Close the connection
            delConn.Close()

            '5. Check to see if any were affected
            If numAffctd <= 0 Then

                'show error message
                MsgBox("The deleted values were not updated in the " & db_tbl_DataValues & " Table in the Database." & vbCrLf & "Please manually verify that it is correct.")

                'reset m_EditDeletedValIDs,m_EditHaveDeletedValIDs
                m_EditHaveDeletedValIDs = False
                m_EditDeletedValIDs.Clear()

                'exit
                Exit Try
            End If

            '6. reset m_EditDeletedValIDs,m_EditHaveDeletedValIDs
            m_EditHaveDeletedValIDs = False
            m_EditDeletedValIDs.Clear()
        Catch ex As Exception
            ShowError("An Error occurred while updating the Deleted Values to the Database." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        '5. release resources
        If Not (delConn Is Nothing) Then
            delConn.Dispose()
            delConn = Nothing
        End If
        If Not (delCmd Is Nothing) Then
            delCmd.Dispose()
            delCmd = Nothing
        End If
    End Sub



    ''REMOVE REFERENCE TO DERIVED FROM ID'S
    'Private Sub UpdateDerivedFromIDsInDB()
    '    Dim i As Integer 'counter
    '    Dim deleteQuery As String
    '    Dim numAffctd As Integer 'tracks the number of rows affected by the delete command
    '    Dim delCmd As SqlClient.SqlCommand 'OleDb.OleDbCommand
    '    Dim delConn As SqlClient.SqlConnection 'OleDb.OleDbConnection
    '    Dim updateQuery As String
    '    Dim updateDT As DataTable
    '    Try
    '        '1. make sure have values to update
    '        'If Not (m_EditHaveRemoveDFIDs) OrElse m_EditRemoveDFIDs.Count <= 0 Then
    '        '    'reset variables
    '        '    m_EditHaveRemoveDFIDs = False
    '        '    If Not (m_EditDeletedValIDs Is Nothing) Then
    '        '        m_EditRemoveDFIDs.Clear()
    '        '    End If
    '        '    'exit 
    '        '    Exit Try
    '        'End If

    '        '2. Delete Values from the DerivedFrom table
    '        deleteQuery = "DELETE FROM " & db_tbl_DerivedFrom & " WHERE " & db_fld_DFID & " IN ("            
    '        'For i = 0 To m_EditRemoveDFIDs.Count - 1
    '        '    If i > 0 Then
    '        '        deleteQuery = deleteQuery & ", " & m_EditRemoveDFIDs(i)
    '        '    Else
    '        '        deleteQuery = deleteQuery & m_EditRemoveDFIDs(i)
    '        '    End If
    '        'Next i
    '        deleteQuery = deleteQuery & ")"
    '        'delConn = New OleDb.OleDbConnection(g_CurrConnSettings.ConnectionString)
    '        delConn = New SqlClient.SqlConnection(g_CurrConnSettings.ConnectionString)
    '        delConn.Open()
    '        'execute delete command -> NonQuery
    '        'delCmd = New OleDb.OleDbCommand(deleteQuery, delConn)
    '        delCmd = New SqlClient.SqlCommand(deleteQuery, delConn)
    '        numAffctd = delCmd.ExecuteNonQuery()
    '        'Close the connection
    '        delConn.Close()
    '        'validate that some were affected
    '        If numAffctd <= 0 Then

    '            MsgBox("No values were deleted from the " & db_tbl_DerivedFrom & " Table in the Database." & vbCrLf & "Please manually verify that it is correct.")

    '            'reset m_EditRemoveDFIDs,m_EditHaveRemoveDFIDs
    '            'm_EditHaveRemoveDFIDs = False
    '            'm_EditRemoveDFIDs.Clear()

    '            'exit
    '            Exit Try
    '        End If

    '        '3. Get the rows that need to be changed in the Data Values table
    '        updateQuery = "SELECT * FROM " & db_tbl_DataValues & " WHERE " & db_fld_ValDerivedFromID & " IN ("

    '        'For i = 0 To m_EditRemoveDFIDs.Count - 1
    '        '    If i > 0 Then
    '        '        updateQuery = updateQuery & ", " & m_EditRemoveDFIDs(i)
    '        '    Else
    '        '        updateQuery = updateQuery & m_EditRemoveDFIDs(i)
    '        '    End If
    '        'Next i
    '        updateQuery = updateQuery & ") ORDER BY " & db_fld_ValID
    '        updateDT = OpenTable("UpdateDeletedDFIDsinValuesTable", updateQuery, g_CurrConnSettings)
    '        'validate have values
    '        If (updateDT Is Nothing) Then
    '            MsgBox("Unable to update the " & db_fld_ValDerivedFromID & " field in the " & db_tbl_DataValues & " Table." & vbCrLf & "Unable to access the " & db_tbl_DataValues & " Table in the Database.")

    '            'reset m_EditRemoveDFIDs,m_EditHaveRemoveDFIDs
    '            'm_EditHaveRemoveDFIDs = False
    '            'm_EditRemoveDFIDs.Clear()
    '            'exit
    '            Exit Try
    '        End If
    '        '4. Move through DataValues table and change any DFIDs = -1 for any of the deleted values
    '        If updateDT.Rows.Count > 0 Then 'NOTE: affected rows may have already been updated!!
    '            For i = 0 To updateDT.Rows.Count - 1
    '                updateDT.Rows(i).Item(db_fld_ValDerivedFromID) = db_val_DerivedFromID_Removed
    '            Next i
    '        End If

    '        '5. Apply to Database
    '        If Not (UpdateTable(updateDT, updateQuery, g_CurrConnSettings.ConnectionString)) Then
    '            MsgBox("Unable to update the " & db_fld_ValDerivedFromID & " field in the " & db_tbl_DataValues & " Table." & vbCrLf & "You may need to manually verify the Values table to make sure it is correct.")

    '            'reset m_EditRemoveDFIDs,m_EditHaveRemoveDFIDs

    '            'm_EditHaveRemoveDFIDs = False
    '            'm_EditRemoveDFIDs.Clear()
    '            'exit
    '            Exit Try
    '        End If

    '        '6. reset m_EditRemoveDFIDs,m_EditHaveRemoveDFIDs

    '        'm_EditHaveRemoveDFIDs = False
    '        'm_EditRemoveDFIDs.Clear()
    '    Catch ex As Exception
    '        ShowError("An Error occurred while updating the " & db_tbl_DerivedFrom & " Table in the Database to reflect the Edits made." & vbCrLf & "Message = " & ex.Message, ex)
    '    End Try
    '    'release resources
    '    If Not (delConn Is Nothing) Then
    '        delConn.Dispose()
    '        delConn = Nothing
    '    End If
    '    If Not (delCmd Is Nothing) Then
    '        delCmd.Dispose()
    '        delCmd = Nothing
    '    End If
    '    If Not (updateDT Is Nothing) Then
    '        updateDT.Dispose()
    '        updateDT = Nothing
    '    End If
    'End Sub

#End Region

#Region " Restore Edits From Database Functionality "

    Private Sub RestoreEditDefaultsFromDB()
        Dim beginDate As DateTime
        Dim endDate As DateTime
        Dim beginUTCDate As DateTime
        Dim endUTCDate As DateTime
        Dim valCount As Integer
		Dim vcIndex As Integer = 15 'value Count index
        Dim dtIndex As Integer = 13 'date/time index
        Dim utcDTIndex As Integer = 14 'utc date/time index
        'NOTE: Colums for lvEditData Series:
        'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description, Citation, Local Date Range, UTC Date Range, Value Count
        Try
            '1. make sure have edits to reset 
            If Not (m_EditHaveEditsUncommitted) Then
                'there are no edits, exit
                Exit Try
            End If

            '2. reset Edit tracking variables
            m_EditHaveEditsUncommitted = False

            '3. reload data series
            lvEditDataSeries_SelectedIndexChanged(Me, New System.EventArgs())

            '4. if have DFIDs to be removed, clear them
            
            'If m_EditHaveRemoveDFIDs = True Then
            '    m_EditHaveRemoveDFIDs = False
            'End If
            'make sure all values are cleared out
            
            'If Not (m_EditRemoveDFIDs Is Nothing) Then
            '    m_EditRemoveDFIDs.Clear()
            'End If

            '5. if have deletedIDs to be deleted, clear them
            If m_EditHaveDeletedValIDs = True Then
                m_EditHaveDeletedValIDs = False
            End If
            'make sure all values are cleared out
            If Not (m_EditDeletedValIDs Is Nothing) Then
                m_EditDeletedValIDs.Clear()
            End If

            '6. Make sure that List View Info (Date, UTC Date, Value Count) matches data in the Table
            'NOTE: have to do this after reload data into Plot/Table so get correct values
            'calculate new Value Count
            valCount = dgvEditTable.RowCount
            'calculate new Date range
            beginDate = m_EditData.Compute("MIN(" & db_fld_ValDateTime & ")", "")
            endDate = m_EditData.Compute("MAX(" & db_fld_ValDateTime & ")", "")
            'calculate new UTC Date range
            beginUTCDate = m_EditData.Compute("MIN(" & db_fld_ValUTCDateTime & ")", "")
            endUTCDate = m_EditData.Compute("MAX(" & db_fld_ValUTCDateTime & ")", "")
            'update the list view
            lvEditDataSeries.SelectedItems(0).SubItems(vcIndex).Text = valCount
            lvEditDataSeries.SelectedItems(0).SubItems(dtIndex).Text = beginDate.ToString & " - " & endDate.ToString
            lvEditDataSeries.SelectedItems(0).SubItems(utcDTIndex).Text = beginUTCDate.ToString & " - " & endUTCDate.ToString

            '7. Make sure that the Date Data Filter matches data in the Table
            'NOTE: have to do this after reload data into Plot/Table so get correct values
            If Not (LoadEditDataFilterDateRange()) Then
                'disable Date Data Filter
                gboxEditDFDate.Enabled = False
                rbtnEditDFDate.Enabled = False
            Else
                'enable Date Data Filter
                gboxEditDFDate.Enabled = True
                rbtnEditDFDate.Enabled = True
            End If

            '8. disable Me and Apply Changes To Database buttons
            btnEditApplyChanges.Enabled = False
        Catch ex As Exception
            ShowError("An Error occurred while restoring defaults from the Database for the selected Data Series on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#End Region

#Region " Edit Tab: Data Selection Functions "

    Private Sub ClearEditSelection()
        Dim i As Integer 'counter
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgTimeSeries plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zgTimeSeries plot object -> used to redraw/update the plot
        Dim line As ZedGraph.LineItem
        Try
            '1. Validate that some points have been selected already
            If (m_EditSelPtIndexes Is Nothing) Then
                'exit
                Exit Try
            End If

            '2. unselect points in plot
            'm_EditData_Graphing = m_EditData.Copy
            'm_EditData_Graphing.Columns.Add(m_Edit_SelZVal, GetType(System.Double))

            If m_EditHavePointsSelected AndAlso m_EditSelPtIndexes.Count > 0 Then
                'set the Graph Pane, graphics object
                gPane = zg5EditPlot.GraphPane
                'g = zg5EditPlot.CreateGraphics
                'make sure have a line
                If gPane.CurveList.Count <= 0 Then
                    'exit
                    Exit Try
                End If
                line = CType(gPane.CurveList(0), ZedGraph.LineItem)
                'NOTE: this plot uses a Gradient Fill by Z-value, so zvalue = 1.0 -> black, zvalue = 2.0 -> red
                For i = 0 To m_EditSelPtIndexes.Count - 1
                    '. Reset all Points -> zvalue = 1.0 so color = black
                    'NOTE: This not longer works, must change points in data source!!
                    'line.Points(m_EditSelPtIndexes(i)).Z = 1.0
                    m_EditData_Graphing.Rows(m_EditSelPtIndexes(i)).Item(m_Edit_SelZVal) = 1.0
                Next i
                'redraw the plot
                zg5EditPlot.Refresh()
                'release resources
                'g.Dispose()
                line = Nothing
            End If

            '2. unselect from table
            dgvEditTable.ClearSelection()

            '3. Clear out Selected indexes
            m_EditSelPtIndexes.Clear()

            '4. reset that points have been selected
            m_EditHavePointsSelected = False

            '5. disable me because selection = cleared
            btnEditDFClearSel.Enabled = False

            '6. enable Apply Filter button, if can
            If HaveValidEditDataFilter() Then
                btnEditDFApplyFilter.Enabled = True
            Else
                btnEditDFApplyFilter.Enabled = False
            End If

            '7. disable Edit Functionality
            SetEditTableBtnsEnabled(False)
            ''re-enable Derive New Data Series
            'btnEditDataDeriveNewDS.Enabled = True
            're-enable add functionality if can
            Dim qcLevel As String
            Dim qcIndex As Integer = 8
            Dim qcCode As String
            'NOTE: Colums for lvEditData Series:
            'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description, Citation, Local Date Range, UTC Date Range, Value Count
            qcLevel = lvEditDataSeries.SelectedItems(0).SubItems(qcIndex).Text
            qcCode = Split(qcLevel, " - ")(0)
            If qcCode <> "0" Then
                btnEditDataAdd.Enabled = True
            End If
        Catch ex As Exception
            ShowError("An Error occurred while clearing the selected points on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
            'keep me enabled, errors occurred above
            btnEditDFClearSel.Enabled = True
        End Try
    End Sub

    Private Sub SelectEditValues()
        Dim i As Integer 'counter
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgTimeSeries plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zgTimeSeries plot object -> used to redraw/update the plot
        Dim line As ZedGraph.LineItem
        Dim curIndex As Integer = -1
        Try
            '1. set the Graph Pane, graphics object
            gPane = zg5EditPlot.GraphPane
            'g = zg5EditPlot.CreateGraphics

            '2. select the points in the plot and in the table change the symbol color for each of the given points
            'validate that data has been plotted
            If gPane.CurveList.Count <= 0 Then
                'exit, nothing has been plotted
                Exit Try
            End If
            line = CType(gPane.CurveList(0), ZedGraph.LineItem)
            'NOTE: this plot uses a Gradient Fill by Z-value, so zvalue = 1.0 -> black, zvalue = 2.0 -> red
            'm_EditData_Graphing = m_EditData.Copy
            'm_EditData_Graphing.Columns.Add(m_Edit_SelZVal, GetType(System.Double))

            m_EditUpdatingSelection = True
            For i = 0 To m_EditSelPtIndexes.Count - 1
                curIndex = m_EditSelPtIndexes(i)
                'change the z-value = 2.0 for selected Indexes, change them to red
                'NOTE: This no longer works, must change value in data source!!
                'line.Points(curIndex).Z = 2.0
                m_EditData_Graphing.Rows(curIndex).Item(m_Edit_SelZVal) = 2.0
                'select the row in the table
                dgvEditTable.Rows(curIndex).Selected = True
            Next i
            m_EditUpdatingSelection = False

            '3. redraw the plot
            zg5EditPlot.Refresh()

            '4. release resources
            'g.Dispose()
            line = Nothing

            '5. set that points are selected, enable Clear Selection button
            m_EditHavePointsSelected = True
            btnEditDFClearSel.Enabled = True

            '6. Enable Data Editing Functionality if can
            'NOTE: right now, due to changes in lvEditDataSeries, is currently looking at wrong column for qclevel
            Dim qcLevelIndex As Integer = 8
            'NOTE: Colums for lvEditDataSeries:
            'General Category, Speciation, Variable Units, Time Support, Time Units, Sample Medium, Value Type, Data Type, Quality Control Level, Method, Organization, Source Description,Citation, Local Date Range, UTC Date Range, Value Count
            Dim qcLevel As String
            Dim qcLevelCode As String
            qcLevel = lvEditDataSeries.SelectedItems(0).SubItems(qcLevelIndex).Text
            qcLevelCode = Split(qcLevel, " - ")(0)
            If IsNumeric(qcLevelCode) Then
                If (CInt(qcLevelCode) <> 0) Then
                    SetEditTableBtnsEnabled(True)
                    dgvEditTable.ReadOnly = False
                Else
                    'raw data -> protect it
                    SetEditTableBtnsEnabled(False)
                    dgvEditTable.ReadOnly = True
                End If
            Else
                'don't know what they want to do, so let them!!
                SetEditTableBtnsEnabled(True)
                dgvEditTable.ReadOnly = False
            End If
        Catch ex As Exception
            'show error msg
            ShowError("An Error occurred while selecting values on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
            'set that points are NOT selected, disable Clear Selection button
            m_EditHavePointsSelected = False
            btnEditDFClearSel.Enabled = False
        End Try
    End Sub

    Private Sub UpdateYValForSelPtsInPlot() 'NOTE: This may no longer be necessary -> plot now updates based on data source changes, I think!!
        Dim i As Integer 'counter
        Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgTimeSeries plot object -> used to set data and characteristics
        'Dim g As Drawing.Graphics 'graphics object of the zgTimeSeries plot object -> used to redraw/update the plot
        Dim line As ZedGraph.LineItem
        Dim curIndex As Integer = -1
        Dim curValue As Double
        Try

            '1. set the Graph Pane, graphics object
            gPane = zg5EditPlot.GraphPane
            'g = zg5EditPlot.CreateGraphics


            '2. table change the y value for the given points
            line = CType(gPane.CurveList(0), ZedGraph.LineItem)

            For i = 0 To m_EditSelPtIndexes.Count - 1
                curIndex = m_EditSelPtIndexes(i)
                curValue = m_EditData.Rows(curIndex).Item(db_fld_ValValue)
                'change the y-value = datavalue
                line.Points(curIndex).Y = curValue
            Next i

            '3. redraw the plot
            'UpdatePlotBounds(zg5EditPlot, m_EditData)
            zg5EditPlot.Refresh()

            '4. release resources
            'g.Dispose()
            line = Nothing
        Catch ex As Exception
            'show error msg
            ShowError("An Error occurred while updating the selected points on the Edit Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub
#End Region
#Region "From Hydrodesktop: Edit View"

    '    'Reset style of data grid view
    '    Public Sub ResetGridViewStyle() Handles dgvDataValues.Sorted
    '        'dgvDataValues.ReadOnly = True
    '        For i As Integer = 0 To dgvDataValues.Columns.Count - 1
    '            dgvDataValues.Columns(i).ReadOnly = True
    '        Next
    '        'dgvDataValues.Columns("DataValue").ReadOnly = False
    '        dgvDataValues.Columns("Other").Visible = False
    '        dgvDataValues.Columns("Selected").Visible = False

    '        dgvDataValues.ClearSelection()
    '        For i As Integer = 0 To dgvDataValues.Rows.Count - 1
    '            If dgvDataValues.Rows(i).Cells("Other").Value = -1 Then
    '                dgvDataValues.Rows(i).DefaultCellStyle.BackColor = Color.Red
    '            Else
    '                dgvDataValues.Rows(i).DefaultCellStyle.BackColor = Nothing
    '            End If

    '            If dgvDataValues.Rows(i).Cells("Selected").Value = 1 Then
    '                dgvDataValues.Rows(i).Selected = True
    '            Else
    '                dgvDataValues.Rows(i).Selected = False
    '            End If
    '        Next
    '    End Sub

    'Private Sub UpdateDataSeries(ByVal SeriesID As Integer)
    '    Dim SQLstring As String
    '    Dim BeginDateTime As DateTime
    '    Dim EndDateTime As DateTime
    '    Dim BeginDateTimeUTC As DateTime
    '    Dim EndDateTimeUTC As DateTime

    '    SQLstring = "SELECT LocalDateTime FROM DataValues WHERE SeriesID = " + SeriesID.ToString + " ORDER BY LocalDateTime"
    '    BeginDateTime = dbTools.ExecuteSingleOutput(SQLstring)
    '    SQLstring = "SELECT LocalDateTime FROM DataValues WHERE SeriesID = " + SeriesID.ToString + " ORDER BY LocalDateTime DESC"
    '    EndDateTime = dbTools.ExecuteSingleOutput(SQLstring)
    '    SQLstring = "SELECT DateTimeUTC FROM DataValues WHERE SeriesID = " + SeriesID.ToString + " ORDER BY DateTimeUTC"
    '    BeginDateTimeUTC = dbTools.ExecuteSingleOutput(SQLstring)
    '    SQLstring = "SELECT DateTimeUTC FROM DataValues WHERE SeriesID = " + SeriesID.ToString + " ORDER BY DateTimeUTC DESC"
    '    EndDateTimeUTC = dbTools.ExecuteSingleOutput(SQLstring)

    '    SQLstring = "UPDATE DataSeries SET ValueCount = " + SeriesRowsCount(SeriesID).ToString + ", "
    '    SQLstring += "BeginDateTime = '" + BeginDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', "
    '    SQLstring += "EndDateTime = '" + EndDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', "
    '    SQLstring += "BeginDateTimeUTC = '" + BeginDateTimeUTC.ToString("yyyy-MM-dd HH:mm:ss") + "', "
    '    SQLstring += "EndDateTimeUTC = '" + EndDateTimeUTC.ToString("yyyy-MM-dd HH:mm:ss") + "', "
    '    SQLstring += "UpdateDateTime = '" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "' "
    '    SQLstring += "WHERE SeriesID = " + SeriesID.ToString

    '    dbTools.ExecuteNonQuery(SQLstring)
    'End Sub

    'Public Sub SaveGraphChangesToDatabase()
    '    Dim SQLstring As String
    '    Dim SQLstring2 As String
    '    Dim datavalue As Double
    '    'Dim QualifierCode As String
    '    Dim ValueID As Integer
    '    Dim RowIndexList As New List(Of Integer)
    '    Dim RestoreDeletedPoint As Boolean = False
    '    Dim dt As New DataTable
    '    Dim ValueIDList As New List(Of Integer)


    '    'Deleting added points after restore data
    '    For i As Integer = 0 To dgvEditTable.Rows.Count - 1
    '        ValueIDList.Add(dgvEditTable.Rows(i).Cells("ValueID").Value)
    '    Next
    '    dt = dbTools.LoadTable("SELECT ValueID FROM DataValues WHERE SeriesID = " + newseriesID.ToString)
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        If Not ValueIDList.Contains(dt.Rows(i)("ValueID")) Then
    '            SQLstring = "DELETE FROM DataValues WHERE ValueID = " + dt.Rows(i)("ValueID").ToString
    '            dbTools.ExecuteNonQuery(SQLstring)
    '        End If
    '    Next


    '    'Setting progress bar
    '    ''Dim frmloading As ProgressBar = pbProgressBar
    '    'frmloading.Visible = True
    '    'frmloading.Maximum = dgvDataValues.Rows.Count - 1
    '    'frmloading.Minimum = 0
    '    'frmloading.Value = 0

    '    ' lblstatus.Text = "Saving..."
    '    SQLstring2 = "BEGIN TRANSACTION; "
    '    'saving by table
    '    For i As Integer = 0 To m_EditData.Rows.Count - 1

    '        ValueID = m_EditData.Rows(i)("ValueID")

    '        'deleting point

    '        If Not m_EditData.Rows(i)("Other") = 0 Then
    '            'Deleteing point
    '            If m_EditData.Rows(i)("Other") = -1 Then
    '                SQLstring = "DELETE FROM DataValues WHERE ValueID = " + ValueID.ToString + "; "
    '                SQLstring2 += SQLstring


    '                'Adding point
    '            ElseIf m_EditData.Rows(i)("Other") = 1 Then
    '                If dbTools.ExecuteSingleOutput("Select ValueID FROM DataValues WHERE ValueID = " + ValueID.ToString) = Nothing Then
    '                    SQLstring = "INSERT INTO DataValues (ValueID,SeriesID,DataValue,ValueAccuracy,LocalDateTime,UTCOffset,DateTimeUTC, "
    '                    SQLstring += "OffsetValue, OffsetTypeID, CensorCode, QualifierID, SampleID, FileID) VALUES ("
    '                    'ValueID,SeriesID,DataValue
    '                    For j As Integer = 0 To 2
    '                        SQLstring += m_EditData.Rows(i)(j).ToString + ","
    '                    Next
    '                    'ValueAccuracy
    '                    If m_EditData.Rows(i)(3) Is DBNull.Value Then
    '                        SQLstring += "NULL,"
    '                    Else
    '                        SQLstring += m_EditData.Rows(i)(3).ToString + ","
    '                    End If
    '                    'LocalDateTime
    '                    SQLstring += "'" + Convert.ToDateTime(m_EditData.Rows(i)(4)).ToString("yyyy-MM-dd HH:mm:ss") + "',"
    '                    'UTCOffset
    '                    SQLstring += m_EditData.Rows(i)(5).ToString
    '                    'DateTimeUTC
    '                    SQLstring += ",'" + Convert.ToDateTime(m_EditData.Rows(i)(6)).ToString("yyyy-MM-dd HH:mm:ss") + "',"
    '                    'OffsetValue
    '                    If m_EditData.Rows(i)(8) Is DBNull.Value Then
    '                        SQLstring += "NULL,"
    '                    Else
    '                        SQLstring += m_EditData.Rows(i)(8).ToString + ","
    '                    End If
    '                    'OffsetTypeID
    '                    If m_EditData.Rows(i)(9) Is DBNull.Value Then
    '                        SQLstring += "NULL,"
    '                    Else
    '                        SQLstring += m_EditData.Rows(i)(9).ToString + ","
    '                    End If
    '                    'CensorCode
    '                    If m_EditData.Rows(i)(10) Is DBNull.Value Then
    '                        SQLstring += "NULL,"
    '                    Else
    '                        SQLstring += "'" + m_EditData.Rows(i)(10).ToString + "',"
    '                    End If
    '                    'QualifierID
    '                    If m_EditData.Rows(i)(7) Is DBNull.Value Then
    '                        SQLstring += "NULL,"
    '                    Else
    '                        SQLstring += GetQualifierID(m_EditData.Rows(i)(7).ToString).ToString + ","
    '                    End If
    '                    'SampleID
    '                    If m_EditData.Rows(i)(11) Is DBNull.Value Then
    '                        SQLstring += "NULL,"
    '                    Else
    '                        SQLstring += m_EditData.Rows(i)(11).ToString() + ","
    '                    End If
    '                    'FileID
    '                    If m_EditData.Rows(i)(12) Is DBNull.Value Then
    '                        SQLstring += "NULL)"
    '                    Else
    '                        SQLstring += m_EditData.Rows(i)(12).ToString() + "); "
    '                    End If

    '                    SQLstring2 += SQLstring
    '                End If


    '                'updating point
    '            ElseIf m_EditData.Rows(i)("Other") = 2 Then
    '                'Update 
    '                If Not datavalue = dgvEditTable.Rows(i).Cells("DataValue").Value Then
    '                    SQLstring = "UPDATE DataValues SET DataValue = "
    '                    SQLstring += m_EditData.Rows(i)("DataValue").ToString + ", QualifierID = "
    '                    SQLstring += GetQualifierID(m_EditData.Rows(i)("QualifierCode")).ToString
    '                    SQLstring += " WHERE ValueID = "
    '                    SQLstring += ValueID.ToString + "; "

    '                    SQLstring2 += SQLstring

    '                End If
    '            End If
    '        End If

    '        'frmloading.Value = i
    '    Next

    '    SQLstring2 += "COMMIT;"

    '    dbTools.ExecuteNonQuery(SQLstring2)

    '    'Update DataSeries
    '    'UpdateDataSeries(newseriesID)

    '    ''Remove rows from dgvDataValues where is deleted
    '    'For i As Integer = 0 To dgvDataValues.Rows.Count - 1
    '    '    If dgvDataValues.Rows(i).Cells("Other").Value = -1 Then
    '    '        RowIndexList.Add(i)
    '    '    End If
    '    'Next

    '    'If RowIndexList.Count > 0 Then
    '    '    For i As Integer = RowIndexList.Count - 1 To 0
    '    '        dgvDataValues.Rows.Remove(dgvDataValues.Rows(RowIndexList(i)))
    '    '    Next
    '    'End If



    '    'Update Data Series
    '    DataSeriesHandling.UpdateDataSeriesFromDataValues(newseriesID)


    '    RefreshDataGridView()
    '    'zg5EditPlot.ReplotEditingCurve(m_EditData)

    '    'frmloading.Value = 0
    '    'lblstatus.Text = "Ready"

    'End Sub
    'Public Sub RefreshDataGridView()
    '    m_EditData.DefaultView.Sort = "[LocalDateTime] Asc"

    '    dgvEditTable.DataSource = m_EditData.DefaultView
    '    ResetGridViewStyle()
    'End Sub
#End Region


    Private Sub dgvEditTable_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEditTable.KeyUp
        dgvEditTable_SelectionChanged(sender, e)
    End Sub

    Private Sub dgvEditTable_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvEditTable.MouseClick
        dgvEditTable_SelectionChanged(sender, e)
    End Sub
End Class

