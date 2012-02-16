Public Class frmWizard
    'TODO: FINISH GUI Setup
    'TODO: FINISH GUI Layout
    'TODO: FINISH 'JavaDoc'
    'TODO: FINISH Documentation

#Region " File Paths "

    Protected m_Path_Batch As String = ""
    Protected m_Path_Log As String = ""
    Protected m_Path_Groups As String = "" '______________Requires GroupDescriptions, DataValues
    Protected m_Path_DerivedFrom As String = "" '_________Requires DataValues
    Protected m_Path_DataValues As String = "" '__________Requires Sites, Variables, Methods, Sources, Samples, OffsetTypes, QualityControlLevels, Qualifiers
    Protected m_Path_Categories As String = "" '__________Requires Variables
    Protected m_Path_GroupDescriptions As String = ""
    Protected m_Path_Sources As String = "" '_____________Requires ISOMetadata
    Protected m_Path_Samples As String = "" '_____________Requires LabMethods
    Protected m_Path_QualityControlLevels As String = ""
    Protected m_Path_OffsetTypes As String = ""
    Protected m_Path_Qualifiers As String = ""
    Protected m_Path_Variables As String = ""
    Protected m_Path_Methods As String = ""
    Protected m_Path_Sites As String = ""
    Protected m_Path_ISOMetadata As String = ""
    Protected m_Path_LabMethods As String = ""

#End Region

    Protected m_connection As clsConnection
    Const m_MaxRows As Integer = 1000
    Protected m_ViewFile As New DataTable
    Protected m_loadingLinks As Boolean = False
    Protected m_loading(13) As Boolean

