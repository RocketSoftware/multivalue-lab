//var http = require('http');
//var port = process.env.port || 1337;
//http.createServer(function (req, res) {
//    res.writeHead(200, { 'Content-Type': 'text/plain' });
//    res.end('Hello World\n');
//}).listen(port);
var http = require('http');
var express = require('express');
var bodyParser = require('body-parser');
var edge = require('edge');

var port = process.env.port || 1337;
var querySample = edge.func({ assemblyFile: 'Test_NodeJS_NativeAccess.dll', typeName: 'Test_NodeJS_NativeAccess.U2Query', methodName: 'Invoke' });
var updateSample = edge.func({ assemblyFile: 'Test_NodeJS_NativeAccess.dll', typeName: 'Test_NodeJS_NativeAccess.U2Query', methodName: 'Invoke_Update' });
//var querySample = edge.func({ assemblyFile: 'Test_NodeJS_SQLAccess.dll', typeName: 'Test_NodeJS_SQLAccess.U2Query', methodName: 'Invoke' });
function logError(err, res) { res.writeHead(200, { 'Content-Type': 'text/plain' }); res.write("Got error: " + err); res.end(""); }
//function logError(err, res) { res.writeHead(200, { 'Content-Type': 'text/html' }); res.write("Got error: " + err); res.end(""); }

var app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));



app.get('/', function (request, response) {
    response.sendFile(__dirname+"/views/HTML2.html");
});

app.get('/api/list', function (request, response) {
    var data = { pageNumber: 2, pageSize: 3 };
    querySample(data, function (error, result) {
        
        if (error) {
           

            console.log("Got error: " + error);

            //logError(error, response); return;
        }
        if (result) {
            
           
            response.end(result);
        }
        else {
            response.end("No results");
        }
    });
    //response.send([{ movieId: '1', name: "The Pacific Rim" } , {movieId: '2', name: "Yeh Jawani Hai Deewani" }
                  
    //             ]);

});

//app.put('/NodeMovieList/api/movies/:movieId', mongoOps.modify);

app.put('/api/list/:movieId', function (request, response) {
    var data2 = request.params.movieId;
    var data = request.body;
    //var data = { pageNumber: data2.FNAME, pageSize: data2.LNAME };
   // var data = { pageNumber: 2, pageSize: 3 };
   // aler(data);
    updateSample(data, function (error, result) {
        
        if (error) {
            logError(error, response); return;
        }
        if (result) {
            
            
            response.end(result);
        }
        else {
            response.end("No results");
        }
    });
    

});





app.listen(port);
