Imports MySql.Data.MySqlClient
Public Class FindTenant
    Dim _lname
    Dim _fname
    Dim _mname
    Dim _birthdate
    Dim _cellno
    Dim _email
    Dim _gender
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If MetroComboBox1.SelectedItem = "Name" Then
            isMultipleValues("select * from tenant_v WHERE lname like '%" & MetroTextBox1.Text & "' OR lname like '% " & MetroTextBox1.Text & " %' or lname like '% " & MetroTextBox1.Text & "'
                               or  ;")
        ElseIf MetroComboBox1.SelectedItem = "Email Address" Then
            isMultipleValues("select * from tenant_v WHERE lname like '%" & MetroTextBox1.Text & "' OR lname like '% " & MetroTextBox1.Text & " %' or lname like '% " & MetroTextBox1.Text & "'")
        ElseIf MetroComboBox1.SelectedItem = "ID" Then
        ElseIf MetroComboBox1.SelectedItem = "Cellphone Number" Then
        End If
    End Sub

    Function isMultipleValues(query) As Boolean
        If executeQuery(query) Then
            connection.ConnectionString = sqlinfo
            Try
                Dim x As Integer = 0
                connection.Open()
                command = New MySqlCommand(query, connection)
                reader = command.ExecuteReader
                While reader.Read
                    x = x + 1
                End While
                If x > 1 Then
                    MessageBox.Show("There are too many result to show! Please specify your information", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                If x = 1 Then
                    getAllData(query)
                End If
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("There are no available tenant on the information you provided!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return False
    End Function

    Sub getAllData(query)
        connection.ConnectionString = sqlinfo
        Try
            Dim x As Integer = 0
            connection.Open()
            command = New MySqlCommand(query, connection)
            reader = command.ExecuteReader
            If reader.Read Then
                MetroLabel2.Text = reader.GetString("lname")
                MetroLabel3.Text = reader.GetString("fname")
                MetroLabel6.Text = reader.GetString("mname")
                MetroLabel7.Text = reader.GetString("birthdate")
                MetroLabel10.Text = reader.GetString("email")
                MetroLabel12.Text = reader.GetString("cellno")
                MetroLabel14.Text = reader.GetString("gender")
            End If
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class