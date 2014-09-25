******************************************************************************
*
*   Header file for XML BASIC programs
*
*	Module	%M%	Version	%I% 	Date	%H%
*
*       (c) Copyright 2002 - 2014 Rocket Software, Inc. - All Rights Reserved
*       This is unpublished proprietary source code of Ardent Software Inc.
*       The copyright notice above does not evidence any actual or intented
*       publication of such source code.
*
*******************************************************************************
*
*       Maintenence log - insert most recent change descriptions at top
*
*       Date.... GTAR# WHO Description.........................................
*
*	11/14/13 Double Xia UDT-8081: XML library update.
*	07/07/11 Double Xia UDT-4007: XDOM API enhancements.
*	11/06/03       ZJH add for U2XMAP APIs.
*
*****************************************************************************

* XML RETCODES and defines.

EQU XML.SUCCESS				TO		  0
EQU XML.ERROR				TO		 -1
EQU XML.INVALID.HANDLE			TO		 -2
EQU XML.EOF				TO		100

* Open mode for XMAPOpen() and XMLOpen()
EQU XML.READ				TO		0
EQU XML.WRITE				TO		1
EQU XML.READWRITE			TO		2
EQU XML.CREATE				TO		3

* Write mode for XMLWrite()
EQU XML.TO.FILE				TO		0
EQU XML.TO.STRING			TO		1
EQU XML.TO.DOM				TO		2

* Flag for form File or from STRING
EQU XML.FROM.FILE			TO		0
EQU XML.FROM.STRING			TO		1
EQU XML.FROM.DOM			TO		2

* Flag for form File or from STRING
EQU XMAP.FROM.FILE			TO		0
EQU XMAP.FROM.STRING			TO		1
EQU XMAP.FROM.DOM			TO		2

* Field type for XMAP RELATIONSHIP (for internal use only)
EQU XML.NORMAL.FIELD			TO		0
EQU XML.GENERATED.ID			TO		1
EQU XML.ORDER.COLUMN			TO		2
EQU XML.GEN.CANDIDATEKEY		TO		3
EQU XML.CANDIDATE.KEY			TO		4
EQU XML.FOREIGN.KEY			TO		5
EQU XML.GEN.FOREIGNKEY			TO		6

* Generated KEY type
EQU XKEY.XFIELD				TO		1
EQU XKEY.SUBR				TO		2

* Macro for XDOM operations
EQU XDOM.TRUE		     TO				1
EQU XDOM.FALSE		     TO				0

EQU XDOM.DUP		     TO				1
EQU XDOM.NODUP		     TO				0

* DOM Node type constants 
EQU XDOM.NONE		     TO				0
EQU XDOM.ELEMENT.NODE        TO				1
EQU XDOM.ATTR.NODE           TO				2
EQU XDOM.TEXT.NODE           TO				3
EQU XDOM.CDATA.NODE          TO				4
EQU XDOM.ENTITY.REF.NODE     TO				5
EQU XDOM.ENTITY.NODE         TO				6
EQU XDOM.PROC.INST.NODE      TO				7
EQU XDOM.COMMENT.NODE        TO				8
EQU XDOM.DOC.NODE            TO				9
EQU XDOM.DOC.TYPE.NODE       TO				10
EQU XDOM.DOC.FRAG.NODE       TO				11
EQU XDOM.NOTATION.NODE       TO				12
EQU XDOM.XML.DECL.NODE       TO				13

* DOM node traverse constants
EQU XDOM.NEXT.SIBLING                TO				0
EQU XDOM.PREV.SIBLING                TO				1
EQU XDOM.PARENT                      TO				2
EQU XDOM.CHILD                       TO				3
EQU XDOM.NEXT.SIBLING.WITH.SAME.NAME TO				4
EQU XDOM.PREV.SIBLING.WITH.SAME.NAME TO				5

* DOM child node index constant
EQU XDOM.FIRST.CHILD        	 	TO			0
EQU XDOM.LAST.CHILD         		TO			-1
EQU XDOM.ALL				TO			-2

EQU XDOM.SINGLE        	 	TO			0
EQU XDOM.MULTI         		TO			1
EQU XML.SINGLE        	 	TO			XDOM.SINGLE
EQU XML.MULTI         		TO			XDOM.MULTI

* XQuery item types
EQU XQ.ITEM.NODE 		TO 	1
EQU XQ.ITEM.ANY_SIMPLE_TYPE     TO 	2
EQU XQ.ITEM.ANY_URI             TO 	3
EQU XQ.ITEM.BASE_64_BINARY      TO 	4
EQU XQ.ITEM.BOOLEAN             TO 	5
EQU XQ.ITEM.DATE                TO 	6
EQU XQ.ITEM.DATE_TIME           TO 	7
EQU XQ.ITEM.DAY_TIME_DURATION   TO 	8
EQU XQ.ITEM.DECIMAL             TO 	9
EQU XQ.ITEM.DOUBLE              TO 	10
EQU XQ.ITEM.DURATION            TO 	11
EQU XQ.ITEM.FLOAT               TO 	12
EQU XQ.ITEM.G_DAY               TO 	13
EQU XQ.ITEM.G_MONTH             TO 	14
EQU XQ.ITEM.G_MONTH_DAY         TO 	15
EQU XQ.ITEM.G_YEAR              TO 	16
EQU XQ.ITEM.G_YEAR_MONTH        TO 	17
EQU XQ.ITEM.HEX_BINARY          TO 	18
EQU XQ.ITEM.NOTATION            TO 	19
EQU XQ.ITEM.QNAME               TO 	20
EQU XQ.ITEM.STRING              TO 	21
EQU XQ.ITEM.TIME                TO 	22
EQU XQ.ITEM.UNTYPED_ATOMIC      TO 	23
EQU XQ.ITEM.YEAR_MONTH_DURATION TO 	24

