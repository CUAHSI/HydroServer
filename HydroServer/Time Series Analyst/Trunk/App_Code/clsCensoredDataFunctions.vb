Option Strict On

Public Class clsCensoredDataFunctions

    ''' <summary>
    ''' Modify the censored data in the table to fit the normal distribution curve
    ''' Censored data are indicated by a CensorCode of "lt"
    ''' </summary>
    ''' <param name="objDataTable">the Data.DataTable of data to move through</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CalculateCensoredData(ByRef objDataTable As Data.DataTable) As Data.DataTable
        Try
            Dim i As Integer 'counter
            Dim freq As Double

            'get all non-censored data
            Dim numCensoredData As Integer = Convert.ToInt32(objDataTable.Compute("Count(DataValue)", "CensorCode = 'lt'"))
            Dim numNonCensoredData As Integer = objDataTable.Rows.Count - numCensoredData
            Dim nonCensoredData As Data.DataRow() = objDataTable.Select("CensorCode <> 'lt'") 'the selection of nonCensored data from table
            Dim count As Integer = nonCensoredData.GetLength(0) 'the # of fields/columns in the first row of nonCensoredData
            Dim xp(count - 1) As Double 'an array to create a table of values -> holds the normal-distribution value for the data
            Dim yp(count - 1) As Double 'an array to create a table of value -> holds the log values for the data

            'calculate xP and yP from non-censored data
            For i = 0 To count - 1
                xp(i) = (CDbl((i + 1) + numCensoredData) - 0.375) / (CDbl(numNonCensoredData + numCensoredData) + 1.0 - 0.375 * 2.0)
                'Calculate the z score
                freq = xp(i)
                xp(i) = 4.91 * (freq ^ 0.14 - (1.0 - freq) ^ 0.14)
                yp(i) = Math.Log10(Convert.ToDouble(nonCensoredData(i).Item("DataValue")))
            Next i
            'release nonCensoredData resources
            If Not (nonCensoredData Is Nothing) Then
                ReDim nonCensoredData(0)
            End If
            'nonCensoredData = Nothing

            Dim slp As Double 'the slope of the line
            Dim intercept As Double 'the intercept for the line
            'calculate the straight line of the non-censored data
            CalculateStraightLine(xp, yp, slp, intercept)

            'recalculate stats with all data
            count = objDataTable.Rows.Count
            ReDim xp(count - 1)
            ReDim yp(count - 1)

            'calculate xP and yP with all data
            For i = 0 To count - 1
                xp(i) = (CDbl(i + 1) - 0.375) / (CDbl(numNonCensoredData + numCensoredData) + 1.0 - 0.375 * 2.0)
                'Calculate the z score
                freq = xp(i)
                xp(i) = 4.91 * (freq ^ 0.14 - (1.0 - freq) ^ 0.14)

                'create the new y values
                If (Convert.ToString(objDataTable.Rows(i).Item("CensorCode")) <> "lt") Then ' the value is not censored
                    yp(i) = Convert.ToDouble(objDataTable.Rows(i).Item("DataValue"))
                Else 'the value is censored and we predict it using the line
                    yp(i) = intercept + slp * xp(i)
                    yp(i) = 10 ^ (yp(i))
                End If
            Next i

            'fill the table with the new info
            For i = 0 To count - 1
                objDataTable.Rows(i).Item("DataValue") = yp(i)
            Next i

            Return objDataTable
        Catch ex As Exception
            Throw New Exception("Error Occured in clsCensoredDataFunctions.CalculateCensoredData" & vbCrLf & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Calculates the best fit line from the array of points.
    ''' </summary>
    ''' <param name="x">the array of x-values</param>
    ''' <param name="y">the array of y-values</param>
    ''' <param name="slp">the slope of the best fit line (this is calculated and returned)</param>
    ''' <param name="intercept">the y-intercept of the best fit line (this is calculated and returned)</param>
    ''' <remarks></remarks>
    Private Sub CalculateStraightLine(ByVal x() As Double, ByVal y() As Double, ByRef slp As Double, ByRef intercept As Double)
        Try
            Dim i As Integer 'counter
            Dim xSum As Double 'sum so far of the x-values in x()
            Dim ySum As Double 'sum so far of the y-values in y()
            Dim xAvg As Double 'the average value of the x-values in x()
            Dim yAvg As Double 'the average value of the y-values in y()

            'make sure x,y have data
            If x.Length = 0 Or y.Length = 0 Then Exit Sub

            'find the average x and y
            For i = 0 To x.Length - 1
                xSum += x(i)
                ySum += y(i)
            Next
            xAvg = xSum / x.Length
            yAvg = ySum / y.Length

            xSum = 0
            ySum = 0
            For i = LBound(y) To UBound(y)
                xSum += (x(i) - xAvg) * (x(i) - xAvg)
                ySum += (y(i) - yAvg) * (x(i) - xAvg)
            Next i

            'calculate the slope of the line
            If (xSum <> 0) Then
                slp = ySum / xSum
            Else
                slp = 0
            End If

            'calculate the intercept of the line, y = mx + b
            intercept = yAvg - slp * xAvg
        Catch ex As Exception
            Throw New Exception("Error Occured in clsCensoredDataFunctions.CalculateStraightLine" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class
