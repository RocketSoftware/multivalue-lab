"""This is a simple example of a module to deal with Rocket MultiValue Named Common.

NAMED COMMON common remains in memory until deleted with the ECL
DELETECOMMON command, even if the program aborts.

A Rocket MV BASIC program uses NAMED COMMON, and we can interact 
with these cariables from a module, like this one, and 
Rocket MV BASIC subroutines.

i.e.  Assume the following NAMED COMMON decleration in BASIC
COMMON /MIKE/ FILEVAR, DATA_ARRAY(10), MY_DYN_ARRAY

The name of the named common in the above example is MIKE, and in this 
example we have three different types of variables defined.

FILEVAR - it is a common practice (no pun intended) to OPEN files to 
          named common, to prevent the re-opeining of the same file.
          ( Since the u2py module does not use these file pointers, 
            do not use a module like this to get the contents. )

MY_DYN_ARRAY - The base type of a variable in MultiValue is the dynamic
          array.  A Dynamic Array can have a single valeu ( i.e. String or
          integer ), or it can be MultiValue ( Attributes, Values, and
          sub-Values )

DATA_ARRAY -    A Dimensioned array with a fixed size.
          in this case 10.  Note that counting of the Array elements
          in MultiValue start at 1.

*** One Issue is that since the MV file pointers can also be stored in
Dimensioned arrays, reading and writing the entire array becomes problematic.

To get around this issue, it is possible to read directly from the variable position.
From our above case, we had
COMMON /MIKE/ FILEVAR, DATA_ARRAY(10), MY_DYN_ARRAY

The named common has defined 12 variables.  This can also be accessed as
COMMON /MIKE/ MY_ARRAY(12)

With this new way of looking at the common, we can access any of the elements we
want based on it position in common.  Set get_one_element and set_one_element

"""
import u2py


def get_one_element(pos):
"""Call the U2 Subroutine that looks at the named common as one dim Array
and get one element, please note that MV counting of array elements
starts with 1"""
    get_it = u2py.call("GET_ONE_ELEMENT", pos, "")
    dynArray = get_it[1].to_list()
    return dynArray


def set_one_element(pos, the_data):
"""Call the U2 Subroutine that looks at the named common as one dim Array
and set one element, please note that MV counting of array elements
starts with 1"""
    to_pass = u2py.DynArray(the_data)
    get_it = u2py.call("SET_ONE_ELEMENT", pos, to_pass)


def get_dimArray():
    """This function returns the named common dimensioned array as a Python nested list.
       It calls the GET_NC_MIKE routine, and retrived the entire DIMARRAY."""
    get_it = u2py.call("GET_NC_MIKE", "DIMARRAY", "")
    dimArray = get_it[1].to_list()
    return dimArray


def set_dimArray(dimArray):
    """ Update the named common with the contents of the nested list.
        This sets the DIMARRAY into common by sending data to the SET_NC_MIKE routine."""
    to_pass = u2py.DynArray(dimArray)
    set_iT = u2py.call("SET_NC_MIKE", "DIMARRAY", to_pass)


def get_dynArray():
    """This function returns the named common dynamic array as a Python nested list.
       It calls the GET_NC_MIKE routine, and retrived the entire DYNARRAY."""
    get_it = u2py.call("GET_NC_MIKE", "DYNARRAY", "")
    dynArray = get_it[1].to_list()
    return dynArray


def set_dynArray(dimArray):
    """ Update the named common with the contents of the nested list.
        This sets the DYNARRAY into common by sending data to the SET_NC_MIKE routine."""
    to_pass = u2py.DynArray(dimArray)
    set_iT = u2py.call("SET_NC_MIKE", "DYNARRAY", to_pass)






