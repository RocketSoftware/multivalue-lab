**********************************************************************
**
**   Header file for U2 MQSeries AMI BASIC programs
**
**   Header name:  U2AMI.H
**
**       IBM Confidential
**       OCO Source Materials
**       Copyright (C) IBM Corp.  2002, 2003
**
**       Module  %M%     Version %I%     Date    %H%
**
**********************************************************************

EQUATE AMB_FALSE TO 0
EQUATE AMB_TRUE  TO 1

EQUATE AMH_NULL_HANDLE    TO  0
EQUATE AMH_INVALID_HANDLE TO -1

**********************************************************************
**                                                                   *
**  System default object names                                      *
**                                                                   *
**********************************************************************

EQUATE AMSD_SESSION_NAME   TO  "SYSTEM.DEFAULT.SESSION"

EQUATE AMSD_SND            TO "SYSTEM.DEFAULT.SENDER"
EQUATE AMSD_RSP_SND        TO  "SYSTEM.DEFAULT.RESPONSE.SENDER"
EQUATE AMSD_RCV            TO  "SYSTEM.DEFAULT.RECEIVER"
EQUATE AMSD_PUB            TO  "SYSTEM.DEFAULT.PUBLISHER"
EQUATE AMSD_PUB_SND        TO  "SYSTEM.DEFAULT.PUBLISHER"
EQUATE AMSD_SUB            TO  "SYSTEM.DEFAULT.SUBSCRIBER"
EQUATE AMSD_SUB_SND        TO  "SYSTEM.DEFAULT.SUBSCRIBER"
EQUATE AMSD_SUB_RCV        TO  "SYSTEM.DEFAULT.SUBSCRIBER.RECEIVER"
EQUATE AMSD_POL            TO  "SYSTEM.DEFAULT.POLICY"
EQUATE AMSD_SYNC_POINT_POL TO  "SYSTEM.DEFAULT.SYNCPOINT.POLICY"
EQUATE AMSD_SND_MSG        TO  "SYSTEM.DEFAULT.SEND.MESSAGE"
EQUATE AMSD_RCV_MSG        TO  "SYSTEM.DEFAULT.RECEIVE.MESSAGE"

**********************************************************************
**                                                                   *
**  System default object handle synonyms                            *
**                                                                   *
**********************************************************************


EQUATE AMSD_RSP_SND_HANDLE        TO  -5
EQUATE AMSD_RCV_HANDLE            TO  -6
EQUATE AMSD_POL_HANDLE            TO  -7
EQUATE AMSD_SYNC_POINT_POL_HANDLE TO  -8
EQUATE AMSD_SND_MSG_HANDLE        TO  -9
EQUATE AMSD_RCV_MSG_HANDLE        TO -10

**********************************************************************
**                                                                   *
**  Built-in object definitions                                      *
**                                                                   *
**********************************************************************

EQUATE AMDEF_SYNC_POINT_POL TO  "AMT.SYSTEM.SYNCPOINT.POLICY"
EQUATE AMDEF_SND            TO  "AMT.SYSTEM.SENDER"
EQUATE AMDEF_RSP_SND        TO  "AMT.SYSTEM.RESPONSE.SENDER"
EQUATE AMDEF_RCV            TO  "AMT.SYSTEM.RECEIVER"
EQUATE AMDEF_PUB            TO  "AMT.SYSTEM.PUBLISHER"
EQUATE AMDEF_SUB            TO  "AMT.SYSTEM.SUBSCRIBER"
EQUATE AMDEF_POL            TO  "AMT.SYSTEM.POLICY"

**********************************************************************
**                                                                   *
**  Tag name constants for use with MQSeries Publish/Subscribe       *
**  name/value elements                                              *
**                                                                   *
**********************************************************************

EQUATE AMPS_COMMAND               TO  "MQPSCommand"
EQUATE AMPS_COMP_CODE             TO  "MQPSCompCode"
EQUATE AMPS_DELETE_OPTIONS        TO  "MQPSDelOpts"
EQUATE AMPS_ERROR_ID              TO  "MQPSErrorId"
EQUATE AMPS_ERROR_POS             TO  "MQPSErrorPos"
EQUATE AMPS_PARAMETER_ID          TO  "MQPSParmId"
EQUATE AMPS_PUBLICATION_OPTIONS   TO  "MQPSPubOpts"
EQUATE AMPS_TIMESTAMP             TO  "MQPSPubTime"
EQUATE AMPS_Q_MGR_NAME            TO  "MQPSQMgrName"
EQUATE AMPS_Q_NAME                TO  "MQPSQName"
EQUATE AMPS_REASON                TO  "MQPSReason"
EQUATE AMPS_REASON_TEXT           TO  "MQPSReasonText"
EQUATE AMPS_REGISTRATION_OPTIONS  TO  "MQPSRegOpts"
EQUATE AMPS_SEQUENCE_NUMBER       TO  "MQPSSeqNum"
EQUATE AMPS_STREAM_NAME           TO  "MQPSStreamName"
EQUATE AMPS_STRING_DATA           TO  "MQPSStringData"
EQUATE AMPS_TOPIC                 TO  "MQPSTopic"
EQUATE AMPS_USER_ID               TO  "MQPSUserId"
EQUATE AMPS_FILTER                TO  "MQPSFilter"
EQUATE AMPS_SUBSCRIPTION_POINT    TO  "MQPSSubPoint"
EQUATE AMPS_SEQUENCE              TO  "MQPSSequence"
EQUATE AMPS_CONTROL               TO  "MQPSControl"

