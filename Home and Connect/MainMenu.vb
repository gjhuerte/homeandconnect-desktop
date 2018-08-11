Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms.DataVisualization.Charting

Public Class MainMenu
#Region "Clock"
    'starts the timer
    Private Sub MainMenu_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        notifyIfBillingIsExpired()
        Timer1.Start()
        Timer2.Start()
    End Sub
    'timer information
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MetroLabel1.Text = DateTime.Now.ToLongDateString + " " + DateTime.Now.ToLongTimeString
    End Sub

#End Region
    Private userinfo
    Private Sub MetroTile5_Click(sender As Object, e As EventArgs) Handles MetroTile5.Click
        Dim addnewtenant As New AddNewTenant
        addnewtenant.ShowDialog()
        setTenantTable()
    End Sub

    Private Sub MetroTile3_Click(sender As Object, e As EventArgs) Handles MetroTile3.Click
        Dim edittenant As New EditTenant
        edittenant.ShowDialog()
        setTenantTable()
    End Sub

    Sub setTenantTable()
        createTable("SELECT tbl_personalinfo.id as 'ID', lname AS 'Last name', fname AS 'First name', 
                    mname AS 'Middle name',	DATE_FORMAT(birthdate, '%M %d %Y') AS 'Birthdate',
                    email AS 'Email', cellno AS 'Cellphone Number', 
                    CASE gender WHEN 'M' THEN 'Male' WHEN 'F' THEN 'Female' END AS 'Gender' FROM tbl_personalinfo
                    JOIN tbl_tenant ON personid = id", MetroGrid1)
    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        setTenantTable()
    End Sub

    Private Sub MetroTile4_Click(sender As Object, e As EventArgs) Handles MetroTile4.Click
        Dim removetenant As New RemoveTenant
        removetenant.ShowDialog()
    End Sub

    Private Sub MetroTile8_Click(sender As Object, e As EventArgs) Handles MetroTile8.Click
        Dim addnewhouse As New AddNewHouse
        addnewhouse.ShowDialog()
    End Sub

    Private Sub TabPage7_Enter(sender As Object, e As EventArgs) Handles TabPage7.Enter
        setHouseTable()
    End Sub

    Sub setHouseTable()
        createTable("SELECT id as 'ID', bedroomno AS 'No of Bedroom',kitchenno AS 'No of Kitchen',
                    bathroomno AS 'No of Bathroom',livingroomno AS 'No of living room', 
                    toiletno AS 'No of Toilet',terraceno AS 'No of Terrace',address AS 'Address',status AS 'status'
                    FROM tbl_housedesc", MetroGrid2)
    End Sub

    Private Sub MetroTile7_Click(sender As Object, e As EventArgs) Handles MetroTile7.Click
        Dim edithouseinfo As New EditExistingHouse
        edithouseinfo.ShowDialog()
    End Sub

    Private Sub MetroTile6_Click(sender As Object, e As EventArgs) Handles MetroTile6.Click
        Dim deletehouseinfo As New DeleteHouseInfo
        deletehouseinfo.ShowDialog()
    End Sub

    Private Sub MetroTile10_Click(sender As Object, e As EventArgs) Handles MetroTile10.Click
        Dim changehousestatus As New changeHouseStatus
        changehousestatus.ShowDialog()
    End Sub

    Private Sub MetroTile11_Click(sender As Object, e As EventArgs) Handles MetroTile11.Click
        Dim evict As New EvictTenant
        evict.ShowDialog()
    End Sub

    Private Sub MetroTile13_Click(sender As Object, e As EventArgs) Handles MetroTile13.Click
        Dim houserent As New HouseRent
        houserent.ShowDialog()
    End Sub

    Sub setRentTable()
        createTable("SELECT CONCAT(lname , ', ',fname,' ',mname) AS 'Name', tbl_housedesc.id 
                    AS 'House ID', DATE_FORMAT(rent_day, '%M %d %Y') AS 'Rent Day ',paymenttype AS 
                    'Payment type', advancepayment AS 'Advanced Payment'
                    FROM tbl_rent JOIN tbl_tenant ON personid = tenant_id 
                    JOIN tbl_personalinfo ON personid = tbl_personalinfo.id 
                    JOIN tbl_housedesc ON tbl_housedesc.id = house_id ", MetroGrid4)
        createTable("SELECT tbl_personalinfo.id as 'ID', lname AS 'Last name', fname AS 'First name', 
                    mname AS 'Middle name' FROM tbl_personalinfo JOIN tbl_tenant ON personid = id", MetroGrid5)
        createTable("SELECT id as 'ID',address AS 'Address'
                    FROM tbl_housedesc WHERE status = 'F'", MetroGrid3)
    End Sub

    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        setRentTable()
    End Sub

    Private Sub MetroTile12_Click(sender As Object, e As EventArgs) Handles MetroTile12.Click
        Dim transfer As New TransferTenant
        transfer.ShowDialog()
    End Sub

    Private Sub MetroTile14_Click(sender As Object, e As EventArgs) Handles MetroTile14.Click
        Dim view As New ViewHouseInformation
        view.ShowDialog()
    End Sub

    Private Sub MetroTile16_Click(sender As Object, e As EventArgs) Handles MetroTile16.Click
        Dim addbilling As New AddNewBilling
        addbilling.ShowDialog()
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        refreshtable()
    End Sub

    Sub refreshtable()
        setHouseTable()
        setRentTable()
        setTenantTable()
        setBillingTable()
        setDashboardTable()
    End Sub
    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        setBillingTable()
    End Sub

    Sub setBillingTable()
        createTable("SELECT * FROM billinginformation_v ", MetroGrid6)
        createTable("SELECT * FROM rental_v", MetroGrid8)
    End Sub

    Private Sub MetroTile17_Click(sender As Object, e As EventArgs) Handles MetroTile17.Click
        Dim form As New Form1
        form.ShowDialog()
    End Sub

    Private Sub MetroTile18_Click(sender As Object, e As EventArgs) Handles MetroTile18.Click
        Dim form As New Form1
        form.Text = "Delete Billing Information"
        form.MetroLabel1.Text = "Enter the Billing ID for deletion"
        form.MetroButton1.Text = "Delete"
        form.ShowDialog()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        refreshtable()
    End Sub

    Private Sub TabPage5_Enter(sender As Object, e As EventArgs) Handles TabPage5.Enter
        setTransactionTab()
    End Sub

    Sub setTransactionTab()
        createTable("SELECT id AS 'ID',payer AS 'Payer', billingid AS 'Billing ID',
        date AS 'Transaction date',amount AS 'Transacted Amount',status AS 'Transaction Status' FROM tbl_transactionhistory ", MetroGrid9)
        createTable("SELECT * FROM billinginformation_v ", MetroGrid7)
    End Sub

    Private Sub MetroTile21_Click(sender As Object, e As EventArgs) Handles MetroTile21.Click
        Dim transaction As New Transaction
        transaction.ShowDialog()
    End Sub

    Private Sub MetroTile20_Click(sender As Object, e As EventArgs) Handles MetroTile20.Click
        Dim edit As New Transaction
        edit.ShowDialog()
    End Sub

    Private Sub MetroTile19_Click(sender As Object, e As EventArgs) Handles MetroTile19.Click
        Dim delete As New Form2
        delete.Text = "Delete a transaction"
        delete.MetroButton1.Text = "Delete"
        delete.ShowDialog()
    End Sub

    Private Sub MetroTile2_Click(sender As Object, e As EventArgs) Handles MetroTile2.Click
        Dim findtenant As New FindTenant
        findtenant.ShowDialog()
    End Sub

    Private Sub MetroTile9_Click(sender As Object, e As EventArgs) Handles MetroTile9.Click
        Dim find As New AddNewHouse
        find.ShowDialog()
    End Sub

    Private Sub MetroTile23_Click(sender As Object, e As EventArgs) Handles MetroTile23.Click
        Dim messaging As New MessageForm
        messaging.ShowDialog()
    End Sub

    Public WriteOnly Property id() As Integer
        Set(value As Integer)
            userinfo = value
        End Set
    End Property


    Private Sub TabPage6_Enter(sender As Object, e As EventArgs) Handles TabPage6.Enter
        setDashboardTable()
    End Sub

    Sub setDashboardTable()
        createTable("SELECT username AS 'User', login AS 'Login time', 
        logout AS 'Logout time' FROM tbl_userlog", MetroGrid10)
        createTable("SELECT Name, `House Address`,Total,`Rent Due date` AS 'Due date' from billinginformation_v join rental_v
        ON billinginformation_v.`House ID` = rental_v.`House ID`
        join tenant_v ON id = `Tenant ID` WHERE `Billing ID` not in (select billingid from tbl_transactionhistory)  ;", MetroGrid12)
        createTable("SELECT payer AS 'Payer', Total AS ' Total Billed Amount', 
        amount AS 'Amount payed', date AS 'Transacted Date', status AS 'Status'
        FROM tbl_transactionhistory NATURAL JOIN billinginformation_v ORDER BY date;", MetroGrid13)

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs)
        createTable("call sproc_tenantbilllist('" & MetroTextBox1.Text & "')", MetroGrid11)
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs)
        CrystalReport.Show()
    End Sub

    Private Sub MetroTile25_Click(sender As Object, e As EventArgs) Handles MetroTile25.Click
        Dim userinfo As New UserInformation
        userinfo.type = "User"
        userinfo.ShowDialog()
    End Sub

    Sub notifyIfBillingIsExpired()
        Try
            Dim connection As MySqlConnection = New MySqlConnection
            Dim command As MySqlCommand
            Dim adapter As New MySqlDataAdapter
            Dim reader As MySqlDataReader
            Dim table As New DataTable
            Dim source As New BindingSource
            connection.ConnectionString = sqlinfo
            connection.Open()
            command = New MySqlCommand("SELECT * FROM billinginformation_v WHERE `Rent Due date` < now() or 
            `Electric bill due date` < now() or `Water bill due date` < now(); ", connection)
            reader = command.ExecuteReader
            If reader.Read Then
                NotifyIcon1.BalloonTipText = "A bill has expired! Open the system to view!"
                NotifyIcon1.ShowBalloonTip(5000)
            End If
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub setChart()
        Chart1.Series.Clear()
        Chart1.Titles.Add("Demo")
        'Create a new series and add data points to it.
        Dim s As New Series
        s.Name = "aline"
        'Change to a line raph.
        s.ChartType = SeriesChartType.Line
        s.Points.AddXY("1990", 27)
        s.Points.AddXY("1991", 15)
        s.Points.AddXY("1992", 17)
        'Add the series to the Chart1 control.
        Chart1.Series.Add(s)
    End Sub
End Class