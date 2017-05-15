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
:     pfxconv2
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
echo. +++++++++++++++++++++++++++++++++
echo.  PFX Certificate Store Converter
echo. +++++++++++++++++++++++++++++++++
echo.      
:
set /p INP1=Enter name of the PFX file :  
IF  NOT (%INP1%)==() (
set pfxfile=%INPUT%
) ELSE (
echo " bad input"
)
set /p INP2=Enter new name for the server root certificate :  
IF  NOT (%INP2%)==() (
set rootfile=%INP2%
) ELSE (
echo " bad input"
)
openssl pkcs12 -cacerts -in %INP1% -nodes -out %INP2%.crt
::openssl pkcs12 -cacerts -in %INP1% -nodes | openssl x509 >> %INP2%.crt
:: future extraction to remove headers
:: openssl x509 -in %INP2%.crt > %INP2%.cer
echo.
SET /P M= Any key to exit : 
IF %M%== GOTO EOF
:EOF
exit