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
''' Form to create a new record in the Methods table.
''' </summary>
''' <remarks></remarks>
Public Class frmNewMethod
    'Last Documented 1/1/1

#Region " Member Variables "

    ''' <summary>
    ''' Query used to fill Methods and generate insert/update statements when necessary
    ''' </summary>
    ''' <remarks></remarks>
    Const sqlQuery As String = "SELECT * FROM " & db_tbl_Methods
    ''' <summary>
    ''' DataTable to store old Methods to ensure no exact replicas.
    ''' </summary>
    ''' <remarks></remarks>
    Dim Methods As DataTable
    ''' <summary>
    ''' ID for the new Method, when none created = -99
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
    ''' The ID of the newly created record in the Methods table
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
    ''' <param name="e_connSettings">The connection settings of the database</param>
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
    Private Sub frmNewMethod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Methods = OpenTable("Methods", sqlQuery, m_connSettings)
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
            Dim duplicates() As DataRow = Methods.Select(db_fld_MethDesc & " = '" & FormatForDB(txtDescription.Text) & "'")
            If (duplicates.Length > 0) Then
                MsgBox("That Method Already Exists in the Database.")
            Else
                Dim newMethod As DataRow = Methods.NewRow
                newMethod.Item(db_fld_MethDesc) = txtDescription.Text
                newMethod.Item(db_fld_MethLink) = txtLink.Text
                Methods.Rows.Add(newMethod)
                CommitTable(Methods, sqlQuery, m_connSettings)
                Dim newMethods() As DataRow = Methods.Select(db_fld_MethDesc & " = '" & FormatForDB(txtDescription.Text) & "'")
                If newMethods.Length = 1 Then
                    NewID = newMethods(0).Item(db_fld_MethID)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    NewID = -99
                    ShowError("Unable to retrieve the new Method from the database.")
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
    Private Sub ShortText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLink.TextChanged
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
    Private Sub LongText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks if all required data is entered
    ''' </summary>
    ''' <returns>returns true if the form is valid and complete</returns>
    ''' <remarks></remarks>
    Private Function isDone() As Boolean
        Return (txtDescription.Text <> "")
    End Function

#End Region

End Class