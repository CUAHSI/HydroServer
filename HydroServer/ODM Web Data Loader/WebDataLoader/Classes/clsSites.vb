Class clsSites
    Inherits clsFile

#Region " Database Field Constants "

#Region " Sites "
    'Sites
    Public Const db_tbl_Sites As String = "Sites" 'Table Name
    Public Const db_fld_SiteID As String = "SiteID" 'M Integer: Primary Key -> Unique ID for each Sites entry
    Public Const db_fld_SiteCode As String = "SiteCode" 'M String: 50 -> Code used by organization that collects the data
    Public Const db_fld_SiteName As String = "SiteName" 'M String: 255 -> Full name of sampling location
    Public Const db_fld_Latitude As String = "Latitude" 'M Double -> Latitude in degrees w/ Decimals
    Public Const db_fld_Longitude As String = "Longitude" 'M Double -> Longitude in degrees w/ Decimals
    Public Const db_fld_LatLongDatumID As String = "LatLongDatumID" 'M Integer -> Linked to SpatialReferences.SpatialReferenceID
    Public Const db_fld_Elevation_m As String = "Elevation_m" 'O Double -> Elevation of sampling location in meters.  
    Public Const db_fld_VerticalDatum As String = "VerticalDatum" 'O String: 255 -> CV. Vertical Datum 
    Public Const db_fld_LocalX As String = "LocalX" 'O Double -> Local Projection X Coordinate
    Public Const db_fld_LocalY As String = "LocalY" 'O Double -> Local Projection Y Coordinate
    Public Const db_fld_LocalProjectionID As String = "LocalProjectionID" 'O Integer -> Linked to SpatialReferences.SpatialReferenceID
    Public Const db_fld_PosAccuracy_m As String = "PosAccuracy_m" 'O Double -> Value giving the acuracy with which the positional information is specified.  in meters
    Public Const db_fld_State As String = "State" 'O String: 255 -> Name of state in which the sampling station is located
    Public Const db_fld_County As String = "County" 'O String: 255 -> Name of County in which the sampling station is located
    Public Const db_fld_Comments As String = "Comments" 'O String: MAX -> Comments related to the site
#End Region

#Region " SpatialReferences "
    'SpatialReferences
    Public Const db_tbl_SpatialReferences As String = "SpatialReferences" 'Table Name
    Public Const db_fld_SpatialReferenceID As String = "SpatialReferenceID" 'M Integer: Primary Key -> Unique ID for each SpatialReferences entry
    Public Const db_fld_SRSID As String = "SRSID" 'O Integer -> ID for Spatial Reference System @ http://epsg.org/
    Public Const db_fld_SRSName As String = "SRSName" 'M String: 255 -> Name of spatial reference system
    Public Const db_fld_IsGeographic As String = "IsGeographic" 'M Boolean -> Whether it uses geographic coordinates (Lat., Long.)
    Public Const db_fld_Notes As String = "Notes" 'O String: MAX -> Descriptive information about reference system
#End Region

#Region " Controlled Vocabulary Table Definitions "

    'table names
    Public Const db_tbl_VerticalDatumCV As String = "VerticalDatumCV"

    'fields
    Public Const db_fld_CV_Term As String = "Term"
    Public Const db_fld_CV_Definition As String = "Definition"

#End Region

#End Region

#Region " File Field Constants "
    Public Const file_Sites As String = "sites"
    Public Const file_Sites_SiteCode As String = "sitecode"                            'R
    Public Const file_Sites_SiteName As String = "sitename"                            'R
    Public Const file_Sites_Latitude As String = "latitude"                            'R
    Public Const file_Sites_Longitude As String = "longitude"                          'R
#Region " LatLongDatum Columns                                             'R"
    Public Const file_Sites_LatLongDatumID As String = "latlongdatumid"                'R
    Public Const file_Sites_LatLongDatumSRSID As String = "latlongdatumsrsid"          'A
    Public Const file_Sites_LatLongDatumSRSName As String = "latlongdatumsrsname"      'A
#End Region
    Public Const file_Sites_Elevation_m As String = "elevation_m"                      'O
    Public Const file_Sites_VerticalDatum As String = "verticaldatum"                  'O
    Public Const file_Sites_LocalX As String = "localx"                                'O
    Public Const file_Sites_LocalY As String = "localy"                                'O
#Region " LocalProjection Columns                                          'O"
    Public Const file_Sites_LocalProjectionID As String = "localprojectionid"          'O
    Public Const file_Sites_LocalProjectionSRSID As String = "localprojectionsrsid"    'A
    Public Const file_Sites_LocalProjectionSRSName As String = "localprojectionsrsname" 'A
