Imports Comun.V40.DAL.BaseDatos
Public Class columnaDate
    Inherits columna

#Region "Métodos"
    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase columnaDate
    ' Sintaxis      :  New(tabla As Ng.tabla, nombreCol As String, origen As ColumnOrigen, valor As String)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - origen : origen de la columna
    '                   - valor : valor de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, origen As ColumnOrigen, valor As String)
        MyBase.New(tabla, nombreCol, DAL_OracleDbType.Date, origen, valor)
    End Sub

    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase columnaDate
    ' Sintaxis      :  New(tabla As Ng.tabla, nombreCol As String, origen As ColumnOrigen)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '                   - origen : origen de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String, origen As ColumnOrigen)
        MyBase.New(tabla, nombreCol, DAL_OracleDbType.Date, origen)
    End Sub

    '********************************************************************************
    ' Procedimiento : New
    ' Descripción   : Constructor de la clase columnaDate
    ' Sintaxis      :  New(tabla As Ng.tabla, nombreCol As String)
    ' Parametros    : 
    '                   - tabla :referencia a la tabla a la que pertenece
    '                   - nombreCol : nombre de la columna
    '********************************************************************************
    Public Sub New(tabla As Ng.tabla, nombreCol As String)
        MyBase.New(tabla, nombreCol, DAL_OracleDbType.Date, ColumnOrigen.Fuente)
    End Sub

    '********************************************************************************
    ' Procedimiento : IsValidDate
    ' Descripción   : Método para verificar si la fecha es válida con la cultura actual de equipo
    ' Sintaxis      :  IsValidDate(dateString As String) As Boolean
    ' Parametros    : 
    '                   - dateString : fecha a comprobar
    ' Retorno       : True --> fecha valida, False --> fecha no valida 
    '********************************************************************************
    Public Shared Function IsValidDate(dateString As String) As Boolean
        Dim tempDate As DateTime
        Return DateTime.TryParse(dateString, tempDate)
    End Function

    '********************************************************************************
    ' Procedimiento : crearCol
    ' Descripción   : crea la columna actual en bbdd
    '                  
    ' Sintaxis      : crearCol()
    ' Parametros    : 
    '********************************************************************************    
    Public Sub crearCol()
        Dim sql As String
        sql = String.Format(constantes.SQL_CREAR_COL, CType(Me, Ng.columna).Tabla.NombreTabla, NombreCol, CType(Me, Ng.columna).TipoCol)
        Me.EjecutarNoSQL(sql, CommandType.Text, Nothing)

        If Not String.IsNullOrEmpty(CType(Me, Ng.columna).ValorCol) Then
            If ConvertStringToDate(CType(Me, Ng.columna).ValorCol) <> Nothing Then
                Dim colParams(0) As IDbDataParameter
                colParams(0) = Me.CrearParametroOracle("VALOR", DAL_OracleDbType.Date, ConvertStringToDate(CType(Me, Ng.columna).ValorCol))
                sql = String.Format(constantes.SQL_ACTUALIZAR_VALOR_COL, CType(Me, Ng.columna).Tabla.NombreTabla, NombreCol)
                Me.EjecutarNoSQL(sql, CommandType.Text, colParams)

            End If
        End If
    End Sub

#End Region
End Class
