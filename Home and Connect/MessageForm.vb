Imports System.Management
Imports System.Threading
Public Class MessageForm
    Dim rcvdata As String = ""
    Function ModemsConnected() As String
        Dim modems As String = ""
        Try
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_POTSModem")
            For Each queryObj As ManagementObject In searcher.Get()
                If queryObj("Status") = "OK" Then
                    modems = modems & (queryObj("AttachedTo") & " - " & queryObj("Description") & "***")
                End If
            Next
        Catch ex As Exception

        End Try
        Return modems
    End Function

    Sub loadComPorts()
        Dim ports() As String
        MetroComboBox1.Items.Clear()
        ports = Split(ModemsConnected(), "***")
        For i As Integer = 0 To ports.Length - 2
            MetroComboBox1.Items.Add(ports(i))
        Next
    End Sub
    Private Sub MessageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadComPorts()
    End Sub

    Private Sub MetroComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles MetroComboBox1.SelectedValueChanged
        MetroLabel1.Text = Trim(Mid(MetroComboBox1.Text, 1, 5))
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            With SerialPort1
                .PortName = MetroLabel1.Text
                .BaudRate = 9600
                .Parity = IO.Ports.Parity.None
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                .Handshake = IO.Ports.Handshake.None
                .RtsEnable = True
                .ReceivedBytesThreshold = 1
                .NewLine = vbCr
                .ReadTimeout = 1000
                .Open()
            End With
            If SerialPort1.IsOpen Then
                MessageBox.Show("Connected!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Not Connected!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim datain As String = ""
        Dim numbytes As Integer = SerialPort1.BytesToRead
        For i As Integer = 1 To numbytes
            datain &= Chr(SerialPort1.ReadChar)
        Next
        test(datain)
    End Sub

    Private Sub test(ByVal indata As String)
        rcvdata &= indata
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            With SerialPort1
                .Write("at" & vbCrLf)
                Threading.Thread.Sleep(1000)
                For i As Integer = 0 To 25
                    MetroProgressSpinner1.Value = i
                Next
                .Write("at+cmgf=1" & vbCrLf)
                Threading.Thread.Sleep(1000)
                For i As Integer = 25 To 50
                    MetroProgressSpinner1.Value = i
                Next
                .Write("at+cmgs=" & Chr(34) & MetroTextBox1.Text & Chr(34) & vbCrLf)
                .Write(MetroTextBox2.Text & Chr(26))
                Threading.Thread.Sleep(1000)
                For i As Integer = 50 To 75
                    MetroProgressSpinner1.Value = i
                Next
                'MessageBox.Show(rcvdata.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End With
            If rcvdata.ToString.Contains(">") Then
                For i As Integer = 75 To 100
                    MetroProgressSpinner1.Value = i
                Next
                MessageBox.Show("Message Sent!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                For i As Integer = 75 To 100
                    MetroProgressSpinner1.Value = i
                Next
                MessageBox.Show("Error in sending message!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        loadComPorts()
    End Sub
End Class