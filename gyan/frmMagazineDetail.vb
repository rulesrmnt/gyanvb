Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class frmMagazineDetail
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
            Dim cq1 As String = "delete from tblMagzineDetail where MagzineCode=@DELETE1;"
            cmd = New SqlCommand(cq1)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 10, "MagzineCode"))


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
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please enter Magazine Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If

        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter  Rate", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If



        Try
            'auto()

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select MagazineName from tblMagazineDetail where MagazineName=@find"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 20, "MagazineName"))
            cmd.Parameters("@find").Value = TextBox1.Text
            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Magazine Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                If Not rdr Is Nothing Then
                    rdr.Close()
                End If

            Else
                con = New SqlConnection(cs)
                con.Open()

                Dim cb As String = "insert into tblMagazineDetail(MagazineCode,MagazineName,Rate) VALUES (@d1,@d3,@d4)"

                cmd = New SqlCommand(cb)

                cmd.Connection = con


                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "MagazineCode"))

                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "MagazineName"))

                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Money, 10, " Rate"))


                cmd.Parameters("@d1").Value = TextBox9.Text
                cmd.Parameters("@d3").Value = TextBox1.Text

                cmd.Parameters("@d4").Value = TextBox2.Text



                cmd.ExecuteReader()
                MessageBox.Show("Successfully saved", "Magazine Details", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
        'Button5.Enabled = True
        Button2.Enabled = True
        ' Button6.Enabled = True
        Button1.Enabled = False
        Button3.Enabled = False
        Me.Hide()
        clear()

        frmMagazineRecord.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update tblMagazineDetail set MagazineCode=@d1,Rate=@d3 where MagazineName=@d2"

            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "MagazineCode"))

            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "MagazineName"))

            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Money, 10, " Rate"))
            cmd.Parameters("@d1").Value = TextBox9.Text
            cmd.Parameters("@d2").Value = TextBox1.Text
            cmd.Parameters("@d3").Value = TextBox2.Text


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
            Dim cb As String = "update CustomerAttendanceEntry set Rate=@d3 where [Paper Name]=@d2"
            cmd = New SqlCommand(cb)

            cmd.Connection = con


            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Paper Name]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Money, 10, "Rate"))

            cmd.Parameters("@d2").Value = TextBox1.Text
            cmd.Parameters("@d3").Value = TextBox2.Text


            cmd.ExecuteReader()
            MessageBox.Show("Successfully updated", "NewsPaper Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If MessageBox.Show("Do you really want to delete the record?", "Course Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                delete_records()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class