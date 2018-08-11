Public Class DeleteHouseInfo
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox1.Text & "'") Then
            Dim result = MessageBox.Show("This will permanently delete all information about the house. Do you want
                          to continue?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                If executeQuery("call sproc_deleterentalinfo('" & MetroTextBox1.Text & "')") Then
                    MessageBox.Show("House information successfully deleted!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("House not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class