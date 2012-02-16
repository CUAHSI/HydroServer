<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeriveNewDataSeries
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeriveNewDataSeries))
		Me.gboxDeriveInfo = New System.Windows.Forms.GroupBox
		Me.gboxMethodInfo = New System.Windows.Forms.GroupBox
		Me.rbtnCreateNewMethodDesc = New System.Windows.Forms.RadioButton
		Me.rbtnSelectExistingMethodDesc = New System.Windows.Forms.RadioButton
		Me.gboxCreateNewMethodDesc = New System.Windows.Forms.GroupBox
		Me.tboxNewMethodDesc = New System.Windows.Forms.TextBox
		Me.gboxSelectExistingMethodDesc = New System.Windows.Forms.GroupBox
		Me.cboxSelectExistingMethodDesc = New System.Windows.Forms.ComboBox
		Me.rbtnAutoGenMethodDesc = New System.Windows.Forms.RadioButton
		Me.gboxMethodType = New System.Windows.Forms.GroupBox
		Me.rbtnCreateDS_Smoothed = New System.Windows.Forms.RadioButton
		Me.gboxSmooth = New System.Windows.Forms.GroupBox
		Me.lblSmooth_WindowUnits = New System.Windows.Forms.Label
		Me.tboxSmooth_WindowVal = New System.Windows.Forms.TextBox
		Me.lblSmooth_Window = New System.Windows.Forms.Label
		Me.rbtnAlgebraic = New System.Windows.Forms.RadioButton
		Me.rbtnAggregate = New System.Windows.Forms.RadioButton
		Me.gboxAggregate = New System.Windows.Forms.GroupBox
		Me.rbtnAgg_Avg = New System.Windows.Forms.RadioButton
		Me.rbtnAgg_Min = New System.Windows.Forms.RadioButton
		Me.rbtnAgg_Max = New System.Windows.Forms.RadioButton
		Me.gboxAlgebraic = New System.Windows.Forms.GroupBox
		Me.lblAlg_F = New System.Windows.Forms.Label
		Me.lblAlg_EplusF = New System.Windows.Forms.Label
		Me.lblAlg_DplusE = New System.Windows.Forms.Label
		Me.tboxAlg_F = New System.Windows.Forms.TextBox
		Me.tboxAlg_E = New System.Windows.Forms.TextBox
		Me.tboxAlg_D = New System.Windows.Forms.TextBox
		Me.lblAlg_CplusD = New System.Windows.Forms.Label
		Me.tboxAlg_C = New System.Windows.Forms.TextBox
		Me.lblAlg_BplusC = New System.Windows.Forms.Label
		Me.tboxAlg_B = New System.Windows.Forms.TextBox
		Me.lblAlg_AplusB = New System.Windows.Forms.Label
		Me.tboxAlg_A = New System.Windows.Forms.TextBox
		Me.lblAlg_y = New System.Windows.Forms.Label
		Me.rbtnCreateDS_QCLevel1 = New System.Windows.Forms.RadioButton
		Me.gboxDSAttributes = New System.Windows.Forms.GroupBox
		Me.tboxDSSite = New System.Windows.Forms.TextBox
		Me.gboxDSVariable = New System.Windows.Forms.GroupBox
		Me.tboxVarSpeciation = New System.Windows.Forms.TextBox
		Me.tboxVarUnits = New System.Windows.Forms.TextBox
		Me.lblVarSpeciation = New System.Windows.Forms.Label
		Me.tboxVarDataType = New System.Windows.Forms.TextBox
		Me.tboxVarValueType = New System.Windows.Forms.TextBox
		Me.cboxVarQCLevel = New System.Windows.Forms.ComboBox
		Me.lblVarQCLevel = New System.Windows.Forms.Label
		Me.gboxVarSource = New System.Windows.Forms.GroupBox
		Me.tboxSourceCitation = New System.Windows.Forms.TextBox
		Me.lblSourceCitation = New System.Windows.Forms.Label
		Me.tboxSourceDesc = New System.Windows.Forms.TextBox
		Me.tboxSourceOrg = New System.Windows.Forms.TextBox
		Me.lblSourceDesc = New System.Windows.Forms.Label
		Me.lblSourceOrg = New System.Windows.Forms.Label
		Me.gboxVarTimeSupport = New System.Windows.Forms.GroupBox
		Me.tboxTSUnits = New System.Windows.Forms.TextBox
		Me.tboxTSValue = New System.Windows.Forms.TextBox
		Me.lblTSUnits = New System.Windows.Forms.Label
		Me.lblTSValue = New System.Windows.Forms.Label
		Me.tboxVarGenCategory = New System.Windows.Forms.TextBox
		Me.tboxVarSampleMed = New System.Windows.Forms.TextBox
		Me.lblVarGenCategory = New System.Windows.Forms.Label
		Me.lblVarSampleMed = New System.Windows.Forms.Label
		Me.lblVarValueType = New System.Windows.Forms.Label
		Me.tboxVarMethod = New System.Windows.Forms.TextBox
		Me.lblVarDataType = New System.Windows.Forms.Label
		Me.cboxVariable = New System.Windows.Forms.ComboBox
		Me.lblVarUnits = New System.Windows.Forms.Label
		Me.lblVariable = New System.Windows.Forms.Label
		Me.lblVarMethod = New System.Windows.Forms.Label
		Me.lblDSSite = New System.Windows.Forms.Label
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnDeriveNewDS = New System.Windows.Forms.Button
		Me.ttipDeriveNewDS = New System.Windows.Forms.ToolTip(Me.components)
		Me.gboxDeriveInfo.SuspendLayout()
		Me.gboxMethodInfo.SuspendLayout()
		Me.gboxCreateNewMethodDesc.SuspendLayout()
		Me.gboxSelectExistingMethodDesc.SuspendLayout()
		Me.gboxMethodType.SuspendLayout()
		Me.gboxSmooth.SuspendLayout()
		Me.gboxAggregate.SuspendLayout()
		Me.gboxAlgebraic.SuspendLayout()
		Me.gboxDSAttributes.SuspendLayout()
		Me.gboxDSVariable.SuspendLayout()
		Me.gboxVarSource.SuspendLayout()
		Me.gboxVarTimeSupport.SuspendLayout()
		Me.SuspendLayout()
		'
		'gboxDeriveInfo
		'
		Me.gboxDeriveInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxDeriveInfo.Controls.Add(Me.gboxMethodInfo)
		Me.gboxDeriveInfo.Controls.Add(Me.gboxMethodType)
		Me.gboxDeriveInfo.Location = New System.Drawing.Point(8, 8)
		Me.gboxDeriveInfo.Name = "gboxDeriveInfo"
		Me.gboxDeriveInfo.Size = New System.Drawing.Size(774, 208)
		Me.gboxDeriveInfo.TabIndex = 0
		Me.gboxDeriveInfo.TabStop = False
		Me.gboxDeriveInfo.Text = "Derivation Information"
		'
		'gboxMethodInfo
		'
		Me.gboxMethodInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxMethodInfo.Controls.Add(Me.rbtnCreateNewMethodDesc)
		Me.gboxMethodInfo.Controls.Add(Me.rbtnSelectExistingMethodDesc)
		Me.gboxMethodInfo.Controls.Add(Me.gboxCreateNewMethodDesc)
		Me.gboxMethodInfo.Controls.Add(Me.gboxSelectExistingMethodDesc)
		Me.gboxMethodInfo.Controls.Add(Me.rbtnAutoGenMethodDesc)
		Me.gboxMethodInfo.Location = New System.Drawing.Point(464, 16)
		Me.gboxMethodInfo.Name = "gboxMethodInfo"
		Me.gboxMethodInfo.Size = New System.Drawing.Size(304, 184)
		Me.gboxMethodInfo.TabIndex = 1
		Me.gboxMethodInfo.TabStop = False
		Me.gboxMethodInfo.Text = "Method Description"
		'
		'rbtnCreateNewMethodDesc
		'
		Me.rbtnCreateNewMethodDesc.AutoSize = True
		Me.rbtnCreateNewMethodDesc.Location = New System.Drawing.Point(16, 88)
		Me.rbtnCreateNewMethodDesc.Name = "rbtnCreateNewMethodDesc"
		Me.rbtnCreateNewMethodDesc.Size = New System.Drawing.Size(14, 13)
		Me.rbtnCreateNewMethodDesc.TabIndex = 5
		Me.rbtnCreateNewMethodDesc.TabStop = True
		Me.rbtnCreateNewMethodDesc.UseVisualStyleBackColor = True
		'
		'rbtnSelectExistingMethodDesc
		'
		Me.rbtnSelectExistingMethodDesc.AutoSize = True
		Me.rbtnSelectExistingMethodDesc.Location = New System.Drawing.Point(16, 40)
		Me.rbtnSelectExistingMethodDesc.Name = "rbtnSelectExistingMethodDesc"
		Me.rbtnSelectExistingMethodDesc.Size = New System.Drawing.Size(14, 13)
		Me.rbtnSelectExistingMethodDesc.TabIndex = 4
		Me.rbtnSelectExistingMethodDesc.TabStop = True
		Me.rbtnSelectExistingMethodDesc.UseVisualStyleBackColor = True
		'
		'gboxCreateNewMethodDesc
		'
		Me.gboxCreateNewMethodDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxCreateNewMethodDesc.Controls.Add(Me.tboxNewMethodDesc)
		Me.gboxCreateNewMethodDesc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.gboxCreateNewMethodDesc.Location = New System.Drawing.Point(8, 88)
		Me.gboxCreateNewMethodDesc.Name = "gboxCreateNewMethodDesc"
		Me.gboxCreateNewMethodDesc.Size = New System.Drawing.Size(288, 88)
		Me.gboxCreateNewMethodDesc.TabIndex = 2
		Me.gboxCreateNewMethodDesc.TabStop = False
		Me.gboxCreateNewMethodDesc.Text = "     Create a new Method Description"
		'
		'tboxNewMethodDesc
		'
		Me.tboxNewMethodDesc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxNewMethodDesc.Location = New System.Drawing.Point(24, 16)
		Me.tboxNewMethodDesc.Multiline = True
		Me.tboxNewMethodDesc.Name = "tboxNewMethodDesc"
		Me.tboxNewMethodDesc.Size = New System.Drawing.Size(256, 64)
		Me.tboxNewMethodDesc.TabIndex = 4
		'
		'gboxSelectExistingMethodDesc
		'
		Me.gboxSelectExistingMethodDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxSelectExistingMethodDesc.Controls.Add(Me.cboxSelectExistingMethodDesc)
		Me.gboxSelectExistingMethodDesc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.gboxSelectExistingMethodDesc.Location = New System.Drawing.Point(8, 40)
		Me.gboxSelectExistingMethodDesc.Name = "gboxSelectExistingMethodDesc"
		Me.gboxSelectExistingMethodDesc.Size = New System.Drawing.Size(288, 40)
		Me.gboxSelectExistingMethodDesc.TabIndex = 1
		Me.gboxSelectExistingMethodDesc.TabStop = False
		Me.gboxSelectExistingMethodDesc.Text = "     Select an existing Method Description"
		'
		'cboxSelectExistingMethodDesc
		'
		Me.cboxSelectExistingMethodDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cboxSelectExistingMethodDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboxSelectExistingMethodDesc.FormattingEnabled = True
		Me.cboxSelectExistingMethodDesc.Location = New System.Drawing.Point(24, 14)
		Me.cboxSelectExistingMethodDesc.Name = "cboxSelectExistingMethodDesc"
		Me.cboxSelectExistingMethodDesc.Size = New System.Drawing.Size(256, 21)
		Me.cboxSelectExistingMethodDesc.TabIndex = 4
		'
		'rbtnAutoGenMethodDesc
		'
		Me.rbtnAutoGenMethodDesc.AutoSize = True
		Me.rbtnAutoGenMethodDesc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.rbtnAutoGenMethodDesc.Location = New System.Drawing.Point(16, 16)
		Me.rbtnAutoGenMethodDesc.Name = "rbtnAutoGenMethodDesc"
		Me.rbtnAutoGenMethodDesc.Size = New System.Drawing.Size(236, 17)
		Me.rbtnAutoGenMethodDesc.TabIndex = 0
		Me.rbtnAutoGenMethodDesc.TabStop = True
		Me.rbtnAutoGenMethodDesc.Text = "Automatically generate a Method Description"
		Me.rbtnAutoGenMethodDesc.UseVisualStyleBackColor = True
		'
		'gboxMethodType
		'
		Me.gboxMethodType.Controls.Add(Me.rbtnCreateDS_Smoothed)
		Me.gboxMethodType.Controls.Add(Me.gboxSmooth)
		Me.gboxMethodType.Controls.Add(Me.rbtnAlgebraic)
		Me.gboxMethodType.Controls.Add(Me.rbtnAggregate)
		Me.gboxMethodType.Controls.Add(Me.gboxAggregate)
		Me.gboxMethodType.Controls.Add(Me.gboxAlgebraic)
		Me.gboxMethodType.Controls.Add(Me.rbtnCreateDS_QCLevel1)
		Me.gboxMethodType.Location = New System.Drawing.Point(8, 16)
		Me.gboxMethodType.Name = "gboxMethodType"
		Me.gboxMethodType.Size = New System.Drawing.Size(448, 184)
		Me.gboxMethodType.TabIndex = 0
		Me.gboxMethodType.TabStop = False
		Me.gboxMethodType.Text = "Derive Method"
		'
		'rbtnCreateDS_Smoothed
		'
		Me.rbtnCreateDS_Smoothed.AutoSize = True
		Me.rbtnCreateDS_Smoothed.Location = New System.Drawing.Point(16, 44)
		Me.rbtnCreateDS_Smoothed.Name = "rbtnCreateDS_Smoothed"
		Me.rbtnCreateDS_Smoothed.Size = New System.Drawing.Size(14, 13)
		Me.rbtnCreateDS_Smoothed.TabIndex = 3
		Me.rbtnCreateDS_Smoothed.UseVisualStyleBackColor = True
		'
		'gboxSmooth
		'
		Me.gboxSmooth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxSmooth.Controls.Add(Me.lblSmooth_WindowUnits)
		Me.gboxSmooth.Controls.Add(Me.tboxSmooth_WindowVal)
		Me.gboxSmooth.Controls.Add(Me.lblSmooth_Window)
		Me.gboxSmooth.ForeColor = System.Drawing.SystemColors.ControlText
		Me.gboxSmooth.Location = New System.Drawing.Point(8, 44)
		Me.gboxSmooth.Name = "gboxSmooth"
		Me.gboxSmooth.Size = New System.Drawing.Size(432, 40)
		Me.gboxSmooth.TabIndex = 6
		Me.gboxSmooth.TabStop = False
		Me.gboxSmooth.Text = "     Derive using a Smoothing Algorithm"
		'
		'lblSmooth_WindowUnits
		'
		Me.lblSmooth_WindowUnits.Location = New System.Drawing.Point(170, 18)
		Me.lblSmooth_WindowUnits.Name = "lblSmooth_WindowUnits"
		Me.lblSmooth_WindowUnits.Size = New System.Drawing.Size(56, 16)
		Me.lblSmooth_WindowUnits.TabIndex = 3
		Me.lblSmooth_WindowUnits.Text = "minutes"
		Me.lblSmooth_WindowUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxSmooth_WindowVal
		'
		Me.tboxSmooth_WindowVal.Location = New System.Drawing.Point(120, 16)
		Me.tboxSmooth_WindowVal.Name = "tboxSmooth_WindowVal"
		Me.tboxSmooth_WindowVal.Size = New System.Drawing.Size(48, 20)
		Me.tboxSmooth_WindowVal.TabIndex = 2
		'
		'lblSmooth_Window
		'
		Me.lblSmooth_Window.Location = New System.Drawing.Point(8, 18)
		Me.lblSmooth_Window.Name = "lblSmooth_Window"
		Me.lblSmooth_Window.Size = New System.Drawing.Size(112, 16)
		Me.lblSmooth_Window.TabIndex = 0
		Me.lblSmooth_Window.Text = "Smoothing Window : "
		Me.lblSmooth_Window.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'rbtnAlgebraic
		'
		Me.rbtnAlgebraic.AutoSize = True
		Me.rbtnAlgebraic.Location = New System.Drawing.Point(16, 136)
		Me.rbtnAlgebraic.Name = "rbtnAlgebraic"
		Me.rbtnAlgebraic.Size = New System.Drawing.Size(14, 13)
		Me.rbtnAlgebraic.TabIndex = 5
		Me.rbtnAlgebraic.UseVisualStyleBackColor = True
		'
		'rbtnAggregate
		'
		Me.rbtnAggregate.AutoSize = True
		Me.rbtnAggregate.Location = New System.Drawing.Point(16, 88)
		Me.rbtnAggregate.Name = "rbtnAggregate"
		Me.rbtnAggregate.Size = New System.Drawing.Size(14, 13)
		Me.rbtnAggregate.TabIndex = 4
		Me.rbtnAggregate.UseVisualStyleBackColor = True
		'
		'gboxAggregate
		'
		Me.gboxAggregate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxAggregate.Controls.Add(Me.rbtnAgg_Avg)
		Me.gboxAggregate.Controls.Add(Me.rbtnAgg_Min)
		Me.gboxAggregate.Controls.Add(Me.rbtnAgg_Max)
		Me.gboxAggregate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.gboxAggregate.Location = New System.Drawing.Point(8, 88)
		Me.gboxAggregate.Name = "gboxAggregate"
		Me.gboxAggregate.Size = New System.Drawing.Size(432, 40)
		Me.gboxAggregate.TabIndex = 2
		Me.gboxAggregate.TabStop = False
		Me.gboxAggregate.Text = "     Derive using a Daily Aggregate Function"
		'
		'rbtnAgg_Avg
		'
		Me.rbtnAgg_Avg.AutoSize = True
		Me.rbtnAgg_Avg.Location = New System.Drawing.Point(248, 16)
		Me.rbtnAgg_Avg.Name = "rbtnAgg_Avg"
		Me.rbtnAgg_Avg.Size = New System.Drawing.Size(65, 17)
		Me.rbtnAgg_Avg.TabIndex = 5
		Me.rbtnAgg_Avg.TabStop = True
		Me.rbtnAgg_Avg.Text = "Average"
		Me.rbtnAgg_Avg.UseVisualStyleBackColor = True
		'
		'rbtnAgg_Min
		'
		Me.rbtnAgg_Min.AutoSize = True
		Me.rbtnAgg_Min.Location = New System.Drawing.Point(136, 16)
		Me.rbtnAgg_Min.Name = "rbtnAgg_Min"
		Me.rbtnAgg_Min.Size = New System.Drawing.Size(66, 17)
		Me.rbtnAgg_Min.TabIndex = 4
		Me.rbtnAgg_Min.TabStop = True
		Me.rbtnAgg_Min.Text = "Minimum"
		Me.rbtnAgg_Min.UseVisualStyleBackColor = True
		'
		'rbtnAgg_Max
		'
		Me.rbtnAgg_Max.AutoSize = True
		Me.rbtnAgg_Max.Location = New System.Drawing.Point(24, 16)
		Me.rbtnAgg_Max.Name = "rbtnAgg_Max"
		Me.rbtnAgg_Max.Size = New System.Drawing.Size(69, 17)
		Me.rbtnAgg_Max.TabIndex = 3
		Me.rbtnAgg_Max.TabStop = True
		Me.rbtnAgg_Max.Text = "Maximum"
		Me.rbtnAgg_Max.UseVisualStyleBackColor = True
		'
		'gboxAlgebraic
		'
		Me.gboxAlgebraic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxAlgebraic.Controls.Add(Me.lblAlg_F)
		Me.gboxAlgebraic.Controls.Add(Me.lblAlg_EplusF)
		Me.gboxAlgebraic.Controls.Add(Me.lblAlg_DplusE)
		Me.gboxAlgebraic.Controls.Add(Me.tboxAlg_F)
		Me.gboxAlgebraic.Controls.Add(Me.tboxAlg_E)
		Me.gboxAlgebraic.Controls.Add(Me.tboxAlg_D)
		Me.gboxAlgebraic.Controls.Add(Me.lblAlg_CplusD)
		Me.gboxAlgebraic.Controls.Add(Me.tboxAlg_C)
		Me.gboxAlgebraic.Controls.Add(Me.lblAlg_BplusC)
		Me.gboxAlgebraic.Controls.Add(Me.tboxAlg_B)
		Me.gboxAlgebraic.Controls.Add(Me.lblAlg_AplusB)
		Me.gboxAlgebraic.Controls.Add(Me.tboxAlg_A)
		Me.gboxAlgebraic.Controls.Add(Me.lblAlg_y)
		Me.gboxAlgebraic.ForeColor = System.Drawing.SystemColors.ControlText
		Me.gboxAlgebraic.Location = New System.Drawing.Point(8, 136)
		Me.gboxAlgebraic.Name = "gboxAlgebraic"
		Me.gboxAlgebraic.Size = New System.Drawing.Size(432, 40)
		Me.gboxAlgebraic.TabIndex = 1
		Me.gboxAlgebraic.TabStop = False
		Me.gboxAlgebraic.Text = "     Derive using an Algebraic Equation"
		'
		'lblAlg_F
		'
		Me.lblAlg_F.Location = New System.Drawing.Point(392, 18)
		Me.lblAlg_F.Name = "lblAlg_F"
		Me.lblAlg_F.Size = New System.Drawing.Size(36, 16)
		Me.lblAlg_F.TabIndex = 18
		Me.lblAlg_F.Text = "x^5"
		Me.lblAlg_F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblAlg_EplusF
		'
		Me.lblAlg_EplusF.Location = New System.Drawing.Point(320, 18)
		Me.lblAlg_EplusF.Name = "lblAlg_EplusF"
		Me.lblAlg_EplusF.Size = New System.Drawing.Size(40, 16)
		Me.lblAlg_EplusF.TabIndex = 17
		Me.lblAlg_EplusF.Text = "x^4  + "
		Me.lblAlg_EplusF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblAlg_DplusE
		'
		Me.lblAlg_DplusE.Location = New System.Drawing.Point(248, 18)
		Me.lblAlg_DplusE.Name = "lblAlg_DplusE"
		Me.lblAlg_DplusE.Size = New System.Drawing.Size(40, 16)
		Me.lblAlg_DplusE.TabIndex = 16
		Me.lblAlg_DplusE.Text = "x^3  + "
		Me.lblAlg_DplusE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxAlg_F
		'
		Me.tboxAlg_F.Location = New System.Drawing.Point(360, 16)
		Me.tboxAlg_F.Name = "tboxAlg_F"
		Me.tboxAlg_F.Size = New System.Drawing.Size(32, 20)
		Me.tboxAlg_F.TabIndex = 14
		Me.tboxAlg_F.Text = "0"
		Me.tboxAlg_F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'tboxAlg_E
		'
		Me.tboxAlg_E.Location = New System.Drawing.Point(288, 16)
		Me.tboxAlg_E.Name = "tboxAlg_E"
		Me.tboxAlg_E.Size = New System.Drawing.Size(32, 20)
		Me.tboxAlg_E.TabIndex = 12
		Me.tboxAlg_E.Text = "0"
		Me.tboxAlg_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'tboxAlg_D
		'
		Me.tboxAlg_D.Location = New System.Drawing.Point(216, 16)
		Me.tboxAlg_D.Name = "tboxAlg_D"
		Me.tboxAlg_D.Size = New System.Drawing.Size(32, 20)
		Me.tboxAlg_D.TabIndex = 10
		Me.tboxAlg_D.Text = "0"
		Me.tboxAlg_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblAlg_CplusD
		'
		Me.lblAlg_CplusD.Location = New System.Drawing.Point(176, 18)
		Me.lblAlg_CplusD.Name = "lblAlg_CplusD"
		Me.lblAlg_CplusD.Size = New System.Drawing.Size(40, 16)
		Me.lblAlg_CplusD.TabIndex = 9
		Me.lblAlg_CplusD.Text = "x^2  + "
		Me.lblAlg_CplusD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxAlg_C
		'
		Me.tboxAlg_C.Location = New System.Drawing.Point(142, 16)
		Me.tboxAlg_C.Name = "tboxAlg_C"
		Me.tboxAlg_C.Size = New System.Drawing.Size(32, 20)
		Me.tboxAlg_C.TabIndex = 8
		Me.tboxAlg_C.Text = "0"
		Me.tboxAlg_C.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblAlg_BplusC
		'
		Me.lblAlg_BplusC.Location = New System.Drawing.Point(116, 18)
		Me.lblAlg_BplusC.Name = "lblAlg_BplusC"
		Me.lblAlg_BplusC.Size = New System.Drawing.Size(24, 16)
		Me.lblAlg_BplusC.TabIndex = 7
		Me.lblAlg_BplusC.Text = "x  + "
		Me.lblAlg_BplusC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxAlg_B
		'
		Me.tboxAlg_B.Location = New System.Drawing.Point(84, 16)
		Me.tboxAlg_B.Name = "tboxAlg_B"
		Me.tboxAlg_B.Size = New System.Drawing.Size(32, 20)
		Me.tboxAlg_B.TabIndex = 6
		Me.tboxAlg_B.Text = "0"
		Me.tboxAlg_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblAlg_AplusB
		'
		Me.lblAlg_AplusB.Location = New System.Drawing.Point(64, 18)
		Me.lblAlg_AplusB.Name = "lblAlg_AplusB"
		Me.lblAlg_AplusB.Size = New System.Drawing.Size(18, 16)
		Me.lblAlg_AplusB.TabIndex = 5
		Me.lblAlg_AplusB.Text = " + "
		Me.lblAlg_AplusB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxAlg_A
		'
		Me.tboxAlg_A.Location = New System.Drawing.Point(32, 16)
		Me.tboxAlg_A.Name = "tboxAlg_A"
		Me.tboxAlg_A.Size = New System.Drawing.Size(32, 20)
		Me.tboxAlg_A.TabIndex = 4
		Me.tboxAlg_A.Text = "0"
		Me.tboxAlg_A.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblAlg_y
		'
		Me.lblAlg_y.Location = New System.Drawing.Point(8, 18)
		Me.lblAlg_y.Name = "lblAlg_y"
		Me.lblAlg_y.Size = New System.Drawing.Size(24, 16)
		Me.lblAlg_y.TabIndex = 3
		Me.lblAlg_y.Text = "y = "
		Me.lblAlg_y.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'rbtnCreateDS_QCLevel1
		'
		Me.rbtnCreateDS_QCLevel1.AutoSize = True
		Me.rbtnCreateDS_QCLevel1.Checked = True
		Me.rbtnCreateDS_QCLevel1.Location = New System.Drawing.Point(16, 16)
		Me.rbtnCreateDS_QCLevel1.Name = "rbtnCreateDS_QCLevel1"
		Me.rbtnCreateDS_QCLevel1.Size = New System.Drawing.Size(258, 17)
		Me.rbtnCreateDS_QCLevel1.TabIndex = 0
		Me.rbtnCreateDS_QCLevel1.TabStop = True
		Me.rbtnCreateDS_QCLevel1.Text = "Create a Quality Controlled Data Series for Editing"
		Me.rbtnCreateDS_QCLevel1.UseVisualStyleBackColor = True
		'
		'gboxDSAttributes
		'
		Me.gboxDSAttributes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxDSAttributes.Controls.Add(Me.tboxDSSite)
		Me.gboxDSAttributes.Controls.Add(Me.gboxDSVariable)
		Me.gboxDSAttributes.Controls.Add(Me.lblDSSite)
		Me.gboxDSAttributes.Location = New System.Drawing.Point(8, 224)
		Me.gboxDSAttributes.Name = "gboxDSAttributes"
		Me.gboxDSAttributes.Size = New System.Drawing.Size(776, 256)
		Me.gboxDSAttributes.TabIndex = 1
		Me.gboxDSAttributes.TabStop = False
		Me.gboxDSAttributes.Text = "Data Series Attributes"
		'
		'tboxDSSite
		'
		Me.tboxDSSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxDSSite.Location = New System.Drawing.Point(40, 16)
		Me.tboxDSSite.Name = "tboxDSSite"
		Me.tboxDSSite.ReadOnly = True
		Me.tboxDSSite.Size = New System.Drawing.Size(728, 20)
		Me.tboxDSSite.TabIndex = 5
		'
		'gboxDSVariable
		'
		Me.gboxDSVariable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxDSVariable.Controls.Add(Me.tboxVarSpeciation)
		Me.gboxDSVariable.Controls.Add(Me.tboxVarUnits)
		Me.gboxDSVariable.Controls.Add(Me.lblVarSpeciation)
		Me.gboxDSVariable.Controls.Add(Me.tboxVarDataType)
		Me.gboxDSVariable.Controls.Add(Me.tboxVarValueType)
		Me.gboxDSVariable.Controls.Add(Me.cboxVarQCLevel)
		Me.gboxDSVariable.Controls.Add(Me.lblVarQCLevel)
		Me.gboxDSVariable.Controls.Add(Me.gboxVarSource)
		Me.gboxDSVariable.Controls.Add(Me.gboxVarTimeSupport)
		Me.gboxDSVariable.Controls.Add(Me.tboxVarGenCategory)
		Me.gboxDSVariable.Controls.Add(Me.tboxVarSampleMed)
		Me.gboxDSVariable.Controls.Add(Me.lblVarGenCategory)
		Me.gboxDSVariable.Controls.Add(Me.lblVarSampleMed)
		Me.gboxDSVariable.Controls.Add(Me.lblVarValueType)
		Me.gboxDSVariable.Controls.Add(Me.tboxVarMethod)
		Me.gboxDSVariable.Controls.Add(Me.lblVarDataType)
		Me.gboxDSVariable.Controls.Add(Me.cboxVariable)
		Me.gboxDSVariable.Controls.Add(Me.lblVarUnits)
		Me.gboxDSVariable.Controls.Add(Me.lblVariable)
		Me.gboxDSVariable.Controls.Add(Me.lblVarMethod)
		Me.gboxDSVariable.Location = New System.Drawing.Point(8, 40)
		Me.gboxDSVariable.Name = "gboxDSVariable"
		Me.gboxDSVariable.Size = New System.Drawing.Size(760, 208)
		Me.gboxDSVariable.TabIndex = 4
		Me.gboxDSVariable.TabStop = False
		Me.gboxDSVariable.Text = "Variable"
		'
		'tboxVarSpeciation
		'
		Me.tboxVarSpeciation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxVarSpeciation.Location = New System.Drawing.Point(632, 16)
		Me.tboxVarSpeciation.Name = "tboxVarSpeciation"
		Me.tboxVarSpeciation.ReadOnly = True
		Me.tboxVarSpeciation.Size = New System.Drawing.Size(120, 20)
		Me.tboxVarSpeciation.TabIndex = 35
		'
		'tboxVarUnits
		'
		Me.tboxVarUnits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxVarUnits.Location = New System.Drawing.Point(392, 16)
		Me.tboxVarUnits.Name = "tboxVarUnits"
		Me.tboxVarUnits.ReadOnly = True
		Me.tboxVarUnits.Size = New System.Drawing.Size(168, 20)
		Me.tboxVarUnits.TabIndex = 34
		'
		'lblVarSpeciation
		'
		Me.lblVarSpeciation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblVarSpeciation.BackColor = System.Drawing.SystemColors.Control
		Me.lblVarSpeciation.Location = New System.Drawing.Point(568, 18)
		Me.lblVarSpeciation.Name = "lblVarSpeciation"
		Me.lblVarSpeciation.Size = New System.Drawing.Size(64, 16)
		Me.lblVarSpeciation.TabIndex = 32
		Me.lblVarSpeciation.Text = "Speciation : "
		Me.lblVarSpeciation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxVarDataType
		'
		Me.tboxVarDataType.Location = New System.Drawing.Point(80, 120)
		Me.tboxVarDataType.Name = "tboxVarDataType"
		Me.tboxVarDataType.ReadOnly = True
		Me.tboxVarDataType.Size = New System.Drawing.Size(224, 20)
		Me.tboxVarDataType.TabIndex = 31
		'
		'tboxVarValueType
		'
		Me.tboxVarValueType.Location = New System.Drawing.Point(80, 96)
		Me.tboxVarValueType.Name = "tboxVarValueType"
		Me.tboxVarValueType.ReadOnly = True
		Me.tboxVarValueType.Size = New System.Drawing.Size(224, 20)
		Me.tboxVarValueType.TabIndex = 30
		'
		'cboxVarQCLevel
		'
		Me.cboxVarQCLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboxVarQCLevel.FormattingEnabled = True
		Me.cboxVarQCLevel.Location = New System.Drawing.Point(120, 152)
		Me.cboxVarQCLevel.Name = "cboxVarQCLevel"
		Me.cboxVarQCLevel.Size = New System.Drawing.Size(184, 21)
		Me.cboxVarQCLevel.TabIndex = 28
		'
		'lblVarQCLevel
		'
		Me.lblVarQCLevel.BackColor = System.Drawing.SystemColors.Control
		Me.lblVarQCLevel.Location = New System.Drawing.Point(8, 154)
		Me.lblVarQCLevel.Name = "lblVarQCLevel"
		Me.lblVarQCLevel.Size = New System.Drawing.Size(112, 16)
		Me.lblVarQCLevel.TabIndex = 27
		Me.lblVarQCLevel.Text = "Quality Control Level : "
		Me.lblVarQCLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'gboxVarSource
		'
		Me.gboxVarSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.gboxVarSource.Controls.Add(Me.tboxSourceCitation)
		Me.gboxVarSource.Controls.Add(Me.lblSourceCitation)
		Me.gboxVarSource.Controls.Add(Me.tboxSourceDesc)
		Me.gboxVarSource.Controls.Add(Me.tboxSourceOrg)
		Me.gboxVarSource.Controls.Add(Me.lblSourceDesc)
		Me.gboxVarSource.Controls.Add(Me.lblSourceOrg)
		Me.gboxVarSource.Location = New System.Drawing.Point(312, 40)
		Me.gboxVarSource.Name = "gboxVarSource"
		Me.gboxVarSource.Size = New System.Drawing.Size(440, 88)
		Me.gboxVarSource.TabIndex = 26
		Me.gboxVarSource.TabStop = False
		Me.gboxVarSource.Text = "Source"
		'
		'tboxSourceCitation
		'
		Me.tboxSourceCitation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxSourceCitation.Location = New System.Drawing.Point(264, 28)
		Me.tboxSourceCitation.Name = "tboxSourceCitation"
		Me.tboxSourceCitation.ReadOnly = True
		Me.tboxSourceCitation.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
		Me.tboxSourceCitation.Size = New System.Drawing.Size(168, 20)
		Me.tboxSourceCitation.TabIndex = 27
		'
		'lblSourceCitation
		'
		Me.lblSourceCitation.Location = New System.Drawing.Point(264, 12)
		Me.lblSourceCitation.Name = "lblSourceCitation"
		Me.lblSourceCitation.Size = New System.Drawing.Size(76, 16)
		Me.lblSourceCitation.TabIndex = 26
		Me.lblSourceCitation.Text = "Citation :"
		Me.lblSourceCitation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxSourceDesc
		'
		Me.tboxSourceDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxSourceDesc.Location = New System.Drawing.Point(8, 64)
		Me.tboxSourceDesc.Name = "tboxSourceDesc"
		Me.tboxSourceDesc.ReadOnly = True
		Me.tboxSourceDesc.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
		Me.tboxSourceDesc.Size = New System.Drawing.Size(424, 20)
		Me.tboxSourceDesc.TabIndex = 25
		'
		'tboxSourceOrg
		'
		Me.tboxSourceOrg.Location = New System.Drawing.Point(8, 28)
		Me.tboxSourceOrg.Name = "tboxSourceOrg"
		Me.tboxSourceOrg.ReadOnly = True
		Me.tboxSourceOrg.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
		Me.tboxSourceOrg.Size = New System.Drawing.Size(248, 20)
		Me.tboxSourceOrg.TabIndex = 24
		'
		'lblSourceDesc
		'
		Me.lblSourceDesc.Location = New System.Drawing.Point(8, 48)
		Me.lblSourceDesc.Name = "lblSourceDesc"
		Me.lblSourceDesc.Size = New System.Drawing.Size(104, 16)
		Me.lblSourceDesc.TabIndex = 1
		Me.lblSourceDesc.Text = "Source Description : "
		Me.lblSourceDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblSourceOrg
		'
		Me.lblSourceOrg.Location = New System.Drawing.Point(8, 12)
		Me.lblSourceOrg.Name = "lblSourceOrg"
		Me.lblSourceOrg.Size = New System.Drawing.Size(76, 16)
		Me.lblSourceOrg.TabIndex = 0
		Me.lblSourceOrg.Text = "Organization :"
		Me.lblSourceOrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'gboxVarTimeSupport
		'
		Me.gboxVarTimeSupport.Controls.Add(Me.tboxTSUnits)
		Me.gboxVarTimeSupport.Controls.Add(Me.tboxTSValue)
		Me.gboxVarTimeSupport.Controls.Add(Me.lblTSUnits)
		Me.gboxVarTimeSupport.Controls.Add(Me.lblTSValue)
		Me.gboxVarTimeSupport.Location = New System.Drawing.Point(8, 40)
		Me.gboxVarTimeSupport.Name = "gboxVarTimeSupport"
		Me.gboxVarTimeSupport.Size = New System.Drawing.Size(296, 48)
		Me.gboxVarTimeSupport.TabIndex = 25
		Me.gboxVarTimeSupport.TabStop = False
		Me.gboxVarTimeSupport.Text = "Time Support"
		'
		'tboxTSUnits
		'
		Me.tboxTSUnits.Location = New System.Drawing.Point(144, 18)
		Me.tboxTSUnits.Name = "tboxTSUnits"
		Me.tboxTSUnits.ReadOnly = True
		Me.tboxTSUnits.Size = New System.Drawing.Size(144, 20)
		Me.tboxTSUnits.TabIndex = 31
		'
		'tboxTSValue
		'
		Me.tboxTSValue.Location = New System.Drawing.Point(56, 18)
		Me.tboxTSValue.Name = "tboxTSValue"
		Me.tboxTSValue.ReadOnly = True
		Me.tboxTSValue.Size = New System.Drawing.Size(40, 20)
		Me.tboxTSValue.TabIndex = 14
		Me.tboxTSValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblTSUnits
		'
		Me.lblTSUnits.BackColor = System.Drawing.SystemColors.Control
		Me.lblTSUnits.Location = New System.Drawing.Point(108, 20)
		Me.lblTSUnits.Name = "lblTSUnits"
		Me.lblTSUnits.Size = New System.Drawing.Size(40, 16)
		Me.lblTSUnits.TabIndex = 6
		Me.lblTSUnits.Text = "Units : "
		Me.lblTSUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblTSValue
		'
		Me.lblTSValue.BackColor = System.Drawing.SystemColors.Control
		Me.lblTSValue.Location = New System.Drawing.Point(12, 20)
		Me.lblTSValue.Name = "lblTSValue"
		Me.lblTSValue.Size = New System.Drawing.Size(40, 16)
		Me.lblTSValue.TabIndex = 5
		Me.lblTSValue.Text = "Value : "
		'
		'tboxVarGenCategory
		'
		Me.tboxVarGenCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxVarGenCategory.Location = New System.Drawing.Point(408, 136)
		Me.tboxVarGenCategory.Name = "tboxVarGenCategory"
		Me.tboxVarGenCategory.ReadOnly = True
		Me.tboxVarGenCategory.Size = New System.Drawing.Size(344, 20)
		Me.tboxVarGenCategory.TabIndex = 23
		'
		'tboxVarSampleMed
		'
		Me.tboxVarSampleMed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxVarSampleMed.Location = New System.Drawing.Point(408, 160)
		Me.tboxVarSampleMed.Name = "tboxVarSampleMed"
		Me.tboxVarSampleMed.ReadOnly = True
		Me.tboxVarSampleMed.Size = New System.Drawing.Size(344, 20)
		Me.tboxVarSampleMed.TabIndex = 22
		'
		'lblVarGenCategory
		'
		Me.lblVarGenCategory.BackColor = System.Drawing.SystemColors.Control
		Me.lblVarGenCategory.Location = New System.Drawing.Point(312, 138)
		Me.lblVarGenCategory.Name = "lblVarGenCategory"
		Me.lblVarGenCategory.Size = New System.Drawing.Size(96, 16)
		Me.lblVarGenCategory.TabIndex = 21
		Me.lblVarGenCategory.Text = "General Category : "
		Me.lblVarGenCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblVarSampleMed
		'
		Me.lblVarSampleMed.BackColor = System.Drawing.SystemColors.Control
		Me.lblVarSampleMed.Location = New System.Drawing.Point(312, 162)
		Me.lblVarSampleMed.Name = "lblVarSampleMed"
		Me.lblVarSampleMed.Size = New System.Drawing.Size(88, 16)
		Me.lblVarSampleMed.TabIndex = 20
		Me.lblVarSampleMed.Text = "Sample Medium : "
		Me.lblVarSampleMed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblVarValueType
		'
		Me.lblVarValueType.BackColor = System.Drawing.SystemColors.Control
		Me.lblVarValueType.Location = New System.Drawing.Point(8, 96)
		Me.lblVarValueType.Name = "lblVarValueType"
		Me.lblVarValueType.Size = New System.Drawing.Size(72, 16)
		Me.lblVarValueType.TabIndex = 18
		Me.lblVarValueType.Text = "Value Type : "
		Me.lblVarValueType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tboxVarMethod
		'
		Me.tboxVarMethod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tboxVarMethod.Location = New System.Drawing.Point(60, 184)
		Me.tboxVarMethod.Name = "tboxVarMethod"
		Me.tboxVarMethod.ReadOnly = True
		Me.tboxVarMethod.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
		Me.tboxVarMethod.Size = New System.Drawing.Size(692, 20)
		Me.tboxVarMethod.TabIndex = 17
		'
		'lblVarDataType
		'
		Me.lblVarDataType.BackColor = System.Drawing.SystemColors.Control
		Me.lblVarDataType.Location = New System.Drawing.Point(8, 124)
		Me.lblVarDataType.Name = "lblVarDataType"
		Me.lblVarDataType.Size = New System.Drawing.Size(72, 16)
		Me.lblVarDataType.TabIndex = 13
		Me.lblVarDataType.Text = "Data Type : "
		Me.lblVarDataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'cboxVariable
		'
		Me.cboxVariable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cboxVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboxVariable.FormattingEnabled = True
		Me.cboxVariable.Location = New System.Drawing.Point(60, 14)
		Me.cboxVariable.Name = "cboxVariable"
		Me.cboxVariable.Size = New System.Drawing.Size(284, 21)
		Me.cboxVariable.TabIndex = 11
		'
		'lblVarUnits
		'
		Me.lblVarUnits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblVarUnits.BackColor = System.Drawing.SystemColors.Control
		Me.lblVarUnits.Location = New System.Drawing.Point(352, 18)
		Me.lblVarUnits.Name = "lblVarUnits"
		Me.lblVarUnits.Size = New System.Drawing.Size(40, 16)
		Me.lblVarUnits.TabIndex = 7
		Me.lblVarUnits.Text = "Units : "
		Me.lblVarUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblVariable
		'
		Me.lblVariable.BackColor = System.Drawing.SystemColors.Control
		Me.lblVariable.Location = New System.Drawing.Point(8, 17)
		Me.lblVariable.Name = "lblVariable"
		Me.lblVariable.Size = New System.Drawing.Size(52, 16)
		Me.lblVariable.TabIndex = 5
		Me.lblVariable.Text = "Variable : "
		Me.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblVarMethod
		'
		Me.lblVarMethod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblVarMethod.BackColor = System.Drawing.SystemColors.Control
		Me.lblVarMethod.Location = New System.Drawing.Point(8, 186)
		Me.lblVarMethod.Name = "lblVarMethod"
		Me.lblVarMethod.Size = New System.Drawing.Size(52, 16)
		Me.lblVarMethod.TabIndex = 4
		Me.lblVarMethod.Text = "Method : "
		Me.lblVarMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblDSSite
		'
		Me.lblDSSite.BackColor = System.Drawing.SystemColors.Control
		Me.lblDSSite.Location = New System.Drawing.Point(8, 16)
		Me.lblDSSite.Name = "lblDSSite"
		Me.lblDSSite.Size = New System.Drawing.Size(32, 16)
		Me.lblDSSite.TabIndex = 0
		Me.lblDSSite.Text = "Site : "
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCancel.Location = New System.Drawing.Point(648, 486)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(136, 24)
		Me.btnCancel.TabIndex = 2
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnDeriveNewDS
		'
		Me.btnDeriveNewDS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnDeriveNewDS.Location = New System.Drawing.Point(504, 486)
		Me.btnDeriveNewDS.Name = "btnDeriveNewDS"
		Me.btnDeriveNewDS.Size = New System.Drawing.Size(136, 24)
		Me.btnDeriveNewDS.TabIndex = 3
		Me.btnDeriveNewDS.Text = "Derive New Data Series"
		Me.btnDeriveNewDS.UseVisualStyleBackColor = True
		'
		'frmDeriveNewDataSeries
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.AutoScroll = True
		Me.ClientSize = New System.Drawing.Size(792, 518)
		Me.Controls.Add(Me.btnDeriveNewDS)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.gboxDSAttributes)
		Me.Controls.Add(Me.gboxDeriveInfo)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(750, 545)
		Me.Name = "frmDeriveNewDataSeries"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Derive A New Data Series"
		Me.gboxDeriveInfo.ResumeLayout(False)
		Me.gboxMethodInfo.ResumeLayout(False)
		Me.gboxMethodInfo.PerformLayout()
		Me.gboxCreateNewMethodDesc.ResumeLayout(False)
		Me.gboxCreateNewMethodDesc.PerformLayout()
		Me.gboxSelectExistingMethodDesc.ResumeLayout(False)
		Me.gboxMethodType.ResumeLayout(False)
		Me.gboxMethodType.PerformLayout()
		Me.gboxSmooth.ResumeLayout(False)
		Me.gboxSmooth.PerformLayout()
		Me.gboxAggregate.ResumeLayout(False)
		Me.gboxAggregate.PerformLayout()
		Me.gboxAlgebraic.ResumeLayout(False)
		Me.gboxAlgebraic.PerformLayout()
		Me.gboxDSAttributes.ResumeLayout(False)
		Me.gboxDSAttributes.PerformLayout()
		Me.gboxDSVariable.ResumeLayout(False)
		Me.gboxDSVariable.PerformLayout()
		Me.gboxVarSource.ResumeLayout(False)
		Me.gboxVarSource.PerformLayout()
		Me.gboxVarTimeSupport.ResumeLayout(False)
		Me.gboxVarTimeSupport.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents gboxDeriveInfo As System.Windows.Forms.GroupBox
	Friend WithEvents gboxMethodType As System.Windows.Forms.GroupBox
	Friend WithEvents gboxMethodInfo As System.Windows.Forms.GroupBox
	Friend WithEvents rbtnCreateDS_QCLevel1 As System.Windows.Forms.RadioButton
	Friend WithEvents gboxAggregate As System.Windows.Forms.GroupBox
	Friend WithEvents gboxAlgebraic As System.Windows.Forms.GroupBox
	Friend WithEvents rbtnAgg_Avg As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnAgg_Min As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnAgg_Max As System.Windows.Forms.RadioButton
	Friend WithEvents lblAlg_y As System.Windows.Forms.Label
	Friend WithEvents lblAlg_BplusC As System.Windows.Forms.Label
	Friend WithEvents tboxAlg_B As System.Windows.Forms.TextBox
	Friend WithEvents lblAlg_AplusB As System.Windows.Forms.Label
	Friend WithEvents tboxAlg_A As System.Windows.Forms.TextBox
	Friend WithEvents lblAlg_F As System.Windows.Forms.Label
	Friend WithEvents lblAlg_EplusF As System.Windows.Forms.Label
	Friend WithEvents lblAlg_DplusE As System.Windows.Forms.Label
	Friend WithEvents tboxAlg_F As System.Windows.Forms.TextBox
	Friend WithEvents tboxAlg_E As System.Windows.Forms.TextBox
	Friend WithEvents tboxAlg_D As System.Windows.Forms.TextBox
	Friend WithEvents lblAlg_CplusD As System.Windows.Forms.Label
	Friend WithEvents tboxAlg_C As System.Windows.Forms.TextBox
	Friend WithEvents gboxSelectExistingMethodDesc As System.Windows.Forms.GroupBox
	Friend WithEvents cboxSelectExistingMethodDesc As System.Windows.Forms.ComboBox
	Friend WithEvents rbtnAutoGenMethodDesc As System.Windows.Forms.RadioButton
	Friend WithEvents gboxCreateNewMethodDesc As System.Windows.Forms.GroupBox
	Friend WithEvents tboxNewMethodDesc As System.Windows.Forms.TextBox
	Friend WithEvents gboxDSAttributes As System.Windows.Forms.GroupBox
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents btnDeriveNewDS As System.Windows.Forms.Button
	Friend WithEvents lblDSSite As System.Windows.Forms.Label
	Friend WithEvents gboxDSVariable As System.Windows.Forms.GroupBox
	Friend WithEvents lblVarUnits As System.Windows.Forms.Label
	Friend WithEvents lblVariable As System.Windows.Forms.Label
	Friend WithEvents lblVarMethod As System.Windows.Forms.Label
	Friend WithEvents tboxDSSite As System.Windows.Forms.TextBox
	Friend WithEvents tboxVarMethod As System.Windows.Forms.TextBox
	Friend WithEvents lblVarDataType As System.Windows.Forms.Label
	Friend WithEvents cboxVariable As System.Windows.Forms.ComboBox
	Friend WithEvents tboxVarGenCategory As System.Windows.Forms.TextBox
	Friend WithEvents tboxVarSampleMed As System.Windows.Forms.TextBox
	Friend WithEvents lblVarGenCategory As System.Windows.Forms.Label
	Friend WithEvents lblVarSampleMed As System.Windows.Forms.Label
	Friend WithEvents lblVarValueType As System.Windows.Forms.Label
	Friend WithEvents gboxVarTimeSupport As System.Windows.Forms.GroupBox
	Friend WithEvents tboxTSValue As System.Windows.Forms.TextBox
	Friend WithEvents lblTSUnits As System.Windows.Forms.Label
	Friend WithEvents lblTSValue As System.Windows.Forms.Label
	Friend WithEvents rbtnAggregate As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnCreateDS_Smoothed As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnCreateNewMethodDesc As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnSelectExistingMethodDesc As System.Windows.Forms.RadioButton
	Friend WithEvents rbtnAlgebraic As System.Windows.Forms.RadioButton
	Friend WithEvents lblVarQCLevel As System.Windows.Forms.Label
	Friend WithEvents gboxVarSource As System.Windows.Forms.GroupBox
	Friend WithEvents lblSourceDesc As System.Windows.Forms.Label
	Friend WithEvents lblSourceOrg As System.Windows.Forms.Label
	Friend WithEvents tboxSourceDesc As System.Windows.Forms.TextBox
	Friend WithEvents tboxSourceOrg As System.Windows.Forms.TextBox
	Friend WithEvents ttipDeriveNewDS As System.Windows.Forms.ToolTip
	Friend WithEvents tboxVarDataType As System.Windows.Forms.TextBox
	Friend WithEvents tboxVarValueType As System.Windows.Forms.TextBox
	Friend WithEvents cboxVarQCLevel As System.Windows.Forms.ComboBox
	Friend WithEvents gboxSmooth As System.Windows.Forms.GroupBox
	Friend WithEvents tboxSmooth_WindowVal As System.Windows.Forms.TextBox
	Friend WithEvents lblSmooth_Window As System.Windows.Forms.Label
	Friend WithEvents lblSmooth_WindowUnits As System.Windows.Forms.Label
	Friend WithEvents tboxSourceCitation As System.Windows.Forms.TextBox
	Friend WithEvents lblSourceCitation As System.Windows.Forms.Label
	Friend WithEvents lblVarSpeciation As System.Windows.Forms.Label
	Friend WithEvents tboxVarSpeciation As System.Windows.Forms.TextBox
	Friend WithEvents tboxVarUnits As System.Windows.Forms.TextBox
	Friend WithEvents tboxTSUnits As System.Windows.Forms.TextBox
End Class
