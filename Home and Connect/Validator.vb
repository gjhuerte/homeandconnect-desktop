Public Class Validator
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
        For Each s As String In val.Split(" "c)
            ' Convert to character array.
            Dim characters() As Char = s.ToLower().ToCharArray
            ' Uppercase first character.
            characters(0) = Char.ToUpper(characters(0))
            name = name + " " + characters
        Next
        ' Return new string.
        Return New String(Trim(name))
    End Function
End Class
