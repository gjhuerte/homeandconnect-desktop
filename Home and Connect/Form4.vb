Imports MySql.Data.MySqlClient

Public Class Form4
    Public connection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public adapter As New MySqlDataAdapter
    Public reader As MySqlDataReader
    Public table As New DataTable
    Public source As New BindingSource
    Dim userinfo As New UserInformation

    Sub setDesign()
        userinfo.MetroButton1.Text = "Update"
        userinfo.MetroTextBox8.Text = MetroTextBox1.Text
        userinfo.MetroTextBox8.Enabled = False
        connection.ConnectionString = sqlinfo
        Try
            connection.Open()
            command = New MySqlCommand("SELECT * FROM user_v WHERE id = '" & MetroTextBox1.Text & "'", connection)
            reader = command.ExecuteReader
            If reader.Read Then
                userinfo.MetroTextBox1.Text = reader.GetString("lname")
                userinfo.MetroTextBox2.Text = reader.GetString("fname")
                userinfo.MetroTextBox3.Text = reader.GetString("mname")
                userinfo.MetroTextBox4.Text = reader.GetString("email")
                userinfo.MetroTextBox5.Text = reader.GetString("cellno")
                userinfo.MetroDateTime1.Value = reader.GetString("birthdate")
                If reader.GetString("gender") = "M" Then
                    userinfo.MetroRadioButton1.Checked = True
                Else
                    userinfo.MetroRadioButton2.Checked = True
                End If
            End If
            Me.Close()
            userinfo.Show()
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        searchForAccount()
    End Sub

    Private Sub MetroTextBox2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox2.Validating
        searchForAccount()
    End Sub

    Sub searchForAccount()
        If executeQuery("SELECT * FROM user_v WHERE password = '" & MetroTextBox2.Text & "'") Then
            MetroPanel1.Visible = True
        Else
            MetroPanel2.Visible = False
        End If
    End Sub

    Private Sub MetroButton1_Click_1(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If MetroButton1.Text = "Search" Then
            setDesign()
        Else
            If executeQuery("SELECT * FROM tbl_user WHERE username = '" & MetroTextBox1.Text & "'") Then
                executeQuery("CALL sproc_deleteuserinfo('" & MetroTextBox1.Text & "')")
                MessageBox.Show("User Deleted", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("User not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class