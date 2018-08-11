Public Class TransferTenant
    Private Sub MetroTextBox1_Enter(sender As Object, e As EventArgs) Handles MetroTextBox1.Enter, MetroTextBox2.Enter
        MetroPanel1.Visible = False
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If isNullOrEmpty(MetroTextBox1.Text) Or isNullOrEmpty(MetroTextBox2.Text) Then
            MessageBox.Show("The system needs both tenant and house ID in order to search!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf executeQuery("SELECT * FROM tbl_rent WHERE tenant_id = '" & MetroTextBox1.Text & "' 
                AND house_id = '" & MetroTextBox2.Text & "' ") Then
            MessageBox.Show("Rental Information found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MetroPanel1.Visible = True
        Else
            MessageBox.Show("No rental information available!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        If isNullOrEmpty(MetroTextBox3.Text) Then
            MessageBox.Show("New House ID must not be empty!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not executeQuery("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox3.Text & "' ") Then
            MessageBox.Show("There is no house information found on the id ", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf MetroTextBox2.Text = MetroTextBox3.Text Then
            MessageBox.Show("The house you transferred is the same as the house you came from. Please change it!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf executeQuery("UPDATE tbl_rent SET house_id = '" & MetroTextBox3.Text & "' WHERE tenant_id = '" & MetroTextBox1.Text & "' 
                AND house_id = '" & MetroTextBox2.Text & "' ") Then
            executeQuery("UPDATE tbl_housedesc SET status = 'F'  WHERE id = '" & MetroTextBox2.Text & "' ")
            executeQuery("UPDATE tbl_housedesc SET status = 'R'  WHERE id = '" & MetroTextBox3.Text & "' ")
            MessageBox.Show("Tenant successfully transferred!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Error! Tenant not transferred!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class