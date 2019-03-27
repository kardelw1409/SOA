var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var CampusSchema = new Schema({
    id: { type: Number, required: true},
    adress: { type: String, required: true, max: 100 }
});


// Export the model
module.exports = mongoose.model('Campus', CampusSchema);