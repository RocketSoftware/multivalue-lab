ROCKET BUILD PROJECT – CLIENTS DATABASE

This project makes use of PHP, Javascript, JSON, python, and the UniData database.
In place of a web service, python is used as the interface between the website and the database. All components are stored on the local host.
JSON data is exchanged between python and the website.
The user has the ability to view and update details, as well as upload images to the database for a particular client.

SETUP INSTRUCTIONS

Before we begin…

There were some issues encountered when creating this project:

1)	The C:\temp folder needs to have Everyone with Full Control permissions (or at least Write permissions). This folder is used to store JSON data from php and retrieve JSON data from python. The temp area is used as part of communications between the two interfaces in a couple of functions.
2)	The c:\inetpub\wwroot\images needs to have Everyone with Full Control permissions for image uploads.
3)	Php’s configuration file php.ini needs to have File_uploads set to “On”
4)	Double-quotes in data will cause JSON extract to fail. As a workaround, the php site checks for double-quotes entered in the data. If present, it disallows the update
5)	Resizing the browser window skewers the display. Not too fussed because I didn’t want to invest too much time in making it a whiz-bang website. Was more interested in how the various components interacted.
6)	In this version of the demo, a paragraph needs to be set up in UniData’s demo account.
As part of selection of the clients for this demonstration, the UniData SELECT command is executed by the python script ClientsScript.py.
Prior to the fix for UDT-14749 (Python EAP – Ability to capture the output of a U2 command), we needed to execute HUSH ON/HUSH OFF around the UniData command being executed by Python so that processing instructions aren’t echoed to the client.
Workaround is to create the following paragraph in the VOC of the demo account. The python script ClientsScript.py executes this paragraph.
 
:CT VOC HUSH.SELECT.CLIENT.BY.LNAME
VOC:

HUSH.SELECT.CLIENT.BY.LNAME:
PA
HUSH ON
SELECT CLIENT.NEW BY LNAME
HUSH OFF
:

As of build 98860 of UniData 8.2.0, this workaround is not required and the python script can be changed to something like:
Cmd = u2py.Command(“SELECT CLIENT.NEW BY LNAME”)
Cout = cmd.run(True)  <- the argument ‘True’ instructs python to capture output to the assigned variable.

 
Setting up the demonstration

1.	Store the following php files in your web site’s root directory (e.g. C:\inetpub\wwwroot) :
•	ClientImageForm.php
•	ClientLoadForm.php
•	Clients.php
•	ClientUpdateView.php

2.	Uncompress the imagesClients.zip file and store the resulting Clients folder under your web site’s Images directory (e.g. C:\inetpub\wwwroot\Images).
3.	Store the ClientsScript.py in UniData’s python directory.
4.	Create a file named CLIENT.NEW in UniData’s demo account. Once it is created, you can overwrite the data and dictionary portions of the file with the attachment CLIENT.NEW and D_CLIENT.NEW in this demo. Alternatively, it may be easier to key the items in (depending on how fast you type : )


Listing of dictionary of CLIENT.NEW:

LIST DICT CLIENT.NEW BY TYP BY @ID TYP LOC CONV NAME FORMAT SM ASSOC 11:49:02 Nov 09 2016 1
@ID............ TYP LOC.......... CONV NAME........... FORMAT SM ASSOC.....

@ID             D               0      Customer #      10L    S
ADDRESS         D               2      Address         25T    S
IMGSRC          D               4      Image source    20L    S
NAME            D               1      Name            15T    S
ZIP_CODE        D               3      Postal Code     10L    S
JSONOBJECT      I   SUBR("SEND.CL      JSON Object     100L   S
                    IENT",@ID);CO
                    NVERT(CHAR(9)
                    ,'',@1);CONVE
                    RT(CHAR(10),'
                    ',@2);CONVERT
                    (CHAR(12),'',
                    @3)
KEYPLUSIMGSRC   I   @ID:CHAR(9):I                      40L    S
                    MGSRC
LNAME           I   FIELD(NAME,'       Lname           15T    S
                    ',2)
8 records listed

Listing of data portion of CLIENT.NEW:

:SELECT CLIENT.NEW

5 records selected to list 0.

>CT CLIENT.NEW
ITEMID
CLIENT.NEW:
Use select list data(Y/N)? Y

9965:
Gary Phillips
8899 S. Taylor St.²New York²OH
00213
Client9965.jpg

9967:
Tamara Vincent
6825 N. Filmore Blvd.²Charlotte Town²PEI
C1A7N7
Client9967.jpg

9966:
Phil Becker
P.O. Box 212²Hawthorn²Victoria
3122
Client9966.jpg

9969:
Alicia Rodriguez
9676 Antonio St.²Philadelphia²PA
Enter <New line> to continue...
19070
Client9969.jpg

9968:
Deborah Adams
4415 119th St.²Cleveland²OH
32226
Client9968.jpg


Running with it

Specify the URL http://localhost/Clients.php in the address bar of your browser and you're ready to roll.
