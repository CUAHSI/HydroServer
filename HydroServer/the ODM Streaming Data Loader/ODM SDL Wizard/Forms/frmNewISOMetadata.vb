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
''' Form to create a new record in the ISOMetadata Table
''' </summary>
''' <remarks></remarks>
Public Class frmNewISOMetadata
    'Last Documented 8/31/07

#Region " Member Variables "

    ''' <summary>
    ''' The query use to fill Metadata and generate insert/update statements when necessary
    ''' </summary>
    ''' <remarks></remarks>
    Const SQLQuery As String = "SELECT * FROM " & db_tbl_ISOMetaData
    ''' <summary>
    ''' DataTable containing existing ISOMetadata to ensure no exact replicas.
    ''' </summary>
    ''' <remarks></remarks>
    Dim Metadata As DataTable
    ''' <summary>
    ''' ID for the ISOMetadata, if no metadata is created = -99.
    ''' </summary>
    ''' <remarks></remarks>
    Dim NewID As Integer = -99
    ''' <summary>
    ''' The Current connection settings
    ''' </summary>
    ''' <remarks></remarks>
    Private m_connSettings As clsConnectionSettings

#End Region

#Region " Properties "

    ''' <summary>
    ''' Returns the ID of the new ISOMetadata
    ''' </summary>
    ''' <returns>the ID of the new ISOMetadata</returns>
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
    ''' <param name="e_connSettings">sets the connection settings to use to connect to hte database</param>
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
    Private Sub frmNewISOMetadata_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Sets up the Form
        Try
            Dim temp() As String 'String array of Topic Categories

            temp = GetTopicCategories(m_connSettings)
            cboTopicCategory.Items.AddRange(temp)

            Metadata = OpenTable("Metadata", SQLQuery, m_connSettings)
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub
    ''' <summary>
    ''' Runs Validation, commits record to database, and returns dialog result
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Try
            Dim duplicates() As DataRow = Metadata.Select(db_fld_IMDTopicCat & " = '" & FormatForDB(cboTopicCategory.SelectedItem) & "' and " & db_fld_IMDTitle & " = '" & FormatForDB(txtTitle.Text) & "' and " & db_fld_IMDAbstract & " = '" & FormatForDB(txtAbstract.Text) & "' and " & db_fld_IMDProfileVs & " = '" & FormatForDB(txtProfileVs.Text) & "'")
            If (duplicates.Length > 0) Then
                ShowError("That Metadata Already Exists in the Database.")
            Else
                Dim newRow As DataRow = Metadata.NewRow
                newRow.Item(db_fld_IMDTopicCat) = cboTopicCategory.SelectedItem
                newRow.Item(db_fld_IMDTitle) = txtTitle.Text
                newRow.Item(db_fld_IMDAbstract) = txtAbstract.Text
                newRow.Item(db_fld_IMDProfileVs) = txtProfileVs.Text
                newRow.Item(db_fld_IMDMetaLink) = txtLink.Text
                Metadata.Rows.Add(newRow)
                CommitTable(Metadata, SQLQuery, m_connSettings)
                Dim newMetadata() As DataRow = Metadata.Select(db_fld_IMDTopicCat & " = '" & FormatForDB(cboTopicCategory.SelectedItem) & "' and " & db_fld_IMDTitle & " = '" & FormatForDB(txtTitle.Text) & "' and " & db_fld_IMDAbstract & " = '" & FormatForDB(txtAbstract.Text) & "' and " & db_fld_IMDProfileVs & " = '" & FormatForDB(txtProfileVs.Text) & "'")
                If newMetadata.Length = 1 Then
                    NewID = newMetadata(0).Item(db_fld_IMDMetaID)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    NewID = -99
                    ShowError("Unable to retrieve the new Metadata from the database.")
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
    ''' Validates text fields using a Regex defined in modcommon
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub ShortText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitle.TextChanged, txtProfileVs.TextChanged, txtLink.TextChanged
        If (Regex.Matches(sender.Text, g_Pattern_SiteVarCode).Count > 0) Then
            Dim Start As Integer = sender.SelectionStart
            Dim First As String = sender.Text.Substring(0, Start)
            Dim Last As String = sender.Text.Substring(Start)

            First = Regex.Replace(First, g_Pattern_ShortText, "")

            Last = Regex.Replace(Last, g_Pattern_ShortText, "")

            sender.Text = First & Last
            sender.SelectionStart = First.Length
        End If

        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks whether the form is complete.
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub LongText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAbstract.TextChanged
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks whether the form is complete
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTopicCategory.SelectedIndexChanged
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks if all required data is entered and not replica of old ISOMetadata
    ''' </summary>
    ''' <returns>returns true if the form is valid and complete</returns>
    ''' <remarks></remarks>
    Private Function isDone() As Boolean
        Try
            Return ((txtTitle.Text <> "") And (txtAbstract.Text <> "") And (txtProfileVs.Text <> "") And (cboTopicCategory.SelectedItem <> ""))
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Function

#End Region

End Class