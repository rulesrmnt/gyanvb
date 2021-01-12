Public Class frmMain

    Private Sub HawkerDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HawkerDetailsToolStripMenuItem.Click
        frmHawkerDetails.Show()

    End Sub

    Private Sub NewspaperDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewspaperDetailsToolStripMenuItem.Click
        FrmNewspaperDetails.Show()

    End Sub

    Private Sub CustomerDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerDetailsToolStripMenuItem.Click
        frmCustomerMaster1.Show()

    End Sub

    Private Sub HawkerPaperTakenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmHawkerPaperSupply.Show()

    End Sub

    Private Sub DaysCountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaysCountToolStripMenuItem.Click
        frmAreaMaster.Show()

    End Sub

    Private Sub ReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnToolStripMenuItem.Click
        frmHawkerReturn.Show()

    End Sub

    Private Sub CustomerPaperNotTakenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerPaperNotTakenToolStripMenuItem.Click
        frmCustomerAttendance.Show()

    End Sub

    Private Sub HawkerPaperTakeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub DemoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DemoToolStripMenuItem.Click
        frmDailyRecord.Show()

    End Sub

    Private Sub Demo1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCustomerRecord.Show()

    End Sub

    Private Sub CustomerAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub CollectionEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectionEntryToolStripMenuItem.Click
        frmCollectionEntry.Show()

    End Sub

    Private Sub Repot2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Repot2ToolStripMenuItem.Click
        frmHawkerList.Show()

    End Sub

    Private Sub HawkerWiseReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form2.Show()

    End Sub

    Private Sub CustomerBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerBalanceToolStripMenuItem.Click
        frmCustomerBalanceRecord.Show()

    End Sub

    Private Sub CollectionRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectionRecordToolStripMenuItem.Click
        frmCollectionRecord.Show()

    End Sub

    Private Sub NewsPaperDetailsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewsPaperDetailsToolStripMenuItem1.Click
        frmNewsPaperRecord.Show()

    End Sub

    Private Sub HawkerReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HawkerReturnReportToolStripMenuItem.Click
        frmHawkerReturnRecord.Show()

    End Sub

    Private Sub BillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillToolStripMenuItem.Click
        frmBillRpt.Show()

    End Sub

    Private Sub CustomerExtraMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerExtraMasterToolStripMenuItem.Click
        frmCusExtraPaper.Show()

    End Sub

    Private Sub MagazineDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MagazineDetailsToolStripMenuItem.Click
        frmMagazineDetail.Show()

    End Sub

    Private Sub CustomerMagazineEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerMagazineEntryToolStripMenuItem.Click
        frmMagazineEntry.Show()

    End Sub

    Private Sub ExtraPaperSoldByHawkerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCheckAttendance.Show()

    End Sub

    Private Sub BalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceReportToolStripMenuItem.Click
        frmBalanceRpt.Show()

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripStatusLabel3.Text = Now
    End Sub

    Private Sub CollectionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectionReportToolStripMenuItem.Click
        frmCollectionRpt.Show()

    End Sub

    Private Sub HawkerReturnReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HawkerReturnReportToolStripMenuItem1.Click
        frmHawkerReturnRpt.Show()

    End Sub

    Private Sub HawkerDetailsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HawkerDetailsToolStripMenuItem1.Click
        frmHawkerRecord.Show()

    End Sub

    Private Sub AreaRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AreaRecordToolStripMenuItem.Click
        frmAreaRecord.Show()

    End Sub

    Private Sub MagazineDetailsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MagazineDetailsToolStripMenuItem1.Click
        frmMagazineRecord.Show()
    End Sub

    Private Sub HawkerNewsPaperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmHawkerPaperTaken.Show()
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NotepadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotepadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Notepad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MSWordToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Winword.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub WordPadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordPadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Wordpad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CustomerAttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCustomerDetails.Show()

    End Sub

    Private Sub DeleteAttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAttendanceToolStripMenuItem.Click
        frmDeleteAttendance.Show()

    End Sub

    Private Sub CustomerRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerRecordToolStripMenuItem.Click
        frmCustomerRecord1.Show()

    End Sub

    Private Sub ChangePrintedBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmChangeBill.Show()

    End Sub

    Private Sub AdminLoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminLoginToolStripMenuItem.Click
        frmAdmin.Show()

    End Sub

    Private Sub AttendanceManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceManualToolStripMenuItem.Click
        frmAttendaneManual.Show()

    End Sub

    Private Sub ReturnToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReturnRpt.Show()

    End Sub

    Private Sub ExtraSoldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraSoldToolStripMenuItem.Click
        frmExtraSold.Show()

    End Sub

    Private Sub HawkerNewsPaperToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HawkerNewsPaperToolStripMenuItem.Click
        frmHawkerPaperTaken.Show()

    End Sub

    Private Sub HawkerPaperTakenToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HawkerPaperTakenToolStripMenuItem.Click
        frmHawkerPaperSupply.Show()

    End Sub

    Private Sub CustomerAttendanceToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerAttendanceToolStripMenuItem.Click
        frmCustomerDetails.Show()

    End Sub


    Private Sub ChangePrintedBillToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePrintedBillToolStripMenuItem.Click
        frmChangeBill.Show()

    End Sub

    Private Sub ReturnToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnToolStripMenuItem1.Click
        frmReturnRpt.Show()

    End Sub

    Private Sub ExtraPaperSoldByHawkerToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraPaperSoldByHawkerToolStripMenuItem.Click
        frmCustomerEntryRecord1.Show()

    End Sub
End Class
