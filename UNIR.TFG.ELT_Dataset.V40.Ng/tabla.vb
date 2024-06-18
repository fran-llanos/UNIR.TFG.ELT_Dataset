Imports Comun.V40.DAL.BaseDatos
Public Class tabla
    Inherits EntidadBase

#Region "Variable"
    'colección de columnas
    Private _columnas As List(Of columna)
#End Region

#Region "Propiedades"

    ' Property to get or set _columnas
    Public ReadOnly Property Columnas As List(Of columna)
        Get
            Return _columnas
        End Get
    End Property
#End Region

#Region "Métodos"
    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase tabla
    ' Sintaxis      : New(ByVal nombre As String)
    ' Parametros    : 
    '                   - nombre: nombre de la tabla
    '********************************************************************************
    Public Sub New(ByVal nombre As String)
        MyBase.New
        _columnas = New List(Of columna)()
        Me.m_strNombreTabla = nombre
        Me.m_objConfigBD = constantes.CONFIGURACION_BD.ActualBDInfo
    End Sub

    '********************************************************************************
    ' Procedimiento : AddColumna
    ' Descripción   : Añade una columna a la colección
    ' Sintaxis      : AddColumna(col As columna)
    ' Parametros    : 
    '                   - col: columna a insertar
    '********************************************************************************
    Public Sub AddColumna(col As columna)
        _columnas.Add(col)
    End Sub

    '********************************************************************************
    ' Procedimiento : RemoveColumna
    ' Descripción   : Borra una columna a la colección
    ' Sintaxis      : RemoveColumna(col As columna)
    ' Parametros    : 
    '                   - col: columna a borrar
    '********************************************************************************
    Public Sub RemoveColumna(col As columna)
        _columnas.Remove(col)
    End Sub

    '********************************************************************************
    ' Procedimiento : EncontrarColumnaporNombre
    ' Descripción   : Devuelve una columna cuyo nombre corresponda con el pasado por parametro
    ' Sintaxis      : EncontrarColumnaporNombre(nombreCol As String) As columna
    ' Parametros    : 
    '                   - nombreCol: nombre de la columna a buscar
    ' Retorno       : columna encontrada
    '********************************************************************************
    Public Function EncontrarColumnaporNombre(nombreCol As String) As columna
        For Each col In _columnas
            If col.NombreCol = nombreCol Then
                Return col
            End If
        Next
        Return Nothing
    End Function

    '********************************************************************************
    ' Procedimiento : confirmarCambios
    ' Descripción   : Metodo que confirma los cambios en BBDD
    ' Sintaxis      : confirmarCambios
    ' Parametros    : 
    '********************************************************************************
    Public Sub confirmarCambios()

    End Sub

    '********************************************************************************
    ' Procedimiento : obtenerColumnasTabla
    ' Descripción   : obtenemos la estructura de la tabla y creamos las columnas
    ' Sintaxis      : obtenerColumnasTabla
    ' Parametros    : 
    '********************************************************************************
    Public Sub obtenerColumnasTabla()
        Dim ds As DataSet
        Try
            'vaciamos colección de columnas
            _columnas.Clear()
            'si se han ejecutado instrucciones ddl es posible que no se vean reflejadas hasta que no se cierre las conexion actual
            'Me.BorrarPoolConexiones()
            'obtenemos columnas tabla
            Dim colParams(0) As IDbDataParameter
            colParams(0) = Me.CrearParametroOracle(constantes.COL_NOMBRE_TABLA, DAL_OracleDbType.NVarchar2, m_strNombreTabla)
            ds = Me.EjecutarSQL(constantes.SQL_COLUMNAS_TABLA, CommandType.Text, colParams)

            For Each fila As DataRow In ds.Tables(0).Rows
                ' _columnas.Add(New columna( )
                Select Case fila.Item("DATA_TYPE").ToUpper()
                    Case "NUMBER"
                        AddColumna(New columnaNumero(Me, fila.Item(constantes.COL_COLUMN_NAME).ToString.ToUpper(), TryCastNumerico(fila.Item(constantes.COL_DATA_PRECISION), 0), TryCastNumerico(fila.Item(constantes.COL_DATA_SCALE), 0), ColumnOrigen.Fuente))
                    Case "VARCHAR2", "CHAR", "CLOB"
                        AddColumna(New columnaTexto(Me, fila.Item(constantes.COL_COLUMN_NAME).ToString.ToUpper(), TryCastNumerico(fila.Item(constantes.COL_DATA_LENGTH), 0), ColumnOrigen.Fuente))
                    Case "NCHAR", "NVARCHAR2"
                        AddColumna(New columnaTexto(Me, fila.Item(constantes.COL_COLUMN_NAME).ToString.ToUpper(), TryCastNumerico(fila.Item(constantes.COL_CHAR_LENGTH), 0), ColumnOrigen.Fuente))
                    Case "DATE", "TIMESTAMP"
                        AddColumna(New columnaDate(Me, fila.Item(constantes.COL_COLUMN_NAME).ToString.ToUpper(), ColumnOrigen.Fuente))
                    Case Else
                        AddColumna(New columnaOtro(Me, fila.Item(constantes.COL_COLUMN_NAME).ToString.ToUpper(), fila.Item(constantes.COL_DATA_TYPE).ToString.ToUpper(), TryCastNumerico(fila.Item(constantes.COL_DATA_LENGTH), 0), TryCastNumerico(fila.Item(constantes.COL_DATA_PRECISION), 0), TryCastNumerico(fila.Item(constantes.COL_DATA_SCALE), 0), ColumnOrigen.Fuente))
                End Select
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************************
    ' Procedimiento : obtenerEjemploFilas
    ' Descripción   : obtenemos los 10 primeros registros de la tabla
    ' Sintaxis      : obtenerEjemploFilas
    ' Parametros    : 
    '********************************************************************************
    Public Function obtenerEjemploFilas() As DataTable
        Dim ds As DataSet
        Try
            ds = Me.EjecutarSQL(String.Format(constantes.QUERY_SEL_OBTENER_EJEMPLO_FILAS, NombreTabla), CommandType.Text, Nothing)
            Return ds.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    '********************************************************************************
    ' Function      : ExisteTabla
    ' Descripción   : Comprueba si existe la tabla indicada en la base de datos de oracle
    ' Sintaxis      : ExisteTabla()
    ' Parametros    : 
    ' Retorno       : Se devuelve True si existe, si no, devuelve False.
    '********************************************************************************
    Public Function ExisteTabla() As Boolean
        'Se crea los parametros
        Dim colParams(0) As IDbDataParameter
        colParams(0) = Me.CrearParametroOracle(constantes.COL_TABLE_NAME, DAL_OracleDbType.Varchar2, NombreTabla, 50)
        'Se ejecuta la query.
        Dim objValor As Object = Me.EjecutarEscalar(constantes.QUERY_SEL_EXISTE_TABLA, CommandType.Text, colParams)
        'Se devuelve el valor
        Return (TryCastNumerico(objValor, 0) > 0)
    End Function

    '********************************************************************************
    ' Function      : analizarTabla
    ' Descripción   : Actualiza las estadisticas de la tabla
    ' Sintaxis      : analizarTabla()
    ' Parametros    : 
    ' Retorno       : 
    '********************************************************************************
    Public Sub analizarTabla()
        Dim params(2) As IDbDataParameter 'OracleClient.OracleParameter
        params(0) = Me.CrearParametroOracle("OWNNAME", DAL_OracleDbType.Varchar2, Me.m_objConfigBD.UserId)
        params(1) = Me.CrearParametroOracle("TABNAME", DAL_OracleDbType.Varchar2, NombreTabla)
        params(2) = Me.CrearParametroOracle("METHOD_OPT", DAL_OracleDbType.Varchar2, "FOR COLUMNS") 'OracleType.VarChar
        'Se ejecuta la query
        Me.EjecutarNoSQL(constantes.GATHER_TABLE_STATS, CommandType.StoredProcedure, params)

    End Sub

    '********************************************************************************
    ' Procedimiento : eliminarCol
    ' Descripción   : busca la columna cuyo nombre es pasado por parametro y la elimina
    '                  
    ' Sintaxis      :  eliminarCol(ByVal nombreCol As String)
    ' Parametros    : 
    '                 - nombreCol: nombre de columna a eliminar
    '********************************************************************************    
    Public Sub eliminarCol(ByVal nombreCol As String)
        Dim col As Ng.columna = EncontrarColumnaporNombre(nombreCol)
        col.EliminarCol()
        RemoveColumna(col)
    End Sub

    '********************************************************************************
    ' Procedimiento : crearCol
    ' Descripción   : crea en la tabla la columna pasada por parametro
    '                  
    ' Sintaxis      : crearCol(ByVal col As columna)
    ' Parametros    : 
    '                 - col: columna a crear
    '********************************************************************************    
    Public Sub crearCol(ByVal col As columna)
        If TypeOf col Is Ng.columnaTexto Then
            CType(col, Ng.columnaTexto).crearCol()
            AddColumna(col)
        ElseIf TypeOf col Is Ng.columnaNumero Then
            CType(col, Ng.columnaNumero).crearCol()
            AddColumna(col)
        ElseIf TypeOf col Is Ng.columnaDate Then
            CType(col, Ng.columnaDate).crearCol()
            AddColumna(col)
        End If
    End Sub

    '********************************************************************************
    ' Procedimiento : borrarColumnas
    ' Descripción   : vacia el contenido de la estructura que contiene las columnas de la tabla
    '                  
    ' Sintaxis      : borrarColumnas()
    ' Parametros    : 
    '********************************************************************************    
    Public Sub borrarColumnas()
        _columnas.Clear()
    End Sub


#End Region


End Class