**********************************************************************
**                                                                   *
**  Tag value constants for use with MQSeries Publish/Subscribe      *
**  name/value elements                                              *
**                                                                   *
**********************************************************************

EQUATE AMPS_DELETE_PUBLICATION      TO  "DeletePub"
EQUATE AMPS_DEREGISTER_PUBLISHER    TO  "DeregPub"
EQUATE AMPS_DEREGISTER_SUBSCRIBER   TO  "DeregSub"
EQUATE AMPS_PUBLISH                 TO  "Publish"
EQUATE AMPS_REGISTER_PUBLISHER      TO  "RegPub"
EQUATE AMPS_REGISTER_SUBSCRIBER     TO  "RegSub"
EQUATE AMPS_REQUEST_UPDATE          TO  "ReqUpdate"

EQUATE AMPS_ANONYMOUS               TO  "Anon"
EQUATE AMPS_CORREL_ID_AS_ID         TO  "CorrelAsId"
EQUATE AMPS_DEREGISTER_ALL          TO  "DeregAll"
EQUATE AMPS_DIRECT_REQUESTS         TO  "DirectReq"
EQUATE AMPS_INCLUDE_STREAM_NAME     TO  "InclStreamName"
EQUATE AMPS_INFORM_IF_RETAINED      TO  "InformIfRet"
EQUATE AMPS_IS_RETAINED_PUBLICATION TO  "IsRetainedPub"
EQUATE AMPS_LOCAL                   TO  "Local"
EQUATE AMPS_NEW_PUBS_ONLY           TO  "NewPubsOnly"
EQUATE AMPS_NO_REGISTRATION         TO  "NoReg"
EQUATE AMPS_NONE                    TO  "None"
EQUATE AMPS_OTHER_SUBSCRIBERS_ONLY  TO  "OtherSubsOnly"
EQUATE AMPS_PUB_ON_REQUEST_ONLY     TO  "PubOnReqOnly"
EQUATE AMPS_RETAIN_PUBLICATION      TO  "RetainPub"
EQUATE AMPS_PERSISTENT              TO  "Pers"
EQUATE AMPS_NON_PERSISTENT          TO  "NonPers"
EQUATE AMPS_PERSISTENT_AS_PUBLISHER TO  "PersAsPub"
EQUATE AMPS_PERSISTENT_AS_QUEUE     TO  "PersAsQueue"
EQUATE AMPS_CC_OK                   TO  "0"
EQUATE AMPS_CC_WARNING              TO  "1"
EQUATE AMPS_CC_ERROR                TO  "2"

**********************************************************************
**                                                                   *
**  Message constants for use with MQSeries Integrator Version 1     *
**  element names                                                    *
**                                                                   *
**********************************************************************

EQUATE AMPS_APPL_TYPE               TO  "OPT_APP_GRP"
EQUATE AMPS_MSG_TYPE                TO  "OPT_MSG_TYPE"

**********************************************************************
**                                                                   *
**  Message content descriptor (mcd) constants for use as MQSeries   *
**  Integrator Version 2 element names                               *
**                                                                   *
**********************************************************************

EQUATE AMMCD_MSG_SERVICE_DOMAIN     TO  "mcd.Msd"
EQUATE AMMCD_MSG_SET                TO  "mcd.Set"
EQUATE AMMCD_MSG_TYPE               TO  "mcd.Type"
EQUATE AMMCD_MSG_FORMAT             TO  "mcd.Fmt"

**********************************************************************
**                                                                   *
**  Group status constants for use with:                             *
**    amMsgSetGroupStatus/amMsgGetGroupStatus                        *
**                                                                   *
**********************************************************************
EQUATE AMGF_IN_GROUP      TO 1
EQUATE AMGF_FIRST         TO 2
EQUATE AMGF_LAST          TO 4

EQUATE AMGRP_MSG_NOT_IN_GROUP     TO 0
EQUATE AMGRP_FIRST_MSG_IN_GROUP   LITERALLY  "AMGF_IN_GROUP + AMGF_FIRST"
EQUATE AMGRP_MIDDLE_MSG_IN_GROUP  TO          AMGF_IN_GROUP
EQUATE AMGRP_LAST_MSG_IN_GROUP    LITERALLY  "AMGF_IN_GROUP + AMGF_LAST" 
EQUATE AMGRP_ONLY_MSG_IN_GROUP    LITERALLY  "AMGF_IN_GROUP + AMGF_FIRST + AMGF_LAST" 

**********************************************************************
**                                                                   *
**  Group status flags provided for performing bit-wise tests on     *
**    group status returned by amMsgGetGroupStatus                   *
**                                                                   *
**********************************************************************

**********************************************************************
**                                                                   *
**  Message type constants for use with:                             *
**    amMsgGetType                                                   *
**                                                                   *
**********************************************************************

EQUATE AMMT_NONE               TO 0
EQUATE AMMT_REQUEST            TO 1
EQUATE AMMT_REPLY              TO 2
EQUATE AMMT_REPORT             TO 4
EQUATE AMMT_DATAGRAM           TO 8

**********************************************************************
**                                                                   *
**  Feedback constants for use with:                                 *
**    amMsgGetReportCode                                             *
**                                                                   *
**********************************************************************