#Region " File Type Tracking "

    Protected Enum FileType
        EVIL = 15
        DataValues = 14
        Groups = 13
        DerivedFrom = 12
        Categories = 11
        GroupDescriptions = 10
        Sources = 9
        Samples = 8
        QualityControlLevels = 7
        OffsetTypes = 6
        Qualifiers = 5
        Variables = 4
        Methods = 3
        Sites = 2
        ISOMetadata = 1
        LabMethods = 0
        NONE = -1
    End Enum

    Protected m_Type_Main As FileType = FileType.DataValues
    Protected m_Type_Current As FileType
    Protected m_Type_Temp As FileType

    Protected Function NextType(ByVal MainType As FileType, Optional ByVal lastFile As FileType = FileType.NONE) As FileType
        Select Case MainType
            'Case FileType.Categories
            '    Select Case lastFile
            '        Case FileType.NONE
            '            Return FileType.Variables
            '        Case Else
            '            Return FileType.NONE
            '    End Select
            'Case FileType.Sources
            '    Select Case lastFile
            '        Case FileType.NONE
            '            Return FileType.ISOMetadata
            '        Case Else
            '            Return FileType.NONE
            '    End Select
            'Case FileType.Samples
            '    Select Case lastFile
            '        Case FileType.NONE
            '            Return FileType.LabMethods
            '        Case Else
            '            Return FileType.NONE
            '    End Select
            Case FileType.DataValues
                Select Case lastFile
                    Case FileType.NONE
                        Return FileType.Sites
                    Case FileType.Sites
                        Return FileType.Variables
                    Case FileType.Variables
                        Return FileType.OffsetTypes
                    Case FileType.OffsetTypes
                        Return FileType.ISOMetadata
                    Case FileType.ISOMetadata
                        Return FileType.Sources
                    Case FileType.Sources
                        Return FileType.Methods
                    Case FileType.Methods
                        Return FileType.LabMethods
                    Case FileType.LabMethods
                        Return FileType.Samples
                    Case FileType.Samples
                        Return FileType.Qualifiers
                    Case FileType.Qualifiers
                        Return FileType.QualityControlLevels
                    Case FileType.QualityControlLevels
                        Return FileType.GroupDescriptions
                    Case FileType.GroupDescriptions
                        Return FileType.Groups
                    Case FileType.Groups
                        Return FileType.DerivedFrom
                    Case FileType.DerivedFrom
                        Return FileType.Categories
                    Case Else
                        Return FileType.NONE
                End Select
                'Case FileType.ValSiteVar
                '    Select Case lastFile
                '        Case FileType.NONE
                '            Return FileType.OffsetTypes
                '        Case FileType.OffsetTypes
                '            Return FileType.ISOMetadata
                '        Case FileType.ISOMetadata
                '            Return FileType.Sources
                '        Case FileType.Sources
                '            Return FileType.Methods
                '        Case FileType.Methods
                '            Return FileType.LabMethods
                '        Case FileType.LabMethods
                '            Return FileType.Samples
                '        Case FileType.Samples
                '            Return FileType.Qualifiers
                '        Case FileType.Qualifiers
                '            Return FileType.QualityControlLevels
                '        Case FileType.QualityControlLevels
                '            Return FileType.GroupDescriptions
                '        Case FileType.GroupDescriptions
                '            Return FileType.Groups
                '        Case FileType.Groups
                '            Return FileType.DerivedFrom
                '        Case FileType.DerivedFrom
                '            Return FileType.Categories
                '        Case Else
                '            Return FileType.NONE
                '    End Select
            Case FileType.EVIL
                Select Case lastFile
                    Case FileType.NONE
                        Return FileType.GroupDescriptions
                    Case FileType.GroupDescriptions
                        Return FileType.Groups
                    Case FileType.Groups
                        Return FileType.DerivedFrom
                    Case FileType.DerivedFrom
                        Return FileType.Categories
                    Case Else
                        Return FileType.NONE
                End Select
                'Case FileType.DerivedFrom
                '    Select Case lastFile
                '        Case FileType.NONE
                '            Return FileType.Sites
                '        Case FileType.Sites
                '            Return FileType.Variables
                '        Case FileType.Variables
                '            Return FileType.OffsetTypes
                '        Case FileType.OffsetTypes
                '            Return FileType.ISOMetadata
                '        Case FileType.ISOMetadata
                '            Return FileType.Sources
                '        Case FileType.Sources
                '            Return FileType.Methods
                '        Case FileType.Methods
                '            Return FileType.LabMethods
                '        Case FileType.LabMethods
                '            Return FileType.Samples
                '        Case FileType.Samples
                '            Return FileType.Qualifiers
                '        Case FileType.Qualifiers
                '            Return FileType.QualityControlLevels
                '        Case FileType.QualityControlLevels
                '            Return FileType.DataValues
                '        Case Else
                '            Return FileType.NONE
                '    End Select
                'Case FileType.Groups
                '    Select Case lastFile
                '        Case FileType.NONE
                '            Return FileType.Sites
                '        Case FileType.Sites
                '            Return FileType.Variables
                '        Case FileType.Variables
                '            Return FileType.OffsetTypes
                '        Case FileType.OffsetTypes
                '            Return FileType.ISOMetadata
                '        Case FileType.ISOMetadata
                '            Return FileType.Sources
                '        Case FileType.Sources
                '            Return FileType.Methods
                '        Case FileType.Methods
                '            Return FileType.LabMethods
                '        Case FileType.LabMethods
                '            Return FileType.Samples
                '        Case FileType.Samples
                '            Return FileType.Qualifiers
                '        Case FileType.Qualifiers
                '            Return FileType.QualityControlLevels
                '        Case FileType.QualityControlLevels
                '            Return FileType.DataValues
                '        Case FileType.DataValues
                '            Return FileType.GroupDescriptions
                '        Case Else
                '            Return FileType.NONE
                '    End Select
            Case Else
                Return FileType.NONE
        End Select
    End Function

    Protected Function LastType(ByVal MainType As FileType, Optional ByVal lastFile As FileType = FileType.NONE) As FileType
        'TODO: FINISH LastType
        Select Case MainType
            Case FileType.DataValues
                Select Case lastFile
                    Case FileType.NONE
                        Return FileType.Categories
                    Case FileType.Categories
                        Return FileType.DerivedFrom
                    Case FileType.DerivedFrom
                        Return FileType.Groups
                    Case FileType.Groups
                        Return FileType.GroupDescriptions
                    Case FileType.GroupDescriptions
                        Return FileType.QualityControlLevels
                    Case FileType.QualityControlLevels
                        Return FileType.Qualifiers
                    Case FileType.Qualifiers
                        Return FileType.Samples
                    Case FileType.Samples
                        Return FileType.LabMethods
                    Case FileType.LabMethods
                        Return FileType.Methods
                    Case FileType.Methods
                        Return FileType.Sources
                    Case FileType.Sources
                        Return FileType.ISOMetadata
                    Case FileType.ISOMetadata
                        Return FileType.OffsetTypes
                    Case FileType.OffsetTypes
                        Return FileType.Variables
                    Case FileType.Variables
                        Return FileType.Sites
                    Case Else
                        Return FileType.NONE
                End Select
            Case FileType.EVIL
                Select Case lastFile
                    Case FileType.NONE
                        Return FileType.Categories
                    Case FileType.Categories
                        Return FileType.DerivedFrom
                    Case FileType.DerivedFrom
                        Return FileType.Groups
                    Case FileType.Groups
                        Return FileType.GroupDescriptions
                    Case Else
                        Return FileType.NONE
                End Select
            Case Else
                Return FileType.NONE
        End Select
    End Function

    Protected Function TypeName(ByVal curr As FileType) As String
        Select Case curr
            Case FileType.Groups
                Return "Groups"
            Case FileType.DerivedFrom
                Return "Derived From"
            Case FileType.DataValues
                Return "Data Values"
            Case FileType.Categories
                Return "Categories"
            Case FileType.GroupDescriptions
                Return "Group Descriptions"
            Case FileType.Sources
                Return "Sources"
            Case FileType.Samples
                Return "Samples"
            Case FileType.QualityControlLevels
                Return "Quality Control Levels"
            Case FileType.OffsetTypes
                Return "OffsetTypes"
            Case FileType.Qualifiers
                Return "Qualifiers"
            Case FileType.Variables
                Return "Variables"
            Case FileType.Methods
                Return "Methods"
            Case FileType.Sites
                Return "Sites"
            Case FileType.ISOMetadata
                Return "ISO Metadata"
            Case FileType.LabMethods
                Return "Lab Methods"
            Case Else
                Return "Invalid File"
        End Select
    End Function

    Protected Function TypeCaptions(ByVal main As FileType, ByVal curr As FileType) As String
        'TODO: FINISH TypeCaptions
        Select Case curr
            Case FileType.Groups
                Return "Groups"
            Case FileType.DerivedFrom
                Return "Derived From"
            Case FileType.DataValues
                Return "Data Values"
            Case FileType.Categories
                Return "Categories"
            Case FileType.GroupDescriptions
                Return "Group Descriptions"
            Case FileType.Sources
                Return "Sources"
            Case FileType.Samples
                Return "Samples"
            Case FileType.QualityControlLevels
                Return "Quality Control Levels"
            Case FileType.OffsetTypes
                Return "OffsetTypes"
            Case FileType.Qualifiers
                Return "Qualifiers"
            Case FileType.Variables
                Return "Variables"
            Case FileType.Methods
                Return "Methods"
            Case FileType.Sites
                Return "Sites"
            Case FileType.ISOMetadata
                Return "ISO Metadata"
            Case FileType.LabMethods
                Return "Lab Methods"
            Case Else
                Return ""
        End Select
    End Function

    Protected Property FilePath(ByVal curr As FileType) As String
        Get
            Select Case curr
                Case FileType.Groups
                    Return m_Path_Groups
                Case FileType.DerivedFrom
                    Return m_Path_DerivedFrom
                Case FileType.DataValues
                    Return m_Path_DataValues
                Case FileType.Categories
                    Return m_Path_Categories
                Case FileType.GroupDescriptions
                    Return m_Path_GroupDescriptions
                Case FileType.Sources
                    Return m_Path_Sources
                Case FileType.Samples
                    Return m_Path_Samples
                Case FileType.QualityControlLevels
                    Return m_Path_QualityControlLevels
                Case FileType.OffsetTypes
                    Return m_Path_OffsetTypes
                Case FileType.Qualifiers
                    Return m_Path_Qualifiers
                Case FileType.Variables
                    Return m_Path_Variables
                Case FileType.Methods
                    Return m_Path_Methods
                Case FileType.Sites
                    Return m_Path_Sites
                Case FileType.ISOMetadata
                    Return m_Path_ISOMetadata
                Case FileType.LabMethods
                    Return m_Path_LabMethods
                Case Else
                    Return ""
            End Select
        End Get
        Set(ByVal path As String)
            Select Case curr
                Case FileType.Groups
                    m_Path_Groups = path
                Case FileType.DerivedFrom
                    m_Path_DerivedFrom = path
                Case FileType.DataValues
                    m_Path_DataValues = path
                Case FileType.Categories
                    m_Path_Categories = path
                Case FileType.GroupDescriptions
                    m_Path_GroupDescriptions = path
                Case FileType.Sources
                    m_Path_Sources = path
                Case FileType.Samples
                    m_Path_Samples = path
                Case FileType.QualityControlLevels
                    m_Path_QualityControlLevels = path
                Case FileType.OffsetTypes
                    m_Path_OffsetTypes = path
                Case FileType.Qualifiers
                    m_Path_Qualifiers = path
                Case FileType.Variables
                    m_Path_Variables = path
                Case FileType.Methods
                    m_Path_Methods = path
                Case FileType.Sites
                    m_Path_Sites = path
                Case FileType.ISOMetadata
                    m_Path_ISOMetadata = path
                Case FileType.LabMethods
                    m_Path_LabMethods = path
                    'Case Else
                    '    Return ""
            End Select
        End Set
    End Property

    Protected Function GetTableType(ByVal m_viewTable As DataTable) As FileType
        'This is where you set the correct filetype.  
        If (m_viewTable.Columns.IndexOf(clsConnection.db_fld_SiteName) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) Then
            'Loading Sites table
            Return FileType.Sites
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_VarName) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) Then
            'Loading Variables table
            Return FileType.Variables
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_MethDesc) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) Then
            'Loading Methods table
            Return FileType.Methods
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_LMLabName) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_SampleType) < 0) Then
            'Loading LabMethods table
            Return FileType.LabMethods
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_SrcOrg) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) Then
            'Loading Sources table
            Return FileType.Sources
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_SampleType) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) Then
            'Loading Samples table
            Return FileType.Samples
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_QlfyDesc) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) Then
            'Loading Qualifiers table
            Return FileType.Qualifiers
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_IMDTopicCat) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_SrcOrg) < 0) Then
            'Loading ISOMetadata table
            Return FileType.ISOMetadata
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_QCLQCLCode) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) Then
            'Loading QualityControlLevels table
            Return FileType.QualityControlLevels
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_GDDesc) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) Then
            'Loading GroupDescriptions table
            Return FileType.GroupDescriptions
        ElseIf (m_viewTable.Columns.Count = 2) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_DFID) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValID) >= 0) Then
            'Loading DerivedFrom table
            Return FileType.DerivedFrom
        ElseIf (m_viewTable.Columns.Count = 2) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_GroupID) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValID) >= 0) Then
            'Loading Groups table
            Return FileType.Groups
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_CatDesc) >= 0) Then
            'Loading Categories table
            Return FileType.Categories
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_OTDesc) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) < 0) Then
            'Loading OffsetTypes table
            Return FileType.OffsetTypes
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_SiteCode) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_VarCode) >= 0) Then
            If (m_viewTable.Columns.IndexOf(clsConnection.db_fld_SrcOrg) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_MethDesc) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_SampleLabCode) >= 0) And (m_viewTable.Columns.IndexOf(clsConnection.db_fld_QCLQCLCode) >= 0) Then
                Return FileType.EVIL
            Else
                Return FileType.DataValues
            End If
        ElseIf (m_viewTable.Columns.IndexOf(clsConnection.db_fld_ValValue) >= 0) Then
            'Loading DataValues table
            Return FileType.DataValues
        End If
        Return FileType.NONE
    End Function

