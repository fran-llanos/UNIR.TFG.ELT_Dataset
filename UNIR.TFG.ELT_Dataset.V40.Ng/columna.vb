Imports Comun.V40.DAL.BaseDatos

Public MustInherit Class columna
    Inherits EntidadBase
#Region "Variables"
    Private _tabla As Ng.tabla
    Private _strNombreCol As String
    Private _tipoCol As DAL_OracleDbType
    Private _tipoColDesc As String
    Private _origenCol As ColumnOrigen
    Private _valorCol As String
#End Region

#Region "Propiedades"
    ' Property to get or set _strNombreCol
    Public Property NombreCol As String
        Get
            Return _strNombreCol
        End Get
        Set(value As String)
            _strNombreCol = value
        End Set
    End Property

    ' Property to get or set _tipoCol
    Public ReadOnly Property TipoCol As DAL_OracleDbType
        Get
            Return _tipoCol
        End Get
    End Property

    Public ReadOnly Property TipoColDesc As String
        Get
            Return _tipoColDesc
        End Get
    End Property

    Public ReadOnly Property OrigenCol As ColumnOrigen
        Get
            Return _origenCol
        End Get
    End Property

    Public Property ValorCol As String
        Get
            Return _valorCol
        End Get
        Set(value As String)
            _valorCol = value
        End Set
    End Property

    Public ReadOnly Property Tabla As tabla
        Get
            Return _tabla
        End Get

    End Property

#End Region

