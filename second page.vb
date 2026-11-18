'Imports System.Data
Imports System.Data.OleDb
Imports Windows.Win32.System
Public Class second_page
    Private Sub scentedtissueblue_Click(sender As Object, e As EventArgs)
        ShowPanel(scentedpanel)
        Panel1.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False





    End Sub

    Private Sub second_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.StartPosition = FormStartPosition.Manual

        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2



        Me.Controls.Add(MyCartpanel)
        MyCartpanel.Location = New Point(205, 50)


        Me.Controls.Add(signoutpanel)
        signoutpanel.Location = New Point(205, 100)

        Me.Controls.Add(flavoredpanel)
        flavoredpanel.Location = New Point(205, 50)

        Me.Controls.Add(updatepasswordpanel)
        updatepasswordpanel.Location = New Point(205, 50)

        Me.Controls.Add(scentedpanel)
        scentedpanel.Location = New Point(205, 50)


        scentedpanel.Visible = False
        flavoredpanel.Visible = False
        MyCartpanel.Visible = False
        signoutpanel.Visible = False
        updatepasswordpanel.Visible = False


        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False










    End Sub


    Private Sub ShowPanel(p As Panel)

        scentedpanel.Visible = False
        flavoredpanel.Visible = False
        MyCartpanel.Visible = False
        signoutpanel.Visible = False
        updatepasswordpanel.Visible = False


        p.Visible = True
        p.BringToFront()

    End Sub





    Private Sub scentedtissueblue_Click_1(sender As Object, e As EventArgs) Handles scentedtissueblue.Click
        ShowPanel(scentedpanel)
        Panel1.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        ShowPanel(flavoredpanel)
        Panel1.Visible = False
        Panel2.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        ShowPanel(MyCartpanel)
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False




        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            conn.Open()


            Dim sql As String = "SELECT P.ProductName, O.QuantityOrder, P.Price, O.OrderId " &
                                "FROM Orders O, Products P " &
                                "WHERE O.ProductId = P.ProductId AND O.UserID = ?"

            Dim cmd As New OleDbCommand(sql, conn)
            cmd.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID

            Dim reader As OleDbDataReader = cmd.ExecuteReader()


            ListView1.Items.Clear()


            While reader.Read()
                Dim productName As String = reader("ProductName").ToString()
                Dim quantity As Integer = CInt(reader("QuantityOrder"))
                Dim price As Decimal = CDec(reader("Price"))
                Dim total As Decimal = price * quantity

                Dim item As New ListViewItem(productName)
                item.SubItems.Add(quantity.ToString())
                item.SubItems.Add("JD " & total.ToString("F2"))
                item.SubItems.Add(reader("OrderId").ToString())

                ListView1.Items.Add(item)
            End While

            reader.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        ShowPanel(signoutpanel)
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = True
        Panel5.Visible = False
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        ShowPanel(updatepasswordpanel)
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = True

    End Sub

    Private Sub gobackbutton_Click_1(sender As Object, e As EventArgs) Handles gobackbutton.Click
        Form1.Show()
        Hide()
    End Sub

    Private Sub maximize_Click_1(sender As Object, e As EventArgs) Handles maximize.Click
        If WindowState = WindowState.Normal Then
            WindowState = WindowState.Maximized
            beigepanel.Location = New Point(0, 0)








        ElseIf WindowState = WindowState.Maximized Then
            WindowState = WindowState.Normal

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtUpdateUser.Text = "" Or txtOldPass.Text = "" Or txtNewPass.Text = "" Then
            MsgBox("Please fill in all fields", MsgBoxStyle.Critical)
            Exit Sub
        End If


        Dim hasletter = False
        Dim hasdigit = False
        Dim hasspecial = False


        If txtNewPass.Text.Length < 8 Then
            MsgBox("The length of the password must be greater than 8 characters", MsgBoxStyle.Exclamation)
            txtNewPass.Focus()
            Exit Sub
        Else

            For Each ch In txtNewPass.Text
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
            MsgBox("The password must contain at least an alphabetical letter, a numeric number, and a special character", MsgBoxStyle.Exclamation)
            txtNewPass.Focus()
            Exit Sub
        End If


        Dim connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            conn.Open()

            Dim checkSql = "SELECT COUNT(*) FROM Users WHERE Username = @u AND [Password] = @old"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.AddWithValue("@u", txtUpdateUser.Text)
            cmdCheck.Parameters.AddWithValue("@old", txtOldPass.Text)

            If CInt(cmdCheck.ExecuteScalar) > 0 Then

                Dim updateSql = "UPDATE Users SET [Password] = @new WHERE Username = @u"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.AddWithValue("@new", txtNewPass.Text)
                cmdUpdate.Parameters.AddWithValue("@u", txtUpdateUser.Text)

                cmdUpdate.ExecuteNonQuery()
                MsgBox("Password updated successfully!", MsgBoxStyle.Information)

                txtOldPass.Clear()
                txtNewPass.Clear()
            Else

                MsgBox("Invalid Username or Old Password. Please try again.", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox("Database Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub flowerb_Click(sender As Object, e As EventArgs) Handles flowerb.Click

        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If floralnumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 1

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(floralnumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 1
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 1
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(floralnumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try


    End Sub

    Private Sub candyb_Click(sender As Object, e As EventArgs) Handles candyb.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)
        Try
            If candynumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 2

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(candynumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 2
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 2
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(candynumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub rainyb_Click(sender As Object, e As EventArgs) Handles rainyb.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If rainynumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 9

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(rainynumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 9
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 9
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(rainynumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub lemonb_Click(sender As Object, e As EventArgs) Handles lemonb.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If lemonnumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 3

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(lemonnumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 3
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 3
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(lemonnumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub bananab_Click(sender As Object, e As EventArgs) Handles bananab.Click

        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If banananumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 7

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(banananumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 7
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 7
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(banananumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub gasb_Click(sender As Object, e As EventArgs) Handles gasb.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If gasnumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 8

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(gasnumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 8
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 8
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(gasnumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try


    End Sub

    Private Sub Breadbutton_Click(sender As Object, e As EventArgs) Handles Breadbutton.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If Breadnumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 11

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(Breadnumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 11
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 11
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(Breadnumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub Smoresbutton_Click(sender As Object, e As EventArgs) Handles Smoresbutton.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If Smoresnumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 12

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(Smoresnumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 12
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 12
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(Smoresnumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Oreobutton_Click(sender As Object, e As EventArgs) Handles Oreobutton.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If oreonumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 10

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(oreonumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 10
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 10
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(oreonumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Cheesebutton_Click(sender As Object, e As EventArgs) Handles Cheesebutton.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If cheesenumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 5

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(cheesenumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 5
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 5
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(cheesenumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Burgerbutton_Click(sender As Object, e As EventArgs) Handles Burgerbutton.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If burgernumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 4

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(burgernumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 4
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 4
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(burgernumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub Cornbutton_Click(sender As Object, e As EventArgs) Handles Cornbutton.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If cornnumeric.Value <= 0 Then
                MsgBox("Please select a quantity!")
                Return
            End If

            conn.Open()


            Dim checkSql As String = "SELECT COUNT(*) FROM Orders WHERE UserID = ? AND ProductId = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
            cmdCheck.Parameters.Add("@pid", OleDbType.Integer).Value = 6

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim updateSql As String = "UPDATE Orders SET QuantityOrder = ? WHERE UserID = ? AND ProductId = ?"
                Dim cmdUpdate As New OleDbCommand(updateSql, conn)
                cmdUpdate.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(cornnumeric.Value)
                cmdUpdate.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUpdate.Parameters.Add("@pid", OleDbType.Integer).Value = 6
                cmdUpdate.ExecuteNonQuery()
                MsgBox("Cart updated successfully!")

            Else

                Dim insertSql As String = "INSERT INTO Orders (UserID, ProductId, QuantityOrder, OrderDate) VALUES (?, ?, ?, ?)"
                Dim cmdInsert As New OleDbCommand(insertSql, conn)
                cmdInsert.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdInsert.Parameters.Add("@pid", OleDbType.Integer).Value = 6
                cmdInsert.Parameters.Add("@qty", OleDbType.Integer).Value = CInt(cornnumeric.Value)
                cmdInsert.Parameters.Add("@dt", OleDbType.Date).Value = DateTime.Now
                cmdInsert.ExecuteNonQuery()
                MsgBox("Added to your cart successfully!")

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Signoutbutton_Click(sender As Object, e As EventArgs) Handles Signoutbutton.Click
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
        Dim conn As New OleDbConnection(connString)

        Try
            If usernamet.Text = "" Or passwordt.Text = "" Then
                MsgBox("Please enter your username and password!")
                Return
            End If

            conn.Open()

            Dim checkSql As String = "SELECT COUNT(*) FROM Users WHERE Username = ? AND Password = ? And userID = ?"
            Dim cmdCheck As New OleDbCommand(checkSql, conn)
            cmdCheck.Parameters.Add("@user", OleDbType.VarChar).Value = usernamet.Text
            'cmdCheck.Parameters.Add("@pass", OleDbType.VarChar).Value = passwordt.Text
            cmdCheck.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID

            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

            If exists > 0 Then

                Dim deleteOrders As String = "DELETE FROM Orders WHERE UserID = ?"
                Dim cmdOrders As New OleDbCommand(deleteOrders, conn)
                cmdOrders.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdOrders.ExecuteNonQuery()


                Dim deleteUser As String = "DELETE FROM Users WHERE UserID = ?"
                Dim cmdUser As New OleDbCommand(deleteUser, conn)
                cmdUser.Parameters.Add("@uid", OleDbType.Integer).Value = Form1.CurrentUserID
                cmdUser.ExecuteNonQuery()

                MsgBox("Your account has been deleted successfully!")


                Form1.Show()
                Me.Close()

            Else
                MsgBox("Incorrect username or password!")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rbaze\OneDrive\Desktop\kledatabase.accdb"
            Dim conn As New OleDbConnection(connString)
            conn.Open()
            For Each i In ListView1.SelectedItems
                Dim id As Integer = CInt(i.SubItems(3).Text)

                Dim cmd As New OleDbCommand(
                "DELETE FROM Orders WHERE OrderID = ?", conn)

                cmd.Parameters.AddWithValue("@p1", id)

                cmd.ExecuteNonQuery()

                ListView1.Items.Remove(i)
            Next
            conn.Close()

        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        byebye.Show()

    End Sub

    Private Sub signoutpanel_Paint(sender As Object, e As PaintEventArgs) Handles signoutpanel.Paint

    End Sub
End Class