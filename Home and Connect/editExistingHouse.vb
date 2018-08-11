Imports MySql.Data.MySqlClient
Public Class EditExistingHouse
    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub


    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        MetroTextBox2.Text = FileBrowse("Image File", "C:\", "*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)
                                        |*.*", 2)
        PictureBox1.Image = Image.FromFile(MetroTextBox2.Text)
    End Sub

    Private Sub MetroTextBox3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox8.Validating, MetroTextBox7.Validating, MetroTextBox6.Validating, MetroTextBox5.Validating, MetroTextBox4.Validating, MetroTextBox3.Validating
        If TryParse(sender.text) = False Then
            sender.text = 0
        End If
    End Sub


    Function isEmpty() As Boolean
        If isNullOrEmpty(MetroTextBox2.Text) Then
            MetroLabel10.Visible = True
            Return True
        Else
            MetroLabel10.Visible = False
        End If
        If isNullOrEmpty(MetroTextBox1.Text) Then
            MetroLabel11.Visible = True
            Return True
        Else
            MetroLabel11.Visible = False
        End If
        Return False
    End Function

    Private Sub MetroLabel11_VisibleChanged(sender As Object, e As EventArgs) Handles MetroLabel11.VisibleChanged, MetroLabel10.VisibleChanged
        If sender.visible Then
            MetroLabel9.Visible = True
        Else
            MetroLabel9.Visible = False
        End If
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        If isEmpty() = False Then
            Dim image = MetroTextBox9.Text.Replace("/", "\")
            If executeQuery("UPDATE tbl_housedesc SET bedroomno = '" & MetroTextBox3.Text & "',
            kitchenno = '" & MetroTextBox4.Text & "',bathroomno = '" & MetroTextBox5.Text & "',
            livingroomno = '" & MetroTextBox6.Text & "',toiletroomno = '" & MetroTextBox7.Text & "',
            terraceno = '" & MetroTextBox8.Text & "',address = '" & MetroTextBox2.Text & "',
            image = '" & image & "' WHERE id = '" & MetroTextBox1.Text & "'") Then
                MessageBox.Show("House information updated!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Else
            MessageBox.Show("Fill-up all the required fields!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub MetroTextBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox1.Validating
        MetroPanel1.Visible = False
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox1.Text & "'") Then
            connection.ConnectionString = sqlinfo
            Try
                connection.Open()
                command = New MySqlCommand("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox1.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    MetroTextBox3.Text = reader.GetString("bedroomno")
                    MetroTextBox4.Text = reader.GetString("kitchenno")
                    MetroTextBox5.Text = reader.GetString("bathroomno")
                    MetroTextBox6.Text = reader.GetString("livingroomno")
                    MetroTextBox7.Text = reader.GetString("toiletno")
                    MetroTextBox8.Text = reader.GetString("terraceno")
                    MetroTextBox2.Text = reader.GetString("image")
                    MetroTextBox9.Text = reader.GetString("address")
                End If
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            PictureBox1.Image = Image.FromFile(MetroTextBox2.Text)
            MetroPanel1.Visible = False
        Else
            MessageBox.Show("House not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class