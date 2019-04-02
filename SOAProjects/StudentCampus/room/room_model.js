const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const CampusSchema = require('../campus/campus_model');

const RoomSchema = new Schema({
    number: Number,
    place_count: Number,
    _campus_id: String
});


// Export the model
module.exports = mongoose.model('Room', RoomSchema);