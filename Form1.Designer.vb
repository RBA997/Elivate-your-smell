<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Timer1 = New Timer(components)
        label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        p1 = New Panel()
        lblGoToSignup = New LinkLabel()
        Label7 = New Label()
        txtLoginPass = New TextBox()
        txtLoginUser = New TextBox()
        pic1 = New PictureBox()
        btnLogin = New Button()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        l8 = New Label()
        p2 = New Panel()
        LinkLabel3 = New LinkLabel()
        ch1 = New CheckBox()
        l13 = New Label()
        rbNonBinary = New RadioButton()
        rbMale = New RadioButton()
        rbFemale = New RadioButton()
        cmbYear = New ComboBox()
        cmbDay = New ComboBox()
        cmbMonth = New ComboBox()
        l12 = New Label()
        Label11 = New Label()
        b2 = New Button()
        link2 = New LinkLabel()
        Label10 = New Label()
        txtSignupUser = New TextBox()
        txtSignupPass = New TextBox()
        Label9 = New Label()
        Label8 = New Label()
        PictureBox1 = New PictureBox()
        p3 = New Panel()
        Button2 = New Button()
        Label13 = New Label()
        Label12 = New Label()
        p1.SuspendLayout()
        CType(pic1, ComponentModel.ISupportInitialize).BeginInit()
        p2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        p3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Timer1
        ' 
        ' 
        ' label1
        ' 
        label1.Anchor = AnchorStyles.None
        label1.AutoSize = True
        label1.Font = New Font("Times New Roman", 25.8000011F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        label1.ForeColor = SystemColors.InactiveCaption
        label1.Location = New Point(306, 299)
        label1.Name = "label1"
        label1.Size = New Size(533, 51)
        label1.TabIndex = 0
        label1.Text = "Tired of not breathing in 4D"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Times New Roman", 18F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.InactiveCaption
        Label2.Location = New Point(340, 350)
        Label2.Name = "Label2"
        Label2.Size = New Size(477, 34)
        Label2.TabIndex = 1
        Label2.Text = "don't worry our solution is right here"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Times New Roman", 22.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.InactiveCaption
        Label3.Location = New Point(252, 285)
        Label3.Name = "Label3"
        Label3.Size = New Size(709, 172)
        Label3.TabIndex = 2
        Label3.Text = "                         Introducing!! " & vbCrLf & "our one and only product in the whole world " & vbCrLf & "                 where scented and flavors " & vbCrLf & "                    are combined together "
        ' 
        ' p1
        ' 
        p1.Anchor = AnchorStyles.None
        p1.Controls.Add(lblGoToSignup)
        p1.Controls.Add(Label7)
        p1.Controls.Add(txtLoginPass)
        p1.Controls.Add(txtLoginUser)
        p1.Controls.Add(pic1)
        p1.Controls.Add(btnLogin)
        p1.Controls.Add(Label6)
        p1.Controls.Add(Label5)
        p1.Controls.Add(Label4)
        p1.Location = New Point(393, 58)
        p1.Name = "p1"
        p1.Size = New Size(469, 472)
        p1.TabIndex = 3
        ' 
        ' lblGoToSignup
        ' 
        lblGoToSignup.AutoSize = True
        lblGoToSignup.BackColor = Color.Transparent
        lblGoToSignup.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblGoToSignup.ForeColor = SystemColors.InactiveCaption
        lblGoToSignup.LinkColor = SystemColors.InactiveCaption
        lblGoToSignup.Location = New Point(263, 398)
        lblGoToSignup.Name = "lblGoToSignup"
        lblGoToSignup.Size = New Size(74, 23)
        lblGoToSignup.TabIndex = 12
        lblGoToSignup.TabStop = True
        lblGoToSignup.Text = "Sign up "
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = SystemColors.InactiveCaption
        Label7.Location = New Point(68, 398)
        Label7.Name = "Label7"
        Label7.Size = New Size(198, 23)
        Label7.TabIndex = 11
        Label7.Text = "Dont have an account ? "
        ' 
        ' txtLoginPass
        ' 
        txtLoginPass.BackColor = SystemColors.InactiveBorder
        txtLoginPass.BorderStyle = BorderStyle.FixedSingle
        txtLoginPass.Location = New Point(54, 292)
        txtLoginPass.Name = "txtLoginPass"
        txtLoginPass.PasswordChar = "*"c
        txtLoginPass.Size = New Size(365, 27)
        txtLoginPass.TabIndex = 10
        ' 
        ' txtLoginUser
        ' 
        txtLoginUser.BackColor = SystemColors.InactiveBorder
        txtLoginUser.BorderStyle = BorderStyle.FixedSingle
        txtLoginUser.Location = New Point(54, 211)
        txtLoginUser.Name = "txtLoginUser"
        txtLoginUser.Size = New Size(365, 27)
        txtLoginUser.TabIndex = 9
        ' 
        ' pic1
        ' 
        pic1.BackColor = Color.Transparent
        pic1.Image = CType(resources.GetObject("pic1.Image"), Image)
        pic1.Location = New Point(169, 3)
        pic1.Name = "pic1"
        pic1.Size = New Size(103, 102)
        pic1.TabIndex = 8
        pic1.TabStop = False
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.Transparent
        btnLogin.Font = New Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = SystemColors.InactiveCaption
        btnLogin.Location = New Point(157, 343)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(140, 42)
        btnLogin.TabIndex = 7
        btnLogin.Text = "login "
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.InactiveCaption
        Label6.Location = New Point(9, 260)
        Label6.Name = "Label6"
        Label6.Size = New Size(102, 29)
        Label6.TabIndex = 3
        Label6.Text = "Password"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.InactiveCaption
        Label5.Location = New Point(9, 179)
        Label5.Name = "Label5"
        Label5.Size = New Size(107, 29)
        Label5.TabIndex = 2
        Label5.Text = "Username"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.InactiveCaption
        Label4.Location = New Point(132, 108)
        Label4.Name = "Label4"
        Label4.Size = New Size(175, 41)
        Label4.TabIndex = 1
        Label4.Text = "Login Here"
        ' 
        ' l8
        ' 
        l8.Anchor = AnchorStyles.None
        l8.AutoSize = True
        l8.Font = New Font("Times New Roman", 22.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        l8.ForeColor = SystemColors.InactiveCaption
        l8.Location = New Point(306, 325)
        l8.Name = "l8"
        l8.Size = New Size(587, 86)
        l8.TabIndex = 4
        l8.Text = "                   Welcome to " & vbCrLf & """why does it taste soo good?"" Tissue "
        ' 
        ' p2
        ' 
        p2.Anchor = AnchorStyles.None
        p2.Controls.Add(LinkLabel3)
        p2.Controls.Add(ch1)
        p2.Controls.Add(l13)
        p2.Controls.Add(rbNonBinary)
        p2.Controls.Add(rbMale)
        p2.Controls.Add(rbFemale)
        p2.Controls.Add(cmbYear)
        p2.Controls.Add(cmbDay)
        p2.Controls.Add(cmbMonth)
        p2.Controls.Add(l12)
        p2.Controls.Add(Label11)
        p2.Controls.Add(b2)
        p2.Controls.Add(link2)
        p2.Controls.Add(Label10)
        p2.Controls.Add(txtSignupUser)
        p2.Controls.Add(txtSignupPass)
        p2.Controls.Add(Label9)
        p2.Controls.Add(Label8)
        p2.Controls.Add(PictureBox1)
        p2.Location = New Point(393, 55)
        p2.Name = "p2"
        p2.Size = New Size(466, 565)
        p2.TabIndex = 13
        ' 
        ' LinkLabel3
        ' 
        LinkLabel3.AutoSize = True
        LinkLabel3.BackColor = Color.Transparent
        LinkLabel3.LinkColor = SystemColors.InactiveCaption
        LinkLabel3.Location = New Point(68, 444)
        LinkLabel3.Name = "LinkLabel3"
        LinkLabel3.Size = New Size(302, 20)
        LinkLabel3.TabIndex = 26
        LinkLabel3.TabStop = True
        LinkLabel3.Text = "click here to see the full terms and condition"
        ' 
        ' ch1
        ' 
        ch1.AutoSize = True
        ch1.BackColor = Color.Transparent
        ch1.Location = New Point(11, 417)
        ch1.Name = "ch1"
        ch1.Size = New Size(261, 24)
        ch1.TabIndex = 25
        ch1.Text = "I agree to the term and conditions "
        ch1.UseVisualStyleBackColor = False
        ' 
        ' l13
        ' 
        l13.AutoSize = True
        l13.BackColor = Color.Transparent
        l13.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        l13.ForeColor = SystemColors.InactiveCaption
        l13.Location = New Point(9, 340)
        l13.Name = "l13"
        l13.Size = New Size(81, 29)
        l13.TabIndex = 24
        l13.Text = "Gender"
        ' 
        ' rbNonBinary
        ' 
        rbNonBinary.AutoSize = True
        rbNonBinary.BackColor = Color.Transparent
        rbNonBinary.Location = New Point(303, 370)
        rbNonBinary.Name = "rbNonBinary"
        rbNonBinary.Size = New Size(104, 24)
        rbNonBinary.TabIndex = 23
        rbNonBinary.TabStop = True
        rbNonBinary.Text = "non binary "
        rbNonBinary.UseVisualStyleBackColor = False
        ' 
        ' rbMale
        ' 
        rbMale.AutoSize = True
        rbMale.BackColor = Color.Transparent
        rbMale.Location = New Point(195, 370)
        rbMale.Name = "rbMale"
        rbMale.Size = New Size(63, 24)
        rbMale.TabIndex = 22
        rbMale.TabStop = True
        rbMale.Text = "Male"
        rbMale.UseVisualStyleBackColor = False
        ' 
        ' rbFemale
        ' 
        rbFemale.AutoSize = True
        rbFemale.BackColor = Color.Transparent
        rbFemale.Location = New Point(68, 372)
        rbFemale.Name = "rbFemale"
        rbFemale.Size = New Size(78, 24)
        rbFemale.TabIndex = 21
        rbFemale.TabStop = True
        rbFemale.Text = "Female"
        rbFemale.UseVisualStyleBackColor = False
        ' 
        ' cmbYear
        ' 
        cmbYear.BackColor = SystemColors.InactiveCaption
        cmbYear.FlatStyle = FlatStyle.Flat
        cmbYear.FormattingEnabled = True
        cmbYear.Location = New Point(295, 306)
        cmbYear.Name = "cmbYear"
        cmbYear.Size = New Size(115, 28)
        cmbYear.TabIndex = 20
        ' 
        ' cmbDay
        ' 
        cmbDay.BackColor = SystemColors.InactiveCaption
        cmbDay.FlatStyle = FlatStyle.Flat
        cmbDay.FormattingEnabled = True
        cmbDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        cmbDay.Location = New Point(173, 306)
        cmbDay.Name = "cmbDay"
        cmbDay.Size = New Size(99, 28)
        cmbDay.TabIndex = 19
        ' 
        ' cmbMonth
        ' 
        cmbMonth.BackColor = SystemColors.InactiveCaption
        cmbMonth.FlatStyle = FlatStyle.Popup
        cmbMonth.FormattingEnabled = True
        cmbMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        cmbMonth.Location = New Point(47, 306)
        cmbMonth.Name = "cmbMonth"
        cmbMonth.Size = New Size(99, 28)
        cmbMonth.TabIndex = 18
        ' 
        ' l12
        ' 
        l12.AutoSize = True
        l12.BackColor = Color.Transparent
        l12.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        l12.ForeColor = SystemColors.InactiveCaption
        l12.Location = New Point(9, 272)
        l12.Name = "l12"
        l12.Size = New Size(155, 29)
        l12.TabIndex = 15
        l12.Text = "Date of birth "
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = SystemColors.InactiveCaption
        Label11.Location = New Point(60, 512)
        Label11.Name = "Label11"
        Label11.Size = New Size(221, 23)
        Label11.TabIndex = 14
        Label11.Text = "Already have an account ? "
        ' 
        ' b2
        ' 
        b2.BackColor = Color.Transparent
        b2.Font = New Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        b2.ForeColor = SystemColors.InactiveCaption
        b2.Location = New Point(157, 467)
        b2.Name = "b2"
        b2.Size = New Size(140, 42)
        b2.TabIndex = 14
        b2.Text = "sign up"
        b2.UseVisualStyleBackColor = False
        ' 
        ' link2
        ' 
        link2.AutoSize = True
        link2.BackColor = Color.Transparent
        link2.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        link2.ForeColor = SystemColors.InactiveCaption
        link2.LinkColor = SystemColors.InactiveCaption
        link2.Location = New Point(280, 512)
        link2.Name = "link2"
        link2.Size = New Size(57, 23)
        link2.TabIndex = 14
        link2.TabStop = True
        link2.Text = "Log in"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = SystemColors.InactiveCaption
        Label10.Location = New Point(9, 209)
        Label10.Name = "Label10"
        Label10.Size = New Size(102, 29)
        Label10.TabIndex = 14
        Label10.Text = "Password"
        ' 
        ' txtSignupUser
        ' 
        txtSignupUser.BackColor = SystemColors.InactiveBorder
        txtSignupUser.BorderStyle = BorderStyle.FixedSingle
        txtSignupUser.Location = New Point(45, 171)
        txtSignupUser.Name = "txtSignupUser"
        txtSignupUser.Size = New Size(365, 27)
        txtSignupUser.TabIndex = 14
        ' 
        ' txtSignupPass
        ' 
        txtSignupPass.BackColor = SystemColors.InactiveBorder
        txtSignupPass.BorderStyle = BorderStyle.FixedSingle
        txtSignupPass.Location = New Point(45, 241)
        txtSignupPass.Name = "txtSignupPass"
        txtSignupPass.PasswordChar = "*"c
        txtSignupPass.Size = New Size(365, 27)
        txtSignupPass.TabIndex = 14
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = SystemColors.InactiveCaption
        Label9.Location = New Point(9, 139)
        Label9.Name = "Label9"
        Label9.Size = New Size(107, 29)
        Label9.TabIndex = 14
        Label9.Text = "Username"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = SystemColors.InactiveCaption
        Label8.Location = New Point(132, 108)
        Label8.Name = "Label8"
        Label8.Size = New Size(215, 41)
        Label8.TabIndex = 14
        Label8.Text = "Sign up here "
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(169, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(103, 102)
        PictureBox1.TabIndex = 14
        PictureBox1.TabStop = False
        ' 
        ' p3
        ' 
        p3.Anchor = AnchorStyles.None
        p3.AutoScroll = True
        p3.Controls.Add(Button2)
        p3.Controls.Add(Label13)
        p3.Controls.Add(Label12)
        p3.Location = New Point(390, 61)
        p3.Name = "p3"
        p3.Size = New Size(466, 562)
        p3.TabIndex = 27
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(343, 9855)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 4
        Button2.Text = "exit "
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label13
        ' 
        Label13.Anchor = AnchorStyles.None
        Label13.AutoSize = True
        Label13.Location = New Point(-205, -269)
        Label13.Name = "Label13"
        Label13.Size = New Size(0, 20)
        Label13.TabIndex = 3
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(3, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(2328, 9900)
        Label12.TabIndex = 5
        Label12.Text = resources.GetString("Label12.Text")
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1221, 701)
        Controls.Add(p3)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(label1)
        Controls.Add(l8)
        Controls.Add(p1)
        Controls.Add(p2)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Elivate your smell"
        p1.ResumeLayout(False)
        p1.PerformLayout()
        CType(pic1, ComponentModel.ISupportInitialize).EndInit()
        p2.ResumeLayout(False)
        p2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        p3.ResumeLayout(False)
        p3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents p1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label

    Friend WithEvents btnLogin As Button

    Friend WithEvents pic1 As PictureBox
    Friend WithEvents txtLoginPass As TextBox
    Friend WithEvents txtLoginUser As TextBox
    Friend WithEvents lblGoToSignup As LinkLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents l8 As Label
    Friend WithEvents p2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSignupUser As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSignupPass As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents b2 As Button
    Friend WithEvents link2 As LinkLabel
    Friend WithEvents rbNonBinary As RadioButton
    Friend WithEvents rbMale As RadioButton
    Friend WithEvents rbFemale As RadioButton
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents cmbDay As ComboBox
    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents l12 As Label
    Friend WithEvents ch1 As CheckBox
    Friend WithEvents l13 As Label
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents p3 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label

End Class
