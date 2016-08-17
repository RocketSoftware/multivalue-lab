@ECHO OFF
:cls
::::::::::::::::::::::::::::::::::
:
: Rocket Software Confidential
: OCO Source Materials
: Copyright (C) Rocket Software. 2009, 2010, 2011, 2012, 2013
: 
:
: @(:) $0 : script for converting a microsoft pfx file to pkcs#8 
:           for a U2 DB system
:	by : Nik Kesic
:	   : U2 Support Denver - USA
: Synopsis:
:
:     pfxconv1 
:
:         for Windows 2008, 7, - 64 bit
:           
:
:
::::::::::::::::::::::::::::::::::
:
cls
:
echo. +++++++++++++++++++++++++++++++++++++++
echo.  PFX (PKCS#12) to PEM PKCS#8 Converter
echo. +++++++++++++++++++++++++++++++++++++++
echo.      
:
set /p INP1=Enter name of the PFX file :  
IF  NOT (%INP1%)==() (
set pfxfile=%INPUT%
) ELSE (
echo. " bad input"
)
set /p INP2=Enter new name for the server root certificate :  
IF  NOT (%INP2%)==() (
set rootfile=%INP2%
) ELSE (
echo. " bad input"
)
set /p INP3=Enter pfx private key password :  
IF  NOT (%INP3%)==() (
set my_passwd=%INP3%
) ELSE (
echo. " bad input"
)
echo.
pause
::for /f "delims=" %%i in ('openssl pkcs12 -in %INP1% -clcerts -nokeys -out %INP2%.cer') do set my_passwd=%%i
        
        openssl pkcs12 -in %INP1% -clcerts -nokeys -out %INP2%.cer -passin pass:%my_passwd%
	openssl pkcs12 -in %INP1% -nocerts -nodes -out %INP2%-pkcs7wh.pvt -passin pass:%my_passwd%
	openssl rsa -in %INP2%-pkcs7wh.pvt -out %INP2%-pkcs7.pvt
	openssl pkcs12 -in %INP1% -out %INP2%CA.cer -nodes -nokeys -cacerts -passin pass:%my_passwd%
echo.
	openssl.exe pkcs8 -v1 PBE-SHA1-3DES -topk8 -in %INP2%-pkcs7.pvt -out %INP2%-pkcs8.pvt -passout pass:%my_passwd%
	openssl x509 -in %INP2%.cer > %INP2%conv.cer
:
:
call :deleteIfEmpty %INP2%CA.cer
exit /b
:
:deleteIfEmpty
if %~z1 == 0 (echo CA certificate cannot be found.
echo.
del %1
)else (openssl x509 -in %INP2%CA.cer > %INP2%CAconv.cer
)
::exit /b
:        
del %INP2%-pkcs7wh.pvt %INP2%-pkcs7.pvt %INP2%.cer %INP2%CA.cer
ren %INP2%conv.cer %INP2%.cer
if exist %INP2%CAconv.cer (
ren %INP2%CAconv.cer %INP2%CA.cer
)
set my_passwd=
:
echo.The following files were extracted:
echo.================================================================
echo.
dir /B %INP2%*
set INP1=
set INP2=
set INP3=
echo.
SET /P M= Any key to exit : 
IF %M%== GOTO EOF
:EOF
exit