EQUATE AMFB_NONE              TO 0
EQUATE AMFB_CODE_EXPIRATION   TO 258
EQUATE AMFB_CODE_COA          TO 259
EQUATE AMFB_CODE_COD          TO 260

**********************************************************************
**                                                                   *
**  Message format constants for use with:                           *
**    amMsgGetFormat                                                 *
**    amMsgSetFormat                                                 *
**                                                                   *
**********************************************************************

EQUATE AMFMT_NONE             TO  "        "
EQUATE AMFMT_STRING           TO  "MQSTR   "
EQUATE AMFMT_RF_HEADER        TO  "MQHRF   "
EQUATE AMFMT_RF2_HEADER       TO  "MQHRF2  "

**********************************************************************
**                                                                   *
**  Receiver/Subscriber definition type constants for use with:      *
**    amRcvGetDefnType                                               *
**    amSubGetDefnType                                               *
**                                                                   *
**********************************************************************

EQUATE AMDT_UNDEFINED    TO 0
EQUATE AMDT_RESPONSE     TO 1
EQUATE AMDT_TEMP_DYNAMIC TO 2
EQUATE AMDT_DYNAMIC      TO 3
EQUATE AMDT_PREDEFINED   TO 4

**********************************************************************
**                                                                   *
**  Encoding constants for use with:                                 *
**    amSndGetEncoding                                               *
**    amPubGetEncoding                                               *
**    amSubGetEncoding                                               *
**    amMsgSetEncoding                                               *
**    amMsgGetEncoding                                               *
**                                                                   *
**********************************************************************

EQUATE AMENC_NORMAL             TO 0
EQUATE AMENC_REVERSED           TO 1
EQUATE AMENC_NORMAL_FLOAT_390   TO 2
EQUATE AMENC_REVERSED_FLOAT_390 TO 3
EQUATE AMENC_UNDEFINED          TO 4

EQUATE AMENC_NATIVE            TO AMENC_NORMAL

**********************************************************************
**                                                                   *
**  Browse option constants for use with:                            *
**    amRcvBrowse                                                    *
**                                                                   *
**********************************************************************

EQUATE AMBRW_UNLOCK          TO  1
EQUATE AMBRW_LOCK            TO  2
EQUATE AMBRW_FIRST           TO  4
EQUATE AMBRW_NEXT            TO  8
EQUATE AMBRW_CURRENT         TO 16
EQUATE AMBRW_RECEIVE_CURRENT TO 32
EQUATE AMBRW_DEFAULT         TO          AMBRW_NEXT
EQUATE AMBRW_LOCK_NEXT       LITERALLY  "AMBRW_LOCK + AMBRW_NEXT" 
EQUATE AMBRW_LOCK_FIRST      LITERALLY  "AMBRW_LOCK + AMBRW_FIRST" 
EQUATE AMBRW_LOCK_CURRENT    LITERALLY  "AMBRW_LOCK + AMBRW_CURRENT" 

**********************************************************************
**                                                                   *
**  Wait time constant for use with:                                 *
**    amPolGetWaitTime                                               *
**    amPolSetWaitTime                                               *
**                                                                   *
**********************************************************************

EQUATE AMWT_UNLIMITED TO -1

**********************************************************************
**                                                                   *
**  String length constants                                          *
**                                                                   *
**********************************************************************

EQUATE AMLEN_NULL_TERM       TO  -1
EQUATE AMLEN_MAX_NAME_LENGTH TO 256


**********************************************************************
**                                                                   *
**  Completion Codes                                                 *
**                                                                   *
**********************************************************************

EQUATE AMCC_OK       TO 0
EQUATE AMCC_WARNING  TO 1
EQUATE AMCC_FAILED   TO 2


**********************************************************************
**                                                                   *
**  Reason codes                                                     *
**                                                                   *
**********************************************************************

EQUATE AMRC_NONE                       TO   0
EQUATE AMRC_UNEXPECTED_ERR             TO   1

EQUATE AMRC_INVALID_Q_NAME             TO   2

EQUATE AMRC_INVALID_SENDER_NAME        TO   3
EQUATE AMRC_INVALID_RECEIVER_NAME      TO   4
EQUATE AMRC_INVALID_PUBLISHER_NAME     TO   5
EQUATE AMRC_INVALID_SUBSCRIBER_NAME    TO   6
EQUATE AMRC_INVALID_POLICY_NAME        TO   7
EQUATE AMRC_INVALID_MSG_NAME           TO   8
EQUATE AMRC_INVALID_SESSION_NAME       TO   9
EQUATE AMRC_INVALID_DIST_LIST_NAME     TO  10

EQUATE AMRC_POLICY_HANDLE_ERR          TO  11
EQUATE AMRC_SERVICE_HANDLE_ERR         TO  12
EQUATE AMRC_MSG_HANDLE_ERR             TO  13
EQUATE AMRC_SESSION_HANDLE_ERR         TO  14

EQUATE AMRC_BROWSE_OPTIONS_ERR         TO  15
EQUATE AMRC_INSUFFICIENT_MEMORY        TO  16

EQUATE AMRC_WAIT_TIME_READ_ONLY        TO  17
EQUATE AMRC_SERVICE_NOT_FOUND          TO  18

EQUATE AMRC_MSG_NOT_FOUND              TO  19

