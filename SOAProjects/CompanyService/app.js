//
const express = require('express');
const bodyParser = require('body-parser');
// create express app
const app = express();

// parse application/x-www-form-urlencoded
app.use(bodyParser.urlencoded({ extended: true }));

// parse application/json
app.use(bodyParser.json());

// Configuring the database
//require('module-alias/register')
const dbConfig = require('./config/database.js');
const mongoose = require('mongoose');

mongoose.Promise = global.Promise;

// Connecting to the database
mongoose.connect(dbConfig.url, {
    useNewUrlParser: true
}).then(() => {
    console.log("Successfully connected to the database");
}).catch(err => {
    console.log('Could not connect to the database. Exiting now...', err);
    process.exit();
});

// define a simple route
app.get('/', (req, res) => {
    res.json({ "message": "Welcome to EasyNotes application. Take notes quickly. Organize and keep track of all your notes." });
});
//require('module-alias/register');
require('./entrant/entrant_routes')(app);
//require('module-alias/register');
require('./profile/profile_routes')(app);
//import * as routes from './room/room.routes.js';
// listen for requests
app.listen(3000, () => {
    console.log("Server is listening on port 3000");
});