Imports MySql.Data.MySqlClient
Public Class Login
    Dim mainmenu As New MainMenu
    Dim _id = 0
    Dim login As String
    Public connection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public adapter As New MySqlDataAdapter
    Public reader As MySqlDataReader
    Public table As New DataTable
    Public source As New BindingSource
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("SELECT * FROM tbl_user WHERE username  = '" & MetroTextBox1.Text &
                        "' AND password = '" & MetroTextBox2.Text & "'") Then
            login = DateTime.Now
            Me.Visible = False
            mainmenu.ShowDialog()
            log()
            Me.Close()
            Timer1.Stop()
        Else
            MessageBox.Show("Invalid Login information!", "Login Status",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        resetTextBox()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CustomSplashScreen.BarLong(100)
        Dim i As Integer = 0
        While i <= 100
            CustomSplashScreen.ShowBar(i)
            i += 1
            Threading.Thread.Sleep(100)
        End While

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
            Timer1.Stop()
            AdminInfo.ShowDialog()
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
        connection.ConnectionString = sqlinfo
        Try
            connection.Open()
            Dim sqlquery As String = "INSERT INTO tbl_userlog(username,login,logout) VALUES('" & MetroTextBox1.Text & "',@dt,now())"
            Dim mycommand As New MySqlCommand(sqlquery, connection)
            'Dim myadapter As New MySqlDataAdapter()
            'Dim Table As New DataTable
            mycommand.Connection = connection
            mycommand.CommandText = sqlquery
            'Here we add the parameters'
            mycommand.Parameters.AddWithValue("@dt", Convert.ToDateTime(login))
            mycommand.CommandType = CommandType.Text
            mycommand.ExecuteNonQuery()
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


End Class