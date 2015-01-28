******************************************************************************
*
*   Header file for ODBC BASIC programs
*
*	Module	%M%	Version	%I% 	Date	%H%
*
*       (c) Copyright 1998 Ardent Software Inc. - All Rights Reserved
*       This is unpublished proprietary source code of Ardent Software Inc.
*       The copyright notice above does not evidence any actual or intented
*       publication of such source code.
*
*******************************************************************************
*
*       Maintenence log - insert most recent change descriptions at top
*
*       Date.... GTAR# WHO Description.........................................
*	10/27/98 23888 CSM Add SQL.LIC.DEV.SUBKEY for licensing
*       10/14/98 23801 SAP Change copyrights. 
*       06/19/97 20748 MJC BCI settings for SQLGetInfo and SQLSetConnectOption
*       11/18/96 19547 MJC BCI settings for SQLTransact 
*       11/18/96 19547 MJC BCI settings for AUTOCOMMIT
*       11/06/96 19512 ENF Add BCI settings for PARAMOPTONS
*       09/04/96 19182 MJC Add SQL.COLUMN.DISPLAY.SIZE
*       08/08/96 18994 ENF Add EMPTY.NULL, TX.PRIVATE
*       07/29/96 18758 MJC Add SQL.COLUMN.PRINT.RESULT as 1004
*       07/25/96 18854 DTM Changes for ODBC middleware project
*       07/23/96 18854 DTM Changes for ODBC middleware project
*       05/24/96 18519 HSB Define parameter types for SQLBindParameter
*       07/31/95 16901 MGM Fix num.sql.types
*       07/25/95 16901 MGM Also fix 16191
*       05/03/95 15921 ENF Add some new ColAttributes option support
*       12/01/93 12544 ENF Added SQL.DATEFORM and SQL.DATEPREC
*       10/05/93 12380 ENF Initial submission
*
*****************************************************************************

* SQL Error RETCODES and defines.

EQU SQL.ERROR                           TO               -1
EQU SQL.INVALID.HANDLE                  TO               -2
EQU SQL.NEED.DATA                       TO               99
EQU SQL.NO.DATA.FOUND                   TO              100
EQU SQL.SUCCESS                         TO                0
EQU SQL.SUCCESS.WITH.INFO               TO                1

EQU SQL.NULL.HENV                       TO               -1
EQU SQL.NULL.HDBC                       TO               -1
EQU SQL.NULL.HSTMT                      TO               -1

EQU SQL.NULL.DATA                       TO               -1

* SQLColAttributes defines

EQU SQL.COLUMN.COUNT                    TO                1
EQU SQL.COLUMN.NAME                     TO                2
EQU SQL.COLUMN.TYPE                     TO                3
EQU SQL.COLUMN.LENGTH                   TO                4
EQU SQL.COLUMN.PRECISION                TO                5
EQU SQL.COLUMN.SCALE                    TO                6
EQU SQL.COLUMN.DISPLAYSIZE              TO                7
EQU SQL.COLUMN.DISPLAY.SIZE             TO                7
EQU SQL.COLUMN.NULLABLE                 TO                8
EQU SQL.COLUMN.UNSIGNED                 TO                9
EQU SQL.COLUMN.MONEY                    TO               10
EQU SQL.COLUMN.UPDATABLE                TO               11
EQU SQL.COLUMN.AUTO.INCREMENT           TO               12
EQU SQL.COLUMN.CASE.SENSITIVE           TO               13
EQU SQL.COLUMN.SEARCHABLE               TO               14
EQU SQL.COLUMN.TYPE.NAME                TO               15
EQU SQL.COLUMN.TABLE.NAME               TO               16
EQU SQL.COLUMN.OWNER.NAME               TO               17
EQU SQL.COLUMN.QUALIFIER.NAME           TO               18
EQU SQL.COLUMN.LABEL                    TO               19
EQU SQL.COLUMN.MULTIVALUED              TO             1001
EQU SQL.COLUMN.FORMAT                   TO             1002
EQU SQL.COLUMN.CONVERSION               TO             1003
EQU SQL.COLUMN.PRINT.RESULT             TO             1004

* SQLColAttributes subdefines for SQL.COLUMN.UPDATABLE

