<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddNewBilling
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addNewBilling))
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroTextBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel3 = New MetroFramework.Controls.MetroPanel()
        Me.MetroTextBox4 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTextBox3 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroDateTime3 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroDateTime2 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroLabel12 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel11 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel10 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel9 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel4 = New MetroFramework.Controls.MetroPanel()
        Me.MetroTextBox5 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTextBox6 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroDateTime4 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroDateTime5 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroLabel13 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel14 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel15 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel16 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel6 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton3 = New MetroFramework.Controls.MetroButton()
        Me.MetroPanel2 = New MetroFramework.Controls.MetroPanel()
        Me.MetroLabel8 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox2 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroDateTime1 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.MetroToggle1 = New MetroFramework.Controls.MetroToggle()
        Me.MetroToggle2 = New MetroFramework.Controls.MetroToggle()
        Me.MetroPanel1.SuspendLayout()
        Me.MetroPanel3.SuspendLayout()
        Me.MetroPanel4.SuspendLayout()
        Me.MetroPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.MetroLabel3)
        Me.MetroPanel1.Controls.Add(Me.MetroLabel2)
        Me.MetroPanel1.Controls.Add(Me.MetroButton1)
        Me.MetroPanel1.Controls.Add(Me.MetroTextBox1)
        Me.MetroPanel1.Controls.Add(Me.MetroLabel1)
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(23, 63)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(320, 114)
        Me.MetroPanel1.TabIndex = 0
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(18, 79)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(89, 19)
        Me.MetroLabel3.TabIndex = 6
        Me.MetroLabel3.Text = "Tenant Name:"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(103, 79)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(218, 19)
        Me.MetroLabel2.TabIndex = 5
        Me.MetroLabel2.Text = "Last name, First name Middle name"
        '
        'MetroButton1
        '
        Me.MetroButton1.Highlight = True
        Me.MetroButton1.Location = New System.Drawing.Point(242, 53)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton1.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroButton1.TabIndex = 4
        Me.MetroButton1.Text = "Search"
        Me.MetroButton1.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroButton1.UseCustomBackColor = True
        Me.MetroButton1.UseSelectable = True
        Me.MetroButton1.UseStyleColors = True
        '
        'MetroTextBox1
        '
        Me.MetroTextBox1.Lines = New String(-1) {}
        Me.MetroTextBox1.Location = New System.Drawing.Point(18, 53)
        Me.MetroTextBox1.MaxLength = 32767
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox1.PromptText = "House ID"
        Me.MetroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox1.SelectedText = ""
        Me.MetroTextBox1.Size = New System.Drawing.Size(218, 23)
        Me.MetroTextBox1.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox1.TabIndex = 3
        Me.MetroTextBox1.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox1.UseCustomBackColor = True
        Me.MetroTextBox1.UseSelectable = True
        Me.MetroTextBox1.UseStyleColors = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(4, 14)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(61, 19)
        Me.MetroLabel1.TabIndex = 2
        Me.MetroLabel1.Text = "House ID"
        '
        'MetroPanel3
        '
        Me.MetroPanel3.Controls.Add(Me.MetroToggle1)
        Me.MetroPanel3.Controls.Add(Me.MetroTextBox4)
        Me.MetroPanel3.Controls.Add(Me.MetroTextBox3)
        Me.MetroPanel3.Controls.Add(Me.MetroDateTime3)
        Me.MetroPanel3.Controls.Add(Me.MetroDateTime2)
        Me.MetroPanel3.Controls.Add(Me.MetroLabel12)
        Me.MetroPanel3.Controls.Add(Me.MetroLabel11)
        Me.MetroPanel3.Controls.Add(Me.MetroLabel10)
        Me.MetroPanel3.Controls.Add(Me.MetroLabel9)
        Me.MetroPanel3.Controls.Add(Me.MetroLabel5)
        Me.MetroPanel3.HorizontalScrollbarBarColor = True
        Me.MetroPanel3.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel3.HorizontalScrollbarSize = 10
        Me.MetroPanel3.Location = New System.Drawing.Point(23, 183)
        Me.MetroPanel3.Name = "MetroPanel3"
        Me.MetroPanel3.Size = New System.Drawing.Size(321, 178)
        Me.MetroPanel3.TabIndex = 2
        Me.MetroPanel3.VerticalScrollbarBarColor = True
        Me.MetroPanel3.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel3.VerticalScrollbarSize = 10
        Me.MetroPanel3.Visible = False
        '
        'MetroTextBox4
        '
        Me.MetroTextBox4.Lines = New String() {"0"}
        Me.MetroTextBox4.Location = New System.Drawing.Point(117, 137)
        Me.MetroTextBox4.MaxLength = 32767
        Me.MetroTextBox4.Name = "MetroTextBox4"
        Me.MetroTextBox4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox4.PromptText = "Amount"
        Me.MetroTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox4.SelectedText = ""
        Me.MetroTextBox4.Size = New System.Drawing.Size(200, 23)
        Me.MetroTextBox4.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox4.TabIndex = 10
        Me.MetroTextBox4.Text = "0"
        Me.MetroTextBox4.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox4.UseCustomBackColor = True
        Me.MetroTextBox4.UseSelectable = True
        Me.MetroTextBox4.UseStyleColors = True
        '
        'MetroTextBox3
        '
        Me.MetroTextBox3.Lines = New String() {"0"}
        Me.MetroTextBox3.Location = New System.Drawing.Point(117, 107)
        Me.MetroTextBox3.MaxLength = 32767
        Me.MetroTextBox3.Name = "MetroTextBox3"
        Me.MetroTextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox3.PromptText = "Amount"
        Me.MetroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox3.SelectedText = ""
        Me.MetroTextBox3.Size = New System.Drawing.Size(200, 23)
        Me.MetroTextBox3.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox3.TabIndex = 9
        Me.MetroTextBox3.Text = "0"
        Me.MetroTextBox3.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox3.UseCustomBackColor = True
        Me.MetroTextBox3.UseSelectable = True
        Me.MetroTextBox3.UseStyleColors = True
        '
        'MetroDateTime3
        '
        Me.MetroDateTime3.Location = New System.Drawing.Point(117, 71)
        Me.MetroDateTime3.MinimumSize = New System.Drawing.Size(0, 29)
        Me.MetroDateTime3.Name = "MetroDateTime3"
        Me.MetroDateTime3.Size = New System.Drawing.Size(200, 29)
        Me.MetroDateTime3.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroDateTime3.TabIndex = 8
        Me.MetroDateTime3.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroDateTime3.UseCustomBackColor = True
        Me.MetroDateTime3.UseStyleColors = True
        '
        'MetroDateTime2
        '
        Me.MetroDateTime2.Location = New System.Drawing.Point(117, 35)
        Me.MetroDateTime2.MinimumSize = New System.Drawing.Size(0, 29)
        Me.MetroDateTime2.Name = "MetroDateTime2"
        Me.MetroDateTime2.Size = New System.Drawing.Size(200, 29)
        Me.MetroDateTime2.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroDateTime2.TabIndex = 7
        Me.MetroDateTime2.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroDateTime2.UseCustomBackColor = True
        Me.MetroDateTime2.UseStyleColors = True
        '
        'MetroLabel12
        '
        Me.MetroLabel12.AutoSize = True
        Me.MetroLabel12.Location = New System.Drawing.Point(28, 141)
        Me.MetroLabel12.Name = "MetroLabel12"
        Me.MetroLabel12.Size = New System.Drawing.Size(56, 19)
        Me.MetroLabel12.TabIndex = 6
        Me.MetroLabel12.Text = "Amount"
        '
        'MetroLabel11
        '
        Me.MetroLabel11.AutoSize = True
        Me.MetroLabel11.Location = New System.Drawing.Point(30, 111)
        Me.MetroLabel11.Name = "MetroLabel11"
        Me.MetroLabel11.Size = New System.Drawing.Size(70, 19)
        Me.MetroLabel11.TabIndex = 5
        Me.MetroLabel11.Text = "Total (kwh)"
        '
        'MetroLabel10
        '
        Me.MetroLabel10.AutoSize = True
        Me.MetroLabel10.Location = New System.Drawing.Point(28, 81)
        Me.MetroLabel10.Name = "MetroLabel10"
        Me.MetroLabel10.Size = New System.Drawing.Size(62, 19)
        Me.MetroLabel10.TabIndex = 4
        Me.MetroLabel10.Text = "Due date"
        '
        'MetroLabel9
        '
        Me.MetroLabel9.AutoSize = True
        Me.MetroLabel9.Location = New System.Drawing.Point(28, 45)
        Me.MetroLabel9.Name = "MetroLabel9"
        Me.MetroLabel9.Size = New System.Drawing.Size(56, 19)
        Me.MetroLabel9.TabIndex = 3
        Me.MetroLabel9.Text = "Bill date"
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = True
        Me.MetroLabel5.Location = New System.Drawing.Point(4, 4)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(71, 19)
        Me.MetroLabel5.TabIndex = 2
        Me.MetroLabel5.Text = "Electric bill"
        '
        'MetroPanel4
        '
        Me.MetroPanel4.Controls.Add(Me.MetroToggle2)
        Me.MetroPanel4.Controls.Add(Me.MetroTextBox5)
        Me.MetroPanel4.Controls.Add(Me.MetroTextBox6)
        Me.MetroPanel4.Controls.Add(Me.MetroDateTime4)
        Me.MetroPanel4.Controls.Add(Me.MetroDateTime5)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel13)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel14)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel15)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel16)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel6)
        Me.MetroPanel4.HorizontalScrollbarBarColor = True
        Me.MetroPanel4.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel4.HorizontalScrollbarSize = 10
        Me.MetroPanel4.Location = New System.Drawing.Point(350, 183)
        Me.MetroPanel4.Name = "MetroPanel4"
        Me.MetroPanel4.Size = New System.Drawing.Size(312, 178)
        Me.MetroPanel4.TabIndex = 3
        Me.MetroPanel4.VerticalScrollbarBarColor = True
        Me.MetroPanel4.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel4.VerticalScrollbarSize = 10
        Me.MetroPanel4.Visible = False
        '
        'MetroTextBox5
        '
        Me.MetroTextBox5.Lines = New String() {"0"}
        Me.MetroTextBox5.Location = New System.Drawing.Point(98, 137)
        Me.MetroTextBox5.MaxLength = 32767
        Me.MetroTextBox5.Name = "MetroTextBox5"
        Me.MetroTextBox5.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox5.PromptText = "Amount"
        Me.MetroTextBox5.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox5.SelectedText = ""
        Me.MetroTextBox5.Size = New System.Drawing.Size(200, 23)
        Me.MetroTextBox5.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox5.TabIndex = 18
        Me.MetroTextBox5.Text = "0"
        Me.MetroTextBox5.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox5.UseCustomBackColor = True
        Me.MetroTextBox5.UseSelectable = True
        Me.MetroTextBox5.UseStyleColors = True
        '
        'MetroTextBox6
        '
        Me.MetroTextBox6.Lines = New String() {"0"}
        Me.MetroTextBox6.Location = New System.Drawing.Point(98, 107)
        Me.MetroTextBox6.MaxLength = 32767
        Me.MetroTextBox6.Name = "MetroTextBox6"
        Me.MetroTextBox6.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox6.PromptText = "Amount"
        Me.MetroTextBox6.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox6.SelectedText = ""
        Me.MetroTextBox6.Size = New System.Drawing.Size(200, 23)
        Me.MetroTextBox6.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox6.TabIndex = 17
        Me.MetroTextBox6.Text = "0"
        Me.MetroTextBox6.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox6.UseCustomBackColor = True
        Me.MetroTextBox6.UseSelectable = True
        Me.MetroTextBox6.UseStyleColors = True
        '
        'MetroDateTime4
        '
        Me.MetroDateTime4.Location = New System.Drawing.Point(98, 71)
        Me.MetroDateTime4.MinimumSize = New System.Drawing.Size(0, 29)
        Me.MetroDateTime4.Name = "MetroDateTime4"
        Me.MetroDateTime4.Size = New System.Drawing.Size(200, 29)
        Me.MetroDateTime4.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroDateTime4.TabIndex = 16
        Me.MetroDateTime4.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroDateTime4.UseCustomBackColor = True
        Me.MetroDateTime4.UseStyleColors = True
        '
        'MetroDateTime5
        '
        Me.MetroDateTime5.Location = New System.Drawing.Point(98, 35)
        Me.MetroDateTime5.MinimumSize = New System.Drawing.Size(0, 29)
        Me.MetroDateTime5.Name = "MetroDateTime5"
        Me.MetroDateTime5.Size = New System.Drawing.Size(200, 29)
        Me.MetroDateTime5.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroDateTime5.TabIndex = 15
        Me.MetroDateTime5.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroDateTime5.UseCustomBackColor = True
        Me.MetroDateTime5.UseStyleColors = True
        '
        'MetroLabel13
        '
        Me.MetroLabel13.AutoSize = True
        Me.MetroLabel13.Location = New System.Drawing.Point(13, 141)
        Me.MetroLabel13.Name = "MetroLabel13"
        Me.MetroLabel13.Size = New System.Drawing.Size(56, 19)
        Me.MetroLabel13.TabIndex = 14
        Me.MetroLabel13.Text = "Amount"
        '
        'MetroLabel14
        '
        Me.MetroLabel14.AutoSize = True
        Me.MetroLabel14.Location = New System.Drawing.Point(13, 111)
        Me.MetroLabel14.Name = "MetroLabel14"
        Me.MetroLabel14.Size = New System.Drawing.Size(87, 19)
        Me.MetroLabel14.TabIndex = 13
        Me.MetroLabel14.Text = "Consumption"
        '
        'MetroLabel15
        '
        Me.MetroLabel15.AutoSize = True
        Me.MetroLabel15.Location = New System.Drawing.Point(13, 81)
        Me.MetroLabel15.Name = "MetroLabel15"
        Me.MetroLabel15.Size = New System.Drawing.Size(62, 19)
        Me.MetroLabel15.TabIndex = 12
        Me.MetroLabel15.Text = "Due date"
        '
        'MetroLabel16
        '
        Me.MetroLabel16.AutoSize = True
        Me.MetroLabel16.Location = New System.Drawing.Point(13, 45)
        Me.MetroLabel16.Name = "MetroLabel16"
        Me.MetroLabel16.Size = New System.Drawing.Size(56, 19)
        Me.MetroLabel16.TabIndex = 11
        Me.MetroLabel16.Text = "Bill date"
        '
        'MetroLabel6
        '
        Me.MetroLabel6.AutoSize = True
        Me.MetroLabel6.Location = New System.Drawing.Point(4, 4)
        Me.MetroLabel6.Name = "MetroLabel6"
        Me.MetroLabel6.Size = New System.Drawing.Size(65, 19)
        Me.MetroLabel6.TabIndex = 2
        Me.MetroLabel6.Text = "Water bill"
        '
        'MetroButton2
        '
        Me.MetroButton2.Highlight = True
        Me.MetroButton2.Location = New System.Drawing.Point(506, 25)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton2.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroButton2.TabIndex = 4
        Me.MetroButton2.Text = "Bill"
        Me.MetroButton2.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroButton2.UseCustomBackColor = True
        Me.MetroButton2.UseSelectable = True
        Me.MetroButton2.UseStyleColors = True
        Me.MetroButton2.Visible = False
        '
        'MetroButton3
        '
        Me.MetroButton3.Highlight = True
        Me.MetroButton3.Location = New System.Drawing.Point(587, 25)
        Me.MetroButton3.Name = "MetroButton3"
        Me.MetroButton3.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton3.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroButton3.TabIndex = 5
        Me.MetroButton3.Text = "Cancel"
        Me.MetroButton3.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroButton3.UseCustomBackColor = True
        Me.MetroButton3.UseSelectable = True
        Me.MetroButton3.UseStyleColors = True
        Me.MetroButton3.Visible = False
        '
        'MetroPanel2
        '
        Me.MetroPanel2.Controls.Add(Me.MetroLabel8)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel7)
        Me.MetroPanel2.Controls.Add(Me.MetroTextBox2)
        Me.MetroPanel2.Controls.Add(Me.MetroDateTime1)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel4)
        Me.MetroPanel2.HorizontalScrollbarBarColor = True
        Me.MetroPanel2.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.HorizontalScrollbarSize = 10
        Me.MetroPanel2.Location = New System.Drawing.Point(350, 63)
        Me.MetroPanel2.Name = "MetroPanel2"
        Me.MetroPanel2.Size = New System.Drawing.Size(312, 114)
        Me.MetroPanel2.TabIndex = 6
        Me.MetroPanel2.VerticalScrollbarBarColor = True
        Me.MetroPanel2.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.VerticalScrollbarSize = 10
        Me.MetroPanel2.Visible = False
        '
        'MetroLabel8
        '
        Me.MetroLabel8.AutoSize = True
        Me.MetroLabel8.Location = New System.Drawing.Point(14, 78)
        Me.MetroLabel8.Name = "MetroLabel8"
        Me.MetroLabel8.Size = New System.Drawing.Size(62, 19)
        Me.MetroLabel8.TabIndex = 6
        Me.MetroLabel8.Text = "Due date"
        '
        'MetroLabel7
        '
        Me.MetroLabel7.AutoSize = True
        Me.MetroLabel7.Location = New System.Drawing.Point(13, 42)
        Me.MetroLabel7.Name = "MetroLabel7"
        Me.MetroLabel7.Size = New System.Drawing.Size(56, 19)
        Me.MetroLabel7.TabIndex = 5
        Me.MetroLabel7.Text = "Amount"
        '
        'MetroTextBox2
        '
        Me.MetroTextBox2.Lines = New String() {"0"}
        Me.MetroTextBox2.Location = New System.Drawing.Point(112, 38)
        Me.MetroTextBox2.MaxLength = 32767
        Me.MetroTextBox2.Name = "MetroTextBox2"
        Me.MetroTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox2.PromptText = "Amount"
        Me.MetroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox2.SelectedText = ""
        Me.MetroTextBox2.Size = New System.Drawing.Size(186, 23)
        Me.MetroTextBox2.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox2.TabIndex = 4
        Me.MetroTextBox2.Text = "0"
        Me.MetroTextBox2.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox2.UseCustomBackColor = True
        Me.MetroTextBox2.UseSelectable = True
        Me.MetroTextBox2.UseStyleColors = True
        '
        'MetroDateTime1
        '
        Me.MetroDateTime1.Location = New System.Drawing.Point(112, 68)
        Me.MetroDateTime1.MinimumSize = New System.Drawing.Size(0, 29)
        Me.MetroDateTime1.Name = "MetroDateTime1"
        Me.MetroDateTime1.Size = New System.Drawing.Size(186, 29)
        Me.MetroDateTime1.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroDateTime1.TabIndex = 3
        Me.MetroDateTime1.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroDateTime1.UseCustomBackColor = True
        Me.MetroDateTime1.UseStyleColors = True
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(3, 14)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(49, 19)
        Me.MetroLabel4.TabIndex = 2
        Me.MetroLabel4.Text = "Rental "
        '
        'MetroToggle1
        '
        Me.MetroToggle1.AutoSize = True
        Me.MetroToggle1.Checked = True
        Me.MetroToggle1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MetroToggle1.Location = New System.Drawing.Point(237, 5)
        Me.MetroToggle1.Name = "MetroToggle1"
        Me.MetroToggle1.Size = New System.Drawing.Size(80, 17)
        Me.MetroToggle1.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroToggle1.TabIndex = 11
        Me.MetroToggle1.Text = "On"
        Me.MetroToggle1.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroToggle1.UseCustomBackColor = True
        Me.MetroToggle1.UseSelectable = True
        Me.MetroToggle1.UseStyleColors = True
        '
        'MetroToggle2
        '
        Me.MetroToggle2.AutoSize = True
        Me.MetroToggle2.Checked = True
        Me.MetroToggle2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MetroToggle2.Location = New System.Drawing.Point(218, 5)
        Me.MetroToggle2.Name = "MetroToggle2"
        Me.MetroToggle2.Size = New System.Drawing.Size(80, 17)
        Me.MetroToggle2.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroToggle2.TabIndex = 19
        Me.MetroToggle2.Text = "On"
        Me.MetroToggle2.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroToggle2.UseCustomBackColor = True
        Me.MetroToggle2.UseSelectable = True
        Me.MetroToggle2.UseStyleColors = True
        '
        'addNewBilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 379)
        Me.Controls.Add(Me.MetroPanel2)
        Me.Controls.Add(Me.MetroButton3)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroPanel4)
        Me.Controls.Add(Me.MetroPanel3)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "addNewBilling"
        Me.Resizable = False
        Me.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow
        Me.Text = "New Billing"
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel1.PerformLayout()
        Me.MetroPanel3.ResumeLayout(False)
        Me.MetroPanel3.PerformLayout()
        Me.MetroPanel4.ResumeLayout(False)
        Me.MetroPanel4.PerformLayout()
        Me.MetroPanel2.ResumeLayout(False)
        Me.MetroPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroTextBox1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroPanel3 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroLabel5 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroPanel4 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroLabel6 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton3 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroTextBox4 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroTextBox3 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroDateTime3 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroDateTime2 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroLabel12 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel11 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel10 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel9 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox5 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroTextBox6 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroDateTime4 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroDateTime5 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroLabel13 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel14 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel15 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel16 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroPanel2 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroLabel8 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel7 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox2 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroDateTime1 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroToggle1 As MetroFramework.Controls.MetroToggle
    Friend WithEvents MetroToggle2 As MetroFramework.Controls.MetroToggle
End Class
