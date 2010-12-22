'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

'Enumeration of Averaging Types for frmWaterQuality 
Public Enum AveragingType
    Hourly
    Daily
    Weekly
    Monthly
    Seasonally
    Yearly
End Enum

Public Class clsStatistics
    'this class contains functions for doing statistical analysis and averaging of data

#Region " Censored Data functions "

    Public Sub CalculateCensoredData(ByRef table As DataTable)
        'Modify the censored data in the table to fit the normal distribution curve
        'censored data has a value of <= 0
        'Inputs:  table ->the dataTable of data to move through
        'Outputs: none
        Dim i As Integer 'counter
        Try
            'get all non-censored data
            Dim numCensoredData As Integer = table.Compute("Count(" & db_fld_ValCensorCode & ")", db_fld_ValCensorCode & " = " & db_val_ValCensorCode_lt) 'the number of values in m_Table that are <= 0 (won't be viewed by the user unless the user specifies to)
            Dim numNonCensoredData As Integer = table.Rows.Count - numCensoredData 'the number of values in m_Table that are > 0 (will be viewed by the user so aren't censored)
            Dim nonCensoredData As DataRow() = table.Select(db_fld_ValCensorCode & " <> " & db_val_ValCensorCode_lt) 'the selection of nonCensored data from table
            Dim count As Integer = nonCensoredData.GetLength(0) 'the # of fields/columns in the first row of nonCensoredData
            Dim xp(count - 1) As Double 'an array to create a table of values -> holds the normal-distribution value for the data
            Dim yp(count - 1) As Double 'ann array to create a table of value -> holds the log values for the data

            'calculate xP and yP from non-censored data
            For i = 0 To count - 1
                xp(i) = (CDbl((i + 1) + numCensoredData) - 0.375) / (CDbl(numNonCensoredData + numCensoredData) + 1.0 - 0.375 * 2.0)
                xp(i) = CalculateZScore(xp(i))
                yp(i) = Math.Log10(nonCensoredData(i).Item(db_fld_ValValue))
            Next i
            'release nonCensoredData resources
            nonCensoredData = Nothing

            Dim slp As Double 'the slope of the line
            Dim intercept As Double 'the intercept for the line
            'calculate the straight line of the non-censored data
            CalculateStraightLine(xp, yp, slp, intercept)

            'recalculate stats with all data
            count = table.Rows.Count
            ReDim xp(count - 1)
            ReDim yp(count - 1)

            'calculate xP and yP with all data
            For i = 0 To count - 1
                xp(i) = (CDbl(i + 1) - 0.375) / (CDbl(numNonCensoredData + numCensoredData) + 1.0 - 0.375 * 2.0)
                xp(i) = CalculateZScore(xp(i))
                If (table.Rows(i).Item(db_fld_ValCensorCode) <> db_val_ValCensorCode_lt) Then
                    yp(i) = table.Rows(i).Item(db_fld_ValValue)
                Else
                    yp(i) = intercept + slp * xp(i)
                    yp(i) = 10 ^ (yp(i))
                End If
            Next i

            'fill the table with the new info
            For i = 0 To count - 1
                table.Rows(i).Item(db_fld_ValValue) = yp(i)
            Next i
        Catch ex As System.Exception
            'show an error message
            ShowError("An Error occurred while calculating the Censored Data for the Statistical Summary on the Visualize Tab." & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Sub

    Private Function CalculateZScore(ByVal freq As Double) As Double
        'Caculates the position along the x-axis to place the dot
        'Based on a normal curve distribution
        'NOTE: Code is from Dr. Stevens
        'Inputs:  freq -> used to calculate the position so has a normal distribution look 
        'Outputs: Double -> the x-position to plot the point at
        Try
            Return 4.91 * (freq ^ 0.14 - (1.0 - freq) ^ 0.14)
        Catch ex As System.Exception
            ShowError("An Error occurred while calculating the ZScore for the Censored Data. " & vbCrLf & "Message = " & ex.Message, ex)
        End Try
    End Function

    Private Sub CalculateStraightLine(ByVal x() As Double, ByVal y() As Double, ByRef slp As Double, ByRef intercept As Double)
        'Calculates the best fit line from the array of points.
        'Inputs:  x() -> the array of x-values
        '         y() -> the array of y-values
        '         slp -> (ByRef) the slope of the best fit line (this is calculated and returned)
        '         intercept -> (ByRef) the y-intercept of the best fit line (this is calculated and returned)
        'Outputs: slp -> (ByRef) the slope of the best fit line, "m" in y = mx + b
        '         intercept -> (ByRef) the y-interspt of the best fit line, "b" in y = mx + b
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
    End Sub

#End Region

End Class
