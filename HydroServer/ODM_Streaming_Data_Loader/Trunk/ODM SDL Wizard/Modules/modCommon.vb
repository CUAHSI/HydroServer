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
    'Last Documented 9/4/07

#Region " Constants "

    ''' <summary>
    ''' Regex. Is valid only if the value is a number.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const g_Pattern_NumericExpression As String = "(^-?\d{1,}\.$)|(^-?\d{1,}$)|(^-?\d{0,}\.\d{1,}$)"
    ''' <summary>
    ''' Regex. Is invalid if the text contains anything other than alphanumeric characters, ., -, or _
    ''' </summary>
    ''' <remarks></remarks>
    Public Const g_Pattern_SiteVarCode As String = "[^A-Za-z0-9\.\-_]"
    ''' <summary>
    ''' Regex. Is valid only if the ODM specifications are met. Does not allow special characters.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const g_Pattern_ShortText As String = "[\a\b\e\f\n\r\t\v]"

#End Region

#Region " Global Variables "

    ''' <summary>
    ''' The filepath of the folder where the executables are located.  
    ''' </summary>
    ''' <remarks></remarks>
    Public g_EXE_Dir As String
    Public g_Config_Dir As String

#End Region

#Region " Error Functionality "

    ''' <summary>
    ''' Displays an error message to the user with the name of the function where the error occured and the error message
    ''' </summary>
    ''' <param name="ex">The exception that describes the error</param>
    ''' <remarks>Displays a messagebox to the user</remarks>
    Public Sub ShowError(ByVal ex As Exception)
        MsgBox("An Error occurred in " & ex.Source & vbCrLf & "Message = " & ex.Message)
    End Sub

    ''' <summary>
    ''' Displays an error message to the user with the name of the function where the error occured and the error message
    ''' </summary>
    ''' <param name="errorMessage">A message describing the error</param>
    ''' <remarks>Displays a messagebox to the user</remarks>
    Public Sub ShowError(ByVal errorMessage As String)
        MsgBox(errorMessage)
    End Sub

#End Region

#Region " String Manipulation "

    ''' <summary>
    ''' Properly escapes ' for query strings
    ''' </summary>
    ''' <param name="value">A string value to use as a parameter in a query</param>
    ''' <returns>A string value to use as a parameter in a SQL Query</returns>
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
    ''' <returns>The array of split strings</returns>
    ''' <remarks></remarks>
    Public Function ProcessLine(ByVal line As String, ByVal delimiter As String) As String()
        Dim str() As String = {}
        If (line <> "") Then
            delimiter = System.Text.RegularExpressions.Regex.Escape(delimiter)
            Dim patt As String = _
                "(?m)^((?("")""(?<quote>)|(?<=(^|" & delimiter & ")))(?<field>(?(quote)(""""|[^""]|""(?!" & delimiter & "))|[^" & delimiter & "])*?)(?(quote)""(?<-quote>))(?($)|" & delimiter & "))+"


            Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(line, patt)

            With m.Groups("field")
                ReDim str(.Captures.Count - 1)
                For i As Integer = 0 To (.Captures.Count - 1)
                    str(i) &= .Captures(i).Value
                Next i
            End With
        End If
        Return str
    End Function

#End Region

    Public Function getConfigDir() As String

        Dim tempdir As String
        Dim g_Config_Dir As String
        tempdir = System.IO.Path.GetDirectoryName(System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath)
        Dim section As String() = Split(tempdir, "Configuration", , CompareMethod.Text)
        g_Config_Dir = section(0) & "StreamingDataLoader\1.1.3.3\"
        IO.Directory.CreateDirectory(g_Config_Dir)
        Return g_Config_Dir

    End Function

End Module
