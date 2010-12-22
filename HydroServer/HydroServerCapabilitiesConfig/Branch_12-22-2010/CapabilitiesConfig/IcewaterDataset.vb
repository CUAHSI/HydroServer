Imports System.Data
Imports System.Data.SqlClient

Public Class IcewaterDataset
    Public ds As DataSet
    Private conn As SqlClient.SqlConnection

    Private RegionsAdapt As SqlDataAdapter
    Private ODMDatabasesAdapt As SqlDataAdapter
    Private MapsAdapt As SqlDataAdapter
    Private ContactsAdapt As SqlDataAdapter
    Private MapServersAdapt As SqlDataAdapter
    Private MapServerTypeAdapt As SqlDataAdapter

    Private RegionDatabasesAdapt As SqlDataAdapter
    Private RegionMapsAdapt As SqlDataAdapter

    Private MapMetaAdapt As SqlDataAdapter
    Private MapServerMetaAdapt As SqlDataAdapter
    Private ODMDatabaseMetaAdapt As SqlDataAdapter
    Private RegionMetadata As SqlDataAdapter


    Public Sub New(ByVal Connection As SqlConnection)
        conn = Connection
        Initialize()
    End Sub
    Public Sub New(ByVal ConnectionString As String)
        conn = New SqlConnection(ConnectionString)
        Initialize()
    End Sub

    Private Sub Initialize()
        ds = New DataSet("IcewaterDatabase")

        ds.BeginInit()

        RegionsAdapt = New SqlDataAdapter("SELECT * FROM Regions", conn)
        RegionsAdapt.Fill(ds, "Regions")

        ODMDatabasesAdapt = New SqlDataAdapter("SELECT * FROM ODMDatabases", conn)
        ODMDatabasesAdapt.Fill(ds, "ODMDatabases")

        MapsAdapt = New SqlDataAdapter("SELECT * FROM Maps", conn)
        MapsAdapt.Fill(ds, "Maps")

        ContactsAdapt = New SqlDataAdapter("SELECT * FROM Contacts", conn)
        ContactsAdapt.Fill(ds, "Contacts")

        MapServersAdapt = New SqlDataAdapter("SELECT * FROM MapServers", conn)
        MapServersAdapt.Fill(ds, "MapServers")

        MapServerTypeAdapt = New SqlDataAdapter("SELECT * FROM MapServerTypeCV", conn)
        MapServerTypeAdapt.Fill(ds, "MapServerTypeCV")

        ds.EndInit()
    End Sub

    Public Sub CommitContacts()
        Dim builder As New SqlCommandBuilder(ContactsAdapt)
        ContactsAdapt.Update(ds, "Contacts")
        ContactsAdapt.Fill(ds, "Contacts")
        MsgBox("TEXT")
    End Sub


End Class
