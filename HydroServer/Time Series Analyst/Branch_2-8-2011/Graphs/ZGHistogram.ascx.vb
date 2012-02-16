Imports ZedGraph
Imports System.Drawing

Partial Class Graphs_ZGHistogram
    Inherits System.Web.UI.UserControl

    Public Shared m_Data As Data.DataTable
    Public Shared m_Site As String
    Public Shared m_Var As String
    Public Shared m_Options As PlotOptions
    Private Const m_MaxHistBins As Integer = 20 'holds the maximum number of Bins for a Histogram plot, 20 = selected due to spacing of values on the plot
    Private m_StdDev As Double = 0

    Public Property Width() As Integer
        Get
            Return HistogramPlot.Width
        End Get
        Set(ByVal value As Integer)
            HistogramPlot.Width = value
        End Set
    End Property
    Public Property Height() As Integer
        Get
            Return HistogramPlot.Height
        End Get
        Set(ByVal value As Integer)
            HistogramPlot.Height = value
        End Set
    End Property

    Public Sub Plot(ByRef objDataTable As Data.DataTable, ByVal strSiteName As String, ByVal strVariableName As String, ByVal strVariableUnits As String, ByRef objOptions As PlotOptions, ByVal e_StdDev As Double) ', Optional ByVal e_StdDev As Double = 0))
        Try
            If Not (m_Data Is Nothing) Then
                m_Data.Clear()
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
            Throw New Exception("Error Occured in ZGHistogram.Plot" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Replot(ByVal options As PlotOptions)
        Try
            m_Options = options
            HistogramPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGHistogram.Replot" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Clear()
        Try
            If Not (m_Data Is Nothing) Then
                m_Data.Dispose()
                m_Data = Nothing
            End If

            'GraphData()
            HistogramPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGHistogram.Clear" & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Sub HistogramPlot_RenderGraph(ByVal g As System.Drawing.Graphics, ByVal pane As ZedGraph.MasterPane) Handles HistogramPlot.RenderGraph
        Try
            If ((m_Data Is Nothing) OrElse (m_Data.Rows.Count < 1)) Then 'OrElse ((m_DataSet Is Nothing) OrElse (m_DataSet.Tables.Count < 1)) Then
                HistogramPlot.CurveList.Clear()
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
                Dim i As Integer 'counter
                Dim gPane As ZedGraph.GraphPane 'GraphPane of the zg5Histogram plot object -> used to set data and characteristics
                Dim ptList As ZedGraph.PointPairList 'collection of points fro the Histogram chart
                Dim histBars As ZedGraph.BarItem 'Bar Item curve -> Histogram bars on the plot
                Dim numValid As Integer 'number of valid rows returned
                Dim numBins As Integer 'number of bars in the bar chart
                Dim minValue As Double 'lowest valid value
                Dim maxValue As Double 'highest valid value
                Dim xRange As Double 'range of Values with padding
                Dim dX As Double 'distance between bins
                Dim totalCount As Integer 'TODO: Document This
                Dim maxTotal As Integer 'TODO: Document This
                Dim lastValue As Double 'TODO: Document This
                Dim xValue As Double 'TODO: Document This
                Dim nextXValue As Double 'TODO: Document This

                '1. set the Graph Pane, graphics object
                gPane = pane(0)
                gPane.CurveList.Clear()
                'g = zg5Histogram.CreateGraphics

                '2. Set Graph Properties
                gPane.XAxis.IsVisible = True
                gPane.XAxis.MajorGrid.IsVisible = True
                gPane.XAxis.MajorGrid.Color = Color.Gray
                gPane.XAxis.Title.Text = m_Var
                gPane.YAxis.MajorGrid.IsVisible = True
                gPane.YAxis.MajorGrid.Color = Color.Gray
                gPane.YAxis.Title.Text = "Number of Observations"
                gPane.Title.Text = m_Site

                '6. Create the Pts for the Bars
                'TODO: Michelle: Track the number of bins created -> set the tboxHPNumBins.Text value

                'set min,max,range values
                minValue = Math.Floor(CDbl(m_Data.Compute("Min( DataValue )", "")) - (0.2 * m_StdDev))
                maxValue = Math.Ceiling(CDbl(m_Data.Compute("Max( DataValue )", "")) + (0.2 * m_StdDev))
                numValid = m_Data.Rows.Count

                'gPane.XAxis.Scale.Min = Int(minValue)
                'gPane.XAxis.Scale.Max = Int(maxValue + 1)

                xRange = (maxValue - minValue) 'Math.Round(maxValue - minValue, 3)
                'get the number of bins -> bars, tic marks
                'figure out for self
                numBins = CalculateHistogramNumBins(numValid)
                If numBins > m_MaxHistBins Then
                    numBins = m_MaxHistBins
                End If

                'dx = range/(#bins - 1)
                dX = (xRange / (numBins)).ToString("0.###e0") 'Math.Round(xRange / (numBins), 3)
                'modify dX so is a discreet value (a whole number) value -> modified dX will always be smaller than calculated to ensure the correct number of bins!
                'If dX > Math.Floor(dX) + 0.5 Then
                '    dX = Math.Ceiling(dX)
                'Else
                '    dX = Math.Floor(dX)
                'End If
                'Do a check if dx = 0, make it minimum of 1
                If dX <= 0 Then
                    dX = 1
                End If

                'get the count of values for each value, add it to ptList
                ptList = New ZedGraph.PointPairList

                lastValue = 0
                xValue = minValue
                nextXValue = Math.Round(xValue + dX, 3)
                totalCount = 0
                maxTotal = 0

                Dim xLabels(numBins) As String
                For i = 0 To numBins - 1
                    If xValue <= maxValue Then
                        '1. get the count of values in range
                        totalCount = m_Data.Compute("Count( DataValue )", "(( DataValue >= " & xValue & ") AND (DataValue < " & nextXValue & "))")
                        '2. add the point to the list
                        'ptList.Add(xValue, totalCount, xValue & " - " & nextXValue)
                        ptList.Add(CDbl((xValue + (dX / 2)).ToString("0.###e0")), totalCount, xValue & " - " & nextXValue)
                        '3. create the tic mark,lable
                        'xLabels(i) = xValue
                        '4. see if totalCount > maxTotal
                        If totalCount > maxTotal Then
                            maxTotal = totalCount
                        End If
                        '5. calculate next xValue,nextXValue
                        xValue = nextXValue
                        nextXValue = Math.Round(xValue + dX, 3)
                    End If
                    xLabels(i) = ""
                Next i

                gPane.XAxis.Scale.Min = minValue
                gPane.XAxis.Scale.Max = maxValue
                'gPane.XAxis.Scale.MinGrace = 0.001
                'gPane.XAxis.Scale.MaxGrace = 0.001
                gPane.XAxis.Scale.MajorStep = dX
                gPane.XAxis.Scale.BaseTic = minValue
                gPane.XAxis.MinorTic.Color = Color.Transparent
                gPane.XAxis.Type = AxisType.Linear
                gPane.BarSettings.MinBarGap = 0
                gPane.BarSettings.MinClusterGap = 0
                gPane.BarSettings.Type = BarType.Overlay

                'gPane.XAxis.Scale.TextLabels = xLabels


                '7. Plot the Data
                'create the bars
                histBars = gPane.AddBar("histogram", ptList, Color.Black)

                'set bar settings
                gPane.XAxis.MajorTic.IsBetweenLabels = True
                ' '' '' '' '' ''gPane.XAxis.Scale.IsLabelsInside = False

                'draw the plot
                gPane.XAxis.IsVisible = True
                gPane.YAxis.IsVisible = True

                pane.AxisChange(g)
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGHistogram.RenderGraph" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function CalculateHistogramNumBins(ByVal numValues As Double) As Integer
        'this function calculates the number of Bins -> Bars for the Histogram Chart on the Visualize Tab
        'Inputs:  numValues -> the total number of valid values
        'Outputs: Integer -> the number of bins needed
        Try
            Dim numBins As Integer = 0 'TODO: Document This
            Dim top As Double 'top half of the equation
            Dim bottom As Double 'bottom half of the equation
            '#bins = ((2.303*squareRoot(n))/(natural log(n)))*(2)

            top = 2.303 * Math.Sqrt(numValues)
            bottom = Math.Log(numValues)
            numBins = Math.Floor((top / bottom) * 2)

            'TODO: FIX HERE
            If numBins < 5 Then
                numBins = 5
            End If

            Return numBins
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGHistogram.CalculateHistogramNumBins" & vbCrLf & ex.Message)
        End Try
    End Function

End Class
