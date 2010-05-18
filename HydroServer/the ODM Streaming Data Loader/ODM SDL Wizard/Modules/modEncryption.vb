'ODM Streaming Data Loader
'Created by Utah State University
'Copyright (C) 2007 Utah State University
'This program is free software. You can redistribute it and/or modify it under the terms of the GNU General Public License Version 2, 1991 as published by the Free Software Foundation.
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'A copy of the full GNU General Public License is included in file gpl.rtf. This is also available at:
'http://www.gnu.org/licenses/gpl.html  
'or from:
'The Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA..

Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module modEncryption
    'Last Documented 9/4/07

#Region " Constants "

    ''' <summary>
    ''' Used to protect the integrity of Encrypted Data
    ''' </summary>
    ''' <remarks></remarks>
    Private Const Entropy As String = "0dMRtDi"

#End Region

#Region " Encryption "

    ''' <summary>
    ''' Encrypts data for security purposes
    ''' </summary>
    ''' <param name="data">The data to decrypt</param>
    ''' <param name="padding">Whether the data should be padded</param>
    ''' <returns>The decrypted data</returns>
    ''' <remarks></remarks>
    Public Function Encrypt(ByVal data As String, Optional ByVal padding As Byte = 0) As String
        Try
            Dim encrypted As Byte() = EncryptInMemoryData(Encoding.UTF8.GetBytes(data), DataProtectionScope.CurrentUser)

            Dim temp As String = encrypted(0).ToString("X")
            Dim i As Integer


            For i = 1 To (encrypted.Length - 1)
                temp &= " " & encrypted(i).ToString("X")
            Next

            Return temp

        Catch ex As Exception
            ShowError("Unable to encrypt data")
        End Try

        Return ""
    End Function

    ''' <summary>
    ''' Encrypts data
    ''' </summary>
    ''' <param name="Data">The data to encrypt as an array of Bytes</param>
    ''' <param name="Scope">the MemoryProtecitonScope used to encrypt the data</param>
    ''' <returns>Encrypted data as an array of Bytes</returns>
    ''' <remarks></remarks>
    Private Function EncryptInMemoryData(ByVal Data() As Byte, ByVal Scope As MemoryProtectionScope) As Byte()
        If Data.Length <= 0 Then
            Throw New ArgumentException("Buffer")
        End If
        If Data Is Nothing Then
            Throw New ArgumentNullException("Buffer")
        End If

        Dim buffer As Byte()

        buffer = ProtectedData.Protect(Data, Encoding.UTF8.GetBytes(Entropy), Scope)

        Return buffer
    End Function 'EncryptInMemoryData

#End Region

#Region " Decryption "

    ''' <summary>
    ''' Decrypts data that has been encrypted by the ODM SDL Config Wizard.
    ''' </summary>
    ''' <param name="data">The data to decrypt</param>
    ''' <param name="padding">Whether the data should be padded</param>
    ''' <returns>The decrypted data</returns>
    ''' <remarks></remarks>
    Public Function Decrypt(ByVal data As String, Optional ByVal padding As Byte = 0) As String
        Try
            Dim bytes() As String = Split(data)
            Dim encrypted(bytes.Length - 1) As Byte
            Dim i As Integer

            For i = 0 To (bytes.Length - 1)
                encrypted(i) = Convert.ToInt32(bytes(i), 16)
            Next

            Dim decrypted As Byte() = DecryptInMemoryData(encrypted, DataProtectionScope.CurrentUser)

            For i = (decrypted.Length - 1) To 0 Step -1
                If decrypted(i) = padding Then
                    ReDim Preserve decrypted(i - 1)
                Else
                    Exit For
                End If
            Next

            Return Encoding.UTF8.GetString(decrypted)

        Catch ex As Exception
            ShowError("Unable to decrypt data")
        End Try

        Return ""
    End Function

    ''' <summary>
    ''' Decrypts Data
    ''' </summary>
    ''' <param name="Data">The data to decrypt as an array of Bytes</param>
    ''' <param name="Scope">the MemoryProtecitonScope used to encrypt the data</param>
    ''' <returns>Decrypted data as an array of Bytes</returns>
    ''' <remarks></remarks>
    Private Function DecryptInMemoryData(ByVal Data() As Byte, ByVal Scope As MemoryProtectionScope) As Byte()
        If Data.Length <= 0 Then
            Throw New ArgumentException("Buffer")
        End If
        If Data Is Nothing Then
            Throw New ArgumentNullException("Buffer")
        End If

        Dim Buffer As Byte()

        'Decrypt the data. The result is stored in the same same array as the original data.
        Buffer = ProtectedData.Unprotect(Data, Encoding.UTF8.GetBytes(Entropy), Scope)

        Return Buffer
    End Function

#End Region

End Module
