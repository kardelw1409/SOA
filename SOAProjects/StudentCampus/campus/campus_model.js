const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const CampusSchema = new Schema({
    _id: Schema.Types.ObjectId,
    number: { type: Number, required: true },
    adress: { type: String, required: true },
    rooms: [{ type: Schema.Types.ObjectId, ref: 'Room' }]
});


// Export the model
module.exports = mongoose.model('Campus', CampusSchema);