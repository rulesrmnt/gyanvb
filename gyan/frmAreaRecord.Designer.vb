<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAreaRecord
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAreaRecord))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.AreaCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AreaAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HawkerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblAreaMasterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GyaDataSet = New Gyan.gyaDataSet()
        Me.TblAreaMasterTableAdapter = New Gyan.gyaDataSetTableAdapters.tblAreaMasterTableAdapter()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblAreaMasterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GyaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AreaCodeDataGridViewTextBoxColumn, Me.AreaAddressDataGridViewTextBoxColumn, Me.HawkerNameDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.TblAreaMasterBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(347, 397)
        Me.DataGridView1.TabIndex = 0
        '
        'AreaCodeDataGridViewTextBoxColumn
        '
        Me.AreaCodeDataGridViewTextBoxColumn.DataPropertyName = "AreaCode"
        Me.AreaCodeDataGridViewTextBoxColumn.HeaderText = "AreaCode"
        Me.AreaCodeDataGridViewTextBoxColumn.Name = "AreaCodeDataGridViewTextBoxColumn"
        '
        'AreaAddressDataGridViewTextBoxColumn
        '
        Me.AreaAddressDataGridViewTextBoxColumn.DataPropertyName = "AreaAddress"
        Me.AreaAddressDataGridViewTextBoxColumn.HeaderText = "AreaAddress"
        Me.AreaAddressDataGridViewTextBoxColumn.Name = "AreaAddressDataGridViewTextBoxColumn"
        '
        'HawkerNameDataGridViewTextBoxColumn
        '
        Me.HawkerNameDataGridViewTextBoxColumn.DataPropertyName = "HawkerName"
        Me.HawkerNameDataGridViewTextBoxColumn.HeaderText = "HawkerName"
        Me.HawkerNameDataGridViewTextBoxColumn.Name = "HawkerNameDataGridViewTextBoxColumn"
        '
        'TblAreaMasterBindingSource
        '
        Me.TblAreaMasterBindingSource.DataMember = "tblAreaMaster"
        Me.TblAreaMasterBindingSource.DataSource = Me.GyaDataSet
        '
        'GyaDataSet
        '
        Me.GyaDataSet.DataSetName = "gyaDataSet"
        Me.GyaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblAreaMasterTableAdapter
        '
        Me.TblAreaMasterTableAdapter.ClearBeforeFill = True
        '
        'frmAreaRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 397)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAreaRecord"
        Me.Text = "Area Record"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblAreaMasterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GyaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GyaDataSet As Gyan.gyaDataSet
    Friend WithEvents TblAreaMasterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblAreaMasterTableAdapter As Gyan.gyaDataSetTableAdapters.tblAreaMasterTableAdapter
    Friend WithEvents AreaCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AreaAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HawkerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
