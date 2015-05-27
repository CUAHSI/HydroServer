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
''' Defines a new Streaming Data file
''' </summary>
''' <remarks></remarks>
Public Class frmAddNewFile
    'Last Documented 8/31/07

#Region " Member Variables "

    ''' <summary>
    ''' Contains all the data from the file
    ''' </summary>
    ''' <remarks></remarks>
    Private m_file As DataTable
    ''' <summary>
    ''' The current connection settings
    ''' </summary>
    ''' <remarks></remarks>
    Private m_connsettings As clsConnectionSettings
    ''' <summary>
    ''' Whether the File Mapping is new or modified
    ''' </summary>
    ''' <remarks></remarks>
    Private m_New As Boolean = True
    ''' <summary>
    ''' The old ID of the File Mapping
    ''' </summary>
    ''' <remarks></remarks>
    Private m_oldID As Integer
    ''' <summary>
    ''' The settings for DateTime, UTC DateTime, and TimeZone
    ''' </summary>
    ''' <remarks></remarks>
    Private m_DT, m_UTCDT, m_TimeZone As String
    ''' <summary>
    ''' Whether to account for Daylight Saving Time
    ''' </summary>
    ''' <remarks></remarks>
    Private m_DST As Boolean = True

#End Region

#Region " Properties "

    ''' <summary>
    ''' Returns the Type of FilePath
    ''' </summary>
    ''' <returns>the Type of FilePath</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetFileType() As String
        Get
            If rdoNFWeb.Checked Then
                Return "Web"
            Else
                Return "Local"
            End If
        End Get
    End Property
    ''' <summary>
    ''' Returns the FilePath
    ''' </summary>
    ''' <returns>the FilePath</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetFilePath() As String
        Get
            If rdoNFWeb.Checked Then
                Return txtNFWeb.Text
            Else
                Return txtNFLocal.Text
            End If
        End Get
    End Property
    ''' <summary>
    ''' Returns the Schedule Period
    ''' </summary>
    ''' <returns>the Schedule Period</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetSchedPeriod() As String
        'Returns the Schedule Period
        Get
            Return (numNFSchedPeriod.Value & " " & cboNFSchedPeriod.SelectedItem)
        End Get
    End Property
    ''' <summary>
    ''' Returns the Schedule beginning
    ''' </summary>
    ''' <returns>the Schedule beginning</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetSchedOffset() As String
        Get
            Return (dtpNFDate.Value.ToShortDateString & " " & dtpNFTime.Value.ToLongTimeString)
        End Get
    End Property
    ''' <summary>
    ''' Returns the number of series
    ''' </summary>
    ''' <returns>the number of series</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetNumSeries() As Integer
        Get
            Return dgvSMSeries.Rows.Count
        End Get
    End Property
    ''' <summary>
    ''' Returns the Connection Settings
    ''' </summary>
    ''' <returns>the Connection Settings</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetConnectionSettings() As clsConnectionSettings
        Get
            Return m_connsettings
        End Get
    End Property

#End Region

#Region " Form Functions "

    ''' <summary>
    ''' Converts the data within lvSMSeries to a DataTable
    ''' </summary>
    ''' <returns>The converted datatable</returns>
    ''' <remarks></remarks>
    Public Function GetSeriesData() As DataTable
        Dim table As New DataTable("SeriesData") 'Stores the data within lvSMSeries

        Try
            Dim i As Integer 'Counter Variable
            table.Columns.Add(config_Map_Val)
            table.Columns.Add(config_Map_Site)
            table.Columns.Add(config_Map_Var)
            table.Columns.Add(config_Map_OT)
            table.Columns.Add(config_Map_OffsetValue)
            table.Columns.Add(config_Map_Method)
            table.Columns.Add(config_Map_Source)
            table.Columns.Add(config_Map_QCLevel)
            table.Columns.Add(config_Map_FileBOR)
            table.Columns.Add(config_Map_DatabaseBOR)
            table.Columns.Add(config_Map_PeriodOfRecord)

            For i = 0 To (dgvSMSeries.Rows.Count - 1)
                table.Rows.Add(New String() {dgvSMSeries.Rows(i).Cells(1).Value, Split(dgvSMSeries.Rows(i).Cells(2).Value, " - ")(0), Split(dgvSMSeries.Rows(i).Cells(3).Value, " - ")(0), Split(dgvSMSeries.Rows(i).Cells(4).Value, " - ")(0), Split(dgvSMSeries.Rows(i).Cells(5).Value, " - ")(0), Split(dgvSMSeries.Rows(i).Cells(6).Value, " - ")(0), Split(dgvSMSeries.Rows(i).Cells(7).Value, " - ")(0), Split(dgvSMSeries.Rows(i).Cells(8).Value, " - ")(0), dgvSMSeries.Rows(i).Cells(9).Value.ToString, dgvSMSeries.Rows(i).Cells(10).Value.ToString, dgvSMSeries.Rows(i).Cells(11).Value.ToString})
            Next
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try

        Return table
    End Function
    ''' <summary>
    ''' Loads required data and populates dropdowns.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub frmAddNewFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not m_New Then
                btnNext.Enabled = isNFDone()
            Else
                cboNFSchedPeriod.SelectedIndex = 0
            End If

            dtpNFDate.Value = Now.Date
            dtpNFDate.MinDate = Now.Date.AddMonths(-1)
            dtpNFTime.Value = Now.Date.AddHours(Now.Hour)
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub
    ''' <summary>
    ''' Closes the form and returns DialogResult = Cancel
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    ''' <summary>
    ''' Goes back one page
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            btnCancel.Visible = True
            btnNext.Visible = True
            btnBack.Visible = False
            btnFinish.Visible = False

            pnlNewFile.Visible = True
            pnlSetMapping.Visible = False

            m_file.Clear()
            If m_New Then
                dgvSMSeries.Rows.Clear()
            End If
            rdoSM_DT.Checked = False
            cboSM_DT.Items.Clear()
            rdoSM_UTCDT.Checked = False
            cboSM_UTCDT.Items.Clear()
            m_DST = chbSM_DST.Checked
            grpSMTime.Enabled = True

            btnFinish.Enabled = isSMDone()
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' Goes Forward a page
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        Me.Cursor = Cursors.WaitCursor

        Dim selectedTime As String
        Dim fnd As Boolean
        Dim x, y As Integer 'Counter Variables
        Try
            If ucdbConnect.TestConnection() Then
                m_connsettings = ucdbConnect.GetDBSetttings
                Dim fileLoaded As Boolean = False 'Tracks whether the file has been loaded yet.
                If rdoNFWeb.Checked Then
                    If txtNFWeb.Text <> "" Then
                        Select Case cboDelimiter.Text
                            Case "<Comma Delimited>"
                                m_file = LoadFile(True, txtNFWeb.Text, numNFHeaderRow.Value, numNFDataRow.Value, ",")
                            Case "<Tab Delimited>"
                                m_file = LoadFile(True, txtNFWeb.Text, numNFHeaderRow.Value, numNFDataRow.Value, ControlChars.Tab)
                            Case Else
                                m_file = LoadFile(True, txtNFWeb.Text, numNFHeaderRow.Value, numNFDataRow.Value, cboDelimiter.Text)
                        End Select
                        fileLoaded = True
                    End If
                Else
                    If txtNFLocal.Text <> "" And (System.IO.Directory.GetFiles(Mid(txtNFLocal.Text, 1, txtNFLocal.Text.LastIndexOf("\")), Mid(txtNFLocal.Text, txtNFLocal.Text.LastIndexOf("\") + 2)).Length > 0) Then
                        Select Case cboDelimiter.Text
                            Case "<Comma Delimited>"
                                m_file = LoadFile(False, txtNFLocal.Text, numNFHeaderRow.Value, numNFDataRow.Value, ",")
                            Case "<Tab Delimited>"
                                m_file = LoadFile(False, txtNFLocal.Text, numNFHeaderRow.Value, numNFDataRow.Value, ControlChars.Tab)
                            Case Else
                                m_file = LoadFile(False, txtNFLocal.Text, numNFHeaderRow.Value, numNFDataRow.Value, cboDelimiter.Text)
                        End Select
                        fileLoaded = True
                    Else
                        ShowError("Unable to find file.")
                    End If
                End If

                If fileLoaded AndAlso (Not (m_file Is Nothing)) Then
                    dgvSMFile.SelectionMode = DataGridViewSelectionMode.CellSelect
                    dgvSMFile.DataSource = m_file

                    For x = 0 To (dgvSMFile.Columns.Count - 1)
                        cboSM_DT.Items.Add(dgvSMFile.Columns(x).Name)
                        cboSM_UTCDT.Items.Add(dgvSMFile.Columns(x).Name)
                        dgvSMFile.Columns(x).SortMode = DataGridViewColumnSortMode.Programmatic
                    Next x
                    dgvSMFile.SelectionMode = DataGridViewSelectionMode.FullColumnSelect

                    If Not m_New Then
                        If m_DT <> "" Then
                            rdoSM_DT.Checked = True
                            cboSM_DT.SelectedItem = m_DT
                            cboSM_TimeZone.SelectedItem = m_TimeZone
                        End If
                        If m_UTCDT <> "" Then
                            rdoSM_UTCDT.Checked = True
                            cboSM_UTCDT.SelectedItem = m_UTCDT
                        End If
                        If cboSM_UTCDT.SelectedIndex < 0 Then
                            rdoSM_UTCDT.Checked = False
                            rdoSM_DT.Checked = True
                        End If

                        chbSM_DST.Checked = m_DST

                        For x = 0 To (dgvSMSeries.Rows.Count - 1)
                            fnd = False  'When column name is found fnd, fnd = true. else, fnd = false.
                            For y = 0 To (dgvSMFile.Columns.Count - 1)
                                If (dgvSMSeries.Rows(x).Cells(1).Value = dgvSMFile.Columns(y).Name) Then
                                    fnd = True
                                    Exit For
                                End If
                            Next y
                            If Not fnd Then
                                dgvSMSeries.Rows.RemoveAt(x)
                            End If
                        Next x
                    End If

                    If rdoSM_UTCDT.Checked Then
                        selectedTime = cboSM_UTCDT.SelectedItem
                    Else
                        selectedTime = cboSM_DT.SelectedItem
                    End If

                    cboSM_UTCDT.Items.Clear()
                    cboSM_DT.Items.Clear()
                    For x = 0 To (dgvSMFile.Columns.Count - 1)
                        fnd = False
                        For y = 0 To (dgvSMSeries.Rows.Count - 1)
                            If dgvSMFile.Columns(x).Name = dgvSMSeries.Rows(y).Cells(1).Value Then
                                fnd = True
                            End If
                        Next y
                        If (Not fnd) Then
                            cboSM_UTCDT.Items.Add(dgvSMFile.Columns(x).Name)
                            cboSM_DT.Items.Add(dgvSMFile.Columns(x).Name)
                        End If
                    Next x

                    If rdoSM_UTCDT.Checked Then
                        cboSM_UTCDT.SelectedItem = selectedTime
                    Else
                        cboSM_DT.SelectedItem = selectedTime
                    End If

                    btnCancel.Visible = False
                    btnNext.Visible = False
                    btnBack.Visible = True
                    btnFinish.Visible = True

                    pnlNewFile.Visible = False
                    pnlSetMapping.Visible = True
                End If
                btnFinish.Enabled = isSMDone()

            End If
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' Closes the form and returns dialogResult = Ok
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Dim delimiter As String
        Me.Cursor = Cursors.WaitCursor
        Try
            m_file = Nothing
            'Select Case cboDelimiter.Text
            '    Case "<Tab Delimited>"
            '        delimiter = ControlChars.Tab
            '    Case "<Comma Delimited>"
            '        delimiter = ","
            '    Case Else
            delimiter = cboDelimiter.Text
            'End Select
            If m_New Then
                AddFile(m_connsettings, GetFileType, GetFilePath, GetSchedPeriod, GetSchedOffset, numNFHeaderRow.Value, numNFDataRow.Value, GetSeriesData, cboSM_DT.SelectedItem, cboSM_UTCDT.SelectedItem, cboSM_TimeZone.SelectedItem, chbSM_DST.Checked, chbOldData.Checked, delimiter)
            Else
                EditFile(m_connsettings, m_oldID, GetFileType, GetFilePath, GetSchedPeriod, GetSchedOffset, numNFHeaderRow.Value, numNFDataRow.Value, GetSeriesData, cboSM_DT.SelectedItem, cboSM_UTCDT.SelectedItem, cboSM_TimeZone.SelectedItem, chbSM_DST.Checked, chbOldData.Checked, delimiter)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' Default Constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    ''' <summary>
    ''' Constructor which loads data from the provided xml element
    ''' </summary>
    ''' <param name="file"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal file As Xml.XmlNode)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            Dim password As String 'Temporarily stores the password after it has been decrypted.
            m_New = False

            If (Not (file.Attributes(config_File_ID) Is Nothing)) Then
                m_oldID = file.Attributes(config_File_ID).Value
            End If

            If (Not (file.Item(config_File_Type) Is Nothing)) And (Not (file.Item(config_File_Type) Is Nothing)) Then
                If file.Item(config_File_Type).InnerText = "Web" Then
                    rdoNFWeb.Checked = True
                    txtNFWeb.Text = file.Item(config_File_Loc).InnerText
                Else
                    rdoNFLocal.Checked = True
                    txtNFLocal.Text = file.Item(config_File_Loc).InnerText
                End If
            End If

            If (Not (file.Item(config_File_HeaderRow) Is Nothing)) Then
                numNFHeaderRow.Value = file.Item(config_File_HeaderRow).InnerText
            End If
            If (Not (file.Item(config_File_DataRow) Is Nothing)) Then
                numNFDataRow.Value = file.Item(config_File_DataRow).InnerText
            End If

            If (Not (file.Item(config_File_SchedPeriod) Is Nothing)) Then
                numNFSchedPeriod.Value = Split(file.Item(config_File_SchedPeriod).InnerText)(0)
                cboNFSchedPeriod.SelectedItem = Split(file.Item(config_File_SchedPeriod).InnerText)(1)
            End If

            If (Not (file.Item(config_File_SchedOffset) Is Nothing)) Then
                Dim tempDate As DateTime 'Temporary DT value to parse individual dates or times into
                Date.TryParse(Split(file.Item(config_File_SchedOffset).InnerText)(0), tempDate)
                dtpNFDate.Value = tempDate
                Date.TryParse(Split(file.Item(config_File_SchedOffset).InnerText)(1), tempDate)
                dtpNFTime.Value = tempDate
            End If

            If (Not (file.Item(config_File_Delimiter) Is Nothing)) Then
                Select Case file.Item(config_File_Delimiter).InnerText
                    Case ControlChars.Tab
                        cboDelimiter.Text = "<Tab Delimited>"
                    Case ","
                        cboDelimiter.Text = "<Comma Delimited>"
                    Case Else
                        cboDelimiter.Text = file.Item(config_File_Delimiter).InnerText
                End Select
            End If

            Try
                password = Decrypt(file.Item(config_File_Password).InnerText)
            Catch ex As Exception
                password = ""
            End Try

            If (Not (file.Item(config_File_Server) Is Nothing)) And (Not (file.Item(config_File_DB) Is Nothing)) And (Not (file.Item(config_File_User) Is Nothing)) Then
                m_connsettings = New clsConnectionSettings(file.Item(config_File_Server).InnerText, file.Item(config_File_DB).InnerText, 10, False, file.Item(config_File_User).InnerText, password)
                ucdbConnect.GetDBSetttings = m_connsettings
            End If

            If (Not (file.Item(config_File_DT) Is Nothing)) AndAlso file.Item(config_File_DT).InnerText <> "" Then
                m_DT = file.Item(config_File_DT).InnerText
            End If
            If (Not (file.Item(config_File_UTCDT) Is Nothing)) AndAlso file.Item(config_File_UTCDT).InnerText <> "" Then
                m_UTCDT = file.Item(config_File_UTCDT).InnerText
            End If
            If (Not (file.Item(config_File_UTCOff) Is Nothing)) AndAlso file.Item(config_File_UTCOff).InnerText <> "" Then
                m_TimeZone = file.Item(config_File_UTCOff).InnerText
            End If
            If (Not (file.Item(config_File_IncludeOld) Is Nothing)) Then
                chbOldData.Checked = LCase(file.Item(config_File_IncludeOld).InnerText) = "true"
            End If
            If (Not (file.Item(config_File_DST) Is Nothing)) Then
                chbSM_DST.Checked = LCase(file.Item(config_File_DST).InnerText) = "true"
                m_DST = LCase(file.Item(config_File_DST).InnerText) = "true"
            End If

            Dim i As Integer 'Counter Variable
            Dim count As Integer = 0
            dgvSMSeries.Rows.Clear()
            For i = 0 To (file.ChildNodes.Count - 1)
                Dim map As Xml.XmlNode = file.ChildNodes(i) 'The 'Config_File_Map' XML node.
                If map.Name = config_File_Map Then
                    Try
                        count += 1
                        dgvSMSeries.Rows.Add(New Object() {count, map.Item(config_Map_Val).InnerText, map.Item(config_Map_Site).InnerText, map.Item(config_Map_Var).InnerText, map.Item(config_Map_OT).InnerText, map.Item(config_Map_OffsetValue).InnerText, map.Item(config_Map_Method).InnerText, map.Item(config_Map_Source).InnerText, map.Item(config_Map_QCLevel).InnerText, map.Item(config_Map_FileBOR).InnerText, map.Item(config_Map_DatabaseBOR).InnerText, map.Item(config_Map_PeriodOfRecord).InnerText})
                    Catch ex As Exception
                        ShowError(ex)
                    End Try
                End If
            Next
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

#End Region

#Region " Validation Functions "

#Region " New File Validation "

    ''' <summary>
    ''' Enforces the constraint that the first data row be after the header row
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub numNFHeaderRow_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numNFHeaderRow.ValueChanged
        numNFDataRow.Minimum = numNFHeaderRow.Value + 1
    End Sub
    ''' <summary>
    ''' If the ucDBConnection control has an error, closes the form.
    ''' </summary>
    ''' <param name="ex">the exception that describes the error</param>
    ''' <remarks></remarks>
    Private Sub ucdbConnect_ErrorOccured(ByVal ex As System.Exception) Handles ucdbConnect.ErrorOccured
        ShowError(ex)
        Me.Close()
    End Sub
    ''' <summary>
    ''' If local file is checked/unchecked, then enable/disable local address input and enable btnNext if the current page is complete.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub rdoNFLocal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNFLocal.CheckedChanged
        txtNFLocal.Enabled = rdoNFLocal.Checked
        btnNext.Enabled = isNFDone()
    End Sub
    ''' <summary>
    ''' If web file is checked/unchecked, then enable/disable web url input and enable btnNext if the current page is complete.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub rdoNFWeb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNFWeb.CheckedChanged
        txtNFWeb.Enabled = rdoNFWeb.Checked
        btnNext.Enabled = isNFDone()
    End Sub
    ''' <summary>
    ''' Validate local address
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub txtNFLocal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNFLocal.TextChanged
        btnNext.Enabled = isNFDone()
    End Sub
    ''' <summary>
    ''' Validate web url
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub txtNFWeb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNFWeb.TextChanged
        btnNext.Enabled = isNFDone()
    End Sub
    ''' <summary>
    ''' Opens the file browser dialog
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnNFBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNFBrowse.Click
        If ofdLocalFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtNFLocal.Text = ofdLocalFile.FileName
            ofdLocalFile.RestoreDirectory = True
        End If
        btnNext.Enabled = isNFDone()
    End Sub
    ''' <summary>
    ''' Enables/Disables btnNext
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ucdbConnect_DataChanged() Handles ucdbConnect.DataChanged
        btnNext.Enabled = isNFDone()
    End Sub
    ''' <summary>
    ''' Checks Whether New File (page) is finished
    ''' </summary>
    ''' <returns>Returns true if New File (page) is finished</returns>
    ''' <remarks></remarks>
    Private Function isNFDone() As Boolean
        Try
            If (rdoNFLocal.Checked And txtNFLocal.Text <> "") Or (rdoNFWeb.Checked And txtNFWeb.Text <> "") And (cboDelimiter.Text <> "") Then
                If ((numNFSchedPeriod.Value > 0) And (cboNFSchedPeriod.SelectedItem <> "")) Then
                    Return True
                End If
            End If
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
        Return False
    End Function

#End Region

#Region " Series Mapping Validation "

    ''' <summary>
    ''' Sets the mapping to use the currently selected column as the UTC DateTime
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub rdoSM_UTCDT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSM_UTCDT.CheckedChanged
        cboSM_UTCDT.Enabled = rdoSM_UTCDT.Checked
        If rdoSM_UTCDT.Checked Then
            If (dgvSMFile.SelectedColumns.Count > 0) Then
                cboSM_UTCDT.SelectedItem = dgvSMFile.SelectedColumns(0).Name
            Else
                If cboSM_UTCDT.Items.Count > 0 Then
                    cboSM_UTCDT.SelectedIndex = 0
                Else
                    cboSM_UTCDT.SelectedIndex = -1
                End If
            End If
        Else
            cboSM_UTCDT.SelectedIndex = -1
        End If

        btnFinish.Enabled = isSMDone()
    End Sub
    ''' <summary>
    ''' Sets the mapping to use the currently selected column as the Local DateTime
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub rdoSM_DT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSM_DT.CheckedChanged

        cboSM_DT.Enabled = rdoSM_DT.Checked
        cboSM_TimeZone.Enabled = rdoSM_DT.Checked
        chbSM_DST.Enabled = rdoSM_DT.Checked
        If rdoSM_DT.Checked Then
            If (dgvSMFile.SelectedColumns.Count > 0) Then
                cboSM_DT.SelectedItem = dgvSMFile.SelectedColumns(0).Name
            Else
                cboSM_DT.SelectedIndex = 0
            End If
        Else
            cboSM_DT.SelectedIndex = -1
        End If

        btnFinish.Enabled = isSMDone()
    End Sub
    ''' <summary>
    ''' Enables Series Edit and Remove buttons depending on how many (0,1,more) series are selected.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub dgvSMSeries_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSMSeries.SelectionChanged
        btnSMEdit.Enabled = (dgvSMSeries.SelectedRows.Count = 1)
        btnSMRemove.Enabled = (dgvSMSeries.SelectedRows.Count > 0)
    End Sub
    ''' <summary>
    ''' Adds a new Series mapping
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnSMAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSMAdd.Click
        Dim numColumns As Integer = (dgvSMFile.Columns.Count - 1) 'The number of columns in the File
        Dim valueColumns(0) As String 'The columns in the file that can be used for values
        Dim x, y As Integer 'Counter Variables 
        Dim offset As Integer 'Used to skip columns tha can't be used for values
        Dim fnd As Boolean 'When column name is found fnd, fnd = true. else, fnd = false.
        Dim SelectedTime As String

        For x = 0 To (dgvSMFile.Columns.Count - 1)
            If rdoSM_DT.Checked AndAlso (dgvSMFile.Columns(x).Name = cboSM_DT.SelectedItem) Then
                offset += 1
            ElseIf rdoSM_UTCDT.Checked AndAlso (dgvSMFile.Columns(x).Name = cboSM_UTCDT.SelectedItem) Then
                offset += 1
            Else
                ReDim Preserve valueColumns(x - offset)
                valueColumns(x - offset) = dgvSMFile.Columns(x).Name
            End If
        Next x

        Dim newSeries As frmNewSeries 'A Dialog Box that will create a new series (and metadata) for the column in the file
        If dgvSMFile.SelectedColumns.Count > 0 Then
            'MsgBox(dgvSMFile.SelectedColumns(0).Name)
            newSeries = New frmNewSeries(m_connsettings, valueColumns, dgvSMFile.SelectedColumns(0).Name)
        Else
            newSeries = New frmNewSeries(m_connsettings, valueColumns)
        End If

        If newSeries.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim maxID, i As Integer
            For i = 0 To dgvSMSeries.Rows.Count - 1
                If (dgvSMSeries.Rows(i).Cells(0).Value > maxID) Then
                    maxID = dgvSMSeries.Rows(i).Cells(0).Value
                End If
            Next
            dgvSMSeries.Rows.Add(New Object() {(maxID + 1), newSeries.SelectedValueColumn, newSeries.SelectedSite, newSeries.SelectedVariable, newSeries.SelectedOffsetType, newSeries.SelectedOffsetValue, newSeries.SelectedMethod, newSeries.SelectedSource, newSeries.SelectedQCLevel, newSeries.SelectedFileBeginningOfRecord, newSeries.SelectedDBBeginningOfRecord, newSeries.SelectedPeriodOfRecord})
        End If

        If rdoSM_UTCDT.Checked Then
            SelectedTime = cboSM_UTCDT.SelectedItem
        Else
            SelectedTime = cboSM_DT.SelectedItem
        End If

        cboSM_UTCDT.Items.Clear()
        cboSM_DT.Items.Clear()
        For x = 0 To (dgvSMFile.Columns.Count - 1)
            fnd = False
            For y = 0 To (dgvSMSeries.Rows.Count - 1)
                If dgvSMFile.Columns(x).Name = dgvSMSeries.Rows(y).Cells(1).Value.ToString Then
                    fnd = True
                End If
            Next y
            If (Not fnd) Then
                cboSM_UTCDT.Items.Add(dgvSMFile.Columns(x).Name)
                cboSM_DT.Items.Add(dgvSMFile.Columns(x).Name)
            End If
        Next x

        If rdoSM_UTCDT.Checked Then
            cboSM_UTCDT.SelectedItem = SelectedTime
        Else
            cboSM_DT.SelectedItem = SelectedTime
        End If

        If (dgvSMFile.SelectedColumns(0).Index < (dgvSMFile.Columns.Count - 1)) Then
            dgvSMFile.Columns(dgvSMFile.SelectedColumns(0).Index + 1).Selected = True
        End If

        btnFinish.Enabled = isSMDone()
    End Sub
    ''' <summary>
    ''' Edits a series mapping
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnSMEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSMEdit.Click
        If dgvSMSeries.SelectedRows.Count = 1 Then
            Dim SelectedTime As String
            Dim numColumns As Integer = (dgvSMFile.Columns.Count - 1) 'Number of columns in the file
            Dim valueColumns(0) As String 'The columns in the file that can be used for values
            Dim x, y As Integer 'Counter Variables
            Dim offset As Integer 'Used to skip columns that can't be used for values.
            Dim fnd As Boolean 'When column name is found fnd, fnd = true. else, fnd = false.

            For x = 0 To (dgvSMFile.Columns.Count - 1)
                If rdoSM_DT.Checked AndAlso (dgvSMFile.Columns(x).Name = cboSM_DT.SelectedItem) Then
                    offset += 1
                ElseIf rdoSM_UTCDT.Checked AndAlso (dgvSMFile.Columns(x).Name = cboSM_UTCDT.SelectedItem) Then
                    offset += 1
                Else
                    ReDim Preserve valueColumns(x - offset)
                    valueColumns(x - offset) = dgvSMFile.Columns(x).Name
                End If
            Next

            Dim newSeries As New frmNewSeries(m_connsettings, valueColumns, _
            dgvSMSeries.SelectedRows(0).Cells(1).Value, _
            dgvSMSeries.SelectedRows(0).Cells(2).Value, _
            dgvSMSeries.SelectedRows(0).Cells(3).Value, _
            dgvSMSeries.SelectedRows(0).Cells(4).Value, _
            dgvSMSeries.SelectedRows(0).Cells(5).Value, _
            dgvSMSeries.SelectedRows(0).Cells(6).Value, _
            dgvSMSeries.SelectedRows(0).Cells(7).Value, _
            dgvSMSeries.SelectedRows(0).Cells(8).Value, _
            dgvSMSeries.SelectedRows(0).Cells(9).Value, _
            dgvSMSeries.SelectedRows(0).Cells(10).Value, _
            dgvSMSeries.SelectedRows(0).Cells(11).Value.ToString) 'Allows you to edit an existing data series/metadata combination.

            If newSeries.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvSMSeries.SelectedRows(0).Cells(1).Value = newSeries.SelectedValueColumn
                dgvSMSeries.SelectedRows(0).Cells(2).Value = newSeries.SelectedSite
                dgvSMSeries.SelectedRows(0).Cells(3).Value = newSeries.SelectedVariable
                dgvSMSeries.SelectedRows(0).Cells(4).Value = newSeries.SelectedOffsetType
                If newSeries.SelectedOffsetType <> db_expr_None Then
                    dgvSMSeries.SelectedRows(0).Cells(5).Value = newSeries.SelectedOffsetValue
                Else
                    dgvSMSeries.SelectedRows(0).Cells(5).Value = db_expr_None
                End If
                dgvSMSeries.SelectedRows(0).Cells(6).Value = newSeries.SelectedMethod
                dgvSMSeries.SelectedRows(0).Cells(7).Value = newSeries.SelectedSource
                dgvSMSeries.SelectedRows(0).Cells(8).Value = newSeries.SelectedQCLevel
            End If
            dgvSMSeries.SelectedRows(0).Selected = False

            If rdoSM_UTCDT.Checked Then
                SelectedTime = cboSM_UTCDT.SelectedItem
            Else
                SelectedTime = cboSM_DT.SelectedItem
            End If

            cboSM_UTCDT.Items.Clear()
            cboSM_DT.Items.Clear()
            For x = 0 To (dgvSMFile.Columns.Count - 1)
                fnd = False
                For y = 0 To (dgvSMSeries.Rows.Count - 1)
                    If dgvSMFile.Columns(x).Name = dgvSMSeries.Rows(y).Cells(1).Value Then
                        fnd = True
                    End If
                Next y
                If (Not fnd) Then
                    cboSM_UTCDT.Items.Add(dgvSMFile.Columns(x).Name)
                    cboSM_DT.Items.Add(dgvSMFile.Columns(x).Name)
                End If
            Next x

            If rdoSM_UTCDT.Checked Then
                cboSM_UTCDT.SelectedItem = SelectedTime
            Else
                cboSM_DT.SelectedItem = SelectedTime
            End If

            btnFinish.Enabled = isSMDone()
        End If

        btnFinish.Enabled = isSMDone()
    End Sub
    ''' <summary>
    ''' Removes a series mapping
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnSMRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSMRemove.Click
        Dim x, y As Integer 'Counter Variables
        Dim fnd As Boolean 'When column name is found fnd, fnd = true. else, fnd = false.
        Dim oldTimeSelection As String = ""

        If MsgBox("Are you sure you want to remove these mappings?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            While (dgvSMSeries.SelectedRows.Count > 0)
                dgvSMSeries.Rows.Remove(dgvSMSeries.SelectedRows(0))
            End While
        End If

        'grpSMTime.Enabled = (lvSMSeries.Items.Count = 0) OrElse Not (((cboSM_DT.SelectedItem <> "") And (cboSM_UTCDT.SelectedItem <> "")) Or ((cboSM_UTCDT.SelectedItem <> "") And (cboSm_TimeZone.SelectedItem <> "")) Or ((cboSm_TimeZone.SelectedItem <> "") And (cboSM_DT.SelectedItem <> "")))
        If rdoSM_DT.Checked Then
            oldTimeSelection = cboSM_DT.SelectedItem
        ElseIf rdoSM_UTCDT.Checked Then
            oldTimeSelection = cboSM_UTCDT.SelectedItem
        End If
        cboSM_UTCDT.Items.Clear()
        cboSM_DT.Items.Clear()
        For x = 0 To (dgvSMFile.Columns.Count - 1)
            fnd = False
            For y = 0 To (dgvSMSeries.Rows.Count - 1)
                If dgvSMFile.Columns(x).Name = dgvSMSeries.Rows(y).Cells(1).Value Then
                    fnd = True
                End If
            Next y
            If (Not fnd) Then
                cboSM_UTCDT.Items.Add(dgvSMFile.Columns(x).Name)
                cboSM_DT.Items.Add(dgvSMFile.Columns(x).Name)
            End If
        Next x

        If rdoSM_DT.Checked Then
            cboSM_DT.SelectedItem = oldTimeSelection
        ElseIf rdoSM_UTCDT.Checked Then
            cboSM_UTCDT.SelectedItem = oldTimeSelection
        End If

        btnFinish.Enabled = isSMDone()
    End Sub
    ''' <summary>
    ''' Determines whether finished defining a Database Mapping 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isSMDone() As Boolean
        Try
            Return isNFDone() AndAlso (dgvSMSeries.Rows.Count > 0) AndAlso ((rdoSM_DT.Checked AndAlso cboSM_DT.SelectedItem <> "") OrElse (rdoSM_UTCDT.Checked AndAlso cboSM_UTCDT.SelectedItem <> ""))
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
        Return False
    End Function

#End Region

#End Region

End Class
