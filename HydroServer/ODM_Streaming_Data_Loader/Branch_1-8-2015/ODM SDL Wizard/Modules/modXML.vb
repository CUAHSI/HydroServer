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

Module modXML
    'Last Documented 1/1/1

#Region " XML Names "

    Public Const config_root As String = "Config"
    Public Const config_root_File As String = "File"
    Public Const config_File_Server As String = "ServerAddress"
    Public Const config_File_DB As String = "DatabaseName"
    Public Const config_File_User As String = "UserName"
    Public Const config_File_Password As String = "Pword"
    Public Const config_File_ID As String = "ID"
    Public Const config_File_Type As String = "FileLocationType"
    Public Const config_File_Loc As String = "FileLocation"
    Public Const config_File_Delimiter As String = "Delimiter"
    Public Const config_File_HeaderRow As String = "HeaderRowPosition"
    Public Const config_File_DataRow As String = "DataRowPosition"
    Public Const config_File_SchedPeriod As String = "SchedulePeriod"
    Public Const config_File_SchedOffset As String = "ScheduleBeginning"
    Public Const config_File_DT As String = "DateTimeColumnName"
    Public Const config_File_UTCDT As String = "UTCDateTimeColumnName"
    Public Const config_File_UTCOff As String = "TimeZone"
    Public Const config_File_DST As String = "DaylightSavingsTime"
    Public Const config_File_IncludeOld As String = "IncludeOldData"
    Public Const config_File_Last As String = "LastUpdate"
    Public Const config_File_Map As String = "DataSeriesMapping"
    Public Const config_Map_Val As String = "ValueColumnName"
    Public Const config_Map_OffsetValue As String = "OffsetValue"
    Public Const config_Map_Site As String = "SiteID"
    Public Const config_Map_Var As String = "VariableID"
    Public Const config_Map_OT As String = "OffsetTypeID"
    Public Const config_Map_Method As String = "MethodID"
    Public Const config_Map_Source As String = "SourceID"
    Public Const config_Map_QCLevel As String = "QualityControlLevelID"

    Public Const config_Map_FileBOR As String = "FileStartOfInterval"
    Public Const config_Map_DatabaseBOR As String = "DatabaseStartOfInterval"
    Public Const config_Map_PeriodOfRecord As String = "IntervalLength"

#End Region

