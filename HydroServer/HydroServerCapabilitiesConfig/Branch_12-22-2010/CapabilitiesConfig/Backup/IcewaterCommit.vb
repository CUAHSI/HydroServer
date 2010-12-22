
Public Class IcewaterCommit
    Public Enum TableType
        Contacts
        MapServers
        MapServices
        ODMDatabases
        Regions
    End Enum
    Private m_Connection As SqlClient.SqlConnection
    Private m_TableType As TableType

    Public Sub New(ByVal TableName As TableType, ByVal connection As SqlClient.SqlConnection)
        m_Connection = connection
        m_TableType = TableName
    End Sub

    Public Function GetRowToEdit(ByVal ID As Integer) As Specialized.NameValueCollection
        Dim SelectQuery As String
        Select Case m_TableType
            Case Else
                SelectQuery = "SELECT * FROM " & TableName() & " WHERE " & TableID & " = '" & ID & "'"
        End Select

        Dim adapt As New SqlClient.SqlDataAdapter(SelectQuery, m_Connection)
        Dim table As New DataTable(TableName)
        adapt.Fill(table)

        If (table.Rows.Count > 0) Then
            Dim toReturn As New Specialized.NameValueCollection
            For Each column As DataColumn In table.Columns
                toReturn.Add(column.ColumnName, table.Rows(0).Item(column).ToString)
            Next column
            Return toReturn
        Else
            Return New Specialized.NameValueCollection
        End If
    End Function
    Public Function CommitRow(ByVal params As Specialized.NameValueCollection) As Integer
        Try
            Dim InsertNames As String = "INSERT INTO " & TableName & " (" & params.GetKey(0)
            Dim InsertValues As String = " VALUES (@" & params.GetKey(0)
            Dim SelectSQL As String = " SELECT SCOPE_IDENTITY() as NewRec"
            Dim sqlParams(params.Count - 1) As SqlClient.SqlParameter

            sqlParams(0) = New SqlClient.SqlParameter("@" & params.GetKey(0), params(0))
            For i As Integer = 1 To (params.Count - 1)
                InsertNames &= ", " & params.GetKey(i)
                InsertValues &= ", @" & params.GetKey(i)
                sqlParams(i) = New SqlClient.SqlParameter("@" & params.GetKey(i), params(i))
            Next i
            InsertNames &= ")"
            InsertValues &= ")"

            m_Connection.Open()
            Dim InsertCMD As New SqlClient.SqlCommand(InsertNames & InsertValues & SelectSQL, m_Connection)
            InsertCMD.Parameters.AddRange(sqlParams)
            Dim ID As String = InsertCMD.ExecuteScalar
            m_Connection.Close()

            If (ID = "null") Or (ID = "NULL") Or (ID = "") Or (ID = Nothing) Then
#If DEBUG Then
    msgbox("CommitRow" & vbcrlf & "Incorrect number of rows",,"CommitRow")
#End If
                Return 0
            End If
            Return Val(ID)
        Catch ex As Exception
            If Not (m_Connection Is Nothing) Then
                If Not (m_Connection.State = ConnectionState.Closed) Then
                    m_Connection.Close()
                End If
            End If
#If DEBUG Then
    msgbox("UpdateRow" & vbcrlf & ex.message,,"CommitRow")
#End If
            Return -1
        End Try
        Return -1
    End Function
    Public Function UpdateRow(ByVal recordID As Integer, ByVal params As Specialized.NameValueCollection) As Integer
        Try
            Dim UpdateSQL As String = "UPDATE " & TableName & " SET " & params.GetKey(0) & " = @" & params.GetKey(0)
            Dim WhereSQL As String = " WHERE (" & TableID & " = '" & recordID & "')"
            Dim sqlParams(params.Count - 1) As SqlClient.SqlParameter

            sqlParams(0) = New SqlClient.SqlParameter("@" & params.GetKey(0), params(0))
            For i As Integer = 1 To (params.Count - 1)
                UpdateSQL &= ", " & params.GetKey(i) & " = @" & params.GetKey(i)
                sqlParams(i) = New SqlClient.SqlParameter("@" & params.GetKey(i), params(i))
            Next i

            m_Connection.Open()
            Dim UpdateCMD As New SqlClient.SqlCommand(UpdateSQL & WhereSQL, m_Connection)
            UpdateCMD.Parameters.AddRange(sqlParams)
            Dim rows As String = UpdateCMD.ExecuteNonQuery
            m_Connection.Close()

            If rows = 1 Then
                Return recordID
            Else
#If DEBUG Then
    msgbox("UpdateRow" & vbcrlf & "Incorrect number of rows",,"UpdateRow")
#End If
                Return -1
            End If
        Catch ex As Exception
            If Not (m_Connection Is Nothing) Then
                If Not (m_Connection.State = ConnectionState.Closed) Then
                    m_Connection.Close()
                End If
            End If