EQUATE AMRC_POLICY_NOT_FOUND           TO  20
EQUATE AMRC_SENDER_NOT_UNIQUE          TO  21
EQUATE AMRC_RECEIVER_NOT_UNIQUE        TO  22
EQUATE AMRC_PUBLISHER_NOT_UNIQUE       TO  23
EQUATE AMRC_SUBSCRIBER_NOT_UNIQUE      TO  24
EQUATE AMRC_MSG_NOT_UNIQUE             TO  25
EQUATE AMRC_POLICY_NOT_UNIQUE          TO  26
EQUATE AMRC_DIST_LIST_NOT_UNIQUE       TO  27

EQUATE AMRC_RECEIVE_BUFF_PTR_ERR       TO  28
EQUATE AMRC_RECEIVE_BUFF_LEN_ERR       TO  29
EQUATE AMRC_SEND_DATA_PTR_ERR          TO  30
EQUATE AMRC_SEND_DATA_LEN_ERR          TO  31

EQUATE AMRC_INVALID_IF_SERVICE_OPEN    TO  32
EQUATE AMRC_SERVICE_ALREADY_OPEN       TO  33
EQUATE AMRC_DATA_SOURCE_NOT_UNIQUE     TO  34

EQUATE AMRC_NO_MSG_AVAILABLE           TO  35
EQUATE AMRC_SESSION_ALREADY_OPEN       TO  36
EQUATE AMRC_SESSION_ALREADY_CLOSED     TO  37

EQUATE AMRC_ELEM_NOT_FOUND             TO  38
EQUATE AMRC_ELEM_COUNT_PTR_ERR         TO  39
EQUATE AMRC_ELEM_NAME_PTR_ERR          TO  40
EQUATE AMRC_ELEM_NAME_LEN_ERR          TO  41
EQUATE AMRC_ELEM_INDEX_ERR             TO  42
EQUATE AMRC_ELEM_PTR_ERR               TO  43
EQUATE AMRC_ELEM_STRUC_ERR             TO  44
EQUATE AMRC_ELEM_STRUC_NAME_ERR        TO  45
EQUATE AMRC_ELEM_STRUC_VALUE_ERR       TO  46
EQUATE AMRC_ELEM_STRUC_NAME_BUFF_ERR   TO  47
EQUATE AMRC_ELEM_STRUC_VALUE_BUFF_ERR  TO  48

EQUATE AMRC_TRANSPORT_ERR              TO  49
EQUATE AMRC_TRANSPORT_WARNING          TO  50

EQUATE AMRC_ENCODING_INCOMPLETE        TO  51
EQUATE AMRC_ENCODING_MIXED             TO  52
EQUATE AMRC_ENCODING_ERR               TO  53
EQUATE AMRC_BEGIN_INVALID              TO  54

EQUATE AMRC_NO_REPLY_TO_INFO           TO  55

EQUATE AMRC_SERVICE_ALREADY_CLOSED     TO  56
EQUATE AMRC_SESSION_NOT_OPEN           TO  57
EQUATE AMRC_DIST_LIST_INDEX_ERR        TO  58
EQUATE AMRC_WAIT_TIME_ERR              TO  59
EQUATE AMRC_SERVICE_NOT_OPEN           TO  60
EQUATE AMRC_HEADER_TRUNCATED           TO  61
EQUATE AMRC_HEADER_INVALID             TO  62
EQUATE AMRC_DATA_LEN_ERR               TO  63
EQUATE AMRC_BACKOUT_REQUEUE_ERR        TO  64
EQUATE AMRC_BACKOUT_LIMIT_ERR          TO  65
EQUATE AMRC_COMMAND_ALREADY_EXISTS     TO  66

EQUATE AMRC_UNEXPECTED_RECEIVE_ERR     TO  67
EQUATE AMRC_UNEXPECTED_SEND_ERR        TO  68


EQUATE AMRC_SENDER_USAGE_ERR           TO  70
EQUATE AMRC_MSG_TRUNCATED              TO  71
EQUATE AMRC_CLOSE_SESSION_ERR          TO  72

EQUATE AMRC_READ_OFFSET_ERR            TO  73
EQUATE AMRC_RFH_ALREADY_EXISTS         TO  74

EQUATE AMRC_GROUP_STATUS_ERR           TO  75

EQUATE AMRC_MSG_ID_LEN_ERR             TO  76
EQUATE AMRC_MSG_ID_PTR_ERR             TO  77

EQUATE AMRC_MSG_ID_BUFF_LEN_ERR        TO  78
EQUATE AMRC_MSG_ID_BUFF_PTR_ERR        TO  79
EQUATE AMRC_MSG_ID_LEN_PTR_ERR         TO  80
EQUATE AMRC_CORREL_ID_LEN_ERR          TO  81
EQUATE AMRC_CORREL_ID_PTR_ERR          TO  82
EQUATE AMRC_CORREL_ID_BUFF_LEN_ERR     TO  83
EQUATE AMRC_CORREL_ID_BUFF_PTR_ERR     TO  84
EQUATE AMRC_CORREL_ID_LEN_PTR_ERR      TO  85
EQUATE AMRC_FORMAT_LEN_ERR             TO  86
EQUATE AMRC_FORMAT_PTR_ERR             TO  87
EQUATE AMRC_FORMAT_BUFF_PTR_ERR        TO  88
EQUATE AMRC_FORMAT_LEN_PTR_ERR         TO  89
EQUATE AMRC_FORMAT_BUFF_LEN_ERR        TO  90

