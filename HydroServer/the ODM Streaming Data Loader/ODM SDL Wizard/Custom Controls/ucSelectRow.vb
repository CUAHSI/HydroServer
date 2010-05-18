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
''' Custom control used to make defining a data series easier.
''' </summary>
''' <remarks></remarks>
Public Class ucSelectRow
    'Last Documented 8/31/07

#Region " Member Variables "

    ''' <summary>
    ''' Used to Determine which table is being worked with
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum TableNames
        Method
        OffsetTypes
        QCLevel
        Site
        Source
        Variable
    End Enum
    ''' <summary>
    ''' Used to Store all the existing values from the current table
    ''' </summary>
    ''' <remarks></remarks>
    Private m_data As DataTable '
    ''' <summary>
    ''' The current table being worked on
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Table As TableNames
    ''' <summary>
    ''' The current connection settings
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Connection As clsConnectionSettings

#End Region

#Region " Events "

    ''' <summary>
    ''' Reports when a selection has been changed
    ''' </summary>
    ''' <remarks></remarks>
    Public Event SelectionChanged()
    ''' <summary>
    ''' Reports when an error has occurred
    ''' </summary>
    ''' <param name="ex">The exception that describes the error</param>
    ''' <remarks></remarks>
    Public Event ErrorOccured(ByVal ex As Exception)

#End Region

