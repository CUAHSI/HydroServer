Imports System.Configuration

'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..

''' <summary>
''' Starting form of the wizard. 
''' Displays a list of all streaming data files listed in the configuration file
''' </summary>
''' <remarks></remarks>
Public Class frmODMSDLWizard
    'Last Documented 1/1/1

    ''' <summary>
    ''' True if there is currently an update running
    ''' </summary>
    ''' <remarks></remarks>
    Dim RunningUpdate As Boolean = False
    ''' <summary>
    ''' The background process to open the SDL to run an update
    ''' </summary>
    ''' <remarks></remarks>
    WithEvents proc As System.Diagnostics.Process

#Region " Form Functions "

    ''' <summary>
    ''' Enables/Disables buttons based on selection
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub dgvFiles_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFiles.SelectionChanged
        tsbEdit.Enabled = (dgvFiles.SelectedRows.Count > 0)
        tsbDelete.Enabled = (dgvFiles.SelectedRows.Count > 0)
        tsbRun.Enabled = ((dgvFiles.SelectedRows.Count > 0) And (Not RunningUpdate))
    End Sub

    ''' <summary>
    ''' Loads all necessary data and sets up the dgvFiles columns
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub frmDataImportWizard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dgvFiles.Columns.Clear()
            dgvFiles.Columns.Add(config_File_ID, "ID")
            dgvFiles.Columns(config_File_ID).ValueType = System.Type.GetType("System.Int32")
            dgvFiles.Columns.Add(config_File_Server, "Server Address")
            dgvFiles.Columns.Add(config_File_DB, "Database Name")
            dgvFiles.Columns.Add(config_File_Type, "File Location Type")
            dgvFiles.Columns.Add(config_File_Loc, "File Location")
            dgvFiles.Columns.Add(config_File_SchedPeriod, "Schedule Period")
            dgvFiles.Columns.Add(config_File_SchedOffset, "Schedule Begginning")
            dgvFiles.Columns.Add(config_File_Last, "Last Update")
            'g_EXE_Dir = System.IO.Path.GetDirectoryName(Me.GetType.Assembly.Location)

            Dim tempdir As String
            tempdir = System.IO.Path.GetDirectoryName(System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath)
            Dim section As String()
            'tempdir = section(0) '& section(1) & "\" & section(2) & "\" & section(3) & "\" & section(4) & "\" & section(5)
            section = Split(tempdir, "Configuration", , CompareMethod.Text)
            g_EXE_Dir = section(0) & "StreamingDataLoader\1.1.2\"
            IO.Directory.CreateDirectory(g_EXE_Dir)
            'Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)
            'config.SaveAs(g_EXE_Dir)

            LoadFileList()
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    Sub CreateDir(ByVal MyFolder As String)
        On Error Resume Next
        MkDir("\MyFolder")
    End Sub
#Region " Button Clicks "

    ''' <summary>
    ''' Adds a new file mapping
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click
        Try
            Dim newFile As New frmAddNewFile 'Dialog Box to create a new file mapping
            If newFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                LoadFileList()
            End If
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    ''' <summary>
    ''' edits an existing file mapping
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        '
        Try
            Dim x As Integer 'Counter Variable
            Dim nodeID As Integer 'The ID of the node to edit
            Dim xmlDoc As New System.Xml.XmlDocument 'The XML Document to edit
            Dim root As System.Xml.XmlNode 'The root node of the XML Document
            Dim node As System.Xml.XmlNode 'The current node in th XML Document
            If (System.IO.File.Exists(g_EXE_Dir & "\Config.xml")) Then
                xmlDoc.Load(g_EXE_Dir & "\Config.xml")
                root = xmlDoc.DocumentElement
                For x = 0 To (root.ChildNodes.Count - 1)
                    node = root.ChildNodes(x)
                    If (node.Attributes(config_File_ID).Value) = (dgvFiles.SelectedRows(0).Cells(config_File_ID).Value) Then
                        nodeID = x
                        Exit For
                    End If
                Next x
                node = root.ChildNodes(x)
                Dim newFile As New frmAddNewFile(node) 'Dialog Box to edit a file mapping XML node.
                If newFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    LoadFileList()
                    For x = 0 To (dgvFiles.Rows.Count - 1)
                        dgvFiles.Rows(x).Selected = False
                    Next
                End If
                'tsbDelete.Enabled = False
                'tsbEdit.Enabled = False
                'tsbRun.Enabled = False
            End If

        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    ''' <summary>
    ''' removes an existing file mapping
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click
        '
        Try
            RemoveFile()
            LoadFileList()
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    ''' <summary>
    ''' runs the selected file mappings
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub tsbRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRun.Click
        '
        Me.Cursor = Cursors.AppStarting
        Try
            tsbRun.Enabled = False
            Dim IDs As String = "-s" 'The IDs of the File Associations to run
            Dim i As Integer 'Counter Variable

            For i = 0 To (dgvFiles.SelectedRows.Count - 1)
                IDs = IDs & " " & dgvFiles.SelectedRows(i).Cells(config_File_ID).Value
            Next
            proc = Process.Start(g_EXE_Dir & "\ODMSDL.exe", IDs)
            tmrProc.Start()
            RunningUpdate = True
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Refreshes the list of files
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        LoadFileList()
    End Sub

#End Region

#End Region

#Region " Config File Functions "

    ''' <summary>
    ''' Loads the list of files from the XML Configuration File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadFileList()
        Try
            dgvFiles.Rows.Clear()
            Dim i As Integer 'Counter Variable
            Dim xmlDoc As New System.Xml.XmlDocument 'The XML Document to load
            Dim root As System.Xml.XmlNode 'The Root Node of the XML Document
            Dim node As System.Xml.XmlNode 'The current node within the XML Document

            If (System.IO.File.Exists(g_EXE_Dir & "\Config.xml")) Then
                xmlDoc.Load(g_EXE_Dir & "\Config.xml")
                root = xmlDoc.DocumentElement
                For i = 0 To (root.ChildNodes.Count - 1)
                    node = root.ChildNodes(i)
                    dgvFiles.Rows.Add(New Object() {Val(node.Attributes(config_File_ID).Value), node.Item(config_File_Server).InnerText, node.Item(config_File_DB).InnerText, node.Item(config_File_Type).InnerText, node.Item(config_File_Loc).InnerText, node.Item(config_File_SchedPeriod).InnerText, node.Item(config_File_SchedOffset).InnerText, node.Item(config_File_Last).InnerText})
                Next
            End If
            'dgvFiles.Sort(dgvFiles.Columns(config_File_ID), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    ''' <summary>
    ''' Removes a file from the XML Configuration File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveFile()
        Try
            Dim i As Integer 'Counter Variable
            Dim xmlDoc As New System.Xml.XmlDocument 'The XML Document to Change
            Dim root As System.Xml.XmlNode 'The root node of the XML Document
            Dim node As System.Xml.XmlNode 'The current node within the XML Document
            If (System.IO.File.Exists(g_EXE_Dir & "\Config.xml")) Then
                xmlDoc.Load(g_EXE_Dir & "\Config.xml")
                root = xmlDoc.DocumentElement
                While (i < root.ChildNodes.Count)
                    node = root.ChildNodes(i)
                    If (node.Attributes(config_File_ID).Value) = (dgvFiles.SelectedRows(0).Cells(config_File_ID).Value) Then
                        root.RemoveChild(node)
                    Else
                        i += 1
                    End If
                End While
            End If
            xmlDoc.Save(g_EXE_Dir & "\Config.xml")
        Catch ex As Exception
            ShowError(ex)
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

#End Region

    ''' <summary>
    ''' Closes the program
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Close()
    End Sub

    ''' <summary>
    ''' Displays the About dialog
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        Dim temp As New frmAbout
        temp.ShowDialog()
    End Sub

    ''' <summary>
    ''' Check whether the SDL background process is complete
    ''' </summary>
    ''' <param name="sender">Visual Studio Required Parameter</param>
    ''' <param name="e">Visual Studio Required Parameter</param>
    ''' <remarks></remarks>
    Private Sub tmrProc_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrProc.Tick
        If proc.HasExited Then
            tmrProc.Stop()
            RunningUpdate = False
            tsbRun.Enabled = True
        End If
    End Sub
End Class