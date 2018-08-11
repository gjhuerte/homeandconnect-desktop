Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CrystalReport
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        'Dim transaction As New TransactionReport
        'CrystalReportViewer1.ReportSource = transaction
        'CrystalReportViewer1.Refresh()
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        Dim connectionString As String
        Dim sql As String

        connectionString = "data source=localhost; _
        initial catalog=houserentalsystem;user id=r3+oot;password=toor;"
        cnn = New SqlConnection(connectionString)
        cnn.Open()
        sql = "Select * from tbl_transactionhistory"
        Dim dscmd As New SqlDataAdapter(sql, cnn)
        dscmd.Fill(ds, "tbl_transactionhistory")
        MsgBox(ds.Tables(1).Rows.Count)
        cnn.Close()

        Dim objRpt As New transactionreport
        objRpt.SetDataSource(ds.Tables(1))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub


End Class