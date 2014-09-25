*
*     Property of Rocket Software, Inc.
*     Copyright (C) Rocket Software, Inc.  2004-2010
*


**********************************************************************
**                                                                   *
**  Header name:  U2MQI.H                                            *
**                                                                   *
**                                                                   *
**********************************************************************



**********************************************************************
**  U2/MQI Option Codes                                               *
**********************************************************************
EQUATE U2MQI_RECEIVEMSG     TO 0 ;* Retrieve msg and msg len 
EQUATE U2MQI_LEAVEMSG       TO 1 ;* Leave msg on queue but get msg len
EQUATE U2MQI_DISCARDMSG     TO 2 ;* Retrieve msg and discard it
EQUATE U2MQI_RESIZEBUFFER   TO 3 ;* Allow U2 to handle msg buffers

**********************************************************************
**  U2/MQI Error Codes                                               *
**********************************************************************

EQUATE U2MQI_ERR_BASE            TO 100 ;* Start of the U2/MQI error codes

EQUATE U2MQI_ERR_MQUNAVAILABLE   TO 100 ;* MQ MQI libraries not available      
EQUATE U2MQI_ERR_UNKNOWN         TO 101 ;* Unknown error                       
EQUATE U2MQI_ERR_NOBINDIR        TO 102 ;* uvbin/udtbin env variable not found 
EQUATE U2MQI_ERR_FORK            TO 103 ;* Error during exec of MQI process    
EQUATE U2MQI_ERR_PIPECREATE      TO 104 ;* Error creating pipes to MQI process 
EQUATE U2MQI_ERR_PIPEWRITETOMQI  TO 105 ;* Error writing pipe to MQI process   
EQUATE U2MQI_ERR_PIPEREADFROMMQI TO 106 ;* Error reading pipe from MQI process 
EQUATE U2MQI_ERR_PIPEWRITETOU2   TO 107 ;* Error writing pipe to u2 process   
EQUATE U2MQI_ERR_PIPEREADFROMU2  TO 108 ;* Error reading pipe from u2 process 
EQUATE U2MQI_ERR_EXEC            TO 109 ;* Error during exec of MQI process    
EQUATE U2MQI_ERR_INVALIDFORMAT   TO 110 ;* Variable does not match req'd format
EQUATE U2MQI_ERR_NOT_HANDLE      TO 111 ;* Variable not of type MQShandle      
EQUATE U2MQI_ERR_NULL_HANDLE     TO 112 ;* Uninitialized handle                
EQUATE U2MQI_ERR_INVALID_HANDLE  TO 113 ;* Handle has been closed w/amTerminate
EQUATE U2MQI_ERR_UNKNOWN_HANDLE  TO 114 ;* Unexpected handle value reported    
EQUATE U2MQI_ERR_SESSION_IN_USE  TO 115 ;* An active MQI session already exists
EQUATE U2MQI_ERR_CREATE_HANDLE   TO 116 ;* Error creating U2/MQS Session Handle
EQUATE U2MQI_ERR_DL_OPEN         TO 117 ;* Error opening MQ MQI library
EQUATE U2MQI_ERR_DL_FUNC         TO 118 ;* Error calling func in MQ MQI library
EQUATE U2MQI_ERR_RCVMSGOPTS      TO 119 ;* Invalid receive-message option


***********************************************************************
**  Byte and Pointer Datatypes                                        *
***********************************************************************
                                                                        
EQUATE MQBYTE    TO CHAR(0)
EQUATE MQBYTE8   TO MQBYTE:MQBYTE:MQBYTE:MQBYTE:MQBYTE:MQBYTE:MQBYTE:MQBYTE
EQUATE MQBYTE16  TO MQBYTE8:MQBYTE8
EQUATE MQBYTE24  TO MQBYTE16:MQBYTE8
EQUATE MQBYTE32  TO MQBYTE16:MQBYTE16
EQUATE MQBYTE40  TO MQBYTE32:MQBYTE8
EQUATE MQBYTE48  TO MQBYTE24:MQBYTE24
EQUATE MQBYTE128 TO MQBYTE32:MQBYTE32:MQBYTE32:MQBYTE32

EQUATE MQPTR TO MQBYTE:MQBYTE:MQBYTE:MQBYTE



***********************************************************************
**  Values Related to MQAIR Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQAIR_STRUC_ID TO "AIR "
                                                                        
*Structure Version Number
EQUATE MQAIR_VERSION_1 TO 1
EQUATE MQAIR_CURRENT_VERSION TO 1
                                                                        
*Authentication Information Type
EQUATE MQAIT_CRL_LDAP TO 1
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQBO Structure                                  *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQBO_STRUC_ID TO "BO  "
                                                                        
*Structure Version Number
EQUATE MQBO_VERSION_1 TO 1
EQUATE MQBO_CURRENT_VERSION TO 1
                                                                        
*Begin Options
EQUATE MQBO_NONE TO 0 ;* 0x0
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQCIH Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQCIH_STRUC_ID TO "CIH "
                                                                        
*Structure Version Number
EQUATE MQCIH_VERSION_1 TO 1
EQUATE MQCIH_VERSION_2 TO 2
EQUATE MQCIH_CURRENT_VERSION TO 2
                                                                        
*Structure Length
EQUATE MQCIH_LENGTH_1 TO 164
EQUATE MQCIH_LENGTH_2 TO 180
EQUATE MQCIH_CURRENT_LENGTH TO 180
                                                                        
*Flags
EQUATE MQCIH_NONE TO 0 ;* 0x0
                                                                        
*Return Code
EQUATE MQCRC_OK TO 0
EQUATE MQCRC_CICS_EXEC_ERROR TO 1
EQUATE MQCRC_MQ_API_ERROR TO 2
EQUATE MQCRC_BRIDGE_ERROR TO 3
EQUATE MQCRC_BRIDGE_ABEND TO 4
EQUATE MQCRC_APPLICATION_ABEND TO 5
EQUATE MQCRC_SECURITY_ERROR TO 6
EQUATE MQCRC_PROGRAM_NOT_AVAILABLE TO 7
EQUATE MQCRC_BRIDGE_TIMEOUT TO 8
EQUATE MQCRC_TRANSID_NOT_AVAILABLE TO 9
                                                                        
*Unit of Work Control
EQUATE MQCUOWC_ONLY TO 273 ;* 0x111
EQUATE MQCUOWC_CONTINUE TO 65536 ;* 0x10000
EQUATE MQCUOWC_FIRST TO 17 ;* 0x11
EQUATE MQCUOWC_MIDDLE TO 16 ;* 0x10
EQUATE MQCUOWC_LAST TO 272 ;* 0x110
EQUATE MQCUOWC_COMMIT TO 256 ;* 0x100
EQUATE MQCUOWC_BACKOUT TO 4352 ;* 0x1100
                                                                        
*Get Wait Interval
EQUATE MQCGWI_DEFAULT TO -2
                                                                        
*Link Type
EQUATE MQCLT_PROGRAM TO 1
EQUATE MQCLT_TRANSACTION TO 2
                                                                        
*Output Data Length
EQUATE MQCODL_AS_INPUT TO -1
                                                                        
*ADS Descriptor
EQUATE MQCADSD_NONE TO 0 ;* 0x0
EQUATE MQCADSD_SEND TO 1 ;* 0x1
EQUATE MQCADSD_RECV TO 16 ;* 0x10
EQUATE MQCADSD_MSGFORMAT TO 256 ;* 0x100
                                                                        
*Conversational Task
EQUATE MQCCT_YES TO 1 ;* 0x1
EQUATE MQCCT_NO TO 0 ;* 0x0
                                                                        
*Task End Status
EQUATE MQCTES_NOSYNC TO 0 ;* 0x0
EQUATE MQCTES_COMMIT TO 256 ;* 0x100
EQUATE MQCTES_BACKOUT TO 4352 ;* 0x1100
EQUATE MQCTES_ENDTASK TO 65536 ;* 0x10000
                                                                        
*Facility
MQCFAC_NONE = MQBYTE8
                                                                        
*Function
EQUATE MQCFUNC_MQCONN TO "CONN"
EQUATE MQCFUNC_MQGET TO "GET "
EQUATE MQCFUNC_MQINQ TO "INQ "
EQUATE MQCFUNC_MQOPEN TO "OPEN"
EQUATE MQCFUNC_MQPUT TO "PUT "
EQUATE MQCFUNC_MQPUT1 TO "PUT1"
EQUATE MQCFUNC_NONE TO "    "
                                                                        
*Start Code
EQUATE MQCSC_START TO "S   "
EQUATE MQCSC_STARTDATA TO "SD  "
EQUATE MQCSC_TERMINPUT TO "TD  "
EQUATE MQCSC_NONE TO "    "
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQCNO Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQCNO_STRUC_ID TO "CNO "
                                                                        
*Structure Version Number
EQUATE MQCNO_VERSION_1 TO 1
EQUATE MQCNO_VERSION_2 TO 2
EQUATE MQCNO_VERSION_3 TO 3
EQUATE MQCNO_VERSION_4 TO 4
EQUATE MQCNO_CURRENT_VERSION TO 4
                                                                        
*Connect Options
EQUATE MQCNO_STANDARD_BINDING TO 0 ;* 0x0
EQUATE MQCNO_FASTPATH_BINDING TO 1 ;* 0x1
EQUATE MQCNO_HANDLE_SHARE_NONE TO 32 ;* 0x20
EQUATE MQCNO_HANDLE_SHARE_BLOCK TO 64 ;* 0x40
EQUATE MQCNO_HANDLE_SHARE_NO_BLOCK TO 128 ;* 0x80
EQUATE MQCNO_NONE TO 0 ;* 0x0
                                                                        
*Queue-Manager Connection Tag
MQCT_NONE = MQBYTE128
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQDH Structure                                  *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQDH_STRUC_ID TO "DH  "
                                                                        
*Structure Version Number
EQUATE MQDH_VERSION_1 TO 1
EQUATE MQDH_CURRENT_VERSION TO 1
                                                                        
*General Flags
EQUATE MQDHF_NEW_MSG_IDS TO 1 ;* 0x1
EQUATE MQDHF_NONE TO 0 ;* 0x0
                                                                        
*Put Message Record Flags
*See values for "Put Message Record Fields" under MQPMO
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQDLH Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQDLH_STRUC_ID TO "DLH "
                                                                        
*Structure Version Number
EQUATE MQDLH_VERSION_1 TO 1
EQUATE MQDLH_CURRENT_VERSION TO 1
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQGMO Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQGMO_STRUC_ID TO "GMO "
                                                                        
*Structure Version Number
EQUATE MQGMO_VERSION_1 TO 1
EQUATE MQGMO_VERSION_2 TO 2
EQUATE MQGMO_VERSION_3 TO 3
EQUATE MQGMO_CURRENT_VERSION TO 3
                                                                        
*Get-Message Options
EQUATE MQGMO_WAIT TO 1 ;* 0x1
EQUATE MQGMO_NO_WAIT TO 0 ;* 0x0
EQUATE MQGMO_SET_SIGNAL TO 8 ;* 0x8
EQUATE MQGMO_FAIL_IF_QUIESCING TO 8192 ;* 0x2000
EQUATE MQGMO_SYNCPOINT TO 2 ;* 0x2
EQUATE MQGMO_SYNCPOINT_IF_PERSISTENT TO 4096 ;* 0x1000
EQUATE MQGMO_NO_SYNCPOINT TO 4 ;* 0x4
EQUATE MQGMO_MARK_SKIP_BACKOUT TO 128 ;* 0x80
EQUATE MQGMO_BROWSE_FIRST TO 16 ;* 0x10
EQUATE MQGMO_BROWSE_NEXT TO 32 ;* 0x20
EQUATE MQGMO_BROWSE_MSG_UNDER_CURSOR TO 2048 ;* 0x800
EQUATE MQGMO_MSG_UNDER_CURSOR TO 256 ;* 0x100
EQUATE MQGMO_LOCK TO 512 ;* 0x200
EQUATE MQGMO_UNLOCK TO 1024 ;* 0x400
EQUATE MQGMO_ACCEPT_TRUNCATED_MSG TO 64 ;* 0x40
EQUATE MQGMO_CONVERT TO 16384 ;* 0x4000
EQUATE MQGMO_LOGICAL_ORDER TO 32768 ;* 0x8000
EQUATE MQGMO_COMPLETE_MSG TO 65536 ;* 0x10000
EQUATE MQGMO_ALL_MSGS_AVAILABLE TO 131072 ;* 0x20000
EQUATE MQGMO_ALL_SEGMENTS_AVAILABLE TO 262144 ;* 0x40000
EQUATE MQGMO_NONE TO 0 ;* 0x0
                                                                        
*Wait Interval
EQUATE MQWI_UNLIMITED TO -1
                                                                        
*Signal Values
EQUATE MQEC_MSG_ARRIVED TO 2
EQUATE MQEC_WAIT_INTERVAL_EXPIRED TO 3
EQUATE MQEC_WAIT_CANCELED TO 4
EQUATE MQEC_Q_MGR_QUIESCING TO 5
EQUATE MQEC_CONNECTION_QUIESCING TO 6
                                                                        
*Match Options
EQUATE MQMO_MATCH_MSG_ID TO 1 ;* 0x1
EQUATE MQMO_MATCH_CORREL_ID TO 2 ;* 0x2
EQUATE MQMO_MATCH_GROUP_ID TO 64 ;* 0x40
EQUATE MQMO_MATCH_MSG_SEQ_NUMBER TO 8  ;* 0x8
EQUATE MQMO_MATCH_OFFSET TO 16 ;* 0x10
EQUATE MQMO_MATCH_MSG_TOKEN TO 32 ;* 0x20
EQUATE MQMO_NONE TO 0 ;* 0x0
                                                                        
*Group Status
EQUATE MQGS_NOT_IN_GROUP TO " "
EQUATE MQGS_MSG_IN_GROUP TO "G"
EQUATE MQGS_LAST_MSG_IN_GROUP TO "L"
                                                                        
*Segment Status
EQUATE MQSS_NOT_A_SEGMENT TO " "
EQUATE MQSS_SEGMENT TO "S"
EQUATE MQSS_LAST_SEGMENT TO "L"
                                                                        
*Segmentation
EQUATE MQSEG_INHIBITED TO " "
EQUATE MQSEG_ALLOWED TO "A"
                                                                        
*Message Token
MQMTOK_NONE = MQBYTE16
                                                                        
*Returned Length
EQUATE MQRL_UNDEFINED TO -1
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQIIH Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQIIH_STRUC_ID TO "IIH "
                                                                        
*Structure Version Number
EQUATE MQIIH_VERSION_1 TO 1
EQUATE MQIIH_CURRENT_VERSION TO 1
                                                                        
*Structure Length
EQUATE MQIIH_LENGTH_1 TO 84
                                                                        
*Flags
EQUATE MQIIH_NONE TO 0 ;* 0x0
                                                                        
*Authenticator
EQUATE MQIAUT_NONE TO "        "
                                                                        
*Transaction Instance Identifier
MQITII_NONE = MQBYTE16
                                                                        
*Transaction State
EQUATE MQITS_IN_CONVERSATION TO "C"
EQUATE MQITS_NOT_IN_CONVERSATION TO " "
EQUATE MQITS_ARCHITECTED TO "A"
                                                                        
*Commit Mode
EQUATE MQICM_COMMIT_THEN_SEND TO "0"
EQUATE MQICM_SEND_THEN_COMMIT TO "1"
                                                                        
*Security Scope
EQUATE MQISS_CHECK TO "C"
EQUATE MQISS_FULL TO "F"
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQMD Structure                                  *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQMD_STRUC_ID TO "MD  "
                                                                        
*Structure Version Number
EQUATE MQMD_VERSION_1 TO 1
EQUATE MQMD_VERSION_2 TO 2
EQUATE MQMD_CURRENT_VERSION TO 2
                                                                        
*Report Options
EQUATE MQRO_EXCEPTION TO 16777216 ;* 0x1000000
EQUATE MQRO_EXCEPTION_WITH_DATA TO 50331648 ;* 0x3000000
EQUATE MQRO_EXCEPTION_WITH_FULL_DATA TO 117440512 ;* 0x7000000
EQUATE MQRO_EXPIRATION TO 2097152 ;* 0x200000
EQUATE MQRO_EXPIRATION_WITH_DATA TO 6291456 ;* 0x600000
EQUATE MQRO_EXPIRATION_WITH_FULL_DATA TO 14680064 ;* 0xE00000
EQUATE MQRO_COA TO 256 ;* 0x100
EQUATE MQRO_COA_WITH_DATA TO 768 ;* 0x300
EQUATE MQRO_COA_WITH_FULL_DATA TO 1792 ;* 0x700
EQUATE MQRO_COD TO 2048 ;* 0x800
EQUATE MQRO_COD_WITH_DATA TO 6144 ;* 0x1800
EQUATE MQRO_COD_WITH_FULL_DATA TO 14336 ;* 0x3800
EQUATE MQRO_PAN TO 1 ;* 0x1
EQUATE MQRO_NAN TO 2 ;* 0x2
EQUATE MQRO_NEW_MSG_ID TO 0 ;* 0x0
EQUATE MQRO_PASS_MSG_ID TO 128 ;* 0x80
EQUATE MQRO_COPY_MSG_ID_TO_CORREL_ID TO 0 ;* 0x0
EQUATE MQRO_PASS_CORREL_ID TO 64 ;* 0x40
EQUATE MQRO_DEAD_LETTER_Q TO 0 ;* 0x0
EQUATE MQRO_DISCARD_MSG TO 134217728 ;* 0x8000000
EQUATE MQRO_NONE TO 0 ;* 0x0
                                                                        
*Report Options Masks
EQUATE MQRO_REJECT_UNSUP_MASK TO 270270464 ;* 0x101C0000
EQUATE MQRO_ACCEPT_UNSUP_MASK TO 4024434943 ;* 0xEFE000FF
EQUATE MQRO_ACCEPT_UNSUP_IF_XMIT_MASK TO 261888 ;* 0x3FF00
                                                                        
