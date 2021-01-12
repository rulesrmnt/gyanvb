Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReturnRpt
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As New DataTable
    Dim dtable As DataTable
    Dim cs As String = "Data Source=.\SQLEXPRESS;Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf;User Instance=True"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim rpt As New CrystalReport6() 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New gyaDataSet 'The DataSet you created.


            myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")
            MyCommand.Connection = myConnection
            ' MyCommand.CommandText = "SELECT * FROM  BillInfo INNER JOIN ProductSold ON BillInfo.InvoiceNo = ProductSold.InvoiceNo INNER JOIN Customer ON BillInfo.CustomerNo = Customer.CustomerNo WHERE billinfo.invoiceno= '" & frmSales.txtInvoiceNo.Text & "'"
            ' Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Sunday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"
            MyCommand.CommandText = "select * from tblExtraSold where HawkerName like '" & ComboBox1.Text & "' and Sold>0"
            'MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateFrom.Value.Date
            'MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dtpInvoiceDateTo.Value.Date
            ' INNER JOIN CustomerMaster ON tblCustomerAttendance.Balance = CustomerMaster.Balance where tblCustomerAttendance.
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "tblExtraSold")
            ' myDA.Fill(myDS, "hawkerPaperReturn")
            rpt.SetDataSource(myDS)
            CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmReturnRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Hawker Name] FROM HawkerMaster", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox1.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                ComboBox1.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class