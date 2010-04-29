'ODM Tools
'Copyright (c) 2007, Utah State University
'All rights reserved.
'Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
'*           Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
'*           Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
'*           Neither the name of the Utah State University nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
'THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module modEncryption
    Public Const Entropy As String = "OdMTo0lz"
    Public Function Encrypt(ByVal data As String, Optional ByVal padding As Byte = 0) As String
        Try
            Dim encrypted As Byte() = EncryptInMemoryData(Encoding.UTF8.GetBytes(data), DataProtectionScope.CurrentUser)

            Dim temp As String = encrypted(0).ToString("X")
            Dim i As Integer


            For i = 1 To (encrypted.Length - 1)
                temp &= " " & encrypted(i).ToString("X")
            Next

            Return temp

        Catch
            ShowError("Unable to encrypt data")
        End Try

        Return ""
    End Function

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
            'ShowError("Unable to decrypt data")
        End Try

        Return ""
    End Function

    Private Function EncryptInMemoryData(ByVal Data() As Byte, ByVal Scope As MemoryProtectionScope, Optional ByVal padding As Byte = 0) As Byte()
        If Data.Length <= 0 Then
            Throw New ArgumentException("Buffer")
        End If
        If Data Is Nothing Then
            Throw New ArgumentNullException("Buffer")
        End If

        Dim buffer As Byte()

        buffer = ProtectedData.Protect(Data, Encoding.UTF8.GetBytes(Entropy), Scope)

        Return buffer
    End Function

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

End Module
