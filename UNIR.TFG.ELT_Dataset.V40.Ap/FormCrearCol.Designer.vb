<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCrearCol
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.gbCrearColumna = New System.Windows.Forms.GroupBox()
        Me.gbValor = New System.Windows.Forms.GroupBox()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.txtValorDefecto = New System.Windows.Forms.TextBox()
        Me.gbTamano = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDecimales = New System.Windows.Forms.TextBox()
        Me.lblPrecision = New System.Windows.Forms.Label()
        Me.txtPrecision = New System.Windows.Forms.TextBox()
        Me.lblTamanoCol = New System.Windows.Forms.Label()
        Me.txtTamano = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNombreCol = New System.Windows.Forms.TextBox()
        Me.lblTipoCol = New System.Windows.Forms.Label()
        Me.cbTipos = New System.Windows.Forms.ComboBox()
        Me.pnlBotonera.SuspendLayout()
        Me.gbCrearColumna.SuspendLayout()
        Me.gbValor.SuspendLayout()
        Me.gbTamano.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(387, 5)
        Me.Label1.TabIndex = 19
        '
        'pnlBotonera
        '
        Me.pnlBotonera.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlBotonera.Controls.Add(Me.Label1)
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Controls.Add(Me.btnCancelar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotonera.Location = New System.Drawing.Point(0, 242)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(387, 47)
        Me.pnlBotonera.TabIndex = 12
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Location = New System.Drawing.Point(295, 13)
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
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(15, 22)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(47, 13)
        Me.lblNombre.TabIndex = 13
        Me.lblNombre.Text = "Nombre:"
        '
        'gbCrearColumna
        '
        Me.gbCrearColumna.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCrearColumna.Controls.Add(Me.gbValor)
        Me.gbCrearColumna.Controls.Add(Me.gbTamano)
        Me.gbCrearColumna.Controls.Add(Me.GroupBox1)
        Me.gbCrearColumna.Location = New System.Drawing.Point(3, 3)
        Me.gbCrearColumna.Name = "gbCrearColumna"
        Me.gbCrearColumna.Size = New System.Drawing.Size(384, 236)
        Me.gbCrearColumna.TabIndex = 14
        Me.gbCrearColumna.TabStop = False
        '
        'gbValor
        '
        Me.gbValor.Controls.Add(Me.lblValor)
        Me.gbValor.Controls.Add(Me.txtValorDefecto)
        Me.gbValor.Enabled = False
        Me.gbValor.Location = New System.Drawing.Point(9, 183)
        Me.gbValor.Name = "gbValor"
        Me.gbValor.Size = New System.Drawing.Size(369, 43)
        Me.gbValor.TabIndex = 23
        Me.gbValor.TabStop = False
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Location = New System.Drawing.Point(6, 16)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(91, 13)
        Me.lblValor.TabIndex = 19
        Me.lblValor.Text = "Valor por defecto:"
        '
        'txtValorDefecto
        '
        Me.txtValorDefecto.Location = New System.Drawing.Point(103, 13)
        Me.txtValorDefecto.MaxLength = 50
        Me.txtValorDefecto.Name = "txtValorDefecto"
        Me.txtValorDefecto.Size = New System.Drawing.Size(260, 20)
        Me.txtValorDefecto.TabIndex = 20
        '
        'gbTamano
        '
        Me.gbTamano.Controls.Add(Me.Label2)
        Me.gbTamano.Controls.Add(Me.txtDecimales)
        Me.gbTamano.Controls.Add(Me.lblPrecision)
        Me.gbTamano.Controls.Add(Me.txtPrecision)
        Me.gbTamano.Controls.Add(Me.lblTamanoCol)
        Me.gbTamano.Controls.Add(Me.txtTamano)
        Me.gbTamano.Enabled = False
        Me.gbTamano.Location = New System.Drawing.Point(6, 95)
        Me.gbTamano.Name = "gbTamano"
        Me.gbTamano.Size = New System.Drawing.Size(372, 82)
        Me.gbTamano.TabIndex = 22
        Me.gbTamano.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(187, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Decimales:"
        '
        'txtDecimales
        '
        Me.txtDecimales.Location = New System.Drawing.Point(252, 39)
        Me.txtDecimales.MaxLength = 50
        Me.txtDecimales.Name = "txtDecimales"
        Me.txtDecimales.Size = New System.Drawing.Size(114, 20)
        Me.txtDecimales.TabIndex = 22
        '
        'lblPrecision
        '
        Me.lblPrecision.AutoSize = True
        Me.lblPrecision.Location = New System.Drawing.Point(11, 42)
        Me.lblPrecision.Name = "lblPrecision"
        Me.lblPrecision.Size = New System.Drawing.Size(53, 13)
        Me.lblPrecision.TabIndex = 19
        Me.lblPrecision.Text = "Precisión:"
        '
        'txtPrecision
        '
        Me.txtPrecision.Location = New System.Drawing.Point(66, 39)
        Me.txtPrecision.MaxLength = 50
        Me.txtPrecision.Name = "txtPrecision"
        Me.txtPrecision.Size = New System.Drawing.Size(115, 20)
        Me.txtPrecision.TabIndex = 20
        '
        'lblTamanoCol
        '
        Me.lblTamanoCol.AutoSize = True
        Me.lblTamanoCol.Location = New System.Drawing.Point(11, 16)
        Me.lblTamanoCol.Name = "lblTamanoCol"
        Me.lblTamanoCol.Size = New System.Drawing.Size(49, 13)
        Me.lblTamanoCol.TabIndex = 17
        Me.lblTamanoCol.Text = "Tamaño:"
        '
        'txtTamano
        '
        Me.txtTamano.Location = New System.Drawing.Point(66, 13)
        Me.txtTamano.MaxLength = 50
        Me.txtTamano.Name = "txtTamano"
        Me.txtTamano.Size = New System.Drawing.Size(115, 20)
        Me.txtTamano.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNombreCol)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Controls.Add(Me.lblTipoCol)
        Me.GroupBox1.Controls.Add(Me.cbTipos)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(372, 80)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'txtNombreCol
        '
        Me.txtNombreCol.Location = New System.Drawing.Point(66, 19)
        Me.txtNombreCol.MaxLength = 50
        Me.txtNombreCol.Name = "txtNombreCol"
        Me.txtNombreCol.Size = New System.Drawing.Size(300, 20)
        Me.txtNombreCol.TabIndex = 14
        '
        'lblTipoCol
        '
        Me.lblTipoCol.AutoSize = True
        Me.lblTipoCol.Location = New System.Drawing.Point(15, 48)
        Me.lblTipoCol.Name = "lblTipoCol"
        Me.lblTipoCol.Size = New System.Drawing.Size(31, 13)
        Me.lblTipoCol.TabIndex = 15
        Me.lblTipoCol.Text = "Tipo:"
        '
        'cbTipos
        '
        Me.cbTipos.FormattingEnabled = True
        Me.cbTipos.Location = New System.Drawing.Point(66, 45)
        Me.cbTipos.Name = "cbTipos"
        Me.cbTipos.Size = New System.Drawing.Size(201, 21)
        Me.cbTipos.TabIndex = 16
        '
        'FormCrearCol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 289)
        Me.Controls.Add(Me.gbCrearColumna)
        Me.Controls.Add(Me.pnlBotonera)
        Me.Name = "FormCrearCol"
        Me.Text = "Crear Columna"
        Me.pnlBotonera.ResumeLayout(False)
        Me.gbCrearColumna.ResumeLayout(False)
        Me.gbValor.ResumeLayout(False)
        Me.gbValor.PerformLayout()
        Me.gbTamano.ResumeLayout(False)
        Me.gbTamano.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents pnlBotonera As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblNombre As Label
    Friend WithEvents gbCrearColumna As GroupBox
    Friend WithEvents txtTamano As TextBox
    Friend WithEvents lblTamanoCol As Label
    Friend WithEvents cbTipos As ComboBox
    Friend WithEvents lblTipoCol As Label
    Friend WithEvents txtNombreCol As TextBox
    Friend WithEvents txtValorDefecto As TextBox
    Friend WithEvents lblValor As Label
    Friend WithEvents gbValor As GroupBox
    Friend WithEvents gbTamano As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDecimales As TextBox
    Friend WithEvents lblPrecision As Label
    Friend WithEvents txtPrecision As TextBox
End Class
