Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmPrintChange

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Try
            Dim rpt As New billduplicate() 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New gyaDataSet 'The DataSet you created.


            myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "select * from tblCustomerAttendance1 where Month='" & frmChangeBill.TextBox2.Text & "' and [Customer ID]= '" & frmChangeBill.TextBox4.Text & "' order by AreaCode"
            'MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateFrom.Value.Date
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
    End Sub
End Class