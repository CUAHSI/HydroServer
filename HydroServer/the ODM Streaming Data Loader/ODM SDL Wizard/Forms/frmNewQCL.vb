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
''' Form used to create a new record in the QualityControlLevels table
''' </summary>
''' <remarks></remarks>
Public Class frmNewQCL
    'Last Documented 1/1/1

#Region " Member Variables "

    ''' <summary>
    ''' The query used to fill qualityControlLevels and generate insert/update statements when needed
    ''' </summary>
    ''' <remarks></remarks>
    Const sqlQuery As String = "SELECT * FROM " & db_tbl_QCLevels
    ''' <summary>
    ''' Data table containing the old Sites to ensure no exact replicas.
    ''' </summary>
    ''' <remarks></remarks>
    Dim qualityControlLevels As DataTable
    ''' <summary>
    ''' ID for the new QualityControlLevel, if none created = -99)
    ''' </summary>
    ''' <remarks></remarks>
    Dim NewID As Integer = -99
    ''' <summary>
    ''' The connection settings for the database
    ''' </summary>
    ''' <remarks></remarks>
    Private m_connSettings As clsConnectionSettings

#End Region

#Region " Properties "

    ''' <summary>
    ''' The ID of the newly created record in the QualityControlLevels table
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
    Private Sub frmNewSite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            qualityControlLevels = OpenTable("QualityControlLevels", sqlQuery, m_connSettings)

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
            Dim repeats() As DataRow = qualityControlLevels.Select(db_fld_QCLQCLevelCode & " = '" & FormatForDB(txtQCLCode.Text) & "' AND " & db_fld_QCLDefinition & " = '" & FormatForDB(txtDefinition.Text) & "' AND " & db_fld_QCLExplanation & " = '" & FormatForDB(txtExplanation.Text) & "'")
            If (repeats.Length > 0) Then
                ShowError("That Quality Control Level Already Exists in the Database.")
            ElseIf (txtQCLCode.Text = "") Then
                ShowError("Quality Control Level Code cannot be NULL.")
            ElseIf (txtDefinition.Text = "") Then
                ShowError("Definition cannot be NULL.")
            ElseIf (txtExplanation.Text = "") Then
                ShowError("Explanation cannot be NULL.")
            Else
                Dim tempRow As DataRow = qualityControlLevels.NewRow
                tempRow.Item(db_fld_QCLQCLevelCode) = txtQCLCode.Text
                tempRow.Item(db_fld_QCLDefinition) = txtDefinition.Text
                tempRow.Item(db_fld_QCLExplanation) = txtExplanation.Text
                qualityControlLevels.Rows.Add(tempRow)
                CommitTable(qualityControlLevels, sqlQuery, m_connSettings)
                Dim AddedRows() As DataRow = qualityControlLevels.Select(db_fld_QCLQCLevelCode & " = '" & FormatForDB(txtQCLCode.Text) & "' AND " & db_fld_QCLDefinition & " = '" & FormatForDB(txtDefinition.Text) & "' AND " & db_fld_QCLExplanation & " = '" & FormatForDB(txtExplanation.Text) & "'")
                If (AddedRows.Length = 1) Then
                    NewID = Val(AddedRows(0).Item(db_fld_QCLQCLevelID))
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    ShowError("The New Quality Control Level was not correctly committed to the database.")
                End If
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
    Private Sub TextField_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExplanation.TextChanged, txtQCLCode.TextChanged, txtDefinition.TextChanged
        'CheckRequirements()
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks if all required data is entered
    ''' </summary>
    ''' <returns>returns true if the form is valid and complete</returns>
    ''' <remarks></remarks>
    Private Function isDone() As Boolean
        Try
            If ((txtQCLCode.Text <> "") And (txtDefinition.Text <> "") And (txtExplanation.Text <> "")) Then
                Return True
            End If
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
        Return False
    End Function

#End Region

End Class