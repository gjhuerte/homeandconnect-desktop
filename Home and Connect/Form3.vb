Imports MySql.Data.MySqlClient

Public Class Form3
    Dim edit As New UserInformation
    Public connection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public adapter As New MySqlDataAdapter
    Public reader As MySqlDataReader
    Public table As New DataTable
    Public source As New BindingSource
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("SELECT * FROM user_v WHERE password = '" & MetroTextBox1.Text & "' AND type = 'Owner'") Then
            If executeQuery("SELECT * FROM user_v WHERE username = '" & MetroTextBox2.Text & "'") Then
                If MetroButton1.Text = "Search" Then
                    showUserInformation()
                    Me.Close()
                    edit.ShowDialog()
                Else
                End If
            End If
        End If
    End Sub

    Sub showUserInformation()
        setDesign()
        setTextField()
    End Sub

    Sub setDesign()
        edit.MetroButton1.Text = "Edit"
        edit.MetroTextBox8.Enabled = False
    End Sub

    Sub setTextField()
        connection.ConnectionString = sqlinfo
        Try
            connection.Open()
            command = New MySqlCommand("SELECT * FROM user_v WHERE username = '" & MetroTextBox2.Text & "'", connection)
            reader = command.ExecuteReader
            If reader.Read Then
                edit.MetroTextBox1.Text = reader.GetString("lname")
                edit.MetroTextBox2.Text = reader.GetString("fname")
                edit.MetroTextBox3.Text = reader.GetString("mname")
                edit.MetroTextBox4.Text = reader.GetString("email")
                edit.MetroTextBox5.Text = reader.GetString("cellno")
                edit.MetroDateTime1.Value = reader.GetString("birthdate")
                If reader.GetString("gender") = "M" Then
                    edit.MetroRadioButton1.Checked = True
                Else
                    edit.MetroRadioButton2.Checked = True
                End If
                edit.MetroTextBox8.Text = reader.GetString("username")
                edit.MetroTextBox6.Text = reader.GetString("password")
            End If
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class