const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const CampusSchema = new Schema({
    number: { type: Number, required: true },
    adress: { type: String, required: true }
});


// Export the model
module.exports = mongoose.model('Campus', CampusSchema);