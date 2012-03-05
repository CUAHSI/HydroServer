Imports System.ComponentModel
Imports System.Configuration.Install
Imports Microsoft.Win32
Imports System.Management

Public Class Installer1

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent

    End Sub

    Protected Overrides Sub OnAfterInstall(ByVal savedState As System.Collections.IDictionary)
        MyBase.OnAfterInstall(savedState)
        SetEnvVariable()
    End Sub

    Public Overrides Sub Uninstall(ByVal savedState As System.Collections.IDictionary)
        MyBase.Uninstall(savedState)
        removeEnvVariable()

    End Sub

    Private Sub removeEnvVariable()
        Dim objEv As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_Environment")
        Dim delstr As String()


        For Each objMgmt As ManagementObject In objEv.Get
            If objMgmt("Name") = "Path" And objMgmt("UserName") = "<SYSTEM>" Then
                Dim strPath As String = objMgmt("VariableValue")
                'If strPath.ToLower.IndexOf("cvsnt") >= 0 Then
                delstr = objMgmt("VariableValue").ToString.Split(";")
                If objMgmt("VariableValue").ToString.Contains("ODMLoader.exe") Then


                    For i As Integer = 0 To delstr.Length
                        If delstr(i).Contains("ODMLoader.exe") Then
                            delstr(i) = Nothing
                            Exit For
                        End If
                    Next

                End If
                objMgmt("VariableValue") = ""

                For j As Integer = 0 To delstr.Length - 1
                    If Not delstr(j) Is Nothing Then
                        objMgmt("VariableValue") = objMgmt("VariableValue") + delstr(j) + ";"
                    End If
                Next j

                'If objMgmt("VariableValue").ToString.Substring(objMgmt("VariableValue").ToString.Length - 1) = ";" Then
                '    objMgmt("VariableValue") = objMgmt("VariableValue") + Trim(Me.Context.Parameters("targ") + "ODMLoader.exe") + ";"
                'Else
                '    objMgmt("VariableValue") = objMgmt("VariableValue") + ";" + Trim(Me.Context.Parameters("targ") + "ODMLoader.exe") + ";"
                'End If
                'End If
                objMgmt.Put()
                ' MessageBox.Show("Path Added Successfully")
                Exit Sub
            End If
        Next objMgmt

    End Sub
    Private Sub SetEnvVariable()

        Dim objEv As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_Environment")
        For Each objMgmt As ManagementObject In objEv.Get
            If objMgmt("Name") = "Path" And objMgmt("UserName") = "<SYSTEM>" Then
                Dim strPath As String = objMgmt("VariableValue")
                'If strPath.ToLower.IndexOf("cvsnt") >= 0 Then
                If objMgmt("VariableValue").ToString.Substring(objMgmt("VariableValue").ToString.Length - 1) = ";" Then
                    objMgmt("VariableValue") = objMgmt("VariableValue") + Trim(Me.Context.Parameters("targ") + "ODMLoader.exe") + ";"
                    objMgmt.Put()
                Else
                    objMgmt("VariableValue") = objMgmt("VariableValue") + ";" + Trim(Me.Context.Parameters("targ") + "ODMLoader.exe") + ";"
                    objMgmt.Put()
                End If
                'End If

                Console.WriteLine(Me.Context.Parameters("targ"))
                Exit For
            End If
        Next
    End Sub


End Class
