Imports System.Data.SqlClient
Public Class frmAdmin

    Private Sub login_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles login_button.Click
       

        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If
        Try
            Dim myConnection As SqlConnection
            myConnection = New SqlConnection("Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\gyan_1.mdf; User Instance=true;")

            Dim myCommand As SqlCommand

            myCommand = New SqlCommand("SELECT Password FROM Admin WHERE  password = @UserPassword", myConnection)



            Dim uPassword As New SqlParameter("@UserPassword", SqlDbType.NChar)


            uPassword.Value = TextBox2.Text



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

                TextBox2.Clear()
                TextBox2.Focus()

            Else

                ProgressBar1.Visible = True
                ProgressBar1.Maximum = 5000
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 4
                ProgressBar1.Step = 1

                For i = 0 To 5000
                    ProgressBar1.PerformStep()
                Next

                'frmMain.ToolStripStatusLabel3.Text = TextBox1.Text
                Me.Hide()

                frmMain.Show()
                frmMain.BillToolStripMenuItem.Enabled = True
                frmMain.ReportToolStripMenuItem1.Enabled = True
                frmMain.DeleteAttendanceToolStripMenuItem.Enabled = True
                frmMain.ChangePrintedBillToolStripMenuItem.Enabled = True
                frmCustomerMaster1.Button6.Enabled = True
                frmCustomerMaster1.Button5.Enabled = True
                FrmNewspaperDetails.Button5.Enabled = True
                FrmNewspaperDetails.Button6.Enabled = True
                frmHawkerDetails.Button5.Enabled = True
                frmHawkerDetails.Button6.Enabled = True
                frmAreaMaster.Button5.Enabled = True
                frmAreaMaster.Button5.Enabled = True
                frmMagazineDetail.Button5.Enabled = True
                frmMagazineDetail.Button5.Enabled = True
                frmHawkerPaperTaken.Button5.Enabled = True
                frmHawkerPaperTaken.Button5.Enabled = True
                frmCollectionEntry.Button6.Enabled = True
                frmCollectionEntry.Button5.Enabled = True

            End If





        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        frmAdminChangePassword.Show()

        frmAdminChangePassword.OldPassword.Text = ""
        frmAdminChangePassword.NewPassword.Text = ""
        frmAdminChangePassword.ConfirmPassword.Text = ""
        frmAdminChangePassword.OldPassword.Focus()
    End Sub
End Class