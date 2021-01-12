Imports System.Data.SqlClient
Imports System.Object
Imports excel = Microsoft.Office.Interop.Excel
Public Class frmCheckAttendance
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

   

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name] , SUM(No) AS No,SUM(Rate) AS [Month Total], Balance, (SUM(Rate)+Balance) AS Total from tblCustomerAttendance where [Hawker Name]='" & ComboBox1.Text & "' GROUP BY Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No],[Hawker Name], Balance", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerAttendance")

            DataGridView1.DataSource = myDataSet.Tables("tblCustomerAttendance").DefaultView

            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmCheckAttendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name] , SUM(No) AS No,SUM(Rate) AS [Month Total], Balance, (SUM(Rate)+Balance) As Total from tblCustomerAttendance GROUP BY Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No],[Hawker Name], Balance", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerAttendance")

            DataGridView1.DataSource = myDataSet.Tables("tblCustomerAttendance").DefaultView

            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If DataGridView1.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New excel.Application

        Try
            Dim excelBook As excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As excel.Worksheet = CType(excelBook.Worksheets(1), excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView1.RowCount - 1
            colsTotal = DataGridView1.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView1.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView1.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub
End Class