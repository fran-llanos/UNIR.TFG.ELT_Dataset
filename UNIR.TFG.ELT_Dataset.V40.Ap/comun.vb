Imports Comun.V40.DAL.BaseDatos
Imports UNIR.TFG.ELT_Dataset.V40.Ng.constantes
Imports UNIR.TFG.ELT_Dataset.V40.Ng
Imports System.Configuration
Imports System.IO



'********************************************************************************
' Nombre            : UNIR.TFG.ELT_Dataset.v40.Ap.Metodos
' Descripción       : Contiene los objetos que se pueden utilizar en cualquier 
'                     parte de la aplicación.
' Creador           : 
' Fecha             : 15/05/2024
' Versión           : 1.0
' Ultima Revisión   : 15/05/2024
'********************************************************************************
'Namespace Metodos
Module comun
#Region "Variables Privadas"
        Private _oConfigurationAppSettings As System.Configuration.AppSettingsReader
#End Region

#Region "Variables globales"
        Friend WithEvents frmMain As FormPrincipal
        Public _objTabla As tabla
#End Region

#Region "Propiedades"
        Public ReadOnly Property ConfigurationAppSettings As System.Configuration.AppSettingsReader
            Get
                If _oConfigurationAppSettings Is Nothing Then
                    _oConfigurationAppSettings = New System.Configuration.AppSettingsReader
                End If
                Return _oConfigurationAppSettings
            End Get
        End Property

#End Region

#Region "Constantes"
    'SAS
    Friend Const SAS_GUARDAR_DATASET As String = "ELT_Dataset.sas"
    Friend Const SAS_GUARDAR_DATASET_SAV As String = "ELT_Dataset_sav.sas"


    'mensajes
    Friend Const MSG_SELECCIONAR_DATASET As String = "Seleccionar Dataset a cargar"
    Friend Const MSG_NO_HAY_CONFIG As String = "No hay configuración de base de datos"
    Friend Const MSG_COLUMN_CREADA As String = "Columna '{0}' creada en tabla '{1}'."
    Friend Const MSG_NO_EXISTE_TABLA As String = "No existe tabla."
    Friend Const MSG_SELECC_DATASET_NOMBRE As String = "Seleccione Dataset y Nombre de Tabla"
    Friend Const MSG_TABLA_NO_CREADA As String = "La tabla {0} no se pudo crear."
    Friend Const MSG_CONSULTE_LOG_SAS As String = "Consulte Log de SAS por si se produjo alguna incidencia en la creación de la tabla."
    Friend Const MSG_ACTUALIZADA_VISUALIZACION As String = "Actualizada la visualización de la tabla '{0}'."
    Friend Const MSG_NO_CREA_LOG_DIRECTORIO As String = "No se tiene acceso de escritura al directorio '{0}'. No se podrá crear el Log de SAS en esta ubicación."
    Friend Const MSG_NO_PERMISO_ACCESO As String = "'{0}', No tienes permiso para acceder al directorio."
    Friend Const MSG_NO_ENCUENTRA_DIRECTORIO As String = "'{0}', El directorio no se encuentra."
    Friend Const MSG_NO_TIENE_ACCESO As String = "No se tiene acceso a la ubicación donde se encuentra el programa SAS que carga el Dataset: {0}"


    Friend Const Q_TABLA_EXISTE As String = "Existe una tabla con este nombre. ¿Desea procesar el Dataset?" & vbCrLf &
                                                                                    "Si: quiero crear de nuevo la tabla." & vbCrLf &
                                                                                    "No: quiero visualizar la tabla actual." & vbCrLf &
                                                                                    "Cancelar: no deseo continuar."
    Friend Const MSG_TABLA_CREADA_OK As String = "Tabla '{0}' creada correctamente."
    Friend Const MSG_COLUMNA_EDITADA_OK As String = "Tabla '{0}' editada."
    Friend Const MSG_COLUMNA_ELIMINADA_OK As String = "Columna '{0}' eliminada en tabla '{1}'"
    Friend Const MSG_VALOR_COLUMNA_NO_OK As String = "Valor de {0} incorrecto"
    Friend Const MSG_COLUMNA_EXISTE As String = "La columna '{0}' ya existe en la tabla."
    Friend Const MSG_TAMANO_INCORRECTO As String = "Debe especificar un tamaño mayor que 0."

    'filtros
    Friend Const FILTRO_TODOS As String = "Todos los archivos (*.*)|*.*"
    Friend Const FILTRO_DATASET As String = "sas7bdat|*.sas7bdat|spss|*.sav"

    'ERRORES
    Friend Const ERR_ERROR_ENTRADA_SALIDA As String = "'{0}', Ha ocurrido un error de entrada/salida: {1}"
    Friend Const ERR_OBTENER_SECCION_BBDD As String = "Error al obtener la sección de configuración: {0}" & vbCrLf & "Detalles del error: {1}"


#End Region



