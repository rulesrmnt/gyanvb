Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class frmCustomerMaster1
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As New DataTable
    Dim dtable As DataTable
    Dim cs As String = "Data Source=.\SQLEXPRESS;Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf;User Instance=True"
    Private Sub auto()
        TextBox4.Text = "CUS-" & GetUniqueKey(6)
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
    Private Sub delete_records()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq1 As String = "delete from CustomerMaster where [Customer Code]=@DELETE1;"
            cmd = New SqlCommand(cq1)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 10, "[Customer Code]"))
            cmd.Parameters("@DELETE1").Value = Trim(TextBox4.Text)
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
        TextBox4.Text = ""
        TextBox1.Text = ""
        TextBox6.Text = ""
        TextBox3.Text = ""
        ComboBox7.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        TextBox5.Text = ""
        'ComboBox6.Text = ""
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
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
    

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

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

        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select AreaCode from CustomerMaster where AreaCode=@find "
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "AreaCode"))
        'cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
        cmd.Parameters("@find").Value = ComboBox3.Text()
        ' cmd.Parameters("@d1").Value = ComboBox1.Text
        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Already saved Customer of this area code", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Else

            Try
                auto()

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

                ' cmd.Parameters("@d9").Value = ComboBox4.Text
                cmd.Parameters("@d10").Value = TextBox6.Text

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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update CustomerAttendanceEntry set Address=@d3,AreaCode=@d4,[Phone No]=@d5,[Hawker Name]=@d6,[Paper Name]=@d7,No=@d8,Rate=@d9,Balance=@d10  where [Customer ID]='" & TextBox4.Text & "'  and [Customer Name]='" & TextBox1.Text & "'"
            cmd = New SqlCommand(cb)

            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "AreaCode"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "[Phone no]"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))

            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "[Paper Name]"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Int, 2, "No"))
            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.Money, 10, "Rate"))
            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.Money, 10, "Balance"))


          

            cmd.Parameters("@d3").Value = ComboBox2.Text

            cmd.Parameters("@d4").Value = ComboBox3.Text
            cmd.Parameters("@d5").Value = TextBox3.Text

            cmd.Parameters("@d6").Value = ComboBox7.Text

            cmd.Parameters("@d7").Value = ComboBox1.Text
            cmd.Parameters("@d8").Value = TextBox5.Text

            cmd.Parameters("@d9").Value = ComboBox4.Text
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

            Dim cb As String = "update CustomerMaster set Address=@d3,AreaCode=@d4,[Phone No]=@d5,[Hawker Name]=@d6,[NewsPaper Take]=@d7,No=@d8,Rate=@d9,Balance=@d10  where [Customer Code]=@d1 and [Customer Name]=@d2"

            cmd = New SqlCommand(cb)

            cmd.Connection = con


            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "[Customer Code]"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "[Customer Name]"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "AreaCode"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "[Phone no]"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))

            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "[NewsPaper Take]"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Int, 2, "No"))
            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.Money, 10, "Rate"))
            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.Money, 10, "Balance"))




            cmd.Parameters("@d3").Value = ComboBox2.Text

            cmd.Parameters("@d4").Value = ComboBox3.Text
            cmd.Parameters("@d5").Value = TextBox3.Text

            cmd.Parameters("@d6").Value = ComboBox7.Text

            cmd.Parameters("@d7").Value = ComboBox1.Text
            cmd.Parameters("@d8").Value = TextBox5.Text

            cmd.Parameters("@d9").Value = ComboBox4.Text
            cmd.Parameters("@d10").Value = TextBox6.Text
            cmd.Parameters("@d1").Value = TextBox4.Text
            cmd.Parameters("@d2").Value = TextBox1.Text


            cmd.ExecuteReader()
            MessageBox.Show("Successfully updated", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        'frmPasword.Show()
        'If frmPasword.TextBox1.Text = True Then
        Try
            If MessageBox.Show("Do you really want to delete the record?", "Hawker Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                delete_records()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' Button5.Enabled = True
        Button2.Enabled = True
       ' Button6.Enabled = True
        Button1.Enabled = False
        Button3.Enabled = False
        Me.Hide()
        clear()

        frmCustomerEntryRecord3.Show()
    End Sub

    Private Sub frmCustomerMaster1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.NewspaperMaster' table. You can move, or remove it, as needed.
        Me.NewspaperMasterTableAdapter.Fill(Me.GyaDataSet.NewspaperMaster)
        'TODO: This line of code loads data into the 'GyaDataSet.tblAreaMaster' table. You can move, or remove it, as needed.
        Me.TblAreaMasterTableAdapter.Fill(Me.GyaDataSet.tblAreaMaster)

    End Sub
End Class