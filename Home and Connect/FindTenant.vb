Imports MySql.Data.MySqlClient
Public Class FindTenant

    Public connection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public adapter As New MySqlDataAdapter
    Public reader As MySqlDataReader
    Public table As New DataTable
    Public source As New BindingSource
    Dim _lname
    Dim _fname
    Dim _mname
    Dim _birthdate
    Dim _cellno
    Dim _email
    Dim _gender
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If MetroComboBox1.SelectedItem = "Name" Then
            If Not isMultipleValues("select * from tenant_v where id = selectname_function('" & TextBox1.Text & "')") Then
                connection.Close()
                MessageBox.Show("Tenant found!")
                MetroPanel2.Visible = True
                getAllData("select * from tenant_v where id = selectname_function('" & TextBox1.Text & "')")
            End If
        ElseIf MetroComboBox1.SelectedItem = "Email Address" Then
            If Not isMultipleValues("select * from tenant_v WHERE email like '%" & TextBox1.Text & "' OR email like '% " & TextBox1.Text & " %' or email like '% " & TextBox1.Text & "'") Then
                connection.Close()
                MessageBox.Show("Tenant found!")
                MetroPanel2.Visible = True
                getAllData("select * from tenant_v WHERE email like '%" & TextBox1.Text & "' OR email like '% " & TextBox1.Text & " %' or email like '% " & TextBox1.Text & "'")
            End If
        ElseIf MetroComboBox1.SelectedItem = "ID" Then
            If Not isMultipleValues("select * from tenant_v WHERE id = '" & TextBox1.Text & "'") Then
                connection.Close()
                MessageBox.Show("Tenant found!")
                MetroPanel2.Visible = True
                getAllData("select * from tenant_v WHERE id = '" & TextBox1.Text & "'")
            End If
        ElseIf MetroComboBox1.SelectedItem = "Cellphone Number" Then
            If Not isMultipleValues("select * from tenant_v WHERE cellno = '" & TextBox1.Text & "'") Then
                connection.Close()
                MessageBox.Show("Tenant found!")
                MetroPanel2.Visible = True
                getAllData("select * from tenant_v WHERE cellno = '" & TextBox1.Text & "'")
            End If
        End If
    End Sub

    Function isMultipleValues(query) As Boolean
        If executeQuery(query) Then
            connection.ConnectionString = sqlinfo
            Try
                Dim x As Integer = 0
                connection.Open()
                Command = New MySqlCommand(query, connection)
                reader = Command.ExecuteReader
                While reader.Read
                    x = x + 1
                End While
                If x > 1 Then
                    MessageBox.Show("There are too many result to show! Please specify your information", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return True
                End If
                If x = 1 Then
                    Return False
                End If
                If x = 0 Then
                    MessageBox.Show("No result!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return True
                End If
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("There are no available or too many result on the information you provided!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return True
    End Function

    Sub getAllData(query)
        Try
            connection.ConnectionString = sqlinfo
            Dim x As Integer = 0
            connection.Open()
            Command = New MySqlCommand(query, connection)
            reader = Command.ExecuteReader
            If reader.Read Then
                MetroLabel4.Text = reader.GetString("lname")
                MetroLabel5.Text = reader.GetString("fname")
                MetroLabel8.Text = reader.GetString("mname")
                MetroLabel9.Text = reader.GetString("birthdate")
                MetroLabel11.Text = reader.GetString("email")
                MetroLabel13.Text = reader.GetString("cellno")
                MetroLabel15.Text = reader.GetString("gender")
            End If
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        MetroPanel2.Visible = False
    End Sub
End Class