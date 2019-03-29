import { ObjectID } from '../../../../../../../AppData/Local/Microsoft/TypeScript/2.6/node_modules/@types/bson';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var CampusSchema = require('../campus/campus.model');

var RoomSchema = new Schema({
    number: Number,
    place_count: Number,
    _campus_id: ObjectID,
    campuses: [CampusSchema]
});


// Export the model
module.exports = mongoose.model('Room', RoomSchema);