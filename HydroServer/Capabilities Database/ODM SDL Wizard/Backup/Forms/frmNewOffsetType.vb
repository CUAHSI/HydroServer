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
''' Form to create a new record in the OffsetTypes table
''' </summary>
''' <remarks></remarks>
Public Class frmNewOffsetType
    'Last Documented 1/1/1

#Region " Member Variables "

    ''' <summary>
    ''' The query used to create OffsetTypes and generate insert/update statements when required
    ''' </summary>
    ''' <remarks></remarks>
    Const SQLQuery As String = "SELECT * FROM " & db_tbl_OffsetTypes
    ''' <summary>
    ''' DataTable to store old OffsetTypes to ensure no exact replicas
    ''' </summary>
    ''' <remarks></remarks>
    Dim OffsetTypes As DataTable
    ''' <summary>
    ''' ID for the new Offset Type, if none created = -99.
    ''' </summary>
    ''' <remarks></remarks>
    Dim NewID As Integer = -99
    ''' <summary>
    ''' The connection settings of the database
    ''' </summary>
    ''' <remarks></remarks>
    Private m_connSettings As clsConnectionSettings

#End Region

#Region " Properties "

    ''' <summary>
    ''' The ID of the new OffsetTypes record
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ID() As Integer
        Get
            Return NewID
        End Get
    End Property

#End Region

#Region " Form Functions "

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="e_connSettings">the connection settings of the database</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_connSettings As clsConnectionSettings)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_connSettings = e_connSettings
    End Sub
    ''' <summary>
    ''' Prepares the form, loads dropdowns, loads validation data
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub frmNewOffsetType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim temptable As DataTable 'Temporary dataTable to store the units.

            OffsetTypes = OpenTable("Sites", SQLQuery, m_connSettings)

            temptable = GetUnits(m_connSettings)
            cboUnits.DisplayMember = db_expr_View
            cboUnits.ValueMember = db_expr_ID
            cboUnits.DataSource = temptable

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
            Dim duplicates() As DataRow = OffsetTypes.Select(db_fld_OTUnitsID & " = '" & cboUnits.SelectedValue & "' and " & db_fld_OTDesc & " = '" & FormatForDB(txtDescription.Text) & "'")
            If (duplicates.Length > 0) Then
                ShowError("That OffsetType Already Exists in the Database.")
            Else
                Dim newOffsetType As DataRow = OffsetTypes.NewRow
                newOffsetType.Item(db_fld_OTUnitsID) = cboUnits.SelectedValue
                newOffsetType.Item(db_fld_OTDesc) = txtDescription.Text
                OffsetTypes.Rows.Add(newOffsetType)
                CommitTable(OffsetTypes, SQLQuery, m_connSettings)
                Dim newOffsetTypes() As DataRow = OffsetTypes.Select(db_fld_OTUnitsID & " = '" & cboUnits.SelectedValue & "' and " & db_fld_OTDesc & " = '" & FormatForDB(txtDescription.Text) & "'")
                If newOffsetTypes.Length = 1 Then
                    NewID = newOffsetTypes(0).Item(db_fld_OTID)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    NewID = -99
                    ShowError("Unable to retrieve the new Offset Type from the database.")
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
    ''' Checks whether the form is complete.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub TextField_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks whether the form is complete.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnits.SelectedIndexChanged
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks if all required data is entered
    ''' </summary>
    ''' <returns>returns true if the form is valid and complete</returns>
    ''' <remarks></remarks>
    Private Function isDone() As Boolean
        Return ((txtDescription.Text <> "") And (cboUnits.SelectedValue <> ""))
    End Function

#End Region

End Class