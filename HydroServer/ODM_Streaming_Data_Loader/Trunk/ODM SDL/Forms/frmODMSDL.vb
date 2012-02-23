'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..

Imports System.xml
Imports System.Configuration

''' <summary>
''' Performs the actual Loading of data into the database.  Is always hidden, but places an icon in the task bar.
''' </summary>
''' <remarks></remarks>
Public Class frmODMSDL
    'Last Documented 8/29/07

    ''' <summary>
    ''' Tracks whether to update specific files or everything based on the schedule.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SpecificFiles As Boolean = False


    ''' <summary>
    ''' Determines which type of update to run based on command line arguments
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmODMSDL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ids() As Integer = {}
            'Dim config As String = ConfigurationManager.openEXEConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)
            g_EXE_Dir = System.IO.Path.GetDirectoryName(Me.GetType.Assembly.Location)
            Dim tempdir As String
            tempdir = System.IO.Path.GetDirectoryName(System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath)
            Dim section As String()
            'tempdir = section(0) '& section(1) & "\" & section(2) & "\" & section(3) & "\" & section(4) & "\" & section(5)
            section = Split(tempdir, "ODMSDL", , CompareMethod.Text)
            g_Config_Dir = section(0) & "StreamingDataLoader\1.1.2.3\"
            IO.Directory.CreateDirectory(g_Config_Dir)
            'g_EXE_Dir = System.IO.Path.GetDirectoryName(System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath)
            'Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)
            'config.SaveAs(g_EXE_Dir)


            If My.Application.CommandLineArgs.Count > 1 Then
                If LCase(My.Application.CommandLineArgs(0)) = "-s" Then

                    Dim i As Integer
                    ReDim ids(My.Application.CommandLineArgs.Count - 2)
                    For i = 0 To (My.Application.CommandLineArgs.Count - 2)
                        ids(i) = My.Application.CommandLineArgs(i + 1)
                    Next
                    m_SpecificFiles = True
                End If
            End If

            If Not m_SpecificFiles Then
                Import()
            Else
                Import(ids)
            End If
        Catch ex As Exception
            ErrorLog("Error Loading Program.", ex)

            Me.Close()
        End Try
        Me.Close()
    End Sub

    Sub CreateDir(ByVal MyFolder As String)
        On Error Resume Next
        MkDir("\MyFolder")
    End Sub
    ''' <summary>
    ''' Loads data based on the pre-defined schedule.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Import()
        Try
            tbIcon.Visible = True
            Dim settings As clsConnectionSettings
            Dim dt, utcdt, utcOff, DST, monthly, yearly, fileBOI, DBBOI As Boolean
            Dim x, y, z As Integer
            Dim file As DataTable
            Dim first, last, lastUpdate As DateTime
            Dim POR As TimeSpan
            Dim tempRow As DataRow
            Dim xmlDoc As New System.Xml.XmlDocument
            Dim root, fileNode, mapNode As System.Xml.XmlNode
            Dim period As TimeSpan
            Dim offset, update As DateTime
            Dim monthyearPeriod As Integer
            Dim valueID As Integer
            Dim valueIDOffset As Integer = 0
            Dim delimiter As String = ","

            If System.IO.File.Exists(g_Config_Dir & "\Config.xml") Then
                xmlDoc.Load(g_Config_Dir & "\Config.xml")

                LogUpdate(Now.ToLongDateString & vbTab & Now.ToLongTimeString & vbCrLf & "Config File Loaded." & vbCrLf & "Running Scheduled Update...")
                root = xmlDoc.DocumentElement

                For x = 0 To (root.ChildNodes.Count - 1)
                    Try
                        fileNode = root.ChildNodes(x)
                        If (fileNode.Name = config_root_File) Then

                            offset = New DateTime()
                            Date.TryParse(fileNode.Item(config_File_SchedOffset).InnerText, offset)
                            monthyearPeriod = Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0))

                            Select Case LCase(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(1))
                                Case "seconds"
                                    period = New TimeSpan(0, 0, Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)))
                                Case "second"
                                    period = New TimeSpan(0, 0, Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)))
                                Case "minutes"
                                    period = New TimeSpan(0, Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0)
                                Case "minute"
                                    period = New TimeSpan(0, Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0)
                                Case "hours"
                                    period = New TimeSpan(Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0, 0)
                                Case "hour"
                                    period = New TimeSpan(Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0, 0)
                                Case "days"
                                    period = New TimeSpan(Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0, 0, 0)
                                Case "day"
                                    period = New TimeSpan(Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0, 0, 0)
                                Case "months"
                                    monthly = True
                                Case "month"
                                    monthly = True
                                Case "years"
                                    yearly = True
                                Case "year"
                                    yearly = True
                            End Select

                            update = offset
                            Date.TryParse(fileNode.Item(config_File_Last).InnerText, lastUpdate)
                            While (update <= lastUpdate)
                                If monthly Then
                                    update.AddMonths(monthyearPeriod)
                                ElseIf yearly Then
                                    update.AddYears(monthyearPeriod)
                                Else
                                    update += period
                                End If
                            End While
                            If (update > Now) Then
                                LogUpdate(vbTab & "File #" & fileNode.Attributes(config_File_ID).Value & " not scheduled for next update until " & update.ToString & ".")
                            Else
                                LogUpdate(vbTab & "Loading File #" & fileNode.Attributes(config_File_ID).Value & "...")

                                If (fileNode.Item(config_File_Delimiter) Is Nothing) OrElse (fileNode.Item(config_File_Delimiter).InnerText = "") Then
                                    delimiter = ","
                                Else
                                    Select Case fileNode.Item(config_File_Delimiter).InnerText
                                        Case "<Tab Delimited>"
                                            delimiter = ControlChars.Tab
                                        Case "<Comma Delimited>"
                                            delimiter = ","
                                        Case Else
                                            delimiter = fileNode.Item(config_File_Delimiter).InnerText
                                    End Select
                                End If

                                file = LoadFile((LCase(fileNode.Item(config_File_Type).InnerText) = "web"), fileNode.Item(config_File_Loc).InnerText, fileNode.Item(config_File_HeaderRow).InnerText, fileNode.Item(config_File_DataRow).InnerText, delimiter)

                                If Not (file Is Nothing) Then
                                    LogUpdate(vbTab & "Server: " & fileNode.Item(config_File_Server).InnerText & vbCrLf & vbTab & "Database: " & fileNode.Item(config_File_DB).InnerText & vbCrLf & vbTab & "User: " & fileNode.Item(config_File_User).InnerText)

                                    fileNode.Item(config_File_Last).InnerText = Now
                                    settings = New clsConnectionSettings(fileNode.Item(config_File_Server).InnerText, fileNode.Item(config_File_DB).InnerText, 10, False, fileNode.Item(config_File_User).InnerText, Decrypt(fileNode.Item(config_File_Password).InnerText))
                                    If TestDBConnection(settings) Then
                                        Dim dataValues As DataTable = OpenTable("DataValues", "SELECT * FROM " & db_tbl_DataValues & " WHERE " & db_fld_ValID & " < 0", settings)
                                        'dataValues.Columns(db_fld_ValDateTime).DataType = System.Type.GetType("System.DateTime")
                                        dt = (fileNode.Item(config_File_DT).InnerText <> "")
                                        utcdt = (fileNode.Item(config_File_UTCDT).InnerText <> "")
                                        utcOff = (fileNode.Item(config_File_UTCOff).InnerText <> "")
                                        DST = fileNode.Item(config_File_DST).InnerText


                                        For y = 0 To (fileNode.ChildNodes.Count - 1)
                                            Try
                                                mapNode = fileNode.ChildNodes(y)
                                                If (mapNode.Name = config_File_Map) Then
                                                    If Not (file Is Nothing) Then
                                                        If utcdt Then
                                                            If (LCase(fileNode.Item(config_File_IncludeOld).InnerText) = "true") Then
                                                                first = GetFirstUTCDate(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                            Else
                                                                first = Date.MinValue
                                                            End If
                                                            last = GetLastUTCDate(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                        ElseIf dt Then
                                                            If (LCase(fileNode.Item(config_File_IncludeOld).InnerText) = "true") Then
                                                                first = GetFirstDate(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                            Else
                                                                first = Date.MinValue
                                                            End If
                                                            last = GetLastDate(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                        Else
                                                            first = Date.MinValue
                                                            last = Date.MaxValue
                                                        End If
                                                        fileBOI = mapNode.Item(config_Map_FileBOR).InnerText
                                                        DBBOI = mapNode.Item(config_Map_DatabaseBOR).InnerText
                                                        POR = TimeSpan.Parse(mapNode.Item(config_Map_PeriodOfRecord).InnerText)


                                                        If fileBOI AndAlso (Not DBBOI) Then
                                                            If first <> New DateTime Then
                                                                first = first.Subtract(POR)
                                                            End If
                                                            If last <> New DateTime Then
                                                                last = last.Subtract(POR)
                                                            End If


                                                        ElseIf DBBOI AndAlso (Not fileBOI) Then
                                                            first = first.Add(POR)
                                                            last = last.Add(POR)
                                                        End If

                                                        Dim RowsAdded As Integer = 0
                                                        Dim seriesID As Integer = IsSeries(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                        If (seriesID >= 0) Then
                                                            LogUpdate(vbTab & vbTab & "Loading Data For Series #" & seriesID & "...")
                                                        Else
                                                            LogUpdate(vbTab & vbTab & "Loading Data For New Series...")
                                                        End If


                                                        valueID = GetLastValueID(settings) + 1
                                                        Dim LastDT As New clsUTCDT()
                                                        For z = 0 To (file.Rows.Count - 1)
                                                            Try

                                                                If ((utcdt AndAlso _
                                                                    (Date.Parse(file.Rows(z).Item(fileNode.Item(config_File_UTCDT).InnerXml)) > last))) OrElse _
                                                                    (((Not utcdt) AndAlso dt) AndAlso _
                                                                    (Date.Parse(file.Rows(z).Item(fileNode.Item(config_File_DT).InnerText)) > last)) OrElse _
                                                                    ((utcdt AndAlso _
                                                                    (Date.Parse(file.Rows(z).Item(fileNode.Item(config_File_UTCDT).InnerXml)) < first))) OrElse _
                                                                    (((Not utcdt) AndAlso dt) AndAlso _
                                                                    (Date.Parse(file.Rows(z).Item(fileNode.Item(config_File_DT).InnerText)) < first)) Then

                                                                    tempRow = dataValues.NewRow
                                                                    tempRow.Item(db_fld_ValID) = valueID + valueIDOffset
                                                                    valueIDOffset += 1
                                                                    If IsNumeric(file.Rows(z).Item(mapNode.Item(config_Map_Val).InnerText)) Then
                                                                        tempRow.Item(db_fld_ValValue) = file.Rows(z).Item(mapNode.Item(config_Map_Val).InnerText)
                                                                    Else
                                                                        tempRow.Item(db_fld_ValValue) = GetNoDataValue(mapNode.Item(config_Map_Var).InnerText, settings)
                                                                        ErrorLog(vbTab & vbTab & "Row: " & (z + fileNode.Item(config_File_DataRow).InnerText) & vbCrLf & "Column: " & mapNode.Item(config_Map_Val).InnerText & vbCrLf & "Has a value of '" & file.Rows(z).Item(mapNode.Item(config_Map_Val).InnerText) & "'." & vbCrLf & "Value of " & tempRow.Item(db_fld_ValValue) & " will be used instead.")
                                                                    End If
                                                                    Dim tempdate As clsUTCDT
                                                                    If (Not dt) Then
                                                                        tempdate = New clsUTCDT(file.Rows(z).Item(fileNode.Item(config_File_UTCDT).InnerXml).ToString, DST, CBool(mapNode.Item(config_Map_FileBOR).InnerText), CBool(mapNode.Item(config_Map_DatabaseBOR).InnerText), mapNode.Item(config_Map_PeriodOfRecord).InnerText)
                                                                        LastDT = tempdate
                                                                    ElseIf (Not utcdt) Then
                                                                        Dim tempUTCOff As Integer = Val(fileNode.Item(config_File_UTCOff).InnerText)
                                                                        tempdate = New clsUTCDT((file.Rows(z).Item(fileNode.Item(config_File_DT).InnerText).ToString), tempUTCOff, DST, LastDT, CBool(mapNode.Item(config_Map_FileBOR).InnerText), CBool(mapNode.Item(config_Map_DatabaseBOR).InnerText), mapNode.Item(config_Map_PeriodOfRecord).InnerText)
                                                                        LastDT = tempdate
                                                                    Else
                                                                        tempdate = New clsUTCDT(file.Rows(z).Item(fileNode.Item(config_File_DT).InnerText).ToString, file.Rows(z).Item(fileNode.Item(config_File_UTCDT).InnerText).ToString, CBool(mapNode.Item(config_Map_FileBOR).InnerText), CBool(mapNode.Item(config_Map_DatabaseBOR).InnerText), mapNode.Item(config_Map_PeriodOfRecord).InnerText)
                                                                        'tempRow.Item(db_fld_ValDateTime) = CDate()
                                                                        'tempRow.Item(db_fld_ValUTCDateTime) = CDate()
                                                                        'tempRow.Item(db_fld_ValUTCOffset) = (tempRow.Item(db_fld_ValDateTime) - tempRow.Item(db_fld_ValUTCDateTime)).Hours
                                                                    End If
                                                                    'tempRow.Item(db_fld_ValDateTime) = tempdate.getLocalDT

                                                                    tempRow.Item(db_fld_ValDateTime) = tempdate.getLocalDT
                                                                    tempRow.Item(db_fld_ValUTCOffset) = tempdate.getUTCOffset
                                                                    tempRow.Item(db_fld_ValUTCDateTime) = tempdate.getUTCDT

                                                                    tempRow.Item(db_fld_ValSiteID) = Val(mapNode.Item(config_Map_Site).InnerText)
                                                                    tempRow.Item(db_fld_ValVarID) = Val(mapNode.Item(config_Map_Var).InnerText)
                                                                    If (mapNode.Item(config_Map_OT).InnerText = "") Or (mapNode.Item(config_Map_OT).InnerText = db_expr_None) Then
                                                                        tempRow.Item(db_fld_ValOffsetTypeID) = DBNull.Value
                                                                    Else
                                                                        tempRow.Item(db_fld_ValOffsetTypeID) = Val(mapNode.Item(config_Map_OT).InnerText)
                                                                        tempRow.Item(db_fld_ValOffsetValue) = Val(mapNode.Item(config_Map_OffsetValue).InnerText)
                                                                    End If
                                                                    tempRow.Item(db_fld_ValCensorCode) = "nc"
                                                                    tempRow.Item(db_fld_ValMethodID) = Val(mapNode.Item(config_Map_Method).InnerText)
                                                                    tempRow.Item(db_fld_ValSourceID) = Val(mapNode.Item(config_Map_Source).InnerText)
                                                                    tempRow.Item(db_fld_ValQCLevel) = Val(mapNode.Item(config_Map_QCLevel).InnerText)
                                                                    dataValues.Rows.Add(tempRow)
                                                                    'TestLog(tempRow.Item(db_fld_ValValue))
                                                                    RowsAdded += 1
                                                                End If
                                                            Catch ex As Exception
                                                                If ex.Message.Contains("Object reference not set to an instance of an object") Then
                                                                    ErrorLog("XML Element Missing", ex)
                                                                Else
                                                                    ErrorLog("Error Running Update", ex)
                                                                End If
                                                                Me.Close()
                                                            End Try
                                                        Next z

                                                        If RowsAdded > 0 Then
                                                            If (seriesID >= 0) Then
                                                                LogUpdate(vbTab & vbTab & "Rows to Add to Series #" & seriesID & ": " & RowsAdded & ".")
                                                            Else
                                                                LogUpdate(vbTab & vbTab & "Rows to Add to New Series: " & RowsAdded & ".")
                                                            End If
                                                        Else
                                                            LogUpdate(vbTab & vbTab & "No Rows to Add to Series.")
                                                        End If
                                                    End If
                                                End If
                                            Catch ex As Exception
                                                If ex.Message.Contains("Object reference not set to an instance of an object") Then
                                                    ErrorLog("XML Element Missing", ex)
                                                Else
                                                    ErrorLog("Error Running Update", ex)
                                                End If
                                                Me.Close()
                                            End Try
                                        Next y

                                        If (dataValues.Rows.Count > 0) Then
                                            LogUpdate(vbTab & "Updating File #" & fileNode.Attributes(config_File_ID).Value & ".")
                                            If UpdateTable(dataValues, "SELECT * FROM " & db_tbl_DataValues, settings) Then
                                                LogUpdate(vbTab & "Rows Added to Database: " & dataValues.Rows.Count & ".")
                                            End If
                                        Else
                                            LogUpdate(vbTab & "File Is Current.  No Data Added.")
                                        End If
                                        dataValues.Rows.Clear()
                                    End If
                                End If
                            End If
                            file = Nothing
                        End If
                    Catch ex As Exception
                        If ex.Message.Contains("Object reference not set to an instance of an object") Then
                            ErrorLog("XML Element Missing", ex)
                        Else
                            ErrorLog("Error Running Update", ex)
                        End If
                        Me.Close()
                    End Try
                Next x

                LogUpdate("Updating Series Catalog Tables...")
                For x = 0 To (root.ChildNodes.Count - 1)
                    Try
                        fileNode = root.ChildNodes(x)
                        If (fileNode.Name = config_root_File) Then
                            settings = New clsConnectionSettings(fileNode.Item(config_File_Server).InnerText, fileNode.Item(config_File_DB).InnerText, 10, False, fileNode.Item(config_File_User).InnerText, Decrypt(fileNode.Item(config_File_Password).InnerText))
                            If TestDBConnection(settings) Then
                                For y = 0 To (fileNode.ChildNodes.Count - 1)
                                    Try
                                        mapNode = fileNode.ChildNodes(y)
                                        If (mapNode.Name = config_File_Map) Then
                                            Dim seriesID As Integer = -1

                                            seriesID = IsSeries(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)

                                            If (seriesID >= 0) Then
                                                UpdateSeriesCatalog(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                If seriesID > 0 Then
                                                    LogUpdate("Updated Series Catalog Table for Series #" & seriesID)
                                                End If
                                            Else
                                                CreateNewSeries(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)

                                                seriesID = IsSeries(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)

                                                If seriesID > 0 Then
                                                    LogUpdate("Series # " & seriesID & " added to series catalog table.")
                                                End If
                                            End If
                                        End If
                                    Catch ex As Exception
                                        If ex.Message.Contains("Object reference not set to an instance of an object") Then
                                            ErrorLog("XML Element Missing", ex)
                                        Else
                                            ErrorLog("Error Running Update", ex)
                                        End If
                                        Me.Close()
                                    End Try
                                Next y
                            End If
                        End If
                    Catch ex As Exception
                        If ex.Message.Contains("Object reference not set to an instance of an object") Then
                            ErrorLog("XML Element Missing", ex)
                        Else
                            ErrorLog("Error Running Update", ex)
                        End If
                        Me.Close()
                    End Try
                Next x
                LogUpdate("Series Catalog Tables Updated.")

                xmlDoc.Save(g_Config_Dir & "\Config.xml")

                LogUpdate("Update Completed @ " & vbCrLf & Now.ToLongDateString & vbTab & Now.ToLongTimeString & vbCrLf & vbCrLf & " * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *" & vbCrLf & vbCrLf)
            Else
                ErrorLog("Unable to find config file.")
            End If
        Catch ex As Xml.XmlException
            ErrorLog("Error in Config File.", ex)
        Catch ex As Exception
            If ex.Message.Contains("Object reference not set to an instance of an object") Then
                ErrorLog("XML Element Missing", ex)
            Else
                ErrorLog("Error Running Update", ex)
            End If
            Me.Close()
        End Try
        tbIcon.Visible = False
    End Sub

    ''' <summary>
    ''' Loads data based on the ID in the Config.xml file.  Ignores the schedule
    ''' </summary>
    ''' <param name="IDs"></param>
    ''' <remarks></remarks>
    Public Sub Import(ByVal IDs() As Integer)
        Try
            tbIcon.Visible = True
            Dim settings As clsConnectionSettings
            Dim dt, utcdt, utcOff, DST, monthly, yearly As Boolean
            Dim x, y, z As Integer
            Dim i As Integer
            Dim file As DataTable
            Dim first, last As DateTime
            Dim tempRow As DataRow
            Dim xmlDoc As New System.Xml.XmlDocument
            Dim root, fileNode, mapNode As System.Xml.XmlNode
            Dim period As TimeSpan
            Dim offset As DateTime
            Dim monthyearPeriod As Integer
            Dim valueID As Integer
            Dim valueIDOffset As Integer = 0
            Dim delimiter As String = ","

            If System.IO.File.Exists(g_Config_Dir & "\Config.xml") Then
                xmlDoc.Load(g_Config_Dir & "\Config.xml")

                LogUpdate(Now.ToLongDateString & vbTab & Now.ToLongTimeString & vbCrLf & "Config File Loaded." & vbCrLf & "Ignoring Update Schedule...")
                root = xmlDoc.DocumentElement

                For x = 0 To (root.ChildNodes.Count - 1)
                    Try
                        fileNode = root.ChildNodes(x)
                        If (fileNode.Name = config_root_File) Then
                            Dim fnd As Boolean = False
                            For i = 0 To (IDs.Length - 1)
                                If IDs(i) = fileNode.Attributes(config_File_ID).Value Then
                                    fnd = True
                                    Exit For
                                End If
                            Next i
                            If fnd Then

                                offset = New DateTime()
                                Date.TryParse(fileNode.Item(config_File_SchedOffset).InnerText, offset)
                                monthyearPeriod = Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0))

                                Select Case LCase(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(1))
                                    Case "seconds"
                                        period = New TimeSpan(0, 0, Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)))
                                    Case "second"
                                        period = New TimeSpan(0, 0, Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)))
                                    Case "minutes"
                                        period = New TimeSpan(0, Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0)
                                    Case "minute"
                                        period = New TimeSpan(0, Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0)
                                    Case "hours"
                                        period = New TimeSpan(Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0, 0)
                                    Case "hour"
                                        period = New TimeSpan(Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0, 0)
                                    Case "days"
                                        period = New TimeSpan(Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0, 0, 0)
                                    Case "day"
                                        period = New TimeSpan(Val(Split(fileNode.Item(config_File_SchedPeriod).InnerText)(0)), 0, 0, 0)
                                    Case "months"
                                        monthly = True
                                    Case "month"
                                        monthly = True
                                    Case "years"
                                        yearly = True
                                    Case "year"
                                        yearly = True
                                End Select

                                If (fileNode.Item(config_File_Delimiter) Is Nothing) OrElse (fileNode.Item(config_File_Delimiter).InnerText = "") Then
                                    delimiter = ","
                                Else
                                    Select Case fileNode.Item(config_File_Delimiter).InnerText
                                        Case "<Tab Delimited>"
                                            delimiter = ControlChars.Tab
                                        Case "<Comma Delimited>"
                                            delimiter = ","
                                        Case Else
                                            delimiter = fileNode.Item(config_File_Delimiter).InnerText
                                    End Select
                                End If

                                LogUpdate(vbTab & "Loading File #" & fileNode.Attributes(config_File_ID).Value & "...")
                                'If (LCase(fileNode.Item(config_File_Type).InnerText) = "web") Then
                                file = LoadFile((LCase(fileNode.Item(config_File_Type).InnerText) = "web"), fileNode.Item(config_File_Loc).InnerText, fileNode.Item(config_File_HeaderRow).InnerText, fileNode.Item(config_File_DataRow).InnerText, delimiter)
                                'Else
                                '    file = LoadFile(False, fileNode.Item(config_File_Loc).InnerText, fileNode.Item(config_File_HeaderRow).InnerText, fileNode.Item(config_File_DataRow).InnerText)
                                'End If

                                If Not (file Is Nothing) Then
                                    LogUpdate(vbTab & "Server: " & fileNode.Item(config_File_Server).InnerText & vbCrLf & vbTab & "Database: " & fileNode.Item(config_File_DB).InnerText & vbCrLf & vbTab & "User: " & fileNode.Item(config_File_User).InnerText)

                                    fileNode.Item(config_File_Last).InnerText = Now
                                    settings = New clsConnectionSettings(fileNode.Item(config_File_Server).InnerText, fileNode.Item(config_File_DB).InnerText, 10, False, fileNode.Item(config_File_User).InnerText, Decrypt(fileNode.Item(config_File_Password).InnerText))
                                    If TestDBConnection(settings) Then
                                        Dim dataValues As DataTable = OpenTable("DataValues", "SELECT * FROM " & db_tbl_DataValues & " WHERE " & db_fld_ValID & " < 0", settings)

                                        dt = (fileNode.Item(config_File_DT).InnerText <> "")
                                        utcdt = (fileNode.Item(config_File_UTCDT).InnerText <> "")
                                        utcOff = (fileNode.Item(config_File_UTCOff).InnerText <> "")
                                        DST = fileNode.Item(config_File_DST).InnerText

                                        For y = 0 To (fileNode.ChildNodes.Count - 1)
                                            Try
                                                mapNode = fileNode.ChildNodes(y)
                                                If (mapNode.Name = config_File_Map) Then
                                                    If Not (file Is Nothing) Then
                                                        If utcdt Then
                                                            If (LCase(fileNode.Item(config_File_IncludeOld).InnerText) = "true") Then
                                                                first = GetFirstUTCDate(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                            Else
                                                                first = Date.MinValue
                                                            End If
                                                            last = GetLastUTCDate(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                        ElseIf dt Then
                                                            If (LCase(fileNode.Item(config_File_IncludeOld).InnerText) = "true") Then
                                                                first = GetFirstDate(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                            Else
                                                                first = Date.MinValue
                                                            End If
                                                            last = GetLastDate(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                        Else
                                                            first = Date.MinValue
                                                            last = Date.MaxValue
                                                        End If


                                                        Dim RowsAdded As Integer = 0

                                                        Dim seriesID As Integer = IsSeries(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)

                                                        If (seriesID >= 0) Then
                                                            LogUpdate(vbTab & vbTab & "Loading Data For Series #" & seriesID & "...")
                                                        Else
                                                            LogUpdate(vbTab & vbTab & "Loading Data For New Series...")
                                                        End If

                                                        valueID = GetLastValueID(settings) + 1
                                                        Dim LastDT As New clsUTCDT()
                                                        For z = 0 To (file.Rows.Count - 1)
                                                            Try
                                                                If (utcdt AndAlso _
                                                                (CDate(file.Rows(z).Item(fileNode.Item(config_File_UTCDT).InnerText)) > last)) OrElse _
                                                                (((Not utcdt) AndAlso dt) AndAlso _
                                                                (CDate(file.Rows(z).Item(fileNode.Item(config_File_DT).InnerText)) > last)) OrElse _
                                                                ((LCase(fileNode.Item(config_File_IncludeOld).InnerText) = "true") AndAlso utcdt AndAlso _
                                                                (CDate(file.Rows(z).Item(fileNode.Item(config_File_UTCDT).InnerText)) < first)) OrElse _
                                                                ((LCase(fileNode.Item(config_File_IncludeOld).InnerText) = "true") AndAlso ((Not utcdt) AndAlso dt) AndAlso _
                                                                (CDate(file.Rows(z).Item(fileNode.Item(config_File_DT).InnerText)) < first)) Then

                                                                    tempRow = dataValues.NewRow
                                                                    tempRow.Item(db_fld_ValID) = valueID + valueIDOffset
                                                                    valueIDOffset += 1
                                                                    If IsNumeric(file.Rows(z).Item(mapNode.Item(config_Map_Val).InnerText)) Then
                                                                        tempRow.Item(db_fld_ValValue) = file.Rows(z).Item(mapNode.Item(config_Map_Val).InnerText)
                                                                    Else
                                                                        tempRow.Item(db_fld_ValValue) = GetNoDataValue(mapNode.Item(config_Map_Var).InnerText, settings)
                                                                        ErrorLog(vbTab & vbTab & "Row: " & (z + fileNode.Item(config_File_DataRow).InnerText) & vbCrLf & "Column: " & mapNode.Item(config_Map_Val).InnerText & vbCrLf & "Has a value of '" & file.Rows(z).Item(mapNode.Item(config_Map_Val).InnerText) & "'." & vbCrLf & "Value of " & tempRow.Item(db_fld_ValValue) & " will be used instead.")
                                                                    End If

                                                                    Dim tempdate As clsUTCDT
                                                                    If (Not dt) Then
                                                                        tempdate = New clsUTCDT(file.Rows(z).Item(fileNode.Item(config_File_UTCDT).InnerText).ToString, DST, CBool(mapNode.Item(config_Map_FileBOR).InnerText), CBool(mapNode.Item(config_Map_DatabaseBOR).InnerText), mapNode.Item(config_Map_PeriodOfRecord).InnerText)
                                                                        LastDT = tempdate
                                                                    ElseIf (Not utcdt) Then
                                                                        Dim tempUTCOff As Integer = Val(fileNode.Item(config_File_UTCOff).InnerText)
                                                                        tempdate = New clsUTCDT(file.Rows(z).Item(fileNode.Item(config_File_DT).InnerText).ToString, tempUTCOff, DST, LastDT, CBool(mapNode.Item(config_Map_FileBOR).InnerText), CBool(mapNode.Item(config_Map_DatabaseBOR).InnerText), mapNode.Item(config_Map_PeriodOfRecord).InnerText)
                                                                        LastDT = tempdate
                                                                    Else
                                                                        tempdate = New clsUTCDT(file.Rows(z).Item(fileNode.Item(config_File_DT).InnerText).ToString, file.Rows(z).Item(fileNode.Item(config_File_UTCDT).InnerText).ToString, CBool(mapNode.Item(config_Map_FileBOR).InnerText), CBool(mapNode.Item(config_Map_DatabaseBOR).InnerText), mapNode.Item(config_Map_PeriodOfRecord).InnerText)
                                                                        'tempRow.Item(db_fld_ValDateTime) = CDate()
                                                                        'tempRow.Item(db_fld_ValUTCDateTime) = CDate()
                                                                        'tempRow.Item(db_fld_ValUTCOffset) = (tempRow.Item(db_fld_ValDateTime) - tempRow.Item(db_fld_ValUTCDateTime)).Hours
                                                                    End If
                                                                    tempRow.Item(db_fld_ValDateTime) = tempdate.getLocalDT
                                                                    tempRow.Item(db_fld_ValUTCOffset) = tempdate.getUTCOffset
                                                                    tempRow.Item(db_fld_ValUTCDateTime) = tempdate.getUTCDT


                                                                    tempRow.Item(db_fld_ValSiteID) = Val(mapNode.Item(config_Map_Site).InnerText)
                                                                    tempRow.Item(db_fld_ValVarID) = Val(mapNode.Item(config_Map_Var).InnerText)
                                                                    If (mapNode.Item(config_Map_OT).InnerText = "") Or (mapNode.Item(config_Map_OT).InnerText = db_expr_None) Then
                                                                        tempRow.Item(db_fld_ValOffsetTypeID) = DBNull.Value
                                                                    Else
                                                                        tempRow.Item(db_fld_ValOffsetTypeID) = Val(mapNode.Item(config_Map_OT).InnerText)
                                                                        tempRow.Item(db_fld_ValOffsetValue) = Val(mapNode.Item(config_Map_OffsetValue).InnerText)
                                                                    End If
                                                                    tempRow.Item(db_fld_ValCensorCode) = "nc"
                                                                    tempRow.Item(db_fld_ValMethodID) = Val(mapNode.Item(config_Map_Method).InnerText)
                                                                    tempRow.Item(db_fld_ValSourceID) = Val(mapNode.Item(config_Map_Source).InnerText)
                                                                    tempRow.Item(db_fld_ValQCLevel) = Val(mapNode.Item(config_Map_QCLevel).InnerText)
                                                                    dataValues.Rows.Add(tempRow)
                                                                    'TestLog(tempRow.Item(db_fld_ValValue))
                                                                    RowsAdded += 1
                                                                End If
                                                            Catch ex As Exception
                                                                If ex.Message.Contains("Object reference not set to an instance of an object") Then
                                                                    ErrorLog("XML Element Missing", ex)
                                                                Else
                                                                    ErrorLog("Error Running Update", ex)
                                                                End If
                                                                Me.Close()
                                                            End Try
                                                        Next z

                                                        If RowsAdded > 0 Then
                                                            If (seriesID >= 0) Then
                                                                LogUpdate(vbTab & vbTab & "Rows to Add to Series #" & seriesID & ": " & RowsAdded & ".")
                                                            Else
                                                                LogUpdate(vbTab & vbTab & "Rows to Add to New Series: " & RowsAdded & ".")
                                                            End If
                                                        Else
                                                            LogUpdate(vbTab & vbTab & "No Rows to Add to Series.")
                                                        End If
                                                    End If
                                                End If
                                            Catch ex As Exception
                                                If ex.Message.Contains("Object reference not set to an instance of an object") Then
                                                    ErrorLog("XML Element Missing", ex)
                                                Else
                                                    ErrorLog("Error Running Update", ex)
                                                End If
                                                Me.Close()
                                            End Try
                                        Next y

                                        If (dataValues.Rows.Count > 0) Then
                                            LogUpdate(vbTab & "Updating File #" & fileNode.Attributes(config_File_ID).Value & ".")
                                            If UpdateTable(dataValues, "SELECT * FROM " & db_tbl_DataValues, settings) Then
                                                LogUpdate(vbTab & "Rows Added to Database: " & dataValues.Rows.Count & ".")
                                            End If
                                        Else
                                            LogUpdate(vbTab & "File Is Current.  No Data Added.")
                                        End If
                                        dataValues.Rows.Clear()
                                    End If
                                End If
                            End If

                            file = Nothing
                        End If
                    Catch ex As Exception
                        If ex.Message.Contains("Object reference not set to an instance of an object") Then
                            ErrorLog("XML Element Missing", ex)
                        Else
                            ErrorLog("Error Running Update", ex)
                        End If
                        Me.Close()
                    End Try
                Next x


                LogUpdate("Updating Series Catalog Table...")
                For x = 0 To (root.ChildNodes.Count - 1)
                    Try
                        fileNode = root.ChildNodes(x)
                        If (fileNode.Name = config_root_File) Then
                            Dim fnd As Boolean = False
                            For i = 0 To (IDs.Length - 1)
                                If IDs(i) = fileNode.Attributes(config_File_ID).Value Then
                                    fnd = True
                                    Exit For
                                End If
                            Next i
                            If fnd Then
                                settings = New clsConnectionSettings(fileNode.Item(config_File_Server).InnerText, fileNode.Item(config_File_DB).InnerText, 10, False, fileNode.Item(config_File_User).InnerText, Decrypt(fileNode.Item(config_File_Password).InnerText))
                                For y = 0 To (fileNode.ChildNodes.Count - 1)
                                    Try
                                        mapNode = fileNode.ChildNodes(y)
                                        If (mapNode.Name = config_File_Map) Then
                                            Dim seriesID As Integer = -1

                                            seriesID = IsSeries(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)

                                            If (seriesID >= 0) Then
                                                UpdateSeriesCatalog(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)
                                                If seriesID > 0 Then
                                                    LogUpdate("Updated Series Catalog Table for Series #" & seriesID)
                                                End If
                                            Else
                                                CreateNewSeries(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)

                                                seriesID = IsSeries(mapNode.Item(config_Map_Site).InnerText, mapNode.Item(config_Map_Var).InnerText, mapNode.Item(config_Map_Method).InnerText, mapNode.Item(config_Map_Source).InnerText, mapNode.Item(config_Map_QCLevel).InnerText, settings)

                                                If seriesID > 0 Then
                                                    LogUpdate("Series # " & seriesID & " added to series catalog table.")
                                                End If
                                            End If
                                        End If
                                    Catch ex As Exception
                                        If ex.Message.Contains("Object reference not set to an instance of an object") Then
                                            ErrorLog("XML Element Missing", ex)
                                        Else
                                            ErrorLog("Error Running Update", ex)
                                        End If
                                        Me.Close()
                                    End Try
                                Next y
                            End If
                        End If
                    Catch ex As Exception
                        If ex.Message.Contains("Object reference not set to an instance of an object") Then
                            ErrorLog("XML Element Missing", ex)
                        Else
                            ErrorLog("Error Running Update", ex)
                        End If
                        Me.Close()
                    End Try
                Next x
                LogUpdate("Series Catalog Table Updated.")

                xmlDoc.Save(g_Config_Dir & "\Config.xml")

                LogUpdate("Update Completed @ " & vbCrLf & Now.ToLongDateString & vbTab & Now.ToLongTimeString & vbCrLf & vbCrLf & " * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *" & vbCrLf & vbCrLf)
            Else
                ErrorLog("Unable to find config file.")
            End If
        Catch ex As Xml.XmlException
            ErrorLog("Error in Config File.", ex)
        Catch ex As Exception
            If ex.Message.Contains("Object reference not set to an instance of an object") Then
                ErrorLog("XML Element Missing", ex)
            Else
                ErrorLog("Error Running Update", ex)
            End If
            Me.Close()
        End Try
        tbIcon.Visible = False
    End Sub

End Class