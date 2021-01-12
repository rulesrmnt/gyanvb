<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewsPaperRecord
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewsPaperRecord))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NewspaperCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewspaperNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SundayDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MondayDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TuesdayDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WednesdayDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThursdayDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FridayDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaturdayDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewspaperMasterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GyaDataSet = New Gyan.gyaDataSet()
        Me.NewspaperMasterTableAdapter = New Gyan.gyaDataSetTableAdapters.NewspaperMasterTableAdapter()
        Me.Button5 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewspaperMasterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GyaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NewspaperCodeDataGridViewTextBoxColumn, Me.NewspaperNameDataGridViewTextBoxColumn, Me.SundayDataGridViewTextBoxColumn, Me.MondayDataGridViewTextBoxColumn, Me.TuesdayDataGridViewTextBoxColumn, Me.WednesdayDataGridViewTextBoxColumn, Me.ThursdayDataGridViewTextBoxColumn, Me.FridayDataGridViewTextBoxColumn, Me.SaturdayDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.NewspaperMasterBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(0, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(946, 365)
        Me.DataGridView1.TabIndex = 0
        '
        'NewspaperCodeDataGridViewTextBoxColumn
        '
        Me.NewspaperCodeDataGridViewTextBoxColumn.DataPropertyName = "Newspaper Code"
        Me.NewspaperCodeDataGridViewTextBoxColumn.HeaderText = "Newspaper Code"
        Me.NewspaperCodeDataGridViewTextBoxColumn.Name = "NewspaperCodeDataGridViewTextBoxColumn"
        '
        'NewspaperNameDataGridViewTextBoxColumn
        '
        Me.NewspaperNameDataGridViewTextBoxColumn.DataPropertyName = "Newspaper Name"
        Me.NewspaperNameDataGridViewTextBoxColumn.HeaderText = "Newspaper Name"
        Me.NewspaperNameDataGridViewTextBoxColumn.Name = "NewspaperNameDataGridViewTextBoxColumn"
        '
        'SundayDataGridViewTextBoxColumn
        '
        Me.SundayDataGridViewTextBoxColumn.DataPropertyName = "Sunday"
        Me.SundayDataGridViewTextBoxColumn.HeaderText = "Sunday"
        Me.SundayDataGridViewTextBoxColumn.Name = "SundayDataGridViewTextBoxColumn"
        '
        'MondayDataGridViewTextBoxColumn
        '
        Me.MondayDataGridViewTextBoxColumn.DataPropertyName = "Monday"
        Me.MondayDataGridViewTextBoxColumn.HeaderText = "Monday"
        Me.MondayDataGridViewTextBoxColumn.Name = "MondayDataGridViewTextBoxColumn"
        '
        'TuesdayDataGridViewTextBoxColumn
        '
        Me.TuesdayDataGridViewTextBoxColumn.DataPropertyName = "Tuesday"
        Me.TuesdayDataGridViewTextBoxColumn.HeaderText = "Tuesday"
        Me.TuesdayDataGridViewTextBoxColumn.Name = "TuesdayDataGridViewTextBoxColumn"
        '
        'WednesdayDataGridViewTextBoxColumn
        '
        Me.WednesdayDataGridViewTextBoxColumn.DataPropertyName = "Wednesday"
        Me.WednesdayDataGridViewTextBoxColumn.HeaderText = "Wednesday"
        Me.WednesdayDataGridViewTextBoxColumn.Name = "WednesdayDataGridViewTextBoxColumn"
        '
        'ThursdayDataGridViewTextBoxColumn
        '
        Me.ThursdayDataGridViewTextBoxColumn.DataPropertyName = "Thursday"
        Me.ThursdayDataGridViewTextBoxColumn.HeaderText = "Thursday"
        Me.ThursdayDataGridViewTextBoxColumn.Name = "ThursdayDataGridViewTextBoxColumn"
        '
        'FridayDataGridViewTextBoxColumn
        '
        Me.FridayDataGridViewTextBoxColumn.DataPropertyName = "Friday"
        Me.FridayDataGridViewTextBoxColumn.HeaderText = "Friday"
        Me.FridayDataGridViewTextBoxColumn.Name = "FridayDataGridViewTextBoxColumn"
        '
        'SaturdayDataGridViewTextBoxColumn
        '
        Me.SaturdayDataGridViewTextBoxColumn.DataPropertyName = "Saturday"
        Me.SaturdayDataGridViewTextBoxColumn.HeaderText = "Saturday"
        Me.SaturdayDataGridViewTextBoxColumn.Name = "SaturdayDataGridViewTextBoxColumn"
        '
        'NewspaperMasterBindingSource
        '
        Me.NewspaperMasterBindingSource.DataMember = "NewspaperMaster"
        Me.NewspaperMasterBindingSource.DataSource = Me.GyaDataSet
        '
        'GyaDataSet
        '
        Me.GyaDataSet.DataSetName = "gyaDataSet"
        Me.GyaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'NewspaperMasterTableAdapter
        '
        Me.NewspaperMasterTableAdapter.ClearBeforeFill = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(56, 12)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(94, 40)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "&Export Excel"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'frmNewsPaperRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 423)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNewsPaperRecord"
        Me.Text = "News Paper Record"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewspaperMasterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GyaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GyaDataSet As Gyan.gyaDataSet
    Friend WithEvents NewspaperMasterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NewspaperMasterTableAdapter As Gyan.gyaDataSetTableAdapters.NewspaperMasterTableAdapter
    Friend WithEvents RateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewspaperCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewspaperNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SundayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MondayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TuesdayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WednesdayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThursdayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FridayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaturdayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
