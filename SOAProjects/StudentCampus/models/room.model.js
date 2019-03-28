var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var RoomSchema = new Schema({
    id: { type: Number, required: true },
    number: { type: Number, required: true },
    place_count: { type: Number, required: true },
    campus_id: { type: Number, required: true }
});


// Export the model
module.exports = mongoose.model('Room', RoomSchema);