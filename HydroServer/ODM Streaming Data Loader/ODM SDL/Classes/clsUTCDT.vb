'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..
Imports System.xml
''' <summary>
''' Object for Storing DateTime values with different TimeZones and DST Settings
''' </summary>
''' <remarks></remarks>
Public Class clsUTCDT
    'Last Documented 8/29/07

#Region " Member Variables "

    ''' <summary>
    ''' The Local Date and Time
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LocalDT As DateTime
    ''' <summary>
    ''' The UTC Date and Time
    ''' </summary>
    ''' <remarks></remarks>
    Private m_UTCDT As DateTime
    ''' <summary>
    ''' The Offset Between Local and UTC Date and Time (Local - UTC)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_UTCOffset As Integer
    ''' <summary>
    ''' Whether this DT uses Daylight Saving Time
    ''' </summary>
    ''' <remarks></remarks>
    Private m_UseDST As Boolean
    ''' <summary>
    ''' Whether it is Daylight Saving Time at this specific Date and Time
    ''' </summary>
    ''' <remarks></remarks>
    Private m_isDST As Boolean = False
    ''' <summary>
    ''' Whether the record was measured at the start of the specified interval
    ''' </summary>
    ''' <remarks></remarks>
    Private m_isFileSOI As Boolean
    ''' <summary>
    ''' Whether the record should be STORED as the start of the specified interval
    ''' </summary>
    ''' <remarks></remarks>
    Private m_isDatabaseSOI As Boolean
    ''' <summary>
    ''' The length of the interval used for 'Start of Interval' - 'End of Interval' conversions
    ''' </summary>
    ''' <remarks></remarks>
    Private m_IntervalLength As TimeSpan

#End Region

#Region " Functions "

#Region " Constructors "

    ''' <summary>
    ''' Used to convert Local Time to UTC Time when a different Timezone is required.  
    ''' </summary>
    ''' <param name="e_LocalDT">The Local Time of the measurement</param>
    ''' <param name="e_TimeZone">The Timezone of the Measurement</param>
    ''' <param name="e_UseDST">Whether the conversion should include Daylight Saving Time</param>
    ''' <param name="e_LastValue">The last Time recorded, used to determine Daylight Saving Time transitions</param>
    ''' <param name="FileSOI">Whether the time was recorded at Start of the Interval</param>
    ''' <param name="DatabaseSOI">Whether the time should be saved as the Start of the Interval</param>
    ''' <param name="Interval">The length of the Interval</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_LocalDT As String, ByVal e_TimeZone As Integer, ByVal e_UseDST As Boolean, ByVal e_LastValue As clsUTCDT, ByVal FileSOI As Boolean, ByVal DatabaseSOI As Boolean, ByVal Interval As String)
        Dim temp As DateTime
        'DateTime.TryParse(e_LocalDT, temp)
        temp = Date.Parse(e_LocalDT)

        m_UseDST = e_UseDST

        m_LocalDT = DateTime.SpecifyKind(temp, DateTimeKind.Local)

        CalcUTCDT(e_LastValue, e_TimeZone)

        m_isFileSOI = FileSOI
        m_isDatabaseSOI = DatabaseSOI
        m_IntervalLength = TimeSpan.Parse(Interval)
    End Sub

    ''' <summary>
    ''' Used to convert UTC Time to Local Time when the local timezone is required.
    ''' </summary>
    ''' <param name="e_UTCDT">The UTC Time of the measurement</param>
    ''' <param name="e_UseDST">Whether the conversion should include Daylight Saving Time</param>
    ''' <param name="FileSOI">Whether the time was recorded at Start of the Interval</param>
    ''' <param name="DatabaseSOI">Whether the time should be saved as the Start of the Interval</param>
    ''' <param name="Interval">The length of the Interval</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_UTCDT As String, ByVal e_UseDST As Boolean, ByVal FileSOI As Boolean, ByVal DatabaseSOI As Boolean, ByVal Interval As String)
        Dim temp As DateTime
        DateTime.TryParse(e_UTCDT, temp)

        m_UseDST = e_UseDST

        m_UTCDT = DateTime.SpecifyKind(temp, DateTimeKind.Utc)

        CalcLocalDT()

        m_isFileSOI = FileSOI
        m_isDatabaseSOI = DatabaseSOI
        m_IntervalLength = TimeSpan.Parse(Interval)
    End Sub

    ''' <summary>
    ''' Used to calculate the UTC Offset when Local and UTC times are given.
    ''' </summary>
    ''' <param name="e_LocalDT">The Local Time of the measurement</param>
    ''' <param name="e_UTCDT">The UTC Time of the measurement</param>
    ''' <param name="FileSOI">Whether the time was recorded at Start of the Interval</param>
    ''' <param name="DatabaseSOI">Whether the time should be saved as the Start of the Interval</param>
    ''' <param name="Interval">The length of the Interval</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal e_LocalDT As String, ByVal e_UTCDT As String, ByVal FileSOI As Boolean, ByVal DatabaseSOI As Boolean, ByVal Interval As String)
        DateTime.TryParse(e_LocalDT, m_LocalDT)
        DateTime.TryParse(e_UTCDT, m_UTCDT)

        CalcUTCOffset()

        m_isFileSOI = FileSOI
        m_isDatabaseSOI = DatabaseSOI
        m_IntervalLength = TimeSpan.Parse(Interval)
    End Sub

    ''' <summary>
    ''' Used to create a default object
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        m_LocalDT = DateTime.MinValue
        m_UTCDT = DateTime.MinValue
        m_UTCOffset = 0
        m_UseDST = False
        m_isDST = True
        m_isFileSOI = True
        m_isDatabaseSOI = True
        m_IntervalLength = New TimeSpan
    End Sub

