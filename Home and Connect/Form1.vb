Imports MySql.Data.MySqlClient
Public Class Form1
    Dim editHouse As New AddNewBilling
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If MetroLabel1.Text = "Enter House ID" Then
            If executeQuery("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox1.Text & "'") Then
                Dim edit As New EditExistingHouse
                edit.setHouseDesign("SELECT * FROM tbl_housedesc WHERE id = '" & MetroTextBox1.Text & "'")
                edit.MetroTextBox3.Enabled = False
                edit.MetroTextBox4.Enabled = False
                edit.MetroTextBox5.Enabled = False
                edit.MetroTextBox6.Enabled = False
                edit.MetroTextBox7.Enabled = False
                edit.MetroTextBox8.Enabled = False
                edit.MetroTextBox2.Enabled = False
                edit.MetroTextBox9.Enabled = False
                edit.MetroTextBox1.Enabled = False
                edit.MetroButton1.Visible = False
                edit.MetroButton4.Visible = False
                edit.MetroButton3.Visible = False
                edit.MetroButton2.Visible = False
                edit.MetroPanel1.Visible = True
                Me.Close()
                edit.ShowDialog()
            Else
                MessageBox.Show("House Information not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        ElseIf MetroLabel1.Text = "Enter Billing ID below" Then
            setData()
        Else
            If executeQuery(" ThenSelect * FROM tbl_billinginfo WHERE id = '" & MetroTextBox1.Text & "'") Then
                executeQuery("call deleteBillingInfo('" & MetroTextBox1.Text & "')")
                MessageBox.Show("Successfully deleted billing information", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Billing ID not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub displayChange()
        editHouse.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroToggle1.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroToggle2.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroButton1.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroButton2.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroButton3.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroButton2.Text = "Update"
        editHouse.MetroTextBox1.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroTextBox2.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroTextBox3.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroTextBox4.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroTextBox5.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.MetroTextBox6.Style = MetroFramework.MetroColorStyle.Purple
        editHouse.buttonClick()
        editHouse.MetroPanel4.Visible = True
        editHouse.MetroPanel3.Visible = True
        editHouse.MetroPanel2.Visible = True
        editHouse.MetroPanel1.Visible = True
        editHouse.MetroTextBox1.Enabled = False
        editHouse.MetroButton1.Enabled = False
        editHouse.MetroButton2.Visible = True
        editHouse.MetroButton3.Visible = True
    End Sub

    Sub setData()
        If executeQuery("SELECT * FROM tbl_billinginfo WHERE id = '" & MetroTextBox1.Text & "'") Then
            Dim connection As MySqlConnection = New MySqlConnection
            Dim command As MySqlCommand
            Dim adapter As New MySqlDataAdapter
            Dim reader As MySqlDataReader
            Dim table As New DataTable
            Dim source As New BindingSource
            connection.ConnectionString = "server=localhost;userid=root;password=toor;database=houserentalsystem"
            Try
                connection.Open()
                command = New MySqlCommand("SELECT * FROM billinginformation_v NATURAL JOIN tbl_billinginfo  WHERE id = '" & MetroTextBox1.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    displayChange()
                    editHouse.MetroTextBox1.Text = reader.GetString("House ID")
                    editHouse.Text = "Edit Billing information"
                    editHouse.MetroDateTime1.Value = reader.GetString("Rent Due date")
                    editHouse.MetroDateTime2.Value = reader.GetString("Electric bill date")
                    editHouse.MetroDateTime3.Value = reader.GetString("Electric bill due date")
                    editHouse.MetroDateTime4.Value = reader.GetString("water bill due date")
                    editHouse.MetroDateTime5.Value = reader.GetString("water bill date")
                    editHouse.MetroTextBox2.Text = reader.GetString("Rent Amount")
                    editHouse.MetroTextBox4.Text = reader.GetString("Electric bill amount")
                    editHouse.MetroTextBox5.Text = reader.GetString("Water bill amount")
                    editHouse.MetroTextBox3.Text = reader.GetString("Total(kwh)")
                    editHouse.MetroTextBox6.Text = reader.GetString("Water bill consumption")
                    editHouse.id = MetroTextBox1.Text
                End If
                connection.Close()
                connection.Open()
                command = New MySqlCommand("SELECT CONCAT(tbl_personalinfo.lname , ', ' , tbl_personalinfo.fname 
                        , ' ' , tbl_personalinfo.mname) AS 'name'
                        FROM tbl_rent JOIN tbl_tenant ON tbl_rent.tenant_id = tbl_tenant.personid 
                        JOIN tbl_personalinfo ON tbl_personalinfo.id = tbl_rent.tenant_id WHERE 
                        house_id = '" & MetroTextBox1.Text & "'", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    editHouse.MetroLabel2.Text = reader.GetString("name")
                End If
                Me.Close()
                editHouse.ShowDialog()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Billing information not found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class