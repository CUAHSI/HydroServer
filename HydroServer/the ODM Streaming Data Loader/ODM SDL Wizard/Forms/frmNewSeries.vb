'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..

''' <summary>
''' Everything needed to create/choose a data series for a column of streaming data to connect to.
''' </summary>
''' <remarks></remarks>
Public Class frmNewSeries
    'Last Documented 1/1/1

#Region " Member Variables "

    ''' <summary>
    ''' The pages of the add new series wizard
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum Pages
        ValueColumn = 0
        Site = 1
        Variable = 2
        Method = 3
        Source = 4
        Offset = 5
        QualityControl = 6
    End Enum
    ''' <summary>
    ''' The connection settings to the database
    ''' </summary>
    ''' <remarks></remarks>
    Private m_connsettings As clsConnectionSettings
    ''' <summary>
    ''' The current page the wizard is on
    ''' </summary>
    ''' <remarks></remarks>
    Private m_CurrentPage As Pages = Pages.ValueColumn
    ''' <summary>
    ''' Which column in the streaming data file should correspond to the data values for the series chosen by the wizard
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ValueColumn As String
    ''' <summary>
    ''' The variableID of the series to use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Variable As Integer
    ''' <summary>
    ''' The siteID of the series to use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Site As Integer
    ''' <summary>
    ''' The offsetTypeID of the series to use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_OffsetType As String
    ''' <summary>
    ''' The offsetValue of the series to use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_OffsetValue As String
    ''' <summary>
    ''' The methodID of the series to use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Method As Integer
    ''' <summary>
    ''' The sourceID of the series to use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Source As Integer
    ''' <summary>
    ''' The qualityControlLevelID of the series to use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_QCLevel As Integer = -9999
    ''' <summary>
    ''' True if record in the file is recorded at the Start of Interval
    ''' </summary>
    ''' <remarks></remarks>
    Private m_FileBOR As Boolean
    ''' <summary>
    ''' True if the record should be stored in the database as the Start of Interval
    ''' </summary>
    ''' <remarks></remarks>
    Private m_DBBOR As Boolean
    ''' <summary>
    ''' The length of the Interval for conversion from EOI to SOI, or SOI to EOI
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PeriodOfRecord As TimeSpan

#End Region

#Region " Properties "

    ''' <summary>
    ''' Returns the column name from the file which will be used as the DataValues for the selected data series
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedValueColumn() As String
        Get
            Return m_ValueColumn
        End Get
    End Property
    ''' <summary>
    ''' The VariableID for the selected data series
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedVariable() As String
        Get
            Return m_Variable
        End Get
    End Property
    ''' <summary>
    ''' The SiteID for the selected data series
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedSite() As String
        Get
            Return m_Site
        End Get
    End Property
    ''' <summary>
    ''' The OffsetTypeID for the selected data series
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedOffsetType() As String
        Get
            Return m_OffsetType
        End Get
    End Property
    ''' <summary>
    ''' The OffsetValue for the selected OffsetTypeID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedOffsetValue() As String
        Get
            Return m_OffsetValue
        End Get
    End Property
    ''' <summary>
    ''' The MethodID for the selected data series
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedMethod() As String
        Get
            Return m_Method
        End Get
    End Property
    ''' <summary>
    ''' The SourceID for the selected data series
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedSource() As String
        Get
            Return m_Source
        End Get
    End Property
    ''' <summary>
    ''' The QualityControlLevelID for the selected data series
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedQCLevel() As String
        Get
            Return m_QCLevel
        End Get
    End Property
    ''' <summary>
    ''' True if the data was recorded at the start of interval
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedFileBeginningOfRecord() As Boolean
        Get
            Return m_FileBOR
        End Get
    End Property
    ''' <summary>
    ''' True if the data should be save to the database as the start of interval
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedDBBeginningOfRecord() As Boolean
        Get
            Return m_DBBOR
        End Get
    End Property
    ''' <summary>
    ''' The length of interval
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedPeriodOfRecord() As TimeSpan
        Get
            Return m_PeriodOfRecord
        End Get
    End Property

#End Region

