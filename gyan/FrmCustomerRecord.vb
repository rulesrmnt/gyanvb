Imports System.Data.SqlClient
Imports System.Object

Public Class FrmCustomerRecord
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Month,[Customer Code],[Customer Name],Address,[Phone No],[Hawker Name],[NewsPaper Take],No,Rate,[Month Total],Balance,[Grand Total] from tblCustomerMoney  where [Customer Name] like '" & TextBox7.Text & "%'  order by [Customer Name]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerMoney")

            DataGridView1.DataSource = myDataSet.Tables("tblCustomerMoney").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Month,[Customer Code],[Customer Name],Address,[Phone No],[Hawker Name],[NewsPaper Take],No,Rate,[Month Total],Balance,[Grand Total] from tblCustomerMoney  where [Customer Code] like '" & TextBox2.Text & "%'  order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerMoney")

            DataGridView1.DataSource = myDataSet.Tables("tblCustomerMoney").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbOrderNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrderNo.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Month,[Customer Code],[Customer Name],Address,[Phone No],[Hawker Name],[NewsPaper Take],No,Rate,[Month Total],Balance,[Grand Total] from tblCustomerMoney  where Month like '" & cmbOrderNo.Text & "%'  order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerMoney")

            DataGridView2.DataSource = myDataSet.Tables("tblCustomerMoney").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Month,[Customer Code],[Customer Name],Address,[Phone No],[Hawker Name],[NewsPaper Take],No,Rate,[Month Total],Balance,[Grand Total] from tblCustomerMoney  where [Customer Name] like '" & TextBox1.Text & "%'  order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerMoney")

            DataGridView2.DataSource = myDataSet.Tables("tblCustomerMoney").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbProductName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProductName.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Month,[Customer Code],[Customer Name],Address,[Phone No],[Hawker Name],[NewsPaper Take],No,Rate,[Month Total],Balance,[Grand Total] from tblCustomerMoney  where [NewsPaper Take] like '" & cmbProductName.Text & "%'  order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerMoney")

            DataGridView5.DataSource = myDataSet.Tables("tblCustomerMoney").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtProduct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProduct.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Month,[Customer Code],[Customer Name],Address,[Phone No],[Hawker Name],[NewsPaper Take],No,Rate,[Month Total],Balance,[Grand Total] from tblCustomerMoney  where [Customer Name] like '" & txtProduct.Text & "%'  order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerMoney")

            DataGridView5.DataSource = myDataSet.Tables("tblCustomerMoney").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerName.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Month,[Customer Code],[Customer Name],Address,[Phone No],[Hawker Name],[NewsPaper Take],No,Rate,[Month Total],Balance,[Grand Total] from tblCustomerMoney  where [Hawker Name] like '" & cmbCustomerName.Text & "%'  order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerMoney")

            DataGridView6.DataSource = myDataSet.Tables("tblCustomerMoney").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Month,[Customer Code],[Customer Name],Address,[Phone No],[Hawker Name],[NewsPaper Take],No,Rate,[Month Total],Balance,[Grand Total] from tblCustomerMoney  where [Customer Name] like '" & txtCustomer.Text & "%'  order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "tblCustomerMoney")

            DataGridView6.DataSource = myDataSet.Tables("tblCustomerMoney").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        DataGridView2.DataSource = Nothing
        cmbOrderNo.Text = ""
        TextBox1.Text = ""

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        DataGridView5.DataSource = Nothing
        cmbProductName.Text = ""
        txtProduct.Text = ""

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        DataGridView6.DataSource = Nothing
        cmbCustomerName.Text = ""
        txtCustomer.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing
        
        TextBox7.Text = ""
        TextBox2.Text = ""
    End Sub

    

    Private Sub GroupBox13_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox13.Enter

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class