EQUATE AMRC_NAME_BUFF_PTR_ERR          TO  91
EQUATE AMRC_NAME_LEN_PTR_ERR           TO  92
EQUATE AMRC_NAME_BUFF_LEN_ERR          TO  93
EQUATE AMRC_Q_NAME_LEN_ERR             TO  94
EQUATE AMRC_Q_NAME_PTR_ERR             TO  95
EQUATE AMRC_Q_NAME_BUFF_PTR_ERR        TO  96
EQUATE AMRC_Q_NAME_LEN_PTR_ERR         TO  97
EQUATE AMRC_Q_NAME_BUFF_LEN_ERR        TO  98
EQUATE AMRC_WAIT_TIME_PTR_ERR          TO  99
EQUATE AMRC_CCSID_PTR_ERR              TO 100
EQUATE AMRC_ENCODING_PTR_ERR           TO 101
EQUATE AMRC_DEFN_TYPE_PTR_ERR          TO 102
EQUATE AMRC_CCSID_ERR                  TO 103
EQUATE AMRC_DATA_LEN_PTR_ERR           TO 104

EQUATE AMRC_GROUP_STATUS_PTR_ERR       TO 105

EQUATE AMRC_DATA_OFFSET_PTR_ERR        TO 106
EQUATE AMRC_RESP_SENDER_HANDLE_ERR     TO 107
EQUATE AMRC_RESP_RECEIVER_HANDLE_ERR   TO 108

EQUATE AMRC_NOT_AUTHORIZED             TO 109
EQUATE AMRC_TRANSPORT_NOT_AVAILABLE    TO 110
EQUATE AMRC_BACKED_OUT                 TO 111
EQUATE AMRC_INCOMPLETE_GROUP           TO 112
EQUATE AMRC_SEND_DISABLED              TO 113
EQUATE AMRC_SERVICE_FULL               TO 114
EQUATE AMRC_NOT_CONVERTED              TO 115
EQUATE AMRC_RECEIVE_DISABLED           TO 116
EQUATE AMRC_GROUP_BACKOUT_LIMIT_ERR    TO 117

EQUATE AMRC_SENDER_COUNT_PTR_ERR       TO 118

EQUATE AMRC_MULTIPLE_REASONS           TO 119
EQUATE AMRC_NO_RESP_SERVICE            TO 120

EQUATE AMRC_DATA_PTR_ERR               TO 121
EQUATE AMRC_DATA_BUFF_LEN_ERR          TO 122
EQUATE AMRC_DATA_BUFF_PTR_ERR          TO 123
EQUATE AMRC_DEFN_TYPE_ERR              TO 124
EQUATE AMRC_BACKOUT_INVALID            TO 125
EQUATE AMRC_COMMIT_INVALID             TO 126
EQUATE AMRC_DATA_OFFSET_ERR            TO 127
EQUATE AMRC_FILE_SYSTEM_ERR            TO 128
EQUATE AMRC_FILE_ALREADY_EXISTS        TO 129

EQUATE AMRC_REPORT_CODE_PTR_ERR        TO 130
EQUATE AMRC_MSG_TYPE_PTR_ERR           TO 131

EQUATE AMRC_FILE_FORMAT_CONVERTED      TO 132
EQUATE AMRC_FILE_TRUNCATED             TO 133
EQUATE AMRC_FILE_NOT_FOUND             TO 134
EQUATE AMRC_NOT_A_FILE                 TO 135
EQUATE AMRC_FILE_NAME_LEN_ERR          TO 136
EQUATE AMRC_FILE_NAME_PTR_ERR          TO 137
EQUATE AMRC_RFH2_FORMAT_ERR            TO 138
EQUATE AMRC_CCSID_NOT_SUPPORTED        TO 139
EQUATE AMRC_FILE_MSG_FORMAT_ERR        TO 140
EQUATE AMRC_MSG_TYPE_NOT_REPORT        TO 141
EQUATE AMRC_ELEM_STRUC_TYPE_ERR        TO 142
EQUATE AMRC_ELEM_STRUC_TYPE_BUFF_ERR   TO 143
EQUATE AMRC_FILE_TRANSFER_INVALID      TO 144
EQUATE AMRC_FILE_NOT_WRITTEN           TO 145
EQUATE AMRC_FILE_FORMAT_NOT_SUPPORTED  TO 146
EQUATE AMRC_NEGATIVE_RECEIVE_BUFF_LEN  TO 147
EQUATE AMRC_LIBRARY_NOT_FOUND          TO 148
EQUATE AMRC_LIBRARY_FUNCTION_PTR_ERR   TO 149
EQUATE AMRC_LIBRARY_INV_POINT_ERR      TO 150
EQUATE AMRC_LIBRARY_DUP_FUNCTION       TO 151
EQUATE AMRC_POLICY_HANDLER_ERR         TO 152
EQUATE AMRC_POLICY_HANDLER_WARNING     TO 153
EQUATE AMRC_REPORT_CODE_ERR            TO 154

**********************************************************************
**                                                                   *
**  Reason codes returned exclusively by Extended C AMI functions    *
**                                                                   *
**********************************************************************

