::::::::::::::::::::::::::::::::::
:
: Rocket Software Confidential
: OCO Source Materials
: Copyright (C) Rocket Software. 2009, 2010, 2011, 2012, 2013
: 
:
: @(:) $0 : script for converting pkcs#8 cert and pvtkey to pfx file
:           for a U2 DB system
:	by : Nik Kesic
:	   : U2 Support Denver - USA
: Synopsis:
:
:     pfxconv8
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
echo.  SSL Test Client
echo. +++++++++++++++++
echo.      
:
if exist certChain.cer (ren certchain.cer certChain.cer)
set INPUT=""
:
set /p INP1=Enter name of secure server :  
IF  NOT (%INP1%)==() (
set pfxfile=%INPUT%
) ELSE (
echo " bad input"
)
set /p INP2=Enter port of secure server :  
IF  (%INP2%)==() (
set INP2=4433
)
echo %INP2%
rem ELSE (
rem echo " bad input"
rem )
set /p INP3=Enter path of CA and intermediate certificates :  
rem IF  NOT (%INP3%)==() (
rem set INP3=c:\certs
rem ) ELSE (
rem echo " bad input"
rem )
set /p INP4=Enter any other options or "<cr>" :  
rem IF  (%INP4%)==() (
rem set INP4=%INPUT%
rem ) ELSE (
rem echo " bad input"
rem )

echo openssl s_client -connect %INP1%:%INP2% -showcerts -CApath %INP3% %INP4%
openssl s_client -connect %INP1%:%INP2% -showcerts -CApath %INP3% %INP4%

echo.
::dir /B %INP6%*
SET /P M= Any key to exit : 
::IF %M%== GOTO EOF
:EOF
exit
