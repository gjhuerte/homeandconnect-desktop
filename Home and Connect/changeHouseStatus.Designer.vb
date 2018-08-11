<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changeHouseStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(changeHouseStatus))
        Me.MetroTextBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.MetroButton3 = New MetroFramework.Controls.MetroButton()
        Me.MetroRadioButton3 = New MetroFramework.Controls.MetroRadioButton()
        Me.MetroRadioButton1 = New MetroFramework.Controls.MetroRadioButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.MetroPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroTextBox1
        '
        Me.MetroTextBox1.Lines = New String(-1) {}
        Me.MetroTextBox1.Location = New System.Drawing.Point(106, 74)
        Me.MetroTextBox1.MaxLength = 32767
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox1.PromptText = "House ID"
        Me.MetroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox1.SelectedText = ""
        Me.MetroTextBox1.Size = New System.Drawing.Size(174, 23)
        Me.MetroTextBox1.Style = MetroFramework.MetroColorStyle.Orange
        Me.MetroTextBox1.TabIndex = 0
        Me.MetroTextBox1.UseCustomBackColor = True
        Me.MetroTextBox1.UseSelectable = True
        Me.MetroTextBox1.UseStyleColors = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(23, 78)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(61, 19)
        Me.MetroLabel1.TabIndex = 1
        Me.MetroLabel1.Text = "House ID"
        '
        'MetroButton1
        '
        Me.MetroButton1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MetroButton1.Highlight = True
        Me.MetroButton1.Location = New System.Drawing.Point(286, 74)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton1.Style = MetroFramework.MetroColorStyle.Orange
        Me.MetroButton1.TabIndex = 2
        Me.MetroButton1.Text = "Get Status"
        Me.MetroButton1.UseCustomBackColor = True
        Me.MetroButton1.UseSelectable = True
        Me.MetroButton1.UseStyleColors = True
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.MetroButton3)
        Me.MetroPanel1.Controls.Add(Me.MetroRadioButton3)
        Me.MetroPanel1.Controls.Add(Me.MetroRadioButton1)
        Me.MetroPanel1.Controls.Add(Me.MetroButton2)
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(1, 105)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(383, 100)
        Me.MetroPanel1.TabIndex = 4
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        Me.MetroPanel1.Visible = False
        '
        'MetroButton3
        '
        Me.MetroButton3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MetroButton3.Highlight = True
        Me.MetroButton3.Location = New System.Drawing.Point(285, 62)
        Me.MetroButton3.Name = "MetroButton3"
        Me.MetroButton3.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton3.Style = MetroFramework.MetroColorStyle.Orange
        Me.MetroButton3.TabIndex = 10
        Me.MetroButton3.Text = "Cancel"
        Me.MetroButton3.UseCustomBackColor = True
        Me.MetroButton3.UseSelectable = True
        Me.MetroButton3.UseStyleColors = True
        '
        'MetroRadioButton3
        '
        Me.MetroRadioButton3.AutoSize = True
        Me.MetroRadioButton3.Location = New System.Drawing.Point(91, 21)
        Me.MetroRadioButton3.Name = "MetroRadioButton3"
        Me.MetroRadioButton3.Size = New System.Drawing.Size(127, 15)
        Me.MetroRadioButton3.Style = MetroFramework.MetroColorStyle.Orange
        Me.MetroRadioButton3.TabIndex = 9
        Me.MetroRadioButton3.Text = "Under Maintenance"
        Me.MetroRadioButton3.UseCustomBackColor = True
        Me.MetroRadioButton3.UseSelectable = True
        Me.MetroRadioButton3.UseStyleColors = True
        '
        'MetroRadioButton1
        '
        Me.MetroRadioButton1.AutoSize = True
        Me.MetroRadioButton1.Location = New System.Drawing.Point(22, 21)
        Me.MetroRadioButton1.Name = "MetroRadioButton1"
        Me.MetroRadioButton1.Size = New System.Drawing.Size(45, 15)
        Me.MetroRadioButton1.Style = MetroFramework.MetroColorStyle.Orange
        Me.MetroRadioButton1.TabIndex = 7
        Me.MetroRadioButton1.Text = "Free"
        Me.MetroRadioButton1.UseCustomBackColor = True
        Me.MetroRadioButton1.UseSelectable = True
        Me.MetroRadioButton1.UseStyleColors = True
        '
        'MetroButton2
        '
        Me.MetroButton2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MetroButton2.Highlight = True
        Me.MetroButton2.Location = New System.Drawing.Point(194, 62)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton2.Style = MetroFramework.MetroColorStyle.Orange
        Me.MetroButton2.TabIndex = 6
        Me.MetroButton2.Text = "Change"
        Me.MetroButton2.UseCustomBackColor = True
        Me.MetroButton2.UseSelectable = True
        Me.MetroButton2.UseStyleColors = True
        '
        'changeHouseStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 213)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.MetroTextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "changeHouseStatus"
        Me.Resizable = False
        Me.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow
        Me.Style = MetroFramework.MetroColorStyle.Orange
        Me.Text = "Maintenance Status"
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroTextBox1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton3 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroRadioButton3 As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents MetroRadioButton1 As MetroFramework.Controls.MetroRadioButton
End Class