#End Region

#Region " Wizard Panel Tracking "

    Protected Enum Page
        Batch = 1
        FilePath = 2
        LinkPath = 3
        Done = 4
    End Enum

    Protected m_Page_Current As Page = Page.Batch

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        'TODO: FINISH btnBack
        Select Case m_Page_Current - 1
            Case Page.Batch
                btnBack.Visible = False
                pnlBatch.Visible = True
                pnlFilePath.Visible = False
                m_Page_Current = Page.Batch
                btnBack.Enabled = True
            Case Page.FilePath
                If (LastType(m_Type_Main, m_Type_Current) = FileType.NONE) Then
                    pnlFilePath.Visible = True
                    pnlLinkPath.Visible = False
                    m_Page_Current = Page.FilePath
                    ''TODO: Justin: Testing Only
                    'MsgBox("Changing Current" & vbCrLf & TypeName(m_Type_Current) & vbCrLf & TypeName(FileType.NONE))
                    ''!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    m_Type_Current = FileType.NONE
                    btnBack.Enabled = True
                Else
                    ''TODO: Justin: Testing Only
                    'MsgBox("Changing Current" & vbCrLf & TypeName(m_Type_Current) & vbCrLf & TypeName(LastType(m_Type_Main, m_Type_Current)))
                    ''!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    m_Type_Current = LastType(m_Type_Main, m_Type_Current)
                    grpLinkLoad.Text = "Would you like to load " & TypeName(m_Type_Current)
                    lblLinkCap.Text = "Not loading " & TypeName(m_Type_Current)
                    rdoYesLoad.Text = "Load " & TypeName(m_Type_Current)
                    rdoNoLoad.Text = "Don't Load " & TypeName(m_Type_Current)
                    dgvLinkView.DataSource = New DataTable
                    txtLinkPath.Text = FilePath(m_Type_Current)
                    rdoYesLoad.Checked = m_loading(m_Type_Current)
                    rdoNoLoad.Checked = Not m_loading(m_Type_Current)
                    btnBack.Enabled = True
                End If
            Case Page.LinkPath
                ''TODO: Justin: Testing Only
                'MsgBox("Changing Current" & vbCrLf & TypeName(m_Type_Current) & vbCrLf & TypeName(LastType(m_Type_Main)))
                ''!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                m_Type_Current = LastType(m_Type_Main)
                grpLinkLoad.Text = "Would you like to load " & TypeName(m_Type_Current)
                lblLinkCap.Text = "Not loading " & TypeName(m_Type_Current)
                rdoYesLoad.Text = "Load " & TypeName(m_Type_Current)
                rdoNoLoad.Text = "Don't Load " & TypeName(m_Type_Current)
                rdoYesLoad.Checked = m_loading(m_Type_Current)
                rdoNoLoad.Checked = Not m_loading(m_Type_Current)
                btnFinish.Visible = False
                btnNext.Visible = True
                pnlLinkPath.Visible = True
                pnlDone.Visible = False
                m_Page_Current = Page.LinkPath
                btnBack.Enabled = True
            Case Else
                'TODO: Error Message
        End Select
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'TODO: FINISH btnNext
        Select Case m_Page_Current + 1
            Case Page.FilePath
                If (txtBatPath.Text <> "") Then
                    Dim file As String = txtBatPath.Text
                    Dim dir As String = ""
                    If (txtBatPath.Text.Contains("\")) Then
                        dir = file.Substring(0, file.LastIndexOf("\") + 1)
                    End If
                    If (IO.Directory.Exists(dir) Or dir = "") AndAlso (ucConnect.TestConnection) Then
                        txtLogPath.Text = dir & "log.text"
                        btnBack.Visible = True
                        pnlBatch.Visible = False
                        pnlFilePath.Visible = True
                        m_Path_Batch = txtBatPath.Text
                        m_Page_Current = Page.FilePath
                        m_Type_Current = FileType.DataValues
                        For i As Integer = 0 To (m_loading.Length - 1)
                            m_loading(i) = True
                        Next
                    End If
                End If
            Case Page.LinkPath
                If (txtLogPath.Text <> "") And (txtFilePath.Text <> "") Then
                    Dim file As String = txtBatPath.Text
                    Dim dir As String = ""
                    If (txtLogPath.Text.Contains("\")) Then
                        dir = file.Substring(0, file.LastIndexOf("\") + 1)
                    End If
                    If (IO.Directory.Exists(dir) Or dir = "") AndAlso (IO.File.Exists(txtFilePath.Text)) AndAlso (m_Type_Main <> FileType.NONE) Then
                        FilePath(m_Type_Main) = txtFilePath.Text
                        pnlFilePath.Visible = False
                        pnlLinkPath.Visible = True
                        m_Page_Current = Page.LinkPath
                        ''TODO: Justin: Testing Only
                        'MsgBox("Changing Current" & vbCrLf & TypeName(m_Type_Current) & vbCrLf & TypeName(NextType(m_Type_Main)))
                        ''!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_Type_Current = NextType(m_Type_Main)
                        txtLinkPath.Text = FilePath(m_Type_Current)
                        grpLinkLoad.Text = "Would you like to load " & TypeName(m_Type_Current)
                        lblLinkCap.Text = "Not loading " & TypeName(m_Type_Current)
                        rdoYesLoad.Text = "Load " & TypeName(m_Type_Current)
                        rdoNoLoad.Text = "Don't Load " & TypeName(m_Type_Current)
                        rdoYesLoad.Checked = m_loading(m_Type_Current)
                        rdoNoLoad.Checked = Not m_loading(m_Type_Current)
                    End If
                End If
            Case Page.Done
                'TODO: Finish 'next link' logic
                If AllowNext() Then
                    If (NextType(m_Type_Main, m_Type_Current) = FileType.NONE) Then
                        btnNext.Visible = False
                        btnFinish.Visible = True
                        pnlLinkPath.Visible = False
                        pnlDone.Visible = True
                        m_Page_Current = Page.Done
                        m_Type_Current = FileType.NONE
                    Else
                        'Justin: Fix btnNext.Enabled
                        'btnNext.Enabled = False
                        m_Type_Current = NextType(m_Type_Main, m_Type_Current)
                        dgvLinkView.DataSource = New DataTable
                        txtLinkPath.Text = FilePath(m_Type_Current)
                        grpLinkLoad.Text = "Would you like to load " & TypeName(m_Type_Current)
                        lblLinkCap.Text = "Not loading " & TypeName(m_Type_Current)
                        rdoYesLoad.Text = "Load " & TypeName(m_Type_Current)
                        rdoNoLoad.Text = "Don't Load " & TypeName(m_Type_Current)
                        rdoYesLoad.Checked = m_loading(m_Type_Current)
                        rdoNoLoad.Checked = Not m_loading(m_Type_Current)
                    End If
                End If
                'TODO: Finish 'moving to done' page logic
                ''Buttons

                ''Member Variables
            Case Else

        End Select
    End Sub
    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        'TODO: FINISH btnFinish
        If m_Page_Current = Page.Done Then
            If WriteBatFile() Then
                If rdoYesRun.Checked Then
                    System.Diagnostics.Process.Start(m_Path_Batch)
                End If
                Close()
            End If
        Else
        End If
    End Sub

#End Region

#Region " Batch Panel "

    Private Sub btnBatBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatBrowse.Click
        'TODO: FINISH btnBatBrowse_Click
        Dim temp As String = txtBatPath.Text.Substring(0, txtBatPath.Text.LastIndexOf("\") + 1)
        If System.IO.Directory.Exists(temp) Then
            sfdSaveBat.FileName = txtBatPath.Text
        Else
            sfdSaveBat.InitialDirectory = ""
        End If
        If sfdSaveBat.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtBatPath.Text = sfdSaveBat.FileName
        End If
    End Sub

#End Region

#Region " File Panel "

    Private Sub btnFileBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileBrowse.Click
        'TODO: FINISH btnFileBrowse_Click
        ofdLoadDataFiles.Title = "Select a file to load"
        ofdLoadDataFiles.FileName = txtFilePath.Text
        If ofdLoadDataFiles.ShowDialog() = Windows.Forms.DialogResult.OK Then
            dgvLinkView.Enabled = False
            dgvFileView.Enabled = False
            'Justin: Fix btnNext.Enabled
            'btnNext.Enabled = False
            btnBack.Enabled = False
            txtFilePath.Text = ofdLoadDataFiles.FileName
            m_loadingLinks = False
            btnFilePreview.PerformClick()
            '    Dim viewtable as datatable = LoadFile(txtFilePath.Text)
            '    m_Type_Main = GetTableType(viewtable)

            '    If (m_Type_Main <> FileType.NONE) Then
            '        dgvFileView.DataSource = viewtable
            '    Else
            '        dgvFileView.DataSource = New DataTable
            '    End If
            '    lblFileType.Text = "Loading: " & TypeName(m_Type_Main)
        End If
    End Sub
    Private Sub txtFilePath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilePath.TextChanged
        'TODO: FINISH txtFilePath_TextChanged
        FilePath(m_Type_Main) = txtFilePath.Text
        m_Path_Log = txtLogPath.Text
    End Sub

    Private Sub btnFilePreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilePreview.Click
        'TODO: FINISH btnFilePreview_Click
        If IO.File.Exists(txtFilePath.Text) Then
            btnBack.Enabled = False
            btnNext.Enabled = False
            FilePreview.RunWorkerAsync()
            'Dim viewtable as datatable = LoadFile(txtFilePath.Text)
            'm_Type_Main = GetTableType(viewtable)

            'If (m_Type_Main <> FileType.NONE) Then
            '    dgvFileView.DataSource = viewtable
            'Else
            '    dgvFileView.DataSource = New DataTable
            'End If
            'lblFileType.Text = "Loading: " & TypeName(m_Type_Main)
        End If
    End Sub

#End Region

#Region " Link Panel "

    Private Sub btnLinkBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinkBrowse.Click
        'TODO: FINISH btnLinkBrowse_Click
        ofdLoadDataFiles.Title = "Select a file to load"
        ofdLoadDataFiles.FileName = txtFilePath.Text
        If ofdLoadDataFiles.ShowDialog() = Windows.Forms.DialogResult.OK Then
            dgvLinkView.Enabled = False
            dgvFileView.Enabled = False
            'Justin: Fix btnNext.Enabled
            'btnNext.Enabled = False
            btnBack.Enabled = False
            txtLinkPath.Text = ofdLoadDataFiles.FileName
            m_loadingLinks = True
            btnLinkPreview.PerformClick()
            '    Dim viewtable as datatable = LoadFile(txtFilePath.Text)
            '    m_Type_Main = GetTableType(viewtable)

            '    If (m_Type_Main <> FileType.NONE) Then
            '        dgvFileView.DataSource = viewtable
            '    Else
            '        dgvFileView.DataSource = New DataTable
            '    End If
            '    lblFileType.Text = "Loading: " & TypeName(m_Type_Main)
        End If
    End Sub
    Private Sub txtLinkPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLinkPath.TextChanged
        'TODO: FINISH txtLinkPath_TextChanged
        'm_Path_Temp = txtLinkPath.Text
    End Sub

    Private Sub rdoYesLoad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoYesLoad.CheckedChanged
        btnLinkBrowse.Enabled = rdoYesLoad.Checked
        txtLinkPath.Enabled = rdoYesLoad.Checked
        m_loading(m_Type_Current) = rdoYesLoad.Checked
    End Sub
    Private Sub rdoNoLoad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNoLoad.CheckedChanged
        lblLinkCap.Visible = rdoNoLoad.Checked
        If rdoNoLoad.Checked Then
            txtLinkPath.Text = ""
            'Justin: Fix btnNext.Enabled
            'btnNext.Enabled = True
        End If
    End Sub

    Private Sub btnLinkPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinkPreview.Click
        'TODO: FINISH btnLinkPreview_Click
        If IO.File.Exists(txtLinkPath.Text) Then
            FilePath(m_Type_Current) = txtLinkPath.Text
            FilePreview.RunWorkerAsync()
            'Dim viewtable as datatable = LoadFile(txtFilePath.Text)
            'm_Type_Main = GetTableType(viewtable)

            'If (m_Type_Main <> FileType.NONE) Then
            '    dgvFileView.DataSource = viewtable
            'Else
            '    dgvFileView.DataSource = New DataTable
            'End If
            'lblFileType.Text = "Loading: " & TypeName(m_Type_Main)
        End If
    End Sub

#End Region

#Region " Done Panel "

    Protected Function WriteBatFile()
        m_connection = ucConnect.GetDBSetttings
        If (m_connection Is Nothing) Then
            Return (False)
        End If
        '-server = server path
        '-db = database name
        '-user = username
        '-password
        '-enc = encrypted password
        '-file = path to file to load
        '-log = path to log file
        Dim writer As System.IO.StreamWriter = Nothing

        If (m_Path_Batch = "") Then
            m_Path_Batch = System.IO.Path.GetTempPath & "temp.bat"
        End If
        If (m_Path_Log = "") Then
            m_Path_Log = m_Path_Batch.Substring(0, m_Path_Batch.LastIndexOf(".")) & ".txt"
        End If
        Try
            writer = New System.IO.StreamWriter(m_Path_Batch)

            If (m_Path_Sites <> "") AndAlso (System.IO.File.Exists(m_Path_Sites)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_Sites & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_Variables <> "") AndAlso (System.IO.File.Exists(m_Path_Variables)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_Variables & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_OffsetTypes <> "") AndAlso (System.IO.File.Exists(m_Path_OffsetTypes)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_OffsetTypes & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_ISOMetadata <> "") AndAlso (System.IO.File.Exists(m_Path_ISOMetadata)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_ISOMetadata & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_Sources <> "") AndAlso (System.IO.File.Exists(m_Path_Sources)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_Sources & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_Methods <> "") AndAlso (System.IO.File.Exists(m_Path_Methods)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_Methods & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_LabMethods <> "") AndAlso (System.IO.File.Exists(m_Path_LabMethods)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_LabMethods & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_Samples <> "") AndAlso (System.IO.File.Exists(m_Path_Samples)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_Samples & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_Qualifiers <> "") AndAlso (System.IO.File.Exists(m_Path_Qualifiers)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_Qualifiers & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_QualityControlLevels <> "") AndAlso (System.IO.File.Exists(m_Path_QualityControlLevels)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_QualityControlLevels & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_DataValues <> "") AndAlso (System.IO.File.Exists(m_Path_DataValues)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_DataValues & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_GroupDescriptions <> "") AndAlso (System.IO.File.Exists(m_Path_GroupDescriptions)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_GroupDescriptions & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_Groups <> "") AndAlso (System.IO.File.Exists(m_Path_Groups)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_Groups & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_DerivedFrom <> "") AndAlso (System.IO.File.Exists(m_Path_DerivedFrom)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_DerivedFrom & """ -log """ & m_Path_Log & """")
            End If
            If (m_Path_Categories <> "") AndAlso (System.IO.File.Exists(m_Path_Categories)) Then
                writer.WriteLine("ODMLoader.exe -server " & m_connection.ServerAddress & _
                " -db " & m_connection.DBName & " -user " & m_connection.UserID & _
                " -enc """ & Encrypt(m_connection.Password) & """ -file """ & m_Path_Categories & """ -log """ & m_Path_Log & """")
            End If

            writer.Flush()
            writer.Close()
        Catch ex As Exception
            ShowError("Error writing batch file.", ex)
            If Not (writer Is Nothing) Then
                writer.Close()
            End If
            Return False
        End Try
        Return True
    End Function

#End Region

#Region " File Loading "

    'Protected Function LoadFile(ByVal m_filepath As String) as new datatable
    '    'Loads a fullPath into a datatable.  Can be comma or tab delimited. 
    '    Dim reader As System.IO.StreamReader
    '    Dim fullPath As String
    '    Dim x As Integer
    '    Dim LastSlash As Integer
    '    Dim lastPeriod As Integer
    '    Dim shortName As String = "file"
    '    If (m_filepath.Contains("\") AndAlso m_filepath.Contains(".")) Then
    '        LastSlash = m_filepath.LastIndexOf("\") + 1
    '        lastPeriod = m_filepath.LastIndexOf(".")
    '        If (lastPeriod > LastSlash) Then
    '            shortName = m_filepath.Substring(LastSlash, lastPeriod - LastSlash)
    '        End If
    '    End If
    '    Dim table As New DataTable(shortName)
    '    'Dim table As New DataTable(m_FilePath.Substring((m_FilePath.LastIndexOf("\") + 1), m_FilePath.Length - (m_FilePath.LastIndexOf("\") + 1)))
    '    Try
    '        If (m_filepath.StartsWith("http:\\") Or m_filepath.StartsWith("ftp:\\")) Then
    '            Dim myWebClient As New Net.WebClient()
    '            Dim tempPath As String
    '            tempPath = System.IO.Path.GetTempPath & "ODMSDL"
    '            'LogUpdate(vbTab & vbTab & "Getting Data from Website..." & vbCrLf & "From: " & m_filepath & vbCrLf & "To: " & tempPath & "\DataImport.txt")
    '            Try
    '                If Not (System.IO.Directory.Exists(tempPath)) Then
    '                    System.IO.Directory.CreateDirectory(tempPath)
    '                End If
    '                myWebClient.DownloadFile(m_filepath, tempPath & "\DataImport.txt")
    '                If System.IO.File.Exists(tempPath & "\DataImport.txt") Then
    '                    fullPath = tempPath & "\DataImport.txt"
    '                Else
    '                    ShowError("Error downloading Table." & vbCrLf & tempPath)
    '                    Return New DataTable("ERROR")
    '                End If
    '            Catch ex As Exception
    '                ShowError("Error Downloading Data From Website", ex)
    '                Return New DataTable("ERROR")
    '            End Try
    '            'LogUpdate(vbTab & vbTab & "...Finished Getting Data")
    '        Else
    '            If System.IO.File.Exists(m_filepath) Then
    '                fullPath = m_filepath
    '            Else
    '                ShowError("Invalid Filepath")
    '                Return New DataTable("ERROR")
    '            End If
    '        End If

    '        Dim FileSize As New System.IO.FileInfo(fullPath)
    '        If (FileSize.Length > ((0.9 * My.Computer.Info.AvailablePhysicalMemory) + (0.9 * My.Computer.Info.AvailableVirtualMemory))) Then
    '            ShowError("File Size: " & FileSize.Length & " bytes" & vbCrLf & "Available System Memory: " & CInt((0.9 * My.Computer.Info.AvailablePhysicalMemory) + (0.9 * My.Computer.Info.AvailableVirtualMemory)) & " bytes ")
    '            Return New DataTable("ERROR")
    '        End If

    '        ' LogUpdate(vbTab & vbTab & "Opening " & fullPath & " ...")
    '        Dim count As Integer = 0
    '        Try
    '            If fullPath.EndsWith("xls") Or fullPath.EndsWith("xlsx") Or fullPath.EndsWith("xlsb") Then
    '                Return LoadExcel(m_filepath)
    '                'm_ViewTable = LoadExcel(path)
    '            Else
    '                reader = New System.IO.StreamReader(m_filepath)
    '                'reader = New System.IO.StreamReader(fullPath)
    '                Dim delimiter As String
    '                Dim FileRow As String = reader.ReadLine
    '                If ((ProcessLine(FileRow, vbTab).Length) > (ProcessLine(FileRow, ",").Length)) Then
    '                    delimiter = vbTab
    '                Else
    '                    delimiter = ","
    '                End If
    '                Dim columns() As String = ProcessLine(FileRow, delimiter)
    '                'Dim columns() As String = Split(FileRow, delimiter)
    '                Dim column As String
    '                table.BeginInit()
    '                For Each column In columns
    '                    table.Columns.Add(column)
    '                Next
    '                table.EndInit()

    '                table.BeginLoadData()
    '                While (Not reader.EndOfStream)
    '                    FileRow = reader.ReadLine
    '                    Dim temprow() As String = ProcessLine(FileRow, delimiter)
    '                    'Dim tempRow() As String = StringSplit(delimiter, FileRow)
    '                    For x = 0 To (temprow.Length - 1)
    '                        If LCase(temprow(x)) = "null" Then
    '                            temprow(x) = ""
    '                        End If
    '                    Next
    '                    While (temprow.Length > table.Columns.Count)
    '                        table.Columns.Add()
    '                    End While
    '                    table.Rows.Add(temprow)
    '                    count += 1
    '                    temprow = Nothing
    '                    'TODO: REMOVE THIS?
    '                    '
    '                    If (count >= m_MaxRows) Then
    '                        '    Exit While
    '                        Me.Refresh()

    '                        count = 0
    '                    End If
    '                End While
    '                table.EndLoadData()
    '                table.AcceptChanges()
    '                reader.Close()
    '                Return table
    '                'LogUpdate(vbTab & vbTab & fullPath & " Opened.")
    '            End If
    '        Catch ex As Exception
    '            ShowError("Error Loading " & fullPath & " .", ex)
    '            Return New DataTable
    '        End Try

    '    Catch ex As System.IO.InvalidDataException
    '        If Not (reader Is Nothing) Then
    '            reader.Close()
    '        End If
    '        ShowError("Error Loading File: " & m_filepath & " .", ex)
    '        Return LoadExcel(m_filepath)
    '    Catch ex As System.Net.WebException
    '        If Not (reader Is Nothing) Then
    '            reader.Close()
    '        End If
    '        ShowError("Unable to Connect to Web File: " & m_filepath & " .", ex)
    '    Catch ex As Exception
    '        If Not (reader Is Nothing) Then
    '            reader.Close()
    '        End If
    '        ShowError("Error Loading File: " & m_filepath & " .", ex)
    '        Return LoadExcel(m_filepath)
    '    End Try

    '    Return New DataTable("ERROR")
    'End Function

    Private Function LoadExcel(ByVal m_filepath As String) As DataTable
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim LastSlash As Integer
        Dim lastPeriod As Integer
        Dim shortName As String = "file"
        If m_filepath.Contains("\") Then
            If m_filepath.Contains(".") Then
                LastSlash = m_filepath.LastIndexOf("\") + 1
                lastPeriod = m_filepath.LastIndexOf(".")
                If (lastPeriod > LastSlash) Then
                    shortName = m_filepath.Substring(LastSlash, lastPeriod - LastSlash)
                End If
            Else
                LastSlash = m_filepath.LastIndexOf("\") + 1
                shortName = m_filepath.Substring(LastSlash)
            End If
        Else
            If m_filepath.Contains(".") Then
                lastPeriod = m_filepath.LastIndexOf(".")
                shortName = m_filepath.Substring(0, lastPeriod)
            Else
                shortName = m_filepath
            End If
        End If
        Dim table As New DataTable(shortName)
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

        MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & m_filepath & " '; " & "Extended Properties=""Excel 8.0; HDR=Yes; IMEX = 1""")

        ' Select the data from the workbook.
        Try
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & shortName & "$]", MyConnection)
            MyCommand.Fill(table)
        Catch err As OleDb.OleDbException
            Try
                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [sheet1$]", MyConnection)
                MyCommand.Fill(table)
                m_Type_Main = GetTableType(table)
            Catch ex As Exception
                ShowError("The sheet with the data must have the same name as the file (" & shortName & ") or be named sheet1.")
                Return New DataTable("Error")
            End Try
        End Try

        MyConnection.Close()
        Return table
    End Function

#End Region

    Private Sub FilePreview_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles FilePreview.DoWork
        Dim m_filepath As String
        'MsgBox(TypeName(m_Type_Current))
        If m_loadingLinks Then
            m_filepath = FilePath(m_Type_Current)
        Else
            m_filepath = txtFilePath.Text
        End If

        'Loads a fullPath into a datatable.  Can be comma or tab delimited. 
        Dim reader As System.IO.StreamReader = Nothing
        Dim fullPath As String = ""
        Dim x As Integer
        Dim LastSlash As Integer
        Dim lastPeriod As Integer
        Dim shortName As String = "file"
        If m_filepath.Contains("\") Then
            If m_filepath.Contains(".") Then
                LastSlash = m_filepath.LastIndexOf("\") + 1
                lastPeriod = m_filepath.LastIndexOf(".")
                If (lastPeriod > LastSlash) Then
                    shortName = m_filepath.Substring(LastSlash, lastPeriod - LastSlash)
                End If
            Else
                LastSlash = m_filepath.LastIndexOf("\") + 1
                shortName = m_filepath.Substring(LastSlash)
            End If
        Else
            If m_filepath.Contains(".") Then
                lastPeriod = m_filepath.LastIndexOf(".")
                shortName = m_filepath.Substring(0, lastPeriod)
            Else
                shortName = m_filepath
            End If
        End If
        Dim table As New DataTable(shortName)
        'Dim table As New DataTable(m_FilePath.Substring((m_FilePath.LastIndexOf("\") + 1), m_FilePath.Length - (m_FilePath.LastIndexOf("\") + 1)))
        Try
            If (m_filepath.StartsWith("http:\\") Or m_filepath.StartsWith("ftp:\\")) Then
                Dim myWebClient As New Net.WebClient()
                Dim tempPath As String
                tempPath = System.IO.Path.GetTempPath & "ODMSDL"
                'LogUpdate(vbTab & vbTab & "Getting Data from Website..." & vbCrLf & "From: " & m_filepath & vbCrLf & "To: " & tempPath & "\DataImport.txt")
                Try
                    If Not (System.IO.Directory.Exists(tempPath)) Then
                        System.IO.Directory.CreateDirectory(tempPath)
                    End If
                    myWebClient.DownloadFile(m_filepath, tempPath & "\DataImport.txt")
                    If System.IO.File.Exists(tempPath & "\DataImport.txt") Then
                        fullPath = tempPath & "\DataImport.txt"
                    Else
                        ShowError("Error downloading Table." & vbCrLf & tempPath)
                        m_ViewFile = New DataTable("ERROR")
                    End If
                Catch ex As Exception
                    ShowError("Error Downloading Data From Website", ex)
                    m_ViewFile = New DataTable("ERROR")
                End Try
                'LogUpdate(vbTab & vbTab & "...Finished Getting Data")
            Else
                If System.IO.File.Exists(m_filepath) Then
                    fullPath = m_filepath
                Else
                    ShowError("Invalid Filepath")
                    m_ViewFile = New DataTable("ERROR")
                End If
            End If

            Dim FileSize As New System.IO.FileInfo(fullPath)
            If (FileSize.Length > ((0.9 * My.Computer.Info.AvailablePhysicalMemory) + (0.9 * My.Computer.Info.AvailableVirtualMemory))) Then
                ShowError("File Size: " & FileSize.Length & " bytes" & vbCrLf & "Available System Memory: " & CInt((0.9 * My.Computer.Info.AvailablePhysicalMemory) + (0.9 * My.Computer.Info.AvailableVirtualMemory)) & " bytes ")
                m_ViewFile = New DataTable("ERROR")
            End If

            ' LogUpdate(vbTab & vbTab & "Opening " & fullPath & " ...")
            Dim count As Integer = 0
            Try
                If fullPath.EndsWith("xls") Or fullPath.EndsWith("xlsx") Or fullPath.EndsWith("xlsb") Then
                    m_ViewFile = LoadExcel(m_filepath)
                    Exit Try
                Else
                    reader = New System.IO.StreamReader(m_filepath)

                    Dim delimiter As String
                    Dim FileRow As String = reader.ReadLine
                    If ((ProcessLine(FileRow, vbTab).Length) > (ProcessLine(FileRow, ",").Length)) Then
                        delimiter = vbTab
                    Else
                        delimiter = ","
                    End If
                    Dim columns() As String = ProcessLine(FileRow, delimiter)
                    'Dim columns() As String = Split(FileRow, delimiter)
                    Dim column As String
                    table.BeginInit()
                    For Each column In columns
                        table.Columns.Add(column)
                    Next
                    table.EndInit()

                    table.BeginLoadData()
                    While (Not reader.EndOfStream)
                        FileRow = reader.ReadLine
                        Dim temprow() As String = ProcessLine(FileRow, delimiter)
                        'Dim tempRow() As String = StringSplit(delimiter, FileRow)
                        For x = 0 To (temprow.Length - 1)
                            If LCase(temprow(x)) = "null" Then
                                temprow(x) = ""
                            End If
                        Next
                        While (temprow.Length > table.Columns.Count)
                            table.Columns.Add()
                        End While
                        table.Rows.Add(temprow)
                        count += 1
                        temprow = Nothing
                        'TODO: REMOVE THIS?
                        If (count >= m_MaxRows) Then
                            m_ViewFile = table.Copy
                            FilePreview.ReportProgress(reader.BaseStream.Position / reader.BaseStream.Length)
                            count = 0
                        End If
                    End While
                    table.EndLoadData()
                    table.AcceptChanges()
                    reader.Close()
                    m_ViewFile = table
                    'LogUpdate(vbTab & vbTab & fullPath & " Opened.")
                End If
            Catch ex As Exception
                ShowError("Error Loading " & fullPath & " .", ex)
                m_ViewFile = New DataTable
            End Try

        Catch ex As System.IO.InvalidDataException
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            ShowError("Error Loading File: " & m_filepath & " .", ex)
            m_ViewFile = LoadExcel(m_filepath)
            Exit Try
        Catch ex As System.Net.WebException
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            ShowError("Unable to Connect to Web File: " & m_filepath & " .", ex)
        Catch ex As Exception
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            ShowError("Error Loading File: " & m_filepath & " .", ex)
            m_ViewFile = LoadExcel(m_filepath)
            Exit Try
        End Try

    End Sub

    Private Sub FilePreview_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles FilePreview.ProgressChanged
        Try
            If m_loadingLinks And (e.ProgressPercentage < 20) Then
                dgvLinkView.DataSource = m_ViewFile
            Else
                dgvFileView.DataSource = m_ViewFile
            End If

            Me.Refresh()
        Catch ex As Exception
            ShowError("Error showing file", ex)
        End Try
    End Sub

    Private Sub FilePreview_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles FilePreview.RunWorkerCompleted
        dgvLinkView.Enabled = True
        dgvFileView.Enabled = True
        If m_loadingLinks Then
            m_Type_Temp = GetTableType(m_ViewFile)
            dgvLinkView.DataSource = m_ViewFile
        Else
            m_Type_Main = GetTableType(m_ViewFile)
            dgvFileView.DataSource = m_ViewFile
        End If
        btnNext.Enabled = True
        btnBack.Enabled = True
    End Sub

    Private Function AllowNext() As Boolean
        Select Case m_Page_Current
            Case Page.FilePath
                Return (NextType(m_Type_Main) <> FileType.NONE)
            Case Page.LinkPath
                'MsgBox("Changing Current")
                Return ((txtLinkPath.Text <> "") AndAlso IO.File.Exists(txtLinkPath.Text) AndAlso ((m_Type_Current = m_Type_Temp) OrElse (m_Type_Current = CheckFileType()))) Or (rdoNoLoad.Checked)
        End Select
    End Function

    Private Sub btnLogBrowse_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogBrowse.Click
        'TODO: FINISH btnLogBrowse_Click
        If sfdSaveLog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtLogPath.Text = sfdSaveLog.FileName
        End If
    End Sub

    Private Function CheckFileType() As FileType
        'btnNext.Enabled = False
        Dim m_filepath As String
        'MsgBox(TypeName(m_Type_Current))
        If m_loadingLinks Then
            m_filepath = FilePath(m_Type_Current)
        Else
            m_filepath = txtFilePath.Text
        End If

        'Loads a fullPath into a datatable.  Can be comma or tab delimited. 
        Dim reader As System.IO.StreamReader = Nothing
        Dim fullPath As String = ""
        'Dim x As Integer
        Dim LastSlash As Integer
        Dim lastPeriod As Integer
        Dim shortName As String = "file"
        If m_filepath.Contains("\") Then
            If m_filepath.Contains(".") Then
                LastSlash = m_filepath.LastIndexOf("\") + 1
                lastPeriod = m_filepath.LastIndexOf(".")
                If (lastPeriod > LastSlash) Then
                    shortName = m_filepath.Substring(LastSlash, lastPeriod - LastSlash)
                End If
            Else
                LastSlash = m_filepath.LastIndexOf("\") + 1
                shortName = m_filepath.Substring(LastSlash)
            End If
        Else
            If m_filepath.Contains(".") Then
                lastPeriod = m_filepath.LastIndexOf(".")
                shortName = m_filepath.Substring(0, lastPeriod)
            Else
                shortName = m_filepath
            End If
        End If
        Dim table As New DataTable(shortName)
        'Dim table As New DataTable(m_FilePath.Substring((m_FilePath.LastIndexOf("\") + 1), m_FilePath.Length - (m_FilePath.LastIndexOf("\") + 1)))
        Try
            If (m_filepath.StartsWith("http:\\") Or m_filepath.StartsWith("ftp:\\")) Then
                Dim myWebClient As New Net.WebClient()
                Dim tempPath As String
                tempPath = System.IO.Path.GetTempPath & "ODMSDL"
                'LogUpdate(vbTab & vbTab & "Getting Data from Website..." & vbCrLf & "From: " & m_filepath & vbCrLf & "To: " & tempPath & "\DataImport.txt")
                Try
                    If Not (System.IO.Directory.Exists(tempPath)) Then
                        System.IO.Directory.CreateDirectory(tempPath)
                    End If
                    myWebClient.DownloadFile(m_filepath, tempPath & "\DataImport.txt")
                    If System.IO.File.Exists(tempPath & "\DataImport.txt") Then
                        fullPath = tempPath & "\DataImport.txt"
                    Else
                        ShowError("Error downloading Table." & vbCrLf & tempPath)
                        m_ViewFile = New DataTable("ERROR")
                    End If
                Catch ex As Exception
                    ShowError("Error Downloading Data From Website", ex)
                    m_ViewFile = New DataTable("ERROR")
                End Try
                'LogUpdate(vbTab & vbTab & "...Finished Getting Data")
            Else
                If System.IO.File.Exists(m_filepath) Then
                    fullPath = m_filepath
                Else
                    ShowError("Invalid Filepath")
                    m_ViewFile = New DataTable("ERROR")
                End If
            End If

            Dim FileSize As New System.IO.FileInfo(fullPath)
            If (FileSize.Length > ((0.9 * My.Computer.Info.AvailablePhysicalMemory) + (0.9 * My.Computer.Info.AvailableVirtualMemory))) Then
                ShowError("File Size: " & FileSize.Length & " bytes" & vbCrLf & "Available System Memory: " & CInt((0.9 * My.Computer.Info.AvailablePhysicalMemory) + (0.9 * My.Computer.Info.AvailableVirtualMemory)) & " bytes ")
                m_ViewFile = New DataTable("ERROR")
            End If

            ' LogUpdate(vbTab & vbTab & "Opening " & fullPath & " ...")
            Dim count As Integer = 0
            Try
                If fullPath.EndsWith("xls") Or fullPath.EndsWith("xlsx") Or fullPath.EndsWith("xlsb") Then
                    m_ViewFile = LoadExcel(m_filepath)
                    Exit Try
                Else
                    reader = New System.IO.StreamReader(m_filepath)

                    Dim delimiter As String
                    Dim FileRow As String = reader.ReadLine
                    If ((ProcessLine(FileRow, vbTab).Length) > (ProcessLine(FileRow, ",").Length)) Then
                        delimiter = vbTab
                    Else
                        delimiter = ","
                    End If
                    Dim columns() As String = ProcessLine(FileRow, delimiter)
                    'Dim columns() As String = Split(FileRow, delimiter)
                    Dim column As String
                    table.BeginInit()
                    For Each column In columns
                        table.Columns.Add(column)
                    Next
                    table.EndInit()

                    'table.BeginLoadData()
                    'While (Not reader.EndOfStream)
                    '    FileRow = reader.ReadLine
                    '    Dim temprow() As String = ProcessLine(FileRow, delimiter)
                    '    'Dim tempRow() As String = StringSplit(delimiter, FileRow)
                    '    For x = 0 To (temprow.Length - 1)
                    '        If LCase(temprow(x)) = "null" Then
                    '            temprow(x) = ""
                    '        End If
                    '    Next
                    '    While (temprow.Length > table.Columns.Count)
                    '        table.Columns.Add()
                    '    End While
                    '    table.Rows.Add(temprow)
                    '    count += 1
                    '    temprow = Nothing
                    '    'TODO: REMOVE THIS?
                    '    If (count >= m_MaxRows) Then
                    '        m_ViewFile = table.Copy
                    '        FilePreview.ReportProgress(reader.BaseStream.Position / reader.BaseStream.Length)
                    '        count = 0
                    '    End If
                    'End While
                    'table.EndLoadData()
                    table.AcceptChanges()
                    reader.Close()
                    m_ViewFile = table
                    'LogUpdate(vbTab & vbTab & fullPath & " Opened.")
                End If
            Catch ex As Exception
                ShowError("Error Loading " & fullPath & " .", ex)
                m_ViewFile = New DataTable
            End Try

        Catch ex As System.IO.InvalidDataException
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            ShowError("Error Loading File: " & m_filepath & " .", ex)
            m_ViewFile = LoadExcel(m_filepath)
            Exit Try
        Catch ex As System.Net.WebException
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            ShowError("Unable to Connect to Web File: " & m_filepath & " .", ex)
        Catch ex As Exception
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            ShowError("Error Loading File: " & m_filepath & " .", ex)
            m_ViewFile = LoadExcel(m_filepath)
            Exit Try
        End Try


        Return GetTableType(m_ViewFile)
    End Function

End Class
