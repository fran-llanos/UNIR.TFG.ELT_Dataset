Imports System.IO
Imports TenTec.Windows.iGridLib
Public Class FormPrincipal

#Region "Eventos"
    '********************************************************************************
    ' Procedimiento : cmdExaminar_Click
    ' Descripción   : Captura el evento click del botón Examinar. En el dialogo de selección de archivos que se muestra se podrán 
    '                 seleccionar solo archivos con extensión sas7bdat o sav
    ' Sintaxis      : cmdExaminar_Click(sender As Object, e As System.EventArgs)
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************
    Private Sub cmdExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExaminar.Click
        'Se muestra el dialogo para seleccionar un fichero.
        Dim strFiltro As New System.Text.StringBuilder
        strFiltro.Append(FILTRO_DATASET)
        Dim strTitulo As String = MSG_SELECCIONAR_DATASET
        Dim fichero As String = SeleccionarArchivo(strTitulo, strFiltro.ToString, Me, txtRuta.Text)
        'Si se ha seleccionado un fichero, se agrega a la lista.
        If Not fichero Is Nothing Then
            Me.txtRuta.Text = fichero
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : linkCrearTabla_LinkClicked
    ' Descripción   : Captura el evento click del link linkCrearTabla
    '                 Gestiona todas las acciones de creación de la tabla Oracle a partir de los valores establecidos  
    ' Sintaxis      : linkCrearTabla_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkCrearTabla.LinkClicked
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************
    Private Sub linkCrearTabla_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkCrearTabla.LinkClicked
        cargarTablaDataset()
    End Sub

    '********************************************************************************
    ' Procedimiento : btnLimpiarTodo_Click
    ' Descripción   : Captura el evento click del botón btnLimpiarTodo
    '                 Gestiona todas las acciones de limpieza de todos los objetos y cajas usadas actualmente 
    ' Sintaxis      : btnLimpiarTodo_Click(sender As Object, e As EventArgs) Handles btnLimpiarTodo.Click
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************
    Private Sub btnLimpiarTodo_Click(sender As Object, e As EventArgs) Handles btnLimpiarTodo.Click
        _objTabla = Nothing
        txtNombreTabla.Text = String.Empty
        txtRuta.Text = String.Empty
        limpiarTabla()
        IGridLog.Rows.Clear()
    End Sub


    '********************************************************************************
    ' Procedimiento : cmdCerrar_Click
    ' Descripción   : Captura el evento click del botón cmdCerrar
    '                 Cierra la aplicación 
    ' Sintaxis      : cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************
    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    '********************************************************************************
    ' Procedimiento : linkCrearColumna_LinkClicked
    ' Descripción   : Captura el evento click del link linkCrearColumna
    '                 Gestiona todas las acciones de creación de una nueva coluna 
    ' Sintaxis      : linkCrearColumna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkCrearColumna.LinkClicked
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************
    Private Sub linkCrearColumna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkCrearColumna.LinkClicked
        If Not _objTabla Is Nothing Then
            Dim frm As New FormCrearCol
            frm.Tabla = _objTabla
            If frm.ShowDialog(Me) = DialogResult.OK Then
                cargarTablaGrid()
                insertarLogs(String.Format(MSG_COLUMN_CREADA, frm.nuevaCol.NombreCol, _objTabla.NombreTabla))
            End If
        Else
            MsgBox(MSG_NO_EXISTE_TABLA)
        End If

    End Sub

    '********************************************************************************
    ' Procedimiento : txtNombreTabla_KeyPress
    ' Descripción   : txtNombreTabla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreTabla.KeyPress
    '                  
    ' Sintaxis      : Metodo que gestiona la presión de una tecla sobre el textbox txtNombreTabla
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub txtNombreTabla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreTabla.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cargarTablaDataset()
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : IGridRegistros_ColHdrComboBeforeCommit
    ' Descripción   : Captura el evento click del link linkEditarColumna
    '                 Gestiona todas las acciones de edición de la columna a la que pertenece la celda marcada en el grid 
    ' Sintaxis      : IGridRegistros_ColHdrComboBeforeCommit(sender As Object, e As iGColHdrComboBeforeCommitEventArgs) Handles IGridRegistros.ColHdrComboBeforeCommit
    ' Parametros    : 
    '                 - sender: objeto que lanza el evento
    '                 - e: Información adicional sobre el evento.
    '********************************************************************************    
    Private Sub IGridRegistros_ColHdrComboBeforeCommit(sender As Object, e As iGColHdrComboBeforeCommitEventArgs) Handles IGridRegistros.ColHdrComboBeforeCommit
        If e.NewValue = 1 Then
            e.Result = iGEditResult.Proceed
            'editar
            editarColumna(IGridRegistros.Cols(e.ColIndex).Key)
        ElseIf e.NewValue = 2 Then
            e.Result = iGEditResult.Proceed
            'eliminar
            eliminarColumna(IGridRegistros.Cols(e.ColIndex).Key)
        End If
    End Sub
