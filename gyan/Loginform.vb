Imports System.Data.SqlClient
Public Class Loginform


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        frmChangePassword.Show()
        frmChangePassword.UserName.Text = ""
        frmChangePassword.OldPassword.Text = ""
        frmChangePassword.NewPassword.Text = ""
        frmChangePassword.ConfirmPassword.Text = ""
        frmChangePassword.UserName.Focus()

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub login_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles login_button.Click

        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please enter user name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If

        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If
        Try
            Dim myConnection As SqlConnection
            myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")

            Dim myCommand As SqlCommand

            myCommand = New SqlCommand("SELECT Username,password FROM Users WHERE username = @username AND password = @UserPassword", myConnection)

            Dim uName As New SqlParameter("@username", SqlDbType.NChar)

            Dim uPassword As New SqlParameter("@UserPassword", SqlDbType.NChar)

            uName.Value = TextBox1.Text

            uPassword.Value = TextBox2.Text

            myCommand.Parameters.Add(uName)

            myCommand.Parameters.Add(uPassword)

            myCommand.Connection.Open()

            Dim myReader As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            Dim Login As Object = 0

            If myReader.HasRows Then

                myReader.Read()

                Login = myReader(Login)

            End If

            If Login = Nothing Then

                MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()

            Else

                ProgressBar1.Visible = True
                ProgressBar1.Maximum = 5000
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 4
                ProgressBar1.Step = 1

                For i = 0 To 5000
                    ProgressBar1.PerformStep()
                Next

                frmMain.ToolStripStatusLabel3.Text = TextBox1.Text
                Me.Hide()

                frmMain.Show()
                frmMain.BillToolStripMenuItem.Enabled = False
                frmMain.ReportToolStripMenuItem1.Enabled = False
                frmMain.DeleteAttendanceToolStripMenuItem.Enabled = False
                frmMain.ChangePrintedBillToolStripMenuItem.Enabled = False
                frmCustomerMaster1.Button6.Enabled = False
                ' frmCustomerMaster1.Button5.Enabled = False
                FrmNewspaperDetails.Button5.Enabled = False
                FrmNewspaperDetails.Button6.Enabled = False
                frmHawkerDetails.Button5.Enabled = False
                frmHawkerDetails.Button6.Enabled = False
                frmAreaMaster.Button5.Enabled = False
                frmAreaMaster.Button5.Enabled = False
                frmMagazineDetail.Button5.Enabled = False
                frmMagazineDetail.Button5.Enabled = False
                frmHawkerPaperTaken.Button5.Enabled = False
                frmHawkerPaperTaken.Button5.Enabled = False
                frmCollectionEntry.Button6.Enabled = False
                frmCollectionEntry.Button5.Enabled = False
            End If





        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Loginform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class