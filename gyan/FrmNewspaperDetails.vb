Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class FrmNewspaperDetails
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub auto()
        TextBox9.Text = "NP-" & GetUniqueKey(3)

    End Sub
   
    Private Sub delete_records()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq1 As String = "delete from NewspaperMaster where [Newspaper Code]=@DELETE1;"
            cmd = New SqlCommand(cq1)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 10, "[Newspaper Code]"))
            cmd.Parameters("@DELETE1").Value = Trim(TextBox9.Text)
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
    Public Shared Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        chars = "123456789".ToCharArray()
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function

    Public Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = "" 
        TextBox9.Text = ""
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub
  
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clear()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Len(Trim(TextBox3.Text)) = 0 Then
            MessageBox.Show("Please enter Newspaper Code", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please enter Newspaper Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If

        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter  Rate", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox4.Text)) = 0 Then
            MessageBox.Show("Please enter Newspaper Code", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox5.Text)) = 0 Then
            MessageBox.Show("Please enter Newspaper Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Exit Sub
        End If

        If Len(Trim(TextBox6.Text)) = 0 Then
            MessageBox.Show("Please enter  Rate", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox7.Text)) = 0 Then
            MessageBox.Show("Please enter Newspaper Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Exit Sub
        End If

        If Len(Trim(TextBox8.Text)) = 0 Then
            MessageBox.Show("Please enter  Rate", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox8.Focus()
            Exit Sub
        End If
        Try


            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select [Newspaper Name] from NewspaperMaster where [Newspaper Name]=@find"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 20, "[Newspaper Name]"))
            cmd.Parameters("@find").Value = TextBox1.Text
            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Newspaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                If Not rdr Is Nothing Then
                    rdr.Close()
                End If

            Else
                con = New SqlConnection(cs)
                con.Open()

                Dim cb As String = "insert into NewspaperMaster([Newspaper Code], [Newspaper Name], Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"

                cmd = New SqlCommand(cb)

                cmd.Connection = con


                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "[Newspaper Code]"))

                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Newspaper Name]"))

                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.SmallMoney, 10, " Sunday"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.SmallMoney, 10, " Monday"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.SmallMoney, 10, " Tuesday"))
                cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.SmallMoney, 10, " Wednesday"))
                cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.SmallMoney, 10, " Thursday"))
                cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.SmallMoney, 10, " Friday"))
                cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.SmallMoney, 10, " Saturday"))


                cmd.Parameters("@d1").Value = TextBox9.Text
                cmd.Parameters("@d2").Value = TextBox1.Text

                cmd.Parameters("@d3").Value = TextBox2.Text

                cmd.Parameters("@d4").Value = TextBox3.Text
                cmd.Parameters("@d5").Value = TextBox4.Text

                cmd.Parameters("@d6").Value = TextBox5.Text

                cmd.Parameters("@d7").Value = TextBox6.Text
                cmd.Parameters("@d8").Value = TextBox7.Text

                cmd.Parameters("@d9").Value = TextBox8.Text



                cmd.ExecuteReader()
                MessageBox.Show("Successfully saved", "Newspaper Details", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    
    Private Sub FrmNewspaperDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button5.Enabled = True
        Button2.Enabled = True
        ' Button6.Enabled = True
        Button1.Enabled = False
        Button3.Enabled = False
        Me.Hide()
        clear()

        frmNewsPaperRecord.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update NewspaperMaster set [Newspaper Code]=@d1, Sunday=@d3, Monday=@d4, Tuesday=@d5, Wednesday=@d6, Thursday=@d7, Friday=@d8, Saturday=@d9 where [Newspaper Name]=@d2"

            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "[Newspaper Code]"))

            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Newspaper Name]"))

            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.SmallMoney, 10, " Sunday"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.SmallMoney, 10, " Monday"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.SmallMoney, 10, " Tuesday"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.SmallMoney, 10, " Wednesday"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.SmallMoney, 10, " Thursday"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.SmallMoney, 10, " Friday"))
            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.SmallMoney, 10, " Saturday"))


            cmd.Parameters("@d1").Value = TextBox9.Text
            cmd.Parameters("@d2").Value = TextBox1.Text

            cmd.Parameters("@d3").Value = TextBox2.Text

            cmd.Parameters("@d4").Value = TextBox3.Text
            cmd.Parameters("@d5").Value = TextBox4.Text

            cmd.Parameters("@d6").Value = TextBox5.Text

            cmd.Parameters("@d7").Value = TextBox6.Text
            cmd.Parameters("@d8").Value = TextBox7.Text

            cmd.Parameters("@d9").Value = TextBox8.Text


            cmd.ExecuteReader()
            MessageBox.Show("Successfully Updated", "Newspaper Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        ' Try
        'con = New SqlConnection(cs)
        'con.Open()
        'Dim cb As String = "update CustomerAttendanceEntry set Rate=@d3 where [Paper Name]=@d2"
        'cmd = New SqlCommand(cb)

        '        cmd.Connection = con


        'cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Paper Name]"))
        'cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.SmallMoney, 10, "Rate"))

        '        cmd.Parameters("@d2").Value = TextBox1.Text
        '       cmd.Parameters("@d3").Value = TextBox2.Text


        'cmd.ExecuteReader()
        'MessageBox.Show("Successfully updated", "NewsPaper Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
       
        ' If con.State = ConnectionState.Open Then

        'con.Close()
        'End If

        'con.Close()

        'Catch ex As Exception
        'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If MessageBox.Show("Do you really want to delete the record?", "Course Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                delete_records()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class