#End Region

#Region "Métodos"

    '********************************************************************************
    ' Procedimiento : cargarTablaDataset
    ' Descripción   : Crea en oracle la tabla que contiene el dataset y la muestra en pantalla
    '                  
    ' Sintaxis      : cargarTablaDataset()
    ' Parametros    : 
    '********************************************************************************    
    Private Sub cargarTablaDataset()
        Dim boolExisteTabla As Boolean = False
        Dim boolTablaOk As Boolean = False
        Dim resultDialog As DialogResult
        Try

            If String.IsNullOrEmpty(txtNombreTabla.Text) Or String.IsNullOrEmpty(txtRuta.Text) Then
                MsgBox(MSG_SELECC_DATASET_NOMBRE)
            Else

                _objTabla = New Ng.tabla(txtNombreTabla.Text.ToUpper)
                boolExisteTabla = _objTabla.ExisteTabla
                If boolExisteTabla Then
                    resultDialog = MessageBox.Show(Me, Q_TABLA_EXISTE, Me.lblTitulo.Text, MessageBoxButtons.YesNoCancel)
                    If resultDialog = DialogResult.No Then
                        boolTablaOk = True
                    End If
                End If
                Me.Cursor = Cursors.WaitCursor
                If Not boolExisteTabla Or resultDialog = DialogResult.Yes Then
                    boolTablaOk = cargarDatasetSAS()
                    If boolTablaOk Then
                        insertarLogs(String.Format(MSG_TABLA_CREADA_OK, txtNombreTabla.Text))
                    End If
                End If

                If resultDialog <> DialogResult.Cancel Then
                    If boolTablaOk Then
                        _objTabla.analizarTabla()
                        cargarTablaGrid()
                        insertarLogs(String.Format(MSG_ACTUALIZADA_VISUALIZACION, txtNombreTabla.Text))
                        If boolExisteTabla And resultDialog = DialogResult.Yes Then
                            insertarLogs(MSG_CONSULTE_LOG_SAS)
                        End If
                    Else
                        MsgBox(String.Format(MSG_TABLA_NO_CREADA, txtNombreTabla.Text))
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    '********************************************************************************
    ' Procedimiento : cargarDatasetSAS
    ' Descripción   : Lanza el SAS que crea la tabla a partir del dataset seleccionado 
    ' Sintaxis      : cargarDatasetSAS() As Boolean
    ' Parametros    : 
    ' Retorno       : True --> la tabla se creó correctamente, False --> la tabla no se creó.
    '********************************************************************************
    Private Function cargarDatasetSAS() As Boolean
        Dim objSAS As New Ng.SAS("CARFI")
        Dim strPathDataset As String 'sin barra del final
        Dim strPathProgramaSAS As String = CType(ConfigurationAppSettings.GetValue("CarpetaProgramasSAS", GetType(System.String)), String)
        Dim ds As DataSet
        Dim strLibSAS As String = "T_BSD_W" 'libreria SAS desde la que se tiene acceso al esquema de bbdd de oracle donde se creará la tabla
        Dim strExt As String = System.IO.Path.GetExtension(txtRuta.Text)
        Try

            strPathDataset = Path.GetDirectoryName(txtRuta.Text)
            If ComprobarAccesoLecturaDirectorio(strPathProgramaSAS) Then

                If Not ComprobarAccesoEscrituraDirectorio(strPathDataset) Then
                    insertarLogs(String.Format(MSG_NO_CREA_LOG_DIRECTORIO, strPathDataset))
                End If
                strPathDataset = strPathDataset.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) 'quitamos la ultima barra
                objSAS.RutaPrograma = strPathProgramaSAS
                If Not IsNothing(strExt) Then
                    'Se obtiene el tipo de fichero dependiendo de la extension
                    Select Case strExt.Replace(".", String.Empty).ToUpper()
                        Case "SAS7BDAT"
                            objSAS.NombrePrograma = SAS_GUARDAR_DATASET
                            ds = objSAS.dsLlamarSAS(strPathDataset & "*" & Path.GetFileNameWithoutExtension(txtRuta.Text) & "*" & strLibSAS & "*" & txtNombreTabla.Text)
                        Case "SAV"
                            objSAS.NombrePrograma = SAS_GUARDAR_DATASET_SAV
                            ds = objSAS.dsLlamarSAS(strPathDataset & "*" & Path.GetFileName(txtRuta.Text) & "*" & strLibSAS & "*" & txtNombreTabla.Text)
                    End Select
                End If

                'comprobamos si la tabla se ha creado correctamente
                Return _objTabla.ExisteTabla
            Else
                Throw New Exception(String.Format(MSG_NO_TIENE_ACCESO, strPathProgramaSAS))
            End If
        Catch ex As Exception
            Select Case True
                Case TypeOf ex Is UnauthorizedAccessException
                    Throw New Exception(String.Format(MSG_NO_PERMISO_ACCESO, strPathProgramaSAS))
                Case TypeOf ex Is DirectoryNotFoundException
                    Throw New Exception(String.Format(MSG_NO_ENCUENTRA_DIRECTORIO, strPathProgramaSAS))
                Case TypeOf ex Is IOException
                    Throw New Exception(String.Format(ERR_ERROR_ENTRADA_SALIDA, strPathProgramaSAS, ex.Message))
                Case Else
                    Throw ex
            End Select
        End Try


    End Function


    '********************************************************************************
    ' Procedimiento : cargarTablaGrid
    ' Descripción   : Crea un Grid que contiene la estructura de la tabla creada. También se muestra una muestra de los registros que contiene.
    '                  
    ' Sintaxis      : cargarTablaGrid()
    ' Parametros    : 
    '********************************************************************************    
    Private Sub cargarTablaGrid()

        _objTabla.BorrarPoolConexiones()
        _objTabla.borrarColumnas()
        _objTabla.obtenerColumnasTabla()

        IGridRegistros.BeginUpdate()

        limpiarTabla()

        IGridRegistros.Cols.Count = _objTabla.Columnas.Count

        Dim dt As DataTable = _objTabla.obtenerEjemploFilas
        IGridRegistros.FillWithData(dt)

        Dim i As Integer = 0
        For Each col As Ng.columna In _objTabla.Columnas
            With IGridRegistros.Header.Cells(0, i)
                .DropDownControl = IGDropDownListAcciones
            End With
            i = i + 1
        Next

        IGridRegistros.Cols.AutoWidth()

        IGridRegistros.EndUpdate()

    End Sub

    '********************************************************************************
    ' Procedimiento : insertarLogs
    ' Descripción   : inserta en el Grid de Logs una nueva linea con la fecha actualy el texto pasado por parametro. 
    ' Sintaxis      : insertarLogs(ByVal desc As String)
    ' Parametros    : 
    '                   - desc : texto del log a mostrar
    '********************************************************************************
    Private Sub insertarLogs(ByVal desc As String)
        With IGridLog.Rows.Insert(0)
            .Cells("colFecha").Value = Now
            .Cells("colTarea").Value = desc
        End With

    End Sub

    '********************************************************************************
    ' Procedimiento : limpiarTabla
    ' Descripción   : Limpia el Grid de registros. Tanto columnas como regitros. 
    ' Sintaxis      : limpiarTabla()
    ' Parametros    : 
    '                   - desc : texto del log a mostrar
    '********************************************************************************
    Private Sub limpiarTabla()
        If IGridRegistros.Rows.Count > 0 Then
            IGridRegistros.Rows.Clear()
        End If
        If IGridRegistros.Cols.Count > 0 Then
            IGridRegistros.Cols.Clear()
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : eliminarColumna
    ' Descripción   : Elimina la columna seleccionada
    '                  
    ' Sintaxis      : eliminarColumna(ByVal nombreCol As String)
    ' Parametros    : 
    '                 - nombreCol: 
    '********************************************************************************    
    Private Sub eliminarColumna(ByVal nombreCol As String)
        _objTabla.eliminarCol(nombreCol)
        cargarTablaGrid()
        insertarLogs(String.Format(MSG_COLUMNA_ELIMINADA_OK, nombreCol, _objTabla.NombreTabla))
    End Sub

    '********************************************************************************
    ' Procedimiento : editarColumna
    ' Descripción   : muestra el formulario donde editar cambiar las caracteristicas de la columna seleccionada
    '                  
    ' Sintaxis      : editarColumna(ByVal nombreCol As String)
    ' Parametros    : 
    '                 - nombreCol: 
    '********************************************************************************    
    Private Sub editarColumna(ByVal nombreCol As String)
        Dim frm As New FormEditarCol
        Dim col As Ng.columna
        If Not String.IsNullOrEmpty(nombreCol) Then
            'obtenemos la columna seleccionada dentro de las columnas de la tabla
            col = _objTabla.EncontrarColumnaporNombre(nombreCol)
            If Not col Is Nothing Then
                frm.EditCol = col
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    cargarTablaGrid()
                    insertarLogs(String.Format(MSG_COLUMNA_EDITADA_OK, txtNombreTabla.Text))
                End If

            End If
        End If
    End Sub



#End Region


End Class
