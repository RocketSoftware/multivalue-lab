# Timing Verb

This program will enable you to record the running time of specific verbs without needing to change any calls to that verb.

## Usage:

Rename a verb's VOC entry by prefixing 'STD' at the start, then copy this programs VOC entry to the original verb's. If you also copy the original verb's VOC entry to a lowercase version with 'std' as the prefix, it will preserve lower case mode switching.

## Results:

All timing results are stored in a file called QUERY.REPORTING.FILE

## Example:

Copy SELECT -> STDSELECT & stdselect  
Copy VERBTIMER -> SELECT  
In this example, all SELECT statements will now be timed.

## Notes:
For UniVerse, you will need to add 'K' to attribute 4 of this verb's VOC entry if you wish it to work correctly with select lists. So for timing verbs like SELECT, this is a must.
