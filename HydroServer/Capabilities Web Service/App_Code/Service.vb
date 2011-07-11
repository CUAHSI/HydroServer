Imports System.Data
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml
Imports Database

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://his.cuahsi.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class HydroServerCapabilities
    Inherits System.Web.Services.WebService
#Region " SQL Constants "
    Public Const ContactsSQL As String = _
    "SELECT Contacts.ContactID, FirstName, LastName, OrganizationName, MailingAddress, City, Area, Country, PostalCode, FaxNumber, PhoneNumber, EmailAddress FROM Contacts"
    Public Const MapServerMetadataSQL As String = _
    "SELECT MapServerMetadata.MapServerID, MetadataTitle, MetadataContent, DisplayOrder FROM MapServerMetadata"
    Public Const MapServersSQL As String = _
    "SELECT MapServers.MapServerID, MapServerName, ConnectionURL, MapServerType, Domain, Username, Password FROM MapServers"
    Public Const MapServiceMetadataSQL As String = _
    "SELECT MapServiceMetadata.MapServiceID, MetadataTitle, MetadataContent, DisplayOrder FROM MapServiceMetadata"
    Public Const MapServicesSQL As String = _
    "SELECT MapServices.MapServiceID, Title, MapConnection, MapServerID, ReferenceDate, NorthExtent, EastExtent, SouthExtent, WestExtent, TopicCategory, Abstract, MetadataContactID, DatasetContactID, SpatialResolution, DistributionFormat, SpatialRepresentationType, SpatialReferenceSystem, LineageStatement, OnlineResource FROM MapServices"
    Public Const ODMDatabaseMetadataSQL As String = _
    "SELECT ODMDatabaseMetadata.DatabaseID as WaterOneFlowServiceID, MetadataTitle, MetadataContent, DisplayOrder FROM ODMDatabaseMetadata"
    Public Const ODMDatabasesSQL As String = _
    "SELECT ODMDatabases.DatabaseID as WaterOneFlowServiceID, Title, MapMarkerURL, ReferenceDate, NorthExtent, SouthExtent, EastExtent, WestExtent, SpatialReferenceSystem, TopicCategory, Abstract, Citation, MetadataContactID, DatasetContactID, LineageStatement, WaterOneFlowWSDL FROM ODMDatabases"
    Public Const RegionDatabasesSQL As String = _
    "SELECT RegionDatabases.RegionID, DatabaseID as WaterOneFlowServiceID, DisplayOrder, DisplayName FROM RegionDatabases"
    Public Const RegionMapServicesSQL As String = _
    "SELECT RegionMapServices.RegionID, MapServiceID, DisplayOrder, DisplayName, TransparencyPercent, IsVisible, IsTOC, IsBaseMapService FROM RegionMapServices"
    Public Const RegionMetadataSQL As String = _
    "SELECT RegionMetadata.RegionID, MetadataTitle, MetadataContent, DisplayOrder FROM RegionMetadata"
    Public Const RegionsSQL As String = _
    "SELECT Regions.RegionID, RegionName, RegionTitle, NorthExtent, SouthExtent, EastExtent, WestExtent, RegionDescription, RegionMapCSSURL FROM Regions"
#End Region ' SQL Contants

