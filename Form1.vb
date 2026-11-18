Imports System.Data.OleDb
Imports System.Reflection.Emit

Public Class Form1
    Dim Errors As ErrorProvider
    Dim opacityy As Integer = 255
    Dim stepFade As Integer = 15

    Public Shared CurrentUserID As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        Errors = New ErrorProvider()


        label1.BackColor = Color.FromArgb(70, 0, 0, 0)
        Label2.BackColor = Color.FromArgb(70, 0, 0, 0)
        Label3.BackColor = Color.FromArgb(70, 0, 0, 0)
        l8.BackColor = Color.FromArgb(70, 0, 0, 0)
        p1.BackColor = Color.FromArgb(60, 0, 0, 0)
        p2.BackColor = Color.FromArgb(60, 0, 0, 0)
        p1.Visible = False
        p2.Visible = False
        p3.Visible = False
        Label3.Visible = False
        l8.Visible = False
        Timer1.Interval = 370
        Timer1.Start()

        Dim i As Integer = 1900
        While i <> 2081
            cmbYear.Items.Add(i)
            i += 1
        End While

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If label1.Visible = True Then
            opacityy -= stepFade
            If opacityy <= 0 Then
                label1.Visible = False
                Label2.Visible = False
                Label3.Visible = True
                opacityy = 255

            End If
        ElseIf Label3.Visible Then
            opacityy -= stepFade
            If opacityy <= 0 Then
                Label3.Visible = False
                l8.Visible = True
                opacityy = 255
            End If
        Else
            opacityy -= stepFade
            If opacityy <= 0 Then
                l8.Visible = False
                p1.Visible = True
                Timer1.Stop()
                opacityy = 255
            End If



        End If
    End Sub

    Private Sub b1_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtLoginUser.Text = "" Or txtLoginPass.Text = "" Then
            MsgBox("Please enter your username and password", MsgBoxStyle.Critical, "Login Error")
            txtLoginUser.Focus()
            Exit Sub
        End If


        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            conn.Open()

            Dim loginSql As String = "SELECT UserID FROM Users WHERE Username = @u AND [Password] = @p"
            Dim cmd As New OleDbCommand(loginSql, conn)


            cmd.Parameters.AddWithValue("@u", txtLoginUser.Text)
            cmd.Parameters.AddWithValue("@p", txtLoginPass.Text)


            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            If reader.Read() Then

                CurrentUserID = CInt(reader("UserID"))

                MessageBox.Show("Login Successful! Welcome back." & vbCrLf & "Your Session ID: " & CurrentUserID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


                second_page.Show()
                Me.Hide()
            Else

                MessageBox.Show("Invalid username or password. If you don't have an account, please Sign Up.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLoginUser.Focus()
            End If

            reader.Close()

        Catch ex As Exception

            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            conn.Close()
        End Try
    End Sub


    Private Sub t1_TextChanged(sender As Object, e As EventArgs) Handles txtLoginUser.TextChanged
        Errors.Clear()
    End Sub

    Private Sub t2_TextChanged(sender As Object, e As EventArgs) Handles txtLoginPass.TextChanged
        Errors.Clear()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGoToSignup.LinkClicked
        p1.Visible = False
        p2.Visible = True


    End Sub

    Private Sub b2_Click(sender As Object, e As EventArgs) Handles b2.Click

        If txtSignupUser.Text = "" Or txtSignupPass.Text = "" Then
            MsgBox("Enter your username and password", MsgBoxStyle.Critical, "Blank!!")
            Exit Sub
        End If
        'Check the password strength'
        Dim hasletter As Boolean = False
        Dim hasdigit As Boolean = False
        Dim hasspecial As Boolean = False

        If txtSignupPass.Text.Length < 8 Then
            MsgBox("the length of the password must be greater than or equal to 8 characters")
            Exit Sub
        Else
            For Each ch In txtSignupPass.Text
                If Char.IsLetter(ch) Then
                    hasletter = True
                ElseIf Char.IsDigit(ch) Then
                    hasdigit = True
                Else
                    hasspecial = True
                End If
            Next
        End If

        If Not (hasspecial And hasletter And hasdigit) Then
            MsgBox("the password must contain at least an alphabetical letter, a numeric number, and a special character")
            Exit Sub
        End If

        If cmbMonth.SelectedIndex = -1 Or cmbDay.SelectedIndex = -1 Or cmbYear.SelectedIndex = -1 Then
            Errors.SetError(l12, "you must pick the whole date of birth")
            Exit Sub
        End If

        If rbFemale.Checked = False And rbMale.Checked = False And rbNonBinary.Checked = False Then
            Errors.SetError(l13, "you must pick a gender")
            Exit Sub
        End If

        If ch1.Checked = False Then
            Errors.SetError(ch1, "you can't sign up without agreeing to the terms and conditions")
            Exit Sub
        End If


        Dim birthDate As String = cmbDay.Text & "/" & cmbMonth.Text & "/" & cmbYear.Text
        Dim gender As String = If(rbFemale.Checked, "Female", If(rbMale.Checked, "Male", "Non-binary"))

        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            conn.Open()

            Dim checkSql As String = "SELECT COUNT(*) FROM Users WHERE Username = @u"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.AddWithValue("@u", txtSignupUser.Text)

            If CInt(cmdCheck.ExecuteScalar()) > 0 Then
                MessageBox.Show("This username is already taken!", "Account Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                Dim insertSql As String = "INSERT INTO Users (Username, [Password], BirthDate, Gender) VALUES (@u, @p, @b, @g)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.AddWithValue("@u", txtSignupUser.Text)
                cmdInsert.Parameters.AddWithValue("@p", txtSignupPass.Text)
                cmdInsert.Parameters.AddWithValue("@b", birthDate)
                cmdInsert.Parameters.AddWithValue("@g", gender)
                cmdInsert.ExecuteNonQuery()


                Dim getIDSql As String = "SELECT @@IDENTITY"
                Dim cmdGetID As New OleDbCommand(getIDSql, conn)
                Dim newUserID As Integer = CInt(cmdGetID.ExecuteScalar())


                CurrentUserID = newUserID

                MessageBox.Show("Registration Successful!" & vbCrLf & "Your unique User ID is: " & CurrentUserID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


                second_page.Show()
                Me.Hide()
            End If

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub link2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link2.LinkClicked
        p1.Visible = True
        p2.Visible = False

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        p3.Visible = True
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        p3.Visible = False

    End Sub

    Private Sub t3_TextChanged(sender As Object, e As EventArgs) Handles txtSignupUser.TextChanged
        Errors.Clear()
    End Sub

    Private Sub t4_TextChanged(sender As Object, e As EventArgs) Handles txtSignupPass.TextChanged
        Errors.Clear()
    End Sub

    Private Sub ch1_CheckedChanged(sender As Object, e As EventArgs) Handles ch1.CheckedChanged
        Errors.Clear()
    End Sub

    Private Sub r1_CheckedChanged(sender As Object, e As EventArgs) Handles rbFemale.CheckedChanged
        Errors.SetError(l13, "")
    End Sub

    Private Sub r2_CheckedChanged(sender As Object, e As EventArgs) Handles rbMale.CheckedChanged
        Errors.SetError(l13, "")
    End Sub

    Private Sub r3_CheckedChanged(sender As Object, e As EventArgs) Handles rbNonBinary.CheckedChanged
        Errors.SetError(l13, "")
    End Sub

    Private Sub c1_MouseClick(sender As Object, e As MouseEventArgs) Handles cmbMonth.MouseClick
        Errors.SetError(l12, "")
    End Sub

    Private Sub c2_MouseClick(sender As Object, e As MouseEventArgs) Handles cmbDay.MouseClick
        Errors.SetError(l12, "")
    End Sub

    Private Sub c3_MouseClick(sender As Object, e As MouseEventArgs) Handles cmbYear.MouseClick
        Errors.SetError(l12, "")
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click_1(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub p3_Paint(sender As Object, e As PaintEventArgs) Handles p3.Paint

    End Sub
End Class




