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
        setChart()
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
        createTable("SELECT tenant_id AS 'Tenant ID',CONCAT(lname , ', ',fname,' ',mname) AS 'Name', tbl_housedesc.id 
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
        If Not executeQuery("SELECT * FROM tbl_tenant") Then
            MessageBox.Show("You need to have a tenant before you can rent a property!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Not executeQuery("SELECT * FROM tbl_housedesc") Then
                MessageBox.Show("You need to establish a house before renting!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub MetroTile12_Click(sender As Object, e As EventArgs) Handles MetroTile12.Click
        Dim transfer As New TransferTenant
        transfer.ShowDialog()
    End Sub

    Private Sub MetroTile14_Click(sender As Object, e As EventArgs) Handles MetroTile14.Click
        Dim find As New Form1
        find.Text = "House ID"
        find.MetroLabel1.Text = "Enter House ID"
        find.MetroTextBox1.PromptText = "House ID"
        find.ShowDialog()
    End Sub

    Private Sub MetroTile16_Click(sender As Object, e As EventArgs) Handles MetroTile16.Click
        Dim addbilling As New AddNewBilling
        addbilling.ShowDialog()
    End Sub

    Sub refreshtable()
        If TabPage7.Visible Then
            setHouseTable()
        End If
        If TabPage3.Visible Then
                setRentTable()
            End If
        If TabPage2.Visible Then
            setTenantTable()
        End If
        If TabPage4.Visible Then
            setBillingTable()
        End If
        If TabPage5.Visible Then
            setTransactionTab()
        End If
        If TabPage6.Visible Then
            setDashboardTable()
        End If
    End Sub
    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        setBillingTable()
        If Not executeQuery("SELECT * FROM tbl_rent") Then
            MessageBox.Show("You need to have atleast one tenant renting a property before you can bill!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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
        If Not executeQuery("SELECT * FROM tbl_billinginfo") Then
            MessageBox.Show("Bill first a tenant before transacting!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub setTransactionTab()
        Dim order
        If MetroRadioButton1.Checked Then
            order = "asc"
        Else
            order = "desc"
        End If
        Dim type
        If MetroComboBox1.SelectedItem = "ID" Then
            type = "id"
        ElseIf MetroComboBox1.SelectedItem = "Payer" Then
            type = "payer"
        ElseIf MetroComboBox1.SelectedItem = "Billing ID" Then
            type = "billingid"
        ElseIf MetroComboBox1.SelectedItem = "Amount" Then
            type = "amount"
        ElseIf MetroComboBox1.SelectedItem = "Date" Then
            type = "date"
        Else
            type = "id"
        End If
            createTable("SELECT id AS 'ID',payer AS 'Payer', billingid AS 'Billing ID',
        date AS 'Transaction date',amount AS 'Transacted Amount',status AS 'Transaction Status' FROM tbl_transactionhistory ORDER BY " & Type & " " & order & " ", MetroGrid9)
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
        Dim find As New Form1
        find.Text = "House ID"
        find.MetroLabel1.Text = "Enter House ID"
        find.MetroTextBox1.PromptText = "House ID"
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
        If executeQuery("SELECT * FROM tbl_billinginfo") Then
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
                    NotifyIcon1.BalloonTipText = "A bill has expired!"
                    NotifyIcon1.ShowBalloonTip(5000)
                End If
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Sub setChart()
        If executeQuery("SELECT * FROM tbl_transactionhistory") Then
            MetroLabel9.Visible = False
            Chart1.Series.Clear()
            Chart1.Titles.Add("Transaction")
            Dim s As New Series
            s.Name = "Money Growth (monthly)"
            'Change to a line raph.
            s.ChartType = SeriesChartType.Line
            'Create a new series and add data points to it.       
            Try
                Dim connection As MySqlConnection = New MySqlConnection
                Dim command As MySqlCommand
                Dim adapter As New MySqlDataAdapter
                Dim reader As MySqlDataReader
                Dim table As New DataTable
                Dim source As New BindingSource
                connection.ConnectionString = sqlinfo
                connection.Open()
                command = New MySqlCommand("select month(date) AS 'Month',amount AS 'Amount'  from tbl_transactionhistory GROUP BY month(date) order by date;", connection)
                reader = command.ExecuteReader
                If reader.Read Then
                    s.Points.AddXY(reader.GetString("Month"), reader.GetString("Amount"))
                End If
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            'Add the series to the Chart1 control.
            Chart1.Series.Add(s)
        Else
            MetroLabel9.Visible = True
        End If
    End Sub

    Private Sub MetroButton2_Click_1(sender As Object, e As EventArgs) Handles MetroButton2.Click
        If executeQuery("select lastnamefirst AS 'Name',r.`House ID`,b.`Billing ID`,Total from billinginformation_v b join rental_v r
            on b.`House ID` = r.`House ID` join nametypes_v n
            on r.`Tenant ID` = n.id WHERE b.`Billing ID` not in (select billingid from tbl_transactionhistory) AND n.id = '" & MetroTextBox1.Text & "';") Then
            MessageBox.Show("Billing information found!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            createTable("select lastnamefirst AS 'Name',r.`House ID`,b.`Billing ID`,Total from billinginformation_v b join rental_v r
            On b.`House ID` = r.`House ID` join nametypes_v n
            on r.`Tenant ID` = n.id WHERE b.`Billing ID` not in (select billingid from tbl_transactionhistory) AND n.id = '" & MetroTextBox1.Text & "';", MetroGrid11)
        Else
            MessageBox.Show("No unpaid billing information found on that ID", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub MetroTile27_Click(sender As Object, e As EventArgs) Handles MetroTile27.Click
        Dim report As New CrystalReport
        report.ShowDialog()
    End Sub

    Private Sub MetroTile28_Click(sender As Object, e As EventArgs) Handles MetroTile28.Click
        Dim report As New CrystalReport
        report.ShowDialog()
    End Sub

    Private Sub MetroTile29_Click(sender As Object, e As EventArgs) Handles MetroTile29.Click
        Dim report As New CrystalReport
        report.ShowDialog()
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Dim report As New CrystalReport
        report.ShowDialog()
    End Sub

    Private Sub MetroTile26_Click(sender As Object, e As EventArgs) Handles MetroTile26.Click
        Dim form As New Form4
        form.MetroButton1.Text = "Delete"
        form.Show()
    End Sub

    Private Sub MetroTile24_Click(sender As Object, e As EventArgs) Handles MetroTile24.Click
        Dim form As New Form
        form.Show()
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        Dim searchbilling As New SearchBilling
        searchbilling.ShowDialog()
    End Sub
End Class