Public Class Form1

    Public b As Bitmap
    Public g As Graphics
    Public r As New Random
    Public PenTrajectory As New Pen(Color.OrangeRed, 2)
    Public b2 As Bitmap
    Public g2 As Graphics

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)
        Me.b2 = New Bitmap(Me.PictureBox2.Width, Me.PictureBox2.Height)
        Me.g2 = Graphics.FromImage(b2)
        Me.g2.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g2.Clear(Color.White)

        Dim TrialsCount As Integer = TrackBar1.Value
        Dim NumerOfTrajectories As Integer = TrackBar2.Value
        Dim SuccessProbability As Double = TrackBar3.Value / 10

        Dim minX As Double = 0
        Dim maxX As Double = TrialsCount
        Dim minY As Double = 0
        Dim maxY As Double = TrialsCount


        Dim VirtualWindow As New Rectangle(20, 20, Me.b.Width - 40, Me.b.Height - 40)

        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        Dim alt(Me.PictureBox1.Height) As Integer
        For i As Integer = 0 To Me.PictureBox1.Height
            alt(i) = 0
        Next

        For i As Integer = 1 To NumerOfTrajectories

            Dim Punti As New List(Of Point)
            Dim Y As Double = 0
            For X As Integer = 1 To TrialsCount
                Dim Uniform As Double = r.NextDouble
                If Uniform < SuccessProbability Then
                    Y = Y + 1
                End If
                Dim xDevice As Integer = FromXRealToXVirtual(X, minX, maxX, VirtualWindow.Left, VirtualWindow.Width)
                Dim YDevice As Integer = FromYRealToYVirtual(Y, minY, maxY, VirtualWindow.Top, VirtualWindow.Height)
                Punti.Add(New Point(xDevice, YDevice))
            Next
            g.DrawLines(PenTrajectory, Punti.ToArray)
            alt(Punti.Last.Y) += 60
        Next

        Me.PictureBox1.Image = b
        Dim pen As New Pen(Color.Black, 5)
        Me.PictureBox2.Image = b2

        For i As Integer = 0 To alt.Length - 1

            g2.DrawLine(pen, 0, i, alt(i), i)

        Next


    End Sub

    Function FromXRealToXVirtual(X As Double,
                                 minX As Double, maxX As Double,
                                 Left As Integer, W As Integer) As Integer

        If (maxX - minX) = 0 Then
            Return 0
        End If

        Return Left + W * (X - minX) / (maxX - minX)

    End Function

    Function FromYRealToYVirtual(Y As Double,
                                minY As Double, maxY As Double,
                                Top As Integer, H As Integer) As Integer

        If (maxY - minY) = 0 Then
            Return 0
        End If

        Return Top + H - H * (Y - minY) / (maxY - minY)

    End Function



    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label1.Text = "Number of trials: " + TrackBar1.Value.ToString
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Label2.Text = "Number of trajectories: " + TrackBar2.Value.ToString
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Label3.Text = "Probability: " + (TrackBar3.Value / 10).ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)
        Me.b2 = New Bitmap(Me.PictureBox2.Width, Me.PictureBox2.Height)
        Me.g2 = Graphics.FromImage(b2)
        Me.g2.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g2.Clear(Color.White)

        Dim TrialsCount As Integer = TrackBar1.Value
        Dim NumerOfTrajectories As Integer = TrackBar2.Value
        Dim SuccessProbability As Double = TrackBar3.Value / 10

        Dim minX As Double = 0
        Dim maxX As Double = TrialsCount
        Dim minY As Double = 0
        Dim maxY As Double = TrialsCount


        Dim VirtualWindow As New Rectangle(20, 20, Me.b.Width - 40, Me.b.Height - 40)

        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        Dim alt(Me.PictureBox1.Height) As Integer
        For i As Integer = 0 To Me.PictureBox1.Height
            alt(i) = 0
        Next

        For i As Integer = 1 To NumerOfTrajectories

            Dim Punti As New List(Of Point)
            Dim Y As Double = 0
            For X As Integer = 1 To TrialsCount
                Dim Uniform As Double = r.NextDouble
                If Uniform < SuccessProbability Then
                    Y = Y + 1
                End If
                Dim xDevice As Integer = FromXRealToXVirtual(X, minX, maxX, VirtualWindow.Left, VirtualWindow.Width)
                Dim YDevice As Integer = FromYRealToYVirtual(Y * TrialsCount / (X + 1), minY, maxY, VirtualWindow.Top, VirtualWindow.Height)
                Punti.Add(New Point(xDevice, YDevice))
            Next
            g.DrawLines(PenTrajectory, Punti.ToArray)
            alt(Punti.Last.Y) += 60
        Next

        Me.PictureBox1.Image = b
        Dim pen As New Pen(Color.Black, 4)
        Me.PictureBox2.Image = b2
        For i As Integer = 0 To alt.Length - 1

            g2.DrawLine(pen, 0, i, alt(i), i)

        Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)
        Me.b2 = New Bitmap(Me.PictureBox2.Width, Me.PictureBox2.Height)
        Me.g2 = Graphics.FromImage(b2)
        Me.g2.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g2.Clear(Color.White)

        Dim TrialsCount As Integer = TrackBar1.Value
        Dim NumerOfTrajectories As Integer = TrackBar2.Value
        Dim SuccessProbability As Double = TrackBar3.Value / 10

        Dim minX As Double = 0
        Dim maxX As Double = TrialsCount
        Dim minY As Double = 0
        Dim maxY As Double = TrialsCount


        Dim VirtualWindow As New Rectangle(20, 20, Me.b.Width - 40, Me.b.Height - 40)

        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        Dim alt(Me.PictureBox1.Height) As Integer
        For i As Integer = 0 To Me.PictureBox1.Height
            alt(i) = 0
        Next

        For i As Integer = 1 To NumerOfTrajectories

            Dim Punti As New List(Of Point)
            Dim Y As Double = 0
            For X As Integer = 1 To TrialsCount
                Dim Uniform As Double = r.NextDouble
                If Uniform < SuccessProbability Then
                    Y = Y + 1
                End If
                Dim xDevice As Integer = FromXRealToXVirtual(X, minX, maxX, VirtualWindow.Left, VirtualWindow.Width)
                Dim YDevice As Integer = FromYRealToYVirtual(Y * Math.Sqrt(TrialsCount) / Math.Sqrt(X + 1), minY, maxY, VirtualWindow.Top, VirtualWindow.Height)
                Punti.Add(New Point(xDevice, YDevice))
            Next
            g.DrawLines(PenTrajectory, Punti.ToArray)
            alt(Punti.Last.Y) += 60
        Next

        Me.PictureBox1.Image = b
        Dim pen As New Pen(Color.Black, 4)
        Me.PictureBox2.Image = b2
        For i As Integer = 0 To alt.Length - 1

            g2.DrawLine(pen, 0, i, alt(i), i)

        Next

    End Sub

End Class