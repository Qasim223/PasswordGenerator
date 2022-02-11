Public Class Form1

    Private Sub BtnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles BtnGenerate.Click

        Dim sr As New System.IO.StreamReader("Z:\Kasim\Development\Password Generator\Dictionary.txt")

        Dim iMaxlines As Integer = 0
        Dim curline As Integer = 0
        Dim Ran As Integer = 0
        Dim Number As Integer
        Dim Symbol As Integer = 0
        Dim SpecialChrs As String = ""
        Dim CharsList = "?,>,<,@,',:,;,#,~,},{,],[,=,-,+,_,),(,*,&,%,£,!,ô"
        Dim RandomClass As New Random()
        Dim UsableChars() As String
        Dim sWord As String = ""
        Dim j As Integer


        Do Until sr.EndOfStream = True
            sr.ReadLine()
            iMaxlines += 1
        Loop
        sr.Dispose()
        sr.Close()


        For j = 1 To 3
            Randomize()
            Ran = Rnd() * iMaxlines

            Dim sr2 As New System.IO.StreamReader("Z:\Kasim\Development\Password Generator\Dictionary.txt")
            curline = 0
            Do Until curline >= Ran
                sWord = sr2.ReadLine()
                curline += 1
            Loop
            sr2.Close()
            sr2.Dispose()
            sr2 = Nothing

            If sWord.Length > 1 Then
                sWord = sWord.Substring(0, 1).ToUpper() + sWord.Substring(1).ToLower

            End If

            Randomize()
            Number = CInt(Math.Floor((999 - 100 + 1) * Rnd())) + 100


            UsableChars = Split(CharsList, ",")
            SpecialChrs = ""

            Symbol = RandomClass.Next(0, UBound(UsableChars))
            SpecialChrs = SpecialChrs + UsableChars(Symbol)

            Select Case j
                Case 1
                    TxtPassword.Text = sWord.Substring(0, 3) & Number & sWord.Substring(3, 3) & SpecialChrs

                Case 2
                    TxtPassword2.Text = sWord.Substring(0, 3) & Number & sWord.Substring(3, 3) & SpecialChrs

                Case 3
                    TxtPassword3.Text = sWord.Substring(0, 3) & Number & sWord.Substring(3, 3) & SpecialChrs

            End Select
        Next

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim path As String
        path = System.IO.Path.GetDirectoryName(
      System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        MessageBox.Show(path)
    End Sub

End Class
