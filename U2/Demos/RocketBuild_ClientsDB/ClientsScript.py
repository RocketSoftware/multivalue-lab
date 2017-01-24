__author__ = 'U2'
import sys, os
import json, u2py
funcmode = sys.argv[1]
os.chdir("C:\\U2\\ud82\\demo")
theFile = u2py.File("CLIENT.NEW")
if funcmode == 'cl_uploadimg':
    clientkey = sys.argv[2]
    imgsrc = sys.argv[3]
    clrec = theFile.read(clientkey)
    theFile.lock(clientkey)
    clrec.replace(4, imgsrc)
    theFile.write(clientkey,clrec)
    theFile.unlock(clientkey)
if funcmode == 'cl_update':
    filekey = sys.argv[2]
    recvdfile = filekey
    filepath = 'C:\\temp\\' + recvdfile
    fileobj = open(filepath)
    jsonrec = fileobj.read()
    jsondata = json.loads(jsonrec)
    clientkey = jsondata["clientid"]
    clrec = theFile.read(clientkey)
    theFile.lock(clientkey)
    clrec.replace(1, jsondata["Name"])
    clrec.replace(2, 1, jsondata["AddressLine1"])
    clrec.replace(2, 2, jsondata["AddressLine2"])
    clrec.replace(2, 3, jsondata["AddressLine3"])
    clrec.replace(3, jsondata["ZipCode"])
    theFile.write(clientkey,clrec)
    theFile.unlock(clientkey)
if funcmode == 'cl_getdetails':
    client_key = sys.argv[2]
    client_key = str(client_key)
    clientrec = theFile.read(client_key)
    py_array = {}
    py_array["Name"] = str(clientrec.extract(1))
    py_array["AddressLine1"] = str(clientrec.extract(2,1))
    py_array["AddressLine2"] = str(clientrec.extract(2,2))
    py_array["AddressLine3"] = str(clientrec.extract(2,3))
    py_array["ZipCode"] = str(clientrec.extract(3))
    print(json.dumps(py_array))
if funcmode == 'cl_list':
    cmd = u2py.Command("HUSH.SELECT.CLIENT.BY.LNAME")
    cmd.run()
    list = u2py.List(0)
    DynList = list.readlist()
    for eachArg in DynList:
        recKey = str(eachArg[0])
        clientrec = theFile.read(recKey)
        imgsrc = clientrec.extract(4,1,1)
        clientlist = str(recKey) + '\t' + str(imgsrc)
        print(clientlist)
