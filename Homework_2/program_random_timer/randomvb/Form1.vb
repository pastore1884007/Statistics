Public Class Form1

    Public r As New Random
    Public t As New Timer
    Dim numgenerati As Integer = 1000
    Public somma As Double = 0
    Public media As Double
    Public count As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim current As Double = r.NextDouble
        somma = somma + current
        count = count + 1
        Me.RichTextBox1.AppendText(vbCrLf & "Valore corrente: " & current & "  Media attuale: " & somma / count)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Timer1.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.RichTextBox1.AppendText("Genero " & numgenerati & " numeri casuali...")
        Me.RichTextBox1.AppendText(Environment.NewLine)
        For i As Integer = 1 To numgenerati
            Dim valcas As Double = r.NextDouble
            Me.RichTextBox1.AppendText(Environment.NewLine & i & ")  " & valcas)
            somma = somma + valcas
        Next
        Me.RichTextBox1.AppendText(Environment.NewLine)
        Me.RichTextBox1.AppendText(Environment.NewLine & "Media")
        Me.RichTextBox1.AppendText(Environment.NewLine)
        media = somma / numgenerati
        Me.RichTextBox1.AppendText(Environment.NewLine & media)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.RichTextBox1.Clear()
    End Sub
End Class
