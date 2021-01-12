Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class frmCustomerDetails
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As New DataTable
    Dim dtable As DataTable
    Dim source1 As New BindingSource()
    Dim cs As String = "Data Source=.\SQLEXPRESS;Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf;User Instance=True"
   
    
   
  
    Sub fillNewsPaperName()

        Try

            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Newspaper Name],Rate FROM NewspaperMaster", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            'ComboBox2.Items.Clear()
            ' ComboBox3.Items.Clear()

            'ComboBox5.Items.Clear()
            'ComboBox6.Items.Clear()
            ComboBox1.Items.Clear()


            For Each drow As DataRow In dtable.Rows
                'ComboBox2.Items.Add(drow(0).ToString())
                'ComboBox3.Items.Add(drow(0).ToString())

                'ComboBox5.Items.Add(drow(0).ToString())
                'ComboBox6.Items.Add(drow(0).ToString())
                ComboBox1.Items.Add(drow(0).ToString())
               
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillHawkerName()
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Hawker Name] FROM HawkerMaster", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox7.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                ComboBox7.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

       
    End Sub
    Sub fillAddress()
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  AreaAddress FROM tblAreaMaster", CN)
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


    End Sub
    Sub clear()
      
        ComboBox7.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        'ComboBox4.Text = ""
        'TextBox5.Text = ""
        'ComboBox6.Text = ""
    End Sub
    Sub clear1()

        ComboBox7.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        'ComboBox4.Text = ""
        TextBox5.Text = ""
        'ComboBox6.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("Select * from CustomerMaster where [Hawker Name]='" & ComboBox4.Text & "' and [Customer Name]='" & ComboBox5.Text & "'  ", con)
             Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerMaster")

            DataGridView1.DataSource = myDataSet.Tables("CustomerMaster").DefaultView

            con.Close()

            Button5.Enabled = True
            Button1.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clear()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button5.Enabled = False
        ' Button6.Enabled = False
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub
    

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

   
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            clear1()

            ' Me.Hide()
            'frmCustomerDetails.Show()

            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();

            ComboBox7.Text = dr.Cells(0).Value.ToString()
            ComboBox2.Text = dr.Cells(1).Value.ToString()
            ComboBox3.Text = dr.Cells(3).Value.ToString()
            ComboBox1.Text = dr.Cells(6).Value.ToString()
            TextBox5.Text = dr.Cells(7).Value.ToString()
            Button5.Enabled = True
            If TextBox5.Text = "0" Then
                CheckBox1.Checked = False

            Else
                CheckBox1.Checked = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmCustomerDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.CustomerMaster' table. You can move, or remove it, as needed.
        Me.CustomerMasterTableAdapter.Fill(Me.GyaDataSet.CustomerMaster)
        clear()
       
        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Hawker Name] FROM HawkerMaster", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox4.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                ComboBox4.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT * from CustomerMaster   order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerMaster")

            DataGridView1.DataSource = myDataSet.Tables("CustomerMaster").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Button5.Enabled = False
        'Button6.Enabled = False
        Button1.Enabled = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        
        Try

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update CustomerAttendanceEntry set No='" & TextBox5.Text & "' where [Customer ID]='" & ComboBox7.Text & "' and [Paper Name]='" & ComboBox1.Text & "' and [Customer Name]='" & ComboBox2.Text & "'"

            cmd = New SqlCommand(cb)

            cmd.Connection = con

            


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

            Dim cb As String = "update CustomerMaster set No=@d1 where [Customer Code]=@d2 and [NewsPaper Take]=@d3"

            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.Int, 10, "No"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "[Customer Code]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "[NewsPaper Take]"))
            cmd.Parameters("@d1").Value = TextBox5.Text
            cmd.Parameters("@d2").Value = ComboBox7.Text
            cmd.Parameters("@d3").Value = ComboBox1.Text


            cmd.ExecuteReader()
            MessageBox.Show("Successfully updated", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button5.Enabled = False
            'Button6.Enabled = False
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button5.Enabled = True
        Button2.Enabled = True
        'Button6.Enabled = False
        Button1.Enabled = True
        Button3.Enabled = False
        Me.Hide()
        clear()

        frmCustomerEntryRecord.Show()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox5.Text = "1"
        Else
            TextBox5.Text = "0"
        End If

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT * from CustomerMaster where [Hawker Name]='" & ComboBox4.Text & "'  order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerMaster")

            DataGridView1.DataSource = myDataSet.Tables("CustomerMaster").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Customer Name] FROM CustomerMaster where [Hawker Name]='" & ComboBox4.Text & "'", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox5.Items.Clear()



            For Each drow As DataRow In dtable.Rows
                ComboBox5.Items.Add(drow(0).ToString())


            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

   
 
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.Click
       
    End Sub

    

    Private Sub ComboBox5_SelectedIndexChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT * from CustomerMaster where [Hawker Name]='" & ComboBox4.Text & "' and [Customer Name]='" & ComboBox5.Text & "' order by [Customer Code]", con)


            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerMaster")

            DataGridView1.DataSource = myDataSet.Tables("CustomerMaster").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class