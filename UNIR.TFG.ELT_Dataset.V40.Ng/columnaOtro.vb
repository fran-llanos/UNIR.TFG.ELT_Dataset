Imports Comun.V40.DAL.BaseDatos
Public Class columnaOtro
    Inherits columna
#Region "Variables"
    Private _intTamano As Integer
    Private _intPrecision As Integer
    Private _intEscala As Integer
#End Region

#Region "Propiedades"
    Public Property Tamano As Integer
        Get
            Return _intTamano
        End Get
        Set(value As Integer)
            _intTamano = value
        End Set
    End Property

    ' Property to get or set _intPrecision
    Public Property Precision As Integer
        Get
            Return _intPrecision
        End Get
        Set(value As Integer)
            _intPrecision = value
        End Set
    End Property

    ' Property to get or set _intEscala
    Public Property Escala As Integer
        Get
            Return _intEscala
        End Get
        Set(value As Integer)
            _intEscala = value
        End Set
    End Property
#End Region

#Region "Métodos"
    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase columnaOtro
    ' Sintaxis      : New(tabla As Ng.tabla, nombreCol As String, tipo As DAL_OracleDbType, tamano As Integer, precision As Integer, escala As Integer, origen As ColumnOrigen)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - tipo : tipo de la columna
    '                   - tamano : longitud de la columna
    '                   - precision : tamaño cuando se trata de una columna numérica
    '                   - escala : parte decimal cuando se trata de una columna numérica
    '                   - origen : origen de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, tipo As DAL_OracleDbType, tamano As Integer, precision As Integer, escala As Integer, origen As ColumnOrigen)
        MyBase.New(tabla, nombreCol, tipo, ColumnOrigen.Fuente)
        _intPrecision = precision
        _intEscala = escala
        _intTamano = tamano
    End Sub

    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase columnaOtro
    ' Sintaxis      : New(tabla As Ng.tabla, nombreCol As String, precision As Integer, escala As Integer)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - precision : tamaño cuando se trata de una columna numérica
    '                   - escala : parte decimal cuando se trata de una columna numérica
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, precision As Integer, escala As Integer)
        MyBase.New(tabla, nombreCol, DAL_OracleDbType.Decimal, ColumnOrigen.Fuente)
        _intPrecision = precision
        _intEscala = escala
    End Sub

#End Region


End Class
