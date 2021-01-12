Imports System.Data.SqlClient
Imports System.Text

Public Class frmCollectionEntry
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As New DataTable
    Dim dtable As DataTable
    Dim cs As String = "Data Source=.\SQLEXPRESS;Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf;User Instance=True"
    Public Sub clear()
       
        TextBox9.Text = ""
        TextBox7.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        ComboBox9.Text = ""
        DateTimePicker1.Text = ""

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox7.Text = Val(TextBox2.Text) - Val(TextBox9.Text)
        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into tblCollectionEntry(Month,[Customer Code],[Customer Name],[Phone no],AreaCode,PaymentDate,[Hawker Name],No,MonthTotal,PreviousBalance,[Grand Total],Paid,Balance) VALUES (@d1,@d2,@d3,@d5,@d4,@d13,@d6,@d8,@d9,@d7,@d11,@d10,@d12)"

            cmd = New SqlCommand(cb)

            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "[Customer Code]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "[Customer Name]"))
            '
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "[Phone no]"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "AreaCode"))
            cmd.Parameters.Add(New SqlParameter("@d13", System.Data.SqlDbType.Date, 10, "PaymentDate"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))

            ' cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "[NewsPaper Take]"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.NChar, 2, "No"))
            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.Money, 10, "MonthTotal"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Money, 10, "PreviosBalance"))

            cmd.Parameters.Add(New SqlParameter("@d11", System.Data.SqlDbType.Money, 10, "[Grand Total]"))
            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.Money, 10, "Paid"))
            cmd.Parameters.Add(New SqlParameter("@d12", System.Data.SqlDbType.Money, 10, "Balance"))

            cmd.Parameters("@d1").Value = ComboBox5.Text
            cmd.Parameters("@d2").Value = ComboBox1.Text

            cmd.Parameters("@d3").Value = ComboBox2.Text

            ' 

            cmd.Parameters("@d5").Value = ComboBox4.Text
            cmd.Parameters("@d4").Value = ComboBox3.Text
            cmd.Parameters("@d13").Value = DateTimePicker1.Text
            cmd.Parameters("@d6").Value = ComboBox7.Text

            'cmd.Parameters("@d7").Value = ComboBox1.Text
            cmd.Parameters("@d8").Value = ComboBox6.Text
            cmd.Parameters("@d9").Value = ComboBox8.Text
            cmd.Parameters("@d7").Value = ComboBox9.Text

            cmd.Parameters("@d11").Value = TextBox2.Text
            cmd.Parameters("@d10").Value = TextBox9.Text
            cmd.Parameters("@d12").Value = TextBox7.Text
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update CustomerAttendanceEntry set Balance=@d3 where [Customer ID]=@d2"
            cmd = New SqlCommand(cb)

            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Customer ID]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Money, 10, "Balance"))
            cmd.Parameters("@d2").Value = ComboBox1.Text
            cmd.Parameters("@d3").Value = TextBox7.Text
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then

                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update tblCustomerAttendance set Balance=@d3 where [Customer ID]=@d2 and  tblCustomerAttendance.Month='" & TextBox1.Text & "' "
            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Customer ID]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Money, 10, "Balance"))

            cmd.Parameters("@d2").Value = ComboBox1.Text
            cmd.Parameters("@d3").Value = TextBox7.Text
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then

                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update CustomerMaster set Balance=@d3 where [Customer Code]=@d2"
            cmd = New SqlCommand(cb)

            cmd.Connection = con


            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Customer Code]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Money, 10, "Balance"))

            cmd.Parameters("@d2").Value = ComboBox1.Text
            cmd.Parameters("@d3").Value = TextBox7.Text

            MessageBox.Show("Successfully saved", "Amount Received by customer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button5.Enabled = False
            Button6.Enabled = False
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        clear()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        frmCollectionEntryRecord.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update tblCollectionEntry set Balance=@d3,Paid='" & TextBox9.Text & "' where [Customer ID]=@d2 and  tblCollectionEntry.Month='" & TextBox1.Text & "' "
            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Customer ID]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Money, 10, "Balance"))

            cmd.Parameters("@d2").Value = ComboBox1.Text
            cmd.Parameters("@d3").Value = TextBox7.Text
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then

                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update CustomerAttendanceEntry set Balance=@d3 where [Customer ID]=@d2"
            cmd = New SqlCommand(cb)

            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Customer ID]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Money, 10, "Balance"))
            cmd.Parameters("@d2").Value = ComboBox1.Text
            cmd.Parameters("@d3").Value = TextBox7.Text
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then

                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update tblCustomerAttendance set Balance=@d3 where [Customer ID]=@d2 and  tblCustomerAttendance.Month='" & TextBox1.Text & "' "
            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Customer ID]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Money, 10, "Balance"))

            cmd.Parameters("@d2").Value = ComboBox1.Text
            cmd.Parameters("@d3").Value = TextBox7.Text
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then

                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update CustomerMaster set Balance=@d3 where [Customer Code]=@d2"
            cmd = New SqlCommand(cb)

            cmd.Connection = con


            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Customer Code]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Money, 10, "Balance"))

            cmd.Parameters("@d2").Value = ComboBox1.Text
            cmd.Parameters("@d3").Value = TextBox7.Text

            MessageBox.Show("Successfully saved", "Amount Received by customer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button5.Enabled = False
            Button6.Enabled = False
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clear()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub frmCollectionEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.tblCustomerAttendance' table. You can move, or remove it, as needed.
        Me.TblCustomerAttendanceTableAdapter.Fill(Me.GyaDataSet.tblCustomerAttendance)
        ' ComboBox12.Text = Format(Now - 1, "mm" - 1)
        TextBox1.Text = Format(DateTimePicker1.Value, "MMM-yyyy")
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Hawker Name] FROM HawkerMaster", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox11.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                ComboBox11.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct (Month) FROM tblCustomerAttendance1", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox12.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                ComboBox12.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], SUM(No) AS No,SUM(Rate) AS Rate, SUM(Total) AS Total, Balance from tblCustomerAttendance1  GROUP BY Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], Balance order by [Customer ID]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerMaster")

            DataGridView1.DataSource = myDataSet.Tables("CustomerMaster").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
     
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.Click
       

    End Sub

   
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("Select Distinct(Month) from tblCustomerAttendance where [Customer ID]='" & ComboBox1.Text & "' and [Customer Name]='" & ComboBox2.Text & "' and AreaCode='" & ComboBox3.Text & "' ", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)

            ComboBox5.Items.Clear()


            For Each drow As DataRow In dtable.Rows

                ComboBox5.Items.Add(drow(0).ToString())

            Next
            ' Button5.Enabled = True
            Button1.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub TextBox9_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        TextBox2.Text = Val(ComboBox8.Text) + Val(ComboBox9.Text)
    End Sub

   
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            clear()

            ' frmCollectionEntry.Show()

            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            ComboBox5.Text = dr.Cells(0).Value.ToString()
            ComboBox1.Text = dr.Cells(1).Value.ToString()
            ComboBox2.Text = dr.Cells(2).Value.ToString()
            ComboBox3.Text = dr.Cells(4).Value.ToString()
            ComboBox4.Text = dr.Cells(5).Value.ToString()
            ComboBox7.Text = dr.Cells(6).Value.ToString()
            ComboBox6.Text = dr.Cells(7).Value.ToString()
            ComboBox8.Text = dr.Cells(9).Value.ToString()
            ComboBox9.Text = dr.Cells(10).Value.ToString()
            Button1.Enabled = True

            'frmCollectionEntry.TextBox11.Text = dr.Cells(3).Value.ToString()
            ' frmCollectionEntry.TextBox3.Text = dr.Cells(4).Value.ToString()
            '  frmCollectionEntry.ComboBox7.Text = dr.Cells(5).Value.ToString()
            '  frmCollectionEntry.ComboBox1.Text = dr.Cells(6).Value.ToString()
            '  frmCollectionEntry.TextBox5.Text = dr.Cells(7).Value.ToString()

            'frmCollectionEntry.TextBox2.Text = Val(frmCollectionEntry.TextBox10.Text) + Val(frmCollectionEntry.TextBox6.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox11.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], SUM(No) AS No,SUM(Rate) AS Rate, SUM(Total) AS Total, Balance from tblCustomerAttendance1 where [Hawker Name]='" & ComboBox11.Text & "' and Month ='" & ComboBox12.Text & "' GROUP BY Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], Balance", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerAttendance1")

            DataGridView1.DataSource = myDataSet.Tables("tblCustomerAttendance1").DefaultView

            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Customer Name] FROM CustomerMaster where [Hawker Name]='" & ComboBox11.Text & "'", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox10.Items.Clear()



            For Each drow As DataRow In dtable.Rows
                ComboBox10.Items.Add(drow(0).ToString())


            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], SUM(No) AS No,SUM(Rate) AS Rate, SUM(Total) AS Total, Balance from tblCustomerAttendance1 where [Hawker Name]='" & ComboBox11.Text & "'  and [Customer Name]='" & ComboBox10.Text & "' and Month ='" & ComboBox12.Text & "' GROUP BY Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], Balance", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerAttendance1")

            DataGridView1.DataSource = myDataSet.Tables("tblCustomerAttendance1").DefaultView

            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.Click
       
    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub
End Class