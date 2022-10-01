<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.BtnGetItem = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.BtnGetIndex = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Programming Languages"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Java", "C", "C++", "C#", "Objective-C", "PHP", "Python", "Ruby", "Javascript", "SQL"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(12, 27)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(237, 202)
        Me.CheckedListBox1.TabIndex = 1
        '
        'BtnGetItem
        '
        Me.BtnGetItem.Location = New System.Drawing.Point(12, 237)
        Me.BtnGetItem.Name = "BtnGetItem"
        Me.BtnGetItem.Size = New System.Drawing.Size(80, 27)
        Me.BtnGetItem.TabIndex = 2
        Me.BtnGetItem.Text = "Get item"
        Me.BtnGetItem.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(12, 270)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 139)
        Me.ListBox1.TabIndex = 3
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 15
        Me.ListBox2.Location = New System.Drawing.Point(169, 270)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(120, 139)
        Me.ListBox2.TabIndex = 5
        '
        'BtnGetIndex
        '
        Me.BtnGetIndex.Location = New System.Drawing.Point(169, 237)
        Me.BtnGetIndex.Name = "BtnGetIndex"
        Me.BtnGetIndex.Size = New System.Drawing.Size(80, 27)
        Me.BtnGetIndex.TabIndex = 4
        Me.BtnGetIndex.Text = "Get index"
        Me.BtnGetIndex.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.BtnGetIndex)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.BtnGetItem)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents BtnGetItem As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents BtnGetIndex As Button
End Class
