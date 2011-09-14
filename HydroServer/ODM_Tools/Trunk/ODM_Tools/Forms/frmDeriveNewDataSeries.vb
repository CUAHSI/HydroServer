'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Imports System.Linq
Imports VBEnumerator
Imports System.Collections
Imports System.Collections.Generic

Public Class frmDeriveNewDataSeries

#Region " Member Variables "
    'Dim m_CanUseAggregateMethod As Boolean = True 'Tracks if the Aggregate Method can be used 'NOTE: No longer using this variable -> always allowing this functionality
    Dim m_CanUseSmoothing As Boolean = True 'Tracks if the Smoothing Method can be used
    'Dim m_CreateNewQCLevel1 As Boolean = False 'Tracks if a QC Level1 series can be created
    Dim m_MethodDesc_Created As String 'Holds the Method Description for the Data Series creating
    Dim m_Site As String 'Holds the Site Code - Name (NOTE: this value is the same for the new Data Series as it is for the Data Series deriving from)
    Dim m_Variable As String 'Holds the Variable Code - Name -> this value is used to initialize the form.  For most data series, it will stay the same as the Data Series deriving from
    Dim m_SampleMed As String 'Holds the Sample Medium (NOTE: this value is the same for the new Data Series as it is for the Data Series deriving from)
    Dim m_GenCategory As String 'Holds the General Category (NOTE: this value is the same for the new Data Series as it is for the Data Series deriving from)
    Dim m_VarUnits As String 'Holds the Units for the Variable -> this value is used to initialize the form.  For most data series, it will stay the same as the Data Series deriving from
    Dim m_TimeSupport As Double 'Holds the Time Support -> this value is used to initialize the form.  For most data series, it will stay the same as the Data Series deriving from
    Dim m_TSUnits As String 'Holds the Time Support Units -> this value is used to initialize the form.  For most data series, it will stay the same as the Data Series deriving from
    Dim m_ValueType As String 'Holds the Value Type -> this value is used to initialize the form.  For most data series, it will stay the same as the Data Series deriving from
    Dim m_DataType As String 'Holds the Data Type -> this value is used to initialize the form.  For most data series, it will stay the same as the Data Series deriving from
    Dim m_Organization As String 'Holds the Source Organization (NOTE: this value is the same for the new Data Series as it is for the Data Series deriving from)
    Dim m_SourceDesc As String 'Holds the Source Description (NOTE: this value is the same for the new Data Series as it is for the Data Series deriving from)
    Dim m_Speciation As String 'Holds the Speciation (-> this is used to initialize the form.  For most data series, it will stay the same as the Data Series deriving from
    Dim m_Citation As String 'Holds the source Citation info (NOTE: this value is the same for the new Data Series as it is for the Data Series deriving from)
    Dim m_DSFromIDs As clsDataSeriesIDs 'Holds the Data Series IDs for the Data Series deriving from
    Dim m_DSFromValues As Data.DataTable 'Holds the Data Value for the Data Series deriving from -> used to copy or calculate new values
    Dim m_Loading As Boolean = True 'Tracks if loading the form or not
    'Dim m_isDSQCLevelLoaded As Boolean = False 'Tracks if the available QC Levels have been loaded or not
    Dim m_isDSReadOnlyLoaded As Boolean = False 'Tracks if the info in the Data Series (Variable, Variable Units, Time Support) are Read Only or user selectable
    Dim m_isDSValueTypeLoaded As Boolean = False 'Tracks if the Value Type has been loaded or not
    Dim m_isDSDataTypeLoaded As Boolean = False 'Tracks if the Data Type has been loaded or not
    Dim m_isDSVarLoaded As Boolean = False 'Tracks if the Variable(s) have been loaded or not
    Dim m_isDSVarSelectable As Boolean = False 'Tracks if the Variable is selectable or not
    Dim m_isDSTSLoaded As Boolean = False 'Tracks if the Time Support Info has been loaded or not
    Dim m_ExistingMethodDescIDs() As Integer 'Holds the MethodIDs for the loaded existing Method Descriptions -> for easier access if the user selects from an existing one
    Public m_NewSeriesID As Integer = -1 'Holds the Data Series ID for the new created Data Series -> so the Edit Tab can know which Data Series to select when finished
    Dim m_createNewVar As String = "<Create New>"
#End Region

