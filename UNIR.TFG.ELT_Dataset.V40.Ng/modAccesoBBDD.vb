Namespace constantes

    Public Module modAccesoBBDD
#Region "CONFIGURACIÓN"
        Public CONFIGURACION_BD As Comun.V40.DAL.BaseDatos.BBDDSectionHandler

        Friend PARAM_DATASOURCE As String = "DataSource"
        Friend PARAM_USER_ID As String = "User_Id"
        Friend PARAM_PASSWORD As String = "Password"
        Friend PARAM_ENCRIPTADO As String = "Encriptado"
        Friend PARAM_CARPETA_SCRIPTS As String = "CarpetaScripts"
        Friend PARAM_NEMONICO_CARFI As String = "NemonicoCarfi"
#End Region

#Region "COLUMNAS"
        Public COL_TABLE_NAME As String = "TABLE_NAME"
        Public COL_COLUMN_NAME As String = "COLUMN_NAME"
        Public COL_DATA_PRECISION As String = "DATA_PRECISION"
        Public COL_DATA_SCALE As String = "DATA_SCALE"
        Public COL_DATA_LENGTH As String = "DATA_LENGTH"
        Public COL_CHAR_LENGTH As String = "CHAR_LENGTH"
        Public COL_LENGTH As String = "LONGITUD"
        Public COL_DATA_TYPE As String = "DATA_TYPE"

        Friend COL_NOMBRE_TABLA As String = "NOMBRE_TABLA"

#End Region

#Region "Tipos de columnas"
        Public Const TIPO_NUMERICO As String = "NUMÉRICO"
        Public Const TIPO_TEXTO As String = "TEXTO"
        Public Const TIPO_FECHA As String = "FECHA"
#End Region


#Region "SQLs"
        ' Sentencia SQL para agregar la nueva columna temporal
        Friend alterAddQuery As String = "ALTER TABLE {0} ADD {1} {2}"

        ' Sentencia SQL para actualizar la nueva columna temporal con los datos de la columna NUMBER
        Friend updateQuery As String = "UPDATE {0} SET {1} = TO_CHAR({2})"

        ' Sentencia SQL para eliminar la columna NUMBER original
        Friend alterDropQuery As String = "ALTER TABLE {0} DROP COLUMN {1}"

        ' Sentencia SQL para renombrar la nueva columna temporal al nombre original de la columna
        Friend alterRenameQuery As String = "ALTER TABLE {0} RENAME COLUMN {1} TO {2}"

        Friend SQL_COLUMNAS_TABLA As String = "SELECT col.COLUMN_NAME,    col.DATA_TYPE,   col.CHAR_LENGTH, col.DATA_LENGTH,    col.DATA_PRECISION,    col.DATA_SCALE,    col.NULLABLE,    col.DATA_DEFAULT,    com.COMMENTS " &
                                          "  From USER_TAB_COLUMNS col " &
                                          "  JOIN USER_COL_COMMENTS com ON col.TABLE_NAME = com.TABLE_NAME AND col.COLUMN_NAME = com.COLUMN_NAME " &
                                          "  WHERE col.TABLE_NAME = :NOMBRE_TABLA " &
                                          "  ORDER BY col.COLUMN_ID"
        Friend QUERY_SEL_EXISTE_TABLA As String = "SELECT COUNT(A.TABLE_NAME) " &
                                                  "FROM USER_TABLES A " &
                                                  "WHERE A.TABLE_NAME=:TABLE_NAME"

        Friend QUERY_SEL_OBTENER_EJEMPLO_FILAS As String = "SELECT * FROM {0} WHERE ROWNUM<=10"

        Friend QUERY_CAMBIAR_NOMBRE_COLUMNA As String = "ALTER TABLE {0} RENAME COLUMN {1} TO {2}"

        Friend GATHER_TABLE_STATS As String = "DBMS_STATS.GATHER_TABLE_STATS"

        Friend SQL_CREAR_COL_TEXTO As String = "ALTER TABLE {0} ADD ({1} {2}({3}))"
        Friend SQL_ACTUALIZAR_VALOR_COL As String = "UPDATE {0} SET {1} = :VALOR"
        Friend SQL_CREAR_COL_NUM_T_D As String = "ALTER TABLE {0} ADD {1} {2}({3}, {4})"
        Friend SQL_CREAR_COL_NUM_T As String = "ALTER TABLE {0} ADD {1} {2}({3})"
        Friend SQL_CREAR_COL As String = "ALTER TABLE {0} ADD {1} {2}"
        Friend SQL_MODIFICAR_T_COL As String = "ALTER TABLE {0} MODIFY {1} {2}({3})"
        Friend SQL_MODIFICAR_T_D_COL As String = "ALTER TABLE {0} MODIFY ({1} NUMBER({2}, {3}))"
        Friend SQL_BORRAR_COL As String = "ALTER TABLE {0} DROP COLUMN {1}"
#End Region
    End Module
End Namespace