*Message Types
EQUATE MQMT_SYSTEM_FIRST TO 1
EQUATE MQMT_REQUEST TO 1
EQUATE MQMT_REPLY TO 2
EQUATE MQMT_DATAGRAM TO 8
EQUATE MQMT_REPORT TO 4
EQUATE MQMT_MQE_FIELDS_FROM_MQE TO 112
EQUATE MQMT_MQE_FIELDS TO 113
EQUATE MQMT_SYSTEM_LAST TO 65535
EQUATE MQMT_APPL_FIRST TO 65536
EQUATE MQMT_APPL_LAST TO 999999999
                                                                        
*Expiry
EQUATE MQEI_UNLIMITED TO -1
                                                                        
*Feedback Values
EQUATE MQFB_NONE TO 0
EQUATE MQFB_SYSTEM_FIRST TO 1
EQUATE MQFB_QUIT TO 256
EQUATE MQFB_EXPIRATION TO 258
EQUATE MQFB_COA TO 259
EQUATE MQFB_COD TO 260
EQUATE MQFB_CHANNEL_COMPLETED TO 262
EQUATE MQFB_CHANNEL_FAIL_RETRY TO 263
EQUATE MQFB_CHANNEL_FAIL TO 264
EQUATE MQFB_APPL_CANNOT_BE_STARTED TO 265
EQUATE MQFB_TM_ERROR TO 266
EQUATE MQFB_APPL_TYPE_ERROR TO 267
EQUATE MQFB_STOPPED_BY_MSG_EXIT TO 268
EQUATE MQFB_XMIT_Q_MSG_ERROR TO 271
EQUATE MQFB_PAN TO 275
EQUATE MQFB_NAN TO 276
EQUATE MQFB_STOPPED_BY_CHAD_EXIT TO 277
EQUATE MQFB_STOPPED_BY_PUBSUB_EXIT TO 279
EQUATE MQFB_NOT_A_REPOSITORY_MSG TO 280
EQUATE MQFB_BIND_OPEN_CLUSRCVR_DEL TO 281
EQUATE MQFB_DATA_LENGTH_ZERO TO 291
EQUATE MQFB_DATA_LENGTH_NEGATIVE TO 292
EQUATE MQFB_DATA_LENGTH_TOO_BIG TO 293
EQUATE MQFB_BUFFER_OVERFLOW TO 294
EQUATE MQFB_LENGTH_OFF_BY_ONE TO 295
EQUATE MQFB_IIH_ERROR TO 296
EQUATE MQFB_NOT_AUTHORIZED_FOR_IMS TO 298
EQUATE MQFB_IMS_ERROR TO 300
EQUATE MQFB_IMS_FIRST TO 301
EQUATE MQFB_IMS_LAST TO 399
EQUATE MQFB_CICS_INTERNAL_ERROR TO 401
EQUATE MQFB_CICS_NOT_AUTHORIZED TO 402
EQUATE MQFB_CICS_BRIDGE_FAILURE TO 403
EQUATE MQFB_CICS_CORREL_ID_ERROR TO 404
EQUATE MQFB_CICS_CCSID_ERROR TO 405
EQUATE MQFB_CICS_ENCODING_ERROR TO 406
EQUATE MQFB_CICS_CIH_ERROR TO 407
EQUATE MQFB_CICS_UOW_ERROR TO 408
EQUATE MQFB_CICS_COMMAREA_ERROR TO 409
EQUATE MQFB_CICS_APPL_NOT_STARTED TO 410
EQUATE MQFB_CICS_APPL_ABENDED TO 411
EQUATE MQFB_CICS_DLQ_ERROR TO 412
EQUATE MQFB_CICS_UOW_BACKED_OUT TO 413
EQUATE MQFB_SYSTEM_LAST TO 65535
EQUATE MQFB_APPL_FIRST TO 65536
EQUATE MQFB_APPL_LAST TO 999999999
                                                                        
*Encoding
EQUATE MQENC_NATIVE TO 546 ;* 0x222
                                                                        
*Encoding Masks
EQUATE MQENC_INTEGER_MASK TO 15  ;* 0xF
EQUATE MQENC_DECIMAL_MASK TO 240 ;* 0xF0
EQUATE MQENC_FLOAT_MASK TO 3840 ;* 0xF00
EQUATE MQENC_RESERVED_MASK TO 4294963200 ;* 0xFFFFF000
                                                                        
*Encodings for Binary Integers
EQUATE MQENC_INTEGER_UNDEFINED TO 0 ;* 0x0
EQUATE MQENC_INTEGER_NORMAL TO 1 ;* 0x1
EQUATE MQENC_INTEGER_REVERSED TO 2 ;* 0x2
                                                                        
*Encodings for Packed-Decimal Integers
EQUATE MQENC_DECIMAL_UNDEFINED TO 0 ;* 0x0
EQUATE MQENC_DECIMAL_NORMAL TO 16 ;* 0x10
EQUATE MQENC_DECIMAL_REVERSED TO 32 ;* 0x20
                                                                        
*Encodings for Floating-Point Numbers
EQUATE MQENC_FLOAT_UNDEFINED TO 0 ;* 0x0
EQUATE MQENC_FLOAT_IEEE_NORMAL TO 256 ;* 0x100
EQUATE MQENC_FLOAT_IEEE_REVERSED TO 512 ;* 0x200
EQUATE MQENC_FLOAT_S390 TO 768 ;* 0x300
                                                                        
*Coded Character-Set Identifiers
EQUATE MQCCSI_UNDEFINED TO 0
EQUATE MQCCSI_DEFAULT TO 0
EQUATE MQCCSI_Q_MGR TO 0
EQUATE MQCCSI_INHERIT TO -2
EQUATE MQCCSI_EMBEDDED TO -1
                                                                        
*Formats
EQUATE MQFMT_NONE TO "        "
EQUATE MQFMT_ADMIN TO "MQADMIN "
EQUATE MQFMT_CHANNEL_COMPLETED TO "MQCHCOM "
EQUATE MQFMT_CICS TO "MQCICS  "
EQUATE MQFMT_COMMAND_1 TO "MQCMD1  "
EQUATE MQFMT_COMMAND_2 TO "MQCMD2  "
EQUATE MQFMT_DEAD_LETTER_HEADER TO "MQDEAD  "
EQUATE MQFMT_DIST_HEADER TO "MQHDIST "
EQUATE MQFMT_EVENT TO "MQEVENT "
EQUATE MQFMT_IMS TO "MQIMS   "
EQUATE MQFMT_IMS_VAR_STRING TO "MQIMSVS "
EQUATE MQFMT_MD_EXTENSION TO "MQHMDE  "
EQUATE MQFMT_PCF TO "MQPCF   "
EQUATE MQFMT_REF_MSG_HEADER TO "MQHREF  "
EQUATE MQFMT_RF_HEADER TO "MQHRF   "
EQUATE MQFMT_RF_HEADER_2 TO "MQHRF2  "
EQUATE MQFMT_STRING TO "MQSTR   "
EQUATE MQFMT_TRIGGER TO "MQTRIG  "
EQUATE MQFMT_WORK_INFO_HEADER TO "MQHWIH  "
EQUATE MQFMT_XMIT_Q_HEADER TO "MQXMIT  "
                                                                        
*Priority
EQUATE MQPRI_PRIORITY_AS_Q_DEF TO -1
                                                                        
*Persistence Values
EQUATE MQPER_NOT_PERSISTENT TO 0
EQUATE MQPER_PERSISTENT TO 1
EQUATE MQPER_PERSISTENCE_AS_Q_DEF TO 2
                                                                        
*Message Identifier
MQMI_NONE = MQBYTE24
                                                                        
*Correlation Identifier
MQCI_NONE        = MQBYTE24
MQCI_NEW_SESSION = MQBYTE24
MQCI_NEW_SESSION[1,1]  = CHAR(65) ;* 0x41
MQCI_NEW_SESSION[2,1]  = CHAR(77) ;* 0x4D
MQCI_NEW_SESSION[3,1]  = CHAR(81) ;* 0x51
MQCI_NEW_SESSION[4,1]  = CHAR(33) ;* 0x21
MQCI_NEW_SESSION[5,1]  = CHAR(78) ;* 0x4E
MQCI_NEW_SESSION[6,1]  = CHAR(69) ;* 0x45
MQCI_NEW_SESSION[7,1]  = CHAR(87) ;* 0x57
MQCI_NEW_SESSION[8,1]  = CHAR(95) ;* 0x5F
MQCI_NEW_SESSION[9,1]  = CHAR(83) ;* 0x53
MQCI_NEW_SESSION[10,1] = CHAR(69) ;* 0x45
MQCI_NEW_SESSION[11,1] = CHAR(83) ;* 0x53
MQCI_NEW_SESSION[12,1] = CHAR(83) ;* 0x53
MQCI_NEW_SESSION[13,1] = CHAR(73) ;* 0x49
MQCI_NEW_SESSION[14,1] = CHAR(79) ;* 0x4F
MQCI_NEW_SESSION[15,1] = CHAR(78) ;* 0x4E
MQCI_NEW_SESSION[16,1] = CHAR(95) ;* 0x5F
MQCI_NEW_SESSION[17,1] = CHAR(67) ;* 0x43
MQCI_NEW_SESSION[18,1] = CHAR(79) ;* 0x4F
MQCI_NEW_SESSION[19,1] = CHAR(82) ;* 0x52
MQCI_NEW_SESSION[20,1] = CHAR(82) ;* 0x52
MQCI_NEW_SESSION[21,1] = CHAR(69) ;* 0x45
MQCI_NEW_SESSION[22,1] = CHAR(76) ;* 0x4C
MQCI_NEW_SESSION[23,1] = CHAR(73) ;* 0x49
MQCI_NEW_SESSION[24,1] = CHAR(68) ;* 0x44
                                                                        
*Accounting Token
MQACT_NONE = MQBYTE32
                                                                        
*Accounting Token Type
EQUATE MQACTT_UNKNOWN TO 0 ;* 0x0
EQUATE MQACTT_CICS_LUOW_ID TO 1 ;* 0x1
EQUATE MQACTT_OS2_DEFAULT TO 64 ;* 0x40
EQUATE MQACTT_DOS_DEFAULT TO 80  ;* 0x50
EQUATE MQACTT_UNIX_NUMERIC_ID TO 6  ;* 0x6
EQUATE MQACTT_OS400_ACCOUNT_TOKEN TO 8  ;* 0x8
EQUATE MQACTT_WINDOWS_DEFAULT TO 9   ;* 0x9
EQUATE MQACTT_NT_SECURITY_ID TO 11  ;* 0xB
EQUATE MQACTT_USER TO 25 ;* 0x19
                                                                        
*Put Application Type
EQUATE MQAT_UNKNOWN TO -1
EQUATE MQAT_NO_CONTEXT TO 0
EQUATE MQAT_CICS TO 1
EQUATE MQAT_MVS TO 2
EQUATE MQAT_OS390 TO 2
EQUATE MQAT_ZOS TO 2
EQUATE MQAT_IMS TO 3
EQUATE MQAT_OS2 TO 4
EQUATE MQAT_DOS TO 5
EQUATE MQAT_AIX TO 6
EQUATE MQAT_UNIX TO 6
EQUATE MQAT_QMGR TO 7
EQUATE MQAT_OS400 TO 8
EQUATE MQAT_WINDOWS TO 9
EQUATE MQAT_CICS_VSE TO 10
EQUATE MQAT_WINDOWS_NT TO 11
EQUATE MQAT_VMS TO 12
EQUATE MQAT_GUARDIAN TO 13
EQUATE MQAT_NSK TO 13
EQUATE MQAT_VOS TO 14
EQUATE MQAT_IMS_BRIDGE TO 19
EQUATE MQAT_XCF TO 20
EQUATE MQAT_CICS_BRIDGE TO 21
EQUATE MQAT_NOTES_AGENT TO 22
EQUATE MQAT_USER TO 25
EQUATE MQAT_BROKER TO 26
EQUATE MQAT_JAVA TO 28
EQUATE MQAT_DQM TO 29
EQUATE MQAT_CHANNEL_INITIATOR TO 30
EQUATE MQAT_DEFAULT TO 11
EQUATE MQAT_USER_FIRST TO 65536
EQUATE MQAT_USER_LAST TO 999999999
                                                                        
*Group Identifier
MQGI_NONE = MQBYTE24
                                                                        
*Message Flags
EQUATE MQMF_SEGMENTATION_INHIBITED TO 0 ;* 0x0
EQUATE MQMF_SEGMENTATION_ALLOWED TO 1 ;* 0x1
EQUATE MQMF_MSG_IN_GROUP TO 8  ;* 0x8
EQUATE MQMF_LAST_MSG_IN_GROUP TO 16 ;* 0x10
EQUATE MQMF_SEGMENT TO 2 ;* 0x2
EQUATE MQMF_LAST_SEGMENT TO 64 ;* 0x40
EQUATE MQMF_NONE TO 0 ;* 0x0
                                                                        
*Message Flags Masks
EQUATE MQMF_REJECT_UNSUP_MASK TO 4095  ;* 0xFFF
EQUATE MQMF_ACCEPT_UNSUP_MASK TO 4293918720 ;* 0xFFF00000
EQUATE MQMF_ACCEPT_UNSUP_IF_XMIT_MASK TO 1044480 ;* 0xFF000
                                                                        
*Original Length
EQUATE MQOL_UNDEFINED TO -1
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQMDE Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQMDE_STRUC_ID TO "MDE "
                                                                        
*Structure Version Number
EQUATE MQMDE_VERSION_2 TO 2
EQUATE MQMDE_CURRENT_VERSION TO 2
                                                                        
*Structure Length
EQUATE MQMDE_LENGTH_2 TO 72
                                                                        
*General Flags
EQUATE MQMDEF_NONE TO 0 ;* 0x0
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQOD Structure                                  *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQOD_STRUC_ID TO "OD  "
                                                                        
*Structure Version Number
EQUATE MQOD_VERSION_1 TO 1
EQUATE MQOD_VERSION_2 TO 2
EQUATE MQOD_VERSION_3 TO 3
EQUATE MQOD_CURRENT_VERSION TO 3
                                                                        
*Structure Length
EQUATE MQOD_CURRENT_LENGTH TO 336
                                                                        
*Object Types
EQUATE MQOT_Q TO 1
EQUATE MQOT_NAMELIST TO 2
EQUATE MQOT_PROCESS TO 3
EQUATE MQOT_STORAGE_CLASS TO 4
EQUATE MQOT_Q_MGR TO 5
EQUATE MQOT_CHANNEL TO 6
EQUATE MQOT_AUTH_INFO TO 7
EQUATE MQOT_CF_STRUC TO 10
EQUATE MQOT_RESERVED_1 TO 999
                                                                        
*Extended Object Types
EQUATE MQOT_ALL TO 1001
EQUATE MQOT_ALIAS_Q TO 1002
EQUATE MQOT_MODEL_Q TO 1003
EQUATE MQOT_LOCAL_Q TO 1004
EQUATE MQOT_REMOTE_Q TO 1005
EQUATE MQOT_SENDER_CHANNEL TO 1007
EQUATE MQOT_SERVER_CHANNEL TO 1008
EQUATE MQOT_REQUESTER_CHANNEL TO 1009
EQUATE MQOT_RECEIVER_CHANNEL TO 1010
EQUATE MQOT_CURRENT_CHANNEL TO 1011
EQUATE MQOT_SAVED_CHANNEL TO 1012
EQUATE MQOT_SVRCONN_CHANNEL TO 1013
EQUATE MQOT_CLNTCONN_CHANNEL TO 1014
                                                                        
*Security Identifier
MQSID_NONE = MQBYTE40
                                                                        
*Security Identifier Type
*(call the MQ_SETDEFAULTS subroutine to initialize the following)
EQUATE MQSIDT_NONE TO 0 ;* 0x0
EQUATE MQSIDT_NT_SECURITY_ID TO 1 ;* 0x1
EQUATE MQSIDT_WAS_SECURITY_ID TO 2 ;* 0x2
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQPMO Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQPMO_STRUC_ID TO "PMO "
                                                                        
*Structure Version Number
EQUATE MQPMO_VERSION_1 TO 1
EQUATE MQPMO_VERSION_2 TO 2
EQUATE MQPMO_CURRENT_VERSION TO 2
                                                                        
*Structure Length
EQUATE MQPMO_CURRENT_LENGTH TO 152
                                                                        
*Put-Message Options
EQUATE MQPMO_SYNCPOINT TO 2 ;* 0x2
EQUATE MQPMO_NO_SYNCPOINT TO 4 ;* 0x4
EQUATE MQPMO_NEW_MSG_ID TO 64 ;* 0x40
EQUATE MQPMO_NEW_CORREL_ID TO 128 ;* 0x80
EQUATE MQPMO_LOGICAL_ORDER TO 32768 ;* 0x8000
EQUATE MQPMO_NO_CONTEXT TO 16384 ;* 0x4000
EQUATE MQPMO_DEFAULT_CONTEXT TO 32 ;* 0x20
EQUATE MQPMO_PASS_IDENTITY_CONTEXT TO 256 ;* 0x100
EQUATE MQPMO_PASS_ALL_CONTEXT TO 512 ;* 0x200
EQUATE MQPMO_SET_IDENTITY_CONTEXT TO 1024 ;* 0x400
EQUATE MQPMO_SET_ALL_CONTEXT TO 2048 ;* 0x800
EQUATE MQPMO_ALTERNATE_USER_AUTHORITY TO 4096 ;* 0x1000
EQUATE MQPMO_FAIL_IF_QUIESCING TO 8192 ;* 0x2000
EQUATE MQPMO_NONE TO 0 ;* 0x0
                                                                        
