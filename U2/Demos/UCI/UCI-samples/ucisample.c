/******************************************************************************
*
*	ucisample.c - the uniVerse UCI example program
*
*	Module	%M%	Version	%I% 	Date	%H%
*
*
******************************************************************************/
#define		__MODULE__ "%M%"
#define		__SCCSID__ "%I%"

#ifdef	_WIN32
#include	<windows.h>
#include	<direct.h>
#include	<stdio.h>
#include	<conio.h>
#else
#include	<unistd.h>
#include	<stdio.h>
#include	<string.h>
#include	<stdlib.h>
#include	<termio.h>
#endif

#include	"UCI.h"

#ifndef	_WIN32
/* begin external function declarations */
SCHAR	*itoa();
/* end external function declarations */
#endif

/* begin static variable declarations */
static	SCHAR	szSqlStr1[] = "SELECT * FROM \"RIDES\";";
static	SCHAR	szSqlStr4[] = "SET QUOTED_IDENTIFIER ON;";
static	SCHAR	szDSN[128];
static	SCHAR	szBlank[] = "          ";
/* end static variable declarations */

/*
 * The ERRCHECK macro shows a way to simplify the checking of errors returned
 * by UCI functions and obtaining error state and message from SQLError
 * This macro cannot be used to check SQLAllocEnv
 */

#define	ERRCHECK(fname)	{ if (ret == SQL_ERROR) {\
		ret = SQLError(LPSQLHandles->henv, LPSQLHandles->hdbc, LPSQLHandles->hstmt, szSqlState, &fNativeError, szErrorMsg, sizeof(szErrorMsg)-1, &cbErrorMsg);\
		if (ret == SQL_SUCCESS || ret == SQL_SUCCESS_WITH_INFO) {\
		printf("\n Died in %s with SQLSTATE %s\n", fname, szSqlState); \
		printf("\n Native error: %d %s\n", fNativeError, szErrorMsg); }\
		exit(EXIT_FAILURE); }}

typedef struct SQLHandles {
	HENV	henv;		/* the environment handle		*/
	HDBC	hdbc;		/* a connection handle			*/
	HSTMT	hstmt;		/* a statement handle			*/
} SQLHANDLE;

/*
 * The print_carray function is provided to show how to use the C_ARRAY
 * structure returned by SQLBindMvCol; it mimics uniVerse VERTICAL listing
 */

void	print_carray( szLabel, pca )
	SCHAR	*szLabel;
	C_ARRAY *pca;
{

	UWORD	ui = pca->cDcount;
	UCI_DATUM	*udptr = pca->Data;

	printf("pCA.count = %d  ",ui);

	while (ui--)
	{
		printf("%-11s.", (udptr == pca->Data) ? szLabel : szBlank);
		if (udptr->fIndicator == SQL_NULL_DATA)
		{
			printf(" \t <null>\n");
		}
		else if (udptr->fIndicator == SQL_BAD_DATA)
		{
			printf(" <data could not be converted>\n");
		}
		else switch (pca->fCType)
		{
			case SQL_C_CHAR:
			case SQL_C_STRING:
				printf(" %s\n", udptr->uValue.string.text);
				break;
			case SQL_C_DOUBLE:
				printf(" %f\n", udptr->uValue.dbl);
				break;
			case SQL_C_FLOAT:
				printf(" %f\n", (double)udptr->uValue.flt);
				break;
			case SQL_C_TINYINT:
			case SQL_C_STINYINT:
				printf(" %d\n", (int)udptr->uValue.sbyte);
				break;
			case SQL_C_UTINYINT:
				printf(" %d\n", (int)udptr->uValue.ubyte);
				break;
			case SQL_C_SHORT:
			case SQL_C_SSHORT:
				printf(" %d\n", (int)udptr->uValue.sword);
				break;
			case SQL_C_USHORT:
				printf(" %d\n", (int)udptr->uValue.uword);
				break;
			case SQL_C_LONG:
			case SQL_C_SLONG:
				printf(" %d\n", (int)udptr->uValue.sdword);
				break;
			case SQL_C_ULONG:
				printf(" %d\n", (int)udptr->uValue.udword);
				break;
			case SQL_C_DATE:
				printf(" %02d-%02d-%04d\n",
					(int)udptr->uValue.date.day, 
					(int)udptr->uValue.date.month, 
					(int)udptr->uValue.date.year);
				break;
			case SQL_C_TIME:
				printf(" %02d:%02d:%02d\n",
					(int)udptr->uValue.time.hour, 
					(int)udptr->uValue.time.minute, 
					(int)udptr->uValue.time.second);
				break;
		}
		udptr++;
	}

	return;
}

/*
 * This routine frees a C_ARRAY structure allocated by SQLBindMvCol
 */

void	free_carray( ppca )
	C_ARRAY **ppca;
{
	C_ARRAY	*pca;
	UWORD	ui;
	UCI_DATUM	*udptr;

	if (!ppca || !(pca = *ppca)) return;

	if (pca->fCType == SQL_C_CHAR || pca->fCType == SQL_C_STRING)
	{
		ui = pca->cDcount;
		udptr = pca->Data;
		while (ui--)
		{
			if (udptr->uValue.string.text)
			{
				free(udptr->uValue.string.text);
			}
			udptr++;
		}
	}

	free(pca);
	*ppca = 0;
	return;
}

