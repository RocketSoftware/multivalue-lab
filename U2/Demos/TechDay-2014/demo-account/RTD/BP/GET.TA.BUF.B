subroutine GET.TA.BUF.B(min.char,max.char,delay.interval,delay.total,str)
******************************************************************************
*
*	Routine to read characters from terminal
*
*	Module	%M%	Version	%I% 	Date	%H%
*
*	(c) Copyright 1998 Ardent Software Inc. - All Rights Reserved
*	This is unpublished proprietary source code of Ardent Software Inc.
*	The copyright notice above does not evidence any actual or intended
*	publication of such source code.
*
*******************************************************************************
*
*	Maintenence log - insert most recent change descriptions at top
*
*	Date.... GTAR# WHO Description........................................
*	10/14/98 23801 SAP Change copyrights. 
*	08/18/96 18335 PNV Added code to port 9 to Siemens Nixdorf.
*	05/13/91 8345  DTM Changed print to tprint
*   11/19/90 7746  DTM Fixed bug in carriage return handling for UCB systems
*   08/13/90 7366  DPB Bugfix for bizarre I/O stream problem.
*	06/28/90 7236  DSC New Cataloged routine
*
*******************************************************************************
* This subroutine returns a string of at least min.char characters and
* as many as are in the type-ahead buffer at startup and as many
* more are typed in until some timeout of no characters has passed,
* but no more than max.char.  After we get max.char characters, leave the
* rest in the type-ahead buffer.
* The timeout is delay.total milliseconds (in delay.interval-sized pieces).
* (We check for more characters at each repition, so if user has typed
* the maximum then user needn't wait for the full time to expire.)
* This routine uses the echo, prompt, and cursor location as they are.
* WORK: Can this code be made less pastoid?
$INCLUDE UNIVERSE.INCLUDE TTY

      str = ""

* First, fill up with the minimum acceptable
      if min.char > 0 
      then
         for i = 1 to min.char
            str := keyin()
         next i
         char.count = min.char
      end
      else char.count = 0

loopback: 
* Check for too many (only if this parameters was specified)
      if (max.char > 0) and (char.count >= max.char) then goto exit.point

* This print statement is a fix to a bizarre bug where you need to print
* a character on the output stream before you can read a character, or test
* for a character on the input stream.
	IF @term.type # "97801-UV" AND @term.type # "97801-uv" AND @term.type # "97808-UV" AND @term.type # "97808-uv"
	      THEN tprint char(0):

* Check for characters in the type-ahead buffer already
      input more,-1
      if more then goto get.another
* Wait a while, testing for new characters in the type-ahead buffer
* every so often.  An argument could be made to be a CPU hog and just
* test the buffer n times (n =? 100) before timing out.  This is a 
* compromise between that and waiting the full timeout period before
* checking.  It is a design requirement that user must be allowed to
* type at full speed, may not be required to pause between typing
* characters (cf vi).
* This extra wait time is for characters that were typed with one keystroke
* but which got separated (eg by network propagation delays).
      if delay.interval > 0 and delay.total > 0;* Only wait if reasonable values
      then
         for waited.so.far = 1 to delay.total step delay.interval
            nap delay.interval
            input more,-1
            if more then goto get.another
         next waited.so.far
      end
* No more characters came in, so exit
      goto exit.point
get.another:
      str := keyin()
      char.count += 1
      goto loopback
exit.point: 
      return
