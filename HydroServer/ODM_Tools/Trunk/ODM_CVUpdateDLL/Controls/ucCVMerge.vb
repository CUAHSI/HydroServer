'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.



'http://his.cuahsi.org/odmcv_1_1/odmcv_1_1.asmx
Public Class ucCVMerge

#Region " Member Variables "
    Private type As CVType = CVType.CensorCode 'The CV that is being updated
    Private strTableName As String = db_tbl_CensorCodeCV 'The tableName of the CV being updated
    Private cHeaderColor As Color 'Changed Values: Color of header, selection arrow, and text
    Private aHeaderColor As Color 'Added Values: Color of header, selection arrow, and text
    Private nfHeaderColor As Color 'Unapproved Values: Color of header, selection arrow, and text

    Private webLoaded As Boolean = False 'Is the webData table loaded with the current CV type?
    Private localLoaded As Boolean = False 'Is the localData table loaded with the current CV type?
    Private changes As Boolean = False 'Have changes been made to the localData table?
    Private hasUnapproved As Boolean = False 'Does the localData table have unapproved terms?

    Private webData As DataTable 'The data from the Master CV Repository
    Private localData As DataTable 'The data from the CV from the local database
    Private fixedData As DataTable 'The fixed unapproved terms.

    Private Const notFnd As String = "Unapproved Term." 'The customErrorText for if a value had been deleted but is still in use locally
    Private Const expr_NewID As String = "NewID" 'The column name for newID of the fixedData table

#End Region

#Region " Events "

    Public Event DataChanged() 'localData has been changed
    Public Event Finished() 'The finished button has been pressed

#End Region

#Region " Properties "

    <System.ComponentModel.Category("DataAppearance")> <System.ComponentModel.DefaultValue("CVType.CensorCode")> Public Property TableType() As Integer
        Get
            Return type
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case CVType.CensorCode
                    cboCVType.SelectedIndex = 0
                Case CVType.DataType
                    cboCVType.SelectedIndex = 1
                Case CVType.GeneralCategory
                    cboCVType.SelectedIndex = 2
                Case CVType.SampleMedium
                    cboCVType.SelectedIndex = 3
                Case CVType.SampleType
                    cboCVType.SelectedIndex = 4
                Case CVType.TopicCategory
                    cboCVType.SelectedIndex = 5
                Case CVType.ValueType
                    cboCVType.SelectedIndex = 6
                Case CVType.VariableName
                    cboCVType.SelectedIndex = 7
                Case CVType.VerticalDatum
                    cboCVType.SelectedIndex = 8
                Case CVType.Speciation
                    cboCVType.SelectedIndex = 9
                Case CVType.SpatialRef
                    cboCVType.SelectedIndex = 10
                Case CVType.Unit
                    cboCVType.SelectedIndex = 11
                Case CVType.SiteType
                    cboCVType.SelectedIndex = 12
                Case Else
                    cboCVType.SelectedIndex = 0
            End Select
        End Set
    End Property 'Changes the type of table being updated

    <System.ComponentModel.Category("DataAppearance")> <System.ComponentModel.DefaultValue("Color.Blue")> Public Property ChangedTextColor() As Color
        Get
            Return cHeaderColor
        End Get
        Set(ByVal value As Color)
            cHeaderColor = value
            lblKeyChanged.ForeColor = value
        End Set
    End Property 'Changes the color of Changed Values

    <System.ComponentModel.Category("DataAppearance")> <System.ComponentModel.DefaultValue("Color.Orange")> Public Property AddedTextColor() As Color
        Get
            Return aHeaderColor
        End Get
        Set(ByVal value As Color)
            aHeaderColor = value
            lblKeyAdded.ForeColor = value
        End Set
    End Property 'Changes the color of Added Values

    <System.ComponentModel.Category("DataAppearance")> <System.ComponentModel.DefaultValue("Color.Red")> Public Property NotFoundTextColor() As Color
        Get
            Return nfHeaderColor
        End Get
        Set(ByVal value As Color)
            nfHeaderColor = value
            lblKeyUnapproved.ForeColor = value
        End Set
    End Property 'Changes the color of Unapproved Values

    Public ReadOnly Property HasChanges() As Boolean
        Get
            Return changes
        End Get
    End Property 'Returns true if changes have been made to localData

#End Region

