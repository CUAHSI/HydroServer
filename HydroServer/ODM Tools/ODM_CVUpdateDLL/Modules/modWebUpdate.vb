'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Imports System.Xml

Module modWebUpdate

    Public Function XMLStringtoTable(ByVal strXML As String, Optional ByVal hasID As Boolean = False, Optional ByVal hasBool As Boolean = False) As DataTable
        'Converts an XML formatted table passed as a string into a DataTable.
        'Inputs:  strXML -> The XML String to convert to a dataTable
        '         hasID -> Determines whether the first column is an integer or a string.
        '         hasBool -> Determines whether columns with "true" or "false" are boolean or string
        'Outputs: the dataTable of data retrieved from the XML string

        Dim x, y As Integer 'Counter Variables
        Try
            Dim maxCol As Integer = 0
            Dim doc As New Xml.XmlDocument()
            doc.LoadXml(strXML)
            Dim node As Xml.XmlNode = doc.FirstChild
            Dim table As DataTable
            table = New DataTable(node.Name)
            node = node.FirstChild
            If (Not (node Is Nothing)) AndAlso (Not (node.FirstChild Is Nothing)) AndAlso (node.FirstChild.ChildNodes.Count > 0) Then
                For x = 0 To node.ChildNodes.Count - 1
                    If maxCol < node.ChildNodes(x).ChildNodes.Count Then
                        maxCol = node.ChildNodes(x).ChildNodes.Count
                    End If
                Next
                For y = 0 To maxCol - 1
                    table.Columns.Add()
                Next
                If hasID Then
                    table.Columns(0).DataType = System.Type.GetType("System.Int32")
                End If
                If hasBool Then
                    table.Columns(3).DataType = System.Type.GetType("System.Boolean")
                End If
                For x = 0 To node.ChildNodes.Count - 1
                    table.Rows.Add()
                    For y = 0 To node.ChildNodes(x).ChildNodes.Count - 1
                        If LCase(node.ChildNodes(x).ChildNodes(y).InnerText) = "true" Then
                            table.Rows(x).Item(y) = True
                        ElseIf LCase(node.ChildNodes(x).ChildNodes(y).InnerText) = "false" Then
                            table.Rows(x).Item(y) = False
                        ElseIf (node.ChildNodes(x).ChildNodes(y).InnerText = "") OrElse (node.ChildNodes(x).ChildNodes(y).InnerText = "NULL") Then
                            table.Rows(x).Item(y) = DBNull.Value
                        Else
                            table.Rows(x).Item(y) = node.ChildNodes(x).ChildNodes(y).InnerText
                        End If
                    Next
                Next
                Return table
            End If
        Catch ex As Exception
            ShowError("An error occurred reading the Web Servive.", ex)
        End Try
        'An error occurred
        Return Nothing
    End Function

End Module
