'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Module CommonSubroutines
    'Last Documented 4/4/07

    Public Enum CVType
        CensorCode = 0
        DataType = 1
        GeneralCategory = 2
        SampleMedium = 3
        SampleType = 4
        TopicCategory = 5
        ValueType = 6
        VariableName = 7
        VerticalDatum = 8
        'QCLevel = _
        Speciation = 9
        SpatialRef = 10
        Unit = 11
    End Enum

    Public Sub ShowError(ByVal errorMessage As String, Optional ByVal err As Exception = Nothing, Optional ByVal style As MsgBoxStyle = MsgBoxStyle.Critical)
        'Displays an error message to the user with the name of the function where the error occured and the error message
        'Inputs:  funcName -> the name of the function where the error occurred
        '         errorMessage -> the message to display
        'Outputs: Displays a messagebox to the user

        'show the error message
        Dim message As String = errorMessage
        If Not (err Is Nothing) Then
            message &= vbCrLf & err.Message
#If DEBUG Then
            message &= vbCrLf & err.StackTrace
#End If
        End If


        MsgBox(message & vbCrLf, style, "CV Update Error")
    End Sub
End Module
