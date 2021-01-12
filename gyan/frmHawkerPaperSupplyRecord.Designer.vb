<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHawkerPaperSupplyRecord
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHawkerPaperSupplyRecord))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MonthYearDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HawkerCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HawkerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaperDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TakenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paper1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taken1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paper2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taken2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paper3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taken3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paper4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taken4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paper5DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taken5DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paper6DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taken6DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paper7DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taken7DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paper8DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taken8DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paper9DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taken9DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HawkerPaperSupplyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GyaDataSet = New Gyan.gyaDataSet()
        Me.HawkerPaperSupplyTableAdapter = New Gyan.gyaDataSetTableAdapters.HawkerPaperSupplyTableAdapter()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HawkerPaperSupplyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GyaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 87)
        Me.GroupBox3.TabIndex = 51
        Me.GroupBox3.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(24, 45)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(135, 20)
        Me.TextBox1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Month Year"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.TextBox7)
        Me.GroupBox14.Controls.Add(Me.Label7)
        Me.GroupBox14.Location = New System.Drawing.Point(242, 12)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(287, 87)
        Me.GroupBox14.TabIndex = 50
        Me.GroupBox14.TabStop = False
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(24, 45)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(234, 20)
        Me.TextBox7.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 18)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Search Hawker Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Location = New System.Drawing.Point(563, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(247, 87)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(30, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 40)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Get Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(130, 23)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 40)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "&Reset"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MonthYearDataGridViewTextBoxColumn, Me.HawkerCodeDataGridViewTextBoxColumn, Me.HawkerNameDataGridViewTextBoxColumn, Me.PaperDataGridViewTextBoxColumn, Me.TakenDataGridViewTextBoxColumn, Me.Paper1DataGridViewTextBoxColumn, Me.Taken1DataGridViewTextBoxColumn, Me.Paper2DataGridViewTextBoxColumn, Me.Taken2DataGridViewTextBoxColumn, Me.Paper3DataGridViewTextBoxColumn, Me.Taken3DataGridViewTextBoxColumn, Me.Paper4DataGridViewTextBoxColumn, Me.Taken4DataGridViewTextBoxColumn, Me.Paper5DataGridViewTextBoxColumn, Me.Taken5DataGridViewTextBoxColumn, Me.Paper6DataGridViewTextBoxColumn, Me.Taken6DataGridViewTextBoxColumn, Me.Paper7DataGridViewTextBoxColumn, Me.Taken7DataGridViewTextBoxColumn, Me.Paper8DataGridViewTextBoxColumn, Me.Taken8DataGridViewTextBoxColumn, Me.Paper9DataGridViewTextBoxColumn, Me.Taken9DataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.HawkerPaperSupplyBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(2, 114)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(867, 221)
        Me.DataGridView1.TabIndex = 52
        '
        'MonthYearDataGridViewTextBoxColumn
        '
        Me.MonthYearDataGridViewTextBoxColumn.DataPropertyName = "MonthYear"
        Me.MonthYearDataGridViewTextBoxColumn.HeaderText = "MonthYear"
        Me.MonthYearDataGridViewTextBoxColumn.Name = "MonthYearDataGridViewTextBoxColumn"
        '
        'HawkerCodeDataGridViewTextBoxColumn
        '
        Me.HawkerCodeDataGridViewTextBoxColumn.DataPropertyName = "HawkerCode"
        Me.HawkerCodeDataGridViewTextBoxColumn.HeaderText = "HawkerCode"
        Me.HawkerCodeDataGridViewTextBoxColumn.Name = "HawkerCodeDataGridViewTextBoxColumn"
        '
        'HawkerNameDataGridViewTextBoxColumn
        '
        Me.HawkerNameDataGridViewTextBoxColumn.DataPropertyName = "Hawker Name"
        Me.HawkerNameDataGridViewTextBoxColumn.HeaderText = "Hawker Name"
        Me.HawkerNameDataGridViewTextBoxColumn.Name = "HawkerNameDataGridViewTextBoxColumn"
        '
        'PaperDataGridViewTextBoxColumn
        '
        Me.PaperDataGridViewTextBoxColumn.DataPropertyName = "Paper"
        Me.PaperDataGridViewTextBoxColumn.HeaderText = "Paper"
        Me.PaperDataGridViewTextBoxColumn.Name = "PaperDataGridViewTextBoxColumn"
        '
        'TakenDataGridViewTextBoxColumn
        '
        Me.TakenDataGridViewTextBoxColumn.DataPropertyName = "Taken"
        Me.TakenDataGridViewTextBoxColumn.HeaderText = "Taken"
        Me.TakenDataGridViewTextBoxColumn.Name = "TakenDataGridViewTextBoxColumn"
        '
        'Paper1DataGridViewTextBoxColumn
        '
        Me.Paper1DataGridViewTextBoxColumn.DataPropertyName = "Paper1"
        Me.Paper1DataGridViewTextBoxColumn.HeaderText = "Paper1"
        Me.Paper1DataGridViewTextBoxColumn.Name = "Paper1DataGridViewTextBoxColumn"
        '
        'Taken1DataGridViewTextBoxColumn
        '
        Me.Taken1DataGridViewTextBoxColumn.DataPropertyName = "Taken1"
        Me.Taken1DataGridViewTextBoxColumn.HeaderText = "Taken1"
        Me.Taken1DataGridViewTextBoxColumn.Name = "Taken1DataGridViewTextBoxColumn"
        '
        'Paper2DataGridViewTextBoxColumn
        '
        Me.Paper2DataGridViewTextBoxColumn.DataPropertyName = "Paper2"
        Me.Paper2DataGridViewTextBoxColumn.HeaderText = "Paper2"
        Me.Paper2DataGridViewTextBoxColumn.Name = "Paper2DataGridViewTextBoxColumn"
        '
        'Taken2DataGridViewTextBoxColumn
        '
        Me.Taken2DataGridViewTextBoxColumn.DataPropertyName = "Taken2"
        Me.Taken2DataGridViewTextBoxColumn.HeaderText = "Taken2"
        Me.Taken2DataGridViewTextBoxColumn.Name = "Taken2DataGridViewTextBoxColumn"
        '
        'Paper3DataGridViewTextBoxColumn
        '
        Me.Paper3DataGridViewTextBoxColumn.DataPropertyName = "Paper3"
        Me.Paper3DataGridViewTextBoxColumn.HeaderText = "Paper3"
        Me.Paper3DataGridViewTextBoxColumn.Name = "Paper3DataGridViewTextBoxColumn"
        '
        'Taken3DataGridViewTextBoxColumn
        '
        Me.Taken3DataGridViewTextBoxColumn.DataPropertyName = "Taken3"
        Me.Taken3DataGridViewTextBoxColumn.HeaderText = "Taken3"
        Me.Taken3DataGridViewTextBoxColumn.Name = "Taken3DataGridViewTextBoxColumn"
        '
        'Paper4DataGridViewTextBoxColumn
        '
        Me.Paper4DataGridViewTextBoxColumn.DataPropertyName = "Paper4"
        Me.Paper4DataGridViewTextBoxColumn.HeaderText = "Paper4"
        Me.Paper4DataGridViewTextBoxColumn.Name = "Paper4DataGridViewTextBoxColumn"
        '
        'Taken4DataGridViewTextBoxColumn
        '
        Me.Taken4DataGridViewTextBoxColumn.DataPropertyName = "Taken4"
        Me.Taken4DataGridViewTextBoxColumn.HeaderText = "Taken4"
        Me.Taken4DataGridViewTextBoxColumn.Name = "Taken4DataGridViewTextBoxColumn"
        '
        'Paper5DataGridViewTextBoxColumn
        '
        Me.Paper5DataGridViewTextBoxColumn.DataPropertyName = "Paper5"
        Me.Paper5DataGridViewTextBoxColumn.HeaderText = "Paper5"
        Me.Paper5DataGridViewTextBoxColumn.Name = "Paper5DataGridViewTextBoxColumn"
        '
        'Taken5DataGridViewTextBoxColumn
        '
        Me.Taken5DataGridViewTextBoxColumn.DataPropertyName = "Taken5"
        Me.Taken5DataGridViewTextBoxColumn.HeaderText = "Taken5"
        Me.Taken5DataGridViewTextBoxColumn.Name = "Taken5DataGridViewTextBoxColumn"
        '
        'Paper6DataGridViewTextBoxColumn
        '
        Me.Paper6DataGridViewTextBoxColumn.DataPropertyName = "Paper6"
        Me.Paper6DataGridViewTextBoxColumn.HeaderText = "Paper6"
        Me.Paper6DataGridViewTextBoxColumn.Name = "Paper6DataGridViewTextBoxColumn"
        '
        'Taken6DataGridViewTextBoxColumn
        '
        Me.Taken6DataGridViewTextBoxColumn.DataPropertyName = "Taken6"
        Me.Taken6DataGridViewTextBoxColumn.HeaderText = "Taken6"
        Me.Taken6DataGridViewTextBoxColumn.Name = "Taken6DataGridViewTextBoxColumn"
        '
        'Paper7DataGridViewTextBoxColumn
        '
        Me.Paper7DataGridViewTextBoxColumn.DataPropertyName = "Paper7"
        Me.Paper7DataGridViewTextBoxColumn.HeaderText = "Paper7"
        Me.Paper7DataGridViewTextBoxColumn.Name = "Paper7DataGridViewTextBoxColumn"
        '
        'Taken7DataGridViewTextBoxColumn
        '
        Me.Taken7DataGridViewTextBoxColumn.DataPropertyName = "Taken7"
        Me.Taken7DataGridViewTextBoxColumn.HeaderText = "Taken7"
        Me.Taken7DataGridViewTextBoxColumn.Name = "Taken7DataGridViewTextBoxColumn"
        '
        'Paper8DataGridViewTextBoxColumn
        '
        Me.Paper8DataGridViewTextBoxColumn.DataPropertyName = "Paper8"
        Me.Paper8DataGridViewTextBoxColumn.HeaderText = "Paper8"
        Me.Paper8DataGridViewTextBoxColumn.Name = "Paper8DataGridViewTextBoxColumn"
        '
        'Taken8DataGridViewTextBoxColumn
        '
        Me.Taken8DataGridViewTextBoxColumn.DataPropertyName = "Taken8"
        Me.Taken8DataGridViewTextBoxColumn.HeaderText = "Taken8"
        Me.Taken8DataGridViewTextBoxColumn.Name = "Taken8DataGridViewTextBoxColumn"
        '
        'Paper9DataGridViewTextBoxColumn
        '
        Me.Paper9DataGridViewTextBoxColumn.DataPropertyName = "Paper9"
        Me.Paper9DataGridViewTextBoxColumn.HeaderText = "Paper9"
        Me.Paper9DataGridViewTextBoxColumn.Name = "Paper9DataGridViewTextBoxColumn"
        '
        'Taken9DataGridViewTextBoxColumn
        '
        Me.Taken9DataGridViewTextBoxColumn.DataPropertyName = "Taken9"
        Me.Taken9DataGridViewTextBoxColumn.HeaderText = "Taken9"
        Me.Taken9DataGridViewTextBoxColumn.Name = "Taken9DataGridViewTextBoxColumn"
        '
        'HawkerPaperSupplyBindingSource
        '
        Me.HawkerPaperSupplyBindingSource.DataMember = "HawkerPaperSupply"
        Me.HawkerPaperSupplyBindingSource.DataSource = Me.GyaDataSet
        '
        'GyaDataSet
        '
        Me.GyaDataSet.DataSetName = "gyaDataSet"
        Me.GyaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HawkerPaperSupplyTableAdapter
        '
        Me.HawkerPaperSupplyTableAdapter.ClearBeforeFill = True
        '
        'frmHawkerPaperSupplyRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 337)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox14)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHawkerPaperSupplyRecord"
        Me.Text = "Hawker Paper Supply Record"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HawkerPaperSupplyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GyaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GyaDataSet As Gyan.gyaDataSet
    Friend WithEvents HawkerPaperSupplyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HawkerPaperSupplyTableAdapter As Gyan.gyaDataSetTableAdapters.HawkerPaperSupplyTableAdapter
    Friend WithEvents CountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Count1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Count2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Count3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Count4DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Count5DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Count6DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Count7DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Count8DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Count9DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonthYearDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HawkerCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HawkerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaperDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TakenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paper1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taken1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paper2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taken2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paper3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taken3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paper4DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taken4DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paper5DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taken5DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paper6DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taken6DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paper7DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taken7DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paper8DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taken8DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paper9DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taken9DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
