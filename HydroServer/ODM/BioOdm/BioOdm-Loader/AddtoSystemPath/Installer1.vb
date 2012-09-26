Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Diagnostics

Public Class Installer1

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent

    End Sub

    <Security.Permissions.SecurityPermission(Security.Permissions.SecurityAction.Demand)> _
    Public Overrides Sub Commit(ByVal savedState As System.Collections.IDictionary)
        MyBase.Commit(savedState)
        System.Diagnostics.Process.Start("http://www.microsoft.com")
    End Sub
End Class
