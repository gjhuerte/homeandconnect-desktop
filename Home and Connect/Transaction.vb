Imports MySql.Data.MySqlClient
Public Class Transaction
    Public connection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public adapter As New MySqlDataAdapter
    Public reader As MySqlDataReader
    Public table As New DataTable
    Public source As New BindingSource
    Public _id As Integer
    Private Sub MetroTextBox1_Enter(sender As Object, e As EventArgs) Handles MetroTextBox1.Enter
        MetroPanel1.Visible = False
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        search
    End Sub

    Sub search()
        If executeQuery("Select * from tbl_billinginfo where id = '" & MetroTextBox1.Text & "'") Then
            MessageBox.Show("Billing information found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MetroPanel1.Visible = True
        Else
            MessageBox.Show("Billing information not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Try
            connection.ConnectionString = sqlinfo
            connection.Open()
            command = New MySqlCommand("Select * from tbl_billinginfo where id = '" & MetroTextBox1.Text & "'", connection)
            reader = command.ExecuteReader
            If reader.Read Then
                MetroTextBox3.Text = reader.GetFloat("amount") - Val(MetroTextBox3.Text)
                If MetroTextBox3.Text < 0 Then
                    MetroTextBox3.ForeColor = Color.Red
                Else
                    MetroTextBox3.ForeColor = Color.Green
                    MetroButton2.Enabled = True
                End If
            End If
            connection.Close()
            MessageBox.Show("Successfully Updated!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MetroTextBox3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox3.Validating
        If Not TryParse(sender.text) Then
            sender.text = 0
        End If
        MetroButton2.Enabled = False
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Dim status As String = "Full"
        If MetroRadioButton2.Checked Then
            status = "Partial"
        End If
        If MetroButton2.Text = "Transact" Then
            If executeQuery("INSERT INTO tbl_transactionhistory(payer,billingid,date,amount,status) VALUES 
                 ('" & MetroTextBox2.Text & "','" & MetroTextBox1.Text & "',NOW()," & MetroTextBox3.Text & ",'" & status & "' ") Then
                MessageBox.Show("Transaction Completed! Do you want to print a receipt?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                MessageBox.Show("Error occurred while processing", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If executeQuery("UPDATE tbl_transactionhistory SET payer = '" & MetroTextBox2.Text & "',billingid = '" & MetroTextBox1.Text & "',
               amount = " & MetroTextBox3.Text & ",status = '" & status & "' WHERE id = '" & _id & "'") Then
                MessageBox.Show("Transaction Info updated", "Status", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Else
                MessageBox.Show("Error occurred while processing", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


    Public WriteOnly Property id() As Integer
        Set(value As Integer)
            _id = value
        End Set
    End Property
End Class