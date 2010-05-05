'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class clsOptions
    'Last Documented 5/15/07

#Region " Member Variables "

    Private m_MetadataExport As Boolean 'Option chosen in tools >> options dialog box.  True -> Exports metadata with Multiple Data Export
    Private m_ExportTime As Boolean 'Option chosen in tools >> options dialog box.  Whether to export the time values
    Private m_ExportSite As Boolean 'Option chosen in tools >> options dialog box.  Whether to export the Site values
    Private m_ExportVariable As Boolean 'Option chosen in tools >> options dialog box.  Whether to export the Variable values
    Private m_ExportQualifier As Boolean 'Option chosen in tools >> options dialog box.  Whether to export the Qualifier values
    Private m_ExportOffset As Boolean 'Option chosen in tools >> options dialog box.  Whether to export the Offset values
    Private m_ExportSource As Boolean 'Option chosen in tools >> options dialog box.  Whether to export the source values
    Private m_ExportQualityControlLevels As Boolean

#End Region

#Region " Functions "

    Public Sub New(Optional ByVal e_ExportTime As Boolean = False, Optional ByVal e_ExportSite As Boolean = False, Optional ByVal e_ExportVariable As Boolean = False, Optional ByVal e_ExportQualifier As Boolean = False, Optional ByVal e_ExportOffset As Boolean = False, Optional ByVal e_ExportSource As Boolean = False, Optional ByVal e_ExportQualityControlLevel As Boolean = False, Optional ByVal e_MetadataExport As Boolean = False)
        'Create a new Options object with the specified parameters
        m_MetadataExport = e_MetadataExport
    End Sub

#End Region

#Region " Properties "
    'NOTE: these properties are used to protect private data members.

    'MetadataExport property: returns and sets if exporting the MetatData 
    Public Property MetadataExport() As Boolean
        Get
            Return m_MetadataExport
        End Get
        Set(ByVal value As Boolean)
            m_MetadataExport = value
        End Set
    End Property

    'ExportTime property: returns and sets if exporting the Time Info
    Public Property ExportTime() As Boolean
        Get
            Return m_ExportTime
        End Get
        Set(ByVal value As Boolean)
            m_ExportTime = value
        End Set
    End Property

    'ExportSite property: returns and sets if exporting the Site Info
    Public Property ExportSite() As Boolean
        Get
            Return m_ExportSite
        End Get
        Set(ByVal value As Boolean)
            m_ExportSite = value
        End Set
    End Property

    'ExportVariable property: returns and sets if exporting the Variable Info
    Public Property ExportVariable() As Boolean
        Get
            Return m_ExportVariable
        End Get
        Set(ByVal value As Boolean)
            m_ExportVariable = value
        End Set
    End Property

    'ExportQualifier property: returns and sets if exporting the Qualifier Info
    Public Property ExportQualifier() As Boolean
        Get
            Return m_ExportQualifier
        End Get
        Set(ByVal value As Boolean)
            m_ExportQualifier = value
        End Set
    End Property

    'ExportOffset property: returns and sets if exporting the Offset Info
    Public Property ExportOffset() As Boolean
        Get
            Return m_ExportOffset
        End Get
        Set(ByVal value As Boolean)
            m_ExportOffset = value
        End Set
    End Property

    'ExportSource property: returns and sets if exporting the Source Info
    Public Property ExportSource() As Boolean
        Get
            Return m_ExportSource
        End Get
        Set(ByVal value As Boolean)
            m_ExportSource = value
        End Set
    End Property

    'ExportQualityControlLevels property: returns and sets if exporting the QualityControlLevel Info
    Public Property ExportQualityControlLevels() As Boolean
        Get
            Return m_ExportQualityControlLevels
        End Get
        Set(ByVal value As Boolean)
            m_ExportQualityControlLevels = value
        End Set
    End Property
#End Region

End Class
