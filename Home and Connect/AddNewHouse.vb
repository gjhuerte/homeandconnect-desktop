Public Class AddNewHouse
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        MetroTextBox2.Text = FileBrowse("Image File", "C:\", "*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)
                                        |*.*", 2)
        PictureBox1.Image = Image.FromFile(MetroTextBox2.Text)
    End Sub

    Private Sub MetroTextBox3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox8.Validating, MetroTextBox7.Validating, MetroTextBox6.Validating, MetroTextBox5.Validating, MetroTextBox4.Validating, MetroTextBox3.Validating
        If TryParse(sender.text) = False Then
            sender.text = 0
        End If
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Me.Close()
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

        If isNullOrEmpty(MetroTextBox3.Text) Then
            MetroTextBox3.Text = 0
        End If

        If isNullOrEmpty(MetroTextBox4.Text) Then
            MetroTextBox4.Text = 0
        End If

        If isNullOrEmpty(MetroTextBox5.Text) Then
            MetroTextBox5.Text = 0
        End If

        If isNullOrEmpty(MetroTextBox6.Text) Then
            MetroTextBox6.Text = 0
        End If
        If isNullOrEmpty(MetroTextBox7.Text) Then
            MetroTextBox7.Text = 0
        End If
        If isNullOrEmpty(MetroTextBox8.Text) Then
            MetroTextBox8.Text = 0
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

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        If isEmpty() = False Then
            Dim image = MetroTextBox2.Text.Replace("\", "/")
            If executeQuery("INSERT INTO tbl_housedesc(bedroomno,kitchenno,bathroomno,livingroomno,toiletno,
            terraceno,address,image,status) VALUES('" & MetroTextBox3.Text & "','" & MetroTextBox4.Text & "',
            '" & MetroTextBox5.Text & "','" & MetroTextBox6.Text & "','" & MetroTextBox7.Text & "',
            '" & MetroTextBox8.Text & "','" & MetroTextBox1.Text & "','" & image & "','F')") Then
                MessageBox.Show("House added!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Else
            MessageBox.Show("Fill-up all the required fields!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class