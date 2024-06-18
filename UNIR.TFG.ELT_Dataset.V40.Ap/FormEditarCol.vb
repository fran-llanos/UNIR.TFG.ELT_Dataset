Imports UNIR.TFG.ELT_Dataset.V40.Ng

Imports TenTec.Windows.iGridLib

Public Class FormEditarCol
#Region "Variables"
    Private _editCol As Ng.columna
#End Region

#Region "Propiedades"
    Public Property EditCol As Ng.columna
        Get
            Return _editCol
        End Get
        Set(value As Ng.columna)
            _editCol = value
        End Set
    End Property

#End Region

#Region "Eventos"
    '********************************************************************************
    ' Procedimiento : FormEditarCol_Load
    ' Descripción   : Evento Load de la página 
    ' Sintaxis      : FormEditarCol_Load(sender As Object, e As EventArgs) Handles Me.Load
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************
    Private Sub FormEditarCol_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargarAtributos()
    End Sub

    '********************************************************************************
    ' Procedimiento : IGridEditarColumnas_AfterCommitEdit
    ' Descripción   : Comprueba si él valor introducido para el atributo seleccionado es correcto 
    ' Sintaxis      : IGridEditarColumnas_AfterCommitEdit(sender As Object, e As iGAfterCommitEditEventArgs) Handles IGridEditarColumnas.AfterCommitEdit
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************
    Private Sub IGridEditarColumnas_AfterCommitEdit(sender As Object, e As iGAfterCommitEditEventArgs) Handles IGridEditarColumnas.AfterCommitEdit
        Dim boolValido As Boolean = True
        If IGridEditarColumnas.CurCell.Text <> String.Empty Then
            If IGridEditarColumnas.CurRow.Tag = constantes.COL_COLUMN_NAME Then
                If Not IGridEditarColumnas.CurCell.Text Is Nothing AndAlso Not IsValidColumnName(IGridEditarColumnas.CurCell.Text) Then
                    boolValido = False
                End If
            ElseIf IGridEditarColumnas.CurRow.Tag = constantes.COL_LENGTH Then
                If Not EsNumeroValido(IGridEditarColumnas.CurCell.Text) OrElse TryCastNumerico(IGridEditarColumnas.CurCell.Text, 0) < TryCastNumerico(IGridEditarColumnas.CurRow.Cells("colValorActual").Text, 0) Then
                    boolValido = False
                End If
            ElseIf IGridEditarColumnas.CurRow.Tag = constantes.COL_DATA_PRECISION Then
                If Not EsNumeroValido(IGridEditarColumnas.CurCell.Text) OrElse TryCastNumerico(IGridEditarColumnas.CurCell.Text, 0) < TryCastNumerico(IGridEditarColumnas.CurRow.Cells("colValorActual").Text, 0) Then
                    boolValido = False
                End If
            ElseIf IGridEditarColumnas.CurRow.Tag = constantes.COL_DATA_SCALE Then
                If Not EsNumeroValido(IGridEditarColumnas.CurCell.Text) OrElse TryCastNumerico(IGridEditarColumnas.CurCell.Text, 0) < TryCastNumerico(IGridEditarColumnas.CurRow.Cells("colValorActual").Text, 0) Then
                    boolValido = False
                End If
            End If
        End If

        If Not boolValido Then
            IGridEditarColumnas.CurCell.Value = String.Empty
            MsgBox(String.Format(MSG_VALOR_COLUMNA_NO_OK, IGridEditarColumnas.CurCell.Col.Text))
        End If

    End Sub

    '********************************************************************************
    ' Procedimiento : btnGuardar_Click
    ' Descripción   : Efectua las modificaciones especificadas 
    ' Sintaxis      : btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim nuevoValor As String
        For Each fila As iGRow In IGridEditarColumnas.Rows
            nuevoValor = fila.Cells("colValorNuevo").Text.ToUpper.Trim
            If nuevoValor <> String.Empty And nuevoValor <> _editCol.NombreCol Then
                If fila.Tag = constantes.COL_COLUMN_NAME Then
                    If Not _editCol.Tabla.EncontrarColumnaporNombre(nuevoValor) Is Nothing Then
                        MsgBox(String.Format("La columna '{0}' ya existe en la tabla.", nuevoValor))
                        DialogResult = DialogResult.None
                    Else
                        'cambiar nombre columna
                        _editCol.cambiarNombreColumna(nuevoValor)
                    End If

                ElseIf fila.Tag = constantes.COL_LENGTH AndAlso nuevoValor <> CType(_editCol, Ng.columnaTexto).Tamano Then
                    'cambiar tamaño de columna
                    _editCol.CambiarLongitudColumna(nuevoValor)
                ElseIf fila.Tag = constantes.COL_DATA_PRECISION AndAlso nuevoValor <> CType(_editCol, Ng.columnaNumero).Precision Then
                    'cambiar precision columna
                    _editCol.CambiarPrecisionColumna(nuevoValor, CType(_editCol, Ng.columnaNumero).Escala)
                ElseIf fila.Tag = constantes.COL_DATA_SCALE AndAlso nuevoValor <> CType(_editCol, Ng.columnaNumero).Escala Then
                    'cambiar escala columna
                    _editCol.CambiarPrecisionColumna(CType(_editCol, Ng.columnaNumero).Precision, nuevoValor)
                End If
            End If
        Next
    End Sub