#Region " Functions "
    'Sub New()
    '    If My.Settings.ODMVersion = "1.1.1" Then
    '        Me.cboCVType.Items.AddRange(New Object() {"Site Type CV"})
    '    End If
    'End Sub
    Public Sub addSiteType()
        If My.Settings.ODMVersion = "1.1.1" Then
            Me.cboCVType.Items.AddRange(New Object() {"Site Type CV"})
        End If
    End Sub
    Public Function LoadInitial() As Boolean
        If (Not localLoaded) And (Not webLoaded) And (Not (g_CurrConnSettings Is Nothing)) Then
            Me.Cursor = Cursors.WaitCursor
            Try
                Dim i As Integer
                webData = GetWebUpdates()
                dgvWeb.DataSource = webData
                localData = GetLocalDB()
                dgvLocal.DataSource = localData
                For i = 0 To (dgvWeb.Columns.Count - 1)
                    dgvWeb.Columns(i).MinimumWidth = 50
                Next i
                dgvWeb.Columns(dgvWeb.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                dgvLocal.Columns(dgvLocal.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                dgvWeb.AutoResizeColumns()
                dgvWeb.AutoResizeRows()
                For i = 0 To (dgvLocal.Columns.Count - 1)
                    dgvLocal.Columns(i).MinimumWidth = 50
                    If dgvWeb.Columns.Count > i Then
                        dgvLocal.Columns(i).Width = dgvWeb.Columns(i).Width
                    End If
                Next i
                dgvLocal.AutoResizeRows()

                fixedData = localData.Clone
                'If (type = CVType.Unit) Or (type = CVType.SpatialRef) Then
                fixedData.Columns.Add("NewID", System.Type.GetType("System.Int32"))
                'Else
                'fixedData.Columns.Add("NewTerm")
                'End If
                webLoaded = True
                localLoaded = True
                btnUpdateLocal.Visible = True
                btnApply.Visible = False
                SplitContainer1.SplitterDistance = (SplitContainer1.Width - SplitContainer1.SplitterWidth) / 2
            Catch ex As Exception

                Me.Cursor = Cursors.Default
                Return False
            End Try
            Me.Cursor = Cursors.Default
        End If
        Return True
    End Function 'Loads initial data for webData and localData, resets member variables, and auto sizes DataGridViews

    Private Function GetWebUpdates() As DataTable
        Dim connect As New wrCVUpdate.ODMCVService
        Dim tempTable As New DataTable

        Select Case type
            Case CVType.CensorCode
                tempTable = XMLStringtoTable(connect.GetCensorCodeCV())
            Case CVType.DataType
                tempTable = XMLStringtoTable(connect.GetDataTypeCV())
            Case CVType.GeneralCategory
                tempTable = XMLStringtoTable(connect.GetGeneralCategoryCV())
            Case CVType.SampleMedium
                tempTable = XMLStringtoTable(connect.GetSampleMediumCV())
            Case CVType.SampleType
                tempTable = XMLStringtoTable(connect.GetSampleTypeCV())
            Case CVType.TopicCategory
                tempTable = XMLStringtoTable(connect.GetTopicCategoryCV())
            Case CVType.ValueType
                tempTable = XMLStringtoTable(connect.GetValueTypeCV())
            Case CVType.VariableName
                tempTable = XMLStringtoTable(connect.GetVariableNameCV())
            Case CVType.VerticalDatum
                tempTable = XMLStringtoTable(connect.GetVerticalDatumCV())
            Case CVType.Speciation
                tempTable = XMLStringtoTable(connect.GetSpeciationCV())
            Case CVType.SpatialRef
                tempTable = XMLStringtoTable(connect.GetSpatialReferences, True, True)
            Case CVType.Unit
                tempTable = XMLStringtoTable(connect.GetUnits, True)
            Case CVType.SiteType
                tempTable = XMLStringtoTable(connect.GetSiteTypeCV)
        End Select
        'If type = CVType.QCLevel Then
        '    tempTable.Columns(0).ColumnName = db_fld_QCLQCLevel
        '    tempTable.Columns(1).ColumnName = db_fld_QCLDefinition
        '    tempTable.Columns(2).ColumnName = db_fld_QCLExplanation
        If type = CVType.SpatialRef Then
            tempTable.Columns(0).ColumnName = db_fld_SRID
            tempTable.Columns(1).ColumnName = db_fld_SRSRSID
            tempTable.Columns(2).ColumnName = db_fld_SRSRSName
            tempTable.Columns(3).ColumnName = db_fld_SRIsGeo
            tempTable.Columns(4).ColumnName = db_fld_SRNotes
        ElseIf type = CVType.Unit Then
            tempTable.Columns(0).ColumnName = db_fld_UnitsID
            tempTable.Columns(1).ColumnName = db_fld_UnitsName
            tempTable.Columns(2).ColumnName = db_fld_UnitsType
            tempTable.Columns(3).ColumnName = db_fld_UnitsAbrv
        Else
            tempTable.Columns(0).ColumnName = db_fld_CV_Term
            tempTable.Columns(1).ColumnName = db_fld_CV_Definition
        End If
        Return tempTable
    End Function 'Retrieves dataTable from web service

    Private Function GetLocalDB() As DataTable
        Dim sql As String
        sql = "SELECT * FROM " & strTableName & " ORDER BY "
        Select Case type
            'Case CVType.QCLevel
            '    sql &= db_fld_QCLQCLevel
            Case CVType.SpatialRef
                sql &= db_fld_SRID
            Case CVType.Unit
                sql &= db_fld_UnitsID
            Case Else
                sql &= db_fld_CV_Term
        End Select
        Return OpenTable(strTableName, sql, g_CurrConnSettings)
    End Function 'Retrieves dataTable from local database

    Private Function UpdateLocal() As DataTable
        Dim WebTable, LocalTable As DataTable
        Dim newRow As DataRow
        Dim fndRows() As DataRow
        Const match As String = "Matches"

        hasUnapproved = False
        WebTable = webData.Copy
        LocalTable = localData.Copy
        Select Case type
            Case CVType.SpatialRef '..................................................................................
                Dim matches(LocalTable.Rows.Count)
                'Matches
                For Each currWRow As DataRow In WebTable.Rows
                    Dim srsidQuery, isGeoQuery, notesQuery As String
                    If (currWRow.Item(db_fld_SRSRSID).ToString = "") OrElse (currWRow.Item(db_fld_SRSRSID).ToString = "NULL") Then
                        srsidQuery = db_fld_SRSRSID & " IS NULL"
                    Else
                        srsidQuery = db_fld_SRSRSID & " = '" & Val(currWRow.Item(db_fld_SRSRSID)) & "'"
                    End If
                    If (currWRow.Item(db_fld_SRIsGeo).ToString = "") OrElse (currWRow.Item(db_fld_SRIsGeo).ToString = "NULL") Then
                        isGeoQuery = db_fld_SRIsGeo & " IS NULL"
                    Else
                        isGeoQuery = db_fld_SRIsGeo & " = '" & FormatForDB(currWRow.Item(db_fld_SRIsGeo).ToString) & "'"
                    End If
                    If (currWRow.Item(db_fld_SRNotes).ToString = "") OrElse (currWRow.Item(db_fld_SRNotes).ToString = "NULL") Then
                        notesQuery = db_fld_SRNotes & " IS NULL"
                    Else
                        notesQuery = db_fld_SRNotes & " = '" & FormatForDB(currWRow.Item(db_fld_SRNotes).ToString) & "'"
                    End If

                    fndRows = LocalTable.Select(srsidQuery & " AND " & db_fld_SRSRSName & " = '" & FormatForDB(currWRow.Item(db_fld_SRSRSName).ToString) & "' AND " & isGeoQuery & " AND " & notesQuery)
                    If (fndRows.Length = 1) Then
                        currWRow.RowError = match
                        matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                    ElseIf (fndRows.Length > 1) Then
                        Throw New Exception("ERROR IN ucCVMerge.vb")
                    End If
                Next currWRow
                'Changes and Additions
                For Each currWRow As DataRow In WebTable.Rows
                    If (currWRow.RowState <> DataRowState.Deleted) AndAlso (currWRow.RowError <> match) Then
                        Dim srsidQuery, isGeoQuery, notesQuery As String
                        If (currWRow.Item(db_fld_SRSRSID).ToString = "") OrElse (currWRow.Item(db_fld_SRSRSID).ToString = "NULL") Then
                            srsidQuery = db_fld_SRSRSID & " IS NULL"
                        Else
                            srsidQuery = db_fld_SRSRSID & " = '" & Val(currWRow.Item(db_fld_SRSRSID)) & "'"
                        End If
                        If (currWRow.Item(db_fld_SRIsGeo).ToString = "") OrElse (currWRow.Item(db_fld_SRIsGeo).ToString = "NULL") Then
                            isGeoQuery = db_fld_SRIsGeo & " IS NULL"
                        Else
                            isGeoQuery = db_fld_SRIsGeo & " = '" & FormatForDB(currWRow.Item(db_fld_SRIsGeo).ToString) & "'"
                        End If
                        If (currWRow.Item(db_fld_SRNotes).ToString = "") OrElse (currWRow.Item(db_fld_SRNotes).ToString = "NULL") Then
                            notesQuery = db_fld_SRNotes & " IS NULL"
                        Else
                            notesQuery = db_fld_SRNotes & " = '" & FormatForDB(currWRow.Item(db_fld_SRNotes).ToString) & "'"
                        End If

                        fndRows = LocalTable.Select(srsidQuery & " AND " & db_fld_SRSRSName & " = '" & FormatForDB(currWRow.Item(db_fld_SRSRSName).ToString) & "' AND " & isGeoQuery)
                        If (fndRows.Length = 1) AndAlso (matches(LocalTable.Rows.IndexOf(fndRows(0))) = False) Then
                            matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                            fndRows(0).Item(db_fld_SRNotes) = currWRow.Item(db_fld_SRNotes)
                            changes = True
                        Else
                            fndRows = LocalTable.Select(srsidQuery & " AND " & db_fld_SRSRSName & " = '" & FormatForDB(currWRow.Item(db_fld_SRSRSName).ToString) & "' AND " & notesQuery)
                            If (fndRows.Length = 1) AndAlso (matches(LocalTable.Rows.IndexOf(fndRows(0))) = False) Then
                                matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                                fndRows(0).Item(db_fld_SRIsGeo) = currWRow.Item(db_fld_SRIsGeo)
                                changes = True
                            Else
                                fndRows = LocalTable.Select(srsidQuery & " AND " & isGeoQuery & " AND " & notesQuery)
                                If (fndRows.Length = 1) AndAlso (matches(LocalTable.Rows.IndexOf(fndRows(0))) = False) Then
                                    matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                                    fndRows(0).Item(db_fld_SRSRSName) = currWRow.Item(db_fld_SRSRSName)
                                    changes = True
                                Else
                                    fndRows = LocalTable.Select(db_fld_SRSRSName & " = '" & FormatForDB(currWRow.Item(db_fld_SRSRSName).ToString) & "' AND " & isGeoQuery & " AND " & notesQuery)
                                    If (fndRows.Length = 1) AndAlso (matches(LocalTable.Rows.IndexOf(fndRows(0))) = False) Then
                                        matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                                        fndRows(0).Item(db_fld_SRSRSID) = currWRow.Item(db_fld_SRSRSID)
                                        changes = True
                                    Else
                                        newRow = LocalTable.NewRow
                                        newRow.Item(db_fld_SRID) = Val(currWRow.Item(db_fld_SRID))
                                        If (currWRow.Item(db_fld_SRSRSID).ToString = "") OrElse (currWRow.Item(db_fld_SRSRSID).ToString = "NULL") Then
                                            newRow.Item(db_fld_SRSRSID) = DBNull.Value
                                        Else
                                            newRow.Item(db_fld_SRSRSID) = currWRow.Item(db_fld_SRSRSID)
                                        End If
                                        newRow.Item(db_fld_SRSRSName) = currWRow.Item(db_fld_SRSRSName).ToString
                                        If (currWRow.Item(db_fld_SRIsGeo).ToString = "") OrElse (currWRow.Item(db_fld_SRIsGeo).ToString = "NULL") Then
                                            newRow.Item(db_fld_SRIsGeo) = DBNull.Value
                                        Else
                                            newRow.Item(db_fld_SRIsGeo) = CBool(currWRow.Item(db_fld_SRIsGeo))
                                        End If
                                        If (currWRow.Item(db_fld_SRNotes) = "").ToString OrElse (currWRow.Item(db_fld_SRNotes).ToString = "NULL") Then
                                            newRow.Item(db_fld_SRNotes) = DBNull.Value
                                        Else
                                            newRow.Item(db_fld_SRNotes) = currWRow.Item(db_fld_SRNotes).ToString
                                        End If
                                        LocalTable.Rows.Add(newRow)
                                        changes = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next currWRow
                'Deletions
                For Each currLRow As DataRow In LocalTable.Rows
                    If (currLRow.RowState = DataRowState.Unchanged) Then
                        Dim srsidQuery, isGeoQuery, notesQuery As String
                        If (currLRow.Item(db_fld_SRSRSID).ToString = "") OrElse (currLRow.Item(db_fld_SRSRSID).ToString = "NULL") Then
                            srsidQuery = db_fld_SRSRSID & " IS NULL"
                        Else
                            srsidQuery = db_fld_SRSRSID & " = '" & Val(currLRow.Item(db_fld_SRSRSID)) & "'"
                        End If
                        If (currLRow.Item(db_fld_SRIsGeo).ToString = "") OrElse (currLRow.Item(db_fld_SRIsGeo).ToString = "NULL") Then
                            isGeoQuery = db_fld_SRIsGeo & " IS NULL"
                        Else
                            isGeoQuery = db_fld_SRIsGeo & " = '" & FormatForDB(currLRow.Item(db_fld_SRIsGeo).ToString) & "'"
                        End If
                        If (currLRow.Item(db_fld_SRNotes).ToString = "") OrElse (currLRow.Item(db_fld_SRNotes).ToString = "NULL") Then
                            notesQuery = db_fld_SRNotes & " IS NULL"
                        Else
                            notesQuery = db_fld_SRNotes & " = '" & FormatForDB(currLRow.Item(db_fld_SRNotes).ToString) & "'"
                        End If

                        fndRows = WebTable.Select(srsidQuery & " AND " & db_fld_SRSRSName & " = '" & FormatForDB(currLRow.Item(db_fld_SRSRSName).ToString) & "' AND " & isGeoQuery & " AND " & notesQuery)
                        If (fndRows.Length = 0) Then
                            If (timesUsed(currLRow.Item(db_fld_SRID)) > 0) Then
                                currLRow.RowError = notfnd
                            Else
                                currLRow.Delete()
                                changes = True
                            End If
                        End If
                    End If
                Next currLRow
            Case CVType.Unit '.........................................................................................
                Dim matches(LocalTable.Rows.Count)
                'Matches
                For Each currWRow As DataRow In WebTable.Rows
                    fndRows = LocalTable.Select(db_fld_UnitsName & " = '" & FormatForDB(currWRow.Item(db_fld_UnitsName).ToString) & "' AND " & db_fld_UnitsType & " = '" & FormatForDB(currWRow.Item(db_fld_UnitsType).ToString) & "' AND " & db_fld_UnitsAbrv & " = '" & FormatForDB(currWRow.Item(db_fld_UnitsAbrv).ToString) & "'")
                    If (fndRows.Length = 1) Then
                        currWRow.RowError = match
                        matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                    ElseIf (fndRows.Length > 1) Then
                        Throw New Exception("ERROR IN ucCVMerge.vb")
                    End If
                Next currWRow
                'Changes and Additions
                For Each currWRow As DataRow In WebTable.Rows
                    If (currWRow.RowState <> DataRowState.Deleted) AndAlso (currWRow.RowError <> match) Then
                        fndRows = LocalTable.Select(db_fld_UnitsName & " = '" & FormatForDB(currWRow.Item(db_fld_UnitsName).ToString) & "' AND " & db_fld_UnitsType & " = '" & FormatForDB(currWRow.Item(db_fld_UnitsType).ToString) & "'")
                        If (fndRows.Length = 1) AndAlso (matches(LocalTable.Rows.IndexOf(fndRows(0))) = False) Then
                            matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                            fndRows(0).Item(db_fld_UnitsAbrv) = currWRow.Item(db_fld_UnitsAbrv)
                            changes = True
                        Else
                            fndRows = LocalTable.Select(db_fld_UnitsName & " = '" & FormatForDB(currWRow.Item(db_fld_UnitsName).ToString) & "' AND " & db_fld_UnitsAbrv & " = '" & FormatForDB(currWRow.Item(db_fld_UnitsAbrv).ToString) & "'")
                            If (fndRows.Length = 1) AndAlso (matches(LocalTable.Rows.IndexOf(fndRows(0))) = False) Then
                                matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                                fndRows(0).Item(db_fld_UnitsType) = currWRow.Item(db_fld_UnitsType)
                                changes = True
                            Else
                                fndRows = LocalTable.Select(db_fld_UnitsType & " = '" & FormatForDB(currWRow.Item(db_fld_UnitsType).ToString) & "' AND " & db_fld_UnitsAbrv & " = '" & FormatForDB(currWRow.Item(db_fld_UnitsAbrv).ToString) & "'")
                                If (fndRows.Length = 1) AndAlso (matches(LocalTable.Rows.IndexOf(fndRows(0))) = False) Then
                                    matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                                    fndRows(0).Item(db_fld_UnitsName) = currWRow.Item(db_fld_UnitsName)
                                    changes = True
                                Else
                                    newRow = LocalTable.NewRow
                                    newRow.Item(db_fld_UnitsID) = Val(currWRow.Item(db_fld_UnitsID))
                                    newRow.Item(db_fld_UnitsName) = currWRow.Item(db_fld_UnitsName).ToString
                                    newRow.Item(db_fld_UnitsType) = currWRow.Item(db_fld_UnitsType).ToString
                                    newRow.Item(db_fld_UnitsAbrv) = currWRow.Item(db_fld_UnitsAbrv).ToString
                                    LocalTable.Rows.Add(newRow)
                                    changes = True
                                End If
                            End If
                        End If
                    End If
                Next currWRow
                'Deletions
                For Each currLRow As DataRow In LocalTable.Rows
                    If (currLRow.RowState = DataRowState.Unchanged) Then
                        fndRows = WebTable.Select(db_fld_UnitsName & " = '" & FormatForDB(currLRow.Item(db_fld_UnitsName).ToString) & "' AND " & db_fld_UnitsType & " = '" & FormatForDB(currLRow.Item(db_fld_UnitsType).ToString) & "' AND " & db_fld_UnitsAbrv & " = '" & FormatForDB(currLRow.Item(db_fld_UnitsAbrv).ToString) & "'")
                        If (fndRows.Length = 0) Then
                            If (timesUsed(currLRow.Item(db_fld_UnitsID)) > 0) Then
                                currLRow.RowError = notFnd
                            Else
                                currLRow.Delete()
                                changes = True
                            End If
                        End If
                    End If
                Next currLRow
            Case Else 'All other CVs without IDs..................................................................
                Dim matches(LocalTable.Rows.Count)
                'Matches
                For Each currWRow As DataRow In WebTable.Rows
                    fndRows = LocalTable.Select(db_fld_CV_Term & " = '" & FormatForDB(currWRow.Item(db_fld_CV_Term).ToString) & "' AND " & db_fld_CV_Definition & " = '" & FormatForDB(currWRow.Item(db_fld_CV_Definition).ToString) & "'")
                    If (fndRows.Length = 1) Then
                        currWRow.RowError = match
                        matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                    ElseIf (fndRows.Length > 1) Then
                        Throw New Exception("ERROR IN ucCVMerge.vb")
                    End If
                Next currWRow
                'Changes and Additions
                For Each currWRow As DataRow In WebTable.Rows
                    If (currWRow.RowState <> DataRowState.Deleted) AndAlso (currWRow.RowError <> match) Then
                        fndRows = LocalTable.Select(db_fld_CV_Term & " = '" & FormatForDB(currWRow.Item(db_fld_CV_Term).ToString) & "'")
                        If (fndRows.Length = 1) AndAlso (matches(LocalTable.Rows.IndexOf(fndRows(0))) = False) Then
                            matches(LocalTable.Rows.IndexOf(fndRows(0))) = True
                            fndRows(0).Item(db_fld_CV_Definition) = currWRow.Item(db_fld_CV_Definition)
                            changes = True
                        Else
                            fndRows = LocalTable.Select(db_fld_CV_Definition & " = '" & FormatForDB(currWRow.Item(db_fld_CV_Definition).ToString) & "'")
                            If (fndRows.Length = 1) AndAlso (matches(LocalTable.Rows.IndexOf(fndRows(0))) = False) Then
                                matches(LocalTable.Rows.IndexOf(fndRows(0))) = True

                                Dim newLocalRow As DataRow = LocalTable.NewRow
                                newLocalRow.Item(db_fld_CV_Term) = currWRow.Item(db_fld_CV_Term)
                                newLocalRow.Item(db_fld_CV_Definition) = currWRow.Item(db_fld_CV_Definition)
                                LocalTable.Rows.Add(newLocalRow)

                                Dim newFixRow As DataRow = fixedData.NewRow
                                newFixRow.Item(db_fld_CV_Term) = fndRows(0).Item(db_fld_CV_Term)
                                newFixRow.Item(db_fld_CV_Definition) = fndRows(0).Item(db_fld_CV_Definition)
                                newFixRow.Item(expr_NewID) = LocalTable.Rows.IndexOf(newLocalRow)
                                fixedData.Rows.Add(newFixRow)

                                fndRows(0).Delete()
                                changes = True
                            Else
                                newRow = LocalTable.NewRow
                                newRow.Item(db_fld_CV_Term) = currWRow.Item(db_fld_CV_Term).ToString
                                newRow.Item(db_fld_CV_Definition) = currWRow.Item(db_fld_CV_Definition).ToString
                                LocalTable.Rows.Add(newRow)
                                changes = True
                            End If
                        End If
                    End If
                Next currWRow
                'Deletions
                For Each currLRow As DataRow In LocalTable.Rows
                    If (currLRow.RowState = DataRowState.Unchanged) Then
                        fndRows = WebTable.Select(db_fld_CV_Term & " = '" & FormatForDB(currLRow.Item(db_fld_CV_Term).ToString) & "' AND " & db_fld_CV_Definition & " = '" & FormatForDB(currLRow.Item(db_fld_CV_Definition).ToString) & "'")
                        If (fndRows.Length = 0) Then
                            If (timesUsed(currLRow.Item(db_fld_CV_Term)) > 0) Then
                                currLRow.RowError = notFnd
                            Else
                                currLRow.Delete()
                                changes = True
                            End If
                        End If
                    End If
                Next currLRow
        End Select '.................................................................................................
        dgvLocal.Select()
        If changes Then
            RaiseEvent DataChanged()
        End If

        Return LocalTable
    End Function 'Returns a dataTable copied from localData that has been updated to match webData as closely as possible

    Private Function timesUsed(ByVal fieldVal As String) As Integer
        Dim sql As String
        Dim useTable As DataTable

        Select Case type
            Case CVType.CensorCode
                sql = "SELECT COUNT(" & db_tbl_DataValues & "." & db_fld_ValID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_DataValues & " ON " & _
                db_tbl_DataValues & "." & db_fld_ValCensorCode & " = "
            Case CVType.DataType
                sql = "SELECT COUNT(" & db_tbl_Variables & "." & db_fld_VarID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_Variables & " ON " & _
                db_tbl_Variables & "." & db_fld_VarDataType & " = "
            Case CVType.GeneralCategory
                sql = "SELECT COUNT(" & db_tbl_Variables & "." & db_fld_VarID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_Variables & " ON " & _
                db_tbl_Variables & "." & db_fld_VarGenCat & " = "
            Case CVType.SampleMedium
                sql = "SELECT COUNT(" & db_tbl_Variables & "." & db_fld_VarID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_Variables & " ON " & _
                db_tbl_Variables & "." & db_fld_VarSampleMed & " = "
            Case CVType.SampleType
                sql = "SELECT COUNT(" & db_tbl_Samples & "." & db_fld_SampleID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_Samples & " ON " & _
                db_tbl_Samples & "." & db_fld_SampleType & " = "
            Case CVType.TopicCategory
                sql = "SELECT COUNT(" & db_tbl_ISOMetaData & "." & db_fld_IMDMetaID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_ISOMetaData & " ON " & _
                db_tbl_ISOMetaData & "." & db_fld_IMDTopicCat & " = "
            Case CVType.ValueType
                sql = "SELECT COUNT(" & db_tbl_Variables & "." & db_fld_VarID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_Variables & " ON " & _
                db_tbl_Variables & "." & db_fld_VarValueType & " = "
            Case CVType.VariableName
                sql = "SELECT COUNT(" & db_tbl_Variables & "." & db_fld_VarID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_Variables & " ON " & _
                db_tbl_Variables & "." & db_fld_VarName & " = "
            Case CVType.SiteType
                sql = "SELECT COUNT(" & db_tbl_Sites & "." & db_fld_SiteType & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_Sites & " ON " & _
                db_tbl_Sites & "." & db_fld_SiteType & " = "
            Case CVType.VerticalDatum
                sql = "SELECT COUNT(" & db_tbl_Sites & "." & db_fld_SiteID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_Sites & " ON " & _
                db_tbl_Sites & "." & db_fld_SiteVertDatum & " = "
            Case CVType.Speciation
                sql = "SELECT COUNT(" & db_tbl_Variables & "." & db_fld_VarID & ") AS " & db_expr_Uses1 & _
                " FROM " & strTableName & " LEFT JOIN " & _
                db_tbl_Variables & " ON " & _
                db_tbl_Variables & "." & db_fld_VarSpec & " = "
                'Case CVType.QCLevel
                '    sql = "SELECT COUNT(" & db_tbl_DataValues & "." & db_fld_ValID & ") AS " & db_expr_Uses1 & _
                '    " FROM " & db_tbl_QCLevels & " LEFT OUTER JOIN " & _
                '    db_tbl_DataValues & " ON " & db_tbl_QCLevels & "." & db_fld_QCLQCLevel & " = " & db_tbl_DataValues & "." & db_fld_ValQCLevel & _
                '    " GROUP BY " & db_tbl_QCLevels & "." & db_fld_QCLQCLevel & ", " & db_tbl_QCLevels & "." & db_fld_QCLDefinition & ", " & db_tbl_QCLevels & "." & db_fld_QCLExplanation & _
                '    " HAVING (" & strTableName & "." & db_fld_QCLQCLevel & " = '" & FormatForDB(fieldVal) & "')"

                '    useTable = OpenTable(strTableName & "Uses", sql, g_CurrConnSettings)
                '    If Not (useTable Is Nothing) AndAlso (useTable.Rows.Count > 0) Then
                '        Return Val(useTable.Rows(0).Item(db_expr_Uses1))
                '    Else
                '        Return 0
                '    End If
            Case CVType.SpatialRef
                sql = "SELECT COUNT(" & db_expr_Sites1 & "." & db_fld_SiteID & ") AS " & db_expr_Uses1 & _
                ", COUNT(" & db_expr_Sites2 & "." & db_fld_SiteID & ") AS " & db_expr_Uses2 & _
                " FROM " & db_tbl_Sites & " AS " & db_expr_Sites2 & " RIGHT OUTER JOIN " & _
                db_tbl_SpatialRefs & " ON " & db_expr_Sites2 & "." & db_fld_SiteLocProjID & " = " & db_tbl_SpatialRefs & "." & db_fld_SRID & " LEFT OUTER JOIN " & _
                db_tbl_Sites & " AS " & db_expr_Sites1 & " ON " & db_tbl_SpatialRefs & "." & db_fld_SRID & " = " & db_expr_Sites1 & "." & db_fld_SiteLatLongDatumID & _
                " GROUP BY " & db_tbl_SpatialRefs & "." & db_fld_SRID & ", " & db_tbl_SpatialRefs & "." & db_fld_SRSRSID & ", " & db_tbl_SpatialRefs & "." & db_fld_SRSRSName & ", " & db_tbl_SpatialRefs & "." & db_fld_SRNotes & ", " & db_tbl_SpatialRefs & "." & db_fld_SRIsGeo & _
                " HAVING (" & strTableName & "." & db_fld_SRID & " = '" & FormatForDB(fieldVal) & "')"

                useTable = OpenTable(strTableName & "Uses", sql, g_CurrConnSettings)
                If Not (useTable Is Nothing) AndAlso (useTable.Rows.Count > 0) Then
                    Return (Val(useTable.Rows(0).Item(db_expr_Uses1)) + Val(useTable.Rows(0).Item(db_expr_Uses2)))
                Else
                    Return 0
                End If
            Case CVType.Unit
                sql = "SELECT COUNT(" & db_tbl_OffsetTypes & "." & db_fld_OTID & ") AS " & db_expr_Uses1 & ", COUNT(" & db_expr_Var1 & "." & db_fld_VarID & ") AS " & db_expr_Uses2 & ", COUNT(" & db_expr_Var2 & "." & db_fld_VarID & ") AS " & db_expr_Uses3 & _
                " FROM " & db_tbl_Variables & " AS " & db_expr_Var2 & " RIGHT OUTER JOIN " & _
                db_tbl_Units & " ON " & db_expr_Var2 & "." & db_fld_VarTimeUnitsID & " = " & db_tbl_Units & "." & db_fld_UnitsID & " LEFT OUTER JOIN " & _
                db_tbl_Variables & " AS " & db_expr_Var1 & " ON " & db_tbl_Units & "." & db_fld_UnitsID & " = " & db_expr_Var1 & "." & db_fld_VarUnitsID & " LEFT OUTER JOIN " & _
                db_tbl_OffsetTypes & " ON " & db_tbl_Units & "." & db_fld_UnitsID & " = " & db_tbl_OffsetTypes & "." & db_fld_OTUnitsID & _
                " GROUP BY " & db_tbl_Units & "." & db_fld_UnitsID & ", " & db_tbl_Units & "." & db_fld_UnitsName & ", " & db_tbl_Units & "." & db_fld_UnitsType & ", " & db_tbl_Units & "." & db_fld_UnitsAbrv & _
                " HAVING (" & strTableName & "." & db_fld_UnitsID & " = '" & FormatForDB(fieldVal) & "')"

                useTable = OpenTable(strTableName & "Uses", sql, g_CurrConnSettings)
                If Not (useTable Is Nothing) AndAlso (useTable.Rows.Count > 0) Then
                    Return (Val(useTable.Rows(0).Item(db_expr_Uses1)) + Val(useTable.Rows(0).Item(db_expr_Uses2)) + Val(useTable.Rows(0).Item(db_expr_Uses3)))
                Else
                    Return 0
                End If
            Case Else
                sql = ""
                Return 0
        End Select

        If Not (type = CVType.SpatialRef And type = CVType.Unit) Then
            sql &= strTableName & "." & db_fld_CV_Term & _
            " GROUP BY " & strTableName & "." & db_fld_CV_Term & ", " & _
            strTableName & "." & db_fld_CV_Definition & _
            " HAVING (" & strTableName & "." & db_fld_CV_Term & " = '" & FormatForDB(fieldVal) & "')"

            useTable = OpenTable(strTableName & "Uses", sql, g_CurrConnSettings)
            If Not (useTable Is Nothing) AndAlso (useTable.Rows.Count > 0) Then
                Return Val(useTable.Rows(0).Item(db_expr_Uses1))
            Else
                Return 0
            End If
        End If

    End Function 'Returns the number of times that value has been used in the database

    Private Function ApplytoDB(ByVal LocalTable As DataTable) As Boolean
        Dim sql As String
        sql = "SELECT * FROM " & strTableName & " ORDER BY "
        Select Case type
            'Case CVType.QCLevel
            '    sql &= strTableName & "." & db_fld_QCLQCLevel
            Case CVType.SpatialRef
                sql &= strTableName & "." & db_fld_SRID
            Case CVType.Unit
                sql &= strTableName & "." & db_fld_UnitsID
            Case Else
                sql &= strTableName & "." & db_fld_CV_Term
        End Select
        UpdateTable(LocalTable, sql, g_CurrConnSettings.ConnectionString)
    End Function 'Commits a dataTable to the Database

    Private Function ApplyFixRow() As Boolean
        Dim connection As New SqlClient.SqlConnection(g_CurrConnSettings.ConnectionString)
        Dim trans As SqlClient.SqlTransaction
        Dim commit As Boolean = True
        Dim command As SqlClient.SqlCommand
        Dim sql As String = ""
        Dim i As Integer
        connection.Open()
        trans = connection.BeginTransaction
        Try
            For i = 0 To (fixedData.Rows.Count - 1)
                Select Case type
                    Case CVType.CensorCode
                        sql = "UPDATE " & db_tbl_DataValues & " SET " & db_fld_ValCensorCode & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_ValCensorCode & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.DataType
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarDataType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarDataType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCDataType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarDataType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.GeneralCategory
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarGenCat & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarGenCat & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCGenCat & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarGenCat & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.SampleMedium
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarSampleMed & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarSampleMed & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.SampleType
                        sql = "UPDATE " & db_tbl_Samples & " SET " & db_fld_SampleType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_SampleType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.TopicCategory
                        sql = "UPDATE " & db_tbl_ISOMetaData & " SET " & db_fld_IMDTopicCat & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_IMDTopicCat & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.ValueType
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarValueType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarValueType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCValueType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarValueType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.VariableName
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarName & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarName & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCVarName & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarName & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.VerticalDatum
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_SiteVertDatum & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_SiteVertDatum & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.Speciation
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_VarSpec & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarSpec & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCSpeciation & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarSpec & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.SpatialRef
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_SiteLatLongDatumID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_SRID) & "' WHERE (" & db_fld_SiteLatLongDatumID & " = '" & fixedData.Rows(i).Item(db_fld_SRID) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_SiteLocProjID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_SRID) & "' WHERE (" & db_fld_SiteLocProjID & " = '" & fixedData.Rows(i).Item(db_fld_SRID) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.Unit
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCTimeUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_SCTimeUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCVarUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_SCVarUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_OffsetTypes & " SET " & db_fld_OTUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_OTUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_VarUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarTimeUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_VarTimeUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.SiteType
                        ''update series catalog, sites
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCSiteType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_SCSiteType & " = '" & fixedData.Rows(i).Item(db_fld_SiteType) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_SiteType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_SiteType & " = '" & fixedData.Rows(i).Item(db_fld_SiteType) & "')"
                        command = New SqlClient.SqlCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        
                    Case Else
                        Return True
                End Select
            Next i
        Catch ex As Exception
            commit = False
            trans.Rollback()
        End Try
        If commit Then
            trans.Commit()
        End If
        connection.Close()
    End Function 'Applies the changes made by frmFixRow to the database

    'Private Sub UpdateOtherTables()
    '    'Justin: REPLACE
    '    Dim connection As New SqlClient.SqlConnection(g_CurrConnSettings.ConnectionString)
    '    Dim command As OleDb.OleDbCommand
    '    Dim trans As OleDb.OleDbTransaction
    '    Dim sql As String
    '    Dim i As Integer

    '    connection.Open()
    '    trans = connection.BeginTransaction()

    '    Select Case type
    '        Case CVType.CensorCode
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_DataValues & " SET " & db_fld_ValCensorCode & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_DataValues & "." & db_fld_ValCensorCode & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case CVType.DataType
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarDataType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarDataType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                    sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCDataType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCDataType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case CVType.GeneralCategory
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarGenCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarGenCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                    sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCGenCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCGenCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case CVType.SampleMedium
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarSampleMed & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarSampleMed & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                    sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCSampleMed & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSampleMed & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case CVType.SampleType
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_Samples & " SET " & db_fld_SampleType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Samples & "." & db_fld_SampleType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case CVType.TopicCategory
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_ISOMetaData & " SET " & db_fld_IMDTopicCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_ISOMetaData & "." & db_fld_IMDTopicCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case CVType.ValueType
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarValueType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarValueType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                    sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCValueType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCValueType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case CVType.VariableName
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarName & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarName & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                    sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCVarName & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCVarName & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case CVType.VerticalDatum
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_SiteVertDatum & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Sites & "." & db_fld_SiteVertDatum & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case CVType.Speciation
    '            For i = 0 To (localData.Rows.Count - 1)
    '                If (localData.Rows(i).RowState = DataRowState.Modified) Then
    '                    sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarSpec & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarSpec & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                    sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCSpeciation & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSpeciation & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
    '                    command = New OleDb.OleDbCommand(sql, connection, trans)
    '                    command.ExecuteScalar()
    '                End If
    '            Next
    '        Case Else
    '            Exit Sub
    '    End Select
    '    trans.Commit()
    '    connection.Close()
    'End Sub 'Updates all tables linking to the CV

    Private Sub btnRefreshWeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshWeb.Click
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        webData = GetWebUpdates()
        dgvWeb.DataSource = webData
        For i = 0 To (dgvWeb.Columns.Count - 1)
            dgvWeb.Columns(i).MinimumWidth = 50
        Next i
        webLoaded = True
        dgvWeb.Columns(dgvWeb.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvWeb.AutoResizeColumns()
        dgvWeb.AutoResizeRows()
        dgvWeb.Select()
        If localLoaded And webLoaded Then
            btnUpdateLocal.Visible = True
        End If
        Me.Cursor = Cursors.Default
    End Sub 'Refreshes the webData.

    Private Sub btnRefreshLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshLocal.Click
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        localData = GetLocalDB()
        dgvLocal.DataSource = localData
        fixedData = localData.Clone
        fixedData.Columns.Add(expr_NewID, System.Type.GetType("System.Int32"))
        changes = False
        For i = 0 To (dgvLocal.Columns.Count - 1)
            dgvLocal.Columns(i).MinimumWidth = 50
        Next i
        dgvLocal.Columns(dgvLocal.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvLocal.AutoResizeRows()
        RaiseEvent DataChanged()
        btnApply.Visible = False
        localLoaded = True
        dgvLocal.Select()
        If localLoaded And webLoaded Then
            btnUpdateLocal.Visible = True
        End If
        Me.Cursor = Cursors.Default
    End Sub 'Refreshes the localData.

    Private Sub btnUpdateLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateLocal.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim x As Integer = 0
            Dim offset As Integer = 0
            Dim column As Integer = -1
            Dim order As System.ComponentModel.ListSortDirection

            If Not (dgvLocal.SortedColumn Is Nothing) Then
                column = dgvLocal.SortedColumn.Index

                If dgvLocal.SortOrder = SortOrder.Ascending Then
                    order = System.ComponentModel.ListSortDirection.Ascending
                Else
                    order = System.ComponentModel.ListSortDirection.Descending
                End If
            End If

            localData = UpdateLocal()
            dgvLocal.DataSource = localData
            btnApply.Visible = changes
            For x = 0 To localData.Rows.Count - 1
                If (localData.Rows(x).RowState = DataRowState.Deleted) Then
                    offset += 1
                ElseIf (localData.Rows(x).RowState = DataRowState.Modified) Then
                    dgvLocal.Rows(x - offset).ErrorText = "Modified but not Committed."
                    dgvLocal.Rows(x - offset).DefaultCellStyle.ForeColor = cHeaderColor
                    dgvLocal.Rows(x - offset).DefaultCellStyle.SelectionForeColor = cHeaderColor
                    dgvLocal.Rows(x - offset).MinimumHeight = 22
                ElseIf (localData.Rows(x).RowState = DataRowState.Added) Then
                    dgvLocal.Rows(x - offset).ErrorText = "Added but not Committed."
                    dgvLocal.Rows(x - offset).DefaultCellStyle.ForeColor = aHeaderColor
                    dgvLocal.Rows(x - offset).DefaultCellStyle.SelectionForeColor = aHeaderColor
                    dgvLocal.Rows(x - offset).MinimumHeight = 22
                ElseIf (localData.Rows(x).RowError = notFnd) Then
                    dgvLocal.Rows(x - offset).ErrorText = notFnd
                    dgvLocal.Rows(x - offset).DefaultCellStyle.ForeColor = nfHeaderColor
                    dgvLocal.Rows(x - offset).DefaultCellStyle.SelectionForeColor = nfHeaderColor
                    dgvLocal.Rows(x - offset).MinimumHeight = 22
                End If
            Next
            dgvLocal.AutoResizeRows()
            If column > 0 Then
                dgvLocal.Sort(dgvLocal.Columns(column), order)
            End If
            If hasUnapproved Then
                ShowError("Your " & strTableName & " table contains unaproved Terms.", , MsgBoxStyle.Information)
            End If
            btnUpdateLocal.Visible = False
        Catch ex As Exception
            ShowError("There was an error Updating the Local Database", ex)
        End Try
        Me.Cursor = Cursors.Default
    End Sub 'Updates localData to match webData as closely as possible

    Private Sub btnFixRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFixRow.Click
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim oldID As Integer
        Dim newID As Integer = localData.Rows.Count
        Dim oldRow As DataTable = localData.Clone
        Dim newRows As DataTable = localData.Clone
        Dim tempRowValues As DataRow = oldRow.NewRow
        Dim newRowValues As DataRow = newRows.NewRow
        For i = 0 To (localData.Columns.Count - 1)
            tempRowValues.Item(i) = dgvLocal.SelectedRows(0).Cells(i).Value
        Next i
        oldRow.Rows.Add(tempRowValues)
        For i = 0 To (localData.Rows.Count - 1)
            If Not ((localData.Rows(i).RowState = DataRowState.Deleted) Or (localData.Rows(i).RowError = notFnd)) Then
                newRows.Rows.Add(localData.Rows(i).ItemArray)
            End If
        Next i
        Dim fixcvrow As New frmFixRow(newRows, oldRow)
        If fixcvrow.ShowDialog() = DialogResult.OK Then
            newRowValues = fixcvrow.returnRow
            For Each currRow As DataRow In localData.Rows
                If currRow.RowState <> DataRowState.Deleted Then
                    Dim fnd As Boolean = True
                    For i = 0 To (localData.Columns.Count - 1)
                        If (currRow.Item(i).ToString <> newRowValues.Item(i).ToString) Then
                            fnd = False
                            Exit For
                        End If
                    Next i
                    If fnd Then
                        newID = localData.Rows.IndexOf(currRow)
                        Exit For
                    End If
                End If
            Next currRow
            If (newID < localData.Rows.Count) Then
                Dim newRow As DataRow = fixedData.NewRow
                Select Case type
                    Case CVType.Unit
                        newRow.Item(db_fld_UnitsID) = oldRow.Rows(0).Item(db_fld_UnitsID)
                        newRow.Item(db_fld_UnitsName) = oldRow.Rows(0).Item(db_fld_UnitsName)
                        newRow.Item(db_fld_UnitsType) = oldRow.Rows(0).Item(db_fld_UnitsType)
                        newRow.Item(db_fld_UnitsAbrv) = oldRow.Rows(0).Item(db_fld_UnitsAbrv)
                        newRow.Item(expr_NewID) = newID
                    Case CVType.SpatialRef
                        newRow.Item(db_fld_SRID) = oldRow.Rows(0).Item(db_fld_SRID)
                        newRow.Item(db_fld_SRSRSID) = oldRow.Rows(0).Item(db_fld_SRSRSID)
                        newRow.Item(db_fld_SRSRSName) = oldRow.Rows(0).Item(db_fld_SRSRSName)
                        newRow.Item(db_fld_SRIsGeo) = oldRow.Rows(0).Item(db_fld_SRIsGeo)
                        newRow.Item(db_fld_SRNotes) = oldRow.Rows(0).Item(db_fld_SRNotes)
                        newRow.Item(expr_NewID) = newID
                    Case Else
                        newRow.Item(db_fld_CV_Term) = oldRow.Rows(0).Item(db_fld_CV_Term)
                        newRow.Item(db_fld_CV_Definition) = oldRow.Rows(0).Item(db_fld_CV_Definition)
                        newRow.Item(expr_NewID) = newID
                End Select
                fixedData.Rows.Add(newRow)
                changes = True
            End If

            For oldID = 0 To (localData.Rows.Count - 1)
                Dim fnd As Boolean = True
                For i = 0 To (localData.Columns.Count - 1)
                    If localData.Rows(oldID).RowState = DataRowState.Deleted OrElse (localData.Rows(oldID).Item(i).ToString <> oldRow.Rows(0).Item(i).ToString) Then
                        fnd = False
                        Exit For
                    End If
                Next i
                If fnd Then
                    Exit For
                End If
            Next oldID
            If (oldID < localData.Rows.Count) Then
                localData.Rows(oldID).Delete()
            End If
        End If

        For i = 0 To (dgvLocal.SelectedRows.Count - 1)
            dgvLocal.SelectedRows(0).Selected = False
        Next

        dgvLocal.Rows(0).Selected = True

        btnApply.Visible = changes
        Me.Cursor = Cursors.Default
    End Sub 'Opens frmFixRow, which allows user to replace unapproved terms

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Me.Cursor = Cursors.WaitCursor
        If (type = CVType.Unit) Or (type = CVType.SpatialRef) Then
            ApplyFixRow()
            'UpdateOtherTables()
            ApplytoDB(localData)
        Else
            ApplyAdds()
            ApplyFixRow()
            ApplyRemoves()
        End If
        btnRefreshLocal.PerformClick()
        Me.Cursor = Cursors.Default
    End Sub 'Commits the changes to localData to the database

    Private Sub dgvLocal_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLocal.SelectionChanged
        If dgvLocal.SelectedRows.Count > 0 Then
            btnFixRow.Visible = (dgvLocal.SelectedRows(0).ErrorText = notFnd)
        End If
    End Sub 'If the selected row is an unapproved term, make btnFixRow visible

    Private Sub cboCVType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCVType.SelectedIndexChanged
        Select Case cboCVType.SelectedIndex
            Case 0
                strTableName = db_tbl_CensorCodeCV
                type = CVType.CensorCode
            Case 1
                strTableName = db_tbl_DataTypeCV
                type = CVType.DataType
            Case 2
                strTableName = db_tbl_GeneralCategoryCV
                type = CVType.GeneralCategory
            Case 3
                strTableName = db_tbl_SampleMediumCV
                type = CVType.SampleMedium
            Case 4
                strTableName = db_tbl_SampleTypeCV
                type = CVType.SampleType
            Case 5
                strTableName = db_tbl_TopicCategoryCV
                type = CVType.TopicCategory
            Case 6
                strTableName = db_tbl_ValueTypeCV
                type = CVType.ValueType
            Case 7
                strTableName = db_tbl_VariableNameCV
                type = CVType.VariableName
            Case 8
                strTableName = db_tbl_VerticalDatumCV
                type = CVType.VerticalDatum
            Case 9
                strTableName = db_tbl_SpeciationCV
                type = CVType.Speciation
            Case 10
                strTableName = db_tbl_SpatialRefs
                type = CVType.SpatialRef
            Case 11
                strTableName = db_tbl_Units
                type = CVType.Unit
            Case 12
                strTableName = db_tbl_SiteTypeCV
                type = CVType.SiteType
        End Select
        webData = New DataTable
        localData = New DataTable
        fixedData = New DataTable
        webLoaded = False
        localLoaded = False
        changes = False
        If Not (g_CurrConnSettings Is Nothing) Then
            LoadInitial()
        End If
        dgvLocal.Select()
    End Sub 'Changes the selected CV type and refreshes both DataGridViews

    Private Sub btnFinished_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinished.Click
        If changes Then
            Select Case MsgBox("You have not applied your changes to the " & strTableName & " table." & vbCrLf & "Would you like to save your changes before you quit?", MsgBoxStyle.YesNoCancel, "Uncommited Changes")
                Case MsgBoxResult.Yes
                    Me.Cursor = Cursors.WaitCursor
                    ApplyFixRow()
                    ApplytoDB(localData)
                    Me.Cursor = Cursors.Default
                    RaiseEvent Finished()
                Case MsgBoxResult.No
                    RaiseEvent Finished()
            End Select
        Else
            RaiseEvent Finished()
        End If
    End Sub 'If ready to finish, calls the Finished() event.

    Private Sub dgvLocal_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLocal.Sorted
        Dim x As Integer = 0
        Dim offset As Integer = 0
        For x = 0 To localData.Rows.Count - 1
            If (localData.Rows(x).RowState = DataRowState.Deleted) Then
                offset += 1
            ElseIf (localData.Rows(x).RowState = DataRowState.Modified) Then
                dgvLocal.Rows(x - offset).ErrorText = "Modified but not Committed."
                dgvLocal.Rows(x - offset).DefaultCellStyle.ForeColor = cHeaderColor
                dgvLocal.Rows(x - offset).DefaultCellStyle.SelectionForeColor = cHeaderColor
                dgvLocal.Rows(x - offset).MinimumHeight = 22
            ElseIf (localData.Rows(x).RowState = DataRowState.Added) Then
                dgvLocal.Rows(x - offset).ErrorText = "Added but not Committed."
                dgvLocal.Rows(x - offset).DefaultCellStyle.ForeColor = aHeaderColor
                dgvLocal.Rows(x - offset).DefaultCellStyle.SelectionForeColor = aHeaderColor
                dgvLocal.Rows(x - offset).MinimumHeight = 22
            ElseIf (localData.Rows(x).RowError = notFnd) Then
                dgvLocal.Rows(x - offset).ErrorText = notFnd
                dgvLocal.Rows(x - offset).DefaultCellStyle.ForeColor = nfHeaderColor
                dgvLocal.Rows(x - offset).DefaultCellStyle.SelectionForeColor = nfHeaderColor
                dgvLocal.Rows(x - offset).MinimumHeight = 22
            End If
        Next
    End Sub 'When dgvLocal has been sorted, reapplies error markings.

    Private Sub ApplyAdds()
        Dim commitTable As DataTable = localData.Copy
        Dim i As Integer
        While (i < commitTable.Rows.Count)
            If commitTable.Rows(i).RowState = DataRowState.Deleted Then
                commitTable.Rows.RemoveAt(i)
            Else
                i += 1
            End If
        End While
        ApplytoDB(commitTable)
    End Sub

    Private Sub ApplyRemoves()
        Dim commitTable As DataTable = localData.Copy
        Dim i As Integer
        While (i < commitTable.Rows.Count)
            If commitTable.Rows(i).RowState <> DataRowState.Deleted Then
                commitTable.Rows.RemoveAt(i)
            Else
                i += 1
            End If
        End While
        ApplytoDB(commitTable)
    End Sub

#End Region

   
End Class
