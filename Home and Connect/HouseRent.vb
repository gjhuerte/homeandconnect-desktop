Public Class HouseRent
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If isNullOrEmpty(MetroTextBox1.Text) Then
            MessageBox.Show("Need to type the tenant ID to proceed!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf executeQuery("SELECT * FROM tbl_personalinfo WHERE id = '" & MetroTextBox1.Text & "'") Then
            MetroPanel2.Visible = True
            MetroTextBox1.Enabled = False
            MetroButton1.Enabled = False
        Else
            MessageBox.Show("Tenant not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        If isNullOrEmpty(MetroTextBox2.Text) Then
            MessageBox.Show("Need to type the house ID to proceed!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf executeQuery("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox2.Text & "' AND status = 'F'") Then
            MetroButton3.Visible = True
            MetroTextBox2.Enabled = False
            MetroTextBox3.Visible = True
            MetroButton2.Enabled = False
        Else
            MessageBox.Show("House not found or already rented!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        If isNullOrEmpty(MetroTextBox3.Text) Then
            MessageBox.Show("Need an advance payment to proceed!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not TryParse(MetroTextBox3.Text) Then
            MessageBox.Show("Must be a number greater than zero!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf executeQuery("call sproc_rent('" & MetroTextBox1.Text & "','" & MetroTextBox2.Text & "'
            , NOW(),'" & MetroComboBox1.SelectedItem & "','" & MetroTextBox3.Text & "')") Then
            MessageBox.Show("House successfully rented!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Theres an error in renting!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class