Imports excel = Microsoft.Office.Interop.Excel
Public Class frmNewsPaperRecord


    Private Sub frmNewsPaperRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.NewspaperMaster' table. You can move, or remove it, as needed.
        Me.NewspaperMasterTableAdapter.Fill(Me.GyaDataSet.NewspaperMaster)

    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            FrmNewspaperDetails.Show()

            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();

            FrmNewspaperDetails.TextBox9.Text = dr.Cells(0).Value.ToString()
            FrmNewspaperDetails.TextBox1.Text = dr.Cells(1).Value.ToString()
            FrmNewspaperDetails.TextBox2.Text = dr.Cells(2).Value.ToString()
            FrmNewspaperDetails.TextBox3.Text = dr.Cells(3).Value.ToString()
            FrmNewspaperDetails.TextBox4.Text = dr.Cells(4).Value.ToString()
            FrmNewspaperDetails.TextBox5.Text = dr.Cells(5).Value.ToString()
            FrmNewspaperDetails.TextBox6.Text = dr.Cells(6).Value.ToString()
            FrmNewspaperDetails.TextBox7.Text = dr.Cells(7).Value.ToString()
            FrmNewspaperDetails.TextBox8.Text = dr.Cells(7).Value.ToString()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

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