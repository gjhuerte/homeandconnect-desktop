Imports MySql.Data.MySqlClient
Public Class Form2
    Dim transaction As New transaction
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If MetroButton1.Text = "Search" Then
            setDesign(MetroFramework.MetroColorStyle.Purple, "Edit Transaction Information", "Update", "Billing ID")
            setInfo()
            transaction.ShowDialog()
        Else
            If executeQuery("SELECT * FROM tbl_transactionhistory WHERE id = '" & MetroTextBox1.Text & "'") Then
                If executeQuery("DELETE FROM tbl_transactionhistory WHERE id = '" & MetroTextBox1.Text & "'") Then
                    MessageBox.Show("Deletion Success!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Transaction ID does not exist!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub setDesign(style, text, buttontext, label1text)
        transaction.MetroTextBox1.Style = style
        transaction.MetroTextBox2.Style = style
        transaction.MetroTextBox3.Style = style
        transaction.MetroTextBox4.Style = style
        transaction.MetroButton1.Style = style
        transaction.MetroButton2.Style = style
        transaction.MetroButton3.Style = style
        transaction.MetroRadioButton1.Style = style
        transaction.MetroRadioButton2.Style = style
        transaction.Text = text
        transaction.MetroButton2.Text = buttontext
        transaction.MetroTextBox1.Enabled = False
        transaction.MetroButton1.Enabled = False
        MetroLabel1.Text = label1text
    End Sub

    Sub setInfo()
        If executeQuery("SELECT * FROM tbl_transactionhistory WHERE id = '" & MetroTextBox1.Text & "'") Then
            Dim connection As MySqlConnection = New MySqlConnection
            Dim command As MySqlCommand
            Dim adapter As New MySqlDataAdapter
            Dim reader As MySqlDataReader
            Dim table As New DataTable
            Dim source As New BindingSource
            connection.ConnectionString = "server=localhost;userid=root;password=toor;database=houserentalsystem"
            Try
                connection.Open()
                command = New MySqlCommand("SELECT * FROM tbl_transactionhistory WHERE id = '" & MetroTextBox1.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    transaction.MetroTextBox1.Text = reader.GetString("billingid")
                    transaction.MetroTextBox2.Text = reader.GetString("payer")
                    transaction.MetroTextBox3.Text = reader.GetString("amount")
                    If reader.GetString("status") = "Full" Then
                        transaction.MetroRadioButton1.Checked = True
                    Else
                        transaction.MetroRadioButton2.Checked = True
                    End If
                End If
                    connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

End Class