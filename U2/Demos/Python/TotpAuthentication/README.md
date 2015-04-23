# TOTP Authentication

Unidata Basic utility for performing Time-based One-time Password Authentication with a mobile app such as Google Authenticator.

Requires Python modules: SpookyOTP and pillow

## Installation

Copy BP/* to Unidata BP file.

From Unidata

```
:BASIC BP TOTP.MAKE
:RUN BP TOTP.MAKE
```

Install Python Modules
* SpookyOYP (https://pypi.python.org/pypi/SpookyOTP / https://github.com/steveherrin/SpookyOTP)
* pillow (https://pypi.python.org/pypi/Pillow)

Windows example, from command prompt, assuming Python in default location

```
>CD /D %UDTHOME%\python\scripts
>pip install spookyotp pillow
```

## Usage

In UniBasic
CALL TOTP.TWO.FACTOR.AUTH(ACT,ISSUER,USERNAME,SECRET,PASS,RTN,ETXT)

1. Generate QRCODE image using 'Q' action and save SECRET against user
record. Path to image returned in RTN. You should delete the image after
using.
2. User scans QRCODE in Google Authenticator to set up account.
3. Validate OTP from Google Authenticator using 'V' option.

Pass ACT
* 'N': Get current password
* 'Q': Get QRCODE image (PASS = Optional Image Path, RTN = Image Path)
* 'U': Get URI (as encoded to QRCODE) RTN = URI
* 'V': Validate - PASS = OTP, RTN = 1 (Valid) or 0 (Invalid)

Pass ISSUER Company Name (eg CACI)

Pass USERNAME User ID (eg fred@caci.com)

Pass/Return SECRET 16 char base32 string (Generated if not passed)

Pass PASS Depends on action

Return RTN Depends on action

Return ETXT Non-null if error

## Test Program

From Unidata, run the included test program

```
:TOTP.TEST
```

This generates a new secret key and QR code.

Open the QR code image and scan on your phone using eg Google Authenticator.

Compare the code from Google Authenticator with that shown by the test program.