main(argc, argv)
	int	argc;
	char *argv[];
{
	RETCODE	ret;		/* the return code from UCI functions	*/
	SDWORD	i;		/* local loop counter			*/
	SDWORD	fNativeError;	/* uniVerse error code from SQLError	*/
	SWORD	cbErrorMsg;	/* length of buffer for error text	*/
	SWORD	cbDesc;		/* bytes returned by SQLColAttributes	*/
	SDWORD	fDesc;		/* numeric return from SQLColAttributes	*/
	SCHAR	szLabel[2][30];	/* buffers for column headings		*/
	SCHAR	szErrorMsg[512];/* buffer for uniVerse error message	*/
	SCHAR	szSqlState[9];	/* buffer for SQLSTATE from SQLError	*/
	SCHAR	szSchema[128];	/* path to local uniVerse acc		*/
	SCHAR	OsUid[64];	/* Server User ID */
	SCHAR	OsPwd[64];	/* Server password */
	C_ARRAY	*pCarray[2];	/* holders for data returned by SQLFetch*/
	SQLHANDLE LPSQLHandles[1];

	printf("\n");
	
/*----------------------------------------------------------------*/
/*  Connect to the server                                         */
/*----------------------------------------------------------------*/

	LPSQLHandles->henv = (HENV) SQL_NULL_HENV;
	LPSQLHandles->hdbc = (HDBC) SQL_NULL_HDBC;
	LPSQLHandles->hstmt = (HSTMT) SQL_NULL_HSTMT;

	printf("\n\nEnter the data source to use for the connection: ");
	szDSN[0] = 0;
	gets(szDSN);
	if ( szDSN[0] == 0)
	{
		printf("\nEmpty data source. Exiting\n");
		exit(EXIT_FAILURE);
	}

	sprintf(szSchema,"demo");
	sprintf(OsUid,"jyao");
	sprintf(OsPwd,"jenny.05");
	
	if (SQL_ERROR == SQLAllocEnv(&(LPSQLHandles->henv)))
	{
		printf("\nDied in SQLAllocEnv\n");
		exit(EXIT_FAILURE);
	}
	ret = SQLAllocConnect(LPSQLHandles->henv, &(LPSQLHandles->hdbc));
	ERRCHECK("SQLAllocConnect");

	ret = SQLSetConnectOption(LPSQLHandles->hdbc, (UWORD)SQL_OS_UID, 0, OsUid);
	ERRCHECK("SQLSetConnectOption");

	ret = SQLSetConnectOption(LPSQLHandles->hdbc, (UWORD)SQL_OS_PWD, 0, OsPwd);
	ERRCHECK("SQLSetConnectOption");
	
	ret = SQLConnect(LPSQLHandles->hdbc, szDSN, strlen(szDSN), szSchema, strlen(szSchema));
	ERRCHECK("SQLConnect");

	ret = SQLSetConnectOption(LPSQLHandles->hdbc, (UWORD)SQL_TXN_ISOLATION, (UDWORD) SQL_TXN_SERIALIZABLE, NULL);
	ERRCHECK("SQLSetConnectOption Isolation");
	
	ret = SQLAllocStmt(LPSQLHandles->hdbc, &(LPSQLHandles->hstmt));
	ERRCHECK("SQLAllocStmt");

/*----------------------------------------------------------------*/
/*  Get some data                                                 */
/*----------------------------------------------------------------*/
	
	SQLExecDirect (LPSQLHandles->hstmt, szSqlStr4, strlen(szSqlStr4));
	
	/* Select the whole file */
	ret = SQLExecDirect(LPSQLHandles->hstmt, szSqlStr1, strlen(szSqlStr1));
	ERRCHECK("SQLExecDirect");

	/*
	   (1) Bind all columns using SQLBindMvCol even if they are
	       single-valued because it's simpler
	   (2) Obtain the column headings for the report
	*/
	ret = SQLBindMvCol(LPSQLHandles->hstmt, 1, SQL_C_USHORT, &pCarray[0]);
	ERRCHECK("SQLBindMvCol");

	ret = SQLColAttributes(LPSQLHandles->hstmt, 1, SQL_COLUMN_LABEL, szLabel[0], 30, &cbDesc, &fDesc);
	ERRCHECK("SQLColAttributes");
	
	ret = SQLBindMvCol(LPSQLHandles->hstmt, 2, SQL_C_USHORT, &pCarray[1]);
	ERRCHECK("SQLBindMvCol");

	ret = SQLColAttributes(LPSQLHandles->hstmt, 2, SQL_COLUMN_LABEL, szLabel[1], 30, &cbDesc, &fDesc);
	ERRCHECK("SQLColAttributes");

	while (1)
	{
		ret = SQLFetch(LPSQLHandles->hstmt);
		ERRCHECK("SQLFetch");
		if (ret == SQL_NO_DATA_FOUND)
		{
			break;
		}
		else if (ret == SQL_SUCCESS || ret == SQL_SUCCESS_WITH_INFO)
		{
			printf("\n");
			for (i = 0; i < 2; i++)
			{
				print_carray( szLabel[i], pCarray[i] );
				free_carray( &pCarray[i] );
			}
		}
	}

/*----------------------------------------------------------------*/
/* Clean up section                                               */
/*----------------------------------------------------------------*/

	ret = SQLDisconnect(LPSQLHandles->hdbc);
	ERRCHECK("SQLDisconnect");

	ret = SQLFreeConnect(LPSQLHandles->hdbc);
	ERRCHECK("SQLFreeConnect");

	ret = SQLFreeEnv(LPSQLHandles->henv);
	ERRCHECK("SQLFreeEnv");

	printf("\n\t*--- End of sample program ---*\n");
	return EXIT_SUCCESS;
}

