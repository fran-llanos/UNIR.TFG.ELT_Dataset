Imports Comun.V40.DAL.BaseDatos
Public Class columnaNumero
    Inherits columna
#Region "Variables"
    Private _intPrecision As Integer
    Private _intEscala As Integer

#End Region

#Region "Propiedades"

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
    ' Descripción   : Constructor de la clase columnaNumero
    ' Sintaxis      :  New(tabla As Ng.tabla, nombreCol As String, precision As Integer, escala As Integer, origen As ColumnOrigen, valor As String)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - precision : tamaño cuando se trata de una columna numérica
    '                   - escala : parte decimal cuando se trata de una columna numérica
    '                   - origen : origen de la columna
    '                   - valor : valor de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, precision As Integer, escala As Integer, origen As ColumnOrigen, valor As String)
        MyBase.New(tabla, nombreCol, DAL_OracleDbType.Decimal, origen, valor)
        _intPrecision = precision
        _intEscala = escala
    End Sub

    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase columnaNumero
    ' Sintaxis      : New(tabla As Ng.tabla, nombreCol As String, precision As Integer, escala As Integer, origen As ColumnOrigen)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - precision : tamaño cuando se trata de una columna numérica
    '                   - escala : parte decimal cuando se trata de una columna numérica
    '                   - origen : origen de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, precision As Integer, escala As Integer, origen As ColumnOrigen)
        MyBase.New(tabla, nombreCol, DAL_OracleDbType.Decimal, ColumnOrigen.Fuente)
        _intPrecision = precision
        _intEscala = escala
    End Sub

    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase columnaNumero
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


    '********************************************************************************
    ' Procedimiento : crearCol
    ' Descripción   : crea la columna actual en bbdd
    '                  
    ' Sintaxis      : crearCol()
    ' Parametros    : 
    '********************************************************************************    
    Public Sub crearCol()
        Dim sql As String
        If _intPrecision > 0 And _intEscala > 0 Then
            sql = String.Format(constantes.SQL_CREAR_COL_NUM_T_D, CType(Me, Ng.columna).Tabla.NombreTabla, NombreCol, CType(Me, Ng.columna).TipoCol, _intPrecision, _intEscala)
        ElseIf _intPrecision > 0 And _intEscala = 0 Then
            sql = String.Format(constantes.SQL_CREAR_COL_NUM_T, CType(Me, Ng.columna).Tabla.NombreTabla, NombreCol, CType(Me, Ng.columna).TipoCol, _intPrecision)
        Else
            sql = String.Format(constantes.SQL_CREAR_COL, CType(Me, Ng.columna).Tabla.NombreTabla, NombreCol, CType(Me, Ng.columna).TipoCol)
        End If
        Me.EjecutarNoSQL(sql, CommandType.Text, Nothing)

        If Not String.IsNullOrEmpty(CType(Me, Ng.columna).ValorCol) Then
            If TryCastNumerico(CType(Me, Ng.columna).ValorCol, Nothing) <> Nothing Then
                Dim colParams(0) As IDbDataParameter
                colParams(0) = Me.CrearParametroOracle("VALOR", DAL_OracleDbType.Decimal, TryCastNumerico(CType(Me, Ng.columna).ValorCol, Nothing))
                sql = String.Format(constantes.SQL_ACTUALIZAR_VALOR_COL, CType(Me, Ng.columna).Tabla.NombreTabla, NombreCol)
                Me.EjecutarNoSQL(sql, CommandType.Text, colParams)

            End If
        End If
    End Sub
#End Region

End Class
