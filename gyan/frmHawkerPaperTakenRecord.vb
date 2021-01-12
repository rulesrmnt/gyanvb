Imports System.Data.SqlClient
Imports System.Object
Public Class frmHawkerPaperTakenRecord
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.HawkerPaperTaken' table. You can move, or remove it, as needed.
        Me.HawkerPaperTakenTableAdapter.Fill(Me.GyaDataSet.HawkerPaperTaken)

    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmHawkerPaperTaken.Show()

            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmHawkerPaperTaken.ComboBox12.Text = dr.Cells(0).Value.ToString()
            frmHawkerPaperTaken.ComboBox1.Text = dr.Cells(1).Value.ToString()
            frmHawkerPaperTaken.ComboBox2.Text = dr.Cells(2).Value.ToString()
            frmHawkerPaperTaken.ComboBox3.Text = dr.Cells(3).Value.ToString()
            frmHawkerPaperTaken.ComboBox4.Text = dr.Cells(4).Value.ToString()
            frmHawkerPaperTaken.ComboBox5.Text = dr.Cells(5).Value.ToString()
            frmHawkerPaperTaken.ComboBox6.Text = dr.Cells(6).Value.ToString()
            frmHawkerPaperTaken.ComboBox7.Text = dr.Cells(7).Value.ToString()
            frmHawkerPaperTaken.ComboBox8.Text = dr.Cells(8).Value.ToString()
            frmHawkerPaperTaken.ComboBox9.Text = dr.Cells(9).Value.ToString()
            frmHawkerPaperTaken.ComboBox10.Text = dr.Cells(10).Value.ToString()
            frmHawkerPaperTaken.ComboBox11.Text = dr.Cells(11).Value.ToString()
         
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT * from HawkerPaperTaken where [Hawker Name]='" & TextBox7.Text & "' order by [Hawker Name]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "HawkerPaperTaken")

            DataGridView1.DataSource = myDataSet.Tables("HawkerPaperTaken").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing


        TextBox7.Text = ""
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class