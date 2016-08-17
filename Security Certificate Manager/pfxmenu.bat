::::::::::::::::::::::::::::::::::
:
: Rocket Software Confidential
: OCO Source Materials
: Copyright (C) Rocket Software. 2015
: 
:
: @(:) $0 : certificate converter menu 
:           for a U2 DB system
:	by : Nik Kesic
:	   : U2 Support Denver - USA
: Synopsis:
:
:     pfxmenu
:
:         for Windows 2008, 7, - 64 bit
:           
:
:
::::::::::::::::::::::::::::::::::
@ECHO OFF
CLS
set PFXTOOL_VERSION=2.03
:MENU
ECHO.
ECHO.      ......................................................
ECHO.      .    Rocket Software Security Certificate Manager    .
ECHO.      ......................................................
ECHO.      .                                                    .
ECHO.      .  1 - PFX (PKCS#12) to PEM PKCS#8 Converter         .
ECHO.      .  2 - PFX Certificate Store Converter               .
ECHO.      .  3 - PEM Server Certificate and Private Key to PFX .
ECHO.      .  4 - PFX Import into NEW/OLD Java Key Store        .
ECHO.      .  5 - Create CSR and Self-Signed Certificate        .
ECHO.      .  6 - View PFX File Contents                        .
ECHO.      .  7 - PEM Chain Certificates and Private Key to PFX .
ECHO.      .  8 - SSL Test Client                               .
ECHO.      .  9 - SSL Test Server                               .
ECHO.      . 10 - View Java Keystore Contents                   .
ECHO.      .  v - PFXTOOL Version                               .
ECHO.      .  ? - Help README                                   .
ECHO.      .  Q - EXIT                                          .
ECHO.      ......................................................
ECHO.
:
SET /P M=Select task: 
IF %M%==1 GOTO pfxconv1
IF %M%==2 GOTO pfxconv2
IF %M%==3 GOTO pfxconv3
IF %M%==4 GOTO pfxconv4
IF %M%==5 GOTO pfxconv5
IF %M%==6 GOTO pfxconv6
IF %M%==7 GOTO pfxconv7
IF %M%==8 GOTO pfxconv8
IF %M%==9 GOTO pfxconv9
IF %M%==10 GOTO pfxconv10
IF %M%==v GOTO pfxtoolver
IF %M%==V GOTO pfxtoolver
IF %M%==? GOTO pfxhelp
IF %M%==h GOTO pfxhelp
IF %M%==H GOTO pfxhelp
IF %M%==Q GOTO EOF
IF %M%==q GOTO EOF
:
:pfxconv1
start pfxconv1.bat
CLS
GOTO MENU
:pfxconv2
start pfxconv2.bat
CLS
GOTO MENU
:pfxconv3
start pfxconv3.bat
CLS
GOTO MENU
:pfxconv4
start pfxconv4.bat
CLS
GOTO MENU
:pfxconv5
start pfxconv5.bat
CLS
GOTO MENU
:pfxconv6
start pfxconv6.bat
CLS
GOTO MENU
:pfxconv7
start pfxconv7.bat
CLS
GOTO MENU
:pfxconv8
start pfxconv8.bat
CLS
GOTO MENU
:pfxconv9
start pfxconv9.bat
CLS
GOTO MENU
:pfxconv10
start pfxconv10.bat
CLS
GOTO MENU
:pfxhelp
start pfxhelp.bat
CLS
GOTO MENU
:
:pfxtoolver
   echo PFX PEM tool version is %PFXTOOL_VERSION%
set /p DUMMY=Hit ENTER to continue...
CLS
GOTO MENU
:
:EOF