#Region "Métodos"
    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase columna
    ' Sintaxis      :  New(tabla As Ng.tabla, nombreCol As String, tipoCol As DAL_OracleDbType, origen As ColumnOrigen, valor As String)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - tipoCol : tipo Oracle de la columna
    '                   - origen : origen de la columna
    '                   - valor : valor de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, tipoCol As DAL_OracleDbType, origen As ColumnOrigen, valor As String)
        _tabla = tabla
        _strNombreCol = nombreCol
        _tipoCol = tipoCol
        obtenerDescTipo()
        _origenCol = origen
        _valorCol = valor
    End Sub

    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase columna
    ' Sintaxis      :  New(tabla As Ng.tabla, nombreCol As String, tipoCol As DAL_OracleDbType, origen As ColumnOrigen)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - tipoCol : tipo Oracle de la columna
    '                   - origen : origen de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, tipoCol As DAL_OracleDbType, origen As ColumnOrigen)
        _tabla = tabla
        _strNombreCol = nombreCol
        _tipoCol = tipoCol
        obtenerDescTipo()
        _origenCol = origen
        _valorCol = String.Empty
    End Sub

    '********************************************************************************
    ' Procedimiento : cambiarTipoColumna
    ' Descripción   : cambia el tipo oracle de una columna. NO USADO ACUTALMENTE. Este metodo supondrá una mejora 
    ' Sintaxis      :  cambiarTipoColumna(ByVal nuevoTipo As DAL_OracleDbType)
    ' Parametros    : 
    '                   - nuevoTipo : 
    '********************************************************************************
    Public Sub cambiarTipoColumna(ByVal nuevoTipo As DAL_OracleDbType)
        ' Nombre de la nueva columna temporal
        Dim tempColumnName As String = _strNombreCol & "_TEMP"
        Try
            ' Agregar la nueva columna temporal

            ' Actualizar la nueva columna temporal con los datos de la columna NUMBER

            ' Eliminar la columna NUMBER original

            ' Renombrar la nueva columna temporal al nombre original de la columna

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************************
    ' Procedimiento : cambiarNombreColumna
    ' Descripción   : cambia el nombre de la columna
    ' Sintaxis      : cambiarNombreColumna(ByVal nuevoNombre As String)
    ' Parametros    : 
    '                   - nuevoNombre : nuevo nombre de la columna
    '********************************************************************************
    Public Sub cambiarNombreColumna(ByVal nuevoNombre As String)
        Dim sql As String
        Try
            sql = String.Format(constantes.QUERY_CAMBIAR_NOMBRE_COLUMNA, _tabla.NombreTabla, Me.NombreCol, nuevoNombre)
            Me.EjecutarNoSQL(sql, CommandType.Text, Nothing)
            Me.NombreCol = nuevoNombre
            'Me.BorrarPoolConexiones()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************************
    ' Procedimiento : CambiarLongitudColumna
    ' Descripción   : cambia longitud de la columna
    '                  
    ' Sintaxis      : CambiarLongitudColumna(ByVal nuevaLongitud As Integer)
    ' Parametros    : 
    '                 - nuevaLongitud: longitud de la columna
    '********************************************************************************    
    Public Sub CambiarLongitudColumna(ByVal nuevaLongitud As Integer)
        Try
            ' Define la consulta SQL para cambiar la longitud de la columna
            Dim sql As String = String.Format(constantes.SQL_MODIFICAR_T_COL, _tabla.NombreTabla, Me._strNombreCol, Me._tipoCol, nuevaLongitud)
            Me.EjecutarNoSQL(sql, CommandType.Text, Nothing)
            CType(Me, Ng.columnaTexto).Tamano = nuevaLongitud
            'Me.BorrarPoolConexiones()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************************
    ' Procedimiento : CambiarPrecisionColumna
    ' Descripción   : cambia precision y escala(decimales) de la columna
    '                  
    ' Sintaxis      : CambiarPrecisionColumna(ByVal nuevaPrecision As Integer, ByVal nuevaEscala As Integer)
    ' Parametros    : 
    '                 - nuevaPrecision: tamaño de la columna numérica
    '                 - nuevaEscala: cantidad de decimales respecto al tamao total
    '********************************************************************************    
    Public Sub CambiarPrecisionColumna(ByVal nuevaPrecision As Integer, ByVal nuevaEscala As Integer)
        Try
            ' Define la consulta SQL para cambiar la longitud de la columna
            Dim sql As String = String.Format(constantes.SQL_MODIFICAR_T_D_COL, _tabla.NombreTabla, Me._strNombreCol, nuevaPrecision, nuevaEscala)
            Me.EjecutarNoSQL(sql, CommandType.Text, Nothing)
            CType(Me, Ng.columnaNumero).Precision = nuevaPrecision
            CType(Me, Ng.columnaNumero).Escala = nuevaEscala

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************************
    ' Procedimiento : EliminarCol
    ' Descripción   : elimina columna actual
    '                  
    ' Sintaxis      : EliminarCol()
    ' Parametros    : 
    '********************************************************************************    
    Public Sub EliminarCol()
        Try
            ' Define la consulta SQL para cambiar la longitud de la columna
            Dim sql As String = String.Format(constantes.SQL_BORRAR_COL, _tabla.NombreTabla, Me._strNombreCol)
            Me.EjecutarNoSQL(sql, CommandType.Text, Nothing)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************************
    ' Procedimiento : obtenerDescTipo
    ' Descripción   : Obtener descripción de tipo de columna a partir del tipo de oracle
    '                  
    ' Sintaxis      : obtenerDescTipo()
    ' Parametros    : 
    '********************************************************************************    
    Private Sub obtenerDescTipo()
        If _tipoCol = DAL_OracleDbType.NVarchar2 Or _tipoCol = DAL_OracleDbType.Varchar2 Or _tipoCol = DAL_OracleDbType.Char Or _tipoCol = DAL_OracleDbType.NChar Then
            _tipoColDesc = constantes.TIPO_TEXTO
        ElseIf _tipoCol = DAL_OracleDbType.Decimal Then
            _tipoColDesc = constantes.TIPO_NUMERICO
        ElseIf _tipoCol = DAL_OracleDbType.Date Then
            _tipoColDesc = constantes.TIPO_FECHA
        Else
            _tipoColDesc = _tipoCol.ToString
        End If
    End Sub


#End Region


End Class