*Put Message Record Fields
EQUATE MQPMRF_MSG_ID TO 1 ;* 0x1
EQUATE MQPMRF_CORREL_ID TO 2 ;* 0x2
EQUATE MQPMRF_GROUP_ID TO 64 ;* 0x40
EQUATE MQPMRF_FEEDBACK TO 8  ;* 0x8
EQUATE MQPMRF_ACCOUNTING_TOKEN TO 16 ;* 0x10
EQUATE MQPMRF_NONE TO 0 ;* 0x0
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQRFH Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQRFH_STRUC_ID TO "RFH "
                                                                        
*Structure Version Number
EQUATE MQRFH_VERSION_1 TO 1
EQUATE MQRFH_VERSION_2 TO 2
                                                                        
*Structure Length
EQUATE MQRFH_STRUC_LENGTH_FIXED TO 32
EQUATE MQRFH_STRUC_LENGTH_FIXED_2 TO 36
                                                                        
*Flags
EQUATE MQRFH_NONE TO 0 ;* 0x0
                                                                        
*Names for Name/Value String
EQUATE MQNVS_APPL_TYPE TO "OPT_APP_GRP "
EQUATE MQNVS_MSG_TYPE TO "OPT_MSG_TYPE "
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQRMH Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQRMH_STRUC_ID TO "RMH "
                                                                        
*Structure Version Number
EQUATE MQRMH_VERSION_1 TO 1
EQUATE MQRMH_CURRENT_VERSION TO 1
                                                                        
*Flags
EQUATE MQRMHF_LAST TO 1 ;* 0x1
EQUATE MQRMHF_NOT_LAST TO 0 ;* 0x0
                                                                        
*Object Instance Identifier
MQOII_NONE = MQBYTE24
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQSCO Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQSCO_STRUC_ID TO "SCO "
                                                                        
*Structure Version Number
EQUATE MQSCO_VERSION_1 TO 1
EQUATE MQSCO_CURRENT_VERSION TO 1
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQTM Structure                                  *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQTM_STRUC_ID TO "TM  "
                                                                        
*Structure Version Number
EQUATE MQTM_VERSION_1 TO 1
EQUATE MQTM_CURRENT_VERSION TO 1
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQTMC2 Structure                                *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQTMC_STRUC_ID TO "TMC "
                                                                        
*Structure Version Number
EQUATE MQTMC_VERSION_1 TO "   1"
EQUATE MQTMC_VERSION_2 TO "   2"
EQUATE MQTMC_CURRENT_VERSION TO "   2"
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQWIH Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQWIH_STRUC_ID TO "WIH "
                                                                        
*Structure Version Number
EQUATE MQWIH_VERSION_1 TO 1
EQUATE MQWIH_CURRENT_VERSION TO 1
                                                                        
*Structure Length
EQUATE MQWIH_LENGTH_1 TO 120
EQUATE MQWIH_CURRENT_LENGTH TO 120
                                                                        
*Flags
EQUATE MQWIH_NONE TO 0 ;* 0x0
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQXQH Structure                                 *
***********************************************************************
                                                                        
*Structure Identifier
EQUATE MQXQH_STRUC_ID TO "XQH "
                                                                        
*Structure Version Number
EQUATE MQXQH_VERSION_1 TO 1
EQUATE MQXQH_CURRENT_VERSION TO 1
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQCLOSE Function                                *
***********************************************************************
                                                                        
*Object Handle
EQUATE MQHO_UNUSABLE_HOBJ TO -1
EQUATE MQHO_NONE TO 0
                                                                        
*Close Options
EQUATE MQCO_NONE TO 0 ;* 0x0
EQUATE MQCO_DELETE TO 1 ;* 0x1
EQUATE MQCO_DELETE_PURGE TO 2 ;* 0x2
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQINQ Function                                  *
***********************************************************************
                                                                        
*Character-Attribute Selectors
EQUATE MQCA_ALTERATION_DATE TO 2027
EQUATE MQCA_ALTERATION_TIME TO 2028
EQUATE MQCA_APPL_ID TO 2001
EQUATE MQCA_AUTH_INFO_CONN_NAME TO 2053
EQUATE MQCA_AUTH_INFO_DESC TO 2046
EQUATE MQCA_AUTH_INFO_NAME TO 2045
EQUATE MQCA_BACKOUT_REQ_Q_NAME TO 2019
EQUATE MQCA_BASE_Q_NAME TO 2002
EQUATE MQCA_CF_STRUC_DESC TO 2052
EQUATE MQCA_CF_STRUC_NAME TO 2039
EQUATE MQCA_CHANNEL_AUTO_DEF_EXIT TO 2026
EQUATE MQCA_CLUSTER_DATE TO 2037
EQUATE MQCA_CLUSTER_NAME TO 2029
EQUATE MQCA_CLUSTER_NAMELIST TO 2030
EQUATE MQCA_CLUSTER_Q_MGR_NAME TO 2031
EQUATE MQCA_CLUSTER_TIME TO 2038
EQUATE MQCA_CLUSTER_WORKLOAD_DATA TO 2034
EQUATE MQCA_CLUSTER_WORKLOAD_EXIT TO 2033
EQUATE MQCA_COMMAND_INPUT_Q_NAME TO 2003
EQUATE MQCA_CREATION_DATE TO 2004
EQUATE MQCA_CREATION_TIME TO 2005
EQUATE MQCA_DEAD_LETTER_Q_NAME TO 2006
EQUATE MQCA_DEF_XMIT_Q_NAME TO 2025
EQUATE MQCA_ENV_DATA TO 2007
EQUATE MQCA_FIRST TO 2001
EQUATE MQCA_IGQ_USER_ID TO 2041
EQUATE MQCA_INITIATION_Q_NAME TO 2008
EQUATE MQCA_LAST TO 4000
EQUATE MQCA_LAST_USED TO 2053
EQUATE MQCA_LDAP_PASSWORD TO 2048
EQUATE MQCA_LDAP_USER_NAME TO 2047
EQUATE MQCA_NAMELIST_DESC TO 2009
EQUATE MQCA_NAMELIST_NAME TO 2010
EQUATE MQCA_NAMES TO 2020
EQUATE MQCA_PROCESS_DESC TO 2011
EQUATE MQCA_PROCESS_NAME TO 2012
EQUATE MQCA_Q_DESC TO 2013
EQUATE MQCA_Q_MGR_DESC TO 2014
EQUATE MQCA_Q_MGR_IDENTIFIER TO 2032
EQUATE MQCA_Q_MGR_NAME TO 2015
EQUATE MQCA_Q_NAME TO 2016
EQUATE MQCA_QSG_NAME TO 2040
EQUATE MQCA_REMOTE_Q_MGR_NAME TO 2017
EQUATE MQCA_REMOTE_Q_NAME TO 2018
EQUATE MQCA_REPOSITORY_NAME TO 2035
EQUATE MQCA_REPOSITORY_NAMELIST TO 2036
EQUATE MQCA_SSL_CRL_NAMELIST TO 2050
EQUATE MQCA_SSL_CRYPTO_HARDWARE TO 2051
EQUATE MQCA_SSL_KEY_REPOSITORY TO 2049
EQUATE MQCA_STORAGE_CLASS TO 2022
EQUATE MQCA_STORAGE_CLASS_DESC TO 2042
EQUATE MQCA_TRIGGER_DATA TO 2023
EQUATE MQCA_USER_DATA TO 2021
EQUATE MQCA_USER_LIST TO 4000
EQUATE MQCA_XCF_GROUP_NAME TO 2043
EQUATE MQCA_XCF_MEMBER_NAME TO 2044
EQUATE MQCA_XMIT_Q_NAME TO 2024
                                                                        
*Integer-Attribute Selectors
EQUATE MQIA_APPL_TYPE TO 1
EQUATE MQIA_ARCHIVE TO 60
EQUATE MQIA_AUTH_INFO_TYPE TO 66
EQUATE MQIA_AUTHORITY_EVENT TO 47
EQUATE MQIA_BACKOUT_THRESHOLD TO 22
EQUATE MQIA_CF_LEVEL TO 70
EQUATE MQIA_CF_RECOVER TO 71
EQUATE MQIA_CHANNEL_AUTO_DEF TO 55
EQUATE MQIA_CHANNEL_AUTO_DEF_EVENT TO 56
EQUATE MQIA_CLUSTER_Q_TYPE TO 59
EQUATE MQIA_CLUSTER_WORKLOAD_LENGTH TO 58
EQUATE MQIA_CODED_CHAR_SET_ID TO 2
EQUATE MQIA_COMMAND_LEVEL TO 31
EQUATE MQIA_CONFIGURATION_EVENT TO 51
EQUATE MQIA_CURRENT_Q_DEPTH TO 3
EQUATE MQIA_DEF_BIND TO 61
EQUATE MQIA_DEF_INPUT_OPEN_OPTION TO 4
EQUATE MQIA_DEF_PERSISTENCE TO 5
EQUATE MQIA_DEF_PRIORITY TO 6
EQUATE MQIA_DEFINITION_TYPE TO 7
EQUATE MQIA_DIST_LISTS TO 34
EQUATE MQIA_EXPIRY_INTERVAL TO 39
EQUATE MQIA_FIRST TO 1
EQUATE MQIA_HARDEN_GET_BACKOUT TO 8
EQUATE MQIA_HIGH_Q_DEPTH TO 36
EQUATE MQIA_IGQ_PUT_AUTHORITY TO 65
EQUATE MQIA_INDEX_TYPE TO 57
EQUATE MQIA_INHIBIT_EVENT TO 48
EQUATE MQIA_INHIBIT_GET TO 9
EQUATE MQIA_INHIBIT_PUT TO 10
EQUATE MQIA_INTRA_GROUP_QUEUING TO 64
EQUATE MQIA_LAST TO 2000
EQUATE MQIA_LAST_USED TO 72
EQUATE MQIA_LOCAL_EVENT TO 49
EQUATE MQIA_MAX_HANDLES TO 11
EQUATE MQIA_MAX_MSG_LENGTH TO 13
EQUATE MQIA_MAX_PRIORITY TO 14
EQUATE MQIA_MAX_Q_DEPTH TO 15
EQUATE MQIA_MAX_UNCOMMITTED_MSGS TO 33
EQUATE MQIA_MSG_DELIVERY_SEQUENCE TO 16
EQUATE MQIA_MSG_DEQ_COUNT TO 38
EQUATE MQIA_MSG_ENQ_COUNT TO 37
EQUATE MQIA_NAME_COUNT TO 19
EQUATE MQIA_NAMELIST_TYPE TO 72
EQUATE MQIA_OPEN_INPUT_COUNT TO 17
EQUATE MQIA_OPEN_OUTPUT_COUNT TO 18
EQUATE MQIA_PAGESET_ID TO 62
EQUATE MQIA_PERFORMANCE_EVENT TO 53
EQUATE MQIA_PLATFORM TO 32
EQUATE MQIA_Q_DEPTH_HIGH_EVENT TO 43
EQUATE MQIA_Q_DEPTH_HIGH_LIMIT TO 40
EQUATE MQIA_Q_DEPTH_LOW_EVENT TO 44
EQUATE MQIA_Q_DEPTH_LOW_LIMIT TO 41
EQUATE MQIA_Q_DEPTH_MAX_EVENT TO 42
EQUATE MQIA_Q_SERVICE_INTERVAL TO 54
EQUATE MQIA_Q_SERVICE_INTERVAL_EVENT TO 46
EQUATE MQIA_Q_TYPE TO 20
EQUATE MQIA_QSG_DISP TO 63
EQUATE MQIA_REMOTE_EVENT TO 50
EQUATE MQIA_RETENTION_INTERVAL TO 21
EQUATE MQIA_SCOPE TO 45
EQUATE MQIA_SHAREABILITY TO 23
EQUATE MQIA_SSL_TASKS TO 69
EQUATE MQIA_START_STOP_EVENT TO 52
EQUATE MQIA_SYNCPOINT TO 30
EQUATE MQIA_TIME_SINCE_RESET TO 35
EQUATE MQIA_TRIGGER_CONTROL TO 24
EQUATE MQIA_TRIGGER_DEPTH TO 29
EQUATE MQIA_TRIGGER_INTERVAL TO 25
EQUATE MQIA_TRIGGER_MSG_PRIORITY TO 26
EQUATE MQIA_TRIGGER_TYPE TO 28
EQUATE MQIA_USAGE TO 12
EQUATE MQIA_USER_LIST TO 2000
                                                                        
*Integer Attribute Value Denoting "Not Applicable"
EQUATE MQIAV_NOT_APPLICABLE TO -1
EQUATE MQIAV_UNDEFINED TO -2
                                                                        
                                                                        
***********************************************************************
**  Values Related to MQOPEN Function                                 *
***********************************************************************
                                                                        
*Open Options
EQUATE MQOO_INPUT_AS_Q_DEF TO 1 ;* 0x1
EQUATE MQOO_INPUT_SHARED TO 2 ;* 0x2
EQUATE MQOO_INPUT_EXCLUSIVE TO 4 ;* 0x4
EQUATE MQOO_BROWSE TO 8  ;* 0x8
EQUATE MQOO_OUTPUT TO 16 ;* 0x10
EQUATE MQOO_INQUIRE TO 32 ;* 0x20
EQUATE MQOO_SET TO 64 ;* 0x40
EQUATE MQOO_BIND_ON_OPEN TO 16384 ;* 0x4000
EQUATE MQOO_BIND_NOT_FIXED TO 32768 ;* 0x8000
EQUATE MQOO_BIND_AS_Q_DEF TO 0 ;* 0x0
EQUATE MQOO_SAVE_ALL_CONTEXT TO 128 ;* 0x80
EQUATE MQOO_PASS_IDENTITY_CONTEXT TO 256 ;* 0x100
EQUATE MQOO_PASS_ALL_CONTEXT TO 512 ;* 0x200
EQUATE MQOO_SET_IDENTITY_CONTEXT TO 1024 ;* 0x400
EQUATE MQOO_SET_ALL_CONTEXT TO 2048 ;* 0x800
EQUATE MQOO_ALTERNATE_USER_AUTHORITY TO 4096 ;* 0x1000
EQUATE MQOO_FAIL_IF_QUIESCING TO 8192 ;* 0x2000
                                                                        
                                                                        
***********************************************************************
**  Values Related to All Functions                                   *
***********************************************************************
                                                                        
*Connection Handle
EQUATE MQHC_DEF_HCONN TO 0
EQUATE MQHC_UNUSABLE_HCONN TO -1
                                                                        
*String Lengths
EQUATE MQ_ABEND_CODE_LENGTH TO 4
EQUATE MQ_ACCOUNTING_TOKEN_LENGTH TO 32
EQUATE MQ_APPL_IDENTITY_DATA_LENGTH TO 32
EQUATE MQ_APPL_NAME_LENGTH TO 28
EQUATE MQ_APPL_ORIGIN_DATA_LENGTH TO 4
EQUATE MQ_APPL_TAG_LENGTH TO 28
EQUATE MQ_ATTENTION_ID_LENGTH TO 4
EQUATE MQ_AUTH_INFO_CONN_NAME_LENGTH TO 264
EQUATE MQ_AUTH_INFO_DESC_LENGTH TO 64
EQUATE MQ_AUTH_INFO_NAME_LENGTH TO 48
EQUATE MQ_AUTHENTICATOR_LENGTH TO 8
EQUATE MQ_BRIDGE_NAME_LENGTH TO 24
EQUATE MQ_CANCEL_CODE_LENGTH TO 4
EQUATE MQ_CF_STRUC_DESC_LENGTH TO 64
EQUATE MQ_CF_STRUC_NAME_LENGTH TO 12
EQUATE MQ_CHANNEL_DATE_LENGTH TO 12
EQUATE MQ_CHANNEL_DESC_LENGTH TO 64
EQUATE MQ_CHANNEL_NAME_LENGTH TO 20
EQUATE MQ_CHANNEL_TIME_LENGTH TO 8
EQUATE MQ_CLUSTER_NAME_LENGTH TO 48
EQUATE MQ_CONN_NAME_LENGTH TO 264
EQUATE MQ_CONN_TAG_LENGTH TO 128
EQUATE MQ_CORREL_ID_LENGTH TO 24
EQUATE MQ_CREATION_DATE_LENGTH TO 12
EQUATE MQ_CREATION_TIME_LENGTH TO 8
EQUATE MQ_DATE_LENGTH TO 12
EQUATE MQ_DISTINGUISHED_NAME_LENGTH TO 1024
EQUATE MQ_EXIT_DATA_LENGTH TO 32
EQUATE MQ_EXIT_INFO_NAME_LENGTH TO 48
EQUATE MQ_EXIT_NAME_LENGTH TO 128
EQUATE MQ_EXIT_PD_AREA_LENGTH TO 48
EQUATE MQ_EXIT_USER_AREA_LENGTH TO 16
EQUATE MQ_FACILITY_LENGTH TO 8
EQUATE MQ_FACILITY_LIKE_LENGTH TO 4
EQUATE MQ_FORMAT_LENGTH TO 8
EQUATE MQ_FUNCTION_LENGTH TO 4
EQUATE MQ_GROUP_ID_LENGTH TO 24
EQUATE MQ_LDAP_PASSWORD_LENGTH TO 32
EQUATE MQ_LOCAL_ADDRESS_LENGTH TO 48
EQUATE MQ_LTERM_OVERRIDE_LENGTH TO 8
EQUATE MQ_LUWID_LENGTH TO 16
EQUATE MQ_MAX_EXIT_NAME_LENGTH TO 128
EQUATE MQ_MAX_MCA_USER_ID_LENGTH TO 64
EQUATE MQ_MAX_USER_ID_LENGTH TO 64
EQUATE MQ_MCA_JOB_NAME_LENGTH TO 28
EQUATE MQ_MCA_NAME_LENGTH TO 20
EQUATE MQ_MCA_USER_ID_LENGTH TO 64
EQUATE MQ_MFS_MAP_NAME_LENGTH TO 8
EQUATE MQ_MODE_NAME_LENGTH TO 8
EQUATE MQ_MSG_HEADER_LENGTH TO 4000
EQUATE MQ_MSG_ID_LENGTH TO 24
EQUATE MQ_MSG_TOKEN_LENGTH TO 16
EQUATE MQ_NAMELIST_DESC_LENGTH TO 64
EQUATE MQ_NAMELIST_NAME_LENGTH TO 48
EQUATE MQ_OBJECT_INSTANCE_ID_LENGTH TO 24
EQUATE MQ_OBJECT_NAME_LENGTH TO 48
EQUATE MQ_PASSWORD_LENGTH TO 12
EQUATE MQ_PROCESS_APPL_ID_LENGTH TO 256
EQUATE MQ_PROCESS_DESC_LENGTH TO 64
EQUATE MQ_PROCESS_ENV_DATA_LENGTH TO 128
EQUATE MQ_PROCESS_NAME_LENGTH TO 48
EQUATE MQ_PROCESS_USER_DATA_LENGTH TO 128
EQUATE MQ_PUT_APPL_NAME_LENGTH TO 28
EQUATE MQ_PUT_DATE_LENGTH TO 8
EQUATE MQ_PUT_TIME_LENGTH TO 8
EQUATE MQ_Q_DESC_LENGTH TO 64
EQUATE MQ_Q_MGR_DESC_LENGTH TO 64
EQUATE MQ_Q_MGR_IDENTIFIER_LENGTH TO 48
EQUATE MQ_Q_MGR_NAME_LENGTH TO 48
EQUATE MQ_Q_NAME_LENGTH TO 48
EQUATE MQ_QSG_NAME_LENGTH TO 4
EQUATE MQ_REMOTE_SYS_ID_LENGTH TO 4
EQUATE MQ_SECURITY_ID_LENGTH TO 40
EQUATE MQ_SERVICE_NAME_LENGTH TO 32
EQUATE MQ_SERVICE_STEP_LENGTH TO 8
EQUATE MQ_SHORT_CONN_NAME_LENGTH TO 20
EQUATE MQ_SSL_CIPHER_SPEC_LENGTH TO 32
EQUATE MQ_SSL_CRYPTO_HARDWARE_LENGTH TO 256
EQUATE MQ_SSL_HANDSHAKE_STAGE_LENGTH TO 32
EQUATE MQ_SSL_KEY_REPOSITORY_LENGTH TO 256
EQUATE MQ_SSL_PEER_NAME_LENGTH TO 1024
EQUATE MQ_SSL_SHORT_PEER_NAME_LENGTH TO 256
EQUATE MQ_START_CODE_LENGTH TO 4
EQUATE MQ_STORAGE_CLASS_DESC_LENGTH TO 64
EQUATE MQ_STORAGE_CLASS_LENGTH TO 8
EQUATE MQ_SUB_IDENTITY_LENGTH TO 128
EQUATE MQ_TIME_LENGTH TO 8
EQUATE MQ_TOTAL_EXIT_DATA_LENGTH TO 999
EQUATE MQ_TOTAL_EXIT_NAME_LENGTH TO 999
EQUATE MQ_TP_NAME_LENGTH TO 64
EQUATE MQ_TRAN_INSTANCE_ID_LENGTH TO 16
EQUATE MQ_TRANSACTION_ID_LENGTH TO 4
EQUATE MQ_TRIGGER_DATA_LENGTH TO 64
EQUATE MQ_USER_ID_LENGTH TO 12
EQUATE MQ_XCF_GROUP_NAME_LENGTH TO 8
EQUATE MQ_XCF_MEMBER_NAME_LENGTH TO 16
                                                                        
