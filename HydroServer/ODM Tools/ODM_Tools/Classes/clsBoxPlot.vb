'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class clsBoxPlot

#Region " Member Variables "

    'point location variables
    Private m_xVal As Double 'xvalue location of the boxplot
    Private m_yVal_Med As Double 'yvalue of the boxplot -> median value

    'box stats variables
    Private m_mean As Double 'mean value for the boxplot
    Private m_median As Double 'median value for the boxplot
    Private m_quantile_25 As Double '25th quantile value
    Private m_quantile_75 As Double '75th quantile value
    Private m_adjLevel_Lower As Double 'lower whisker
    Private m_adjLevel_Upper As Double 'upper whisker
    Private m_confIntvl95_Lower As Double 'the lower 95% confidence interval on the mean
    Private m_confIntvl95_Upper As Double 'the upper 95% confidence interval on the mean
    Private m_confLimit95_Lower As Double 'the lower 95% confidence limit on the median
    Private m_confLimit95_Upper As Double 'the upper 95% confidence limit on the median

    'other variables
    Private m_outliers_Lower As Double() 'holds the y-value only -> NOTE: use m_xVal for the x-value when plotting
    Private m_outliers_Upper As Double() 'holds the y-value only -> NOTE: use m_xVal for the x-value when plotting
    Private m_numOutliers_Lower As Integer 'number of lower outliers
    Private m_numOutliers_Upper As Integer 'number of upper outliers

#End Region

#Region " Functions "

    Public Sub New()
        'creates a new instance of the class, initializes member variables
        m_xVal = 0
        m_yVal_Med = 0
        m_numOutliers_Lower = 0
        m_numOutliers_Upper = 0
    End Sub

    Public Sub AddOutlier_Lower(ByVal value As Double)
        'adds a lower outlier value to m_outliers_Lower, updates m_numOutliers_Lower
        'Inputs:  value -> the lower outlier value to add
        'Outputs: none

        'resize the array
        ReDim Preserve m_outliers_Lower(m_numOutliers_Lower)
        'add the new outlier
        m_outliers_Lower(m_numOutliers_Lower) = value
        'update the count
        m_numOutliers_Lower += 1
    End Sub

    Public Sub AddOutlier_Upper(ByVal value As Double)
        'add an upper outlier value to m_outliers_Upper, update m_numOutliers_Upper
        'Inputs:  value = the upper outlier value to add
        'Outputs: none

        'resize the array
        ReDim Preserve m_outliers_Upper(m_numOutliers_Upper)
        'add the new outlier
        m_outliers_Upper(m_numOutliers_Upper) = value
        'update the count
        m_numOutliers_Upper += 1
    End Sub

#End Region

