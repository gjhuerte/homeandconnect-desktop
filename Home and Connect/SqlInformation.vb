Imports MySql.Data.MySqlClient
Module SqlInformation
    Public connection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public adapter As New MySqlDataAdapter
    Public reader As MySqlDataReader
    Public table As New DataTable
    Public source As New BindingSource
    Public sqlinfo As String = "server=localhost;userid=root;password=toor;database=houserentalsystem"
End Module
