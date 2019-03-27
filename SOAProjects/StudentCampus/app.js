
var express = require('express');
var bodyParser = require('body-parser');

var campus = require('./routes/campus'); // Imports routes for the products
var app = express();


// Set up mongoose connection
const mongoose = require('mongoose');
mongoose.connect('mongodb://localhost:27017/CampusDb', { useNewUrlParser: true });
/*var dev_db_url = 'mongodb://someuser:abcd1234@ds123619.mlab.com:23619/productstutorial';
var mongoDB = process.env.MONGODB_URI || dev_db_url;
mongoose.connect(mongoDB);*/
mongoose.Promise = global.Promise;
var db = mongoose.connection;
db.on('error', console.error.bind(console, 'MongoDB connection error:'));

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use('/campuses', campus);

var port = 1234;

app.listen(port, () => {
    console.log('Server is up and running on port numner ' + port);
});