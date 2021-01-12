Imports System.Data.SqlClient
Imports System.Text

Public Class frmHawkerReturn
    Dim rdr As SqlDataReader = Nothing
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"
    Private Sub frmHawkerReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.HawkerPaperSupply' table. You can move, or remove it, as needed.
        Me.HawkerPaperSupplyTableAdapter.Fill(Me.GyaDataSet.HawkerPaperSupply)

    End Sub
    Sub clear()
        ComboBox1.Text = ""
        TextBox10.Text = ""
        TextBox2.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
        If Len(Trim(TextBox21.Text)) = 0 Then
            MessageBox.Show("Please enter Year", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox21.Focus()
            Exit Sub
        End If

        If Len(Trim(ComboBox1.Text)) = 0 Then
            MessageBox.Show("Please enter Hawker Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If
        Try
            If Len(Trim(TextBox11.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label2.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label2.Text
                        cmd.Parameters("@d4").Value = TextBox1.Text
                        cmd.Parameters("@d5").Value = TextBox11.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If

                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox1.Text
                            cmd.Parameters("@d7").Value = TextBox11.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label2.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                       
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            If Len(Trim(TextBox12.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label3.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label3.Text
                        cmd.Parameters("@d4").Value = TextBox2.Text
                        cmd.Parameters("@d5").Value = TextBox12.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox2.Text
                            cmd.Parameters("@d7").Value = TextBox12.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label3.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            If Len(Trim(TextBox13.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label4.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label4.Text
                        cmd.Parameters("@d4").Value = TextBox3.Text
                        cmd.Parameters("@d5").Value = TextBox13.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox3.Text
                            cmd.Parameters("@d7").Value = TextBox13.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label4.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            If Len(Trim(TextBox14.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label5.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label5.Text
                        cmd.Parameters("@d4").Value = TextBox4.Text
                        cmd.Parameters("@d5").Value = TextBox14.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox4.Text
                            cmd.Parameters("@d7").Value = TextBox14.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label5.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            If Len(Trim(TextBox15.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label6.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label6.Text
                        cmd.Parameters("@d4").Value = TextBox5.Text
                        cmd.Parameters("@d5").Value = TextBox15.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox5.Text
                            cmd.Parameters("@d7").Value = TextBox15.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label6.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            If Len(Trim(TextBox16.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label7.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label7.Text
                        cmd.Parameters("@d4").Value = TextBox6.Text
                        cmd.Parameters("@d5").Value = TextBox16.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox6.Text
                            cmd.Parameters("@d7").Value = TextBox16.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label7.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            If Len(Trim(TextBox17.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label8.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label8.Text
                        cmd.Parameters("@d4").Value = TextBox7.Text
                        cmd.Parameters("@d5").Value = TextBox17.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox7.Text
                            cmd.Parameters("@d7").Value = TextBox17.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label8.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            If Len(Trim(TextBox18.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label9.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label9.Text
                        cmd.Parameters("@d4").Value = TextBox8.Text
                        cmd.Parameters("@d5").Value = TextBox18.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox8.Text
                            cmd.Parameters("@d7").Value = TextBox18.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label9.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
            If Len(Trim(TextBox19.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label10.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label10.Text
                        cmd.Parameters("@d4").Value = TextBox9.Text
                        cmd.Parameters("@d5").Value = TextBox19.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox9.Text
                            cmd.Parameters("@d7").Value = TextBox19.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label10.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
            If Len(Trim(TextBox20.Text)) > 0 Then
                Try


                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Date,[Hawker Name],NewsPaper from HawkerPaperReturn where Date=@find and [Hawker Name]=@a1 and NewsPaper=@a2"

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.DateTime2, 10, "Date"))
                    cmd.Parameters.Add(New SqlParameter("@a1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                    cmd.Parameters.Add(New SqlParameter("@a2", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                    cmd.Parameters("@a2").Value = Label11.Text()
                    cmd.Parameters("@find").Value = DateTimePicker1.Text()
                    cmd.Parameters("@a1").Value = ComboBox1.Text()
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        MessageBox.Show("Hawker Code with NewsPaper Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ComboBox1.Text = ""
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                    Else



                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "insert into HawkerPaperReturn(Date,Month,[Hawker Name],NewsPaper,Taken,[Return]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5)"

                        ' Dim cb As String = "insert into HawkerPaperTaken(HawkerCode,[Hawker Name],[Paper 1],[Paper 2],[Paper 3],[Paper 4],[Paper 5],[Paper 6],[Paper 7],[Paper 8],[Paper 9],[Paper 10]) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                        cmd = New SqlCommand(cb)

                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@d0", System.Data.SqlDbType.DateTime2, 10, "Date"))
                        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Month"))
                        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
                        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "NewsPaper"))
                        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.Int, 4, "Taken"))
                        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.Int, 4, "[Return]"))
                        cmd.Parameters("@d0").Value = DateTimePicker1.Text
                        cmd.Parameters("@d1").Value = TextBox21.Text
                        cmd.Parameters("@d2").Value = ComboBox1.Text
                        cmd.Parameters("@d3").Value = Label11.Text
                        cmd.Parameters("@d4").Value = TextBox10.Text
                        cmd.Parameters("@d5").Value = TextBox20.Text

                        cmd.ExecuteReader()
                        ' MessageBox.Show("Successfully saved", "Hawker Paper taken Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ca As String = "update tblExtraSold set Taken=@d6,[Return]=@d7  where Date=@d8 and HawkerName=@d9 and Newspaper=@d10"
                            cmd = New SqlCommand(ca)

                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.Int, 4, "Taken"))
                            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.Int, 4, "[Return]"))
                            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.Date, 7, "Date"))
                            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "HawkerName"))
                            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Newspaper"))
                            cmd.Parameters("@d6").Value = TextBox10.Text
                            cmd.Parameters("@d7").Value = TextBox20.Text
                            cmd.Parameters("@d8").Value = DateTimePicker1.Text
                            cmd.Parameters("@d9").Value = ComboBox1.Text
                            cmd.Parameters("@d10").Value = Label11.Text
                            cmd.ExecuteReader()
                            If con.State = ConnectionState.Open Then

                                con.Close()
                            End If

                            con.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        con.Close()
                    End If



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
            MessageBox.Show("Successfully saved", "Hawker Paper Return", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

       
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clear()

    End Sub
End Class