#Region " Properties "

    'xValue property: return and set the xValue for the boxplot
    Public Property xValue() As Double
        Get
            Return m_xVal
        End Get
        Set(ByVal value As Double)
            m_xVal = value
        End Set
    End Property

    'yValue property: return and set the yValue for the boxplot
    Public Property yValue() As Double
        Get
            Return m_yVal_Med
        End Get
        Set(ByVal value As Double)
            m_yVal_Med = value
        End Set
    End Property

    'mean property: return and set the mean value for the boxplot
    Public Property mean() As Double
        Get
            Return m_mean
        End Get
        Set(ByVal value As Double)
            m_mean = value
        End Set
    End Property

    'median property: return and set the median value for the boxplot
    Public Property median() As Double
        Get
            Return m_median
        End Get
        Set(ByVal value As Double)
            m_median = value
        End Set
    End Property

    'quantile_25th property: return and set the 25th quantile value for the boxplot
    Public Property quantile_25th() As Double
        Get
            Return m_quantile_25
        End Get
        Set(ByVal value As Double)
            m_quantile_25 = value
        End Set
    End Property

    'quantile_75th property: return and set the 75th quantile value for the boxplot
    Public Property quantile_75th() As Double
        Get
            Return m_quantile_75
        End Get
        Set(ByVal value As Double)
            m_quantile_75 = value
        End Set
    End Property

    'adjacentLevel_Lower property: return and set the lower whisker (Lower adjacent level) value for the boxplot
    Public Property adjacentLevel_Lower() As Double
        Get
            Return m_adjLevel_Lower
        End Get
        Set(ByVal value As Double)
            m_adjLevel_Lower = value
        End Set
    End Property

    'adjacentLevel_Upper property: return and set the upper whisker (Upper adjacent level) value for the boxplot
    Public Property adjacentLevel_Upper() As Double
        Get
            Return m_adjLevel_Upper
        End Get
        Set(ByVal value As Double)
            m_adjLevel_Upper = value
        End Set
    End Property

    'confidenceInterval95_Lower property: return and set the Lower 95% Confidence Interval value for the boxplot
    Public Property confidenceInterval95_Lower() As Double
        Get
            Return m_confIntvl95_Lower
        End Get
        Set(ByVal value As Double)
            m_confIntvl95_Lower = value
        End Set
    End Property

    'confidenceInterval95_Upper property: return and set the Upper 95% Confidence Interval value for the boxplot
    Public Property confidenceInterval95_Upper() As Double
        Get
            Return m_confIntvl95_Upper
        End Get
        Set(ByVal value As Double)
            m_confIntvl95_Upper = value
        End Set
    End Property

    'confidenceLimit95_Lower property: return and set the Lower 95% Confidence Limit value for the boxplot
    Public Property confidenceLimit95_Lower() As Double
        Get
            Return m_confLimit95_Lower
        End Get
        Set(ByVal value As Double)
            m_confLimit95_Lower = value
        End Set
    End Property

    'confidenceLimit95_Upper property: return and set the Upper 95% Confidnece Limit value for the boxplot
    Public Property confidenceLimit95_Upper() As Double
        Get
            Return m_confLimit95_Upper
        End Get
        Set(ByVal value As Double)
            m_confLimit95_Upper = value
        End Set
    End Property

    'numOutliers_Lower property: ReadOnly -> returns the number of lower outliers in m_outliers_Lower
    Public ReadOnly Property numOutliers_Lower() As Integer
        Get
            Return m_numOutliers_Lower
        End Get
    End Property

    'numOutliers_Upper property: ReadOnly -> returns the number of upper outliers in m_outliers_Upper
    Public ReadOnly Property numOutliers_Upper() As Integer
        Get
            Return m_numOutliers_Upper
        End Get
    End Property

    'collectionOfOutliers_Lower property: ReadOnly -> return the collection of lower outliers
    Public ReadOnly Property collectionOfOutliers_Lower() As Double()
        Get
            Return m_outliers_Lower
        End Get
    End Property

    'collectionOfOutliers_Upper property: ReadOnly -> return the collection of upper outliers
    Public ReadOnly Property collectionOfOutliers_Upper() As Double()
        Get
            Return m_outliers_Upper
        End Get
    End Property

    'outlierValue_Lower property: returns or sets the lower outlier value at the given index
    'Inputs:  index -> the index into m_outliers_Lower to get or set the value for
    Public Property outlierValue_Lower(ByVal index As Integer) As Double
        Get
            If index >= 0 And index < m_numOutliers_Lower Then
                Return m_outliers_Lower(index)
            Else
                Return -1
            End If
        End Get
        Set(ByVal value As Double)
            If index > 0 And index < m_numOutliers_Lower Then
                m_outliers_Lower(index) = value
            End If
        End Set
    End Property

    'outlierValue_Upper property: returns or sets the upper outlier value at the given index
    'Inputs:  index -> the index into m_outliers_Upper to get or set the value for
    Public Property outlierValue_Upper(ByVal index As Integer) As Double
        Get
            If index >= 0 And index < m_numOutliers_Upper Then
                Return m_outliers_Upper(index)
            Else
                Return -1
            End If
        End Get
        Set(ByVal value As Double)
            If index > 0 And index < m_numOutliers_Upper Then
                m_outliers_Upper(index) = value
            End If
        End Set
    End Property

#End Region

End Class
