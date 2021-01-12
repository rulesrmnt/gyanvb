Imports System.Data.SqlClient
Imports System.Text
Public Class frmCustomerAccount
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As New DataTable
    Dim dtable As DataTable
    Dim cs As String = "Data Source=.\SQLEXPRESS;Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf;User Instance=True"
    Public Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox7.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Text = Val(TextBox6.Text) + Val(TextBox7.Text)
        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into tblCustomerMoney(Month,[Customer Code],[Customer Name],Address,[Phone no],[Hawker Name],[NewsPaper Take],No,Rate,[Month Total],Balance,[Grand Total]) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"

            cmd = New SqlCommand(cb)

            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "[Customer Code]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "[Customer Name]"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 100, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "[Phone no]"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))

            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "[NewsPaper Take]"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.NChar, 2, "No"))
            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.Money, 10, "Rate"))
            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.Money, 10, "[Month Total]"))
            cmd.Parameters.Add(New SqlParameter("@d11", System.Data.SqlDbType.Money, 10, "Balance"))
            cmd.Parameters.Add(New SqlParameter("@d12", System.Data.SqlDbType.Money, 10, "[Grand Total]"))

            cmd.Parameters("@d1").Value = ComboBox2.Text
            cmd.Parameters("@d2").Value = TextBox4.Text

            cmd.Parameters("@d3").Value = TextBox1.Text

            cmd.Parameters("@d4").Value = TextBox8.Text

            cmd.Parameters("@d5").Value = TextBox3.Text

            cmd.Parameters("@d6").Value = ComboBox7.Text

            cmd.Parameters("@d7").Value = ComboBox1.Text
            cmd.Parameters("@d8").Value = TextBox5.Text
            cmd.Parameters("@d9").Value = TextBox9.Text
            cmd.Parameters("@d10").Value = TextBox6.Text

            cmd.Parameters("@d11").Value = TextBox7.Text
            cmd.Parameters("@d12").Value = TextBox2.Text
            cmd.ExecuteReader()

            MessageBox.Show("Successfully saved", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button5.Enabled = False
            Button6.Enabled = False
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
        Button6.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = True
        Me.Hide()
        clear()

        frmDailyRecord.Show()
    End Sub

    Private Sub frmCustomerAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    End Sub
End Class