EQU SQL.ATTR.READONLY                   TO                0
EQU SQL.ATTR.WRITE                      TO                1
EQU SQL.ATTR.READWRITE.UNKNOWN          TO                2

* SQLColAttributes subdefines for SQL.COLUMN.SEARCHABLE

EQU SQL.UNSEARCHABLE                    TO                0
EQU SQL.LIKE.ONLY                       TO                1
EQU SQL.ALL.EXCEPT.LIKE                 TO                2
EQU SQL.SEARCHABLE                      TO                3

* SQLSetConnectOption defines

EQU SQL.AUTOCOMMIT                      TO              102
EQU SQL.USE.ODBC.PRECISION              TO              999
EQU SQL.TRUNC.ROUND                     TO              998
EQU SQL.SEND.TRUNC.ROUND                TO              997
EQU SQL.OS.UID                          TO              996
EQU SQL.OS.PWD                          TO              995
EQU SQL.DATEFORM                        TO              994
EQU SQL.DATEPREC                        TO              993

EQU SQL.AUTOCOMMIT.OFF                  TO                0
EQU SQL.AUTOCOMMIT.ON                   TO                1

EQU SQL.EMPTY.NULL                      TO             1003
EQU SQL.EMPTY.NULL.ON                   TO                1
EQU SQL.EMPTY.NULL.OFF                  TO                0

EQU SQL.TX.PRIVATE                      TO             1004
EQU SQL.TX.PRIVATE.ON                   TO                1
EQU SQL.TX.PRIVATE.OFF                  TO                0

EQU SQL.UVNLS.MAP                       TO             1005
EQU SQL.UVNLS.LOCALE                    TO             1006
EQU SQL.UVNLS.LC.TIME                   TO             1007
EQU SQL.UVNLS.LC.NUMERIC                TO             1008
EQU SQL.UVNLS.LC.MONETARY               TO             1009
EQU SQL.UVNLS.LC.CTYPE                  TO             1010
EQU SQL.UVNLS.LC.COLLATE                TO             1011
EQU SQL.UVNLS.LC.ALL                    TO             1012

EQU SQL.UVNLS.SQL.NULL                  TO             1013
EQU SQL.UVNLS.TEXT.MARK                 TO             1014
EQU SQL.UVNLS.SUBVALUE.MARK             TO             1015
EQU SQL.UVNLS.VALUE.MARK                TO             1016
EQU SQL.UVNLS.FIELD.MARK                TO             1017
EQU SQL.UVNLS.ITEM.MARK                 TO             1018
EQU SQL.LIC.DEV.SUBKEY                  TO             1019


* SQLFreeStmt option defines

EQU SQL.CLOSE                           TO                1
EQU SQL.DROP                            TO                2
EQU SQL.UNBIND                          TO                3
EQU SQL.RESET.PARAMS                    TO                4

* Define all SQL data types
* and those that we support

EQU SQL.CHAR                            TO                1
EQU SQL.NUMERIC                         TO                2
EQU SQL.DECIMAL                         TO                3
EQU SQL.INTEGER                         TO                4
EQU SQL.SMALLINT                        TO                5
EQU SQL.FLOAT                           TO                6
EQU SQL.REAL                            TO                7
EQU SQL.DOUBLE                          TO                8
EQU SQL.DATE                            TO                9
EQU SQL.TIME                            TO               10
EQU SQL.TIMESTAMP                       TO               11
EQU SQL.VARCHAR                         TO               12
EQU SQL.LONGVARCHAR                     TO               -1
EQU SQL.BINARY                          TO               -2
EQU SQL.VARBINARY                       TO               -3
EQU SQL.LONGVARBINARY                   TO               -4
EQU SQL.BIGINT                          TO               -5
EQU SQL.TINYINT                         TO               -6
EQU SQL.BIT                             TO               -7
EQU NUM.SQL.TYPES                       TO               19 

* Define ODBC conception of display size 
* for the various data types

EQU SQL.CHAR.DSPSIZE                    TO                0
EQU SQL.VARCHAR.DSPSIZE                 TO                0
EQU SQL.DECIMAL.DSPSIZE                 TO                2
EQU SQL.NUMERIC.DSPSIZE                 TO                2
EQU SQL.SMALLINT.DSPSIZE                TO                6
EQU SQL.INTEGER.DSPSIZE                 TO               11
EQU SQL.REAL.DSPSIZE                    TO               13
EQU SQL.FLOAT.DSPSIZE                   TO               22
EQU SQL.DOUBLE.DSPSIZE                  TO               22
EQU SQL.DATE.DSPSIZE                    TO               10
EQU SQL.TIME.DSPSIZE                    TO                8

