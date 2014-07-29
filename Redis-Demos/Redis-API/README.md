Redis-API Demo
==============

A basic API for accessing Redis using U2 Basic. Place the files from INCLUDE into the INCLUDE directory of your account. The program files in BP_SOURCE can then be compiled.  For UniVerse, you will need to change $INCLUDE INCLUDE to $INCLUDE UNIVERSE.INCLUDE.

Please see INCLUDE redis.include for a list of the COMMON variables that are used by these subroutines.

Program listing for BP_SOURCE
---------------

<dl>
<dt>UDOEXTRACT(result, handle, target, option)</dt>
<dd>Some of the redis examples use UDO to pass data around. This is just a helper subroutine</dd>
<dt>redis.connect(ret, server, port, options)</dt>
<dd>This will connect you to a redis server using settings from the COMMON vars when passed in variables are empty</dd>
<dt>redis.del(result, keys, retMsg)</dt>
<dd>Delete a single key from redis</dd>
<dt>redis.disconnect(ret)</dt>
<dd>This will disconnect you from the redis server</dd>
<dt>redis.generic(response, request)</dt>
<dd>This accepts a string command for Redis (e.g., try "SET myKey myData") and return the results using a U2 Dynamic Object</dd>
<dt>redis.get(result, key, retMsg)</dt>
<dd>Returns the value from a key</dd>
<dt>redis.sadd(result, key, value, retMsg)</dt>
<dd>Add a value to a set in redis</dd>
<dt>redis.scard(result, key, retMsg)</dt>
<dd>Returns the cardinality of a set in redis</dd>
<dt>redis.set(result, key, value, retMsg)</dt>
<dd>Sets a key to the desire value</dd>
</dl>

For all subroutines with the argument 'result': 1 = success, 0 = redis returned an error, -1 = a network error, and -9 = not connected to Redis.  


Program listing for ALT_SOURCE
---------------
<dl>
<dt>SDELETE.LIST listname</dt>
<dd>Delete a saved list from Redis. Equivalent to the DELETE.LIST command</dd>

<dt>SGET.LIST listname</dt>
<dd>Retreive a saved list from Redis and make it active. Equivalent to the GET.LIST command</dd>
<dt>SMERGE.LIST list1 {DIFF | INTERSECTION | UNION} list2 [TO list3]</dt>
<dd>Merge 2 saved lists stored in Redis</dd>
</dl>