#End Region

#Region "Métodos"
    '********************************************************************************
    ' Procedimiento : cargarAtributos
    ' Descripción   : Carga los atributos de la columna en el Grid 
    ' Sintaxis      : cargarAtributos()
    ' Parametros    : 
    '********************************************************************************
    Private Sub cargarAtributos()
        IGridEditarColumnas.BeginUpdate()
        With IGridEditarColumnas.Rows.Add
            .Cells("colAtributo").Value = "Nombre"
            .Cells("colValorActual").Value = _editCol.NombreCol
            .Tag = constantes.COL_COLUMN_NAME
        End With

        With IGridEditarColumnas.Rows.Add
            .Cells("colAtributo").Value = "Tipo"
            .Cells("colValorActual").Value = _editCol.TipoColDesc
            .Cells("colValorNuevo").Enabled = TenTec.Windows.iGridLib.iGBool.False
            .Cells("colValorNuevo").Value = _editCol.TipoColDesc
            .Tag = constantes.COL_DATA_TYPE
        End With

        If TypeOf _editCol Is Ng.columnaTexto Then
            With IGridEditarColumnas.Rows.Add
                .Cells("colAtributo").Value = "Tamaño"
                .Cells("colValorActual").Value = CType(_editCol, Ng.columnaTexto).Tamano
                If CType(_editCol, Ng.columnaTexto).Tamano = 0 Then
                    .Cells("colValorNuevo").Enabled = TenTec.Windows.iGridLib.iGBool.False
                    .Cells("colValorNuevo").Value = CType(_editCol, Ng.columnaTexto).Tamano
                End If

                .Tag = constantes.COL_LENGTH
            End With

        End If

        If TypeOf _editCol Is Ng.columnaNumero Then
            With IGridEditarColumnas.Rows.Add
                .Cells("colAtributo").Value = "Precisión"
                .Cells("colValorActual").Value = CType(_editCol, Ng.columnaNumero).Precision
                If CType(_editCol, Ng.columnaNumero).Precision = 0 Then
                    .Cells("colValorNuevo").Enabled = TenTec.Windows.iGridLib.iGBool.False
                    .Cells("colValorNuevo").Value = CType(_editCol, Ng.columnaNumero).Precision
                End If
                .Tag = constantes.COL_DATA_PRECISION
            End With

            With IGridEditarColumnas.Rows.Add
                .Cells("colAtributo").Value = "Escala"
                .Cells("colValorActual").Value = CType(_editCol, Ng.columnaNumero).Escala
                If CType(_editCol, Ng.columnaNumero).Escala = 0 Then
                    .Cells("colValorNuevo").Enabled = TenTec.Windows.iGridLib.iGBool.False
                    .Cells("colValorNuevo").Value = CType(_editCol, Ng.columnaNumero).Escala
                End If
                .Tag = constantes.COL_DATA_SCALE
            End With

        End If
        IGridEditarColumnas.EndUpdate()
    End Sub


#End Region


End Class