#If DEBUG Then
    msgbox("UpdateRow" & vbcrlf & ex.message,,"UpdateRow")
#End If
            Return -1
        End Try
        Return -1
    End Function

    Public Function GetMapServicesInRegion(ByVal regionID As Integer) As DataTable
        Try
            Dim adapt As New SqlClient.SqlDataAdapter("SELECT * FROM RegionMapServices WHERE RegionID = '" & regionID & "' ORDER BY DisplayOrder ASC", m_Connection)
            Dim table As New DataTable
            adapt.Fill(table)
            Return table
        Catch ex As Exception
            Throw New Exception("There was an error retrieving the RegionMapServices for RegionID = " & regionID & ".", ex)
        End Try
    End Function
    Public Function AddMapServicesToRegion(ByVal regionID As Integer, ByVal mapServiceIDs As List(Of Integer), ByVal displayNames As List(Of String), ByVal TransparencyList As List(Of Integer), ByVal isVisibleList As List(Of Boolean), ByVal isTOCList As List(Of Boolean), ByVal isBaseMapService As List(Of Boolean)) As Boolean
        Try
            Dim count As Integer = 0
            If (mapServiceIDs.Count <> displayNames.Count) Or (mapServiceIDs.Count <> TransparencyList.Count) Or (mapServiceIDs.Count <> isVisibleList.Count) Or (mapServiceIDs.Count <> isTOCList.Count) Or (mapServiceIDs.Count <> isBaseMapService.Count) Then
                Return -1
            End If

            If m_Connection.State <> ConnectionState.Open Then
                m_Connection.Open()
            End If

            Dim DeleteCMD As New SqlClient.SqlCommand("DELETE FROM RegionMapServices WHERE RegionID = '" & regionID & "'", m_Connection)
            DeleteCMD.ExecuteNonQuery()

            Dim InsertCMD As New SqlClient.SqlCommand("INSERT INTO RegionMapServices(RegionID, MapServiceID, DisplayOrder, DisplayName, TransparencyPercent, IsVisible, IsTOC, IsBaseMapService) VALUES ('" & regionID & "', @MapServiceID, @DisplayOrder, @DisplayName, @TransparencyPercent, @IsVisible, @IsTOC, @IsBaseMapService)", m_Connection)
            Dim MapServiceID As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@MapServiceID", SqlDbType.Int))
            Dim DisplayName As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@DisplayName", SqlDbType.Text))
            Dim DisplayOrder As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@DisplayOrder", SqlDbType.Int))
            Dim Transparency As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@TransparencyPercent", SqlDbType.Int))
            Dim Visible As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@IsVisible", SqlDbType.Bit))
            Dim TOC As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@IsTOC", SqlDbType.Bit))
            Dim BaseMapService As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@IsBaseMapService", SqlDbType.Bit))
            For i As Integer = 0 To (mapServiceIDs.Count - 1)
                MapServiceID.Value = mapServiceIDs(i)
                DisplayName.Value = displayNames(i)
                DisplayOrder.Value = i + 1
                Transparency.Value = TransparencyList(i)
                Visible.Value = isVisibleList(i)
                TOC.Value = isTOCList(i)
                BaseMapService.Value = isBaseMapService(i)
                If InsertCMD.ExecuteNonQuery > 0 Then
                    count += 1
                End If
            Next i
            m_Connection.Close()
            Return count
        Catch ex As Exception
            If Not (m_Connection Is Nothing) Then
                If Not (m_Connection.State = ConnectionState.Closed) Then
                    m_Connection.Close()
                End If
            End If
            Return -1
        End Try
    End Function
    Public Function GetDatabasesInRegion(ByVal regionID As Integer) As DataTable
        Try
            Dim adapt As New SqlClient.SqlDataAdapter("SELECT * FROM RegionDatabases WHERE RegionID = '" & regionID & "' ORDER BY DisplayOrder ASC", m_Connection)
            Dim table As New DataTable
            adapt.Fill(table)
            Return table
        Catch ex As Exception
            Throw New Exception("There was an error retrieving the RegionDatabases for RegionID = " & regionID & ".", ex)
        End Try
    End Function
    Public Function AddDatabasesToRegion(ByVal regionID As Integer, ByVal databaseIDs As List(Of Integer), ByVal displayNames As List(Of String)) As Integer
        Try
            Dim count As Integer = 0
            If (databaseIDs.Count <> displayNames.Count) Then
                Return -1
            End If

            If m_Connection.State <> ConnectionState.Open Then
                m_Connection.Open()
            End If

            Dim DeleteCMD As New SqlClient.SqlCommand("DELETE FROM RegionDatabases WHERE RegionID = '" & regionID & "'", m_Connection)
            DeleteCMD.ExecuteNonQuery()

            Dim InsertCMD As New SqlClient.SqlCommand("INSERT INTO RegionDatabases(RegionID, DatabaseID, DisplayOrder, DisplayName) VALUES ('" & regionID & "', @DatabaseID, @DisplayOrder, @DisplayName)", m_Connection)
            Dim MapServiceID As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@DatabaseID", SqlDbType.Int))
            Dim DisplayOrder As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@DisplayOrder", SqlDbType.Int))
            Dim DisplayName As SqlClient.SqlParameter = InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@DisplayName", SqlDbType.Text))
            For i As Integer = 0 To (databaseIDs.Count - 1)
                MapServiceID.Value = databaseIDs(i)
                DisplayOrder.Value = i + 1
                DisplayName.Value = displayNames(i)
                If InsertCMD.ExecuteNonQuery > 0 Then
                    count += 1
                End If
            Next i
            m_Connection.Close()
            Return count
        Catch ex As Exception
            If Not (m_Connection Is Nothing) Then
                If Not (m_Connection.State = ConnectionState.Closed) Then
                    m_Connection.Close()
                End If
            End If
            Return -1
        End Try
    End Function

    Public Function GetMetadata(ByVal ID As Integer) As DataTable
        Try
            Dim adapt As New SqlClient.SqlDataAdapter("SELECT MetadataTitle as Title, MetadataContent as Content FROM " & MetaTablename & " WHERE " & MetaIDName & " = '" & ID & "' ORDER BY DisplayOrder ASC", m_Connection)
            Dim table As New DataTable
            adapt.Fill(table)
            Return table
        Catch ex As Exception
            Throw New Exception("There was an error retrieving the metadata.", ex)
        End Try
    End Function
    Public Function CommitMetadata(ByVal ID As Integer, ByVal Titles As Specialized.StringCollection, ByVal Contents As Specialized.StringCollection) As Boolean
        Dim count As Integer = 0
        Try
            If Titles.Count <> Contents.Count Then
                Return False
            End If
            Dim DeleteCMD As New SqlClient.SqlCommand("DELETE FROM " & MetaTablename() & " WHERE " & MetaIDName() & " = '" & ID & "'", m_Connection)
            If m_Connection.State <> ConnectionState.Open Then
                m_Connection.Open()
            End If
            DeleteCMD.ExecuteNonQuery()
            For i As Integer = 0 To (Titles.Count - 1)
                Dim InsertCMD As New SqlClient.SqlCommand("INSERT INTO " & MetaTablename() & " VALUES ('" & ID & "', @Titles, @Contents, '" & i + 1 & "')", m_Connection)
                InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@Titles", Titles(i)))
                InsertCMD.Parameters.Add(New SqlClient.SqlParameter("@Contents", Contents(i)))
                If InsertCMD.ExecuteNonQuery > 0 Then
                    count += 1
                End If
            Next i
            m_Connection.Close()
            Return (Titles.Count = count)

        Catch ex As Exception
            If Not (m_Connection Is Nothing) Then
                If Not (m_Connection.State = ConnectionState.Closed) Then
                    m_Connection.Close()
                End If
            End If
            Return False
        End Try
    End Function

    Private ReadOnly Property TableName() As String
        Get
            Select Case m_TableType
                Case TableType.Contacts
                    Return "Contacts"
                Case TableType.MapServers
                    Return "MapServers"
                Case TableType.MapServices
                    Return "MapServices"
                Case TableType.ODMDatabases
                    Return "ODMDatabases"
                Case TableType.Regions
                    Return "Regions"
                Case Else
                    Return ""
            End Select
        End Get
    End Property
    Private ReadOnly Property TableID() As String
        Get
            Select Case m_TableType
                Case TableType.Contacts
                    Return "ContactID"
                Case TableType.MapServers
                    Return "MapServerID"
                Case TableType.MapServices
                    Return "MapServiceID"
                Case TableType.ODMDatabases
                    Return "DatabaseID"
                Case TableType.Regions
                    Return "RegionID"
                Case Else
                    Return ""
            End Select
        End Get
    End Property
    Private ReadOnly Property MetaTablename() As String
        Get
            Select Case m_TableType
                Case TableType.MapServices
                    Return "MapServiceMetadata"
                Case TableType.MapServers
                    Return "MapServerMetadata"
                Case TableType.ODMDatabases
                    Return "ODMDatabaseMetadata"
                Case TableType.Regions
                    Return "RegionMetadata"
                Case Else
                    Return ""
            End Select
        End Get
    End Property
    Private ReadOnly Property MetaIDName() As String
        Get
            Select Case m_TableType
                Case TableType.MapServices
                    Return "MapServiceID"
                Case TableType.MapServers
                    Return "MapServerID"
                Case TableType.ODMDatabases
                    Return "DatabaseID"
                Case TableType.Regions
                    Return "RegionID"
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    'Private Function formatForQuery(ByVal input As String) As String
    '    Return input.Replace("'", "''")
    'End Function
End Class