* Define ODBC conception of precision 
* for the various data types

EQU SQL.CHAR.PRECISION                  TO              254
EQU SQL.VARCHAR.PRECISION               TO              254
EQU SQL.DECIMAL.PRECISION               TO               15
EQU SQL.NUMERIC.PRECISION               TO               15
EQU SQL.SMALLINT.PRECISION              TO                5
EQU SQL.INTEGER.PRECISION               TO               10
EQU SQL.REAL.PRECISION                  TO                7
EQU SQL.FLOAT.PRECISION                 TO               15
EQU SQL.DOUBLE.PRECISION                TO               15
EQU SQL.DATE.PRECISION                  TO               10
EQU SQL.TIME.PRECISION                  TO                8

* Valid BASIC data types

EQU SQL.B.BASIC                         TO              100
EQU SQL.B.INTDATE                       TO              101
EQU SQL.B.NUMBER                        TO              102
EQU SQL.B.INTTIME                       TO              103
EQU SQL.B.CHAR                          TO                1
EQU SQL.B.DEFAULT                       TO               99

* Define return valued for 
* Describe and ColAttributes

EQU SQL.NO.NULLS                        TO                0
EQU SQL.NULLABLE                        TO                1
EQU SQL.NULLABLE.UNKNOWN                TO                2

* Define parameter types for SQLBindParameter (SQLSetParam)

EQU SQL.PARAM.INPUT                     TO                1
EQU SQL.PARAM.INPUT.OUTPUT              TO                2
EQU SQL.PARAM.OUTPUT                    TO                4

* DTM Added for BCI/Datastage - SQLGetInfo