*Completion Codes
EQUATE MQCC_OK TO 0
EQUATE MQCC_WARNING TO 1
EQUATE MQCC_FAILED TO 2
EQUATE MQCC_UNKNOWN TO -1
                                                                        
*Reason Codes
EQUATE MQRC_NONE TO 0
EQUATE MQRC_APPL_FIRST TO 900
EQUATE MQRC_APPL_LAST TO 999
EQUATE MQRC_ALIAS_BASE_Q_TYPE_ERROR TO 2001
EQUATE MQRC_ALREADY_CONNECTED TO 2002
EQUATE MQRC_BACKED_OUT TO 2003
EQUATE MQRC_BUFFER_ERROR TO 2004
EQUATE MQRC_BUFFER_LENGTH_ERROR TO 2005
EQUATE MQRC_CHAR_ATTR_LENGTH_ERROR TO 2006
EQUATE MQRC_CHAR_ATTRS_ERROR TO 2007
EQUATE MQRC_CHAR_ATTRS_TOO_SHORT TO 2008
EQUATE MQRC_CONNECTION_BROKEN TO 2009
EQUATE MQRC_DATA_LENGTH_ERROR TO 2010
EQUATE MQRC_DYNAMIC_Q_NAME_ERROR TO 2011
EQUATE MQRC_ENVIRONMENT_ERROR TO 2012
EQUATE MQRC_EXPIRY_ERROR TO 2013
EQUATE MQRC_FEEDBACK_ERROR TO 2014
EQUATE MQRC_GET_INHIBITED TO 2016
EQUATE MQRC_HANDLE_NOT_AVAILABLE TO 2017
EQUATE MQRC_HCONN_ERROR TO 2018
EQUATE MQRC_HOBJ_ERROR TO 2019
EQUATE MQRC_INHIBIT_VALUE_ERROR TO 2020
EQUATE MQRC_INT_ATTR_COUNT_ERROR TO 2021
EQUATE MQRC_INT_ATTR_COUNT_TOO_SMALL TO 2022
EQUATE MQRC_INT_ATTRS_ARRAY_ERROR TO 2023
EQUATE MQRC_SYNCPOINT_LIMIT_REACHED TO 2024
EQUATE MQRC_MAX_CONNS_LIMIT_REACHED TO 2025
EQUATE MQRC_MD_ERROR TO 2026
EQUATE MQRC_MISSING_REPLY_TO_Q TO 2027
EQUATE MQRC_MSG_TYPE_ERROR TO 2029
EQUATE MQRC_MSG_TOO_BIG_FOR_Q TO 2030
EQUATE MQRC_MSG_TOO_BIG_FOR_Q_MGR TO 2031
EQUATE MQRC_NO_MSG_AVAILABLE TO 2033
EQUATE MQRC_NO_MSG_UNDER_CURSOR TO 2034
EQUATE MQRC_NOT_AUTHORIZED TO 2035
EQUATE MQRC_NOT_OPEN_FOR_BROWSE TO 2036
EQUATE MQRC_NOT_OPEN_FOR_INPUT TO 2037
EQUATE MQRC_NOT_OPEN_FOR_INQUIRE TO 2038
EQUATE MQRC_NOT_OPEN_FOR_OUTPUT TO 2039
EQUATE MQRC_NOT_OPEN_FOR_SET TO 2040
EQUATE MQRC_OBJECT_CHANGED TO 2041
EQUATE MQRC_OBJECT_IN_USE TO 2042
EQUATE MQRC_OBJECT_TYPE_ERROR TO 2043
EQUATE MQRC_OD_ERROR TO 2044
EQUATE MQRC_OPTION_NOT_VALID_FOR_TYPE TO 2045
EQUATE MQRC_OPTIONS_ERROR TO 2046
EQUATE MQRC_PERSISTENCE_ERROR TO 2047
EQUATE MQRC_PERSISTENT_NOT_ALLOWED TO 2048
EQUATE MQRC_PRIORITY_EXCEEDS_MAXIMUM TO 2049
EQUATE MQRC_PRIORITY_ERROR TO 2050
EQUATE MQRC_PUT_INHIBITED TO 2051
EQUATE MQRC_Q_DELETED TO 2052
EQUATE MQRC_Q_FULL TO 2053
EQUATE MQRC_Q_NOT_EMPTY TO 2055
EQUATE MQRC_Q_SPACE_NOT_AVAILABLE TO 2056
EQUATE MQRC_Q_TYPE_ERROR TO 2057
EQUATE MQRC_Q_MGR_NAME_ERROR TO 2058
EQUATE MQRC_Q_MGR_NOT_AVAILABLE TO 2059
EQUATE MQRC_REPORT_OPTIONS_ERROR TO 2061
EQUATE MQRC_SECOND_MARK_NOT_ALLOWED TO 2062
EQUATE MQRC_SECURITY_ERROR TO 2063
EQUATE MQRC_SELECTOR_COUNT_ERROR TO 2065
EQUATE MQRC_SELECTOR_LIMIT_EXCEEDED TO 2066
EQUATE MQRC_SELECTOR_ERROR TO 2067
EQUATE MQRC_SELECTOR_NOT_FOR_TYPE TO 2068
EQUATE MQRC_SIGNAL_OUTSTANDING TO 2069
EQUATE MQRC_SIGNAL_REQUEST_ACCEPTED TO 2070
EQUATE MQRC_STORAGE_NOT_AVAILABLE TO 2071
EQUATE MQRC_SYNCPOINT_NOT_AVAILABLE TO 2072
EQUATE MQRC_TRIGGER_CONTROL_ERROR TO 2075
EQUATE MQRC_TRIGGER_DEPTH_ERROR TO 2076
EQUATE MQRC_TRIGGER_MSG_PRIORITY_ERR TO 2077
EQUATE MQRC_TRIGGER_TYPE_ERROR TO 2078
EQUATE MQRC_TRUNCATED_MSG_ACCEPTED TO 2079
EQUATE MQRC_TRUNCATED_MSG_FAILED TO 2080
EQUATE MQRC_UNKNOWN_ALIAS_BASE_Q TO 2082
EQUATE MQRC_UNKNOWN_OBJECT_NAME TO 2085
EQUATE MQRC_UNKNOWN_OBJECT_Q_MGR TO 2086
EQUATE MQRC_UNKNOWN_REMOTE_Q_MGR TO 2087
EQUATE MQRC_WAIT_INTERVAL_ERROR TO 2090
EQUATE MQRC_XMIT_Q_TYPE_ERROR TO 2091
EQUATE MQRC_XMIT_Q_USAGE_ERROR TO 2092
EQUATE MQRC_NOT_OPEN_FOR_PASS_ALL TO 2093
EQUATE MQRC_NOT_OPEN_FOR_PASS_IDENT TO 2094
EQUATE MQRC_NOT_OPEN_FOR_SET_ALL TO 2095
EQUATE MQRC_NOT_OPEN_FOR_SET_IDENT TO 2096
EQUATE MQRC_CONTEXT_HANDLE_ERROR TO 2097
EQUATE MQRC_CONTEXT_NOT_AVAILABLE TO 2098
EQUATE MQRC_SIGNAL1_ERROR TO 2099
EQUATE MQRC_OBJECT_ALREADY_EXISTS TO 2100
EQUATE MQRC_OBJECT_DAMAGED TO 2101
EQUATE MQRC_RESOURCE_PROBLEM TO 2102
EQUATE MQRC_ANOTHER_Q_MGR_CONNECTED TO 2103
EQUATE MQRC_UNKNOWN_REPORT_OPTION TO 2104
EQUATE MQRC_STORAGE_CLASS_ERROR TO 2105
EQUATE MQRC_COD_NOT_VALID_FOR_XCF_Q TO 2106
EQUATE MQRC_SUPPRESSED_BY_EXIT TO 2109
EQUATE MQRC_FORMAT_ERROR TO 2110
EQUATE MQRC_SOURCE_CCSID_ERROR TO 2111
EQUATE MQRC_SOURCE_INTEGER_ENC_ERROR TO 2112
EQUATE MQRC_SOURCE_DECIMAL_ENC_ERROR TO 2113
EQUATE MQRC_SOURCE_FLOAT_ENC_ERROR TO 2114
EQUATE MQRC_TARGET_CCSID_ERROR TO 2115
EQUATE MQRC_TARGET_INTEGER_ENC_ERROR TO 2116
EQUATE MQRC_TARGET_DECIMAL_ENC_ERROR TO 2117
EQUATE MQRC_TARGET_FLOAT_ENC_ERROR TO 2118
EQUATE MQRC_NOT_CONVERTED TO 2119
EQUATE MQRC_CONVERTED_MSG_TOO_BIG TO 2120
EQUATE MQRC_TRUNCATED TO 2120
EQUATE MQRC_NO_EXTERNAL_PARTICIPANTS TO 2121
EQUATE MQRC_PARTICIPANT_NOT_AVAILABLE TO 2122
EQUATE MQRC_OUTCOME_MIXED TO 2123
EQUATE MQRC_OUTCOME_PENDING TO 2124
EQUATE MQRC_BRIDGE_STARTED TO 2125
EQUATE MQRC_BRIDGE_STOPPED TO 2126
EQUATE MQRC_ADAPTER_STORAGE_SHORTAGE TO 2127
EQUATE MQRC_UOW_IN_PROGRESS TO 2128
EQUATE MQRC_ADAPTER_CONN_LOAD_ERROR TO 2129
EQUATE MQRC_ADAPTER_SERV_LOAD_ERROR TO 2130
EQUATE MQRC_ADAPTER_DEFS_ERROR TO 2131
EQUATE MQRC_ADAPTER_DEFS_LOAD_ERROR TO 2132
EQUATE MQRC_ADAPTER_CONV_LOAD_ERROR TO 2133
EQUATE MQRC_BO_ERROR TO 2134
EQUATE MQRC_DH_ERROR TO 2135
EQUATE MQRC_MULTIPLE_REASONS TO 2136
EQUATE MQRC_OPEN_FAILED TO 2137
EQUATE MQRC_ADAPTER_DISC_LOAD_ERROR TO 2138
EQUATE MQRC_CNO_ERROR TO 2139
EQUATE MQRC_CICS_WAIT_FAILED TO 2140
EQUATE MQRC_DLH_ERROR TO 2141
EQUATE MQRC_HEADER_ERROR TO 2142
EQUATE MQRC_SOURCE_LENGTH_ERROR TO 2143
EQUATE MQRC_TARGET_LENGTH_ERROR TO 2144
EQUATE MQRC_SOURCE_BUFFER_ERROR TO 2145
EQUATE MQRC_TARGET_BUFFER_ERROR TO 2146
EQUATE MQRC_IIH_ERROR TO 2148
EQUATE MQRC_PCF_ERROR TO 2149
EQUATE MQRC_DBCS_ERROR TO 2150
EQUATE MQRC_OBJECT_NAME_ERROR TO 2152
EQUATE MQRC_OBJECT_Q_MGR_NAME_ERROR TO 2153
EQUATE MQRC_RECS_PRESENT_ERROR TO 2154
EQUATE MQRC_OBJECT_RECORDS_ERROR TO 2155
EQUATE MQRC_RESPONSE_RECORDS_ERROR TO 2156
EQUATE MQRC_ASID_MISMATCH TO 2157
EQUATE MQRC_PMO_RECORD_FLAGS_ERROR TO 2158
EQUATE MQRC_PUT_MSG_RECORDS_ERROR TO 2159
EQUATE MQRC_CONN_ID_IN_USE TO 2160
EQUATE MQRC_Q_MGR_QUIESCING TO 2161
EQUATE MQRC_Q_MGR_STOPPING TO 2162
EQUATE MQRC_DUPLICATE_RECOV_COORD TO 2163
EQUATE MQRC_PMO_ERROR TO 2173
EQUATE MQRC_API_EXIT_NOT_FOUND TO 2182
EQUATE MQRC_API_EXIT_LOAD_ERROR TO 2183
EQUATE MQRC_REMOTE_Q_NAME_ERROR TO 2184
EQUATE MQRC_INCONSISTENT_PERSISTENCE TO 2185
EQUATE MQRC_GMO_ERROR TO 2186
EQUATE MQRC_CICS_BRIDGE_RESTRICTION TO 2187
EQUATE MQRC_STOPPED_BY_CLUSTER_EXIT TO 2188
EQUATE MQRC_CLUSTER_RESOLUTION_ERROR TO 2189
EQUATE MQRC_CONVERTED_STRING_TOO_BIG TO 2190
EQUATE MQRC_TMC_ERROR TO 2191
EQUATE MQRC_PAGESET_FULL TO 2192
EQUATE MQRC_STORAGE_MEDIUM_FULL TO 2192
EQUATE MQRC_PAGESET_ERROR TO 2193
EQUATE MQRC_NAME_NOT_VALID_FOR_TYPE TO 2194
EQUATE MQRC_UNEXPECTED_ERROR TO 2195
EQUATE MQRC_UNKNOWN_XMIT_Q TO 2196
EQUATE MQRC_UNKNOWN_DEF_XMIT_Q TO 2197
EQUATE MQRC_DEF_XMIT_Q_TYPE_ERROR TO 2198
EQUATE MQRC_DEF_XMIT_Q_USAGE_ERROR TO 2199
EQUATE MQRC_NAME_IN_USE TO 2201
EQUATE MQRC_CONNECTION_QUIESCING TO 2202
EQUATE MQRC_CONNECTION_STOPPING TO 2203
EQUATE MQRC_ADAPTER_NOT_AVAILABLE TO 2204
EQUATE MQRC_MSG_ID_ERROR TO 2206
EQUATE MQRC_CORREL_ID_ERROR TO 2207
EQUATE MQRC_FILE_SYSTEM_ERROR TO 2208
EQUATE MQRC_NO_MSG_LOCKED TO 2209
EQUATE MQRC_FILE_NOT_AUDITED TO 2216
EQUATE MQRC_CONNECTION_NOT_AUTHORIZED TO 2217
EQUATE MQRC_MSG_TOO_BIG_FOR_CHANNEL TO 2218
EQUATE MQRC_CALL_IN_PROGRESS TO 2219
EQUATE MQRC_RMH_ERROR TO 2220
EQUATE MQRC_Q_MGR_ACTIVE TO 2222
EQUATE MQRC_Q_MGR_NOT_ACTIVE TO 2223
EQUATE MQRC_Q_DEPTH_HIGH TO 2224
EQUATE MQRC_Q_DEPTH_LOW TO 2225
EQUATE MQRC_Q_SERVICE_INTERVAL_HIGH TO 2226
EQUATE MQRC_Q_SERVICE_INTERVAL_OK TO 2227
EQUATE MQRC_UNIT_OF_WORK_NOT_STARTED TO 2232
EQUATE MQRC_CHANNEL_AUTO_DEF_OK TO 2233
EQUATE MQRC_CHANNEL_AUTO_DEF_ERROR TO 2234
EQUATE MQRC_CFH_ERROR TO 2235
EQUATE MQRC_CFIL_ERROR TO 2236
EQUATE MQRC_CFIN_ERROR TO 2237
EQUATE MQRC_CFSL_ERROR TO 2238
EQUATE MQRC_CFST_ERROR TO 2239
EQUATE MQRC_INCOMPLETE_GROUP TO 2241
EQUATE MQRC_INCOMPLETE_MSG TO 2242
EQUATE MQRC_INCONSISTENT_CCSIDS TO 2243
EQUATE MQRC_INCONSISTENT_ENCODINGS TO 2244
EQUATE MQRC_INCONSISTENT_UOW TO 2245
EQUATE MQRC_INVALID_MSG_UNDER_CURSOR TO 2246
EQUATE MQRC_MATCH_OPTIONS_ERROR TO 2247
EQUATE MQRC_MDE_ERROR TO 2248
EQUATE MQRC_MSG_FLAGS_ERROR TO 2249
EQUATE MQRC_MSG_SEQ_NUMBER_ERROR TO 2250
EQUATE MQRC_OFFSET_ERROR TO 2251
EQUATE MQRC_ORIGINAL_LENGTH_ERROR TO 2252
EQUATE MQRC_SEGMENT_LENGTH_ZERO TO 2253
EQUATE MQRC_UOW_NOT_AVAILABLE TO 2255
EQUATE MQRC_WRONG_GMO_VERSION TO 2256
EQUATE MQRC_WRONG_MD_VERSION TO 2257
EQUATE MQRC_GROUP_ID_ERROR TO 2258
EQUATE MQRC_INCONSISTENT_BROWSE TO 2259
EQUATE MQRC_XQH_ERROR TO 2260
EQUATE MQRC_SRC_ENV_ERROR TO 2261
EQUATE MQRC_SRC_NAME_ERROR TO 2262
EQUATE MQRC_DEST_ENV_ERROR TO 2263
EQUATE MQRC_DEST_NAME_ERROR TO 2264
EQUATE MQRC_TM_ERROR TO 2265
EQUATE MQRC_CLUSTER_EXIT_ERROR TO 2266
EQUATE MQRC_CLUSTER_EXIT_LOAD_ERROR TO 2267
EQUATE MQRC_CLUSTER_PUT_INHIBITED TO 2268
EQUATE MQRC_CLUSTER_RESOURCE_ERROR TO 2269
EQUATE MQRC_NO_DESTINATIONS_AVAILABLE TO 2270
EQUATE MQRC_CONN_TAG_IN_USE TO 2271
EQUATE MQRC_PARTIALLY_CONVERTED TO 2272
EQUATE MQRC_CONNECTION_ERROR TO 2273
EQUATE MQRC_OPTION_ENVIRONMENT_ERROR TO 2274
EQUATE MQRC_CD_ERROR TO 2277
EQUATE MQRC_CLIENT_CONN_ERROR TO 2278
EQUATE MQRC_CHANNEL_STOPPED_BY_USER TO 2279
EQUATE MQRC_HCONFIG_ERROR TO 2280
EQUATE MQRC_FUNCTION_ERROR TO 2281
EQUATE MQRC_CHANNEL_STARTED TO 2282
EQUATE MQRC_CHANNEL_STOPPED TO 2283
EQUATE MQRC_CHANNEL_CONV_ERROR TO 2284
EQUATE MQRC_SERVICE_NOT_AVAILABLE TO 2285
EQUATE MQRC_INITIALIZATION_FAILED TO 2286
EQUATE MQRC_TERMINATION_FAILED TO 2287
EQUATE MQRC_UNKNOWN_Q_NAME TO 2288
EQUATE MQRC_SERVICE_ERROR TO 2289
EQUATE MQRC_Q_ALREADY_EXISTS TO 2290
EQUATE MQRC_USER_ID_NOT_AVAILABLE TO 2291
EQUATE MQRC_UNKNOWN_ENTITY TO 2292
EQUATE MQRC_UNKNOWN_AUTH_ENTITY TO 2293
EQUATE MQRC_UNKNOWN_REF_OBJECT TO 2294
EQUATE MQRC_CHANNEL_ACTIVATED TO 2295
EQUATE MQRC_CHANNEL_NOT_ACTIVATED TO 2296
EQUATE MQRC_UOW_CANCELED TO 2297
EQUATE MQRC_FUNCTION_NOT_SUPPORTED TO 2298
EQUATE MQRC_SELECTOR_TYPE_ERROR TO 2299
EQUATE MQRC_COMMAND_TYPE_ERROR TO 2300
EQUATE MQRC_MULTIPLE_INSTANCE_ERROR TO 2301
EQUATE MQRC_SYSTEM_ITEM_NOT_ALTERABLE TO 2302
EQUATE MQRC_BAG_CONVERSION_ERROR TO 2303
EQUATE MQRC_SELECTOR_OUT_OF_RANGE TO 2304
EQUATE MQRC_SELECTOR_NOT_UNIQUE TO 2305
EQUATE MQRC_INDEX_NOT_PRESENT TO 2306
EQUATE MQRC_STRING_ERROR TO 2307
EQUATE MQRC_ENCODING_NOT_SUPPORTED TO 2308
EQUATE MQRC_SELECTOR_NOT_PRESENT TO 2309
EQUATE MQRC_OUT_SELECTOR_ERROR TO 2310
EQUATE MQRC_STRING_TRUNCATED TO 2311
EQUATE MQRC_SELECTOR_WRONG_TYPE TO 2312
EQUATE MQRC_INCONSISTENT_ITEM_TYPE TO 2313
EQUATE MQRC_INDEX_ERROR TO 2314
EQUATE MQRC_SYSTEM_BAG_NOT_ALTERABLE TO 2315
EQUATE MQRC_ITEM_COUNT_ERROR TO 2316
EQUATE MQRC_FORMAT_NOT_SUPPORTED TO 2317
EQUATE MQRC_SELECTOR_NOT_SUPPORTED TO 2318
EQUATE MQRC_ITEM_VALUE_ERROR TO 2319
EQUATE MQRC_HBAG_ERROR TO 2320
EQUATE MQRC_PARAMETER_MISSING TO 2321
EQUATE MQRC_CMD_SERVER_NOT_AVAILABLE TO 2322
EQUATE MQRC_STRING_LENGTH_ERROR TO 2323
EQUATE MQRC_INQUIRY_COMMAND_ERROR TO 2324
EQUATE MQRC_NESTED_BAG_NOT_SUPPORTED TO 2325
EQUATE MQRC_BAG_WRONG_TYPE TO 2326
EQUATE MQRC_ITEM_TYPE_ERROR TO 2327
EQUATE MQRC_SYSTEM_BAG_NOT_DELETABLE TO 2328
EQUATE MQRC_SYSTEM_ITEM_NOT_DELETABLE TO 2329
EQUATE MQRC_CODED_CHAR_SET_ID_ERROR TO 2330
EQUATE MQRC_MSG_TOKEN_ERROR TO 2331
EQUATE MQRC_MISSING_WIH TO 2332
EQUATE MQRC_WIH_ERROR TO 2333
EQUATE MQRC_RFH_ERROR TO 2334
EQUATE MQRC_RFH_STRING_ERROR TO 2335
EQUATE MQRC_RFH_COMMAND_ERROR TO 2336
EQUATE MQRC_RFH_PARM_ERROR TO 2337
EQUATE MQRC_RFH_DUPLICATE_PARM TO 2338
EQUATE MQRC_RFH_PARM_MISSING TO 2339
EQUATE MQRC_CHAR_CONVERSION_ERROR TO 2340
EQUATE MQRC_UCS2_CONVERSION_ERROR TO 2341
EQUATE MQRC_DB2_NOT_AVAILABLE TO 2342
EQUATE MQRC_OBJECT_NOT_UNIQUE TO 2343
EQUATE MQRC_CONN_TAG_NOT_RELEASED TO 2344
EQUATE MQRC_CF_NOT_AVAILABLE TO 2345
EQUATE MQRC_CF_STRUC_IN_USE TO 2346
EQUATE MQRC_CF_STRUC_LIST_HDR_IN_USE TO 2347
EQUATE MQRC_CF_STRUC_AUTH_FAILED TO 2348
EQUATE MQRC_CF_STRUC_ERROR TO 2349
EQUATE MQRC_CONN_TAG_NOT_USABLE TO 2350
EQUATE MQRC_GLOBAL_UOW_CONFLICT TO 2351
EQUATE MQRC_LOCAL_UOW_CONFLICT TO 2352
EQUATE MQRC_HANDLE_IN_USE_FOR_UOW TO 2353
EQUATE MQRC_UOW_ENLISTMENT_ERROR TO 2354
EQUATE MQRC_UOW_MIX_NOT_SUPPORTED TO 2355
EQUATE MQRC_WXP_ERROR TO 2356
EQUATE MQRC_CURRENT_RECORD_ERROR TO 2357
EQUATE MQRC_NEXT_OFFSET_ERROR TO 2358
EQUATE MQRC_NO_RECORD_AVAILABLE TO 2359
EQUATE MQRC_OBJECT_LEVEL_INCOMPATIBLE TO 2360
EQUATE MQRC_NEXT_RECORD_ERROR TO 2361
EQUATE MQRC_BACKOUT_THRESHOLD_REACHED TO 2362
EQUATE MQRC_MSG_NOT_MATCHED TO 2363
EQUATE MQRC_JMS_FORMAT_ERROR TO 2364
EQUATE MQRC_SEGMENTS_NOT_SUPPORTED TO 2365
EQUATE MQRC_WRONG_CF_LEVEL TO 2366
EQUATE MQRC_CONFIG_CREATE_OBJECT TO 2367
EQUATE MQRC_CONFIG_CHANGE_OBJECT TO 2368
EQUATE MQRC_CONFIG_DELETE_OBJECT TO 2369
EQUATE MQRC_CONFIG_REFRESH_OBJECT TO 2370
EQUATE MQRC_CHANNEL_SSL_ERROR TO 2371
EQUATE MQRC_CF_STRUC_FAILED TO 2373
EQUATE MQRC_API_EXIT_ERROR TO 2374
EQUATE MQRC_API_EXIT_INIT_ERROR TO 2375
EQUATE MQRC_API_EXIT_TERM_ERROR TO 2376
EQUATE MQRC_EXIT_REASON_ERROR TO 2377
EQUATE MQRC_RESERVED_VALUE_ERROR TO 2378
EQUATE MQRC_NO_DATA_AVAILABLE TO 2379
EQUATE MQRC_SCO_ERROR TO 2380
EQUATE MQRC_KEY_REPOSITORY_ERROR TO 2381
EQUATE MQRC_CRYPTO_HARDWARE_ERROR TO 2382
EQUATE MQRC_AUTH_INFO_REC_COUNT_ERROR TO 2383
EQUATE MQRC_AUTH_INFO_REC_ERROR TO 2384
EQUATE MQRC_AIR_ERROR TO 2385
EQUATE MQRC_AUTH_INFO_TYPE_ERROR TO 2386
EQUATE MQRC_AUTH_INFO_CONN_NAME_ERROR TO 2387
EQUATE MQRC_LDAP_USER_NAME_ERROR TO 2388
EQUATE MQRC_LDAP_USER_NAME_LENGTH_ERR TO 2389
EQUATE MQRC_LDAP_PASSWORD_ERROR TO 2390
EQUATE MQRC_SSL_ALREADY_INITIALIZED TO 2391
EQUATE MQRC_SSL_CONFIG_ERROR TO 2392
EQUATE MQRC_SSL_INITIALIZATION_ERROR TO 2393
EQUATE MQRC_Q_INDEX_TYPE_ERROR TO 2394
EQUATE MQRC_SSL_NOT_ALLOWED TO 2396
EQUATE MQRC_JSSE_ERROR TO 2397
EQUATE MQRC_SSL_PEER_NAME_MISMATCH TO 2398
EQUATE MQRC_SSL_PEER_NAME_ERROR TO 2399
EQUATE MQRC_UNSUPPORTED_CIPHER_SUITE TO 2400
EQUATE MQRC_SSL_CERTIFICATE_REVOKED TO 2401
EQUATE MQRC_SSL_CERT_STORE_ERROR TO 2402
EQUATE MQRC_REOPEN_EXCL_INPUT_ERROR TO 6100
EQUATE MQRC_REOPEN_INQUIRE_ERROR TO 6101
EQUATE MQRC_REOPEN_SAVED_CONTEXT_ERR TO 6102
EQUATE MQRC_REOPEN_TEMPORARY_Q_ERROR TO 6103
EQUATE MQRC_ATTRIBUTE_LOCKED TO 6104
EQUATE MQRC_CURSOR_NOT_VALID TO 6105
EQUATE MQRC_ENCODING_ERROR TO 6106
EQUATE MQRC_STRUC_ID_ERROR TO 6107
EQUATE MQRC_NULL_POINTER TO 6108
EQUATE MQRC_NO_CONNECTION_REFERENCE TO 6109
EQUATE MQRC_NO_BUFFER TO 6110
EQUATE MQRC_BINARY_DATA_LENGTH_ERROR TO 6111
EQUATE MQRC_BUFFER_NOT_AUTOMATIC TO 6112
EQUATE MQRC_INSUFFICIENT_BUFFER TO 6113
EQUATE MQRC_INSUFFICIENT_DATA TO 6114
EQUATE MQRC_DATA_TRUNCATED TO 6115
EQUATE MQRC_ZERO_LENGTH TO 6116
EQUATE MQRC_NEGATIVE_LENGTH TO 6117
EQUATE MQRC_NEGATIVE_OFFSET TO 6118
EQUATE MQRC_INCONSISTENT_FORMAT TO 6119
EQUATE MQRC_INCONSISTENT_OBJECT_STATE TO 6120
EQUATE MQRC_CONTEXT_OBJECT_NOT_VALID TO 6121
EQUATE MQRC_CONTEXT_OPEN_ERROR TO 6122
EQUATE MQRC_STRUC_LENGTH_ERROR TO 6123
EQUATE MQRC_NOT_CONNECTED TO 6124
EQUATE MQRC_NOT_OPEN TO 6125
EQUATE MQRC_DISTRIBUTION_LIST_EMPTY TO 6126
EQUATE MQRC_INCONSISTENT_OPEN_OPTIONS TO 6127
EQUATE MQRC_WRONG_VERSION TO 6128
EQUATE MQRC_REFERENCE_ERROR TO 6129
                                                                        
                                                                        
***********************************************************************
**  Values Related to Queue Attributes                                *
***********************************************************************
                                                                        
