D3 R/LINK Basic Demos
=====================

EXAMPLE-RLINK.ORDER.PROCESSING
------------------------------

A D3 FlashBASIC program that reads .TXT and .CSV order files from an R/Link folder, processes the orders and places .TXT and .CSV confirmation/error files in other R/Link folders.

PARSE.RLINK.ORDER.SUB
---------------------

Called by EXAMPLE-RLINK.ORDER.PROCESSING. A D3 FlashBASIC subroutine that parses a .TXT or .CSV file into a dynamic array consistent with an item in the SQLDEMO,ORDERS, file.

GEN.RLINK.ORDER.SUB
-------------------

Called by EXAMPLE-RLINK.ORDER.PROCESSING. A D3 FlashBASIC subroutine that completes the dynamic array started by PARSE.RLINK.ORDER.SUB and writes it to the SQLDEMO,ORDERS, file.

GEN.RLINK.ORDER.RESPONSE.SUB
----------------------------

Called by EXAMPLE-RLINK.ORDER.PROCESSING. A D3 FlashBASIC subroutine that uses data contained in the newly-created ORDERS item to create a dynamic array (with errors if detected) to be placed in the CONFIRMED or ERRORS R/Link folder as a .TXT or .CSV file.

GET.JSON.FIELD.SUB
------------------

Called by EXAMPLE-RLINK.ORDER.PROCESSING. A D3 FlashBASIC subroutine that returns a dynamic array containing information extracted from a JSON string. Each attribute of the dynamic array is the value, object or array associated with the passed name.

HTTP.GET.SUB
----------------------

Called by EXAMPLE-RLINK.ORDER.PROCESSING and EXAMPLE-RLINK.STATEMENT.PDF. Uses D3's built-in FlashBASIC socket functions to send an HTTP GET request to a server and retrieve the response.

HTTP.POST.SUB
----------------------

Called by EXAMPLE-RLINK.STATEMENT.PDF. Uses D3's built-in FlashBASIC socket functions to send data as HTTP POST content to a server and retrieve the status response.