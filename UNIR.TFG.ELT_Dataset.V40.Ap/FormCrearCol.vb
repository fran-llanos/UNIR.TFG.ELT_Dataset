Imports Comun.V40.DAL.BaseDatos
Imports UNIR.TFG.ELT_Dataset.V40.Ng
Public Class FormCrearCol
#Region "Variables"
    Private _tabla As Ng.tabla
    Private _nuevaCol As Ng.columna
#End Region
#Region "Propiedades"
    Public Property Tabla As Ng.tabla
        Get
            Return _tabla
        End Get
        Set(value As Ng.tabla)
            _tabla = value
        End Set
    End Property
    Public ReadOnly Property nuevaCol As Ng.columna
        Get
            Return _nuevaCol
        End Get
    End Property
#End Region
#Region "Eventos"

    '********************************************************************************
    ' Procedimiento : cbCombo_SelectedIndexChanged
    ' Descripción   : Gestina el cambio de elemento seleccionado en cbCombo
    '                  
    ' Sintaxis      : cbCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipos.SelectedIndexChanged
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub cbCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipos.SelectedIndexChanged
        ' Obtener el elemento seleccionado
        Dim selectedItem As ComboBoxItem = CType(cbTipos.SelectedItem, ComboBoxItem)

        If selectedItem.Id = 1 Then
            gbTamano.Enabled = True
            gbValor.Enabled = True
            txtPrecision.Enabled = True
            txtDecimales.Enabled = True
            txtTamano.Enabled = False
            txtTamano.Text = String.Empty
        ElseIf selectedItem.Id = 2 Then
            gbTamano.Enabled = True
            gbValor.Enabled = True
            txtPrecision.Enabled = False
            txtDecimales.Enabled = False
            txtPrecision.Text = String.Empty
            txtDecimales.Text = String.Empty
            txtTamano.Enabled = True
        ElseIf selectedItem.Id = 3 Then
            gbTamano.Enabled = False
            gbValor.Enabled = True
            txtTamano.Text = String.Empty
            txtPrecision.Text = String.Empty
            txtDecimales.Text = String.Empty
        Else
            gbTamano.Enabled = False
            gbValor.Enabled = False
            txtTamano.Text = String.Empty
            txtPrecision.Text = String.Empty
            txtDecimales.Text = String.Empty
            txtValorDefecto.Text = String.Empty
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : FormCrearCol_Load
    ' Descripción   : gestiona el evento load del formulario
    '                  
    ' Sintaxis      : FormCrearCol_Load(sender As Object, e As EventArgs) Handles Me.Load
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub FormCrearCol_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargarComboTipos()
    End Sub

    '********************************************************************************
    ' Procedimiento : txtNombreCol_LostFocus
    ' Descripción   : gestiona el evento lostfocus de txtNombreCol
    '                  
    ' Sintaxis      : txtNombreCol_LostFocus(sender As Object, e As EventArgs) Handles txtNombreCol.LostFocus
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub txtNombreCol_LostFocus(sender As Object, e As EventArgs) Handles txtNombreCol.LostFocus
        If Not IsValidColumnName(txtNombreCol.Text) Then
            txtNombreCol.Text = String.Empty
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : txtTamano_LostFocus
    ' Descripción   : gestiona el evento lostfocus de txtTamano
    '                  
    ' Sintaxis      : txtTamano_LostFocus(sender As Object, e As EventArgs) Handles txtTamano.LostFocus
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub txtTamano_LostFocus(sender As Object, e As EventArgs) Handles txtTamano.LostFocus
        If Not EsNumeroValido(txtTamano.Text) Then
            txtTamano.Text = String.Empty
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : txtPrecision_LostFocus
    ' Descripción   : gestiona el evento lostfocus de txtPrecision
    '                  
    ' Sintaxis      : txtPrecision_LostFocus(sender As Object, e As EventArgs) Handles txtPrecision.LostFocus
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub txtPrecision_LostFocus(sender As Object, e As EventArgs) Handles txtPrecision.LostFocus
        If Not EsNumeroValido(txtPrecision.Text) Then
            txtPrecision.Text = String.Empty
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : txtDecimales_LostFocus
    ' Descripción   : gestiona el evento lostfocus de txtDecimales
    '                  
    ' Sintaxis      : txtDecimales_LostFocus(sender As Object, e As EventArgs) Handles txtDecimales.LostFocus
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub txtDecimales_LostFocus(sender As Object, e As EventArgs) Handles txtDecimales.LostFocus
        If Not EsNumeroValido(txtDecimales.Text) Then
            txtDecimales.Text = String.Empty
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : txtValorDefecto_LostFocus
    ' Descripción   : gestiona el evento lostfocus de txtValorDefecto
    '                  
    ' Sintaxis      : txtValorDefecto_LostFocus(sender As Object, e As EventArgs) Handles txtValorDefecto.LostFocus
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub txtValorDefecto_LostFocus(sender As Object, e As EventArgs) Handles txtValorDefecto.LostFocus
        Dim selectedItem As ComboBoxItem = CType(cbTipos.SelectedItem, ComboBoxItem)
        Dim parsedDate As Date
        If selectedItem.Id = 1 Then
            If Not EsNumeroValido(txtValorDefecto.Text) Then
                txtValorDefecto.Text = String.Empty
            End If
        ElseIf selectedItem.Id = 3 Then

            If Not Date.TryParse(txtValorDefecto.Text, parsedDate) Then
                txtValorDefecto.Text = String.Empty
            End If
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : btnGuardar_Click
    ' Descripción   : guarda la información de la columna a crear
    '                  
    ' Sintaxis      : btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            ' Obtener el elemento seleccionado
            Dim selectedItem As ComboBoxItem = CType(cbTipos.SelectedItem, ComboBoxItem)
            If Not _tabla.EncontrarColumnaporNombre(txtNombreCol.Text.ToUpper) Is Nothing Then
                MsgBox(String.Format(MSG_COLUMNA_EXISTE, txtNombreCol.Text.ToUpper))
                DialogResult = DialogResult.None
            Else
                If selectedItem.Id = 1 Then
                    _nuevaCol = New Ng.columnaNumero(_tabla, txtNombreCol.Text.ToUpper, TryCastNumerico(txtPrecision.Text, 0), TryCastNumerico(txtDecimales.Text, 0), ColumnOrigen.Generada, txtValorDefecto.Text)
                    _objTabla.crearCol(_nuevaCol)
                ElseIf selectedItem.Id = 2 Then
                    If TryCastNumerico(txtTamano.Text, 0) = 0 Then
                        MsgBox(MSG_TAMANO_INCORRECTO)
                        DialogResult = DialogResult.None
                    Else
                        _nuevaCol = New Ng.columnaTexto(_tabla, txtNombreCol.Text.ToUpper, TryCastNumerico(txtTamano.Text, 0), ColumnOrigen.Generada, txtValorDefecto.Text)
                        _objTabla.crearCol(_nuevaCol)

                    End If
                ElseIf selectedItem.Id = 3 Then
                    _nuevaCol = New Ng.columnaDate(_tabla, txtNombreCol.Text.ToUpper, ColumnOrigen.Generada, txtValorDefecto.Text)
                    _objTabla.crearCol(_nuevaCol)
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Métodos"
    '********************************************************************************
    ' Procedimiento : cargarComboTipos
    ' Descripción   : carga tipos de columnas en cbTipos
    '                  
    ' Sintaxis      : cargarComboTipos()
    ' Parametros    : 
    '********************************************************************************    
    Private Sub cargarComboTipos()
        ' Crear los elementos
        Dim item1 As New ComboBoxItem(1, DAL_OracleDbType.Decimal)
        Dim item2 As New ComboBoxItem(2, DAL_OracleDbType.NVarchar2)
        Dim item3 As New ComboBoxItem(3, DAL_OracleDbType.Date)


        ' Agregar los elementos al ComboBox
        cbTipos.Items.Add(item1)
        cbTipos.Items.Add(item2)
        cbTipos.Items.Add(item3)
    End Sub

#End Region

End Class