*Queue Types
EQUATE MQQT_LOCAL TO 1
EQUATE MQQT_MODEL TO 2
EQUATE MQQT_ALIAS TO 3
EQUATE MQQT_REMOTE TO 6
EQUATE MQQT_CLUSTER TO 7
                                                                        
*Cluster Queue Types
EQUATE MQCQT_LOCAL_Q TO 1
EQUATE MQCQT_ALIAS_Q TO 2
EQUATE MQCQT_REMOTE_Q TO 3
EQUATE MQCQT_Q_MGR_ALIAS TO 4
                                                                        
*Extended Queue Types
EQUATE MQQT_ALL TO 1001
                                                                        
*Queue Definition Types
EQUATE MQQDT_PREDEFINED TO 1
EQUATE MQQDT_PERMANENT_DYNAMIC TO 2
EQUATE MQQDT_TEMPORARY_DYNAMIC TO 3
EQUATE MQQDT_SHARED_DYNAMIC TO 4
                                                                        
*Inhibit Get
EQUATE MQQA_GET_INHIBITED TO 1
EQUATE MQQA_GET_ALLOWED TO 0
                                                                        
*Inhibit Put
EQUATE MQQA_PUT_INHIBITED TO 1
EQUATE MQQA_PUT_ALLOWED TO 0
                                                                        
*Queue Shareability
EQUATE MQQA_SHAREABLE TO 1
EQUATE MQQA_NOT_SHAREABLE TO 0
                                                                        
*Back-Out Hardening
EQUATE MQQA_BACKOUT_HARDENED TO 1
EQUATE MQQA_BACKOUT_NOT_HARDENED TO 0
                                                                        
*Message Delivery Sequence
EQUATE MQMDS_PRIORITY TO 0
EQUATE MQMDS_FIFO TO 1
                                                                        
*Trigger Control
EQUATE MQTC_OFF TO 0
EQUATE MQTC_ON TO 1
                                                                        
*Trigger Types
EQUATE MQTT_NONE TO 0
EQUATE MQTT_FIRST TO 1
EQUATE MQTT_EVERY TO 2
EQUATE MQTT_DEPTH TO 3
                                                                        
*Queue Usage
EQUATE MQUS_NORMAL TO 0
EQUATE MQUS_TRANSMISSION TO 1
                                                                        
*Distribution Lists
EQUATE MQDL_SUPPORTED TO 1
EQUATE MQDL_NOT_SUPPORTED TO 0
                                                                        
*Index Type
EQUATE MQIT_NONE TO 0
EQUATE MQIT_MSG_ID TO 1
EQUATE MQIT_CORREL_ID TO 2
EQUATE MQIT_MSG_TOKEN TO 4
EQUATE MQIT_GROUP_ID TO 5
                                                                        
*Default Bind
EQUATE MQBND_BIND_ON_OPEN TO 0
EQUATE MQBND_BIND_NOT_FIXED TO 1
                                                                        
*Queue Sharing Group Disposition
EQUATE MQQSGD_Q_MGR TO 0
EQUATE MQQSGD_COPY TO 1
EQUATE MQQSGD_SHARED TO 2
EQUATE MQQSGD_GROUP TO 3
                                                                        
                                                                        
***********************************************************************
**  Values Related to Namelist Attributes                             *
***********************************************************************
                                                                        
