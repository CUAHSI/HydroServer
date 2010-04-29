'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Module CommonSubroutines
    'Last Documented 5/15/07

#Region " Global Variables "

    Public Const g_RegularExpressionPatern As String = "[\[\]\%\*]" 'Used by System.Text.RegularExpressions.Regex to check if input is valid sql expression
	Public Const g_NumericExpressionPatern As String = "[^.1234567890+/-]" 'Used by System.Text.RegularExpressions.Regex to check if input is valid numerical expression
	Public Const g_DeriveMethod_Smooth As String = "Smoothing Algorithm"
	Public Const g_DeriveMethod_Aggregate As String = "Daily Aggregate Functions"
	Public Const g_DeriveMethod_Algebraic As String = "Algebraic Equation"
	Public g_FProgress As frmProgress


#End Region

#Region " Error Reporting Functionality "

    Public Sub ShowError(ByVal errorMessage As String, Optional ByVal ex As Exception = Nothing) ', Optional ByVal style As MsgBoxStyle = MsgBoxStyle.Critical)
        'Displays an error message to the user with the name of the function where the error occured and the error message
        'Inputs:  funcName -> the name of the function where the error occurred
        '         errorMessage -> the message to display
        'Outputs: Displays a messagebox to the user

        'show the error message
        If ex Is Nothing Then
            MsgBox(errorMessage, MsgBoxStyle.Critical, "ODM Tools")
        Else
            Dim message As String = ex.Message
#If DEBUG Then
            message &= vbCrLf & ex.StackTrace
#End If
            MsgBox(errorMessage & vbCrLf & message, MsgBoxStyle.Critical, "ODM Tools")
        End If
        'MsgBox(errorMessage & vbCrLf & ex.StackTrace, style, "ODM Tools")
    End Sub

#End Region

#Region " Database Functionality "

    Public Function ValidQueryText(ByVal entry As String) As Boolean
        'Checks if the input is valid TEXT input for a query
        'Input:     Entry -> The input string 
        'Output:    If Entry has only valid Chars return true
        Dim check As New System.Text.RegularExpressions.Regex(g_RegularExpressionPatern) 'Checks to see if the the entry matches the specified patern
        If entry = "*" Then
            Return True
        End If
        Return (Not check.IsMatch(entry))
    End Function

    Public Function FixSQL(ByVal e_SQL As String) As String
        'Removes bad sql symbols
        'Input:  UnChecked SQL Command String
        'Output: Returns the Corrected SQL Command String
        Dim temp As String 'Corrected SQL String
        If e_SQL = "*" Then
            Return e_SQL
        End If
        temp = System.Text.RegularExpressions.Regex.Replace(e_SQL, g_RegularExpressionPatern, "")
        Return Replace(temp, "'", "''")
    End Function

#End Region

#Region " String Manipulation Functionality "

    Public Function SplitMultipleEntries(ByVal inputString As String) As String()
        'Splits entries separated by "; "
        'Input:     InputString -> the user input to separate into individual entries
        'Output:    Entries() -> An array of the seperated entries
        Dim entries() As String 'Splits semicolon separated values into separate values in a string array
        'ShortenedEntries = InputString
        '        b = Split(ShortenedEntries, "; ")
        'OR
        entries = Split(inputString, "; ")
        Return entries
    End Function

    Public Function GetStringLen(ByVal s As String) As Integer
        'calculates the the length of the string s in pixels
        'Inputs:  s -> the string to find the length of
        'Outputs: Integer -> the length of the string s in pixels
        Dim l As New Label   'used to find the length of the string in pixels
        l.Text = s
        l.AutoSize = True
        Return l.Width
    End Function

    Public Function GetStringLen(ByVal s As String, ByVal stringFormat As Font) As Integer
        'calculates the the length of the string s in pixels
        'Inputs:  s -> the string to find the length of
        'Outputs: Integer -> the length of the string s in pixels
        Dim l As New Label   'used to find the length of the string in pixels
        'l.Height = 13
        'l.Width = 100
        l.Text = s
        l.Font = stringFormat
        l.AutoSize = True
        Return l.PreferredWidth
    End Function

    Public Function GraphTitleBreaks(ByVal s As String) As String
        Dim offset As Integer
        For offset = 0 To ((s.Length - 1) \ 2)
            If (((s.Length - 1) \ 2) - offset) > 0 AndAlso (s(((s.Length - 1) \ 2) - offset) = " ") Then
                Return s.Substring(0, (((s.Length - 1) \ 2) - offset)) & vbCrLf & s.Substring(((s.Length - 1) \ 2) - offset)
            ElseIf (((s.Length) \ 2) + offset) > 0 AndAlso (s(((s.Length) \ 2) + offset) = " ") Then
                Return s.Substring(0, ((s.Length \ 2) + offset)) & vbCrLf & s.Substring((s.Length \ 2) + offset)
            End If
        Next offset
        Return (s.Substring(0, (((s.Length - 1) \ 2))) & vbCrLf & s.Substring(((s.Length - 1) \ 2)))
    End Function

#End Region

#Region " Conversion Functionality "

    Public Function ConvertMinutesToDays(ByVal minVal As Double) As Double
        'This function converts a given value from minutes into days
        'Inputs:  value to convert (in minutes)
        'Outputs: value converted to days
        Dim dayVal As Double = 0 'converted value -> return value
        Dim hourVal As Double = 0 'intermedian value -> used to calculate final value
        Try
            '1. Convert minutes -> hours
            hourVal = minVal / 60 'there are 60 minutes in 1 hour

            '2. convert hours -> days
            dayVal = hourVal / 24 'there are 24 hours in 1 day

            '3. return the calculated value
            Return dayVal
        Catch ex As Exception
            ShowError("An Error occurred while converting the given value from minutes into days." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
        'errors occurred above, return 0
        Return 0
    End Function

#End Region

End Module
