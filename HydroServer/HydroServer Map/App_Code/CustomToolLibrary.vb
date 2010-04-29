'Copyright 2008 ESRI

'All rights reserved under the copyright laws of the United States
'and applicable international laws, treaties, and conventions.

'You may freely redistribute and use this sample code, with or
'without modification, provided you include the original copyright
'notice and use restrictions.

'See use restrictions at <your ArcGIS install location>/developerkit/userestrictions.txt.


'Copyright 2008 ESRI

'All rights reserved under the copyright laws of the United States
'and applicable international laws, treaties, and conventions.

'You may freely redistribute and use this sample code, with or
'without modification, provided you include the original copyright
'notice and use restrictions.

'See use restrictions at /arcgis/developerkit/userestrictions.


Imports Microsoft.VisualBasic
Imports System
Namespace CustomToolLibrary

    '    Public Class TSA_Link
    '        Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IMapServerToolAction
    '#Region "IMapServerToolAction Members"
    '        Private Const HYPERLINK_PANEL_HEIGHT As Integer = 250

    '        Private Sub ServerAction(ByVal toolEventArgs As ESRI.ArcGIS.ADF.Web.UI.WebControls.ToolEventArgs) Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IMapServerToolAction.ServerAction
    '            ' Get reference to the map control
    '            Dim adfMap As ESRI.ArcGIS.ADF.Web.UI.WebControls.Map = CType(toolEventArgs.Control, ESRI.ArcGIS.ADF.Web.UI.WebControls.Map)

    '            Try
    '                ' Cast tool event arguments to map point event arguments, which allows
    '                ' easy access to the map point clicked by the user
    '                Dim mapPointEventArgs As ESRI.ArcGIS.ADF.Web.UI.WebControls.MapPointEventArgs = CType(toolEventArgs, ESRI.ArcGIS.ADF.Web.UI.WebControls.MapPointEventArgs)
    '                ' Get the map point from the map point event arguments
    '                Dim adfPoint As ESRI.ArcGIS.ADF.Web.Geometry.Point = mapPointEventArgs.MapPoint

    '                ' Create a master dataset to store all tables returned from Identity operation
    '                Dim outputDataset As System.Data.DataSet = New System.Data.DataSet()

    '                ' For each map functionality (resource) in the Map, do an Identify
    '                For Each mapFunctionality As ESRI.ArcGIS.ADF.Web.DataSources.IMapFunctionality In adfMap.GetFunctionalities()
    '                    If mapFunctionality.Resource.Name.Contains("ODM Sites") Then
    '                        ' Retrieve the resource for the current map functionality object
    '                        Dim gisResource As ESRI.ArcGIS.ADF.Web.DataSources.IGISResource = mapFunctionality.Resource

    '                        ' Check whether the current resource supports querying
    '                        Dim supportsQuery As Boolean = gisResource.SupportsFunctionality(GetType(ESRI.ArcGIS.ADF.Web.DataSources.IQueryFunctionality))

    '                        If supportsQuery Then
    '                            ' Create a query functionality object from the current resource
    '                            Dim queryFunctionality As ESRI.ArcGIS.ADF.Web.DataSources.IQueryFunctionality = CType(gisResource.CreateFunctionality(GetType(ESRI.ArcGIS.ADF.Web.DataSources.IQueryFunctionality), Nothing), ESRI.ArcGIS.ADF.Web.DataSources.IQueryFunctionality)

    '                            ' Get the names and ids of the queryable layers in the current resource
    '                            Dim layerIDs As String()
    '                            Dim layerNames As String()
    '                            queryFunctionality.GetQueryableLayers(Nothing, layerIDs, layerNames)

    '                            If (layerNames Is Nothing) Then
    '                                Continue For
    '                            End If

    '                            ' Initialize a variable to store tolerance.  This will be used as the tolerance
    '                            ' around the point clicked by the user
    '                            Dim pixelTolerance As Integer = 15

    '                            ' Execute the identify operation
    '                            Dim resultDataTableArray As System.Data.DataTable() = queryFunctionality.Identify(mapFunctionality.Name, adfPoint, pixelTolerance, ESRI.ArcGIS.ADF.Web.IdentifyOption.VisibleLayers, layerIDs)

    '                            ' Exit the loop if no results were found
    '                            If resultDataTableArray Is Nothing Then
    '                                Exit For
    '                            End If

    '                            ' Add each table returned to the master dataset.  Give each table a unique name
    '                            ' composed of the resource name, layer id, and layer name.
    '                            Dim index As Integer = 0
    '                            Do While index < resultDataTableArray.Length
    '                                Dim resultDataTable As System.Data.DataTable = resultDataTableArray(index)
    '                                ' Find the index of the layer name in the layerNames array
    '                                ' corresponding to the current results table
    '                                Dim i As Integer
    '                                i = 0
    '                                Do While i < layerNames.Length
    '                                    If resultDataTable.TableName = layerNames(i) Then
    '                                        Exit Do
    '                                    End If
    '                                    i += 1
    '                                Loop
    '                                resultDataTable.TableName = gisResource.Name & "_" & layerIDs(i) & "_" & layerNames(i)
    '                                outputDataset.Tables.Add(resultDataTable)
    '                                index += 1
    '                            Loop
    '                        End If
    '                    End If
    '                Next mapFunctionality
    '                Dim Javascript As String = "<script type=""text/javascript"">" & vbCrLf & "//<![CDATA[" & vbCrLf & "window.open(""http://www.google.com/"",""Test"");" & vbCrLf & "//]]></script>"
    '                If (outputDataset.Tables.Count = 1) AndAlso (outputDataset.Tables(0).Rows.Count = 1) Then

    '                End If
    '            Catch exception As System.Exception

    '            End Try

    '        End Sub
    '#End Region
    '    End Class

    '    Public Class ExtentCommand
    '        Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IMapServerCommandAction
    '#Region "IMapServerCommandAction Members"

    '        Private Sub ServerAction(ByVal toolbarItemInfo As ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.ToolbarItemInfo) Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IServerAction.ServerAction
    '            ' Change map extent.  Since layer or resource content is 
    '            ' not changed, no call to Map.Refresh is needed.
    '            Dim adfMap As ESRI.ArcGIS.ADF.Web.UI.WebControls.Map = CType(toolbarItemInfo.BuddyControls(0), ESRI.ArcGIS.ADF.Web.UI.WebControls.Map)

    '            Try
    '                adfMap.Extent = New ESRI.ArcGIS.ADF.Web.Geometry.Envelope(-120, 30, -100, 40)
    '            Catch exception As System.Exception
    '                ' If an error occurred, get the callback result from the ProcessError
    '                ' function and copy to the map control's callback results collection
    '                adfMap.CallbackResults.Add(Utility.GetErrorCallback(exception))
    '            End Try
    '        End Sub

    '#End Region
    '    End Class

    '    Public Class ExtentListDropDownBox
    '        Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IMapServerDropDownBoxAction
    '#Region "IMapServerDropDownBoxAction Members"

    '        Private Sub ServerAction(ByVal toolbarItemInfo As ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.ToolbarItemInfo) Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IServerAction.ServerAction
    '            ' Get the value selected in Web ADF drop down box.  Change map extent and set Map.Extent to the new extent.
    '            ' Get the Web ADF map control
    '            Dim adfMap As ESRI.ArcGIS.ADF.Web.UI.WebControls.Map = CType(toolbarItemInfo.BuddyControls(0), ESRI.ArcGIS.ADF.Web.UI.WebControls.Map)

    '            Try
    '                ' Get the direction drop-down box and the currently selected value
    '                Dim directionDropDownBox As ESRI.ArcGIS.ADF.Web.UI.WebControls.DropDownBox = CType(toolbarItemInfo.Toolbar.ToolbarItems.Find(toolbarItemInfo.Name), ESRI.ArcGIS.ADF.Web.UI.WebControls.DropDownBox)
    '                Dim directionQuadrant As String = directionDropDownBox.SelectedValue

    '                ' Get the current map extent parameters
    '                Dim minx, miny, maxx, maxy As Double
    '                minx = adfMap.Extent.XMin
    '                miny = adfMap.Extent.YMin
    '                maxx = adfMap.Extent.XMax
    '                maxy = adfMap.Extent.YMax

    '                ' Calculate the width and height of the current map extent
    '                Dim xWidth As Double = maxx - minx
    '                Dim yHeight As Double = maxy - miny

    '                ' Calculate new extent parameters based on the currently selected
    '                ' value in the direction drop-down box
    '                Select Case directionQuadrant
    '                    Case "NorthWest"
    '                        miny = maxy
    '                        maxy = maxy + yHeight
    '                        maxx = minx
    '                        minx = minx - xWidth
    '                    Case "NorthEast"
    '                        minx = maxx
    '                        maxx = maxx + xWidth
    '                        miny = maxy
    '                        maxy = maxy + yHeight
    '                    Case "SouthWest"
    '                        maxx = minx
    '                        minx = minx - xWidth
    '                        maxy = miny
    '                        miny = miny - yHeight
    '                    Case "SouthEast"
    '                        minx = maxx
    '                        maxx = maxx + xWidth
    '                        maxy = miny
    '                        miny = miny - yHeight
    '                End Select

    '                ' Set the map control's extent to the new extent parameters
    '                adfMap.Extent = New ESRI.ArcGIS.ADF.Web.Geometry.Envelope(minx, miny, maxx, maxy)
    '            Catch exception As System.Exception
    '                ' If an error occurred, get the callback result from the ProcessError
    '                ' function and copy to the map control's callback results collection
    '                adfMap.CallbackResults.Add(Utility.GetErrorCallback(exception))
    '            End Try
    '        End Sub

    '#End Region
    '    End Class

    Public Class HyperLinkTool
        Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IMapServerToolAction
