Public Class SAS
#Region "Variables"
    Private _strNemonico As String
    Private _strNombrePrograma As String
    Private _strRutaPrograma As String
    Private _strPlantilla As String
    Private _strApp As String
#End Region

#Region "Propiedades"
    Public ReadOnly Property App() As String
        Get
            Return Me._strApp
        End Get
    End Property

    Public Property NombrePrograma() As String
        Get
            Return Me._strNombrePrograma
        End Get
        Set(value As String)
            Me._strNombrePrograma = value
        End Set
    End Property
    Public Property RutaPrograma() As String
        Get
            Return Me._strRutaPrograma
        End Get
        Set(value As String)
            Me._strRutaPrograma = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New(ByVal strApp As String)
        MyBase.New()
        _strApp = strApp
    End Sub
#End Region


    '********************************************************************************
    ' Procedimiento : dsLlamarSAS
    ' Descripción   : crea una instancia sas y ejecuta el programa NombrePrograma còn los parametros pasados por parametro
    '                  
    ' Sintaxis      : dsLlamarSAS(ByVal strParametros As String) As DataSet
    ' Parametros    : 
    '                 - strParametros: parametros que se pasan la procedimiento sas
    '********************************************************************************    
    Public Function dsLlamarSAS(ByVal strParametros As String) As DataSet

        Dim ws As New wsSAS.UtilidadesSAS
        Dim ds As New DataSet
        Dim strUID As String = Nothing
        Try
            ' Evita las credenciales del proxy
            ws.Proxy = System.Net.WebRequest.DefaultWebProxy
            ws.Timeout = System.Threading.Timeout.Infinite

            'inicio instancia SAS
            ds = ws.dsCrearInstanciaSAS(_strApp, strUID)

            'ejecutar procedimiento
            ds = ws.dsEjecutarSAS(strUID, _strRutaPrograma & _strNombrePrograma, strParametros)
            'fin instancia web
            ds = ws.dsCerrarInstanciaSAS(strUID)


            'Se devuelve el resultado
            dsLlamarSAS = ds
        Catch ex As Exception
            ex.Source = "dsLlamarSAS - " & ex.Source
            Throw ex
        Finally
            ds.Dispose()
            ws.Dispose()
        End Try

    End Function


End Class
