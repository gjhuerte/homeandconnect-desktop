Imports MySql.Data.MySqlClient
Public Class EditTenant
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("SELECT * FROM tbl_tenant WHERE personid = '" & MetroTextBox6.Text & "'") Then
            MessageBox.Show("Tenant Found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            setTenantTable()
            MetroPanel1.Visible = True
        Else
            MessageBox.Show("Tenant not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Sub setTenantTable()
        connection.ConnectionString = sqlinfo
        Try
            connection.Open()
            command = New MySqlCommand("SELECT * FROM tbl_personalinfo WHERE id = '" & MetroTextBox6.Text & "'", connection)
            reader = command.ExecuteReader
            If reader.Read Then
                MetroTextBox1.Text = reader.GetString("lname")
                MetroTextBox2.Text = reader.GetString("fname")
                MetroTextBox3.Text = reader.GetString("mname")
                MetroTextBox4.Text = reader.GetString("email")
                MetroTextBox5.Text = reader.GetString("cellno")
                MetroDateTime1.Value = reader.GetString("birthdate")
                If reader.GetString("gender") = "M" Then
                    MetroRadioButton1.Checked = True
                Else
                    MetroRadioButton2.Checked = True
                End If
            End If
            connection.Close()
            MessageBox.Show("Successfully Updated!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MetroTextBox6_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox6.Validating
        MetroPanel1.Visible = False
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub


    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        assignIfEmpty()
        If isEmpty() Then
            MessageBox.Show("FIll-up all the empty textboxes!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim birthdate As String = MetroDateTime1.Value.Date.ToString("yyyyMMdd").Replace("/", "\")
            Dim gender As Char
            If MetroRadioButton1.Checked Then
                gender = "M"
            Else
                gender = "F"
            End If
            If executeQuery("UPDATE tbl_personalinfo SET lname = '" & MetroTextBox1.Text & "', 
                fname = '" & MetroTextBox2.Text & "', mname = '" & MetroTextBox3.Text & "', 
                birthdate = '" & birthdate & "', email = '" & MetroTextBox4.Text & "', cellno = '" & MetroTextBox5.Text & "', 
                gender = '" & gender & "' WHERE  id = '" & MetroTextBox6.Text & "'") Then
            Else
                MessageBox.Show("System error!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Function isEmpty() As Boolean
        If isNullOrEmpty(MetroTextBox1.Text) Or isNullOrEmpty(MetroTextBox2.Text) Or isNullOrEmpty(MetroTextBox3.Text) Or isNullOrEmpty(MetroTextBox4.Text) Then
            Return True
        End If
        Return False
    End Function
    Sub assignIfEmpty()
        If isNullOrEmpty(MetroTextBox1.Text) Then
            MetroLabel7.Visible = True
        End If
        If isNullOrEmpty(MetroTextBox2.Text) Then
            MetroLabel8.Visible = True
        End If
        If isNullOrEmpty(MetroTextBox3.Text) Then
            MetroLabel9.Visible = True
        End If
        If isNullOrEmpty(MetroTextBox4.Text) Then
            MetroLabel11.Visible = True
        End If
        If isNullOrEmpty(MetroTextBox5.Text) Then
            MetroLabel12.Visible = True
        End If
    End Sub
    Private Sub MetroLabel7_VisibleChanged(sender As Object, e As EventArgs) Handles MetroLabel9.VisibleChanged, MetroLabel8.VisibleChanged, MetroLabel7.VisibleChanged, MetroLabel12.VisibleChanged, MetroLabel11.VisibleChanged
        If sender.visible Then
            MetroLabel6.Visible = True
        ElseIf Not isEmpty() Then
            MetroLabel6.Visible = False
        End If
    End Sub

    Private Sub MetroTextBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox1.Validating
        If isNullOrEmpty(sender.text) Then
            MetroLabel7.Visible = True
        ElseIf Not isValidSurName(sender.text) Then
            MetroLabel7.Visible = True
            sender.text = ""
        Else
            MetroLabel7.Visible = False
        End If
    End Sub

    Private Sub MetroTextBox2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox2.Validating

        If isNullOrEmpty(sender.text) Then
            MetroLabel8.Visible = True
        ElseIf Not isValidFirstName(sender.text) Then
            MetroLabel8.Visible = True
            sender.text = ""
        Else
            MetroLabel8.Visible = False
        End If
    End Sub

    Private Sub MetroTextBox3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox3.Validating

        If isNullOrEmpty(sender.text) Then
            MetroLabel9.Visible = True
        ElseIf Not isValidSurName(sender.text) Then
            MetroLabel9.Visible = True
            sender.text = ""
        Else
            MetroLabel9.Visible = False
        End If
    End Sub

    Private Sub MetroTextBox4_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox4.Validating
        If isNullOrEmpty(sender.text) Then
            MetroLabel11.Visible = True
        ElseIf Not isValidEmailAddress(sender.text) Then
            MetroLabel11.Visible = True
            sender.text = ""
        Else
            MetroLabel11.Visible = False
        End If
    End Sub

    Private Sub MetroTextBox1_Validated(sender As Object, e As EventArgs) Handles MetroTextBox3.Validated, MetroTextBox2.Validated, MetroTextBox1.Validated
        sender.text = UppercaseFirstLetter(sender.text)
    End Sub

    Private Sub MetroTextBox5_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox5.Validating
        If isNullOrEmpty(sender.text) Then
            MetroLabel12.Visible = True
        End If
    End Sub
End Class