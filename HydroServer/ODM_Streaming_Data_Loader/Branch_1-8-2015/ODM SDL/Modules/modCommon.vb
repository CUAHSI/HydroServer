'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..

Module Common
    'Last Documented 8/29/07

#Region " Global Variables "

    ''' <summary>
    ''' The filepath of the folder where the executables are located.  
    ''' </summary>
    ''' <remarks></remarks>
    Public g_EXE_Dir As String
    Public g_Config_Dir As String

#End Region

#Region " Error Reporting Functionality "

    ''' <summary>
    ''' Writes an error message to the log file.  Including the message from the exception.
    ''' </summary>
    ''' <param name="message">A custom message to help the tech support trace the exception.</param>
    ''' <param name="err">The exception that describes the error</param>
    ''' <remarks></remarks>
    Public Sub ErrorLog(ByVal message As String, ByVal err As Exception)
        '#If DEBUG Then
        '        MsgBox(message & vbCrLf & vbCrLf & err.StackTrace)
        '#End If
        Try
            Dim Writer As New System.IO.StreamWriter(g_Config_Dir & "\Log.txt", True)
            Writer.WriteLine("ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Writer.WriteLine(message)
            Writer.WriteLine("Error Message: " & err.Message)
            'Writer.WriteLine("Stack Trace: " & err.StackTrace) 'Testing Only!
            Writer.WriteLine()
            Writer.Close()
        Catch ex As Exception
            Dim Writer As New System.IO.StreamWriter(g_Config_Dir & "\Errors.txt", True)
            Writer.WriteLine("ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Writer.WriteLine("Error Writing to Log File.")
            Writer.WriteLine("Error Message: " & ex.Message)
            'Writer.WriteLine("Stack Trace: " & ex.StackTrace) 'Testing Only!
            Writer.WriteLine()
            Writer.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Writes an error message to the log file.
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub ErrorLog(ByVal message As String)
        '

        Try
            Dim Writer As New System.IO.StreamWriter(g_Config_Dir & "\Log.txt", True)
            Writer.WriteLine("ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Writer.WriteLine("Error Message: " & message)
            Writer.WriteLine()
            Writer.Close()
        Catch ex As Exception
            Dim Writer As New System.IO.StreamWriter(g_Config_Dir & "\Errors.txt", True)
            Writer.WriteLine("ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Writer.WriteLine("Error Writing to Log File.")
            Writer.WriteLine("Error Message: " & ex.Message)
            Writer.WriteLine("Stack Trace: " & ex.StackTrace)
            Writer.WriteLine()
            Writer.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Writes messages to the log file with an empty line between each message.
    ''' </summary>
    ''' <param name="comment"></param>
    ''' <remarks></remarks>
    Public Sub LogUpdate(ByVal comment As String)
        Try
            Dim Writer As New System.IO.StreamWriter(g_Config_Dir & "\Log.txt", True)
            'Writer.WriteLine(Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Writer.WriteLine(comment)
            Writer.WriteLine()
            Writer.Close()
        Catch ex As Exception
            ErrorLog("Unable to update log file.", ex)

            Dim Writer As New System.IO.StreamWriter(g_Config_Dir & "\Errors.txt", True)
            Writer.WriteLine("ERROR @ " & Now.ToLongDateString & vbTab & Now.ToLongTimeString)
            Writer.WriteLine("Error Writing to Log File.")
            Writer.WriteLine("Error Message: " & ex.Message)
            Writer.WriteLine("Stack Trace: " & ex.StackTrace)
            Writer.WriteLine()
            Writer.Close()
        End Try
    End Sub

#End Region

    Public Function getConfigDir() As String

        Dim tempdir As String
        Dim g_Config_Dir As String
        tempdir = System.IO.Path.GetDirectoryName(System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath)
        Dim section As String() = Split(tempdir, "Configuration", , CompareMethod.Text)
        g_Config_Dir = section(0) & "StreamingDataLoader\1.2.1.1\"
        IO.Directory.CreateDirectory(g_Config_Dir)
        Return g_Config_Dir

    End Function

#Region " String Manipulation "

    ''' <summary>
    ''' Properly escapes ' for query strings
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FormatForDB(ByVal value As String) As String
        Dim formatted As String
        formatted = value.Replace("'", "''")

        Return formatted
    End Function

    ''' <summary>
    ''' Splits a line of text at a delimiter, using " as text delimiters which prevent text containing the delimiter from being split.
    ''' <example>
    ''' "this, should, all, stay, together", this, "should", not 
    ''' when split using , as a delimiter will return
    ''' 1   this, should, all, stay, together
    ''' 2   this
    ''' 3   should
    ''' 4   not
    ''' </example> 
    ''' </summary>
    ''' <param name="line">a line of text from the file</param>
    ''' <param name="delimiter">usually ',' for CSV files</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ProcessLine(ByVal line As String, ByVal delimiter As String) As String()
        Dim str() As String = {}
        If (line <> "") Then
            delimiter = System.Text.RegularExpressions.Regex.Escape(delimiter)
            Dim patt As String = _
                "(?m)^((?("")""(?<quote>)|(?<=(^|" & delimiter & ")))(?<field>(?(quote)(""""|[^""]|""(?!" & delimiter & "))|[^" & delimiter & "])*?)(?(quote)""(?<-quote>))(?($)|" & delimiter & "))+"


            Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(line, patt)

            With m.Groups("field")
                ReDim str(.Captures.Count)
                For i As Integer = 0 To (.Captures.Count - 1)
                    str(i) &= .Captures(i).Value
                Next i
            End With
        End If
        Return str
    End Function

#End Region

End Module
