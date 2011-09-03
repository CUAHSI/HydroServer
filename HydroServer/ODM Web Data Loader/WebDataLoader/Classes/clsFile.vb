Imports System.Data

Class clsFile
    Public Event FileLoadFinished()
    Public Event FileLoadStarted()

    Public MyType As String = "an Unrecognized File"
    Public Const file_DV_DV As String = "datavalue"
    Public FileLoadPercent As Double
    Public Canceled As Boolean = False
    'public Const file_Site_Name As String = "sitename"
    'public Const file_Var_Name As String = "variablename"
    Protected m_ViewTable As New DataTable
    Protected m_Connection As clsConnection
    Protected m_ThrowFileOnRepeat As Boolean = True
    Protected m_ThrowFileOnNulls As Boolean = True
    Protected m_FilePath As String
    Private WithEvents bg As New System.Threading.Thread(AddressOf LoadFile)
    Private Const MaxRows As Integer = 1000
    Private Const SmallMaxRows As Integer = 20

    Public Property FilePath() As String
        Get
            Return m_FilePath
        End Get
        Set(ByVal value As String)
            m_FilePath = FilePath
            LoadFile()
            'bg.Start()
        End Set
    End Property
    Public ReadOnly Property ViewTable() As DataTable
        Get
            Dim clone As DataTable = m_ViewTable.Clone
            Dim total As Integer = m_ViewTable.Rows.Count
            If (total > MaxRows) Then
                total = MaxRows
            End If
            For i As Integer = 0 To (total - 1)
                clone.Rows.Add(m_ViewTable.Rows(i).ItemArray)
            Next
            Return clone
        End Get
    End Property
    Public ReadOnly Property SmallViewTable() As DataTable
        Get
            Dim clone As DataTable = m_ViewTable.Clone
            Dim total As Integer = m_ViewTable.Rows.Count
            If (total > SmallMaxRows) Then
                total = SmallMaxRows
            End If
            For i As Integer = 0 To (total - 1)
                clone.Rows.Add(m_ViewTable.Rows(i).ItemArray)
            Next
            Return clone
        End Get
    End Property
    Public WriteOnly Property Connection() As clsConnection
        Set(ByVal value As clsConnection)
            m_Connection = value
        End Set
    End Property

    Public Sub New(ByVal e_Connection As clsConnection)
        FileLoadPercent = 0
        m_Connection = e_Connection
        m_ViewTable = New DataTable("EMPTY")
    End Sub
    Public Sub New(ByVal e_Connection As clsConnection, ByVal filePath As String)
        m_FilePath = filePath
        Dim LastSlash As Integer
        Dim lastPeriod As Integer
        Dim shortName As String = "file"
        If (m_FilePath.Contains("\") AndAlso m_FilePath.Contains(".")) Then
            LastSlash = m_FilePath.LastIndexOf("\") + 1
            lastPeriod = m_FilePath.LastIndexOf(".")
            If (lastPeriod > LastSlash) Then
                shortName = m_FilePath.Substring(LastSlash, lastPeriod - LastSlash)
            End If
        End If


        FileLoadPercent = 0
        m_Connection = e_Connection
        If Not (m_ViewTable Is Nothing) Then
            m_ViewTable.Clear()
        End If
        m_ViewTable = New DataTable(shortName)

        LoadFile()
        'bg.Start()
    End Sub
    Public Sub New(ByVal filePath As String)
        m_FilePath = filePath
        Dim LastSlash As Integer
        Dim lastPeriod As Integer
        Dim shortName As String = "file"
        If (m_FilePath.Contains("\") AndAlso m_FilePath.Contains(".")) Then
            LastSlash = m_FilePath.LastIndexOf("\") + 1
            lastPeriod = m_FilePath.LastIndexOf(".")
            If (lastPeriod > LastSlash) Then
                shortName = m_FilePath.Substring(LastSlash, lastPeriod - LastSlash)
            End If
        End If
        FileLoadPercent = 0
        m_Connection = New clsConnection
        'If (filePath.Contains(".xls")) Then
        '    EXL = New Excel.Application
        '    m_ViewTable = LoadExcel(filePath)
        'Else
        m_ViewTable = New DataTable(shortName)
        LoadFile()
        'bg.Start()
        'm_ViewTable = LoadFile(filePath)
        'End If
    End Sub
    Public Sub New(ByVal file As clsFile)
        FileLoadPercent = 0
        m_ViewTable = file.m_ViewTable
        m_Connection = file.m_Connection
    End Sub
    Public Sub New(ByVal table As DataTable, ByVal connection As clsConnection)
        FileLoadPercent = 0
        m_ViewTable = table
        m_Connection = connection
    End Sub
    Public Sub New(ByVal e_Connection As clsConnection, ByVal table As DataTable)
        FileLoadPercent = 0
        m_ViewTable = table
        m_Connection = e_Connection
    End Sub

    Public Function GetTableType() As clsFile
        'This is where you set the correct filetype.  
        If (m_ViewTable.Columns.IndexOf(clsSites.file_Sites_SiteName) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) Then
            'Loading Sites table
            Return New clsSites(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsVariables.file_Variables_VariableName) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) Then
            'Loading Variables table
            Return New clsVariables(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsMethods.file_Methods_MethodDescription) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) Then
            'Loading Methods table
            Return New clsMethods(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsLabMethods.db_fld_LabName) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) And (m_ViewTable.Columns.IndexOf(clsSamples.db_fld_SampleType) < 0) Then
            'Loading LabMethods table
            Return New clsLabMethods(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsSources.db_fld_Organization) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) Then
            'Loading Sources table
            Return New clsSources(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsSamples.db_fld_SampleType) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) Then
            'Loading Samples table
            Return New clsSamples(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsQualifiers.db_fld_QualifierDescription) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) Then
            'Loading Qualifiers table
            Return New clsQualifiers(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsISOMetadata.db_fld_TopicCategory) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) And (m_ViewTable.Columns.IndexOf(clsSources.db_fld_Organization) < 0) Then
            'Loading ISOMetadata table
            Return New clsISOMetadata(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsQualityControlLevels.db_fld_QualityControlLevelCode) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) Then
            'Loading QualityControlLevels table
            Return New clsQualityControlLevels(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsGroupDescriptions.db_fld_GroupDescription) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) Then
            'Loading GroupDescriptions table
            Return New clsGroupDescriptions(Me)
        ElseIf (m_ViewTable.Columns.Count = 2) And (m_ViewTable.Columns.IndexOf(clsDerivedFrom.db_fld_DerivedFromID) >= 0) And (m_ViewTable.Columns.IndexOf(clsDerivedFrom.db_fld_ValueID) >= 0) Then
            'Loading DerivedFrom table
            Return New clsDerivedFrom(Me)
        ElseIf (m_ViewTable.Columns.Count = 2) And (m_ViewTable.Columns.IndexOf(clsGroups.db_fld_GroupID) >= 0) And (m_ViewTable.Columns.IndexOf(clsGroups.db_fld_ValueID) >= 0) Then
            'Loading Groups table
            Return New clsGroups(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsCategories.db_fld_CategoryDescription) >= 0) Then
            'Loading Categories table
            Return New clsCategories(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsOffsetTypes.db_fld_OffsetDescription) >= 0) And (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) < 0) Then
            'Loading OffsetTypes table
            Return New clsOffsetTypes(Me)
        ElseIf (m_ViewTable.Columns.IndexOf(clsDataValues.db_fld_DataValue) >= 0) Then
            'Loading DataValues table
            Return New clsDataValues(Me)
        End If
        Return Me
    End Function

    'Public Overridable Function CommitTable() As Integer
    Public Overridable Function CommitTable() As clsTableCount
        Return Nothing
        'Return m_Connection.UpdateTable(ValidateTable(m_ViewTable), "SELECT * FROM" & db_tblTableName)
    End Function
    'Public Overridable Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As Integer
    Public Overridable Function CommitTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As SqlClient.SqlTransaction) As clsTableCount

        Return Nothing
        'Return m_Connection.UpdateTable(ValidateTable(m_ViewTable), "SELECT * FROM" & db_tblTableName)
    End Function

    Protected Overridable Function ValidateTable(ByVal connect As SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As Data.DataTable
        Return m_ViewTable
    End Function

    Protected Sub LoadFile() '(ByVal path As String) 'as new datatable
        'Loads a fullPath into a datatable.  Can be comma or tab delimited. 

        Dim reader As System.IO.StreamReader
        RaiseEvent FileLoadStarted()
        Dim fullPath As String
        Dim x As Integer
        Dim total As Long
        Dim count As Integer
        Dim LastSlash As Integer
        Dim lastPeriod As Integer
        Dim shortName As String = "file"
        If (m_FilePath.Contains("\") AndAlso m_FilePath.Contains(".")) Then
            LastSlash = m_FilePath.LastIndexOf("\") + 1
            lastPeriod = m_FilePath.LastIndexOf(".")
            If (lastPeriod > LastSlash) Then
                shortName = m_FilePath.Substring(LastSlash, lastPeriod - LastSlash)
            End If
        End If
        Dim table As New DataTable(shortName)
        'Dim table As New DataTable(m_FilePath.Substring((m_FilePath.LastIndexOf("\") + 1), m_FilePath.Length - (m_FilePath.LastIndexOf("\") + 1)))
        Try
            If (m_FilePath.StartsWith("http:\\") Or m_FilePath.StartsWith("ftp:\\")) Then
                Dim myWebClient As New Net.WebClient()
                Dim tempPath As String
                tempPath = System.IO.Path.GetTempPath & "ODMWDL"
                '''LogUpdate(vbTab & vbTab & "Getting Data from Website..." & vbCrLf & "From: " & m_FilePath & vbCrLf & "To: " & tempPath & "\DataImport.txt")
                Try
                    If Not (System.IO.Directory.Exists(tempPath)) Then
                        System.IO.Directory.CreateDirectory(tempPath)
                    End If
                    myWebClient.DownloadFile(m_FilePath, tempPath & "\DataImport.txt")
                    If System.IO.File.Exists(tempPath & "\DataImport.txt") Then
                        fullPath = tempPath & "\DataImport.txt"
                    Else
                        ''LogError("Error downloading Table." & vbCrLf & tempPath)
                        m_ViewTable = New DataTable("ERROR")
                    End If
                Catch ExEr As ExitError
                    Throw ExEr
                Catch ex As Exception
                    ''LogError("Error Downloading Data From Website", ex)
                    m_ViewTable = New DataTable("ERROR")
                End Try
                '''LogUpdate(vbTab & vbTab & "...Finished Getting Data")
            Else
                'If System.IO.File.Exists(m_FilePath) Then
                fullPath = m_FilePath
                'Else
                '    ''LogError("Invalid Filepath")
                '    m_ViewTable = New DataTable("ERROR")
                'End If
            End If

            Dim FileSize As New System.IO.FileInfo(fullPath)

            If (FileSize.Length > ((0.9 * My.Computer.Info.AvailablePhysicalMemory) + (0.9 * My.Computer.Info.AvailableVirtualMemory))) Then
                ''LogError("File Size: " & FileSize.Length & " bytes" & vbCrLf & "Available System Memory: " & CInt((0.9 * My.Computer.Info.AvailablePhysicalMemory) + (0.9 * My.Computer.Info.AvailableVirtualMemory)) & " bytes ")
                m_ViewTable = New DataTable("ERROR")
            End If

            ''''LogUpdate(vbTab & vbTab & "Opening " & fullPath & " ...")
            Try
                If fullPath.EndsWith("xls") Or fullPath.EndsWith("xlsx") Or fullPath.EndsWith("xlsb") Then
                    LoadExcel()
                    'm_ViewTable = LoadExcel(path)
                Else

                    Dim counter As New System.IO.FileStream(m_FilePath, IO.FileMode.Open)
                    total = counter.Length
                    reader = New System.IO.StreamReader(counter)
                    'reader = New System.IO.StreamReader(fullPath)
                    Dim delimiter As String
                    Dim FileRow As String = reader.ReadLine
                    If FileRow <> "" Then
                        If ((ProcessLine(FileRow, vbTab).Length) > (ProcessLine(FileRow, ",").Length)) Then
                            delimiter = vbTab
                        Else
                            delimiter = ","
                        End If
                    Else
                        LoadExcel()
                        Exit Try
                    End If
                    Dim columns() As String
                    If (FileRow <> "") Then
                        columns = ProcessLine(FileRow, delimiter)
                    End If
                    Dim column As String
                    table.BeginInit()
                    For Each column In columns
                        table.Columns.Add(column.Replace(" ", ""))
                    Next
                    table.EndInit()

                    table.BeginLoadData()
                    While (Not reader.EndOfStream)
                        If Canceled Then
                            reader.Close()
                            m_ViewTable = New DataTable("Canceled")
                            Exit Sub
                        End If
                        FileRow = reader.ReadLine
                        Dim tempRow() As String = ProcessLine(FileRow, delimiter)
                        For x = 0 To (tempRow.Length - 1)
                            If LCase(tempRow(x)) = "null" Then
                                tempRow(x) = ""
                            End If
                        Next
                        While (tempRow.Length > table.Columns.Count)
                            table.Columns.Add()
                        End While
                        table.Rows.Add(tempRow)
                        tempRow = Nothing
                        FileLoadPercent = counter.Position / total * 95
                        If count >= 1000 Then
                            count = 0
                            m_ViewTable = table.Copy
                        Else
                            count += 1
                        End If
                    End While
                    table.EndLoadData()
                    table.AcceptChanges()
                    reader.Close()
                    m_ViewTable = table
                    ''''LogUpdate(vbTab & vbTab & fullPath & " Opened.")
                End If
            Catch ExEr As ExitError
                Throw ExEr
            Catch ex As Exception
                ''LogError("Error Loading " & fullPath & " .", ex)
                m_ViewTable = New DataTable
            End Try

        Catch ex As System.IO.InvalidDataException
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            ''LogError("Error Loading File: " & m_FilePath & " .", ex)
            LoadExcel()
        Catch ex As System.Net.WebException
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            ''LogError("Unable to Connect to Web File: " & m_FilePath & " .", ex)
        Catch ExEr As ExitError
            Throw ExEr
        Catch ex As Exception
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            ''LogError("Error Loading File: " & m_FilePath & " .", ex)
            LoadExcel()
        End Try

        RaiseEvent FileLoadFinished()
        FileLoadPercent = 100
    End Sub

    ''TODO: PUT THIS BACK?
    'Protected Function RowExists(ByVal newRow As DataRow, ByVal table as new datatable, Optional ByVal excludeColumn() As String = "") As Boolean
    '    Dim x, y As Integer
    '    If (newRow.Table.Equals(table)) Then
    '        For x = 0 To (table.Rows.Count - 1)
    '            Dim fnd = True
    '            For y = 0 To (table.Columns.Count - 1)
    '                If (table.Columns(y).ColumnName <> excludeColumn) Then
    '                    If (table.Rows(x).Item(y).ToString <> newRow.Item(y).ToString) Then
    '                        fnd = False
    '                        Exit For
    '                    End If
    '                End If
    '            Next y
    '            If fnd Then
    '                Return True
    '            End If
    '        Next x
    '        Return False
    '    Else
    '        Throw New Exception("newRow does not belong to table")
    '    End If
    '    Return False
    'End Function

    Private Sub LoadExcel()
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim LastSlash As Integer
        Dim lastPeriod As Integer
        Dim shortName As String = "file"
        If (m_FilePath.Contains("\") AndAlso m_FilePath.Contains(".")) Then
            LastSlash = m_FilePath.LastIndexOf("\") + 1
            lastPeriod = m_FilePath.LastIndexOf(".")
            If (lastPeriod > LastSlash) Then
                shortName = m_FilePath.Substring(LastSlash, lastPeriod - LastSlash)
            End If
        End If
        Dim table As New DataTable(shortName)
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & m_FilePath & "'; " & "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'")
        Try
            MyConnection.Open()
        Catch ex As Exception

        End Try
        ' Select the data from the workbook.
        Try
            FileLoadPercent = 20
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & shortName & "$]", MyConnection)
            MyCommand.Fill(table)
            For Each column As Data.DataColumn In table.Columns
                If column.ColumnName.Contains(" ") Then
                    column.ColumnName = column.ColumnName.Replace(" ", "")
                End If
            Next column
        Catch err As OleDb.OleDbException
            Try
                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [sheet1$]", MyConnection)
                MyCommand.Fill(table)
                For Each column As Data.DataColumn In table.Columns
                    If column.ColumnName.Contains(" ") Then
                        column.ColumnName = column.ColumnName.Replace(" ", "")
                    End If
                Next column
            Catch ex As Exception
                'LogError("The sheet with the data must have the same name as the file (" & shortName & ") or be named sheet1.")
                Throw New ExitError("clsFile.LoadExcell()<br> " & ex.Message)
            End Try
        End Try

        MyConnection.Close()

        'TODO: See if this reads data correctly...
        'Try
        '    Dim rs As New ADODB.Recordset
        '    Dim sconn As String
        '    Dim conn As New ADODB.Connection()
        '    rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        '    rs.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        '    rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        '    sconn = "DRIVER=Microsoft Excel Driver (*.xls);DBQ='" & m_FilePath & "'"
        '    conn.ConnectionString = sconn
        '    conn.Open()
        'Catch ex As Exception
        '    Msgbox(ex.StackTrace)
        'End Try

        If (table Is Nothing) AndAlso (table.Rows.Count = 0) Then
            m_ViewTable = New DataTable("ERROR")
        Else
            m_ViewTable = table
        End If


        'Catch ex As Exception
        '    MyConnection.Close()
        '    m_ViewTable = New DataTable("ERROR")
        'End Try
    End Sub

End Class
