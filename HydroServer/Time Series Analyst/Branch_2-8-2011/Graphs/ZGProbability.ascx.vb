Imports ZedGraph
Imports System.Drawing

Partial Class Graphs_ZGProbability
    Inherits System.Web.UI.UserControl

    Public Shared m_Data As Data.DataTable
    'Public Shared m_DataRows() As Data.DataRow
    Public Shared m_Site As String
    Public Shared m_Var As String
    Public Shared m_Options As PlotOptions
    Private m_StdDev As Double

    'Private m_XLabels() As String = _
    '{"0.01|-3.892", "0.02|-3.5", "0.1|-3.095", "1|-2.323", "2|-2.055", _
    '"5|-1.645", "10|-1.282", "20|-0.842", "30|-0.524", "40|-0.254", _
    '"50|0", "60|0.254", "70|0.524", "80|0.842", "90|1.282", _
    '"95|1.645", "98|2.055", "99|2.323", "99.9|3.095", "99.98|3.5", _
    '"99.99|3.892"}

    Public Property Width() As Integer
        Get
            Return ProbabilityPlot.Width
        End Get
        Set(ByVal value As Integer)
            ProbabilityPlot.Width = value
        End Set
    End Property
    Public Property Height() As Integer
        Get
            Return ProbabilityPlot.Height
        End Get
        Set(ByVal value As Integer)
            ProbabilityPlot.Height = value
        End Set
    End Property

    Public Sub Plot(ByRef objDataTable As Data.DataTable, ByVal strSiteName As String, ByVal strVariableName As String, ByVal strVariableUnits As String, ByRef objOptions As PlotOptions, Optional ByVal e_StdDev As Double = 0)
        Try
            If Not (m_Data Is Nothing) Then
                m_Data.Dispose()
                'm_Data = Nothing
            End If
            'If Not (m_DataRows.Length < 1) Then
            '    ReDim m_DataRows(0)
            'End If

            m_Data = objDataTable.Copy
            'm_DataRows = objDataTable.Select("", "DataValue ASC")
            m_Site = strSiteName
            m_Var = strVariableName & " - " & strVariableUnits
            m_Options = objOptions



            If (e_StdDev = 0) And (Not (m_Data Is Nothing)) And (m_Data.Rows.Count > 0) Then
                m_StdDev = Statistics.StandardDeviation(m_Data)
            Else
                m_StdDev = e_StdDev
            End If
            ProbabilityPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGProbability.Plot" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Replot(ByVal options As PlotOptions)
        Try
            m_Options = options
            ProbabilityPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGProbability.Replot" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Clear()
        Try
            If Not (m_Data Is Nothing) Then
                m_Data.Dispose()
                m_Data = Nothing
            End If

            'GraphData()
            ProbabilityPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGProbability.Clear" & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Sub ProbabilityPlot_RenderGraph(ByVal g As System.Drawing.Graphics, ByVal pane As ZedGraph.MasterPane) Handles ProbabilityPlot.RenderGraph
        Try
            If ((m_Data Is Nothing) OrElse (m_Data.Rows.Count < 1)) Then 'OrElse ((m_DataSet Is Nothing) OrElse (m_DataSet.Tables.Count < 1)) Then
                ProbabilityPlot.CurveList.Clear()
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
                Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgProbability plot object -> used to set data and characteristics
                'Dim g As Drawing.Graphics 'graphics object of the zgProbability plot object -> used to redraw/update the plot
                'Dim ptList As ZedGraph.PointPairList 'collection of points for the Probability plot
                'Dim bflPtList As ZedGraph.PointPairList 'TODO: Document This
                Dim probLine As ZedGraph.LineItem 'TODO: Document This
                'Dim bflLine As ZedGraph.LineItem 'TODO: Document This
                Dim validRows() As Data.DataRow 'TODO: Document This
                Dim numRows As Integer 'TODO: Document This
                Dim curValue As Double 'TODO: Document This
                Dim curX As Double 'TODO: Document This
                Dim curFreq As Double 'TODO: Document This
                Try
                    'TODO: Michelle: Remove the message box -> for testing only!!
                    'MsgBox("Graphing the Probability Plot")

                    'TODO: Michelle: 
                    '1. Set the Graph Pane, graphics object
                    gPane = pane(0)
                    gPane.CurveList.Clear()
                    'g = zg5Probability.CreateGraphics

                    'get all data(even censored ones), order by Value
                    validRows = m_Data.Select("", "DataValue ASC")
                    numRows = validRows.GetLength(0)
                    'make sure data was selected
                    If (numRows = 0) Then
                        Throw New Exception("No data selected")
                    End If

                    '5. Set Graph Properties
                    'x-axis
                    gPane.XAxis.IsVisible = True
                    gPane.XAxis.MajorTic.Size = 0
                    gPane.XAxis.MinorTic.Size = 0
                    gPane.XAxis.Title.Text = vbCrLf & vbCrLf & "Cumulative Frequency < Stated Value %"
                    gPane.XAxis.Title.Gap = 0.2
                    gPane.XAxis.Type = ZedGraph.AxisType.Linear
                    gPane.XAxis.Scale.IsVisible = False
                    gPane.XAxis.Scale.Min = -4.0
                    gPane.XAxis.Scale.Max = 4.0
                    gPane.XAxis.MajorTic.IsAllTics = False
                    gPane.XAxis.Scale.MinGrace = 0
                    gPane.XAxis.Scale.MaxGrace = 0
                    'y-axis
                    gPane.YAxis.IsVisible = True
                    gPane.YAxis.MajorGrid.IsVisible = True
                    gPane.YAxis.MajorGrid.Color = Drawing.Color.Gray
                    gPane.YAxis.Title.Text = m_Var
                    gPane.YAxis.Type = ZedGraph.AxisType.Linear
                    gPane.YAxis.Scale.MinGrace = 0.025
                    gPane.YAxis.Scale.MaxGrace = 0.025
                    gPane.YAxis.Scale.Min = m_Data.Compute("Min(DataValue)", "") - (0.2 * m_StdDev)
                    gPane.YAxis.Scale.Max = m_Data.Compute("Max(DataValue)", "") + (0.2 * m_StdDev)

                    gPane.Title.Text = m_Site

                    '6. Create the Pts for the Line
                    probLine = New ZedGraph.LineItem("ProbCurve")
                    For i = 0 To numRows - 1
                        'get the y component
                        curValue = validRows(i).Item("DataValue")
                        'curX = CalculateProbabilityXPosition(i / numRows)
                        curFreq = CalculateProbabilityFreq(i + 1, numRows)
                        curX = CalculateProbabilityXPosition(curFreq)
                        'NOTE: use i+1 so rank = 1 -> N

                        'plot the point
                        If curValue >= 0 Then
                            probLine.AddPoint(curX, curValue) ', "(" & curFreq * 100 & ", " & curValue & ")")
                        End If
                    Next i

                    '7. Plot the Data
                    'Dim mProbLine As New ZedGraph.LineItem("Michelle's Curve")
                    'mProbLine = gPane.AddCurve("Michelle", ptListF, Drawing.Color.Red, ZedGraph.SymbolType.Circle)
                    'mProbLine.Line.IsVisible = False
                    'mProbLine.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Red)

                    'create the points
                    gPane.CurveList.Add(probLine)
                    probLine.Line.IsVisible = False
                    probLine.Symbol.Type = SymbolType.Circle
                    probLine.Symbol.Fill = New ZedGraph.Fill(Drawing.Color.Black)
                    probLine.Symbol.Size = 3

                    'TODO: Michelle:  ->8. Create/Plot the BFL Line if needed
                    ''set up the initial plotType -> Points +/- Best fit line
                    'If (cbShowBestFitLine.Checked) Then
                    '    ProbabilityPlot.PlottingMethod = PESGO32BLib.ePlottingMethod.SGPM_POINTSPLUSBFL
                    'Else
                    '    ProbabilityPlot.PlottingMethod = PESGO32BLib.ePlottingMethod.SGPM_POINT
                    'End If


                    '8. set up Tic Marks
                    'Dim myText As ZedGraph.TextObj
                    'Dim myTicMark As ZedGraph.TextObj
                    For i = 0 To 20
                        AddLabelToPlot(gPane, GetProbabilityLabel(i), GetProbabilityValue(i))
                        'myText = New ZedGraph.TextObj(GetProbabilityLabel(i), GetProbabilityValue(i), 1.05, ZedGraph.CoordType.XScaleYChartFraction)
                        'myText.FontSpec.Size = 12.5
                        'myText.FontSpec.Border.IsVisible = False
                        'myText.FontSpec.Fill = New ZedGraph.Fill(Drawing.Color.FromArgb(25, Color.White))
                        'gPane.GraphObjList.Add(myText)

                        'myTicMark = New ZedGraph.TextObj("|", GetProbabilityValue(i), 0.995, ZedGraph.CoordType.XScaleYChartFraction)
                        'myTicMark.FontSpec.Size = 11.0
                        'myTicMark.FontSpec.Border.IsVisible = False
                        'myTicMark.FontSpec.Fill = New ZedGraph.Fill(Drawing.Color.FromArgb(25, Drawing.Color.White))
                        'gPane.GraphObjList.Add(myTicMark)
                    Next i

                    ''draw the plot
                    'ProbabilityPlot.AxisChanged = True

                    '9. Release resources
                    'If Not (g Is Nothing) Then
                    '	g.Dispose()
                    '	g = Nothing
                    'End If
                    'If Not (ptList Is Nothing) Then
                    '    ptList.Clear()
                    '    'ptList = Nothing
                    'End If
                    'If Not (bflPtList Is Nothing) Then
                    '    bflPtList.Clear()
                    '    'bflPtList = Nothing
                    'End If
                    'If Not (probLine Is Nothing) Then
                    '    'probLine.Clear()
                    '    'probLine = Nothing
                    'End If
                    'If Not (bflLine Is Nothing) Then
                    '    bflLine.Clear()
                    '    'bflLine = Nothing
                    'End If
                    If Not (validRows Is Nothing) Then
                        ReDim validRows(0)
                        'validRows = Nothing
                    End If
                Catch ex As Exception
                    'show an error message
                    gPane = pane(0)
                    gPane.Title.Text = "No graph loaded"
                    gPane.YAxis.Title.Text = ""
                    gPane.XAxis.Title.Text = ""
                    gPane.XAxis.IsVisible = False
                    gPane.YAxis.IsVisible = False
                End Try
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGProbability.RenderGraph" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function CalculateProbabilityXPosition(ByVal freq As Double) As Double
        'Calculates the position along the x-axis to place the dot -> only used on the Probability Plot
        'Based on a normal curve distribution, Code is from Dr. Stevens
        'Inputs:  freq -> used to calculate the position so has a normal distribution look -> (i/numrows)
        'Outputs: Double -> the x-position to plot the point at
        Try
            Return Math.Round(4.91 * (freq ^ 0.14 - (1.0# - freq) ^ 0.14), 3)
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGProbability.CalculateProbabilityXPosition" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function CalculateProbabilityFreq(ByVal rank As Integer, ByVal numRows As Integer) As Double
        Try
            Return Math.Round((rank - 0.375) / (numRows + 1 - 2 * (0.375)), 3)
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGProbability.CalculateProbabilityFreq" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function GetProbabilityLabel(ByVal index As Integer) As String
        Select Case index
            Case 0
                Return "0.010"
            Case 1
                Return "0.020"
            Case 2
                Return "0.100"
            Case 3
                Return "1.000"
            Case 4
                Return "2.000"
            Case 5
                Return "5.000"
            Case 6
                Return "10.00"
            Case 7
                Return "20.00"
            Case 8
                Return "30.00"
            Case 9
                Return "40.00"
            Case 10
                Return "50.00"
            Case 11
                Return "60.00"
            Case 12
                Return "70.00"
            Case 13
                Return "80.00"
            Case 14
                Return "90.00"
            Case 15
                Return "95.00"
            Case 16
                Return "98.00"
            Case 17
                Return "99.00"
            Case 18
                Return "99.90"
            Case 19
                Return "99.98"
            Case 20
                Return "99.99"
            Case Else
                Return ""
        End Select
    End Function

    Private Function GetProbabilityValue(ByVal index As Integer) As Double
        Select Case index
            Case 0
                Return -3.892
            Case 1
                Return -3.5
            Case 2
                Return -3.095
            Case 3
                Return -2.323
            Case 4
                Return -2.055
            Case 5
                Return -1.645
            Case 6
                Return -1.282
            Case 7
                Return -0.842
            Case 8
                Return -0.542
            Case 9
                Return -0.254
            Case 10
                Return 0
            Case 11
                Return 0.254
            Case 12
                Return 0.524
            Case 13
                Return 0.842
            Case 14
                Return 1.282
            Case 15
                Return 1.645
            Case 16
                Return 2.055
            Case 17
                Return 2.323
            Case 18
                Return 3.095
            Case 19
                Return 3.5
            Case 20
                Return 3.892
            Case Else
                Return ""
        End Select
    End Function

    Private Sub AddLabelToPlot(ByRef gpane As ZedGraph.GraphPane, ByVal label As String, ByVal xLoc As Double)
        Dim myText As ZedGraph.TextObj 'TODO: Document This
        Dim myTic As ZedGraph.TextObj 'TODO: Document This
        Try
            myText = New ZedGraph.TextObj(label, xLoc + 0.1, 1.07, ZedGraph.CoordType.XScaleYChartFraction)
            myText.FontSpec.StringAlignment = StringAlignment.Near
            myText.FontSpec.Angle = -45
            myText.FontSpec.Size = 13
            myText.FontSpec.Border.IsVisible = False
            myText.FontSpec.Fill = New ZedGraph.Fill(Drawing.Color.FromArgb(25, Drawing.Color.White))
            gpane.GraphObjList.Add(myText)
            myTic = New ZedGraph.TextObj("|", xLoc, 0.997, ZedGraph.CoordType.XScaleYChartFraction)
            myTic.FontSpec.Size = 12.0
            myTic.FontSpec.Border.IsVisible = False
            myTic.FontSpec.Fill = New ZedGraph.Fill(Drawing.Color.FromArgb(25, Drawing.Color.White))
            gpane.GraphObjList.Add(myTic)
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGProbability.AddLabelToPlot" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class
