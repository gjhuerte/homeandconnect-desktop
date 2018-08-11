Imports MySql.Data.MySqlClient
Public Class changeHouseStatus
    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs) Handles MetroTextBox1.Click

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Dim status = ""
        If executeQuery("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox1.Text & "'") Then
            connection.ConnectionString = sqlinfo
            Try
                connection.Open()
                command = New MySqlCommand("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox1.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    status = reader.GetString("tbl_housedesc")
                End If

                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            If status = "R" Then
                MessageBox.Show("House still in lease! Remove the tenant before changing its status", "Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MetroTextBox1.Text = ""
            Else
                If status = "M" Then
                    MetroRadioButton1.Checked = True
                Else
                    MetroRadioButton3.Checked = True
                End If
                MetroPanel1.Visible = True
            End If
        Else
            MessageBox.Show("House not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MetroPanel1.Visible = False
        End If
    End Sub

    Private Sub MetroTextBox1_Enter(sender As Object, e As EventArgs) Handles MetroTextBox1.Enter
        MetroPanel1.Visible = False
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Dim status
        If MetroRadioButton1.Checked Then
            status = "M"
        Else
            status = "F"
        End If
        If executeQuery("UPDATE tbl_housedesc SET status = '' WHERE status = '" & status & "'") Then
            MessageBox.Show("House Updated!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub
End Class