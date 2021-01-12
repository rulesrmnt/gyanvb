Imports System.Data.SqlClient
Imports System
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data
Public Class frmCustomerAttendance
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cmdb1 As New SqlCommandBuilder
    Protected Const PROD = "CustomerAttendanceEntry"

    Protected Const CONN = ""
    Protected dsSearchResults As DataSet
    Protected dsCodeTables As DataSet
    Protected intCurrentRec As Integer
    Protected myBindingManagerBase As BindingManagerBase
    Dim cs As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;"

    Private ReadOnly Property Connection() As SqlConnection
        Get
            Dim ConnectionToFetch As New SqlConnection(cs)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property
    Public Function GetData() As DataView
        Dim SelectQry = "SELECT Date, [Customer ID], [Customer Name], P, T, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, [Hawker Name] FROM CustomerAttendanceEntry order by Date"

        Dim SampleSource As New DataSet
        Dim TableView As DataView
        Try
            Dim SampleCommand As New SqlCommand()
            Dim SampleDataAdapter = New SqlDataAdapter()
            SampleCommand.CommandText = SelectQry
            SampleCommand.Connection = Connection
            SampleDataAdapter.SelectCommand = SampleCommand
            SampleDataAdapter.Fill(SampleSource)
            TableView = SampleSource.Tables(0).DefaultView
        Catch ex As Exception
            Throw ex
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return TableView
    End Function
    Private Sub delete_records()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq1 As String = "delete from tblCustomerAttendance where Date=@DELETE1;"
            cmd = New SqlCommand(cq1)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.Date, 10, "Date"))
            cmd.Parameters("@DELETE1").Value = Trim(DateTimePicker1.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
   

    Private Sub frmCustomerAttendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GyaDataSet.CustomerAttendanceEntry' table. You can move, or remove it, as needed.
        Me.CustomerAttendanceEntryTableAdapter.Fill(Me.GyaDataSet.CustomerAttendanceEntry)

        TextBox1.Text = Format(DateTimePicker1.Value, "MMM-yyyy")

        TextBox2.Text = Format(DateTimePicker2.Value, "MMM-yyyy")
        TextBox3.Text = Format(DateTimePicker1.Value, "dddd")
        ComboBox2.Text = Format(DateTimePicker2.Value, "dddd")
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
        Try
            If TextBox3.Text = "Sunday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Sunday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Monday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Monday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Tuesday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Tuesday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Wednesday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Wednesday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Thursday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Thursday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Friday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Friday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Saturday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Saturday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
            Try

                con = New SqlConnection(cs)

                con.Open()
                cmd = New SqlCommand("SELECT [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, No * Rate AS Total, Balance FROM CustomerAttendanceEntry GROUP BY [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, Total, Balance  ", con)
                Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

                Dim myDataSet As DataSet = New DataSet()

                myDA.Fill(myDataSet, "CustomerAttendanceEntry")

                DataGridView2.DataSource = myDataSet.Tables("CustomerAttendanceEntry").DefaultView

                con.Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            If ComboBox2.Text = "Sunday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Sunday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Monday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Monday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Tuesday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Tuesday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Wednesday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Wednesday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Thursday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Thursday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Friday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Friday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Saturday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Saturday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
            Try

                con = New SqlConnection(cs)

                con.Open()
                cmd = New SqlCommand("SELECT [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, No * Rate AS Total, Balance FROM CustomerAttendanceEntry GROUP BY [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, Total, Balance  ", con)
                Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

                Dim myDataSet As DataSet = New DataSet()

                myDA.Fill(myDataSet, "CustomerAttendanceEntry")

                DataGridView1.DataSource = myDataSet.Tables("CustomerAttendanceEntry").DefaultView

                con.Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        DataGridView2.DataSource = GetData()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If Len(Trim(DateTimePicker1.Text)) = 0 Then
            MessageBox.Show("Please enter Date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Exit Sub
        End If
        If Len(Trim(ComboBox1.Text)) = 0 Then
            MessageBox.Show("Please enter Hawker Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please enter Month", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Date from tblCustomerAttendance where Date=@find and [Hawker Name]=@d1 "
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.Date, 20, "Date"))
        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
        cmd.Parameters("@find").Value = DateTimePicker1.Text
        cmd.Parameters("@d1").Value = ComboBox1.Text
        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Already saved attendance of this date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Else
            ' Try
            'Dim iCell1 As Integer
            'Dim icell2 As Integer

            'Dim icellResult As Integer
            ' For i As Integer = 0 To Me.DataGridView2.Rows.Count - 1
            '
            ' iCell1 = Me.DataGridView2.Rows(i).Cells(7).Value
            ' icell2 = Me.DataGridView2.Rows(i).Cells(8).Value
            '

            ' icellResult = iCell1 * icell2
            '  Me.DataGridView2.Rows(i).Cells(9).Value = icellResult

            ' Next

            '  Catch ex As Exception
            'MessageBox.Show(ex.ToString)
            'End Try
            '
            Try

                con = New SqlConnection(cs)
                con.Open()

                'Dim cm As String = "insert into [Customer Attendance] (Date,Day,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30) select @d1,@d2,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30 from datagridview2 "

                Dim cm As String = "insert  tblCustomerAttendance (Date,Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Total,Balance) select @d1,@d2,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,No*Rate AS Total,Balance from CustomerAttendanceEntry where CustomerAttendanceEntry.[Hawker Name]= '" & ComboBox1.Text & "' "
                'Dim ca As String = "insert  tblCustomerAttendance1 (Date,Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Balance) select @d1,@d2,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Balance from CustomerAttendanceEntry "
                cmd = New SqlCommand(cm)
                'cmd = New SqlCommand(ca)

                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.Date, 10, "Date"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Month"))
                cmd.Parameters("@d1").Value = DateTimePicker1.Text
                cmd.Parameters("@d2").Value = TextBox1.Text
                cmd.ExecuteReader()
                ' MessageBox.Show("Successfully Saved", "Customer Entry for Today", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    'Dim cm As String = "insert into [Customer Attendance] (Date,Day,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30) select @d1,@d2,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30 from datagridview2 "

                    Dim ca As String = "insert  tblExtraSold (Date,HawkerName,Newspaper,Sold) select @d1,[Hawker Name],[Paper Name],Sum(No) As No from CustomerAttendanceEntry where CustomerAttendanceEntry.[Hawker Name]= '" & ComboBox1.Text & "' GROUP BY CustomerAttendanceEntry.[Paper Name],CustomerAttendanceEntry.[Hawker Name] "
                    ' Dim ca As String = "insert  tblCustomerAttendance1 (Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Total,Balance) SELECT Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name],[Paper Name], SUM(No) AS No, SUM(Total) AS Total, Balance from tblCustomerAttendance GROUP BY Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name],[Paper Name],Balance "
                    'cmd = New SqlCommand(cm)
                    'Dim ca As String = "insert  tblCustomerAttendance1 (Date,Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Balance) select @d1,@d2,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Balance from CustomerAttendanceEntry "
                    cmd = New SqlCommand(ca)
                    'cmd = New SqlCommand(ca)

                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.Date, 10, "Date"))

                    cmd.Parameters("@d1").Value = DateTimePicker1.Text

                    cmd.ExecuteReader()
                    MessageBox.Show("Successfully Saved", "Customer Entry for Today", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If

                    con.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                con.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            
        End If

    End Sub
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)


    End Sub



    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox1.Text = Format(DateTimePicker1.Value, "MMM-yyyy")


        TextBox3.Text = Format(DateTimePicker1.Value, "dddd")
        Try
            If TextBox3.Text = "Sunday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Sunday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Monday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Monday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Tuesday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Tuesday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Wednesday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Wednesday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Thursday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Thursday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Friday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Friday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf TextBox3.Text = "Saturday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Saturday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
            Try

                con = New SqlConnection(cs)

                con.Open()
                cmd = New SqlCommand("SELECT [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, No * Rate AS Total, Balance FROM CustomerAttendanceEntry GROUP BY [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, Total, Balance  ", con)
                Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

                Dim myDataSet As DataSet = New DataSet()

                myDA.Fill(myDataSet, "CustomerAttendanceEntry")

                DataGridView2.DataSource = myDataSet.Tables("CustomerAttendanceEntry").DefaultView

                con.Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub UpdateDatabase1()

        Dim myFirstRow As DataRow = GyaDataSet.CustomerAttendanceEntry.Rows(7)
        Dim RecordsUpdated As Integer
        If GyaDataSet.HasChanges Then
            ' Update any customer table changes. 
            myFirstRow.BeginEdit()
            myFirstRow("No") = "90210"
            myFirstRow.EndEdit()

            GyaDataSet.CustomerAttendanceEntry.AcceptChanges()
            RecordsUpdated = Me.CustomerAttendanceEntryTableAdapter.Update(GyaDataSet)

            MessageBox.Show(RecordsUpdated.ToString & " customer record(s) updated.")

            ' Refresh the grid.          

        Else
            MessageBox.Show("There are no changed records to update.")
        End If
        ' Me.CustomerAttendanceEntryTableAdapter.Update(Me.GyaDataSet.CustomerAttendanceEntry)
        ' MsgBox("Update successful")



    End Sub




    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim dtable As DataTable = ds.Tables("CustomerAttendanceEntry")
            Me.CustomerAttendanceEntryBindingSource.EndEdit()
            Me.adp.Update(dtable)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Len(Trim(DateTimePicker2.Text)) = 0 Then
            MessageBox.Show("Please enter Date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker2.Focus()
            Exit Sub
        End If
        
        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter Month", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Date from tblCustomerAttendance where Date=@find and [Hawker Name]=@d1"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.Date, 20, "Date"))
        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "[Hawker Name]"))
        cmd.Parameters("@find").Value = DateTimePicker1.Text
        cmd.Parameters("@d1").Value = ComboBox1.Text
        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Already saved attendance of this date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Else
          
            Try

                con = New SqlConnection(cs)
                con.Open()

                'Dim cm As String = "insert into [Customer Attendance] (Date,Day,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30) select @d1,@d2,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30 from datagridview2 "

                Dim cm As String = "insert  tblCustomerAttendance (Date,Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Total,Balance) select @d1,@d2,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,No*Rate AS Total,Balance from CustomerAttendanceEntry  "
                'Dim ca As String = "insert  tblCustomerAttendance1 (Date,Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Balance) select @d1,@d2,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Balance from CustomerAttendanceEntry "
                cmd = New SqlCommand(cm)
                'cmd = New SqlCommand(ca)

                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.Date, 10, "Date"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Month"))
                cmd.Parameters("@d1").Value = DateTimePicker1.Text
                cmd.Parameters("@d2").Value = TextBox1.Text
                cmd.ExecuteReader()
                'MessageBox.Show("Successfully Saved", "Customer Entry for Today", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    'Dim cm As String = "insert into [Customer Attendance] (Date,Day,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30) select @d1,@d2,[Customer ID],[Customer Name],P,N,P1,N1,P2,N2,P3,N3,P4,N4,P5,N5,P6,N6,P7,N7,P8,N8,P9,N9,P10,N10,P11,N11,P12,N12,P13,N13,P14,N14,P15,N15,P16,N16,P17,N17,P18,N18,P19,N19,P20,N20,P21,N21,P22,N22,P23,N23,P24,N24,P25,N25,P26,N26,P27,N27,P28,N28,P29,N29,P30,N30 from datagridview2 "

                    Dim ca As String = "insert  tblExtraSold (Date,HawkerName,Newspaper,Sold) select @d1,[Hawker Name],[Paper Name],Sum(No) As No from CustomerAttendanceEntry  GROUP BY CustomerAttendanceEntry.[Paper Name],CustomerAttendanceEntry.[Hawker Name] "
                    ' Dim ca As String = "insert  tblCustomerAttendance1 (Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Total,Balance) SELECT Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name],[Paper Name], SUM(No) AS No, SUM(Total) AS Total, Balance from tblCustomerAttendance GROUP BY Month, [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name],[Paper Name],Balance "
                    'cmd = New SqlCommand(cm)
                    'Dim ca As String = "insert  tblCustomerAttendance1 (Date,Month,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Balance) select @d1,@d2,[Customer ID],[Customer Name],Address,AreaCode,[Phone No],[Hawker Name],[Paper Name],No,Rate,Balance from CustomerAttendanceEntry "
                    cmd = New SqlCommand(ca)
                    'cmd = New SqlCommand(ca)

                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.Date, 10, "Date"))

                    cmd.Parameters("@d1").Value = DateTimePicker1.Text

                    cmd.ExecuteReader()
                    MessageBox.Show("Successfully Saved", "Customer Entry for Today", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If

                    con.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                con.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)

            con.Open()
            cmd = New SqlCommand("SELECT [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, No * Rate AS Total, Balance FROM CustomerAttendanceEntry where  [Hawker Name]='" & ComboBox1.Text & "' GROUP BY [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, Total, Balance  ", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "CustomerAttendanceEntry")

            DataGridView2.DataSource = myDataSet.Tables("CustomerAttendanceEntry").DefaultView

            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button2_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        TextBox2.Text = Format(DateTimePicker2.Value, "MMM-yyyy")


        ComboBox2.Text = Format(DateTimePicker2.Value, "dddd")
        Try
            If ComboBox2.Text = "Sunday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Sunday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Monday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Monday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Tuesday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Tuesday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Wednesday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Wednesday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Thursday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Thursday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Friday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Friday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf ComboBox2.Text = "Saturday" Then
                Try

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb As String = "update CustomerAttendanceEntry set Rate=t2.Saturday  from NewsPaperMaster t2  CROSS JOIN CustomerAttendanceEntry t1 where t1.[Paper Name]=t2.[NewsPaper Name]"

                    cmd = New SqlCommand(cb)

                    cmd.Connection = con

                    cmd.ExecuteReader()


                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
            Try

                con = New SqlConnection(cs)

                con.Open()
                cmd = New SqlCommand("SELECT [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, No * Rate AS Total, Balance FROM CustomerAttendanceEntry GROUP BY [Customer ID], [Customer Name], Address, AreaCode, [Phone No], [Hawker Name], [Paper Name], No, Rate, Total, Balance  ", con)
                Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

                Dim myDataSet As DataSet = New DataSet()

                myDA.Fill(myDataSet, "CustomerAttendanceEntry")

                DataGridView1.DataSource = myDataSet.Tables("CustomerAttendanceEntry").DefaultView

                con.Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class