Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class frmCusExtraPaper
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
        'TextBox6.Text = ""
        TextBox3.Text = ""
        ComboBox7.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        'TextBox5.Text = ""
    End Sub
    Sub clear1()
        TextBox4.Text = ""
        TextBox1.Text = ""
        'TextBox6.Text = ""
        TextBox3.Text = ""
        ComboBox7.Text = ""
        'ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        'ComboBox4.Text = ""
        'TextBox5.Text = ""
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = False
        Me.Hide()
        clear1()

        frmCustomerEntryRecord1.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please enter Customer Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If
        If Len(Trim(ComboBox2.Text)) = 0 Then
            MessageBox.Show("Please Enter Customer Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox2.Focus()
            Exit Sub

        End If
        If Len(TextBox3.Text) = 0 Then
            MessageBox.Show("Please Enter Phone No", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Exit Sub
        End If



        Try


            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into CustomerMaster([Customer Code],[Customer Name],Address,AreaCode,[Phone no],[Hawker Name],[NewsPaper Take],No,Balance) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d10)"

            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "[Customer Code]"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Customer Name]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "AreaCode"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "[Phone no]"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))

            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "[NewsPaper Take]"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Int, 2, "No"))
            ' cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.Money, 10, "Rate"))
            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.Money, 10, "Balance"))
            cmd.Parameters("@d1").Value = TextBox4.Text
            cmd.Parameters("@d2").Value = TextBox1.Text

            cmd.Parameters("@d3").Value = ComboBox2.Text

            cmd.Parameters("@d4").Value = ComboBox3.Text

            cmd.Parameters("@d5").Value = TextBox3.Text

            cmd.Parameters("@d6").Value = ComboBox7.Text

            cmd.Parameters("@d7").Value = ComboBox1.Text
            cmd.Parameters("@d8").Value = TextBox5.Text

            'cmd.Parameters("@d9").Value = ComboBox4.Text
            cmd.Parameters("@d10").Value = TextBox6.Text
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

            Dim cb As String = "insert into CustomerAttendanceEntry ([Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Balance)VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d10)"
            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "[Customer ID]"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Customer Name]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "AreaCode"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "[Phone no]"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))

            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "[Paper Name]"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Int, 2, "No"))
            ' cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.Money, 10, "Rate"))
            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.Money, 10, "Balance"))


            cmd.Parameters("@d1").Value = TextBox4.Text
            cmd.Parameters("@d2").Value = TextBox1.Text

            cmd.Parameters("@d3").Value = ComboBox2.Text

            cmd.Parameters("@d4").Value = ComboBox3.Text
            cmd.Parameters("@d5").Value = TextBox3.Text

            cmd.Parameters("@d6").Value = ComboBox7.Text

            cmd.Parameters("@d7").Value = ComboBox1.Text
            cmd.Parameters("@d8").Value = TextBox5.Text

            'cmd.Parameters("@d9").Value = ComboBox4.Text
            cmd.Parameters("@d10").Value = TextBox6.Text

            cmd.ExecuteReader()

            MessageBox.Show("Successfully saved", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Button3.Enabled = False
    End Sub

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub frmCusExtraPaper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.NewspaperMaster' table. You can move, or remove it, as needed.
        Me.NewspaperMasterTableAdapter.Fill(Me.GyaDataSet.NewspaperMaster)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class