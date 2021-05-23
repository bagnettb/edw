'Imports System
'Imports System.IO
'Imports System.Security
'Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
'Imports System.Text


Module Module1
    Public sjFolder As String
    Public sjFile As String

    ' Call this function to remove the key from memory after it is used for security.
    <DllImport("kernel32.dll")> _
    Public Sub ZeroMemory(ByVal addr As IntPtr, ByVal size As Integer)
    End Sub

End Module
