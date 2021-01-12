Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class frmChangeBill
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As New DataTable
    Dim dtable As DataTable
    Dim cs As String = "Data Source=.\SQLEXPRESS;Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf;User Instance=True"
    Sub clear()
        TextBox4.Text = ""
        TextBox1.Text = ""
        TextBox6.Text = ""
        TextBox3.Text = ""
        ComboBox7.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""

        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox2.Text = ""
        'ComboBox6.Text = ""
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button5.Enabled = True
        Button2.Enabled = True
        Button6.Enabled = True
        Button1.Enabled = False
        Button3.Enabled = False
        Me.Hide()
        clear()

        frmBillChange.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update tblCustomerAttendance1 set No=@d3,Total=@d4  where [Customer ID]=@d1 and [Customer Name]=@d2 and [Paper name]=@d5"

            cmd = New SqlCommand(cb)

            cmd.Connection = con


            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "[Customer ID]"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Customer Name]"))
           

            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "[Paper Name]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.Int, 2, "No"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Money, 10, "Total"))





            cmd.Parameters("@d1").Value = TextBox4.Text

            cmd.Parameters("@d2").Value = TextBox1.Text
         

            cmd.Parameters("@d5").Value = ComboBox1.Text
            cmd.Parameters("@d3").Value = TextBox5.Text

            cmd.Parameters("@d4").Value = TextBox7.Text
         


            cmd.ExecuteReader()
            MessageBox.Show("Successfully updated", "Customer Bill", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If MessageBox.Show("Do you really want to print the Bill?", "Changed Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                frmPrintChange.Show()

            End If
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clear()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class