#Region " Web Service Methods "

    ''' <summary>
    ''' Retrieves all Regions
    ''' </summary>
    ''' <returns>XML Formatted string containing information about all regions</returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="This method returns a string (formatted as XML) with a list of all of the study regions for which data have been published.")> _
    Public Function GetRegions() As String
        Dim doc As New XmlDocument

        'Dim Result As New Text.StringBuilder
        Dim objDataTable As DataTable
        'Dim objDataRow As DataRow
        'Dim ElementName As String

        'Get the metadata for published services from the database
        objDataTable = OpenTable(RegionsSQL & " ORDER BY RegionID ASC")

        'Create the result string
        Dim root As XmlNode = doc.AppendChild(doc.CreateElement("GetRegionsResponse"))
        'Result.Append("<GetRegionsResponse>")

        root.AppendChild(WriteTableToXML(objDataTable, doc, "RegionID", "RegionID"))

        'Return Result.ToString
        Return root.OuterXml
    End Function

    ''' <summary>
    ''' Retrieves a single Region with the provided RegionID
    ''' </summary>
    ''' <param name="RegionID">The ID of the Region you are interested in.</param>
    ''' <returns>XML formatted string containing the Region with the provided RegionID</returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the metadata for that region.")> _
    Public Function GetRegionInfo(ByVal RegionID As Integer) As String
        Dim doc As New XmlDocument
        Dim objDataTable As DataTable
        Dim objMetaTable As DataTable

        'Get the metadata for published services from the database
        objDataTable = OpenTable(RegionsSQL & " WHERE RegionID = '" & RegionID & "'")
        objMetaTable = OpenTable(RegionMetadataSQL & " WHERE RegionID = '" & RegionID & "' ORDER BY DisplayOrder ASC")

        'Create the result string
        Dim root As XmlNode = doc.AppendChild(doc.CreateElement("GetRegionInfoResponse"))

        Dim records As XmlElement = root.AppendChild(WriteTableToXML(objDataTable, doc, "RegionID", "RegionID"))
        LinkMetadataToXML(objMetaTable, "RegionID", records, doc)

        Return root.OuterXml
    End Function

    ''' <summary>
    ''' Retrieves all RegionSpatialServices with the provided RegionID
    ''' </summary>
    ''' <param name="RegionID">ID of the Region you are interested in</param>
    ''' <returns>XML formatted string containing all RegionSpatialServices with the provided RegionID</returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="Given the ID for a study region, this method returns a string (formatted as XML) with a list of all of the spatial data services associated with that region.")> _
    Public Function GetRegionMapServices(ByVal RegionID As String) As String
        Dim doc As New XmlDocument

        Dim objDataTable As DataTable

        'Get the metadata for published services from the database
        objDataTable = OpenTable(RegionMapServicesSQL & " WHERE RegionID = '" & RegionID & "' ORDER BY DisplayOrder ASC")

        'Create the result string
        Dim root As XmlNode = doc.AppendChild(doc.CreateElement("GetRegionMapServicesResponse"))

        root.AppendChild(WriteTableToXML(objDataTable, doc, "MapServiceID", "MapServiceID"))

        Return root.OuterXml
    End Function

    ''' <summary>
    ''' Retrieves all RegionWOFServices with the provided RegionID
    ''' </summary>
    ''' <param name="RegionID">ID of the Region you are interested in</param>
    ''' <returns>XML formatted string containing all RegionWOFServices with the provided RegionID</returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="Given the ID for a study region, this method returns a string (formatted as XML) with a list of all of the WaterOneFlow data services associated with that region.")> _
    Public Function GetRegionWaterOneFlowServices(ByVal RegionID As String) As String
        Dim doc As New XmlDocument

        Dim objDataTable As DataTable

        'Get the metadata for published services from the database
        objDataTable = OpenTable(RegionDatabasesSQL & " WHERE RegionID = '" & RegionID & "' ORDER BY DisplayOrder ASC")

        'Create the result string
        Dim root As XmlNode = doc.AppendChild(doc.CreateElement("GetRegionWaterOneFlowServicesResponse"))

        root.AppendChild(WriteTableToXML(objDataTable, doc, "WaterOneFlowServiceID", "WaterOneFlowServiceID"))

        Return root.OuterXml
    End Function

    ''' <summary>
    ''' Retrieves all SpatialServices
    ''' </summary>
    ''' <returns>XML formatted string containing all SpatialServices</returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the metadata for published spatial data services.")> _
      Public Function GetMapServices() As String
        Dim doc As New XmlDocument

        Dim objDataTable As DataTable
        Dim objMapServers As DataTable
        Dim objContacts As DataTable
        'Get the metadata for published services from the database
        objDataTable = OpenTable(MapServicesSQL & " ORDER BY MapServiceID ASC")
        objMapServers = OpenTable(MapServersSQL & " ORDER BY MapServerID ASC")
        objContacts = OpenTable(ContactsSQL & " ORDER BY ContactID ASC")

        'Create the result string
        Dim root As XmlNode = doc.AppendChild(doc.CreateElement("GetMapServicesResponse"))

        Dim records As XmlElement = root.AppendChild(WriteTableToXML(objDataTable, doc, "MapServiceID", "MapServiceID"))
        LinkTableToXML(objMapServers, "MapServerID", "MapServerID", "MapServer", records, doc)
        LinkTableToXML(objContacts, "MetadataContactID", "ContactID", "MetadataContact", records, doc)
        LinkTableToXML(objContacts, "DatasetContactID", "ContactID", "DatasetContact", records, doc)
        Return root.OuterXml
    End Function

    ''' <summary>
    ''' Retrieves a single Spatialservice with the provided SpatialServiceID
    ''' </summary>
    ''' <param name="MapServiceID">The ID of the SpatialService you are interested in.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="Given the ID for a spatial data service, this method returns a string (formatted as XML) with all of the metadata for that spatial data service.")> _
      Public Function GetMapServiceInfo(ByVal MapServiceID As Integer) As String
        Dim doc As New XmlDocument

        Dim objDataTable As DataTable
        Dim objMapServers As DataTable
        Dim objContacts As DataTable
        Dim objMetaTable As DataTable
        Dim objServerMetaTable As DataTable
        'Get the metadata for published services from the database
        objDataTable = OpenTable(MapServicesSQL & " WHERE MapServiceID = '" & MapServiceID & "'")
        objMapServers = OpenTable(MapServersSQL & " LEFT JOIN MapServices ON MapServers.MapServerID = MapServices.MapServerID WHERE MapServiceID = '" & MapServiceID & "' ORDER BY MapServers.MapServerID ASC")
        objContacts = OpenTable(ContactsSQL & " ORDER BY ContactID ASC")
        objMetaTable = OpenTable(MapServiceMetadataSQL & " WHERE MapServiceID = '" & MapServiceID & "' ORDER BY DisplayOrder ASC")
        objServerMetaTable = OpenTable(MapServerMetadataSQL & " LEFT JOIN MapServices ON MapServerMetadata.MapServerID = MapServices.MapServerID WHERE MapServiceID = '" & MapServiceID & "' ORDER BY MapServerMetadata.MapServerID ASC")
        'Create the result string
        Dim root As XmlNode = doc.AppendChild(doc.CreateElement("GetMapServiceInfoResponse"))

        Dim records As XmlElement = root.AppendChild(WriteTableToXML(objDataTable, doc, "MapServiceID", "MapServiceID"))
        LinkTableToXML(objMapServers, "MapServerID", "MapServerID", "MapServer", records, doc)
        LinkTableToXML(objContacts, "MetadataContactID", "ContactID", "MetadataContact", records, doc)
        LinkTableToXML(objContacts, "DatasetContactID", "ContactID", "DatasetContact", records, doc)
        LinkMetadataToXML(objMetaTable, "MapServiceID", records, doc)
        Return root.OuterXml
    End Function

    ''' <summary>
    ''' Retrieves all WaterOneFlowServices
    ''' </summary>
    ''' <returns>XML formatted string containing all WaterOneFlowServices</returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the metadata for published WaterOneFlow data services.")> _
      Public Function GetWaterOneFlowServices() As String
        Dim doc As New XmlDocument

        Dim objDataTable As DataTable
        Dim objContacts As DataTable
        'Get the metadata for published services from the database
        objDataTable = OpenTable(ODMDatabasesSQL & " ORDER BY DatabaseID ASC")
        objContacts = OpenTable(ContactsSQL & " ORDER BY ContactID ASC")

        'Create the result string
        Dim root As XmlNode = doc.AppendChild(doc.CreateElement("GetWaterOneFlowServicesResponse"))

        Dim records As XmlElement = root.AppendChild(WriteTableToXML(objDataTable, doc, "WaterOneFlowServiceID", "WaterOneFlowServiceID"))
        LinkTableToXML(objContacts, "MetadataContactID", "ContactID", "MetadataContact", records, doc)
        LinkTableToXML(objContacts, "DatasetContactID", "ContactID", "DatasetContact", records, doc)
        Return root.OuterXml
    End Function

    ''' <summary>
    ''' Retrieves as single WaterOneFlowService with the provided WaterOneFlowServiceID
    ''' </summary>
    ''' <param name="WaterOneFlowServiceID">The ID of the WaterOneFlowService you are interested in.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="Given the ID for a WaterOneFlow data service, this method returns a string (formatted as XML) with all of the metadata for that WaterOneFlow data service.")> _
     Public Function GetWaterOneFlowServiceInfo(ByVal WaterOneFlowServiceID As Integer) As String
        Dim doc As New XmlDocument

        Dim objDataTable As DataTable
        Dim objContacts As DataTable
        Dim objMetaTable As DataTable

        'Get the metadata for published services from the database
        objDataTable = OpenTable(ODMDatabasesSQL & " Where DatabaseID = '" & WaterOneFlowServiceID & "'")
        objContacts = OpenTable(ContactsSQL & " ORDER BY ContactID ASC")
        objMetaTable = OpenTable(ODMDatabaseMetadataSQL & " WHERE DatabaseID = '" & WaterOneFlowServiceID & "' ORDER BY DisplayOrder")

        'Create the result string
        Dim root As XmlNode = doc.AppendChild(doc.CreateElement("GetWaterOneFlowServiceInfoResponse"))

        Dim records As XmlElement = root.AppendChild(WriteTableToXML(objDataTable, doc, "WaterOneFlowServiceID", "WaterOneFlowServiceID"))
        LinkTableToXML(objContacts, "MetadataContactID", "ContactID", "MetadataContact", records, doc)
        LinkTableToXML(objContacts, "DatasetContactID", "ContactID", "DatasetContact", records, doc)
        LinkMetadataToXML(objMetaTable, "WaterOneFlowServiceID", records, doc)
        Return root.OuterXml
    End Function

    ''' <summary>
    ''' Converts a datatable into XML
    ''' </summary>
    ''' <param name="table"></param>
    ''' <param name="doc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function WriteTableToXML(ByVal table As DataTable, ByRef doc As XmlDocument, ByVal RecordIDColumn As String, ByVal RecordIDName As String) As XmlElement
        Dim records As XmlElement = doc.CreateElement("Records")
        Dim count As XmlAttribute = records.Attributes.Append(doc.CreateAttribute("count"))
        count.Value = table.Rows.Count

        For Each row As DataRow In table.Rows
            Dim record As XmlElement = records.AppendChild(doc.CreateElement("Record"))
            Dim RecordID As XmlAttribute = doc.CreateAttribute(RecordIDName)
            RecordID.Value = row.Item(RecordIDColumn)
            record.Attributes.Append(RecordID)
            For Each column As DataColumn In table.Columns
                Dim info As XmlElement = record.AppendChild(doc.CreateElement(column.ColumnName))
                info.InnerText = row.Item(column).ToString
            Next column
        Next row

        Return records
    End Function

    Private Sub LinkTableToXML(ByVal table As DataTable, ByVal linkingElementName As String, ByVal linkingColumnName As String, ByVal linkedElementName As String, ByRef Records As XmlElement, ByRef doc As XmlDocument)
        For Each Record As XmlElement In Records.ChildNodes
            Dim LinkColumn As XmlElement = Record.Item(linkingElementName)
            If Not (LinkColumn Is Nothing) Then
                Dim LinkElement As XmlElement = doc.CreateElement(linkedElementName)
                Dim rows() As DataRow = table.Select(linkingColumnName & " = '" & LinkColumn.InnerText & "'")

                If rows.Count > 0 Then
                    For Each column As DataColumn In table.Columns
                        Dim columnElement As XmlElement = doc.CreateElement(column.ColumnName)
                        columnElement.InnerText = rows(0).Item(column).ToString
                        LinkElement.AppendChild(columnElement)
                    Next column

                    Record.ReplaceChild(LinkElement, LinkColumn)
                End If
            End If
        Next Record
    End Sub

    Private Sub LinkMetadataToXML(ByVal Metadata As DataTable, ByVal linkColumnName As String, ByVal records As XmlElement, ByVal doc As XmlDocument)
        For Each Record As XmlElement In records.ChildNodes
            Dim LinkColumn As XmlElement = Record.Item(linkColumnName)
            If Not (LinkColumn Is Nothing) Then
                Dim MetadataElement As XmlElement = Record.AppendChild(doc.CreateElement("Metadata"))
                Dim rows() As DataRow = Metadata.Select(linkColumnName & " = '" & LinkColumn.InnerText & "'", "DisplayOrder ASC")

                Dim i As Integer = 1
                For Each row As DataRow In rows
                    Dim item As XmlElement = MetadataElement.AppendChild(doc.CreateElement("Item"))
                    Dim ID As XmlAttribute = item.Attributes.Append(doc.CreateAttribute("ID"))
                    ID.Value = i
                    i += 1
                    For Each column As DataColumn In Metadata.Columns
                        If LCase(column.ColumnName) <> LCase(linkColumnName) Then
                            If (LCase(column.ColumnName) <> "displayorder") Then
                                Dim columnElement As XmlElement = doc.CreateElement(column.ColumnName)
                                'columnElement.InnerText = rows(0).Item(column)
                                columnElement.InnerText = row.Item(column)
                                item.AppendChild(columnElement)
                            End If
                        End If
                    Next column
                    Record.AppendChild(MetadataElement)
                Next row
            End If
        Next Record
    End Sub
#End Region ' Web Service Methods

End Class