#End Region

    ''' <summary>
    ''' Calculates the UTC DateTime based on the Last DateTime and the TimeZone.
    ''' If using DST, also includes UTC in the calculation.
    ''' </summary>
    ''' <param name="e_LastValue">The last recorded time record used to determine DST in dataloggers (which don't always propperly adjust for DST).</param>
    ''' <param name="e_TimeZone">The timezone or UTC Offset of the record</param>
    ''' <remarks></remarks>
    Private Sub CalcUTCDT(ByVal e_LastValue As clsUTCDT, ByVal e_TimeZone As Integer)


        m_isDST = False

        If m_UseDST Then

            If ((m_LocalDT.Date).IsDaylightSavingTime) AndAlso (((m_LocalDT.Date).AddHours(3)).IsDaylightSavingTime) Then
                m_UTCDT = DateTime.SpecifyKind(m_LocalDT.AddHours(-(e_TimeZone + 1)), DateTimeKind.Utc)
                m_UTCOffset = e_TimeZone + 1
                m_isDST = True
            ElseIf (Not ((m_LocalDT.Date).IsDaylightSavingTime)) AndAlso (((m_LocalDT.Date).AddHours(3)).IsDaylightSavingTime) Then
                If (m_LocalDT.Hour < 2) Then
                    m_UTCDT = DateTime.SpecifyKind(m_LocalDT.AddHours(-e_TimeZone), DateTimeKind.Utc)
                    m_UTCOffset = e_TimeZone
                Else
                    m_UTCDT = DateTime.SpecifyKind(m_LocalDT.AddHours(-(e_TimeZone + 1)), DateTimeKind.Utc)
                    m_UTCOffset = e_TimeZone + 1
                    m_isDST = True
                End If
            ElseIf ((m_LocalDT.Date).IsDaylightSavingTime) AndAlso (Not (((m_LocalDT.Date).AddHours(3)).IsDaylightSavingTime)) Then
                If (m_LocalDT.Hour < 1) Then
                    m_UTCDT = DateTime.SpecifyKind(m_LocalDT.AddHours(-(e_TimeZone + 1)), DateTimeKind.Utc)
                    m_UTCOffset = e_TimeZone + 1
                    m_isDST = True
                ElseIf (m_LocalDT.Hour >= 2) Then
                    m_UTCDT = DateTime.SpecifyKind(m_LocalDT.AddHours(-e_TimeZone), DateTimeKind.Utc)
                    m_UTCOffset = e_TimeZone
                ElseIf (e_LastValue.m_isDST) AndAlso (e_LastValue.m_LocalDT < m_LocalDT) Then
                    m_UTCDT = DateTime.SpecifyKind(m_LocalDT.AddHours(-(e_TimeZone + 1)), DateTimeKind.Utc)
                    m_UTCOffset = e_TimeZone + 1
                    m_isDST = True
                Else
                    m_UTCDT = DateTime.SpecifyKind(m_LocalDT.AddHours(-e_TimeZone), DateTimeKind.Utc)
                    m_UTCOffset = e_TimeZone
                End If
            Else
                m_UTCDT = DateTime.SpecifyKind(m_LocalDT.AddHours(-e_TimeZone), DateTimeKind.Utc)
            End If
        Else
            m_UTCDT = DateTime.SpecifyKind(m_LocalDT.AddHours(-e_TimeZone), DateTimeKind.Utc)
            m_UTCOffset = e_TimeZone
        End If
    End Sub

    ''' <summary>
    ''' Calculates the Local DateTime and UTC Offset based on the UTC DateTime.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalcLocalDT()
        m_LocalDT = DateTime.FromFileTime(m_UTCDT.ToFileTimeUtc)
        m_UTCOffset = (m_LocalDT.TimeOfDay - m_UTCDT.TimeOfDay).Hours
        'MsgBox(m_UTCOffset)
    End Sub

    ''' <summary>
    ''' Calculates the UTC Offset based on the Local DateTime and UTC DateTime
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalcUTCOffset()
        m_UTCOffset = (m_LocalDT - m_UTCDT).Hours
    End Sub

#End Region

#Region " Properties "

    ''' <summary>
    ''' Returns the Local DateTime (after Interval and DST calculations)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property getLocalDT() As DateTime
        Get
            '#If DEBUG Then
            '            MsgBox("FileStart = " & m_isFileSOI.ToString & vbCrLf & _
            '            "DatabaseStart = " & m_isDatabaseSOI.ToString & vbCrLf & _
            '            m_IntervalLength.ToString)
            '#End If
            If (m_isFileSOI = True) And (m_isDatabaseSOI = False) Then
                Return m_LocalDT + m_IntervalLength
            ElseIf (m_isFileSOI = False) And (m_isDatabaseSOI = True) Then
                Return m_LocalDT - m_IntervalLength
            Else
                Return m_LocalDT
            End If
        End Get
    End Property

    ''' <summary>
    ''' Returns the UTC DateTime (after Interval and DST calculations)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property getUTCDT() As DateTime
        Get
            '#If DEBUG Then
            '            MsgBox("FileStart = " & m_isFileSOI.ToString & vbCrLf & _
            '            "DatabaseStart = " & m_isDatabaseSOI.ToString & vbCrLf & _
            '            m_IntervalLength.ToString)
            '#End If
            If (m_isFileSOI = True) And (m_isDatabaseSOI = False) Then
                Return m_UTCDT + m_IntervalLength
            ElseIf (m_isFileSOI = False) And (m_isDatabaseSOI = True) Then
                Return m_UTCDT - m_IntervalLength
            Else
                Return m_UTCDT
            End If
        End Get
    End Property

    ''' <summary>
    ''' Returns the UTC Offset  (after DST calculations)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property getUTCOffset()
        Get
            Return m_UTCOffset
        End Get
    End Property

#End Region

End Class
