'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class clsDataSeriesIDs
	'Contains the IDs for the different variables that make a Data Series Unique

#Region " Member Variables "

    Private m_SeriesID As Integer 'holds the Data Series ID value -> from the SeriesCatalog table 
    Private m_SiteID As Integer 'holds the Site ID value -> from the Sites table
    Private m_VariableID As Integer 'holds the Variable ID value -> from the Variables table
    Private m_MethodID As Integer 'holds the Method ID value -> from the Methods table
    Private m_QCLevelID As Integer 'holds the QC Level ID value -> from the QualityControlLevel table
    Private m_SourceID As Integer 'holds the Source ID value -> from the Sources table

#End Region

#Region " Properties "

    'SeriesID property -> returns and sets the Data Series ID value
    Property SeriesID() As Integer
        Get
            Return m_SeriesID
        End Get
        Set(ByVal Value As Integer)
            m_SeriesID = Value
        End Set
    End Property

    'SiteID property -> returns and sets the Site ID value
    Property SiteID() As Integer
        Get
            Return m_SiteID
        End Get
        Set(ByVal Value As Integer)
            m_SiteID = Value
        End Set
    End Property

    'VariableID property -> returns and sets the Variable ID value
    Property VariableID() As Integer
        Get
            Return m_VariableID
        End Get
        Set(ByVal Value As Integer)
            m_VariableID = Value
        End Set
    End Property

    'MethodID property -> returns and sets the Method ID value
    Property MethodID() As Integer
        Get
            Return m_MethodID
        End Get
        Set(ByVal Value As Integer)
            m_MethodID = Value
        End Set
    End Property

    'QCLevel property -> returns and sets the Quality Control Level ID value
	Property QCLevelID() As Integer
		Get
			Return m_QCLevelID
		End Get
		Set(ByVal Value As Integer)
			m_QCLevelID = Value
		End Set
	End Property

    'SourceID property -> returns and sets the Source ID value
    Property SourceID() As Integer
        Get
            Return m_SourceID
        End Get
        Set(ByVal Value As Integer)
            m_SourceID = Value
        End Set
    End Property

#End Region

#Region " Functions "

    Public Sub New()
        'creates a new instance of the class, initialized values
        m_SiteID = db_BadID
        m_VariableID = db_BadID
        m_MethodID = db_BadID
        m_QCLevelID = db_BadID
        m_SourceID = db_BadID
    End Sub

#End Region

End Class
