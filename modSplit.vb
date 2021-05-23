Imports System
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module modSplit

    Dim infile As String
    Dim otfile As String
    Dim otFldr As String
    Dim a As Byte
    Dim filectr As Long
    Dim fsz As Long
    Dim app_path As String = CurDir()

    '
    ' -------------------------------- < FileExists > --------------------------
    '
    Public Function FileExists(ByVal p_FileName As String) As Boolean
        On Error Resume Next
        Dim sr As StreamReader = New StreamReader(p_FileName)

        ' MsgBox Err.Number
        If Err.Number <> 0 Then
            FileExists = vbFalse
        Else
            FileExists = vbTrue
            sr.Close()
        End If

    End Function
    '
    '  ------------- < LoadFile > -------------
    '  called by MAIN
    '  Load binary data 1 byte at a time into array arrfile(fsz)
    '  fsz = file size
    '
    Private Sub LoadFile()
        On Error GoTo handler
        fsz = 1
        filectr = 1

        otfile = otFldr & "\out" & CStr(filectr) & ".txt"
        If FileExists(infile) Then
        Else
            MsgBox("file " & infile & " does not exist.")
            End
        End If
        ' PrintIt "loading file " & Combo1.Text & "\" & txtFile.Text
        Dim iFr As Short
        Dim ReadString As String

        iFr = FreeFile()
        ReadString = infile
        FileOpen(iFr, ReadString, OpenMode.Binary)

        ' Open infile For Binary As #24  ' hello.txt

        Dim iFrO As Short
        Dim ReadStringO As String

        iFrO = FreeFile()
        ReadStringO = otfile
        FileOpen(iFrO, ReadStringO, OpenMode.Binary)

        'Open otfile For Binary Access Write As #44


        While Not EOF(iFr)


            If fsz > 1048576 Then     ' 1048576 1M
                'Close #44
                FileClose(iFrO)

                filectr = filectr + 1
                otfile = otFldr & "\out" & CStr(filectr) & ".txt"

                'iFrO = FreeFile()
                ReadStringO = otfile
                FileOpen(iFrO, ReadStringO, OpenMode.Binary)

                'Open otfile For Binary Access Write As #44
                fsz = 1
            End If

            'Get #24, , a
            'Put #44, , a

            FileGet(iFr, a)
            FilePut(iFrO, a)

            fsz = fsz + 1  ' move on to next byte
            'DoEvents()  ' Allow operating system to do its thing
        End While
        FileClose(iFr)
        FileClose(iFrO)
        Beep()

        Exit Sub
handler:
        MsgBox("error in LoadFile: " & CStr(Err.Number) & ", " & Err.Description & vbCrLf & _
               "file=" & infile)

    End Sub  '  LoadFile

    Sub Main()

        infile = Module1.sjFile
        otFldr = Path.GetDirectoryName(infile)
        otfile = Path.GetDirectoryName(infile) & "\out01.txt"
        Call LoadFile()

    End Sub

End Module
