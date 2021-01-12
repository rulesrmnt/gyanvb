Imports System.Data.SqlClient
Imports System.Object
Imports excel = Microsoft.Office.Interop.Excel
Public Class frmCustomerEntryRecord1
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub frmCustomerEntryRecord1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.CustomerMaster' table. You can move, or remove it, as needed.
        Me.CustomerMasterTableAdapter.Fill(Me.GyaDataSet.CustomerMaster)
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Customer Name] FROM CustomerMaster", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox2.Items.Clear()



            For Each drow As DataRow In dtable.Rows
                ComboBox2.Items.Add(drow(0).ToString())


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
            ComboBox1.Items.Clear()



            For Each drow As DataRow In dtable.Rows
                ComboBox1.Items.Add(drow(0).ToString())


            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  AreaCode FROM CustomerMaster", CN)
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
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmCusExtraPaper.Show()

            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();

            frmCusExtraPaper.TextBox4.Text = dr.Cells(0).Value.ToString()
            frmCusExtraPaper.TextBox1.Text = dr.Cells(1).Value.ToString()
            frmCusExtraPaper.ComboBox2.Text = dr.Cells(2).Value.ToString()
            frmCusExtraPaper.ComboBox3.Text = dr.Cells(3).Value.ToString()
            frmCusExtraPaper.TextBox3.Text = dr.Cells(4).Value.ToString()
            frmCusExtraPaper.ComboBox7.Text = dr.Cells(5).Value.ToString()
            ' frmCusExtraPaper.ComboBox1.Text = dr.Cells(6).Value.ToString()
            frmCusExtraPaper.TextBox5.Text = dr.Cells(7).Value.ToString()
            'frmCusExtraPaper.TextBox7.Text = dr.Cells(8).Value.ToString()
            frmCusExtraPaper.TextBox6.Text = dr.Cells(9).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT * from CustomerMaster where AreaCode='" & ComboBox3.Text & "' or [Customer Code]='" & ComboBox1.Text & "' or [Customer Name]='" & ComboBox2.Text & "' order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerMaster")

            DataGridView1.DataSource = myDataSet.Tables("CustomerMaster").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT * from CustomerMaster where [Customer Code]='" & ComboBox1.Text & "' order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerMaster")

            DataGridView1.DataSource = myDataSet.Tables("CustomerMaster").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT * from   CustomerMaster where [Customer Name]='" & ComboBox2.Text & "' order by [Customer Name]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerMaster")

            DataGridView1.DataSource = myDataSet.Tables("CustomerMaster").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT * from CustomerMaster where AreaCode='" & ComboBox3.Text & "'  order by AreaCode", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerMaster")

            DataGridView1.DataSource = myDataSet.Tables("CustomerMaster").DefaultView

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