*Name Count
EQUATE MQNC_MAX_NAMELIST_NAME_COUNT TO 256
                                                                        
*Namelist Type
EQUATE MQNT_NONE TO 0
EQUATE MQNT_Q TO 1
EQUATE MQNT_CLUSTER TO 2
EQUATE MQNT_AUTH_INFO TO 4
EQUATE MQNT_ALL TO 1001
                                                                        
                                                                        
***********************************************************************
**  Values Related to Process-Definition Attributes                   *
***********************************************************************
                                                                        
*Application Type
*See values for "Put Application Type" under MQMD
                                                                        
                                                                        
***********************************************************************
**  Values Related to Authentication-Information Attributes           *
***********************************************************************
                                                                        
*Authentication Information Type
*See values for "Authentication Information Type" under MQAIR
                                                                        
                                                                        
***********************************************************************
**  Values Related to Queue-Manager Attributes                        *
***********************************************************************
                                                                        
*Channel Auto Definition
EQUATE MQCHAD_DISABLED TO 0
EQUATE MQCHAD_ENABLED TO 1
                                                                        
*Command Level
EQUATE MQCMDL_LEVEL_1 TO 100
EQUATE MQCMDL_LEVEL_101 TO 101
EQUATE MQCMDL_LEVEL_110 TO 110
EQUATE MQCMDL_LEVEL_114 TO 114
EQUATE MQCMDL_LEVEL_120 TO 120
EQUATE MQCMDL_LEVEL_200 TO 200
EQUATE MQCMDL_LEVEL_201 TO 201
EQUATE MQCMDL_LEVEL_210 TO 210
EQUATE MQCMDL_LEVEL_220 TO 220
EQUATE MQCMDL_LEVEL_221 TO 221
EQUATE MQCMDL_LEVEL_320 TO 320
EQUATE MQCMDL_LEVEL_420 TO 420
EQUATE MQCMDL_LEVEL_500 TO 500
EQUATE MQCMDL_LEVEL_510 TO 510
EQUATE MQCMDL_LEVEL_520 TO 520
EQUATE MQCMDL_LEVEL_530 TO 530
                                                                        
*Distribution Lists
*See values for "Distribution Lists" under Queue Attributes
                                                                        
*Expiration Scan Interval
EQUATE MQEXPI_OFF TO 0
                                                                        
*Intra-Group Queuing
EQUATE MQIGQ_DISABLED TO 0
EQUATE MQIGQ_ENABLED TO 1
                                                                        
*Intra-Group Queuing Put Authority
EQUATE MQIGQPA_DEFAULT TO 1
EQUATE MQIGQPA_CONTEXT TO 2
EQUATE MQIGQPA_ONLY_IGQ TO 3
EQUATE MQIGQPA_ALTERNATE_OR_IGQ TO 4
                                                                        
*Platform
EQUATE MQPL_MVS TO 1
EQUATE MQPL_OS390 TO 1
EQUATE MQPL_ZOS TO 1
EQUATE MQPL_OS2 TO 2
EQUATE MQPL_AIX TO 3
EQUATE MQPL_UNIX TO 3
EQUATE MQPL_OS400 TO 4
EQUATE MQPL_WINDOWS TO 5
EQUATE MQPL_WINDOWS_NT TO 11
EQUATE MQPL_VMS TO 12
EQUATE MQPL_NSK TO 13
                                                                        
*Syncpoint Availability
EQUATE MQSP_AVAILABLE TO 1
EQUATE MQSP_NOT_AVAILABLE TO 0
                                                                        
                                                                        
***********************************************************************
**  MQAIR Structure -- Authentication Information Record              *
***********************************************************************

* MQAIR Fields
EQUATE MQAIR.StrucId            TO 1
EQUATE MQAIR.Version            TO 2
EQUATE MQAIR.AuthInfoType       TO 3
EQUATE MQAIR.AuthInfoConnName   TO 4
EQUATE MQAIR.LDAPUserNamePtr    TO 5
EQUATE MQAIR.LDAPUserNameOffset TO 6
EQUATE MQAIR.LDAPUserNameLength TO 7
EQUATE MQAIR.LDAPPassword       TO 8
 
* Default MQAIR variable
MQAIR.DFLT = ""
MQAIR.DFLT<MQAIR.StrucId>            = MQAIR_STRUC_ID
MQAIR.DFLT<MQAIR.Version>            = MQAIR_VERSION_1
MQAIR.DFLT<MQAIR.AuthInfoType>       = MQAIT_CRL_LDAP
MQAIR.DFLT<MQAIR.AuthInfoConnName>   = ""
MQAIR.DFLT<MQAIR.LDAPUserNamePtr>    = MQPTR
MQAIR.DFLT<MQAIR.LDAPUserNameOffset> = 0
MQAIR.DFLT<MQAIR.LDAPUserNameLength> = 0
MQAIR.DFLT<MQAIR.LDAPPassword>       = ""


***********************************************************************
**  MQBO Structure -- Begin Options                                   *
***********************************************************************
                                                                        
* MQBO Fields
EQUATE MQBO.StrucId TO 1
EQUATE MQBO.Version TO 2
EQUATE MQBO.Options TO 3
 
* Default MQBO variable
MQBO.DFLT = ""
MQBO.DFLT<MQBO.StrucId> = MQBO_STRUC_ID
MQBO.DFLT<MQBO.Version> = MQBO_VERSION_1
MQBO.DFLT<MQBO.Options> = MQBO_NONE
        
                                                                        
***********************************************************************
**  MQCIH Structure -- CICS Information Header                        *
***********************************************************************
                                                                        
* MQCIH Fields
EQUATE MQCIH.StrucId            TO  1
EQUATE MQCIH.Version            TO  2
EQUATE MQCIH.StrucLength        TO  3
EQUATE MQCIH.Encoding           TO  4
EQUATE MQCIH.CodedCharSetId     TO  5
EQUATE MQCIH.Format             TO  6
EQUATE MQCIH.Flags              TO  7
EQUATE MQCIH.ReturnCode         TO  8
EQUATE MQCIH.CompCode           TO  9
EQUATE MQCIH.Reason             TO 10
EQUATE MQCIH.UOWControl         TO 11
EQUATE MQCIH.GetWaitInterval    TO 12
EQUATE MQCIH.LinkType           TO 13
EQUATE MQCIH.OutputDataLength   TO 14
EQUATE MQCIH.FacilityKeepTime   TO 15
EQUATE MQCIH.ADSDescriptor      TO 16
EQUATE MQCIH.ConversationalTask TO 17
EQUATE MQCIH.TaskEndStatus      TO 18
EQUATE MQCIH.Facility           TO 19
EQUATE MQCIH.Function           TO 20
EQUATE MQCIH.AbendCode          TO 21
EQUATE MQCIH.Authenticator      TO 22
EQUATE MQCIH.Reserved1          TO 23
EQUATE MQCIH.ReplyToFormat      TO 24
EQUATE MQCIH.RemoteSysId        TO 25
EQUATE MQCIH.RemoteTransId      TO 26
EQUATE MQCIH.TransactionId      TO 27
EQUATE MQCIH.FacilityLike       TO 28
EQUATE MQCIH.AttentionId        TO 29
EQUATE MQCIH.StartCode          TO 30
EQUATE MQCIH.CancelCode         TO 31
EQUATE MQCIH.NextTransactionId  TO 32
EQUATE MQCIH.Reserved2          TO 33
EQUATE MQCIH.Reserved3          TO 34
EQUATE MQCIH.CursorPosition     TO 35
EQUATE MQCIH.ErrorOffset        TO 36
EQUATE MQCIH.InputItem          TO 37
EQUATE MQCIH.Reserved4          TO 38
 
* Default MQCIH variable
MQCIH.DFLT = ""
MQCIH.DFLT<MQCIH.StrucId>            = MQCIH_STRUC_ID
MQCIH.DFLT<MQCIH.Version>            = MQCIH_VERSION_2
MQCIH.DFLT<MQCIH.StrucLength>        = MQCIH_LENGTH_2
MQCIH.DFLT<MQCIH.Encoding>           = 0
MQCIH.DFLT<MQCIH.CodedCharSetId>     = 0
MQCIH.DFLT<MQCIH.Format>             = MQFMT_NONE
MQCIH.DFLT<MQCIH.Flags>              = MQCIH_NONE
MQCIH.DFLT<MQCIH.ReturnCode>         = MQCRC_OK
MQCIH.DFLT<MQCIH.CompCode>           = MQCC_OK
MQCIH.DFLT<MQCIH.Reason>             = MQRC_NONE
MQCIH.DFLT<MQCIH.UOWControl>         = MQCUOWC_ONLY
MQCIH.DFLT<MQCIH.GetWaitInterval>    = MQCGWI_DEFAULT
MQCIH.DFLT<MQCIH.LinkType>           = MQCLT_PROGRAM
MQCIH.DFLT<MQCIH.OutputDataLength>   = MQCODL_AS_INPUT
MQCIH.DFLT<MQCIH.FacilityKeepTime>   = 0
MQCIH.DFLT<MQCIH.ADSDescriptor>      = MQCADSD_NONE
MQCIH.DFLT<MQCIH.ConversationalTask> = MQCCT_NO
MQCIH.DFLT<MQCIH.TaskEndStatus>      = MQCTES_NOSYNC
MQCIH.DFLT<MQCIH.Facility>           = MQBYTE8
MQCIH.DFLT<MQCIH.Function>           = MQCFUNC_NONE
MQCIH.DFLT<MQCIH.AbendCode>          = ""
MQCIH.DFLT<MQCIH.Authenticator>      = ""
MQCIH.DFLT<MQCIH.Reserved1>          = ""
MQCIH.DFLT<MQCIH.ReplyToFormat>      = MQFMT_NONE
MQCIH.DFLT<MQCIH.RemoteSysId>        = ""
MQCIH.DFLT<MQCIH.RemoteTransId>      = ""
MQCIH.DFLT<MQCIH.TransactionId>      = ""
MQCIH.DFLT<MQCIH.FacilityLike>       = ""
MQCIH.DFLT<MQCIH.AttentionId>        = ""
MQCIH.DFLT<MQCIH.StartCode>          = MQCSC_NONE
MQCIH.DFLT<MQCIH.CancelCode>         = ""
MQCIH.DFLT<MQCIH.NextTransactionId>  = ""
MQCIH.DFLT<MQCIH.Reserved2>          = ""
MQCIH.DFLT<MQCIH.Reserved3>          = ""
MQCIH.DFLT<MQCIH.CursorPosition>     = 0
MQCIH.DFLT<MQCIH.ErrorOffset>        = 0
MQCIH.DFLT<MQCIH.InputItem>          = 0
MQCIH.DFLT<MQCIH.Reserved4>          = 0
                                                                        
                                                                        
***********************************************************************
**  MQSCO Structure -- SSL Configuration Options                      *
***********************************************************************
                                                                        
* MQSCO Fields
EQUATE MQSCO.StrucId           TO 1
EQUATE MQSCO.Version           TO 2
EQUATE MQSCO.KeyRepository     TO 3
EQUATE MQSCO.CryptoHardware    TO 4
EQUATE MQSCO.AuthInfoRecCount  TO 5
EQUATE MQSCO.AuthInfoRecOffset TO 6
EQUATE MQSCO.AuthInfoRecPtr    TO 7
 
* Default MQSCO variable
MQSCO.DFLT = ""
MQSCO.DFLT<MQSCO.StrucId>           = MQSCO_STRUC_ID
MQSCO.DFLT<MQSCO.Version>           = MQSCO_VERSION_1
MQSCO.DFLT<MQSCO.KeyRepository>     = ""
MQSCO.DFLT<MQSCO.CryptoHardware>    = ""
MQSCO.DFLT<MQSCO.AuthInfoRecCount>  = 0
MQSCO.DFLT<MQSCO.AuthInfoRecOffset> = 0
MQSCO.DFLT<MQSCO.AuthInfoRecPtr>    = MQPTR
                                                                        
                                                                        
***********************************************************************
**  MQCNO Structure -- Connect Options                                *
***********************************************************************
                                                                        
* MQCNO Fields
EQUATE MQCNO.StrucId          TO 1
EQUATE MQCNO.Version          TO 2
EQUATE MQCNO.Options          TO 3
EQUATE MQCNO.ClientConnOffset TO 4
EQUATE MQCNO.ClientConnPtr    TO 5
EQUATE MQCNO.ConnTag          TO 6
EQUATE MQCNO.SSLConfigPtr     TO 7
EQUATE MQCNO.SSLConfigOffset  TO 8
 
* Default MQCNO variable
MQCNO.DFLT = ""
MQCNO.DFLT<MQCNO.StrucId>          = MQCNO_STRUC_ID
MQCNO.DFLT<MQCNO.Version>          = MQCNO_VERSION_1
MQCNO.DFLT<MQCNO.Options>          = MQCNO_NONE
MQCNO.DFLT<MQCNO.ClientConnOffset> = 0
MQCNO.DFLT<MQCNO.ClientConnPtr>    = MQPTR
MQCNO.DFLT<MQCNO.ConnTag>          = MQBYTE128
MQCNO.DFLT<MQCNO.SSLConfigPtr>     = MQPTR
MQCNO.DFLT<MQCNO.SSLConfigOffset>  = 0
                                                                        
                                                                        
***********************************************************************
**  MQDH Structure -- Distribution Header                             *
***********************************************************************
                                                                        
* MQDH Fields
EQUATE MQDH.StrucId         TO  1
EQUATE MQDH.Version         TO  2
EQUATE MQDH.StrucLength     TO  3
EQUATE MQDH.Encoding        TO  4
EQUATE MQDH.CodedCharSetId  TO  5
EQUATE MQDH.Format          TO  6
EQUATE MQDH.Flags           TO  7
EQUATE MQDH.PutMsgRecFields TO  8
EQUATE MQDH.RecsPresent     TO  9
EQUATE MQDH.ObjectRecOffset TO 10
EQUATE MQDH.PutMsgRecOffset TO 11
 
* Default MQDH variable
MQDH.DFLT = ""
MQDH.DFLT<MQDH.StrucId>         = MQDH_STRUC_ID
MQDH.DFLT<MQDH.Version>         = MQDH_VERSION_1
MQDH.DFLT<MQDH.StrucLength>     = 0
MQDH.DFLT<MQDH.Encoding>        = 0
MQDH.DFLT<MQDH.CodedCharSetId>  = MQCCSI_UNDEFINED
MQDH.DFLT<MQDH.Format>          = MQFMT_NONE
MQDH.DFLT<MQDH.Flags>           = MQDHF_NONE
MQDH.DFLT<MQDH.PutMsgRecFields> = MQPMRF_NONE
MQDH.DFLT<MQDH.RecsPresent>     = 0
MQDH.DFLT<MQDH.ObjectRecOffset> = 0
MQDH.DFLT<MQDH.PutMsgRecOffset> = 0
                                                                        
                                                                        
***********************************************************************
**  MQDLH Structure -- Dead Letter Header                             *
***********************************************************************

EQUATE MQDLH.StrucId        TO  1 ;* Structure identifier
EQUATE MQDLH.Version        TO  2 ;* Structure version number
EQUATE MQDLH.Reason         TO  3 ;* Reason message arrived on dead-letter 
                                  ;* (undelivered-message) queue
EQUATE MQDLH.DestQName      TO  4 ;* Name of original destination queue
EQUATE MQDLH.DestQMgrName   TO  5 ;* Name of original destination queue
                                  ;* manager
EQUATE MQDLH.Encoding       TO  6 ;* Numeric encoding of data that follows 
                                  ;* MQDLH
EQUATE MQDLH.CodedCharSetId TO  7 ;* Character set identifier of data that 
                                  ;* follows MQDLH
EQUATE MQDLH.Format         TO  8 ;* Format name of data that follows MQDLH
EQUATE MQDLH.PutApplType    TO  9 ;* Type of application that put message on 
                                  ;* dead-letter (undelivered-message) queue
EQUATE MQDLH.PutApplName    TO 10 ;* Name of application that put message on 
                                  ;* dead-letter (undelivered-message) queue
EQUATE MQDLH.PutDate        TO 11 ;* Date when message was put on dead-letter
                                  ;* (undelivered-message) queue
EQUATE MQDLH.PutTime        TO 12 ;* Time when message was put on the 
                                  ;* dead-letter (undelivered-message) queue
 
MQDLH.DFLT = ""
MQDLH.DFLT<MQDLH.StrucId>        = MQDLH_STRUC_ID
MQDLH.DFLT<MQDLH.Version>        = MQDLH_VERSION_1
MQDLH.DFLT<MQDLH.Reason>         = MQRC_NONE
MQDLH.DFLT<MQDLH.DestQName>      = ""
MQDLH.DFLT<MQDLH.DestQMgrName>   = ""
MQDLH.DFLT<MQDLH.Encoding>       = 0
MQDLH.DFLT<MQDLH.CodedCharSetId> = MQCCSI_UNDEFINED
MQDLH.DFLT<MQDLH.Format>         = MQFMT_NONE
MQDLH.DFLT<MQDLH.PutApplType>    = 0
MQDLH.DFLT<MQDLH.PutApplName>    = ""
MQDLH.DFLT<MQDLH.PutDate>        = ""
MQDLH.DFLT<MQDLH.PutTime>        = ""

                                                                        
***********************************************************************
**  MQGMO Structure -- Get Message Options                            *
***********************************************************************

EQUATE MQGMO.StrucId        TO  1 ;* Structure identifier
EQUATE MQGMO.Version        TO  2 ;* Structure version number
EQUATE MQGMO.Options        TO  3 ;* Options that control the action of MQGET
EQUATE MQGMO.WaitInterval   TO  4 ;* Wait interval
EQUATE MQGMO.Signal1        TO  5 ;* Signal
EQUATE MQGMO.Signal2        TO  6 ;* Signal identifier
EQUATE MQGMO.ResolvedQName  TO  7 ;* Resolved name of destination queue
EQUATE MQGMO.MatchOptions   TO  8 ;* Options controlling selection criteria used 
                                  ;* for MQGET
