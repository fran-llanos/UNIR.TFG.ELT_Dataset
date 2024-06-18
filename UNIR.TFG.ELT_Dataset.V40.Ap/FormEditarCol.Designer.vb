<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEditarCol
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim IGColPattern1 As TenTec.Windows.iGridLib.iGColPattern = New TenTec.Windows.iGridLib.iGColPattern()
        Dim IGColPattern2 As TenTec.Windows.iGridLib.iGColPattern = New TenTec.Windows.iGridLib.iGColPattern()
        Dim IGColPattern3 As TenTec.Windows.iGridLib.iGColPattern = New TenTec.Windows.iGridLib.iGColPattern()
        Me.IGCellStyleDesignNoEdit = New TenTec.Windows.iGridLib.iGCellStyleDesign()
        Me.IGridEditarColumnasCol0ColHdrStyle = New TenTec.Windows.iGridLib.iGColHdrStyle(True)
        Me.IGridEditarColumnasCol3ColHdrStyle = New TenTec.Windows.iGridLib.iGColHdrStyle(True)
        Me.IGCellStyleDesignEdit = New TenTec.Windows.iGridLib.iGCellStyleDesign()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbEditarColumnas = New System.Windows.Forms.GroupBox()
        Me.IGridEditarColumnas = New TenTec.Windows.iGridLib.iGrid()
        Me.pnlBotonera.SuspendLayout()
        Me.gbEditarColumnas.SuspendLayout()
        CType(Me.IGridEditarColumnas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IGCellStyleDesignNoEdit
        '
        Me.IGCellStyleDesignNoEdit.BackColor = System.Drawing.Color.White
        Me.IGCellStyleDesignNoEdit.ReadOnly = TenTec.Windows.iGridLib.iGBool.[True]
        Me.IGCellStyleDesignNoEdit.Selectable = TenTec.Windows.iGridLib.iGBool.[False]
        '
        'IGCellStyleDesignEdit
        '
        Me.IGCellStyleDesignEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.IGCellStyleDesignEdit.ReadOnly = TenTec.Windows.iGridLib.iGBool.[False]
        Me.IGCellStyleDesignEdit.Selectable = TenTec.Windows.iGridLib.iGBool.[True]
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(486, 5)
        Me.Label1.TabIndex = 19
        '
        'pnlBotonera
        '
        Me.pnlBotonera.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlBotonera.Controls.Add(Me.Label1)
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Controls.Add(Me.btnCancelar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotonera.Location = New System.Drawing.Point(0, 403)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(486, 47)
        Me.pnlBotonera.TabIndex = 11
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Location = New System.Drawing.Point(394, 13)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 23)
        Me.btnGuardar.TabIndex = 18
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.ImageIndex = 0
        Me.btnCancelar.Location = New System.Drawing.Point(12, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 22)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'gbEditarColumnas
        '
        Me.gbEditarColumnas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEditarColumnas.Controls.Add(Me.IGridEditarColumnas)
        Me.gbEditarColumnas.Location = New System.Drawing.Point(0, 1)
        Me.gbEditarColumnas.Name = "gbEditarColumnas"
        Me.gbEditarColumnas.Size = New System.Drawing.Size(486, 399)
        Me.gbEditarColumnas.TabIndex = 12
        Me.gbEditarColumnas.TabStop = False
        '
        'IGridEditarColumnas
        '
        IGColPattern1.CellStyle = Me.IGCellStyleDesignNoEdit
        IGColPattern1.ColHdrStyle = Me.IGridEditarColumnasCol0ColHdrStyle
        IGColPattern1.Key = "colAtributo"
        IGColPattern1.Text = "Atributo"
        IGColPattern1.Width = 150
        IGColPattern2.CellStyle = Me.IGCellStyleDesignNoEdit
        IGColPattern2.ColHdrStyle = Me.IGridEditarColumnasCol3ColHdrStyle
        IGColPattern2.Key = "colValorActual"
        IGColPattern2.Text = "Valor Actual"
        IGColPattern2.Width = 150
        IGColPattern3.CellStyle = Me.IGCellStyleDesignEdit
        IGColPattern3.Key = "colValorNuevo"
        IGColPattern3.Text = "Valor Nuevo"
        IGColPattern3.Width = 150
        Me.IGridEditarColumnas.Cols.AddRange(New TenTec.Windows.iGridLib.iGColPattern() {IGColPattern1, IGColPattern2, IGColPattern3})
        Me.IGridEditarColumnas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IGridEditarColumnas.Header.Height = 20
        Me.IGridEditarColumnas.Location = New System.Drawing.Point(3, 16)
        Me.IGridEditarColumnas.Name = "IGridEditarColumnas"
        Me.IGridEditarColumnas.Size = New System.Drawing.Size(480, 380)
        Me.IGridEditarColumnas.TabIndex = 0
        '
        'FormEditarCol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 450)
        Me.Controls.Add(Me.gbEditarColumnas)
        Me.Controls.Add(Me.pnlBotonera)
        Me.Name = "FormEditarCol"
        Me.Text = "Editar Columnas"
        Me.pnlBotonera.ResumeLayout(False)
        Me.gbEditarColumnas.ResumeLayout(False)
        CType(Me.IGridEditarColumnas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents pnlBotonera As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents gbEditarColumnas As GroupBox
    Friend WithEvents IGridEditarColumnas As TenTec.Windows.iGridLib.iGrid
    Friend WithEvents IGridEditarColumnasCol0ColHdrStyle As TenTec.Windows.iGridLib.iGColHdrStyle
    Friend WithEvents IGridEditarColumnasCol3ColHdrStyle As TenTec.Windows.iGridLib.iGColHdrStyle
    Friend WithEvents IGCellStyleDesignNoEdit As TenTec.Windows.iGridLib.iGCellStyleDesign
    Friend WithEvents IGCellStyleDesignEdit As TenTec.Windows.iGridLib.iGCellStyleDesign
End Class
