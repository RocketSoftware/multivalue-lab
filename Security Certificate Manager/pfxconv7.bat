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
:     pfxconv7
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
echo. +++++++++++++++++++++++++++++++++++++++++++++++
echo.  PEM Chain Certificates and Private Key to PFX
echo. +++++++++++++++++++++++++++++++++++++++++++++++
echo.      
:
if exist certChain.cer (ren certchain.cer certChain.cer)
set INPUT="no entry"
:
set /p INP1=Enter name of the PEM Certificate file :  
IF  NOT (%INP1%)==() (
set pfxfile=%INPUT%
) ELSE (
echo " bad input"
)
set /p INP2=Enter name of the Private Key file :  
IF  NOT (%INP2%)==() (
set pfxfile=%INPUT%
) ELSE (
echo " bad input"
)
set /p numc=How Many Intermediate Certificates : 
FOR /L %%G IN (1,1,%numc%) DO set /p neddy=Enter name of the intermediate file %%G : & type %neddy% >>certChain.cer & echo. >>certChain.cer 
:
set /p INP5=Enter name of the CAfile file :  
IF  !%1==! (
set pfxfile=%INPUT%
) ELSE (
echo " bad input"
)
set /p INP6=Enter name for the PFX file :  
IF  !%1==! (
set pfxfile=%INPUT%
) ELSE (
echo " bad input"
)
type %INP5% >>certChain.cer
:
openssl pkcs12 -export -in %INP1% -certfile certChain.cer -inkey %INP2% -out %INP6% 
:
echo.
dir /B %INP6%*
SET /P M= Any key to exit : 
IF %M%== GOTO EOF
:EOF
::::exit
