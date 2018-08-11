Public Class AddNewTenant
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
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
            If executeQuery("INSERT INTO tbl_personalinfo(lname, fname, mname, birthdate, email, cellno, gender) 
                VALUES('" & MetroTextBox1.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox3.Text & "',
                '" & birthdate & "','" & MetroTextBox4.Text & "','" & MetroTextBox5.Text & "','" & gender & "');
                 insert into tbl_tenant select last_insert_id();") Then
                Dim message = "Tenant '" + MetroTextBox2.Text + " " + MetroTextBox1.Text + "' added!"
                MessageBox.Show(message, "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageBox.Show("Do you want this tenant to assign to a house?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Me.Close()
            Else
                MessageBox.Show("System error1!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        ElseIf Not isEmpty Then
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

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Me.Close()
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