Redis-API Demo
==============

A basic API for accessing Redis using U2 Basic. Place the files from INCLUDE into the INCLUDE directory of your account. The program files in BP_SOURCE can then be compiled.  

Please see INCLUDE redis.include for a list of the COMMON variables that are used by these subroutines.

Program listing
---------------

<dl>
<dt>redis.connect(ret, server, port, options)</dt>
<dd>This will connect you to a redis server using settings from the COMMON vars when passed in variables are empty</dd>
<dt>redis.disconnect(ret)</dt>
<dd>This will disconnect you from the redis serve</dd>
<dt>redis.generic(response, request)</dt>
<dd>This accepts a string command for Redis (e.g., try "SET myKey myData") and return the results using a U2 Dynamic Object</dd>
<dt>redis.get(result, key, retMsg)</dt>
<dd>Returns the value from a key</dd>
<dt>redis.set(result, key, value, retMsg)</dt>
<dd>Sets a key to the desire value</dd>
</dl>

For all subroutines with the argument 'result': 1 = success, 0 = redis returned an error, -1 = a network error, and -9 = not connected to Redis.  
