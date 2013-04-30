*******************************************************************************
*
*       Program DECRYPT.EXAMPLE
*       Copyright Rocket Software, Rocket U2 (C) 2010    
*
*******************************************************************************
*
*  Author: Brian Kupzyk (bkupzyk@rs.com)
*  Created on: Sep 29, 2010 8:05:01 AM
*  Description: Example on how to decrypt the encrypted data in MEMBERS file
*
*****************************************************************************
 ENC.REC = "";REC.ID = "";DEBUG.FLAG = 0
 RUN.SENTENCE = @SENTENCE
 CRT "Encryption/Decryption Example" 
 GOSUB PARSE.COMMAND.LINE
 CRT "-----------------------------------------------------------------" 
 * Read Encryption details from dicitonary
 OPEN "DICT","MEMBERS" TO F.DICT.MEMBERS ELSE STOP "Open DICT MEMBERS Error!"
 READ ENC.REC FROM F.DICT.MEMBERS,"ENC.PARAMS" ELSE STOP "Unable to read ENC.PARAMS record from MEMBERS Dictionary."
 IF ENC.REC THEN
  * Salt and IV are not used
  ALGORITHM   = FIELD(ENC.REC<2>,"=",2)
  ENCRYPT.KEY = FIELD(ENC.REC<3>,"=",2)
  ACTION      = FIELD(ENC.REC<4>,"=",2)
  KEYACTION   = FIELD(ENC.REC<5>,"=",2)  
  DATALOC     = 1 ;* Data supplied as a string
  KEYLOC      = 1 ;* Key supplied as string
  RESULTLOC   = 1 ;* Return result as string
  EN.RESULT   = "" 
 END
 CLOSE F.DICT.MEMBERS
 
 * Change ACTION to decrypt option
 ORIG.ACTION = ACTION
 ACTION = 0
 BEGIN CASE
   CASE ORIG.ACTION = 1
     ACTION = 3
   CASE ORIG.ACTION = 2
     ACTION = 4
   CASE ORIG.ACTION = 5
     ACTION = 6
   CASE 1
      STOP "Error retrieving proper ACTION value."
 END CASE          
 
 PROMPT ""
 ANS = ""
 JUNK = @(0,0); * Fix for 'Press Any Key' 
 REC = "";RESULT="";MY.LOG="DECRYPT.LOG";LOGFILE=@PATH:"/BP/":MY.LOG
 IF REC.ID = "" THEN
  CRT "Input Member ID(0001-2500): ":;INPUT ANS
  IF ANS = "" THEN STOP "Exiting.."
 END ELSE
  IF DEBUG.FLAG THEN CRT "REC ID Entered: ":REC.ID
  ANS = REC.ID
 END

 IF DEBUG.FLAG THEN
  CRT "ALGORITHM: ":ALGORITHM 
  CRT "ENCRYPT.KEY: ":ENCRYPT.KEY
  CRT "ORIG.ACTION: ":ORIG.ACTION
  CRT "ACTION: ":ACTION
  CRT "KEYACTION: ":KEYACTION        
 END 
  
 OPEN "","MEMBERS" TO F.MEMBERS ELSE STOP "Open MEMBERS Error!"
 READ REC FROM F.MEMBERS,ANS ELSE STOP "Read error on MEMBERS file, ID: ":ANS
  
 CRT "Record ID: ":ANS:"   Name: ":REC<2>:" ":REC<1>
 CRT "Clear Text Password: ":REC<14> 
 CRT " Encrypted Password: ":REC<15>
 DECRYPT.STRING="";ENCRYPT.STRING=""
   EN.RESULT = ENCRYPT(ALGORITHM,ACTION,REC<15>,DATALOC,ENCRYPT.KEY,KEYLOC,KEYACTION,'','',DECRYPT.STRING,RESULTLOC)   
     IF EN.RESULT = 0 THEN
       CRT " Decrypted Password: ":DECRYPT.STRING
      END ELSE    
       STOP "DECRYPT Function Error on Password Field: ":EN.RESULT
     END   
 CRT "-----------------------------------------------------------------"   
 * Credit Card
 FOR C = 1 TO DCOUNT(REC<19>,@VM)     
   CRT "Clear Text Credit Card #":C:": ":REC<18,C>
   CRT " Encrypted Credit Card #":C:": ":REC<19,C>   
   DECRYPT.STRING="";ENCRYPT.STRING=""
   EN.RESULT = ENCRYPT(ALGORITHM,ACTION,REC<19,C>,DATALOC,ENCRYPT.KEY,KEYLOC,KEYACTION,'','',DECRYPT.STRING,RESULTLOC)   
     IF EN.RESULT = 0 THEN
       CRT " Decrypted Credit Card #":C:": ":DECRYPT.STRING
       CRT "--------------------------------------------"
      END ELSE    
       STOP "DECRYPT Function Error on Credit Card Field: ":EN.RESULT
     END  
  NEXT C             
 CRT "End of Program!"
 STOP
 
 PARSE.COMMAND.LINE:
* Check Command line options
CONVERT " " TO @FM IN RUN.SENTENCE
* RUN U2BP PROGNAME CLO1 (4th) or PROGNAME CLO1 (2nd)
IF UPCASE(RUN.SENTENCE<1>) = "RUN" THEN START.POSITION = 4 ELSE START.POSITION = 2
CLO.SENTENCE = ""; * Short for Command Line Options
PROCESS.TYPE = ""
FOR X = START.POSITION TO DCOUNT(RUN.SENTENCE, @FM)
  CLO.SENTENCE<-1> = RUN.SENTENCE<X>
NEXT X
* Now parse through CLOs to get parameters for program
CHECK.NEXT.OPTION = 1
FILES.TO.PROCESS = ""; * Clear first
IF CLO.SENTENCE # "" THEN CRT "Validating Command Line Options..."
FOR X = 1 TO DCOUNT(CLO.SENTENCE, @FM)
  MY.PARAM = CLO.SENTENCE<X>
  MY.PARAM2 = CLO.SENTENCE<X+1>
  IF CHECK.NEXT.OPTION THEN 
    BEGIN CASE
      * Command line otions  
     CASE UPCASE(MY.PARAM) = "-DEBUG"
       DEBUG.FLAG = 1  
       CHECK.NEXT.OPTION = 1           
     CASE UPCASE(MY.PARAM) = "-N"
       IF NUM(MY.PARAM2) THEN
          REC.ID = MY.PARAM2
         END ELSE
          CRT "Record count parameter must be numeric, skipping."
       END  
       CHECK.NEXT.OPTION = 0                                                       
      CASE 1  
        * Do Nothing
    END CASE
   END ELSE
    * Option was taken care of in last loop
    CHECK.NEXT.OPTION = 1
  END
NEXT X
RETURN