#Region "IMapServerToolAction Members"

        Private Sub ServerAction(ByVal toolEventArgs As ESRI.ArcGIS.ADF.Web.UI.WebControls.ToolEventArgs) Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IMapServerToolAction.ServerAction

            ' Get map control from passed-in arguments
            Dim adfMap As ESRI.ArcGIS.ADF.Web.UI.WebControls.Map = CType(toolEventArgs.Control, ESRI.ArcGIS.ADF.Web.UI.WebControls.Map)

            ' Cast tool event arguments to map point event arguments, which allows
            ' easy access to the map point clicked by the user
            Dim mapPointEventArgs As ESRI.ArcGIS.ADF.Web.UI.WebControls.MapPointEventArgs = CType(toolEventArgs, ESRI.ArcGIS.ADF.Web.UI.WebControls.MapPointEventArgs)
            ' Get the map point from the map point event arguments
            Dim adfPoint As ESRI.ArcGIS.ADF.Web.Geometry.Point = mapPointEventArgs.MapPoint

            ' Get the functionality of the resource that contains the layer on which you want to hyperlink
            Dim commonMapFunctionality As ESRI.ArcGIS.ADF.Web.DataSources.IMapFunctionality = adfMap.GetFunctionality("ODM Sites")
            Dim gisResource As ESRI.ArcGIS.ADF.Web.DataSources.IGISResource = commonMapFunctionality.Resource

            ' Create query functionality from the resource
            Dim queryFunctionality As ESRI.ArcGIS.ADF.Web.DataSources.IQueryFunctionality = CType(gisResource.CreateFunctionality(GetType(ESRI.ArcGIS.ADF.Web.DataSources.IQueryFunctionality), Nothing), ESRI.ArcGIS.ADF.Web.DataSources.IQueryFunctionality)

            ' Get the ids and names of the layers in the current that can be queried
            Dim layerIDs As String() = {}
            Dim layerNames As String() = {}
            queryFunctionality.GetQueryableLayers(Nothing, layerIDs, layerNames)

            '' Set the layer name on which you want to hyperlink
            'Dim activeLayerName As String = "littlebear11"

            '' Iterate through the layer names until a match is found for
            '' activeLayerName.  Include a call to ToUpper() in the comparison
            '' to eliminate case sensitivity.
            'Dim activeLayerID As String = Nothing
            'Dim index As Integer = 0
            'Do While index < layerNames.Length
            '    If layerNames(index).ToUpper() = activeLayerName.ToUpper() Then
            '        ' Get the layer id of the match found from the layer id array
            '        activeLayerID = layerIDs(index)
            '        Exit Do
            '    End If
            '    index += 1
            'Loop

            ' Create a spatial filter and initialize its geometry with the point clicked
            'Dim spatialFilter As ESRI.ArcGIS.ADF.Web.SpatialFilter = New ESRI.ArcGIS.ADF.Web.SpatialFilter()
            'Dim adfRect As New ESRI.ArcGIS.ADF.Web.Geometry.Envelope(adfPoint.X - (adfMap.Extent.Width * buffer), adfPoint.Y - (adfMap.Extent.Height * buffer), adfPoint.X + (adfMap.Extent.Width * buffer), adfPoint.Y + (adfMap.Extent.Height * buffer))


            Try
                ' Execute the query
                Dim resultDataTables() As System.Data.DataTable = queryFunctionality.Identify(commonMapFunctionality.Name, adfPoint, 10, ESRI.ArcGIS.ADF.Web.IdentifyOption.VisibleLayers, layerNames)
                'Dim resultDataTable As System.Data.DataTable = queryFunctionality.Query(commonMapFunctionality.Name, activeLayerID, spatialFilter)


                ' If no features returned, show alert
                If (resultDataTables.Length < 1) Then
                    Throw New System.Exception("No feature found")
                End If

                'If (resultDataTables(0).Rows.Count < 1) Then
                '    Throw New System.Exception("No feature found")
                'End If

                Dim closestSite As Data.DataRow = Nothing
                Dim closestDist As Double
                Dim p As ESRI.ArcGIS.ADF.Web.Geometry.Point
                Dim currDist As Double
                For Each resultDataTable As Data.DataTable In resultDataTables
                    For Each resultdatarow As Data.DataRow In resultDataTable.Rows
                        p = resultdatarow.Item("GeometryElement")
                        If (closestSite Is Nothing) Then
                            closestSite = resultdatarow
                            closestDist = (Math.Pow(p.X - adfPoint.X, 2) + Math.Pow(p.Y - adfPoint.Y, 2))
                        Else
                            currDist = (Math.Pow(p.X - adfPoint.X, 2) + Math.Pow(p.Y - adfPoint.Y, 2))
                            If (currDist < closestDist) Then
                                closestSite = resultdatarow
                                closestDist = currDist
                            End If
                        End If
                    Next resultdatarow
                Next resultDataTable

                If (closestSite Is Nothing) Then
                    Throw New System.Exception("No feature found")
                End If

                ' Name of field containing the term to the google search url
                Dim SiteCode As String = CStr(closestSite.Item("SiteCode"))
                Dim DatabaseName As String = CStr(closestSite.Item("DatabaseName"))

                ' If field contains no data, show alert
                If String.IsNullOrEmpty(SiteCode) Then
                    Throw New System.Exception("Hyperlink field contains no data")
                End If
                If String.IsNullOrEmpty(DatabaseName) Then
                    Throw New System.Exception("Hyperlink field contains no data")
                End If

                ' Construct the JavaScript call to change the map cursor back to original
                Dim jsChangeCursor As String = "map.divObject.style.cursor = map.cursor"

                ' Create a callback result containing the JavaScript call and add to the
                ' map control's callback results collection
                Dim cursorCallbackResult As ESRI.ArcGIS.ADF.Web.UI.WebControls.CallbackResult = ESRI.ArcGIS.ADF.Web.UI.WebControls.CallbackResult.CreateJavaScript(jsChangeCursor)
                adfMap.CallbackResults.Add(cursorCallbackResult)

                ' Construct the JavaScript call to open a new browser window.  Any valid url can be used.
                Dim jsPopup As String = "window.open('" & ConfigurationManager.AppSettings("TSA_Location") & "?Database=" & DatabaseName & "&SiteCode=" & SiteCode & "');"

                ' Create a callback result containing the JavaScript call and add to the
                ' map control's callback results collection
                Dim popupCallbackResult As ESRI.ArcGIS.ADF.Web.UI.WebControls.CallbackResult = ESRI.ArcGIS.ADF.Web.UI.WebControls.CallbackResult.CreateJavaScript(jsPopup)
                adfMap.CallbackResults.Add(popupCallbackResult)
            Catch exception As System.Exception
                ' If an error occurred, get the callback result from the ProcessError
                ' function and copy to the map control's callback results collection
                adfMap.CallbackResults.Add(Utility.GetErrorCallback(exception))
            End Try

        End Sub

