<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrincipal))
        Dim IGColPattern1 As TenTec.Windows.iGridLib.iGColPattern = New TenTec.Windows.iGridLib.iGColPattern()
        Dim IGColPattern2 As TenTec.Windows.iGridLib.iGColPattern = New TenTec.Windows.iGridLib.iGColPattern()
        Dim IGDropDownListItem1 As TenTec.Windows.iGridLib.iGDropDownListItem = New TenTec.Windows.iGridLib.iGDropDownListItem()
        Dim IGDropDownListItem2 As TenTec.Windows.iGridLib.iGDropDownListItem = New TenTec.Windows.iGridLib.iGDropDownListItem()
        Me.IGridLogCol0CellStyle = New TenTec.Windows.iGridLib.iGCellStyle(True)
        Me.IGridLogCol0ColHdrStyle = New TenTec.Windows.iGridLib.iGColHdrStyle(True)
        Me.IGridLogCol1CellStyle = New TenTec.Windows.iGridLib.iGCellStyle(True)
        Me.IGridLogCol1ColHdrStyle = New TenTec.Windows.iGridLib.iGColHdrStyle(True)
        Me.lblLineaSuperior = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.gbDataset = New System.Windows.Forms.GroupBox()
        Me.linkCrearTabla = New System.Windows.Forms.LinkLabel()
        Me.txtNombreTabla = New System.Windows.Forms.TextBox()
        Me.lblNombreTabla = New System.Windows.Forms.Label()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cmdExaminar = New System.Windows.Forms.Button()
        Me.ilsmall = New System.Windows.Forms.ImageList(Me.components)
        Me.gbRegistrosTablaCargada = New System.Windows.Forms.GroupBox()
        Me.linkCrearColumna = New System.Windows.Forms.LinkLabel()
        Me.IGridRegistros = New TenTec.Windows.iGridLib.iGrid()
        Me.IGrid1DefaultCellStyle = New TenTec.Windows.iGridLib.iGCellStyle(True)
        Me.IGrid1DefaultColHdrStyle = New TenTec.Windows.iGridLib.iGColHdrStyle(True)
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimpiarTodo = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.gbLog = New System.Windows.Forms.GroupBox()
        Me.IGridLog = New TenTec.Windows.iGridLib.iGrid()
        Me.IGrid1DefaultCellStyle1 = New TenTec.Windows.iGridLib.iGCellStyle(True)
        Me.IGrid1DefaultColHdrStyle1 = New TenTec.Windows.iGridLib.iGColHdrStyle(True)
        Me.IGDropDownListAcciones = New TenTec.Windows.iGridLib.iGDropDownList()
        Me.pnlCabecera.SuspendLayout()
        Me.gbDataset.SuspendLayout()
        Me.gbRegistrosTablaCargada.SuspendLayout()
        CType(Me.IGridRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonera.SuspendLayout()
        Me.gbLog.SuspendLayout()
        CType(Me.IGridLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLineaSuperior
        '
        Me.lblLineaSuperior.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblLineaSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLineaSuperior.Location = New System.Drawing.Point(0, 31)
        Me.lblLineaSuperior.Name = "lblLineaSuperior"
        Me.lblLineaSuperior.Size = New System.Drawing.Size(888, 5)
        Me.lblLineaSuperior.TabIndex = 7
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.pnlCabecera.Controls.Add(Me.lblTitulo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(888, 31)
        Me.pnlCabecera.TabIndex = 6
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitulo.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(888, 31)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "ELT Dataset"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbDataset
        '
        Me.gbDataset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDataset.Controls.Add(Me.linkCrearTabla)
        Me.gbDataset.Controls.Add(Me.txtNombreTabla)
        Me.gbDataset.Controls.Add(Me.lblNombreTabla)
        Me.gbDataset.Controls.Add(Me.txtRuta)
        Me.gbDataset.Controls.Add(Me.lblRuta)
        Me.gbDataset.Controls.Add(Me.cmdExaminar)
        Me.gbDataset.Location = New System.Drawing.Point(0, 36)
        Me.gbDataset.Name = "gbDataset"
        Me.gbDataset.Size = New System.Drawing.Size(888, 66)
        Me.gbDataset.TabIndex = 8
        Me.gbDataset.TabStop = False
        '
        'linkCrearTabla
        '
        Me.linkCrearTabla.AutoSize = True
        Me.linkCrearTabla.Location = New System.Drawing.Point(356, 41)
        Me.linkCrearTabla.Name = "linkCrearTabla"
        Me.linkCrearTabla.Size = New System.Drawing.Size(62, 13)
        Me.linkCrearTabla.TabIndex = 21
        Me.linkCrearTabla.TabStop = True
        Me.linkCrearTabla.Text = "Crear Tabla"
        '
        'txtNombreTabla
        '
        Me.txtNombreTabla.Location = New System.Drawing.Point(98, 38)
        Me.txtNombreTabla.Name = "txtNombreTabla"
        Me.txtNombreTabla.Size = New System.Drawing.Size(252, 20)
        Me.txtNombreTabla.TabIndex = 16
        '
        'lblNombreTabla
        '
        Me.lblNombreTabla.Location = New System.Drawing.Point(9, 36)
        Me.lblNombreTabla.Name = "lblNombreTabla"
        Me.lblNombreTabla.Size = New System.Drawing.Size(88, 23)
        Me.lblNombreTabla.TabIndex = 15
        Me.lblNombreTabla.Text = "Nombre Tabla:"
        Me.lblNombreTabla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRuta
        '
        Me.txtRuta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRuta.Location = New System.Drawing.Point(98, 14)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(753, 20)
        Me.txtRuta.TabIndex = 14
        '
        'lblRuta
        '
        Me.lblRuta.Location = New System.Drawing.Point(9, 11)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(99, 23)
        Me.lblRuta.TabIndex = 12
        Me.lblRuta.Text = "Dataset a cargar:"
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExaminar
        '
        Me.cmdExaminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExaminar.ImageIndex = 0
        Me.cmdExaminar.ImageList = Me.ilsmall
        Me.cmdExaminar.Location = New System.Drawing.Point(857, 13)
        Me.cmdExaminar.Name = "cmdExaminar"
        Me.cmdExaminar.Size = New System.Drawing.Size(25, 21)
        Me.cmdExaminar.TabIndex = 13
        '
        'ilsmall
        '
        Me.ilsmall.ImageStream = CType(resources.GetObject("ilsmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsmall.TransparentColor = System.Drawing.Color.Transparent
        Me.ilsmall.Images.SetKeyName(0, "")
        Me.ilsmall.Images.SetKeyName(1, "")
        Me.ilsmall.Images.SetKeyName(2, "")
        Me.ilsmall.Images.SetKeyName(3, "")
        Me.ilsmall.Images.SetKeyName(4, "Precarga.ico")
        Me.ilsmall.Images.SetKeyName(5, "Homogeneizar.ico")
        Me.ilsmall.Images.SetKeyName(6, "Abrir32.ico")
        Me.ilsmall.Images.SetKeyName(7, "reloj_arena1.GIF")
        Me.ilsmall.Images.SetKeyName(8, "16 (Wizard).ico")
        Me.ilsmall.Images.SetKeyName(9, "key-icon.png")
        Me.ilsmall.Images.SetKeyName(10, "Anterior.ico")
        Me.ilsmall.Images.SetKeyName(11, "Siguiente.ico")
        Me.ilsmall.Images.SetKeyName(12, "pers_a.gif")
        '
        'gbRegistrosTablaCargada
        '
        Me.gbRegistrosTablaCargada.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRegistrosTablaCargada.Controls.Add(Me.linkCrearColumna)
        Me.gbRegistrosTablaCargada.Controls.Add(Me.IGridRegistros)
        Me.gbRegistrosTablaCargada.Location = New System.Drawing.Point(0, 108)
        Me.gbRegistrosTablaCargada.Name = "gbRegistrosTablaCargada"
        Me.gbRegistrosTablaCargada.Size = New System.Drawing.Size(888, 213)
        Me.gbRegistrosTablaCargada.TabIndex = 9
        Me.gbRegistrosTablaCargada.TabStop = False
        Me.gbRegistrosTablaCargada.Text = "Registros Tabla Cargada"
        '
        'linkCrearColumna
        '
        Me.linkCrearColumna.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.linkCrearColumna.AutoSize = True
        Me.linkCrearColumna.Location = New System.Drawing.Point(799, 187)
        Me.linkCrearColumna.Name = "linkCrearColumna"
        Me.linkCrearColumna.Size = New System.Drawing.Size(76, 13)
        Me.linkCrearColumna.TabIndex = 19
        Me.linkCrearColumna.TabStop = True
        Me.linkCrearColumna.Text = "Crear Columna"
        '
        'IGridRegistros
        '
        Me.IGridRegistros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IGridRegistros.DefaultCol.CellStyle = Me.IGrid1DefaultCellStyle
        Me.IGridRegistros.DefaultCol.ColHdrStyle = Me.IGrid1DefaultColHdrStyle
        Me.IGridRegistros.Location = New System.Drawing.Point(3, 19)
        Me.IGridRegistros.Name = "IGridRegistros"
        Me.IGridRegistros.Size = New System.Drawing.Size(882, 159)
        Me.IGridRegistros.TabIndex = 0
        '
        'pnlBotonera
        '
        Me.pnlBotonera.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlBotonera.Controls.Add(Me.Label1)
        Me.pnlBotonera.Controls.Add(Me.btnLimpiarTodo)
        Me.pnlBotonera.Controls.Add(Me.cmdCerrar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotonera.Location = New System.Drawing.Point(0, 497)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(888, 47)
        Me.pnlBotonera.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(888, 5)
        Me.Label1.TabIndex = 19
        '
        'btnLimpiarTodo
        '
        Me.btnLimpiarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiarTodo.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiarTodo.Location = New System.Drawing.Point(716, 13)
        Me.btnLimpiarTodo.Name = "btnLimpiarTodo"
        Me.btnLimpiarTodo.Size = New System.Drawing.Size(80, 23)
        Me.btnLimpiarTodo.TabIndex = 18
        Me.btnLimpiarTodo.Text = "Limpiar Todo"
        Me.btnLimpiarTodo.UseVisualStyleBackColor = False
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCerrar.ImageIndex = 0
        Me.cmdCerrar.Location = New System.Drawing.Point(802, 13)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(80, 22)
        Me.cmdCerrar.TabIndex = 0
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCerrar.UseVisualStyleBackColor = False
        '
        'gbLog
        '
        Me.gbLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbLog.Controls.Add(Me.IGridLog)
        Me.gbLog.Location = New System.Drawing.Point(0, 324)
        Me.gbLog.Name = "gbLog"
        Me.gbLog.Size = New System.Drawing.Size(888, 170)
        Me.gbLog.TabIndex = 11
        Me.gbLog.TabStop = False
        Me.gbLog.Text = "Log Tareas"
        '
        'IGridLog
        '
        IGColPattern1.CellStyle = Me.IGridLogCol0CellStyle
        IGColPattern1.ColHdrStyle = Me.IGridLogCol0ColHdrStyle
        IGColPattern1.Key = "colFecha"
        IGColPattern1.Text = "Fecha"
        IGColPattern1.Width = 150
        IGColPattern2.CellStyle = Me.IGridLogCol1CellStyle
        IGColPattern2.ColHdrStyle = Me.IGridLogCol1ColHdrStyle
        IGColPattern2.Key = "colTarea"
        IGColPattern2.Text = "Descripción Tarea"
        IGColPattern2.Width = 600
        Me.IGridLog.Cols.AddRange(New TenTec.Windows.iGridLib.iGColPattern() {IGColPattern1, IGColPattern2})
        Me.IGridLog.DefaultCol.CellStyle = Me.IGrid1DefaultCellStyle1
        Me.IGridLog.DefaultCol.ColHdrStyle = Me.IGrid1DefaultColHdrStyle1
        Me.IGridLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IGridLog.Header.Height = 20
        Me.IGridLog.Location = New System.Drawing.Point(3, 16)
        Me.IGridLog.Name = "IGridLog"
        Me.IGridLog.Size = New System.Drawing.Size(882, 151)
        Me.IGridLog.TabIndex = 0
        '
        'IGDropDownListAcciones
        '
        IGDropDownListItem1.Text = "Editar"
        IGDropDownListItem1.Value = "1"
        IGDropDownListItem2.Text = "Eliminar"
        IGDropDownListItem2.Value = "2"
        Me.IGDropDownListAcciones.Items.AddRange(New TenTec.Windows.iGridLib.iGDropDownListItem() {IGDropDownListItem1, IGDropDownListItem2})
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 544)
        Me.Controls.Add(Me.gbLog)
        Me.Controls.Add(Me.pnlBotonera)
        Me.Controls.Add(Me.gbRegistrosTablaCargada)
        Me.Controls.Add(Me.gbDataset)
        Me.Controls.Add(Me.lblLineaSuperior)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Name = "FormPrincipal"
        Me.Text = "ELT Dataset"
        Me.pnlCabecera.ResumeLayout(False)
        Me.gbDataset.ResumeLayout(False)
        Me.gbDataset.PerformLayout()
        Me.gbRegistrosTablaCargada.ResumeLayout(False)
        Me.gbRegistrosTablaCargada.PerformLayout()
        CType(Me.IGridRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonera.ResumeLayout(False)
        Me.gbLog.ResumeLayout(False)
        CType(Me.IGridLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblLineaSuperior As Label
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents gbDataset As GroupBox
    Friend WithEvents txtRuta As TextBox
    Friend WithEvents lblRuta As Label
    Friend WithEvents cmdExaminar As Button
    Friend WithEvents linkCrearTabla As LinkLabel
    Friend WithEvents txtNombreTabla As TextBox
    Friend WithEvents lblNombreTabla As Label
    Friend WithEvents ilsmall As ImageList
    Friend WithEvents gbRegistrosTablaCargada As GroupBox
    Friend WithEvents linkCrearColumna As LinkLabel
    Friend WithEvents IGridRegistros As TenTec.Windows.iGridLib.iGrid
    Friend WithEvents IGrid1DefaultCellStyle As TenTec.Windows.iGridLib.iGCellStyle
    Friend WithEvents IGrid1DefaultColHdrStyle As TenTec.Windows.iGridLib.iGColHdrStyle
    Friend WithEvents pnlBotonera As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLimpiarTodo As Button
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents gbLog As GroupBox
    Friend WithEvents IGridLog As TenTec.Windows.iGridLib.iGrid
    Friend WithEvents IGrid1DefaultCellStyle1 As TenTec.Windows.iGridLib.iGCellStyle
    Friend WithEvents IGrid1DefaultColHdrStyle1 As TenTec.Windows.iGridLib.iGColHdrStyle
    Friend WithEvents IGridLogCol0CellStyle As TenTec.Windows.iGridLib.iGCellStyle
    Friend WithEvents IGridLogCol0ColHdrStyle As TenTec.Windows.iGridLib.iGColHdrStyle
    Friend WithEvents IGridLogCol1CellStyle As TenTec.Windows.iGridLib.iGCellStyle
    Friend WithEvents IGridLogCol1ColHdrStyle As TenTec.Windows.iGridLib.iGColHdrStyle
    Friend WithEvents IGDropDownListAcciones As TenTec.Windows.iGridLib.iGDropDownList
End Class
