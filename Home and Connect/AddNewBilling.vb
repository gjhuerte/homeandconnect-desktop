Imports MySql.Data.MySqlClient
Public Class AddNewBilling
    Private _id As Integer = 0
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If buttonClick() Then
        Else
            MessageBox.Show("No rental information found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Function buttonClick() As Boolean
        If executeQuery("SELECT * FROM tbl_rent WHERE house_id = '" & MetroTextBox1.Text & "'") Then
            connection.ConnectionString = sqlinfo
            Try
                connection.Open()
                command = New MySqlCommand("SELECT * from rental_v WHERE 
                        house_id = '" & MetroTextBox1.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    MetroLabel2.Text = reader.GetString("Name")
                End If
                connection.Close()
                setVisibility(True)
                Return True
            Catch ex As Exception
                Return False
                MessageBox.Show(ex.Message)
            End Try
        Else
            Return False
        End If
    End Function
    Private Sub MetroTextBox1_Enter(sender As Object, e As EventArgs) Handles MetroTextBox1.Enter
        setVisibility(False)
    End Sub

    Sub setVisibility(value As Boolean)
        MetroPanel3.Visible = value
        MetroPanel2.Visible = value
        MetroPanel4.Visible = value
        MetroButton2.Visible = value
        MetroButton3.Visible = value
    End Sub
    Private Sub MetroToggle1_MouseClick(sender As Object, e As MouseEventArgs) Handles MetroToggle1.MouseClick
        Dim bool As Boolean = True
        If Not MetroToggle1.Checked Then
            bool = False
        End If
        MetroDateTime2.Enabled = bool
        MetroDateTime3.Enabled = bool
        MetroTextBox3.Enabled = bool
        MetroTextBox4.Enabled = bool
    End Sub

    Private Sub MetroToggle2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroToggle2.CheckedChanged
        Dim bool As Boolean = True
        If Not MetroToggle2.Checked Then
            bool = False
        End If
        MetroDateTime5.Enabled = bool
        MetroDateTime4.Enabled = bool
        MetroTextBox6.Enabled = bool
        MetroTextBox5.Enabled = bool
    End Sub

    Private Sub MetroTextBox3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox6.Validating, MetroTextBox5.Validating, MetroTextBox4.Validating, MetroTextBox3.Validating, MetroTextBox2.Validating
        If Not TryParse(sender.text) Then
            sender.text = 0
        End If
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        If MetroButton2.Text = "Bill" Then
            executeQuery("call sproc_insertbillinfo(
            '" & setDateFormat(MetroDateTime2, "yyyyMMdd", "/", "\") & "',
            '" & setDateFormat(MetroDateTime2, "yyyyMMdd", "/", "\") & "',
            " & MetroTextBox3.Text & "," & MetroTextBox4.Text & ",
            '" & setDateFormat(MetroDateTime5, "yyyyMMdd", "/", "\") & "',
            '" & setDateFormat(MetroDateTime4, "yyyyMMdd", "/", "\") & "',
            " & MetroTextBox6.Text & "," & MetroTextBox5.Text & ",
            '" & MetroTextBox2.Text & "','" & setDateFormat(MetroDateTime1, "yyyyMMdd", "/", "\") & "',
            '" & MetroTextBox1.Text & "')")
            MessageBox.Show("Success in creating bill!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            executeQuery("call sproc_updatebillinfo(
            '" & setDateFormat(MetroDateTime2, "yyyyMMdd", "/", "\") & "',
            '" & setDateFormat(MetroDateTime3, "yyyyMMdd", "/", "\") & "',
            " & MetroTextBox3.Text & "," & MetroTextBox4.Text & ",
            '" & setDateFormat(MetroDateTime5, "yyyyMMdd", "/", "\") & "',
            '" & setDateFormat(MetroDateTime4, "yyyyMMdd", "/", "\") & "',
            " & MetroTextBox6.Text & "," & MetroTextBox5.Text & ",
            '" & MetroTextBox2.Text & "','" & setDateFormat(MetroDateTime1, "yyyyMMdd", "/", "\") & "',
            '" & MetroTextBox1.Text & "','" & _id & "')")
            MessageBox.Show("Successfully updated!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Close()
    End Sub

    Public WriteOnly Property id() As Integer
        Set(value As Integer)
            _id = value
        End Set
    End Property
End Class