'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..
Imports System.Text.RegularExpressions
''' <summary>
''' Form to create a new record in the Variables Table
''' </summary>
''' <remarks></remarks>
Public Class frmNewVariable
    'Last Documented 1/1/1

#Region " Member Variables "

    ''' <summary>
    ''' Query used to get the schema for Variables and generate Insert and Update methods when necessary
    ''' </summary>
    ''' <remarks></remarks>
    Const sqlQuery As String = "SELECT * FROM " & db_tbl_Variables
    ''' <summary>
    ''' DataTable to store old Variables to ensure no exact replicas
    ''' </summary>
    ''' <remarks></remarks>
    Dim Variables As DataTable
    ''' <summary>
    ''' ID for the new site, if none created = -99)
    ''' </summary>
    ''' <remarks></remarks>
    Dim NewID As Integer = -99
    ''' <summary>
    ''' The connection settings to the database
    ''' </summary>
    ''' <remarks></remarks>
    Private m_connSettings As clsConnectionSettings

#End Region

#Region " Properties "

    ''' <summary>
    ''' The ID of the newly generated Variable
    ''' </summary>
    ''' <value></value>
    ''' <returns>-99 If variable not created, otherwise the ID of the newly generated variable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ID() As Integer
        Get
            Return NewID
        End Get
    End Property

#End Region

#Region " Form Functions "

    ''' <summary>
    ''' Constructor to create a new record
    ''' </summary>
    ''' <param name="e_connSettings">The connection settings to the database</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_connSettings As clsConnectionSettings)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try

            m_connSettings = e_connSettings

            Dim temp() As String 'Temporary string array to store VariableNames, SampleMediums, ValueTypes, DataTypes, and GeneralCategories
            Dim tempTable As DataTable 'Temporary DataTable to store Units
            Dim i As Integer 'Counter Variable

            tempTable = GetUnits(m_connSettings)
            cboVariableUnits.DisplayMember = db_expr_View
            cboVariableUnits.ValueMember = db_expr_ID
            cboVariableUnits.DataSource = tempTable

            tempTable = GetUnits(m_connSettings)
            cboTimeSupportUnits.DisplayMember = db_expr_View
            cboTimeSupportUnits.ValueMember = db_expr_ID
            cboTimeSupportUnits.DataSource = tempTable

            temp = GetVariableNames(m_connSettings)
            cboVariableName.Items.AddRange(temp)

            temp = GetSpeciation(m_connSettings)
            cboSpeciation.Items.AddRange(temp)

            temp = GetSampleMediums(m_connSettings)
            cboSampleMedium.Items.AddRange(temp)
            For i = 0 To (cboSampleMedium.Items.Count - 1)
                If LCase(cboSampleMedium.Items(i)) = db_expr_Default Then
                    cboSampleMedium.SelectedIndex = i
                    Exit For
                End If
            Next

            temp = GetValueTypes(m_connSettings)
            cboValueType.Items.AddRange(temp)
            For i = 0 To (cboValueType.Items.Count - 1)
                If LCase(cboValueType.Items(i)) = db_expr_Default Then
                    cboValueType.SelectedIndex = i
                    Exit For
                End If
            Next

            temp = GetDataTypes(m_connSettings)
            cboDataType.Items.AddRange(temp)
            For i = 0 To (cboDataType.Items.Count - 1)
                If LCase(cboDataType.Items(i)) = db_expr_Default Then
                    cboDataType.SelectedIndex = i
                    Exit For
                End If
            Next

            temp = GetGeneralCategories(m_connSettings)
            cboGeneralCategory.Items.AddRange(temp)
            For i = 0 To (cboGeneralCategory.Items.Count - 1)
                If LCase(cboGeneralCategory.Items(i)) = db_expr_Default Then
                    cboGeneralCategory.SelectedIndex = i
                    Exit For
                End If
            Next

            cboIsRegular.SelectedItem = "False"

        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    ''' <summary>
    ''' Constructor to edit an existing record
    ''' </summary>
    ''' <param name="e_connSettings">The connection settings to the database</param>
    ''' <param name="e_VarCode">The variable code of the existing record</param>
    ''' <param name="e_VarName">The Variable name of the existing record</param>
    ''' <param name="e_Spec">The speciation of the existing record</param>
    ''' <param name="e_VarUnitsName">The units name of the existing record</param>
    ''' <param name="e_SampleMed">The sample medium of the existing record</param>
    ''' <param name="e_ValType">The value type of the existing record</param>
    ''' <param name="e_TSVal">The time support value of the existing record</param>
    ''' <param name="e_TSUnitsName">The time support units name of the existing record</param>
    ''' <param name="e_DataType">The data type of the existing record</param>
    ''' <param name="e_GenCat">The general category of the existing record</param>
    ''' <param name="e_NDV">The no data value of the existing record</param>
    ''' <param name="e_IsReg">Whether the existing variable is Regular or not</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_connSettings As clsConnectionSettings, ByVal e_VarCode As String, ByVal e_VarName As String, ByVal e_Spec As String, ByVal e_VarUnitsName As String, ByVal e_SampleMed As String, ByVal e_ValType As String, ByVal e_TSVal As String, ByVal e_TSUnitsName As String, ByVal e_DataType As String, ByVal e_GenCat As String, ByVal e_NDV As String, ByVal e_IsReg As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try

            m_connSettings = e_connSettings

            Dim temp() As String 'Temporary string array to store VariableNames, SampleMediums, ValueTypes, DataTypes, and GeneralCategories
            Dim tempTable As DataTable 'Temporary DataTable to store Units
            Dim i As Integer 'Counter Variable

            tempTable = GetUnits(m_connSettings)
            cboVariableUnits.DisplayMember = db_expr_View
            cboVariableUnits.ValueMember = db_expr_ID
            cboVariableUnits.DataSource = tempTable

            tempTable = GetUnits(m_connSettings)
            cboTimeSupportUnits.DisplayMember = db_expr_View
            cboTimeSupportUnits.ValueMember = db_expr_ID
            cboTimeSupportUnits.DataSource = tempTable

            temp = GetVariableNames(m_connSettings)
            cboVariableName.Items.AddRange(temp)

            temp = GetSpeciation(m_connSettings)
            cboSpeciation.Items.AddRange(temp)

            temp = GetSampleMediums(m_connSettings)
            cboSampleMedium.Items.AddRange(temp)

            temp = GetValueTypes(m_connSettings)
            cboValueType.Items.AddRange(temp)

            temp = GetDataTypes(m_connSettings)
            cboDataType.Items.AddRange(temp)

            temp = GetGeneralCategories(m_connSettings)
            cboGeneralCategory.Items.AddRange(temp)

            txtVariableCode.Text = e_VarCode
            cboVariableName.SelectedItem = e_VarName
            cboSpeciation.SelectedItem = e_Spec
            For i = 0 To (cboVariableUnits.Items.Count - 1)
                If (Split(cboVariableUnits.Items(i).item(1), " - ")(0) = e_VarUnitsName) Then
                    cboVariableUnits.SelectedIndex = i
                    Exit For
                End If
            Next
            cboSampleMedium.SelectedItem = e_SampleMed
            cboValueType.SelectedItem = e_ValType
            numTimeSupport.Value = Val(e_TSVal)
            For i = 0 To (cboTimeSupportUnits.Items.Count - 1)
                If (Split(cboTimeSupportUnits.Items(i).item(1), " - ")(0) = e_TSUnitsName) Then
                    cboTimeSupportUnits.SelectedIndex = i
                    Exit For
                End If
            Next
            cboDataType.SelectedItem = e_DataType
            cboGeneralCategory.SelectedItem = e_GenCat
            txtNoDataValue.Text = e_NDV
            cboIsRegular.SelectedItem = e_IsReg

        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    ''' <summary>
    ''' Prepares the form, loads dropdowns, loads validation data
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub frmNewVariable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Variables = OpenTable("Variables", sqlQuery, m_connSettings)
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    ''' <summary>
    ''' Runs Validation, commits record to database, and returns dialog result
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Dim duplicates() As DataRow = Variables.Select(db_fld_VarCode & " = '" & FormatForDB(txtVariableCode.Text) & "'")
            If (duplicates.Length > 0) Then
                MsgBox("That Variable Code Already Exists in the Database.")
            Else
                Dim newVariable As DataRow = Variables.NewRow
                newVariable.Item(db_fld_VarCode) = txtVariableCode.Text
                newVariable.Item(db_fld_VarName) = cboVariableName.SelectedItem
                newVariable.Item(db_fld_VarSpec) = cboSpeciation.SelectedItem
                newVariable.Item(db_fld_VarUnitsID) = cboVariableUnits.SelectedValue
                newVariable.Item(db_fld_VarSampleMed) = cboSampleMedium.SelectedItem
                newVariable.Item(db_fld_VarValueType) = cboValueType.SelectedItem
                newVariable.Item(db_fld_VarIsRegular) = cboIsRegular.SelectedItem
                newVariable.Item(db_fld_VarTimeSupport) = Val(numTimeSupport.Value)
                newVariable.Item(db_fld_VarTimeUnitsID) = cboTimeSupportUnits.SelectedValue
                newVariable.Item(db_fld_VarSpec) = cboSpeciation.SelectedItem
                newVariable.Item(db_fld_VarDataType) = cboDataType.SelectedItem
                newVariable.Item(db_fld_VarGenCat) = cboGeneralCategory.SelectedItem
                newVariable.Item(db_fld_VarNoDataVal) = Val(txtNoDataValue.Text)

                Variables.Rows.Add(newVariable)
                CommitTable(Variables, sqlQuery, m_connSettings)
                Dim newVariables() As DataRow = Variables.Select(db_fld_VarCode & " = '" & FormatForDB(txtVariableCode.Text) & "'")
                If (newVariables.Length = 1) Then
                    NewID = newVariables(0).Item(db_fld_VarID)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    NewID = -99
                    ShowError("Unable to retrieve the new Variable from the database.")
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

#End Region

#Region " Validation Functions "

    ''' <summary>
    ''' Ensures that all numeric fields are valid using regular expressions
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub NumericField_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoDataValue.TextChanged
        If (sender.text <> "") AndAlso (sender.text <> "-") Then
            If Not (Regex.IsMatch(sender.Text, g_Pattern_NumericExpression)) Then
                Dim Start As Integer = sender.SelectionStart
                Dim First As String = sender.Text.Substring(0, Start)
                Dim Last As String = sender.Text.Substring(Start)

                First = Regex.Replace(First, "[^\-\d\.]", "")
                Last = Regex.Replace(Last, "[^\-\d\.]", "")

                If (First.Length > 1) Then
                    If First.Substring(1).Contains("-") Then
                        If First.StartsWith("-") Then
                            First = First.Substring(1).Replace("-", "")
                        Else
                            First = "-" & First.Replace("-", "")
                        End If
                    End If
                End If
                Last = Last.Replace("-", "")
                If First.Contains(".") Then
                    First = First.Substring(0, First.IndexOf(".") + 1) & First.Substring(First.IndexOf(".") + 1).Replace(".", "")
                    Last = Last.Replace(".", "")
                ElseIf Last.Contains(".") Then
                    Last = Last.Substring(0, Last.IndexOf(".") + 1) & Last.Substring(Last.IndexOf(".") + 1).Replace(".", "")
                End If


                If (Regex.IsMatch(First & Last, g_Pattern_NumericExpression)) Or (First & Last = "") Or (First & Last = ".") Or (First & Last = "-") Then
                    sender.Text = First & Last
                    sender.SelectionStart = First.Length
                Else

                End If
            End If
        End If

        'CheckRequirements()
        btnOK.Enabled = isDone()
    End Sub


    ''' <summary>
    ''' Ensures that the VariableCode field is valid using regular expressions
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>>
    ''' <remarks></remarks>
    Private Sub VariableCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVariableCode.TextChanged
        If (Regex.Matches(sender.Text, g_Pattern_SiteVarCode).Count > 0) Then
            Dim Start As Integer = sender.SelectionStart
            Dim First As String = sender.Text.Substring(0, Start)
            Dim Last As String = sender.Text.Substring(Start)

            First = Regex.Replace(First, "[\040]", "_")
            First = Regex.Replace(First, "[,\+]", ".")
            First = Regex.Replace(First, "[=:;/\\]", "-")
            First = Regex.Replace(First, g_Pattern_SiteVarCode, "")

            Last = Regex.Replace(Last, "[\040]", "_")
            Last = Regex.Replace(Last, "[,\+]", ".")
            Last = Regex.Replace(Last, "[=:;/\\]", "-")
            Last = Regex.Replace(Last, g_Pattern_SiteVarCode, "")

            sender.Text = First & Last
            sender.SelectionStart = First.Length
        End If

        'CheckRequirements()
        btnOK.Enabled = isDone()
    End Sub

    ''' <summary>
    ''' Checks if the form is complete and valid
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVariableName.SelectedIndexChanged, cboVariableUnits.SelectedIndexChanged, cboSampleMedium.SelectedIndexChanged, cboValueType.SelectedIndexChanged, cboTimeSupportUnits.SelectedIndexChanged, cboDataType.SelectedIndexChanged, cboGeneralCategory.SelectedIndexChanged, cboIsRegular.SelectedIndexChanged
        btnOK.Enabled = isDone()
    End Sub

    ''' <summary>
    ''' Returns true if the form is complete and valid
    ''' </summary>
    ''' <returns>True if the form is complete and valid</returns>
    ''' <remarks></remarks>
    Private Function isDone() As Boolean
        Try
            Return ((txtVariableCode.Text <> "") AndAlso (cboVariableName.SelectedItem <> "") AndAlso (cboSpeciation.SelectedItem <> "") AndAlso (cboVariableUnits.SelectedValue <> "") AndAlso (cboSampleMedium.SelectedItem <> "") AndAlso (cboValueType.SelectedItem <> "") AndAlso (cboIsRegular.SelectedItem <> "") AndAlso (numTimeSupport.Value >= 0) AndAlso (cboTimeSupportUnits.SelectedValue <> "") AndAlso (cboDataType.SelectedItem <> "") AndAlso (cboGeneralCategory.SelectedItem <> "") AndAlso (txtNoDataValue.Text <> "") AndAlso (IsNumeric(txtNoDataValue.Text)))
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Function

#End Region

End Class