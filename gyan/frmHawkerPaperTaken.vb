Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class frmHawkerPaperTaken

    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As New DataTable
    Dim dtable As DataTable
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub delete_records()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq1 As String = "delete from HawkerPaperTaken where HawkerCode=@DELETE1;"
            cmd = New SqlCommand(cq1)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 10, "HawkerCode"))
            cmd.Parameters("@DELETE1").Value = Trim(ComboBox12.Text)
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
    Sub clear()
       
        ComboBox7.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox6.Text = ""
        ComboBox5.Text = ""
        ComboBox8.Text = ""
        ComboBox9.Text = ""
        ComboBox10.Text = ""
        ComboBox11.Text = ""
        ComboBox12.Text = ""
    End Sub
    Sub fillNewsPaperName()

        Try

            Dim CN As New SqlConnection(cs)

            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  [Newspaper Name] FROM NewspaperMaster", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            ComboBox4.Items.Clear()
            ComboBox5.Items.Clear()
            ComboBox6.Items.Clear()
            ComboBox7.Items.Clear()
            ComboBox8.Items.Clear()
            ComboBox9.Items.Clear()
            ComboBox10.Items.Clear()
            ComboBox11.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                ComboBox2.Items.Add(drow(0).ToString())
                ComboBox3.Items.Add(drow(0).ToString())
                ComboBox4.Items.Add(drow(0).ToString())
                ComboBox5.Items.Add(drow(0).ToString())
                ComboBox6.Items.Add(drow(0).ToString())
                ComboBox7.Items.Add(drow(0).ToString())
                ComboBox8.Items.Add(drow(0).ToString())
                ComboBox9.Items.Add(drow(0).ToString())
                ComboBox10.Items.Add(drow(0).ToString())
                ComboBox11.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Len(Trim(ComboBox12.Text)) = 0 Then
            MessageBox.Show("Please enter Hawker Code", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If
        If Len(Trim(ComboBox1.Text)) = 0 Then
            MessageBox.Show("Please enter Hawker Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If

        If Len(Trim(ComboBox2.Text)) = 0 Then
            MessageBox.Show("Please enter atleast 1st PAPER", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox2.Focus()
            Exit Sub
        End If



        Try


            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select HawkerCode from HawkerPaperTaken where HawkerCode=@find"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "HawkerCode"))
            cmd.Parameters("@find").Value = ComboBox12.Text()
            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Hawker Code Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ComboBox1.Text = ""
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            Else



                con = New SqlConnection(cs)
                con.Open()

                Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                cmd = New SqlCommand(cb)

                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.NChar, 10, "HawkerCode"))
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Paper 1]"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "[Paper 2]"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "[Paper 3]"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "[Paper 4]"))
                cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "[Paper 5]"))
                cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "[Paper 6]"))
                cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "[Paper 7]"))
                cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "[Paper 8]"))
                cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "[Paper 9]"))
                cmd.Parameters.Add(New SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "[Paper 10]"))

                cmd.Parameters("@d0").Value = ComboBox12.Text
                cmd.Parameters("@d1").Value = ComboBox1.Text
                cmd.Parameters("@d2").Value = ComboBox2.Text
                cmd.Parameters("@d3").Value = ComboBox3.Text
                cmd.Parameters("@d4").Value = ComboBox4.Text
                cmd.Parameters("@d5").Value = ComboBox5.Text
                cmd.Parameters("@d6").Value = ComboBox6.Text
                cmd.Parameters("@d7").Value = ComboBox7.Text
                cmd.Parameters("@d8").Value = ComboBox8.Text
                cmd.Parameters("@d9").Value = ComboBox9.Text
                cmd.Parameters("@d10").Value = ComboBox10.Text
                cmd.Parameters("@d11").Value = ComboBox11.Text

                cmd.ExecuteReader()
                MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Button1.Enabled = True
                Button2.Enabled = False
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

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub frmHawkerPaperTaken_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.HawkerMaster' table. You can move, or remove it, as needed.
        Me.HawkerMasterTableAdapter.Fill(Me.GyaDataSet.HawkerMaster)

        fillNewsPaperName()
        Button5.Enabled = False
        Button6.Enabled = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        clear()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update HawkerPaperTaken set [Hawker Name]=@d1,[Paper 1]=@d2,[Paper 2]=@d3,[Paper 3]=@d4,[Paper 4]=@d5,[Paper 5]=@d6,[Paper 6]=@d7,[Paper 7]=@d8,[Paper 8]=@d9,[Paper 9]=@d10,[Paper 10]=@d11 where HawkerCode=@d12"

            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Paper 1]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "[Paper 2]"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "[Paper 3]"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "[Paper 4]"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "[Paper 5]"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "[Paper 6]"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "[Paper 7]"))
            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "[Paper 8]"))
            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "[Paper 9]"))
            cmd.Parameters.Add(New SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "[Paper 10]"))
            cmd.Parameters.Add(New SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "HawkerCode"))
            cmd.Parameters("@d1").Value = ComboBox1.Text
            cmd.Parameters("@d2").Value = ComboBox2.Text
            cmd.Parameters("@d3").Value = ComboBox3.Text
            cmd.Parameters("@d4").Value = ComboBox4.Text
            cmd.Parameters("@d5").Value = ComboBox5.Text
            cmd.Parameters("@d6").Value = ComboBox6.Text
            cmd.Parameters("@d7").Value = ComboBox7.Text
            cmd.Parameters("@d8").Value = ComboBox8.Text
            cmd.Parameters("@d9").Value = ComboBox9.Text
            cmd.Parameters("@d10").Value = ComboBox10.Text
            cmd.Parameters("@d11").Value = ComboBox11.Text
            cmd.Parameters("@d12").Value = ComboBox12.Text

            cmd.ExecuteReader()
            MessageBox.Show("Successfully updated", "Hawker paper Taken Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button5.Enabled = False
            Button6.Enabled = False
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = True
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button5.Enabled = True
        'Button6.Enabled = True
        Button1.Enabled = False
        Button3.Enabled = True
        Button2.Enabled = False
        Me.Hide()
        clear()

        frmHawkerPaperTakenRecord.Show()
    End Sub
End Class