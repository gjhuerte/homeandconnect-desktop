Public Class EvictTenant
    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Dim output = "Information:" + Environment.NewLine
        If executeQuery("SELECT * FROM tbl_personalinfo WHERE id = '" & MetroTextBox1.Text & "'") Then
            output += "Tenants Information: ✓" + Environment.NewLine
            If executeQuery("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox2.Text & "'") Then
                output += "House Information: ✓" + Environment.NewLine
                If executeQuery("SELECT * FROM tbl_rent WHERE tenant_id = '" & MetroTextBox1.Text & "' AND house_id = '" & MetroTextBox2.Text & "'") Then
                    output += "Rent Information: ✓" + Environment.NewLine
                    MetroButton1.Visible = True
                Else
                    output += "Rent Information: ✘" + Environment.NewLine
                End If
            Else
                output += "House Information: ✘" + Environment.NewLine
            End If
        Else
            output += "Tenants Information: ✘" + Environment.NewLine
        End If
        MessageBox.Show(output, "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If executeQuery("DELETE FROM tbl_rent WHERE tenant_id = '" & MetroTextBox1.Text & "' AND house_id = '" & MetroTextBox2.Text & "'") Then
            executeQuery("UPDATE tbl_housedesc SET status = 'F' WHERE id = '" & MetroTextBox2.Text & "'")
            MessageBox.Show("Tenant Successfully evicted from house!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub MetroTextBox1_Enter(sender As Object, e As EventArgs) Handles MetroTextBox1.Enter
        MetroButton1.Visible = False
    End Sub

    Private Sub MetroTextBox2_Enter(sender As Object, e As EventArgs) Handles MetroTextBox2.Enter
        MetroButton1.Visible = False
    End Sub
End Class