Imports MySql.Data.MySqlClient
Public Class RemoveTenant
    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("SELECT * FROM tbl_personalinfo WHERE id = '" & MetroTextBox6.Text & "'") Then
            Dim connection As MySqlConnection = New MySqlConnection
            Dim command As MySqlCommand
            Dim adapter As New MySqlDataAdapter
            Dim reader As MySqlDataReader
            Dim table As New DataTable
            Dim source As New BindingSource
            connection.ConnectionString = "server=localhost;userid=root;password=toor;database=houserentalsystem"
            Try
                connection.Open()
                command = New MySqlCommand("SELECT * FROM tbl_personalinfo WHERE id = '" & MetroTextBox6.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    MetroLabel7.Text = reader.GetString("lname")
                    MetroLabel8.Text = reader.GetString("fname")
                    MetroLabel9.Text = reader.GetString("mname")
                    MetroLabel10.Text = reader.GetString("birthdate")
                    MetroLabel11.Text = reader.GetString("email")
                    MetroLabel12.Text = reader.GetString("cellno")
                    If reader.GetString("usr_gender") = "M" Then
                        MetroLabel15.Text = "Male"
                    Else
                        MetroLabel15.Text = "Female"
                    End If
                End If
                connection.Close()
                MessageBox.Show("Tenant found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MetroButton2.Visible = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Tenant not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub MetroTextBox6_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox6.Validating
        MetroButton2.Visible = False
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Dim result = MessageBox.Show("This will delete of the tenants information and will also be evicted from his property permanently. Do you want to continue?", "Status",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            If executeQuery("DELETE FROM tbl_rent WHERE tenant_id = ' " & MetroTextBox6.Text & "'") Then
                MessageBox.Show("Tenant evicted from his rented house", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If executeQuery("DELETE FROM tbl_tenant WHERE personid = ' " & MetroTextBox6.Text & "'") Then
                    If executeQuery("DELETE FROM tbl_personalinfo WHERE id = ' " & MetroTextBox6.Text & "'") Then
                        executeQuery("alter table tbl_personalinfo auto_increment = 1")
                        MessageBox.Show("Tenants Information Successfully Deleted", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                End If
            End If
        End If
    End Sub
End Class