EQUATE AMRC_ACCEPT_DIRECT_ERR          TO 201
EQUATE AMRC_ACCEPT_DIRECT_PTR_ERR      TO 202
EQUATE AMRC_ACCEPT_TRUNCATED_ERR       TO 203
EQUATE AMRC_ACCEPT_TRUNCATED_PTR_ERR   TO 204
EQUATE AMRC_ANON_ERR                   TO 205
EQUATE AMRC_ANON_PTR_ERR               TO 206
EQUATE AMRC_APPL_GROUP_BUFF_LEN_ERR    TO 207
EQUATE AMRC_APPL_GROUP_BUFF_PTR_ERR    TO 208
EQUATE AMRC_APPL_GROUP_LEN_ERR         TO 209
EQUATE AMRC_APPL_GROUP_LEN_PTR_ERR     TO 210
EQUATE AMRC_APPL_GROUP_PTR_ERR         TO 211
EQUATE AMRC_BIND_ON_OPEN_ERR           TO 212
EQUATE AMRC_BIND_ON_OPEN_PTR_ERR       TO 213
EQUATE AMRC_CHL_NAME_BUFF_LEN_ERR      TO 214
EQUATE AMRC_CHL_NAME_BUFF_PTR_ERR      TO 215
EQUATE AMRC_CHL_NAME_LEN_ERR           TO 216
EQUATE AMRC_CHL_NAME_LEN_PTR_ERR       TO 217
EQUATE AMRC_CHL_NAME_PTR_ERR           TO 218
EQUATE AMRC_CLOSE_DELETE_ERR           TO 219
EQUATE AMRC_CLOSE_DELETE_PTR_ERR       TO 220
EQUATE AMRC_CONTEXT_ERR                TO 221
EQUATE AMRC_CONTEXT_PTR_ERR            TO 222
EQUATE AMRC_CONVERT_ERR                TO 223
EQUATE AMRC_CONVERT_PTR_ERR            TO 224
EQUATE AMRC_COUNT_ERR                  TO 225
EQUATE AMRC_COUNT_PTR_ERR              TO 226
EQUATE AMRC_CUST_PARM_BUFF_LEN_ERR     TO 227
EQUATE AMRC_CUST_PARM_BUFF_PTR_ERR     TO 228
EQUATE AMRC_CUST_PARM_LEN_ERR          TO 229
EQUATE AMRC_CUST_PARM_LEN_PTR_ERR      TO 230
EQUATE AMRC_CUST_PARM_PTR_ERR          TO 231
EQUATE AMRC_DLY_PERSISTENCE_ERR        TO 232
EQUATE AMRC_DLY_PERSISTENCE_PTR_ERR    TO 233
EQUATE AMRC_DST_SUPPORT_ERR            TO 234
EQUATE AMRC_DST_SUPPORT_PTR_ERR        TO 235
EQUATE AMRC_EXPIRY_ERR                 TO 236
EQUATE AMRC_EXPIRY_PTR_ERR             TO 237
EQUATE AMRC_FILE_DISP_ERR              TO 238
EQUATE AMRC_FILE_DISP_PTR_ERR          TO 239
EQUATE AMRC_FILE_RCD_LEN_ERR           TO 240
EQUATE AMRC_FILE_RCD_LEN_PTR_ERR       TO 241
EQUATE AMRC_GROUP_ID_BUFF_LEN_ERR      TO 242
EQUATE AMRC_GROUP_ID_BUFF_PTR_ERR      TO 243
EQUATE AMRC_GROUP_ID_LEN_ERR           TO 244
EQUATE AMRC_GROUP_ID_LEN_PTR_ERR       TO 245
EQUATE AMRC_GROUP_ID_PTR_ERR           TO 246
EQUATE AMRC_HANDLE_POISON_MSG_ERR      TO 247
EQUATE AMRC_HANDLE_POISON_MSG_PTR_ERR  TO 248
EQUATE AMRC_HANDLE_PTR_ERR             TO 249
EQUATE AMRC_IMPL_OPEN_ERR              TO 250
EQUATE AMRC_IMPL_OPEN_PTR_ERR          TO 251
EQUATE AMRC_INFORM_IF_RET_ERR          TO 252
EQUATE AMRC_INFORM_IF_RET_PTR_ERR      TO 253
EQUATE AMRC_INTERVAL_ERR               TO 254
EQUATE AMRC_INTERVAL_PTR_ERR           TO 255
EQUATE AMRC_LEAVE_OPEN_ERR             TO 256
EQUATE AMRC_LEAVE_OPEN_PTR_ERR         TO 257
EQUATE AMRC_LOCAL_ERR                  TO 258
EQUATE AMRC_LOCAL_PTR_ERR              TO 259
EQUATE AMRC_MCD_PARM_BUFF_LEN_ERR      TO 260
EQUATE AMRC_MCD_PARM_BUFF_PTR_ERR      TO 261
EQUATE AMRC_MCD_PARM_LEN_ERR           TO 262
EQUATE AMRC_MCD_PARM_LEN_PTR_ERR       TO 263
EQUATE AMRC_MCD_PARM_PTR_ERR           TO 264
EQUATE AMRC_MGR_NAME_BUFF_LEN_ERR      TO 265
EQUATE AMRC_MGR_NAME_BUFF_PTR_ERR      TO 266
EQUATE AMRC_MGR_NAME_LEN_ERR           TO 267
EQUATE AMRC_MGR_NAME_LEN_PTR_ERR       TO 268
EQUATE AMRC_MGR_NAME_PTR_ERR           TO 269
EQUATE AMRC_MSG_LEN_ERR                TO 270
EQUATE AMRC_MSG_LEN_PTR_ERR            TO 271
EQUATE AMRC_MSG_TYPE_ERR               TO 272
EQUATE AMRC_NEW_CORREL_ID_ERR          TO 273
EQUATE AMRC_NEW_CORREL_ID_PTR_ERR      TO 274
EQUATE AMRC_NEW_PUBS_ONLY_ERR          TO 275
EQUATE AMRC_NEW_PUBS_ONLY_PTR_ERR      TO 276
EQUATE AMRC_PERSISTENCE_ERR            TO 277
EQUATE AMRC_PERSISTENCE_PTR_ERR        TO 278
EQUATE AMRC_PRIORITY_ERR               TO 279
EQUATE AMRC_PRIORITY_PTR_ERR           TO 280
EQUATE AMRC_PUB_ON_REQ_ERR             TO 281
EQUATE AMRC_PUB_ON_REQ_PTR_ERR         TO 282
EQUATE AMRC_PUB_OTHERS_ONLY_ERR        TO 283
EQUATE AMRC_PUB_OTHERS_ONLY_PTR_ERR    TO 284
EQUATE AMRC_READ_ONLY_ERR              TO 285
EQUATE AMRC_READ_ONLY_PTR_ERR          TO 286
EQUATE AMRC_REMOVE_ALL_ERR             TO 287
EQUATE AMRC_REMOVE_ALL_PTR_ERR         TO 288
EQUATE AMRC_REPORT_OPTION_ERR          TO 289
EQUATE AMRC_REPORT_OPTION_PTR_ERR      TO 290
EQUATE AMRC_RETAIN_ERR                 TO 291
EQUATE AMRC_RETAIN_PTR_ERR             TO 292
EQUATE AMRC_SEGMENT_ERR                TO 293
EQUATE AMRC_SEGMENT_PTR_ERR            TO 294
EQUATE AMRC_SEQ_NO_ERR                 TO 295
EQUATE AMRC_SEQ_NO_PTR_ERR             TO 296
EQUATE AMRC_SET_NAME_INVALID           TO 297
EQUATE AMRC_SHARED_ERR                 TO 298
EQUATE AMRC_SHARED_PTR_ERR             TO 299
EQUATE AMRC_SND_TYPE_ERR               TO 300
EQUATE AMRC_SND_TYPE_PTR_ERR           TO 301
EQUATE AMRC_SRV_TYPE_ERR               TO 302
EQUATE AMRC_SRV_TYPE_PTR_ERR           TO 303
EQUATE AMRC_SPLIT_LOGICAL_ERR          TO 304
EQUATE AMRC_SPLIT_LOGICAL_PTR_ERR      TO 305
EQUATE AMRC_SUBS_POINT_BUFF_LEN_ERR    TO 306
EQUATE AMRC_SUBS_POINT_BUFF_PTR_ERR    TO 307
EQUATE AMRC_SUBS_POINT_LEN_ERR         TO 308
EQUATE AMRC_SUBS_POINT_LEN_PTR_ERR     TO 309
EQUATE AMRC_SUBS_POINT_PTR_ERR         TO 310
EQUATE AMRC_SUPPRESS_REG_ERR           TO 311
EQUATE AMRC_SUPPRESS_REG_PTR_ERR       TO 312
EQUATE AMRC_SYNCPOINT_ERR              TO 313
EQUATE AMRC_SYNCPOINT_PTR_ERR          TO 314
EQUATE AMRC_TCP_ADDR_BUFF_LEN_ERR      TO 315
EQUATE AMRC_TCP_ADDR_BUFF_PTR_ERR      TO 316
EQUATE AMRC_TCP_ADDR_LEN_ERR           TO 317
EQUATE AMRC_TCP_ADDR_LEN_PTR_ERR       TO 318
EQUATE AMRC_TCP_ADDR_PTR_ERR           TO 319
EQUATE AMRC_TRP_TYPE_ERR               TO 320
EQUATE AMRC_TRP_TYPE_PTR_ERR           TO 321
EQUATE AMRC_TRUSTED_ERR                TO 322
EQUATE AMRC_TRUSTED_PTR_ERR            TO 323
EQUATE AMRC_USE_CORREL_ID_ERR          TO 324
EQUATE AMRC_USE_CORREL_ID_PTR_ERR      TO 325
EQUATE AMRC_WAIT_WHOLE_GROUP_ERR       TO 326
EQUATE AMRC_WAIT_WHOLE_GROUP_PTR_ERR   TO 327
EQUATE AMRC_CON_INT_PROP_ID_ERR        TO 328
EQUATE AMRC_CON_STR_PROP_ID_ERR        TO 329
EQUATE AMRC_MSG_INT_PROP_ID_ERR        TO 330
EQUATE AMRC_MSG_STR_PROP_ID_ERR        TO 331
EQUATE AMRC_POLICY_INT_PROP_ID_ERR     TO 332
EQUATE AMRC_POLICY_STR_PROP_ID_ERR     TO 333
EQUATE AMRC_SRV_INT_PROP_ID_ERR        TO 334
EQUATE AMRC_SRV_STR_PROP_ID_ERR        TO 335
EQUATE AMRC_INVALID_IF_CON_OPEN        TO 336
EQUATE AMRC_CON_HANDLE_ERR             TO 337

