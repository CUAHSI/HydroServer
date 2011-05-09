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
    <Security.Permissions.SecurityPermission(Security.Permissions.SecurityAction.Demand)> _
   Public Overrides Sub Commit(ByVal savedState As _
     System.Collections.IDictionary)

        MyBase.Commit(savedState)
        System.Diagnostics.Process.Start("http://www.microsoft.com")


    End Sub

    Protected Overrides Sub OnAfterInstall(ByVal savedState As System.Collections.IDictionary)
        MyBase.OnAfterInstall(savedState)
        SetEnvVariable()
    End Sub

    
    Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)
        MyBase.Install(stateSaver)

        'SetEnvVariable()
        'SetEnvVariable()
    End Sub


    Private Sub SetEnvVariable()

        Dim objEv As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_Environment")
        For Each objMgmt As ManagementObject In objEv.Get
            If objMgmt("Name") = "Path" And objMgmt("UserName") = "<SYSTEM>" Then
                Dim strPath As String = objMgmt("VariableValue")
                'If strPath.ToLower.IndexOf("cvsnt") >= 0 Then
                If objMgmt("VariableValue").ToString.Substring(objMgmt("VariableValue").ToString.Length - 1) = ";" Then
                    objMgmt("VariableValue") = objMgmt("VariableValue") + Trim(Me.Context.Parameters("targ") + "ODMLoader.exe") + ";"
                Else
                    objMgmt("VariableValue") = objMgmt("VariableValue") + ";" + Trim(Me.Context.Parameters("targ") + "ODMLoader.exe") + ";"
                End If
                'End If
                objMgmt.Put()
                ' MessageBox.Show("Path Added Successfully")
                Exit Sub
            End If
        Next
    End Sub




End Class