#End Region
    Public Const file_Sites_PosAccuracy_m As String = "posaccuracy_m"                  'O
    Public Const file_Sites_SiteState As String = "sitestate"                          'O
    Public Const file_Sites_County As String = "county"                                'O
    Public Const file_Sites_Comments As String = "comments"                            'O
#End Region

    Public Sub New(ByVal e_Connection As clsConnection)
        MyBase.New(e_Connection)
        MyType = "Sites"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        MyBase.New(e_Connection, filePath)
        MyType = "Sites"
    End Sub

    Public Sub New(ByVal m_viewtable As clsFile)
        MyBase.new(m_viewtable)
        MyType = "Sites"
    End Sub

    Public Sub New(ByVal e_Connection As clsConnection, ByVal m_viewtable As DataTable, Optional ByVal e_ThrowFileOnError As Boolean = False)
        MyBase.new(e_Connection, m_viewtable)
        MyType = "Sites"
        m_ThrowFileOnRepeat = e_ThrowFileOnError
        m_ThrowFileOnNulls = e_ThrowFileOnError
    End Sub

    Protected Overrides Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Dim valid as new datatable
        'Declare all of your CVs Here
        Dim SpatialReferences, VerticalDatum as new datatable
        Dim i As Integer
        Dim fileRows() As DataRow

        Try
            If (m_Connection Is Nothing) OrElse (m_Connection.ConnectionString = "") Then
                Throw New Exception("No Database Connection")
            End If

            'Load The Table Template Here
            valid = m_Connection.OpenTable(connect, trans, db_tbl_Sites, "SELECT * FROM " & db_tbl_Sites) ' & " WHERE " & db_tbl_Sites & "." & db_fld_SiteID & " <> " & db_tbl_Sites & "." & db_fld_SiteID)
            If (valid Is Nothing) Then
                Throw New Exception("Error Getting Database Schema")
            End If

            'Load all of the CV and other related tables here
            SpatialReferences = m_Connection.OpenTable(connect, trans, db_tbl_SpatialReferences, "SELECT * FROM " & db_tbl_SpatialReferences)
            VerticalDatum = m_Connection.OpenTable(connect, trans, db_tbl_VerticalDatumCV, "SELECT * FROM " & db_tbl_VerticalDatumCV)

            If (m_ViewTable.Columns.IndexOf(file_Sites_SiteCode) >= 0) Then
                fileRows = m_ViewTable.Select(file_Sites_SiteCode & " IS NOT NULL AND " & file_Sites_SiteCode & " <> ''", file_Sites_SiteCode & " ASC")
                If (m_ThrowFileOnNulls) Then
                    If (fileRows.Length < m_ViewTable.Rows.Count) Then
                        Throw New Exception(file_Sites_SiteCode & " cannot be NULL.")
                    End If
                End If
            Else
                Throw New Exception("Unable to find " & file_Sites_SiteCode & " column.")
            End If

            valid.Constraints.Add("AllUnique", valid.Columns(db_fld_SiteCode), False)

            For i = 0 To (fileRows.Length - 1)
                Dim tempRow As DataRow = valid.NewRow
                Dim fileRow As DataRow = fileRows(i)
                'Required columns
                '----------------
                'SiteID
                tempRow.Item(db_fld_SiteID) = i

                'SiteCode
                If (m_ViewTable.Columns.IndexOf(file_Sites_SiteCode) >= 0) Then
                    If (fileRow.Item(file_Sites_SiteCode).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sites_SiteCode), "[\040]", "_")
                        temp = System.Text.RegularExpressions.Regex.Replace(temp, "[\,\+]", ".")
                        temp = System.Text.RegularExpressions.Regex.Replace(temp, "[\:\\\/\=]", "-")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[^0-9a-zA-Z\.\-_]").Count() = 0 Then
                            tempRow.Item(db_fld_SiteCode) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sites_SiteCode & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception(file_Sites_SiteCode & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sites_SiteCode & " column.")
                End If

                'SiteName
                If (m_ViewTable.Columns.IndexOf(file_Sites_SiteName) >= 0) Then
                    If (fileRow.Item(file_Sites_SiteName).ToString <> "") Then
                        Dim temp As String
                        temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sites_SiteName), "[\t\r\v\f\n]", "")

                        If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                            tempRow.Item(db_fld_SiteName) = temp
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sites_SiteName & " contains invalid characters.")
                        End If
                    Else
                        Throw New Exception(file_Sites_SiteName & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sites_SiteName & " column.")
                End If

                'Latitude
                If (m_ViewTable.Columns.IndexOf(file_Sites_Latitude) >= 0) Then
                    If (fileRow.Item(file_Sites_Latitude).ToString <> "") Then
                        tempRow.Item(db_fld_Latitude) = Val(fileRow.Item(file_Sites_Latitude))
                    Else
                        Throw New Exception(file_Sites_Latitude & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sites_Latitude & " column.")
                End If

                'Longitude
                If (m_ViewTable.Columns.IndexOf(file_Sites_Longitude) >= 0) Then
                    If (fileRow.Item(file_Sites_Longitude).ToString <> "") Then
                        tempRow.Item(db_fld_Longitude) = Val(fileRow.Item(file_Sites_Longitude))
                    Else
                        Throw New Exception(file_Sites_Longitude & " cannot be Null.")
                    End If
                Else
                    Throw New Exception("Unable to find the " & file_Sites_Longitude & " column.")
                End If

                'LatLongDatum column
                If (m_ViewTable.Columns.IndexOf(file_Sites_LatLongDatumID) >= 0) Then
                    If (fileRow.Item(file_Sites_LatLongDatumID).ToString <> "") Then
                        Dim SRRows() As DataRow = SpatialReferences.Select(db_fld_SpatialReferenceID & " = '" & Val(fileRow.Item(file_Sites_LatLongDatumID)) & "'")
                        If (SRRows.Length > 0) Then
                            tempRow.Item(db_fld_LatLongDatumID) = Val(fileRow.Item(file_Sites_LatLongDatumID))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Sites_LatLongDatumID & " in the SpatialReferences table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sites_LatLongDatumID & " cannot be NULL.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_Sites_LatLongDatumSRSID) >= 0) Then
                    If (fileRow.Item(file_Sites_LatLongDatumSRSID).ToString <> "") Then
                        Dim SRRows() As DataRow = SpatialReferences.Select(db_fld_SRSID & " = '" & Val(fileRow.Item(file_Sites_LatLongDatumSRSID)) & "'")
                        If (SRRows.Length > 0) Then
                            tempRow.Item(db_fld_LatLongDatumID) = Val(SRRows(SRRows.Length - 1).Item(db_fld_SpatialReferenceID))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Sites_LatLongDatumSRSID & " in the SpatialReferences table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sites_LatLongDatumSRSID & " cannot be NULL.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_Sites_LatLongDatumSRSName) >= 0) Then
                    If (fileRow.Item(file_Sites_LatLongDatumSRSName).ToString <> "") Then
                        Dim SRRows() As DataRow = SpatialReferences.Select(db_fld_SRSName & " = '" & Replace(fileRow.Item(file_Sites_LatLongDatumSRSName), "'", "''") & "'")
                        If (SRRows.Length > 0) Then
                            tempRow.Item(db_fld_LatLongDatumID) = Val(SRRows(SRRows.Length - 1).Item(db_fld_SpatialReferenceID))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Sites_LatLongDatumSRSName & " in the SpatialReferences table.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sites_LatLongDatumSRSName & " cannot be NULL.")
                    End If
                Else
                    Throw New Exception("Cannot find information to fill the LatLongDatumID column.  You must specify one the following:  LatLongDatumID, LatLongDatumSRSID, or LatLongDatumSRSName.")
                End If

                'Optional columns
                '----------------
                'Elevation_m
                If (m_ViewTable.Columns.IndexOf(file_Sites_Elevation_m) >= 0) AndAlso (fileRow.Item(file_Sites_Elevation_m).ToString <> "") Then
                    If IsNumeric(fileRow.Item(file_Sites_Elevation_m)) Then
                        tempRow.Item(db_fld_Elevation_m) = Val(fileRow.Item(file_Sites_Elevation_m))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & db_fld_Elevation_m & " must be numeric.")
                    End If
                End If

                'VerticalDatum column
                If (m_ViewTable.Columns.IndexOf(file_Sites_VerticalDatum) >= 0) AndAlso (fileRow.Item(file_Sites_VerticalDatum).ToString <> "") Then
                    If (VerticalDatum.Select(db_fld_CV_Term & " = '" & Replace(fileRow.Item(file_Sites_VerticalDatum), "'", "''") & "'").Length > 0) Then
                        tempRow.Item(db_fld_VerticalDatum) = fileRow.Item(file_Sites_VerticalDatum)
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Unable to find the specified " & file_Sites_VerticalDatum & " in the VarticalDatumCV table.")
                    End If
                End If

                'LocalX and LocalY
                If ((m_ViewTable.Columns.IndexOf(file_Sites_LocalX) >= 0) AndAlso (fileRow.Item(file_Sites_LocalX).ToString <> "")) Or ((m_ViewTable.Columns.IndexOf(file_Sites_LocalY) >= 0) AndAlso (fileRow.Item(file_Sites_LocalY).ToString <> "")) Then
                    If (m_ViewTable.Columns.IndexOf(file_Sites_LocalProjectionID) >= 0) Then
                        If (fileRow.Item(file_Sites_LocalProjectionID).ToString = "") Then
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Missing LocalProjection value.")
                        End If
                    ElseIf (m_ViewTable.Columns.IndexOf(file_Sites_LocalProjectionSRSID) >= 0) Then
                        If (fileRow.Item(file_Sites_LocalProjectionSRSID).ToString = "") Then
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Missing LocalProjection value.")
                        End If
                    ElseIf (m_ViewTable.Columns.IndexOf(file_Sites_LocalProjectionSRSName) >= 0) Then
                        If (fileRow.Item(file_Sites_LocalProjectionSRSName).ToString = "") Then
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Missing LocalProjection value.")
                        End If
                    Else
                        Throw New Exception("Unable to find LocalProjection Column")
                    End If
                    If (m_ViewTable.Columns.IndexOf(file_Sites_LocalX) < 0) Then
                        Throw New Exception("Unable to find LocalX column")
                    ElseIf (fileRow.Item(file_Sites_LocalX).ToString = "") Then
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Missing LocalX value.")
                    End If
                    If (m_ViewTable.Columns.IndexOf(file_Sites_LocalY) < 0) Then
                        Throw New Exception("Unable to find LocalY column")
                    ElseIf (fileRow.Item(file_Sites_LocalY).ToString = "") Then
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & "Missing LocalY value.")
                    End If

                    If IsNumeric(fileRow.Item(file_Sites_LocalX)) Then
                        If IsNumeric(fileRow.Item(file_Sites_LocalY)) Then
                            tempRow.Item(db_fld_LocalY) = Val(fileRow.Item(file_Sites_LocalX))
                            tempRow.Item(db_fld_LocalX) = Val(fileRow.Item(file_Sites_LocalY))
                        Else
                            Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & db_fld_LocalY & " must be numeric.")
                        End If
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & db_fld_LocalX & " must be numeric.")
                    End If
                End If

                'LocalProjection column
                If (m_ViewTable.Columns.IndexOf(file_Sites_LocalProjectionID) >= 0) AndAlso (fileRow.Item(file_Sites_LocalProjectionID).ToString <> "") Then
                    Dim SRRows() As DataRow = SpatialReferences.Select(db_fld_SpatialReferenceID & " = '" & Val(fileRow.Item(file_Sites_LocalProjectionID)) & "'")
                    If (SRRows.Length > 0) Then
                        tempRow.Item(db_fld_LocalProjectionID) = Val(fileRow.Item(file_Sites_LocalProjectionID))
                    Else
                        Throw New Exception("Unable to find the specified " & file_Sites_LocalProjectionID & " in the SpatialReferences table.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_Sites_LocalProjectionSRSID) >= 0) AndAlso (fileRow.Item(file_Sites_LocalProjectionSRSID).ToString <> "") Then
                    Dim SRRows() As DataRow = SpatialReferences.Select(db_fld_SRSID & " = '" & Replace(fileRow.Item(file_Sites_LocalProjectionSRSID), "'", "''") & "'")
                    If (SRRows.Length > 0) Then
                        tempRow.Item(db_fld_LocalProjectionID) = Val(SRRows(SRRows.Length - 1).Item(db_fld_SpatialReferenceID))
                    Else
                        Throw New Exception("Unable to find the specified " & file_Sites_LocalProjectionSRSID & " in the SpatialReferences table.")
                    End If
                ElseIf (m_ViewTable.Columns.IndexOf(file_Sites_LocalProjectionSRSName) >= 0) AndAlso (fileRow.Item(file_Sites_LocalProjectionSRSName).ToString <> "") Then
                    Dim SRRows() As DataRow = SpatialReferences.Select(db_fld_SRSName & " = '" & Replace(fileRow.Item(file_Sites_LocalProjectionSRSName), "'", "''") & "'")
                    If (SRRows.Length > 0) Then
                        tempRow.Item(db_fld_LocalProjectionID) = Val(SRRows(SRRows.Length - 1).Item(db_fld_SpatialReferenceID))
                    Else
                        Throw New Exception("Unable to find the specified " & file_Sites_LocalProjectionSRSName & " in the SpatialReferences table.")
                    End If
                End If

                'PosAccuarcy_m
                If (m_ViewTable.Columns.IndexOf(file_Sites_PosAccuracy_m) >= 0) AndAlso (fileRow.Item(file_Sites_PosAccuracy_m).ToString <> "") Then
                    If IsNumeric(fileRow.Item(file_Sites_PosAccuracy_m)) Then
                        tempRow.Item(db_fld_PosAccuracy_m) = Val(fileRow.Item(file_Sites_PosAccuracy_m))
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & db_fld_PosAccuracy_m & " must be numeric.")
                    End If
                End If

                'State
                If (m_ViewTable.Columns.IndexOf(file_Sites_SiteState) >= 0) AndAlso ((fileRow.Item(file_Sites_SiteState).ToString <> "")) Then
                    Dim temp As String
                    temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sites_SiteState), "[\t\r\v\f\n]", "")

                    If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                        tempRow.Item(db_fld_State) = temp
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sites_SiteState & " contains invalid characters.")
                    End If
                End If

                'County
                If (m_ViewTable.Columns.IndexOf(file_Sites_County) >= 0) AndAlso ((fileRow.Item(file_Sites_County).ToString <> "")) Then
                    Dim temp As String
                    temp = System.Text.RegularExpressions.Regex.Replace(fileRow.Item(file_Sites_County), "[\t\r\v\f\n]", "")

                    If System.Text.RegularExpressions.Regex.Matches(temp, "[\t\r\v\f\n]").Count() = 0 Then
                        tempRow.Item(db_fld_County) = temp
                    Else
                        Throw New Exception("ROW # " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & ": " & file_Sites_County & " contains invalid characters.")
                    End If
                End If

                'Comments
                If (m_ViewTable.Columns.IndexOf(file_Sites_Comments) >= 0) AndAlso ((fileRow.Item(file_Sites_Comments).ToString <> "")) Then
                    tempRow.Item(db_fld_Comments) = fileRow.Item(file_Sites_Comments)
                End If

                ''TODO: PUT THIS BACK??
                'If RowExists(tempRow, valid) Then
                '    If (m_ThrowFileOnRepeat) Then
                '        Throw New Exception("Row " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & " already exists in the database.")
                '    End If
                'Else
                '    valid.Rows.Add(tempRow)
                'End If
                Try
                    valid.Rows.Add(tempRow)
                Catch ex As Exception
                    If (m_ThrowFileOnRepeat) Then
                        Throw New Exception("Row " & (m_ViewTable.Rows.IndexOf(fileRow) + 1) & " already exists in the database.")
                    End If
                End Try
            Next i

            GC.Collect()
            Return valid
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            'Log: ERROR
            'LogError(ex)
            If Not (valid Is Nothing) Then
                valid.Clear()
            End If
            If Not (SpatialReferences Is Nothing) Then
                SpatialReferences.Clear()
            End If
            If Not (VerticalDatum Is Nothing) Then
                VerticalDatum.Clear()
            End If
            Throw New ExitError(ex.Message)
        End Try
        Return New DataTable("ERROR")
    End Function

    Public Overrides Function CommitTable() As Integer
        'Dim scope As New Transactions.TransactionScope
        Dim count As Integer = 0

        'Using scope
        Dim connect As New System.Data.SqlClient.SqlConnection(m_Connection.ConnectionString)
        connect.Open()
        Dim trans As SqlClient.SqlTransaction = connect.BeginTransaction(Data.IsolationLevel.ReadCommitted, "this is a test")
        Try
            count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Sites)

            GC.Collect()
            If (count > 0) Then
                trans.Commit()
            Else
                Throw New Exception("An Error Occurred. Rolling back database transaction.")
            End If
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            'LogError(ex)

            trans.Rollback()
            Throw New ExitError(ex.Message)
        End Try
        connect.Close()
        Return count
    End Function

    Public Overrides Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As Integer
        Dim count As Integer = 0

        count = m_Connection.UpdateTable(connect, trans, ValidateTable(connect, trans), "SELECT * FROM " & db_tbl_Sites)
        GC.Collect()

        Return count
    End Function

End Class