EQUATE AMRC_INVALID_TRACE_LEVEL        TO 400
EQUATE AMRC_CONN_NAME_NOT_FOUND        TO 401
EQUATE AMRC_HOST_FILE_NOT_FOUND        TO 402
EQUATE AMRC_HOST_FILENAME_ERR          TO 403
EQUATE AMRC_HOST_FILE_ERR              TO 404

EQUATE AMRC_POLICY_NOT_IN_REPOS        TO 405
EQUATE AMRC_SENDER_NOT_IN_REPOS        TO 406
EQUATE AMRC_RECEIVER_NOT_IN_REPOS      TO 407
EQUATE AMRC_DIST_LIST_NOT_IN_REPOS     TO 408
EQUATE AMRC_PUBLISHER_NOT_IN_REPOS     TO 409
EQUATE AMRC_SUBSCRIBER_NOT_IN_REPOS    TO 410
EQUATE AMRC_RESERVED_NAME_IN_REPOS     TO 411


EQUATE AMRC_REPOS_FILENAME_ERR         TO 414
EQUATE AMRC_REPOS_WARNING              TO 415
EQUATE AMRC_REPOS_ERR                  TO 416


EQUATE AMRC_REPOS_NOT_FOUND            TO 418
EQUATE AMRC_TRANSPORT_LIBRARY_ERR      TO 419

