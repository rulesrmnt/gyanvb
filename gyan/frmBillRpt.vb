Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmBillRpt
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As New DataTable
    Dim dtable As DataTable
    Dim cs As String = "Data Source=.\SQLEXPRESS;Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf;User Instance=True"
    Sub fillMonth()
       


    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Len(Trim(ComboBox5.Text)) = 0 Then
            MessageBox.Show("Please enter Month", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox5.Focus()
            Exit Sub
        End If
        Try

            con = New SqlConnection(cs)
            con.Open()

            'Dim cm As String = "insert into [Customer Attendance] (Date,Day,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30) select @d1,@d2,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30 from datagridview2 "

            'Dim cm As String = "insert  tblCustomerAttendance (Date,Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Total,Balance) select @d1,@d2,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,No*Rate AS Total,Balance from CustomerAttendanceEntry "
            Dim ca As String = "insert  tblCustomerAttendance1 (Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Total,Balance) SELECT Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name],[Paper Name], SUM(No) AS No, SUM(Total) AS Total, Balance from tblCustomerAttendance GROUP BY Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name],[Paper Name],Balance "
            'cmd = New SqlCommand(cm)
            cmd = New SqlCommand(ca)

            cmd.Connection = con

            cmd.ExecuteReader()
            ' MessageBox.Show("Successfully Saved", "Customer Entry for Today", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Month from tblCustomerAttendance1 where Month=@find"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 20, "Month"))
        cmd.Parameters("@find").Value = ComboBox5.Text
        rdr = cmd.ExecuteReader()

        If rdr.Read Then
           

            Try
                Dim rpt As New billduplicate() 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New gyaDataSet 'The DataSet you created.


                myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")
                MyCommand.Connection = myConnection
                MyCommand.CommandText = "select * from tblCustomerAttendance1  where Month='" & ComboBox5.Text & "' and No>0 order by AreaCode"
                ' MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateFrom.Value.Date
                ' MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateTo.Value.Date
                ' INNER JOIN CustomerMaster ON tblCustomerAttendance.Balance = CustomerMaster.Balance where tblCustomerAttendance.
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "tblCustomerAttendance1")
                'myDA.Fill(myDS, "CustomerAttendanceEntry")
                rpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = rpt
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


            Try
                'If MessageBox.Show("Do you really want to delete the record?", "Entry Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                delete_records1()

                'End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        Else
            MessageBox.Show("No data to Display", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
        End If
    End Sub
    Private Sub delete_records1()
      
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq1 As String = "delete from tblCustomerAttendance where Month=@DELETE1;"
            cmd = New SqlCommand(cq1)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 10, "Month"))
            cmd.Parameters("@DELETE1").Value = Trim(ComboBox5.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim rpt As New billduplicate() 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New gyaDataSet 'The DataSet you created.


            myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "select * from tblCustomerAttendance1 where Month='" & ComboBox1.Text & "' and [Hawker Name]= '" & ComboBox4.Text & "' and No>0 order by AreaCode"
            'MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateFrom.Value.Date
            ' MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateTo.Value.Date
            ' INNER JOIN CustomerMaster ON tblCustomerAttendance.Balance = CustomerMaster.Balance where tblCustomerAttendance.
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "tblCustomerAttendance1")
            'myDA.Fill(myDS, "CustomerAttendanceEntry")
            rpt.SetDataSource(myDS)
            CrystalReportViewer2.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmBillRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct(MonthYear) FROM HawkerPaperSupply", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox5.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                ComboBox1.Items.Add(drow(0).ToString())
                ComboBox2.Items.Add(drow(0).ToString())
                ComboBox5.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Customer Code] FROM CustomerMaster", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox3.Items.Clear()


            For Each drow As DataRow In dtable.Rows
                ComboBox3.Items.Add(drow(0).ToString())

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Hawker Name] FROM HawkerMaster", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox4.Items.Clear()


            For Each drow As DataRow In dtable.Rows
                ComboBox4.Items.Add(drow(0).ToString())

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim rpt As New billduplicate() 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New gyaDataSet 'The DataSet you created.


            myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "select * from tblCustomerAttendance1 where Month='" & ComboBox2.Text & "' and [Customer ID]= '" & ComboBox3.Text & "'and No>0 order by AreaCode"
            'MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateFrom.Value.Date
            ' MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateTo.Value.Date
            ' INNER JOIN CustomerMaster ON tblCustomerAttendance.Balance = CustomerMaster.Balance where tblCustomerAttendance.
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "tblCustomerAttendance1")
            'myDA.Fill(myDS, "CustomerAttendanceEntry")
            rpt.SetDataSource(myDS)
            CrystalReportViewer3.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub


End Class