EQU SQL.ACTIVE.CONNECTIONS              TO                0
EQU SQL.ACTIVE.STATEMENTS               TO                1
EQU SQL.DATA.SOURCE.NAME                TO                2
EQU SQL.DRIVER.HDBC                     TO                3
EQU SQL.DRIVER.HENV                     TO                4
EQU SQL.DRIVER.HSTMT                    TO                5
EQU SQL.DRIVER.NAME                     TO                6
EQU SQL.DRIVER.VER                      TO                7
EQU SQL.FETCH.DIRECTION                 TO                8
EQU SQL.ODBC.API.CONFORMANCE            TO                9
EQU SQL.ODBC.VER                        TO               10
EQU SQL.ROW.UPDATES                     TO               11
EQU SQL.ODBC.SAG.CLI.CONFORMANCE        TO               12
EQU SQL.SERVER.NAME                     TO               13
EQU SQL.SEARCH.PATTERN.ESCAPE           TO               14
EQU SQL.ODBC.SQL.CONFORMANCE            TO               15
EQU SQL.DATABASE.NAME                   TO               16
EQU SQL.DBMS.NAME                       TO               17
EQU SQL.DBMS.VER                        TO               18
EQU SQL.ACCESSIBLE.TABLES               TO               19
EQU SQL.ACCESSIBLE.PROCEDURES           TO               20
EQU SQL.PROCEDURES                      TO               21
EQU SQL.CONCAT.NULL.BEHAVIOR            TO               22
EQU SQL.CURSOR.COMMIT.BEHAVIOR          TO               23
EQU SQL.CURSOR.ROLLBACK.BEHAVIOR        TO               24
EQU SQL.DATA.SOURCE.READ.ONLY           TO               25
EQU SQL.DEFAULT.TXN.ISOLATION           TO               26
EQU SQL.EXPRESSIONS.IN.ORDERBY          TO               27
EQU SQL.IDENTIFIER.CASE                 TO               28
EQU SQL.IDENTIFIER.QUOTE.CHAR           TO               29
EQU SQL.MAX.COLUMN.NAME.LEN             TO               30
EQU SQL.MAX.CURSOR.NAME.LEN             TO               31
EQU SQL.MAX.OWNER.NAME.LEN              TO               32
EQU SQL.MAX.PROCEDURE.NAME.LEN          TO               33
EQU SQL.MAX.QUALIFIER.NAME.LEN          TO               34
EQU SQL.MAX.TABLE.NAME.LEN              TO               35
EQU SQL.MULT.RESULT.SETS                TO               36
EQU SQL.MULTIPLE.ACTIVE.TXN             TO               37
EQU SQL.OUTER.JOINS                     TO               38
EQU SQL.OWNER.TERM                      TO               39
EQU SQL.PROCEDURE.TERM                  TO               40
EQU SQL.QUALIFIER.NAME.SEPARATOR        TO               41
EQU SQL.QUALIFIER.TERM                  TO               42
EQU SQL.SCROLL.CONCURRENCY              TO               43
EQU SQL.SCROLL.OPTIONS                  TO               44
EQU SQL.TABLE.TERM                      TO               45
EQU SQL.TXN.CAPABLE                     TO               46
EQU SQL.USER.NAME                       TO               47
EQU SQL.CONVERT.FUNCTIONS               TO               48
EQU SQL.NUMERIC.FUNCTIONS               TO               49
EQU SQL.STRING.FUNCTIONS                TO               50
EQU SQL.SYSTEM.FUNCTIONS                TO               51
EQU SQL.TIMEDATE.FUNCTIONS              TO               52
EQU SQL.CONVERT.BIGINT                  TO               53
EQU SQL.CONVERT.BINARY                  TO               54
EQU SQL.CONVERT.BIT                     TO               55
EQU SQL.CONVERT.CHAR                    TO               56
EQU SQL.CONVERT.DATE                    TO               57
EQU SQL.CONVERT.DECIMAL                 TO               58
EQU SQL.CONVERT.DOUBLE                  TO               59
EQU SQL.CONVERT.FLOAT                   TO               60
EQU SQL.CONVERT.INTEGER                 TO               61
EQU SQL.CONVERT.LONGVARCHAR             TO               62
EQU SQL.CONVERT.NUMERIC                 TO               63
EQU SQL.CONVERT.REAL                    TO               64
EQU SQL.CONVERT.SMALLINT                TO               65
EQU SQL.CONVERT.TIME                    TO               66
EQU SQL.CONVERT.TIMESTAMP               TO               67
EQU SQL.CONVERT.TINYINT                 TO               68
EQU SQL.CONVERT.VARBINARY               TO               69
EQU SQL.CONVERT.VARCHAR                 TO               70
EQU SQL.CONVERT.LONGVARBINARY           TO               71
EQU SQL.TXN.ISOLATION.OPTION            TO               72
EQU SQL.ODBC.SQL.OPT.IEF                TO               73
EQU SQL.CORRELATION.NAME                TO               74
EQU SQL.NON.NULLABLE.COLUMNS            TO               75
EQU SQL.DRIVER.HLIB                     TO               76
EQU SQL.DRIVER.ODBC.VER                 TO               77
EQU SQL.LOCK.TYPES                      TO               78
EQU SQL.POS.OPERATIONS                  TO               79
EQU SQL.POSITIONED.STATEMENTS           TO               80
EQU SQL.GETDATA.EXTENSIONS              TO               81
EQU SQL.BOOKMARK.PERSISTENCE            TO               82
EQU SQL.STATIC.SENSITIVITY              TO               83
EQU SQL.FILE.USAGE                      TO               84
EQU SQL.NULL.COLLATION                  TO               85
EQU SQL.ALTER.TABLE                     TO               86
EQU SQL.COLUMN.ALIAS                    TO               87
EQU SQL.GROUP.BY                        TO               88
EQU SQL.KEYWORDS                        TO               89
EQU SQL.ORDER.BY.COLUMNS.IN.SELECT      TO               90
EQU SQL.OWNER.USAGE                     TO               91
EQU SQL.QUALIFIER.USAGE                 TO               92
EQU SQL.QUOTED.IDENTIFIER.CASE          TO               93
EQU SQL.SPECIAL.CHARACTERS              TO               94
EQU SQL.SUBQUERIES                      TO               95
EQU SQL.UNION                           TO               96
EQU SQL.MAX.COLUMNS.IN.GROUP.BY         TO               97
EQU SQL.MAX.COLUMNS.IN.INDEX            TO               98
EQU SQL.MAX.COLUMNS.IN.ORDER.BY         TO               99
EQU SQL.MAX.COLUMNS.IN.SELECT           TO              100
EQU SQL.MAX.COLUMNS.IN.TABLE            TO              101
EQU SQL.MAX.INDEX.SIZE                  TO              102
EQU SQL.MAX.ROW.SIZE.INCLUDES.LONG      TO              103
EQU SQL.MAX.ROW.SIZE                    TO              104
EQU SQL.MAX.STATEMENT.LEN               TO              105
EQU SQL.MAX.TABLES.IN.SELECT            TO              106
EQU SQL.MAX.USER.NAME.LEN               TO              107
EQU SQL.MAX.CHAR.LITERAL.LEN            TO              108
EQU SQL.TIMEDATE.ADD.INTERVALS          TO              109
EQU SQL.TIMEDATE.DIFF.INTERVALS         TO              110
EQU SQL.NEED.LONG.DATA.LEN              TO              111
EQU SQL.MAX.BINARY.LITERAL.LEN          TO              112
EQU SQL.LIKE.ESCAPE.CLAUSE              TO              113
EQU SQL.QUALIFIER.LOCATION              TO              114