EQUATE MQGMO.GroupStatus    TO  9 ;* Flag indicating whether message retrieved 
                                  ;* is in a group
EQUATE MQGMO.SegmentStatus  TO 10 ;* Flag indicating whether message retrieved is 
                                  ;* a segment of a logical message
EQUATE MQGMO.Segmentation   TO 11 ;* Flag indicating whether further segmentation 
                                  ;* is allowed for the message retrieved
EQUATE MQGMO.Reserved1      TO 12 ;* Reserved
EQUATE MQGMO.MsgToken       TO 13 ;* Message token
EQUATE MQGMO.ReturnedLength TO 14 ;* Length of message data returned (bytes)

MQGMO.DFLT = ""
MQGMO.DFLT<MQGMO.StrucId>        = MQGMO_STRUC_ID
MQGMO.DFLT<MQGMO.Version>        = MQGMO_VERSION_1
MQGMO.DFLT<MQGMO.Options>        = MQGMO_NO_WAIT
MQGMO.DFLT<MQGMO.WaitInterval>   = 0
MQGMO.DFLT<MQGMO.Signal1>        = 0
MQGMO.DFLT<MQGMO.Signal2>        = 0
MQGMO.DFLT<MQGMO.ResolvedQName>  = ""
MQGMO.DFLT<MQGMO.MatchOptions>   = MQMO_MATCH_MSG_ID + MQMO_MATCH_CORREL_ID
MQGMO.DFLT<MQGMO.GroupStatus>    = MQGS_NOT_IN_GROUP
MQGMO.DFLT<MQGMO.SegmentStatus>  = MQSS_NOT_A_SEGMENT
MQGMO.DFLT<MQGMO.Segmentation>   = MQSEG_INHIBITED
MQGMO.DFLT<MQGMO.Reserved1>      = ""
MQGMO.DFLT<MQGMO.MsgToken>       = MQBYTE16
MQGMO.DFLT<MQGMO.ReturnedLength> = MQRL_UNDEFINED


***********************************************************************
**  MQIIH Structure -- IMS Information Header                         *
***********************************************************************

EQUATE MQIIH.StrucId        TO  1 ;* Structure identifier
EQUATE MQIIH.Version        TO  2 ;* Structure version number
EQUATE MQIIH.StrucLength    TO  3 ;* Length of MQIIH structure
EQUATE MQIIH.Encoding       TO  4 ;* Reserved
EQUATE MQIIH.CodedCharSetId TO  5 ;* Reserved
EQUATE MQIIH.Format         TO  6 ;* MQ format name of data that follows MQIIH
EQUATE MQIIH.Flags          TO  7 ;* Flags
EQUATE MQIIH.LTermOverride  TO  8 ;* Logical terminal override
EQUATE MQIIH.MFSMapName     TO  9 ;* Message format services map name
EQUATE MQIIH.ReplyToFormat  TO 10 ;* MQ format name of reply message
EQUATE MQIIH.Authenticator  TO 11 ;* RACF password or passticket
EQUATE MQIIH.TranInstanceId TO 12 ;* Transaction instance identifier
EQUATE MQIIH.TranState      TO 13 ;* Transaction state
EQUATE MQIIH.CommitMode     TO 14 ;* Commit mode
EQUATE MQIIH.SecurityScope  TO 15 ;* Security scope
EQUATE MQIIH.Reserved       TO 16 ;* Reserved

MQIIH.DFLT = ""
MQIIH.DFLT<MQIIH.StrucId>        = MQIIH_STRUC_ID
MQIIH.DFLT<MQIIH.Version>        = MQIIH_VERSION_1
MQIIH.DFLT<MQIIH.StrucLength>    = MQIIH_LENGTH_1
MQIIH.DFLT<MQIIH.Encoding>       = 0
MQIIH.DFLT<MQIIH.CodedCharSetId> = 0
MQIIH.DFLT<MQIIH.Format>         = MQFMT_NONE
MQIIH.DFLT<MQIIH.Flags>          = MQIIH_NONE
MQIIH.DFLT<MQIIH.LTermOverride>  = ""
MQIIH.DFLT<MQIIH.MFSMapName>     = ""
MQIIH.DFLT<MQIIH.ReplyToFormat>  = MQFMT_NONE
MQIIH.DFLT<MQIIH.Authenticator>  = MQIAUT_NONE
MQIIH.DFLT<MQIIH.TranInstanceId> = MQBYTE16
MQIIH.DFLT<MQIIH.TranState>      = MQITS_NOT_IN_CONVERSATION
MQIIH.DFLT<MQIIH.CommitMode>     = MQICM_COMMIT_THEN_SEND
MQIIH.DFLT<MQIIH.SecurityScope>  = MQISS_CHECK
MQIIH.DFLT<MQIIH.Reserved>       = ""

                                                                        
***********************************************************************
**  MQMD Structure -- Message Descriptor                              *
***********************************************************************

EQUATE MQMD.StrucId          TO  1 ;* Structure identifier
EQUATE MQMD.Version          TO  2 ;* Structure version number
EQUATE MQMD.Report           TO  3 ;* Options for report messages
EQUATE MQMD.MsgType          TO  4 ;* Message type
EQUATE MQMD.Expiry           TO  5 ;* Message lifetime
EQUATE MQMD.Feedback         TO  6 ;* Feedback or reason code
EQUATE MQMD.Encoding         TO  7 ;* Numeric encoding of message data
EQUATE MQMD.CodedCharSetId   TO  8 ;* Character set identifier of message data
EQUATE MQMD.Format           TO  9 ;* Format name of message data
EQUATE MQMD.Priority         TO 10 ;* Message priority
EQUATE MQMD.Persistence      TO 11 ;* Message persistence
EQUATE MQMD.MsgId            TO 12 ;* Message identifier
EQUATE MQMD.CorrelId         TO 13 ;* Correlation identifier
EQUATE MQMD.BackoutCount     TO 14 ;* Backout counter
EQUATE MQMD.ReplyToQ         TO 15 ;* Name of reply queue
EQUATE MQMD.ReplyToQMgr      TO 16 ;* Name of reply queue manager
EQUATE MQMD.UserIdentifier   TO 17 ;* User identifier
EQUATE MQMD.AccountingToken  TO 18 ;* Accounting token
EQUATE MQMD.ApplIdentityData TO 19 ;* Application data relating to identity
EQUATE MQMD.PutApplType      TO 20 ;* Type of application that put the message
EQUATE MQMD.PutApplName      TO 21 ;* Name of application that put the message
EQUATE MQMD.PutDate          TO 22 ;* Date when message was put
EQUATE MQMD.PutTime          TO 23 ;* Time when message was put
EQUATE MQMD.ApplOriginData   TO 24 ;* Application data relating to origin
EQUATE MQMD.GroupId          TO 25 ;* Group identifier
EQUATE MQMD.MsgSeqNumber     TO 26 ;* Sequence number of logical message within group
EQUATE MQMD.Offset           TO 27 ;* Offset of data in physical message from start 
                                   ;* of logical message
EQUATE MQMD.MsgFlags         TO 28 ;* Message flags
EQUATE MQMD.OriginalLength   TO 29 ;* Length of original message

MQMD.DFLT = ""
MQMD.DFLT<MQMD.StrucId>          = MQMD_STRUC_ID
MQMD.DFLT<MQMD.Version>          = MQMD_VERSION_1
MQMD.DFLT<MQMD.Report>           = MQRO_NONE
MQMD.DFLT<MQMD.MsgType>          = MQMT_DATAGRAM
MQMD.DFLT<MQMD.Expiry>           = MQEI_UNLIMITED
MQMD.DFLT<MQMD.Feedback>         = MQFB_NONE
MQMD.DFLT<MQMD.Encoding>         = MQENC_NATIVE
MQMD.DFLT<MQMD.CodedCharSetId>   = MQCCSI_Q_MGR
MQMD.DFLT<MQMD.Format>           = MQFMT_NONE
MQMD.DFLT<MQMD.Priority>         = MQPRI_PRIORITY_AS_Q_DEF
MQMD.DFLT<MQMD.Persistence>      = MQPER_PERSISTENCE_AS_Q_DEF
MQMD.DFLT<MQMD.MsgId>            = MQBYTE24
MQMD.DFLT<MQMD.CorrelId>         = MQBYTE24
MQMD.DFLT<MQMD.BackoutCount>     = 0
MQMD.DFLT<MQMD.ReplyToQ>         = ""
MQMD.DFLT<MQMD.ReplyToQMgr>      = ""
MQMD.DFLT<MQMD.UserIdentifier>   = ""
MQMD.DFLT<MQMD.AccountingToken>  = MQBYTE32
MQMD.DFLT<MQMD.ApplIdentityData> = ""
MQMD.DFLT<MQMD.PutApplType>      = MQAT_NO_CONTEXT
MQMD.DFLT<MQMD.PutApplName>      = ""
MQMD.DFLT<MQMD.PutDate>          = ""
MQMD.DFLT<MQMD.PutTime>          = ""
MQMD.DFLT<MQMD.ApplOriginData>   = ""
MQMD.DFLT<MQMD.GroupId>          = MQBYTE24
MQMD.DFLT<MQMD.MsgSeqNumber>     = 1
MQMD.DFLT<MQMD.Offset>           = 0
MQMD.DFLT<MQMD.MsgFlags>         = MQMF_NONE
MQMD.DFLT<MQMD.OriginalLength>   = MQOL_UNDEFINED

                                                                        
***********************************************************************
**  MQMDE Structure -- Message Descriptor Extension                   *
***********************************************************************

EQUATE MQMDE.StrucId        TO  1 ;* Structure identifier
EQUATE MQMDE.Version        TO  2 ;* Structure version number
EQUATE MQMDE.StrucLength    TO  3 ;* Length of MQMDE structure
EQUATE MQMDE.Encoding       TO  4 ;* Numeric encoding of data that follows MQMDE
EQUATE MQMDE.CodedCharSetId TO  5 ;* Character-set identifier of data that follows MQMDE
EQUATE MQMDE.Format         TO  6 ;* Format name of data that follows MQMDE
EQUATE MQMDE.Flags          TO  7 ;* General flags
EQUATE MQMDE.GroupId        TO  8 ;* Group identifier
EQUATE MQMDE.MsgSeqNumber   TO  9 ;* Sequence number of logical message within group
EQUATE MQMDE.Offset         TO 10 ;* Offset of data in physical message from start of logical message
EQUATE MQMDE.MsgFlags       TO 11 ;* Message flags
EQUATE MQMDE.OriginalLength TO 12 ;* Length of original message
 
MQMDE.DFLT = ""
MQMDE.DFLT<MQMDE.StrucId>        = MQMDE_STRUC_ID
MQMDE.DFLT<MQMDE.Version>        = MQMDE_VERSION_2
MQMDE.DFLT<MQMDE.StrucLength>    = MQMDE_LENGTH_2
MQMDE.DFLT<MQMDE.Encoding>       = MQENC_NATIVE
MQMDE.DFLT<MQMDE.CodedCharSetId> = MQCCSI_UNDEFINED
MQMDE.DFLT<MQMDE.Format>         = MQFMT_NONE
MQMDE.DFLT<MQMDE.Flags>          = MQMDEF_NONE
MQMDE.DFLT<MQMDE.GroupId>        = MQBYTE24
MQMDE.DFLT<MQMDE.MsgSeqNumber>   = 1
MQMDE.DFLT<MQMDE.Offset>         = 0
MQMDE.DFLT<MQMDE.MsgFlags>       = MQMF_NONE
MQMDE.DFLT<MQMDE.OriginalLength> = MQOL_UNDEFINED
 
                                                                        
***********************************************************************
**  MQMD1 Structure -- Version-1 Message Descriptor                   *
***********************************************************************
                                                                        
EQUATE MQMD1.StrucId          TO  1 ;* Structure identifier
EQUATE MQMD1.Version          TO  2 ;* Structure version number
EQUATE MQMD1.Report           TO  3 ;* Report options
EQUATE MQMD1.MsgType          TO  4 ;* Message type
EQUATE MQMD1.Expiry           TO  5 ;* Expiry time
EQUATE MQMD1.Feedback         TO  6 ;* Feedback or reason code
EQUATE MQMD1.Encoding         TO  7 ;* Numeric encoding of message data
EQUATE MQMD1.CodedCharSetId   TO  8 ;* Character set identifier of message data
EQUATE MQMD1.Format           TO  9 ;* Format name of message data
EQUATE MQMD1.Priority         TO 10 ;* Message priority
EQUATE MQMD1.Persistence      TO 11 ;* Message persistence
EQUATE MQMD1.MsgId            TO 12 ;* Message identifier
EQUATE MQMD1.CorrelId         TO 13 ;* Correlation identifier
EQUATE MQMD1.BackoutCount     TO 14 ;* Backout counter
EQUATE MQMD1.ReplyToQ         TO 15 ;* Name of reply-to queue
EQUATE MQMD1.ReplyToQMgr      TO 16 ;* Name of reply queue manager
EQUATE MQMD1.UserIdentifier   TO 17 ;* User identifier
EQUATE MQMD1.AccountingToken  TO 18 ;* Accounting token
EQUATE MQMD1.ApplIdentityData TO 19 ;* Application data relating to identity
EQUATE MQMD1.PutApplType      TO 20 ;* Type of application that put the message
EQUATE MQMD1.PutApplName      TO 21 ;* Name of application that put the message
EQUATE MQMD1.PutDate          TO 22 ;* Date when message was put
EQUATE MQMD1.PutTime          TO 23 ;* Time when message was put
EQUATE MQMD1.ApplOriginData   TO 24 ;* Application data relating to origin
 
MQMD1.DFLT = ""
MQMD1.DFLT<MQMD1.StrucId>          = MQMD_STRUC_ID
MQMD1.DFLT<MQMD1.Version>          = MQMD_VERSION_1
MQMD1.DFLT<MQMD1.Report>           = MQRO_NONE
MQMD1.DFLT<MQMD1.MsgType>          = MQMT_DATAGRAM
MQMD1.DFLT<MQMD1.Expiry>           = MQEI_UNLIMITED
MQMD1.DFLT<MQMD1.Feedback>         = MQFB_NONE
MQMD1.DFLT<MQMD1.Encoding>         = MQENC_NATIVE
MQMD1.DFLT<MQMD1.CodedCharSetId>   = MQCCSI_Q_MGR
MQMD1.DFLT<MQMD1.Format>           = MQFMT_NONE
MQMD1.DFLT<MQMD1.Priority>         = MQPRI_PRIORITY_AS_Q_DEF
MQMD1.DFLT<MQMD1.Persistence>      = MQPER_PERSISTENCE_AS_Q_DEF
MQMD1.DFLT<MQMD1.MsgId>            = MQBYTE24
MQMD1.DFLT<MQMD1.CorrelId>         = MQBYTE24
MQMD1.DFLT<MQMD1.BackoutCount>     = 0
MQMD1.DFLT<MQMD1.ReplyToQ>         = ""
MQMD1.DFLT<MQMD1.ReplyToQMgr>      = ""
MQMD1.DFLT<MQMD1.UserIdentifier>   = ""
MQMD1.DFLT<MQMD1.AccountingToken>  = MQBYTE32
MQMD1.DFLT<MQMD1.ApplIdentityData> = ""
MQMD1.DFLT<MQMD1.PutApplType>      = MQAT_NO_CONTEXT
MQMD1.DFLT<MQMD1.PutApplName>      = ""
MQMD1.DFLT<MQMD1.PutDate>          = ""
MQMD1.DFLT<MQMD1.PutTime>          = ""
MQMD1.DFLT<MQMD1.ApplOriginData>   = ""
 
                                                                        
***********************************************************************
**  MQOD Structure -- Object Descriptor                               *
***********************************************************************

EQUATE MQOD.StrucId             TO  1 ;* Structure identifier
EQUATE MQOD.Version             TO  2 ;* Structure version number
EQUATE MQOD.ObjectType          TO  3 ;* Object type
EQUATE MQOD.ObjectName          TO  4 ;* Object name
EQUATE MQOD.ObjectQMgrName      TO  5 ;* Object queue manager name
EQUATE MQOD.DynamicQName        TO  6 ;* Dynamic queue name
EQUATE MQOD.AlternateUserId     TO  7 ;* Alternate user identifier
EQUATE MQOD.RecsPresent         TO  8 ;* Number of object records present
EQUATE MQOD.KnownDestCount      TO  9 ;* Number of local queues opened successfully
EQUATE MQOD.UnknownDestCount    TO 10 ;* Number of remote queues opened successfully
EQUATE MQOD.InvalidDestCount    TO 11 ;* Number of queues that failed to open
EQUATE MQOD.ObjectRecOffset     TO 12 ;* Offset of first object record from start of MQOD
EQUATE MQOD.ResponseRecOffset   TO 13 ;* Offset of first response record from start of MQOD
EQUATE MQOD.ObjectRecPtr        TO 14 ;* Address of first object record
EQUATE MQOD.ResponseRecPtr      TO 15 ;* Address of first response record
EQUATE MQOD.AlternateSecurityId TO 16 ;* Alternate security identifier
EQUATE MQOD.ResolvedQName       TO 17 ;* Resolved queue name
EQUATE MQOD.ResolvedQMgrName    TO 18 ;* Resolved queue manager name
 
