Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Public Class MainMenu
#Region "Clock"
    'starts the timer
    Private Sub MainMenu_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Timer1.Start()
        Timer2.Start()
    End Sub
    'timer information
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MetroLabel1.Text = DateTime.Now.ToLongDateString + " " + DateTime.Now.ToLongTimeString
    End Sub

#End Region

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
        Dim removetenant As New removeTenant
        removetenant.ShowDialog()
    End Sub

    Private Sub MetroTile8_Click(sender As Object, e As EventArgs) Handles MetroTile8.Click
        Dim addnewhouse As New addNewHouse
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
        Dim edithouseinfo As New editExistingHouse
        edithouseinfo.ShowDialog()
    End Sub

    Private Sub MetroTile6_Click(sender As Object, e As EventArgs) Handles MetroTile6.Click
        Dim deletehouseinfo As New deleteHouseInfo
        deletehouseinfo.ShowDialog()
    End Sub

    Private Sub MetroTile10_Click(sender As Object, e As EventArgs) Handles MetroTile10.Click
        Dim changehousestatus As New changeHouseStatus
        changehousestatus.ShowDialog()
    End Sub

    Private Sub MetroTile11_Click(sender As Object, e As EventArgs) Handles MetroTile11.Click
        Dim evict As New evictTenant
        evict.ShowDialog()
    End Sub

    Private Sub MetroTile13_Click(sender As Object, e As EventArgs) Handles MetroTile13.Click
        Dim houserent As New houseRent
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
        Dim transfer As New transferTenant
        transfer.ShowDialog()
    End Sub

    Private Sub MetroTile14_Click(sender As Object, e As EventArgs) Handles MetroTile14.Click
        Dim view As New viewHouseInformation
        view.ShowDialog()
    End Sub

    Private Sub MetroTile16_Click(sender As Object, e As EventArgs) Handles MetroTile16.Click
        Dim addbilling As New addNewBilling
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
        setTransactionTab
    End Sub

    Sub setTransactionTab()
        createTable("SELECT id AS 'ID',payer AS 'Payer', billingid AS 'Billing ID',
        date AS 'Transaction date',amount AS 'Transacted Amount',status AS 'Transaction Status' FROM tbl_transactionhistory ", MetroGrid9)
        createTable("SELECT * FROM billinginformation_v ", MetroGrid7)
    End Sub

    Private Sub MetroTile21_Click(sender As Object, e As EventArgs) Handles MetroTile21.Click
        Dim transaction As New transaction
        transaction.ShowDialog()
    End Sub

    Private Sub MetroTile20_Click(sender As Object, e As EventArgs) Handles MetroTile20.Click
        Dim edit As New transaction

    End Sub

    Private Sub MetroTile19_Click(sender As Object, e As EventArgs) Handles MetroTile19.Click
        Dim delete As New Form2
        delete.Text = "Delete a transaction"
        delete.MetroButton1.Text = "Delete"
    End Sub

    Private Sub MetroTile2_Click(sender As Object, e As EventArgs) Handles MetroTile2.Click

    End Sub
End Class