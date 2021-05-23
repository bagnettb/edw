<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdStart = New System.Windows.Forms.Button
        Me.txtKey = New System.Windows.Forms.TextBox
        Me.cmdOpen = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.radDec = New System.Windows.Forms.RadioButton
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.radEnc = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radJoin = New System.Windows.Forms.RadioButton
        Me.radSplit = New System.Windows.Forms.RadioButton
        Me.radModDate = New System.Windows.Forms.RadioButton
        Me.radUnzip = New System.Windows.Forms.RadioButton
        Me.radZip = New System.Windows.Forms.RadioButton
        Me.radDecString = New System.Windows.Forms.RadioButton
        Me.radEncString = New System.Windows.Forms.RadioButton
        Me.radB64Txt = New System.Windows.Forms.RadioButton
        Me.radTxtB64 = New System.Windows.Forms.RadioButton
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.txtMesgBox = New System.Windows.Forms.TextBox
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSwap = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdWinExplorer = New System.Windows.Forms.Button
        Me.cmdFolder = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdWindow = New System.Windows.Forms.Button
        Me.radTextB64 = New System.Windows.Forms.RadioButton
        Me.radB64Text = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(233, 119)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(59, 21)
        Me.cmdStart.TabIndex = 4
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'txtKey
        '
        Me.txtKey.Location = New System.Drawing.Point(29, 93)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(263, 20)
        Me.txtKey.TabIndex = 2
        '
        'cmdOpen
        '
        Me.cmdOpen.Location = New System.Drawing.Point(29, 119)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(75, 21)
        Me.cmdOpen.TabIndex = 3
        Me.cmdOpen.Text = "Select File"
        Me.cmdOpen.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(29, 161)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(529, 20)
        Me.TextBox1.TabIndex = 8
        '
        'radDec
        '
        Me.radDec.AutoSize = True
        Me.radDec.ForeColor = System.Drawing.Color.White
        Me.radDec.Location = New System.Drawing.Point(6, 36)
        Me.radDec.Name = "radDec"
        Me.radDec.Size = New System.Drawing.Size(62, 17)
        Me.radDec.TabIndex = 1
        Me.radDec.TabStop = True
        Me.radDec.Text = "Decrypt"
        Me.radDec.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(29, 196)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(529, 20)
        Me.TextBox2.TabIndex = 9
        '
        'radEnc
        '
        Me.radEnc.AutoSize = True
        Me.radEnc.ForeColor = System.Drawing.Color.White
        Me.radEnc.Location = New System.Drawing.Point(6, 13)
        Me.radEnc.Name = "radEnc"
        Me.radEnc.Size = New System.Drawing.Size(61, 17)
        Me.radEnc.TabIndex = 0
        Me.radEnc.TabStop = True
        Me.radEnc.Text = "Encrypt"
        Me.radEnc.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Key"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radB64Text)
        Me.GroupBox1.Controls.Add(Me.radTextB64)
        Me.GroupBox1.Controls.Add(Me.radJoin)
        Me.GroupBox1.Controls.Add(Me.radSplit)
        Me.GroupBox1.Controls.Add(Me.radModDate)
        Me.GroupBox1.Controls.Add(Me.radUnzip)
        Me.GroupBox1.Controls.Add(Me.radZip)
        Me.GroupBox1.Controls.Add(Me.radDecString)
        Me.GroupBox1.Controls.Add(Me.radEncString)
        Me.GroupBox1.Controls.Add(Me.radB64Txt)
        Me.GroupBox1.Controls.Add(Me.radTxtB64)
        Me.GroupBox1.Controls.Add(Me.radDec)
        Me.GroupBox1.Controls.Add(Me.radEnc)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(29, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 62)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Menu"
        '
        'radJoin
        '
        Me.radJoin.AutoSize = True
        Me.radJoin.ForeColor = System.Drawing.Color.White
        Me.radJoin.Location = New System.Drawing.Point(394, 36)
        Me.radJoin.Name = "radJoin"
        Me.radJoin.Size = New System.Drawing.Size(44, 17)
        Me.radJoin.TabIndex = 10
        Me.radJoin.TabStop = True
        Me.radJoin.Text = "Join"
        Me.radJoin.UseVisualStyleBackColor = True
        '
        'radSplit
        '
        Me.radSplit.AutoSize = True
        Me.radSplit.ForeColor = System.Drawing.Color.White
        Me.radSplit.Location = New System.Drawing.Point(393, 13)
        Me.radSplit.Name = "radSplit"
        Me.radSplit.Size = New System.Drawing.Size(45, 17)
        Me.radSplit.TabIndex = 9
        Me.radSplit.TabStop = True
        Me.radSplit.Text = "Split"
        Me.radSplit.UseVisualStyleBackColor = True
        '
        'radModDate
        '
        Me.radModDate.AutoSize = True
        Me.radModDate.ForeColor = System.Drawing.Color.White
        Me.radModDate.Location = New System.Drawing.Point(444, 36)
        Me.radModDate.Name = "radModDate"
        Me.radModDate.Size = New System.Drawing.Size(66, 17)
        Me.radModDate.TabIndex = 8
        Me.radModDate.TabStop = True
        Me.radModDate.Text = "LastMod"
        Me.radModDate.UseVisualStyleBackColor = True
        '
        'radUnzip
        '
        Me.radUnzip.AutoSize = True
        Me.radUnzip.ForeColor = System.Drawing.Color.White
        Me.radUnzip.Location = New System.Drawing.Point(325, 36)
        Me.radUnzip.Name = "radUnzip"
        Me.radUnzip.Size = New System.Drawing.Size(68, 17)
        Me.radUnzip.TabIndex = 7
        Me.radUnzip.TabStop = True
        Me.radUnzip.Text = "PKUnZip"
        Me.radUnzip.UseVisualStyleBackColor = True
        '
        'radZip
        '
        Me.radZip.AutoSize = True
        Me.radZip.ForeColor = System.Drawing.Color.White
        Me.radZip.Location = New System.Drawing.Point(325, 13)
        Me.radZip.Name = "radZip"
        Me.radZip.Size = New System.Drawing.Size(54, 17)
        Me.radZip.TabIndex = 6
        Me.radZip.TabStop = True
        Me.radZip.Text = "PKZip"
        Me.radZip.UseVisualStyleBackColor = True
        '
        'radDecString
        '
        Me.radDecString.AutoSize = True
        Me.radDecString.ForeColor = System.Drawing.Color.White
        Me.radDecString.Location = New System.Drawing.Point(83, 36)
        Me.radDecString.Name = "radDecString"
        Me.radDecString.Size = New System.Drawing.Size(72, 17)
        Me.radDecString.TabIndex = 5
        Me.radDecString.TabStop = True
        Me.radDecString.Text = "DecString"
        Me.radDecString.UseVisualStyleBackColor = True
        '
        'radEncString
        '
        Me.radEncString.AutoSize = True
        Me.radEncString.ForeColor = System.Drawing.Color.White
        Me.radEncString.Location = New System.Drawing.Point(84, 13)
        Me.radEncString.Name = "radEncString"
        Me.radEncString.Size = New System.Drawing.Size(71, 17)
        Me.radEncString.TabIndex = 4
        Me.radEncString.TabStop = True
        Me.radEncString.Text = "EncString"
        Me.radEncString.UseVisualStyleBackColor = True
        '
        'radB64Txt
        '
        Me.radB64Txt.AutoSize = True
        Me.radB64Txt.ForeColor = System.Drawing.Color.White
        Me.radB64Txt.Location = New System.Drawing.Point(173, 36)
        Me.radB64Txt.Name = "radB64Txt"
        Me.radB64Txt.Size = New System.Drawing.Size(62, 17)
        Me.radB64Txt.TabIndex = 3
        Me.radB64Txt.TabStop = True
        Me.radB64Txt.Text = "B64-Zip"
        Me.radB64Txt.UseVisualStyleBackColor = True
        '
        'radTxtB64
        '
        Me.radTxtB64.AutoSize = True
        Me.radTxtB64.ForeColor = System.Drawing.Color.White
        Me.radTxtB64.Location = New System.Drawing.Point(173, 13)
        Me.radTxtB64.Name = "radTxtB64"
        Me.radTxtB64.Size = New System.Drawing.Size(62, 17)
        Me.radTxtB64.TabIndex = 2
        Me.radTxtB64.TabStop = True
        Me.radTxtB64.Text = "Zip-B64"
        Me.radTxtB64.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtMesgBox
        '
        Me.txtMesgBox.Location = New System.Drawing.Point(29, 234)
        Me.txtMesgBox.Multiline = True
        Me.txtMesgBox.Name = "txtMesgBox"
        Me.txtMesgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMesgBox.Size = New System.Drawing.Size(529, 69)
        Me.txtMesgBox.TabIndex = 10
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(428, 92)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(59, 21)
        Me.cmdDelete.TabIndex = 11
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        Me.cmdDelete.Visible = False
        '
        'cmdSwap
        '
        Me.cmdSwap.Location = New System.Drawing.Point(364, 121)
        Me.cmdSwap.Name = "cmdSwap"
        Me.cmdSwap.Size = New System.Drawing.Size(59, 21)
        Me.cmdSwap.TabIndex = 6
        Me.cmdSwap.Text = "Swap"
        Me.cmdSwap.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(299, 121)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(59, 21)
        Me.cmdClear.TabIndex = 7
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdWinExplorer
        '
        Me.cmdWinExplorer.Location = New System.Drawing.Point(299, 92)
        Me.cmdWinExplorer.Name = "cmdWinExplorer"
        Me.cmdWinExplorer.Size = New System.Drawing.Size(59, 21)
        Me.cmdWinExplorer.TabIndex = 5
        Me.cmdWinExplorer.Text = "Folder"
        Me.cmdWinExplorer.UseVisualStyleBackColor = True
        '
        'cmdFolder
        '
        Me.cmdFolder.Location = New System.Drawing.Point(110, 119)
        Me.cmdFolder.Name = "cmdFolder"
        Me.cmdFolder.Size = New System.Drawing.Size(97, 21)
        Me.cmdFolder.TabIndex = 16
        Me.cmdFolder.Text = "Select Folder"
        Me.cmdFolder.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(32, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Input File/String"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(32, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Output File/String"
        '
        'cmdWindow
        '
        Me.cmdWindow.Location = New System.Drawing.Point(364, 92)
        Me.cmdWindow.Name = "cmdWindow"
        Me.cmdWindow.Size = New System.Drawing.Size(58, 21)
        Me.cmdWindow.TabIndex = 19
        Me.cmdWindow.Text = "CmdWin"
        Me.cmdWindow.UseVisualStyleBackColor = True
        '
        'radTextB64
        '
        Me.radTextB64.AutoSize = True
        Me.radTextB64.ForeColor = System.Drawing.Color.White
        Me.radTextB64.Location = New System.Drawing.Point(250, 13)
        Me.radTextB64.Name = "radTextB64"
        Me.radTextB64.Size = New System.Drawing.Size(64, 17)
        Me.radTextB64.TabIndex = 11
        Me.radTextB64.TabStop = True
        Me.radTextB64.Text = "text-B64"
        Me.radTextB64.UseVisualStyleBackColor = True
        '
        'radB64Text
        '
        Me.radB64Text.AutoSize = True
        Me.radB64Text.ForeColor = System.Drawing.Color.White
        Me.radB64Text.Location = New System.Drawing.Point(250, 36)
        Me.radB64Text.Name = "radB64Text"
        Me.radB64Text.Size = New System.Drawing.Size(64, 17)
        Me.radB64Text.TabIndex = 12
        Me.radB64Text.TabStop = True
        Me.radB64Text.Text = "B64-text"
        Me.radB64Text.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(590, 315)
        Me.Controls.Add(Me.cmdWindow)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdFolder)
        Me.Controls.Add(Me.cmdWinExplorer)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdSwap)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.txtMesgBox)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.cmdOpen)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Encrypt/Decrypt/B64 encode/B64 decode"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents txtKey As System.Windows.Forms.TextBox
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents radDec As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents radEnc As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtMesgBox As System.Windows.Forms.TextBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSwap As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdWinExplorer As System.Windows.Forms.Button
    Friend WithEvents radB64Txt As System.Windows.Forms.RadioButton
    Friend WithEvents radTxtB64 As System.Windows.Forms.RadioButton
    Friend WithEvents radDecString As System.Windows.Forms.RadioButton
    Friend WithEvents radEncString As System.Windows.Forms.RadioButton
    Friend WithEvents radZip As System.Windows.Forms.RadioButton
    Friend WithEvents radUnzip As System.Windows.Forms.RadioButton
    Friend WithEvents cmdFolder As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdWindow As System.Windows.Forms.Button
    Friend WithEvents radModDate As System.Windows.Forms.RadioButton
    Friend WithEvents radSplit As System.Windows.Forms.RadioButton
    Friend WithEvents radJoin As System.Windows.Forms.RadioButton
    Friend WithEvents radB64Text As System.Windows.Forms.RadioButton
    Friend WithEvents radTextB64 As System.Windows.Forms.RadioButton

End Class