EQUATE AMRC_HOST_CACHE_ERR             TO 420
EQUATE AMRC_REPOS_CACHE_ERR            TO 421
EQUATE AMRC_PRIMARY_HANDLE_ERR         TO 422

EQUATE AMRC_SESSION_EXPIRED            TO 423
EQUATE AMRC_DTD_NOT_FOUND              TO 424
EQUATE AMRC_LDAP_ERR                   TO 425


**********************************************************************
**  AMELEM structure and related values                              *
**********************************************************************

** Structure Identifier *
EQUATE AMELEM_STRUC_ID TO  "ELEM    "

** Structure Version Number *
EQUATE AMELEM_VERSION_1        TO 1
EQUATE AMELEM_CURRENT_VERSION  TO AMELEM_VERSION_1

EQUATE AMELEM_DEFAULT TO AMELEM_STRUC_ID:@VM:AMELEM_VERSION_1:@VM:0:@VM:0:@VM:'':@VM:0:@VM:0:@VM:'':@VM:0:@VM:0:@VM:'':@VM:0:@VM:0:@VM:''


**********************************************************************
**  U2/AMI Option Codes                                               *
**********************************************************************
EQUATE U2AMI_RECEIVEMSG     TO 0 ;* Retrieve msg and msg len 
EQUATE U2AMI_LEAVEMSG       TO 1 ;* Leave msg on queue but get msg len
EQUATE U2AMI_DISCARDMSG     TO 2 ;* Retrieve msg and discard it
EQUATE U2AMI_RESIZEBUFFER   TO 3 ;* Allow U2 to handle msg buffers

**********************************************************************
**  U2/AMI Error Codes                                               *
**********************************************************************

EQUATE U2AMI_ERR_BASE            TO 100 ;* Start of the U2/AMI error codes

EQUATE U2AMI_ERR_MQUNAVAILABLE   TO 100 ;* MQ AMI libraries not available      
EQUATE U2AMI_ERR_UNKNOWN         TO 101 ;* Unknown error                       
EQUATE U2AMI_ERR_NOBINDIR        TO 102 ;* uvbin/udtbin env variable not found 
EQUATE U2AMI_ERR_FORK            TO 103 ;* Error during exec of ami process    
EQUATE U2AMI_ERR_PIPECREATE      TO 104 ;* Error creating pipes to ami process 
EQUATE U2AMI_ERR_PIPEWRITETOAMI  TO 105 ;* Error writing pipe to ami process   
EQUATE U2AMI_ERR_PIPEREADFROMAMI TO 106 ;* Error reading pipe from ami process 
EQUATE U2AMI_ERR_PIPEWRITETOU2   TO 107 ;* Error writing pipe to u2 process   
EQUATE U2AMI_ERR_PIPEREADFROMU2  TO 108 ;* Error reading pipe from u2 process 
EQUATE U2AMI_ERR_EXEC            TO 109 ;* Error during exec of ami process    
EQUATE U2AMI_ERR_INVALIDFORMAT   TO 110 ;* Variable does not match req'd format
EQUATE U2AMI_ERR_NOT_HANDLE      TO 111 ;* Variable not of type MQShandle      
EQUATE U2AMI_ERR_NULL_HANDLE     TO 112 ;* Uninitialized handle                
EQUATE U2AMI_ERR_INVALID_HANDLE  TO 113 ;* Handle has been closed w/amTerminate
EQUATE U2AMI_ERR_UNKNOWN_HANDLE  TO 114 ;* Unexpected handle value reported    
EQUATE U2AMI_ERR_SESSION_IN_USE  TO 115 ;* An active AMI session already exists
EQUATE U2AMI_ERR_CREATE_HANDLE   TO 116 ;* Error creating U2/MQS Session Handle
EQUATE U2AMI_ERR_DL_OPEN         TO 117 ;* Error opening MQ AMI library
EQUATE U2AMI_ERR_DL_FUNC         TO 118 ;* Error calling func in MQ AMI library
EQUATE U2AMI_ERR_RCVMSGOPTS      TO 119 ;* Invalid receive-message option

