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
''' Form to create a new record in the Sources table
''' </summary>
''' <remarks></remarks>
Public Class frmNewSource
    'Last Documented 1/1/1

#Region " Member Variables "

    ''' <summary>
    ''' Query to load schema Sources and create Update and Insert methods when needed
    ''' </summary>
    ''' <remarks></remarks>
    Const SQLQuery As String = "SELECT * FROM " & db_tbl_Sources
    ''' <summary>
    ''' Data table to store old Sources to ensure no exact replicas
    ''' </summary>
    ''' <remarks></remarks>
    Dim Sources As DataTable
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
    ''' Returns the ID of the newly generated site
    ''' </summary>
    ''' <returns>The ID of the newly generated site, -99 if site not created</returns>
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
    ''' <param name="e_connSettings">The connection settings to the database</param>
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
    Private Sub frmNewSource_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadMetadata()
            Sources = OpenTable("Sources", SQLQuery, m_connSettings)
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
            Dim duplicates() As DataRow = Sources.Select(db_fld_SrcOrg & " = '" & FormatForDB(txtOrganization.Text) & "' and " & db_fld_SrcDesc & " = '" & FormatForDB(txtDescription.Text) & "' and " & db_fld_SrcContactName & " = '" & FormatForDB(txtContactName.Text) & "' and " & db_fld_SrcPhone & " = '" & FormatForDB(txtContactPhone.Text) & "' and " & db_fld_SrcEmail & " = '" & FormatForDB(txtEmail.Text) & "' and " & db_fld_SrcAddress & " = '" & FormatForDB(txtContactAddress.Text) & "' and " & db_fld_SrcCity & " = '" & FormatForDB(txtCity.Text) & "' and " & db_fld_SrcState & " = '" & FormatForDB(txtState.Text) & "' and " & db_fld_SrcZip & " = '" & FormatForDB(txtZipCode.Text) & "' and " & db_fld_SrcMetaID & " = '" & FormatForDB(cboISOMetadata.SelectedValue) & "' and " & db_fld_SrcCitation & " = '" & FormatForDB(txtCitation.Text) & "'")
            If (duplicates.Length > 0) Then
                MsgBox("That Source Already Exists in the Database.")
            Else
                Dim newSource As DataRow = Sources.NewRow
                newSource.Item(db_fld_SrcOrg) = txtOrganization.Text
                newSource.Item(db_fld_SrcDesc) = txtDescription.Text
                newSource.Item(db_fld_SrcContactName) = txtContactName.Text
                newSource.Item(db_fld_SrcPhone) = txtContactPhone.Text
                newSource.Item(db_fld_SrcEmail) = txtEmail.Text
                newSource.Item(db_fld_SrcAddress) = txtContactAddress.Text
                newSource.Item(db_fld_SrcCity) = txtCity.Text
                newSource.Item(db_fld_SrcState) = txtState.Text
                newSource.Item(db_fld_SrcZip) = txtZipCode.Text
                newSource.Item(db_fld_SrcCitation) = txtCitation.Text
                newSource.Item(db_fld_SrcMetaID) = cboISOMetadata.SelectedValue
                newSource.Item(db_fld_SrcLink) = txtLink.Text
                Sources.Rows.Add(newSource)
                CommitTable(Sources, SQLQuery, m_connSettings)
                Dim newSources() As DataRow = Sources.Select(db_fld_SrcOrg & " = '" & FormatForDB(txtOrganization.Text) & "' and " & db_fld_SrcDesc & " = '" & FormatForDB(txtDescription.Text) & "' and " & db_fld_SrcContactName & " = '" & FormatForDB(txtContactName.Text) & "' and " & db_fld_SrcPhone & " = '" & FormatForDB(txtContactPhone.Text) & "' and " & db_fld_SrcEmail & " = '" & FormatForDB(txtEmail.Text) & "' and " & db_fld_SrcAddress & " = '" & FormatForDB(txtContactAddress.Text) & "' and " & db_fld_SrcCity & " = '" & FormatForDB(txtCity.Text) & "' and " & db_fld_SrcState & " = '" & FormatForDB(txtState.Text) & "' and " & db_fld_SrcZip & " = '" & FormatForDB(txtZipCode.Text) & "' and " & db_fld_SrcMetaID & " = '" & FormatForDB(cboISOMetadata.SelectedValue) & "' and " & db_fld_SrcCitation & " = '" & FormatForDB(txtCitation.Text) & "'")
                If newSources.Length = 1 Then
                    NewID = newSources(0).Item(db_fld_SrcID)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    NewID = -99
                    ShowError("Unable to retrieve the new Source from the database.")
                End If
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    ''' <summary>
    ''' Loads ISOMetadata for dropdowns
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMetadata()
        Try
            Dim temptable As DataTable 'Temporary dataTable to store Metadata

            temptable = GetMetadata(m_connSettings)
            'temptable.Rows.Add(New String() {db_expr_New, db_expr_New})
            cboISOMetadata.DisplayMember = db_expr_View
            cboISOMetadata.ValueMember = db_expr_ID
            cboISOMetadata.DataSource = temptable
            cboISOMetadata.SelectedIndex = -1

            temptable = Nothing
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

#End Region

#Region " Validation Functions "

    ''' <summary>
    ''' Adds a new ISOMetadata record to the database and dropdown
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim newMetadata As New frmNewISOMetadata(m_connSettings) 'Dialog to create new Metadata
            If newMetadata.ShowDialog() = Windows.Forms.DialogResult.OK Then
                LoadMetadata()
                cboISOMetadata.SelectedValue = newMetadata.ID
            Else
                cboISOMetadata.SelectedIndex = -1
            End If

            btnOK.Enabled = isDone()
        Catch ex As Exception
            ShowError(ex)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Try
    End Sub
    ''' <summary>
    ''' Clears txtContactPhone when selected
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub txtContactPhone_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtContactPhone.MouseClick
        txtContactPhone.SelectionStart = 0
    End Sub
    ''' <summary>
    ''' Clears txtZipCode when selected
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub txtZipCode_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtZipCode.MouseClick
        txtZipCode.SelectionStart = 0
    End Sub
    ''' <summary>
    ''' Validates short text fields using modCommon.g_Pattern_ShortText
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub ShortText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrganization.TextChanged, txtContactName.TextChanged, txtContactAddress.TextChanged, txtCity.TextChanged, txtState.TextChanged, txtEmail.TextChanged, txtLink.TextChanged
        If (Regex.Matches(sender.Text, g_Pattern_SiteVarCode).Count > 0) Then
            Dim Start As Integer = sender.SelectionStart
            Dim First As String = sender.Text.Substring(0, Start)
            Dim Last As String = sender.Text.Substring(Start)

            First = Regex.Replace(First, g_Pattern_ShortText, "")

            Last = Regex.Replace(Last, g_Pattern_ShortText, "")

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
    Private Sub LongText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged, txtCitation.TextChanged
        'CheckRequirements()
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks if the form is complete and valid
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub cboISOMetadata_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboISOMetadata.SelectedIndexChanged
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Returns true if the form is complete and valid
    ''' </summary>
    ''' <returns>True if the form is complete and valid</returns>
    ''' <remarks></remarks>
    Private Function isDone() As Boolean
        Try
            If (txtOrganization.Text <> "") And (txtDescription.Text <> "") And (txtContactName.Text <> "") And (txtContactPhone.Text <> "") And (txtContactAddress.Text <> "") And (txtEmail.Text <> "") And (txtCity.Text <> "") And (txtState.Text <> "") And (txtZipCode.Text <> "") Then
                If (cboISOMetadata.SelectedIndex >= 0) Then
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

End Class