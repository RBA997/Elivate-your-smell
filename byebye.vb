Public Class byebye


    Private Sub byebye_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual

        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2


        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent

    End Sub
End Class