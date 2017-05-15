::::::::::::::::::::::::::::::::::
:
: Rocket Software Confidential
: OCO Source Materials
: Copyright (C) Rocket Software. 2009, 2010, 2011, 2012, 2013
: 
:
: @(:) $0 : MS exported certificate store pfx file to pkcs#8 file 
:           for a U2 DB system
:	by : Nik Kesic
:	   : U2 Support Denver - USA
: Synopsis:
:
:     pfxconv6
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
echo. ++++++++++++++++++++++++
echo.  View PFX File Contents
echo. ++++++++++++++++++++++++
echo.      
:
set /p INP1=Enter name of the PFX file :  
IF  NOT (%INP1%)==() (
set pfxfile=%INPUT%
) ELSE (
echo " bad input"
)
openssl pkcs12 -info -in %INP1% 
:
echo.
SET /P M= Any key to exit : 
IF %M%== GOTO EOF
:EOF
exit