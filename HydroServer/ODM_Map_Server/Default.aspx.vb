Option Strict On
Imports System.Xml
Imports System.Data
Imports DatabaseFunctions

Partial Class _Default
    Inherits System.Web.UI.Page

    Private mobjNetworks As SortedList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strNetworksPath As String
        'strNetworksPath = Me.Page.MapPath("bin") & "\Networks.xml"
        strNetworksPath = Me.Page.MapPath("App_Data") & "\Networks.xml"
        If Session("Networks") Is Nothing Then
            'Refresh the session
            Session.Clear()
            SessionFunctions.Load(strNetworksPath)
        End If

        If Request.UserHostAddress = "127.0.0.1" Then 'Request from the localhost
            ltlMaps.Text = "<script src=""http://maps.google.com/maps?file=api&v=2;&key=ABQIAAAAqDXqSq472xFWgkbKasg44BQs8u-UdKdxhZZWKfbbdRG1NjAJChQF1KtY9U7N19uCJcEc9rpBu-nXjw"" type=""text/javascript""></script>"
        Else
            ltlMaps.Text = "<script src=""http://maps.google.com/maps?file=api&v=2;&key=ABQIAAAAqDXqSq472xFWgkbKasg44BSTNIMltmWs3yQcKby0sd43XLUGcxRDWViYcyDTeYDKKxRDUJTB6eHylw"" type=""text/javascript""></script>"
        End If

        'Bind session objects
        mobjNetworks = CType(Session("Networks"), SortedList)
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Not IsPostBack Then
            'Populate the Networks drop down list
            LoadNetworks(sender, e)
        End If
    End Sub

    Private Sub LoadNetworks(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strKey As String
        Dim intKey As Integer
        Dim objNetwork As clsNetwork
        Dim objListItem As ListItem
        Dim strLegendHTML As String = Nothing

        'Fill the network drop-down list
        If Not IsPostBack Then
            strLegendHTML = "<div class=" & """" & "leftpanel" & """" & "><b>Legend</b><br><p>"
            ddlNetworks.Items.Clear()

            objListItem = New ListItem("All Networks", "0")
            ddlNetworks.Items.Add(objListItem)

            For Each strKey In mobjNetworks.Keys
                objNetwork = CType(mobjNetworks.Item(strKey), clsNetwork)

                'Add the list item
                objListItem = New ListItem(objNetwork.NetworkName, objNetwork.NetworkId.ToString)
                ddlNetworks.Items.Add(objListItem)

                'Create the legend item
                strLegendHTML = strLegendHTML & "<img src=" & """" & "/odmmap/icons/" & objNetwork.Icon & """" & " ></img>" & objNetwork.NetworkName & "<br>"
            Next

            'set the legend literal control
            strLegendHTML = strLegendHTML & "</p></div>"
            ltlNetworkLegend.Text = strLegendHTML

            'Check to see if a network name was specified in the URL
            If Request.QueryString.Get("NetworkName") <> Nothing Then
                'Select the network specified in the URL, if provided
                If Not ddlNetworks.Items.FindByText(Request.QueryString.Get("NetworkName")) Is Nothing Then
                    ddlNetworks.ClearSelection()
                    ddlNetworks.Items.FindByText(Request.QueryString.Get("NetworkName")).Selected = True
                End If
            End If

            ddlNetworks_SelectedIndexChanged(sender, e)
        End If

    End Sub

    Private Sub ddlNetworks_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNetworks.SelectedIndexChanged
        'Populate the Variables drop down list
        LoadVariables(sender, e)
    End Sub

    Private Sub LoadVariables(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim objListItem As ListItem
        Dim intVariableKey As Integer = 0
        Dim objVariableTable As DataTable
        Dim objVariableRow As DataRow
        Dim strPreviousValue As String
        Dim strKey As String, strVariableKey As String, VariableName As String

        'Get the variables that need to be in the list
        Dim objNetwork As clsNetwork
        Dim objVariables As SortedList
        If ddlNetworks.SelectedItem.Text = "All Networks" Then
            'must construct a list of variables that covers all of the networks
            objVariables = New SortedList
            For Each strKey In mobjNetworks.Keys
                For Each strVariableKey In CType(mobjNetworks.Item(strKey), clsNetwork).Variables.Keys
                    VariableName = Convert.ToString(CType(mobjNetworks.Item(strKey), clsNetwork).Variables.Item(strVariableKey))
                    'Only add the variable to the list if it doesn't already exist
                    If objVariables(VariableName) Is Nothing Then
                        objVariables.Add(VariableName, VariableName)
                    End If
                Next
            Next
            objVariables.TrimToSize()
        Else 'Just make the list for the selected network
            objNetwork = CType(mobjNetworks.Item(ddlNetworks.SelectedItem.Value), clsNetwork)
            objVariables = objNetwork.Variables
        End If

        'Fill the Variables drop-down list
        ddlVariables.Items.Clear()

        objListItem = New ListItem("All Variables", intVariableKey.ToString)
        ddlVariables.Items.Add(objListItem)

        For Each strKey In objVariables.Keys
            VariableName = CType(objVariables(strKey), String)
            intVariableKey = intVariableKey + 1
            'Add the list item
            objListItem = New ListItem(VariableName, intVariableKey.ToString)
            ddlVariables.Items.Add(objListItem)
        Next

        ddlVariables_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub ddlVariables_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlVariables.SelectedIndexChanged
        'Remap the sites based on the fact that the selected variable has changed
        LoadSites(sender, e)
    End Sub

    Private Sub LoadSites(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim objDataTable As DataTable
        Dim VariableName As String
        Dim objNetwork As clsNetwork
        Dim strDBConnection As String
        Dim strIconName As String
        Dim objDataRow As DataRow
        Dim ScriptString As String = Nothing
        Dim i As Integer = 0
        Dim markerHTML As String
        Dim strKey As String
        Dim minLat As Double, maxLat As Double, avgLat As Double, minLong As Double, maxLong As Double, avgLong As Double
        Dim latChange As Double, longChange As Double
        Dim ZoomLevel As Double

        'First figure out which network to load sites for
        If ddlNetworks.SelectedItem.Text = "All Networks" Then
            maxLat = 0
            minLat = 100000
            maxLong = -100000
            minLong = 0
            'I have to loop through each network and add the sites for each one to the map
            For Each strKey In mobjNetworks.Keys
                objNetwork = CType(mobjNetworks.Item(strKey), clsNetwork)
                strDBConnection = objNetwork.DBCOnnection
                strIconName = objNetwork.Icon
                objDataTable = ConstructSitesDataTable(objNetwork)

                'Make sure there is something in the datatable before doing anything
                If objDataTable.Rows.Count > 0 Then
                    'Check the max and min lat and long
                    If Convert.ToDouble(objDataTable.Compute("Max(Latitude)", "")) > maxLat Then
                        maxLat = Convert.ToDouble(objDataTable.Compute("Max(Latitude)", ""))
                    End If
                    If Convert.ToDouble(objDataTable.Compute("Min(Latitude)", "")) < minLat Then
                        minLat = Convert.ToDouble(objDataTable.Compute("Min(Latitude)", ""))
                    End If
                    If Convert.ToDouble(objDataTable.Compute("Max(Longitude)", "")) > maxLong Then
                        maxLong = Convert.ToDouble(objDataTable.Compute("Max(Longitude)", ""))
                    End If
                    If Convert.ToDouble(objDataTable.Compute("Min(Longitude)", "")) < minLong Then
                        minLong = Convert.ToDouble(objDataTable.Compute("Min(Longitude)", ""))
                    End If

                    'Construct the script for adding the sites to the map
                    ScriptString = ScriptString & ConstructSitesScript(objDataTable, objNetwork)
                End If
            Next

            'Set the the centerpoint lat and long for zooming the map and the zoom level
            latChange = maxLat - minLat
            longChange = maxLong - minLong
            avgLat = (maxLat + minLat) / 2
            avgLong = (maxLong + minLong) / 2
            ZoomLevel = Math.Round(-1.075 * Math.Log(Math.Max(latChange, longChange)) + 8.7546, 0)
            ltlZoomExtents.Text = "map.setCenter(new GLatLng(" & avgLat.ToString & ", " & avgLong.ToString & "), " & ZoomLevel.ToString & ");"

        Else 'only load sites for a single network to the map
            objNetwork = CType(mobjNetworks.Item(ddlNetworks.SelectedItem.Value), clsNetwork)
            strDBConnection = objNetwork.DBCOnnection
            strIconName = objNetwork.Icon
            objDataTable = ConstructSitesDataTable(objNetwork)

            'Set the centerpoint lat and long for zooming the map and the zoom level
            latChange = (Convert.ToDouble(objDataTable.Compute("Max(Latitude)", "")) - Convert.ToDouble(objDataTable.Compute("Min(Latitude)", "")))
            longChange = (Convert.ToDouble(objDataTable.Compute("Max(Longitude)", "")) - Convert.ToDouble(objDataTable.Compute("Min(Longitude)", ""))) / 2
            avgLat = (Convert.ToDouble(objDataTable.Compute("Max(Latitude)", "")) + Convert.ToDouble(objDataTable.Compute("Min(Latitude)", ""))) / 2
            avgLong = (Convert.ToDouble(objDataTable.Compute("Max(Longitude)", "")) + Convert.ToDouble(objDataTable.Compute("Min(Longitude)", ""))) / 2
            ZoomLevel = Math.Round(-1.075 * Math.Log(Math.Max(latChange, longChange)) + 8.7546, 0)
            ltlZoomExtents.Text = "map.setCenter(new GLatLng(" & avgLat.ToString & ", " & avgLong.ToString & "), " & ZoomLevel.ToString & ");"

            'Construct the script for adding the sites to the map
            ScriptString = ConstructSitesScript(objDataTable, objNetwork)
        End If

        ltlSitesScript.Text = ScriptString
        Page_Load(sender, e)
    End Sub

    Private Function ConstructSitesDataTable(ByVal objNetwork As clsNetwork) As DataTable
        Dim VariableName As String
        Dim objDataTable As DataTable
        'Get the name of the selected Variable
        VariableName = ddlVariables.SelectedItem.Text

        Dim strDBConnection As String = objNetwork.DBCOnnection

        If VariableName = "All Variables" Then 'Get all of the sites for the selected networks
            objDataTable = OpenTable(strDBConnection, "SELECT * FROM Sites ORDER BY SiteID")
        Else 'Get the sites from the selected networks with data for the selected variable
            objDataTable = OpenTable(strDBConnection, "Select * FROM Sites WHERE SiteID IN (SELECT SiteID FROM SeriesCatalog WHERE VariableName ='" & VariableName & "')")
        End If
        Return objDataTable
    End Function

    Private Function ConstructSitesScript(ByVal objDataTable As DataTable, ByVal objNetwork As clsNetwork) As String
        Dim ScriptString As String = String.Empty
        Dim objDataRow As DataRow
        Dim markerHTML As String
        Dim i As Integer

        Dim strNetworkID As String = objNetwork.NetworkId.ToString
        Dim strIconName As String = objNetwork.Icon.ToString
        Dim strDatabaseName As String = objNetwork.DatabaseName.ToString

        'For Each objDataRow In objDataTable.Select
        '    i = i + 1
        '    markerHTML = "<table><tr><td><img src='images/spacer.gif' width=100 height=1</td><td><img src='images/spacer.gif' width=10 height=1</td><td><img src='images/spacer.gif' width=100 height=1</td></tr>" & _
        '        "<tr valign='top'>" & _
        '        "<td padding='10px' width=200><b>SiteCode: </b>" & Convert.ToString(objDataRow.Item("SiteCode")) & "<br>" & _
        '        "<b>SiteName: </b>" & Convert.ToString(objDataRow.Item("SiteName")) & "<br>" & _
        '        "<b>Latitude: </b>" & Convert.ToString(objDataRow.Item("Latitude")) & "<br>" & _
        '        "<b>Longitude: </b>" & Convert.ToString(objDataRow.Item("Longitude")) & "<br><br>" & _
        '        "<table><tr><td><img src='images/ploticon.gif'></td><td><img src='images/spacer.gif' width=5></td>" & _
        '        "<td><a href='http://water.usu.edu/odmanalyst/default.aspx?Database=LittleBearRiver&SiteID=" & Convert.ToString(objDataRow.Item("SiteID")) & "' target='_blank'>View and download data</a>" & "</td></tr>" & _
        '        "<tr><td><img src='images/ploticonwpoint.gif'></td><td><img src='images/spacer.gif' width=5></td>" & _
        '        "<td><a href='current/default.aspx?SiteCode=" & Convert.ToString(objDataRow.Item("SiteCode")) & "' target='_blank'>View current conditions</a></td></tr></table>" & _
        '        "<td><img src='images/spacer.gif' width=10 height=1</td>" & _
        '        "<td><a href='images/" & Convert.ToString(objDataRow.Item("SiteCode")) & ".jpg' target='_blank'>" & "<img src=" & "images/" & Convert.ToString(objDataRow.Item("SiteCode")) & "-small.jpg" & " width=125 border=0></a></td>" & _
        '        "</tr></table>"
        '    ScriptString = ScriptString & "var point = new GLatLng(" & Convert.ToString(objDataRow.Item("Latitude")) & ", " & Convert.ToString(objDataRow.Item("Longitude")) & ");" & ControlChars.NewLine
        '    ScriptString = ScriptString & "map.addOverlay(createMarker(point, " & """" & markerHTML & """" & "));" & ControlChars.NewLine
        'Next

        ScriptString = ScriptString & "var Icon" & strNetworkID & " = new GIcon();" & ControlChars.NewLine
        ScriptString = ScriptString & "Icon" & strNetworkID & ".image = " & """" & "/odmmap/icons/" & strIconName & """" & ";" & ControlChars.NewLine
        ScriptString = ScriptString & "Icon" & strNetworkID & ".shadow = " & """" & "/odmmap/icons/" & Split(strIconName, ".")(0) & "_shadow.png" & """" & ";" & ControlChars.NewLine
        ScriptString = ScriptString & "Icon" & strNetworkID & ".iconSize = new GSize(32, 32);" & ControlChars.NewLine
        ScriptString = ScriptString & "Icon" & strNetworkID & ".shadowSize = new GSize(56, 32);" & ControlChars.NewLine
        ScriptString = ScriptString & "Icon" & strNetworkID & ".iconAnchor = new GPoint(16, 32);" & ControlChars.NewLine
        ScriptString = ScriptString & "Icon" & strNetworkID & ".infoWindowAnchor = new GPoint(16, 0);" & ControlChars.NewLine
        ScriptString = ScriptString & "Icon" & strNetworkID & ".infoShadowAnchor = new GPoint(18, 25);" & ControlChars.NewLine
        ScriptString = ScriptString & "markerOptions = { icon:" & "Icon" & strNetworkID & " };" & ControlChars.NewLine

        For Each objDataRow In objDataTable.Select
            i = i + 1
            markerHTML = "<div class='bubble'><b>SiteCode: </b>" & Convert.ToString(objDataRow.Item("SiteCode")) & "<br>" & _
                "<b>SiteName: </b>" & Convert.ToString(objDataRow.Item("SiteName")) & "<br>" & _
                "<b>Latitude: </b>" & Convert.ToString(objDataRow.Item("Latitude")) & "<br>" & _
                "<b>Longitude: </b>" & Convert.ToString(objDataRow.Item("Longitude")) & "<br>" & _
                "<img src='images/ploticon.gif'><a href='http://tsa.usu.edu/odm_tsa/default.aspx?Database=" & strDatabaseName & "&SiteCode=" & Convert.ToString(objDataRow.Item("SiteCode")) & "' target='_blank' style='MARGIN-LEFT:10px'>View and download data</a></div>"
            
            ScriptString = ScriptString & "var point = new GLatLng(" & Convert.ToString(objDataRow.Item("Latitude")) & ", " & Convert.ToString(objDataRow.Item("Longitude")) & ");" & ControlChars.NewLine
            ScriptString = ScriptString & "map.addOverlay(createMarker(point, " & """" & markerHTML & """" & ", markerOptions));" & ControlChars.NewLine
        Next

        Return ScriptString
    End Function

    Private Sub lnkLegend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLegend.Click
        tabQueryOptions.Attributes.Item("class") = "inactiveTab"
        tabLegend.Attributes.Item("class") = "activeTab"
        pnlQueryOptions.Visible = False
        pnlLegend.Visible = True
    End Sub

    Private Sub lnkQueryOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkQueryOptions.Click
        tabLegend.Attributes.Item("class") = "inactiveTab"
        tabQueryOptions.Attributes.Item("class") = "activeTab"
        pnlLegend.Visible = False
        pnlQueryOptions.Visible = True
    End Sub

End Class