#Region " Member Functions "

    ''' <summary>
    ''' Sets the current table to e_table and loads initial data.
    ''' </summary>
    ''' <param name="e_Table">an enum describing which type of table to load</param>
    ''' <param name="e_Connection">the connection settings to use to connect to the database</param>
    ''' <param name="e_Default">The row to start selected</param>
    ''' <param name="e_OffsetValue">The offset value to start with</param>
    ''' <remarks></remarks>
    Public Sub ResetData(ByVal e_Table As TableNames, ByVal e_Connection As clsConnectionSettings, ByVal e_Default As String, Optional ByVal e_OffsetValue As String = "") '
        Try
            m_Table = e_Table
            m_Connection = e_Connection

            lblTitle.Text = Title()

            LoadData()

            If (e_Default = db_expr_None) Then
                e_Default = Int32.MinValue
            End If

            If (e_Default <> "") And (Not (m_data Is Nothing)) Then '
                Dim i As Integer 'Counter Variable
                For i = 0 To (dgvData.Rows.Count - 1)
                    If (dgvData.Rows(i).Cells(ReturnField).Value = e_Default) Then
                        dgvData.Rows(i).Selected = True
                        Exit For
                    End If
                Next
            End If
            If (e_Table = TableNames.OffsetTypes) And (e_OffsetValue <> "") Then
                txtOTVal.Text = e_OffsetValue
            End If

            btnAdd.Visible = True
            txtOTVal.Visible = (m_Table = TableNames.OffsetTypes)
            lblOTVal.Visible = (m_Table = TableNames.OffsetTypes)
            btnCopy.Visible = (m_Table = TableNames.Variable)
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex)
        End Try
    End Sub
    ''' <summary>
    ''' Returns the currently selected value.
    ''' </summary>
    ''' <returns>Currently selected value</returns>
    ''' <remarks></remarks>
    Public Function SelectedValue() As String
        Try
            If dgvData.SelectedRows.Count > 0 Then
                If (m_Table = TableNames.OffsetTypes) AndAlso (dgvData.SelectedRows(0).Cells(ReturnField).Value = Int32.MinValue) Then
                    Return db_expr_None
                Else
                    Return dgvData.SelectedRows(0).Cells(ReturnField).Value
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex)
        End Try
        Return ""
    End Function
    ''' <summary>
    ''' Returns the current offset value (if valid)
    ''' </summary>
    ''' <returns>Current offset value as string</returns>
    ''' <remarks></remarks>
    Public Function SelectedOffsetValue() As String
        Try
            If (m_Table = TableNames.OffsetTypes) Then
                If (dgvData.SelectedRows.Count = 0) OrElse (dgvData.SelectedRows(0).Cells(db_fld_OTID).Value = Int32.MinValue) Then
                    Return db_expr_None
                Else
                    Return Val(txtOTVal.Text)
                End If
            End If
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex)
        End Try
        Return ""
    End Function
    ''' <summary>
    ''' Loads initial data
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()
        Try
            Dim sql As String 'Holds the SQL Command used to retrieve data from the database.

            Select Case m_Table
                Case TableNames.Method
                    sql = "SELECT * FROM " & _
                    db_tbl_Methods & _
                    " ORDER BY " & db_fld_MethDesc & ", " & db_fld_MethLink
                Case TableNames.OffsetTypes
                    sql = "SELECT " & _
                    db_tbl_OffsetTypes & "." & db_fld_OTID & ", " & _
                    db_tbl_Units & "." & db_fld_UnitsName & ", " & _
                    db_tbl_OffsetTypes & "." & db_fld_OTDesc & " FROM " & _
                    db_tbl_OffsetTypes & " LEFT OUTER JOIN " & _
                    db_tbl_Units & " ON " & _
                    db_tbl_OffsetTypes & "." & db_fld_OTUnitsID & " = " & _
                    db_tbl_Units & "." & db_fld_UnitsID & " ORDER BY " & _
                    db_tbl_Units & "." & db_fld_UnitsName & ", " & _
                    db_tbl_OffsetTypes & "." & db_fld_OTDesc
                Case TableNames.QCLevel
                    sql = "SELECT * FROM " & _
                    db_tbl_QCLevels & _
                    " ORDER BY " & db_fld_QCLQCLevelCode & ", " & db_fld_QCLDefinition
                Case TableNames.Source
                    sql = "SELECT " & _
                    db_tbl_Sources & "." & db_fld_SrcID & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcOrg & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcDesc & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcLink & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcContactName & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcPhone & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcEmail & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcAddress & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcCity & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcState & ", " & _
                    db_tbl_Sources & "." & db_fld_SrcZip & ", " & _
                    db_tbl_ISOMetaData & "." & db_fld_IMDTitle & " AS " & db_expr_MetaTitle & ", " & _
                    db_tbl_ISOMetaData & "." & db_fld_IMDAbstract & " AS " & db_expr_MetaAbstract & " FROM " & _
                    db_tbl_Sources & " LEFT OUTER JOIN " & _
                    db_tbl_ISOMetaData & " ON " & _
                    db_tbl_Sources & "." & db_fld_SrcMetaID & " = " & _
                    db_tbl_ISOMetaData & "." & db_fld_IMDMetaID
                Case TableNames.Variable
                    sql = "SELECT " & _
                    db_tbl_Variables & "." & db_fld_VarID & ", " & _
                    db_tbl_Variables & "." & db_fld_VarCode & ", " & _
                    db_tbl_Variables & "." & db_fld_VarName & ", " & _
                    db_tbl_Variables & "." & db_fld_VarSpec & ", " & _
                    db_expr_VarUnits & "." & db_fld_UnitsName & " AS " & db_expr_VarUnitsName & ", " & _
                    db_tbl_Variables & "." & db_fld_VarSampleMed & ", " & _
                    db_tbl_Variables & "." & db_fld_VarValueType & ", " & _
                    db_tbl_Variables & "." & db_fld_VarIsRegular & ", " & _
                    db_tbl_Variables & "." & db_fld_VarTimeSupport & ", " & _
                    db_expr_TimeUnits & "." & db_fld_UnitsName & " AS " & db_expr_TimeUnitsName & ", " & _
                    db_tbl_Variables & "." & db_fld_VarDataType & ", " & _
                    db_tbl_Variables & "." & db_fld_VarGenCat & ", " & _
                    db_tbl_Variables & "." & db_fld_VarNoDataVal & " FROM " & _
                    db_tbl_Variables & " LEFT OUTER JOIN " & _
                    db_tbl_Units & " AS " & db_expr_TimeUnits & " ON " & _
                    db_tbl_Variables & "." & db_fld_VarTimeUnitsID & " = " & _
                    db_expr_TimeUnits & "." & db_fld_UnitsID & " LEFT OUTER JOIN " & _
                    db_tbl_Units & " AS " & db_expr_VarUnits & " ON " & _
                    db_tbl_Variables & "." & db_fld_VarUnitsID & " = " & _
                    db_expr_VarUnits & "." & db_fld_UnitsID
                Case Else 'Sites
                    sql = "SELECT * FROM " & db_tbl_Sites & " ORDER BY " & db_fld_SiteCode & ", " & db_fld_SiteName
            End Select

            m_data = Nothing
            m_data = OpenTable("DATA", sql, m_Connection)

            If Not (m_data Is Nothing) Then
                dgvData.DataSource = m_data
                dgvData.Columns(ReturnField).Visible = False
                If m_Table = TableNames.OffsetTypes Then
                    Dim newRow As DataRow = m_data.NewRow 'Temporary row of data to add to m_data
                    newRow.ItemArray = New String() {Int32.MinValue, db_expr_None, db_expr_None}
                    If m_data.Rows.Count = 0 Then
                        m_data.Rows.Add(newRow)
                    Else
                        m_data.Rows.InsertAt(newRow, 0)
                    End If

                End If
            End If
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex)
        End Try
    End Sub
    ''' <summary>
    ''' Performs validation when the selection is changed.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub dgvData_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvData.SelectionChanged
        Try
            If (m_Table = TableNames.OffsetTypes) Then
                If (dgvData.SelectedRows.Count > 0) AndAlso (dgvData.SelectedRows(0).Cells(db_fld_OTID).Value = Int32.MinValue) Then
                    txtOTVal.Text = db_expr_None
                    txtOTVal.Enabled = False
                    lblOTVal.Enabled = False
                Else
                    txtOTVal.Text = 0
                    txtOTVal.Enabled = True
                    lblOTVal.Enabled = True
                End If
            End If

            If (m_Table = TableNames.Variable) Then
                btnCopy.Enabled = (dgvData.SelectedRows.Count > 0)
            End If

            RaiseEvent SelectionChanged()
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex)
        End Try
    End Sub
    ''' <summary>
    ''' Performs validation when the offset value is changed.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub NumericField_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOTVal.TextChanged
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
        'btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Opens the correct frmNew____ dialog when clicked
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim NewRowID As Integer = -99
            Select Case m_Table
                Case TableNames.Method
                    Dim NewRow As New frmNewMethod(m_Connection) 'Dialog box to create a new Method.
                    If NewRow.ShowDialog = DialogResult.OK Then
                        NewRowID = NewRow.ID
                    End If
                Case TableNames.OffsetTypes
                    Dim NewRow As New frmNewOffsetType(m_Connection) 'Dialog box to create a new Offset Type.
                    If NewRow.ShowDialog = DialogResult.OK Then
                        NewRowID = NewRow.ID
                    End If
                Case TableNames.QCLevel
                    Dim NewRow As New frmNewQCL(m_Connection) 'Dialog box to create a new Quality Control Level.
                    If NewRow.ShowDialog = DialogResult.OK Then
                        NewRowID = NewRow.ID
                    End If
                Case TableNames.Source
                    Dim NewRow As New frmNewSource(m_Connection) 'Dialog box to create a new Source.
                    If NewRow.ShowDialog = DialogResult.OK Then
                        NewRowID = NewRow.ID
                    End If
                Case TableNames.Variable
                    Dim NewRow As New frmNewVariable(m_Connection) 'Dialog box to create a new Variable.
                    If NewRow.ShowDialog = DialogResult.OK Then
                        NewRowID = NewRow.ID
                    End If
                Case Else 'Sites
                    Dim NewRow As New frmNewSite(m_Connection) 'Dialog box to create a new Site.
                    If NewRow.ShowDialog = DialogResult.OK Then
                        NewRowID = NewRow.ID
                    End If
            End Select
            LoadData()
            If (NewRowID <> -99) Then
                Dim i As Integer 'Counter Variable
                For i = 0 To (dgvData.Rows.Count - 1)
                    If (dgvData.Rows(i).Cells(ReturnField).Value = NewRowID) Then
                        dgvData.Rows(i).Selected = True
                    End If
                Next i
            End If

        Catch ex As Exception
            RaiseEvent ErrorOccured(ex)
        End Try
    End Sub
    ''' <summary>
    ''' Opens the NewVariable dialog with preset values.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Dim newRowID As Integer = -99
        If dgvData.SelectedRows.Count > 0 Then
            Select Case m_Table
                Case TableNames.Variable
                    Dim temp As New frmNewVariable(m_Connection, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarCode).Value, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarName).Value, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarSpec).Value, _
                    dgvData.SelectedRows(0).Cells(db_expr_VarUnitsName).Value, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarSampleMed).Value, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarValueType).Value, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarTimeSupport).Value, _
                    dgvData.SelectedRows(0).Cells(db_expr_TimeUnitsName).Value, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarDataType).Value, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarGenCat).Value, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarNoDataVal).Value, _
                    dgvData.SelectedRows(0).Cells(db_fld_VarIsRegular).Value) 'Dialog to create a similiar Variable to the selected Variable

                    If temp.ShowDialog = DialogResult.OK Then
                        newRowID = temp.ID
                    End If
                Case Else

            End Select

            LoadData()
            If (newRowID <> -99) Then
                Dim i As Integer 'Counter Variable
                For i = 0 To (dgvData.Rows.Count - 1)
                    If (dgvData.Rows(i).Cells(ReturnField).Value = newRowID) Then
                        dgvData.Rows(i).Selected = True
                    End If
                Next i
            End If
        End If
    End Sub
    ''' <summary>
    ''' Returns the name of the database field that is being selected.
    ''' </summary>
    ''' <returns>The name of the database field that will be returned</returns>
    ''' <remarks></remarks>
    Private Function ReturnField() As String
        Try
            Select Case m_Table
                Case TableNames.Method
                    Return db_fld_MethID
                Case TableNames.OffsetTypes
                    Return db_fld_OTID
                Case TableNames.QCLevel
                    Return db_fld_QCLQCLevelID
                Case TableNames.Source
                    Return db_fld_SrcID
                Case TableNames.Variable
                    Return db_fld_VarID
                Case Else 'Sites
                    Return db_fld_SiteID
            End Select
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex)
        End Try
        Return ""
    End Function
    ''' <summary>
    ''' Returns the Title (and instructions) for each table type
    ''' </summary>
    ''' <returns>Title and instructions</returns>
    ''' <remarks></remarks>
    Private Function Title() As String
        Try
            Select Case m_Table
                Case TableNames.Method
                    Return "Please Select a Method." & vbCrLf & "Press + to Create a New Method."
                Case TableNames.OffsetTypes
                    Return "Please Select a Offset Type and Offset Value." & vbCrLf & "Press + to Create a New Offset Type."
                Case TableNames.QCLevel
                    Return "Please Select a Quality Control Level." & vbCrLf
                Case TableNames.Source
                    Return "Please Select a Source." & vbCrLf & "Press + to Create a New Source."
                Case TableNames.Variable
                    Return "Please Select a Variable." & vbCrLf & "Press + to Create a New Variable."
                Case Else 'Sites
                    Return "Please Select a Site." & vbCrLf & "Press + to Create a New Site."
            End Select
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex)
        End Try
        Return ""
    End Function

#End Region

End Class
