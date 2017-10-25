#
# Rocket Software Confidential
# OCO Source Materials
# Copyright (C) Rocket Software. 2016, 2017
#

"""
    U2 Support module is a set of convenience functions
    for those working with the u2py module.
"""
import u2py

def to_num(x):
    if type(x) == int or type(x) == float:
        return x
    try:
        if type(x) != str:
            x = str(x)
        if type(x) == str:
            try:
                x = int(x)
                return x
            except ValueError:
                x = float(x)
            return x
    except ValueError:
        print("Exception occured while converting " + x + "to a number. Zero will be used.")
        return 0


def to_str(x):
    if type(x) == str:
        return x
    try:
        return str(x)
    except ValueError:
        print("Exception occured while converting an object to a string. Empty string will be used.")
        return ""


def to_DynArray(x):
    if type(x) == u2py.DynArray:
        return x
    try:
        return u2py.DynArray(x)
    except ValueError:
        print("Exception occured while converting an object to a DynArray")
        raise


def to_int(x):
    if type(x) == int:
        return x
    try:
        i = int(x)
        f = float(x)
        if (i != f):
            raise ValueError("value is not integer")
        else:
            return i
    except ValueError:
        print("Exception occured while converting an object to an int")
        raise


def CALL_BASIC(routine, *args):
    '''
    routine - is the cataloged subroutine name.
    *args   - arguments to pass to the subroutine.

    Note this function returns a tuple with the same number of elements
    as arguments passed in for *args.
    '''
    the_subroutine = u2py.Subroutine(routine, len(args))
    cnt = 0
    #    type_list = []
    for each in args:
        #        type_list[cnt] = type(args[cnt])
        the_subroutine.args[cnt] = args[cnt]
        cnt += 1

    the_subroutine.call()
    out_args = []
    for out_var in range(0, cnt):
        thisDyn = the_subroutine.args[out_var]
        try:
            outValue = int(thisDyn)
        except ValueError:
            try:
                outValue = float(thisDyn)
            except ValueError:
                delim = thisDyn.count(u2py.FM) + thisDyn.count(u2py.VM) + thisDyn.count(u2py.SM)
                if delim == 0:
                    try:
                        outValue = str(thisDyn)
                    except ValueError:
                        outValue = thisDyn
                else:
                    outValue = thisDyn
        out_args.append(outValue)
    #
    return out_args


def OCONV(invalue, convCode):
    '''
    invalue - variable ( u2py.DynArray, string or number )
    convCode - Conversion code (see UniVerse BASIC Command Reference Guide)
    
    Returns the output conversion if successful or invlaue if conversion
    failed.
    Note there is no STATUS function at this time.
    
    This function will return a float, int or string 
    based on the results of the conversion. 
    '''

    #
    in_type = type(invalue)
    if in_type == u2py.DynArray:
        outValue = invalue.oconv(convCode)
    else:
        strValue = str(u2py.DynArray(invalue).oconv(convCode))
        outValue = set_type(strValue)
    return outValue


def ICONV(invalue, convCode):
    '''
    invalue - variable ( u2py.DynArray, string or number )
    convCode - Conversion code (see UniVerse BASIC Command Reference Guide)
    #
    Returns the input conversion if successful or invlaue if conversion
    failed.
    Note there is no STATUS function at this time.
    
    This function will return a float, int or string 
    based on the results of the conversion. 
    '''
    strValue = str(u2py.DynArray(invalue).iconv(convCode))
    try:
        outValue = int(strValue)
    except ValueError:
        try:
            outValue = float(strValue)
        except ValueError:
            outValue = strValue
    return outValue


def ALPHA(invalue):
    '''
    ALPHA(invalue) -> True/False -- check if the invalue is an alphabetic string.
    '''
    outValue = u2py.DynArray(invalue).alpha()
    return outValue


def COUNT(invalue, delim):
    '''
    invalue - variable ( u2py.DynArray, string or number )
    delim - delimiter

    Returns the count of the delimiter character in the invalue variable

    Note there is no STATUS function at this time.

   '''
    outValue = u2py.DynArray(invalue).count(delim)
    return outValue


def DCOUNT(invalue, delim):
    '''
    invalue - variable ( u2py.DynArray, string or number )
    delim - delimiter

    Returns the number of fields seperated by the delimiter character
    in the invalu2 variable

    Note there is no STATUS function at this time.

    '''
    outValue = u2py.DynArray(invalue).dcount(delim)
    return outValue


def DELETE(inValue, field, value=None, subvalue=None):
    outValue = u2py.DynArray(inValue)
    if value == None:
        outValue.delete(field)
    else:
        if subvalue == None:
            outValue.delete(field, value)
        else:
            outValue.delete(field, value, subvalue)

    return outValue


def FIELD(inVal, delimiter, occurance, num_substr=None):
    if num_substr == None:
        outValue = u2py.DynArray(inVal).field(delimiter, occurance)
    else:
        outValue = u2py.DynArray(inVal).field(delimiter, occurance, num_substr)
    return outValue


def FMT(innalue, fmtCode):
    outValue = u2py.DynArray(invalue).format(fmtCode)
    return outValue


