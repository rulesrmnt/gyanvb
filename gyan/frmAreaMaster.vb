Imports System.Data.SqlClient
Imports System.Text
Public Class frmAreaMaster
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As New DataTable
    Dim dtable As DataTable
    Dim cs As String = "Data Source=.\SQLEXPRESS;Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf;User Instance=True"
    Private Sub delete_records()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq1 As String = "delete from tblAreaMaster where AreaCode=@DELETE1;"
            cmd = New SqlCommand(cq1)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 10, "AreaCode"))
            cmd.Parameters("@DELETE1").Value = Trim(TextBox1.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear()
                Button5.Enabled = False
                Button6.Enabled = False
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear()
                Button5.Enabled = False
                Button6.Enabled = False
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            End If
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
            ComboBox1.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                ComboBox1.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Sub clear()

        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
    End Sub
    Private Sub auto()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(AreaCode) as AreaCode from tblAreaMaster"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()

        If rdr("AreaCode").ToString() <> "" Then
            TextBox1.Text = Integer.Parse(rdr("AreaCode").ToString()) + 1
        Else
            TextBox1.Text = 1
        End If
        con.Close()
        rdr.Close()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clear()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       

        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter  Area Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If
        If Len(Trim(ComboBox1.Text)) = 0 Then
            MessageBox.Show("Please enter  Hawker name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If


        Try
            auto()

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select AreaCode from tblAreaMaster where AreaCode=@find"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "AreaCode"))
            cmd.Parameters("@find").Value = TextBox1.Text
            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Area Code Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                If Not rdr Is Nothing Then
                    rdr.Close()
                End If

            Else
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "insert into tblAreaMaster(AreaCode,AreaAddress,HawkerName) VALUES (@d3,@d4,@d5)"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "AreaCode"))

                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 100, " AreaAddress"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, " HawkerName"))


                cmd.Parameters("@d3").Value = TextBox1.Text

                cmd.Parameters("@d4").Value = TextBox2.Text

                cmd.Parameters("@d5").Value = ComboBox1.Text

                cmd.ExecuteReader()
                MessageBox.Show("Successfully saved", "Area Details", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Button1.Enabled = False
                Button2.Enabled = True
                Button3.Enabled = True
                Button5.Enabled = False
                Button6.Enabled = False
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

                con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update tblAreaMaster set AreaAddress=@d3,HawkerName=@d4 where AreaCode=@d2"

            cmd = New SqlCommand(cb)

            cmd.Connection = con


            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "AreaCode"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AreaAddress"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 50, "HawkerName"))
            cmd.Parameters("@d2").Value = TextBox1.Text
            cmd.Parameters("@d3").Value = TextBox2.Text
            cmd.Parameters("@d4").Value = ComboBox1.Text

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
            Dim cb As String = "update CustomerAttendanceEntry set [Hawker Name]=@d3 where Address=@d2"
            cmd = New SqlCommand(cb)

            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Hawker Name]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "Address"))
            cmd.Parameters("@d2").Value = ComboBox1.Text
            cmd.Parameters("@d3").Value = TextBox2.Text
            cmd.ExecuteReader()
            MessageBox.Show("Successfully updated", "Area Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button5.Enabled = False
            Button6.Enabled = False
            Button1.Enabled = False
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub frmAreaMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   
        Button5.Enabled = False
        Button6.Enabled = False

        fillHawkerName()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' Button5.Enabled = True
        Button2.Enabled = True
        'Button6.Enabled = True
        Button1.Enabled = False
        Button3.Enabled = False
        Me.Hide()
        clear()

        frmAreaRecord.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If MessageBox.Show("Do you really want to delete the record?", "Hawker Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                delete_records()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class