#Region " Config File Operations "

    ''' <summary>
    ''' Adds a new streaming data file to the configuration file
    ''' </summary>
    ''' <param name="e_ConnSettings">The connection settings to the database</param>
    ''' <param name="e_Type">The filetype (web or local)</param>
    ''' <param name="e_Location">The Location of the file (URL or Filepath)</param>
    ''' <param name="e_Period">The schedule interval</param>
    ''' <param name="e_offset">The date/time the file should first be run </param>
    ''' <param name="e_HeaderRow">The number of the header row (min = 0)</param>
    ''' <param name="e_DataRow">The number of the data row (min = HeaderRow + 1)</param>
    ''' <param name="e_SeriesData">The specifications of what dataseries each column belongs to</param>
    ''' <param name="e_DT">The Date Time column</param>
    ''' <param name="e_UTCDT">The UTC Date Time column</param>
    ''' <param name="e_UTCoff">The UTC offset</param>
    ''' <param name="e_DST">Whether to use Daylight Saving Time</param>
    ''' <param name="e_OldData">Whether to include older data</param>
    ''' <param name="e_delimiter">The delimiter used in the file</param>
    ''' <remarks></remarks>
    Public Sub AddFile(ByVal e_ConnSettings As clsConnectionSettings, ByVal e_Type As String, ByVal e_Location As String, ByVal e_Period As String, ByVal e_offset As String, ByVal e_HeaderRow As Integer, ByVal e_DataRow As Integer, ByVal e_SeriesData As DataTable, ByVal e_DT As String, ByVal e_UTCDT As String, ByVal e_UTCoff As String, ByVal e_DST As Boolean, ByVal e_OldData As Boolean, ByVal e_delimiter As String)
        Dim keepOld As Boolean
        Dim oldDoc As New XmlDocument
        Dim root As XmlNode = Nothing
        Dim MaxID As Integer = 1
        Dim i As Integer

        If System.IO.File.Exists(g_Config_Dir & "\Config.xml") Then
            Try
                oldDoc.Load(g_Config_Dir & "\Config.xml")
                root = oldDoc.DocumentElement
                For i = 0 To (root.ChildNodes.Count - 1)
                    Dim tempID As Integer = Val(root.ChildNodes(i).Attributes(config_File_ID).Value)
                    If tempID >= MaxID Then
                        MaxID = tempID + 1
                    End If
                Next i
                keepOld = True
            Catch ex As Exception
                keepOld = False
                MaxID = 1
            End Try
        End If

        Dim writer As New XmlTextWriter(g_Config_Dir & "\Config.xml", System.Text.Encoding.UTF8)

        Try
            writer.WriteStartDocument()

            writer.WriteStartElement(config_root) 'Start: Config
            If keepOld And Not (root Is Nothing) Then
                writer.WriteRaw(root.InnerXml)
            End If

            writer.WriteStartElement(config_root_File) 'Start: Config >> File
            writer.WriteAttributeString(config_File_ID, MaxID)
            writer.WriteElementString(config_File_Server, e_ConnSettings.ServerAddress)
            writer.WriteElementString(config_File_DB, e_ConnSettings.DBName)
            writer.WriteElementString(config_File_User, e_ConnSettings.UserID)
            writer.WriteElementString(config_File_Password, Encrypt(e_ConnSettings.Password))
            writer.WriteElementString(config_File_Type, e_Type)
            writer.WriteElementString(config_File_Loc, e_Location)
            writer.WriteElementString(config_File_Delimiter, e_delimiter)
            writer.WriteElementString(config_File_HeaderRow, e_HeaderRow)
            writer.WriteElementString(config_File_DataRow, e_DataRow)
            writer.WriteElementString(config_File_SchedPeriod, e_Period)
            writer.WriteElementString(config_File_SchedOffset, e_offset)
            writer.WriteElementString(config_File_DT, e_DT)
            writer.WriteElementString(config_File_UTCDT, e_UTCDT)
            writer.WriteElementString(config_File_UTCOff, e_UTCoff)
            writer.WriteElementString(config_File_DST, e_DST)
            writer.WriteElementString(config_File_IncludeOld, e_OldData)
            writer.WriteElementString(config_File_Last, Date.MinValue.ToString)
            For i = 0 To (e_SeriesData.Rows.Count - 1)
                writer.WriteStartElement(config_File_Map) 'Start: Config >> File >> TableMapping
                writer.WriteElementString(config_Map_Val, e_SeriesData.Rows(i).Item(config_Map_Val))
                writer.WriteElementString(config_Map_Site, e_SeriesData.Rows(i).Item(config_Map_Site))
                writer.WriteElementString(config_Map_Var, e_SeriesData.Rows(i).Item(config_Map_Var))
                writer.WriteElementString(config_Map_OT, e_SeriesData.Rows(i).Item(config_Map_OT))
                writer.WriteElementString(config_Map_OffsetValue, e_SeriesData.Rows(i).Item(config_Map_OffsetValue))
                writer.WriteElementString(config_Map_Method, e_SeriesData.Rows(i).Item(config_Map_Method))
                writer.WriteElementString(config_Map_Source, e_SeriesData.Rows(i).Item(config_Map_Source))
                writer.WriteElementString(config_Map_QCLevel, e_SeriesData.Rows(i).Item(config_Map_QCLevel))
                writer.WriteElementString(config_Map_FileBOR, e_SeriesData.Rows(i).Item(config_Map_FileBOR))
                writer.WriteElementString(config_Map_DatabaseBOR, e_SeriesData.Rows(i).Item(config_Map_DatabaseBOR))
                writer.WriteElementString(config_Map_PeriodOfRecord, e_SeriesData.Rows(i).Item(config_Map_PeriodOfRecord))
                writer.WriteEndElement() 'End: Config >> File >> TableMapping
            Next i
            writer.WriteEndElement() 'End: Config >> File
            writer.WriteEndElement() 'End: Config

            writer.Close()
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Edist and existing streaming data file in the configuration file
    ''' </summary>
    ''' <param name="e_ConnSettings">The connection settings to the database</param>
    ''' <param name="oldFileID">The fileID of the old Steaming Data File in the configuration file</param>
    ''' <param name="e_Type">The filetype (web or local)</param>
    ''' <param name="e_Location">The Location of the file (URL or Filepath)</param>
    ''' <param name="e_Period">The schedule interval</param>
    ''' <param name="e_offset">The date/time the file should first be run </param>
    ''' <param name="e_HeaderRow">The number of the header row (min = 0)</param>
    ''' <param name="e_DataRow">The number of the data row (min = HeaderRow + 1)</param>
    ''' <param name="e_SeriesData">The specifications of what dataseries each column belongs to</param>
    ''' <param name="e_DT">The Date Time column</param>
    ''' <param name="e_UTCDT">The UTC Date Time column</param>
    ''' <param name="e_UTCoff">The UTC offset</param>
    ''' <param name="e_DST">Whether to use Daylight Saving Time</param>
    ''' <param name="e_OldData">Whether to include older data</param>
    ''' <param name="e_delimiter">The delimiter used in the file</param>
    ''' <remarks></remarks>
    Public Sub EditFile(ByVal e_ConnSettings As clsConnectionSettings, ByVal oldFileID As Integer, ByVal e_Type As String, ByVal e_Location As String, ByVal e_Period As String, ByVal e_offset As String, ByVal e_HeaderRow As Integer, ByVal e_DataRow As Integer, ByVal e_SeriesData As DataTable, ByVal e_DT As String, ByVal e_UTCDT As String, ByVal e_UTCoff As String, ByVal e_DST As Boolean, ByVal e_OldData As Boolean, ByVal e_delimiter As String)
        Dim keepOld As Boolean = True
        Dim oldDoc As New XmlDocument
        Dim root As XmlNode = Nothing
        Dim newNode As XmlElement
        Dim i As Integer


        Try
            If System.IO.File.Exists(g_Config_Dir & "\Config.xml") Then
                Dim tempFile As XmlNode
                oldDoc.Load(g_Config_Dir & "\Config.xml")
                root = oldDoc.DocumentElement
                For Each tempFile In root
                    If Val(tempFile.Attributes(config_File_ID).Value) = oldFileID Then
                        tempFile.Item(config_File_Server).InnerText = e_ConnSettings.ServerAddress
                        tempFile.Item(config_File_DB).InnerText = e_ConnSettings.DBName
                        tempFile.Item(config_File_User).InnerText = e_ConnSettings.UserID
                        tempFile.Item(config_File_Password).InnerText = Encrypt(e_ConnSettings.Password)
                        tempFile.Item(config_File_Loc).InnerText = e_Location
                        tempFile.Item(config_File_Type).InnerText = e_Type
                        If (tempFile.Item(config_File_Delimiter) Is Nothing) Then
                            newNode = oldDoc.CreateElement(config_File_Delimiter)
                            newNode.InnerText = e_delimiter
                            tempFile.InsertAfter(newNode, tempFile.Item(config_File_Type))
                        Else
                            tempFile.Item(config_File_Delimiter).InnerText = e_delimiter
                        End If
                        tempFile.Item(config_File_HeaderRow).InnerText = e_HeaderRow
                        tempFile.Item(config_File_DataRow).InnerText = e_DataRow
                        tempFile.Item(config_File_SchedPeriod).InnerText = e_Period
                        tempFile.Item(config_File_SchedOffset).InnerText = e_offset
                        tempFile.Item(config_File_DT).InnerText = e_DT
                        tempFile.Item(config_File_UTCDT).InnerText = e_UTCDT
                        tempFile.Item(config_File_UTCOff).InnerText = e_UTCoff
                        If (tempFile.Item(config_File_DST) Is Nothing) Then
                            newNode = oldDoc.CreateElement(config_File_DST)
                            newNode.InnerText = e_DST
                            tempFile.InsertAfter(newNode, tempFile.Item(config_File_UTCOff))
                        Else
                            tempFile.Item(config_File_DST).InnerText = e_DST
                        End If
                        tempFile.Item(config_File_IncludeOld).InnerText = e_OldData
                        tempFile.Item(config_File_Last).InnerText = Date.MinValue.ToString

                        Dim mapFormat As XmlNode = tempFile.Item(config_File_Map).Clone

                        While (tempFile.SelectNodes(config_File_Map).Count > 0)
                            tempFile.RemoveChild(tempFile.SelectNodes(config_File_Map).Item(0))
                        End While

                        For i = 0 To e_SeriesData.Rows.Count - 1
                            Dim tempMap As XmlNode = mapFormat.Clone
                            tempMap.Item(config_Map_Val).InnerText = e_SeriesData.Rows(i).Item(config_Map_Val)
                            tempMap.Item(config_Map_Site).InnerText = e_SeriesData.Rows(i).Item(config_Map_Site)
                            tempMap.Item(config_Map_Var).InnerText = e_SeriesData.Rows(i).Item(config_Map_Var)
                            tempMap.Item(config_Map_OT).InnerText = e_SeriesData.Rows(i).Item(config_Map_OT)
                            tempMap.Item(config_Map_OffsetValue).InnerText = e_SeriesData.Rows(i).Item(config_Map_OffsetValue)
                            tempMap.Item(config_Map_Method).InnerText = e_SeriesData.Rows(i).Item(config_Map_Method)
                            tempMap.Item(config_Map_Source).InnerText = e_SeriesData.Rows(i).Item(config_Map_Source)
                            tempMap.Item(config_Map_QCLevel).InnerText = e_SeriesData.Rows(i).Item(config_Map_QCLevel)
                            tempMap.Item(config_Map_FileBOR).InnerText = e_SeriesData.Rows(i).Item(config_Map_FileBOR)
                            tempMap.Item(config_Map_DatabaseBOR).InnerText = e_SeriesData.Rows(i).Item(config_Map_DatabaseBOR)
                            tempMap.Item(config_Map_PeriodOfRecord).InnerText = e_SeriesData.Rows(i).Item(config_Map_PeriodOfRecord)

                            tempFile.AppendChild(tempMap)
                        Next
                        'root.AppendChild(tempFile)
                    End If
                    oldDoc.Save(g_Config_Dir & "\Config.xml")
                Next tempFile
            End If
            Return
        Catch ex As Exception
            keepOld = False
        End Try

        If (Not keepOld) Then
            Try


                Dim writer As New XmlTextWriter(g_Config_Dir & "\Config.xml", System.Text.Encoding.UTF8)
                writer.Formatting = Formatting.Indented

                writer.WriteStartDocument()

                writer.WriteStartElement(config_root) 'Start: Config

                writer.WriteStartElement(config_root_File) 'Start: Config >> File
                writer.WriteAttributeString(config_File_ID, oldFileID)
                writer.WriteElementString(config_File_Server, e_ConnSettings.ServerAddress)
                writer.WriteElementString(config_File_DB, e_ConnSettings.DBName)
                writer.WriteElementString(config_File_User, e_ConnSettings.UserID)
                writer.WriteElementString(config_File_Password, Encrypt(e_ConnSettings.Password))
                writer.WriteElementString(config_File_Type, e_Type)
                writer.WriteElementString(config_File_Loc, e_Location)
                writer.WriteElementString(config_File_Delimiter, e_delimiter)
                writer.WriteElementString(config_File_HeaderRow, e_HeaderRow)
                writer.WriteElementString(config_File_DataRow, e_DataRow)
                writer.WriteElementString(config_File_SchedPeriod, e_Period)
                writer.WriteElementString(config_File_SchedOffset, e_offset)
                writer.WriteElementString(config_File_DT, e_DT)
                writer.WriteElementString(config_File_UTCDT, e_UTCDT)
                writer.WriteElementString(config_File_UTCOff, e_UTCoff)
                writer.WriteElementString(config_File_DST, e_DST)
                writer.WriteElementString(config_File_IncludeOld, e_OldData)
                writer.WriteElementString(config_File_Last, Date.MinValue.ToString)
                For i = 0 To (e_SeriesData.Rows.Count - 1)
                    writer.WriteStartElement(config_File_Map) 'Start: Config >> File >> TableMapping
                    writer.WriteElementString(config_Map_Val, e_SeriesData.Rows(i).Item(config_Map_Val))
                    writer.WriteElementString(config_Map_Site, e_SeriesData.Rows(i).Item(config_Map_Site))
                    writer.WriteElementString(config_Map_Var, e_SeriesData.Rows(i).Item(config_Map_Var))
                    writer.WriteElementString(config_Map_OT, e_SeriesData.Rows(i).Item(config_Map_OT))
                    writer.WriteElementString(config_Map_OffsetValue, e_SeriesData.Rows(i).Item(config_Map_OffsetValue))
                    writer.WriteElementString(config_Map_Method, e_SeriesData.Rows(i).Item(config_Map_Method))
                    writer.WriteElementString(config_Map_Source, e_SeriesData.Rows(i).Item(config_Map_Source))
                    writer.WriteElementString(config_Map_QCLevel, e_SeriesData.Rows(i).Item(config_Map_QCLevel))
                    writer.WriteElementString(config_Map_FileBOR, e_SeriesData.Rows(i).Item(config_Map_FileBOR))
                    writer.WriteElementString(config_Map_DatabaseBOR, e_SeriesData.Rows(i).Item(config_Map_DatabaseBOR))
                    writer.WriteElementString(config_Map_PeriodOfRecord, e_SeriesData.Rows(i).Item(config_Map_PeriodOfRecord))

                    writer.WriteEndElement() 'End: Config >> File >> TableMapping
                Next i
                writer.WriteEndElement() 'End: Config >> File
                writer.WriteEndElement() 'End: Config

                writer.Close()

            Catch ex As Exception
                ShowError(ex)
            End Try
        End If
    End Sub

#End Region

End Module
