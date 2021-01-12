Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmBalanceRpt
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim rpt As New CrystalReport2() 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New gyaDataSet 'The DataSet you created.


            myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")
            MyCommand.Connection = myConnection

            MyCommand.CommandText = "select * from CustomerAttendanceEntry where Balance>0  order by Balance DESC"
            'MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateFrom.Value.Date
            'MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateTo.Value.Date
            ' INNER JOIN CustomerMaster ON tblCustomerAttendance.Balance = CustomerMaster.Balance where tblCustomerAttendance.
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            ' myDA.Fill(myDS, "tblCustomerAttendance")
            myDA.Fill(myDS, "CustomerAttendanceEntry")
            rpt.SetDataSource(myDS)
            CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Dim rpt As New CrystalReport2() 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New gyaDataSet 'The DataSet you created.


            myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "select * from CustomerAttendanceEntry where Balance between @date1 and @date2 and Balance>0 order by Balance DESC"
            MyCommand.Parameters.Add("@date1", SqlDbType.Money, 10, "Balance").Value = TextBox2.Text
            MyCommand.Parameters.Add("@date2", SqlDbType.Money, 10, "Balance").Value = TextBox3.Text
            ' INNER JOIN CustomerMaster ON tblCustomerAttendance.Balance = CustomerMaster.Balance where tblCustomerAttendance.
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            ' myDA.Fill(myDS, "tblCustomerAttendance")
            myDA.Fill(myDS, "CustomerAttendanceEntry")
            rpt.SetDataSource(myDS)
            CrystalReportViewer2.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim rpt As New CrystalReport2() 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New gyaDataSet 'The DataSet you created.


            myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "select * from CustomerAttendanceEntry where Balance>=@date1   order by Balance DESC"
            MyCommand.Parameters.Add("@date1", SqlDbType.Money, 10, "Balance").Value = TextBox4.Text

            ' INNER JOIN CustomerMaster ON tblCustomerAttendance.Balance = CustomerMaster.Balance where tblCustomerAttendance.
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            ' myDA.Fill(myDS, "tblCustomerAttendance")
            myDA.Fill(myDS, "CustomerAttendanceEntry")
            rpt.SetDataSource(myDS)
            CrystalReportViewer3.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class