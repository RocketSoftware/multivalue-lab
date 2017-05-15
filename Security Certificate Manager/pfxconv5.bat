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
:     pfxconv05
:
:         for Windows 2008, 7, - 64 bit
:           
:
:
::::::::::::::::::::::::::::::::::
:
cls
:
set OPENSSL_CONF=c:\OpenSSL-Win32\openssl.cnf
:
echo. ++++++++++++++++++++++++++++++++++++++++
echo.  Create CSR and Self-Signed Certificate
echo. ++++++++++++++++++++++++++++++++++++++++
echo.      
:
rem set pfxfile=mytest
::
set /p INPUT=Enter name and path of the CSR file : 
IF  NOT (%INPUT%)==() (
set pfxfile=%INPUT%
) ELSE (
echo "bad input"
)
openssl genrsa -out %pfxfile%.rsa 2048 
openssl rsa -in %pfxfile%.rsa -pubout > %pfxfile%.pub
rem set country=US
set /p INP3=Country Name (2 letter code) [US]:  
IF  NOT (%INP3%)==() (
set country=%INP3%
) ELSE (
echo. " bad input"
)
rem set state=Colorado
set /p INP4=State or Province Name (full name) [Some-State]: 
IF  NOT (%INP4%)==() (
set state=%INP4%
) ELSE (
echo. " bad input"
)
rem set city=Denver
set /p INP5=Locality Name (eg, city) []:  
IF  NOT (%INP5%)==() (
set city=%INP5%
) ELSE (
echo. " bad input"
)
rem set "orgname=Rocket Software, Inc."
set /p INP6=Organization Name (eg, company) [Internet Widgits Pty Ltd]:  
IF  NOT "%INP6%"==() (
set "orgname=%INP6%"
) ELSE (
echo. " bad input"
)
rem set "unit=U2"
set /p INP7=Organizational Unit Name (eg, section) []:  
IF  NOT "%INP7%"==() (
set "unit=%INP7%"
) ELSE (
echo. " bad input"
)
rem set domname=den-l-nk01.rocketsoftware.com
set /p INP8=Common Name (e.g. server FQDN or YOUR name) []:  
IF  NOT (%INP8%)==() (
set domname=%INP8%
) ELSE (
echo. " bad input"
)
rem set email=nkesic@rs.com
set /p INP9=Email Address []:
IF  NOT (%INP9%)==() (
set email=%INP9%
) ELSE (
echo. " bad input"
)
rem set algo=sha256
set /p INP12=Sha1 or sha2 type certificate (sha1/sha2):
IF  NOT (%INP12%)==() (
set algoIN=%INP12%
) ELSE (
echo. " bad input"
)
IF %algoIN%==sha2 (
set algo=sha256
) ELSE (
set algo=%INP12%
)
rem set age=365
set /p INP10=Certificate Age limit [365]:
IF  NOT %INP10%==() (
set age=%inp10%
) ELSE (
echo. " bad input"
)
echo.
pause
echo. 
echo Country = %country%
echo State = %state%
echo Locality = %city%
echo Organization = %orgname%
echo Organization Name = %unit%"
echo Common Name = %domname%
echo Email Adress = %email%
echo Algorithm = %algo%
echo.
:
echo 1
echo 2
echo.
   openssl.exe pkcs8 -v1 PBE-SHA1-3DES -topk8 -in %pfxfile%.rsa -out %pfxfile%-pkcs8.pvt 
	echo 3
:
::  openssl req -new -%algo% -digest sha1 -subj "/C=%country%/ST=%state%/L=%city%/O=%orgname%/CN=%domname%/emailAddress=%email%/OU=%unit%" -key %pfxfile%-pkcs8.pvt -out %pfxfile%.req
echo  openssl req -new -%algo% -subj "/C=%country%/ST=%state%/L=%city%/O=%orgname%/CN=%domname%/emailAddress=%email%/OU=%unit%" -key %pfxfile%-pkcs8.pvt -out %pfxfile%.req -passin pass:password
  openssl req -new -%algo% -subj "/C=%country%/ST=%state%/L=%city%/O=%orgname%/CN=%domname%/emailAddress=%email%/OU=%unit%" -key %pfxfile%-pkcs8.pvt -out %pfxfile%.req -passin pass:password
echo 4
   openssl req -text -noout -verify -in %pfxfile%.req
:
set /p INP11=Do you want to create a self-signed certificate [y/n]:
IF  %INP11%==y (
openssl x509 -%algo% -signkey %pfxfile%-pkcs8.pvt -in %pfxfile%.req -req -days %age% -out %pfxfile%.cer
echo 5
echo "Private Key and CSR and self-signed certificate created!"
) ELSE (
echo.The following files were created:
echo.================================================================
echo.
dir /B %pfxfile%*
goto END
)
:
echo.
:
echo.The following files were created:
echo.================================================================
echo.
dir /B %pfxfile%*
set INP1=
set INP2=
set INP3=
set INP4=
set INP5=
set INP6=
set INP7=
set INP8=
set INP9=
set INP10=
set INP11=
set country=
set state=
set city=
:END
:echo.
echo "Task Completed"
pause
exit