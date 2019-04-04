const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const CampusSchema = require('../campus/campus_model');

const RoomSchema = new Schema({
    number: { type: Number, required: true },
    place_count: { type: Number, required: true },
    _campus_id: { type: Schema.Types.ObjectId, ref: 'Campus' }
});


// Export the model
module.exports = mongoose.model('Room', RoomSchema);