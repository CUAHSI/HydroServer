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
    'Last Documented 8/30/07

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

End Module
