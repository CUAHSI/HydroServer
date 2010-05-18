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
''' Form to create a new record in the Sites table
''' </summary>
''' <remarks></remarks>
Public Class frmNewSite
    'Last Documented 1/1/1

#Region " Member Variables "

    ''' <summary>
    ''' The query that loads Sites and generates the Insert/Update queries when necessary
    ''' </summary>
    ''' <remarks></remarks>
    Const sqlQuery As String = "SELECT * FROM " & db_tbl_Sites
    ''' <summary>
    ''' Data table containing the old Sites to ensure no exact replicas.
    ''' </summary>
    ''' <remarks></remarks>
    Dim Sites As DataTable
    ''' <summary>
    ''' The default Vertical Datum
    ''' </summary>
    ''' <remarks></remarks>
    Dim defaultVertDatum As Integer
    ''' <summary>
    ''' The default Local Projection ID
    ''' </summary>
    ''' <remarks></remarks>
    Dim defaultLocProj As Integer
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
    ''' The SiteID of the new record in the Sites table
    ''' </summary>
    ''' <value></value>
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
    Private Sub frmNewSite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim temp() As String 'Temporary string array to store Vertical Datum
            Dim tempTable As DataTable 'Temporary datatable to store SpatialReferences
            Dim i As Integer 'Counter Variable

            Sites = OpenTable("Sites", sqlQuery, m_connSettings)

            tempTable = GetSpatialReferences(m_connSettings)
            cboLatLongDatum.DisplayMember = db_expr_View
            cboLatLongDatum.ValueMember = db_expr_ID
            cboLatLongDatum.DataSource = tempTable

            tempTable = GetSpatialReferences(m_connSettings)
            cboLocalProjection.DisplayMember = db_expr_View
            cboLocalProjection.ValueMember = db_expr_ID
            cboLocalProjection.DataSource = tempTable
            cboLocalProjection.SelectedIndex = -1

            temp = GetVerticalDatum(m_connSettings)
            cboVerticalDatum.Items.AddRange(temp)

            For i = 0 To (cboVerticalDatum.Items.Count - 1)
                If LCase(cboVerticalDatum.Items(i)) = db_expr_Default Then
                    defaultVertDatum = i
                    Exit For
                End If
            Next
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
            Dim duplicates() As DataRow = Sites.Select(db_fld_SiteCode & " = '" & FormatForDB(txtSiteCode.Text) & "'")
            If (duplicates.Length > 0) Then
                ShowError("That Site Code Already Exists in the Database.")
            Else
                If IsNumeric(txtLatitude.Text) Then
                    If IsNumeric(txtLongitude.Text) Then
                        If (txtElevation_m.Text = "" Or IsNumeric(txtElevation_m.Text)) Then
                            If (txtLocalX.Text = "" Or IsNumeric(txtLocalX.Text)) Then
                                If (txtLocalY.Text = "" Or IsNumeric(txtLocalY.Text)) Then
                                    If (txtPosAccuracy.Text = "" Or IsNumeric(txtPosAccuracy.Text)) Then
                                        Dim newSite As DataRow = Sites.NewRow
                                        newSite.Item(db_fld_SiteCode) = txtSiteCode.Text
                                        newSite.Item(db_fld_SiteName) = txtSiteName.Text
                                        newSite.Item(db_fld_SiteLat) = txtLatitude.Text
                                        newSite.Item(db_fld_SiteLong) = txtLongitude.Text
                                        newSite.Item(db_fld_SiteLatLongDatumID) = cboLatLongDatum.SelectedValue
                                        newSite.Item(db_fld_SiteState) = txtState.Text
                                        newSite.Item(db_fld_SiteCounty) = txtCounty.Text
                                        newSite.Item(db_fld_SiteComments) = txtComments.Text

                                        If txtElevation_m.Text = "" Then
                                            newSite.Item(db_fld_SiteElev_m) = DBNull.Value
                                        Else
                                            newSite.Item(db_fld_SiteElev_m) = Val(txtElevation_m.Text)
                                        End If
                                        If txtLocalX.Text = "" Then
                                            newSite.Item(db_fld_SiteLocX) = DBNull.Value
                                        Else
                                            newSite.Item(db_fld_SiteLocX) = Val(txtLocalX.Text)
                                        End If
                                        If txtLocalY.Text = "" Then
                                            newSite.Item(db_fld_SiteLocY) = DBNull.Value
                                        Else
                                            newSite.Item(db_fld_SiteLocY) = Val(txtLocalY.Text)
                                        End If
                                        If txtPosAccuracy.Text = "" Then
                                            newSite.Item(db_fld_SitePosAccuracy_m) = DBNull.Value
                                        Else
                                            newSite.Item(db_fld_SitePosAccuracy_m) = Val(txtPosAccuracy.Text)
                                        End If
                                        If (cboLocalProjection.SelectedIndex < 0) Then
                                            newSite.Item(db_fld_SiteLocProjID) = DBNull.Value
                                        Else
                                            newSite.Item(db_fld_SiteLocProjID) = cboLocalProjection.SelectedValue
                                        End If
                                        If (cboVerticalDatum.SelectedItem = "") Or (cboVerticalDatum.SelectedItem = db_expr_None) Then
                                            newSite.Item(db_fld_SiteVertDatum) = DBNull.Value
                                        Else
                                            newSite.Item(db_fld_SiteVertDatum) = cboVerticalDatum.SelectedItem
                                        End If
                                        Sites.Rows.Add(newSite)

                                        CommitTable(Sites, sqlQuery, m_connSettings)
                                        Dim newSites() As DataRow = Sites.Select(db_fld_SiteCode & " = '" & FormatForDB(txtSiteCode.Text) & "'")
                                        If newSites.Length = 1 Then
                                            NewID = newSites(0).Item(db_fld_SiteID)
                                            Me.DialogResult = Windows.Forms.DialogResult.OK
                                        Else
                                            NewID = -99
                                            ShowError("Unable to retrieve the new Site from the database.")
                                        End If

                                        Me.DialogResult = Windows.Forms.DialogResult.OK
                                    Else
                                        ShowError("Positional Accuracy must be a number.")
                                    End If
                                Else
                                    ShowError("LocalY must be a number.")
                                End If
                            Else
                                ShowError("LocalX must be a number.")
                            End If
                        Else
                            ShowError("Elevation must be a number.")
                        End If
                    Else
                        ShowError("Longitude must be a number.")
                    End If
                Else
                    ShowError("Latitude must be a number.")
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
    ''' Uses a regular expression to ensure that only numbers are allowed 
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub NumericField_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLatitude.TextChanged, txtLongitude.TextChanged, txtElevation_m.TextChanged, txtLocalX.TextChanged, txtLocalY.TextChanged, txtPosAccuracy.TextChanged
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

        CheckRequirements()
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Uses regular expressions to ensure that only valid text is allowed into the site code field
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub SiteCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSiteCode.TextChanged
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

        CheckRequirements()
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Uses modCommon.g_Pattern_ShortText to ensure that only valid text is allowed
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub ShortText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSiteName.TextChanged, txtState.TextChanged, txtCounty.TextChanged
        If (Regex.Matches(sender.Text, g_Pattern_SiteVarCode).Count > 0) Then
            Dim Start As Integer = sender.SelectionStart
            Dim First As String = sender.Text.Substring(0, Start)
            Dim Last As String = sender.Text.Substring(Start)

            First = Regex.Replace(First, g_Pattern_ShortText, "")

            Last = Regex.Replace(Last, g_Pattern_ShortText, "")

            sender.Text = First & Last
            sender.SelectionStart = First.Length
        End If

        CheckRequirements()
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks whether the form is complete and valid
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub LongText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged
        CheckRequirements()
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Checks whether the form is complete and valid
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLatLongDatum.SelectedIndexChanged, cboVerticalDatum.SelectedIndexChanged, cboLocalProjection.SelectedIndexChanged
        btnOK.Enabled = isDone()
    End Sub
    ''' <summary>
    ''' Enables/Disables certain fields if their prerequisites are not complete/valid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckRequirements()
        Try
            lblVerticalDatum.Enabled = (txtElevation_m.Text <> "")
            cboVerticalDatum.Enabled = (txtElevation_m.Text <> "")

            lblLocalProjection.Enabled = ((txtLocalX.Text <> "") Or (txtLocalY.Text <> ""))
            cboLocalProjection.Enabled = ((txtLocalX.Text <> "") Or (txtLocalY.Text <> ""))

            If Not cboVerticalDatum.Enabled Then
                cboVerticalDatum.SelectedIndex = -1
            ElseIf cboVerticalDatum.SelectedIndex < 0 Then
                cboVerticalDatum.SelectedIndex = defaultVertDatum
            End If

            If Not cboLocalProjection.Enabled Then
                cboLocalProjection.SelectedIndex = -1
            ElseIf cboLocalProjection.SelectedIndex < 0 Then
                cboLocalProjection.SelectedIndex = defaultLocProj
            End If
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub
    ''' <summary>
    ''' Returns true if the form is complete and valid
    ''' </summary>
    ''' <returns>true if the form is complete and valid</returns>
    ''' <remarks></remarks>
    Private Function isDone() As Boolean
        Try
            If (txtSiteCode.Text <> "") And (txtSiteName.Text <> "") And (txtLatitude.Text <> "") And (txtLongitude.Text <> "") And (cboLatLongDatum.SelectedIndex >= 0) Then
                If (txtElevation_m.Text = "" Or (cboVerticalDatum.SelectedItem <> db_expr_None And cboVerticalDatum.SelectedIndex >= 0)) Then
                    If ((txtLocalX.Text = "" And txtLocalY.Text = "") Or (txtLocalX.Text <> "" And txtLocalY.Text <> "" And cboLocalProjection.SelectedIndex >= 0)) Then 'And cboLocalProjection.SelectedItem <> db_expr_None
                        Return True
                    End If
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