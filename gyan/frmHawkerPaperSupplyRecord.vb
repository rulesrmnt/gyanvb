Imports System.Data.SqlClient
Imports System.Object
Public Class frmHawkerPaperSupplyRecord
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmHawkerPaperSupply.Show()

            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();

            frmHawkerPaperSupply.TextBox11.Text = dr.Cells(0).Value.ToString()
            frmHawkerPaperSupply.ComboBox12.Text = dr.Cells(1).Value.ToString()
            frmHawkerPaperSupply.ComboBox1.Text = dr.Cells(2).Value.ToString()
            frmHawkerPaperSupply.Label2.Text = dr.Cells(3).Value.ToString()
            frmHawkerPaperSupply.TextBox1.Text = dr.Cells(4).Value.ToString()
            frmHawkerPaperSupply.Label3.Text = dr.Cells(5).Value.ToString()
            frmHawkerPaperSupply.TextBox2.Text = dr.Cells(6).Value.ToString()
            frmHawkerPaperSupply.Label4.Text = dr.Cells(7).Value.ToString()
            frmHawkerPaperSupply.TextBox3.Text = dr.Cells(8).Value.ToString()

            frmHawkerPaperSupply.Label5.Text = dr.Cells(9).Value.ToString()
            frmHawkerPaperSupply.TextBox4.Text = dr.Cells(10).Value.ToString()
            frmHawkerPaperSupply.Label6.Text = dr.Cells(11).Value.ToString()
            frmHawkerPaperSupply.TextBox5.Text = dr.Cells(12).Value.ToString()
            frmHawkerPaperSupply.Label7.Text = dr.Cells(13).Value.ToString()
            frmHawkerPaperSupply.TextBox6.Text = dr.Cells(14).Value.ToString()


            frmHawkerPaperSupply.Label8.Text = dr.Cells(15).Value.ToString()
            frmHawkerPaperSupply.TextBox7.Text = dr.Cells(16).Value.ToString()
            frmHawkerPaperSupply.Label9.Text = dr.Cells(17).Value.ToString()
            frmHawkerPaperSupply.TextBox8.Text = dr.Cells(18).Value.ToString()

            frmHawkerPaperSupply.Label10.Text = dr.Cells(19).Value.ToString()
            frmHawkerPaperSupply.TextBox9.Text = dr.Cells(20).Value.ToString()
            frmHawkerPaperSupply.Label11.Text = dr.Cells(21).Value.ToString()
            frmHawkerPaperSupply.TextBox10.Text = dr.Cells(22).Value.ToString()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmHawkerPaperSupplyRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Format(Now, "MMMM-yyyy")
        'TODO: This line of code loads data into the 'GyaDataSet.HawkerPaperSupply' table. You can move, or remove it, as needed.
        Me.HawkerPaperSupplyTableAdapter.Fill(Me.GyaDataSet.HawkerPaperSupply)

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT * from HawkerPaperSupply where MonthYear='" & TextBox1.Text & "'  and [Hawker Name]='" & TextBox7.Text & "' order by [Hawker Name]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "HawkerPaperSupply")

            DataGridView1.DataSource = myDataSet.Tables("HawkerPaperSupply").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing
        TextBox1.Text = ""

        TextBox7.Text = ""
    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class