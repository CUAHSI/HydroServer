Option Strict On
Imports System.Xml
Imports System.Data
Imports DatabaseFunctions

Public Class SessionFunctions
    Public Shared Sub Load(ByVal strNetworksPath As String)
        'Initialize networks
        Dim objNetworks As New SortedList
        Dim objXmlDocument As New XmlDocument
        Dim intNetworkCount As Integer
        Dim strNetworkID As String, strNetworkName As String, strDatabaseName, strDBConnection As String, strIcon As String
        Dim objVariables As SortedList
        Dim objVariableTable As DataTable
        Dim objVariableRow As DataRow
        Dim i As Integer

        objXmlDocument.Load(strNetworksPath)
        intNetworkCount = objXmlDocument.GetElementsByTagName("Network").Count

        For i = 0 To intNetworkCount - 1
            strNetworkID = objXmlDocument.GetElementsByTagName("Network").Item(i).ChildNodes.Item(0).InnerText
            strNetworkName = objXmlDocument.GetElementsByTagName("Network").Item(i).ChildNodes.Item(1).InnerText
            strDatabaseName = objXmlDocument.GetElementsByTagName("Network").Item(i).ChildNodes.Item(2).InnerText
            strDBConnection = objXmlDocument.GetElementsByTagName("Network").Item(i).ChildNodes.Item(3).InnerText
            strIcon = objXmlDocument.GetElementsByTagName("Network").Item(i).ChildNodes.Item(4).InnerText
            objVariables = New SortedList
            objVariableTable = OpenTable(strDBConnection, "SELECT DISTINCT VariableName FROM SeriesCatalog ORDER BY VariableName ASC")
            For Each objVariableRow In objVariableTable.Select()
                objVariables.Add(Convert.ToString(objVariableRow.Item("VariableName")), Convert.ToString(objVariableRow.Item("VariableName")))
            Next
            objVariables.TrimToSize()
            objNetworks.Add(strNetworkID, New clsNetwork(Convert.ToInt32(strNetworkID), strNetworkName, strDatabaseName, strDBConnection, strIcon, objVariables))
        Next

        objNetworks.TrimToSize()
        System.Web.HttpContext.Current.Session("Networks") = objNetworks
    End Sub
End Class
