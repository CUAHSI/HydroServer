Imports ZedGraph
Imports System.Drawing

Partial Public Class Graphs_ZGBoxWhisker
    Inherits UserControl
    'Inherits Panel

    Public Shared m_Data As Data.DataTable
    Public Shared m_Site As String
    Public Shared m_Var As String
    Public Shared m_Options As PlotOptions
    Private m_StdDev As Double = 0

    Private Const db_outFld_ValDTMonth As String = "DateMonth"
    Private Const db_outFld_ValDTYear As String = "DateYear"
    Private Const db_outFld_ValDTDay As String = "DateDay"

    Public Property Width() As WebControls.Unit
        Get
            Return BoxWhiskerPlot.Width
        End Get
        Set(ByVal val As WebControls.Unit)
            'MyBase.Width = val.Value
            BoxWhiskerPlot.Width = val.Value
        End Set
    End Property
    Public Property Height() As WebControls.Unit
        Get
            Return BoxWhiskerPlot.Height
        End Get
        Set(ByVal val As WebControls.Unit)
            BoxWhiskerPlot.Height = val.Value
        End Set
    End Property

    Public Sub Plot(ByRef objDataTable As Data.DataTable, ByVal strSiteName As String, ByVal strVariableName As String, ByVal strVariableUnits As String, ByRef objOptions As PlotOptions, ByVal e_StdDev As Double) ', Optional ByVal e_StdDev As Double = 0))
        Try
            If Not (m_Data Is Nothing) Then
                Clear()
            End If
            m_Data = objDataTable.Copy
            m_Site = strSiteName
            m_Var = strVariableName & " - " & strVariableUnits
            m_Options = objOptions

            If (e_StdDev = 0) And (Not (m_Data Is Nothing)) And (m_Data.Rows.Count > 0) Then
                m_StdDev = Statistics.StandardDeviation(m_Data)
            Else
                m_StdDev = e_StdDev
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGBoxWhisker.Plot" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Replot(ByVal options As PlotOptions)
        Try
            m_Options = options
            BoxWhiskerPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGBoxWhisker.Replot" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Clear()
        Try
            If Not (m_Data Is Nothing) Then
                m_Data.Dispose()
                m_Data = Nothing
            End If

            'GraphData()
            BoxWhiskerPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGBoxWhisker.Clear" & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Sub BoxWhiskerPlot_RenderGraph(ByVal g As System.Drawing.Graphics, ByVal pane As ZedGraph.MasterPane) Handles BoxWhiskerPlot.RenderGraph
        Try
            If ((m_Data Is Nothing) OrElse (m_Data.Rows.Count < 1)) Then 'OrElse ((m_DataSet Is Nothing) OrElse (m_DataSet.Tables.Count < 1)) Then
                BoxWhiskerPlot.CurveList.Clear()
                Dim gPane As ZedGraph.GraphPane = pane(0)
                gPane.Title.Text = "No Data to Plot"
                gPane.XAxis.Scale.Min = 0
                gPane.XAxis.Scale.Max = 10
                gPane.XAxis.Title.Text = ""
                gPane.XAxis.Type = AxisType.Linear
                gPane.YAxis.Scale.Min = 0
                gPane.YAxis.Scale.Max = 10
                gPane.YAxis.Title.Text = ""
                gPane.YAxis.Type = AxisType.Linear
            Else
                Dim i As Integer
                Dim gPane As ZedGraph.GraphPane 'GraphPane of the zg5Histogram plot object -> used to set data and characteristics
                Dim numPts As Integer 'number of points in ptList
                Dim xTitle As String 'the title of the XAxis
                Dim medianList As ZedGraph.PointPairList 'collection of Median points for the Box/Whisker plot
                Dim meanList As ZedGraph.PointPairList 'collection of Mean points for the Box/Whisker plot
                Dim outlierList As ZedGraph.PointPairList = Nothing 'collection of Outlier points for the Box/Whisker plot
                Dim boxes As BoxPlot() = Nothing 'collection of boxes to draw
                Dim xAxisLabels As String() = Nothing 'collection of labels for the x-Axis
                Dim medianLine As ZedGraph.LineItem 'zedgraph curve item -> line that contains all of the Medain points
                Dim meanLine As ZedGraph.LineItem 'zedgraph curve item -> line that contains all of the Mean points
                Dim outlierLine As ZedGraph.LineItem 'zedgraph curve item -> line that contains all of the outliers
                Dim min, max As Double 'the max,Min value
                Dim showXTics As Boolean = True 'tracks if showing major tic marks along the x-axis

                '1. set the Graph Pane, graphics object
                gPane = pane(0)

                '4. Calculate Data for the correct type of BoxPlot
                'get all the rows from the table with positive data, order by Date
                medianList = New ZedGraph.PointPairList()
                meanList = New ZedGraph.PointPairList()
                min = 100
                max = 0
                Select Case m_Options.BoxWhiskerType
                    Case "monthly"
                        'Calculate Boxplot for Monthly data
                        numPts = CalcBoxPlot_Monthly(medianList, meanList, boxes, xAxisLabels, min, max)
                        xTitle = "Month"
                        showXTics = True
                    Case "seasonal"
                        'Calculate Boxplot for seasonal data
                        numPts = CalcBoxPlot_Seasonal(medianList, meanList, boxes, xAxisLabels, min, max)
                        xTitle = "Season"
                        showXTics = True
                    Case "yearly"
                        'Calculate Boxplot for Yearly data
                        numPts = CalcBoxPlot_Yearly(medianList, meanList, boxes, xAxisLabels, min, max)
                        xTitle = "Year"
                        showXTics = True
                    Case "overall"
                        'Calculate Boxplot for All data
                        numPts = CalcBoxPlot_Overall(medianList, meanList, boxes, xAxisLabels, min, max)
                        xTitle = "Overall"
                        showXTics = False
                    Case Else
                        'Calculate Boxplot for Monthly data
                        numPts = CalcBoxPlot_Monthly(medianList, meanList, boxes, xAxisLabels, min, max)
                        xTitle = "Month"
                        showXTics = True
                End Select

                '5. Set Graph Properties
                'x-axis
                gPane.XAxis.IsVisible = True
                gPane.XAxis.Type = ZedGraph.AxisType.Text
                gPane.XAxis.Scale.TextLabels = xAxisLabels
                gPane.XAxis.Title.Text = xTitle
                gPane.XAxis.MajorTic.IsAllTics = showXTics
                'y-axis
                gPane.YAxis.IsVisible = True
                gPane.YAxis.MajorGrid.IsVisible = True
                gPane.YAxis.MajorGrid.Color = Color.Gray
                'gPane.YAxis.Type = ZedGraph.AxisType.Linear
                gPane.YAxis.Title.Text = m_Var
                gPane.YAxis.Scale.Min = min - (0.2 * m_StdDev)
                gPane.YAxis.Scale.Max = max + (0.2 * m_StdDev)
                gPane.YAxis.Scale.MaxGrace = 0 '0.025 '2.5% 
                gPane.YAxis.Scale.MinGrace = 0 '0.025 '2.5%

                gPane.Title.Text = m_Site

                '6. Plot the Data
                If numPts > 0 Then
                    'Add Median line to plot
                    medianLine = gPane.AddCurve("MedianPts", medianList, Color.Black, ZedGraph.SymbolType.Circle)
                    medianLine.Line.IsVisible = False
                    medianLine.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Black)
                    medianLine.Symbol.Size = 5
                    'Add Mean line to plot
                    meanLine = gPane.AddCurve("MeanPts", meanList, Color.Red, ZedGraph.SymbolType.Triangle)
                    meanLine.Line.IsVisible = False
                    meanLine.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Red)
                    meanLine.Symbol.Size = 5
                    'Draw BoxPlot,Outliers around each point
                    If Not (outlierList Is Nothing) Then
                        outlierList.Clear()
                    Else
                        outlierList = New ZedGraph.PointPairList
                    End If
                    For i = 0 To numPts - 1
                        If Not (boxes(i) Is Nothing) Then
                            'Draw Box/Whisker
                            DrawBoxPlot(gPane, boxes(i))
                            'set Outliers Points
                            DrawOutliers(outlierList, boxes(i))
                        End If
                    Next i
                    'draw the Outliers on plot
                    outlierLine = gPane.AddCurve("Outliers", outlierList, Color.DarkGreen, ZedGraph.SymbolType.Circle)
                    outlierLine.Line.IsVisible = False
                    outlierLine.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.DarkGreen)
                    outlierLine.Symbol.Size = 4
                    outlierLine.IsOverrideOrdinal = True

                Else
                    gPane.XAxis.Scale.Min = 0
                    gPane.XAxis.Scale.Max = 10
                    gPane.YAxis.Scale.Min = 0
                    gPane.YAxis.Scale.Max = 10
                End If

                'draw the plot
                gPane.XAxis.IsVisible = True
                gPane.YAxis.IsVisible = True

                pane.AxisChange(g)
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGBoxWhisker.RenderGraph" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function CalcBoxPlot_Monthly(ByRef medianPtList As ZedGraph.PointPairList, ByRef meanPtList As ZedGraph.PointPairList, ByRef boxes As BoxPlot(), ByRef xAxisLabels As String(), ByRef min As Double, ByRef max As Double) As Integer
        'This function calculates the Mean and Median point lists, boxes, and x-axis lables for the Monthly Box Plot, it returns the number of points created
        'Inputs:  medianPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         meanPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         boxes (ByRef) -> the collection of data for drawing each box -> values are calculated in this function : input values are junk
        '         xAxisLabels (ByRef) -> the collection of labels for the x-Axis -> values are calcaulted in this funciton : input values are junk
        '         min (byRef) -> the minimum value -> value is calculated in this function : input value is initialized
        '         max (byRef) -> the maximum value -> value is calculated in this function : input value is initialized  
        'Outputs: Integer -> the number of points (boxes) in the point list being returned
        '         medianPtList (ByRef) -> the Median Point values for each month
        '         meanPtList (ByRef) -> the Mean Point values for each month
        '         boxes (ByRef) -> the calculated values for drawing a box around each point
        '         xAxisLabels (ByRef) -> the set of labels for the x-Axis -> 1 for each month
        '         min (byRef) -> the minimum value of the whisker/outliers
        '         max (byRef) -> the maximum value of the whisker/outliers
        Const numMonths As Integer = 12 'number of months in the year -> Monthly will always have this many points
        Dim i, j As Integer 'counter
        Dim monthData As Data.DataTable 'clone of m_VisPlotData -> used to pull the data for each individual month 
        Dim validRows As Data.DataRow() = Nothing 'collection of valid data for the current month
        Dim numValid As Integer 'number of valid rows retrieved
        Try
            'TODO: Michelle: Remove the message box -> for testing only
            'MsgBox("Calculating the Data for the Monthly Box Plot")

            '1. Create the Mean, Median point list
            If Not (medianPtList) Is Nothing Then
                If medianPtList.Count > 0 Then
                    medianPtList.Clear()
                End If
            Else
                medianPtList = New ZedGraph.PointPairList()
            End If
            If Not (meanPtList) Is Nothing Then
                If meanPtList.Count > 0 Then
                    meanPtList.Clear()
                End If
            Else
                meanPtList = New ZedGraph.PointPairList()
            End If

            '2. Create Axis labels
            xAxisLabels = CreateMonthLabels()

            '3. Get data for each month, calculate stats
            ReDim boxes(numMonths - 1)
            monthData = m_Data.Clone()
            For i = 0 To numMonths - 1
                '4. get the data for the current month
                'validRows = m_VisPlotData.Select(db_fld_ValDTMonth & " = " & (i + 1) & " AND " & db_fld_ValCensorCode & " <> " & db_val_valCensorCode_lt, db_fld_ValValue & " ASC")
                'NOTE: INCLUDE the censored data
                validRows = m_Data.Select(db_outFld_ValDTMonth & " = " & (i + 1), "DataValue ASC")
                numValid = validRows.Length()
                'see if have any points for this month
                If numValid > 0 Then
                    'add the data for this month to monthData
                    If monthData.Rows.Count > 0 Then
                        monthData.Clear()
                    End If
                    For j = 0 To numValid - 1
                        monthData.ImportRow(validRows(j))
                    Next j
                    '5. calculate stats on data
                    If (boxes(i) Is Nothing) Then
                        boxes(i) = New BoxPlot
                    End If
                    CalcBoxPlotStats(numValid, monthData, boxes(i))

                    '6. calculate,add the point to ptList
                    'set x,y values for this box
                    boxes(i).xValue = i + 1
                    boxes(i).yValue = boxes(i).median
                    'add the point
                    medianPtList.Add(i, boxes(i).yValue, xAxisLabels(i) & ", " & "Median = " & boxes(i).yValue)
                    meanPtList.Add(i, boxes(i).mean, xAxisLabels(i) & ", " & "Mean = " & boxes(i).mean)

                    '7. Calc Outliers
                    'set the min,max to Lower,Upper Adjacent Values
                    'min
                    If boxes(i).adjacentLevel_Lower < min Then
                        min = boxes(i).adjacentLevel_Lower
                    End If
                    'max
                    If boxes(i).adjacentLevel_Upper > max Then
                        max = boxes(i).adjacentLevel_Upper
                    End If
                    'Calculate the Outliers for this set of data, set min,max values to min,Max Outlier values
                    CalcBoxPlotOutliers(numValid, monthData, boxes(i), min, max)
                Else
                    medianPtList.Add(i, ZedGraph.PointPair.Missing)
                    meanPtList.Add(i, ZedGraph.PointPair.Missing)
                End If
            Next i

            '8. Release resources
            If Not (monthData Is Nothing) Then
                monthData.Dispose()
                'monthData = Nothing
            End If
            If Not (validRows Is Nothing) Then
                ReDim validRows(0)
                'validRows = Nothing
            End If

            '9. return the number of points created
            Return numMonths
        Catch ex As Exception
            Return -1
            'ShowError("An Error occurred while calculating the Monthly Box Plot values. " & vbCrLf & "Message = " & ex.Message)
        End Try
        'return that none were created
        Return 0
    End Function

    Private Function CalcBoxPlot_Seasonal(ByRef medianPtList As ZedGraph.PointPairList, ByRef meanPtList As ZedGraph.PointPairList, ByRef boxes As BoxPlot(), ByRef xAxisLabels As String(), ByRef min As Double, ByRef max As Double) As Integer
        'This function calculates the point list, boxes, and x-axis lables for the Seasonal Box Plot, it returns the number of points created
        'Inputs:  medianPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         meanPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         boxes (ByRef) -> the collection of data for drawing each box -> values are calculated in this function : input values are junk
        '         xAxisLabels (ByRef) -> the collection of labels for the x-Axis -> values are calcaulted in this funciton : input values are junk
        '         min (byRef) -> the minimum value -> value is calculated in this function : input value is initialized
        '         max (byRef) -> the maximum value -> value is calculated in this function : input value is initialized  
        'Outputs: Integer -> the number of points (boxes) in the point list being returned
        '         medianPtList (ByRef) -> the Median Point values for each Season
        '         meanPtList (ByRef) -> the Mean Point values for each Season
        '         boxes (ByRef) -> the calculated values for drawing a box around each point
        '         xAxisLabels (ByRef) -> the set of labels for the x-Axis -> 1 for each month
        '         min (byRef) -> the minimum value of the whisker/outliers
        '         max (byRef) -> the maximum value of the whisker/outliers
        Const numSeasons As Integer = 4 'number of Seasons in the year -> Seasonal will always have this many points
        Dim i, j As Integer 'counter
        Dim seasonData As Data.DataTable 'clone of m_VisPlotData -> used to pull the data for each individual month 
        Dim validRows As Data.DataRow() = Nothing 'collection of valid data for the current month
        Dim numValid As Integer 'number of valid rows retrieved
        Try
            'TODO: Michelle: Remove the message box -> for testing only
            'MsgBox("Calculating the Data for the Seasonal Box Plot")

            '1. Create the Mean, Median point list
            If Not (medianPtList) Is Nothing Then
                If medianPtList.Count > 0 Then
                    medianPtList.Clear()
                End If
            Else
                medianPtList = New ZedGraph.PointPairList()
            End If
            If Not (meanPtList) Is Nothing Then
                If meanPtList.Count > 0 Then
                    meanPtList.Clear()
                End If
            Else
                meanPtList = New ZedGraph.PointPairList()
            End If

            '2. Create Axis labels
            xAxisLabels = CreateSeasonLabels()

            '3. Get data for each month, calculate stats
            ReDim boxes(numSeasons - 1)
            seasonData = m_Data.Clone()
            For i = 0 To numSeasons - 1
                '4. get the data for the current season
                'validRows = m_VisPlotData.Select("(" & db_fld_ValDTMonth & " = " & ((3 * i) + 1) & " OR " & db_fld_ValDTMonth & " = " & ((3 * i) + 2) & " OR " & db_fld_ValDTMonth & " = " & ((3 * i) + 3) & ") AND (" & db_fld_ValCensorCode & " <> " & db_val_valCensorCode_lt & ")", db_fld_ValValue & " ASC")
                'NOTE: INCLUDE the censored data
                validRows = m_Data.Select("(" & db_outFld_ValDTMonth & " = " & ((3 * i) + 1) & " OR " & db_outFld_ValDTMonth & " = " & ((3 * i) + 2) & " OR " & db_outFld_ValDTMonth & " = " & ((3 * i) + 3) & ")", "DataValue ASC")
                numValid = validRows.Length()
                'see if have any points for this month
                If numValid > 0 Then
                    'add the data for this month to monthData
                    If seasonData.Rows.Count > 0 Then
                        seasonData.Clear()
                    End If
                    For j = 0 To numValid - 1
                        seasonData.ImportRow(validRows(j))
                    Next j
                    '5. calculate stats on data
                    If (boxes(i) Is Nothing) Then
                        boxes(i) = New BoxPlot
                    End If
                    CalcBoxPlotStats(numValid, seasonData, boxes(i))

                    '6. calculate,add the point to ptList
                    'set x,y values for this box
                    boxes(i).xValue = i + 1
                    boxes(i).yValue = boxes(i).median
                    'add the point
                    medianPtList.Add(i, boxes(i).yValue, xAxisLabels(i) & ", " & "Median = " & boxes(i).yValue)
                    meanPtList.Add(i, boxes(i).mean, xAxisLabels(i) & ", " & "Mean = " & boxes(i).mean)

                    '7. Calc Outliers
                    'set the min,max to Lower,Upper Adjacent Values
                    'min
                    If boxes(i).adjacentLevel_Lower < min Then
                        min = boxes(i).adjacentLevel_Lower
                    End If
                    'max
                    If boxes(i).adjacentLevel_Upper > max Then
                        max = boxes(i).adjacentLevel_Upper
                    End If
                    'Calculate the Outliers for this set of data, set min,max values to min,Max Outlier values
                    CalcBoxPlotOutliers(numValid, seasonData, boxes(i), min, max)
                Else
                    medianPtList.Add(i, ZedGraph.PointPair.Missing)
                    meanPtList.Add(i, ZedGraph.PointPair.Missing)
                End If
            Next i

            '8. Release resources
            If Not (seasonData Is Nothing) Then
                seasonData.Dispose()
                'seasonData = Nothing
            End If
            If Not (validRows Is Nothing) Then
                ReDim validRows(0)
                'validRows = Nothing
            End If

            '9. return the number of points created
            Return numSeasons
        Catch ex As Exception
            Return -1
            'ShowError("An Error occurred while calculating the Seasonal Box Plot values. " & vbCrLf & "Message = " & ex.Message)
        End Try
        'return that none were created
        Return 0
    End Function

    Private Function CalcBoxPlot_Yearly(ByRef medianPtList As ZedGraph.PointPairList, ByRef meanPtList As ZedGraph.PointPairList, ByRef boxes As BoxPlot(), ByRef xAxisLabels As String(), ByRef min As Double, ByRef max As Double) As Integer
        'This function calculates the point list, boxes, and x-axis lables for the Yearly Box Plot, it returns the number of points created
        'Inputs:  medianPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         meanPtList (ByRef) -> the zedgraph PointPairList to Plot the Median values -> values are calculated in this function : input values are junk
        '         boxes (ByRef) -> the collection of data for drawing each box -> values are calculated in this function : input values are junk
        '         xAxisLabels (ByRef) -> the collection of labels for the x-Axis -> values are calcaulted in this funciton : input values are junk
        '         min (byRef) -> the minimum value -> value is calculated in this function : input value is initialized
        '         max (byRef) -> the maximum value -> value is calculated in this function : input value is initialized  
        'Outputs: Integer -> the number of points (boxes) in the point list being returned
        '         medianPtList (ByRef) -> the Median Point values for each year
        '         meanPtList (ByRef) -> the Mean Point values for each year
        '         boxes (ByRef) -> the calculated values for drawing a box around each point
        '         xAxisLabels (ByRef) -> the set of labels for the x-Axis -> 1 for each Year
        '         min (byRef) -> the minimum value of the whisker/outliers
        '         max (byRef) -> the maximum value of the whisker/outliers
        Dim numYears As Integer = 0 'number of years in selected data
        Dim i, j As Integer 'counter
        Dim yearData As Data.DataTable 'clone of m_VisPlotData -> used to pull the data for each individual month 
        Dim validRows As Data.DataRow() = Nothing 'collection of valid data for the current month
        Dim numValid As Integer = Nothing 'number of valid rows retrieved
        Dim startYear As Integer 'the beginning year of the data
        Dim endYear As Integer 'the ending year of the data
        Dim curYear As Integer 'the current year evaluating data for
        Try
            'TODO: Michelle: Remove the message box -> for testing only
            'MsgBox("Calculating the Data for the Yearly Box Plot")

            'TODO: Michelle: 
            '1. Create Axis labels
            numYears = CreateYearLabels(xAxisLabels, startYear, endYear)
            'make sure there is at least 1 year
            If numYears <= 0 Then
                'return 0
                Exit Try
            End If

            '2. Create the Mean, Median point list
            If Not (medianPtList) Is Nothing Then
                If medianPtList.Count > 0 Then
                    medianPtList.Clear()
                End If
            Else
                medianPtList = New ZedGraph.PointPairList()
            End If
            If Not (meanPtList) Is Nothing Then
                If meanPtList.Count > 0 Then
                    meanPtList.Clear()
                End If
            Else
                meanPtList = New ZedGraph.PointPairList()
            End If

            '3. Get data for each month, calculate stats
            ReDim boxes(numYears - 1)
            yearData = m_Data.Clone()
            For i = 0 To numYears - 1
                '4. get the data for the current year
                'TODO: Michelle:  -> adjust this for Year Data
                curYear = CInt(xAxisLabels(i))
                'validRows = m_VisPlotData.Select(db_fld_ValDTYear & " = " & (curYear) & " AND " & db_fld_ValCensorCode & " <> " & db_val_valCensorCode_lt, db_fld_ValValue & " ASC")
                'NOTE: INCLUDE censored data
                validRows = m_Data.Select(db_outFld_ValDTYear & " = " & (curYear), "DataValue ASC")
                numValid = validRows.Length()
                'see if have any points for this month
                If numValid > 0 Then
                    'add the data for this month to monthData
                    If yearData.Rows.Count > 0 Then
                        yearData.Clear()
                    End If
                    For j = 0 To numValid - 1
                        yearData.ImportRow(validRows(j))
                    Next j
                    '5. calculate stats on data
                    If (boxes(i) Is Nothing) Then
                        boxes(i) = New BoxPlot
                    End If
                    CalcBoxPlotStats(numValid, yearData, boxes(i))

                    '6. calculate,add the point to ptList
                    'set x,y values for this box
                    boxes(i).xValue = i + 1
                    boxes(i).yValue = boxes(i).median
                    'add the point
                    medianPtList.Add(i, boxes(i).yValue, xAxisLabels(i) & ", " & "Median = " & boxes(i).yValue)
                    meanPtList.Add(i, boxes(i).mean, xAxisLabels(i) & ", " & "Mean = " & boxes(i).mean)

                    '7. Calc Outliers
                    'set the min,max to Lower,Upper Adjacent Values
                    'min
                    If boxes(i).adjacentLevel_Lower < min Then
                        min = boxes(i).adjacentLevel_Lower
                    End If
                    'max
                    If boxes(i).adjacentLevel_Upper > max Then
                        max = boxes(i).adjacentLevel_Upper
                    End If
                    'Calculate the Outliers for this set of data, set min,max values to min,Max Outlier values
                    CalcBoxPlotOutliers(numValid, yearData, boxes(i), min, max)
                Else
                    medianPtList.Add(i, ZedGraph.PointPair.Missing)
                    meanPtList.Add(i, ZedGraph.PointPair.Missing)
                End If
            Next i

            '8. Release resources
            If Not (yearData Is Nothing) Then
                yearData.Dispose()
                'yearData = Nothing
            End If
            If Not (validRows Is Nothing) Then
                ReDim validRows(0)
                'validRows = Nothing
            End If

            '9. return the number of points created
            Return numYears
        Catch ex As Exception
            Return -1
            'ShowError("An Error occurred while calculating the Yearly Box Plot values. " & vbCrLf & "Message = " & ex.Message)
        End Try
        'return that none were created
        Return 0
    End Function

    Private Function CalcBoxPlot_Overall(ByRef medianPtList As ZedGraph.PointPairList, ByRef meanPtList As ZedGraph.PointPairList, ByRef boxes As BoxPlot(), ByRef xAxisLabels As String(), ByRef min As Double, ByRef max As Double) As Integer
        'This function calculates the point list, boxes, and x-axis labels for the Overall Box Plot, it returns the number of points created
        'Inputs:  medianPtList (ByRef) -> the zedgraph PointPairList to Plot the Median value -> value is calculated in this function : input values are junk
        '         meanPtList (ByRef) -> the zedgraph PointPairList to Plot the Median value -> value is calculated in this function : input values are junk
        '         boxes (ByRef) -> the collection of data for drawing each box -> values are calculated in this function : input values are junk
        '         xAxisLabels (ByRef) -> the collection of labels for the x-Axis -> values are calcaulted in this funciton : input values are junk
        '         min (byRef) -> the minimum value -> value is calculated in this function : input value is initialized
        '         max (byRef) -> the maximum value -> value is calculated in this function : input value is initialized  
        'Outputs: Integer -> the number of points (boxes) in the point list being returned
        '         medianPtList (ByRef) -> the overall Median Point value
        '         meanPtList (ByRef) -> the overall Mean Point value
        '         boxes (ByRef) -> the calculated values for drawing a box around each point
        '         xAxisLabels (ByRef) -> the set of labels for the x-Axis -> 1 total
        '         min (byRef) -> the minimum value of the whisker/outliers
        '         max (byRef) -> the maximum value of the whisker/outliers
        Const numPts As Integer = 5 'number of months in the year -> Overall will always have this many points
        Dim validRows() As Data.DataRow 'TODO: Document This
        Dim numValid As Integer 'number of valid rows retrieved
        Dim overallData As Data.DataTable 'TODO: Document This
        Dim i As Integer 'TODO: Document This
        Try
            'TODO: Michelle: Remove the message box -> for testing only
            'MsgBox("Calculating the Data for the Overall Box Plot")

            '1. Create the Mean, Median point list
            If Not (medianPtList) Is Nothing Then
                If medianPtList.Count > 0 Then
                    medianPtList.Clear()
                End If
            Else
                medianPtList = New ZedGraph.PointPairList()
            End If
            If Not (meanPtList) Is Nothing Then
                If meanPtList.Count > 0 Then
                    meanPtList.Clear()
                End If
            Else
                meanPtList = New ZedGraph.PointPairList()
            End If

            '2. Create Axis labels
            ReDim xAxisLabels(4)
            'xAxisLabels(2) = "Overall"

            '3. Get data for each month, calculate stats
            ReDim boxes(numPts - 1)
            overallData = m_Data.Clone()
            '4. get the valid data 
            'TODO: Michelle:  -> !!Find out if ONLY retrieving Valid values -> censorCode <> "lt", or all values!!
            validRows = m_Data.Select("", "DataValue ASC")
            numValid = validRows.Length()
            'see if have any points 
            If numValid > 0 Then
                'add the data to overallData
                For i = 0 To numValid - 1
                    overallData.ImportRow(validRows(i))
                Next i
                '5. calculate stats on data
                If (boxes(2) Is Nothing) Then
                    boxes(2) = New BoxPlot
                End If
                CalcBoxPlotStats(numValid, overallData, boxes(2))

                '6. calculate,add the point to ptList
                'set x,y values for this box
                boxes(2).xValue = 3
                boxes(2).yValue = boxes(2).median
                'add the points
                medianPtList.Add(1, ZedGraph.PointPair.Missing)
                meanPtList.Add(1, ZedGraph.PointPair.Missing)
                medianPtList.Add(2, ZedGraph.PointPair.Missing)
                meanPtList.Add(2, ZedGraph.PointPair.Missing)
                medianPtList.Add(3, boxes(2).yValue, xAxisLabels(2) & ", " & "Median = " & boxes(2).yValue)
                meanPtList.Add(3, boxes(2).mean, xAxisLabels(2) & ", " & "Mean = " & boxes(2).mean)
                medianPtList.Add(4, ZedGraph.PointPair.Missing)
                meanPtList.Add(4, ZedGraph.PointPair.Missing)
                medianPtList.Add(5, ZedGraph.PointPair.Missing)
                meanPtList.Add(5, ZedGraph.PointPair.Missing)

                '7. Calc Outliers
                'set the min,max to Lower,Upper Adjacent Values
                'min
                If boxes(2).adjacentLevel_Lower < min Then
                    min = boxes(2).adjacentLevel_Lower
                End If
                'max
                If boxes(2).adjacentLevel_Upper > max Then
                    max = boxes(2).adjacentLevel_Upper
                End If
                'Calculate the Outliers for this set of data, set min,max values to min,Max Outlier values
                CalcBoxPlotOutliers(numValid, m_Data, boxes(2), min, max)
            End If

            '8. return the number of points created
            Return numPts
        Catch ex As Exception
            Return -1
            'ShowError("An Error occurred while calculating the Overall Box Plot values. " & vbCrLf & "Message = " & ex.Message)
        End Try
        'return that none were created
        Return 0
    End Function

    Private Sub CalcBoxPlotOutliers(ByVal numRows As Integer, ByRef monthData As Data.DataTable, ByRef boxData As BoxPlot, ByRef min As Double, ByRef max As Double)
        '
        'Inputs:  
        'Outputs: 
        Dim i As Integer 'counter
        Dim curValue As Double 'current value checking
        Try
            'TODO: Michelle: remove the message box -> for testing only
            'MsgBox("Calculating the Outliers for a set of data for the Box Plot")

            'TODO: Michelle: 
            '1. move through values 
            For i = 0 To numRows - 1
                'get the value
                curValue = monthData.Rows(i).Item("DataValue")
                '2. find those that are below the Lower Adjacent Level -> add them to boxData.Outliers_Lower
                If (curValue < boxData.adjacentLevel_Lower) Then
                    boxData.AddOutlier_Lower(curValue)
                End If
                '3. find those that are above the Upper Adjacent Level -> add them to boxData.Outliers_Upper
                If (curValue > boxData.adjacentLevel_Upper) Then
                    boxData.AddOutlier_Upper(curValue)
                End If
                '4. compare to min,max
                'min
                If curValue < min Then
                    min = curValue
                End If
                'max
                If curValue > max Then
                    max = curValue
                End If
            Next i
        Catch ex As Exception
            Clear()
            'ShowError("An Error occurred while calculating the the Outliers for the Box Plot on the Visualize Tab." & vbCrLf & "Message = " & ex.Message)
        End Try
    End Sub

    Private Sub DrawBoxPlot(ByRef gPane As ZedGraph.GraphPane, ByVal boxData As BoxPlot)
        'Dim x1, y1, x2, y2 As Double 'x,y values for bounds of rectangles
        Dim upperBoxShaded As ZedGraph.BoxObj 'shaded box between 75% quantile and Upper 95% Confidence Limit on the Median
        Dim lowerBoxShaded As ZedGraph.BoxObj 'shaded box between 25% quantile and Lower 95% Confidence Limit on the Median
        Dim hourglassPts As ZedGraph.PointD() 'points for the Hourglass outline to make up the box outline
        Dim hourglassOutline As ZedGraph.PolyObj 'Outline for the Hourglass
        Dim confIntervalLine As ZedGraph.LineObj 'Line in center -> 95% Confidence Interval on the Mean
        Dim whisker_Upper As ZedGraph.LineObj 'Upper Whisker -> Upper Adjacent Level
        Dim lineToWhisker_Upper As ZedGraph.LineObj 'Line from Upper Whisker to 75% quantile (top of box)
        Dim whisker_Lower As ZedGraph.LineObj 'Lower Whisker -> Lower Adjacent Level
        Dim lineToWhisker_Lower As ZedGraph.LineObj 'Line from Lower Whisker to 25% quantil (bottom of box)
        Try
            'TODO: Michelle: Remove messagebox -> for testing only!!
            'MsgBox("Drawing the Box Plot")

            'TODO: Michelle:  ->
            '1. Draw Confidence Interval -> red line
            confIntervalLine = New ZedGraph.LineObj(Color.Red, boxData.xValue, boxData.confidenceInterval95_Upper, boxData.xValue, boxData.confidenceInterval95_Lower)
            confIntervalLine.IsClippedToChartRect = True
            confIntervalLine.ZOrder = ZedGraph.ZOrder.D_BehindCurves
            gPane.GraphObjList.Add(confIntervalLine)

            '2. Draw Upper Whisker, line
            'whisker
            whisker_Upper = New ZedGraph.LineObj(Color.Black, boxData.xValue - 0.15, boxData.adjacentLevel_Upper, boxData.xValue + 0.15, boxData.adjacentLevel_Upper)
            whisker_Upper.IsClippedToChartRect = True
            whisker_Upper.ZOrder = ZedGraph.ZOrder.D_BehindCurves
            whisker_Upper.PenWidth = 2
            gPane.GraphObjList.Add(whisker_Upper)
            'line between whisker, top of hourglass
            lineToWhisker_Upper = New ZedGraph.LineObj(Color.Black, boxData.xValue, boxData.adjacentLevel_Upper, boxData.xValue, boxData.quantile_75th)
            lineToWhisker_Upper.IsClippedToChartRect = True
            lineToWhisker_Upper.ZOrder = ZedGraph.ZOrder.D_BehindCurves
            lineToWhisker_Upper.PenWidth = 2
            gPane.GraphObjList.Add(lineToWhisker_Upper)

            '3. Draw Lower Whisker, line
            'whisker
            whisker_Lower = New ZedGraph.LineObj(Color.Black, boxData.xValue - 0.15, boxData.adjacentLevel_Lower, boxData.xValue + 0.15, boxData.adjacentLevel_Lower)
            whisker_Lower.IsClippedToChartRect = True
            whisker_Lower.ZOrder = ZedGraph.ZOrder.D_BehindCurves
            whisker_Lower.PenWidth = 2
            gPane.GraphObjList.Add(whisker_Lower)
            'line between whisker, top of hourglass
            lineToWhisker_Lower = New ZedGraph.LineObj(Color.Black, boxData.xValue, boxData.quantile_25th, boxData.xValue, boxData.adjacentLevel_Lower)
            lineToWhisker_Lower.IsClippedToChartRect = True
            lineToWhisker_Lower.ZOrder = ZedGraph.ZOrder.D_BehindCurves
            lineToWhisker_Lower.PenWidth = 2
            gPane.GraphObjList.Add(lineToWhisker_Lower)

            '4. Draw Hourglass outline
            'create points
            ReDim hourglassPts(10)
            'top
            hourglassPts(0) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.quantile_75th)
            hourglassPts(1) = New ZedGraph.PointD(boxData.xValue + 0.3, boxData.quantile_75th)
            'right side
            hourglassPts(2) = New ZedGraph.PointD(boxData.xValue + 0.3, boxData.confidenceLimit95_Upper)
            hourglassPts(3) = New ZedGraph.PointD(boxData.xValue + 0.15, boxData.median)
            hourglassPts(4) = New ZedGraph.PointD(boxData.xValue + 0.3, boxData.confidenceLimit95_Lower)
            'bottom
            hourglassPts(5) = New ZedGraph.PointD(boxData.xValue + 0.3, boxData.quantile_25th)
            hourglassPts(6) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.quantile_25th)
            'left side
            hourglassPts(7) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.confidenceLimit95_Lower)
            hourglassPts(8) = New ZedGraph.PointD(boxData.xValue - 0.15, boxData.median)
            hourglassPts(9) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.confidenceLimit95_Upper)
            'repeat 1st point -> end of poly
            hourglassPts(10) = New ZedGraph.PointD(boxData.xValue - 0.3, boxData.quantile_75th)
            'create outline
            hourglassOutline = New ZedGraph.PolyObj(hourglassPts)
            hourglassOutline.Border.Color = Color.SlateGray
            hourglassOutline.Border.IsVisible = True
            hourglassOutline.Fill.IsVisible = False
            hourglassOutline.IsClippedToChartRect = True
            hourglassOutline.ZOrder = ZedGraph.ZOrder.D_BehindCurves
            gPane.GraphObjList.Add(hourglassOutline)

            '5. Draw Upper shaded box ->Upper 95% Confidence Limit to 75% quantile value
            If boxData.quantile_75th > boxData.confidenceLimit95_Upper Then
                upperBoxShaded = New ZedGraph.BoxObj(1, 1, 1, 1)
                'If upperBoxShaded.Location Is Nothing Then
                '    upperBoxShaded.Location = New ZedGraph.Location()
                'End If
                upperBoxShaded.Location.X = boxData.xValue - 0.3
                upperBoxShaded.Location.Width = 0.6
                upperBoxShaded.Location.Y = boxData.quantile_75th
                upperBoxShaded.Location.Height = -Math.Round(boxData.quantile_75th - boxData.confidenceLimit95_Upper, 3)
                'Else
                'upperBoxShaded.Location.Y = boxData.confidenceLimit95_Upper
                'upperBoxShaded.Location.Height = Math.Round(boxData.quantile_75th - boxData.confidenceLimit95_Upper, 3)

                upperBoxShaded.Border.IsVisible = False
                upperBoxShaded.Fill = New ZedGraph.Fill(System.Drawing.Color.LightGray)
                upperBoxShaded.IsClippedToChartRect = True
                upperBoxShaded.ZOrder = ZedGraph.ZOrder.D_BehindCurves
                gPane.GraphObjList.Add(upperBoxShaded)
            End If
            '6. Draw Lower shaded box ->Lower 95% Confidence Limit to 25% quantile value
            If boxData.confidenceLimit95_Lower > boxData.quantile_25th Then
                lowerBoxShaded = New ZedGraph.BoxObj(1, 1, 1, 1)
                'If upperBoxShaded.Location Is Nothing Then
                '    upperBoxShaded.Location = New ZedGraph.Location()
                'End If
                lowerBoxShaded.Location.X = boxData.xValue - 0.3
                lowerBoxShaded.Location.Width = 0.6

                lowerBoxShaded.Location.Y = boxData.confidenceLimit95_Lower
                lowerBoxShaded.Location.Height = -Math.Round(boxData.confidenceLimit95_Lower - boxData.quantile_25th, 3)
                'Else
                'lowerBoxShaded.Location.Y = boxData.quantile_25th
                'lowerBoxShaded.Location.Height = Math.Round(boxData.confidenceLimit95_Lower - boxData.quantile_25th, 3)
                lowerBoxShaded.Border.IsVisible = False
                lowerBoxShaded.Fill = New ZedGraph.Fill(System.Drawing.Color.LightGray)
                lowerBoxShaded.IsClippedToChartRect = True
                lowerBoxShaded.ZOrder = ZedGraph.ZOrder.D_BehindCurves
                gPane.GraphObjList.Add(lowerBoxShaded)
            End If

            '7. Release resources
            If Not (hourglassPts Is Nothing) Then
                ReDim hourglassPts(0)
                'hourglassPts = Nothing
            End If
            'If Not (hourglassOutline Is Nothing) Then
            'hourglassOutline = Nothing
            'End If
            'If Not (upperBoxShaded Is Nothing) Then
            'upperBoxShaded = Nothing
            'End If
            'If Not (lowerBoxShaded Is Nothing) Then
            'lowerBoxShaded = Nothing
            'End If
            'If Not (confIntervalLine Is Nothing) Then
            'IntervalLine = Nothing
            'End If
            'If Not (whisker_Upper Is Nothing) Then
            'whisker_Upper = Nothing
            'End If
            'If Not (lineToWhisker_Upper Is Nothing) Then
            'lineToWhisker_Upper = Nothing
            'End If
            'If Not (whisker_Lower Is Nothing) Then
            'whisker_Lower = Nothing
            'End If
            'If Not (lineToWhisker_Lower Is Nothing) Then
            'lineToWhisker_Lower = Nothing
            'End If
        Catch ex As Exception
            Clear()
            'ShowError("An Error occurred while drawing a Box/Whisker for the Box Plot. " & vbCrLf & "Message = " & ex.Message)
        End Try
    End Sub

    Private Sub DrawOutliers(ByRef outlierPtList As ZedGraph.PointPairList, ByVal curBoxData As BoxPlot) 'ByRef gPane As ZedGraph.GraphPane, ByVal boxData As clsBoxPlot)
        Dim i As Integer 'counter
        Dim curValue As Double 'TODO: Document This

        Try
            'TODO: Michelle: Remove message box -> for testing only
            'MsgBox("Setting Outliers" & vbCrLf & "X = " & curBoxData.xValue)

            'TODO: Michelle: 
            '1. validate data
            If curBoxData Is Nothing Then
                Exit Try
            End If
            If outlierPtList Is Nothing Then
                outlierPtList = New ZedGraph.PointPairList
            End If

            '2. Add Lower Outliers
            If curBoxData.numOutliers_Lower > 0 Then
                For i = 0 To curBoxData.numOutliers_Lower - 1
                    curValue = curBoxData.outlierValue_Lower(i)
                    If curValue <> -1 Then
                        outlierPtList.Add(curBoxData.xValue, curValue)
                    End If
                Next i
            End If

            '3. Draw Upper Outliers
            If curBoxData.numOutliers_Upper > 0 Then
                For i = 0 To curBoxData.numOutliers_Upper - 1
                    curValue = curBoxData.outlierValue_Upper(i)
                    If curValue <> -1 Then
                        'add the point
                        outlierPtList.Add(curBoxData.xValue, curValue)
                    End If
                Next i
            End If
        Catch ex As Exception
            Clear()
            'ShowError("An Error occurred while drawing the Outliers for the Box Plot." & vbCrLf & "Message = " & ex.Message)
        End Try
    End Sub

    Private Function CreateMonthLabels() As String()
        Dim labels(11) As String 'TODO: Document This
        'set the labels for each month
        labels(0) = "Jan"
        labels(1) = "Feb"
        labels(2) = "Mar"
        labels(3) = "Apr"
        labels(4) = "May"
        labels(5) = "Jun"
        labels(6) = "Jul"
        labels(7) = "Aug"
        labels(8) = "Sep"
        labels(9) = "Oct"
        labels(10) = "Nov"
        labels(11) = "Dec"

        Return labels
    End Function

    Private Function CreateSeasonLabels() As String()
        Dim labels(3) As String  'TODO: Document This
        'set the labels for each month
        labels(0) = "Winter"
        labels(1) = "Spring"
        labels(2) = "Summer"
        labels(3) = "Fall"

        Return labels
    End Function

    Private Function CreateYearLabels(ByRef labels As String(), ByRef startYear As Integer, ByRef endYear As Integer) As Integer
        Dim i As Integer 'counter
        Dim numYears As Integer 'count of years in selected data
        Dim curYear As Integer 'current year creating a label for
        Try
            'TODO: Michelle: remove message box -> for testing only!!
            'MsgBox("Creating the Year Labels for the Box/Whisker Plot")

            '1. calculate the start,end year
            startYear = m_Data.Compute("Min(" & db_outFld_ValDTYear & ")", "")
            endYear = m_Data.Compute("Max(" & db_outFld_ValDTYear & ")", "")

            '2. calculate the number of years
            numYears = (endYear - startYear) + 1

            '3. create the labels -> one for each year
            ReDim labels(numYears - 1)
            For i = 0 To numYears - 1
                curYear = startYear + i
                If (curYear >= startYear) AndAlso (curYear <= endYear) Then
                    labels(i) = curYear
                End If
            Next i

            Return numYears
        Catch ex As Exception
            Return -1
            'ShowError("An Error occurred while creating the Year labels for the Box/Whisker Plot." & vbCrLf & "Message = " & ex.Message)
        End Try
        'return 0
        Return 0
    End Function

    Private Sub CalcBoxPlotStats(ByVal numRows As Integer, ByRef data As Data.DataTable, ByRef boxData As BoxPlot)
        'Calculates and stores the stats for the given set of data for a BoxPlot
        'Inputs:  data (ByRef) -> the set of data to calculate the stats on
        '         boxData (ByRef) -> the clsBoxPlot object to store the calculated data into -> NOTE: the xValue should have already been set
        'Outputs: data (ByRef) -> 
        '         boxData (ByRef) -> the calculated stats so can draw the boxPlot at this point
        Dim variance As Double 'the variance of the values in data
        Dim stdDev As Double 'the standard deviation of the values in data
        Dim max As Double 'the maximum value in data
        Dim min As Double 'the minimum value in data
        Dim v As Double 'used to calculate the lower,upper whiskers (adjacent levels)
        Try
            'make sure have data
            If numRows = 0 OrElse data.Rows.Count <= 0 Then
                Exit Try
            End If

            'TODO: Michelle: remove msg box -> for testing only
            'MsgBox("Calculating the Box Plot Statistics")

            'TODO: Michelle
            '1. Calculate the 25% and 75% quantile values
            boxData.quantile_25th = data.Rows(Math.Floor(numRows / 4)).Item("DataValue")
            boxData.quantile_75th = data.Rows(Math.Floor(numRows / 4) * 3).Item("DataValue")

            '2. calculate the Mean, Median
            'Mean
            boxData.mean = Math.Round(data.Compute("Avg(DataValue)", ""), 3)
            'Median
            If (numRows Mod 2 = 0 And numRows > 1) Then
                'even number of values -> take the middle two and average them
                Dim val1 As Double 'first of the middle values -> (numRows/2) - 1
                Dim val2 As Double 'second of the middle value -> (numrows/2)
                val1 = data.Rows((numRows / 2) - 1).Item("DataValue")
                val2 = data.Rows(numRows / 2).Item("DataValue")
                boxData.median = (val1 + val2) / 2
            Else
                boxData.median = data.Rows(Math.Ceiling((numRows / 2) - 1)).Item("DataValue")
            End If

            '3. Calculate the upper and lower whiskers
            max = data.Compute("Max(DataValue)", "")
            min = data.Compute("Min(DataValue)", "")
            v = (boxData.quantile_75th - boxData.quantile_25th) * 1.5
            'lower whisker -> Lower Adjacent Level
            If (boxData.quantile_25th - v) < min Then
                boxData.adjacentLevel_Lower = min
            Else
                boxData.adjacentLevel_Lower = boxData.quantile_25th - v
            End If
            'upper whisker -> Upper Adjacent Level
            If (boxData.quantile_75th + v) > max Then
                boxData.adjacentLevel_Upper = max
            Else
                boxData.adjacentLevel_Upper = boxData.quantile_75th + v
            End If

            '4. Calculate the 95% Confidence Interval on the Mean,Calculate the 95% Confidence Limit on the Median
            If Not (data.Compute("Var(DataValue)", "") Is System.DBNull.Value) Then
                variance = data.Compute("Var(DataValue)", "")
                stdDev = Math.Sqrt(variance)
            Else
                stdDev = 0
            End If
            'Confidence Interval on Mean
            boxData.confidenceInterval95_Lower = boxData.mean - 1.96 * (stdDev / (Math.Sqrt(numRows)))
            boxData.confidenceInterval95_Upper = boxData.mean + 1.96 * (stdDev / (Math.Sqrt(numRows)))
            'Confidence Limit on Median
            boxData.confidenceLimit95_Lower = boxData.median - 1.96 * (stdDev / (Math.Sqrt(numRows)))
            boxData.confidenceLimit95_Upper = boxData.median + 1.96 * (stdDev / (Math.Sqrt(numRows)))
        Catch ex As Exception
            Clear()
            'ShowError("An Error occurred while calculating the Box Plot Statistics for the Visualize Tab. " & vbCrLf & "Message = " & ex.Message)
        End Try
    End Sub

End Class
