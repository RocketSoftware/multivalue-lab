ExportHelp
==========

This U2 Dynamic Objects sample program will export the ECL/TCL help from 'HELP.FILE' into a JSON string.

You will need to create a directory/type-19 file called EXPORT_FILES. This is where ExportHelp will create 4 files:
HELP.json
HELP.js
Keywords.json
Keywords.js

To create EXPORT_FILES, you can run the following command
* UniData: CREATE.FILE DIR EXPORT_FILES
* UniVerse: CREATE.FILE EXPORT_FILES 19