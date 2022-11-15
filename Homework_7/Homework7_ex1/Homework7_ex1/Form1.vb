Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1

    Public b As Bitmap
    Public g As Graphics
    Public r As New Random
    Public PenTrajectory As New Pen(Color.OrangeRed, 2)
    Public b2 As Bitmap
    Public g2 As Graphics
    Public b3 As Bitmap
    Public g3 As Graphics

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
        Dim SuccessProbability As Double = TrackBar3.Value / TrialsCount

        Dim minX As Double = 0
        Dim maxX As Double = TrialsCount
        Dim minY As Double = 0
        Dim maxY As Double = TrialsCount

        Dim interarrival = 0

        Dim interarrivalDistribution As New Dictionary(Of Integer, Integer)

        Me.b3 = New Bitmap(Me.PictureBox3.Width, Me.PictureBox3.Height)
        Me.g3 = Graphics.FromImage(b3)
        Me.g3.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g3.Clear(Color.White)

        g3.DrawRectangle(New Pen(Color.Black, 1), 0, 0, PictureBox3.Width - 1, PictureBox3.Height - 1)

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
                    If interarrival <> 0 Then
                        If Not interarrivalDistribution.ContainsKey(interarrival) Then
                            interarrivalDistribution.Add(interarrival, 1)
                        Else
                            interarrivalDistribution.Item(interarrival) = interarrivalDistribution.Item(interarrival) + 1
                        End If
                        interarrival = 0
                    End If
                Else
                    interarrival = interarrival + 1
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

        drawVerticalChart(b3, g3, PictureBox3, interarrivalDistribution, TrialsCount)
        PictureBox3.Image = b3

    End Sub

    Function drawVerticalChart(b As Bitmap, g As Graphics, p As PictureBox, distr As Dictionary(Of Integer, Integer), n As Integer)
        Dim j As Integer
        j = 0
        Dim s As Integer
        s = p.Width / distr.Count

        g.DrawRectangle(New Pen(Color.Black), 0, 0, p.Width - 1, p.Height - 1)

        For Each pair As KeyValuePair(Of Integer, Integer) In distr
            Dim virtualX As Double = FromXRealToXVirtual(pair.Value, 0, n, 0, p.Height)
            Dim r As Rectangle = New Rectangle(j + 1, p.Height - CType(virtualX, Integer) - 1, s, CType(virtualX, Integer))
            g.DrawRectangle(New Pen(Color.Black), j + 1, p.Height - CType(virtualX, Integer) - 1, s, CType(virtualX, Integer))
            g.FillRectangle(New SolidBrush(Color.Orange), r)
            j = j + s

        Next

        p.Image = b

    End Function

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
        Label3.Text = "Value of λ: " + (TrackBar3.Value).ToString
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
        Dim SuccessProbability As Double = TrackBar3.Value / TrialsCount

        Dim minX As Double = 0
        Dim maxX As Double = TrialsCount
        Dim minY As Double = 0
        Dim maxY As Double = TrialsCount

        Dim interarrival = 0

        Dim interarrivalDistribution As New Dictionary(Of Integer, Integer)

        Me.b3 = New Bitmap(Me.PictureBox3.Width, Me.PictureBox3.Height)
        Me.g3 = Graphics.FromImage(b3)
        Me.g3.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g3.Clear(Color.White)


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
                If Uniform <SuccessProbability Then
                    Y = Y + 1
                    If interarrival <> 0 Then
                        If Not interarrivalDistribution.ContainsKey(interarrival) Then
                            interarrivalDistribution.Add(interarrival, 1)
                        Else
                            interarrivalDistribution.Item(interarrival) = interarrivalDistribution.Item(interarrival) + 1
                        End If
                        interarrival = 0
                    End If
                Else
                    interarrival = interarrival + 1
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

        drawVerticalChart(b3, g3, PictureBox3, interarrivalDistribution, TrialsCount)
        PictureBox3.Image = b3

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
        Dim SuccessProbability As Double = TrackBar3.Value / TrialsCount

        Dim minX As Double = 0
        Dim maxX As Double = TrialsCount
        Dim minY As Double = 0
        Dim maxY As Double = TrialsCount

        Dim interarrival = 0

        Dim interarrivalDistribution As New Dictionary(Of Integer, Integer)

        Me.b3 = New Bitmap(Me.PictureBox3.Width, Me.PictureBox3.Height)
        Me.g3 = Graphics.FromImage(b3)
        Me.g3.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g3.Clear(Color.White)

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
                    If interarrival <> 0 Then
                        If Not interarrivalDistribution.ContainsKey(interarrival) Then
                            interarrivalDistribution.Add(interarrival, 1)
                        Else
                            interarrivalDistribution.Item(interarrival) = interarrivalDistribution.Item(interarrival) + 1
                        End If
                        interarrival = 0
                    End If
                Else
                    interarrival = interarrival + 1
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

        drawVerticalChart(b3, g3, PictureBox3, interarrivalDistribution, TrialsCount)
        PictureBox3.Image = b3

    End Sub

End Class