Imports MySql.Data.MySqlClient
Public Class ViewHouseInformation
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox1.Text & "'") Then
            MessageBox.Show("House found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            connection.ConnectionString = sqlinfo
            Try
                connection.Open()
                command = New MySqlCommand("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox2.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    MetroTextBox3.Text = reader.GetString("bedroomno")
                    MetroTextBox4.Text = reader.GetString("kitchenno")
                    MetroTextBox5.Text = reader.GetString("bathroomno")
                    MetroTextBox6.Text = reader.GetString("livingroomno")
                    MetroTextBox7.Text = reader.GetString("toiletno")
                    MetroTextBox8.Text = reader.GetString("terraceno")
                    PictureBox1.Image = Image.FromFile(reader.GetString("image"))
                    MetroTextBox1.Text = reader.GetString("address")
                End If
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("House not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class