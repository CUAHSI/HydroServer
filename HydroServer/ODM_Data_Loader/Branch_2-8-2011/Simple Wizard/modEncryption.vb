Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module modEncryption
    Public Const Entropy As String = "OdMdL"

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

    'Public Function Decrypt(ByVal data As String, Optional ByVal padding As Byte = 0) As String
    '    Try
    '        Dim bytes() As String = Split(data)
    '        Dim encrypted(bytes.Length - 1) As Byte
    '        Dim i As Integer

    '        For i = 0 To (bytes.Length - 1)
    '            encrypted(i) = Convert.ToInt32(bytes(i), 16)
    '        Next

    '        Dim decrypted As Byte() = DecryptInMemoryData(encrypted, DataProtectionScope.CurrentUser)

    '        For i = (decrypted.Length - 1) To 0 Step -1
    '            If decrypted(i) = padding Then
    '                ReDim Preserve decrypted(i - 1)
    '            Else
    '                Exit For
    '            End If
    '        Next

    '        Return Encoding.UTF8.GetString(decrypted)

    '    Catch ex As Exception
    '        'ShowError("Unable to decrypt data")
    '    End Try

    '    Return ""
    'End Function

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

    'Private Function DecryptInMemoryData(ByVal Data() As Byte, ByVal Scope As MemoryProtectionScope) As Byte()
    '    If Data.Length <= 0 Then
    '        Throw New ArgumentException("Buffer")
    '    End If
    '    If Data Is Nothing Then
    '        Throw New ArgumentNullException("Buffer")
    '    End If

    '    Dim Buffer As Byte()

    '    'Decrypt the data. The result is stored in the same same array as the original data.
    '    Buffer = ProtectedData.Unprotect(Data, Encoding.UTF8.GetBytes(Entropy), Scope)

    '    Return Buffer
    'End Function

End Module
