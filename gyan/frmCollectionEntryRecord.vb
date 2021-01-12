Imports System.Data.SqlClient
Imports System.Object

Public Class frmCollectionEntryRecord
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub frmCollectionEntryRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.tblCollectionEntry' table. You can move, or remove it, as needed.
        Me.TblCollectionEntryTableAdapter.Fill(Me.GyaDataSet.tblCollectionEntry)


       
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
            frmCollectionEntry.Show()

            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmCollectionEntry.ComboBox5.Text = dr.Cells(0).Value.ToString()
            frmCollectionEntry.ComboBox1.Text = dr.Cells(1).Value.ToString()
            frmCollectionEntry.ComboBox2.Text = dr.Cells(2).Value.ToString()
            frmCollectionEntry.ComboBox4.Text = dr.Cells(3).Value.ToString()
            frmCollectionEntry.ComboBox3.Text = dr.Cells(4).Value.ToString()
            frmCollectionEntry.DateTimePicker1.Text = dr.Cells(5).Value.ToString()
            frmCollectionEntry.ComboBox7.Text = dr.Cells(6).Value.ToString()
            frmCollectionEntry.ComboBox6.Text = dr.Cells(7).Value.ToString()
            frmCollectionEntry.ComboBox8.Text = dr.Cells(8).Value.ToString()
            frmCollectionEntry.ComboBox9.Text = dr.Cells(9).Value.ToString()
            frmCollectionEntry.TextBox9.Text = dr.Cells(11).Value.ToString()

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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT  Month, [Customer Code], [Customer Name], [Phone No], PaymentDate, [Hawker Name], No, [Grand Total], Paid, Balance FROM tblcollectionEntry where AreaCode='" & ComboBox3.Text & "' or [Customer Code]='" & ComboBox1.Text & "' or [Customer Name]='" & ComboBox2.Text & "'", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblcollectionEntry")

            DataGridView1.DataSource = myDataSet.Tables("tblcollectionEntry").DefaultView

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
  
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            con = New SqlConnection(cs)
            con.Open()

            'Dim cm As String = "insert into [Customer Attendance] (Date,Day,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30) select @d1,@d2,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30 from datagridview2 "

            'Dim cm As String = "insert  tblCustomerAttendance (Date,Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Total,Balance) select @d1,@d2,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,No*Rate AS Total,Balance from CustomerAttendanceEntry "
            Dim ca As String = "insert  tblCustomerAttendance1 (Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],No,Rate,Balance) SELECT Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], SUM(No) AS No, SUM(Total) AS Total, Balance from tblCustomerAttendance GROUP BY Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], Balance "
            'cmd = New SqlCommand(cm)
            cmd = New SqlCommand(ca)

            cmd.Connection = con

            cmd.ExecuteReader()
            MessageBox.Show("Successfully Saved", "Customer Entry for Today", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class