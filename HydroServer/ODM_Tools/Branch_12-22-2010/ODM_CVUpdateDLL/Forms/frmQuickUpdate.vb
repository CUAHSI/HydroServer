'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
Public Class frmQuickUpdate
    Private type As CVType = CVType.CensorCode
    Private strTableName As String = db_tbl_CensorCodeCV

    Private webLoaded As Boolean = False
    Private localLoaded As Boolean = False
    Private changes As Boolean = False
    Private hasUnapproved As Boolean = False
    Private running As Boolean = False

    Private webData As DataTable
    Private localData As DataTable
    Private fixedData As DataTable 'The fixed unapproved terms.

    Private Const notFnd As String = "Unapproved Term."
    Private Const expr_NewID As String = "NewID" 'The column name for newID of the fixedData table
    Private Const numUpdates As Integer = 12

    Private ReadOnly Property isRunning() As Boolean
        Get
            Return running
        End Get
    End Property

    Private Property UpdateType() As CVType
        Get
            Return type
        End Get
        Set(ByVal value As CVType)
            type = value
            Select Case value
                Case CVType.CensorCode
                    strTableName = db_tbl_CensorCodeCV
                Case CVType.DataType
                    strTableName = db_tbl_DataTypeCV
                Case CVType.GeneralCategory
                    strTableName = db_tbl_GeneralCategoryCV
                Case CVType.SampleMedium
                    strTableName = db_tbl_SampleMediumCV
                Case CVType.SampleType
                    strTableName = db_tbl_SampleTypeCV
                Case CVType.TopicCategory
                    strTableName = db_tbl_TopicCategoryCV
                Case CVType.ValueType
                    strTableName = db_tbl_ValueTypeCV
                Case CVType.VariableName
                    strTableName = db_tbl_VariableNameCV
                Case CVType.VerticalDatum
                    strTableName = db_tbl_VerticalDatumCV
                Case CVType.Speciation
                    strTableName = db_tbl_SpeciationCV
                Case CVType.SpatialRef
                    strTableName = db_tbl_SpatialRefs
                Case CVType.Unit
                    strTableName = db_tbl_Units
            End Select
            webData = New DataTable
            localData = New DataTable
            webLoaded = False
            localLoaded = False
            changes = False
            RunUpdate()
        End Set
    End Property

    Private Function RunUpdate() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Try
            GetWebUpdates()
            GetLocalDB()
            If (localLoaded) And (webLoaded) Then
                'UpdateLocal()
                'UpdateOtherTables()
                'ApplytoDB(localData)
                If (type = CVType.Unit) Or (type = CVType.SpatialRef) Then
                    'ApplyFixRow()
                    localData = UpdateLocal()
                    UpdateOtherTables()
                    ApplytoDB(localData)
                Else
                    localData = UpdateLocal()
                    ApplyRemoves()
                    ApplyAdds()
                    ApplyFixRow()
                End If
            End If

            webLoaded = True
            localLoaded = True

        Catch ex As Exception
            ShowError("There was an error running the automatic update.", ex)
            Me.Cursor = Cursors.Default
            Return False
        End Try
        Me.Cursor = Cursors.Default
        Return True
    End Function

    Private Sub GetWebUpdates()
        webLoaded = True
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
        webData = tempTable
    End Sub

    Private Sub GetLocalDB()
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

        localData = OpenTable(strTableName, sql, g_CurrConnSettings)
        changes = False
        localLoaded = True
    End Sub

    Private Function UpdateLocal() As DataTable
        Dim WebTable, LocalTable As DataTable
        Dim newRow As DataRow
        Dim fndRows() As DataRow
        Const match As String = "Matches"

        hasUnapproved = False
        WebTable = webData.Copy
        LocalTable = localData.Copy
        fixedData = localData.Clone
        fixedData.Columns.Add("NewID")
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
        Return LocalTable
    End Function 'Returns a dataTable copied from localData that has been updated to match webData as closely as possible

    'Private Sub UpdateLocal()
    '    Dim WebTable As DataTable
    '    Dim LocalTable As DataTable
    '    Dim x, y As Integer
    '    Dim newRow As DataRow

    '    hasUnapproved = False
    '    WebTable = webData.Copy
    '    LocalTable = localData.Copy
    '    Select Case type
    '        'Case CVType.QCLevel
    '        '    'Matches
    '        '    For x = 0 To LocalTable.Rows.Count - 1
    '        '        If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '        '            For y = 0 To WebTable.Rows.Count - 1
    '        '                If (Val(LocalTable.Rows(x).Item(db_fld_QCLQCLevel)) = Val(WebTable.Rows(y).Item(db_fld_QCLQCLevel).ToString)) AndAlso (LocalTable.Rows(x).Item(db_fld_QCLDefinition).ToString = WebTable.Rows(y).Item(db_fld_QCLDefinition).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_QCLExplanation).ToString = WebTable.Rows(y).Item(db_fld_QCLExplanation).ToString) Then
    '        '                    WebTable.Rows(y).Delete()
    '        '                    Exit For
    '        '                End If
    '        '            Next y
    '        '        End If
    '        '    Next x
    '        '    'Changes 
    '        '    y = 0
    '        '    While (y < WebTable.Rows.Count)
    '        '        Dim fnd As Boolean = False
    '        '        For x = 0 To LocalTable.Rows.Count - 1
    '        '            If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '        '                If (Val(LocalTable.Rows(x).Item(db_fld_QCLQCLevel)) = Val(WebTable.Rows(y).Item(db_fld_QCLQCLevel))) Then
    '        '                    LocalTable.Rows(x).Item(db_fld_QCLDefinition) = WebTable.Rows(y).Item(db_fld_QCLDefinition).ToString
    '        '                    LocalTable.Rows(x).Item(db_fld_QCLExplanation) = WebTable.Rows(y).Item(db_fld_QCLExplanation).ToString
    '        '                    changes = True
    '        '                    fnd = True
    '        '                    Exit For
    '        '                End If
    '        '            End If
    '        '        Next x
    '        '        If fnd Then
    '        '            WebTable.Rows(y).Delete()
    '        '        Else
    '        '            y += 1
    '        '        End If
    '        '    End While
    '        '    'Additions
    '        '    For y = 0 To WebTable.Rows.Count - 1
    '        '        newRow = LocalTable.NewRow
    '        '        newRow.Item(db_fld_QCLQCLevel) = Val(WebTable.Rows(y).Item(db_fld_QCLQCLevel).ToString)
    '        '        newRow.Item(db_fld_QCLDefinition) = WebTable.Rows(y).Item(db_fld_QCLDefinition).ToString
    '        '        newRow.Item(db_fld_QCLExplanation) = WebTable.Rows(y).Item(db_fld_QCLExplanation).ToString
    '        '        LocalTable.Rows.Add(newRow)
    '        '        changes = True
    '        '    Next y
    '        '    'Deletions
    '        '    x = 0
    '        '    While (x < LocalTable.Rows.Count)
    '        '        If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '        '            Dim fnd As Boolean = False
    '        '            For y = 0 To (webData.Rows.Count - 1)
    '        '                If (Val(LocalTable.Rows(x).Item(db_fld_QCLQCLevel)) = Val(webData.Rows(y).Item(db_fld_QCLQCLevel))) AndAlso (LocalTable.Rows(x).Item(db_fld_QCLDefinition).ToString = webData.Rows(y).Item(db_fld_QCLDefinition).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_QCLExplanation).ToString = webData.Rows(y).Item(db_fld_QCLExplanation).ToString) Then
    '        '                    fnd = True
    '        '                    Exit For
    '        '                End If
    '        '            Next
    '        '            If Not fnd Then
    '        '                If timesUsed(LocalTable.Rows(x).Item(db_fld_QCLQCLevel)) = 0 Then
    '        '                    LocalTable.Rows(x).Delete()
    '        '                    changes = True
    '        '                Else
    '        '                    LocalTable.Rows(x).RowError = notFnd
    '        '                    hasUnapproved = True
    '        '                    x += 1
    '        '                End If
    '        '            Else
    '        '                x += 1
    '        '            End If
    '        '        Else
    '        '            x += 1
    '        '        End If
    '        '    End While
    '        Case CVType.SpatialRef
    '            'Matches
    '            For x = 0 To LocalTable.Rows.Count - 1
    '                If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '                    For y = 0 To WebTable.Rows.Count - 1
    '                        If (Val(LocalTable.Rows(x).Item(db_fld_SRID).ToString) = Val(WebTable.Rows(y).Item(db_fld_SRID).ToString)) AndAlso (Val(LocalTable.Rows(x).Item(db_fld_SRSRSID).ToString) = Val(WebTable.Rows(y).Item(db_fld_SRSRSID).ToString)) AndAlso (LocalTable.Rows(x).Item(db_fld_SRSRSName).ToString = WebTable.Rows(y).Item(db_fld_SRSRSName).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_SRIsGeo).ToString = WebTable.Rows(y).Item(db_fld_SRIsGeo).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_SRNotes).ToString = WebTable.Rows(y).Item(db_fld_SRNotes).ToString) Then
    '                            WebTable.Rows(y).Delete()
    '                            Exit For
    '                        End If
    '                    Next y
    '                End If
    '            Next x
    '            'Changes 
    '            y = 0
    '            While (y < WebTable.Rows.Count)
    '                Dim fnd As Boolean = False
    '                For x = 0 To LocalTable.Rows.Count - 1
    '                    If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '                        If (Val(LocalTable.Rows(x).Item(db_fld_SRID)) = Val(WebTable.Rows(y).Item(db_fld_SRID))) Then
    '                            LocalTable.Rows(x).Item(db_fld_SRSRSID) = Val(WebTable.Rows(y).Item(db_fld_SRSRSID))
    '                            LocalTable.Rows(x).Item(db_fld_SRSRSName) = WebTable.Rows(y).Item(db_fld_SRSRSName).ToString
    '                            LocalTable.Rows(x).Item(db_fld_SRIsGeo) = CBool(WebTable.Rows(y).Item(db_fld_SRIsGeo))
    '                            LocalTable.Rows(x).Item(db_fld_SRNotes) = WebTable.Rows(y).Item(db_fld_SRNotes).ToString
    '                            changes = True
    '                            fnd = True
    '                            Exit For
    '                        End If
    '                    End If
    '                Next x
    '                If fnd Then
    '                    WebTable.Rows(y).Delete()
    '                Else
    '                    y += 1
    '                End If
    '            End While
    '            'Additions
    '            For y = 0 To WebTable.Rows.Count - 1
    '                newRow = LocalTable.NewRow
    '                newRow.Item(db_fld_SRID) = Val(WebTable.Rows(y).Item(db_fld_SRID))
    '                If WebTable.Rows(y).Item(db_fld_SRSRSID) = "" Then
    '                    newRow.Item(db_fld_SRSRSID) = DBNull.Value
    '                Else
    '                    newRow.Item(db_fld_SRSRSID) = Val(WebTable.Rows(y).Item(db_fld_SRSRSID))
    '                End If
    '                newRow.Item(db_fld_SRSRSName) = WebTable.Rows(y).Item(db_fld_SRSRSName).ToString
    '                newRow.Item(db_fld_SRIsGeo) = CBool(WebTable.Rows(y).Item(db_fld_SRIsGeo))
    '                newRow.Item(db_fld_SRNotes) = WebTable.Rows(y).Item(db_fld_SRNotes).ToString
    '                LocalTable.Rows.Add(newRow)
    '                changes = True
    '            Next y
    '            'Deletions
    '            x = 0
    '            While (x < LocalTable.Rows.Count)
    '                If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '                    Dim fnd As Boolean = False
    '                    For y = 0 To (webData.Rows.Count - 1)
    '                        If (Val(LocalTable.Rows(x).Item(db_fld_SRID)) = Val(webData.Rows(y).Item(db_fld_SRID))) AndAlso (Val(LocalTable.Rows(x).Item(db_fld_SRSRSID).ToString) = Val(webData.Rows(y).Item(db_fld_SRSRSID)).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_SRSRSName).ToString = webData.Rows(y).Item(db_fld_SRSRSName).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_SRIsGeo).ToString = webData.Rows(y).Item(db_fld_SRIsGeo).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_SRNotes).ToString = webData.Rows(y).Item(db_fld_SRNotes).ToString) Then
    '                            fnd = True
    '                            Exit For
    '                        End If
    '                    Next
    '                    If Not fnd Then
    '                        If timesUsed(LocalTable.Rows(x).Item(db_fld_SRID)) = 0 Then
    '                            LocalTable.Rows(x).Delete()
    '                            changes = True
    '                        Else
    '                            LocalTable.Rows(x).RowError = notFnd
    '                            hasUnapproved = True
    '                            x += 1
    '                        End If
    '                    Else
    '                        x += 1
    '                    End If
    '                Else
    '                    x += 1
    '                End If
    '            End While
    '        Case CVType.Unit
    '            'Matches
    '            For x = 0 To LocalTable.Rows.Count - 1
    '                If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '                    For y = 0 To WebTable.Rows.Count - 1
    '                        If (LocalTable.Rows(x).Item(db_fld_UnitsName).ToString = WebTable.Rows(y).Item(db_fld_UnitsName).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_UnitsType).ToString = WebTable.Rows(y).Item(db_fld_UnitsType).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_UnitsAbrv).ToString = WebTable.Rows(y).Item(db_fld_UnitsAbrv).ToString) Then
    '                            WebTable.Rows(y).Delete()
    '                            Exit For
    '                        End If
    '                    Next y
    '                End If
    '            Next x
    '            'Changes 
    '            y = 0
    '            While (y < WebTable.Rows.Count)
    '                Dim fnd As Boolean = False
    '                For x = 0 To LocalTable.Rows.Count - 1
    '                    If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '                        If (LocalTable.Rows(x).Item(db_fld_UnitsID).ToString = WebTable.Rows(y).Item(db_fld_UnitsID).ToString) Then
    '                            LocalTable.Rows(x).Item(db_fld_UnitsName) = WebTable.Rows(y).Item(db_fld_UnitsName).ToString
    '                            LocalTable.Rows(x).Item(db_fld_UnitsType) = WebTable.Rows(y).Item(db_fld_UnitsType).ToString
    '                            LocalTable.Rows(x).Item(db_fld_UnitsAbrv) = WebTable.Rows(y).Item(db_fld_UnitsAbrv).ToString
    '                            changes = True
    '                            fnd = True
    '                            Exit For
    '                        End If
    '                    End If
    '                Next x
    '                If fnd Then
    '                    WebTable.Rows(y).Delete()
    '                Else
    '                    y += 1
    '                End If
    '            End While
    '            'Additions
    '            For y = 0 To WebTable.Rows.Count - 1
    '                newRow = LocalTable.NewRow
    '                newRow.Item(db_fld_UnitsID) = Val(WebTable.Rows(y).Item(db_fld_UnitsID))
    '                newRow.Item(db_fld_UnitsName) = WebTable.Rows(y).Item(db_fld_UnitsName).ToString
    '                newRow.Item(db_fld_UnitsType) = WebTable.Rows(y).Item(db_fld_UnitsType).ToString
    '                newRow.Item(db_fld_UnitsAbrv) = WebTable.Rows(y).Item(db_fld_UnitsAbrv).ToString
    '                LocalTable.Rows.Add(newRow)
    '                changes = True
    '            Next y
    '            'Deletions
    '            x = 0
    '            While (x < LocalTable.Rows.Count)
    '                If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '                    Dim fnd As Boolean = False
    '                    For y = 0 To (webData.Rows.Count - 1)
    '                        If (LocalTable.Rows(x).Item(db_fld_UnitsID).ToString = webData.Rows(y).Item(db_fld_UnitsID).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_UnitsName).ToString = webData.Rows(y).Item(db_fld_UnitsName).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_UnitsType).ToString = webData.Rows(y).Item(db_fld_UnitsType).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_UnitsAbrv).ToString = webData.Rows(y).Item(db_fld_UnitsAbrv).ToString) Then
    '                            fnd = True
    '                            Exit For
    '                        End If
    '                    Next
    '                    If Not fnd Then
    '                        If timesUsed(LocalTable.Rows(x).Item(db_fld_UnitsID)) = 0 Then
    '                            LocalTable.Rows(x).Delete()
    '                            changes = True
    '                        Else
    '                            LocalTable.Rows(x).RowError = notFnd
    '                            hasUnapproved = True
    '                            x += 1
    '                        End If
    '                    Else
    '                        x += 1
    '                    End If
    '                Else
    '                    x += 1
    '                End If
    '            End While
    '        Case Else 'All other CVs without IDs
    '            'Matches
    '            For x = 0 To LocalTable.Rows.Count - 1
    '                If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '                    For y = 0 To WebTable.Rows.Count - 1
    '                        If (LocalTable.Rows(x).Item(db_fld_CV_Term).ToString = WebTable.Rows(y).Item(db_fld_CV_Term).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_CV_Definition).ToString = WebTable.Rows(y).Item(db_fld_CV_Definition).ToString) Then
    '                            WebTable.Rows(y).Delete()
    '                            Exit For
    '                        End If
    '                    Next y
    '                End If
    '            Next x
    '            'Changes 
    '            y = 0
    '            While (y < WebTable.Rows.Count)
    '                Dim fnd As Boolean = False
    '                For x = 0 To LocalTable.Rows.Count - 1
    '                    If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '                        If (LocalTable.Rows(x).Item(db_fld_CV_Term).ToString = WebTable.Rows(y).Item(db_fld_CV_Term).ToString) Then
    '                            LocalTable.Rows(x).Item(db_fld_CV_Definition) = WebTable.Rows(y).Item(db_fld_CV_Definition)
    '                            changes = True
    '                            fnd = True
    '                            Exit For
    '                        End If
    '                        If (LocalTable.Rows(x).Item(db_fld_CV_Definition).ToString = WebTable.Rows(y).Item(db_fld_CV_Definition).ToString) Then
    '                            LocalTable.Rows(x).Item(db_fld_CV_Term) = WebTable.Rows(y).Item(db_fld_CV_Term)
    '                            changes = True
    '                            fnd = True
    '                            Exit For
    '                        End If
    '                    End If
    '                Next x
    '                If fnd Then
    '                    WebTable.Rows(y).Delete()
    '                Else
    '                    y += 1
    '                End If
    '            End While
    '            'Additions
    '            For y = 0 To WebTable.Rows.Count - 1
    '                newRow = LocalTable.NewRow
    '                newRow.Item(db_fld_CV_Term) = WebTable.Rows(y).Item(db_fld_CV_Term).ToString
    '                newRow.Item(db_fld_CV_Definition) = WebTable.Rows(y).Item(db_fld_CV_Definition).ToString
    '                LocalTable.Rows.Add(newRow)
    '                changes = True
    '            Next y
    '            'Deletions
    '            x = 0
    '            While (x < LocalTable.Rows.Count)
    '                If (LocalTable.Rows(x).RowState <> DataRowState.Deleted) Then
    '                    Dim fnd As Boolean = False
    '                    For y = 0 To (webData.Rows.Count - 1)
    '                        If (LocalTable.Rows(x).Item(db_fld_CV_Term).ToString = webData.Rows(y).Item(db_fld_CV_Term).ToString) AndAlso (LocalTable.Rows(x).Item(db_fld_CV_Definition).ToString = webData.Rows(y).Item(db_fld_CV_Definition).ToString) Then
    '                            fnd = True
    '                            Exit For
    '                        End If
    '                    Next
    '                    If Not fnd Then
    '                        If timesUsed(LocalTable.Rows(x).Item(db_fld_CV_Term)) = 0 Then
    '                            LocalTable.Rows(x).Delete()
    '                            changes = True
    '                        Else
    '                            LocalTable.Rows(x).RowError = notFnd
    '                            hasUnapproved = True
    '                            x += 1
    '                        End If
    '                    Else
    '                        x += 1
    '                    End If
    '                Else
    '                    x += 1
    '                End If
    '            End While
    '    End Select

    '    localData = LocalTable
    'End Sub

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
    End Function

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
        Dim tempie As New DataSet("BOB")
        UpdateTable(LocalTable, sql, g_CurrConnSettings.ConnectionString)
    End Function

    Private Sub UpdateOtherTables()
        Dim connection As New OleDb.OleDbConnection(g_CurrConnSettings.ConnectionString)
        Dim command As OleDb.OleDbCommand
        Dim trans As OleDb.OleDbTransaction
        Dim sql As String
        Dim i As Integer
        connection.Open()
        trans = connection.BeginTransaction

        Select Case type
            Case CVType.CensorCode
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_DataValues & " SET " & db_fld_ValCensorCode & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_DataValues & "." & db_fld_ValCensorCode & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        connection.Close()
                    End If
                Next
            Case CVType.DataType
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarDataType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarDataType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCDataType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCDataType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    End If
                Next
            Case CVType.GeneralCategory
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarGenCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarGenCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCGenCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCGenCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    End If
                Next
            Case CVType.SampleMedium
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarSampleMed & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarSampleMed & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCSampleMed & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSampleMed & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    End If
                Next
            Case CVType.SampleType
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_Samples & " SET " & db_fld_SampleType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Samples & "." & db_fld_SampleType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    End If
                Next
            Case CVType.TopicCategory
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_ISOMetaData & " SET " & db_fld_IMDTopicCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_ISOMetaData & "." & db_fld_IMDTopicCat & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    End If
                Next
            Case CVType.ValueType
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarValueType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarValueType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCValueType & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCValueType & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    End If
                Next
            Case CVType.VariableName
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarName & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarName & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCVarName & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCVarName & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    End If
                Next
            Case CVType.VerticalDatum
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_SiteVertDatum & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Sites & "." & db_fld_SiteVertDatum & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    End If
                Next
            Case CVType.Speciation
                For i = 0 To (localData.Rows.Count - 1)
                    If (localData.Rows(i).RowState = DataRowState.Modified) Then
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarSpec & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_Variables & "." & db_fld_VarSpec & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCSpeciation & " = '" & localData.Rows(i).Item(db_fld_CV_Term) & "' WHERE (" & db_tbl_SeriesCatalog & "." & db_fld_SCSpeciation & " = '" & localData.Rows(i).Item(db_fld_CV_Term, DataRowVersion.Original) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    End If
                Next
            Case Else
                Exit Sub
        End Select
    End Sub

    Public Sub New(ByVal ServerAddress As String, ByVal DBName As String, ByVal Timeout As Integer, ByVal Trusted As Boolean, ByVal UserID As String, ByVal Password As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        g_CurrConnSettings = New clsConnectionSettings(ServerAddress, DBName, Timeout, Trusted, UserID, Password)
    End Sub

    Public Sub RunCVUpdate()
        progUpdate.Value = progUpdate.Minimum
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.CensorCode
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 1
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.DataType
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 2
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.GeneralCategory
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 3
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.Speciation
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 4
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.SampleMedium
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 5
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.SampleType
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 6
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.SpatialRef
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 7
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.TopicCategory
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 8
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.Unit
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 9
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.ValueType
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 10
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.VariableName
        RunUpdate()
        progUpdate.Value = ((progUpdate.Maximum - progUpdate.Minimum) / numUpdates) * 11
        progUpdate.Refresh()
        Me.Refresh()
        UpdateType = CVType.VerticalDatum
        RunUpdate()
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

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

    Private Function ApplyFixRow() As Boolean
        Dim connection As New OleDb.OleDbConnection(g_CurrConnSettings.ConnectionString)
        Dim trans As OleDb.OleDbTransaction
        Dim commit As Boolean = True
        Dim command As OleDb.OleDbCommand
        Dim sql As String = ""
        Dim i As Integer
        connection.Open()
        trans = connection.BeginTransaction
        Try
            For i = 0 To (fixedData.Rows.Count - 1)
                Select Case type
                    Case CVType.CensorCode
                        sql = "UPDATE " & db_tbl_DataValues & " SET " & db_fld_ValCensorCode & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_ValCensorCode & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.DataType
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarDataType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarDataType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCDataType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarDataType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.GeneralCategory
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarGenCat & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarGenCat & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCGenCat & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarGenCat & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.SampleMedium
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarSampleMed & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarSampleMed & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.SampleType
                        sql = "UPDATE " & db_tbl_Samples & " SET " & db_fld_SampleType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_SampleType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.TopicCategory
                        sql = "UPDATE " & db_tbl_ISOMetaData & " SET " & db_fld_IMDTopicCat & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_IMDTopicCat & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.ValueType
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarValueType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarValueType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCValueType & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarValueType & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.VariableName
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarName & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarName & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCVarName & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarName & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.VerticalDatum
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_SiteVertDatum & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_SiteVertDatum & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.Speciation
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_VarSpec & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarSpec & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCSpeciation & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_CV_Term) & "' WHERE (" & db_fld_VarSpec & " = '" & fixedData.Rows(i).Item(db_fld_CV_Term) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.SpatialRef
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_SiteLatLongDatumID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_SRID) & "' WHERE (" & db_fld_SiteLatLongDatumID & " = '" & fixedData.Rows(i).Item(db_fld_SRID) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_Sites & " SET " & db_fld_SiteLocProjID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_SRID) & "' WHERE (" & db_fld_SiteLocProjID & " = '" & fixedData.Rows(i).Item(db_fld_SRID) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                    Case CVType.Unit
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCTimeUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_SCTimeUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_SeriesCatalog & " SET " & db_fld_SCVarUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_SCVarUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_OffsetTypes & " SET " & db_fld_OTUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_OTUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_VarUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
                        command.ExecuteScalar()
                        sql = "UPDATE " & db_tbl_Variables & " SET " & db_fld_VarTimeUnitsID & " = '" & localData.Rows(fixedData.Rows(i).Item(expr_NewID)).Item(db_fld_UnitsID) & "' WHERE (" & db_fld_VarTimeUnitsID & " = '" & fixedData.Rows(i).Item(db_fld_UnitsID) & "')"
                        command = New OleDb.OleDbCommand(sql, connection, trans)
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

End Class