#Region "PUNTO DE ENTRADA A LA APLICACIÓN"
    '********************************************************************************
    ' Procedimiento : Main
    ' Descripción   : Punto de inicio de la aplicación.
    ' Sintaxis      : Main ()
    '********************************************************************************
    Public Sub Main()
            Try
                'Se carga la configuración de las base de datos
                '                Dim A As Object = System.Configuration.ConfigurationManager.GetSection("BBDDSection")
                CONFIGURACION_BD = CType(System.Configuration.ConfigurationManager.GetSection("BBDDSection"), BBDDSectionHandler)
                If CONFIGURACION_BD Is Nothing Then
                MsgBox(MSG_NO_HAY_CONFIG)
            End If

                'Se muestra el formulario principal
                frmMain = New FormPrincipal
                Application.Run(frmMain)
            Catch ex As ConfigurationErrorsException
            MsgBox(String.Format(ERR_OBTENER_SECCION_BBDD, ex.Message, ex.ToString))
        Catch exc As Exception
            ' MostrarError(exc)
            MsgBox(exc.Message)
            frmMain.Close()
            End Try
            frmMain = Nothing
            'Se cierra el reproductor
            'Metodos.CerrarReproductor()
        End Sub
#End Region

    '********************************************************************************
    ' Function      : SeleccionarArchivo
    ' Descripción   : Muestra un formulario dentro del formulario principal
    ' Sintaxis      : SeleccionarArchivo(strTitulo As String, strFiltro As String) As String
    ' Parametros    : 
    '                 - strTitulo: Titulo a mostrar en el dialogo
    ' Retorno       : Devuelve el nombre del archivo seleccionado
    '********************************************************************************
    Function SeleccionarArchivo(ByVal strTitulo As String, Optional ByVal filtro As String = FILTRO_TODOS, Optional ByVal padre As Form = Nothing, Optional ByVal ficheroInicial As String = Nothing) As String
        'Se crea una instancia del dialogo
        Dim frmArchivo As New OpenFileDialog
        'Se configura el dialogo
        If Not strTitulo Is Nothing Then
            frmArchivo.Title = strTitulo
        End If
        If Not ficheroInicial Is Nothing AndAlso ficheroInicial.LastIndexOf("\") >= 0 Then
            frmArchivo.InitialDirectory = ficheroInicial.Substring(0, ficheroInicial.LastIndexOf("\"))
            frmArchivo.FileName = ficheroInicial.Substring(ficheroInicial.LastIndexOf("\") + 1)
        End If
        frmArchivo.RestoreDirectory = True
        frmArchivo.Filter = filtro
        frmArchivo.Multiselect = False
        If padre Is Nothing Then
            padre = FormPrincipal
        End If
        'Se muestra el dialogo
        If frmArchivo.ShowDialog(padre) = DialogResult.OK Then
            'Si se ha seleccioando un archivo, se devuelve
            Return frmArchivo.FileName
        End If
        'Por defecto se devuelve un nulo.
        Return Nothing
    End Function

    '********************************************************************************
    ' Function      : ComprobarAccesoLecturaDirectorio
    ' Descripción   : Comprobar si se tiene acceso de lectura a un directorio
    ' Sintaxis      : ComprobarAccesoLecturaDirectorio(directoryPath As String) As Boolean
    ' Parametros    : 
    '                 - directoryPath: directorio a comprobar
    ' Retorno       : true: tiene acceso, false: no tiene acceso
    '********************************************************************************
    Public Function ComprobarAccesoLecturaDirectorio(directoryPath As String) As Boolean
        Try
            Dim di As New DirectoryInfo(directoryPath)
            Dim files = di.GetFiles()
            Dim dirs = di.GetDirectories()

            Return True
        Catch ex As UnauthorizedAccessException
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' Function      : ComprobarAccesoEscrituraDirectorio
    ' Descripción   : Comprobar si se tiene acceso de escritura a un directorio
    ' Sintaxis      : ComprobarAccesoEscrituraDirectorio(directoryPath As String) As Boolean
    ' Parametros    : 
    '                 - directoryPath: directorio a comprobar
    ' Retorno       : true: tiene acceso, false: no tiene acceso
    '********************************************************************************
    Public Function ComprobarAccesoEscrituraDirectorio(directoryPath As String) As Boolean
        Try
            Dim testFilePath = Path.Combine(directoryPath, "eltDatasetTestfile.tmp")
            Using fs As FileStream = File.Create(testFilePath)
            End Using
            File.Delete(testFilePath)

            Return True
        Catch ex As UnauthorizedAccessException
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Module

'********************************************************************************
' Clase         : ComboBoxItem
' Descripción   : Representa un elemento de un Combobox
'********************************************************************************
Public Class ComboBoxItem
    Public Property Id As Integer
    Public Property Value As DAL_OracleDbType

    Public Sub New(id As Integer, value As DAL_OracleDbType)
        Me.Id = id
        Me.Value = value
    End Sub

    Public Overrides Function ToString() As String
        If Id = 1 Then
            Return TIPO_NUMERICO
        ElseIf Id = 2 Then
            Return TIPO_TEXTO
        ElseIf Id = 3 Then
            Return TIPO_FECHA
        End If
    End Function
End Class

'End Namespace
