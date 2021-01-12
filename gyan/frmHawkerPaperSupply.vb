Imports System.Data.SqlClient
Imports System.Text
Public Class frmHawkerPaperSupply
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub frmHawkerPaperSupply_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox11.Text = Format(Now, "MMM-yyyy")
        'TODO: This line of code loads data into the 'GyaDataSet.HawkerPaperTaken' table. You can move, or remove it, as needed.
        Me.HawkerPaperTakenTableAdapter.Fill(Me.GyaDataSet.HawkerPaperTaken)





    End Sub
    Sub clear()

        TextBox10.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        ComboBox12.Text = ""
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       
      
        If Len(Trim(TextBox11.Text)) = 0 Then
            MessageBox.Show("Please enter Year", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox11.Focus()
            Exit Sub
        End If

        If Len(Trim(ComboBox1.Text)) = 0 Then
            MessageBox.Show("Please enter Hawker Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select HawkerCode,MonthYear from HawkerPaperSupply where HawkerCode=@find and MonthYear=@a1"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "HawkerCode"))
            cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 30, "MonthYear"))
            cmd.Parameters("@find").Value = ComboBox12.Text()
            cmd.Parameters("@a1").Value = TextBox11.Text()
            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Hawker Code and MonthYear Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ComboBox1.Text = ""
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            Else

                con = New SqlConnection(cs)
                con.Open()

                Dim cb As String = "insert into HawkerPaperSupply(MonthYear,HawkerCode,[Hawker Name],Paper,Taken,Paper1,Taken1,Paper2,Taken2,Paper3,Taken3,Paper4,Taken4,Paper5,Taken5,Paper6,Taken6,Paper7,Taken7,Paper8,Taken8,Paper9,Taken9) VALUES (@d2,@d1,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23)"

                cmd = New SqlCommand(cb)

                cmd.Connection = con

                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "MonthYear"))
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "HawkerCode"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Paper"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 3, "Taken"))
                cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "Paper1"))
                cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 3, "Taken1"))
                cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "Paper2"))
                cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 3, "Taken2"))
                cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Paper3"))
                cmd.Parameters.Add(New SqlParameter("@d11", System.Data.SqlDbType.NChar, 3, "Taken3"))
                cmd.Parameters.Add(New SqlParameter("@d12", System.Data.SqlDbType.NChar, 20, "Paper4"))
                cmd.Parameters.Add(New SqlParameter("@d13", System.Data.SqlDbType.NChar, 3, "Taken4"))
                cmd.Parameters.Add(New SqlParameter("@d14", System.Data.SqlDbType.NChar, 20, "Paper5"))
                cmd.Parameters.Add(New SqlParameter("@d15", System.Data.SqlDbType.NChar, 3, "Taken5"))
                cmd.Parameters.Add(New SqlParameter("@d16", System.Data.SqlDbType.NChar, 20, "Paper6"))
                cmd.Parameters.Add(New SqlParameter("@d17", System.Data.SqlDbType.NChar, 3, "Taken6"))
                cmd.Parameters.Add(New SqlParameter("@d18", System.Data.SqlDbType.NChar, 20, "Paper7"))
                cmd.Parameters.Add(New SqlParameter("@d19", System.Data.SqlDbType.NChar, 3, "Taken7"))
                cmd.Parameters.Add(New SqlParameter("@d20", System.Data.SqlDbType.NChar, 20, "Paper8"))
                cmd.Parameters.Add(New SqlParameter("@d21", System.Data.SqlDbType.NChar, 3, "Taken8"))
                cmd.Parameters.Add(New SqlParameter("@d22", System.Data.SqlDbType.NChar, 20, "Paper9"))
                cmd.Parameters.Add(New SqlParameter("@d23", System.Data.SqlDbType.NChar, 3, "Taken9"))


                cmd.Parameters("@d2").Value = TextBox11.Text
                cmd.Parameters("@d1").Value = ComboBox12.Text
                cmd.Parameters("@d3").Value = ComboBox1.Text
                cmd.Parameters("@d4").Value = Label2.Text
                cmd.Parameters("@d5").Value = TextBox1.Text
                cmd.Parameters("@d6").Value = Label3.Text
                cmd.Parameters("@d7").Value = TextBox2.Text
                cmd.Parameters("@d8").Value = Label4.Text
                cmd.Parameters("@d9").Value = TextBox3.Text
                cmd.Parameters("@d10").Value = Label5.Text
                cmd.Parameters("@d11").Value = TextBox4.Text
                cmd.Parameters("@d12").Value = Label6.Text
                cmd.Parameters("@d13").Value = TextBox5.Text
                cmd.Parameters("@d14").Value = Label7.Text
                cmd.Parameters("@d15").Value = TextBox6.Text
                cmd.Parameters("@d16").Value = Label8.Text
                cmd.Parameters("@d17").Value = TextBox7.Text
                cmd.Parameters("@d18").Value = Label9.Text
                cmd.Parameters("@d19").Value = TextBox8.Text
                cmd.Parameters("@d20").Value = Label10.Text
                cmd.Parameters("@d21").Value = TextBox9.Text
                cmd.Parameters("@d22").Value = Label11.Text
                cmd.Parameters("@d23").Value = TextBox10.Text
                cmd.ExecuteReader()
                MessageBox.Show("Successfully saved", "Hawker Paper Supply", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Button1.Enabled = False
                Button5.Enabled = False
                Button2.Enabled = True
                Button3.Enabled = True
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

                con.Close()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update HawkerPaperSupply set MonthYear=@d1,[Hawker Name]=@d2,Count=@d3,Count1=@d4,Count2=@d5,Count3=@d6,Count4=@d7,Count5=@d8,Count6=@d9,Count7=@d10,Count8=@d11,Count9=@d12 where HawkerCode=@d13"

            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "MonthYear"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))

            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 3, "Count"))

            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 3, "Count1"))

            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 3, "Count2"))

            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 3, "Count3"))

            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 3, "Count4"))

            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.NChar, 3, "Count5"))

            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 3, "Count6"))

            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 3, "Count7"))

            cmd.Parameters.Add(New SqlParameter("@d11", System.Data.SqlDbType.NChar, 3, "Count8"))

            cmd.Parameters.Add(New SqlParameter("@d12", System.Data.SqlDbType.NChar, 3, "Count9"))
            cmd.Parameters.Add(New SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "HawkerCode"))

            cmd.Parameters("@d1").Value = TextBox11.Text
            cmd.Parameters("@d2").Value = ComboBox1.Text

            cmd.Parameters("@d3").Value = TextBox1.Text

            cmd.Parameters("@d4").Value = TextBox2.Text

            cmd.Parameters("@d5").Value = TextBox3.Text

            cmd.Parameters("@d6").Value = TextBox4.Text

            cmd.Parameters("@d7").Value = TextBox5.Text

            cmd.Parameters("@d8").Value = TextBox6.Text

            cmd.Parameters("@d9").Value = TextBox7.Text

            cmd.Parameters("@d10").Value = TextBox8.Text

            cmd.Parameters("@d11").Value = TextBox9.Text

            cmd.Parameters("@d12").Value = TextBox10.Text
            cmd.Parameters("@d13").Value = ComboBox12.Text
            cmd.ExecuteReader()
            MessageBox.Show("Successfully updated", "Hawker paper Supply Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

  

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button5.Enabled = True
        Button2.Enabled = True
        ' Button6.Enabled = True
        Button1.Enabled = False
        Button3.Enabled = False
        Me.Hide()
        clear()

        frmHawkerPaperSupplyRecord.Show()
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clear()
        Button1.Enabled = True
        Button5.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub
End Class