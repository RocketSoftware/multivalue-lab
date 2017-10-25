"""This module is the interface to the U2 XTOOLSUB subroutine, it provides access to common functions.

This module provides access to methods that help the Python programm work with a U2 Database.  It exposes common
functions used by the Rocket U2 Database Tools.  The underlying subroutine is documented in the
following Knowledge Base article:
https://my.rocketsoftware.com/RocketCommunity/articles/Tech_Note/Basic-Developer-Toolkit-Extensibility-Details-1478611802417"""
from u2py import *
import os

cwd = os.getcwd()
initialAccount = cwd.split('\\')[-1]

__version__ = '1.2.3'


def callXTOOLSUB(X_CODE, X_PARAMS):
    """callXTOOLSUB(X_CODE, X_PARMS )

     Parameters
     ----------
     X_CODE   - This is the operation request number that is being passed to the backend.
     X_PARAMS - This includes the parameters that are required by the particular function being performed.

     Returns
     -------
     rtnVal    - The oupput form the call, where the u2py.DynArray output is converted to a list
     rtnStatus - The status of the call
     """
    initCmd = Subroutine("XTOOLSUB", 4)
    initCmd.args[0] = X_CODE
    initCmd.args[1] = X_PARAMS
    initCmd.args[2] = ""
    initCmd.args[3] = "0"
    initCmd.call()
    #
    xout = initCmd.args[2]
    #
    if xout.count(IM) > 0:
        xout.lowerdelim()

    rtnVal = xout.to_list()
    rtnStatus = initCmd.args[3]
    return rtnVal, rtnStatus

def Init():
    """Init( ) - Initialize some global variables"""
    rtnVal, rtnStatus = callXTOOLSUB(0, "")
    return rtnVal

def LogtoAccount(newAccount):
    """Logto a U2 account

     Parameters
     ----------
     newAccount : String
                  Account name, must be defined in the U2 Database, use xtoolsub.GetAccounts
                  to get a list of accounts
     Raises
     ------
     NameError
                  If the newAccount is not valid, or the logto fails."""

    rtnVal, rtnStatus = callXTOOLSUB(2, newAccount)

    if int(rtnStatus) > 0:
        raise NameError(theAccount)

    return

toolVersion = Init()
LogtoAccount(initialAccount)

def test(arg1, arg2):
    arg3 = ""
    arg4 = ""
    rtnVal, rtnStatus = callXTOOLSUB(arg1, arg2)
    print("rtnVal:    " + str(rtnVal))
    print("rtnStatus: " + str(rtnStatus))
    assert isinstance(rtnVal, object)
    return rtnVal


def GetAccounts():
    """Get the list of accounts

     Note: The xtoolsub returns both the path and the account name.
     It is a dynamic array where each attribute contains
     the account name and the path seperated by a value mark.

     This method only returns the account names as a python list.

     returns
     --------
     rtnVal - Python list of account names"""

    rtnVal, rtnStatus = callXTOOLSUB(1, "")
    accountList = []
    for each in rtnVal:
        accountList.append(each[0])

    rtnVal = accountList
    #
    return rtnVal



def GetDTDList():
    """Get a list of DTD files from the local &XML&/_XML_ file

     returns
     --------
     rtnVal - Python list of file names"""
    rtnVal, rtnStatus = callXTOOLSUB(10, "")

    return rtnVal


def GetFileList():
    """List of all data  file names in current account

    returns
    -------
    rtnVal - Python list of file names"""
    rtnVal, rtnStatus = callXTOOLSUB(64, "")

    return rtnVal


def GetDictList(theFile):
    """GetFileList( theFile ) - Get the list of Dictionary items for theFile
        theFile is the id of the file.

    returns
    -------
    rtnVal - Python nested list of the dictionary items.
             note the first [0] element of each nested list is the ID of the dictionary item

    Raises
    ------
    NameError raised if theFile is not valid, or the dictionary can not be read."""
    rtnVal, rtnStatus = callXTOOLSUB(33, theFile)
    if int(rtnStatus) != 0:
        raise NameError(theFile)

    return rtnVal


def GetDTypeList(theFile):
    """Get the list of D-Type Dictionary items IDs only for theFile.

        theFile is the id of the file.

    returns
    -------
    rtnVal - Python list of the dictionary item ids.

    Raises
    ------
    NameError raised if theFile is not valid, or the dictionary can not be read."""
    xout = GetDictList(theFile)

    d_item_list = []

    for each in xout:
        d_item_list.append(each[0])

    return d_item_list

def GetDatabaseType():
    '''By checking the account flavor determines the if the database is UniData or UniVerse'''
    rtnVal = "UniVerse"
    flavor, rtnStatus = callXTOOLSUB(59, "")
    rtnVal = "UniVerse"
    print(rtnStatus)
    if int(rtnStatus) == 1:
        rtnVal = "UniData"

    return rtnVal

