Imports ZedGraph
Imports System.Drawing

Partial Class Graphs_ZGTimeSeries
    Inherits System.Web.UI.UserControl

    Public Shared m_Data As Data.DataTable
    Public Shared m_DataSet As Data.DataSet
    Public Shared m_Site As String
    Public Shared m_Var As String
    Public Shared m_Options As PlotOptions
    'Private m_StdDev As Double = 0

    Public Property Width() As Integer
        Get
            Return TimeSeriesPlot.Width
        End Get
        Set(ByVal value As Integer)
            TimeSeriesPlot.Width = value
        End Set
    End Property
    Public Property Height() As Integer
        Get
            Return TimeSeriesPlot.Height
        End Get
        Set(ByVal value As Integer)
            TimeSeriesPlot.Height = value
        End Set
    End Property

    Public Sub Plot(ByRef objDataTable As Data.DataTable, ByVal strSiteName As String, ByVal strVariableName As String, ByVal strVariableUnits As String, ByRef objOptions As PlotOptions, ByVal e_StdDev As Double) ', Optional ByVal e_StdDev As Double = 0)
        Try
            m_Data = objDataTable.Copy
            m_Site = strSiteName
            m_Var = strVariableName & " - " & strVariableUnits
            m_Options = objOptions

            'If (e_StdDev = 0) And (Not (m_Data Is Nothing)) And (m_Data.Rows.Count > 0) Then
            '    m_StdDev = Statistics.StandardDeviation(m_Data)
            'Else
            '    m_StdDev = e_StdDev
            'End If

            'GraphData()
            TimeSeriesPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGTimeSeries.Plot" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Replot(ByVal options As PlotOptions)
        Try
            m_Options = options

            TimeSeriesPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGTimeSeries.Replot" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Clear()
        Try
            If Not (m_Data Is Nothing) Then
                m_Data.Dispose()
                m_Data = Nothing
            End If

            'GraphData()
            TimeSeriesPlot.AxisChanged = True
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGTimeSeries.Clear" & vbCrLf & ex.Message)
        End Try
    End Sub

    Protected Sub TimeSeriesPlot_RenderGraph(ByVal g As System.Drawing.Graphics, ByVal pane As ZedGraph.MasterPane) Handles TimeSeriesPlot.RenderGraph
        Try
            If ((m_Data Is Nothing) OrElse (m_Data.Rows.Count < 1)) Then 'OrElse ((m_DataSet Is Nothing) OrElse (m_DataSet.Tables.Count < 1)) Then
                TimeSeriesPlot.CurveList.Clear()
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
            ElseIf (m_DataSet Is Nothing) OrElse (m_DataSet.Tables.Count <= 0) Then
                Dim DataSeriesid As Integer = 0

                Dim gPane As ZedGraph.GraphPane 'GraphPane of the zgProbability plot object -> used to set data and characteristics
                Dim i As Integer


                Const adjust As Double = 0.025

                gPane = pane(0)

                gPane.CurveList.Clear()

                gPane.Title.Text = m_Site
                gPane.XAxis.Title.Text = "Date and Time"
                gPane.YAxis.Title.Text = m_Var

                ' Calculate the Axis Scale Ranges
                Dim maxX, minX, minY, maxY, rangeX, rangeY As Double
                minX = CDbl(New ZedGraph.XDate(CDate(m_Data.Compute("MIN(LocalDateTime)", ""))))
                maxX = CDbl(New ZedGraph.XDate(CDate(m_Data.Compute("MAX(LocalDateTime)", ""))))
                minY = CDbl(m_Data.Compute("Min(DataValue)", ""))
                maxY = CDbl(m_Data.Compute("Max(DataValue)", ""))
                rangeX = maxX - minX
                rangeY = maxY - minY
                gPane.XAxis.Scale.Min = minX - (adjust * rangeX)
                gPane.XAxis.Scale.Max = maxX + (adjust * rangeX)
                gPane.YAxis.Scale.Min = minY - (adjust * rangeY)
                gPane.YAxis.Scale.Max = maxY + (adjust * rangeY)

                Dim curve As New ZedGraph.LineItem(m_Var)


                If (m_Options.ShowControlLine) Then
                    Dim controlLine As New ZedGraph.LineItem(m_Options.ControlLineLabel)

                    Dim start As New ZedGraph.PointPair
                    start.X = minX - (rangeX * adjust)
                    start.Y = CDbl(m_Options.ControlLineValue)
                    start.Z = i

                    Dim ending As New ZedGraph.PointPair
                    ending.X = maxX + (rangeX * adjust)
                    ending.Y = CDbl(m_Options.ControlLineValue)
                    ending.Z = i

                    controlLine.AddPoint(start)
                    controlLine.AddPoint(ending)
                    controlLine.Symbol.IsVisible = False
                    AddLabelToPlot(gPane, m_Options.ControlLineLabel, m_Options.ControlLineColor, m_Options.ControlLineValue + (rangeY * adjust))
                    controlLine.Color = m_Options.ControlLineColor
                    controlLine.IsVisible = True

                    gPane.CurveList.Add(controlLine)
                End If

                For i = 0 To m_Data.Rows.Count - 1
                    'Only plot the value if it is not censored
                    If Convert.ToString(m_Data.Rows(i).Item("CensorCode")) = "nc" Then
                        Dim tempPoint As New ZedGraph.PointPair
                        tempPoint.X = CDbl(New ZedGraph.XDate(CDate(m_Data.Rows(i).Item("LocalDateTime"))))
                        tempPoint.Y = CDbl(Convert.ToDouble(m_Data.Rows(i).Item("DataValue")))
                        tempPoint.Z = i
                        curve.AddPoint(tempPoint)
                    End If
                Next

                Select Case LCase(m_Options.PlottingMethod)
                    Case "both"
                        curve.Symbol.IsVisible = True
                        curve.Color = Color.Gray 'LineColor(DataSeriesid)
                        curve.Symbol.Fill.Color = Color.Black 'PointColor(DataSeriesid)
                    Case "line"
                        curve.Symbol.IsVisible = False
                        curve.Color = Color.Gray 'LineColor(DataSeriesid)
                        curve.Symbol.Fill.Color = Drawing.Color.Transparent
                    Case "point"
                        curve.Symbol.IsVisible = True
                        curve.Color = Drawing.Color.Transparent
                        curve.Symbol.Fill.Color = Color.Black 'PointColor(DataSeriesid)
                    Case Else
                        curve.Symbol.IsVisible = False
                        curve.Color = Drawing.Color.Transparent
                        curve.Symbol.Fill.Color = Drawing.Color.Transparent
                End Select

                curve.Symbol.Size = 5
                curve.Symbol.Fill.IsVisible = True
                curve.Symbol.Type = ZedGraph.SymbolType.Circle
                curve.Symbol.Fill.Type = ZedGraph.FillType.Solid
                curve.Symbol.Border.IsVisible = False
                gPane.CurveList.Add(curve)

                gPane.XAxis.IsVisible = True
                gPane.YAxis.IsVisible = True
            End If
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGTimeSeries.RenderGraph" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function LineColor(ByVal i As Integer) As System.Drawing.Color
        Select Case i
            Case Else
                Return Drawing.Color.Black
        End Select
    End Function

    Private Function PointColor(ByVal i As Integer) As System.Drawing.Color
        Select Case i
            Case Else
                Return Drawing.Color.Blue
        End Select
    End Function

    Private Sub AddLabelToPlot(ByRef gpane As ZedGraph.GraphPane, ByVal label As String, ByVal color As Drawing.Color, ByVal yLoc As Double)
        Dim myText As ZedGraph.TextObj 'TODO: Document This
        Try
            myText = New ZedGraph.TextObj(label, 0.5, yLoc, ZedGraph.CoordType.XChartFractionYScale, AlignH.Center, AlignV.Bottom)
            myText.IsClippedToChartRect = False
            myText.FontSpec.StringAlignment = Drawing.StringAlignment.Center
            myText.FontSpec.Size = 15
            myText.FontSpec.IsBold = True
            myText.FontSpec.Border.IsVisible = False
            myText.FontSpec.FontColor = color
            myText.FontSpec.Fill = New ZedGraph.Fill(Drawing.Color.Transparent)
            gpane.GraphObjList.Add(myText)
        Catch ex As Exception
            Throw New Exception("Error Occured in ZGTimeSeries.AddLabelToPlot" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class
