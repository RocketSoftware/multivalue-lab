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
:     pfxconv3
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
echo.  PEM Server Certificate and Private Key to PFX
echo. +++++++++++++++++++++++++++++++++++++++++++++++
echo.      
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
set /p INP3=Enter name of the CAfile file :  
IF  !%1==! (
set INP3=%INP1%
) ELSE (
echo " bad input"
)
set /p INP4=Enter name for the PFX file :  
IF  NOT (%INP4%)==() (
set rootfile=%INP1%
) ELSE (
echo " bad input"
)
openssl pkcs12 -export -out %INP4% -inkey %INP2% -in %INP1% -cacerts -in %INP3% 
echo.
dir /B %INP4%*
SET /P M= Any key to exit : 
IF %M%== GOTO EOF
EOF
exit