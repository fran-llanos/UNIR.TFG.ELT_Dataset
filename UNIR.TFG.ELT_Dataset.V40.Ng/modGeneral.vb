Imports System.Text.RegularExpressions
Public Module modGeneral
    Public Enum ColumnOrigen
        Fuente
        Generada
    End Enum

#Region "Métodos"
    '********************************************************************************
    ' Procedimiento : ConvertStringToDate
    ' Descripción   : Método para convertir una cadena a fecha con la cultura actual de equipo
    ' Sintaxis      :  ConvertStringToDate(dateString As String) As Boolean
    ' Parametros    : 
    '                   - dateString : fecha a comprobar
    ' Retorno       : fecha en formato Datetime si se ha podido parsear correctamente, nothing en caso contrario. 
    '********************************************************************************
    Public Function ConvertStringToDate(dateString As String) As DateTime
        Dim tempDate As DateTime
        If DateTime.TryParse(dateString, tempDate) Then
            Return tempDate
        Else
            Return Nothing
        End If
    End Function
    '********************************************************************************
    ' Function      : TryCastNumerico
    ' Descripción   : intenta convertir un valor pasado por parametro a integer, si no lo consigue devuelve el valor por defecto especificado
    ' Sintaxis      : TryCastNumerico(ByVal value As Object, ByVal porDefecto As Integer) As Integer
    ' Parametros    : 
    '                   - value : valor a convertir
    '                   - porDefecto : valor que se devuelve en el caso de con poder convertir value a entero
    ' Retorno       : entero obtenido a partir del valor pasado por parametro.
    '********************************************************************************
    Function TryCastNumerico(ByVal value As Object, ByVal porDefecto As Integer) As Decimal
        Dim result As Decimal = porDefecto
        Try
            If Decimal.TryParse(value.ToString, result) Then
                Return result
            Else
                Return porDefecto
            End If
        Catch ex As Exception
            Return porDefecto
        End Try
    End Function

    '********************************************************************************
    ' Function      : EsNumeroValido
    ' Descripción   : comprueba si el valor pasado por parametro es numérico
    ' Sintaxis      : EsNumeroValido(ByVal value As Object) As Boolean
    ' Parametros    : 
    '                   - value : valor a comprobar
    ' Retorno       : True --> valor numérico, False --> valor no numérico.
    '********************************************************************************
    Function EsNumeroValido(ByVal value As Object) As Boolean
        Dim result As Integer
        Try
            If Decimal.TryParse(value.ToString, result) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    '********************************************************************************
    ' Procedimiento : IsValidColumnName
    ' Descripción   : Valida si el nombre de la columna introducido es correcto
    ' Sintaxis      : IsValidColumnName(name As String) As Boolean
    ' Parametros    : 
    '                   - name : nombre de la columna a validar
    '********************************************************************************
    Public Function IsValidColumnName(name As String) As Boolean
        ' Check if the name length is between 1 and 30 characters
        If String.IsNullOrEmpty(name) OrElse name.Length > 30 Then
            Return False
        End If

        ' Check if the name starts with a letter
        If Not Char.IsLetter(name(0)) Then
            Return False
        End If

        ' Check if the name contains only valid characters
        If Not Regex.IsMatch(name, "^[A-Za-z][A-Za-z0-9_$#]*$") Then
            Return False
        End If

        ' Check if the name is not a reserved word in Oracle
        Dim reservedWords As HashSet(Of String) = GetOracleReservedWords()
        If reservedWords.Contains(name.ToUpper()) Then
            Return False
        End If

        Return True
    End Function

    '********************************************************************************
    ' Procedimiento : GetOracleReservedWords
    ' Descripción   : recupera las palabras reservadas de Oracle
    ' Sintaxis      : GetOracleReservedWords() As HashSet(Of String)
    ' Parametros    : 
    ' Retorno       : Hashset que contiene las palabras reservadas.
    '********************************************************************************
    Private Function GetOracleReservedWords() As HashSet(Of String)
        Return New HashSet(Of String) From {
            "ACCESS", "ADD", "ALL", "ALTER", "AND", "ANY", "AS", "ASC", "AUDIT",
            "BETWEEN", "BY", "CHAR", "CHECK", "CLUSTER", "COLUMN", "COMMENT",
            "COMPRESS", "CONNECT", "CREATE", "CURRENT", "DATE", "DECIMAL",
            "DEFAULT", "DELETE", "DESC", "DISTINCT", "DROP", "ELSE", "EXCLUSIVE",
            "EXISTS", "FILE", "FLOAT", "FOR", "FROM", "GRANT", "GROUP", "HAVING",
            "IDENTIFIED", "IMMEDIATE", "IN", "INCREMENT", "INDEX", "INITIAL",
            "INSERT", "INTEGER", "INTERSECT", "INTO", "IS", "LEVEL", "LIKE",
            "LOCK", "LONG", "MAXEXTENTS", "MINUS", "MLSLABEL", "MODE", "MODIFY",
            "NOAUDIT", "NOCOMPRESS", "NOT", "NOWAIT", "NULL", "NUMBER", "OF",
            "OFFLINE", "ON", "ONLINE", "OPTION", "OR", "ORDER", "PCTFREE", "PRIOR",
            "PRIVILEGES", "PUBLIC", "RAW", "RENAME", "RESOURCE", "REVOKE", "ROW",
            "ROWID", "ROWNUM", "ROWS", "SELECT", "SESSION", "SET", "SHARE",
            "SIZE", "SMALLINT", "START", "SUCCESSFUL", "SYNONYM", "SYSDATE",
            "TABLE", "THEN", "TO", "TRIGGER", "UID", "UNION", "UNIQUE", "UPDATE",
            "USER", "VALIDATE", "VALUES", "VARCHAR", "VARCHAR2", "VIEW", "WHENEVER",
            "WHERE", "WITH"
        }
    End Function

#End Region

End Module
