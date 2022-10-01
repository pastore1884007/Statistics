Public Class Form1
    Private Sub BtnGetItem_Click(sender As Object, e As EventArgs) Handles BtnGetItem.Click
        ListBox1.Items.Clear()
        For Each s As String In CheckedListBox1.CheckedItems
            ListBox1.Items.Add(s)
        Next
    End Sub

    Private Sub BtnGetIndex_Click(sender As Object, e As EventArgs) Handles BtnGetIndex.Click
        ListBox2.Items.Clear()
        For i As Integer = 0 To CheckedListBox1.CheckedIndices.Count - 1
            ListBox2.Items.Add(CheckedListBox1.CheckedIndices(i))
        Next
    End Sub

    Private Sub BtnGetItem_MouseEnter(sender As Object, e As EventArgs) Handles BtnGetItem.MouseEnter
        BtnGetItem.BackColor = Color.Green
    End Sub

    Private Sub BtnGetIndex_MouseEnter(sender As Object, e As EventArgs) Handles BtnGetIndex.MouseEnter
        BtnGetIndex.BackColor = Color.Green
    End Sub

    Private Sub BtnGetItem_MouseLeave(sender As Object, e As EventArgs) Handles BtnGetItem.MouseLeave
        BtnGetItem.BackColor = Color.Yellow
    End Sub

    Private Sub BtnGetIndex_MouseLeave(sender As Object, e As EventArgs) Handles BtnGetIndex.MouseLeave
        BtnGetIndex.BackColor = Color.Yellow
    End Sub

End Class
