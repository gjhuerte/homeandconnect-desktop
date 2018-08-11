Imports System.Data.SqlClient
Imports MySql.Data
Imports MySql.Data.MySqlClient
Module Commands
    'try converting to integer
    Function TryParse(input) As Boolean
        Try
            Dim sample As Integer = input
            sample = Convert.ToDecimal(sample)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    'creates table 
    Public Function createTable(query, datagridview) As Boolean
        Dim connection As MySqlConnection = New MySqlConnection
        Dim command As MySqlCommand
        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim source As New BindingSource
        connection.ConnectionString = "server=localhost;userid=root;password=toor;database=houserentalsystem"
        Try
            connection.Open()
            command = New MySqlCommand(query, connection)
            adapter.SelectCommand = command
            adapter.Fill(table)
            source.DataSource = table
            datagridview.datasource = source
            adapter.Update(table)
            connection.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return False
    End Function
    'execute the queries
    Public Function executeQuery(query) As Boolean
        Dim connection As MySqlConnection = New MySqlConnection
        Dim command As MySqlCommand
        Dim reader As MySqlDataReader
        connection.ConnectionString = "server=localhost;userid=root;
            password=toor;database=houserentalsystem"
        Try
            connection.Open()
            command = New MySqlCommand(query, connection)
            reader = command.ExecuteReader
            If query.subString(0, 6) = "UPDATE" Or query.subString(0, 6) = "INSERT" Or query.subString(0, 6) = "DELETE" Then
                Return True
            ElseIf reader.Read Then
                Return True
            End If
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function
    Public Function executeCountQuery(query) As Integer
        Dim connection As MySqlConnection = New MySqlConnection
        Dim command As MySqlCommand
        Dim reader As MySqlDataReader
        connection.ConnectionString = "server=localhost;userid=root;
            password=toor;database=houserentalsystem"
        Try
            connection.Open()
            command = New MySqlCommand(query, connection)
            reader = command.ExecuteReader
            If query.subString(0, 6) = "UPDATE" Or query.subString(0, 6) = "INSERT" Or query.subString(0, 6) = "DELETE" Then
                Return CType(command.ExecuteScalar(), Int32)
            ElseIf reader.Read Then
                Return 0
            End If
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
        Return 0
    End Function
    'add items to a combobox
    Sub AddItemToComboBox(query As String, combobox As Object)
        Dim connection As MySqlConnection = New MySqlConnection
        Dim command As MySqlCommand
        Dim reader As MySqlDataReader
        connection.ConnectionString = "server=localhost;userid=root;
            password=toor;database=homeandconnect"
        Try
            connection.Open()
            command = New MySqlCommand(query, connection)
            reader = command.ExecuteReader
            combobox.items.clear()
            While reader.Read
                combobox.items.add(reader.GetString("bill_code"))
            End While
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'valid filename
    Public Function IsValidFileNameOrPath(ByVal name As String) As Boolean
        ' Determines if the name is Nothing.
        If name Is Nothing Then
            Return False
        End If
        ' Determines if there are bad characters in the name.
        For Each badChar As Char In System.IO.Path.GetInvalidPathChars
            If InStr(name, badChar) > 0 Then
                Return False
            End If
        Next
        ' The name passes basic validation.
        Return True
    End Function
    'Validates Email Address
    Public Function isValidEmailAddress(input) As Boolean
        Dim regEx As New System.Text.RegularExpressions.Regex("^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        If Not String.IsNullOrEmpty(input) Then
            If regEx.IsMatch(input) Then
                Return True
            Else
                Return False
            End If
        End If
        Return False
    End Function
    'valid phonenumber
    Public Function isValidPhoneNumber(strPhoneNum) As Boolean
        ''Create Reg Exp Pattern
        'Create Reg Ex Object
        Dim rePhone As New System.Text.RegularExpressions.Regex("^[1-9]\d{2}-[1-9]\d{2}-\d{4}$")
        'Something Typed In
        If Not String.IsNullOrEmpty(strPhoneNum) Then
            If rePhone.IsMatch(strPhoneNum) Then
                Return True
            End If
        End If
        Return False
    End Function
    'validate surname
    Public Function isValidSurName(input) As Boolean
        Dim reSurname As New System.Text.RegularExpressions.Regex("^[a-zA-Z\s]+$")
        If Not String.IsNullOrEmpty(input) Then
            'Not A Match
            For Each s As String In input.Split(" "c)
                If Not System.Text.RegularExpressions.Regex.Match(s, "^[a-z]*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Success Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function
    'validates firstname
    Public Function isValidFirstName(input) As Boolean
        If Not String.IsNullOrEmpty(input) Then
            'Not A Match
            For Each s As String In input.Split(" "c)
                If Not System.Text.RegularExpressions.Regex.Match(s, "^[a-z]*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Success Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function
    'validates if empty or null
    Public Function isNullOrEmpty(input) As Boolean
        If String.IsNullOrEmpty(input) Then
            Return True
        End If
        Return False
    End Function
    'uppercase first letter
    Function UppercaseFirstLetter(ByVal val As String) As String
        ' Test for nothing or empty.
        If String.IsNullOrEmpty(val) Then
            Return val
        End If
        Dim name = ""
        'Not A Match
        For Each s As String In val.Trim().Split(" "c)
            ' Convert to character array.
            Dim characters() As Char = s.ToLower().ToCharArray
            ' Uppercase first character.
            characters(0) = Char.ToUpper(characters(0))
            name = name + " " + characters
        Next
        ' Return new string.
        Return New String(Trim(name))
    End Function
    'file browser
    Function FileBrowse(title, dir, filter, index) As String
        Dim fd As OpenFileDialog = New OpenFileDialog()
        'fd.Title = "Image File"
        'fd.InitialDirectory = "C:\"
        'fd.Filter = "*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
        'fd.FilterIndex = 2
        ' fd.RestoreDirectory = True
        fd.Title = title
        fd.InitialDirectory = dir
        fd.Filter = filter
        fd.FilterIndex = index
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Return fd.FileName
            'MetroTextBox10.Text = fd.FileName
            'PictureBox1.Image = Image.FromFile(MetroTextBox10.Text)
        End If
        Return ""
    End Function

    Function setDateFormat(input As MetroFramework.Controls.MetroDateTime, timeformat As String,
    value1 As String, value2 As String) As String
        Return input.Value.Date.ToString(timeformat).Replace(value1, value2)
    End Function
End Module
