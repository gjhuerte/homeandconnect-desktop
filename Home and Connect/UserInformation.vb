Public Class UserInformation
    Public type = "Owner"
    Private Sub MetroTextBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox1.Validating
        If isNullOrEmpty(MetroTextBox1.Text) Then
            isTextBoxEmpty()
        ElseIf Not isValidSurName(MetroTextBox1.Text) Then
            MetroTextBox1.Text = ""
        Else
            MetroTextBox1.Text = UppercaseFirstLetter(MetroTextBox1.Text)
        End If
    End Sub

    Private Sub MetroTextBox2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox2.Validating
        If isNullOrEmpty(MetroTextBox2.Text) Then
            isTextBoxEmpty()
        ElseIf Not isValidFirstName(MetroTextBox2.Text) Then
            MessageBox.Show("Invalid Firstname!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MetroTextBox2.Text = ""
        Else
            MetroTextBox2.Text = UppercaseFirstLetter(MetroTextBox2.Text)
        End If
    End Sub

    Private Sub MetroTextBox3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox3.Validating
        If isNullOrEmpty(MetroTextBox3.Text) Then
            isTextBoxEmpty()
        ElseIf Not isValidFirstName(MetroTextBox3.Text) Then
            MessageBox.Show("Invalid Middlename!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MetroTextBox3.Text = ""
        Else
            MetroTextBox3.Text = UppercaseFirstLetter(MetroTextBox3.Text)
        End If
    End Sub

    Private Sub MetroTextBox4_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox4.Validating
        If isNullOrEmpty(MetroTextBox4.Text) Then
            isTextBoxEmpty()
        ElseIf Not isValidEmailAddress(MetroTextBox4.Text) Then
            MessageBox.Show("Invalid Email Address!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MetroTextBox4.Text = ""
        End If
    End Sub

    Private Sub MetroTextBox5_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox5.Validating
        If isNullOrEmpty(MetroTextBox5.Text) Then
            isTextBoxEmpty()
            'ElseIf Not validator.isValidPhoneNumber(MetroTextBox5.Text) Then
            'MessageBox.Show("Invalid Cellphone number!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MetroTextBox5.Text = ""
        End If
    End Sub

    Private Sub MetroTextBox6_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox7.Validating, MetroTextBox6.Validating
        If isNullOrEmpty(MetroTextBox6.Text) Then
            isTextBoxEmpty()
        ElseIf isNullOrEmpty(MetroTextBox6.Text) Then
            MessageBox.Show("Invalid Password!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MetroTextBox6.Text = ""
        End If
    End Sub

    Function isTextBoxEmpty() As Boolean
        If isNullOrEmpty(MetroTextBox1.Text) Then
            MetroLabel2.Visible = True
            Return True
        Else
            MetroLabel2.Visible = False
        End If
        If isNullOrEmpty(MetroTextBox2.Text) Then
            MetroLabel3.Visible = True
            Return True
        Else
            MetroLabel3.Visible = False
        End If
        If isNullOrEmpty(MetroTextBox3.Text) Then
            MetroLabel4.Visible = True
            Return True
        Else
            MetroLabel4.Visible = False
        End If
        If isNullOrEmpty(MetroTextBox4.Text) Then
            MetroLabel5.Visible = True
            Return True
        Else
            MetroLabel5.Visible = False
        End If
        If isNullOrEmpty(MetroTextBox5.Text) Then
            MetroLabel6.Visible = True
            Return True
        Else
            MetroLabel6.Visible = False
        End If

        If isNullOrEmpty(MetroTextBox6.Text) Then
            MetroLabel7.Visible = True
            Return True
        Else
            MetroLabel7.Visible = False
        End If
        If isNullOrEmpty(MetroTextBox8.Text) Then
            MetroLabel9.Visible = True
            Return True
        Else
            MetroLabel9.Visible = False
        End If
        Return False
    End Function

    Function isPasswordCorrect() As Boolean
        If MetroTextBox6.Text = MetroTextBox7.Text Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        isTextBoxEmpty()
        If MetroLabel2.Visible Or MetroLabel3.Visible Or MetroLabel4.Visible Or MetroLabel5.Visible Or MetroLabel6.Visible Or MetroLabel7.Visible Or MetroLabel9.Visible Then
            MetroLabel8.Visible = True
        Else
            MetroLabel8.Visible = False
        End If
    End Sub

    Private Sub AdminInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub MetroButton1_Click_1(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Dim email As String = MetroTextBox4.Text
        Dim cellno As String = MetroTextBox5.Text
            Dim bday = setDateFormat(MetroDateTime1, "yyyyMMdd", "/", "\")
            Dim gender As Char

            If MetroRadioButton1.Checked Then
                gender = "M"
            Else
                gender = "F"
            End If

        If isTextBoxEmpty() Then
            MessageBox.Show("Fill-up all the required fields before proceeding!",
                            "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If isPasswordCorrect() Then

                If MetroButton1.Text = "Add" Then
                    executeQuery("call sproc_insertuser('" & MetroTextBox1.Text &
                 "','" & MetroTextBox2.Text & "','" & MetroTextBox3.Text &
                 "','" & email & "','" & cellno &
                 "','" & bday & "','" & gender & "','" & MetroTextBox8.Text & "','" & MetroTextBox6.Text & "','" & type & "')")
                    MessageBox.Show("Account successfully created!", "Status",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    executeQuery("UPDATE tbl_personalinfo SET ")
                    executeQuery("UPDATE tbl_user SET")
                End If

                Timer1.Stop()
                Me.Close()
            Else
                    MessageBox.Show("Password not match!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MetroTextBox6.Text = ""
                MetroTextBox7.Text = ""
            End If
        End If
    End Sub

    Private Sub MetroTextBox8_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox8.Validating
        If isNullOrEmpty(MetroTextBox8.Text) Then
            MetroLabel9.Visible = True
        Else
            MetroLabel9.Visible = False
        End If
    End Sub

    Public WriteOnly Property _type() As Integer
        Set(value As Integer)
            type = value
        End Set
    End Property
End Class