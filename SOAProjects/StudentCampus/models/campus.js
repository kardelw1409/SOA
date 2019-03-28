var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var CampusSchema = new Schema({
    number: { type: Number, required: true },
    adress: { type: String, required: true }
});


// Export the model
module.exports = mongoose.model('Campus', CampusSchema);