#End Region
    End Class

    '    Public Class PreviousExtent
    '        Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IMapServerCommandAction
    '#Region "IMapServerCommandAction Members"

    '        Private Sub ServerAction(ByVal toolbarItemInfo As ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.ToolbarItemInfo) Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IServerAction.ServerAction
    '            Dim adfMap As ESRI.ArcGIS.ADF.Web.UI.WebControls.Map = CType(toolbarItemInfo.BuddyControls(0), ESRI.ArcGIS.ADF.Web.UI.WebControls.Map)

    '            Try
    '                ' Access to custom members in a page.  Implement custom interface in the Page.
    '                Dim baseToolbarRefresh As IBaseToolbarRefresh = CType(adfMap.Page, IBaseToolbarRefresh)

    '                ' A previous\next action is occurring
    '                ' Initial previous\next action to skip extent hashtable adjustment
    '                adfMap.Page.Session("previousNext") = True
    '                ' Subsequent map draw from previous\next action to skip extent hashtable adjustment
    '                adfMap.Page.Session("previousNextMapHandler") = True
    '                Dim extentsHashTable As System.Collections.Hashtable = Nothing

    '                ' If there is an extent history, continue
    '                If Not adfMap.Page.Session("extentHistory") Is Nothing Then
    '                    ' Get the extent history
    '                    extentsHashTable = CType(adfMap.Page.Session("extentHistory"), System.Collections.Hashtable)

    '                    ' Get the current extent index.  If greater than 0, decrement the index
    '                    ' and set the map extent to the previous extent in the extent history.               
    '                    Dim extentIndex As Integer = CInt(Fix(adfMap.Page.Session("currentExtentIndex")))

    '                    If extentIndex > 0 Then
    '                        extentIndex -= 1
    '                        adfMap.Page.Session("currentExtentIndex") = extentIndex
    '                        adfMap.Extent = CType(extentsHashTable(extentIndex), ESRI.ArcGIS.ADF.Web.Geometry.Envelope)
    '                    End If

    '                    ' If the index is now less than or equal to 0, meaning there is not prior extent
    '                    ' in the extent history, disable the previous extent command.
    '                    If extentIndex <= 0 Then
    '                        baseToolbarRefresh.RefreshToolbar("previousExtent", True)
    '                    End If
    '                End If
    '                ' If there is an extent history, always enable the next extent command after the previous
    '                ' extent command is executed.
    '                baseToolbarRefresh.RefreshToolbar("nextExtent", False)
    '            Catch exception As System.Exception
    '                ' If an error occurred, get the callback result from the ProcessError
    '                ' function and copy to the map control's callback results collection
    '                adfMap.CallbackResults.Add(Utility.GetErrorCallback(exception))
    '            End Try
    '        End Sub

    '#End Region
    '    End Class

    '    Public Class NextExtent
    '        Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IMapServerCommandAction
    '#Region "IMapServerCommandAction Members"

    '        Private Sub ServerAction(ByVal toolbarItemInfo As ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.ToolbarItemInfo) Implements ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.IServerAction.ServerAction
    '            ' Get references to the map control and page via IBaseToolbarRefresh
    '            Dim adfMap As ESRI.ArcGIS.ADF.Web.UI.WebControls.Map = CType(toolbarItemInfo.BuddyControls(0), ESRI.ArcGIS.ADF.Web.UI.WebControls.Map)

    '            Try
    '                Dim baseToolbarRefresh As IBaseToolbarRefresh = CType(adfMap.Page, IBaseToolbarRefresh)

    '                ' A previous\next action is occurring
    '                ' Initial previous\next action to skip extent hashtable adjustment
    '                adfMap.Page.Session("previousNext") = True
    '                ' Subsequent map draw from previous\next action to skip extent hashtable adjustment
    '                adfMap.Page.Session("previousNextMapHandler") = True
    '                Dim extentsHashTable As System.Collections.Hashtable = Nothing

    '                ' If there is an extent history, continue
    '                If Not adfMap.Page.Session("extentHistory") Is Nothing Then
    '                    ' Get the extent history and current extent index
    '                    extentsHashTable = CType(adfMap.Page.Session("extentHistory"), System.Collections.Hashtable)
    '                    Dim extentIndex As Integer = CInt(Fix(adfMap.Page.Session("currentExtentIndex")))

    '                    ' Get the current extent index.  If index is less than the index of the last extent in extent history, 
    '                    ' increment the index by 1 and set the map extent to the next extent in the extent history.
    '                    If extentIndex < (extentsHashTable.Count - 1) Then
    '                        extentIndex += 1
    '                        adfMap.Page.Session("currentExtentIndex") = extentIndex
    '                        adfMap.Extent = CType(extentsHashTable(extentIndex), ESRI.ArcGIS.ADF.Web.Geometry.Envelope)
    '                    End If

    '                    ' If the index greater than or equal to the index of the last extent in extent history,
    '                    ' meaning there is not another extent to move to, disable the next extent command.
    '                    If extentIndex >= (extentsHashTable.Count - 1) Then
    '                        baseToolbarRefresh.RefreshToolbar("nextExtent", True)
    '                    End If

    '                    ' If there is an extent history, always enable the previous extent command after the 
    '                    ' next extent command is executed.
    '                    baseToolbarRefresh.RefreshToolbar("previousExtent", False)
    '                End If
    '            Catch exception As System.Exception
    '                ' If an error occurred, get the callback result from the ProcessError
    '                ' function and copy to the map control's callback results collection
    '                adfMap.CallbackResults.Add(Utility.GetErrorCallback(exception))
    '            End Try
    '        End Sub

    '#End Region
    '    End Class

    Public Class Utility
        'Constructs a callback result that will display an error message based on the passed-in
        'exception
        Public Shared Function GetErrorCallback(ByVal exception As System.Exception) As ESRI.ArcGIS.ADF.Web.UI.WebControls.CallbackResult
            'Create a callback result to display an error message
            Dim jsAlertErrorMessage As String = GetJavaScriptErrorString(exception)
            Dim alertCallbackResult As ESRI.ArcGIS.ADF.Web.UI.WebControls.CallbackResult = ESRI.ArcGIS.ADF.Web.UI.WebControls.CallbackResult.CreateJavaScript(jsAlertErrorMessage)
            Return alertCallbackResult
        End Function

        'Constructs JavaScript necessary to display an error message based on the passed-in exception.
        Public Shared Function GetJavaScriptErrorString(ByVal exception As System.Exception) As String
            'Get the website's configuration file
            Dim webConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(System.Web.HttpContext.Current.Request.ApplicationPath)

            'Get the "compilation" section of the config file
            Dim compilationSection As System.Web.Configuration.CompilationSection = TryCast(webConfig.GetSection("system.web/compilation"), System.Web.Configuration.CompilationSection)

            'If the config file's compilation section specifies debug mode, include 
            'stack trace information in the error message.  Otherwise, just return 
            'the exception message.
            Dim errorMessage As String = Nothing
            If (Not compilationSection Is Nothing) AndAlso (compilationSection.Debug) Then
                Dim stackTrace As String = exception.StackTrace.Replace("\", "\\")
                errorMessage = exception.Message & "\n\n" & stackTrace.Trim()
            Else
                errorMessage = exception.Message
            End If

            'Create a callback result to display an error message
            Dim jsAlertException As String = "alert('" & errorMessage & "')"
            Return jsAlertException
        End Function
    End Class
End Namespace