def FADD(num1, num2):
    '''
    A convenience function for those MV Programmers who utilize this
    function MV BASIC instead of the "+" operator.

    The function will raise an exception if the inputs are not numeric
    '''
    try :
       outValue = float(num1) + float(num2)
    except ValueError:
        raise ValueError

    return outValue

def FDIV(num1, num2):
    '''
    A convenience function for those MV Programmers who utilize this
    function MV BASIC instead of the "/" operator.

    The function will raise an exception if the inputs are not numeric
    '''
    try :
        outValue = float(num1) / float(num2)
    except ValueError:
        raise ValueError
    return outValue


def FMUL(num1, num2):
    outValue = num1 * num2
    return outValue


def INSERT(inValue, field, arg1, arg2=None, arg3=None):
    outValue = u2py.DynArray(inValue)
    if arg2 == None:
        outValue.insert(int(field), arg1)
    else:
        if arg3 == None:
            outValue.insert(int(field), int(arg1), arg2)
        else:
            outValue.insert(int(field), int(arg1), int(arg2), arg3)

    return outValue


def LOWER(inValue):
    outValue = u2py.DynArray(inValue)
    outValue.lowerdelim()
    return outValue


def RAISE(inValue):
    outValue = u2py.DynArray(inValue)
    outValue.raisedelim()
    return outValue


def REPLACE(inValue, field, arg1, arg2=None, arg3=None):
    outValue = u2py.DynArray(inValue)
    if arg2 == None:
        outValue.replace(int(field), arg1)
    else:
        if arg3 == None:
            outValue.replace(int(field), int(arg1), arg2)
        else:
            outValue.replace(int(field), int(arg1), int(arg2), arg3)

    return outValue


def U2READ(theFile, itemId, defaultItem):
    if type(theFile).__name__ == 'File':
        myFile = theFile
    else:
        myFile = u2py.File(theFile)

    notFound = 0
    try:
        rec = myFile.read(itemId)

    except u2py.U2Error:
        if type(defaultItem) == u2py.DynArray:
            rec = defaultItem
        else:
            rec = u2py._DynArray(defaultItem)

    return rec

def u2ReadPyDict( theFile, itemId, fieldList ):
    if type(theFile).__name__ == 'File':
        myFile = theFile
    else:
        myFile = u2py.File(theFile)

    if type(fieldList).__name__ == 'list':
        fieldDynArray = u2py.DynArray(fieldList)
    else:
        raise ValueError("Expecting Python list of field names")
        return null

    notFound = 0
    try:
        rec = myFile.readnamedfields(itemId, fieldDynArray)
        rec_list = rec.to_list()
        my_dict = dict(zip(fieldList, rec_list))
    except u2py.U2Error as e:
        print( "item " + str(itemId) + " was not read from the file")
        print( str(e))

    return my_dict

def u2WritePyDict( theFile, itemId, theDictItem ):
    if type(theFile).__name__ == 'File':
        myFile = theFile
    else:
        myFile = u2py.File(theFile)

    if type(theDictItem).__name__ == 'dict':
        fieldNames, fieldValues = zip(*theDictItem.items())
        fieldNames = u2py.DynArray(list(fieldNames))
        fieldValues = u2py.DynArray(list(fieldValues))
    else:
        raise ValueError("Expecting Python dict item for theDictItem")
        return null

    myFile.writenamedfields(itemId,fieldNames, fieldValues )
    return

def print_at(param):
    this_routine = u2py.Subroutine("PRINT_AT", 1)
    this_routine.args[0] = u2py.DynArray(param)
    this_routine.call()
    return


def nzne(x):
    x = str(x)
    if x == 0 or x == "0" or x == "" or x == None:
        return False
    else:
        return True


def set_type(invalue):
    if type(invalue) == type(list()):
        return invalue

    if type(invalue) == u2py.DynArray:
        invalue = invalue.to_list()
        if len(invalue) > 1 :
           outValue = u2py.DynArray(invalue)
           return outValue
        else :
           invalue = invalue[0]
    try:
        outValue = int(invalue)
    except ValueError:
        try:
            outValue = float(invalue)
        except ValueError:
            outValue = invalue
    return outValue


def to_dynarray(invalue):
    out = u2py.DynArray(invalue)
    return out


def EXTRACT(invalue, *myargs):
    if len(myargs) == 0 or len(myargs) > 3:
        outValue = invalue
        print("r1")
        return outValue
    else:
        if type(invalue) == u2py.DynArray:
            invalue = invalue.to_list()
        else:
            invalue = u2py.DynArray(invalue).to_list()

        this_att = myargs[0] - 1
        if (int(this_att) or this_att == 0) and len(invalue) > this_att:
            invalue = invalue[this_att]
        else:
            invalue = ""

        if len(myargs) > 1:
            print(str(invalue))
            invalue = u2py.DynArray(invalue).to_list()
            this_val = myargs[1] - 1
            if (int(this_val) or this_val == 0) and len(invalue) > this_val and this_val > -1:
                invalue = invalue[this_val]
            else:
                invalue = ""

        if len(myargs) == 3:
            invalue = u2py.DynArray(invalue).to_list()
            this_sval = myargs[2] - 1
            if (int(this_sval) or this_sval == 0) and len(invalue) > this_sval and this_sval > -1:
                invalue = invalue[this_sval]
            else:
                invalue = ""

        outValue = invalue
        outValue = set_type(outValue)
    return outValue