* SQL_ALTER_TABLE bitmasks *
EQU     SQL.AT.ADD.COLUMN               TO                1
EQU     SQL.AT.DROP.COLUMN              TO                2

* SQL_BOOKMARK_PERSISTENCE bitmasks *
EQU     SQL.BP.CLOSE                    TO                1
EQU     SQL.BP.DELETE                   TO                2
EQU     SQL.BP.DROP                     TO                4
EQU     SQL.BP.TRANSACTION              TO                8
EQU     SQL.BP.UPDATE                   TO               16
EQU     SQL.BP.OTHER.HSTMT              TO               32
EQU     SQL.BP.SCROLL                   TO               64

* SQL_CONCAT_NULL_BEHAVIOR values *
EQU     SQL.CB.NULL                     TO                0
EQU     SQL.CB.NON.NULL                 TO                1

* SQL_CURSOR_COMMIT_BEHAVIOR values *
* SQL_CURSOR_ROLLBACK_BEHAVIOR values *
EQU     SQL.CB.DELETE                   TO                0
EQU     SQL.CB.CLOSE                    TO                1
EQU     SQL.CB.PRESERVE                 TO                2

* SQL_CORRELATION_NAME values *
EQU     SQL.CN.NONE                     TO                0
EQU     SQL.CN.DIFFERENT                TO                1
EQU     SQL.CN.ANY                      TO                2

* SQL_CONVERT_<.> bitmasks *
EQU     SQL.CVT.CHAR                    TO                1
EQU     SQL.CVT.NUMERIC                 TO                2
EQU     SQL.CVT.DECIMAL                 TO                4
EQU     SQL.CVT.INTEGER                 TO                8
EQU     SQL.CVT.SMALLINT                TO               16
EQU     SQL.CVT.FLOAT                   TO               32
EQU     SQL.CVT.REAL                    TO               64
EQU     SQL.CVT.DOUBLE                  TO              128
EQU     SQL.CVT.VARCHAR                 TO              256
EQU     SQL.CVT.LONGVARCHAR             TO              512
EQU     SQL.CVT.BINARY                  TO             1024
EQU     SQL.CVT.VARBINARY               TO             2048
EQU     SQL.CVT.BIT                     TO             4096
EQU     SQL.CVT.TINYINT                 TO             8192
EQU     SQL.CVT.BIGINT                  TO            16384
EQU     SQL.CVT.DATE                    TO            32768
EQU     SQL.CVT.TIME                    TO            65536
EQU     SQL.CVT.TIMESTAMP               TO           131072
EQU     SQL.CVT.LONGVARBINARY           TO           262144

* SQL_FETCH_DIRECTION bitmask *
EQU SQL.FD.FETCH.NEXT                   TO                1
EQU SQL.FD.FETCH.FIRST                  TO                2
EQU SQL.FD.FETCH.LAST                   TO                4
EQU SQL.FD.FETCH.PRIOR                  TO                8
EQU SQL.FD.FETCH.ABSOLUTE               TO               16
EQU SQL.FD.FETCH.RELATIVE               TO               32
EQU SQL.FD.FETCH.RESUME                 TO               64
EQU SQL.FD.FETCH.BOOKMARK               TO              128

