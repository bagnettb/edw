Imports System
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions


Module modJoin


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
        'Open p_FileName For Input Access Read As #9
        Dim sr As StreamReader = New StreamReader(p_FileName)

        ' MsgBox Err.Number
        If Err.Number <> 0 Then
            FileExists = vbFalse
        Else
            FileExists = vbTrue
            'Close #9
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

        'Open infile For Binary Access Write As #24  ' hello.txt
        Dim iFr As Short
        Dim ReadString As String
        Dim iFrO As Short
        Dim ReadStringO As String

        iFr = FreeFile()
        ReadString = infile
        FileOpen(iFr, ReadString, OpenMode.Binary)

        otfile = otFldr & "\out" & CStr(filectr) & ".txt"
        Do
            If FileExists(otfile) Then
                ' PrintIt "loading file " & Combo1.Text & "\" & txtFile.Text
                'Open otfile For Binary As #44
                iFrO = FreeFile()
                ReadStringO = otfile
                FileOpen(iFrO, ReadStringO, OpenMode.Binary)


                While Not EOF(iFrO)

                    'Get #44, , a
                    FileGet(iFrO, a)

                    'Put #24, , a
                    FilePut(iFr, a)


                    'DoEvents()  ' Allow operating system to do its thing
                End While

                'Close #44
                FileClose(iFrO)

                filectr = filectr + 1
                otfile = otFldr & "\out" & CStr(filectr) & ".txt"

            Else
                MsgBox("file " & infile & " does not exist.")
                End
            End If  '  FileExists(otfile)
        Loop Until Not FileExists(otfile)

        'Close #24
        FileClose(iFr)

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
