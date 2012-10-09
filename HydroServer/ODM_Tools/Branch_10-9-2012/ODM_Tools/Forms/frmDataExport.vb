'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Imports System.Windows.Forms
'Last Docuemented 5/15/07

Public Class frmDataExport

#Region " Member Variables "
    Dim m_queryString As String 'Used for Data Export
    Dim m_fileName As String    'Where the export file is stored
    Dim m_exportSeriesID() As Integer   'The Series' IDs to Export
    Dim m_delimiter As String 'Delimiter used in the MyDB Export

    Dim backThread As New Threading.Thread(AddressOf exportDataThread) 'Process thread used to export the data in the background
#End Region

#Region " Form Functionality "

    Public Sub New(ByVal e_queryString As String, ByVal e_fileName As String, ByVal e_exportSeriesID() As Integer, ByVal e_delimiter As String)
        'Retrieves Export Information from parent form
        'Input:  e_queryString -> The Query String to retrieve the Data to Export
        '       e_fileName ->  The Filename to store the data
        '       e_exportSeriesID() -> The SeriesIDs for the data
        '       e_delimiter -> The delimiter used to save the data

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_queryString = e_queryString
        m_fileName = e_fileName
        m_exportSeriesID = e_exportSeriesID
        m_delimiter = e_delimiter
    End Sub

    Private Sub frmDataExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Begins the data export
        backThread.Priority = Threading.ThreadPriority.AboveNormal
        backThread.Start()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'In case user wishes to abort
        'Output:    returns DialogResult.Cancel
        backThread.Abort()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

#End Region

#Region " Exporting Functionality "

    Private Sub exportDataThread()
        'Exports the data then closes the form when done/error
        'Output:    Writes the data to m_filename

        If ExportData(m_queryString, m_fileName, m_exportSeriesID, m_delimiter) Then
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        Else
            Me.DialogResult = Windows.Forms.DialogResult.No
        End If
    End Sub

#End Region

End Class