* SQL_FILE_USAGE values *
EQU     SQL.FILE.NOT.SUPPORTED          TO                0
EQU     SQL.FILE.TABLE                  TO                1
EQU     SQL.FILE.QUALIFIER              TO                2

* SQL_CONVERT_FUNCTIONS bitmask *
EQU     SQL.FN.CVT.CONVERT              TO                1

* SQL_NUMERIC_FUNCTIONS bitmask *
EQU SQL.FN.NUM.ABS                      TO                1
EQU SQL.FN.NUM.ACOS                     TO                2
EQU SQL.FN.NUM.ASIN                     TO                4
EQU SQL.FN.NUM.ATAN                     TO                8
EQU SQL.FN.NUM.ATAN2                    TO               16
EQU SQL.FN.NUM.CEILING                  TO               32
EQU SQL.FN.NUM.COS                      TO               64
EQU SQL.FN.NUM.COT                      TO              128
EQU SQL.FN.NUM.EXP                      TO              256
EQU SQL.FN.NUM.FLOOR                    TO              512
EQU SQL.FN.NUM.LOG                      TO             1024
EQU SQL.FN.NUM.MOD                      TO             2048
EQU SQL.FN.NUM.SIGN                     TO             4096
EQU SQL.FN.NUM.SIN                      TO             8192
EQU SQL.FN.NUM.SQRT                     TO            16384
EQU SQL.FN.NUM.TAN                      TO            32768
EQU SQL.FN.NUM.PI                       TO            65536
EQU SQL.FN.NUM.RAND                     TO           131072
EQU SQL.FN.NUM.DEGREES                  TO           262144
EQU SQL.FN.NUM.LOG10                    TO           524288
EQU SQL.FN.NUM.POWER                    TO          1048576
EQU SQL.FN.NUM.RADIANS                  TO          2097152
EQU SQL.FN.NUM.ROUND                    TO          4194304
EQU SQL.FN.NUM.TRUNCATE                 TO          8388608

* SQL_STRING_FUNCTIONS bitmask *
EQU SQL.FN.STR.CONCAT                   TO                1
EQU SQL.FN.STR.INSERT                   TO                2
EQU SQL.FN.STR.LEFT                     TO                4
EQU SQL.FN.STR.LTRIM                    TO                8
EQU SQL.FN.STR.LENGTH                   TO               16
EQU SQL.FN.STR.LOCATE                   TO               32
EQU SQL.FN.STR.LCASE                    TO               64
EQU SQL.FN.STR.REPEAT                   TO              128
EQU SQL.FN.STR.REPLACE                  TO              256
EQU SQL.FN.STR.RIGHT                    TO              512
EQU SQL.FN.STR.RTRIM                    TO             1024
EQU SQL.FN.STR.SUBSTRING                TO             2048
EQU SQL.FN.STR.UCASE                    TO             4096
EQU SQL.FN.STR.ASCII                    TO             8192
EQU SQL.FN.STR.CHAR                     TO            16384
EQU SQL.FN.STR.DIFFERENCE               TO            32768
EQU SQL.FN.STR.LOCATE.2                 TO            65536
EQU SQL.FN.STR.SOUNDEX                  TO           131072
EQU SQL.FN.STR.SPACE                    TO           262144

* SQL_SYSTEM_FUNCTIONS bitmask *
EQU SQL.FN.SYS.USERNAME                 TO                1
EQU SQL.FN.SYS.DBNAME                   TO                2
EQU SQL.FN.SYS.IFNULL                   TO                4

* SQL_TIMEDATE bitmask *
EQU SQL.FN.TD.NOW                       TO                1
EQU SQL.FN.TD.CURDATE                   TO                2
EQU SQL.FN.TD.DAYOFMONTH                TO                4
EQU SQL.FN.TD.DAYOFWEEK                 TO                8
EQU SQL.FN.TD.DAYOFYEAR                 TO               16
EQU SQL.FN.TD.MONTH                     TO               32
EQU SQL.FN.TD.QUARTER                   TO               64
EQU SQL.FN.TD.WEEK                      TO              128
EQU SQL.FN.TD.YEAR                      TO              256
EQU SQL.FN.TD.CURTIME                   TO              512
EQU SQL.FN.TD.HOUR                      TO             1024
EQU SQL.FN.TD.MINUTE                    TO             2048
EQU SQL.FN.TD.SECOND                    TO             4096
EQU SQL.FN.TD.TIMESTAMPADD              TO             8192
EQU SQL.FN.TD.TIMESTAMPDIFF             TO            16384
EQU SQL.FN.TD.DAYNAME                   TO            32768
EQU SQL.FN.TD.MONTHNAME                 TO            65536

