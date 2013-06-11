Redis-API Demo
==============

A basic API for accessing Redis using U2 Basic. Place the files from INCLUDE into the INCLUDE directory of your account. The program files in BP_SOURCE can then be compiled.  

Please see INCLUDE redis.include for a list of the COMMON variables that are used by these subroutines.

Program listing
---------------

**redis.connect(ret, server, port, options)** - This will connect you to a redis server using settings from the COMMON vars when passed in variables are empty.  
**redis.disconnect(ret)** - This will disconnect you from the redis server  
**redis.generic** - This accepts a string command for Redis (e.g., try "SET myKey myData") and return the results using a U2 Dynamic Object.  
