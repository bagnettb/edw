Imports System
Imports System.Xml
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Random
Imports System.IO.Compression




Public Class Form1

    Dim rnd1 As New Random()
    Dim tempfile As String
    Dim edOption As String
    '
    ' ------------------------------ < GenerateKey > ------------------------------
    ' Function to generate a 64-bit key.
    '
    Function GenerateKey() As String
        ' Create an instance of a symmetric algorithm. The key and the IV are generated automatically.
        Dim desCrypto As DESCryptoServiceProvider = DESCryptoServiceProvider.Create()

        ' Use the automatically generated key for encryption. 
        Return ASCIIEncoding.ASCII.GetString(desCrypto.Key)

    End Function  '  GenerateKey

    '
    ' ------------------------------ < TruncateHash > ------------------------------
    ' 
    Private Function TruncateHash( _
 ByVal key As String, _
 ByVal length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key. 
        Dim keyBytes() As Byte = _
        System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash. 
        ReDim Preserve hash(length - 1)
        Return hash
    End Function  '  TruncateHash


    '
    ' ------------------------------ < EncryptFile > ------------------------------
    ' 
    Sub EncryptFile(ByVal sInputFilename As String, _
                    ByVal sOutputFilename As String, _
                    ByVal sKey As String)

        Dim fsInput As New FileStream(sInputFilename, _
                                    FileMode.Open, FileAccess.Read)
        Dim fsEncrypted As New FileStream(sOutputFilename, _
                                    FileMode.Create, FileAccess.Write)

        Dim DES As New DESCryptoServiceProvider()

        ''Set secret key for DES algorithm.
        ''A 64-bit key and an IV are required for this provider.
        'DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey)

        ''Set the initialization vector.
        'DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        ' Initialize the crypto provider.
        DES.Key = TruncateHash(sKey, DES.KeySize \ 8)
        DES.IV = TruncateHash("", DES.BlockSize \ 8)

        'Create the DES encryptor from this instance.
        Dim desencrypt As ICryptoTransform = DES.CreateEncryptor()
        'Create the crypto stream that transforms the file stream by using DES encryption.
        Dim cryptostream As New CryptoStream(fsEncrypted, _
                                            desencrypt, _
                                            CryptoStreamMode.Write)

        'Read the file text to the byte array.
        Dim bytearrayinput(fsInput.Length - 1) As Byte
        fsInput.Read(bytearrayinput, 0, bytearrayinput.Length)
        'Write out the DES encrypted file.
        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Close()
    End Sub  '  EncryptFile

    '
    ' ------------------------------ < DecryptFile > ------------------------------
    ' 
    Sub DecryptFile(ByVal sInputFilename As String, _
        ByVal sOutputFilename As String, _
        ByVal sKey As String)

        Dim DES As New DESCryptoServiceProvider()

        ''A 64-bit key and an IV are required for this provider.
        ''Set the secret key for the DES algorithm.
        'DES.Key() = ASCIIEncoding.ASCII.GetBytes(sKey)
        ''Set the initialization vector.
        'DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        ' Initialize the crypto provider.
        DES.Key = TruncateHash(sKey, DES.KeySize \ 8)
        DES.IV = TruncateHash("", DES.BlockSize \ 8)

        'Create the file stream to read the encrypted file back.
        Dim fsread As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)
        'Create the DES decryptor from the DES instance.
        Dim desdecrypt As ICryptoTransform = DES.CreateDecryptor()
        'Create the crypto stream set to read and to do a DES decryption transform on incoming bytes.
        Dim cryptostreamDecr As New CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read)
        'Print out the contents of the decrypted file.
        Try
            Dim fsDecrypted As New StreamWriter(sOutputFilename)
            fsDecrypted.Write(New StreamReader(cryptostreamDecr).ReadToEnd)
            fsDecrypted.Flush()
            fsDecrypted.Close()
        Catch
            MsgBox(Err.Description)
        End Try

    End Sub  '  DecryptFile

    '
    ' ------------------------------ < DecodeFile > ------------------------------
    ' 
    Sub DecodeFile(ByVal srcFile As String, ByVal destFile As String)
        Try
            Dim src As String
            Dim sr As New IO.StreamReader(srcFile)
            src = sr.ReadToEnd
            sr.Close()
            Dim bt64 As Byte() = System.Convert.FromBase64String(src)
            If IO.File.Exists(destFile) Then
                IO.File.Delete(destFile)
            End If
            Dim sw As New IO.FileStream(destFile, IO.FileMode.Create)
            sw.Write(bt64, 0, bt64.Length)
            sw.Close()
        Catch
            txtMesgBox.Text = Err.Description
        End Try
    End Sub  '  DecodeFile

    '
    ' ------------------------------ < EncodeFile > ------------------------------
    ' 
    Sub EncodeFile(ByVal srcFile As String, ByVal destfile As String)
        Try
            Dim srcBT As Byte()
            Dim dest As String
            Dim sr As New IO.FileStream(srcFile, IO.FileMode.Open)
            ReDim srcBT(sr.Length)
            sr.Read(srcBT, 0, sr.Length)
            sr.Close()
            dest = System.Convert.ToBase64String(srcBT)
            Dim sw As New IO.StreamWriter(destfile, False)
            sw.Write(dest)
            sw.Close()
        Catch
            txtMesgBox.Text = Err.Description
        End Try

    End Sub  '  EncodeFile

    Public Sub TestEncoding()
        Dim plainText As String = TextBox1.Text
        Dim password As String = txtKey.Text

        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        TextBox2.Text = cipherText

    End Sub

    Public Sub TestDecoding()
        Dim cipherText As String = TextBox1.Text
        Dim password As String = txtKey.Text

        Dim wrapper As New Simple3Des(password)

        ' DecryptData throws if the wrong password is used. 
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            TextBox2.Text = plainText
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
        End Try
    End Sub
    '
    ' ------------------------------ < App_Path > ------------------------------
    ' 
    Public Function App_Path() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function  '  App_Path



    '
    ' ------------------------------ < Form1_Load > ------------------------------
    ' 
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strCmdLine As String = System.Environment.CommandLine
        'Dim strCmdLine As String = Replace("edw.exe E plain.txt plainenc.txt 1234%205678", "%20", " ")

        Dim s() As String = Split(strCmdLine, " ")
        'Dim s() As String = {"EncDec_work.exe", "E", "test.jpg", "test.enc"}
        'Dim s() As String = {"EncDec_work.exe", "D", "test.enc", "test2.jpg"}
        Dim optEndDec As String
        Dim fileIN As String
        Dim fileOUT As String
        Dim fileKey As String
        '        tempfile = App_Path() & CStr(rnd1.Next) & ".b64"
        tempfile = App_Path() & "edw_temp.b64"

        If UBound(s) <> 4 Then
            txtMesgBox.Text = "batch command: edw.exe (E|D) in_file out_file key. " & vbCrLf
            radDec.Checked = vbTrue
            Call readconfig()

            ' User will see form appear on screen if no parameters are provided
            Exit Sub
        Else
            ' edw.exe = s(0)
            optEndDec = s(1)
            fileIN = s(2)
            fileOUT = s(3)
            fileKey = s(4)
            'MsgBox(optEndDec & "," & fileIN & "," & fileOUT)
        End If

        'Must be 64 bits, 8 bytes.
        Dim sSecretKey As String = fileKey

        ' Get the key for the file to encrypt.
        ' You can distribute this key to the user who will decrypt the file.
        ' sSecretKey = GenerateKey()

        ' For additional security, pin the key.
        Dim gch As GCHandle = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned)

        If UCase(optEndDec) = "E" Then
            ' Encrypt the file.        
            Call EncodeFile(fileIN, tempfile)

            EncryptFile(tempfile, _
                            fileOUT, _
                            sSecretKey)

        End If

        If UCase(optEndDec) = "D" Then

            ' Decrypt the file.
            DecryptFile(fileIN, _
                        tempfile, _
                        sSecretKey)

            Call DecodeFile(tempfile, fileOUT)

            'System.IO.File.Delete("temp.b64")
            ' Remove the key from memory. 
        End If
        ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2)
        gch.Free()

        Try
            If System.IO.File.Exists(tempfile) = vbTrue Then
                System.IO.File.Delete(tempfile)
            End If
        Catch
            Console.WriteLine(Err.Description)
        End Try

        If System.IO.File.Exists(tempfile) = True Then
            Try
                System.IO.File.Delete(tempfile)
            Catch
            End Try
        End If


        If UBound(s) <> 4 Then
        Else
            ' don't display form if parameters were used
            Me.Dispose()
            Exit Sub
        End If

    End Sub  '  Form1_Load

    '
    ' ------------------------------ < readconfig > ------------------------------
    ' 
    Private Sub readconfig()
        If File.Exists("ECOption.xml") Then
            Dim Doc As New XmlDocument
            Dim Input As New XmlTextReader("ECOption.xml")
            Input.WhitespaceHandling = WhitespaceHandling.None
            Do While Input.Read()
                If Input.NodeType = XmlNodeType.Element Then
                    Select Case Input.Name
                        Case "ECOption"
                            edOption = Input.ReadString()
                    End Select
                End If
            Loop
        End If

        Select Case edOption
            Case "E"
                radEnc.Checked = vbTrue
            Case "D"
                radDec.Checked = vbTrue
            Case "B"
                radTxtB64.Checked = vbTrue
            Case "T"
                radB64Txt.Checked = vbTrue
            Case Else
                radEnc.Checked = vbTrue
        End Select
    End Sub  '  readconfig

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    End Sub

    '
    ' ------------------------------ < cmdOpen_Click > ------------------------------
    ' select file button
    '
    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click

        If radEncString.Checked = vbTrue Or radDecString.Checked = vbTrue Then
            txtMesgBox.Text = "No need to select a file when encrypting/decrypting a text string"
            Exit Sub
        End If


        ' make sure one of the radio buttons is checked
        If radEnc.Checked = vbTrue Or radDec.Checked = vbTrue Or _
           radTxtB64.Checked = vbTrue Or radB64Txt.Checked = vbTrue Or _
           radZip.Checked = vbTrue Or radUnzip.Checked = vbTrue Or _
           radSplit.Checked = vbTrue Or radJoin.Checked = vbTrue Then
        Else
            txtMesgBox.Text = "Please check either the Encode or Decode radio button before selecting a file"
            Exit Sub
        End If

        OpenFileDialog1.Title = "Please Select a File"
        OpenFileDialog1.InitialDirectory = _
            System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        OpenFileDialog1.ShowDialog()
        TextBox1.Text = OpenFileDialog1.FileName

        ' User checked encrypt/decrypt
        If radEnc.Checked = vbTrue Or radDec.Checked = vbTrue Then
            If radEnc.Checked = vbTrue Then
                TextBox2.Text = OpenFileDialog1.FileName & ".enc"
            Else
                ' If decoding a file that ends with ".enc".  Strip it off. ".Substring" is 0-relative
                Dim filestr As String = OpenFileDialog1.FileName
                If filestr.Substring(filestr.Length - 4) = ".enc" Then
                    TextBox2.Text = filestr.Substring(0, filestr.Length - 4)
                Else
                    TextBox2.Text = OpenFileDialog1.FileName & ".dec"
                End If

            End If  '  radEnc.Checked = vbTrue
        End If  '  radEnc.Checked = vbTrue Or radDec.Checked = vbTrue

        ' User checked B64
        If radTxtB64.Checked = vbTrue Or radB64Txt.Checked = vbTrue Then
            If radTxtB64.Checked = vbTrue Then
                ' If encoding a file that ends with ".zip".  Strip it off. ".Substring" is 0-relative
                Dim filestr As String = OpenFileDialog1.FileName
                If filestr.Substring(filestr.Length - 4) = ".zip" Then
                    TextBox2.Text = filestr.Substring(0, filestr.Length - 4) & ".txt"
                Else
                    TextBox2.Text = OpenFileDialog1.FileName & ".txt"
                End If
            Else
                ' If decoding a file that ends with ".enc".  Strip it off. ".Substring" is 0-relative
                Dim filestr As String = OpenFileDialog1.FileName
                If filestr.Substring(filestr.Length - 4) = ".txt" Then
                    TextBox2.Text = filestr.Substring(0, filestr.Length - 4) & ".zip"
                Else
                    TextBox2.Text = OpenFileDialog1.FileName & ".zip"
                End If

            End If  '  radEnc.Checked = vbTrue
        End If  '  radEnc.Checked = vbTrue Or radDec.Checked = vbTrue


        ' User checked B64
        If radZip.Checked = vbTrue Or radUnzip.Checked = vbTrue Then
            Dim filestr As String = OpenFileDialog1.FileName
            If radZip.Checked = vbTrue Then
                TextBox2.Text = filestr.Substring(0, filestr.Length - 4) & ".zip"
            Else
                ' If decoding a file that ends with ".enc".  Strip it off. ".Substring" is 0-relative
                If filestr.Substring(filestr.Length - 4) = ".zip" Then
                    TextBox2.Text = filestr.Substring(0, filestr.Length - 4)
                Else
                    TextBox2.Text = filestr & ".!zip"
                End If

            End If  '  radEnc.Checked = vbTrue
        End If  '  radEnc.Checked = vbTrue Or radDec.Checked = vbTrue


    End Sub  '  cmdOpen_Click

    Private Sub OpenFileDialog1_FileOk_1(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    '
    ' ------------------------------ < cmdStart_Click > ------------------------------
    ' start button
    '
    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        Dim fileIN As String
        Dim fileOUT As String
        'tempfile = App_Path() & CStr(rnd1.Next) & ".b64"

        txtMesgBox.Text = "clicked Start button" & vbCrLf & txtMesgBox.Text

        ' last date this program was modified
        If radModDate.Checked = vbTrue Then
            txtMesgBox.Text = "Date Last Modified=" & IO.File.GetLastWriteTime("edw.exe")
            Exit Sub
        End If

        'any encrypting/decrypting a string/file requires the key 
        If (radEnc.Checked = vbTrue Or radDec.Checked = vbTrue Or _
            radEncString.Checked = vbTrue Or radDecString.Checked = vbTrue) And txtKey.Text = "" Then
            txtMesgBox.Text = "Enter a key value." & vbCrLf
            Exit Sub
        End If

        ' all functions require input file/text (TextBox1.Text)
        If TextBox1.Text = "" Then
            txtMesgBox.Text = "Enter an input value in 1st textbox." & vbCrLf
            Exit Sub
        End If

        ' Split
        If radSplit.Checked = vbTrue Then
            Diagnostics.Debug.Print(Path.GetDirectoryName(TextBox1.Text))
            Module1.sjFile = TextBox1.Text
            Call modSplit.Main()
            txtMesgBox.Text = "Done!" & vbCrLf & txtMesgBox.Text
        End If

        ' Join
        If radJoin.Checked = vbTrue Then
            Diagnostics.Debug.Print(Path.GetDirectoryName(TextBox1.Text))
            Module1.sjFile = TextBox1.Text
            Call modJoin.Main()
            txtMesgBox.Text = "Done!" & vbCrLf & txtMesgBox.Text
        End If


        ' Encrypt/Decrypt function
        If (radEnc.Checked = vbTrue Or radDec.Checked = vbTrue Or _
            radTxtB64.Checked = vbTrue Or radB64Txt.Checked = vbTrue) And TextBox2.Text = "" Then
            txtMesgBox.Text = "Enter an output value in 2nd textbox." & vbCrLf
            Exit Sub
        End If

        fileIN = TextBox1.Text
        fileOUT = TextBox2.Text
        'MsgBox(optEndDec & "," & fileIN & "," & fileOUT)


        'Must be 64 bits, 8 bytes.
        Dim sSecretKey As String = txtKey.Text

        ' Get the key for the file to encrypt.
        ' You can distribute this key to the user who will decrypt the file.
        ' sSecretKey = GenerateKey()

        ' For additional security, pin the key.
        Dim gch As GCHandle = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned)

        If radZip.Checked = vbTrue Then
            Call ZipIt()
        End If

        If radUnzip.Checked = vbTrue Then
            Call UnZipIt()
        End If


        If radEnc.Checked = vbTrue Then
            ' Encrypt the file.        
            Call EncodeFile(fileIN, tempfile)

            EncryptFile(tempfile, _
                            fileOUT, _
                            sSecretKey)

        End If

        If radDec.Checked = vbTrue Then

            ' Decrypt the file.
            DecryptFile(fileIN, tempfile, sSecretKey)

            Call DecodeFile(tempfile, fileOUT)

            'System.IO.File.Delete("temp.b64")
            ' Remove the key from memory. 
        End If

        If (radEnc.Checked = vbTrue) Or (radDec.Checked = vbTrue) Then
            ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2)
            gch.Free()

            'Call ClearFile()  I'll null the file out in batch file edw.bat
            'Call Button1_Click(sender, e)
            txtMesgBox.Text = "Done!" & vbCrLf & txtMesgBox.Text
            ' System.IO.File.Delete("temp.b64")
            ' Remove the key from memory. 
        End If


        If radTxtB64.Checked = vbTrue Then
            ' Encrypt the file.        
            Call EncodeFile(fileIN, fileOUT)
            txtMesgBox.Text = "Done!" & vbCrLf & txtMesgBox.Text
        End If

        If radB64Txt.Checked = vbTrue Then

            ' Decode the file.
            Call DecodeFile(fileIN, fileOUT)
            txtMesgBox.Text = "Done!" & vbCrLf & txtMesgBox.Text
        End If


        If radEncString.Checked = vbTrue Then
            If txtKey.Text = "" Then
                txtMesgBox.Text = "Enter a key value." & vbCrLf
            Else
                ' Encrypt the file.        
                Call TestEncoding()
                txtMesgBox.Text = "Done!" & vbCrLf & txtMesgBox.Text
            End If
        End If

            If radDecString.Checked = vbTrue Then
            If txtKey.Text = "" Then
                txtMesgBox.Text = "Enter a key value." & vbCrLf
            Else

                ' Decode the file.
                Call TestDecoding()
                txtMesgBox.Text = "Done!" & vbCrLf & txtMesgBox.Text
            End If
        End If

        If radTextB64.Checked = vbTrue Then
            TextBox2.Text = Base64Encode(TextBox1.Text)
        End If

        If radB64Text.Checked = vbTrue Then
            TextBox2.Text = Base64Decode(TextBox1.Text)
        End If

    End Sub  '  cmdStart_Click



    Private Sub ZipIt()
        txtMesgBox.Text = "zip -r " & TextBox2.Text & "  " & TextBox1.Text & vbCrLf & vbCrLf & _
                          "unzip -l " & TextBox2.Text
        Try
            Dim sw As New System.IO.StreamWriter("z.bat", False)
            Dim detail As String
            detail = "zip -r " & TextBox2.Text & "  " & TextBox1.Text
            sw.WriteLine(detail)
            sw.Close()
            Shell("z.bat", AppWinStyle.NormalFocus)

        Catch
            txtMesgBox.Text = Err.Description
        End Try
    End Sub

    Private Sub UnZipIt()
        txtMesgBox.Text = "unzip  " & TextBox1.Text
        Try
            Shell("unzip  " & TextBox1.Text, AppWinStyle.NormalFocus)
        Catch
            txtMesgBox.Text = Err.Description
        End Try
    End Sub

    '
    ' ------------------------------ < ZipIt > ------------------------------
    ' 
    Private Sub _ZipIt()
        'A String object reads the file name (locally)
        Dim FileName As String = TextBox1.Text

        Dim bData As Byte()
        Dim br As BinaryReader = New BinaryReader(System.IO.File.OpenRead(FileName))
        bData = br.ReadBytes(br.BaseStream.Length)
        Dim streamObj As MemoryStream = New MemoryStream(bData, 0, bData.Length)

        'Allocate space in buffer according to the length of the file read
        Dim buffer(streamObj.Length) As Byte

        'Fill buffer
        streamObj.Read(buffer, 0, buffer.Length)
        streamObj.Close()

        'File Stream object used to change the extension of a file
        Dim compFile As System.IO.FileStream = File.Create(TextBox2.Text)

        'GZip object that compress the file 
        Dim zipStreamObj As New GZipStream(compFile, CompressionMode.Compress)

        'Write to the Stream object from the buffer
        zipStreamObj.Write(buffer, 0, buffer.Length)
        zipStreamObj.Close()

    End Sub  '  ZipIt
    '
    ' ------------------------------ < UnZipIt > ------------------------------
    ' 
    Private Sub _UnZipIt()
        'A String object reads the file name (locally)
        Dim FileName As String = TextBox1.Text

        Dim bData As Byte()
        Dim br As BinaryReader = New BinaryReader(System.IO.File.OpenRead(FileName))
        bData = br.ReadBytes(br.BaseStream.Length)
        Dim streamObj As MemoryStream = New MemoryStream(bData, 0, bData.Length)

        'Allocate space in buffer according to the length of the file read
        'Dim buffer(streamObj.Length) As Byte

        'Fill buffer
        'streamObj.Read(buffer, 0, buffer.Length)
        'streamObj.Close()

        'File Stream object used to change the extension of a file
        Dim compFile As System.IO.FileStream = File.Create(TextBox2.Text)

        'GZip object that compress the file 
        Dim zipStreamObj As New GZipStream(streamObj, CompressionMode.Decompress)

        'Write to the Stream object from the buffer
        'zipStreamObj.Write(Buffer, 0, bData.Length)
        'zipStreamObj.Close()

    End Sub  '  UnZipIt

    ' 

    '-----------------------------------------------------------------------------------

    'Base64Encode

    '-----------------------------------------------------------------------------------

    ' Called from Send_Message()

    '

    Function Base64Encode(ByVal inData As String) As String

        Base64Encode = ""

        If inData = "" Then
        Else
            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(inData)
            Base64Encode = Convert.ToBase64String(byt)
        End If

    End Function  '  Base64Encode



    ' 

    '-----------------------------------------------------------------------------------

    'Base64Decode

    '-----------------------------------------------------------------------------------

    ' Called from Send_Message()

    '

    Function Base64Decode(ByVal inData As String) As String

        Base64Decode = ""

        If inData = "" Then
        Else
            Dim byt As Byte()
            byt = Convert.FromBase64String(inData)
            Base64Decode = System.Text.ASCIIEncoding.ASCII.GetString(byt)
        End If

    End Function  '  Base64Decode

    '
    ' ------------------------------ < ClearFile > ------------------------------
    ' 
    Private Sub ClearFile()
        Try
            Application.DoEvents()
            If System.IO.File.Exists(tempfile) = vbTrue Then
                Shell("type NUL > edw_temp.b64")
                'Using writer As StreamWriter = New StreamWriter(tempfile)
                '    writer.WriteLine("cleared")
                'End Using
                Exit Sub
            End If
        Catch
            txtMesgBox.Text = "ClearFile: " & Err.Description & vbCrLf & txtMesgBox.Text
            Dim path As String
            path = System.IO.Path.GetDirectoryName( _
               System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)

            Process.Start("explorer.exe", path)
        End Try

    End Sub  '  ClearFile

    '
    ' ------------------------------ < Button1_Click > ------------------------------
    ' Delete button
    ' 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim i As Integer = 0
        If TextBox2.Text = "" Then
            txtMesgBox.Text = "Include file to delete in 2nd textbox above"
        Else
            Do
                Try
                    Application.DoEvents()
                    If System.IO.File.Exists(TextBox2.Text) = vbTrue Then
                        System.IO.File.Delete(TextBox2.Text)
                        Exit Sub
                    End If
                Catch
                    txtMesgBox.Text = "delete: " & Err.Description & vbCrLf & txtMesgBox.Text
                    System.Threading.Thread.Sleep(10000)
                End Try
                i += 1
            Loop Until (i > 5)
        End If  '  TextBox2.Text = "" 

    End Sub  '  Button1_Click

    '
    ' ------------------------------ < cmdSwap_Click > ------------------------------
    ' swap button
    '

    Private Sub cmdSwap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSwap.Click
        Dim tName As String = "new string"
        If TextBox1.Text = "" And TextBox2.Text = "" Then
            txtMesgBox.Text = "nothing to swap"
            Exit Sub
        End If
        tName = TextBox1.Text
        TextBox1.Text = TextBox2.Text
        TextBox2.Text = tName

        Select Case vbTrue

            Case radTextB64.Checked : radB64Text.Checked = vbTrue
            Case radB64Text.Checked : radTextB64.Checked = vbTrue
            Case radTxtB64.Checked : radB64Txt.Checked = vbTrue
            Case radB64Txt.Checked : radTxtB64.Checked = vbTrue
            Case radEncString.Checked : radDecString.Checked = vbTrue
            Case radDecString.Checked : radEncString.Checked = vbTrue
            Case radEnc.Checked : radDec.Checked = vbTrue
            Case radDec.Checked : radEnc.Checked = vbTrue
                'Case radEncDES.Checked : radDecDES.Checked = vbTrue
                'Case radDecDES.Checked : radEncDES.Checked = vbTrue
            Case (radZip.Checked) : radUnzip.Checked = vbTrue
            Case (radUnzip.Checked) : radZip.Checked = vbTrue

        End Select
    End Sub  '  cmdSwap_Click

    '
    ' ------------------------------ < cmdClear_Click > ------------------------------
    ' clear button
    '
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        txtMesgBox.Text = ""
        txtKey.Text = ""
    End Sub  '  cmdClear_Click

    '
    ' ------------------------------ < cmdWinExplorer_Click > ------------------------------
    ' Folder button
    '
    Private Sub cmdWinExplorer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWinExplorer.Click
        Dim fldr As String
        Try
            'If OpenFileDialog1.FileName = "OpenFileDialog1" Then
            If TextBox1.Text = "" Then
                fldr = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Else
                fldr = TextBox1.Text
            End If
            'Else
            'Dim b As Integer = InStrRev(OpenFileDialog1.FileName, "\")
            'fldr = Mid(OpenFileDialog1.FileName, 1, b)
            'End If
            txtMesgBox.Text = "explorer.exe " & fldr
            Process.Start("explorer.exe", fldr)
        Catch
            txtMesgBox.Text = Err.Description
        End Try
    End Sub  '  cmdWinExplorer_Click

    ' zip file.zip [file|folder]   
    ' see www.info-zip.org
    Private Sub radZip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radZip.CheckedChanged
        If radZip.Checked = vbTrue Then
            txtMesgBox.Text = "PKZIP (Requires PKZip): Select Input file or folder. Select Output file.  Click Start."
        End If
    End Sub

    Private Sub radUnzip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radUnzip.CheckedChanged
        If radUnzip.Checked = vbTrue Then
            txtMesgBox.Text = "PKUNZIP (Requires PKZip): Select Input & Output files.  Click Start."
        End If
    End Sub

    Private Sub radTxtB64_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTxtB64.CheckedChanged
        If radTxtB64.Checked = vbTrue Then
            txtMesgBox.Text = ".ZIP->B64:Select Input/Output files.  Click Start."
        End If
    End Sub

    Private Sub radB64Txt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radB64Txt.CheckedChanged
        If radB64Txt.Checked = vbTrue Then
            txtMesgBox.Text = "B64->.ZIP:Select Input/Output files.  Click Start."
        End If
    End Sub

    Private Sub radEncString_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radEncString.CheckedChanged
        If radEncString.Checked = vbTrue Then
            txtMesgBox.Text = "ENCSTRING:DECSTRING:Enter Key/Input string. Click Start."
        End If
    End Sub

    Private Sub radDecString_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDecString.CheckedChanged
        If radDecString.Checked = vbTrue Then
            txtMesgBox.Text = "DECSTRING:Enter Key/Input string. Click Start."
        End If
    End Sub

    Private Sub radEnc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radEnc.CheckedChanged
        If radEnc.Checked = vbTrue Then
            txtMesgBox.Text = "ENCRYPT:Enter key. Select Input file. Click Start."
        End If
    End Sub

    Private Sub radDec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDec.CheckedChanged
        If radDec.Checked = vbTrue Then
            txtMesgBox.Text = "DECRYPT:Enter key. Select Input file. Click Start."
        End If
    End Sub

    '
    ' select folder button
    '
    Private Sub cmdFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFolder.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            If radZip.Checked = vbTrue Then
                TextBox1.Text = """" & FolderBrowserDialog1.SelectedPath & "\*"""  ' zip all files in folder
            Else
                TextBox1.Text = """" & FolderBrowserDialog1.SelectedPath & """"  ' zip all files in folder
            End If
            Dim fldrName As String
            Dim fldrQual As String
            Dim fldrPtr As Integer
            fldrQual = FolderBrowserDialog1.SelectedPath
            fldrPtr = InStrRev(FolderBrowserDialog1.SelectedPath, "\")
            fldrName = Mid(FolderBrowserDialog1.SelectedPath, fldrPtr)
            fldrName = Replace(fldrName, " ", "_")
            If radZip.Checked = vbTrue Then
                TextBox2.Text = """" & FolderBrowserDialog1.SelectedPath & fldrName & ".zip"""
            Else
                TextBox2.Text = """" & FolderBrowserDialog1.SelectedPath & fldrName & """ "
            End If

        End If

    End Sub


    '
    ' cmd Window button
    '
    Private Sub cmdWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindow.Click
        If TextBox1.Text = "" Then
            Shell("C:\WINDOWS\system32\WindowsPowerShell\v1.0\powershell.exe cd "" " & System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & _
              " """, AppWinStyle.NormalFocus)
            txtMesgBox.Text = "C:\WINDOWS\system32\WindowsPowerShell\v1.0\powershell.exe cd "" " & System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & _
                          """ "
        Else
            Shell("cmd /K ""cd " & TextBox1.Text & """ ", AppWinStyle.NormalFocus)
            txtMesgBox.Text = "cmd /K ""cd " & TextBox1.Text & """ "

        End If
    End Sub

    Private Sub radSplit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSplit.CheckedChanged

    End Sub
End Class
