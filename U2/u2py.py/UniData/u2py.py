#
# Rocket Software Confidential
# OCO Source Materials
# Copyright (C) Rocket Software. 2016, 2016
#

"""U2 module for Python, it allows Python developers to
1) call U2BASIC catalogued subroutines
2) run U2 ECL/TCL commands
3) read/write U2 files
4) handle U2 dynamic arrays
5) manage U2 SELECT list
6) control U2 transactions
"""
import os, sys
import random
from _u2py import *
from _u2py import call as _call
from _u2py import _File, _Command, _List, _Subroutine, _DynArray


#
# public functions
#
def run(cmdtext, capture=False):
    ''' 
    run(cmdtext, [capture=False]) -> run a TCL/ECL command
    if capture is True, return the output of the command as a string
    '''         
    cmd = Command(cmdtext)
    if capture is True:
        return cmd.run(True)
    else:
        cmd.run()
        return None


def call(subname, *args):
    newargs = _call(subname, *args)
    for i, arg in enumerate(newargs):
        newarg = DynArray(arg)
        newargs[i] = newarg
    return newargs
call.__doc__ = _call.__doc__

#
#   public classes
#
class Command(_Command):
    __doc__ = _Command.__doc__

    def __repr__(self):
        return _repr_wrapper(self.__class__, self)


    def run(self, capture=False):
        ''' 
        run([capture=False]) -> None -- run the TCL/ECL command, similar to running a command from U2 prompt
        if capture is True, return the output of the command as a string
        '''     
        if capture is True:
            u2_save_stdout = os.dup(sys.stdout.fileno())
            u2_save_stderr = os.dup(sys.stderr.fileno())
            capture_file_name = "u2pyruncapture-{pid}-{random_number}".format(pid = os.getpid(), random_number = random.randrange(10000))
            repstdout = open(capture_file_name, 'w+t',encoding='UTF8', errors="ignore")
            os.dup2(repstdout.fileno(), sys.stdout.fileno())
            os.dup2(repstdout.fileno(), sys.stderr.fileno())

            super().run()

            os.dup2(u2_save_stdout, sys.stdout.fileno())
            os.dup2(u2_save_stderr, sys.stderr.fileno())
    
            repstdout.seek(0,0)
            cmd_output = repstdout.read()
            repstdout.close()
            os.close(u2_save_stdout)
            os.close(u2_save_stderr)
            try:
                os.unlink(capture_file_name)
            except:
                pass
            return cmd_output
        else:
            super().run()
            return None

    pass



class File(_File):
    __doc__ = _File.__doc__

    def __repr__(self):
        return _repr_wrapper(self.__class__, self)

    def read(self, *args):
        return DynArray(super().read(*args))
    read.__doc__ = _File.read.__doc__

    def readv(self, *args):
        return DynArray(super().readv(*args))
    readv.__doc__ = _File.readv.__doc__

    def readnamedfields(self, *args):
        return DynArray(super().readnamedfields(*args))
    readnamedfields.__doc__ = _File.readnamedfields.__doc__

    pass



class List(_List):
    __doc__ = _List.__doc__
    def __repr__(self):
        return _repr_wrapper(self.__class__, self)

    def readlist(self):
        return DynArray(super().readlist())
    readlist.__doc__ = _List.readlist.__doc__

    def next(self):
        return DynArray(super().next())
    next.__doc__ = _List.next.__doc__

    def __next__(self):
        return DynArray(super().__next__())

    pass



class Subroutine(_Subroutine):
    __doc__ = _Subroutine.__doc__
    def __repr__(self):
        return _repr_wrapper(self.__class__, self)

    def call(self):
        super().call()
        for i, arg in enumerate(self.args):
            newarg = DynArray(arg)
            self.args[i] = newarg
    call.__doc__ = _Subroutine.call.__doc__

    pass


class DynArray(_DynArray):
    __doc__ = _DynArray.__doc__
 
    def __init__(self, *args):
        if  len(args) == 1 and isinstance(args[0], list):
            self._normalize_list(args[0])
            return
        else:
            super().__init__(*args)

    def __repr__(self):
        return _repr_wrapper(self.__class__, self)

    def extract(self,  *args, **kwargs):
        return DynArray(super().extract(*args, **kwargs))
    extract.__doc__ = _DynArray.extract.__doc__

    def field(self, *args, **kwargs):
        return DynArray(super().field(*args, **kwargs))
    field.__doc__ = _DynArray.field.__doc__

    def format(self, *args):
        return DynArray(super().format(*args))
    format.__doc__ = _DynArray.format.__doc__

    def iconv(self, *args):
        return DynArray(super().iconv(*args))
    iconv.__doc__ = _DynArray.iconv.__doc__

    def oconv(self, *args):
        return DynArray(super().oconv(*args))
    oconv.__doc__ = _DynArray.oconv.__doc__

    def to_list(self):
        ''' 
        to_list() ->a Python list object -- split the DynArray object into a Python list object using FM/VM/SM as delimiters
        '''     
        
        if len(self._bytes) == 0:
            return []
            
        nested_list = self._bytes.split(FM)
        for i, f in enumerate(nested_list):
            if f.find(VM) == -1 and f.find(SM) == -1:
                pass
            else:
                nested_list[i] = f.split(VM)
                for j, v in enumerate(nested_list[i]):
                    if v.find(SM) == -1:
                        pass
                    else:
                        nested_list[i][j] = v.split(SM)
             
        
        _stringize_list(nested_list)

        return nested_list

    def _normalize_list(self, l):
        barray = bytearray()
        _bytesize_list(barray, l, mark_idx = 1)
        self._bytes =  bytes(barray)



#
# internal helper functions
#

def _stringize_list(l):
    for i, f in enumerate(l):
        if isinstance(f, list):
            _stringize_list(f)
        else:
            l[i] = str(f, config.encoding)

def _bytesize_item(barray, i, mark_idx):
    if isinstance(i, list):
        _bytesize_list(barray, i, mark_idx)
    else:
        barray.extend(_bytesize(i))
    
def _bytesize_list(barray, l, mark_idx):
    if l == []:
        return
    
    mark = _B_MARKS[mark_idx]
    for i in l[:-1]:
        _bytesize_item(barray, i, mark_idx + 1)           
        barray.extend(mark)
         
    _bytesize_item(barray, l[-1], mark_idx + 1)

def _bytesize(v):
    if v is None:
        return b''
    
    if isinstance(v, bytes) or isinstance(v, bytearray):
        return bytes(v)
    else:
        return bytes(str(v), config.encoding, errors = 'replace')

def _repr_wrapper(__class__, self):
     return super(__class__, self).__repr__().replace("_u2py._", "u2py.", 1)


#
# internal module level constants
#
_B_MARKS=[IM, FM, VM, SM, TM]
