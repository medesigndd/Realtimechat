
const express = require('express');
const app = express();
const path = require('path');
const server = require('http').createServer(app);

const io = require("socket.io")(server, {
  allowEIO3: true,
  cors: {
    origin: ['https://localhost:44357'],
    methods: ["GET", "POST"],
    credentials: true
  }
});

const port = process.env.PORT || 5555;

server.listen(port, () => {
  console.log('Server listening at port %d', port);
});

app.all("*", function (req, res, next) {
  res.header("Access-Control-Allow-Origin", "*");
  res.header("Access-Control-Allow-Headers", "X-Requested-With");
  res.header("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE,OPTIONS");
  res.header("X-Powered-By", " 3.2.1");
  res.header("Content-Type", "application/json;charset=utf-8");
  next();
});




io.on('connection', (socket) => { 
   
  console.log('a user connected'+socket.id);
 
  socket.on('chatter', (data) => {
	  
    io.emit('chatter', data+' '+socket.id);
	console.log(data); // log โชว์ข้อความ    

 });


io.on('disconnect', function() {
        console.log("disconnected");       
		io.emit('chatter', 'disconnected');
    });

  
});

