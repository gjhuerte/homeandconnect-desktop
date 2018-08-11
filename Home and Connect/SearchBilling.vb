Imports MySql.Data.MySqlClient

Public Class SearchBilling
    Private Sub SearchBilling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createTable("SELECT Name, Address, `Billing ID`, `Rent Amount`,`Electric bill amount`, `Water bill amount`, 
        Total FROM billinginformation_v natural join rental_v", MetroGrid1)
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("SELECT * FROM tbl_billinginfo WHERE id = '" & MetroTextBox1.Text & "'") Then
            Dim connection As MySqlConnection = New MySqlConnection
            Dim command As MySqlCommand
            Dim adapter As New MySqlDataAdapter
            Dim reader As MySqlDataReader
            Dim table As New DataTable
            Dim source As New BindingSource
            connection.ConnectionString = "server=localhost;userid=root;password=toor;database=houserentalsystem"
            Dim amount = 0
            Dim total = 0
            Try
                connection.Open()
                command = New MySqlCommand("SELECT * FROM billinginformation_v WHERE id = '" & MetroTextBox1.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    MetroLabel11.Text = reader.GetString("Electric bill amount")
                    MetroLabel10.Text = reader.GetString("Water bill amount")
                    MetroLabel9.Text = reader.GetString("Rent Amount")
                End If
                connection.Close()
                connection.Open()
                command = New MySqlCommand("Select * FROM tbl_transactionhistory WHERE billingid = '" & MetroTextBox1.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    amount += reader.GetInt64("amount")

                End If
                MetroLabel8.Text = amount
                total = Val(MetroLabel9.Text) + Val(MetroLabel10.Text) + Val(MetroLabel11.Text)
                MetroLabel7.Text = total - amount
                If total > 0 Then
                    MetroButton2.Visible = True
                End If
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Billing information not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub MetroTextBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox1.Validating
        MetroButton2.Visible = True
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Dim transaction As New Transaction
        transaction.MetroTextBox1.Text = MetroTextBox1.Text
        transaction.MetroButton1.Visible = False
        transaction.MetroTextBox1.ReadOnly = True
        transaction.search()
        transaction.ShowDialog()
    End Sub
End Class