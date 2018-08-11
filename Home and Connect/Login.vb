Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("SELECT * FROM tbl_user WHERE username  = '" & MetroTextBox1.Text &
                        "' AND password = '" & MetroTextBox2.Text & "'") Then
            log()
            Me.Close()
            MainMenu.Show()
            Timer1.Stop()
        Else
            MessageBox.Show("Invalid Login information!", "Login Status",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        resetTextBox()
    End Sub
    'reset data on textboxes
    Sub resetTextBox()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
    End Sub
    'checks if the account has admin in it
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If executeQuery("SELECT * FROM tbl_user") = False Then
            Me.Visible = False
            Dim AdminInfo As New UserInformation
            AdminInfo.ShowDialog()
            If executeQuery("SELECT * FROM tbl_user") = False Then
                Application.Exit()
            Else
                Timer1.Stop()
            End If
            Me.Visible = True
        End If
    End Sub
    Private Sub Login_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If executeQuery("SELECT * FROM tbl_user") Then
            Timer1.Stop()
        Else
            Timer1.Start()
        End If
    End Sub

    Private Sub Login_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If executeQuery("SELECT * FROM tbl_user") Then
            Timer1.Stop()
        Else
            Timer1.Start()
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Sub log()
        executeQuery("INSERT INTO tbl_userlog(username,login) VALUES('" + MetroTextBox1.Text + "',now())")
    End Sub
End Class