HMAC
====

HMAC (Hash-based Message Authentication Code)  
based on RFC-2104  

Sample code in UniVerse BASIC  
* Supports HMAC-MD5, HMAC-SHA1 and HMAC-SHA256  
* **NOTE:** SHA256 is available only in UV 11.2 and UD 7.4.


**For UniData 7.3.x or UniVerse 11.1.x and all previous versions:**
The following functions used in the sample must be put into a separate files, compiled and cataloged. This is because this sample program is written for the upcoming UniData 7.4 and UniVerse 11.2 releases.
Or, you can adapt it to be called inline by GOSUB.
* HMAC
* HMAC_DAN

HMAC.SPEED calls two different HMAC implementations and times the execution time.
It also uses RFC-2104 provided test vectors to verify the correctness.
 
As currently coded, the program runs 10,000 itrations for each test.

***

More on the HMAC algorithm:

RFC-2104 HMAC algorithm is

   ```HMAC(K,m) = H((K XOR opad) || H((K XOR ipad) || m))```  

Where:
* K is a secret key  
* m is the message to be authenticated  
* H is a hash algorithm such as md5, sha1, sha256 etc.  
* XOR bitwise exclusive-OR operation  
* || concatenation operation  
* opad is outer padding string 0x5c5c...  
* ipad is inner padding string 0x3636...  

Two different ways of doing XOR are implemented by the HMAC() function below.
The first (by $DEFINE USE_BITXOR) is to convert all pads/keys to literal binary strings
then perform XOR "bit by bit". The second (by $UNDEFINE USE_BITXOR) is to convert all
pads/key into literal hex strings, then convert 8 hex chars into one integer and
perform 32-bit integer XOR by calling BITXOR(), finally convert each partial result
back into literal hex strings. The second approach appeasrs more convoluted but much
more efficient.

A more elegant implementation shown below (HMAC_DAN) was written by Dan McGrath.
Benchmark shows that it is a little slower than HMAC() with BITXOR.

There should be other ways to implement HMAC(). implementations shown here are just
for examples.