* SQL_TIMEDATE_ADD_INTERVALS bitmask *
* SQL_TIMEDATE_DIFF_INTERVALS bitmask *
EQU SQL.FN.TSI.FRAC.SECOND              TO                1
EQU SQL.FN.TSI.SECOND                   TO                2
EQU SQL.FN.TSI.MINUTE                   TO                4
EQU SQL.FN.TSI.HOUR                     TO                8
EQU SQL.FN.TSI.DAY                      TO               16
EQU SQL.FN.TSI.WEEK                     TO               32
EQU SQL.FN.TSI.MONTH                    TO               64
EQU SQL.FN.TSI.QUARTER                  TO              128
EQU SQL.FN.TSI.YEAR                     TO              256

* SQL_GROUP_BY values *
EQU     SQL.GB.NOT.SUPPORTED            TO                0
EQU     SQL.GB.GROUP.BY.EQUALS.SELECT   TO                1
EQU     SQL.GB.GROUP.BY.CONTAINS.SELECT TO                2
EQU     SQL.GB.NO.RELATION              TO                3

* SQL_GETDATA_EXTENSIONS values *
EQU     SQL.GD.ANY.COLUMN               TO                1
EQU     SQL.GD.ANY.ORDER                TO                2
EQU     SQL.GD.BLOCK                    TO                4
EQU     SQL.GD.BOUND                    TO                8

* SQL_IDENTIFIER_CASE values *
* SQL_QUOTED_IDENTIFIER values *
EQU     SQL.IC.UPPER                    TO                1
EQU     SQL.IC.LOWER                    TO                2
EQU     SQL.IC.SENSITIVE                TO                3
EQU     SQL.IC.MIXED                    TO                4

* SQL_LOCK_TYPES bitmask *
EQU     SQL.LCK.NO.CHANGE               TO                1
EQU     SQL.LCK.EXCLUSIVE               TO                2
EQU     SQL.LCK.UNLOCK                  TO                4

* SQL_NULL_COLLATION values *
EQU     SQL.NC.HIGH                     TO                0
EQU     SQL.NC.LOW                      TO                1
EQU     SQL.NC.START                    TO                2
EQU     SQL.NC.END                      TO                4

* SQL_NON_NULLABLE_COLUMNS values *
EQU     SQL.NNC.NULL                    TO                0
EQU     SQL.NNC.NON.NULL                TO                1

* SQL_ODBC_API_CONFORMANCE *
EQU     SQL.OAC.NONE                    TO                0
EQU     SQL.OAC.LEVEL1                  TO                1
EQU     SQL.OAC.LEVEL2                  TO                2

* SQL_ODBC_SQL_CONFORMANCE values *
EQU     SQL.OSC.MINIMUM                 TO                0
EQU     SQL.OSC.CORE                    TO                1
EQU     SQL.OSC.EXTENDED                TO                2

* SQL_ODBC_SAG_CLI_CONFORMANCE values *
EQU     SQL.OSCC.NOT.COMPLIANT          TO                0
EQU     SQL.OSCC.COMPLIANT              TO                1

* SQL_OWNER_USAGE bitmask *
EQU     SQL.OU.DML.STATEMENTS           TO                1
EQU     SQL.OU.PROCEDURE.INVOCATION     TO                2
EQU     SQL.OU.TABLE.DEFINITION         TO                4
EQU     SQL.OU.INDEX.DEFINITION         TO                8
EQU     SQL.OU.PRIVILEGE.DEFINITION     TO               16

* SQL_POS_OPERATIONS *
EQU SQL.POS.POSITION                    TO                1
EQU SQL.POS.REFRESH                     TO                2
EQU SQL.POS.UPDATE                      TO                4
EQU SQL.POS.DELETE                      TO                8
EQU SQL.POS.ADD                         TO               16

* SQL_POSITIONED_STATEMENTS bitmask *
EQU     SQL.PS.POSITIONED.DELETE        TO                1
EQU     SQL.PS.POSITIONED.UPDATE        TO                2
EQU     SQL.PS.SELECT.FOR.UPDATE        TO                4