#Region " Form Control Functions "

    Public Sub New(ByVal dataSeriesIDs As clsDataSeriesIDs, ByVal siteName As String, ByVal variableName As String, ByVal speciation As String, ByVal variableUnits As String, ByVal sampleMedium As String, ByVal generalCategory As String, ByVal timeSupportValue As Double, ByVal timeSupportUnits As String, ByVal valueType As String, ByVal dataType As String, ByVal organization As String, ByVal sourceDesc As String, ByVal citation As String)
        'This function creates a new instance of the frmDeriveNewDataSeries form
        'Inputs:  dataSeriesIDs -> the Data Series IDs for the Data Series deriving from
        '         siteName -> the site for the Data Series deriving from
        '         variableName -> the variable for the Data Series deriving from
        '		  speciation -> the speciation of the Variable for the Data Series deriving from
        '         variableUnits -> the Units of the Variable for the Data Series deriving from
        '         sampleMedium -> the Sample Medium for the Data Series deriving from
        '         generalCategory -> the General Category for the Data Series deriving from
        '         timeSupportValue -> the Time Support Value for the Data Series deriving from
        '         timeSupportUnits -> the Time Support Units for the Data Series deriving from
        '         valueType -> the Value Type for the Data Series deriving from
        '         dataType -> the Data Type for the Data Series deriving from
        '         organization -> the Source Organization for the Data Series deriving from
        '         sourceDesc -> the Source Description for the Data Series deriving from
        '		  citation -> the Citation for the source for the Data Series deriving from
        'Outputs: None
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'Derive Method Variables
        'm_CanUseAggregateMethod = CanUseAggregateMethodToDerive(timeSupportValue, timeSupportUnits) 'NOTE: No longer using this variable -> always allowing this functionality
        m_CanUseSmoothing = CanUseSmoothingAlgorithmToDerive(dataSeriesIDs.VariableID)
        'm_CreateNewQCLevel1 = CanUseCreateQCLevel1ToDerive(dataSeriesIDs)
        'Derive Method Info
        m_MethodDesc_Created = ""
        'Data Series Attributes
        m_DSFromIDs = dataSeriesIDs
        m_Site = siteName
        m_Variable = variableName
        m_VarUnits = variableUnits
        m_SampleMed = sampleMedium
        m_Speciation = speciation
        m_GenCategory = generalCategory
        m_TimeSupport = timeSupportValue
        m_TSUnits = timeSupportUnits
        m_ValueType = valueType
        m_DataType = dataType
        m_Organization = organization
        m_SourceDesc = sourceDesc
        m_Citation = citation
        'set that loading the form
        m_Loading = True
    End Sub

    Private Sub frmDeriveNewDataSeries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Loads and Initializes the frmDeriveNewDataSeries form when it is shown
        'the inputs/outputs are standard for form events
        Try
            '1. Enable/Disable Derive methods
            'NOTE: to allow for new user defined QC Levels in new ODM1.1, now this can be selected anytime
            'CreateQCLevel1
            'If m_CanUseCreateQCLevel1 Then
            '	'enable CreateQCLevel1,Algebraic
            '	rbtnCreateDS_QCLevel1.Enabled = True
            'Else
            '	'disable CreateQCLevel1
            '	rbtnCreateDS_QCLevel1.Enabled = False
            'End If

            'Smoothing
            If m_CanUseSmoothing Then
                rbtnCreateDS_Smoothed.Enabled = True
                gboxSmooth.Enabled = True
            Else
                rbtnCreateDS_Smoothed.Enabled = False
                gboxSmooth.Enabled = False
            End If
            'Aggregate
            'NOTE: No longer using this -> functionality is always enabled!!
            '***************************************************************
            'If m_CanUseAggregateMethod Then
            rbtnAggregate.Enabled = True
            gboxAggregate.Enabled = True
            'Else
            'rbtnAggregate.Enabled = False
            'gboxAggregate.Enabled = False
            'End If
            '***************************************************************
            'Algebraic
            'NOTE: Algebraic is ALWAYS enabled

            'disable types in methods
            'smoothing
            tboxSmooth_WindowVal.Enabled = False
            'aggregate
            rbtnAgg_Max.Enabled = False
            rbtnAgg_Min.Enabled = False
            rbtnAgg_Avg.Enabled = False
            'algebraic
            tboxAlg_A.Enabled = False
            tboxAlg_B.Enabled = False
            tboxAlg_C.Enabled = False
            tboxAlg_D.Enabled = False
            tboxAlg_E.Enabled = False
            tboxAlg_F.Enabled = False

            'disable Method Desc values
            cboxSelectExistingMethodDesc.Enabled = False
            tboxNewMethodDesc.Enabled = False

            '2.Load Existing Method Descriptions from DB
            If LoadExistingMethodDescriptions() = True Then
                rbtnSelectExistingMethodDesc.Enabled = True
                gboxSelectExistingMethodDesc.Enabled = True
            Else
                rbtnSelectExistingMethodDesc.Enabled = False
                gboxSelectExistingMethodDesc.Enabled = False
            End If

            '3. unselect all Derive info
            'derive Type
            rbtnCreateDS_QCLevel1.Checked = False
            rbtnCreateDS_Smoothed.Checked = False
            rbtnAggregate.Checked = False
            rbtnAlgebraic.Checked = False
            'Method
            InitializeMethodDesc()

            '4. Load the QC Levels
            LoadQCLevels()

            '4. Disable Method Desc,Data Series info
            gboxMethodInfo.Enabled = False
            gboxDSAttributes.Enabled = False

            '5. Disable DeriveNewDataSeries button
            btnDeriveNewDS.Enabled = False

            '6. Set that done loading the form
            m_Loading = False
        Catch ex As Exception
            ShowError("An Error occurred while loading the form to Derive a Data Series." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Handles the Cancel Button click, closes the form
        'the inputs/outputs are standard for form events

        'set that clicked cancel
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        'close the form
        Me.Close()
    End Sub

    Private Sub btnDeriveNewDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeriveNewDS.Click
        'Handles the "Derive New Data Series" button click
        'Gets the info to derive the new data series, calls the appropriate function
        'if everything worked then closes the form, else allows to stay open for user to try again or change something or hit cancel
        'the inputs/outputs are standard for form events

        Dim variable As String 'the Variable (Code - Name) for the new Data Series
        'Dim varCode As String 'the Variable Code portion of the variable for the new Data Series
        'Dim varName As String 'the Variable Name portion of the variable for the new Data Series
        'Dim varUnits As String 'The Variable Units for the new Data Series
        'Dim speciation As String 'The Speciation for the new Data Series
        Dim valueType As String 'The Value Type for the new Data Series
        '      Dim site As String 'the Site (Code - Name) for the new Data Series
        '      Dim siteCode As String 'the Site Code portion of the site for the new Data Series
        'Dim siteName As String 'the Site Name portion of the site for the new Data Series
        Dim qcLevelID As Integer 'the QCLevelID of the QC Level for the new Data Series
        Dim qcLevel As String 'the QCLevel (Code - Definition)for the new Data Series
        Dim qcLevel_code As String 'the Code of the QC Level for the new Data Series
        Dim qcLevel_Def As String 'the Definition of the QC Level for the new Data Series
        Try
            'disable the buttons on the form
            btnDeriveNewDS.Enabled = False
            btnCancel.Enabled = False

            '1. Get the Variable, Site, QCLevel Info
            'variable
            variable = cboxVariable.Text

            '         varCode = Split(variable, " - ")(0)
            '         varName = Split(variable, " - ")(1)
            '         'site
            '         site = tboxDSSite.Text
            '         siteCode = Split(site, " - ")(0)
            '		  siteName = Split(site, " - ")(1)

            'QClevel
            qcLevel = cboxVarQCLevel.Text
            qcLevel_code = Split(qcLevel, " - ")(0)
            qcLevel_Def = Split(qcLevel, " - ")(1)

            '2. Check Specified values (Variable/Units, algebraic equation, etc) if needed
            'NOTE: if derive type = Algebraic and DS variable = sel Variable, verify that user wants same variable
            Select Case True
                Case rbtnCreateDS_QCLevel1.Checked, rbtnCreateDS_Smoothed.Checked, rbtnAggregate.Checked
                    'For now do nothing, allow to move through 
                    'NOTE: QCLevel Check happens in DeriveNewDS function
                Case rbtnAlgebraic.Checked
                    '1.  check if variable = same, units = same, speciation = same, qcLevelID = same, AND valueType = same 
                    'varUnits = cboxVarUnits.Text
                    'speciation = tboxVarSpeciation.Text
                    valueType = tboxVarValueType.Text 'NOTE: must check this -> when doing a controlled DS for editing, this value will be the same
                    qcLevelID = GetQCLevelIDFromDB(qcLevel_code, qcLevel_Def)
                    'If variable = m_Variable AndAlso varUnits = m_VarUnits AndAlso speciation = m_Speciation AndAlso qcLevelID = m_DSFromIDs.QCLevelID AndAlso valueType = m_ValueType Then
                    'If variable = m_Variable AndAlso speciation = m_Speciation AndAlso varUnits = m_VarUnits AndAlso qcLevelID = m_DSFromIDs.QCLevelID AndAlso valueType = m_ValueType Then
                    'NOTE: Speciation and Variable Units are associated with a unique variable
                    If variable = m_Variable AndAlso qcLevelID = m_DSFromIDs.QCLevelID AndAlso valueType = m_ValueType Then
                        'pop up message to make sure user knows what doing
                        If MsgBox("The selected Variable Information is EXACTLY the same as the Data Series you are deriving from." & vbCrLf & "Are you sure that you want to derive the new Data Series using these values?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                            'exit -> allow user to select new variable info
                            Exit Sub
                        End If
                    End If
                    '2. check if Algebraic equation is set to create constant value
                    If CDbl(tboxAlg_B.Text) = 0 AndAlso CDbl(tboxAlg_C.Text) = 0 AndAlso CDbl(tboxAlg_D.Text) = 0 AndAlso CDbl(tboxAlg_E.Text) = 0 AndAlso CDbl(tboxAlg_F.Text) = 0 Then
                        'equation is set to create constant values
                        If MsgBox("The specified Algebraic Equation will produce a set of Constant Data Values = " & tboxAlg_A.Text & vbCrLf & "Are you sure that you want to derive the new Data Series using this constant value?" & vbCrLf & vbCrLf & "(NOTE: If you wish to do a simple offset by adding a constant to the value," & vbCrLf & "the equation should look like this:  " & tboxAlg_A.Text & " + 1x + 0x^2 + 0x^3 + 0x^4 + 0x^5", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                            'exit -> allow user the specify new equation
                            Exit Sub
                        End If
                    End If
                Case Else
                    'exit
                    Exit Sub
            End Select

            '3. Derive the New Data series
            'change cursor to hour glass
            Me.Cursor = Cursors.WaitCursor

            g_FProgress = New frmProgress
            g_FProgress.Text = "Creating the Data Series ..."
            g_FProgress.TopLevel = True
            Me.AddOwnedForm(g_FProgress)
            g_FProgress.Show()
            g_FProgress.BringToFront()
            g_FProgress.Refresh()

            If (DeriveNewDataSeries()) Then
                'set Dialog Result = OK, close form
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                'disable DeriveNewDS button -> until fix errors/duplication
                btnDeriveNewDS.Enabled = False
            End If

            'close the progress bar
            g_FProgress.Close()
            'remove owned form
            Me.RemoveOwnedForm(g_FProgress)
            'release resources
            If Not (g_FProgress Is Nothing) Then
                g_FProgress.Dispose()
                g_FProgress = Nothing
            End If
            'NOTE: don't close the form if it doesn't work, allow the user to try again or hit cancel
        Catch ex As Exception
            ShowError("An Error occurred when the user clicked the 'Derive New Data Series' button." & vbCrLf & "Message = " & ex.Message, ex)
            'NOTE: don't close the form, allow the user to try again or hit cancel
            'disable DeriveNewDS button -> until fix errors
            btnDeriveNewDS.Enabled = False
        End Try
        If Not IsNothing(g_FProgress) Then
            'close the progress bar
            g_FProgress.Close()
            'remove owned form
            Me.RemoveOwnedForm(g_FProgress)
            'release resources
            If Not (g_FProgress Is Nothing) Then
                g_FProgress.Dispose()
                g_FProgress = Nothing
            End If
        End If
        Me.Cursor = Cursors.Default
        'enable the buttons on the form
        btnCancel.Enabled = True
    End Sub

#Region " Derive Type Functionality "

    Private Sub rbtnCreateDS_QCLevel1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCreateDS_QCLevel1.CheckedChanged
        'Handles the Create QC Level 1 Data series radio button checked changed
        'if the button = checked, then loads necessary info, creates a Method Description, disables Method Description area
        'Else, reset that ValueType, QC Level are not loaded, so they will be loaded correctly for the next type selected
        'the inputs/outputs are standard for form events
        If Not (m_Loading) Then
            'NOTE: m_isDSValueTypeLoaded only changes in this function -> only different if this value is selected
            'NOTE: m_isDSQCLevelLoaded only changed in this function -> only different if this value is selected
            If rbtnCreateDS_QCLevel1.Checked Then
                '1. set that the Variable info <> Selectable
                If m_isDSVarSelectable = True Then '
                    'set m_IsDSVarSelectable = False, set that variable <> Loaded
                    m_isDSVarSelectable = False
                    m_isDSVarLoaded = False
                End If

                'NOTE: Per changes for ODM1.1, now allow selection of correct QC Level
                ''2. set that QCLevel <> Loaded -> force it to load = 1 only
                'm_isDSQCLevelLoaded = False

                '3. set that valueType <> Loaded -> force it to load from current Data Series
                m_isDSValueTypeLoaded = False
                'NOTE: m_isDSDataTypeLoaded will only be changed in the rbtnAggregate_CheckedChanged() function
                'NOTE: m_isDSTSLoaded will only be changed in the rbtnAggregate_CheckedChanged() function

                '4. Load the form with current Data Series Info (NOTE: this function only loads changed data)
                LoadDataSeriesAttributes()

                '5. Set the Method Description in Data Series Area
                'm_MethodDesc_Created = AutoGenerateMethodDesc()
                'tboxVarMethod.Text = m_MethodDesc_Created

                '6. enable/disable Method,Data Series Info
                SetMethodDescEnabled()
            Else
                '1. set that the valueType <> Loaded -> force it to change to "Derived Value"
                m_isDSValueTypeLoaded = False
                'NOTE: Per changes for ODM1.1, now allow selection of correct QC Level
                ''2. set that the QCLevel <> Loaded -> force it to load = 0 only
                'm_isDSQCLevelLoaded = False
            End If
        End If
    End Sub

#Region " Smoothing Functions "

    Private Sub rbtnCreateDS_Smoothed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCreateDS_Smoothed.CheckedChanged
        'Handles the Create A Smoothed Data series radio button checked changed
        'If Checked, then Loads Data Series Attributes, enable Method Description specification
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If rbtnCreateDS_Smoothed.Checked Then
                    '1. set that the Variable info <> Selectable
                    If m_isDSVarSelectable = True Then '
                        'set m_IsDSVarSelectable = False, set that variable <> Loaded
                        m_isDSVarSelectable = False
                        m_isDSVarLoaded = False
                    End If

                    'NOTE: m_isDSQCLevelLoaded will only be changed in the rbtnCreateDS_QCLevel1_CheckedChanged() function
                    'NOTE: m_isDSValueTypeLoaded will only be changed in the rbtnCreateDS_QCLevel1_CheckedChanged() function
                    'NOTE: m_isDSDataTypeLoaded will only be changed in the rbtnAggregate_CheckedChanged() function
                    'NOTE: m_isDSTSLoaded will only be changed in the rbtnAggregate_CheckedChanged() function

                    '2. enable Smoothing Window functionality
                    tboxSmooth_WindowVal.Enabled = True

                    '3. Load the form with current Data Series Info (NOTE: this function only loads changed data)
                    LoadDataSeriesAttributes()

                    '4. set the method
                    m_MethodDesc_Created = ""
                    If Not (rbtnAutoGenMethodDesc.Checked) Then
                        'reset method desc selection
                        InitializeMethodDesc()
                    End If
                    'enable/disable Method,Data Series Info
                    SetMethodDescEnabled()
                    'NOTE: tboxVarMethod should be set in above function
                Else
                    'disable Smoothing Window functionality
                    tboxSmooth_WindowVal.Enabled = False
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the 'Derive using a Smoothing Algorithm' button was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxSmooth_WindowVal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxSmooth_WindowVal.KeyPress
        'Handles the Smoothing Window Value key Press
        'If Enter/Return/etc is pressed, validate Value
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxSmooth_WindowVal_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxSmooth_WindowVal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxSmooth_WindowVal.Validating
        'Handles the Smoothing Window Value Validation
        'Checks to see if value is numeric, if so -> enables Method Descriptions
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If tboxSmooth_WindowVal.Text <> "" Then
                    If Not (IsNumeric(tboxSmooth_WindowVal.Text)) Then
                        MsgBox("Invalid value for the Smoothing Window Value:  Value must be numeric.")
                        e.Cancel = True
                    Else
                        'Reset m_MethodDesc_Created, clear out Method Desc Selection
                        m_MethodDesc_Created = ""
                        If Not (rbtnAutoGenMethodDesc.Checked) Then
                            'reset method desc selection
                            InitializeMethodDesc()
                        End If
                        'enable/disable Method,Data Series Info
                        SetMethodDescEnabled()
                        'NOTE: tboxVarMethod should be set in above function
                    End If
                Else
                    MsgBox("Invalid Smoothing Window Value:  Value cannot be blank.")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the Smoothing Window Value." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Daily Aggregate Functionality "

    Private Sub rbtnAggregate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAggregate.CheckedChanged
        'Handles the Derive using an Aggregate Function radio button checked changed
        'If Checked, sets that Variable is not selectable, enables Aggregate types, Loads Data Series Attributes, enables Method Description specification
        'Else disables Aggregate types, resets Data Type, Time Support so that they will be loaded correctly for the new Derive Type
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                'NOTE: m_isDSDataTypeLoaded only changes in this function -> only different if this value is selected
                'NOTE: m_isDSTSLoaded only changes in this function -> only different if this value is selected
                If rbtnAggregate.Checked Then
                    '1. set that the Variable info <> Selectable
                    If m_isDSVarSelectable = True Then '
                        'set m_IsDSVarSelectable = False, set that variable <> Loaded
                        m_isDSVarSelectable = False
                        m_isDSVarLoaded = False
                    End If

                    'NOTE: m_isDSQCLevelLoaded will only be changed in the rbtnCreateDS_QCLevel1_CheckedChanged() function
                    'NOTE: m_isDSValueTypeLoaded will only be changed in the rbtnCreateDS_QCLevel1_CheckedChanged() function

                    '2. set that Data Type <> Loaded -> force it to change to selected type -> (avg, min, max)
                    m_isDSDataTypeLoaded = False

                    '3. set that Time Support <> Loaded -> force it to change = 1 day
                    m_isDSTSLoaded = False

                    '4. enable Max,Min,Avg methods
                    rbtnAgg_Max.Enabled = True
                    rbtnAgg_Min.Enabled = True
                    rbtnAgg_Avg.Enabled = True

                    '5. Load the form with current Data Series Info (NOTE: this function only loads changed data)
                    m_isDSDataTypeLoaded = False
                    m_isDSVarLoaded = False
                    LoadDataSeriesAttributes()

                    '6. set the method
                    If Not (rbtnAgg_Max.Checked) And Not (rbtnAgg_Min.Checked) And Not (rbtnAgg_Avg.Checked) Then
                        'set Average as default
                        rbtnAgg_Avg.Checked = True 'NOTE: this will reset method desc selection
                    Else
                        m_MethodDesc_Created = ""
                        If Not (rbtnAutoGenMethodDesc.Checked) Then
                            'reset method desc selection
                            InitializeMethodDesc()
                        End If

                        'enable/disable Method,Data Series Info
                        SetMethodDescEnabled()
                        'NOTE: tboxVarMethod should be set in above function
                    End If
                Else
                    '1. disable Max,Min,Avg methods
                    rbtnAgg_Max.Enabled = False
                    rbtnAgg_Min.Enabled = False
                    rbtnAgg_Avg.Enabled = False
                    '2. set that Data Type <> Loaded -> force it to change to current Data Series value
                    m_isDSDataTypeLoaded = False
                    '3. set that Time Support <> Loaded -> force it to change to current Data Series value
                    m_isDSTSLoaded = False
                    '4. set that Variable <> Loaded
                    m_isDSVarLoaded = False
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the 'Derive Using a Daily Aggregate Function' button was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub rbtnAgg_Max_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAgg_Max.CheckedChanged
        'Handles the Max Aggregate Method radio button checked changed
        'If Checked, resets method description, changes DataType = Maximum
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If rbtnAgg_Max.Checked Then
                    '1. Reset m_MethodDesc_Created, clear out Method Desc Selection
                    m_MethodDesc_Created = ""
                    If Not (rbtnAutoGenMethodDesc.Checked) Then
                        'reset method desc selection
                        InitializeMethodDesc()
                    End If

                    ''change Data Type = maximum
                    'tboxVarDataType.Text = db_val_DTCVTerm_Maximum
                    'm_isDSDataTypeLoaded = True

                    '5. Load the form with current Data Series Info (NOTE: this function only loads changed data)
                    m_isDSDataTypeLoaded = False
                    m_isDSVarLoaded = False
                    LoadDataSeriesAttributes()

                    'enable/disable Method,Data Series Info
                    SetMethodDescEnabled()
                    'NOTE: tboxVarMethod should be set in above function
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the Maximum Daily Aggregate Function was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub rbtnAgg_Min_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAgg_Min.CheckedChanged
        'Handles the Min Aggregate Method radio button checked changed
        'If Checked, resets method description, changes DataType = Minimum
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If rbtnAgg_Min.Checked Then
                    '1. Reset m_MethodDesc_Created, clear out Method Desc Selection
                    m_MethodDesc_Created = ""
                    If Not (rbtnAutoGenMethodDesc.Checked) Then
                        'reset method desc selection
                        InitializeMethodDesc()
                    End If

                    ''change Data Type = Minimum
                    'tboxVarDataType.Text = db_val_DTCVTerm_Minimum
                    'm_isDSDataTypeLoaded = True

                    '5. Load the form with current Data Series Info (NOTE: this function only loads changed data)
                    m_isDSDataTypeLoaded = False
                    m_isDSVarLoaded = False
                    LoadDataSeriesAttributes()

                    'enable/disable Method,Data Series Info
                    SetMethodDescEnabled()
                    'NOTE: tboxVarMethod should be set in above function
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the Minimum Daily Aggregate Function was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub rbtnAgg_Avg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAgg_Avg.CheckedChanged
        'Handles the Avg Aggregate Method radio button checked changed
        'If Checked, resets method description, changes DataType = Average
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If rbtnAgg_Avg.Checked Then
                    '1. Reset m_MethodDesc_Created, clear out Method Desc Selection
                    m_MethodDesc_Created = ""
                    If Not (rbtnAutoGenMethodDesc.Checked) Then
                        'reset method desc selection
                        InitializeMethodDesc()
                    End If

                    ''change Data Type = Average
                    'tboxVarDataType.Text = db_val_DTCVTerm_Average
                    'm_isDSDataTypeLoaded = True

                    '5. Load the form with current Data Series Info (NOTE: this function only loads changed data)
                    m_isDSDataTypeLoaded = False
                    m_isDSVarLoaded = False
                    LoadDataSeriesAttributes()

                    'enable/disable Method,Data Series Info
                    SetMethodDescEnabled()
                    'NOTE: tboxVarMethod should be set in above function
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the Average Daily Aggregate Function was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Algebraic Functionality "

    Private Sub rbtnAlgebraic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAlgebraic.CheckedChanged
        'Handles the Derive using an Algebraic Equation radio button checked changed
        'If Checked, sets that Variable is selectable, enables Polynomial values, Loads Data Series Attributes, enables Method Description specification
        'Else disables Polynomial values
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If rbtnAlgebraic.Checked Then
                    '1. set that the Variable info = Selectable
                    If m_isDSVarSelectable = False Then '
                        'set m_IsDSVarSelectable = True, set that variable <> Loaded
                        m_isDSVarSelectable = True
                        m_isDSVarLoaded = False
                    End If

                    'NOTE: m_isDSQCLevelLoaded will only be changed in the rbtnCreateDS_QCLevel1_CheckedChanged() function
                    'NOTE: m_isDSValueTypeLoaded will only be changed in the rbtnCreateDS_QCLevel1_CheckedChanged() function
                    'NOTE: m_isDSDataTypeLoaded will only be changed in the rbtnAggregate_CheckedChanged() function
                    'NOTE: m_isDSTSLoaded will only be changed in the rbtnAggregate_CheckedChanged() function

                    '2. enable text boxes
                    tboxAlg_A.Enabled = True
                    tboxAlg_B.Enabled = True
                    tboxAlg_C.Enabled = True
                    tboxAlg_D.Enabled = True
                    tboxAlg_E.Enabled = True
                    tboxAlg_F.Enabled = True
                    'set values = 0 for default
                    If tboxAlg_A.Text = "" Then
                        tboxAlg_A.Text = 0
                    End If
                    If tboxAlg_B.Text = "" Then
                        tboxAlg_B.Text = 0
                    End If
                    If tboxAlg_C.Text = "" Then
                        tboxAlg_C.Text = 0
                    End If
                    If tboxAlg_D.Text = "" Then
                        tboxAlg_D.Text = 0
                    End If
                    If tboxAlg_E.Text = "" Then
                        tboxAlg_E.Text = 0
                    End If
                    If tboxAlg_F.Text = "" Then
                        tboxAlg_F.Text = 0
                    End If

                    '3. Load the form with current Data Series Info (NOTE: this function only loads changed data)
                    LoadDataSeriesAttributes()

                    '4. set method
                    m_MethodDesc_Created = ""
                    If Not (rbtnAutoGenMethodDesc.Checked) Then
                        'reset method desc selection
                        InitializeMethodDesc()
                    End If
                    'enable/disable Method desc,Data Series Info
                    SetMethodDescEnabled()
                    'NOTE: tboxVarMethod should be set in above function
                Else
                    'disable A,B,C,D,E,F
                    tboxAlg_A.Enabled = False
                    tboxAlg_B.Enabled = False
                    tboxAlg_C.Enabled = False
                    tboxAlg_D.Enabled = False
                    tboxAlg_E.Enabled = False
                    tboxAlg_F.Enabled = False
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the 'Derive Using a Daily Aggregate Function' button was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxAlg_A_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxAlg_A.KeyPress
        'Handles the A Value of the Algebraic Equation key Press
        'If Enter/Return/etc is pressed, validate Value
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxAlg_A_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxAlg_A_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxAlg_A.Validating
        'Handles the A Value of the Algebraic Equation Validation
        'Checks to see if value is numeric, if so -> enables Method Descriptions
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If tboxAlg_A.Text <> "" Then
                    If Not (IsNumeric(tboxAlg_A.Text)) Then
                        MsgBox("Invalid A value for the Algebraic Equation:  Value must be numeric.")
                        e.Cancel = True
                    Else
                        'Reset m_MethodDesc_Created, clear out Method Desc Selection
                        m_MethodDesc_Created = ""
                        If Not (rbtnAutoGenMethodDesc.Checked) Then
                            'reset method desc selection
                            InitializeMethodDesc()
                        End If
                        'enable/disable Method,Data Series Info
                        SetMethodDescEnabled()
                        'NOTE: tboxVarMethod should be set in above function
                    End If
                Else
                    MsgBox("Invalid A value for the Algebraic Equation:  Value cannot be blank, it must be numeric." & vbCrLf & "NOTE: if you do not wish to use this value, then enter a 0.")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the A value for the Algebraic Equation." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxAlg_B_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxAlg_B.KeyPress
        'Handles the B Value of the Algebraic Equation key Press
        'If Enter/Return/etc is pressed, validate Value
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxAlg_B_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxAlg_B_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxAlg_B.Validating
        'Handles the B Value of the Algebraic Equation Validation
        'Checks to see if value is numeric, if so -> enables Method Descriptions
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If tboxAlg_B.Text <> "" Then
                    If Not (IsNumeric(tboxAlg_B.Text)) Then
                        MsgBox("Invalid B value for the Algebraic Equation:  Value must be numeric.")
                        e.Cancel = True
                    Else
                        'Reset m_MethodDesc_Created, clear out Method Desc Selection
                        m_MethodDesc_Created = ""
                        If Not (rbtnAutoGenMethodDesc.Checked) Then
                            'reset method desc selection
                            InitializeMethodDesc()
                        End If
                        'enable/disable Method,Data Series Info
                        SetMethodDescEnabled()
                        'NOTE: tboxVarMethod should be set in above function
                    End If
                Else
                    MsgBox("Invalid B value for the Algebraic Equation:  Value cannot be blank, it must be numeric." & vbCrLf & "NOTE: if you do not wish to use this value, then enter a 0.")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the B value for the Algebraic Equation." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxAlg_C_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxAlg_C.KeyPress
        'Handles the C Value of the Algebraic Equation key Press
        'If Enter/Return/etc is pressed, validate Value
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxAlg_C_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxAlg_C_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxAlg_C.Validating
        'Handles the C Value of the Algebraic Equation Validation
        'Checks to see if value is numeric, if so -> enables Method Descriptions
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If tboxAlg_C.Text <> "" Then
                    If Not (IsNumeric(tboxAlg_C.Text)) Then
                        MsgBox("Invalid C value for the Algebraic Equation:  Value must be numeric.")
                        e.Cancel = True
                    Else
                        'Reset m_MethodDesc_Created, clear out Method Desc Selection
                        m_MethodDesc_Created = ""
                        If Not (rbtnAutoGenMethodDesc.Checked) Then
                            'reset method desc selection
                            InitializeMethodDesc()
                        End If
                        'enable/disable Method,Data Series Info
                        SetMethodDescEnabled()
                        'NOTE: tboxVarMethod should be set in above function
                    End If
                Else
                    MsgBox("Invalid C value for the Algebraic Equation:  Value cannot be blank, it must be numeric." & vbCrLf & "NOTE: if you do not wish to use this value, then enter a 0.")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the C value for the Algebraic Equation." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxAlg_D_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxAlg_D.KeyPress
        'Handles the D Value of the Algebraic Equation key Press
        'If Enter/Return/etc is pressed, validate Value
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxAlg_D_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxAlg_D_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxAlg_D.Validating
        'Handles the D Value of the Algebraic Equation Validation
        'Checks to see if value is numeric, if so -> enables Method Descriptions
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If tboxAlg_D.Text <> "" Then
                    If Not (IsNumeric(tboxAlg_D.Text)) Then
                        MsgBox("Invalid D value for the Algebraic Equation:  Value must be numeric.")
                        e.Cancel = True
                    Else
                        'Reset m_MethodDesc_Created, clear out Method Desc Selection
                        m_MethodDesc_Created = ""
                        If Not (rbtnAutoGenMethodDesc.Checked) Then
                            'reset method desc selection
                            InitializeMethodDesc()
                        End If
                        'enable/disable Method,Data Series Info
                        SetMethodDescEnabled()
                        'NOTE: tboxVarMethod should be set in above function
                    End If
                Else
                    MsgBox("Invalid D value for the Algebraic Equation:  Value cannot be blank, it must be numeric." & vbCrLf & "NOTE: if you do not wish to use this value, then enter a 0.")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the D value for the Algebraic Equation." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxAlg_E_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxAlg_E.KeyPress
        'Handles the E Value of the Algebraic Equation key Press
        'If Enter/Return/etc is pressed, validate Value
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxAlg_E_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxAlg_E_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxAlg_E.Validating
        'Handles the E Value of the Algebraic Equation Validation
        'Checks to see if value is numeric, if so -> enables Method Descriptions
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If tboxAlg_E.Text <> "" Then
                    If Not (IsNumeric(tboxAlg_E.Text)) Then
                        MsgBox("Invalid E value for the Algebraic Equation:  Value must be numeric.")
                        e.Cancel = True
                    Else
                        'Reset m_MethodDesc_Created, clear out Method Desc Selection
                        m_MethodDesc_Created = ""
                        If Not (rbtnAutoGenMethodDesc.Checked) Then
                            'reset method desc selection
                            InitializeMethodDesc()
                        End If
                        'enable/disable Method,Data Series Info
                        SetMethodDescEnabled()
                        'NOTE: tboxVarMethod should be set in above function
                    End If
                Else
                    MsgBox("Invalid E value for the Algebraic Equation:  Value cannot be blank, it must be numeric." & vbCrLf & "NOTE: if you do not wish to use this value, then enter a 0.")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the E value for the Algebraic Equation." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxAlg_F_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxAlg_F.KeyPress
        'Handles the F Value of the Algebraic Equation key Press
        'If Enter/Return/etc is pressed, validate Value
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxAlg_F_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxAlg_F_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxAlg_F.Validating
        'Handles the F Value of the Algebraic Equation Validation
        'Checks to see if value is numeric, if so -> enables Method Descriptions
        'the inputs/outputs are standard for form events
        Try
            If Not (m_Loading) Then
                If tboxAlg_F.Text <> "" Then
                    If Not (IsNumeric(tboxAlg_F.Text)) Then
                        MsgBox("Invalid F value for the Algebraic Equation:  Value must be numeric.")
                        e.Cancel = True
                    Else
                        'Reset m_MethodDesc_Created, clear out Method Desc Selection
                        m_MethodDesc_Created = ""
                        If Not (rbtnAutoGenMethodDesc.Checked) Then
                            'reset method desc selection
                            InitializeMethodDesc()
                        End If
                        'enable/disable Method,Data Series Info
                        SetMethodDescEnabled()
                        'NOTE: tboxVarMethod should be set in above function
                    End If
                Else
                    MsgBox("Invalid F value for the Algebraic Equation:  Value cannot be blank, it must be numeric." & vbCrLf & "NOTE: if you do not wish to use this value, then enter a 0.")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the F value for the Algebraic Equation." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#End Region

#Region " Method Functionality "

#Region " Auto Generate Method Description Functionality "

    Private Sub rbtnAutoGenMethodDesc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAutoGenMethodDesc.CheckedChanged
        'Handles the Automatically Generate a Method Description radio button checked changed
        'If Checked, then validates the Method Description (Auto Generates a new one), enables/disables Data Series Area
        'the inputs/outputs are standard for form events

        Dim enableDS As Boolean = False 'Tracks if can enable the Data Series area or not
        Try
            If Not (m_Loading) Then
                If rbtnAutoGenMethodDesc.Checked Then
                    'reset m_MethodDesc_Created
                    m_MethodDesc_Created = ""

                    'Validate Method Desc -> set m_MethodDesc_Created
                    enableDS = HaveValidMethodDesc()

                    'enable/disable Data series Attributes
                    SetDSAttributesEnabled(enableDS)
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the Automatically Generate Method Description button was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " SelectExistingMethod Functionality "

    Private Sub rbtnSelectExistingMethodDesc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSelectExistingMethodDesc.CheckedChanged
        'Handles the Select an Existing Method Description radio button checked changed
        'If Checked, then validates the selected Method Description (in cboxSelectExistingMethodDesc), enables/disables Data Series Area
        'the inputs/outputs are standard for form events

        Dim enableDS As Boolean = False 'Tracks if can enable the Data Series area or not
        Try
            If Not (m_Loading) Then
                If rbtnSelectExistingMethodDesc.Checked Then
                    'enable cboxSelectExistingMethodDesc
                    cboxSelectExistingMethodDesc.Enabled = True

                    'reset m_MethodDesc_Created
                    m_MethodDesc_Created = ""
                    'disable/enable Data Series Attributes
                    enableDS = HaveValidMethodDesc()

                    'enable/disable Data series Attributes
                    SetDSAttributesEnabled(enableDS)
                Else
                    'disable cboxSelectExistingMethodDesc
                    cboxSelectExistingMethodDesc.Enabled = False
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the Select an existing Method Description button was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub cboxSelectExistingMethodDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxSelectExistingMethodDesc.SelectedIndexChanged
        'Handles the Existing Method Description combo box selected index changed
        'Validates selected value, resets Method description, enable/disables Data Series Area
        'the inputs/outputs are standard for form events

        Dim enableDS As Boolean = False 'Tracks if can enable the Data Series area or not
        Try
            If Not (m_Loading) Then
                'reset m_MethodDesc_Created
                m_MethodDesc_Created = ""
                If cboxSelectExistingMethodDesc.SelectedIndex >= 0 Then
                    'Validate Method Desc -> set m_MethodDesc_Created
                    enableDS = HaveValidMethodDesc()
                Else
                    'disable Data Series Attributes
                    enableDS = False
                End If
                'enable/disable Data series Attributes
                SetDSAttributesEnabled(enableDS)
            End If
        Catch ex As Exception
            ShowError("An Error occurred when an existing Method Description was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " CreateNewMethod Functionality "

    Private Sub rbtnCreateNewMethodDesc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCreateNewMethodDesc.CheckedChanged
        'Handles the Create a New Method Description radio button checked changed
        'If Checked, then validates the specified Method Description (in tboxCreateNewMethodDesc), enables/disables Data Series Area
        'the inputs/outputs are standard for form events

        Dim enableDS As Boolean = False 'Tracks if can enable the Data Series area or not
        Try
            If Not (m_Loading) Then
                If rbtnCreateNewMethodDesc.Checked Then
                    'enable tboxNewMethodDesc
                    tboxNewMethodDesc.Enabled = True

                    'reset m_MethodDesc_Created
                    m_MethodDesc_Created = ""

                    'Validate Mehod Desc -> set m_MethodDesc_Created
                    enableDS = HaveValidMethodDesc()

                    'enable/disable Data series Attributes
                    SetDSAttributesEnabled(enableDS)
                Else
                    'disable tboxNewMethodDesc
                    tboxNewMethodDesc.Enabled = False
                End If
            End If
        Catch ex As Exception
            ShowError("An Error occurred when the Create a new Method Description button was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub tboxNewMethodDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tboxNewMethodDesc.KeyPress
        'Handles the Create New Method Description text box key Press
        'If Enter/Return/etc is pressed, validate Value
        'the inputs/outputs are standard for form events
        Select Case e.KeyChar
            Case vbCr, vbCrLf, vbLf 'return key
                tboxNewMethodDesc_Validating(sender, New System.ComponentModel.CancelEventArgs)
        End Select
    End Sub

    Private Sub tboxNewMethodDesc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tboxNewMethodDesc.Validating
        'Validates the Create New Method Description textbox Value
        'checks to see if have a value, reset Method Description, enables/disables Data Series Area
        'the inputs/outputs are standard for form events
        Dim enableDS As Boolean = False 'tracks if can enable the data series attributes or not
        Try
            If Not (m_Loading) Then
                m_MethodDesc_Created = ""
                If tboxNewMethodDesc.Text <> "" Then
                    'reset m_MethodDesc_Created
                    m_MethodDesc_Created = ""

                    'Validate Method Desc -> set m_MethodDesc_Created
                    enableDS = HaveValidMethodDesc()
                Else
                    'show error -> blank Method Description
                    MsgBox("Invalid Method Description:  Method Description cannot be blank")
                    'disable Data Series Attributes
                    enableDS = False
                End If
                'enable/disable Data series Attributes
                SetDSAttributesEnabled(enableDS)
            End If
        Catch ex As Exception
            ShowError("An Error occurred when an existing Method Description was selected." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#End Region

#Region " Data Series Attributes Functionality "

    Private Sub cboxVariable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxVariable.SelectedIndexChanged
        'Handles the Variable Selection Changed in the Data Series Attributes area
        'If have valid index, validates Data Series Atts, enables/disables DeriveNewDS button
        'the inputs/outputs are standard for form events
        Dim varCode As String 'variable code to load the units,speciation info for
        Dim varUnits As String = "" 'variable units retrieved from the database
        Dim speciation As String = "" 'speciation retrieved from the database
        Dim fCreateNewVar As frmCreateNewVariable 'instance of frmCreateNewVariable -> allows user to create a new variable
        Dim deriveMethod As String
        Dim dsFromVarID As Integer = -1
        Dim varName As String = ""
        Dim i As Integer
        Try
            If cboxVariable.SelectedIndex >= 0 Then
                '1. check to see if selected value = <create new>
                If cboxVariable.Text = m_createNewVar Then
                    '1. get info needed for frmCreateNewVariable form
                    dsFromVarID = m_DSFromIDs.VariableID
                    Select Case True
                        'Note: won't ever use this when creating a controlled ds for editing, so not putting in check for it
                        
                        Case rbtnCreateDS_Smoothed.Checked
                            deriveMethod = g_DeriveMethod_Smooth
                            varName = Split(m_Variable, " - ")(1)
                            varUnits = m_VarUnits
                            speciation = m_Speciation
                        Case rbtnAggregate.Checked
                            deriveMethod = g_DeriveMethod_Aggregate
                            varName = Split(m_Variable, " - ")(1)
                            varUnits = m_VarUnits
                            speciation = m_Speciation
                        Case rbtnAlgebraic.Checked
                            deriveMethod = g_DeriveMethod_Algebraic
                            varName = ""
                            varUnits = ""
                            speciation = ""
                        Case Else
                            'don't know how deriving, exit
                            cboxVariable.SelectedIndex = -1
                            cboxVariable.Text = ""
                            Exit Try
                    End Select

                    '2. Create instance of frmDeriveNewDataSeries
                    fCreateNewVar = New frmCreateNewVariable(CDbl(tboxTSValue.Text), tboxTSUnits.Text, GetUnitsIDFromDB(tboxTSUnits.Text), tboxVarValueType.Text, tboxVarDataType.Text, tboxVarGenCategory.Text, tboxVarSampleMed.Text, GetVarNoDataValueFromDB(dsFromVarID), GetVarIsRegularFromDB(dsFromVarID), deriveMethod, varName, varUnits, speciation)
                    Me.AddOwnedForm(fCreateNewVar)
                    '3. Show the form,If Cancel = do nothing, 
                    If fCreateNewVar.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Dim selIndex As Integer = -1
                        '2. reload variables
                        cboxVariable.Items.Clear()
                        cboxVariable.Text = ""
                        LoadSelVariables(deriveMethod)

                        '3. select new variable in list
                        varCode = fCreateNewVar.tboxVarCode.Text
                        For i = 0 To cboxVariable.Items.Count - 1
                            If Split(cboxVariable.Items(i).ToString, " - ")(0) = varCode Then
                                selIndex = i
                                'exit early
                                i = cboxVariable.Items.Count
                            End If
                        Next i
                        If selIndex >= 0 Then
                            'select the newly created variable
                            cboxVariable.SelectedIndex = selIndex
                        End If
                    Else
                        'reset text = "", exit
                        cboxVariable.SelectedIndex = -1
                        cboxVariable.Text = ""
                        Exit Try
                    End If
                    'remove owned form
                    Me.RemoveOwnedForm(fCreateNewVar)
                    'release resources
                    If Not (fCreateNewVar Is Nothing) Then
                        fCreateNewVar.Dispose()
                        fCreateNewVar = Nothing
                    End If
                Else
                    '2. load the units,speciation for the selected variable
                    varCode = Split(cboxVariable.Text, " - ")(0)
                    varUnits = GetVarUnitsFromDB(varCode)
                    speciation = GetSpeciationFromDB(varCode)
                    tboxVarUnits.Text = varUnits
                    tboxVarSpeciation.Text = speciation
                End If

                '3. enable/disable Derive New Data Series button
                If HaveValidDSAttributes() = True Then
                    'enable btnDeriveNewDS
                    btnDeriveNewDS.Enabled = True
                Else
                    'disable btnDeriveNewDS
                    btnDeriveNewDS.Enabled = False
                End If
            Else
                'disable btnDeriveNewDS
                btnDeriveNewDS.Enabled = False
            End If
        Catch ex As Exception
            ShowError("An Error occurred when a new Variable was selected." & vbCrLf & "Message = " & ex.Message, ex)
            'disable btnDeriveNewDS
            btnDeriveNewDS.Enabled = False
        End Try
    End Sub

    'Private Sub cboxVarUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '	'Handles the Variable Units Selection Changed in the Data Series Attributes area
    '	'If have valid index, validates Data Series Atts, enables/disables DeriveNewDS button
    '	'the inputs/outputs are standard for form events
    '	Try
    '		'1. Validate sel value
    '		If cboxVarUnits.SelectedIndex >= 0 Then
    '			'2. enable/disable Derive New Data Series button
    '			If HaveValidDSAttributes() = True Then
    '				'enable btnDeriveNewDS
    '				btnDeriveNewDS.Enabled = True
    '			Else
    '				'disable btnDeriveNewDS
    '				btnDeriveNewDS.Enabled = False
    '			End If
    '		Else
    '			'disable btnDeriveNewDS
    '			btnDeriveNewDS.Enabled = False
    '		End If
    '	Catch ex As Exception
    '		ShowError("An Error occurred when new Variable Units were selected." & vbCrLf & "Message = " & ex.Message, ex)
    '		'disable btnDeriveNewDS
    '		btnDeriveNewDS.Enabled = False
    '	End Try
    'End Sub

    Private Sub cboxVarQCLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxVarQCLevel.SelectedIndexChanged
        'Handles the QC Level Selection Changed in the Data Series Attributes area
        'If have valid index, validates Data Series Atts, enables/disables DeriveNewDS button
        'the inputs/outputs are standard for form events
        Try
            If cboxVarQCLevel.SelectedIndex >= 0 Then
                'enable/disable Derive New Data Series button
                If HaveValidDSAttributes() = True Then
                    'enable btnDeriveNewDS
                    btnDeriveNewDS.Enabled = True
                Else
                    'disable btnDeriveNewDS
                    btnDeriveNewDS.Enabled = False
                End If
            Else
                'disable btnDeriveNewDS
                btnDeriveNewDS.Enabled = False
            End If
        Catch ex As Exception
            ShowError("An Error occurred when a new Quality Control Level was selected." & vbCrLf & "Message = " & ex.Message, ex)
            'disable btnDeriveNewDS
            btnDeriveNewDS.Enabled = False
        End Try
    End Sub

#End Region

#Region " Tooltip Functionality "

#Region " Method Description "

    Private Sub cboxSelectExistingMethodDesc_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxSelectExistingMethodDesc.MouseEnter
        'Handles the Select an Existing Method Description combobox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = cboxSelectExistingMethodDesc text
        ttipDeriveNewDS.SetToolTip(cboxSelectExistingMethodDesc, cboxSelectExistingMethodDesc.Text)
    End Sub

    Private Sub tboxNewMethodDesc_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxNewMethodDesc.MouseEnter
        'Handles the Create New Method Description textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxNewMethodDesc text
        ttipDeriveNewDS.SetToolTip(tboxNewMethodDesc, tboxNewMethodDesc.Text)
    End Sub

#End Region

#Region " Data Series Attributes "

    Private Sub tboxDSSite_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxDSSite.MouseEnter
        'Handles the Site textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxDSSite text
        ttipDeriveNewDS.SetToolTip(tboxDSSite, tboxDSSite.Text)
    End Sub

    Private Sub cboxVariable_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxVariable.MouseEnter
        'Handles the Variable textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = cboxVariable text
        ttipDeriveNewDS.SetToolTip(cboxVariable, cboxVariable.Text)
    End Sub

    'Private Sub cboxVarUnits_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
    '	'Handles the Variable Units combobox Mouse Enter
    '	'Sets the tooltip value = text
    '	'the inputs/outputs are standard for form events

    '	'set the tooltip = cboxVarUnits text
    '	ttipDeriveNewDS.SetToolTip(cboxVarUnits, cboxVarUnits.Text)
    'End Sub

    Private Sub tboxVarUnits_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxVarUnits.MouseEnter
        'Handles the Variable Units combobox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = cboxVarUnits text
        ttipDeriveNewDS.SetToolTip(tboxVarUnits, tboxVarUnits.Text)
    End Sub

    Private Sub tboxTSUnits_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxTSUnits.MouseEnter
        'Handles the Time Support Units textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxTSUnits text
        ttipDeriveNewDS.SetToolTip(tboxTSUnits, tboxTSUnits.Text)
    End Sub

    Private Sub tboxSourceOrg_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxSourceOrg.MouseEnter
        'Handles the Source Organization textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxSourceOrg text
        ttipDeriveNewDS.SetToolTip(tboxSourceOrg, tboxSourceOrg.Text)
    End Sub

    Private Sub tboxSourceDesc_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxSourceDesc.MouseEnter
        'Handles the Source Description textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxSourceDesc text
        ttipDeriveNewDS.SetToolTip(tboxSourceDesc, tboxSourceDesc.Text)
    End Sub

    Private Sub tboxVarGenCategory_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxVarGenCategory.MouseEnter
        'Handles the General Category textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxVarGenCategory text
        ttipDeriveNewDS.SetToolTip(tboxVarGenCategory, tboxVarGenCategory.Text)
    End Sub

    Private Sub tboxVarSampleMed_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxVarSampleMed.MouseEnter
        'Handles the Sample Medium textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxVarSampleMed text
        ttipDeriveNewDS.SetToolTip(tboxVarSampleMed, tboxVarSampleMed.Text)
    End Sub

    Private Sub tboxVarValueType_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxVarValueType.MouseEnter
        'Handles the Value Type textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxVarValueType text
        ttipDeriveNewDS.SetToolTip(tboxVarValueType, tboxVarValueType.Text)
    End Sub

    Private Sub tboxVarDataType_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxVarDataType.MouseEnter
        'Handles the Data Type textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxVarDataType text
        ttipDeriveNewDS.SetToolTip(tboxVarDataType, tboxVarDataType.Text)
    End Sub

    Private Sub tboxVarMethod_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tboxVarMethod.MouseEnter
        'Handles the Method Description (in the Data Series Atts area) textbox Mouse Enter
        'Sets the tooltip value = text
        'the inputs/outputs are standard for form events

        'set the tooltip = tboxVarMethod text
        ttipDeriveNewDS.SetToolTip(tboxVarMethod, tboxVarMethod.Text)
    End Sub

#End Region

#End Region

#End Region

#Region " Validation Functions "

    'NOTE: Due to changes in QCLevels from ODM1.1 Schema, this is no longer needed -> this option is always available
    'Private Function CanUseCreateQCLevel1ToDerive(ByVal dsIDs As clsDataSeriesIDs) As Boolean
    '    'This function checks to see the Create a QC Level1 Data series button can be enabled or not
    '    'Inputs:  dsIDs -> set of IDs for the Data Series deriving from
    '    'Outputs: Boolean -> tracks if a QC Level1 Data Series can be created from the given Data Series
    '    Dim query As String 'sql query to pull qcLevel info from the database
    '    Dim qcLevelDT As Data.DataTable 'data table to hold the data pulled from the database
    '    Dim i As Integer 'counter
    '    Dim haveLevel1 As Boolean = False 'tracks if a QC Level 1 value has been found for the given data series
    '    'NOTE: current qclevel must be = 0 and no level1 already created for this site,variable,method,source
    '    Try
    '        '1.check qclevel -> (only if current QCLevel = 0 can a level1 be created)
    '        If dsIDs.QCLevel = 0 Then
    '            'initialize haveLevel1 = false
    '            haveLevel1 = False
    '            'Check to see if a level1 already exists for this Site,Variable, method, source
    '            query = "SELECT " & db_fld_SCQCLevel & " FROM " & db_tbl_SeriesCatalog & " WHERE " & db_fld_SCSiteID & " = " & dsIDs.SiteID & " AND " & db_fld_SCVarID & " = " & dsIDs.VariableID & " AND " & db_fld_SCSourceID & " = " & dsIDs.SourceID & " ORDER BY " & db_fld_SCQCLevel
    '            qcLevelDT = OpenTable("CanCreateQCLevel1", query, g_CurrConnSettings)
    '            'validate data
    '            If (qcLevelDT Is Nothing) OrElse qcLevelDT.Rows.Count = 0 Then
    '                'nothing was retrieved, return false
    '                Exit Try
    '            End If
    '            'see if there is a data series with a QC Level 1 already
    '            For i = 0 To qcLevelDT.Rows.Count - 1
    '	If Not (qcLevelDT.Rows(i).Item(db_fld_SCQCLevel) Is DBNull.Value) Then
    '		m_QCLevelID = qcLevelDT.Rows(i)
    '		'If qcLevelDT.Rows(i).Item(db_fld_SCQCLevel) = 1 Then
    '		'    haveLevel1 = True
    '		'    Exit For
    '		'End If
    '	End If
    '            Next i

    '            'release resources
    '            If Not (qcLevelDT Is Nothing) Then
    '                qcLevelDT.Dispose()
    '                qcLevelDT = Nothing
    '            End If

    '            'return if can create a level1 (NOTE: if haveLevel1 = True, then Return False, and vise versa)
    '            Return Not (haveLevel1)
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        ShowError("An Error occurred while validating if the new Data Series can be derived as a Quality Control Level1 Data Series from raw data." & vbCrLf & "Message = " & ex.Message, ex)
    '    End Try
    '    'release resources
    '    If Not (qcLevelDT Is Nothing) Then
    '        qcLevelDT.Dispose()
    '        qcLevelDT = Nothing
    '    End If
    '    Return False
    'End Function

    Private Function CanUseSmoothingAlgorithmToDerive(ByVal varID As Integer) As Boolean
        'This function checks to see the Create a Smoothed Data Series button can be enabled or not
        'Inputs:  varID -> the variable ID for the selected Data Series -> so can retrieve the IsRegular value for the variable
        'Outputs: Boolean -> tracks if can use the smoothing functionality or not
        Dim isRegular As Boolean = False 'tracks if variable is Regular or not -> only can smoothed a Regularly spaced data set = Return Value
        Try
            '1. get the IsRegular value for the given VariableID
            isRegular = GetVarIsRegularFromDB(varID)

            '2. return value
            Return isRegular
        Catch ex As Exception
            ShowError("An Error occurred while validating if the new Data Series can be derived using a Daily Aggregate Method." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'errors occurred above, return false
        Return False
    End Function

    Private Function HaveValidMethodDesc() As Boolean
        'This function determines if a valid Method Description has been set yet
        'Inputs:  None
        'Outputs: Boolean -> tells if have a valid Method Description or not
        Try
            '1. Make sure have set m_MethodDesc_Created
            Select Case True
                Case rbtnAutoGenMethodDesc.Checked
                    'Generate the new method
                    m_MethodDesc_Created = AutoGenerateMethodDesc()
                Case rbtnSelectExistingMethodDesc.Checked
                    'reset m_MethodDesc_Created
                    m_MethodDesc_Created = ""
                    'get selected method desc
                    If cboxSelectExistingMethodDesc.SelectedIndex >= 0 Then
                        m_MethodDesc_Created = cboxSelectExistingMethodDesc.Text
                    Else
                        'nothing is selected, so return false
                        Exit Try
                    End If
                Case rbtnCreateNewMethodDesc.Checked
                    'reset m_MethodDesc_Created
                    m_MethodDesc_Created = ""
                    'get user specified method
                    If tboxNewMethodDesc.Text <> "" Then
                        m_MethodDesc_Created = Trim(tboxNewMethodDesc.Text)
                    Else
                        'no method set, so return False
                        Exit Try
                    End If
                Case Else
                    'no method selected, return false
                    Exit Try
            End Select
            'set the Method Desc text
            tboxVarMethod.Text = m_MethodDesc_Created
            'return if valid
            If m_MethodDesc_Created <> "" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the Method Description. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'errors occurred above, return false
        Return False
    End Function

    Private Function HaveValidDSAttributes() As Boolean
        'This function checks to make sure all of the data that can be changed is set
        'Inputs:  None
        'Outputs: Boolean -> returns if the Data Series Attributes selected are valid or not
        'NOTE: This function does NOT test to see if there is a Data Series that already matches the selected parameters -> that is done when the user tries to derive a data series only
        Dim validVar As Boolean = False 'tracks if have a valid Variable set -> default value = False
        Dim validVarUnits As Boolean = False 'tracks if have valid Variable Units set -> default value = False
        Dim validSpeciation As Boolean = False 'track if have valid Speciation -> default value = False
        Dim validTimeSupport As Boolean = False 'tracks if have a valid Time Support value set -> default value = False
        Dim validValueType As Boolean = False 'tracks if have a valid Value Type set -> default value = False
        Dim validDataType As Boolean = False 'tracks if have a valid Data Type set -> default value = False
        Dim validQCLevel As Boolean = False 'tracks if have a valid QC Level selected -> default value = False
        Dim validMethodDesc As Boolean = False 'tracks if have a valid Method Description set -> default value = False
        'Dim curQCLevel As Integer 'holds the QCLevel for the Data Series deriving from -> so can validate the selected QC Level
        Try
            '1. Validate Variable
            If cboxVariable.SelectedIndex >= 0 And cboxVariable.Text <> "" Then
                validVar = True
            Else
                validVar = False
            End If

            '2. Validate Variable Units
            If tboxVarUnits.Text <> "" Then
                validVarUnits = True
            Else
                validVarUnits = False
            End If
            'NOTE: Variable Units are now associated with a unique code, so value is read only
            'If cboxVarUnits.SelectedIndex >= 0 And cboxVarUnits.Text <> "" Then
            '	validVarUnits = True
            'Else
            '	validVarUnits = False
            'End If

            '3. Validate Speciation
            If tboxVarSpeciation.Text <> "" Then
                validSpeciation = True
            Else
                validSpeciation = False
            End If

            '3. Validate Time Support
            If tboxTSValue.Text <> "" And tboxTSUnits.Text <> "" Then
                validTimeSupport = True
            Else
                validTimeSupport = False
            End If

            '4. Validate Value Type
            If tboxVarValueType.Text <> "" Then
                validValueType = True
            Else
                validValueType = False
            End If

            '5. Validate Data Type
            If tboxVarDataType.Text <> "" Then
                validDataType = True
            Else
                validDataType = False
            End If

            '6. Validate QC Level
            'get the selected QC Level
            If cboxVarQCLevel.SelectedIndex >= 0 And cboxVarQCLevel.Text <> "" Then
                validQCLevel = True
                'NOTE: Changing this to check against QCLevel from DB -> per changes made to ODM1.1 Schema
                '           curQCLevel = CInt(Split(cboxVarQCLevel.Text, " - ")(0))
                '           'make sure selected QC Level >,= Data series QC Level (DS deriving from)
                '           If curQCLevel >= m_DSFromIDs.QCLevel Then
                '               validQCLevel = True
                '           Else
                'MsgBox("Invalid Quality Control Level: Please select a different QC Level")
                ''NOTE: Only load QCLevels at startup now -> all are always available
                ' ''reload QC Levels
                ''LoadQCLevels(m_DSFromIDs.QCLevel)
                '               validQCLevel = False
                '           End If
            Else
                validQCLevel = False
            End If

            '7. Validate Method Desc
            If tboxVarMethod.Text <> "" Then
                validMethodDesc = True
            Else
                validMethodDesc = False
            End If

            '8. return True if all are valid, else return false
            If Not (validVar) OrElse Not (validVarUnits) OrElse Not (validSpeciation) OrElse Not (validTimeSupport) OrElse Not (validValueType) OrElse Not (validDataType) OrElse Not (validQCLevel) OrElse Not (validMethodDesc) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            ShowError("An Error occurred while validating the new Data Series Attributes." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'errors occurred above
        Return False
    End Function

#Region " Old Functionality -> no longer being used "

    'Private Function CanUseAggregateMethodToDerive(ByVal timeSupport As Double, ByVal tsUnits As String) As Boolean
    '	'This function checks to see the Create an Data Series using an Aggregate Function button can be enabled or not
    '	'Inputs:  timeSupport ->
    '	'         tsUnits ->
    '	'Outputs: Boolean -> 
    '	'Dim canUseAggregate As Boolean = False
    '	'Const numMilliSeconds_perDay As Integer = 86400000
    '	'Const numSeconds_perDay As Integer = 86400
    '	'Const numMinutes_perDay As Integer = 1440
    '	'Const numHours_perDay As Integer = 24
    '	Try
    '		'NOTE: doing this for now -> allow user to do if want!!
    '		Return True

    '		'****************************************************************************************************************************************************************************
    '		''1. see if time support units can be put into daily average
    '		'Select Case tsUnits
    '		'	Case db_val_UnitsTimeSupport_MilliSecond
    '		'		'units = millisecond -> make sure Value < 86400000
    '		'		If timeSupport < numMilliSeconds_perDay Then
    '		'			canUseAggregate = True
    '		'		Else
    '		'			canUseAggregate = False
    '		'		End If
    '		'	Case db_val_UnitsTimeSupport_Second
    '		'		'units = second -> make sure Value < 86400
    '		'		If timeSupport < numSeconds_perDay Then
    '		'			canUseAggregate = True
    '		'		Else
    '		'			canUseAggregate = False
    '		'		End If
    '		'	Case db_val_UnitsTimeSupport_Minute
    '		'		'units = minute -> make sure Value < 1440
    '		'		If timeSupport < numMinutes_perDay Then
    '		'			canUseAggregate = True
    '		'		Else
    '		'			canUseAggregate = False
    '		'		End If
    '		'	Case db_val_UnitsTimeSupport_Hour
    '		'		'units = hour -> make sure Value < 24
    '		'		If timeSupport < numHours_perDay Then
    '		'			canUseAggregate = True
    '		'		Else
    '		'			canUseAggregate = False
    '		'		End If
    '		'	Case db_val_UnitsTimeSupport_Day
    '		'		'units = Day -> make sure Value < 1
    '		'		If timeSupport < 1 Then
    '		'			canUseAggregate = True
    '		'		Else
    '		'			canUseAggregate = False
    '		'		End If
    '		'	Case Else
    '		'		'any other units cannot be averaged for daily data -> return false
    '		'		canUseAggregate = False
    '		'End Select

    '		'Return canUseAggregate
    '		'****************************************************************************************************************************************************************************
    '	Catch ex As Exception
    '		ShowError("An Error occurred while validating if the new Data Series can be derived using a Daily Aggregate Method." & vbCrLf & "Message = " & ex.Message, ex)
    '	End Try
    '	'errors occurred above, return false
    '	Return False
    'End Function

#End Region

#End Region

#Region " Loading Functions "

    Private Function LoadExistingMethodDescriptions() As Boolean
        'This function loads the existing Method Descriptions from the Methods table in the database
        'Inputs:  None
        'Outputs: Boolean -> tracks if successfully loaded the Method Descriptions from the database or not
        Dim i As Integer 'counter
        Dim methodDescDT As Data.DataTable 'Datatable to hold the Sites retrieved and loaded from the Series Catalog Table in the Database
        Dim query As String 'SQL Query to pull the data from the database
        Dim methodID As Integer 'the MethodID value retrieved from the Database -> 
        Dim methodDesc As String 'the MethodDescription value retrieved from the Database ->
        Try
            '1. clear out any old data 
            cboxSelectExistingMethodDesc.Items.Clear()
            m_ExistingMethodDescIDs = Nothing

            '2. Connect to the database
            query = "SELECT * FROM " & db_tbl_Methods & " ORDER BY " & db_fld_MethID

            methodDescDT = OpenTable("ExistingMethodDesc", query, g_CurrConnSettings)
            If (methodDescDT Is Nothing) OrElse methodDescDT.Rows.Count = 0 Then
                'release resources
                If Not (methodDescDT Is Nothing) Then
                    methodDescDT.Dispose()
                    methodDescDT = Nothing
                End If

                'return false -> no values were added
                Return True
            End If

            '3. get the Sites from the Series Catalog Table,load the Sites into cboxSites
            ReDim m_ExistingMethodDescIDs(methodDescDT.Rows.Count - 1)
            For i = 0 To methodDescDT.Rows.Count - 1
                If Not (methodDescDT.Rows(i).Item(db_fld_MethID) Is DBNull.Value) Then
                    methodID = methodDescDT.Rows(i).Item(db_fld_MethID)
                Else
                    methodID = -1
                End If
                If Not (methodDescDT.Rows(i).Item(db_fld_MethDesc) Is DBNull.Value) Then
                    methodDesc = methodDescDT.Rows(i).Item(db_fld_MethDesc)
                Else
                    methodDesc = " "
                End If
                m_ExistingMethodDescIDs(i) = methodID
                cboxSelectExistingMethodDesc.Items.Add(methodDesc)
            Next i

            '4. release resources
            If Not (methodDescDT Is Nothing) Then
                methodDescDT.Dispose()
                methodDescDT = Nothing
            End If

            Return True
        Catch ex As Exception
            ShowError("An Error occurred while loading the existing Method Descriptions." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (methodDescDT Is Nothing) Then
            methodDescDT.Dispose()
            methodDescDT = Nothing
        End If
        'errors occurred above, return false
        Return False
    End Function

    Private Sub LoadDataSeriesAttributes()
        'This function Loads the info in the Data Series Attributes area based on what can be selected
        'Inputs:  None
        'Outputs: None
        Try
            '1. Load Read Only Data -> always the same no matter what derive method is
            If Not (m_isDSReadOnlyLoaded) Then
                LoadReadOnlyData()
            End If

            '2. Load the Value Type
            If Not (m_isDSValueTypeLoaded) Then
                LoadValueType()
            End If

            '3. Load the Data Type
            If Not (m_isDSDataTypeLoaded) Then
                LoadDataType()
            End If

            '4. Load the Time Support, Time Support Units
            If Not (m_isDSTSLoaded) Then
                LoadTimeSupport_Units()
            End If

            '5. Load the Variable, Variable Units, Speciation
            If Not (m_isDSVarLoaded) Then
                LoadVariable_Units_Speciation()
            End If

            'NOTE: Only load on startup -> can select any type now any time = for new OCM1.1 Schema
            ''6. Load the QC Level
            'If Not (m_isDSQCLevelLoaded) Then
            '    LoadQCLevels(m_DSFromIDs.QCLevel)
            'End If
        Catch ex As Exception
            ShowError("An Error occurred while loading the Data Series Attributes." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub LoadReadOnlyData()
        'This function loads the Read Only Data Series Attributes (NOTE: these values will not change for any of the Derive Methods)
        'Inputs:  None
        'Outputs: None
        Try
            'set the read only data
            tboxDSSite.Text = m_Site
            tboxVarSampleMed.Text = m_SampleMed
            tboxVarGenCategory.Text = m_GenCategory
            tboxSourceOrg.Text = m_Organization
            tboxSourceDesc.Text = m_SourceDesc
            tboxSourceCitation.Text = m_Citation

            'set that the read only data = loaded
            m_isDSReadOnlyLoaded = True
        Catch ex As Exception
            ShowError("An Error occurred while loading the Read-Only Data Series Information." & vbCrLf & "Message = " & ex.Message, ex)
            'set that the read only data <> Loaded
            m_isDSReadOnlyLoaded = False
        End Try
    End Sub

    Private Sub LoadValueType()
        'This function Loads the ValueType based on Derive Method
        'If CreateLevel1 = checked, ValueType = current Data Series Value Type
        'Else ValueType = "Derived Value"
        'Inputs:  None
        'Outputs: None
        Try
            '1. set the Value Type
            Select Case True
                Case rbtnCreateDS_QCLevel1.Checked
                    'same as Data Series deriving from
                    tboxVarValueType.Text = m_ValueType
                Case rbtnCreateDS_Smoothed.Checked, rbtnAggregate.Checked, rbtnAlgebraic.Checked
                    tboxVarValueType.Text = db_val_VTCVTerm_DerivedValue
                Case Else
                    'set text = ""
                    tboxVarValueType.Text = ""
                    'set that the Value Type <> Loaded
                    m_isDSValueTypeLoaded = False
                    'exit
                    Exit Try
            End Select

            'set m_isDSValueTypeLoaded = True
            m_isDSValueTypeLoaded = True
        Catch ex As Exception
            ShowError("An Error occurred while loading the Value Type." & vbCrLf & "Message = " & ex.Message, ex)
            'set that the Value Type <> Loaded
            m_isDSValueTypeLoaded = False
        End Try
    End Sub

    Private Sub LoadDataType()
        'This function Loads the DataType based on Derive Method
        'If Aggregate = checked, DataType = max,min,avg -> depending on type selected
        'Else DataType = current Data Series Data Type
        'Inputs:  None
        'Outputs: None
        Try
            '1. set the Data Type
            Select Case True
                Case rbtnCreateDS_QCLevel1.Checked, rbtnCreateDS_Smoothed.Checked, rbtnAlgebraic.Checked
                    'same as Data Series deriving from
                    tboxVarDataType.Text = m_DataType
                Case rbtnAggregate.Checked
                    Select Case True
                        Case rbtnAgg_Max.Checked
                            tboxVarDataType.Text = db_val_DTCVTerm_Maximum
                        Case rbtnAgg_Min.Checked
                            tboxVarDataType.Text = db_val_DTCVTerm_Minimum
                        Case rbtnAgg_Avg.Checked
                            tboxVarDataType.Text = db_val_DTCVTerm_Average
                        Case Else
                            tboxVarDataType.Text = ""
                            'set that the Data Type <> Loaded
                            m_isDSDataTypeLoaded = False
                            'exit
                            Exit Try
                    End Select
                Case Else
                    'set text = ""
                    tboxVarDataType.Text = ""
                    'set that the Data Type <> Loaded
                    m_isDSDataTypeLoaded = False
                    'exit
                    Exit Try
            End Select

            'set m_isDSDataTypeLoaded = True
            m_isDSDataTypeLoaded = True
        Catch ex As Exception
            ShowError("An Error occurred while loading the Data Type." & vbCrLf & "Message = " & ex.Message, ex)
            'set that the Data Type <> Loaded
            m_isDSDataTypeLoaded = False
        End Try
    End Sub

    Private Sub LoadTimeSupport_Units()
        'This function Loads the Time Support info based on Derive Method
        'If Aggregate = checked, Time Support = 1 day
        'Else Time Support = current Data Series Time Support
        'Inputs:  None
        'Outputs: None
        Try
            '1. set the Time Support Value, Units
            Select Case True
                Case rbtnCreateDS_QCLevel1.Checked, rbtnCreateDS_Smoothed.Checked, rbtnAlgebraic.Checked
                    'same as Data Series deriving from
                    tboxTSValue.Text = m_TimeSupport
                    tboxTSUnits.Text = m_TSUnits
                Case rbtnAggregate.Checked
                    '1 Day
                    tboxTSValue.Text = 1
                    tboxTSUnits.Text = db_val_UnitsTimeSupport_Day
                Case Else
                    'clear out any values -> make it invalid
                    'set value,units = ""
                    tboxTSValue.Text = ""
                    tboxTSUnits.Text = ""
                    'set that the Time Support <> Loaded
                    m_isDSTSLoaded = False
                    'exit
                    Exit Try
            End Select

            m_isDSTSLoaded = True
        Catch ex As Exception
            ShowError("An Error occurred while loading the Time Support." & vbCrLf & "Message = " & ex.Message, ex)
            'set that the Time Support <> Loaded
            m_isDSTSLoaded = False
        End Try
    End Sub

    Private Sub LoadQCLevels() 'ByVal curDSQCLevel As Integer)
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
            cboxVarQCLevel.Items.Clear()
            cboxVarQCLevel.Text = ""

            'NOTE: Changing this to read QC Levels from DB -> to match new ODM1.1 Schema
            ''2. Load QC Level Descriptions if needed
            'If Not db_qclLoaded Then
            '    LoadQCLevelDefinitions()
            'End If

            '3. Add the correct QC Levels -> based on current Data Series QC Level
            query = "SELECT DISTINCT " & db_fld_QCLQCLevel & ", " & db_fld_QCLCode & ", " & db_fld_QCLDefinition & " FROM " & db_tbl_QCLevels & " ORDER BY " & db_fld_QCLQCLevel
            qcLevelDT = OpenTable("selQCLevels", query, g_CurrConnSettings)
            'validate data
            If Not (qcLevelDT Is Nothing) AndAlso qcLevelDT.Rows.Count > 0 Then
                '2. load variables into cboxVarQCLevel
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
                    cboxVarQCLevel.Items.Add(qcLevel_Code & " - " & qcLevel_Def)
                Next i

                ''4. set that QC Levels = Loaded
                'm_isDSQCLevelLoaded = True
                'Else
                '	'4. set that QC Levels = Loaded
                '	m_isDSQCLevelLoaded = False
            End If

            '5. Release resources
            If Not (qcLevelDT Is Nothing) Then
                qcLevelDT.Dispose()
                qcLevelDT = Nothing
            End If
            'NOTE: Changing this to read QC Levels from DB -> to match new ODM1.1 Schema
            'Select Case curDSQCLevel
            '    Case 0
            '        'add values based on selected derive method
            '        Select Case True
            '            Case rbtnCreateDS_Smoothed.Checked, rbtnAggregate.Checked, rbtnAlgebraic.Checked
            '                'ONLY add value = 0
            '                cboxVarQCLevel.Items.Add(0 & " - " & db_val_QCLDef_Level(1, GetQCLDefID(0)))
            '                'select the value
            '                cboxVarQCLevel.SelectedIndex = 0
            '            Case rbtnCreateDS_QCLevel1.Checked
            '                'ONLY add value = 1 
            '                cboxVarQCLevel.Items.Add(1 & " - " & db_val_QCLDef_Level(1, GetQCLDefID(1)))
            '                'select the value
            '                cboxVarQCLevel.SelectedIndex = 0
            '            Case Else
            '                'add NOTHING, set that QC Levels <> Loaded
            '                m_isDSQCLevelLoaded = False
            '                'exit 
            '                Exit Try
            '        End Select
            '    Case 1, 2
            '        'add 2,3,4
            '        cboxVarQCLevel.Items.Add(2 & " - " & db_val_QCLDef_Level(1, GetQCLDefID(2)))
            '        cboxVarQCLevel.Items.Add(3 & " - " & db_val_QCLDef_Level(1, GetQCLDefID(3)))
            '        cboxVarQCLevel.Items.Add(4 & " - " & db_val_QCLDef_Level(1, GetQCLDefID(4)))
            '    Case 3
            '        'add 3,4
            '        cboxVarQCLevel.Items.Add(3 & " - " & db_val_QCLDef_Level(1, GetQCLDefID(3)))
            '        cboxVarQCLevel.Items.Add(4 & " - " & db_val_QCLDef_Level(1, GetQCLDefID(4)))
            '    Case 4
            '        'ONLY add value = 4
            '        cboxVarQCLevel.Items.Add(4 & " - " & db_val_QCLDef_Level(1, GetQCLDefID(4)))
            '    Case Else
            '        'set that QC Levels <> Loaded
            '        m_isDSQCLevelLoaded = False
            '        'exit 
            '        Exit Try
            'End Select
            '
            ''5. set that QC Levels = Loaded
            '         m_isDSQCLevelLoaded = True
        Catch ex As Exception
            ShowError("An Error occurred while loading the QC Levels." & vbCrLf & "Message = " & ex.Message, ex)
            ''set that QC Levels <> Loaded
            'm_isDSQCLevelLoaded = False
        End Try
    End Sub

    Private Sub LoadVariable_Units_Speciation()
        'This function loads the Variable, Variable Units in the Data Series Attributes Section -> based on Derive Method
        'If Algebraic = checked, Variable,Units,Speciation = selectable
        'Else Variable,Units,Speciation = from current Data Series
        'Inputs:  None
        'Outputs: None
        Try
            '1. clear out old data
            'Variable
            cboxVariable.Items.Clear()
            cboxVariable.Text = ""
            'Units
            'cboxVarUnits.Items.Clear()
            'cboxVarUnits.Text = ""
            'NOTE: Variable Units are now read only -> associated with a unique variable code
            tboxVarUnits.Text = ""
            'Speciation
            'cboxVarSpeciation.Items.Clear()
            'cboxVarSpeciation.Text = ""
            'NOTE: Speciation is now read only -> associated with a unique variable code
            tboxVarSpeciation.Text = ""

            '2. Load the Variable, Units
            Select Case True
                Case rbtnCreateDS_QCLevel1.Checked
                    'same as Data Series deriving from
                    'Variable
                    cboxVariable.Items.Add(m_Variable)
                    'select the value
                    cboxVariable.SelectedIndex = 0
                    'Units
                    'NOTE: Variable Units are now read only -> associated with a unique variable code
                    tboxVarUnits.Text = m_VarUnits
                    'cboxVarUnits.Items.Add(m_VarUnits)
                    ''select the value
                    'cboxVarUnits.SelectedIndex = 0
                    'Speciation
                    'NOTE: Speciation is now read only -> associated with a unique variable code
                    tboxVarSpeciation.Text = m_Speciation
                    'cboxVarSpeciation.Items.Add(m_Speciation)
                    ''select the value
                    'cboxVarSpeciation.SelectedIndex = 0
                Case rbtnCreateDS_Smoothed.Checked
                    'Variable
                    LoadSelVariables(g_DeriveMethod_Smooth) 'NOTE: when a variable is selected, the units,speciation = loaded

                Case rbtnAggregate.Checked
                    'Variable
                    LoadSelVariables(g_DeriveMethod_Aggregate) 'NOTE: when a variable is selected, the units,speciation = loaded

                Case rbtnAlgebraic.Checked
                    'Variable
                    LoadSelVariables(g_DeriveMethod_Algebraic)

                    'NOTE: when a variable is selected, the units,speciation = loaded
                    ''Units
                    'LoadSelVarUnits()

                    ''Speciation
                    'LoadSelSpeciation()
                Case Else
                    'set value,units = ""
                    tboxTSValue.Text = ""
                    tboxTSUnits.Text = ""
                    'set that the Variable <> Loaded
                    m_isDSVarLoaded = False
                    'exit
                    Exit Try
            End Select

            If cboxVariable.Items.Count <= 0 Then
                m_isDSVarLoaded = False
            Else
                m_isDSVarLoaded = True
            End If
        Catch ex As Exception
            ShowError("An Error occurred while Loading the Variable, Variable Units." & vbCrLf & "Message = " & ex.Message, ex)
            'set that the Variable <> Loaded
            m_isDSVarLoaded = False
        End Try
    End Sub

    Private Sub LoadSelVariables(ByVal deriveMethod As String)
        'This function loads the Selectable Variables from the Database
        'NOTE: cboxVariable should already be cleared before calling this function
        'Inputs:  None
        'Outputs: None
        Dim i As Integer 'counter
        Dim query As String 'the SQL query used to pull the Variables to select from from the database
        Dim varDT As Data.DataTable 'the Data table of data retrieved from the database -> collection of variables to load into cboxVariable
        Dim varName As String 'the Variable Name value to retrieved variables/retreived from the Database -> used to add it to cboxVariable
        Dim varCode As String 'the Variable Code value retrieved from the Database -> used to add it to cboxVariable
        Dim valueType As String
        Dim dataType As String
        Dim genCategory As String
        Dim sampleMed As String
        Dim tsValue As Double
        Dim tsUnitsID As String
        Try
            'NOTE: for aggregate, only load variables if exist for all info(data type, etc) -> so if can retrieve from db already

            '1. Get parameters to find Variables for
            sampleMed = tboxVarSampleMed.Text
            valueType = tboxVarValueType.Text
            tsValue = CDbl(tboxTSValue.Text)
            tsUnitsID = GetUnitsIDFromDB(tboxTSUnits.Text)
            dataType = tboxVarDataType.Text
            genCategory = tboxVarGenCategory.Text

            '2. get unique Variables from the Database
            'NOTE: changed to load variables based on derive method
            Select Case deriveMethod
                Case g_DeriveMethod_Smooth, g_DeriveMethod_Aggregate
                    'make sure have a valid Data Type selected
                    If dataType = "" Then
                        'nothing is selected, load nothing
                        Exit Try
                    End If
                    'Load Variable for selected type,name only if it exists, else, load only <Create New>
                    varName = Split(m_Variable, " - ")(1) 'holds the variable name -> which needs to be the same for Aggregate,Smoothing Methods
                    query = "SELECT DISTINCT " & db_fld_VarCode & " FROM " & db_tbl_Variables & " WHERE (" & db_fld_VarName & " = '" & FormatStringForQueryFromDB(varName) & "' AND " & db_fld_VarSampleMed & " = '" & FormatStringForQueryFromDB(sampleMed) & "' AND " & db_fld_VarValueType & " = '" & FormatStringForQueryFromDB(valueType) & "' AND " & db_fld_VarTimeSupport & " = " & tsValue & " AND " & db_fld_VarTimeUnitsID & " = " & tsUnitsID & " AND " & db_fld_VarDataType & " = '" & FormatStringForQueryFromDB(dataType) & "' AND " & db_fld_VarGenCat & " = '" & FormatStringForQueryFromDB(genCategory) & "') ORDER BY " & db_fld_VarCode
                Case g_DeriveMethod_Algebraic
                    'Load all Variables from the DB with given parameters
                    query = "SELECT DISTINCT " & db_fld_VarCode & ", " & db_fld_VarName & " FROM " & db_tbl_Variables & " WHERE (" & db_fld_VarSampleMed & " = '" & FormatStringForQueryFromDB(sampleMed) & "' AND " & db_fld_VarValueType & " = '" & FormatStringForQueryFromDB(valueType) & "' AND " & db_fld_VarTimeSupport & " = " & tsValue & " AND " & db_fld_VarTimeUnitsID & " = " & tsUnitsID & " AND " & db_fld_VarDataType & " = '" & FormatStringForQueryFromDB(dataType) & "' AND " & db_fld_VarGenCat & " = '" & FormatStringForQueryFromDB(genCategory) & "') ORDER BY " & db_fld_VarCode
                Case Else
                    'don't know what derive method, so load Nothing
                    query = ""
            End Select
            ''NOTE: Changed to loading From Variables Table so that if variables are created for deriving from, can still access them!!
            ''***************************************************************************************************************************************************************************
            ''query = "SELECT DISTINCT " & db_fld_SCVarCode & ", " & db_fld_SCVarName & " FROM " & db_tbl_SeriesCatalog & " ORDER BY " & db_fld_SCVarCode & ", " & db_fld_SCVarName
            'query = "SELECT DISTINCT " & db_fld_VarCode & ", " & db_fld_VarName & " FROM " & db_tbl_Variables & " ORDER BY " & db_fld_VarCode & ", " & db_fld_VarName
            ''***************************************************************************************************************************************************************************

            varDT = OpenTable("selVars", query, g_CurrConnSettings)
            'validate data
            If Not (varDT Is Nothing) AndAlso varDT.Rows.Count > 0 Then
                '2. load variables into cboxVariable
                For i = 0 To varDT.Rows.Count - 1
                    If Not (varDT.Rows(i).Item(db_fld_VarCode) Is DBNull.Value) Then
                        varCode = varDT.Rows(i).Item(db_fld_VarCode)
                    Else
                        varCode = " "
                    End If
                    If deriveMethod = g_DeriveMethod_Algebraic Then
                        If Not (varDT.Rows(i).Item(db_fld_VarName) Is DBNull.Value) Then
                            varName = varDT.Rows(i).Item(db_fld_VarName)
                        Else
                            varName = " "
                        End If
                    End If
                    cboxVariable.Items.Add(varCode & " - " & varName)
                Next i
            End If

            '3. Add in a <create new> item
            cboxVariable.Items.Add(m_createNewVar)

            '4. Release resources
            If Not (varDT Is Nothing) Then
                varDT.Dispose()
                varDT = Nothing
            End If
        Catch ex As Exception
            ShowError("An Error occurred while loading the Selectable Variables for the Data Series." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#Region "old code -> changed so now Units,Speciation = Read Only"

    'Private Sub LoadSelVarUnits()
    '	'This function loads the Selectable Variable Units from the Database
    '	'NOTE: cboxVarUnits should already be cleared before calling this function
    '	'Inputs:  None
    '	'Outputs: None
    '	Dim i As Integer 'counter
    '	Dim query As String	'the SQL query used to pull the Units to select from from the database
    '	Dim varUnitsDT As Data.DataTable 'the set of data retrieved from the Database -> values = loaded into cboxVarUnits
    '	Try
    '		'1. get unique Variables from the Data Series Catalog
    '		query = "SELECT DISTINCT " & db_fld_UnitsName & " FROM " & db_tbl_Units & " ORDER BY " & db_fld_UnitsName

    '		varUnitsDT = OpenTable("selVarUnits", query, g_CurrConnSettings)
    '		'validate data
    '		If Not (varUnitsDT Is Nothing) AndAlso varUnitsDT.Rows.Count > 0 Then
    '			'2. load variable units into cboxVarUnits
    '			For i = 0 To varUnitsDT.Rows.Count - 1
    '				If Not (varUnitsDT.Rows(i).Item(db_fld_UnitsName) Is DBNull.Value) Then
    '					cboxVarUnits.Items.Add(varUnitsDT.Rows(i).Item(db_fld_UnitsName))
    '				End If
    '			Next i
    '		End If

    '		'3. Release resources
    '		If Not (varUnitsDT Is Nothing) Then
    '			varUnitsDT.Dispose()
    '			varUnitsDT = Nothing
    '		End If
    '	Catch ex As Exception
    '		ShowError("An Error occurred while loading the Selectable Variable Units for the Data Series." & vbCrLf & "Message = " & ex.Message, ex)
    '	End Try
    'End Sub

    'Private Sub LoadSelSpeciation()
    '	'This function loads the Selectable Variable Speciation from the Database
    '	'NOTE: cboxVarSpeciation should already be cleared before calling this function
    '	'Inputs:  None
    '	'Outputs: None
    '	Dim i As Integer 'counter
    '	Dim query As String	'the SQL query used to pull the Units to select from from the database
    '	Dim speciationDT As Data.DataTable 'the set of data retrieved from the Database -> values = loaded into cboxVarUnits
    '	Try
    '		'1. get unique Variables from the Data Series Catalog
    '		query = "SELECT DISTINCT " & db_fld_CV_Term & " FROM " & db_tbl_SpeciationCV & " ORDER BY " & db_fld_CV_Term

    '		speciationDT = OpenTable("selVarUnits", query, g_CurrConnSettings)
    '		'validate data
    '		If Not (speciationDT Is Nothing) AndAlso speciationDT.Rows.Count > 0 Then
    '			'2. load variable units into cboxVarUnits
    '			For i = 0 To speciationDT.Rows.Count - 1
    '				If Not (speciationDT.Rows(i).Item(db_fld_CV_Term) Is DBNull.Value) Then
    '					cboxVarSpeciation.Items.Add(speciationDT.Rows(i).Item(db_fld_CV_Term))
    '				End If
    '			Next i
    '		End If

    '		'3. Release resources
    '		If Not (speciationDT Is Nothing) Then
    '			speciationDT.Dispose()
    '			speciationDT = Nothing
    '		End If
    '	Catch ex As Exception
    '		ShowError("An Error occurred while loading the Selectable Variable Units for the Data Series." & vbCrLf & "Message = " & ex.Message, ex)
    '	End Try
    'End Sub

#End Region

#End Region

#Region " Auto Generate Functions "

    Private Function AutoGenerateMethodDesc() As String
        'This function generates a predefined method Description when the user selects this option
        'Inputs:  None
        'Outputs: String -> the created Method Description
        Dim methodDesc As String = "" 'the create method description = Return Value -> initialized as blank
        Try
            '1. create a Method Description based on Derive Type
            Select Case True
                Case rbtnCreateDS_QCLevel1.Checked
                    'methodDesc = "Quality Control Level 1 Data Series created from raw QC Level 0 data using ODM Tools."
                    methodDesc = "Quality controlled data series created from raw data using ODM Tools."
                Case rbtnCreateDS_Smoothed.Checked
                    If tboxSmooth_WindowVal.Text <> "" Then
                        methodDesc = "Data Series created using a Smoothing Algorithm in ODM Tools using a Smoothing Window = " & tboxSmooth_WindowVal.Text & " minutes."
                    Else
                        methodDesc = ""
                    End If
                Case rbtnAggregate.Checked
                    Select Case True
                        Case rbtnAgg_Max.Checked
                            methodDesc = "Data Series created using the Maximum Daily Aggregate Function in ODM Tools."
                        Case rbtnAgg_Min.Checked
                            methodDesc = "Data Series created using the Minimum Daily Aggregate Function in ODM Tools."
                        Case rbtnAgg_Avg.Checked
                            methodDesc = "Data Series created using the Average Daily Aggregate Function in ODM Tools."
                        Case Else
                            methodDesc = ""
                    End Select
                Case rbtnAlgebraic.Checked
                    Dim algFound As Boolean = False 'Tracks whether changes have been made to the algebraic equation
                    'put on the beginning
                    methodDesc = "Data Series created using the Algebraic Equation = "
                    'put on the equation -> only put on values <> 0
                    If tboxAlg_A.Text <> 0 Then
                        methodDesc = methodDesc & tboxAlg_A.Text
                    End If
                    If tboxAlg_B.Text <> 0 Then
                        If methodDesc.EndsWith(" = ") Then
                            methodDesc = methodDesc & tboxAlg_B.Text & "x"
                        Else
                            methodDesc = methodDesc & " + " & tboxAlg_B.Text & "x"
                        End If
                        algFound = True
                    End If
                    If tboxAlg_C.Text <> 0 Then
                        If methodDesc.EndsWith(" = ") Then
                            methodDesc = methodDesc & tboxAlg_C.Text & "x^2"
                        Else
                            methodDesc = methodDesc & " + " & tboxAlg_C.Text & "x^2"
                        End If
                        algFound = True
                    End If
                    If tboxAlg_D.Text <> 0 Then
                        If methodDesc.EndsWith(" = ") Then
                            methodDesc = methodDesc & tboxAlg_D.Text & "x^3"
                        Else
                            methodDesc = methodDesc & " + " & tboxAlg_D.Text & "x^3"
                        End If
                        algFound = True
                    End If
                    If tboxAlg_E.Text <> 0 Then
                        If methodDesc.EndsWith(" = ") Then
                            methodDesc = methodDesc & tboxAlg_E.Text & "x^4"
                        Else
                            methodDesc = methodDesc & " + " & tboxAlg_E.Text & "x^4"
                        End If
                        algFound = True
                    End If
                    If tboxAlg_F.Text <> 0 Then
                        If methodDesc.EndsWith(" = ") Then
                            methodDesc = methodDesc & tboxAlg_F.Text & "x^5"
                        Else
                            methodDesc = methodDesc & " + " & tboxAlg_F.Text & "x^5"
                        End If
                        algFound = True
                    End If
                    'make sure something was added for the equation
                    If Not (algFound) Then
                        'reset methodDesc = ""
                        methodDesc = ""
                    Else
                        'tack on the ending
                        methodDesc = methodDesc & " in ODM Tools."
                    End If
                Case Else
                    methodDesc = ""
            End Select

            Return methodDesc
        Catch ex As Exception
            ShowError("An Error occurred while automatically generating the Method Description. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Return ""
    End Function

#End Region

#Region " Initialize/Set Functions "

#Region " Initialize functions "

    Private Sub InitializeMethodDesc()
        'This function clears and intializes the values for the Method Description selection and value
        'Inputs:  None
        'Outputs: None
        Try
            'uncheck everything
            rbtnAutoGenMethodDesc.Checked = False
            rbtnSelectExistingMethodDesc.Checked = False
            rbtnCreateNewMethodDesc.Checked = False
            'reset Variable Method Desc
            tboxVarMethod.Text = ""
        Catch ex As Exception
            ShowError("An Error occurred while initializing the Method Description area." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#Region " Setting Functions "

    Private Sub SetMethodDescEnabled()
        'This function enables/disables Method Description Info,Data Series Attributes Info, and btnDeriveNewDS based on data
        'Inputs:  None
        'Outputs: None
        Dim enableDSAtts As Boolean = False 'tracks if the Data Series Attributes can be enabled or not -> initialized to False
        Try
            '1. enable Method Description Area based on Derive method
            Select Case True
                'Case rbtnCreateDS_QCLevel1.Checked
                '	'disable Method
                '	gboxMethodInfo.Enabled = False
                '	enableDSAtts = True
                Case rbtnCreateDS_Smoothed.Checked, rbtnAggregate.Checked, rbtnAlgebraic.Checked, rbtnCreateDS_QCLevel1.Checked
                    'enable Method Info
                    gboxMethodInfo.Enabled = True
                    If HaveValidMethodDesc() = True Then
                        'enable Data Series Attributes
                        enableDSAtts = True
                    Else
                        'disable Data Series Attributes
                        enableDSAtts = False
                    End If
                Case Else
                    'disable everything
                    gboxMethodInfo.Enabled = False
                    gboxDSAttributes.Enabled = False
                    btnDeriveNewDS.Enabled = False
            End Select

            '2. enable/disable the Data series Attributes
            SetDSAttributesEnabled(enableDSAtts)
        Catch ex As Exception
            ShowError("An Error occurred while setting the Method and Data series Attributes accessibility. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Sub SetDSAttributesEnabled(ByVal enabled As Boolean)
        'This function enables/disables Data Series Attributes Area, and btnDeriveNewDS based on data
        'Inputs:  enabled -> value if should enable(=True) or disable(=False) the Data Series Attributes are
        'Outputs: None
        Try
            '1. Check to see if enabling or disabling
            If enabled = True Then
                'enable Data Series Attributes
                gboxDSAttributes.Enabled = True
                'check to see if can enable the Derive New Data Series Button
                If HaveValidDSAttributes() = True Then
                    'enable btnDeriveNewDS
                    btnDeriveNewDS.Enabled = True
                Else
                    'disable btnDeriveNewDS
                    btnDeriveNewDS.Enabled = False
                End If
            Else
                'disable Data Series Attributes
                gboxDSAttributes.Enabled = False
                'disable btnDeriveNewDS
                btnDeriveNewDS.Enabled = False
            End If
        Catch ex As Exception
            ShowError("An Error occurred while enabling/disabling the Data Series Attributes." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

#End Region

#End Region

#Region " Derive New DS Functions "

    Public Function DeriveNewDataSeries() As Boolean
        'This function creates a new Data series based on Derive Method selected
        'Inputs:  progressBar -> the progress bar from frmProgess to update as creating
        'Outputs: Boolean -> tracks if the new Data Series was successfully created or not
        Dim dsID As Integer = -1 'holds the Data series for the specified parameters -> used to validate if can create a new data series or not
        Dim seriesID As Integer 'holds the SeriesID for the newly created Data Series
        Dim siteID As Integer 'holds the SiteID for the data series to create
        Dim site As String 'string version of the site (Code - Name), used to get infor to update the Series Catalog table for the new Data Series -> value from tboxSite
        Dim siteCode As String 'Site Code of site value, used to update the Series Catalog table for the new Data Series
        Dim siteName As String 'Site Name of site value, used to update the Series Catalog table for the new Data Series
        Dim variable As String 'string version of the variable (Code - Name), used to see if need to create a new Variable in the Data and/or to update the Series Catalog table for the new Data Series -> value from tboxVariable
        Dim varID As Integer 'VariableID for the variable
        Dim varCode As String 'Variable Code of the variable value, used to create/update a new Variable/SeriesCatalog table for the new Data Series
        Dim varName As String 'Variable Name of the variable value, used to create/update a new Variable/SeriesCatalog table for the new Data Series
        Dim speciation As String 'Speciation for the variable value, used to create/update a new Variable/SeriesCatalog table for the new Data Series
        Dim varUnitsID As Integer 'VariableUnitsID for the variable Units -> used to create/update a new Variable/SeriesCatalog table for the new Data Series
        Dim varUnitsName As String 'Variable Units Name for the variable units -> used to get the VariableUnitsID and update the SeriesCatalog table for the new Data Series
        Dim sampleMed As String 'holds the Sample Medium Value -> used to update the SeriesCatalog table for the new Data Series
        Dim valueType As String 'holds the Value Type value -> used to update the SeriesCatalog table for the new Data Series
        'Dim isRegular As Boolean 'holds the IsRegular value of the variable -> used to create a new variable when needed
        Dim timeSupport As Double 'holds the TimeSupport Value -> used to get/create variable info, and also to update the SeriesCatalog table for the new Data Series
        Dim tsUnitsID As Integer 'holds the Time Support Units ID -> used to update the SeriesCatalog table for the new Data Series
        Dim tsUnitsName As String 'holds the Time Support Units Name -> used to update the SeriesCatalog table for the new Data Series
        Dim dataType As String 'holds the Data Type Value -> used to get/create variable info, create new Aggregate values, and update the SeriesCatalog table for the new Data Series
        Dim genCategory As String 'holds the General Category Value -> used to get/create variable info, and SeriesCatalog table for the new Data Series
        Dim noDataValue As Double 'holds the NoDataValue of the variable -> used to create a new variable if needed, and also to generate points for the new Data Series
        Dim methodID As Integer 'holds the MethodID value for the method of the new Data Series -> used to validate if can create a new Data Series, create the new points, and update the SeriesCatalog table for the new Data Series
        Dim methodDesc As String 'holds the MethodDescription value for the method of the new Data Series -> used to get the MethodID value, create a new method if needed, and update the SeriesCatalog table for the new Data Series
        Dim sourceID As Integer 'holds the SourceID value for the new Data Series -> used to validate if can create a new Data Series, create the new points, and update the SeriesCatalog table for the new Data Series
        Dim organization As String 'holds the Organization Value for the source -> used to update the SeriesCatalog table for the new Data Series
        Dim sourceDesc As String  'holds the Source Description Value for the source -> used to update the SeriesCatalog table for the new Data Series
        Dim citation As String 'holds the Citation value for the source -> used to update the Series Catalog table for the new Data Series
        Dim qclevelID As Integer 'holds the QCLevelID for the new Data Series -> used to validate if can create a new Data Series, create the new points, and update the SeriesCatalog table for the new Data Series
        Dim qcLevel As String 'holds the QCLevel info (Code - Definition) for the new Data Series
        Dim qclevel_Code As String 'holds the QCLevel Code for the new Data Series
        Dim qclevel_Def As String 'holds the QCLevel Definition for the new Data Series
        Dim beginDate As DateTime 'holds the LocalBeginDate value for the new Data Series -> used to update the SeriesCatalog table for the new Data Series, this value is calculated when the new points are created
        Dim endDate As DateTime 'holds the LocalEndDate value for the new Data Series -> used to update the SeriesCatalog table for the new Data Series, this value is calculated when the new points are created
        Dim beginDateUTC As DateTime 'holds the UTCBeginDate value for the new Data Series -> used to update the SeriesCatalog table for the new Data Series, this value is calculated when the new points are created
        Dim endDateUTC As DateTime 'holds the UTCEndDate value for the new Data Series -> used to update the SeriesCatalog table for the new Data Series, this value is calculated when the new points are created
        Dim valueCount As Integer 'holds the total number of points for the new Data Series -> used to update the SeriesCatalog table for the new Data Series, this value is calculated when the new points are created
        Dim created As Boolean = False 'tracks if the new points for the new Data Series have been successfully created or not -> initialized to false
        Dim createdNewDS1 As Boolean = False
        Try
            'reset progress bar
            g_FProgress.pbarProgress.Value = 0

            '1. Get all of the Variable Info needed
            variable = cboxVariable.Text
            varCode = Split(variable, " - ")(0)
            varName = Split(variable, " - ")(1)
            'NOTE: changed these to readonly info -> now associated with a unique Variable Code
            'speciation = cboxVarSpeciation.Text
            'varUnitsName = cboxVarUnits.Text
            speciation = tboxVarSpeciation.Text
            varUnitsName = tboxVarUnits.Text
            varUnitsID = GetUnitsIDFromDB(varUnitsName)
            sampleMed = tboxVarSampleMed.Text
            valueType = tboxVarValueType.Text
            timeSupport = CDbl(tboxTSValue.Text)
            tsUnitsName = tboxTSUnits.Text
            tsUnitsID = GetUnitsIDFromDB(tsUnitsName)
            dataType = tboxVarDataType.Text
            genCategory = tboxVarGenCategory.Text
            qcLevel = cboxVarQCLevel.Text
            qclevel_Code = Split(qcLevel, " - ")(0)
            qclevel_Def = Split(qcLevel, " - ")(1)
            'NOTE: just use noDataValue from the Data series deriving from -> shouldn't change
            noDataValue = GetVarNoDataValueFromDB(m_DSFromIDs.VariableID)

            '2. get ID's to validate if can create new Data Series
            varID = GetVariableIDFromDB(varCode, varName, speciation, varUnitsID, sampleMed, valueType, timeSupport, tsUnitsID, dataType, genCategory)
            'make sure have a valid VariableID
            If Not IsNumeric(varID) Then
                'If varID < 0 Then
                'NOTE: due to changes in the DB for ODM1.1 Schema, a duplicate Variable Code cannot be created, so variableID must exist already!!
                'isRegular = GetVarIsRegularFromDB(m_DSFromIDs.VariableID)
                'varID = CreateNewVariableInDB(varCode, varName, speciation, varUnitsID, sampleMed, valueType, timeSupport, tsUnitsID, dataType, genCategory, isRegular, noDataValue)
                'If varID < 0 Then
                '	MsgBox("Unable to create the Variable for this Data Series:  Cannot continue!", MsgBoxStyle.Exclamation)
                '	'return false
                '	Exit Try
                'End If

                'Tell the user to create a new variable/select a valid one
                MsgBox("A Variable with the selected Parameters does not exist yet in the Database!! The new data series cannot be created until an existing variable has been selected or a new variable has been created.  Please select a different variable, or create a new one for the selected parameters.", MsgBoxStyle.Exclamation)
                'Return False
                Exit Try
            End If

            'get rest of IDs
            siteID = m_DSFromIDs.SiteID
            methodDesc = tboxVarMethod.Text
            methodID = GetMethodIDFromDB(methodDesc)
            sourceID = m_DSFromIDs.SourceID
            qclevelID = GetQCLevelIDFromDB(qclevel_Code, qclevel_Def)

            'update progress bar = 5%
            g_FProgress.pbarProgress.Value = 5

            '3. check to see if a Data Series that matches already exists
            If (varID > 0 AndAlso siteID > 0 AndAlso methodID > 0 AndAlso sourceID > 0) Then
                'every ID is valid, check to see a data series already exists for these ID's
                dsID = GetDataSeriesIDFromDB(siteID, varID, methodID, sourceID, qclevelID)
                If dsID > 0 Then
                    'a data series matching info already exists
                    'If qclevelID <> 1 Then
                    MsgBox("Unable to create new Data Series: A Data Series already exists in the database that matches the parameters you have specified." & vbCrLf & "There can only be 1 data series in the database with these parameters.  Please change them and try again.")
                    'Return False
                    Exit Try
                    'Else
                    '	Select Case MsgBox("There can be only one Quality Control Level 1 Data Series derived from a single Quality Control Level 0 Data Series." & vbCrLf & "Press Yes to add only the new values to the database." & vbCrLf & "Press No to overwrite the existing Data Series.", MsgBoxStyle.YesNoCancel)
                    '		Case MsgBoxResult.Yes
                    '			m_CreateNewQCLevel1 = False
                    '		Case MsgBoxResult.No
                    '			m_CreateNewQCLevel1 = True
                    '			If Not DeleteDataSeries(siteID, varID, methodID, sourceID, qclevelID) Then
                    '				ShowError("Unable to delete existing data series.")
                    '				'Return False
                    '				Exit Try
                    '			End If
                    '		Case MsgBoxResult.Cancel
                    '			'Return False
                    '			Exit Try
                    '	End Select
                    'End If
                End If
            End If

            '5. see if need to create a new Method ID
            'validate ID
            If Not IsNumeric(methodID) Then 'no ID was found -> create the Method in the Database
                methodID = CreateNewMethodInDB(methodDesc)
                If Not IsNumeric(methodID) Then
                    MsgBox("Unable to create the Method for this Data Series: Cannot continue!", MsgBoxStyle.Exclamation)
                    'return false
                    Exit Try
                End If
            End If

            'update progressbar = 10%
            g_FProgress.pbarProgress.Value = 10

            '6. Get the new values
            created = False
            Select Case True
                Case rbtnCreateDS_QCLevel1.Checked
                    'Create copy of Values in DB, set dates/valueCount 
                    created = CreateQCLevel1DSValues(siteID, varID, methodID, sourceID, qclevelID, valueCount, beginDate, endDate, beginDateUTC, endDateUTC, createdNewDS1)
                Case rbtnCreateDS_Smoothed.Checked
                    'Create a CreateSmoothedDSValues Function -> pass in Smoothing Method
                    created = CreateSmoothedDSValues(siteID, varID, methodID, sourceID, qclevelID, noDataValue, valueCount, beginDate, endDate, beginDateUTC, endDateUTC)
                    'valueCount = 0
                Case rbtnAggregate.Checked
                    'Create new Values in DB, set dates/valueCount 
                    created = CreateAggregateDSValues(dataType, siteID, varID, methodID, sourceID, qclevelID, noDataValue, valueCount, beginDate, endDate, beginDateUTC, endDateUTC)
                Case rbtnAlgebraic.Checked
                    'Create new Values in DB, set dates/valueCount
                    created = CreateAlgebraicDSValues(CDbl(tboxAlg_A.Text), CDbl(tboxAlg_B.Text), CDbl(tboxAlg_C.Text), CDbl(tboxAlg_D.Text), CDbl(tboxAlg_E.Text), CDbl(tboxAlg_F.Text), siteID, varID, methodID, sourceID, qclevelID, noDataValue, valueCount, beginDate, endDate, beginDateUTC, endDateUTC)
            End Select
            'validate that values were created
            If Not (created) Then
                'show error
                MsgBox("Unable to create the Values for this Data Series: Cannot continue!", MsgBoxStyle.Exclamation)
                'return false
                Exit Try
            End If
            If valueCount = 0 Then
                'show message
                MsgBox("No Values were created for this Data Series:  Cannot continue!", MsgBoxStyle.Exclamation)
                'return false
                Exit Try
            End If

            'update progressbar = 95%
            g_FProgress.pbarProgress.Value = 95

            '7. Create the new Data Series
            'get the Data Series Info
            site = tboxDSSite.Text
            siteCode = Split(site, " - ")(0)
            siteName = Split(site, " - ")(1)
            sourceDesc = tboxSourceDesc.Text
            organization = tboxSourceOrg.Text
            citation = tboxSourceCitation.Text

            '8. Update the Series Catalog Table in the Database, return SeriesID just created
            dsID = GetDataSeriesIDFromDB(siteID, varID, methodID, sourceID, qclevelID)
            If (dsID > 0) Then
                UpdateSeriesCatalogAfterEdits(dsID, beginDate, endDate, beginDateUTC, endDateUTC, valueCount)
            Else
                seriesID = CreateNewDataSeriesInDB(siteID, siteCode, siteName, varID, varCode, varName, speciation, varUnitsID, varUnitsName, sampleMed, valueType, timeSupport, tsUnitsID, tsUnitsName, dataType, genCategory, methodID, methodDesc, sourceID, sourceDesc, organization, citation, qclevelID, qclevel_Code, beginDate, endDate, beginDateUTC, endDateUTC, valueCount)
                'make sure a valid seriesID was found/created
                If seriesID > 0 Then
                    m_NewSeriesID = seriesID
                End If
            End If

            'update progress bar = 100%
            g_FProgress.pbarProgress.Value = 100

            '9. everything worked, return true
            Return True
        Catch ex As Exception
            ShowError("An Error occurred while deriving the the new Data Series. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'errors occurred above, return false
        Return False
    End Function

    Private Function CreateQCLevel1DSValues(ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qcLevelID As Integer, ByRef valueCount As Integer, ByRef beginDate As DateTime, ByRef endDate As DateTime, ByRef beginDateUTC As DateTime, ByRef endDateUTC As DateTime, ByRef createNew As Boolean) As Boolean
        'This function creates the new points for a QC Level1 Data Series
        'Inputs:  siteID -> the siteID for the new Data Series (NOTE: value is stored for each point)
        '         varID -> the variableID for the new Data Series (NOTE: value is stored for each point)
        '         methodID -> the methodID for the new Data Series (NOTE: value is stored for each point)
        '         sourceID -> the sourceID for the new Data Series (NOTE: value is stored for each point)
        '         qcLevelID -> the QCLevelID for the new Data Series (NOTE: value is stored for each point)
        '         valueCount (ByRef) -> the total number of points created, the input value is junk = value is set in this function and returned
        '         beginDate (ByRef) -> the LocalBeginDate of the points created, the input value is junk = value is set in this function and returned
        '         endDate (ByRef) -> the LocalEndDate of the points created, the input value is junk = value is set in this function and returned
        '         beginDateUTC (ByRef) -> the UTCBeginDate of the points created, the input value is junk = value is set in this function and returned
        '         endDateUTC (ByRef) -> the UTCEndDate of the points created, the input value is junk = value is set in this function and returned
        'Outputs: Boolean -> tracks if the new points for the QC Level1 Data Series were created successfully or not
        '         valueCount (ByRef) -> the total number of point created
        '         beginDate (ByRef) -> the LocalDate of the first point
        '         endDate (ByRef) -> the LocalDate of the last point
        '         beginDateUTC (ByRef) -> the UTCDate of the first point
        '         endDateUTC (ByRef) -> the UTCDate of the last point
        Dim i As Integer 'counter
        Dim numCreated As Integer = 0 'tracks the number of points created so far
        Dim numVals As Integer = 0 'holds the number of values retrieved from the Database -> number of values in the Data Series deriving from
        Dim valDT As Data.DataTable 'holds the set of values for the Data Series deriving from
        'use m_EditData instead 

        Dim maxQuery As String 'the sql query to pull the Maximum ValueID value from the Database -> so can start numbering higher than the highest value in the database to avoid duplicates
        'Dim maxDT As Data.DataTable	'the data table that holds the data retrieved from the database using maxQuery
        'Dim addQuery As String 'the sql query used to update the newly created values to the database
        'Dim addDT As Data.DataTable 'the data table (clone of valDT) that holds the newly created values
        'Dim newRow As Data.DataRow 'used to create/add new points (rows) to addDT
        Dim lastID As Integer 'holds the maximum ValueID retrieved from the Database -> used to create the ValueIDs for the new points
        Dim added As Boolean = False 'tracks if the new points were successfully updated to the database or not
        'Dim deriveFromID As Integer	'holds the DerivedFromID for the current point being created
        Dim numVals_percent As Integer

        Try

            'essentially a copy of m_EditTable
            valDT = GetValuesFromDB("FromDSValues", m_DSFromIDs.SiteID, m_DSFromIDs.VariableID, m_DSFromIDs.QCLevelID, m_DSFromIDs.MethodID, m_DSFromIDs.SourceID)
            'validate that have data
            If (valDT Is Nothing) OrElse valDT.Rows.Count <= 0 Then
                'show error message
                MsgBox("Unable to retrieve the values for the Data Series deriving From:  Cannot continue!!  (unable to retrieve values)", MsgBoxStyle.Exclamation)
                'return false
                Exit Try
            End If
            numVals = valDT.Rows.Count
            numVals_percent = CInt(numVals * 0.125)

            ''2. Get the max ValueID value
            ''NOTE: There has to be values to derive from, so there have to be values in valDT = always get ID of last value
            maxQuery = "SELECT MAX(" & db_fld_ValID & ") AS " & db_expr_MaxID & " FROM " & db_tbl_DataValues
            'maxDT = OpenTable("GetMaxValueID", maxQuery, g_CurrConnSettings)

            ''validate data
            'If (maxDT Is Nothing) OrElse maxDT.Rows.Count = 0 OrElse (maxDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
            '    'show error message 
            '    MsgBox("Unable to access the " & db_tbl_DataValues & " Table in the Database:  Cannot continue!!", MsgBoxStyle.Exclamation)
            '    'return false
            '    Exit Try
            'End If
            ''NOTE: There has to be values to derive from, so there has to be a value in maxDT = always get ID of first value
            'lastID = maxDT.Rows(0).Item(db_expr_MaxID)
            lastID = getValue(maxQuery, g_CurrConnSettings)

            '3. Create an empty data table to add values into
            'addDT = valDT.Clone()

            '4. Create the New Values
            'addQuery = "SELECT * FROM " & db_tbl_DataValues & " ORDER BY " & db_fld_ValID
            For i = 0 To numVals - 1
                'newRow = addDT.NewRow()
                valDT.Rows(i).Item(db_fld_ValID) = lastID + (i + 1) 'SqlTypes.SqlInt32.Null
                'valDT.Rows(i).Item(db_fld_ValValue) = valDT.Rows(i).Item(db_fld_ValValue)
                'valDT.Rows(i).Item(db_fld_ValDateTime) = valDT.Rows(i).Item(db_fld_ValDateTime)
                'valDT.Rows(i).Item(db_fld_ValUTCOffset) = valDT.Rows(i).Item(db_fld_ValUTCOffset)
                'valDT.Rows(i).Item(db_fld_ValUTCDateTime) = valDT.Rows(i).Item(db_fld_ValUTCDateTime)
                valDT.Rows(i).Item(db_fld_ValSiteID) = siteID
                valDT.Rows(i).Item(db_fld_ValVarID) = varID
                'valDT.Rows(i).Item(db_fld_ValOffsetValue) = valDT.Rows(i).Item(db_fld_ValOffsetValue)
                'valDT.Rows(i).Item(db_fld_ValOffsetTypeID) = valDT.Rows(i).Item(db_fld_ValOffsetTypeID)
                'valDT.Rows(i).Item(db_fld_ValCensorCode) = valDT.Rows(i).Item(db_fld_ValCensorCode)
                'valDT.Rows(i).Item(db_fld_ValQualifierID) = valDT.Rows(i).Item(db_fld_ValQualifierID)
                valDT.Rows(i).Item(db_fld_ValMethodID) = methodID
                valDT.Rows(i).Item(db_fld_ValSourceID) = sourceID
                'qcLevelID
                valDT.Rows(i).Item(db_fld_ValQCLevel) = qcLevelID
                'NOTE: These values become NULL!!
                '***************************************************
                valDT.Rows(i).Item(db_fld_ValQualifierID) = DBNull.Value
                '***************************************************
                'add it to the dataTable
                'addDT.Rows.Add(newRow)
                numCreated += 1
                If numVals_percent <> 0 AndAlso i Mod numVals_percent = 0 AndAlso i <> 0 Then
                    'update progress bar
                    g_FProgress.pbarProgress.Value += 10 '80 / (numVals / numVals_percent) '10
                    g_FProgress.pbarProgress.Refresh()
                End If
            Next i

            'update to 90%
            g_FProgress.pbarProgress.Value = 90
            g_FProgress.pbarProgress.Refresh()

            '5. Update Database w/ New Values
            'added = added Or UpdateTable(valDT, addQuery, g_CurrConnSettings.ConnectionString)
            added = InsertBulk(db_tbl_DataValues, valDT, g_CurrConnSettings.ConnectionString)
            If Not (added) Then
                'show an error message
                MsgBox("Unable to update the " & db_tbl_DataValues & " Table with the values for the new Data Series:  Cannot Continue!!", MsgBoxStyle.Exclamation)
                'return false
                Exit Try
            End If

            '6. Set Date Return Values
            beginDate = valDT.Rows(0).Item(db_fld_ValDateTime)
            endDate = valDT.Rows(numCreated - 1).Item(db_fld_ValDateTime)
            beginDateUTC = valDT.Rows(0).Item(db_fld_ValUTCDateTime)
            endDateUTC = valDT.Rows(numCreated - 1).Item(db_fld_ValUTCDateTime)

            '7. Release resources
            If Not (valDT Is Nothing) Then
                valDT.Dispose()
                valDT = Nothing
            End If
            'If Not (maxDT Is Nothing) Then
            '    maxDT.Dispose()
            '    maxDT = Nothing
            'End If
            'If Not (addDT Is Nothing) Then
            '    addDT.Dispose()
            '    addDT = Nothing
            'End If
            'If Not (newRow Is Nothing) Then
            '    newRow = Nothing
            'End If

            '8. return number of values created, True -> it worked!!
            valueCount = numCreated
            Return True
        Catch ex As Exception
            ShowError("An Error occurred while creating the Values for the New QC Level 1 Data Series." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (valDT Is Nothing) Then
            valDT.Dispose()
            valDT = Nothing
        End If
        'If Not (maxDT Is Nothing) Then
        '	maxDT.Dispose()
        '	maxDT = Nothing
        'End If
        'If Not (addDT Is Nothing) Then
        '	addDT.Dispose()
        '	addDT = Nothing
        'End If
        'If Not (newRow Is Nothing) Then
        '	newRow = Nothing
        'End If
        'errors occurred above, return 0 -> so looks like nothing was created!!
        valueCount = 0
        'Return False
        Return False
    End Function

    Private Function CreateSmoothedDSValues(ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qcLevelID As Integer, ByVal noDataValue As Double, ByRef valueCount As Integer, ByRef beginDate As DateTime, ByRef endDate As DateTime, ByRef beginDateUTC As DateTime, ByRef endDateUTC As DateTime) As Boolean
        'This function creates the new points for a QC Level1 Data Series
        'Inputs:  siteID -> the siteID for the new Data Series (NOTE: value is stored for each point)
        '         varID -> the variableID for the new Data Series (NOTE: value is stored for each point)
        '         methodID -> the methodID for the new Data Series (NOTE: value is stored for each point)
        '         sourceID -> the sourceID for the new Data Series (NOTE: value is stored for each point)
        '         qcLevelID -> the QCLevelID for the new Data Series (NOTE: value is stored for each point)
        '         noDataValue -> holds the NoDataValue for the new Data Series, used to see if should calculate a new value at the current point or not
        '         valueCount (ByRef) -> the total number of points created, the input value is junk = value is set in this function and returned
        '         beginDate (ByRef) -> the LocalBeginDate of the points created, the input value is junk = value is set in this function and returned
        '         endDate (ByRef) -> the LocalEndDate of the points created, the input value is junk = value is set in this function and returned
        '         beginDateUTC (ByRef) -> the UTCBeginDate of the points created, the input value is junk = value is set in this function and returned
        '         endDateUTC (ByRef) -> the UTCEndDate of the points created, the input value is junk = value is set in this function and returned
        'Outputs: Boolean -> tracks if the new points for the smoothed Data Series were created successfully or not
        '         valueCount (ByRef) -> the total number of point created
        '         beginDate (ByRef) -> the LocalDate of the first point
        '         endDate (ByRef) -> the LocalDate of the last point
        '         beginDateUTC (ByRef) -> the UTCDate of the first point
        '         endDateUTC (ByRef) -> the UTCDate of the last point
        'Dim i As Integer = 0 'counter
        Dim numCreated As Integer = 0 'tracks the number of points created so far
        Dim numVals As Integer = 0 'holds the number of values retrieved from the Database -> number of values in the Data Series deriving from
        Dim valDT As Data.DataTable 'holds the set of values for the Data Series deriving from
        Dim maxQuery As String 'the sql query to pull the Maximum ValueID value from the Database -> so can start numbering higher than the highest value in the database to avoid duplicates
        'Dim maxDT As Data.DataTable	'the data table that holds the data retrieved from the database using maxQuery
        'Dim addQuery As String 'the sql query used to update the newly created values to the database
        'Dim addDT As Data.DataTable 'the data table (clone of valDT) that holds the newly created values
        'Dim newRow As Data.DataRow 'used to create/add new points (rows) to addDT
        Dim lastID As Integer 'holds the maximum ValueID retrieved from the Database -> used to create the ValueIDs for the new points
        Dim added As Boolean = False 'tracks if the new points were successfully updated to the database or not
        'Dim derivedFromID As Integer	'holds the DerivedFromID for the current point being created
        Dim newVal As Double 'the new value for the current point creating
        Dim curVal As Double 'the current value deriving from -> used to see if use no data value or if use new value for new point
        Dim censorCode As String 'holds the NC censor code -> used to create a new point
        Dim lowessY As Double() 'contains the lowess-smoothed method points
        Dim numVals_percent As Integer
        Try
            '1. Get the Data from the Database for the Data Series deriving from
            valDT = GetValuesFromDB("FromDSValues", m_DSFromIDs.SiteID, m_DSFromIDs.VariableID, m_DSFromIDs.QCLevelID, m_DSFromIDs.MethodID, m_DSFromIDs.SourceID)
            'validate that have data
            If (valDT Is Nothing) OrElse valDT.Rows.Count <= 0 Then
                'show error message
                MsgBox("Unable to retrieve the values for the Data Series deriving From:  Cannot continue!!  (unable to retrieve values)", MsgBoxStyle.Exclamation)
                'return False
                Exit Try
            End If
            numVals = valDT.Rows.Count
            numVals_percent = CInt(numVals * 0.125)

            '2. Get the max ValueID value
            'NOTE: There has to be values to derive from, so there have to be values in valDT = always get ID of last value
            maxQuery = "SELECT MAX(" & db_fld_ValID & ") AS " & db_expr_MaxID & " FROM " & db_tbl_DataValues
            'maxDT = OpenTable("GetMaxValueID", maxQuery, g_CurrConnSettings)
            ''validate data
            'If (maxDT Is Nothing) OrElse maxDT.Rows.Count = 0 OrElse (maxDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
            '	'show error message 
            '	MsgBox("Unable to access the " & db_tbl_DataValues & " Table in the Database:  Cannot continue!!", MsgBoxStyle.Exclamation)
            '	'return false
            '	Exit Try
            'End If
            ''NOTE: There has to be values to derive from, so there has to be a value in maxDT = always get ID of first value
            'lastID = maxDT.Rows(0).Item(db_expr_MaxID)

            lastID = getValue(maxQuery, g_CurrConnSettings)

            '3. Create an empty data table to add values into
            'addDT = valDT.Clone()

            '4. Get the new smoothed Values
            'NOTE: For now just using the LOWESS method
            lowessY = Smooth_LOWESS(numVals, valDT)
            If lowessY Is Nothing Then
                'no values were created, return false (NOTE: an error message is show later, so don't need a duplicate!!)
                Exit Try
            End If

            '5. Create the New Values
            censorCode = db_val_CCCVTerm_NULL
            For i As Integer = 0 To numVals - 1
                'get the current value (one to derive from)
                curVal = valDT.Rows(i).Item(db_fld_ValValue)

                'Calculate new value
                If curVal <> noDataValue Then
                    newVal = lowessY(numCreated)
                Else
                    newVal = noDataValue
                End If

                'create the new point
                'newRow = addDT.NewRow()                
                valDT.Rows(i).Item(db_fld_ValID) = lastID + (i + 1)
                valDT.Rows(i).Item(db_fld_ValValue) = newVal
                'newRow.Item(db_fld_ValDateTime) = valDT.Rows(i).Item(db_fld_ValDateTime)
                'newRow.Item(db_fld_ValUTCOffset) = valDT.Rows(i).Item(db_fld_ValUTCOffset)
                'newRow.Item(db_fld_ValUTCDateTime) = valDT.Rows(i).Item(db_fld_ValUTCDateTime)
                valDT.Rows(i).Item(db_fld_ValSiteID) = siteID
                valDT.Rows(i).Item(db_fld_ValVarID) = varID
                'newRow.Item(db_fld_ValOffsetValue) = valDT.Rows(i).Item(db_fld_ValOffsetValue)
                'newRow.Item(db_fld_ValOffsetTypeID) = valDT.Rows(i).Item(db_fld_ValOffsetTypeID)
                valDT.Rows(i).Item(db_fld_ValCensorCode) = censorCode 'NOTE: This value is set to 'nd' = not detected
                'NOTE: These values become NULL!!
                '***************************************************
                valDT.Rows(i).Item(db_fld_ValQualifierID) = DBNull.Value
                '***************************************************
                valDT.Rows(i).Item(db_fld_ValMethodID) = methodID
                valDT.Rows(i).Item(db_fld_ValSourceID) = sourceID

                valDT.Rows(i).Item(db_fld_ValQCLevel) = qcLevelID
                'add it to the dataTable
                'addDT.Rows.Add(newRow)
                numCreated += 1

                If i Mod numVals_percent = 0 AndAlso i <> 0 Then
                    'update progress bar
                    g_FProgress.pbarProgress.Value += 5
                    g_FProgress.pbarProgress.Refresh()
                End If
            Next i

            'update to 90%
            g_FProgress.pbarProgress.Value = 90
            g_FProgress.pbarProgress.Refresh()

            '5. Update Database w/ New Values
            added = InsertBulk(db_tbl_DataValues, valDT, g_CurrConnSettings.ConnectionString)
            'addQuery = "SELECT * FROM " & db_tbl_DataValues & " ORDER BY " & db_fld_ValID
            'added = UpdateTable(addDT, addQuery, g_CurrConnSettings.ConnectionString)
            If Not (added) Then
                'show an error message
                MsgBox("Unable to update the " & db_tbl_DataValues & " Table with the values for the new Data Series:  Cannot Continue!!", MsgBoxStyle.Exclamation)
                'return False
                Exit Try
            End If

            '6. Set Date Return Values

            beginDate = valDT.Rows(0).Item(db_fld_ValDateTime)
            endDate = valDT.Rows(numCreated - 1).Item(db_fld_ValDateTime)
            beginDateUTC = valDT.Rows(0).Item(db_fld_ValUTCDateTime)
            endDateUTC = valDT.Rows(numCreated - 1).Item(db_fld_ValUTCDateTime)
            'beginDate = addDT.Rows(0).Item(db_fld_ValDateTime)
            'endDate = addDT.Rows(numCreated - 1).Item(db_fld_ValDateTime)
            'beginDateUTC = addDT.Rows(0).Item(db_fld_ValUTCDateTime)
            'endDateUTC = addDT.Rows(numCreated - 1).Item(db_fld_ValUTCDateTime)

            '7. Release resources
            If Not (valDT Is Nothing) Then
                valDT.Dispose()
                valDT = Nothing
            End If
            'If Not (maxDT Is Nothing) Then
            '	maxDT.Dispose()
            '	maxDT = Nothing
            'End If
            'If Not (addDT Is Nothing) Then
            '    addDT.Dispose()
            '    addDT = Nothing
            'End If
            'If Not (newRow Is Nothing) Then
            '    newRow = Nothing
            'End If

            '8. return number of values created, True -> everything worked!!
            valueCount = numCreated
            Return True
        Catch ex As Exception
            ShowError("An Error occurred while creating the Smoothed Values for New Data Series." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (valDT Is Nothing) Then
            valDT.Dispose()
            valDT = Nothing
        End If
        'If Not (maxDT Is Nothing) Then
        '	maxDT.Dispose()
        '	maxDT = Nothing
        'End If
        'If Not (addDT Is Nothing) Then
        '    addDT.Dispose()
        '    addDT = Nothing
        'End If
        'If Not (newRow Is Nothing) Then
        '    newRow = Nothing
        'End If
        'errors occurred above, return 0 -> so looks like nothing was created!!
        valueCount = 0
        Return False
    End Function
    Private Function CreateAggregateDSValues(ByVal aggMethod As String, ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qcLevelID As Integer, ByVal noDataValue As Double, ByRef valueCount As Integer, ByRef beginDate As DateTime, ByRef endDate As DateTime, ByRef beginDateUTC As DateTime, ByRef endDateUTC As DateTime) As Boolean
        'This function creates the new points for a QC Level1 Data Series
        'Inputs:  aggMethod -> the aggregate method to use to derive the new data series (max,min, or avg) 
        '         siteID -> the siteID for the new Data Series (NOTE: value is stored for each point)
        '         varID -> the variableID for the new Data Series (NOTE: value is stored for each point)
        '         methodID -> the methodID for the new Data Series (NOTE: value is stored for each point)
        '         sourceID -> the sourceID for the new Data Series (NOTE: value is stored for each point)
        '         qcLevelID -> the QCLevelID for the new Data Series (NOTE: value is stored for each point)
        '         noDataValue -> holds the NoDataValue for the new Data Series, used to see if should calculate a new value at the current point or not
        '         valueCount (ByRef) -> the total number of points created, the input value is junk = value is set in this function and returned
        '         beginDate (ByRef) -> the LocalBeginDate of the points created, the input value is junk = value is set in this function and returned
        '         endDate (ByRef) -> the LocalEndDate of the points created, the input value is junk = value is set in this function and returned
        '         beginDateUTC (ByRef) -> the UTCBeginDate of the points created, the input value is junk = value is set in this function and returned
        '         endDateUTC (ByRef) -> the UTCEndDate of the points created, the input value is junk = value is set in this function and returned
        'Outputs: Boolean -> tracks if the new points for the derived Data Series were created successfully or not
        '         valueCount (ByRef) -> the total number of point created
        '         beginDate (ByRef) -> the LocalDate of the first point
        '         endDate (ByRef) -> the LocalDate of the last point
        '         beginDateUTC (ByRef) -> the UTCDate of the first point
        '         endDateUTC (ByRef) -> the UTCDate of the last point
        Dim i As Integer 'counter
        Dim numCreated As Integer = 0 'tracks the number of points created so far
        Dim numVals As Integer = 0 'holds the number of values retrieved from the Database -> number of values in the Data Series deriving from
        Dim valDT As Data.DataTable 'holds the set of values for the Data Series deriving from
        Dim maxQuery As String 'the sql query to pull the Maximum ValueID value from the Database -> so can start numbering higher than the highest value in the database to avoid duplicates
        'Dim maxDT As Data.DataTable	'the data table that holds the data retrieved from the database using maxQuery
        'Dim addQuery As String 'the sql query used to update the newly created values to the database
        Dim addDT As Data.DataTable 'the data table (clone of valDT) that holds the newly created values
        Dim newRow As Data.DataRow 'used to create/add new points (rows) to addDT
        Dim lastID As Integer 'holds the maximum ValueID retrieved from the Database -> used to create the ValueIDs for the new points
        Dim added As Boolean = False 'tracks if the new points were successfully updated to the database or not
        'Dim derivedFromID As Integer	'holds the DerivedFromID for the current point being created
        'Dim newVal As Object 'the computed aggregate value to be input for the current point being created
        Dim curDate As DateTime 'the date value for the current point being created
        'Dim year As Integer	'the year value of curDate -> used to calculate newVal value
        'Dim month As Integer 'the month value of curDate -> used to calculate newVal value
        ''Dim day As Integer 'the day value of curDate -> used to calculate newVal value
        'Dim utcOffset As Integer 'the utcOffset for the Data Series deriving from -> used to calculate the new UTC Date Time (because new local date = 12:00:00 AM on the day
        'Dim utcDate As DateTime 'the newly calculate UTC Date for the current point being created
        'Dim offsetValue As Object 'holds the offsetValue of the first value of the group of values that is used to calculate the new value for the current point being created
        'Dim offsetTypeID As Object 'holds the ofsetTypeID of the first value of the group of values that is used to claculate the new value for the current point being created
        Dim censorCode As String 'holds the NC censor code -> used to create a new point
        'Dim selRows As Data.DataRow() 'the group of rows used to calculate the new value for the current point being created
        Dim firstDate As DateTime 'the LocalDateTime value of the first point from the Data Series deriving from
        Dim lastDate As DateTime 'the LocalDateTime value of the last point from the Data Series deriving from
        Dim numVals_percent As Integer
        Try
            '1. Get the Data from the Database for the Data Series deriving from
            valDT = GetValuesFromDB("FromDSValues", m_DSFromIDs.SiteID, m_DSFromIDs.VariableID, m_DSFromIDs.QCLevelID, m_DSFromIDs.MethodID, m_DSFromIDs.SourceID)
            'validate that have data
            If (valDT Is Nothing) OrElse valDT.Rows.Count <= 0 Then
                'show error message
                MsgBox("Unable to retrieve the values for the Data Series deriving From:  Cannot continue!!  (unable to retrieve values)", MsgBoxStyle.Exclamation)
                'return False
                Exit Try
            End If
            numVals = valDT.Rows.Count


            '2. Get the max ValueID value
            'NOTE: There has to be values to derive from, so there have to be values in valDT = always get ID of last value
            maxQuery = "SELECT MAX(" & db_fld_ValID & ") AS " & db_expr_MaxID & " FROM " & db_tbl_DataValues
            'maxDT = OpenTable("GetMaxValueID", maxQuery, g_CurrConnSettings)
            ''validate data
            'If (maxDT Is Nothing) OrElse maxDT.Rows.Count = 0 OrElse (maxDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
            '	'show error message 
            '	MsgBox("Unable to access the " & db_tbl_DataValues & " Table in the Database:  Cannot continue!!", MsgBoxStyle.Exclamation)
            '	'return false
            '	Exit Try
            'End If
            ''NOTE: There has to be values to derive from, so there has to be a value in maxDT = always get ID of first value
            'lastID = maxDT.Rows(0).Item(db_expr_MaxID)
            lastID = getValue(maxQuery, g_CurrConnSettings)

            '3. Create an empty data table to add values into
            addDT = valDT.Clone()

            '4. Create the New Values
            censorCode = db_val_CCCVTerm_NULL
            firstDate = valDT.Rows(0).Item(db_fld_ValDateTime)
            lastDate = valDT.Rows(numVals - 1).Item(db_fld_ValDateTime)
            curDate = New DateTime(firstDate.Year, firstDate.Month, firstDate.Day)
            i = 0
            numVals_percent = CInt((lastDate.Subtract(firstDate).Days) * 0.2)
            'While curDate <= lastDate
            '    'get the Date qualifiers
            '    'year = curDate.Year
            '    'month = curDate.Month
            '    'day = curDate.Day
            '    'get the aggregated value
            '    Dim dateFilter As String = "LocalDateTime >='" & curDate.ToString() & "' AND LocalDateTime <'" & curDate.AddDays(1).ToString() & "'"

            Dim querytable As Object

            Dim valDT2 As IEnumerable(Of DataRow) = New VBEnumerator.EnumerableDataRows(Of DataRow)(valDT.Rows)
            Select Case aggMethod
                Case db_val_DTCVTerm_Maximum
                    querytable = _
                           From series In valDT2 _
                           Where series.Item("DataValue") <> noDataValue _
                           Group series By series.Item("LocalDateTime").Day, series.Item("LocalDateTime").Month, series.Item("LocalDateTime").Year _
                           Into Max(CType(series.Item("DataValue"), Double)), Group
                Case db_val_DTCVTerm_Minimum
                    querytable = _
                        From series In valDT2 _
                           Where series.Item("DataValue") <> noDataValue _
                           Group series By series.Item("LocalDateTime").Day, series.Item("LocalDateTime").Month, series.Item("LocalDateTime").Year _
                           Into Min(CType(series.Item("DataValue"), Double)), Group
                Case db_val_DTCVTerm_Average
                    querytable = _
                           From series In valDT2 _
                           Where series.Item("DataValue") <> noDataValue _
                           Group series By series.Item("LocalDateTime").Day, series.Item("LocalDateTime").Month, series.Item("LocalDateTime").Year _
                           Into Average(CType(series.Item("DataValue"), Double)), Group
            End Select


            ''addDT = querytable.CopyToDataTable()
            'Select Case aggMethod
            '    Case db_val_DTCVTerm_Maximum
            '        newVal = valDT.Compute("Max(" & db_fld_ValValue & ")", dateFilter & " AND " & db_fld_ValValue & " <> " & noDataValue)
            '        'newVal = valDT.Compute("Max(" & db_fld_ValValue & ")", db_outFld_ValDTYear & " = " & year & " AND " & db_outFld_ValDTMonth & " = " & month & " AND " & db_outFld_ValDTDay & " = " & day & " AND " & db_fld_ValValue & " <> " & noDataValue)
            '    Case db_val_DTCVTerm_Minimum
            '        newVal = valDT.Compute("Min(" & db_fld_ValValue & ")", dateFilter & " AND " & db_fld_ValValue & " <> " & noDataValue)
            '        ' newVal = valDT.Compute("Min(" & db_fld_ValValue & ")", db_outFld_ValDTYear & " = " & year & " AND " & db_outFld_ValDTMonth & " = " & month & " AND " & db_outFld_ValDTDay & " = " & day & " AND " & db_fld_ValValue & " <> " & noDataValue)
            '    Case db_val_DTCVTerm_Average
            '        newVal = valDT.Compute("Avg(" & db_fld_ValValue & ")", dateFilter & " AND " & db_fld_ValValue & " <> " & noDataValue)
            '        'newVal = valDT.Compute("Avg(" & db_fld_ValValue & ")", db_outFld_ValDTYear & " = " & year & " AND " & db_outFld_ValDTMonth & " = " & month & " AND " & db_outFld_ValDTDay & " = " & day & " AND " & db_fld_ValValue & " <> " & noDataValue)
            'End Select
            ''get the values that come from data series deriving from
            ''selRows = valDT.Select(db_outFld_ValDTYear & " = " & year & " AND " & db_outFld_ValDTMonth & " = " & month & " AND " & db_outFld_ValDTDay & " = " & day, db_fld_ValDateTime)
            'selRows = valDT.Select(dateFilter, db_fld_ValDateTime)

            ''see if there is any data for this date, if not -> go to next date
            'If selRows.Length > 0 Then
            '    utcOffset = selRows(0).Item(db_fld_ValUTCOffset)
            '    utcDate = curDate.AddHours(-utcOffset) 'this subtracts the utcOffset -> UTCDate = LocalDate - UTCOffset
            '    offsetValue = selRows(0).Item(db_fld_ValOffsetValue)
            '    offsetTypeID = selRows(0).Item(db_fld_ValOffsetTypeID)

            '    'create the new point
            '    newRow = addDT.NewRow()
            '    newRow.Item(db_fld_ValID) = lastID + (i + 1)
            '    If (newVal Is DBNull.Value) Then
            '        newRow.Item(db_fld_ValValue) = noDataValue
            '    Else
            '        newRow.Item(db_fld_ValValue) = CDbl(newVal)
            '    End If
            '    newRow.Item(db_fld_ValDateTime) = FormatDateForInsertIntoDB(curDate)
            '    newRow.Item(db_fld_ValUTCOffset) = utcOffset
            '    newRow.Item(db_fld_ValUTCDateTime) = FormatDateForInsertIntoDB(utcDate)
            '    newRow.Item(db_fld_ValSiteID) = siteID
            '    newRow.Item(db_fld_ValVarID) = varID
            '    newRow.Item(db_fld_ValOffsetValue) = offsetValue
            '    newRow.Item(db_fld_ValOffsetTypeID) = offsetTypeID
            '    newRow.Item(db_fld_ValCensorCode) = censorCode
            '    'NOTE: These values become NULL!!
            '    '***************************************************
            '    'newRow.Item(db_fld_ValQualifierID) = qualifierID
            '    '***************************************************
            '    newRow.Item(db_fld_ValMethodID) = methodID
            '    newRow.Item(db_fld_ValSourceID) = sourceID
            '    newRow.Item(db_fld_ValQCLevel) = qcLevelID
            '    'add it to the dataTable
            '    addDT.Rows.Add(newRow)
            '    numCreated += 1
            '    i += 1
            'End If
            'If lastDate.Subtract(curDate).Days Mod numVals_percent = 0 AndAlso i <> 0 Then
            '    'update progress bar
            '    g_FProgress.pbarProgress.Value += 10
            '    g_FProgress.pbarProgress.Refresh()
            'End If


            'go to the next date
            '    curDate = curDate.AddDays(1)
            'End While

            For Each Rows As Object In querytable
                Dim result As DataRow = Rows.Group(0)
                ' Dim printed As String = String.Format("{0}, {1}, {2},{3}, {4}, {5},{6}, {7}, {8},{9}, {10}, {11}, {12}", Rows.Max, result.Item(1), result.Item(2), result.Item(3), result.Item(4), result.Item(5), result.Item(6), result.Item(7), result.Item(8), result.Item(9), result.Item(10), result.Item(11), result.Item(12))
                ' MsgBox(printed, MsgBoxStyle.Information, "Current Row")

                result.Item(db_fld_ValID) = lastID + (i + 1)

                Select Case aggMethod
                    Case db_val_DTCVTerm_Maximum
                        If (Rows.Max Is DBNull.Value) Then
                            result.Item(db_fld_ValValue) = noDataValue
                        Else
                            result.Item(db_fld_ValValue) = CDbl(Rows.Max)
                        End If
                    Case db_val_DTCVTerm_Minimum
                        If (Rows.Min Is DBNull.Value) Then
                            result.Item(db_fld_ValValue) = noDataValue
                        Else
                            result.Item(db_fld_ValValue) = CDbl(Rows.Min)
                        End If
                    Case db_val_DTCVTerm_Average
                        If (Rows.Average Is DBNull.Value) Then
                            result.Item(db_fld_ValValue) = noDataValue
                        Else
                            result.Item(db_fld_ValValue) = CDbl(Rows.Average)
                        End If
                End Select
                result.Item(db_fld_MethID) = methodID
                result.Item(db_fld_ValSiteID) = siteID
                result.Item(db_fld_ValVarID) = varID
                result.Item(db_fld_ValCensorCode) = censorCode
                result.Item(db_fld_ValSourceID) = sourceID
                result.Item(db_fld_ValQCLevel) = qcLevelID
                'NOTE: These values become NULL!!
                '***************************************************
                result.Item(db_fld_ValQualifierID) = DBNull.Value
                '***************************************************
                'add it to the dataTable
                If lastDate.Subtract(result.Item("LocalDateTime")).Days Mod numVals_percent = 0 AndAlso i <> 0 Then
                    'update progress bar
                    g_FProgress.pbarProgress.Value += 10
                    g_FProgress.pbarProgress.Refresh()
                End If

                addDT.ImportRow(result)
                numCreated += 1
                i += 1
            Next

            'update to 90%
            g_FProgress.pbarProgress.Value = 90
            g_FProgress.pbarProgress.Refresh()

            '5. Update Database w/ New Values
            added = InsertBulk(db_tbl_DataValues, addDT, g_CurrConnSettings.ConnectionString)
            'addQuery = "SELECT * FROM " & db_tbl_DataValues & " ORDER BY " & db_fld_ValID
            'added = UpdateTable(addDT, addQuery, g_CurrConnSettings.ConnectionString)
            If Not (added) Then
                'show an error message
                MsgBox("Unable to update the " & db_tbl_DataValues & " Table with the values for the new Data Series:  Cannot Continue!!", MsgBoxStyle.Exclamation)
                'return False
                Exit Try
            End If

            '6. Set Date Return Values
            beginDate = addDT.Rows(0).Item(db_fld_ValDateTime)
            endDate = addDT.Rows(numCreated - 1).Item(db_fld_ValDateTime)
            beginDateUTC = addDT.Rows(0).Item(db_fld_ValUTCDateTime)
            endDateUTC = addDT.Rows(numCreated - 1).Item(db_fld_ValUTCDateTime)

            '7. Release resources
            If Not (valDT Is Nothing) Then
                valDT.Dispose()
                valDT = Nothing
            End If
            'If Not (maxDT Is Nothing) Then
            '	maxDT.Dispose()
            '	maxDT = Nothing
            'End If
            If Not (addDT Is Nothing) Then
                addDT.Dispose()
                addDT = Nothing
            End If
            If Not (newRow Is Nothing) Then
                newRow = Nothing
            End If

            '8. return number of values created, True -> everything worked!!
            valueCount = numCreated
            Return True
        Catch ex As Exception
            ShowError("An Error occurred while creating the Values for the New Aggregate Data Series." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (valDT Is Nothing) Then
            valDT.Dispose()
            valDT = Nothing
        End If
        'If Not (maxDT Is Nothing) Then
        '	maxDT.Dispose()
        '	maxDT = Nothing
        'End If
        If Not (addDT Is Nothing) Then
            addDT.Dispose()
            addDT = Nothing
        End If
        If Not (newRow Is Nothing) Then
            newRow = Nothing
        End If
        'errors occurred above, return 0 -> so looks like nothing was created!!
        valueCount = 0
        Return False
    End Function
    ''Version for 2010*****************************
    'Private Function CreateAggregateDSValues(ByVal aggMethod As String, ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qcLevelID As Integer, ByVal noDataValue As Double, ByRef valueCount As Integer, ByRef beginDate As DateTime, ByRef endDate As DateTime, ByRef beginDateUTC As DateTime, ByRef endDateUTC As DateTime) As Boolean
    '    'This function creates the new points for a QC Level1 Data Series
    '    'Inputs:  aggMethod -> the aggregate method to use to derive the new data series (max,min, or avg) 
    '    '         siteID -> the siteID for the new Data Series (NOTE: value is stored for each point)
    '    '         varID -> the variableID for the new Data Series (NOTE: value is stored for each point)
    '    '         methodID -> the methodID for the new Data Series (NOTE: value is stored for each point)
    '    '         sourceID -> the sourceID for the new Data Series (NOTE: value is stored for each point)
    '    '         qcLevelID -> the QCLevelID for the new Data Series (NOTE: value is stored for each point)
    '    '         noDataValue -> holds the NoDataValue for the new Data Series, used to see if should calculate a new value at the current point or not
    '    '         valueCount (ByRef) -> the total number of points created, the input value is junk = value is set in this function and returned
    '    '         beginDate (ByRef) -> the LocalBeginDate of the points created, the input value is junk = value is set in this function and returned
    '    '         endDate (ByRef) -> the LocalEndDate of the points created, the input value is junk = value is set in this function and returned
    '    '         beginDateUTC (ByRef) -> the UTCBeginDate of the points created, the input value is junk = value is set in this function and returned
    '    '         endDateUTC (ByRef) -> the UTCEndDate of the points created, the input value is junk = value is set in this function and returned
    '    'Outputs: Boolean -> tracks if the new points for the derived Data Series were created successfully or not
    '    '         valueCount (ByRef) -> the total number of point created
    '    '         beginDate (ByRef) -> the LocalDate of the first point
    '    '         endDate (ByRef) -> the LocalDate of the last point
    '    '         beginDateUTC (ByRef) -> the UTCDate of the first point
    '    '         endDateUTC (ByRef) -> the UTCDate of the last point
    '    Dim i As Integer 'counter
    '    Dim numCreated As Integer = 0 'tracks the number of points created so far
    '    Dim numVals As Integer = 0 'holds the number of values retrieved from the Database -> number of values in the Data Series deriving from
    '    Dim valDT As Data.DataTable 'holds the set of values for the Data Series deriving from
    '    Dim maxQuery As String 'the sql query to pull the Maximum ValueID value from the Database -> so can start numbering higher than the highest value in the database to avoid duplicates
    '    Dim addDT As Data.DataTable 'the data table (clone of valDT) that holds the newly created values
    '    Dim lastID As Integer 'holds the maximum ValueID retrieved from the Database -> used to create the ValueIDs for the new points
    '    Dim added As Boolean = False 'tracks if the new points were successfully updated to the database or not
    '    Dim curDate As DateTime 'the date value for the current point being created
    '    Dim censorCode As String 'holds the NC censor code -> used to create a new point
    '    Dim firstDate As DateTime 'the LocalDateTime value of the first point from the Data Series deriving from
    '    Dim lastDate As DateTime 'the LocalDateTime value of the last point from the Data Series deriving from
    '    Dim numVals_percent As Integer
    '    Try
    '        '1. Get the Data from the Database for the Data Series deriving from
    '        valDT = GetValuesFromDB("FromDSValues", m_DSFromIDs.SiteID, m_DSFromIDs.VariableID, m_DSFromIDs.QCLevelID, m_DSFromIDs.MethodID, m_DSFromIDs.SourceID)
    '        'validate that have data
    '        If (valDT Is Nothing) OrElse valDT.Rows.Count <= 0 Then
    '            'show error message
    '            MsgBox("Unable to retrieve the values for the Data Series deriving From:  Cannot continue!!  (unable to retrieve values)", MsgBoxStyle.Exclamation)
    '            'return False
    '            Exit Try
    '        End If
    '        numVals = valDT.Rows.Count

    '        '2. Get the max ValueID value
    '        'NOTE: There has to be values to derive from, so there have to be values in valDT = always get ID of last value
    '        maxQuery = "SELECT MAX(" & db_fld_ValID & ") AS " & db_expr_MaxID & " FROM " & db_tbl_DataValues
    '        lastID = getValue(maxQuery, g_CurrConnSettings)

    '        '3. Create an empty data table to add values into
    '        addDT = valDT.Clone()

    '        '4. Create the New Values
    '        censorCode = db_val_CCCVTerm_NULL
    '        firstDate = valDT.Rows(0).Item(db_fld_ValDateTime)
    '        lastDate = valDT.Rows(numVals - 1).Item(db_fld_ValDateTime)
    '        'curDate = New DateTime(firstDate.Year, firstDate.Month, firstDate.Day)
    '        i = 0
    '        numVals_percent = CInt((lastDate.Subtract(firstDate).Days) * 0.2)

    '        Dim dateFilter As String = "LocalDateTime >='" & curDate.ToString() & "' AND LocalDateTime <'" & curDate.AddDays(1).ToString() & "'"
    '        Dim querytable As Object

    '        Select Case aggMethod
    '            Case db_val_DTCVTerm_Maximum
    '                querytable = _
    '                       From series In valDT.AsEnumerable _
    '                       Where series.Field(Of Double)("DataValue") <> noDataValue _
    '                       Group series By series.Field(Of DateTime)("LocalDateTime").Day, series.Field(Of DateTime)("LocalDateTime").Month, series.Field(Of DateTime)("LocalDateTime").Year _
    '                       Into Max(series.Field(Of Double)("DataValue")), Group
    '            Case db_val_DTCVTerm_Minimum
    '                querytable = _
    '                    From series In valDT.AsEnumerable _
    '                       Where series.Field(Of Double)("DataValue") <> noDataValue _
    '                       Group series By series.Field(Of DateTime)("LocalDateTime").Day, series.Field(Of DateTime)("LocalDateTime").Month, series.Field(Of DateTime)("LocalDateTime").Year _
    '                       Into Min(series.Field(Of Double)("DataValue")), Group
    '            Case db_val_DTCVTerm_Average
    '                querytable = _
    '                        From series In valDT.AsEnumerable _
    '                       Where series.Field(Of Double)("DataValue") <> noDataValue _
    '                       Group series By series.Field(Of DateTime)("LocalDateTime").Day, series.Field(Of DateTime)("LocalDateTime").Month, series.Field(Of DateTime)("LocalDateTime").Year _
    '                       Into Average(series.Field(Of Double)("DataValue")), Group
    '        End Select

    '        For Each Rows As Object In querytable
    '            Dim result As DataRow = Rows.Group(0)
    '            ' Dim printed As String = String.Format("{0}, {1}, {2},{3}, {4}, {5},{6}, {7}, {8},{9}, {10}, {11}, {12}", Rows.Max, result.Item(1), result.Item(2), result.Item(3), result.Item(4), result.Item(5), result.Item(6), result.Item(7), result.Item(8), result.Item(9), result.Item(10), result.Item(11), result.Item(12))
    '            ' MsgBox(printed, MsgBoxStyle.Information, "Current Row")

    '            result.Item(db_fld_ValID) = lastID + (i + 1)

    '            Select Case aggMethod
    '                Case db_val_DTCVTerm_Maximum
    '                    If (Rows.Max Is DBNull.Value) Then
    '                        result.Item(db_fld_ValValue) = noDataValue
    '                    Else
    '                        result.Item(db_fld_ValValue) = CDbl(Rows.Max)
    '                    End If
    '                Case db_val_DTCVTerm_Minimum
    '                    If (Rows.Min Is DBNull.Value) Then
    '                        result.Item(db_fld_ValValue) = noDataValue
    '                    Else
    '                        result.Item(db_fld_ValValue) = CDbl(Rows.Min)
    '                    End If
    '                Case db_val_DTCVTerm_Average
    '                    If (Rows.Average Is DBNull.Value) Then
    '                        result.Item(db_fld_ValValue) = noDataValue
    '                    Else
    '                        result.Item(db_fld_ValValue) = CDbl(Rows.Average)
    '                    End If
    '            End Select
    '            result.Item(db_fld_MethID) = methodID
    '            result.Item(db_fld_ValSiteID) = siteID
    '            result.Item(db_fld_ValVarID) = varID
    '            result.Item(db_fld_ValCensorCode) = censorCode
    '            result.Item(db_fld_ValSourceID) = sourceID
    '            result.Item(db_fld_ValQCLevel) = qcLevelID
    'NOTE: These values become NULL!!
    '***************************************************
    '           result.Item(db_fld_ValQualifierID) = DBNull.Value
    '***************************************************
    '            'add it to the dataTable
    '            If lastDate.Subtract(result.Item("LocalDateTime")).Days Mod numVals_percent = 0 AndAlso i <> 0 Then
    '                'update progress bar
    '                g_FProgress.pbarProgress.Value += 10
    '                g_FProgress.pbarProgress.Refresh()
    '            End If

    '            addDT.ImportRow(result)
    '            numCreated += 1
    '            i += 1
    '        Next
    '        'update to 90%
    '        g_FProgress.pbarProgress.Value = 90
    '        g_FProgress.pbarProgress.Refresh()

    '        '5. Update Database w/ New Values
    '        added = InsertBulk(db_tbl_DataValues, addDT, g_CurrConnSettings.ConnectionString)

    '        If Not (added) Then
    '            'show an error message
    '            MsgBox("Unable to update the " & db_tbl_DataValues & " Table with the values for the new Data Series:  Cannot Continue!!", MsgBoxStyle.Exclamation)
    '            'return False
    '            Exit Try
    '        End If

    '        '6. Set Date Return Values
    '        beginDate = addDT.Rows(0).Item(db_fld_ValDateTime)
    '        endDate = addDT.Rows(numCreated - 1).Item(db_fld_ValDateTime)
    '        beginDateUTC = addDT.Rows(0).Item(db_fld_ValUTCDateTime)
    '        endDateUTC = addDT.Rows(numCreated - 1).Item(db_fld_ValUTCDateTime)

    '        '7. Release resources
    '        If Not (valDT Is Nothing) Then
    '            valDT.Dispose()
    '            valDT = Nothing
    '        End If
    '        If Not (addDT Is Nothing) Then
    '            addDT.Dispose()
    '            addDT = Nothing
    '        End If
    '        '8. return number of values created, True -> everything worked!!
    '        valueCount = numCreated
    '        Return True
    '    Catch ex As Exception
    '        ShowError("An Error occurred while creating the Values for the New Aggregate Data Series." & vbCrLf & "Message = " & ex.Message, ex)
    '    End Try
    '    'release resources
    '    If Not (valDT Is Nothing) Then
    '        valDT.Dispose()
    '        valDT = Nothing
    '    End If
    '    If Not (addDT Is Nothing) Then
    '        addDT.Dispose()
    '        addDT = Nothing
    '    End If
    '    'errors occurred above, return 0 -> so looks like nothing was created!!
    '    valueCount = 0
    '    Return False
    'End Function

    ''****************END 2010******************
    Private Function CreateAlgebraicDSValues(ByVal A As Double, ByVal B As Double, ByVal C As Double, ByVal D As Double, ByVal E As Double, ByVal F As Double, ByVal siteID As Integer, ByVal varID As Integer, ByVal methodID As Integer, ByVal sourceID As Integer, ByVal qcLevelID As Integer, ByVal noDataValue As Double, ByRef valueCount As Integer, ByRef beginDate As DateTime, ByRef endDate As DateTime, ByRef beginDateUTC As DateTime, ByRef endDateUTC As DateTime) As Boolean
        'This function creates the new points for a QC Level1 Data Series
        'Inputs:  A -> the A value of the algebraic equation (y = A + Bx + Cx^2 + Dx^3 + Ex^4 + Fx^5)
        '         B -> the B value of the algebraic equation (y = A + Bx + Cx^2 + Dx^3 + Ex^4 + Fx^5)
        '         C -> the C value of the algebraic equation (y = A + Bx + Cx^2 + Dx^3 + Ex^4 + Fx^5)
        '         D -> the D value of the algebraic equation (y = A + Bx + Cx^2 + Dx^3 + Ex^4 + Fx^5)
        '         E -> the E value of the algebraic equation (y = A + Bx + Cx^2 + Dx^3 + Ex^4 + Fx^5)
        '         F -> the F value of the algebraic equation (y = A + Bx + Cx^2 + Dx^3 + Ex^4 + Fx^5)
        '         siteID -> the siteID for the new Data Series (NOTE: value is stored for each point)
        '         varID -> the variableID for the new Data Series (NOTE: value is stored for each point)
        '         methodID -> the methodID for the new Data Series (NOTE: value is stored for each point)
        '         sourceID -> the sourceID for the new Data Series (NOTE: value is stored for each point)
        '         qcLevelID -> the QCLevelID for the new Data Series (NOTE: value is stored for each point)
        '         noDataValue -> holds the NoDataValue for the new Data Series, used to see if should calculate a new value at the current point or not
        '         valueCount (ByRef) -> the total number of points created, the input value is junk = value is set in this function and returned
        '         beginDate (ByRef) -> the LocalBeginDate of the points created, the input value is junk = value is set in this function and returned
        '         endDate (ByRef) -> the LocalEndDate of the points created, the input value is junk = value is set in this function and returned
        '         beginDateUTC (ByRef) -> the UTCBeginDate of the points created, the input value is junk = value is set in this function and returned
        '         endDateUTC (ByRef) -> the UTCEndDate of the points created, the input value is junk = value is set in this function and returned
        'Outputs: Boolean -> tracks if the new points for the QC Level1 Data Series were created successfully or not
        '         valueCount (ByRef) -> the total number of point created
        '         beginDate (ByRef) -> the LocalDate of the first point
        '         endDate (ByRef) -> the LocalDate of the last point
        '         beginDateUTC (ByRef) -> the UTCDate of the first point
        '         endDateUTC (ByRef) -> the UTCDate of the last point
        Dim i As Integer 'counter
        Dim numCreated As Integer = 0 'tracks the number of points created so far
        Dim numVals As Integer = 0 'holds the number of values retrieved from the Database -> number of values in the Data Series deriving from
        Dim valDT As Data.DataTable 'holds the set of values for the Data Series deriving from
        Dim maxQuery As String 'the sql query to pull the Maximum ValueID value from the Database -> so can start numbering higher than the highest value in the database to avoid duplicates
        'Dim maxDT As Data.DataTable	'the data table that holds the data retrieved from the database using maxQuery
        'Dim addQuery As String 'the sql query used to update the newly created values to the database
        'Dim addDT As Data.DataTable	'the data table (clone of valDT) that holds the newly created values
        'Dim newRow As Data.DataRow 'used to create/add new points (rows) to addDT
        Dim lastID As Integer 'holds the maximum ValueID retrieved from the Database -> used to create the ValueIDs for the new points
        Dim added As Boolean = False 'tracks if the new points were successfully updated to the database or not
        'Dim derivedFromID As Integer 'holds the DerivedFromID for the current point being created
        Dim newVal As Double 'the calculate new value for the current point being created
        Dim curVal As Double ' the value deriving the new value from for the current point being created (from the Data Series deriving from)
        Dim censorCode As String 'holds the NC censor code -> used to create a new point
        Dim numVals_percent As Integer
        Try
            '1. Get the Data from the Database for the Data Series deriving from
            valDT = GetValuesFromDB("FromDSValues", m_DSFromIDs.SiteID, m_DSFromIDs.VariableID, m_DSFromIDs.QCLevelID, m_DSFromIDs.MethodID, m_DSFromIDs.SourceID)
            'validate that have data
            If (valDT Is Nothing) OrElse valDT.Rows.Count <= 0 Then
                'show error message
                MsgBox("Unable to retrieve the values for the Data Series deriving From:  Cannot continue!!  (unable to retrieve values)", MsgBoxStyle.Exclamation)
                'return False
                Exit Try
            End If
            numVals = valDT.Rows.Count
            numVals_percent = CInt(numVals * 0.125)


            '2. Get the max ValueID value
            'NOTE: There has to be values to derive from, so there have to be values in valDT = always get ID of last value
            maxQuery = "SELECT MAX(" & db_fld_ValID & ") AS " & db_expr_MaxID & " FROM " & db_tbl_DataValues
            'maxDT = OpenTable("GetMaxValueID", maxQuery, g_CurrConnSettings)
            ''validate data
            'If (maxDT Is Nothing) OrElse maxDT.Rows.Count = 0 OrElse (maxDT.Rows(0).Item(db_expr_MaxID) Is DBNull.Value) Then
            '	'show error message 
            '	MsgBox("Unable to access the " & db_tbl_DataValues & " Table in the Database:  Cannot continue!!", MsgBoxStyle.Exclamation)
            '	'return false
            '	Exit Try
            'End If
            ''NOTE: There has to be values to derive from, so there has to be a value in maxDT = always get ID of first value
            'lastID = maxDT.Rows(0).Item(db_expr_MaxID)
            lastID = getValue(maxQuery, g_CurrConnSettings)

            '3. Create an empty data table to add values into
            'addDT = valDT.Clone()

            '4. Create the New Values
            censorCode = db_val_CCCVTerm_NULL
            For i = 0 To numVals - 1
                'get the current value (one to derive from)
                curVal = valDT.Rows(i).Item(db_fld_ValValue)

                'Calculate new value
                If curVal <> noDataValue Then
                    'NOTE: Equation = Fx^5 + Ex^4 + Dx^3 + Cx^2 + Bx + A
                    newVal = (F * (Math.Pow(curVal, 5))) + (E * (Math.Pow(curVal, 4))) + (D * (Math.Pow(curVal, 3))) + (C * (Math.Pow(curVal, 2))) + (B * curVal) + A
                    newVal = Math.Round(newVal, 5)
                Else
                    newVal = noDataValue
                End If

                valDT.Rows(i).Item(db_fld_ValID) = lastID + (i + 1)
                valDT.Rows(i).Item(db_fld_ValValue) = newVal
                valDT.Rows(i).Item(db_fld_ValSiteID) = siteID
                valDT.Rows(i).Item(db_fld_ValVarID) = varID
                valDT.Rows(i).Item(db_fld_ValCensorCode) = censorCode 'NOTE: This value is set to 'nd' = not detected				
                valDT.Rows(i).Item(db_fld_ValMethodID) = methodID
                valDT.Rows(i).Item(db_fld_ValSourceID) = sourceID
                valDT.Rows(i).Item(db_fld_ValQCLevel) = qcLevelID
                'NOTE: These values become NULL!!
                '***************************************************
                valDT.Rows(i).Item(db_fld_ValQualifierID) = DBNull.Value
                '***************************************************


                'newRow = addDT.NewRow()
                'newRow.Item(db_fld_ValID) = lastID + (i + 1)
                'newRow.Item(db_fld_ValValue) = newVal
                'newRow.Item(db_fld_ValDateTime) = valDT.Rows(i).Item(db_fld_ValDateTime)
                'newRow.Item(db_fld_ValUTCOffset) = valDT.Rows(i).Item(db_fld_ValUTCOffset)
                'newRow.Item(db_fld_ValUTCDateTime) = valDT.Rows(i).Item(db_fld_ValUTCDateTime)
                'newRow.Item(db_fld_ValSiteID) = siteID
                'newRow.Item(db_fld_ValVarID) = varID
                'newRow.Item(db_fld_ValOffsetValue) = valDT.Rows(i).Item(db_fld_ValOffsetValue)
                'newRow.Item(db_fld_ValOffsetTypeID) = valDT.Rows(i).Item(db_fld_ValOffsetTypeID)
                'newRow.Item(db_fld_ValCensorCode) = censorCode 'NOTE: This value is set to 'nd' = not detected
                ''NOTE: These values become NULL!!
                ''***************************************************
                ''newRow.Item(db_fld_ValQualifierID) = qualifierID
                ''***************************************************
                'newRow.Item(db_fld_ValMethodID) = methodID
                'newRow.Item(db_fld_ValSourceID) = sourceID

                ''NOTE: Per Jeff 4/4/07, just create a new DFID everytime!!
                ''***********************************************************************************************
                '            'derivedFromID = GetDerivedFromIDFromDB(valDT.Rows(i).Item(db_fld_ValID))
                ''If derivedFromID < 0 Then

                ''try creating one
                '            'derivedFromID = CreateNewDerivedFromIDInDB(valDT.Rows(i).Item(db_fld_ValID))
                '            'If derivedFromID < 0 Then
                '            '	'leave it NULL
                '            'Else
                '            '	'set the value
                '            '	newRow.Item(db_fld_ValDerivedFromID) = derivedFromID
                '            'End If
                ''Else
                ''	'set the value
                ''	newRow.Item(db_fld_ValDerivedFromID) = derivedFromID
                ''End If
                ''***********************************************************************************************

                'newRow.Item(db_fld_ValQCLevel) = qcLevelID
                ''add it to the dataTable
                'addDT.Rows.Add(newRow)
                numCreated += 1
                If i Mod numVals_percent = 0 AndAlso i <> 0 Then
                    'update progress bar
                    g_FProgress.pbarProgress.Value += 10
                    g_FProgress.pbarProgress.Refresh()
                End If
            Next i

            'update to 90%
            g_FProgress.pbarProgress.Value = 90
            g_FProgress.pbarProgress.Refresh()

            '5. Update Database w/ New Values
            added = InsertBulk(db_tbl_DataValues, valDT, g_CurrConnSettings.ConnectionString)
            'addQuery = "SELECT * FROM " & db_tbl_DataValues & " ORDER BY " & db_fld_ValID
            'added = UpdateTable(addDT, addQuery, g_CurrConnSettings.ConnectionString)
            If Not (added) Then
                'show an error message
                MsgBox("Unable to update the " & db_tbl_DataValues & " Table with the values for the new Data Series:  Cannot Continue!!", MsgBoxStyle.Exclamation)
                'return False
                Exit Try
            End If

            '6. Set Date Return Values
            beginDate = valDT.Rows(0).Item(db_fld_ValDateTime)
            endDate = valDT.Rows(numCreated - 1).Item(db_fld_ValDateTime)
            beginDateUTC = valDT.Rows(0).Item(db_fld_ValUTCDateTime)
            endDateUTC = valDT.Rows(numCreated - 1).Item(db_fld_ValUTCDateTime)


            'beginDate = addDT.Rows(0).Item(db_fld_ValDateTime)
            'endDate = addDT.Rows(numCreated - 1).Item(db_fld_ValDateTime)
            'beginDateUTC = addDT.Rows(0).Item(db_fld_ValUTCDateTime)
            'endDateUTC = addDT.Rows(numCreated - 1).Item(db_fld_ValUTCDateTime)


            '7. Release resources
            If Not (valDT Is Nothing) Then
                valDT.Dispose()
                valDT = Nothing
            End If
            
            '8. return number of values created, True -> everything worked!!
            valueCount = numCreated
            Return True
        Catch ex As Exception
            ShowError("An Error occurred while creating the Values for the New Data Series created using an Algebraic Equation." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'release resources
        If Not (valDT Is Nothing) Then
            valDT.Dispose()
            valDT = Nothing
        End If
        'If Not (maxDT Is Nothing) Then
        '	maxDT.Dispose()
        '	maxDT = Nothing
        'End If
        'If Not (addDT Is Nothing) Then
        '	addDT.Dispose()
        '	addDT = Nothing
        'End If
        'If Not (newRow Is Nothing) Then
        '	newRow = Nothing
        'End If
        'errors occurred above, return 0 -> so looks like nothing was created!!
        valueCount = 0
        Return False
    End Function

#End Region

#Region " Smoothing Functions "

    Private Function Smooth_LOWESS(ByVal numVals As Integer, ByVal valDT As Data.DataTable) As Double()
        'Calculates new Y-values that have been smoothing using the LOWESS algorithm 
        'NOTE: Code for this was modified from code recieved from Brent Aulenbach
        'Inputs:  numVals -> the total number of values to be smoothed
        '         valDT -> the set of Values to smooth
        'Outputs: Double() -> the new set of Y-Values
        Dim i, j As Integer 'counters
        Dim curYVal As Double 'current Y-Value working with -> used to calculate diffSmoothY values
        Dim curXVal As Double 'current X-Value working with -> used to calculate rwlreg function
        Dim smoothWindow_Days As Double 'smoothing window value in Days -> for rwlreg function
        Dim newYVals As Double() 'set of newly calculated Y-values -> Return Value
        Dim residuals As Double() 'set of residual values -> used to calculate the Weights in the Y-Value direction
        Dim diffSmoothY As Double() 'set of |y - (smoothed y)| values -> used to calculate median value
        Dim sortedDSY As System.Collections.ArrayList 'sorted array of diffSmoothY values -> to get the correct Median value
        Dim median As Double 'the Median |y - (smoothed y)| value -> used to weight new value in the Y-Value direction
        Dim tempResidual As Double 'used to calculate the new Residual value
        Dim temp1_TRSquared As Double 'used to calculate the new residual value
        Dim medianIndex As Integer = 0 'index of the Median Value -> used to get the corrent Median value
        Try
            '1. Get smoothing window value, convert it into days from minutes
            smoothWindow_Days = ConvertMinutesToDays(CDbl(tboxSmooth_WindowVal.Text))

            'NOTE: according to statistics books, you fit the line to all data points, but only evaluate it for the current value
            'NOTE: Following code was obtained from Brent Aulenbauch and adapted for our use
            '**********************************************************************************************************************

            'resize the arrays to numVals, initialize collections
            ReDim newYVals(numVals - 1)
            ReDim residuals(numVals - 1)
            ReDim diffSmoothY(numVals - 1)
            sortedDSY = New System.Collections.ArrayList

            numVals = valDT.Rows.Count

            Dim numVals_percent As Double = CInt(numVals * 0.125)
            '2. Determine initial weightings
            For i = 0 To numVals - 1
                'set initial weightings to 1 for y direction (residuals) -> weight in Y-Value direction
                For j = 0 To numVals - 1
                    residuals(j) = 1
                Next j
                'set initial newYVals values -> weight in X-Value direction
                curXVal = CType(valDT.Rows(i).Item(db_fld_ValDateTime), DateTime).ToOADate
                newYVals(i) = RWLReg(smoothWindow_Days, numVals, curXVal, residuals, valDT)
            Next i
            g_FProgress.pbarProgress.Value += 10
            g_FProgress.pbarProgress.Refresh()
            '3. make two iterations
            For i = 0 To 1
                'clear out values in sortedDSY -> only used to calculate Median, so needs to reset for each pass!!
                sortedDSY.Clear()
                'calculate differences
                For j = 0 To numVals - 1
                    curYVal = valDT.Rows(j).Item(db_fld_ValValue)
                    diffSmoothY(j) = Math.Abs(curYVal - newYVals(j))
                    sortedDSY.Add(diffSmoothY(j))
                Next j
                g_FProgress.pbarProgress.Value += 10
                g_FProgress.pbarProgress.Refresh()
                'sort the values in sortedDSY
                sortedDSY.Sort()
                'find the Median value of all (|y - (smoothed y)|) values
                medianIndex = ((numVals + 1) / 2) - 1 'using 0-based arrays, so have to apply correct offset!!
                If (Int(numVals / 2) = Int((numVals + 1) / 2)) Then
                    'n = even
                    median = (sortedDSY(medianIndex) + sortedDSY(medianIndex + 1)) / 2
                Else
                    'n = odd
                    median = sortedDSY(medianIndex)
                End If
                'Weight values in Y-Value direction (residuals)
                For j = 0 To numVals - 1
                    tempResidual = diffSmoothY(j) / (6 * median)
                    temp1_TRSquared = 1 - Math.Pow(tempResidual, 2)
                    If temp1_TRSquared < 0 OrElse Double.IsNaN(temp1_TRSquared) Then
                        residuals(j) = 0
                    Else
                        residuals(j) = Math.Round(Math.Pow(temp1_TRSquared, 2), 5)
                    End If
                Next j
                g_FProgress.pbarProgress.Value += 10
                g_FProgress.pbarProgress.Refresh()
                'weight in the xdirection and do weighted least squares
                For j = 0 To numVals - 1
                    curXVal = CType(valDT.Rows(j).Item(db_fld_ValDateTime), DateTime).ToOADate
                    newYVals(j) = RWLReg(smoothWindow_Days, numVals, curXVal, residuals, valDT)
                Next j
                g_FProgress.pbarProgress.Value += 10
                g_FProgress.pbarProgress.Refresh()
                'If i Mod numVals_percent & i <> 0 Then
                '    g_FProgress.pbarProgress.Value += 5
                '    g_FProgress.pbarProgress.Refresh()
                'End If
            Next i
            '**********************************************************************************************************************

            'release resources
            If Not (residuals Is Nothing) Then
                residuals = Nothing
            End If
            If Not (diffSmoothY Is Nothing) Then
                diffSmoothY = Nothing
            End If
            If Not (sortedDSY Is Nothing) Then
                sortedDSY.Clear()
                sortedDSY = Nothing
            End If

            'return the new set of YVals
            Return newYVals
        Catch ex As Exception
            ShowError("An Error occurred while running the LOWESS Smoothing routine. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Return Nothing
    End Function

    Private Function RWLReg(ByVal smoothWindow As Double, ByVal numVals As Integer, ByVal X_OADate As Double, ByVal residuals As Double(), ByVal valDT As Data.DataTable) As Double
        'this function is called by LOWESS
        'Robust Weighted Regression, tricube weight by dinstance on x-axis (fractional day), bisquare weight by distance on y-axis (residual) 
        'From: PT2-Trend2.f, DHELZEL
        'NOTE: Code for this was modified from code recieved from Brent Aulenbach
        'Inputs:  smoothWindow -> the smoothing window value in days
        '         numVals -> the total number of values smoothing
        '         X_OADate -> the X-value in OADate format to estimate the Y-Value for
        '         residuals -> the residual values (y-Value bisquare weightings) calculated in LOWESS routine -> used to calculate new X-Value weight
        '         valDT -> the set of actual X-Values -> used to calculate weights in X-Direction
        'Outputs: Double -> the estimated Y-Value at the given X-Value
        Dim i As Integer 'counter
        Dim newY As Double = 0 'new estimated value -> return value
        Dim weights As Double() 'set of weights -> used int WLSq function
        Dim curWeight As Double 'current X-Value weight
        Dim tempWeight As Double 'used to calculate weight
        Dim halfWindow As Double 'half width of the window
        Dim weightsTotal As Double 'running total of all the weights -> so can make weights sum to 1
        Dim curX_OADate As Double 'current X value in OADate format
        Dim diffX As Double 'the difference between x(i) and current X -> used to calculate X-Value weight
        Dim aVal As Double 'calculated in the WLSq function -> used to estimate new Y-Value
        Dim bVal As Double 'calculate in the WLSq function -> used to estimate new Y-Value
        Try
            '1. Initialize values
            halfWindow = smoothWindow / 2
            weightsTotal = 0
            ReDim weights(numVals - 1)

            '2. Weight in X-Value Direction (time)
            For i = 0 To numVals - 1
                curX_OADate = CType(valDT.Rows(i).Item(db_fld_ValDateTime), DateTime).ToOADate
                diffX = (curX_OADate - X_OADate) / halfWindow
                tempWeight = 1 - Math.Abs(Math.Pow(diffX, 3)) '1 - |(diffX ^ 3)|
                If tempWeight < 0 Then
                    curWeight = 0
                Else
                    curWeight = Math.Pow(tempWeight, 3) 'tempWeight ^ 3
                End If
                'set value in Weights
                weights(i) = curWeight * (residuals(i))
                'update weightsTotal
                weightsTotal += weights(i)
            Next i

            '3. make Weights sum to 1
            If weightsTotal <> 0 Then 'make sure don't divide by 0
                For i = 0 To numVals - 1
                    curWeight = weights(i)
                    weights(i) = Math.Round(curWeight / weightsTotal, 5)
                Next i
            End If

            '4. calculate A,B values
            WLSq(aVal, bVal, numVals, weights, valDT)

            '5. Estimate new Y-Value
            newY = Math.Round(aVal + (bVal * X_OADate), 5)

            '6. see if value = undefined
            If (Double.IsNaN(newY)) = True Then
                'return 0 for now!! -> don't know what else to do!!
                newY = 0
            End If
            Return newY
        Catch ex As Exception
            ShowError("An Error occurred while calculated the new Y-Value for the LOWESS smoothing routine." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        Return 0
    End Function

    Private Sub WLSq(ByRef aVal As Double, ByRef bVal As Double, ByVal numVals As Integer, ByVal weights As Double(), ByVal valDT As Data.DataTable)
        'this function is called by RWLReg
        'Calculates the Weighted Least Squares
        'From: PT2-Trend2.f, DHELZEL
        'NOTE: Code for this was modified from code recieved from Brent Aulenbach
        'Inputs:  aVal (ByRef) -> A value for the fitted line -> input value is junk, value is calculated here
        '         bVal (ByRef) -> B value for the fitted line -> input value is junk, value is calculated here
        '         numVals -> the total number of values smoothing
        '         weights -> the X-Value weights calculated in RWLReg
        '         valDT -> the original set of data -> used to calculate A,B values
        Dim i As Integer 'counter
        Dim weightXX As Double = 0 'holds the running total of (curWeight * curX * curX) values -> used to calculate A,B values
        Dim weightX As Double = 0 'holds the running total of (curWeight * curX) values -> used to calculate A,B values
        Dim weightXY As Double = 0 'holds the running total of (curWeight * curX * curY) values -> used to calculate A,B values
        Dim weightY As Double = 0 'holds the running total of (curWeight * curY) values -> used to calculate A,B values
        Dim curX_OADate As Double 'holds the current X value in OADate format -> used to calculate A,B values
        Dim curY As Double 'holds the actual current Y value -> used to calculate A,B values
        Dim curWeight As Double 'holds the current weight value -> used to calculate A,B values
        Dim topVal As Double 'holds the top portion of the equation to calculate the B Value -> (weightXY - (weightY * weightX))/(weightXX - (weightX * weightX))
        Dim bottomVal As Double 'holds the bottom portion of the equation to calculate the B Value -> (weightXY - (weightY * weightX))/(weightXX - (weightX * weightX))
        Try
            '1. intialize values
            aVal = 0
            bVal = 0

            '2. calculate weightXX, weightX, weightXY, weightY totals
            For i = 0 To numVals - 1
                'get current weight
                curWeight = weights(i)
                'if curWeight <> 0, then calculate -> otherwise, just adding 0 all the time -> allows shorter calc times!!
                If curWeight <> 0 Then
                    'get current values (x,y)
                    curX_OADate = CType(valDT.Rows(i).Item(db_fld_ValDateTime), DateTime).ToOADate
                    curY = valDT.Rows(i).Item(db_fld_ValValue)
                    'add to totals
                    weightXX += (curWeight * Math.Pow(curX_OADate, 2))
                    weightX += (curWeight * curX_OADate)
                    weightXY += (curWeight * curX_OADate * curY)
                    weightY += (curWeight * curY)
                End If
            Next i

            '3. Calculate B Value
            topVal = Math.Round(weightXY - (weightY * weightX), 5)
            bottomVal = Math.Round(weightXX - (Math.Pow(weightX, 2)), 5)
            If bottomVal = 0 Then
                bVal = 0
            Else
                bVal = Math.Round(topVal / bottomVal, 5)
            End If

            '4. Calculate A Value
            aVal = Math.Round(weightY - (bVal * weightX), 5)
        Catch ex As Exception
            ShowError("An Error occurred while calculate the Weighted Least Squares values (A,B Values) for the current value smoothing." & vbCrLf & "Message = " & ex.Message, ex)
            'errors occurred, reset A,B vals
            aVal = 0
            bVal = 0
        End Try
    End Sub

#End Region

End Class