MQOD.DFLT = ""
MQOD.DFLT<MQOD.StrucId>             = MQOD_STRUC_ID
MQOD.DFLT<MQOD.Version>             = MQOD_VERSION_1
MQOD.DFLT<MQOD.ObjectType>          = MQOT_Q
MQOD.DFLT<MQOD.ObjectName>          = ""
MQOD.DFLT<MQOD.ObjectQMgrName>      = ""
MQOD.DFLT<MQOD.DynamicQName>        = "AMQ.*"
MQOD.DFLT<MQOD.AlternateUserId>     = ""
MQOD.DFLT<MQOD.RecsPresent>         = 0
MQOD.DFLT<MQOD.KnownDestCount>      = 0
MQOD.DFLT<MQOD.UnknownDestCount>    = 0
MQOD.DFLT<MQOD.InvalidDestCount>    = 0
MQOD.DFLT<MQOD.ObjectRecOffset>     = 0
MQOD.DFLT<MQOD.ResponseRecOffset>   = 0
MQOD.DFLT<MQOD.ObjectRecPtr>        = MQPTR
MQOD.DFLT<MQOD.ResponseRecPtr>      = MQPTR
MQOD.DFLT<MQOD.AlternateSecurityId> = MQBYTE40
MQOD.DFLT<MQOD.ResolvedQName>       = ""
MQOD.DFLT<MQOD.ResolvedQMgrName>    = ""
 
                                                                        
***********************************************************************
**  MQOR Structure -- Object Record                                   *
***********************************************************************
                                                                        
EQUATE MQOR.ObjectName     TO 1 ;* Object name
EQUATE MQOR.ObjectQMgrName TO 2 ;* Object queue manager name
 
MQOR.DFLT = ""
MQOR.DFLT<MQOR.ObjectName>     = ""
MQOR.DFLT<MQOR.ObjectQMgrName> = ""
 
                                                                        
***********************************************************************
**  MQPMO Structure -- Put Message Options                            *
***********************************************************************
                                                                        
EQUATE MQPMO.StrucId           TO  1 ;* Structure identifier
EQUATE MQPMO.Version           TO  2 ;* Structure version number
EQUATE MQPMO.Options           TO  3 ;* Options that control the action of MQPUT and MQPUT1
EQUATE MQPMO.Timeout           TO  4 ;* Reserved
EQUATE MQPMO.Context           TO  5 ;* Object handle of input queue
EQUATE MQPMO.KnownDestCount    TO  6 ;* Number of messages sent successfully to local queues
EQUATE MQPMO.UnknownDestCount  TO  7 ;* Number of messages sent successfully to remote queues
EQUATE MQPMO.InvalidDestCount  TO  8 ;* Number of messages that could not be sent
EQUATE MQPMO.ResolvedQName     TO  9 ;* Resolved name of destination queue
EQUATE MQPMO.ResolvedQMgrName  TO 10 ;* Resolved name of destination queue manager
EQUATE MQPMO.RecsPresent       TO 11 ;* Number of put message records or response records present
EQUATE MQPMO.PutMsgRecFields   TO 12 ;* Flags indicating which MQPMR fields are present
EQUATE MQPMO.PutMsgRecOffset   TO 13 ;* Offset of first put message record from start of MQPMO
EQUATE MQPMO.ResponseRecOffset TO 14 ;* Offset of first response record from start of MQPMO
EQUATE MQPMO.PutMsgRecPtr      TO 15 ;* Address of first put message record
EQUATE MQPMO.ResponseRecPtr    TO 16 ;* Address of first response record
 
MQPMO.DFLT = ""
MQPMO.DFLT<MQPMO.StrucId>           = MQPMO_STRUC_ID
MQPMO.DFLT<MQPMO.Version>           = MQPMO_VERSION_1
MQPMO.DFLT<MQPMO.Options>           = MQPMO_NONE
MQPMO.DFLT<MQPMO.Timeout>           = -1
MQPMO.DFLT<MQPMO.Context>           = 0
MQPMO.DFLT<MQPMO.KnownDestCount>    = 0
MQPMO.DFLT<MQPMO.UnknownDestCount>  = 0
MQPMO.DFLT<MQPMO.InvalidDestCount>  = 0
MQPMO.DFLT<MQPMO.ResolvedQName>     = ""
MQPMO.DFLT<MQPMO.ResolvedQMgrName>  = ""
MQPMO.DFLT<MQPMO.RecsPresent>       = 0
MQPMO.DFLT<MQPMO.PutMsgRecFields>   = MQPMRF_NONE
MQPMO.DFLT<MQPMO.PutMsgRecOffset>   = 0
MQPMO.DFLT<MQPMO.ResponseRecOffset> = 0
MQPMO.DFLT<MQPMO.PutMsgRecPtr>      = MQPTR
MQPMO.DFLT<MQPMO.ResponseRecPtr>    = MQPTR
 
                                                                        
***********************************************************************
**  MQPMR Structure -- Put Message Record                             *
***********************************************************************
                                                                        
EQUATE MQPMR.MsgId           TO 1 ;* Message identifier
EQUATE MQPMR.CorrelId        TO 2 ;* Correlation identifier
EQUATE MQPMR.Feedback        TO 3 ;* Feedback or reason code
EQUATE MQPMR.AccountingToken TO 4 ;* Accounting token

MQPMR.DFLT = ""
MQPMR.DFLT<MQPMR.MsgId>           = MQBYTE24
MQPMR.DFLT<MQPMR.CorrelId>        = MQBYTE24
MQPMR.DFLT<MQPMR.Feedback>        = MQFB_NONE
MQPMR.DFLT<MQPMR.AccountingToken> = MQBYTE32
 
                                                                        
***********************************************************************
**  MQRFH Structure -- Rules and Formatting Header                    *
***********************************************************************

EQUATE MQRFH.StrucId        TO 1 ;* Structure identifier
EQUATE MQRFH.Version        TO 2 ;* Structure version number
EQUATE MQRFH.StrucLength    TO 3 ;* Total length of MQRFH including NameValueString
EQUATE MQRFH.Encoding       TO 4 ;* Numeric encoding of data that follows NameValueString
EQUATE MQRFH.CodedCharSetId TO 5 ;* Character set identifier of data that follows NameValueString
EQUATE MQRFH.Format         TO 6 ;* Format name of data that follows NameValueString
EQUATE MQRFH.Flags          TO 7 ;* Flags

MQRFH.DFLT = ""
MQRFH.DFLT<MQRFH.StrucId>        = MQRFH_STRUC_ID
MQRFH.DFLT<MQRFH.Version>        = MQRFH_VERSION_1
MQRFH.DFLT<MQRFH.StrucLength>    = MQRFH_STRUC_LENGTH_FIXED
MQRFH.DFLT<MQRFH.Encoding>       = MQENC_NATIVE
MQRFH.DFLT<MQRFH.CodedCharSetId> = MQCCSI_UNDEFINED
MQRFH.DFLT<MQRFH.Format>         = MQFMT_NONE
MQRFH.DFLT<MQRFH.Flags>          = MQRFH_NONE
 
                                                                        
***********************************************************************
**  MQRFH2 Structure -- Rules and Formatting Header 2                 *
***********************************************************************
                                                                        
EQUATE MQRFH2.StrucId        TO 1 ;* Structure identifier
EQUATE MQRFH2.Version        TO 2 ;* Structure version number
EQUATE MQRFH2.StrucLength    TO 3 ;* Total length of MQRFH2 including all NameValueLength and NameValueData fields
EQUATE MQRFH2.Encoding       TO 4 ;* Numeric encoding of data that follows last NameValueData field
EQUATE MQRFH2.CodedCharSetId TO 5 ;* Character set identifier of data that follows last NameValueData field
EQUATE MQRFH2.Format         TO 6 ;* Format name of data that follows last NameValueData field
EQUATE MQRFH2.Flags          TO 7 ;* Flags
EQUATE MQRFH2.NameValueCCSID TO 8 ;* Character set identifier of NameValueData

MQRFH2.DFLT = ""
MQRFH2.DFLT<MQRFH2.StrucId>        = MQRFH_STRUC_ID
MQRFH2.DFLT<MQRFH2.Version>        = MQRFH_VERSION_2
MQRFH2.DFLT<MQRFH2.StrucLength>    = MQRFH_STRUC_LENGTH_FIXED_2
MQRFH2.DFLT<MQRFH2.Encoding>       = MQENC_NATIVE
MQRFH2.DFLT<MQRFH2.CodedCharSetId> = MQCCSI_INHERIT
MQRFH2.DFLT<MQRFH2.Format>         = MQFMT_NONE
MQRFH2.DFLT<MQRFH2.Flags>          = MQRFH_NONE
MQRFH2.DFLT<MQRFH2.NameValueCCSID> = 1208

                                                                        
***********************************************************************
**  MQRMH Structure -- Reference Message Header                       *
***********************************************************************
                                                                        
EQUATE MQRMH.StrucId            TO  1 ;* Structure identifier
EQUATE MQRMH.Version            TO  2 ;* Structure version number
EQUATE MQRMH.StrucLength        TO  3 ;* Total length of MQRMH, including strings at 
                                      ;* end of fixed fields, but not the bulk data
EQUATE MQRMH.Encoding           TO  4 ;* Numeric encoding of bulk data
EQUATE MQRMH.CodedCharSetId     TO  5 ;* Character set identifier of bulk data
EQUATE MQRMH.Format             TO  6 ;* Format name of bulk data
EQUATE MQRMH.Flags              TO  7 ;* Reference message flags
EQUATE MQRMH.ObjectType         TO  8 ;* Object type
EQUATE MQRMH.ObjectInstanceId   TO  9 ;* Object instance identifier
EQUATE MQRMH.SrcEnvLength       TO 10 ;* Length of source environment data
EQUATE MQRMH.SrcEnvOffset       TO 11 ;* Offset of source environment data
EQUATE MQRMH.SrcNameLength      TO 12 ;* Length of source object name
EQUATE MQRMH.SrcNameOffset      TO 13 ;* Offset of source object name
EQUATE MQRMH.DestEnvLength      TO 14 ;* Length of destination environment data
EQUATE MQRMH.DestEnvOffset      TO 15 ;* Offset of destination environment data
EQUATE MQRMH.DestNameLength     TO 16 ;* Length of destination object name
EQUATE MQRMH.DestNameOffset     TO 17 ;* Offset of destination object name
EQUATE MQRMH.DataLogicalLength  TO 18 ;* Length of bulk data
EQUATE MQRMH.DataLogicalOffset  TO 19 ;* Low offset of bulk data
EQUATE MQRMH.DataLogicalOffset2 TO 20 ;* High offset of bulk data

MQRMH.DFLT = ""
MQRMH.DFLT<MQRMH.StrucId>            = MQRMH_STRUC_ID
MQRMH.DFLT<MQRMH.Version>            = MQRMH_VERSION_1
MQRMH.DFLT<MQRMH.StrucLength>        = 0
MQRMH.DFLT<MQRMH.Encoding>           = MQENC_NATIVE
MQRMH.DFLT<MQRMH.CodedCharSetId>     = MQCCSI_UNDEFINED
MQRMH.DFLT<MQRMH.Format>             = MQFMT_NONE
MQRMH.DFLT<MQRMH.Flags>              = MQRMHF_NOT_LAST
MQRMH.DFLT<MQRMH.ObjectType>         = ""
MQRMH.DFLT<MQRMH.ObjectInstanceId>   = MQBYTE24
MQRMH.DFLT<MQRMH.SrcEnvLength>       = 0
MQRMH.DFLT<MQRMH.SrcEnvOffset>       = 0
MQRMH.DFLT<MQRMH.SrcNameLength>      = 0
MQRMH.DFLT<MQRMH.SrcNameOffset>      = 0
MQRMH.DFLT<MQRMH.DestEnvLength>      = 0
MQRMH.DFLT<MQRMH.DestEnvOffset>      = 0
MQRMH.DFLT<MQRMH.DestNameLength>     = 0
MQRMH.DFLT<MQRMH.DestNameOffset>     = 0
MQRMH.DFLT<MQRMH.DataLogicalLength>  = 0
MQRMH.DFLT<MQRMH.DataLogicalOffset>  = 0
MQRMH.DFLT<MQRMH.DataLogicalOffset2> = 0

                                                                        
***********************************************************************
**  MQRR Structure -- Response Record                                 *
***********************************************************************

EQUATE MQRR.CompCode TO 1 ;* Completion code for queue
EQUATE MQRR.Reason   TO 2 ;* Reason code for queue

MQRR.DFLT = ""
MQRR.DFLT<MQRR.CompCode> = MQCC_OK
MQRR.DFLT<MQRR.Reason>   = MQRC_NONE


***********************************************************************
**  MQTM Structure -- Trigger Message                                 *
***********************************************************************
                                                                        
EQUATE MQTM.StrucId     TO 1 ;* Structure identifier
EQUATE MQTM.Version     TO 2 ;* Structure version number
EQUATE MQTM.QName       TO 3 ;* Name of triggered queue
EQUATE MQTM.ProcessName TO 4 ;* Name of process object
EQUATE MQTM.TriggerData TO 5 ;* Trigger data
EQUATE MQTM.ApplType    TO 6 ;* Application type
EQUATE MQTM.ApplId      TO 7 ;* Application identifier
EQUATE MQTM.EnvData     TO 8 ;* Environment data
EQUATE MQTM.UserData    TO 9 ;* User data

MQTM.DFLT = ""
MQTM.DFLT<MQTM.StrucId>     = MQTM_STRUC_ID
MQTM.DFLT<MQTM.Version>     = MQTM_VERSION_1
MQTM.DFLT<MQTM.QName>       = ""
MQTM.DFLT<MQTM.ProcessName> = ""
MQTM.DFLT<MQTM.TriggerData> = ""
MQTM.DFLT<MQTM.ApplType>    = 0
MQTM.DFLT<MQTM.ApplId>      = ""
MQTM.DFLT<MQTM.EnvData>     = ""
MQTM.DFLT<MQTM.UserData>    = ""

                                                                        
***********************************************************************
**  MQTMC2 Structure -- Trigger Message 2 (Character)                 *
***********************************************************************
                                                                        
EQUATE MQTMC2.StrucId     TO  1 ;* Structure identifier
EQUATE MQTMC2.Version     TO  2 ;* Structure version number
EQUATE MQTMC2.QName       TO  3 ;* Name of triggered queue
EQUATE MQTMC2.ProcessName TO  4 ;* Name of process object
EQUATE MQTMC2.TriggerData TO  5 ;* Trigger data
EQUATE MQTMC2.ApplType    TO  6 ;* Application type
EQUATE MQTMC2.ApplId      TO  7 ;* Application identifier
EQUATE MQTMC2.EnvData     TO  8 ;* Environment data
EQUATE MQTMC2.UserData    TO  9 ;* User data
EQUATE MQTMC2.QMgrName    TO 10 ;* Queue manager name

MQTMC2.DFLT = ""
MQTMC2.DFLT<MQTMC2.StrucId>     = MQTMC_STRUC_ID
MQTMC2.DFLT<MQTMC2.Version>     = MQTMC_VERSION_2
MQTMC2.DFLT<MQTMC2.QName>       = ""
MQTMC2.DFLT<MQTMC2.ProcessName> = ""
MQTMC2.DFLT<MQTMC2.TriggerData> = ""
MQTMC2.DFLT<MQTMC2.ApplType>    = ""
MQTMC2.DFLT<MQTMC2.ApplId>      = ""
MQTMC2.DFLT<MQTMC2.EnvData>     = ""
MQTMC2.DFLT<MQTMC2.UserData>    = ""
MQTMC2.DFLT<MQTMC2.QMgrName>    = ""
 
                                                                        
***********************************************************************
**  MQWIH Structure -- Work Information Header                        *
***********************************************************************
                                                                        
EQUATE MQWIH.StrucId        TO  1 ;* Structure identifier
EQUATE MQWIH.Version        TO  2 ;* Structure version number
EQUATE MQWIH.StrucLength    TO  3 ;* Length of MQWIH structure
EQUATE MQWIH.Encoding       TO  4 ;* Numeric encoding of data that follows MQWIH
EQUATE MQWIH.CodedCharSetId TO  5 ;* Character-set identifier of data that follows MQWIH
EQUATE MQWIH.Format         TO  6 ;* Format name of data that follows MQWIH
EQUATE MQWIH.Flags          TO  7 ;* Flags
EQUATE MQWIH.ServiceName    TO  8 ;* Service name
EQUATE MQWIH.ServiceStep    TO  9 ;* Service step name
EQUATE MQWIH.MsgToken       TO 10 ;* Message token
EQUATE MQWIH.Reserved       TO 11 ;* Reserved

MQWIH.DFLT = ""
MQWIH.DFLT<MQWIH.StrucId>        = MQWIH_STRUC_ID
MQWIH.DFLT<MQWIH.Version>        = MQWIH_VERSION_1
MQWIH.DFLT<MQWIH.StrucLength>    = MQWIH_LENGTH_1
MQWIH.DFLT<MQWIH.Encoding>       = 0
MQWIH.DFLT<MQWIH.CodedCharSetId> = MQCCSI_UNDEFINED
MQWIH.DFLT<MQWIH.Format>         = MQFMT_NONE
MQWIH.DFLT<MQWIH.Flags>          = MQWIH_NONE
MQWIH.DFLT<MQWIH.ServiceName>    = ""
MQWIH.DFLT<MQWIH.ServiceStep>    = ""
MQWIH.DFLT<MQWIH.MsgToken>       = MQBYTE16
MQWIH.DFLT<MQWIH.Reserved>       = ""
 
                                                                        
***********************************************************************
**  MQXQH Structure -- Transmission Queue Header                      *
***********************************************************************
                                                                        
EQUATE MQXQH.StrucId        TO 1 ;* Structure identifier
EQUATE MQXQH.Version        TO 2 ;* Structure version number
EQUATE MQXQH.RemoteQName    TO 3 ;* Name of destination queue
EQUATE MQXQH.RemoteQMgrName TO 4 ;* Name of destination queue manager
EQUATE MQXQH.MsgDesc        TO 5 ;* Original message descriptor

MQXQH.DFLT = ""
MQXQH.DFLT<MQXQH.StrucId>        = MQXQH_STRUC_ID
MQXQH.DFLT<MQXQH.Version>        = MQXQH_VERSION_1
MQXQH.DFLT<MQXQH.RemoteQName>    = ""
MQXQH.DFLT<MQXQH.RemoteQMgrName> = ""
MQXQH.DFLT<MQXQH.MsgDesc>        = LOWER(MQMD1.DFLT)