* SQL_DEFAULT_TXN_ISOLATION bitmask *
* SQL_TXN_ISOLATION_OPTION bitmask *
EQU     SQL.TXN.READ.UNCOMMITTED        TO                1
EQU     SQL.TXN.READ.COMMITTED          TO                2
EQU     SQL.TXN.REPEATABLE.READ         TO                4
EQU     SQL.TXN.SERIALIZABLE            TO                8
EQU     SQL.TXN.VERSIONING              TO               16
EQU     SQL.TXN.CURRENT                 TO               42

* SQL_QUALIFIER_LOCATION values *
EQU     SQL.QL.START                    TO                1
EQU     SQL.QL.END                      TO                2

* SQL_QUALIFIER_USAGE bitmask *
EQU     SQL.QU.DML.STATEMENTS           TO                1
EQU     SQL.QU.PROCEDURE.INVOCATION     TO                2
EQU     SQL.QU.TABLE.DEFINITION         TO                4
EQU     SQL.QU.INDEX.DEFINITION         TO                8
EQU     SQL.QU.PRIVILEGE.DEFINITION     TO               16

* SQL_SCROLL_CONCURRENCY bitmask *
EQU     SQL.SCCO.READ.ONLY              TO                1
EQU     SQL.SCCO.LOCK                   TO                2
EQU     SQL.SCCO.OPT.ROWVER             TO                4
EQU     SQL.SCCO.OPT.VALUES             TO                8

* SQL_SCROLL_OPTIONS bitmask *
EQU     SQL.SO.FORWARD.ONLY             TO                1
EQU     SQL.SO.KEYSET.DRIVEN            TO                2
EQU     SQL.SO.DYNAMIC                  TO                4
EQU     SQL.SO.MIXED                    TO                8
EQU     SQL.SO.STATIC                   TO               16

* SQL_STATIC_SENSITIVITY bitmask *
EQU     SQL.SS.ADDITIONS                TO                1
EQU     SQL.SS.DELETIONS                TO                2
EQU     SQL.SS.UPDATES                  TO                4

* SQL_SUBQUERIES bitmask *
EQU SQL.SQ.COMPARISON                   TO                1
EQU SQL.SQ.EXISTS                       TO                2
EQU SQL.SQ.IN                           TO                4
EQU SQL.SQ.QUANTIFIED                   TO                8
EQU SQL.SQ.CORRELATED.SUBQUERIES        TO               16

* SQL_TXN_CAPABLE values *
EQU SQL.TC.NONE                         TO                0
EQU SQL.TC.DML                          TO                1
EQU SQL.TC.ALL                          TO                2
EQU SQL.TC.DDL.COMMIT                   TO                3
EQU SQL.TC.DDL.IGNORE                   TO                4

* SQL_UNION values *
EQU SQL.U.UNION                         TO                1
EQU SQL.U.UNION.ALL                     TO                2

* Additions for SQLSpecialColumns

EQU     SQL.BEST.ROWID                  TO                1
EQU     SQL.ROWVER                      TO                2
EQU     SQL.SCOPE.CURROW                TO                0
EQU     SQL.SCOPE.TRANSACTION           TO                1
EQU     SQL.SCOPE.SESSION               TO                2
EQU     SQL.PC.UNKNOWN                  TO                0
EQU     SQL.PC.PSEUDO                   TO                1
EQU     SQL.PC.NOT.PSEUDO               TO                2

* Additions for SQLStatistics
EQU     SQL.INDEX.UNIQUE                TO                0
EQU     SQL.INDEX.ALL                   TO                1
EQU     SQL.QUICK                       TO                0
EQU     SQL.ENSURE                      TO                1
EQU     SQL.TABLE.STAT                  TO                0
EQU     SQL.INDEX.CLUSTERED             TO                1
EQU     SQL.INDEX.HASHED                TO                2
EQU     SQL.INDEX.OTHER                 TO                3

* Additions for SQLParamOptions
EQU     SQL.PARAMOPTIONS.SET            TO                0
EQU     SQL.PARAMOPTIONS.READ           TO                1

* Additions for SQLTransact
EQU     SQL.COMMIT                      TO                1
EQU     SQL.ROLLBACK                    TO                2

