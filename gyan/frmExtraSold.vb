Imports System.Data.SqlClient
Imports System.Object
Public Class frmExtraSold
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub frmExtraSold_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.HawkerMaster' table. You can move, or remove it, as needed.
        Me.HawkerMasterTableAdapter.Fill(Me.GyaDataSet.HawkerMaster)
        'TODO: This line of code loads data into the 'GyaDataSet.tblExtraSold' table. You can move, or remove it, as needed.
        Me.TblExtraSoldTableAdapter.Fill(Me.GyaDataSet.tblExtraSold)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
         Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT  Date,HawkerName,Newspaper,Taken,[Return],Sold,Taken-Sold-[Return] As ExtraSold from tblExtraSold  where HawkerName like '" & ComboBox1.Text & "%' and Sold>0  order by Taken", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblExtraSold")

            DataGridView1.DataSource = myDataSet.Tables("tblExtraSold").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class