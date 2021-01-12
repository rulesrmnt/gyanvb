Public Class frmHawkerRecord

    Private Sub frmHawkerRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.HawkerMaster' table. You can move, or remove it, as needed.
        Me.HawkerMasterTableAdapter.Fill(Me.GyaDataSet.HawkerMaster)

    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmHawkerDetails.Show()

            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();

            frmHawkerDetails.TextBox4.Text = dr.Cells(0).Value.ToString()
            frmHawkerDetails.TextBox1.Text = dr.Cells(1).Value.ToString()
            frmHawkerDetails.TextBox2.Text = dr.Cells(2).Value.ToString()
            frmHawkerDetails.TextBox3.Text = dr.Cells(3).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class