#Region " Form Functions "

    ''' <summary>
    ''' Create a new File mapping
    ''' </summary>
    ''' <param name="e_settings">the connection settings to the database</param>
    ''' <param name="ValueColumns">The list of columns in the file</param>
    ''' <param name="e_ValueColumn">The column from the streaming file that should be the default selection for the datavalue</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_settings As clsConnectionSettings, ByVal ValueColumns() As String, Optional ByVal e_ValueColumn As String = "")

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            m_connsettings = e_settings

            cboValColumn.Items.AddRange(ValueColumns)
            m_ValueColumn = e_ValueColumn
            cboValColumn.SelectedItem = m_ValueColumn

        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub
    ''' <summary>
    ''' Edit and existing File mapping
    ''' </summary>
    ''' <param name="e_settings">the connection settings to the database</param>
    ''' <param name="ValueColumns">The list of columns in the file</param>
    ''' <param name="e_ValueColumn">The column from the streaming file that used to be the selection for the datavalue</param>
    ''' <param name="e_Site">The SiteID of previous file mapping</param>
    ''' <param name="e_Var">The VariableID of the previous file mapping</param>
    ''' <param name="e_OffsetType">The OffsetTypeID of the previous file mapping</param>
    ''' <param name="e_OffsetValue">The OffsetValue of the previous file mapping</param>
    ''' <param name="e_Method">The MethodID of the previous file mapping</param>
    ''' <param name="e_Source">The SourceID of the previous file mapping</param>
    ''' <param name="e_QCLevel">The QualityControlLevelID of the previous file mapping</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_settings As clsConnectionSettings, ByVal ValueColumns() As String, ByVal e_ValueColumn As String, ByVal e_Site As String, ByVal e_Var As String, ByVal e_OffsetType As String, ByVal e_OffsetValue As String, ByVal e_Method As String, ByVal e_Source As String, ByVal e_QCLevel As String, ByVal e_FileBOR As Boolean, ByVal e_DBBOR As Boolean, ByVal e_PeriodOfRecord As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            m_connsettings = e_settings

            cboValColumn.Items.AddRange(ValueColumns)
            m_ValueColumn = e_ValueColumn
            cboValColumn.SelectedItem = m_ValueColumn

            m_Site = e_Site
            m_Variable = e_Var
            m_OffsetType = e_OffsetType
            m_OffsetValue = e_OffsetValue
            m_Method = e_Method
            m_Source = e_Source
            m_QCLevel = e_QCLevel
            m_FileBOR = e_FileBOR
            m_DBBOR = e_DBBOR
            m_PeriodOfRecord = TimeSpan.Parse(e_PeriodOfRecord)
            If m_PeriodOfRecord <> New TimeSpan(0) Then
                numDays.Value = m_PeriodOfRecord.Days
                numHours.Value = m_PeriodOfRecord.Hours
                numMinutes.Value = m_PeriodOfRecord.Minutes
                numSeconds.Value = m_PeriodOfRecord.Seconds
                rdoAggregate.Checked = True
                rdoInstantaneous.Checked = False
                rdoFileYes.Checked = e_FileBOR
                rdoFileNo.Checked = (Not e_FileBOR)
                rdoDBYes.Checked = e_DBBOR
                rdoDBNo.Checked = (Not e_DBBOR)

            End If



        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub
    ''' <summary>
    ''' Cancels the dialog
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    ''' <summary>
    ''' Finishes the form and returns dialog result
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        If m_CurrentPage = Pages.QualityControl Then
            m_QCLevel = ucSelect.SelectedValue
        End If
        SetPORData()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    ''' <summary>
    ''' Moves the wizard back a page
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Select Case m_CurrentPage
            Case Pages.Site
                btnCancel.Visible = True
                btnBack.Visible = False
                pnlValColumn.Visible = True
                ucSelect.Visible = False

            Case Pages.Variable
                ucSelect.ResetData(ucSelectRow.TableNames.Site, m_connsettings, m_Site)

            Case Pages.Method
                ucSelect.ResetData(ucSelectRow.TableNames.Variable, m_connsettings, m_Variable)

            Case Pages.Source
                ucSelect.ResetData(ucSelectRow.TableNames.Method, m_connsettings, m_Method)

            Case Pages.Offset
                ucSelect.ResetData(ucSelectRow.TableNames.Source, m_connsettings, m_Source)


            Case Pages.QualityControl
                ucSelect.ResetData(ucSelectRow.TableNames.OffsetTypes, m_connsettings, m_OffsetType, m_OffsetValue)
                btnNext.Visible = True
                btnFinish.Visible = False

            Case Else
                btnCancel.Visible = True
                btnFinish.Visible = True
                btnBack.Visible = False
                btnNext.Visible = False
        End Select
        m_CurrentPage -= 1
    End Sub
    ''' <summary>
    ''' Moves the wizard forward a page
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            Select Case m_CurrentPage
                Case Pages.QualityControl
                    m_QCLevel = ucSelect.SelectedValue
                    btnCancel.Visible = True
                    btnFinish.Visible = True
                    btnBack.Visible = False
                    btnNext.Visible = False
                Case Pages.Offset
                    m_OffsetType = ucSelect.SelectedValue
                    m_OffsetValue = ucSelect.SelectedOffsetValue
                    m_CurrentPage += 1
                    ucSelect.ResetData(ucSelectRow.TableNames.QCLevel, m_connsettings, m_QCLevel)
                    btnNext.Visible = False
                    btnFinish.Visible = True
                    If ucSelect.SelectedValue <> "" Then
                        btnFinish.Enabled = True
                    End If
                Case Pages.Source
                    m_Source = ucSelect.SelectedValue
                    m_CurrentPage += 1
                    ucSelect.ResetData(ucSelectRow.TableNames.OffsetTypes, m_connsettings, m_OffsetType, m_OffsetValue)
                Case Pages.Method
                    m_Method = ucSelect.SelectedValue
                    m_CurrentPage += 1
                    ucSelect.ResetData(ucSelectRow.TableNames.Source, m_connsettings, m_Source)
                Case Pages.Variable
                    m_Variable = ucSelect.SelectedValue
                    m_CurrentPage += 1
                    ucSelect.ResetData(ucSelectRow.TableNames.Method, m_connsettings, m_Method)
                Case Pages.Site
                    m_Site = ucSelect.SelectedValue
                    m_CurrentPage += 1
                    ucSelect.ResetData(ucSelectRow.TableNames.Variable, m_connsettings, m_Variable)
                Case Pages.ValueColumn
                    ucSelect.ResetData(ucSelectRow.TableNames.Site, m_connsettings, m_Site)
                    btnCancel.Visible = False
                    btnBack.Visible = True
                    pnlValColumn.Visible = False
                    ucSelect.Visible = True
                    m_CurrentPage += 1
                Case Else
                    btnCancel.Visible = True
                    btnFinish.Visible = True
                    btnBack.Visible = False
                    btnNext.Visible = False
            End Select
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
    End Sub

#End Region

#Region " Validation Functions "

    ''' <summary>
    ''' Enables the next button when a Value Column is selected
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub cboValColumn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboValColumn.SelectedIndexChanged
        m_ValueColumn = cboValColumn.SelectedItem
        If m_ValueColumn <> "" Then
            btnNext.Enabled = True
        End If
    End Sub
    ''' <summary>
    ''' Enables/Disables Start of Interval data input
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub rdoAggregate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAggregate.CheckedChanged
        pnlAggregate.Enabled = rdoAggregate.Checked
        SetPORData()
    End Sub
    ''' <summary>
    ''' Saves ubSeleciton info
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ucSelect_SelectionChanged() Handles ucSelect.SelectionChanged
        If (ucSelect.SelectedValue <> "") Then
            If (m_CurrentPage = Pages.Offset) AndAlso (ucSelect.SelectedOffsetValue <> "") Then
                btnNext.Enabled = True
            ElseIf (m_CurrentPage = Pages.QualityControl) Then
                btnFinish.Enabled = True
            Else
                btnNext.Enabled = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' Kills the form and reports to the owner that an error occurred
    ''' </summary>
    ''' <param name="ex">An exception that describes the error that occurred</param>
    ''' <remarks></remarks>
    Private Sub ucSelect_ErrorOccured(ByVal ex As System.Exception) Handles ucSelect.ErrorOccured
        ShowError(ex)
        Me.Close()
    End Sub
    ''' <summary>
    ''' Writes the StartOfInterval data to member variables
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPORData()
        If rdoAggregate.Checked Then
            m_FileBOR = rdoFileYes.Checked
            m_DBBOR = rdoDBYes.Checked
            m_PeriodOfRecord = New TimeSpan(numDays.Value, numHours.Value, numMinutes.Value, numSeconds.Value)
        Else
            m_FileBOR = True
            m_DBBOR = True
            m_PeriodOfRecord = New TimeSpan(0)
        End If
    End Sub

#End Region



End Class