Imports Comun.V40.DAL.BaseDatos
Public Class columnaTexto
    Inherits columna

#Region "Variables"
    Private _intTamano As Integer
#End Region

#Region "Propiedades"
    ' Property to get or set _intTamano
    Public Property Tamano As Integer
        Get
            Return _intTamano
        End Get
        Set(value As Integer)
            _intTamano = value
        End Set
    End Property
#End Region

#Region "Métodos"
    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase tabla
    ' Sintaxis      : New(tabla As Ng.tabla, nombreCol As String, tamano As Integer, origen As ColumnOrigen, valor As String)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - origen : origen de la columna
    '                   - valor : valor de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, tamano As Integer, origen As ColumnOrigen, valor As String)
        MyBase.New(tabla, nombreCol, DAL_OracleDbType.NVarchar2, origen, valor)
        _intTamano = tamano
    End Sub

    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase tabla
    ' Sintaxis      : New(tabla As Ng.tabla, nombreCol As String, tamano As Integer, origen As ColumnOrigen)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - tamano : tamaño de la columna
    '                   - origen : origen de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, tamano As Integer, origen As ColumnOrigen)
        MyBase.New(tabla, nombreCol, DAL_OracleDbType.NVarchar2, ColumnOrigen.Fuente)
        _intTamano = tamano
    End Sub

    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase tabla
    ' Sintaxis      : New(tabla As Ng.tabla, nombreCol As String, tamano As Integer)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - tamano : tamaño de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, tamano As Integer)
        MyBase.New(tabla, nombreCol, DAL_OracleDbType.NVarchar2, ColumnOrigen.Fuente)
        _intTamano = tamano
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
        sql = String.Format(constantes.SQL_CREAR_COL_TEXTO, CType(Me, Ng.columna).Tabla.NombreTabla, NombreCol, CType(Me, Ng.columna).TipoCol, _intTamano)
        Me.EjecutarNoSQL(sql, CommandType.Text, Nothing)

        If Not String.IsNullOrEmpty(CType(Me, Ng.columna).ValorCol) Then
            Dim colParams(0) As IDbDataParameter
            colParams(0) = Me.CrearParametroOracle("VALOR", DAL_OracleDbType.NVarchar2, CType(Me, Ng.columna).ValorCol)
            sql = String.Format(constantes.SQL_ACTUALIZAR_VALOR_COL, CType(Me, Ng.columna).Tabla.NombreTabla, NombreCol)
            Me.EjecutarNoSQL(sql, CommandType.Text, colParams)
        End If

    End Sub
#End Region

End Class
