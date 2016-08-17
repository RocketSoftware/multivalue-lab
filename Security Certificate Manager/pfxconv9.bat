::::::::::::::::::::::::::::::::::
:
: Rocket Software Confidential
: OCO Source Materials
: Copyright (C) Rocket Software. 2015
: 
:
: @(:) $0 : script for converting pkcs#8 cert and pvtkey to pfx file
:           for a U2 DB system
:	by : Nik Kesic
:	   : U2 Support Denver - USA
: Synopsis:
:
:     pfxconv9
:
:         for Windows 2008, 7, - 64 bit
:           
:
:
::::::::::::::::::::::::::::::::::
@ECHO OFF
:
cls
:
echo. +++++++++++++++++
echo.  SSL Test Server
echo. +++++++++++++++++
echo.      
:
set INPUT=""
:port
set /p INP2=Enter port of secure server :  

IF  (%INP2%)==() (
ECHO You did not enter port number!!
timeout 30
goto EOF
)
:

set /p INP3=Enter path and name of server certificate :  
IF  (%INP3%)==() (
ECHO You did not enter a certificate!!
timeout 30
goto EOF
)
set /p INP4=Enter path and name of private key :  
IF  (%INP4%)==() (
ECHO You did not enter a private key!!
timeout 30
goto EOF
)
set /p INP5=Enter any other options or "<cr>" :  
IF  (%INP5%)==() (
set INP5=%INPUT%
) ELSE (
echo " bad input"
)
echo openssl s_server -www -accept %INP2% -cert %INP3% -key %INP4% %INP5%
openssl s_server -accept %INP2% -cert %INP3% -key %INP4%


echo.
::dir /B %INP6%*
SET /P M= Any key to exit : 
::IF %M%== GOTO EOF
:EOF
exit
